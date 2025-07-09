using QuanLyCuaHangTraSua.DTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyCuaHangTraSua.DAO
{
    public class BillInfoDAO
    {
        private static BillInfoDAO instance;
        public static BillInfoDAO Instance
        {
            get { if (instance == null) instance = new BillInfoDAO(); return instance; }
            private set { instance = value; }
        }
        private BillInfoDAO() { }

        public List<BillInfo> GetListBillInfo(int id)
        {
            List<BillInfo> listBillInfo = new List<BillInfo>();
            string query = "SELECT * FROM dbo.BillInfo WHERE idBill = " + id;
            DataTable data = DataProvider.Instance.ExecuteQuery(query);
            foreach (DataRow item in data.Rows)
            {
                BillInfo billInfo = new BillInfo(item);
                listBillInfo.Add(billInfo);
            }
            return listBillInfo;
        }

        public void InsertBillInfo(int idBill, int idFood, int count)
        {
            string query = "USP_InsertBillInfo @idBill, @idFood, @count";
            DataProvider.Instance.ExecuteNonQuery(query, new object[] { idBill, idFood, count });
        }

        public int GetTotalInvoice()
        {
            string query = "SELECT COUNT(*) FROM Bill WHERE Status = 1"; // Status = 1: đã thanh toán
            object result = DataProvider.Instance.ExecuteScalar(query);
            return result != null ? Convert.ToInt32(result) : 0;
        }

        public decimal GetTotalMoney()
        {
            string query = "SELECT ISNULL(SUM(TotalPrice), 0) FROM Bill WHERE Status = 1"; // Status = 1: đã thanh toán
            object result = DataProvider.Instance.ExecuteScalar(query);
            return result != null ? Convert.ToDecimal(result) : 0;
        }
        public decimal GetTotalMoneyByDate(DateTime date)
        {
            // Tính tổng TotalPrice của các hóa đơn đã thanh toán (status = 1)
            string query = @"
        SELECT ISNULL(SUM(TotalPrice), 0)
        FROM dbo.Bill
        WHERE CAST(dateCheckOut AS DATE) = CAST(@date AS DATE) AND status = 1";
            object result = DataProvider.Instance.ExecuteScalar(query, new object[] { date });
            return result != null ? Convert.ToDecimal(result) : 0;
        }

        public int GetTotalInvoiceByDate(DateTime date)
        {
            // Đếm số hóa đơn đã thanh toán (status = 1)
            string query = @"
        SELECT COUNT(*)
        FROM dbo.Bill
        WHERE CAST(dateCheckOut AS DATE) = CAST(@date AS DATE) AND status = 1";
            object result = DataProvider.Instance.ExecuteScalar(query, new object[] { date });
            return result != null ? Convert.ToInt32(result) : 0;
        }
    }
}
