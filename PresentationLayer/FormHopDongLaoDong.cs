using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BusinessLayer;
using TransferObject;
using DevExpress.XtraReports.UI;

namespace PresentationLayer 
{
    public partial class FormHopDongLaoDong : DevExpress.XtraEditors.XtraForm
    {
        HDLaoDongBL hdlaodongBL;
        HDLaoDong hdld;
        NhanVienBL nhanvienBL;
        bool _them;
        string _soHD;
        int _deletedBy;
        int _idHopDong;
        public FormHopDongLaoDong()
        {
            InitializeComponent();
            hdlaodongBL = new HDLaoDongBL();
            nhanvienBL=new NhanVienBL();

        }



        private void frmHopDongLaoDong_Load(object sender, EventArgs e)
        {
            try
            {
                gcHDLaoDong.DataSource = hdlaodongBL.GetHopDongsWithNhanVien();
                gvHDLaoDong.OptionsBehavior.Editable = false;
            }
            catch (SqlException ex)
            {
                MessageBox.Show(ex.Message);
            }
            _showHide(true);
            splitContainer1.Panel1Collapsed = true;
            loadNhanVien();
        }

        void loadNhanVien()
        {
            slkNhanVien.Properties.DataSource=nhanvienBL.getNhanViens();
            slkNhanVien.Properties.ValueMember = "IdNhanVien";
            slkNhanVien.Properties.DisplayMember = "HoTen";
        }

        private void btnThem_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            _showHide(false);
            _them = true;
            _reset();
            splitContainer1.Panel1Collapsed = false;

            HDLaoDongBL hdlaodongBL = new HDLaoDongBL();
            txtSoHD.Text = hdlaodongBL.GetAvailableSoHD();
        }

