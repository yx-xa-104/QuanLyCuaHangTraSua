using QuanLyCuaHangTraSua.DAO;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QuanLyCuaHangTraSua.User_Controls
{
    public partial class ucDashboard : UserControl
    {
        public ucDashboard()
        {
            InitializeComponent();
            this.Load += ucDashboard_Load;
        }
        private void ucDashboard_Load(object sender, EventArgs e)
        {
            // Chỉ tải dữ liệu khi không ở trong chế độ thiết kế
            if (!this.DesignMode)
            {
                LoadDashboardData();
            }
        }
        private void LoadDashboardData()
        {
            DateTime today = DateTime.Now;

            // Tải doanh thu trong ngày
            decimal todayRevenue = BillInfoDAO.Instance.GetTotalMoneyByDate(today);
            lblRevenueToday.Text = todayRevenue.ToString("N0") + " VNĐ";

            // Tải tổng số hóa đơn trong ngày
            int todayInvoices = BillInfoDAO.Instance.GetTotalInvoiceByDate(today);
            lblBillToday.Text = todayInvoices.ToString();

            // Tải số bàn đang có khách
            try
            {
                // Sử dụng Linq để đếm trực tiếp từ danh sách
                int busyTables = TableDAO.Instance.LoadTableList().Count(table => table.Status == "Có người");
                lblTableNow.Text = busyTables.ToString();
            }
            catch (Exception ex)
            {
                lblTableNow.Text = "Lỗi!";
                MessageBox.Show("Không thể tải thông tin bàn: " + ex.Message);
            }
        }
    }
}
