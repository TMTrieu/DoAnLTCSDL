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
using BusinessLayer;
using BusinessLayer.ChamCongBL;
using System.Data.SqlClient;
using DevExpress.XtraEditors.Mask;
using DevExpress.XtraEditors.Repository;
using DevExpress.XtraGrid.Columns;
using DevExpress.Utils;
using DevExpress.XtraGrid.Views.Grid;
using DevExpress.XtraGrid;
using DevExpress.XtraExport.Helpers;
using DevExpress.XtraCharts.Native;

namespace PresentationLayer.ChamCong
{
    public partial class FormKyCongChiTiet : DevExpress.XtraEditors.XtraForm
    {
        KyCongChiTietBL kyCongChiTietBL;
        public int thang;
        public int nam;
        public int maKyCong;
        public int maNhanVien;
        public bool daChamCong;
        public KyCongChiTiet kyCongChiTiet;
        private BangCongChiTietBL bangCongChiTietBL;
        private LoaiCaBL loaiCaBL;
        public FormKyCongChiTiet()
        {
            InitializeComponent();
            kyCongChiTietBL = new KyCongChiTietBL();

            bangCongChiTietBL = new BangCongChiTietBL();
            loaiCaBL = new LoaiCaBL();
        }
        private void BangCongChiTiet_Load(object sender, EventArgs e)
        {
            try
            {
                dgcBangCong.DataSource = kyCongChiTietBL.GetKyCongChiTiets(maKyCong);
                dgvBangCong.OptionsBehavior.Editable = false;
                CustomView(thang, nam);
            }
            catch (SqlException ex)
            {
                MessageBox.Show(ex.Message);
            }
            cbBThang.Text = thang.ToString();
            cbBNam.Text = nam.ToString();
            dgvBangCong.FocusedRowHandle = 0;
            chBKhoa.Enabled = false;
            if (daChamCong)
                chBKhoa.Checked = true;

        }
        private void loadBangCong()
        {
            thang = int.Parse(cbBThang.Text);
            nam = int.Parse(cbBNam.Text);
            maKyCong = nam * 100 + thang;
            try
            {
                dgcBangCong.DataSource = kyCongChiTietBL.GetKyCongChiTiets(maKyCong);
            }
            catch (SqlException ex)
            {
                MessageBox.Show(ex.Message);
            }
            CustomView(thang, nam);
        }
        private void btnPhatSinhKyCong_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            try
            {
                thang = int.Parse(cbBThang.Text);
                nam = int.Parse(cbBNam.Text);

                kyCongChiTietBL.PhatSinhKyCong(thang, nam);
                loadBangCong();
            }
            catch (SqlException ex)
            {
                MessageBox.Show("Đã tồn tại bảng công chi tiết này!\n" + ex.Message, "Không thể phát sinh!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void CustomView(int thang, int nam)
        {
            try
            {
                DevExpress.LookAndFeel.UserLookAndFeel.Default.SetSkinStyle("WXI");

                // Tùy chỉnh giao diện GridView
                dgvBangCong.OptionsView.ShowGroupPanel = false; // Ẩn group panel
                dgvBangCong.OptionsView.ShowIndicator = true; // Hiển thị cột chỉ số
                dgvBangCong.OptionsSelection.EnableAppearanceFocusedCell = true; // Hiển thị ô được chọn
                dgvBangCong.OptionsSelection.EnableAppearanceFocusedRow = true; // Hiển thị hàng được chọn
                dgvBangCong.OptionsView.EnableAppearanceOddRow = true; // Kích hoạt màu cho hàng lẻ
                dgvBangCong.OptionsView.EnableAppearanceEvenRow = true; // Kích hoạt màu cho hàng chẵn
                dgvBangCong.Appearance.OddRow.BackColor = Color.FromArgb(245, 245, 245); // Màu nhạt cho hàng lẻ
                dgvBangCong.Appearance.EvenRow.BackColor = Color.White; // Màu trắng cho hàng chẵn
                dgvBangCong.Appearance.Row.Font = new Font("Tahoma", 8F); // Font hiện đại
                dgvBangCong.Appearance.HeaderPanel.Font = new Font("Tahoma", 8F, FontStyle.Bold); // Font tiêu đề

                // 2. Tùy chỉnh các cột hiện có
                foreach (GridColumn gridColumn in dgvBangCong.Columns)
                {
                    if (gridColumn.FieldName == "HoTen") continue;

                    RepositoryItemTextEdit textEdit = new RepositoryItemTextEdit();
                    textEdit.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.RegEx;
                    textEdit.Mask.EditMask = @"\p{Lu}+"; // Giữ nguyên logic mask
                    gridColumn.ColumnEdit = textEdit;

                    // Căn giữa nội dung ô
                    gridColumn.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
                    gridColumn.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;

                    // Thêm viền cho ô
                    gridColumn.AppearanceCell.Options.UseBorderColor = true;
                    gridColumn.AppearanceCell.BorderColor = Color.LightGray;
                }

                // 3. Tùy chỉnh cột D1-D31
                int daysInMonth = DateTime.DaysInMonth(nam, thang);
                for (int i = 1; i <= daysInMonth; i++)
                {
                    DateTime newDate = new DateTime(nam, thang, i);
                    string fieldName = "D" + i;
                    GridColumn column = dgvBangCong.Columns[fieldName];

                    if (column == null) continue; // Kiểm tra cột tồn tại

                    // Căn chỉnh và viền
                    column.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
                    column.AppearanceHeader.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
                    column.AppearanceHeader.TextOptions.WordWrap = WordWrap.Wrap; // Bật wrap text
                    column.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
                    column.AppearanceCell.Options.UseBorderColor = true;
                    column.AppearanceCell.BorderColor = Color.LightGray;

                    // Tùy chỉnh giao diện theo ngày
                    switch (newDate.DayOfWeek.ToString())
                    {
                        case "Monday":
                            column.Caption = $"T.Hai{Environment.NewLine}{i}";
                            column.OptionsColumn.AllowEdit = true;
                            column.AppearanceHeader.ForeColor = Color.White;
                            column.AppearanceHeader.BackColor = Color.FromArgb(0, 120, 215); // Màu xanh dương đậm
                            column.AppearanceHeader.BackColor2 = Color.FromArgb(0, 172, 255); // Gradient
                            column.AppearanceHeader.GradientMode = System.Drawing.Drawing2D.LinearGradientMode.Vertical;
                            column.AppearanceCell.ForeColor = Color.Black;
                            column.AppearanceCell.BackColor = Color.FromArgb(240, 248, 255); // AliceBlue
                            column.OptionsColumn.AllowFocus = true;
                            column.Width = 60; // Tăng chiều rộng cột
                            break;

                        case "Tuesday":
                            column.Caption = $"T.Ba{Environment.NewLine}{i}";
                            column.OptionsColumn.AllowEdit = true;
                            column.AppearanceHeader.ForeColor = Color.White;
                            column.AppearanceHeader.BackColor = Color.FromArgb(0, 120, 215);
                            column.AppearanceHeader.BackColor2 = Color.FromArgb(0, 172, 255);
                            column.AppearanceHeader.GradientMode = System.Drawing.Drawing2D.LinearGradientMode.Vertical;
                            column.AppearanceCell.ForeColor = Color.Black;
                            column.AppearanceCell.BackColor = Color.FromArgb(240, 248, 255);
                            column.OptionsColumn.AllowFocus = true;
                            column.Width = 60;
                            break;

                        case "Wednesday":
                            column.Caption = $"T.Tư{Environment.NewLine}{i}";
                            column.OptionsColumn.AllowEdit = true;
                            column.AppearanceHeader.ForeColor = Color.White;
                            column.AppearanceHeader.BackColor = Color.FromArgb(0, 120, 215);
                            column.AppearanceHeader.BackColor2 = Color.FromArgb(0, 172, 255);
                            column.AppearanceHeader.GradientMode = System.Drawing.Drawing2D.LinearGradientMode.Vertical;
                            column.AppearanceCell.ForeColor = Color.Black;
                            column.AppearanceCell.BackColor = Color.FromArgb(240, 248, 255);
                            column.OptionsColumn.AllowFocus = true;
                            column.Width = 60;
                            break;

                        case "Thursday":
                            column.Caption = $"T.Năm{Environment.NewLine}{i}";
                            column.OptionsColumn.AllowEdit = true;
                            column.AppearanceHeader.ForeColor = Color.White;
                            column.AppearanceHeader.BackColor = Color.FromArgb(0, 120, 215);
                            column.AppearanceHeader.BackColor2 = Color.FromArgb(0, 172, 255);
                            column.AppearanceHeader.GradientMode = System.Drawing.Drawing2D.LinearGradientMode.Vertical;
                            column.AppearanceCell.ForeColor = Color.Black;
                            column.AppearanceCell.BackColor = Color.FromArgb(240, 248, 255);
                            column.OptionsColumn.AllowFocus = true;
                            column.Width = 60;
                            break;

                        case "Friday":
                            column.Caption = $"T.Sáu{Environment.NewLine}{i}";
                            column.OptionsColumn.AllowEdit = true;
                            column.AppearanceHeader.ForeColor = Color.White;
                            column.AppearanceHeader.BackColor = Color.FromArgb(0, 120, 215);
                            column.AppearanceHeader.BackColor2 = Color.FromArgb(0, 172, 255);
                            column.AppearanceHeader.GradientMode = System.Drawing.Drawing2D.LinearGradientMode.Vertical;
                            column.AppearanceCell.ForeColor = Color.Black;
                            column.AppearanceCell.BackColor = Color.FromArgb(240, 248, 255);
                            column.OptionsColumn.AllowFocus = true;
                            column.Width = 60;
                            break;

                        case "Saturday":
                            column.Caption = $"T.Bảy{Environment.NewLine}{i}";
                            column.OptionsColumn.AllowEdit = true;
                            column.AppearanceHeader.ForeColor = Color.White;
                            column.AppearanceHeader.BackColor = Color.FromArgb(255, 69, 0); // Màu đỏ cam
                            column.AppearanceHeader.BackColor2 = Color.FromArgb(255, 140, 0);
                            column.AppearanceHeader.GradientMode = System.Drawing.Drawing2D.LinearGradientMode.Vertical;
                            column.AppearanceCell.ForeColor = Color.Black;
                            column.AppearanceCell.BackColor = Color.FromArgb(255, 245, 220); // Màu vàng nhạt
                            column.OptionsColumn.AllowFocus = true;
                            column.Width = 60;
                            break;

                        case "Sunday":
                            column.Caption = $"CN{Environment.NewLine}{i}";
                            column.OptionsColumn.AllowEdit = false;
                            column.AppearanceHeader.ForeColor = Color.White;
                            column.AppearanceHeader.BackColor = Color.FromArgb(220, 20, 60); // Màu đỏ đậm
                            column.AppearanceHeader.BackColor2 = Color.FromArgb(255, 99, 71);
                            column.AppearanceHeader.GradientMode = System.Drawing.Drawing2D.LinearGradientMode.Vertical;
                            column.AppearanceCell.ForeColor = Color.Black;
                            column.AppearanceCell.BackColor = Color.FromArgb(255, 228, 225); // Màu hồng nhạt
                            column.Width = 60;
                            break;
                    }
                }

                // 4. Ẩn các cột không cần thiết (D[daysInMonth+1] đến D31)
                for (int j = daysInMonth + 1; j <= 31; j++)
                {
                    string fieldName = "D" + j;
                    GridColumn column = dgvBangCong.Columns[fieldName];
                    if (column != null)
                    {
                        column.Visible = false;
                    }
                }

                // 5. Tinh chỉnh thêm giao diện
                dgvBangCong.RowHeight = 30; // Tăng chiều cao hàng
                dgvBangCong.Appearance.HeaderPanel.BorderColor = Color.FromArgb(100, 100, 100); // Viền tiêu đề
                dgvBangCong.Appearance.Row.BorderColor = Color.FromArgb(200, 200, 200); // Viền hàng
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi tùy chỉnh giao diện: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ctMSCapNhat_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (daChamCong == true)
                MessageBox.Show("Kỳ công này đã bị khóa, không thể thực hiện", "Kỳ đã khóa", MessageBoxButtons.OK, MessageBoxIcon.Error);
            else
            {
                FormNgayCongChiTiet frmCNNC = new FormNgayCongChiTiet();
                frmCNNC.maNhanVien = maNhanVien;
                frmCNNC.maKyCong = maKyCong;
                DateTime ngayChon = new DateTime(nam, thang, ngay);
                frmCNNC.ngayChamCong = ngayChon;
                frmCNNC.ShowDialog();

                string result = frmCNNC.ketQua;
                if (result != "KP" && result != null)
                {
                    try
                    {
                        kyCongChiTietBL.CapNhatBangCong(tenCot, result, maKyCong, maNhanVien);
                    }
                    catch (SqlException ex)
                    {
                        MessageBox.Show(ex.Message);
                    }
                }
                else if (result == "KP")
                    try
                    {
                        kyCongChiTietBL.CapNhatBangCong(tenCot, "", maKyCong, maNhanVien);
                    }
                    catch (SqlException ex)
                    {
                        MessageBox.Show(ex.Message);
                    }
                CapNhatThongKeCong(maKyCong, maNhanVien);
                loadBangCong();
            }
        }

        private string tenCot;
        private string giaTriO;
        private int ngay;

        private void dgvBangCong_RowCellClick_1(object sender, RowCellClickEventArgs e)
        {
            tenCot = dgvBangCong.FocusedColumn.FieldName;
            giaTriO = dgvBangCong.GetFocusedRowCellValue(tenCot).ToString();
            int.TryParse(tenCot.Substring(1), out ngay);
            maNhanVien = int.Parse(dgvBangCong.GetFocusedRowCellValue("MaNhanVien").ToString());
        }

        private void dgvBangCong_DoubleClick_1(object sender, EventArgs e)
        {
            ctMenuStrip.ShowPopup(Cursor.Position);
        }

        public void CapNhatThongKeCong(int maKyCong, int maNhanVien)
        {
            int soNgayTrongThang = DateTime.DaysInMonth(nam, thang);
            double ngayCong = 0;
            double ngayPhep = 0;
            double nghiKhongPhep = 0;
            double congNgayLe = 0;
            double congNgayNghi = 0;

            for (int i = 1; i <= soNgayTrongThang; i++)
            {
                DateTime ngayChamCong = new DateTime(nam, thang, i);
                List<BangCongChiTiet> congNgay = bangCongChiTietBL.GetNgayCongChiTiet(maKyCong, maNhanVien, ngayChamCong);

                bool laNgayNghi = LaNgayNghi(ngayChamCong);
                bool laNgayLe = LaNgayLe(ngayChamCong);

                if (congNgay != null)
                {
                    foreach (var cong in congNgay)
                    {

                        switch (cong.ChamCong.Trim())
                        {
                            case "CT":
                                ngayCong += 0.5;
                                break;
                            case "X":

                                if (laNgayLe)
                                    congNgayLe += TinhHeSoTheoCa(cong.IdLoaiCa, cong);
                                else if (laNgayNghi)
                                    congNgayNghi += TinhHeSoTheoCa(cong.IdLoaiCa, cong);
                                else
                                    ngayCong += TinhHeSoTheoCa(cong.IdLoaiCa, cong);
                                break;
                            case "P":
                                ngayPhep += 0.5;
                                break;

                            case "KP":
                                nghiKhongPhep += 0.5;
                                break;
                        }
                    }
                }
                else
                        if (!laNgayNghi && !laNgayLe)
                    nghiKhongPhep += 1;
            }
            ngayCong = Math.Round(ngayCong, 2);
            ngayPhep = Math.Round(ngayPhep, 2);
            nghiKhongPhep = Math.Round(nghiKhongPhep, 2);
            congNgayLe = Math.Round(congNgayLe, 2);
            congNgayNghi = Math.Round(congNgayNghi, 2);
            double tongNgayCong = ngayCong + ngayPhep + congNgayLe + congNgayNghi;
            kyCongChiTietBL.CapNhatBangCong("NgayCong", ngayCong.ToString(), maKyCong, maNhanVien);
            kyCongChiTietBL.CapNhatBangCong("NgayPhep", ngayPhep.ToString(), maKyCong, maNhanVien);
            kyCongChiTietBL.CapNhatBangCong("NghiKhongPhep", nghiKhongPhep.ToString(), maKyCong, maNhanVien);
            kyCongChiTietBL.CapNhatBangCong("CongNgayLe", congNgayLe.ToString(), maKyCong, maNhanVien);
            kyCongChiTietBL.CapNhatBangCong("CongNgayNghi", congNgayNghi.ToString(), maKyCong, maNhanVien);
            kyCongChiTietBL.CapNhatBangCong("TongNgayCong", tongNgayCong.ToString(), maKyCong, maNhanVien);
        }
        private double TinhHeSoTheoCa(int idLoaiCa, BangCongChiTiet cong)
        {
            switch (idLoaiCa) //he so moi 4 tieng
            {
                case 1:
                    return 0.5;
                case 2:
                    return 0.5;
                case 3:
                    {
                        double soGioLamViec;
                        if (cong.ThoiGianRa < cong.ThoiGianVao)
                            soGioLamViec = (24 - cong.ThoiGianVao.TotalHours) + cong.ThoiGianRa.TotalHours;
                        else
                            soGioLamViec = cong.ThoiGianRa.TotalHours - cong.ThoiGianVao.TotalHours;
                        return soGioLamViec * 0.75;
                    }
                default:
                    return 0;
            }
        }
        private bool LaNgayNghi(DateTime ngay)
        {
            return ngay.DayOfWeek == DayOfWeek.Saturday || ngay.DayOfWeek == DayOfWeek.Sunday;
        }

        private bool LaNgayLe(DateTime ngay)
        {
            var ngayLe = new List<DateTime>
    {
        new DateTime(ngay.Year, 1, 1),
        new DateTime(ngay.Year, 4, 30),
        new DateTime(ngay.Year, 5, 1),
        new DateTime(ngay.Year, 9, 2)
    };

            return ngayLe.Any(x => x.Day == ngay.Day && x.Month == ngay.Month);
        }

        private void btnXem_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            loadBangCong();
        }

        private void btnLamMoi_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            loadBangCong();
        }

        private void btDong_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            this.Close();
        }
    }

}