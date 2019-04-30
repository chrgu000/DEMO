namespace WorkInformation
{
    partial class Frm生产手工计划
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
            this.gridCol时间戳 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridCol编辑状态 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridCol物料编码 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.ItemLookUpEdit物料编码 = new DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit();
            this.gridCol物料名称 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.ItemLookUpEdit物料名称 = new DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit();
            this.gridCol规格型号 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.ItemLookUpEdit规格型号 = new DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit();
            this.gridCol销售订单号 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.ItemLookUpEdit销售订单号 = new DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit();
            this.gridCol行号 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridCol数量 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridCol完工日期 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridCol备注 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColiID = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridCol产品编码 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridCol产品名称 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridCol产品规格 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.layoutControlGroup1 = new DevExpress.XtraLayout.LayoutControlGroup();
            this.layoutControlItem3 = new DevExpress.XtraLayout.LayoutControlItem();
            ((System.ComponentModel.ISupportInitialize)(this.dsPrint)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dsForm)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtSel)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControl1)).BeginInit();
            this.layoutControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ItemLookUpEdit物料编码)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ItemLookUpEdit物料名称)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ItemLookUpEdit规格型号)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ItemLookUpEdit销售订单号)).BeginInit();
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
            this.layoutControl1.Root = this.layoutControlGroup1;
            this.layoutControl1.Size = new System.Drawing.Size(916, 376);
            this.layoutControl1.TabIndex = 5;
            this.layoutControl1.Text = "layoutControl1";
            // 
            // gridControl1
            // 
            this.gridControl1.Location = new System.Drawing.Point(12, 29);
            this.gridControl1.MainView = this.gridView1;
            this.gridControl1.Name = "gridControl1";
            this.gridControl1.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.ItemLookUpEdit销售订单号,
            this.ItemLookUpEdit物料编码,
            this.ItemLookUpEdit物料名称,
            this.ItemLookUpEdit规格型号});
            this.gridControl1.Size = new System.Drawing.Size(892, 335);
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
            this.gridCol时间戳,
            this.gridCol编辑状态,
            this.gridCol物料编码,
            this.gridCol物料名称,
            this.gridCol规格型号,
            this.gridCol销售订单号,
            this.gridCol行号,
            this.gridCol数量,
            this.gridCol完工日期,
            this.gridCol备注,
            this.gridColiID,
            this.gridCol产品编码,
            this.gridCol产品名称,
            this.gridCol产品规格});
            this.gridView1.GridControl = this.gridControl1;
            this.gridView1.IndicatorWidth = 40;
            this.gridView1.Name = "gridView1";
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
            this.gridView1.FocusedRowChanged += new DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventHandler(this.gridView1_FocusedRowChanged);
            this.gridView1.CustomDrawRowIndicator += new DevExpress.XtraGrid.Views.Grid.RowIndicatorCustomDrawEventHandler(this.gridView1_CustomDrawRowIndicator);
            this.gridView1.CellValueChanged += new DevExpress.XtraGrid.Views.Base.CellValueChangedEventHandler(this.gridView1_CellValueChanged);
            // 
            // gridCol时间戳
            // 
            this.gridCol时间戳.Caption = "时间戳";
            this.gridCol时间戳.FieldName = "时间戳";
            this.gridCol时间戳.Name = "gridCol时间戳";
            this.gridCol时间戳.OptionsColumn.AllowEdit = false;
            this.gridCol时间戳.Width = 434;
            // 
            // gridCol编辑状态
            // 
            this.gridCol编辑状态.Caption = "编辑状态";
            this.gridCol编辑状态.FieldName = "编辑状态";
            this.gridCol编辑状态.Name = "gridCol编辑状态";
            this.gridCol编辑状态.OptionsColumn.AllowEdit = false;
            // 
            // gridCol物料编码
            // 
            this.gridCol物料编码.Caption = "物料编码";
            this.gridCol物料编码.ColumnEdit = this.ItemLookUpEdit物料编码;
            this.gridCol物料编码.FieldName = "物料编码";
            this.gridCol物料编码.Name = "gridCol物料编码";
            this.gridCol物料编码.OptionsColumn.AllowMerge = DevExpress.Utils.DefaultBoolean.False;
            this.gridCol物料编码.Visible = true;
            this.gridCol物料编码.VisibleIndex = 2;
            this.gridCol物料编码.Width = 118;
            // 
            // ItemLookUpEdit物料编码
            // 
            this.ItemLookUpEdit物料编码.AutoHeight = false;
            this.ItemLookUpEdit物料编码.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.ItemLookUpEdit物料编码.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("cInvCode", "物料编码"),
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("cInvName", "物料名称"),
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("cInvStd", "规格型号")});
            this.ItemLookUpEdit物料编码.DisplayMember = "cInvCode";
            this.ItemLookUpEdit物料编码.Name = "ItemLookUpEdit物料编码";
            this.ItemLookUpEdit物料编码.NullText = "";
            this.ItemLookUpEdit物料编码.PopupWidth = 600;
            this.ItemLookUpEdit物料编码.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.Standard;
            this.ItemLookUpEdit物料编码.ValueMember = "cInvCode";
            // 
            // gridCol物料名称
            // 
            this.gridCol物料名称.Caption = "物料名称";
            this.gridCol物料名称.ColumnEdit = this.ItemLookUpEdit物料名称;
            this.gridCol物料名称.FieldName = "物料编码";
            this.gridCol物料名称.Name = "gridCol物料名称";
            this.gridCol物料名称.OptionsColumn.AllowEdit = false;
            this.gridCol物料名称.OptionsColumn.AllowMerge = DevExpress.Utils.DefaultBoolean.False;
            this.gridCol物料名称.Visible = true;
            this.gridCol物料名称.VisibleIndex = 3;
            this.gridCol物料名称.Width = 117;
            // 
            // ItemLookUpEdit物料名称
            // 
            this.ItemLookUpEdit物料名称.AutoHeight = false;
            this.ItemLookUpEdit物料名称.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.ItemLookUpEdit物料名称.DisplayMember = "cInvName";
            this.ItemLookUpEdit物料名称.Name = "ItemLookUpEdit物料名称";
            this.ItemLookUpEdit物料名称.NullText = "";
            this.ItemLookUpEdit物料名称.ValueMember = "cInvCode";
            // 
            // gridCol规格型号
            // 
            this.gridCol规格型号.Caption = "规格型号";
            this.gridCol规格型号.ColumnEdit = this.ItemLookUpEdit规格型号;
            this.gridCol规格型号.FieldName = "物料编码";
            this.gridCol规格型号.Name = "gridCol规格型号";
            this.gridCol规格型号.OptionsColumn.AllowEdit = false;
            this.gridCol规格型号.Visible = true;
            this.gridCol规格型号.VisibleIndex = 4;
            this.gridCol规格型号.Width = 101;
            // 
            // ItemLookUpEdit规格型号
            // 
            this.ItemLookUpEdit规格型号.AutoHeight = false;
            this.ItemLookUpEdit规格型号.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.ItemLookUpEdit规格型号.DisplayMember = "cInvStd";
            this.ItemLookUpEdit规格型号.Name = "ItemLookUpEdit规格型号";
            this.ItemLookUpEdit规格型号.NullText = "";
            this.ItemLookUpEdit规格型号.ValueMember = "cInvCode";
            // 
            // gridCol销售订单号
            // 
            this.gridCol销售订单号.Caption = "销售订单号";
            this.gridCol销售订单号.ColumnEdit = this.ItemLookUpEdit销售订单号;
            this.gridCol销售订单号.FieldName = "销售订单号";
            this.gridCol销售订单号.Name = "gridCol销售订单号";
            this.gridCol销售订单号.Visible = true;
            this.gridCol销售订单号.VisibleIndex = 0;
            this.gridCol销售订单号.Width = 135;
            // 
            // ItemLookUpEdit销售订单号
            // 
            this.ItemLookUpEdit销售订单号.AutoHeight = false;
            this.ItemLookUpEdit销售订单号.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.ItemLookUpEdit销售订单号.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("cSOCode", "销售订单号")});
            this.ItemLookUpEdit销售订单号.DisplayMember = "cSOCode";
            this.ItemLookUpEdit销售订单号.Name = "ItemLookUpEdit销售订单号";
            this.ItemLookUpEdit销售订单号.NullText = "";
            this.ItemLookUpEdit销售订单号.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.Standard;
            this.ItemLookUpEdit销售订单号.ValueMember = "cSOCode";
            // 
            // gridCol行号
            // 
            this.gridCol行号.Caption = "行号";
            this.gridCol行号.FieldName = "行号";
            this.gridCol行号.Name = "gridCol行号";
            this.gridCol行号.Visible = true;
            this.gridCol行号.VisibleIndex = 1;
            this.gridCol行号.Width = 53;
            // 
            // gridCol数量
            // 
            this.gridCol数量.Caption = "数量";
            this.gridCol数量.FieldName = "数量";
            this.gridCol数量.Name = "gridCol数量";
            this.gridCol数量.Visible = true;
            this.gridCol数量.VisibleIndex = 5;
            // 
            // gridCol完工日期
            // 
            this.gridCol完工日期.Caption = "完工日期";
            this.gridCol完工日期.FieldName = "完工日期";
            this.gridCol完工日期.Name = "gridCol完工日期";
            this.gridCol完工日期.Visible = true;
            this.gridCol完工日期.VisibleIndex = 6;
            this.gridCol完工日期.Width = 95;
            // 
            // gridCol备注
            // 
            this.gridCol备注.Caption = "备注";
            this.gridCol备注.FieldName = "备注";
            this.gridCol备注.Name = "gridCol备注";
            this.gridCol备注.OptionsColumn.AllowMerge = DevExpress.Utils.DefaultBoolean.False;
            this.gridCol备注.Visible = true;
            this.gridCol备注.VisibleIndex = 10;
            this.gridCol备注.Width = 403;
            // 
            // gridColiID
            // 
            this.gridColiID.Caption = "iID";
            this.gridColiID.FieldName = "iID";
            this.gridColiID.Name = "gridColiID";
            this.gridColiID.OptionsColumn.AllowEdit = false;
            this.gridColiID.Visible = true;
            this.gridColiID.VisibleIndex = 11;
            // 
            // gridCol产品编码
            // 
            this.gridCol产品编码.Caption = "产品编码";
            this.gridCol产品编码.ColumnEdit = this.ItemLookUpEdit物料编码;
            this.gridCol产品编码.FieldName = "产品编码";
            this.gridCol产品编码.Name = "gridCol产品编码";
            this.gridCol产品编码.Visible = true;
            this.gridCol产品编码.VisibleIndex = 7;
            this.gridCol产品编码.Width = 93;
            // 
            // gridCol产品名称
            // 
            this.gridCol产品名称.Caption = "产品名称";
            this.gridCol产品名称.ColumnEdit = this.ItemLookUpEdit物料名称;
            this.gridCol产品名称.FieldName = "产品编码";
            this.gridCol产品名称.Name = "gridCol产品名称";
            this.gridCol产品名称.OptionsColumn.ReadOnly = true;
            this.gridCol产品名称.Visible = true;
            this.gridCol产品名称.VisibleIndex = 8;
            this.gridCol产品名称.Width = 151;
            // 
            // gridCol产品规格
            // 
            this.gridCol产品规格.Caption = "产品规格";
            this.gridCol产品规格.ColumnEdit = this.ItemLookUpEdit规格型号;
            this.gridCol产品规格.FieldName = "产品编码";
            this.gridCol产品规格.Name = "gridCol产品规格";
            this.gridCol产品规格.OptionsColumn.ReadOnly = true;
            this.gridCol产品规格.Visible = true;
            this.gridCol产品规格.VisibleIndex = 9;
            this.gridCol产品规格.Width = 164;
            // 
            // layoutControlGroup1
            // 
            this.layoutControlGroup1.CustomizationFormText = "layoutControlGroup1";
            this.layoutControlGroup1.EnableIndentsWithoutBorders = DevExpress.Utils.DefaultBoolean.True;
            this.layoutControlGroup1.GroupBordersVisible = false;
            this.layoutControlGroup1.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.layoutControlItem3});
            this.layoutControlGroup1.Location = new System.Drawing.Point(0, 0);
            this.layoutControlGroup1.Name = "layoutControlGroup1";
            this.layoutControlGroup1.Size = new System.Drawing.Size(916, 376);
            this.layoutControlGroup1.Text = "layoutControlGroup1";
            this.layoutControlGroup1.TextVisible = false;
            // 
            // layoutControlItem3
            // 
            this.layoutControlItem3.Control = this.gridControl1;
            this.layoutControlItem3.CustomizationFormText = "layoutControlItem3";
            this.layoutControlItem3.Location = new System.Drawing.Point(0, 0);
            this.layoutControlItem3.Name = "layoutControlItem3";
            this.layoutControlItem3.Size = new System.Drawing.Size(896, 356);
            this.layoutControlItem3.Text = "列表";
            this.layoutControlItem3.TextLocation = DevExpress.Utils.Locations.Top;
            this.layoutControlItem3.TextSize = new System.Drawing.Size(24, 14);
            // 
            // Frm生产手工计划
            // 
            this.Appearance.BackColor = System.Drawing.SystemColors.Control;
            this.Appearance.Options.UseBackColor = true;
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(914, 405);
            this.Controls.Add(this.layoutControl1);
            this.Name = "Frm生产手工计划";
            this.Text = "生产手工计划";
            this.Load += new System.EventHandler(this.FrmLookUpData_Load);
            this.Controls.SetChildIndex(this.layoutControl1, 0);
            ((System.ComponentModel.ISupportInitialize)(this.dsPrint)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dsForm)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtSel)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControl1)).EndInit();
            this.layoutControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ItemLookUpEdit物料编码)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ItemLookUpEdit物料名称)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ItemLookUpEdit规格型号)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ItemLookUpEdit销售订单号)).EndInit();
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
        private DevExpress.XtraGrid.Columns.GridColumn gridCol物料编码;
        private DevExpress.XtraGrid.Columns.GridColumn gridCol物料名称;
        private DevExpress.XtraGrid.Columns.GridColumn gridCol备注;
        private DevExpress.XtraGrid.Columns.GridColumn gridCol时间戳;
        private DevExpress.XtraGrid.Columns.GridColumn gridCol编辑状态;
        private DevExpress.XtraGrid.Columns.GridColumn gridCol规格型号;
        private DevExpress.XtraGrid.Columns.GridColumn gridCol销售订单号;
        private DevExpress.XtraGrid.Columns.GridColumn gridCol行号;
        private DevExpress.XtraGrid.Columns.GridColumn gridCol数量;
        private DevExpress.XtraGrid.Columns.GridColumn gridCol完工日期;
        private DevExpress.XtraGrid.Columns.GridColumn gridColiID;
        private DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit ItemLookUpEdit销售订单号;
        private DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit ItemLookUpEdit物料编码;
        private DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit ItemLookUpEdit物料名称;
        private DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit ItemLookUpEdit规格型号;
        private DevExpress.XtraGrid.Columns.GridColumn gridCol产品编码;
        private DevExpress.XtraGrid.Columns.GridColumn gridCol产品名称;
        private DevExpress.XtraGrid.Columns.GridColumn gridCol产品规格;
    }
}