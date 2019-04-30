namespace 基础设置
{
    partial class Frm经销商档案
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
            this.gridControl1 = new DevExpress.XtraGrid.GridControl();
            this.gridView1 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.gridColdDeaCode = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColdDeaName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColdDeaAbbName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridCol地区编码 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.ItemButtonEdit地区编码 = new DevExpress.XtraEditors.Repository.RepositoryItemButtonEdit();
            this.gridCol地区 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.ItemLookUpEditdDCCode = new DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit();
            this.gridColdDeaPerson = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColdDeaPhone = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColdDeaAddress = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColdDeaEmail = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColdDeaDevDate = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColdEndDate = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColdDeaRegCode = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColdDeaAccount = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColdDeaBank = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColdDeaLPerson = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColdDeaType = new DevExpress.XtraGrid.Columns.GridColumn();
            this.ItemLookUpEditdDeaType = new DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit();
            this.gridColdDeaUnit = new DevExpress.XtraGrid.Columns.GridColumn();
            this.ItemLookUpEditdDeaUnit = new DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit();
            this.gridColiSave = new DevExpress.XtraGrid.Columns.GridColumn();
            this.layoutControlGroup1 = new DevExpress.XtraLayout.LayoutControlGroup();
            this.layoutControlItem3 = new DevExpress.XtraLayout.LayoutControlItem();
            this.gridCol经销商分类编码 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridCol经销商分类 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.ItemButtonEdit分销商分类 = new DevExpress.XtraEditors.Repository.RepositoryItemButtonEdit();
            this.ItemLookUpEdit经销商分类 = new DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit();
            ((System.ComponentModel.ISupportInitialize)(this.dsPrint)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dsForm)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtSel)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControl1)).BeginInit();
            this.layoutControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ItemButtonEdit地区编码)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ItemLookUpEditdDCCode)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ItemLookUpEditdDeaType)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ItemLookUpEditdDeaUnit)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ItemButtonEdit分销商分类)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ItemLookUpEdit经销商分类)).BeginInit();
            this.SuspendLayout();
            // 
            // layoutControl1
            // 
            this.layoutControl1.AllowCustomizationMenu = false;
            this.layoutControl1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.layoutControl1.Controls.Add(this.gridControl1);
            this.layoutControl1.Location = new System.Drawing.Point(0, 28);
            this.layoutControl1.Name = "layoutControl1";
            this.layoutControl1.OptionsCustomizationForm.DesignTimeCustomizationFormPositionAndSize = new System.Drawing.Rectangle(210, 239, 250, 350);
            this.layoutControl1.OptionsCustomizationForm.ShowLoadButton = false;
            this.layoutControl1.OptionsCustomizationForm.ShowSaveButton = false;
            this.layoutControl1.Root = this.layoutControlGroup1;
            this.layoutControl1.Size = new System.Drawing.Size(934, 332);
            this.layoutControl1.TabIndex = 5;
            this.layoutControl1.Text = "layoutControl1";
            // 
            // gridControl1
            // 
            this.gridControl1.Location = new System.Drawing.Point(12, 12);
            this.gridControl1.MainView = this.gridView1;
            this.gridControl1.Name = "gridControl1";
            this.gridControl1.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.ItemLookUpEditdDCCode,
            this.ItemLookUpEditdDeaType,
            this.ItemLookUpEditdDeaUnit,
            this.ItemButtonEdit地区编码,
            this.ItemButtonEdit分销商分类,
            this.ItemLookUpEdit经销商分类});
            this.gridControl1.Size = new System.Drawing.Size(910, 308);
            this.gridControl1.TabIndex = 6;
            this.gridControl1.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView1});
            // 
            // gridView1
            // 
            this.gridView1.Appearance.FocusedCell.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.gridView1.Appearance.FocusedCell.Options.UseBackColor = true;
            this.gridView1.Appearance.FocusedRow.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.gridView1.Appearance.FocusedRow.Options.UseBackColor = true;
            this.gridView1.Appearance.SelectedRow.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.gridView1.Appearance.SelectedRow.Options.UseBackColor = true;
            this.gridView1.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.gridColdDeaCode,
            this.gridColdDeaName,
            this.gridColdDeaAbbName,
            this.gridCol经销商分类编码,
            this.gridCol经销商分类,
            this.gridCol地区编码,
            this.gridCol地区,
            this.gridColdDeaPerson,
            this.gridColdDeaPhone,
            this.gridColdDeaAddress,
            this.gridColdDeaEmail,
            this.gridColdDeaDevDate,
            this.gridColdEndDate,
            this.gridColdDeaRegCode,
            this.gridColdDeaAccount,
            this.gridColdDeaBank,
            this.gridColdDeaLPerson,
            this.gridColdDeaType,
            this.gridColdDeaUnit,
            this.gridColiSave});
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
            // gridColdDeaCode
            // 
            this.gridColdDeaCode.Caption = "经销商编码";
            this.gridColdDeaCode.FieldName = "dDeaCode";
            this.gridColdDeaCode.Name = "gridColdDeaCode";
            this.gridColdDeaCode.OptionsColumn.AllowMerge = DevExpress.Utils.DefaultBoolean.False;
            this.gridColdDeaCode.Visible = true;
            this.gridColdDeaCode.VisibleIndex = 0;
            this.gridColdDeaCode.Width = 84;
            // 
            // gridColdDeaName
            // 
            this.gridColdDeaName.Caption = "经销商名称";
            this.gridColdDeaName.FieldName = "dDeaName";
            this.gridColdDeaName.Name = "gridColdDeaName";
            this.gridColdDeaName.OptionsColumn.AllowMerge = DevExpress.Utils.DefaultBoolean.False;
            this.gridColdDeaName.Visible = true;
            this.gridColdDeaName.VisibleIndex = 1;
            this.gridColdDeaName.Width = 135;
            // 
            // gridColdDeaAbbName
            // 
            this.gridColdDeaAbbName.Caption = "经销商简称";
            this.gridColdDeaAbbName.FieldName = "dDeaAbbName";
            this.gridColdDeaAbbName.Name = "gridColdDeaAbbName";
            this.gridColdDeaAbbName.OptionsColumn.AllowMerge = DevExpress.Utils.DefaultBoolean.False;
            this.gridColdDeaAbbName.Visible = true;
            this.gridColdDeaAbbName.VisibleIndex = 2;
            this.gridColdDeaAbbName.Width = 84;
            // 
            // gridCol地区编码
            // 
            this.gridCol地区编码.Caption = "地区编码";
            this.gridCol地区编码.ColumnEdit = this.ItemButtonEdit地区编码;
            this.gridCol地区编码.FieldName = "dDCCode";
            this.gridCol地区编码.Name = "gridCol地区编码";
            this.gridCol地区编码.OptionsColumn.AllowMerge = DevExpress.Utils.DefaultBoolean.False;
            this.gridCol地区编码.Visible = true;
            this.gridCol地区编码.VisibleIndex = 9;
            this.gridCol地区编码.Width = 64;
            // 
            // ItemButtonEdit地区编码
            // 
            this.ItemButtonEdit地区编码.AutoHeight = false;
            this.ItemButtonEdit地区编码.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
            this.ItemButtonEdit地区编码.Name = "ItemButtonEdit地区编码";
            this.ItemButtonEdit地区编码.ButtonClick += new DevExpress.XtraEditors.Controls.ButtonPressedEventHandler(this.ItemButtonEdit地区编码_ButtonClick);
            // 
            // gridCol地区
            // 
            this.gridCol地区.Caption = "地区";
            this.gridCol地区.ColumnEdit = this.ItemLookUpEditdDCCode;
            this.gridCol地区.FieldName = "dDCCode";
            this.gridCol地区.Name = "gridCol地区";
            this.gridCol地区.Visible = true;
            this.gridCol地区.VisibleIndex = 10;
            this.gridCol地区.Width = 74;
            // 
            // ItemLookUpEditdDCCode
            // 
            this.ItemLookUpEditdDCCode.AutoHeight = false;
            this.ItemLookUpEditdDCCode.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.ItemLookUpEditdDCCode.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("iID", "序号"),
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("iText", "名称")});
            this.ItemLookUpEditdDCCode.DisplayMember = "iText";
            this.ItemLookUpEditdDCCode.Name = "ItemLookUpEditdDCCode";
            this.ItemLookUpEditdDCCode.NullText = "";
            this.ItemLookUpEditdDCCode.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.Standard;
            this.ItemLookUpEditdDCCode.ValueMember = "iID";
            // 
            // gridColdDeaPerson
            // 
            this.gridColdDeaPerson.Caption = "联系人";
            this.gridColdDeaPerson.FieldName = "dDeaPerson";
            this.gridColdDeaPerson.Name = "gridColdDeaPerson";
            this.gridColdDeaPerson.Visible = true;
            this.gridColdDeaPerson.VisibleIndex = 5;
            // 
            // gridColdDeaPhone
            // 
            this.gridColdDeaPhone.Caption = "电话";
            this.gridColdDeaPhone.FieldName = "dDeaPhone";
            this.gridColdDeaPhone.Name = "gridColdDeaPhone";
            this.gridColdDeaPhone.Visible = true;
            this.gridColdDeaPhone.VisibleIndex = 6;
            // 
            // gridColdDeaAddress
            // 
            this.gridColdDeaAddress.Caption = "地址";
            this.gridColdDeaAddress.FieldName = "dDeaAddress";
            this.gridColdDeaAddress.Name = "gridColdDeaAddress";
            this.gridColdDeaAddress.Visible = true;
            this.gridColdDeaAddress.VisibleIndex = 7;
            // 
            // gridColdDeaEmail
            // 
            this.gridColdDeaEmail.Caption = "邮箱";
            this.gridColdDeaEmail.FieldName = "dDeaEmail";
            this.gridColdDeaEmail.Name = "gridColdDeaEmail";
            this.gridColdDeaEmail.Visible = true;
            this.gridColdDeaEmail.VisibleIndex = 8;
            // 
            // gridColdDeaDevDate
            // 
            this.gridColdDeaDevDate.Caption = "发展日期";
            this.gridColdDeaDevDate.FieldName = "dDeaDevDate";
            this.gridColdDeaDevDate.Name = "gridColdDeaDevDate";
            this.gridColdDeaDevDate.Visible = true;
            this.gridColdDeaDevDate.VisibleIndex = 11;
            // 
            // gridColdEndDate
            // 
            this.gridColdEndDate.Caption = "停用日期";
            this.gridColdEndDate.FieldName = "dEndDate";
            this.gridColdEndDate.Name = "gridColdEndDate";
            this.gridColdEndDate.Visible = true;
            this.gridColdEndDate.VisibleIndex = 12;
            // 
            // gridColdDeaRegCode
            // 
            this.gridColdDeaRegCode.Caption = "税号";
            this.gridColdDeaRegCode.FieldName = "dDeaRegCode";
            this.gridColdDeaRegCode.Name = "gridColdDeaRegCode";
            this.gridColdDeaRegCode.Visible = true;
            this.gridColdDeaRegCode.VisibleIndex = 13;
            // 
            // gridColdDeaAccount
            // 
            this.gridColdDeaAccount.Caption = "银行账号";
            this.gridColdDeaAccount.FieldName = "dDeaAccount";
            this.gridColdDeaAccount.Name = "gridColdDeaAccount";
            this.gridColdDeaAccount.Visible = true;
            this.gridColdDeaAccount.VisibleIndex = 14;
            // 
            // gridColdDeaBank
            // 
            this.gridColdDeaBank.Caption = "开户行";
            this.gridColdDeaBank.FieldName = "dDeaBank";
            this.gridColdDeaBank.Name = "gridColdDeaBank";
            this.gridColdDeaBank.Visible = true;
            this.gridColdDeaBank.VisibleIndex = 15;
            // 
            // gridColdDeaLPerson
            // 
            this.gridColdDeaLPerson.Caption = "法人";
            this.gridColdDeaLPerson.FieldName = "dDeaLPerson";
            this.gridColdDeaLPerson.Name = "gridColdDeaLPerson";
            this.gridColdDeaLPerson.Visible = true;
            this.gridColdDeaLPerson.VisibleIndex = 16;
            // 
            // gridColdDeaType
            // 
            this.gridColdDeaType.Caption = "归属类型";
            this.gridColdDeaType.ColumnEdit = this.ItemLookUpEditdDeaType;
            this.gridColdDeaType.FieldName = "dDeaType";
            this.gridColdDeaType.Name = "gridColdDeaType";
            this.gridColdDeaType.Visible = true;
            this.gridColdDeaType.VisibleIndex = 17;
            // 
            // ItemLookUpEditdDeaType
            // 
            this.ItemLookUpEditdDeaType.AutoHeight = false;
            this.ItemLookUpEditdDeaType.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.ItemLookUpEditdDeaType.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("iID", "序号"),
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("iText", "名称")});
            this.ItemLookUpEditdDeaType.DisplayMember = "iText";
            this.ItemLookUpEditdDeaType.Name = "ItemLookUpEditdDeaType";
            this.ItemLookUpEditdDeaType.NullText = "";
            this.ItemLookUpEditdDeaType.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.Standard;
            this.ItemLookUpEditdDeaType.ValueMember = "iID";
            // 
            // gridColdDeaUnit
            // 
            this.gridColdDeaUnit.Caption = "归属单位";
            this.gridColdDeaUnit.ColumnEdit = this.ItemLookUpEditdDeaUnit;
            this.gridColdDeaUnit.FieldName = "dDeaUnit";
            this.gridColdDeaUnit.Name = "gridColdDeaUnit";
            this.gridColdDeaUnit.Visible = true;
            this.gridColdDeaUnit.VisibleIndex = 18;
            // 
            // ItemLookUpEditdDeaUnit
            // 
            this.ItemLookUpEditdDeaUnit.AutoHeight = false;
            this.ItemLookUpEditdDeaUnit.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.ItemLookUpEditdDeaUnit.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("iID", "序号"),
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("iText", "名称")});
            this.ItemLookUpEditdDeaUnit.DisplayMember = "iText";
            this.ItemLookUpEditdDeaUnit.Name = "ItemLookUpEditdDeaUnit";
            this.ItemLookUpEditdDeaUnit.NullText = "";
            this.ItemLookUpEditdDeaUnit.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.Standard;
            this.ItemLookUpEditdDeaUnit.ValueMember = "iID";
            // 
            // gridColiSave
            // 
            this.gridColiSave.Caption = "编辑状态";
            this.gridColiSave.FieldName = "iSave";
            this.gridColiSave.Name = "gridColiSave";
            this.gridColiSave.OptionsColumn.AllowEdit = false;
            // 
            // layoutControlGroup1
            // 
            this.layoutControlGroup1.CustomizationFormText = "layoutControlGroup1";
            this.layoutControlGroup1.EnableIndentsWithoutBorders = DevExpress.Utils.DefaultBoolean.True;
            this.layoutControlGroup1.GroupBordersVisible = false;
            this.layoutControlGroup1.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.layoutControlItem3});
            this.layoutControlGroup1.Location = new System.Drawing.Point(0, 0);
            this.layoutControlGroup1.Name = "Root";
            this.layoutControlGroup1.Size = new System.Drawing.Size(934, 332);
            this.layoutControlGroup1.Text = "Root";
            this.layoutControlGroup1.TextVisible = false;
            // 
            // layoutControlItem3
            // 
            this.layoutControlItem3.Control = this.gridControl1;
            this.layoutControlItem3.CustomizationFormText = "layoutControlItem3";
            this.layoutControlItem3.Location = new System.Drawing.Point(0, 0);
            this.layoutControlItem3.Name = "layoutControlItem3";
            this.layoutControlItem3.Size = new System.Drawing.Size(914, 312);
            this.layoutControlItem3.Text = "layoutControlItem3";
            this.layoutControlItem3.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem3.TextToControlDistance = 0;
            this.layoutControlItem3.TextVisible = false;
            // 
            // gridCol经销商分类编码
            // 
            this.gridCol经销商分类编码.Caption = "经销商分类编码";
            this.gridCol经销商分类编码.ColumnEdit = this.ItemButtonEdit分销商分类;
            this.gridCol经销商分类编码.FieldName = "cDCCode";
            this.gridCol经销商分类编码.Name = "gridCol经销商分类编码";
            this.gridCol经销商分类编码.Visible = true;
            this.gridCol经销商分类编码.VisibleIndex = 3;
            this.gridCol经销商分类编码.Width = 97;
            // 
            // gridCol经销商分类
            // 
            this.gridCol经销商分类.Caption = "经销商分类";
            this.gridCol经销商分类.ColumnEdit = this.ItemLookUpEdit经销商分类;
            this.gridCol经销商分类.FieldName = "cDCCode";
            this.gridCol经销商分类.Name = "gridCol经销商分类";
            this.gridCol经销商分类.OptionsColumn.AllowEdit = false;
            this.gridCol经销商分类.Visible = true;
            this.gridCol经销商分类.VisibleIndex = 4;
            this.gridCol经销商分类.Width = 93;
            // 
            // ItemButtonEdit分销商分类
            // 
            this.ItemButtonEdit分销商分类.AutoHeight = false;
            this.ItemButtonEdit分销商分类.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
            this.ItemButtonEdit分销商分类.Name = "ItemButtonEdit分销商分类";
            this.ItemButtonEdit分销商分类.ButtonClick += new DevExpress.XtraEditors.Controls.ButtonPressedEventHandler(this.ItemButtonEdit分销商分类_ButtonClick);
            // 
            // ItemLookUpEdit经销商分类
            // 
            this.ItemLookUpEdit经销商分类.AutoHeight = false;
            this.ItemLookUpEdit经销商分类.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.ItemLookUpEdit经销商分类.DisplayMember = "iText";
            this.ItemLookUpEdit经销商分类.Name = "ItemLookUpEdit经销商分类";
            this.ItemLookUpEdit经销商分类.NullText = "";
            this.ItemLookUpEdit经销商分类.ValueMember = "iID";
            // 
            // Frm经销商档案
            // 
            this.Appearance.BackColor = System.Drawing.SystemColors.Control;
            this.Appearance.Options.UseBackColor = true;
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(932, 361);
            this.Controls.Add(this.layoutControl1);
            this.Name = "Frm经销商档案";
            this.Text = "经销商档案";
            this.Load += new System.EventHandler(this.Frm经销商档案_Load);
            this.Controls.SetChildIndex(this.layoutControl1, 0);
            ((System.ComponentModel.ISupportInitialize)(this.dsPrint)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dsForm)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtSel)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControl1)).EndInit();
            this.layoutControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ItemButtonEdit地区编码)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ItemLookUpEditdDCCode)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ItemLookUpEditdDeaType)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ItemLookUpEditdDeaUnit)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ItemButtonEdit分销商分类)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ItemLookUpEdit经销商分类)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraLayout.LayoutControl layoutControl1;
        private DevExpress.XtraGrid.GridControl gridControl1;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView1;
        private DevExpress.XtraLayout.LayoutControlGroup layoutControlGroup1;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem3;
        private DevExpress.XtraGrid.Columns.GridColumn gridColdDeaCode;
        private DevExpress.XtraGrid.Columns.GridColumn gridColdDeaName;
        private DevExpress.XtraGrid.Columns.GridColumn gridColdDeaAbbName;
        private DevExpress.XtraGrid.Columns.GridColumn gridCol地区编码;
        private DevExpress.XtraGrid.Columns.GridColumn gridColiSave;
        private DevExpress.XtraGrid.Columns.GridColumn gridColdDeaPerson;
        private DevExpress.XtraGrid.Columns.GridColumn gridColdDeaPhone;
        private DevExpress.XtraGrid.Columns.GridColumn gridColdDeaAddress;
        private DevExpress.XtraGrid.Columns.GridColumn gridColdDeaEmail;
        private DevExpress.XtraGrid.Columns.GridColumn gridColdDeaDevDate;
        private DevExpress.XtraGrid.Columns.GridColumn gridColdEndDate;
        private DevExpress.XtraGrid.Columns.GridColumn gridColdDeaRegCode;
        private DevExpress.XtraGrid.Columns.GridColumn gridColdDeaAccount;
        private DevExpress.XtraGrid.Columns.GridColumn gridColdDeaBank;
        private DevExpress.XtraGrid.Columns.GridColumn gridColdDeaLPerson;
        private DevExpress.XtraGrid.Columns.GridColumn gridColdDeaType;
        private DevExpress.XtraGrid.Columns.GridColumn gridColdDeaUnit;
        private DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit ItemLookUpEditdDCCode;
        private DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit ItemLookUpEditdDeaType;
        private DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit ItemLookUpEditdDeaUnit;
        private DevExpress.XtraGrid.Columns.GridColumn gridCol地区;
        private DevExpress.XtraEditors.Repository.RepositoryItemButtonEdit ItemButtonEdit地区编码;
        private DevExpress.XtraGrid.Columns.GridColumn gridCol经销商分类编码;
        private DevExpress.XtraGrid.Columns.GridColumn gridCol经销商分类;
        private DevExpress.XtraEditors.Repository.RepositoryItemButtonEdit ItemButtonEdit分销商分类;
        private DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit ItemLookUpEdit经销商分类;
    }
}