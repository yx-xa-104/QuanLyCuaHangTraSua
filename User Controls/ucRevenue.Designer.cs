namespace QuanLyCuaHangTraSua.UserControls
{
    partial class ucRevenue
    {
        /// <summary> 
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ucRevenue));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea1 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend1 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series1 = new System.Windows.Forms.DataVisualization.Charting.Series();
            this.lblTotalMoney = new System.Windows.Forms.Label();
            this.lblTotalMoneyTitle = new System.Windows.Forms.Label();
            this.pnlTop = new System.Windows.Forms.Panel();
            this.dtpCheckIn = new System.Windows.Forms.DateTimePicker();
            this.btnView = new System.Windows.Forms.Button();
            this.dtpCheckOut = new System.Windows.Forms.DateTimePicker();
            this.dgvRevenue = new System.Windows.Forms.DataGridView();
            this.pnlChildForm = new System.Windows.Forms.Panel();
            this.pnlStatistical = new System.Windows.Forms.Panel();
            this.pnlChartBottom = new System.Windows.Forms.Panel();
            this.pnlChart = new System.Windows.Forms.Panel();
            this.chart2 = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.pnlContent = new System.Windows.Forms.Panel();
            this.pnlTotalMoney = new System.Windows.Forms.Panel();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.pnlBill = new System.Windows.Forms.Panel();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.lblTotalInvoice = new System.Windows.Forms.Label();
            this.lblTotalInvoiceTitle = new System.Windows.Forms.Label();
            this.pnlDgv = new System.Windows.Forms.Panel();
            this.pnlBot = new System.Windows.Forms.Panel();
            this.pnlTop.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvRevenue)).BeginInit();
            this.pnlChildForm.SuspendLayout();
            this.pnlStatistical.SuspendLayout();
            this.pnlChartBottom.SuspendLayout();
            this.pnlChart.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chart2)).BeginInit();
            this.pnlContent.SuspendLayout();
            this.pnlTotalMoney.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.pnlBill.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            this.pnlDgv.SuspendLayout();
            this.pnlBot.SuspendLayout();
            this.SuspendLayout();
            // 
            // lblTotalMoney
            // 
            this.lblTotalMoney.AutoSize = true;
            this.lblTotalMoney.Font = new System.Drawing.Font("Segoe UI", 15F, System.Drawing.FontStyle.Bold);
            this.lblTotalMoney.ForeColor = System.Drawing.Color.Black;
            this.lblTotalMoney.Location = new System.Drawing.Point(13, 54);
            this.lblTotalMoney.Name = "lblTotalMoney";
            this.lblTotalMoney.Size = new System.Drawing.Size(163, 28);
            this.lblTotalMoney.TabIndex = 1;
            this.lblTotalMoney.Text = "Tổng doanh thu";
            // 
            // lblTotalMoneyTitle
            // 
            this.lblTotalMoneyTitle.AutoSize = true;
            this.lblTotalMoneyTitle.Font = new System.Drawing.Font("Segoe UI", 13F, System.Drawing.FontStyle.Bold);
            this.lblTotalMoneyTitle.ForeColor = System.Drawing.Color.Black;
            this.lblTotalMoneyTitle.Location = new System.Drawing.Point(13, 11);
            this.lblTotalMoneyTitle.Name = "lblTotalMoneyTitle";
            this.lblTotalMoneyTitle.Size = new System.Drawing.Size(102, 25);
            this.lblTotalMoneyTitle.TabIndex = 0;
            this.lblTotalMoneyTitle.Text = "Doanh thu";
            // 
            // pnlTop
            // 
            this.pnlTop.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(248)))), ((int)(((byte)(251)))), ((int)(((byte)(247)))));
            this.pnlTop.Controls.Add(this.dtpCheckIn);
            this.pnlTop.Controls.Add(this.dtpCheckOut);
            this.pnlTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlTop.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.pnlTop.Location = new System.Drawing.Point(0, 0);
            this.pnlTop.Margin = new System.Windows.Forms.Padding(2);
            this.pnlTop.Name = "pnlTop";
            this.pnlTop.Size = new System.Drawing.Size(1040, 55);
            this.pnlTop.TabIndex = 0;
            // 
            // dtpCheckIn
            // 
            this.dtpCheckIn.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.dtpCheckIn.CalendarFont = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtpCheckIn.CalendarMonthBackground = System.Drawing.SystemColors.InactiveBorder;
            this.dtpCheckIn.CalendarTrailingForeColor = System.Drawing.SystemColors.ButtonShadow;
            this.dtpCheckIn.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtpCheckIn.Location = new System.Drawing.Point(25, 22);
            this.dtpCheckIn.Margin = new System.Windows.Forms.Padding(2);
            this.dtpCheckIn.Name = "dtpCheckIn";
            this.dtpCheckIn.Size = new System.Drawing.Size(259, 29);
            this.dtpCheckIn.TabIndex = 4;
            // 
            // btnView
            // 
            this.btnView.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)));
            this.btnView.BackColor = System.Drawing.Color.Transparent;
            this.btnView.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(106)))), ((int)(((byte)(156)))), ((int)(((byte)(116)))));
            this.btnView.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(106)))), ((int)(((byte)(156)))), ((int)(((byte)(116)))));
            this.btnView.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(106)))), ((int)(((byte)(156)))), ((int)(((byte)(116)))));
            this.btnView.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnView.Font = new System.Drawing.Font("Segoe UI", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnView.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(42)))), ((int)(((byte)(63)))), ((int)(((byte)(48)))));
            this.btnView.Image = ((System.Drawing.Image)(resources.GetObject("btnView.Image")));
            this.btnView.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnView.Location = new System.Drawing.Point(455, 9);
            this.btnView.Name = "btnView";
            this.btnView.Padding = new System.Windows.Forms.Padding(8, 0, 0, 0);
            this.btnView.Size = new System.Drawing.Size(130, 68);
            this.btnView.TabIndex = 4;
            this.btnView.Text = "Xem";
            this.btnView.UseVisualStyleBackColor = false;
            this.btnView.Click += new System.EventHandler(this.btnView_Click);
            // 
            // dtpCheckOut
            // 
            this.dtpCheckOut.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.dtpCheckOut.CalendarFont = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtpCheckOut.CalendarMonthBackground = System.Drawing.SystemColors.InactiveBorder;
            this.dtpCheckOut.CalendarTrailingForeColor = System.Drawing.SystemColors.ButtonShadow;
            this.dtpCheckOut.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtpCheckOut.Location = new System.Drawing.Point(304, 21);
            this.dtpCheckOut.Margin = new System.Windows.Forms.Padding(2);
            this.dtpCheckOut.Name = "dtpCheckOut";
            this.dtpCheckOut.Size = new System.Drawing.Size(258, 29);
            this.dtpCheckOut.TabIndex = 3;
            // 
            // dgvRevenue
            // 
            this.dgvRevenue.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(234)))), ((int)(((byte)(244)))), ((int)(((byte)(237)))));
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.Color.LavenderBlush;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvRevenue.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvRevenue.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.LavenderBlush;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvRevenue.DefaultCellStyle = dataGridViewCellStyle2;
            this.dgvRevenue.Dock = System.Windows.Forms.DockStyle.Top;
            this.dgvRevenue.Location = new System.Drawing.Point(25, 0);
            this.dgvRevenue.Margin = new System.Windows.Forms.Padding(2);
            this.dgvRevenue.Name = "dgvRevenue";
            this.dgvRevenue.ReadOnly = true;
            this.dgvRevenue.RowTemplate.Height = 24;
            this.dgvRevenue.Size = new System.Drawing.Size(490, 507);
            this.dgvRevenue.TabIndex = 1;
            // 
            // pnlChildForm
            // 
            this.pnlChildForm.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(248)))), ((int)(((byte)(251)))), ((int)(((byte)(247)))));
            this.pnlChildForm.Controls.Add(this.pnlDgv);
            this.pnlChildForm.Controls.Add(this.pnlStatistical);
            this.pnlChildForm.Controls.Add(this.pnlTop);
            this.pnlChildForm.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlChildForm.Location = new System.Drawing.Point(0, 0);
            this.pnlChildForm.Margin = new System.Windows.Forms.Padding(2);
            this.pnlChildForm.Name = "pnlChildForm";
            this.pnlChildForm.Size = new System.Drawing.Size(1040, 654);
            this.pnlChildForm.TabIndex = 0;
            // 
            // pnlStatistical
            // 
            this.pnlStatistical.Controls.Add(this.pnlChartBottom);
            this.pnlStatistical.Dock = System.Windows.Forms.DockStyle.Right;
            this.pnlStatistical.Location = new System.Drawing.Point(515, 55);
            this.pnlStatistical.Name = "pnlStatistical";
            this.pnlStatistical.Size = new System.Drawing.Size(525, 599);
            this.pnlStatistical.TabIndex = 5;
            // 
            // pnlChartBottom
            // 
            this.pnlChartBottom.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(248)))), ((int)(((byte)(251)))), ((int)(((byte)(247)))));
            this.pnlChartBottom.Controls.Add(this.pnlChart);
            this.pnlChartBottom.Controls.Add(this.pnlContent);
            this.pnlChartBottom.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlChartBottom.Location = new System.Drawing.Point(0, 0);
            this.pnlChartBottom.Name = "pnlChartBottom";
            this.pnlChartBottom.Padding = new System.Windows.Forms.Padding(25, 0, 25, 25);
            this.pnlChartBottom.Size = new System.Drawing.Size(525, 599);
            this.pnlChartBottom.TabIndex = 1;
            // 
            // pnlChart
            // 
            this.pnlChart.Controls.Add(this.chart2);
            this.pnlChart.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlChart.Location = new System.Drawing.Point(25, 106);
            this.pnlChart.Name = "pnlChart";
            this.pnlChart.Size = new System.Drawing.Size(475, 381);
            this.pnlChart.TabIndex = 2;
            // 
            // chart2
            // 
            this.chart2.BackColor = System.Drawing.Color.Transparent;
            this.chart2.BorderlineColor = System.Drawing.Color.Transparent;
            chartArea1.Name = "ChartArea1";
            this.chart2.ChartAreas.Add(chartArea1);
            this.chart2.Dock = System.Windows.Forms.DockStyle.Top;
            legend1.Name = "Legend1";
            this.chart2.Legends.Add(legend1);
            this.chart2.Location = new System.Drawing.Point(0, 0);
            this.chart2.Name = "chart2";
            this.chart2.Palette = System.Windows.Forms.DataVisualization.Charting.ChartColorPalette.SeaGreen;
            series1.ChartArea = "ChartArea1";
            series1.Legend = "Legend1";
            series1.Name = "DoanhThu";
            this.chart2.Series.Add(series1);
            this.chart2.Size = new System.Drawing.Size(475, 401);
            this.chart2.TabIndex = 0;
            this.chart2.Text = "chart2";
            // 
            // pnlContent
            // 
            this.pnlContent.Controls.Add(this.pnlTotalMoney);
            this.pnlContent.Controls.Add(this.pnlBill);
            this.pnlContent.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlContent.Location = new System.Drawing.Point(25, 0);
            this.pnlContent.Name = "pnlContent";
            this.pnlContent.Size = new System.Drawing.Size(475, 106);
            this.pnlContent.TabIndex = 1;
            // 
            // pnlTotalMoney
            // 
            this.pnlTotalMoney.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pnlTotalMoney.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(106)))), ((int)(((byte)(156)))), ((int)(((byte)(116)))));
            this.pnlTotalMoney.Controls.Add(this.lblTotalMoney);
            this.pnlTotalMoney.Controls.Add(this.lblTotalMoneyTitle);
            this.pnlTotalMoney.Controls.Add(this.pictureBox1);
            this.pnlTotalMoney.Location = new System.Drawing.Point(248, 0);
            this.pnlTotalMoney.Name = "pnlTotalMoney";
            this.pnlTotalMoney.Size = new System.Drawing.Size(224, 104);
            this.pnlTotalMoney.TabIndex = 4;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::QuanLyCuaHangTraSua.Properties.Resources.money;
            this.pictureBox1.Location = new System.Drawing.Point(170, 11);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(36, 36);
            this.pictureBox1.TabIndex = 2;
            this.pictureBox1.TabStop = false;
            // 
            // pnlBill
            // 
            this.pnlBill.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pnlBill.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(188)))), ((int)(((byte)(198)))), ((int)(((byte)(192)))));
            this.pnlBill.Controls.Add(this.pictureBox2);
            this.pnlBill.Controls.Add(this.lblTotalInvoice);
            this.pnlBill.Controls.Add(this.lblTotalInvoiceTitle);
            this.pnlBill.Location = new System.Drawing.Point(0, 0);
            this.pnlBill.Name = "pnlBill";
            this.pnlBill.Size = new System.Drawing.Size(224, 104);
            this.pnlBill.TabIndex = 1;
            // 
            // pictureBox2
            // 
            this.pictureBox2.Image = global::QuanLyCuaHangTraSua.Properties.Resources.bill;
            this.pictureBox2.Location = new System.Drawing.Point(175, 11);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(36, 36);
            this.pictureBox2.TabIndex = 3;
            this.pictureBox2.TabStop = false;
            // 
            // lblTotalInvoice
            // 
            this.lblTotalInvoice.AutoSize = true;
            this.lblTotalInvoice.Font = new System.Drawing.Font("Segoe UI", 15F, System.Drawing.FontStyle.Bold);
            this.lblTotalInvoice.ForeColor = System.Drawing.Color.Black;
            this.lblTotalInvoice.Location = new System.Drawing.Point(14, 54);
            this.lblTotalInvoice.Name = "lblTotalInvoice";
            this.lblTotalInvoice.Size = new System.Drawing.Size(120, 28);
            this.lblTotalInvoice.TabIndex = 2;
            this.lblTotalInvoice.Text = "Số hoá đơn";
            // 
            // lblTotalInvoiceTitle
            // 
            this.lblTotalInvoiceTitle.AutoSize = true;
            this.lblTotalInvoiceTitle.Font = new System.Drawing.Font("Segoe UI", 13F, System.Drawing.FontStyle.Bold);
            this.lblTotalInvoiceTitle.ForeColor = System.Drawing.Color.Black;
            this.lblTotalInvoiceTitle.Location = new System.Drawing.Point(14, 11);
            this.lblTotalInvoiceTitle.Name = "lblTotalInvoiceTitle";
            this.lblTotalInvoiceTitle.Size = new System.Drawing.Size(155, 25);
            this.lblTotalInvoiceTitle.TabIndex = 1;
            this.lblTotalInvoiceTitle.Text = "Tổng sổ hoá đơn";
            // 
            // pnlDgv
            // 
            this.pnlDgv.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(248)))), ((int)(((byte)(251)))), ((int)(((byte)(247)))));
            this.pnlDgv.Controls.Add(this.dgvRevenue);
            this.pnlDgv.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlDgv.Location = new System.Drawing.Point(0, 55);
            this.pnlDgv.Name = "pnlDgv";
            this.pnlDgv.Padding = new System.Windows.Forms.Padding(25, 0, 0, 25);
            this.pnlDgv.Size = new System.Drawing.Size(515, 599);
            this.pnlDgv.TabIndex = 6;
            // 
            // pnlBot
            // 
            this.pnlBot.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(248)))), ((int)(((byte)(251)))), ((int)(((byte)(247)))));
            this.pnlBot.Controls.Add(this.btnView);
            this.pnlBot.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pnlBot.Location = new System.Drawing.Point(0, 567);
            this.pnlBot.Name = "pnlBot";
            this.pnlBot.Size = new System.Drawing.Size(1040, 87);
            this.pnlBot.TabIndex = 7;
            // 
            // ucRevenue
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.pnlBot);
            this.Controls.Add(this.pnlChildForm);
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "ucRevenue";
            this.Size = new System.Drawing.Size(1040, 654);
            this.pnlTop.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvRevenue)).EndInit();
            this.pnlChildForm.ResumeLayout(false);
            this.pnlStatistical.ResumeLayout(false);
            this.pnlChartBottom.ResumeLayout(false);
            this.pnlChart.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.chart2)).EndInit();
            this.pnlContent.ResumeLayout(false);
            this.pnlTotalMoney.ResumeLayout(false);
            this.pnlTotalMoney.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.pnlBill.ResumeLayout(false);
            this.pnlBill.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            this.pnlDgv.ResumeLayout(false);
            this.pnlBot.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Button btnView;
        private System.Windows.Forms.Panel pnlTop;
        private System.Windows.Forms.DateTimePicker dtpCheckIn;
        private System.Windows.Forms.DataGridView dgvRevenue;
        private System.Windows.Forms.DateTimePicker dtpCheckOut;
        private System.Windows.Forms.Panel pnlChildForm;
        private System.Windows.Forms.Panel pnlStatistical;
        private System.Windows.Forms.Panel pnlChartBottom;
        private System.Windows.Forms.Panel pnlChart;
        private System.Windows.Forms.DataVisualization.Charting.Chart chart2;
        private System.Windows.Forms.Panel pnlContent;
        private System.Windows.Forms.Panel pnlBill;
        private System.Windows.Forms.Label lblTotalInvoice;
        private System.Windows.Forms.Label lblTotalInvoiceTitle;
        private System.Windows.Forms.Label lblTotalMoney;
        private System.Windows.Forms.Label lblTotalMoneyTitle;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.Panel pnlTotalMoney;
        private System.Windows.Forms.Panel pnlDgv;
        private System.Windows.Forms.Panel pnlBot;
    }
}
