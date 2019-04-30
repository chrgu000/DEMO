namespace UFIDA.U8.UAP.CustomApp.ControlForm
{
    partial class FrmExchangeDetails
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
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.btnExport = new System.Windows.Forms.ToolStripMenuItem();
            this.btnClose = new System.Windows.Forms.ToolStripMenuItem();
            this.gridControl1 = new DevExpress.XtraGrid.GridControl();
            this.gridView1 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.gridColcCode = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColirowno = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColcExch_Name = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColdDate = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColAutoID = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColcInvCode = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColcInvName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColcInvStd = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColiOriSum = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColnflat = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColnflat2 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColAmountOfExchangeProfitAndLoss = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColino_id = new DevExpress.XtraGrid.Columns.GridColumn();
            this.menuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.AllowDrop = true;
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btnExport,
            this.btnClose});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Padding = new System.Windows.Forms.Padding(9, 3, 0, 3);
            this.menuStrip1.Size = new System.Drawing.Size(1572, 28);
            this.menuStrip1.TabIndex = 173;
            this.menuStrip1.Text = "menuStrip";
            // 
            // btnExport
            // 
            this.btnExport.Name = "btnExport";
            this.btnExport.Size = new System.Drawing.Size(128, 22);
            this.btnExport.Text = "Export Excel";
            this.btnExport.Click += new System.EventHandler(this.btnExport_Click);
            // 
            // btnClose
            // 
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(65, 22);
            this.btnClose.Text = "Close";
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // gridControl1
            // 
            this.gridControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridControl1.EmbeddedNavigator.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.gridControl1.Location = new System.Drawing.Point(0, 28);
            this.gridControl1.LookAndFeel.SkinName = "Office 2010 Blue";
            this.gridControl1.MainView = this.gridView1;
            this.gridControl1.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.gridControl1.Name = "gridControl1";
            this.gridControl1.Size = new System.Drawing.Size(1572, 652);
            this.gridControl1.TabIndex = 195;
            this.gridControl1.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView1});
            // 
            // gridView1
            // 
            this.gridView1.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.gridColcCode,
            this.gridColirowno,
            this.gridColcExch_Name,
            this.gridColdDate,
            this.gridColAutoID,
            this.gridColcInvCode,
            this.gridColcInvName,
            this.gridColcInvStd,
            this.gridColiOriSum,
            this.gridColnflat,
            this.gridColnflat2,
            this.gridColAmountOfExchangeProfitAndLoss,
            this.gridColino_id});
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
            // gridColcCode
            // 
            this.gridColcCode.Caption = "cCode";
            this.gridColcCode.FieldName = "cCode";
            this.gridColcCode.Name = "gridColcCode";
            this.gridColcCode.OptionsColumn.AllowEdit = false;
            this.gridColcCode.Visible = true;
            this.gridColcCode.VisibleIndex = 0;
            // 
            // gridColirowno
            // 
            this.gridColirowno.Caption = "irowno";
            this.gridColirowno.FieldName = "irowno";
            this.gridColirowno.Name = "gridColirowno";
            this.gridColirowno.OptionsColumn.AllowEdit = false;
            this.gridColirowno.Visible = true;
            this.gridColirowno.VisibleIndex = 1;
            // 
            // gridColcExch_Name
            // 
            this.gridColcExch_Name.Caption = "cExch_Name";
            this.gridColcExch_Name.FieldName = "cExch_Name";
            this.gridColcExch_Name.Name = "gridColcExch_Name";
            this.gridColcExch_Name.OptionsColumn.AllowEdit = false;
            this.gridColcExch_Name.Visible = true;
            this.gridColcExch_Name.VisibleIndex = 2;
            this.gridColcExch_Name.Width = 105;
            // 
            // gridColdDate
            // 
            this.gridColdDate.Caption = "dDate";
            this.gridColdDate.FieldName = "dDate";
            this.gridColdDate.Name = "gridColdDate";
            this.gridColdDate.OptionsColumn.AllowEdit = false;
            this.gridColdDate.Visible = true;
            this.gridColdDate.VisibleIndex = 3;
            // 
            // gridColAutoID
            // 
            this.gridColAutoID.Caption = "AutoID";
            this.gridColAutoID.FieldName = "AutoID";
            this.gridColAutoID.Name = "gridColAutoID";
            this.gridColAutoID.OptionsColumn.AllowEdit = false;
            this.gridColAutoID.Visible = true;
            this.gridColAutoID.VisibleIndex = 11;
            // 
            // gridColcInvCode
            // 
            this.gridColcInvCode.Caption = "cInvCode";
            this.gridColcInvCode.FieldName = "cInvCode";
            this.gridColcInvCode.Name = "gridColcInvCode";
            this.gridColcInvCode.OptionsColumn.AllowEdit = false;
            this.gridColcInvCode.Visible = true;
            this.gridColcInvCode.VisibleIndex = 4;
            // 
            // gridColcInvName
            // 
            this.gridColcInvName.Caption = "cInvName";
            this.gridColcInvName.FieldName = "cInvName";
            this.gridColcInvName.Name = "gridColcInvName";
            this.gridColcInvName.OptionsColumn.AllowEdit = false;
            this.gridColcInvName.Visible = true;
            this.gridColcInvName.VisibleIndex = 5;
            // 
            // gridColcInvStd
            // 
            this.gridColcInvStd.Caption = "cInvStd";
            this.gridColcInvStd.FieldName = "cInvStd";
            this.gridColcInvStd.Name = "gridColcInvStd";
            this.gridColcInvStd.OptionsColumn.AllowEdit = false;
            this.gridColcInvStd.Visible = true;
            this.gridColcInvStd.VisibleIndex = 6;
            // 
            // gridColiOriSum
            // 
            this.gridColiOriSum.Caption = "iOriSum";
            this.gridColiOriSum.DisplayFormat.FormatString = "n2";
            this.gridColiOriSum.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.gridColiOriSum.FieldName = "iOriSum";
            this.gridColiOriSum.Name = "gridColiOriSum";
            this.gridColiOriSum.OptionsColumn.AllowEdit = false;
            this.gridColiOriSum.Summary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] {
            new DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "iOriSum", "{0:#,##0.00}")});
            this.gridColiOriSum.Visible = true;
            this.gridColiOriSum.VisibleIndex = 7;
            // 
            // gridColnflat
            // 
            this.gridColnflat.Caption = "nflat";
            this.gridColnflat.FieldName = "nflat";
            this.gridColnflat.Name = "gridColnflat";
            this.gridColnflat.OptionsColumn.AllowEdit = false;
            this.gridColnflat.Visible = true;
            this.gridColnflat.VisibleIndex = 8;
            this.gridColnflat.Width = 112;
            // 
            // gridColnflat2
            // 
            this.gridColnflat2.Caption = "nflat2";
            this.gridColnflat2.FieldName = "nflat2";
            this.gridColnflat2.Name = "gridColnflat2";
            this.gridColnflat2.OptionsColumn.AllowEdit = false;
            this.gridColnflat2.Visible = true;
            this.gridColnflat2.VisibleIndex = 9;
            this.gridColnflat2.Width = 127;
            // 
            // gridColAmountOfExchangeProfitAndLoss
            // 
            this.gridColAmountOfExchangeProfitAndLoss.Caption = "AmountOfExchangeProfitAndLoss";
            this.gridColAmountOfExchangeProfitAndLoss.DisplayFormat.FormatString = "n2";
            this.gridColAmountOfExchangeProfitAndLoss.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.gridColAmountOfExchangeProfitAndLoss.FieldName = "AmountOfExchangeProfitAndLoss";
            this.gridColAmountOfExchangeProfitAndLoss.Name = "gridColAmountOfExchangeProfitAndLoss";
            this.gridColAmountOfExchangeProfitAndLoss.OptionsColumn.AllowEdit = false;
            this.gridColAmountOfExchangeProfitAndLoss.Summary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] {
            new DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "AmountOfExchangeProfitAndLoss", "{0:#,##0.00}")});
            this.gridColAmountOfExchangeProfitAndLoss.Visible = true;
            this.gridColAmountOfExchangeProfitAndLoss.VisibleIndex = 10;
            this.gridColAmountOfExchangeProfitAndLoss.Width = 209;
            // 
            // gridColino_id
            // 
            this.gridColino_id.Caption = "ino_id";
            this.gridColino_id.FieldName = "ino_id";
            this.gridColino_id.Name = "gridColino_id";
            this.gridColino_id.OptionsColumn.AllowEdit = false;
            this.gridColino_id.Visible = true;
            this.gridColino_id.VisibleIndex = 12;
            // 
            // FrmExchangeDetails
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 18F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1572, 680);
            this.Controls.Add(this.gridControl1);
            this.Controls.Add(this.menuStrip1);
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Name = "FrmExchangeDetails";
            this.Text = "FrmExchangeDetails";
            this.Load += new System.EventHandler(this.FrmExchangeDetails_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem btnExport;
        private DevExpress.XtraGrid.GridControl gridControl1;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView1;
        private DevExpress.XtraGrid.Columns.GridColumn gridColcCode;
        private DevExpress.XtraGrid.Columns.GridColumn gridColirowno;
        private DevExpress.XtraGrid.Columns.GridColumn gridColcExch_Name;
        private DevExpress.XtraGrid.Columns.GridColumn gridColdDate;
        private DevExpress.XtraGrid.Columns.GridColumn gridColAutoID;
        private DevExpress.XtraGrid.Columns.GridColumn gridColcInvCode;
        private DevExpress.XtraGrid.Columns.GridColumn gridColcInvName;
        private DevExpress.XtraGrid.Columns.GridColumn gridColcInvStd;
        private DevExpress.XtraGrid.Columns.GridColumn gridColiOriSum;
        private DevExpress.XtraGrid.Columns.GridColumn gridColnflat;
        private DevExpress.XtraGrid.Columns.GridColumn gridColnflat2;
        private DevExpress.XtraGrid.Columns.GridColumn gridColAmountOfExchangeProfitAndLoss;
        private DevExpress.XtraGrid.Columns.GridColumn gridColino_id;
        private System.Windows.Forms.ToolStripMenuItem btnClose;
    }
}