using System;
using System.Collections.Generic;
using System.Configuration;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Windows.Forms;
using MySql.Data.MySqlClient;
using KozmetikOtomasyon.Models;

namespace KozmetikOtomasyon
{
    // Tüm veritabanı işlemlerini bu sınıf yönetir
    public static class DatabaseHelper
    {
        private static string connectionString =
            $"Server={ConfigurationManager.AppSettings["DbServer"]};" +
            $"Port={ConfigurationManager.AppSettings["DbPort"]};" +
            $"Database={ConfigurationManager.AppSettings["DbName"]};" +
            $"Uid={ConfigurationManager.AppSettings["DbUser"]};" +
            $"Pwd={ConfigurationManager.AppSettings["DbPassword"]};";

        private static MySqlConnection GetConnection()
        {
            return new MySqlConnection(connectionString);
        }

        // Uygulama açılınca veritabanını ve tabloları oluşturur
        public static void Initialize()
        {
            try
            {
                string rootConn =
                    $"Server={ConfigurationManager.AppSettings["DbServer"]};" +
                    $"Port={ConfigurationManager.AppSettings["DbPort"]};" +
                    $"Uid={ConfigurationManager.AppSettings["DbUser"]};" +
                    $"Pwd={ConfigurationManager.AppSettings["DbPassword"]};";

                using (var con = new MySqlConnection(rootConn))
                {
                    con.Open();
                    string dbName = ConfigurationManager.AppSettings["DbName"];
                    new MySqlCommand($"CREATE DATABASE IF NOT EXISTS `{dbName}`;", con).ExecuteNonQuery();
                }

                using (var con = GetConnection())
                {
                    con.Open();

                    new MySqlCommand(@"
                        CREATE TABLE IF NOT EXISTS Users (
                            Id       INT AUTO_INCREMENT PRIMARY KEY,
                            Name     VARCHAR(100) NOT NULL,
                            Email    VARCHAR(100) NOT NULL UNIQUE,
                            Password VARCHAR(100) NOT NULL,
                            IsAdmin  TINYINT(1)   NOT NULL DEFAULT 0
                        );", con).ExecuteNonQuery();

                    new MySqlCommand(@"
                        ALTER TABLE Users
                        ADD COLUMN IF NOT EXISTS IsAdmin TINYINT(1) NOT NULL DEFAULT 0;",
                        con).ExecuteNonQuery();

                    new MySqlCommand(@"
                        CREATE TABLE IF NOT EXISTS Products (
                            Id        INT AUTO_INCREMENT PRIMARY KEY,
                            Name      VARCHAR(100)  NOT NULL,
                            Price     DECIMAL(10,2) NOT NULL,
                            Stock     INT           NOT NULL DEFAULT 0,
                            ImagePath VARCHAR(500)  DEFAULT NULL
                        );", con).ExecuteNonQuery();

                    new MySqlCommand(@"
                        ALTER TABLE Products
                        ADD COLUMN IF NOT EXISTS ImagePath VARCHAR(500) DEFAULT NULL;",
                        con).ExecuteNonQuery();

                    new MySqlCommand(@"
                        CREATE TABLE IF NOT EXISTS Orders (
                            Id         INT AUTO_INCREMENT PRIMARY KEY,
                            UserId     INT           NOT NULL,
                            ProductId  INT           NOT NULL,
                            Quantity   INT           NOT NULL,
                            TotalPrice DECIMAL(10,2) NOT NULL,
                            OrderDate  DATETIME      NOT NULL,
                            Status     VARCHAR(20)   NOT NULL DEFAULT 'Beklemede'
                        );", con).ExecuteNonQuery();

                    // Parfüm görselleri ve örnek ürünleri ekle
                    EnsureProductImages();
                    AddProductIfNotExists("Sauvage - Dior",      2850m, 50, @"Images\sauvage.png");
                    AddProductIfNotExists("My Way - Armani",     3200m, 30, @"Images\myway.png");
                    AddProductIfNotExists("Chance - Chanel",     4100m, 25, @"Images\chance.png");
                    AddProductIfNotExists("Eros - Versace",      2400m, 40, @"Images\eros.png");

                    // Varsayılan admin yoksa ekle
                    long count = (long)new MySqlCommand(
                        "SELECT COUNT(*) FROM Users WHERE Email='admin@admin.com'", con).ExecuteScalar();

                    if (count == 0)
                    {
                        new MySqlCommand(@"
                            INSERT INTO Users (Name, Email, Password, IsAdmin)
                            VALUES ('Admin', 'admin@admin.com', '123456', 1);", con).ExecuteNonQuery();
                    }
                    else
                    {
                        new MySqlCommand(
                            "UPDATE Users SET IsAdmin=1 WHERE Email='admin@admin.com'", con)
                            .ExecuteNonQuery();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Veritabanı bağlantısı kurulamadı!\n\n" + ex.Message +
                    "\n\nApp.config dosyasındaki MySQL ayarlarını kontrol edin.",
                    "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // ─── GİRİŞ ───────────────────────────────────────
        public static User Login(string email, string password)
        {
            try
            {
                using (var con = GetConnection())
                {
                    con.Open();
                    var cmd = new MySqlCommand(
                        "SELECT * FROM Users WHERE Email=@email AND Password=@pass", con);
                    cmd.Parameters.AddWithValue("@email", email);
                    cmd.Parameters.AddWithValue("@pass",  password);

                    var reader = cmd.ExecuteReader();
                    if (reader.Read())
                    {
                        return new User
                        {
                            Id       = reader.GetInt32("Id"),
                            Name     = reader.GetString("Name"),
                            Email    = reader.GetString("Email"),
                            Password = reader.GetString("Password"),
                            IsAdmin  = reader.GetBoolean("IsAdmin")
                        };
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Giriş hatası: " + ex.Message, "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            return null;
        }

        // ─── ÜRÜNLER ─────────────────────────────────────
        public static List<Product> GetProducts()
        {
            var list = new List<Product>();
            try
            {
                using (var con = GetConnection())
                {
                    con.Open();
                    var reader = new MySqlCommand("SELECT * FROM Products", con).ExecuteReader();
                    while (reader.Read())
                    {
                        list.Add(new Product
                        {
                            Id        = reader.GetInt32("Id"),
                            Name      = reader.GetString("Name"),
                            Price     = reader.GetDecimal("Price"),
                            Stock     = reader.GetInt32("Stock"),
                            ImagePath = reader.IsDBNull(reader.GetOrdinal("ImagePath"))
                                        ? null : reader.GetString("ImagePath")
                        });
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ürünler yüklenemedi: " + ex.Message, "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            return list;
        }

        public static void AddProduct(Product p)
        {
            try
            {
                using (var con = GetConnection())
                {
                    con.Open();
                    var cmd = new MySqlCommand(
                        "INSERT INTO Products (Name, Price, Stock, ImagePath) VALUES (@name, @price, @stock, @img)", con);
                    cmd.Parameters.AddWithValue("@name",  p.Name);
                    cmd.Parameters.AddWithValue("@price", p.Price);
                    cmd.Parameters.AddWithValue("@stock", p.Stock);
                    cmd.Parameters.AddWithValue("@img",   (object)p.ImagePath ?? DBNull.Value);
                    cmd.ExecuteNonQuery();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ürün eklenemedi: " + ex.Message, "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public static void UpdateProduct(Product p)
        {
            try
            {
                using (var con = GetConnection())
                {
                    con.Open();
                    var cmd = new MySqlCommand(
                        "UPDATE Products SET Name=@name, Price=@price, Stock=@stock, ImagePath=@img WHERE Id=@id", con);
                    cmd.Parameters.AddWithValue("@name",  p.Name);
                    cmd.Parameters.AddWithValue("@price", p.Price);
                    cmd.Parameters.AddWithValue("@stock", p.Stock);
                    cmd.Parameters.AddWithValue("@img",   (object)p.ImagePath ?? DBNull.Value);
                    cmd.Parameters.AddWithValue("@id",    p.Id);
                    cmd.ExecuteNonQuery();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ürün güncellenemedi: " + ex.Message, "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public static void DeleteProduct(int id)
        {
            try
            {
                using (var con = GetConnection())
                {
                    con.Open();
                    var cmd = new MySqlCommand("DELETE FROM Products WHERE Id=@id", con);
                    cmd.Parameters.AddWithValue("@id", id);
                    cmd.ExecuteNonQuery();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ürün silinemedi: " + ex.Message, "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // ─── SİPARİŞLER ──────────────────────────────────
        public static bool AddOrder(int userId, int productId, int quantity)
        {
            try
            {
                using (var con = GetConnection())
                {
                    con.Open();

                    var checkCmd = new MySqlCommand("SELECT Price, Stock FROM Products WHERE Id=@id", con);
                    checkCmd.Parameters.AddWithValue("@id", productId);
                    var reader = checkCmd.ExecuteReader();

                    if (!reader.Read()) return false;
                    decimal price = reader.GetDecimal("Price");
                    int     stock = reader.GetInt32("Stock");
                    reader.Close();

                    if (stock < quantity)
                    {
                        MessageBox.Show("Yeterli stok yok!", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return false;
                    }

                    var cmd = new MySqlCommand(@"
                        INSERT INTO Orders (UserId, ProductId, Quantity, TotalPrice, OrderDate, Status)
                        VALUES (@uid, @pid, @qty, @total, @date, 'Beklemede')", con);
                    cmd.Parameters.AddWithValue("@uid",   userId);
                    cmd.Parameters.AddWithValue("@pid",   productId);
                    cmd.Parameters.AddWithValue("@qty",   quantity);
                    cmd.Parameters.AddWithValue("@total", price * quantity);
                    cmd.Parameters.AddWithValue("@date",  DateTime.Now);
                    cmd.ExecuteNonQuery();

                    var stockCmd = new MySqlCommand("UPDATE Products SET Stock=Stock-@qty WHERE Id=@id", con);
                    stockCmd.Parameters.AddWithValue("@qty", quantity);
                    stockCmd.Parameters.AddWithValue("@id",  productId);
                    stockCmd.ExecuteNonQuery();

                    return true;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Sipariş verilemedi: " + ex.Message, "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }

        public static List<Order> GetOrders()
        {
            var list = new List<Order>();
            try
            {
                using (var con = GetConnection())
                {
                    con.Open();
                    var cmd = new MySqlCommand(@"
                        SELECT o.Id, o.UserId, u.Name AS UserName, p.Name AS ProductName,
                               o.Quantity, o.TotalPrice, o.OrderDate, o.Status
                        FROM Orders o
                        JOIN Users    u ON o.UserId    = u.Id
                        JOIN Products p ON o.ProductId = p.Id
                        ORDER BY o.OrderDate DESC", con);

                    var reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        list.Add(new Order
                        {
                            Id          = reader.GetInt32("Id"),
                            UserId      = reader.GetInt32("UserId"),
                            UserName    = reader.GetString("UserName"),
                            ProductName = reader.GetString("ProductName"),
                            Quantity    = reader.GetInt32("Quantity"),
                            TotalPrice  = reader.GetDecimal("TotalPrice"),
                            OrderDate   = reader.GetDateTime("OrderDate"),
                            Status      = reader.GetString("Status")
                        });
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Siparişler yüklenemedi: " + ex.Message, "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            return list;
        }

        public static List<Order> GetOrdersByUser(int userId)
        {
            var list = new List<Order>();
            try
            {
                using (var con = GetConnection())
                {
                    con.Open();
                    var cmd = new MySqlCommand(@"
                        SELECT o.Id, o.UserId, u.Name AS UserName, p.Name AS ProductName,
                               o.Quantity, o.TotalPrice, o.OrderDate, o.Status
                        FROM Orders o
                        JOIN Users    u ON o.UserId    = u.Id
                        JOIN Products p ON o.ProductId = p.Id
                        WHERE o.UserId = @uid
                        ORDER BY o.OrderDate DESC", con);
                    cmd.Parameters.AddWithValue("@uid", userId);

                    var reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        list.Add(new Order
                        {
                            Id          = reader.GetInt32("Id"),
                            UserId      = reader.GetInt32("UserId"),
                            UserName    = reader.GetString("UserName"),
                            ProductName = reader.GetString("ProductName"),
                            Quantity    = reader.GetInt32("Quantity"),
                            TotalPrice  = reader.GetDecimal("TotalPrice"),
                            OrderDate   = reader.GetDateTime("OrderDate"),
                            Status      = reader.GetString("Status")
                        });
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Siparişler yüklenemedi: " + ex.Message, "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            return list;
        }

        public static void UpdateOrderStatus(int orderId, string status)
        {
            try
            {
                using (var con = GetConnection())
                {
                    con.Open();
                    var cmd = new MySqlCommand("UPDATE Orders SET Status=@status WHERE Id=@id", con);
                    cmd.Parameters.AddWithValue("@status", status);
                    cmd.Parameters.AddWithValue("@id",     orderId);
                    cmd.ExecuteNonQuery();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Durum güncellenemedi: " + ex.Message, "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // ─── KULLANICI KAYIT ─────────────────────────────
        public static bool RegisterUser(User user)
        {
            try
            {
                using (var con = GetConnection())
                {
                    con.Open();
                    var check = new MySqlCommand("SELECT COUNT(*) FROM Users WHERE Email=@email", con);
                    check.Parameters.AddWithValue("@email", user.Email);
                    if ((long)check.ExecuteScalar() > 0)
                    {
                        MessageBox.Show("Bu email zaten kayıtlı!", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return false;
                    }

                    var cmd = new MySqlCommand(
                        "INSERT INTO Users (Name, Email, Password, IsAdmin) VALUES (@name, @email, @pass, 0)", con);
                    cmd.Parameters.AddWithValue("@name",  user.Name);
                    cmd.Parameters.AddWithValue("@email", user.Email);
                    cmd.Parameters.AddWithValue("@pass",  user.Password);
                    cmd.ExecuteNonQuery();
                    return true;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Kayıt hatası: " + ex.Message, "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }

        // ─── ŞİFRE SIFIRLAMA ─────────────────────────────
        public static bool ResetPassword(string email, string newPassword)
        {
            try
            {
                using (var con = GetConnection())
                {
                    con.Open();
                    var check = new MySqlCommand("SELECT COUNT(*) FROM Users WHERE Email=@email", con);
                    check.Parameters.AddWithValue("@email", email);
                    if ((long)check.ExecuteScalar() == 0)
                    {
                        MessageBox.Show("Bu email ile kayıtlı kullanıcı bulunamadı!", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return false;
                    }

                    var cmd = new MySqlCommand("UPDATE Users SET Password=@pass WHERE Email=@email", con);
                    cmd.Parameters.AddWithValue("@pass",  newPassword);
                    cmd.Parameters.AddWithValue("@email", email);
                    cmd.ExecuteNonQuery();
                    return true;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Şifre sıfırlama hatası: " + ex.Message, "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }

        // ─── GÖRSEL YARDIMCILARI ─────────────────────────
        private static void EnsureProductImages()
        {
            string imgDir = Path.Combine(Application.StartupPath, "Images");
            if (!Directory.Exists(imgDir))
                Directory.CreateDirectory(imgDir);

            CreatePerfumeImage(Path.Combine(imgDir, "sauvage.png"),
                "SAUVAGE", "DIOR",
                Color.FromArgb(8, 18, 60), Color.FromArgb(30, 60, 130),
                Color.White, Color.FromArgb(210, 180, 90));

            CreatePerfumeImage(Path.Combine(imgDir, "myway.png"),
                "MY WAY", "GIORGIO ARMANI",
                Color.FromArgb(170, 90, 100), Color.FromArgb(230, 165, 170),
                Color.White, Color.FromArgb(250, 230, 220));

            CreatePerfumeImage(Path.Combine(imgDir, "chance.png"),
                "CHANCE", "CHANEL",
                Color.FromArgb(240, 195, 205), Color.FromArgb(255, 228, 232),
                Color.FromArgb(25, 25, 25), Color.FromArgb(80, 55, 60));

            CreatePerfumeImage(Path.Combine(imgDir, "eros.png"),
                "EROS", "VERSACE",
                Color.FromArgb(0, 105, 135), Color.FromArgb(0, 175, 205),
                Color.White, Color.FromArgb(215, 185, 40));
        }

        private static void CreatePerfumeImage(string filePath,
            string perfumeName, string brandName,
            Color topColor, Color bottomColor,
            Color nameColor, Color brandColor)
        {
            if (File.Exists(filePath)) return;

            int w = 220, h = 290;
            using (var bmp = new Bitmap(w, h))
            using (var g = Graphics.FromImage(bmp))
            {
                g.SmoothingMode       = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;
                g.TextRenderingHint   = System.Drawing.Text.TextRenderingHint.ClearTypeGridFit;

                // Gradient arka plan
                using (var br = new System.Drawing.Drawing2D.LinearGradientBrush(
                    new Rectangle(0, 0, w, h), topColor, bottomColor,
                    System.Drawing.Drawing2D.LinearGradientMode.Vertical))
                    g.FillRectangle(br, 0, 0, w, h);

                // Şişe kapağı
                g.FillRectangle(new SolidBrush(brandColor), 85, 20, 50, 16);
                g.DrawRectangle(new Pen(Color.FromArgb(80, Color.White), 1), 85, 20, 50, 16);

                // Şişe boynu
                g.FillRectangle(new SolidBrush(Color.FromArgb(170, Color.White)), 93, 36, 34, 22);

                // Şişe gövdesi
                g.FillRectangle(new SolidBrush(Color.FromArgb(160, Color.White)), 58, 58, 104, 140);
                g.DrawRectangle(new Pen(Color.FromArgb(80, Color.White), 1.5f), 58, 58, 104, 140);

                // İç etiket
                g.FillRectangle(new SolidBrush(Color.FromArgb(60, Color.White)), 65, 90, 90, 70);

                // Parfüm adı (büyük)
                using (var font = new Font("Segoe UI", 15, FontStyle.Bold))
                {
                    var sf = new StringFormat { Alignment = StringAlignment.Center };
                    g.DrawString(perfumeName, font, new SolidBrush(nameColor),
                        new RectangleF(0, 210, w, 36), sf);
                }
                // Marka adı (küçük)
                using (var font = new Font("Segoe UI", 9, FontStyle.Regular))
                {
                    var sf = new StringFormat { Alignment = StringAlignment.Center };
                    g.DrawString(brandName, font, new SolidBrush(brandColor),
                        new RectangleF(0, 250, w, 24), sf);
                }

                bmp.Save(filePath, ImageFormat.Png);
            }
        }

        private static void AddProductIfNotExists(string name, decimal price, int stock, string imagePath)
        {
            try
            {
                using (var con = GetConnection())
                {
                    con.Open();
                    var check = new MySqlCommand("SELECT COUNT(*) FROM Products WHERE Name=@name", con);
                    check.Parameters.AddWithValue("@name", name);
                    if ((long)check.ExecuteScalar() > 0) return;

                    var cmd = new MySqlCommand(
                        "INSERT INTO Products (Name, Price, Stock, ImagePath) VALUES (@name, @price, @stock, @img)", con);
                    cmd.Parameters.AddWithValue("@name",  name);
                    cmd.Parameters.AddWithValue("@price", price);
                    cmd.Parameters.AddWithValue("@stock", stock);
                    cmd.Parameters.AddWithValue("@img",   imagePath);
                    cmd.ExecuteNonQuery();
                }
            }
            catch { }
        }

        // ─── RAPOR ───────────────────────────────────────
        public static List<int> GetReportYears()
        {
            var list = new List<int>();
            try
            {
                using (var con = GetConnection())
                {
                    con.Open();
                    var reader = new MySqlCommand(
                        "SELECT DISTINCT YEAR(OrderDate) AS Yil FROM Orders ORDER BY Yil DESC", con)
                        .ExecuteReader();
                    while (reader.Read())
                        list.Add(reader.GetInt32("Yil"));
                }
            }
            catch { }

            if (list.Count == 0)
                list.Add(DateTime.Now.Year);

            return list;
        }

        public static List<MonthlyReport> GetMonthlyReport(int year)
        {
            var list = new List<MonthlyReport>();
            var ayAdlari = new[] {
                "Ocak","Şubat","Mart","Nisan","Mayıs","Haziran",
                "Temmuz","Ağustos","Eylül","Ekim","Kasım","Aralık"
            };

            try
            {
                using (var con = GetConnection())
                {
                    con.Open();
                    var cmd = new MySqlCommand(@"
                        SELECT
                            MONTH(OrderDate) AS AySayisi,
                            COUNT(*)         AS ToplamSiparis,
                            IFNULL(SUM(TotalPrice), 0) AS ToplamCiro,
                            SUM(CASE WHEN Status='Onaylandı' THEN 1 ELSE 0 END) AS Onaylanan,
                            SUM(CASE WHEN Status='Beklemede' THEN 1 ELSE 0 END) AS Bekleyen,
                            SUM(CASE WHEN Status='İptal'     THEN 1 ELSE 0 END) AS Iptal
                        FROM Orders
                        WHERE YEAR(OrderDate) = @year
                        GROUP BY MONTH(OrderDate)
                        ORDER BY MONTH(OrderDate)", con);
                    cmd.Parameters.AddWithValue("@year", year);

                    var reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        int ay = reader.GetInt32("AySayisi");
                        list.Add(new MonthlyReport
                        {
                            AySayisi      = ay,
                            Ay            = ayAdlari[ay - 1],
                            ToplamSiparis = reader.GetInt32("ToplamSiparis"),
                            ToplamCiro    = reader.GetDecimal("ToplamCiro"),
                            Onaylanan     = reader.GetInt32("Onaylanan"),
                            Bekleyen      = reader.GetInt32("Bekleyen"),
                            Iptal         = reader.GetInt32("Iptal")
                        });
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Rapor yüklenemedi: " + ex.Message, "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            return list;
        }

        public static List<TopProduct> GetTopProducts(int year, int topN = 10)
        {
            var list = new List<TopProduct>();
            try
            {
                using (var con = GetConnection())
                {
                    con.Open();
                    var cmd = new MySqlCommand(@"
                        SELECT
                            p.Name                     AS UrunAdi,
                            SUM(o.Quantity)            AS ToplamAdet,
                            IFNULL(SUM(o.TotalPrice),0) AS ToplamCiro
                        FROM Orders o
                        JOIN Products p ON o.ProductId = p.Id
                        WHERE YEAR(o.OrderDate) = @year
                        GROUP BY p.Id, p.Name
                        ORDER BY ToplamAdet DESC
                        LIMIT @topN", con);
                    cmd.Parameters.AddWithValue("@year", year);
                    cmd.Parameters.AddWithValue("@topN", topN);

                    var reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        list.Add(new TopProduct
                        {
                            UrunAdi    = reader.GetString("UrunAdi"),
                            ToplamAdet = reader.GetInt32("ToplamAdet"),
                            ToplamCiro = reader.GetDecimal("ToplamCiro")
                        });
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("En çok satan raporu yüklenemedi: " + ex.Message, "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            return list;
        }

        // ─── PROFİL GÜNCELLEME ────────────────────────────
        public static bool UpdateUser(User user)
        {
            try
            {
                using (var con = GetConnection())
                {
                    con.Open();
                    var check = new MySqlCommand(
                        "SELECT COUNT(*) FROM Users WHERE Email=@email AND Id!=@id", con);
                    check.Parameters.AddWithValue("@email", user.Email);
                    check.Parameters.AddWithValue("@id",    user.Id);
                    if ((long)check.ExecuteScalar() > 0)
                    {
                        MessageBox.Show("Bu email başka bir kullanıcı tarafından kullanılıyor!", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return false;
                    }

                    var cmd = new MySqlCommand(
                        "UPDATE Users SET Name=@name, Email=@email, Password=@pass WHERE Id=@id", con);
                    cmd.Parameters.AddWithValue("@name",  user.Name);
                    cmd.Parameters.AddWithValue("@email", user.Email);
                    cmd.Parameters.AddWithValue("@pass",  user.Password);
                    cmd.Parameters.AddWithValue("@id",    user.Id);
                    cmd.ExecuteNonQuery();
                    return true;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Profil güncellenemedi: " + ex.Message, "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }
    }
}
