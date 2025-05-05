using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using BusinessLayer;
using System.Data.SqlClient;
using TransferObject;
using System.Linq.Expressions;

namespace PresentationLayer
{
	public partial class FormDanToc: DevExpress.XtraEditors.XtraForm
	{
        int action;
        DanTocBL danTocBL;
        DanToc danToc;
        public FormDanToc()
		{
            InitializeComponent();
            danTocBL = new DanTocBL();
		}

        private void FormDanToc_Load(object sender, EventArgs e)
        {
            try
            {
                dgcDanToc.DataSource = danTocBL.GetDanTocs();
                dgvDanToc.OptionsBehavior.Editable = false;
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
            lbTen.Text = "Dân tộc";

            txtDanToc.Text = string.Empty;
            txtDanToc.Show();
            txtDanToc.Enabled = !kt;

            lbID.Text = "ID";

            txtId.Enabled = !kt;
            txtId.Text = string.Empty;
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
            lbID.Text = "Nhập Id đối tượng";
            lbTen.Text  =  "Nhập tên muốn sửa";
        }

        private void btnXoa_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            action = 2;
            ShowHide(false);
            lbID.Text = "Nhập ID đối tượng muốn xóa";
            lbTen.Hide();
            txtDanToc.Enabled=false;
            txtDanToc.Hide();
        }

        private void btnLuu_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            


            if (int.TryParse(txtId.Text, out int id) == false)
            {
                MessageBox.Show("ID phải là một số nguyên hợp lệ!", "Lỗi", MessageBoxButtons.OK);
                return;
            }
               
            
            string ten = txtDanToc.Text.Trim();
            if (string.IsNullOrEmpty(ten) && action != 2)
            {
                MessageBox.Show("Tên dân tộc không được để trống!", "Lỗi", MessageBoxButtons.OK);
                return;
            }
            switch (action)
                
            {
                case 0:
                    danToc = new DanToc(id, ten);

                     try
                    {
                       danTocBL.AddDanToc(danToc);
                    }
                    catch (SqlException)
                    {
                        MessageBox.Show("ID đã tồn tại!","Lỗi", MessageBoxButtons.OK);
                    }
                    break;
                case 1:
                    danToc = new DanToc(id, ten);
                    try
                    {
                        danTocBL.UpdateDanToc(danToc);
                    }
                    catch (SqlException ex)
                    {
                        MessageBox.Show(ex.Message, "Loi");
                    }
                   
                    break;

                case 2:
                    try
                    {
                        danTocBL.DeleteDanToc(id);
                        
                    }
                    catch (SqlException ex)
                    {
                        MessageBox.Show(ex.Message, "Loi");
                    }
                    
                    break;
                 default:
                    break;
            }
            dgcDanToc.DataSource = danTocBL.GetDanTocs();
            
            ShowHide(true);
        }

        private void btnHuy_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            ShowHide(true);
 
        }

    }
}