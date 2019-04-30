namespace ImportDLL
{
    partial class Frm存货工时报表
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
            this.txt默认工时 = new DevExpress.XtraEditors.TextEdit();
            this.txtPurchase = new DevExpress.XtraEditors.TextEdit();
            this.txtProxyForeign = new DevExpress.XtraEditors.TextEdit();
            this.gridControl1 = new DevExpress.XtraGrid.GridControl();
            this.gridView1 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.gridColiID = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColGUID = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColCreateUid = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColCreateDate = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColUpdataUid = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColUpdataDate = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColcInvCode = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColLineNo = new DevExpress.XtraGrid.Columns.GridColumn();
            this.ItemLookUpEditLineNo = new DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit();
            this.gridColLineName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.ItemLookUpEditLineName = new DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit();
            this.gridColSelfCycle = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColSelfCapacity = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColPurchaseCycle = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColProxyForeignCycle = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColSelfSetupCycle = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColPriority = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColRemark = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColbSelf = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColbPurchase = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColbProxyForeign = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColchoose = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColSelfCycleB = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridCol产量 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.layoutControlItem8 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem9 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlGroup1 = new DevExpress.XtraLayout.LayoutControlGroup();
            this.layoutControlItem3 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem10 = new DevExpress.XtraLayout.LayoutControlItem();
            this.gridColcInvName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColcInvStd = new DevExpress.XtraGrid.Columns.GridColumn();
            this.ItemLookUpEditcInvName = new DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit();
            this.ItemLookUpEditcInvStd = new DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit();
            ((System.ComponentModel.ISupportInitialize)(this.dsPrint)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dsForm)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtSel)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControl1)).BeginInit();
            this.layoutControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txt默认工时.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtPurchase.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtProxyForeign.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ItemLookUpEditLineNo)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ItemLookUpEditLineName)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem8)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem9)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem10)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ItemLookUpEditcInvName)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ItemLookUpEditcInvStd)).BeginInit();
            this.SuspendLayout();
            // 
            // layoutControl1
            // 
            this.layoutControl1.AllowCustomizationMenu = false;
            this.layoutControl1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.layoutControl1.Controls.Add(this.txt默认工时);
            this.layoutControl1.Controls.Add(this.txtPurchase);
            this.layoutControl1.Controls.Add(this.txtProxyForeign);
            this.layoutControl1.Controls.Add(this.gridControl1);
            this.layoutControl1.HiddenItems.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.layoutControlItem8,
            this.layoutControlItem9});
            this.layoutControl1.Location = new System.Drawing.Point(0, 28);
            this.layoutControl1.Name = "layoutControl1";
            this.layoutControl1.OptionsCustomizationForm.DesignTimeCustomizationFormPositionAndSize = new System.Drawing.Rectangle(555, 438, 250, 350);
            this.layoutControl1.OptionsCustomizationForm.ShowLoadButton = false;
            this.layoutControl1.OptionsCustomizationForm.ShowSaveButton = false;
            this.layoutControl1.OptionsView.UseDefaultDragAndDropRendering = false;
            this.layoutControl1.Root = this.layoutControlGroup1;
            this.layoutControl1.Size = new System.Drawing.Size(916, 376);
            this.layoutControl1.TabIndex = 5;
            this.layoutControl1.Text = "layoutControl1";
            // 
            // txt默认工时
            // 
            this.txt默认工时.EditValue = "8";
            this.txt默认工时.Location = new System.Drawing.Point(64, 12);
            this.txt默认工时.Name = "txt默认工时";
            this.txt默认工时.Properties.Mask.EditMask = "n1";
            this.txt默认工时.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Numeric;
            this.txt默认工时.Size = new System.Drawing.Size(50, 21);
            this.txt默认工时.StyleController = this.layoutControl1;
            this.txt默认工时.TabIndex = 15;
            // 
            // txtPurchase
            // 
            this.txtPurchase.Location = new System.Drawing.Point(64, 37);
            this.txtPurchase.Name = "txtPurchase";
            this.txtPurchase.Properties.Mask.EditMask = "n0";
            this.txtPurchase.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Numeric;
            this.txtPurchase.Size = new System.Drawing.Size(101, 21);
            this.txtPurchase.StyleController = this.layoutControl1;
            this.txtPurchase.TabIndex = 13;
            // 
            // txtProxyForeign
            // 
            this.txtProxyForeign.Location = new System.Drawing.Point(64, 37);
            this.txtProxyForeign.Name = "txtProxyForeign";
            this.txtProxyForeign.Properties.Mask.EditMask = "n0";
            this.txtProxyForeign.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Numeric;
            this.txtProxyForeign.Size = new System.Drawing.Size(271, 21);
            this.txtProxyForeign.StyleController = this.layoutControl1;
            this.txtProxyForeign.TabIndex = 14;
            // 
            // gridControl1
            // 
            this.gridControl1.Location = new System.Drawing.Point(12, 54);
            this.gridControl1.MainView = this.gridView1;
            this.gridControl1.Name = "gridControl1";
            this.gridControl1.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.ItemLookUpEditLineNo,
            this.ItemLookUpEditLineName,
            this.ItemLookUpEditcInvName,
            this.ItemLookUpEditcInvStd});
            this.gridControl1.Size = new System.Drawing.Size(892, 310);
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
            this.gridColiID,
            this.gridColGUID,
            this.gridColCreateUid,
            this.gridColCreateDate,
            this.gridColUpdataUid,
            this.gridColUpdataDate,
            this.gridColcInvCode,
            this.gridColcInvName,
            this.gridColcInvStd,
            this.gridColLineNo,
            this.gridColLineName,
            this.gridColSelfCycle,
            this.gridColSelfCapacity,
            this.gridColPurchaseCycle,
            this.gridColProxyForeignCycle,
            this.gridColSelfSetupCycle,
            this.gridColPriority,
            this.gridColRemark,
            this.gridColbSelf,
            this.gridColbPurchase,
            this.gridColbProxyForeign,
            this.gridColchoose,
            this.gridColSelfCycleB,
            this.gridCol产量});
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
            this.gridView1.OptionsView.AutoCalcPreviewLineCount = true;
            this.gridView1.OptionsView.ColumnAutoWidth = false;
            this.gridView1.OptionsView.EnableAppearanceEvenRow = true;
            this.gridView1.OptionsView.EnableAppearanceOddRow = true;
            this.gridView1.OptionsView.ShowGroupPanel = false;
            this.gridView1.CustomDrawRowIndicator += new DevExpress.XtraGrid.Views.Grid.RowIndicatorCustomDrawEventHandler(this.gridView1_CustomDrawRowIndicator);
            // 
            // gridColiID
            // 
            this.gridColiID.Caption = "iID";
            this.gridColiID.FieldName = "iID";
            this.gridColiID.Name = "gridColiID";
            this.gridColiID.OptionsColumn.AllowEdit = false;
            this.gridColiID.OptionsColumn.AllowSort = DevExpress.Utils.DefaultBoolean.False;
            // 
            // gridColGUID
            // 
            this.gridColGUID.Caption = "GUID";
            this.gridColGUID.FieldName = "GUID";
            this.gridColGUID.Name = "gridColGUID";
            this.gridColGUID.OptionsColumn.AllowEdit = false;
            this.gridColGUID.OptionsColumn.AllowSort = DevExpress.Utils.DefaultBoolean.False;
            // 
            // gridColCreateUid
            // 
            this.gridColCreateUid.Caption = "制单人";
            this.gridColCreateUid.FieldName = "CreateUid";
            this.gridColCreateUid.Name = "gridColCreateUid";
            this.gridColCreateUid.OptionsColumn.AllowEdit = false;
            this.gridColCreateUid.OptionsColumn.AllowSort = DevExpress.Utils.DefaultBoolean.False;
            // 
            // gridColCreateDate
            // 
            this.gridColCreateDate.Caption = "制单日期";
            this.gridColCreateDate.FieldName = "CreateDate";
            this.gridColCreateDate.Name = "gridColCreateDate";
            this.gridColCreateDate.OptionsColumn.AllowEdit = false;
            this.gridColCreateDate.OptionsColumn.AllowSort = DevExpress.Utils.DefaultBoolean.False;
            // 
            // gridColUpdataUid
            // 
            this.gridColUpdataUid.Caption = "修改人";
            this.gridColUpdataUid.FieldName = "UpdateUid";
            this.gridColUpdataUid.Name = "gridColUpdataUid";
            this.gridColUpdataUid.OptionsColumn.AllowEdit = false;
            this.gridColUpdataUid.OptionsColumn.AllowSort = DevExpress.Utils.DefaultBoolean.False;
            // 
            // gridColUpdataDate
            // 
            this.gridColUpdataDate.Caption = "修改日期";
            this.gridColUpdataDate.FieldName = "UpdateDate";
            this.gridColUpdataDate.Name = "gridColUpdataDate";
            this.gridColUpdataDate.OptionsColumn.AllowEdit = false;
            this.gridColUpdataDate.OptionsColumn.AllowSort = DevExpress.Utils.DefaultBoolean.False;
            // 
            // gridColcInvCode
            // 
            this.gridColcInvCode.Caption = "存货编码";
            this.gridColcInvCode.FieldName = "cInvCode";
            this.gridColcInvCode.Name = "gridColcInvCode";
            this.gridColcInvCode.OptionsColumn.AllowEdit = false;
            this.gridColcInvCode.Visible = true;
            this.gridColcInvCode.VisibleIndex = 1;
            this.gridColcInvCode.Width = 102;
            // 
            // gridColLineNo
            // 
            this.gridColLineNo.Caption = "产线序号";
            this.gridColLineNo.ColumnEdit = this.ItemLookUpEditLineNo;
            this.gridColLineNo.FieldName = "LineNo";
            this.gridColLineNo.Name = "gridColLineNo";
            this.gridColLineNo.OptionsColumn.AllowSort = DevExpress.Utils.DefaultBoolean.False;
            this.gridColLineNo.Visible = true;
            this.gridColLineNo.VisibleIndex = 4;
            this.gridColLineNo.Width = 65;
            // 
            // ItemLookUpEditLineNo
            // 
            this.ItemLookUpEditLineNo.AutoHeight = false;
            this.ItemLookUpEditLineNo.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.ItemLookUpEditLineNo.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("LineNo", "序号"),
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("LineName", 60, "产线")});
            this.ItemLookUpEditLineNo.DisplayMember = "LineNo";
            this.ItemLookUpEditLineNo.Name = "ItemLookUpEditLineNo";
            this.ItemLookUpEditLineNo.NullText = "";
            this.ItemLookUpEditLineNo.PopupWidth = 150;
            this.ItemLookUpEditLineNo.ValueMember = "LineNo";
            // 
            // gridColLineName
            // 
            this.gridColLineName.Caption = "产线";
            this.gridColLineName.ColumnEdit = this.ItemLookUpEditLineName;
            this.gridColLineName.FieldName = "LineNo";
            this.gridColLineName.Name = "gridColLineName";
            this.gridColLineName.OptionsColumn.AllowSort = DevExpress.Utils.DefaultBoolean.False;
            this.gridColLineName.Visible = true;
            this.gridColLineName.VisibleIndex = 5;
            this.gridColLineName.Width = 248;
            // 
            // ItemLookUpEditLineName
            // 
            this.ItemLookUpEditLineName.AutoHeight = false;
            this.ItemLookUpEditLineName.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.ItemLookUpEditLineName.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("LineNo", "序号"),
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("LineName", "产线")});
            this.ItemLookUpEditLineName.DisplayMember = "LineName";
            this.ItemLookUpEditLineName.Name = "ItemLookUpEditLineName";
            this.ItemLookUpEditLineName.NullText = "";
            this.ItemLookUpEditLineName.ValueMember = "LineNo";
            // 
            // gridColSelfCycle
            // 
            this.gridColSelfCycle.Caption = "单件生产工时";
            this.gridColSelfCycle.FieldName = "SelfCycle";
            this.gridColSelfCycle.Name = "gridColSelfCycle";
            this.gridColSelfCycle.Visible = true;
            this.gridColSelfCycle.VisibleIndex = 8;
            this.gridColSelfCycle.Width = 86;
            // 
            // gridColSelfCapacity
            // 
            this.gridColSelfCapacity.Caption = "产线并发生产数";
            this.gridColSelfCapacity.FieldName = "SelfCapacity";
            this.gridColSelfCapacity.Name = "gridColSelfCapacity";
            this.gridColSelfCapacity.Width = 107;
            // 
            // gridColPurchaseCycle
            // 
            this.gridColPurchaseCycle.Caption = "采购周期";
            this.gridColPurchaseCycle.FieldName = "PurchaseCycle";
            this.gridColPurchaseCycle.Name = "gridColPurchaseCycle";
            this.gridColPurchaseCycle.Width = 58;
            // 
            // gridColProxyForeignCycle
            // 
            this.gridColProxyForeignCycle.Caption = "委外周期";
            this.gridColProxyForeignCycle.FieldName = "ProxyForeignCycle";
            this.gridColProxyForeignCycle.Name = "gridColProxyForeignCycle";
            this.gridColProxyForeignCycle.Width = 62;
            // 
            // gridColSelfSetupCycle
            // 
            this.gridColSelfSetupCycle.Caption = "生产准备时间";
            this.gridColSelfSetupCycle.FieldName = "SelfSetupCycle";
            this.gridColSelfSetupCycle.Name = "gridColSelfSetupCycle";
            this.gridColSelfSetupCycle.Visible = true;
            this.gridColSelfSetupCycle.VisibleIndex = 9;
            this.gridColSelfSetupCycle.Width = 90;
            // 
            // gridColPriority
            // 
            this.gridColPriority.Caption = "是否默认产线";
            this.gridColPriority.FieldName = "Priority";
            this.gridColPriority.Name = "gridColPriority";
            this.gridColPriority.Visible = true;
            this.gridColPriority.VisibleIndex = 6;
            this.gridColPriority.Width = 87;
            // 
            // gridColRemark
            // 
            this.gridColRemark.Caption = "备注";
            this.gridColRemark.FieldName = "Remark";
            this.gridColRemark.Name = "gridColRemark";
            this.gridColRemark.OptionsColumn.AllowSort = DevExpress.Utils.DefaultBoolean.False;
            this.gridColRemark.Visible = true;
            this.gridColRemark.VisibleIndex = 11;
            this.gridColRemark.Width = 377;
            // 
            // gridColbSelf
            // 
            this.gridColbSelf.Caption = "是否自制";
            this.gridColbSelf.FieldName = "bSelf";
            this.gridColbSelf.Name = "gridColbSelf";
            this.gridColbSelf.OptionsColumn.AllowEdit = false;
            // 
            // gridColbPurchase
            // 
            this.gridColbPurchase.Caption = "是否外购";
            this.gridColbPurchase.FieldName = "bPurchase";
            this.gridColbPurchase.Name = "gridColbPurchase";
            this.gridColbPurchase.OptionsColumn.AllowEdit = false;
            // 
            // gridColbProxyForeign
            // 
            this.gridColbProxyForeign.Caption = "是否委外";
            this.gridColbProxyForeign.FieldName = "bProxyForeign ";
            this.gridColbProxyForeign.Name = "gridColbProxyForeign";
            this.gridColbProxyForeign.OptionsColumn.AllowEdit = false;
            // 
            // gridColchoose
            // 
            this.gridColchoose.Caption = "选择";
            this.gridColchoose.FieldName = "choose";
            this.gridColchoose.Fixed = DevExpress.XtraGrid.Columns.FixedStyle.Left;
            this.gridColchoose.Name = "gridColchoose";
            this.gridColchoose.Visible = true;
            this.gridColchoose.VisibleIndex = 0;
            this.gridColchoose.Width = 36;
            // 
            // gridColSelfCycleB
            // 
            this.gridColSelfCycleB.Caption = "单件生产工时基数";
            this.gridColSelfCycleB.FieldName = "SelfCycleB";
            this.gridColSelfCycleB.Name = "gridColSelfCycleB";
            this.gridColSelfCycleB.Visible = true;
            this.gridColSelfCycleB.VisibleIndex = 10;
            this.gridColSelfCycleB.Width = 109;
            // 
            // gridCol产量
            // 
            this.gridCol产量.Caption = "产量";
            this.gridCol产量.FieldName = "产量";
            this.gridCol产量.Name = "gridCol产量";
            this.gridCol产量.Visible = true;
            this.gridCol产量.VisibleIndex = 7;
            this.gridCol产量.Width = 59;
            // 
            // layoutControlItem8
            // 
            this.layoutControlItem8.Control = this.txtPurchase;
            this.layoutControlItem8.CustomizationFormText = "采购周期";
            this.layoutControlItem8.Location = new System.Drawing.Point(0, 25);
            this.layoutControlItem8.Name = "layoutControlItem8";
            this.layoutControlItem8.Size = new System.Drawing.Size(157, 25);
            this.layoutControlItem8.Text = "采购周期";
            this.layoutControlItem8.TextSize = new System.Drawing.Size(48, 14);
            this.layoutControlItem8.TextToControlDistance = 5;
            // 
            // layoutControlItem9
            // 
            this.layoutControlItem9.Control = this.txtProxyForeign;
            this.layoutControlItem9.CustomizationFormText = "委外周期";
            this.layoutControlItem9.Location = new System.Drawing.Point(0, 25);
            this.layoutControlItem9.Name = "layoutControlItem9";
            this.layoutControlItem9.Size = new System.Drawing.Size(327, 25);
            this.layoutControlItem9.Text = "委外周期";
            this.layoutControlItem9.TextSize = new System.Drawing.Size(48, 14);
            this.layoutControlItem9.TextToControlDistance = 5;
            // 
            // layoutControlGroup1
            // 
            this.layoutControlGroup1.CustomizationFormText = "layoutControlGroup1";
            this.layoutControlGroup1.EnableIndentsWithoutBorders = DevExpress.Utils.DefaultBoolean.True;
            this.layoutControlGroup1.GroupBordersVisible = false;
            this.layoutControlGroup1.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.layoutControlItem3,
            this.layoutControlItem10});
            this.layoutControlGroup1.Location = new System.Drawing.Point(0, 0);
            this.layoutControlGroup1.Name = "Root";
            this.layoutControlGroup1.Size = new System.Drawing.Size(916, 376);
            this.layoutControlGroup1.Text = "Root";
            this.layoutControlGroup1.TextVisible = false;
            // 
            // layoutControlItem3
            // 
            this.layoutControlItem3.Control = this.gridControl1;
            this.layoutControlItem3.CustomizationFormText = "layoutControlItem3";
            this.layoutControlItem3.Location = new System.Drawing.Point(0, 25);
            this.layoutControlItem3.Name = "layoutControlItem3";
            this.layoutControlItem3.Size = new System.Drawing.Size(896, 331);
            this.layoutControlItem3.Text = "自制属性";
            this.layoutControlItem3.TextLocation = DevExpress.Utils.Locations.Top;
            this.layoutControlItem3.TextSize = new System.Drawing.Size(48, 14);
            // 
            // layoutControlItem10
            // 
            this.layoutControlItem10.Control = this.txt默认工时;
            this.layoutControlItem10.CustomizationFormText = "默认工时";
            this.layoutControlItem10.Location = new System.Drawing.Point(0, 0);
            this.layoutControlItem10.MaxSize = new System.Drawing.Size(106, 25);
            this.layoutControlItem10.MinSize = new System.Drawing.Size(106, 25);
            this.layoutControlItem10.Name = "layoutControlItem10";
            this.layoutControlItem10.Size = new System.Drawing.Size(896, 25);
            this.layoutControlItem10.SizeConstraintsType = DevExpress.XtraLayout.SizeConstraintsType.Custom;
            this.layoutControlItem10.Text = "默认工时";
            this.layoutControlItem10.TextSize = new System.Drawing.Size(48, 14);
            // 
            // gridColcInvName
            // 
            this.gridColcInvName.Caption = "存货名称";
            this.gridColcInvName.ColumnEdit = this.ItemLookUpEditcInvName;
            this.gridColcInvName.FieldName = "cInvCode";
            this.gridColcInvName.Name = "gridColcInvName";
            this.gridColcInvName.Visible = true;
            this.gridColcInvName.VisibleIndex = 2;
            this.gridColcInvName.Width = 206;
            // 
            // gridColcInvStd
            // 
            this.gridColcInvStd.Caption = "规格型号";
            this.gridColcInvStd.ColumnEdit = this.ItemLookUpEditcInvStd;
            this.gridColcInvStd.FieldName = "cInvCode";
            this.gridColcInvStd.Name = "gridColcInvStd";
            this.gridColcInvStd.Visible = true;
            this.gridColcInvStd.VisibleIndex = 3;
            this.gridColcInvStd.Width = 91;
            // 
            // ItemLookUpEditcInvName
            // 
            this.ItemLookUpEditcInvName.AutoHeight = false;
            this.ItemLookUpEditcInvName.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.ItemLookUpEditcInvName.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("cInvCode", "存货编码"),
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("cInvName", "存货名称"),
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("cInvStd", "规格型号")});
            this.ItemLookUpEditcInvName.DisplayMember = "cInvName";
            this.ItemLookUpEditcInvName.Name = "ItemLookUpEditcInvName";
            this.ItemLookUpEditcInvName.NullText = "";
            this.ItemLookUpEditcInvName.ValueMember = "cInvCode";
            // 
            // ItemLookUpEditcInvStd
            // 
            this.ItemLookUpEditcInvStd.AutoHeight = false;
            this.ItemLookUpEditcInvStd.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.ItemLookUpEditcInvStd.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("cInvCode", "存货编码"),
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("cInvName", "存货名称"),
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("cInvStd", "规格型号")});
            this.ItemLookUpEditcInvStd.DisplayMember = "cInvStd";
            this.ItemLookUpEditcInvStd.Name = "ItemLookUpEditcInvStd";
            this.ItemLookUpEditcInvStd.NullText = "";
            this.ItemLookUpEditcInvStd.ValueMember = "cInvCode";
            // 
            // Frm存货工时报表
            // 
            this.Appearance.BackColor = System.Drawing.SystemColors.Control;
            this.Appearance.Options.UseBackColor = true;
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(914, 405);
            this.Controls.Add(this.layoutControl1);
            this.Name = "Frm存货工时报表";
            this.Text = "存货工时报表";
            this.Load += new System.EventHandler(this.Frm_Load);
            this.Controls.SetChildIndex(this.layoutControl1, 0);
            ((System.ComponentModel.ISupportInitialize)(this.dsPrint)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dsForm)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtSel)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControl1)).EndInit();
            this.layoutControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.txt默认工时.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtPurchase.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtProxyForeign.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ItemLookUpEditLineNo)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ItemLookUpEditLineName)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem8)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem9)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem10)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ItemLookUpEditcInvName)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ItemLookUpEditcInvStd)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraLayout.LayoutControl layoutControl1;
        private DevExpress.XtraGrid.GridControl gridControl1;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView1;
        private DevExpress.XtraLayout.LayoutControlGroup layoutControlGroup1;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem3;
        private DevExpress.XtraGrid.Columns.GridColumn gridColiID;
        private DevExpress.XtraGrid.Columns.GridColumn gridColGUID;
        private DevExpress.XtraGrid.Columns.GridColumn gridColCreateUid;
        private DevExpress.XtraGrid.Columns.GridColumn gridColCreateDate;
        private DevExpress.XtraGrid.Columns.GridColumn gridColUpdataUid;
        private DevExpress.XtraGrid.Columns.GridColumn gridColUpdataDate;
        private DevExpress.XtraGrid.Columns.GridColumn gridColLineNo;
        private DevExpress.XtraGrid.Columns.GridColumn gridColLineName;
        private DevExpress.XtraGrid.Columns.GridColumn gridColRemark;
        private DevExpress.XtraGrid.Columns.GridColumn gridColcInvCode;
        private DevExpress.XtraGrid.Columns.GridColumn gridColPurchaseCycle;
        private DevExpress.XtraGrid.Columns.GridColumn gridColProxyForeignCycle;
        private DevExpress.XtraGrid.Columns.GridColumn gridColSelfCycle;
        private DevExpress.XtraGrid.Columns.GridColumn gridColSelfSetupCycle;
        private DevExpress.XtraGrid.Columns.GridColumn gridColPriority;
        private DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit ItemLookUpEditLineNo;
        private DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit ItemLookUpEditLineName;
        private DevExpress.XtraGrid.Columns.GridColumn gridColbSelf;
        private DevExpress.XtraGrid.Columns.GridColumn gridColbPurchase;
        private DevExpress.XtraGrid.Columns.GridColumn gridColbProxyForeign;
        private DevExpress.XtraEditors.TextEdit txtPurchase;
        private DevExpress.XtraEditors.TextEdit txtProxyForeign;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem8;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem9;
        private DevExpress.XtraGrid.Columns.GridColumn gridColchoose;
        private DevExpress.XtraGrid.Columns.GridColumn gridColSelfCapacity;
        private DevExpress.XtraGrid.Columns.GridColumn gridColSelfCycleB;
        private DevExpress.XtraGrid.Columns.GridColumn gridCol产量;
        private DevExpress.XtraEditors.TextEdit txt默认工时;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem10;
        private DevExpress.XtraGrid.Columns.GridColumn gridColcInvName;
        private DevExpress.XtraGrid.Columns.GridColumn gridColcInvStd;
        private DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit ItemLookUpEditcInvName;
        private DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit ItemLookUpEditcInvStd;
    }
}