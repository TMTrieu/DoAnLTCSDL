namespace PresentationLayer
{
    partial class FormDuyetThoiViec
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
            this.txtGhiChu = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.btnPheDuyet = new DevExpress.XtraEditors.SimpleButton();
            this.btnTuChoi = new DevExpress.XtraEditors.SimpleButton();
            this.dgcYeuCau = new DevExpress.XtraGrid.GridControl();
            this.dgvYeuCau = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.IdYeuCau = new DevExpress.XtraGrid.Columns.GridColumn();
            this.IdNhanVien = new DevExpress.XtraGrid.Columns.GridColumn();
            this.NgayYeuCau = new DevExpress.XtraGrid.Columns.GridColumn();
            this.LyDo = new DevExpress.XtraGrid.Columns.GridColumn();
            this.LoaiLyDo = new DevExpress.XtraGrid.Columns.GridColumn();
            this.TrangThai = new DevExpress.XtraGrid.Columns.GridColumn();
            this.NgayPheDuyet = new DevExpress.XtraGrid.Columns.GridColumn();
            this.GhiChu = new DevExpress.XtraGrid.Columns.GridColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dgcYeuCau)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvYeuCau)).BeginInit();
            this.SuspendLayout();
            // 
            // txtGhiChu
            // 
            this.txtGhiChu.Font = new System.Drawing.Font("Tahoma", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtGhiChu.Location = new System.Drawing.Point(147, 49);
            this.txtGhiChu.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txtGhiChu.Name = "txtGhiChu";
            this.txtGhiChu.Size = new System.Drawing.Size(602, 32);
            this.txtGhiChu.TabIndex = 0;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Tahoma", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(33, 49);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(89, 24);
            this.label2.TabIndex = 1;
            this.label2.Text = "Ghi chú: ";
            // 
            // btnPheDuyet
            // 
            this.btnPheDuyet.Appearance.Font = new System.Drawing.Font("Tahoma", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnPheDuyet.Appearance.Options.UseFont = true;
            this.btnPheDuyet.Location = new System.Drawing.Point(147, 106);
            this.btnPheDuyet.Margin = new System.Windows.Forms.Padding(6);
            this.btnPheDuyet.Name = "btnPheDuyet";
            this.btnPheDuyet.Size = new System.Drawing.Size(189, 49);
            this.btnPheDuyet.TabIndex = 2;
            this.btnPheDuyet.Text = "Phê duyệt";
            this.btnPheDuyet.Click += new System.EventHandler(this.btnPheDuyet_Click);
            // 
            // btnTuChoi
            // 
            this.btnTuChoi.Appearance.Font = new System.Drawing.Font("Tahoma", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnTuChoi.Appearance.Options.UseFont = true;
            this.btnTuChoi.Location = new System.Drawing.Point(554, 106);
            this.btnTuChoi.Margin = new System.Windows.Forms.Padding(9, 10, 9, 10);
            this.btnTuChoi.Name = "btnTuChoi";
            this.btnTuChoi.Size = new System.Drawing.Size(194, 49);
            this.btnTuChoi.TabIndex = 3;
            this.btnTuChoi.Text = "Từ chối";
            this.btnTuChoi.Click += new System.EventHandler(this.btnTuChoi_Click);
            // 
            // dgcYeuCau
            // 
            this.dgcYeuCau.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.dgcYeuCau.EmbeddedNavigator.Margin = new System.Windows.Forms.Padding(6);
            this.dgcYeuCau.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Bold);
            this.dgcYeuCau.Location = new System.Drawing.Point(0, 291);
            this.dgcYeuCau.MainView = this.dgvYeuCau;
            this.dgcYeuCau.Margin = new System.Windows.Forms.Padding(6);
            this.dgcYeuCau.Name = "dgcYeuCau";
            this.dgcYeuCau.Size = new System.Drawing.Size(1599, 393);
            this.dgcYeuCau.TabIndex = 4;
            this.dgcYeuCau.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.dgvYeuCau});
            // 
            // dgvYeuCau
            // 
            this.dgvYeuCau.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.IdYeuCau,
            this.IdNhanVien,
            this.NgayYeuCau,
            this.LyDo,
            this.LoaiLyDo,
            this.TrangThai,
            this.NgayPheDuyet,
            this.GhiChu});
            this.dgvYeuCau.DetailHeight = 525;
            this.dgvYeuCau.GridControl = this.dgcYeuCau;
            this.dgvYeuCau.Name = "dgvYeuCau";
            this.dgvYeuCau.OptionsEditForm.PopupEditFormWidth = 1200;
            this.dgvYeuCau.OptionsView.ColumnAutoWidth = false;
            // 
            // IdYeuCau
            // 
            this.IdYeuCau.AppearanceHeader.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Bold);
            this.IdYeuCau.AppearanceHeader.Options.UseFont = true;
            this.IdYeuCau.Caption = "Id";
            this.IdYeuCau.FieldName = "IdYeuCau";
            this.IdYeuCau.MinWidth = 45;
            this.IdYeuCau.Name = "IdYeuCau";
            this.IdYeuCau.Visible = true;
            this.IdYeuCau.VisibleIndex = 0;
            this.IdYeuCau.Width = 125;
            // 
            // IdNhanVien
            // 
            this.IdNhanVien.AppearanceHeader.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Bold);
            this.IdNhanVien.AppearanceHeader.Options.UseFont = true;
            this.IdNhanVien.Caption = "IdNhanVien";
            this.IdNhanVien.FieldName = "IdNhanVien";
            this.IdNhanVien.MinWidth = 45;
            this.IdNhanVien.Name = "IdNhanVien";
            this.IdNhanVien.Visible = true;
            this.IdNhanVien.VisibleIndex = 1;
            this.IdNhanVien.Width = 125;
            // 
            // NgayYeuCau
            // 
            this.NgayYeuCau.AppearanceHeader.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Bold);
            this.NgayYeuCau.AppearanceHeader.Options.UseFont = true;
            this.NgayYeuCau.Caption = "Ngày yêu cầu";
            this.NgayYeuCau.FieldName = "NgayYeuCau";
            this.NgayYeuCau.MinWidth = 45;
            this.NgayYeuCau.Name = "NgayYeuCau";
            this.NgayYeuCau.Visible = true;
            this.NgayYeuCau.VisibleIndex = 2;
            this.NgayYeuCau.Width = 277;
            // 
            // LyDo
            // 
            this.LyDo.AppearanceHeader.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Bold);
            this.LyDo.AppearanceHeader.Options.UseFont = true;
            this.LyDo.Caption = "Lý do";
            this.LyDo.FieldName = "LyDo";
            this.LyDo.MinWidth = 30;
            this.LyDo.Name = "LyDo";
            this.LyDo.Visible = true;
            this.LyDo.VisibleIndex = 3;
            this.LyDo.Width = 138;
            // 
            // LoaiLyDo
            // 
            this.LoaiLyDo.AppearanceHeader.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Bold);
            this.LoaiLyDo.AppearanceHeader.Options.UseFont = true;
            this.LoaiLyDo.Caption = "Loại lý do";
            this.LoaiLyDo.FieldName = "LoaiLyDo";
            this.LoaiLyDo.MinWidth = 30;
            this.LoaiLyDo.Name = "LoaiLyDo";
            this.LoaiLyDo.Visible = true;
            this.LoaiLyDo.VisibleIndex = 4;
            this.LoaiLyDo.Width = 150;
            // 
            // TrangThai
            // 
            this.TrangThai.AppearanceHeader.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Bold);
            this.TrangThai.AppearanceHeader.Options.UseFont = true;
            this.TrangThai.Caption = "Trạng thái";
            this.TrangThai.FieldName = "TrangThai";
            this.TrangThai.MinWidth = 45;
            this.TrangThai.Name = "TrangThai";
            this.TrangThai.Visible = true;
            this.TrangThai.VisibleIndex = 5;
            this.TrangThai.Width = 202;
            // 
            // NgayPheDuyet
            // 
            this.NgayPheDuyet.AppearanceHeader.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Bold);
            this.NgayPheDuyet.AppearanceHeader.Options.UseFont = true;
            this.NgayPheDuyet.Caption = "Ngày phê duyệt";
            this.NgayPheDuyet.FieldName = "NgayPheDuyet";
            this.NgayPheDuyet.MinWidth = 45;
            this.NgayPheDuyet.Name = "NgayPheDuyet";
            this.NgayPheDuyet.Visible = true;
            this.NgayPheDuyet.VisibleIndex = 6;
            this.NgayPheDuyet.Width = 264;
            // 
            // GhiChu
            // 
            this.GhiChu.AppearanceHeader.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Bold);
            this.GhiChu.AppearanceHeader.Options.UseFont = true;
            this.GhiChu.Caption = "Ghi chú";
            this.GhiChu.FieldName = "GhiChu";
            this.GhiChu.MinWidth = 45;
            this.GhiChu.Name = "GhiChu";
            this.GhiChu.Visible = true;
            this.GhiChu.VisibleIndex = 7;
            this.GhiChu.Width = 224;
            // 
            // FormDuyetThoiViec
            // 
            this.Appearance.BackColor = System.Drawing.Color.SteelBlue;
            this.Appearance.Options.UseBackColor = true;
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 19F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1599, 684);
            this.Controls.Add(this.dgcYeuCau);
            this.Controls.Add(this.btnTuChoi);
            this.Controls.Add(this.btnPheDuyet);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtGhiChu);
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "FormDuyetThoiViec";
            this.Text = "Thôi việc";
            this.Load += new System.EventHandler(this.FormDuyetThoiViec_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgcYeuCau)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvYeuCau)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.TextBox txtGhiChu;
        private System.Windows.Forms.Label label2;
        private DevExpress.XtraEditors.SimpleButton btnPheDuyet;
        private DevExpress.XtraEditors.SimpleButton btnTuChoi;
        private DevExpress.XtraGrid.GridControl dgcYeuCau;
        private DevExpress.XtraGrid.Views.Grid.GridView dgvYeuCau;
        private DevExpress.XtraGrid.Columns.GridColumn IdYeuCau;
        private DevExpress.XtraGrid.Columns.GridColumn IdNhanVien;
        private DevExpress.XtraGrid.Columns.GridColumn NgayYeuCau;
        private DevExpress.XtraGrid.Columns.GridColumn TrangThai;
        private DevExpress.XtraGrid.Columns.GridColumn NgayPheDuyet;
        private DevExpress.XtraGrid.Columns.GridColumn GhiChu;
        private DevExpress.XtraGrid.Columns.GridColumn LyDo;
        private DevExpress.XtraGrid.Columns.GridColumn LoaiLyDo;
    }
}