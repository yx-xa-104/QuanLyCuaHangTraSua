using System.Collections.Generic;
using QuanLyCuaHangTraSua.DTO;
using QuanLyCuaHangTraSua.DAO;

namespace QuanLyCuaHangTraSua.BLL
{
    public class TableManagementBLL
    {
        public List<Category> GetCategories()
        {
            return CategoryDAO.Instance.GetListCategory();
        }

        public List<Food> GetFoodsByCategory(int categoryId)
        {
            return FoodDAO.Instance.GetFoodByCategoryID(categoryId);
        }

        public List<Table> GetTables()
        {
            return TableDAO.Instance.LoadTableList();
        }

        public List<Menu> GetMenuByTable(int tableId)
        {
            return MenuDAO.Instance.GetListMenuByTable(tableId);
        }

        public int GetUncheckBillIdByTable(int tableId)
        {
            return BillDAO.Instance.GetUncheckBillIDByTableID(tableId);
        }

        public void AddFoodToBill(int billId, int foodId, int count)
        {
            BillInfoDAO.Instance.InsertBillInfo(billId, foodId, count);
        }

        public void CreateBill(int tableId)
        {
            BillDAO.Instance.InsertBill(tableId);
        }

        public int GetMaxBillId()
        {
            return BillDAO.Instance.GetMaxIDBill();
        }

        public void CheckOut(int billId, int discount, double totalPrice)
        {
            BillDAO.Instance.CheckOut(billId, discount, totalPrice);
        }

        public void SwitchTable(int sourceBillId, int targetTableId)
        {
            BillDAO.Instance.SwitchTable(sourceBillId, targetTableId);
        }

        public void MergeTable(int sourceBillId, int targetBillId)
        {
            BillDAO.Instance.MergeTable(sourceBillId, targetBillId);
        }

        public void UpdateTableStatus(int tableId, string status)
        {
            TableDAO.Instance.UpdateTableStatus(tableId, status);
        }
    }
}
