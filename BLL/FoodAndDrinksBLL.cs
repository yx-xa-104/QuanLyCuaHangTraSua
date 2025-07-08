using iTextSharp.text.xml;
using System.Data;
using System;
using System.Drawing;
using System.IO; 
using System.Windows.Forms;
using QuanLyCuaHangTraSua.DAO;
using System.Linq;

namespace QuanLyCuaHangTraSua.BLL
{
    public class FoodAndDrinksBLL
    {
        public Image LoadImage(string relativePath)
        {
            if (string.IsNullOrEmpty(relativePath))
                return null;

            try
            {
                string fullPath = Path.Combine(Application.StartupPath, relativePath);
                if (File.Exists(fullPath))
                {
                    return Image.FromFile(fullPath);
                }
            }
            catch
            { 
                MessageBox.Show("Không thể tải hình ảnh từ đường dẫn: " + relativePath, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            return null;
        }

        public void SetupDataGridView(DataGridView dgv, object dataSource)
        {
            dgv.AutoGenerateColumns = false;
            dgv.DataSource = dataSource;
            dgv.Columns.Clear();
            dgv.Columns.Add(new DataGridViewTextBoxColumn { Name = "ID", HeaderText = "Mã", DataPropertyName = "ID" });
            dgv.Columns.Add(new DataGridViewTextBoxColumn { Name = "TenMon", HeaderText = "Tên Món Ăn", DataPropertyName = "TenMon", AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill });
            dgv.Columns.Add(new DataGridViewTextBoxColumn { Name = "TenDanhMuc", HeaderText = "Danh Mục", DataPropertyName = "TenDanhMuc" });
            dgv.Columns.Add(new DataGridViewTextBoxColumn { Name = "Gia", HeaderText = "Đơn Giá", DataPropertyName = "Gia" });
        }

        public void ClearBinding(TextBox txtID, TextBox txtDish, ComboBox cbCategory, NumericUpDown numpPrice, BindingSource foodList)
        {
            // Ngắt liên kết dữ liệu
            txtID.DataBindings.Clear();
            txtDish.DataBindings.Clear();
            cbCategory.DataBindings.Clear();
            numpPrice.DataBindings.Clear();
            // Xóa dữ liệu trong các TextBox và ComboBox
            txtID.Text = string.Empty;
            txtDish.Text = string.Empty;
            cbCategory.SelectedIndex = -1; // Đặt lại ComboBox về trạng thái không chọn
            numpPrice.Value = 0; // Đặt lại NumericUpDown về giá trị mặc định
        }

        public void FoodBinding(TextBox txtID, TextBox txtDish, ComboBox cbCategory, NumericUpDown numpPrice, BindingSource foodList)
        {
            ClearBinding(txtID, txtDish, cbCategory, numpPrice, foodList);

            txtID.DataBindings.Clear();
            txtDish.DataBindings.Clear();
            cbCategory.DataBindings.Clear();
            numpPrice.DataBindings.Clear();

            txtID.DataBindings.Add(new Binding("Text", foodList, "ID", true, DataSourceUpdateMode.Never));
            txtDish.DataBindings.Add(new Binding("Text", foodList, "TenMon", true, DataSourceUpdateMode.Never));
            cbCategory.DataBindings.Add(new Binding("SelectedValue", foodList, "IDDanhMuc", true, DataSourceUpdateMode.Never));
            numpPrice.DataBindings.Add(new Binding("Value", foodList, "Gia", true, DataSourceUpdateMode.Never));
        }

        public bool IsFoodExists(string name, int idFood)
        {
            // Convert the DataTable to an enumerable collection using AsEnumerable()
            var foodTable = FoodDAO.Instance.GetListFood();
            return foodTable.AsEnumerable().Any(row =>
                row.Field<string>("TenMon").Equals(name, StringComparison.OrdinalIgnoreCase) &&
                row.Field<int>("ID") == idFood);
        }
    }
}
