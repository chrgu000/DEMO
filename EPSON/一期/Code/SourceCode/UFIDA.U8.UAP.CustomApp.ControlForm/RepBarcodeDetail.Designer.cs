namespace UFIDA.U8.UAP.CustomApp.ControlForm
{
    partial class RepBarcodeDetail
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
            this.gridColCUSTOMER = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColCustomerID = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColPARTCODE = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColPLATING = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColProcess = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColDepartment = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColLabelNumber = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColQuantity = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColReceiveDate = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColDueDate = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColDateStart = new DevExpress.XtraGrid.Columns.GridColumn();
            this.ItemDateEdit1 = new DevExpress.XtraEditors.Repository.RepositoryItemDateEdit();
            this.gridColDateEnd = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColOFFPH = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColTAT = new DevExpress.XtraGrid.Columns.GridColumn();
            this.panel1 = new System.Windows.Forms.Panel();
            this.dateEdit2 = new DevExpress.XtraEditors.DateEdit();
            this.dateEdit1 = new DevExpress.XtraEditors.DateEdit();
            this.radioPreview = new System.Windows.Forms.RadioButton();
            this.radioPrint = new System.Windows.Forms.RadioButton();
            this.label1 = new System.Windows.Forms.Label();
            this.lookUpEditPrinter = new DevExpress.XtraEditors.LookUpEdit();
            this.label5 = new System.Windows.Forms.Label();
            this.ItemLookUpEditDept = new DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit();
            this.menuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ItemDateEdit1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ItemDateEdit1.VistaTimeProperties)).BeginInit();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dateEdit2.Properties.VistaTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dateEdit2.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dateEdit1.Properties.VistaTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dateEdit1.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lookUpEditPrinter.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ItemLookUpEditDept)).BeginInit();
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
            this.btnPrintSet.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnPrintSet.Click += new System.EventHandler(this.btnPrintSet_Click);
            // 
            // gridControl1
            // 
            this.gridControl1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.gridControl1.EmbeddedNavigator.Margin = new System.Windows.Forms.Padding(4);
            this.gridControl1.Location = new System.Drawing.Point(4, 80);
            this.gridControl1.LookAndFeel.SkinName = "Office 2010 Blue";
            this.gridControl1.MainView = this.gridView1;
            this.gridControl1.Margin = new System.Windows.Forms.Padding(4);
            this.gridControl1.Name = "gridControl1";
            this.gridControl1.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.ItemDateEdit1,
            this.ItemLookUpEditDept});
            this.gridControl1.Size = new System.Drawing.Size(1433, 455);
            this.gridControl1.TabIndex = 191;
            this.gridControl1.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView1});
            // 
            // gridView1
            // 
            this.gridView1.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.gridColCUSTOMER,
            this.gridColCustomerID,
            this.gridColPARTCODE,
            this.gridColPLATING,
            this.gridColProcess,
            this.gridColDepartment,
            this.gridColLabelNumber,
            this.gridColQuantity,
            this.gridColReceiveDate,
            this.gridColDueDate,
            this.gridColDateStart,
            this.gridColDateEnd,
            this.gridColOFFPH,
            this.gridColTAT});
            this.gridView1.GridControl = this.gridControl1;
            this.gridView1.IndicatorWidth = 40;
            this.gridView1.Name = "gridView1";
            this.gridView1.OptionsBehavior.AllowDeleteRows = DevExpress.Utils.DefaultBoolean.True;
            this.gridView1.OptionsBehavior.EditorShowMode = DevExpress.Utils.EditorShowMode.MouseDown;
            this.gridView1.OptionsCustomization.AllowQuickHideColumns = false;
            this.gridView1.OptionsNavigation.EnterMoveNextColumn = true;
            this.gridView1.OptionsPrint.AutoWidth = false;
            this.gridView1.OptionsView.ColumnAutoWidth = false;
            this.gridView1.OptionsView.ShowFooter = true;
            this.gridView1.OptionsView.ShowGroupPanel = false;
            this.gridView1.CustomDrawRowIndicator += new DevExpress.XtraGrid.Views.Grid.RowIndicatorCustomDrawEventHandler(this.gridView1_CustomDrawRowIndicator);
            // 
            // gridColCUSTOMER
            // 
            this.gridColCUSTOMER.Caption = "CUSTOMER";
            this.gridColCUSTOMER.FieldName = "CUSTOMER";
            this.gridColCUSTOMER.Name = "gridColCUSTOMER";
            this.gridColCUSTOMER.OptionsColumn.AllowEdit = false;
            this.gridColCUSTOMER.OptionsColumn.AllowGroup = DevExpress.Utils.DefaultBoolean.True;
            this.gridColCUSTOMER.Visible = true;
            this.gridColCUSTOMER.VisibleIndex = 0;
            this.gridColCUSTOMER.Width = 120;
            // 
            // gridColCustomerID
            // 
            this.gridColCustomerID.Caption = "Customer ID";
            this.gridColCustomerID.FieldName = "CustomerID";
            this.gridColCustomerID.Name = "gridColCustomerID";
            this.gridColCustomerID.OptionsColumn.AllowEdit = false;
            this.gridColCustomerID.OptionsColumn.AllowGroup = DevExpress.Utils.DefaultBoolean.True;
            this.gridColCustomerID.Visible = true;
            this.gridColCustomerID.VisibleIndex = 1;
            // 
            // gridColPARTCODE
            // 
            this.gridColPARTCODE.Caption = "PART CODE";
            this.gridColPARTCODE.FieldName = "PARTCODE";
            this.gridColPARTCODE.Name = "gridColPARTCODE";
            this.gridColPARTCODE.OptionsColumn.AllowEdit = false;
            this.gridColPARTCODE.OptionsColumn.AllowGroup = DevExpress.Utils.DefaultBoolean.True;
            this.gridColPARTCODE.Visible = true;
            this.gridColPARTCODE.VisibleIndex = 2;
            this.gridColPARTCODE.Width = 126;
            // 
            // gridColPLATING
            // 
            this.gridColPLATING.Caption = "PLATING";
            this.gridColPLATING.FieldName = "PLATING";
            this.gridColPLATING.Name = "gridColPLATING";
            this.gridColPLATING.OptionsColumn.AllowEdit = false;
            this.gridColPLATING.OptionsColumn.AllowGroup = DevExpress.Utils.DefaultBoolean.True;
            this.gridColPLATING.Visible = true;
            this.gridColPLATING.VisibleIndex = 3;
            this.gridColPLATING.Width = 83;
            // 
            // gridColProcess
            // 
            this.gridColProcess.Caption = "Process";
            this.gridColProcess.FieldName = "Process";
            this.gridColProcess.Name = "gridColProcess";
            this.gridColProcess.OptionsColumn.AllowEdit = false;
            this.gridColProcess.OptionsColumn.AllowGroup = DevExpress.Utils.DefaultBoolean.True;
            this.gridColProcess.Visible = true;
            this.gridColProcess.VisibleIndex = 4;
            this.gridColProcess.Width = 104;
            // 
            // gridColDepartment
            // 
            this.gridColDepartment.Caption = "DEPARTMENT";
            this.gridColDepartment.ColumnEdit = this.ItemLookUpEditDept;
            this.gridColDepartment.FieldName = "Department";
            this.gridColDepartment.Name = "gridColDepartment";
            this.gridColDepartment.OptionsColumn.AllowEdit = false;
            this.gridColDepartment.OptionsColumn.AllowGroup = DevExpress.Utils.DefaultBoolean.True;
            this.gridColDepartment.Visible = true;
            this.gridColDepartment.VisibleIndex = 5;
            this.gridColDepartment.Width = 152;
            // 
            // gridColLabelNumber
            // 
            this.gridColLabelNumber.Caption = "Label Number";
            this.gridColLabelNumber.FieldName = "LabelNumber";
            this.gridColLabelNumber.Name = "gridColLabelNumber";
            this.gridColLabelNumber.OptionsColumn.AllowEdit = false;
            this.gridColLabelNumber.OptionsColumn.AllowGroup = DevExpress.Utils.DefaultBoolean.True;
            this.gridColLabelNumber.Visible = true;
            this.gridColLabelNumber.VisibleIndex = 6;
            this.gridColLabelNumber.Width = 109;
            // 
            // gridColQuantity
            // 
            this.gridColQuantity.Caption = "QUANTITY";
            this.gridColQuantity.FieldName = "Quantity";
            this.gridColQuantity.Name = "gridColQuantity";
            this.gridColQuantity.OptionsColumn.AllowEdit = false;
            this.gridColQuantity.OptionsColumn.AllowGroup = DevExpress.Utils.DefaultBoolean.True;
            this.gridColQuantity.Visible = true;
            this.gridColQuantity.VisibleIndex = 7;
            // 
            // gridColReceiveDate
            // 
            this.gridColReceiveDate.Caption = "Receive Date";
            this.gridColReceiveDate.FieldName = "ReceiveDate";
            this.gridColReceiveDate.Name = "gridColReceiveDate";
            this.gridColReceiveDate.OptionsColumn.AllowEdit = false;
            this.gridColReceiveDate.OptionsColumn.AllowGroup = DevExpress.Utils.DefaultBoolean.True;
            this.gridColReceiveDate.Visible = true;
            this.gridColReceiveDate.VisibleIndex = 8;
            this.gridColReceiveDate.Width = 150;
            // 
            // gridColDueDate
            // 
            this.gridColDueDate.Caption = "Due Date";
            this.gridColDueDate.FieldName = "DueDate";
            this.gridColDueDate.Name = "gridColDueDate";
            this.gridColDueDate.OptionsColumn.AllowEdit = false;
            this.gridColDueDate.OptionsColumn.AllowGroup = DevExpress.Utils.DefaultBoolean.True;
            this.gridColDueDate.Visible = true;
            this.gridColDueDate.VisibleIndex = 9;
            this.gridColDueDate.Width = 142;
            // 
            // gridColDateStart
            // 
            this.gridColDateStart.Caption = "Date Start";
            this.gridColDateStart.ColumnEdit = this.ItemDateEdit1;
            this.gridColDateStart.FieldName = "DateStart";
            this.gridColDateStart.Name = "gridColDateStart";
            this.gridColDateStart.OptionsColumn.AllowEdit = false;
            this.gridColDateStart.OptionsColumn.AllowGroup = DevExpress.Utils.DefaultBoolean.True;
            this.gridColDateStart.Visible = true;
            this.gridColDateStart.VisibleIndex = 10;
            this.gridColDateStart.Width = 101;
            // 
            // ItemDateEdit1
            // 
            this.ItemDateEdit1.AutoHeight = false;
            this.ItemDateEdit1.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.ItemDateEdit1.DisplayFormat.FormatString = "g";
            this.ItemDateEdit1.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.ItemDateEdit1.EditFormat.FormatString = "g";
            this.ItemDateEdit1.EditFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.ItemDateEdit1.Mask.EditMask = "g";
            this.ItemDateEdit1.Name = "ItemDateEdit1";
            this.ItemDateEdit1.VistaTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
            // 
            // gridColDateEnd
            // 
            this.gridColDateEnd.Caption = "Date End";
            this.gridColDateEnd.ColumnEdit = this.ItemDateEdit1;
            this.gridColDateEnd.FieldName = "DateEnd";
            this.gridColDateEnd.Name = "gridColDateEnd";
            this.gridColDateEnd.OptionsColumn.AllowEdit = false;
            this.gridColDateEnd.OptionsColumn.AllowGroup = DevExpress.Utils.DefaultBoolean.True;
            this.gridColDateEnd.Visible = true;
            this.gridColDateEnd.VisibleIndex = 11;
            // 
            // gridColOFFPH
            // 
            this.gridColOFFPH.Caption = "TOTAL OFF/PH";
            this.gridColOFFPH.DisplayFormat.FormatString = "n5";
            this.gridColOFFPH.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.gridColOFFPH.FieldName = "OFFPH";
            this.gridColOFFPH.Name = "gridColOFFPH";
            this.gridColOFFPH.OptionsColumn.AllowEdit = false;
            this.gridColOFFPH.OptionsColumn.AllowGroup = DevExpress.Utils.DefaultBoolean.True;
            this.gridColOFFPH.Summary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] {
            new DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum)});
            this.gridColOFFPH.Visible = true;
            this.gridColOFFPH.VisibleIndex = 12;
            this.gridColOFFPH.Width = 141;
            // 
            // gridColTAT
            // 
            this.gridColTAT.Caption = "TOTAL TIME";
            this.gridColTAT.DisplayFormat.FormatString = "n5";
            this.gridColTAT.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.gridColTAT.FieldName = "TAT";
            this.gridColTAT.Name = "gridColTAT";
            this.gridColTAT.OptionsColumn.AllowEdit = false;
            this.gridColTAT.OptionsColumn.AllowGroup = DevExpress.Utils.DefaultBoolean.True;
            this.gridColTAT.Summary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] {
            new DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum)});
            this.gridColTAT.Visible = true;
            this.gridColTAT.VisibleIndex = 13;
            // 
            // panel1
            // 
            this.panel1.AutoScroll = true;
            this.panel1.Controls.Add(this.dateEdit2);
            this.panel1.Controls.Add(this.dateEdit1);
            this.panel1.Controls.Add(this.radioPreview);
            this.panel1.Controls.Add(this.radioPrint);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.lookUpEditPrinter);
            this.panel1.Controls.Add(this.label5);
            this.panel1.Controls.Add(this.gridControl1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 28);
            this.panel1.Margin = new System.Windows.Forms.Padding(4);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1441, 541);
            this.panel1.TabIndex = 173;
            // 
            // dateEdit2
            // 
            this.dateEdit2.EditValue = null;
            this.dateEdit2.Location = new System.Drawing.Point(321, 14);
            this.dateEdit2.Margin = new System.Windows.Forms.Padding(4);
            this.dateEdit2.Name = "dateEdit2";
            this.dateEdit2.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.dateEdit2.Properties.VistaTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
            this.dateEdit2.Size = new System.Drawing.Size(188, 24);
            this.dateEdit2.TabIndex = 233;
            // 
            // dateEdit1
            // 
            this.dateEdit1.EditValue = null;
            this.dateEdit1.Location = new System.Drawing.Point(121, 14);
            this.dateEdit1.Margin = new System.Windows.Forms.Padding(4);
            this.dateEdit1.Name = "dateEdit1";
            this.dateEdit1.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.dateEdit1.Properties.VistaTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
            this.dateEdit1.Size = new System.Drawing.Size(188, 24);
            this.dateEdit1.TabIndex = 232;
            // 
            // radioPreview
            // 
            this.radioPreview.AutoSize = true;
            this.radioPreview.Location = new System.Drawing.Point(757, 52);
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
            this.radioPrint.Location = new System.Drawing.Point(576, 52);
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
            this.label1.Location = new System.Drawing.Point(563, 20);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(63, 15);
            this.label1.TabIndex = 229;
            this.label1.Text = "Printer";
            // 
            // lookUpEditPrinter
            // 
            this.lookUpEditPrinter.Location = new System.Drawing.Point(648, 15);
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
            this.label5.Location = new System.Drawing.Point(52, 19);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(39, 15);
            this.label5.TabIndex = 226;
            this.label5.Text = "Date";
            // 
            // ItemLookUpEditDept
            // 
            this.ItemLookUpEditDept.AutoHeight = false;
            this.ItemLookUpEditDept.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.ItemLookUpEditDept.DisplayMember = "cDepName";
            this.ItemLookUpEditDept.Name = "ItemLookUpEditDept";
            this.ItemLookUpEditDept.NullText = "";
            this.ItemLookUpEditDept.ValueMember = "cDepCode";
            // 
            // RepBarcodeDetail
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.menuStrip1);
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "RepBarcodeDetail";
            this.Size = new System.Drawing.Size(1441, 569);
            this.Load += new System.EventHandler(this.Frm_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ItemDateEdit1.VistaTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ItemDateEdit1)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dateEdit2.Properties.VistaTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dateEdit2.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dateEdit1.Properties.VistaTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dateEdit1.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lookUpEditPrinter.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ItemLookUpEditDept)).EndInit();
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
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label1;
        private DevExpress.XtraEditors.LookUpEdit lookUpEditPrinter;
        private System.Windows.Forms.RadioButton radioPreview;
        private System.Windows.Forms.RadioButton radioPrint;
        private DevExpress.XtraEditors.DateEdit dateEdit2;
        private DevExpress.XtraEditors.DateEdit dateEdit1;
        private System.Windows.Forms.ToolStripMenuItem btnQuery;
        private DevExpress.XtraGrid.Columns.GridColumn gridColDepartment;
        private DevExpress.XtraGrid.Columns.GridColumn gridColCUSTOMER;
        private DevExpress.XtraGrid.Columns.GridColumn gridColPARTCODE;
        private DevExpress.XtraGrid.Columns.GridColumn gridColCustomerID;
        private DevExpress.XtraGrid.Columns.GridColumn gridColPLATING;
        private DevExpress.XtraGrid.Columns.GridColumn gridColProcess;
        private DevExpress.XtraGrid.Columns.GridColumn gridColLabelNumber;
        private DevExpress.XtraGrid.Columns.GridColumn gridColQuantity;
        private DevExpress.XtraGrid.Columns.GridColumn gridColReceiveDate;
        private DevExpress.XtraGrid.Columns.GridColumn gridColDueDate;
        private DevExpress.XtraGrid.Columns.GridColumn gridColDateStart;
        private DevExpress.XtraGrid.Columns.GridColumn gridColDateEnd;
        private DevExpress.XtraGrid.Columns.GridColumn gridColOFFPH;
        private DevExpress.XtraGrid.Columns.GridColumn gridColTAT;
        private DevExpress.XtraEditors.Repository.RepositoryItemDateEdit ItemDateEdit1;
        private DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit ItemLookUpEditDept;
    }
}
