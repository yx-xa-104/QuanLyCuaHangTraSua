using QuanLyCuaHangTraSua.DAO;
using QuanLyCuaHangTraSua.User_Controls;
using QuanLyCuaHangTraSua.UserControls;
using System;
using System.Windows.Forms;
using System.Drawing;

namespace QuanLyCuaHangTraSua
{
    public partial class fMain: Form
    {
        private UserControl currentChildUserControl; // Để theo dõi User Control đang hiển thị
               
        // Khai báo biến toàn cục trong MainForm
        bool isMenuExpanded = true; // Ban đầu menu đang mở rộng
        public fMain()
        {
            InitializeComponent();
            // Mở trang tổngg quan khi khởi động ứng dụng
            button1_Click(button1, EventArgs.Empty);
            SetMenuByRole(); // Thiết lập menu dựa trên vai trò người dùng
        }

        #region Method
        private void OpenChildUserControl(UserControl userControl, string title, Control activeControl)
        {
            // Cập nhật Text của Label tiêu đề
            lblTitle.Text = title; // lblTitle là tên của Label trên top
            lblCurrentUser.Text = SessionManager.CurrentAccount.DisplayName;
            // Nếu đã có User Control đang hiển thị, giải phóng nó
            if (currentChildUserControl != null)
            {
                currentChildUserControl.Dispose();
            }

            currentChildUserControl = userControl;
            userControl.Dock = DockStyle.Fill; // Đảm bảo User Control lấp đầy Panel

            this.pnlMain.Controls.Clear();    // Xóa tất cả các controls hiện có trong panel
            this.pnlMain.Controls.Add(userControl); // Thêm User Control mới vào panel
          
        }

        public void SettingUC_DisplayNameChanged(object sender, EventArgs e)
        {                    
        }

        private void SetMenuByRole()
        {
            if (SessionManager.CurrentAccount != null && SessionManager.CurrentAccount.Type == 0) // Nhân viên
            {
                btnTableManagement.Visible = true;
                btnAccountManager.Visible = false;
                btnCategory.Visible = false;
                btnRevenue.Visible = false;
                btnFoodAndDninks.Visible = false;
                btnTable.Visible = true;
            }
            else // Admin
            {
                btnTableManagement.Visible = true;
                btnCategory.Visible = true;
                btnAccountManager.Visible = true;
                btnRevenue.Visible = true;
                btnFoodAndDninks.Visible = true;
                btnTable.Visible = true;
            }
        }                    
        #endregion

        #region Event              
        private void btnAccountManager_Click(object sender, EventArgs e)
        {
            OpenChildUserControl(new ucAccountManagement(), "Quản lý tài khoản", (Control)sender);
        }
        private void btnTable_Click(object sender, EventArgs e)
        {
            OpenChildUserControl(new ucTable(), "Bàn ăn", (Control)sender);
        }

        private void btnCategory_Click(object sender, EventArgs e)
        {
            OpenChildUserControl(new ucCategory(), "Danh mục", (Control)sender);
        }

        private void btnRevenue_Click(object sender, EventArgs e)
        {
            OpenChildUserControl(new ucRevenue(), "Doanh thu", (Control)sender);
        }

        private void btnFoodAndDninks_Click(object sender, EventArgs e)
        {
            OpenChildUserControl(new ucFoodAndDrinks(), " Đồ uống", (Control)sender);
        }

        private void btnTableManagement_Click(object sender, EventArgs e)
        {
            OpenChildUserControl(new ucTableManagement(), "Quản lý bàn", (Control)sender);
        }

        private void pbSetting_Click(object sender, EventArgs e)
        {
            var settingUC = new ucSetting();
            settingUC.DisplayNameChanged += SettingUC_DisplayNameChanged;
            OpenChildUserControl(new ucSetting(), "Cài đặt", (Control)sender);
        }
        private void button1_Click(object sender, EventArgs e)
        {
            OpenChildUserControl(new ucDashboard(), "Tổng quan", button1);
        }
        private void fMain_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (MessageBox.Show("Bạn có thật sự muốn thoát chương trình?", "Thông báo", MessageBoxButtons.OKCancel) != System.Windows.Forms.DialogResult.OK)
            {
                e.Cancel = true;
            }
        }
        private void lblTitle_Click(object sender, EventArgs e)
        {

        }

        
        #endregion


    }
}







// private System.Windows.Forms.Panel pnlMain;