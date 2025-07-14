namespace QuanLyCuaHangTraSua.UserControls
{
    partial class ucSetting
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
            this.lblAccountDetail = new System.Windows.Forms.Label();
            this.lblChangePassword = new System.Windows.Forms.Label();
            this.btnSignOut = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.txtUserName = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.txtDisplayName = new System.Windows.Forms.TextBox();
            this.panel3 = new System.Windows.Forms.Panel();
            this.txtAccountType = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.panel4 = new System.Windows.Forms.Panel();
            this.btnToggleOldPassword = new System.Windows.Forms.Button();
            this.txtOldPassword = new System.Windows.Forms.TextBox();
            this.panel5 = new System.Windows.Forms.Panel();
            this.btnToggleNewPassword = new System.Windows.Forms.Button();
            this.txtNewPassword = new System.Windows.Forms.TextBox();
            this.panel6 = new System.Windows.Forms.Panel();
            this.btnToggleConfirmPassword = new System.Windows.Forms.Button();
            this.txtConfirmPassword = new System.Windows.Forms.TextBox();
            this.EditPassword = new System.Windows.Forms.Button();
            this.btnEditDisplayName = new System.Windows.Forms.Button();
            this.pnlMain = new System.Windows.Forms.Panel();
            this.pnlBottom = new System.Windows.Forms.Panel();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.panel3.SuspendLayout();
            this.panel4.SuspendLayout();
            this.panel5.SuspendLayout();
            this.panel6.SuspendLayout();
            this.pnlMain.SuspendLayout();
            this.pnlBottom.SuspendLayout();
            this.SuspendLayout();
            // 
            // lblAccountDetail
            // 
            this.lblAccountDetail.AutoSize = true;
            this.lblAccountDetail.Font = new System.Drawing.Font("Segoe UI", 18F, System.Drawing.FontStyle.Bold);
            this.lblAccountDetail.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(42)))), ((int)(((byte)(63)))), ((int)(((byte)(48)))));
            this.lblAccountDetail.Location = new System.Drawing.Point(44, 40);
            this.lblAccountDetail.Name = "lblAccountDetail";
            this.lblAccountDetail.Size = new System.Drawing.Size(249, 32);
            this.lblAccountDetail.TabIndex = 0;
            this.lblAccountDetail.Text = "▼ Thông tin cá nhân";
            // 
            // lblChangePassword
            // 
            this.lblChangePassword.AutoSize = true;
            this.lblChangePassword.Font = new System.Drawing.Font("Segoe UI", 18F, System.Drawing.FontStyle.Bold);
            this.lblChangePassword.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(42)))), ((int)(((byte)(63)))), ((int)(((byte)(48)))));
            this.lblChangePassword.Location = new System.Drawing.Point(517, 40);
            this.lblChangePassword.Name = "lblChangePassword";
            this.lblChangePassword.Size = new System.Drawing.Size(195, 32);
            this.lblChangePassword.TabIndex = 5;
            this.lblChangePassword.Text = "▼ Đổi mật khẩu";
            // 
            // btnSignOut
            // 
            this.btnSignOut.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSignOut.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(106)))), ((int)(((byte)(156)))), ((int)(((byte)(116)))));
            this.btnSignOut.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSignOut.Font = new System.Drawing.Font("Segoe UI Semibold", 14F, System.Drawing.FontStyle.Bold);
            this.btnSignOut.ForeColor = System.Drawing.Color.White;
            this.btnSignOut.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnSignOut.Location = new System.Drawing.Point(877, 15);
            this.btnSignOut.Name = "btnSignOut";
            this.btnSignOut.Size = new System.Drawing.Size(144, 43);
            this.btnSignOut.TabIndex = 10;
            this.btnSignOut.Text = "Đăng xuất";
            this.btnSignOut.UseVisualStyleBackColor = false;
            this.btnSignOut.Click += new System.EventHandler(this.btnSignOut_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI Semibold", 13F, System.Drawing.FontStyle.Bold);
            this.label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(42)))), ((int)(((byte)(63)))), ((int)(((byte)(48)))));
            this.label1.Location = new System.Drawing.Point(79, 90);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(138, 25);
            this.label1.TabIndex = 1;
            this.label1.Text = "Tên đăng nhập:";
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(42)))), ((int)(((byte)(63)))), ((int)(((byte)(48)))));
            this.panel1.Controls.Add(this.txtUserName);
            this.panel1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(34)))), ((int)(((byte)(10)))), ((int)(((byte)(5)))));
            this.panel1.Location = new System.Drawing.Point(222, 84);
            this.panel1.Name = "panel1";
            this.panel1.Padding = new System.Windows.Forms.Padding(1);
            this.panel1.Size = new System.Drawing.Size(232, 35);
            this.panel1.TabIndex = 12;
            // 
            // txtUserName
            // 
            this.txtUserName.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(248)))), ((int)(((byte)(251)))), ((int)(((byte)(247)))));
            this.txtUserName.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtUserName.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtUserName.Font = new System.Drawing.Font("Segoe UI Semibold", 14F, System.Drawing.FontStyle.Bold);
            this.txtUserName.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(42)))), ((int)(((byte)(63)))), ((int)(((byte)(48)))));
            this.txtUserName.Location = new System.Drawing.Point(1, 1);
            this.txtUserName.Name = "txtUserName";
            this.txtUserName.ReadOnly = true;
            this.txtUserName.Size = new System.Drawing.Size(230, 32);
            this.txtUserName.TabIndex = 0;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Segoe UI Semibold", 13F, System.Drawing.FontStyle.Bold);
            this.label2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(42)))), ((int)(((byte)(63)))), ((int)(((byte)(48)))));
            this.label2.Location = new System.Drawing.Point(79, 145);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(113, 25);
            this.label2.TabIndex = 2;
            this.label2.Text = "Tên hiển thị:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Segoe UI Semibold", 13F, System.Drawing.FontStyle.Bold);
            this.label3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(42)))), ((int)(((byte)(63)))), ((int)(((byte)(48)))));
            this.label3.Location = new System.Drawing.Point(79, 197);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(131, 25);
            this.label3.TabIndex = 3;
            this.label3.Text = "Loại tài khoản:";
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(42)))), ((int)(((byte)(63)))), ((int)(((byte)(48)))));
            this.panel2.Controls.Add(this.txtDisplayName);
            this.panel2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(34)))), ((int)(((byte)(10)))), ((int)(((byte)(5)))));
            this.panel2.Location = new System.Drawing.Point(222, 139);
            this.panel2.Name = "panel2";
            this.panel2.Padding = new System.Windows.Forms.Padding(1);
            this.panel2.Size = new System.Drawing.Size(232, 35);
            this.panel2.TabIndex = 13;
            // 
            // txtDisplayName
            // 
            this.txtDisplayName.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(248)))), ((int)(((byte)(251)))), ((int)(((byte)(247)))));
            this.txtDisplayName.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtDisplayName.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtDisplayName.Font = new System.Drawing.Font("Segoe UI Semibold", 14F, System.Drawing.FontStyle.Bold);
            this.txtDisplayName.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(42)))), ((int)(((byte)(63)))), ((int)(((byte)(48)))));
            this.txtDisplayName.Location = new System.Drawing.Point(1, 1);
            this.txtDisplayName.Name = "txtDisplayName";
            this.txtDisplayName.Size = new System.Drawing.Size(230, 32);
            this.txtDisplayName.TabIndex = 0;
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(42)))), ((int)(((byte)(63)))), ((int)(((byte)(48)))));
            this.panel3.Controls.Add(this.txtAccountType);
            this.panel3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(34)))), ((int)(((byte)(10)))), ((int)(((byte)(5)))));
            this.panel3.Location = new System.Drawing.Point(223, 191);
            this.panel3.Name = "panel3";
            this.panel3.Padding = new System.Windows.Forms.Padding(1);
            this.panel3.Size = new System.Drawing.Size(232, 35);
            this.panel3.TabIndex = 13;
            // 
            // txtAccountType
            // 
            this.txtAccountType.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(248)))), ((int)(((byte)(251)))), ((int)(((byte)(247)))));
            this.txtAccountType.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtAccountType.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtAccountType.Font = new System.Drawing.Font("Segoe UI Semibold", 14F, System.Drawing.FontStyle.Bold);
            this.txtAccountType.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(42)))), ((int)(((byte)(63)))), ((int)(((byte)(48)))));
            this.txtAccountType.Location = new System.Drawing.Point(1, 1);
            this.txtAccountType.Name = "txtAccountType";
            this.txtAccountType.ReadOnly = true;
            this.txtAccountType.Size = new System.Drawing.Size(230, 32);
            this.txtAccountType.TabIndex = 0;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Segoe UI Semibold", 13F, System.Drawing.FontStyle.Bold);
            this.label4.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(42)))), ((int)(((byte)(63)))), ((int)(((byte)(48)))));
            this.label4.Location = new System.Drawing.Point(552, 88);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(117, 25);
            this.label4.TabIndex = 6;
            this.label4.Text = "Mật khẩu cũ:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Segoe UI Semibold", 13F, System.Drawing.FontStyle.Bold);
            this.label5.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(42)))), ((int)(((byte)(63)))), ((int)(((byte)(48)))));
            this.label5.Location = new System.Drawing.Point(552, 142);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(130, 25);
            this.label5.TabIndex = 7;
            this.label5.Text = "Mật khẩu mới:";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Segoe UI Semibold", 13F, System.Drawing.FontStyle.Bold);
            this.label6.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(42)))), ((int)(((byte)(63)))), ((int)(((byte)(48)))));
            this.label6.Location = new System.Drawing.Point(552, 192);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(84, 25);
            this.label6.TabIndex = 8;
            this.label6.Text = "Nhập lại:";
            // 
            // panel4
            // 
            this.panel4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(42)))), ((int)(((byte)(63)))), ((int)(((byte)(48)))));
            this.panel4.Controls.Add(this.btnToggleOldPassword);
            this.panel4.Controls.Add(this.txtOldPassword);
            this.panel4.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(34)))), ((int)(((byte)(10)))), ((int)(((byte)(5)))));
            this.panel4.Location = new System.Drawing.Point(694, 82);
            this.panel4.Name = "panel4";
            this.panel4.Padding = new System.Windows.Forms.Padding(1);
            this.panel4.Size = new System.Drawing.Size(232, 35);
            this.panel4.TabIndex = 19;
            // 
            // btnToggleOldPassword
            // 
            this.btnToggleOldPassword.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(248)))), ((int)(((byte)(251)))), ((int)(((byte)(247)))));
            this.btnToggleOldPassword.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnToggleOldPassword.ForeColor = System.Drawing.Color.Transparent;
            this.btnToggleOldPassword.Image = global::QuanLyCuaHangTraSua.Properties.Resources.view1;
            this.btnToggleOldPassword.Location = new System.Drawing.Point(199, 3);
            this.btnToggleOldPassword.Name = "btnToggleOldPassword";
            this.btnToggleOldPassword.Size = new System.Drawing.Size(29, 28);
            this.btnToggleOldPassword.TabIndex = 1;
            this.btnToggleOldPassword.UseVisualStyleBackColor = false;
            this.btnToggleOldPassword.Click += new System.EventHandler(this.btnToggleOldPassword_Click);
            // 
            // txtOldPassword
            // 
            this.txtOldPassword.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(248)))), ((int)(((byte)(251)))), ((int)(((byte)(247)))));
            this.txtOldPassword.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtOldPassword.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtOldPassword.Font = new System.Drawing.Font("Segoe UI Semibold", 14F, System.Drawing.FontStyle.Bold);
            this.txtOldPassword.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(42)))), ((int)(((byte)(63)))), ((int)(((byte)(48)))));
            this.txtOldPassword.Location = new System.Drawing.Point(1, 1);
            this.txtOldPassword.Name = "txtOldPassword";
            this.txtOldPassword.Size = new System.Drawing.Size(230, 32);
            this.txtOldPassword.TabIndex = 0;
            this.txtOldPassword.UseSystemPasswordChar = true;
            // 
            // panel5
            // 
            this.panel5.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(42)))), ((int)(((byte)(63)))), ((int)(((byte)(48)))));
            this.panel5.Controls.Add(this.btnToggleNewPassword);
            this.panel5.Controls.Add(this.txtNewPassword);
            this.panel5.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(34)))), ((int)(((byte)(10)))), ((int)(((byte)(5)))));
            this.panel5.Location = new System.Drawing.Point(694, 136);
            this.panel5.Name = "panel5";
            this.panel5.Padding = new System.Windows.Forms.Padding(1);
            this.panel5.Size = new System.Drawing.Size(232, 35);
            this.panel5.TabIndex = 20;
            // 
            // btnToggleNewPassword
            // 
            this.btnToggleNewPassword.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(248)))), ((int)(((byte)(251)))), ((int)(((byte)(247)))));
            this.btnToggleNewPassword.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnToggleNewPassword.ForeColor = System.Drawing.Color.Transparent;
            this.btnToggleNewPassword.Image = global::QuanLyCuaHangTraSua.Properties.Resources.view1;
            this.btnToggleNewPassword.Location = new System.Drawing.Point(199, 4);
            this.btnToggleNewPassword.Name = "btnToggleNewPassword";
            this.btnToggleNewPassword.Size = new System.Drawing.Size(29, 27);
            this.btnToggleNewPassword.TabIndex = 2;
            this.btnToggleNewPassword.UseVisualStyleBackColor = false;
            this.btnToggleNewPassword.Click += new System.EventHandler(this.btnToggleNewPassword_Click);
            // 
            // txtNewPassword
            // 
            this.txtNewPassword.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(248)))), ((int)(((byte)(251)))), ((int)(((byte)(247)))));
            this.txtNewPassword.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtNewPassword.Font = new System.Drawing.Font("Segoe UI Semibold", 14F, System.Drawing.FontStyle.Bold);
            this.txtNewPassword.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(42)))), ((int)(((byte)(63)))), ((int)(((byte)(48)))));
            this.txtNewPassword.Location = new System.Drawing.Point(1, 1);
            this.txtNewPassword.Name = "txtNewPassword";
            this.txtNewPassword.Size = new System.Drawing.Size(230, 32);
            this.txtNewPassword.TabIndex = 0;
            this.txtNewPassword.UseSystemPasswordChar = true;
            // 
            // panel6
            // 
            this.panel6.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(42)))), ((int)(((byte)(63)))), ((int)(((byte)(48)))));
            this.panel6.Controls.Add(this.btnToggleConfirmPassword);
            this.panel6.Controls.Add(this.txtConfirmPassword);
            this.panel6.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(34)))), ((int)(((byte)(10)))), ((int)(((byte)(5)))));
            this.panel6.Location = new System.Drawing.Point(694, 186);
            this.panel6.Name = "panel6";
            this.panel6.Padding = new System.Windows.Forms.Padding(1);
            this.panel6.Size = new System.Drawing.Size(232, 35);
            this.panel6.TabIndex = 20;
            // 
            // btnToggleConfirmPassword
            // 
            this.btnToggleConfirmPassword.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(248)))), ((int)(((byte)(251)))), ((int)(((byte)(247)))));
            this.btnToggleConfirmPassword.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnToggleConfirmPassword.ForeColor = System.Drawing.Color.Transparent;
            this.btnToggleConfirmPassword.Image = global::QuanLyCuaHangTraSua.Properties.Resources.view1;
            this.btnToggleConfirmPassword.Location = new System.Drawing.Point(199, 4);
            this.btnToggleConfirmPassword.Name = "btnToggleConfirmPassword";
            this.btnToggleConfirmPassword.Size = new System.Drawing.Size(29, 27);
            this.btnToggleConfirmPassword.TabIndex = 21;
            this.btnToggleConfirmPassword.UseVisualStyleBackColor = false;
            this.btnToggleConfirmPassword.Click += new System.EventHandler(this.btnToggleConfirmPassword_Click);
            // 
            // txtConfirmPassword
            // 
            this.txtConfirmPassword.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(248)))), ((int)(((byte)(251)))), ((int)(((byte)(247)))));
            this.txtConfirmPassword.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtConfirmPassword.Font = new System.Drawing.Font("Segoe UI Semibold", 14F, System.Drawing.FontStyle.Bold);
            this.txtConfirmPassword.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(42)))), ((int)(((byte)(63)))), ((int)(((byte)(48)))));
            this.txtConfirmPassword.Location = new System.Drawing.Point(1, 1);
            this.txtConfirmPassword.Name = "txtConfirmPassword";
            this.txtConfirmPassword.Size = new System.Drawing.Size(230, 32);
            this.txtConfirmPassword.TabIndex = 0;
            this.txtConfirmPassword.UseSystemPasswordChar = true;
            // 
            // EditPassword
            // 
            this.EditPassword.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(106)))), ((int)(((byte)(156)))), ((int)(((byte)(116)))));
            this.EditPassword.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.EditPassword.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.EditPassword.ForeColor = System.Drawing.Color.White;
            this.EditPassword.Image = global::QuanLyCuaHangTraSua.Properties.Resources.edit;
            this.EditPassword.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.EditPassword.Location = new System.Drawing.Point(695, 241);
            this.EditPassword.Name = "EditPassword";
            this.EditPassword.Padding = new System.Windows.Forms.Padding(10, 0, 0, 0);
            this.EditPassword.Size = new System.Drawing.Size(233, 44);
            this.EditPassword.TabIndex = 9;
            this.EditPassword.Text = "Đổi mật khẩu";
            this.EditPassword.UseVisualStyleBackColor = false;
            this.EditPassword.Click += new System.EventHandler(this.EditPassword_Click);
            // 
            // btnEditDisplayName
            // 
            this.btnEditDisplayName.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(106)))), ((int)(((byte)(156)))), ((int)(((byte)(116)))));
            this.btnEditDisplayName.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnEditDisplayName.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnEditDisplayName.ForeColor = System.Drawing.Color.White;
            this.btnEditDisplayName.Image = global::QuanLyCuaHangTraSua.Properties.Resources.edit;
            this.btnEditDisplayName.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnEditDisplayName.Location = new System.Drawing.Point(222, 246);
            this.btnEditDisplayName.Name = "btnEditDisplayName";
            this.btnEditDisplayName.Padding = new System.Windows.Forms.Padding(10, 0, 0, 0);
            this.btnEditDisplayName.Size = new System.Drawing.Size(233, 44);
            this.btnEditDisplayName.TabIndex = 4;
            this.btnEditDisplayName.Text = "Lưu thay đổi";
            this.btnEditDisplayName.UseVisualStyleBackColor = false;
            this.btnEditDisplayName.Click += new System.EventHandler(this.btnEditDisplayName_Click);
            // 
            // pnlMain
            // 
            this.pnlMain.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(248)))), ((int)(((byte)(251)))), ((int)(((byte)(247)))));
            this.pnlMain.Controls.Add(this.lblAccountDetail);
            this.pnlMain.Controls.Add(this.lblChangePassword);
            this.pnlMain.Controls.Add(this.label1);
            this.pnlMain.Controls.Add(this.panel1);
            this.pnlMain.Controls.Add(this.label2);
            this.pnlMain.Controls.Add(this.label3);
            this.pnlMain.Controls.Add(this.panel2);
            this.pnlMain.Controls.Add(this.panel3);
            this.pnlMain.Controls.Add(this.btnEditDisplayName);
            this.pnlMain.Controls.Add(this.label4);
            this.pnlMain.Controls.Add(this.label5);
            this.pnlMain.Controls.Add(this.label6);
            this.pnlMain.Controls.Add(this.panel4);
            this.pnlMain.Controls.Add(this.panel6);
            this.pnlMain.Controls.Add(this.EditPassword);
            this.pnlMain.Controls.Add(this.panel5);
            this.pnlMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlMain.Location = new System.Drawing.Point(0, 0);
            this.pnlMain.Name = "pnlMain";
            this.pnlMain.Size = new System.Drawing.Size(1040, 654);
            this.pnlMain.TabIndex = 21;
            // 
            // pnlBottom
            // 
            this.pnlBottom.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(248)))), ((int)(((byte)(251)))), ((int)(((byte)(247)))));
            this.pnlBottom.Controls.Add(this.btnSignOut);
            this.pnlBottom.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pnlBottom.Location = new System.Drawing.Point(0, 581);
            this.pnlBottom.Name = "pnlBottom";
            this.pnlBottom.Size = new System.Drawing.Size(1040, 73);
            this.pnlBottom.TabIndex = 22;
            // 
            // ucSetting
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.LavenderBlush;
            this.Controls.Add(this.pnlBottom);
            this.Controls.Add(this.pnlMain);
            this.Name = "ucSetting";
            this.Size = new System.Drawing.Size(1040, 654);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.panel4.ResumeLayout(false);
            this.panel4.PerformLayout();
            this.panel5.ResumeLayout(false);
            this.panel5.PerformLayout();
            this.panel6.ResumeLayout(false);
            this.panel6.PerformLayout();
            this.pnlMain.ResumeLayout(false);
            this.pnlMain.PerformLayout();
            this.pnlBottom.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Label lblAccountDetail;
        private System.Windows.Forms.Label lblChangePassword;
        private System.Windows.Forms.Button btnSignOut;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.TextBox txtUserName;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.TextBox txtDisplayName;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.TextBox txtAccountType;
        private System.Windows.Forms.Button btnEditDisplayName;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.TextBox txtOldPassword;
        private System.Windows.Forms.Panel panel5;
        private System.Windows.Forms.TextBox txtNewPassword;
        private System.Windows.Forms.Panel panel6;
        private System.Windows.Forms.TextBox txtConfirmPassword;
        private System.Windows.Forms.Button EditPassword;
        private System.Windows.Forms.Button btnToggleOldPassword;
        private System.Windows.Forms.Button btnToggleNewPassword;
        private System.Windows.Forms.Button btnToggleConfirmPassword;
        private System.Windows.Forms.Panel pnlMain;
        private System.Windows.Forms.Panel pnlBottom;
    }
}
