namespace UFIDA.U8.UAP.CustomApp.ControlForm
{
    partial class Process
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
            this.gridColProcessNo = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColProcess = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColCondition = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColPLATINGSPEC = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColTHICKNESS = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColTIME = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColAMPHRS = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColRemark = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColCreateUid = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColCreateDate = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColiState = new DevExpress.XtraGrid.Columns.GridColumn();
            this.panel1 = new System.Windows.Forms.Panel();
            this.menuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).BeginInit();
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
            this.gridControl1.Location = new System.Drawing.Point(3, 3);
            this.gridControl1.LookAndFeel.SkinName = "Office 2010 Blue";
            this.gridControl1.MainView = this.gridView1;
            this.gridControl1.Name = "gridControl1";
            this.gridControl1.Size = new System.Drawing.Size(939, 423);
            this.gridControl1.TabIndex = 191;
            this.gridControl1.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView1});
            // 
            // gridView1
            // 
            this.gridView1.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.gridColiID,
            this.gridColProcessNo,
            this.gridColProcess,
            this.gridColCondition,
            this.gridColPLATINGSPEC,
            this.gridColTHICKNESS,
            this.gridColTIME,
            this.gridColAMPHRS,
            this.gridColRemark,
            this.gridColCreateUid,
            this.gridColCreateDate,
            this.gridColiState});
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
            this.gridView1.FocusedRowChanged += new DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventHandler(this.gridView1_FocusedRowChanged);
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
            // gridColProcessNo
            // 
            this.gridColProcessNo.Caption = "ProcessNo";
            this.gridColProcessNo.FieldName = "ProcessNo";
            this.gridColProcessNo.Name = "gridColProcessNo";
            this.gridColProcessNo.OptionsColumn.AllowSort = DevExpress.Utils.DefaultBoolean.False;
            this.gridColProcessNo.Visible = true;
            this.gridColProcessNo.VisibleIndex = 0;
            this.gridColProcessNo.Width = 116;
            // 
            // gridColProcess
            // 
            this.gridColProcess.Caption = "Process";
            this.gridColProcess.FieldName = "Process";
            this.gridColProcess.Name = "gridColProcess";
            this.gridColProcess.OptionsColumn.AllowSort = DevExpress.Utils.DefaultBoolean.False;
            this.gridColProcess.Visible = true;
            this.gridColProcess.VisibleIndex = 1;
            // 
            // gridColCondition
            // 
            this.gridColCondition.Caption = "Condition";
            this.gridColCondition.FieldName = "Condition";
            this.gridColCondition.Name = "gridColCondition";
            this.gridColCondition.OptionsColumn.AllowSort = DevExpress.Utils.DefaultBoolean.False;
            this.gridColCondition.Visible = true;
            this.gridColCondition.VisibleIndex = 2;
            // 
            // gridColPLATINGSPEC
            // 
            this.gridColPLATINGSPEC.Caption = "PLATING SPEC";
            this.gridColPLATINGSPEC.FieldName = "PLATINGSPEC";
            this.gridColPLATINGSPEC.Name = "gridColPLATINGSPEC";
            this.gridColPLATINGSPEC.OptionsColumn.AllowSort = DevExpress.Utils.DefaultBoolean.False;
            this.gridColPLATINGSPEC.Visible = true;
            this.gridColPLATINGSPEC.VisibleIndex = 3;
            this.gridColPLATINGSPEC.Width = 125;
            // 
            // gridColTHICKNESS
            // 
            this.gridColTHICKNESS.Caption = "THICKNESS";
            this.gridColTHICKNESS.FieldName = "THICKNESS";
            this.gridColTHICKNESS.Name = "gridColTHICKNESS";
            this.gridColTHICKNESS.Visible = true;
            this.gridColTHICKNESS.VisibleIndex = 4;
            this.gridColTHICKNESS.Width = 107;
            // 
            // gridColTIME
            // 
            this.gridColTIME.Caption = "TIME";
            this.gridColTIME.DisplayFormat.FormatString = "n4";
            this.gridColTIME.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.gridColTIME.FieldName = "TIME";
            this.gridColTIME.Name = "gridColTIME";
            this.gridColTIME.OptionsColumn.AllowSort = DevExpress.Utils.DefaultBoolean.False;
            this.gridColTIME.Visible = true;
            this.gridColTIME.VisibleIndex = 5;
            // 
            // gridColAMPHRS
            // 
            this.gridColAMPHRS.Caption = "AMP HRS";
            this.gridColAMPHRS.FieldName = "AMPHRS";
            this.gridColAMPHRS.Name = "gridColAMPHRS";
            this.gridColAMPHRS.OptionsColumn.AllowSort = DevExpress.Utils.DefaultBoolean.False;
            this.gridColAMPHRS.Visible = true;
            this.gridColAMPHRS.VisibleIndex = 6;
            // 
            // gridColRemark
            // 
            this.gridColRemark.Caption = "Remark";
            this.gridColRemark.FieldName = "Remark";
            this.gridColRemark.Name = "gridColRemark";
            this.gridColRemark.OptionsColumn.AllowSort = DevExpress.Utils.DefaultBoolean.False;
            this.gridColRemark.Visible = true;
            this.gridColRemark.VisibleIndex = 7;
            this.gridColRemark.Width = 276;
            // 
            // gridColCreateUid
            // 
            this.gridColCreateUid.Caption = "Creater";
            this.gridColCreateUid.FieldName = "CreateUid";
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
            // 
            // gridColiState
            // 
            this.gridColiState.Caption = "iState";
            this.gridColiState.FieldName = "iState";
            this.gridColiState.Name = "gridColiState";
            this.gridColiState.OptionsColumn.AllowEdit = false;
            this.gridColiState.OptionsColumn.AllowSort = DevExpress.Utils.DefaultBoolean.False;
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
            // Process
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.menuStrip1);
            this.Name = "Process";
            this.Size = new System.Drawing.Size(945, 456);
            this.Load += new System.EventHandler(this.Frm_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).EndInit();
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
        private DevExpress.XtraGrid.Columns.GridColumn gridColProcessNo;
        private DevExpress.XtraGrid.Columns.GridColumn gridColProcess;
        private DevExpress.XtraGrid.Columns.GridColumn gridColCondition;
        private DevExpress.XtraGrid.Columns.GridColumn gridColPLATINGSPEC;
        private DevExpress.XtraGrid.Columns.GridColumn gridColTIME;
        private DevExpress.XtraGrid.Columns.GridColumn gridColAMPHRS;
        private DevExpress.XtraGrid.Columns.GridColumn gridColCreateUid;
        private DevExpress.XtraGrid.Columns.GridColumn gridColCreateDate;
        private DevExpress.XtraGrid.Columns.GridColumn gridColiID;
        private DevExpress.XtraGrid.Columns.GridColumn gridColRemark;
        private System.Windows.Forms.ToolStripMenuItem btnAddRow;
        private System.Windows.Forms.ToolStripMenuItem btnExport;
        private DevExpress.XtraGrid.Columns.GridColumn gridColiState;
        private DevExpress.XtraGrid.Columns.GridColumn gridColTHICKNESS;
    }
}
