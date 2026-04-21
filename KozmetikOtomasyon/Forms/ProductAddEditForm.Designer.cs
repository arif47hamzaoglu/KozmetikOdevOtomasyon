namespace KozmetikOtomasyon.Forms
{
    partial class ProductAddEditForm
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null)) components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.lblName = new System.Windows.Forms.Label();
            this.txtName = new System.Windows.Forms.TextBox();
            this.lblPrice = new System.Windows.Forms.Label();
            this.txtPrice = new System.Windows.Forms.TextBox();
            this.lblStock = new System.Windows.Forms.Label();
            this.txtStock = new System.Windows.Forms.TextBox();
            this.btnSave = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.SuspendLayout();

            // lblName
            this.lblName.Location = new System.Drawing.Point(30, 30);
            this.lblName.Size = new System.Drawing.Size(90, 23);
            this.lblName.Text = "Ürün Adı:";

            // txtName
            this.txtName.Location = new System.Drawing.Point(130, 27);
            this.txtName.Size = new System.Drawing.Size(180, 23);

            // lblPrice
            this.lblPrice.Location = new System.Drawing.Point(30, 70);
            this.lblPrice.Size = new System.Drawing.Size(90, 23);
            this.lblPrice.Text = "Fiyat (TL):";

            // txtPrice
            this.txtPrice.Location = new System.Drawing.Point(130, 67);
            this.txtPrice.Size = new System.Drawing.Size(180, 23);

            // lblStock
            this.lblStock.Location = new System.Drawing.Point(30, 110);
            this.lblStock.Size = new System.Drawing.Size(90, 23);
            this.lblStock.Text = "Stok:";

            // txtStock
            this.txtStock.Location = new System.Drawing.Point(130, 107);
            this.txtStock.Size = new System.Drawing.Size(180, 23);

            // btnSave
            this.btnSave.Location = new System.Drawing.Point(50, 155);
            this.btnSave.Size = new System.Drawing.Size(100, 35);
            this.btnSave.Text = "Kaydet";
            this.btnSave.BackColor = System.Drawing.Color.MediumSeaGreen;
            this.btnSave.ForeColor = System.Drawing.Color.White;
            this.btnSave.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);

            // btnCancel
            this.btnCancel.Location = new System.Drawing.Point(180, 155);
            this.btnCancel.Size = new System.Drawing.Size(100, 35);
            this.btnCancel.Text = "İptal";
            this.btnCancel.BackColor = System.Drawing.Color.Gray;
            this.btnCancel.ForeColor = System.Drawing.Color.White;
            this.btnCancel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);

            // ProductAddEditForm
            this.ClientSize = new System.Drawing.Size(350, 220);
            this.Controls.Add(this.lblName);
            this.Controls.Add(this.txtName);
            this.Controls.Add(this.lblPrice);
            this.Controls.Add(this.txtPrice);
            this.Controls.Add(this.lblStock);
            this.Controls.Add(this.txtStock);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.btnCancel);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;

            this.ResumeLayout(false);
        }

        private System.Windows.Forms.Label lblName;
        private System.Windows.Forms.TextBox txtName;
        private System.Windows.Forms.Label lblPrice;
        private System.Windows.Forms.TextBox txtPrice;
        private System.Windows.Forms.Label lblStock;
        private System.Windows.Forms.TextBox txtStock;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Button btnCancel;
    }
}
