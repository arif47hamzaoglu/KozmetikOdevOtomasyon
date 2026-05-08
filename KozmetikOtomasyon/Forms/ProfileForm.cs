using System;
using System.Windows.Forms;
using KozmetikOtomasyon.Models;

namespace KozmetikOtomasyon.Forms
{
    public partial class ProfileForm : Form
    {
        public ProfileForm()
        {
            InitializeComponent();
        }

        private void ProfileForm_Load(object sender, EventArgs e)
        {
            txtName.Text  = Session.CurrentUser.Name;
            txtEmail.Text = Session.CurrentUser.Email;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            string name        = txtName.Text.Trim();
            string email       = txtEmail.Text.Trim();
            string currentPass = txtCurrentPassword.Text;
            string newPass     = txtNewPassword.Text;
            string newPass2    = txtNewPasswordConfirm.Text;

            if (string.IsNullOrEmpty(name) || string.IsNullOrEmpty(email))
            {
                MessageBox.Show("Ad Soyad ve Email boş olamaz!", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (currentPass != Session.CurrentUser.Password)
            {
                MessageBox.Show("Mevcut şifre hatalı!", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            string finalPassword = Session.CurrentUser.Password;

            if (!string.IsNullOrEmpty(newPass))
            {
                if (newPass.Length < 4)
                {
                    MessageBox.Show("Yeni şifre en az 4 karakter olmalı!", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                if (newPass != newPass2)
                {
                    MessageBox.Show("Yeni şifreler eşleşmiyor!", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                finalPassword = newPass;
            }

            var updated = new User
            {
                Id       = Session.CurrentUser.Id,
                Name     = name,
                Email    = email,
                Password = finalPassword,
                IsAdmin  = Session.CurrentUser.IsAdmin
            };

            if (DatabaseHelper.UpdateUser(updated))
            {
                Session.CurrentUser = updated;
                MessageBox.Show("Profil güncellendi!", "Başarılı", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }
    }
}
