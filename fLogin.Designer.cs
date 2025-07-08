namespace QuanLyCuaHangTraSua
{
    partial class fLogin
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

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(fLogin));
            this.pnlDangNhap = new System.Windows.Forms.Panel();
            this.pbOnOff = new System.Windows.Forms.PictureBox();
            this.btnLogin = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.pnlMatKhau = new System.Windows.Forms.Panel();
            this.txtPassword = new System.Windows.Forms.TextBox();
            this.pnlTenDangNhap = new System.Windows.Forms.Panel();
            this.txtUserName = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.pbDangNhap = new System.Windows.Forms.PictureBox();
            this.pnlDangNhap.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbOnOff)).BeginInit();
            this.pnlMatKhau.SuspendLayout();
            this.pnlTenDangNhap.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbDangNhap)).BeginInit();
            this.SuspendLayout();
            // 
            // pnlDangNhap
            // 
            this.pnlDangNhap.BackColor = System.Drawing.Color.LavenderBlush;
            this.pnlDangNhap.Controls.Add(this.pbOnOff);
            this.pnlDangNhap.Controls.Add(this.btnLogin);
            this.pnlDangNhap.Controls.Add(this.label4);
            this.pnlDangNhap.Controls.Add(this.label3);
            this.pnlDangNhap.Controls.Add(this.pnlMatKhau);
            this.pnlDangNhap.Controls.Add(this.pnlTenDangNhap);
            this.pnlDangNhap.Controls.Add(this.label2);
            this.pnlDangNhap.Controls.Add(this.label1);
            this.pnlDangNhap.Controls.Add(this.pbDangNhap);
            this.pnlDangNhap.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlDangNhap.Location = new System.Drawing.Point(0, 0);
            this.pnlDangNhap.Name = "pnlDangNhap";
            this.pnlDangNhap.Size = new System.Drawing.Size(800, 500);
            this.pnlDangNhap.TabIndex = 0;
            this.pnlDangNhap.MouseDown += new System.Windows.Forms.MouseEventHandler(this.pnlDangNhap_MouseDown);
            this.pnlDangNhap.MouseMove += new System.Windows.Forms.MouseEventHandler(this.pnlDangNhap_MouseMove);
            this.pnlDangNhap.MouseUp += new System.Windows.Forms.MouseEventHandler(this.pnlDangNhap_MouseUp);
            // 
            // pbOnOff
            // 
            this.pbOnOff.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("pbOnOff.BackgroundImage")));
            this.pbOnOff.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pbOnOff.Location = new System.Drawing.Point(743, 446);
            this.pbOnOff.Name = "pbOnOff";
            this.pbOnOff.Size = new System.Drawing.Size(45, 42);
            this.pbOnOff.TabIndex = 5;
            this.pbOnOff.TabStop = false;
            this.pbOnOff.Click += new System.EventHandler(this.pbOnOff_Click);
            // 
            // btnLogin
            // 
            this.btnLogin.BackColor = System.Drawing.Color.Coral;
            this.btnLogin.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnLogin.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnLogin.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btnLogin.Location = new System.Drawing.Point(443, 351);
            this.btnLogin.Name = "btnLogin";
            this.btnLogin.Size = new System.Drawing.Size(202, 43);
            this.btnLogin.TabIndex = 0;
            this.btnLogin.Text = "Đăng nhập";
            this.btnLogin.UseVisualStyleBackColor = false;
            this.btnLogin.Click += new System.EventHandler(this.btnLogin_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold);
            this.label4.ForeColor = System.Drawing.Color.SaddleBrown;
            this.label4.Location = new System.Drawing.Point(366, 171);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(120, 21);
            this.label4.TabIndex = 6;
            this.label4.Text = "Tên đăng nhập:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold);
            this.label3.ForeColor = System.Drawing.Color.SaddleBrown;
            this.label3.Location = new System.Drawing.Point(366, 255);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(81, 21);
            this.label3.TabIndex = 5;
            this.label3.Text = "Mật khẩu:";
            // 
            // pnlMatKhau
            // 
            this.pnlMatKhau.BackColor = System.Drawing.Color.SaddleBrown;
            this.pnlMatKhau.Controls.Add(this.txtPassword);
            this.pnlMatKhau.Location = new System.Drawing.Point(369, 278);
            this.pnlMatKhau.Name = "pnlMatKhau";
            this.pnlMatKhau.Padding = new System.Windows.Forms.Padding(1);
            this.pnlMatKhau.Size = new System.Drawing.Size(365, 41);
            this.pnlMatKhau.TabIndex = 4;
            // 
            // txtPassword
            // 
            this.txtPassword.BackColor = System.Drawing.Color.LavenderBlush;
            this.txtPassword.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtPassword.Font = new System.Drawing.Font("Segoe UI Semibold", 17.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtPassword.ForeColor = System.Drawing.Color.SaddleBrown;
            this.txtPassword.Location = new System.Drawing.Point(1, 1);
            this.txtPassword.Name = "txtPassword";
            this.txtPassword.Size = new System.Drawing.Size(363, 38);
            this.txtPassword.TabIndex = 0;
            this.txtPassword.UseSystemPasswordChar = true;
            // 
            // pnlTenDangNhap
            // 
            this.pnlTenDangNhap.BackColor = System.Drawing.Color.SaddleBrown;
            this.pnlTenDangNhap.Controls.Add(this.txtUserName);
            this.pnlTenDangNhap.Location = new System.Drawing.Point(369, 198);
            this.pnlTenDangNhap.Name = "pnlTenDangNhap";
            this.pnlTenDangNhap.Padding = new System.Windows.Forms.Padding(1);
            this.pnlTenDangNhap.Size = new System.Drawing.Size(365, 41);
            this.pnlTenDangNhap.TabIndex = 3;
            // 
            // txtUserName
            // 
            this.txtUserName.BackColor = System.Drawing.Color.LavenderBlush;
            this.txtUserName.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtUserName.Font = new System.Drawing.Font("Segoe UI Semibold", 17F, System.Drawing.FontStyle.Bold);
            this.txtUserName.ForeColor = System.Drawing.Color.SaddleBrown;
            this.txtUserName.Location = new System.Drawing.Point(1, 1);
            this.txtUserName.Name = "txtUserName";
            this.txtUserName.Size = new System.Drawing.Size(363, 38);
            this.txtUserName.TabIndex = 0;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Segoe UI Semibold", 14F, System.Drawing.FontStyle.Bold);
            this.label2.ForeColor = System.Drawing.Color.SaddleBrown;
            this.label2.Location = new System.Drawing.Point(365, 130);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(308, 25);
            this.label2.TabIndex = 3;
            this.label2.Text = "Bắt đầu quản lý cửa hàng của bạn!";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 30F, System.Drawing.FontStyle.Bold);
            this.label1.ForeColor = System.Drawing.Color.SaddleBrown;
            this.label1.Location = new System.Drawing.Point(360, 67);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(230, 54);
            this.label1.TabIndex = 2;
            this.label1.Text = "Đăng nhập";
            // 
            // pbDangNhap
            // 
            this.pbDangNhap.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("pbDangNhap.BackgroundImage")));
            this.pbDangNhap.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pbDangNhap.Location = new System.Drawing.Point(0, 0);
            this.pbDangNhap.Name = "pbDangNhap";
            this.pbDangNhap.Size = new System.Drawing.Size(328, 500);
            this.pbDangNhap.TabIndex = 0;
            this.pbDangNhap.TabStop = false;
            // 
            // fLogin
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 500);
            this.Controls.Add(this.pnlDangNhap);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "fLogin";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "fLogin";
            this.pnlDangNhap.ResumeLayout(false);
            this.pnlDangNhap.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbOnOff)).EndInit();
            this.pnlMatKhau.ResumeLayout(false);
            this.pnlMatKhau.PerformLayout();
            this.pnlTenDangNhap.ResumeLayout(false);
            this.pnlTenDangNhap.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbDangNhap)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel pnlDangNhap;
        private System.Windows.Forms.PictureBox pbDangNhap;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Panel pnlTenDangNhap;
        private System.Windows.Forms.Panel pnlMatKhau;
        private System.Windows.Forms.TextBox txtPassword;
        private System.Windows.Forms.TextBox txtUserName;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button btnLogin;
        private System.Windows.Forms.PictureBox pbOnOff;
    }
}