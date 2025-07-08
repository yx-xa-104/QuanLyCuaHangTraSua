using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using QuanLyCuaHangTraSua.DAO;
using QuanLyCuaHangTraSua.DTO;
using System.IO;

namespace QuanLyCuaHangTraSua.UserControls
{
    public partial class ucFoodAndDrinks: UserControl
    {
        // Sử dụng BindingSource để quản lý dữ liệu một cách hiệu quả
        readonly BindingSource foodList = new BindingSource();
        private string _currentImagePath = null; // Biến để lưu đường dẫn ảnh hiện tại

        public ucFoodAndDrinks()
        {
            InitializeComponent();
            // Gán sự kiện Load để đảm bảo các control đã được khởi tạo
            this.Load += ucFoodAndDrinks_Load;
            dgvFoodAndDrinks.AllowUserToAddRows = false;
        }

        #region Method
        // Biến để xác định chế độ thêm mới
        private bool isAddNewMode = false;

        void ShowImage(string relativePath)
        {
            if (string.IsNullOrEmpty(relativePath))
            {
                pictureBox1.Image = null; // Xóa ảnh nếu không có đường dẫn
                return;
            }
            try
            {
                // Ghép đường dẫn tương đối với thư mục chạy của ứng dụng
                string fullPath = Path.Combine(Application.StartupPath, relativePath);
                if (File.Exists(fullPath))
                {
                    // Sử dụng Image.FromFile để không khóa file ảnh
                    pictureBox1.Image = Image.FromFile(fullPath);
                }
                else
                {
                    pictureBox1.Image = null; // Xóa ảnh nếu file không tồn tại
                }
            }
            catch
            {
                pictureBox1.Image = null; // Xóa ảnh nếu có lỗi xảy ra
            }
        }

        // Cấu hình các cột cho DataGridView thủ công.
        // Đảm bảo các cột luôn tồn tại và tránh lỗi NullReferenceException.
        void SetupDataGridView()
        {
            dgvFoodAndDrinks.AutoGenerateColumns = false;
            dgvFoodAndDrinks.DataSource = foodList;
            dgvFoodAndDrinks.Columns.Clear();
            dgvFoodAndDrinks.Columns.Add(new DataGridViewTextBoxColumn { Name = "ID", HeaderText = "Mã", DataPropertyName = "ID" });
            dgvFoodAndDrinks.Columns.Add(new DataGridViewTextBoxColumn { Name = "TenMon", HeaderText = "Tên Món Ăn", DataPropertyName = "TenMon", AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill });
            dgvFoodAndDrinks.Columns.Add(new DataGridViewTextBoxColumn { Name = "TenDanhMuc", HeaderText = "Danh Mục", DataPropertyName = "TenDanhMuc" });
            dgvFoodAndDrinks.Columns.Add(new DataGridViewTextBoxColumn { Name = "Gia", HeaderText = "Đơn Giá", DataPropertyName = "Gia" });
        }

        void ClearBinding()
        {
            // Xóa các binding hiện tại để tránh lỗi khi thêm mới
            txtID.DataBindings.Clear();
            txtDish.DataBindings.Clear();
            cbCategory.DataBindings.Clear();
            numpPrice.DataBindings.Clear();
        }

        void SetBinding()
        {
            ClearBinding();

            // Thêm các binding mới, liên kết trực tiếp với BindingSource
            txtID.DataBindings.Add(new Binding("Text", foodList, "ID", true, DataSourceUpdateMode.Never));
            txtDish.DataBindings.Add(new Binding("Text", foodList, "TenMon", true, DataSourceUpdateMode.Never));
            cbCategory.DataBindings.Add(new Binding("SelectedValue", foodList, "IDDanhMuc", true, DataSourceUpdateMode.Never));
            numpPrice.DataBindings.Add(new Binding("Value", foodList, "Gia", true, DataSourceUpdateMode.Never));

            isAddNewMode = false; // Tắt cờ "Thêm mới"
        }

        void LoadCategoryIntoCombobox(ComboBox cb)
        {
            cb.DataSource = CategoryDAO.Instance.GetListCategory();
            cb.DisplayMember = "Name"; // Hiển thị tên danh mục
            cb.ValueMember = "ID";   // Nhưng giá trị thực sự là ID
        }
        #endregion

        #region Event
        private void ucFoodAndDrinks_Load(object sender, EventArgs e)
        {
            // Thiết lập DataGridView và gán DataSource
            SetupDataGridView();
            // Tải dữ liệu từ CSDL
            LoadFoodList();
            // Thiết lập liên kết dữ liệu cho các TextBox
            SetBinding();
            LoadCategoryIntoCombobox(cbCategory);
            foodList.CurrentChanged += FoodList_CurrentChanged;
        }

        private void FoodList_CurrentChanged(object sender, EventArgs e)
        {
            // Lấy đường dẫn ảnh từ món ăn đang được chọn
            if (foodList.Current is DataRowView rowView)
            {
                string imagePath = rowView["ImagePath"] != DBNull.Value ? rowView["ImagePath"].ToString() : null;

                // Hiển thị ảnh
                ShowImage(imagePath);
                _currentImagePath = imagePath; // Cập nhật đường dẫn hiện tại
            }
        }

