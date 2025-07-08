using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using Microsoft.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using QuanLyCuaHangTraSua.UserControls;
using System.Text.RegularExpressions;

namespace QuanLyCuaHangTraSua.DAO
{
    // Lớp DataProvider cung cấp các phương thức để tương tác với cơ sở dữ liệu.
    class DataProvider
    {
        private static DataProvider instance;

        // Singleton property to get the single instance of DataProvider
        public static DataProvider Instance
        {
            get { if (instance == null) instance = new DataProvider(); return instance; }
            private set { instance = value; }
        }

        private DataProvider() { }

        // Connection string to the database, retrieved from application settings
        private string connString = Properties.Settings.Default.ConnectionString;

        // Executes a SQL query and returns the result as a DataTable
        public DataTable ExecuteQuery(string query, object[] parameter = null) 
        {
            DataTable data = new DataTable();

            using (SqlConnection conn = new SqlConnection(connString))
            {
                conn.Open();

                SqlCommand sqlCommand = new SqlCommand(query, conn);

                if (parameter != null)
                {
                    var matches = Regex.Matches(query, @"@\w+");
                    var paramNames = matches.Cast<Match>().Select(m => m.Value).Distinct().ToList();

                    for (int i = 0; i < paramNames.Count && i < parameter.Length; i++)
                    {
                        sqlCommand.Parameters.AddWithValue(paramNames[i], parameter[i]);
                    }
                }

                SqlDataAdapter adapter = new SqlDataAdapter(sqlCommand);

                adapter.Fill(data);

                conn.Close();
            }
            return data;
        }

        // Chạy một câu lệnh SQL không trả về dữ liệu (INSERT, UPDATE, DELETE) và trả về số lượng bản ghi bị ảnh hưởng
        public int ExecuteNonQuery(string query, object[] parameter = null)
        {
            int data = 0;

            using (SqlConnection conn = new SqlConnection(connString))
            {
                conn.Open();

                SqlCommand sqlCommand = new SqlCommand(query, conn);

                if (parameter != null)
                {
                    var matches = Regex.Matches(query, @"@\w+");
                    var paramNames = matches.Cast<Match>().Select(m => m.Value).Distinct().ToList();

                    for (int i = 0; i < paramNames.Count && i < parameter.Length; i++)
                    {
                        sqlCommand.Parameters.AddWithValue(paramNames[i], parameter[i]);
                    }
                }

                data = sqlCommand.ExecuteNonQuery();
                conn.Close();
            }
            return data;
        }

        // Chạy một câu lệnh SQL và trả về giá trị đầu tiên của cột đầu tiên trong kết quả (thường dùng cho các truy vấn trả về một giá trị duy nhất, như COUNT, SUM, v.v.)
        public object ExecuteScalar(string query, object[] parameter = null)
        {
            object data = 0;

            using (SqlConnection conn = new SqlConnection(connString))
            {
                conn.Open();

                SqlCommand sqlCommand = new SqlCommand(query, conn);

                if (parameter != null)
                {
                    var matches = Regex.Matches(query, @"@\w+");
                    var paramNames = matches.Cast<Match>().Select(m => m.Value).Distinct().ToList();

                    for (int i = 0; i < paramNames.Count && i < parameter.Length; i++)
                    {
                        sqlCommand.Parameters.AddWithValue(paramNames[i], parameter[i]);
                    }
                }

                data = sqlCommand.ExecuteScalar();
                conn.Close();
            }
            return data;
        }
    }
}
