namespace PresentationLayer.ChamCong
{
    partial class FormNgayCongChiTiet
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
            this.gridColumn3 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn5 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.LoaiCong = new DevExpress.XtraGrid.Columns.GridColumn();
            this.chCbBLoaiCong = new DevExpress.XtraEditors.CheckedComboBoxEdit();
            this.LoaiCa = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn2 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.ID = new DevExpress.XtraGrid.Columns.GridColumn();
            this.tEGioRa = new DevExpress.XtraEditors.TimeEdit();
            this.gridView1 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.gridColumn6 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridControl1 = new DevExpress.XtraGrid.GridControl();
            this.btCapNhat = new System.Windows.Forms.Button();
            this.chCbBLoaiCa = new DevExpress.XtraEditors.CheckedComboBoxEdit();
            this.label6 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.groupControl1 = new DevExpress.XtraEditors.GroupControl();
            this.radioGroup1 = new DevExpress.XtraEditors.RadioGroup();
            this.tEGioVao = new DevExpress.XtraEditors.TimeEdit();
            this.label7 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.chCbBLoaiCong.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tEGioRa.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chCbBLoaiCa.Properties)).BeginInit();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl1)).BeginInit();
            this.groupControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.radioGroup1.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tEGioVao.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // gridColumn3
            // 
            this.gridColumn3.Caption = "Trạng thái";
            this.gridColumn3.FieldName = "ChamCong";
            this.gridColumn3.MinWidth = 30;
            this.gridColumn3.Name = "gridColumn3";
            this.gridColumn3.Visible = true;
            this.gridColumn3.VisibleIndex = 6;
            this.gridColumn3.Width = 112;
            // 
            // gridColumn5
            // 
            this.gridColumn5.Caption = "Giờ vào";
            this.gridColumn5.FieldName = "ThoiGianVao";
            this.gridColumn5.MinWidth = 30;
            this.gridColumn5.Name = "gridColumn5";
            this.gridColumn5.Visible = true;
            this.gridColumn5.VisibleIndex = 4;
            this.gridColumn5.Width = 134;
            // 
            // LoaiCong
            // 
            this.LoaiCong.Caption = "Loại công";
            this.LoaiCong.FieldName = "TenLoaiCong";
            this.LoaiCong.MinWidth = 30;
            this.LoaiCong.Name = "LoaiCong";
            this.LoaiCong.Visible = true;
            this.LoaiCong.VisibleIndex = 3;
            this.LoaiCong.Width = 135;
            // 
            // chCbBLoaiCong
            // 
            this.chCbBLoaiCong.Location = new System.Drawing.Point(313, 49);
            this.chCbBLoaiCong.Name = "chCbBLoaiCong";
            this.chCbBLoaiCong.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.chCbBLoaiCong.Properties.SelectAllItemVisible = false;
            this.chCbBLoaiCong.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.Standard;
            this.chCbBLoaiCong.Size = new System.Drawing.Size(178, 26);
            this.chCbBLoaiCong.TabIndex = 7;
            // 
            // LoaiCa
            // 
            this.LoaiCa.AppearanceCell.Options.UseTextOptions = true;
            this.LoaiCa.AppearanceCell.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
            this.LoaiCa.Caption = "Loại ca";
            this.LoaiCa.FieldName = "TenLoaiCa";
            this.LoaiCa.MinWidth = 30;
            this.LoaiCa.Name = "LoaiCa";
            this.LoaiCa.Visible = true;
            this.LoaiCa.VisibleIndex = 2;
            this.LoaiCa.Width = 146;
            // 
            // gridColumn2
            // 
            this.gridColumn2.Caption = "Ngày";
            this.gridColumn2.FieldName = "NgayChamCong";
            this.gridColumn2.MinWidth = 30;
            this.gridColumn2.Name = "gridColumn2";
            this.gridColumn2.Visible = true;
            this.gridColumn2.VisibleIndex = 1;
            this.gridColumn2.Width = 101;
            // 
            // ID
            // 
            this.ID.Caption = "ID";
            this.ID.FieldName = "IdBangCong";
            this.ID.MinWidth = 30;
            this.ID.Name = "ID";
            this.ID.Visible = true;
            this.ID.VisibleIndex = 0;
            this.ID.Width = 50;
            // 
            // tEGioRa
            // 
            this.tEGioRa.EditValue = new System.TimeOnly(12, 0, 0, 0, 0);
            this.tEGioRa.Location = new System.Drawing.Point(519, 128);
            this.tEGioRa.Name = "tEGioRa";
            this.tEGioRa.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.tEGioRa.Properties.MaskSettings.Set("MaskManagerType", typeof(DevExpress.Data.Mask.TimeOnlyMaskManager));
            this.tEGioRa.Properties.MaskSettings.Set("MaskManagerSignature", "allowNull=False");
            this.tEGioRa.Properties.MaskSettings.Set("mask", "HH:mm:ss");
            this.tEGioRa.Size = new System.Drawing.Size(159, 26);
            this.tEGioRa.TabIndex = 10;
            // 
            // gridView1
            // 
            this.gridView1.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.ID,
            this.gridColumn2,
            this.LoaiCa,
            this.LoaiCong,
            this.gridColumn5,
            this.gridColumn6,
            this.gridColumn3});
            this.gridView1.GridControl = this.gridControl1;
            this.gridView1.Name = "gridView1";
            this.gridView1.OptionsView.ShowGroupPanel = false;
            this.gridView1.Click += new System.EventHandler(this.gridView1_Click);
            // 
            // gridColumn6
            // 
            this.gridColumn6.Caption = "Giờ ra";
            this.gridColumn6.FieldName = "ThoiGianRa";
            this.gridColumn6.MinWidth = 30;
            this.gridColumn6.Name = "gridColumn6";
            this.gridColumn6.Visible = true;
            this.gridColumn6.VisibleIndex = 5;
            this.gridColumn6.Width = 122;
            // 
            // gridControl1
            // 
            this.gridControl1.Location = new System.Drawing.Point(12, 194);
            this.gridControl1.MainView = this.gridView1;
            this.gridControl1.Name = "gridControl1";
            this.gridControl1.Size = new System.Drawing.Size(839, 271);
            this.gridControl1.TabIndex = 14;
            this.gridControl1.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView1});
            // 
            // btCapNhat
            // 
            this.btCapNhat.Location = new System.Drawing.Point(738, 59);
            this.btCapNhat.Name = "btCapNhat";
            this.btCapNhat.Size = new System.Drawing.Size(86, 78);
            this.btCapNhat.TabIndex = 0;
            this.btCapNhat.Text = "Cập nhật";
            this.btCapNhat.UseVisualStyleBackColor = true;
            this.btCapNhat.Click += new System.EventHandler(this.btCapNhat_Click);
            // 
            // chCbBLoaiCa
            // 
            this.chCbBLoaiCa.Location = new System.Drawing.Point(313, 128);
            this.chCbBLoaiCa.Name = "chCbBLoaiCa";
            this.chCbBLoaiCa.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.chCbBLoaiCa.Properties.SelectAllItemVisible = false;
            this.chCbBLoaiCa.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.Standard;
            this.chCbBLoaiCa.Properties.EditValueChanged += new System.EventHandler(this.chCbBLoaiCa_Properties_EditValueChanged);
            this.chCbBLoaiCa.Size = new System.Drawing.Size(178, 26);
            this.chCbBLoaiCa.TabIndex = 7;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.label6.Location = new System.Drawing.Point(515, 24);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(76, 22);
            this.label6.TabIndex = 8;
            this.label6.Text = "Giờ vào";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.chCbBLoaiCong);
            this.groupBox2.Controls.Add(this.tEGioRa);
            this.groupBox2.Controls.Add(this.btCapNhat);
            this.groupBox2.Controls.Add(this.chCbBLoaiCa);
            this.groupBox2.Controls.Add(this.groupControl1);
            this.groupBox2.Controls.Add(this.tEGioVao);
            this.groupBox2.Controls.Add(this.label7);
            this.groupBox2.Controls.Add(this.label6);
            this.groupBox2.Controls.Add(this.label4);
            this.groupBox2.Controls.Add(this.label5);
            this.groupBox2.Location = new System.Drawing.Point(12, 7);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(839, 181);
            this.groupBox2.TabIndex = 13;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Thông tin";
            // 
            // groupControl1
            // 
            this.groupControl1.Controls.Add(this.radioGroup1);
            this.groupControl1.GroupStyle = DevExpress.Utils.GroupStyle.Card;
            this.groupControl1.Location = new System.Drawing.Point(19, 27);
            this.groupControl1.Margin = new System.Windows.Forms.Padding(4);
            this.groupControl1.Name = "groupControl1";
            this.groupControl1.Size = new System.Drawing.Size(269, 139);
            this.groupControl1.TabIndex = 3;
            this.groupControl1.Text = "Chấm công";
            // 
            // radioGroup1
            // 
            this.radioGroup1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.radioGroup1.Location = new System.Drawing.Point(2, 32);
            this.radioGroup1.Margin = new System.Windows.Forms.Padding(4);
            this.radioGroup1.Name = "radioGroup1";
            this.radioGroup1.Properties.Columns = 2;
            this.radioGroup1.Properties.GlyphAlignment = DevExpress.Utils.HorzAlignment.Default;
            this.radioGroup1.Properties.Items.AddRange(new DevExpress.XtraEditors.Controls.RadioGroupItem[] {
            new DevExpress.XtraEditors.Controls.RadioGroupItem("X", "Đi làm"),
            new DevExpress.XtraEditors.Controls.RadioGroupItem("CT", "Công tác"),
            new DevExpress.XtraEditors.Controls.RadioGroupItem("P", "Nghỉ phép"),
            new DevExpress.XtraEditors.Controls.RadioGroupItem("KP", "Vắng")});
            this.radioGroup1.Size = new System.Drawing.Size(265, 105);
            this.radioGroup1.TabIndex = 0;
            this.radioGroup1.EditValueChanged += new System.EventHandler(this.radioGroup1_EditValueChanged);
            // 
            // tEGioVao
            // 
            this.tEGioVao.EditValue = new System.TimeOnly(8, 0, 0, 0, 0);
            this.tEGioVao.Location = new System.Drawing.Point(519, 49);
            this.tEGioVao.Name = "tEGioVao";
            this.tEGioVao.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.tEGioVao.Properties.MaskSettings.Set("MaskManagerType", typeof(DevExpress.Data.Mask.TimeOnlyMaskManager));
            this.tEGioVao.Properties.MaskSettings.Set("MaskManagerSignature", "allowNull=False");
            this.tEGioVao.Properties.MaskSettings.Set("mask", "HH:mm:ss");
            this.tEGioVao.Size = new System.Drawing.Size(159, 26);
            this.tEGioVao.TabIndex = 10;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.label7.Location = new System.Drawing.Point(515, 103);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(63, 22);
            this.label7.TabIndex = 8;
            this.label7.Text = "Giờ ra";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.label4.Location = new System.Drawing.Point(311, 24);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(96, 22);
            this.label4.TabIndex = 8;
            this.label4.Text = "Loại công";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.label5.Location = new System.Drawing.Point(311, 103);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(73, 22);
            this.label5.TabIndex = 8;
            this.label5.Text = "Loại ca";
            // 
            // FormNgayCongChiTiet
            // 
            this.Appearance.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.Appearance.Options.UseBackColor = true;
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 19F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(868, 477);
            this.Controls.Add(this.gridControl1);
            this.Controls.Add(this.groupBox2);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FormNgayCongChiTiet";
            this.Text = "Chỉnh sửa bảng công";
            this.Load += new System.EventHandler(this.FormCapNhatNgayCong_Load);
            ((System.ComponentModel.ISupportInitialize)(this.chCbBLoaiCong.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tEGioRa.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chCbBLoaiCa.Properties)).EndInit();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl1)).EndInit();
            this.groupControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.radioGroup1.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tEGioVao.Properties)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraGrid.Columns.GridColumn gridColumn3;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn5;
        private DevExpress.XtraGrid.Columns.GridColumn LoaiCong;
        private DevExpress.XtraEditors.CheckedComboBoxEdit chCbBLoaiCong;
        private DevExpress.XtraGrid.Columns.GridColumn LoaiCa;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn2;
        private DevExpress.XtraGrid.Columns.GridColumn ID;
        private DevExpress.XtraEditors.TimeEdit tEGioRa;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView1;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn6;
        private DevExpress.XtraGrid.GridControl gridControl1;
        private System.Windows.Forms.Button btCapNhat;
        private DevExpress.XtraEditors.CheckedComboBoxEdit chCbBLoaiCa;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.GroupBox groupBox2;
        private DevExpress.XtraEditors.GroupControl groupControl1;
        private DevExpress.XtraEditors.RadioGroup radioGroup1;
        private DevExpress.XtraEditors.TimeEdit tEGioVao;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
    }
}