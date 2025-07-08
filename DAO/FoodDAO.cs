using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using QuanLyCuaHangTraSua.DTO;

namespace QuanLyCuaHangTraSua.DAO
{
    public class FoodDAO
    {
        private static FoodDAO instance;

        public static FoodDAO Instance
        {
            get { if (instance == null) instance = new FoodDAO(); return FoodDAO.instance; }
            private set { FoodDAO.instance = value; }
        }

        private FoodDAO() { }

        public List<Food> GetFoodByCategoryID(int id)
        {
            List<Food> list = new List<Food>();

            string query = "SELECT * FROM dbo.Food WHERE idCategory = " + id;

            DataTable data = DataProvider.Instance.ExecuteQuery(query);

            foreach (DataRow item in data.Rows)
            {
                Food food = new Food(item);
                list.Add(food);
            }
            return list;
        }

        public DataTable GetListFood()
        {
            // Truy vấn để lấy danh sách món ăn cùng với thông tin danh mục
            string query = @"
                SELECT 
                    f.id AS ID, 
                    f.name AS TenMon, 
                    f.idCategory AS IDDanhMuc, 
                    fc.name AS TenDanhMuc, 
                    f.price AS Gia,
                    f.ImagePath
                FROM dbo.Food AS f
                INNER JOIN dbo.FoodCategory AS fc ON f.idCategory = fc.id";
            return DataProvider.Instance.ExecuteQuery(query);
        }

        public bool InsertFood(string name, int idCategory, float price, string imagePath)
        {
            // Kiểm tra xem tên món ăn có hợp lệ không
            string query = "INSERT dbo.Food (name, idCategory, price, ImagePath) VALUES ( @name , @idCategory , @price , @imagePath )";
            int result = DataProvider.Instance.ExecuteNonQuery(query, new object[] { name, idCategory, price, imagePath });
            return result > 0;
        }
        public bool UpdateFood(int idFood, string name, int idCategory, float price, string imagePath)
        {
            string query = "UPDATE dbo.Food SET name = @name, idCategory = @idCategory, price = @price, ImagePath = @imagePath WHERE id = @id";
            int result = DataProvider.Instance.ExecuteNonQuery(query, new object[] { name, idCategory, price, imagePath, idFood });
            return result > 0;
        }
        public bool UpdateImageFood(int idFood, string imagePath)
        {
            // Cập nhật đường dẫn hình ảnh của món ăn
            string query = "UPDATE dbo.Food SET ImagePath = @imagePath WHERE id = @id";
            int result = DataProvider.Instance.ExecuteNonQuery(query, new object[] { imagePath, idFood });
            return result > 0;
        }
        public bool DeleteFood(int idFood)
        {
            // Xóa các bản ghi liên quan trong BillInfo trước
            DataProvider.Instance.ExecuteNonQuery("DELETE BillInfo WHERE idFood = @idFood", new object[] { idFood });

            // Xóa món ăn
            string query = "DELETE Food WHERE id = @id";
            int result = DataProvider.Instance.ExecuteNonQuery(query, new object[] { idFood });
            return result > 0;
        }

        public DataTable SearchFoodByName(string name)
        {
            // Truy vấn để tìm kiếm món ăn theo tên, sử dụng hàm chuyển đổi không dấu
            // @name là tham số đầu vào, tránh SQL Injection
            string query = @" 
                SELECT 
                    f.id AS ID, 
                    f.name AS TenMon, 
                    f.idCategory AS IDDanhMuc, 
                    fc.name AS TenDanhMuc, 
                    f.price AS Gia,
                    f.ImagePath
                FROM dbo.Food AS f 
                INNER JOIN dbo.FoodCategory AS fc ON f.idCategory = fc.id
                WHERE f.name LIKE N'%' + @name + '%'
                   OR dbo.fuConvertToUnsign1(f.name) LIKE N'%' + dbo.fuConvertToUnsign1(@name) + '%'";
            DataTable data = DataProvider.Instance.ExecuteQuery(query, new object[] { name });
            return data;
        }
    }
}
