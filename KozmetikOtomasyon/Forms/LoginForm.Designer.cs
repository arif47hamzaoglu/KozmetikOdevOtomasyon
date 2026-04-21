namespace KozmetikOtomasyon.Forms
{
    partial class LoginForm
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null)) components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.lblTitle    = new System.Windows.Forms.Label();
            this.lblEmail    = new System.Windows.Forms.Label();
            this.txtEmail    = new System.Windows.Forms.TextBox();
            this.lblPassword = new System.Windows.Forms.Label();
            this.txtPassword = new System.Windows.Forms.TextBox();
            this.btnLogin    = new System.Windows.Forms.Button();
            this.SuspendLayout();

            // lblTitle
            this.lblTitle.Font      = new System.Drawing.Font("Segoe UI", 16F, System.Drawing.FontStyle.Bold);
            this.lblTitle.Location  = new System.Drawing.Point(50, 30);
            this.lblTitle.Size      = new System.Drawing.Size(300, 35);
            this.lblTitle.Text      = "Kozmetik Otomasyon";
            this.lblTitle.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;

            // lblEmail
            this.lblEmail.Location = new System.Drawing.Point(60, 95);
            this.lblEmail.Size     = new System.Drawing.Size(80, 23);
            this.lblEmail.Text     = "Email:";

            // txtEmail
            this.txtEmail.Location = new System.Drawing.Point(150, 92);
            this.txtEmail.Size     = new System.Drawing.Size(180, 23);

            // lblPassword
            this.lblPassword.Location = new System.Drawing.Point(60, 135);
            this.lblPassword.Size     = new System.Drawing.Size(80, 23);
            this.lblPassword.Text     = "Şifre:";

            // txtPassword
            this.txtPassword.Location     = new System.Drawing.Point(150, 132);
            this.txtPassword.Size         = new System.Drawing.Size(180, 23);
            this.txtPassword.PasswordChar = '*';

            // btnLogin
            this.btnLogin.Location  = new System.Drawing.Point(130, 180);
            this.btnLogin.Size      = new System.Drawing.Size(130, 35);
            this.btnLogin.Text      = "Giriş Yap";
            this.btnLogin.BackColor = System.Drawing.Color.MediumOrchid;
            this.btnLogin.ForeColor = System.Drawing.Color.White;
            this.btnLogin.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnLogin.Click    += new System.EventHandler(this.btnLogin_Click);

            // LoginForm
            this.ClientSize        = new System.Drawing.Size(400, 250);
            this.FormBorderStyle   = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox       = false;
            this.StartPosition     = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text              = "Giriş Yap";
            this.Controls.Add(this.lblTitle);
            this.Controls.Add(this.lblEmail);
            this.Controls.Add(this.txtEmail);
            this.Controls.Add(this.lblPassword);
            this.Controls.Add(this.txtPassword);
            this.Controls.Add(this.btnLogin);

            this.ResumeLayout(false);
        }

        private System.Windows.Forms.Label   lblTitle;
        private System.Windows.Forms.Label   lblEmail;
        private System.Windows.Forms.TextBox txtEmail;
        private System.Windows.Forms.Label   lblPassword;
        private System.Windows.Forms.TextBox txtPassword;
        private System.Windows.Forms.Button  btnLogin;
    }
}
