namespace PresentationLayer
{
    partial class MainForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.ribbon = new DevExpress.XtraBars.Ribbon.RibbonControl();
            this.btDanToc = new DevExpress.XtraBars.BarButtonItem();
            this.btTonGiao = new DevExpress.XtraBars.BarButtonItem();
            this.btTrinhDo = new DevExpress.XtraBars.BarButtonItem();
            this.btPhongBan = new DevExpress.XtraBars.BarButtonItem();
            this.btNhanVien = new DevExpress.XtraBars.BarButtonItem();
            this.btHopDong = new DevExpress.XtraBars.BarButtonItem();
            this.btKhenThuongKyLuat = new DevExpress.XtraBars.BarButtonItem();
            this.btDieuChuyen = new DevExpress.XtraBars.BarButtonItem();
            this.btThoiViec = new DevExpress.XtraBars.BarButtonItem();
            this.btLoaiCa = new DevExpress.XtraBars.BarButtonItem();
            this.btLoaiCong = new DevExpress.XtraBars.BarButtonItem();
            this.btPhuCap = new DevExpress.XtraBars.BarButtonItem();
            this.btTangCa = new DevExpress.XtraBars.BarButtonItem();
            this.btUngLuong = new DevExpress.XtraBars.BarButtonItem();
            this.btBangCong = new DevExpress.XtraBars.BarButtonItem();
            this.btBangLuong = new DevExpress.XtraBars.BarButtonItem();
            this.btDoiMatKhau = new DevExpress.XtraBars.BarButtonItem();
            this.btSaoLuuDuLieu = new DevExpress.XtraBars.BarButtonItem();
            this.btPhucHoiDuLieu = new DevExpress.XtraBars.BarButtonItem();
            this.btThoat = new DevExpress.XtraBars.BarButtonItem();
            this.btChucVu = new DevExpress.XtraBars.BarButtonItem();
            this.btBoPhan = new DevExpress.XtraBars.BarButtonItem();
            this.ribbonPage1 = new DevExpress.XtraBars.Ribbon.RibbonPage();
            this.ribbonPageGroup3 = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            this.ribbonPage2 = new DevExpress.XtraBars.Ribbon.RibbonPage();
            this.ribbonPageGroup2 = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            this.ribbonPageGroup4 = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            this.ribbonPage4 = new DevExpress.XtraBars.Ribbon.RibbonPage();
            this.ribbonPageGroup6 = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            this.ribbonPage3 = new DevExpress.XtraBars.Ribbon.RibbonPage();
            this.ribbonPageGroup5 = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            this.ribbonStatusBar = new DevExpress.XtraBars.Ribbon.RibbonStatusBar();
            this.ribbonPageGroup1 = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            this.documentManager1 = new DevExpress.XtraBars.Docking2010.DocumentManager(this.components);
            this.tabbedView1 = new DevExpress.XtraBars.Docking2010.Views.Tabbed.TabbedView(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.ribbon)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.documentManager1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tabbedView1)).BeginInit();
            this.SuspendLayout();
            // 
            // ribbon
            // 
            this.ribbon.ExpandCollapseItem.Id = 0;
            this.ribbon.Items.AddRange(new DevExpress.XtraBars.BarItem[] {
            this.ribbon.ExpandCollapseItem,
            this.btDanToc,
            this.btTonGiao,
            this.btTrinhDo,
            this.btPhongBan,
            this.btNhanVien,
            this.btHopDong,
            this.btKhenThuongKyLuat,
            this.btDieuChuyen,
            this.btThoiViec,
            this.btLoaiCa,
            this.btLoaiCong,
            this.btPhuCap,
            this.btTangCa,
            this.btUngLuong,
            this.btBangCong,
            this.btBangLuong,
            this.btDoiMatKhau,
            this.btSaoLuuDuLieu,
            this.btPhucHoiDuLieu,
            this.btThoat,
            this.btChucVu,
            this.btBoPhan});
            this.ribbon.Location = new System.Drawing.Point(0, 0);
            this.ribbon.MaxItemId = 29;
            this.ribbon.Name = "ribbon";
            this.ribbon.Pages.AddRange(new DevExpress.XtraBars.Ribbon.RibbonPage[] {
            this.ribbonPage1,
            this.ribbonPage2,
            this.ribbonPage4,
            this.ribbonPage3});
            this.ribbon.Size = new System.Drawing.Size(1262, 231);
            this.ribbon.StatusBar = this.ribbonStatusBar;
            // 
            // btDanToc
            // 
            this.btDanToc.Caption = "Dân tộc";
            this.btDanToc.Id = 4;
            this.btDanToc.ImageOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("btDanToc.ImageOptions.SvgImage")));
            this.btDanToc.Name = "btDanToc";
            this.btDanToc.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btDanToc_ItemClick);
            // 
            // btTonGiao
            // 
            this.btTonGiao.Caption = "Tôn giáo";
            this.btTonGiao.Id = 5;
            this.btTonGiao.ImageOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("btTonGiao.ImageOptions.SvgImage")));
            this.btTonGiao.Name = "btTonGiao";
            // 
            // btTrinhDo
            // 
            this.btTrinhDo.Caption = "Trình độ";
            this.btTrinhDo.Id = 6;
            this.btTrinhDo.ImageOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("btTrinhDo.ImageOptions.SvgImage")));
            this.btTrinhDo.Name = "btTrinhDo";
            // 
            // btPhongBan
            // 
            this.btPhongBan.Caption = "Phòng ban";
            this.btPhongBan.Id = 7;
            this.btPhongBan.ImageOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("btPhongBan.ImageOptions.SvgImage")));
            this.btPhongBan.Name = "btPhongBan";
            this.btPhongBan.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btPhongBan_ItemClick);
            // 
            // btNhanVien
            // 
            this.btNhanVien.Caption = "Nhân viên";
            this.btNhanVien.Id = 8;
            this.btNhanVien.ImageOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("btNhanVien.ImageOptions.SvgImage")));
            this.btNhanVien.Name = "btNhanVien";
            // 
            // btHopDong
            // 
            this.btHopDong.Caption = "Hợp đồng";
            this.btHopDong.Id = 9;
            this.btHopDong.ImageOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("btHopDong.ImageOptions.SvgImage")));
            this.btHopDong.Name = "btHopDong";
            // 
            // btKhenThuongKyLuat
            // 
            this.btKhenThuongKyLuat.Caption = "Khen thưởng - Kỷ luật";
            this.btKhenThuongKyLuat.Id = 10;
            this.btKhenThuongKyLuat.ImageOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("btKhenThuongKyLuat.ImageOptions.SvgImage")));
            this.btKhenThuongKyLuat.Name = "btKhenThuongKyLuat";
            // 
            // btDieuChuyen
            // 
            this.btDieuChuyen.Caption = "Điều chuyển";
            this.btDieuChuyen.Id = 11;
            this.btDieuChuyen.ImageOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("btDieuChuyen.ImageOptions.SvgImage")));
            this.btDieuChuyen.Name = "btDieuChuyen";
            // 
            // btThoiViec
            // 
            this.btThoiViec.Caption = "Thôi việc";
            this.btThoiViec.Id = 12;
            this.btThoiViec.ImageOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("btThoiViec.ImageOptions.SvgImage")));
            this.btThoiViec.Name = "btThoiViec";
            // 
            // btLoaiCa
            // 
            this.btLoaiCa.Caption = "Loại ca";
            this.btLoaiCa.Id = 13;
            this.btLoaiCa.Name = "btLoaiCa";
            this.btLoaiCa.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btLoaiCa_ItemClick);
            // 
            // btLoaiCong
            // 
            this.btLoaiCong.Caption = "Loại công";
            this.btLoaiCong.Id = 14;
            this.btLoaiCong.Name = "btLoaiCong";
            this.btLoaiCong.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btLoaiCong_ItemClick);
            // 
            // btPhuCap
            // 
            this.btPhuCap.Caption = "Phụ cấp";
            this.btPhuCap.Id = 15;
            this.btPhuCap.Name = "btPhuCap";
            // 
            // btTangCa
            // 
            this.btTangCa.Caption = "Tăng ca";
            this.btTangCa.Id = 16;
            this.btTangCa.Name = "btTangCa";
            // 
            // btUngLuong
            // 
            this.btUngLuong.Caption = "Ứng lương";
            this.btUngLuong.Id = 17;
            this.btUngLuong.Name = "btUngLuong";
            // 
            // btBangCong
            // 
            this.btBangCong.Caption = "Bảng công";
            this.btBangCong.Id = 18;
            this.btBangCong.Name = "btBangCong";
            // 
            // btBangLuong
            // 
            this.btBangLuong.Caption = "Bảng lương";
            this.btBangLuong.Id = 19;
            this.btBangLuong.Name = "btBangLuong";
            // 
            // btDoiMatKhau
            // 
            this.btDoiMatKhau.Caption = "Đổi mật khẩu";
            this.btDoiMatKhau.Id = 20;
            this.btDoiMatKhau.ImageOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("btDoiMatKhau.ImageOptions.SvgImage")));
            this.btDoiMatKhau.Name = "btDoiMatKhau";
            // 
            // btSaoLuuDuLieu
            // 
            this.btSaoLuuDuLieu.Caption = "Sao lưu dữ liệu";
            this.btSaoLuuDuLieu.Id = 21;
            this.btSaoLuuDuLieu.ImageOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("btSaoLuuDuLieu.ImageOptions.SvgImage")));
            this.btSaoLuuDuLieu.Name = "btSaoLuuDuLieu";
            // 
            // btPhucHoiDuLieu
            // 
            this.btPhucHoiDuLieu.Caption = "Phục hồi dữ liệu";
            this.btPhucHoiDuLieu.Id = 22;
            this.btPhucHoiDuLieu.ImageOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("btPhucHoiDuLieu.ImageOptions.SvgImage")));
            this.btPhucHoiDuLieu.Name = "btPhucHoiDuLieu";
            // 
            // btThoat
            // 
            this.btThoat.Caption = "Thoát";
            this.btThoat.Id = 23;
            this.btThoat.ImageOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("btThoat.ImageOptions.SvgImage")));
            this.btThoat.Name = "btThoat";
            // 
            // btChucVu
            // 
            this.btChucVu.Caption = "Chức vụ";
            this.btChucVu.Id = 27;
            this.btChucVu.ImageOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("btChucVu.ImageOptions.SvgImage")));
            this.btChucVu.Name = "btChucVu";
            this.btChucVu.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btChucVu_ItemClick);
            // 
            // btBoPhan
            // 
            this.btBoPhan.Caption = "Bộ phận";
            this.btBoPhan.Id = 28;
            this.btBoPhan.ImageOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("btBoPhan.ImageOptions.SvgImage")));
            this.btBoPhan.Name = "btBoPhan";
            this.btBoPhan.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btBoPhan_ItemClick);
            // 
            // ribbonPage1
            // 
            this.ribbonPage1.Groups.AddRange(new DevExpress.XtraBars.Ribbon.RibbonPageGroup[] {
            this.ribbonPageGroup3});
            this.ribbonPage1.Name = "ribbonPage1";
            this.ribbonPage1.Text = "Hệ thống";
            // 
            // ribbonPageGroup3
            // 
            this.ribbonPageGroup3.ItemLinks.Add(this.btDoiMatKhau);
            this.ribbonPageGroup3.ItemLinks.Add(this.btSaoLuuDuLieu);
            this.ribbonPageGroup3.ItemLinks.Add(this.btPhucHoiDuLieu);
            this.ribbonPageGroup3.ItemLinks.Add(this.btThoat);
            this.ribbonPageGroup3.Name = "ribbonPageGroup3";
            this.ribbonPageGroup3.Text = "Hệ thống";
            // 
            // ribbonPage2
            // 
            this.ribbonPage2.Groups.AddRange(new DevExpress.XtraBars.Ribbon.RibbonPageGroup[] {
            this.ribbonPageGroup2,
            this.ribbonPageGroup4});
            this.ribbonPage2.Name = "ribbonPage2";
            this.ribbonPage2.Text = "Danh mục";
            // 
            // ribbonPageGroup2
            // 
            this.ribbonPageGroup2.ItemLinks.Add(this.btDanToc);
            this.ribbonPageGroup2.ItemLinks.Add(this.btTonGiao);
            this.ribbonPageGroup2.ItemLinks.Add(this.btTrinhDo);
            this.ribbonPageGroup2.ItemLinks.Add(this.btPhongBan);
            this.ribbonPageGroup2.ItemLinks.Add(this.btNhanVien);
            this.ribbonPageGroup2.ItemLinks.Add(this.btChucVu);
            this.ribbonPageGroup2.ItemLinks.Add(this.btBoPhan);
            this.ribbonPageGroup2.Name = "ribbonPageGroup2";
            this.ribbonPageGroup2.Text = "Danh mục dùng chung";
            // 
            // ribbonPageGroup4
            // 
            this.ribbonPageGroup4.ItemLinks.Add(this.btHopDong);
            this.ribbonPageGroup4.ItemLinks.Add(this.btKhenThuongKyLuat);
            this.ribbonPageGroup4.ItemLinks.Add(this.btDieuChuyen);
            this.ribbonPageGroup4.ItemLinks.Add(this.btThoiViec);
            this.ribbonPageGroup4.Name = "ribbonPageGroup4";
            this.ribbonPageGroup4.Text = "Nghiệp vụ";
            // 
            // ribbonPage4
            // 
            this.ribbonPage4.Groups.AddRange(new DevExpress.XtraBars.Ribbon.RibbonPageGroup[] {
            this.ribbonPageGroup6});
            this.ribbonPage4.Name = "ribbonPage4";
            this.ribbonPage4.Text = "Chấm công";
            // 
            // ribbonPageGroup6
            // 
            this.ribbonPageGroup6.ItemLinks.Add(this.btLoaiCa);
            this.ribbonPageGroup6.ItemLinks.Add(this.btLoaiCong);
            this.ribbonPageGroup6.ItemLinks.Add(this.btPhuCap);
            this.ribbonPageGroup6.ItemLinks.Add(this.btTangCa);
            this.ribbonPageGroup6.ItemLinks.Add(this.btUngLuong);
            this.ribbonPageGroup6.ItemLinks.Add(this.btBangCong);
            this.ribbonPageGroup6.ItemLinks.Add(this.btBangLuong);
            this.ribbonPageGroup6.Name = "ribbonPageGroup6";
            this.ribbonPageGroup6.Text = "Quản lý chấm công";
            // 
            // ribbonPage3
            // 
            this.ribbonPage3.Groups.AddRange(new DevExpress.XtraBars.Ribbon.RibbonPageGroup[] {
            this.ribbonPageGroup5});
            this.ribbonPage3.Name = "ribbonPage3";
            this.ribbonPage3.Text = "Bảng biểu";
            // 
            // ribbonPageGroup5
            // 
            this.ribbonPageGroup5.Name = "ribbonPageGroup5";
            this.ribbonPageGroup5.Text = "ribbonPageGroup5";
            // 
            // ribbonStatusBar
            // 
            this.ribbonStatusBar.Location = new System.Drawing.Point(0, 563);
            this.ribbonStatusBar.Name = "ribbonStatusBar";
            this.ribbonStatusBar.Ribbon = this.ribbon;
            this.ribbonStatusBar.Size = new System.Drawing.Size(1262, 36);
            // 
            // ribbonPageGroup1
            // 
            this.ribbonPageGroup1.Name = "ribbonPageGroup1";
            this.ribbonPageGroup1.Text = "ribbonPageGroup1";
            // 
            // documentManager1
            // 
            this.documentManager1.MdiParent = this;
            this.documentManager1.MenuManager = this.ribbon;
            this.documentManager1.View = this.tabbedView1;
            this.documentManager1.ViewCollection.AddRange(new DevExpress.XtraBars.Docking2010.Views.BaseView[] {
            this.tabbedView1});
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 19F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1262, 599);
            this.Controls.Add(this.ribbonStatusBar);
            this.Controls.Add(this.ribbon);
            this.IsMdiContainer = true;
            this.Name = "MainForm";
            this.Ribbon = this.ribbon;
            this.StatusBar = this.ribbonStatusBar;
            this.Text = "Phần mềm quản lý nhân sự";
            this.Load += new System.EventHandler(this.MainForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.ribbon)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.documentManager1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tabbedView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraBars.Ribbon.RibbonControl ribbon;
        private DevExpress.XtraBars.Ribbon.RibbonPage ribbonPage1;
        private DevExpress.XtraBars.Ribbon.RibbonStatusBar ribbonStatusBar;
        
        private DevExpress.XtraBars.Ribbon.RibbonPage ribbonPage2;
        private DevExpress.XtraBars.Ribbon.RibbonPageGroup ribbonPageGroup2;
        private DevExpress.XtraBars.Ribbon.RibbonPageGroup ribbonPageGroup1;
        private DevExpress.XtraBars.BarButtonItem btDanToc;
        private DevExpress.XtraBars.BarButtonItem btTonGiao;
        private DevExpress.XtraBars.BarButtonItem btTrinhDo;
        private DevExpress.XtraBars.BarButtonItem btPhongBan;
        private DevExpress.XtraBars.BarButtonItem btNhanVien;
        private DevExpress.XtraBars.Ribbon.RibbonPageGroup ribbonPageGroup3;
        private DevExpress.XtraBars.Ribbon.RibbonPageGroup ribbonPageGroup4;
        private DevExpress.XtraBars.BarButtonItem btHopDong;
        private DevExpress.XtraBars.BarButtonItem btKhenThuongKyLuat;
        private DevExpress.XtraBars.BarButtonItem btDieuChuyen;
        private DevExpress.XtraBars.BarButtonItem btThoiViec;
        private DevExpress.XtraBars.BarButtonItem btLoaiCa;
        private DevExpress.XtraBars.BarButtonItem btLoaiCong;
        private DevExpress.XtraBars.BarButtonItem btPhuCap;
        private DevExpress.XtraBars.BarButtonItem btTangCa;
        private DevExpress.XtraBars.Ribbon.RibbonPage ribbonPage3;
        private DevExpress.XtraBars.Ribbon.RibbonPageGroup ribbonPageGroup5;
        private DevExpress.XtraBars.Ribbon.RibbonPage ribbonPage4;
        private DevExpress.XtraBars.Ribbon.RibbonPageGroup ribbonPageGroup6;
        private DevExpress.XtraBars.BarButtonItem btUngLuong;
        private DevExpress.XtraBars.BarButtonItem btBangCong;
        private DevExpress.XtraBars.BarButtonItem btBangLuong;
        private DevExpress.XtraBars.BarButtonItem btDoiMatKhau;
        private DevExpress.XtraBars.BarButtonItem btSaoLuuDuLieu;
        private DevExpress.XtraBars.BarButtonItem btPhucHoiDuLieu;
        private DevExpress.XtraBars.BarButtonItem btThoat;
        private DevExpress.XtraBars.Docking2010.DocumentManager documentManager1;
        private DevExpress.XtraBars.Docking2010.Views.Tabbed.TabbedView tabbedView1;
        private DevExpress.XtraBars.BarButtonItem btChucVu;
        private DevExpress.XtraBars.BarButtonItem btBoPhan;
    }
}