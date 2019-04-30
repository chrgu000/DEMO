namespace UFIDA.U8.UAP.CustomApp.ControlForm
{
    partial class 货位条形码打印
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(货位条形码打印));
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            this.gridControl1 = new DevExpress.XtraGrid.GridControl();
            this.gridView1 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.ItemLookUpEdit货位编码 = new DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit();
            this.ItemLookUpEdit货位名称 = new DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit();
            this.ItemLookUpEdit规格型号 = new DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit();
            this.btnRefresh = new DevExpress.XtraEditors.SimpleButton();
            this.btnExcel = new DevExpress.XtraEditors.SimpleButton();
            this.label5 = new System.Windows.Forms.Label();
            this.btnPrint = new DevExpress.XtraEditors.SimpleButton();
            this.textEdit货位 = new DevExpress.XtraEditors.TextEdit();
            this.tsbClearCon = new DevExpress.XtraEditors.SimpleButton();
            this.btnPrintSet = new DevExpress.XtraEditors.SimpleButton();
            this.chk全选 = new System.Windows.Forms.CheckBox();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ItemLookUpEdit货位编码)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ItemLookUpEdit货位名称)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ItemLookUpEdit规格型号)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.textEdit货位.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // labelControl1
            // 
            this.labelControl1.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.labelControl1.Appearance.Font = new System.Drawing.Font("Tahoma", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelControl1.Location = new System.Drawing.Point(376, 14);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(147, 25);
            this.labelControl1.TabIndex = 109;
            this.labelControl1.Text = "货位条形码打印";
            // 
            // gridControl1
            // 
            this.gridControl1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.gridControl1.Location = new System.Drawing.Point(7, 157);
            this.gridControl1.LookAndFeel.SkinName = "Office 2010 Blue";
            this.gridControl1.MainView = this.gridView1;
            this.gridControl1.Name = "gridControl1";
            this.gridControl1.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.ItemLookUpEdit货位编码,
            this.ItemLookUpEdit货位名称,
            this.ItemLookUpEdit规格型号});
            this.gridControl1.Size = new System.Drawing.Size(881, 240);
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
            // ItemLookUpEdit货位编码
            // 
            this.ItemLookUpEdit货位编码.AutoHeight = false;
            this.ItemLookUpEdit货位编码.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.ItemLookUpEdit货位编码.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("cInvCode", "货位编码"),
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("cInvName", "货位名称"),
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("cInvStd", "规格型号")});
            this.ItemLookUpEdit货位编码.DisplayMember = "cInvCode";
            this.ItemLookUpEdit货位编码.Name = "ItemLookUpEdit货位编码";
            this.ItemLookUpEdit货位编码.NullText = "";
            this.ItemLookUpEdit货位编码.PopupWidth = 600;
            this.ItemLookUpEdit货位编码.ValueMember = "cInvCode";
            // 
            // ItemLookUpEdit货位名称
            // 
            this.ItemLookUpEdit货位名称.AutoHeight = false;
            this.ItemLookUpEdit货位名称.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.ItemLookUpEdit货位名称.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("cInvCode", "货位编码"),
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("cInvName", "货位名称"),
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("cInvStd", "规格型号")});
            this.ItemLookUpEdit货位名称.DisplayMember = "cInvName";
            this.ItemLookUpEdit货位名称.Name = "ItemLookUpEdit货位名称";
            this.ItemLookUpEdit货位名称.NullText = "";
            this.ItemLookUpEdit货位名称.ValueMember = "cInvCode";
            // 
            // ItemLookUpEdit规格型号
            // 
            this.ItemLookUpEdit规格型号.AutoHeight = false;
            this.ItemLookUpEdit规格型号.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.ItemLookUpEdit规格型号.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("cInvCode", "货位编码"),
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("cInvName", "货位名称"),
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
            this.btnRefresh.Location = new System.Drawing.Point(317, 58);
            this.btnRefresh.Name = "btnRefresh";
            this.btnRefresh.Size = new System.Drawing.Size(46, 41);
            this.btnRefresh.TabIndex = 115;
            this.btnRefresh.Text = "过滤";
            this.btnRefresh.Click += new System.EventHandler(this.btnRefresh_Click);
            // 
            // btnExcel
            // 
            this.btnExcel.Image = ((System.Drawing.Image)(resources.GetObject("btnExcel.Image")));
            this.btnExcel.ImageLocation = DevExpress.XtraEditors.ImageLocation.TopCenter;
            this.btnExcel.Location = new System.Drawing.Point(373, 58);
            this.btnExcel.Name = "btnExcel";
            this.btnExcel.Size = new System.Drawing.Size(46, 41);
            this.btnExcel.TabIndex = 123;
            this.btnExcel.Text = "导出";
            this.btnExcel.Click += new System.EventHandler(this.btnExcel_Click);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(64, 61);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(29, 12);
            this.label5.TabIndex = 125;
            this.label5.Text = "货位";
            this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // btnPrint
            // 
            this.btnPrint.Image = ((System.Drawing.Image)(resources.GetObject("btnPrint.Image")));
            this.btnPrint.ImageLocation = DevExpress.XtraEditors.ImageLocation.TopCenter;
            this.btnPrint.Location = new System.Drawing.Point(434, 58);
            this.btnPrint.Name = "btnPrint";
            this.btnPrint.Size = new System.Drawing.Size(46, 41);
            this.btnPrint.TabIndex = 126;
            this.btnPrint.Text = "打印";
            this.btnPrint.Click += new System.EventHandler(this.tsbPrint_Click);
            // 
            // textEdit货位
            // 
            this.textEdit货位.Location = new System.Drawing.Point(111, 56);
            this.textEdit货位.Name = "textEdit货位";
            this.textEdit货位.Size = new System.Drawing.Size(121, 20);
            this.textEdit货位.TabIndex = 127;
            // 
            // tsbClearCon
            // 
            this.tsbClearCon.Image = ((System.Drawing.Image)(resources.GetObject("tsbClearCon.Image")));
            this.tsbClearCon.ImageLocation = DevExpress.XtraEditors.ImageLocation.TopCenter;
            this.tsbClearCon.Location = new System.Drawing.Point(256, 58);
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
            this.btnPrintSet.Location = new System.Drawing.Point(501, 60);
            this.btnPrintSet.Name = "btnPrintSet";
            this.btnPrintSet.Size = new System.Drawing.Size(61, 41);
            this.btnPrintSet.TabIndex = 134;
            this.btnPrintSet.Text = "打印设置";
            this.btnPrintSet.Click += new System.EventHandler(this.btnPrintSet_Click);
            // 
            // chk全选
            // 
            this.chk全选.AutoSize = true;
            this.chk全选.Location = new System.Drawing.Point(16, 135);
            this.chk全选.Name = "chk全选";
            this.chk全选.Size = new System.Drawing.Size(48, 16);
            this.chk全选.TabIndex = 135;
            this.chk全选.Text = "全选";
            this.chk全选.UseVisualStyleBackColor = true;
            this.chk全选.CheckedChanged += new System.EventHandler(this.chk全选_CheckedChanged);
            // 
            // 货位条形码打印
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.chk全选);
            this.Controls.Add(this.btnPrintSet);
            this.Controls.Add(this.tsbClearCon);
            this.Controls.Add(this.textEdit货位);
            this.Controls.Add(this.btnPrint);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.btnExcel);
            this.Controls.Add(this.btnRefresh);
            this.Controls.Add(this.gridControl1);
            this.Controls.Add(this.labelControl1);
            this.Name = "货位条形码打印";
            this.Size = new System.Drawing.Size(890, 401);
            this.Load += new System.EventHandler(this.ProjectManager_Load);
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ItemLookUpEdit货位编码)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ItemLookUpEdit货位名称)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ItemLookUpEdit规格型号)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.textEdit货位.Properties)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraEditors.LabelControl labelControl1;
        private DevExpress.XtraGrid.GridControl gridControl1;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView1;
        private DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit ItemLookUpEdit货位编码;
        private DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit ItemLookUpEdit货位名称;
        private DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit ItemLookUpEdit规格型号;
        private DevExpress.XtraEditors.SimpleButton btnRefresh;
        private DevExpress.XtraEditors.SimpleButton btnExcel;
        private System.Windows.Forms.Label label5;
        private DevExpress.XtraEditors.SimpleButton btnPrint;
        private DevExpress.XtraEditors.TextEdit textEdit货位;
        private DevExpress.XtraEditors.SimpleButton tsbClearCon;
        private DevExpress.XtraEditors.SimpleButton btnPrintSet;
        private System.Windows.Forms.CheckBox chk全选;

    }
}
