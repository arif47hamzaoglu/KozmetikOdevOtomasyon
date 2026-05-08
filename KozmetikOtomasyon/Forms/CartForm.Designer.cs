namespace KozmetikOtomasyon.Forms
{
    partial class CartForm
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null)) components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.lblProducts  = new System.Windows.Forms.Label();
            this.dgvProducts  = new System.Windows.Forms.DataGridView();
            this.lblQtyLabel  = new System.Windows.Forms.Label();
            this.txtQuantity  = new System.Windows.Forms.TextBox();
            this.btnAddToCart = new System.Windows.Forms.Button();
            this.lblCart      = new System.Windows.Forms.Label();
            this.dgvCart      = new System.Windows.Forms.DataGridView();
            this.btnRemove    = new System.Windows.Forms.Button();
            this.btnClear     = new System.Windows.Forms.Button();
            this.lblTotal     = new System.Windows.Forms.Label();
            this.btnCheckout  = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgvProducts)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvCart)).BeginInit();
            this.SuspendLayout();

            // lblProducts
            this.lblProducts.Location = new System.Drawing.Point(10, 12);
            this.lblProducts.Size     = new System.Drawing.Size(100, 23);
            this.lblProducts.Text     = "Ürünler";
            this.lblProducts.Font     = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);

            // dgvProducts
            this.dgvProducts.Location            = new System.Drawing.Point(10, 38);
            this.dgvProducts.Size                = new System.Drawing.Size(370, 340);
            this.dgvProducts.AllowUserToAddRows  = false;
            this.dgvProducts.ReadOnly            = true;
            this.dgvProducts.SelectionMode       = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvProducts.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvProducts.MultiSelect         = false;

            // lblQtyLabel
            this.lblQtyLabel.Location = new System.Drawing.Point(10, 393);
            this.lblQtyLabel.Size     = new System.Drawing.Size(50, 23);
            this.lblQtyLabel.Text     = "Adet:";

            // txtQuantity
            this.txtQuantity.Location = new System.Drawing.Point(65, 390);
            this.txtQuantity.Size     = new System.Drawing.Size(60, 23);
            this.txtQuantity.Text     = "1";

            // btnAddToCart
            this.btnAddToCart.Location  = new System.Drawing.Point(140, 388);
            this.btnAddToCart.Size      = new System.Drawing.Size(140, 30);
            this.btnAddToCart.Text      = "Sepete Ekle";
            this.btnAddToCart.BackColor = System.Drawing.Color.MediumSeaGreen;
            this.btnAddToCart.ForeColor = System.Drawing.Color.White;
            this.btnAddToCart.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAddToCart.Click    += new System.EventHandler(this.btnAddToCart_Click);

            // lblCart
            this.lblCart.Location = new System.Drawing.Point(400, 12);
            this.lblCart.Size     = new System.Drawing.Size(100, 23);
            this.lblCart.Text     = "Sepetim";
            this.lblCart.Font     = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);

            // dgvCart
            this.dgvCart.Location            = new System.Drawing.Point(400, 38);
            this.dgvCart.Size                = new System.Drawing.Size(455, 275);
            this.dgvCart.AllowUserToAddRows  = false;
            this.dgvCart.ReadOnly            = true;
            this.dgvCart.SelectionMode       = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvCart.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvCart.MultiSelect         = false;

            // btnRemove
            this.btnRemove.Location  = new System.Drawing.Point(400, 325);
            this.btnRemove.Size      = new System.Drawing.Size(110, 30);
            this.btnRemove.Text      = "Çıkar";
            this.btnRemove.BackColor = System.Drawing.Color.Tomato;
            this.btnRemove.ForeColor = System.Drawing.Color.White;
            this.btnRemove.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnRemove.Click    += new System.EventHandler(this.btnRemove_Click);

            // btnClear
            this.btnClear.Location  = new System.Drawing.Point(520, 325);
            this.btnClear.Size      = new System.Drawing.Size(130, 30);
            this.btnClear.Text      = "Sepeti Boşalt";
            this.btnClear.BackColor = System.Drawing.Color.DarkOrange;
            this.btnClear.ForeColor = System.Drawing.Color.White;
            this.btnClear.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnClear.Click    += new System.EventHandler(this.btnClear_Click);

            // lblTotal
            this.lblTotal.Location  = new System.Drawing.Point(400, 370);
            this.lblTotal.Size      = new System.Drawing.Size(260, 28);
            this.lblTotal.Text      = "Toplam: 0,00 TL";
            this.lblTotal.Font      = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold);
            this.lblTotal.ForeColor = System.Drawing.Color.DarkGreen;

            // btnCheckout
            this.btnCheckout.Location  = new System.Drawing.Point(670, 364);
            this.btnCheckout.Size      = new System.Drawing.Size(160, 35);
            this.btnCheckout.Text      = "Sipariş Ver";
            this.btnCheckout.BackColor = System.Drawing.Color.MediumOrchid;
            this.btnCheckout.ForeColor = System.Drawing.Color.White;
            this.btnCheckout.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCheckout.Click    += new System.EventHandler(this.btnCheckout_Click);

            // CartForm
            this.ClientSize      = new System.Drawing.Size(870, 420);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox     = false;
            this.StartPosition   = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text            = "Sepetim";
            this.Load           += new System.EventHandler(this.CartForm_Load);
            this.Controls.Add(this.lblProducts);
            this.Controls.Add(this.dgvProducts);
            this.Controls.Add(this.lblQtyLabel);
            this.Controls.Add(this.txtQuantity);
            this.Controls.Add(this.btnAddToCart);
            this.Controls.Add(this.lblCart);
            this.Controls.Add(this.dgvCart);
            this.Controls.Add(this.btnRemove);
            this.Controls.Add(this.btnClear);
            this.Controls.Add(this.lblTotal);
            this.Controls.Add(this.btnCheckout);
            ((System.ComponentModel.ISupportInitialize)(this.dgvProducts)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvCart)).EndInit();
            this.ResumeLayout(false);
        }

        private System.Windows.Forms.Label        lblProducts;
        private System.Windows.Forms.DataGridView dgvProducts;
        private System.Windows.Forms.Label        lblQtyLabel;
        private System.Windows.Forms.TextBox      txtQuantity;
        private System.Windows.Forms.Button       btnAddToCart;
        private System.Windows.Forms.Label        lblCart;
        private System.Windows.Forms.DataGridView dgvCart;
        private System.Windows.Forms.Button       btnRemove;
        private System.Windows.Forms.Button       btnClear;
        private System.Windows.Forms.Label        lblTotal;
        private System.Windows.Forms.Button       btnCheckout;
    }
}
