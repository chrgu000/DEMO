namespace 报表
{
    partial class Frm业务费申请汇总
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
            this.gridColiID = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColiSave = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColiCode = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColdDate = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColSS1 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColSS1_1 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.ItemLookUpEditSS1_1 = new DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit();
            this.gridColSS2 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColSS2_1 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.ItemLookUpEditSS2_1 = new DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit();
            this.gridColSS3 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColSS3_1 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.ItemLookUpEditSS3_1 = new DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit();
            this.gridColSS4 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColSS5 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.ItemLookUpEditSS5 = new DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit();
            this.gridColSS6 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColSS7 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColSS8 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColSS9 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColSS12 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColDD5 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColTT1 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColTT2 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColTT3 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColTT4 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColTT5 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColTT6 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColTT7 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColTT8 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColTT9 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.layoutControlGroup1 = new DevExpress.XtraLayout.LayoutControlGroup();
            this.layoutControlItem3 = new DevExpress.XtraLayout.LayoutControlItem();
            ((System.ComponentModel.ISupportInitialize)(this.dsPrint)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dsForm)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtSel)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControl1)).BeginInit();
            this.layoutControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ItemLookUpEditSS1_1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ItemLookUpEditSS2_1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ItemLookUpEditSS3_1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ItemLookUpEditSS5)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem3)).BeginInit();
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
            this.layoutControl1.OptionsView.UseDefaultDragAndDropRendering = false;
            this.layoutControl1.Root = this.layoutControlGroup1;
            this.layoutControl1.Size = new System.Drawing.Size(1286, 350);
            this.layoutControl1.TabIndex = 5;
            this.layoutControl1.Text = "layoutControl1";
            // 
            // gridControl1
            // 
            this.gridControl1.Location = new System.Drawing.Point(12, 12);
            this.gridControl1.MainView = this.gridView1;
            this.gridControl1.Name = "gridControl1";
            this.gridControl1.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.ItemLookUpEditSS1_1,
            this.ItemLookUpEditSS2_1,
            this.ItemLookUpEditSS3_1,
            this.ItemLookUpEditSS5});
            this.gridControl1.Size = new System.Drawing.Size(1262, 326);
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
            this.gridColiID,
            this.gridColiSave,
            this.gridColiCode,
            this.gridColdDate,
            this.gridColSS1,
            this.gridColSS1_1,
            this.gridColSS2,
            this.gridColSS2_1,
            this.gridColSS3,
            this.gridColSS3_1,
            this.gridColSS4,
            this.gridColSS5,
            this.gridColSS6,
            this.gridColSS7,
            this.gridColSS8,
            this.gridColSS9,
            this.gridColSS12,
            this.gridColDD5,
            this.gridColTT1,
            this.gridColTT2,
            this.gridColTT3,
            this.gridColTT4,
            this.gridColTT5,
            this.gridColTT6,
            this.gridColTT7,
            this.gridColTT8,
            this.gridColTT9});
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
            this.gridView1.CustomDrawRowIndicator += new DevExpress.XtraGrid.Views.Grid.RowIndicatorCustomDrawEventHandler(this.gridView1_CustomDrawRowIndicator);
            // 
            // gridColiID
            // 
            this.gridColiID.Caption = "iID";
            this.gridColiID.FieldName = "ID";
            this.gridColiID.Name = "gridColiID";
            this.gridColiID.OptionsColumn.AllowEdit = false;
            // 
            // gridColiSave
            // 
            this.gridColiSave.Caption = "编辑状态";
            this.gridColiSave.FieldName = "iSave";
            this.gridColiSave.Name = "gridColiSave";
            this.gridColiSave.OptionsColumn.AllowEdit = false;
            // 
            // gridColiCode
            // 
            this.gridColiCode.Caption = "单据号";
            this.gridColiCode.FieldName = "iCode";
            this.gridColiCode.Name = "gridColiCode";
            this.gridColiCode.OptionsColumn.AllowEdit = false;
            this.gridColiCode.Visible = true;
            this.gridColiCode.VisibleIndex = 3;
            // 
            // gridColdDate
            // 
            this.gridColdDate.Caption = "单据日期";
            this.gridColdDate.FieldName = "dDate";
            this.gridColdDate.Name = "gridColdDate";
            this.gridColdDate.OptionsColumn.AllowEdit = false;
            this.gridColdDate.Visible = true;
            this.gridColdDate.VisibleIndex = 2;
            // 
            // gridColSS1
            // 
            this.gridColSS1.Caption = "SS1";
            this.gridColSS1.FieldName = "SS1";
            this.gridColSS1.Name = "gridColSS1";
            this.gridColSS1.OptionsColumn.AllowEdit = false;
            // 
            // gridColSS1_1
            // 
            this.gridColSS1_1.Caption = "业务员";
            this.gridColSS1_1.ColumnEdit = this.ItemLookUpEditSS1_1;
            this.gridColSS1_1.FieldName = "SS1";
            this.gridColSS1_1.Name = "gridColSS1_1";
            this.gridColSS1_1.OptionsColumn.AllowEdit = false;
            this.gridColSS1_1.Visible = true;
            this.gridColSS1_1.VisibleIndex = 1;
            // 
            // ItemLookUpEditSS1_1
            // 
            this.ItemLookUpEditSS1_1.AutoHeight = false;
            this.ItemLookUpEditSS1_1.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.ItemLookUpEditSS1_1.Name = "ItemLookUpEditSS1_1";
            // 
            // gridColSS2
            // 
            this.gridColSS2.Caption = "SS2";
            this.gridColSS2.FieldName = "SS2";
            this.gridColSS2.Name = "gridColSS2";
            this.gridColSS2.OptionsColumn.AllowEdit = false;
            // 
            // gridColSS2_1
            // 
            this.gridColSS2_1.Caption = "部门";
            this.gridColSS2_1.ColumnEdit = this.ItemLookUpEditSS2_1;
            this.gridColSS2_1.FieldName = "SS2";
            this.gridColSS2_1.Name = "gridColSS2_1";
            this.gridColSS2_1.OptionsColumn.AllowEdit = false;
            this.gridColSS2_1.Visible = true;
            this.gridColSS2_1.VisibleIndex = 0;
            // 
            // ItemLookUpEditSS2_1
            // 
            this.ItemLookUpEditSS2_1.AutoHeight = false;
            this.ItemLookUpEditSS2_1.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.ItemLookUpEditSS2_1.Name = "ItemLookUpEditSS2_1";
            // 
            // gridColSS3
            // 
            this.gridColSS3.Caption = "SS3";
            this.gridColSS3.FieldName = "SS3";
            this.gridColSS3.Fixed = DevExpress.XtraGrid.Columns.FixedStyle.Left;
            this.gridColSS3.Name = "gridColSS3";
            this.gridColSS3.OptionsColumn.AllowEdit = false;
            // 
            // gridColSS3_1
            // 
            this.gridColSS3_1.Caption = "客户";
            this.gridColSS3_1.ColumnEdit = this.ItemLookUpEditSS3_1;
            this.gridColSS3_1.FieldName = "SS3";
            this.gridColSS3_1.Fixed = DevExpress.XtraGrid.Columns.FixedStyle.Left;
            this.gridColSS3_1.Name = "gridColSS3_1";
            this.gridColSS3_1.OptionsColumn.AllowEdit = false;
            this.gridColSS3_1.Width = 246;
            // 
            // ItemLookUpEditSS3_1
            // 
            this.ItemLookUpEditSS3_1.AutoHeight = false;
            this.ItemLookUpEditSS3_1.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.ItemLookUpEditSS3_1.Name = "ItemLookUpEditSS3_1";
            // 
            // gridColSS4
            // 
            this.gridColSS4.Caption = "SS4";
            this.gridColSS4.FieldName = "SS4";
            this.gridColSS4.Fixed = DevExpress.XtraGrid.Columns.FixedStyle.Left;
            this.gridColSS4.Name = "gridColSS4";
            this.gridColSS4.OptionsColumn.AllowEdit = false;
            this.gridColSS4.Width = 118;
            // 
            // gridColSS5
            // 
            this.gridColSS5.Caption = "SS5";
            this.gridColSS5.ColumnEdit = this.ItemLookUpEditSS5;
            this.gridColSS5.FieldName = "SS5";
            this.gridColSS5.Name = "gridColSS5";
            this.gridColSS5.OptionsColumn.AllowEdit = false;
            // 
            // ItemLookUpEditSS5
            // 
            this.ItemLookUpEditSS5.AutoHeight = false;
            this.ItemLookUpEditSS5.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.ItemLookUpEditSS5.Name = "ItemLookUpEditSS5";
            // 
            // gridColSS6
            // 
            this.gridColSS6.Caption = "SS6";
            this.gridColSS6.FieldName = "SS6";
            this.gridColSS6.Name = "gridColSS6";
            this.gridColSS6.OptionsColumn.AllowEdit = false;
            // 
            // gridColSS7
            // 
            this.gridColSS7.Caption = "SS7";
            this.gridColSS7.FieldName = "SS7";
            this.gridColSS7.Name = "gridColSS7";
            this.gridColSS7.OptionsColumn.AllowEdit = false;
            // 
            // gridColSS8
            // 
            this.gridColSS8.Caption = "SS8";
            this.gridColSS8.FieldName = "SS8";
            this.gridColSS8.Name = "gridColSS8";
            this.gridColSS8.OptionsColumn.AllowEdit = false;
            // 
            // gridColSS9
            // 
            this.gridColSS9.Caption = "SS9";
            this.gridColSS9.FieldName = "SS9";
            this.gridColSS9.Name = "gridColSS9";
            this.gridColSS9.OptionsColumn.AllowEdit = false;
            // 
            // gridColSS12
            // 
            this.gridColSS12.Caption = "费用类别";
            this.gridColSS12.FieldName = "SS12";
            this.gridColSS12.Name = "gridColSS12";
            // 
            // gridColDD5
            // 
            this.gridColDD5.Caption = "合计";
            this.gridColDD5.FieldName = "D5";
            this.gridColDD5.Name = "gridColDD5";
            this.gridColDD5.OptionsColumn.AllowEdit = false;
            this.gridColDD5.Summary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] {
            new DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum)});
            this.gridColDD5.Visible = true;
            this.gridColDD5.VisibleIndex = 4;
            // 
            // gridColTT1
            // 
            this.gridColTT1.Caption = "TT1";
            this.gridColTT1.FieldName = "TT1";
            this.gridColTT1.Name = "gridColTT1";
            this.gridColTT1.OptionsColumn.AllowEdit = false;
            // 
            // gridColTT2
            // 
            this.gridColTT2.Caption = "TT2";
            this.gridColTT2.FieldName = "TT2";
            this.gridColTT2.Name = "gridColTT2";
            this.gridColTT2.OptionsColumn.AllowEdit = false;
            // 
            // gridColTT3
            // 
            this.gridColTT3.Caption = "TT3";
            this.gridColTT3.FieldName = "TT3";
            this.gridColTT3.Name = "gridColTT3";
            this.gridColTT3.OptionsColumn.AllowEdit = false;
            // 
            // gridColTT4
            // 
            this.gridColTT4.Caption = "TT4";
            this.gridColTT4.FieldName = "TT4";
            this.gridColTT4.Name = "gridColTT4";
            this.gridColTT4.OptionsColumn.AllowEdit = false;
            // 
            // gridColTT5
            // 
            this.gridColTT5.Caption = "TT5";
            this.gridColTT5.FieldName = "TT5";
            this.gridColTT5.Name = "gridColTT5";
            this.gridColTT5.OptionsColumn.AllowEdit = false;
            // 
            // gridColTT6
            // 
            this.gridColTT6.Caption = "TT6";
            this.gridColTT6.FieldName = "TT6";
            this.gridColTT6.Name = "gridColTT6";
            this.gridColTT6.OptionsColumn.AllowEdit = false;
            // 
            // gridColTT7
            // 
            this.gridColTT7.Caption = "TT7";
            this.gridColTT7.FieldName = "TT7";
            this.gridColTT7.Name = "gridColTT7";
            this.gridColTT7.OptionsColumn.AllowEdit = false;
            // 
            // gridColTT8
            // 
            this.gridColTT8.Caption = "TT8";
            this.gridColTT8.FieldName = "TT8";
            this.gridColTT8.Name = "gridColTT8";
            this.gridColTT8.OptionsColumn.AllowEdit = false;
            // 
            // gridColTT9
            // 
            this.gridColTT9.Caption = "TT9";
            this.gridColTT9.FieldName = "TT9";
            this.gridColTT9.Name = "gridColTT9";
            this.gridColTT9.OptionsColumn.AllowEdit = false;
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
            this.layoutControlGroup1.Size = new System.Drawing.Size(1286, 350);
            this.layoutControlGroup1.Text = "Root";
            this.layoutControlGroup1.TextVisible = false;
            // 
            // layoutControlItem3
            // 
            this.layoutControlItem3.Control = this.gridControl1;
            this.layoutControlItem3.CustomizationFormText = "layoutControlItem3";
            this.layoutControlItem3.Location = new System.Drawing.Point(0, 0);
            this.layoutControlItem3.Name = "layoutControlItem3";
            this.layoutControlItem3.Size = new System.Drawing.Size(1266, 330);
            this.layoutControlItem3.Text = "layoutControlItem3";
            this.layoutControlItem3.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem3.TextToControlDistance = 0;
            this.layoutControlItem3.TextVisible = false;
            // 
            // Frm业务费申请汇总
            // 
            this.Appearance.BackColor = System.Drawing.SystemColors.Control;
            this.Appearance.Options.UseBackColor = true;
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1284, 379);
            this.Controls.Add(this.layoutControl1);
            this.Name = "Frm业务费申请汇总";
            this.Text = "业务费申请汇总";
            this.Load += new System.EventHandler(this.Frm业务费申请汇总_Load);
            this.Controls.SetChildIndex(this.layoutControl1, 0);
            ((System.ComponentModel.ISupportInitialize)(this.dsPrint)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dsForm)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtSel)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControl1)).EndInit();
            this.layoutControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ItemLookUpEditSS1_1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ItemLookUpEditSS2_1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ItemLookUpEditSS3_1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ItemLookUpEditSS5)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem3)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraLayout.LayoutControl layoutControl1;
        private DevExpress.XtraGrid.GridControl gridControl1;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView1;
        private DevExpress.XtraLayout.LayoutControlGroup layoutControlGroup1;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem3;
        private DevExpress.XtraGrid.Columns.GridColumn gridColiSave;
        private DevExpress.XtraGrid.Columns.GridColumn gridColiID;
        private DevExpress.XtraGrid.Columns.GridColumn gridColiCode;
        private DevExpress.XtraGrid.Columns.GridColumn gridColdDate;
        private DevExpress.XtraGrid.Columns.GridColumn gridColSS1;
        private DevExpress.XtraGrid.Columns.GridColumn gridColSS2;
        private DevExpress.XtraGrid.Columns.GridColumn gridColSS3;
        private DevExpress.XtraGrid.Columns.GridColumn gridColSS4;
        private DevExpress.XtraGrid.Columns.GridColumn gridColSS5;
        private DevExpress.XtraGrid.Columns.GridColumn gridColSS6;
        private DevExpress.XtraGrid.Columns.GridColumn gridColSS7;
        private DevExpress.XtraGrid.Columns.GridColumn gridColSS8;
        private DevExpress.XtraGrid.Columns.GridColumn gridColSS9;
        private DevExpress.XtraGrid.Columns.GridColumn gridColDD5;
        private DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit ItemLookUpEditSS1_1;
        private DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit ItemLookUpEditSS2_1;
        private DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit ItemLookUpEditSS3_1;
        private DevExpress.XtraGrid.Columns.GridColumn gridColTT1;
        private DevExpress.XtraGrid.Columns.GridColumn gridColTT2;
        private DevExpress.XtraGrid.Columns.GridColumn gridColTT3;
        private DevExpress.XtraGrid.Columns.GridColumn gridColTT4;
        private DevExpress.XtraGrid.Columns.GridColumn gridColTT5;
        private DevExpress.XtraGrid.Columns.GridColumn gridColTT6;
        private DevExpress.XtraGrid.Columns.GridColumn gridColTT7;
        private DevExpress.XtraGrid.Columns.GridColumn gridColTT8;
        private DevExpress.XtraGrid.Columns.GridColumn gridColTT9;
        private DevExpress.XtraGrid.Columns.GridColumn gridColSS1_1;
        private DevExpress.XtraGrid.Columns.GridColumn gridColSS2_1;
        private DevExpress.XtraGrid.Columns.GridColumn gridColSS3_1;
        private DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit ItemLookUpEditSS5;
        private DevExpress.XtraGrid.Columns.GridColumn gridColSS12;
    }
}