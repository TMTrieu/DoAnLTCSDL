using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BusinessLayer;
using DevExpress.XtraReports.UI;
using PresentationLayer.BaoCao;

namespace PresentationLayer
{
    public partial class FormBangLuong : DevExpress.XtraEditors.XtraForm
    {
        private BangLuongBL bangLuongBL;
        private int maKyCong;
        public int nam;
        public int thang;
        public FormBangLuong()
        {
            InitializeComponent();
            bangLuongBL = new BangLuongBL();
            
        }

        private void FormBangLuong_Load(object sender, EventArgs e)
        {
            try
            { 
            maKyCong = nam *100 + thang;
            gcDSBangLuong.DataSource = bangLuongBL.GetListByMaKyCong(maKyCong);
            gvDSBangLuong.OptionsBehavior.Editable = false;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi load bảng lương: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void btnThem_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            bangLuongBL.TinhLuongNhanVien(maKyCong);
            loadData();
        }
        
       
        void loadData()
        {
            gcDSBangLuong.DataSource=bangLuongBL.GetListByMaKyCong(maKyCong);
            
        }

        private void btnIn_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
           rptBangLuong rpt=new rptBangLuong();
            rpt.ShowPreviewDialog();
        }

        private void btDong_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            this.Close();
        }

        private void gvDSBangLuong_Click(object sender, EventArgs e)
        {

        }

        private void spXemBangLuong_Click(object sender, EventArgs e)
        {
            maKyCong = nam *100+thang;
            loadData();
        }

        
    }
}
