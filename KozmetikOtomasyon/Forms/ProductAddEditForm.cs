using System;
using System.IO;
using System.Windows.Forms;
using KozmetikOtomasyon.Models;

namespace KozmetikOtomasyon.Forms
{
    public partial class ProductAddEditForm : Form
    {
        private Product _product;
        private string  _selectedImagePath;

        public ProductAddEditForm(Product product)
        {
            InitializeComponent();
            _product = product;

            if (_product != null)
            {
                this.Text         = "Ürün Düzenle";
                txtName.Text      = _product.Name;
                txtPrice.Text     = _product.Price.ToString();
                txtStock.Text     = _product.Stock.ToString();
                _selectedImagePath = _product.ImagePath;
                txtImagePath.Text  = _product.ImagePath ?? "";
                LoadPreview(_product.ImagePath);
            }
            else
            {
                this.Text = "Ürün Ekle";
            }
        }

        private void LoadPreview(string relativePath)
        {
            if (string.IsNullOrEmpty(relativePath)) { picPreview.Image = null; return; }
            string full = Path.Combine(Application.StartupPath, relativePath);
            if (File.Exists(full))
                picPreview.Image = System.Drawing.Image.FromFile(full);
        }

        private void btnBrowse_Click(object sender, EventArgs e)
        {
            using (var dlg = new OpenFileDialog())
            {
                dlg.Title  = "Resim Seç";
                dlg.Filter = "Resim Dosyaları|*.png;*.jpg;*.jpeg;*.bmp;*.gif";
                if (dlg.ShowDialog() != DialogResult.OK) return;

                string imgDir  = Path.Combine(Application.StartupPath, "Images");
                if (!Directory.Exists(imgDir)) Directory.CreateDirectory(imgDir);

                string destName = Path.GetFileName(dlg.FileName);
                string destPath = Path.Combine(imgDir, destName);

                if (!File.Exists(destPath))
                    File.Copy(dlg.FileName, destPath);

                _selectedImagePath = @"Images\" + destName;
                txtImagePath.Text  = _selectedImagePath;
                LoadPreview(_selectedImagePath);
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            // Boş alan kontrolü
            if (string.IsNullOrEmpty(txtName.Text))
            {
                MessageBox.Show("Ürün adı boş olamaz!", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Fiyat sayı mı?
            if (!decimal.TryParse(txtPrice.Text, out decimal price) || price <= 0)
            {
                MessageBox.Show("Geçerli bir fiyat girin!", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Stok sayı mı?
            if (!int.TryParse(txtStock.Text, out int stock) || stock < 0)
            {
                MessageBox.Show("Geçerli bir stok miktarı girin!", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (_product == null)
            {
                var newProduct = new Product
                {
                    Name      = txtName.Text.Trim(),
                    Price     = price,
                    Stock     = stock,
                    ImagePath = _selectedImagePath
                };
                DatabaseHelper.AddProduct(newProduct);
                MessageBox.Show("Ürün eklendi!", "Başarılı", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                _product.Name      = txtName.Text.Trim();
                _product.Price     = price;
                _product.Stock     = stock;
                _product.ImagePath = _selectedImagePath;
                DatabaseHelper.UpdateProduct(_product);
                MessageBox.Show("Ürün güncellendi!", "Başarılı", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }

            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }
    }
}
