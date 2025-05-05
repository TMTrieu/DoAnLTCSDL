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

namespace PresentationLayer.QuanLyChamCong
{
    public partial class BangCong : DevExpress.XtraEditors.XtraForm
    {
        enum ActionType { add = 0, update = 1, delete = 2 };
        KyCongBL kyCongBL;
        KyCong kyCong;
        ActionType action;
        public BangCong()
        {
            InitializeComponent();
            kyCongBL = new KyCongBL();
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

            lbThang.Show();

           cbBNam.Text = string.Empty;
           cbBNam.Show();
           cbBNam.Enabled = !kt;

           cbBThang.Enabled = !kt;
           cbBThang.Text = string.Empty;

            
        }

        private void btnThem_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            action = ActionType.add;
            ShowHide(false);


        }

        private void btnSua_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            action = ActionType.update;
            ShowHide(false);

        }

        private void btnXoa_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            action = ActionType.delete;
            ShowHide(false);
            lbNam.Text = "Nhập ID đối tượng muốn xóa";
            lbThang.Hide();
           cbBNam.Enabled = false;
           cbBNam.Hide();

        }

        private void btnLuu_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            int id=1;
            switch (action)

            {
                case ActionType.add:
                    kyCong = new KyCong();

                    try
                    {
                        kyCongBL.AddKyCong(kyCong);
                    }
                    catch (SqlException)
                    {
                        MessageBox.Show("ID đã tồn tại!", "Lỗi", MessageBoxButtons.OK);
                    }
                    break;
                case ActionType.update:
                    kyCong = new KyCong();
                    try
                    {
                        kyCongBL.UpdateKyCong(kyCong);
                    }
                    catch (SqlException ex)
                    {
                        MessageBox.Show(ex.Message, "Loi");
                    }

                    break;

                case ActionType.delete:
                    try
                    {
                        kyCongBL.DeleteKyCong(id);

                    }
                    catch (SqlException ex)
                    {
                        MessageBox.Show(ex.Message, "Loi");
                    }

                    break;
                default:
                    break;
            }
            dgcBangCong.DataSource = kyCongBL.GetKyCongs();

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

        private void BangCong_Load(object sender, EventArgs e)
        {
            try
            {
                dgcBangCong.DataSource = kyCongBL.GetKyCongs();
                dgvBangCong.OptionsBehavior.Editable = false;
            }
            catch (SqlException ex)
            {
                MessageBox.Show(ex.Message);
            }
            ShowHide(true);
        }

      

        private void dgvBangCong_Click(object sender, EventArgs e)
        {
            int Id = int.Parse(dgvBangCong.GetFocusedRowCellValue("MaKyCong").ToString());

            kyCong = kyCongBL.GetKyCongs().Find(x => x.MaKyCong == Id);
        }
    }
}