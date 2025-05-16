using BusinessLayer;

using DevExpress.XtraEditors;
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
using TransferObject;

namespace PresentationLayer 
{
    public partial class FormTangCa : DevExpress.XtraEditors.XtraForm
    {

        TangCa tangca;
        TangCaBL tangcaBL; 
        NhanVienBL nhanvienBL;
        LoaiCaBL loaicaBL;
        SysConfigBL sysConfigBL;


        int _idTangCa;
        bool _them;
        public FormTangCa()
        {
            InitializeComponent();
            tangcaBL = new TangCaBL();
            loaicaBL = new LoaiCaBL();
            nhanvienBL = new NhanVienBL();
            sysConfigBL = new SysConfigBL();  
        }
        

        private void FormTangCa_Load(object sender, EventArgs e)
        {
            tangca =new TangCa();
            _showHide(true);
            _them = false;
           
            try
            {
                gcDSTangCa.DataSource = tangcaBL.GetTangCas();
                gvDSTangCa.OptionsBehavior.Editable = false;
            }
            catch (SqlException ex)
            {
                MessageBox.Show(ex.Message);
            }

            splitContainer1.Panel1Collapsed = false;
            loadNhanVien();
            loadLoaiCa();
           

        }


        void loadLoaiCa()
        {
            List<LoaiCa> dsLoaiCa = loaicaBL.GetLoaiCas();

            cboLoaiCa.DisplayMember = "TenLoaiCa";
            cboLoaiCa.ValueMember = "IdLoaiCa";
            cboLoaiCa.DataSource = dsLoaiCa;

            if (dsLoaiCa.Count > 0)
                cboLoaiCa.SelectedIndex = 0;
            else
                cboLoaiCa.SelectedIndex = -1;
        }

        void loadNhanVien()
        {
            slkNhanVien.Properties.DataSource = nhanvienBL.getNhanViens();
            slkNhanVien.Properties.ValueMember = "IdNhanVien";
            slkNhanVien.Properties.DisplayMember = "HoTen";
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
            txtGhiChu.Enabled = !kt;
            spSoGio.Enabled = !kt;
            slkNhanVien.Enabled = !kt;
            cboLoaiCa.Enabled = !kt;
        }

        private void btnThem_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            _showHide(false);
            _them = true;
            txtGhiChu.Text=string.Empty;
            spSoGio.EditValue = 0;
            slkNhanVien.EditValue = 0;
            cboLoaiCa.SelectedIndex = 0;
            splitContainer1.Panel1Collapsed = false;
        }

        private void btnSua_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            _them = false;
            _showHide(false) ;
            splitContainer1.Panel1Collapsed = false;
        }

        private void btnXoa_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (MessageBox.Show("Bạn có chắc chắn xóa không?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
            {
                try
                {
                    int id = Convert.ToInt32(gvDSTangCa.GetFocusedRowCellValue("IdTangCa"));
                    tangcaBL.Delete(id);
                    MessageBox.Show("Đã xóa thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    gcDSTangCa.DataSource = tangcaBL.GetTangCas();
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
        void SaveData()
        {
            try
            {
                int idNV = slkNhanVien.EditValue != null ? Convert.ToInt32(slkNhanVien.EditValue) : 0;
                int idLC = cboLoaiCa.SelectedValue != null ? Convert.ToInt32(cboLoaiCa.SelectedValue) : 0;
                float soGio = spSoGio.EditValue != null ? Convert.ToSingle(spSoGio.EditValue) : 0;


                var lc = loaicaBL.GetItem(idLC);
                var cfg = sysConfigBL.GetItem("TangCa");

                if (cfg == null || !float.TryParse(cfg.Value, out float donGia) || donGia <= 0)
                {
                    
                    return;
                }

                var tc = new TangCa
                {
                    IdTangCa = _them ? 0 : _idTangCa,
                    IdNhanVien = idNV,
                    IdLoaiCa = idLC,
                    SoGio = soGio,
                    GhiChu = txtGhiChu.Text.Trim(),
                    NgayTangCa = DateTime.Now,
                    HeSo = lc.HeSo,
                    SoTien = (float?)(soGio * lc.HeSo * donGia),
                    Created_By = _them ? 1 : (int?)null,
                    Created_Date = _them ? DateTime.Now : (DateTime?)null,
                    Updated_By = !_them ? 1 : (int?)null,
                    Updated_Date = !_them ? DateTime.Now : (DateTime?)null
                };

                if (_them)
                    tangcaBL.Add(tc);
                else
                    tangcaBL.Update(tc);

                MessageBox.Show("Lưu thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                gcDSTangCa.DataSource = tangcaBL.GetTangCas();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi lưu: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }



        private void btnIn_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {

        }

        private void btDong_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            this.Close();
        }

       

        private void gvDSTangCa_Click(object sender, EventArgs e)
        {
            if (gvDSTangCa.RowCount > 0)
            {
                var idTangCaObj = gvDSTangCa.GetFocusedRowCellValue("IdTangCa");
                _idTangCa = idTangCaObj != DBNull.Value ? Convert.ToInt32(idTangCaObj) : 0;

                var ghiChuObj = gvDSTangCa.GetFocusedRowCellValue("GhiChu");
                txtGhiChu.Text = ghiChuObj != DBNull.Value ? ghiChuObj.ToString() : string.Empty;

                var soGioObj = gvDSTangCa.GetFocusedRowCellValue("SoGio");
                spSoGio.EditValue = soGioObj != DBNull.Value ? Convert.ToSingle(soGioObj) : 0;

                var idNVObj = gvDSTangCa.GetFocusedRowCellValue("IdNhanVien");
                slkNhanVien.EditValue = idNVObj != DBNull.Value ? Convert.ToInt32(idNVObj) : 0;

                var idLoaiCaObj = gvDSTangCa.GetFocusedRowCellValue("IdLoaiCa");
                cboLoaiCa.SelectedValue = idLoaiCaObj != DBNull.Value ? Convert.ToInt32(idLoaiCaObj) : -1;
            }
        }
    }
}