        private void btnSua_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            _showHide(false);
            _them = false;
            gcHDLaoDong.Enabled = true;
            splitContainer1.Panel1Collapsed = false;
        }

        private void btnXoa_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (MessageBox.Show("Bạn có chắc chắn xóa không?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
            {
                try
                {
                    // Lấy SoHD từ dòng đang chọn
                    _soHD = gvHDLaoDong.GetFocusedRowCellValue("SoHD").ToString();
                    _deletedBy = 1;
                    hdlaodongBL.Delete(_soHD,_deletedBy);
                    MessageBox.Show("Đã đánh dấu xóa thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    // Cập nhật lại dữ liệu bảng
                    gcHDLaoDong.DataSource = hdlaodongBL.GetHopDongsWithNhanVien();
                }
                catch (SqlException ex)
                {
                    MessageBox.Show("Lỗi khi xóa: " + ex.Message);
                }

            }
        }

        private void btnLuu_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            SaveData();
            _them = false;
            _showHide(true);
            splitContainer1.Panel1Collapsed = true;
        }

        private void btnHuy_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            _them = false;
            _showHide(true);
            splitContainer1.Panel1Collapsed = true;
        }

        private void btnIn_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {

            if (gvHDLaoDong.RowCount > 0)
            {
                string soHD = gvHDLaoDong.GetFocusedRowCellValue("SoHD").ToString();
                HDLaoDongBL hdlaodongBL = new HDLaoDongBL();

                HDLaoDong hdld = hdlaodongBL.GetHopDongBySoHD(soHD); 
                List<HDLaoDong> lstHD = new List<HDLaoDong> { hdld }; 

                rptHDLaoDong rpt = new rptHDLaoDong(lstHD); 
                rpt.ShowPreviewDialog();
            }
        }

        private void btDong_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            this.Close();
        }

        void _showHide(bool kt)
        {
            btnLuu.Enabled = !kt;
            btnHuy.Enabled = !kt;
            btnThem.Enabled = kt;
            btnSua.Enabled = kt;
            btnXoa.Enabled = kt;
            btnDong.Enabled = kt;
            btnIn.Enabled = kt;
            gcHDLaoDong.Enabled = kt;
            txtSoHD.Enabled = !kt;
            dtNgayBatDau.Enabled = !kt;
            dtNgayKetThuc.Enabled = !kt;
            dtNgayKy.Enabled = !kt;
            spHSLuong.Enabled = !kt;
            spLanKy.Enabled = !kt;
            slkNhanVien.Enabled = !kt;
        }
        void _reset()
        {
            txtSoHD.Text = string.Empty;
            dtNgayBatDau.Value = DateTime.Now;
            dtNgayKetThuc.Value = dtNgayBatDau.Value.AddMonths(6);
            dtNgayKy.Value = DateTime.Now;
            spLanKy.Text = "1";
            spHSLuong.Text = "1";
        }
        void SaveData()
        {
            if (_them)
            {
                hdld = new HDLaoDong();
                hdld.SoHD = txtSoHD.Text;
                hdld.NgayBatDau = dtNgayBatDau.Value;
                hdld.NgayKetThuc = dtNgayKetThuc.Value;
                hdld.NgayKy = dtNgayKy.Value;
                hdld.LanKy = int.Parse(spLanKy.EditValue.ToString());
                hdld.ThoiHan = cboThoiHan.Text;
                hdld.NoiDung = txtNoiDung.RtfText;
                hdld.HeSoLuong = float.Parse(spHSLuong.EditValue.ToString());
                hdld.LuongCoBan = int.Parse(spLuongCoBan.EditValue.ToString());
                hdld.IdNhanVien = Convert.ToInt32(slkNhanVien.EditValue.ToString());
                hdld.Created_By = 1; 
                hdld.Created_Date = DateTime.Now;

                hdlaodongBL.Add(hdld);
            }
            else
            {
                hdld = new HDLaoDong();
                hdld.SoHD = txtSoHD.Text;
                hdld.NgayBatDau = dtNgayBatDau.Value;
                hdld.NgayKetThuc = dtNgayKetThuc.Value;
                hdld.NgayKy = dtNgayKy.Value;
                hdld.LanKy = int.Parse(spLanKy.EditValue.ToString());
                hdld.ThoiHan = cboThoiHan.Text;
                hdld.NoiDung=txtNoiDung.RtfText;
                hdld.HeSoLuong = float.Parse(spHSLuong.EditValue.ToString());
                hdld.LuongCoBan = int.Parse(spLuongCoBan.EditValue.ToString());
                hdld.IdNhanVien = Convert.ToInt32(slkNhanVien.EditValue);
                hdld.Updated_By = 1; 
                hdld.Updated_Date = DateTime.Now;

                hdlaodongBL.Update(hdld);
            }

            // Sau khi lưu xong load lại
            gcHDLaoDong.DataSource = hdlaodongBL.GetHopDongsWithNhanVien();
        }

        private void gvHDLaoDong_Click(object sender, EventArgs e)
        {
            if (gvHDLaoDong.RowCount > 0)
            {
                _idHopDong = int.Parse(gvHDLaoDong.GetFocusedRowCellValue("IdHopDong").ToString());
                txtSoHD.Text = gvHDLaoDong.GetFocusedRowCellValue("SoHD").ToString();
                dtNgayBatDau.Value = Convert.ToDateTime(gvHDLaoDong.GetFocusedRowCellValue("NgayBatDau"));
                dtNgayKetThuc.Value = Convert.ToDateTime(gvHDLaoDong.GetFocusedRowCellValue("NgayKetThuc"));
                dtNgayKy.Value = Convert.ToDateTime(gvHDLaoDong.GetFocusedRowCellValue("NgayKy"));
                txtNoiDung.RtfText = gvHDLaoDong.GetFocusedRowCellValue("NoiDung").ToString();
                spHSLuong.Value = Convert.ToDecimal(gvHDLaoDong.GetFocusedRowCellValue("HeSoLuong"));
                spLuongCoBan.Value = int.Parse(gvHDLaoDong.GetFocusedRowCellValue("LuongCoBan").ToString());
                spLanKy.Value = int.Parse(gvHDLaoDong.GetFocusedRowCellValue("LanKy").ToString());
                slkNhanVien.EditValue = int.Parse(gvHDLaoDong.GetFocusedRowCellValue("IdNhanVien").ToString());
            }
        }



    }

}
