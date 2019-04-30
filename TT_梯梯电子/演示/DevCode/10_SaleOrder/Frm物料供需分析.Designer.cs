namespace SaleOrder
{
    partial class Frm物料供需分析
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
            this.gridControl1 = new DevExpress.XtraGrid.GridControl();
            this.gridView1 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.gridCol存货编码 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.ItemLookUpEdit存货编码 = new DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit();
            this.gridCol存货名称 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.ItemLookUpEdit存货名称 = new DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit();
            this.gridCol规格型号 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.ItemLookUpEdit规格型号 = new DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit();
            this.gridCol现存量 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridCol供需类型 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridCol采购数 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridCol委外数 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridCol生产数 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridCol待入库 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridCol待出库 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridCol供需日期 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridCol单据号 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridCol需求数 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridCol外销单号 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.layoutControlGroup1 = new DevExpress.XtraLayout.LayoutControlGroup();
            this.layoutControlItem12 = new DevExpress.XtraLayout.LayoutControlItem();
            this.btnOK = new System.Windows.Forms.Button();
            this.btnSEL = new System.Windows.Forms.Button();
            this.btnExport = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControl1)).BeginInit();
            this.layoutControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ItemLookUpEdit存货编码)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ItemLookUpEdit存货名称)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ItemLookUpEdit规格型号)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem12)).BeginInit();
            this.SuspendLayout();
            // 
            // layoutControl1
            // 
            this.layoutControl1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.layoutControl1.Controls.Add(this.gridControl1);
            this.layoutControl1.Location = new System.Drawing.Point(12, 12);
            this.layoutControl1.Name = "layoutControl1";
            this.layoutControl1.OptionsCustomizationForm.DesignTimeCustomizationFormPositionAndSize = new System.Drawing.Rectangle(197, 251, 250, 350);
            this.layoutControl1.Root = this.layoutControlGroup1;
            this.layoutControl1.Size = new System.Drawing.Size(1164, 417);
            this.layoutControl1.TabIndex = 0;
            this.layoutControl1.Text = "layoutControl1";
            // 
            // gridControl1
            // 
            this.gridControl1.Location = new System.Drawing.Point(12, 33);
            this.gridControl1.MainView = this.gridView1;
            this.gridControl1.Name = "gridControl1";
            this.gridControl1.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.ItemLookUpEdit存货编码,
            this.ItemLookUpEdit存货名称,
            this.ItemLookUpEdit规格型号});
            this.gridControl1.Size = new System.Drawing.Size(1140, 372);
            this.gridControl1.TabIndex = 7;
            this.gridControl1.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView1});
            // 
            // gridView1
            // 
            this.gridView1.Appearance.ColumnFilterButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(236)))), ((int)(((byte)(232)))), ((int)(((byte)(201)))));
            this.gridView1.Appearance.ColumnFilterButton.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(236)))), ((int)(((byte)(232)))), ((int)(((byte)(201)))));
            this.gridView1.Appearance.ColumnFilterButton.ForeColor = System.Drawing.Color.Black;
            this.gridView1.Appearance.ColumnFilterButton.Options.UseBackColor = true;
            this.gridView1.Appearance.ColumnFilterButton.Options.UseBorderColor = true;
            this.gridView1.Appearance.ColumnFilterButton.Options.UseForeColor = true;
            this.gridView1.Appearance.ColumnFilterButtonActive.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(221)))), ((int)(((byte)(231)))), ((int)(((byte)(234)))));
            this.gridView1.Appearance.ColumnFilterButtonActive.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(221)))), ((int)(((byte)(231)))), ((int)(((byte)(234)))));
            this.gridView1.Appearance.ColumnFilterButtonActive.ForeColor = System.Drawing.Color.Black;
            this.gridView1.Appearance.ColumnFilterButtonActive.Options.UseBackColor = true;
            this.gridView1.Appearance.ColumnFilterButtonActive.Options.UseBorderColor = true;
            this.gridView1.Appearance.ColumnFilterButtonActive.Options.UseForeColor = true;
            this.gridView1.Appearance.Empty.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(236)))), ((int)(((byte)(232)))), ((int)(((byte)(201)))));
            this.gridView1.Appearance.Empty.BackColor2 = System.Drawing.Color.White;
            this.gridView1.Appearance.Empty.Options.UseBackColor = true;
            this.gridView1.Appearance.EvenRow.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(221)))), ((int)(((byte)(231)))), ((int)(((byte)(234)))));
            this.gridView1.Appearance.EvenRow.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(221)))), ((int)(((byte)(231)))), ((int)(((byte)(234)))));
            this.gridView1.Appearance.EvenRow.ForeColor = System.Drawing.Color.Black;
            this.gridView1.Appearance.EvenRow.Options.UseBackColor = true;
            this.gridView1.Appearance.EvenRow.Options.UseBorderColor = true;
            this.gridView1.Appearance.EvenRow.Options.UseForeColor = true;
            this.gridView1.Appearance.FilterCloseButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(216)))), ((int)(((byte)(209)))), ((int)(((byte)(179)))));
            this.gridView1.Appearance.FilterCloseButton.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(216)))), ((int)(((byte)(209)))), ((int)(((byte)(179)))));
            this.gridView1.Appearance.FilterCloseButton.ForeColor = System.Drawing.Color.Black;
            this.gridView1.Appearance.FilterCloseButton.Options.UseBackColor = true;
            this.gridView1.Appearance.FilterCloseButton.Options.UseBorderColor = true;
            this.gridView1.Appearance.FilterCloseButton.Options.UseForeColor = true;
            this.gridView1.Appearance.FilterPanel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(236)))), ((int)(((byte)(232)))), ((int)(((byte)(201)))));
            this.gridView1.Appearance.FilterPanel.BackColor2 = System.Drawing.Color.White;
            this.gridView1.Appearance.FilterPanel.ForeColor = System.Drawing.Color.Black;
            this.gridView1.Appearance.FilterPanel.Options.UseBackColor = true;
            this.gridView1.Appearance.FilterPanel.Options.UseForeColor = true;
            this.gridView1.Appearance.FixedLine.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(122)))), ((int)(((byte)(114)))), ((int)(((byte)(113)))));
            this.gridView1.Appearance.FixedLine.Options.UseBackColor = true;
            this.gridView1.Appearance.FocusedCell.BackColor = System.Drawing.Color.White;
            this.gridView1.Appearance.FocusedCell.ForeColor = System.Drawing.Color.Black;
            this.gridView1.Appearance.FocusedCell.Options.UseBackColor = true;
            this.gridView1.Appearance.FocusedCell.Options.UseForeColor = true;
            this.gridView1.Appearance.FocusedRow.BackColor = System.Drawing.Color.Lime;
            this.gridView1.Appearance.FocusedRow.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(219)))), ((int)(((byte)(188)))));
            this.gridView1.Appearance.FocusedRow.ForeColor = System.Drawing.Color.Black;
            this.gridView1.Appearance.FocusedRow.Options.UseBackColor = true;
            this.gridView1.Appearance.FocusedRow.Options.UseBorderColor = true;
            this.gridView1.Appearance.FocusedRow.Options.UseForeColor = true;
            this.gridView1.Appearance.FooterPanel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(216)))), ((int)(((byte)(209)))), ((int)(((byte)(170)))));
            this.gridView1.Appearance.FooterPanel.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(216)))), ((int)(((byte)(209)))), ((int)(((byte)(170)))));
            this.gridView1.Appearance.FooterPanel.ForeColor = System.Drawing.Color.Black;
            this.gridView1.Appearance.FooterPanel.Options.UseBackColor = true;
            this.gridView1.Appearance.FooterPanel.Options.UseBorderColor = true;
            this.gridView1.Appearance.FooterPanel.Options.UseForeColor = true;
            this.gridView1.Appearance.GroupButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(216)))), ((int)(((byte)(209)))), ((int)(((byte)(179)))));
            this.gridView1.Appearance.GroupButton.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(216)))), ((int)(((byte)(209)))), ((int)(((byte)(179)))));
            this.gridView1.Appearance.GroupButton.Options.UseBackColor = true;
            this.gridView1.Appearance.GroupButton.Options.UseBorderColor = true;
            this.gridView1.Appearance.GroupFooter.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(236)))), ((int)(((byte)(232)))), ((int)(((byte)(201)))));
            this.gridView1.Appearance.GroupFooter.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(236)))), ((int)(((byte)(232)))), ((int)(((byte)(201)))));
            this.gridView1.Appearance.GroupFooter.ForeColor = System.Drawing.Color.Black;
            this.gridView1.Appearance.GroupFooter.Options.UseBackColor = true;
            this.gridView1.Appearance.GroupFooter.Options.UseBorderColor = true;
            this.gridView1.Appearance.GroupFooter.Options.UseForeColor = true;
            this.gridView1.Appearance.GroupPanel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(246)))), ((int)(((byte)(242)))), ((int)(((byte)(213)))));
            this.gridView1.Appearance.GroupPanel.BackColor2 = System.Drawing.Color.White;
            this.gridView1.Appearance.GroupPanel.ForeColor = System.Drawing.Color.Black;
            this.gridView1.Appearance.GroupPanel.Options.UseBackColor = true;
            this.gridView1.Appearance.GroupPanel.Options.UseForeColor = true;
            this.gridView1.Appearance.GroupRow.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(236)))), ((int)(((byte)(232)))), ((int)(((byte)(201)))));
            this.gridView1.Appearance.GroupRow.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(236)))), ((int)(((byte)(232)))), ((int)(((byte)(201)))));
            this.gridView1.Appearance.GroupRow.ForeColor = System.Drawing.Color.Black;
            this.gridView1.Appearance.GroupRow.Options.UseBackColor = true;
            this.gridView1.Appearance.GroupRow.Options.UseBorderColor = true;
            this.gridView1.Appearance.GroupRow.Options.UseForeColor = true;
            this.gridView1.Appearance.HeaderPanel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(216)))), ((int)(((byte)(209)))), ((int)(((byte)(170)))));
            this.gridView1.Appearance.HeaderPanel.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(216)))), ((int)(((byte)(209)))), ((int)(((byte)(170)))));
            this.gridView1.Appearance.HeaderPanel.ForeColor = System.Drawing.Color.Black;
            this.gridView1.Appearance.HeaderPanel.Options.UseBackColor = true;
            this.gridView1.Appearance.HeaderPanel.Options.UseBorderColor = true;
            this.gridView1.Appearance.HeaderPanel.Options.UseForeColor = true;
            this.gridView1.Appearance.HideSelectionRow.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(237)))), ((int)(((byte)(230)))), ((int)(((byte)(203)))));
            this.gridView1.Appearance.HideSelectionRow.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(237)))), ((int)(((byte)(230)))), ((int)(((byte)(203)))));
            this.gridView1.Appearance.HideSelectionRow.ForeColor = System.Drawing.Color.Black;
            this.gridView1.Appearance.HideSelectionRow.Options.UseBackColor = true;
            this.gridView1.Appearance.HideSelectionRow.Options.UseBorderColor = true;
            this.gridView1.Appearance.HideSelectionRow.Options.UseForeColor = true;
            this.gridView1.Appearance.HorzLine.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(216)))), ((int)(((byte)(209)))), ((int)(((byte)(170)))));
            this.gridView1.Appearance.HorzLine.Options.UseBackColor = true;
            this.gridView1.Appearance.OddRow.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(242)))), ((int)(((byte)(244)))), ((int)(((byte)(236)))));
            this.gridView1.Appearance.OddRow.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(242)))), ((int)(((byte)(244)))), ((int)(((byte)(236)))));
            this.gridView1.Appearance.OddRow.ForeColor = System.Drawing.Color.Black;
            this.gridView1.Appearance.OddRow.Options.UseBackColor = true;
            this.gridView1.Appearance.OddRow.Options.UseBorderColor = true;
            this.gridView1.Appearance.OddRow.Options.UseForeColor = true;
            this.gridView1.Appearance.Preview.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(251)))), ((int)(((byte)(252)))), ((int)(((byte)(247)))));
            this.gridView1.Appearance.Preview.Font = new System.Drawing.Font("Verdana", 7.5F);
            this.gridView1.Appearance.Preview.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(148)))), ((int)(((byte)(148)))), ((int)(((byte)(148)))));
            this.gridView1.Appearance.Preview.Options.UseBackColor = true;
            this.gridView1.Appearance.Preview.Options.UseFont = true;
            this.gridView1.Appearance.Preview.Options.UseForeColor = true;
            this.gridView1.Appearance.Row.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(242)))), ((int)(((byte)(244)))), ((int)(((byte)(236)))));
            this.gridView1.Appearance.Row.ForeColor = System.Drawing.Color.Black;
            this.gridView1.Appearance.Row.Options.UseBackColor = true;
            this.gridView1.Appearance.Row.Options.UseForeColor = true;
            this.gridView1.Appearance.RowSeparator.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(236)))), ((int)(((byte)(232)))), ((int)(((byte)(201)))));
            this.gridView1.Appearance.RowSeparator.BackColor2 = System.Drawing.Color.White;
            this.gridView1.Appearance.RowSeparator.Options.UseBackColor = true;
            this.gridView1.Appearance.SelectedRow.BackColor = System.Drawing.Color.Lime;
            this.gridView1.Appearance.SelectedRow.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(237)))), ((int)(((byte)(230)))), ((int)(((byte)(203)))));
            this.gridView1.Appearance.SelectedRow.ForeColor = System.Drawing.Color.Black;
            this.gridView1.Appearance.SelectedRow.Options.UseBackColor = true;
            this.gridView1.Appearance.SelectedRow.Options.UseBorderColor = true;
            this.gridView1.Appearance.SelectedRow.Options.UseForeColor = true;
            this.gridView1.Appearance.TopNewRow.BackColor = System.Drawing.Color.White;
            this.gridView1.Appearance.TopNewRow.Options.UseBackColor = true;
            this.gridView1.Appearance.VertLine.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(216)))), ((int)(((byte)(209)))), ((int)(((byte)(170)))));
            this.gridView1.Appearance.VertLine.Options.UseBackColor = true;
            this.gridView1.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.gridCol存货编码,
            this.gridCol存货名称,
            this.gridCol规格型号,
            this.gridCol现存量,
            this.gridCol供需类型,
            this.gridCol采购数,
            this.gridCol委外数,
            this.gridCol生产数,
            this.gridCol待入库,
            this.gridCol待出库,
            this.gridCol供需日期,
            this.gridCol单据号,
            this.gridCol需求数,
            this.gridCol外销单号});
            this.gridView1.GridControl = this.gridControl1;
            this.gridView1.IndicatorWidth = 40;
            this.gridView1.Name = "gridView1";
            this.gridView1.OptionsBehavior.Editable = false;
            this.gridView1.OptionsLayout.Columns.StoreAllOptions = true;
            this.gridView1.OptionsLayout.Columns.StoreAppearance = true;
            this.gridView1.OptionsLayout.StoreAllOptions = true;
            this.gridView1.OptionsLayout.StoreAppearance = true;
            this.gridView1.OptionsMenu.ShowAddNewSummaryItem = DevExpress.Utils.DefaultBoolean.True;
            this.gridView1.OptionsMenu.ShowGroupSummaryEditorItem = true;
            this.gridView1.OptionsNavigation.EnterMoveNextColumn = true;
            this.gridView1.OptionsSelection.MultiSelect = true;
            this.gridView1.OptionsView.AllowCellMerge = true;
            this.gridView1.OptionsView.AutoCalcPreviewLineCount = true;
            this.gridView1.OptionsView.ColumnAutoWidth = false;
            this.gridView1.OptionsView.EnableAppearanceEvenRow = true;
            this.gridView1.OptionsView.EnableAppearanceOddRow = true;
            this.gridView1.OptionsView.ShowFooter = true;
            this.gridView1.OptionsView.ShowGroupPanel = false;
            // 
            // gridCol存货编码
            // 
            this.gridCol存货编码.Caption = "存货编码";
            this.gridCol存货编码.ColumnEdit = this.ItemLookUpEdit存货编码;
            this.gridCol存货编码.FieldName = "存货编码";
            this.gridCol存货编码.Name = "gridCol存货编码";
            this.gridCol存货编码.OptionsColumn.AllowEdit = false;
            this.gridCol存货编码.OptionsColumn.AllowMerge = DevExpress.Utils.DefaultBoolean.True;
            this.gridCol存货编码.Visible = true;
            this.gridCol存货编码.VisibleIndex = 0;
            this.gridCol存货编码.Width = 116;
            // 
            // ItemLookUpEdit存货编码
            // 
            this.ItemLookUpEdit存货编码.AutoHeight = false;
            this.ItemLookUpEdit存货编码.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.ItemLookUpEdit存货编码.DisplayMember = "存货编码";
            this.ItemLookUpEdit存货编码.Name = "ItemLookUpEdit存货编码";
            this.ItemLookUpEdit存货编码.NullText = "";
            this.ItemLookUpEdit存货编码.ValueMember = "存货编码";
            // 
            // gridCol存货名称
            // 
            this.gridCol存货名称.Caption = "存货名称";
            this.gridCol存货名称.ColumnEdit = this.ItemLookUpEdit存货名称;
            this.gridCol存货名称.FieldName = "存货编码";
            this.gridCol存货名称.Name = "gridCol存货名称";
            this.gridCol存货名称.OptionsColumn.AllowEdit = false;
            this.gridCol存货名称.OptionsColumn.AllowMerge = DevExpress.Utils.DefaultBoolean.True;
            this.gridCol存货名称.Visible = true;
            this.gridCol存货名称.VisibleIndex = 1;
            this.gridCol存货名称.Width = 143;
            // 
            // ItemLookUpEdit存货名称
            // 
            this.ItemLookUpEdit存货名称.AutoHeight = false;
            this.ItemLookUpEdit存货名称.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.ItemLookUpEdit存货名称.DisplayMember = "存货名称";
            this.ItemLookUpEdit存货名称.Name = "ItemLookUpEdit存货名称";
            this.ItemLookUpEdit存货名称.NullText = "";
            this.ItemLookUpEdit存货名称.ValueMember = "存货编码";
            // 
            // gridCol规格型号
            // 
            this.gridCol规格型号.Caption = "规格型号";
            this.gridCol规格型号.ColumnEdit = this.ItemLookUpEdit规格型号;
            this.gridCol规格型号.FieldName = "规格型号";
            this.gridCol规格型号.Name = "gridCol规格型号";
            this.gridCol规格型号.OptionsColumn.AllowEdit = false;
            this.gridCol规格型号.OptionsColumn.AllowMerge = DevExpress.Utils.DefaultBoolean.True;
            this.gridCol规格型号.Visible = true;
            this.gridCol规格型号.VisibleIndex = 2;
            this.gridCol规格型号.Width = 118;
            // 
            // ItemLookUpEdit规格型号
            // 
            this.ItemLookUpEdit规格型号.AutoHeight = false;
            this.ItemLookUpEdit规格型号.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.ItemLookUpEdit规格型号.DisplayMember = "规格型号";
            this.ItemLookUpEdit规格型号.Name = "ItemLookUpEdit规格型号";
            this.ItemLookUpEdit规格型号.NullText = "";
            this.ItemLookUpEdit规格型号.ValueMember = "存货编码";
            // 
            // gridCol现存量
            // 
            this.gridCol现存量.Caption = "现存量";
            this.gridCol现存量.FieldName = "现存量";
            this.gridCol现存量.Name = "gridCol现存量";
            this.gridCol现存量.OptionsColumn.AllowEdit = false;
            this.gridCol现存量.OptionsColumn.AllowMerge = DevExpress.Utils.DefaultBoolean.False;
            this.gridCol现存量.Summary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] {
            new DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum)});
            this.gridCol现存量.Visible = true;
            this.gridCol现存量.VisibleIndex = 7;
            this.gridCol现存量.Width = 104;
            // 
            // gridCol供需类型
            // 
            this.gridCol供需类型.Caption = "供需类型";
            this.gridCol供需类型.FieldName = "供需类型";
            this.gridCol供需类型.Name = "gridCol供需类型";
            this.gridCol供需类型.OptionsColumn.AllowEdit = false;
            this.gridCol供需类型.OptionsColumn.AllowMerge = DevExpress.Utils.DefaultBoolean.False;
            this.gridCol供需类型.Visible = true;
            this.gridCol供需类型.VisibleIndex = 3;
            this.gridCol供需类型.Width = 84;
            // 
            // gridCol采购数
            // 
            this.gridCol采购数.Caption = "采购数";
            this.gridCol采购数.FieldName = "采购数";
            this.gridCol采购数.Name = "gridCol采购数";
            this.gridCol采购数.OptionsColumn.AllowEdit = false;
            this.gridCol采购数.OptionsColumn.AllowMerge = DevExpress.Utils.DefaultBoolean.False;
            this.gridCol采购数.Summary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] {
            new DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum)});
            // 
            // gridCol委外数
            // 
            this.gridCol委外数.Caption = "委外数";
            this.gridCol委外数.FieldName = "委外数";
            this.gridCol委外数.Name = "gridCol委外数";
            this.gridCol委外数.OptionsColumn.AllowEdit = false;
            this.gridCol委外数.OptionsColumn.AllowMerge = DevExpress.Utils.DefaultBoolean.False;
            this.gridCol委外数.Summary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] {
            new DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum)});
            this.gridCol委外数.Width = 76;
            // 
            // gridCol生产数
            // 
            this.gridCol生产数.Caption = "生产数";
            this.gridCol生产数.FieldName = "生产数";
            this.gridCol生产数.Name = "gridCol生产数";
            this.gridCol生产数.OptionsColumn.AllowEdit = false;
            this.gridCol生产数.OptionsColumn.AllowMerge = DevExpress.Utils.DefaultBoolean.False;
            this.gridCol生产数.Summary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] {
            new DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum)});
            this.gridCol生产数.Width = 94;
            // 
            // gridCol待入库
            // 
            this.gridCol待入库.Caption = "待入库";
            this.gridCol待入库.FieldName = "待入库";
            this.gridCol待入库.Name = "gridCol待入库";
            this.gridCol待入库.OptionsColumn.AllowEdit = false;
            this.gridCol待入库.OptionsColumn.AllowMerge = DevExpress.Utils.DefaultBoolean.False;
            this.gridCol待入库.Summary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] {
            new DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum)});
            this.gridCol待入库.Visible = true;
            this.gridCol待入库.VisibleIndex = 8;
            this.gridCol待入库.Width = 107;
            // 
            // gridCol待出库
            // 
            this.gridCol待出库.Caption = "待出库";
            this.gridCol待出库.FieldName = "待出库";
            this.gridCol待出库.Name = "gridCol待出库";
            this.gridCol待出库.OptionsColumn.AllowEdit = false;
            this.gridCol待出库.OptionsColumn.AllowMerge = DevExpress.Utils.DefaultBoolean.False;
            this.gridCol待出库.Summary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] {
            new DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum)});
            this.gridCol待出库.Visible = true;
            this.gridCol待出库.VisibleIndex = 9;
            this.gridCol待出库.Width = 125;
            // 
            // gridCol供需日期
            // 
            this.gridCol供需日期.Caption = "供需日期";
            this.gridCol供需日期.FieldName = "供需日期";
            this.gridCol供需日期.Name = "gridCol供需日期";
            this.gridCol供需日期.OptionsColumn.AllowEdit = false;
            this.gridCol供需日期.OptionsColumn.AllowMerge = DevExpress.Utils.DefaultBoolean.False;
            this.gridCol供需日期.Visible = true;
            this.gridCol供需日期.VisibleIndex = 6;
            this.gridCol供需日期.Width = 90;
            // 
            // gridCol单据号
            // 
            this.gridCol单据号.Caption = "单据号";
            this.gridCol单据号.FieldName = "单据号";
            this.gridCol单据号.Name = "gridCol单据号";
            this.gridCol单据号.OptionsColumn.AllowEdit = false;
            this.gridCol单据号.Visible = true;
            this.gridCol单据号.VisibleIndex = 4;
            this.gridCol单据号.Width = 102;
            // 
            // gridCol需求数
            // 
            this.gridCol需求数.Caption = "需求数";
            this.gridCol需求数.FieldName = "需求数";
            this.gridCol需求数.Name = "gridCol需求数";
            this.gridCol需求数.OptionsColumn.AllowEdit = false;
            this.gridCol需求数.OptionsColumn.AllowMerge = DevExpress.Utils.DefaultBoolean.False;
            this.gridCol需求数.Summary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] {
            new DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum)});
            // 
            // gridCol外销单号
            // 
            this.gridCol外销单号.Caption = "外销单号";
            this.gridCol外销单号.FieldName = "外销单号";
            this.gridCol外销单号.Name = "gridCol外销单号";
            this.gridCol外销单号.OptionsColumn.AllowEdit = false;
            this.gridCol外销单号.Visible = true;
            this.gridCol外销单号.VisibleIndex = 5;
            this.gridCol外销单号.Width = 96;
            // 
            // layoutControlGroup1
            // 
            this.layoutControlGroup1.CustomizationFormText = "layoutControlGroup1";
            this.layoutControlGroup1.EnableIndentsWithoutBorders = DevExpress.Utils.DefaultBoolean.True;
            this.layoutControlGroup1.GroupBordersVisible = false;
            this.layoutControlGroup1.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.layoutControlItem12});
            this.layoutControlGroup1.Location = new System.Drawing.Point(0, 0);
            this.layoutControlGroup1.Name = "Root";
            this.layoutControlGroup1.Size = new System.Drawing.Size(1164, 417);
            this.layoutControlGroup1.Text = "Root";
            this.layoutControlGroup1.TextVisible = false;
            // 
            // layoutControlItem12
            // 
            this.layoutControlItem12.Control = this.gridControl1;
            this.layoutControlItem12.CustomizationFormText = "layoutControlItem12";
            this.layoutControlItem12.Location = new System.Drawing.Point(0, 0);
            this.layoutControlItem12.Name = "layoutControlItem12";
            this.layoutControlItem12.Size = new System.Drawing.Size(1144, 397);
            this.layoutControlItem12.Text = "查询列表";
            this.layoutControlItem12.TextLocation = DevExpress.Utils.Locations.Top;
            this.layoutControlItem12.TextSize = new System.Drawing.Size(60, 18);
            // 
            // btnOK
            // 
            this.btnOK.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnOK.Location = new System.Drawing.Point(1089, 438);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(75, 23);
            this.btnOK.TabIndex = 1;
            this.btnOK.Text = "确 定";
            this.btnOK.UseVisualStyleBackColor = true;
            this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
            // 
            // btnSEL
            // 
            this.btnSEL.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSEL.Location = new System.Drawing.Point(1012, 438);
            this.btnSEL.Name = "btnSEL";
            this.btnSEL.Size = new System.Drawing.Size(62, 23);
            this.btnSEL.TabIndex = 3;
            this.btnSEL.Text = "刷 新";
            this.btnSEL.UseVisualStyleBackColor = true;
            this.btnSEL.Click += new System.EventHandler(this.btnSEL_Click);
            // 
            // btnExport
            // 
            this.btnExport.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnExport.Location = new System.Drawing.Point(927, 438);
            this.btnExport.Name = "btnExport";
            this.btnExport.Size = new System.Drawing.Size(62, 23);
            this.btnExport.TabIndex = 4;
            this.btnExport.Text = "输 出";
            this.btnExport.UseVisualStyleBackColor = true;
            this.btnExport.Click += new System.EventHandler(this.btnExport_Click);
            // 
            // Frm物料供需分析
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1186, 485);
            this.Controls.Add(this.btnExport);
            this.Controls.Add(this.btnSEL);
            this.Controls.Add(this.btnOK);
            this.Controls.Add(this.layoutControl1);
            this.Name = "Frm物料供需分析";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "查询";
            this.Load += new System.EventHandler(this.Frm物料供需分析_Load);
            ((System.ComponentModel.ISupportInitialize)(this.layoutControl1)).EndInit();
            this.layoutControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ItemLookUpEdit存货编码)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ItemLookUpEdit存货名称)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ItemLookUpEdit规格型号)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem12)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraLayout.LayoutControl layoutControl1;
        private DevExpress.XtraLayout.LayoutControlGroup layoutControlGroup1;
        private System.Windows.Forms.Button btnOK;
        private DevExpress.XtraGrid.GridControl gridControl1;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView1;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem12;
        private System.Windows.Forms.Button btnSEL;
        private DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit ItemLookUpEdit存货编码;
        private DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit ItemLookUpEdit存货名称;
        private DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit ItemLookUpEdit规格型号;
        private DevExpress.XtraGrid.Columns.GridColumn gridCol存货编码;
        private DevExpress.XtraGrid.Columns.GridColumn gridCol存货名称;
        private DevExpress.XtraGrid.Columns.GridColumn gridCol规格型号;
        private DevExpress.XtraGrid.Columns.GridColumn gridCol现存量;
        private DevExpress.XtraGrid.Columns.GridColumn gridCol采购数;
        private DevExpress.XtraGrid.Columns.GridColumn gridCol供需类型;
        private DevExpress.XtraGrid.Columns.GridColumn gridCol委外数;
        private DevExpress.XtraGrid.Columns.GridColumn gridCol生产数;
        private DevExpress.XtraGrid.Columns.GridColumn gridCol待入库;
        private DevExpress.XtraGrid.Columns.GridColumn gridCol待出库;
        private DevExpress.XtraGrid.Columns.GridColumn gridCol供需日期;
        private DevExpress.XtraGrid.Columns.GridColumn gridCol单据号;
        private DevExpress.XtraGrid.Columns.GridColumn gridCol需求数;
        private DevExpress.XtraGrid.Columns.GridColumn gridCol外销单号;
        private System.Windows.Forms.Button btnExport;
    }
}