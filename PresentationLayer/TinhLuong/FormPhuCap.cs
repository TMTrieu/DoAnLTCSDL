using BusinessLayer;
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
    public partial class FormPhuCap :DevExpress.XtraEditors.XtraForm
    {
        bool _them;
        int _idPhuCap;
        PhuCap pc;
        NhanVienPhuCap nvpc;
        NhanVien nhanvien;
        PhuCapBL phucapBL;
        NhanVienPhuCapBL nvpcBL;
        NhanVienBL nhanvienBL;
        public FormPhuCap()
        {
            InitializeComponent();
        }
        private void frmPhuCap1_Load(object sender, EventArgs e)
        {
            _showHide(true);
            _them = false;
            nvpcBL = new NhanVienPhuCapBL();
            nhanvienBL = new NhanVienBL();
            phucapBL = new PhuCapBL();
            try
            {
                gcDSPhuCap.DataSource = nvpcBL.GetNhanVienPhuCaps();
                gvDSPhuCap.OptionsBehavior.Editable = false;
            }
            catch (SqlException ex)
            {
                MessageBox.Show(ex.Message);
            }

            splitContainer1.Panel1Collapsed = false;
            loadNhanVien();
            loadPhuCap();
            cboPhuCap.SelectedIndexChanged += cboPhuCap_SelectedIndexChanged;


        }
        void cboPhuCap_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cboPhuCap.SelectedValue != null && int.TryParse(cboPhuCap.SelectedValue.ToString(), out int idPC))
            {
                PhuCap pc = phucapBL.GetItemPhuCap(idPC);
                if (pc != null)
                {
                    spSoTien.EditValue = pc.SoTien;
                }
            }
        }

        void loadPhuCap()
        {
            cboPhuCap.DataSource = phucapBL.GetPhuCaps();
            cboPhuCap.DisplayMember = "TenPhuCap";
            cboPhuCap.ValueMember = "IdPhuCap";
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
            spSoTien.Enabled = !kt;
            slkNhanVien.Enabled = !kt;
            cboPhuCap.Enabled = !kt;
        }

        
        private void btnThem_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            _showHide(false);
            _them = true;
            txtGhiChu.Text = string.Empty;
            spSoTien.EditValue = 0;
            slkNhanVien.EditValue = 0;
            cboPhuCap.SelectedIndex = 0;

            splitContainer1.Panel1Collapsed = false;
        }

        private void btnSua_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            _them = false;
            _showHide(false);

            splitContainer1.Panel1Collapsed = false;
        }

        private void btnXoa_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            
            if (MessageBox.Show("Bạn có chắc chắn xóa không?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
            {
                try
                {
                    int id = Convert.ToInt32(gvDSPhuCap.GetFocusedRowCellValue("IdNhanVienPhuCap"));
                    nvpcBL.Delete(id);
                    MessageBox.Show("Đã xóa thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    gcDSPhuCap.DataSource = nvpcBL.GetNhanVienPhuCaps();
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

        }

        private void btDong_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            this.Close();
        }
        void SaveData()
        {
            if (_them)
            {
                nvpc = new NhanVienPhuCap();
                nvpc.Ngay=DateTime.Now;
                nvpc.IdNhanVien = Convert.ToInt32(slkNhanVien.EditValue);
                nvpc.IdPhuCap = Convert.ToInt32(cboPhuCap.SelectedValue);
                nvpc.SoTien = float.Parse(spSoTien.EditValue.ToString());
                nvpc.NoiDung = txtGhiChu.Text;
                nvpc.Created_By = 1;
                nvpc.Created_Date = DateTime.Now;

                nvpcBL.Add(nvpc);

            }
            else
            {
                nvpc = new NhanVienPhuCap();
                nvpc.Ngay = DateTime.Now;
                nvpc.IdNhanVienPhuCap = _idPhuCap;
                nvpc.IdNhanVien = Convert.ToInt32(slkNhanVien.EditValue);
                nvpc.IdPhuCap = Convert.ToInt32(cboPhuCap.SelectedValue);
                nvpc.SoTien = float.Parse(spSoTien.EditValue.ToString());
                nvpc.NoiDung = txtGhiChu.Text;
                nvpc.Updated_By = 1;
                nvpc.Updated_Date = DateTime.Now;

                nvpcBL.Update(nvpc);
            }
            // Sau khi lưu xong load lại
            gcDSPhuCap.DataSource = nvpcBL.GetNhanVienPhuCaps();
        }

        private void gvDSPhuCap_Click(object sender, EventArgs e)
        {
            if (gvDSPhuCap.RowCount > 0)
            {
                _idPhuCap = int.Parse(gvDSPhuCap.GetFocusedRowCellValue("IdNhanVienPhuCap").ToString());
                txtGhiChu.Text = gvDSPhuCap.GetFocusedRowCellValue("NoiDung").ToString();
                spSoTien.EditValue = gvDSPhuCap.GetFocusedRowCellValue("SoTien");
                slkNhanVien.EditValue = gvDSPhuCap.GetFocusedRowCellValue("IdNhanVien");
                cboPhuCap.SelectedValue = gvDSPhuCap.GetFocusedRowCellValue("IdPhuCap");
            }
        }

        
    }
}
