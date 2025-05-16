using BusinessLayer;
using DevExpress.Utils.DirectXPaint;
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
    public partial class FormLoaiCa : DevExpress.XtraEditors.XtraForm
    {
        enum ActionType { add = 0, update = 1, delete = 2 };
        LoaiCaBL loaiCaBL;
        LoaiCa loaiCa;
        ActionType action;
        public FormLoaiCa()
        {
            InitializeComponent();
            loaiCaBL = new LoaiCaBL();

        }

        private void FormLoaiCa_Load(object sender, EventArgs e)
        {
            try
            {
                dgcLoaiCa.DataSource = loaiCaBL.GetLoaiCas();
                dgvLoaiCa.OptionsBehavior.Editable = false;
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

            lbTen.Show();
            lbTen.Text = "Loại ca";
            txtTen.Text = string.Empty;
            txtTen.Show();
            txtTen.Enabled = !kt;

            lbID.Text = "ID";
            txtId.Enabled = !kt;
            txtId.Text = string.Empty;

            lbGioBatDau.Show();
            txtGioBatDau.Enabled = !kt;
            txtGioBatDau.EditValue = null;
            lbGioKetThuc.Show();
            txtGioKetThuc.Enabled = !kt;
            txtGioKetThuc.EditValue = null;
        }

        private void btnThem_ItemClick_1(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            action = ActionType.add;
            ShowHide(false);
            lbID.Text = "Nhập Id mới";
            lbTen.Text = "Nhập tên mới";
        }

        private void btnSua_ItemClick_1(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            action = ActionType.update;
            ShowHide(false);
            lbID.Text = "Nhập Id đối tượng";
            lbTen.Text = "Nhập tên muốn sửa";
            if (dgvLoaiCa.FocusedRowHandle >= 0)
            {
                txtId.Text = dgvLoaiCa.GetFocusedRowCellValue("ID")?.ToString();
                txtTen.Text = dgvLoaiCa.GetFocusedRowCellValue("TenLoaiCa")?.ToString();
                txtHeSo.Text = dgvLoaiCa.GetFocusedRowCellValue("HeSo")?.ToString();
                txtGioBatDau.EditValue = TimeSpan.Parse(dgvLoaiCa.GetFocusedRowCellValue("GioBatDau")?.ToString());
                txtGioKetThuc.EditValue = TimeSpan.Parse(dgvLoaiCa.GetFocusedRowCellValue("GioKetThuc")?.ToString());
            }
        }

        private void btnXoa_ItemClick_1(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {

            int id = int.Parse(dgvLoaiCa.GetFocusedRowCellValue("ID")?.ToString());
            loaiCaBL.DeleteLoaiCa(id);
            dgcLoaiCa.DataSource = loaiCaBL.GetLoaiCas();
        }

        private void btnHuy_ItemClick_1(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            ShowHide(true);
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
                MessageBox.Show("Tên loại ca không được để trống!", "Lỗi", MessageBoxButtons.OK);
                return;
            }
            if ((txtGioBatDau.EditValue == null || txtGioKetThuc.EditValue == null) && action != ActionType.delete)
            {
                MessageBox.Show("Giờ bắt đầu và giờ kết thúc không được để trống!", "Lỗi", MessageBoxButtons.OK);
                return;
            }
            if (!float.TryParse(txtHeSo.Text.Trim(), out float heSo))
            {
                MessageBox.Show("Hệ số phải là một số thực hợp lệ!", "Lỗi", MessageBoxButtons.OK);
                return;
            }

            TimeSpan gioBatDau = (TimeSpan)txtGioBatDau.EditValue;
            TimeSpan gioKetThuc = (TimeSpan)txtGioKetThuc.EditValue;
            switch (action)

            {
                case ActionType.add:
                    loaiCa = new LoaiCa(id, ten, gioBatDau, gioKetThuc, heSo);

                    try
                    {
                        loaiCaBL.AddLoaiCa(loaiCa);
                    }
                    catch (SqlException)
                    {
                        MessageBox.Show("ID đã tồn tại!", "Lỗi", MessageBoxButtons.OK);
                    }
                    break;
                case ActionType.update:
                    loaiCa = new LoaiCa(id, ten, gioBatDau, gioKetThuc, heSo);
                    try
                    {
                        loaiCaBL.UpdateLoaiCa(loaiCa);
                    }
                    catch (SqlException ex)
                    {
                        MessageBox.Show(ex.Message, "Loi");
                    }

                    break;

                default:
                    break;
            }
            dgcLoaiCa.DataSource = loaiCaBL.GetLoaiCas();

            ShowHide(true);
        }

        private void btDong_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            this.Close();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
    }
}
