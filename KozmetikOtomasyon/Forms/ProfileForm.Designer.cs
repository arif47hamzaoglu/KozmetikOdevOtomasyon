namespace KozmetikOtomasyon.Forms
{
    partial class ProfileForm
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null)) components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.lblTitle              = new System.Windows.Forms.Label();
            this.lblName               = new System.Windows.Forms.Label();
            this.txtName               = new System.Windows.Forms.TextBox();
            this.lblEmail              = new System.Windows.Forms.Label();
            this.txtEmail              = new System.Windows.Forms.TextBox();
            this.lblSeparator          = new System.Windows.Forms.Label();
            this.lblCurrentPassword    = new System.Windows.Forms.Label();
            this.txtCurrentPassword    = new System.Windows.Forms.TextBox();
            this.lblNewPassword        = new System.Windows.Forms.Label();
            this.txtNewPassword        = new System.Windows.Forms.TextBox();
            this.lblNewPasswordConfirm = new System.Windows.Forms.Label();
            this.txtNewPasswordConfirm = new System.Windows.Forms.TextBox();
            this.btnSave               = new System.Windows.Forms.Button();
            this.btnCancel             = new System.Windows.Forms.Button();
            this.SuspendLayout();

            // lblTitle
            this.lblTitle.Font      = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Bold);
            this.lblTitle.Location  = new System.Drawing.Point(50, 20);
            this.lblTitle.Size      = new System.Drawing.Size(300, 30);
            this.lblTitle.Text      = "Profil Bilgilerim";
            this.lblTitle.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;

            // lblName
            this.lblName.Location = new System.Drawing.Point(30, 75);
            this.lblName.Size     = new System.Drawing.Size(110, 23);
            this.lblName.Text     = "Ad Soyad:";

            // txtName
            this.txtName.Location = new System.Drawing.Point(155, 72);
            this.txtName.Size     = new System.Drawing.Size(210, 23);

            // lblEmail
            this.lblEmail.Location = new System.Drawing.Point(30, 112);
            this.lblEmail.Size     = new System.Drawing.Size(110, 23);
            this.lblEmail.Text     = "Email:";

            // txtEmail
            this.txtEmail.Location = new System.Drawing.Point(155, 109);
            this.txtEmail.Size     = new System.Drawing.Size(210, 23);

            // lblSeparator
            this.lblSeparator.Location  = new System.Drawing.Point(30, 150);
            this.lblSeparator.Size      = new System.Drawing.Size(340, 18);
            this.lblSeparator.Text      = "── Şifre Değiştir (boş bırakılırsa değişmez) ──";
            this.lblSeparator.ForeColor = System.Drawing.Color.Gray;
            this.lblSeparator.Font      = new System.Drawing.Font("Segoe UI", 8F);

            // lblCurrentPassword
            this.lblCurrentPassword.Location = new System.Drawing.Point(30, 180);
            this.lblCurrentPassword.Size     = new System.Drawing.Size(120, 23);
            this.lblCurrentPassword.Text     = "Mevcut Şifre:";

            // txtCurrentPassword
            this.txtCurrentPassword.Location     = new System.Drawing.Point(155, 177);
            this.txtCurrentPassword.Size         = new System.Drawing.Size(210, 23);
            this.txtCurrentPassword.PasswordChar = '*';

            // lblNewPassword
            this.lblNewPassword.Location = new System.Drawing.Point(30, 217);
            this.lblNewPassword.Size     = new System.Drawing.Size(120, 23);
            this.lblNewPassword.Text     = "Yeni Şifre:";

            // txtNewPassword
            this.txtNewPassword.Location     = new System.Drawing.Point(155, 214);
            this.txtNewPassword.Size         = new System.Drawing.Size(210, 23);
            this.txtNewPassword.PasswordChar = '*';

            // lblNewPasswordConfirm
            this.lblNewPasswordConfirm.Location = new System.Drawing.Point(30, 254);
            this.lblNewPasswordConfirm.Size     = new System.Drawing.Size(120, 23);
            this.lblNewPasswordConfirm.Text     = "Yeni Şifre Tekrar:";

            // txtNewPasswordConfirm
            this.txtNewPasswordConfirm.Location     = new System.Drawing.Point(155, 251);
            this.txtNewPasswordConfirm.Size         = new System.Drawing.Size(210, 23);
            this.txtNewPasswordConfirm.PasswordChar = '*';

            // btnSave
            this.btnSave.Location  = new System.Drawing.Point(60, 298);
            this.btnSave.Size      = new System.Drawing.Size(120, 35);
            this.btnSave.Text      = "Kaydet";
            this.btnSave.BackColor = System.Drawing.Color.MediumSeaGreen;
            this.btnSave.ForeColor = System.Drawing.Color.White;
            this.btnSave.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSave.Click    += new System.EventHandler(this.btnSave_Click);

            // btnCancel
            this.btnCancel.Location  = new System.Drawing.Point(215, 298);
            this.btnCancel.Size      = new System.Drawing.Size(110, 35);
            this.btnCancel.Text      = "İptal";
            this.btnCancel.BackColor = System.Drawing.Color.Gray;
            this.btnCancel.ForeColor = System.Drawing.Color.White;
            this.btnCancel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCancel.Click    += new System.EventHandler(this.btnCancel_Click);

            // ProfileForm
            this.ClientSize      = new System.Drawing.Size(400, 352);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox     = false;
            this.StartPosition   = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text            = "Profil Bilgilerim";
            this.Load           += new System.EventHandler(this.ProfileForm_Load);
            this.Controls.Add(this.lblTitle);
            this.Controls.Add(this.lblName);
            this.Controls.Add(this.txtName);
            this.Controls.Add(this.lblEmail);
            this.Controls.Add(this.txtEmail);
            this.Controls.Add(this.lblSeparator);
            this.Controls.Add(this.lblCurrentPassword);
            this.Controls.Add(this.txtCurrentPassword);
            this.Controls.Add(this.lblNewPassword);
            this.Controls.Add(this.txtNewPassword);
            this.Controls.Add(this.lblNewPasswordConfirm);
            this.Controls.Add(this.txtNewPasswordConfirm);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.btnCancel);
            this.ResumeLayout(false);
        }

        private System.Windows.Forms.Label   lblTitle;
        private System.Windows.Forms.Label   lblName;
        private System.Windows.Forms.TextBox txtName;
        private System.Windows.Forms.Label   lblEmail;
        private System.Windows.Forms.TextBox txtEmail;
        private System.Windows.Forms.Label   lblSeparator;
        private System.Windows.Forms.Label   lblCurrentPassword;
        private System.Windows.Forms.TextBox txtCurrentPassword;
        private System.Windows.Forms.Label   lblNewPassword;
        private System.Windows.Forms.TextBox txtNewPassword;
        private System.Windows.Forms.Label   lblNewPasswordConfirm;
        private System.Windows.Forms.TextBox txtNewPasswordConfirm;
        private System.Windows.Forms.Button  btnSave;
        private System.Windows.Forms.Button  btnCancel;
    }
}
