namespace 销售
{
    partial class Frm销售订单业务费用历史_Add 
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
            this.layoutControlItem1 = new DevExpress.XtraLayout.LayoutControlItem();
            this.gridControl1 = new DevExpress.XtraGrid.GridControl();
            this.gridView1 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.gridColCID = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColID = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColiSave = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColSS1 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColSS2 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColSS3 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColDD1 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColDD2 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridCol业务费用 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColSS4 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColSS5 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.ItemButtonEditcInvCode = new DevExpress.XtraEditors.Repository.RepositoryItemButtonEdit();
            this.gridColSS5_1 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.ItemLookUpEditcInvName = new DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit();
            this.ItemCheckEditChk = new DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit();
            this.ItemLookUpEditcInvCode = new DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit();
            this.ItemLookUpEditcInvStd = new DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit();
            this.ItemLookUpEdit子件代码 = new DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit();
            this.ItemLookUpEdit存货分类 = new DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit();
            this.layoutControlItem2 = new DevExpress.XtraLayout.LayoutControlItem();
            this.textEdit数量 = new DevExpress.XtraEditors.TextEdit();
            this.layoutControl1 = new DevExpress.XtraLayout.LayoutControl();
            this.btnEnsure = new System.Windows.Forms.Button();
            this.btnDel = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ItemButtonEditcInvCode)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ItemLookUpEditcInvName)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ItemCheckEditChk)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ItemLookUpEditcInvCode)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ItemLookUpEditcInvStd)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ItemLookUpEdit子件代码)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ItemLookUpEdit存货分类)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.textEdit数量.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControl1)).BeginInit();
            this.layoutControl1.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnExit
            // 
            this.btnExit.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnExit.Location = new System.Drawing.Point(902, 346);
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
            this.layoutControlItem1,
            this.layoutControlItem2});
            this.layoutControlGroup1.Location = new System.Drawing.Point(0, 0);
            this.layoutControlGroup1.Name = "Root";
            this.layoutControlGroup1.Size = new System.Drawing.Size(1000, 331);
            this.layoutControlGroup1.Text = "Root";
            this.layoutControlGroup1.TextVisible = false;
            // 
            // layoutControlItem1
            // 
            this.layoutControlItem1.Control = this.gridControl1;
            this.layoutControlItem1.CustomizationFormText = "layoutControlItem1";
            this.layoutControlItem1.Location = new System.Drawing.Point(0, 25);
            this.layoutControlItem1.Name = "layoutControlItem1";
            this.layoutControlItem1.Size = new System.Drawing.Size(980, 286);
            this.layoutControlItem1.Text = "layoutControlItem1";
            this.layoutControlItem1.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem1.TextToControlDistance = 0;
            this.layoutControlItem1.TextVisible = false;
            // 
            // gridControl1
            // 
            this.gridControl1.Location = new System.Drawing.Point(12, 37);
            this.gridControl1.MainView = this.gridView1;
            this.gridControl1.Name = "gridControl1";
            this.gridControl1.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.ItemCheckEditChk,
            this.ItemLookUpEditcInvCode,
            this.ItemLookUpEditcInvName,
            this.ItemLookUpEditcInvStd,
            this.ItemButtonEditcInvCode,
            this.ItemLookUpEdit子件代码,
            this.ItemLookUpEdit存货分类});
            this.gridControl1.Size = new System.Drawing.Size(976, 282);
            this.gridControl1.TabIndex = 8;
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
            this.gridColCID,
            this.gridColID,
            this.gridColiSave,
            this.gridColSS1,
            this.gridColSS2,
            this.gridColSS3,
            this.gridColDD1,
            this.gridColDD2,
            this.gridCol业务费用,
            this.gridColSS4,
            this.gridColSS5,
            this.gridColSS5_1});
            this.gridView1.CustomizationFormBounds = new System.Drawing.Rectangle(950, 457, 216, 187);
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
            this.gridView1.OptionsView.ShowFooter = true;
            this.gridView1.OptionsView.ShowGroupPanel = false;
            this.gridView1.CustomDrawRowIndicator += new DevExpress.XtraGrid.Views.Grid.RowIndicatorCustomDrawEventHandler(this.gridView1_CustomDrawRowIndicator_1);
            this.gridView1.CellValueChanged += new DevExpress.XtraGrid.Views.Base.CellValueChangedEventHandler(this.gridView1_CellValueChanged);
            // 
            // gridColCID
            // 
            this.gridColCID.Caption = "AutoID";
            this.gridColCID.FieldName = "CID";
            this.gridColCID.Name = "gridColCID";
            this.gridColCID.OptionsColumn.AllowEdit = false;
            // 
            // gridColID
            // 
            this.gridColID.Caption = "ID";
            this.gridColID.FieldName = "ID";
            this.gridColID.Name = "gridColID";
            // 
            // gridColiSave
            // 
            this.gridColiSave.Caption = "iSave";
            this.gridColiSave.FieldName = "iSave";
            this.gridColiSave.Name = "gridColiSave";
            this.gridColiSave.OptionsColumn.AllowEdit = false;
            this.gridColiSave.Width = 31;
            // 
            // gridColSS1
            // 
            this.gridColSS1.Caption = "客户联系人";
            this.gridColSS1.FieldName = "SS1";
            this.gridColSS1.Name = "gridColSS1";
            this.gridColSS1.Visible = true;
            this.gridColSS1.VisibleIndex = 0;
            this.gridColSS1.Width = 104;
            // 
            // gridColSS2
            // 
            this.gridColSS2.Caption = "客户联系电话";
            this.gridColSS2.FieldName = "SS2";
            this.gridColSS2.Name = "gridColSS2";
            this.gridColSS2.Visible = true;
            this.gridColSS2.VisibleIndex = 1;
            this.gridColSS2.Width = 155;
            // 
            // gridColSS3
            // 
            this.gridColSS3.Caption = "客户地址";
            this.gridColSS3.FieldName = "SS3";
            this.gridColSS3.Name = "gridColSS3";
            this.gridColSS3.Visible = true;
            this.gridColSS3.VisibleIndex = 2;
            this.gridColSS3.Width = 155;
            // 
            // gridColDD1
            // 
            this.gridColDD1.Caption = "业务费用/公斤";
            this.gridColDD1.FieldName = "DD1";
            this.gridColDD1.Name = "gridColDD1";
            this.gridColDD1.Visible = true;
            this.gridColDD1.VisibleIndex = 5;
            this.gridColDD1.Width = 123;
            // 
            // gridColDD2
            // 
            this.gridColDD2.Caption = "数量（公斤）";
            this.gridColDD2.FieldName = "DD2";
            this.gridColDD2.Name = "gridColDD2";
            this.gridColDD2.Visible = true;
            this.gridColDD2.VisibleIndex = 6;
            this.gridColDD2.Width = 182;
            // 
            // gridCol业务费用
            // 
            this.gridCol业务费用.Caption = "业务费用";
            this.gridCol业务费用.FieldName = "sCount";
            this.gridCol业务费用.Name = "gridCol业务费用";
            this.gridCol业务费用.OptionsColumn.AllowEdit = false;
            this.gridCol业务费用.Summary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] {
            new DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum)});
            this.gridCol业务费用.Visible = true;
            this.gridCol业务费用.VisibleIndex = 7;
            // 
            // gridColSS4
            // 
            this.gridColSS4.Caption = "备注";
            this.gridColSS4.FieldName = "SS4";
            this.gridColSS4.Name = "gridColSS4";
            this.gridColSS4.Visible = true;
            this.gridColSS4.VisibleIndex = 8;
            this.gridColSS4.Width = 213;
            // 
            // gridColSS5
            // 
            this.gridColSS5.Caption = "存货编码";
            this.gridColSS5.ColumnEdit = this.ItemButtonEditcInvCode;
            this.gridColSS5.FieldName = "SS5";
            this.gridColSS5.Name = "gridColSS5";
            this.gridColSS5.Visible = true;
            this.gridColSS5.VisibleIndex = 3;
            // 
            // ItemButtonEditcInvCode
            // 
            this.ItemButtonEditcInvCode.AutoHeight = false;
            this.ItemButtonEditcInvCode.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
            this.ItemButtonEditcInvCode.Name = "ItemButtonEditcInvCode";
            this.ItemButtonEditcInvCode.Leave += new System.EventHandler(this.ItemButtonEditcInvCode_Leave);
            this.ItemButtonEditcInvCode.ButtonClick += new DevExpress.XtraEditors.Controls.ButtonPressedEventHandler(this.ItemButtonEditcInvCode_ButtonClick);
            this.ItemButtonEditcInvCode.EditValueChanged += new System.EventHandler(this.ItemButtonEditcInvCode_EditValueChanged);
            // 
            // gridColSS5_1
            // 
            this.gridColSS5_1.Caption = "存货名称";
            this.gridColSS5_1.ColumnEdit = this.ItemLookUpEditcInvName;
            this.gridColSS5_1.FieldName = "SS5";
            this.gridColSS5_1.Name = "gridColSS5_1";
            this.gridColSS5_1.OptionsColumn.AllowEdit = false;
            this.gridColSS5_1.Visible = true;
            this.gridColSS5_1.VisibleIndex = 4;
            // 
            // ItemLookUpEditcInvName
            // 
            this.ItemLookUpEditcInvName.AutoHeight = false;
            this.ItemLookUpEditcInvName.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.ItemLookUpEditcInvName.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("cInvCode", "物料编码"),
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("cInvName", "物料名称"),
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("cInvStd", "规格型号")});
            this.ItemLookUpEditcInvName.DisplayMember = "cInvName";
            this.ItemLookUpEditcInvName.Name = "ItemLookUpEditcInvName";
            this.ItemLookUpEditcInvName.NullText = "";
            this.ItemLookUpEditcInvName.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.Standard;
            this.ItemLookUpEditcInvName.ValueMember = "cInvCode";
            // 
            // ItemCheckEditChk
            // 
            this.ItemCheckEditChk.AutoHeight = false;
            this.ItemCheckEditChk.Name = "ItemCheckEditChk";
            // 
            // ItemLookUpEditcInvCode
            // 
            this.ItemLookUpEditcInvCode.AutoHeight = false;
            this.ItemLookUpEditcInvCode.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.ItemLookUpEditcInvCode.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("cInvCode", "物料编码"),
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("cInvName", "物料名称"),
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("cInvStd", "规格型号")});
            this.ItemLookUpEditcInvCode.DisplayMember = "cInvCode";
            this.ItemLookUpEditcInvCode.Name = "ItemLookUpEditcInvCode";
            this.ItemLookUpEditcInvCode.NullText = "";
            this.ItemLookUpEditcInvCode.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.Standard;
            this.ItemLookUpEditcInvCode.ValueMember = "cInvCode";
            // 
            // ItemLookUpEditcInvStd
            // 
            this.ItemLookUpEditcInvStd.AutoHeight = false;
            this.ItemLookUpEditcInvStd.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.ItemLookUpEditcInvStd.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("cInvCode", "物料编码"),
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("cInvName", "物料名称"),
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("cInvStd", "规格型号")});
            this.ItemLookUpEditcInvStd.DisplayMember = "cInvStd";
            this.ItemLookUpEditcInvStd.Name = "ItemLookUpEditcInvStd";
            this.ItemLookUpEditcInvStd.NullText = "";
            this.ItemLookUpEditcInvStd.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.Standard;
            this.ItemLookUpEditcInvStd.ValueMember = "cInvCode";
            // 
            // ItemLookUpEdit子件代码
            // 
            this.ItemLookUpEdit子件代码.AutoHeight = false;
            this.ItemLookUpEdit子件代码.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.ItemLookUpEdit子件代码.Name = "ItemLookUpEdit子件代码";
            // 
            // ItemLookUpEdit存货分类
            // 
            this.ItemLookUpEdit存货分类.AutoHeight = false;
            this.ItemLookUpEdit存货分类.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.ItemLookUpEdit存货分类.Name = "ItemLookUpEdit存货分类";
            // 
            // layoutControlItem2
            // 
            this.layoutControlItem2.Control = this.textEdit数量;
            this.layoutControlItem2.CustomizationFormText = "数量";
            this.layoutControlItem2.Location = new System.Drawing.Point(0, 0);
            this.layoutControlItem2.Name = "layoutControlItem2";
            this.layoutControlItem2.Size = new System.Drawing.Size(980, 25);
            this.layoutControlItem2.Text = "数量";
            this.layoutControlItem2.TextSize = new System.Drawing.Size(24, 14);
            // 
            // textEdit数量
            // 
            this.textEdit数量.Enabled = false;
            this.textEdit数量.Location = new System.Drawing.Point(40, 12);
            this.textEdit数量.Name = "textEdit数量";
            this.textEdit数量.Size = new System.Drawing.Size(948, 21);
            this.textEdit数量.StyleController = this.layoutControl1;
            this.textEdit数量.TabIndex = 9;
            // 
            // layoutControl1
            // 
            this.layoutControl1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.layoutControl1.Controls.Add(this.textEdit数量);
            this.layoutControl1.Controls.Add(this.gridControl1);
            this.layoutControl1.Location = new System.Drawing.Point(-3, 12);
            this.layoutControl1.Name = "layoutControl1";
            this.layoutControl1.OptionsCustomizationForm.DesignTimeCustomizationFormPositionAndSize = new System.Drawing.Rectangle(123, 171, 250, 350);
            this.layoutControl1.OptionsView.UseDefaultDragAndDropRendering = false;
            this.layoutControl1.Root = this.layoutControlGroup1;
            this.layoutControl1.Size = new System.Drawing.Size(1000, 331);
            this.layoutControl1.TabIndex = 0;
            this.layoutControl1.Text = "layoutControl1";
            // 
            // btnEnsure
            // 
            this.btnEnsure.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnEnsure.Location = new System.Drawing.Point(747, 346);
            this.btnEnsure.Name = "btnEnsure";
            this.btnEnsure.Size = new System.Drawing.Size(62, 23);
            this.btnEnsure.TabIndex = 3;
            this.btnEnsure.Text = "确 定";
            this.btnEnsure.UseVisualStyleBackColor = true;
            this.btnEnsure.Click += new System.EventHandler(this.btnEnsure_Click);
            // 
            // btnDel
            // 
            this.btnDel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnDel.Location = new System.Drawing.Point(825, 346);
            this.btnDel.Name = "btnDel";
            this.btnDel.Size = new System.Drawing.Size(62, 23);
            this.btnDel.TabIndex = 4;
            this.btnDel.Text = "删 行";
            this.btnDel.UseVisualStyleBackColor = true;
            this.btnDel.Click += new System.EventHandler(this.btnDel_Click);
            // 
            // Frm销售订单业务费用_Add
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(994, 381);
            this.Controls.Add(this.btnDel);
            this.Controls.Add(this.btnEnsure);
            this.Controls.Add(this.btnExit);
            this.Controls.Add(this.layoutControl1);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Frm销售订单业务费用历史_Add";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "销售订单业务费用历史信息";
            this.Load += new System.EventHandler(this.Frm销售订单业务费用历史_Add_Load);
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ItemButtonEditcInvCode)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ItemLookUpEditcInvName)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ItemCheckEditChk)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ItemLookUpEditcInvCode)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ItemLookUpEditcInvStd)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ItemLookUpEdit子件代码)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ItemLookUpEdit存货分类)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.textEdit数量.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControl1)).EndInit();
            this.layoutControl1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnExit;
        private DevExpress.XtraLayout.LayoutControlGroup layoutControlGroup1;
        private DevExpress.XtraLayout.LayoutControl layoutControl1;
        private System.Windows.Forms.Button btnEnsure;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem1;
        private DevExpress.XtraGrid.GridControl gridControl1;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView1;
        private DevExpress.XtraGrid.Columns.GridColumn gridColCID;
        private DevExpress.XtraGrid.Columns.GridColumn gridColiSave;
        private DevExpress.XtraGrid.Columns.GridColumn gridColSS1;
        private DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit ItemLookUpEditcInvCode;
        private DevExpress.XtraGrid.Columns.GridColumn gridColSS2;
        private DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit ItemLookUpEditcInvName;
        private DevExpress.XtraGrid.Columns.GridColumn gridColSS3;
        private DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit ItemLookUpEditcInvStd;
        private DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit ItemCheckEditChk;
        private System.Windows.Forms.Button btnDel;
        private DevExpress.XtraEditors.Repository.RepositoryItemButtonEdit ItemButtonEditcInvCode;
        private DevExpress.XtraGrid.Columns.GridColumn gridColDD1;
        private DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit ItemLookUpEdit子件代码;
        private DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit ItemLookUpEdit存货分类;
        private DevExpress.XtraGrid.Columns.GridColumn gridColID;
        private DevExpress.XtraGrid.Columns.GridColumn gridColSS4;
        private DevExpress.XtraGrid.Columns.GridColumn gridColDD2;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem2;
        private DevExpress.XtraEditors.TextEdit textEdit数量;
        private DevExpress.XtraGrid.Columns.GridColumn gridCol业务费用;
        private DevExpress.XtraGrid.Columns.GridColumn gridColSS5;
        private DevExpress.XtraGrid.Columns.GridColumn gridColSS5_1;
    }
}