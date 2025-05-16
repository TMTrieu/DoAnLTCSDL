using BusinessLayer;
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
using BusinessLayer.ChamCongBL;
using DevExpress.Utils.Extensions;

namespace PresentationLayer.ChamCong
{
    public partial class FormNgayCongChiTiet : DevExpress.XtraEditors.XtraForm
    {
        public int maKyCong;
        public int maNhanVien;
        public DateTime ngayChamCong;

        private KyCongChiTietBL kyCongChiTietBL;
        private LoaiCaBL loaiCaBL;
        private LoaiCongBL loaiCongBL;
        private BangCongChiTietBL bangCongChiTietBL;

        public string ketQua;

        private BangCongChiTiet bangCongChiTiet;
        private List<BangCongChiTiet> duLieu;

        private int IdCa, IdCong;
        public FormNgayCongChiTiet()
        {
            InitializeComponent();
            loaiCongBL = new LoaiCongBL();
            loaiCaBL = new LoaiCaBL();
            bangCongChiTietBL = new BangCongChiTietBL();
            kyCongChiTietBL = new KyCongChiTietBL();
        }

        private void FormCapNhatNgayCong_Load(object sender, EventArgs e)
        {
            chCbBLoaiCa.Properties.DataSource = loaiCaBL.GetLoaiCas();
            chCbBLoaiCa.Properties.DisplayMember = "TenLoaiCa";
            chCbBLoaiCa.Properties.ValueMember = "IdLoaiCa";
            chCbBLoaiCa.Properties.AllowMultiSelect = false;
            chCbBLoaiCong.Properties.AllowMultiSelect = false;
            chCbBLoaiCong.Properties.DataSource = loaiCongBL.GetLoaiCongs().Skip(1);
            chCbBLoaiCong.Properties.DisplayMember = "TenLoaiCong";
            chCbBLoaiCong.Properties.ValueMember = "ID";


            tEGioVao.EditValue = TimeSpan.Parse(DateTime.Now.TimeOfDay.ToString(@"hh\:mm\:ss"));
            tEGioRa.EditValue = DateTime.Now.TimeOfDay.ToString(@"hh\:mm\:ss");
            if (ngayChamCong.DayOfWeek == DayOfWeek.Saturday || ngayChamCong.DayOfWeek == DayOfWeek.Sunday)
                chCbBLoaiCong.EditValue = "Ngày nghỉ";
            duLieu = bangCongChiTietBL.GetNgayCongChiTiet(maKyCong, maNhanVien, ngayChamCong);
            gridControl1.DataSource = duLieu;
            gridView1.OptionsBehavior.Editable = false;
            if (gridView1.RowCount > 0)
            {
                gridView1.FocusedRowHandle = 0;
                object id = gridView1.GetRowCellValue(0, "IdBangCong");
                if (id != null)
                {
                    bangCongChiTiet = duLieu.FirstOrDefault(x => x.IdBangCong == Convert.ToInt32(id));
                    chCbBLoaiCa.Text = bangCongChiTiet.TenLoaiCa;
                    IdCa = bangCongChiTiet.IdLoaiCa;
                    chCbBLoaiCong.Text = bangCongChiTiet.TenLoaiCong;
                    IdCong = bangCongChiTiet.IdLoaiCong;
                    radioGroup1.EditValue = bangCongChiTiet.ChamCong.Trim();
                    tEGioVao.EditValue = bangCongChiTiet.ThoiGianVao.ToString(@"hh\:mm\:ss");
                    tEGioRa.EditValue = bangCongChiTiet.ThoiGianRa.ToString(@"hh\:mm\:ss");
                }
            }
        }

