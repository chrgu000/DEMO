namespace Base
{
    partial class Frm杜乐耗材供应商
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
            this.gridCol选择 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColcVenCode = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColcVenName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColcVenAbbName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColAddress = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColcVenPerson = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColcVenPhone = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColRemark1 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColRemark2 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColRemark3 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColRemark4 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColRemark5 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColRemark6 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColRemark7 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColRemark8 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColCreateUid = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColCreateDate = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColUpdateUid = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColUpdateDate = new DevExpress.XtraGrid.Columns.GridColumn();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).BeginInit();
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
            this.gridControl1.Location = new System.Drawing.Point(7, 28);
            this.gridControl1.MainView = this.gridView1;
            this.gridControl1.Name = "gridControl1";
            this.gridControl1.Size = new System.Drawing.Size(933, 368);
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
            this.gridCol选择,
            this.gridColcVenCode,
            this.gridColcVenName,
            this.gridColcVenAbbName,
            this.gridColAddress,
            this.gridColcVenPerson,
            this.gridColcVenPhone,
            this.gridColRemark1,
            this.gridColRemark2,
            this.gridColRemark3,
            this.gridColRemark4,
            this.gridColRemark5,
            this.gridColRemark6,
            this.gridColRemark7,
            this.gridColRemark8,
            this.gridColCreateUid,
            this.gridColCreateDate,
            this.gridColUpdateUid,
            this.gridColUpdateDate});
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
            this.gridView1.CustomDrawRowIndicator += new DevExpress.XtraGrid.Views.Grid.RowIndicatorCustomDrawEventHandler(this.gridView评审_CustomDrawRowIndicator);
            this.gridView1.DoubleClick += new System.EventHandler(this.gridView1_DoubleClick);
            // 
            // gridCol选择
            // 
            this.gridCol选择.Caption = "选择";
            this.gridCol选择.FieldName = "选择";
            this.gridCol选择.Name = "gridCol选择";
            this.gridCol选择.Visible = true;
            this.gridCol选择.VisibleIndex = 0;
            this.gridCol选择.Width = 44;
            // 
            // gridColcVenCode
            // 
            this.gridColcVenCode.Caption = "供应商编码";
            this.gridColcVenCode.FieldName = "cVenCode";
            this.gridColcVenCode.Name = "gridColcVenCode";
            this.gridColcVenCode.OptionsColumn.AllowEdit = false;
            this.gridColcVenCode.Visible = true;
            this.gridColcVenCode.VisibleIndex = 1;
            this.gridColcVenCode.Width = 85;
            // 
            // gridColcVenName
            // 
            this.gridColcVenName.Caption = "名称";
            this.gridColcVenName.FieldName = "cVenName";
            this.gridColcVenName.Name = "gridColcVenName";
            this.gridColcVenName.OptionsColumn.AllowEdit = false;
            this.gridColcVenName.Visible = true;
            this.gridColcVenName.VisibleIndex = 2;
            this.gridColcVenName.Width = 391;
            // 
            // gridColcVenAbbName
            // 
            this.gridColcVenAbbName.Caption = "简称";
            this.gridColcVenAbbName.FieldName = "cVenAbbName";
            this.gridColcVenAbbName.Name = "gridColcVenAbbName";
            this.gridColcVenAbbName.OptionsColumn.AllowEdit = false;
            this.gridColcVenAbbName.Visible = true;
            this.gridColcVenAbbName.VisibleIndex = 3;
            // 
            // gridColAddress
            // 
            this.gridColAddress.Caption = "地址";
            this.gridColAddress.FieldName = "Address";
            this.gridColAddress.Name = "gridColAddress";
            this.gridColAddress.OptionsColumn.AllowEdit = false;
            this.gridColAddress.Visible = true;
            this.gridColAddress.VisibleIndex = 5;
            // 
            // gridColcVenPerson
            // 
            this.gridColcVenPerson.Caption = "联系人";
            this.gridColcVenPerson.FieldName = "cVenPerson";
            this.gridColcVenPerson.Name = "gridColcVenPerson";
            this.gridColcVenPerson.OptionsColumn.AllowEdit = false;
            this.gridColcVenPerson.Visible = true;
            this.gridColcVenPerson.VisibleIndex = 4;
            // 
            // gridColcVenPhone
            // 
            this.gridColcVenPhone.Caption = "电话";
            this.gridColcVenPhone.FieldName = "cVenPhone";
            this.gridColcVenPhone.Name = "gridColcVenPhone";
            this.gridColcVenPhone.OptionsColumn.AllowEdit = false;
            this.gridColcVenPhone.Visible = true;
            this.gridColcVenPhone.VisibleIndex = 9;
            // 
            // gridColRemark1
            // 
            this.gridColRemark1.Caption = "传真";
            this.gridColRemark1.FieldName = "Remark1";
            this.gridColRemark1.Name = "gridColRemark1";
            this.gridColRemark1.OptionsColumn.AllowEdit = false;
            this.gridColRemark1.Visible = true;
            this.gridColRemark1.VisibleIndex = 6;
            // 
            // gridColRemark2
            // 
            this.gridColRemark2.Caption = "邮箱";
            this.gridColRemark2.FieldName = "Remark2";
            this.gridColRemark2.Name = "gridColRemark2";
            this.gridColRemark2.OptionsColumn.AllowEdit = false;
            this.gridColRemark2.Visible = true;
            this.gridColRemark2.VisibleIndex = 7;
            // 
            // gridColRemark3
            // 
            this.gridColRemark3.Caption = "备注";
            this.gridColRemark3.FieldName = "Remark3";
            this.gridColRemark3.Name = "gridColRemark3";
            this.gridColRemark3.OptionsColumn.AllowEdit = false;
            this.gridColRemark3.Visible = true;
            this.gridColRemark3.VisibleIndex = 8;
            // 
            // gridColRemark4
            // 
            this.gridColRemark4.Caption = "备注2";
            this.gridColRemark4.FieldName = "Remark4";
            this.gridColRemark4.Name = "gridColRemark4";
            this.gridColRemark4.OptionsColumn.AllowEdit = false;
            this.gridColRemark4.Visible = true;
            this.gridColRemark4.VisibleIndex = 10;
            // 
            // gridColRemark5
            // 
            this.gridColRemark5.Caption = "备注3";
            this.gridColRemark5.FieldName = "Remark5";
            this.gridColRemark5.Name = "gridColRemark5";
            this.gridColRemark5.OptionsColumn.AllowEdit = false;
            this.gridColRemark5.Visible = true;
            this.gridColRemark5.VisibleIndex = 11;
            // 
            // gridColRemark6
            // 
            this.gridColRemark6.Caption = "备注4";
            this.gridColRemark6.FieldName = "Remark6";
            this.gridColRemark6.Name = "gridColRemark6";
            this.gridColRemark6.OptionsColumn.AllowEdit = false;
            this.gridColRemark6.Visible = true;
            this.gridColRemark6.VisibleIndex = 12;
            // 
            // gridColRemark7
            // 
            this.gridColRemark7.Caption = "备注5";
            this.gridColRemark7.FieldName = "Remark7";
            this.gridColRemark7.Name = "gridColRemark7";
            this.gridColRemark7.OptionsColumn.AllowEdit = false;
            this.gridColRemark7.Visible = true;
            this.gridColRemark7.VisibleIndex = 13;
            // 
            // gridColRemark8
            // 
            this.gridColRemark8.Caption = "备注6";
            this.gridColRemark8.FieldName = "Remark8";
            this.gridColRemark8.Name = "gridColRemark8";
            this.gridColRemark8.OptionsColumn.AllowEdit = false;
            this.gridColRemark8.Visible = true;
            this.gridColRemark8.VisibleIndex = 14;
            // 
            // gridColCreateUid
            // 
            this.gridColCreateUid.Caption = "创建人";
            this.gridColCreateUid.FieldName = "CreateUid";
            this.gridColCreateUid.Name = "gridColCreateUid";
            this.gridColCreateUid.OptionsColumn.AllowEdit = false;
            this.gridColCreateUid.Visible = true;
            this.gridColCreateUid.VisibleIndex = 15;
            // 
            // gridColCreateDate
            // 
            this.gridColCreateDate.Caption = "创建日期";
            this.gridColCreateDate.FieldName = "CreateDate";
            this.gridColCreateDate.Name = "gridColCreateDate";
            this.gridColCreateDate.OptionsColumn.AllowEdit = false;
            this.gridColCreateDate.Visible = true;
            this.gridColCreateDate.VisibleIndex = 16;
            // 
            // gridColUpdateUid
            // 
            this.gridColUpdateUid.Caption = "修改人";
            this.gridColUpdateUid.FieldName = "UpdateUid";
            this.gridColUpdateUid.Name = "gridColUpdateUid";
            this.gridColUpdateUid.OptionsColumn.AllowEdit = false;
            this.gridColUpdateUid.Visible = true;
            this.gridColUpdateUid.VisibleIndex = 17;
            // 
            // gridColUpdateDate
            // 
            this.gridColUpdateDate.Caption = "修改日期";
            this.gridColUpdateDate.FieldName = "UpdateDate";
            this.gridColUpdateDate.Name = "gridColUpdateDate";
            this.gridColUpdateDate.OptionsColumn.AllowEdit = false;
            this.gridColUpdateDate.Visible = true;
            this.gridColUpdateDate.VisibleIndex = 18;
            // 
            // Frm杜乐耗材供应商
            // 
            this.Appearance.BackColor = System.Drawing.SystemColors.Control;
            this.Appearance.Options.UseBackColor = true;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(945, 399);
            this.Controls.Add(this.gridControl1);
            this.Name = "Frm杜乐耗材供应商";
            this.Text = "杜乐耗材供应商";
            this.Load += new System.EventHandler(this.Frm_Load);
            this.Controls.SetChildIndex(this.gridControl1, 0);
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraGrid.GridControl gridControl1;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView1;
        private DevExpress.XtraGrid.Columns.GridColumn gridColcVenCode;
        private DevExpress.XtraGrid.Columns.GridColumn gridColcVenName;
        private DevExpress.XtraGrid.Columns.GridColumn gridCol选择;
        private DevExpress.XtraGrid.Columns.GridColumn gridColcVenAbbName;
        private DevExpress.XtraGrid.Columns.GridColumn gridColAddress;
        private DevExpress.XtraGrid.Columns.GridColumn gridColcVenPerson;
        private DevExpress.XtraGrid.Columns.GridColumn gridColcVenPhone;
        private DevExpress.XtraGrid.Columns.GridColumn gridColRemark1;
        private DevExpress.XtraGrid.Columns.GridColumn gridColRemark2;
        private DevExpress.XtraGrid.Columns.GridColumn gridColRemark3;
        private DevExpress.XtraGrid.Columns.GridColumn gridColRemark4;
        private DevExpress.XtraGrid.Columns.GridColumn gridColRemark5;
        private DevExpress.XtraGrid.Columns.GridColumn gridColRemark6;
        private DevExpress.XtraGrid.Columns.GridColumn gridColRemark7;
        private DevExpress.XtraGrid.Columns.GridColumn gridColRemark8;
        private DevExpress.XtraGrid.Columns.GridColumn gridColCreateUid;
        private DevExpress.XtraGrid.Columns.GridColumn gridColUpdateUid;
        private DevExpress.XtraGrid.Columns.GridColumn gridColCreateDate;
        private DevExpress.XtraGrid.Columns.GridColumn gridColUpdateDate;
    }
}