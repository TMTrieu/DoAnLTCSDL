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
	public partial class MainForm: DevExpress.XtraBars.Ribbon.RibbonForm
	{
        public MainForm()
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
            this.Show();
            this.Enabled = false;
            FormDangNhap frmDangNhap= new FormDangNhap();
            DialogResult result = frmDangNhap.ShowDialog();
            if (result == DialogResult.OK)
            {
                this.Enabled = true;
            }
            else
                Application.Exit();
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
    }
}