using System;
using System.Windows.Forms;
using BusinessLayer;
using TransferObject;
using System.Collections.Generic;


namespace PresentationLayer
{
    public partial class FormYeuCauThoiViec : DevExpress.XtraEditors.XtraForm
    {
        private YeuCauThoiViecBL yeuCauBL;
        private int _idNhanVien;

        public FormYeuCauThoiViec(int idNV)
        {
            InitializeComponent();
            yeuCauBL = new YeuCauThoiViecBL();
            this._idNhanVien = idNV;
        }

        private async void btGuiYeuCau_Click(object sender, EventArgs e)
        {
            string lyDo = txtLyDo.Text.Trim();


            if (string.IsNullOrEmpty(lyDo))
            {
                MessageBox.Show("Vui lòng nhập lý do thôi việc.", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }



            YeuCauThoiViec yc = new YeuCauThoiViec
            {

                IdNhanVien = _idNhanVien,
                NgayYeuCau = DateTime.Now,
                LyDo = lyDo,
                TrangThai = "ChoDuyet",
                NgayPheDuyet = null,
                GhiChu = null
            };
            // Gửi yêu cầu và lấy IdYeuCau
            int idYeuCau = yeuCauBL.GuiYeuCauVaLayId(yc);
            if (idYeuCau <= 0)
            {
                MessageBox.Show("Gửi yêu cầu thất bại. Vui lòng thử lại sau.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }



            MessageBox.Show("Yêu cầu thôi việc đã được gửi thành công.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            txtLyDo.Clear();


            // Load lại danh sách
            dgcYeuCau.DataSource = yeuCauBL.GetYeuCau(_idNhanVien);
        }

        private void FormYeuCauThoiViec_Load(object sender, EventArgs e)
        {
            List<YeuCauThoiViec> danhSach = yeuCauBL.GetYeuCau(_idNhanVien);
            dgcYeuCau.DataSource = danhSach;
        }

    }
}