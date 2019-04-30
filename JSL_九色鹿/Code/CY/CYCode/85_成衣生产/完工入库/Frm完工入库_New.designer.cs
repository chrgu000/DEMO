namespace 成衣生产
{
    partial class Frm完工入库_New 
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
            this.btnExit = new System.Windows.Forms.Button();
            this.layoutControlGroup1 = new DevExpress.XtraLayout.LayoutControlGroup();
            this.layoutControlItem3 = new DevExpress.XtraLayout.LayoutControlItem();
            this.dateEdit单据日期1 = new DevExpress.XtraEditors.DateEdit();
            this.layoutControl1 = new DevExpress.XtraLayout.LayoutControl();
            this.txt客户 = new DevExpress.XtraEditors.TextEdit();
            this.gridControl1 = new DevExpress.XtraGrid.GridControl();
            this.gridView1 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.gridColID = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColAutoID = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridCol选择 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.ItemCheckEdit1 = new DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit();
            this.gridCol生产计划iID = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridCol单据日期 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridCol客户 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridCol生产 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.ItemLookUpEdit生产 = new DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit();
            this.gridCol类别 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.ItemLookUpEdit类别 = new DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit();
            this.gridCol款号 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.ItemLookUpEdit款号 = new DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit();
            this.gridCol纱种 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.ItemLookUpEdit纱种 = new DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit();
            this.gridCol未入库数量 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridCol生产计划数量 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.dateEdit单据日期2 = new DevExpress.XtraEditors.DateEdit();
            this.layoutControlItem17 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem2 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem4 = new DevExpress.XtraLayout.LayoutControlItem();
            this.btnEnsure = new System.Windows.Forms.Button();
            this.button查询 = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dateEdit单据日期1.Properties.VistaTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dateEdit单据日期1.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControl1)).BeginInit();
            this.layoutControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txt客户.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ItemCheckEdit1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ItemLookUpEdit生产)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ItemLookUpEdit类别)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ItemLookUpEdit款号)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ItemLookUpEdit纱种)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dateEdit单据日期2.Properties.VistaTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dateEdit单据日期2.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem17)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem4)).BeginInit();
            this.SuspendLayout();
            // 
            // btnExit
            // 
            this.btnExit.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnExit.Location = new System.Drawing.Point(991, 394);
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size(62, 23);
            this.btnExit.TabIndex = 2;
            this.btnExit.Text = "退 出";
            this.btnExit.UseVisualStyleBackColor = true;
            this.btnExit.Click += new System.EventHandler(this.btnExit_Click);
            // 
            // layoutControlGroup1
            // 
            this.layoutControlGroup1.CustomizationFormText = "layoutControlGroup1";
            this.layoutControlGroup1.EnableIndentsWithoutBorders = DevExpress.Utils.DefaultBoolean.True;
            this.layoutControlGroup1.GroupBordersVisible = false;
            this.layoutControlGroup1.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.layoutControlItem3,
            this.layoutControlItem17,
            this.layoutControlItem2,
            this.layoutControlItem4});
            this.layoutControlGroup1.Location = new System.Drawing.Point(0, 0);
            this.layoutControlGroup1.Name = "Root";
            this.layoutControlGroup1.Size = new System.Drawing.Size(1088, 379);
            this.layoutControlGroup1.Text = "Root";
            this.layoutControlGroup1.TextVisible = false;
            // 
            // layoutControlItem3
            // 
            this.layoutControlItem3.Control = this.dateEdit单据日期1;
            this.layoutControlItem3.CustomizationFormText = "入库日期";
            this.layoutControlItem3.Location = new System.Drawing.Point(0, 25);
            this.layoutControlItem3.Name = "layoutControlItem3";
            this.layoutControlItem3.Size = new System.Drawing.Size(515, 25);
            this.layoutControlItem3.Text = "单据日期";
            this.layoutControlItem3.TextSize = new System.Drawing.Size(48, 14);
            // 
            // dateEdit单据日期1
            // 
            this.dateEdit单据日期1.EditValue = null;
            this.dateEdit单据日期1.Location = new System.Drawing.Point(64, 37);
            this.dateEdit单据日期1.Name = "dateEdit单据日期1";
            this.dateEdit单据日期1.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.dateEdit单据日期1.Properties.VistaTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
            this.dateEdit单据日期1.Size = new System.Drawing.Size(459, 21);
            this.dateEdit单据日期1.StyleController = this.layoutControl1;
            this.dateEdit单据日期1.TabIndex = 12;
            // 
            // layoutControl1
            // 
            this.layoutControl1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.layoutControl1.Controls.Add(this.txt客户);
            this.layoutControl1.Controls.Add(this.gridControl1);
            this.layoutControl1.Controls.Add(this.dateEdit单据日期1);
            this.layoutControl1.Controls.Add(this.dateEdit单据日期2);
            this.layoutControl1.Location = new System.Drawing.Point(-3, 12);
            this.layoutControl1.Name = "layoutControl1";
            this.layoutControl1.OptionsCustomizationForm.DesignTimeCustomizationFormPositionAndSize = new System.Drawing.Rectangle(123, 171, 250, 350);
            this.layoutControl1.OptionsView.UseDefaultDragAndDropRendering = false;
            this.layoutControl1.Root = this.layoutControlGroup1;
            this.layoutControl1.Size = new System.Drawing.Size(1088, 379);
            this.layoutControl1.TabIndex = 0;
            this.layoutControl1.Text = "layoutControl1";
            // 
            // txt客户
            // 
            this.txt客户.Location = new System.Drawing.Point(64, 12);
            this.txt客户.Name = "txt客户";
            this.txt客户.Size = new System.Drawing.Size(1012, 21);
            this.txt客户.StyleController = this.layoutControl1;
            this.txt客户.TabIndex = 13;
            // 
            // gridControl1
            // 
            this.gridControl1.Location = new System.Drawing.Point(12, 62);
            this.gridControl1.MainView = this.gridView1;
            this.gridControl1.Name = "gridControl1";
            this.gridControl1.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.ItemLookUpEdit生产,
            this.ItemLookUpEdit类别,
            this.ItemLookUpEdit款号,
            this.ItemLookUpEdit纱种,
            this.ItemCheckEdit1});
            this.gridControl1.Size = new System.Drawing.Size(1064, 305);
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
            this.gridColID,
            this.gridColAutoID,
            this.gridCol选择,
            this.gridCol生产计划iID,
            this.gridCol单据日期,
            this.gridCol客户,
            this.gridCol生产,
            this.gridCol类别,
            this.gridCol款号,
            this.gridCol纱种,
            this.gridCol未入库数量,
            this.gridCol生产计划数量});
            this.gridView1.CustomizationFormBounds = new System.Drawing.Rectangle(950, 457, 216, 187);
            this.gridView1.GridControl = this.gridControl1;
            this.gridView1.IndicatorWidth = 40;
            this.gridView1.Name = "gridView1";
            this.gridView1.OptionsBehavior.CopyToClipboardWithColumnHeaders = false;
            this.gridView1.OptionsBehavior.EditorShowMode = DevExpress.Utils.EditorShowMode.MouseDown;
            this.gridView1.OptionsCustomization.AllowSort = false;
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
            this.gridView1.DoubleClick += new System.EventHandler(this.gridView1_DoubleClick);
            // 
            // gridColID
            // 
            this.gridColID.Caption = "ID";
            this.gridColID.FieldName = "ID";
            this.gridColID.Name = "gridColID";
            // 
            // gridColAutoID
            // 
            this.gridColAutoID.Caption = "AutoID";
            this.gridColAutoID.FieldName = "AutoID";
            this.gridColAutoID.Name = "gridColAutoID";
            // 
            // gridCol选择
            // 
            this.gridCol选择.Caption = "选择";
            this.gridCol选择.ColumnEdit = this.ItemCheckEdit1;
            this.gridCol选择.FieldName = "iChk";
            this.gridCol选择.Fixed = DevExpress.XtraGrid.Columns.FixedStyle.Left;
            this.gridCol选择.Name = "gridCol选择";
            this.gridCol选择.Visible = true;
            this.gridCol选择.VisibleIndex = 0;
            this.gridCol选择.Width = 31;
            // 
            // ItemCheckEdit1
            // 
            this.ItemCheckEdit1.AutoHeight = false;
            this.ItemCheckEdit1.Name = "ItemCheckEdit1";
            // 
            // gridCol生产计划iID
            // 
            this.gridCol生产计划iID.Caption = "生产计划iID";
            this.gridCol生产计划iID.FieldName = "生产计划iID";
            this.gridCol生产计划iID.Name = "gridCol生产计划iID";
            this.gridCol生产计划iID.OptionsColumn.AllowEdit = false;
            this.gridCol生产计划iID.Visible = true;
            this.gridCol生产计划iID.VisibleIndex = 1;
            this.gridCol生产计划iID.Width = 112;
            // 
            // gridCol单据日期
            // 
            this.gridCol单据日期.Caption = "单据日期";
            this.gridCol单据日期.DisplayFormat.FormatString = "yyyy-MM-dd";
            this.gridCol单据日期.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.gridCol单据日期.FieldName = "单据日期";
            this.gridCol单据日期.Name = "gridCol单据日期";
            this.gridCol单据日期.OptionsColumn.AllowEdit = false;
            this.gridCol单据日期.Visible = true;
            this.gridCol单据日期.VisibleIndex = 2;
            this.gridCol单据日期.Width = 92;
            // 
            // gridCol客户
            // 
            this.gridCol客户.Caption = "客户";
            this.gridCol客户.FieldName = "客户";
            this.gridCol客户.Name = "gridCol客户";
            this.gridCol客户.OptionsColumn.AllowEdit = false;
            this.gridCol客户.Visible = true;
            this.gridCol客户.VisibleIndex = 3;
            // 
            // gridCol生产
            // 
            this.gridCol生产.Caption = "生产";
            this.gridCol生产.ColumnEdit = this.ItemLookUpEdit生产;
            this.gridCol生产.FieldName = "生产";
            this.gridCol生产.Name = "gridCol生产";
            this.gridCol生产.OptionsColumn.AllowEdit = false;
            this.gridCol生产.Visible = true;
            this.gridCol生产.VisibleIndex = 4;
            this.gridCol生产.Width = 95;
            // 
            // ItemLookUpEdit生产
            // 
            this.ItemLookUpEdit生产.AutoHeight = false;
            this.ItemLookUpEdit生产.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.ItemLookUpEdit生产.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("cCode", "生产")});
            this.ItemLookUpEdit生产.DisplayMember = "cCode";
            this.ItemLookUpEdit生产.Name = "ItemLookUpEdit生产";
            this.ItemLookUpEdit生产.ValueMember = "cCode";
            // 
            // gridCol类别
            // 
            this.gridCol类别.Caption = "类别";
            this.gridCol类别.ColumnEdit = this.ItemLookUpEdit类别;
            this.gridCol类别.FieldName = "类别";
            this.gridCol类别.Name = "gridCol类别";
            this.gridCol类别.OptionsColumn.AllowEdit = false;
            this.gridCol类别.Visible = true;
            this.gridCol类别.VisibleIndex = 5;
            this.gridCol类别.Width = 92;
            // 
            // ItemLookUpEdit类别
            // 
            this.ItemLookUpEdit类别.AutoHeight = false;
            this.ItemLookUpEdit类别.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.ItemLookUpEdit类别.DisplayMember = "iText";
            this.ItemLookUpEdit类别.Name = "ItemLookUpEdit类别";
            this.ItemLookUpEdit类别.ValueMember = "iID";
            // 
            // gridCol款号
            // 
            this.gridCol款号.Caption = "款号";
            this.gridCol款号.ColumnEdit = this.ItemLookUpEdit款号;
            this.gridCol款号.FieldName = "款号";
            this.gridCol款号.Name = "gridCol款号";
            this.gridCol款号.OptionsColumn.AllowEdit = false;
            this.gridCol款号.Visible = true;
            this.gridCol款号.VisibleIndex = 6;
            this.gridCol款号.Width = 89;
            // 
            // ItemLookUpEdit款号
            // 
            this.ItemLookUpEdit款号.AutoHeight = false;
            this.ItemLookUpEdit款号.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.ItemLookUpEdit款号.DisplayMember = "款号";
            this.ItemLookUpEdit款号.Name = "ItemLookUpEdit款号";
            this.ItemLookUpEdit款号.ValueMember = "款号";
            // 
            // gridCol纱种
            // 
            this.gridCol纱种.Caption = "纱种";
            this.gridCol纱种.ColumnEdit = this.ItemLookUpEdit纱种;
            this.gridCol纱种.FieldName = "纱种";
            this.gridCol纱种.Name = "gridCol纱种";
            this.gridCol纱种.OptionsColumn.AllowEdit = false;
            this.gridCol纱种.Visible = true;
            this.gridCol纱种.VisibleIndex = 7;
            this.gridCol纱种.Width = 93;
            // 
            // ItemLookUpEdit纱种
            // 
            this.ItemLookUpEdit纱种.AutoHeight = false;
            this.ItemLookUpEdit纱种.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.ItemLookUpEdit纱种.DisplayMember = "cName";
            this.ItemLookUpEdit纱种.Name = "ItemLookUpEdit纱种";
            this.ItemLookUpEdit纱种.ValueMember = "cCode";
            // 
            // gridCol未入库数量
            // 
            this.gridCol未入库数量.Caption = "本次入库数量";
            this.gridCol未入库数量.FieldName = "未入库数量";
            this.gridCol未入库数量.Name = "gridCol未入库数量";
            this.gridCol未入库数量.Visible = true;
            this.gridCol未入库数量.VisibleIndex = 9;
            this.gridCol未入库数量.Width = 92;
            // 
            // gridCol生产计划数量
            // 
            this.gridCol生产计划数量.Caption = "生产计划数量";
            this.gridCol生产计划数量.FieldName = "数量";
            this.gridCol生产计划数量.Name = "gridCol生产计划数量";
            this.gridCol生产计划数量.OptionsColumn.AllowEdit = false;
            this.gridCol生产计划数量.Visible = true;
            this.gridCol生产计划数量.VisibleIndex = 8;
            // 
            // dateEdit单据日期2
            // 
            this.dateEdit单据日期2.EditValue = null;
            this.dateEdit单据日期2.Location = new System.Drawing.Point(579, 37);
            this.dateEdit单据日期2.Name = "dateEdit单据日期2";
            this.dateEdit单据日期2.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.dateEdit单据日期2.Properties.VistaTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
            this.dateEdit单据日期2.Size = new System.Drawing.Size(497, 21);
            this.dateEdit单据日期2.StyleController = this.layoutControl1;
            this.dateEdit单据日期2.TabIndex = 11;
            // 
            // layoutControlItem17
            // 
            this.layoutControlItem17.Control = this.gridControl1;
            this.layoutControlItem17.CustomizationFormText = "layoutControlItem17";
            this.layoutControlItem17.Location = new System.Drawing.Point(0, 50);
            this.layoutControlItem17.Name = "layoutControlItem17";
            this.layoutControlItem17.Size = new System.Drawing.Size(1068, 309);
            this.layoutControlItem17.Text = "layoutControlItem17";
            this.layoutControlItem17.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem17.TextToControlDistance = 0;
            this.layoutControlItem17.TextVisible = false;
            // 
            // layoutControlItem2
            // 
            this.layoutControlItem2.Control = this.dateEdit单据日期2;
            this.layoutControlItem2.CustomizationFormText = "入库日期";
            this.layoutControlItem2.Location = new System.Drawing.Point(515, 25);
            this.layoutControlItem2.Name = "layoutControlItem2";
            this.layoutControlItem2.Size = new System.Drawing.Size(553, 25);
            this.layoutControlItem2.Text = "至";
            this.layoutControlItem2.TextSize = new System.Drawing.Size(48, 14);
            // 
            // layoutControlItem4
            // 
            this.layoutControlItem4.Control = this.txt客户;
            this.layoutControlItem4.CustomizationFormText = "客户";
            this.layoutControlItem4.Location = new System.Drawing.Point(0, 0);
            this.layoutControlItem4.Name = "layoutControlItem4";
            this.layoutControlItem4.Size = new System.Drawing.Size(1068, 25);
            this.layoutControlItem4.Text = "客户";
            this.layoutControlItem4.TextSize = new System.Drawing.Size(48, 14);
            // 
            // btnEnsure
            // 
            this.btnEnsure.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnEnsure.Location = new System.Drawing.Point(890, 394);
            this.btnEnsure.Name = "btnEnsure";
            this.btnEnsure.Size = new System.Drawing.Size(62, 23);
            this.btnEnsure.TabIndex = 3;
            this.btnEnsure.Text = "保 存";
            this.btnEnsure.UseVisualStyleBackColor = true;
            this.btnEnsure.Click += new System.EventHandler(this.btnEnsure_Click);
            // 
            // button查询
            // 
            this.button查询.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.button查询.Location = new System.Drawing.Point(795, 394);
            this.button查询.Name = "button查询";
            this.button查询.Size = new System.Drawing.Size(62, 23);
            this.button查询.TabIndex = 4;
            this.button查询.Text = "查 询";
            this.button查询.UseVisualStyleBackColor = true;
            this.button查询.Click += new System.EventHandler(this.button查询_Click);
            // 
            // Frm完工入库_New
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1082, 429);
            this.Controls.Add(this.button查询);
            this.Controls.Add(this.btnEnsure);
            this.Controls.Add(this.btnExit);
            this.Controls.Add(this.layoutControl1);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Frm完工入库_New";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "完工入库";
            this.Load += new System.EventHandler(this.Frm完工入库_New_Load);
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dateEdit单据日期1.Properties.VistaTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dateEdit单据日期1.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControl1)).EndInit();
            this.layoutControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.txt客户.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ItemCheckEdit1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ItemLookUpEdit生产)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ItemLookUpEdit类别)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ItemLookUpEdit款号)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ItemLookUpEdit纱种)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dateEdit单据日期2.Properties.VistaTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dateEdit单据日期2.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem17)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem4)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnExit;
        private DevExpress.XtraLayout.LayoutControlGroup layoutControlGroup1;
        private DevExpress.XtraLayout.LayoutControl layoutControl1;
        private System.Windows.Forms.Button btnEnsure;
        private DevExpress.XtraEditors.DateEdit dateEdit单据日期1;
        private DevExpress.XtraEditors.DateEdit dateEdit单据日期2;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem3;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem2;
        private DevExpress.XtraGrid.GridControl gridControl1;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView1;
        private DevExpress.XtraGrid.Columns.GridColumn gridColID;
        private DevExpress.XtraGrid.Columns.GridColumn gridColAutoID;
        private DevExpress.XtraGrid.Columns.GridColumn gridCol选择;
        private DevExpress.XtraGrid.Columns.GridColumn gridCol生产计划iID;
        private DevExpress.XtraGrid.Columns.GridColumn gridCol单据日期;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem17;
        private System.Windows.Forms.Button button查询;
        private DevExpress.XtraEditors.TextEdit txt客户;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem4;
        private DevExpress.XtraGrid.Columns.GridColumn gridCol客户;
        private DevExpress.XtraGrid.Columns.GridColumn gridCol生产;
        private DevExpress.XtraGrid.Columns.GridColumn gridCol类别;
        private DevExpress.XtraGrid.Columns.GridColumn gridCol款号;
        private DevExpress.XtraGrid.Columns.GridColumn gridCol纱种;
        private DevExpress.XtraGrid.Columns.GridColumn gridCol未入库数量;
        private DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit ItemLookUpEdit生产;
        private DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit ItemLookUpEdit类别;
        private DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit ItemLookUpEdit款号;
        private DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit ItemLookUpEdit纱种;
        private DevExpress.XtraGrid.Columns.GridColumn gridCol生产计划数量;
        private DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit ItemCheckEdit1;
    }
}