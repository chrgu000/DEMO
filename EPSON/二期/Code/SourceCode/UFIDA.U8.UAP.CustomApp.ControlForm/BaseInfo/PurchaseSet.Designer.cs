namespace UFIDA.U8.UAP.CustomApp.ControlForm
{
    partial class PurchaseSet
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
            this.btnAddRow = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem2 = new System.Windows.Forms.ToolStripMenuItem();
            this.btnDEL = new System.Windows.Forms.ToolStripMenuItem();
            this.btnSave = new System.Windows.Forms.ToolStripMenuItem();
            this.btnExport = new System.Windows.Forms.ToolStripMenuItem();
            this.gridControl1 = new DevExpress.XtraGrid.GridControl();
            this.gridView1 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.gridColiID = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColCreateUid = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColCreateDate = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColiState = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColReasonCode = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColDescription = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColCostCenter = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColCostCentreDescription = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColGLAccountCode = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColGLAccountDescription = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColInternalOrder = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColHeadtext = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColReasonname = new DevExpress.XtraGrid.Columns.GridColumn();
            this.ItemLookUpEditcWhCode = new DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit();
            this.ItemLookUpEditcWhName = new DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit();
            this.ItemLookUpEditcasetype = new DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit();
            this.panel1 = new System.Windows.Forms.Panel();
            this.menuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ItemLookUpEditcWhCode)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ItemLookUpEditcWhName)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ItemLookUpEditcasetype)).BeginInit();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btnRefresh,
            this.btnAddRow,
            this.btnDEL,
            this.btnSave,
            this.btnExport});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(945, 25);
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
            // btnAddRow
            // 
            this.btnAddRow.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripMenuItem2});
            this.btnAddRow.Name = "btnAddRow";
            this.btnAddRow.Size = new System.Drawing.Size(73, 21);
            this.btnAddRow.Text = "Add Row";
            this.btnAddRow.Click += new System.EventHandler(this.btnAddRow_Click_1);
            // 
            // toolStripMenuItem2
            // 
            this.toolStripMenuItem2.Name = "toolStripMenuItem2";
            this.toolStripMenuItem2.Size = new System.Drawing.Size(80, 22);
            this.toolStripMenuItem2.Text = " ";
            // 
            // btnDEL
            // 
            this.btnDEL.Name = "btnDEL";
            this.btnDEL.Size = new System.Drawing.Size(57, 21);
            this.btnDEL.Text = "Delete";
            this.btnDEL.Click += new System.EventHandler(this.btnDEL_Click);
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
            this.ItemLookUpEditcasetype});
            this.gridControl1.Size = new System.Drawing.Size(939, 423);
            this.gridControl1.TabIndex = 191;
            this.gridControl1.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView1});
            // 
            // gridView1
            // 
            this.gridView1.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.gridColiID,
            this.gridColCreateUid,
            this.gridColCreateDate,
            this.gridColiState,
            this.gridColReasonCode,
            this.gridColDescription,
            this.gridColCostCenter,
            this.gridColCostCentreDescription,
            this.gridColGLAccountCode,
            this.gridColGLAccountDescription,
            this.gridColInternalOrder,
            this.gridColHeadtext,
            this.gridColReasonname});
            this.gridView1.GridControl = this.gridControl1;
            this.gridView1.IndicatorWidth = 40;
            this.gridView1.Name = "gridView1";
            this.gridView1.OptionsBehavior.AllowDeleteRows = DevExpress.Utils.DefaultBoolean.True;
            this.gridView1.OptionsBehavior.EditorShowMode = DevExpress.Utils.EditorShowMode.MouseDown;
            this.gridView1.OptionsCustomization.AllowGroup = false;
            this.gridView1.OptionsCustomization.AllowQuickHideColumns = false;
            this.gridView1.OptionsCustomization.AllowSort = false;
            this.gridView1.OptionsNavigation.EnterMoveNextColumn = true;
            this.gridView1.OptionsPrint.AutoWidth = false;
            this.gridView1.OptionsView.ColumnAutoWidth = false;
            this.gridView1.OptionsView.ShowFooter = true;
            this.gridView1.OptionsView.ShowGroupPanel = false;
            this.gridView1.CustomDrawRowIndicator += new DevExpress.XtraGrid.Views.Grid.RowIndicatorCustomDrawEventHandler(this.gridView1_CustomDrawRowIndicator);
            this.gridView1.CellValueChanged += new DevExpress.XtraGrid.Views.Base.CellValueChangedEventHandler(this.gridView1_CellValueChanged);
            // 
            // gridColiID
            // 
            this.gridColiID.Caption = "iID";
            this.gridColiID.FieldName = "iID";
            this.gridColiID.Name = "gridColiID";
            this.gridColiID.OptionsColumn.AllowEdit = false;
            this.gridColiID.OptionsColumn.AllowSort = DevExpress.Utils.DefaultBoolean.False;
            this.gridColiID.Width = 58;
            // 
            // gridColCreateUid
            // 
            this.gridColCreateUid.Caption = "Creater";
            this.gridColCreateUid.FieldName = "Creater";
            this.gridColCreateUid.Name = "gridColCreateUid";
            this.gridColCreateUid.OptionsColumn.AllowEdit = false;
            this.gridColCreateUid.OptionsColumn.AllowSort = DevExpress.Utils.DefaultBoolean.False;
            // 
            // gridColCreateDate
            // 
            this.gridColCreateDate.Caption = "CreateDate";
            this.gridColCreateDate.FieldName = "CreateDate";
            this.gridColCreateDate.Name = "gridColCreateDate";
            this.gridColCreateDate.OptionsColumn.AllowEdit = false;
            this.gridColCreateDate.OptionsColumn.AllowSort = DevExpress.Utils.DefaultBoolean.False;
            this.gridColCreateDate.Width = 112;
            // 
            // gridColiState
            // 
            this.gridColiState.Caption = "iState";
            this.gridColiState.FieldName = "iState";
            this.gridColiState.Name = "gridColiState";
            this.gridColiState.OptionsColumn.AllowEdit = false;
            this.gridColiState.OptionsColumn.AllowSort = DevExpress.Utils.DefaultBoolean.False;
            // 
            // gridColReasonCode
            // 
            this.gridColReasonCode.Caption = "Reason Code";
            this.gridColReasonCode.FieldName = "ReasonCode";
            this.gridColReasonCode.Name = "gridColReasonCode";
            this.gridColReasonCode.Visible = true;
            this.gridColReasonCode.VisibleIndex = 0;
            this.gridColReasonCode.Width = 135;
            // 
            // gridColDescription
            // 
            this.gridColDescription.Caption = "Description";
            this.gridColDescription.FieldName = "Description";
            this.gridColDescription.Name = "gridColDescription";
            this.gridColDescription.Visible = true;
            this.gridColDescription.VisibleIndex = 3;
            // 
            // gridColCostCenter
            // 
            this.gridColCostCenter.Caption = "Cost Center";
            this.gridColCostCenter.FieldName = "CostCenter";
            this.gridColCostCenter.Name = "gridColCostCenter";
            this.gridColCostCenter.Visible = true;
            this.gridColCostCenter.VisibleIndex = 4;
            // 
            // gridColCostCentreDescription
            // 
            this.gridColCostCentreDescription.Caption = "Cost Center Description";
            this.gridColCostCentreDescription.FieldName = "CostCentreDescription";
            this.gridColCostCentreDescription.Name = "gridColCostCentreDescription";
            this.gridColCostCentreDescription.Visible = true;
            this.gridColCostCentreDescription.VisibleIndex = 5;
            this.gridColCostCentreDescription.Width = 121;
            // 
            // gridColGLAccountCode
            // 
            this.gridColGLAccountCode.Caption = "GL Account Code";
            this.gridColGLAccountCode.FieldName = "GLAccountCode";
            this.gridColGLAccountCode.Name = "gridColGLAccountCode";
            this.gridColGLAccountCode.Visible = true;
            this.gridColGLAccountCode.VisibleIndex = 6;
            this.gridColGLAccountCode.Width = 140;
            // 
            // gridColGLAccountDescription
            // 
            this.gridColGLAccountDescription.Caption = "GL Account Description";
            this.gridColGLAccountDescription.FieldName = "GLAccountDescription";
            this.gridColGLAccountDescription.Name = "gridColGLAccountDescription";
            this.gridColGLAccountDescription.Visible = true;
            this.gridColGLAccountDescription.VisibleIndex = 7;
            this.gridColGLAccountDescription.Width = 154;
            // 
            // gridColInternalOrder
            // 
            this.gridColInternalOrder.Caption = "Internal Order";
            this.gridColInternalOrder.FieldName = "InternalOrder";
            this.gridColInternalOrder.Name = "gridColInternalOrder";
            this.gridColInternalOrder.Visible = true;
            this.gridColInternalOrder.VisibleIndex = 8;
            // 
            // gridColHeadtext
            // 
            this.gridColHeadtext.Caption = "Head text";
            this.gridColHeadtext.FieldName = "Headtext";
            this.gridColHeadtext.Name = "gridColHeadtext";
            this.gridColHeadtext.Visible = true;
            this.gridColHeadtext.VisibleIndex = 2;
            // 
            // gridColReasonname
            // 
            this.gridColReasonname.Caption = "Reason name";
            this.gridColReasonname.FieldName = "Reasonname";
            this.gridColReasonname.Name = "gridColReasonname";
            this.gridColReasonname.Visible = true;
            this.gridColReasonname.VisibleIndex = 1;
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
            this.ItemLookUpEditcWhCode.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.Standard;
            this.ItemLookUpEditcWhCode.ValueMember = "cWhCode";
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
            this.ItemLookUpEditcWhName.ValueMember = "cWhCode";
            // 
            // ItemLookUpEditcasetype
            // 
            this.ItemLookUpEditcasetype.AutoHeight = false;
            this.ItemLookUpEditcasetype.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.ItemLookUpEditcasetype.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("casetype", "Case Type")});
            this.ItemLookUpEditcasetype.DisplayMember = "casetype";
            this.ItemLookUpEditcasetype.Name = "ItemLookUpEditcasetype";
            this.ItemLookUpEditcasetype.NullText = "";
            this.ItemLookUpEditcasetype.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.Standard;
            this.ItemLookUpEditcasetype.ValueMember = "casetype";
            // 
            // panel1
            // 
            this.panel1.AutoScroll = true;
            this.panel1.Controls.Add(this.gridControl1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 25);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(945, 431);
            this.panel1.TabIndex = 173;
            // 
            // PurchaseSet
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.menuStrip1);
            this.Name = "PurchaseSet";
            this.Size = new System.Drawing.Size(945, 456);
            this.Load += new System.EventHandler(this.Frm_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ItemLookUpEditcWhCode)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ItemLookUpEditcWhName)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ItemLookUpEditcasetype)).EndInit();
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem btnSave;
        private DevExpress.XtraGrid.GridControl gridControl1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.ToolStripMenuItem btnDEL;
        private System.Windows.Forms.ToolStripMenuItem btnRefresh;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView1;
        private DevExpress.XtraGrid.Columns.GridColumn gridColCreateUid;
        private DevExpress.XtraGrid.Columns.GridColumn gridColCreateDate;
        private DevExpress.XtraGrid.Columns.GridColumn gridColiID;
        private System.Windows.Forms.ToolStripMenuItem btnExport;
        private DevExpress.XtraGrid.Columns.GridColumn gridColiState;
        private DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit ItemLookUpEditcWhCode;
        private DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit ItemLookUpEditcWhName;
        private DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit ItemLookUpEditcasetype;
        private DevExpress.XtraGrid.Columns.GridColumn gridColReasonCode;
        private DevExpress.XtraGrid.Columns.GridColumn gridColDescription;
        private DevExpress.XtraGrid.Columns.GridColumn gridColCostCenter;
        private DevExpress.XtraGrid.Columns.GridColumn gridColCostCentreDescription;
        private DevExpress.XtraGrid.Columns.GridColumn gridColGLAccountCode;
        private DevExpress.XtraGrid.Columns.GridColumn gridColGLAccountDescription;
        private DevExpress.XtraGrid.Columns.GridColumn gridColInternalOrder;
        private System.Windows.Forms.ToolStripMenuItem btnAddRow;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem2;
        private DevExpress.XtraGrid.Columns.GridColumn gridColHeadtext;
        private DevExpress.XtraGrid.Columns.GridColumn gridColReasonname;
    }
}
