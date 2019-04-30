namespace ImportDLL
{
    partial class FrmWorkCalendar
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
            this.splitContainerControl1 = new DevExpress.XtraEditors.SplitContainerControl();
            this.gridControl产线 = new DevExpress.XtraGrid.GridControl();
            this.gridView产线 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.gridCol_选择 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridCol_LineNo = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridCol_LineName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.chk全选产线 = new System.Windows.Forms.CheckBox();
            this.label2 = new System.Windows.Forms.Label();
            this.gridControl日历 = new DevExpress.XtraGrid.GridControl();
            this.gridView日历 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.gridColchoose = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColiID = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColGUID = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColCreateUid = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColCreateDate = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColUpdataUid = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColUpdataDate = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColiYear = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColiMonth = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColLineNo = new DevExpress.XtraGrid.Columns.GridColumn();
            this.chk全选日历 = new System.Windows.Forms.CheckBox();
            this.lookUpEdit班次 = new DevExpress.XtraEditors.LookUpEdit();
            this.textEditDayTime = new DevExpress.XtraEditors.TextEdit();
            this.lookUpEditYear = new DevExpress.XtraEditors.LookUpEdit();
            this.label1 = new System.Windows.Forms.Label();
            this.layoutControlGroup1 = new DevExpress.XtraLayout.LayoutControlGroup();
            this.layoutControlItem1 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem4 = new DevExpress.XtraLayout.LayoutControlItem();
            this.emptySpaceItem1 = new DevExpress.XtraLayout.EmptySpaceItem();
            this.layoutControlItem6 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem2 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem8 = new DevExpress.XtraLayout.LayoutControlItem();
            ((System.ComponentModel.ISupportInitialize)(this.dsPrint)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dsForm)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtSel)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControl1)).BeginInit();
            this.layoutControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerControl1)).BeginInit();
            this.splitContainerControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl产线)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView产线)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl日历)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView日历)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lookUpEdit班次.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.textEditDayTime.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lookUpEditYear.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem6)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem8)).BeginInit();
            this.SuspendLayout();
            // 
            // layoutControl1
            // 
            this.layoutControl1.AllowCustomizationMenu = false;
            this.layoutControl1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.layoutControl1.Controls.Add(this.splitContainerControl1);
            this.layoutControl1.Controls.Add(this.lookUpEdit班次);
            this.layoutControl1.Controls.Add(this.textEditDayTime);
            this.layoutControl1.Controls.Add(this.lookUpEditYear);
            this.layoutControl1.Controls.Add(this.label1);
            this.layoutControl1.Location = new System.Drawing.Point(0, 28);
            this.layoutControl1.Name = "layoutControl1";
            this.layoutControl1.OptionsCustomizationForm.DesignTimeCustomizationFormPositionAndSize = new System.Drawing.Rectangle(1004, 191, 250, 350);
            this.layoutControl1.OptionsCustomizationForm.ShowLoadButton = false;
            this.layoutControl1.OptionsCustomizationForm.ShowSaveButton = false;
            this.layoutControl1.OptionsView.UseDefaultDragAndDropRendering = false;
            this.layoutControl1.Root = this.layoutControlGroup1;
            this.layoutControl1.Size = new System.Drawing.Size(916, 376);
            this.layoutControl1.TabIndex = 5;
            this.layoutControl1.Text = "layoutControl1";
            // 
            // splitContainerControl1
            // 
            this.splitContainerControl1.Location = new System.Drawing.Point(12, 61);
            this.splitContainerControl1.Name = "splitContainerControl1";
            this.splitContainerControl1.Panel1.Controls.Add(this.gridControl产线);
            this.splitContainerControl1.Panel1.Controls.Add(this.chk全选产线);
            this.splitContainerControl1.Panel1.Text = "Panel1";
            this.splitContainerControl1.Panel2.Controls.Add(this.label2);
            this.splitContainerControl1.Panel2.Controls.Add(this.gridControl日历);
            this.splitContainerControl1.Panel2.Controls.Add(this.chk全选日历);
            this.splitContainerControl1.Panel2.Text = "Panel2";
            this.splitContainerControl1.Size = new System.Drawing.Size(892, 303);
            this.splitContainerControl1.SplitterPosition = 289;
            this.splitContainerControl1.TabIndex = 63;
            this.splitContainerControl1.Text = "splitContainerControl1";
            // 
            // gridControl产线
            // 
            this.gridControl产线.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.gridControl产线.Location = new System.Drawing.Point(6, 31);
            this.gridControl产线.MainView = this.gridView产线;
            this.gridControl产线.Name = "gridControl产线";
            this.gridControl产线.Size = new System.Drawing.Size(282, 265);
            this.gridControl产线.TabIndex = 62;
            this.gridControl产线.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView产线});
            // 
            // gridView产线
            // 
            this.gridView产线.Appearance.ColumnFilterButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(236)))), ((int)(((byte)(232)))), ((int)(((byte)(201)))));
            this.gridView产线.Appearance.ColumnFilterButton.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(236)))), ((int)(((byte)(232)))), ((int)(((byte)(201)))));
            this.gridView产线.Appearance.ColumnFilterButton.ForeColor = System.Drawing.Color.Black;
            this.gridView产线.Appearance.ColumnFilterButton.Options.UseBackColor = true;
            this.gridView产线.Appearance.ColumnFilterButton.Options.UseBorderColor = true;
            this.gridView产线.Appearance.ColumnFilterButton.Options.UseForeColor = true;
            this.gridView产线.Appearance.ColumnFilterButtonActive.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(221)))), ((int)(((byte)(231)))), ((int)(((byte)(234)))));
            this.gridView产线.Appearance.ColumnFilterButtonActive.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(221)))), ((int)(((byte)(231)))), ((int)(((byte)(234)))));
            this.gridView产线.Appearance.ColumnFilterButtonActive.ForeColor = System.Drawing.Color.Black;
            this.gridView产线.Appearance.ColumnFilterButtonActive.Options.UseBackColor = true;
            this.gridView产线.Appearance.ColumnFilterButtonActive.Options.UseBorderColor = true;
            this.gridView产线.Appearance.ColumnFilterButtonActive.Options.UseForeColor = true;
            this.gridView产线.Appearance.Empty.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(236)))), ((int)(((byte)(232)))), ((int)(((byte)(201)))));
            this.gridView产线.Appearance.Empty.BackColor2 = System.Drawing.Color.White;
            this.gridView产线.Appearance.Empty.Options.UseBackColor = true;
            this.gridView产线.Appearance.EvenRow.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(221)))), ((int)(((byte)(231)))), ((int)(((byte)(234)))));
            this.gridView产线.Appearance.EvenRow.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(221)))), ((int)(((byte)(231)))), ((int)(((byte)(234)))));
            this.gridView产线.Appearance.EvenRow.ForeColor = System.Drawing.Color.Black;
            this.gridView产线.Appearance.EvenRow.Options.UseBackColor = true;
            this.gridView产线.Appearance.EvenRow.Options.UseBorderColor = true;
            this.gridView产线.Appearance.EvenRow.Options.UseForeColor = true;
            this.gridView产线.Appearance.FilterCloseButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(216)))), ((int)(((byte)(209)))), ((int)(((byte)(179)))));
            this.gridView产线.Appearance.FilterCloseButton.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(216)))), ((int)(((byte)(209)))), ((int)(((byte)(179)))));
            this.gridView产线.Appearance.FilterCloseButton.ForeColor = System.Drawing.Color.Black;
            this.gridView产线.Appearance.FilterCloseButton.Options.UseBackColor = true;
            this.gridView产线.Appearance.FilterCloseButton.Options.UseBorderColor = true;
            this.gridView产线.Appearance.FilterCloseButton.Options.UseForeColor = true;
            this.gridView产线.Appearance.FilterPanel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(236)))), ((int)(((byte)(232)))), ((int)(((byte)(201)))));
            this.gridView产线.Appearance.FilterPanel.BackColor2 = System.Drawing.Color.White;
            this.gridView产线.Appearance.FilterPanel.ForeColor = System.Drawing.Color.Black;
            this.gridView产线.Appearance.FilterPanel.Options.UseBackColor = true;
            this.gridView产线.Appearance.FilterPanel.Options.UseForeColor = true;
            this.gridView产线.Appearance.FixedLine.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(122)))), ((int)(((byte)(114)))), ((int)(((byte)(113)))));
            this.gridView产线.Appearance.FixedLine.Options.UseBackColor = true;
            this.gridView产线.Appearance.FocusedCell.BackColor = System.Drawing.Color.White;
            this.gridView产线.Appearance.FocusedCell.ForeColor = System.Drawing.Color.Black;
            this.gridView产线.Appearance.FocusedCell.Options.UseBackColor = true;
            this.gridView产线.Appearance.FocusedCell.Options.UseForeColor = true;
            this.gridView产线.Appearance.FocusedRow.BackColor = System.Drawing.Color.Lime;
            this.gridView产线.Appearance.FocusedRow.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(219)))), ((int)(((byte)(188)))));
            this.gridView产线.Appearance.FocusedRow.ForeColor = System.Drawing.Color.Black;
            this.gridView产线.Appearance.FocusedRow.Options.UseBackColor = true;
            this.gridView产线.Appearance.FocusedRow.Options.UseBorderColor = true;
            this.gridView产线.Appearance.FocusedRow.Options.UseForeColor = true;
            this.gridView产线.Appearance.FooterPanel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(216)))), ((int)(((byte)(209)))), ((int)(((byte)(170)))));
            this.gridView产线.Appearance.FooterPanel.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(216)))), ((int)(((byte)(209)))), ((int)(((byte)(170)))));
            this.gridView产线.Appearance.FooterPanel.ForeColor = System.Drawing.Color.Black;
            this.gridView产线.Appearance.FooterPanel.Options.UseBackColor = true;
            this.gridView产线.Appearance.FooterPanel.Options.UseBorderColor = true;
            this.gridView产线.Appearance.FooterPanel.Options.UseForeColor = true;
            this.gridView产线.Appearance.GroupButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(216)))), ((int)(((byte)(209)))), ((int)(((byte)(179)))));
            this.gridView产线.Appearance.GroupButton.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(216)))), ((int)(((byte)(209)))), ((int)(((byte)(179)))));
            this.gridView产线.Appearance.GroupButton.Options.UseBackColor = true;
            this.gridView产线.Appearance.GroupButton.Options.UseBorderColor = true;
            this.gridView产线.Appearance.GroupFooter.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(236)))), ((int)(((byte)(232)))), ((int)(((byte)(201)))));
            this.gridView产线.Appearance.GroupFooter.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(236)))), ((int)(((byte)(232)))), ((int)(((byte)(201)))));
            this.gridView产线.Appearance.GroupFooter.ForeColor = System.Drawing.Color.Black;
            this.gridView产线.Appearance.GroupFooter.Options.UseBackColor = true;
            this.gridView产线.Appearance.GroupFooter.Options.UseBorderColor = true;
            this.gridView产线.Appearance.GroupFooter.Options.UseForeColor = true;
            this.gridView产线.Appearance.GroupPanel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(246)))), ((int)(((byte)(242)))), ((int)(((byte)(213)))));
            this.gridView产线.Appearance.GroupPanel.BackColor2 = System.Drawing.Color.White;
            this.gridView产线.Appearance.GroupPanel.ForeColor = System.Drawing.Color.Black;
            this.gridView产线.Appearance.GroupPanel.Options.UseBackColor = true;
            this.gridView产线.Appearance.GroupPanel.Options.UseForeColor = true;
            this.gridView产线.Appearance.GroupRow.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(236)))), ((int)(((byte)(232)))), ((int)(((byte)(201)))));
            this.gridView产线.Appearance.GroupRow.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(236)))), ((int)(((byte)(232)))), ((int)(((byte)(201)))));
            this.gridView产线.Appearance.GroupRow.ForeColor = System.Drawing.Color.Black;
            this.gridView产线.Appearance.GroupRow.Options.UseBackColor = true;
            this.gridView产线.Appearance.GroupRow.Options.UseBorderColor = true;
            this.gridView产线.Appearance.GroupRow.Options.UseForeColor = true;
            this.gridView产线.Appearance.HeaderPanel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(216)))), ((int)(((byte)(209)))), ((int)(((byte)(170)))));
            this.gridView产线.Appearance.HeaderPanel.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(216)))), ((int)(((byte)(209)))), ((int)(((byte)(170)))));
            this.gridView产线.Appearance.HeaderPanel.ForeColor = System.Drawing.Color.Black;
            this.gridView产线.Appearance.HeaderPanel.Options.UseBackColor = true;
            this.gridView产线.Appearance.HeaderPanel.Options.UseBorderColor = true;
            this.gridView产线.Appearance.HeaderPanel.Options.UseForeColor = true;
            this.gridView产线.Appearance.HideSelectionRow.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(237)))), ((int)(((byte)(230)))), ((int)(((byte)(203)))));
            this.gridView产线.Appearance.HideSelectionRow.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(237)))), ((int)(((byte)(230)))), ((int)(((byte)(203)))));
            this.gridView产线.Appearance.HideSelectionRow.ForeColor = System.Drawing.Color.Black;
            this.gridView产线.Appearance.HideSelectionRow.Options.UseBackColor = true;
            this.gridView产线.Appearance.HideSelectionRow.Options.UseBorderColor = true;
            this.gridView产线.Appearance.HideSelectionRow.Options.UseForeColor = true;
            this.gridView产线.Appearance.HorzLine.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(216)))), ((int)(((byte)(209)))), ((int)(((byte)(170)))));
            this.gridView产线.Appearance.HorzLine.Options.UseBackColor = true;
            this.gridView产线.Appearance.OddRow.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(242)))), ((int)(((byte)(244)))), ((int)(((byte)(236)))));
            this.gridView产线.Appearance.OddRow.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(242)))), ((int)(((byte)(244)))), ((int)(((byte)(236)))));
            this.gridView产线.Appearance.OddRow.ForeColor = System.Drawing.Color.Black;
            this.gridView产线.Appearance.OddRow.Options.UseBackColor = true;
            this.gridView产线.Appearance.OddRow.Options.UseBorderColor = true;
            this.gridView产线.Appearance.OddRow.Options.UseForeColor = true;
            this.gridView产线.Appearance.Preview.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(251)))), ((int)(((byte)(252)))), ((int)(((byte)(247)))));
            this.gridView产线.Appearance.Preview.Font = new System.Drawing.Font("Verdana", 7.5F);
            this.gridView产线.Appearance.Preview.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(148)))), ((int)(((byte)(148)))), ((int)(((byte)(148)))));
            this.gridView产线.Appearance.Preview.Options.UseBackColor = true;
            this.gridView产线.Appearance.Preview.Options.UseFont = true;
            this.gridView产线.Appearance.Preview.Options.UseForeColor = true;
            this.gridView产线.Appearance.Row.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(242)))), ((int)(((byte)(244)))), ((int)(((byte)(236)))));
            this.gridView产线.Appearance.Row.ForeColor = System.Drawing.Color.Black;
            this.gridView产线.Appearance.Row.Options.UseBackColor = true;
            this.gridView产线.Appearance.Row.Options.UseForeColor = true;
            this.gridView产线.Appearance.RowSeparator.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(236)))), ((int)(((byte)(232)))), ((int)(((byte)(201)))));
            this.gridView产线.Appearance.RowSeparator.BackColor2 = System.Drawing.Color.White;
            this.gridView产线.Appearance.RowSeparator.Options.UseBackColor = true;
            this.gridView产线.Appearance.SelectedRow.BackColor = System.Drawing.Color.Lime;
            this.gridView产线.Appearance.SelectedRow.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(237)))), ((int)(((byte)(230)))), ((int)(((byte)(203)))));
            this.gridView产线.Appearance.SelectedRow.ForeColor = System.Drawing.Color.Black;
            this.gridView产线.Appearance.SelectedRow.Options.UseBackColor = true;
            this.gridView产线.Appearance.SelectedRow.Options.UseBorderColor = true;
            this.gridView产线.Appearance.SelectedRow.Options.UseForeColor = true;
            this.gridView产线.Appearance.TopNewRow.BackColor = System.Drawing.Color.White;
            this.gridView产线.Appearance.TopNewRow.Options.UseBackColor = true;
            this.gridView产线.Appearance.VertLine.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(216)))), ((int)(((byte)(209)))), ((int)(((byte)(170)))));
            this.gridView产线.Appearance.VertLine.Options.UseBackColor = true;
            this.gridView产线.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.gridCol_选择,
            this.gridCol_LineNo,
            this.gridCol_LineName});
            this.gridView产线.GridControl = this.gridControl产线;
            this.gridView产线.IndicatorWidth = 40;
            this.gridView产线.Name = "gridView产线";
            this.gridView产线.OptionsCustomization.AllowFilter = false;
            this.gridView产线.OptionsCustomization.AllowSort = false;
            this.gridView产线.OptionsLayout.Columns.StoreAllOptions = true;
            this.gridView产线.OptionsLayout.Columns.StoreAppearance = true;
            this.gridView产线.OptionsLayout.StoreAllOptions = true;
            this.gridView产线.OptionsLayout.StoreAppearance = true;
            this.gridView产线.OptionsMenu.ShowAddNewSummaryItem = DevExpress.Utils.DefaultBoolean.True;
            this.gridView产线.OptionsMenu.ShowGroupSummaryEditorItem = true;
            this.gridView产线.OptionsNavigation.EnterMoveNextColumn = true;
            this.gridView产线.OptionsView.AutoCalcPreviewLineCount = true;
            this.gridView产线.OptionsView.ColumnAutoWidth = false;
            this.gridView产线.OptionsView.EnableAppearanceEvenRow = true;
            this.gridView产线.OptionsView.EnableAppearanceOddRow = true;
            this.gridView产线.OptionsView.ShowGroupPanel = false;
            this.gridView产线.CustomDrawRowIndicator += new DevExpress.XtraGrid.Views.Grid.RowIndicatorCustomDrawEventHandler(this.gridView1_CustomDrawRowIndicator);
            this.gridView产线.DoubleClick += new System.EventHandler(this.gridView产线_DoubleClick);
            // 
            // gridCol_选择
            // 
            this.gridCol_选择.Caption = "选择";
            this.gridCol_选择.FieldName = "选择";
            this.gridCol_选择.Fixed = DevExpress.XtraGrid.Columns.FixedStyle.Left;
            this.gridCol_选择.Name = "gridCol_选择";
            this.gridCol_选择.OptionsColumn.AllowSort = DevExpress.Utils.DefaultBoolean.False;
            this.gridCol_选择.Visible = true;
            this.gridCol_选择.VisibleIndex = 0;
            this.gridCol_选择.Width = 36;
            // 
            // gridCol_LineNo
            // 
            this.gridCol_LineNo.Caption = "编码";
            this.gridCol_LineNo.FieldName = "LineNo";
            this.gridCol_LineNo.Fixed = DevExpress.XtraGrid.Columns.FixedStyle.Left;
            this.gridCol_LineNo.Name = "gridCol_LineNo";
            this.gridCol_LineNo.OptionsColumn.AllowEdit = false;
            this.gridCol_LineNo.OptionsColumn.ReadOnly = true;
            this.gridCol_LineNo.Visible = true;
            this.gridCol_LineNo.VisibleIndex = 1;
            this.gridCol_LineNo.Width = 37;
            // 
            // gridCol_LineName
            // 
            this.gridCol_LineName.Caption = "产线";
            this.gridCol_LineName.FieldName = "LineName";
            this.gridCol_LineName.Name = "gridCol_LineName";
            this.gridCol_LineName.OptionsColumn.AllowEdit = false;
            this.gridCol_LineName.Visible = true;
            this.gridCol_LineName.VisibleIndex = 2;
            this.gridCol_LineName.Width = 345;
            // 
            // chk全选产线
            // 
            this.chk全选产线.Location = new System.Drawing.Point(12, 4);
            this.chk全选产线.Name = "chk全选产线";
            this.chk全选产线.Size = new System.Drawing.Size(93, 20);
            this.chk全选产线.TabIndex = 62;
            this.chk全选产线.Text = "全选产线";
            this.chk全选产线.UseVisualStyleBackColor = true;
            this.chk全选产线.CheckedChanged += new System.EventHandler(this.chk全选产线_CheckedChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(109, 6);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(38, 14);
            this.label2.TabIndex = 11;
            this.label2.Text = "label2";
            // 
            // gridControl日历
            // 
            this.gridControl日历.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.gridControl日历.Location = new System.Drawing.Point(2, 31);
            this.gridControl日历.MainView = this.gridView日历;
            this.gridControl日历.Name = "gridControl日历";
            this.gridControl日历.Size = new System.Drawing.Size(593, 265);
            this.gridControl日历.TabIndex = 7;
            this.gridControl日历.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView日历});
            // 
            // gridView日历
            // 
            this.gridView日历.Appearance.ColumnFilterButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(236)))), ((int)(((byte)(232)))), ((int)(((byte)(201)))));
            this.gridView日历.Appearance.ColumnFilterButton.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(236)))), ((int)(((byte)(232)))), ((int)(((byte)(201)))));
            this.gridView日历.Appearance.ColumnFilterButton.ForeColor = System.Drawing.Color.Black;
            this.gridView日历.Appearance.ColumnFilterButton.Options.UseBackColor = true;
            this.gridView日历.Appearance.ColumnFilterButton.Options.UseBorderColor = true;
            this.gridView日历.Appearance.ColumnFilterButton.Options.UseForeColor = true;
            this.gridView日历.Appearance.ColumnFilterButtonActive.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(221)))), ((int)(((byte)(231)))), ((int)(((byte)(234)))));
            this.gridView日历.Appearance.ColumnFilterButtonActive.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(221)))), ((int)(((byte)(231)))), ((int)(((byte)(234)))));
            this.gridView日历.Appearance.ColumnFilterButtonActive.ForeColor = System.Drawing.Color.Black;
            this.gridView日历.Appearance.ColumnFilterButtonActive.Options.UseBackColor = true;
            this.gridView日历.Appearance.ColumnFilterButtonActive.Options.UseBorderColor = true;
            this.gridView日历.Appearance.ColumnFilterButtonActive.Options.UseForeColor = true;
            this.gridView日历.Appearance.Empty.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(236)))), ((int)(((byte)(232)))), ((int)(((byte)(201)))));
            this.gridView日历.Appearance.Empty.BackColor2 = System.Drawing.Color.White;
            this.gridView日历.Appearance.Empty.Options.UseBackColor = true;
            this.gridView日历.Appearance.EvenRow.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(221)))), ((int)(((byte)(231)))), ((int)(((byte)(234)))));
            this.gridView日历.Appearance.EvenRow.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(221)))), ((int)(((byte)(231)))), ((int)(((byte)(234)))));
            this.gridView日历.Appearance.EvenRow.ForeColor = System.Drawing.Color.Black;
            this.gridView日历.Appearance.EvenRow.Options.UseBackColor = true;
            this.gridView日历.Appearance.EvenRow.Options.UseBorderColor = true;
            this.gridView日历.Appearance.EvenRow.Options.UseForeColor = true;
            this.gridView日历.Appearance.FilterCloseButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(216)))), ((int)(((byte)(209)))), ((int)(((byte)(179)))));
            this.gridView日历.Appearance.FilterCloseButton.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(216)))), ((int)(((byte)(209)))), ((int)(((byte)(179)))));
            this.gridView日历.Appearance.FilterCloseButton.ForeColor = System.Drawing.Color.Black;
            this.gridView日历.Appearance.FilterCloseButton.Options.UseBackColor = true;
            this.gridView日历.Appearance.FilterCloseButton.Options.UseBorderColor = true;
            this.gridView日历.Appearance.FilterCloseButton.Options.UseForeColor = true;
            this.gridView日历.Appearance.FilterPanel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(236)))), ((int)(((byte)(232)))), ((int)(((byte)(201)))));
            this.gridView日历.Appearance.FilterPanel.BackColor2 = System.Drawing.Color.White;
            this.gridView日历.Appearance.FilterPanel.ForeColor = System.Drawing.Color.Black;
            this.gridView日历.Appearance.FilterPanel.Options.UseBackColor = true;
            this.gridView日历.Appearance.FilterPanel.Options.UseForeColor = true;
            this.gridView日历.Appearance.FixedLine.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(122)))), ((int)(((byte)(114)))), ((int)(((byte)(113)))));
            this.gridView日历.Appearance.FixedLine.Options.UseBackColor = true;
            this.gridView日历.Appearance.FocusedCell.BackColor = System.Drawing.Color.White;
            this.gridView日历.Appearance.FocusedCell.ForeColor = System.Drawing.Color.Black;
            this.gridView日历.Appearance.FocusedCell.Options.UseBackColor = true;
            this.gridView日历.Appearance.FocusedCell.Options.UseForeColor = true;
            this.gridView日历.Appearance.FocusedRow.BackColor = System.Drawing.Color.Lime;
            this.gridView日历.Appearance.FocusedRow.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(219)))), ((int)(((byte)(188)))));
            this.gridView日历.Appearance.FocusedRow.ForeColor = System.Drawing.Color.Black;
            this.gridView日历.Appearance.FocusedRow.Options.UseBackColor = true;
            this.gridView日历.Appearance.FocusedRow.Options.UseBorderColor = true;
            this.gridView日历.Appearance.FocusedRow.Options.UseForeColor = true;
            this.gridView日历.Appearance.FooterPanel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(216)))), ((int)(((byte)(209)))), ((int)(((byte)(170)))));
            this.gridView日历.Appearance.FooterPanel.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(216)))), ((int)(((byte)(209)))), ((int)(((byte)(170)))));
            this.gridView日历.Appearance.FooterPanel.ForeColor = System.Drawing.Color.Black;
            this.gridView日历.Appearance.FooterPanel.Options.UseBackColor = true;
            this.gridView日历.Appearance.FooterPanel.Options.UseBorderColor = true;
            this.gridView日历.Appearance.FooterPanel.Options.UseForeColor = true;
            this.gridView日历.Appearance.GroupButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(216)))), ((int)(((byte)(209)))), ((int)(((byte)(179)))));
            this.gridView日历.Appearance.GroupButton.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(216)))), ((int)(((byte)(209)))), ((int)(((byte)(179)))));
            this.gridView日历.Appearance.GroupButton.Options.UseBackColor = true;
            this.gridView日历.Appearance.GroupButton.Options.UseBorderColor = true;
            this.gridView日历.Appearance.GroupFooter.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(236)))), ((int)(((byte)(232)))), ((int)(((byte)(201)))));
            this.gridView日历.Appearance.GroupFooter.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(236)))), ((int)(((byte)(232)))), ((int)(((byte)(201)))));
            this.gridView日历.Appearance.GroupFooter.ForeColor = System.Drawing.Color.Black;
            this.gridView日历.Appearance.GroupFooter.Options.UseBackColor = true;
            this.gridView日历.Appearance.GroupFooter.Options.UseBorderColor = true;
            this.gridView日历.Appearance.GroupFooter.Options.UseForeColor = true;
            this.gridView日历.Appearance.GroupPanel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(246)))), ((int)(((byte)(242)))), ((int)(((byte)(213)))));
            this.gridView日历.Appearance.GroupPanel.BackColor2 = System.Drawing.Color.White;
            this.gridView日历.Appearance.GroupPanel.ForeColor = System.Drawing.Color.Black;
            this.gridView日历.Appearance.GroupPanel.Options.UseBackColor = true;
            this.gridView日历.Appearance.GroupPanel.Options.UseForeColor = true;
            this.gridView日历.Appearance.GroupRow.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(236)))), ((int)(((byte)(232)))), ((int)(((byte)(201)))));
            this.gridView日历.Appearance.GroupRow.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(236)))), ((int)(((byte)(232)))), ((int)(((byte)(201)))));
            this.gridView日历.Appearance.GroupRow.ForeColor = System.Drawing.Color.Black;
            this.gridView日历.Appearance.GroupRow.Options.UseBackColor = true;
            this.gridView日历.Appearance.GroupRow.Options.UseBorderColor = true;
            this.gridView日历.Appearance.GroupRow.Options.UseForeColor = true;
            this.gridView日历.Appearance.HeaderPanel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(216)))), ((int)(((byte)(209)))), ((int)(((byte)(170)))));
            this.gridView日历.Appearance.HeaderPanel.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(216)))), ((int)(((byte)(209)))), ((int)(((byte)(170)))));
            this.gridView日历.Appearance.HeaderPanel.ForeColor = System.Drawing.Color.Black;
            this.gridView日历.Appearance.HeaderPanel.Options.UseBackColor = true;
            this.gridView日历.Appearance.HeaderPanel.Options.UseBorderColor = true;
            this.gridView日历.Appearance.HeaderPanel.Options.UseForeColor = true;
            this.gridView日历.Appearance.HideSelectionRow.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(237)))), ((int)(((byte)(230)))), ((int)(((byte)(203)))));
            this.gridView日历.Appearance.HideSelectionRow.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(237)))), ((int)(((byte)(230)))), ((int)(((byte)(203)))));
            this.gridView日历.Appearance.HideSelectionRow.ForeColor = System.Drawing.Color.Black;
            this.gridView日历.Appearance.HideSelectionRow.Options.UseBackColor = true;
            this.gridView日历.Appearance.HideSelectionRow.Options.UseBorderColor = true;
            this.gridView日历.Appearance.HideSelectionRow.Options.UseForeColor = true;
            this.gridView日历.Appearance.HorzLine.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(216)))), ((int)(((byte)(209)))), ((int)(((byte)(170)))));
            this.gridView日历.Appearance.HorzLine.Options.UseBackColor = true;
            this.gridView日历.Appearance.OddRow.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(242)))), ((int)(((byte)(244)))), ((int)(((byte)(236)))));
            this.gridView日历.Appearance.OddRow.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(242)))), ((int)(((byte)(244)))), ((int)(((byte)(236)))));
            this.gridView日历.Appearance.OddRow.ForeColor = System.Drawing.Color.Black;
            this.gridView日历.Appearance.OddRow.Options.UseBackColor = true;
            this.gridView日历.Appearance.OddRow.Options.UseBorderColor = true;
            this.gridView日历.Appearance.OddRow.Options.UseForeColor = true;
            this.gridView日历.Appearance.Preview.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(251)))), ((int)(((byte)(252)))), ((int)(((byte)(247)))));
            this.gridView日历.Appearance.Preview.Font = new System.Drawing.Font("Verdana", 7.5F);
            this.gridView日历.Appearance.Preview.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(148)))), ((int)(((byte)(148)))), ((int)(((byte)(148)))));
            this.gridView日历.Appearance.Preview.Options.UseBackColor = true;
            this.gridView日历.Appearance.Preview.Options.UseFont = true;
            this.gridView日历.Appearance.Preview.Options.UseForeColor = true;
            this.gridView日历.Appearance.Row.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(242)))), ((int)(((byte)(244)))), ((int)(((byte)(236)))));
            this.gridView日历.Appearance.Row.ForeColor = System.Drawing.Color.Black;
            this.gridView日历.Appearance.Row.Options.UseBackColor = true;
            this.gridView日历.Appearance.Row.Options.UseForeColor = true;
            this.gridView日历.Appearance.RowSeparator.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(236)))), ((int)(((byte)(232)))), ((int)(((byte)(201)))));
            this.gridView日历.Appearance.RowSeparator.BackColor2 = System.Drawing.Color.White;
            this.gridView日历.Appearance.RowSeparator.Options.UseBackColor = true;
            this.gridView日历.Appearance.SelectedRow.BackColor = System.Drawing.Color.Lime;
            this.gridView日历.Appearance.SelectedRow.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(237)))), ((int)(((byte)(230)))), ((int)(((byte)(203)))));
            this.gridView日历.Appearance.SelectedRow.ForeColor = System.Drawing.Color.Black;
            this.gridView日历.Appearance.SelectedRow.Options.UseBackColor = true;
            this.gridView日历.Appearance.SelectedRow.Options.UseBorderColor = true;
            this.gridView日历.Appearance.SelectedRow.Options.UseForeColor = true;
            this.gridView日历.Appearance.TopNewRow.BackColor = System.Drawing.Color.White;
            this.gridView日历.Appearance.TopNewRow.Options.UseBackColor = true;
            this.gridView日历.Appearance.VertLine.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(216)))), ((int)(((byte)(209)))), ((int)(((byte)(170)))));
            this.gridView日历.Appearance.VertLine.Options.UseBackColor = true;
            this.gridView日历.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.gridColchoose,
            this.gridColiID,
            this.gridColGUID,
            this.gridColCreateUid,
            this.gridColCreateDate,
            this.gridColUpdataUid,
            this.gridColUpdataDate,
            this.gridColiYear,
            this.gridColiMonth,
            this.gridColLineNo});
            this.gridView日历.GridControl = this.gridControl日历;
            this.gridView日历.IndicatorWidth = 40;
            this.gridView日历.Name = "gridView日历";
            this.gridView日历.OptionsLayout.Columns.StoreAllOptions = true;
            this.gridView日历.OptionsLayout.Columns.StoreAppearance = true;
            this.gridView日历.OptionsLayout.StoreAllOptions = true;
            this.gridView日历.OptionsLayout.StoreAppearance = true;
            this.gridView日历.OptionsMenu.ShowAddNewSummaryItem = DevExpress.Utils.DefaultBoolean.True;
            this.gridView日历.OptionsMenu.ShowGroupSummaryEditorItem = true;
            this.gridView日历.OptionsNavigation.EnterMoveNextColumn = true;
            this.gridView日历.OptionsSelection.MultiSelect = true;
            this.gridView日历.OptionsView.AutoCalcPreviewLineCount = true;
            this.gridView日历.OptionsView.ColumnAutoWidth = false;
            this.gridView日历.OptionsView.EnableAppearanceEvenRow = true;
            this.gridView日历.OptionsView.EnableAppearanceOddRow = true;
            this.gridView日历.OptionsView.ShowGroupPanel = false;
            this.gridView日历.FocusedRowChanged += new DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventHandler(this.gridView1_FocusedRowChanged);
            this.gridView日历.CustomDrawRowIndicator += new DevExpress.XtraGrid.Views.Grid.RowIndicatorCustomDrawEventHandler(this.gridView1_CustomDrawRowIndicator);
            this.gridView日历.FocusedColumnChanged += new DevExpress.XtraGrid.Views.Base.FocusedColumnChangedEventHandler(this.gridView1_FocusedColumnChanged);
            this.gridView日历.CellValueChanged += new DevExpress.XtraGrid.Views.Base.CellValueChangedEventHandler(this.gridView1_CellValueChanged);
            this.gridView日历.RowCellStyle += new DevExpress.XtraGrid.Views.Grid.RowCellStyleEventHandler(this.gridView1_RowCellStyle);
            // 
            // gridColchoose
            // 
            this.gridColchoose.Caption = "选择";
            this.gridColchoose.FieldName = "choose";
            this.gridColchoose.Fixed = DevExpress.XtraGrid.Columns.FixedStyle.Left;
            this.gridColchoose.Name = "gridColchoose";
            this.gridColchoose.OptionsColumn.AllowSort = DevExpress.Utils.DefaultBoolean.False;
            this.gridColchoose.Visible = true;
            this.gridColchoose.VisibleIndex = 0;
            this.gridColchoose.Width = 36;
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
            this.gridColUpdataUid.FieldName = "UpdataUid";
            this.gridColUpdataUid.Name = "gridColUpdataUid";
            this.gridColUpdataUid.OptionsColumn.AllowEdit = false;
            this.gridColUpdataUid.OptionsColumn.AllowSort = DevExpress.Utils.DefaultBoolean.False;
            // 
            // gridColUpdataDate
            // 
            this.gridColUpdataDate.Caption = "修改日期";
            this.gridColUpdataDate.FieldName = "UpdataDate";
            this.gridColUpdataDate.Name = "gridColUpdataDate";
            this.gridColUpdataDate.OptionsColumn.AllowEdit = false;
            this.gridColUpdataDate.OptionsColumn.AllowSort = DevExpress.Utils.DefaultBoolean.False;
            // 
            // gridColiYear
            // 
            this.gridColiYear.Caption = "iYear";
            this.gridColiYear.FieldName = "iYear";
            this.gridColiYear.Fixed = DevExpress.XtraGrid.Columns.FixedStyle.Left;
            this.gridColiYear.Name = "gridColiYear";
            this.gridColiYear.OptionsColumn.AllowSort = DevExpress.Utils.DefaultBoolean.False;
            // 
            // gridColiMonth
            // 
            this.gridColiMonth.Caption = "月";
            this.gridColiMonth.FieldName = "iMonth";
            this.gridColiMonth.Fixed = DevExpress.XtraGrid.Columns.FixedStyle.Left;
            this.gridColiMonth.Name = "gridColiMonth";
            this.gridColiMonth.OptionsColumn.AllowSort = DevExpress.Utils.DefaultBoolean.False;
            this.gridColiMonth.OptionsColumn.ReadOnly = true;
            this.gridColiMonth.Visible = true;
            this.gridColiMonth.VisibleIndex = 1;
            this.gridColiMonth.Width = 48;
            // 
            // gridColLineNo
            // 
            this.gridColLineNo.Caption = "LineNo";
            this.gridColLineNo.FieldName = "LineNo";
            this.gridColLineNo.Name = "gridColLineNo";
            this.gridColLineNo.OptionsColumn.ReadOnly = true;
            // 
            // chk全选日历
            // 
            this.chk全选日历.Location = new System.Drawing.Point(2, 4);
            this.chk全选日历.Name = "chk全选日历";
            this.chk全选日历.Size = new System.Drawing.Size(77, 20);
            this.chk全选日历.TabIndex = 10;
            this.chk全选日历.Text = "全选日历";
            this.chk全选日历.UseVisualStyleBackColor = true;
            this.chk全选日历.CheckedChanged += new System.EventHandler(this.chkAll_CheckedChanged);
            // 
            // lookUpEdit班次
            // 
            this.lookUpEdit班次.Location = new System.Drawing.Point(194, 12);
            this.lookUpEdit班次.Name = "lookUpEdit班次";
            this.lookUpEdit班次.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.lookUpEdit班次.Properties.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("班次", "班次"),
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("小时数", "小时数")});
            this.lookUpEdit班次.Properties.DisplayMember = "班次";
            this.lookUpEdit班次.Properties.NullText = "";
            this.lookUpEdit班次.Properties.ValueMember = "小时数";
            this.lookUpEdit班次.Size = new System.Drawing.Size(52, 21);
            this.lookUpEdit班次.StyleController = this.layoutControl1;
            this.lookUpEdit班次.TabIndex = 11;
            this.lookUpEdit班次.EditValueChanged += new System.EventHandler(this.lookUpEdit班次_EditValueChanged);
            // 
            // textEditDayTime
            // 
            this.textEditDayTime.EditValue = "8";
            this.textEditDayTime.Location = new System.Drawing.Point(314, 12);
            this.textEditDayTime.Name = "textEditDayTime";
            this.textEditDayTime.Size = new System.Drawing.Size(50, 21);
            this.textEditDayTime.StyleController = this.layoutControl1;
            this.textEditDayTime.TabIndex = 9;
            // 
            // lookUpEditYear
            // 
            this.lookUpEditYear.Location = new System.Drawing.Point(76, 12);
            this.lookUpEditYear.Name = "lookUpEditYear";
            this.lookUpEditYear.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.lookUpEditYear.Properties.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("iYear", "年度")});
            this.lookUpEditYear.Properties.DisplayMember = "iYear";
            this.lookUpEditYear.Properties.NullText = "";
            this.lookUpEditYear.Properties.ValueMember = "iYear";
            this.lookUpEditYear.Size = new System.Drawing.Size(50, 21);
            this.lookUpEditYear.StyleController = this.layoutControl1;
            this.lookUpEditYear.TabIndex = 7;
            this.lookUpEditYear.EditValueChanged += new System.EventHandler(this.lookUpEditYear_EditValueChanged);
            // 
            // label1
            // 
            this.label1.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.label1.Location = new System.Drawing.Point(12, 37);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(892, 20);
            this.label1.TabIndex = 8;
            this.label1.Text = "黑色：该日期不合法； 淡黄色 周六；  黄色：周日；  红色：节假日";
            // 
            // layoutControlGroup1
            // 
            this.layoutControlGroup1.CustomizationFormText = "layoutControlGroup1";
            this.layoutControlGroup1.EnableIndentsWithoutBorders = DevExpress.Utils.DefaultBoolean.True;
            this.layoutControlGroup1.GroupBordersVisible = false;
            this.layoutControlGroup1.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.layoutControlItem1,
            this.layoutControlItem4,
            this.emptySpaceItem1,
            this.layoutControlItem6,
            this.layoutControlItem2,
            this.layoutControlItem8});
            this.layoutControlGroup1.Location = new System.Drawing.Point(0, 0);
            this.layoutControlGroup1.Name = "Root";
            this.layoutControlGroup1.Size = new System.Drawing.Size(916, 376);
            this.layoutControlGroup1.Text = "Root";
            this.layoutControlGroup1.TextVisible = false;
            // 
            // layoutControlItem1
            // 
            this.layoutControlItem1.Control = this.lookUpEditYear;
            this.layoutControlItem1.CustomizationFormText = "年度";
            this.layoutControlItem1.Location = new System.Drawing.Point(0, 0);
            this.layoutControlItem1.MaxSize = new System.Drawing.Size(118, 25);
            this.layoutControlItem1.MinSize = new System.Drawing.Size(118, 25);
            this.layoutControlItem1.Name = "layoutControlItem1";
            this.layoutControlItem1.Size = new System.Drawing.Size(118, 25);
            this.layoutControlItem1.SizeConstraintsType = DevExpress.XtraLayout.SizeConstraintsType.Custom;
            this.layoutControlItem1.Text = "年度";
            this.layoutControlItem1.TextSize = new System.Drawing.Size(60, 14);
            // 
            // layoutControlItem4
            // 
            this.layoutControlItem4.Control = this.textEditDayTime;
            this.layoutControlItem4.CustomizationFormText = "默认日工时";
            this.layoutControlItem4.Location = new System.Drawing.Point(238, 0);
            this.layoutControlItem4.MaxSize = new System.Drawing.Size(118, 25);
            this.layoutControlItem4.MinSize = new System.Drawing.Size(118, 25);
            this.layoutControlItem4.Name = "layoutControlItem4";
            this.layoutControlItem4.Size = new System.Drawing.Size(118, 25);
            this.layoutControlItem4.SizeConstraintsType = DevExpress.XtraLayout.SizeConstraintsType.Custom;
            this.layoutControlItem4.Text = "默认日工时";
            this.layoutControlItem4.TextSize = new System.Drawing.Size(60, 14);
            // 
            // emptySpaceItem1
            // 
            this.emptySpaceItem1.AllowHotTrack = false;
            this.emptySpaceItem1.CustomizationFormText = "emptySpaceItem1";
            this.emptySpaceItem1.Location = new System.Drawing.Point(356, 0);
            this.emptySpaceItem1.Name = "emptySpaceItem1";
            this.emptySpaceItem1.Size = new System.Drawing.Size(540, 25);
            this.emptySpaceItem1.Text = "emptySpaceItem1";
            this.emptySpaceItem1.TextSize = new System.Drawing.Size(0, 0);
            // 
            // layoutControlItem6
            // 
            this.layoutControlItem6.Control = this.lookUpEdit班次;
            this.layoutControlItem6.CustomizationFormText = "班次";
            this.layoutControlItem6.Location = new System.Drawing.Point(118, 0);
            this.layoutControlItem6.MaxSize = new System.Drawing.Size(120, 25);
            this.layoutControlItem6.MinSize = new System.Drawing.Size(120, 25);
            this.layoutControlItem6.Name = "layoutControlItem6";
            this.layoutControlItem6.Size = new System.Drawing.Size(120, 25);
            this.layoutControlItem6.SizeConstraintsType = DevExpress.XtraLayout.SizeConstraintsType.Custom;
            this.layoutControlItem6.Text = "班次";
            this.layoutControlItem6.TextSize = new System.Drawing.Size(60, 14);
            // 
            // layoutControlItem2
            // 
            this.layoutControlItem2.Control = this.label1;
            this.layoutControlItem2.CustomizationFormText = "layoutControlItem2";
            this.layoutControlItem2.Location = new System.Drawing.Point(0, 25);
            this.layoutControlItem2.MaxSize = new System.Drawing.Size(0, 24);
            this.layoutControlItem2.MinSize = new System.Drawing.Size(24, 24);
            this.layoutControlItem2.Name = "layoutControlItem2";
            this.layoutControlItem2.Size = new System.Drawing.Size(896, 24);
            this.layoutControlItem2.SizeConstraintsType = DevExpress.XtraLayout.SizeConstraintsType.Custom;
            this.layoutControlItem2.Text = "layoutControlItem2";
            this.layoutControlItem2.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem2.TextToControlDistance = 0;
            this.layoutControlItem2.TextVisible = false;
            // 
            // layoutControlItem8
            // 
            this.layoutControlItem8.Control = this.splitContainerControl1;
            this.layoutControlItem8.CustomizationFormText = "layoutControlItem8";
            this.layoutControlItem8.Location = new System.Drawing.Point(0, 49);
            this.layoutControlItem8.Name = "layoutControlItem8";
            this.layoutControlItem8.Size = new System.Drawing.Size(896, 307);
            this.layoutControlItem8.Text = "layoutControlItem8";
            this.layoutControlItem8.TextLocation = DevExpress.Utils.Locations.Top;
            this.layoutControlItem8.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem8.TextToControlDistance = 0;
            this.layoutControlItem8.TextVisible = false;
            // 
            // FrmWorkCalendar
            // 
            this.Appearance.BackColor = System.Drawing.SystemColors.Control;
            this.Appearance.Options.UseBackColor = true;
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(914, 405);
            this.Controls.Add(this.layoutControl1);
            this.Name = "FrmWorkCalendar";
            this.Text = "工作日历";
            this.Load += new System.EventHandler(this.Frm_Load);
            this.Controls.SetChildIndex(this.layoutControl1, 0);
            ((System.ComponentModel.ISupportInitialize)(this.dsPrint)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dsForm)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtSel)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControl1)).EndInit();
            this.layoutControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerControl1)).EndInit();
            this.splitContainerControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gridControl产线)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView产线)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl日历)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView日历)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lookUpEdit班次.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.textEditDayTime.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lookUpEditYear.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem6)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem8)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraLayout.LayoutControl layoutControl1;
        private DevExpress.XtraLayout.LayoutControlGroup layoutControlGroup1;
        private DevExpress.XtraEditors.LookUpEdit lookUpEditYear;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem1;
        private DevExpress.XtraLayout.EmptySpaceItem emptySpaceItem1;
        private System.Windows.Forms.Label label1;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem2;
        private DevExpress.XtraEditors.TextEdit textEditDayTime;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem4;
        private System.Windows.Forms.CheckBox chk全选日历;
        private DevExpress.XtraEditors.LookUpEdit lookUpEdit班次;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem6;
        private System.Windows.Forms.CheckBox chk全选产线;
        private DevExpress.XtraEditors.SplitContainerControl splitContainerControl1;
        private DevExpress.XtraGrid.GridControl gridControl产线;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView产线;
        private DevExpress.XtraGrid.Columns.GridColumn gridCol_选择;
        private DevExpress.XtraGrid.Columns.GridColumn gridCol_LineNo;
        private DevExpress.XtraGrid.Columns.GridColumn gridCol_LineName;
        private System.Windows.Forms.Label label2;
        private DevExpress.XtraGrid.GridControl gridControl日历;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView日历;
        private DevExpress.XtraGrid.Columns.GridColumn gridColchoose;
        private DevExpress.XtraGrid.Columns.GridColumn gridColiID;
        private DevExpress.XtraGrid.Columns.GridColumn gridColGUID;
        private DevExpress.XtraGrid.Columns.GridColumn gridColCreateUid;
        private DevExpress.XtraGrid.Columns.GridColumn gridColCreateDate;
        private DevExpress.XtraGrid.Columns.GridColumn gridColUpdataUid;
        private DevExpress.XtraGrid.Columns.GridColumn gridColUpdataDate;
        private DevExpress.XtraGrid.Columns.GridColumn gridColiYear;
        private DevExpress.XtraGrid.Columns.GridColumn gridColiMonth;
        private DevExpress.XtraGrid.Columns.GridColumn gridColLineNo;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem8;
    }
}