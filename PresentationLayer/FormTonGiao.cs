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
    public partial class FormTonGiao : DevExpress.XtraEditors.XtraForm
    {
        bool _them;
        TonGiaoBL tongiaoBL;
        TonGiao tg;
        int _id;
        public FormTonGiao()
        {
            InitializeComponent();
            tongiaoBL = new TonGiaoBL();
        }
        private void frmTonGiao_Load(object sender, EventArgs e)
        {
            try
            {
                gcDSTonGiao.DataSource = tongiaoBL.GetTonGiaos();
                gvDSTonGiao.OptionsBehavior.Editable = false;
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
            txtIdTonGiao.Enabled = !kt;
            txtTenTonGiao.Enabled = !kt;
        }

        private void btnThem_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            _them = true;
            _showHide(false);
            txtIdTonGiao.Text = string.Empty;
            txtTenTonGiao.Text = string.Empty;
        }

        private void btnSua_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            _them = false;
            _showHide(false);
        }

        private void btnXoa_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            txtIdTonGiao.Enabled = true;
            txtTenTonGiao.Enabled = false;

            if (!int.TryParse(txtIdTonGiao.Text.Trim(), out int id))
            {
                MessageBox.Show("Vui lòng nhập ID hợp lệ để xóa.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (MessageBox.Show("Bạn có chắc chắn xóa không?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
            {
                try
                {
                    tongiaoBL.DeleteTonGiao(id);
                    gcDSTonGiao.DataSource = tongiaoBL.GetTonGiaos();

                    txtIdTonGiao.Text = string.Empty;
                    txtTenTonGiao.Text = string.Empty;
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

       

        private void btDong_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            this.Close();
        }
         void SaveData()
        {
            if (_them)
            {
                tg = new TonGiao();
                tg.TenTonGiao = txtTenTonGiao.Text;
                tg.IdTonGiao = int.Parse(txtIdTonGiao.Text);
                tongiaoBL.AddTonGiao(tg);
            }
            else
            {
                tg = new TonGiao();
                tg.IdTonGiao = _id;

                tg.TenTonGiao = txtTenTonGiao.Text;
                tongiaoBL.UpdateTonGiao(tg);
            }
            gcDSTonGiao.DataSource = tongiaoBL.GetTonGiaos();
        }

        private void gcDSTonGiao_Click(object sender, EventArgs e)
        {
            _id = int.Parse(gvDSTonGiao.GetFocusedRowCellValue("IdTonGiao").ToString());
            txtTenTonGiao.Text = gvDSTonGiao.GetFocusedRowCellValue("TenTonGiao").ToString();
        }


    }
}
