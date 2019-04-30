namespace UFIDA.U8.UAP.CustomApp.ControlForm
{
    partial class 产成品入库单条形码打印
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region 组件设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(产成品入库单条形码打印));
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            this.gridControl1 = new DevExpress.XtraGrid.GridControl();
            this.gridView1 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.ItemLookUpEdit存货编码 = new DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit();
            this.ItemLookUpEdit存货名称 = new DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit();
            this.ItemLookUpEdit规格型号 = new DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit();
            this.btnRefresh = new DevExpress.XtraEditors.SimpleButton();
            this.dateEdit单据日期1 = new DevExpress.XtraEditors.DateEdit();
            this.label1 = new System.Windows.Forms.Label();
            this.dateEdit单据日期2 = new DevExpress.XtraEditors.DateEdit();
            this.lookUpEdit单据号1 = new DevExpress.XtraEditors.LookUpEdit();
            this.label3 = new System.Windows.Forms.Label();
            this.lookUpEdit单据号2 = new DevExpress.XtraEditors.LookUpEdit();
            this.btnExcel = new DevExpress.XtraEditors.SimpleButton();
            this.btnPrint = new DevExpress.XtraEditors.SimpleButton();
            this.radio未完成 = new System.Windows.Forms.RadioButton();
            this.radio全部 = new System.Windows.Forms.RadioButton();
            this.tsbClearCon = new DevExpress.XtraEditors.SimpleButton();
            this.btnPrintSet = new DevExpress.XtraEditors.SimpleButton();
            this.chk全选 = new System.Windows.Forms.CheckBox();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ItemLookUpEdit存货编码)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ItemLookUpEdit存货名称)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ItemLookUpEdit规格型号)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dateEdit单据日期1.Properties.VistaTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dateEdit单据日期1.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dateEdit单据日期2.Properties.VistaTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dateEdit单据日期2.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lookUpEdit单据号1.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lookUpEdit单据号2.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // labelControl1
            // 
            this.labelControl1.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.labelControl1.Appearance.Font = new System.Drawing.Font("Tahoma", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelControl1.Location = new System.Drawing.Point(360, 16);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(168, 25);
            this.labelControl1.TabIndex = 109;
            this.labelControl1.Text = "入库单条形码打印";
            // 
            // gridControl1
            // 
            this.gridControl1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.gridControl1.Location = new System.Drawing.Point(7, 190);
            this.gridControl1.LookAndFeel.SkinName = "Office 2010 Blue";
            this.gridControl1.MainView = this.gridView1;
            this.gridControl1.Name = "gridControl1";
            this.gridControl1.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.ItemLookUpEdit存货编码,
            this.ItemLookUpEdit存货名称,
            this.ItemLookUpEdit规格型号});
            this.gridControl1.Size = new System.Drawing.Size(881, 207);
            this.gridControl1.TabIndex = 113;
            this.gridControl1.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView1});
            // 
            // gridView1
            // 
            this.gridView1.GridControl = this.gridControl1;
            this.gridView1.IndicatorWidth = 40;
            this.gridView1.Name = "gridView1";
            this.gridView1.OptionsBehavior.AllowDeleteRows = DevExpress.Utils.DefaultBoolean.True;
            this.gridView1.OptionsBehavior.Editable = false;
            this.gridView1.OptionsBehavior.EditorShowMode = DevExpress.Utils.EditorShowMode.MouseDown;
            this.gridView1.OptionsCustomization.AllowGroup = false;
            this.gridView1.OptionsCustomization.AllowQuickHideColumns = false;
            this.gridView1.OptionsView.ColumnAutoWidth = false;
            this.gridView1.OptionsView.ShowGroupPanel = false;
            this.gridView1.CustomDrawRowIndicator += new DevExpress.XtraGrid.Views.Grid.RowIndicatorCustomDrawEventHandler(this.gridView1_CustomDrawRowIndicator);
            // 
            // ItemLookUpEdit存货编码
            // 
            this.ItemLookUpEdit存货编码.AutoHeight = false;
            this.ItemLookUpEdit存货编码.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.ItemLookUpEdit存货编码.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("cInvCode", "存货编码"),
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("cInvName", "存货名称"),
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("cInvStd", "规格型号")});
            this.ItemLookUpEdit存货编码.DisplayMember = "cInvCode";
            this.ItemLookUpEdit存货编码.Name = "ItemLookUpEdit存货编码";
            this.ItemLookUpEdit存货编码.NullText = "";
            this.ItemLookUpEdit存货编码.PopupWidth = 600;
            this.ItemLookUpEdit存货编码.ValueMember = "cInvCode";
            // 
            // ItemLookUpEdit存货名称
            // 
            this.ItemLookUpEdit存货名称.AutoHeight = false;
            this.ItemLookUpEdit存货名称.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.ItemLookUpEdit存货名称.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("cInvCode", "存货编码"),
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("cInvName", "存货名称"),
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("cInvStd", "规格型号")});
            this.ItemLookUpEdit存货名称.DisplayMember = "cInvName";
            this.ItemLookUpEdit存货名称.Name = "ItemLookUpEdit存货名称";
            this.ItemLookUpEdit存货名称.NullText = "";
            this.ItemLookUpEdit存货名称.ValueMember = "cInvCode";
            // 
            // ItemLookUpEdit规格型号
            // 
            this.ItemLookUpEdit规格型号.AutoHeight = false;
            this.ItemLookUpEdit规格型号.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.ItemLookUpEdit规格型号.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("cInvCode", "存货编码"),
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("cInvName", "存货名称"),
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("cInvStd", "规格型号")});
            this.ItemLookUpEdit规格型号.DisplayMember = "cInvStd";
            this.ItemLookUpEdit规格型号.Name = "ItemLookUpEdit规格型号";
            this.ItemLookUpEdit规格型号.NullText = "";
            this.ItemLookUpEdit规格型号.ValueMember = "cInvCode";
            // 
            // btnRefresh
            // 
            this.btnRefresh.Image = ((System.Drawing.Image)(resources.GetObject("btnRefresh.Image")));
            this.btnRefresh.ImageLocation = DevExpress.XtraEditors.ImageLocation.TopCenter;
            this.btnRefresh.Location = new System.Drawing.Point(421, 59);
            this.btnRefresh.Name = "btnRefresh";
            this.btnRefresh.Size = new System.Drawing.Size(46, 41);
            this.btnRefresh.TabIndex = 115;
            this.btnRefresh.Text = "过滤";
            this.btnRefresh.Click += new System.EventHandler(this.btnRefresh_Click);
            // 
            // dateEdit单据日期1
            // 
            this.dateEdit单据日期1.EditValue = null;
            this.dateEdit单据日期1.Location = new System.Drawing.Point(82, 80);
            this.dateEdit单据日期1.Name = "dateEdit单据日期1";
            this.dateEdit单据日期1.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.dateEdit单据日期1.Properties.VistaTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
            this.dateEdit单据日期1.Size = new System.Drawing.Size(121, 20);
            this.dateEdit单据日期1.TabIndex = 116;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(17, 87);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(53, 12);
            this.label1.TabIndex = 117;
            this.label1.Text = "单据日期";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // dateEdit单据日期2
            // 
            this.dateEdit单据日期2.EditValue = null;
            this.dateEdit单据日期2.Location = new System.Drawing.Point(209, 80);
            this.dateEdit单据日期2.Name = "dateEdit单据日期2";
            this.dateEdit单据日期2.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.dateEdit单据日期2.Properties.VistaTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
            this.dateEdit单据日期2.Size = new System.Drawing.Size(127, 20);
            this.dateEdit单据日期2.TabIndex = 116;
            // 
            // lookUpEdit单据号1
            // 
            this.lookUpEdit单据号1.AllowHtmlTextInToolTip = DevExpress.Utils.DefaultBoolean.True;
            this.lookUpEdit单据号1.Location = new System.Drawing.Point(82, 56);
            this.lookUpEdit单据号1.Name = "lookUpEdit单据号1";
            this.lookUpEdit单据号1.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.lookUpEdit单据号1.Properties.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("cCode", "单据号")});
            this.lookUpEdit单据号1.Properties.DisplayMember = "cCode";
            this.lookUpEdit单据号1.Properties.NullText = "";
            this.lookUpEdit单据号1.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.Standard;
            this.lookUpEdit单据号1.Properties.ValueMember = "cCode";
            this.lookUpEdit单据号1.Size = new System.Drawing.Size(121, 20);
            this.lookUpEdit单据号1.TabIndex = 119;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(29, 61);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(41, 12);
            this.label3.TabIndex = 117;
            this.label3.Text = "单据号";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lookUpEdit单据号2
            // 
            this.lookUpEdit单据号2.Location = new System.Drawing.Point(209, 56);
            this.lookUpEdit单据号2.Name = "lookUpEdit单据号2";
            this.lookUpEdit单据号2.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.lookUpEdit单据号2.Properties.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("cCode", "单据号")});
            this.lookUpEdit单据号2.Properties.DisplayMember = "cCode";
            this.lookUpEdit单据号2.Properties.NullText = "";
            this.lookUpEdit单据号2.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.Standard;
            this.lookUpEdit单据号2.Properties.ValueMember = "cCode";
            this.lookUpEdit单据号2.Size = new System.Drawing.Size(126, 20);
            this.lookUpEdit单据号2.TabIndex = 119;
            // 
            // btnExcel
            // 
            this.btnExcel.Image = ((System.Drawing.Image)(resources.GetObject("btnExcel.Image")));
            this.btnExcel.ImageLocation = DevExpress.XtraEditors.ImageLocation.TopCenter;
            this.btnExcel.Location = new System.Drawing.Point(477, 59);
            this.btnExcel.Name = "btnExcel";
            this.btnExcel.Size = new System.Drawing.Size(46, 41);
            this.btnExcel.TabIndex = 123;
            this.btnExcel.Text = "导出";
            this.btnExcel.Click += new System.EventHandler(this.btnExcel_Click);
            // 
            // btnPrint
            // 
            this.btnPrint.Image = ((System.Drawing.Image)(resources.GetObject("btnPrint.Image")));
            this.btnPrint.ImageLocation = DevExpress.XtraEditors.ImageLocation.TopCenter;
            this.btnPrint.Location = new System.Drawing.Point(538, 59);
            this.btnPrint.Name = "btnPrint";
            this.btnPrint.Size = new System.Drawing.Size(46, 41);
            this.btnPrint.TabIndex = 126;
            this.btnPrint.Text = "打印";
            this.btnPrint.Click += new System.EventHandler(this.tsbPrint_Click);
            // 
            // radio未完成
            // 
            this.radio未完成.AutoSize = true;
            this.radio未完成.Checked = true;
            this.radio未完成.Location = new System.Drawing.Point(217, 135);
            this.radio未完成.Name = "radio未完成";
            this.radio未完成.Size = new System.Drawing.Size(59, 16);
            this.radio未完成.TabIndex = 132;
            this.radio未完成.TabStop = true;
            this.radio未完成.Text = "未完成";
            this.radio未完成.UseVisualStyleBackColor = true;
            // 
            // radio全部
            // 
            this.radio全部.AutoSize = true;
            this.radio全部.Location = new System.Drawing.Point(288, 135);
            this.radio全部.Name = "radio全部";
            this.radio全部.Size = new System.Drawing.Size(47, 16);
            this.radio全部.TabIndex = 132;
            this.radio全部.Text = "全部";
            this.radio全部.UseVisualStyleBackColor = true;
            // 
            // tsbClearCon
            // 
            this.tsbClearCon.Image = ((System.Drawing.Image)(resources.GetObject("tsbClearCon.Image")));
            this.tsbClearCon.ImageLocation = DevExpress.XtraEditors.ImageLocation.TopCenter;
            this.tsbClearCon.Location = new System.Drawing.Point(360, 59);
            this.tsbClearCon.Name = "tsbClearCon";
            this.tsbClearCon.Size = new System.Drawing.Size(46, 41);
            this.tsbClearCon.TabIndex = 133;
            this.tsbClearCon.Text = "清空";
            this.tsbClearCon.Click += new System.EventHandler(this.tsbClearCon_Click);
            // 
            // btnPrintSet
            // 
            this.btnPrintSet.Image = ((System.Drawing.Image)(resources.GetObject("btnPrintSet.Image")));
            this.btnPrintSet.ImageLocation = DevExpress.XtraEditors.ImageLocation.TopCenter;
            this.btnPrintSet.Location = new System.Drawing.Point(605, 61);
            this.btnPrintSet.Name = "btnPrintSet";
            this.btnPrintSet.Size = new System.Drawing.Size(61, 41);
            this.btnPrintSet.TabIndex = 134;
            this.btnPrintSet.Text = "打印设置";
            this.btnPrintSet.Click += new System.EventHandler(this.btnPrintSet_Click);
            // 
            // chk全选
            // 
            this.chk全选.AutoSize = true;
            this.chk全选.Location = new System.Drawing.Point(31, 168);
            this.chk全选.Name = "chk全选";
            this.chk全选.Size = new System.Drawing.Size(48, 16);
            this.chk全选.TabIndex = 135;
            this.chk全选.Text = "全选";
            this.chk全选.UseVisualStyleBackColor = true;
            this.chk全选.CheckedChanged += new System.EventHandler(this.chk全选_CheckedChanged);
            // 
            // 入库单条形码打印
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.chk全选);
            this.Controls.Add(this.btnPrintSet);
            this.Controls.Add(this.tsbClearCon);
            this.Controls.Add(this.radio全部);
            this.Controls.Add(this.radio未完成);
            this.Controls.Add(this.btnPrint);
            this.Controls.Add(this.btnExcel);
            this.Controls.Add(this.lookUpEdit单据号2);
            this.Controls.Add(this.lookUpEdit单据号1);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.dateEdit单据日期2);
            this.Controls.Add(this.dateEdit单据日期1);
            this.Controls.Add(this.btnRefresh);
            this.Controls.Add(this.gridControl1);
            this.Controls.Add(this.labelControl1);
            this.Name = "入库单条形码打印";
            this.Size = new System.Drawing.Size(890, 401);
            this.Load += new System.EventHandler(this.Frm产成品入库单条形码打印_Load);
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ItemLookUpEdit存货编码)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ItemLookUpEdit存货名称)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ItemLookUpEdit规格型号)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dateEdit单据日期1.Properties.VistaTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dateEdit单据日期1.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dateEdit单据日期2.Properties.VistaTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dateEdit单据日期2.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lookUpEdit单据号1.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lookUpEdit单据号2.Properties)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraEditors.LabelControl labelControl1;
        private DevExpress.XtraGrid.GridControl gridControl1;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView1;
        private DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit ItemLookUpEdit存货编码;
        private DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit ItemLookUpEdit存货名称;
        private DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit ItemLookUpEdit规格型号;
        private DevExpress.XtraEditors.SimpleButton btnRefresh;
        private DevExpress.XtraEditors.DateEdit dateEdit单据日期1;
        private System.Windows.Forms.Label label1;
        private DevExpress.XtraEditors.DateEdit dateEdit单据日期2;
        private DevExpress.XtraEditors.LookUpEdit lookUpEdit单据号1;
        private System.Windows.Forms.Label label3;
        private DevExpress.XtraEditors.LookUpEdit lookUpEdit单据号2;
        private DevExpress.XtraEditors.SimpleButton btnExcel;
        private DevExpress.XtraEditors.SimpleButton btnPrint;
        private System.Windows.Forms.RadioButton radio未完成;
        private System.Windows.Forms.RadioButton radio全部;
        private DevExpress.XtraEditors.SimpleButton tsbClearCon;
        private DevExpress.XtraEditors.SimpleButton btnPrintSet;
        private System.Windows.Forms.CheckBox chk全选;

    }
}
