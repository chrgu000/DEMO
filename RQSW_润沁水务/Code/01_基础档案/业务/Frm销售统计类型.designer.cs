﻿namespace 基础设置
{
    partial class Frm销售统计类型
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
            this.gridColCode = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.ItemLookUpEdit收发标志 = new DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit();
            this.gridColRemark = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColiSave = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColiID = new DevExpress.XtraGrid.Columns.GridColumn();
            this.ItemLookUpEdit关联类别 = new DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit();
            this.gridCol是否减少应收款 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.ItemCheckEdit是否影响应收款 = new DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit();
            this.gridCol是否影响出货量 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.ItemCheckEdit是否影响出货量 = new DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit();
            this.gridCol是否影响利润 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.ItemCheckEdit是否影响利润 = new DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit();
            this.gridCol是否影响退回率 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.ItemCheckEdit是否影响退回率 = new DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit();
            this.gridCol是否影响样品率 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.ItemCheckEdit是否影响样品率 = new DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit();
            this.layoutControlGroup1 = new DevExpress.XtraLayout.LayoutControlGroup();
            this.layoutControlItem3 = new DevExpress.XtraLayout.LayoutControlItem();
            ((System.ComponentModel.ISupportInitialize)(this.dsPrint)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dsForm)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtSel)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControl1)).BeginInit();
            this.layoutControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ItemLookUpEdit收发标志)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ItemLookUpEdit关联类别)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ItemCheckEdit是否影响应收款)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ItemCheckEdit是否影响出货量)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ItemCheckEdit是否影响利润)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ItemCheckEdit是否影响退回率)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ItemCheckEdit是否影响样品率)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem3)).BeginInit();
            this.SuspendLayout();
            // 
            // layoutControl1
            // 
            this.layoutControl1.AllowCustomizationMenu = false;
            this.layoutControl1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.layoutControl1.Controls.Add(this.gridControl1);
            this.layoutControl1.Location = new System.Drawing.Point(0, 28);
            this.layoutControl1.Name = "layoutControl1";
            this.layoutControl1.OptionsCustomizationForm.DesignTimeCustomizationFormPositionAndSize = new System.Drawing.Rectangle(210, 239, 250, 350);
            this.layoutControl1.OptionsCustomizationForm.ShowLoadButton = false;
            this.layoutControl1.OptionsCustomizationForm.ShowSaveButton = false;
            this.layoutControl1.OptionsView.UseDefaultDragAndDropRendering = false;
            this.layoutControl1.Root = this.layoutControlGroup1;
            this.layoutControl1.Size = new System.Drawing.Size(856, 277);
            this.layoutControl1.TabIndex = 5;
            this.layoutControl1.Text = "layoutControl1";
            // 
            // gridControl1
            // 
            this.gridControl1.Location = new System.Drawing.Point(12, 12);
            this.gridControl1.MainView = this.gridView1;
            this.gridControl1.Name = "gridControl1";
            this.gridControl1.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.ItemLookUpEdit收发标志,
            this.ItemLookUpEdit关联类别,
            this.ItemCheckEdit是否影响应收款,
            this.ItemCheckEdit是否影响出货量,
            this.ItemCheckEdit是否影响利润,
            this.ItemCheckEdit是否影响退回率,
            this.ItemCheckEdit是否影响样品率});
            this.gridControl1.Size = new System.Drawing.Size(832, 253);
            this.gridControl1.TabIndex = 6;
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
            this.gridView1.Appearance.FocusedRow.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(200)))), ((int)(((byte)(192)))), ((int)(((byte)(157)))));
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
            this.gridView1.Appearance.SelectedRow.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(221)))), ((int)(((byte)(215)))), ((int)(((byte)(188)))));
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
            this.gridColCode,
            this.gridColName,
            this.gridColRemark,
            this.gridColiSave,
            this.gridColiID,
            this.gridCol是否减少应收款,
            this.gridCol是否影响出货量,
            this.gridCol是否影响利润,
            this.gridCol是否影响退回率,
            this.gridCol是否影响样品率});
            this.gridView1.GridControl = this.gridControl1;
            this.gridView1.IndicatorWidth = 40;
            this.gridView1.Name = "gridView1";
            this.gridView1.OptionsCustomization.AllowSort = false;
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
            this.gridView1.OptionsView.ShowGroupPanel = false;
            this.gridView1.FocusedRowChanged += new DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventHandler(this.gridView1_FocusedRowChanged);
            this.gridView1.CustomDrawRowIndicator += new DevExpress.XtraGrid.Views.Grid.RowIndicatorCustomDrawEventHandler(this.gridView1_CustomDrawRowIndicator);
            this.gridView1.CellValueChanged += new DevExpress.XtraGrid.Views.Base.CellValueChangedEventHandler(this.gridView1_CellValueChanged);
            // 
            // gridColCode
            // 
            this.gridColCode.AppearanceHeader.ForeColor = System.Drawing.Color.Blue;
            this.gridColCode.AppearanceHeader.Options.UseForeColor = true;
            this.gridColCode.Caption = "销售统计类型编码";
            this.gridColCode.FieldName = "cSTTCode";
            this.gridColCode.Name = "gridColCode";
            this.gridColCode.OptionsColumn.AllowMerge = DevExpress.Utils.DefaultBoolean.False;
            this.gridColCode.Visible = true;
            this.gridColCode.VisibleIndex = 0;
            this.gridColCode.Width = 134;
            // 
            // gridColName
            // 
            this.gridColName.AppearanceHeader.ForeColor = System.Drawing.Color.Blue;
            this.gridColName.AppearanceHeader.Options.UseForeColor = true;
            this.gridColName.Caption = "销售统计类型名称";
            this.gridColName.FieldName = "cSTTName";
            this.gridColName.Name = "gridColName";
            this.gridColName.OptionsColumn.AllowMerge = DevExpress.Utils.DefaultBoolean.False;
            this.gridColName.Visible = true;
            this.gridColName.VisibleIndex = 1;
            this.gridColName.Width = 158;
            // 
            // ItemLookUpEdit收发标志
            // 
            this.ItemLookUpEdit收发标志.AutoHeight = false;
            this.ItemLookUpEdit收发标志.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.ItemLookUpEdit收发标志.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("iID", "编码"),
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("iText", "内容")});
            this.ItemLookUpEdit收发标志.DisplayMember = "iText";
            this.ItemLookUpEdit收发标志.Name = "ItemLookUpEdit收发标志";
            this.ItemLookUpEdit收发标志.NullText = "";
            this.ItemLookUpEdit收发标志.ValueMember = "iID";
            // 
            // gridColRemark
            // 
            this.gridColRemark.Caption = "备注";
            this.gridColRemark.FieldName = "Remark";
            this.gridColRemark.Name = "gridColRemark";
            this.gridColRemark.Visible = true;
            this.gridColRemark.VisibleIndex = 7;
            this.gridColRemark.Width = 470;
            // 
            // gridColiSave
            // 
            this.gridColiSave.Caption = "编辑状态";
            this.gridColiSave.FieldName = "iSave";
            this.gridColiSave.Name = "gridColiSave";
            this.gridColiSave.OptionsColumn.AllowEdit = false;
            // 
            // gridColiID
            // 
            this.gridColiID.Caption = "iID";
            this.gridColiID.FieldName = "iID";
            this.gridColiID.Name = "gridColiID";
            // 
            // ItemLookUpEdit关联类别
            // 
            this.ItemLookUpEdit关联类别.AutoHeight = false;
            this.ItemLookUpEdit关联类别.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.ItemLookUpEdit关联类别.Name = "ItemLookUpEdit关联类别";
            // 
            // gridCol是否减少应收款
            // 
            this.gridCol是否减少应收款.Caption = "影响应收款";
            this.gridCol是否减少应收款.ColumnEdit = this.ItemCheckEdit是否影响应收款;
            this.gridCol是否减少应收款.FieldName = "B1";
            this.gridCol是否减少应收款.Name = "gridCol是否减少应收款";
            this.gridCol是否减少应收款.Visible = true;
            this.gridCol是否减少应收款.VisibleIndex = 2;
            // 
            // ItemCheckEdit是否影响应收款
            // 
            this.ItemCheckEdit是否影响应收款.AutoHeight = false;
            this.ItemCheckEdit是否影响应收款.Name = "ItemCheckEdit是否影响应收款";
            // 
            // gridCol是否影响出货量
            // 
            this.gridCol是否影响出货量.Caption = "影响出货量";
            this.gridCol是否影响出货量.ColumnEdit = this.ItemCheckEdit是否影响出货量;
            this.gridCol是否影响出货量.FieldName = "B2";
            this.gridCol是否影响出货量.Name = "gridCol是否影响出货量";
            this.gridCol是否影响出货量.Visible = true;
            this.gridCol是否影响出货量.VisibleIndex = 3;
            // 
            // ItemCheckEdit是否影响出货量
            // 
            this.ItemCheckEdit是否影响出货量.AutoHeight = false;
            this.ItemCheckEdit是否影响出货量.Name = "ItemCheckEdit是否影响出货量";
            // 
            // gridCol是否影响利润
            // 
            this.gridCol是否影响利润.Caption = "影响利润";
            this.gridCol是否影响利润.ColumnEdit = this.ItemCheckEdit是否影响利润;
            this.gridCol是否影响利润.FieldName = "B3";
            this.gridCol是否影响利润.Name = "gridCol是否影响利润";
            this.gridCol是否影响利润.Visible = true;
            this.gridCol是否影响利润.VisibleIndex = 4;
            // 
            // ItemCheckEdit是否影响利润
            // 
            this.ItemCheckEdit是否影响利润.AutoHeight = false;
            this.ItemCheckEdit是否影响利润.Name = "ItemCheckEdit是否影响利润";
            // 
            // gridCol是否影响退回率
            // 
            this.gridCol是否影响退回率.Caption = "影响退回率";
            this.gridCol是否影响退回率.ColumnEdit = this.ItemCheckEdit是否影响退回率;
            this.gridCol是否影响退回率.FieldName = "B4";
            this.gridCol是否影响退回率.Name = "gridCol是否影响退回率";
            this.gridCol是否影响退回率.Visible = true;
            this.gridCol是否影响退回率.VisibleIndex = 5;
            // 
            // ItemCheckEdit是否影响退回率
            // 
            this.ItemCheckEdit是否影响退回率.AutoHeight = false;
            this.ItemCheckEdit是否影响退回率.Name = "ItemCheckEdit是否影响退回率";
            // 
            // gridCol是否影响样品率
            // 
            this.gridCol是否影响样品率.Caption = "影响样品率";
            this.gridCol是否影响样品率.ColumnEdit = this.ItemCheckEdit是否影响样品率;
            this.gridCol是否影响样品率.FieldName = "B5";
            this.gridCol是否影响样品率.Name = "gridCol是否影响样品率";
            this.gridCol是否影响样品率.Visible = true;
            this.gridCol是否影响样品率.VisibleIndex = 6;
            // 
            // ItemCheckEdit是否影响样品率
            // 
            this.ItemCheckEdit是否影响样品率.AutoHeight = false;
            this.ItemCheckEdit是否影响样品率.Name = "ItemCheckEdit是否影响样品率";
            // 
            // layoutControlGroup1
            // 
            this.layoutControlGroup1.CustomizationFormText = "layoutControlGroup1";
            this.layoutControlGroup1.EnableIndentsWithoutBorders = DevExpress.Utils.DefaultBoolean.True;
            this.layoutControlGroup1.GroupBordersVisible = false;
            this.layoutControlGroup1.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.layoutControlItem3});
            this.layoutControlGroup1.Location = new System.Drawing.Point(0, 0);
            this.layoutControlGroup1.Name = "Root";
            this.layoutControlGroup1.Size = new System.Drawing.Size(856, 277);
            this.layoutControlGroup1.Text = "Root";
            this.layoutControlGroup1.TextVisible = false;
            // 
            // layoutControlItem3
            // 
            this.layoutControlItem3.Control = this.gridControl1;
            this.layoutControlItem3.CustomizationFormText = "layoutControlItem3";
            this.layoutControlItem3.Location = new System.Drawing.Point(0, 0);
            this.layoutControlItem3.Name = "layoutControlItem3";
            this.layoutControlItem3.Size = new System.Drawing.Size(836, 257);
            this.layoutControlItem3.Text = "layoutControlItem3";
            this.layoutControlItem3.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem3.TextToControlDistance = 0;
            this.layoutControlItem3.TextVisible = false;
            // 
            // Frm销售统计类型
            // 
            this.Appearance.BackColor = System.Drawing.SystemColors.Control;
            this.Appearance.Options.UseBackColor = true;
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(854, 306);
            this.Controls.Add(this.layoutControl1);
            this.Name = "Frm销售统计类型";
            this.Text = "销售统计类型";
            this.Load += new System.EventHandler(this.Frm销售统计类型_Load);
            this.Controls.SetChildIndex(this.layoutControl1, 0);
            ((System.ComponentModel.ISupportInitialize)(this.dsPrint)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dsForm)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtSel)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControl1)).EndInit();
            this.layoutControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ItemLookUpEdit收发标志)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ItemLookUpEdit关联类别)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ItemCheckEdit是否影响应收款)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ItemCheckEdit是否影响出货量)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ItemCheckEdit是否影响利润)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ItemCheckEdit是否影响退回率)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ItemCheckEdit是否影响样品率)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem3)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraLayout.LayoutControl layoutControl1;
        private DevExpress.XtraGrid.GridControl gridControl1;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView1;
        private DevExpress.XtraLayout.LayoutControlGroup layoutControlGroup1;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem3;
        private DevExpress.XtraGrid.Columns.GridColumn gridColCode;
        private DevExpress.XtraGrid.Columns.GridColumn gridColName;
        private DevExpress.XtraGrid.Columns.GridColumn gridColiSave;
        private DevExpress.XtraGrid.Columns.GridColumn gridColRemark;
        private DevExpress.XtraGrid.Columns.GridColumn gridColiID;
        private DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit ItemLookUpEdit收发标志;
        private DevExpress.XtraGrid.Columns.GridColumn gridCol是否减少应收款;
        private DevExpress.XtraGrid.Columns.GridColumn gridCol是否影响出货量;
        private DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit ItemLookUpEdit关联类别;
        private DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit ItemCheckEdit是否影响应收款;
        private DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit ItemCheckEdit是否影响出货量;
        private DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit ItemCheckEdit是否影响利润;
        private DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit ItemCheckEdit是否影响退回率;
        private DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit ItemCheckEdit是否影响样品率;
        private DevExpress.XtraGrid.Columns.GridColumn gridCol是否影响利润;
        private DevExpress.XtraGrid.Columns.GridColumn gridCol是否影响退回率;
        private DevExpress.XtraGrid.Columns.GridColumn gridCol是否影响样品率;
    }
}