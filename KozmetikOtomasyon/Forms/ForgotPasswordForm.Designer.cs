namespace KozmetikOtomasyon.Forms
{
    partial class ForgotPasswordForm
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
            this.lblInfo               = new System.Windows.Forms.Label();
            this.lblEmail              = new System.Windows.Forms.Label();
            this.txtEmail              = new System.Windows.Forms.TextBox();
            this.lblNewPassword        = new System.Windows.Forms.Label();
            this.txtNewPassword        = new System.Windows.Forms.TextBox();
            this.lblNewPasswordConfirm = new System.Windows.Forms.Label();
            this.txtNewPasswordConfirm = new System.Windows.Forms.TextBox();
            this.btnReset              = new System.Windows.Forms.Button();
            this.btnCancel             = new System.Windows.Forms.Button();
            this.SuspendLayout();

            // lblTitle
            this.lblTitle.Font      = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Bold);
            this.lblTitle.Location  = new System.Drawing.Point(40, 20);
            this.lblTitle.Size      = new System.Drawing.Size(320, 30);
            this.lblTitle.Text      = "Şifremi Unuttum";
            this.lblTitle.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;

            // lblInfo
            this.lblInfo.Location  = new System.Drawing.Point(30, 62);
            this.lblInfo.Size      = new System.Drawing.Size(340, 35);
            this.lblInfo.Text      = "Kayıtlı email adresinizi ve yeni şifrenizi girin.";
            this.lblInfo.ForeColor = System.Drawing.Color.Gray;

            // lblEmail
            this.lblEmail.Location = new System.Drawing.Point(30, 108);
            this.lblEmail.Size     = new System.Drawing.Size(110, 23);
            this.lblEmail.Text     = "Email:";

            // txtEmail
            this.txtEmail.Location = new System.Drawing.Point(150, 105);
            this.txtEmail.Size     = new System.Drawing.Size(210, 23);

            // lblNewPassword
            this.lblNewPassword.Location = new System.Drawing.Point(30, 148);
            this.lblNewPassword.Size     = new System.Drawing.Size(110, 23);
            this.lblNewPassword.Text     = "Yeni Şifre:";

            // txtNewPassword
            this.txtNewPassword.Location     = new System.Drawing.Point(150, 145);
            this.txtNewPassword.Size         = new System.Drawing.Size(210, 23);
            this.txtNewPassword.PasswordChar = '*';

            // lblNewPasswordConfirm
            this.lblNewPasswordConfirm.Location = new System.Drawing.Point(30, 188);
            this.lblNewPasswordConfirm.Size     = new System.Drawing.Size(110, 23);
            this.lblNewPasswordConfirm.Text     = "Şifre Tekrar:";

            // txtNewPasswordConfirm
            this.txtNewPasswordConfirm.Location     = new System.Drawing.Point(150, 185);
            this.txtNewPasswordConfirm.Size         = new System.Drawing.Size(210, 23);
            this.txtNewPasswordConfirm.PasswordChar = '*';

            // btnReset
            this.btnReset.Location  = new System.Drawing.Point(55, 230);
            this.btnReset.Size      = new System.Drawing.Size(135, 35);
            this.btnReset.Text      = "Şifreyi Sıfırla";
            this.btnReset.BackColor = System.Drawing.Color.MediumOrchid;
            this.btnReset.ForeColor = System.Drawing.Color.White;
            this.btnReset.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnReset.Click    += new System.EventHandler(this.btnReset_Click);

            // btnCancel
            this.btnCancel.Location  = new System.Drawing.Point(215, 230);
            this.btnCancel.Size      = new System.Drawing.Size(110, 35);
            this.btnCancel.Text      = "İptal";
            this.btnCancel.BackColor = System.Drawing.Color.Gray;
            this.btnCancel.ForeColor = System.Drawing.Color.White;
            this.btnCancel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCancel.Click    += new System.EventHandler(this.btnCancel_Click);

            // ForgotPasswordForm
            this.ClientSize      = new System.Drawing.Size(400, 285);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox     = false;
            this.StartPosition   = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text            = "Şifremi Unuttum";
            this.Controls.Add(this.lblTitle);
            this.Controls.Add(this.lblInfo);
            this.Controls.Add(this.lblEmail);
            this.Controls.Add(this.txtEmail);
            this.Controls.Add(this.lblNewPassword);
            this.Controls.Add(this.txtNewPassword);
            this.Controls.Add(this.lblNewPasswordConfirm);
            this.Controls.Add(this.txtNewPasswordConfirm);
            this.Controls.Add(this.btnReset);
            this.Controls.Add(this.btnCancel);
            this.ResumeLayout(false);
        }

        private System.Windows.Forms.Label   lblTitle;
        private System.Windows.Forms.Label   lblInfo;
        private System.Windows.Forms.Label   lblEmail;
        private System.Windows.Forms.TextBox txtEmail;
        private System.Windows.Forms.Label   lblNewPassword;
        private System.Windows.Forms.TextBox txtNewPassword;
        private System.Windows.Forms.Label   lblNewPasswordConfirm;
        private System.Windows.Forms.TextBox txtNewPasswordConfirm;
        private System.Windows.Forms.Button  btnReset;
        private System.Windows.Forms.Button  btnCancel;
    }
}
