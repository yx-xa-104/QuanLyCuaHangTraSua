namespace QuanLyCuaHangTraSua
{
    partial class fMain
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.Panel pnlMain;
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

        #region Windows Form Designer generated code
        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(fMain));
            this.timerMenu = new System.Windows.Forms.Timer(this.components);
            this.pnlTop = new System.Windows.Forms.Panel();
            this.lblTitle = new System.Windows.Forms.Label();
            this.pnlTopMenu = new System.Windows.Forms.Panel();
            this.lblDisplayName = new System.Windows.Forms.Label();
            this.pbToggleMenu = new System.Windows.Forms.PictureBox();
            this.pnlTableManagement = new System.Windows.Forms.Panel();
            this.btnTableManagement = new System.Windows.Forms.Button();
            this.pnlMenu = new System.Windows.Forms.Panel();
            this.pnlRevenue = new System.Windows.Forms.Panel();
            this.btnRevenue = new System.Windows.Forms.Button();
            this.pnlAccountManagement = new System.Windows.Forms.Panel();
            this.btnAccountManager = new System.Windows.Forms.Button();
            this.pnlCategory = new System.Windows.Forms.Panel();
            this.btnCategory = new System.Windows.Forms.Button();
            this.pbSetting = new System.Windows.Forms.PictureBox();
            this.pnlTable = new System.Windows.Forms.Panel();
            this.btnTable = new System.Windows.Forms.Button();
            this.pnlFoodAndDrinks = new System.Windows.Forms.Panel();
            this.btnFoodAndDninks = new System.Windows.Forms.Button();
            this.pnlMain = new System.Windows.Forms.Panel();
            this.pnlTop.SuspendLayout();
            this.pnlTopMenu.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbToggleMenu)).BeginInit();
            this.pnlTableManagement.SuspendLayout();
            this.pnlMenu.SuspendLayout();
            this.pnlRevenue.SuspendLayout();
            this.pnlAccountManagement.SuspendLayout();
            this.pnlCategory.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbSetting)).BeginInit();
            this.pnlTable.SuspendLayout();
            this.pnlFoodAndDrinks.SuspendLayout();
            this.SuspendLayout();
            // 
            // timerMenu
            // 
            this.timerMenu.Interval = 10;
            this.timerMenu.Tick += new System.EventHandler(this.timerMenu_Tick);
            // 
            // pnlTop
            // 
            this.pnlTop.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(234)))), ((int)(((byte)(244)))), ((int)(((byte)(237)))));
            this.pnlTop.Controls.Add(this.lblTitle);
            this.pnlTop.Controls.Add(this.pnlTopMenu);
            this.pnlTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlTop.Location = new System.Drawing.Point(0, 0);
            this.pnlTop.Name = "pnlTop";
            this.pnlTop.Size = new System.Drawing.Size(1280, 74);
            this.pnlTop.TabIndex = 1;
            // 
            // lblTitle
            // 
            this.lblTitle.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.lblTitle.AutoSize = true;
            this.lblTitle.BackColor = System.Drawing.Color.Transparent;
            this.lblTitle.Font = new System.Drawing.Font("Segoe UI", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTitle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(42)))), ((int)(((byte)(63)))), ((int)(((byte)(48)))));
            this.lblTitle.Location = new System.Drawing.Point(633, 21);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(64, 32);
            this.lblTitle.TabIndex = 1;
            this.lblTitle.Text = "Title";
            this.lblTitle.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // pnlTopMenu
            // 
            this.pnlTopMenu.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(106)))), ((int)(((byte)(156)))), ((int)(((byte)(116)))));
            this.pnlTopMenu.Controls.Add(this.lblDisplayName);
            this.pnlTopMenu.Controls.Add(this.pbToggleMenu);
            this.pnlTopMenu.Location = new System.Drawing.Point(1, 0);
            this.pnlTopMenu.Margin = new System.Windows.Forms.Padding(0);
            this.pnlTopMenu.Name = "pnlTopMenu";
            this.pnlTopMenu.Size = new System.Drawing.Size(239, 73);
            this.pnlTopMenu.TabIndex = 0;
            // 
            // lblDisplayName
            // 
            this.lblDisplayName.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.lblDisplayName.AutoSize = true;
            this.lblDisplayName.BackColor = System.Drawing.Color.Transparent;
            this.lblDisplayName.Font = new System.Drawing.Font("Segoe UI", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDisplayName.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(42)))), ((int)(((byte)(63)))), ((int)(((byte)(48)))));
            this.lblDisplayName.Location = new System.Drawing.Point(71, 21);
            this.lblDisplayName.Name = "lblDisplayName";
            this.lblDisplayName.Size = new System.Drawing.Size(165, 32);
            this.lblDisplayName.TabIndex = 2;
            this.lblDisplayName.Text = "DisplayName";
            this.lblDisplayName.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // pbToggleMenu
            // 
            this.pbToggleMenu.BackColor = System.Drawing.Color.Transparent;
            this.pbToggleMenu.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("pbToggleMenu.BackgroundImage")));
            this.pbToggleMenu.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pbToggleMenu.Location = new System.Drawing.Point(11, 12);
            this.pbToggleMenu.Name = "pbToggleMenu";
            this.pbToggleMenu.Size = new System.Drawing.Size(46, 46);
            this.pbToggleMenu.TabIndex = 0;
            this.pbToggleMenu.TabStop = false;
            this.pbToggleMenu.Click += new System.EventHandler(this.pbToggleMenu_Click);
            // 
            // pnlTableManagement
            // 
            this.pnlTableManagement.BackColor = System.Drawing.Color.Transparent;
            this.pnlTableManagement.Controls.Add(this.btnTableManagement);
            this.pnlTableManagement.Location = new System.Drawing.Point(1, 0);
            this.pnlTableManagement.Margin = new System.Windows.Forms.Padding(0);
            this.pnlTableManagement.Name = "pnlTableManagement";
            this.pnlTableManagement.Size = new System.Drawing.Size(239, 73);
            this.pnlTableManagement.TabIndex = 1;
            // 
            // btnTableManagement
            // 
            this.btnTableManagement.BackColor = System.Drawing.Color.Transparent;
            this.btnTableManagement.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnTableManagement.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(106)))), ((int)(((byte)(156)))), ((int)(((byte)(116)))));
            this.btnTableManagement.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(106)))), ((int)(((byte)(156)))), ((int)(((byte)(116)))));
            this.btnTableManagement.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnTableManagement.Font = new System.Drawing.Font("Segoe UI Semibold", 16F, System.Drawing.FontStyle.Bold);
            this.btnTableManagement.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(42)))), ((int)(((byte)(63)))), ((int)(((byte)(48)))));
            this.btnTableManagement.Image = ((System.Drawing.Image)(resources.GetObject("btnTableManagement.Image")));
            this.btnTableManagement.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnTableManagement.Location = new System.Drawing.Point(-10, -10);
            this.btnTableManagement.Name = "btnTableManagement";
            this.btnTableManagement.Padding = new System.Windows.Forms.Padding(16, 0, 0, 0);
            this.btnTableManagement.Size = new System.Drawing.Size(258, 93);
            this.btnTableManagement.TabIndex = 0;
            this.btnTableManagement.Text = "    Quản lý bàn";
            this.btnTableManagement.UseVisualStyleBackColor = false;
            this.btnTableManagement.Click += new System.EventHandler(this.btnTableManagement_Click);
            // 
            // pnlMenu
            // 
            this.pnlMenu.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(234)))), ((int)(((byte)(244)))), ((int)(((byte)(237)))));
            this.pnlMenu.Controls.Add(this.pnlRevenue);
            this.pnlMenu.Controls.Add(this.pnlAccountManagement);
            this.pnlMenu.Controls.Add(this.pnlTableManagement);
            this.pnlMenu.Controls.Add(this.pnlCategory);
            this.pnlMenu.Controls.Add(this.pbSetting);
            this.pnlMenu.Controls.Add(this.pnlTable);
            this.pnlMenu.Controls.Add(this.pnlFoodAndDrinks);
            this.pnlMenu.Dock = System.Windows.Forms.DockStyle.Left;
            this.pnlMenu.Location = new System.Drawing.Point(0, 74);
            this.pnlMenu.Name = "pnlMenu";
            this.pnlMenu.Size = new System.Drawing.Size(240, 654);
            this.pnlMenu.TabIndex = 0;
            // 
            // pnlRevenue
            // 
            this.pnlRevenue.BackColor = System.Drawing.Color.Transparent;
            this.pnlRevenue.Controls.Add(this.btnRevenue);
            this.pnlRevenue.Location = new System.Drawing.Point(1, 219);
            this.pnlRevenue.Margin = new System.Windows.Forms.Padding(0);
            this.pnlRevenue.Name = "pnlRevenue";
            this.pnlRevenue.Size = new System.Drawing.Size(239, 73);
            this.pnlRevenue.TabIndex = 2;
            // 
            // btnRevenue
            // 
            this.btnRevenue.BackColor = System.Drawing.Color.Transparent;
            this.btnRevenue.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(106)))), ((int)(((byte)(156)))), ((int)(((byte)(116)))));
            this.btnRevenue.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(106)))), ((int)(((byte)(156)))), ((int)(((byte)(116)))));
            this.btnRevenue.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnRevenue.Font = new System.Drawing.Font("Segoe UI Semibold", 16F, System.Drawing.FontStyle.Bold);
            this.btnRevenue.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(42)))), ((int)(((byte)(63)))), ((int)(((byte)(48)))));
            this.btnRevenue.Image = global::QuanLyCuaHangTraSua.Properties.Resources.Revenue;
            this.btnRevenue.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnRevenue.Location = new System.Drawing.Point(-10, -10);
            this.btnRevenue.Name = "btnRevenue";
            this.btnRevenue.Padding = new System.Windows.Forms.Padding(16, 0, 0, 0);
            this.btnRevenue.Size = new System.Drawing.Size(258, 93);
            this.btnRevenue.TabIndex = 0;
            this.btnRevenue.Text = "  Doanh thu";
            this.btnRevenue.UseVisualStyleBackColor = false;
            this.btnRevenue.Click += new System.EventHandler(this.btnRevenue_Click);
            // 
            // pnlAccountManagement
            // 
            this.pnlAccountManagement.BackColor = System.Drawing.Color.Transparent;
            this.pnlAccountManagement.Controls.Add(this.btnAccountManager);
            this.pnlAccountManagement.Location = new System.Drawing.Point(1, 365);
            this.pnlAccountManagement.Margin = new System.Windows.Forms.Padding(0);
            this.pnlAccountManagement.Name = "pnlAccountManagement";
            this.pnlAccountManagement.Size = new System.Drawing.Size(239, 73);
            this.pnlAccountManagement.TabIndex = 3;
            // 
            // btnAccountManager
            // 
            this.btnAccountManager.BackColor = System.Drawing.Color.Transparent;
            this.btnAccountManager.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(106)))), ((int)(((byte)(156)))), ((int)(((byte)(116)))));
            this.btnAccountManager.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(106)))), ((int)(((byte)(156)))), ((int)(((byte)(116)))));
            this.btnAccountManager.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAccountManager.Font = new System.Drawing.Font("Segoe UI Semibold", 16F, System.Drawing.FontStyle.Bold);
            this.btnAccountManager.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(42)))), ((int)(((byte)(63)))), ((int)(((byte)(48)))));
            this.btnAccountManager.Image = global::QuanLyCuaHangTraSua.Properties.Resources.Account_;
            this.btnAccountManager.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnAccountManager.Location = new System.Drawing.Point(-10, -10);
            this.btnAccountManager.Name = "btnAccountManager";
            this.btnAccountManager.Padding = new System.Windows.Forms.Padding(16, 0, 0, 0);
            this.btnAccountManager.Size = new System.Drawing.Size(258, 93);
            this.btnAccountManager.TabIndex = 0;
            this.btnAccountManager.Text = "          Quản lý \r\n          tài khoản";
            this.btnAccountManager.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnAccountManager.UseMnemonic = false;
            this.btnAccountManager.UseVisualStyleBackColor = false;
            this.btnAccountManager.Click += new System.EventHandler(this.btnAccountManager_Click);
            // 
            // pnlCategory
            // 
            this.pnlCategory.BackColor = System.Drawing.Color.Transparent;
            this.pnlCategory.Controls.Add(this.btnCategory);
            this.pnlCategory.Location = new System.Drawing.Point(1, 292);
            this.pnlCategory.Margin = new System.Windows.Forms.Padding(0);
            this.pnlCategory.Name = "pnlCategory";
            this.pnlCategory.Size = new System.Drawing.Size(239, 73);
            this.pnlCategory.TabIndex = 2;
            // 
            // btnCategory
            // 
            this.btnCategory.BackColor = System.Drawing.Color.Transparent;
            this.btnCategory.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(106)))), ((int)(((byte)(156)))), ((int)(((byte)(116)))));
            this.btnCategory.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(106)))), ((int)(((byte)(156)))), ((int)(((byte)(116)))));
            this.btnCategory.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCategory.Font = new System.Drawing.Font("Segoe UI Semibold", 16F, System.Drawing.FontStyle.Bold);
            this.btnCategory.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(42)))), ((int)(((byte)(63)))), ((int)(((byte)(48)))));
            this.btnCategory.Image = global::QuanLyCuaHangTraSua.Properties.Resources.Category;
            this.btnCategory.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnCategory.Location = new System.Drawing.Point(-10, -10);
            this.btnCategory.Name = "btnCategory";
            this.btnCategory.Padding = new System.Windows.Forms.Padding(16, 0, 0, 0);
            this.btnCategory.Size = new System.Drawing.Size(258, 93);
            this.btnCategory.TabIndex = 0;
            this.btnCategory.Text = "Danh mục";
            this.btnCategory.UseVisualStyleBackColor = false;
            this.btnCategory.Click += new System.EventHandler(this.btnCategory_Click);
            // 
            // pbSetting
            // 
            this.pbSetting.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.pbSetting.BackColor = System.Drawing.Color.Transparent;
            this.pbSetting.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("pbSetting.BackgroundImage")));
            this.pbSetting.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pbSetting.Location = new System.Drawing.Point(12, 596);
            this.pbSetting.Name = "pbSetting";
            this.pbSetting.Size = new System.Drawing.Size(46, 46);
            this.pbSetting.TabIndex = 13;
            this.pbSetting.TabStop = false;
            this.pbSetting.Click += new System.EventHandler(this.pbSetting_Click);
            // 
            // pnlTable
            // 
            this.pnlTable.BackColor = System.Drawing.Color.Transparent;
            this.pnlTable.Controls.Add(this.btnTable);
            this.pnlTable.Location = new System.Drawing.Point(1, 73);
            this.pnlTable.Margin = new System.Windows.Forms.Padding(0);
            this.pnlTable.Name = "pnlTable";
            this.pnlTable.Size = new System.Drawing.Size(239, 73);
            this.pnlTable.TabIndex = 2;
            // 
            // btnTable
            // 
            this.btnTable.BackColor = System.Drawing.Color.Transparent;
            this.btnTable.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(106)))), ((int)(((byte)(156)))), ((int)(((byte)(116)))));
            this.btnTable.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(106)))), ((int)(((byte)(156)))), ((int)(((byte)(116)))));
            this.btnTable.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnTable.Font = new System.Drawing.Font("Segoe UI Semibold", 16F, System.Drawing.FontStyle.Bold);
            this.btnTable.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(42)))), ((int)(((byte)(63)))), ((int)(((byte)(48)))));
            this.btnTable.Image = global::QuanLyCuaHangTraSua.Properties.Resources.Food_Table;
            this.btnTable.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnTable.Location = new System.Drawing.Point(-9, -12);
            this.btnTable.Name = "btnTable";
            this.btnTable.Padding = new System.Windows.Forms.Padding(16, 0, 0, 0);
            this.btnTable.Size = new System.Drawing.Size(258, 101);
            this.btnTable.TabIndex = 0;
            this.btnTable.Text = "          Bàn ăn";
            this.btnTable.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnTable.UseVisualStyleBackColor = false;
            this.btnTable.Click += new System.EventHandler(this.btnTable_Click);
            // 
            // pnlFoodAndDrinks
            // 
            this.pnlFoodAndDrinks.BackColor = System.Drawing.Color.Transparent;
            this.pnlFoodAndDrinks.Controls.Add(this.btnFoodAndDninks);
            this.pnlFoodAndDrinks.Location = new System.Drawing.Point(1, 146);
            this.pnlFoodAndDrinks.Margin = new System.Windows.Forms.Padding(0);
            this.pnlFoodAndDrinks.Name = "pnlFoodAndDrinks";
            this.pnlFoodAndDrinks.Size = new System.Drawing.Size(239, 73);
            this.pnlFoodAndDrinks.TabIndex = 2;
            // 
            // btnFoodAndDninks
            // 
            this.btnFoodAndDninks.BackColor = System.Drawing.Color.Transparent;
            this.btnFoodAndDninks.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(106)))), ((int)(((byte)(156)))), ((int)(((byte)(116)))));
            this.btnFoodAndDninks.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(106)))), ((int)(((byte)(156)))), ((int)(((byte)(116)))));
            this.btnFoodAndDninks.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnFoodAndDninks.Font = new System.Drawing.Font("Segoe UI Semibold", 16F, System.Drawing.FontStyle.Bold);
            this.btnFoodAndDninks.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(42)))), ((int)(((byte)(63)))), ((int)(((byte)(48)))));
            this.btnFoodAndDninks.Image = global::QuanLyCuaHangTraSua.Properties.Resources.Food;
            this.btnFoodAndDninks.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnFoodAndDninks.Location = new System.Drawing.Point(-10, -10);
            this.btnFoodAndDninks.Name = "btnFoodAndDninks";
            this.btnFoodAndDninks.Padding = new System.Windows.Forms.Padding(16, 0, 0, 0);
            this.btnFoodAndDninks.Size = new System.Drawing.Size(258, 93);
            this.btnFoodAndDninks.TabIndex = 0;
            this.btnFoodAndDninks.Text = "          Đồ uống";
            this.btnFoodAndDninks.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnFoodAndDninks.UseVisualStyleBackColor = false;
            this.btnFoodAndDninks.Click += new System.EventHandler(this.btnFoodAndDninks_Click);
            // 
            // pnlMain
            // 
            pnlMain.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(248)))), ((int)(((byte)(251)))), ((int)(((byte)(247)))));
            pnlMain.Dock = System.Windows.Forms.DockStyle.Fill;
            pnlMain.Location = new System.Drawing.Point(240, 74);
            pnlMain.Name = "pnlMain";
            pnlMain.Size = new System.Drawing.Size(1040, 654);
            pnlMain.TabIndex = 2;
            // 
            // fMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(1280, 728);
            this.Controls.Add(pnlMain);
            this.Controls.Add(this.pnlMenu);
            this.Controls.Add(this.pnlTop);
            this.DoubleBuffered = true;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.IsMdiContainer = true;
            this.Name = "fMain";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Quản lý của hàng đồ ăn nhanh";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.fMain_FormClosing);
            this.pnlTop.ResumeLayout(false);
            this.pnlTop.PerformLayout();
            this.pnlTopMenu.ResumeLayout(false);
            this.pnlTopMenu.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbToggleMenu)).EndInit();
            this.pnlTableManagement.ResumeLayout(false);
            this.pnlMenu.ResumeLayout(false);
            this.pnlRevenue.ResumeLayout(false);
            this.pnlAccountManagement.ResumeLayout(false);
            this.pnlCategory.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pbSetting)).EndInit();
            this.pnlTable.ResumeLayout(false);
            this.pnlFoodAndDrinks.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Panel pnlTop;
        private System.Windows.Forms.Timer timerMenu;
        private System.Windows.Forms.PictureBox pbToggleMenu;
        private System.Windows.Forms.Panel pnlTopMenu;
        private System.Windows.Forms.Panel pnlMenu;
        private System.Windows.Forms.Panel pnlTableManagement;
        private System.Windows.Forms.Panel pnlTable;
        private System.Windows.Forms.Button btnTable;
        private System.Windows.Forms.Panel pnlFoodAndDrinks;
        private System.Windows.Forms.Button btnFoodAndDninks;
        private System.Windows.Forms.Panel pnlRevenue;
        private System.Windows.Forms.Button btnRevenue;
        private System.Windows.Forms.Button btnTableManagement;
        private System.Windows.Forms.Panel pnlAccountManagement;
        private System.Windows.Forms.Button btnAccountManager;
        private System.Windows.Forms.Panel pnlCategory;
        private System.Windows.Forms.Button btnCategory;
        private System.Windows.Forms.PictureBox pbSetting;
        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.Label lblDisplayName;
    }
}