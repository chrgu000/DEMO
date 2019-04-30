namespace UFIDA.U8.UAP.CustomApp.ControlForm
{
    partial class _CorrectiveAction
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
            this.gridView1 = new DevExpress.XtraGrid.Views.BandedGrid.BandedGridView();
            this.gridBand1 = new DevExpress.XtraGrid.Views.BandedGrid.GridBand();
            this.gridColiID = new DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn();
            this.gridColsStatus = new DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn();
            this.gridColsType = new DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn();
            this.ItemLookUpEditsType = new DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit();
            this.gridColBarcode = new DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn();
            this.gridColReportNo = new DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn();
            this.gridColDateofComplaint = new DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn();
            this.ItemDateEdit1 = new DevExpress.XtraEditors.Repository.RepositoryItemDateEdit();
            this.gridColcCusCode = new DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn();
            this.ItemLookUpEditcCusCode = new DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit();
            this.gridColcCusName = new DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn();
            this.ItemLookUpEditcCusName = new DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit();
            this.gridColcDepCode = new DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn();
            this.ItemLookUpEditcDepCode = new DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit();
            this.gridColcDepName = new DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn();
            this.ItemLookUpEditcDepName = new DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit();
            this.gridBand2 = new DevExpress.XtraGrid.Views.BandedGrid.GridBand();
            this.gridColDateIssued = new DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn();
            this.gridColDueDate = new DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn();
            this.gridColDateReplied = new DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn();
            this.gridBand3 = new DevExpress.XtraGrid.Views.BandedGrid.GridBand();
            this.gridColDateClosed = new DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn();
            this.gridColRemarks = new DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn();
            this.gridColComplaint = new DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn();
            this.gridColClaim = new DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn();
            this.panel1 = new System.Windows.Forms.Panel();
            this.ItemTextEditn2 = new DevExpress.XtraEditors.Repository.RepositoryItemTextEdit();
            this.menuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ItemLookUpEditsType)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ItemDateEdit1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ItemDateEdit1.VistaTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ItemLookUpEditcCusCode)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ItemLookUpEditcCusName)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ItemLookUpEditcDepCode)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ItemLookUpEditcDepName)).BeginInit();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ItemTextEditn2)).BeginInit();
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
            this.menuStrip1.Padding = new System.Windows.Forms.Padding(8, 2, 0, 2);
            this.menuStrip1.Size = new System.Drawing.Size(1389, 24);
            this.menuStrip1.TabIndex = 172;
            this.menuStrip1.Text = "menuStrip";
            // 
            // btnRefresh
            // 
            this.btnRefresh.BackColor = System.Drawing.SystemColors.Control;
            this.btnRefresh.Name = "btnRefresh";
            this.btnRefresh.Size = new System.Drawing.Size(75, 20);
            this.btnRefresh.Text = "Refresh";
            this.btnRefresh.Click += new System.EventHandler(this.btnRefresh_Click);
            // 
            // btnAddRow
            // 
            this.btnAddRow.Name = "btnAddRow";
            this.btnAddRow.Size = new System.Drawing.Size(75, 20);
            this.btnAddRow.Text = "Add Row";
            this.btnAddRow.Click += new System.EventHandler(this.btnAddRow_Click);
            // 
            // btnEdit
            // 
            this.btnEdit.Name = "btnEdit";
            this.btnEdit.Size = new System.Drawing.Size(51, 20);
            this.btnEdit.Text = "Edit";
            this.btnEdit.Click += new System.EventHandler(this.btnEdit_Click);
            // 
            // btnSave
            // 
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(51, 20);
            this.btnSave.Text = "Save";
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // btnDelete
            // 
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(67, 20);
            this.btnDelete.Text = "Delete";
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // btnExport
            // 
            this.btnExport.Name = "btnExport";
            this.btnExport.Size = new System.Drawing.Size(67, 20);
            this.btnExport.Text = "Export";
            this.btnExport.Click += new System.EventHandler(this.btnExport_Click);
            // 
            // gridControl1
            // 
            this.gridControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridControl1.EmbeddedNavigator.Margin = new System.Windows.Forms.Padding(4);
            this.gridControl1.Location = new System.Drawing.Point(0, 0);
            this.gridControl1.LookAndFeel.SkinName = "Office 2010 Blue";
            this.gridControl1.MainView = this.gridView1;
            this.gridControl1.Margin = new System.Windows.Forms.Padding(4);
            this.gridControl1.Name = "gridControl1";
            this.gridControl1.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.ItemLookUpEditcCusCode,
            this.ItemLookUpEditcCusName,
            this.ItemDateEdit1,
            this.ItemLookUpEditcDepName,
            this.ItemLookUpEditcDepCode,
            this.ItemLookUpEditsType,
            this.ItemTextEditn2});
            this.gridControl1.Size = new System.Drawing.Size(1389, 568);
            this.gridControl1.TabIndex = 191;
            this.gridControl1.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView1});
            // 
            // gridView1
            // 
            this.gridView1.Bands.AddRange(new DevExpress.XtraGrid.Views.BandedGrid.GridBand[] {
            this.gridBand1,
            this.gridBand2,
            this.gridBand3});
            this.gridView1.Columns.AddRange(new DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn[] {
            this.gridColiID,
            this.gridColsStatus,
            this.gridColsType,
            this.gridColBarcode,
            this.gridColReportNo,
            this.gridColDateofComplaint,
            this.gridColcCusCode,
            this.gridColcCusName,
            this.gridColcDepCode,
            this.gridColcDepName,
            this.gridColDateIssued,
            this.gridColDueDate,
            this.gridColDateReplied,
            this.gridColDateClosed,
            this.gridColRemarks,
            this.gridColComplaint,
            this.gridColClaim});
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
            // gridBand1
            // 
            this.gridBand1.Columns.Add(this.gridColiID);
            this.gridBand1.Columns.Add(this.gridColsStatus);
            this.gridBand1.Columns.Add(this.gridColsType);
            this.gridBand1.Columns.Add(this.gridColBarcode);
            this.gridBand1.Columns.Add(this.gridColReportNo);
            this.gridBand1.Columns.Add(this.gridColDateofComplaint);
            this.gridBand1.Columns.Add(this.gridColcCusCode);
            this.gridBand1.Columns.Add(this.gridColcCusName);
            this.gridBand1.Columns.Add(this.gridColcDepCode);
            this.gridBand1.Columns.Add(this.gridColcDepName);
            this.gridBand1.Name = "gridBand1";
            this.gridBand1.Width = 778;
            // 
            // gridColiID
            // 
            this.gridColiID.Caption = "iID";
            this.gridColiID.FieldName = "iID";
            this.gridColiID.Name = "gridColiID";
            this.gridColiID.OptionsColumn.AllowEdit = false;
            // 
            // gridColsStatus
            // 
            this.gridColsStatus.Caption = "sStatus";
            this.gridColsStatus.FieldName = "sStatus";
            this.gridColsStatus.Name = "gridColsStatus";
            this.gridColsStatus.OptionsColumn.AllowEdit = false;
            // 
            // gridColsType
            // 
            this.gridColsType.Caption = "Type";
            this.gridColsType.ColumnEdit = this.ItemLookUpEditsType;
            this.gridColsType.FieldName = "sType";
            this.gridColsType.Name = "gridColsType";
            this.gridColsType.Visible = true;
            this.gridColsType.Width = 78;
            // 
            // ItemLookUpEditsType
            // 
            this.ItemLookUpEditsType.AutoHeight = false;
            this.ItemLookUpEditsType.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.ItemLookUpEditsType.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("sType", "Type")});
            this.ItemLookUpEditsType.DisplayMember = "sType";
            this.ItemLookUpEditsType.Name = "ItemLookUpEditsType";
            this.ItemLookUpEditsType.NullText = "";
            this.ItemLookUpEditsType.ValueMember = "sType";
            // 
            // gridColBarcode
            // 
            this.gridColBarcode.Caption = "Barcode";
            this.gridColBarcode.FieldName = "Barcode";
            this.gridColBarcode.Name = "gridColBarcode";
            this.gridColBarcode.Visible = true;
            this.gridColBarcode.Width = 78;
            // 
            // gridColReportNo
            // 
            this.gridColReportNo.Caption = "Report No";
            this.gridColReportNo.FieldName = "ReportNo";
            this.gridColReportNo.Name = "gridColReportNo";
            this.gridColReportNo.Visible = true;
            this.gridColReportNo.Width = 96;
            // 
            // gridColDateofComplaint
            // 
            this.gridColDateofComplaint.Caption = "Date of Complaint";
            this.gridColDateofComplaint.ColumnEdit = this.ItemDateEdit1;
            this.gridColDateofComplaint.FieldName = "DateofComplaint";
            this.gridColDateofComplaint.Name = "gridColDateofComplaint";
            this.gridColDateofComplaint.Visible = true;
            this.gridColDateofComplaint.Width = 138;
            // 
            // ItemDateEdit1
            // 
            this.ItemDateEdit1.AutoHeight = false;
            this.ItemDateEdit1.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.ItemDateEdit1.Name = "ItemDateEdit1";
            this.ItemDateEdit1.VistaTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
            // 
            // gridColcCusCode
            // 
            this.gridColcCusCode.Caption = "Customer Code";
            this.gridColcCusCode.ColumnEdit = this.ItemLookUpEditcCusCode;
            this.gridColcCusCode.FieldName = "cCusCode";
            this.gridColcCusCode.Name = "gridColcCusCode";
            this.gridColcCusCode.Visible = true;
            this.gridColcCusCode.Width = 113;
            // 
            // ItemLookUpEditcCusCode
            // 
            this.ItemLookUpEditcCusCode.AutoHeight = false;
            this.ItemLookUpEditcCusCode.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.ItemLookUpEditcCusCode.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("cCusCode", "Customer Code"),
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("cCusName", 80, "Customer Name")});
            this.ItemLookUpEditcCusCode.DisplayMember = "cCusCode";
            this.ItemLookUpEditcCusCode.Name = "ItemLookUpEditcCusCode";
            this.ItemLookUpEditcCusCode.NullText = "";
            this.ItemLookUpEditcCusCode.PopupWidth = 400;
            this.ItemLookUpEditcCusCode.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.Standard;
            this.ItemLookUpEditcCusCode.ValueMember = "cCusCode";
            // 
            // gridColcCusName
            // 
            this.gridColcCusName.Caption = "Description";
            this.gridColcCusName.ColumnEdit = this.ItemLookUpEditcCusName;
            this.gridColcCusName.FieldName = "cCusCode";
            this.gridColcCusName.Name = "gridColcCusName";
            this.gridColcCusName.Visible = true;
            this.gridColcCusName.Width = 109;
            // 
            // ItemLookUpEditcCusName
            // 
            this.ItemLookUpEditcCusName.AutoHeight = false;
            this.ItemLookUpEditcCusName.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.ItemLookUpEditcCusName.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("cCusCode", "Customer Code"),
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("cCusName", 80, "Customer Name")});
            this.ItemLookUpEditcCusName.DisplayMember = "cCusName";
            this.ItemLookUpEditcCusName.Name = "ItemLookUpEditcCusName";
            this.ItemLookUpEditcCusName.NullText = "";
            this.ItemLookUpEditcCusName.PopupWidth = 400;
            this.ItemLookUpEditcCusName.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.Standard;
            this.ItemLookUpEditcCusName.ValueMember = "cCusCode";
            // 
            // gridColcDepCode
            // 
            this.gridColcDepCode.Caption = "Dept Code";
            this.gridColcDepCode.ColumnEdit = this.ItemLookUpEditcDepCode;
            this.gridColcDepCode.FieldName = "cDepCode";
            this.gridColcDepCode.Name = "gridColcDepCode";
            this.gridColcDepCode.Visible = true;
            this.gridColcDepCode.Width = 80;
            // 
            // ItemLookUpEditcDepCode
            // 
            this.ItemLookUpEditcDepCode.AutoHeight = false;
            this.ItemLookUpEditcDepCode.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.ItemLookUpEditcDepCode.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("cDepCode", "Dept Code"),
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("cDepName", 60, "Dept Name")});
            this.ItemLookUpEditcDepCode.DisplayMember = "cDepName";
            this.ItemLookUpEditcDepCode.Name = "ItemLookUpEditcDepCode";
            this.ItemLookUpEditcDepCode.NullText = "";
            this.ItemLookUpEditcDepCode.PopupWidth = 400;
            this.ItemLookUpEditcDepCode.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.Standard;
            this.ItemLookUpEditcDepCode.ValueMember = "cDepCode";
            // 
            // gridColcDepName
            // 
            this.gridColcDepName.Caption = "Dept Name";
            this.gridColcDepName.ColumnEdit = this.ItemLookUpEditcDepName;
            this.gridColcDepName.FieldName = "cDepCode";
            this.gridColcDepName.Name = "gridColcDepName";
            this.gridColcDepName.Visible = true;
            this.gridColcDepName.Width = 86;
            // 
            // ItemLookUpEditcDepName
            // 
            this.ItemLookUpEditcDepName.AutoHeight = false;
            this.ItemLookUpEditcDepName.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.ItemLookUpEditcDepName.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("cDepCode", "cDepCode"),
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("cDepName", 60, "cDepName")});
            this.ItemLookUpEditcDepName.DisplayMember = "cDepName";
            this.ItemLookUpEditcDepName.Name = "ItemLookUpEditcDepName";
            this.ItemLookUpEditcDepName.NullText = "";
            this.ItemLookUpEditcDepName.PopupWidth = 400;
            this.ItemLookUpEditcDepName.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.Standard;
            this.ItemLookUpEditcDepName.ValueMember = "cDepCode";
            // 
            // gridBand2
            // 
            this.gridBand2.AppearanceHeader.Options.UseTextOptions = true;
            this.gridBand2.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gridBand2.Caption = "Dept";
            this.gridBand2.Columns.Add(this.gridColDateIssued);
            this.gridBand2.Columns.Add(this.gridColDueDate);
            this.gridBand2.Columns.Add(this.gridColDateReplied);
            this.gridBand2.Name = "gridBand2";
            this.gridBand2.Width = 273;
            // 
            // gridColDateIssued
            // 
            this.gridColDateIssued.Caption = "Date  Issued";
            this.gridColDateIssued.ColumnEdit = this.ItemDateEdit1;
            this.gridColDateIssued.FieldName = "DateIssued";
            this.gridColDateIssued.Name = "gridColDateIssued";
            this.gridColDateIssued.Visible = true;
            this.gridColDateIssued.Width = 96;
            // 
            // gridColDueDate
            // 
            this.gridColDueDate.Caption = "Due Date";
            this.gridColDueDate.ColumnEdit = this.ItemDateEdit1;
            this.gridColDueDate.FieldName = "DueDate";
            this.gridColDueDate.Name = "gridColDueDate";
            this.gridColDueDate.Visible = true;
            // 
            // gridColDateReplied
            // 
            this.gridColDateReplied.Caption = "Date Replied";
            this.gridColDateReplied.ColumnEdit = this.ItemDateEdit1;
            this.gridColDateReplied.FieldName = "DateReplied";
            this.gridColDateReplied.Name = "gridColDateReplied";
            this.gridColDateReplied.Visible = true;
            this.gridColDateReplied.Width = 102;
            // 
            // gridBand3
            // 
            this.gridBand3.Columns.Add(this.gridColDateClosed);
            this.gridBand3.Columns.Add(this.gridColRemarks);
            this.gridBand3.Columns.Add(this.gridColComplaint);
            this.gridBand3.Columns.Add(this.gridColClaim);
            this.gridBand3.Name = "gridBand3";
            this.gridBand3.Width = 486;
            // 
            // gridColDateClosed
            // 
            this.gridColDateClosed.Caption = "Date Closed";
            this.gridColDateClosed.ColumnEdit = this.ItemDateEdit1;
            this.gridColDateClosed.FieldName = "DateClosed";
            this.gridColDateClosed.Name = "gridColDateClosed";
            this.gridColDateClosed.Visible = true;
            this.gridColDateClosed.Width = 115;
            // 
            // gridColRemarks
            // 
            this.gridColRemarks.Caption = "Remarks";
            this.gridColRemarks.FieldName = "Remarks";
            this.gridColRemarks.Name = "gridColRemarks";
            this.gridColRemarks.Visible = true;
            this.gridColRemarks.Width = 221;
            // 
            // gridColComplaint
            // 
            this.gridColComplaint.Caption = "Complaint";
            this.gridColComplaint.ColumnEdit = this.ItemTextEditn2;
            this.gridColComplaint.FieldName = "Complaint";
            this.gridColComplaint.Name = "gridColComplaint";
            this.gridColComplaint.Visible = true;
            // 
            // gridColClaim
            // 
            this.gridColClaim.Caption = "Claim";
            this.gridColClaim.ColumnEdit = this.ItemTextEditn2;
            this.gridColClaim.FieldName = "Claim";
            this.gridColClaim.Name = "gridColClaim";
            this.gridColClaim.Visible = true;
            // 
            // panel1
            // 
            this.panel1.AutoScroll = true;
            this.panel1.Controls.Add(this.gridControl1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 24);
            this.panel1.Margin = new System.Windows.Forms.Padding(4);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1389, 568);
            this.panel1.TabIndex = 173;
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
            // _CorrectiveAction
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.menuStrip1);
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "_CorrectiveAction";
            this.Size = new System.Drawing.Size(1389, 592);
            this.Load += new System.EventHandler(this.Frm_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ItemLookUpEditsType)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ItemDateEdit1.VistaTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ItemDateEdit1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ItemLookUpEditcCusCode)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ItemLookUpEditcCusName)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ItemLookUpEditcDepCode)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ItemLookUpEditcDepName)).EndInit();
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.ItemTextEditn2)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private DevExpress.XtraGrid.GridControl gridControl1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.ToolStripMenuItem btnRefresh;
        private System.Windows.Forms.ToolStripMenuItem btnExport;
        private System.Windows.Forms.ToolStripMenuItem btnEdit;
        private System.Windows.Forms.ToolStripMenuItem btnSave;
        private System.Windows.Forms.ToolStripMenuItem btnDelete;
        private DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit ItemLookUpEditcCusCode;
        private DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit ItemLookUpEditcCusName;
        private System.Windows.Forms.ToolStripMenuItem btnAddRow;
        private DevExpress.XtraGrid.Views.BandedGrid.BandedGridView gridView1;
        private DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn gridColiID;
        private DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn gridColsStatus;
        private DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn gridColsType;
        private DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn gridColBarcode;
        private DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn gridColReportNo;
        private DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn gridColDateofComplaint;
        private DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn gridColcCusCode;
        private DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn gridColcCusName;
        private DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn gridColcDepCode;
        private DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn gridColDateIssued;
        private DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn gridColDueDate;
        private DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn gridColDateReplied;
        private DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn gridColDateClosed;
        private DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn gridColRemarks;
        private DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn gridColComplaint;
        private DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn gridColClaim;
        private DevExpress.XtraEditors.Repository.RepositoryItemDateEdit ItemDateEdit1;
        private DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit ItemLookUpEditcDepName;
        private DevExpress.XtraGrid.Views.BandedGrid.GridBand gridBand1;
        private DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn gridColcDepName;
        private DevExpress.XtraGrid.Views.BandedGrid.GridBand gridBand2;
        private DevExpress.XtraGrid.Views.BandedGrid.GridBand gridBand3;
        private DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit ItemLookUpEditcDepCode;
        private DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit ItemLookUpEditsType;
        private DevExpress.XtraEditors.Repository.RepositoryItemTextEdit ItemTextEditn2;
    }
}
