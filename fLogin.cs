using QuanLyCuaHangTraSua.DAO;
using System;
using System.Drawing;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace QuanLyCuaHangTraSua
{
    public partial class fLogin: Form
    {     
        private bool isDragging = false; // Biến cờ để kiểm tra xem form có đang được kéo hay không
        private Point lastLocation;    // Lưu trữ vị trí cuối cùng của chuột
        
        public fLogin()
        {
            InitializeComponent();
        }

        #region Event
        private void pnlDangNhap_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left) // Chỉ xử lý khi nhấn chuột trái
            {
                isDragging = true;         // Đặt cờ kéo là true
                lastLocation = e.Location; // Ghi lại vị trí hiện tại của chuột trên form
            }
        }

        private void pnlDangNhap_MouseMove(object sender, MouseEventArgs e)
        {
            if (isDragging) // Chỉ di chuyển form nếu đang trong trạng thái kéo
            {
                // Cập nhật vị trí của form bằng cách cộng dồn sự thay đổi của chuột
                this.Location = new Point(
                    (this.Location.X - lastLocation.X) + e.X,
                    (this.Location.Y - lastLocation.Y) + e.Y);

                this.Update(); // Cập nhật hiển thị form
            }
        }

        private void pnlDangNhap_MouseUp(object sender, MouseEventArgs e)
        {
            isDragging = false; // Đặt cờ kéo là false
        }

        private void pbOnOff_Click(object sender, EventArgs e)
        {
            Application.Exit();
            
        }       
        private void btnLogin_Click(object sender, EventArgs e)
        {
            string userName = txtUserName.Text.Trim(); // Lấy tên đăng nhập từ TextBox
            string password = txtPassword.Text.Trim(); // Lấy mật khẩu từ TextBox
                                                       // Kiểm tra thông tin đăng nhập
            if (Login(userName, password))
            {
                // Gán tài khoản đăng nhập vào SessionManager
                SessionManager.CurrentAccount = AccountDAO.Instance.GetAccountByUserName(userName);

                // Nếu đăng nhập thành công, mở form chính
                fMain fMain = new fMain();
                this.Hide(); // Ẩn form đăng nhập
                fMain.ShowDialog(); // Hiển thị form chính
                this.Close(); // Đóng form đăng nhập sau khi form chính được đóng
            }
            else
            {
                // Nếu đăng nhập thất bại, hiển thị thông báo lỗi
                MessageBox.Show("Tên đăng nhập hoặc mật khẩu không đúng!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        #endregion

        #region Method
        bool Login(string userName, string password)
        {
            return AccountDAO.Instance.Login(userName, password);
        }
        #endregion
    }
}