        private void btCapNhat_Click(object sender, EventArgs e)
        {
            BangCongChiTiet bangCongMoi = new BangCongChiTiet();
            if (radioGroup1.EditValue == null)
            {
                MessageBox.Show("Chưa chấm công hợp lệ!", "Cảnh báo", MessageBoxButtons.OK);
                return;
            }
            var listCa = chCbBLoaiCa.Properties.Items.GetCheckedValues();
            if (listCa.Count == 0 && chCbBLoaiCa.Text == "")
            {
                MessageBox.Show("Vui lòng nhập đầy đủ thông tin!", "Cảnh báo", MessageBoxButtons.OK);
                return;
            }

            if (listCa.Count > 1)
            {
                MessageBox.Show("Không thể chọn nhiều ca!", "Cảnh báo", MessageBoxButtons.OK);
                return;
            }
            if (listCa.Count == 1)
            {
                int.TryParse(listCa[0].ToString(), out int id);
                bangCongMoi.IdLoaiCa = id;
            }
            else
                bangCongMoi.IdLoaiCa = loaiCaBL.GetLoaiCas().Find(x => x.TenLoaiCa == chCbBLoaiCa.Text).IdLoaiCa;


            bangCongMoi.ChamCong = radioGroup1.EditValue.ToString();
            bangCongMoi.MaKyCong = maKyCong;
            bangCongMoi.IdNhanVien = maNhanVien;
            bangCongMoi.NgayChamCong = ngayChamCong;


            switch (radioGroup1.EditValue.ToString())
            {
                case "P":
                case "KP":
                    {
                        if (bangCongChiTietBL.GetCaChiTiet(maKyCong, maNhanVien, ngayChamCong, bangCongMoi.IdLoaiCa) != null)
                        {
                            if (kiemTra(bangCongChiTiet, bangCongMoi, false, false))
                            {
                                MessageBox.Show("Đã tồn tại!", "Cảnh báo", MessageBoxButtons.OK);
                                return;
                            }
                            else
                                bangCongChiTietBL.UpdateBangCongChiTiet(bangCongMoi, bangCongChiTiet.IdBangCong);
                        }
                        else
                            bangCongChiTietBL.AddBangCongChiTiet(bangCongMoi);
                    }
                    break;
                case "X":
                    if (chCbBLoaiCong.EditValue == null || string.IsNullOrEmpty(chCbBLoaiCong.EditValue.ToString()))
                    {
                        MessageBox.Show("Vui lòng nhập đầy đủ thông tin!", "Cảnh báo", MessageBoxButtons.OK);
                        return;
                    }
                    LoaiCong cong = loaiCongBL.GetLoaiCongs().FirstOrDefault(x => x.TenLoaiCong == chCbBLoaiCong.EditValue.ToString());
                    if (cong != null)
                        bangCongMoi.IdLoaiCong = cong.ID;
                    else
                        bangCongMoi.IdLoaiCong = Convert.ToInt32(chCbBLoaiCong.EditValue);

                    bangCongMoi.ThoiGianVao = TimeSpan.Parse(tEGioVao.Text);
                    bangCongMoi.ThoiGianRa = TimeSpan.Parse(tEGioRa.Text);
                    if (bangCongChiTietBL.GetCaChiTiet(maKyCong, maNhanVien, ngayChamCong, bangCongMoi.IdLoaiCa) != null)
                    {
                        if (kiemTra(bangCongChiTiet, bangCongMoi, true, true))
                        {
                            MessageBox.Show("Đã tồn tại!", "Cảnh báo", MessageBoxButtons.OK);
                            return;
                        }
                        else
                            bangCongChiTietBL.UpdateBangCongChiTiet(bangCongMoi, bangCongChiTiet.IdBangCong);
                    }
                    else
                        bangCongChiTietBL.AddBangCongChiTiet(bangCongMoi);

                    break;
                case "CT":
                    if (chCbBLoaiCong.EditValue == null || string.IsNullOrEmpty(chCbBLoaiCong.EditValue.ToString()))
                    {
                        MessageBox.Show("Vui lòng nhập đầy đủ thông tin!", "Cảnh báo", MessageBoxButtons.OK);
                        return;
                    }
                    LoaiCong lcong = loaiCongBL.GetLoaiCongs().FirstOrDefault(x => x.TenLoaiCong == chCbBLoaiCong.EditValue.ToString());
                    if (lcong != null)
                        bangCongMoi.IdLoaiCong = lcong.ID;
                    else
                        bangCongMoi.IdLoaiCong = Convert.ToInt32(chCbBLoaiCong.EditValue);
                    if (bangCongChiTietBL.GetCaChiTiet(maKyCong, maNhanVien, ngayChamCong, bangCongMoi.IdLoaiCa) != null)
                    {
                        if (kiemTra(bangCongChiTiet, bangCongMoi, false, true))
                        {
                            MessageBox.Show("Đã tồn tại!", "Cảnh báo", MessageBoxButtons.OK);
                            return;
                        }
                        else
                            bangCongChiTietBL.UpdateBangCongChiTiet(bangCongMoi, bangCongChiTiet.IdBangCong);
                    }
                    else
                        bangCongChiTietBL.AddBangCongChiTiet(bangCongMoi);

                    break;
                default:
                    break;
            }
            var duLieuMoi = bangCongChiTietBL.GetNgayCongChiTiet(maKyCong, maNhanVien, ngayChamCong);
            ketQua = traVe(duLieuMoi, radioGroup1.EditValue.ToString());
            this.Close();
        }

