
using System;
using System.Collections.Generic;
using System.Windows.Forms;
using BusinessLayer;
using TransferObject;
using System.Data.SqlClient;
using DevExpress.XtraGrid.Views.Grid;

namespace PresentationLayer
{
    public partial class FormDuyetThoiViec : DevExpress.XtraEditors.XtraForm
    {
        private YeuCauThoiViecBL _ycTVBL;
        private List<YeuCauThoiViec> _dsYeuCau;
        private int _idNhanVien;
        public FormDuyetThoiViec(int idNhanVien)
        {
            InitializeComponent();
            _ycTVBL = new YeuCauThoiViecBL();
            _idNhanVien = idNhanVien;
        }

        private void btnPheDuyet_Click(object sender, EventArgs e)
        {

            var yc = LayYeuCauDangChon();
            if (yc != null)
            {
                yc.GhiChu = txtGhiChu.Text.Trim(); // Lấy ghi chú từ người dùng nhập
                yc.NgayPheDuyet = DateTime.Now;

                if (_ycTVBL.PheDuyetYeuCau(yc, true))
                {
                    MessageBox.Show("Đã phê duyệt.");
                    LoadYeuCau();
                }
                else
                {
                    MessageBox.Show("Lỗi khi cập nhật.");
                }
            }
            else
            {
                MessageBox.Show("Vui lòng chọn một yêu cầu.");
            }
            txtGhiChu.Clear();
        }

        private void FormDuyetThoiViec_Load(object sender, EventArgs e)
        {
            try
            {
                dgcYeuCau.DataSource = _ycTVBL.GetYeuCaus();
                dgvYeuCau.OptionsBehavior.Editable = false;
            }
            catch (SqlException ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void LoadYeuCau()
        {
            _dsYeuCau = _ycTVBL.GetYeuCaus();
            dgcYeuCau.DataSource = _dsYeuCau;
        }

        private YeuCauThoiViec LayYeuCauDangChon()
        {

            var view = dgvYeuCau as GridView;
            if (view.FocusedRowHandle >= 0)
            {
                // Lấy object bind trực tiếp từ GridControl (nếu DataSource là List<YeuCauThoiViec>)
                var yc = view.GetRow(view.FocusedRowHandle) as YeuCauThoiViec;

                // Kiểm tra null và IdYeuCau hợp lệ
                if (yc != null && yc.IdYeuCau > 0)
                {
                    return yc;
                }
            }
            return null;
        }

        private void btnTuChoi_Click(object sender, EventArgs e)
        {
            var yc = LayYeuCauDangChon();
            if (yc != null)
            {
                //yc.GhiChu = "Không hợp lệ";
                yc.GhiChu = txtGhiChu.Text.Trim(); // Lấy ghi chú từ người dùng nhập
                yc.NgayPheDuyet = DateTime.Now;

                if (_ycTVBL.PheDuyetYeuCau(yc, false))
                {
                    MessageBox.Show("Đã từ chối.");
                    LoadYeuCau();
                }
                else
                {
                    MessageBox.Show("Lỗi khi cập nhật.");
                }
            }
            else
            {
                MessageBox.Show("Vui lòng chọn một yêu cầu.");
            }
            txtGhiChu.Clear();
        }

        private void dgvYeuCau_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            var yc = LayYeuCauDangChon();
            if (yc != null)
            {
                txtGhiChu.Text = yc.GhiChu;
            }
        }
    }
}