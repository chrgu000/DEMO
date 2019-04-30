namespace UFIDA.U8.UAP.CustomApp.ControlForm
{
    partial class 能源分配
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
            this.btn刷新 = new System.Windows.Forms.ToolStripMenuItem();
            this.btnDel = new System.Windows.Forms.ToolStripMenuItem();
            this.btn计算 = new System.Windows.Forms.ToolStripMenuItem();
            this.btnSave = new System.Windows.Forms.ToolStripMenuItem();
            this.btnAudit = new System.Windows.Forms.ToolStripMenuItem();
            this.btnUnAudit = new System.Windows.Forms.ToolStripMenuItem();
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            this.gridControl1 = new DevExpress.XtraGrid.GridControl();
            this.gridView1 = new DevExpress.XtraGrid.Views.BandedGrid.BandedGridView();
            this.gridBand1 = new DevExpress.XtraGrid.Views.BandedGrid.GridBand();
            this.gridCol部门编码 = new DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn();
            this.gridCol部门 = new DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn();
            this.gridCol制单人 = new DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn();
            this.gridCol制单日期 = new DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn();
            this.gridCol审核人 = new DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn();
            this.gridCol审核日期 = new DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn();
            this.gridCol修改人 = new DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn();
            this.gridCol修改日期 = new DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn();
            this.gridCol记账人 = new DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn();
            this.gridCol记账日期 = new DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn();
            this.gridBand2 = new DevExpress.XtraGrid.Views.BandedGrid.GridBand();
            this.gridCol供水分配率 = new DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn();
            this.gridCol供水金额 = new DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn();
            this.gridBand3 = new DevExpress.XtraGrid.Views.BandedGrid.GridBand();
            this.gridCol供电分配率 = new DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn();
            this.gridCol供电金额 = new DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn();
            this.gridBand4 = new DevExpress.XtraGrid.Views.BandedGrid.GridBand();
            this.gridCol供汽分配率 = new DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn();
            this.gridCol供汽金额 = new DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn();
            this.gridBand5 = new DevExpress.XtraGrid.Views.BandedGrid.GridBand();
            this.gridCol开利机组冷水机组分配率 = new DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn();
            this.gridCol开利机组冷水机组金额 = new DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn();
            this.gridBand6 = new DevExpress.XtraGrid.Views.BandedGrid.GridBand();
            this.gridCol合计 = new DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn();
            this.panel1 = new System.Windows.Forms.Panel();
            this.lAudit = new System.Windows.Forms.Label();
            this.txt开利机组冷水机组 = new DevExpress.XtraEditors.TextEdit();
            this.txt供水 = new DevExpress.XtraEditors.TextEdit();
            this.txt供电 = new DevExpress.XtraEditors.TextEdit();
            this.txt供汽 = new DevExpress.XtraEditors.TextEdit();
            this.label4 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.lookUpEdit会计期间 = new DevExpress.XtraEditors.LookUpEdit();
            this.label3 = new System.Windows.Forms.Label();
            this.btnExcel = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).BeginInit();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txt开利机组冷水机组.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txt供水.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txt供电.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txt供汽.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lookUpEdit会计期间.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btn刷新,
            this.btnDel,
            this.btn计算,
            this.btnSave,
            this.btnAudit,
            this.btnUnAudit,
            this.btnExcel});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Padding = new System.Windows.Forms.Padding(7, 2, 0, 2);
            this.menuStrip1.Size = new System.Drawing.Size(1054, 32);
            this.menuStrip1.TabIndex = 172;
            this.menuStrip1.Text = "menuStrip";
            // 
            // btn刷新
            // 
            this.btn刷新.Name = "btn刷新";
            this.btn刷新.Size = new System.Drawing.Size(58, 28);
            this.btn刷新.Text = "刷新";
            this.btn刷新.Click += new System.EventHandler(this.btn刷新_Click);
            // 
            // btnDel
            // 
            this.btnDel.Name = "btnDel";
            this.btnDel.Size = new System.Drawing.Size(58, 28);
            this.btnDel.Text = "删除";
            this.btnDel.Click += new System.EventHandler(this.btnDel_Click);
            // 
            // btn计算
            // 
            this.btn计算.Name = "btn计算";
            this.btn计算.Size = new System.Drawing.Size(58, 28);
            this.btn计算.Text = "计算";
            this.btn计算.Click += new System.EventHandler(this.btn计算_Click);
            // 
            // btnSave
            // 
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(58, 28);
            this.btnSave.Text = "保存";
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // btnAudit
            // 
            this.btnAudit.Name = "btnAudit";
            this.btnAudit.Size = new System.Drawing.Size(58, 28);
            this.btnAudit.Text = "审核";
            this.btnAudit.Click += new System.EventHandler(this.btnAudit_Click);
            // 
            // btnUnAudit
            // 
            this.btnUnAudit.Name = "btnUnAudit";
            this.btnUnAudit.Size = new System.Drawing.Size(58, 28);
            this.btnUnAudit.Text = "弃审";
            this.btnUnAudit.Click += new System.EventHandler(this.btnUnAudit_Click);
            // 
            // labelControl1
            // 
            this.labelControl1.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.labelControl1.Appearance.Font = new System.Drawing.Font("Tahoma", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelControl1.Location = new System.Drawing.Point(481, 20);
            this.labelControl1.Margin = new System.Windows.Forms.Padding(4);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(100, 30);
            this.labelControl1.TabIndex = 190;
            this.labelControl1.Text = "能源分配";
            // 
            // gridControl1
            // 
            this.gridControl1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.gridControl1.EmbeddedNavigator.Margin = new System.Windows.Forms.Padding(4);
            this.gridControl1.Location = new System.Drawing.Point(7, 85);
            this.gridControl1.LookAndFeel.SkinName = "Office 2010 Blue";
            this.gridControl1.MainView = this.gridView1;
            this.gridControl1.Margin = new System.Windows.Forms.Padding(4);
            this.gridControl1.Name = "gridControl1";
            this.gridControl1.Size = new System.Drawing.Size(1046, 370);
            this.gridControl1.TabIndex = 191;
            this.gridControl1.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView1});
            // 
            // gridView1
            // 
            this.gridView1.Bands.AddRange(new DevExpress.XtraGrid.Views.BandedGrid.GridBand[] {
            this.gridBand1,
            this.gridBand2,
            this.gridBand3,
            this.gridBand4,
            this.gridBand5,
            this.gridBand6});
            this.gridView1.Columns.AddRange(new DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn[] {
            this.gridCol部门编码,
            this.gridCol部门,
            this.gridCol制单人,
            this.gridCol制单日期,
            this.gridCol审核人,
            this.gridCol审核日期,
            this.gridCol修改人,
            this.gridCol修改日期,
            this.gridCol记账人,
            this.gridCol记账日期,
            this.gridCol供水分配率,
            this.gridCol供水金额,
            this.gridCol供电分配率,
            this.gridCol供电金额,
            this.gridCol供汽分配率,
            this.gridCol供汽金额,
            this.gridCol开利机组冷水机组分配率,
            this.gridCol开利机组冷水机组金额,
            this.gridCol合计});
            this.gridView1.GridControl = this.gridControl1;
            this.gridView1.IndicatorWidth = 40;
            this.gridView1.Name = "gridView1";
            this.gridView1.OptionsBehavior.AllowDeleteRows = DevExpress.Utils.DefaultBoolean.True;
            this.gridView1.OptionsBehavior.EditorShowMode = DevExpress.Utils.EditorShowMode.MouseDown;
            this.gridView1.OptionsCustomization.AllowGroup = false;
            this.gridView1.OptionsCustomization.AllowQuickHideColumns = false;
            this.gridView1.OptionsNavigation.EnterMoveNextColumn = true;
            this.gridView1.OptionsView.ColumnAutoWidth = false;
            this.gridView1.OptionsView.ShowFooter = true;
            this.gridView1.OptionsView.ShowGroupPanel = false;
            this.gridView1.CustomDrawRowIndicator += new DevExpress.XtraGrid.Views.Grid.RowIndicatorCustomDrawEventHandler(this.gridView1_CustomDrawRowIndicator);
            this.gridView1.CellValueChanged += new DevExpress.XtraGrid.Views.Base.CellValueChangedEventHandler(this.gridView1_CellValueChanged);
            // 
            // gridBand1
            // 
            this.gridBand1.Columns.Add(this.gridCol部门编码);
            this.gridBand1.Columns.Add(this.gridCol部门);
            this.gridBand1.Columns.Add(this.gridCol制单人);
            this.gridBand1.Columns.Add(this.gridCol制单日期);
            this.gridBand1.Columns.Add(this.gridCol审核人);
            this.gridBand1.Columns.Add(this.gridCol审核日期);
            this.gridBand1.Columns.Add(this.gridCol修改人);
            this.gridBand1.Columns.Add(this.gridCol修改日期);
            this.gridBand1.Columns.Add(this.gridCol记账人);
            this.gridBand1.Columns.Add(this.gridCol记账日期);
            this.gridBand1.Fixed = DevExpress.XtraGrid.Columns.FixedStyle.Left;
            this.gridBand1.Name = "gridBand1";
            this.gridBand1.Width = 250;
            // 
            // gridCol部门编码
            // 
            this.gridCol部门编码.AppearanceHeader.Options.UseTextOptions = true;
            this.gridCol部门编码.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gridCol部门编码.Caption = "部门编码";
            this.gridCol部门编码.FieldName = "cDepCode";
            this.gridCol部门编码.Name = "gridCol部门编码";
            this.gridCol部门编码.OptionsColumn.AllowEdit = false;
            this.gridCol部门编码.OptionsColumn.AllowSort = DevExpress.Utils.DefaultBoolean.False;
            this.gridCol部门编码.OptionsFilter.AllowFilter = false;
            this.gridCol部门编码.Visible = true;
            this.gridCol部门编码.Width = 83;
            // 
            // gridCol部门
            // 
            this.gridCol部门.AppearanceHeader.Options.UseTextOptions = true;
            this.gridCol部门.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gridCol部门.Caption = "部门";
            this.gridCol部门.FieldName = "部门";
            this.gridCol部门.Name = "gridCol部门";
            this.gridCol部门.OptionsColumn.AllowEdit = false;
            this.gridCol部门.OptionsColumn.AllowSort = DevExpress.Utils.DefaultBoolean.False;
            this.gridCol部门.OptionsFilter.AllowFilter = false;
            this.gridCol部门.Visible = true;
            this.gridCol部门.Width = 167;
            // 
            // gridCol制单人
            // 
            this.gridCol制单人.AppearanceHeader.Options.UseTextOptions = true;
            this.gridCol制单人.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gridCol制单人.Caption = "制单人";
            this.gridCol制单人.FieldName = "制单人";
            this.gridCol制单人.Name = "gridCol制单人";
            this.gridCol制单人.OptionsColumn.AllowEdit = false;
            this.gridCol制单人.OptionsColumn.AllowSort = DevExpress.Utils.DefaultBoolean.False;
            this.gridCol制单人.OptionsFilter.AllowFilter = false;
            // 
            // gridCol制单日期
            // 
            this.gridCol制单日期.AppearanceHeader.Options.UseTextOptions = true;
            this.gridCol制单日期.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gridCol制单日期.Caption = "制单日期";
            this.gridCol制单日期.FieldName = "制单日期";
            this.gridCol制单日期.Name = "gridCol制单日期";
            this.gridCol制单日期.OptionsColumn.AllowEdit = false;
            this.gridCol制单日期.OptionsColumn.AllowSort = DevExpress.Utils.DefaultBoolean.False;
            this.gridCol制单日期.OptionsFilter.AllowFilter = false;
            // 
            // gridCol审核人
            // 
            this.gridCol审核人.AppearanceHeader.Options.UseTextOptions = true;
            this.gridCol审核人.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gridCol审核人.Caption = "审核人";
            this.gridCol审核人.FieldName = "审核人";
            this.gridCol审核人.Name = "gridCol审核人";
            this.gridCol审核人.OptionsColumn.AllowEdit = false;
            this.gridCol审核人.OptionsColumn.AllowSort = DevExpress.Utils.DefaultBoolean.False;
            this.gridCol审核人.OptionsFilter.AllowFilter = false;
            // 
            // gridCol审核日期
            // 
            this.gridCol审核日期.AppearanceHeader.Options.UseTextOptions = true;
            this.gridCol审核日期.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gridCol审核日期.Caption = "审核日期";
            this.gridCol审核日期.FieldName = "审核日期";
            this.gridCol审核日期.Name = "gridCol审核日期";
            this.gridCol审核日期.OptionsColumn.AllowEdit = false;
            this.gridCol审核日期.OptionsColumn.AllowSort = DevExpress.Utils.DefaultBoolean.False;
            this.gridCol审核日期.OptionsFilter.AllowFilter = false;
            // 
            // gridCol修改人
            // 
            this.gridCol修改人.AppearanceHeader.Options.UseTextOptions = true;
            this.gridCol修改人.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gridCol修改人.Caption = "修改人";
            this.gridCol修改人.FieldName = "修改人";
            this.gridCol修改人.Name = "gridCol修改人";
            this.gridCol修改人.OptionsColumn.AllowEdit = false;
            this.gridCol修改人.OptionsColumn.AllowSort = DevExpress.Utils.DefaultBoolean.False;
            this.gridCol修改人.OptionsFilter.AllowFilter = false;
            // 
            // gridCol修改日期
            // 
            this.gridCol修改日期.AppearanceHeader.Options.UseTextOptions = true;
            this.gridCol修改日期.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gridCol修改日期.Caption = "修改日期";
            this.gridCol修改日期.FieldName = "修改日期";
            this.gridCol修改日期.Name = "gridCol修改日期";
            this.gridCol修改日期.OptionsColumn.AllowEdit = false;
            this.gridCol修改日期.OptionsColumn.AllowSort = DevExpress.Utils.DefaultBoolean.False;
            this.gridCol修改日期.OptionsFilter.AllowFilter = false;
            // 
            // gridCol记账人
            // 
            this.gridCol记账人.AppearanceHeader.Options.UseTextOptions = true;
            this.gridCol记账人.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gridCol记账人.Caption = "记账人";
            this.gridCol记账人.FieldName = "记账人";
            this.gridCol记账人.Name = "gridCol记账人";
            this.gridCol记账人.OptionsColumn.AllowEdit = false;
            this.gridCol记账人.OptionsColumn.AllowSort = DevExpress.Utils.DefaultBoolean.False;
            this.gridCol记账人.OptionsFilter.AllowFilter = false;
            // 
            // gridCol记账日期
            // 
            this.gridCol记账日期.AppearanceHeader.Options.UseTextOptions = true;
            this.gridCol记账日期.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gridCol记账日期.Caption = "记账日期";
            this.gridCol记账日期.FieldName = "记账日期";
            this.gridCol记账日期.Name = "gridCol记账日期";
            this.gridCol记账日期.OptionsColumn.AllowEdit = false;
            this.gridCol记账日期.OptionsColumn.AllowSort = DevExpress.Utils.DefaultBoolean.False;
            this.gridCol记账日期.OptionsFilter.AllowFilter = false;
            // 
            // gridBand2
            // 
            this.gridBand2.AppearanceHeader.Options.UseTextOptions = true;
            this.gridBand2.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gridBand2.Caption = "供水";
            this.gridBand2.Columns.Add(this.gridCol供水分配率);
            this.gridBand2.Columns.Add(this.gridCol供水金额);
            this.gridBand2.Name = "gridBand2";
            this.gridBand2.Width = 191;
            // 
            // gridCol供水分配率
            // 
            this.gridCol供水分配率.AppearanceHeader.Options.UseTextOptions = true;
            this.gridCol供水分配率.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gridCol供水分配率.Caption = "分配率";
            this.gridCol供水分配率.FieldName = "供水分配率";
            this.gridCol供水分配率.Name = "gridCol供水分配率";
            this.gridCol供水分配率.OptionsColumn.AllowSort = DevExpress.Utils.DefaultBoolean.False;
            this.gridCol供水分配率.OptionsFilter.AllowFilter = false;
            this.gridCol供水分配率.Summary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] {
            new DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum)});
            this.gridCol供水分配率.Visible = true;
            this.gridCol供水分配率.Width = 116;
            // 
            // gridCol供水金额
            // 
            this.gridCol供水金额.AppearanceHeader.Options.UseTextOptions = true;
            this.gridCol供水金额.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gridCol供水金额.Caption = "金额";
            this.gridCol供水金额.FieldName = "供水金额";
            this.gridCol供水金额.Name = "gridCol供水金额";
            this.gridCol供水金额.OptionsColumn.AllowSort = DevExpress.Utils.DefaultBoolean.False;
            this.gridCol供水金额.OptionsFilter.AllowFilter = false;
            this.gridCol供水金额.Summary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] {
            new DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum)});
            this.gridCol供水金额.Visible = true;
            // 
            // gridBand3
            // 
            this.gridBand3.AppearanceHeader.Options.UseTextOptions = true;
            this.gridBand3.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gridBand3.Caption = "供电";
            this.gridBand3.Columns.Add(this.gridCol供电分配率);
            this.gridBand3.Columns.Add(this.gridCol供电金额);
            this.gridBand3.Name = "gridBand3";
            this.gridBand3.Width = 150;
            // 
            // gridCol供电分配率
            // 
            this.gridCol供电分配率.AppearanceHeader.Options.UseTextOptions = true;
            this.gridCol供电分配率.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gridCol供电分配率.Caption = "分配率";
            this.gridCol供电分配率.FieldName = "供电分配率";
            this.gridCol供电分配率.Name = "gridCol供电分配率";
            this.gridCol供电分配率.OptionsColumn.AllowSort = DevExpress.Utils.DefaultBoolean.False;
            this.gridCol供电分配率.OptionsFilter.AllowFilter = false;
            this.gridCol供电分配率.Summary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] {
            new DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum)});
            this.gridCol供电分配率.Visible = true;
            // 
            // gridCol供电金额
            // 
            this.gridCol供电金额.AppearanceHeader.Options.UseTextOptions = true;
            this.gridCol供电金额.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gridCol供电金额.Caption = "金额";
            this.gridCol供电金额.FieldName = "供电金额";
            this.gridCol供电金额.Name = "gridCol供电金额";
            this.gridCol供电金额.OptionsColumn.AllowSort = DevExpress.Utils.DefaultBoolean.False;
            this.gridCol供电金额.OptionsFilter.AllowFilter = false;
            this.gridCol供电金额.Summary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] {
            new DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum)});
            this.gridCol供电金额.Visible = true;
            // 
            // gridBand4
            // 
            this.gridBand4.AppearanceHeader.Options.UseTextOptions = true;
            this.gridBand4.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gridBand4.Caption = "供汽";
            this.gridBand4.Columns.Add(this.gridCol供汽分配率);
            this.gridBand4.Columns.Add(this.gridCol供汽金额);
            this.gridBand4.Name = "gridBand4";
            this.gridBand4.Width = 150;
            // 
            // gridCol供汽分配率
            // 
            this.gridCol供汽分配率.AppearanceHeader.Options.UseTextOptions = true;
            this.gridCol供汽分配率.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gridCol供汽分配率.Caption = "分配率";
            this.gridCol供汽分配率.FieldName = "供汽分配率";
            this.gridCol供汽分配率.Name = "gridCol供汽分配率";
            this.gridCol供汽分配率.OptionsColumn.AllowSort = DevExpress.Utils.DefaultBoolean.False;
            this.gridCol供汽分配率.OptionsFilter.AllowFilter = false;
            this.gridCol供汽分配率.Summary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] {
            new DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum)});
            this.gridCol供汽分配率.Visible = true;
            // 
            // gridCol供汽金额
            // 
            this.gridCol供汽金额.AppearanceHeader.Options.UseTextOptions = true;
            this.gridCol供汽金额.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gridCol供汽金额.Caption = "金额";
            this.gridCol供汽金额.FieldName = "供汽金额";
            this.gridCol供汽金额.Name = "gridCol供汽金额";
            this.gridCol供汽金额.OptionsColumn.AllowSort = DevExpress.Utils.DefaultBoolean.False;
            this.gridCol供汽金额.OptionsFilter.AllowFilter = false;
            this.gridCol供汽金额.Summary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] {
            new DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum)});
            this.gridCol供汽金额.Visible = true;
            // 
            // gridBand5
            // 
            this.gridBand5.AppearanceHeader.Options.UseTextOptions = true;
            this.gridBand5.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gridBand5.Caption = "开利机组冷水机组";
            this.gridBand5.Columns.Add(this.gridCol开利机组冷水机组分配率);
            this.gridBand5.Columns.Add(this.gridCol开利机组冷水机组金额);
            this.gridBand5.Name = "gridBand5";
            this.gridBand5.Width = 246;
            // 
            // gridCol开利机组冷水机组分配率
            // 
            this.gridCol开利机组冷水机组分配率.AppearanceHeader.Options.UseTextOptions = true;
            this.gridCol开利机组冷水机组分配率.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gridCol开利机组冷水机组分配率.Caption = "分配率";
            this.gridCol开利机组冷水机组分配率.FieldName = "开利机组冷水机组分配率";
            this.gridCol开利机组冷水机组分配率.Name = "gridCol开利机组冷水机组分配率";
            this.gridCol开利机组冷水机组分配率.OptionsColumn.AllowSort = DevExpress.Utils.DefaultBoolean.False;
            this.gridCol开利机组冷水机组分配率.OptionsFilter.AllowFilter = false;
            this.gridCol开利机组冷水机组分配率.Summary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] {
            new DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum)});
            this.gridCol开利机组冷水机组分配率.Visible = true;
            this.gridCol开利机组冷水机组分配率.Width = 123;
            // 
            // gridCol开利机组冷水机组金额
            // 
            this.gridCol开利机组冷水机组金额.AppearanceHeader.Options.UseTextOptions = true;
            this.gridCol开利机组冷水机组金额.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gridCol开利机组冷水机组金额.Caption = "金额";
            this.gridCol开利机组冷水机组金额.FieldName = "开利机组冷水机组金额";
            this.gridCol开利机组冷水机组金额.Name = "gridCol开利机组冷水机组金额";
            this.gridCol开利机组冷水机组金额.OptionsColumn.AllowSort = DevExpress.Utils.DefaultBoolean.False;
            this.gridCol开利机组冷水机组金额.OptionsFilter.AllowFilter = false;
            this.gridCol开利机组冷水机组金额.Summary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] {
            new DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum)});
            this.gridCol开利机组冷水机组金额.Visible = true;
            this.gridCol开利机组冷水机组金额.Width = 123;
            // 
            // gridBand6
            // 
            this.gridBand6.AppearanceHeader.Options.UseTextOptions = true;
            this.gridBand6.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gridBand6.Caption = "合计";
            this.gridBand6.Columns.Add(this.gridCol合计);
            this.gridBand6.Name = "gridBand6";
            this.gridBand6.Width = 75;
            // 
            // gridCol合计
            // 
            this.gridCol合计.AppearanceHeader.Options.UseTextOptions = true;
            this.gridCol合计.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gridCol合计.Caption = "（元）";
            this.gridCol合计.FieldName = "合计";
            this.gridCol合计.Name = "gridCol合计";
            this.gridCol合计.OptionsColumn.AllowSort = DevExpress.Utils.DefaultBoolean.False;
            this.gridCol合计.OptionsFilter.AllowFilter = false;
            this.gridCol合计.Summary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] {
            new DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum)});
            this.gridCol合计.Visible = true;
            // 
            // panel1
            // 
            this.panel1.AutoScroll = true;
            this.panel1.Controls.Add(this.lAudit);
            this.panel1.Controls.Add(this.txt开利机组冷水机组);
            this.panel1.Controls.Add(this.txt供水);
            this.panel1.Controls.Add(this.txt供电);
            this.panel1.Controls.Add(this.txt供汽);
            this.panel1.Controls.Add(this.label4);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.label12);
            this.panel1.Controls.Add(this.lookUpEdit会计期间);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.gridControl1);
            this.panel1.Controls.Add(this.labelControl1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 32);
            this.panel1.Margin = new System.Windows.Forms.Padding(4);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1054, 455);
            this.panel1.TabIndex = 173;
            // 
            // lAudit
            // 
            this.lAudit.AutoSize = true;
            this.lAudit.Location = new System.Drawing.Point(954, 60);
            this.lAudit.Name = "lAudit";
            this.lAudit.Size = new System.Drawing.Size(55, 15);
            this.lAudit.TabIndex = 240;
            this.lAudit.Text = "label6";
            // 
            // txt开利机组冷水机组
            // 
            this.txt开利机组冷水机组.Location = new System.Drawing.Point(843, 55);
            this.txt开利机组冷水机组.Margin = new System.Windows.Forms.Padding(4);
            this.txt开利机组冷水机组.Name = "txt开利机组冷水机组";
            this.txt开利机组冷水机组.Properties.DisplayFormat.FormatString = "n2";
            this.txt开利机组冷水机组.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.txt开利机组冷水机组.Properties.EditFormat.FormatString = "n2";
            this.txt开利机组冷水机组.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.txt开利机组冷水机组.Properties.Mask.EditMask = "n2";
            this.txt开利机组冷水机组.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Numeric;
            this.txt开利机组冷水机组.Size = new System.Drawing.Size(105, 24);
            this.txt开利机组冷水机组.TabIndex = 239;
            // 
            // txt供水
            // 
            this.txt供水.Location = new System.Drawing.Point(306, 55);
            this.txt供水.Margin = new System.Windows.Forms.Padding(4);
            this.txt供水.Name = "txt供水";
            this.txt供水.Properties.DisplayFormat.FormatString = "n2";
            this.txt供水.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.txt供水.Properties.EditFormat.FormatString = "n2";
            this.txt供水.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.txt供水.Properties.Mask.EditMask = "n2";
            this.txt供水.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Numeric;
            this.txt供水.Size = new System.Drawing.Size(105, 24);
            this.txt供水.TabIndex = 238;
            // 
            // txt供电
            // 
            this.txt供电.Location = new System.Drawing.Point(467, 57);
            this.txt供电.Margin = new System.Windows.Forms.Padding(4);
            this.txt供电.Name = "txt供电";
            this.txt供电.Properties.DisplayFormat.FormatString = "n2";
            this.txt供电.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.txt供电.Properties.EditFormat.FormatString = "n2";
            this.txt供电.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.txt供电.Properties.Mask.EditMask = "n2";
            this.txt供电.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Numeric;
            this.txt供电.Size = new System.Drawing.Size(105, 24);
            this.txt供电.TabIndex = 237;
            // 
            // txt供汽
            // 
            this.txt供汽.Location = new System.Drawing.Point(612, 55);
            this.txt供汽.Margin = new System.Windows.Forms.Padding(4);
            this.txt供汽.Name = "txt供汽";
            this.txt供汽.Properties.DisplayFormat.FormatString = "n2";
            this.txt供汽.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.txt供汽.Properties.EditFormat.FormatString = "n2";
            this.txt供汽.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.txt供汽.Properties.Mask.EditMask = "n2";
            this.txt供汽.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Numeric;
            this.txt供汽.Size = new System.Drawing.Size(105, 24);
            this.txt供汽.TabIndex = 236;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.ForeColor = System.Drawing.Color.Blue;
            this.label4.Location = new System.Drawing.Point(724, 60);
            this.label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(127, 15);
            this.label4.TabIndex = 232;
            this.label4.Text = "开利机组冷水机组";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.ForeColor = System.Drawing.Color.Blue;
            this.label2.Location = new System.Drawing.Point(571, 60);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(37, 15);
            this.label2.TabIndex = 230;
            this.label2.Text = "供汽";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.ForeColor = System.Drawing.Color.Blue;
            this.label1.Location = new System.Drawing.Point(418, 60);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(37, 15);
            this.label1.TabIndex = 228;
            this.label1.Text = "供电";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.ForeColor = System.Drawing.Color.Blue;
            this.label12.Location = new System.Drawing.Point(255, 60);
            this.label12.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(37, 15);
            this.label12.TabIndex = 226;
            this.label12.Text = "供水";
            this.label12.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lookUpEdit会计期间
            // 
            this.lookUpEdit会计期间.AllowHtmlTextInToolTip = DevExpress.Utils.DefaultBoolean.True;
            this.lookUpEdit会计期间.Location = new System.Drawing.Point(81, 55);
            this.lookUpEdit会计期间.Margin = new System.Windows.Forms.Padding(4);
            this.lookUpEdit会计期间.Name = "lookUpEdit会计期间";
            this.lookUpEdit会计期间.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.lookUpEdit会计期间.Properties.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("会计期间", "会计期间")});
            this.lookUpEdit会计期间.Properties.DisplayMember = "会计期间";
            this.lookUpEdit会计期间.Properties.NullText = "";
            this.lookUpEdit会计期间.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.Standard;
            this.lookUpEdit会计期间.Properties.ValueMember = "会计期间";
            this.lookUpEdit会计期间.Size = new System.Drawing.Size(141, 24);
            this.lookUpEdit会计期间.TabIndex = 195;
            this.lookUpEdit会计期间.EditValueChanged += new System.EventHandler(this.lookUpEdit会计期间_EditValueChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.ForeColor = System.Drawing.Color.Blue;
            this.label3.Location = new System.Drawing.Point(13, 60);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(67, 15);
            this.label3.TabIndex = 194;
            this.label3.Text = "会计期间";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // btnExcel
            // 
            this.btnExcel.Name = "btnExcel";
            this.btnExcel.Size = new System.Drawing.Size(58, 28);
            this.btnExcel.Text = "导出";
            this.btnExcel.Click += new System.EventHandler(this.btnExcel_Click);
            // 
            // 能源分配
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.menuStrip1);
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "能源分配";
            this.Size = new System.Drawing.Size(1054, 487);
            this.Load += new System.EventHandler(this.Frm_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txt开利机组冷水机组.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txt供水.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txt供电.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txt供汽.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lookUpEdit会计期间.Properties)).EndInit();
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
        private DevExpress.XtraEditors.LookUpEdit lookUpEdit会计期间;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ToolStripMenuItem btnAudit;
        private System.Windows.Forms.ToolStripMenuItem btnUnAudit;
        private DevExpress.XtraGrid.Views.BandedGrid.BandedGridView gridView1;
        private DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn gridCol部门编码;
        private DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn gridCol部门;
        private DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn gridCol制单人;
        private DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn gridCol制单日期;
        private DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn gridCol审核人;
        private DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn gridCol审核日期;
        private DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn gridCol修改人;
        private DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn gridCol修改日期;
        private DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn gridCol记账人;
        private DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn gridCol记账日期;
        private DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn gridCol供水分配率;
        private DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn gridCol供水金额;
        private DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn gridCol供电分配率;
        private DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn gridCol供电金额;
        private DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn gridCol供汽分配率;
        private DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn gridCol供汽金额;
        private DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn gridCol开利机组冷水机组分配率;
        private DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn gridCol开利机组冷水机组金额;
        private DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn gridCol合计;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.ToolStripMenuItem btn计算;
        private System.Windows.Forms.ToolStripMenuItem btn刷新;
        private DevExpress.XtraEditors.TextEdit txt供汽;
        private DevExpress.XtraEditors.TextEdit txt供水;
        private DevExpress.XtraEditors.TextEdit txt供电;
        private DevExpress.XtraEditors.TextEdit txt开利机组冷水机组;
        private DevExpress.XtraGrid.Views.BandedGrid.GridBand gridBand1;
        private DevExpress.XtraGrid.Views.BandedGrid.GridBand gridBand2;
        private DevExpress.XtraGrid.Views.BandedGrid.GridBand gridBand3;
        private DevExpress.XtraGrid.Views.BandedGrid.GridBand gridBand4;
        private DevExpress.XtraGrid.Views.BandedGrid.GridBand gridBand5;
        private DevExpress.XtraGrid.Views.BandedGrid.GridBand gridBand6;
        private System.Windows.Forms.Label lAudit;
        private System.Windows.Forms.ToolStripMenuItem btnExcel;
    }
}
