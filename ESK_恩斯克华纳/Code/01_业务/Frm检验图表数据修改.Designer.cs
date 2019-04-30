namespace 业务
{
    partial class Frm检验图表数据修改
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
            this.gridColiID = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridCol工作台 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridCol量具品名 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridCol测定项目 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridCol测定项目日文 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridCol规格 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridCol尺寸公差 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridCol下限 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridCol上限 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridCol备注 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridCol测量值 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridCol原始值 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridCol发射器ID = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColSelected = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridCol检验时间 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.ItemLookUpEdit送检零件编号 = new DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit();
            this.ItemLookUpEdit量具档案 = new DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit();
            this.ItemLookUpEdit发射头编号 = new DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit();
            this.ItemLookUpEdit测量项目编号 = new DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit();
            this.btnSave = new System.Windows.Forms.Button();
            this.btnDel = new System.Windows.Forms.Button();
            this.btnExit = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ItemLookUpEdit送检零件编号)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ItemLookUpEdit量具档案)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ItemLookUpEdit发射头编号)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ItemLookUpEdit测量项目编号)).BeginInit();
            this.SuspendLayout();
            // 
            // gridControl1
            // 
            this.gridControl1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.gridControl1.Location = new System.Drawing.Point(3, 1);
            this.gridControl1.MainView = this.gridView1;
            this.gridControl1.Name = "gridControl1";
            this.gridControl1.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.ItemLookUpEdit送检零件编号,
            this.ItemLookUpEdit量具档案,
            this.ItemLookUpEdit发射头编号,
            this.ItemLookUpEdit测量项目编号});
            this.gridControl1.Size = new System.Drawing.Size(1034, 599);
            this.gridControl1.TabIndex = 8;
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
            this.gridColiID,
            this.gridCol工作台,
            this.gridCol量具品名,
            this.gridCol测定项目,
            this.gridCol测定项目日文,
            this.gridCol规格,
            this.gridCol尺寸公差,
            this.gridCol下限,
            this.gridCol上限,
            this.gridCol备注,
            this.gridCol测量值,
            this.gridCol原始值,
            this.gridCol发射器ID,
            this.gridColSelected,
            this.gridCol检验时间});
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
            this.gridView1.CustomDrawRowIndicator += new DevExpress.XtraGrid.Views.Grid.RowIndicatorCustomDrawEventHandler(this.gridView1_CustomDrawRowIndicator);
            this.gridView1.CellValueChanged += new DevExpress.XtraGrid.Views.Base.CellValueChangedEventHandler(this.gridView1_CellValueChanged);
            // 
            // gridColiID
            // 
            this.gridColiID.Caption = "序号";
            this.gridColiID.FieldName = "iID";
            this.gridColiID.Name = "gridColiID";
            this.gridColiID.OptionsColumn.AllowEdit = false;
            this.gridColiID.Visible = true;
            this.gridColiID.VisibleIndex = 1;
            this.gridColiID.Width = 35;
            // 
            // gridCol工作台
            // 
            this.gridCol工作台.Caption = "工作台";
            this.gridCol工作台.FieldName = "工作台";
            this.gridCol工作台.Name = "gridCol工作台";
            this.gridCol工作台.OptionsColumn.AllowEdit = false;
            this.gridCol工作台.Visible = true;
            this.gridCol工作台.VisibleIndex = 3;
            this.gridCol工作台.Width = 87;
            // 
            // gridCol量具品名
            // 
            this.gridCol量具品名.Caption = "量具品名";
            this.gridCol量具品名.FieldName = "量具品名";
            this.gridCol量具品名.Name = "gridCol量具品名";
            this.gridCol量具品名.OptionsColumn.AllowEdit = false;
            this.gridCol量具品名.Visible = true;
            this.gridCol量具品名.VisibleIndex = 4;
            this.gridCol量具品名.Width = 117;
            // 
            // gridCol测定项目
            // 
            this.gridCol测定项目.Caption = "测定项目";
            this.gridCol测定项目.FieldName = "测定项目";
            this.gridCol测定项目.Name = "gridCol测定项目";
            this.gridCol测定项目.OptionsColumn.AllowEdit = false;
            this.gridCol测定项目.Visible = true;
            this.gridCol测定项目.VisibleIndex = 5;
            this.gridCol测定项目.Width = 197;
            // 
            // gridCol测定项目日文
            // 
            this.gridCol测定项目日文.Caption = "测定项目日文";
            this.gridCol测定项目日文.FieldName = "测定项目日文";
            this.gridCol测定项目日文.Name = "gridCol测定项目日文";
            this.gridCol测定项目日文.OptionsColumn.AllowEdit = false;
            this.gridCol测定项目日文.Visible = true;
            this.gridCol测定项目日文.VisibleIndex = 6;
            this.gridCol测定项目日文.Width = 199;
            // 
            // gridCol规格
            // 
            this.gridCol规格.Caption = "规格";
            this.gridCol规格.FieldName = "规格";
            this.gridCol规格.Name = "gridCol规格";
            this.gridCol规格.OptionsColumn.AllowEdit = false;
            this.gridCol规格.Visible = true;
            this.gridCol规格.VisibleIndex = 10;
            this.gridCol规格.Width = 135;
            // 
            // gridCol尺寸公差
            // 
            this.gridCol尺寸公差.Caption = "尺寸公差";
            this.gridCol尺寸公差.FieldName = "尺寸公差";
            this.gridCol尺寸公差.Name = "gridCol尺寸公差";
            this.gridCol尺寸公差.OptionsColumn.AllowEdit = false;
            this.gridCol尺寸公差.Visible = true;
            this.gridCol尺寸公差.VisibleIndex = 11;
            this.gridCol尺寸公差.Width = 164;
            // 
            // gridCol下限
            // 
            this.gridCol下限.Caption = "下限";
            this.gridCol下限.FieldName = "下限";
            this.gridCol下限.Name = "gridCol下限";
            this.gridCol下限.OptionsColumn.AllowEdit = false;
            this.gridCol下限.Visible = true;
            this.gridCol下限.VisibleIndex = 12;
            // 
            // gridCol上限
            // 
            this.gridCol上限.Caption = "上限";
            this.gridCol上限.FieldName = "上限";
            this.gridCol上限.Name = "gridCol上限";
            this.gridCol上限.OptionsColumn.AllowEdit = false;
            this.gridCol上限.Visible = true;
            this.gridCol上限.VisibleIndex = 13;
            // 
            // gridCol备注
            // 
            this.gridCol备注.Caption = "备注";
            this.gridCol备注.FieldName = "备注";
            this.gridCol备注.Name = "gridCol备注";
            this.gridCol备注.OptionsColumn.AllowEdit = false;
            this.gridCol备注.Visible = true;
            this.gridCol备注.VisibleIndex = 14;
            this.gridCol备注.Width = 421;
            // 
            // gridCol测量值
            // 
            this.gridCol测量值.AppearanceHeader.ForeColor = System.Drawing.Color.Blue;
            this.gridCol测量值.AppearanceHeader.Options.UseForeColor = true;
            this.gridCol测量值.Caption = "测量值";
            this.gridCol测量值.FieldName = "测量值";
            this.gridCol测量值.Name = "gridCol测量值";
            this.gridCol测量值.OptionsColumn.AllowEdit = false;
            this.gridCol测量值.Visible = true;
            this.gridCol测量值.VisibleIndex = 8;
            // 
            // gridCol原始值
            // 
            this.gridCol原始值.Caption = "原始值";
            this.gridCol原始值.FieldName = "原始值";
            this.gridCol原始值.Name = "gridCol原始值";
            this.gridCol原始值.OptionsColumn.AllowEdit = false;
            this.gridCol原始值.Visible = true;
            this.gridCol原始值.VisibleIndex = 9;
            // 
            // gridCol发射器ID
            // 
            this.gridCol发射器ID.Caption = "发射器ID";
            this.gridCol发射器ID.FieldName = "发射器ID";
            this.gridCol发射器ID.Name = "gridCol发射器ID";
            this.gridCol发射器ID.OptionsColumn.AllowEdit = false;
            this.gridCol发射器ID.Visible = true;
            this.gridCol发射器ID.VisibleIndex = 2;
            // 
            // gridColSelected
            // 
            this.gridColSelected.Caption = "选择";
            this.gridColSelected.FieldName = "Selected";
            this.gridColSelected.Name = "gridColSelected";
            this.gridColSelected.Visible = true;
            this.gridColSelected.VisibleIndex = 0;
            this.gridColSelected.Width = 45;
            // 
            // gridCol检验时间
            // 
            this.gridCol检验时间.Caption = "检验时间";
            this.gridCol检验时间.DisplayFormat.FormatString = "G";
            this.gridCol检验时间.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.gridCol检验时间.FieldName = "检验时间";
            this.gridCol检验时间.Name = "gridCol检验时间";
            this.gridCol检验时间.OptionsColumn.AllowEdit = false;
            this.gridCol检验时间.Visible = true;
            this.gridCol检验时间.VisibleIndex = 7;
            // 
            // ItemLookUpEdit送检零件编号
            // 
            this.ItemLookUpEdit送检零件编号.AutoHeight = false;
            this.ItemLookUpEdit送检零件编号.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.ItemLookUpEdit送检零件编号.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("iID", "编号"),
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("iText", 60, "检验工位")});
            this.ItemLookUpEdit送检零件编号.DisplayMember = "iText";
            this.ItemLookUpEdit送检零件编号.Name = "ItemLookUpEdit送检零件编号";
            this.ItemLookUpEdit送检零件编号.NullText = "";
            this.ItemLookUpEdit送检零件编号.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.Standard;
            this.ItemLookUpEdit送检零件编号.ValueMember = "iID";
            // 
            // ItemLookUpEdit量具档案
            // 
            this.ItemLookUpEdit量具档案.AutoHeight = false;
            this.ItemLookUpEdit量具档案.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.ItemLookUpEdit量具档案.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("iID", "编号"),
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("iText", "量具")});
            this.ItemLookUpEdit量具档案.DisplayMember = "iText";
            this.ItemLookUpEdit量具档案.Name = "ItemLookUpEdit量具档案";
            this.ItemLookUpEdit量具档案.NullText = "";
            this.ItemLookUpEdit量具档案.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.Standard;
            this.ItemLookUpEdit量具档案.ValueMember = "iID";
            // 
            // ItemLookUpEdit发射头编号
            // 
            this.ItemLookUpEdit发射头编号.AutoHeight = false;
            this.ItemLookUpEdit发射头编号.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.ItemLookUpEdit发射头编号.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("iID", "编号"),
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("iText", "发射头")});
            this.ItemLookUpEdit发射头编号.DisplayMember = "iText";
            this.ItemLookUpEdit发射头编号.Name = "ItemLookUpEdit发射头编号";
            this.ItemLookUpEdit发射头编号.NullText = "";
            this.ItemLookUpEdit发射头编号.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.Standard;
            this.ItemLookUpEdit发射头编号.ValueMember = "iID";
            // 
            // ItemLookUpEdit测量项目编号
            // 
            this.ItemLookUpEdit测量项目编号.AutoHeight = false;
            this.ItemLookUpEdit测量项目编号.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.ItemLookUpEdit测量项目编号.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("iID", "编号"),
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("iText", "测量项目")});
            this.ItemLookUpEdit测量项目编号.DisplayMember = "iText";
            this.ItemLookUpEdit测量项目编号.Name = "ItemLookUpEdit测量项目编号";
            this.ItemLookUpEdit测量项目编号.NullText = "";
            this.ItemLookUpEdit测量项目编号.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.Standard;
            this.ItemLookUpEdit测量项目编号.ValueMember = "iID";
            // 
            // btnSave
            // 
            this.btnSave.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSave.Location = new System.Drawing.Point(710, 606);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(75, 23);
            this.btnSave.TabIndex = 9;
            this.btnSave.Text = "保 存";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // btnDel
            // 
            this.btnDel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnDel.Location = new System.Drawing.Point(831, 606);
            this.btnDel.Name = "btnDel";
            this.btnDel.Size = new System.Drawing.Size(75, 23);
            this.btnDel.TabIndex = 10;
            this.btnDel.Text = "删 除";
            this.btnDel.UseVisualStyleBackColor = true;
            this.btnDel.Click += new System.EventHandler(this.btnDel_Click);
            // 
            // btnExit
            // 
            this.btnExit.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnExit.Location = new System.Drawing.Point(952, 606);
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size(75, 23);
            this.btnExit.TabIndex = 11;
            this.btnExit.Text = "退 出";
            this.btnExit.UseVisualStyleBackColor = true;
            this.btnExit.Click += new System.EventHandler(this.btnExit_Click);
            // 
            // Frm检验图表数据修改
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1039, 640);
            this.Controls.Add(this.btnExit);
            this.Controls.Add(this.btnDel);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.gridControl1);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Frm检验图表数据修改";
            this.Text = "修改数据";
            this.Load += new System.EventHandler(this.Frm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ItemLookUpEdit送检零件编号)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ItemLookUpEdit量具档案)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ItemLookUpEdit发射头编号)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ItemLookUpEdit测量项目编号)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraGrid.GridControl gridControl1;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView1;
        private DevExpress.XtraGrid.Columns.GridColumn gridColiID;
        private DevExpress.XtraGrid.Columns.GridColumn gridCol工作台;
        private DevExpress.XtraGrid.Columns.GridColumn gridCol量具品名;
        private DevExpress.XtraGrid.Columns.GridColumn gridCol测定项目;
        private DevExpress.XtraGrid.Columns.GridColumn gridCol测定项目日文;
        private DevExpress.XtraGrid.Columns.GridColumn gridCol规格;
        private DevExpress.XtraGrid.Columns.GridColumn gridCol尺寸公差;
        private DevExpress.XtraGrid.Columns.GridColumn gridCol下限;
        private DevExpress.XtraGrid.Columns.GridColumn gridCol上限;
        private DevExpress.XtraGrid.Columns.GridColumn gridCol备注;
        private DevExpress.XtraGrid.Columns.GridColumn gridCol测量值;
        private DevExpress.XtraGrid.Columns.GridColumn gridCol原始值;
        private DevExpress.XtraGrid.Columns.GridColumn gridCol发射器ID;
        private DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit ItemLookUpEdit送检零件编号;
        private DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit ItemLookUpEdit量具档案;
        private DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit ItemLookUpEdit发射头编号;
        private DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit ItemLookUpEdit测量项目编号;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Button btnDel;
        private System.Windows.Forms.Button btnExit;
        private DevExpress.XtraGrid.Columns.GridColumn gridColSelected;
        private DevExpress.XtraGrid.Columns.GridColumn gridCol检验时间;

    }
}