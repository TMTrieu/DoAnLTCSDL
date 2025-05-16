namespace PresentationLayer
{
    partial class FormYeuCauThoiViec
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
            this.btGuiYeuCau = new DevExpress.XtraEditors.SimpleButton();
            this.txtLyDo = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.dgcYeuCau = new DevExpress.XtraGrid.GridControl();
            this.dgvYeuCau = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.NgayYeuCau = new DevExpress.XtraGrid.Columns.GridColumn();
            this.LyDo = new DevExpress.XtraGrid.Columns.GridColumn();
            this.TrangThai = new DevExpress.XtraGrid.Columns.GridColumn();
            this.NgayPheDuyet = new DevExpress.XtraGrid.Columns.GridColumn();
            this.GhiChu = new DevExpress.XtraGrid.Columns.GridColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dgcYeuCau)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvYeuCau)).BeginInit();
            this.SuspendLayout();
            // 
            // btGuiYeuCau
            // 
            this.btGuiYeuCau.Appearance.Font = new System.Drawing.Font("Tahoma", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btGuiYeuCau.Appearance.Options.UseFont = true;
            this.btGuiYeuCau.Location = new System.Drawing.Point(138, 106);
            this.btGuiYeuCau.Margin = new System.Windows.Forms.Padding(27);
            this.btGuiYeuCau.Name = "btGuiYeuCau";
            this.btGuiYeuCau.Size = new System.Drawing.Size(147, 57);
            this.btGuiYeuCau.TabIndex = 5;
            this.btGuiYeuCau.Text = "Gửi yêu cầu";
            this.btGuiYeuCau.Click += new System.EventHandler(this.btGuiYeuCau_Click);
            // 
            // txtLyDo
            // 
            this.txtLyDo.Font = new System.Drawing.Font("Tahoma", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtLyDo.Location = new System.Drawing.Point(138, 49);
            this.txtLyDo.Margin = new System.Windows.Forms.Padding(4);
            this.txtLyDo.Multiline = true;
            this.txtLyDo.Name = "txtLyDo";
            this.txtLyDo.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtLyDo.Size = new System.Drawing.Size(556, 27);
            this.txtLyDo.TabIndex = 4;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Tahoma", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(30, 49);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(65, 24);
            this.label1.TabIndex = 3;
            this.label1.Text = "Lý do:";
            // 
            // dgcYeuCau
            // 
            this.dgcYeuCau.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.dgcYeuCau.EmbeddedNavigator.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.dgcYeuCau.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Bold);
            this.dgcYeuCau.Location = new System.Drawing.Point(0, 289);
            this.dgcYeuCau.MainView = this.dgvYeuCau;
            this.dgcYeuCau.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.dgcYeuCau.Name = "dgcYeuCau";
            this.dgcYeuCau.Size = new System.Drawing.Size(1444, 281);
            this.dgcYeuCau.TabIndex = 6;
            this.dgcYeuCau.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.dgvYeuCau});
            // 
            // dgvYeuCau
            // 
            this.dgvYeuCau.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.NgayYeuCau,
            this.LyDo,
            this.TrangThai,
            this.NgayPheDuyet,
            this.GhiChu});
            this.dgvYeuCau.GridControl = this.dgcYeuCau;
            this.dgvYeuCau.Name = "dgvYeuCau";
            this.dgvYeuCau.OptionsView.ColumnAutoWidth = false;
            // 
            // NgayYeuCau
            // 
            this.NgayYeuCau.AppearanceHeader.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Bold);
            this.NgayYeuCau.AppearanceHeader.Options.UseFont = true;
            this.NgayYeuCau.Caption = "Ngày yêu cầu";
            this.NgayYeuCau.FieldName = "NgayYeuCau";
            this.NgayYeuCau.MinWidth = 30;
            this.NgayYeuCau.Name = "NgayYeuCau";
            this.NgayYeuCau.Visible = true;
            this.NgayYeuCau.VisibleIndex = 0;
            this.NgayYeuCau.Width = 150;
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
            this.LyDo.VisibleIndex = 1;
            this.LyDo.Width = 300;
            // 
            // TrangThai
            // 
            this.TrangThai.AppearanceHeader.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Bold);
            this.TrangThai.AppearanceHeader.Options.UseFont = true;
            this.TrangThai.Caption = "Trạng thái";
            this.TrangThai.FieldName = "TrangThai";
            this.TrangThai.MinWidth = 30;
            this.TrangThai.Name = "TrangThai";
            this.TrangThai.Visible = true;
            this.TrangThai.VisibleIndex = 2;
            this.TrangThai.Width = 200;
            // 
            // NgayPheDuyet
            // 
            this.NgayPheDuyet.AppearanceHeader.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Bold);
            this.NgayPheDuyet.AppearanceHeader.Options.UseFont = true;
            this.NgayPheDuyet.Caption = "Ngày phê duyệt";
            this.NgayPheDuyet.FieldName = "NgayPheDuyet";
            this.NgayPheDuyet.MinWidth = 30;
            this.NgayPheDuyet.Name = "NgayPheDuyet";
            this.NgayPheDuyet.Visible = true;
            this.NgayPheDuyet.VisibleIndex = 3;
            this.NgayPheDuyet.Width = 200;
            // 
            // GhiChu
            // 
            this.GhiChu.AppearanceHeader.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Bold);
            this.GhiChu.AppearanceHeader.Options.UseFont = true;
            this.GhiChu.Caption = "Ghi chú";
            this.GhiChu.FieldName = "GhiChu";
            this.GhiChu.MinWidth = 30;
            this.GhiChu.Name = "GhiChu";
            this.GhiChu.Visible = true;
            this.GhiChu.VisibleIndex = 4;
            this.GhiChu.Width = 500;
            // 
            // FormYeuCauThoiViec
            // 
            this.Appearance.BackColor = System.Drawing.Color.SteelBlue;
            this.Appearance.Options.UseBackColor = true;
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 19F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1444, 570);
            this.Controls.Add(this.dgcYeuCau);
            this.Controls.Add(this.btGuiYeuCau);
            this.Controls.Add(this.txtLyDo);
            this.Controls.Add(this.label1);
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "FormYeuCauThoiViec";
            this.Text = "Thôi việc";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.FormYeuCauThoiViec_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgcYeuCau)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvYeuCau)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraEditors.SimpleButton btGuiYeuCau;
        private System.Windows.Forms.TextBox txtLyDo;
        private System.Windows.Forms.Label label1;
        private DevExpress.XtraGrid.GridControl dgcYeuCau;
        private DevExpress.XtraGrid.Views.Grid.GridView dgvYeuCau;
        private DevExpress.XtraGrid.Columns.GridColumn NgayYeuCau;
        private DevExpress.XtraGrid.Columns.GridColumn LyDo;
        private DevExpress.XtraGrid.Columns.GridColumn TrangThai;
        private DevExpress.XtraGrid.Columns.GridColumn NgayPheDuyet;
        private DevExpress.XtraGrid.Columns.GridColumn GhiChu;
    }
}