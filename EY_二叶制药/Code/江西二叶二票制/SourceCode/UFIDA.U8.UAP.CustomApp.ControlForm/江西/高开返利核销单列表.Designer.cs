namespace UFIDA.U8.UAP.CustomApp.ControlForm
{
    partial class 高开返利核销单列表
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
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.btnSEL = new System.Windows.Forms.ToolStripMenuItem();
            this.btnExcel = new System.Windows.Forms.ToolStripMenuItem();
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            this.gridControl1 = new DevExpress.XtraGrid.GridControl();
            this.gridView1 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.gridCol单据号 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColdtmDate = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridCol业务员编码 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridCol业务员姓名 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridCol返利单号 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridCol发票号 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridCol核销金额 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColFLD_iIDs = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColFP_IDs = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColColumns = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColcCusName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColcreateUid = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColdtmCreate = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColRemark = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridCol代理商编码 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridCol代理商 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.panel1 = new System.Windows.Forms.Panel();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.dtm2 = new DevExpress.XtraEditors.DateEdit();
            this.dtm1 = new DevExpress.XtraEditors.DateEdit();
            this.label2 = new System.Windows.Forms.Label();
            this.lookUpEditcCode = new DevExpress.XtraEditors.LookUpEdit();
            this.label1 = new System.Windows.Forms.Label();
            this.lookUpEditcCusName = new DevExpress.XtraEditors.LookUpEdit();
            this.label6 = new System.Windows.Forms.Label();
            this.lookUpEditcCusCode = new DevExpress.XtraEditors.LookUpEdit();
            this.menuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).BeginInit();
            this.panel1.SuspendLayout();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dtm2.Properties.VistaTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtm2.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtm1.Properties.VistaTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtm1.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lookUpEditcCode.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lookUpEditcCusName.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lookUpEditcCusCode.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btnSEL,
            this.btnExcel});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(903, 25);
            this.menuStrip1.TabIndex = 172;
            this.menuStrip1.Text = "menuStrip";
            // 
            // btnSEL
            // 
            this.btnSEL.Name = "btnSEL";
            this.btnSEL.Size = new System.Drawing.Size(44, 21);
            this.btnSEL.Text = "查询";
            this.btnSEL.Click += new System.EventHandler(this.btnSEL_Click);
            // 
            // btnExcel
            // 
            this.btnExcel.Name = "btnExcel";
            this.btnExcel.Size = new System.Drawing.Size(44, 21);
            this.btnExcel.Text = "导出";
            this.btnExcel.Click += new System.EventHandler(this.btnExcel_Click);
            // 
            // labelControl1
            // 
            this.labelControl1.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.labelControl1.Appearance.Font = new System.Drawing.Font("Tahoma", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelControl1.Location = new System.Drawing.Point(327, 0);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(273, 25);
            this.labelControl1.TabIndex = 190;
            this.labelControl1.Text = "高开返利核销单列表（江西）";
            // 
            // gridControl1
            // 
            this.gridControl1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.gridControl1.Location = new System.Drawing.Point(6, 117);
            this.gridControl1.LookAndFeel.SkinName = "Office 2010 Blue";
            this.gridControl1.MainView = this.gridView1;
            this.gridControl1.Name = "gridControl1";
            this.gridControl1.Size = new System.Drawing.Size(897, 275);
            this.gridControl1.TabIndex = 191;
            this.gridControl1.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView1});
            // 
            // gridView1
            // 
            this.gridView1.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.gridCol单据号,
            this.gridColdtmDate,
            this.gridCol业务员编码,
            this.gridCol业务员姓名,
            this.gridCol返利单号,
            this.gridCol发票号,
            this.gridCol核销金额,
            this.gridColFLD_iIDs,
            this.gridColFP_IDs,
            this.gridColColumns,
            this.gridColcCusName,
            this.gridColcreateUid,
            this.gridColdtmCreate,
            this.gridColRemark,
            this.gridCol代理商编码,
            this.gridCol代理商});
            this.gridView1.GridControl = this.gridControl1;
            this.gridView1.IndicatorWidth = 40;
            this.gridView1.Name = "gridView1";
            this.gridView1.OptionsBehavior.AllowDeleteRows = DevExpress.Utils.DefaultBoolean.True;
            this.gridView1.OptionsBehavior.Editable = false;
            this.gridView1.OptionsBehavior.EditorShowMode = DevExpress.Utils.EditorShowMode.MouseDown;
            this.gridView1.OptionsCustomization.AllowGroup = false;
            this.gridView1.OptionsCustomization.AllowQuickHideColumns = false;
            this.gridView1.OptionsNavigation.EnterMoveNextColumn = true;
            this.gridView1.OptionsView.AllowCellMerge = true;
            this.gridView1.OptionsView.ColumnAutoWidth = false;
            this.gridView1.OptionsView.ShowFooter = true;
            this.gridView1.OptionsView.ShowGroupPanel = false;
            this.gridView1.CustomDrawRowIndicator += new DevExpress.XtraGrid.Views.Grid.RowIndicatorCustomDrawEventHandler(this.gridView1_CustomDrawRowIndicator);
            this.gridView1.DoubleClick += new System.EventHandler(this.gridView1_DoubleClick);
            // 
            // gridCol单据号
            // 
            this.gridCol单据号.Caption = "核销单号";
            this.gridCol单据号.FieldName = "cCode";
            this.gridCol单据号.Name = "gridCol单据号";
            this.gridCol单据号.OptionsColumn.AllowEdit = false;
            this.gridCol单据号.OptionsColumn.AllowMerge = DevExpress.Utils.DefaultBoolean.True;
            this.gridCol单据号.Visible = true;
            this.gridCol单据号.VisibleIndex = 2;
            this.gridCol单据号.Width = 116;
            // 
            // gridColdtmDate
            // 
            this.gridColdtmDate.Caption = "核销日期";
            this.gridColdtmDate.FieldName = "dtmDate";
            this.gridColdtmDate.Name = "gridColdtmDate";
            this.gridColdtmDate.OptionsColumn.AllowEdit = false;
            this.gridColdtmDate.OptionsColumn.AllowMerge = DevExpress.Utils.DefaultBoolean.False;
            this.gridColdtmDate.Visible = true;
            this.gridColdtmDate.VisibleIndex = 5;
            // 
            // gridCol业务员编码
            // 
            this.gridCol业务员编码.Caption = "业务员编码";
            this.gridCol业务员编码.FieldName = "cPersonCode";
            this.gridCol业务员编码.Name = "gridCol业务员编码";
            this.gridCol业务员编码.OptionsColumn.AllowEdit = false;
            this.gridCol业务员编码.OptionsColumn.AllowMerge = DevExpress.Utils.DefaultBoolean.False;
            this.gridCol业务员编码.Visible = true;
            this.gridCol业务员编码.VisibleIndex = 6;
            // 
            // gridCol业务员姓名
            // 
            this.gridCol业务员姓名.Caption = "业务员姓名";
            this.gridCol业务员姓名.FieldName = "cPersonName";
            this.gridCol业务员姓名.Name = "gridCol业务员姓名";
            this.gridCol业务员姓名.OptionsColumn.AllowEdit = false;
            this.gridCol业务员姓名.OptionsColumn.AllowMerge = DevExpress.Utils.DefaultBoolean.False;
            this.gridCol业务员姓名.Visible = true;
            this.gridCol业务员姓名.VisibleIndex = 7;
            // 
            // gridCol返利单号
            // 
            this.gridCol返利单号.Caption = "返利单号";
            this.gridCol返利单号.FieldName = "FLD_cCode";
            this.gridCol返利单号.Name = "gridCol返利单号";
            this.gridCol返利单号.OptionsColumn.AllowEdit = false;
            this.gridCol返利单号.OptionsColumn.AllowMerge = DevExpress.Utils.DefaultBoolean.False;
            this.gridCol返利单号.Visible = true;
            this.gridCol返利单号.VisibleIndex = 8;
            // 
            // gridCol发票号
            // 
            this.gridCol发票号.Caption = "发票号";
            this.gridCol发票号.FieldName = "FP_Code";
            this.gridCol发票号.Name = "gridCol发票号";
            this.gridCol发票号.OptionsColumn.AllowEdit = false;
            this.gridCol发票号.OptionsColumn.AllowMerge = DevExpress.Utils.DefaultBoolean.False;
            this.gridCol发票号.Visible = true;
            this.gridCol发票号.VisibleIndex = 9;
            // 
            // gridCol核销金额
            // 
            this.gridCol核销金额.Caption = "核销金额";
            this.gridCol核销金额.FieldName = "dMoney";
            this.gridCol核销金额.Name = "gridCol核销金额";
            this.gridCol核销金额.OptionsColumn.AllowEdit = false;
            this.gridCol核销金额.OptionsColumn.AllowMerge = DevExpress.Utils.DefaultBoolean.False;
            this.gridCol核销金额.Summary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] {
            new DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum)});
            this.gridCol核销金额.Visible = true;
            this.gridCol核销金额.VisibleIndex = 10;
            // 
            // gridColFLD_iIDs
            // 
            this.gridColFLD_iIDs.Caption = "FLD_iIDs";
            this.gridColFLD_iIDs.FieldName = "FLD_iIDs";
            this.gridColFLD_iIDs.Name = "gridColFLD_iIDs";
            this.gridColFLD_iIDs.OptionsColumn.AllowEdit = false;
            this.gridColFLD_iIDs.OptionsColumn.AllowMerge = DevExpress.Utils.DefaultBoolean.False;
            // 
            // gridColFP_IDs
            // 
            this.gridColFP_IDs.Caption = "FP_IDs";
            this.gridColFP_IDs.FieldName = "FP_IDs";
            this.gridColFP_IDs.Name = "gridColFP_IDs";
            this.gridColFP_IDs.OptionsColumn.AllowEdit = false;
            this.gridColFP_IDs.OptionsColumn.AllowMerge = DevExpress.Utils.DefaultBoolean.False;
            // 
            // gridColColumns
            // 
            this.gridColColumns.Caption = "客户编码";
            this.gridColColumns.FieldName = "cCusCode";
            this.gridColColumns.Name = "gridColColumns";
            this.gridColColumns.OptionsColumn.AllowEdit = false;
            this.gridColColumns.OptionsColumn.AllowMerge = DevExpress.Utils.DefaultBoolean.False;
            this.gridColColumns.Visible = true;
            this.gridColColumns.VisibleIndex = 3;
            this.gridColColumns.Width = 99;
            // 
            // gridColcCusName
            // 
            this.gridColcCusName.Caption = "客户";
            this.gridColcCusName.FieldName = "cCusName";
            this.gridColcCusName.Name = "gridColcCusName";
            this.gridColcCusName.OptionsColumn.AllowEdit = false;
            this.gridColcCusName.OptionsColumn.AllowMerge = DevExpress.Utils.DefaultBoolean.False;
            this.gridColcCusName.Visible = true;
            this.gridColcCusName.VisibleIndex = 4;
            this.gridColcCusName.Width = 208;
            // 
            // gridColcreateUid
            // 
            this.gridColcreateUid.Caption = "制单人";
            this.gridColcreateUid.FieldName = "createUid";
            this.gridColcreateUid.Name = "gridColcreateUid";
            this.gridColcreateUid.OptionsColumn.AllowEdit = false;
            this.gridColcreateUid.OptionsColumn.AllowMerge = DevExpress.Utils.DefaultBoolean.False;
            this.gridColcreateUid.Visible = true;
            this.gridColcreateUid.VisibleIndex = 12;
            // 
            // gridColdtmCreate
            // 
            this.gridColdtmCreate.Caption = "制单时间";
            this.gridColdtmCreate.FieldName = "dtmCreate";
            this.gridColdtmCreate.Name = "gridColdtmCreate";
            this.gridColdtmCreate.OptionsColumn.AllowEdit = false;
            this.gridColdtmCreate.OptionsColumn.AllowMerge = DevExpress.Utils.DefaultBoolean.False;
            this.gridColdtmCreate.Visible = true;
            this.gridColdtmCreate.VisibleIndex = 13;
            // 
            // gridColRemark
            // 
            this.gridColRemark.Caption = "备注";
            this.gridColRemark.FieldName = "Remark";
            this.gridColRemark.Name = "gridColRemark";
            this.gridColRemark.OptionsColumn.AllowEdit = false;
            this.gridColRemark.OptionsColumn.AllowMerge = DevExpress.Utils.DefaultBoolean.False;
            this.gridColRemark.Visible = true;
            this.gridColRemark.VisibleIndex = 11;
            // 
            // gridCol代理商编码
            // 
            this.gridCol代理商编码.Caption = "代理商编码";
            this.gridCol代理商编码.FieldName = "DLS";
            this.gridCol代理商编码.Name = "gridCol代理商编码";
            this.gridCol代理商编码.OptionsColumn.AllowEdit = false;
            this.gridCol代理商编码.Visible = true;
            this.gridCol代理商编码.VisibleIndex = 0;
            // 
            // gridCol代理商
            // 
            this.gridCol代理商.Caption = "代理商";
            this.gridCol代理商.FieldName = "代理商";
            this.gridCol代理商.Name = "gridCol代理商";
            this.gridCol代理商.OptionsColumn.AllowEdit = false;
            this.gridCol代理商.Visible = true;
            this.gridCol代理商.VisibleIndex = 1;
            this.gridCol代理商.Width = 138;
            // 
            // panel1
            // 
            this.panel1.AutoScroll = true;
            this.panel1.Controls.Add(this.groupBox1);
            this.panel1.Controls.Add(this.gridControl1);
            this.panel1.Controls.Add(this.labelControl1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 25);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(903, 392);
            this.panel1.TabIndex = 173;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.dtm2);
            this.groupBox1.Controls.Add(this.dtm1);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.lookUpEditcCode);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.lookUpEditcCusName);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.lookUpEditcCusCode);
            this.groupBox1.Location = new System.Drawing.Point(6, 34);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(536, 69);
            this.groupBox1.TabIndex = 247;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "过滤条件";
            // 
            // dtm2
            // 
            this.dtm2.EditValue = null;
            this.dtm2.Location = new System.Drawing.Point(401, 18);
            this.dtm2.Name = "dtm2";
            this.dtm2.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.dtm2.Properties.VistaTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
            this.dtm2.Size = new System.Drawing.Size(121, 20);
            this.dtm2.TabIndex = 252;
            // 
            // dtm1
            // 
            this.dtm1.EditValue = null;
            this.dtm1.Location = new System.Drawing.Point(273, 18);
            this.dtm1.Name = "dtm1";
            this.dtm1.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.dtm1.Properties.VistaTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
            this.dtm1.Size = new System.Drawing.Size(122, 20);
            this.dtm1.TabIndex = 251;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(220, 22);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(53, 12);
            this.label2.TabIndex = 250;
            this.label2.Text = "单据日期";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lookUpEditcCode
            // 
            this.lookUpEditcCode.AllowHtmlTextInToolTip = DevExpress.Utils.DefaultBoolean.True;
            this.lookUpEditcCode.Location = new System.Drawing.Point(78, 18);
            this.lookUpEditcCode.Name = "lookUpEditcCode";
            this.lookUpEditcCode.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.lookUpEditcCode.Properties.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("cCode", 60, "单据号")});
            this.lookUpEditcCode.Properties.DisplayMember = "cCode";
            this.lookUpEditcCode.Properties.NullText = "";
            this.lookUpEditcCode.Properties.PopupWidth = 400;
            this.lookUpEditcCode.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.Standard;
            this.lookUpEditcCode.Properties.ValueMember = "cCode";
            this.lookUpEditcCode.Size = new System.Drawing.Size(121, 20);
            this.lookUpEditcCode.TabIndex = 249;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(19, 22);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(41, 12);
            this.label1.TabIndex = 248;
            this.label1.Text = "单据号";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lookUpEditcCusName
            // 
            this.lookUpEditcCusName.AllowHtmlTextInToolTip = DevExpress.Utils.DefaultBoolean.True;
            this.lookUpEditcCusName.Location = new System.Drawing.Point(205, 43);
            this.lookUpEditcCusName.Name = "lookUpEditcCusName";
            this.lookUpEditcCusName.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.lookUpEditcCusName.Properties.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("cCusCode", "客户编号"),
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("cCusName", 60, "客户名称")});
            this.lookUpEditcCusName.Properties.DisplayMember = "cCusName";
            this.lookUpEditcCusName.Properties.NullText = "";
            this.lookUpEditcCusName.Properties.PopupWidth = 400;
            this.lookUpEditcCusName.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.Standard;
            this.lookUpEditcCusName.Properties.ValueMember = "cCusCode";
            this.lookUpEditcCusName.Size = new System.Drawing.Size(317, 20);
            this.lookUpEditcCusName.TabIndex = 247;
            this.lookUpEditcCusName.EditValueChanged += new System.EventHandler(this.lookUpEditcCusName_EditValueChanged);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(19, 47);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(41, 12);
            this.label6.TabIndex = 245;
            this.label6.Text = "代理商";
            this.label6.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lookUpEditcCusCode
            // 
            this.lookUpEditcCusCode.AllowHtmlTextInToolTip = DevExpress.Utils.DefaultBoolean.True;
            this.lookUpEditcCusCode.Location = new System.Drawing.Point(78, 43);
            this.lookUpEditcCusCode.Name = "lookUpEditcCusCode";
            this.lookUpEditcCusCode.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.lookUpEditcCusCode.Properties.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("cCusCode", "客户编号"),
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("cCusName", 60, "客户名称")});
            this.lookUpEditcCusCode.Properties.DisplayMember = "cCusCode";
            this.lookUpEditcCusCode.Properties.NullText = "";
            this.lookUpEditcCusCode.Properties.PopupWidth = 400;
            this.lookUpEditcCusCode.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.Standard;
            this.lookUpEditcCusCode.Properties.ValueMember = "cCusCode";
            this.lookUpEditcCusCode.Size = new System.Drawing.Size(121, 20);
            this.lookUpEditcCusCode.TabIndex = 246;
            this.lookUpEditcCusCode.EditValueChanged += new System.EventHandler(this.lookUpEditcCusCode_EditValueChanged);
            // 
            // 高开返利核销单列表
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.menuStrip1);
            this.Name = "高开返利核销单列表";
            this.Size = new System.Drawing.Size(903, 417);
            this.Load += new System.EventHandler(this.Frm_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dtm2.Properties.VistaTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtm2.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtm1.Properties.VistaTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtm1.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lookUpEditcCode.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lookUpEditcCusName.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lookUpEditcCusCode.Properties)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private DevExpress.XtraEditors.LabelControl labelControl1;
        private DevExpress.XtraGrid.GridControl gridControl1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.ToolStripMenuItem btnExcel;
        private System.Windows.Forms.GroupBox groupBox1;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView1;
        private DevExpress.XtraGrid.Columns.GridColumn gridCol返利单号;
        private DevExpress.XtraGrid.Columns.GridColumn gridCol发票号;
        private DevExpress.XtraEditors.LookUpEdit lookUpEditcCusName;
        private System.Windows.Forms.Label label6;
        private DevExpress.XtraEditors.LookUpEdit lookUpEditcCusCode;
        private DevExpress.XtraGrid.Columns.GridColumn gridCol单据号;
        private DevExpress.XtraGrid.Columns.GridColumn gridCol业务员编码;
        private DevExpress.XtraGrid.Columns.GridColumn gridCol业务员姓名;
        private System.Windows.Forms.ToolStripMenuItem btnSEL;
        private System.Windows.Forms.Label label2;
        private DevExpress.XtraEditors.LookUpEdit lookUpEditcCode;
        private System.Windows.Forms.Label label1;
        private DevExpress.XtraEditors.DateEdit dtm2;
        private DevExpress.XtraEditors.DateEdit dtm1;
        private DevExpress.XtraGrid.Columns.GridColumn gridCol核销金额;
        private DevExpress.XtraGrid.Columns.GridColumn gridColFLD_iIDs;
        private DevExpress.XtraGrid.Columns.GridColumn gridColFP_IDs;
        private DevExpress.XtraGrid.Columns.GridColumn gridColdtmDate;
        private DevExpress.XtraGrid.Columns.GridColumn gridColColumns;
        private DevExpress.XtraGrid.Columns.GridColumn gridColcCusName;
        private DevExpress.XtraGrid.Columns.GridColumn gridColcreateUid;
        private DevExpress.XtraGrid.Columns.GridColumn gridColdtmCreate;
        private DevExpress.XtraGrid.Columns.GridColumn gridColRemark;
        private DevExpress.XtraGrid.Columns.GridColumn gridCol代理商编码;
        private DevExpress.XtraGrid.Columns.GridColumn gridCol代理商;
    }
}
