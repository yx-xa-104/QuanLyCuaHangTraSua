using QuanLyCuaHangTraSua.DAO;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QuanLyCuaHangTraSua.UserControls
{
    public partial class ucTable: UserControl
    {    
        public ucTable()
        {
            InitializeComponent();
            LoadTable();
            dgvTable.DataSource = tableList;
            AddTableBinding();
        }

        #region Method
        BindingSource tableList = new BindingSource();
        private bool isAddNewMode = false;
        void LoadTable()
        {
            tableList.DataSource = TableDAO.Instance.LoadTableList();
        }
        void AddTableBinding()
        {
            // Xóa binding cũ để tránh lỗi (nếu có)
            txtID.DataBindings.Clear();
            txtTableName.DataBindings.Clear();
            cbStatus.DataBindings.Clear();

            txtID.DataBindings.Add(new Binding("Text", dgvTable.DataSource, "ID", true, DataSourceUpdateMode.Never));
            txtTableName.DataBindings.Add(new Binding("Text", dgvTable.DataSource, "Name", true, DataSourceUpdateMode.Never));
            cbStatus.DataBindings.Add(new Binding("Text", dgvTable.DataSource, "Status", true, DataSourceUpdateMode.Never));
            txtID.ReadOnly = true;
        }
        #endregion

        #region Event       
        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (!isAddNewMode)
            {
                // Chuyển sang chế độ thêm mới
                isAddNewMode = true;
                txtID.Text = "";
                txtID.Enabled = false; // Không cho sửa ID khi thêm mới
                txtTableName.Text = "";
                cbStatus.SelectedIndex = -1;
                txtTableName.ReadOnly = false;
                cbStatus.Enabled = true;
                btnEdit.Enabled = false;
                btnAdd.Text = "Lưu";
                return;
            }

            // Đang ở chế độ thêm mới, thực hiện lưu
            string name = txtTableName.Text.Trim();
            string status = cbStatus.Text.Trim();

            if (string.IsNullOrWhiteSpace(name))
            {
                MessageBox.Show("Tên bàn không được để trống!");
                return;
            }
            if (string.IsNullOrWhiteSpace(status))
            {
                MessageBox.Show("Vui lòng chọn trạng thái bàn!");
                return;
            }

            if (TableDAO.Instance.InsertTable(name, status))
            {
                MessageBox.Show("Thêm bàn thành công");
                LoadTable();
                AddTableBinding();
                isAddNewMode = false;
                btnAdd.Text = "Thêm";
                btnEdit.Enabled = true;
            }
            else
            {
                MessageBox.Show("Thêm bàn thất bại");
            }
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            if (txtID.Text == "")
            {
                MessageBox.Show("Vui lòng chọn bàn để sửa!");
                return;
            }
            txtTableName.ReadOnly = false;
            cbStatus.Enabled = true;

            // Khi bấm lại lần nữa sẽ lưu
            btnEdit.Text = btnEdit.Text == "Lưu" ? "Sửa" : "Lưu";

            if (btnEdit.Text == "Lưu")
                return;

            // Lưu thông tin sửa
            int id = Convert.ToInt32(txtID.Text);
            string name = txtTableName.Text.Trim();
            string status = cbStatus.Text.Trim();

            if (string.IsNullOrWhiteSpace(name))
            {
                MessageBox.Show("Tên bàn không được để trống!");
                return;
            }
            if (string.IsNullOrWhiteSpace(status))
            {
                MessageBox.Show("Vui lòng chọn trạng thái bàn!");
                return;
            }

            if (TableDAO.Instance.UpdateTable(id, name, status))
            {
                MessageBox.Show("Sửa bàn thành công");
                LoadTable();
                AddTableBinding();
                txtTableName.ReadOnly = true;
                cbStatus.Enabled = false;
                btnEdit.Text = "Sửa";
            }
            else
            {
                MessageBox.Show("Sửa bàn thất bại");
            }
        }
        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtID.Text))
            {
                MessageBox.Show("Vui lòng chọn một bàn để xóa.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            int id = Convert.ToInt32(txtID.Text);

            // Sử dụng MessageBox để xác nhận trước khi xóa
            if (MessageBox.Show("Bạn có chắc chắn muốn xóa bàn này?", "Xác nhận xóa", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                // Gọi phương thức DeleteTable đã được cập nhật
                if (TableDAO.Instance.DeleteTable(id))
                {
                    MessageBox.Show("Xóa bàn thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    LoadTable(); // Tải lại danh sách bàn
                }
                else
                {
                    // Hiển thị thông báo lỗi thân thiện nếu không xóa được
                    MessageBox.Show("Xóa bàn thất bại! Bàn này có thể đang được sử dụng hoặc đã có hóa đơn liên quan.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void btnView_Click(object sender, EventArgs e)
        {
            LoadTable();
        }
        private void dgvTable_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (isAddNewMode)
            {
                isAddNewMode = false;
                AddTableBinding();
                btnAdd.Text = "Thêm";
                btnEdit.Enabled = true;
            }
            txtTableName.ReadOnly = true;
            cbStatus.Enabled = true;
        }
        #endregion
    }
}