﻿using QuanLyCuaHangTraSua.DTO;
using QuanLyCuaHangTraSua.UserControls;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyCuaHangTraSua.DAO
{
    // Lớp MenuDAO cung cấp các phương thức để truy xuất thông tin thực đơn từ cơ sở dữ liệu.
    public class MenuDAO
    {
        private static MenuDAO instance;

        public static MenuDAO Instance
        {
            get { if (instance == null) instance = new MenuDAO(); return MenuDAO.instance; }
            private set { MenuDAO.instance = value; }
        }

        private MenuDAO() { }

        public List<Menu> GetListMenuByTable(int id)
        {
            List<Menu> listMenu = new List<Menu>();

            string query = "SELECT f.name AS foodName, bi.count, f.price, f.price* bi.count AS totalPrice\r\n" +
                "FROM dbo.BillInfo AS bi, dbo.Bill AS b, dbo.Food AS f\r\n" +
                "WHERE bi.idBill = b.id AND bi.idFood = f.id AND b.status = 0 AND b.idTable =" + id;
            DataTable data = DataProvider.Instance.ExecuteQuery(query);

            foreach (DataRow item in data.Rows)
            {
                Menu menu = new Menu(item);
                listMenu.Add(menu);
            }

            return listMenu;
        }
    }
}
