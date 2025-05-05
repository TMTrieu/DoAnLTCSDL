using DevExpress.XtraEditors;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TransferObject;
using BusinessLayer;
using DevExpress.XtraGrid;
using System.Data.SqlClient;

namespace PresentationLayer
{
    public partial class FormBoPhan : DevExpress.XtraEditors.XtraForm
    {
        int action;
        BoPhanBL boPhanBL;
        BoPhan boPhan;
        public FormBoPhan()
        {
            InitializeComponent();
            boPhanBL = new BoPhanBL();
        }
        private void FormBoPhan_Load(object sender, EventArgs e)
        {
            try
            {
                gcDSBoPhan.DataSource = boPhanBL.GetBoPhans();
                gvDSBoPhan.OptionsBehavior.Editable = false;
            }
            catch (SqlException ex)
            {
                MessageBox.Show(ex.Message);
            }
            ShowHide(true);
        }
        void ShowHide(bool kt)
        {
            btnLuu.Enabled = !kt;
            btnHuy.Enabled = !kt;
            btnThem.Enabled = kt;
            btnSua.Enabled = kt;
            btnXoa.Enabled = kt;
            btnDong.Enabled = kt;
            btnIn.Enabled = kt;

            lbID.Text = "ID";

            lbTen.Show();
            lbTen.Text = "Bộ phận";

            txtBoPhan.Enabled = !kt;
            txtBoPhan.Show();
            txtBoPhan.Text = string.Empty;

            txtId.Text = string.Empty;
            txtId.Enabled = !kt;
        }
        private void btnThem_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            action = 0;
            ShowHide(false);
            lbID.Text = "Nhập Id mới";
            lbTen.Text = "Nhập tên mới";
        }
        private void btnSua_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            action = 1;
            ShowHide(false);
            lbID.Text = "Nhập Id bộ phận";
            lbTen.Text = "Nhập tên muốn sửa";
        }
        private void btnXoa_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            action = 2;
            ShowHide(false);
            lbID.Text = "Nhập ID bộ phận muốn xóa";
            lbTen.Hide();
            txtBoPhan.Enabled = false;
            txtBoPhan.Hide();
        }
        private void btnLuu_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (int.TryParse(txtId.Text, out int id) == false)
            {
                MessageBox.Show("ID phải là một số nguyên hợp lệ!", "Lỗi", MessageBoxButtons.OK);
                return;
            }

            string ten = txtBoPhan.Text.Trim();
            if (string.IsNullOrEmpty(ten) && action != 2)
            {
                MessageBox.Show("Tên bộ phận không được để trống!", "Lỗi", MessageBoxButtons.OK);
                return;
            }
            switch (action)

            {
                case 0:
                    boPhan = new BoPhan(id, ten);

                    try
                    {
                        boPhanBL.AddBoPhan(boPhan);
                    }
                    catch (SqlException)
                    {
                        MessageBox.Show("ID đã tồn tại!", "Lỗi", MessageBoxButtons.OK);
                    }
                    break;
                case 1:
                    boPhan = new BoPhan(id, ten);
                    try
                    {
                        boPhanBL.UpdateBoPhan(boPhan);
                    }
                    catch (SqlException ex)
                    {
                        MessageBox.Show(ex.Message, "Lỗi");
                    }
                    break;
                case 2:
                    try
                    {
                        boPhanBL.DeleteBoPhan(id);

                    }
                    catch (SqlException ex)
                    {
                        MessageBox.Show(ex.Message, "Loi");
                    }
                    break;
                default:
                    break;
            }
            gcDSBoPhan.DataSource = boPhanBL.GetBoPhans();
            
            ShowHide(true);
        }

        private void btnHuy_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            ShowHide(true);
        }
    }
}