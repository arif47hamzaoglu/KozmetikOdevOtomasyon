using System;
using System.Windows.Forms;
using KozmetikOtomasyon.Models;

namespace KozmetikOtomasyon.Forms
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            lblWelcome.Text = $"Hoşgeldin, {Session.CurrentUser.Name}";
            LoadProducts();
            LoadOrders();
        }

        // ─── ÜRÜNLER ───────────────────────────────────
        private void LoadProducts()
        {
            dgvProducts.DataSource = DatabaseHelper.GetProducts();

            if (dgvProducts.Columns.Count > 0)
            {
                dgvProducts.Columns["Id"].HeaderText    = "No";
                dgvProducts.Columns["Name"].HeaderText  = "Ürün Adı";
                dgvProducts.Columns["Price"].HeaderText = "Fiyat (TL)";
                dgvProducts.Columns["Stock"].HeaderText = "Stok";
            }
        }

        private void btnAddProduct_Click(object sender, EventArgs e)
        {
            if (new ProductAddEditForm(null).ShowDialog() == DialogResult.OK)
                LoadProducts();
        }

        private void btnEditProduct_Click(object sender, EventArgs e)
        {
            if (dgvProducts.CurrentRow == null) return;
            var p = (Product)dgvProducts.CurrentRow.DataBoundItem;
            if (new ProductAddEditForm(p).ShowDialog() == DialogResult.OK)
                LoadProducts();
        }

        private void btnDeleteProduct_Click(object sender, EventArgs e)
        {
            if (dgvProducts.CurrentRow == null) return;
            var p = (Product)dgvProducts.CurrentRow.DataBoundItem;

            var result = MessageBox.Show($"'{p.Name}' silinsin mi?", "Silme Onayı",
                MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
                DatabaseHelper.DeleteProduct(p.Id);
                LoadProducts();
            }
        }

        // ─── SİPARİŞLER ────────────────────────────────
        private void LoadOrders()
        {
            dgvOrders.DataSource = DatabaseHelper.GetOrders();

            if (dgvOrders.Columns.Count > 0)
            {
                dgvOrders.Columns["Id"].HeaderText          = "No";
                dgvOrders.Columns["UserId"].Visible         = false;
                dgvOrders.Columns["UserName"].HeaderText    = "Kullanıcı";
                dgvOrders.Columns["ProductName"].HeaderText = "Ürün";
                dgvOrders.Columns["Quantity"].HeaderText    = "Adet";
                dgvOrders.Columns["TotalPrice"].HeaderText  = "Toplam (TL)";
                dgvOrders.Columns["OrderDate"].HeaderText   = "Tarih";
                dgvOrders.Columns["Status"].HeaderText      = "Durum";
            }
        }

        private void btnOrder_Click(object sender, EventArgs e)
        {
            if (new OrderForm().ShowDialog() == DialogResult.OK)
            {
                LoadProducts();
                LoadOrders();
            }
        }

        private void btnUpdateStatus_Click(object sender, EventArgs e)
        {
            if (dgvOrders.CurrentRow == null) return;
            var order = (Order)dgvOrders.CurrentRow.DataBoundItem;

            var dlg = new Form
            {
                Text            = "Durum Güncelle",
                Size            = new System.Drawing.Size(280, 140),
                StartPosition   = FormStartPosition.CenterParent,
                FormBorderStyle = FormBorderStyle.FixedDialog,
                MaximizeBox     = false
            };
            var cmb = new ComboBox { Location = new System.Drawing.Point(30, 25), Width = 200, DropDownStyle = ComboBoxStyle.DropDownList };
            cmb.Items.AddRange(new[] { "Beklemede", "Onaylandı", "İptal" });
            cmb.SelectedItem = order.Status;

            var btn = new Button { Text = "Güncelle", Location = new System.Drawing.Point(80, 65), Width = 110 };
            btn.Click += (s, ev) => { DatabaseHelper.UpdateOrderStatus(order.Id, cmb.SelectedItem.ToString()); dlg.DialogResult = DialogResult.OK; dlg.Close(); };

            dlg.Controls.Add(cmb);
            dlg.Controls.Add(btn);

            if (dlg.ShowDialog() == DialogResult.OK)
                LoadOrders();
        }

        // ─── ÇIKIŞ ─────────────────────────────────────
        private void btnLogout_Click(object sender, EventArgs e)
        {
            Session.CurrentUser = null;
            new LoginForm().Show();
            this.Close();
        }
    }
}
