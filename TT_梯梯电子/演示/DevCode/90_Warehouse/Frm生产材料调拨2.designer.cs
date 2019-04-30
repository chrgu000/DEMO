namespace Warehouse
{
    partial class Frm生产材料调拨2
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
            this.radio订单子件有现存量 = new System.Windows.Forms.RadioButton();
            this.label1 = new System.Windows.Forms.Label();
            this.radio全部 = new System.Windows.Forms.RadioButton();
            this.chk全选 = new System.Windows.Forms.CheckBox();
            this.dtm单据日期1 = new DevExpress.XtraEditors.DateEdit();
            this.gridControl1 = new DevExpress.XtraGrid.GridControl();
            this.gridView1 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.gridColiChk = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridCol生产计划订单号 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridCol物料编码 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridCol计划数量 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridCol生产订单号 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridCol生产订单行号 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridCol生产订单状态 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridCol生产订单母件编码 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridCol生产订单数量 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridCol子件编码 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridCol子件数量 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridCol子件待调拨数量 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridCol调出仓库 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.ItemLookUpEdit仓库 = new DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit();
            this.gridCol调入仓库 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridCol仓库可用量 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridCol本次调拨 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridCol物料名称 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridCol物料规格 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridCol子件名称 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridCol子件规格 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridCol累计下单 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridCol调出部门 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.ItemLookUpEdit部门 = new DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit();
            this.gridCol调入部门 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridCol出库类别 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.ItemLookUpEdit收发类别 = new DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit();
            this.gridCol入库类别 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridCol生产订单子件ID = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridCol项目编码 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridCol子件应领数量 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridCol子件应领辅计量 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridCol子件辅助计量 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridCol子件换算率 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridCol仓库现存量 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridCol调拨未审核待出库 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridCol计划日期 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.ItemTextEdit1 = new DevExpress.XtraEditors.Repository.RepositoryItemTextEdit();
            this.gridCol条形码 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridCol子件用料ID = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColbUsed = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridCol发料类型 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.label2 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dsPrint)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dsForm)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtSel)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtm单据日期1.Properties.VistaTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtm单据日期1.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ItemLookUpEdit仓库)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ItemLookUpEdit部门)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ItemLookUpEdit收发类别)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ItemTextEdit1)).BeginInit();
            this.SuspendLayout();
            // 
            // radio订单子件有现存量
            // 
            this.radio订单子件有现存量.Checked = true;
            this.radio订单子件有现存量.Location = new System.Drawing.Point(376, 58);
            this.radio订单子件有现存量.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.radio订单子件有现存量.Name = "radio订单子件有现存量";
            this.radio订单子件有现存量.Size = new System.Drawing.Size(153, 32);
            this.radio订单子件有现存量.TabIndex = 20;
            this.radio订单子件有现存量.TabStop = true;
            this.radio订单子件有现存量.Text = "订单子件有现存量";
            this.radio订单子件有现存量.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(805, 58);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(154, 32);
            this.label1.TabIndex = 22;
            this.label1.Text = "20161101 0920";
            // 
            // radio全部
            // 
            this.radio全部.Location = new System.Drawing.Point(301, 58);
            this.radio全部.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.radio全部.Name = "radio全部";
            this.radio全部.Size = new System.Drawing.Size(69, 32);
            this.radio全部.TabIndex = 19;
            this.radio全部.TabStop = true;
            this.radio全部.Text = "全部";
            this.radio全部.UseVisualStyleBackColor = true;
            // 
            // chk全选
            // 
            this.chk全选.Location = new System.Drawing.Point(37, 94);
            this.chk全选.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.chk全选.Name = "chk全选";
            this.chk全选.Size = new System.Drawing.Size(65, 26);
            this.chk全选.TabIndex = 21;
            this.chk全选.Text = "全选";
            this.chk全选.UseVisualStyleBackColor = true;
            this.chk全选.CheckedChanged += new System.EventHandler(this.chk全选_CheckedChanged);
            // 
            // dtm单据日期1
            // 
            this.dtm单据日期1.EditValue = null;
            this.dtm单据日期1.Location = new System.Drawing.Point(138, 62);
            this.dtm单据日期1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.dtm单据日期1.Name = "dtm单据日期1";
            this.dtm单据日期1.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.dtm单据日期1.Properties.VistaTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
            this.dtm单据日期1.Size = new System.Drawing.Size(120, 24);
            this.dtm单据日期1.TabIndex = 18;
            // 
            // gridControl1
            // 
            this.gridControl1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.gridControl1.Location = new System.Drawing.Point(17, 129);
            this.gridControl1.MainView = this.gridView1;
            this.gridControl1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.gridControl1.Name = "gridControl1";
            this.gridControl1.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.ItemLookUpEdit仓库,
            this.ItemLookUpEdit部门,
            this.ItemLookUpEdit收发类别,
            this.ItemTextEdit1});
            this.gridControl1.Size = new System.Drawing.Size(1019, 384);
            this.gridControl1.TabIndex = 17;
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
            this.gridColiChk,
            this.gridCol生产计划订单号,
            this.gridCol物料编码,
            this.gridCol计划数量,
            this.gridCol生产订单号,
            this.gridCol生产订单行号,
            this.gridCol生产订单状态,
            this.gridCol生产订单母件编码,
            this.gridCol生产订单数量,
            this.gridCol子件编码,
            this.gridCol子件数量,
            this.gridCol子件待调拨数量,
            this.gridCol调出仓库,
            this.gridCol调入仓库,
            this.gridCol仓库可用量,
            this.gridCol本次调拨,
            this.gridCol物料名称,
            this.gridCol物料规格,
            this.gridCol子件名称,
            this.gridCol子件规格,
            this.gridCol累计下单,
            this.gridCol调出部门,
            this.gridCol调入部门,
            this.gridCol出库类别,
            this.gridCol入库类别,
            this.gridCol生产订单子件ID,
            this.gridCol项目编码,
            this.gridCol子件应领数量,
            this.gridCol子件应领辅计量,
            this.gridCol子件辅助计量,
            this.gridCol子件换算率,
            this.gridCol仓库现存量,
            this.gridCol调拨未审核待出库,
            this.gridCol计划日期,
            this.gridCol条形码,
            this.gridCol子件用料ID,
            this.gridColbUsed,
            this.gridCol发料类型});
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
            this.gridView1.OptionsView.ShowGroupPanel = false;
            this.gridView1.CustomDrawRowIndicator += new DevExpress.XtraGrid.Views.Grid.RowIndicatorCustomDrawEventHandler(this.gridView1_CustomDrawRowIndicator);
            this.gridView1.CellValueChanged += new DevExpress.XtraGrid.Views.Base.CellValueChangedEventHandler(this.gridView1_CellValueChanged);
            this.gridView1.DoubleClick += new System.EventHandler(this.gridView1_DoubleClick);
            // 
            // gridColiChk
            // 
            this.gridColiChk.Caption = "选择";
            this.gridColiChk.FieldName = "iChk";
            this.gridColiChk.Fixed = DevExpress.XtraGrid.Columns.FixedStyle.Left;
            this.gridColiChk.Name = "gridColiChk";
            this.gridColiChk.OptionsColumn.AllowSort = DevExpress.Utils.DefaultBoolean.False;
            this.gridColiChk.Visible = true;
            this.gridColiChk.VisibleIndex = 0;
            this.gridColiChk.Width = 33;
            // 
            // gridCol生产计划订单号
            // 
            this.gridCol生产计划订单号.Caption = "生产订单(计划)";
            this.gridCol生产计划订单号.FieldName = "生产订单号";
            this.gridCol生产计划订单号.Name = "gridCol生产计划订单号";
            this.gridCol生产计划订单号.OptionsColumn.AllowEdit = false;
            this.gridCol生产计划订单号.OptionsColumn.AllowSort = DevExpress.Utils.DefaultBoolean.True;
            this.gridCol生产计划订单号.Width = 105;
            // 
            // gridCol物料编码
            // 
            this.gridCol物料编码.Caption = "物料编码";
            this.gridCol物料编码.FieldName = "物料编码";
            this.gridCol物料编码.Name = "gridCol物料编码";
            this.gridCol物料编码.OptionsColumn.AllowEdit = false;
            this.gridCol物料编码.OptionsColumn.AllowSort = DevExpress.Utils.DefaultBoolean.True;
            this.gridCol物料编码.Visible = true;
            this.gridCol物料编码.VisibleIndex = 5;
            this.gridCol物料编码.Width = 122;
            // 
            // gridCol计划数量
            // 
            this.gridCol计划数量.Caption = "计划数量";
            this.gridCol计划数量.FieldName = "计划数量";
            this.gridCol计划数量.Name = "gridCol计划数量";
            this.gridCol计划数量.OptionsColumn.AllowEdit = false;
            this.gridCol计划数量.OptionsColumn.AllowSort = DevExpress.Utils.DefaultBoolean.True;
            // 
            // gridCol生产订单号
            // 
            this.gridCol生产订单号.Caption = "生产订单号";
            this.gridCol生产订单号.FieldName = "生产订单号";
            this.gridCol生产订单号.Fixed = DevExpress.XtraGrid.Columns.FixedStyle.Left;
            this.gridCol生产订单号.Name = "gridCol生产订单号";
            this.gridCol生产订单号.OptionsColumn.AllowEdit = false;
            this.gridCol生产订单号.OptionsColumn.AllowSort = DevExpress.Utils.DefaultBoolean.True;
            this.gridCol生产订单号.Visible = true;
            this.gridCol生产订单号.VisibleIndex = 1;
            // 
            // gridCol生产订单行号
            // 
            this.gridCol生产订单行号.Caption = "行号";
            this.gridCol生产订单行号.FieldName = "行号";
            this.gridCol生产订单行号.Fixed = DevExpress.XtraGrid.Columns.FixedStyle.Left;
            this.gridCol生产订单行号.Name = "gridCol生产订单行号";
            this.gridCol生产订单行号.OptionsColumn.AllowEdit = false;
            this.gridCol生产订单行号.OptionsColumn.AllowSort = DevExpress.Utils.DefaultBoolean.True;
            this.gridCol生产订单行号.Visible = true;
            this.gridCol生产订单行号.VisibleIndex = 2;
            this.gridCol生产订单行号.Width = 32;
            // 
            // gridCol生产订单状态
            // 
            this.gridCol生产订单状态.Caption = "生产订单状态";
            this.gridCol生产订单状态.FieldName = "Status";
            this.gridCol生产订单状态.Name = "gridCol生产订单状态";
            this.gridCol生产订单状态.OptionsColumn.AllowEdit = false;
            this.gridCol生产订单状态.OptionsColumn.AllowSort = DevExpress.Utils.DefaultBoolean.True;
            this.gridCol生产订单状态.Width = 102;
            // 
            // gridCol生产订单母件编码
            // 
            this.gridCol生产订单母件编码.Caption = "生产订单母件编码";
            this.gridCol生产订单母件编码.FieldName = "生产订单母件编码";
            this.gridCol生产订单母件编码.Name = "gridCol生产订单母件编码";
            this.gridCol生产订单母件编码.OptionsColumn.AllowEdit = false;
            this.gridCol生产订单母件编码.OptionsColumn.AllowSort = DevExpress.Utils.DefaultBoolean.True;
            this.gridCol生产订单母件编码.Width = 128;
            // 
            // gridCol生产订单数量
            // 
            this.gridCol生产订单数量.Caption = "生产订单数量";
            this.gridCol生产订单数量.FieldName = "生产订单数量";
            this.gridCol生产订单数量.Name = "gridCol生产订单数量";
            this.gridCol生产订单数量.OptionsColumn.AllowEdit = false;
            this.gridCol生产订单数量.OptionsColumn.AllowSort = DevExpress.Utils.DefaultBoolean.True;
            this.gridCol生产订单数量.Visible = true;
            this.gridCol生产订单数量.VisibleIndex = 8;
            this.gridCol生产订单数量.Width = 84;
            // 
            // gridCol子件编码
            // 
            this.gridCol子件编码.Caption = "子件编码";
            this.gridCol子件编码.FieldName = "子件编码";
            this.gridCol子件编码.Name = "gridCol子件编码";
            this.gridCol子件编码.OptionsColumn.AllowEdit = false;
            this.gridCol子件编码.OptionsColumn.AllowSort = DevExpress.Utils.DefaultBoolean.True;
            this.gridCol子件编码.Visible = true;
            this.gridCol子件编码.VisibleIndex = 9;
            this.gridCol子件编码.Width = 93;
            // 
            // gridCol子件数量
            // 
            this.gridCol子件数量.Caption = "子件数量";
            this.gridCol子件数量.FieldName = "子件数量";
            this.gridCol子件数量.Name = "gridCol子件数量";
            this.gridCol子件数量.OptionsColumn.AllowEdit = false;
            this.gridCol子件数量.OptionsColumn.AllowSort = DevExpress.Utils.DefaultBoolean.True;
            this.gridCol子件数量.Visible = true;
            this.gridCol子件数量.VisibleIndex = 12;
            // 
            // gridCol子件待调拨数量
            // 
            this.gridCol子件待调拨数量.Caption = "子件待调拨数量";
            this.gridCol子件待调拨数量.FieldName = "子件待调拨数量";
            this.gridCol子件待调拨数量.Name = "gridCol子件待调拨数量";
            this.gridCol子件待调拨数量.OptionsColumn.AllowEdit = false;
            this.gridCol子件待调拨数量.OptionsColumn.AllowSort = DevExpress.Utils.DefaultBoolean.True;
            this.gridCol子件待调拨数量.Visible = true;
            this.gridCol子件待调拨数量.VisibleIndex = 13;
            this.gridCol子件待调拨数量.Width = 94;
            // 
            // gridCol调出仓库
            // 
            this.gridCol调出仓库.Caption = "调出仓库";
            this.gridCol调出仓库.ColumnEdit = this.ItemLookUpEdit仓库;
            this.gridCol调出仓库.FieldName = "调出仓库";
            this.gridCol调出仓库.Name = "gridCol调出仓库";
            this.gridCol调出仓库.OptionsColumn.AllowSort = DevExpress.Utils.DefaultBoolean.True;
            this.gridCol调出仓库.Visible = true;
            this.gridCol调出仓库.VisibleIndex = 19;
            // 
            // ItemLookUpEdit仓库
            // 
            this.ItemLookUpEdit仓库.AutoHeight = false;
            this.ItemLookUpEdit仓库.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.ItemLookUpEdit仓库.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("cWhCode", "编码"),
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("cWhName", "名称")});
            this.ItemLookUpEdit仓库.DisplayMember = "cWhName";
            this.ItemLookUpEdit仓库.Name = "ItemLookUpEdit仓库";
            this.ItemLookUpEdit仓库.ValueMember = "cWhCode";
            // 
            // gridCol调入仓库
            // 
            this.gridCol调入仓库.Caption = "调入仓库";
            this.gridCol调入仓库.ColumnEdit = this.ItemLookUpEdit仓库;
            this.gridCol调入仓库.FieldName = "调入仓库";
            this.gridCol调入仓库.Name = "gridCol调入仓库";
            this.gridCol调入仓库.OptionsColumn.AllowSort = DevExpress.Utils.DefaultBoolean.True;
            this.gridCol调入仓库.Visible = true;
            this.gridCol调入仓库.VisibleIndex = 20;
            // 
            // gridCol仓库可用量
            // 
            this.gridCol仓库可用量.Caption = "仓库可用量";
            this.gridCol仓库可用量.FieldName = "仓库可用量";
            this.gridCol仓库可用量.Name = "gridCol仓库可用量";
            this.gridCol仓库可用量.OptionsColumn.AllowEdit = false;
            this.gridCol仓库可用量.OptionsColumn.AllowSort = DevExpress.Utils.DefaultBoolean.True;
            this.gridCol仓库可用量.Visible = true;
            this.gridCol仓库可用量.VisibleIndex = 15;
            // 
            // gridCol本次调拨
            // 
            this.gridCol本次调拨.AppearanceHeader.ForeColor = System.Drawing.Color.Blue;
            this.gridCol本次调拨.AppearanceHeader.Options.UseForeColor = true;
            this.gridCol本次调拨.Caption = "本次调拨";
            this.gridCol本次调拨.FieldName = "本次调拨";
            this.gridCol本次调拨.Name = "gridCol本次调拨";
            this.gridCol本次调拨.OptionsColumn.AllowSort = DevExpress.Utils.DefaultBoolean.True;
            this.gridCol本次调拨.Visible = true;
            this.gridCol本次调拨.VisibleIndex = 14;
            // 
            // gridCol物料名称
            // 
            this.gridCol物料名称.Caption = "物料名称";
            this.gridCol物料名称.FieldName = "物料名称";
            this.gridCol物料名称.Name = "gridCol物料名称";
            this.gridCol物料名称.OptionsColumn.AllowEdit = false;
            this.gridCol物料名称.OptionsColumn.AllowSort = DevExpress.Utils.DefaultBoolean.True;
            this.gridCol物料名称.Visible = true;
            this.gridCol物料名称.VisibleIndex = 6;
            // 
            // gridCol物料规格
            // 
            this.gridCol物料规格.Caption = "物料规格";
            this.gridCol物料规格.FieldName = "物料规格";
            this.gridCol物料规格.Name = "gridCol物料规格";
            this.gridCol物料规格.OptionsColumn.AllowEdit = false;
            this.gridCol物料规格.OptionsColumn.AllowSort = DevExpress.Utils.DefaultBoolean.True;
            this.gridCol物料规格.Visible = true;
            this.gridCol物料规格.VisibleIndex = 7;
            // 
            // gridCol子件名称
            // 
            this.gridCol子件名称.Caption = "子件名称";
            this.gridCol子件名称.FieldName = "子件名称";
            this.gridCol子件名称.Name = "gridCol子件名称";
            this.gridCol子件名称.OptionsColumn.AllowEdit = false;
            this.gridCol子件名称.OptionsColumn.AllowSort = DevExpress.Utils.DefaultBoolean.True;
            this.gridCol子件名称.Visible = true;
            this.gridCol子件名称.VisibleIndex = 10;
            // 
            // gridCol子件规格
            // 
            this.gridCol子件规格.Caption = "子件规格";
            this.gridCol子件规格.FieldName = "子件规格";
            this.gridCol子件规格.Name = "gridCol子件规格";
            this.gridCol子件规格.OptionsColumn.AllowEdit = false;
            this.gridCol子件规格.OptionsColumn.AllowSort = DevExpress.Utils.DefaultBoolean.True;
            this.gridCol子件规格.Visible = true;
            this.gridCol子件规格.VisibleIndex = 11;
            // 
            // gridCol累计下单
            // 
            this.gridCol累计下单.Caption = "累计下单";
            this.gridCol累计下单.FieldName = "累计下单";
            this.gridCol累计下单.Name = "gridCol累计下单";
            this.gridCol累计下单.OptionsColumn.AllowEdit = false;
            this.gridCol累计下单.OptionsColumn.AllowSort = DevExpress.Utils.DefaultBoolean.True;
            this.gridCol累计下单.Visible = true;
            this.gridCol累计下单.VisibleIndex = 16;
            // 
            // gridCol调出部门
            // 
            this.gridCol调出部门.Caption = "调出部门";
            this.gridCol调出部门.ColumnEdit = this.ItemLookUpEdit部门;
            this.gridCol调出部门.FieldName = "调出部门";
            this.gridCol调出部门.Name = "gridCol调出部门";
            this.gridCol调出部门.OptionsColumn.AllowSort = DevExpress.Utils.DefaultBoolean.True;
            this.gridCol调出部门.Visible = true;
            this.gridCol调出部门.VisibleIndex = 21;
            // 
            // ItemLookUpEdit部门
            // 
            this.ItemLookUpEdit部门.AutoHeight = false;
            this.ItemLookUpEdit部门.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.ItemLookUpEdit部门.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("cDepCode", "部门编号"),
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("cDepName", "部门名称")});
            this.ItemLookUpEdit部门.DisplayMember = "cDepName";
            this.ItemLookUpEdit部门.Name = "ItemLookUpEdit部门";
            this.ItemLookUpEdit部门.ValueMember = "cDepCode";
            // 
            // gridCol调入部门
            // 
            this.gridCol调入部门.Caption = "调入部门";
            this.gridCol调入部门.ColumnEdit = this.ItemLookUpEdit部门;
            this.gridCol调入部门.FieldName = "调入部门";
            this.gridCol调入部门.Fixed = DevExpress.XtraGrid.Columns.FixedStyle.Left;
            this.gridCol调入部门.Name = "gridCol调入部门";
            this.gridCol调入部门.OptionsColumn.AllowSort = DevExpress.Utils.DefaultBoolean.True;
            this.gridCol调入部门.Visible = true;
            this.gridCol调入部门.VisibleIndex = 3;
            this.gridCol调入部门.Width = 70;
            // 
            // gridCol出库类别
            // 
            this.gridCol出库类别.Caption = "出库类别";
            this.gridCol出库类别.ColumnEdit = this.ItemLookUpEdit收发类别;
            this.gridCol出库类别.FieldName = "出库类别";
            this.gridCol出库类别.Name = "gridCol出库类别";
            this.gridCol出库类别.OptionsColumn.AllowSort = DevExpress.Utils.DefaultBoolean.True;
            this.gridCol出库类别.Visible = true;
            this.gridCol出库类别.VisibleIndex = 22;
            // 
            // ItemLookUpEdit收发类别
            // 
            this.ItemLookUpEdit收发类别.AutoHeight = false;
            this.ItemLookUpEdit收发类别.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.ItemLookUpEdit收发类别.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("cRdCode", "编码"),
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("cRdName", "名称")});
            this.ItemLookUpEdit收发类别.DisplayMember = "cRdName";
            this.ItemLookUpEdit收发类别.Name = "ItemLookUpEdit收发类别";
            this.ItemLookUpEdit收发类别.ValueMember = "cRdCode";
            // 
            // gridCol入库类别
            // 
            this.gridCol入库类别.Caption = "入库类别";
            this.gridCol入库类别.ColumnEdit = this.ItemLookUpEdit收发类别;
            this.gridCol入库类别.FieldName = "入库类别";
            this.gridCol入库类别.Name = "gridCol入库类别";
            this.gridCol入库类别.OptionsColumn.AllowSort = DevExpress.Utils.DefaultBoolean.True;
            this.gridCol入库类别.Visible = true;
            this.gridCol入库类别.VisibleIndex = 23;
            // 
            // gridCol生产订单子件ID
            // 
            this.gridCol生产订单子件ID.Caption = "生产订单子件ID";
            this.gridCol生产订单子件ID.FieldName = "生产订单子件ID";
            this.gridCol生产订单子件ID.Name = "gridCol生产订单子件ID";
            this.gridCol生产订单子件ID.OptionsColumn.AllowEdit = false;
            this.gridCol生产订单子件ID.OptionsColumn.AllowSort = DevExpress.Utils.DefaultBoolean.True;
            this.gridCol生产订单子件ID.Visible = true;
            this.gridCol生产订单子件ID.VisibleIndex = 24;
            // 
            // gridCol项目编码
            // 
            this.gridCol项目编码.Caption = "销售订单号";
            this.gridCol项目编码.FieldName = "销售订单号";
            this.gridCol项目编码.Name = "gridCol项目编码";
            this.gridCol项目编码.OptionsColumn.AllowEdit = false;
            this.gridCol项目编码.OptionsColumn.AllowSort = DevExpress.Utils.DefaultBoolean.True;
            this.gridCol项目编码.Visible = true;
            this.gridCol项目编码.VisibleIndex = 25;
            // 
            // gridCol子件应领数量
            // 
            this.gridCol子件应领数量.Caption = "子件应领数量";
            this.gridCol子件应领数量.FieldName = "子件应领数量";
            this.gridCol子件应领数量.Name = "gridCol子件应领数量";
            this.gridCol子件应领数量.OptionsColumn.AllowEdit = false;
            this.gridCol子件应领数量.OptionsColumn.AllowSort = DevExpress.Utils.DefaultBoolean.True;
            this.gridCol子件应领数量.Visible = true;
            this.gridCol子件应领数量.VisibleIndex = 26;
            // 
            // gridCol子件应领辅计量
            // 
            this.gridCol子件应领辅计量.Caption = "子件应领辅计量";
            this.gridCol子件应领辅计量.FieldName = "子件应领辅计量";
            this.gridCol子件应领辅计量.Name = "gridCol子件应领辅计量";
            this.gridCol子件应领辅计量.OptionsColumn.AllowEdit = false;
            this.gridCol子件应领辅计量.OptionsColumn.AllowSort = DevExpress.Utils.DefaultBoolean.True;
            this.gridCol子件应领辅计量.Visible = true;
            this.gridCol子件应领辅计量.VisibleIndex = 27;
            // 
            // gridCol子件辅助计量
            // 
            this.gridCol子件辅助计量.Caption = "子件辅助计量";
            this.gridCol子件辅助计量.FieldName = "子件计量单位";
            this.gridCol子件辅助计量.Name = "gridCol子件辅助计量";
            this.gridCol子件辅助计量.OptionsColumn.AllowEdit = false;
            this.gridCol子件辅助计量.OptionsColumn.AllowSort = DevExpress.Utils.DefaultBoolean.True;
            this.gridCol子件辅助计量.Visible = true;
            this.gridCol子件辅助计量.VisibleIndex = 28;
            // 
            // gridCol子件换算率
            // 
            this.gridCol子件换算率.Caption = "子件换算率";
            this.gridCol子件换算率.FieldName = "子件换算率";
            this.gridCol子件换算率.Name = "gridCol子件换算率";
            this.gridCol子件换算率.OptionsColumn.AllowEdit = false;
            this.gridCol子件换算率.OptionsColumn.AllowSort = DevExpress.Utils.DefaultBoolean.True;
            this.gridCol子件换算率.Visible = true;
            this.gridCol子件换算率.VisibleIndex = 29;
            // 
            // gridCol仓库现存量
            // 
            this.gridCol仓库现存量.Caption = "仓库现存量";
            this.gridCol仓库现存量.FieldName = "仓库现存量";
            this.gridCol仓库现存量.Name = "gridCol仓库现存量";
            this.gridCol仓库现存量.OptionsColumn.AllowEdit = false;
            this.gridCol仓库现存量.OptionsColumn.AllowSort = DevExpress.Utils.DefaultBoolean.True;
            this.gridCol仓库现存量.Visible = true;
            this.gridCol仓库现存量.VisibleIndex = 17;
            // 
            // gridCol调拨未审核待出库
            // 
            this.gridCol调拨未审核待出库.Caption = "调拨未审核待出库";
            this.gridCol调拨未审核待出库.FieldName = "调拨未审核待出库";
            this.gridCol调拨未审核待出库.Name = "gridCol调拨未审核待出库";
            this.gridCol调拨未审核待出库.OptionsColumn.AllowEdit = false;
            this.gridCol调拨未审核待出库.OptionsColumn.AllowSort = DevExpress.Utils.DefaultBoolean.True;
            this.gridCol调拨未审核待出库.Visible = true;
            this.gridCol调拨未审核待出库.VisibleIndex = 18;
            this.gridCol调拨未审核待出库.Width = 107;
            // 
            // gridCol计划日期
            // 
            this.gridCol计划日期.Caption = "计划日期";
            this.gridCol计划日期.ColumnEdit = this.ItemTextEdit1;
            this.gridCol计划日期.FieldName = "计划日期";
            this.gridCol计划日期.Fixed = DevExpress.XtraGrid.Columns.FixedStyle.Left;
            this.gridCol计划日期.Name = "gridCol计划日期";
            this.gridCol计划日期.OptionsColumn.AllowEdit = false;
            this.gridCol计划日期.OptionsColumn.AllowSort = DevExpress.Utils.DefaultBoolean.True;
            this.gridCol计划日期.Visible = true;
            this.gridCol计划日期.VisibleIndex = 4;
            this.gridCol计划日期.Width = 63;
            // 
            // ItemTextEdit1
            // 
            this.ItemTextEdit1.AutoHeight = false;
            this.ItemTextEdit1.Name = "ItemTextEdit1";
            // 
            // gridCol条形码
            // 
            this.gridCol条形码.Caption = "条形码";
            this.gridCol条形码.FieldName = "条形码";
            this.gridCol条形码.Name = "gridCol条形码";
            this.gridCol条形码.OptionsColumn.AllowEdit = false;
            this.gridCol条形码.OptionsColumn.AllowSort = DevExpress.Utils.DefaultBoolean.True;
            this.gridCol条形码.Visible = true;
            this.gridCol条形码.VisibleIndex = 31;
            // 
            // gridCol子件用料ID
            // 
            this.gridCol子件用料ID.Caption = "子件用料ID";
            this.gridCol子件用料ID.FieldName = "子件用料ID";
            this.gridCol子件用料ID.Name = "gridCol子件用料ID";
            this.gridCol子件用料ID.OptionsColumn.AllowEdit = false;
            this.gridCol子件用料ID.OptionsColumn.AllowSort = DevExpress.Utils.DefaultBoolean.True;
            this.gridCol子件用料ID.Visible = true;
            this.gridCol子件用料ID.VisibleIndex = 30;
            // 
            // gridColbUsed
            // 
            this.gridColbUsed.Caption = "bUsed";
            this.gridColbUsed.FieldName = "bUsed";
            this.gridColbUsed.Name = "gridColbUsed";
            this.gridColbUsed.OptionsColumn.AllowEdit = false;
            this.gridColbUsed.OptionsColumn.AllowSort = DevExpress.Utils.DefaultBoolean.True;
            this.gridColbUsed.Visible = true;
            this.gridColbUsed.VisibleIndex = 32;
            // 
            // gridCol发料类型
            // 
            this.gridCol发料类型.Caption = "发料类型";
            this.gridCol发料类型.FieldName = "发料类型";
            this.gridCol发料类型.Name = "gridCol发料类型";
            this.gridCol发料类型.OptionsColumn.AllowEdit = false;
            this.gridCol发料类型.OptionsColumn.AllowSort = DevExpress.Utils.DefaultBoolean.True;
            this.gridCol发料类型.Visible = true;
            this.gridCol发料类型.VisibleIndex = 33;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(34, 65);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(98, 18);
            this.label2.TabIndex = 23;
            this.label2.Text = "生产计划日期";
            // 
            // Frm生产材料调拨2
            // 
            this.Appearance.BackColor = System.Drawing.SystemColors.Control;
            this.Appearance.Options.UseBackColor = true;
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 18F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1045, 521);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.radio订单子件有现存量);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.radio全部);
            this.Controls.Add(this.chk全选);
            this.Controls.Add(this.dtm单据日期1);
            this.Controls.Add(this.gridControl1);
            this.Margin = new System.Windows.Forms.Padding(3, 5, 3, 5);
            this.Name = "Frm生产材料调拨2";
            this.Text = "生产材料调拨";
            this.Load += new System.EventHandler(this.Frm生产材料调拨2_Load);
            this.Controls.SetChildIndex(this.gridControl1, 0);
            this.Controls.SetChildIndex(this.dtm单据日期1, 0);
            this.Controls.SetChildIndex(this.chk全选, 0);
            this.Controls.SetChildIndex(this.radio全部, 0);
            this.Controls.SetChildIndex(this.label1, 0);
            this.Controls.SetChildIndex(this.radio订单子件有现存量, 0);
            this.Controls.SetChildIndex(this.label2, 0);
            ((System.ComponentModel.ISupportInitialize)(this.dsPrint)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dsForm)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtSel)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtm单据日期1.Properties.VistaTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtm单据日期1.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ItemLookUpEdit仓库)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ItemLookUpEdit部门)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ItemLookUpEdit收发类别)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ItemTextEdit1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.RadioButton radio订单子件有现存量;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.RadioButton radio全部;
        private System.Windows.Forms.CheckBox chk全选;
        private DevExpress.XtraEditors.DateEdit dtm单据日期1;
        private DevExpress.XtraGrid.GridControl gridControl1;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView1;
        private DevExpress.XtraGrid.Columns.GridColumn gridColiChk;
        private DevExpress.XtraGrid.Columns.GridColumn gridCol生产计划订单号;
        private DevExpress.XtraGrid.Columns.GridColumn gridCol物料编码;
        private DevExpress.XtraGrid.Columns.GridColumn gridCol计划数量;
        private DevExpress.XtraGrid.Columns.GridColumn gridCol生产订单号;
        private DevExpress.XtraGrid.Columns.GridColumn gridCol生产订单行号;
        private DevExpress.XtraGrid.Columns.GridColumn gridCol生产订单状态;
        private DevExpress.XtraGrid.Columns.GridColumn gridCol生产订单母件编码;
        private DevExpress.XtraGrid.Columns.GridColumn gridCol生产订单数量;
        private DevExpress.XtraGrid.Columns.GridColumn gridCol子件编码;
        private DevExpress.XtraGrid.Columns.GridColumn gridCol子件数量;
        private DevExpress.XtraGrid.Columns.GridColumn gridCol子件待调拨数量;
        private DevExpress.XtraGrid.Columns.GridColumn gridCol调出仓库;
        private DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit ItemLookUpEdit仓库;
        private DevExpress.XtraGrid.Columns.GridColumn gridCol调入仓库;
        private DevExpress.XtraGrid.Columns.GridColumn gridCol仓库可用量;
        private DevExpress.XtraGrid.Columns.GridColumn gridCol本次调拨;
        private DevExpress.XtraGrid.Columns.GridColumn gridCol物料名称;
        private DevExpress.XtraGrid.Columns.GridColumn gridCol物料规格;
        private DevExpress.XtraGrid.Columns.GridColumn gridCol子件名称;
        private DevExpress.XtraGrid.Columns.GridColumn gridCol子件规格;
        private DevExpress.XtraGrid.Columns.GridColumn gridCol累计下单;
        private DevExpress.XtraGrid.Columns.GridColumn gridCol调出部门;
        private DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit ItemLookUpEdit部门;
        private DevExpress.XtraGrid.Columns.GridColumn gridCol调入部门;
        private DevExpress.XtraGrid.Columns.GridColumn gridCol出库类别;
        private DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit ItemLookUpEdit收发类别;
        private DevExpress.XtraGrid.Columns.GridColumn gridCol入库类别;
        private DevExpress.XtraGrid.Columns.GridColumn gridCol生产订单子件ID;
        private DevExpress.XtraGrid.Columns.GridColumn gridCol项目编码;
        private DevExpress.XtraGrid.Columns.GridColumn gridCol子件应领数量;
        private DevExpress.XtraGrid.Columns.GridColumn gridCol子件应领辅计量;
        private DevExpress.XtraGrid.Columns.GridColumn gridCol子件辅助计量;
        private DevExpress.XtraGrid.Columns.GridColumn gridCol子件换算率;
        private DevExpress.XtraGrid.Columns.GridColumn gridCol仓库现存量;
        private DevExpress.XtraGrid.Columns.GridColumn gridCol调拨未审核待出库;
        private DevExpress.XtraGrid.Columns.GridColumn gridCol计划日期;
        private DevExpress.XtraEditors.Repository.RepositoryItemTextEdit ItemTextEdit1;
        private DevExpress.XtraGrid.Columns.GridColumn gridCol条形码;
        private DevExpress.XtraGrid.Columns.GridColumn gridCol子件用料ID;
        private DevExpress.XtraGrid.Columns.GridColumn gridColbUsed;
        private DevExpress.XtraGrid.Columns.GridColumn gridCol发料类型;
        private System.Windows.Forms.Label label2;

        //private DevExpress.XtraLayout.LayoutControlGroup layoutControlGroup1;
    }
}