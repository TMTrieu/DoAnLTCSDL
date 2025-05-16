using BusinessLayer;
using DevExpress.XtraEditors;
using PresentationLayer.ChamCong;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.ServiceModel.Channels;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TransferObject;

namespace PresentationLayer
{
    public partial class FormKyCong : DevExpress.XtraEditors.XtraForm
    {
        enum ActionType { add = 0, update = 1, delete = 2 };
        KyCongBL kyCongBL;
        KyCong kyCong;
        ActionType action;
        public FormKyCong()
        {
            InitializeComponent();
            kyCongBL = new KyCongBL();
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

        void ShowHide(bool kt)
        {
            btnLuu.Enabled = !kt;
            btnHuy.Enabled = !kt;
            btnThem.Enabled = kt;
            btnSua.Enabled = kt;
            btnXoa.Enabled = kt;
            btnDong.Enabled = kt;
            btnXemBangCong.Enabled = kt;

            lbThang.Show();

            cbBNam.Text = string.Empty;
            cbBNam.Show();
            cbBNam.Enabled = !kt;

            cbBThang.Enabled = !kt;
            cbBThang.Text = string.Empty;
            chBKhoa.Enabled = !kt;

            cbBNam.Text = DateTime.Now.Year.ToString();
            cbBThang.Text = DateTime.Now.Month.ToString();
            dateEditNgayTinhCong.Enabled = !kt;
            dateEditNgayTinhCong.Text = DateTime.Today.ToString("dd/MM/yyyy");
        }

        private void btnThem_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            action = ActionType.add;
            ShowHide(false);
        }

        private void btnSua_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            cbBNam.Enabled = false;
            cbBThang.Enabled = false;
            action = ActionType.update;
            ShowHide(false);
        }

        private void btnXoa_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (kyCong == null)
            {
                MessageBox.Show("Chưa chọn kỳ công cần xóa!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (MessageBox.Show("Xóa kỳ công mã: " + kyCong.MaKyCong + "?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
            {
                action = ActionType.delete;
                ShowHide(true);
                try
                {
                    kyCongBL.DeleteKyCong(kyCong.MaKyCong);
                }
                catch (SqlException ex)
                {
                    MessageBox.Show(ex.Message, "Loi");
                }
                dgcBangCong.DataSource = kyCongBL.GetKyCongs();
            }
        }

        private void btnLuu_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            kyCong = new KyCong();
            kyCong.Nam = int.Parse(cbBNam.Text);
            kyCong.Thang = int.Parse(cbBThang.Text);
            kyCong.MaKyCong = kyCong.Nam * 100 + kyCong.Thang;
            kyCong.Khoa = chBKhoa.Checked;
            kyCong.SoNgayCong = DemSoNgayLamViecTrongThang(kyCong.Thang, kyCong.Nam);
            kyCong.NgayTinhCong = dateEditNgayTinhCong.DateTime;
            switch (action)
            {
                case ActionType.add:
                    try
                    {
                        kyCongBL.AddKyCong(kyCong);
                    }
                    catch (SqlException ex)
                    {
                        MessageBox.Show(ex.Message, "Lỗi", MessageBoxButtons.OK);
                    }
                    break;
                case ActionType.update:
                    try
                    {
                        kyCongBL.UpdateKyCong(kyCong);
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

        public int DemSoNgayLamViecTrongThang(int thang, int nam)
        {
            int soNgayLamViec = 0;
            int soNgayTrongThang = DemSoNgayTrongThang(thang, nam);
            for (int ngay = 1; ngay <= soNgayTrongThang; ngay++)
            {
                DateTime ngayHienTai = new DateTime(nam, thang, ngay);
                if (ngayHienTai.DayOfWeek != DayOfWeek.Sunday && ngayHienTai.DayOfWeek != DayOfWeek.Saturday)
                {
                    soNgayLamViec++;
                }
            }
            return soNgayLamViec;
        }
        public int DemSoNgayTrongThang (int thang, int nam)
        {
            return DateTime.DaysInMonth(nam, thang);
        }

        private void dgvBangCong_Click(object sender, EventArgs e)
        {
            int Id = int.Parse(dgvBangCong.GetFocusedRowCellValue("MaKyCong").ToString());
            kyCong = kyCongBL.GetKyCongs().Find(x => x.MaKyCong == Id);
            cbBNam.Text = kyCong.Nam.ToString();
            cbBThang.Text = kyCong.Thang.ToString();
            chBKhoa.Checked = kyCong.Khoa;
            dateEditNgayTinhCong.Text = kyCong.NgayTinhCong.ToString("dd/MM/yyyy");
        }

        private void dgvBangCong_RowStyle(object sender, DevExpress.XtraGrid.Views.Grid.RowStyleEventArgs e)
        {
            if (e.RowHandle >= 0)
            {
                if (e.RowHandle % 2 == 0)
                {
                    e.Appearance.BackColor = Color.DeepSkyBlue;
                }
                else
                {
                    e.Appearance.BackColor = Color.GreenYellow;
                }
            }
        }

        private void btnXemBangCong_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (kyCong == null)
            {
                MessageBox.Show("Phải chọn bảng công mới được xem!", "Chưa chọn bảng công!", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                return;
            }
            try
            {
                FormKyCongChiTiet bangCongChiTiet = new FormKyCongChiTiet();
                bangCongChiTiet.maKyCong = kyCong.MaKyCong;
                bangCongChiTiet.thang = kyCong.Thang;
                bangCongChiTiet.nam = kyCong.Nam;
                bangCongChiTiet.daChamCong = kyCong.Khoa;
                bangCongChiTiet.ShowDialog();
            }
            catch (NullReferenceException ex)
            {
                MessageBox.Show("Phải chọn bảng công mới được xem!\n" + ex.Message, "Chưa chọn bảng công!", MessageBoxButtons.OK, MessageBoxIcon.Stop);
            }
        }
    }
    }
