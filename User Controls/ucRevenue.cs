using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using QuanLyCuaHangTraSua.DAO;
using System.Windows.Forms.DataVisualization.Charting;
using System.Runtime.InteropServices;
using QuanLyCuaHangTraSua.BLL;

namespace QuanLyCuaHangTraSua.UserControls
{
    // User Control hiển thị doanh thu
    public partial class ucRevenue: UserControl
    {
        public ucRevenue()
        {
            InitializeComponent();
            LoadDateTimePickerBill();
            UpdateSummaryPanels();
            LoadListBillByDate(dtpCheckIn.Value, dtpCheckOut.Value);
            dgvRevenue.AllowUserToAddRows = false;
        }

        #region Method
        private RevenueBLL revenueBLL = new RevenueBLL();

        void LoadListBillByDate(DateTime checkIn, DateTime checkOut)
        {
            var billTable = revenueBLL.GetBillsByDate(checkIn, checkOut);
            dgvRevenue.DataSource = billTable;
            LoadRevenueChart(billTable);
        }

        private void UpdateSummaryPanels()
        {
            decimal totalMoney = revenueBLL.GetTotalMoney();
            int totalInvoice = revenueBLL.GetTotalInvoice();

            lblTotalMoney.Text = totalMoney.ToString("N0") + " VNĐ";
            lblTotalInvoice.Text = totalInvoice.ToString();
        }

        void LoadRevenueChart(DataTable billTable)
        {
            chart2.Series.Clear();
            chart2.ChartAreas.Clear();

            ChartArea chartArea = new ChartArea("RevenueArea");
            chart2.ChartAreas.Add(chartArea);

            Series series = new Series("Doanh thu");
            series.ChartType = SeriesChartType.Column;

            var revenueByDate = revenueBLL.GetRevenueByDate(billTable);

            foreach (var item in revenueByDate.OrderBy(x => x.Key))
            {
                series.Points.AddXY(item.Key.ToString("dd/MM/yyyy"), item.Value);
            }

            chart2.Series.Add(series);
        }
        #endregion

        #region Event
        private void btnView_Click(object sender, EventArgs e)
        {
            LoadListBillByDate(dtpCheckIn.Value, dtpCheckOut.Value);
        }

        void LoadDateTimePickerBill()
        {
            DateTime today = DateTime.Now;
            dtpCheckIn.Value = new DateTime(today.Year, today.Month, 1);
            dtpCheckOut.Value = dtpCheckIn.Value.AddMonths(1).AddDays(-1); 
        }       
        #endregion
    }
}
