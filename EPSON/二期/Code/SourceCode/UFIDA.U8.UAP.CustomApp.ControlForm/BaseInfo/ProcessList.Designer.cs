namespace UFIDA.U8.UAP.CustomApp.ControlForm
{
    partial class ProcessList
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
            this.btnDel = new System.Windows.Forms.ToolStripMenuItem();
            this.btnSave = new System.Windows.Forms.ToolStripMenuItem();
            this.btnExport = new System.Windows.Forms.ToolStripMenuItem();
            this.gridControl1 = new DevExpress.XtraGrid.GridControl();
            this.gridView1 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.gridColStatus = new DevExpress.XtraGrid.Columns.GridColumn();
            this.ItemLookUpEditActive = new DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit();
            this.gridColProcessCode = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColSeq = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColPlatingProcess = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColCondition = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColThichness = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColTime = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColDensity = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColAMP = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColUpdatedDate = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColUpdatedBy = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColiID = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColRemark = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColiState = new DevExpress.XtraGrid.Columns.GridColumn();
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnAddCopyRow = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ItemLookUpEditActive)).BeginInit();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btnRefresh,
            this.btnAddRow,
            this.btnDel,
            this.btnSave,
            this.btnExport,
            this.btnAddCopyRow});
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
            this.btnAddRow.Click += new System.EventHandler(this.btnAddRow_Click_1);
            // 
            // btnDel
            // 
            this.btnDel.Name = "btnDel";
            this.btnDel.Size = new System.Drawing.Size(86, 21);
            this.btnDel.Text = "Delete Row";
            this.btnDel.Click += new System.EventHandler(this.btnDel_Click);
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
            this.gridControl1.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.ItemLookUpEditActive});
            this.gridControl1.Size = new System.Drawing.Size(938, 423);
            this.gridControl1.TabIndex = 191;
            this.gridControl1.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView1});
            // 
            // gridView1
            // 
            this.gridView1.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.gridColStatus,
            this.gridColProcessCode,
            this.gridColSeq,
            this.gridColPlatingProcess,
            this.gridColCondition,
            this.gridColThichness,
            this.gridColTime,
            this.gridColDensity,
            this.gridColAMP,
            this.gridColUpdatedDate,
            this.gridColUpdatedBy,
            this.gridColiID,
            this.gridColRemark,
            this.gridColiState});
            this.gridView1.GridControl = this.gridControl1;
            this.gridView1.IndicatorWidth = 40;
            this.gridView1.Name = "gridView1";
            this.gridView1.OptionsBehavior.AllowDeleteRows = DevExpress.Utils.DefaultBoolean.True;
            this.gridView1.OptionsBehavior.EditorShowMode = DevExpress.Utils.EditorShowMode.MouseDown;
            this.gridView1.OptionsCustomization.AllowGroup = false;
            this.gridView1.OptionsCustomization.AllowQuickHideColumns = false;
            this.gridView1.OptionsCustomization.AllowSort = false;
            this.gridView1.OptionsNavigation.EnterMoveNextColumn = true;
            this.gridView1.OptionsPrint.AutoWidth = false;
            this.gridView1.OptionsView.ColumnAutoWidth = false;
            this.gridView1.OptionsView.ShowFooter = true;
            this.gridView1.OptionsView.ShowGroupPanel = false;
            this.gridView1.CustomDrawRowIndicator += new DevExpress.XtraGrid.Views.Grid.RowIndicatorCustomDrawEventHandler(this.gridView1_CustomDrawRowIndicator);
            this.gridView1.CellValueChanged += new DevExpress.XtraGrid.Views.Base.CellValueChangedEventHandler(this.gridView1_CellValueChanged);
            // 
            // gridColStatus
            // 
            this.gridColStatus.Caption = "Active";
            this.gridColStatus.ColumnEdit = this.ItemLookUpEditActive;
            this.gridColStatus.FieldName = "Status";
            this.gridColStatus.Name = "gridColStatus";
            this.gridColStatus.Visible = true;
            this.gridColStatus.VisibleIndex = 0;
            this.gridColStatus.Width = 85;
            // 
            // ItemLookUpEditActive
            // 
            this.ItemLookUpEditActive.AutoHeight = false;
            this.ItemLookUpEditActive.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.ItemLookUpEditActive.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("Active", "Active")});
            this.ItemLookUpEditActive.DisplayMember = "Active";
            this.ItemLookUpEditActive.Name = "ItemLookUpEditActive";
            this.ItemLookUpEditActive.NullText = "";
            this.ItemLookUpEditActive.ValueMember = "Active";
            // 
            // gridColProcessCode
            // 
            this.gridColProcessCode.Caption = "Process Code";
            this.gridColProcessCode.FieldName = "ProcessCode";
            this.gridColProcessCode.Name = "gridColProcessCode";
            this.gridColProcessCode.Visible = true;
            this.gridColProcessCode.VisibleIndex = 1;
            this.gridColProcessCode.Width = 98;
            // 
            // gridColSeq
            // 
            this.gridColSeq.Caption = "Seq";
            this.gridColSeq.FieldName = "Seq";
            this.gridColSeq.Name = "gridColSeq";
            this.gridColSeq.Visible = true;
            this.gridColSeq.VisibleIndex = 2;
            // 
            // gridColPlatingProcess
            // 
            this.gridColPlatingProcess.Caption = "Plating Process";
            this.gridColPlatingProcess.FieldName = "PlatingProcess";
            this.gridColPlatingProcess.Name = "gridColPlatingProcess";
            this.gridColPlatingProcess.Visible = true;
            this.gridColPlatingProcess.VisibleIndex = 3;
            this.gridColPlatingProcess.Width = 143;
            // 
            // gridColCondition
            // 
            this.gridColCondition.Caption = "Condition";
            this.gridColCondition.FieldName = "Condition";
            this.gridColCondition.Name = "gridColCondition";
            this.gridColCondition.Visible = true;
            this.gridColCondition.VisibleIndex = 4;
            this.gridColCondition.Width = 100;
            // 
            // gridColThichness
            // 
            this.gridColThichness.Caption = "Thickness";
            this.gridColThichness.FieldName = "Thichness";
            this.gridColThichness.Name = "gridColThichness";
            this.gridColThichness.Visible = true;
            this.gridColThichness.VisibleIndex = 5;
            this.gridColThichness.Width = 149;
            // 
            // gridColTime
            // 
            this.gridColTime.Caption = "Time";
            this.gridColTime.FieldName = "Time";
            this.gridColTime.Name = "gridColTime";
            this.gridColTime.Visible = true;
            this.gridColTime.VisibleIndex = 6;
            // 
            // gridColDensity
            // 
            this.gridColDensity.Caption = "Density";
            this.gridColDensity.FieldName = "Density";
            this.gridColDensity.Name = "gridColDensity";
            this.gridColDensity.Visible = true;
            this.gridColDensity.VisibleIndex = 7;
            // 
            // gridColAMP
            // 
            this.gridColAMP.Caption = "AMP";
            this.gridColAMP.FieldName = "AMP";
            this.gridColAMP.Name = "gridColAMP";
            this.gridColAMP.Visible = true;
            this.gridColAMP.VisibleIndex = 8;
            // 
            // gridColUpdatedDate
            // 
            this.gridColUpdatedDate.Caption = "Updated Date";
            this.gridColUpdatedDate.FieldName = "UpdateDate";
            this.gridColUpdatedDate.Name = "gridColUpdatedDate";
            this.gridColUpdatedDate.OptionsColumn.AllowEdit = false;
            this.gridColUpdatedDate.Visible = true;
            this.gridColUpdatedDate.VisibleIndex = 10;
            this.gridColUpdatedDate.Width = 101;
            // 
            // gridColUpdatedBy
            // 
            this.gridColUpdatedBy.Caption = "Updated By";
            this.gridColUpdatedBy.FieldName = "Updatedby";
            this.gridColUpdatedBy.Name = "gridColUpdatedBy";
            this.gridColUpdatedBy.OptionsColumn.AllowEdit = false;
            this.gridColUpdatedBy.Visible = true;
            this.gridColUpdatedBy.VisibleIndex = 11;
            this.gridColUpdatedBy.Width = 107;
            // 
            // gridColiID
            // 
            this.gridColiID.Caption = "iID";
            this.gridColiID.FieldName = "iID";
            this.gridColiID.Name = "gridColiID";
            this.gridColiID.OptionsColumn.AllowEdit = false;
            // 
            // gridColRemark
            // 
            this.gridColRemark.Caption = "Remark";
            this.gridColRemark.FieldName = "Remark";
            this.gridColRemark.Name = "gridColRemark";
            this.gridColRemark.OptionsColumn.AllowSort = DevExpress.Utils.DefaultBoolean.False;
            this.gridColRemark.Visible = true;
            this.gridColRemark.VisibleIndex = 9;
            this.gridColRemark.Width = 276;
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
            this.panel1.Size = new System.Drawing.Size(944, 431);
            this.panel1.TabIndex = 173;
            // 
            // btnAddCopyRow
            // 
            this.btnAddCopyRow.Name = "btnAddCopyRow";
            this.btnAddCopyRow.Size = new System.Drawing.Size(100, 21);
            this.btnAddCopyRow.Text = "Copy one line";
            this.btnAddCopyRow.Click += new System.EventHandler(this.btnAddCopyRow_Click);
            // 
            // ProcessList
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.menuStrip1);
            this.Name = "ProcessList";
            this.Size = new System.Drawing.Size(944, 456);
            this.Load += new System.EventHandler(this.Frm_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ItemLookUpEditActive)).EndInit();
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem btnSave;
        private DevExpress.XtraGrid.GridControl gridControl1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.ToolStripMenuItem btnRefresh;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView1;
        private DevExpress.XtraGrid.Columns.GridColumn gridColRemark;
        private System.Windows.Forms.ToolStripMenuItem btnExport;
        private DevExpress.XtraGrid.Columns.GridColumn gridColiState;
        private DevExpress.XtraGrid.Columns.GridColumn gridColStatus;
        private DevExpress.XtraGrid.Columns.GridColumn gridColProcessCode;
        private DevExpress.XtraGrid.Columns.GridColumn gridColSeq;
        private DevExpress.XtraGrid.Columns.GridColumn gridColPlatingProcess;
        private DevExpress.XtraGrid.Columns.GridColumn gridColCondition;
        private DevExpress.XtraGrid.Columns.GridColumn gridColThichness;
        private DevExpress.XtraGrid.Columns.GridColumn gridColTime;
        private DevExpress.XtraGrid.Columns.GridColumn gridColDensity;
        private DevExpress.XtraGrid.Columns.GridColumn gridColAMP;
        private DevExpress.XtraGrid.Columns.GridColumn gridColUpdatedDate;
        private DevExpress.XtraGrid.Columns.GridColumn gridColUpdatedBy;
        private DevExpress.XtraGrid.Columns.GridColumn gridColiID;
        private System.Windows.Forms.ToolStripMenuItem btnAddRow;
        private System.Windows.Forms.ToolStripMenuItem btnDel;
        private DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit ItemLookUpEditActive;
        private System.Windows.Forms.ToolStripMenuItem btnAddCopyRow;
    }
}
