using BusinessLayer;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace PresentationLayer
{
    public partial class FormDoiMatKhau : DevExpress.XtraEditors.XtraForm
    {
        private string tenDangNhap;
        private TaiKhoanNhanVienBL taiKhoannhanvienBL = new TaiKhoanNhanVienBL();
        public FormDoiMatKhau(string tenDangNhapHienTai)
        {
            InitializeComponent();
            tenDangNhap = tenDangNhapHienTai;
        }

        private void FormDoiMatKhau_Load(object sender, EventArgs e)
        {

            
        }

        private void btDoiMatKhau_Click(object sender, EventArgs e)
        {
           
            string matKhauCu = txtMatKhauHienTai.Text.Trim();
            string matKhauMoi = txtMatKhauMoi.Text.Trim();
            string xacNhanMK = txtXacNhanMatKhau.Text.Trim();

            if (matKhauMoi != xacNhanMK)
            {
                MessageBox.Show("Mật khẩu xác nhận không khớp!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            
            bool doiThanhCong = taiKhoannhanvienBL.DoiMatKhau(tenDangNhap, matKhauCu, matKhauMoi);

            if (doiThanhCong)
            {
                MessageBox.Show("Sai mật khẩu hiện tại!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.Close();
            }
            else
            {
                MessageBox.Show("Đổi mật khẩu thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }

        }

        private void btHuy_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void pbHide1_Click(object sender, EventArgs e)
        {
            txtMatKhauHienTai.UseSystemPasswordChar = false;
            pbHide1.Hide();
            pbShow1.Show();
        }

        private void pbShow1_Click(object sender, EventArgs e)
        {
            txtMatKhauHienTai.UseSystemPasswordChar = true;
            pbShow1.Visible = false;
            pbHide1.Visible = true;
        }

        private void pbHide2_Click(object sender, EventArgs e)
        {
            txtMatKhauMoi.UseSystemPasswordChar = false;
            pbHide2.Visible = false;
            pbShow2.Visible = true;
        }

        private void pbShow2_Click(object sender, EventArgs e)
        {
            txtMatKhauMoi.UseSystemPasswordChar = true;
            pbShow2.Visible = false;
            pbHide2.Visible = true;
        }

        private void pbHide3_Click(object sender, EventArgs e)
        {
            txtXacNhanMatKhau.UseSystemPasswordChar = false;
            pbHide3.Visible = false;
            pbShow3.Visible = true;
        }

        private void pbShow3_Click(object sender, EventArgs e)
        {
            txtXacNhanMatKhau.UseSystemPasswordChar = true;
            pbShow3.Visible = false;
            pbHide3.Visible = true;
        }
    }
}
