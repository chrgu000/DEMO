namespace 销售
{
    partial class Frm销售订单_New 
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
            this.gridCol来源单据类型 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.ItemLookUpEdit来源单据类型 = new DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit();
            this.gridCol来源单据号 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridCol单据日期 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridCol业务员 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.ItemLookUpEdit业务员 = new DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit();
            this.gridCol部门 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.ItemLookUpEdit部门 = new DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit();
            this.gridCol金额 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridCol应收金额 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridCol来源单据ID = new DevExpress.XtraGrid.Columns.GridColumn();
            this.layoutControlItem10 = new DevExpress.XtraLayout.LayoutControlItem();
            this.radioGroup蓝红标识 = new DevExpress.XtraEditors.RadioGroup();
            this.layoutControl1 = new DevExpress.XtraLayout.LayoutControl();
            this.lookUpEdit销售类型 = new DevExpress.XtraEditors.LookUpEdit();
            this.buttonEdit客户 = new DevExpress.XtraEditors.ButtonEdit();
            this.lookUpEdit客户 = new DevExpress.XtraEditors.LookUpEdit();
            this.layoutControlItem9 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem11 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem1 = new DevExpress.XtraLayout.LayoutControlItem();
            this.btnEnsure = new System.Windows.Forms.Button();
            this.button查询 = new System.Windows.Forms.Button();
            this.layoutControlItem13 = new DevExpress.XtraLayout.LayoutControlItem();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem17)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ItemLookUpEdit来源单据类型)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ItemLookUpEdit业务员)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ItemLookUpEdit部门)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem10)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radioGroup蓝红标识.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControl1)).BeginInit();
            this.layoutControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.lookUpEdit销售类型.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.buttonEdit客户.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lookUpEdit客户.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem9)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem11)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem13)).BeginInit();
            this.SuspendLayout();
            // 
            // btnExit
            // 
            this.btnExit.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnExit.Location = new System.Drawing.Point(775, 419);
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
            this.layoutControlItem10,
            this.layoutControlItem9,
            this.layoutControlItem11,
            this.layoutControlItem1});
            this.layoutControlGroup1.Location = new System.Drawing.Point(0, 0);
            this.layoutControlGroup1.Name = "Root";
            this.layoutControlGroup1.Size = new System.Drawing.Size(872, 404);
            this.layoutControlGroup1.Text = "Root";
            this.layoutControlGroup1.TextVisible = false;
            // 
            // layoutControlItem17
            // 
            this.layoutControlItem17.Control = this.gridControl1;
            this.layoutControlItem17.CustomizationFormText = "layoutControlItem17";
            this.layoutControlItem17.Location = new System.Drawing.Point(0, 29);
            this.layoutControlItem17.Name = "layoutControlItem17";
            this.layoutControlItem17.Size = new System.Drawing.Size(852, 355);
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
            this.ItemLookUpEdit来源单据类型,
            this.ItemLookUpEdit业务员,
            this.ItemLookUpEdit部门});
            this.gridControl1.Size = new System.Drawing.Size(848, 351);
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
            this.gridCol来源单据类型,
            this.gridCol来源单据号,
            this.gridCol单据日期,
            this.gridCol业务员,
            this.gridCol部门,
            this.gridCol金额,
            this.gridCol应收金额,
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
            this.gridView1.CustomDrawRowIndicator += new DevExpress.XtraGrid.Views.Grid.RowIndicatorCustomDrawEventHandler(this.gridView1_CustomDrawRowIndicator_1);
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
            this.gridCol选择.Width = 35;
            // 
            // gridCol来源单据类型
            // 
            this.gridCol来源单据类型.Caption = "来源单据类型";
            this.gridCol来源单据类型.ColumnEdit = this.ItemLookUpEdit来源单据类型;
            this.gridCol来源单据类型.FieldName = "iType";
            this.gridCol来源单据类型.Name = "gridCol来源单据类型";
            this.gridCol来源单据类型.Visible = true;
            this.gridCol来源单据类型.VisibleIndex = 1;
            this.gridCol来源单据类型.Width = 95;
            // 
            // ItemLookUpEdit来源单据类型
            // 
            this.ItemLookUpEdit来源单据类型.AutoHeight = false;
            this.ItemLookUpEdit来源单据类型.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.ItemLookUpEdit来源单据类型.Name = "ItemLookUpEdit来源单据类型";
            // 
            // gridCol来源单据号
            // 
            this.gridCol来源单据号.Caption = "来源单据号";
            this.gridCol来源单据号.FieldName = "cTypeCode";
            this.gridCol来源单据号.Name = "gridCol来源单据号";
            this.gridCol来源单据号.Visible = true;
            this.gridCol来源单据号.VisibleIndex = 2;
            this.gridCol来源单据号.Width = 123;
            // 
            // gridCol单据日期
            // 
            this.gridCol单据日期.Caption = "单据日期";
            this.gridCol单据日期.DisplayFormat.FormatString = "yyyy-MM-dd";
            this.gridCol单据日期.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.gridCol单据日期.FieldName = "dDate";
            this.gridCol单据日期.Name = "gridCol单据日期";
            this.gridCol单据日期.Visible = true;
            this.gridCol单据日期.VisibleIndex = 3;
            this.gridCol单据日期.Width = 108;
            // 
            // gridCol业务员
            // 
            this.gridCol业务员.Caption = "业务员";
            this.gridCol业务员.ColumnEdit = this.ItemLookUpEdit业务员;
            this.gridCol业务员.FieldName = "cPersonCode";
            this.gridCol业务员.Name = "gridCol业务员";
            this.gridCol业务员.Visible = true;
            this.gridCol业务员.VisibleIndex = 4;
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
            this.gridCol部门.VisibleIndex = 5;
            // 
            // ItemLookUpEdit部门
            // 
            this.ItemLookUpEdit部门.AutoHeight = false;
            this.ItemLookUpEdit部门.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.ItemLookUpEdit部门.Name = "ItemLookUpEdit部门";
            // 
            // gridCol金额
            // 
            this.gridCol金额.Caption = "金额";
            this.gridCol金额.FieldName = "iMoney";
            this.gridCol金额.Name = "gridCol金额";
            this.gridCol金额.Summary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] {
            new DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum)});
            this.gridCol金额.Visible = true;
            this.gridCol金额.VisibleIndex = 6;
            // 
            // gridCol应收金额
            // 
            this.gridCol应收金额.Caption = "应收金额";
            this.gridCol应收金额.FieldName = "iReceiptMoney";
            this.gridCol应收金额.Name = "gridCol应收金额";
            this.gridCol应收金额.Summary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] {
            new DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum)});
            this.gridCol应收金额.Visible = true;
            this.gridCol应收金额.VisibleIndex = 7;
            // 
            // gridCol来源单据ID
            // 
            this.gridCol来源单据ID.Caption = "来源单据ID";
            this.gridCol来源单据ID.FieldName = "cSBVAutoID";
            this.gridCol来源单据ID.Name = "gridCol来源单据ID";
            this.gridCol来源单据ID.Visible = true;
            this.gridCol来源单据ID.VisibleIndex = 8;
            // 
            // layoutControlItem10
            // 
            this.layoutControlItem10.Control = this.radioGroup蓝红标识;
            this.layoutControlItem10.CustomizationFormText = "layoutControlItem10";
            this.layoutControlItem10.Location = new System.Drawing.Point(537, 0);
            this.layoutControlItem10.Name = "layoutControlItem10";
            this.layoutControlItem10.Size = new System.Drawing.Size(315, 29);
            this.layoutControlItem10.Text = "layoutControlItem10";
            this.layoutControlItem10.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem10.TextToControlDistance = 0;
            this.layoutControlItem10.TextVisible = false;
            this.layoutControlItem10.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Never;
            // 
            // radioGroup蓝红标识
            // 
            this.radioGroup蓝红标识.Location = new System.Drawing.Point(549, 12);
            this.radioGroup蓝红标识.Name = "radioGroup蓝红标识";
            this.radioGroup蓝红标识.Properties.Items.AddRange(new DevExpress.XtraEditors.Controls.RadioGroupItem[] {
            new DevExpress.XtraEditors.Controls.RadioGroupItem("1", "蓝字"),
            new DevExpress.XtraEditors.Controls.RadioGroupItem("2", "红字")});
            this.radioGroup蓝红标识.Size = new System.Drawing.Size(311, 25);
            this.radioGroup蓝红标识.StyleController = this.layoutControl1;
            this.radioGroup蓝红标识.TabIndex = 60;
            this.radioGroup蓝红标识.EditValueChanged += new System.EventHandler(this.radioGroup蓝红标识_EditValueChanged);
            // 
            // layoutControl1
            // 
            this.layoutControl1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.layoutControl1.Controls.Add(this.lookUpEdit销售类型);
            this.layoutControl1.Controls.Add(this.buttonEdit客户);
            this.layoutControl1.Controls.Add(this.radioGroup蓝红标识);
            this.layoutControl1.Controls.Add(this.gridControl1);
            this.layoutControl1.Controls.Add(this.lookUpEdit客户);
            this.layoutControl1.Location = new System.Drawing.Point(-3, 12);
            this.layoutControl1.Name = "layoutControl1";
            this.layoutControl1.OptionsCustomizationForm.DesignTimeCustomizationFormPositionAndSize = new System.Drawing.Rectangle(123, 171, 250, 350);
            this.layoutControl1.OptionsView.UseDefaultDragAndDropRendering = false;
            this.layoutControl1.Root = this.layoutControlGroup1;
            this.layoutControl1.Size = new System.Drawing.Size(872, 404);
            this.layoutControl1.TabIndex = 0;
            this.layoutControl1.Text = "layoutControl1";
            // 
            // lookUpEdit销售类型
            // 
            this.lookUpEdit销售类型.Location = new System.Drawing.Point(462, 12);
            this.lookUpEdit销售类型.Name = "lookUpEdit销售类型";
            this.lookUpEdit销售类型.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.lookUpEdit销售类型.Size = new System.Drawing.Size(83, 21);
            this.lookUpEdit销售类型.StyleController = this.layoutControl1;
            this.lookUpEdit销售类型.TabIndex = 63;
            // 
            // buttonEdit客户
            // 
            this.buttonEdit客户.Location = new System.Drawing.Point(64, 12);
            this.buttonEdit客户.Name = "buttonEdit客户";
            this.buttonEdit客户.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
            this.buttonEdit客户.Size = new System.Drawing.Size(93, 21);
            this.buttonEdit客户.StyleController = this.layoutControl1;
            this.buttonEdit客户.TabIndex = 62;
            this.buttonEdit客户.ButtonClick += new DevExpress.XtraEditors.Controls.ButtonPressedEventHandler(this.buttonEdit客户_ButtonClick);
            this.buttonEdit客户.EditValueChanged += new System.EventHandler(this.buttonEdit客户_EditValueChanged);
            this.buttonEdit客户.Leave += new System.EventHandler(this.buttonEdit客户_Leave);
            // 
            // lookUpEdit客户
            // 
            this.lookUpEdit客户.Enabled = false;
            this.lookUpEdit客户.Location = new System.Drawing.Point(161, 12);
            this.lookUpEdit客户.Name = "lookUpEdit客户";
            this.lookUpEdit客户.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.lookUpEdit客户.Size = new System.Drawing.Size(245, 21);
            this.lookUpEdit客户.StyleController = this.layoutControl1;
            this.lookUpEdit客户.TabIndex = 61;
            // 
            // layoutControlItem9
            // 
            this.layoutControlItem9.Control = this.lookUpEdit客户;
            this.layoutControlItem9.CustomizationFormText = "layoutControlItem9";
            this.layoutControlItem9.Location = new System.Drawing.Point(149, 0);
            this.layoutControlItem9.Name = "layoutControlItem9";
            this.layoutControlItem9.Size = new System.Drawing.Size(249, 29);
            this.layoutControlItem9.Text = "layoutControlItem9";
            this.layoutControlItem9.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem9.TextToControlDistance = 0;
            this.layoutControlItem9.TextVisible = false;
            // 
            // layoutControlItem11
            // 
            this.layoutControlItem11.Control = this.buttonEdit客户;
            this.layoutControlItem11.CustomizationFormText = "客户";
            this.layoutControlItem11.Location = new System.Drawing.Point(0, 0);
            this.layoutControlItem11.Name = "layoutControlItem11";
            this.layoutControlItem11.Size = new System.Drawing.Size(149, 29);
            this.layoutControlItem11.Text = "客户";
            this.layoutControlItem11.TextSize = new System.Drawing.Size(48, 14);
            // 
            // layoutControlItem1
            // 
            this.layoutControlItem1.Control = this.lookUpEdit销售类型;
            this.layoutControlItem1.CustomizationFormText = "销售类型";
            this.layoutControlItem1.Location = new System.Drawing.Point(398, 0);
            this.layoutControlItem1.MaxSize = new System.Drawing.Size(139, 29);
            this.layoutControlItem1.MinSize = new System.Drawing.Size(139, 29);
            this.layoutControlItem1.Name = "layoutControlItem1";
            this.layoutControlItem1.Size = new System.Drawing.Size(139, 29);
            this.layoutControlItem1.SizeConstraintsType = DevExpress.XtraLayout.SizeConstraintsType.Custom;
            this.layoutControlItem1.Text = "销售类型";
            this.layoutControlItem1.TextSize = new System.Drawing.Size(48, 14);
            // 
            // btnEnsure
            // 
            this.btnEnsure.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnEnsure.Location = new System.Drawing.Point(674, 419);
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
            this.button查询.Location = new System.Drawing.Point(579, 419);
            this.button查询.Name = "button查询";
            this.button查询.Size = new System.Drawing.Size(62, 23);
            this.button查询.TabIndex = 4;
            this.button查询.Text = "查 询";
            this.button查询.UseVisualStyleBackColor = true;
            this.button查询.Click += new System.EventHandler(this.button查询_Click);
            // 
            // layoutControlItem13
            // 
            this.layoutControlItem13.CustomizationFormText = "客户";
            this.layoutControlItem13.Location = new System.Drawing.Point(0, 0);
            this.layoutControlItem13.Name = "layoutControlItem13";
            this.layoutControlItem13.Size = new System.Drawing.Size(153, 29);
            this.layoutControlItem13.Text = "客户";
            this.layoutControlItem13.TextSize = new System.Drawing.Size(48, 14);
            this.layoutControlItem13.TextToControlDistance = 5;
            // 
            // Frm销售订单_New
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(866, 454);
            this.Controls.Add(this.button查询);
            this.Controls.Add(this.btnEnsure);
            this.Controls.Add(this.btnExit);
            this.Controls.Add(this.layoutControl1);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Frm销售订单_New";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "参照";
            this.Load += new System.EventHandler(this.Frm销售订单_New_Load);
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem17)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ItemLookUpEdit来源单据类型)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ItemLookUpEdit业务员)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ItemLookUpEdit部门)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem10)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radioGroup蓝红标识.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControl1)).EndInit();
            this.layoutControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.lookUpEdit销售类型.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.buttonEdit客户.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lookUpEdit客户.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem9)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem11)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem13)).EndInit();
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
        private DevExpress.XtraGrid.Columns.GridColumn gridCol来源单据号;
        private DevExpress.XtraGrid.Columns.GridColumn gridCol单据日期;
        private DevExpress.XtraGrid.Columns.GridColumn gridCol业务员;
        private DevExpress.XtraGrid.Columns.GridColumn gridCol部门;
        private DevExpress.XtraGrid.Columns.GridColumn gridCol金额;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem17;
        private System.Windows.Forms.Button button查询;
        private DevExpress.XtraEditors.ButtonEdit buttonEdit客户;
        private DevExpress.XtraEditors.RadioGroup radioGroup蓝红标识;
        private DevExpress.XtraEditors.LookUpEdit lookUpEdit客户;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem10;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem9;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem11;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem13;
        private DevExpress.XtraGrid.Columns.GridColumn gridCol应收金额;
        private DevExpress.XtraGrid.Columns.GridColumn gridCol来源单据类型;
        private DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit ItemLookUpEdit来源单据类型;
        private DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit ItemLookUpEdit业务员;
        private DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit ItemLookUpEdit部门;
        private DevExpress.XtraEditors.LookUpEdit lookUpEdit销售类型;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem1;
        private DevExpress.XtraGrid.Columns.GridColumn gridCol来源单据ID;
    }
}