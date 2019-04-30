namespace 销售
{
    partial class Frm未核销收款单_New 
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
            this.gridCol选择 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridCol单据号 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridCol单据日期 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridCol业务员 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.ItemLookUpEdit业务员 = new DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit();
            this.gridCol部门 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.ItemLookUpEdit部门 = new DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit();
            this.gridCol客户 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.ItemLookUpEdit客户 = new DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit();
            this.gridCol销售类型 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.ItemLookUpEdit销售类型 = new DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit();
            this.gridCol含税金额 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridCol来源类型 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.ItemLookUpEdit来源类型 = new DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit();
            this.ItemCheckEditChk = new DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit();
            this.layoutControl1 = new DevExpress.XtraLayout.LayoutControl();
            this.btnEnsure = new System.Windows.Forms.Button();
            this.layoutControlItem9 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem12 = new DevExpress.XtraLayout.LayoutControlItem();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem17)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ItemLookUpEdit业务员)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ItemLookUpEdit部门)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ItemLookUpEdit客户)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ItemLookUpEdit销售类型)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ItemLookUpEdit来源类型)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ItemCheckEditChk)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControl1)).BeginInit();
            this.layoutControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem9)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem12)).BeginInit();
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
            this.layoutControlItem17});
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
            this.layoutControlItem17.Location = new System.Drawing.Point(0, 0);
            this.layoutControlItem17.Name = "layoutControlItem17";
            this.layoutControlItem17.Size = new System.Drawing.Size(762, 359);
            this.layoutControlItem17.Text = "layoutControlItem17";
            this.layoutControlItem17.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem17.TextToControlDistance = 0;
            this.layoutControlItem17.TextVisible = false;
            // 
            // gridControl1
            // 
            this.gridControl1.Location = new System.Drawing.Point(12, 12);
            this.gridControl1.MainView = this.gridView1;
            this.gridControl1.Name = "gridControl1";
            this.gridControl1.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.ItemCheckEditChk,
            this.ItemLookUpEdit业务员,
            this.ItemLookUpEdit部门,
            this.ItemLookUpEdit客户,
            this.ItemLookUpEdit销售类型,
            this.ItemLookUpEdit来源类型});
            this.gridControl1.Size = new System.Drawing.Size(758, 355);
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
            this.gridCol选择,
            this.gridCol单据号,
            this.gridCol单据日期,
            this.gridCol业务员,
            this.gridCol部门,
            this.gridCol客户,
            this.gridCol销售类型,
            this.gridCol含税金额,
            this.gridCol来源类型});
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
            this.gridCol单据号.Caption = "单据号";
            this.gridCol单据号.FieldName = "cSOCCode";
            this.gridCol单据号.Name = "gridCol单据号";
            this.gridCol单据号.Visible = true;
            this.gridCol单据号.VisibleIndex = 1;
            this.gridCol单据号.Width = 112;
            // 
            // gridCol单据日期
            // 
            this.gridCol单据日期.Caption = "单据日期";
            this.gridCol单据日期.DisplayFormat.FormatString = "yyyy-MM-dd";
            this.gridCol单据日期.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.gridCol单据日期.FieldName = "dDate";
            this.gridCol单据日期.Name = "gridCol单据日期";
            this.gridCol单据日期.Visible = true;
            this.gridCol单据日期.VisibleIndex = 2;
            this.gridCol单据日期.Width = 92;
            // 
            // gridCol业务员
            // 
            this.gridCol业务员.Caption = "业务员";
            this.gridCol业务员.ColumnEdit = this.ItemLookUpEdit业务员;
            this.gridCol业务员.FieldName = "cPersonCode";
            this.gridCol业务员.Name = "gridCol业务员";
            this.gridCol业务员.Visible = true;
            this.gridCol业务员.VisibleIndex = 3;
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
            this.gridCol部门.VisibleIndex = 4;
            // 
            // ItemLookUpEdit部门
            // 
            this.ItemLookUpEdit部门.AutoHeight = false;
            this.ItemLookUpEdit部门.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.ItemLookUpEdit部门.Name = "ItemLookUpEdit部门";
            // 
            // gridCol客户
            // 
            this.gridCol客户.Caption = "客户";
            this.gridCol客户.ColumnEdit = this.ItemLookUpEdit客户;
            this.gridCol客户.FieldName = "cCusCode";
            this.gridCol客户.Name = "gridCol客户";
            this.gridCol客户.Visible = true;
            this.gridCol客户.VisibleIndex = 5;
            // 
            // ItemLookUpEdit客户
            // 
            this.ItemLookUpEdit客户.AutoHeight = false;
            this.ItemLookUpEdit客户.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.ItemLookUpEdit客户.Name = "ItemLookUpEdit客户";
            // 
            // gridCol销售类型
            // 
            this.gridCol销售类型.Caption = "销售类型";
            this.gridCol销售类型.ColumnEdit = this.ItemLookUpEdit销售类型;
            this.gridCol销售类型.FieldName = "cSTCode";
            this.gridCol销售类型.Name = "gridCol销售类型";
            this.gridCol销售类型.Visible = true;
            this.gridCol销售类型.VisibleIndex = 6;
            // 
            // ItemLookUpEdit销售类型
            // 
            this.ItemLookUpEdit销售类型.AutoHeight = false;
            this.ItemLookUpEdit销售类型.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.ItemLookUpEdit销售类型.Name = "ItemLookUpEdit销售类型";
            // 
            // gridCol含税金额
            // 
            this.gridCol含税金额.Caption = "含税金额";
            this.gridCol含税金额.FieldName = "iAmount";
            this.gridCol含税金额.Name = "gridCol含税金额";
            this.gridCol含税金额.Summary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] {
            new DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum)});
            this.gridCol含税金额.Visible = true;
            this.gridCol含税金额.VisibleIndex = 7;
            // 
            // gridCol来源类型
            // 
            this.gridCol来源类型.Caption = "来源类型";
            this.gridCol来源类型.ColumnEdit = this.ItemLookUpEdit来源类型;
            this.gridCol来源类型.FieldName = "iType";
            this.gridCol来源类型.Name = "gridCol来源类型";
            this.gridCol来源类型.Visible = true;
            this.gridCol来源类型.VisibleIndex = 8;
            // 
            // ItemLookUpEdit来源类型
            // 
            this.ItemLookUpEdit来源类型.AutoHeight = false;
            this.ItemLookUpEdit来源类型.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.ItemLookUpEdit来源类型.Name = "ItemLookUpEdit来源类型";
            // 
            // ItemCheckEditChk
            // 
            this.ItemCheckEditChk.AutoHeight = false;
            this.ItemCheckEditChk.Name = "ItemCheckEditChk";
            this.ItemCheckEditChk.NullText = "0";
            // 
            // layoutControl1
            // 
            this.layoutControl1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
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
            // layoutControlItem9
            // 
            this.layoutControlItem9.CustomizationFormText = "供应商";
            this.layoutControlItem9.Location = new System.Drawing.Point(0, 0);
            this.layoutControlItem9.Name = "layoutControlItem7";
            this.layoutControlItem9.Size = new System.Drawing.Size(173, 29);
            this.layoutControlItem9.Text = "供应商";
            this.layoutControlItem9.TextSize = new System.Drawing.Size(48, 14);
            this.layoutControlItem9.TextToControlDistance = 5;
            // 
            // layoutControlItem12
            // 
            this.layoutControlItem12.CustomizationFormText = "供应商";
            this.layoutControlItem12.Location = new System.Drawing.Point(0, 0);
            this.layoutControlItem12.Name = "layoutControlItem7";
            this.layoutControlItem12.Size = new System.Drawing.Size(173, 29);
            this.layoutControlItem12.Text = "供应商";
            this.layoutControlItem12.TextSize = new System.Drawing.Size(48, 14);
            this.layoutControlItem12.TextToControlDistance = 5;
            // 
            // Frm未核销收款单_New
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(776, 429);
            this.Controls.Add(this.btnEnsure);
            this.Controls.Add(this.btnExit);
            this.Controls.Add(this.layoutControl1);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Frm未核销收款单_New";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "未核销收款单";
            this.Load += new System.EventHandler(this.未核销收款单_New_Load);
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem17)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ItemLookUpEdit业务员)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ItemLookUpEdit部门)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ItemLookUpEdit客户)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ItemLookUpEdit销售类型)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ItemLookUpEdit来源类型)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ItemCheckEditChk)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControl1)).EndInit();
            this.layoutControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem9)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem12)).EndInit();
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
        private DevExpress.XtraGrid.Columns.GridColumn gridCol选择;
        private DevExpress.XtraGrid.Columns.GridColumn gridCol单据号;
        private DevExpress.XtraGrid.Columns.GridColumn gridCol单据日期;
        private DevExpress.XtraGrid.Columns.GridColumn gridCol业务员;
        private DevExpress.XtraGrid.Columns.GridColumn gridCol部门;
        private DevExpress.XtraGrid.Columns.GridColumn gridCol客户;
        private DevExpress.XtraGrid.Columns.GridColumn gridCol销售类型;
        private DevExpress.XtraGrid.Columns.GridColumn gridCol含税金额;
        private DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit ItemCheckEditChk;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem17;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem9;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem12;
        private DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit ItemLookUpEdit业务员;
        private DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit ItemLookUpEdit部门;
        private DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit ItemLookUpEdit客户;
        private DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit ItemLookUpEdit销售类型;
        private DevExpress.XtraGrid.Columns.GridColumn gridCol来源类型;
        private DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit ItemLookUpEdit来源类型;
    }
}