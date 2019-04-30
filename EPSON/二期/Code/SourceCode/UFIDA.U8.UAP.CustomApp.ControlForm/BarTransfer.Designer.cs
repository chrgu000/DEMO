namespace UFIDA.U8.UAP.CustomApp.ControlForm
{
    partial class BarTransfer
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
            this.btnScan = new System.Windows.Forms.ToolStripMenuItem();
            this.btnDelRow = new System.Windows.Forms.ToolStripMenuItem();
            this.btnSave = new System.Windows.Forms.ToolStripMenuItem();
            this.panel1 = new System.Windows.Forms.Panel();
            this.txtBarCode2 = new DevExpress.XtraEditors.TextEdit();
            this.label2 = new System.Windows.Forms.Label();
            this.labelErr = new System.Windows.Forms.Label();
            this.gridControl1 = new DevExpress.XtraGrid.GridControl();
            this.gridView1 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.gridColchoose = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColLotNO = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColcSOCode = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColSaleOrderRow = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColItemNO = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColDescription = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColcCusCode = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColOrderQTY = new DevExpress.XtraGrid.Columns.GridColumn();
            this.ItemTextEditn2 = new DevExpress.XtraEditors.Repository.RepositoryItemTextEdit();
            this.gridColLOTQTY = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColOtherQTY = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColsErr = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColProcess = new DevExpress.XtraGrid.Columns.GridColumn();
            this.ItemLookUpEditProcess = new DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit();
            this.gridColProcessNext = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColStatus = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColcSTCode = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColiSOsID = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColcBatch = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColScanTime = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColIQCStatus = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColOQCStatus = new DevExpress.XtraGrid.Columns.GridColumn();
            this.ItemLookUpEditPriceType = new DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit();
            this.txtBarCode = new DevExpress.XtraEditors.TextEdit();
            this.label1 = new System.Windows.Forms.Label();
            this.lookUpEditProcessNext = new DevExpress.XtraEditors.LookUpEdit();
            this.label13 = new System.Windows.Forms.Label();
            this.lookUpEditProcess = new DevExpress.XtraEditors.LookUpEdit();
            this.label12 = new System.Windows.Forms.Label();
            this.menuStrip1.SuspendLayout();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtBarCode2.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ItemTextEditn2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ItemLookUpEditProcess)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ItemLookUpEditPriceType)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtBarCode.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lookUpEditProcessNext.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lookUpEditProcess.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btnScan,
            this.btnDelRow,
            this.btnSave});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Padding = new System.Windows.Forms.Padding(9, 2, 0, 2);
            this.menuStrip1.Size = new System.Drawing.Size(1491, 26);
            this.menuStrip1.TabIndex = 172;
            this.menuStrip1.Text = "menuStrip";
            // 
            // btnScan
            // 
            this.btnScan.Name = "btnScan";
            this.btnScan.Size = new System.Drawing.Size(56, 22);
            this.btnScan.Text = "Scan";
            this.btnScan.Click += new System.EventHandler(this.btnScan_Click);
            // 
            // btnDelRow
            // 
            this.btnDelRow.Name = "btnDelRow";
            this.btnDelRow.Size = new System.Drawing.Size(110, 22);
            this.btnDelRow.Text = "Delete Row";
            this.btnDelRow.Click += new System.EventHandler(this.btnDelRow_Click);
            // 
            // btnSave
            // 
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(56, 22);
            this.btnSave.Text = "Save";
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // panel1
            // 
            this.panel1.AutoScroll = true;
            this.panel1.Controls.Add(this.txtBarCode2);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.labelErr);
            this.panel1.Controls.Add(this.gridControl1);
            this.panel1.Controls.Add(this.txtBarCode);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.lookUpEditProcessNext);
            this.panel1.Controls.Add(this.label13);
            this.panel1.Controls.Add(this.lookUpEditProcess);
            this.panel1.Controls.Add(this.label12);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 26);
            this.panel1.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1491, 562);
            this.panel1.TabIndex = 173;
            // 
            // txtBarCode2
            // 
            this.txtBarCode2.Enabled = false;
            this.txtBarCode2.Location = new System.Drawing.Point(612, 47);
            this.txtBarCode2.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtBarCode2.Name = "txtBarCode2";
            this.txtBarCode2.Size = new System.Drawing.Size(306, 28);
            this.txtBarCode2.TabIndex = 244;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(477, 50);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(134, 18);
            this.label2.TabIndex = 245;
            this.label2.Text = "Scanned Lot No";
            // 
            // labelErr
            // 
            this.labelErr.AutoSize = true;
            this.labelErr.Location = new System.Drawing.Point(948, 55);
            this.labelErr.Name = "labelErr";
            this.labelErr.Size = new System.Drawing.Size(35, 18);
            this.labelErr.TabIndex = 222;
            this.labelErr.Text = "Err";
            // 
            // gridControl1
            // 
            this.gridControl1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.gridControl1.EmbeddedNavigator.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.gridControl1.Location = new System.Drawing.Point(8, 78);
            this.gridControl1.LookAndFeel.SkinName = "Office 2010 Blue";
            this.gridControl1.MainView = this.gridView1;
            this.gridControl1.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.gridControl1.Name = "gridControl1";
            this.gridControl1.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.ItemLookUpEditPriceType,
            this.ItemLookUpEditProcess,
            this.ItemTextEditn2});
            this.gridControl1.Size = new System.Drawing.Size(1479, 478);
            this.gridControl1.TabIndex = 4;
            this.gridControl1.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView1});
            // 
            // gridView1
            // 
            this.gridView1.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.gridColchoose,
            this.gridColLotNO,
            this.gridColcSOCode,
            this.gridColSaleOrderRow,
            this.gridColItemNO,
            this.gridColDescription,
            this.gridColcCusCode,
            this.gridColOrderQTY,
            this.gridColLOTQTY,
            this.gridColOtherQTY,
            this.gridColsErr,
            this.gridColProcess,
            this.gridColProcessNext,
            this.gridColStatus,
            this.gridColcSTCode,
            this.gridColiSOsID,
            this.gridColcBatch,
            this.gridColScanTime,
            this.gridColIQCStatus,
            this.gridColOQCStatus});
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
            // gridColchoose
            // 
            this.gridColchoose.Caption = "Selected";
            this.gridColchoose.FieldName = "CHOOSE";
            this.gridColchoose.Name = "gridColchoose";
            this.gridColchoose.Visible = true;
            this.gridColchoose.VisibleIndex = 0;
            // 
            // gridColLotNO
            // 
            this.gridColLotNO.Caption = "Lot No";
            this.gridColLotNO.FieldName = "LotNO";
            this.gridColLotNO.Name = "gridColLotNO";
            this.gridColLotNO.OptionsColumn.AllowEdit = false;
            this.gridColLotNO.Summary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] {
            new DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Count)});
            this.gridColLotNO.Visible = true;
            this.gridColLotNO.VisibleIndex = 1;
            // 
            // gridColcSOCode
            // 
            this.gridColcSOCode.Caption = "Order No";
            this.gridColcSOCode.FieldName = "cSOCode";
            this.gridColcSOCode.Name = "gridColcSOCode";
            this.gridColcSOCode.OptionsColumn.AllowEdit = false;
            this.gridColcSOCode.Visible = true;
            this.gridColcSOCode.VisibleIndex = 4;
            this.gridColcSOCode.Width = 92;
            // 
            // gridColSaleOrderRow
            // 
            this.gridColSaleOrderRow.Caption = "SaleOrderRow";
            this.gridColSaleOrderRow.FieldName = "SaleOrderRow";
            this.gridColSaleOrderRow.Name = "gridColSaleOrderRow";
            this.gridColSaleOrderRow.OptionsColumn.AllowEdit = false;
            this.gridColSaleOrderRow.Width = 106;
            // 
            // gridColItemNO
            // 
            this.gridColItemNO.Caption = "Item No";
            this.gridColItemNO.FieldName = "ItemNO";
            this.gridColItemNO.Name = "gridColItemNO";
            this.gridColItemNO.OptionsColumn.AllowEdit = false;
            this.gridColItemNO.Visible = true;
            this.gridColItemNO.VisibleIndex = 2;
            // 
            // gridColDescription
            // 
            this.gridColDescription.Caption = "Item Desc";
            this.gridColDescription.FieldName = "Description";
            this.gridColDescription.Name = "gridColDescription";
            this.gridColDescription.OptionsColumn.AllowEdit = false;
            this.gridColDescription.Visible = true;
            this.gridColDescription.VisibleIndex = 3;
            this.gridColDescription.Width = 91;
            // 
            // gridColcCusCode
            // 
            this.gridColcCusCode.Caption = "Cust No";
            this.gridColcCusCode.FieldName = "cCusCode";
            this.gridColcCusCode.Name = "gridColcCusCode";
            this.gridColcCusCode.OptionsColumn.AllowEdit = false;
            this.gridColcCusCode.Visible = true;
            this.gridColcCusCode.VisibleIndex = 8;
            // 
            // gridColOrderQTY
            // 
            this.gridColOrderQTY.Caption = "Order Qty";
            this.gridColOrderQTY.ColumnEdit = this.ItemTextEditn2;
            this.gridColOrderQTY.FieldName = "OrderQTY";
            this.gridColOrderQTY.Name = "gridColOrderQTY";
            this.gridColOrderQTY.OptionsColumn.AllowEdit = false;
            this.gridColOrderQTY.Summary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] {
            new DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum)});
            this.gridColOrderQTY.Visible = true;
            this.gridColOrderQTY.VisibleIndex = 5;
            this.gridColOrderQTY.Width = 94;
            // 
            // ItemTextEditn2
            // 
            this.ItemTextEditn2.AutoHeight = false;
            this.ItemTextEditn2.DisplayFormat.FormatString = "n2";
            this.ItemTextEditn2.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.ItemTextEditn2.EditFormat.FormatString = "n2";
            this.ItemTextEditn2.EditFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.ItemTextEditn2.Mask.EditMask = "n2";
            this.ItemTextEditn2.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Numeric;
            this.ItemTextEditn2.Name = "ItemTextEditn2";
            // 
            // gridColLOTQTY
            // 
            this.gridColLOTQTY.AppearanceHeader.ForeColor = System.Drawing.Color.Blue;
            this.gridColLOTQTY.AppearanceHeader.Options.UseForeColor = true;
            this.gridColLOTQTY.Caption = "Lot Qty";
            this.gridColLOTQTY.ColumnEdit = this.ItemTextEditn2;
            this.gridColLOTQTY.FieldName = "LOTQTY";
            this.gridColLOTQTY.Name = "gridColLOTQTY";
            this.gridColLOTQTY.OptionsColumn.AllowEdit = false;
            this.gridColLOTQTY.Summary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] {
            new DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum)});
            this.gridColLOTQTY.Visible = true;
            this.gridColLOTQTY.VisibleIndex = 6;
            // 
            // gridColOtherQTY
            // 
            this.gridColOtherQTY.Caption = "Lot Qty 2";
            this.gridColOtherQTY.ColumnEdit = this.ItemTextEditn2;
            this.gridColOtherQTY.FieldName = "OtherQTY";
            this.gridColOtherQTY.Name = "gridColOtherQTY";
            this.gridColOtherQTY.OptionsColumn.AllowEdit = false;
            this.gridColOtherQTY.Summary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] {
            new DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum)});
            this.gridColOtherQTY.Visible = true;
            this.gridColOtherQTY.VisibleIndex = 7;
            this.gridColOtherQTY.Width = 98;
            // 
            // gridColsErr
            // 
            this.gridColsErr.Caption = "sErr";
            this.gridColsErr.FieldName = "sErr";
            this.gridColsErr.Name = "gridColsErr";
            this.gridColsErr.OptionsColumn.AllowEdit = false;
            this.gridColsErr.Width = 76;
            // 
            // gridColProcess
            // 
            this.gridColProcess.Caption = "From Warehouse";
            this.gridColProcess.ColumnEdit = this.ItemLookUpEditProcess;
            this.gridColProcess.FieldName = "Process";
            this.gridColProcess.Name = "gridColProcess";
            this.gridColProcess.OptionsColumn.AllowEdit = false;
            this.gridColProcess.Visible = true;
            this.gridColProcess.VisibleIndex = 9;
            this.gridColProcess.Width = 143;
            // 
            // ItemLookUpEditProcess
            // 
            this.ItemLookUpEditProcess.AutoHeight = false;
            this.ItemLookUpEditProcess.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.ItemLookUpEditProcess.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("cWhCode", "Process"),
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("cWhName", "Description")});
            this.ItemLookUpEditProcess.DisplayMember = "cWhCode";
            this.ItemLookUpEditProcess.Name = "ItemLookUpEditProcess";
            this.ItemLookUpEditProcess.NullText = "";
            this.ItemLookUpEditProcess.ValueMember = "cWhCode";
            // 
            // gridColProcessNext
            // 
            this.gridColProcessNext.Caption = "Next Warehouse";
            this.gridColProcessNext.ColumnEdit = this.ItemLookUpEditProcess;
            this.gridColProcessNext.FieldName = "ProcessNext";
            this.gridColProcessNext.Name = "gridColProcessNext";
            this.gridColProcessNext.OptionsColumn.AllowEdit = false;
            this.gridColProcessNext.Visible = true;
            this.gridColProcessNext.VisibleIndex = 10;
            this.gridColProcessNext.Width = 145;
            // 
            // gridColStatus
            // 
            this.gridColStatus.Caption = "Status";
            this.gridColStatus.FieldName = "Status";
            this.gridColStatus.Name = "gridColStatus";
            this.gridColStatus.OptionsColumn.AllowEdit = false;
            // 
            // gridColcSTCode
            // 
            this.gridColcSTCode.Caption = "cSTCode";
            this.gridColcSTCode.FieldName = "cSTCode";
            this.gridColcSTCode.Name = "gridColcSTCode";
            this.gridColcSTCode.OptionsColumn.AllowEdit = false;
            // 
            // gridColiSOsID
            // 
            this.gridColiSOsID.Caption = "iSOsID";
            this.gridColiSOsID.FieldName = "iSOsID";
            this.gridColiSOsID.Name = "gridColiSOsID";
            this.gridColiSOsID.OptionsColumn.AllowEdit = false;
            // 
            // gridColcBatch
            // 
            this.gridColcBatch.Caption = "cBatch";
            this.gridColcBatch.FieldName = "cBatch";
            this.gridColcBatch.Name = "gridColcBatch";
            this.gridColcBatch.OptionsColumn.AllowEdit = false;
            this.gridColcBatch.Visible = true;
            this.gridColcBatch.VisibleIndex = 11;
            // 
            // gridColScanTime
            // 
            this.gridColScanTime.Caption = "ScanTime";
            this.gridColScanTime.FieldName = "ScanTime";
            this.gridColScanTime.Name = "gridColScanTime";
            this.gridColScanTime.OptionsColumn.AllowEdit = false;
            this.gridColScanTime.Summary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] {
            new DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Count)});
            // 
            // gridColIQCStatus
            // 
            this.gridColIQCStatus.Caption = "IQC Status";
            this.gridColIQCStatus.FieldName = "IQCStatus";
            this.gridColIQCStatus.Name = "gridColIQCStatus";
            this.gridColIQCStatus.OptionsColumn.AllowEdit = false;
            this.gridColIQCStatus.Visible = true;
            this.gridColIQCStatus.VisibleIndex = 12;
            this.gridColIQCStatus.Width = 103;
            // 
            // gridColOQCStatus
            // 
            this.gridColOQCStatus.Caption = "OQC Status";
            this.gridColOQCStatus.FieldName = "OQCStatus";
            this.gridColOQCStatus.Name = "gridColOQCStatus";
            this.gridColOQCStatus.OptionsColumn.AllowEdit = false;
            this.gridColOQCStatus.Visible = true;
            this.gridColOQCStatus.VisibleIndex = 13;
            this.gridColOQCStatus.Width = 111;
            // 
            // ItemLookUpEditPriceType
            // 
            this.ItemLookUpEditPriceType.AutoHeight = false;
            this.ItemLookUpEditPriceType.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.ItemLookUpEditPriceType.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("PriceType", "PriceType")});
            this.ItemLookUpEditPriceType.DisplayMember = "PriceType";
            this.ItemLookUpEditPriceType.Name = "ItemLookUpEditPriceType";
            this.ItemLookUpEditPriceType.NullText = "";
            this.ItemLookUpEditPriceType.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.Standard;
            this.ItemLookUpEditPriceType.ValueMember = "PriceType";
            // 
            // txtBarCode
            // 
            this.txtBarCode.Location = new System.Drawing.Point(148, 47);
            this.txtBarCode.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtBarCode.Name = "txtBarCode";
            this.txtBarCode.Size = new System.Drawing.Size(306, 28);
            this.txtBarCode.TabIndex = 3;
            this.txtBarCode.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtBarCode_KeyDown);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(14, 50);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(62, 18);
            this.label1.TabIndex = 192;
            this.label1.Text = "Lot No";
            // 
            // lookUpEditProcessNext
            // 
            this.lookUpEditProcessNext.Location = new System.Drawing.Point(612, 6);
            this.lookUpEditProcessNext.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.lookUpEditProcessNext.Name = "lookUpEditProcessNext";
            this.lookUpEditProcessNext.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.lookUpEditProcessNext.Properties.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("cWhCode", 40, "Process"),
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("cWhName", 60, "Description")});
            this.lookUpEditProcessNext.Properties.DisplayMember = "cWhCode";
            this.lookUpEditProcessNext.Properties.NullText = "";
            this.lookUpEditProcessNext.Properties.PopupWidth = 500;
            this.lookUpEditProcessNext.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.Standard;
            this.lookUpEditProcessNext.Properties.ValueMember = "cWhCode";
            this.lookUpEditProcessNext.Size = new System.Drawing.Size(306, 28);
            this.lookUpEditProcessNext.TabIndex = 2;
            this.lookUpEditProcessNext.Leave += new System.EventHandler(this.lookUpEditProcessNext_Leave);
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(471, 12);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(134, 18);
            this.label13.TabIndex = 243;
            this.label13.Text = "Next Warehouse";
            // 
            // lookUpEditProcess
            // 
            this.lookUpEditProcess.Location = new System.Drawing.Point(148, 6);
            this.lookUpEditProcess.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.lookUpEditProcess.Name = "lookUpEditProcess";
            this.lookUpEditProcess.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.lookUpEditProcess.Properties.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("cWhCode", 40, "Process"),
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("cWhName", 60, "Description")});
            this.lookUpEditProcess.Properties.DisplayMember = "cWhCode";
            this.lookUpEditProcess.Properties.NullText = "";
            this.lookUpEditProcess.Properties.PopupWidth = 500;
            this.lookUpEditProcess.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.Standard;
            this.lookUpEditProcess.Properties.ValueMember = "cWhCode";
            this.lookUpEditProcess.Size = new System.Drawing.Size(306, 28);
            this.lookUpEditProcess.TabIndex = 1;
            this.lookUpEditProcess.Validated += new System.EventHandler(this.lookUpEditProcess_Validated);
            this.lookUpEditProcess.KeyUp += new System.Windows.Forms.KeyEventHandler(this.lookUpEditProcess_KeyUp);
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(15, 13);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(134, 18);
            this.label12.TabIndex = 241;
            this.label12.Text = "From Warehouse";
            // 
            // BarTransfer
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 18F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.menuStrip1);
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "BarTransfer";
            this.Size = new System.Drawing.Size(1491, 588);
            this.Load += new System.EventHandler(this.Frm_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtBarCode2.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ItemTextEditn2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ItemLookUpEditProcess)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ItemLookUpEditPriceType)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtBarCode.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lookUpEditProcessNext.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lookUpEditProcess.Properties)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.ToolStripMenuItem btnScan;
        private System.Windows.Forms.Label label1;
        private DevExpress.XtraEditors.TextEdit txtBarCode;
        private System.Windows.Forms.ToolStripMenuItem btnSave;
        private DevExpress.XtraGrid.GridControl gridControl1;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView1;
        private DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit ItemLookUpEditPriceType;
        private DevExpress.XtraGrid.Columns.GridColumn gridColchoose;
        private DevExpress.XtraGrid.Columns.GridColumn gridColLotNO;
        private DevExpress.XtraGrid.Columns.GridColumn gridColcSOCode;
        private DevExpress.XtraGrid.Columns.GridColumn gridColSaleOrderRow;
        private DevExpress.XtraGrid.Columns.GridColumn gridColiSOsID;
        private DevExpress.XtraGrid.Columns.GridColumn gridColItemNO;
        private DevExpress.XtraGrid.Columns.GridColumn gridColDescription;
        private DevExpress.XtraGrid.Columns.GridColumn gridColcCusCode;
        private DevExpress.XtraGrid.Columns.GridColumn gridColOrderQTY;
        private DevExpress.XtraGrid.Columns.GridColumn gridColLOTQTY;
        private DevExpress.XtraGrid.Columns.GridColumn gridColsErr;
        private System.Windows.Forms.Label labelErr;
        private DevExpress.XtraGrid.Columns.GridColumn gridColProcess;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label13;
        private DevExpress.XtraEditors.LookUpEdit lookUpEditProcess;
        private DevExpress.XtraEditors.LookUpEdit lookUpEditProcessNext;
        private DevExpress.XtraGrid.Columns.GridColumn gridColProcessNext;
        private DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit ItemLookUpEditProcess;
        private DevExpress.XtraEditors.TextEdit txtBarCode2;
        private System.Windows.Forms.Label label2;
        private DevExpress.XtraGrid.Columns.GridColumn gridColOtherQTY;
        private DevExpress.XtraGrid.Columns.GridColumn gridColStatus;
        private DevExpress.XtraGrid.Columns.GridColumn gridColcSTCode;
        private DevExpress.XtraGrid.Columns.GridColumn gridColcBatch;
        private System.Windows.Forms.ToolStripMenuItem btnDelRow;
        private DevExpress.XtraGrid.Columns.GridColumn gridColScanTime;
        private DevExpress.XtraGrid.Columns.GridColumn gridColIQCStatus;
        private DevExpress.XtraGrid.Columns.GridColumn gridColOQCStatus;
        private DevExpress.XtraEditors.Repository.RepositoryItemTextEdit ItemTextEditn2;
    }
}
