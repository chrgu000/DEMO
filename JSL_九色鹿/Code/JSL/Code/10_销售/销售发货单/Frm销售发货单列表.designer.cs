namespace 销售
{
    partial class Frm销售发货单列表 
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
            this.layoutControl1 = new DevExpress.XtraLayout.LayoutControl();
            this.checkEditChk = new DevExpress.XtraEditors.CheckEdit();
            this.gridControl1 = new DevExpress.XtraGrid.GridControl();
            this.gridView1 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.gridColID = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColAutoID = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridCol选择 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.ItemCheckEdit选择 = new DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit();
            this.gridCol单据号 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridCol单据日期 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridCol部门 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.ItemLookUpEdit部门 = new DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit();
            this.gridCol物料编码 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridCol物料名称 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.ItemLookUpEdit物料名称 = new DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit();
            this.gridCol数量 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridCol盒数 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridCol备注 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridCol制单人 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridCol制单日期 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridCol审核人 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridCol审核日期 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridCol关闭人 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridCol关闭日期 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColM1 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.ItemLookUpEditM1 = new DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit();
            this.gridColM2 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridCol已发货盒数 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.layoutControlGroup1 = new DevExpress.XtraLayout.LayoutControlGroup();
            this.layoutControlItem3 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem1 = new DevExpress.XtraLayout.LayoutControlItem();
            this.ItemLookUpEditSexID = new DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit();
            this.ItemLookUpEditDept = new DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit();
            ((System.ComponentModel.ISupportInitialize)(this.dsPrint)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dsPrint2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dsForm)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtSel)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControl1)).BeginInit();
            this.layoutControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.checkEditChk.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ItemCheckEdit选择)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ItemLookUpEdit部门)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ItemLookUpEdit物料名称)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ItemLookUpEditM1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ItemLookUpEditSexID)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ItemLookUpEditDept)).BeginInit();
            this.SuspendLayout();
            // 
            // layoutControl1
            // 
            this.layoutControl1.AllowCustomizationMenu = false;
            this.layoutControl1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.layoutControl1.Controls.Add(this.checkEditChk);
            this.layoutControl1.Controls.Add(this.gridControl1);
            this.layoutControl1.Location = new System.Drawing.Point(0, 28);
            this.layoutControl1.Name = "layoutControl1";
            this.layoutControl1.OptionsCustomizationForm.DesignTimeCustomizationFormPositionAndSize = new System.Drawing.Rectangle(75, 239, 250, 350);
            this.layoutControl1.OptionsCustomizationForm.ShowLoadButton = false;
            this.layoutControl1.OptionsCustomizationForm.ShowSaveButton = false;
            this.layoutControl1.OptionsView.UseDefaultDragAndDropRendering = false;
            this.layoutControl1.Root = this.layoutControlGroup1;
            this.layoutControl1.Size = new System.Drawing.Size(1299, 574);
            this.layoutControl1.TabIndex = 5;
            this.layoutControl1.Text = "layoutControl1";
            // 
            // checkEditChk
            // 
            this.checkEditChk.Location = new System.Drawing.Point(12, 12);
            this.checkEditChk.Name = "checkEditChk";
            this.checkEditChk.Properties.Caption = "全选";
            this.checkEditChk.Size = new System.Drawing.Size(1275, 19);
            this.checkEditChk.StyleController = this.layoutControl1;
            this.checkEditChk.TabIndex = 50;
            this.checkEditChk.CheckedChanged += new System.EventHandler(this.checkEditChk_CheckedChanged);
            // 
            // gridControl1
            // 
            this.gridControl1.Location = new System.Drawing.Point(12, 35);
            this.gridControl1.MainView = this.gridView1;
            this.gridControl1.Name = "gridControl1";
            this.gridControl1.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.ItemLookUpEdit部门,
            this.ItemCheckEdit选择,
            this.ItemLookUpEdit物料名称,
            this.ItemLookUpEditM1});
            this.gridControl1.Size = new System.Drawing.Size(1275, 527);
            this.gridControl1.TabIndex = 6;
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
            this.gridColID,
            this.gridColAutoID,
            this.gridCol选择,
            this.gridCol单据号,
            this.gridCol单据日期,
            this.gridCol部门,
            this.gridCol物料编码,
            this.gridCol物料名称,
            this.gridCol数量,
            this.gridCol盒数,
            this.gridCol备注,
            this.gridCol制单人,
            this.gridCol制单日期,
            this.gridCol审核人,
            this.gridCol审核日期,
            this.gridCol关闭人,
            this.gridCol关闭日期,
            this.gridColM1,
            this.gridColM2,
            this.gridCol已发货盒数});
            this.gridView1.CustomizationFormBounds = new System.Drawing.Rectangle(950, 457, 216, 187);
            this.gridView1.GridControl = this.gridControl1;
            this.gridView1.IndicatorWidth = 40;
            this.gridView1.Name = "gridView1";
            this.gridView1.OptionsBehavior.CopyToClipboardWithColumnHeaders = false;
            this.gridView1.OptionsLayout.Columns.StoreAllOptions = true;
            this.gridView1.OptionsLayout.Columns.StoreAppearance = true;
            this.gridView1.OptionsLayout.StoreAllOptions = true;
            this.gridView1.OptionsLayout.StoreAppearance = true;
            this.gridView1.OptionsMenu.ShowAddNewSummaryItem = DevExpress.Utils.DefaultBoolean.True;
            this.gridView1.OptionsMenu.ShowGroupSummaryEditorItem = true;
            this.gridView1.OptionsNavigation.EnterMoveNextColumn = true;
            this.gridView1.OptionsSelection.MultiSelect = true;
            this.gridView1.OptionsSelection.MultiSelectMode = DevExpress.XtraGrid.Views.Grid.GridMultiSelectMode.CellSelect;
            this.gridView1.OptionsView.AutoCalcPreviewLineCount = true;
            this.gridView1.OptionsView.ColumnAutoWidth = false;
            this.gridView1.OptionsView.EnableAppearanceEvenRow = true;
            this.gridView1.OptionsView.EnableAppearanceOddRow = true;
            this.gridView1.OptionsView.ShowFooter = true;
            this.gridView1.OptionsView.ShowGroupPanel = false;
            this.gridView1.CustomDrawRowIndicator += new DevExpress.XtraGrid.Views.Grid.RowIndicatorCustomDrawEventHandler(this.gridView1_CustomDrawRowIndicator);
            this.gridView1.DoubleClick += new System.EventHandler(this.gridView1_DoubleClick);
            // 
            // gridColID
            // 
            this.gridColID.Caption = "ID";
            this.gridColID.FieldName = "ID";
            this.gridColID.Name = "gridColID";
            this.gridColID.OptionsColumn.AllowEdit = false;
            // 
            // gridColAutoID
            // 
            this.gridColAutoID.Caption = "AutoID";
            this.gridColAutoID.FieldName = "AutoID";
            this.gridColAutoID.Name = "gridColAutoID";
            this.gridColAutoID.OptionsColumn.AllowEdit = false;
            // 
            // gridCol选择
            // 
            this.gridCol选择.Caption = "选择";
            this.gridCol选择.ColumnEdit = this.ItemCheckEdit选择;
            this.gridCol选择.FieldName = "iChk";
            this.gridCol选择.Name = "gridCol选择";
            this.gridCol选择.Visible = true;
            this.gridCol选择.VisibleIndex = 0;
            this.gridCol选择.Width = 31;
            // 
            // ItemCheckEdit选择
            // 
            this.ItemCheckEdit选择.AutoHeight = false;
            this.ItemCheckEdit选择.Name = "ItemCheckEdit选择";
            this.ItemCheckEdit选择.CheckedChanged += new System.EventHandler(this.ItemCheckEdit选择_CheckedChanged);
            // 
            // gridCol单据号
            // 
            this.gridCol单据号.Caption = "单据号";
            this.gridCol单据号.FieldName = "cDLCode";
            this.gridCol单据号.Name = "gridCol单据号";
            this.gridCol单据号.OptionsColumn.AllowEdit = false;
            this.gridCol单据号.Visible = true;
            this.gridCol单据号.VisibleIndex = 1;
            this.gridCol单据号.Width = 86;
            // 
            // gridCol单据日期
            // 
            this.gridCol单据日期.Caption = "单据日期";
            this.gridCol单据日期.FieldName = "dDate";
            this.gridCol单据日期.Name = "gridCol单据日期";
            this.gridCol单据日期.OptionsColumn.AllowEdit = false;
            this.gridCol单据日期.Visible = true;
            this.gridCol单据日期.VisibleIndex = 2;
            // 
            // gridCol部门
            // 
            this.gridCol部门.Caption = "部门";
            this.gridCol部门.ColumnEdit = this.ItemLookUpEdit部门;
            this.gridCol部门.FieldName = "cDepCode";
            this.gridCol部门.Name = "gridCol部门";
            this.gridCol部门.OptionsColumn.AllowEdit = false;
            this.gridCol部门.Visible = true;
            this.gridCol部门.VisibleIndex = 17;
            this.gridCol部门.Width = 59;
            // 
            // ItemLookUpEdit部门
            // 
            this.ItemLookUpEdit部门.AutoHeight = false;
            this.ItemLookUpEdit部门.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.ItemLookUpEdit部门.Name = "ItemLookUpEdit部门";
            this.ItemLookUpEdit部门.NullText = "";
            this.ItemLookUpEdit部门.ValueMember = "PersonCode";
            // 
            // gridCol物料编码
            // 
            this.gridCol物料编码.Caption = "物料编码";
            this.gridCol物料编码.FieldName = "cInvCode";
            this.gridCol物料编码.Name = "gridCol物料编码";
            this.gridCol物料编码.OptionsColumn.AllowEdit = false;
            this.gridCol物料编码.Visible = true;
            this.gridCol物料编码.VisibleIndex = 4;
            this.gridCol物料编码.Width = 68;
            // 
            // gridCol物料名称
            // 
            this.gridCol物料名称.Caption = "物料名称";
            this.gridCol物料名称.ColumnEdit = this.ItemLookUpEdit物料名称;
            this.gridCol物料名称.FieldName = "cInvCode";
            this.gridCol物料名称.Name = "gridCol物料名称";
            this.gridCol物料名称.OptionsColumn.AllowEdit = false;
            this.gridCol物料名称.Visible = true;
            this.gridCol物料名称.VisibleIndex = 5;
            this.gridCol物料名称.Width = 105;
            // 
            // ItemLookUpEdit物料名称
            // 
            this.ItemLookUpEdit物料名称.AutoHeight = false;
            this.ItemLookUpEdit物料名称.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.ItemLookUpEdit物料名称.Name = "ItemLookUpEdit物料名称";
            // 
            // gridCol数量
            // 
            this.gridCol数量.Caption = "数量";
            this.gridCol数量.FieldName = "iQuantity";
            this.gridCol数量.Name = "gridCol数量";
            this.gridCol数量.OptionsColumn.AllowEdit = false;
            this.gridCol数量.Summary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] {
            new DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum)});
            this.gridCol数量.Visible = true;
            this.gridCol数量.VisibleIndex = 9;
            // 
            // gridCol盒数
            // 
            this.gridCol盒数.Caption = "盒数";
            this.gridCol盒数.FieldName = "sBoxQty";
            this.gridCol盒数.Name = "gridCol盒数";
            this.gridCol盒数.OptionsColumn.AllowEdit = false;
            this.gridCol盒数.Summary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] {
            new DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum)});
            this.gridCol盒数.Visible = true;
            this.gridCol盒数.VisibleIndex = 8;
            // 
            // gridCol备注
            // 
            this.gridCol备注.Caption = "备注";
            this.gridCol备注.FieldName = "Remark";
            this.gridCol备注.Name = "gridCol备注";
            this.gridCol备注.OptionsColumn.AllowEdit = false;
            this.gridCol备注.Visible = true;
            this.gridCol备注.VisibleIndex = 11;
            // 
            // gridCol制单人
            // 
            this.gridCol制单人.Caption = "制单人";
            this.gridCol制单人.FieldName = "dCreatesysPerson";
            this.gridCol制单人.Name = "gridCol制单人";
            this.gridCol制单人.OptionsColumn.AllowEdit = false;
            this.gridCol制单人.Visible = true;
            this.gridCol制单人.VisibleIndex = 12;
            // 
            // gridCol制单日期
            // 
            this.gridCol制单日期.Caption = "制单日期";
            this.gridCol制单日期.DisplayFormat.FormatString = "yyyy-MM-dd";
            this.gridCol制单日期.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.gridCol制单日期.FieldName = "dCreatesysTime";
            this.gridCol制单日期.Name = "gridCol制单日期";
            this.gridCol制单日期.OptionsColumn.AllowEdit = false;
            this.gridCol制单日期.Visible = true;
            this.gridCol制单日期.VisibleIndex = 13;
            // 
            // gridCol审核人
            // 
            this.gridCol审核人.Caption = "审核人";
            this.gridCol审核人.FieldName = "dVerifysysPerson";
            this.gridCol审核人.Name = "gridCol审核人";
            this.gridCol审核人.OptionsColumn.AllowEdit = false;
            this.gridCol审核人.Visible = true;
            this.gridCol审核人.VisibleIndex = 3;
            this.gridCol审核人.Width = 49;
            // 
            // gridCol审核日期
            // 
            this.gridCol审核日期.Caption = "审核日期";
            this.gridCol审核日期.DisplayFormat.FormatString = "yyyy-MM-dd";
            this.gridCol审核日期.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.gridCol审核日期.FieldName = "dVerifysysTime";
            this.gridCol审核日期.Name = "gridCol审核日期";
            this.gridCol审核日期.OptionsColumn.AllowEdit = false;
            this.gridCol审核日期.Visible = true;
            this.gridCol审核日期.VisibleIndex = 14;
            // 
            // gridCol关闭人
            // 
            this.gridCol关闭人.Caption = "关闭人";
            this.gridCol关闭人.FieldName = "dClosesysPerson";
            this.gridCol关闭人.Name = "gridCol关闭人";
            this.gridCol关闭人.OptionsColumn.AllowEdit = false;
            this.gridCol关闭人.Visible = true;
            this.gridCol关闭人.VisibleIndex = 15;
            // 
            // gridCol关闭日期
            // 
            this.gridCol关闭日期.Caption = "关闭日期";
            this.gridCol关闭日期.FieldName = "dClosesysTime";
            this.gridCol关闭日期.Name = "gridCol关闭日期";
            this.gridCol关闭日期.OptionsColumn.AllowEdit = false;
            this.gridCol关闭日期.Visible = true;
            this.gridCol关闭日期.VisibleIndex = 16;
            // 
            // gridColM1
            // 
            this.gridColM1.Caption = "色号";
            this.gridColM1.ColumnEdit = this.ItemLookUpEditM1;
            this.gridColM1.FieldName = "M1";
            this.gridColM1.Name = "gridColM1";
            this.gridColM1.OptionsColumn.AllowEdit = false;
            this.gridColM1.Visible = true;
            this.gridColM1.VisibleIndex = 6;
            this.gridColM1.Width = 53;
            // 
            // ItemLookUpEditM1
            // 
            this.ItemLookUpEditM1.AutoHeight = false;
            this.ItemLookUpEditM1.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.ItemLookUpEditM1.Name = "ItemLookUpEditM1";
            // 
            // gridColM2
            // 
            this.gridColM2.Caption = "缸号";
            this.gridColM2.FieldName = "M2";
            this.gridColM2.Name = "gridColM2";
            this.gridColM2.OptionsColumn.AllowEdit = false;
            this.gridColM2.Visible = true;
            this.gridColM2.VisibleIndex = 7;
            this.gridColM2.Width = 69;
            // 
            // gridCol已发货盒数
            // 
            this.gridCol已发货盒数.Caption = "已发货盒数";
            this.gridCol已发货盒数.FieldName = "已发货盒数";
            this.gridCol已发货盒数.Name = "gridCol已发货盒数";
            this.gridCol已发货盒数.OptionsColumn.AllowEdit = false;
            this.gridCol已发货盒数.Visible = true;
            this.gridCol已发货盒数.VisibleIndex = 10;
            // 
            // layoutControlGroup1
            // 
            this.layoutControlGroup1.CustomizationFormText = "layoutControlGroup1";
            this.layoutControlGroup1.EnableIndentsWithoutBorders = DevExpress.Utils.DefaultBoolean.True;
            this.layoutControlGroup1.GroupBordersVisible = false;
            this.layoutControlGroup1.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.layoutControlItem3,
            this.layoutControlItem1});
            this.layoutControlGroup1.Location = new System.Drawing.Point(0, 0);
            this.layoutControlGroup1.Name = "Root";
            this.layoutControlGroup1.Size = new System.Drawing.Size(1299, 574);
            this.layoutControlGroup1.Text = "Root";
            this.layoutControlGroup1.TextVisible = false;
            // 
            // layoutControlItem3
            // 
            this.layoutControlItem3.Control = this.gridControl1;
            this.layoutControlItem3.CustomizationFormText = "layoutControlItem3";
            this.layoutControlItem3.Location = new System.Drawing.Point(0, 23);
            this.layoutControlItem3.Name = "layoutControlItem3";
            this.layoutControlItem3.Size = new System.Drawing.Size(1279, 531);
            this.layoutControlItem3.Text = "layoutControlItem3";
            this.layoutControlItem3.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem3.TextToControlDistance = 0;
            this.layoutControlItem3.TextVisible = false;
            // 
            // layoutControlItem1
            // 
            this.layoutControlItem1.Control = this.checkEditChk;
            this.layoutControlItem1.CustomizationFormText = "layoutControlItem1";
            this.layoutControlItem1.Location = new System.Drawing.Point(0, 0);
            this.layoutControlItem1.Name = "layoutControlItem1";
            this.layoutControlItem1.Size = new System.Drawing.Size(1279, 23);
            this.layoutControlItem1.Text = "layoutControlItem1";
            this.layoutControlItem1.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem1.TextToControlDistance = 0;
            this.layoutControlItem1.TextVisible = false;
            // 
            // ItemLookUpEditSexID
            // 
            this.ItemLookUpEditSexID.AutoHeight = false;
            this.ItemLookUpEditSexID.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.ItemLookUpEditSexID.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("iID", "编号"),
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("iText", "类型")});
            this.ItemLookUpEditSexID.DisplayMember = "iText";
            this.ItemLookUpEditSexID.Name = "ItemLookUpEditSexID";
            this.ItemLookUpEditSexID.NullText = "";
            this.ItemLookUpEditSexID.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.Standard;
            this.ItemLookUpEditSexID.ValueMember = "iID";
            // 
            // ItemLookUpEditDept
            // 
            this.ItemLookUpEditDept.AutoHeight = false;
            this.ItemLookUpEditDept.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.ItemLookUpEditDept.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("iID", "序号"),
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("iText", "状态")});
            this.ItemLookUpEditDept.DisplayMember = "iText";
            this.ItemLookUpEditDept.Name = "ItemLookUpEditDept";
            this.ItemLookUpEditDept.NullText = "";
            this.ItemLookUpEditDept.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.Standard;
            this.ItemLookUpEditDept.ValueMember = "iID";
            // 
            // Frm销售发货单列表
            // 
            this.Appearance.BackColor = System.Drawing.SystemColors.Control;
            this.Appearance.Options.UseBackColor = true;
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1292, 603);
            this.Controls.Add(this.layoutControl1);
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "Frm销售发货单列表";
            this.Text = "销售发货单列表";
            this.Load += new System.EventHandler(this.Frm销售发货单列表_Load);
            this.Controls.SetChildIndex(this.layoutControl1, 0);
            ((System.ComponentModel.ISupportInitialize)(this.dsPrint)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dsPrint2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dsForm)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtSel)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControl1)).EndInit();
            this.layoutControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.checkEditChk.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ItemCheckEdit选择)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ItemLookUpEdit部门)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ItemLookUpEdit物料名称)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ItemLookUpEditM1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ItemLookUpEditSexID)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ItemLookUpEditDept)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraLayout.LayoutControl layoutControl1;
        private DevExpress.XtraGrid.GridControl gridControl1;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView1;
        private DevExpress.XtraLayout.LayoutControlGroup layoutControlGroup1;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem3;
        private DevExpress.XtraGrid.Columns.GridColumn gridCol部门;
        private DevExpress.XtraGrid.Columns.GridColumn gridCol选择;
        private DevExpress.XtraGrid.Columns.GridColumn gridCol备注;
        private DevExpress.XtraGrid.Columns.GridColumn gridColAutoID;
        private DevExpress.XtraGrid.Columns.GridColumn gridCol物料编码;
        private DevExpress.XtraGrid.Columns.GridColumn gridCol物料名称;
        private DevExpress.XtraGrid.Columns.GridColumn gridCol单据号;
        private DevExpress.XtraGrid.Columns.GridColumn gridCol数量;
        private DevExpress.XtraGrid.Columns.GridColumn gridCol盒数;
        private DevExpress.XtraGrid.Columns.GridColumn gridCol制单人;
        private DevExpress.XtraGrid.Columns.GridColumn gridCol制单日期;
        private DevExpress.XtraGrid.Columns.GridColumn gridCol审核人;
        private DevExpress.XtraGrid.Columns.GridColumn gridCol审核日期;
        private DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit ItemLookUpEditSexID;
        private DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit ItemLookUpEditDept;
        private DevExpress.XtraEditors.CheckEdit checkEditChk;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem1;
        private DevExpress.XtraGrid.Columns.GridColumn gridColID;
        private DevExpress.XtraGrid.Columns.GridColumn gridCol关闭人;
        private DevExpress.XtraGrid.Columns.GridColumn gridCol关闭日期;
        private DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit ItemLookUpEdit部门;
        private DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit ItemCheckEdit选择;
        private DevExpress.XtraGrid.Columns.GridColumn gridCol单据日期;
        private DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit ItemLookUpEdit物料名称;
        private DevExpress.XtraGrid.Columns.GridColumn gridColM1;
        private DevExpress.XtraGrid.Columns.GridColumn gridColM2;
        private DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit ItemLookUpEditM1;
        private DevExpress.XtraGrid.Columns.GridColumn gridCol已发货盒数;
    }
}