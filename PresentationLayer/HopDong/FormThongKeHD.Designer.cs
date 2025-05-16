namespace PresentationLayer
{
    partial class FormThongKeHD
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            DevExpress.XtraCharts.XYDiagram xyDiagram2 = new DevExpress.XtraCharts.XYDiagram();
            DevExpress.XtraCharts.Series series2 = new DevExpress.XtraCharts.Series();
            DevExpress.XtraCharts.SideBySideBarSeriesView sideBySideBarSeriesView2 = new DevExpress.XtraCharts.SideBySideBarSeriesView();
            DevExpress.XtraCharts.ChartTitle chartTitle2 = new DevExpress.XtraCharts.ChartTitle();
            this.chartThongKeHD = new DevExpress.XtraCharts.ChartControl();
            this.cboNam = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.btXem = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.cboThoiHan = new System.Windows.Forms.ComboBox();
            ((System.ComponentModel.ISupportInitialize)(this.chartThongKeHD)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(xyDiagram2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(series2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(sideBySideBarSeriesView2)).BeginInit();
            this.SuspendLayout();
            // 
            // chartThongKeHD
            // 
            xyDiagram2.AxisX.VisibleInPanesSerializable = "-1";
            xyDiagram2.AxisY.VisibleInPanesSerializable = "-1";
            this.chartThongKeHD.Diagram = xyDiagram2;
            this.chartThongKeHD.Legend.BackColor = System.Drawing.Color.White;
            this.chartThongKeHD.Legend.Name = "Hợp Đồng theo thời hạn";
            this.chartThongKeHD.Location = new System.Drawing.Point(93, 122);
            this.chartThongKeHD.Name = "chartThongKeHD";
            series2.Name = "Thời Hạn";
            series2.SeriesID = 1;
            sideBySideBarSeriesView2.Color = System.Drawing.Color.FromArgb(((int)(((byte)(49)))), ((int)(((byte)(133)))), ((int)(((byte)(155)))));
            series2.View = sideBySideBarSeriesView2;
            this.chartThongKeHD.SeriesSerializable = new DevExpress.XtraCharts.Series[] {
        series2};
            this.chartThongKeHD.Size = new System.Drawing.Size(604, 339);
            this.chartThongKeHD.TabIndex = 0;
            chartTitle2.DXFont = new DevExpress.Drawing.DXFont("Times New Roman", 14F, DevExpress.Drawing.DXFontStyle.Bold);
            chartTitle2.Text = "Hợp Đồng Theo Thời Hạn";
            chartTitle2.TitleID = 0;
            this.chartThongKeHD.Titles.AddRange(new DevExpress.XtraCharts.ChartTitle[] {
            chartTitle2});
            // 
            // cboNam
            // 
            this.cboNam.FormattingEnabled = true;
            this.cboNam.Location = new System.Drawing.Point(153, 49);
            this.cboNam.Name = "cboNam";
            this.cboNam.Size = new System.Drawing.Size(121, 24);
            this.cboNam.TabIndex = 1;
            this.cboNam.SelectedIndexChanged += new System.EventHandler(this.cboNam_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(100, 51);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(47, 22);
            this.label1.TabIndex = 2;
            this.label1.Text = "Năm";
            // 
            // btXem
            // 
            this.btXem.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
            this.btXem.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btXem.Location = new System.Drawing.Point(560, 28);
            this.btXem.Name = "btXem";
            this.btXem.Size = new System.Drawing.Size(108, 54);
            this.btXem.TabIndex = 5;
            this.btXem.Text = "Xem";
            this.btXem.UseVisualStyleBackColor = false;
            this.btXem.Click += new System.EventHandler(this.btXem_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(289, 48);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(80, 22);
            this.label2.TabIndex = 4;
            this.label2.Text = "Thời hạn";
            // 
            // cboThoiHan
            // 
            this.cboThoiHan.FormattingEnabled = true;
            this.cboThoiHan.Location = new System.Drawing.Point(375, 46);
            this.cboThoiHan.Name = "cboThoiHan";
            this.cboThoiHan.Size = new System.Drawing.Size(121, 24);
            this.cboThoiHan.TabIndex = 3;
            // 
            // FormThongKeHD
            // 
            this.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.Appearance.Options.UseBackColor = true;
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(816, 519);
            this.Controls.Add(this.btXem);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.cboThoiHan);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.cboNam);
            this.Controls.Add(this.chartThongKeHD);
            this.Name = "FormThongKeHD";
            this.Text = "FormThongKeHD";
            this.Load += new System.EventHandler(this.FormThongKeHD_Load);
            ((System.ComponentModel.ISupportInitialize)(xyDiagram2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(sideBySideBarSeriesView2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(series2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chartThongKeHD)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraCharts.ChartControl chartThongKeHD;
        private System.Windows.Forms.ComboBox cboNam;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btXem;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox cboThoiHan;
    }
}