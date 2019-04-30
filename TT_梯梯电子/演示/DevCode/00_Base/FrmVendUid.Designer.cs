namespace Base
{
    partial class FrmVendUid
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
            this.gridColvchrUid = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColvchrName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColbVend = new DevExpress.XtraGrid.Columns.GridColumn();
            this.LookUpEditbVend = new DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit();
            this.gridColcvenCode = new DevExpress.XtraGrid.Columns.GridColumn();
            this.LookUpEditVend = new DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit();
            this.gridColcVenName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColsEMail = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColPOAduditGrade = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColcDepCode = new DevExpress.XtraGrid.Columns.GridColumn();
            this.ItemButtonEditDep = new DevExpress.XtraEditors.Repository.RepositoryItemButtonEdit();
            this.gridColcDepName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.radioAll = new System.Windows.Forms.RadioButton();
            this.radioPer = new System.Windows.Forms.RadioButton();
            this.radioVen = new System.Windows.Forms.RadioButton();
            this.gridColbChoose = new DevExpress.XtraGrid.Columns.GridColumn();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.LookUpEditbVend)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.LookUpEditVend)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ItemButtonEditDep)).BeginInit();
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
            this.gridControl1.Location = new System.Drawing.Point(0, 77);
            this.gridControl1.MainView = this.gridView1;
            this.gridControl1.Name = "gridControl1";
            this.gridControl1.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.LookUpEditVend,
            this.LookUpEditbVend,
            this.ItemButtonEditDep});
            this.gridControl1.Size = new System.Drawing.Size(727, 274);
            this.gridControl1.TabIndex = 9;
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
            this.gridColvchrUid,
            this.gridColvchrName,
            this.gridColbVend,
            this.gridColcvenCode,
            this.gridColcVenName,
            this.gridColsEMail,
            this.gridColPOAduditGrade,
            this.gridColcDepCode,
            this.gridColcDepName,
            this.gridColbChoose});
            this.gridView1.GridControl = this.gridControl1;
            this.gridView1.IndicatorWidth = 40;
            this.gridView1.Name = "gridView1";
            this.gridView1.OptionsCustomization.AllowFilter = false;
            this.gridView1.OptionsView.ColumnAutoWidth = false;
            this.gridView1.OptionsView.EnableAppearanceEvenRow = true;
            this.gridView1.OptionsView.EnableAppearanceOddRow = true;
            this.gridView1.OptionsView.ShowGroupPanel = false;
            this.gridView1.CellValueChanged += new DevExpress.XtraGrid.Views.Base.CellValueChangedEventHandler(this.gridView1_CellValueChanged);
            this.gridView1.RowCellStyle += new DevExpress.XtraGrid.Views.Grid.RowCellStyleEventHandler(this.gridView1_RowCellStyle);
            this.gridView1.CustomDrawRowIndicator += new DevExpress.XtraGrid.Views.Grid.RowIndicatorCustomDrawEventHandler(this.gridView1_CustomDrawRowIndicator);
            // 
            // gridColvchrUid
            // 
            this.gridColvchrUid.AppearanceCell.Options.UseTextOptions = true;
            this.gridColvchrUid.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near;
            this.gridColvchrUid.Caption = "账号";
            this.gridColvchrUid.FieldName = "vchrUid";
            this.gridColvchrUid.Name = "gridColvchrUid";
            this.gridColvchrUid.OptionsColumn.AllowEdit = false;
            this.gridColvchrUid.Visible = true;
            this.gridColvchrUid.VisibleIndex = 0;
            this.gridColvchrUid.Width = 65;
            // 
            // gridColvchrName
            // 
            this.gridColvchrName.AppearanceCell.Options.UseTextOptions = true;
            this.gridColvchrName.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near;
            this.gridColvchrName.Caption = "名称";
            this.gridColvchrName.FieldName = "vchrName";
            this.gridColvchrName.Name = "gridColvchrName";
            this.gridColvchrName.OptionsColumn.AllowEdit = false;
            this.gridColvchrName.Visible = true;
            this.gridColvchrName.VisibleIndex = 1;
            this.gridColvchrName.Width = 97;
            // 
            // gridColbVend
            // 
            this.gridColbVend.AppearanceCell.Options.UseTextOptions = true;
            this.gridColbVend.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near;
            this.gridColbVend.Caption = "帐号类型";
            this.gridColbVend.ColumnEdit = this.LookUpEditbVend;
            this.gridColbVend.FieldName = "bVend";
            this.gridColbVend.Name = "gridColbVend";
            this.gridColbVend.Width = 113;
            // 
            // LookUpEditbVend
            // 
            this.LookUpEditbVend.AutoHeight = false;
            this.LookUpEditbVend.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.LookUpEditbVend.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("iID", "编码", 20, DevExpress.Utils.FormatType.None, "", true, DevExpress.Utils.HorzAlignment.Default, DevExpress.Data.ColumnSortOrder.None),
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("iText", "说明", 20, DevExpress.Utils.FormatType.None, "", true, DevExpress.Utils.HorzAlignment.Default, DevExpress.Data.ColumnSortOrder.None)});
            this.LookUpEditbVend.DisplayMember = "iText";
            this.LookUpEditbVend.Name = "LookUpEditbVend";
            this.LookUpEditbVend.ValueMember = "iID";
            // 
            // gridColcvenCode
            // 
            this.gridColcvenCode.AppearanceCell.Options.UseTextOptions = true;
            this.gridColcvenCode.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near;
            this.gridColcvenCode.Caption = "供应商编号";
            this.gridColcvenCode.ColumnEdit = this.LookUpEditVend;
            this.gridColcvenCode.FieldName = "cvenCode";
            this.gridColcvenCode.Name = "gridColcvenCode";
            this.gridColcvenCode.Visible = true;
            this.gridColcvenCode.VisibleIndex = 3;
            this.gridColcvenCode.Width = 112;
            // 
            // LookUpEditVend
            // 
            this.LookUpEditVend.AutoHeight = false;
            this.LookUpEditVend.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.LookUpEditVend.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("iID", "供应商编码", 100),
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("iText", "供应商名称", 500)});
            this.LookUpEditVend.DisplayMember = "iID";
            this.LookUpEditVend.Name = "LookUpEditVend";
            this.LookUpEditVend.NullText = "";
            this.LookUpEditVend.PopupFormWidth = 600;
            this.LookUpEditVend.PopupSizeable = false;
            this.LookUpEditVend.PopupWidth = 600;
            this.LookUpEditVend.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.Standard;
            this.LookUpEditVend.ValueMember = "iID";
            // 
            // gridColcVenName
            // 
            this.gridColcVenName.AppearanceCell.Options.UseTextOptions = true;
            this.gridColcVenName.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near;
            this.gridColcVenName.Caption = "供应商名称";
            this.gridColcVenName.FieldName = "cVenName";
            this.gridColcVenName.Name = "gridColcVenName";
            this.gridColcVenName.OptionsColumn.AllowEdit = false;
            this.gridColcVenName.Visible = true;
            this.gridColcVenName.VisibleIndex = 4;
            this.gridColcVenName.Width = 317;
            // 
            // gridColsEMail
            // 
            this.gridColsEMail.Caption = "eMail";
            this.gridColsEMail.FieldName = "sEMail";
            this.gridColsEMail.Name = "gridColsEMail";
            this.gridColsEMail.Visible = true;
            this.gridColsEMail.VisibleIndex = 2;
            this.gridColsEMail.Width = 148;
            // 
            // gridColPOAduditGrade
            // 
            this.gridColPOAduditGrade.Caption = "采购订单审核等级";
            this.gridColPOAduditGrade.DisplayFormat.FormatString = "n0";
            this.gridColPOAduditGrade.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.gridColPOAduditGrade.FieldName = "POAduditGrade";
            this.gridColPOAduditGrade.GroupFormat.FormatString = "n0";
            this.gridColPOAduditGrade.GroupFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.gridColPOAduditGrade.Name = "gridColPOAduditGrade";
            this.gridColPOAduditGrade.Visible = true;
            this.gridColPOAduditGrade.VisibleIndex = 5;
            this.gridColPOAduditGrade.Width = 113;
            // 
            // gridColcDepCode
            // 
            this.gridColcDepCode.Caption = "部门编号";
            this.gridColcDepCode.ColumnEdit = this.ItemButtonEditDep;
            this.gridColcDepCode.FieldName = "cDepCode";
            this.gridColcDepCode.Name = "gridColcDepCode";
            this.gridColcDepCode.Visible = true;
            this.gridColcDepCode.VisibleIndex = 6;
            this.gridColcDepCode.Width = 71;
            // 
            // ItemButtonEditDep
            // 
            this.ItemButtonEditDep.AutoHeight = false;
            this.ItemButtonEditDep.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
            this.ItemButtonEditDep.Name = "ItemButtonEditDep";
            this.ItemButtonEditDep.ButtonClick += new DevExpress.XtraEditors.Controls.ButtonPressedEventHandler(this.ItemButtonEditDep_ButtonClick);
            // 
            // gridColcDepName
            // 
            this.gridColcDepName.Caption = "部门名称";
            this.gridColcDepName.FieldName = "cDepName";
            this.gridColcDepName.Name = "gridColcDepName";
            this.gridColcDepName.Visible = true;
            this.gridColcDepName.VisibleIndex = 7;
            this.gridColcDepName.Width = 86;
            // 
            // radioAll
            // 
            this.radioAll.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.radioAll.AutoSize = true;
            this.radioAll.Checked = true;
            this.radioAll.Location = new System.Drawing.Point(504, 45);
            this.radioAll.Name = "radioAll";
            this.radioAll.Size = new System.Drawing.Size(49, 18);
            this.radioAll.TabIndex = 10;
            this.radioAll.TabStop = true;
            this.radioAll.Text = "全部";
            this.radioAll.UseVisualStyleBackColor = true;
            this.radioAll.Visible = false;
            this.radioAll.CheckedChanged += new System.EventHandler(this.radioAll_CheckedChanged);
            // 
            // radioPer
            // 
            this.radioPer.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.radioPer.AutoSize = true;
            this.radioPer.Location = new System.Drawing.Point(570, 45);
            this.radioPer.Name = "radioPer";
            this.radioPer.Size = new System.Drawing.Size(49, 18);
            this.radioPer.TabIndex = 11;
            this.radioPer.Text = "员工";
            this.radioPer.UseVisualStyleBackColor = true;
            this.radioPer.Visible = false;
            this.radioPer.CheckedChanged += new System.EventHandler(this.radioPer_CheckedChanged);
            // 
            // radioVen
            // 
            this.radioVen.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.radioVen.AutoSize = true;
            this.radioVen.Location = new System.Drawing.Point(625, 45);
            this.radioVen.Name = "radioVen";
            this.radioVen.Size = new System.Drawing.Size(61, 18);
            this.radioVen.TabIndex = 12;
            this.radioVen.Text = "供应商";
            this.radioVen.UseVisualStyleBackColor = true;
            this.radioVen.Visible = false;
            this.radioVen.CheckedChanged += new System.EventHandler(this.radioVen_CheckedChanged);
            // 
            // gridColbChoose
            // 
            this.gridColbChoose.FieldName = "bChoose";
            this.gridColbChoose.Name = "gridColbChoose";
            this.gridColbChoose.OptionsColumn.AllowEdit = false;
            this.gridColbChoose.Width = 26;
            // 
            // FrmVendUid
            // 
            this.Appearance.BackColor = System.Drawing.SystemColors.Control;
            this.Appearance.Options.UseBackColor = true;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(727, 351);
            this.Controls.Add(this.radioVen);
            this.Controls.Add(this.radioPer);
            this.Controls.Add(this.radioAll);
            this.Controls.Add(this.gridControl1);
            this.Name = "FrmVendUid";
            this.Text = "FrmVendUid";
            this.Load += new System.EventHandler(this.FrmVendUid_Load);
            this.Controls.SetChildIndex(this.gridControl1, 0);
            this.Controls.SetChildIndex(this.radioAll, 0);
            this.Controls.SetChildIndex(this.radioPer, 0);
            this.Controls.SetChildIndex(this.radioVen, 0);
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.LookUpEditbVend)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.LookUpEditVend)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ItemButtonEditDep)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraGrid.GridControl gridControl1;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView1;
        private DevExpress.XtraGrid.Columns.GridColumn gridColvchrUid;
        private DevExpress.XtraGrid.Columns.GridColumn gridColvchrName;
        private DevExpress.XtraGrid.Columns.GridColumn gridColcvenCode;
        private DevExpress.XtraGrid.Columns.GridColumn gridColcVenName;
        private DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit LookUpEditVend;
        private DevExpress.XtraGrid.Columns.GridColumn gridColbVend;
        private DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit LookUpEditbVend;
        private DevExpress.XtraGrid.Columns.GridColumn gridColsEMail;
        private System.Windows.Forms.RadioButton radioAll;
        private System.Windows.Forms.RadioButton radioPer;
        private System.Windows.Forms.RadioButton radioVen;
        private DevExpress.XtraGrid.Columns.GridColumn gridColPOAduditGrade;
        private DevExpress.XtraGrid.Columns.GridColumn gridColcDepCode;
        private DevExpress.XtraEditors.Repository.RepositoryItemButtonEdit ItemButtonEditDep;
        private DevExpress.XtraGrid.Columns.GridColumn gridColcDepName;
        private DevExpress.XtraGrid.Columns.GridColumn gridColbChoose;
    }
}