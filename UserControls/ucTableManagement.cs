using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using System.Runtime.InteropServices;
using QuanLyCuaHangTraSua.DTO;
using QuanLyCuaHangTraSua.DAO;
using System.Globalization;
using QuanLyCuaHangTraSua.BLL;
using System.IO;
using System.Xml;
using iTextSharp.text.pdf;
using iTextSharp.text;

namespace QuanLyCuaHangTraSua.UserControls
{
    public partial class ucTableManagement: UserControl
    {
        private bool isDiscountApplied = false;
        private int appliedDiscount = 0;

        public ucTableManagement()
        {
            InitializeComponent();
            // Khóa không cho người dùng sửa ID
            if (!this.DesignMode)
            {
                LoadTable();
                LoadCategory();
                LoadTableComboBox();
            }
        }

        #region Method
        private TableManagementBLL tableBLL = new TableManagementBLL();
        void LoadCategory()
        {
            var listCategory = tableBLL.GetCategories();
            cbCategory.DataSource = listCategory;
            cbCategory.DisplayMember = "Name";
        }

        void LoadFoodListByCategoryID(int id)
        {
            var listFood = tableBLL.GetFoodsByCategory(id);
            cbFoodAndDrinks.DataSource = listFood;
            cbFoodAndDrinks.DisplayMember = "Name";
        }

        void LoadTable()
        {
            flpTable.Controls.Clear();
            var tableList = tableBLL.GetTables();
            foreach (var item in tableList)
            {
                Button btn = new Button() { Width = TableDAO.TableWidth, Height = TableDAO.TableHeight };
                btn.Text = item.Name + Environment.NewLine + item.Status;
                flpTable.Controls.Add(btn);
                btn.Click += btn_Click;
                btn.Tag = item;
                btn.BackColor = item.Status == "Trống" ? Color.LightGreen : Color.LightCoral;
            }
        }

        void ShowBill(int id)
        {
            // Hiển thị thông tin hóa đơn cho bàn
            lsvBill.Items.Clear();
            var listBillInfo = tableBLL.GetMenuByTable(id);            
            float totalPrice = 0;
            foreach (var item in listBillInfo)
            {
                ListViewItem lsvItem = new ListViewItem(item.FoodName.ToString());
                lsvItem.SubItems.Add(item.Count.ToString());
                lsvItem.SubItems.Add(item.Price.ToString());
                lsvItem.SubItems.Add(item.TotalPrice.ToString());
                totalPrice += item.TotalPrice;
                lsvBill.Items.Add(lsvItem);
            }
            txtTotalPrice.Text = totalPrice.ToString("c", System.Globalization.CultureInfo.GetCultureInfo("vi-VN"));
        }

        void LoadTableComboBox()
        {
            var tables = tableBLL.GetTables();
            cbSwitchTable.DataSource = tables;
            cbSwitchTable.DisplayMember = "Name";
        }
        #endregion

        #region Event      
        private void btn_Click(object sender, EventArgs e)
        {
            // Lấy đối tượng Table từ Tag của nút
            Table table = (sender as Button).Tag as Table;
            // Kiểm tra nếu table không null
            lsvBill.Tag = (sender as Button).Tag;
            ShowBill(table.ID);
        }

        private void cbCategory_SelectedIndexChanged(object sender, EventArgs e)
        {
            int id = 0;

            ComboBox cb = sender as ComboBox;

            if (cb.SelectedItem == null)
                return;

            Category selected = cb.SelectedItem as Category;
            id = selected.ID;

            LoadFoodListByCategoryID(id);
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            Table table = lsvBill.Tag as Table;
            if (table == null)
            {
                MessageBox.Show("Xin vui lòng chọn bàn ăn trước.");
                return;
            }
            int idBill = tableBLL.GetUncheckBillIdByTable(table.ID);
            // Nếu chưa có hóa đơn thì tạo mới
            if (idBill == -1)
            {
                tableBLL.CreateBill(table.ID);
                idBill = tableBLL.GetMaxBillId();
            }
            // Thêm món ăn vào hóa đơn
            if (cbFoodAndDrinks.SelectedItem == null)
            {
                MessageBox.Show("Vui lòng chọn món ăn trước.");
                return;
            }
            // Lấy ID món ăn và số lượng từ các điều khiển
            if (!(cbFoodAndDrinks.SelectedItem is Food))
            {
                MessageBox.Show("Vui lòng chọn món ăn hợp lệ.");
                return;
            }
            // Thêm món ăn vào hóa đơn
            tableBLL.AddFoodToBill(idBill, (cbFoodAndDrinks.SelectedItem as Food).ID, (int)nmFoodCount.Value);



            // Nếu đã có hóa đơn thì thêm món vào hóa đơn đó
            int foodID = (cbFoodAndDrinks.SelectedItem as Food).ID;
            int count = (int)nmFoodCount.Value;
            
            ShowBill(table.ID);
            LoadTable();
        }

