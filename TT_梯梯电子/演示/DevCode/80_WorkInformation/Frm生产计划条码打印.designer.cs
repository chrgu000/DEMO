namespace WorkInformation
{
    partial class Frm生产计划条码打印
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
            this.emptySpaceItem4 = new DevExpress.XtraLayout.EmptySpaceItem();
            this.emptySpaceItem3 = new DevExpress.XtraLayout.EmptySpaceItem();
            this.panel1 = new System.Windows.Forms.Panel();
            this.radio全部 = new System.Windows.Forms.RadioButton();
            this.radio流转缴库 = new System.Windows.Forms.RadioButton();
            this.radio生产缴库 = new System.Windows.Forms.RadioButton();
            this.radio工序报表 = new System.Windows.Forms.RadioButton();
            this.dtm计划日期 = new DevExpress.XtraEditors.DateEdit();
            this.lookUpEdit班组 = new DevExpress.XtraEditors.LookUpEdit();
            this.chk包含已关闭 = new DevExpress.XtraEditors.CheckEdit();
            this.chk全选 = new DevExpress.XtraEditors.CheckEdit();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.gridControl1 = new DevExpress.XtraGrid.GridControl();
            this.gridView1 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.gridCol选择 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.ItemCheckEdit选择 = new DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit();
            this.gridCol人员 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridCol物料编码 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridCol外销订单 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridCol产品编码 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridCol订单数量 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridCol制造令号码 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridCol物料名称 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridCol物料规格 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridCol设备 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridCol工序 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridCol工时理论 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridCol预计计划数量 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridCol计划数量 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridCol完工数量 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridCol工时 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridCol周未完工 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridCol下一工序 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridCol条形码 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridCol托外结束时间 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridCol货位 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridCol工序类型 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridCol本次缴库数量 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dsPrint)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dsForm)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtSel)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem3)).BeginInit();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dtm计划日期.Properties.VistaTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtm计划日期.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lookUpEdit班组.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chk包含已关闭.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chk全选.Properties)).BeginInit();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ItemCheckEdit选择)).BeginInit();
            this.SuspendLayout();
            // 
            // emptySpaceItem4
            // 
            this.emptySpaceItem4.AllowHotTrack = false;
            this.emptySpaceItem4.CustomizationFormText = "emptySpaceItem4";
            this.emptySpaceItem4.Location = new System.Drawing.Point(251, 0);
            this.emptySpaceItem4.Name = "emptySpaceItem4";
            this.emptySpaceItem4.Size = new System.Drawing.Size(126, 110);
            this.emptySpaceItem4.Text = "emptySpaceItem4";
            this.emptySpaceItem4.TextSize = new System.Drawing.Size(0, 0);
            // 
            // emptySpaceItem3
            // 
            this.emptySpaceItem3.AllowHotTrack = false;
            this.emptySpaceItem3.CustomizationFormText = "emptySpaceItem1";
            this.emptySpaceItem3.Location = new System.Drawing.Point(224, 0);
            this.emptySpaceItem3.Name = "emptySpaceItem1";
            this.emptySpaceItem3.Size = new System.Drawing.Size(672, 25);
            this.emptySpaceItem3.Text = "emptySpaceItem1";
            this.emptySpaceItem3.TextSize = new System.Drawing.Size(0, 0);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.radio全部);
            this.panel1.Controls.Add(this.radio流转缴库);
            this.panel1.Controls.Add(this.radio生产缴库);
            this.panel1.Controls.Add(this.radio工序报表);
            this.panel1.Location = new System.Drawing.Point(327, 27);
            this.panel1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(381, 106);
            this.panel1.TabIndex = 26;
            // 
            // radio全部
            // 
            this.radio全部.AutoSize = true;
            this.radio全部.Location = new System.Drawing.Point(288, 15);
            this.radio全部.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.radio全部.Name = "radio全部";
            this.radio全部.Size = new System.Drawing.Size(59, 22);
            this.radio全部.TabIndex = 3;
            this.radio全部.Text = "全部";
            this.radio全部.UseVisualStyleBackColor = true;
            this.radio全部.CheckedChanged += new System.EventHandler(this.radio全部_CheckedChanged);
            // 
            // radio流转缴库
            // 
            this.radio流转缴库.AutoSize = true;
            this.radio流转缴库.Location = new System.Drawing.Point(218, 57);
            this.radio流转缴库.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.radio流转缴库.Name = "radio流转缴库";
            this.radio流转缴库.Size = new System.Drawing.Size(89, 22);
            this.radio流转缴库.TabIndex = 2;
            this.radio流转缴库.Text = "流转缴库";
            this.radio流转缴库.UseVisualStyleBackColor = true;
            this.radio流转缴库.Visible = false;
            this.radio流转缴库.CheckedChanged += new System.EventHandler(this.radio流转缴库_CheckedChanged);
            // 
            // radio生产缴库
            // 
            this.radio生产缴库.AutoSize = true;
            this.radio生产缴库.Location = new System.Drawing.Point(172, 15);
            this.radio生产缴库.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.radio生产缴库.Name = "radio生产缴库";
            this.radio生产缴库.Size = new System.Drawing.Size(89, 22);
            this.radio生产缴库.TabIndex = 1;
            this.radio生产缴库.Text = "生产缴库";
            this.radio生产缴库.UseVisualStyleBackColor = true;
            this.radio生产缴库.CheckedChanged += new System.EventHandler(this.radio生产缴库_CheckedChanged);
            // 
            // radio工序报表
            // 
            this.radio工序报表.AutoSize = true;
            this.radio工序报表.Checked = true;
            this.radio工序报表.Location = new System.Drawing.Point(3, 15);
            this.radio工序报表.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.radio工序报表.Name = "radio工序报表";
            this.radio工序报表.Size = new System.Drawing.Size(155, 22);
            this.radio工序报表.TabIndex = 0;
            this.radio工序报表.TabStop = true;
            this.radio工序报表.Text = "工序报表(含流转）";
            this.radio工序报表.UseVisualStyleBackColor = true;
            this.radio工序报表.CheckedChanged += new System.EventHandler(this.radio工序报表_CheckedChanged);
            // 
            // dtm计划日期
            // 
            this.dtm计划日期.EditValue = null;
            this.dtm计划日期.Location = new System.Drawing.Point(123, 24);
            this.dtm计划日期.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.dtm计划日期.Name = "dtm计划日期";
            this.dtm计划日期.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.dtm计划日期.Properties.VistaTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
            this.dtm计划日期.Size = new System.Drawing.Size(183, 24);
            this.dtm计划日期.TabIndex = 21;
            this.dtm计划日期.EditValueChanged += new System.EventHandler(this.dtm计划日期_EditValueChanged);
            // 
            // lookUpEdit班组
            // 
            this.lookUpEdit班组.Location = new System.Drawing.Point(123, 56);
            this.lookUpEdit班组.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.lookUpEdit班组.Name = "lookUpEdit班组";
            this.lookUpEdit班组.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.lookUpEdit班组.Properties.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("FCode", "班组编号"),
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("FName", "班组")});
            this.lookUpEdit班组.Properties.DisplayMember = "FName";
            this.lookUpEdit班组.Properties.NullText = "";
            this.lookUpEdit班组.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.Standard;
            this.lookUpEdit班组.Properties.ValueMember = "FCode";
            this.lookUpEdit班组.Size = new System.Drawing.Size(183, 24);
            this.lookUpEdit班组.TabIndex = 23;
            this.lookUpEdit班组.EditValueChanged += new System.EventHandler(this.lookUpEdit班组_EditValueChanged);
            // 
            // chk包含已关闭
            // 
            this.chk包含已关闭.Location = new System.Drawing.Point(17, 95);
            this.chk包含已关闭.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.chk包含已关闭.Name = "chk包含已关闭";
            this.chk包含已关闭.Properties.Caption = "包含已关闭";
            this.chk包含已关闭.Size = new System.Drawing.Size(247, 23);
            this.chk包含已关闭.TabIndex = 24;
            // 
            // chk全选
            // 
            this.chk全选.Location = new System.Drawing.Point(17, 126);
            this.chk全选.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.chk全选.Name = "chk全选";
            this.chk全选.Properties.Caption = "全选";
            this.chk全选.Size = new System.Drawing.Size(247, 23);
            this.chk全选.TabIndex = 25;
            this.chk全选.CheckedChanged += new System.EventHandler(this.chk全选_CheckedChanged);
            // 
            // tabControl1
            // 
            this.tabControl1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Location = new System.Drawing.Point(0, 157);
            this.tabControl1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(1016, 385);
            this.tabControl1.TabIndex = 22;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.gridControl1);
            this.tabPage1.Location = new System.Drawing.Point(4, 27);
            this.tabPage1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.tabPage1.Size = new System.Drawing.Size(1008, 354);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "明细";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // gridControl1
            // 
            this.gridControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridControl1.EmbeddedNavigator.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.gridControl1.Location = new System.Drawing.Point(3, 4);
            this.gridControl1.MainView = this.gridView1;
            this.gridControl1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.gridControl1.Name = "gridControl1";
            this.gridControl1.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.ItemCheckEdit选择});
            this.gridControl1.Size = new System.Drawing.Size(1002, 346);
            this.gridControl1.TabIndex = 8;
            this.gridControl1.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView1});
            // 
            // gridView1
            // 
            this.gridView1.Appearance.FocusedCell.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.gridView1.Appearance.FocusedCell.Options.UseBackColor = true;
            this.gridView1.Appearance.FocusedRow.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.gridView1.Appearance.FocusedRow.Options.UseBackColor = true;
            this.gridView1.Appearance.SelectedRow.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.gridView1.Appearance.SelectedRow.Options.UseBackColor = true;
            this.gridView1.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.gridCol选择,
            this.gridCol人员,
            this.gridCol物料编码,
            this.gridCol外销订单,
            this.gridCol产品编码,
            this.gridCol订单数量,
            this.gridCol制造令号码,
            this.gridCol物料名称,
            this.gridCol物料规格,
            this.gridCol设备,
            this.gridCol工序,
            this.gridCol工时理论,
            this.gridCol预计计划数量,
            this.gridCol计划数量,
            this.gridCol完工数量,
            this.gridCol工时,
            this.gridCol周未完工,
            this.gridCol下一工序,
            this.gridCol条形码,
            this.gridCol托外结束时间,
            this.gridCol货位,
            this.gridCol工序类型,
            this.gridCol本次缴库数量});
            this.gridView1.GridControl = this.gridControl1;
            this.gridView1.IndicatorWidth = 40;
            this.gridView1.Name = "gridView1";
            this.gridView1.OptionsLayout.Columns.StoreAllOptions = true;
            this.gridView1.OptionsLayout.Columns.StoreAppearance = true;
            this.gridView1.OptionsLayout.StoreAllOptions = true;
            this.gridView1.OptionsLayout.StoreAppearance = true;
            this.gridView1.OptionsMenu.ShowAddNewSummaryItem = DevExpress.Utils.DefaultBoolean.True;
            this.gridView1.OptionsMenu.ShowGroupSummaryEditorItem = true;
            this.gridView1.OptionsNavigation.EnterMoveNextColumn = true;
            this.gridView1.OptionsSelection.MultiSelect = true;
            this.gridView1.OptionsView.AutoCalcPreviewLineCount = true;
            this.gridView1.OptionsView.ColumnAutoWidth = false;
            this.gridView1.OptionsView.EnableAppearanceEvenRow = true;
            this.gridView1.OptionsView.EnableAppearanceOddRow = true;
            this.gridView1.OptionsView.ShowFooter = true;
            this.gridView1.OptionsView.ShowGroupPanel = false;
            this.gridView1.CustomDrawRowIndicator += new DevExpress.XtraGrid.Views.Grid.RowIndicatorCustomDrawEventHandler(this.gridView1_CustomDrawRowIndicator);
            this.gridView1.RowCellStyle += new DevExpress.XtraGrid.Views.Grid.RowCellStyleEventHandler(this.gridView1_RowCellStyle);
            // 
            // gridCol选择
            // 
            this.gridCol选择.Caption = "选择";
            this.gridCol选择.ColumnEdit = this.ItemCheckEdit选择;
            this.gridCol选择.FieldName = "选择";
            this.gridCol选择.Name = "gridCol选择";
            this.gridCol选择.OptionsColumn.AllowSort = DevExpress.Utils.DefaultBoolean.False;
            this.gridCol选择.Visible = true;
            this.gridCol选择.VisibleIndex = 0;
            this.gridCol选择.Width = 38;
            // 
            // ItemCheckEdit选择
            // 
            this.ItemCheckEdit选择.AutoHeight = false;
            this.ItemCheckEdit选择.Name = "ItemCheckEdit选择";
            // 
            // gridCol人员
            // 
            this.gridCol人员.Caption = "人员";
            this.gridCol人员.FieldName = "人员";
            this.gridCol人员.Name = "gridCol人员";
            this.gridCol人员.OptionsColumn.AllowEdit = false;
            this.gridCol人员.OptionsColumn.AllowSort = DevExpress.Utils.DefaultBoolean.False;
            this.gridCol人员.Visible = true;
            this.gridCol人员.VisibleIndex = 1;
            // 
            // gridCol物料编码
            // 
            this.gridCol物料编码.Caption = "物料编码";
            this.gridCol物料编码.FieldName = "物料编码";
            this.gridCol物料编码.Name = "gridCol物料编码";
            this.gridCol物料编码.OptionsColumn.AllowEdit = false;
            this.gridCol物料编码.OptionsColumn.AllowSort = DevExpress.Utils.DefaultBoolean.False;
            this.gridCol物料编码.Visible = true;
            this.gridCol物料编码.VisibleIndex = 2;
            // 
            // gridCol外销订单
            // 
            this.gridCol外销订单.Caption = "外销订单";
            this.gridCol外销订单.FieldName = "外销订单";
            this.gridCol外销订单.Name = "gridCol外销订单";
            this.gridCol外销订单.OptionsColumn.AllowEdit = false;
            this.gridCol外销订单.OptionsColumn.AllowSort = DevExpress.Utils.DefaultBoolean.False;
            this.gridCol外销订单.Visible = true;
            this.gridCol外销订单.VisibleIndex = 3;
            // 
            // gridCol产品编码
            // 
            this.gridCol产品编码.Caption = "产品编码";
            this.gridCol产品编码.FieldName = "产品编码";
            this.gridCol产品编码.Name = "gridCol产品编码";
            this.gridCol产品编码.OptionsColumn.AllowEdit = false;
            this.gridCol产品编码.OptionsColumn.AllowSort = DevExpress.Utils.DefaultBoolean.False;
            this.gridCol产品编码.Visible = true;
            this.gridCol产品编码.VisibleIndex = 4;
            // 
            // gridCol订单数量
            // 
            this.gridCol订单数量.Caption = "订单数量";
            this.gridCol订单数量.FieldName = "订单数量";
            this.gridCol订单数量.Name = "gridCol订单数量";
            this.gridCol订单数量.OptionsColumn.AllowEdit = false;
            this.gridCol订单数量.OptionsColumn.AllowSort = DevExpress.Utils.DefaultBoolean.False;
            this.gridCol订单数量.Summary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] {
            new DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum)});
            this.gridCol订单数量.Visible = true;
            this.gridCol订单数量.VisibleIndex = 5;
            // 
            // gridCol制造令号码
            // 
            this.gridCol制造令号码.Caption = "制造令号码";
            this.gridCol制造令号码.FieldName = "制造令号码";
            this.gridCol制造令号码.Name = "gridCol制造令号码";
            this.gridCol制造令号码.OptionsColumn.AllowEdit = false;
            this.gridCol制造令号码.OptionsColumn.AllowSort = DevExpress.Utils.DefaultBoolean.False;
            this.gridCol制造令号码.Visible = true;
            this.gridCol制造令号码.VisibleIndex = 6;
            this.gridCol制造令号码.Width = 85;
            // 
            // gridCol物料名称
            // 
            this.gridCol物料名称.Caption = "物料名称";
            this.gridCol物料名称.FieldName = "物料名称";
            this.gridCol物料名称.Name = "gridCol物料名称";
            this.gridCol物料名称.OptionsColumn.AllowEdit = false;
            this.gridCol物料名称.OptionsColumn.AllowSort = DevExpress.Utils.DefaultBoolean.False;
            this.gridCol物料名称.Visible = true;
            this.gridCol物料名称.VisibleIndex = 7;
            // 
            // gridCol物料规格
            // 
            this.gridCol物料规格.Caption = "物料规格";
            this.gridCol物料规格.FieldName = "物料规格";
            this.gridCol物料规格.Name = "gridCol物料规格";
            this.gridCol物料规格.OptionsColumn.AllowEdit = false;
            this.gridCol物料规格.OptionsColumn.AllowSort = DevExpress.Utils.DefaultBoolean.False;
            this.gridCol物料规格.Visible = true;
            this.gridCol物料规格.VisibleIndex = 8;
            // 
            // gridCol设备
            // 
            this.gridCol设备.Caption = "设备";
            this.gridCol设备.FieldName = "设备";
            this.gridCol设备.Name = "gridCol设备";
            this.gridCol设备.OptionsColumn.AllowEdit = false;
            this.gridCol设备.OptionsColumn.AllowSort = DevExpress.Utils.DefaultBoolean.False;
            this.gridCol设备.Visible = true;
            this.gridCol设备.VisibleIndex = 9;
            // 
            // gridCol工序
            // 
            this.gridCol工序.Caption = "工序";
            this.gridCol工序.FieldName = "工序";
            this.gridCol工序.Name = "gridCol工序";
            this.gridCol工序.OptionsColumn.AllowEdit = false;
            this.gridCol工序.OptionsColumn.AllowSort = DevExpress.Utils.DefaultBoolean.False;
            this.gridCol工序.Visible = true;
            this.gridCol工序.VisibleIndex = 10;
            // 
            // gridCol工时理论
            // 
            this.gridCol工时理论.Caption = "工时理论";
            this.gridCol工时理论.FieldName = "工时理论";
            this.gridCol工时理论.Name = "gridCol工时理论";
            this.gridCol工时理论.OptionsColumn.AllowEdit = false;
            this.gridCol工时理论.OptionsColumn.AllowSort = DevExpress.Utils.DefaultBoolean.False;
            this.gridCol工时理论.Summary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] {
            new DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum)});
            this.gridCol工时理论.Visible = true;
            this.gridCol工时理论.VisibleIndex = 11;
            // 
            // gridCol预计计划数量
            // 
            this.gridCol预计计划数量.Caption = "预计计划数量";
            this.gridCol预计计划数量.FieldName = "预计计划数量";
            this.gridCol预计计划数量.Name = "gridCol预计计划数量";
            this.gridCol预计计划数量.OptionsColumn.AllowEdit = false;
            this.gridCol预计计划数量.OptionsColumn.AllowSort = DevExpress.Utils.DefaultBoolean.False;
            this.gridCol预计计划数量.Summary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] {
            new DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum)});
            this.gridCol预计计划数量.Visible = true;
            this.gridCol预计计划数量.VisibleIndex = 12;
            this.gridCol预计计划数量.Width = 100;
            // 
            // gridCol计划数量
            // 
            this.gridCol计划数量.Caption = "计划数量";
            this.gridCol计划数量.FieldName = "计划数量";
            this.gridCol计划数量.Name = "gridCol计划数量";
            this.gridCol计划数量.OptionsColumn.AllowEdit = false;
            this.gridCol计划数量.OptionsColumn.AllowSort = DevExpress.Utils.DefaultBoolean.False;
            this.gridCol计划数量.Summary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] {
            new DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum)});
            this.gridCol计划数量.Visible = true;
            this.gridCol计划数量.VisibleIndex = 13;
            // 
            // gridCol完工数量
            // 
            this.gridCol完工数量.Caption = "完工数量";
            this.gridCol完工数量.FieldName = "完工数量";
            this.gridCol完工数量.Name = "gridCol完工数量";
            this.gridCol完工数量.OptionsColumn.AllowEdit = false;
            this.gridCol完工数量.OptionsColumn.AllowSort = DevExpress.Utils.DefaultBoolean.False;
            this.gridCol完工数量.Summary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] {
            new DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum)});
            // 
            // gridCol工时
            // 
            this.gridCol工时.Caption = "工时";
            this.gridCol工时.FieldName = "工时";
            this.gridCol工时.Name = "gridCol工时";
            this.gridCol工时.OptionsColumn.AllowEdit = false;
            this.gridCol工时.OptionsColumn.AllowSort = DevExpress.Utils.DefaultBoolean.False;
            this.gridCol工时.Summary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] {
            new DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum)});
            // 
            // gridCol周未完工
            // 
            this.gridCol周未完工.Caption = "周/未完工";
            this.gridCol周未完工.FieldName = "周未完工";
            this.gridCol周未完工.Name = "gridCol周未完工";
            this.gridCol周未完工.OptionsColumn.AllowEdit = false;
            this.gridCol周未完工.OptionsColumn.AllowSort = DevExpress.Utils.DefaultBoolean.False;
            this.gridCol周未完工.Visible = true;
            this.gridCol周未完工.VisibleIndex = 15;
            // 
            // gridCol下一工序
            // 
            this.gridCol下一工序.Caption = "下一工序";
            this.gridCol下一工序.FieldName = "下一工序";
            this.gridCol下一工序.Name = "gridCol下一工序";
            this.gridCol下一工序.OptionsColumn.AllowEdit = false;
            this.gridCol下一工序.OptionsColumn.AllowSort = DevExpress.Utils.DefaultBoolean.False;
            this.gridCol下一工序.Visible = true;
            this.gridCol下一工序.VisibleIndex = 16;
            // 
            // gridCol条形码
            // 
            this.gridCol条形码.Caption = "条形码";
            this.gridCol条形码.FieldName = "条形码";
            this.gridCol条形码.Name = "gridCol条形码";
            this.gridCol条形码.OptionsColumn.AllowEdit = false;
            this.gridCol条形码.OptionsColumn.AllowSort = DevExpress.Utils.DefaultBoolean.False;
            this.gridCol条形码.Visible = true;
            this.gridCol条形码.VisibleIndex = 17;
            // 
            // gridCol托外结束时间
            // 
            this.gridCol托外结束时间.Caption = "托外结束时间";
            this.gridCol托外结束时间.FieldName = "托外结束时间";
            this.gridCol托外结束时间.Name = "gridCol托外结束时间";
            this.gridCol托外结束时间.OptionsColumn.AllowEdit = false;
            this.gridCol托外结束时间.OptionsColumn.AllowSort = DevExpress.Utils.DefaultBoolean.False;
            this.gridCol托外结束时间.Visible = true;
            this.gridCol托外结束时间.VisibleIndex = 18;
            this.gridCol托外结束时间.Width = 99;
            // 
            // gridCol货位
            // 
            this.gridCol货位.Caption = "货位";
            this.gridCol货位.FieldName = "货位";
            this.gridCol货位.Name = "gridCol货位";
            this.gridCol货位.OptionsColumn.AllowEdit = false;
            this.gridCol货位.OptionsColumn.AllowSort = DevExpress.Utils.DefaultBoolean.False;
            this.gridCol货位.Visible = true;
            this.gridCol货位.VisibleIndex = 19;
            // 
            // gridCol工序类型
            // 
            this.gridCol工序类型.Caption = "工序类型";
            this.gridCol工序类型.FieldName = "工序类型";
            this.gridCol工序类型.Name = "gridCol工序类型";
            this.gridCol工序类型.OptionsColumn.AllowEdit = false;
            this.gridCol工序类型.Visible = true;
            this.gridCol工序类型.VisibleIndex = 20;
            // 
            // gridCol本次缴库数量
            // 
            this.gridCol本次缴库数量.Caption = "本次缴库数量";
            this.gridCol本次缴库数量.FieldName = "本次缴库数量";
            this.gridCol本次缴库数量.Name = "gridCol本次缴库数量";
            this.gridCol本次缴库数量.Visible = true;
            this.gridCol本次缴库数量.VisibleIndex = 14;
            this.gridCol本次缴库数量.Width = 101;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(38, 27);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(68, 18);
            this.label1.TabIndex = 27;
            this.label1.Text = "计划日期";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(48, 59);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(38, 18);
            this.label2.TabIndex = 28;
            this.label2.Text = "班组";
            // 
            // Frm生产计划条码打印
            // 
            this.Appearance.BackColor = System.Drawing.SystemColors.Control;
            this.Appearance.Options.UseBackColor = true;
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 18F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1016, 544);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.chk全选);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.dtm计划日期);
            this.Controls.Add(this.lookUpEdit班组);
            this.Controls.Add(this.chk包含已关闭);
            this.Controls.Add(this.tabControl1);
            this.Margin = new System.Windows.Forms.Padding(3, 5, 3, 5);
            this.Name = "Frm生产计划条码打印";
            this.Text = "生产计划条码打印";
            this.Load += new System.EventHandler(this.Frm生产流转缴库_Load);
            this.Controls.SetChildIndex(this.tabControl1, 0);
            this.Controls.SetChildIndex(this.chk包含已关闭, 0);
            this.Controls.SetChildIndex(this.lookUpEdit班组, 0);
            this.Controls.SetChildIndex(this.dtm计划日期, 0);
            this.Controls.SetChildIndex(this.panel1, 0);
            this.Controls.SetChildIndex(this.label1, 0);
            this.Controls.SetChildIndex(this.chk全选, 0);
            this.Controls.SetChildIndex(this.label2, 0);
            ((System.ComponentModel.ISupportInitialize)(this.dsPrint)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dsForm)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtSel)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem3)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dtm计划日期.Properties.VistaTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtm计划日期.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lookUpEdit班组.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chk包含已关闭.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chk全选.Properties)).EndInit();
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ItemCheckEdit选择)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        //private DevExpress.XtraLayout.LayoutControlGroup layoutControlGroup1;
        private DevExpress.XtraLayout.EmptySpaceItem emptySpaceItem4;
        private DevExpress.XtraLayout.EmptySpaceItem emptySpaceItem3;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.RadioButton radio全部;
        private System.Windows.Forms.RadioButton radio流转缴库;
        private System.Windows.Forms.RadioButton radio生产缴库;
        private System.Windows.Forms.RadioButton radio工序报表;
        private DevExpress.XtraEditors.DateEdit dtm计划日期;
        private DevExpress.XtraEditors.LookUpEdit lookUpEdit班组;
        private DevExpress.XtraEditors.CheckEdit chk包含已关闭;
        private DevExpress.XtraEditors.CheckEdit chk全选;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private DevExpress.XtraGrid.GridControl gridControl1;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView1;
        private DevExpress.XtraGrid.Columns.GridColumn gridCol选择;
        private DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit ItemCheckEdit选择;
        private DevExpress.XtraGrid.Columns.GridColumn gridCol人员;
        private DevExpress.XtraGrid.Columns.GridColumn gridCol物料编码;
        private DevExpress.XtraGrid.Columns.GridColumn gridCol外销订单;
        private DevExpress.XtraGrid.Columns.GridColumn gridCol产品编码;
        private DevExpress.XtraGrid.Columns.GridColumn gridCol订单数量;
        private DevExpress.XtraGrid.Columns.GridColumn gridCol制造令号码;
        private DevExpress.XtraGrid.Columns.GridColumn gridCol物料名称;
        private DevExpress.XtraGrid.Columns.GridColumn gridCol物料规格;
        private DevExpress.XtraGrid.Columns.GridColumn gridCol设备;
        private DevExpress.XtraGrid.Columns.GridColumn gridCol工序;
        private DevExpress.XtraGrid.Columns.GridColumn gridCol工时理论;
        private DevExpress.XtraGrid.Columns.GridColumn gridCol预计计划数量;
        private DevExpress.XtraGrid.Columns.GridColumn gridCol计划数量;
        private DevExpress.XtraGrid.Columns.GridColumn gridCol完工数量;
        private DevExpress.XtraGrid.Columns.GridColumn gridCol工时;
        private DevExpress.XtraGrid.Columns.GridColumn gridCol周未完工;
        private DevExpress.XtraGrid.Columns.GridColumn gridCol下一工序;
        private DevExpress.XtraGrid.Columns.GridColumn gridCol条形码;
        private DevExpress.XtraGrid.Columns.GridColumn gridCol托外结束时间;
        private DevExpress.XtraGrid.Columns.GridColumn gridCol货位;
        private DevExpress.XtraGrid.Columns.GridColumn gridCol工序类型;
        private DevExpress.XtraGrid.Columns.GridColumn gridCol本次缴库数量;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
    }
}