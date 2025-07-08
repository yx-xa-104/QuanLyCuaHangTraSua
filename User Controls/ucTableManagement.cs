using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using QuanLyCuaHangTraSua.DTO;
using QuanLyCuaHangTraSua.DAO;
using System.Globalization;
using QuanLyCuaHangTraSua.BLL;
using System.IO;
using iTextSharp.text.pdf;
using iTextSharp.text;
using OfficeOpenXml;
using DTO_Menu = QuanLyCuaHangTraSua.DTO.Menu;

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

        private void ExportBillToPdf(string tableName, List<DTO_Menu> billItems, int discount, double finalPrice, int invoiceId, string creatorName)
        {
            // Sử dụng SaveFileDialog để người dùng chọn vị trí lưu file PDF
            SaveFileDialog saveFileDialog = new SaveFileDialog
            {
                Filter = "PDF files (*.pdf)|*.pdf",
                FileName = $"HoaDon_{tableName}_{DateTime.Now:yyyyMMddHHmmss}.pdf"
            };

            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {             
                Document doc = new Document(PageSize.A5);
                BaseFont bf; // Khai báo BaseFont
                try
                {
                    // Tạo font Arial để hỗ trợ tiếng Việt
                    // Đảm bảo file arial.ttf tồn tại trên hệ thống
                    bf = BaseFont.CreateFont("c:\\windows\\fonts\\arial.ttf", BaseFont.IDENTITY_H, BaseFont.EMBEDDED);
                }
                catch (DocumentException)
                {
                    // Fallback nếu font Arial không tải được
                    bf = BaseFont.CreateFont(BaseFont.HELVETICA, BaseFont.CP1252, BaseFont.NOT_EMBEDDED);
                    MessageBox.Show("Không thể tải font Arial. Tiếng Việt có thể không hiển thị đúng.", "Lỗi Font", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                catch (IOException)
                {
                    // Fallback nếu file font không tìm thấy
                    bf = BaseFont.CreateFont(BaseFont.HELVETICA, BaseFont.CP1252, BaseFont.NOT_EMBEDDED);
                    MessageBox.Show("Không tìm thấy font Arial. Tiếng Việt có thể không hiển thị đúng.", "Lỗi Font", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }

                // Định nghĩa các font sử dụng trong PDF
                iTextSharp.text.Font titleFont = new iTextSharp.text.Font(bf, 18, iTextSharp.text.Font.BOLD);
                iTextSharp.text.Font normalFont = new iTextSharp.text.Font(bf, 12, iTextSharp.text.Font.NORMAL);
                iTextSharp.text.Font boldFont = new iTextSharp.text.Font(bf, 13, iTextSharp.text.Font.BOLD);
                iTextSharp.text.Font itemFontBlue = new iTextSharp.text.Font(bf, 12, iTextSharp.text.Font.NORMAL, BaseColor.BLUE);
                iTextSharp.text.Font itemFontGreen = new iTextSharp.text.Font(bf, 12, iTextSharp.text.Font.NORMAL, BaseColor.GREEN);
                iTextSharp.text.Font itemFontRed = new iTextSharp.text.Font(bf, 12, iTextSharp.text.Font.NORMAL, BaseColor.RED);
                iTextSharp.text.Font totalSummaryFont = new iTextSharp.text.Font(bf, 15, iTextSharp.text.Font.BOLD);


                try
                {
                    PdfWriter.GetInstance(doc, new FileStream(saveFileDialog.FileName, FileMode.Create));
                    doc.Open();

                    // Thêm tiêu đề và thông tin hóa đơn
                    Paragraph title = new Paragraph($"HÓA ĐƠN THANH TOÁN - {tableName}", titleFont);
                    title.Alignment = Element.ALIGN_CENTER;
                    doc.Add(title);
                    doc.Add(new Paragraph($"Mã hóa đơn: {invoiceId}", normalFont));
                    doc.Add(new Paragraph($"Người tạo hóa đơn: {creatorName}", normalFont)); 
                    doc.Add(new Paragraph("Ngày: " + DateTime.Now.ToString("dd/MM/yyyy HH:mm:ss"), normalFont));
                    doc.Add(Chunk.NEWLINE);

                    // Tạo bảng cho danh sách món ăn
                    PdfPTable table = new PdfPTable(4); // 4 cột: Tên món, Số lượng, Đơn giá, Thành tiền
                    table.WidthPercentage = 100;
                    table.SetWidths(new float[] { 3f, 1f, 1.5f, 1.5f });

                    // Thêm tiêu đề cột
                    PdfPCell headerCell;
                    headerCell = new PdfPCell(new Phrase("Tên món", boldFont));
                    headerCell.HorizontalAlignment = Element.ALIGN_CENTER;
                    headerCell.BackgroundColor = BaseColor.LIGHT_GRAY;
                    table.AddCell(headerCell);

                    headerCell = new PdfPCell(new Phrase("Số lượng", boldFont));
                    headerCell.HorizontalAlignment = Element.ALIGN_CENTER;
                    headerCell.BackgroundColor = BaseColor.LIGHT_GRAY;
                    table.AddCell(headerCell);

                    headerCell = new PdfPCell(new Phrase("Đơn giá", boldFont));
                    headerCell.HorizontalAlignment = Element.ALIGN_CENTER;
                    headerCell.BackgroundColor = BaseColor.LIGHT_GRAY;
                    table.AddCell(headerCell);

                    headerCell = new PdfPCell(new Phrase("Thành tiền", boldFont));
                    headerCell.HorizontalAlignment = Element.ALIGN_CENTER;
                    headerCell.BackgroundColor = BaseColor.LIGHT_GRAY;
                    table.AddCell(headerCell);

                    // Thêm dữ liệu từ List<DTO_Menu>
                    foreach (var item in billItems)
                    {
                        table.AddCell(new Phrase(item.FoodName, normalFont));
                        table.AddCell(new Phrase(item.Count.ToString(), itemFontBlue));
                        table.AddCell(new Phrase(item.Price.ToString("N0", new CultureInfo("vi-VN")), itemFontGreen));
                        table.AddCell(new Phrase(item.TotalPrice.ToString("N0", new CultureInfo("vi-VN")), itemFontRed));
                    }
                    doc.Add(table);
                    doc.Add(Chunk.NEWLINE);

                    // Thêm mục giảm giá
                    Paragraph discountParagraph = new Paragraph($"Giảm giá: {discount}%", normalFont);
                    discountParagraph.Alignment = Element.ALIGN_RIGHT;
                    doc.Add(discountParagraph);

                    // Thêm tổng tiền cuối cùng
                    Paragraph finalTotalParagraph = new Paragraph($"Tổng tiền phải trả: {finalPrice.ToString("c", new CultureInfo("vi-VN"))}", totalSummaryFont);
                    finalTotalParagraph.Alignment = Element.ALIGN_RIGHT;
                    doc.Add(finalTotalParagraph);
                    doc.Add(Chunk.NEWLINE);


                    MessageBox.Show("Hóa đơn đã được lưu tại:\n" + saveFileDialog.FileName, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi khi xuất PDF: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                finally
                {
                    doc.Close();
                }
            }
        }
        private void ExportToExcel(List<DTO_Menu> billItems, string tableName, int discount, double finalPrice, int invoiceId, string creatorName)
        {
            // Sử dụng SaveFileDialog để người dùng chọn vị trí lưu file Excel
            SaveFileDialog saveFileDialog = new SaveFileDialog
            {
                Filter = "Excel files (*.xlsx)|*.xlsx",
                FileName = $"HoaDon_Excel_{tableName}_{DateTime.Now:yyyyMMddHHmmss}.xlsx"
            };

            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                ExcelPackage.License.SetNonCommercialOrganization("Quan Ly Cua Hang Tra Sua");

                using (ExcelPackage excelPackage = new ExcelPackage())
                {
                    ExcelWorksheet worksheet = excelPackage.Workbook.Worksheets.Add("HoaDon");

                    // Thêm tiêu đề và thông tin hóa đơn
                    worksheet.Cells[1, 1].Value = "HÓA ĐƠN THANH TOÁN";
                    worksheet.Cells[2, 1].Value = $"Bàn: {tableName}";
                    worksheet.Cells[3, 1].Value = $"Mã hóa đơn: {invoiceId}";
                    worksheet.Cells[4, 1].Value = $"Người tạo hóa đơn: {creatorName}";
                    worksheet.Cells[5, 1].Value = $"Ngày: {DateTime.Now:dd/MM/yyyy HH:mm:ss}";

                    // Bắt đầu dữ liệu món ăn từ dòng 7
                    int dataStartRow = 7;

                    // Thêm tiêu đề cột
                    worksheet.Cells[dataStartRow - 1, 1].Value = "Tên món";
                    worksheet.Cells[dataStartRow - 1, 2].Value = "Số lượng";
                    worksheet.Cells[dataStartRow - 1, 3].Value = "Đơn giá";
                    worksheet.Cells[dataStartRow - 1, 4].Value = "Thành tiền";

                    // Thêm dữ liệu từ List<DTO_Menu>
                    for (int i = 0; i < billItems.Count; i++)
                    {
                        worksheet.Cells[i + dataStartRow, 1].Value = billItems[i].FoodName;
                        worksheet.Cells[i + dataStartRow, 2].Value = billItems[i].Count;
                        worksheet.Cells[i + dataStartRow, 3].Value = billItems[i].Price;
                        worksheet.Cells[i + dataStartRow, 4].Value = billItems[i].TotalPrice;
                    }

                    // Thêm mục giảm giá và tổng tiền cuối cùng
                    int nextRow = billItems.Count + dataStartRow + 1; // Dòng tiếp theo sau dữ liệu món ăn và một dòng trống

                    worksheet.Cells[nextRow, 3].Value = "Giảm giá:";
                    worksheet.Cells[nextRow, 4].Value = $"{discount}%";

                    nextRow++; // Chuyển xuống dòng tiếp theo
                    worksheet.Cells[nextRow, 3].Value = "Tổng tiền phải trả:";
                    worksheet.Cells[nextRow, 4].Value = finalPrice.ToString("N0", new CultureInfo("vi-VN"));

                    worksheet.Cells.AutoFitColumns();

                    FileInfo excelFile = new FileInfo(saveFileDialog.FileName);
                    excelPackage.SaveAs(excelFile);

                    MessageBox.Show("Dữ liệu đã được xuất ra Excel tại:\n" + saveFileDialog.FileName, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }

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
            if (table == null)
            {
                MessageBox.Show("Vui lòng chọn bàn trước khi thanh toán.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            int idBill = tableBLL.GetUncheckBillIdByTable(table.ID);
            if (idBill == -1)
            {
                MessageBox.Show("Bàn này chưa có hóa đơn để thanh toán.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Lấy tên người xuất hóa đơn từ tài khoản đang đăng nhập
            string creatorName = SessionManager.CurrentAccount != null ? SessionManager.CurrentAccount.DisplayName : "N/A";
            // Lấy danh sách món ăn HIỆN TẠI của hóa đơn TRƯỚC KHI thanh toán
            List<DTO_Menu> currentBillItems = tableBLL.GetMenuByTable(table.ID);

            double totalPrice;
            if (!double.TryParse(txtTotalPrice.Text.Trim().Replace("₫", "").Replace(".", ""), NumberStyles.Any, CultureInfo.GetCultureInfo("vi-VN"), out totalPrice))
            {
                MessageBox.Show("Giá trị tổng tiền không hợp lệ. Vui lòng kiểm tra lại.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            double finalPrice;
            int discount;

            if (isDiscountApplied)
            {
                discount = appliedDiscount;
                finalPrice = totalPrice;
            }
            else
            {
                discount = (int)nmDiscount.Value;
                finalPrice = totalPrice - (totalPrice * discount / 100);
                txtTotalPrice.Text = finalPrice.ToString("c", CultureInfo.GetCultureInfo("vi-VN"));
            }

            if (MessageBox.Show(
                string.Format("Bạn có chắc muốn thanh toán & in hóa đơn cho bàn {0}?\nTổng tiền: {1}", table.Name, txtTotalPrice.Text),
                "Thông báo", MessageBoxButtons.OKCancel) == DialogResult.OK)
            {
                try
                {
                    ExportBillToPdf(table.Name, currentBillItems, discount, finalPrice, idBill, creatorName); 
                    ExportToExcel(currentBillItems, table.Name, discount, finalPrice, idBill, creatorName); 


                    tableBLL.CheckOut(idBill, discount, finalPrice);
                    tableBLL.UpdateTableStatus(table.ID, "Trống");
                    ShowBill(table.ID); // Hàm này sẽ làm trống ListView sau khi thanh toán
                    LoadTable();

                    MessageBox.Show("Thanh toán thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Đã xảy ra lỗi trong quá trình thanh toán: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
