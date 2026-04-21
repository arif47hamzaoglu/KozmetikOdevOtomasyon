using System;
using System.Windows.Forms;
using KozmetikOtomasyon.Models;

namespace KozmetikOtomasyon.Forms
{
    // Ürün eklemek veya düzenlemek için kullanılan form
    public partial class ProductAddEditForm : Form
    {
        private Product _product; // null ise yeni ürün, dolu ise düzenleme

        public ProductAddEditForm(Product product)
        {
            InitializeComponent();
            _product = product;

            // Düzenleme modunda ise mevcut değerleri doldur
            if (_product != null)
            {
                this.Text = "Ürün Düzenle";
                txtName.Text = _product.Name;
                txtPrice.Text = _product.Price.ToString();
                txtStock.Text = _product.Stock.ToString();
            }
            else
            {
                this.Text = "Ürün Ekle";
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
                // Yeni ürün ekle
                var newProduct = new Product { Name = txtName.Text.Trim(), Price = price, Stock = stock };
                DatabaseHelper.AddProduct(newProduct);
                MessageBox.Show("Ürün eklendi!", "Başarılı", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                // Mevcut ürünü güncelle
                _product.Name = txtName.Text.Trim();
                _product.Price = price;
                _product.Stock = stock;
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