        private void btnUpload_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFile = new OpenFileDialog();
            openFile.Filter = "Image Files (*.jpg, *.jpeg, *.png, *.gif, *.bmp)|*.jpg; *.jpeg; *.png; *.gif; *.bmp";
            if (openFile.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    // Tạo thư mục "Images"
                    string imageDir = Path.Combine(Application.StartupPath, "Images");
                    if (!Directory.Exists(imageDir))
                    {
                        Directory.CreateDirectory(imageDir);
                    }

                    // Tạo tên file duy nhất và copy vào thư mục Images
                    string fileName = Guid.NewGuid().ToString() + Path.GetExtension(openFile.FileName);
                    string destinationPath = Path.Combine(imageDir, fileName);
                    File.Copy(openFile.FileName, destinationPath);

                    // Hiển thị ảnh vừa tải lên
                    pictureBox1.Image = Image.FromFile(destinationPath);

                    // Lưu đường dẫn tương đối để lưu vào CSDL
                    _currentImagePath = Path.Combine("Images", fileName);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi khi tải ảnh: " + ex.Message);
                }
            }
        }

        private void btnView_Click(object sender, EventArgs e)
        {
            LoadFoodList();
        }
        void LoadFoodList()
        {
            foodList.DataSource = FoodDAO.Instance.GetListFood();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (!isAddNewMode)
            {
                // Chuyển sang chế độ thêm mới
                isAddNewMode = true;
                txtID.Text = "";
                txtDish.Text = "";
                cbCategory.SelectedIndex = -1;
                numpPrice.Value = 0;
                pictureBox1.Image = null;
                _currentImagePath = null;

                txtDish.ReadOnly = false;
                txtID.ReadOnly = true;
                cbCategory.Enabled = true;
                numpPrice.Enabled = true;
                btnEdit.Enabled = false;
                btnAdd.Text = "Lưu";
                return;
            }

            // Đang ở chế độ thêm mới, thực hiện lưu dữ liệu
            try
            {
                string name = txtDish.Text;
                if (cbCategory.SelectedValue == null)
                {
                    MessageBox.Show("Vui lòng chọn danh mục!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                int categoryID = (int)cbCategory.SelectedValue;
                float price = (float)numpPrice.Value;

                if (string.IsNullOrWhiteSpace(name))
                {
                    MessageBox.Show("Tên món ăn không được để trống!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                if (categoryID == 0)
                {
                    MessageBox.Show("Vui lòng chọn danh mục cho món ăn!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                if (float.IsNaN(price) || price <= 0)
                {
                    MessageBox.Show("Giá món ăn phải lớn hơn 0!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                if (string.IsNullOrEmpty(_currentImagePath))
                {
                    MessageBox.Show("Vui lòng tải lên ảnh cho món ăn!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                if (FoodDAO.Instance.InsertFood(name, categoryID, price, _currentImagePath))
                {
                    MessageBox.Show("Thêm món thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    LoadFoodList();
                    SetBinding();
                    isAddNewMode = false;
                    btnAdd.Text = "Thêm";
                }
                else
                {
                    MessageBox.Show("Có lỗi khi thêm món ăn!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            try
            {
                string name = txtDish.Text;
                int categoryID = (int)cbCategory.SelectedValue;
                float price = (float)numpPrice.Value;

                // Kiểm tra xem ID có hợp lệ không
                if (!int.TryParse(txtID.Text, out int id))
                {
                    MessageBox.Show("Vui lòng chọn một món ăn để sửa.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                if (string.IsNullOrWhiteSpace(txtDish.Text))
                {
                    MessageBox.Show("Tên món ăn không được để trống!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                if (int.Parse(cbCategory.SelectedValue.ToString()) == 0)
                {
                    MessageBox.Show("Vui lòng chọn danh mục cho món ăn!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                if (float.IsNaN(price) || price <= 0)
                {
                    MessageBox.Show("Giá món ăn phải lớn hơn 0!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                if (string.IsNullOrEmpty(_currentImagePath))
                {
                    MessageBox.Show("Vui lòng tải lên ảnh cho món ăn!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                // Cập nhật món ăn với đường dẫn ảnh
                if (FoodDAO.Instance.UpdateFood(id, name, categoryID, price, _currentImagePath))
                {
                    MessageBox.Show("Cập nhật món ăn thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    LoadFoodList();
                }
                else
                {
                    MessageBox.Show("Có lỗi khi cập nhật món ăn!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            // Kiểm tra xem ID có hợp lệ không
            if (!int.TryParse(txtID.Text, out int id))
            {
                MessageBox.Show("Vui lòng chọn một món ăn để xóa.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            // Xác nhận xóa món ăn
            try
            {
                if (MessageBox.Show("Bạn có chắc chắn muốn xóa món này?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
                {
                    if (FoodDAO.Instance.DeleteFood(id))
                    {
                        MessageBox.Show("Xóa món ăn thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        LoadFoodList();
                    }
                    else
                    {
                        MessageBox.Show("Có lỗi khi xóa món ăn!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            foodList.DataSource = FoodDAO.Instance.SearchFoodByName(txtSearch.Text);
        }

        private void dgvFoodAndDrinks_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            // Nếu đang ở chế độ thêm mới, hủy chế độ thêm mới và quay lại chế độ xem/sửa
            if (isAddNewMode)
            {
                isAddNewMode = false;
                SetBinding();
                btnAdd.Text = "Thêm";
                btnEdit.Enabled = true;
            }

            // Nếu click vào dòng hợp lệ thì cập nhật lại trạng thái các control
            if (e.RowIndex >= 0 && e.RowIndex < dgvFoodAndDrinks.Rows.Count)
            {
                txtDish.ReadOnly = false;
                txtID.ReadOnly = true;
                cbCategory.Enabled = true;
                numpPrice.Enabled = true;
                btnEdit.Enabled = true;
                btnAdd.Enabled = true;
            }
        }
        #endregion
    }
}


