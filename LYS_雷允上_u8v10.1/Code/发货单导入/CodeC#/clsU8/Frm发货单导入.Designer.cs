namespace clsU8
{
    partial class Frm发货单导入
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
            this.gridControl1 = new DevExpress.XtraGrid.GridControl();
            this.gridView1 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.gridCol订单号 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridCol仓库编码 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.ItemLookUpEditcWhCode = new DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit();
            this.gridCol仓库 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.ItemLookUpEditcWhName = new DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit();
            this.gridCol业务模式 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridCol客户编码 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridCol客户 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.ItemLookUpEdit客户 = new DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit();
            this.gridCol业务员 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridCol存货编码 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridCol存货名称 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.ItemLookUpEdit存货名称 = new DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit();
            this.gridCol规格 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.ItemLookUpEdit规格 = new DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit();
            this.gridCol含税单价 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridCol出库数量 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridCol月份 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.btnLoad = new System.Windows.Forms.ToolStripMenuItem();
            this.btnSave = new System.Windows.Forms.ToolStripMenuItem();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ItemLookUpEditcWhCode)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ItemLookUpEditcWhName)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ItemLookUpEdit客户)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ItemLookUpEdit存货名称)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ItemLookUpEdit规格)).BeginInit();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // gridControl1
            // 
            this.gridControl1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.gridControl1.EmbeddedNavigator.Margin = new System.Windows.Forms.Padding(4);
            this.gridControl1.Location = new System.Drawing.Point(0, 32);
            this.gridControl1.LookAndFeel.SkinName = "Office 2010 Blue";
            this.gridControl1.MainView = this.gridView1;
            this.gridControl1.Margin = new System.Windows.Forms.Padding(4);
            this.gridControl1.Name = "gridControl1";
            this.gridControl1.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.ItemLookUpEditcWhCode,
            this.ItemLookUpEditcWhName,
            this.ItemLookUpEdit存货名称,
            this.ItemLookUpEdit规格,
            this.ItemLookUpEdit客户});
            this.gridControl1.Size = new System.Drawing.Size(1400, 551);
            this.gridControl1.TabIndex = 192;
            this.gridControl1.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView1});
            // 
            // gridView1
            // 
            this.gridView1.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.gridCol订单号,
            this.gridCol仓库编码,
            this.gridCol仓库,
            this.gridCol业务模式,
            this.gridCol客户编码,
            this.gridCol客户,
            this.gridCol业务员,
            this.gridCol存货编码,
            this.gridCol存货名称,
            this.gridCol规格,
            this.gridCol含税单价,
            this.gridCol出库数量,
            this.gridCol月份});
            this.gridView1.GridControl = this.gridControl1;
            this.gridView1.IndicatorWidth = 40;
            this.gridView1.Name = "gridView1";
            this.gridView1.OptionsBehavior.AllowDeleteRows = DevExpress.Utils.DefaultBoolean.True;
            this.gridView1.OptionsBehavior.EditorShowMode = DevExpress.Utils.EditorShowMode.MouseDown;
            this.gridView1.OptionsCustomization.AllowGroup = false;
            this.gridView1.OptionsCustomization.AllowQuickHideColumns = false;
            this.gridView1.OptionsNavigation.EnterMoveNextColumn = true;
            this.gridView1.OptionsPrint.AutoWidth = false;
            this.gridView1.OptionsView.AllowCellMerge = true;
            this.gridView1.OptionsView.ColumnAutoWidth = false;
            this.gridView1.OptionsView.ShowFooter = true;
            this.gridView1.OptionsView.ShowGroupPanel = false;
            this.gridView1.CustomDrawRowIndicator += new DevExpress.XtraGrid.Views.Grid.RowIndicatorCustomDrawEventHandler(this.gridView1_CustomDrawRowIndicator);
            this.gridView1.CellMerge += new DevExpress.XtraGrid.Views.Grid.CellMergeEventHandler(this.gridView1_CellMerge);
            // 
            // gridCol订单号
            // 
            this.gridCol订单号.Caption = "订单号";
            this.gridCol订单号.FieldName = "订单号";
            this.gridCol订单号.Name = "gridCol订单号";
            this.gridCol订单号.OptionsColumn.AllowEdit = false;
            this.gridCol订单号.OptionsColumn.AllowMerge = DevExpress.Utils.DefaultBoolean.False;
            this.gridCol订单号.OptionsColumn.AllowMove = false;
            this.gridCol订单号.OptionsColumn.AllowSort = DevExpress.Utils.DefaultBoolean.False;
            this.gridCol订单号.OptionsFilter.AllowFilter = false;
            this.gridCol订单号.Visible = true;
            this.gridCol订单号.VisibleIndex = 0;
            // 
            // gridCol仓库编码
            // 
            this.gridCol仓库编码.Caption = "仓库编码";
            this.gridCol仓库编码.ColumnEdit = this.ItemLookUpEditcWhCode;
            this.gridCol仓库编码.FieldName = "仓库编码";
            this.gridCol仓库编码.Name = "gridCol仓库编码";
            this.gridCol仓库编码.OptionsColumn.AllowEdit = false;
            this.gridCol仓库编码.OptionsColumn.AllowMerge = DevExpress.Utils.DefaultBoolean.False;
            this.gridCol仓库编码.Visible = true;
            this.gridCol仓库编码.VisibleIndex = 2;
            // 
            // ItemLookUpEditcWhCode
            // 
            this.ItemLookUpEditcWhCode.AutoHeight = false;
            this.ItemLookUpEditcWhCode.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.ItemLookUpEditcWhCode.DisplayMember = "cWhCode";
            this.ItemLookUpEditcWhCode.Name = "ItemLookUpEditcWhCode";
            this.ItemLookUpEditcWhCode.NullText = "";
            this.ItemLookUpEditcWhCode.ValueMember = "cWhCode";
            // 
            // gridCol仓库
            // 
            this.gridCol仓库.Caption = "仓库";
            this.gridCol仓库.ColumnEdit = this.ItemLookUpEditcWhName;
            this.gridCol仓库.FieldName = "仓库编码";
            this.gridCol仓库.Name = "gridCol仓库";
            this.gridCol仓库.OptionsColumn.AllowEdit = false;
            this.gridCol仓库.OptionsColumn.AllowMerge = DevExpress.Utils.DefaultBoolean.False;
            this.gridCol仓库.Visible = true;
            this.gridCol仓库.VisibleIndex = 3;
            // 
            // ItemLookUpEditcWhName
            // 
            this.ItemLookUpEditcWhName.AutoHeight = false;
            this.ItemLookUpEditcWhName.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.ItemLookUpEditcWhName.DisplayMember = "cWhName";
            this.ItemLookUpEditcWhName.Name = "ItemLookUpEditcWhName";
            this.ItemLookUpEditcWhName.NullText = "";
            this.ItemLookUpEditcWhName.ValueMember = "cWhCode";
            // 
            // gridCol业务模式
            // 
            this.gridCol业务模式.Caption = "业务模式";
            this.gridCol业务模式.FieldName = "业务模式";
            this.gridCol业务模式.Name = "gridCol业务模式";
            this.gridCol业务模式.OptionsColumn.AllowEdit = false;
            this.gridCol业务模式.OptionsColumn.AllowMerge = DevExpress.Utils.DefaultBoolean.False;
            this.gridCol业务模式.Visible = true;
            this.gridCol业务模式.VisibleIndex = 4;
            // 
            // gridCol客户编码
            // 
            this.gridCol客户编码.Caption = "客户编码";
            this.gridCol客户编码.FieldName = "客户编码";
            this.gridCol客户编码.Name = "gridCol客户编码";
            this.gridCol客户编码.OptionsColumn.AllowEdit = false;
            this.gridCol客户编码.OptionsColumn.AllowMerge = DevExpress.Utils.DefaultBoolean.False;
            this.gridCol客户编码.Visible = true;
            this.gridCol客户编码.VisibleIndex = 5;
            // 
            // gridCol客户
            // 
            this.gridCol客户.Caption = "客户";
            this.gridCol客户.ColumnEdit = this.ItemLookUpEdit客户;
            this.gridCol客户.FieldName = "客户编码";
            this.gridCol客户.Name = "gridCol客户";
            this.gridCol客户.OptionsColumn.AllowEdit = false;
            this.gridCol客户.OptionsColumn.AllowMerge = DevExpress.Utils.DefaultBoolean.False;
            this.gridCol客户.Visible = true;
            this.gridCol客户.VisibleIndex = 6;
            // 
            // ItemLookUpEdit客户
            // 
            this.ItemLookUpEdit客户.AutoHeight = false;
            this.ItemLookUpEdit客户.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.ItemLookUpEdit客户.DisplayMember = "cCusName";
            this.ItemLookUpEdit客户.Name = "ItemLookUpEdit客户";
            this.ItemLookUpEdit客户.NullText = "";
            this.ItemLookUpEdit客户.ValueMember = "cCusCode";
            // 
            // gridCol业务员
            // 
            this.gridCol业务员.Caption = "业务员";
            this.gridCol业务员.FieldName = "业务员";
            this.gridCol业务员.Name = "gridCol业务员";
            this.gridCol业务员.OptionsColumn.AllowEdit = false;
            this.gridCol业务员.OptionsColumn.AllowMerge = DevExpress.Utils.DefaultBoolean.False;
            this.gridCol业务员.Visible = true;
            this.gridCol业务员.VisibleIndex = 7;
            // 
            // gridCol存货编码
            // 
            this.gridCol存货编码.Caption = "存货编码";
            this.gridCol存货编码.FieldName = "存货编码";
            this.gridCol存货编码.Name = "gridCol存货编码";
            this.gridCol存货编码.OptionsColumn.AllowEdit = false;
            this.gridCol存货编码.OptionsColumn.AllowMerge = DevExpress.Utils.DefaultBoolean.False;
            this.gridCol存货编码.Visible = true;
            this.gridCol存货编码.VisibleIndex = 8;
            // 
            // gridCol存货名称
            // 
            this.gridCol存货名称.Caption = "存货名称";
            this.gridCol存货名称.ColumnEdit = this.ItemLookUpEdit存货名称;
            this.gridCol存货名称.FieldName = "存货编码";
            this.gridCol存货名称.Name = "gridCol存货名称";
            this.gridCol存货名称.OptionsColumn.AllowEdit = false;
            this.gridCol存货名称.OptionsColumn.AllowMerge = DevExpress.Utils.DefaultBoolean.False;
            this.gridCol存货名称.Visible = true;
            this.gridCol存货名称.VisibleIndex = 9;
            // 
            // ItemLookUpEdit存货名称
            // 
            this.ItemLookUpEdit存货名称.AutoHeight = false;
            this.ItemLookUpEdit存货名称.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.ItemLookUpEdit存货名称.DisplayMember = "cInvName";
            this.ItemLookUpEdit存货名称.Name = "ItemLookUpEdit存货名称";
            this.ItemLookUpEdit存货名称.NullText = "";
            this.ItemLookUpEdit存货名称.ValueMember = "cInvCode";
            // 
            // gridCol规格
            // 
            this.gridCol规格.Caption = "规格";
            this.gridCol规格.ColumnEdit = this.ItemLookUpEdit规格;
            this.gridCol规格.FieldName = "存货编码";
            this.gridCol规格.Name = "gridCol规格";
            this.gridCol规格.OptionsColumn.AllowEdit = false;
            this.gridCol规格.OptionsColumn.AllowMerge = DevExpress.Utils.DefaultBoolean.False;
            this.gridCol规格.Visible = true;
            this.gridCol规格.VisibleIndex = 10;
            // 
            // ItemLookUpEdit规格
            // 
            this.ItemLookUpEdit规格.AutoHeight = false;
            this.ItemLookUpEdit规格.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.ItemLookUpEdit规格.DisplayMember = "cInvStd";
            this.ItemLookUpEdit规格.Name = "ItemLookUpEdit规格";
            this.ItemLookUpEdit规格.ValueMember = "cInvCode";
            // 
            // gridCol含税单价
            // 
            this.gridCol含税单价.Caption = "含税单价";
            this.gridCol含税单价.FieldName = "含税单价";
            this.gridCol含税单价.Name = "gridCol含税单价";
            this.gridCol含税单价.OptionsColumn.AllowEdit = false;
            this.gridCol含税单价.OptionsColumn.AllowMerge = DevExpress.Utils.DefaultBoolean.False;
            this.gridCol含税单价.Visible = true;
            this.gridCol含税单价.VisibleIndex = 12;
            // 
            // gridCol出库数量
            // 
            this.gridCol出库数量.Caption = "出库数量";
            this.gridCol出库数量.FieldName = "出库数量";
            this.gridCol出库数量.Name = "gridCol出库数量";
            this.gridCol出库数量.OptionsColumn.AllowEdit = false;
            this.gridCol出库数量.OptionsColumn.AllowMerge = DevExpress.Utils.DefaultBoolean.False;
            this.gridCol出库数量.OptionsColumn.AllowMove = false;
            this.gridCol出库数量.OptionsColumn.AllowSort = DevExpress.Utils.DefaultBoolean.False;
            this.gridCol出库数量.OptionsFilter.AllowFilter = false;
            this.gridCol出库数量.Visible = true;
            this.gridCol出库数量.VisibleIndex = 11;
            // 
            // gridCol月份
            // 
            this.gridCol月份.Caption = "月份";
            this.gridCol月份.FieldName = "月份";
            this.gridCol月份.Name = "gridCol月份";
            this.gridCol月份.OptionsColumn.AllowEdit = false;
            this.gridCol月份.OptionsColumn.AllowMerge = DevExpress.Utils.DefaultBoolean.False;
            this.gridCol月份.Visible = true;
            this.gridCol月份.VisibleIndex = 1;
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btnLoad,
            this.btnSave});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Padding = new System.Windows.Forms.Padding(8, 2, 0, 2);
            this.menuStrip1.Size = new System.Drawing.Size(1400, 28);
            this.menuStrip1.TabIndex = 193;
            this.menuStrip1.Text = "menuStrip";
            // 
            // btnLoad
            // 
            this.btnLoad.Name = "btnLoad";
            this.btnLoad.Size = new System.Drawing.Size(51, 24);
            this.btnLoad.Text = "加载";
            this.btnLoad.Click += new System.EventHandler(this.btnLoad_Click);
            // 
            // btnSave
            // 
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(51, 24);
            this.btnSave.Text = "导入";
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // Frm发货单导入
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.ClientSize = new System.Drawing.Size(1400, 582);
            this.Controls.Add(this.menuStrip1);
            this.Controls.Add(this.gridControl1);
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "Frm发货单导入";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "ImportDispatchList ";
            this.Load += new System.EventHandler(this.Frm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ItemLookUpEditcWhCode)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ItemLookUpEditcWhName)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ItemLookUpEdit客户)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ItemLookUpEdit存货名称)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ItemLookUpEdit规格)).EndInit();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraGrid.GridControl gridControl1;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView1;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem btnLoad;
        private System.Windows.Forms.ToolStripMenuItem btnSave;
        private DevExpress.XtraGrid.Columns.GridColumn gridCol订单号;
        private DevExpress.XtraGrid.Columns.GridColumn gridCol出库数量;
        private DevExpress.XtraGrid.Columns.GridColumn gridCol仓库编码;
        private DevExpress.XtraGrid.Columns.GridColumn gridCol仓库;
        private DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit ItemLookUpEditcWhCode;
        private DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit ItemLookUpEditcWhName;
        private DevExpress.XtraGrid.Columns.GridColumn gridCol业务模式;
        private DevExpress.XtraGrid.Columns.GridColumn gridCol客户编码;
        private DevExpress.XtraGrid.Columns.GridColumn gridCol客户;
        private DevExpress.XtraGrid.Columns.GridColumn gridCol业务员;
        private DevExpress.XtraGrid.Columns.GridColumn gridCol存货编码;
        private DevExpress.XtraGrid.Columns.GridColumn gridCol存货名称;
        private DevExpress.XtraGrid.Columns.GridColumn gridCol规格;
        private DevExpress.XtraGrid.Columns.GridColumn gridCol含税单价;
        private DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit ItemLookUpEdit客户;
        private DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit ItemLookUpEdit存货名称;
        private DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit ItemLookUpEdit规格;
        private DevExpress.XtraGrid.Columns.GridColumn gridCol月份;

    }
}