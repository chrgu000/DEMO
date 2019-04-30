namespace clsU8
{
    partial class Frm产成品入库单导入
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
            this.gridCol仓库编码 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.ItemLookUpEditWarehouse = new DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit();
            this.gridCol仓库 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.ItemLookUpEditWareHouseName = new DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit();
            this.gridCol入库类别 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridCol部门 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.ItemLookUpEditcDepCode = new DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit();
            this.gridCol存货编码 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.ItemLookUpEditcInvCode = new DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit();
            this.gridCol存货名称 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.ItemLookUpEditcInvName = new DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit();
            this.gridCol规格型号 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.ItemLookUpEditcInvStd = new DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit();
            this.gridCol数量 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridCol件数 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.btnLoad = new System.Windows.Forms.ToolStripMenuItem();
            this.btnSave = new System.Windows.Forms.ToolStripMenuItem();
            this.dateEdit1 = new DevExpress.XtraEditors.DateEdit();
            this.label1 = new System.Windows.Forms.Label();
            this.gridCol班组 = new DevExpress.XtraGrid.Columns.GridColumn();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ItemLookUpEditWarehouse)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ItemLookUpEditWareHouseName)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ItemLookUpEditcDepCode)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ItemLookUpEditcInvCode)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ItemLookUpEditcInvName)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ItemLookUpEditcInvStd)).BeginInit();
            this.menuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dateEdit1.Properties.VistaTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dateEdit1.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // gridControl1
            // 
            this.gridControl1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.gridControl1.Location = new System.Drawing.Point(0, 59);
            this.gridControl1.LookAndFeel.SkinName = "Office 2010 Blue";
            this.gridControl1.MainView = this.gridView1;
            this.gridControl1.Name = "gridControl1";
            this.gridControl1.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.ItemLookUpEditcInvCode,
            this.ItemLookUpEditcInvName,
            this.ItemLookUpEditcInvStd,
            this.ItemLookUpEditWarehouse,
            this.ItemLookUpEditWareHouseName,
            this.ItemLookUpEditcDepCode});
            this.gridControl1.Size = new System.Drawing.Size(1046, 407);
            this.gridControl1.TabIndex = 192;
            this.gridControl1.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView1});
            // 
            // gridView1
            // 
            this.gridView1.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.gridCol仓库编码,
            this.gridCol仓库,
            this.gridCol入库类别,
            this.gridCol部门,
            this.gridCol存货编码,
            this.gridCol存货名称,
            this.gridCol规格型号,
            this.gridCol数量,
            this.gridCol件数,
            this.gridCol班组});
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
            // gridCol仓库编码
            // 
            this.gridCol仓库编码.AppearanceHeader.BackColor = System.Drawing.Color.Blue;
            this.gridCol仓库编码.AppearanceHeader.ForeColor = System.Drawing.Color.Blue;
            this.gridCol仓库编码.AppearanceHeader.Options.UseBackColor = true;
            this.gridCol仓库编码.AppearanceHeader.Options.UseForeColor = true;
            this.gridCol仓库编码.Caption = "仓库编码";
            this.gridCol仓库编码.ColumnEdit = this.ItemLookUpEditWarehouse;
            this.gridCol仓库编码.FieldName = "仓库";
            this.gridCol仓库编码.Name = "gridCol仓库编码";
            this.gridCol仓库编码.OptionsColumn.AllowEdit = false;
            this.gridCol仓库编码.OptionsColumn.AllowMerge = DevExpress.Utils.DefaultBoolean.True;
            this.gridCol仓库编码.OptionsColumn.AllowMove = false;
            this.gridCol仓库编码.OptionsColumn.AllowSort = DevExpress.Utils.DefaultBoolean.False;
            this.gridCol仓库编码.OptionsFilter.AllowFilter = false;
            this.gridCol仓库编码.Visible = true;
            this.gridCol仓库编码.VisibleIndex = 0;
            // 
            // ItemLookUpEditWarehouse
            // 
            this.ItemLookUpEditWarehouse.AutoHeight = false;
            this.ItemLookUpEditWarehouse.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.ItemLookUpEditWarehouse.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("cWhCode", "仓库编码"),
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("cWhName", "仓库")});
            this.ItemLookUpEditWarehouse.DisplayMember = "cWhCode";
            this.ItemLookUpEditWarehouse.Name = "ItemLookUpEditWarehouse";
            this.ItemLookUpEditWarehouse.NullText = "";
            this.ItemLookUpEditWarehouse.ValueMember = "cWhCode";
            // 
            // gridCol仓库
            // 
            this.gridCol仓库.Caption = "仓库";
            this.gridCol仓库.ColumnEdit = this.ItemLookUpEditWareHouseName;
            this.gridCol仓库.FieldName = "仓库";
            this.gridCol仓库.Name = "gridCol仓库";
            this.gridCol仓库.Visible = true;
            this.gridCol仓库.VisibleIndex = 1;
            // 
            // ItemLookUpEditWareHouseName
            // 
            this.ItemLookUpEditWareHouseName.AutoHeight = false;
            this.ItemLookUpEditWareHouseName.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.ItemLookUpEditWareHouseName.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("cWhCode", "仓库编码"),
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("cWhName", "仓库")});
            this.ItemLookUpEditWareHouseName.DisplayMember = "cWhName";
            this.ItemLookUpEditWareHouseName.Name = "ItemLookUpEditWareHouseName";
            this.ItemLookUpEditWareHouseName.NullText = "";
            this.ItemLookUpEditWareHouseName.ValueMember = "cWhCode";
            // 
            // gridCol入库类别
            // 
            this.gridCol入库类别.Caption = "入库类别";
            this.gridCol入库类别.FieldName = "入库类别";
            this.gridCol入库类别.Name = "gridCol入库类别";
            this.gridCol入库类别.OptionsColumn.AllowEdit = false;
            this.gridCol入库类别.OptionsColumn.AllowMerge = DevExpress.Utils.DefaultBoolean.True;
            this.gridCol入库类别.OptionsColumn.AllowMove = false;
            this.gridCol入库类别.OptionsColumn.AllowSort = DevExpress.Utils.DefaultBoolean.False;
            this.gridCol入库类别.OptionsFilter.AllowFilter = false;
            this.gridCol入库类别.Visible = true;
            this.gridCol入库类别.VisibleIndex = 2;
            // 
            // gridCol部门
            // 
            this.gridCol部门.AppearanceHeader.BackColor = System.Drawing.Color.Blue;
            this.gridCol部门.AppearanceHeader.ForeColor = System.Drawing.Color.Blue;
            this.gridCol部门.AppearanceHeader.Options.UseBackColor = true;
            this.gridCol部门.AppearanceHeader.Options.UseForeColor = true;
            this.gridCol部门.Caption = "部门";
            this.gridCol部门.ColumnEdit = this.ItemLookUpEditcDepCode;
            this.gridCol部门.FieldName = "部门";
            this.gridCol部门.Name = "gridCol部门";
            this.gridCol部门.OptionsColumn.AllowEdit = false;
            this.gridCol部门.OptionsColumn.AllowMerge = DevExpress.Utils.DefaultBoolean.True;
            this.gridCol部门.OptionsColumn.AllowMove = false;
            this.gridCol部门.OptionsColumn.AllowSort = DevExpress.Utils.DefaultBoolean.False;
            this.gridCol部门.OptionsFilter.AllowFilter = false;
            this.gridCol部门.Visible = true;
            this.gridCol部门.VisibleIndex = 3;
            // 
            // ItemLookUpEditcDepCode
            // 
            this.ItemLookUpEditcDepCode.AutoHeight = false;
            this.ItemLookUpEditcDepCode.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.ItemLookUpEditcDepCode.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("cDepCode", "部门编码"),
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("cDepName", "部门")});
            this.ItemLookUpEditcDepCode.DisplayMember = "cDepName";
            this.ItemLookUpEditcDepCode.Name = "ItemLookUpEditcDepCode";
            this.ItemLookUpEditcDepCode.NullText = "";
            this.ItemLookUpEditcDepCode.UseParentBackground = true;
            this.ItemLookUpEditcDepCode.ValueMember = "cDepCode";
            // 
            // gridCol存货编码
            // 
            this.gridCol存货编码.AppearanceHeader.BackColor = System.Drawing.Color.Blue;
            this.gridCol存货编码.AppearanceHeader.ForeColor = System.Drawing.Color.Blue;
            this.gridCol存货编码.AppearanceHeader.Options.UseBackColor = true;
            this.gridCol存货编码.AppearanceHeader.Options.UseForeColor = true;
            this.gridCol存货编码.Caption = "存货编码";
            this.gridCol存货编码.ColumnEdit = this.ItemLookUpEditcInvCode;
            this.gridCol存货编码.FieldName = "存货编码";
            this.gridCol存货编码.Name = "gridCol存货编码";
            this.gridCol存货编码.OptionsColumn.AllowEdit = false;
            this.gridCol存货编码.OptionsColumn.AllowMerge = DevExpress.Utils.DefaultBoolean.False;
            this.gridCol存货编码.OptionsColumn.AllowMove = false;
            this.gridCol存货编码.OptionsColumn.AllowSort = DevExpress.Utils.DefaultBoolean.False;
            this.gridCol存货编码.OptionsFilter.AllowFilter = false;
            this.gridCol存货编码.Visible = true;
            this.gridCol存货编码.VisibleIndex = 5;
            // 
            // ItemLookUpEditcInvCode
            // 
            this.ItemLookUpEditcInvCode.AutoHeight = false;
            this.ItemLookUpEditcInvCode.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.ItemLookUpEditcInvCode.DisplayMember = "cInvCode";
            this.ItemLookUpEditcInvCode.Name = "ItemLookUpEditcInvCode";
            this.ItemLookUpEditcInvCode.NullText = "";
            this.ItemLookUpEditcInvCode.ValueMember = "cInvCode";
            // 
            // gridCol存货名称
            // 
            this.gridCol存货名称.Caption = "存货名称";
            this.gridCol存货名称.ColumnEdit = this.ItemLookUpEditcInvName;
            this.gridCol存货名称.FieldName = "存货编码";
            this.gridCol存货名称.Name = "gridCol存货名称";
            this.gridCol存货名称.OptionsColumn.AllowEdit = false;
            this.gridCol存货名称.OptionsColumn.AllowMerge = DevExpress.Utils.DefaultBoolean.False;
            this.gridCol存货名称.OptionsColumn.AllowMove = false;
            this.gridCol存货名称.OptionsColumn.AllowSort = DevExpress.Utils.DefaultBoolean.False;
            this.gridCol存货名称.OptionsFilter.AllowFilter = false;
            this.gridCol存货名称.Visible = true;
            this.gridCol存货名称.VisibleIndex = 6;
            // 
            // ItemLookUpEditcInvName
            // 
            this.ItemLookUpEditcInvName.AutoHeight = false;
            this.ItemLookUpEditcInvName.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.ItemLookUpEditcInvName.DisplayMember = "cInvName";
            this.ItemLookUpEditcInvName.Name = "ItemLookUpEditcInvName";
            this.ItemLookUpEditcInvName.NullText = "";
            this.ItemLookUpEditcInvName.ValueMember = "cInvCode";
            // 
            // gridCol规格型号
            // 
            this.gridCol规格型号.Caption = "规格型号";
            this.gridCol规格型号.ColumnEdit = this.ItemLookUpEditcInvStd;
            this.gridCol规格型号.FieldName = "存货编码";
            this.gridCol规格型号.Name = "gridCol规格型号";
            this.gridCol规格型号.OptionsColumn.AllowEdit = false;
            this.gridCol规格型号.OptionsColumn.AllowMerge = DevExpress.Utils.DefaultBoolean.False;
            this.gridCol规格型号.OptionsColumn.AllowMove = false;
            this.gridCol规格型号.OptionsColumn.AllowSort = DevExpress.Utils.DefaultBoolean.False;
            this.gridCol规格型号.OptionsFilter.AllowFilter = false;
            this.gridCol规格型号.Visible = true;
            this.gridCol规格型号.VisibleIndex = 7;
            // 
            // ItemLookUpEditcInvStd
            // 
            this.ItemLookUpEditcInvStd.AutoHeight = false;
            this.ItemLookUpEditcInvStd.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.ItemLookUpEditcInvStd.DisplayMember = "cInvSTd";
            this.ItemLookUpEditcInvStd.Name = "ItemLookUpEditcInvStd";
            this.ItemLookUpEditcInvStd.NullText = "";
            this.ItemLookUpEditcInvStd.ValueMember = "cInvCode";
            // 
            // gridCol数量
            // 
            this.gridCol数量.AppearanceHeader.BackColor = System.Drawing.Color.Blue;
            this.gridCol数量.AppearanceHeader.ForeColor = System.Drawing.Color.Blue;
            this.gridCol数量.AppearanceHeader.Options.UseBackColor = true;
            this.gridCol数量.AppearanceHeader.Options.UseForeColor = true;
            this.gridCol数量.Caption = "数量";
            this.gridCol数量.FieldName = "数量";
            this.gridCol数量.Name = "gridCol数量";
            this.gridCol数量.OptionsColumn.AllowEdit = false;
            this.gridCol数量.OptionsColumn.AllowMerge = DevExpress.Utils.DefaultBoolean.False;
            this.gridCol数量.OptionsColumn.AllowMove = false;
            this.gridCol数量.OptionsColumn.AllowSort = DevExpress.Utils.DefaultBoolean.False;
            this.gridCol数量.OptionsFilter.AllowFilter = false;
            this.gridCol数量.Visible = true;
            this.gridCol数量.VisibleIndex = 8;
            // 
            // gridCol件数
            // 
            this.gridCol件数.AppearanceHeader.BackColor = System.Drawing.Color.Blue;
            this.gridCol件数.AppearanceHeader.ForeColor = System.Drawing.Color.Blue;
            this.gridCol件数.AppearanceHeader.Options.UseBackColor = true;
            this.gridCol件数.AppearanceHeader.Options.UseForeColor = true;
            this.gridCol件数.Caption = "件数";
            this.gridCol件数.FieldName = "件数";
            this.gridCol件数.Name = "gridCol件数";
            this.gridCol件数.OptionsColumn.AllowEdit = false;
            this.gridCol件数.OptionsColumn.AllowMerge = DevExpress.Utils.DefaultBoolean.False;
            this.gridCol件数.OptionsColumn.AllowMove = false;
            this.gridCol件数.OptionsColumn.AllowSort = DevExpress.Utils.DefaultBoolean.False;
            this.gridCol件数.OptionsFilter.AllowFilter = false;
            this.gridCol件数.Visible = true;
            this.gridCol件数.VisibleIndex = 9;
            this.gridCol件数.Width = 103;
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btnLoad,
            this.btnSave});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(1046, 25);
            this.menuStrip1.TabIndex = 193;
            this.menuStrip1.Text = "menuStrip";
            // 
            // btnLoad
            // 
            this.btnLoad.Name = "btnLoad";
            this.btnLoad.Size = new System.Drawing.Size(44, 21);
            this.btnLoad.Text = "加载";
            this.btnLoad.Click += new System.EventHandler(this.btnLoad_Click);
            // 
            // btnSave
            // 
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(44, 21);
            this.btnSave.Text = "导入";
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // dateEdit1
            // 
            this.dateEdit1.EditValue = null;
            this.dateEdit1.Location = new System.Drawing.Point(79, 33);
            this.dateEdit1.Name = "dateEdit1";
            this.dateEdit1.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.dateEdit1.Properties.VistaTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
            this.dateEdit1.Size = new System.Drawing.Size(141, 20);
            this.dateEdit1.TabIndex = 214;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(21, 36);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(53, 12);
            this.label1.TabIndex = 215;
            this.label1.Text = "导入日期";
            // 
            // gridCol班组
            // 
            this.gridCol班组.Caption = "班组";
            this.gridCol班组.FieldName = "班组";
            this.gridCol班组.Name = "gridCol班组";
            this.gridCol班组.Visible = true;
            this.gridCol班组.VisibleIndex = 4;
            this.gridCol班组.Width = 93;
            // 
            // Frm产成品入库单导入
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.ClientSize = new System.Drawing.Size(1046, 466);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.dateEdit1);
            this.Controls.Add(this.menuStrip1);
            this.Controls.Add(this.gridControl1);
            this.Name = "Frm产成品入库单导入";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "ImportRD10";
            this.Load += new System.EventHandler(this.Frm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ItemLookUpEditWarehouse)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ItemLookUpEditWareHouseName)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ItemLookUpEditcDepCode)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ItemLookUpEditcInvCode)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ItemLookUpEditcInvName)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ItemLookUpEditcInvStd)).EndInit();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dateEdit1.Properties.VistaTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dateEdit1.Properties)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraGrid.GridControl gridControl1;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView1;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem btnLoad;
        private System.Windows.Forms.ToolStripMenuItem btnSave;
        private DevExpress.XtraEditors.DateEdit dateEdit1;
        private System.Windows.Forms.Label label1;
        private DevExpress.XtraGrid.Columns.GridColumn gridCol仓库编码;
        private DevExpress.XtraGrid.Columns.GridColumn gridCol入库类别;
        private DevExpress.XtraGrid.Columns.GridColumn gridCol部门;
        private DevExpress.XtraGrid.Columns.GridColumn gridCol存货编码;
        private DevExpress.XtraGrid.Columns.GridColumn gridCol存货名称;
        private DevExpress.XtraGrid.Columns.GridColumn gridCol规格型号;
        private DevExpress.XtraGrid.Columns.GridColumn gridCol数量;
        private DevExpress.XtraGrid.Columns.GridColumn gridCol件数;
        private DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit ItemLookUpEditcInvCode;
        private DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit ItemLookUpEditcInvName;
        private DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit ItemLookUpEditcInvStd;
        private DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit ItemLookUpEditWarehouse;
        private DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit ItemLookUpEditWareHouseName;
        private DevExpress.XtraGrid.Columns.GridColumn gridCol仓库;
        private DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit ItemLookUpEditcDepCode;
        private DevExpress.XtraGrid.Columns.GridColumn gridCol班组;

    }
}