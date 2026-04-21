namespace KozmetikOtomasyon.Forms
{
    partial class MainForm
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null)) components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.lblWelcome       = new System.Windows.Forms.Label();
            this.btnLogout        = new System.Windows.Forms.Button();
            this.tabControl       = new System.Windows.Forms.TabControl();
            this.tabProducts      = new System.Windows.Forms.TabPage();
            this.dgvProducts      = new System.Windows.Forms.DataGridView();
            this.btnAddProduct    = new System.Windows.Forms.Button();
            this.btnEditProduct   = new System.Windows.Forms.Button();
            this.btnDeleteProduct = new System.Windows.Forms.Button();
            this.btnOrder         = new System.Windows.Forms.Button();
            this.tabOrders        = new System.Windows.Forms.TabPage();
            this.dgvOrders        = new System.Windows.Forms.DataGridView();
            this.btnUpdateStatus  = new System.Windows.Forms.Button();

            this.tabControl.SuspendLayout();
            this.tabProducts.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvProducts)).BeginInit();
            this.tabOrders.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvOrders)).BeginInit();
            this.SuspendLayout();

            // lblWelcome
            this.lblWelcome.Location = new System.Drawing.Point(12, 12);
            this.lblWelcome.Size     = new System.Drawing.Size(500, 23);
            this.lblWelcome.Font     = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);

            // btnLogout
            this.btnLogout.Location  = new System.Drawing.Point(680, 8);
            this.btnLogout.Size      = new System.Drawing.Size(90, 30);
            this.btnLogout.Text      = "Çıkış";
            this.btnLogout.BackColor = System.Drawing.Color.Tomato;
            this.btnLogout.ForeColor = System.Drawing.Color.White;
            this.btnLogout.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnLogout.Click    += new System.EventHandler(this.btnLogout_Click);

            // tabControl
            this.tabControl.Location = new System.Drawing.Point(12, 50);
            this.tabControl.Size     = new System.Drawing.Size(760, 490);
            this.tabControl.Controls.Add(this.tabProducts);
            this.tabControl.Controls.Add(this.tabOrders);

            // ── ÜRÜNLER TABı ─────────────────────────────
            this.tabProducts.Text = "Ürünler";
            this.tabProducts.Controls.Add(this.dgvProducts);
            this.tabProducts.Controls.Add(this.btnAddProduct);
            this.tabProducts.Controls.Add(this.btnEditProduct);
            this.tabProducts.Controls.Add(this.btnDeleteProduct);
            this.tabProducts.Controls.Add(this.btnOrder);

            this.dgvProducts.Location            = new System.Drawing.Point(10, 10);
            this.dgvProducts.Size                = new System.Drawing.Size(725, 370);
            this.dgvProducts.AllowUserToAddRows  = false;
            this.dgvProducts.ReadOnly            = true;
            this.dgvProducts.SelectionMode       = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvProducts.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;

            this.btnAddProduct.Location  = new System.Drawing.Point(10, 395);
            this.btnAddProduct.Size      = new System.Drawing.Size(110, 35);
            this.btnAddProduct.Text      = "Ürün Ekle";
            this.btnAddProduct.BackColor = System.Drawing.Color.MediumSeaGreen;
            this.btnAddProduct.ForeColor = System.Drawing.Color.White;
            this.btnAddProduct.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAddProduct.Click    += new System.EventHandler(this.btnAddProduct_Click);

            this.btnEditProduct.Location  = new System.Drawing.Point(130, 395);
            this.btnEditProduct.Size      = new System.Drawing.Size(110, 35);
            this.btnEditProduct.Text      = "Düzenle";
            this.btnEditProduct.BackColor = System.Drawing.Color.SteelBlue;
            this.btnEditProduct.ForeColor = System.Drawing.Color.White;
            this.btnEditProduct.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnEditProduct.Click    += new System.EventHandler(this.btnEditProduct_Click);

            this.btnDeleteProduct.Location  = new System.Drawing.Point(250, 395);
            this.btnDeleteProduct.Size      = new System.Drawing.Size(110, 35);
            this.btnDeleteProduct.Text      = "Sil";
            this.btnDeleteProduct.BackColor = System.Drawing.Color.Tomato;
            this.btnDeleteProduct.ForeColor = System.Drawing.Color.White;
            this.btnDeleteProduct.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDeleteProduct.Click    += new System.EventHandler(this.btnDeleteProduct_Click);

            this.btnOrder.Location  = new System.Drawing.Point(600, 395);
            this.btnOrder.Size      = new System.Drawing.Size(130, 35);
            this.btnOrder.Text      = "Sipariş Ver";
            this.btnOrder.BackColor = System.Drawing.Color.MediumOrchid;
            this.btnOrder.ForeColor = System.Drawing.Color.White;
            this.btnOrder.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnOrder.Click    += new System.EventHandler(this.btnOrder_Click);

            // ── SİPARİŞLER TABı ──────────────────────────
            this.tabOrders.Text = "Siparişler";
            this.tabOrders.Controls.Add(this.dgvOrders);
            this.tabOrders.Controls.Add(this.btnUpdateStatus);

            this.dgvOrders.Location            = new System.Drawing.Point(10, 10);
            this.dgvOrders.Size                = new System.Drawing.Size(725, 370);
            this.dgvOrders.AllowUserToAddRows  = false;
            this.dgvOrders.ReadOnly            = true;
            this.dgvOrders.SelectionMode       = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvOrders.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;

            this.btnUpdateStatus.Location  = new System.Drawing.Point(10, 395);
            this.btnUpdateStatus.Size      = new System.Drawing.Size(150, 35);
            this.btnUpdateStatus.Text      = "Durum Güncelle";
            this.btnUpdateStatus.BackColor = System.Drawing.Color.SteelBlue;
            this.btnUpdateStatus.ForeColor = System.Drawing.Color.White;
            this.btnUpdateStatus.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnUpdateStatus.Click    += new System.EventHandler(this.btnUpdateStatus_Click);

            // ── MAIN FORM ─────────────────────────────────
            this.ClientSize    = new System.Drawing.Size(784, 561);
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text          = "Kozmetik Otomasyon Sistemi";
            this.Controls.Add(this.lblWelcome);
            this.Controls.Add(this.btnLogout);
            this.Controls.Add(this.tabControl);
            this.Load += new System.EventHandler(this.MainForm_Load);

            this.tabControl.ResumeLayout(false);
            this.tabProducts.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvProducts)).EndInit();
            this.tabOrders.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvOrders)).EndInit();
            this.ResumeLayout(false);
        }

        private System.Windows.Forms.Label        lblWelcome;
        private System.Windows.Forms.Button       btnLogout;
        private System.Windows.Forms.TabControl   tabControl;
        private System.Windows.Forms.TabPage      tabProducts;
        private System.Windows.Forms.DataGridView dgvProducts;
        private System.Windows.Forms.Button       btnAddProduct;
        private System.Windows.Forms.Button       btnEditProduct;
        private System.Windows.Forms.Button       btnDeleteProduct;
        private System.Windows.Forms.Button       btnOrder;
        private System.Windows.Forms.TabPage      tabOrders;
        private System.Windows.Forms.DataGridView dgvOrders;
        private System.Windows.Forms.Button       btnUpdateStatus;
    }
}
