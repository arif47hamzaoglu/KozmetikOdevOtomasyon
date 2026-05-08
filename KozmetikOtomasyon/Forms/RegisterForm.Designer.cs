namespace KozmetikOtomasyon.Forms
{
    partial class RegisterForm
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null)) components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.lblTitle           = new System.Windows.Forms.Label();
            this.lblName            = new System.Windows.Forms.Label();
            this.txtName            = new System.Windows.Forms.TextBox();
            this.lblEmail           = new System.Windows.Forms.Label();
            this.txtEmail           = new System.Windows.Forms.TextBox();
            this.lblPassword        = new System.Windows.Forms.Label();
            this.txtPassword        = new System.Windows.Forms.TextBox();
            this.lblPasswordConfirm = new System.Windows.Forms.Label();
            this.txtPasswordConfirm = new System.Windows.Forms.TextBox();
            this.btnRegister        = new System.Windows.Forms.Button();
            this.btnCancel          = new System.Windows.Forms.Button();
            this.SuspendLayout();

            // lblTitle
            this.lblTitle.Font      = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Bold);
            this.lblTitle.Location  = new System.Drawing.Point(50, 20);
            this.lblTitle.Size      = new System.Drawing.Size(300, 30);
            this.lblTitle.Text      = "Yeni Hesap Oluştur";
            this.lblTitle.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;

            // lblName
            this.lblName.Location = new System.Drawing.Point(40, 75);
            this.lblName.Size     = new System.Drawing.Size(100, 23);
            this.lblName.Text     = "Ad Soyad:";

            // txtName
            this.txtName.Location = new System.Drawing.Point(150, 72);
            this.txtName.Size     = new System.Drawing.Size(200, 23);

            // lblEmail
            this.lblEmail.Location = new System.Drawing.Point(40, 115);
            this.lblEmail.Size     = new System.Drawing.Size(100, 23);
            this.lblEmail.Text     = "Email:";

            // txtEmail
            this.txtEmail.Location = new System.Drawing.Point(150, 112);
            this.txtEmail.Size     = new System.Drawing.Size(200, 23);

            // lblPassword
            this.lblPassword.Location = new System.Drawing.Point(40, 155);
            this.lblPassword.Size     = new System.Drawing.Size(100, 23);
            this.lblPassword.Text     = "Şifre:";

            // txtPassword
            this.txtPassword.Location     = new System.Drawing.Point(150, 152);
            this.txtPassword.Size         = new System.Drawing.Size(200, 23);
            this.txtPassword.PasswordChar = '*';

            // lblPasswordConfirm
            this.lblPasswordConfirm.Location = new System.Drawing.Point(40, 195);
            this.lblPasswordConfirm.Size     = new System.Drawing.Size(100, 23);
            this.lblPasswordConfirm.Text     = "Şifre Tekrar:";

            // txtPasswordConfirm
            this.txtPasswordConfirm.Location     = new System.Drawing.Point(150, 192);
            this.txtPasswordConfirm.Size         = new System.Drawing.Size(200, 23);
            this.txtPasswordConfirm.PasswordChar = '*';

            // btnRegister
            this.btnRegister.Location  = new System.Drawing.Point(60, 238);
            this.btnRegister.Size      = new System.Drawing.Size(120, 35);
            this.btnRegister.Text      = "Kayıt Ol";
            this.btnRegister.BackColor = System.Drawing.Color.MediumSeaGreen;
            this.btnRegister.ForeColor = System.Drawing.Color.White;
            this.btnRegister.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnRegister.Click    += new System.EventHandler(this.btnRegister_Click);

            // btnCancel
            this.btnCancel.Location  = new System.Drawing.Point(215, 238);
            this.btnCancel.Size      = new System.Drawing.Size(110, 35);
            this.btnCancel.Text      = "İptal";
            this.btnCancel.BackColor = System.Drawing.Color.Gray;
            this.btnCancel.ForeColor = System.Drawing.Color.White;
            this.btnCancel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCancel.Click    += new System.EventHandler(this.btnCancel_Click);

            // RegisterForm
            this.ClientSize      = new System.Drawing.Size(400, 298);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox     = false;
            this.StartPosition   = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text            = "Kayıt Ol";
            this.Controls.Add(this.lblTitle);
            this.Controls.Add(this.lblName);
            this.Controls.Add(this.txtName);
            this.Controls.Add(this.lblEmail);
            this.Controls.Add(this.txtEmail);
            this.Controls.Add(this.lblPassword);
            this.Controls.Add(this.txtPassword);
            this.Controls.Add(this.lblPasswordConfirm);
            this.Controls.Add(this.txtPasswordConfirm);
            this.Controls.Add(this.btnRegister);
            this.Controls.Add(this.btnCancel);
            this.ResumeLayout(false);
        }

        private System.Windows.Forms.Label   lblTitle;
        private System.Windows.Forms.Label   lblName;
        private System.Windows.Forms.TextBox txtName;
        private System.Windows.Forms.Label   lblEmail;
        private System.Windows.Forms.TextBox txtEmail;
        private System.Windows.Forms.Label   lblPassword;
        private System.Windows.Forms.TextBox txtPassword;
        private System.Windows.Forms.Label   lblPasswordConfirm;
        private System.Windows.Forms.TextBox txtPasswordConfirm;
        private System.Windows.Forms.Button  btnRegister;
        private System.Windows.Forms.Button  btnCancel;
    }
}
