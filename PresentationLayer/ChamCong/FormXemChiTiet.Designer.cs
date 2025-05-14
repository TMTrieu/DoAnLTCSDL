namespace PresentationLayer.ChamCong
{
    partial class FormXemChiTiet
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
            this.label7 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.groupThongTinChiTiet = new System.Windows.Forms.GroupBox();
            this.lbTen = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.txtTen = new System.Windows.Forms.Label();
            this.txtNgay = new System.Windows.Forms.Label();
            this.txtGioVao = new System.Windows.Forms.Label();
            this.txtGioRa = new System.Windows.Forms.Label();
            this.txtCa = new System.Windows.Forms.Label();
            this.txtCong = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.groupThongTinChiTiet.SuspendLayout();
            this.SuspendLayout();
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.label7.Location = new System.Drawing.Point(469, 76);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(63, 22);
            this.label7.TabIndex = 8;
            this.label7.Text = "Giờ ra";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.label5.Location = new System.Drawing.Point(220, 93);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(80, 22);
            this.label5.TabIndex = 8;
            this.label5.Text = "Loại ca:";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.label6.Location = new System.Drawing.Point(469, 32);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(83, 22);
            this.label6.TabIndex = 8;
            this.label6.Text = "Giờ vào:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.label4.Location = new System.Drawing.Point(220, 137);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(103, 22);
            this.label4.TabIndex = 8;
            this.label4.Text = "Loại công:";
            // 
            // groupThongTinChiTiet
            // 
            this.groupThongTinChiTiet.Controls.Add(this.groupBox1);
            this.groupThongTinChiTiet.Controls.Add(this.txtNgay);
            this.groupThongTinChiTiet.Controls.Add(this.label1);
            this.groupThongTinChiTiet.Controls.Add(this.txtCong);
            this.groupThongTinChiTiet.Controls.Add(this.txtCa);
            this.groupThongTinChiTiet.Controls.Add(this.txtTen);
            this.groupThongTinChiTiet.Controls.Add(this.lbTen);
            this.groupThongTinChiTiet.Controls.Add(this.txtGioRa);
            this.groupThongTinChiTiet.Controls.Add(this.label7);
            this.groupThongTinChiTiet.Controls.Add(this.txtGioVao);
            this.groupThongTinChiTiet.Controls.Add(this.label6);
            this.groupThongTinChiTiet.Controls.Add(this.label4);
            this.groupThongTinChiTiet.Controls.Add(this.label5);
            this.groupThongTinChiTiet.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupThongTinChiTiet.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.groupThongTinChiTiet.Location = new System.Drawing.Point(0, 0);
            this.groupThongTinChiTiet.Name = "groupThongTinChiTiet";
            this.groupThongTinChiTiet.Size = new System.Drawing.Size(868, 477);
            this.groupThongTinChiTiet.TabIndex = 15;
            this.groupThongTinChiTiet.TabStop = false;
            this.groupThongTinChiTiet.Text = "Chấm công ngày ";
            this.groupThongTinChiTiet.Enter += new System.EventHandler(this.groupBox2_Enter);
            // 
            // lbTen
            // 
            this.lbTen.AutoSize = true;
            this.lbTen.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.lbTen.Location = new System.Drawing.Point(6, 49);
            this.lbTen.Name = "lbTen";
            this.lbTen.Size = new System.Drawing.Size(109, 22);
            this.lbTen.TabIndex = 11;
            this.lbTen.Text = "Nhân viên:";
            this.lbTen.Click += new System.EventHandler(this.lblTrangThai_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.label1.Location = new System.Drawing.Point(6, 93);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(63, 22);
            this.label1.TabIndex = 11;
            this.label1.Text = "Ngày:";
            this.label1.Click += new System.EventHandler(this.lblTrangThai_Click);
            // 
            // txtTen
            // 
            this.txtTen.AutoSize = true;
            this.txtTen.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.txtTen.Location = new System.Drawing.Point(113, 49);
            this.txtTen.Name = "txtTen";
            this.txtTen.Size = new System.Drawing.Size(38, 22);
            this.txtTen.TabIndex = 11;
            this.txtTen.Text = "----";
            this.txtTen.Click += new System.EventHandler(this.lblTrangThai_Click);
            // 
            // txtNgay
            // 
            this.txtNgay.AutoSize = true;
            this.txtNgay.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.txtNgay.Location = new System.Drawing.Point(75, 93);
            this.txtNgay.Name = "txtNgay";
            this.txtNgay.Size = new System.Drawing.Size(38, 22);
            this.txtNgay.TabIndex = 11;
            this.txtNgay.Text = "----";
            this.txtNgay.Click += new System.EventHandler(this.lblTrangThai_Click);
            // 
            // txtGioVao
            // 
            this.txtGioVao.AutoSize = true;
            this.txtGioVao.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.txtGioVao.Location = new System.Drawing.Point(548, 32);
            this.txtGioVao.Name = "txtGioVao";
            this.txtGioVao.Size = new System.Drawing.Size(44, 22);
            this.txtGioVao.TabIndex = 8;
            this.txtGioVao.Text = "--:--";
            // 
            // txtGioRa
            // 
            this.txtGioRa.AutoSize = true;
            this.txtGioRa.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.txtGioRa.Location = new System.Drawing.Point(548, 76);
            this.txtGioRa.Name = "txtGioRa";
            this.txtGioRa.Size = new System.Drawing.Size(44, 22);
            this.txtGioRa.TabIndex = 8;
            this.txtGioRa.Text = "--:--";
            // 
            // txtCa
            // 
            this.txtCa.AutoSize = true;
            this.txtCa.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.txtCa.Location = new System.Drawing.Point(318, 93);
            this.txtCa.Name = "txtCa";
            this.txtCa.Size = new System.Drawing.Size(38, 22);
            this.txtCa.TabIndex = 11;
            this.txtCa.Text = "----";
            this.txtCa.Click += new System.EventHandler(this.lblTrangThai_Click);
            // 
            // txtCong
            // 
            this.txtCong.AutoSize = true;
            this.txtCong.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.txtCong.Location = new System.Drawing.Point(318, 137);
            this.txtCong.Name = "txtCong";
            this.txtCong.Size = new System.Drawing.Size(38, 22);
            this.txtCong.TabIndex = 11;
            this.txtCong.Text = "----";
            this.txtCong.Click += new System.EventHandler(this.lblTrangThai_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Location = new System.Drawing.Point(10, 170);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(313, 269);
            this.groupBox1.TabIndex = 12;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "groupBox1";
            // 
            // FormXemChiTiet
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 19F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(868, 477);
            this.Controls.Add(this.groupThongTinChiTiet);
            this.Name = "FormXemChiTiet";
            this.Text = "FormXemChiTiet";
            this.Deactivate += new System.EventHandler(this.FormXemChiTiet_Deactivate);
            this.Load += new System.EventHandler(this.FormXemChiTiet_Load);
            this.groupThongTinChiTiet.ResumeLayout(false);
            this.groupThongTinChiTiet.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.GroupBox groupThongTinChiTiet;
        private System.Windows.Forms.Label lbTen;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label txtTen;
        private System.Windows.Forms.Label txtNgay;
        private System.Windows.Forms.Label txtGioRa;
        private System.Windows.Forms.Label txtGioVao;
        private System.Windows.Forms.Label txtCong;
        private System.Windows.Forms.Label txtCa;
        private System.Windows.Forms.GroupBox groupBox1;
    }
}