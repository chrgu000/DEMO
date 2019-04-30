namespace 报表
{
    partial class Frm代理商数据核查
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
            this.gridCol存货编码 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridCol存货名称 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.ItemLookUpEdit存货名称 = new DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit();
            this.gridColM1 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColM2 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColcRdCode = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColcCusCode = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridCol客户名称 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.ItemLookUpEdit客户 = new DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit();
            this.gridCol销售出库单数量 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridCol销售出库单盒数 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridCol客户端数量 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridCol客户端盒数 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridCol客户端已出库数量 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridCol客户端已出库盒数 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.ItemLookUpEdit存货分类 = new DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit();
            this.ItemLookUpEdit仓库 = new DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit();
            this.ItemLookUpEdit货位 = new DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit();
            this.layoutControlGroup1 = new DevExpress.XtraLayout.LayoutControlGroup();
            this.layoutControlItem3 = new DevExpress.XtraLayout.LayoutControlItem();
            ((System.ComponentModel.ISupportInitialize)(this.dsPrint)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dsPrint2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dsForm)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtSel)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControl1)).BeginInit();
            this.layoutControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ItemLookUpEdit存货名称)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ItemLookUpEdit客户)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ItemLookUpEdit存货分类)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ItemLookUpEdit仓库)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ItemLookUpEdit货位)).BeginInit();
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
            this.layoutControl1.OptionsCustomizationForm.DesignTimeCustomizationFormPositionAndSize = new System.Drawing.Rectangle(64, 320, 250, 350);
            this.layoutControl1.OptionsCustomizationForm.ShowLoadButton = false;
            this.layoutControl1.OptionsCustomizationForm.ShowSaveButton = false;
            this.layoutControl1.OptionsView.UseDefaultDragAndDropRendering = false;
            this.layoutControl1.Root = this.layoutControlGroup1;
            this.layoutControl1.Size = new System.Drawing.Size(1358, 499);
            this.layoutControl1.TabIndex = 5;
            this.layoutControl1.Text = "layoutControl1";
            // 
            // gridControl1
            // 
            this.gridControl1.Location = new System.Drawing.Point(12, 29);
            this.gridControl1.MainView = this.gridView1;
            this.gridControl1.Name = "gridControl1";
            this.gridControl1.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.ItemLookUpEdit存货分类,
            this.ItemLookUpEdit存货名称,
            this.ItemLookUpEdit仓库,
            this.ItemLookUpEdit货位,
            this.ItemLookUpEdit客户});
            this.gridControl1.Size = new System.Drawing.Size(1334, 458);
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
            this.gridCol存货编码,
            this.gridCol存货名称,
            this.gridColM1,
            this.gridColM2,
            this.gridColcRdCode,
            this.gridColcCusCode,
            this.gridCol客户名称,
            this.gridCol销售出库单数量,
            this.gridCol销售出库单盒数,
            this.gridCol客户端数量,
            this.gridCol客户端盒数,
            this.gridCol客户端已出库数量,
            this.gridCol客户端已出库盒数});
            this.gridView1.GridControl = this.gridControl1;
            this.gridView1.IndicatorWidth = 40;
            this.gridView1.Name = "gridView1";
            this.gridView1.OptionsBehavior.CopyToClipboardWithColumnHeaders = false;
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
            this.gridView1.CellValueChanged += new DevExpress.XtraGrid.Views.Base.CellValueChangedEventHandler(this.gridView1_CellValueChanged);
            // 
            // gridCol存货编码
            // 
            this.gridCol存货编码.Caption = "存货编码";
            this.gridCol存货编码.FieldName = "cInvCode";
            this.gridCol存货编码.Name = "gridCol存货编码";
            this.gridCol存货编码.OptionsColumn.AllowEdit = false;
            this.gridCol存货编码.Visible = true;
            this.gridCol存货编码.VisibleIndex = 4;
            // 
            // gridCol存货名称
            // 
            this.gridCol存货名称.Caption = "存货名称";
            this.gridCol存货名称.ColumnEdit = this.ItemLookUpEdit存货名称;
            this.gridCol存货名称.FieldName = "cInvCode";
            this.gridCol存货名称.Name = "gridCol存货名称";
            this.gridCol存货名称.OptionsColumn.AllowEdit = false;
            this.gridCol存货名称.Visible = true;
            this.gridCol存货名称.VisibleIndex = 3;
            // 
            // ItemLookUpEdit存货名称
            // 
            this.ItemLookUpEdit存货名称.AutoHeight = false;
            this.ItemLookUpEdit存货名称.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.ItemLookUpEdit存货名称.Name = "ItemLookUpEdit存货名称";
            this.ItemLookUpEdit存货名称.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.Standard;
            // 
            // gridColM1
            // 
            this.gridColM1.Caption = "色号";
            this.gridColM1.FieldName = "M1";
            this.gridColM1.Name = "gridColM1";
            this.gridColM1.OptionsColumn.AllowEdit = false;
            this.gridColM1.Visible = true;
            this.gridColM1.VisibleIndex = 5;
            // 
            // gridColM2
            // 
            this.gridColM2.Caption = "缸号";
            this.gridColM2.FieldName = "M2";
            this.gridColM2.Name = "gridColM2";
            this.gridColM2.OptionsColumn.AllowEdit = false;
            this.gridColM2.Visible = true;
            this.gridColM2.VisibleIndex = 6;
            // 
            // gridColcRdCode
            // 
            this.gridColcRdCode.Caption = "单据号";
            this.gridColcRdCode.FieldName = "cRDCode";
            this.gridColcRdCode.Name = "gridColcRdCode";
            this.gridColcRdCode.OptionsColumn.AllowEdit = false;
            this.gridColcRdCode.Visible = true;
            this.gridColcRdCode.VisibleIndex = 2;
            // 
            // gridColcCusCode
            // 
            this.gridColcCusCode.Caption = "客户编码";
            this.gridColcCusCode.FieldName = "cCusCode";
            this.gridColcCusCode.Name = "gridColcCusCode";
            this.gridColcCusCode.OptionsColumn.AllowEdit = false;
            this.gridColcCusCode.Visible = true;
            this.gridColcCusCode.VisibleIndex = 0;
            // 
            // gridCol客户名称
            // 
            this.gridCol客户名称.Caption = "客户名称";
            this.gridCol客户名称.ColumnEdit = this.ItemLookUpEdit客户;
            this.gridCol客户名称.FieldName = "cCusCode";
            this.gridCol客户名称.Name = "gridCol客户名称";
            this.gridCol客户名称.OptionsColumn.AllowEdit = false;
            this.gridCol客户名称.Visible = true;
            this.gridCol客户名称.VisibleIndex = 1;
            // 
            // ItemLookUpEdit客户
            // 
            this.ItemLookUpEdit客户.AutoHeight = false;
            this.ItemLookUpEdit客户.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.ItemLookUpEdit客户.Name = "ItemLookUpEdit客户";
            // 
            // gridCol销售出库单数量
            // 
            this.gridCol销售出库单数量.Caption = "销售出库单数量";
            this.gridCol销售出库单数量.FieldName = "iQuantity";
            this.gridCol销售出库单数量.Name = "gridCol销售出库单数量";
            this.gridCol销售出库单数量.OptionsColumn.AllowEdit = false;
            this.gridCol销售出库单数量.Visible = true;
            this.gridCol销售出库单数量.VisibleIndex = 7;
            this.gridCol销售出库单数量.Width = 93;
            // 
            // gridCol销售出库单盒数
            // 
            this.gridCol销售出库单盒数.Caption = "销售出库单盒数";
            this.gridCol销售出库单盒数.FieldName = "sBoxQty";
            this.gridCol销售出库单盒数.Name = "gridCol销售出库单盒数";
            this.gridCol销售出库单盒数.OptionsColumn.AllowEdit = false;
            this.gridCol销售出库单盒数.Visible = true;
            this.gridCol销售出库单盒数.VisibleIndex = 8;
            this.gridCol销售出库单盒数.Width = 93;
            // 
            // gridCol客户端数量
            // 
            this.gridCol客户端数量.Caption = "客户端数量";
            this.gridCol客户端数量.FieldName = "cusiQuantity";
            this.gridCol客户端数量.Name = "gridCol客户端数量";
            this.gridCol客户端数量.OptionsColumn.AllowEdit = false;
            this.gridCol客户端数量.Visible = true;
            this.gridCol客户端数量.VisibleIndex = 9;
            // 
            // gridCol客户端盒数
            // 
            this.gridCol客户端盒数.Caption = "客户端盒数";
            this.gridCol客户端盒数.FieldName = "cussBoxQty";
            this.gridCol客户端盒数.Name = "gridCol客户端盒数";
            this.gridCol客户端盒数.OptionsColumn.AllowEdit = false;
            this.gridCol客户端盒数.Visible = true;
            this.gridCol客户端盒数.VisibleIndex = 10;
            // 
            // gridCol客户端已出库数量
            // 
            this.gridCol客户端已出库数量.Caption = "客户端已出库数量";
            this.gridCol客户端已出库数量.FieldName = "cusoutiQuantity";
            this.gridCol客户端已出库数量.Name = "gridCol客户端已出库数量";
            this.gridCol客户端已出库数量.OptionsColumn.AllowEdit = false;
            this.gridCol客户端已出库数量.Visible = true;
            this.gridCol客户端已出库数量.VisibleIndex = 11;
            this.gridCol客户端已出库数量.Width = 105;
            // 
            // gridCol客户端已出库盒数
            // 
            this.gridCol客户端已出库盒数.Caption = "客户端已出库盒数";
            this.gridCol客户端已出库盒数.FieldName = "cusoutsBoxQty";
            this.gridCol客户端已出库盒数.Name = "gridCol客户端已出库盒数";
            this.gridCol客户端已出库盒数.OptionsColumn.AllowEdit = false;
            this.gridCol客户端已出库盒数.Visible = true;
            this.gridCol客户端已出库盒数.VisibleIndex = 12;
            this.gridCol客户端已出库盒数.Width = 105;
            // 
            // ItemLookUpEdit存货分类
            // 
            this.ItemLookUpEdit存货分类.AutoHeight = false;
            this.ItemLookUpEdit存货分类.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.ItemLookUpEdit存货分类.Name = "ItemLookUpEdit存货分类";
            this.ItemLookUpEdit存货分类.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.Standard;
            // 
            // ItemLookUpEdit仓库
            // 
            this.ItemLookUpEdit仓库.AutoHeight = false;
            this.ItemLookUpEdit仓库.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.ItemLookUpEdit仓库.Name = "ItemLookUpEdit仓库";
            // 
            // ItemLookUpEdit货位
            // 
            this.ItemLookUpEdit货位.AutoHeight = false;
            this.ItemLookUpEdit货位.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.ItemLookUpEdit货位.Name = "ItemLookUpEdit货位";
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
            this.layoutControlGroup1.Size = new System.Drawing.Size(1358, 499);
            this.layoutControlGroup1.Text = "Root";
            this.layoutControlGroup1.TextVisible = false;
            // 
            // layoutControlItem3
            // 
            this.layoutControlItem3.Control = this.gridControl1;
            this.layoutControlItem3.CustomizationFormText = "layoutControlItem3";
            this.layoutControlItem3.Location = new System.Drawing.Point(0, 0);
            this.layoutControlItem3.Name = "layoutControlItem3";
            this.layoutControlItem3.Size = new System.Drawing.Size(1338, 479);
            this.layoutControlItem3.Text = "列表";
            this.layoutControlItem3.TextLocation = DevExpress.Utils.Locations.Top;
            this.layoutControlItem3.TextSize = new System.Drawing.Size(24, 14);
            // 
            // Frm代理商数据核查
            // 
            this.Appearance.BackColor = System.Drawing.SystemColors.Control;
            this.Appearance.Options.UseBackColor = true;
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1356, 528);
            this.Controls.Add(this.layoutControl1);
            this.Name = "Frm代理商数据核查";
            this.Text = "代理商数据核查";
            this.Load += new System.EventHandler(this.Frm代理商数据核查_Load);
            this.Controls.SetChildIndex(this.layoutControl1, 0);
            ((System.ComponentModel.ISupportInitialize)(this.dsPrint)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dsPrint2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dsForm)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtSel)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControl1)).EndInit();
            this.layoutControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ItemLookUpEdit存货名称)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ItemLookUpEdit客户)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ItemLookUpEdit存货分类)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ItemLookUpEdit仓库)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ItemLookUpEdit货位)).EndInit();
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
        private DevExpress.XtraGrid.Columns.GridColumn gridCol存货编码;
        private DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit ItemLookUpEdit存货分类;
        private DevExpress.XtraGrid.Columns.GridColumn gridCol存货名称;
        private DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit ItemLookUpEdit存货名称;
        private DevExpress.XtraGrid.Columns.GridColumn gridColM1;
        private DevExpress.XtraGrid.Columns.GridColumn gridColM2;
        private DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit ItemLookUpEdit仓库;
        private DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit ItemLookUpEdit货位;
        private DevExpress.XtraGrid.Columns.GridColumn gridColcRdCode;
        private DevExpress.XtraGrid.Columns.GridColumn gridColcCusCode;
        private DevExpress.XtraGrid.Columns.GridColumn gridCol客户名称;
        private DevExpress.XtraGrid.Columns.GridColumn gridCol销售出库单数量;
        private DevExpress.XtraGrid.Columns.GridColumn gridCol销售出库单盒数;
        private DevExpress.XtraGrid.Columns.GridColumn gridCol客户端数量;
        private DevExpress.XtraGrid.Columns.GridColumn gridCol客户端盒数;
        private DevExpress.XtraGrid.Columns.GridColumn gridCol客户端已出库数量;
        private DevExpress.XtraGrid.Columns.GridColumn gridCol客户端已出库盒数;
        private DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit ItemLookUpEdit客户;
    }
}