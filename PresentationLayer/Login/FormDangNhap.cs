using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using System.Xml.Linq;
using BusinessLayer;
using TransferObject;

namespace PresentationLayer 
{
    public partial class FormDangNhap : Form
    {
        public string TenDangNhap { get; private set; }
        public string VaiTro { get; private set; }


        public FormDangNhap()
        {
            InitializeComponent();
        }

        

        
        private void pbShow_MouseHover(object sender, EventArgs e)
        {
            toolTip1.SetToolTip(pbShow, "Hiển thị mật khẩu");
        }

        private void pbHide_MouseHover(object sender, EventArgs e)
        {
            toolTip1.SetToolTip(pbHide, "Ẩn mật khẩu");
        }
        private void pbShow_Click(object sender, EventArgs e)
        {
            pbShow.Hide();
            txtMatKhau.UseSystemPasswordChar = false;
            pbHide.Show();
        }

        private void pbHide_Click(object sender, EventArgs e)
        {
            pbHide.Hide();
            txtMatKhau.UseSystemPasswordChar = true;
            pbShow.Show();
        }

        private void btLogin_Click(object sender, EventArgs e)
        {
            string tenDangNhap = txtTenDangNhap.Text.Trim();
            string matKhau = txtMatKhau.Text.Trim();

            if (string.IsNullOrEmpty(tenDangNhap) || string.IsNullOrEmpty(matKhau))
            {
                MessageBox.Show("Vui lòng nhập đầy đủ tên đăng nhập và mật khẩu!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                TaiKhoanAdminBL taiKhoanBL = new TaiKhoanAdminBL();
                TaiKhoan taiKhoan = taiKhoanBL.DangNhap(tenDangNhap, matKhau);

                if (taiKhoan != null)
                {
                    this.TenDangNhap = taiKhoan.TenDangNhap;
                    this.VaiTro = taiKhoan.VaiTro;
                    this.DialogResult = DialogResult.OK;
                }
                else
                {
                    MessageBox.Show("Tên đăng nhập hoặc mật khẩu không đúng!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txtMatKhau.Clear();
                    txtMatKhau.Focus();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi: " + ex.Message, "Lỗi hệ thống", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        private void frmDangNhap_Load(object sender, EventArgs e)
        {

        }

        private void lbExit_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Bạn có chắc chắn muốn thoát khỏi chương trình?", "Xác nhận thoát", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {
                Application.Exit();
            }
        }

       

        private void txtMatKhau_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                btLogin.PerformClick();
            }
        }
    }
}
