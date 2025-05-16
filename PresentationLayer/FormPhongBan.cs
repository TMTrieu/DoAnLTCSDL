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
    public partial class FormPhongBan : DevExpress.XtraEditors.XtraForm
    {
        int action;
        PhongBanBL phongBanBL;
        PhongBan phongBan;
        public FormPhongBan()
        {
            InitializeComponent();
            phongBanBL = new PhongBanBL();
        }

        private void btnThem_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            action = 0;
            ShowHide(false);
            lbID.Text = "Nhập Id mới";
            lbTen.Text = "Nhập tên mới";
        }

        private void FormPhongBan_Load(object sender, EventArgs e)
        {
            try
            {
                dgcPhongBan.DataSource = phongBanBL.GetPhongBans();
                dgvPhongBan.OptionsBehavior.Editable = false;
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
            lbTen.Text = "Phòng ban";

            txtPhongBan.Text = string.Empty;
            txtPhongBan.Show();
            txtPhongBan.Enabled = !kt;

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
            txtPhongBan.Enabled = false;
            txtPhongBan.Hide();
        }

        private void btnLuu_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (int.TryParse(txtId.Text, out int id) == false)
            {
                MessageBox.Show("ID phải là một số nguyên hợp lệ!", "Lỗi", MessageBoxButtons.OK);
                return;
            }


            string ten = txtPhongBan.Text.Trim();
            if (string.IsNullOrEmpty(ten) && action != 2)
            {
                MessageBox.Show("Tên dân tộc không được để trống!", "Lỗi", MessageBoxButtons.OK);
                return;
            }
            switch (action)

            {
                case 0:
                    phongBan = new PhongBan(id, ten);

                    try
                    {
                        phongBanBL.AddPhongBan(phongBan);
                    }
                    catch (SqlException)
                    {
                        MessageBox.Show("ID đã tồn tại!", "Lỗi", MessageBoxButtons.OK);
                    }
                    break;
                case 1:
                    phongBan = new PhongBan(id, ten);
                    try
                    {
                        phongBanBL.UpdatePhongBan(phongBan);
                    }
                    catch (SqlException ex)
                    {
                        MessageBox.Show(ex.Message, "Loi");
                    }

                    break;

                case 2:
                    try
                    {
                        phongBanBL.DeletePhongBan(id);

                    }
                    catch (SqlException ex)
                    {
                        MessageBox.Show(ex.Message, "Loi");
                    }

                    break;
                default:
                    break;
            }
            dgcPhongBan.DataSource = phongBanBL.GetPhongBans();

            ShowHide(true);
        }

        private void btnHuy_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            ShowHide(true);
        }

      
        private void btDong_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            this.Close();
        }

        private void btnIn_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {

        }
    }
}