namespace clsU8
{
    partial class Frm销售发票导出
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
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.btnExport = new System.Windows.Forms.ToolStripMenuItem();
            this.gridControl2 = new DevExpress.XtraGrid.GridControl();
            this.gridView2 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.gridCol_DO_NO = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridCol_DO_DATE = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridCol_SLIP_NO = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridCol_LOT_ID = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridCol_QTY = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridCol_PLATING_DATE = new DevExpress.XtraGrid.Columns.GridColumn();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).BeginInit();
            this.menuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView2)).BeginInit();
            this.SuspendLayout();
            // 
            // gridControl1
            // 
            this.gridControl1.EmbeddedNavigator.Margin = new System.Windows.Forms.Padding(4);
            this.gridControl1.Location = new System.Drawing.Point(0, 26);
            this.gridControl1.LookAndFeel.SkinName = "Office 2010 Blue";
            this.gridControl1.MainView = this.gridView1;
            this.gridControl1.Margin = new System.Windows.Forms.Padding(4);
            this.gridControl1.Name = "gridControl1";
            this.gridControl1.Size = new System.Drawing.Size(975, 363);
            this.gridControl1.TabIndex = 192;
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
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btnExport});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Padding = new System.Windows.Forms.Padding(8, 2, 0, 2);
            this.menuStrip1.Size = new System.Drawing.Size(975, 28);
            this.menuStrip1.TabIndex = 193;
            this.menuStrip1.Text = "menuStrip";
            // 
            // btnExport
            // 
            this.btnExport.Name = "btnExport";
            this.btnExport.Size = new System.Drawing.Size(69, 24);
            this.btnExport.Text = "Export";
            this.btnExport.Click += new System.EventHandler(this.btnExport_Click);
            // 
            // gridControl2
            // 
            this.gridControl2.EmbeddedNavigator.Margin = new System.Windows.Forms.Padding(4);
            this.gridControl2.Location = new System.Drawing.Point(0, 101);
            this.gridControl2.LookAndFeel.SkinName = "Office 2010 Blue";
            this.gridControl2.MainView = this.gridView2;
            this.gridControl2.Margin = new System.Windows.Forms.Padding(4);
            this.gridControl2.Name = "gridControl2";
            this.gridControl2.Size = new System.Drawing.Size(637, 288);
            this.gridControl2.TabIndex = 194;
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
            // Frm销售发票导出
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.ClientSize = new System.Drawing.Size(975, 393);
            this.Controls.Add(this.gridControl2);
            this.Controls.Add(this.menuStrip1);
            this.Controls.Add(this.gridControl1);
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "Frm销售发票导出";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Export";
            this.Load += new System.EventHandler(this.Frm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).EndInit();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView2)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

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
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem btnExport;
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