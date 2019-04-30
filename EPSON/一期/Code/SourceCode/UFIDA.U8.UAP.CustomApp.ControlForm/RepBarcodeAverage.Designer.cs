namespace UFIDA.U8.UAP.CustomApp.ControlForm
{
    partial class RepBarcodeAverage
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
            this.gridColDEPARTMENT = new DevExpress.XtraGrid.Columns.GridColumn();
            this.ItemLookUpEditDept = new DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit();
            this.gridColCUSTOMER = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColPARTCODE = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColTOTALOFFPH = new DevExpress.XtraGrid.Columns.GridColumn();
            this.ItemTextEditn5 = new DevExpress.XtraEditors.Repository.RepositoryItemTextEdit();
            this.gridColTOTALTIME = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColDepCode = new DevExpress.XtraGrid.Columns.GridColumn();
            this.panel1 = new System.Windows.Forms.Panel();
            this.dateEdit2 = new DevExpress.XtraEditors.DateEdit();
            this.dateEdit1 = new DevExpress.XtraEditors.DateEdit();
            this.radioPreview = new System.Windows.Forms.RadioButton();
            this.radioPrint = new System.Windows.Forms.RadioButton();
            this.label1 = new System.Windows.Forms.Label();
            this.lookUpEditPrinter = new DevExpress.XtraEditors.LookUpEdit();
            this.label5 = new System.Windows.Forms.Label();
            this.gridColcCusCode = new DevExpress.XtraGrid.Columns.GridColumn();
            this.menuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ItemLookUpEditDept)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ItemTextEditn5)).BeginInit();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dateEdit2.Properties.VistaTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dateEdit2.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dateEdit1.Properties.VistaTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dateEdit1.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lookUpEditPrinter.Properties)).BeginInit();
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
            this.ItemTextEditn5,
            this.ItemLookUpEditDept});
            this.gridControl1.Size = new System.Drawing.Size(1433, 455);
            this.gridControl1.TabIndex = 191;
            this.gridControl1.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView1});
            // 
            // gridView1
            // 
            this.gridView1.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.gridColDEPARTMENT,
            this.gridColCUSTOMER,
            this.gridColPARTCODE,
            this.gridColTOTALOFFPH,
            this.gridColTOTALTIME,
            this.gridColDepCode,
            this.gridColcCusCode});
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
            // gridColDEPARTMENT
            // 
            this.gridColDEPARTMENT.Caption = "DEPARTMENT";
            this.gridColDEPARTMENT.ColumnEdit = this.ItemLookUpEditDept;
            this.gridColDEPARTMENT.FieldName = "Department";
            this.gridColDEPARTMENT.Name = "gridColDEPARTMENT";
            this.gridColDEPARTMENT.OptionsColumn.AllowEdit = false;
            this.gridColDEPARTMENT.Visible = true;
            this.gridColDEPARTMENT.VisibleIndex = 1;
            this.gridColDEPARTMENT.Width = 152;
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
            // gridColCUSTOMER
            // 
            this.gridColCUSTOMER.Caption = "CUSTOMER";
            this.gridColCUSTOMER.FieldName = "CUSTOMER";
            this.gridColCUSTOMER.Name = "gridColCUSTOMER";
            this.gridColCUSTOMER.OptionsColumn.AllowEdit = false;
            this.gridColCUSTOMER.Visible = true;
            this.gridColCUSTOMER.VisibleIndex = 3;
            this.gridColCUSTOMER.Width = 120;
            // 
            // gridColPARTCODE
            // 
            this.gridColPARTCODE.Caption = "PART CODE";
            this.gridColPARTCODE.FieldName = "PARTCODE";
            this.gridColPARTCODE.Name = "gridColPARTCODE";
            this.gridColPARTCODE.OptionsColumn.AllowEdit = false;
            this.gridColPARTCODE.Visible = true;
            this.gridColPARTCODE.VisibleIndex = 4;
            this.gridColPARTCODE.Width = 126;
            // 
            // gridColTOTALOFFPH
            // 
            this.gridColTOTALOFFPH.Caption = "TOTAL OFF/PH";
            this.gridColTOTALOFFPH.ColumnEdit = this.ItemTextEditn5;
            this.gridColTOTALOFFPH.FieldName = "TOTALOFFPH";
            this.gridColTOTALOFFPH.Name = "gridColTOTALOFFPH";
            this.gridColTOTALOFFPH.OptionsColumn.AllowEdit = false;
            this.gridColTOTALOFFPH.Summary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] {
            new DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum)});
            this.gridColTOTALOFFPH.Visible = true;
            this.gridColTOTALOFFPH.VisibleIndex = 5;
            this.gridColTOTALOFFPH.Width = 128;
            // 
            // ItemTextEditn5
            // 
            this.ItemTextEditn5.AutoHeight = false;
            this.ItemTextEditn5.DisplayFormat.FormatString = "n5";
            this.ItemTextEditn5.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.ItemTextEditn5.EditFormat.FormatString = "n5";
            this.ItemTextEditn5.EditFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.ItemTextEditn5.Mask.EditMask = "n5";
            this.ItemTextEditn5.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Numeric;
            this.ItemTextEditn5.Name = "ItemTextEditn5";
            // 
            // gridColTOTALTIME
            // 
            this.gridColTOTALTIME.Caption = "TOTAL TIME";
            this.gridColTOTALTIME.ColumnEdit = this.ItemTextEditn5;
            this.gridColTOTALTIME.FieldName = "TOTALTIME";
            this.gridColTOTALTIME.Name = "gridColTOTALTIME";
            this.gridColTOTALTIME.OptionsColumn.AllowEdit = false;
            this.gridColTOTALTIME.Summary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] {
            new DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum)});
            this.gridColTOTALTIME.Visible = true;
            this.gridColTOTALTIME.VisibleIndex = 6;
            this.gridColTOTALTIME.Width = 169;
            // 
            // gridColDepCode
            // 
            this.gridColDepCode.Caption = "Deptno";
            this.gridColDepCode.FieldName = "Department";
            this.gridColDepCode.Name = "gridColDepCode";
            this.gridColDepCode.OptionsColumn.AllowEdit = false;
            this.gridColDepCode.Visible = true;
            this.gridColDepCode.VisibleIndex = 0;
            this.gridColDepCode.Width = 127;
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
            // gridColcCusCode
            // 
            this.gridColcCusCode.Caption = "Customer Code";
            this.gridColcCusCode.FieldName = "cCusCode";
            this.gridColcCusCode.Name = "gridColcCusCode";
            this.gridColcCusCode.OptionsColumn.AllowEdit = false;
            this.gridColcCusCode.Visible = true;
            this.gridColcCusCode.VisibleIndex = 2;
            this.gridColcCusCode.Width = 125;
            // 
            // RepBarcodeAverage
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.menuStrip1);
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "RepBarcodeAverage";
            this.Size = new System.Drawing.Size(1441, 569);
            this.Load += new System.EventHandler(this.Frm_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ItemLookUpEditDept)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ItemTextEditn5)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dateEdit2.Properties.VistaTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dateEdit2.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dateEdit1.Properties.VistaTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dateEdit1.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lookUpEditPrinter.Properties)).EndInit();
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
        private DevExpress.XtraGrid.Columns.GridColumn gridColDEPARTMENT;
        private DevExpress.XtraGrid.Columns.GridColumn gridColCUSTOMER;
        private DevExpress.XtraGrid.Columns.GridColumn gridColPARTCODE;
        private DevExpress.XtraGrid.Columns.GridColumn gridColTOTALOFFPH;
        private DevExpress.XtraGrid.Columns.GridColumn gridColTOTALTIME;
        private DevExpress.XtraEditors.Repository.RepositoryItemTextEdit ItemTextEditn5;
        private DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit ItemLookUpEditDept;
        private DevExpress.XtraGrid.Columns.GridColumn gridColDepCode;
        private DevExpress.XtraGrid.Columns.GridColumn gridColcCusCode;
    }
}
