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
    public partial class FormTrinhDo : DevExpress.XtraEditors.XtraForm
    {
        bool _them;
        TrinhDoBL trinhdoBL;
        TrinhDo td;
        int _id;
        public FormTrinhDo()
        {
            InitializeComponent();
            trinhdoBL = new TrinhDoBL();
        }
        private void frmTrinhDo_Load(object sender, EventArgs e)
        {
            try
            {
                gcDSTrinhDo.DataSource = trinhdoBL.GetTrinhDos();
                gvDSTrinhDo.OptionsBehavior.Editable = false;
            }
            catch (SqlException ex)
            {
                MessageBox.Show(ex.Message);
            }
            _showHide(true);
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
            txtIdTrinhDo.Enabled = !kt;
            txtTenTrinhDo.Enabled = !kt;
        }

        private void btnThem_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {

            _them = true;
            _showHide(false);
            txtIdTrinhDo.Enabled = false;
            txtTenTrinhDo.Text = string.Empty;
        }

        private void btnSua_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            _them = false;
            _showHide(false);
            txtIdTrinhDo.Enabled = false;
        }

        private void btnXoa_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {

            txtIdTrinhDo.Enabled = true;
            txtTenTrinhDo.Enabled = false;

            if (!int.TryParse(txtIdTrinhDo.Text.Trim(), out int id))
            {
                MessageBox.Show("Vui lòng nhập ID hợp lệ để xóa.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (MessageBox.Show("Bạn có chắc chắn xóa không?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
            {
                try
                {
                    trinhdoBL.DeleteTrinhDo(id);
                    // Cập nhật lại dữ liệu bảng
                    gcDSTrinhDo.DataSource = trinhdoBL.GetTrinhDos();

                    // Xóa nội dung text box
                    txtIdTrinhDo.Text = string.Empty;
                    txtTenTrinhDo.Text = string.Empty;
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
        }

        private void btnHuy_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            _them = false;
            _showHide(true);
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
                td = new TrinhDo();
                td.TenTrinhDo = txtTenTrinhDo.Text;
                trinhdoBL.AddTrinhDo(td);
            }
            else
            {
                td = new TrinhDo();
                td.IdTrinhDo = _id;

                td.TenTrinhDo = txtTenTrinhDo.Text;
                trinhdoBL.UpdateTrinhDo(td);
            }
            gcDSTrinhDo.DataSource = trinhdoBL.GetTrinhDos();
        }
        private void gcDSTrinhDo_Click(object sender, EventArgs e)
        {
            _id = int.Parse(gvDSTrinhDo.GetFocusedRowCellValue("IdTrinhDo").ToString());
            txtTenTrinhDo.Text = gvDSTrinhDo.GetFocusedRowCellValue("TenTrinhDo").ToString();
        }


    }
}
