namespace UFIDA.U8.UAP.CustomApp.ControlForm
{
    partial class SaleBillVouchCSV
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
            this.btnSEL = new System.Windows.Forms.ToolStripMenuItem();
            this.btnExport = new System.Windows.Forms.ToolStripMenuItem();
            this.panel1 = new System.Windows.Forms.Panel();
            this.gridControl2 = new DevExpress.XtraGrid.GridControl();
            this.gridView2 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.gridCol_DO_NO = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridCol_DO_DATE = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridCol_SLIP_NO = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridCol_LOT_ID = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridCol_QTY = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridCol_PLATING_DATE = new DevExpress.XtraGrid.Columns.GridColumn();
            this.radioIC = new System.Windows.Forms.RadioButton();
            this.gridControl1 = new DevExpress.XtraGrid.GridControl();
            this.gridView1 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.gridColEPJINVOICENO = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColEPJONBOARDDATE = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColPARTCODE = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColJOBNO = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColEPJOPERATIONCODE = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColSEPOPERATIONCODE = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColDELIVERYQTY = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColREJECTQTY = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColMATERIALPRICE = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColCURRENCY = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColPRODUCTCODE = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColPARENTCODE = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColPLATINGSPEC = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColSEPINVOICENO = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColSTATUS = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColSEPPLTPRICE = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColSEPAMOUNT = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColEPJAMOUNT = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColSEPDONO = new DevExpress.XtraGrid.Columns.GridColumn();
            this.radioPP = new System.Windows.Forms.RadioButton();
            this.radioWP = new System.Windows.Forms.RadioButton();
            this.radioWC = new System.Windows.Forms.RadioButton();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.lookUpEditcSBVCode2 = new DevExpress.XtraEditors.LookUpEdit();
            this.lookUpEditcSBVCode1 = new DevExpress.XtraEditors.LookUpEdit();
            this.dateEdit2 = new DevExpress.XtraEditors.DateEdit();
            this.dateEdit1 = new DevExpress.XtraEditors.DateEdit();
            this.menuStrip1.SuspendLayout();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lookUpEditcSBVCode2.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lookUpEditcSBVCode1.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dateEdit2.Properties.VistaTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dateEdit2.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dateEdit1.Properties.VistaTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dateEdit1.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btnSEL,
            this.btnExport});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Padding = new System.Windows.Forms.Padding(8, 2, 0, 2);
            this.menuStrip1.Size = new System.Drawing.Size(1259, 28);
            this.menuStrip1.TabIndex = 172;
            this.menuStrip1.Text = "menuStrip";
            // 
            // btnSEL
            // 
            this.btnSEL.Name = "btnSEL";
            this.btnSEL.Size = new System.Drawing.Size(65, 24);
            this.btnSEL.Text = "Query";
            this.btnSEL.Click += new System.EventHandler(this.btnSEL_Click);
            // 
            // btnExport
            // 
            this.btnExport.Name = "btnExport";
            this.btnExport.Size = new System.Drawing.Size(69, 24);
            this.btnExport.Text = "Export";
            this.btnExport.Click += new System.EventHandler(this.btnExport_Click);
            // 
            // panel1
            // 
            this.panel1.AutoScroll = true;
            this.panel1.Controls.Add(this.gridControl2);
            this.panel1.Controls.Add(this.radioIC);
            this.panel1.Controls.Add(this.gridControl1);
            this.panel1.Controls.Add(this.radioPP);
            this.panel1.Controls.Add(this.radioWP);
            this.panel1.Controls.Add(this.radioWC);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.lookUpEditcSBVCode2);
            this.panel1.Controls.Add(this.lookUpEditcSBVCode1);
            this.panel1.Controls.Add(this.dateEdit2);
            this.panel1.Controls.Add(this.dateEdit1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 28);
            this.panel1.Margin = new System.Windows.Forms.Padding(4);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1259, 542);
            this.panel1.TabIndex = 173;
            // 
            // gridControl2
            // 
            this.gridControl2.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.gridControl2.EmbeddedNavigator.Margin = new System.Windows.Forms.Padding(4);
            this.gridControl2.Location = new System.Drawing.Point(8, 82);
            this.gridControl2.LookAndFeel.SkinName = "Office 2010 Blue";
            this.gridControl2.MainView = this.gridView2;
            this.gridControl2.Margin = new System.Windows.Forms.Padding(4);
            this.gridControl2.Name = "gridControl2";
            this.gridControl2.Size = new System.Drawing.Size(648, 456);
            this.gridControl2.TabIndex = 209;
            this.gridControl2.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView2});
            // 
            // gridView2
            // 
            this.gridView2.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.gridCol_DO_NO,
            this.gridCol_DO_DATE,
            this.gridCol_SLIP_NO,
            this.gridCol_LOT_ID,
            this.gridCol_QTY,
            this.gridCol_PLATING_DATE});
            this.gridView2.GridControl = this.gridControl2;
            this.gridView2.IndicatorWidth = 40;
            this.gridView2.Name = "gridView2";
            this.gridView2.OptionsBehavior.AllowDeleteRows = DevExpress.Utils.DefaultBoolean.True;
            this.gridView2.OptionsBehavior.EditorShowMode = DevExpress.Utils.EditorShowMode.MouseDown;
            this.gridView2.OptionsCustomization.AllowGroup = false;
            this.gridView2.OptionsCustomization.AllowQuickHideColumns = false;
            this.gridView2.OptionsNavigation.EnterMoveNextColumn = true;
            this.gridView2.OptionsPrint.AutoWidth = false;
            this.gridView2.OptionsView.ColumnAutoWidth = false;
            this.gridView2.OptionsView.ShowFooter = true;
            this.gridView2.OptionsView.ShowGroupPanel = false;
            this.gridView2.CustomDrawRowIndicator += new DevExpress.XtraGrid.Views.Grid.RowIndicatorCustomDrawEventHandler(this.gridView1_CustomDrawRowIndicator);
            // 
            // gridCol_DO_NO
            // 
            this.gridCol_DO_NO.Caption = "DO_NO(SEP DO)";
            this.gridCol_DO_NO.FieldName = "DO_NO";
            this.gridCol_DO_NO.Name = "gridCol_DO_NO";
            this.gridCol_DO_NO.Visible = true;
            this.gridCol_DO_NO.VisibleIndex = 0;
            // 
            // gridCol_DO_DATE
            // 
            this.gridCol_DO_DATE.Caption = "DO_DATE";
            this.gridCol_DO_DATE.FieldName = "DO_DATE";
            this.gridCol_DO_DATE.Name = "gridCol_DO_DATE";
            this.gridCol_DO_DATE.Visible = true;
            this.gridCol_DO_DATE.VisibleIndex = 1;
            this.gridCol_DO_DATE.Width = 91;
            // 
            // gridCol_SLIP_NO
            // 
            this.gridCol_SLIP_NO.Caption = "SLIP_NO";
            this.gridCol_SLIP_NO.FieldName = "SLIP_NO";
            this.gridCol_SLIP_NO.Name = "gridCol_SLIP_NO";
            this.gridCol_SLIP_NO.Visible = true;
            this.gridCol_SLIP_NO.VisibleIndex = 2;
            // 
            // gridCol_LOT_ID
            // 
            this.gridCol_LOT_ID.Caption = "LOT_ID";
            this.gridCol_LOT_ID.FieldName = "LOT_ID";
            this.gridCol_LOT_ID.Name = "gridCol_LOT_ID";
            this.gridCol_LOT_ID.Visible = true;
            this.gridCol_LOT_ID.VisibleIndex = 3;
            this.gridCol_LOT_ID.Width = 107;
            // 
            // gridCol_QTY
            // 
            this.gridCol_QTY.Caption = "QTY";
            this.gridCol_QTY.FieldName = "QTY";
            this.gridCol_QTY.Name = "gridCol_QTY";
            this.gridCol_QTY.Visible = true;
            this.gridCol_QTY.VisibleIndex = 4;
            // 
            // gridCol_PLATING_DATE
            // 
            this.gridCol_PLATING_DATE.Caption = "PLATING_DATE";
            this.gridCol_PLATING_DATE.FieldName = "PLATING_DATE";
            this.gridCol_PLATING_DATE.Name = "gridCol_PLATING_DATE";
            this.gridCol_PLATING_DATE.Visible = true;
            this.gridCol_PLATING_DATE.VisibleIndex = 5;
            this.gridCol_PLATING_DATE.Width = 128;
            // 
            // radioIC
            // 
            this.radioIC.AutoSize = true;
            this.radioIC.Location = new System.Drawing.Point(706, 44);
            this.radioIC.Name = "radioIC";
            this.radioIC.Size = new System.Drawing.Size(44, 19);
            this.radioIC.TabIndex = 208;
            this.radioIC.Text = "IC";
            this.radioIC.UseVisualStyleBackColor = true;
            this.radioIC.CheckedChanged += new System.EventHandler(this.radio_CheckedChanged);
            // 
            // gridControl1
            // 
            this.gridControl1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.gridControl1.EmbeddedNavigator.Margin = new System.Windows.Forms.Padding(4);
            this.gridControl1.Location = new System.Drawing.Point(8, 82);
            this.gridControl1.LookAndFeel.SkinName = "Office 2010 Blue";
            this.gridControl1.MainView = this.gridView1;
            this.gridControl1.Margin = new System.Windows.Forms.Padding(4);
            this.gridControl1.Name = "gridControl1";
            this.gridControl1.Size = new System.Drawing.Size(1247, 456);
            this.gridControl1.TabIndex = 207;
            this.gridControl1.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView1});
            // 
            // gridView1
            // 
            this.gridView1.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.gridColEPJINVOICENO,
            this.gridColEPJONBOARDDATE,
            this.gridColPARTCODE,
            this.gridColJOBNO,
            this.gridColEPJOPERATIONCODE,
            this.gridColSEPOPERATIONCODE,
            this.gridColDELIVERYQTY,
            this.gridColREJECTQTY,
            this.gridColMATERIALPRICE,
            this.gridColCURRENCY,
            this.gridColPRODUCTCODE,
            this.gridColPARENTCODE,
            this.gridColPLATINGSPEC,
            this.gridColSEPINVOICENO,
            this.gridColSTATUS,
            this.gridColSEPPLTPRICE,
            this.gridColSEPAMOUNT,
            this.gridColEPJAMOUNT,
            this.gridColSEPDONO});
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
            // gridColEPJINVOICENO
            // 
            this.gridColEPJINVOICENO.Caption = "EPJINVOICENO";
            this.gridColEPJINVOICENO.FieldName = "EPJINVOICENO";
            this.gridColEPJINVOICENO.Name = "gridColEPJINVOICENO";
            this.gridColEPJINVOICENO.Visible = true;
            this.gridColEPJINVOICENO.VisibleIndex = 0;
            // 
            // gridColEPJONBOARDDATE
            // 
            this.gridColEPJONBOARDDATE.Caption = "EPJONBOARDDATE";
            this.gridColEPJONBOARDDATE.FieldName = "EPJONBOARDDATE";
            this.gridColEPJONBOARDDATE.Name = "gridColEPJONBOARDDATE";
            this.gridColEPJONBOARDDATE.Visible = true;
            this.gridColEPJONBOARDDATE.VisibleIndex = 1;
            this.gridColEPJONBOARDDATE.Width = 91;
            // 
            // gridColPARTCODE
            // 
            this.gridColPARTCODE.Caption = "PARTCODE";
            this.gridColPARTCODE.FieldName = "PARTCODE";
            this.gridColPARTCODE.Name = "gridColPARTCODE";
            this.gridColPARTCODE.Visible = true;
            this.gridColPARTCODE.VisibleIndex = 2;
            // 
            // gridColJOBNO
            // 
            this.gridColJOBNO.Caption = "JOBNO";
            this.gridColJOBNO.FieldName = "JOBNO";
            this.gridColJOBNO.Name = "gridColJOBNO";
            this.gridColJOBNO.Visible = true;
            this.gridColJOBNO.VisibleIndex = 3;
            this.gridColJOBNO.Width = 107;
            // 
            // gridColEPJOPERATIONCODE
            // 
            this.gridColEPJOPERATIONCODE.Caption = "EPJOPERATIONCODE";
            this.gridColEPJOPERATIONCODE.FieldName = "EPJOPERATIONCODE";
            this.gridColEPJOPERATIONCODE.Name = "gridColEPJOPERATIONCODE";
            this.gridColEPJOPERATIONCODE.Visible = true;
            this.gridColEPJOPERATIONCODE.VisibleIndex = 4;
            // 
            // gridColSEPOPERATIONCODE
            // 
            this.gridColSEPOPERATIONCODE.Caption = "SEPOPERATIONCODE";
            this.gridColSEPOPERATIONCODE.FieldName = "SEPOPERATIONCODE";
            this.gridColSEPOPERATIONCODE.Name = "gridColSEPOPERATIONCODE";
            this.gridColSEPOPERATIONCODE.Visible = true;
            this.gridColSEPOPERATIONCODE.VisibleIndex = 5;
            // 
            // gridColDELIVERYQTY
            // 
            this.gridColDELIVERYQTY.Caption = "DELIVERYQTY";
            this.gridColDELIVERYQTY.FieldName = "DELIVERYQTY";
            this.gridColDELIVERYQTY.Name = "gridColDELIVERYQTY";
            this.gridColDELIVERYQTY.Visible = true;
            this.gridColDELIVERYQTY.VisibleIndex = 6;
            this.gridColDELIVERYQTY.Width = 104;
            // 
            // gridColREJECTQTY
            // 
            this.gridColREJECTQTY.Caption = "REJECTQTY";
            this.gridColREJECTQTY.FieldName = "REJECTQTY";
            this.gridColREJECTQTY.Name = "gridColREJECTQTY";
            this.gridColREJECTQTY.Visible = true;
            this.gridColREJECTQTY.VisibleIndex = 7;
            this.gridColREJECTQTY.Width = 84;
            // 
            // gridColMATERIALPRICE
            // 
            this.gridColMATERIALPRICE.Caption = "MATERIALPRICE";
            this.gridColMATERIALPRICE.FieldName = "MATERIALPRICE";
            this.gridColMATERIALPRICE.Name = "gridColMATERIALPRICE";
            this.gridColMATERIALPRICE.Visible = true;
            this.gridColMATERIALPRICE.VisibleIndex = 8;
            this.gridColMATERIALPRICE.Width = 142;
            // 
            // gridColCURRENCY
            // 
            this.gridColCURRENCY.Caption = "CURRENCY";
            this.gridColCURRENCY.FieldName = "CURRENCY";
            this.gridColCURRENCY.Name = "gridColCURRENCY";
            this.gridColCURRENCY.Visible = true;
            this.gridColCURRENCY.VisibleIndex = 9;
            // 
            // gridColPRODUCTCODE
            // 
            this.gridColPRODUCTCODE.Caption = "PRODUCTCODE";
            this.gridColPRODUCTCODE.FieldName = "PRODUCTCODE";
            this.gridColPRODUCTCODE.Name = "gridColPRODUCTCODE";
            this.gridColPRODUCTCODE.Visible = true;
            this.gridColPRODUCTCODE.VisibleIndex = 10;
            // 
            // gridColPARENTCODE
            // 
            this.gridColPARENTCODE.Caption = "PARENTCODE";
            this.gridColPARENTCODE.FieldName = "PARENTCODE";
            this.gridColPARENTCODE.Name = "gridColPARENTCODE";
            this.gridColPARENTCODE.Visible = true;
            this.gridColPARENTCODE.VisibleIndex = 11;
            // 
            // gridColPLATINGSPEC
            // 
            this.gridColPLATINGSPEC.Caption = "PLATINGSPEC";
            this.gridColPLATINGSPEC.FieldName = "PLATINGSPEC";
            this.gridColPLATINGSPEC.Name = "gridColPLATINGSPEC";
            this.gridColPLATINGSPEC.Visible = true;
            this.gridColPLATINGSPEC.VisibleIndex = 12;
            // 
            // gridColSEPINVOICENO
            // 
            this.gridColSEPINVOICENO.Caption = "SEPINVOICENO";
            this.gridColSEPINVOICENO.FieldName = "SEPINVOICENO";
            this.gridColSEPINVOICENO.Name = "gridColSEPINVOICENO";
            this.gridColSEPINVOICENO.Visible = true;
            this.gridColSEPINVOICENO.VisibleIndex = 13;
            // 
            // gridColSTATUS
            // 
            this.gridColSTATUS.Caption = "STATUS";
            this.gridColSTATUS.FieldName = "STATUS";
            this.gridColSTATUS.Name = "gridColSTATUS";
            this.gridColSTATUS.Visible = true;
            this.gridColSTATUS.VisibleIndex = 14;
            // 
            // gridColSEPPLTPRICE
            // 
            this.gridColSEPPLTPRICE.Caption = "SEPPLTPRICE";
            this.gridColSEPPLTPRICE.FieldName = "SEPPLTPRICE";
            this.gridColSEPPLTPRICE.Name = "gridColSEPPLTPRICE";
            this.gridColSEPPLTPRICE.Visible = true;
            this.gridColSEPPLTPRICE.VisibleIndex = 15;
            // 
            // gridColSEPAMOUNT
            // 
            this.gridColSEPAMOUNT.Caption = "SEPAMOUNT";
            this.gridColSEPAMOUNT.FieldName = "SEPAMOUNT";
            this.gridColSEPAMOUNT.Name = "gridColSEPAMOUNT";
            this.gridColSEPAMOUNT.Visible = true;
            this.gridColSEPAMOUNT.VisibleIndex = 16;
            // 
            // gridColEPJAMOUNT
            // 
            this.gridColEPJAMOUNT.Caption = "EPJAMOUNT";
            this.gridColEPJAMOUNT.FieldName = "EPJAMOUNT";
            this.gridColEPJAMOUNT.Name = "gridColEPJAMOUNT";
            this.gridColEPJAMOUNT.Visible = true;
            this.gridColEPJAMOUNT.VisibleIndex = 17;
            // 
            // gridColSEPDONO
            // 
            this.gridColSEPDONO.Caption = "SEPDONO";
            this.gridColSEPDONO.FieldName = "SEPDONO";
            this.gridColSEPDONO.Name = "gridColSEPDONO";
            this.gridColSEPDONO.Visible = true;
            this.gridColSEPDONO.VisibleIndex = 18;
            // 
            // radioPP
            // 
            this.radioPP.AutoSize = true;
            this.radioPP.Location = new System.Drawing.Point(767, 44);
            this.radioPP.Name = "radioPP";
            this.radioPP.Size = new System.Drawing.Size(44, 19);
            this.radioPP.TabIndex = 205;
            this.radioPP.Text = "PP";
            this.radioPP.UseVisualStyleBackColor = true;
            this.radioPP.CheckedChanged += new System.EventHandler(this.radio_CheckedChanged);
            // 
            // radioWP
            // 
            this.radioWP.AutoSize = true;
            this.radioWP.Location = new System.Drawing.Point(645, 44);
            this.radioWP.Name = "radioWP";
            this.radioWP.Size = new System.Drawing.Size(44, 19);
            this.radioWP.TabIndex = 204;
            this.radioWP.Text = "WP";
            this.radioWP.UseVisualStyleBackColor = true;
            this.radioWP.CheckedChanged += new System.EventHandler(this.radio_CheckedChanged);
            // 
            // radioWC
            // 
            this.radioWC.AutoSize = true;
            this.radioWC.Location = new System.Drawing.Point(582, 44);
            this.radioWC.Name = "radioWC";
            this.radioWC.Size = new System.Drawing.Size(44, 19);
            this.radioWC.TabIndex = 203;
            this.radioWC.Text = "WC";
            this.radioWC.UseVisualStyleBackColor = true;
            this.radioWC.CheckedChanged += new System.EventHandler(this.radio_CheckedChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(430, 44);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(87, 15);
            this.label3.TabIndex = 202;
            this.label3.Text = "Sales type";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(430, 8);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(103, 15);
            this.label2.TabIndex = 197;
            this.label2.Text = "Invoice Date";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(5, 8);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(95, 15);
            this.label1.TabIndex = 196;
            this.label1.Text = "Invoice No.";
            // 
            // lookUpEditcSBVCode2
            // 
            this.lookUpEditcSBVCode2.Location = new System.Drawing.Point(289, 4);
            this.lookUpEditcSBVCode2.Margin = new System.Windows.Forms.Padding(4);
            this.lookUpEditcSBVCode2.Name = "lookUpEditcSBVCode2";
            this.lookUpEditcSBVCode2.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.lookUpEditcSBVCode2.Properties.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("cSBVCode", "发票号")});
            this.lookUpEditcSBVCode2.Properties.DisplayMember = "cSBVCode";
            this.lookUpEditcSBVCode2.Properties.NullText = "";
            this.lookUpEditcSBVCode2.Properties.ValueMember = "cSBVCode";
            this.lookUpEditcSBVCode2.Size = new System.Drawing.Size(133, 24);
            this.lookUpEditcSBVCode2.TabIndex = 195;
            // 
            // lookUpEditcSBVCode1
            // 
            this.lookUpEditcSBVCode1.Location = new System.Drawing.Point(148, 4);
            this.lookUpEditcSBVCode1.Margin = new System.Windows.Forms.Padding(4);
            this.lookUpEditcSBVCode1.Name = "lookUpEditcSBVCode1";
            this.lookUpEditcSBVCode1.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.lookUpEditcSBVCode1.Properties.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("cSBVCode", "发票号")});
            this.lookUpEditcSBVCode1.Properties.DisplayMember = "cSBVCode";
            this.lookUpEditcSBVCode1.Properties.NullText = "";
            this.lookUpEditcSBVCode1.Properties.ValueMember = "cSBVCode";
            this.lookUpEditcSBVCode1.Size = new System.Drawing.Size(133, 24);
            this.lookUpEditcSBVCode1.TabIndex = 194;
            // 
            // dateEdit2
            // 
            this.dateEdit2.EditValue = null;
            this.dateEdit2.Location = new System.Drawing.Point(724, 4);
            this.dateEdit2.Margin = new System.Windows.Forms.Padding(4);
            this.dateEdit2.Name = "dateEdit2";
            this.dateEdit2.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.dateEdit2.Properties.VistaTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
            this.dateEdit2.Size = new System.Drawing.Size(133, 24);
            this.dateEdit2.TabIndex = 193;
            // 
            // dateEdit1
            // 
            this.dateEdit1.EditValue = null;
            this.dateEdit1.Location = new System.Drawing.Point(582, 4);
            this.dateEdit1.Margin = new System.Windows.Forms.Padding(4);
            this.dateEdit1.Name = "dateEdit1";
            this.dateEdit1.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.dateEdit1.Properties.VistaTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
            this.dateEdit1.Size = new System.Drawing.Size(133, 24);
            this.dateEdit1.TabIndex = 192;
            // 
            // SaleBillVouchCSV
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.menuStrip1);
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "SaleBillVouchCSV";
            this.Size = new System.Drawing.Size(1259, 570);
            this.Load += new System.EventHandler(this.Frm_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lookUpEditcSBVCode2.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lookUpEditcSBVCode1.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dateEdit2.Properties.VistaTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dateEdit2.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dateEdit1.Properties.VistaTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dateEdit1.Properties)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.ToolStripMenuItem btnSEL;
        private System.Windows.Forms.ToolStripMenuItem btnExport;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private DevExpress.XtraEditors.LookUpEdit lookUpEditcSBVCode2;
        private DevExpress.XtraEditors.LookUpEdit lookUpEditcSBVCode1;
        private DevExpress.XtraEditors.DateEdit dateEdit2;
        private DevExpress.XtraEditors.DateEdit dateEdit1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.RadioButton radioPP;
        private System.Windows.Forms.RadioButton radioWP;
        private System.Windows.Forms.RadioButton radioWC;
        private DevExpress.XtraGrid.GridControl gridControl1;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView1;
        private DevExpress.XtraGrid.Columns.GridColumn gridColEPJINVOICENO;
        private DevExpress.XtraGrid.Columns.GridColumn gridColEPJONBOARDDATE;
        private DevExpress.XtraGrid.Columns.GridColumn gridColPARTCODE;
        private DevExpress.XtraGrid.Columns.GridColumn gridColJOBNO;
        private DevExpress.XtraGrid.Columns.GridColumn gridColEPJOPERATIONCODE;
        private DevExpress.XtraGrid.Columns.GridColumn gridColSEPOPERATIONCODE;
        private DevExpress.XtraGrid.Columns.GridColumn gridColDELIVERYQTY;
        private DevExpress.XtraGrid.Columns.GridColumn gridColREJECTQTY;
        private DevExpress.XtraGrid.Columns.GridColumn gridColMATERIALPRICE;
        private DevExpress.XtraGrid.Columns.GridColumn gridColCURRENCY;
        private DevExpress.XtraGrid.Columns.GridColumn gridColPRODUCTCODE;
        private DevExpress.XtraGrid.Columns.GridColumn gridColPARENTCODE;
        private DevExpress.XtraGrid.Columns.GridColumn gridColPLATINGSPEC;
        private DevExpress.XtraGrid.Columns.GridColumn gridColSEPINVOICENO;
        private DevExpress.XtraGrid.Columns.GridColumn gridColSTATUS;
        private DevExpress.XtraGrid.Columns.GridColumn gridColSEPPLTPRICE;
        private DevExpress.XtraGrid.Columns.GridColumn gridColSEPAMOUNT;
        private DevExpress.XtraGrid.Columns.GridColumn gridColEPJAMOUNT;
        private DevExpress.XtraGrid.Columns.GridColumn gridColSEPDONO;
        private System.Windows.Forms.RadioButton radioIC;
        private DevExpress.XtraGrid.GridControl gridControl2;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView2;
        private DevExpress.XtraGrid.Columns.GridColumn gridCol_DO_NO;
        private DevExpress.XtraGrid.Columns.GridColumn gridCol_DO_DATE;
        private DevExpress.XtraGrid.Columns.GridColumn gridCol_SLIP_NO;
        private DevExpress.XtraGrid.Columns.GridColumn gridCol_LOT_ID;
        private DevExpress.XtraGrid.Columns.GridColumn gridCol_QTY;
        private DevExpress.XtraGrid.Columns.GridColumn gridCol_PLATING_DATE;
    }
}
