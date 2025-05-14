using BusinessLayer;
using DevExpress.XtraReports.UI;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using TransferObject;

namespace PresentationLayer 
{
    public partial class rptHDLaoDong : DevExpress.XtraReports.UI.XtraReport
    {

        List<HDLaoDong> _lstHD;

        public rptHDLaoDong()
        {
            InitializeComponent();
        }
        public rptHDLaoDong(List<HDLaoDong> lstHD)
        {
            InitializeComponent();
            this._lstHD = lstHD;
            this.DataSource = _lstHD;

            loadData();
        }
       

        void loadData()
        {
            lblSoHD.DataBindings.Add("Text",_lstHD, "SoHD");  

        }



    }
}
