using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyCuaHangTraSua.DTO
{
    // Lớp DTO (Data Transfer Object) cho tài khoản người dùng.
    public class Account
    {
        public Account(string userName, string displayName, int type, string password = null)
        {
            this.UserName = userName;
            this.DisplayName = displayName;
            this.Type = type;
            this.Password = password;
        }

        // Chia Account thành các thuộc tính để dễ dàng truy xuất và cập nhật
        public Account(DataRow row)
        {
            this.UserName = row["userName"].ToString();
            this.DisplayName = row["displayName"].ToString();
            this.Type = (int)row["type"];
        }

        private int type;
        private string password;
        private string displayName;
        private string userName;

        public string UserName { get => userName; set => userName = value; }
        public string DisplayName { get => displayName; set => displayName = value; }
        public string Password { get => password; set => password = value; }
        public int Type { get => type; set => type = value; }
    }
}