using BusinessLayer;
using DevExpress.XtraEditors;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TransferObject;
using PresentationLayer.BaoCao;
using DevExpress.XtraReports.UI;

namespace PresentationLayer
{
    public partial class FormNhanVien : DevExpress.XtraEditors.XtraForm
    {
        NhanVienBL nhanvienBL;
        NhanVien nv;
        DanTocBL danTocBL;
        TonGiaoBL tonGiaoBL;
        ChucVuBL chucVuBL;
        TrinhDoBL trinhDoBL;
        PhongBanBL phongBanBL;
        BoPhanBL boPhanBL;
        List<NhanVien> nhanViens;
        enum ActionType { add = 0, update = 1, delete = 2 };
        ActionType action;

        private void FormNhanVien_Load(object sender, EventArgs e)
        {
            try
            {
                gcDSNhanVien.DataSource = nhanvienBL.getNhanViens();
                gvDSNhanVien.OptionsBehavior.Editable = false;
                nhanViens = nhanvienBL.getNhanViens();
                LoadCombo();
            }
            catch (SqlException ex)
            {

                throw ex;
            }
            ShowHide(true);
            gvDSNhanVien.CustomColumnDisplayText += gvDSNhanVien_CustomColumnDisplayText;
        }
        public FormNhanVien()
        {
            InitializeComponent();
            nhanvienBL = new NhanVienBL();
            danTocBL = new DanTocBL();
            tonGiaoBL = new TonGiaoBL();
            chucVuBL = new ChucVuBL();
            trinhDoBL = new TrinhDoBL();
            phongBanBL = new PhongBanBL();
            boPhanBL = new BoPhanBL();
        }
        void LoadCombo()
        {
            cboxPhongBan.DataSource = phongBanBL.GetPhongBans();
            cboxPhongBan.DisplayMember = "TenPhongBan";
            cboxPhongBan.ValueMember = "IdPhongBan";

            cboxBoPhan.DataSource = boPhanBL.GetBoPhans();
            cboxBoPhan.DisplayMember = "TenBoPhan";
            cboxBoPhan.ValueMember = "IdBoPhan";

            cboxChucVu.DataSource = chucVuBL.GetChucVus();
            cboxChucVu.DisplayMember = "TenChucVu";
            cboxChucVu.ValueMember = "IdChucVu";

            cboxTrinhDo.DataSource = trinhDoBL.GetTrinhDos();
            cboxTrinhDo.DisplayMember = "TenTrinhDo";
            cboxTrinhDo.ValueMember = "IdTrinhDo";

            cboxDanToc.DataSource = danTocBL.GetDanTocs();
            cboxDanToc.DisplayMember = "TenDanToc";
            cboxDanToc.ValueMember = "IdDanToc";

            cboxTonGiao.DataSource = tonGiaoBL.GetTonGiaos();
            cboxTonGiao.DisplayMember = "TenTonGiao";
            cboxTonGiao.ValueMember = "IdTonGiao";
        }
        void ShowHide(bool kt)
        {
            btLuu.Enabled = !kt;
            btHuy.Enabled = !kt;
            btThem.Enabled = kt;
            btSua.Enabled = kt;
            btXoa.Enabled = kt;
            btnDongg.Enabled = kt;
            btIn.Enabled = kt;
            splitContainer1.Panel1Collapsed = kt;
        }
        void EmptyText()
        {
            txtTenNhanVien.Text = string.Empty;
            txtCCCD.Text = string.Empty;
            txtSDT.Text = string.Empty;
            txtDiaChi.Text = string.Empty;
            rdBtNam.Checked = false;
            rdBtNu.Checked = false;
            txtIdNhanVien.Text = string.Empty;
            cboxBoPhan.Text = string.Empty;
            cboxChucVu.Text = string.Empty;
            cboxDanToc.Text = string.Empty;
            cboxPhongBan.Text = string.Empty;
            cboxTonGiao.Text = string.Empty;
            cboxTrinhDo.Text = string.Empty;
            picHinhAnh.Image = null;
        }
        
        private void btThem_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            action = ActionType.add;
            ShowHide(false);
        }

