using System;
using System.Collections.Generic;
using System.Windows.Forms;
using KozmetikOtomasyon.Models;

namespace KozmetikOtomasyon.Forms
{
    // Sipariş verme formu
    public partial class OrderForm : Form
    {
        private List<Product> _products;

        public OrderForm()
        {
            InitializeComponent();
        }

        private void OrderForm_Load(object sender, EventArgs e)
        {
            // Ürünleri listele
            _products = DatabaseHelper.GetProducts();

            cmbProducts.DisplayMember = "Name";
            cmbProducts.ValueMember = "Id";
            cmbProducts.DataSource = _products;
        }

        // Ürün seçildiğinde fiyat bilgisini göster
        private void cmbProducts_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbProducts.SelectedItem is Product p)
            {
                lblProductInfo.Text = $"Fiyat: {p.Price:C2}  |  Stok: {p.Stock}";
            }
        }

        private void btnPlaceOrder_Click(object sender, EventArgs e)
        {
            if (cmbProducts.SelectedItem == null)
            {
                MessageBox.Show("Lütfen bir ürün seçin!", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (!int.TryParse(txtQuantity.Text, out int quantity) || quantity <= 0)
            {
                MessageBox.Show("Geçerli bir adet girin!", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var product = (Product)cmbProducts.SelectedItem;
            bool success = DatabaseHelper.AddOrder(Session.CurrentUser.Id, product.Id, quantity);

            if (success)
            {
                decimal total = product.Price * quantity;
                MessageBox.Show($"Siparişiniz alındı!\n\nÜrün: {product.Name}\nAdet: {quantity}\nToplam: {total:C2}",
                    "Sipariş Başarılı", MessageBoxButtons.OK, MessageBoxIcon.Information);

                this.DialogResult = DialogResult.OK;
                this.Close();
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }
    }
}
