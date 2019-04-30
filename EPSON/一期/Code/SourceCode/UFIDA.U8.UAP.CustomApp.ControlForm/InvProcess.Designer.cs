namespace UFIDA.U8.UAP.CustomApp.ControlForm
{
    partial class InvProcess
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
            this.btnDEL = new System.Windows.Forms.ToolStripMenuItem();
            this.btnSave = new System.Windows.Forms.ToolStripMenuItem();
            this.btnExport = new System.Windows.Forms.ToolStripMenuItem();
            this.gridControl1 = new DevExpress.XtraGrid.GridControl();
            this.gridView1 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.gridColiID = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColItemCode = new DevExpress.XtraGrid.Columns.GridColumn();
            this.ItemButtonEditcInvCode = new DevExpress.XtraEditors.Repository.RepositoryItemButtonEdit();
            this.gridColItemName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.ItemLookUpEditcInvName = new DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit();
            this.gridColProcessRow = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColProcessNo = new DevExpress.XtraGrid.Columns.GridColumn();
            this.ItemLookUpEditProcessNo = new DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit();
            this.gridColProcess = new DevExpress.XtraGrid.Columns.GridColumn();
            this.ItemLookUpEditProcess = new DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit();
            this.gridColRemark = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColCreateUid = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColCreateDate = new DevExpress.XtraGrid.Columns.GridColumn();
            this.panel1 = new System.Windows.Forms.Panel();
            this.lookUpEditInvName = new DevExpress.XtraEditors.LookUpEdit();
            this.label1 = new System.Windows.Forms.Label();
            this.btnTxtInvCode = new DevExpress.XtraEditors.ButtonEdit();
            this.menuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ItemButtonEditcInvCode)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ItemLookUpEditcInvName)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ItemLookUpEditProcessNo)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ItemLookUpEditProcess)).BeginInit();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.lookUpEditInvName.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnTxtInvCode.Properties)).BeginInit();
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
            // btnAddRow
            // 
            this.btnAddRow.Name = "btnAddRow";
            this.btnAddRow.Size = new System.Drawing.Size(73, 21);
            this.btnAddRow.Text = "Add Row";
            this.btnAddRow.Click += new System.EventHandler(this.btnAddRow_Click);
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
            this.gridControl1.Location = new System.Drawing.Point(3, 62);
            this.gridControl1.LookAndFeel.SkinName = "Office 2010 Blue";
            this.gridControl1.MainView = this.gridView1;
            this.gridControl1.Name = "gridControl1";
            this.gridControl1.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.ItemLookUpEditcInvName,
            this.ItemLookUpEditProcessNo,
            this.ItemLookUpEditProcess,
            this.ItemButtonEditcInvCode});
            this.gridControl1.Size = new System.Drawing.Size(938, 363);
            this.gridControl1.TabIndex = 191;
            this.gridControl1.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView1});
            // 
            // gridView1
            // 
            this.gridView1.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.gridColiID,
            this.gridColItemCode,
            this.gridColItemName,
            this.gridColProcessRow,
            this.gridColProcessNo,
            this.gridColProcess,
            this.gridColRemark,
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
            // gridColiID
            // 
            this.gridColiID.Caption = "iID";
            this.gridColiID.FieldName = "iID";
            this.gridColiID.Name = "gridColiID";
            this.gridColiID.OptionsColumn.AllowEdit = false;
            this.gridColiID.OptionsColumn.AllowSort = DevExpress.Utils.DefaultBoolean.False;
            this.gridColiID.Width = 58;
            // 
            // gridColItemCode
            // 
            this.gridColItemCode.Caption = "ItemCode";
            this.gridColItemCode.ColumnEdit = this.ItemButtonEditcInvCode;
            this.gridColItemCode.FieldName = "cInvCode";
            this.gridColItemCode.Name = "gridColItemCode";
            this.gridColItemCode.OptionsColumn.AllowSort = DevExpress.Utils.DefaultBoolean.False;
            this.gridColItemCode.Width = 136;
            // 
            // ItemButtonEditcInvCode
            // 
            this.ItemButtonEditcInvCode.AutoHeight = false;
            this.ItemButtonEditcInvCode.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
            this.ItemButtonEditcInvCode.Name = "ItemButtonEditcInvCode";
            this.ItemButtonEditcInvCode.ButtonClick += new DevExpress.XtraEditors.Controls.ButtonPressedEventHandler(this.ItemButtonEditcInvCode_ButtonClick);
            // 
            // gridColItemName
            // 
            this.gridColItemName.Caption = "ItemName";
            this.gridColItemName.ColumnEdit = this.ItemLookUpEditcInvName;
            this.gridColItemName.FieldName = "cInvCode";
            this.gridColItemName.Name = "gridColItemName";
            this.gridColItemName.OptionsColumn.AllowSort = DevExpress.Utils.DefaultBoolean.False;
            this.gridColItemName.Width = 201;
            // 
            // ItemLookUpEditcInvName
            // 
            this.ItemLookUpEditcInvName.AutoHeight = false;
            this.ItemLookUpEditcInvName.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.ItemLookUpEditcInvName.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("cInvCode", "ItemCode"),
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("cInvName", "ItemName")});
            this.ItemLookUpEditcInvName.DisplayMember = "cInvName";
            this.ItemLookUpEditcInvName.Name = "ItemLookUpEditcInvName";
            this.ItemLookUpEditcInvName.NullText = "";
            this.ItemLookUpEditcInvName.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.Standard;
            this.ItemLookUpEditcInvName.ValueMember = "cInvCode";
            // 
            // gridColProcessRow
            // 
            this.gridColProcessRow.Caption = "ProcessSeq";
            this.gridColProcessRow.FieldName = "ProcessRow";
            this.gridColProcessRow.Name = "gridColProcessRow";
            this.gridColProcessRow.OptionsColumn.AllowSort = DevExpress.Utils.DefaultBoolean.False;
            this.gridColProcessRow.Visible = true;
            this.gridColProcessRow.VisibleIndex = 0;
            // 
            // gridColProcessNo
            // 
            this.gridColProcessNo.Caption = "ProcessNo";
            this.gridColProcessNo.ColumnEdit = this.ItemLookUpEditProcessNo;
            this.gridColProcessNo.FieldName = "ProcessNo";
            this.gridColProcessNo.Name = "gridColProcessNo";
            this.gridColProcessNo.OptionsColumn.AllowSort = DevExpress.Utils.DefaultBoolean.False;
            this.gridColProcessNo.Visible = true;
            this.gridColProcessNo.VisibleIndex = 1;
            this.gridColProcessNo.Width = 111;
            // 
            // ItemLookUpEditProcessNo
            // 
            this.ItemLookUpEditProcessNo.AutoHeight = false;
            this.ItemLookUpEditProcessNo.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.ItemLookUpEditProcessNo.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("ProcessNo", "ProcessSeq"),
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("Process", "ProcessNo")});
            this.ItemLookUpEditProcessNo.DisplayMember = "ProcessNo";
            this.ItemLookUpEditProcessNo.Name = "ItemLookUpEditProcessNo";
            this.ItemLookUpEditProcessNo.NullText = "";
            this.ItemLookUpEditProcessNo.ValueMember = "ProcessNo";
            // 
            // gridColProcess
            // 
            this.gridColProcess.Caption = "Process";
            this.gridColProcess.ColumnEdit = this.ItemLookUpEditProcess;
            this.gridColProcess.FieldName = "ProcessNo";
            this.gridColProcess.Name = "gridColProcess";
            this.gridColProcess.OptionsColumn.AllowSort = DevExpress.Utils.DefaultBoolean.False;
            this.gridColProcess.Visible = true;
            this.gridColProcess.VisibleIndex = 2;
            this.gridColProcess.Width = 148;
            // 
            // ItemLookUpEditProcess
            // 
            this.ItemLookUpEditProcess.AutoHeight = false;
            this.ItemLookUpEditProcess.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.ItemLookUpEditProcess.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("ProcessNo", "ProcessSeq"),
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("Process", "Process")});
            this.ItemLookUpEditProcess.DisplayMember = "Process";
            this.ItemLookUpEditProcess.Name = "ItemLookUpEditProcess";
            this.ItemLookUpEditProcess.NullText = "";
            this.ItemLookUpEditProcess.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.Standard;
            this.ItemLookUpEditProcess.ValueMember = "ProcessNo";
            // 
            // gridColRemark
            // 
            this.gridColRemark.Caption = "Remark";
            this.gridColRemark.FieldName = "Remark";
            this.gridColRemark.Name = "gridColRemark";
            this.gridColRemark.OptionsColumn.AllowSort = DevExpress.Utils.DefaultBoolean.False;
            this.gridColRemark.Visible = true;
            this.gridColRemark.VisibleIndex = 3;
            this.gridColRemark.Width = 276;
            // 
            // gridColCreateUid
            // 
            this.gridColCreateUid.Caption = "Creater";
            this.gridColCreateUid.FieldName = "CreateUid";
            this.gridColCreateUid.Name = "gridColCreateUid";
            this.gridColCreateUid.OptionsColumn.AllowEdit = false;
            this.gridColCreateUid.OptionsColumn.AllowSort = DevExpress.Utils.DefaultBoolean.False;
            this.gridColCreateUid.Visible = true;
            this.gridColCreateUid.VisibleIndex = 4;
            // 
            // gridColCreateDate
            // 
            this.gridColCreateDate.Caption = "CreateDate";
            this.gridColCreateDate.FieldName = "CreateDate";
            this.gridColCreateDate.Name = "gridColCreateDate";
            this.gridColCreateDate.OptionsColumn.AllowEdit = false;
            this.gridColCreateDate.OptionsColumn.AllowSort = DevExpress.Utils.DefaultBoolean.False;
            this.gridColCreateDate.Visible = true;
            this.gridColCreateDate.VisibleIndex = 5;
            // 
            // panel1
            // 
            this.panel1.AutoScroll = true;
            this.panel1.Controls.Add(this.lookUpEditInvName);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.btnTxtInvCode);
            this.panel1.Controls.Add(this.gridControl1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 25);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(944, 431);
            this.panel1.TabIndex = 173;
            // 
            // lookUpEditInvName
            // 
            this.lookUpEditInvName.Location = new System.Drawing.Point(231, 24);
            this.lookUpEditInvName.Name = "lookUpEditInvName";
            this.lookUpEditInvName.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.lookUpEditInvName.Properties.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("cInvCode", "Item Code"),
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("cInvName", "Item Name")});
            this.lookUpEditInvName.Properties.DisplayMember = "cInvName";
            this.lookUpEditInvName.Properties.NullText = "";
            this.lookUpEditInvName.Properties.ValueMember = "cInvCode";
            this.lookUpEditInvName.Size = new System.Drawing.Size(196, 20);
            this.lookUpEditInvName.TabIndex = 194;
            this.lookUpEditInvName.EditValueChanged += new System.EventHandler(this.lookUpEditInvName_EditValueChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(25, 29);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(59, 12);
            this.label1.TabIndex = 193;
            this.label1.Text = "Item Code";
            // 
            // btnTxtInvCode
            // 
            this.btnTxtInvCode.Location = new System.Drawing.Point(100, 24);
            this.btnTxtInvCode.Name = "btnTxtInvCode";
            this.btnTxtInvCode.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
            this.btnTxtInvCode.Size = new System.Drawing.Size(125, 20);
            this.btnTxtInvCode.TabIndex = 192;
            this.btnTxtInvCode.ButtonClick += new DevExpress.XtraEditors.Controls.ButtonPressedEventHandler(this.btnTxtInvCode_ButtonClick);
            this.btnTxtInvCode.KeyUp += new System.Windows.Forms.KeyEventHandler(this.btnTxtInvCode_KeyUp);
            this.btnTxtInvCode.Validated += new System.EventHandler(this.btnTxtInvCode_Validated);
            // 
            // InvProcess
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.menuStrip1);
            this.Name = "InvProcess";
            this.Size = new System.Drawing.Size(944, 456);
            this.Load += new System.EventHandler(this.Frm_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ItemButtonEditcInvCode)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ItemLookUpEditcInvName)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ItemLookUpEditProcessNo)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ItemLookUpEditProcess)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.lookUpEditInvName.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnTxtInvCode.Properties)).EndInit();
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
        private DevExpress.XtraGrid.Columns.GridColumn gridColProcessNo;
        private DevExpress.XtraGrid.Columns.GridColumn gridColProcess;
        private DevExpress.XtraGrid.Columns.GridColumn gridColCreateUid;
        private DevExpress.XtraGrid.Columns.GridColumn gridColCreateDate;
        private DevExpress.XtraGrid.Columns.GridColumn gridColiID;
        private DevExpress.XtraGrid.Columns.GridColumn gridColRemark;
        private System.Windows.Forms.ToolStripMenuItem btnAddRow;
        private System.Windows.Forms.ToolStripMenuItem btnExport;
        private DevExpress.XtraGrid.Columns.GridColumn gridColItemCode;
        private DevExpress.XtraGrid.Columns.GridColumn gridColItemName;
        private DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit ItemLookUpEditcInvName;
        private DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit ItemLookUpEditProcessNo;
        private DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit ItemLookUpEditProcess;
        private DevExpress.XtraEditors.Repository.RepositoryItemButtonEdit ItemButtonEditcInvCode;
        private DevExpress.XtraEditors.LookUpEdit lookUpEditInvName;
        private System.Windows.Forms.Label label1;
        private DevExpress.XtraEditors.ButtonEdit btnTxtInvCode;
        private DevExpress.XtraGrid.Columns.GridColumn gridColProcessRow;
    }
}
