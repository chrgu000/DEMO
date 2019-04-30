namespace Base
{
    partial class Frm询价单结论公布sel
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            DevExpress.XtraGrid.GridLevelNode gridLevelNode1 = new DevExpress.XtraGrid.GridLevelNode();
            this.gridControl1 = new DevExpress.XtraGrid.GridControl();
            this.gridView1 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.gridCol标题 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridCol备注 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridCol制单人 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.ItemLookUpEditUser = new DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit();
            this.gridCol制单日期 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridCol发布人 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridCol发布日期 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColGUID = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridCol供应商编码 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridCol供应商名称 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridCol截止日期 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridCol单据日期 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridCol终止询价日期 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridCol终止人 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridCol审批结论 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridCol审批时间 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridCol审批人 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.label1 = new System.Windows.Forms.Label();
            this.date1 = new DevExpress.XtraEditors.DateEdit();
            this.date2 = new DevExpress.XtraEditors.DateEdit();
            this.lookUpEditcVenCode = new DevExpress.XtraEditors.LookUpEdit();
            this.label2 = new System.Windows.Forms.Label();
            this.btnOK = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ItemLookUpEditUser)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.date1.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.date2.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lookUpEditcVenCode.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // childLF
            // 
            this.childLF.LookAndFeel.Style = DevExpress.LookAndFeel.LookAndFeelStyle.Skin;
            this.childLF.LookAndFeel.UseWindowsXPTheme = false;
            // 
            // gridControl1
            // 
            this.gridControl1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.gridControl1.EmbeddedNavigator.Name = "";
            gridLevelNode1.RelationName = "Level1";
            this.gridControl1.LevelTree.Nodes.AddRange(new DevExpress.XtraGrid.GridLevelNode[] {
            gridLevelNode1});
            this.gridControl1.Location = new System.Drawing.Point(7, 55);
            this.gridControl1.MainView = this.gridView1;
            this.gridControl1.Name = "gridControl1";
            this.gridControl1.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.ItemLookUpEditUser});
            this.gridControl1.Size = new System.Drawing.Size(933, 341);
            this.gridControl1.TabIndex = 71;
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
            this.gridCol标题,
            this.gridCol备注,
            this.gridCol制单人,
            this.gridCol制单日期,
            this.gridCol发布人,
            this.gridCol发布日期,
            this.gridColGUID,
            this.gridCol供应商编码,
            this.gridCol供应商名称,
            this.gridCol截止日期,
            this.gridCol单据日期,
            this.gridCol终止询价日期,
            this.gridCol终止人,
            this.gridCol审批结论,
            this.gridCol审批时间,
            this.gridCol审批人});
            this.gridView1.CustomizationFormBounds = new System.Drawing.Rectangle(816, 318, 208, 177);
            this.gridView1.GridControl = this.gridControl1;
            this.gridView1.IndicatorWidth = 40;
            this.gridView1.Name = "gridView1";
            this.gridView1.OptionsLayout.Columns.StoreAllOptions = true;
            this.gridView1.OptionsLayout.Columns.StoreAppearance = true;
            this.gridView1.OptionsLayout.StoreAllOptions = true;
            this.gridView1.OptionsLayout.StoreAppearance = true;
            this.gridView1.OptionsNavigation.EnterMoveNextColumn = true;
            this.gridView1.OptionsSelection.MultiSelect = true;
            this.gridView1.OptionsView.AutoCalcPreviewLineCount = true;
            this.gridView1.OptionsView.ColumnAutoWidth = false;
            this.gridView1.OptionsView.EnableAppearanceEvenRow = true;
            this.gridView1.OptionsView.EnableAppearanceOddRow = true;
            this.gridView1.OptionsView.ShowFooter = true;
            this.gridView1.OptionsView.ShowGroupPanel = false;
            this.gridView1.CustomDrawRowIndicator += new DevExpress.XtraGrid.Views.Grid.RowIndicatorCustomDrawEventHandler(this.gridView_CustomDrawRowIndicator);
            this.gridView1.DoubleClick += new System.EventHandler(this.gridView1_DoubleClick);
            // 
            // gridCol标题
            // 
            this.gridCol标题.Caption = "标题";
            this.gridCol标题.FieldName = "标题";
            this.gridCol标题.Name = "gridCol标题";
            this.gridCol标题.OptionsColumn.AllowEdit = false;
            this.gridCol标题.Visible = true;
            this.gridCol标题.VisibleIndex = 0;
            this.gridCol标题.Width = 85;
            // 
            // gridCol备注
            // 
            this.gridCol备注.Caption = "备注";
            this.gridCol备注.FieldName = "备注";
            this.gridCol备注.Name = "gridCol备注";
            this.gridCol备注.OptionsColumn.AllowEdit = false;
            this.gridCol备注.Visible = true;
            this.gridCol备注.VisibleIndex = 3;
            this.gridCol备注.Width = 216;
            // 
            // gridCol制单人
            // 
            this.gridCol制单人.Caption = "制单人";
            this.gridCol制单人.ColumnEdit = this.ItemLookUpEditUser;
            this.gridCol制单人.FieldName = "制单人";
            this.gridCol制单人.Name = "gridCol制单人";
            this.gridCol制单人.OptionsColumn.AllowEdit = false;
            this.gridCol制单人.Visible = true;
            this.gridCol制单人.VisibleIndex = 6;
            // 
            // ItemLookUpEditUser
            // 
            this.ItemLookUpEditUser.AutoHeight = false;
            this.ItemLookUpEditUser.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.ItemLookUpEditUser.DisplayMember = "vchrName";
            this.ItemLookUpEditUser.Name = "ItemLookUpEditUser";
            this.ItemLookUpEditUser.ValueMember = "vchrUid";
            // 
            // gridCol制单日期
            // 
            this.gridCol制单日期.Caption = "制单日期";
            this.gridCol制单日期.FieldName = "制单日期";
            this.gridCol制单日期.Name = "gridCol制单日期";
            this.gridCol制单日期.OptionsColumn.AllowEdit = false;
            this.gridCol制单日期.Visible = true;
            this.gridCol制单日期.VisibleIndex = 7;
            this.gridCol制单日期.Width = 104;
            // 
            // gridCol发布人
            // 
            this.gridCol发布人.Caption = "发布人";
            this.gridCol发布人.ColumnEdit = this.ItemLookUpEditUser;
            this.gridCol发布人.FieldName = "发布人";
            this.gridCol发布人.Name = "gridCol发布人";
            this.gridCol发布人.OptionsColumn.AllowEdit = false;
            this.gridCol发布人.Visible = true;
            this.gridCol发布人.VisibleIndex = 8;
            // 
            // gridCol发布日期
            // 
            this.gridCol发布日期.Caption = "发布日期";
            this.gridCol发布日期.FieldName = "发布日期";
            this.gridCol发布日期.Name = "gridCol发布日期";
            this.gridCol发布日期.OptionsColumn.AllowEdit = false;
            this.gridCol发布日期.Visible = true;
            this.gridCol发布日期.VisibleIndex = 9;
            this.gridCol发布日期.Width = 109;
            // 
            // gridColGUID
            // 
            this.gridColGUID.Caption = "GUID";
            this.gridColGUID.FieldName = "GUID";
            this.gridColGUID.Name = "gridColGUID";
            this.gridColGUID.OptionsColumn.AllowEdit = false;
            // 
            // gridCol供应商编码
            // 
            this.gridCol供应商编码.Caption = "供应商编码";
            this.gridCol供应商编码.FieldName = "供应商编码";
            this.gridCol供应商编码.Name = "gridCol供应商编码";
            this.gridCol供应商编码.OptionsColumn.AllowEdit = false;
            this.gridCol供应商编码.Visible = true;
            this.gridCol供应商编码.VisibleIndex = 4;
            // 
            // gridCol供应商名称
            // 
            this.gridCol供应商名称.Caption = "供应商名称";
            this.gridCol供应商名称.FieldName = "供应商名称";
            this.gridCol供应商名称.Name = "gridCol供应商名称";
            this.gridCol供应商名称.OptionsColumn.AllowEdit = false;
            this.gridCol供应商名称.Visible = true;
            this.gridCol供应商名称.VisibleIndex = 5;
            // 
            // gridCol截止日期
            // 
            this.gridCol截止日期.Caption = "截止日期";
            this.gridCol截止日期.FieldName = "截止日期";
            this.gridCol截止日期.Name = "gridCol截止日期";
            this.gridCol截止日期.OptionsColumn.AllowEdit = false;
            this.gridCol截止日期.Visible = true;
            this.gridCol截止日期.VisibleIndex = 2;
            this.gridCol截止日期.Width = 165;
            // 
            // gridCol单据日期
            // 
            this.gridCol单据日期.Caption = "单据日期";
            this.gridCol单据日期.FieldName = "单据日期";
            this.gridCol单据日期.Name = "gridCol单据日期";
            this.gridCol单据日期.OptionsColumn.AllowEdit = false;
            this.gridCol单据日期.Visible = true;
            this.gridCol单据日期.VisibleIndex = 1;
            // 
            // gridCol终止询价日期
            // 
            this.gridCol终止询价日期.Caption = "终止询价日期";
            this.gridCol终止询价日期.FieldName = "终止询价日期";
            this.gridCol终止询价日期.Name = "gridCol终止询价日期";
            this.gridCol终止询价日期.OptionsColumn.AllowEdit = false;
            this.gridCol终止询价日期.Visible = true;
            this.gridCol终止询价日期.VisibleIndex = 10;
            this.gridCol终止询价日期.Width = 87;
            // 
            // gridCol终止人
            // 
            this.gridCol终止人.Caption = "终止人";
            this.gridCol终止人.ColumnEdit = this.ItemLookUpEditUser;
            this.gridCol终止人.FieldName = "终止人";
            this.gridCol终止人.Name = "gridCol终止人";
            this.gridCol终止人.OptionsColumn.AllowEdit = false;
            this.gridCol终止人.Visible = true;
            this.gridCol终止人.VisibleIndex = 11;
            // 
            // gridCol审批结论
            // 
            this.gridCol审批结论.Caption = "审批结论";
            this.gridCol审批结论.FieldName = "审批结论";
            this.gridCol审批结论.Name = "gridCol审批结论";
            this.gridCol审批结论.OptionsColumn.AllowEdit = false;
            this.gridCol审批结论.Visible = true;
            this.gridCol审批结论.VisibleIndex = 12;
            // 
            // gridCol审批时间
            // 
            this.gridCol审批时间.Caption = "审批时间";
            this.gridCol审批时间.FieldName = "审批时间";
            this.gridCol审批时间.Name = "gridCol审批时间";
            this.gridCol审批时间.OptionsColumn.AllowEdit = false;
            this.gridCol审批时间.Visible = true;
            this.gridCol审批时间.VisibleIndex = 14;
            // 
            // gridCol审批人
            // 
            this.gridCol审批人.Caption = "审批人";
            this.gridCol审批人.ColumnEdit = this.ItemLookUpEditUser;
            this.gridCol审批人.FieldName = "审批人";
            this.gridCol审批人.Name = "gridCol审批人";
            this.gridCol审批人.OptionsColumn.AllowEdit = false;
            this.gridCol审批人.Visible = true;
            this.gridCol审批人.VisibleIndex = 13;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 31);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(55, 14);
            this.label1.TabIndex = 96;
            this.label1.Text = "单据日期";
            // 
            // date1
            // 
            this.date1.EditValue = new System.DateTime(2011, 10, 24, 0, 0, 0, 0);
            this.date1.Location = new System.Drawing.Point(73, 28);
            this.date1.Name = "date1";
            this.date1.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.date1.Size = new System.Drawing.Size(144, 21);
            this.date1.TabIndex = 97;
            // 
            // date2
            // 
            this.date2.EditValue = new System.DateTime(2011, 10, 24, 0, 0, 0, 0);
            this.date2.Location = new System.Drawing.Point(223, 28);
            this.date2.Name = "date2";
            this.date2.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.date2.Size = new System.Drawing.Size(144, 21);
            this.date2.TabIndex = 98;
            // 
            // lookUpEditcVenCode
            // 
            this.lookUpEditcVenCode.Enabled = false;
            this.lookUpEditcVenCode.Location = new System.Drawing.Point(442, 28);
            this.lookUpEditcVenCode.Name = "lookUpEditcVenCode";
            this.lookUpEditcVenCode.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.lookUpEditcVenCode.Properties.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("cVenCode", "编码", 20, DevExpress.Utils.FormatType.None, "", true, DevExpress.Utils.HorzAlignment.Default, DevExpress.Data.ColumnSortOrder.None),
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("cVenName", "名称", 20, DevExpress.Utils.FormatType.None, "", true, DevExpress.Utils.HorzAlignment.Default, DevExpress.Data.ColumnSortOrder.None)});
            this.lookUpEditcVenCode.Properties.DisplayMember = "cVenName";
            this.lookUpEditcVenCode.Properties.NullText = "";
            this.lookUpEditcVenCode.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.Standard;
            this.lookUpEditcVenCode.Properties.ValueMember = "cVenCode";
            this.lookUpEditcVenCode.Size = new System.Drawing.Size(250, 21);
            this.lookUpEditcVenCode.TabIndex = 120;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(381, 31);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(43, 14);
            this.label2.TabIndex = 121;
            this.label2.Text = "供应商";
            // 
            // btnOK
            // 
            this.btnOK.Location = new System.Drawing.Point(714, 28);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(75, 23);
            this.btnOK.TabIndex = 122;
            this.btnOK.Text = "确定";
            this.btnOK.UseVisualStyleBackColor = true;
            this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
            // 
            // Frm询价单结论公布sel
            // 
            this.Appearance.BackColor = System.Drawing.SystemColors.Control;
            this.Appearance.Options.UseBackColor = true;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(945, 399);
            this.Controls.Add(this.btnOK);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.lookUpEditcVenCode);
            this.Controls.Add(this.date2);
            this.Controls.Add(this.date1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.gridControl1);
            this.Name = "Frm询价单结论公布sel";
            this.Text = "询价单结论公布";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.Frm_Load);
            this.Controls.SetChildIndex(this.gridControl1, 0);
            this.Controls.SetChildIndex(this.label1, 0);
            this.Controls.SetChildIndex(this.date1, 0);
            this.Controls.SetChildIndex(this.date2, 0);
            this.Controls.SetChildIndex(this.lookUpEditcVenCode, 0);
            this.Controls.SetChildIndex(this.label2, 0);
            this.Controls.SetChildIndex(this.btnOK, 0);
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ItemLookUpEditUser)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.date1.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.date2.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lookUpEditcVenCode.Properties)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraGrid.GridControl gridControl1;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView1;
        private DevExpress.XtraGrid.Columns.GridColumn gridCol标题;
        private DevExpress.XtraGrid.Columns.GridColumn gridCol备注;
        private System.Windows.Forms.Label label1;
        private DevExpress.XtraEditors.DateEdit date1;
        private DevExpress.XtraEditors.DateEdit date2;
        private DevExpress.XtraGrid.Columns.GridColumn gridCol制单人;
        private DevExpress.XtraGrid.Columns.GridColumn gridCol制单日期;
        private DevExpress.XtraGrid.Columns.GridColumn gridCol发布人;
        private DevExpress.XtraGrid.Columns.GridColumn gridCol发布日期;
        private DevExpress.XtraGrid.Columns.GridColumn gridColGUID;
        private DevExpress.XtraGrid.Columns.GridColumn gridCol供应商编码;
        private DevExpress.XtraGrid.Columns.GridColumn gridCol供应商名称;
        private DevExpress.XtraGrid.Columns.GridColumn gridCol截止日期;
        private DevExpress.XtraGrid.Columns.GridColumn gridCol单据日期;
        private DevExpress.XtraEditors.LookUpEdit lookUpEditcVenCode;
        private System.Windows.Forms.Label label2;
        private DevExpress.XtraGrid.Columns.GridColumn gridCol终止询价日期;
        private DevExpress.XtraGrid.Columns.GridColumn gridCol终止人;
        private DevExpress.XtraGrid.Columns.GridColumn gridCol审批结论;
        private DevExpress.XtraGrid.Columns.GridColumn gridCol审批时间;
        private DevExpress.XtraGrid.Columns.GridColumn gridCol审批人;
        private System.Windows.Forms.Button btnOK;
        private DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit ItemLookUpEditUser;
    }
}