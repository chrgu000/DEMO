namespace UFIDA.U8.UAP.CustomApp.ControlForm
{
    partial class Exchange
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
            this.ItemTextEditn2 = new DevExpress.XtraEditors.Repository.RepositoryItemTextEdit();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.btnQuery = new System.Windows.Forms.ToolStripMenuItem();
            this.btnSave = new System.Windows.Forms.ToolStripMenuItem();
            this.btnExport = new System.Windows.Forms.ToolStripMenuItem();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.lookUpEditPeriod = new DevExpress.XtraEditors.LookUpEdit();
            this.label6 = new System.Windows.Forms.Label();
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
            this.gridColcVenCode = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColcVenName = new DevExpress.XtraGrid.Columns.GridColumn();
            ((System.ComponentModel.ISupportInitialize)(this.ItemTextEditn2)).BeginInit();
            this.menuStrip1.SuspendLayout();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.lookUpEditPeriod.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).BeginInit();
            this.SuspendLayout();
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
            // menuStrip1
            // 
            this.menuStrip1.AllowDrop = true;
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btnQuery,
            this.btnSave,
            this.btnExport});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Padding = new System.Windows.Forms.Padding(9, 3, 0, 3);
            this.menuStrip1.Size = new System.Drawing.Size(1546, 28);
            this.menuStrip1.TabIndex = 172;
            this.menuStrip1.Text = "menuStrip";
            // 
            // btnQuery
            // 
            this.btnQuery.Name = "btnQuery";
            this.btnQuery.Size = new System.Drawing.Size(65, 22);
            this.btnQuery.Text = "Query";
            this.btnQuery.Click += new System.EventHandler(this.btnQuery_Click);
            // 
            // btnSave
            // 
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(56, 22);
            this.btnSave.Text = "Save";
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // btnExport
            // 
            this.btnExport.Name = "btnExport";
            this.btnExport.Size = new System.Drawing.Size(128, 22);
            this.btnExport.Text = "Export Excel";
            this.btnExport.Click += new System.EventHandler(this.btnExport_Click);
            // 
            // panel1
            // 
            this.panel1.AutoScroll = true;
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.lookUpEditPeriod);
            this.panel1.Controls.Add(this.label6);
            this.panel1.Controls.Add(this.gridControl1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 28);
            this.panel1.Margin = new System.Windows.Forms.Padding(4);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1546, 564);
            this.panel1.TabIndex = 173;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(420, 20);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(62, 18);
            this.label1.TabIndex = 217;
            this.label1.Text = "Period";
            // 
            // lookUpEditPeriod
            // 
            this.lookUpEditPeriod.Location = new System.Drawing.Point(188, 15);
            this.lookUpEditPeriod.Margin = new System.Windows.Forms.Padding(4);
            this.lookUpEditPeriod.Name = "lookUpEditPeriod";
            this.lookUpEditPeriod.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.lookUpEditPeriod.Properties.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("Period", 40, "Period")});
            this.lookUpEditPeriod.Properties.DisplayMember = "Period";
            this.lookUpEditPeriod.Properties.NullText = "";
            this.lookUpEditPeriod.Properties.PopupWidth = 500;
            this.lookUpEditPeriod.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.Standard;
            this.lookUpEditPeriod.Properties.ValueMember = "Period";
            this.lookUpEditPeriod.Size = new System.Drawing.Size(202, 28);
            this.lookUpEditPeriod.TabIndex = 216;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(21, 20);
            this.label6.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(143, 18);
            this.label6.TabIndex = 215;
            this.label6.Text = "Expiration date";
            // 
            // gridControl1
            // 
            this.gridControl1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.gridControl1.EmbeddedNavigator.Margin = new System.Windows.Forms.Padding(4);
            this.gridControl1.Location = new System.Drawing.Point(0, 69);
            this.gridControl1.LookAndFeel.SkinName = "Office 2010 Blue";
            this.gridControl1.MainView = this.gridView1;
            this.gridControl1.Margin = new System.Windows.Forms.Padding(4);
            this.gridControl1.Name = "gridControl1";
            this.gridControl1.Size = new System.Drawing.Size(1546, 496);
            this.gridControl1.TabIndex = 194;
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
            this.gridColino_id,
            this.gridColcVenCode,
            this.gridColcVenName});
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
            this.gridColdDate.VisibleIndex = 5;
            // 
            // gridColAutoID
            // 
            this.gridColAutoID.Caption = "AutoID";
            this.gridColAutoID.FieldName = "AutoID";
            this.gridColAutoID.Name = "gridColAutoID";
            this.gridColAutoID.OptionsColumn.AllowEdit = false;
            this.gridColAutoID.Visible = true;
            this.gridColAutoID.VisibleIndex = 13;
            // 
            // gridColcInvCode
            // 
            this.gridColcInvCode.Caption = "cInvCode";
            this.gridColcInvCode.FieldName = "cInvCode";
            this.gridColcInvCode.Name = "gridColcInvCode";
            this.gridColcInvCode.OptionsColumn.AllowEdit = false;
            this.gridColcInvCode.Visible = true;
            this.gridColcInvCode.VisibleIndex = 6;
            // 
            // gridColcInvName
            // 
            this.gridColcInvName.Caption = "cInvName";
            this.gridColcInvName.FieldName = "cInvName";
            this.gridColcInvName.Name = "gridColcInvName";
            this.gridColcInvName.OptionsColumn.AllowEdit = false;
            this.gridColcInvName.Visible = true;
            this.gridColcInvName.VisibleIndex = 7;
            // 
            // gridColcInvStd
            // 
            this.gridColcInvStd.Caption = "cInvStd";
            this.gridColcInvStd.FieldName = "cInvStd";
            this.gridColcInvStd.Name = "gridColcInvStd";
            this.gridColcInvStd.OptionsColumn.AllowEdit = false;
            this.gridColcInvStd.Visible = true;
            this.gridColcInvStd.VisibleIndex = 8;
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
            this.gridColiOriSum.VisibleIndex = 9;
            // 
            // gridColnflat
            // 
            this.gridColnflat.Caption = "nflat";
            this.gridColnflat.FieldName = "nflat";
            this.gridColnflat.Name = "gridColnflat";
            this.gridColnflat.OptionsColumn.AllowEdit = false;
            this.gridColnflat.Visible = true;
            this.gridColnflat.VisibleIndex = 10;
            this.gridColnflat.Width = 112;
            // 
            // gridColnflat2
            // 
            this.gridColnflat2.Caption = "nflat2";
            this.gridColnflat2.FieldName = "nflat2";
            this.gridColnflat2.Name = "gridColnflat2";
            this.gridColnflat2.OptionsColumn.AllowEdit = false;
            this.gridColnflat2.Visible = true;
            this.gridColnflat2.VisibleIndex = 11;
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
            this.gridColAmountOfExchangeProfitAndLoss.VisibleIndex = 12;
            this.gridColAmountOfExchangeProfitAndLoss.Width = 209;
            // 
            // gridColino_id
            // 
            this.gridColino_id.Caption = "ino_id";
            this.gridColino_id.FieldName = "ino_id";
            this.gridColino_id.Name = "gridColino_id";
            this.gridColino_id.OptionsColumn.AllowEdit = false;
            this.gridColino_id.Visible = true;
            this.gridColino_id.VisibleIndex = 14;
            // 
            // gridColcVenCode
            // 
            this.gridColcVenCode.Caption = "Vendor Code";
            this.gridColcVenCode.FieldName = "cVenCode";
            this.gridColcVenCode.Name = "gridColcVenCode";
            this.gridColcVenCode.OptionsColumn.AllowEdit = false;
            this.gridColcVenCode.Visible = true;
            this.gridColcVenCode.VisibleIndex = 3;
            this.gridColcVenCode.Width = 121;
            // 
            // gridColcVenName
            // 
            this.gridColcVenName.Caption = "Vendor";
            this.gridColcVenName.FieldName = "cVenName";
            this.gridColcVenName.Name = "gridColcVenName";
            this.gridColcVenName.OptionsColumn.AllowEdit = false;
            this.gridColcVenName.Visible = true;
            this.gridColcVenName.VisibleIndex = 4;
            this.gridColcVenName.Width = 356;
            // 
            // Exchange
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 18F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.menuStrip1);
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "Exchange";
            this.Size = new System.Drawing.Size(1546, 592);
            this.Load += new System.EventHandler(this.Frm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.ItemTextEditn2)).EndInit();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.lookUpEditPeriod.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.Panel panel1;
        private DevExpress.XtraEditors.Repository.RepositoryItemTextEdit ItemTextEditn2;
        private System.Windows.Forms.ToolStripMenuItem btnQuery;
        private DevExpress.XtraGrid.GridControl gridControl1;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView1;
        private System.Windows.Forms.ToolStripMenuItem btnSave;
        private DevExpress.XtraGrid.Columns.GridColumn gridColcCode;
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
        private System.Windows.Forms.Label label6;
        private DevExpress.XtraEditors.LookUpEdit lookUpEditPeriod;
        private DevExpress.XtraGrid.Columns.GridColumn gridColirowno;
        private DevExpress.XtraGrid.Columns.GridColumn gridColino_id;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ToolStripMenuItem btnExport;
        private DevExpress.XtraGrid.Columns.GridColumn gridColcVenCode;
        private DevExpress.XtraGrid.Columns.GridColumn gridColcVenName;
    }
}
