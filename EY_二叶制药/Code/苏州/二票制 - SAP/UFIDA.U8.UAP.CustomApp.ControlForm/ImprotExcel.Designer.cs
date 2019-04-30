namespace UFIDA.U8.UAP.CustomApp.ControlForm
{
    partial class ImprotExcel
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
            this.btnImport = new System.Windows.Forms.ToolStripMenuItem();
            this.btnSave = new System.Windows.Forms.ToolStripMenuItem();
            this.gridControl回款 = new DevExpress.XtraGrid.GridControl();
            this.gridView回款 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.gridCol_收款单号 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridCol_收款单日期 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridCol_收款单金额 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridCol_业务员编码 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridCol_业务员 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridCol_核销金额 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridCol_核销日期 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridCol_发票号码 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridCol_发票日期 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridCol_销售组织 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridCol_客户编码 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridCol_客户名称 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridCol_发票金额 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridCol_货币单位 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.panel1 = new System.Windows.Forms.Panel();
            this.gridControl发票 = new DevExpress.XtraGrid.GridControl();
            this.gridView发票 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.gridCol销售组织 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridCol发票号码 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridCol发票类型 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridCol发票类型名称 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridCol发票日期 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridCol客户编码 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridCol客户名称 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridCol代码商编码 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridCol代理商名称 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridCol业务员编码 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridCol业务员名称 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridCol省份编码 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridCol省份名称 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridCol城市编码 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridCol发货单号 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridCol发货行号 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridCol货物编码 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridCol货物名称 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridCol规格型号 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridCol批次 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridCol单价 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridCol开票数量 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridCol金额 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridCol货币单位 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.radio回款 = new System.Windows.Forms.RadioButton();
            this.radio发票 = new System.Windows.Forms.RadioButton();
            this.menuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl回款)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView回款)).BeginInit();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl发票)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView发票)).BeginInit();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btnImport,
            this.btnSave});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(1073, 25);
            this.menuStrip1.TabIndex = 172;
            this.menuStrip1.Text = "menuStrip";
            // 
            // btnImport
            // 
            this.btnImport.Name = "btnImport";
            this.btnImport.Size = new System.Drawing.Size(44, 21);
            this.btnImport.Text = "加载";
            this.btnImport.Click += new System.EventHandler(this.btnImport_Click);
            // 
            // btnSave
            // 
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(44, 21);
            this.btnSave.Text = "保存";
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // gridControl回款
            // 
            this.gridControl回款.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.gridControl回款.Location = new System.Drawing.Point(6, 62);
            this.gridControl回款.LookAndFeel.SkinName = "Office 2010 Blue";
            this.gridControl回款.MainView = this.gridView回款;
            this.gridControl回款.Name = "gridControl回款";
            this.gridControl回款.Size = new System.Drawing.Size(1067, 360);
            this.gridControl回款.TabIndex = 191;
            this.gridControl回款.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView回款});
            this.gridControl回款.Visible = false;
            // 
            // gridView回款
            // 
            this.gridView回款.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.gridCol_收款单号,
            this.gridCol_收款单日期,
            this.gridCol_收款单金额,
            this.gridCol_业务员编码,
            this.gridCol_业务员,
            this.gridCol_核销金额,
            this.gridCol_核销日期,
            this.gridCol_发票号码,
            this.gridCol_发票日期,
            this.gridCol_销售组织,
            this.gridCol_客户编码,
            this.gridCol_客户名称,
            this.gridCol_发票金额,
            this.gridCol_货币单位});
            this.gridView回款.GridControl = this.gridControl回款;
            this.gridView回款.IndicatorWidth = 40;
            this.gridView回款.Name = "gridView回款";
            this.gridView回款.OptionsBehavior.AllowDeleteRows = DevExpress.Utils.DefaultBoolean.True;
            this.gridView回款.OptionsBehavior.EditorShowMode = DevExpress.Utils.EditorShowMode.MouseDown;
            this.gridView回款.OptionsCustomization.AllowGroup = false;
            this.gridView回款.OptionsCustomization.AllowQuickHideColumns = false;
            this.gridView回款.OptionsNavigation.EnterMoveNextColumn = true;
            this.gridView回款.OptionsView.ColumnAutoWidth = false;
            this.gridView回款.OptionsView.ShowFooter = true;
            this.gridView回款.OptionsView.ShowGroupPanel = false;
            this.gridView回款.CustomDrawRowIndicator += new DevExpress.XtraGrid.Views.Grid.RowIndicatorCustomDrawEventHandler(this.gridView1_CustomDrawRowIndicator);
            // 
            // gridCol_收款单号
            // 
            this.gridCol_收款单号.Caption = "收款单号";
            this.gridCol_收款单号.FieldName = "收款单号";
            this.gridCol_收款单号.Name = "gridCol_收款单号";
            this.gridCol_收款单号.OptionsColumn.AllowEdit = false;
            this.gridCol_收款单号.Visible = true;
            this.gridCol_收款单号.VisibleIndex = 0;
            // 
            // gridCol_收款单日期
            // 
            this.gridCol_收款单日期.Caption = "收款单日期";
            this.gridCol_收款单日期.FieldName = "收款单日期";
            this.gridCol_收款单日期.Name = "gridCol_收款单日期";
            this.gridCol_收款单日期.OptionsColumn.AllowEdit = false;
            this.gridCol_收款单日期.Visible = true;
            this.gridCol_收款单日期.VisibleIndex = 1;
            // 
            // gridCol_收款单金额
            // 
            this.gridCol_收款单金额.Caption = "收款单金额";
            this.gridCol_收款单金额.FieldName = "收款单金额";
            this.gridCol_收款单金额.Name = "gridCol_收款单金额";
            this.gridCol_收款单金额.OptionsColumn.AllowEdit = false;
            this.gridCol_收款单金额.Visible = true;
            this.gridCol_收款单金额.VisibleIndex = 2;
            // 
            // gridCol_业务员编码
            // 
            this.gridCol_业务员编码.Caption = "业务员编码";
            this.gridCol_业务员编码.FieldName = "业务员编码";
            this.gridCol_业务员编码.Name = "gridCol_业务员编码";
            this.gridCol_业务员编码.OptionsColumn.AllowEdit = false;
            this.gridCol_业务员编码.Visible = true;
            this.gridCol_业务员编码.VisibleIndex = 3;
            // 
            // gridCol_业务员
            // 
            this.gridCol_业务员.Caption = "业务员";
            this.gridCol_业务员.FieldName = "业务员";
            this.gridCol_业务员.Name = "gridCol_业务员";
            this.gridCol_业务员.OptionsColumn.AllowEdit = false;
            this.gridCol_业务员.Visible = true;
            this.gridCol_业务员.VisibleIndex = 4;
            // 
            // gridCol_核销金额
            // 
            this.gridCol_核销金额.Caption = "核销金额";
            this.gridCol_核销金额.FieldName = "核销金额";
            this.gridCol_核销金额.Name = "gridCol_核销金额";
            this.gridCol_核销金额.OptionsColumn.AllowEdit = false;
            this.gridCol_核销金额.Visible = true;
            this.gridCol_核销金额.VisibleIndex = 5;
            // 
            // gridCol_核销日期
            // 
            this.gridCol_核销日期.Caption = "核销日期";
            this.gridCol_核销日期.FieldName = "核销日期";
            this.gridCol_核销日期.Name = "gridCol_核销日期";
            this.gridCol_核销日期.OptionsColumn.AllowEdit = false;
            this.gridCol_核销日期.Visible = true;
            this.gridCol_核销日期.VisibleIndex = 6;
            // 
            // gridCol_发票号码
            // 
            this.gridCol_发票号码.Caption = "发票号码";
            this.gridCol_发票号码.FieldName = "发票号码";
            this.gridCol_发票号码.Name = "gridCol_发票号码";
            this.gridCol_发票号码.OptionsColumn.AllowEdit = false;
            this.gridCol_发票号码.Visible = true;
            this.gridCol_发票号码.VisibleIndex = 7;
            // 
            // gridCol_发票日期
            // 
            this.gridCol_发票日期.Caption = "发票日期";
            this.gridCol_发票日期.FieldName = "发票日期";
            this.gridCol_发票日期.Name = "gridCol_发票日期";
            this.gridCol_发票日期.OptionsColumn.AllowEdit = false;
            this.gridCol_发票日期.Visible = true;
            this.gridCol_发票日期.VisibleIndex = 8;
            // 
            // gridCol_销售组织
            // 
            this.gridCol_销售组织.Caption = "销售组织";
            this.gridCol_销售组织.FieldName = "销售组织";
            this.gridCol_销售组织.Name = "gridCol_销售组织";
            this.gridCol_销售组织.OptionsColumn.AllowEdit = false;
            this.gridCol_销售组织.Visible = true;
            this.gridCol_销售组织.VisibleIndex = 9;
            // 
            // gridCol_客户编码
            // 
            this.gridCol_客户编码.Caption = "客户编码";
            this.gridCol_客户编码.FieldName = "客户编码";
            this.gridCol_客户编码.Name = "gridCol_客户编码";
            this.gridCol_客户编码.OptionsColumn.AllowEdit = false;
            this.gridCol_客户编码.Visible = true;
            this.gridCol_客户编码.VisibleIndex = 10;
            // 
            // gridCol_客户名称
            // 
            this.gridCol_客户名称.Caption = "客户名称";
            this.gridCol_客户名称.FieldName = "客户名称";
            this.gridCol_客户名称.Name = "gridCol_客户名称";
            this.gridCol_客户名称.OptionsColumn.AllowEdit = false;
            this.gridCol_客户名称.Visible = true;
            this.gridCol_客户名称.VisibleIndex = 11;
            // 
            // gridCol_发票金额
            // 
            this.gridCol_发票金额.Caption = "发票金额";
            this.gridCol_发票金额.FieldName = "发票金额";
            this.gridCol_发票金额.Name = "gridCol_发票金额";
            this.gridCol_发票金额.OptionsColumn.AllowEdit = false;
            this.gridCol_发票金额.Visible = true;
            this.gridCol_发票金额.VisibleIndex = 12;
            // 
            // gridCol_货币单位
            // 
            this.gridCol_货币单位.Caption = "货币单位";
            this.gridCol_货币单位.FieldName = "货币单位";
            this.gridCol_货币单位.Name = "gridCol_货币单位";
            this.gridCol_货币单位.OptionsColumn.AllowEdit = false;
            this.gridCol_货币单位.Visible = true;
            this.gridCol_货币单位.VisibleIndex = 13;
            // 
            // panel1
            // 
            this.panel1.AutoScroll = true;
            this.panel1.Controls.Add(this.gridControl发票);
            this.panel1.Controls.Add(this.radio回款);
            this.panel1.Controls.Add(this.radio发票);
            this.panel1.Controls.Add(this.gridControl回款);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 25);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1073, 422);
            this.panel1.TabIndex = 173;
            // 
            // gridControl发票
            // 
            this.gridControl发票.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.gridControl发票.Location = new System.Drawing.Point(6, 62);
            this.gridControl发票.LookAndFeel.SkinName = "Office 2010 Blue";
            this.gridControl发票.MainView = this.gridView发票;
            this.gridControl发票.Name = "gridControl发票";
            this.gridControl发票.Size = new System.Drawing.Size(1067, 360);
            this.gridControl发票.TabIndex = 194;
            this.gridControl发票.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView发票});
            // 
            // gridView发票
            // 
            this.gridView发票.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.gridCol销售组织,
            this.gridCol发票号码,
            this.gridCol发票类型,
            this.gridCol发票类型名称,
            this.gridCol发票日期,
            this.gridCol客户编码,
            this.gridCol客户名称,
            this.gridCol代码商编码,
            this.gridCol代理商名称,
            this.gridCol业务员编码,
            this.gridCol业务员名称,
            this.gridCol省份编码,
            this.gridCol省份名称,
            this.gridCol城市编码,
            this.gridCol发货单号,
            this.gridCol发货行号,
            this.gridCol货物编码,
            this.gridCol货物名称,
            this.gridCol规格型号,
            this.gridCol批次,
            this.gridCol单价,
            this.gridCol开票数量,
            this.gridCol金额,
            this.gridCol货币单位});
            this.gridView发票.GridControl = this.gridControl发票;
            this.gridView发票.IndicatorWidth = 40;
            this.gridView发票.Name = "gridView发票";
            this.gridView发票.OptionsBehavior.AllowDeleteRows = DevExpress.Utils.DefaultBoolean.True;
            this.gridView发票.OptionsBehavior.EditorShowMode = DevExpress.Utils.EditorShowMode.MouseDown;
            this.gridView发票.OptionsCustomization.AllowGroup = false;
            this.gridView发票.OptionsCustomization.AllowQuickHideColumns = false;
            this.gridView发票.OptionsNavigation.EnterMoveNextColumn = true;
            this.gridView发票.OptionsView.ColumnAutoWidth = false;
            this.gridView发票.OptionsView.ShowFooter = true;
            this.gridView发票.OptionsView.ShowGroupPanel = false;
            this.gridView发票.CustomDrawRowIndicator += new DevExpress.XtraGrid.Views.Grid.RowIndicatorCustomDrawEventHandler(this.gridView1_CustomDrawRowIndicator);
            // 
            // gridCol销售组织
            // 
            this.gridCol销售组织.Caption = "销售组织";
            this.gridCol销售组织.FieldName = "销售组织";
            this.gridCol销售组织.Name = "gridCol销售组织";
            this.gridCol销售组织.OptionsColumn.AllowEdit = false;
            this.gridCol销售组织.Visible = true;
            this.gridCol销售组织.VisibleIndex = 0;
            // 
            // gridCol发票号码
            // 
            this.gridCol发票号码.Caption = "发票号码";
            this.gridCol发票号码.FieldName = "发票号码";
            this.gridCol发票号码.Name = "gridCol发票号码";
            this.gridCol发票号码.OptionsColumn.AllowEdit = false;
            this.gridCol发票号码.Visible = true;
            this.gridCol发票号码.VisibleIndex = 1;
            // 
            // gridCol发票类型
            // 
            this.gridCol发票类型.Caption = "发票类型";
            this.gridCol发票类型.FieldName = "发票类型";
            this.gridCol发票类型.Name = "gridCol发票类型";
            this.gridCol发票类型.OptionsColumn.AllowEdit = false;
            this.gridCol发票类型.Visible = true;
            this.gridCol发票类型.VisibleIndex = 2;
            // 
            // gridCol发票类型名称
            // 
            this.gridCol发票类型名称.Caption = "发票类型名称";
            this.gridCol发票类型名称.FieldName = "发票类型名称";
            this.gridCol发票类型名称.Name = "gridCol发票类型名称";
            this.gridCol发票类型名称.OptionsColumn.AllowEdit = false;
            this.gridCol发票类型名称.Visible = true;
            this.gridCol发票类型名称.VisibleIndex = 3;
            // 
            // gridCol发票日期
            // 
            this.gridCol发票日期.Caption = "发票日期";
            this.gridCol发票日期.FieldName = "发票日期";
            this.gridCol发票日期.Name = "gridCol发票日期";
            this.gridCol发票日期.OptionsColumn.AllowEdit = false;
            this.gridCol发票日期.Visible = true;
            this.gridCol发票日期.VisibleIndex = 4;
            // 
            // gridCol客户编码
            // 
            this.gridCol客户编码.Caption = "客户编码";
            this.gridCol客户编码.FieldName = "客户编码";
            this.gridCol客户编码.Name = "gridCol客户编码";
            this.gridCol客户编码.OptionsColumn.AllowEdit = false;
            this.gridCol客户编码.Visible = true;
            this.gridCol客户编码.VisibleIndex = 5;
            // 
            // gridCol客户名称
            // 
            this.gridCol客户名称.Caption = "客户名称";
            this.gridCol客户名称.FieldName = "客户名称";
            this.gridCol客户名称.Name = "gridCol客户名称";
            this.gridCol客户名称.OptionsColumn.AllowEdit = false;
            this.gridCol客户名称.Visible = true;
            this.gridCol客户名称.VisibleIndex = 6;
            // 
            // gridCol代码商编码
            // 
            this.gridCol代码商编码.Caption = "代码商编码";
            this.gridCol代码商编码.FieldName = "代码商编码";
            this.gridCol代码商编码.Name = "gridCol代码商编码";
            this.gridCol代码商编码.OptionsColumn.AllowEdit = false;
            this.gridCol代码商编码.Visible = true;
            this.gridCol代码商编码.VisibleIndex = 7;
            // 
            // gridCol代理商名称
            // 
            this.gridCol代理商名称.Caption = "代理商名称";
            this.gridCol代理商名称.FieldName = "代理商名称";
            this.gridCol代理商名称.Name = "gridCol代理商名称";
            this.gridCol代理商名称.OptionsColumn.AllowEdit = false;
            this.gridCol代理商名称.Visible = true;
            this.gridCol代理商名称.VisibleIndex = 8;
            // 
            // gridCol业务员编码
            // 
            this.gridCol业务员编码.Caption = "业务员编码";
            this.gridCol业务员编码.FieldName = "业务员编码";
            this.gridCol业务员编码.Name = "gridCol业务员编码";
            this.gridCol业务员编码.OptionsColumn.AllowEdit = false;
            this.gridCol业务员编码.Visible = true;
            this.gridCol业务员编码.VisibleIndex = 9;
            // 
            // gridCol业务员名称
            // 
            this.gridCol业务员名称.Caption = "业务员名称";
            this.gridCol业务员名称.FieldName = "业务员名称";
            this.gridCol业务员名称.Name = "gridCol业务员名称";
            this.gridCol业务员名称.OptionsColumn.AllowEdit = false;
            this.gridCol业务员名称.Visible = true;
            this.gridCol业务员名称.VisibleIndex = 10;
            // 
            // gridCol省份编码
            // 
            this.gridCol省份编码.Caption = "省份编码";
            this.gridCol省份编码.FieldName = "省份编码";
            this.gridCol省份编码.Name = "gridCol省份编码";
            this.gridCol省份编码.OptionsColumn.AllowEdit = false;
            this.gridCol省份编码.Visible = true;
            this.gridCol省份编码.VisibleIndex = 11;
            // 
            // gridCol省份名称
            // 
            this.gridCol省份名称.Caption = "省份名称";
            this.gridCol省份名称.FieldName = "省份名称";
            this.gridCol省份名称.Name = "gridCol省份名称";
            this.gridCol省份名称.OptionsColumn.AllowEdit = false;
            this.gridCol省份名称.Visible = true;
            this.gridCol省份名称.VisibleIndex = 12;
            // 
            // gridCol城市编码
            // 
            this.gridCol城市编码.Caption = "城市编码";
            this.gridCol城市编码.FieldName = "城市编码";
            this.gridCol城市编码.Name = "gridCol城市编码";
            this.gridCol城市编码.OptionsColumn.AllowEdit = false;
            this.gridCol城市编码.Visible = true;
            this.gridCol城市编码.VisibleIndex = 13;
            // 
            // gridCol发货单号
            // 
            this.gridCol发货单号.Caption = "发货单号";
            this.gridCol发货单号.FieldName = "发货单号";
            this.gridCol发货单号.Name = "gridCol发货单号";
            this.gridCol发货单号.OptionsColumn.AllowEdit = false;
            this.gridCol发货单号.Visible = true;
            this.gridCol发货单号.VisibleIndex = 14;
            // 
            // gridCol发货行号
            // 
            this.gridCol发货行号.Caption = "发货行号";
            this.gridCol发货行号.FieldName = "发货行号";
            this.gridCol发货行号.Name = "gridCol发货行号";
            this.gridCol发货行号.OptionsColumn.AllowEdit = false;
            this.gridCol发货行号.Visible = true;
            this.gridCol发货行号.VisibleIndex = 15;
            // 
            // gridCol货物编码
            // 
            this.gridCol货物编码.Caption = "货物编码";
            this.gridCol货物编码.FieldName = "货物编码";
            this.gridCol货物编码.Name = "gridCol货物编码";
            this.gridCol货物编码.OptionsColumn.AllowEdit = false;
            this.gridCol货物编码.Visible = true;
            this.gridCol货物编码.VisibleIndex = 16;
            // 
            // gridCol货物名称
            // 
            this.gridCol货物名称.Caption = "货物名称";
            this.gridCol货物名称.FieldName = "货物名称";
            this.gridCol货物名称.Name = "gridCol货物名称";
            this.gridCol货物名称.OptionsColumn.AllowEdit = false;
            this.gridCol货物名称.Visible = true;
            this.gridCol货物名称.VisibleIndex = 17;
            // 
            // gridCol规格型号
            // 
            this.gridCol规格型号.Caption = "规格型号";
            this.gridCol规格型号.FieldName = "规格型号";
            this.gridCol规格型号.Name = "gridCol规格型号";
            this.gridCol规格型号.OptionsColumn.AllowEdit = false;
            this.gridCol规格型号.Visible = true;
            this.gridCol规格型号.VisibleIndex = 18;
            // 
            // gridCol批次
            // 
            this.gridCol批次.Caption = "批次";
            this.gridCol批次.FieldName = "批次";
            this.gridCol批次.Name = "gridCol批次";
            this.gridCol批次.OptionsColumn.AllowEdit = false;
            this.gridCol批次.Visible = true;
            this.gridCol批次.VisibleIndex = 19;
            // 
            // gridCol单价
            // 
            this.gridCol单价.Caption = "单价";
            this.gridCol单价.DisplayFormat.FormatString = "n2";
            this.gridCol单价.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.gridCol单价.FieldName = "单价";
            this.gridCol单价.Name = "gridCol单价";
            this.gridCol单价.OptionsColumn.AllowEdit = false;
            this.gridCol单价.Visible = true;
            this.gridCol单价.VisibleIndex = 20;
            // 
            // gridCol开票数量
            // 
            this.gridCol开票数量.Caption = "开票数量";
            this.gridCol开票数量.DisplayFormat.FormatString = "n2";
            this.gridCol开票数量.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.gridCol开票数量.FieldName = "开票数量";
            this.gridCol开票数量.Name = "gridCol开票数量";
            this.gridCol开票数量.OptionsColumn.AllowEdit = false;
            this.gridCol开票数量.Summary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] {
            new DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum)});
            this.gridCol开票数量.Visible = true;
            this.gridCol开票数量.VisibleIndex = 21;
            // 
            // gridCol金额
            // 
            this.gridCol金额.Caption = "金额";
            this.gridCol金额.DisplayFormat.FormatString = "n2";
            this.gridCol金额.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.gridCol金额.FieldName = "金额";
            this.gridCol金额.Name = "gridCol金额";
            this.gridCol金额.OptionsColumn.AllowEdit = false;
            this.gridCol金额.Summary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] {
            new DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum)});
            this.gridCol金额.Visible = true;
            this.gridCol金额.VisibleIndex = 22;
            // 
            // gridCol货币单位
            // 
            this.gridCol货币单位.Caption = "货币单位";
            this.gridCol货币单位.FieldName = "货币单位";
            this.gridCol货币单位.Name = "gridCol货币单位";
            this.gridCol货币单位.OptionsColumn.AllowEdit = false;
            this.gridCol货币单位.Visible = true;
            this.gridCol货币单位.VisibleIndex = 23;
            // 
            // radio回款
            // 
            this.radio回款.AutoSize = true;
            this.radio回款.Location = new System.Drawing.Point(137, 23);
            this.radio回款.Name = "radio回款";
            this.radio回款.Size = new System.Drawing.Size(47, 16);
            this.radio回款.TabIndex = 193;
            this.radio回款.Text = "回款";
            this.radio回款.UseVisualStyleBackColor = true;
            this.radio回款.CheckedChanged += new System.EventHandler(this.radio回款_CheckedChanged);
            // 
            // radio发票
            // 
            this.radio发票.AutoSize = true;
            this.radio发票.Checked = true;
            this.radio发票.Location = new System.Drawing.Point(27, 23);
            this.radio发票.Name = "radio发票";
            this.radio发票.Size = new System.Drawing.Size(47, 16);
            this.radio发票.TabIndex = 192;
            this.radio发票.TabStop = true;
            this.radio发票.Text = "发票";
            this.radio发票.UseVisualStyleBackColor = true;
            this.radio发票.CheckedChanged += new System.EventHandler(this.radio发票_CheckedChanged);
            // 
            // ImprotExcel
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.menuStrip1);
            this.Name = "ImprotExcel";
            this.Size = new System.Drawing.Size(1073, 447);
            this.Load += new System.EventHandler(this.Frm_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl回款)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView回款)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl发票)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView发票)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem btnSave;
        private DevExpress.XtraGrid.GridControl gridControl回款;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.ToolStripMenuItem btnImport;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView回款;
        private System.Windows.Forms.RadioButton radio回款;
        private System.Windows.Forms.RadioButton radio发票;
        private DevExpress.XtraGrid.GridControl gridControl发票;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView发票;
        private DevExpress.XtraGrid.Columns.GridColumn gridCol代码商编码;
        private DevExpress.XtraGrid.Columns.GridColumn gridCol代理商名称;
        private DevExpress.XtraGrid.Columns.GridColumn gridCol业务员编码;
        private DevExpress.XtraGrid.Columns.GridColumn gridCol业务员名称;
        private DevExpress.XtraGrid.Columns.GridColumn gridCol省份编码;
        private DevExpress.XtraGrid.Columns.GridColumn gridCol省份名称;
        private DevExpress.XtraGrid.Columns.GridColumn gridCol城市编码;
        private DevExpress.XtraGrid.Columns.GridColumn gridCol发货单号;
        private DevExpress.XtraGrid.Columns.GridColumn gridCol发货行号;
        private DevExpress.XtraGrid.Columns.GridColumn gridCol货物编码;
        private DevExpress.XtraGrid.Columns.GridColumn gridCol货物名称;
        private DevExpress.XtraGrid.Columns.GridColumn gridCol规格型号;
        private DevExpress.XtraGrid.Columns.GridColumn gridCol批次;
        private DevExpress.XtraGrid.Columns.GridColumn gridCol单价;
        private DevExpress.XtraGrid.Columns.GridColumn gridCol开票数量;
        private DevExpress.XtraGrid.Columns.GridColumn gridCol金额;
        private DevExpress.XtraGrid.Columns.GridColumn gridCol货币单位;
        private DevExpress.XtraGrid.Columns.GridColumn gridCol_收款单号;
        private DevExpress.XtraGrid.Columns.GridColumn gridCol_收款单日期;
        private DevExpress.XtraGrid.Columns.GridColumn gridCol_收款单金额;
        private DevExpress.XtraGrid.Columns.GridColumn gridCol_业务员编码;
        private DevExpress.XtraGrid.Columns.GridColumn gridCol_业务员;
        private DevExpress.XtraGrid.Columns.GridColumn gridCol_核销金额;
        private DevExpress.XtraGrid.Columns.GridColumn gridCol_核销日期;
        private DevExpress.XtraGrid.Columns.GridColumn gridCol_发票号码;
        private DevExpress.XtraGrid.Columns.GridColumn gridCol_发票日期;
        private DevExpress.XtraGrid.Columns.GridColumn gridCol_销售组织;
        private DevExpress.XtraGrid.Columns.GridColumn gridCol_客户编码;
        private DevExpress.XtraGrid.Columns.GridColumn gridCol_客户名称;
        private DevExpress.XtraGrid.Columns.GridColumn gridCol_发票金额;
        private DevExpress.XtraGrid.Columns.GridColumn gridCol_货币单位;
        private DevExpress.XtraGrid.Columns.GridColumn gridCol销售组织;
        private DevExpress.XtraGrid.Columns.GridColumn gridCol发票号码;
        private DevExpress.XtraGrid.Columns.GridColumn gridCol发票类型;
        private DevExpress.XtraGrid.Columns.GridColumn gridCol发票类型名称;
        private DevExpress.XtraGrid.Columns.GridColumn gridCol发票日期;
        private DevExpress.XtraGrid.Columns.GridColumn gridCol客户编码;
        private DevExpress.XtraGrid.Columns.GridColumn gridCol客户名称;
    }
}
