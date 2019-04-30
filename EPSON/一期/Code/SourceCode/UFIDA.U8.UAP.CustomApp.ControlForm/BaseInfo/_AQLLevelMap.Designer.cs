namespace UFIDA.U8.UAP.CustomApp.ControlForm
{
    partial class _AQLLevelMap
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
            this.btnEdit = new System.Windows.Forms.ToolStripMenuItem();
            this.btnSave = new System.Windows.Forms.ToolStripMenuItem();
            this.btnDelete = new System.Windows.Forms.ToolStripMenuItem();
            this.btnExport = new System.Windows.Forms.ToolStripMenuItem();
            this.gridControl1 = new DevExpress.XtraGrid.GridControl();
            this.gridView1 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.gridColCodeLetter = new DevExpress.XtraGrid.Columns.GridColumn();
            this.ItemLookUpEditCodeLetter = new DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit();
            this.gridColAQLLevel = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColAccept = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColReject = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColsStatus = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColiID = new DevExpress.XtraGrid.Columns.GridColumn();
            this.panel1 = new System.Windows.Forms.Panel();
            this.ItemTextEditn0 = new DevExpress.XtraEditors.Repository.RepositoryItemTextEdit();
            this.menuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ItemLookUpEditCodeLetter)).BeginInit();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ItemTextEditn0)).BeginInit();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btnRefresh,
            this.btnAddRow,
            this.btnEdit,
            this.btnSave,
            this.btnDelete,
            this.btnExport});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Padding = new System.Windows.Forms.Padding(9, 2, 0, 2);
            this.menuStrip1.Size = new System.Drawing.Size(832, 26);
            this.menuStrip1.TabIndex = 172;
            this.menuStrip1.Text = "menuStrip";
            // 
            // btnRefresh
            // 
            this.btnRefresh.BackColor = System.Drawing.SystemColors.Control;
            this.btnRefresh.Name = "btnRefresh";
            this.btnRefresh.Size = new System.Drawing.Size(83, 22);
            this.btnRefresh.Text = "Refresh";
            this.btnRefresh.Click += new System.EventHandler(this.btnRefresh_Click);
            // 
            // btnAddRow
            // 
            this.btnAddRow.Name = "btnAddRow";
            this.btnAddRow.Size = new System.Drawing.Size(83, 22);
            this.btnAddRow.Text = "Add Row";
            this.btnAddRow.Click += new System.EventHandler(this.btnAddRow_Click_1);
            // 
            // btnEdit
            // 
            this.btnEdit.Name = "btnEdit";
            this.btnEdit.Size = new System.Drawing.Size(56, 22);
            this.btnEdit.Text = "Edit";
            this.btnEdit.Click += new System.EventHandler(this.btnEdit_Click);
            // 
            // btnSave
            // 
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(56, 22);
            this.btnSave.Text = "Save";
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // btnDelete
            // 
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(74, 22);
            this.btnDelete.Text = "Delete";
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // btnExport
            // 
            this.btnExport.Name = "btnExport";
            this.btnExport.Size = new System.Drawing.Size(74, 22);
            this.btnExport.Text = "Export";
            this.btnExport.Click += new System.EventHandler(this.btnExport_Click);
            // 
            // gridControl1
            // 
            this.gridControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridControl1.EmbeddedNavigator.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.gridControl1.Location = new System.Drawing.Point(0, 0);
            this.gridControl1.LookAndFeel.SkinName = "Office 2010 Blue";
            this.gridControl1.MainView = this.gridView1;
            this.gridControl1.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.gridControl1.Name = "gridControl1";
            this.gridControl1.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.ItemLookUpEditCodeLetter,
            this.ItemTextEditn0});
            this.gridControl1.Size = new System.Drawing.Size(832, 575);
            this.gridControl1.TabIndex = 191;
            this.gridControl1.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView1});
            // 
            // gridView1
            // 
            this.gridView1.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.gridColCodeLetter,
            this.gridColAQLLevel,
            this.gridColAccept,
            this.gridColReject,
            this.gridColsStatus,
            this.gridColiID});
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
            // gridColCodeLetter
            // 
            this.gridColCodeLetter.Caption = "Code Letter";
            this.gridColCodeLetter.ColumnEdit = this.ItemLookUpEditCodeLetter;
            this.gridColCodeLetter.FieldName = "CodeLetter";
            this.gridColCodeLetter.Name = "gridColCodeLetter";
            this.gridColCodeLetter.Visible = true;
            this.gridColCodeLetter.VisibleIndex = 0;
            this.gridColCodeLetter.Width = 137;
            // 
            // ItemLookUpEditCodeLetter
            // 
            this.ItemLookUpEditCodeLetter.AutoHeight = false;
            this.ItemLookUpEditCodeLetter.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.ItemLookUpEditCodeLetter.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("CodeLetter", "CodeLetter")});
            this.ItemLookUpEditCodeLetter.DisplayMember = "CodeLetter";
            this.ItemLookUpEditCodeLetter.Name = "ItemLookUpEditCodeLetter";
            this.ItemLookUpEditCodeLetter.NullText = "";
            this.ItemLookUpEditCodeLetter.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.Standard;
            this.ItemLookUpEditCodeLetter.ValueMember = "CodeLetter";
            // 
            // gridColAQLLevel
            // 
            this.gridColAQLLevel.Caption = "AQL Level";
            this.gridColAQLLevel.FieldName = "AQLLevel";
            this.gridColAQLLevel.Name = "gridColAQLLevel";
            this.gridColAQLLevel.Visible = true;
            this.gridColAQLLevel.VisibleIndex = 1;
            this.gridColAQLLevel.Width = 109;
            // 
            // gridColAccept
            // 
            this.gridColAccept.Caption = "Accept";
            this.gridColAccept.ColumnEdit = this.ItemTextEditn0;
            this.gridColAccept.FieldName = "Accept";
            this.gridColAccept.Name = "gridColAccept";
            this.gridColAccept.Visible = true;
            this.gridColAccept.VisibleIndex = 2;
            this.gridColAccept.Width = 116;
            // 
            // gridColReject
            // 
            this.gridColReject.Caption = "Reject";
            this.gridColReject.ColumnEdit = this.ItemTextEditn0;
            this.gridColReject.FieldName = "Reject";
            this.gridColReject.Name = "gridColReject";
            this.gridColReject.Visible = true;
            this.gridColReject.VisibleIndex = 3;
            this.gridColReject.Width = 125;
            // 
            // gridColsStatus
            // 
            this.gridColsStatus.Caption = "sStatus";
            this.gridColsStatus.FieldName = "sStatus";
            this.gridColsStatus.Name = "gridColsStatus";
            this.gridColsStatus.OptionsColumn.AllowEdit = false;
            // 
            // gridColiID
            // 
            this.gridColiID.Caption = "iID";
            this.gridColiID.FieldName = "iID";
            this.gridColiID.Name = "gridColiID";
            this.gridColiID.OptionsColumn.AllowEdit = false;
            // 
            // panel1
            // 
            this.panel1.AutoScroll = true;
            this.panel1.Controls.Add(this.gridControl1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 26);
            this.panel1.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(832, 575);
            this.panel1.TabIndex = 173;
            // 
            // ItemTextEditn0
            // 
            this.ItemTextEditn0.AutoHeight = false;
            this.ItemTextEditn0.DisplayFormat.FormatString = "n0";
            this.ItemTextEditn0.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.ItemTextEditn0.EditFormat.FormatString = "n0";
            this.ItemTextEditn0.EditFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.ItemTextEditn0.Mask.EditMask = "n0";
            this.ItemTextEditn0.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Numeric;
            this.ItemTextEditn0.Name = "ItemTextEditn0";
            // 
            // _AQLLevelMap
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 18F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.menuStrip1);
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "_AQLLevelMap";
            this.Size = new System.Drawing.Size(832, 601);
            this.Load += new System.EventHandler(this.Frm_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ItemLookUpEditCodeLetter)).EndInit();
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.ItemTextEditn0)).EndInit();
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
        private DevExpress.XtraGrid.Columns.GridColumn gridColAQLLevel;
        private System.Windows.Forms.ToolStripMenuItem btnEdit;
        private System.Windows.Forms.ToolStripMenuItem btnSave;
        private System.Windows.Forms.ToolStripMenuItem btnDelete;
        private DevExpress.XtraGrid.Columns.GridColumn gridColiID;
        private DevExpress.XtraGrid.Columns.GridColumn gridColsStatus;
        private System.Windows.Forms.ToolStripMenuItem btnAddRow;
        private DevExpress.XtraGrid.Columns.GridColumn gridColCodeLetter;
        private DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit ItemLookUpEditCodeLetter;
        private DevExpress.XtraGrid.Columns.GridColumn gridColAccept;
        private DevExpress.XtraGrid.Columns.GridColumn gridColReject;
        private DevExpress.XtraEditors.Repository.RepositoryItemTextEdit ItemTextEditn0;
    }
}
