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
    public partial class FormLoaiCong : DevExpress.XtraEditors.XtraForm
    {
        enum ActionType { add = 0, update = 1, delete = 2 };
        LoaiCongBL loaiCongBL;
        LoaiCong loaiCong;
        ActionType action;
        public FormLoaiCong()
        {
            InitializeComponent();
            loaiCongBL = new LoaiCongBL();
        }

        private void btnThem_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            action = ActionType.add;
            ShowHide(false);
            lbID.Text = "Nhập Id mới";
            lbTen.Text = "Nhập tên mới";
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
            lbTen.Text = "Loại công";

            txtTen.Text = string.Empty;
            txtTen.Show();
            txtTen.Enabled = !kt;

            lbID.Text = "ID";

            txtId.Enabled = !kt;
            txtId.Text = string.Empty;

            nbrUDHeSo.Enabled = !kt;
        }
        private void FormLoaiCong_Load(object sender, EventArgs e)
        {
            try
            {
                dgcLoaiCong.DataSource = loaiCongBL.GetLoaiCongs();
                dgvLoaiCong.OptionsBehavior.Editable = false;
            }
            catch (SqlException ex)
            {
                MessageBox.Show(ex.Message);
            }
            ShowHide(true);
        }

        private void btnSua_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            action = ActionType.update;
            ShowHide(false);
            lbID.Text = "Nhập Id đối tượng";
            lbTen.Text = "Nhập tên muốn sửa";
        }

        private void btnXoa_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            action = ActionType.delete;
            ShowHide(false);
            lbID.Text = "Nhập ID đối tượng muốn xóa";
            lbTen.Hide();
            txtTen.Enabled = false;
            txtTen.Hide();
            lbHeSo.Hide();
            nbrUDHeSo.Hide();
        }

        private void btnLuu_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (int.TryParse(txtId.Text, out int id) == false)
            {
                MessageBox.Show("ID phải là một số nguyên hợp lệ!", "Lỗi", MessageBoxButtons.OK);
                return;
            }


            string ten = txtTen.Text.Trim();
            if (string.IsNullOrEmpty(ten) && action != ActionType.delete)
            {
                MessageBox.Show("Tên loại công không được để trống!", "Lỗi", MessageBoxButtons.OK);
                return;
            }

            double HeSo = double.Parse(nbrUDHeSo.Text);
            if (HeSo <= 0 || HeSo > 4)
            {
                MessageBox.Show("Nhập sai hệ số!", "Lỗi", MessageBoxButtons.OK);
                return;
            }
            switch (action)

            {
                case ActionType.add:
                    loaiCong = new LoaiCong(id, ten, HeSo);

                    try
                    {
                        loaiCongBL.AddLoaiCong(loaiCong);
                    }
                    catch (SqlException)
                    {
                        MessageBox.Show("ID đã tồn tại!", "Lỗi", MessageBoxButtons.OK);
                    }
                    break;
                case ActionType.update:
                    loaiCong = new LoaiCong(id, ten, HeSo);
                    try
                    {
                        loaiCongBL.UpdateLoaiCong(loaiCong);
                    }
                    catch (SqlException ex)
                    {
                        MessageBox.Show(ex.Message, "Loi");
                    }

                    break;

                case ActionType.delete:
                    try
                    {
                        loaiCongBL.DeleteLoaiCong(id);

                    }
                    catch (SqlException ex)
                    {
                        MessageBox.Show(ex.Message, "Loi");
                    }

                    break;
                default:
                    break;
            }
            dgcLoaiCong.DataSource = loaiCongBL.GetLoaiCongs();

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
    }
}