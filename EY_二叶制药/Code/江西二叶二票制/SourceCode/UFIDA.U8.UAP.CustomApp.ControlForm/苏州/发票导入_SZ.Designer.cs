namespace UFIDA.U8.UAP.CustomApp.ControlForm
{
    partial class 发票导入_SZ
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
            this.btnLoadExcel = new System.Windows.Forms.ToolStripMenuItem();
            this.btnSEL = new System.Windows.Forms.ToolStripMenuItem();
            this.btnEdit = new System.Windows.Forms.ToolStripMenuItem();
            this.btnDel = new System.Windows.Forms.ToolStripMenuItem();
            this.btnSave = new System.Windows.Forms.ToolStripMenuItem();
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            this.gridControl1 = new DevExpress.XtraGrid.GridControl();
            this.gridView1 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.gridCol选择 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridCol金税发票号码 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridCol发票号码 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridCol销售组织 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridCol发票类型 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridCol发票类型名称 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridCol发票日期 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridCol客户编码 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridCol客户旧编码 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridCol客户名称 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridCol代理商编码 = new DevExpress.XtraGrid.Columns.GridColumn();
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
            this.gridCol发票已取消 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridCol被冲销的号码 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColPO项目 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridCol已使用 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColiID = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridCol货物旧编码 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.panel1 = new System.Windows.Forms.Panel();
            this.txt发票号 = new DevExpress.XtraEditors.TextEdit();
            this.label1 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.chkAll = new System.Windows.Forms.CheckBox();
            this.lookUpEditYear = new DevExpress.XtraEditors.LookUpEdit();
            this.lookUpEditMonth = new DevExpress.XtraEditors.LookUpEdit();
            this.menuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).BeginInit();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txt发票号.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lookUpEditYear.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lookUpEditMonth.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btnLoadExcel,
            this.btnSEL,
            this.btnEdit,
            this.btnDel,
            this.btnSave});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(903, 25);
            this.menuStrip1.TabIndex = 172;
            this.menuStrip1.Text = "menuStrip";
            // 
            // btnLoadExcel
            // 
            this.btnLoadExcel.Name = "btnLoadExcel";
            this.btnLoadExcel.Size = new System.Drawing.Size(73, 21);
            this.btnLoadExcel.Text = "加载Excel";
            this.btnLoadExcel.Click += new System.EventHandler(this.btnLoadExcel_Click);
            // 
            // btnSEL
            // 
            this.btnSEL.Name = "btnSEL";
            this.btnSEL.Size = new System.Drawing.Size(44, 21);
            this.btnSEL.Text = "过滤";
            this.btnSEL.Click += new System.EventHandler(this.btnSEL_Click);
            // 
            // btnEdit
            // 
            this.btnEdit.Name = "btnEdit";
            this.btnEdit.Size = new System.Drawing.Size(104, 21);
            this.btnEdit.Text = "编辑金税发票号";
            this.btnEdit.Click += new System.EventHandler(this.btnEdit_Click);
            // 
            // btnDel
            // 
            this.btnDel.Name = "btnDel";
            this.btnDel.Size = new System.Drawing.Size(44, 21);
            this.btnDel.Text = "删除";
            this.btnDel.Click += new System.EventHandler(this.btnDel_Click);
            // 
            // btnSave
            // 
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(44, 21);
            this.btnSave.Text = "保存";
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // labelControl1
            // 
            this.labelControl1.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.labelControl1.Appearance.Font = new System.Drawing.Font("Tahoma", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelControl1.Location = new System.Drawing.Point(378, 3);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(142, 25);
            this.labelControl1.TabIndex = 190;
            this.labelControl1.Text = "发票导入(苏州)";
            // 
            // gridControl1
            // 
            this.gridControl1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.gridControl1.Location = new System.Drawing.Point(6, 73);
            this.gridControl1.LookAndFeel.SkinName = "Office 2010 Blue";
            this.gridControl1.MainView = this.gridView1;
            this.gridControl1.Name = "gridControl1";
            this.gridControl1.Size = new System.Drawing.Size(894, 319);
            this.gridControl1.TabIndex = 191;
            this.gridControl1.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView1});
            // 
            // gridView1
            // 
            this.gridView1.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.gridCol选择,
            this.gridCol金税发票号码,
            this.gridCol发票号码,
            this.gridCol销售组织,
            this.gridCol发票类型,
            this.gridCol发票类型名称,
            this.gridCol发票日期,
            this.gridCol客户编码,
            this.gridCol客户旧编码,
            this.gridCol客户名称,
            this.gridCol代理商编码,
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
            this.gridCol货币单位,
            this.gridCol发票已取消,
            this.gridCol被冲销的号码,
            this.gridColPO项目,
            this.gridCol已使用,
            this.gridColiID,
            this.gridCol货物旧编码});
            this.gridView1.GridControl = this.gridControl1;
            this.gridView1.IndicatorWidth = 40;
            this.gridView1.Name = "gridView1";
            this.gridView1.OptionsBehavior.AllowDeleteRows = DevExpress.Utils.DefaultBoolean.True;
            this.gridView1.OptionsBehavior.EditorShowMode = DevExpress.Utils.EditorShowMode.MouseDown;
            this.gridView1.OptionsCustomization.AllowFilter = false;
            this.gridView1.OptionsCustomization.AllowGroup = false;
            this.gridView1.OptionsCustomization.AllowQuickHideColumns = false;
            this.gridView1.OptionsCustomization.AllowSort = false;
            this.gridView1.OptionsNavigation.EnterMoveNextColumn = true;
            this.gridView1.OptionsView.ColumnAutoWidth = false;
            this.gridView1.OptionsView.ShowFooter = true;
            this.gridView1.OptionsView.ShowGroupPanel = false;
            this.gridView1.CustomDrawRowIndicator += new DevExpress.XtraGrid.Views.Grid.RowIndicatorCustomDrawEventHandler(this.gridView1_CustomDrawRowIndicator);
            this.gridView1.CellValueChanged += new DevExpress.XtraGrid.Views.Base.CellValueChangedEventHandler(this.gridView1_CellValueChanged);
            // 
            // gridCol选择
            // 
            this.gridCol选择.Caption = "选择";
            this.gridCol选择.FieldName = "choose";
            this.gridCol选择.Name = "gridCol选择";
            this.gridCol选择.Visible = true;
            this.gridCol选择.VisibleIndex = 0;
            this.gridCol选择.Width = 36;
            // 
            // gridCol金税发票号码
            // 
            this.gridCol金税发票号码.AppearanceHeader.ForeColor = System.Drawing.Color.Blue;
            this.gridCol金税发票号码.AppearanceHeader.Options.UseForeColor = true;
            this.gridCol金税发票号码.Caption = "金税发票号码";
            this.gridCol金税发票号码.FieldName = "金税发票号码";
            this.gridCol金税发票号码.Name = "gridCol金税发票号码";
            this.gridCol金税发票号码.Visible = true;
            this.gridCol金税发票号码.VisibleIndex = 2;
            this.gridCol金税发票号码.Width = 84;
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
            // gridCol销售组织
            // 
            this.gridCol销售组织.Caption = "销售组织";
            this.gridCol销售组织.FieldName = "销售组织";
            this.gridCol销售组织.Name = "gridCol销售组织";
            this.gridCol销售组织.OptionsColumn.AllowEdit = false;
            this.gridCol销售组织.Visible = true;
            this.gridCol销售组织.VisibleIndex = 3;
            // 
            // gridCol发票类型
            // 
            this.gridCol发票类型.Caption = "发票类型";
            this.gridCol发票类型.FieldName = "发票类型";
            this.gridCol发票类型.Name = "gridCol发票类型";
            this.gridCol发票类型.OptionsColumn.AllowEdit = false;
            this.gridCol发票类型.Visible = true;
            this.gridCol发票类型.VisibleIndex = 4;
            // 
            // gridCol发票类型名称
            // 
            this.gridCol发票类型名称.Caption = "发票类型名称";
            this.gridCol发票类型名称.FieldName = "发票类型名称";
            this.gridCol发票类型名称.Name = "gridCol发票类型名称";
            this.gridCol发票类型名称.OptionsColumn.AllowEdit = false;
            this.gridCol发票类型名称.Visible = true;
            this.gridCol发票类型名称.VisibleIndex = 5;
            this.gridCol发票类型名称.Width = 87;
            // 
            // gridCol发票日期
            // 
            this.gridCol发票日期.Caption = "发票日期";
            this.gridCol发票日期.FieldName = "发票日期";
            this.gridCol发票日期.Name = "gridCol发票日期";
            this.gridCol发票日期.OptionsColumn.AllowEdit = false;
            this.gridCol发票日期.Visible = true;
            this.gridCol发票日期.VisibleIndex = 22;
            // 
            // gridCol客户编码
            // 
            this.gridCol客户编码.Caption = "客户编码";
            this.gridCol客户编码.FieldName = "客户编码";
            this.gridCol客户编码.Name = "gridCol客户编码";
            this.gridCol客户编码.OptionsColumn.AllowEdit = false;
            this.gridCol客户编码.Visible = true;
            this.gridCol客户编码.VisibleIndex = 7;
            // 
            // gridCol客户旧编码
            // 
            this.gridCol客户旧编码.Caption = "客户旧编码";
            this.gridCol客户旧编码.FieldName = "客户旧编码";
            this.gridCol客户旧编码.Name = "gridCol客户旧编码";
            this.gridCol客户旧编码.OptionsColumn.AllowEdit = false;
            this.gridCol客户旧编码.Visible = true;
            this.gridCol客户旧编码.VisibleIndex = 8;
            // 
            // gridCol客户名称
            // 
            this.gridCol客户名称.Caption = "客户名称";
            this.gridCol客户名称.FieldName = "客户名称";
            this.gridCol客户名称.Name = "gridCol客户名称";
            this.gridCol客户名称.OptionsColumn.AllowEdit = false;
            this.gridCol客户名称.Visible = true;
            this.gridCol客户名称.VisibleIndex = 9;
            // 
            // gridCol代理商编码
            // 
            this.gridCol代理商编码.Caption = "代理商编码";
            this.gridCol代理商编码.FieldName = "代理商编码";
            this.gridCol代理商编码.Name = "gridCol代理商编码";
            this.gridCol代理商编码.OptionsColumn.AllowEdit = false;
            this.gridCol代理商编码.Visible = true;
            this.gridCol代理商编码.VisibleIndex = 10;
            // 
            // gridCol代理商名称
            // 
            this.gridCol代理商名称.Caption = "代理商名称";
            this.gridCol代理商名称.FieldName = "代理商名称";
            this.gridCol代理商名称.Name = "gridCol代理商名称";
            this.gridCol代理商名称.OptionsColumn.AllowEdit = false;
            this.gridCol代理商名称.Visible = true;
            this.gridCol代理商名称.VisibleIndex = 11;
            // 
            // gridCol业务员编码
            // 
            this.gridCol业务员编码.Caption = "业务员编码";
            this.gridCol业务员编码.FieldName = "业务员编码";
            this.gridCol业务员编码.Name = "gridCol业务员编码";
            this.gridCol业务员编码.OptionsColumn.AllowEdit = false;
            this.gridCol业务员编码.Visible = true;
            this.gridCol业务员编码.VisibleIndex = 12;
            // 
            // gridCol业务员名称
            // 
            this.gridCol业务员名称.Caption = "业务员名称";
            this.gridCol业务员名称.FieldName = "业务员名称";
            this.gridCol业务员名称.Name = "gridCol业务员名称";
            this.gridCol业务员名称.OptionsColumn.AllowEdit = false;
            this.gridCol业务员名称.Summary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] {
            new DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum)});
            this.gridCol业务员名称.Visible = true;
            this.gridCol业务员名称.VisibleIndex = 13;
            // 
            // gridCol省份编码
            // 
            this.gridCol省份编码.Caption = "省份编码";
            this.gridCol省份编码.FieldName = "省份编码";
            this.gridCol省份编码.Name = "gridCol省份编码";
            this.gridCol省份编码.OptionsColumn.AllowEdit = false;
            this.gridCol省份编码.Visible = true;
            this.gridCol省份编码.VisibleIndex = 14;
            // 
            // gridCol省份名称
            // 
            this.gridCol省份名称.Caption = "省份名称";
            this.gridCol省份名称.FieldName = "省份名称";
            this.gridCol省份名称.Name = "gridCol省份名称";
            this.gridCol省份名称.OptionsColumn.AllowEdit = false;
            this.gridCol省份名称.Visible = true;
            this.gridCol省份名称.VisibleIndex = 15;
            // 
            // gridCol城市编码
            // 
            this.gridCol城市编码.Caption = "城市编码";
            this.gridCol城市编码.FieldName = "城市编码";
            this.gridCol城市编码.Name = "gridCol城市编码";
            this.gridCol城市编码.OptionsColumn.AllowEdit = false;
            this.gridCol城市编码.Visible = true;
            this.gridCol城市编码.VisibleIndex = 16;
            // 
            // gridCol发货单号
            // 
            this.gridCol发货单号.Caption = "发货单号";
            this.gridCol发货单号.FieldName = "发货单号";
            this.gridCol发货单号.Name = "gridCol发货单号";
            this.gridCol发货单号.OptionsColumn.AllowEdit = false;
            this.gridCol发货单号.Visible = true;
            this.gridCol发货单号.VisibleIndex = 17;
            // 
            // gridCol发货行号
            // 
            this.gridCol发货行号.Caption = "发货行号";
            this.gridCol发货行号.FieldName = "发货行号";
            this.gridCol发货行号.Name = "gridCol发货行号";
            this.gridCol发货行号.OptionsColumn.AllowEdit = false;
            this.gridCol发货行号.Visible = true;
            this.gridCol发货行号.VisibleIndex = 23;
            // 
            // gridCol货物编码
            // 
            this.gridCol货物编码.Caption = "货物编码";
            this.gridCol货物编码.FieldName = "货物编码";
            this.gridCol货物编码.Name = "gridCol货物编码";
            this.gridCol货物编码.OptionsColumn.AllowEdit = false;
            this.gridCol货物编码.Visible = true;
            this.gridCol货物编码.VisibleIndex = 24;
            // 
            // gridCol货物名称
            // 
            this.gridCol货物名称.Caption = "货物名称";
            this.gridCol货物名称.FieldName = "货物名称";
            this.gridCol货物名称.Name = "gridCol货物名称";
            this.gridCol货物名称.OptionsColumn.AllowEdit = false;
            this.gridCol货物名称.Visible = true;
            this.gridCol货物名称.VisibleIndex = 26;
            // 
            // gridCol规格型号
            // 
            this.gridCol规格型号.Caption = "规格型号";
            this.gridCol规格型号.FieldName = "规格型号";
            this.gridCol规格型号.Name = "gridCol规格型号";
            this.gridCol规格型号.OptionsColumn.AllowEdit = false;
            this.gridCol规格型号.Visible = true;
            this.gridCol规格型号.VisibleIndex = 27;
            // 
            // gridCol批次
            // 
            this.gridCol批次.Caption = "批次";
            this.gridCol批次.FieldName = "批次";
            this.gridCol批次.Name = "gridCol批次";
            this.gridCol批次.OptionsColumn.AllowEdit = false;
            this.gridCol批次.Visible = true;
            this.gridCol批次.VisibleIndex = 6;
            this.gridCol批次.Width = 87;
            // 
            // gridCol单价
            // 
            this.gridCol单价.Caption = "单价";
            this.gridCol单价.FieldName = "单价";
            this.gridCol单价.Name = "gridCol单价";
            this.gridCol单价.OptionsColumn.AllowEdit = false;
            this.gridCol单价.Visible = true;
            this.gridCol单价.VisibleIndex = 18;
            // 
            // gridCol开票数量
            // 
            this.gridCol开票数量.Caption = "开票数量";
            this.gridCol开票数量.FieldName = "开票数量";
            this.gridCol开票数量.Name = "gridCol开票数量";
            this.gridCol开票数量.OptionsColumn.AllowEdit = false;
            this.gridCol开票数量.Summary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] {
            new DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum)});
            this.gridCol开票数量.Visible = true;
            this.gridCol开票数量.VisibleIndex = 19;
            // 
            // gridCol金额
            // 
            this.gridCol金额.Caption = "金额";
            this.gridCol金额.FieldName = "金额";
            this.gridCol金额.Name = "gridCol金额";
            this.gridCol金额.OptionsColumn.AllowEdit = false;
            this.gridCol金额.Summary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] {
            new DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum)});
            this.gridCol金额.Visible = true;
            this.gridCol金额.VisibleIndex = 20;
            // 
            // gridCol货币单位
            // 
            this.gridCol货币单位.Caption = "货币单位";
            this.gridCol货币单位.FieldName = "货币单位";
            this.gridCol货币单位.Name = "gridCol货币单位";
            this.gridCol货币单位.OptionsColumn.AllowEdit = false;
            this.gridCol货币单位.Visible = true;
            this.gridCol货币单位.VisibleIndex = 21;
            // 
            // gridCol发票已取消
            // 
            this.gridCol发票已取消.Caption = "发票已取消";
            this.gridCol发票已取消.FieldName = "发票已取消";
            this.gridCol发票已取消.Name = "gridCol发票已取消";
            this.gridCol发票已取消.OptionsColumn.AllowEdit = false;
            this.gridCol发票已取消.Visible = true;
            this.gridCol发票已取消.VisibleIndex = 28;
            // 
            // gridCol被冲销的号码
            // 
            this.gridCol被冲销的号码.Caption = "被冲销的号码";
            this.gridCol被冲销的号码.FieldName = "被冲销的号码";
            this.gridCol被冲销的号码.Name = "gridCol被冲销的号码";
            this.gridCol被冲销的号码.OptionsColumn.AllowEdit = false;
            this.gridCol被冲销的号码.Visible = true;
            this.gridCol被冲销的号码.VisibleIndex = 29;
            this.gridCol被冲销的号码.Width = 85;
            // 
            // gridColPO项目
            // 
            this.gridColPO项目.Caption = "PO项目";
            this.gridColPO项目.FieldName = "PO项目";
            this.gridColPO项目.Name = "gridColPO项目";
            this.gridColPO项目.OptionsColumn.AllowEdit = false;
            this.gridColPO项目.Visible = true;
            this.gridColPO项目.VisibleIndex = 30;
            // 
            // gridCol已使用
            // 
            this.gridCol已使用.Caption = "已使用";
            this.gridCol已使用.FieldName = "已使用";
            this.gridCol已使用.Name = "gridCol已使用";
            this.gridCol已使用.OptionsColumn.AllowEdit = false;
            // 
            // gridColiID
            // 
            this.gridColiID.Caption = "iID";
            this.gridColiID.FieldName = "iID";
            this.gridColiID.Name = "gridColiID";
            this.gridColiID.OptionsColumn.AllowEdit = false;
            // 
            // gridCol货物旧编码
            // 
            this.gridCol货物旧编码.Caption = "货物旧编码";
            this.gridCol货物旧编码.FieldName = "货物旧编码";
            this.gridCol货物旧编码.Name = "gridCol货物旧编码";
            this.gridCol货物旧编码.OptionsColumn.AllowEdit = false;
            this.gridCol货物旧编码.Visible = true;
            this.gridCol货物旧编码.VisibleIndex = 25;
            // 
            // panel1
            // 
            this.panel1.AutoScroll = true;
            this.panel1.Controls.Add(this.gridControl1);
            this.panel1.Controls.Add(this.txt发票号);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.chkAll);
            this.panel1.Controls.Add(this.labelControl1);
            this.panel1.Controls.Add(this.lookUpEditYear);
            this.panel1.Controls.Add(this.lookUpEditMonth);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 25);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(903, 392);
            this.panel1.TabIndex = 173;
            // 
            // txt发票号
            // 
            this.txt发票号.Enabled = false;
            this.txt发票号.Location = new System.Drawing.Point(250, 27);
            this.txt发票号.Name = "txt发票号";
            this.txt发票号.Properties.DisplayFormat.FormatString = "n2";
            this.txt发票号.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.txt发票号.Properties.EditFormat.FormatString = "n2";
            this.txt发票号.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.txt发票号.Size = new System.Drawing.Size(122, 20);
            this.txt发票号.TabIndex = 254;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(203, 31);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(41, 12);
            this.label1.TabIndex = 253;
            this.label1.Text = "发票号";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(13, 31);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(29, 12);
            this.label3.TabIndex = 252;
            this.label3.Text = "期间";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // chkAll
            // 
            this.chkAll.AutoSize = true;
            this.chkAll.Location = new System.Drawing.Point(15, 51);
            this.chkAll.Name = "chkAll";
            this.chkAll.Size = new System.Drawing.Size(48, 16);
            this.chkAll.TabIndex = 251;
            this.chkAll.Text = "全选";
            this.chkAll.UseVisualStyleBackColor = true;
            this.chkAll.CheckedChanged += new System.EventHandler(this.chkAll_CheckedChanged);
            // 
            // lookUpEditYear
            // 
            this.lookUpEditYear.AllowHtmlTextInToolTip = DevExpress.Utils.DefaultBoolean.True;
            this.lookUpEditYear.Location = new System.Drawing.Point(60, 27);
            this.lookUpEditYear.Name = "lookUpEditYear";
            this.lookUpEditYear.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.lookUpEditYear.Properties.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("iYear", "年")});
            this.lookUpEditYear.Properties.DisplayMember = "iYear";
            this.lookUpEditYear.Properties.NullText = "";
            this.lookUpEditYear.Properties.PopupWidth = 400;
            this.lookUpEditYear.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.Standard;
            this.lookUpEditYear.Properties.ValueMember = "iYear";
            this.lookUpEditYear.Size = new System.Drawing.Size(61, 20);
            this.lookUpEditYear.TabIndex = 246;
            // 
            // lookUpEditMonth
            // 
            this.lookUpEditMonth.AllowHtmlTextInToolTip = DevExpress.Utils.DefaultBoolean.True;
            this.lookUpEditMonth.Location = new System.Drawing.Point(127, 27);
            this.lookUpEditMonth.Name = "lookUpEditMonth";
            this.lookUpEditMonth.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.lookUpEditMonth.Properties.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("iMonth", "月")});
            this.lookUpEditMonth.Properties.DisplayMember = "iMonth";
            this.lookUpEditMonth.Properties.NullText = "";
            this.lookUpEditMonth.Properties.PopupWidth = 400;
            this.lookUpEditMonth.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.Standard;
            this.lookUpEditMonth.Properties.ValueMember = "iMonth";
            this.lookUpEditMonth.Size = new System.Drawing.Size(51, 20);
            this.lookUpEditMonth.TabIndex = 241;
            // 
            // 发票导入_SZ
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.menuStrip1);
            this.Name = "发票导入_SZ";
            this.Size = new System.Drawing.Size(903, 417);
            this.Load += new System.EventHandler(this.Frm_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txt发票号.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lookUpEditYear.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lookUpEditMonth.Properties)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem btnDel;
        private System.Windows.Forms.ToolStripMenuItem btnSave;
        private DevExpress.XtraEditors.LabelControl labelControl1;
        private DevExpress.XtraGrid.GridControl gridControl1;
        private System.Windows.Forms.Panel panel1;
        private DevExpress.XtraEditors.LookUpEdit lookUpEditMonth;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView1;
        private DevExpress.XtraGrid.Columns.GridColumn gridCol销售组织;
        private DevExpress.XtraGrid.Columns.GridColumn gridCol发票号码;
        private DevExpress.XtraGrid.Columns.GridColumn gridCol发票类型;
        private DevExpress.XtraGrid.Columns.GridColumn gridCol发票类型名称;
        private DevExpress.XtraGrid.Columns.GridColumn gridCol客户编码;
        private DevExpress.XtraGrid.Columns.GridColumn gridCol客户旧编码;
        private DevExpress.XtraGrid.Columns.GridColumn gridCol客户名称;
        private DevExpress.XtraGrid.Columns.GridColumn gridCol代理商编码;
        private DevExpress.XtraGrid.Columns.GridColumn gridCol代理商名称;
        private DevExpress.XtraGrid.Columns.GridColumn gridCol业务员编码;
        private DevExpress.XtraEditors.LookUpEdit lookUpEditYear;
        private DevExpress.XtraGrid.Columns.GridColumn gridCol业务员名称;
        private DevExpress.XtraGrid.Columns.GridColumn gridCol省份编码;
        private DevExpress.XtraGrid.Columns.GridColumn gridCol省份名称;
        private DevExpress.XtraGrid.Columns.GridColumn gridCol城市编码;
        private DevExpress.XtraGrid.Columns.GridColumn gridCol发货单号;
        private DevExpress.XtraGrid.Columns.GridColumn gridCol选择;
        private System.Windows.Forms.CheckBox chkAll;
        private DevExpress.XtraGrid.Columns.GridColumn gridCol发货行号;
        private DevExpress.XtraGrid.Columns.GridColumn gridCol发票日期;
        private DevExpress.XtraGrid.Columns.GridColumn gridCol货物编码;
        private DevExpress.XtraGrid.Columns.GridColumn gridCol货物名称;
        private DevExpress.XtraGrid.Columns.GridColumn gridCol规格型号;
        private DevExpress.XtraGrid.Columns.GridColumn gridCol批次;
        private DevExpress.XtraGrid.Columns.GridColumn gridCol单价;
        private DevExpress.XtraGrid.Columns.GridColumn gridCol开票数量;
        private DevExpress.XtraGrid.Columns.GridColumn gridCol金额;
        private DevExpress.XtraGrid.Columns.GridColumn gridCol货币单位;
        private DevExpress.XtraGrid.Columns.GridColumn gridCol金税发票号码;
        private System.Windows.Forms.ToolStripMenuItem btnLoadExcel;
        private System.Windows.Forms.Label label3;
        private DevExpress.XtraGrid.Columns.GridColumn gridCol发票已取消;
        private DevExpress.XtraGrid.Columns.GridColumn gridCol被冲销的号码;
        private DevExpress.XtraGrid.Columns.GridColumn gridColPO项目;
        private DevExpress.XtraGrid.Columns.GridColumn gridCol已使用;
        private System.Windows.Forms.ToolStripMenuItem btnSEL;
        private System.Windows.Forms.Label label1;
        private DevExpress.XtraEditors.TextEdit txt发票号;
        private System.Windows.Forms.ToolStripMenuItem btnEdit;
        private DevExpress.XtraGrid.Columns.GridColumn gridColiID;
        private DevExpress.XtraGrid.Columns.GridColumn gridCol货物旧编码;
    }
}
