namespace PresentationLayer
{
    partial class FormDangNhap
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
            this.components = new System.ComponentModel.Container();
            this.panel1 = new System.Windows.Forms.Panel();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.label3 = new System.Windows.Forms.Label();
            this.clickExit = new System.Windows.Forms.Label();
            this.txtTenDangNhap = new System.Windows.Forms.TextBox();
            this.txtMatKhau = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.btLogin = new System.Windows.Forms.Button();
            this.lbThanks = new System.Windows.Forms.Label();
            this.lbExit = new System.Windows.Forms.Label();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.jsonDataSource1 = new DevExpress.DataAccess.Json.JsonDataSource(this.components);
            this.pbShow = new System.Windows.Forms.PictureBox();
            this.pbHide = new System.Windows.Forms.PictureBox();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbShow)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbHide)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.CornflowerBlue;
            this.panel1.Controls.Add(this.pictureBox1);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(330, 678);
            this.panel1.TabIndex = 0;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::PresentationLayer.Properties.Resources.Icon_Employee;
            this.pictureBox1.Location = new System.Drawing.Point(110, 100);
            this.pictureBox1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(100, 100);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 9;
            this.pictureBox1.TabStop = false;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Tahoma", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.label3.Location = new System.Drawing.Point(102, 228);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(114, 24);
            this.label3.TabIndex = 9;
            this.label3.Text = "NhanSuPlus";
            // 
            // clickExit
            // 
            this.clickExit.AutoSize = true;
            this.clickExit.Cursor = System.Windows.Forms.Cursors.Hand;
            this.clickExit.Font = new System.Drawing.Font("Tahoma", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.clickExit.Location = new System.Drawing.Point(782, 0);
            this.clickExit.Name = "clickExit";
            this.clickExit.Size = new System.Drawing.Size(23, 27);
            this.clickExit.TabIndex = 1;
            this.clickExit.Text = "x";
            // 
            // txtTenDangNhap
            // 
            this.txtTenDangNhap.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtTenDangNhap.Font = new System.Drawing.Font("Tahoma", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtTenDangNhap.Location = new System.Drawing.Point(374, 189);
            this.txtTenDangNhap.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtTenDangNhap.Name = "txtTenDangNhap";
            this.txtTenDangNhap.Size = new System.Drawing.Size(404, 34);
            this.txtTenDangNhap.TabIndex = 4;
            // 
            // txtMatKhau
            // 
            this.txtMatKhau.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtMatKhau.Font = new System.Drawing.Font("Tahoma", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtMatKhau.Location = new System.Drawing.Point(374, 292);
            this.txtMatKhau.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtMatKhau.Name = "txtMatKhau";
            this.txtMatKhau.PasswordChar = '*';
            this.txtMatKhau.Size = new System.Drawing.Size(374, 34);
            this.txtMatKhau.TabIndex = 6;
            this.txtMatKhau.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtMatKhau_KeyDown);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Tahoma", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(369, 266);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(105, 24);
            this.label4.TabIndex = 5;
            this.label4.Text = "Mật khẩu: ";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Tahoma", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(367, 88);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(187, 34);
            this.label5.TabIndex = 2;
            this.label5.Text = "ĐĂNG NHẬP";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Tahoma", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(369, 162);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(157, 24);
            this.label6.TabIndex = 3;
            this.label6.Text = "Tên đăng nhập: ";
            // 
            // btLogin
            // 
            this.btLogin.BackColor = System.Drawing.Color.RoyalBlue;
            this.btLogin.FlatAppearance.BorderSize = 0;
            this.btLogin.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btLogin.Font = new System.Drawing.Font("Tahoma", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btLogin.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btLogin.Location = new System.Drawing.Point(487, 398);
            this.btLogin.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btLogin.Name = "btLogin";
            this.btLogin.Size = new System.Drawing.Size(169, 40);
            this.btLogin.TabIndex = 8;
            this.btLogin.Text = "Đăng nhập";
            this.btLogin.UseVisualStyleBackColor = false;
            this.btLogin.Click += new System.EventHandler(this.btLogin_Click);
            // 
            // lbThanks
            // 
            this.lbThanks.AutoSize = true;
            this.lbThanks.Font = new System.Drawing.Font("Times New Roman", 10.2F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbThanks.ForeColor = System.Drawing.Color.DodgerBlue;
            this.lbThanks.Location = new System.Drawing.Point(429, 641);
            this.lbThanks.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lbThanks.Name = "lbThanks";
            this.lbThanks.Size = new System.Drawing.Size(330, 24);
            this.lbThanks.TabIndex = 18;
            this.lbThanks.Text = "Quản lý dễ dàng, hiệu quả vượt trội!";
            // 
            // lbExit
            // 
            this.lbExit.AutoSize = true;
            this.lbExit.BackColor = System.Drawing.SystemColors.Control;
            this.lbExit.Cursor = System.Windows.Forms.Cursors.Hand;
            this.lbExit.Font = new System.Drawing.Font("Times New Roman", 10.2F, ((System.Drawing.FontStyle)(((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic) 
                | System.Drawing.FontStyle.Underline))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbExit.ForeColor = System.Drawing.Color.DodgerBlue;
            this.lbExit.Location = new System.Drawing.Point(544, 452);
            this.lbExit.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lbExit.Name = "lbExit";
            this.lbExit.Size = new System.Drawing.Size(62, 24);
            this.lbExit.TabIndex = 20;
            this.lbExit.Text = "Thoát";
            this.lbExit.Click += new System.EventHandler(this.lbExit_Click);
            // 
            // jsonDataSource1
            // 
            this.jsonDataSource1.Name = "jsonDataSource1";
            // 
            // pbShow
            // 
            this.pbShow.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pbShow.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pbShow.Image = global::PresentationLayer.Properties.Resources.show1;
            this.pbShow.Location = new System.Drawing.Point(745, 292);
            this.pbShow.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.pbShow.Name = "pbShow";
            this.pbShow.Size = new System.Drawing.Size(32, 46);
            this.pbShow.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pbShow.TabIndex = 21;
            this.pbShow.TabStop = false;
            this.pbShow.Click += new System.EventHandler(this.pbShow_Click);
            this.pbShow.MouseHover += new System.EventHandler(this.pbShow_MouseHover);
            // 
            // pbHide
            // 
            this.pbHide.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pbHide.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pbHide.Image = global::PresentationLayer.Properties.Resources.picshow1;
            this.pbHide.Location = new System.Drawing.Point(745, 292);
            this.pbHide.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.pbHide.Name = "pbHide";
            this.pbHide.Size = new System.Drawing.Size(32, 46);
            this.pbHide.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pbHide.TabIndex = 11;
            this.pbHide.TabStop = false;
            this.pbHide.Click += new System.EventHandler(this.pbHide_Click);
            this.pbHide.MouseHover += new System.EventHandler(this.pbHide_MouseHover);
            // 
            // FormDangNhap
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(804, 678);
            this.Controls.Add(this.pbShow);
            this.Controls.Add(this.lbExit);
            this.Controls.Add(this.lbThanks);
            this.Controls.Add(this.pbHide);
            this.Controls.Add(this.btLogin);
            this.Controls.Add(this.txtMatKhau);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.txtTenDangNhap);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.clickExit);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Name = "FormDangNhap";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Đăng nhập";
            this.Load += new System.EventHandler(this.frmDangNhap_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbShow)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbHide)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label clickExit;
        private System.Windows.Forms.TextBox txtTenDangNhap;
        private System.Windows.Forms.TextBox txtMatKhau;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Button btLogin;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.PictureBox pbHide;
        private System.Windows.Forms.Label lbThanks;
        private System.Windows.Forms.Label lbExit;
        private System.Windows.Forms.PictureBox pbShow;
        private System.Windows.Forms.ToolTip toolTip1;
        private DevExpress.DataAccess.Json.JsonDataSource jsonDataSource1;
    }
}

