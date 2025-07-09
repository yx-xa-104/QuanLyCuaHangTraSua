using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using QuanLyCuaHangTraSua.DTO;

namespace QuanLyCuaHangTraSua.DAO
{
    public class BillDAO
    {
        private static BillDAO instance;

        public static BillDAO Instance
        {
            get { if (instance == null) instance = new BillDAO(); return instance; }
            private set { instance = value; }
        }

        private BillDAO() { }

        public int GetUncheckBillIDByTableID(int id)
        {
            DataTable data = DataProvider.Instance.ExecuteQuery("SELECT * FROM dbo.Bill WHERE idTable = " + id + " AND status = 0");

            if (data.Rows.Count > 0)
            {
                Bill bill = new Bill(data.Rows[0]);
                return bill.ID;
            }

            return -1; // Trả về -1 nếu không tìm thấy hóa đơn chưa thanh toán
        }   

        public void InsertBill(int id)
        {
            string query = "exec USP_InsertBill @idTable";
            DataProvider.Instance.ExecuteNonQuery(query, new object[] { id });
        }

        public int GetMaxIDBill()
        {
            try
            {
                return (int)DataProvider.Instance.ExecuteScalar("SELECT MAX(id) FROM dbo.Bill");
            }
            catch
            {
                return 1; // Trả về 1 nếu không có hóa đơn nào
            }
        }

        public void CheckOut(int id, int discount, double totalPrice)
        {
            string query = "UPDATE dbo.Bill SET dateCheckOut = GETDATE(), status = 1, " + "discount = " + discount + ", totalPrice = " + totalPrice + " WHERE id = " + id;
            DataProvider.Instance.ExecuteNonQuery(query);
        }

        public void SwitchTable(int billId, int newTableId)
        {
            string query = "UPDATE Bill SET idTable = @newTableId WHERE id = @billId";
            DataProvider.Instance.ExecuteNonQuery(query, new object[] { newTableId, billId });
        }

        // Gộp hóa đơn: chuyển các món từ source sang target, cộng dồn số lượng nếu trùng món
        public void MergeTable(int sourceBillId, int targetBillId)
        {
            // Cộng dồn số lượng món trùng
            string updateQuery = @"
                                    UPDATE BI
                                    SET BI.count = BI.count + BII.count
                                    FROM BillInfo BI
                                    INNER JOIN BillInfo BII ON BI.idBill = @targetBillId AND BII.idBill = @sourceBillId AND BI.idFood = BII.idFood;
                                ";
            DataProvider.Instance.ExecuteNonQuery(updateQuery, new object[] { targetBillId, sourceBillId });

            // Thêm món chưa có ở target
            string insertQuery = @"
                                    INSERT INTO BillInfo (idBill, idFood, count)
                                    SELECT @targetBillId, idFood, count
                                    FROM BillInfo
                                    WHERE idBill = @sourceBillId AND idFood NOT IN (SELECT idFood FROM BillInfo WHERE idBill = @targetBillId);
                                ";
            DataProvider.Instance.ExecuteNonQuery(insertQuery, new object[] { targetBillId, sourceBillId });

            // Xóa BillInfo và Bill của source
            string deleteBillInfo = "DELETE FROM BillInfo WHERE idBill = @sourceBillId";
            DataProvider.Instance.ExecuteNonQuery(deleteBillInfo, new object[] { sourceBillId });

            string deleteBill = "DELETE FROM Bill WHERE id = @sourceBillId";
            DataProvider.Instance.ExecuteNonQuery(deleteBill, new object[] { sourceBillId });
        }

        public DataTable GetListBillByDate(DateTime checkIn, DateTime checkOut)
        {
            string query = "EXEC USP_GetListBillByDate @checkIn , @checkOut";
            return DataProvider.Instance.ExecuteQuery(query, new object[] { checkIn, checkOut });
        }
        public DataTable GetListBillByDate(DateTime date)
        {
            // Sử dụng lại phương thức cũ nhưng với checkIn và checkOut là cùng một ngày
            return GetListBillByDate(date, date);
        }
    }
}
