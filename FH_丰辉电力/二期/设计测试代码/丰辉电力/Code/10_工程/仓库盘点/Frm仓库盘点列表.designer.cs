namespace 工程
{
    partial class Frm仓库盘点列表 
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
            this.checkEditChk = new DevExpress.XtraEditors.CheckEdit();
            this.gridControl1 = new DevExpress.XtraGrid.GridControl();
            this.gridView1 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.gridColAutoID = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridCol选择 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.ItemCheckEdit选择 = new DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit();
            this.gridCol序号 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridCol单据号 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridCol存货编码 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridCol存货名称 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.ItemLookUpEdit物料名称 = new DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit();
            this.gridCol规格型号 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.ItemLookUpEdit物料规格 = new DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit();
            this.gridCol计量单位 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.ItemLookUpEdit计量单位 = new DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit();
            this.gridCol单据日期 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridCol账面数量 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridCol实盘数量 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridCol备注 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.layoutControlGroup1 = new DevExpress.XtraLayout.LayoutControlGroup();
            this.layoutControlItem3 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem1 = new DevExpress.XtraLayout.LayoutControlItem();
            this.ItemLookUpEditSexID = new DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit();
            this.ItemLookUpEditDept = new DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit();
            ((System.ComponentModel.ISupportInitialize)(this.dsPrint)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dsPrint2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dsForm)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtSel)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControl1)).BeginInit();
            this.layoutControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.checkEditChk.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ItemCheckEdit选择)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ItemLookUpEdit物料名称)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ItemLookUpEdit物料规格)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ItemLookUpEdit计量单位)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ItemLookUpEditSexID)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ItemLookUpEditDept)).BeginInit();
            this.SuspendLayout();
            // 
            // layoutControl1
            // 
            this.layoutControl1.AllowCustomizationMenu = false;
            this.layoutControl1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.layoutControl1.Controls.Add(this.checkEditChk);
            this.layoutControl1.Controls.Add(this.gridControl1);
            this.layoutControl1.Location = new System.Drawing.Point(0, 28);
            this.layoutControl1.Name = "layoutControl1";
            this.layoutControl1.OptionsCustomizationForm.DesignTimeCustomizationFormPositionAndSize = new System.Drawing.Rectangle(210, 239, 250, 350);
            this.layoutControl1.OptionsCustomizationForm.ShowLoadButton = false;
            this.layoutControl1.OptionsCustomizationForm.ShowSaveButton = false;
            this.layoutControl1.OptionsView.UseDefaultDragAndDropRendering = false;
            this.layoutControl1.Root = this.layoutControlGroup1;
            this.layoutControl1.Size = new System.Drawing.Size(1212, 316);
            this.layoutControl1.TabIndex = 5;
            this.layoutControl1.Text = "layoutControl1";
            // 
            // checkEditChk
            // 
            this.checkEditChk.Location = new System.Drawing.Point(12, 12);
            this.checkEditChk.Name = "checkEditChk";
            this.checkEditChk.Properties.Caption = "全选";
            this.checkEditChk.Size = new System.Drawing.Size(1188, 19);
            this.checkEditChk.StyleController = this.layoutControl1;
            this.checkEditChk.TabIndex = 50;
            this.checkEditChk.Visible = false;
            this.checkEditChk.CheckedChanged += new System.EventHandler(this.checkEditChk_CheckedChanged);
            // 
            // gridControl1
            // 
            this.gridControl1.Location = new System.Drawing.Point(12, 35);
            this.gridControl1.MainView = this.gridView1;
            this.gridControl1.Name = "gridControl1";
            this.gridControl1.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.ItemCheckEdit选择,
            this.ItemLookUpEdit物料名称,
            this.ItemLookUpEdit物料规格,
            this.ItemLookUpEdit计量单位});
            this.gridControl1.Size = new System.Drawing.Size(1188, 269);
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
            this.gridColAutoID,
            this.gridCol选择,
            this.gridCol序号,
            this.gridCol单据号,
            this.gridCol存货编码,
            this.gridCol存货名称,
            this.gridCol规格型号,
            this.gridCol计量单位,
            this.gridCol单据日期,
            this.gridCol账面数量,
            this.gridCol实盘数量,
            this.gridCol备注});
            this.gridView1.CustomizationFormBounds = new System.Drawing.Rectangle(950, 457, 216, 187);
            this.gridView1.GridControl = this.gridControl1;
            this.gridView1.IndicatorWidth = 40;
            this.gridView1.Name = "gridView1";
            this.gridView1.OptionsBehavior.CopyToClipboardWithColumnHeaders = false;
            this.gridView1.OptionsBehavior.EditorShowMode = DevExpress.Utils.EditorShowMode.MouseDown;
            this.gridView1.OptionsLayout.Columns.StoreAllOptions = true;
            this.gridView1.OptionsLayout.Columns.StoreAppearance = true;
            this.gridView1.OptionsLayout.StoreAllOptions = true;
            this.gridView1.OptionsLayout.StoreAppearance = true;
            this.gridView1.OptionsMenu.ShowAddNewSummaryItem = DevExpress.Utils.DefaultBoolean.True;
            this.gridView1.OptionsMenu.ShowGroupSummaryEditorItem = true;
            this.gridView1.OptionsNavigation.EnterMoveNextColumn = true;
            this.gridView1.OptionsSelection.MultiSelect = true;
            this.gridView1.OptionsSelection.MultiSelectMode = DevExpress.XtraGrid.Views.Grid.GridMultiSelectMode.CellSelect;
            this.gridView1.OptionsView.AutoCalcPreviewLineCount = true;
            this.gridView1.OptionsView.ColumnAutoWidth = false;
            this.gridView1.OptionsView.EnableAppearanceEvenRow = true;
            this.gridView1.OptionsView.EnableAppearanceOddRow = true;
            this.gridView1.OptionsView.ShowFooter = true;
            this.gridView1.OptionsView.ShowGroupPanel = false;
            this.gridView1.CustomDrawRowIndicator += new DevExpress.XtraGrid.Views.Grid.RowIndicatorCustomDrawEventHandler(this.gridView1_CustomDrawRowIndicator);
            this.gridView1.DoubleClick += new System.EventHandler(this.gridView1_DoubleClick);
            // 
            // gridColAutoID
            // 
            this.gridColAutoID.Caption = "AutoID";
            this.gridColAutoID.FieldName = "AutoID";
            this.gridColAutoID.Name = "gridColAutoID";
            this.gridColAutoID.OptionsColumn.AllowEdit = false;
            // 
            // gridCol选择
            // 
            this.gridCol选择.Caption = "选择";
            this.gridCol选择.ColumnEdit = this.ItemCheckEdit选择;
            this.gridCol选择.FieldName = "iChk";
            this.gridCol选择.Name = "gridCol选择";
            this.gridCol选择.OptionsColumn.AllowEdit = false;
            this.gridCol选择.Width = 31;
            // 
            // ItemCheckEdit选择
            // 
            this.ItemCheckEdit选择.AutoHeight = false;
            this.ItemCheckEdit选择.Name = "ItemCheckEdit选择";
            this.ItemCheckEdit选择.CheckedChanged += new System.EventHandler(this.ItemCheckEdit选择_CheckedChanged);
            // 
            // gridCol序号
            // 
            this.gridCol序号.Caption = "序号";
            this.gridCol序号.FieldName = "iID";
            this.gridCol序号.Name = "gridCol序号";
            this.gridCol序号.OptionsColumn.AllowEdit = false;
            this.gridCol序号.Visible = true;
            this.gridCol序号.VisibleIndex = 0;
            this.gridCol序号.Width = 95;
            // 
            // gridCol单据号
            // 
            this.gridCol单据号.Caption = "单据号";
            this.gridCol单据号.FieldName = "cRdCode";
            this.gridCol单据号.Name = "gridCol单据号";
            this.gridCol单据号.OptionsColumn.AllowEdit = false;
            this.gridCol单据号.Visible = true;
            this.gridCol单据号.VisibleIndex = 1;
            this.gridCol单据号.Width = 92;
            // 
            // gridCol存货编码
            // 
            this.gridCol存货编码.Caption = "存货编码";
            this.gridCol存货编码.FieldName = "cInvCode";
            this.gridCol存货编码.Name = "gridCol存货编码";
            this.gridCol存货编码.OptionsColumn.AllowEdit = false;
            this.gridCol存货编码.Visible = true;
            this.gridCol存货编码.VisibleIndex = 3;
            // 
            // gridCol存货名称
            // 
            this.gridCol存货名称.Caption = "存货名称";
            this.gridCol存货名称.ColumnEdit = this.ItemLookUpEdit物料名称;
            this.gridCol存货名称.FieldName = "cInvCode";
            this.gridCol存货名称.Name = "gridCol存货名称";
            this.gridCol存货名称.OptionsColumn.AllowEdit = false;
            this.gridCol存货名称.Visible = true;
            this.gridCol存货名称.VisibleIndex = 4;
            // 
            // ItemLookUpEdit物料名称
            // 
            this.ItemLookUpEdit物料名称.AutoHeight = false;
            this.ItemLookUpEdit物料名称.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.ItemLookUpEdit物料名称.Name = "ItemLookUpEdit物料名称";
            // 
            // gridCol规格型号
            // 
            this.gridCol规格型号.Caption = "规格型号";
            this.gridCol规格型号.ColumnEdit = this.ItemLookUpEdit物料规格;
            this.gridCol规格型号.FieldName = "cInvCode";
            this.gridCol规格型号.Name = "gridCol规格型号";
            this.gridCol规格型号.OptionsColumn.AllowEdit = false;
            this.gridCol规格型号.Visible = true;
            this.gridCol规格型号.VisibleIndex = 5;
            // 
            // ItemLookUpEdit物料规格
            // 
            this.ItemLookUpEdit物料规格.AutoHeight = false;
            this.ItemLookUpEdit物料规格.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.ItemLookUpEdit物料规格.Name = "ItemLookUpEdit物料规格";
            // 
            // gridCol计量单位
            // 
            this.gridCol计量单位.Caption = "计量单位";
            this.gridCol计量单位.ColumnEdit = this.ItemLookUpEdit计量单位;
            this.gridCol计量单位.FieldName = "cInvCode";
            this.gridCol计量单位.Name = "gridCol计量单位";
            this.gridCol计量单位.OptionsColumn.AllowEdit = false;
            this.gridCol计量单位.Visible = true;
            this.gridCol计量单位.VisibleIndex = 6;
            // 
            // ItemLookUpEdit计量单位
            // 
            this.ItemLookUpEdit计量单位.AutoHeight = false;
            this.ItemLookUpEdit计量单位.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.ItemLookUpEdit计量单位.Name = "ItemLookUpEdit计量单位";
            // 
            // gridCol单据日期
            // 
            this.gridCol单据日期.Caption = "单据日期";
            this.gridCol单据日期.FieldName = "单据日期";
            this.gridCol单据日期.Name = "gridCol单据日期";
            this.gridCol单据日期.OptionsColumn.AllowEdit = false;
            this.gridCol单据日期.Visible = true;
            this.gridCol单据日期.VisibleIndex = 2;
            // 
            // gridCol账面数量
            // 
            this.gridCol账面数量.Caption = "账面数量";
            this.gridCol账面数量.FieldName = "SQty";
            this.gridCol账面数量.Name = "gridCol账面数量";
            this.gridCol账面数量.OptionsColumn.AllowEdit = false;
            this.gridCol账面数量.Visible = true;
            this.gridCol账面数量.VisibleIndex = 7;
            // 
            // gridCol实盘数量
            // 
            this.gridCol实盘数量.Caption = "实盘数量";
            this.gridCol实盘数量.FieldName = "iQuantity";
            this.gridCol实盘数量.Name = "gridCol实盘数量";
            this.gridCol实盘数量.OptionsColumn.AllowEdit = false;
            this.gridCol实盘数量.Visible = true;
            this.gridCol实盘数量.VisibleIndex = 8;
            // 
            // gridCol备注
            // 
            this.gridCol备注.Caption = "备注";
            this.gridCol备注.FieldName = "Remark";
            this.gridCol备注.Name = "gridCol备注";
            this.gridCol备注.OptionsColumn.AllowEdit = false;
            this.gridCol备注.Visible = true;
            this.gridCol备注.VisibleIndex = 9;
            this.gridCol备注.Width = 114;
            // 
            // layoutControlGroup1
            // 
            this.layoutControlGroup1.CustomizationFormText = "layoutControlGroup1";
            this.layoutControlGroup1.EnableIndentsWithoutBorders = DevExpress.Utils.DefaultBoolean.True;
            this.layoutControlGroup1.GroupBordersVisible = false;
            this.layoutControlGroup1.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.layoutControlItem3,
            this.layoutControlItem1});
            this.layoutControlGroup1.Location = new System.Drawing.Point(0, 0);
            this.layoutControlGroup1.Name = "Root";
            this.layoutControlGroup1.Size = new System.Drawing.Size(1212, 316);
            this.layoutControlGroup1.Text = "Root";
            this.layoutControlGroup1.TextVisible = false;
            // 
            // layoutControlItem3
            // 
            this.layoutControlItem3.Control = this.gridControl1;
            this.layoutControlItem3.CustomizationFormText = "layoutControlItem3";
            this.layoutControlItem3.Location = new System.Drawing.Point(0, 23);
            this.layoutControlItem3.Name = "layoutControlItem3";
            this.layoutControlItem3.Size = new System.Drawing.Size(1192, 273);
            this.layoutControlItem3.Text = "layoutControlItem3";
            this.layoutControlItem3.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem3.TextToControlDistance = 0;
            this.layoutControlItem3.TextVisible = false;
            // 
            // layoutControlItem1
            // 
            this.layoutControlItem1.Control = this.checkEditChk;
            this.layoutControlItem1.CustomizationFormText = "layoutControlItem1";
            this.layoutControlItem1.Location = new System.Drawing.Point(0, 0);
            this.layoutControlItem1.Name = "layoutControlItem1";
            this.layoutControlItem1.Size = new System.Drawing.Size(1192, 23);
            this.layoutControlItem1.Text = "layoutControlItem1";
            this.layoutControlItem1.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem1.TextToControlDistance = 0;
            this.layoutControlItem1.TextVisible = false;
            this.layoutControlItem1.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Never;
            // 
            // ItemLookUpEditSexID
            // 
            this.ItemLookUpEditSexID.AutoHeight = false;
            this.ItemLookUpEditSexID.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.ItemLookUpEditSexID.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("iID", "编号"),
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("iText", "类型")});
            this.ItemLookUpEditSexID.DisplayMember = "iText";
            this.ItemLookUpEditSexID.Name = "ItemLookUpEditSexID";
            this.ItemLookUpEditSexID.NullText = "";
            this.ItemLookUpEditSexID.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.Standard;
            this.ItemLookUpEditSexID.ValueMember = "iID";
            // 
            // ItemLookUpEditDept
            // 
            this.ItemLookUpEditDept.AutoHeight = false;
            this.ItemLookUpEditDept.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.ItemLookUpEditDept.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("iID", "序号"),
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("iText", "状态")});
            this.ItemLookUpEditDept.DisplayMember = "iText";
            this.ItemLookUpEditDept.Name = "ItemLookUpEditDept";
            this.ItemLookUpEditDept.NullText = "";
            this.ItemLookUpEditDept.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.Standard;
            this.ItemLookUpEditDept.ValueMember = "iID";
            // 
            // Frm仓库盘点列表
            // 
            this.Appearance.BackColor = System.Drawing.SystemColors.Control;
            this.Appearance.Options.UseBackColor = true;
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1210, 345);
            this.Controls.Add(this.layoutControl1);
            this.Name = "Frm仓库盘点列表";
            this.Text = "仓库盘点列表";
            this.Load += new System.EventHandler(this.Frm仓库盘点列表_Load);
            this.Controls.SetChildIndex(this.layoutControl1, 0);
            ((System.ComponentModel.ISupportInitialize)(this.dsPrint)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dsPrint2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dsForm)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtSel)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControl1)).EndInit();
            this.layoutControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.checkEditChk.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ItemCheckEdit选择)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ItemLookUpEdit物料名称)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ItemLookUpEdit物料规格)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ItemLookUpEdit计量单位)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ItemLookUpEditSexID)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ItemLookUpEditDept)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraLayout.LayoutControl layoutControl1;
        private DevExpress.XtraGrid.GridControl gridControl1;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView1;
        private DevExpress.XtraLayout.LayoutControlGroup layoutControlGroup1;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem3;
        private DevExpress.XtraGrid.Columns.GridColumn gridCol单据号;
        private DevExpress.XtraGrid.Columns.GridColumn gridCol选择;
        private DevExpress.XtraGrid.Columns.GridColumn gridColAutoID;
        private DevExpress.XtraGrid.Columns.GridColumn gridCol序号;
        private DevExpress.XtraGrid.Columns.GridColumn gridCol存货名称;
        private DevExpress.XtraGrid.Columns.GridColumn gridCol存货编码;
        private DevExpress.XtraGrid.Columns.GridColumn gridCol规格型号;
        private DevExpress.XtraGrid.Columns.GridColumn gridCol计量单位;
        private DevExpress.XtraGrid.Columns.GridColumn gridCol单据日期;
        private DevExpress.XtraGrid.Columns.GridColumn gridCol账面数量;
        private DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit ItemLookUpEditSexID;
        private DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit ItemLookUpEditDept;
        private DevExpress.XtraEditors.CheckEdit checkEditChk;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem1;
        private DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit ItemCheckEdit选择;
        private DevExpress.XtraGrid.Columns.GridColumn gridCol实盘数量;
        private DevExpress.XtraGrid.Columns.GridColumn gridCol备注;
        private DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit ItemLookUpEdit物料名称;
        private DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit ItemLookUpEdit物料规格;
        private DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit ItemLookUpEdit计量单位;
    }
}