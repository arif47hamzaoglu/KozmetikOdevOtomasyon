using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using KozmetikOtomasyon.Models;

namespace KozmetikOtomasyon.Forms
{
    public partial class CartForm : Form
    {
        private List<Product> _products;

        public CartForm()
        {
            InitializeComponent();
        }

        private void CartForm_Load(object sender, EventArgs e)
        {
            LoadProducts();
            RefreshCart();
        }

        private void LoadProducts()
        {
            _products = DatabaseHelper.GetProducts();
            dgvProducts.DataSource = null;
            dgvProducts.DataSource = _products;

            if (dgvProducts.Columns.Count > 0)
            {
                dgvProducts.Columns["Id"].Visible       = false;
                dgvProducts.Columns["Name"].HeaderText  = "Ürün Adı";
                dgvProducts.Columns["Price"].HeaderText = "Fiyat (TL)";
                dgvProducts.Columns["Stock"].HeaderText = "Stok";
            }
        }

        private void RefreshCart()
        {
            dgvCart.DataSource = null;
            dgvCart.DataSource = Session.Cart.ToList();

            if (dgvCart.Columns.Count > 0)
            {
                dgvCart.Columns["ProductId"].Visible      = false;
                dgvCart.Columns["ProductName"].HeaderText = "Ürün";
                dgvCart.Columns["Price"].HeaderText       = "Birim Fiyat";
                dgvCart.Columns["Quantity"].HeaderText    = "Adet";
                dgvCart.Columns["Total"].HeaderText       = "Toplam";
            }

            decimal total = Session.Cart.Sum(c => c.Total);
            lblTotal.Text = $"Toplam: {total:C2}";
        }

        private void btnAddToCart_Click(object sender, EventArgs e)
        {
            if (dgvProducts.CurrentRow == null) return;

            var product = (Product)dgvProducts.CurrentRow.DataBoundItem;

            if (!int.TryParse(txtQuantity.Text, out int qty) || qty <= 0)
            {
                MessageBox.Show("Geçerli bir adet girin!", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var existing  = Session.Cart.FirstOrDefault(c => c.ProductId == product.Id);
            int totalQty  = (existing?.Quantity ?? 0) + qty;

            if (totalQty > product.Stock)
            {
                MessageBox.Show($"Yeterli stok yok! Mevcut stok: {product.Stock}", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (existing != null)
            {
                existing.Quantity += qty;
            }
            else
            {
                Session.Cart.Add(new CartItem
                {
                    ProductId   = product.Id,
                    ProductName = product.Name,
                    Price       = product.Price,
                    Quantity    = qty
                });
            }

            RefreshCart();
        }

        private void btnRemove_Click(object sender, EventArgs e)
        {
            if (dgvCart.CurrentRow == null) return;
            var item = (CartItem)dgvCart.CurrentRow.DataBoundItem;
            Session.Cart.Remove(item);
            RefreshCart();
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            if (Session.Cart.Count == 0) return;
            var res = MessageBox.Show("Sepet tamamen boşaltılsın mı?", "Onay",
                MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (res == DialogResult.Yes)
            {
                Session.Cart.Clear();
                RefreshCart();
            }
        }

        private void btnCheckout_Click(object sender, EventArgs e)
        {
            if (Session.Cart.Count == 0)
            {
                MessageBox.Show("Sepet boş!", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            decimal total  = Session.Cart.Sum(c => c.Total);
            var    result  = MessageBox.Show(
                $"Toplam {total:C2} tutarında {Session.Cart.Count} kalem için sipariş verilsin mi?",
                "Sipariş Onayı", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (result != DialogResult.Yes) return;

            bool allSuccess = true;
            foreach (var item in Session.Cart.ToList())
            {
                if (!DatabaseHelper.AddOrder(Session.CurrentUser.Id, item.ProductId, item.Quantity))
                {
                    allSuccess = false;
                    break;
                }
            }

            if (allSuccess)
            {
                Session.Cart.Clear();
                MessageBox.Show("Siparişleriniz başarıyla alındı!", "Başarılı", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
        }
    }
}
