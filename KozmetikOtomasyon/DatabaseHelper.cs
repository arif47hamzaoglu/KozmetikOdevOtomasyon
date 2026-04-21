using System;
using System.Collections.Generic;
using System.Configuration;
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
                            Password VARCHAR(100) NOT NULL
                        );", con).ExecuteNonQuery();

                    new MySqlCommand(@"
                        CREATE TABLE IF NOT EXISTS Products (
                            Id    INT AUTO_INCREMENT PRIMARY KEY,
                            Name  VARCHAR(100)  NOT NULL,
                            Price DECIMAL(10,2) NOT NULL,
                            Stock INT           NOT NULL DEFAULT 0
                        );", con).ExecuteNonQuery();

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

                    // Varsayılan admin yoksa ekle
                    long count = (long)new MySqlCommand(
                        "SELECT COUNT(*) FROM Users WHERE Email='admin@admin.com'", con).ExecuteScalar();

                    if (count == 0)
                    {
                        new MySqlCommand(@"
                            INSERT INTO Users (Name, Email, Password)
                            VALUES ('Admin', 'admin@admin.com', '123456');", con).ExecuteNonQuery();
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
                            Password = reader.GetString("Password")
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
                            Id    = reader.GetInt32("Id"),
                            Name  = reader.GetString("Name"),
                            Price = reader.GetDecimal("Price"),
                            Stock = reader.GetInt32("Stock")
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
                        "INSERT INTO Products (Name, Price, Stock) VALUES (@name, @price, @stock)", con);
                    cmd.Parameters.AddWithValue("@name",  p.Name);
                    cmd.Parameters.AddWithValue("@price", p.Price);
                    cmd.Parameters.AddWithValue("@stock", p.Stock);
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
                        "UPDATE Products SET Name=@name, Price=@price, Stock=@stock WHERE Id=@id", con);
                    cmd.Parameters.AddWithValue("@name",  p.Name);
                    cmd.Parameters.AddWithValue("@price", p.Price);
                    cmd.Parameters.AddWithValue("@stock", p.Stock);
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
    }
}
