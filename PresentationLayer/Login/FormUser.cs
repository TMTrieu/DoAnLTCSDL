using System;
using System.Windows.Forms;
using BusinessLayer;
using TransferObject;

namespace PresentationLayer
{
    public partial class FormUser : Form
    {
        private string username;
        private TaiKhoanNhanVienBL taiKhoanNhanVienBL = new TaiKhoanNhanVienBL();

        public FormUser()
        {
            InitializeComponent();
            this.IsMdiContainer = true;
        }

        public void SetUserInfo(string username)
        {
            this.username = username;
            
        }

        private void FormUser_Load(object sender, EventArgs e)
        {
            
        }

        private void btThoat_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            DialogResult result = MessageBox.Show(
                "Bạn có chắc chắn muốn đăng xuất không?",
                "Xác nhận đăng xuất",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question
            );

            if (result == DialogResult.Yes)
            {
                Application.Restart(); 
            }
        }

        private void btNhanVien_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            int idNhanVien = taiKhoanNhanVienBL.LayMaTaiKhoan(username);
            if (idNhanVien > 0)
            {
                FormThongTinCaNhan form = new FormThongTinCaNhan(idNhanVien);
                form.ShowDialog();
            }
            else
            {
                MessageBox.Show("Không tìm thấy thông tin tài khoản!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btDoiMatKhau_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (!string.IsNullOrEmpty(username))
            {
               FormDoiMatKhau form = new FormDoiMatKhau(username);
                form.ShowDialog(); 
            }
            else
            {
                MessageBox.Show("Không tìm thấy tài khoản đăng nhập!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
