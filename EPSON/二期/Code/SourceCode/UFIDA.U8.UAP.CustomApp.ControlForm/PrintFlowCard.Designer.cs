namespace UFIDA.U8.UAP.CustomApp.ControlForm
{
    partial class PrintFlowCard
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
            this.btnPrint = new System.Windows.Forms.ToolStripMenuItem();
            this.btnExport = new System.Windows.Forms.ToolStripMenuItem();
            this.btnPrintSet = new System.Windows.Forms.ToolStripMenuItem();
            this.gridControl1 = new DevExpress.XtraGrid.GridControl();
            this.gridView1 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.gridColchoose = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColcSTCode = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColdDate = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColcSOCode = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColiSOsID = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColiRowNo = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColcDepCode = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColcCusCode = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColvend = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColItemNO = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColItemDESC = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColCustLOT = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColCustDO = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColORDQTY = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColLOTQTY = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColPrintQTY = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColRECDTE = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColDUEDTE = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColLOTNO = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColcreater = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColcreatedate = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColcUnitID = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColPrintCount = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColPrintTime = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColBarCode = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColiID = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColRACK = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColMC = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColPOT = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColPRODLINE = new DevExpress.XtraGrid.Columns.GridColumn();
            this.ItemLookUpEditRACK = new DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label3 = new System.Windows.Forms.Label();
            this.lookUpEditSOCode = new DevExpress.XtraEditors.LookUpEdit();
            this.btnTxtSize = new DevExpress.XtraEditors.ButtonEdit();
            this.label2 = new System.Windows.Forms.Label();
            this.radioPreview = new System.Windows.Forms.RadioButton();
            this.radioPrint = new System.Windows.Forms.RadioButton();
            this.label1 = new System.Windows.Forms.Label();
            this.lookUpEditPrinter = new DevExpress.XtraEditors.LookUpEdit();
            this.label5 = new System.Windows.Forms.Label();
            this.btnTxtBarCode = new DevExpress.XtraEditors.ButtonEdit();
            this.label4 = new System.Windows.Forms.Label();
            this.lookUpEditFlowType = new DevExpress.XtraEditors.LookUpEdit();
            this.chkAll = new System.Windows.Forms.CheckBox();
            this.gridColColor = new DevExpress.XtraGrid.Columns.GridColumn();
            this.menuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ItemLookUpEditRACK)).BeginInit();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.lookUpEditSOCode.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnTxtSize.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lookUpEditPrinter.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnTxtBarCode.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lookUpEditFlowType.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btnQuery,
            this.btnPrint,
            this.btnExport,
            this.btnPrintSet});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Padding = new System.Windows.Forms.Padding(8, 2, 0, 2);
            this.menuStrip1.Size = new System.Drawing.Size(1441, 28);
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
            // btnPrint
            // 
            this.btnPrint.Name = "btnPrint";
            this.btnPrint.Size = new System.Drawing.Size(55, 24);
            this.btnPrint.Text = "Print";
            this.btnPrint.Click += new System.EventHandler(this.btnPrint_Click);
            // 
            // btnExport
            // 
            this.btnExport.Name = "btnExport";
            this.btnExport.Size = new System.Drawing.Size(69, 24);
            this.btnExport.Text = "Export";
            this.btnExport.Click += new System.EventHandler(this.btnExcel_Click);
            // 
            // btnPrintSet
            // 
            this.btnPrintSet.Name = "btnPrintSet";
            this.btnPrintSet.Size = new System.Drawing.Size(83, 24);
            this.btnPrintSet.Text = "Print Set";
            this.btnPrintSet.Click += new System.EventHandler(this.btnPrintSet_Click);
            // 
            // gridControl1
            // 
            this.gridControl1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.gridControl1.EmbeddedNavigator.Margin = new System.Windows.Forms.Padding(4);
            this.gridControl1.Location = new System.Drawing.Point(4, 114);
            this.gridControl1.LookAndFeel.SkinName = "Office 2010 Blue";
            this.gridControl1.MainView = this.gridView1;
            this.gridControl1.Margin = new System.Windows.Forms.Padding(4);
            this.gridControl1.Name = "gridControl1";
            this.gridControl1.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.ItemLookUpEditRACK});
            this.gridControl1.Size = new System.Drawing.Size(1433, 422);
            this.gridControl1.TabIndex = 191;
            this.gridControl1.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView1});
            // 
            // gridView1
            // 
            this.gridView1.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.gridColchoose,
            this.gridColcSTCode,
            this.gridColdDate,
            this.gridColcSOCode,
            this.gridColiSOsID,
            this.gridColiRowNo,
            this.gridColcDepCode,
            this.gridColcCusCode,
            this.gridColvend,
            this.gridColItemNO,
            this.gridColItemDESC,
            this.gridColCustLOT,
            this.gridColCustDO,
            this.gridColORDQTY,
            this.gridColLOTQTY,
            this.gridColPrintQTY,
            this.gridColRECDTE,
            this.gridColDUEDTE,
            this.gridColLOTNO,
            this.gridColcreater,
            this.gridColcreatedate,
            this.gridColcUnitID,
            this.gridColPrintCount,
            this.gridColPrintTime,
            this.gridColBarCode,
            this.gridColiID,
            this.gridColRACK,
            this.gridColMC,
            this.gridColPOT,
            this.gridColPRODLINE,
            this.gridColColor});
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
            // 
            // gridColchoose
            // 
            this.gridColchoose.Caption = "Selected";
            this.gridColchoose.FieldName = "choose";
            this.gridColchoose.Name = "gridColchoose";
            this.gridColchoose.Visible = true;
            this.gridColchoose.VisibleIndex = 0;
            // 
            // gridColcSTCode
            // 
            this.gridColcSTCode.Caption = "STCode";
            this.gridColcSTCode.FieldName = "cSTCode";
            this.gridColcSTCode.Name = "gridColcSTCode";
            this.gridColcSTCode.OptionsColumn.AllowEdit = false;
            // 
            // gridColdDate
            // 
            this.gridColdDate.Caption = "Date";
            this.gridColdDate.FieldName = "dDate";
            this.gridColdDate.Name = "gridColdDate";
            this.gridColdDate.OptionsColumn.AllowEdit = false;
            this.gridColdDate.Visible = true;
            this.gridColdDate.VisibleIndex = 16;
            // 
            // gridColcSOCode
            // 
            this.gridColcSOCode.Caption = "Order No";
            this.gridColcSOCode.FieldName = "ORDNO";
            this.gridColcSOCode.Name = "gridColcSOCode";
            this.gridColcSOCode.OptionsColumn.AllowEdit = false;
            this.gridColcSOCode.Visible = true;
            this.gridColcSOCode.VisibleIndex = 4;
            // 
            // gridColiSOsID
            // 
            this.gridColiSOsID.Caption = "iSOsID";
            this.gridColiSOsID.FieldName = "iSOsID";
            this.gridColiSOsID.Name = "gridColiSOsID";
            this.gridColiSOsID.OptionsColumn.AllowEdit = false;
            // 
            // gridColiRowNo
            // 
            this.gridColiRowNo.Caption = "iRowNo";
            this.gridColiRowNo.FieldName = "iRowNo";
            this.gridColiRowNo.Name = "gridColiRowNo";
            this.gridColiRowNo.OptionsColumn.AllowEdit = false;
            // 
            // gridColcDepCode
            // 
            this.gridColcDepCode.Caption = "Dept";
            this.gridColcDepCode.FieldName = "DEPT";
            this.gridColcDepCode.Name = "gridColcDepCode";
            this.gridColcDepCode.OptionsColumn.AllowEdit = false;
            this.gridColcDepCode.Visible = true;
            this.gridColcDepCode.VisibleIndex = 15;
            // 
            // gridColcCusCode
            // 
            this.gridColcCusCode.Caption = "Cust No";
            this.gridColcCusCode.FieldName = "CUST";
            this.gridColcCusCode.Name = "gridColcCusCode";
            this.gridColcCusCode.OptionsColumn.AllowEdit = false;
            this.gridColcCusCode.Visible = true;
            this.gridColcCusCode.VisibleIndex = 8;
            // 
            // gridColvend
            // 
            this.gridColvend.Caption = "Vend";
            this.gridColvend.FieldName = "vend";
            this.gridColvend.Name = "gridColvend";
            this.gridColvend.OptionsColumn.AllowEdit = false;
            this.gridColvend.Width = 56;
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
            // gridColItemDESC
            // 
            this.gridColItemDESC.Caption = "Item Desc";
            this.gridColItemDESC.FieldName = "ItemDESC";
            this.gridColItemDESC.Name = "gridColItemDESC";
            this.gridColItemDESC.OptionsColumn.AllowEdit = false;
            this.gridColItemDESC.Visible = true;
            this.gridColItemDESC.VisibleIndex = 3;
            // 
            // gridColCustLOT
            // 
            this.gridColCustLOT.Caption = "Cust Lot";
            this.gridColCustLOT.FieldName = "CustLOT";
            this.gridColCustLOT.Name = "gridColCustLOT";
            this.gridColCustLOT.OptionsColumn.AllowEdit = false;
            this.gridColCustLOT.Visible = true;
            this.gridColCustLOT.VisibleIndex = 13;
            // 
            // gridColCustDO
            // 
            this.gridColCustDO.Caption = "Cust DO";
            this.gridColCustDO.FieldName = "CustDO";
            this.gridColCustDO.Name = "gridColCustDO";
            this.gridColCustDO.OptionsColumn.AllowEdit = false;
            this.gridColCustDO.Visible = true;
            this.gridColCustDO.VisibleIndex = 14;
            // 
            // gridColORDQTY
            // 
            this.gridColORDQTY.Caption = "Order Qty";
            this.gridColORDQTY.FieldName = "ORDQTY";
            this.gridColORDQTY.Name = "gridColORDQTY";
            this.gridColORDQTY.OptionsColumn.AllowEdit = false;
            this.gridColORDQTY.Visible = true;
            this.gridColORDQTY.VisibleIndex = 5;
            // 
            // gridColLOTQTY
            // 
            this.gridColLOTQTY.Caption = "Lot Qty";
            this.gridColLOTQTY.DisplayFormat.FormatString = "n2";
            this.gridColLOTQTY.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.gridColLOTQTY.FieldName = "LOTQTY";
            this.gridColLOTQTY.Name = "gridColLOTQTY";
            this.gridColLOTQTY.OptionsColumn.AllowEdit = false;
            this.gridColLOTQTY.Visible = true;
            this.gridColLOTQTY.VisibleIndex = 6;
            // 
            // gridColPrintQTY
            // 
            this.gridColPrintQTY.AppearanceHeader.ForeColor = System.Drawing.Color.Blue;
            this.gridColPrintQTY.AppearanceHeader.Options.UseForeColor = true;
            this.gridColPrintQTY.Caption = "Print Qty";
            this.gridColPrintQTY.FieldName = "PrintQTY";
            this.gridColPrintQTY.Name = "gridColPrintQTY";
            this.gridColPrintQTY.OptionsColumn.AllowEdit = false;
            this.gridColPrintQTY.Summary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] {
            new DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum)});
            this.gridColPrintQTY.Visible = true;
            this.gridColPrintQTY.VisibleIndex = 7;
            // 
            // gridColRECDTE
            // 
            this.gridColRECDTE.Caption = "Rec Date";
            this.gridColRECDTE.FieldName = "RECDTE";
            this.gridColRECDTE.Name = "gridColRECDTE";
            this.gridColRECDTE.OptionsColumn.AllowEdit = false;
            this.gridColRECDTE.Visible = true;
            this.gridColRECDTE.VisibleIndex = 17;
            // 
            // gridColDUEDTE
            // 
            this.gridColDUEDTE.Caption = "Due Date";
            this.gridColDUEDTE.FieldName = "DUEDTE";
            this.gridColDUEDTE.Name = "gridColDUEDTE";
            this.gridColDUEDTE.OptionsColumn.AllowEdit = false;
            this.gridColDUEDTE.Visible = true;
            this.gridColDUEDTE.VisibleIndex = 18;
            // 
            // gridColLOTNO
            // 
            this.gridColLOTNO.Caption = "Lot No";
            this.gridColLOTNO.FieldName = "LOTNO";
            this.gridColLOTNO.Name = "gridColLOTNO";
            this.gridColLOTNO.OptionsColumn.AllowEdit = false;
            this.gridColLOTNO.Visible = true;
            this.gridColLOTNO.VisibleIndex = 1;
            // 
            // gridColcreater
            // 
            this.gridColcreater.Caption = "creater";
            this.gridColcreater.FieldName = "creater";
            this.gridColcreater.Name = "gridColcreater";
            this.gridColcreater.OptionsColumn.AllowEdit = false;
            // 
            // gridColcreatedate
            // 
            this.gridColcreatedate.Caption = "createdate";
            this.gridColcreatedate.FieldName = "createdate";
            this.gridColcreatedate.Name = "gridColcreatedate";
            this.gridColcreatedate.OptionsColumn.AllowEdit = false;
            // 
            // gridColcUnitID
            // 
            this.gridColcUnitID.Caption = "cUnitID";
            this.gridColcUnitID.FieldName = "cUnitID";
            this.gridColcUnitID.Name = "gridColcUnitID";
            this.gridColcUnitID.OptionsColumn.AllowEdit = false;
            // 
            // gridColPrintCount
            // 
            this.gridColPrintCount.Caption = "Print Count";
            this.gridColPrintCount.FieldName = "PrintCount";
            this.gridColPrintCount.Name = "gridColPrintCount";
            this.gridColPrintCount.OptionsColumn.AllowEdit = false;
            // 
            // gridColPrintTime
            // 
            this.gridColPrintTime.Caption = "Print Time";
            this.gridColPrintTime.FieldName = "PrintTime";
            this.gridColPrintTime.Name = "gridColPrintTime";
            this.gridColPrintTime.OptionsColumn.AllowEdit = false;
            // 
            // gridColBarCode
            // 
            this.gridColBarCode.Caption = "BarCode";
            this.gridColBarCode.FieldName = "BarCode";
            this.gridColBarCode.Name = "gridColBarCode";
            this.gridColBarCode.OptionsColumn.AllowEdit = false;
            // 
            // gridColiID
            // 
            this.gridColiID.Caption = "iID";
            this.gridColiID.FieldName = "iID";
            this.gridColiID.Name = "gridColiID";
            this.gridColiID.OptionsColumn.AllowEdit = false;
            // 
            // gridColRACK
            // 
            this.gridColRACK.AppearanceHeader.ForeColor = System.Drawing.Color.Blue;
            this.gridColRACK.AppearanceHeader.Options.UseForeColor = true;
            this.gridColRACK.Caption = "RACK";
            this.gridColRACK.FieldName = "RACK";
            this.gridColRACK.Name = "gridColRACK";
            this.gridColRACK.Visible = true;
            this.gridColRACK.VisibleIndex = 9;
            // 
            // gridColMC
            // 
            this.gridColMC.AppearanceHeader.ForeColor = System.Drawing.Color.Blue;
            this.gridColMC.AppearanceHeader.Options.UseForeColor = true;
            this.gridColMC.Caption = "M/C";
            this.gridColMC.FieldName = "MC";
            this.gridColMC.Name = "gridColMC";
            this.gridColMC.Visible = true;
            this.gridColMC.VisibleIndex = 10;
            // 
            // gridColPOT
            // 
            this.gridColPOT.AppearanceHeader.ForeColor = System.Drawing.Color.Blue;
            this.gridColPOT.AppearanceHeader.Options.UseForeColor = true;
            this.gridColPOT.Caption = "POT";
            this.gridColPOT.FieldName = "POT";
            this.gridColPOT.Name = "gridColPOT";
            this.gridColPOT.Visible = true;
            this.gridColPOT.VisibleIndex = 11;
            // 
            // gridColPRODLINE
            // 
            this.gridColPRODLINE.AppearanceHeader.ForeColor = System.Drawing.Color.Blue;
            this.gridColPRODLINE.AppearanceHeader.Options.UseForeColor = true;
            this.gridColPRODLINE.Caption = "Prod Line";
            this.gridColPRODLINE.ColumnEdit = this.ItemLookUpEditRACK;
            this.gridColPRODLINE.FieldName = "PRODLINE";
            this.gridColPRODLINE.Name = "gridColPRODLINE";
            this.gridColPRODLINE.Visible = true;
            this.gridColPRODLINE.VisibleIndex = 12;
            // 
            // ItemLookUpEditRACK
            // 
            this.ItemLookUpEditRACK.AutoHeight = false;
            this.ItemLookUpEditRACK.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.ItemLookUpEditRACK.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("cCode", "Code"),
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("cName", 60, "Description")});
            this.ItemLookUpEditRACK.DisplayMember = "cCode";
            this.ItemLookUpEditRACK.Name = "ItemLookUpEditRACK";
            this.ItemLookUpEditRACK.NullText = "";
            this.ItemLookUpEditRACK.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.Standard;
            this.ItemLookUpEditRACK.ValueMember = "cCode";
            // 
            // panel1
            // 
            this.panel1.AutoScroll = true;
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.lookUpEditSOCode);
            this.panel1.Controls.Add(this.btnTxtSize);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.radioPreview);
            this.panel1.Controls.Add(this.radioPrint);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.lookUpEditPrinter);
            this.panel1.Controls.Add(this.label5);
            this.panel1.Controls.Add(this.btnTxtBarCode);
            this.panel1.Controls.Add(this.label4);
            this.panel1.Controls.Add(this.lookUpEditFlowType);
            this.panel1.Controls.Add(this.chkAll);
            this.panel1.Controls.Add(this.gridControl1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 28);
            this.panel1.Margin = new System.Windows.Forms.Padding(4);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1441, 541);
            this.panel1.TabIndex = 173;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(340, 54);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(71, 15);
            this.label3.TabIndex = 236;
            this.label3.Text = "Order No";
            // 
            // lookUpEditSOCode
            // 
            this.lookUpEditSOCode.Location = new System.Drawing.Point(428, 50);
            this.lookUpEditSOCode.Margin = new System.Windows.Forms.Padding(4);
            this.lookUpEditSOCode.Name = "lookUpEditSOCode";
            this.lookUpEditSOCode.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.lookUpEditSOCode.Properties.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("cSoCode", "Order No")});
            this.lookUpEditSOCode.Properties.DisplayMember = "cSoCode";
            this.lookUpEditSOCode.Properties.NullText = "";
            this.lookUpEditSOCode.Properties.PopupWidth = 400;
            this.lookUpEditSOCode.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.Standard;
            this.lookUpEditSOCode.Properties.ValueMember = "cSoCode";
            this.lookUpEditSOCode.Size = new System.Drawing.Size(188, 24);
            this.lookUpEditSOCode.TabIndex = 235;
            // 
            // btnTxtSize
            // 
            this.btnTxtSize.Location = new System.Drawing.Point(143, 48);
            this.btnTxtSize.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnTxtSize.Name = "btnTxtSize";
            this.btnTxtSize.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
            this.btnTxtSize.Properties.DisplayFormat.FormatString = "n2";
            this.btnTxtSize.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.btnTxtSize.Properties.EditFormat.FormatString = "n2";
            this.btnTxtSize.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.btnTxtSize.Properties.Mask.EditMask = "n2";
            this.btnTxtSize.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Numeric;
            this.btnTxtSize.Size = new System.Drawing.Size(179, 24);
            this.btnTxtSize.TabIndex = 234;
            this.btnTxtSize.ButtonClick += new DevExpress.XtraEditors.Controls.ButtonPressedEventHandler(this.btnTxtSize_ButtonClick);
            this.btnTxtSize.KeyUp += new System.Windows.Forms.KeyEventHandler(this.btnTxtSize_KeyUp);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(23, 54);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(39, 15);
            this.label2.TabIndex = 233;
            this.label2.Text = "Size";
            // 
            // radioPreview
            // 
            this.radioPreview.AutoSize = true;
            this.radioPreview.Location = new System.Drawing.Point(917, 49);
            this.radioPreview.Margin = new System.Windows.Forms.Padding(4);
            this.radioPreview.Name = "radioPreview";
            this.radioPreview.Size = new System.Drawing.Size(84, 19);
            this.radioPreview.TabIndex = 231;
            this.radioPreview.Text = "Preview";
            this.radioPreview.UseVisualStyleBackColor = true;
            // 
            // radioPrint
            // 
            this.radioPrint.AutoSize = true;
            this.radioPrint.Checked = true;
            this.radioPrint.Location = new System.Drawing.Point(736, 49);
            this.radioPrint.Margin = new System.Windows.Forms.Padding(4);
            this.radioPrint.Name = "radioPrint";
            this.radioPrint.Size = new System.Drawing.Size(68, 19);
            this.radioPrint.TabIndex = 230;
            this.radioPrint.TabStop = true;
            this.radioPrint.Text = "Print";
            this.radioPrint.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(647, 21);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(63, 15);
            this.label1.TabIndex = 229;
            this.label1.Text = "Printer";
            // 
            // lookUpEditPrinter
            // 
            this.lookUpEditPrinter.Location = new System.Drawing.Point(732, 16);
            this.lookUpEditPrinter.Margin = new System.Windows.Forms.Padding(4);
            this.lookUpEditPrinter.Name = "lookUpEditPrinter";
            this.lookUpEditPrinter.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.lookUpEditPrinter.Properties.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("Printer", "Printer")});
            this.lookUpEditPrinter.Properties.DisplayMember = "Printer";
            this.lookUpEditPrinter.Properties.NullText = "";
            this.lookUpEditPrinter.Properties.PopupWidth = 400;
            this.lookUpEditPrinter.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.Standard;
            this.lookUpEditPrinter.Properties.ValueMember = "Printer";
            this.lookUpEditPrinter.Size = new System.Drawing.Size(305, 24);
            this.lookUpEditPrinter.TabIndex = 228;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(23, 21);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(95, 15);
            this.label5.TabIndex = 226;
            this.label5.Text = "Lot No Scan";
            // 
            // btnTxtBarCode
            // 
            this.btnTxtBarCode.Location = new System.Drawing.Point(143, 16);
            this.btnTxtBarCode.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnTxtBarCode.Name = "btnTxtBarCode";
            this.btnTxtBarCode.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
            this.btnTxtBarCode.Size = new System.Drawing.Size(179, 24);
            this.btnTxtBarCode.TabIndex = 227;
            this.btnTxtBarCode.ButtonClick += new DevExpress.XtraEditors.Controls.ButtonPressedEventHandler(this.btnTxtBarCode_ButtonClick);
            this.btnTxtBarCode.KeyDown += new System.Windows.Forms.KeyEventHandler(this.btnTxtBarCode_KeyDown);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(340, 21);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(79, 15);
            this.label4.TabIndex = 225;
            this.label4.Text = "Flow Type";
            // 
            // lookUpEditFlowType
            // 
            this.lookUpEditFlowType.Location = new System.Drawing.Point(428, 16);
            this.lookUpEditFlowType.Margin = new System.Windows.Forms.Padding(4);
            this.lookUpEditFlowType.Name = "lookUpEditFlowType";
            this.lookUpEditFlowType.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.lookUpEditFlowType.Properties.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("FlowType", "FlowType")});
            this.lookUpEditFlowType.Properties.DisplayMember = "FlowType";
            this.lookUpEditFlowType.Properties.NullText = "";
            this.lookUpEditFlowType.Properties.PopupWidth = 400;
            this.lookUpEditFlowType.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.Standard;
            this.lookUpEditFlowType.Properties.ValueMember = "FlowType";
            this.lookUpEditFlowType.Size = new System.Drawing.Size(188, 24);
            this.lookUpEditFlowType.TabIndex = 224;
            this.lookUpEditFlowType.EditValueChanged += new System.EventHandler(this.lookUpEditFlowType_EditValueChanged);
            // 
            // chkAll
            // 
            this.chkAll.AutoSize = true;
            this.chkAll.Location = new System.Drawing.Point(25, 89);
            this.chkAll.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.chkAll.Name = "chkAll";
            this.chkAll.Size = new System.Drawing.Size(109, 19);
            this.chkAll.TabIndex = 223;
            this.chkAll.Text = "Select All";
            this.chkAll.UseVisualStyleBackColor = true;
            this.chkAll.CheckedChanged += new System.EventHandler(this.chkAll_CheckedChanged);
            // 
            // gridColColor
            // 
            this.gridColColor.Caption = "Color";
            this.gridColColor.FieldName = "Color";
            this.gridColColor.Name = "gridColColor";
            this.gridColColor.OptionsColumn.AllowEdit = false;
            this.gridColColor.Visible = true;
            this.gridColColor.VisibleIndex = 19;
            // 
            // PrintFlowCard
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.menuStrip1);
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "PrintFlowCard";
            this.Size = new System.Drawing.Size(1441, 569);
            this.Load += new System.EventHandler(this.Frm_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ItemLookUpEditRACK)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.lookUpEditSOCode.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnTxtSize.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lookUpEditPrinter.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnTxtBarCode.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lookUpEditFlowType.Properties)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem btnPrint;
        private DevExpress.XtraGrid.GridControl gridControl1;
        private System.Windows.Forms.Panel panel1;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView1;
        private System.Windows.Forms.ToolStripMenuItem btnExport;
        private System.Windows.Forms.ToolStripMenuItem btnPrintSet;
        private System.Windows.Forms.CheckBox chkAll;
        private System.Windows.Forms.Label label5;
        private DevExpress.XtraEditors.ButtonEdit btnTxtBarCode;
        private System.Windows.Forms.Label label4;
        private DevExpress.XtraEditors.LookUpEdit lookUpEditFlowType;
        private DevExpress.XtraGrid.Columns.GridColumn gridColchoose;
        private DevExpress.XtraGrid.Columns.GridColumn gridColcSTCode;
        private DevExpress.XtraGrid.Columns.GridColumn gridColdDate;
        private DevExpress.XtraGrid.Columns.GridColumn gridColcSOCode;
        private DevExpress.XtraGrid.Columns.GridColumn gridColiSOsID;
        private DevExpress.XtraGrid.Columns.GridColumn gridColiRowNo;
        private DevExpress.XtraGrid.Columns.GridColumn gridColcDepCode;
        private DevExpress.XtraGrid.Columns.GridColumn gridColcCusCode;
        private DevExpress.XtraGrid.Columns.GridColumn gridColvend;
        private DevExpress.XtraGrid.Columns.GridColumn gridColItemNO;
        private DevExpress.XtraGrid.Columns.GridColumn gridColItemDESC;
        private DevExpress.XtraGrid.Columns.GridColumn gridColCustLOT;
        private DevExpress.XtraGrid.Columns.GridColumn gridColCustDO;
        private DevExpress.XtraGrid.Columns.GridColumn gridColORDQTY;
        private DevExpress.XtraGrid.Columns.GridColumn gridColLOTQTY;
        private DevExpress.XtraGrid.Columns.GridColumn gridColPrintQTY;
        private DevExpress.XtraGrid.Columns.GridColumn gridColRECDTE;
        private DevExpress.XtraGrid.Columns.GridColumn gridColDUEDTE;
        private DevExpress.XtraGrid.Columns.GridColumn gridColLOTNO;
        private DevExpress.XtraGrid.Columns.GridColumn gridColcreater;
        private DevExpress.XtraGrid.Columns.GridColumn gridColcreatedate;
        private DevExpress.XtraGrid.Columns.GridColumn gridColcUnitID;
        private DevExpress.XtraGrid.Columns.GridColumn gridColPrintCount;
        private DevExpress.XtraGrid.Columns.GridColumn gridColPrintTime;
        private DevExpress.XtraGrid.Columns.GridColumn gridColBarCode;
        private DevExpress.XtraGrid.Columns.GridColumn gridColiID;
        private System.Windows.Forms.Label label1;
        private DevExpress.XtraEditors.LookUpEdit lookUpEditPrinter;
        private System.Windows.Forms.RadioButton radioPreview;
        private System.Windows.Forms.RadioButton radioPrint;
        private DevExpress.XtraGrid.Columns.GridColumn gridColRACK;
        private DevExpress.XtraGrid.Columns.GridColumn gridColMC;
        private DevExpress.XtraGrid.Columns.GridColumn gridColPOT;
        private DevExpress.XtraGrid.Columns.GridColumn gridColPRODLINE;
        private System.Windows.Forms.Label label2;
        private DevExpress.XtraEditors.ButtonEdit btnTxtSize;
        private DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit ItemLookUpEditRACK;
        private System.Windows.Forms.Label label3;
        private DevExpress.XtraEditors.LookUpEdit lookUpEditSOCode;
        private System.Windows.Forms.ToolStripMenuItem btnQuery;
        private DevExpress.XtraGrid.Columns.GridColumn gridColColor;
    }
}
