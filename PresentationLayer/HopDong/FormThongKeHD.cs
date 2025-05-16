using BusinessLayer;
using DevExpress.XtraCharts;
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

namespace PresentationLayer
{
    public partial class FormThongKeHD : DevExpress.XtraEditors.XtraForm
    {
        private ThongKeHDTheoLoaiBL thongkeHDTheoLoaiBL = new ThongKeHDTheoLoaiBL();
        public FormThongKeHD()
        {
            InitializeComponent();
        }

        private void FormThongKeHD_Load(object sender, EventArgs e)
        {
            for (int year = 2020; year <= DateTime.Now.Year; year++)
            {
                cboNam.Items.Add(year);
            }

            cboNam.SelectedIndexChanged += cboNam_SelectedIndexChanged;
            cboNam.SelectedIndex = cboNam.Items.Count - 1;
        }
        private void cboNam_SelectedIndexChanged(object sender, EventArgs e)
        {
            int nam = Convert.ToInt32(cboNam.SelectedItem);
            var thoiHanList = thongkeHDTheoLoaiBL.LayDanhSachThoiHanTheoNam(nam);

            cboThoiHan.Items.Clear();
            foreach (var th in thoiHanList)
            {
                cboThoiHan.Items.Add(th);
            }

            if (cboThoiHan.Items.Count > 0)
                cboThoiHan.SelectedIndex = 0;

            HienThiBieuDo();
        }

        private void HienThiBieuDo()
        {


            if (cboNam.SelectedItem == null || cboThoiHan.SelectedItem == null) return;

            int nam = Convert.ToInt32(cboNam.SelectedItem);
            string thoiHan = cboThoiHan.SelectedItem.ToString(); // truyền thẳng chuỗi "3 tháng", "6 tháng" v.v.

            var duLieu = thongkeHDTheoLoaiBL.LayDuLieuThongKeTheoNamVaThoiHan(nam, thoiHan);

            chartThongKeHD.Series.Clear();
            Series series = new Series("Thống kê theo thời hạn", ViewType.Bar);

            foreach (var item in duLieu)
            {
                series.Points.Add(new SeriesPoint(item.LoaiHopDong, item.SoLuong));
            }

            chartThongKeHD.Series.Add(series);
            chartThongKeHD.Series[0].ChangeView(ViewType.Bar);
        }

        

        private void btXem_Click(object sender, EventArgs e)
        {
            HienThiBieuDo();
        }
    }
}