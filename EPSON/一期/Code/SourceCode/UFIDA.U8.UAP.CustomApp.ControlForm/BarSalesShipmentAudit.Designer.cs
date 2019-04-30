namespace UFIDA.U8.UAP.CustomApp.ControlForm
{
    partial class BarSalesShipmentAudit
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
            this.btnQuery = new System.Windows.Forms.ToolStripMenuItem();
            this.btnDelRow = new System.Windows.Forms.ToolStripMenuItem();
            this.btnSave = new System.Windows.Forms.ToolStripMenuItem();
            this.panel1 = new System.Windows.Forms.Panel();
            this.chkAll = new System.Windows.Forms.CheckBox();
            this.lookUpEditcCusName = new DevExpress.XtraEditors.LookUpEdit();
            this.lookUpEditcCusCode = new DevExpress.XtraEditors.LookUpEdit();
            this.label1 = new System.Windows.Forms.Label();
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
            this.gridColLOTQTY = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColOtherQTY = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColsErr = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColProcess = new DevExpress.XtraGrid.Columns.GridColumn();
            this.ItemLookUpEditProcess = new DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit();
            this.gridColStatus = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColcSTCode = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColiSOsID = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColCurrQTY = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColCartonNo = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColiID = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColCreateUid = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColCreateDate = new DevExpress.XtraGrid.Columns.GridColumn();
            this.ItemLookUpEditPriceType = new DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit();
            this.lookUpEditProcess = new DevExpress.XtraEditors.LookUpEdit();
            this.label12 = new System.Windows.Forms.Label();
            this.gridColcustlot = new DevExpress.XtraGrid.Columns.GridColumn();
            this.menuStrip1.SuspendLayout();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.lookUpEditcCusName.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lookUpEditcCusCode.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ItemLookUpEditProcess)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ItemLookUpEditPriceType)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lookUpEditProcess.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btnQuery,
            this.btnDelRow,
            this.btnSave});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Padding = new System.Windows.Forms.Padding(8, 2, 0, 2);
            this.menuStrip1.Size = new System.Drawing.Size(1325, 28);
            this.menuStrip1.TabIndex = 172;
            this.menuStrip1.Text = "menuStrip";
            // 
            // btnQuery
            // 
            this.btnQuery.Name = "btnQuery";
            this.btnQuery.Size = new System.Drawing.Size(65, 24);
            this.btnQuery.Text = "Query";
            this.btnQuery.Click += new System.EventHandler(this.btnQuery_Click);
            // 
            // btnDelRow
            // 
            this.btnDelRow.Name = "btnDelRow";
            this.btnDelRow.Size = new System.Drawing.Size(105, 24);
            this.btnDelRow.Text = "Delete Row";
            this.btnDelRow.Click += new System.EventHandler(this.btnDelRow_Click);
            // 
            // btnSave
            // 
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(55, 24);
            this.btnSave.Text = "Save";
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // panel1
            // 
            this.panel1.AutoScroll = true;
            this.panel1.Controls.Add(this.chkAll);
            this.panel1.Controls.Add(this.lookUpEditcCusName);
            this.panel1.Controls.Add(this.lookUpEditcCusCode);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.gridControl1);
            this.panel1.Controls.Add(this.lookUpEditProcess);
            this.panel1.Controls.Add(this.label12);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 28);
            this.panel1.Margin = new System.Windows.Forms.Padding(4);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1325, 462);
            this.panel1.TabIndex = 173;
            // 
            // chkAll
            // 
            this.chkAll.AutoSize = true;
            this.chkAll.Location = new System.Drawing.Point(17, 48);
            this.chkAll.Margin = new System.Windows.Forms.Padding(4);
            this.chkAll.Name = "chkAll";
            this.chkAll.Size = new System.Drawing.Size(109, 19);
            this.chkAll.TabIndex = 245;
            this.chkAll.Text = "Select All";
            this.chkAll.UseVisualStyleBackColor = true;
            this.chkAll.CheckedChanged += new System.EventHandler(this.chkAll_CheckedChanged);
            // 
            // lookUpEditcCusName
            // 
            this.lookUpEditcCusName.Location = new System.Drawing.Point(737, 6);
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
            this.lookUpEditcCusName.Properties.ValueMember = "cCusCode";
            this.lookUpEditcCusName.Size = new System.Drawing.Size(417, 24);
            this.lookUpEditcCusName.TabIndex = 244;
            this.lookUpEditcCusName.EditValueChanged += new System.EventHandler(this.lookUpEditcCusName_EditValueChanged);
            // 
            // lookUpEditcCusCode
            // 
            this.lookUpEditcCusCode.Location = new System.Drawing.Point(508, 6);
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
            this.lookUpEditcCusCode.Properties.ValueMember = "cCusCode";
            this.lookUpEditcCusCode.Size = new System.Drawing.Size(221, 24);
            this.lookUpEditcCusCode.TabIndex = 243;
            this.lookUpEditcCusCode.EditValueChanged += new System.EventHandler(this.lookUpEditcCusCode_EditValueChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(431, 10);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(71, 15);
            this.label1.TabIndex = 242;
            this.label1.Text = "Customer";
            // 
            // gridControl1
            // 
            this.gridControl1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.gridControl1.EmbeddedNavigator.Margin = new System.Windows.Forms.Padding(4);
            this.gridControl1.Location = new System.Drawing.Point(7, 79);
            this.gridControl1.LookAndFeel.SkinName = "Office 2010 Blue";
            this.gridControl1.MainView = this.gridView1;
            this.gridControl1.Margin = new System.Windows.Forms.Padding(4);
            this.gridControl1.Name = "gridControl1";
            this.gridControl1.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.ItemLookUpEditPriceType,
            this.ItemLookUpEditProcess});
            this.gridControl1.Size = new System.Drawing.Size(1315, 375);
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
            this.gridColStatus,
            this.gridColcSTCode,
            this.gridColiSOsID,
            this.gridColCurrQTY,
            this.gridColCartonNo,
            this.gridColiID,
            this.gridColCreateUid,
            this.gridColCreateDate,
            this.gridColcustlot});
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
            this.gridColcSOCode.VisibleIndex = 2;
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
            this.gridColItemNO.VisibleIndex = 3;
            // 
            // gridColDescription
            // 
            this.gridColDescription.Caption = "Item Desc";
            this.gridColDescription.FieldName = "Description";
            this.gridColDescription.Name = "gridColDescription";
            this.gridColDescription.OptionsColumn.AllowEdit = false;
            this.gridColDescription.Visible = true;
            this.gridColDescription.VisibleIndex = 4;
            // 
            // gridColcCusCode
            // 
            this.gridColcCusCode.Caption = "Customer";
            this.gridColcCusCode.FieldName = "cCusCode";
            this.gridColcCusCode.Name = "gridColcCusCode";
            this.gridColcCusCode.OptionsColumn.AllowEdit = false;
            this.gridColcCusCode.Visible = true;
            this.gridColcCusCode.VisibleIndex = 5;
            // 
            // gridColOrderQTY
            // 
            this.gridColOrderQTY.Caption = "Order Qty";
            this.gridColOrderQTY.FieldName = "OrderQTY";
            this.gridColOrderQTY.Name = "gridColOrderQTY";
            this.gridColOrderQTY.OptionsColumn.AllowEdit = false;
            this.gridColOrderQTY.Summary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] {
            new DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum)});
            this.gridColOrderQTY.Visible = true;
            this.gridColOrderQTY.VisibleIndex = 6;
            // 
            // gridColLOTQTY
            // 
            this.gridColLOTQTY.AppearanceHeader.ForeColor = System.Drawing.Color.Blue;
            this.gridColLOTQTY.AppearanceHeader.Options.UseForeColor = true;
            this.gridColLOTQTY.Caption = "Lot Qty";
            this.gridColLOTQTY.FieldName = "LOTQTY";
            this.gridColLOTQTY.Name = "gridColLOTQTY";
            this.gridColLOTQTY.OptionsColumn.AllowEdit = false;
            this.gridColLOTQTY.Summary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] {
            new DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum)});
            this.gridColLOTQTY.Visible = true;
            this.gridColLOTQTY.VisibleIndex = 7;
            // 
            // gridColOtherQTY
            // 
            this.gridColOtherQTY.Caption = "LotQTY2";
            this.gridColOtherQTY.FieldName = "OtherQTY";
            this.gridColOtherQTY.Name = "gridColOtherQTY";
            this.gridColOtherQTY.OptionsColumn.AllowEdit = false;
            this.gridColOtherQTY.Summary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] {
            new DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum)});
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
            this.gridColProcess.Caption = "Warehouse";
            this.gridColProcess.ColumnEdit = this.ItemLookUpEditProcess;
            this.gridColProcess.FieldName = "Process";
            this.gridColProcess.Name = "gridColProcess";
            this.gridColProcess.OptionsColumn.AllowEdit = false;
            this.gridColProcess.Visible = true;
            this.gridColProcess.VisibleIndex = 8;
            this.gridColProcess.Width = 126;
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
            // gridColCurrQTY
            // 
            this.gridColCurrQTY.Caption = "Current Qty";
            this.gridColCurrQTY.FieldName = "CurrQTY";
            this.gridColCurrQTY.Name = "gridColCurrQTY";
            this.gridColCurrQTY.OptionsColumn.AllowEdit = false;
            // 
            // gridColCartonNo
            // 
            this.gridColCartonNo.Caption = "CartonNo";
            this.gridColCartonNo.FieldName = "CartonNo";
            this.gridColCartonNo.Name = "gridColCartonNo";
            this.gridColCartonNo.OptionsColumn.AllowEdit = false;
            this.gridColCartonNo.Visible = true;
            this.gridColCartonNo.VisibleIndex = 9;
            // 
            // gridColiID
            // 
            this.gridColiID.Caption = "iID";
            this.gridColiID.FieldName = "iID";
            this.gridColiID.Name = "gridColiID";
            this.gridColiID.OptionsColumn.AllowEdit = false;
            // 
            // gridColCreateUid
            // 
            this.gridColCreateUid.Caption = "CreateUid";
            this.gridColCreateUid.FieldName = "CreateUid";
            this.gridColCreateUid.Name = "gridColCreateUid";
            this.gridColCreateUid.OptionsColumn.AllowEdit = false;
            this.gridColCreateUid.Visible = true;
            this.gridColCreateUid.VisibleIndex = 11;
            // 
            // gridColCreateDate
            // 
            this.gridColCreateDate.Caption = "CreateDate";
            this.gridColCreateDate.FieldName = "CreateDate";
            this.gridColCreateDate.Name = "gridColCreateDate";
            this.gridColCreateDate.OptionsColumn.AllowEdit = false;
            this.gridColCreateDate.Visible = true;
            this.gridColCreateDate.VisibleIndex = 12;
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
            // lookUpEditProcess
            // 
            this.lookUpEditProcess.Location = new System.Drawing.Point(132, 4);
            this.lookUpEditProcess.Margin = new System.Windows.Forms.Padding(4);
            this.lookUpEditProcess.Name = "lookUpEditProcess";
            this.lookUpEditProcess.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.lookUpEditProcess.Properties.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("cWhCode", 40, "Warehouse No"),
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("cWhName", 60, "Description")});
            this.lookUpEditProcess.Properties.DisplayMember = "cWhCode";
            this.lookUpEditProcess.Properties.NullText = "";
            this.lookUpEditProcess.Properties.PopupWidth = 500;
            this.lookUpEditProcess.Properties.ValueMember = "cWhCode";
            this.lookUpEditProcess.Size = new System.Drawing.Size(272, 24);
            this.lookUpEditProcess.TabIndex = 1;
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(13, 10);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(79, 15);
            this.label12.TabIndex = 241;
            this.label12.Text = "WareHouse";
            // 
            // gridColcustlot
            // 
            this.gridColcustlot.Caption = "Customer Lot";
            this.gridColcustlot.FieldName = "custlot";
            this.gridColcustlot.Name = "gridColcustlot";
            this.gridColcustlot.OptionsColumn.AllowEdit = false;
            this.gridColcustlot.Visible = true;
            this.gridColcustlot.VisibleIndex = 10;
            this.gridColcustlot.Width = 90;
            // 
            // BarSalesShipmentAudit
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.menuStrip1);
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "BarSalesShipmentAudit";
            this.Size = new System.Drawing.Size(1325, 490);
            this.Load += new System.EventHandler(this.Frm_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.lookUpEditcCusName.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lookUpEditcCusCode.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ItemLookUpEditProcess)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ItemLookUpEditPriceType)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lookUpEditProcess.Properties)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.ToolStripMenuItem btnQuery;
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
        private DevExpress.XtraGrid.Columns.GridColumn gridColProcess;
        private System.Windows.Forms.Label label12;
        private DevExpress.XtraEditors.LookUpEdit lookUpEditProcess;
        private DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit ItemLookUpEditProcess;
        private DevExpress.XtraGrid.Columns.GridColumn gridColOtherQTY;
        private DevExpress.XtraGrid.Columns.GridColumn gridColStatus;
        private DevExpress.XtraGrid.Columns.GridColumn gridColcSTCode;
        private System.Windows.Forms.ToolStripMenuItem btnDelRow;
        private DevExpress.XtraGrid.Columns.GridColumn gridColCurrQTY;
        private DevExpress.XtraEditors.LookUpEdit lookUpEditcCusName;
        private DevExpress.XtraEditors.LookUpEdit lookUpEditcCusCode;
        private System.Windows.Forms.Label label1;
        private DevExpress.XtraGrid.Columns.GridColumn gridColiID;
        private DevExpress.XtraGrid.Columns.GridColumn gridColCreateUid;
        private DevExpress.XtraGrid.Columns.GridColumn gridColCreateDate;
        private DevExpress.XtraGrid.Columns.GridColumn gridColCartonNo;
        private System.Windows.Forms.CheckBox chkAll;
        private DevExpress.XtraGrid.Columns.GridColumn gridColcustlot;
    }
}
