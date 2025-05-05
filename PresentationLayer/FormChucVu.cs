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
    public partial class FormChucVu : DevExpress.XtraEditors.XtraForm
    {
        int action;
        ChucVuBL chucVuBL;
        ChucVu chucVu;
        public FormChucVu()
        {
            InitializeComponent();
            chucVuBL = new ChucVuBL();
        }

        private void btnThem_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            action = 0;
            ShowHide(false);
            lbID.Text = "Nhập Id mới";
            lbTen.Text = "Nhập tên mới";
        }

        private void FormChucVu_Load(object sender, EventArgs e)
        {
            try
            {
                dgcChucVu.DataSource = chucVuBL.GetChucVus();
                dgvChucVu.OptionsBehavior.Editable = false;
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

            lbTen.Show();
            lbTen.Text = "Chức vụ";

            txtChucVu.Text = string.Empty;
            txtChucVu.Show();
            txtChucVu.Enabled = !kt;

            lbID.Text = "ID";

            txtId.Enabled = !kt;
            txtId.Text = string.Empty;
        }
        private void btnSua_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            action = 1;
            ShowHide(false);
            lbID.Text = "Nhập Id đối tượng";
            lbTen.Text = "Nhập tên muốn sửa";
        }

        private void btnXoa_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            action = 2;
            ShowHide(false);
            lbID.Text = "Nhập ID đối tượng muốn xóa";
            lbTen.Hide();
            txtChucVu.Enabled = false;
            txtChucVu.Hide();
        }

        private void btnLuu_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (int.TryParse(txtId.Text, out int id) == false)
            {
                MessageBox.Show("ID phải là một số nguyên hợp lệ!", "Lỗi", MessageBoxButtons.OK);
                return;
            }


            string ten = txtChucVu.Text.Trim();
            if (string.IsNullOrEmpty(ten) && action != 2)
            {
                MessageBox.Show("Tên chức vụ không được để trống!", "Lỗi", MessageBoxButtons.OK);
                return;
            }
            switch (action)

            {
                case 0:
                    chucVu = new ChucVu(id, ten);

                    try
                    {
                        chucVuBL.AddChucVu(chucVu);
                    }
                    catch (SqlException)
                    {
                        MessageBox.Show("ID đã tồn tại!", "Lỗi", MessageBoxButtons.OK);
                    }
                    break;
                case 1:
                    chucVu = new ChucVu(id, ten);
                    try
                    {
                        chucVuBL.UpdateChucVu(chucVu);
                    }
                    catch (SqlException ex)
                    {
                        MessageBox.Show(ex.Message, "Loi");
                    }

                    break;

                case 2:
                    try
                    {
                        chucVuBL.DeleteChucVu(id);

                    }
                    catch (SqlException ex)
                    {
                        MessageBox.Show(ex.Message, "Loi");
                    }

                    break;
                default:
                    break;
            }
            dgcChucVu.DataSource = chucVuBL.GetChucVus();

            ShowHide(true);
        }

        private void btnHuy_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            ShowHide(true);
        }
    }
}