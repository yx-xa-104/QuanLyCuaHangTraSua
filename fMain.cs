using System;
using System.Windows.Forms;
using QuanLyCuaHangTraSua.UserControls;
using QuanLyCuaHangTraSua.DAO;

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
            OpenChildUserControl(new ucTableManagement(), "Quản lý bàn");
            SetMenuByRole(); // Thiết lập menu dựa trên vai trò người dùng
        }

        #region Method
        private void OpenChildUserControl(UserControl userControl, string title)
        {
            // Cập nhật Text của Label tiêu đề
            lblTitle.Text = title; // lblTitle là tên của Label trên top
            lblDisplayName.Text = AccountDAO.Instance.GetAccountByUserName(SessionManager.CurrentAccount.UserName).DisplayName;

            // Nếu đã có User Control đang hiển thị, giải phóng nó
            if (currentChildUserControl != null)
            {
                currentChildUserControl.Dispose();
            }

            currentChildUserControl = userControl;
            userControl.Dock = DockStyle.Fill; // Đảm bảo User Control lấp đầy Panel

            pnlMain.Controls.Clear();    // Xóa tất cả các controls hiện có trong panel
            pnlMain.Controls.Add(userControl); // Thêm User Control mới vào panel
        }

        public void SettingUC_DisplayNameChanged(object sender, EventArgs e)
        {
            // Cập nhật lại tên hiển thị trên giao diện
            lblDisplayName.Text = SessionManager.CurrentAccount.DisplayName;
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
                // Ẩn các nút khác tương tự
            }
            else // Admin
            {
                btnTableManagement.Visible = true;
                btnCategory.Visible = true;
                btnAccountManager.Visible = true;
                btnRevenue.Visible = true;
                btnFoodAndDninks.Visible = true;
                btnTable.Visible = true;
                // Hiện các nút khác tương tự
            }
        }
        #endregion

        #region Event
        private void pbToggleMenu_Click(object sender, EventArgs e)
        {
            timerMenu.Start();
            lblDisplayName.Visible = !lblDisplayName.Visible; // Ẩn/hiện tên hiển thị khi click vào biểu tượng menu
        }

        private void timerMenu_Tick(object sender, EventArgs e)
        {
            if (isMenuExpanded)
            {
                pnlTopMenu.Width -= 15;
                pnlMenu.Width -= 15;
                if (pnlMenu.Width <= 80 && pnlTopMenu.Width <= 80)
                {
                    isMenuExpanded = false;
                    timerMenu.Stop();
                }
            }
            else
            {
                pnlTopMenu.Width += 15;
                pnlMenu.Width += 15;
                if (pnlMenu.Width >= 240 && pnlTopMenu.Width <= 240)
                {
                    isMenuExpanded = true;
                    timerMenu.Stop();
                }
            }
        }

        private void btnAccountManager_Click(object sender, EventArgs e)
        {
            OpenChildUserControl(new ucAccountManagement(), "Quản lý tài khoản");
        }

        private void btnTable_Click(object sender, EventArgs e)
        {
            OpenChildUserControl(new ucTable(), "Bàn ăn");
        }

        private void btnCategory_Click(object sender, EventArgs e)
        {
            OpenChildUserControl(new ucCategory(), "Danh mục");
        }

        private void btnRevenue_Click(object sender, EventArgs e)
        {
            OpenChildUserControl(new ucRevenue(), "Doanh thu");
        }

        private void btnFoodAndDninks_Click(object sender, EventArgs e)
        {
            OpenChildUserControl(new ucFoodAndDrinks(), "Thức ăn và đồ uống");
        }

        private void btnTableManagement_Click(object sender, EventArgs e)
        {
            OpenChildUserControl(new ucTableManagement(), "Quản lý bàn");
        }

        private void pbSetting_Click(object sender, EventArgs e)
        {
            var settingUC = new ucSetting();
            settingUC.DisplayNameChanged += SettingUC_DisplayNameChanged;
            OpenChildUserControl(new ucSetting(), "Cài đặt");
        }

        private void fMain_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (MessageBox.Show("Bạn có thật sự muốn thoát chương trình?", "Thông báo", MessageBoxButtons.OKCancel) != System.Windows.Forms.DialogResult.OK)
            {
                e.Cancel = true;
            }
        }
        #endregion
    }
}
