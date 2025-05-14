using BusinessLayer;
using BusinessLayer.ChamCongBL;
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

namespace PresentationLayer.ChamCong
{
    public partial class FormXemChiTiet : DevExpress.XtraEditors.XtraForm
    {
        public int maKyCong;
        public int maNhanVien;
        public DateTime ngayChamCong;

        private KyCongChiTietBL kyCongChiTietBL;
        private LoaiCaBL loaiCaBL;
        private BangCongChiTietBL bangCongChiTietBL;

        private List<BangCongChiTiet> duLieu;

        public FormXemChiTiet()
        {
            InitializeComponent();
            loaiCaBL = new LoaiCaBL();
            bangCongChiTietBL = new BangCongChiTietBL();
            kyCongChiTietBL = new KyCongChiTietBL();
        }

        private void FormXemChiTiet_Load(object sender, EventArgs e)
        {
            duLieu = bangCongChiTietBL.GetNgayCongChiTiet(maKyCong, maNhanVien, ngayChamCong);

            if (duLieu == null || duLieu.Count == 0)
            {
                groupThongTinChiTiet.Text = "Lỗi: Nhân viên không có ca làm việc trong ngày này";
                groupThongTinChiTiet.ForeColor = Color.Red;

                return;
            }
            groupThongTinChiTiet.Visible = true;

            // Lấy tất cả các ca X (có chấm công vào/ra)
            var caXList = duLieu.Where(x => x.ChamCong.Trim() == "X").ToList();

            if (caXList.Count == 0)
            {
                // Không có ca X nào, kiểm tra các loại ca khác
                if (duLieu.Any(x => x.ChamCong.Trim() == "P"))
                {
                    lbTen.Text = "Nhân viên có mặt đầy đủ";
                    lbTen.ForeColor = Color.Green;
                }
                else if (duLieu.Any(x => x.ChamCong.Trim() == "KP"))
                {
                    lbTen.Text = "Nhân viên không có mặt";
                    lbTen.ForeColor = Color.Red;
                }
                else if (duLieu.Any(x => x.ChamCong.Trim() == "CT"))
                {
                    lbTen.Text = "Nhân viên công tác";
                    lbTen.ForeColor = Color.Blue;
                }
                else
                {
                    lbTen.Text = "Không có thông tin chấm công";
                    lbTen.ForeColor = Color.Orange;
                }

                // Ẩn thông tin giờ vào/ra vì không có dữ liệu
                //panelGioVaoRa.Visible = false;
                return;
            }

            // Có ít nhất một ca X, hiển thị thông tin giờ vào/ra
           // panelGioVaoRa.Visible = true;

            // Đếm số ca đi trễ hoặc về sớm
            int caDiTre = 0;
            int caVeSom = 0;
            int tongPhutDiTre = 0;
            int tongPhutVeSom = 0;

            // Hiển thị dữ liệu trên GridControl

            // Xử lý kiểm tra đi trễ/về sớm cho từng ca
            foreach (var ca in caXList)
            {
                // Lấy thông tin loại ca để so sánh giờ vào/ra
                LoaiCa loaiCa = loaiCaBL.GetLoaiCas().FirstOrDefault(x => x.IdLoaiCa == ca.IdLoaiCa);
                if (loaiCa != null)
                {
                    // Kiểm tra đi trễ
                    if (ca.ThoiGianVao > loaiCa.GioBatDau)
                    {
                        int phutDiTre = (int)(ca.ThoiGianVao - loaiCa.GioBatDau).TotalMinutes;
                        if (phutDiTre > 0)
                        {
                            caDiTre++;
                            tongPhutDiTre += phutDiTre;
                        }
                    }

                    // Kiểm tra về sớm
                    if (ca.ThoiGianRa < loaiCa.GioKetThuc)
                    {
                        int phutVeSom = (int)(loaiCa.GioKetThuc - ca.ThoiGianRa).TotalMinutes;
                        if (phutVeSom > 0)
                        {
                            caVeSom++;
                            tongPhutVeSom += phutVeSom;
                        }
                    }
                }
            }

            // Hiển thị thông tin trạng thái đi trễ/về sớm
            if (caDiTre > 0 || caVeSom > 0)
            {
                StringBuilder sb = new StringBuilder();
                if (caDiTre > 0)
                {
                    sb.AppendLine($"Đi trễ {caDiTre} ca ({tongPhutDiTre} phút)");
                }
                if (caVeSom > 0)
                {
                    sb.AppendLine($"Về sớm {caVeSom} ca ({tongPhutVeSom} phút)");
                }

                lbTen.Text = sb.ToString();
                lbTen.ForeColor = Color.Orange;
            }
            else
            {
                lbTen.Text = "Nhân viên đi làm đúng giờ";
                lbTen.ForeColor = Color.Green;
            }
        }

        private void FormXemChiTiet_Deactivate(object sender, EventArgs e)
        {
            this.Close();
        }

        private void lblTrangThai_Click(object sender, EventArgs e)
        {

        }

        private void groupBox2_Enter(object sender, EventArgs e)
        {

        }
    }
}