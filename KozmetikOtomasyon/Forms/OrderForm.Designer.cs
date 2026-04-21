namespace KozmetikOtomasyon.Forms
{
    partial class OrderForm
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null)) components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.lblProduct = new System.Windows.Forms.Label();
            this.cmbProducts = new System.Windows.Forms.ComboBox();
            this.lblProductInfo = new System.Windows.Forms.Label();
            this.lblQuantity = new System.Windows.Forms.Label();
            this.txtQuantity = new System.Windows.Forms.TextBox();
            this.btnPlaceOrder = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.SuspendLayout();

            // lblProduct
            this.lblProduct.Location = new System.Drawing.Point(30, 30);
            this.lblProduct.Size = new System.Drawing.Size(80, 23);
            this.lblProduct.Text = "Ürün:";

            // cmbProducts
            this.cmbProducts.Location = new System.Drawing.Point(120, 27);
            this.cmbProducts.Size = new System.Drawing.Size(210, 23);
            this.cmbProducts.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbProducts.SelectedIndexChanged += new System.EventHandler(this.cmbProducts_SelectedIndexChanged);

            // lblProductInfo
            this.lblProductInfo.Location = new System.Drawing.Point(120, 58);
            this.lblProductInfo.Size = new System.Drawing.Size(250, 23);
            this.lblProductInfo.ForeColor = System.Drawing.Color.Gray;
            this.lblProductInfo.Text = "";

            // lblQuantity
            this.lblQuantity.Location = new System.Drawing.Point(30, 90);
            this.lblQuantity.Size = new System.Drawing.Size(80, 23);
            this.lblQuantity.Text = "Adet:";

            // txtQuantity
            this.txtQuantity.Location = new System.Drawing.Point(120, 87);
            this.txtQuantity.Size = new System.Drawing.Size(80, 23);
            this.txtQuantity.Text = "1";

            // btnPlaceOrder
            this.btnPlaceOrder.Location = new System.Drawing.Point(40, 135);
            this.btnPlaceOrder.Size = new System.Drawing.Size(130, 35);
            this.btnPlaceOrder.Text = "Sipariş Ver";
            this.btnPlaceOrder.BackColor = System.Drawing.Color.MediumOrchid;
            this.btnPlaceOrder.ForeColor = System.Drawing.Color.White;
            this.btnPlaceOrder.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnPlaceOrder.Click += new System.EventHandler(this.btnPlaceOrder_Click);

            // btnCancel
            this.btnCancel.Location = new System.Drawing.Point(190, 135);
            this.btnCancel.Size = new System.Drawing.Size(100, 35);
            this.btnCancel.Text = "İptal";
            this.btnCancel.BackColor = System.Drawing.Color.Gray;
            this.btnCancel.ForeColor = System.Drawing.Color.White;
            this.btnCancel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);

            // OrderForm
            this.ClientSize = new System.Drawing.Size(360, 200);
            this.Controls.Add(this.lblProduct);
            this.Controls.Add(this.cmbProducts);
            this.Controls.Add(this.lblProductInfo);
            this.Controls.Add(this.lblQuantity);
            this.Controls.Add(this.txtQuantity);
            this.Controls.Add(this.btnPlaceOrder);
            this.Controls.Add(this.btnCancel);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Sipariş Ver";
            this.Load += new System.EventHandler(this.OrderForm_Load);

            this.ResumeLayout(false);
        }

        private System.Windows.Forms.Label lblProduct;
        private System.Windows.Forms.ComboBox cmbProducts;
        private System.Windows.Forms.Label lblProductInfo;
        private System.Windows.Forms.Label lblQuantity;
        private System.Windows.Forms.TextBox txtQuantity;
        private System.Windows.Forms.Button btnPlaceOrder;
        private System.Windows.Forms.Button btnCancel;
    }
}
