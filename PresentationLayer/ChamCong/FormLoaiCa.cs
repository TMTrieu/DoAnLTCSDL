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
            btnIn.Enabled = kt;

            lbTen.Show();
            lbTen.Text = "Loại ca";

            txtTen.Text = string.Empty;
            txtTen.Show();
            txtTen.Enabled = !kt;

            lbID.Text = "ID";

            txtId.Enabled = !kt;
            txtId.Text = string.Empty;

            nbrUDHeSo.Enabled = !kt;
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
        }

        private void btnXoa_ItemClick_1(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            action = ActionType.delete;
            action = ActionType.delete;
            ShowHide(false);
            lbID.Text = "Nhập ID đối tượng muốn xóa";
            lbTen.Hide();
            txtTen.Enabled = false;
            txtTen.Hide();
            lbHeSo.Hide();
            nbrUDHeSo.Hide();
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

            double HeSo = double.Parse(nbrUDHeSo.Text);
            if(HeSo <= 0 || HeSo>4)
            {
                MessageBox.Show("Nhập sai hệ số!", "Lỗi", MessageBoxButtons.OK);
                return;
            }
            switch (action)

            {
                case ActionType.add:
                    loaiCa = new LoaiCa(id, ten,HeSo);

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
                    loaiCa = new LoaiCa(id, ten, HeSo);
                    try
                    {
                        loaiCaBL.UpdateLoaiCa(loaiCa);
                    }
                    catch (SqlException ex)
                    {
                        MessageBox.Show(ex.Message, "Loi");
                    }

                    break;

                case ActionType.delete:
                    try
                    {
                        loaiCaBL.DeleteLoaiCa(id);

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
    }
}