        private void btnPay_Click(object sender, EventArgs e)
        {
            Table table = lsvBill.Tag as Table;
            int idBill = tableBLL.GetUncheckBillIdByTable(table.ID);
            int discount;
            double totalPrice = double.Parse(txtTotalPrice.Text, NumberStyles.Currency, CultureInfo.GetCultureInfo("vi-VN"));
            double finalPrice;

            if (isDiscountApplied)
            {
                discount = appliedDiscount;
                finalPrice = totalPrice;
            }
            else
            {
                discount = (int)nmDiscount.Value;
                finalPrice = totalPrice - (totalPrice * discount / 100);
                txtTotalPrice.Text = finalPrice.ToString("c", System.Globalization.CultureInfo.GetCultureInfo("vi-VN"));
            }

            if (idBill != -1)
            {
                if (MessageBox.Show(
                    string.Format("Bạn có chắc muốn thanh toán & in hóa đơn cho bàn {0}?", table.Name),
                    "Thông báo", MessageBoxButtons.OKCancel) == DialogResult.OK)
                {
                   // xuất ra Excel
                 
                }
            }
        }        

        private void btnDiscount_Click(object sender, EventArgs e)
        {
            Table table = lsvBill.Tag as Table;
            int idBill = tableBLL.GetUncheckBillIdByTable(table.ID);
            if (idBill != -1)
            {
                int discount = (int)nmDiscount.Value;
                double totalPrice = double.Parse(txtTotalPrice.Text, NumberStyles.Currency, CultureInfo.GetCultureInfo("vi-VN"));
                double finalPrice = totalPrice - (totalPrice * discount / 100);
                txtTotalPrice.Text = finalPrice.ToString("c", System.Globalization.CultureInfo.GetCultureInfo("vi-VN"));
                MessageBox.Show(string.Format("Giảm giá {0}% cho bàn {1} thành công!", discount, table.Name));
                isDiscountApplied = true;
                appliedDiscount = discount;
            }
            else
            {
                MessageBox.Show("Bàn này chưa có hóa đơn để áp dụng giảm giá!");
            }
        }

        private void btnSwitchTable_Click(object sender, EventArgs e)
        {
            Table sourceTable = lsvBill.Tag as Table;
            Table targetTable = cbSwitchTable.SelectedItem as Table;
            if (sourceTable == null || targetTable == null || sourceTable.ID == targetTable.ID)
            {
                MessageBox.Show("Vui lòng chọn bàn hợp lệ để chuyển/gộp!");
                return;
            }

            int sourceBillId = tableBLL.GetUncheckBillIdByTable(sourceTable.ID);
            int targetBillId = tableBLL.GetUncheckBillIdByTable(targetTable.ID);

            if (targetTable.Status == "Trống")
            {
                if (sourceBillId == -1)
                {
                    MessageBox.Show("Bàn nguồn không có hóa đơn để chuyển!");
                    return;
                }
                tableBLL.SwitchTable(sourceBillId, targetTable.ID);
                tableBLL.UpdateTableStatus(sourceTable.ID, "Trống");
                tableBLL.UpdateTableStatus(targetTable.ID, "Có người");
                MessageBox.Show($"Chuyển hóa đơn sang bàn {targetTable.Name} thành công!");
            }
            else
            {
                if (sourceBillId == -1 || targetBillId == -1)
                {
                    MessageBox.Show("Cả hai bàn phải có hóa đơn để gộp!");
                    return;
                }
                tableBLL.MergeTable(sourceBillId, targetBillId);
                tableBLL.UpdateTableStatus(sourceTable.ID, "Trống");
                MessageBox.Show($"Gộp hóa đơn bàn {sourceTable.Name} vào bàn {targetTable.Name} thành công!");
            }

            LoadTable();
            LoadTableComboBox();
            ShowBill(targetTable.ID);
            lsvBill.Tag = targetTable;
        }
        #endregion
    }
}
