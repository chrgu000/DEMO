namespace UFIDA.U8.UAP.CustomApp.ControlForm
{
    partial class GL_accvouch
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
            this.ItemTextEditn2 = new DevExpress.XtraEditors.Repository.RepositoryItemTextEdit();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.btnLoad = new System.Windows.Forms.ToolStripMenuItem();
            this.btnSave = new System.Windows.Forms.ToolStripMenuItem();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label3 = new System.Windows.Forms.Label();
            this.txtMonth = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtYear = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.txtXZDTableName = new System.Windows.Forms.TextBox();
            this.gridControl1 = new DevExpress.XtraGrid.GridControl();
            this.gridView1 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.gridCol选择 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridCol凭证类别 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridCol凭证号 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridCol行号 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridCol摘要 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridCol会计科目 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridCol借方 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridCol贷方 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridCol外币借方 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridCol外币贷方 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridCol币种 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridCol汇率 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridCol部门编码 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.ItemLookUpEditcDepCode = new DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit();
            this.gridCol部门名称 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.ItemLookUpEditcDepName = new DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit();
            this.gridCol客户编码 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.ItemLookUpEditcCusCode = new DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit();
            this.gridCol客户名称 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.ItemLookUpEditcCusName = new DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit();
            this.gridCol供应商编码 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.ItemLookUpEditcVenCode = new DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit();
            this.gridCol供应商名称 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.ItemLookUpEditcVenName = new DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit();
            this.gridCol制单人 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridCol制单日期 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridCol年度 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridCol期间 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridCol科目名称 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridCol客户核算 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridCol供应商核算 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridCol部门核算 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridCol项目核算 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridCol个人核算 = new DevExpress.XtraGrid.Columns.GridColumn();
            ((System.ComponentModel.ISupportInitialize)(this.ItemTextEditn2)).BeginInit();
            this.menuStrip1.SuspendLayout();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ItemLookUpEditcDepCode)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ItemLookUpEditcDepName)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ItemLookUpEditcCusCode)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ItemLookUpEditcCusName)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ItemLookUpEditcVenCode)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ItemLookUpEditcVenName)).BeginInit();
            this.SuspendLayout();
            // 
            // ItemTextEditn2
            // 
            this.ItemTextEditn2.AutoHeight = false;
            this.ItemTextEditn2.DisplayFormat.FormatString = "n2";
            this.ItemTextEditn2.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.ItemTextEditn2.EditFormat.FormatString = "n2";
            this.ItemTextEditn2.EditFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.ItemTextEditn2.Mask.EditMask = "n2";
            this.ItemTextEditn2.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Numeric;
            this.ItemTextEditn2.Name = "ItemTextEditn2";
            // 
            // menuStrip1
            // 
            this.menuStrip1.AllowDrop = true;
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btnLoad,
            this.btnSave});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(1031, 33);
            this.menuStrip1.TabIndex = 172;
            this.menuStrip1.Text = "menuStrip";
            // 
            // btnLoad
            // 
            this.btnLoad.Name = "btnLoad";
            this.btnLoad.Size = new System.Drawing.Size(62, 29);
            this.btnLoad.Text = "加载";
            this.btnLoad.Click += new System.EventHandler(this.btnLoad_Click);
            // 
            // btnSave
            // 
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(62, 29);
            this.btnSave.Text = "保存";
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // panel1
            // 
            this.panel1.AutoScroll = true;
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.txtMonth);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.txtYear);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.txtXZDTableName);
            this.panel1.Controls.Add(this.gridControl1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 33);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1031, 362);
            this.panel1.TabIndex = 173;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(294, 17);
            this.label3.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(37, 15);
            this.label3.TabIndex = 198;
            this.label3.Text = "月份";
            // 
            // txtMonth
            // 
            this.txtMonth.Location = new System.Drawing.Point(346, 14);
            this.txtMonth.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.txtMonth.Name = "txtMonth";
            this.txtMonth.Size = new System.Drawing.Size(35, 21);
            this.txtMonth.TabIndex = 197;
            this.txtMonth.Text = "01";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(185, 17);
            this.label2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(37, 15);
            this.label2.TabIndex = 196;
            this.label2.Text = "年度";
            // 
            // txtYear
            // 
            this.txtYear.Location = new System.Drawing.Point(226, 14);
            this.txtYear.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.txtYear.Name = "txtYear";
            this.txtYear.Size = new System.Drawing.Size(54, 21);
            this.txtYear.TabIndex = 195;
            this.txtYear.Text = "2016";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(30, 18);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(82, 15);
            this.label1.TabIndex = 194;
            this.label1.Text = "新中大表名";
            // 
            // txtXZDTableName
            // 
            this.txtXZDTableName.Location = new System.Drawing.Point(116, 14);
            this.txtXZDTableName.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.txtXZDTableName.Name = "txtXZDTableName";
            this.txtXZDTableName.Size = new System.Drawing.Size(53, 21);
            this.txtXZDTableName.TabIndex = 193;
            this.txtXZDTableName.Text = "Z-PZ";
            // 
            // gridControl1
            // 
            this.gridControl1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.gridControl1.Location = new System.Drawing.Point(3, 51);
            this.gridControl1.LookAndFeel.SkinName = "Office 2010 Blue";
            this.gridControl1.MainView = this.gridView1;
            this.gridControl1.Name = "gridControl1";
            this.gridControl1.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.ItemLookUpEditcDepCode,
            this.ItemLookUpEditcDepName,
            this.ItemLookUpEditcVenCode,
            this.ItemLookUpEditcVenName,
            this.ItemLookUpEditcCusCode,
            this.ItemLookUpEditcCusName});
            this.gridControl1.Size = new System.Drawing.Size(1025, 307);
            this.gridControl1.TabIndex = 192;
            this.gridControl1.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView1});
            // 
            // gridView1
            // 
            this.gridView1.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.gridCol选择,
            this.gridCol凭证类别,
            this.gridCol凭证号,
            this.gridCol行号,
            this.gridCol摘要,
            this.gridCol会计科目,
            this.gridCol借方,
            this.gridCol贷方,
            this.gridCol外币借方,
            this.gridCol外币贷方,
            this.gridCol币种,
            this.gridCol汇率,
            this.gridCol部门编码,
            this.gridCol部门名称,
            this.gridCol客户编码,
            this.gridCol客户名称,
            this.gridCol供应商编码,
            this.gridCol供应商名称,
            this.gridCol制单人,
            this.gridCol制单日期,
            this.gridCol年度,
            this.gridCol期间,
            this.gridCol科目名称,
            this.gridCol客户核算,
            this.gridCol供应商核算,
            this.gridCol部门核算,
            this.gridCol项目核算,
            this.gridCol个人核算});
            this.gridView1.GridControl = this.gridControl1;
            this.gridView1.IndicatorWidth = 40;
            this.gridView1.Name = "gridView1";
            this.gridView1.OptionsBehavior.AllowDeleteRows = DevExpress.Utils.DefaultBoolean.True;
            this.gridView1.OptionsBehavior.EditorShowMode = DevExpress.Utils.EditorShowMode.MouseDown;
            this.gridView1.OptionsCustomization.AllowGroup = false;
            this.gridView1.OptionsCustomization.AllowQuickHideColumns = false;
            this.gridView1.OptionsCustomization.AllowSort = false;
            this.gridView1.OptionsNavigation.EnterMoveNextColumn = true;
            this.gridView1.OptionsPrint.AutoWidth = false;
            this.gridView1.OptionsView.ColumnAutoWidth = false;
            this.gridView1.OptionsView.ShowFooter = true;
            this.gridView1.OptionsView.ShowGroupPanel = false;
            this.gridView1.CustomDrawRowIndicator += new DevExpress.XtraGrid.Views.Grid.RowIndicatorCustomDrawEventHandler(this.gridView1_CustomDrawRowIndicator);
            // 
            // gridCol选择
            // 
            this.gridCol选择.Caption = "选择";
            this.gridCol选择.FieldName = "选择";
            this.gridCol选择.Name = "gridCol选择";
            this.gridCol选择.OptionsColumn.AllowEdit = false;
            this.gridCol选择.OptionsColumn.AllowMerge = DevExpress.Utils.DefaultBoolean.True;
            this.gridCol选择.Visible = true;
            this.gridCol选择.VisibleIndex = 0;
            this.gridCol选择.Width = 35;
            // 
            // gridCol凭证类别
            // 
            this.gridCol凭证类别.Caption = "凭证类别";
            this.gridCol凭证类别.FieldName = "凭证类别";
            this.gridCol凭证类别.Name = "gridCol凭证类别";
            this.gridCol凭证类别.OptionsColumn.AllowEdit = false;
            this.gridCol凭证类别.OptionsColumn.AllowMerge = DevExpress.Utils.DefaultBoolean.True;
            this.gridCol凭证类别.Visible = true;
            this.gridCol凭证类别.VisibleIndex = 1;
            // 
            // gridCol凭证号
            // 
            this.gridCol凭证号.Caption = "凭证号";
            this.gridCol凭证号.FieldName = "凭证号";
            this.gridCol凭证号.Name = "gridCol凭证号";
            this.gridCol凭证号.OptionsColumn.AllowEdit = false;
            this.gridCol凭证号.OptionsColumn.AllowMerge = DevExpress.Utils.DefaultBoolean.True;
            this.gridCol凭证号.Visible = true;
            this.gridCol凭证号.VisibleIndex = 2;
            this.gridCol凭证号.Width = 67;
            // 
            // gridCol行号
            // 
            this.gridCol行号.Caption = "行号";
            this.gridCol行号.FieldName = "行号";
            this.gridCol行号.Name = "gridCol行号";
            this.gridCol行号.OptionsColumn.AllowEdit = false;
            this.gridCol行号.Visible = true;
            this.gridCol行号.VisibleIndex = 3;
            this.gridCol行号.Width = 46;
            // 
            // gridCol摘要
            // 
            this.gridCol摘要.Caption = "摘要";
            this.gridCol摘要.FieldName = "摘要";
            this.gridCol摘要.Name = "gridCol摘要";
            this.gridCol摘要.OptionsColumn.AllowEdit = false;
            this.gridCol摘要.OptionsColumn.AllowMerge = DevExpress.Utils.DefaultBoolean.False;
            this.gridCol摘要.Visible = true;
            this.gridCol摘要.VisibleIndex = 4;
            this.gridCol摘要.Width = 86;
            // 
            // gridCol会计科目
            // 
            this.gridCol会计科目.Caption = "会计科目";
            this.gridCol会计科目.FieldName = "会计科目";
            this.gridCol会计科目.Name = "gridCol会计科目";
            this.gridCol会计科目.OptionsColumn.AllowEdit = false;
            this.gridCol会计科目.OptionsColumn.AllowMerge = DevExpress.Utils.DefaultBoolean.False;
            this.gridCol会计科目.Visible = true;
            this.gridCol会计科目.VisibleIndex = 5;
            this.gridCol会计科目.Width = 81;
            // 
            // gridCol借方
            // 
            this.gridCol借方.Caption = "借方";
            this.gridCol借方.ColumnEdit = this.ItemTextEditn2;
            this.gridCol借方.FieldName = "借方";
            this.gridCol借方.Name = "gridCol借方";
            this.gridCol借方.OptionsColumn.AllowEdit = false;
            this.gridCol借方.OptionsColumn.AllowMerge = DevExpress.Utils.DefaultBoolean.False;
            this.gridCol借方.Summary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] {
            new DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum)});
            this.gridCol借方.Visible = true;
            this.gridCol借方.VisibleIndex = 7;
            this.gridCol借方.Width = 67;
            // 
            // gridCol贷方
            // 
            this.gridCol贷方.Caption = "贷方";
            this.gridCol贷方.ColumnEdit = this.ItemTextEditn2;
            this.gridCol贷方.FieldName = "贷方";
            this.gridCol贷方.Name = "gridCol贷方";
            this.gridCol贷方.OptionsColumn.AllowEdit = false;
            this.gridCol贷方.OptionsColumn.AllowMerge = DevExpress.Utils.DefaultBoolean.False;
            this.gridCol贷方.Summary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] {
            new DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum)});
            this.gridCol贷方.Visible = true;
            this.gridCol贷方.VisibleIndex = 8;
            this.gridCol贷方.Width = 49;
            // 
            // gridCol外币借方
            // 
            this.gridCol外币借方.Caption = "外币借方";
            this.gridCol外币借方.ColumnEdit = this.ItemTextEditn2;
            this.gridCol外币借方.FieldName = "外币借方";
            this.gridCol外币借方.Name = "gridCol外币借方";
            this.gridCol外币借方.OptionsColumn.AllowEdit = false;
            this.gridCol外币借方.OptionsColumn.AllowMerge = DevExpress.Utils.DefaultBoolean.False;
            this.gridCol外币借方.Summary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] {
            new DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum)});
            this.gridCol外币借方.Visible = true;
            this.gridCol外币借方.VisibleIndex = 9;
            this.gridCol外币借方.Width = 76;
            // 
            // gridCol外币贷方
            // 
            this.gridCol外币贷方.Caption = "外币贷方";
            this.gridCol外币贷方.ColumnEdit = this.ItemTextEditn2;
            this.gridCol外币贷方.FieldName = "外币贷方";
            this.gridCol外币贷方.Name = "gridCol外币贷方";
            this.gridCol外币贷方.OptionsColumn.AllowEdit = false;
            this.gridCol外币贷方.OptionsColumn.AllowMerge = DevExpress.Utils.DefaultBoolean.False;
            this.gridCol外币贷方.Summary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] {
            new DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum)});
            this.gridCol外币贷方.Visible = true;
            this.gridCol外币贷方.VisibleIndex = 10;
            this.gridCol外币贷方.Width = 79;
            // 
            // gridCol币种
            // 
            this.gridCol币种.Caption = "币种";
            this.gridCol币种.FieldName = "币种";
            this.gridCol币种.Name = "gridCol币种";
            this.gridCol币种.OptionsColumn.AllowMerge = DevExpress.Utils.DefaultBoolean.False;
            this.gridCol币种.Visible = true;
            this.gridCol币种.VisibleIndex = 11;
            this.gridCol币种.Width = 46;
            // 
            // gridCol汇率
            // 
            this.gridCol汇率.Caption = "汇率";
            this.gridCol汇率.FieldName = "汇率";
            this.gridCol汇率.Name = "gridCol汇率";
            this.gridCol汇率.OptionsColumn.AllowMerge = DevExpress.Utils.DefaultBoolean.False;
            this.gridCol汇率.Visible = true;
            this.gridCol汇率.VisibleIndex = 12;
            this.gridCol汇率.Width = 52;
            // 
            // gridCol部门编码
            // 
            this.gridCol部门编码.Caption = "部门编码";
            this.gridCol部门编码.ColumnEdit = this.ItemLookUpEditcDepCode;
            this.gridCol部门编码.FieldName = "部门编码";
            this.gridCol部门编码.Name = "gridCol部门编码";
            this.gridCol部门编码.Visible = true;
            this.gridCol部门编码.VisibleIndex = 13;
            // 
            // ItemLookUpEditcDepCode
            // 
            this.ItemLookUpEditcDepCode.AutoHeight = false;
            this.ItemLookUpEditcDepCode.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.ItemLookUpEditcDepCode.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("cDepCode", "部门编码"),
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("cDepName", 60, "部门名称")});
            this.ItemLookUpEditcDepCode.DisplayMember = "cDepCode";
            this.ItemLookUpEditcDepCode.Name = "ItemLookUpEditcDepCode";
            this.ItemLookUpEditcDepCode.NullText = "";
            this.ItemLookUpEditcDepCode.PopupWidth = 400;
            this.ItemLookUpEditcDepCode.ValueMember = "cDepCode";
            // 
            // gridCol部门名称
            // 
            this.gridCol部门名称.Caption = "部门名称";
            this.gridCol部门名称.ColumnEdit = this.ItemLookUpEditcDepName;
            this.gridCol部门名称.FieldName = "部门编码";
            this.gridCol部门名称.Name = "gridCol部门名称";
            this.gridCol部门名称.OptionsColumn.AllowEdit = false;
            this.gridCol部门名称.OptionsColumn.AllowMerge = DevExpress.Utils.DefaultBoolean.False;
            this.gridCol部门名称.Visible = true;
            this.gridCol部门名称.VisibleIndex = 14;
            // 
            // ItemLookUpEditcDepName
            // 
            this.ItemLookUpEditcDepName.AutoHeight = false;
            this.ItemLookUpEditcDepName.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.ItemLookUpEditcDepName.DisplayMember = "cDepName";
            this.ItemLookUpEditcDepName.Name = "ItemLookUpEditcDepName";
            this.ItemLookUpEditcDepName.NullText = "";
            this.ItemLookUpEditcDepName.PopupWidth = 400;
            this.ItemLookUpEditcDepName.ValueMember = "cDepCode";
            // 
            // gridCol客户编码
            // 
            this.gridCol客户编码.Caption = "客户编码";
            this.gridCol客户编码.ColumnEdit = this.ItemLookUpEditcCusCode;
            this.gridCol客户编码.FieldName = "客户编码";
            this.gridCol客户编码.Name = "gridCol客户编码";
            this.gridCol客户编码.Visible = true;
            this.gridCol客户编码.VisibleIndex = 15;
            // 
            // ItemLookUpEditcCusCode
            // 
            this.ItemLookUpEditcCusCode.AutoHeight = false;
            this.ItemLookUpEditcCusCode.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.ItemLookUpEditcCusCode.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("cCusCode", "客户编码"),
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("cCusName", 60, "客户名称")});
            this.ItemLookUpEditcCusCode.DisplayMember = "cCusCode";
            this.ItemLookUpEditcCusCode.Name = "ItemLookUpEditcCusCode";
            this.ItemLookUpEditcCusCode.NullText = "";
            this.ItemLookUpEditcCusCode.PopupWidth = 400;
            this.ItemLookUpEditcCusCode.ValueMember = "cCusCode";
            // 
            // gridCol客户名称
            // 
            this.gridCol客户名称.Caption = "客户名称";
            this.gridCol客户名称.ColumnEdit = this.ItemLookUpEditcCusName;
            this.gridCol客户名称.FieldName = "客户编码";
            this.gridCol客户名称.Name = "gridCol客户名称";
            this.gridCol客户名称.OptionsColumn.AllowEdit = false;
            this.gridCol客户名称.OptionsColumn.AllowMerge = DevExpress.Utils.DefaultBoolean.False;
            this.gridCol客户名称.Visible = true;
            this.gridCol客户名称.VisibleIndex = 16;
            // 
            // ItemLookUpEditcCusName
            // 
            this.ItemLookUpEditcCusName.AutoHeight = false;
            this.ItemLookUpEditcCusName.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.ItemLookUpEditcCusName.DisplayMember = "cCusName";
            this.ItemLookUpEditcCusName.Name = "ItemLookUpEditcCusName";
            this.ItemLookUpEditcCusName.NullText = "";
            this.ItemLookUpEditcCusName.ValueMember = "cCusCode";
            // 
            // gridCol供应商编码
            // 
            this.gridCol供应商编码.Caption = "供应商编码";
            this.gridCol供应商编码.ColumnEdit = this.ItemLookUpEditcVenCode;
            this.gridCol供应商编码.FieldName = "供应商编码";
            this.gridCol供应商编码.Name = "gridCol供应商编码";
            this.gridCol供应商编码.Visible = true;
            this.gridCol供应商编码.VisibleIndex = 17;
            this.gridCol供应商编码.Width = 106;
            // 
            // ItemLookUpEditcVenCode
            // 
            this.ItemLookUpEditcVenCode.AutoHeight = false;
            this.ItemLookUpEditcVenCode.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.ItemLookUpEditcVenCode.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("cVenCode", "供应商编码"),
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("cVenName", 60, "供应商名称")});
            this.ItemLookUpEditcVenCode.DisplayMember = "cVenCode";
            this.ItemLookUpEditcVenCode.Name = "ItemLookUpEditcVenCode";
            this.ItemLookUpEditcVenCode.NullText = "";
            this.ItemLookUpEditcVenCode.PopupWidth = 400;
            this.ItemLookUpEditcVenCode.ValueMember = "cVenCode";
            // 
            // gridCol供应商名称
            // 
            this.gridCol供应商名称.Caption = "供应商名称";
            this.gridCol供应商名称.ColumnEdit = this.ItemLookUpEditcVenName;
            this.gridCol供应商名称.FieldName = "供应商编码";
            this.gridCol供应商名称.Name = "gridCol供应商名称";
            this.gridCol供应商名称.OptionsColumn.AllowEdit = false;
            this.gridCol供应商名称.OptionsColumn.AllowMerge = DevExpress.Utils.DefaultBoolean.False;
            this.gridCol供应商名称.Visible = true;
            this.gridCol供应商名称.VisibleIndex = 18;
            // 
            // ItemLookUpEditcVenName
            // 
            this.ItemLookUpEditcVenName.AutoHeight = false;
            this.ItemLookUpEditcVenName.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.ItemLookUpEditcVenName.DisplayMember = "cVenName";
            this.ItemLookUpEditcVenName.Name = "ItemLookUpEditcVenName";
            this.ItemLookUpEditcVenName.NullText = "";
            this.ItemLookUpEditcVenName.ValueMember = "cVenCode";
            // 
            // gridCol制单人
            // 
            this.gridCol制单人.Caption = "制单人";
            this.gridCol制单人.FieldName = "制单人";
            this.gridCol制单人.Name = "gridCol制单人";
            this.gridCol制单人.OptionsColumn.AllowEdit = false;
            this.gridCol制单人.OptionsColumn.AllowMerge = DevExpress.Utils.DefaultBoolean.False;
            this.gridCol制单人.Visible = true;
            this.gridCol制单人.VisibleIndex = 19;
            // 
            // gridCol制单日期
            // 
            this.gridCol制单日期.Caption = "制单日期";
            this.gridCol制单日期.FieldName = "制单日期";
            this.gridCol制单日期.Name = "gridCol制单日期";
            this.gridCol制单日期.OptionsColumn.AllowEdit = false;
            this.gridCol制单日期.OptionsColumn.AllowMerge = DevExpress.Utils.DefaultBoolean.False;
            this.gridCol制单日期.Visible = true;
            this.gridCol制单日期.VisibleIndex = 20;
            // 
            // gridCol年度
            // 
            this.gridCol年度.Caption = "年度";
            this.gridCol年度.FieldName = "年度";
            this.gridCol年度.Name = "gridCol年度";
            this.gridCol年度.OptionsColumn.AllowEdit = false;
            this.gridCol年度.Visible = true;
            this.gridCol年度.VisibleIndex = 21;
            // 
            // gridCol期间
            // 
            this.gridCol期间.Caption = "期间";
            this.gridCol期间.FieldName = "期间";
            this.gridCol期间.Name = "gridCol期间";
            this.gridCol期间.OptionsColumn.AllowEdit = false;
            this.gridCol期间.Visible = true;
            this.gridCol期间.VisibleIndex = 22;
            // 
            // gridCol科目名称
            // 
            this.gridCol科目名称.Caption = "科目名称";
            this.gridCol科目名称.FieldName = "科目名称";
            this.gridCol科目名称.Name = "gridCol科目名称";
            this.gridCol科目名称.OptionsColumn.AllowEdit = false;
            this.gridCol科目名称.Visible = true;
            this.gridCol科目名称.VisibleIndex = 6;
            // 
            // gridCol客户核算
            // 
            this.gridCol客户核算.Caption = "客户核算";
            this.gridCol客户核算.FieldName = "客户核算";
            this.gridCol客户核算.Name = "gridCol客户核算";
            this.gridCol客户核算.OptionsColumn.AllowEdit = false;
            this.gridCol客户核算.Visible = true;
            this.gridCol客户核算.VisibleIndex = 23;
            // 
            // gridCol供应商核算
            // 
            this.gridCol供应商核算.Caption = "供应商核算";
            this.gridCol供应商核算.FieldName = "供应商核算";
            this.gridCol供应商核算.Name = "gridCol供应商核算";
            this.gridCol供应商核算.OptionsColumn.AllowEdit = false;
            this.gridCol供应商核算.Visible = true;
            this.gridCol供应商核算.VisibleIndex = 24;
            this.gridCol供应商核算.Width = 104;
            // 
            // gridCol部门核算
            // 
            this.gridCol部门核算.Caption = "部门核算";
            this.gridCol部门核算.FieldName = "部门核算";
            this.gridCol部门核算.Name = "gridCol部门核算";
            this.gridCol部门核算.OptionsColumn.AllowEdit = false;
            this.gridCol部门核算.Visible = true;
            this.gridCol部门核算.VisibleIndex = 25;
            // 
            // gridCol项目核算
            // 
            this.gridCol项目核算.Caption = "项目核算";
            this.gridCol项目核算.FieldName = "项目核算";
            this.gridCol项目核算.Name = "gridCol项目核算";
            this.gridCol项目核算.OptionsColumn.AllowEdit = false;
            this.gridCol项目核算.Visible = true;
            this.gridCol项目核算.VisibleIndex = 26;
            // 
            // gridCol个人核算
            // 
            this.gridCol个人核算.Caption = "个人核算";
            this.gridCol个人核算.FieldName = "个人核算";
            this.gridCol个人核算.Name = "gridCol个人核算";
            this.gridCol个人核算.OptionsColumn.AllowEdit = false;
            this.gridCol个人核算.Visible = true;
            this.gridCol个人核算.VisibleIndex = 27;
            // 
            // GL_accvouch
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.menuStrip1);
            this.Name = "GL_accvouch";
            this.Size = new System.Drawing.Size(1031, 395);
            this.Load += new System.EventHandler(this.Frm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.ItemTextEditn2)).EndInit();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ItemLookUpEditcDepCode)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ItemLookUpEditcDepName)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ItemLookUpEditcCusCode)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ItemLookUpEditcCusName)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ItemLookUpEditcVenCode)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ItemLookUpEditcVenName)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem btnSave;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.ToolStripMenuItem btnLoad;
        private DevExpress.XtraGrid.GridControl gridControl1;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView1;
        private DevExpress.XtraGrid.Columns.GridColumn gridCol凭证类别;
        private DevExpress.XtraGrid.Columns.GridColumn gridCol会计科目;
        private DevExpress.XtraGrid.Columns.GridColumn gridCol借方;
        private DevExpress.XtraGrid.Columns.GridColumn gridCol贷方;
        private DevExpress.XtraGrid.Columns.GridColumn gridCol凭证号;
        private DevExpress.XtraGrid.Columns.GridColumn gridCol摘要;
        private DevExpress.XtraGrid.Columns.GridColumn gridCol外币借方;
        private DevExpress.XtraGrid.Columns.GridColumn gridCol外币贷方;
        private DevExpress.XtraGrid.Columns.GridColumn gridCol币种;
        private DevExpress.XtraGrid.Columns.GridColumn gridCol汇率;
        private DevExpress.XtraGrid.Columns.GridColumn gridCol部门名称;
        private DevExpress.XtraGrid.Columns.GridColumn gridCol客户名称;
        private DevExpress.XtraGrid.Columns.GridColumn gridCol供应商名称;
        private DevExpress.XtraGrid.Columns.GridColumn gridCol制单人;
        private DevExpress.XtraGrid.Columns.GridColumn gridCol制单日期;
        private DevExpress.XtraGrid.Columns.GridColumn gridCol选择;
        private DevExpress.XtraGrid.Columns.GridColumn gridCol行号;
        private DevExpress.XtraEditors.Repository.RepositoryItemTextEdit ItemTextEditn2;
        private DevExpress.XtraGrid.Columns.GridColumn gridCol客户编码;
        private DevExpress.XtraGrid.Columns.GridColumn gridCol供应商编码;
        private System.Windows.Forms.TextBox txtXZDTableName;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtMonth;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtYear;
        private DevExpress.XtraGrid.Columns.GridColumn gridCol部门编码;
        private DevExpress.XtraGrid.Columns.GridColumn gridCol年度;
        private DevExpress.XtraGrid.Columns.GridColumn gridCol期间;
        private DevExpress.XtraGrid.Columns.GridColumn gridCol科目名称;
        private DevExpress.XtraGrid.Columns.GridColumn gridCol客户核算;
        private DevExpress.XtraGrid.Columns.GridColumn gridCol供应商核算;
        private DevExpress.XtraGrid.Columns.GridColumn gridCol部门核算;
        private DevExpress.XtraGrid.Columns.GridColumn gridCol项目核算;
        private DevExpress.XtraGrid.Columns.GridColumn gridCol个人核算;
        private DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit ItemLookUpEditcDepCode;
        private DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit ItemLookUpEditcDepName;
        private DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit ItemLookUpEditcCusCode;
        private DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit ItemLookUpEditcCusName;
        private DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit ItemLookUpEditcVenCode;
        private DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit ItemLookUpEditcVenName;
    }
}
