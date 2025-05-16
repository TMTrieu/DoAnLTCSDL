using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using DevExpress.XtraBars;
using DevExpress.XtraEditors.ColorPick.Picker;

namespace PresentationLayer
{
	public partial class FormAdmin: DevExpress.XtraBars.Ribbon.RibbonForm
	{
        private  int _idNhanVien;
        public FormAdmin()
		{
            InitializeComponent();
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
        private void MainForm_Load(object sender, EventArgs e)
        {
           
        }

        private void btDanToc_ItemClick(object sender, ItemClickEventArgs e)
        {

            OpenForm(new FormDanToc());
        }

        private void btPhongBan_ItemClick(object sender, ItemClickEventArgs e)
        {
            OpenForm(new FormPhongBan());
        }

        private void btChucVu_ItemClick(object sender, ItemClickEventArgs e)
        {
            OpenForm(new FormChucVu());
        }

        private void btBoPhan_ItemClick(object sender, ItemClickEventArgs e)
        {
            OpenForm(new FormBoPhan());
        }

        private void btLoaiCa_ItemClick(object sender, ItemClickEventArgs e)
        {
            OpenForm(new FormLoaiCa());
        }

        private void btLoaiCong_ItemClick(object sender, ItemClickEventArgs e)
        {

            OpenForm(new FormLoaiCong());
        }

        private void btThoat_ItemClick(object sender, ItemClickEventArgs e)
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

        private void btHopDong_ItemClick(object sender, ItemClickEventArgs e)
        {
            OpenForm(new FormHopDongLaoDong());
        }

        private void btBangCong_ItemClick(object sender, ItemClickEventArgs e)
        {
            OpenForm(new FormKyCong());
        }

        private void btPhuCap_ItemClick(object sender, ItemClickEventArgs e)
        {
            OpenForm(new FormPhuCap());
        }

        private void btTangCa_ItemClick(object sender, ItemClickEventArgs e)
        {
            OpenForm(new FormTangCa());
        }

        private void btTonGiao_ItemClick(object sender, ItemClickEventArgs e)
        {
            OpenForm(new FormTonGiao());
        }

        private void btTrinhDo_ItemClick(object sender, ItemClickEventArgs e)
        {
            OpenForm(new FormTrinhDo());
        }

        private void btNhanVien_ItemClick(object sender, ItemClickEventArgs e)
        {
            OpenForm(new FormNhanVien());
        }

        private void btBangLuong_ItemClick(object sender, ItemClickEventArgs e)
        {
            OpenForm(new FormBangLuong());
        }

        private void btThoiViec_ItemClick(object sender, ItemClickEventArgs e)
        {
            OpenForm(new FormDuyetThoiViec(_idNhanVien));
        }
    }
}