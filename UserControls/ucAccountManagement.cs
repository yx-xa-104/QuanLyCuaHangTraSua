using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Runtime.InteropServices;
using QuanLyCuaHangTraSua.DAO;

namespace QuanLyCuaHangTraSua.UserControls
{
    public partial class ucAccountManagement: UserControl
    {
        public ucAccountManagement()
        {
            InitializeComponent();
            LoadAccountList();
            dgvAccount.AllowUserToAddRows = false;
        }

        #region Method
        // Biến để xác định chế độ thêm mới
        private bool isAddNewMode = false;

        void LoadAccountList()
        {
            string query = "SELECT UserName AS [Tên tài khoản], DisplayName AS [Tên hiển thị], CASE Type WHEN 1 THEN 'Admin' ELSE 'Nhân viên' END AS [Loại tài khoản] FROM dbo.Account";
            dgvAccount.DataSource = DataProvider.Instance.ExecuteQuery(query);
        }

        void ClearBinding()
        {
            // Ngắt liên kết dữ liệu
            txtUserName.DataBindings.Clear();
            txtDisplayName.DataBindings.Clear();
            cbType.DataBindings.Clear();
        }

        void SetBinding()
        {
            ClearBinding();

            txtUserName.DataBindings.Add(new Binding("Text", dgvAccount.DataSource, "Tên tài khoản", true, DataSourceUpdateMode.Never));
            txtDisplayName.DataBindings.Add(new Binding("Text", dgvAccount.DataSource, "Tên hiển thị", true, DataSourceUpdateMode.Never));
            cbType.DataBindings.Add(new Binding("Text", dgvAccount.DataSource, "Loại tài khoản", true, DataSourceUpdateMode.Never));

            // Ở chế độ xem/sửa, không cho phép thay đổi Tên tài khoản (khóa chính)
            txtUserName.ReadOnly = true;
            isAddNewMode = false; // Tắt cờ "Thêm mới"
        }

        void ResetPassword(string userName)
        {
            if (AccountDAO.Instance.ResetPassword(userName))
            {
                MessageBox.Show("Đặt lại mật khẩu thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("Đặt lại mật khẩu thất bại!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        #endregion

        #region Event
        private void ucAccountManagement_Load(object sender, EventArgs e)
        {
            // Gán các sự kiện 
            dgvAccount.CellClick += DgvAccount_CellClick;
            txtUserName.Enter += TxtUserName_Enter; // Sự kiện quan trọng để vào chế độ "Thêm mới"

            // Thiết lập trạng thái ban đầu 
            SetBinding();
        }

        private void TxtUserName_Enter(object sender, EventArgs e)
        {
            // Chỉ chuyển sang chế độ thêm mới nếu chưa ở chế độ đó
            if (!isAddNewMode)
            {
                isAddNewMode = true; // Bật cờ "Thêm mới"

                ClearBinding(); // Ngắt liên kết dữ liệu

                // Xóa trắng các ô và đặt giá trị mặc định
                txtUserName.Text = "";
                txtDisplayName.Text = "";
                cbType.SelectedIndex = 1; // Mặc định là "Nhân viên"

                txtUserName.ReadOnly = false; // Cho phép nhập tên tài khoản
            }
        }

        private void DgvAccount_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            // Nếu đang ở chế độ thêm mới, hãy thoát ra và quay lại chế độ xem
            if (isAddNewMode)
            {
                isAddNewMode = false;
                SetBinding();
            }
        }
        
        private void btnAdd_Click(object sender, EventArgs e)
        {
            try
            {
                string userName = txtUserName.Text;
                string displayName = txtDisplayName.Text;

                // Kiểm tra các ô nhập liệu có bị bỏ trống không
                if (string.IsNullOrWhiteSpace(userName))
                {
                    MessageBox.Show("Tên tài khoản không được để trống!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                if (string.IsNullOrWhiteSpace(displayName))
                {
                    MessageBox.Show("Tên hiển thị không được để trống!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                // Kiểm tra xem tên tài khoản đã tồn tại trong CSDL chưa
                if (AccountDAO.Instance.GetAccountByUserName(userName) != null)
                {
                    MessageBox.Show("Tên tài khoản '" + userName + "' đã tồn tại. Vui lòng chọn một tên khác.", "Lỗi Trùng Lặp", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                // Nếu tất cả các kiểm tra đều ổn, tiến hành thêm tài khoản mới
                int type = (cbType.SelectedItem.ToString() == "Admin") ? 1 : 0;

                if (AccountDAO.Instance.InsertAccount(userName, displayName, type))
                {
                    MessageBox.Show("Thêm tài khoản thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    LoadAccountList();
                    SetBinding(); // Quay lại chế độ xem/sửa
                }
                else
                {
                    MessageBox.Show("Thêm tài khoản thất bại!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            if (SessionManager.CurrentAccount == null)
            {
                MessageBox.Show("Không xác định được tài khoản đăng nhập.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            try
            {
                // Kiểm tra xem có tài khoản nào được chọn không
                string userName = txtUserName.Text;
                string displayName = txtDisplayName.Text;

                // Kiểm tra đầu vào
                if (string.IsNullOrWhiteSpace(userName))
                {
                    MessageBox.Show("Vui lòng chọn một tài khoản để sửa.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                if (string.IsNullOrWhiteSpace(displayName))
                {
                    MessageBox.Show("Tên hiển thị không được để trống!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                int type = (cbType.SelectedItem.ToString() == "Admin") ? 1 : 0;

                if (AccountDAO.Instance.UpdateAccount(userName, displayName, type))
                {
                    MessageBox.Show("Cập nhật tài khoản thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    LoadAccountList();
                    SetBinding(); // Quay lại chế độ xem/sửa
                }
                else
                {
                    MessageBox.Show("Cập nhật tài khoản thất bại!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (SessionManager.CurrentAccount == null)
            {
                MessageBox.Show("Không xác định được tài khoản đăng nhập.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            try
            {
                string userName = txtUserName.Text;

                string currentUserName = SessionManager.CurrentAccount?.UserName;

                if (userName == currentUserName)
                {
                    MessageBox.Show("Bạn không thể xóa tài khoản đang đăng nhập!", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                if (MessageBox.Show("Bạn có chắc chắn muốn xóa tài khoản này?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
                {
                    if (AccountDAO.Instance.DeleteAccount(userName))
                    {
                        MessageBox.Show("Xóa tài khoản thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        LoadAccountList();
                        SetBinding(); // Quay lại chế độ xem/sửa
                    }
                    else
                    {
                        MessageBox.Show("Xóa tài khoản thất bại!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnView_Click(object sender, EventArgs e)
        {
            LoadAccountList();
            SetBinding();
        }

        private void btnResetPassword_Click(object sender, EventArgs e)
        {
            string userName = txtUserName.Text;
            if (SessionManager.CurrentAccount == null)
            {
                MessageBox.Show("Không xác định được tài khoản đăng nhập.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (string.IsNullOrWhiteSpace(userName))
            {
                MessageBox.Show("Vui lòng chọn một tài khoản để đặt lại mật khẩu.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (MessageBox.Show("Bạn có chắc chắn muốn đặt lại mật khẩu cho tài khoản này?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
            {
                ResetPassword(userName);
            }
        }
        #endregion
    }
}
