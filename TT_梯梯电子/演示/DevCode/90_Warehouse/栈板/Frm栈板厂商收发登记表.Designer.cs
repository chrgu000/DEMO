namespace Warehouse
{
    partial class Frm栈板厂商收发登记表
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
            this.gridCol选择 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridCol厂商编码 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.ItemLookUpEditVenCode = new DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit();
            this.gridCol厂商 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.ItemLookUpEditVenName = new DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit();
            this.gridCol单据类型 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.ItemLookUpEdit单据类型 = new DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit();
            this.gridCol栈板1 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridCol栈板2 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridCol栈板3 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridCol栈板4 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridCol栈板5 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridCol栈板6 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridCol栈板7 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridCol栈板8 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridCol栈板9 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridCol栈板10 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridCol日期 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridCol备注 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridCol制单人 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridCol制单日期 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridCol审核人 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridCol审核日期 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColiID = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridCol收发 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.ItemLookUpEdit收发 = new DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit();
            this.gridCol确认人 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridCol确认日期 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridCol单据号 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.label1 = new System.Windows.Forms.Label();
            this.txtVenName = new DevExpress.XtraEditors.TextEdit();
            this.txtVenCode = new DevExpress.XtraEditors.ButtonEdit();
            this.dateEdit1 = new DevExpress.XtraEditors.DateEdit();
            this.label2 = new System.Windows.Forms.Label();
            this.dateEdit2 = new DevExpress.XtraEditors.DateEdit();
            this.chk全选 = new System.Windows.Forms.CheckBox();
            this.label3 = new System.Windows.Forms.Label();
            this.chk0 = new System.Windows.Forms.CheckBox();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ItemLookUpEditVenCode)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ItemLookUpEditVenName)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ItemLookUpEdit单据类型)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ItemLookUpEdit收发)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtVenName.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtVenCode.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dateEdit1.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dateEdit2.Properties)).BeginInit();
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
            this.gridControl1.Location = new System.Drawing.Point(0, 141);
            this.gridControl1.MainView = this.gridView1;
            this.gridControl1.Name = "gridControl1";
            this.gridControl1.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.ItemLookUpEdit单据类型,
            this.ItemLookUpEdit收发,
            this.ItemLookUpEditVenCode,
            this.ItemLookUpEditVenName});
            this.gridControl1.Size = new System.Drawing.Size(726, 210);
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
            this.gridCol选择,
            this.gridCol厂商编码,
            this.gridCol厂商,
            this.gridCol单据类型,
            this.gridCol栈板1,
            this.gridCol栈板2,
            this.gridCol栈板3,
            this.gridCol栈板4,
            this.gridCol栈板5,
            this.gridCol栈板6,
            this.gridCol栈板7,
            this.gridCol栈板8,
            this.gridCol栈板9,
            this.gridCol栈板10,
            this.gridCol日期,
            this.gridCol备注,
            this.gridCol制单人,
            this.gridCol制单日期,
            this.gridCol审核人,
            this.gridCol审核日期,
            this.gridColiID,
            this.gridCol收发,
            this.gridCol确认人,
            this.gridCol确认日期,
            this.gridCol单据号});
            this.gridView1.CustomizationFormBounds = new System.Drawing.Rectangle(1702, 792, 208, 175);
            this.gridView1.GridControl = this.gridControl1;
            this.gridView1.IndicatorWidth = 40;
            this.gridView1.Name = "gridView1";
            this.gridView1.OptionsCustomization.AllowSort = false;
            this.gridView1.OptionsView.ColumnAutoWidth = false;
            this.gridView1.OptionsView.EnableAppearanceEvenRow = true;
            this.gridView1.OptionsView.EnableAppearanceOddRow = true;
            this.gridView1.OptionsView.ShowFooter = true;
            this.gridView1.OptionsView.ShowGroupPanel = false;
            this.gridView1.FocusedRowChanged += new DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventHandler(this.gridView1_FocusedRowChanged);
            this.gridView1.CellValueChanged += new DevExpress.XtraGrid.Views.Base.CellValueChangedEventHandler(this.gridView1_CellValueChanged);
            this.gridView1.CustomDrawRowIndicator += new DevExpress.XtraGrid.Views.Grid.RowIndicatorCustomDrawEventHandler(this.gridView1_CustomDrawRowIndicator);
            // 
            // gridCol选择
            // 
            this.gridCol选择.Caption = "选择";
            this.gridCol选择.FieldName = "选择";
            this.gridCol选择.Name = "gridCol选择";
            this.gridCol选择.Visible = true;
            this.gridCol选择.VisibleIndex = 0;
            this.gridCol选择.Width = 34;
            // 
            // gridCol厂商编码
            // 
            this.gridCol厂商编码.Caption = "厂商编码";
            this.gridCol厂商编码.ColumnEdit = this.ItemLookUpEditVenCode;
            this.gridCol厂商编码.FieldName = "厂商编码";
            this.gridCol厂商编码.Name = "gridCol厂商编码";
            this.gridCol厂商编码.OptionsColumn.ReadOnly = true;
            this.gridCol厂商编码.Visible = true;
            this.gridCol厂商编码.VisibleIndex = 1;
            this.gridCol厂商编码.Width = 65;
            // 
            // ItemLookUpEditVenCode
            // 
            this.ItemLookUpEditVenCode.AutoHeight = false;
            this.ItemLookUpEditVenCode.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.ItemLookUpEditVenCode.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("cVenCode", "编码", 20, DevExpress.Utils.FormatType.None, "", true, DevExpress.Utils.HorzAlignment.Default, DevExpress.Data.ColumnSortOrder.None),
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("cVenName", "名称", 20, DevExpress.Utils.FormatType.None, "", true, DevExpress.Utils.HorzAlignment.Default, DevExpress.Data.ColumnSortOrder.None)});
            this.ItemLookUpEditVenCode.DisplayMember = "cVenCode";
            this.ItemLookUpEditVenCode.Name = "ItemLookUpEditVenCode";
            this.ItemLookUpEditVenCode.NullText = "";
            this.ItemLookUpEditVenCode.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.Standard;
            this.ItemLookUpEditVenCode.ValueMember = "cVenCode";
            // 
            // gridCol厂商
            // 
            this.gridCol厂商.Caption = "厂商";
            this.gridCol厂商.ColumnEdit = this.ItemLookUpEditVenName;
            this.gridCol厂商.FieldName = "厂商编码";
            this.gridCol厂商.Name = "gridCol厂商";
            this.gridCol厂商.OptionsColumn.ReadOnly = true;
            this.gridCol厂商.Visible = true;
            this.gridCol厂商.VisibleIndex = 2;
            this.gridCol厂商.Width = 167;
            // 
            // ItemLookUpEditVenName
            // 
            this.ItemLookUpEditVenName.AutoHeight = false;
            this.ItemLookUpEditVenName.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.ItemLookUpEditVenName.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("cVenCode", "编码", 20, DevExpress.Utils.FormatType.None, "", true, DevExpress.Utils.HorzAlignment.Default, DevExpress.Data.ColumnSortOrder.None),
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("cVenName", "名称", 20, DevExpress.Utils.FormatType.None, "", true, DevExpress.Utils.HorzAlignment.Default, DevExpress.Data.ColumnSortOrder.None)});
            this.ItemLookUpEditVenName.DisplayMember = "cVenName";
            this.ItemLookUpEditVenName.Name = "ItemLookUpEditVenName";
            this.ItemLookUpEditVenName.NullText = "";
            this.ItemLookUpEditVenName.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.Standard;
            this.ItemLookUpEditVenName.ValueMember = "cVenCode";
            // 
            // gridCol单据类型
            // 
            this.gridCol单据类型.Caption = "单据类型";
            this.gridCol单据类型.ColumnEdit = this.ItemLookUpEdit单据类型;
            this.gridCol单据类型.FieldName = "单据类型";
            this.gridCol单据类型.Name = "gridCol单据类型";
            this.gridCol单据类型.OptionsColumn.ReadOnly = true;
            this.gridCol单据类型.Visible = true;
            this.gridCol单据类型.VisibleIndex = 3;
            // 
            // ItemLookUpEdit单据类型
            // 
            this.ItemLookUpEdit单据类型.AutoHeight = false;
            this.ItemLookUpEdit单据类型.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.ItemLookUpEdit单据类型.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("单据类型", "单据类型", 20, DevExpress.Utils.FormatType.None, "", true, DevExpress.Utils.HorzAlignment.Default, DevExpress.Data.ColumnSortOrder.None)});
            this.ItemLookUpEdit单据类型.DisplayMember = "单据类型";
            this.ItemLookUpEdit单据类型.Name = "ItemLookUpEdit单据类型";
            this.ItemLookUpEdit单据类型.NullText = "";
            this.ItemLookUpEdit单据类型.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.Standard;
            this.ItemLookUpEdit单据类型.ValueMember = "单据类型";
            // 
            // gridCol栈板1
            // 
            this.gridCol栈板1.Caption = "栈板1";
            this.gridCol栈板1.FieldName = "栈板1";
            this.gridCol栈板1.Name = "gridCol栈板1";
            this.gridCol栈板1.OptionsColumn.ReadOnly = true;
            this.gridCol栈板1.SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Sum;
            this.gridCol栈板1.Visible = true;
            this.gridCol栈板1.VisibleIndex = 5;
            // 
            // gridCol栈板2
            // 
            this.gridCol栈板2.Caption = "栈板2";
            this.gridCol栈板2.FieldName = "栈板2";
            this.gridCol栈板2.Name = "gridCol栈板2";
            this.gridCol栈板2.OptionsColumn.ReadOnly = true;
            this.gridCol栈板2.SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Sum;
            this.gridCol栈板2.Visible = true;
            this.gridCol栈板2.VisibleIndex = 6;
            // 
            // gridCol栈板3
            // 
            this.gridCol栈板3.Caption = "栈板3";
            this.gridCol栈板3.FieldName = "栈板3";
            this.gridCol栈板3.Name = "gridCol栈板3";
            this.gridCol栈板3.OptionsColumn.ReadOnly = true;
            this.gridCol栈板3.SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Sum;
            this.gridCol栈板3.Visible = true;
            this.gridCol栈板3.VisibleIndex = 7;
            // 
            // gridCol栈板4
            // 
            this.gridCol栈板4.Caption = "栈板4";
            this.gridCol栈板4.FieldName = "栈板4";
            this.gridCol栈板4.Name = "gridCol栈板4";
            this.gridCol栈板4.OptionsColumn.ReadOnly = true;
            this.gridCol栈板4.SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Sum;
            this.gridCol栈板4.Visible = true;
            this.gridCol栈板4.VisibleIndex = 8;
            // 
            // gridCol栈板5
            // 
            this.gridCol栈板5.Caption = "栈板5";
            this.gridCol栈板5.FieldName = "栈板5";
            this.gridCol栈板5.Name = "gridCol栈板5";
            this.gridCol栈板5.OptionsColumn.ReadOnly = true;
            this.gridCol栈板5.SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Sum;
            this.gridCol栈板5.Visible = true;
            this.gridCol栈板5.VisibleIndex = 9;
            // 
            // gridCol栈板6
            // 
            this.gridCol栈板6.Caption = "栈板6";
            this.gridCol栈板6.FieldName = "栈板6";
            this.gridCol栈板6.Name = "gridCol栈板6";
            this.gridCol栈板6.OptionsColumn.ReadOnly = true;
            this.gridCol栈板6.SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Sum;
            this.gridCol栈板6.Visible = true;
            this.gridCol栈板6.VisibleIndex = 10;
            // 
            // gridCol栈板7
            // 
            this.gridCol栈板7.Caption = "栈板7";
            this.gridCol栈板7.FieldName = "栈板7";
            this.gridCol栈板7.Name = "gridCol栈板7";
            this.gridCol栈板7.OptionsColumn.ReadOnly = true;
            this.gridCol栈板7.SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Sum;
            this.gridCol栈板7.Visible = true;
            this.gridCol栈板7.VisibleIndex = 11;
            // 
            // gridCol栈板8
            // 
            this.gridCol栈板8.Caption = "栈板8";
            this.gridCol栈板8.FieldName = "栈板8";
            this.gridCol栈板8.Name = "gridCol栈板8";
            this.gridCol栈板8.OptionsColumn.ReadOnly = true;
            this.gridCol栈板8.SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Sum;
            this.gridCol栈板8.Visible = true;
            this.gridCol栈板8.VisibleIndex = 12;
            // 
            // gridCol栈板9
            // 
            this.gridCol栈板9.Caption = "栈板9";
            this.gridCol栈板9.FieldName = "栈板9";
            this.gridCol栈板9.Name = "gridCol栈板9";
            this.gridCol栈板9.OptionsColumn.ReadOnly = true;
            this.gridCol栈板9.SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Sum;
            this.gridCol栈板9.Visible = true;
            this.gridCol栈板9.VisibleIndex = 13;
            // 
            // gridCol栈板10
            // 
            this.gridCol栈板10.Caption = "栈板10";
            this.gridCol栈板10.FieldName = "栈板10";
            this.gridCol栈板10.Name = "gridCol栈板10";
            this.gridCol栈板10.OptionsColumn.ReadOnly = true;
            this.gridCol栈板10.SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Sum;
            this.gridCol栈板10.Visible = true;
            this.gridCol栈板10.VisibleIndex = 14;
            // 
            // gridCol日期
            // 
            this.gridCol日期.Caption = "日期";
            this.gridCol日期.FieldName = "日期";
            this.gridCol日期.Name = "gridCol日期";
            this.gridCol日期.OptionsColumn.ReadOnly = true;
            this.gridCol日期.Width = 57;
            // 
            // gridCol备注
            // 
            this.gridCol备注.Caption = "备注";
            this.gridCol备注.FieldName = "备注";
            this.gridCol备注.Name = "gridCol备注";
            this.gridCol备注.OptionsColumn.ReadOnly = true;
            this.gridCol备注.Visible = true;
            this.gridCol备注.VisibleIndex = 15;
            // 
            // gridCol制单人
            // 
            this.gridCol制单人.Caption = "制单人";
            this.gridCol制单人.FieldName = "制单人";
            this.gridCol制单人.Name = "gridCol制单人";
            this.gridCol制单人.OptionsColumn.ReadOnly = true;
            this.gridCol制单人.Visible = true;
            this.gridCol制单人.VisibleIndex = 16;
            // 
            // gridCol制单日期
            // 
            this.gridCol制单日期.Caption = "制单日期";
            this.gridCol制单日期.FieldName = "制单日期";
            this.gridCol制单日期.Name = "gridCol制单日期";
            this.gridCol制单日期.OptionsColumn.ReadOnly = true;
            this.gridCol制单日期.Visible = true;
            this.gridCol制单日期.VisibleIndex = 17;
            // 
            // gridCol审核人
            // 
            this.gridCol审核人.Caption = "审核人";
            this.gridCol审核人.FieldName = "审核人";
            this.gridCol审核人.Name = "gridCol审核人";
            this.gridCol审核人.OptionsColumn.ReadOnly = true;
            this.gridCol审核人.Visible = true;
            this.gridCol审核人.VisibleIndex = 18;
            // 
            // gridCol审核日期
            // 
            this.gridCol审核日期.Caption = "审核日期";
            this.gridCol审核日期.FieldName = "审核日期";
            this.gridCol审核日期.Name = "gridCol审核日期";
            this.gridCol审核日期.OptionsColumn.ReadOnly = true;
            this.gridCol审核日期.Visible = true;
            this.gridCol审核日期.VisibleIndex = 19;
            // 
            // gridColiID
            // 
            this.gridColiID.Caption = "iID";
            this.gridColiID.FieldName = "iID";
            this.gridColiID.Name = "gridColiID";
            this.gridColiID.OptionsColumn.ReadOnly = true;
            // 
            // gridCol收发
            // 
            this.gridCol收发.Caption = "收发";
            this.gridCol收发.ColumnEdit = this.ItemLookUpEdit收发;
            this.gridCol收发.FieldName = "收发";
            this.gridCol收发.Name = "gridCol收发";
            this.gridCol收发.OptionsColumn.ReadOnly = true;
            // 
            // ItemLookUpEdit收发
            // 
            this.ItemLookUpEdit收发.AutoHeight = false;
            this.ItemLookUpEdit收发.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.ItemLookUpEdit收发.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("编码", "编码", 20, DevExpress.Utils.FormatType.None, "", true, DevExpress.Utils.HorzAlignment.Default, DevExpress.Data.ColumnSortOrder.None),
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("类型", "类型", 20, DevExpress.Utils.FormatType.None, "", true, DevExpress.Utils.HorzAlignment.Default, DevExpress.Data.ColumnSortOrder.None)});
            this.ItemLookUpEdit收发.DisplayMember = "类型";
            this.ItemLookUpEdit收发.Name = "ItemLookUpEdit收发";
            this.ItemLookUpEdit收发.NullText = "";
            this.ItemLookUpEdit收发.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.Standard;
            this.ItemLookUpEdit收发.ValueMember = "类型";
            // 
            // gridCol确认人
            // 
            this.gridCol确认人.Caption = "确认人";
            this.gridCol确认人.FieldName = "确认人";
            this.gridCol确认人.Name = "gridCol确认人";
            this.gridCol确认人.OptionsColumn.ReadOnly = true;
            this.gridCol确认人.Visible = true;
            this.gridCol确认人.VisibleIndex = 20;
            // 
            // gridCol确认日期
            // 
            this.gridCol确认日期.Caption = "确认日期";
            this.gridCol确认日期.FieldName = "确认日期";
            this.gridCol确认日期.Name = "gridCol确认日期";
            this.gridCol确认日期.OptionsColumn.ReadOnly = true;
            this.gridCol确认日期.Visible = true;
            this.gridCol确认日期.VisibleIndex = 21;
            // 
            // gridCol单据号
            // 
            this.gridCol单据号.Caption = "单据号";
            this.gridCol单据号.FieldName = "单据号";
            this.gridCol单据号.Name = "gridCol单据号";
            this.gridCol单据号.Visible = true;
            this.gridCol单据号.VisibleIndex = 4;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 45);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(43, 14);
            this.label1.TabIndex = 24;
            this.label1.Text = "供应商";
            // 
            // txtVenName
            // 
            this.txtVenName.Enabled = false;
            this.txtVenName.Location = new System.Drawing.Point(177, 42);
            this.txtVenName.Name = "txtVenName";
            this.txtVenName.Properties.ReadOnly = true;
            this.txtVenName.Size = new System.Drawing.Size(269, 21);
            this.txtVenName.TabIndex = 67;
            // 
            // txtVenCode
            // 
            this.txtVenCode.EnterMoveNextControl = true;
            this.txtVenCode.Location = new System.Drawing.Point(70, 42);
            this.txtVenCode.Name = "txtVenCode";
            this.txtVenCode.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
            this.txtVenCode.Size = new System.Drawing.Size(101, 21);
            this.txtVenCode.TabIndex = 66;
            this.txtVenCode.ButtonClick += new DevExpress.XtraEditors.Controls.ButtonPressedEventHandler(this.txtVenCode_ButtonClick);
            this.txtVenCode.Leave += new System.EventHandler(this.txtVenCode_Leave);
            // 
            // dateEdit1
            // 
            this.dateEdit1.EditValue = new System.DateTime(2011, 10, 24, 0, 0, 0, 0);
            this.dateEdit1.Location = new System.Drawing.Point(70, 69);
            this.dateEdit1.Name = "dateEdit1";
            this.dateEdit1.Properties.Appearance.BackColor = System.Drawing.Color.WhiteSmoke;
            this.dateEdit1.Properties.Appearance.Options.UseBackColor = true;
            this.dateEdit1.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.dateEdit1.Size = new System.Drawing.Size(101, 21);
            this.dateEdit1.TabIndex = 78;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 72);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(55, 14);
            this.label2.TabIndex = 79;
            this.label2.Text = "单据日期";
            // 
            // dateEdit2
            // 
            this.dateEdit2.EditValue = new System.DateTime(2011, 10, 24, 0, 0, 0, 0);
            this.dateEdit2.Location = new System.Drawing.Point(177, 68);
            this.dateEdit2.Name = "dateEdit2";
            this.dateEdit2.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.dateEdit2.Size = new System.Drawing.Size(101, 21);
            this.dateEdit2.TabIndex = 80;
            // 
            // chk全选
            // 
            this.chk全选.AccessibleRole = System.Windows.Forms.AccessibleRole.None;
            this.chk全选.AutoSize = true;
            this.chk全选.Location = new System.Drawing.Point(15, 103);
            this.chk全选.Name = "chk全选";
            this.chk全选.Size = new System.Drawing.Size(50, 18);
            this.chk全选.TabIndex = 81;
            this.chk全选.Text = "全选";
            this.chk全选.UseVisualStyleBackColor = true;
            this.chk全选.CheckedChanged += new System.EventHandler(this.chk全选_CheckedChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(7, 124);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(271, 14);
            this.label3.TabIndex = 82;
            this.label3.Text = "正数表示栈板进入杜乐；负数表示栈板从杜乐发出";
            // 
            // chk0
            // 
            this.chk0.AutoSize = true;
            this.chk0.Location = new System.Drawing.Point(309, 72);
            this.chk0.Name = "chk0";
            this.chk0.Size = new System.Drawing.Size(81, 18);
            this.chk0.TabIndex = 85;
            this.chk0.Text = "包含数量0";
            this.chk0.UseVisualStyleBackColor = true;
            // 
            // Frm栈板厂商收发登记表
            // 
            this.Appearance.BackColor = System.Drawing.SystemColors.Control;
            this.Appearance.Options.UseBackColor = true;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(726, 354);
            this.Controls.Add(this.chk0);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.chk全选);
            this.Controls.Add(this.dateEdit2);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.dateEdit1);
            this.Controls.Add(this.txtVenName);
            this.Controls.Add(this.txtVenCode);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.gridControl1);
            this.Name = "Frm栈板厂商收发登记表";
            this.Text = "栈板厂商收发登记表";
            this.Load += new System.EventHandler(this.Frm栈板厂商收发登记表_Load);
            this.Controls.SetChildIndex(this.gridControl1, 0);
            this.Controls.SetChildIndex(this.label1, 0);
            this.Controls.SetChildIndex(this.txtVenCode, 0);
            this.Controls.SetChildIndex(this.txtVenName, 0);
            this.Controls.SetChildIndex(this.dateEdit1, 0);
            this.Controls.SetChildIndex(this.label2, 0);
            this.Controls.SetChildIndex(this.dateEdit2, 0);
            this.Controls.SetChildIndex(this.chk全选, 0);
            this.Controls.SetChildIndex(this.label3, 0);
            this.Controls.SetChildIndex(this.chk0, 0);
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ItemLookUpEditVenCode)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ItemLookUpEditVenName)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ItemLookUpEdit单据类型)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ItemLookUpEdit收发)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtVenName.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtVenCode.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dateEdit1.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dateEdit2.Properties)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraGrid.GridControl gridControl1;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView1;
        private System.Windows.Forms.Label label1;
        private DevExpress.XtraEditors.TextEdit txtVenName;
        private DevExpress.XtraEditors.ButtonEdit txtVenCode;
        private DevExpress.XtraEditors.DateEdit dateEdit1;
        private DevExpress.XtraGrid.Columns.GridColumn gridCol选择;
        private DevExpress.XtraGrid.Columns.GridColumn gridCol厂商编码;
        private DevExpress.XtraGrid.Columns.GridColumn gridCol厂商;
        private DevExpress.XtraGrid.Columns.GridColumn gridCol栈板1;
        private DevExpress.XtraGrid.Columns.GridColumn gridCol栈板2;
        private DevExpress.XtraGrid.Columns.GridColumn gridCol栈板3;
        private DevExpress.XtraGrid.Columns.GridColumn gridCol栈板4;
        private DevExpress.XtraGrid.Columns.GridColumn gridCol栈板5;
        private DevExpress.XtraGrid.Columns.GridColumn gridCol栈板6;
        private DevExpress.XtraGrid.Columns.GridColumn gridCol栈板7;
        private DevExpress.XtraGrid.Columns.GridColumn gridCol栈板8;
        private DevExpress.XtraGrid.Columns.GridColumn gridCol栈板9;
        private DevExpress.XtraGrid.Columns.GridColumn gridCol栈板10;
        private DevExpress.XtraGrid.Columns.GridColumn gridCol日期;
        private DevExpress.XtraGrid.Columns.GridColumn gridCol备注;
        private DevExpress.XtraGrid.Columns.GridColumn gridCol制单人;
        private DevExpress.XtraGrid.Columns.GridColumn gridCol制单日期;
        private DevExpress.XtraGrid.Columns.GridColumn gridCol审核人;
        private DevExpress.XtraGrid.Columns.GridColumn gridCol审核日期;
        private DevExpress.XtraGrid.Columns.GridColumn gridColiID;
        private DevExpress.XtraGrid.Columns.GridColumn gridCol收发;
        private DevExpress.XtraGrid.Columns.GridColumn gridCol确认人;
        private DevExpress.XtraGrid.Columns.GridColumn gridCol确认日期;
        private DevExpress.XtraGrid.Columns.GridColumn gridCol单据号;
        private System.Windows.Forms.Label label2;
        private DevExpress.XtraEditors.DateEdit dateEdit2;
        private DevExpress.XtraGrid.Columns.GridColumn gridCol单据类型;
        private DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit ItemLookUpEdit单据类型;
        private DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit ItemLookUpEdit收发;
        private DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit ItemLookUpEditVenCode;
        private DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit ItemLookUpEditVenName;
        private System.Windows.Forms.CheckBox chk全选;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.CheckBox chk0;
    }
}