using QuanLyCuaHangTraSua.DAO;
using QuanLyCuaHangTraSua.DTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;

namespace QuanLyCuaHangTraSua.DAO
{
    //  CHỈ CHỨA các phương thức liên quan đến tài khoản, không chứa logic nghiệp vụ.
    public class AccountDAO
    {
        private static AccountDAO instance;

        public static AccountDAO Instance
        {
            get { if (instance == null) instance = new AccountDAO(); return instance; }
            private set { instance = value; }
        }

        private AccountDAO() { }
        public bool Login(string userName, string passWord)
        {
            string hashedPass = HashPassword(passWord);

            string query = "USP_Login @userName , @passWord";

            DataTable result = DataProvider.Instance.ExecuteQuery(query, new object[] { userName, hashedPass });

            return result.Rows.Count > 0; // Trả về true nếu có ít nhất một tài khoản khớp với thông tin đăng nhập
        }


        // Lấy thông tin tài khoản bằng UserName
        public Account GetAccountByUserName(string userName)
        {
            DataTable data = DataProvider.Instance.ExecuteQuery("SELECT * FROM account WHERE userName = @userName", new object[] { userName });
            foreach (DataRow item in data.Rows)
            {
                return new Account(item);
            }
            return null;
        }

        // Thêm một tài khoản mới. Mật khẩu mặc định là "0".
        public bool InsertAccount(string userName, string displayName, int type)
        {
            string defaultPassword = HashPassword("0");
            string query = "INSERT dbo.Account ( UserName, DisplayName, PassWord, Type ) VALUES ( @userName , @displayName , @password , @type )";
            int result = DataProvider.Instance.ExecuteNonQuery(query, new object[] { userName, displayName, defaultPassword, type });
            return result > 0;
        }
        
        // Cập nhật thông tin tài khoản.
        public bool UpdateAccount(string userName, string displayName, int type)
        {
            string query = "UPDATE dbo.Account SET DisplayName = @displayName , Type = @type WHERE UserName = @userName";
            int result = DataProvider.Instance.ExecuteNonQuery(query, new object[] { displayName, type, userName });
            return result > 0;
        }

        // Xóa một tài khoản.
        public bool DeleteAccount(string userName)
        {
            string query = "DELETE dbo.Account WHERE UserName = @userName";
            int result = DataProvider.Instance.ExecuteNonQuery(query, new object[] { userName });
            return result > 0;
        }

        public bool ResetPassword(string name)
        {
            string defaultPassword = HashPassword("0");
            string query = string.Format("UPDATE dbo.Account SET password = N'0' WHERE UserName = N'{0}'", name);
            int result = DataProvider.Instance.ExecuteNonQuery(query);
            return result > 0;
        }

        public bool ChangePassword(string userName, string newPassword)
        {
            string hashedNewPassword = HashPassword(newPassword);
            string query = "UPDATE dbo.Account SET PassWord = @newPassword WHERE UserName = @userName";
            int result = DataProvider.Instance.ExecuteNonQuery(query, new object[] { hashedNewPassword, userName });
            return result > 0;
        }

        private string HashPassword(string password)
        {
            using (SHA256 sha256 = SHA256.Create())
            {
                byte[] bytes = Encoding.UTF8.GetBytes(password);
                byte[] hash = sha256.ComputeHash(bytes);
                StringBuilder builder = new StringBuilder();
                foreach (byte b in hash)
                    builder.Append(b.ToString("x2"));
                return builder.ToString();
            }
        }
    }
}
