namespace UFIDA.U8.UAP.CustomApp.ControlForm
{
    partial class SystemSet
    {
        /// <summary> 
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region 组件设计器生成的代码

        /// <summary> 
        /// 设计器支持所需的方法 - 不要
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.btnRefresh = new System.Windows.Forms.ToolStripMenuItem();
            this.btnSave = new System.Windows.Forms.ToolStripMenuItem();
            this.btnExport = new System.Windows.Forms.ToolStripMenuItem();
            this.gridControl1 = new DevExpress.XtraGrid.GridControl();
            this.gridView1 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.gridColcSTCode = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColcSTName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColcWhCode = new DevExpress.XtraGrid.Columns.GridColumn();
            this.ItemLookUpEditcWhCode = new DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit();
            this.gridColcWhName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.ItemLookUpEditcWhName = new DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit();
            this.gridColcRdCode = new DevExpress.XtraGrid.Columns.GridColumn();
            this.ItemLookUpEditcRdCode = new DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit();
            this.gridColcRdName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.ItemLookUpEditcRdName = new DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit();
            this.gridColSAPCode = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColSAPWorkCenter = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColInternalOrder = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColRemark = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColiState = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColCreateUid = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColCreateDate = new DevExpress.XtraGrid.Columns.GridColumn();
            this.panel1 = new System.Windows.Forms.Panel();
            this.menuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ItemLookUpEditcWhCode)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ItemLookUpEditcWhName)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ItemLookUpEditcRdCode)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ItemLookUpEditcRdName)).BeginInit();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btnRefresh,
            this.btnSave,
            this.btnExport});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(944, 25);
            this.menuStrip1.TabIndex = 172;
            this.menuStrip1.Text = "menuStrip";
            // 
            // btnRefresh
            // 
            this.btnRefresh.Name = "btnRefresh";
            this.btnRefresh.Size = new System.Drawing.Size(64, 21);
            this.btnRefresh.Text = "Refresh";
            this.btnRefresh.Click += new System.EventHandler(this.btnRefresh_Click);
            // 
            // btnSave
            // 
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(47, 21);
            this.btnSave.Text = "Save";
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // btnExport
            // 
            this.btnExport.Name = "btnExport";
            this.btnExport.Size = new System.Drawing.Size(58, 21);
            this.btnExport.Text = "Export";
            this.btnExport.Click += new System.EventHandler(this.btnExcel_Click);
            // 
            // gridControl1
            // 
            this.gridControl1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.gridControl1.Location = new System.Drawing.Point(3, 3);
            this.gridControl1.LookAndFeel.SkinName = "Office 2010 Blue";
            this.gridControl1.MainView = this.gridView1;
            this.gridControl1.Name = "gridControl1";
            this.gridControl1.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.ItemLookUpEditcWhCode,
            this.ItemLookUpEditcWhName,
            this.ItemLookUpEditcRdCode,
            this.ItemLookUpEditcRdName});
            this.gridControl1.Size = new System.Drawing.Size(938, 423);
            this.gridControl1.TabIndex = 191;
            this.gridControl1.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView1});
            // 
            // gridView1
            // 
            this.gridView1.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.gridColcSTCode,
            this.gridColcSTName,
            this.gridColcWhCode,
            this.gridColcWhName,
            this.gridColcRdCode,
            this.gridColcRdName,
            this.gridColSAPCode,
            this.gridColSAPWorkCenter,
            this.gridColInternalOrder,
            this.gridColRemark,
            this.gridColiState,
            this.gridColCreateUid,
            this.gridColCreateDate});
            this.gridView1.GridControl = this.gridControl1;
            this.gridView1.IndicatorWidth = 40;
            this.gridView1.Name = "gridView1";
            this.gridView1.OptionsBehavior.AllowDeleteRows = DevExpress.Utils.DefaultBoolean.True;
            this.gridView1.OptionsBehavior.EditorShowMode = DevExpress.Utils.EditorShowMode.MouseDown;
            this.gridView1.OptionsCustomization.AllowGroup = false;
            this.gridView1.OptionsCustomization.AllowQuickHideColumns = false;
            this.gridView1.OptionsNavigation.EnterMoveNextColumn = true;
            this.gridView1.OptionsPrint.AutoWidth = false;
            this.gridView1.OptionsView.ColumnAutoWidth = false;
            this.gridView1.OptionsView.ShowFooter = true;
            this.gridView1.OptionsView.ShowGroupPanel = false;
            this.gridView1.CustomDrawRowIndicator += new DevExpress.XtraGrid.Views.Grid.RowIndicatorCustomDrawEventHandler(this.gridView1_CustomDrawRowIndicator);
            this.gridView1.CellValueChanged += new DevExpress.XtraGrid.Views.Base.CellValueChangedEventHandler(this.gridView1_CellValueChanged);
            // 
            // gridColcSTCode
            // 
            this.gridColcSTCode.Caption = "Sales Type Code";
            this.gridColcSTCode.FieldName = "cSTCode";
            this.gridColcSTCode.Name = "gridColcSTCode";
            this.gridColcSTCode.OptionsColumn.AllowEdit = false;
            this.gridColcSTCode.Visible = true;
            this.gridColcSTCode.VisibleIndex = 0;
            this.gridColcSTCode.Width = 100;
            // 
            // gridColcSTName
            // 
            this.gridColcSTName.Caption = "Sales Type Name";
            this.gridColcSTName.FieldName = "cSTCode";
            this.gridColcSTName.Name = "gridColcSTName";
            this.gridColcSTName.OptionsColumn.AllowEdit = false;
            this.gridColcSTName.Visible = true;
            this.gridColcSTName.VisibleIndex = 1;
            this.gridColcSTName.Width = 105;
            // 
            // gridColcWhCode
            // 
            this.gridColcWhCode.Caption = "Default Warehouse";
            this.gridColcWhCode.ColumnEdit = this.ItemLookUpEditcWhCode;
            this.gridColcWhCode.FieldName = "cWhCode";
            this.gridColcWhCode.Name = "gridColcWhCode";
            this.gridColcWhCode.Visible = true;
            this.gridColcWhCode.VisibleIndex = 2;
            this.gridColcWhCode.Width = 133;
            // 
            // ItemLookUpEditcWhCode
            // 
            this.ItemLookUpEditcWhCode.AutoHeight = false;
            this.ItemLookUpEditcWhCode.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.ItemLookUpEditcWhCode.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("cWhCode", "WareHouseNo"),
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("cWhName", "WareHouse")});
            this.ItemLookUpEditcWhCode.DisplayMember = "cWhCode";
            this.ItemLookUpEditcWhCode.Name = "ItemLookUpEditcWhCode";
            this.ItemLookUpEditcWhCode.NullText = "";
            this.ItemLookUpEditcWhCode.PopupWidth = 400;
            this.ItemLookUpEditcWhCode.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.Standard;
            this.ItemLookUpEditcWhCode.ValueMember = "cWhCode";
            // 
            // gridColcWhName
            // 
            this.gridColcWhName.Caption = "Default Warehouse Name";
            this.gridColcWhName.ColumnEdit = this.ItemLookUpEditcWhName;
            this.gridColcWhName.FieldName = "cWhCode";
            this.gridColcWhName.Name = "gridColcWhName";
            this.gridColcWhName.Visible = true;
            this.gridColcWhName.VisibleIndex = 3;
            this.gridColcWhName.Width = 167;
            // 
            // ItemLookUpEditcWhName
            // 
            this.ItemLookUpEditcWhName.AutoHeight = false;
            this.ItemLookUpEditcWhName.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.ItemLookUpEditcWhName.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("cWhCode", "WareHouseNo"),
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("cWhName", "WareHouse")});
            this.ItemLookUpEditcWhName.DisplayMember = "cWhName";
            this.ItemLookUpEditcWhName.Name = "ItemLookUpEditcWhName";
            this.ItemLookUpEditcWhName.NullText = "";
            this.ItemLookUpEditcWhName.PopupWidth = 400;
            this.ItemLookUpEditcWhName.ValueMember = "cWhCode";
            // 
            // gridColcRdCode
            // 
            this.gridColcRdCode.Caption = "Receipt Category Code";
            this.gridColcRdCode.ColumnEdit = this.ItemLookUpEditcRdCode;
            this.gridColcRdCode.FieldName = "cRdCode";
            this.gridColcRdCode.Name = "gridColcRdCode";
            this.gridColcRdCode.Visible = true;
            this.gridColcRdCode.VisibleIndex = 4;
            this.gridColcRdCode.Width = 162;
            // 
            // ItemLookUpEditcRdCode
            // 
            this.ItemLookUpEditcRdCode.AutoHeight = false;
            this.ItemLookUpEditcRdCode.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.ItemLookUpEditcRdCode.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("cRdCode", "收发类别编码"),
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("cRdName", "收发类别名称")});
            this.ItemLookUpEditcRdCode.DisplayMember = "cRdCode";
            this.ItemLookUpEditcRdCode.Name = "ItemLookUpEditcRdCode";
            this.ItemLookUpEditcRdCode.NullText = "";
            this.ItemLookUpEditcRdCode.PopupWidth = 400;
            this.ItemLookUpEditcRdCode.ValueMember = "cRdCode";
            // 
            // gridColcRdName
            // 
            this.gridColcRdName.Caption = "Receipt Category Name";
            this.gridColcRdName.ColumnEdit = this.ItemLookUpEditcRdName;
            this.gridColcRdName.FieldName = "cRdCode";
            this.gridColcRdName.Name = "gridColcRdName";
            this.gridColcRdName.Visible = true;
            this.gridColcRdName.VisibleIndex = 5;
            this.gridColcRdName.Width = 150;
            // 
            // ItemLookUpEditcRdName
            // 
            this.ItemLookUpEditcRdName.AutoHeight = false;
            this.ItemLookUpEditcRdName.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.ItemLookUpEditcRdName.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("cRdCode", "收发类别编码"),
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("cRdName", "收发类别名称")});
            this.ItemLookUpEditcRdName.DisplayMember = "cRdName";
            this.ItemLookUpEditcRdName.Name = "ItemLookUpEditcRdName";
            this.ItemLookUpEditcRdName.NullText = "";
            this.ItemLookUpEditcRdName.PopupWidth = 400;
            this.ItemLookUpEditcRdName.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.Standard;
            this.ItemLookUpEditcRdName.ValueMember = "cRdCode";
            // 
            // gridColSAPCode
            // 
            this.gridColSAPCode.Caption = "SAP Item Code";
            this.gridColSAPCode.FieldName = "SAPCode";
            this.gridColSAPCode.Name = "gridColSAPCode";
            this.gridColSAPCode.Visible = true;
            this.gridColSAPCode.VisibleIndex = 6;
            this.gridColSAPCode.Width = 105;
            // 
            // gridColSAPWorkCenter
            // 
            this.gridColSAPWorkCenter.Caption = "SAP Cost Centre";
            this.gridColSAPWorkCenter.FieldName = "SAPWorkCenter";
            this.gridColSAPWorkCenter.Name = "gridColSAPWorkCenter";
            this.gridColSAPWorkCenter.Visible = true;
            this.gridColSAPWorkCenter.VisibleIndex = 7;
            this.gridColSAPWorkCenter.Width = 109;
            // 
            // gridColInternalOrder
            // 
            this.gridColInternalOrder.Caption = "Internal Order (SAP Internal Code)";
            this.gridColInternalOrder.FieldName = "InternalOrder";
            this.gridColInternalOrder.Name = "gridColInternalOrder";
            this.gridColInternalOrder.Visible = true;
            this.gridColInternalOrder.VisibleIndex = 8;
            this.gridColInternalOrder.Width = 240;
            // 
            // gridColRemark
            // 
            this.gridColRemark.Caption = "Remark";
            this.gridColRemark.FieldName = "Remark";
            this.gridColRemark.Name = "gridColRemark";
            this.gridColRemark.OptionsColumn.AllowSort = DevExpress.Utils.DefaultBoolean.False;
            this.gridColRemark.Visible = true;
            this.gridColRemark.VisibleIndex = 9;
            this.gridColRemark.Width = 276;
            // 
            // gridColiState
            // 
            this.gridColiState.Caption = "iState";
            this.gridColiState.FieldName = "iState";
            this.gridColiState.Name = "gridColiState";
            this.gridColiState.OptionsColumn.AllowEdit = false;
            this.gridColiState.OptionsColumn.AllowSort = DevExpress.Utils.DefaultBoolean.False;
            // 
            // gridColCreateUid
            // 
            this.gridColCreateUid.Caption = "Creater";
            this.gridColCreateUid.FieldName = "CreaterUid";
            this.gridColCreateUid.Name = "gridColCreateUid";
            this.gridColCreateUid.OptionsColumn.AllowEdit = false;
            this.gridColCreateUid.OptionsColumn.AllowSort = DevExpress.Utils.DefaultBoolean.False;
            // 
            // gridColCreateDate
            // 
            this.gridColCreateDate.Caption = "CreateDate";
            this.gridColCreateDate.FieldName = "CreaterDate";
            this.gridColCreateDate.Name = "gridColCreateDate";
            this.gridColCreateDate.OptionsColumn.AllowEdit = false;
            this.gridColCreateDate.OptionsColumn.AllowSort = DevExpress.Utils.DefaultBoolean.False;
            this.gridColCreateDate.Width = 150;
            // 
            // panel1
            // 
            this.panel1.AutoScroll = true;
            this.panel1.Controls.Add(this.gridControl1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 25);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(944, 431);
            this.panel1.TabIndex = 173;
            // 
            // SystemSet
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.menuStrip1);
            this.Name = "SystemSet";
            this.Size = new System.Drawing.Size(944, 456);
            this.Load += new System.EventHandler(this.Frm_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ItemLookUpEditcWhCode)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ItemLookUpEditcWhName)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ItemLookUpEditcRdCode)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ItemLookUpEditcRdName)).EndInit();
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem btnSave;
        private DevExpress.XtraGrid.GridControl gridControl1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.ToolStripMenuItem btnRefresh;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView1;
        private DevExpress.XtraGrid.Columns.GridColumn gridColCreateUid;
        private DevExpress.XtraGrid.Columns.GridColumn gridColCreateDate;
        private DevExpress.XtraGrid.Columns.GridColumn gridColRemark;
        private System.Windows.Forms.ToolStripMenuItem btnExport;
        private DevExpress.XtraGrid.Columns.GridColumn gridColiState;
        private DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit ItemLookUpEditcWhCode;
        private DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit ItemLookUpEditcWhName;
        private DevExpress.XtraGrid.Columns.GridColumn gridColcSTCode;
        private DevExpress.XtraGrid.Columns.GridColumn gridColcSTName;
        private DevExpress.XtraGrid.Columns.GridColumn gridColcWhCode;
        private DevExpress.XtraGrid.Columns.GridColumn gridColcWhName;
        private DevExpress.XtraGrid.Columns.GridColumn gridColcRdCode;
        private DevExpress.XtraGrid.Columns.GridColumn gridColcRdName;
        private DevExpress.XtraGrid.Columns.GridColumn gridColSAPCode;
        private DevExpress.XtraGrid.Columns.GridColumn gridColSAPWorkCenter;
        private DevExpress.XtraGrid.Columns.GridColumn gridColInternalOrder;
        private DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit ItemLookUpEditcRdCode;
        private DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit ItemLookUpEditcRdName;
    }
}
