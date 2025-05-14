using BusinessLayer;
using DevExpress.XtraEditors;
using DevExpress.XtraLayout.Customization;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TransferObject;

namespace PresentationLayer
{
    public partial class FormThongTinCaNhan : DevExpress.XtraEditors.XtraForm
    {
        private NhanVienBL nhanVienBL = new NhanVienBL();
        private NhanVien nhanVien;
        private int idNhanVien;

        public FormThongTinCaNhan(int idNhanVien)
        {
            InitializeComponent();
            this.idNhanVien = idNhanVien;

        }
        private void FormThongTinCaNhan_Load(object sender, EventArgs e)
        {
            LoadThongTin(idNhanVien);
          
        }
        private void LoadThongTin(int idNhanVien)
        {
            nhanVien = nhanVienBL.getNhanViens().FirstOrDefault(x=>x.IdNhanVien==idNhanVien);
            if (nhanVien != null)
            {
                txtIdNhanVien.Text = nhanVien.IdNhanVien.ToString();
                txtHoTen.Text = nhanVien.HoTen;
                rdNam.Checked = nhanVien.GioiTinh;
                rdNu.Checked = !nhanVien.GioiTinh;
                dtNgaySinh.Value = nhanVien.NgaySinh;
                txtCCCD.Text = nhanVien.CCCD;
                txtDienThoai.Text = nhanVien.DienThoai;
                txtDiaChi.Text = nhanVien.DiaChi;
                txtChucVu.Text = nhanVien.TenChucVu;
                txtTrinhDo.Text = nhanVien.TenTrinhDo;
                txtPhongBan.Text = nhanVien.TenPhongBan;
                txtBoPhan.Text = nhanVien.TenBoPhan;
                txtDanToc.Text = nhanVien.TenDanToc;
                txtTonGiao.Text = nhanVien.TenTonGiao;

                if (nhanVien.HinhAnh != null)
                {
                    using (MemoryStream ms = new MemoryStream(nhanVien.HinhAnh))
                    {
                        picHinhAnh.Image = Image.FromStream(ms);
                    }
                }
                else
                {
                    picHinhAnh.Image = Properties.Resources.Noimage1; // Ảnh mặc định
                }
            }
        }

        private void btCapNhatThongTin_Click(object sender, EventArgs e)
        {
            nhanVien.HoTen = txtHoTen.Text.Trim();
            nhanVien.NgaySinh = dtNgaySinh.Value;
            nhanVien.DienThoai = txtDienThoai.Text.Trim();
            nhanVien.CCCD = txtCCCD.Text.Trim();
            nhanVien.DiaChi = txtDiaChi.Text.Trim();
            nhanVien.TenDanToc = txtDanToc.Text.Trim();
            nhanVien.TenTonGiao = txtTonGiao.Text.Trim();
            if (picHinhAnh.Image != null)
            {
                using (MemoryStream ms = new MemoryStream())
                {
                    picHinhAnh.Image.Save(ms, picHinhAnh.Image.RawFormat);
                    nhanVien.HinhAnh = ms.ToArray();
                }
            }

            nhanVienBL.Update(nhanVien);
            MessageBox.Show("Cập nhật thành công!");

        }


        private void picHinhAnh_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog ofd = new OpenFileDialog())
            {
                ofd.Filter = "Image Files|*.jpg;*.jpeg;*.png;*.bmp";
                if (ofd.ShowDialog() == DialogResult.OK)
                {
                    picHinhAnh.Image = Image.FromFile(ofd.FileName);
                }
            }
        }
    }
}
