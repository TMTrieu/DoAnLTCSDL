using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using DevExpress.XtraReports.UI;
using TransferObject;
using BusinessLayer;

namespace QuanLyNhanSu.Reports
{
    public partial class rptDSNhanVien : DevExpress.XtraReports.UI.XtraReport
    {
        public rptDSNhanVien()
        {
            InitializeComponent();
        }
        List<NhanVien> _nhanViens;
        public rptDSNhanVien(List<NhanVien> nhanViens)
        {
            InitializeComponent();
            this._nhanViens = nhanViens; 
            this.DataSource = _nhanViens;
            loadData();
        }
        void loadData()
        {
            lbIdNhanVien.DataBindings.Add("Text", _nhanViens, "IdNhanVien");
            lbTenNhanVien.DataBindings.Add("Text", _nhanViens, "HoTen");
            lbGioiTinh.DataBindings.Add("Text", _nhanViens, "GioiTinh");
            lbNgaySinh.DataBindings.Add("Text", _nhanViens, "NgaySinh");
            lbCccd.DataBindings.Add("Text", _nhanViens, "CCCD");
            lbDienThoai.DataBindings.Add("Text", _nhanViens, "DienThoai");
            lbPhongBan.DataBindings.Add("Text", _nhanViens, "TenPhongBan");
            lbBoPhan.DataBindings.Add("Text", _nhanViens, "TenBoPhan");
            lbChucVu.DataBindings.Add("Text", _nhanViens, "TenChucVu");
            lbTrinhDo.DataBindings.Add("Text", _nhanViens, "TenTrinhDo");
            lbDanToc.DataBindings.Add("Text", _nhanViens, "TenDanToc");
            lbTonGiao.DataBindings.Add("Text", _nhanViens, "TenTonGiao");
            lbDiaChi.DataBindings.Add("Text", _nhanViens, "DiaChi");
        }
    }
}
