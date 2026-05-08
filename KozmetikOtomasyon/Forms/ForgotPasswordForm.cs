using System;
using System.Windows.Forms;

namespace KozmetikOtomasyon.Forms
{
    public partial class ForgotPasswordForm : Form
    {
        public ForgotPasswordForm()
        {
            InitializeComponent();
        }

        private void btnReset_Click(object sender, EventArgs e)
        {
            string email = txtEmail.Text.Trim();
            string pass  = txtNewPassword.Text;
            string pass2 = txtNewPasswordConfirm.Text;

            if (string.IsNullOrEmpty(email))
            {
                MessageBox.Show("Email adresi boş olamaz!", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (string.IsNullOrEmpty(pass) || string.IsNullOrEmpty(pass2))
            {
                MessageBox.Show("Yeni şifre boş olamaz!", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (pass.Length < 4)
            {
                MessageBox.Show("Şifre en az 4 karakter olmalı!", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (pass != pass2)
            {
                MessageBox.Show("Şifreler eşleşmiyor!", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (DatabaseHelper.ResetPassword(email, pass))
            {
                MessageBox.Show("Şifreniz başarıyla sıfırlandı! Yeni şifrenizle giriş yapabilirsiniz.",
                    "Başarılı", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.Close();
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
