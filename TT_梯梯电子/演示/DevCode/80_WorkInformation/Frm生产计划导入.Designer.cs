namespace WorkInformation
{
    partial class Frm生产计划导入
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
            this.gridControl1 = new DevExpress.XtraGrid.GridControl();
            this.gridView1 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.g生产订单ID = new DevExpress.XtraGrid.Columns.GridColumn();
            this.g外销订单 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.g产品编码 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.g物料编码 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.g半成品编码 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.g制造令号码 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.g生产订单行号 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.g产品名称 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.g产品规格 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.g班组 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.ItemLookUpEditDepartment = new DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit();
            this.g下一班组 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.g工序 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.g下道工序 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.g制造令数量 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.g计划数量 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.g计划日期 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.repositoryItemDateEdit1 = new DevExpress.XtraEditors.Repository.RepositoryItemDateEdit();
            this.g人员 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.g设备 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.g选择 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.g行号 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.g理论工时 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.g是否入库 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.g备注 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.g预计计划数量 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.g托外结束时间 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.btnCheck = new System.Windows.Forms.Button();
            this.btnSave = new System.Windows.Forms.Button();
            this.btnExport = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ItemLookUpEditDepartment)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemDateEdit1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemDateEdit1.VistaTimeProperties)).BeginInit();
            this.SuspendLayout();
            // 
            // gridControl1
            // 
            this.gridControl1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.gridControl1.EmbeddedNavigator.Margin = new System.Windows.Forms.Padding(4);
            this.gridControl1.Location = new System.Drawing.Point(8, 8);
            this.gridControl1.MainView = this.gridView1;
            this.gridControl1.Margin = new System.Windows.Forms.Padding(4);
            this.gridControl1.Name = "gridControl1";
            this.gridControl1.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.repositoryItemDateEdit1,
            this.ItemLookUpEditDepartment});
            this.gridControl1.Size = new System.Drawing.Size(1239, 520);
            this.gridControl1.TabIndex = 11;
            this.gridControl1.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView1});
            // 
            // gridView1
            // 
            this.gridView1.Appearance.ColumnFilterButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(202)))), ((int)(((byte)(221)))), ((int)(((byte)(208)))));
            this.gridView1.Appearance.ColumnFilterButton.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(202)))), ((int)(((byte)(221)))), ((int)(((byte)(208)))));
            this.gridView1.Appearance.ColumnFilterButton.ForeColor = System.Drawing.Color.Black;
            this.gridView1.Appearance.ColumnFilterButton.Options.UseBackColor = true;
            this.gridView1.Appearance.ColumnFilterButton.Options.UseBorderColor = true;
            this.gridView1.Appearance.ColumnFilterButton.Options.UseForeColor = true;
            this.gridView1.Appearance.ColumnFilterButtonActive.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(211)))), ((int)(((byte)(226)))), ((int)(((byte)(216)))));
            this.gridView1.Appearance.ColumnFilterButtonActive.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(211)))), ((int)(((byte)(226)))), ((int)(((byte)(216)))));
            this.gridView1.Appearance.ColumnFilterButtonActive.ForeColor = System.Drawing.Color.Black;
            this.gridView1.Appearance.ColumnFilterButtonActive.Options.UseBackColor = true;
            this.gridView1.Appearance.ColumnFilterButtonActive.Options.UseBorderColor = true;
            this.gridView1.Appearance.ColumnFilterButtonActive.Options.UseForeColor = true;
            this.gridView1.Appearance.Empty.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(242)))), ((int)(((byte)(244)))), ((int)(((byte)(236)))));
            this.gridView1.Appearance.Empty.BackColor2 = System.Drawing.Color.White;
            this.gridView1.Appearance.Empty.Options.UseBackColor = true;
            this.gridView1.Appearance.EvenRow.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(221)))), ((int)(((byte)(227)))), ((int)(((byte)(245)))));
            this.gridView1.Appearance.EvenRow.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(221)))), ((int)(((byte)(227)))), ((int)(((byte)(245)))));
            this.gridView1.Appearance.EvenRow.ForeColor = System.Drawing.Color.Black;
            this.gridView1.Appearance.EvenRow.Options.UseBackColor = true;
            this.gridView1.Appearance.EvenRow.Options.UseBorderColor = true;
            this.gridView1.Appearance.EvenRow.Options.UseForeColor = true;
            this.gridView1.Appearance.FilterCloseButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(202)))), ((int)(((byte)(221)))), ((int)(((byte)(208)))));
            this.gridView1.Appearance.FilterCloseButton.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(202)))), ((int)(((byte)(221)))), ((int)(((byte)(208)))));
            this.gridView1.Appearance.FilterCloseButton.ForeColor = System.Drawing.Color.Black;
            this.gridView1.Appearance.FilterCloseButton.Options.UseBackColor = true;
            this.gridView1.Appearance.FilterCloseButton.Options.UseBorderColor = true;
            this.gridView1.Appearance.FilterCloseButton.Options.UseForeColor = true;
            this.gridView1.Appearance.FilterPanel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(242)))), ((int)(((byte)(244)))), ((int)(((byte)(236)))));
            this.gridView1.Appearance.FilterPanel.BackColor2 = System.Drawing.Color.White;
            this.gridView1.Appearance.FilterPanel.ForeColor = System.Drawing.Color.Black;
            this.gridView1.Appearance.FilterPanel.Options.UseBackColor = true;
            this.gridView1.Appearance.FilterPanel.Options.UseForeColor = true;
            this.gridView1.Appearance.FixedLine.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(117)))), ((int)(((byte)(136)))), ((int)(((byte)(122)))));
            this.gridView1.Appearance.FixedLine.Options.UseBackColor = true;
            this.gridView1.Appearance.FocusedCell.BackColor = System.Drawing.Color.White;
            this.gridView1.Appearance.FocusedCell.ForeColor = System.Drawing.Color.Black;
            this.gridView1.Appearance.FocusedCell.Options.UseBackColor = true;
            this.gridView1.Appearance.FocusedCell.Options.UseForeColor = true;
            this.gridView1.Appearance.FocusedRow.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(129)))), ((int)(((byte)(171)))), ((int)(((byte)(177)))));
            this.gridView1.Appearance.FocusedRow.ForeColor = System.Drawing.Color.White;
            this.gridView1.Appearance.FocusedRow.Options.UseBackColor = true;
            this.gridView1.Appearance.FocusedRow.Options.UseForeColor = true;
            this.gridView1.Appearance.FooterPanel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(202)))), ((int)(((byte)(221)))), ((int)(((byte)(208)))));
            this.gridView1.Appearance.FooterPanel.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(202)))), ((int)(((byte)(221)))), ((int)(((byte)(208)))));
            this.gridView1.Appearance.FooterPanel.ForeColor = System.Drawing.Color.Black;
            this.gridView1.Appearance.FooterPanel.Options.UseBackColor = true;
            this.gridView1.Appearance.FooterPanel.Options.UseBorderColor = true;
            this.gridView1.Appearance.FooterPanel.Options.UseForeColor = true;
            this.gridView1.Appearance.GroupButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(178)))), ((int)(((byte)(209)))), ((int)(((byte)(188)))));
            this.gridView1.Appearance.GroupButton.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(178)))), ((int)(((byte)(209)))), ((int)(((byte)(188)))));
            this.gridView1.Appearance.GroupButton.Options.UseBackColor = true;
            this.gridView1.Appearance.GroupButton.Options.UseBorderColor = true;
            this.gridView1.Appearance.GroupFooter.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(215)))), ((int)(((byte)(234)))), ((int)(((byte)(221)))));
            this.gridView1.Appearance.GroupFooter.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(215)))), ((int)(((byte)(234)))), ((int)(((byte)(221)))));
            this.gridView1.Appearance.GroupFooter.ForeColor = System.Drawing.Color.Black;
            this.gridView1.Appearance.GroupFooter.Options.UseBackColor = true;
            this.gridView1.Appearance.GroupFooter.Options.UseBorderColor = true;
            this.gridView1.Appearance.GroupFooter.Options.UseForeColor = true;
            this.gridView1.Appearance.GroupPanel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(242)))), ((int)(((byte)(244)))), ((int)(((byte)(236)))));
            this.gridView1.Appearance.GroupPanel.BackColor2 = System.Drawing.Color.White;
            this.gridView1.Appearance.GroupPanel.ForeColor = System.Drawing.Color.Black;
            this.gridView1.Appearance.GroupPanel.Options.UseBackColor = true;
            this.gridView1.Appearance.GroupPanel.Options.UseForeColor = true;
            this.gridView1.Appearance.GroupRow.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(215)))), ((int)(((byte)(234)))), ((int)(((byte)(221)))));
            this.gridView1.Appearance.GroupRow.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(215)))), ((int)(((byte)(234)))), ((int)(((byte)(221)))));
            this.gridView1.Appearance.GroupRow.ForeColor = System.Drawing.Color.Black;
            this.gridView1.Appearance.GroupRow.Options.UseBackColor = true;
            this.gridView1.Appearance.GroupRow.Options.UseBorderColor = true;
            this.gridView1.Appearance.GroupRow.Options.UseForeColor = true;
            this.gridView1.Appearance.HeaderPanel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(211)))), ((int)(((byte)(226)))), ((int)(((byte)(216)))));
            this.gridView1.Appearance.HeaderPanel.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(211)))), ((int)(((byte)(226)))), ((int)(((byte)(216)))));
            this.gridView1.Appearance.HeaderPanel.ForeColor = System.Drawing.Color.Black;
            this.gridView1.Appearance.HeaderPanel.Options.UseBackColor = true;
            this.gridView1.Appearance.HeaderPanel.Options.UseBorderColor = true;
            this.gridView1.Appearance.HeaderPanel.Options.UseForeColor = true;
            this.gridView1.Appearance.HideSelectionRow.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(186)))), ((int)(((byte)(211)))), ((int)(((byte)(215)))));
            this.gridView1.Appearance.HideSelectionRow.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(104)))), ((int)(((byte)(130)))), ((int)(((byte)(134)))));
            this.gridView1.Appearance.HideSelectionRow.Options.UseBackColor = true;
            this.gridView1.Appearance.HideSelectionRow.Options.UseForeColor = true;
            this.gridView1.Appearance.HorzLine.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(172)))), ((int)(((byte)(197)))), ((int)(((byte)(180)))));
            this.gridView1.Appearance.HorzLine.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(117)))), ((int)(((byte)(136)))), ((int)(((byte)(122)))));
            this.gridView1.Appearance.HorzLine.Options.UseBackColor = true;
            this.gridView1.Appearance.HorzLine.Options.UseBorderColor = true;
            this.gridView1.Appearance.OddRow.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(242)))), ((int)(((byte)(244)))), ((int)(((byte)(236)))));
            this.gridView1.Appearance.OddRow.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(242)))), ((int)(((byte)(244)))), ((int)(((byte)(236)))));
            this.gridView1.Appearance.OddRow.ForeColor = System.Drawing.Color.Black;
            this.gridView1.Appearance.OddRow.Options.UseBackColor = true;
            this.gridView1.Appearance.OddRow.Options.UseBorderColor = true;
            this.gridView1.Appearance.OddRow.Options.UseForeColor = true;
            this.gridView1.Appearance.Preview.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(250)))), ((int)(((byte)(250)))), ((int)(((byte)(240)))));
            this.gridView1.Appearance.Preview.Font = new System.Drawing.Font("Verdana", 7.5F);
            this.gridView1.Appearance.Preview.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(104)))), ((int)(((byte)(130)))), ((int)(((byte)(134)))));
            this.gridView1.Appearance.Preview.Options.UseBackColor = true;
            this.gridView1.Appearance.Preview.Options.UseFont = true;
            this.gridView1.Appearance.Preview.Options.UseForeColor = true;
            this.gridView1.Appearance.Row.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(242)))), ((int)(((byte)(244)))), ((int)(((byte)(236)))));
            this.gridView1.Appearance.Row.ForeColor = System.Drawing.Color.Black;
            this.gridView1.Appearance.Row.Options.UseBackColor = true;
            this.gridView1.Appearance.Row.Options.UseForeColor = true;
            this.gridView1.Appearance.RowSeparator.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(242)))), ((int)(((byte)(244)))), ((int)(((byte)(236)))));
            this.gridView1.Appearance.RowSeparator.BackColor2 = System.Drawing.Color.White;
            this.gridView1.Appearance.RowSeparator.Options.UseBackColor = true;
            this.gridView1.Appearance.SelectedRow.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(159)))), ((int)(((byte)(201)))), ((int)(((byte)(207)))));
            this.gridView1.Appearance.SelectedRow.ForeColor = System.Drawing.Color.Black;
            this.gridView1.Appearance.SelectedRow.Options.UseBackColor = true;
            this.gridView1.Appearance.SelectedRow.Options.UseForeColor = true;
            this.gridView1.Appearance.TopNewRow.BackColor = System.Drawing.Color.White;
            this.gridView1.Appearance.TopNewRow.Options.UseBackColor = true;
            this.gridView1.Appearance.VertLine.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(172)))), ((int)(((byte)(197)))), ((int)(((byte)(180)))));
            this.gridView1.Appearance.VertLine.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(117)))), ((int)(((byte)(136)))), ((int)(((byte)(122)))));
            this.gridView1.Appearance.VertLine.Options.UseBackColor = true;
            this.gridView1.Appearance.VertLine.Options.UseBorderColor = true;
            this.gridView1.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.g生产订单ID,
            this.g外销订单,
            this.g产品编码,
            this.g物料编码,
            this.g半成品编码,
            this.g制造令号码,
            this.g生产订单行号,
            this.g产品名称,
            this.g产品规格,
            this.g班组,
            this.g下一班组,
            this.g工序,
            this.g下道工序,
            this.g制造令数量,
            this.g计划数量,
            this.g计划日期,
            this.g人员,
            this.g设备,
            this.g选择,
            this.g行号,
            this.g理论工时,
            this.g是否入库,
            this.g备注,
            this.g预计计划数量,
            this.g托外结束时间});
            this.gridView1.GridControl = this.gridControl1;
            this.gridView1.IndicatorWidth = 40;
            this.gridView1.Name = "gridView1";
            this.gridView1.OptionsBehavior.Editable = false;
            this.gridView1.OptionsCustomization.AllowFilter = false;
            this.gridView1.OptionsPrint.AutoWidth = false;
            this.gridView1.OptionsView.ColumnAutoWidth = false;
            this.gridView1.OptionsView.EnableAppearanceEvenRow = true;
            this.gridView1.OptionsView.EnableAppearanceOddRow = true;
            this.gridView1.OptionsView.ShowFooter = true;
            this.gridView1.OptionsView.ShowGroupPanel = false;
            this.gridView1.CustomDrawRowIndicator += new DevExpress.XtraGrid.Views.Grid.RowIndicatorCustomDrawEventHandler(this.gridView1_CustomDrawRowIndicator);
            // 
            // g生产订单ID
            // 
            this.g生产订单ID.Caption = "生产订单ID";
            this.g生产订单ID.FieldName = "生产订单ID";
            this.g生产订单ID.Name = "g生产订单ID";
            this.g生产订单ID.Width = 71;
            // 
            // g外销订单
            // 
            this.g外销订单.Caption = "外销订单";
            this.g外销订单.FieldName = "外销订单";
            this.g外销订单.Name = "g外销订单";
            this.g外销订单.Visible = true;
            this.g外销订单.VisibleIndex = 11;
            this.g外销订单.Width = 80;
            // 
            // g产品编码
            // 
            this.g产品编码.Caption = "产品编码";
            this.g产品编码.FieldName = "产品编码";
            this.g产品编码.Name = "g产品编码";
            this.g产品编码.Visible = true;
            this.g产品编码.VisibleIndex = 12;
            this.g产品编码.Width = 70;
            // 
            // g物料编码
            // 
            this.g物料编码.Caption = "物料编码";
            this.g物料编码.FieldName = "物料编码";
            this.g物料编码.Name = "g物料编码";
            this.g物料编码.Visible = true;
            this.g物料编码.VisibleIndex = 3;
            this.g物料编码.Width = 62;
            // 
            // g半成品编码
            // 
            this.g半成品编码.Caption = "半成品编码";
            this.g半成品编码.FieldName = "半成品编码";
            this.g半成品编码.Name = "g半成品编码";
            this.g半成品编码.Visible = true;
            this.g半成品编码.VisibleIndex = 13;
            this.g半成品编码.Width = 84;
            // 
            // g制造令号码
            // 
            this.g制造令号码.Caption = "制造令号码";
            this.g制造令号码.FieldName = "制造令号码";
            this.g制造令号码.Name = "g制造令号码";
            this.g制造令号码.Visible = true;
            this.g制造令号码.VisibleIndex = 1;
            this.g制造令号码.Width = 79;
            // 
            // g生产订单行号
            // 
            this.g生产订单行号.Caption = "生产订单行号";
            this.g生产订单行号.FieldName = "生产订单行号";
            this.g生产订单行号.Name = "g生产订单行号";
            this.g生产订单行号.Width = 47;
            // 
            // g产品名称
            // 
            this.g产品名称.Caption = "产品名称";
            this.g产品名称.FieldName = "产品名称";
            this.g产品名称.Name = "g产品名称";
            this.g产品名称.Visible = true;
            this.g产品名称.VisibleIndex = 4;
            this.g产品名称.Width = 79;
            // 
            // g产品规格
            // 
            this.g产品规格.Caption = "产品规格";
            this.g产品规格.FieldName = "产品规格";
            this.g产品规格.Name = "g产品规格";
            this.g产品规格.Visible = true;
            this.g产品规格.VisibleIndex = 5;
            this.g产品规格.Width = 83;
            // 
            // g班组
            // 
            this.g班组.Caption = "班组";
            this.g班组.ColumnEdit = this.ItemLookUpEditDepartment;
            this.g班组.FieldName = "班组";
            this.g班组.Name = "g班组";
            this.g班组.Visible = true;
            this.g班组.VisibleIndex = 7;
            this.g班组.Width = 63;
            // 
            // ItemLookUpEditDepartment
            // 
            this.ItemLookUpEditDepartment.AutoHeight = false;
            this.ItemLookUpEditDepartment.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.ItemLookUpEditDepartment.DisplayMember = "cDepName";
            this.ItemLookUpEditDepartment.Name = "ItemLookUpEditDepartment";
            this.ItemLookUpEditDepartment.ValueMember = "cDepName";
            // 
            // g下一班组
            // 
            this.g下一班组.Caption = "下一班组";
            this.g下一班组.ColumnEdit = this.ItemLookUpEditDepartment;
            this.g下一班组.FieldName = "下一班组";
            this.g下一班组.Name = "g下一班组";
            this.g下一班组.Visible = true;
            this.g下一班组.VisibleIndex = 8;
            this.g下一班组.Width = 62;
            // 
            // g工序
            // 
            this.g工序.Caption = "工序";
            this.g工序.FieldName = "工序";
            this.g工序.Name = "g工序";
            this.g工序.Visible = true;
            this.g工序.VisibleIndex = 9;
            this.g工序.Width = 66;
            // 
            // g下道工序
            // 
            this.g下道工序.Caption = "下道工序";
            this.g下道工序.FieldName = "下道工序";
            this.g下道工序.Name = "g下道工序";
            this.g下道工序.Visible = true;
            this.g下道工序.VisibleIndex = 10;
            this.g下道工序.Width = 79;
            // 
            // g制造令数量
            // 
            this.g制造令数量.Caption = "制造令数量";
            this.g制造令数量.FieldName = "制造令数量";
            this.g制造令数量.Name = "g制造令数量";
            this.g制造令数量.Summary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] {
            new DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum)});
            this.g制造令数量.Visible = true;
            this.g制造令数量.VisibleIndex = 6;
            this.g制造令数量.Width = 84;
            // 
            // g计划数量
            // 
            this.g计划数量.Caption = "计划数量";
            this.g计划数量.FieldName = "计划数量";
            this.g计划数量.Name = "g计划数量";
            this.g计划数量.Summary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] {
            new DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum)});
            this.g计划数量.Visible = true;
            this.g计划数量.VisibleIndex = 14;
            this.g计划数量.Width = 73;
            // 
            // g计划日期
            // 
            this.g计划日期.Caption = "计划日期";
            this.g计划日期.ColumnEdit = this.repositoryItemDateEdit1;
            this.g计划日期.FieldName = "计划日期";
            this.g计划日期.Name = "g计划日期";
            this.g计划日期.Visible = true;
            this.g计划日期.VisibleIndex = 2;
            this.g计划日期.Width = 66;
            // 
            // repositoryItemDateEdit1
            // 
            this.repositoryItemDateEdit1.AutoHeight = false;
            this.repositoryItemDateEdit1.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.repositoryItemDateEdit1.Name = "repositoryItemDateEdit1";
            this.repositoryItemDateEdit1.VistaTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
            // 
            // g人员
            // 
            this.g人员.Caption = "人员";
            this.g人员.FieldName = "人员";
            this.g人员.Name = "g人员";
            this.g人员.Visible = true;
            this.g人员.VisibleIndex = 16;
            this.g人员.Width = 68;
            // 
            // g设备
            // 
            this.g设备.Caption = "设备";
            this.g设备.FieldName = "设备";
            this.g设备.Name = "g设备";
            this.g设备.Visible = true;
            this.g设备.VisibleIndex = 17;
            this.g设备.Width = 48;
            // 
            // g选择
            // 
            this.g选择.FieldName = "选择";
            this.g选择.Name = "g选择";
            this.g选择.Visible = true;
            this.g选择.VisibleIndex = 0;
            this.g选择.Width = 34;
            // 
            // g行号
            // 
            this.g行号.Caption = "行号";
            this.g行号.FieldName = "行号";
            this.g行号.Name = "g行号";
            this.g行号.Width = 42;
            // 
            // g理论工时
            // 
            this.g理论工时.Caption = "理论工时";
            this.g理论工时.FieldName = "理论工时";
            this.g理论工时.Name = "g理论工时";
            this.g理论工时.Summary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] {
            new DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum)});
            this.g理论工时.Visible = true;
            this.g理论工时.VisibleIndex = 18;
            this.g理论工时.Width = 74;
            // 
            // g是否入库
            // 
            this.g是否入库.Caption = "是否入库";
            this.g是否入库.FieldName = "是否入库";
            this.g是否入库.Name = "g是否入库";
            this.g是否入库.OptionsColumn.AllowEdit = false;
            this.g是否入库.Visible = true;
            this.g是否入库.VisibleIndex = 19;
            this.g是否入库.Width = 101;
            // 
            // g备注
            // 
            this.g备注.Caption = "备注";
            this.g备注.FieldName = "备注";
            this.g备注.Name = "g备注";
            this.g备注.Visible = true;
            this.g备注.VisibleIndex = 20;
            // 
            // g预计计划数量
            // 
            this.g预计计划数量.Caption = "预计计划数量";
            this.g预计计划数量.FieldName = "预计计划数量";
            this.g预计计划数量.Name = "g预计计划数量";
            this.g预计计划数量.OptionsColumn.AllowEdit = false;
            this.g预计计划数量.Summary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] {
            new DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum)});
            this.g预计计划数量.Visible = true;
            this.g预计计划数量.VisibleIndex = 15;
            this.g预计计划数量.Width = 94;
            // 
            // g托外结束时间
            // 
            this.g托外结束时间.Caption = "托外结束时间";
            this.g托外结束时间.FieldName = "托外结束时间";
            this.g托外结束时间.Name = "g托外结束时间";
            this.g托外结束时间.OptionsColumn.AllowEdit = false;
            this.g托外结束时间.Visible = true;
            this.g托外结束时间.VisibleIndex = 21;
            // 
            // btnCheck
            // 
            this.btnCheck.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCheck.Location = new System.Drawing.Point(937, 535);
            this.btnCheck.Name = "btnCheck";
            this.btnCheck.Size = new System.Drawing.Size(75, 23);
            this.btnCheck.TabIndex = 12;
            this.btnCheck.Text = "验证";
            this.btnCheck.UseVisualStyleBackColor = true;
            this.btnCheck.Click += new System.EventHandler(this.btnCheck_Click);
            // 
            // btnSave
            // 
            this.btnSave.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSave.Location = new System.Drawing.Point(1028, 535);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(75, 23);
            this.btnSave.TabIndex = 13;
            this.btnSave.Text = "导入";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // btnExport
            // 
            this.btnExport.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnExport.Location = new System.Drawing.Point(1118, 535);
            this.btnExport.Name = "btnExport";
            this.btnExport.Size = new System.Drawing.Size(75, 23);
            this.btnExport.TabIndex = 13;
            this.btnExport.Text = "导出";
            this.btnExport.UseVisualStyleBackColor = true;
            this.btnExport.Click += new System.EventHandler(this.btnExport_Click);
            // 
            // Frm生产计划导入
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1249, 577);
            this.Controls.Add(this.btnExport);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.btnCheck);
            this.Controls.Add(this.gridControl1);
            this.Name = "Frm生产计划导入";
            this.Text = "生产计划导入";
            this.Load += new System.EventHandler(this.Frm生产计划导入_Load);
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ItemLookUpEditDepartment)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemDateEdit1.VistaTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemDateEdit1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraGrid.GridControl gridControl1;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView1;
        private DevExpress.XtraGrid.Columns.GridColumn g生产订单ID;
        private DevExpress.XtraGrid.Columns.GridColumn g外销订单;
        private DevExpress.XtraGrid.Columns.GridColumn g产品编码;
        private DevExpress.XtraGrid.Columns.GridColumn g物料编码;
        private DevExpress.XtraGrid.Columns.GridColumn g半成品编码;
        private DevExpress.XtraGrid.Columns.GridColumn g制造令号码;
        private DevExpress.XtraGrid.Columns.GridColumn g生产订单行号;
        private DevExpress.XtraGrid.Columns.GridColumn g产品名称;
        private DevExpress.XtraGrid.Columns.GridColumn g产品规格;
        private DevExpress.XtraGrid.Columns.GridColumn g班组;
        private DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit ItemLookUpEditDepartment;
        private DevExpress.XtraGrid.Columns.GridColumn g下一班组;
        private DevExpress.XtraGrid.Columns.GridColumn g工序;
        private DevExpress.XtraGrid.Columns.GridColumn g下道工序;
        private DevExpress.XtraGrid.Columns.GridColumn g制造令数量;
        private DevExpress.XtraGrid.Columns.GridColumn g计划数量;
        private DevExpress.XtraGrid.Columns.GridColumn g计划日期;
        private DevExpress.XtraEditors.Repository.RepositoryItemDateEdit repositoryItemDateEdit1;
        private DevExpress.XtraGrid.Columns.GridColumn g人员;
        private DevExpress.XtraGrid.Columns.GridColumn g设备;
        private DevExpress.XtraGrid.Columns.GridColumn g选择;
        private DevExpress.XtraGrid.Columns.GridColumn g行号;
        private DevExpress.XtraGrid.Columns.GridColumn g理论工时;
        private DevExpress.XtraGrid.Columns.GridColumn g是否入库;
        private DevExpress.XtraGrid.Columns.GridColumn g备注;
        private DevExpress.XtraGrid.Columns.GridColumn g预计计划数量;
        private DevExpress.XtraGrid.Columns.GridColumn g托外结束时间;
        private System.Windows.Forms.Button btnCheck;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Button btnExport;
    }
}