        private string traVe(List<BangCongChiTiet> duLieuMoi, string chamCong)
        {
            if (duLieuMoi.Any(x => x.ChamCong.Trim() == "CT"))
                return "CT";
            if (duLieuMoi.Any(x => x.ChamCong.Trim() == "X"))
                return "X";
            if (duLieuMoi.Any(x => x.ChamCong.Trim() == "P"))
                return "P";
            if (duLieuMoi.Any(x => x.ChamCong.Trim() == "KP"))
                return "KP";
            return chamCong;
        }
        private bool kiemTra(BangCongChiTiet cu, BangCongChiTiet moi, bool gio, bool cong)
        {
            if (cu == null || moi == null) return false;

            bool giongCoBan = cu.IdLoaiCa == moi.IdLoaiCa &&
                              cu.NgayChamCong == moi.NgayChamCong &&
                              cu.MaKyCong == moi.MaKyCong &&
                              cu.IdNhanVien == moi.IdNhanVien &&
                              cu.ChamCong.Trim() == moi.ChamCong.Trim();
            if (!giongCoBan) return false;
            if (cong)
                if (cu.IdLoaiCong != moi.IdLoaiCong)
                    return false;
            if (gio)
            {
                return cu.ThoiGianVao == moi.ThoiGianVao &&
                       cu.ThoiGianRa == moi.ThoiGianRa;
            }
            return true;
        }
        private void radioGroup1_EditValueChanged(object sender, EventArgs e)
        {
            switch (radioGroup1.EditValue.ToString())
            {
                case "KP":
                case "P":
                    chCbBLoaiCa.Enabled = true;
                    chCbBLoaiCong.Enabled = false;
                    tEGioRa.Enabled = false;
                    tEGioVao.Enabled = false;
                    break;

                case "CT":
                    chCbBLoaiCa.Enabled = true;
                    chCbBLoaiCong.Enabled = true;
                    tEGioRa.Enabled = false;
                    tEGioVao.Enabled = false;
                    break;
                case "X":
                    chCbBLoaiCa.Enabled = true;
                    chCbBLoaiCong.Enabled = true;
                    tEGioRa.Enabled = true;
                    tEGioVao.Enabled = true;
                    break;
                default:
                    break;
            }
        }
        private void chCbBLoaiCa_Properties_EditValueChanged(object sender, EventArgs e)
        {
            var checkedValues = chCbBLoaiCa.Properties.Items.GetCheckedValues();
            if (checkedValues.Count > 0 && int.TryParse(checkedValues[0].ToString(), out int id))
            {
                LoaiCa loaiCa = loaiCaBL.GetLoaiCas().Find(x => x.IdLoaiCa == id);
                tEGioRa.EditValue = loaiCa.GioKetThuc.ToString(@"hh\:mm\:ss");
            }
            tEGioVao.EditValue = TimeSpan.Parse(DateTime.Now.TimeOfDay.ToString(@"hh\:mm\:ss"));
        }

        private void gridView1_Click(object sender, EventArgs e)
        {
            bangCongChiTiet = bangCongChiTietBL.GetNgayCongChiTiet(maKyCong, maNhanVien, ngayChamCong).FirstOrDefault(x => x.IdBangCong == int.Parse(gridView1.GetFocusedRowCellValue("IdBangCong").ToString()));
            if (bangCongChiTiet != null)
            {
                IdCa = bangCongChiTiet.IdLoaiCa;
                IdCong = bangCongChiTiet.IdLoaiCong;
                tEGioVao.EditValue = bangCongChiTiet.ThoiGianVao.ToString();
                tEGioRa.EditValue = bangCongChiTiet.ThoiGianRa.ToString();
                chCbBLoaiCa.Text = bangCongChiTiet.TenLoaiCa.ToString();
                chCbBLoaiCong.Text = bangCongChiTiet.TenLoaiCong.ToString();
                radioGroup1.EditValue = bangCongChiTiet.ChamCong.ToString().Trim();
            }
        }
    }
}