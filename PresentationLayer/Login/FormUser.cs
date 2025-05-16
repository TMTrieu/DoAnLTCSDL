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
        private YeuCauThoiViecBL yeuCauBL;
        private int _idNhanVien; // ID nhân viên được truyền vào khi đăng nhập
      
        public FormUser(int idNV)
        {
            InitializeComponent();
            yeuCauBL = new YeuCauThoiViecBL();
            this._idNhanVien = idNV;

            this.IsMdiContainer = true;
        }
        private void OpenForm(Form form)
        {
            foreach (Form frm in MdiChildren)
            {
                if (frm.GetType() == form.GetType())
                {
                    frm.Activate();
                    return;
                }
            }
            form.MdiParent = this;
            form.Show();
        }
        public void SetUserInfo(string username)
        {
            this.username = username;
            
        }
        public void NhanVien(int idNhanVien)
        {
            this._idNhanVien = idNhanVien;
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
            OpenForm(new FormThongTinCaNhan(_idNhanVien));
        }

        private void btDoiMatKhau_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            OpenForm(new FormDoiMatKhau(username));
        }

        private void btThoiViec_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            OpenForm(new FormYeuCauThoiViec(_idNhanVien));
        }

      
    }
}
