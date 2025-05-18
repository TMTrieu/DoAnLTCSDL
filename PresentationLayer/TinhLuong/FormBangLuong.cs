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
using BusinessLayer;
using BusinessLayer.ChamCongBL;
using DevExpress.XtraReports.UI;
using PresentationLayer.BaoCao;
using TransferObject;
using TransferObject.TinhLuong;

namespace PresentationLayer
{
    public partial class FormBangLuong : DevExpress.XtraEditors.XtraForm
    {
        private BangLuongBL bangLuongBL;
        private int maKyCong;
        public int nam;
        public int thang;
        private KyCongChiTietBL kyCongChiTietBL;
        private NhanVienBL nhanVienBL;
        private KyCongBL kyCongBL;
        private TangCaBL tangCaBL;
        private NhanVienPhuCapBL nvphuCapBL;
        private HDLaoDongBL hDLaoDongBL;

        public FormBangLuong()
        {
            InitializeComponent();
            bangLuongBL = new BangLuongBL();
            int.TryParse(cboNam.Text, out nam);
            int.TryParse(cboThang.Text, out thang);
            kyCongChiTietBL = new KyCongChiTietBL();
            nhanVienBL = new NhanVienBL();
            kyCongBL = new KyCongBL();
            tangCaBL = new TangCaBL();
            nvphuCapBL = new NhanVienPhuCapBL();
            hDLaoDongBL = new HDLaoDongBL();
        }
        private void FormBangLuong_Load(object sender, EventArgs e)
        {
            try
            {
                maKyCong = nam * 100 + thang;
                gcDSBangLuong.DataSource = bangLuongBL.GetListByMaKyCong(maKyCong);
                gvDSBangLuong.OptionsBehavior.Editable = false;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi load bảng lương: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void btnThem_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (cboNam.Text == "" || cboThang.Text == "")
            {
                MessageBox.Show("Chọn năm và tháng để xem!");
                return;
            }
            else
            {
                int.TryParse(cboNam.Text, out nam);
                int.TryParse(cboThang.Text, out thang);
                maKyCong = nam * 100 + thang;
            }
            try
            {
                List<BangLuong> list = bangLuongBL.GetListByMaKyCong(maKyCong);
                BangLuong bangLuong = new BangLuong();
                foreach (BangLuong bl in list)
                {
                    HDLaoDong hDLaoDong = hDLaoDongBL.GetHopDongs().FirstOrDefault(x => x.IdNhanVien == bl.IdNhanVien);
                    double luong1NgayCong = (hDLaoDong.LuongCoBan * hDLaoDong.HeSoLuong) / bl.NgayCongTrongThang;
                    double luongNgayThuong = bl.TongNgayCong * luong1NgayCong;
                    double luongPhep = bl.NgayPhep * luong1NgayCong;
                    double luongLe = bl.CongNgayLe * luong1NgayCong * 3;
                    double luongNgayNghi = bl.CongNgayNghi * luong1NgayCong * 2;
                    double thucLanh = luongNgayThuong + luongPhep + luongLe + luongNgayNghi + bl.TangCa + bl.PhuCap;
                    bl.ThucLanh = thucLanh;

                    bangLuongBL.Update(bl);

                }
                loadData();
            }
            catch (SqlException ex)
            {
                MessageBox.Show(ex.Message);
            }
        }



        void loadData()
        {
            try
            {
                maKyCong = nam * 100 + thang;
                var data = bangLuongBL.GetListByMaKyCong(maKyCong);
                gcDSBangLuong.DataSource = data;
                if (data.Count == 0)
                {
                    MessageBox.Show("Không tồn tại dữ liệu chấm công", "Lỗi", MessageBoxButtons.OK);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi load dữ liệu bảng lương: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void btnIn_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            rptBangLuong rpt = new rptBangLuong();
            rpt.ShowPreviewDialog();
        }

        private void btDong_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            this.Close();
        }

        private void gvDSBangLuong_Click(object sender, EventArgs e)
        {

        }

        private void spXemBangLuong_Click(object sender, EventArgs e)
        {
            if (cboNam.Text == "" || cboThang.Text == "")
            {
                MessageBox.Show("Chọn năm và tháng để xem!");
                return;
            }
            else
            {
                int.TryParse(cboNam.Text, out nam);
                int.TryParse(cboThang.Text, out thang);

                List<KyCongChiTiet> lkcct = kyCongChiTietBL.GetKyCongChiTiets(maKyCong);
                List<BangLuong> lbl = bangLuongBL.GetListByMaKyCong(maKyCong);

                double tongTangCa = 0;
                double tongPhuCap = 0;
                var bangLuongsCu = bangLuongBL.GetListByMaKyCong(maKyCong);
                bangLuongBL.Delete(maKyCong);
                foreach (var kc in lkcct)
                {
                    bool exists = lbl.Any(bl => bl.MaKyCong == kc.MaKyCong && bl.IdNhanVien == kc.MaNhanVien);
                    if (!exists)
                    {
                        BangLuong bangLuong = new BangLuong();
                        {
                            bangLuong.MaKyCong = kc.MaKyCong;
                            bangLuong.IdNhanVien = kc.MaNhanVien;
                            bangLuong.NgayPhep = kc.NgayPhep;
                            bangLuong.CongNgayLe = kc.CongNgayLe;
                            bangLuong.TongNgayCong = kc.TongNgayCong;
                            bangLuong.CongNgayNghi = kc.CongNgayNghi;
                            bangLuong.NgayCongTrongThang = kc.NgayCong;
                            foreach (var tangCa in tangCaBL.GetTangCas())
                                if (tangCa.IdNhanVien == bangLuong.IdNhanVien && (tangCa.NgayTangCa.Year * 100 + tangCa.NgayTangCa.Month) == bangLuong.MaKyCong)
                                    tongTangCa += tangCa.SoTien;
                            bangLuong.TangCa = tongTangCa;

                            foreach (var phuCap in nvphuCapBL.GetNhanVienPhuCaps())
                                if (phuCap.IdNhanVien == bangLuong.IdNhanVien)
                                    tongPhuCap += phuCap.SoTien;
                            bangLuong.PhuCap = tongPhuCap;
                            bangLuong.HoTen = nhanVienBL.getNhanViens().Find(x => x.IdNhanVien == kc.MaNhanVien).HoTen;
                            bangLuong.NgayCongTrongThang = kyCongBL.GetKyCongs().Find(x => x.MaKyCong == kc.MaKyCong).SoNgayCong;
                        }
                        ;
                        bangLuongBL.Add(bangLuong);
                    }
                }
                try
                {
                    maKyCong = nam * 100 + thang;
                    var data = bangLuongBL.GetListByMaKyCong(maKyCong);
                    gcDSBangLuong.DataSource = data;
                    if (data.Count == 0)
                    {
                        MessageBox.Show("Vui lòng đợi!", "", MessageBoxButtons.OK);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi khi load dữ liệu bảng lương: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
    }
}

