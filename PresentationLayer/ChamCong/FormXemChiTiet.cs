using BusinessLayer;
using BusinessLayer.ChamCongBL;
using DevExpress.CodeParser;
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
        private LoaiCongBL loaiCongBL;
        private BangCongChiTietBL bangCongChiTietBL;
        private NhanVienBL nhanVienBl;
        private List<BangCongChiTiet> duLieu;

        public FormXemChiTiet()
        {
            InitializeComponent();
            loaiCaBL = new LoaiCaBL();
            loaiCongBL = new LoaiCongBL();
            bangCongChiTietBL = new BangCongChiTietBL();
            kyCongChiTietBL = new KyCongChiTietBL();
            nhanVienBl = new NhanVienBL();
        }

        private void FormXemChiTiet_Load(object sender, EventArgs e)
        {
            duLieu = bangCongChiTietBL.GetNgayCongChiTiet(maKyCong, maNhanVien, ngayChamCong);
            txtTen.Text = nhanVienBl.getNhanViens().Find(x => x.IdNhanVien == maNhanVien).HoTen;
            switch (duLieu.Count)
            {
                case 0:
                    groupThongTinChiTiet.Text = "Nhân viên không có ca làm việc";
                    break;
                case 1:
                    groupThongTinChiTiet.Text += ngayChamCong.ToString("dd/MM/yyyy");
                    txtTrangThai.Text = trangThai(duLieu[0]);
                    txtCa.Text = loaiCaBL.GetLoaiCas().Find(x => x.IdLoaiCa == duLieu[0].IdLoaiCa).TenLoaiCa;
                    txtCong.Text = loaiCongBL.GetLoaiCongs().Find(x => x.ID == duLieu[0].IdLoaiCong).TenLoaiCong;
                    txtGioVao1.Text = duLieu[0].ThoiGianVao.ToString();
                    txtGioRa1.Text = duLieu[0].ThoiGianRa.ToString();
                    if (duLieu[0].IdLoaiCa != 3)
                    {
                        diTre(duLieu[0], txtDiTre);
                        veSom(duLieu[0], txtVeSom1);
                    }
                    break;
                case 2:
                    groupThongTinChiTiet.Text += ngayChamCong.ToString("dd/MM/yyyy");
                    txtTrangThai.Text = trangThai(duLieu[0]);
                    txtTrangThai2.Text = trangThai(duLieu[1]);

                    txtCa.Text = loaiCaBL.GetLoaiCas().Find(x => x.IdLoaiCa == duLieu[0].IdLoaiCa).TenLoaiCa;
                    txtCa2.Text = loaiCaBL.GetLoaiCas().Find(x => x.IdLoaiCa == duLieu[1].IdLoaiCa).TenLoaiCa;
                    txtCong.Text = loaiCongBL.GetLoaiCongs().Find(x => x.ID == duLieu[0].IdLoaiCong).TenLoaiCong;
                    txtCong2.Text = loaiCongBL.GetLoaiCongs().Find(x => x.ID == duLieu[1].IdLoaiCong).TenLoaiCong;
                    txtGioVao1.Text = duLieu[0].ThoiGianVao.ToString();
                    txtGioVao2.Text = duLieu[1].ThoiGianVao.ToString();
                    txtGioRa1.Text = duLieu[0].ThoiGianRa.ToString();
                    txtGioRa2.Text = duLieu[1].ThoiGianRa.ToString();
                    if (duLieu[0].IdLoaiCa != 3)
                    {
                        diTre(duLieu[0], txtDiTre);
                        veSom(duLieu[0], txtVeSom1);
                    }
                    if (duLieu[1].IdLoaiCa != 3)
                    {
                        diTre(duLieu[1], txtDiTre2);
                        veSom(duLieu[1], txtVeSom2);
                    }
                    break;
                case 3:
                    groupThongTinChiTiet.Text += ngayChamCong.ToString("dd/MM/yyyy");
                    txtTrangThai.Text = trangThai(duLieu[0]);
                    txtTrangThai2.Text = trangThai(duLieu[1]);
                    txtTrangThai3.Text = trangThai(duLieu[2]);
                    txtCa.Text = loaiCaBL.GetLoaiCas().Find(x => x.IdLoaiCa == duLieu[0].IdLoaiCa).TenLoaiCa;
                    txtCa2.Text = loaiCaBL.GetLoaiCas().Find(x => x.IdLoaiCa == duLieu[1].IdLoaiCa).TenLoaiCa;
                    txtCa3.Text = loaiCaBL.GetLoaiCas().Find(x => x.IdLoaiCa == duLieu[2].IdLoaiCa).TenLoaiCa;
                    txtCong.Text = loaiCongBL.GetLoaiCongs().Find(x => x.ID == duLieu[0].IdLoaiCong).TenLoaiCong;
                    txtCong2.Text = loaiCongBL.GetLoaiCongs().Find(x => x.ID == duLieu[1].IdLoaiCong).TenLoaiCong;
                    txtCong3.Text = loaiCongBL.GetLoaiCongs().Find(x => x.ID == duLieu[2].IdLoaiCong).TenLoaiCong;
                    txtGioVao1.Text = duLieu[0].ThoiGianVao.ToString();
                    txtGioVao2.Text = duLieu[1].ThoiGianVao.ToString();
                    txtGioVao3.Text = duLieu[2].ThoiGianVao.ToString();
                    txtGioRa1.Text = duLieu[0].ThoiGianRa.ToString();
                    txtGioRa2.Text = duLieu[1].ThoiGianRa.ToString();
                    txtGioRa3.Text = duLieu[2].ThoiGianRa.ToString();

                    if (duLieu[0].IdLoaiCa != 3)
                    {
                        diTre(duLieu[0], txtDiTre);
                        veSom(duLieu[0], txtVeSom1);
                    }
                    if (duLieu[1].IdLoaiCa != 3)
                    {
                        diTre(duLieu[1], txtDiTre2);
                        veSom(duLieu[1], txtVeSom2);
                    }
                    if (duLieu[2].IdLoaiCa != 3)
                    {
                        diTre(duLieu[2], txtDiTre3);
                        veSom(duLieu[2], txtVeSom3);
                    }
                    break;
            }
            TinhTangCa(duLieu, txtLamThem);
            TinhThoiGianNghi(duLieu,txtNghiCT);
        }

        private string trangThai(BangCongChiTiet ca)
        {
            if (ca.ChamCong == "X")
                return "Đi làm";
            if (ca.ChamCong == "CT")
                return "Công tác";
            if (ca.ChamCong == "P")
                return "Nghỉ phép";
            if (ca.ChamCong == "KP")
                return "Nghỉ K.Phép";
            return "";
        }
        private void diTre(BangCongChiTiet ca, System.Windows.Forms.Label textBox)
        {
            if (ca.IdLoaiCa == 3 || ca.ChamCong == "P" || ca.ChamCong == "KP" || ca.ChamCong == "CT")
                return;
            int tongPhutDiTre = 0;
            LoaiCa loaiCa = loaiCaBL.GetLoaiCas().Find(x => x.IdLoaiCa == ca.IdLoaiCa);
            if (ca.ThoiGianVao > loaiCa.GioBatDau)
            {
                int phutDiTre = (int)(ca.ThoiGianVao - loaiCa.GioBatDau).TotalMinutes;
                if (phutDiTre > 0)
                {
                    tongPhutDiTre += phutDiTre;
                    textBox.Text = tongPhutDiTre.ToString();
                }
            }
        }
        private void veSom(BangCongChiTiet ca, System.Windows.Forms.Label textBox)
        {
            if (ca.IdLoaiCa == 3 || ca.ChamCong=="P"|| ca.ChamCong=="KP" || ca.ChamCong == "CT")
                return;
            int tongPhutVeSom = 0;
            LoaiCa loaiCa = loaiCaBL.GetLoaiCas().Find(x => x.IdLoaiCa == ca.IdLoaiCa);
            if (ca.ThoiGianRa < loaiCa.GioKetThuc)
            {
                int phutVeSom = (int)(loaiCa.GioKetThuc - ca.ThoiGianRa).TotalMinutes;
                if (phutVeSom > 0)
                {
                    tongPhutVeSom += phutVeSom;
                    textBox.Text = tongPhutVeSom.ToString();
                }
            }
        }

        private void TinhTangCa(List<BangCongChiTiet> cacCa, System.Windows.Forms.Label lb)
        {
            int tongPhutTangCa = 0;
            foreach (var ca in cacCa) {
                if (ca.ChamCong == "X")
                {
                    LoaiCa loaiCa = loaiCaBL.GetLoaiCas().Find(x => x.IdLoaiCa == ca.IdLoaiCa);
                    int phutTangCa = (int)(ca.ThoiGianRa - loaiCa.GioKetThuc).TotalMinutes;
                    if (phutTangCa > 0)
                        tongPhutTangCa += tongPhutTangCa += phutTangCa;

                }
            }
            tongPhutTangCa -= 480;
            if(tongPhutTangCa>0)
            {int hours = tongPhutTangCa / 60;
            int minutes = tongPhutTangCa % 60;
                lb.Text = $"{hours}:{minutes:D2}";
            }
        }
        private void TinhThoiGianNghi(List<BangCongChiTiet> cacCa, System.Windows.Forms.Label textBox)
        {
            int tong=0;
            foreach (var ca in cacCa)
            {
                if (ca.ChamCong == "CT" || ca.ChamCong == "P" || ca.ChamCong == "KP")
                    tong += 4;
            }
            textBox.Text = tong.ToString();
        }



        private void FormXemChiTiet_Deactivate(object sender, EventArgs e)
        {
            this.Dispose();
            this.Close();
        }

        private void lblTrangThai_Click(object sender, EventArgs e)
        {

        }

        private void groupBox2_Enter(object sender, EventArgs e)
        {

        }

        private void txtVeSom_Click(object sender, EventArgs e)
        {

        }
    }
}