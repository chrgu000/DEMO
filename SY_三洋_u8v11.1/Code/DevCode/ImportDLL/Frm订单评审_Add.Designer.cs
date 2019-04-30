namespace ImportDLL
{
    partial class Frm订单评审_Add
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
            this.chkAll = new System.Windows.Forms.CheckBox();
            this.dtm单据日期1 = new DevExpress.XtraEditors.DateEdit();
            this.dtm单据日期2 = new DevExpress.XtraEditors.DateEdit();
            this.gridControl1 = new DevExpress.XtraGrid.GridControl();
            this.gridView1 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.gridColChoose = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridCol销售订单号 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridCol单据日期 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridCol客户编码 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridCol客户简称 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridCol存货编码 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridCol存货名称 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridCol规格型号 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridCol订单数量 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridCol交货日期 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridCol销售订单子表ID = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridCol已评审数量 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridCol待评审数量 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridCol行号 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.lookUpEdit销售订单号2 = new DevExpress.XtraEditors.LookUpEdit();
            this.lookUpEdit销售订单号1 = new DevExpress.XtraEditors.LookUpEdit();
            this.layoutControlGroup1 = new DevExpress.XtraLayout.LayoutControlGroup();
            this.layoutControlItem12 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem1 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem2 = new DevExpress.XtraLayout.LayoutControlItem();
            this.emptySpaceItem3 = new DevExpress.XtraLayout.EmptySpaceItem();
            this.layoutControlItem6 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem5 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem3 = new DevExpress.XtraLayout.LayoutControlItem();
            this.btnOK = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnSEL = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControl1)).BeginInit();
            this.layoutControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dtm单据日期1.Properties.VistaTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtm单据日期1.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtm单据日期2.Properties.VistaTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtm单据日期2.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lookUpEdit销售订单号2.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lookUpEdit销售订单号1.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem12)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem6)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem5)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem3)).BeginInit();
            this.SuspendLayout();
            // 
            // layoutControl1
            // 
            this.layoutControl1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.layoutControl1.Controls.Add(this.chkAll);
            this.layoutControl1.Controls.Add(this.dtm单据日期1);
            this.layoutControl1.Controls.Add(this.dtm单据日期2);
            this.layoutControl1.Controls.Add(this.gridControl1);
            this.layoutControl1.Controls.Add(this.lookUpEdit销售订单号2);
            this.layoutControl1.Controls.Add(this.lookUpEdit销售订单号1);
            this.layoutControl1.Location = new System.Drawing.Point(12, 12);
            this.layoutControl1.Name = "layoutControl1";
            this.layoutControl1.OptionsCustomizationForm.DesignTimeCustomizationFormPositionAndSize = new System.Drawing.Rectangle(376, 251, 250, 350);
            this.layoutControl1.Root = this.layoutControlGroup1;
            this.layoutControl1.Size = new System.Drawing.Size(900, 376);
            this.layoutControl1.TabIndex = 0;
            this.layoutControl1.Text = "layoutControl1";
            // 
            // chkAll
            // 
            this.chkAll.Location = new System.Drawing.Point(12, 37);
            this.chkAll.Name = "chkAll";
            this.chkAll.Size = new System.Drawing.Size(876, 20);
            this.chkAll.TabIndex = 10;
            this.chkAll.Text = "全选";
            this.chkAll.UseVisualStyleBackColor = true;
            this.chkAll.CheckedChanged += new System.EventHandler(this.chkAll_CheckedChanged);
            // 
            // dtm单据日期1
            // 
            this.dtm单据日期1.EditValue = null;
            this.dtm单据日期1.Location = new System.Drawing.Point(488, 12);
            this.dtm单据日期1.Name = "dtm单据日期1";
            this.dtm单据日期1.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.dtm单据日期1.Properties.VistaTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
            this.dtm单据日期1.Size = new System.Drawing.Size(165, 21);
            this.dtm单据日期1.StyleController = this.layoutControl1;
            this.dtm单据日期1.TabIndex = 9;
            // 
            // dtm单据日期2
            // 
            this.dtm单据日期2.EditValue = null;
            this.dtm单据日期2.Location = new System.Drawing.Point(657, 12);
            this.dtm单据日期2.Name = "dtm单据日期2";
            this.dtm单据日期2.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.dtm单据日期2.Properties.VistaTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
            this.dtm单据日期2.Size = new System.Drawing.Size(199, 21);
            this.dtm单据日期2.StyleController = this.layoutControl1;
            this.dtm单据日期2.TabIndex = 8;
            // 
            // gridControl1
            // 
            this.gridControl1.Location = new System.Drawing.Point(12, 78);
            this.gridControl1.MainView = this.gridView1;
            this.gridControl1.Name = "gridControl1";
            this.gridControl1.Size = new System.Drawing.Size(876, 286);
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
            this.gridColChoose,
            this.gridCol销售订单号,
            this.gridCol单据日期,
            this.gridCol客户编码,
            this.gridCol客户简称,
            this.gridCol存货编码,
            this.gridCol存货名称,
            this.gridCol规格型号,
            this.gridCol订单数量,
            this.gridCol交货日期,
            this.gridCol销售订单子表ID,
            this.gridCol已评审数量,
            this.gridCol待评审数量,
            this.gridCol行号});
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
            this.gridView1.OptionsView.AutoCalcPreviewLineCount = true;
            this.gridView1.OptionsView.ColumnAutoWidth = false;
            this.gridView1.OptionsView.EnableAppearanceEvenRow = true;
            this.gridView1.OptionsView.EnableAppearanceOddRow = true;
            this.gridView1.OptionsView.ShowFooter = true;
            this.gridView1.OptionsView.ShowGroupPanel = false;
            this.gridView1.CustomDrawRowIndicator += new DevExpress.XtraGrid.Views.Grid.RowIndicatorCustomDrawEventHandler(this.gridView1_CustomDrawRowIndicator);
            // 
            // gridColChoose
            // 
            this.gridColChoose.Caption = "选择";
            this.gridColChoose.FieldName = "Choose";
            this.gridColChoose.Fixed = DevExpress.XtraGrid.Columns.FixedStyle.Left;
            this.gridColChoose.Name = "gridColChoose";
            this.gridColChoose.OptionsColumn.AllowSort = DevExpress.Utils.DefaultBoolean.False;
            this.gridColChoose.OptionsColumn.ReadOnly = true;
            this.gridColChoose.OptionsFilter.AllowFilter = false;
            this.gridColChoose.Visible = true;
            this.gridColChoose.VisibleIndex = 0;
            this.gridColChoose.Width = 45;
            // 
            // gridCol销售订单号
            // 
            this.gridCol销售订单号.Caption = "销售订单号";
            this.gridCol销售订单号.FieldName = "销售订单号";
            this.gridCol销售订单号.Name = "gridCol销售订单号";
            this.gridCol销售订单号.OptionsColumn.AllowEdit = false;
            this.gridCol销售订单号.OptionsColumn.AllowSort = DevExpress.Utils.DefaultBoolean.False;
            this.gridCol销售订单号.OptionsColumn.ReadOnly = true;
            this.gridCol销售订单号.Visible = true;
            this.gridCol销售订单号.VisibleIndex = 1;
            this.gridCol销售订单号.Width = 152;
            // 
            // gridCol单据日期
            // 
            this.gridCol单据日期.Caption = "单据日期";
            this.gridCol单据日期.FieldName = "单据日期";
            this.gridCol单据日期.Name = "gridCol单据日期";
            this.gridCol单据日期.OptionsColumn.AllowEdit = false;
            this.gridCol单据日期.OptionsColumn.AllowSort = DevExpress.Utils.DefaultBoolean.False;
            this.gridCol单据日期.OptionsColumn.ReadOnly = true;
            this.gridCol单据日期.Visible = true;
            this.gridCol单据日期.VisibleIndex = 2;
            // 
            // gridCol客户编码
            // 
            this.gridCol客户编码.Caption = "客户编码";
            this.gridCol客户编码.FieldName = "客户编码";
            this.gridCol客户编码.Name = "gridCol客户编码";
            this.gridCol客户编码.OptionsColumn.AllowEdit = false;
            this.gridCol客户编码.OptionsColumn.AllowSort = DevExpress.Utils.DefaultBoolean.False;
            this.gridCol客户编码.OptionsColumn.ReadOnly = true;
            this.gridCol客户编码.Visible = true;
            this.gridCol客户编码.VisibleIndex = 3;
            // 
            // gridCol客户简称
            // 
            this.gridCol客户简称.Caption = "客户简称";
            this.gridCol客户简称.FieldName = "客户简称";
            this.gridCol客户简称.Name = "gridCol客户简称";
            this.gridCol客户简称.OptionsColumn.AllowEdit = false;
            this.gridCol客户简称.OptionsColumn.AllowSort = DevExpress.Utils.DefaultBoolean.False;
            this.gridCol客户简称.OptionsColumn.ReadOnly = true;
            this.gridCol客户简称.Visible = true;
            this.gridCol客户简称.VisibleIndex = 4;
            // 
            // gridCol存货编码
            // 
            this.gridCol存货编码.Caption = "存货编码";
            this.gridCol存货编码.FieldName = "存货编码";
            this.gridCol存货编码.Name = "gridCol存货编码";
            this.gridCol存货编码.OptionsColumn.AllowEdit = false;
            this.gridCol存货编码.OptionsColumn.AllowSort = DevExpress.Utils.DefaultBoolean.False;
            this.gridCol存货编码.OptionsColumn.ReadOnly = true;
            this.gridCol存货编码.Visible = true;
            this.gridCol存货编码.VisibleIndex = 6;
            // 
            // gridCol存货名称
            // 
            this.gridCol存货名称.Caption = "存货名称";
            this.gridCol存货名称.FieldName = "存货名称";
            this.gridCol存货名称.Name = "gridCol存货名称";
            this.gridCol存货名称.OptionsColumn.AllowEdit = false;
            this.gridCol存货名称.OptionsColumn.AllowSort = DevExpress.Utils.DefaultBoolean.False;
            this.gridCol存货名称.OptionsColumn.ReadOnly = true;
            this.gridCol存货名称.Visible = true;
            this.gridCol存货名称.VisibleIndex = 7;
            // 
            // gridCol规格型号
            // 
            this.gridCol规格型号.Caption = "规格型号";
            this.gridCol规格型号.FieldName = "规格型号";
            this.gridCol规格型号.Name = "gridCol规格型号";
            this.gridCol规格型号.OptionsColumn.AllowEdit = false;
            this.gridCol规格型号.OptionsColumn.AllowSort = DevExpress.Utils.DefaultBoolean.False;
            this.gridCol规格型号.OptionsColumn.ReadOnly = true;
            this.gridCol规格型号.Visible = true;
            this.gridCol规格型号.VisibleIndex = 8;
            // 
            // gridCol订单数量
            // 
            this.gridCol订单数量.Caption = "订单数量";
            this.gridCol订单数量.FieldName = "订单数量";
            this.gridCol订单数量.Name = "gridCol订单数量";
            this.gridCol订单数量.OptionsColumn.AllowEdit = false;
            this.gridCol订单数量.OptionsColumn.AllowSort = DevExpress.Utils.DefaultBoolean.False;
            this.gridCol订单数量.OptionsColumn.ReadOnly = true;
            this.gridCol订单数量.Visible = true;
            this.gridCol订单数量.VisibleIndex = 11;
            // 
            // gridCol交货日期
            // 
            this.gridCol交货日期.Caption = "交货日期";
            this.gridCol交货日期.FieldName = "交货日期";
            this.gridCol交货日期.Name = "gridCol交货日期";
            this.gridCol交货日期.OptionsColumn.AllowEdit = false;
            this.gridCol交货日期.OptionsColumn.AllowSort = DevExpress.Utils.DefaultBoolean.False;
            this.gridCol交货日期.OptionsColumn.ReadOnly = true;
            this.gridCol交货日期.Visible = true;
            this.gridCol交货日期.VisibleIndex = 10;
            // 
            // gridCol销售订单子表ID
            // 
            this.gridCol销售订单子表ID.Caption = "销售订单子表ID";
            this.gridCol销售订单子表ID.FieldName = "销售订单子表ID";
            this.gridCol销售订单子表ID.Name = "gridCol销售订单子表ID";
            this.gridCol销售订单子表ID.OptionsColumn.AllowEdit = false;
            this.gridCol销售订单子表ID.OptionsColumn.AllowSort = DevExpress.Utils.DefaultBoolean.False;
            this.gridCol销售订单子表ID.OptionsColumn.ReadOnly = true;
            this.gridCol销售订单子表ID.Visible = true;
            this.gridCol销售订单子表ID.VisibleIndex = 13;
            this.gridCol销售订单子表ID.Width = 118;
            // 
            // gridCol已评审数量
            // 
            this.gridCol已评审数量.Caption = "已评审数量";
            this.gridCol已评审数量.FieldName = "已评审数量";
            this.gridCol已评审数量.Name = "gridCol已评审数量";
            this.gridCol已评审数量.OptionsColumn.AllowEdit = false;
            this.gridCol已评审数量.OptionsColumn.AllowSort = DevExpress.Utils.DefaultBoolean.False;
            this.gridCol已评审数量.OptionsColumn.ReadOnly = true;
            this.gridCol已评审数量.Visible = true;
            this.gridCol已评审数量.VisibleIndex = 12;
            // 
            // gridCol待评审数量
            // 
            this.gridCol待评审数量.Caption = "待评审数量";
            this.gridCol待评审数量.FieldName = "待评审数量";
            this.gridCol待评审数量.Name = "gridCol待评审数量";
            this.gridCol待评审数量.OptionsColumn.AllowEdit = false;
            this.gridCol待评审数量.OptionsColumn.AllowSort = DevExpress.Utils.DefaultBoolean.False;
            this.gridCol待评审数量.OptionsColumn.ReadOnly = true;
            this.gridCol待评审数量.Visible = true;
            this.gridCol待评审数量.VisibleIndex = 9;
            // 
            // gridCol行号
            // 
            this.gridCol行号.Caption = "行号";
            this.gridCol行号.FieldName = "行号";
            this.gridCol行号.Name = "gridCol行号";
            this.gridCol行号.OptionsColumn.AllowEdit = false;
            this.gridCol行号.OptionsColumn.AllowSort = DevExpress.Utils.DefaultBoolean.False;
            this.gridCol行号.OptionsColumn.ReadOnly = true;
            this.gridCol行号.Visible = true;
            this.gridCol行号.VisibleIndex = 5;
            this.gridCol行号.Width = 45;
            // 
            // lookUpEdit销售订单号2
            // 
            this.lookUpEdit销售订单号2.Location = new System.Drawing.Point(244, 12);
            this.lookUpEdit销售订单号2.Name = "lookUpEdit销售订单号2";
            this.lookUpEdit销售订单号2.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.lookUpEdit销售订单号2.Properties.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("cSoCode", "销售订单号")});
            this.lookUpEdit销售订单号2.Properties.DisplayMember = "cSoCode";
            this.lookUpEdit销售订单号2.Properties.NullText = "";
            this.lookUpEdit销售订单号2.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.Standard;
            this.lookUpEdit销售订单号2.Properties.ValueMember = "cSoCode";
            this.lookUpEdit销售订单号2.Size = new System.Drawing.Size(176, 21);
            this.lookUpEdit销售订单号2.StyleController = this.layoutControl1;
            this.lookUpEdit销售订单号2.TabIndex = 5;
            // 
            // lookUpEdit销售订单号1
            // 
            this.lookUpEdit销售订单号1.Location = new System.Drawing.Point(76, 12);
            this.lookUpEdit销售订单号1.Name = "lookUpEdit销售订单号1";
            this.lookUpEdit销售订单号1.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.lookUpEdit销售订单号1.Properties.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("cSoCode", "销售订单号")});
            this.lookUpEdit销售订单号1.Properties.DisplayMember = "cSoCode";
            this.lookUpEdit销售订单号1.Properties.NullText = "";
            this.lookUpEdit销售订单号1.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.Standard;
            this.lookUpEdit销售订单号1.Properties.ValueMember = "cSoCode";
            this.lookUpEdit销售订单号1.Size = new System.Drawing.Size(164, 21);
            this.lookUpEdit销售订单号1.StyleController = this.layoutControl1;
            this.lookUpEdit销售订单号1.TabIndex = 4;
            // 
            // layoutControlGroup1
            // 
            this.layoutControlGroup1.CustomizationFormText = "layoutControlGroup1";
            this.layoutControlGroup1.EnableIndentsWithoutBorders = DevExpress.Utils.DefaultBoolean.True;
            this.layoutControlGroup1.GroupBordersVisible = false;
            this.layoutControlGroup1.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.layoutControlItem12,
            this.layoutControlItem1,
            this.layoutControlItem2,
            this.emptySpaceItem3,
            this.layoutControlItem6,
            this.layoutControlItem5,
            this.layoutControlItem3});
            this.layoutControlGroup1.Location = new System.Drawing.Point(0, 0);
            this.layoutControlGroup1.Name = "Root";
            this.layoutControlGroup1.Size = new System.Drawing.Size(900, 376);
            this.layoutControlGroup1.Text = "Root";
            this.layoutControlGroup1.TextVisible = false;
            // 
            // layoutControlItem12
            // 
            this.layoutControlItem12.Control = this.gridControl1;
            this.layoutControlItem12.CustomizationFormText = "layoutControlItem12";
            this.layoutControlItem12.Location = new System.Drawing.Point(0, 49);
            this.layoutControlItem12.Name = "layoutControlItem12";
            this.layoutControlItem12.Size = new System.Drawing.Size(880, 307);
            this.layoutControlItem12.Text = "查询列表";
            this.layoutControlItem12.TextLocation = DevExpress.Utils.Locations.Top;
            this.layoutControlItem12.TextSize = new System.Drawing.Size(60, 14);
            // 
            // layoutControlItem1
            // 
            this.layoutControlItem1.Control = this.lookUpEdit销售订单号1;
            this.layoutControlItem1.CustomizationFormText = "销售订单号";
            this.layoutControlItem1.Location = new System.Drawing.Point(0, 0);
            this.layoutControlItem1.Name = "layoutControlItem1";
            this.layoutControlItem1.Size = new System.Drawing.Size(232, 25);
            this.layoutControlItem1.Text = "销售订单号";
            this.layoutControlItem1.TextSize = new System.Drawing.Size(60, 14);
            // 
            // layoutControlItem2
            // 
            this.layoutControlItem2.Control = this.lookUpEdit销售订单号2;
            this.layoutControlItem2.CustomizationFormText = "至";
            this.layoutControlItem2.Location = new System.Drawing.Point(232, 0);
            this.layoutControlItem2.Name = "layoutControlItem2";
            this.layoutControlItem2.Size = new System.Drawing.Size(180, 25);
            this.layoutControlItem2.Text = "至";
            this.layoutControlItem2.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem2.TextToControlDistance = 0;
            this.layoutControlItem2.TextVisible = false;
            // 
            // emptySpaceItem3
            // 
            this.emptySpaceItem3.AllowHotTrack = false;
            this.emptySpaceItem3.CustomizationFormText = "emptySpaceItem3";
            this.emptySpaceItem3.Location = new System.Drawing.Point(848, 0);
            this.emptySpaceItem3.Name = "emptySpaceItem3";
            this.emptySpaceItem3.Size = new System.Drawing.Size(32, 25);
            this.emptySpaceItem3.Text = "emptySpaceItem3";
            this.emptySpaceItem3.TextSize = new System.Drawing.Size(0, 0);
            // 
            // layoutControlItem6
            // 
            this.layoutControlItem6.Control = this.dtm单据日期1;
            this.layoutControlItem6.CustomizationFormText = "单据日期";
            this.layoutControlItem6.Location = new System.Drawing.Point(412, 0);
            this.layoutControlItem6.Name = "layoutControlItem6";
            this.layoutControlItem6.Size = new System.Drawing.Size(233, 25);
            this.layoutControlItem6.Text = "单据日期";
            this.layoutControlItem6.TextSize = new System.Drawing.Size(60, 14);
            // 
            // layoutControlItem5
            // 
            this.layoutControlItem5.Control = this.dtm单据日期2;
            this.layoutControlItem5.CustomizationFormText = "至";
            this.layoutControlItem5.Location = new System.Drawing.Point(645, 0);
            this.layoutControlItem5.Name = "layoutControlItem5";
            this.layoutControlItem5.Size = new System.Drawing.Size(203, 25);
            this.layoutControlItem5.Text = "至";
            this.layoutControlItem5.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem5.TextToControlDistance = 0;
            this.layoutControlItem5.TextVisible = false;
            // 
            // layoutControlItem3
            // 
            this.layoutControlItem3.Control = this.chkAll;
            this.layoutControlItem3.CustomizationFormText = "layoutControlItem3";
            this.layoutControlItem3.Location = new System.Drawing.Point(0, 25);
            this.layoutControlItem3.Name = "layoutControlItem3";
            this.layoutControlItem3.Size = new System.Drawing.Size(880, 24);
            this.layoutControlItem3.Text = "layoutControlItem3";
            this.layoutControlItem3.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem3.TextToControlDistance = 0;
            this.layoutControlItem3.TextVisible = false;
            // 
            // btnOK
            // 
            this.btnOK.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnOK.Location = new System.Drawing.Point(717, 397);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(75, 23);
            this.btnOK.TabIndex = 1;
            this.btnOK.Text = "确 定";
            this.btnOK.UseVisualStyleBackColor = true;
            this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCancel.Location = new System.Drawing.Point(828, 397);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 23);
            this.btnCancel.TabIndex = 2;
            this.btnCancel.Text = "取 消";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // btnSEL
            // 
            this.btnSEL.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSEL.Location = new System.Drawing.Point(615, 398);
            this.btnSEL.Name = "btnSEL";
            this.btnSEL.Size = new System.Drawing.Size(62, 23);
            this.btnSEL.TabIndex = 3;
            this.btnSEL.Text = "查 询";
            this.btnSEL.UseVisualStyleBackColor = true;
            this.btnSEL.Click += new System.EventHandler(this.btnSEL_Click);
            // 
            // Frm订单评审_Add
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(921, 445);
            this.Controls.Add(this.btnSEL);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnOK);
            this.Controls.Add(this.layoutControl1);
            this.Name = "Frm订单评审_Add";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "查询";
            this.Load += new System.EventHandler(this.Frm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.layoutControl1)).EndInit();
            this.layoutControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dtm单据日期1.Properties.VistaTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtm单据日期1.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtm单据日期2.Properties.VistaTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtm单据日期2.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lookUpEdit销售订单号2.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lookUpEdit销售订单号1.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem12)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem6)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem5)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem3)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraLayout.LayoutControl layoutControl1;
        private DevExpress.XtraLayout.LayoutControlGroup layoutControlGroup1;
        private DevExpress.XtraEditors.DateEdit dtm单据日期1;
        private DevExpress.XtraEditors.DateEdit dtm单据日期2;
        private DevExpress.XtraEditors.LookUpEdit lookUpEdit销售订单号2;
        private DevExpress.XtraEditors.LookUpEdit lookUpEdit销售订单号1;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem2;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem1;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem5;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem6;
        private System.Windows.Forms.Button btnOK;
        private System.Windows.Forms.Button btnCancel;
        private DevExpress.XtraGrid.GridControl gridControl1;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView1;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem12;
        private System.Windows.Forms.Button btnSEL;
        private DevExpress.XtraGrid.Columns.GridColumn gridCol销售订单号;
        private DevExpress.XtraGrid.Columns.GridColumn gridCol客户编码;
        private DevExpress.XtraLayout.EmptySpaceItem emptySpaceItem3;
        private DevExpress.XtraGrid.Columns.GridColumn gridCol客户简称;
        private DevExpress.XtraGrid.Columns.GridColumn gridCol单据日期;
        private DevExpress.XtraGrid.Columns.GridColumn gridCol存货编码;
        private DevExpress.XtraGrid.Columns.GridColumn gridCol存货名称;
        private DevExpress.XtraGrid.Columns.GridColumn gridCol规格型号;
        private DevExpress.XtraGrid.Columns.GridColumn gridCol订单数量;
        private DevExpress.XtraGrid.Columns.GridColumn gridCol交货日期;
        private DevExpress.XtraGrid.Columns.GridColumn gridColChoose;
        private DevExpress.XtraGrid.Columns.GridColumn gridCol销售订单子表ID;
        private DevExpress.XtraGrid.Columns.GridColumn gridCol已评审数量;
        private DevExpress.XtraGrid.Columns.GridColumn gridCol待评审数量;
        private DevExpress.XtraGrid.Columns.GridColumn gridCol行号;
        private System.Windows.Forms.CheckBox chkAll;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem3;
    }
}