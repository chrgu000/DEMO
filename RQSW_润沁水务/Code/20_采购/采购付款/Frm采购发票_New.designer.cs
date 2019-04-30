namespace 采购
{
    partial class Frm采购发票_New 
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
            this.btnExit = new System.Windows.Forms.Button();
            this.layoutControlGroup1 = new DevExpress.XtraLayout.LayoutControlGroup();
            this.layoutControlItem17 = new DevExpress.XtraLayout.LayoutControlItem();
            this.gridControl1 = new DevExpress.XtraGrid.GridControl();
            this.gridView1 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.gridColID = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColAutoID = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridCol选择 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridCol单据号 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridCol采购发票行号 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridCol采购订单号 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridCol单据日期 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridCol付款日期 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridCol业务员 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.ItemLookUpEdit业务员 = new DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit();
            this.gridCol部门 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.ItemLookUpEdit部门 = new DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit();
            this.gridCol供应商 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.ItemLookUpEdit供应商 = new DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit();
            this.gridCol付款金额 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridCol含税金额 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridCol无税金额 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridCol税额 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridCol备注 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridCol来源类型 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.ItemLookUpEdit来源类型 = new DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit();
            this.gridCol来源单据ID = new DevExpress.XtraGrid.Columns.GridColumn();
            this.ItemLookUpEdit采购订单号 = new DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit();
            this.layoutControlItem7 = new DevExpress.XtraLayout.LayoutControlItem();
            this.buttonEdit供应商 = new DevExpress.XtraEditors.ButtonEdit();
            this.layoutControl1 = new DevExpress.XtraLayout.LayoutControl();
            this.radioGroup蓝红标识 = new DevExpress.XtraEditors.RadioGroup();
            this.lookUpEdit供应商 = new DevExpress.XtraEditors.LookUpEdit();
            this.layoutControlItem8 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem9 = new DevExpress.XtraLayout.LayoutControlItem();
            this.btnEnsure = new System.Windows.Forms.Button();
            this.button查询 = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem17)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ItemLookUpEdit业务员)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ItemLookUpEdit部门)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ItemLookUpEdit供应商)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ItemLookUpEdit来源类型)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ItemLookUpEdit采购订单号)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem7)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.buttonEdit供应商.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControl1)).BeginInit();
            this.layoutControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.radioGroup蓝红标识.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lookUpEdit供应商.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem8)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem9)).BeginInit();
            this.SuspendLayout();
            // 
            // btnExit
            // 
            this.btnExit.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnExit.Location = new System.Drawing.Point(685, 394);
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size(62, 23);
            this.btnExit.TabIndex = 2;
            this.btnExit.Text = "退 出";
            this.btnExit.UseVisualStyleBackColor = true;
            this.btnExit.Click += new System.EventHandler(this.btnExit_Click);
            // 
            // layoutControlGroup1
            // 
            this.layoutControlGroup1.CustomizationFormText = "layoutControlGroup1";
            this.layoutControlGroup1.EnableIndentsWithoutBorders = DevExpress.Utils.DefaultBoolean.True;
            this.layoutControlGroup1.GroupBordersVisible = false;
            this.layoutControlGroup1.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.layoutControlItem17,
            this.layoutControlItem7,
            this.layoutControlItem8,
            this.layoutControlItem9});
            this.layoutControlGroup1.Location = new System.Drawing.Point(0, 0);
            this.layoutControlGroup1.Name = "Root";
            this.layoutControlGroup1.Size = new System.Drawing.Size(782, 379);
            this.layoutControlGroup1.Text = "Root";
            this.layoutControlGroup1.TextVisible = false;
            // 
            // layoutControlItem17
            // 
            this.layoutControlItem17.Control = this.gridControl1;
            this.layoutControlItem17.CustomizationFormText = "layoutControlItem17";
            this.layoutControlItem17.Location = new System.Drawing.Point(0, 29);
            this.layoutControlItem17.Name = "layoutControlItem17";
            this.layoutControlItem17.Size = new System.Drawing.Size(762, 330);
            this.layoutControlItem17.Text = "layoutControlItem17";
            this.layoutControlItem17.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem17.TextToControlDistance = 0;
            this.layoutControlItem17.TextVisible = false;
            // 
            // gridControl1
            // 
            this.gridControl1.Location = new System.Drawing.Point(12, 41);
            this.gridControl1.MainView = this.gridView1;
            this.gridControl1.Name = "gridControl1";
            this.gridControl1.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.ItemLookUpEdit部门,
            this.ItemLookUpEdit业务员,
            this.ItemLookUpEdit供应商,
            this.ItemLookUpEdit来源类型,
            this.ItemLookUpEdit采购订单号});
            this.gridControl1.Size = new System.Drawing.Size(758, 326);
            this.gridControl1.TabIndex = 7;
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
            this.gridColID,
            this.gridColAutoID,
            this.gridCol选择,
            this.gridCol单据号,
            this.gridCol采购发票行号,
            this.gridCol采购订单号,
            this.gridCol单据日期,
            this.gridCol付款日期,
            this.gridCol业务员,
            this.gridCol部门,
            this.gridCol供应商,
            this.gridCol付款金额,
            this.gridCol含税金额,
            this.gridCol无税金额,
            this.gridCol税额,
            this.gridCol备注,
            this.gridCol来源类型,
            this.gridCol来源单据ID});
            this.gridView1.CustomizationFormBounds = new System.Drawing.Rectangle(950, 457, 216, 187);
            this.gridView1.GridControl = this.gridControl1;
            this.gridView1.IndicatorWidth = 40;
            this.gridView1.Name = "gridView1";
            this.gridView1.OptionsBehavior.Editable = false;
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
            this.gridView1.OptionsView.ShowFooter = true;
            this.gridView1.OptionsView.ShowGroupPanel = false;
            this.gridView1.CustomDrawRowIndicator += new DevExpress.XtraGrid.Views.Grid.RowIndicatorCustomDrawEventHandler(this.gridView1_CustomDrawRowIndicator);
            this.gridView1.DoubleClick += new System.EventHandler(this.gridView1_DoubleClick);
            // 
            // gridColID
            // 
            this.gridColID.Caption = "ID";
            this.gridColID.FieldName = "ID";
            this.gridColID.Name = "gridColID";
            // 
            // gridColAutoID
            // 
            this.gridColAutoID.Caption = "AutoID";
            this.gridColAutoID.FieldName = "AutoID";
            this.gridColAutoID.Name = "gridColAutoID";
            // 
            // gridCol选择
            // 
            this.gridCol选择.Caption = "选择";
            this.gridCol选择.FieldName = "iChk";
            this.gridCol选择.Name = "gridCol选择";
            this.gridCol选择.Visible = true;
            this.gridCol选择.VisibleIndex = 0;
            this.gridCol选择.Width = 31;
            // 
            // gridCol单据号
            // 
            this.gridCol单据号.Caption = "来源单据号";
            this.gridCol单据号.FieldName = "cPBVCode";
            this.gridCol单据号.Name = "gridCol单据号";
            this.gridCol单据号.OptionsColumn.AllowEdit = false;
            this.gridCol单据号.Visible = true;
            this.gridCol单据号.VisibleIndex = 2;
            this.gridCol单据号.Width = 92;
            // 
            // gridCol采购发票行号
            // 
            this.gridCol采购发票行号.Caption = "采购发票行号";
            this.gridCol采购发票行号.FieldName = "AutoID";
            this.gridCol采购发票行号.Name = "gridCol采购发票行号";
            this.gridCol采购发票行号.Visible = true;
            this.gridCol采购发票行号.VisibleIndex = 3;
            // 
            // gridCol采购订单号
            // 
            this.gridCol采购订单号.Caption = "采购订单号";
            this.gridCol采购订单号.FieldName = "cPOCode";
            this.gridCol采购订单号.Name = "gridCol采购订单号";
            this.gridCol采购订单号.Visible = true;
            this.gridCol采购订单号.VisibleIndex = 5;
            // 
            // gridCol单据日期
            // 
            this.gridCol单据日期.Caption = "单据日期";
            this.gridCol单据日期.DisplayFormat.FormatString = "yyyy-MM-dd";
            this.gridCol单据日期.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.gridCol单据日期.FieldName = "dDate";
            this.gridCol单据日期.Name = "gridCol单据日期";
            this.gridCol单据日期.Visible = true;
            this.gridCol单据日期.VisibleIndex = 4;
            this.gridCol单据日期.Width = 92;
            // 
            // gridCol付款日期
            // 
            this.gridCol付款日期.Caption = "付款日期";
            this.gridCol付款日期.FieldName = "付款日期";
            this.gridCol付款日期.Name = "gridCol付款日期";
            this.gridCol付款日期.Visible = true;
            this.gridCol付款日期.VisibleIndex = 14;
            // 
            // gridCol业务员
            // 
            this.gridCol业务员.Caption = "业务员";
            this.gridCol业务员.ColumnEdit = this.ItemLookUpEdit业务员;
            this.gridCol业务员.FieldName = "cPersonCode";
            this.gridCol业务员.Name = "gridCol业务员";
            this.gridCol业务员.Visible = true;
            this.gridCol业务员.VisibleIndex = 6;
            this.gridCol业务员.Width = 89;
            // 
            // ItemLookUpEdit业务员
            // 
            this.ItemLookUpEdit业务员.AutoHeight = false;
            this.ItemLookUpEdit业务员.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.ItemLookUpEdit业务员.Name = "ItemLookUpEdit业务员";
            // 
            // gridCol部门
            // 
            this.gridCol部门.Caption = "部门";
            this.gridCol部门.ColumnEdit = this.ItemLookUpEdit部门;
            this.gridCol部门.FieldName = "cDepCode";
            this.gridCol部门.Name = "gridCol部门";
            this.gridCol部门.Visible = true;
            this.gridCol部门.VisibleIndex = 7;
            // 
            // ItemLookUpEdit部门
            // 
            this.ItemLookUpEdit部门.AutoHeight = false;
            this.ItemLookUpEdit部门.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.ItemLookUpEdit部门.Name = "ItemLookUpEdit部门";
            // 
            // gridCol供应商
            // 
            this.gridCol供应商.Caption = "供应商";
            this.gridCol供应商.ColumnEdit = this.ItemLookUpEdit供应商;
            this.gridCol供应商.FieldName = "cVenCode";
            this.gridCol供应商.Name = "gridCol供应商";
            this.gridCol供应商.Visible = true;
            this.gridCol供应商.VisibleIndex = 9;
            // 
            // ItemLookUpEdit供应商
            // 
            this.ItemLookUpEdit供应商.AutoHeight = false;
            this.ItemLookUpEdit供应商.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.ItemLookUpEdit供应商.Name = "ItemLookUpEdit供应商";
            // 
            // gridCol付款金额
            // 
            this.gridCol付款金额.Caption = "付款金额";
            this.gridCol付款金额.FieldName = "付款金额";
            this.gridCol付款金额.Name = "gridCol付款金额";
            this.gridCol付款金额.Summary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] {
            new DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum)});
            this.gridCol付款金额.Visible = true;
            this.gridCol付款金额.VisibleIndex = 13;
            // 
            // gridCol含税金额
            // 
            this.gridCol含税金额.Caption = "含税金额";
            this.gridCol含税金额.FieldName = "iMoney";
            this.gridCol含税金额.Name = "gridCol含税金额";
            this.gridCol含税金额.Summary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] {
            new DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum)});
            this.gridCol含税金额.Visible = true;
            this.gridCol含税金额.VisibleIndex = 8;
            // 
            // gridCol无税金额
            // 
            this.gridCol无税金额.Caption = "无税金额";
            this.gridCol无税金额.FieldName = "iNatMoney";
            this.gridCol无税金额.Name = "gridCol无税金额";
            this.gridCol无税金额.Summary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] {
            new DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum)});
            this.gridCol无税金额.Visible = true;
            this.gridCol无税金额.VisibleIndex = 10;
            // 
            // gridCol税额
            // 
            this.gridCol税额.Caption = "税额";
            this.gridCol税额.FieldName = "iNatTax";
            this.gridCol税额.Name = "gridCol税额";
            this.gridCol税额.Summary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] {
            new DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum)});
            this.gridCol税额.Visible = true;
            this.gridCol税额.VisibleIndex = 11;
            // 
            // gridCol备注
            // 
            this.gridCol备注.Caption = "备注";
            this.gridCol备注.FieldName = "Remark";
            this.gridCol备注.Name = "gridCol备注";
            this.gridCol备注.Visible = true;
            this.gridCol备注.VisibleIndex = 12;
            // 
            // gridCol来源类型
            // 
            this.gridCol来源类型.Caption = "来源类型";
            this.gridCol来源类型.ColumnEdit = this.ItemLookUpEdit来源类型;
            this.gridCol来源类型.FieldName = "iType";
            this.gridCol来源类型.Name = "gridCol来源类型";
            this.gridCol来源类型.OptionsColumn.AllowEdit = false;
            this.gridCol来源类型.Visible = true;
            this.gridCol来源类型.VisibleIndex = 1;
            this.gridCol来源类型.Width = 86;
            // 
            // ItemLookUpEdit来源类型
            // 
            this.ItemLookUpEdit来源类型.AutoHeight = false;
            this.ItemLookUpEdit来源类型.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.ItemLookUpEdit来源类型.Name = "ItemLookUpEdit来源类型";
            // 
            // gridCol来源单据ID
            // 
            this.gridCol来源单据ID.Caption = "来源单据ID";
            this.gridCol来源单据ID.FieldName = "AutoID";
            this.gridCol来源单据ID.Name = "gridCol来源单据ID";
            this.gridCol来源单据ID.Visible = true;
            this.gridCol来源单据ID.VisibleIndex = 15;
            // 
            // ItemLookUpEdit采购订单号
            // 
            this.ItemLookUpEdit采购订单号.AutoHeight = false;
            this.ItemLookUpEdit采购订单号.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.ItemLookUpEdit采购订单号.Name = "ItemLookUpEdit采购订单号";
            // 
            // layoutControlItem7
            // 
            this.layoutControlItem7.Control = this.buttonEdit供应商;
            this.layoutControlItem7.CustomizationFormText = "供应商";
            this.layoutControlItem7.Location = new System.Drawing.Point(0, 0);
            this.layoutControlItem7.Name = "layoutControlItem7";
            this.layoutControlItem7.Size = new System.Drawing.Size(173, 29);
            this.layoutControlItem7.Text = "供应商";
            this.layoutControlItem7.TextSize = new System.Drawing.Size(36, 14);
            // 
            // buttonEdit供应商
            // 
            this.buttonEdit供应商.Location = new System.Drawing.Point(52, 12);
            this.buttonEdit供应商.Name = "buttonEdit供应商";
            this.buttonEdit供应商.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
            this.buttonEdit供应商.Size = new System.Drawing.Size(129, 21);
            this.buttonEdit供应商.StyleController = this.layoutControl1;
            this.buttonEdit供应商.TabIndex = 57;
            this.buttonEdit供应商.ButtonClick += new DevExpress.XtraEditors.Controls.ButtonPressedEventHandler(this.buttonEdit供应商_ButtonClick);
            this.buttonEdit供应商.EditValueChanged += new System.EventHandler(this.buttonEdit供应商_EditValueChanged);
            this.buttonEdit供应商.Leave += new System.EventHandler(this.buttonEdit供应商_Leave);
            // 
            // layoutControl1
            // 
            this.layoutControl1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.layoutControl1.Controls.Add(this.radioGroup蓝红标识);
            this.layoutControl1.Controls.Add(this.lookUpEdit供应商);
            this.layoutControl1.Controls.Add(this.buttonEdit供应商);
            this.layoutControl1.Controls.Add(this.gridControl1);
            this.layoutControl1.Location = new System.Drawing.Point(-3, 12);
            this.layoutControl1.Name = "layoutControl1";
            this.layoutControl1.OptionsCustomizationForm.DesignTimeCustomizationFormPositionAndSize = new System.Drawing.Rectangle(123, 171, 250, 350);
            this.layoutControl1.OptionsView.UseDefaultDragAndDropRendering = false;
            this.layoutControl1.Root = this.layoutControlGroup1;
            this.layoutControl1.Size = new System.Drawing.Size(782, 379);
            this.layoutControl1.TabIndex = 0;
            this.layoutControl1.Text = "layoutControl1";
            // 
            // radioGroup蓝红标识
            // 
            this.radioGroup蓝红标识.Location = new System.Drawing.Point(626, 12);
            this.radioGroup蓝红标识.Name = "radioGroup蓝红标识";
            this.radioGroup蓝红标识.Properties.Items.AddRange(new DevExpress.XtraEditors.Controls.RadioGroupItem[] {
            new DevExpress.XtraEditors.Controls.RadioGroupItem("1", "蓝字"),
            new DevExpress.XtraEditors.Controls.RadioGroupItem("2", "红字")});
            this.radioGroup蓝红标识.Size = new System.Drawing.Size(144, 25);
            this.radioGroup蓝红标识.StyleController = this.layoutControl1;
            this.radioGroup蓝红标识.TabIndex = 52;
            // 
            // lookUpEdit供应商
            // 
            this.lookUpEdit供应商.Enabled = false;
            this.lookUpEdit供应商.Location = new System.Drawing.Point(185, 12);
            this.lookUpEdit供应商.Name = "lookUpEdit供应商";
            this.lookUpEdit供应商.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.lookUpEdit供应商.Size = new System.Drawing.Size(437, 21);
            this.lookUpEdit供应商.StyleController = this.layoutControl1;
            this.lookUpEdit供应商.TabIndex = 57;
            // 
            // layoutControlItem8
            // 
            this.layoutControlItem8.Control = this.lookUpEdit供应商;
            this.layoutControlItem8.CustomizationFormText = "layoutControlItem8";
            this.layoutControlItem8.Location = new System.Drawing.Point(173, 0);
            this.layoutControlItem8.Name = "layoutControlItem8";
            this.layoutControlItem8.Size = new System.Drawing.Size(441, 29);
            this.layoutControlItem8.Text = "layoutControlItem8";
            this.layoutControlItem8.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem8.TextToControlDistance = 0;
            this.layoutControlItem8.TextVisible = false;
            // 
            // layoutControlItem9
            // 
            this.layoutControlItem9.Control = this.radioGroup蓝红标识;
            this.layoutControlItem9.CustomizationFormText = "layoutControlItem9";
            this.layoutControlItem9.Location = new System.Drawing.Point(614, 0);
            this.layoutControlItem9.Name = "layoutControlItem9";
            this.layoutControlItem9.Size = new System.Drawing.Size(148, 29);
            this.layoutControlItem9.Text = "layoutControlItem9";
            this.layoutControlItem9.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem9.TextToControlDistance = 0;
            this.layoutControlItem9.TextVisible = false;
            // 
            // btnEnsure
            // 
            this.btnEnsure.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnEnsure.Location = new System.Drawing.Point(584, 394);
            this.btnEnsure.Name = "btnEnsure";
            this.btnEnsure.Size = new System.Drawing.Size(62, 23);
            this.btnEnsure.TabIndex = 3;
            this.btnEnsure.Text = "确 定";
            this.btnEnsure.UseVisualStyleBackColor = true;
            this.btnEnsure.Click += new System.EventHandler(this.btnEnsure_Click);
            // 
            // button查询
            // 
            this.button查询.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.button查询.Location = new System.Drawing.Point(489, 394);
            this.button查询.Name = "button查询";
            this.button查询.Size = new System.Drawing.Size(62, 23);
            this.button查询.TabIndex = 4;
            this.button查询.Text = "查 询";
            this.button查询.UseVisualStyleBackColor = true;
            this.button查询.Click += new System.EventHandler(this.button查询_Click);
            // 
            // Frm采购发票_New
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(776, 429);
            this.Controls.Add(this.button查询);
            this.Controls.Add(this.btnEnsure);
            this.Controls.Add(this.btnExit);
            this.Controls.Add(this.layoutControl1);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Frm采购发票_New";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "参照";
            this.Load += new System.EventHandler(this.Frm采购发票_New_Load);
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem17)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ItemLookUpEdit业务员)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ItemLookUpEdit部门)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ItemLookUpEdit供应商)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ItemLookUpEdit来源类型)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ItemLookUpEdit采购订单号)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem7)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.buttonEdit供应商.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControl1)).EndInit();
            this.layoutControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.radioGroup蓝红标识.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lookUpEdit供应商.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem8)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem9)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnExit;
        private DevExpress.XtraLayout.LayoutControlGroup layoutControlGroup1;
        private DevExpress.XtraLayout.LayoutControl layoutControl1;
        private System.Windows.Forms.Button btnEnsure;
        private DevExpress.XtraGrid.GridControl gridControl1;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView1;
        private DevExpress.XtraGrid.Columns.GridColumn gridColID;
        private DevExpress.XtraGrid.Columns.GridColumn gridColAutoID;
        private DevExpress.XtraGrid.Columns.GridColumn gridCol选择;
        private DevExpress.XtraGrid.Columns.GridColumn gridCol单据号;
        private DevExpress.XtraGrid.Columns.GridColumn gridCol单据日期;
        private DevExpress.XtraGrid.Columns.GridColumn gridCol业务员;
        private DevExpress.XtraGrid.Columns.GridColumn gridCol部门;
        private DevExpress.XtraGrid.Columns.GridColumn gridCol供应商;
        private DevExpress.XtraGrid.Columns.GridColumn gridCol含税金额;
        private DevExpress.XtraGrid.Columns.GridColumn gridCol无税金额;
        private DevExpress.XtraGrid.Columns.GridColumn gridCol税额;
        private DevExpress.XtraGrid.Columns.GridColumn gridCol备注;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem17;
        private System.Windows.Forms.Button button查询;
        private DevExpress.XtraEditors.ButtonEdit buttonEdit供应商;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem7;
        private DevExpress.XtraEditors.LookUpEdit lookUpEdit供应商;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem8;
        private DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit ItemLookUpEdit业务员;
        private DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit ItemLookUpEdit部门;
        private DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit ItemLookUpEdit供应商;
        private DevExpress.XtraEditors.RadioGroup radioGroup蓝红标识;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem9;
        private DevExpress.XtraGrid.Columns.GridColumn gridCol付款日期;
        private DevExpress.XtraGrid.Columns.GridColumn gridCol付款金额;
        private DevExpress.XtraGrid.Columns.GridColumn gridCol来源类型;
        private DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit ItemLookUpEdit来源类型;
        private DevExpress.XtraGrid.Columns.GridColumn gridCol采购发票行号;
        private DevExpress.XtraGrid.Columns.GridColumn gridCol采购订单号;
        private DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit ItemLookUpEdit采购订单号;
        private DevExpress.XtraGrid.Columns.GridColumn gridCol来源单据ID;
    }
}