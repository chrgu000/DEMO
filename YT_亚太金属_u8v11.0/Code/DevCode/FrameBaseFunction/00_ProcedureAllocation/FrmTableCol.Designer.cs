namespace FrameBaseFunction
{
    partial class FrmTableCol
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
            this.gridControl1 = new DevExpress.XtraGrid.GridControl();
            this.gridView1 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.gridColiID = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColTABLE_CATALOG = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColTABLE_SCHEMA = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColTABLE_NAME = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColCOLUMN_NAME = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColCOLUMN_Text = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColDATA_Type2 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColDataType = new DevExpress.XtraGrid.Columns.GridColumn();
            this.LookUpEditDataType = new DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit();
            this.gridColcollation_add = new DevExpress.XtraGrid.Columns.GridColumn();
            this.LookUpEditSQLAdd = new DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit();
            this.gridColnewAdd = new DevExpress.XtraGrid.Columns.GridColumn();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.lookUpEditDataBase = new DevExpress.XtraEditors.LookUpEdit();
            this.lookUpEditTable = new DevExpress.XtraEditors.LookUpEdit();
            this.chkSystem = new DevExpress.XtraEditors.CheckEdit();
            this.gridColbKey = new DevExpress.XtraGrid.Columns.GridColumn();
            this.LookUpEditbKey = new DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit();
            ((System.ComponentModel.ISupportInitialize)(this.dsForm)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtSel)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.LookUpEditDataType)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.LookUpEditSQLAdd)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lookUpEditDataBase.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lookUpEditTable.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkSystem.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.LookUpEditbKey)).BeginInit();
            this.SuspendLayout();
            // 
            // gridControl1
            // 
            this.gridControl1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.gridControl1.Location = new System.Drawing.Point(0, 87);
            this.gridControl1.MainView = this.gridView1;
            this.gridControl1.Name = "gridControl1";
            this.gridControl1.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.LookUpEditDataType,
            this.LookUpEditSQLAdd,
            this.LookUpEditbKey});
            this.gridControl1.Size = new System.Drawing.Size(980, 335);
            this.gridControl1.TabIndex = 23;
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
            this.gridColTABLE_CATALOG,
            this.gridColTABLE_SCHEMA,
            this.gridColTABLE_NAME,
            this.gridColCOLUMN_NAME,
            this.gridColCOLUMN_Text,
            this.gridColDATA_Type2,
            this.gridColDataType,
            this.gridColcollation_add,
            this.gridColnewAdd,
            this.gridColbKey});
            this.gridView1.GridControl = this.gridControl1;
            this.gridView1.Name = "gridView1";
            this.gridView1.OptionsCustomization.AllowFilter = false;
            this.gridView1.OptionsCustomization.AllowSort = false;
            this.gridView1.OptionsView.ColumnAutoWidth = false;
            this.gridView1.OptionsView.EnableAppearanceEvenRow = true;
            this.gridView1.OptionsView.EnableAppearanceOddRow = true;
            this.gridView1.OptionsView.ShowGroupPanel = false;
            this.gridView1.RowCellStyle += new DevExpress.XtraGrid.Views.Grid.RowCellStyleEventHandler(this.gridView1_RowCellStyle);
            // 
            // gridColiID
            // 
            this.gridColiID.AppearanceCell.Options.UseTextOptions = true;
            this.gridColiID.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near;
            this.gridColiID.Caption = "iID";
            this.gridColiID.FieldName = "iID";
            this.gridColiID.Name = "gridColiID";
            this.gridColiID.OptionsColumn.AllowEdit = false;
            // 
            // gridColTABLE_CATALOG
            // 
            this.gridColTABLE_CATALOG.AppearanceCell.Options.UseTextOptions = true;
            this.gridColTABLE_CATALOG.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near;
            this.gridColTABLE_CATALOG.Caption = "数据库名称";
            this.gridColTABLE_CATALOG.FieldName = "TABLE_CATALOG";
            this.gridColTABLE_CATALOG.Name = "gridColTABLE_CATALOG";
            this.gridColTABLE_CATALOG.OptionsColumn.AllowEdit = false;
            this.gridColTABLE_CATALOG.Visible = true;
            this.gridColTABLE_CATALOG.VisibleIndex = 0;
            this.gridColTABLE_CATALOG.Width = 111;
            // 
            // gridColTABLE_SCHEMA
            // 
            this.gridColTABLE_SCHEMA.AppearanceCell.Options.UseTextOptions = true;
            this.gridColTABLE_SCHEMA.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near;
            this.gridColTABLE_SCHEMA.Caption = "表所有者";
            this.gridColTABLE_SCHEMA.FieldName = "TABLE_SCHEMA";
            this.gridColTABLE_SCHEMA.Name = "gridColTABLE_SCHEMA";
            this.gridColTABLE_SCHEMA.OptionsColumn.AllowEdit = false;
            // 
            // gridColTABLE_NAME
            // 
            this.gridColTABLE_NAME.AppearanceCell.Options.UseTextOptions = true;
            this.gridColTABLE_NAME.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near;
            this.gridColTABLE_NAME.Caption = "表名";
            this.gridColTABLE_NAME.FieldName = "TABLE_NAME";
            this.gridColTABLE_NAME.Name = "gridColTABLE_NAME";
            this.gridColTABLE_NAME.OptionsColumn.AllowEdit = false;
            this.gridColTABLE_NAME.Visible = true;
            this.gridColTABLE_NAME.VisibleIndex = 1;
            this.gridColTABLE_NAME.Width = 121;
            // 
            // gridColCOLUMN_NAME
            // 
            this.gridColCOLUMN_NAME.AppearanceCell.Options.UseTextOptions = true;
            this.gridColCOLUMN_NAME.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near;
            this.gridColCOLUMN_NAME.Caption = "列名";
            this.gridColCOLUMN_NAME.FieldName = "COLUMN_NAME";
            this.gridColCOLUMN_NAME.Name = "gridColCOLUMN_NAME";
            this.gridColCOLUMN_NAME.OptionsColumn.AllowEdit = false;
            this.gridColCOLUMN_NAME.Visible = true;
            this.gridColCOLUMN_NAME.VisibleIndex = 2;
            this.gridColCOLUMN_NAME.Width = 180;
            // 
            // gridColCOLUMN_Text
            // 
            this.gridColCOLUMN_Text.AppearanceCell.Options.UseTextOptions = true;
            this.gridColCOLUMN_Text.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near;
            this.gridColCOLUMN_Text.Caption = "列标题";
            this.gridColCOLUMN_Text.FieldName = "COLUMN_Text";
            this.gridColCOLUMN_Text.Name = "gridColCOLUMN_Text";
            this.gridColCOLUMN_Text.Visible = true;
            this.gridColCOLUMN_Text.VisibleIndex = 3;
            this.gridColCOLUMN_Text.Width = 182;
            // 
            // gridColDATA_Type2
            // 
            this.gridColDATA_Type2.Caption = "数据库数据类型";
            this.gridColDATA_Type2.FieldName = "DATA_Type2";
            this.gridColDATA_Type2.Name = "gridColDATA_Type2";
            this.gridColDATA_Type2.OptionsColumn.AllowEdit = false;
            this.gridColDATA_Type2.Visible = true;
            this.gridColDATA_Type2.VisibleIndex = 4;
            this.gridColDATA_Type2.Width = 101;
            // 
            // gridColDataType
            // 
            this.gridColDataType.AppearanceCell.Options.UseTextOptions = true;
            this.gridColDataType.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near;
            this.gridColDataType.Caption = "数据类型";
            this.gridColDataType.ColumnEdit = this.LookUpEditDataType;
            this.gridColDataType.FieldName = "DataType";
            this.gridColDataType.Name = "gridColDataType";
            this.gridColDataType.Visible = true;
            this.gridColDataType.VisibleIndex = 5;
            this.gridColDataType.Width = 69;
            // 
            // LookUpEditDataType
            // 
            this.LookUpEditDataType.AutoHeight = false;
            this.LookUpEditDataType.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.LookUpEditDataType.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("iID", 100, "编号"),
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("iText", 200, "说明")});
            this.LookUpEditDataType.DisplayMember = "iID";
            this.LookUpEditDataType.Name = "LookUpEditDataType";
            this.LookUpEditDataType.NullText = "";
            this.LookUpEditDataType.PopupWidth = 300;
            this.LookUpEditDataType.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.Standard;
            this.LookUpEditDataType.ValueMember = "iID";
            // 
            // gridColcollation_add
            // 
            this.gridColcollation_add.AppearanceCell.Options.UseTextOptions = true;
            this.gridColcollation_add.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near;
            this.gridColcollation_add.Caption = "是否SQL_ADD使用";
            this.gridColcollation_add.ColumnEdit = this.LookUpEditSQLAdd;
            this.gridColcollation_add.FieldName = "collation_add";
            this.gridColcollation_add.Name = "gridColcollation_add";
            this.gridColcollation_add.Visible = true;
            this.gridColcollation_add.VisibleIndex = 6;
            this.gridColcollation_add.Width = 137;
            // 
            // LookUpEditSQLAdd
            // 
            this.LookUpEditSQLAdd.AutoHeight = false;
            this.LookUpEditSQLAdd.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.LookUpEditSQLAdd.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("iID", 100, "编号"),
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("iText", 200, "说明")});
            this.LookUpEditSQLAdd.DisplayMember = "iID";
            this.LookUpEditSQLAdd.Name = "LookUpEditSQLAdd";
            this.LookUpEditSQLAdd.NullText = "";
            this.LookUpEditSQLAdd.PopupWidth = 300;
            this.LookUpEditSQLAdd.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.Standard;
            this.LookUpEditSQLAdd.ValueMember = "iID";
            // 
            // gridColnewAdd
            // 
            this.gridColnewAdd.AppearanceCell.Options.UseTextOptions = true;
            this.gridColnewAdd.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near;
            this.gridColnewAdd.Caption = "新增列";
            this.gridColnewAdd.FieldName = "newAdd";
            this.gridColnewAdd.Name = "gridColnewAdd";
            this.gridColnewAdd.OptionsColumn.AllowEdit = false;
            this.gridColnewAdd.Visible = true;
            this.gridColnewAdd.VisibleIndex = 7;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(14, 47);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(67, 14);
            this.label1.TabIndex = 24;
            this.label1.Text = "数据库名称";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(384, 47);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(67, 14);
            this.label2.TabIndex = 26;
            this.label2.Text = "数据表名称";
            // 
            // lookUpEditDataBase
            // 
            this.lookUpEditDataBase.Location = new System.Drawing.Point(99, 43);
            this.lookUpEditDataBase.Name = "lookUpEditDataBase";
            this.lookUpEditDataBase.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.lookUpEditDataBase.Properties.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("Name", "数据库名称")});
            this.lookUpEditDataBase.Properties.DisplayMember = "Name";
            this.lookUpEditDataBase.Properties.NullText = "";
            this.lookUpEditDataBase.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.Standard;
            this.lookUpEditDataBase.Properties.ValueMember = "Name";
            this.lookUpEditDataBase.Size = new System.Drawing.Size(278, 21);
            this.lookUpEditDataBase.TabIndex = 27;
            this.lookUpEditDataBase.EditValueChanged += new System.EventHandler(this.lookUpEditDataBase_EditValueChanged);
            // 
            // lookUpEditTable
            // 
            this.lookUpEditTable.Location = new System.Drawing.Point(469, 43);
            this.lookUpEditTable.Name = "lookUpEditTable";
            this.lookUpEditTable.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.lookUpEditTable.Properties.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("Name", "数据表名称")});
            this.lookUpEditTable.Properties.DisplayMember = "Name";
            this.lookUpEditTable.Properties.NullText = "";
            this.lookUpEditTable.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.Standard;
            this.lookUpEditTable.Properties.ValueMember = "Name";
            this.lookUpEditTable.Size = new System.Drawing.Size(278, 21);
            this.lookUpEditTable.TabIndex = 27;
            this.lookUpEditTable.EditValueChanged += new System.EventHandler(this.lookUpEditTable_EditValueChanged);
            // 
            // chkSystem
            // 
            this.chkSystem.Location = new System.Drawing.Point(812, 45);
            this.chkSystem.Name = "chkSystem";
            this.chkSystem.Properties.Caption = "系统";
            this.chkSystem.Size = new System.Drawing.Size(75, 19);
            this.chkSystem.TabIndex = 28;
            // 
            // gridColbKey
            // 
            this.gridColbKey.Caption = "是否主键";
            this.gridColbKey.ColumnEdit = this.LookUpEditbKey;
            this.gridColbKey.FieldName = "bKey";
            this.gridColbKey.Name = "gridColbKey";
            this.gridColbKey.Visible = true;
            this.gridColbKey.VisibleIndex = 8;
            // 
            // LookUpEditbKey
            // 
            this.LookUpEditbKey.AutoHeight = false;
            this.LookUpEditbKey.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.LookUpEditbKey.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("iID", "编码"),
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("iText", "内容")});
            this.LookUpEditbKey.DisplayMember = "iText";
            this.LookUpEditbKey.Name = "LookUpEditbKey";
            this.LookUpEditbKey.NullText = "";
            this.LookUpEditbKey.ValueMember = "iID";
            // 
            // FrmTableCol
            // 
            this.Appearance.BackColor = System.Drawing.SystemColors.Control;
            this.Appearance.Options.UseBackColor = true;
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(980, 423);
            this.Controls.Add(this.chkSystem);
            this.Controls.Add(this.lookUpEditTable);
            this.Controls.Add(this.lookUpEditDataBase);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.gridControl1);
            this.Name = "FrmTableCol";
            this.Text = "FrmTableCol";
            this.Load += new System.EventHandler(this.FrmTableCol_Load);
            this.Controls.SetChildIndex(this.gridControl1, 0);
            this.Controls.SetChildIndex(this.label1, 0);
            this.Controls.SetChildIndex(this.label2, 0);
            this.Controls.SetChildIndex(this.lookUpEditDataBase, 0);
            this.Controls.SetChildIndex(this.lookUpEditTable, 0);
            this.Controls.SetChildIndex(this.chkSystem, 0);
            ((System.ComponentModel.ISupportInitialize)(this.dsForm)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtSel)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.LookUpEditDataType)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.LookUpEditSQLAdd)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lookUpEditDataBase.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lookUpEditTable.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkSystem.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.LookUpEditbKey)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraGrid.GridControl gridControl1;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView1;
        private DevExpress.XtraGrid.Columns.GridColumn gridColiID;
        private DevExpress.XtraGrid.Columns.GridColumn gridColTABLE_CATALOG;
        private DevExpress.XtraGrid.Columns.GridColumn gridColTABLE_SCHEMA;
        private DevExpress.XtraGrid.Columns.GridColumn gridColTABLE_NAME;
        private DevExpress.XtraGrid.Columns.GridColumn gridColCOLUMN_NAME;
        private DevExpress.XtraGrid.Columns.GridColumn gridColCOLUMN_Text;
        private DevExpress.XtraGrid.Columns.GridColumn gridColDataType;
        private DevExpress.XtraGrid.Columns.GridColumn gridColcollation_add;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private DevExpress.XtraEditors.LookUpEdit lookUpEditDataBase;
        private DevExpress.XtraEditors.LookUpEdit lookUpEditTable;
        private DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit LookUpEditDataType;
        private DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit LookUpEditSQLAdd;
        private DevExpress.XtraGrid.Columns.GridColumn gridColnewAdd;
        private DevExpress.XtraGrid.Columns.GridColumn gridColDATA_Type2;
        private DevExpress.XtraEditors.CheckEdit chkSystem;
        private DevExpress.XtraGrid.Columns.GridColumn gridColbKey;
        private DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit LookUpEditbKey;
    }
}