        private void btSua_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            action = ActionType.update;
            ShowHide(false);
            txtIdNhanVien.Enabled = false;
        }

        private void btXoa_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (nv==null)
            {
                MessageBox.Show("Chưa chọn nhân viên cần xóa!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (MessageBox.Show("Xóa nhân viên có ID: "+nv.IdNhanVien+", tên: "+nv.HoTen+"?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
            {
                action = ActionType.delete;
                ShowHide(true);
                try
                {
                    nhanvienBL.Delete(nv.IdNhanVien);
                }
                catch (SqlException ex)
                {
                    MessageBox.Show(ex.Message, "Loi");
                }
                gcDSNhanVien.DataSource = nhanvienBL.getNhanViens();
                nhanViens = nhanvienBL.getNhanViens();
            }
        }

        private void btLuu_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtTenNhanVien.Text))
            {
                MessageBox.Show("Vui lòng nhập tên nhân viên", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtTenNhanVien.Focus();
                return;
            }

            if (string.IsNullOrWhiteSpace(txtIdNhanVien.Text) || !int.TryParse(txtIdNhanVien.Text, out int idNV))
            {
                MessageBox.Show("Vui lòng nhập ID nhân viên hợp lệ", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtIdNhanVien.Focus();
                return;
            }
            if (rdBtNam.Checked == false && rdBtNu.Checked == false)
            {
                MessageBox.Show("Vui lòng chọn giới tính", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
                nv = new NhanVien();
                nv.IdNhanVien = int.Parse(txtIdNhanVien.Text);
                nv.HoTen = txtTenNhanVien.Text;
                nv.GioiTinh = rdBtNam.Checked;
                nv.NgaySinh = dtNgaySinh.Value;
                nv.DienThoai = txtSDT.Text;
                nv.CCCD = txtCCCD.Text;
                nv.DiaChi = txtDiaChi.Text;

            if (picHinhAnh.Image != null)
            {
                nv.HinhAnh = LuuAnh(picHinhAnh.Image, System.Drawing.Imaging.ImageFormat.Jpeg);
            }
            else
            {
                nv.HinhAnh = null;
            }
            nv.IdPhongBan = Convert.ToInt32(cboxPhongBan.SelectedValue);
                nv.IdBoPhan = Convert.ToInt32(cboxBoPhan.SelectedValue);
                nv.IdChucVu = Convert.ToInt32(cboxChucVu.SelectedValue);
                nv.IdTrinhDo = Convert.ToInt32(cboxTrinhDo.SelectedValue);
                nv.IdDanToc = Convert.ToInt32(cboxDanToc.SelectedValue);
                nv.IdTonGiao = Convert.ToInt32(cboxTonGiao.SelectedValue);
            switch (action)
            
            {
                case ActionType.add:

                    try
                    {
                    nhanvienBL.Add(nv);

                    }
                    catch (SqlException ex)
                    {
                        MessageBox.Show("Thêm không thành công: "+ ex.Message, "Lỗi", MessageBoxButtons.OK);
                    }
                    break;
            
                case ActionType.update:
                    try
                    {
                        nhanvienBL.Update(nv);
                    }
                    catch (SqlException ex)
                    {
                        MessageBox.Show(ex.Message, "Loi");
                    }
                    txtIdNhanVien.Enabled = true;
                    break;
                
                default:
                    break;
            }
            gcDSNhanVien.DataSource = nhanvienBL.getNhanViens();
            nhanViens = nhanvienBL.getNhanViens();
            ShowHide(true);
            EmptyText();
            txtIdNhanVien.Enabled = true;
        }

        private void btHuy_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            ShowHide(true);
            EmptyText();
            txtIdNhanVien.Enabled = true;
        }

        private void btnDongg_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            this.Close();
        }

        public byte[] LuuAnh(Image img, System.Drawing.Imaging.ImageFormat format)
        {
            using (MemoryStream ms = new MemoryStream())
            {
                img.Save(ms, format);
                byte[] imgBytes = ms.ToArray();

                return imgBytes;
            }
        }
        public Image HienThiAnh(byte[] imgBytes)
        {
            // nếu không có ảnh trả về null
            if (imgBytes == null )
            {
                return null;
            }
            try
            {
                MemoryStream ms = new MemoryStream(imgBytes, 0, imgBytes.Length);
                ms.Write(imgBytes, 0, imgBytes.Length);
                Image img = Image.FromStream(ms, true);

                return img;
            }
            catch (Exception ex)
            {
                
                Console.WriteLine($"Lỗi khi chuyển đổi byte[] thành Image: {ex.Message}");
                return null;
            }
        }

      
        private void btnChonHinh_Click_2(object sender, EventArgs e)
        {
            using (OpenFileDialog openFile = new OpenFileDialog())
            {
                openFile.Filter = "Picture files (*.png, *.jpg)|*.png;*.jpg";
                openFile.Title = "Chọn hình ảnh";
                if (openFile.ShowDialog() == DialogResult.OK)
                {
                    try
                    {
                        picHinhAnh.Image = Image.FromFile(openFile.FileName);
                        picHinhAnh.SizeMode = PictureBoxSizeMode.StretchImage;
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Lỗi khi tải hình ảnh: "+ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }
        private void btIn_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            rptDSNhanVien rpt = new rptDSNhanVien(nhanViens);
            rpt.ShowPreview();
        }

        private void gvDSNhanVien_Click(object sender, EventArgs e)
        {
            int Id = int.Parse(gvDSNhanVien.GetFocusedRowCellValue("IdNhanVien").ToString());

            nv = nhanvienBL.getNhanViens().Find(x => x.IdNhanVien == Id);
            txtIdNhanVien.Text = nv.IdNhanVien.ToString();
            txtTenNhanVien.Text = nv.HoTen;

            if (nv.GioiTinh == true)
                rdBtNam.Checked = true;
            else
                rdBtNu.Checked = true;
            dtNgaySinh.Value = nv.NgaySinh;
            txtSDT.Text = nv.DienThoai;
            txtCCCD.Text = nv.CCCD;
            txtDiaChi.Text = nv.DiaChi;
            picHinhAnh.Image = HienThiAnh(nv.HinhAnh);
            cboxPhongBan.SelectedValue = nv.IdPhongBan;
            cboxBoPhan.SelectedValue = nv.IdBoPhan;
            cboxChucVu.SelectedValue = nv.IdChucVu;
            cboxTrinhDo.SelectedValue = nv.IdTrinhDo;
            cboxDanToc.SelectedValue = nv.IdDanToc;
            cboxTonGiao.SelectedValue = nv.IdTonGiao;
        }

        private void gvDSNhanVien_CustomColumnDisplayText(object sender, DevExpress.XtraGrid.Views.Base.CustomColumnDisplayTextEventArgs e)
        {
            if (e.Column.FieldName == "GioiTinh")
            {
                bool gioiTinh = Convert.ToBoolean(e.Value);
                e.DisplayText = gioiTinh ? "Nam" : "Nữ";
            }
        }
    }
}