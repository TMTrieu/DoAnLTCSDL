namespace PresentationLayer
{
    partial class FormDoiMatKhau
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
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.pbShow1 = new System.Windows.Forms.PictureBox();
            this.pbHide1 = new System.Windows.Forms.PictureBox();
            this.txtMatKhauHienTai = new System.Windows.Forms.TextBox();
            this.txtMatKhauMoi = new System.Windows.Forms.TextBox();
            this.txtXacNhanMatKhau = new System.Windows.Forms.TextBox();
            this.pbShow2 = new System.Windows.Forms.PictureBox();
            this.pbShow3 = new System.Windows.Forms.PictureBox();
            this.pbHide2 = new System.Windows.Forms.PictureBox();
            this.pbHide3 = new System.Windows.Forms.PictureBox();
            this.btDoiMatKhau = new System.Windows.Forms.Button();
            this.btHuy = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.pbShow1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbHide1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbShow2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbShow3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbHide2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbHide3)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Times New Roman", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(136, 121);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(211, 33);
            this.label1.TabIndex = 0;
            this.label1.Text = "Mật khẩu hiện tại";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Times New Roman", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(136, 316);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(278, 33);
            this.label2.TabIndex = 1;
            this.label2.Text = "Xác nhận mật khẩu mới";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Times New Roman", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(136, 226);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(171, 33);
            this.label3.TabIndex = 2;
            this.label3.Text = "Mật khẩu mới";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Times New Roman", 22.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(190, 9);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(293, 42);
            this.label4.TabIndex = 3;
            this.label4.Text = "Thay đổi mật khẩu";
            // 
            // pbShow1
            // 
            this.pbShow1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pbShow1.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pbShow1.Image = global::PresentationLayer.Properties.Resources.show1;
            this.pbShow1.Location = new System.Drawing.Point(482, 165);
            this.pbShow1.Margin = new System.Windows.Forms.Padding(4);
            this.pbShow1.Name = "pbShow1";
            this.pbShow1.Size = new System.Drawing.Size(29, 37);
            this.pbShow1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pbShow1.TabIndex = 22;
            this.pbShow1.TabStop = false;
            this.pbShow1.Click += new System.EventHandler(this.pbShow1_Click);
            // 
            // pbHide1
            // 
            this.pbHide1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pbHide1.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pbHide1.Image = global::PresentationLayer.Properties.Resources.picshow1;
            this.pbHide1.Location = new System.Drawing.Point(482, 165);
            this.pbHide1.Margin = new System.Windows.Forms.Padding(4);
            this.pbHide1.Name = "pbHide1";
            this.pbHide1.Size = new System.Drawing.Size(29, 37);
            this.pbHide1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pbHide1.TabIndex = 23;
            this.pbHide1.TabStop = false;
            this.pbHide1.Click += new System.EventHandler(this.pbHide1_Click);
            // 
            // txtMatKhauHienTai
            // 
            this.txtMatKhauHienTai.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtMatKhauHienTai.Font = new System.Drawing.Font("Tahoma", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtMatKhauHienTai.Location = new System.Drawing.Point(142, 165);
            this.txtMatKhauHienTai.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtMatKhauHienTai.Multiline = true;
            this.txtMatKhauHienTai.Name = "txtMatKhauHienTai";
            this.txtMatKhauHienTai.Size = new System.Drawing.Size(341, 37);
            this.txtMatKhauHienTai.TabIndex = 28;
            // 
            // txtMatKhauMoi
            // 
            this.txtMatKhauMoi.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtMatKhauMoi.Font = new System.Drawing.Font("Tahoma", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtMatKhauMoi.Location = new System.Drawing.Point(142, 260);
            this.txtMatKhauMoi.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtMatKhauMoi.Multiline = true;
            this.txtMatKhauMoi.Name = "txtMatKhauMoi";
            this.txtMatKhauMoi.Size = new System.Drawing.Size(341, 37);
            this.txtMatKhauMoi.TabIndex = 29;
            // 
            // txtXacNhanMatKhau
            // 
            this.txtXacNhanMatKhau.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtXacNhanMatKhau.Font = new System.Drawing.Font("Tahoma", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtXacNhanMatKhau.Location = new System.Drawing.Point(142, 365);
            this.txtXacNhanMatKhau.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtXacNhanMatKhau.Multiline = true;
            this.txtXacNhanMatKhau.Name = "txtXacNhanMatKhau";
            this.txtXacNhanMatKhau.Size = new System.Drawing.Size(341, 37);
            this.txtXacNhanMatKhau.TabIndex = 30;
            // 
            // pbShow2
            // 
            this.pbShow2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pbShow2.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pbShow2.Image = global::PresentationLayer.Properties.Resources.show1;
            this.pbShow2.Location = new System.Drawing.Point(482, 260);
            this.pbShow2.Margin = new System.Windows.Forms.Padding(4);
            this.pbShow2.Name = "pbShow2";
            this.pbShow2.Size = new System.Drawing.Size(29, 37);
            this.pbShow2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pbShow2.TabIndex = 31;
            this.pbShow2.TabStop = false;
            this.pbShow2.Click += new System.EventHandler(this.pbShow2_Click);
            // 
            // pbShow3
            // 
            this.pbShow3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pbShow3.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pbShow3.Image = global::PresentationLayer.Properties.Resources.show1;
            this.pbShow3.Location = new System.Drawing.Point(482, 365);
            this.pbShow3.Margin = new System.Windows.Forms.Padding(4);
            this.pbShow3.Name = "pbShow3";
            this.pbShow3.Size = new System.Drawing.Size(29, 37);
            this.pbShow3.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pbShow3.TabIndex = 32;
            this.pbShow3.TabStop = false;
            this.pbShow3.Click += new System.EventHandler(this.pbShow3_Click);
            // 
            // pbHide2
            // 
            this.pbHide2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pbHide2.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pbHide2.Image = global::PresentationLayer.Properties.Resources.picshow1;
            this.pbHide2.Location = new System.Drawing.Point(482, 260);
            this.pbHide2.Margin = new System.Windows.Forms.Padding(4);
            this.pbHide2.Name = "pbHide2";
            this.pbHide2.Size = new System.Drawing.Size(29, 37);
            this.pbHide2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pbHide2.TabIndex = 33;
            this.pbHide2.TabStop = false;
            this.pbHide2.Click += new System.EventHandler(this.pbHide2_Click);
            // 
            // pbHide3
            // 
            this.pbHide3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pbHide3.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pbHide3.Image = global::PresentationLayer.Properties.Resources.picshow1;
            this.pbHide3.Location = new System.Drawing.Point(482, 365);
            this.pbHide3.Margin = new System.Windows.Forms.Padding(4);
            this.pbHide3.Name = "pbHide3";
            this.pbHide3.Size = new System.Drawing.Size(29, 37);
            this.pbHide3.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pbHide3.TabIndex = 34;
            this.pbHide3.TabStop = false;
            this.pbHide3.Click += new System.EventHandler(this.pbHide3_Click);
            // 
            // btDoiMatKhau
            // 
            this.btDoiMatKhau.BackColor = System.Drawing.Color.RoyalBlue;
            this.btDoiMatKhau.Font = new System.Drawing.Font("Times New Roman", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btDoiMatKhau.ForeColor = System.Drawing.Color.White;
            this.btDoiMatKhau.Location = new System.Drawing.Point(450, 436);
            this.btDoiMatKhau.Name = "btDoiMatKhau";
            this.btDoiMatKhau.Size = new System.Drawing.Size(209, 41);
            this.btDoiMatKhau.TabIndex = 35;
            this.btDoiMatKhau.Text = "Đổi mật khẩu";
            this.btDoiMatKhau.UseVisualStyleBackColor = false;
            this.btDoiMatKhau.Click += new System.EventHandler(this.btDoiMatKhau_Click);
            // 
            // btHuy
            // 
            this.btHuy.BackColor = System.Drawing.Color.RoyalBlue;
            this.btHuy.Font = new System.Drawing.Font("Times New Roman", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btHuy.ForeColor = System.Drawing.Color.White;
            this.btHuy.Location = new System.Drawing.Point(334, 436);
            this.btHuy.Name = "btHuy";
            this.btHuy.Size = new System.Drawing.Size(101, 41);
            this.btHuy.TabIndex = 36;
            this.btHuy.Text = "Hủy";
            this.btHuy.UseVisualStyleBackColor = false;
            this.btHuy.Click += new System.EventHandler(this.btHuy_Click);
            // 
            // FormDoiMatKhau
            // 
            this.Appearance.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.Appearance.Options.UseBackColor = true;
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(700, 504);
            this.Controls.Add(this.pbHide1);
            this.Controls.Add(this.pbHide2);
            this.Controls.Add(this.pbHide3);
            this.Controls.Add(this.btHuy);
            this.Controls.Add(this.btDoiMatKhau);
            this.Controls.Add(this.pbShow3);
            this.Controls.Add(this.pbShow2);
            this.Controls.Add(this.txtXacNhanMatKhau);
            this.Controls.Add(this.txtMatKhauMoi);
            this.Controls.Add(this.txtMatKhauHienTai);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.pbShow1);
            this.Name = "FormDoiMatKhau";
            this.Text = "FormDoiMatKhau";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.FormDoiMatKhau_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pbShow1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbHide1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbShow2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbShow3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbHide2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbHide3)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.PictureBox pbShow1;
        private System.Windows.Forms.PictureBox pbHide1;
        private System.Windows.Forms.TextBox txtMatKhauHienTai;
        private System.Windows.Forms.TextBox txtMatKhauMoi;
        private System.Windows.Forms.TextBox txtXacNhanMatKhau;
        private System.Windows.Forms.PictureBox pbShow2;
        private System.Windows.Forms.PictureBox pbShow3;
        private System.Windows.Forms.PictureBox pbHide2;
        private System.Windows.Forms.PictureBox pbHide3;
        private System.Windows.Forms.Button btDoiMatKhau;
        private System.Windows.Forms.Button btHuy;
    }
}