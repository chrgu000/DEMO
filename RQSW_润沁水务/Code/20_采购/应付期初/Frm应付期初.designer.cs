namespace 采购
{
    partial class Frm应付期初
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
            this.gridColiSave = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColiID = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColS1 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.ItemButtonEdit供应商 = new DevExpress.XtraEditors.Repository.RepositoryItemButtonEdit();
            this.gridColS2 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.ItemLookUpEdit供应商 = new DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit();
            this.gridColS3 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.ItemButtonEdit业务员 = new DevExpress.XtraEditors.Repository.RepositoryItemButtonEdit();
            this.gridColS4 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.ItemLookUpEdit业务员 = new DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit();
            this.gridColS5 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColS6 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColS7 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColS8 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColS9 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColS10 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColDate1 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColDate2 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColDate3 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColDate4 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColDate5 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColDate6 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColD1 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColD2 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColD3 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColD4 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColD5 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColD6 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColD7 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColD8 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColD9 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColD10 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.layoutControlGroup1 = new DevExpress.XtraLayout.LayoutControlGroup();
            this.layoutControlItem3 = new DevExpress.XtraLayout.LayoutControlItem();
            ((System.ComponentModel.ISupportInitialize)(this.dsPrint)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dsForm)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtSel)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControl1)).BeginInit();
            this.layoutControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ItemButtonEdit供应商)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ItemLookUpEdit供应商)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ItemButtonEdit业务员)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ItemLookUpEdit业务员)).BeginInit();
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
            this.layoutControl1.Size = new System.Drawing.Size(990, 322);
            this.layoutControl1.TabIndex = 5;
            this.layoutControl1.Text = "layoutControl1";
            // 
            // gridControl1
            // 
            this.gridControl1.Location = new System.Drawing.Point(12, 12);
            this.gridControl1.MainView = this.gridView1;
            this.gridControl1.Name = "gridControl1";
            this.gridControl1.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.ItemButtonEdit供应商,
            this.ItemButtonEdit业务员,
            this.ItemLookUpEdit供应商,
            this.ItemLookUpEdit业务员});
            this.gridControl1.Size = new System.Drawing.Size(966, 298);
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
            this.gridColiSave,
            this.gridColiID,
            this.gridColS1,
            this.gridColS2,
            this.gridColS3,
            this.gridColS4,
            this.gridColS5,
            this.gridColS6,
            this.gridColS7,
            this.gridColS8,
            this.gridColS9,
            this.gridColS10,
            this.gridColDate1,
            this.gridColDate2,
            this.gridColDate3,
            this.gridColDate4,
            this.gridColDate5,
            this.gridColDate6,
            this.gridColD1,
            this.gridColD2,
            this.gridColD3,
            this.gridColD4,
            this.gridColD5,
            this.gridColD6,
            this.gridColD7,
            this.gridColD8,
            this.gridColD9,
            this.gridColD10});
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
            this.gridView1.CellValueChanged += new DevExpress.XtraGrid.Views.Base.CellValueChangedEventHandler(this.gridView1_CellValueChanged);
            // 
            // gridColiSave
            // 
            this.gridColiSave.Caption = "编辑状态";
            this.gridColiSave.FieldName = "iSave";
            this.gridColiSave.Name = "gridColiSave";
            this.gridColiSave.OptionsColumn.AllowEdit = false;
            // 
            // gridColiID
            // 
            this.gridColiID.Caption = "iID";
            this.gridColiID.FieldName = "iID";
            this.gridColiID.Name = "gridColiID";
            this.gridColiID.OptionsColumn.AllowEdit = false;
            // 
            // gridColS1
            // 
            this.gridColS1.Caption = "供应商编码";
            this.gridColS1.ColumnEdit = this.ItemButtonEdit供应商;
            this.gridColS1.FieldName = "S1";
            this.gridColS1.Name = "gridColS1";
            this.gridColS1.Visible = true;
            this.gridColS1.VisibleIndex = 0;
            this.gridColS1.Width = 74;
            // 
            // ItemButtonEdit供应商
            // 
            this.ItemButtonEdit供应商.AutoHeight = false;
            this.ItemButtonEdit供应商.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
            this.ItemButtonEdit供应商.Name = "ItemButtonEdit供应商";
            this.ItemButtonEdit供应商.ButtonClick += new DevExpress.XtraEditors.Controls.ButtonPressedEventHandler(this.ItemButtonEdit供应商_ButtonClick);
            // 
            // gridColS2
            // 
            this.gridColS2.Caption = "供应商名称";
            this.gridColS2.ColumnEdit = this.ItemLookUpEdit供应商;
            this.gridColS2.FieldName = "S1";
            this.gridColS2.Name = "gridColS2";
            this.gridColS2.Visible = true;
            this.gridColS2.VisibleIndex = 1;
            this.gridColS2.Width = 235;
            // 
            // ItemLookUpEdit供应商
            // 
            this.ItemLookUpEdit供应商.AutoHeight = false;
            this.ItemLookUpEdit供应商.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.ItemLookUpEdit供应商.Name = "ItemLookUpEdit供应商";
            // 
            // gridColS3
            // 
            this.gridColS3.Caption = "业务员编码";
            this.gridColS3.ColumnEdit = this.ItemButtonEdit业务员;
            this.gridColS3.FieldName = "S3";
            this.gridColS3.Name = "gridColS3";
            this.gridColS3.Width = 102;
            // 
            // ItemButtonEdit业务员
            // 
            this.ItemButtonEdit业务员.AutoHeight = false;
            this.ItemButtonEdit业务员.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
            this.ItemButtonEdit业务员.Name = "ItemButtonEdit业务员";
            this.ItemButtonEdit业务员.ButtonClick += new DevExpress.XtraEditors.Controls.ButtonPressedEventHandler(this.ItemButtonEdit业务员_ButtonClick);
            // 
            // gridColS4
            // 
            this.gridColS4.Caption = "业务员";
            this.gridColS4.ColumnEdit = this.ItemLookUpEdit业务员;
            this.gridColS4.FieldName = "S3";
            this.gridColS4.Name = "gridColS4";
            this.gridColS4.Width = 99;
            // 
            // ItemLookUpEdit业务员
            // 
            this.ItemLookUpEdit业务员.AutoHeight = false;
            this.ItemLookUpEdit业务员.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.ItemLookUpEdit业务员.Name = "ItemLookUpEdit业务员";
            // 
            // gridColS5
            // 
            this.gridColS5.Caption = "S5";
            this.gridColS5.FieldName = "S5";
            this.gridColS5.Name = "gridColS5";
            // 
            // gridColS6
            // 
            this.gridColS6.Caption = "S6";
            this.gridColS6.FieldName = "S6";
            this.gridColS6.Name = "gridColS6";
            // 
            // gridColS7
            // 
            this.gridColS7.Caption = "S7";
            this.gridColS7.FieldName = "S7";
            this.gridColS7.Name = "gridColS7";
            // 
            // gridColS8
            // 
            this.gridColS8.Caption = "S8";
            this.gridColS8.FieldName = "S8";
            this.gridColS8.Name = "gridColS8";
            // 
            // gridColS9
            // 
            this.gridColS9.Caption = "S9";
            this.gridColS9.FieldName = "S9";
            this.gridColS9.Name = "gridColS9";
            // 
            // gridColS10
            // 
            this.gridColS10.Caption = "S10";
            this.gridColS10.FieldName = "S10";
            this.gridColS10.Name = "gridColS10";
            // 
            // gridColDate1
            // 
            this.gridColDate1.Caption = "账款日期";
            this.gridColDate1.FieldName = "Date1";
            this.gridColDate1.Name = "gridColDate1";
            this.gridColDate1.Visible = true;
            this.gridColDate1.VisibleIndex = 2;
            this.gridColDate1.Width = 115;
            // 
            // gridColDate2
            // 
            this.gridColDate2.Caption = "Date2";
            this.gridColDate2.FieldName = "Date2";
            this.gridColDate2.Name = "gridColDate2";
            this.gridColDate2.Width = 122;
            // 
            // gridColDate3
            // 
            this.gridColDate3.Caption = "Date3";
            this.gridColDate3.FieldName = "Date3";
            this.gridColDate3.Name = "gridColDate3";
            this.gridColDate3.Width = 133;
            // 
            // gridColDate4
            // 
            this.gridColDate4.Caption = "Date4";
            this.gridColDate4.FieldName = "Date4";
            this.gridColDate4.Name = "gridColDate4";
            // 
            // gridColDate5
            // 
            this.gridColDate5.Caption = "Date5";
            this.gridColDate5.FieldName = "Date5";
            this.gridColDate5.Name = "gridColDate5";
            // 
            // gridColDate6
            // 
            this.gridColDate6.Caption = "Date6";
            this.gridColDate6.FieldName = "Date6";
            this.gridColDate6.Name = "gridColDate6";
            // 
            // gridColD1
            // 
            this.gridColD1.Caption = "应付金额";
            this.gridColD1.FieldName = "D1";
            this.gridColD1.Name = "gridColD1";
            this.gridColD1.Summary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] {
            new DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum)});
            this.gridColD1.Visible = true;
            this.gridColD1.VisibleIndex = 3;
            this.gridColD1.Width = 110;
            // 
            // gridColD2
            // 
            this.gridColD2.Caption = "采购期初余额";
            this.gridColD2.FieldName = "D2";
            this.gridColD2.Name = "gridColD2";
            this.gridColD2.Summary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] {
            new DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum)});
            this.gridColD2.Visible = true;
            this.gridColD2.VisibleIndex = 4;
            this.gridColD2.Width = 111;
            // 
            // gridColD3
            // 
            this.gridColD3.Caption = "D3";
            this.gridColD3.FieldName = "D3";
            this.gridColD3.Name = "gridColD3";
            // 
            // gridColD4
            // 
            this.gridColD4.Caption = "D4";
            this.gridColD4.FieldName = "D4";
            this.gridColD4.Name = "gridColD4";
            // 
            // gridColD5
            // 
            this.gridColD5.Caption = "D5";
            this.gridColD5.FieldName = "D5";
            this.gridColD5.Name = "gridColD5";
            // 
            // gridColD6
            // 
            this.gridColD6.Caption = "D6";
            this.gridColD6.FieldName = "D6";
            this.gridColD6.Name = "gridColD6";
            // 
            // gridColD7
            // 
            this.gridColD7.Caption = "D7";
            this.gridColD7.FieldName = "D7";
            this.gridColD7.Name = "gridColD7";
            // 
            // gridColD8
            // 
            this.gridColD8.Caption = "D8";
            this.gridColD8.FieldName = "D8";
            this.gridColD8.Name = "gridColD8";
            // 
            // gridColD9
            // 
            this.gridColD9.Caption = "D9";
            this.gridColD9.FieldName = "D9";
            this.gridColD9.Name = "gridColD9";
            // 
            // gridColD10
            // 
            this.gridColD10.Caption = "D10";
            this.gridColD10.FieldName = "D10";
            this.gridColD10.Name = "gridColD10";
            this.gridColD10.Width = 122;
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
            this.layoutControlGroup1.Size = new System.Drawing.Size(990, 322);
            this.layoutControlGroup1.Text = "Root";
            this.layoutControlGroup1.TextVisible = false;
            // 
            // layoutControlItem3
            // 
            this.layoutControlItem3.Control = this.gridControl1;
            this.layoutControlItem3.CustomizationFormText = "layoutControlItem3";
            this.layoutControlItem3.Location = new System.Drawing.Point(0, 0);
            this.layoutControlItem3.Name = "layoutControlItem3";
            this.layoutControlItem3.Size = new System.Drawing.Size(970, 302);
            this.layoutControlItem3.Text = "layoutControlItem3";
            this.layoutControlItem3.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem3.TextToControlDistance = 0;
            this.layoutControlItem3.TextVisible = false;
            // 
            // Frm应付期初
            // 
            this.Appearance.BackColor = System.Drawing.SystemColors.Control;
            this.Appearance.Options.UseBackColor = true;
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(988, 351);
            this.Controls.Add(this.layoutControl1);
            this.Name = "Frm应付期初";
            this.Text = "应付期初";
            this.Load += new System.EventHandler(this.Frm应付期初_Load);
            this.Controls.SetChildIndex(this.layoutControl1, 0);
            ((System.ComponentModel.ISupportInitialize)(this.dsPrint)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dsForm)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtSel)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControl1)).EndInit();
            this.layoutControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ItemButtonEdit供应商)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ItemLookUpEdit供应商)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ItemButtonEdit业务员)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ItemLookUpEdit业务员)).EndInit();
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
        private DevExpress.XtraGrid.Columns.GridColumn gridColS1;
        private DevExpress.XtraGrid.Columns.GridColumn gridColS2;
        private DevExpress.XtraGrid.Columns.GridColumn gridColDate1;
        private DevExpress.XtraGrid.Columns.GridColumn gridColS3;
        private DevExpress.XtraGrid.Columns.GridColumn gridColS4;
        private DevExpress.XtraGrid.Columns.GridColumn gridColDate2;
        private DevExpress.XtraGrid.Columns.GridColumn gridColDate3;
        private DevExpress.XtraGrid.Columns.GridColumn gridColS5;
        private DevExpress.XtraGrid.Columns.GridColumn gridColS6;
        private DevExpress.XtraGrid.Columns.GridColumn gridColS7;
        private DevExpress.XtraGrid.Columns.GridColumn gridColS8;
        private DevExpress.XtraGrid.Columns.GridColumn gridColS9;
        private DevExpress.XtraGrid.Columns.GridColumn gridColS10;
        private DevExpress.XtraGrid.Columns.GridColumn gridColDate4;
        private DevExpress.XtraGrid.Columns.GridColumn gridColDate5;
        private DevExpress.XtraEditors.Repository.RepositoryItemButtonEdit ItemButtonEdit供应商;
        private DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit ItemLookUpEdit供应商;
        private DevExpress.XtraEditors.Repository.RepositoryItemButtonEdit ItemButtonEdit业务员;
        private DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit ItemLookUpEdit业务员;
        private DevExpress.XtraGrid.Columns.GridColumn gridColD1;
        private DevExpress.XtraGrid.Columns.GridColumn gridColD2;
        private DevExpress.XtraGrid.Columns.GridColumn gridColD3;
        private DevExpress.XtraGrid.Columns.GridColumn gridColD4;
        private DevExpress.XtraGrid.Columns.GridColumn gridColD5;
        private DevExpress.XtraGrid.Columns.GridColumn gridColD6;
        private DevExpress.XtraGrid.Columns.GridColumn gridColD7;
        private DevExpress.XtraGrid.Columns.GridColumn gridColD8;
        private DevExpress.XtraGrid.Columns.GridColumn gridColD9;
        private DevExpress.XtraGrid.Columns.GridColumn gridColD10;
        private DevExpress.XtraGrid.Columns.GridColumn gridColDate6;
    }
}