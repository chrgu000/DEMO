namespace UFIDA.U8.UAP.CustomApp.ControlForm
{
    partial class ActionFCost
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
            this.btnLoad = new System.Windows.Forms.ToolStripMenuItem();
            this.btnEdit = new System.Windows.Forms.ToolStripMenuItem();
            this.btnSave = new System.Windows.Forms.ToolStripMenuItem();
            this.btnDelete = new System.Windows.Forms.ToolStripMenuItem();
            this.btnExport = new System.Windows.Forms.ToolStripMenuItem();
            this.gridControl1 = new DevExpress.XtraGrid.GridControl();
            this.gridView1 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.gridColcCusCode = new DevExpress.XtraGrid.Columns.GridColumn();
            this.ItemLookUpEditcCusCode = new DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit();
            this.gridColcCusName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.ItemLookUpEditcCusName = new DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit();
            this.gridColcInvCode = new DevExpress.XtraGrid.Columns.GridColumn();
            this.ItemLookUpEditcInvCode = new DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit();
            this.gridColcInvName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.ItemLookUpEditcInvName = new DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit();
            this.gridColActionCode = new DevExpress.XtraGrid.Columns.GridColumn();
            this.ItemLookUpEditActionCode = new DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit();
            this.gridColAction = new DevExpress.XtraGrid.Columns.GridColumn();
            this.ItemLookUpEditAction = new DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit();
            this.gridColLabour = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColProcess = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColPlatingCost = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColPart = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColdtmStart = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColdtmEnd = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColiID = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColsStatus = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColMANHOUR = new DevExpress.XtraGrid.Columns.GridColumn();
            this.panel1 = new System.Windows.Forms.Panel();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.lookUpEditcCusName = new DevExpress.XtraEditors.LookUpEdit();
            this.lookUpEditcCusCode = new DevExpress.XtraEditors.LookUpEdit();
            this.label2 = new System.Windows.Forms.Label();
            this.dateEdit1 = new DevExpress.XtraEditors.DateEdit();
            this.label1 = new System.Windows.Forms.Label();
            this.dtmStartImprot = new DevExpress.XtraEditors.DateEdit();
            this.label12 = new System.Windows.Forms.Label();
            this.menuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ItemLookUpEditcCusCode)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ItemLookUpEditcCusName)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ItemLookUpEditcInvCode)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ItemLookUpEditcInvName)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ItemLookUpEditActionCode)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ItemLookUpEditAction)).BeginInit();
            this.panel1.SuspendLayout();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.lookUpEditcCusName.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lookUpEditcCusCode.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dateEdit1.Properties.VistaTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dateEdit1.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtmStartImprot.Properties.VistaTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtmStartImprot.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btnRefresh,
            this.btnAddRow,
            this.btnLoad,
            this.btnEdit,
            this.btnSave,
            this.btnDelete,
            this.btnExport});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Padding = new System.Windows.Forms.Padding(8, 2, 0, 2);
            this.menuStrip1.Size = new System.Drawing.Size(1329, 24);
            this.menuStrip1.TabIndex = 172;
            this.menuStrip1.Text = "menuStrip";
            // 
            // btnRefresh
            // 
            this.btnRefresh.BackColor = System.Drawing.SystemColors.Control;
            this.btnRefresh.Name = "btnRefresh";
            this.btnRefresh.Size = new System.Drawing.Size(75, 20);
            this.btnRefresh.Text = "Refresh";
            this.btnRefresh.Click += new System.EventHandler(this.btnRefresh_Click);
            // 
            // btnAddRow
            // 
            this.btnAddRow.Name = "btnAddRow";
            this.btnAddRow.Size = new System.Drawing.Size(75, 20);
            this.btnAddRow.Text = "Add Row";
            this.btnAddRow.Click += new System.EventHandler(this.btnAddRow_Click_1);
            // 
            // btnLoad
            // 
            this.btnLoad.Name = "btnLoad";
            this.btnLoad.Size = new System.Drawing.Size(51, 20);
            this.btnLoad.Text = "Load";
            this.btnLoad.Click += new System.EventHandler(this.btnLoad_Click);
            // 
            // btnEdit
            // 
            this.btnEdit.Name = "btnEdit";
            this.btnEdit.Size = new System.Drawing.Size(51, 20);
            this.btnEdit.Text = "Edit";
            this.btnEdit.Click += new System.EventHandler(this.btnEdit_Click);
            // 
            // btnSave
            // 
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(51, 20);
            this.btnSave.Text = "Save";
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // btnDelete
            // 
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(67, 20);
            this.btnDelete.Text = "Delete";
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // btnExport
            // 
            this.btnExport.Name = "btnExport";
            this.btnExport.Size = new System.Drawing.Size(67, 20);
            this.btnExport.Text = "Export";
            this.btnExport.Click += new System.EventHandler(this.btnExport_Click);
            // 
            // gridControl1
            // 
            this.gridControl1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.gridControl1.EmbeddedNavigator.Margin = new System.Windows.Forms.Padding(4);
            this.gridControl1.Location = new System.Drawing.Point(0, 130);
            this.gridControl1.LookAndFeel.SkinName = "Office 2010 Blue";
            this.gridControl1.MainView = this.gridView1;
            this.gridControl1.Margin = new System.Windows.Forms.Padding(4);
            this.gridControl1.Name = "gridControl1";
            this.gridControl1.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.ItemLookUpEditActionCode,
            this.ItemLookUpEditcInvCode,
            this.ItemLookUpEditcInvName,
            this.ItemLookUpEditcCusCode,
            this.ItemLookUpEditcCusName,
            this.ItemLookUpEditAction});
            this.gridControl1.Size = new System.Drawing.Size(1329, 469);
            this.gridControl1.TabIndex = 191;
            this.gridControl1.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView1});
            // 
            // gridView1
            // 
            this.gridView1.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.gridColcCusCode,
            this.gridColcCusName,
            this.gridColcInvCode,
            this.gridColcInvName,
            this.gridColActionCode,
            this.gridColAction,
            this.gridColLabour,
            this.gridColProcess,
            this.gridColPlatingCost,
            this.gridColPart,
            this.gridColdtmStart,
            this.gridColdtmEnd,
            this.gridColiID,
            this.gridColsStatus,
            this.gridColMANHOUR});
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
            // gridColcCusCode
            // 
            this.gridColcCusCode.Caption = "Customer Code";
            this.gridColcCusCode.ColumnEdit = this.ItemLookUpEditcCusCode;
            this.gridColcCusCode.FieldName = "cCusCode";
            this.gridColcCusCode.Name = "gridColcCusCode";
            this.gridColcCusCode.Visible = true;
            this.gridColcCusCode.VisibleIndex = 0;
            this.gridColcCusCode.Width = 120;
            // 
            // ItemLookUpEditcCusCode
            // 
            this.ItemLookUpEditcCusCode.AutoHeight = false;
            this.ItemLookUpEditcCusCode.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.ItemLookUpEditcCusCode.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("cCusCode", 30, "Customer Code"),
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("cCusName", 70, "Customer Name")});
            this.ItemLookUpEditcCusCode.DisplayMember = "cCusCode";
            this.ItemLookUpEditcCusCode.Name = "ItemLookUpEditcCusCode";
            this.ItemLookUpEditcCusCode.NullText = "";
            this.ItemLookUpEditcCusCode.PopupWidth = 500;
            this.ItemLookUpEditcCusCode.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.Standard;
            this.ItemLookUpEditcCusCode.ValueMember = "cCusCode";
            // 
            // gridColcCusName
            // 
            this.gridColcCusName.Caption = "Customer Name";
            this.gridColcCusName.ColumnEdit = this.ItemLookUpEditcCusName;
            this.gridColcCusName.FieldName = "cCusCode";
            this.gridColcCusName.Name = "gridColcCusName";
            this.gridColcCusName.Visible = true;
            this.gridColcCusName.VisibleIndex = 1;
            this.gridColcCusName.Width = 175;
            // 
            // ItemLookUpEditcCusName
            // 
            this.ItemLookUpEditcCusName.AutoHeight = false;
            this.ItemLookUpEditcCusName.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.ItemLookUpEditcCusName.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("cCusCode", "Customer Code"),
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("cCusName", "Customer Name")});
            this.ItemLookUpEditcCusName.DisplayMember = "cCusName";
            this.ItemLookUpEditcCusName.Name = "ItemLookUpEditcCusName";
            this.ItemLookUpEditcCusName.NullText = "";
            this.ItemLookUpEditcCusName.PopupWidth = 500;
            this.ItemLookUpEditcCusName.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.Standard;
            this.ItemLookUpEditcCusName.ValueMember = "cCusCode";
            // 
            // gridColcInvCode
            // 
            this.gridColcInvCode.Caption = "Part No";
            this.gridColcInvCode.ColumnEdit = this.ItemLookUpEditcInvCode;
            this.gridColcInvCode.FieldName = "cInvCode";
            this.gridColcInvCode.Name = "gridColcInvCode";
            this.gridColcInvCode.Visible = true;
            this.gridColcInvCode.VisibleIndex = 2;
            this.gridColcInvCode.Width = 92;
            // 
            // ItemLookUpEditcInvCode
            // 
            this.ItemLookUpEditcInvCode.AutoHeight = false;
            this.ItemLookUpEditcInvCode.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.ItemLookUpEditcInvCode.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("cInvCode", "Part No"),
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("cInvName", 80, "Description")});
            this.ItemLookUpEditcInvCode.DisplayMember = "cInvCode";
            this.ItemLookUpEditcInvCode.Name = "ItemLookUpEditcInvCode";
            this.ItemLookUpEditcInvCode.NullText = "";
            this.ItemLookUpEditcInvCode.PopupWidth = 400;
            this.ItemLookUpEditcInvCode.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.Standard;
            this.ItemLookUpEditcInvCode.ValueMember = "cInvCode";
            // 
            // gridColcInvName
            // 
            this.gridColcInvName.Caption = "Description";
            this.gridColcInvName.ColumnEdit = this.ItemLookUpEditcInvName;
            this.gridColcInvName.FieldName = "cInvCode";
            this.gridColcInvName.Name = "gridColcInvName";
            this.gridColcInvName.Visible = true;
            this.gridColcInvName.VisibleIndex = 3;
            this.gridColcInvName.Width = 110;
            // 
            // ItemLookUpEditcInvName
            // 
            this.ItemLookUpEditcInvName.AutoHeight = false;
            this.ItemLookUpEditcInvName.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.ItemLookUpEditcInvName.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("cInvCode", "Part No"),
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("cInvName", 80, "Description")});
            this.ItemLookUpEditcInvName.DisplayMember = "cInvName";
            this.ItemLookUpEditcInvName.Name = "ItemLookUpEditcInvName";
            this.ItemLookUpEditcInvName.NullText = "";
            this.ItemLookUpEditcInvName.PopupWidth = 400;
            this.ItemLookUpEditcInvName.ValueMember = "cInvCode";
            // 
            // gridColActionCode
            // 
            this.gridColActionCode.Caption = "ActionCode";
            this.gridColActionCode.ColumnEdit = this.ItemLookUpEditActionCode;
            this.gridColActionCode.FieldName = "ActionCode";
            this.gridColActionCode.Name = "gridColActionCode";
            this.gridColActionCode.Visible = true;
            this.gridColActionCode.VisibleIndex = 4;
            this.gridColActionCode.Width = 132;
            // 
            // ItemLookUpEditActionCode
            // 
            this.ItemLookUpEditActionCode.AutoHeight = false;
            this.ItemLookUpEditActionCode.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.ItemLookUpEditActionCode.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("ActionCode", "Action Code"),
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("Action", "Action")});
            this.ItemLookUpEditActionCode.DisplayMember = "ActionCode";
            this.ItemLookUpEditActionCode.Name = "ItemLookUpEditActionCode";
            this.ItemLookUpEditActionCode.NullText = "";
            this.ItemLookUpEditActionCode.PopupWidth = 400;
            this.ItemLookUpEditActionCode.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.Standard;
            this.ItemLookUpEditActionCode.ValueMember = "ActionCode";
            // 
            // gridColAction
            // 
            this.gridColAction.Caption = "Action";
            this.gridColAction.ColumnEdit = this.ItemLookUpEditAction;
            this.gridColAction.FieldName = "ActionCode";
            this.gridColAction.Name = "gridColAction";
            this.gridColAction.Visible = true;
            this.gridColAction.VisibleIndex = 5;
            this.gridColAction.Width = 117;
            // 
            // ItemLookUpEditAction
            // 
            this.ItemLookUpEditAction.AutoHeight = false;
            this.ItemLookUpEditAction.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.ItemLookUpEditAction.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("ActionCode", "Action Code"),
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("Action", "Action")});
            this.ItemLookUpEditAction.DisplayMember = "Action";
            this.ItemLookUpEditAction.Name = "ItemLookUpEditAction";
            this.ItemLookUpEditAction.NullText = "";
            this.ItemLookUpEditAction.PopupWidth = 400;
            this.ItemLookUpEditAction.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.Standard;
            this.ItemLookUpEditAction.ValueMember = "ActionCode";
            // 
            // gridColLabour
            // 
            this.gridColLabour.Caption = "Labour";
            this.gridColLabour.FieldName = "Labour";
            this.gridColLabour.Name = "gridColLabour";
            this.gridColLabour.Visible = true;
            this.gridColLabour.VisibleIndex = 7;
            // 
            // gridColProcess
            // 
            this.gridColProcess.Caption = "Process";
            this.gridColProcess.FieldName = "Process";
            this.gridColProcess.Name = "gridColProcess";
            this.gridColProcess.Visible = true;
            this.gridColProcess.VisibleIndex = 8;
            // 
            // gridColPlatingCost
            // 
            this.gridColPlatingCost.Caption = "Plating Cost";
            this.gridColPlatingCost.FieldName = "PlatingCost";
            this.gridColPlatingCost.Name = "gridColPlatingCost";
            this.gridColPlatingCost.Visible = true;
            this.gridColPlatingCost.VisibleIndex = 9;
            this.gridColPlatingCost.Width = 92;
            // 
            // gridColPart
            // 
            this.gridColPart.Caption = "Part";
            this.gridColPart.FieldName = "Part";
            this.gridColPart.Name = "gridColPart";
            this.gridColPart.Visible = true;
            this.gridColPart.VisibleIndex = 10;
            // 
            // gridColdtmStart
            // 
            this.gridColdtmStart.Caption = "Start Date";
            this.gridColdtmStart.FieldName = "dtmStart";
            this.gridColdtmStart.Name = "gridColdtmStart";
            this.gridColdtmStart.Visible = true;
            this.gridColdtmStart.VisibleIndex = 11;
            this.gridColdtmStart.Width = 103;
            // 
            // gridColdtmEnd
            // 
            this.gridColdtmEnd.Caption = "End Date";
            this.gridColdtmEnd.FieldName = "dtmEnd";
            this.gridColdtmEnd.Name = "gridColdtmEnd";
            this.gridColdtmEnd.OptionsColumn.AllowEdit = false;
            this.gridColdtmEnd.Visible = true;
            this.gridColdtmEnd.VisibleIndex = 12;
            this.gridColdtmEnd.Width = 107;
            // 
            // gridColiID
            // 
            this.gridColiID.Caption = "iID";
            this.gridColiID.FieldName = "iID";
            this.gridColiID.Name = "gridColiID";
            this.gridColiID.OptionsColumn.AllowEdit = false;
            // 
            // gridColsStatus
            // 
            this.gridColsStatus.Caption = "sStatus";
            this.gridColsStatus.FieldName = "sStatus";
            this.gridColsStatus.Name = "gridColsStatus";
            this.gridColsStatus.OptionsColumn.AllowEdit = false;
            // 
            // gridColMANHOUR
            // 
            this.gridColMANHOUR.Caption = "MAN-HOUR";
            this.gridColMANHOUR.DisplayFormat.FormatString = "n2";
            this.gridColMANHOUR.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.gridColMANHOUR.FieldName = "MANHOUR";
            this.gridColMANHOUR.Name = "gridColMANHOUR";
            this.gridColMANHOUR.Visible = true;
            this.gridColMANHOUR.VisibleIndex = 6;
            this.gridColMANHOUR.Width = 90;
            // 
            // panel1
            // 
            this.panel1.AutoScroll = true;
            this.panel1.Controls.Add(this.groupBox1);
            this.panel1.Controls.Add(this.dtmStartImprot);
            this.panel1.Controls.Add(this.label12);
            this.panel1.Controls.Add(this.gridControl1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 24);
            this.panel1.Margin = new System.Windows.Forms.Padding(4);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1329, 599);
            this.panel1.TabIndex = 173;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.lookUpEditcCusName);
            this.groupBox1.Controls.Add(this.lookUpEditcCusCode);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.dateEdit1);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Location = new System.Drawing.Point(24, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(831, 79);
            this.groupBox1.TabIndex = 289;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Filter";
            // 
            // lookUpEditcCusName
            // 
            this.lookUpEditcCusName.Location = new System.Drawing.Point(264, 47);
            this.lookUpEditcCusName.Margin = new System.Windows.Forms.Padding(4);
            this.lookUpEditcCusName.Name = "lookUpEditcCusName";
            this.lookUpEditcCusName.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.lookUpEditcCusName.Properties.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("cCusCode", 40, "Customer No"),
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("cCusName", 60, "Description")});
            this.lookUpEditcCusName.Properties.DisplayMember = "cCusName";
            this.lookUpEditcCusName.Properties.NullText = "";
            this.lookUpEditcCusName.Properties.PopupWidth = 500;
            this.lookUpEditcCusName.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.Standard;
            this.lookUpEditcCusName.Properties.ValueMember = "cCusCode";
            this.lookUpEditcCusName.Size = new System.Drawing.Size(560, 24);
            this.lookUpEditcCusName.TabIndex = 291;
            this.lookUpEditcCusName.EditValueChanged += new System.EventHandler(this.lookUpEditcCusName_EditValueChanged);
            // 
            // lookUpEditcCusCode
            // 
            this.lookUpEditcCusCode.Location = new System.Drawing.Point(106, 47);
            this.lookUpEditcCusCode.Margin = new System.Windows.Forms.Padding(4);
            this.lookUpEditcCusCode.Name = "lookUpEditcCusCode";
            this.lookUpEditcCusCode.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.lookUpEditcCusCode.Properties.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("cCusCode", 40, "Customer No"),
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("cCusName", 60, "Description")});
            this.lookUpEditcCusCode.Properties.DisplayMember = "cCusCode";
            this.lookUpEditcCusCode.Properties.NullText = "";
            this.lookUpEditcCusCode.Properties.PopupWidth = 500;
            this.lookUpEditcCusCode.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.Standard;
            this.lookUpEditcCusCode.Properties.ValueMember = "cCusCode";
            this.lookUpEditcCusCode.Size = new System.Drawing.Size(150, 24);
            this.lookUpEditcCusCode.TabIndex = 290;
            this.lookUpEditcCusCode.EditValueChanged += new System.EventHandler(this.lookUpEditcCusCode_EditValueChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(29, 52);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(71, 15);
            this.label2.TabIndex = 289;
            this.label2.Text = "Customer";
            // 
            // dateEdit1
            // 
            this.dateEdit1.EditValue = null;
            this.dateEdit1.Enabled = false;
            this.dateEdit1.Location = new System.Drawing.Point(109, 17);
            this.dateEdit1.Margin = new System.Windows.Forms.Padding(4);
            this.dateEdit1.Name = "dateEdit1";
            this.dateEdit1.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.dateEdit1.Properties.VistaTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
            this.dateEdit1.Size = new System.Drawing.Size(147, 24);
            this.dateEdit1.TabIndex = 287;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Enabled = false;
            this.label1.Location = new System.Drawing.Point(15, 22);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(87, 15);
            this.label1.TabIndex = 288;
            this.label1.Text = "Start Date";
            // 
            // dtmStartImprot
            // 
            this.dtmStartImprot.EditValue = null;
            this.dtmStartImprot.Enabled = false;
            this.dtmStartImprot.Location = new System.Drawing.Point(293, 98);
            this.dtmStartImprot.Margin = new System.Windows.Forms.Padding(4);
            this.dtmStartImprot.Name = "dtmStartImprot";
            this.dtmStartImprot.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.dtmStartImprot.Properties.VistaTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
            this.dtmStartImprot.Size = new System.Drawing.Size(193, 24);
            this.dtmStartImprot.TabIndex = 285;
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Enabled = false;
            this.label12.Location = new System.Drawing.Point(23, 103);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(263, 15);
            this.label12.TabIndex = 286;
            this.label12.Text = "Start Date(Auto edit start date)";
            // 
            // ActionFCost
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.menuStrip1);
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "ActionFCost";
            this.Size = new System.Drawing.Size(1329, 623);
            this.Load += new System.EventHandler(this.Frm_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ItemLookUpEditcCusCode)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ItemLookUpEditcCusName)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ItemLookUpEditcInvCode)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ItemLookUpEditcInvName)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ItemLookUpEditActionCode)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ItemLookUpEditAction)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.lookUpEditcCusName.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lookUpEditcCusCode.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dateEdit1.Properties.VistaTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dateEdit1.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtmStartImprot.Properties.VistaTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtmStartImprot.Properties)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private DevExpress.XtraGrid.GridControl gridControl1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.ToolStripMenuItem btnRefresh;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView1;
        private System.Windows.Forms.ToolStripMenuItem btnExport;
        private DevExpress.XtraGrid.Columns.GridColumn gridColActionCode;
        private System.Windows.Forms.ToolStripMenuItem btnEdit;
        private System.Windows.Forms.ToolStripMenuItem btnSave;
        private System.Windows.Forms.ToolStripMenuItem btnDelete;
        private DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit ItemLookUpEditActionCode;
        private DevExpress.XtraGrid.Columns.GridColumn gridColiID;
        private DevExpress.XtraGrid.Columns.GridColumn gridColsStatus;
        private System.Windows.Forms.ToolStripMenuItem btnAddRow;
        private DevExpress.XtraGrid.Columns.GridColumn gridColcInvCode;
        private DevExpress.XtraGrid.Columns.GridColumn gridColcInvName;
        private DevExpress.XtraGrid.Columns.GridColumn gridColLabour;
        private DevExpress.XtraGrid.Columns.GridColumn gridColProcess;
        private DevExpress.XtraGrid.Columns.GridColumn gridColPlatingCost;
        private DevExpress.XtraGrid.Columns.GridColumn gridColPart;
        private DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit ItemLookUpEditcInvCode;
        private DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit ItemLookUpEditcInvName;
        private DevExpress.XtraGrid.Columns.GridColumn gridColcCusCode;
        private DevExpress.XtraGrid.Columns.GridColumn gridColcCusName;
        private DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit ItemLookUpEditcCusCode;
        private DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit ItemLookUpEditcCusName;
        private DevExpress.XtraGrid.Columns.GridColumn gridColAction;
        private DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit ItemLookUpEditAction;
        private DevExpress.XtraGrid.Columns.GridColumn gridColdtmStart;
        private DevExpress.XtraGrid.Columns.GridColumn gridColdtmEnd;
        private DevExpress.XtraEditors.DateEdit dtmStartImprot;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.ToolStripMenuItem btnLoad;
        private DevExpress.XtraEditors.DateEdit dateEdit1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox groupBox1;
        private DevExpress.XtraEditors.LookUpEdit lookUpEditcCusName;
        private DevExpress.XtraEditors.LookUpEdit lookUpEditcCusCode;
        private System.Windows.Forms.Label label2;
        private DevExpress.XtraGrid.Columns.GridColumn gridColMANHOUR;
    }
}
