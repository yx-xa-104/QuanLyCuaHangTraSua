using System;
using System.Windows.Forms;
using QuanLyCuaHangTraSua.DAO;
using QuanLyCuaHangTraSua.BLL;

namespace QuanLyCuaHangTraSua.UserControls
{
    public partial class ucSetting: UserControl
    {
        public event EventHandler DisplayNameChanged;

        public ucSetting()
        {
            InitializeComponent();
            LoadAccountInfo();
        }

        #region Method
        private SettingBLL accountBLL = new SettingBLL();

        private void LoadAccountInfo()
        {
            var acc = SessionManager.CurrentAccount;
            if (acc != null)
            {
                txtUserName.Text = acc.UserName;
                txtDisplayName.Text = acc.DisplayName;
                txtAccountType.Text = acc.Type == 1 ? "Admin" : "Nhân viên";
                txtUserName.ReadOnly = true;
                txtAccountType.ReadOnly = true;
            }
            else
            {
                MessageBox.Show("Không có tài khoản đăng nhập!");
                return;
            }
        }
        #endregion

        #region Event
        private void btnEditDisplayName_Click(object sender, EventArgs e)
        {
            string newDisplayName = txtDisplayName.Text.Trim();
            if (string.IsNullOrEmpty(newDisplayName))
            {
                MessageBox.Show("Tên hiển thị không được để trống!");
                return;
            }
            if (accountBLL.UpdateDisplayName(txtUserName.Text, newDisplayName, SessionManager.CurrentAccount.Type))
            {
                MessageBox.Show("Cập nhật thành công!");
                SessionManager.CurrentAccount.DisplayName = newDisplayName;
                DisplayNameChanged?.Invoke(this, EventArgs.Empty);
            }
            else
            {
                MessageBox.Show("Cập nhật thất bại!");
            }
        }

        private void EditPassword_Click(object sender, EventArgs e)
        {
            string oldPass = txtOldPassword.Text;
            string newPass = txtNewPassword.Text;
            string confirmPass = txtConfirmPassword.Text;

            if (string.IsNullOrEmpty(oldPass) || string.IsNullOrEmpty(newPass) || string.IsNullOrEmpty(confirmPass))
            {
                MessageBox.Show("Vui lòng nhập đầy đủ thông tin!");
                return;
            }
            if (newPass != confirmPass)
            {
                MessageBox.Show("Mật khẩu mới không khớp!");
                return;
            }
            if (accountBLL.ChangePassword(SessionManager.CurrentAccount.UserName, oldPass, newPass))
            {
                MessageBox.Show("Đổi mật khẩu thành công!");
                txtOldPassword.Clear();
                txtNewPassword.Clear();
                txtConfirmPassword.Clear();
            }
            else
            {
                MessageBox.Show("Mật khẩu cũ không đúng hoặc đổi mật khẩu thất bại!");
            }
        }

        private void btnSignOut_Click(object sender, EventArgs e)
        {
            SessionManager.CurrentAccount = null;
            // Đóng form chính và quay về form đăng nhập
            Form mainForm = this.FindForm();
            if (mainForm != null)
            {
                mainForm.Hide();
                fLogin loginForm = new fLogin();
                loginForm.ShowDialog();
                mainForm.Close();
            }
        }

        private void btnToggleOldPassword_Click(object sender, EventArgs e)
        {
            txtOldPassword.UseSystemPasswordChar = !txtOldPassword.UseSystemPasswordChar;
        }

        private void btnToggleNewPassword_Click(object sender, EventArgs e)
        {
            txtNewPassword.UseSystemPasswordChar = !txtNewPassword.UseSystemPasswordChar;
        }

        private void btnToggleConfirmPassword_Click(object sender, EventArgs e)
        {
            txtConfirmPassword.UseSystemPasswordChar = !txtConfirmPassword.UseSystemPasswordChar;
        }
        #endregion
    }
}
