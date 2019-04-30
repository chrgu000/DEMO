namespace UFIDA.U8.UAP.CustomApp.ControlForm
{
    partial class RepForm
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
            this.btnExport = new System.Windows.Forms.ToolStripMenuItem();
            this.gridControl1 = new DevExpress.XtraGrid.GridControl();
            this.gridView1 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.gridColUPC = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColDescription = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColDescription2 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColQty = new DevExpress.XtraGrid.Columns.GridColumn();
            this.ItemTextEditnumber = new DevExpress.XtraEditors.Repository.RepositoryItemTextEdit();
            this.gridColCSEConv0 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColCases = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColEUConv = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColEUs = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColGSWOTaxRMB = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColGSWOTaxUSD = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColStandardCost = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColAllocateDutyCIQ = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColTotStdCostRMB = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColTotStdCostUSD = new DevExpress.XtraGrid.Columns.GridColumn();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label7 = new System.Windows.Forms.Label();
            this.txtExchangeRate = new DevExpress.XtraEditors.TextEdit();
            this.label6 = new System.Windows.Forms.Label();
            this.txtStdCost = new DevExpress.XtraEditors.TextEdit();
            this.label5 = new System.Windows.Forms.Label();
            this.txtTotal = new DevExpress.XtraEditors.TextEdit();
            this.label4 = new System.Windows.Forms.Label();
            this.txtDuty = new DevExpress.XtraEditors.TextEdit();
            this.label3 = new System.Windows.Forms.Label();
            this.txtCIO = new DevExpress.XtraEditors.TextEdit();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.dateEdit2 = new DevExpress.XtraEditors.DateEdit();
            this.dateEdit1 = new DevExpress.XtraEditors.DateEdit();
            this.label8 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.menuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ItemTextEditnumber)).BeginInit();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtExchangeRate.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtStdCost.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtTotal.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtDuty.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtCIO.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dateEdit2.Properties.VistaTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dateEdit2.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dateEdit1.Properties.VistaTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dateEdit1.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btnQuery,
            this.btnExport});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(944, 25);
            this.menuStrip1.TabIndex = 172;
            this.menuStrip1.Text = "menuStrip";
            // 
            // btnQuery
            // 
            this.btnQuery.Name = "btnQuery";
            this.btnQuery.Size = new System.Drawing.Size(55, 21);
            this.btnQuery.Text = "Query";
            this.btnQuery.Click += new System.EventHandler(this.btnQuery_Click);
            // 
            // btnExport
            // 
            this.btnExport.Name = "btnExport";
            this.btnExport.Size = new System.Drawing.Size(58, 21);
            this.btnExport.Text = "Export";
            this.btnExport.Click += new System.EventHandler(this.btnExport_Click);
            // 
            // gridControl1
            // 
            this.gridControl1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.gridControl1.Location = new System.Drawing.Point(3, 155);
            this.gridControl1.LookAndFeel.SkinName = "Office 2010 Blue";
            this.gridControl1.MainView = this.gridView1;
            this.gridControl1.Name = "gridControl1";
            this.gridControl1.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.ItemTextEditnumber});
            this.gridControl1.Size = new System.Drawing.Size(938, 271);
            this.gridControl1.TabIndex = 191;
            this.gridControl1.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView1});
            // 
            // gridView1
            // 
            this.gridView1.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.gridColUPC,
            this.gridColDescription,
            this.gridColDescription2,
            this.gridColQty,
            this.gridColCSEConv0,
            this.gridColCases,
            this.gridColEUConv,
            this.gridColEUs,
            this.gridColGSWOTaxRMB,
            this.gridColGSWOTaxUSD,
            this.gridColStandardCost,
            this.gridColAllocateDutyCIQ,
            this.gridColTotStdCostRMB,
            this.gridColTotStdCostUSD});
            this.gridView1.GridControl = this.gridControl1;
            this.gridView1.IndicatorWidth = 40;
            this.gridView1.Name = "gridView1";
            this.gridView1.OptionsBehavior.AllowDeleteRows = DevExpress.Utils.DefaultBoolean.True;
            this.gridView1.OptionsBehavior.Editable = false;
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
            // gridColUPC
            // 
            this.gridColUPC.Caption = "UPC";
            this.gridColUPC.FieldName = "UPC";
            this.gridColUPC.Name = "gridColUPC";
            this.gridColUPC.Visible = true;
            this.gridColUPC.VisibleIndex = 0;
            // 
            // gridColDescription
            // 
            this.gridColDescription.Caption = "Description";
            this.gridColDescription.FieldName = "Description";
            this.gridColDescription.Name = "gridColDescription";
            this.gridColDescription.Visible = true;
            this.gridColDescription.VisibleIndex = 1;
            // 
            // gridColDescription2
            // 
            this.gridColDescription2.Caption = "Description";
            this.gridColDescription2.FieldName = "Description2";
            this.gridColDescription2.Name = "gridColDescription2";
            this.gridColDescription2.Visible = true;
            this.gridColDescription2.VisibleIndex = 2;
            // 
            // gridColQty
            // 
            this.gridColQty.Caption = "Qty (Units)";
            this.gridColQty.ColumnEdit = this.ItemTextEditnumber;
            this.gridColQty.FieldName = "Qty";
            this.gridColQty.Name = "gridColQty";
            this.gridColQty.Summary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] {
            new DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum)});
            this.gridColQty.Visible = true;
            this.gridColQty.VisibleIndex = 3;
            // 
            // ItemTextEditnumber
            // 
            this.ItemTextEditnumber.AutoHeight = false;
            this.ItemTextEditnumber.DisplayFormat.FormatString = "n";
            this.ItemTextEditnumber.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.ItemTextEditnumber.Mask.EditMask = "n";
            this.ItemTextEditnumber.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Numeric;
            this.ItemTextEditnumber.Name = "ItemTextEditnumber";
            // 
            // gridColCSEConv0
            // 
            this.gridColCSEConv0.Caption = "CSE Conv0";
            this.gridColCSEConv0.ColumnEdit = this.ItemTextEditnumber;
            this.gridColCSEConv0.FieldName = "CSEConv0";
            this.gridColCSEConv0.Name = "gridColCSEConv0";
            this.gridColCSEConv0.Summary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] {
            new DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum)});
            this.gridColCSEConv0.Visible = true;
            this.gridColCSEConv0.VisibleIndex = 4;
            // 
            // gridColCases
            // 
            this.gridColCases.Caption = "Cases";
            this.gridColCases.ColumnEdit = this.ItemTextEditnumber;
            this.gridColCases.FieldName = "Cases";
            this.gridColCases.Name = "gridColCases";
            this.gridColCases.Summary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] {
            new DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum)});
            this.gridColCases.Visible = true;
            this.gridColCases.VisibleIndex = 5;
            // 
            // gridColEUConv
            // 
            this.gridColEUConv.Caption = "EU Conv";
            this.gridColEUConv.ColumnEdit = this.ItemTextEditnumber;
            this.gridColEUConv.FieldName = "EUConv";
            this.gridColEUConv.Name = "gridColEUConv";
            this.gridColEUConv.Summary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] {
            new DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum)});
            this.gridColEUConv.Visible = true;
            this.gridColEUConv.VisibleIndex = 6;
            // 
            // gridColEUs
            // 
            this.gridColEUs.Caption = "EUs";
            this.gridColEUs.ColumnEdit = this.ItemTextEditnumber;
            this.gridColEUs.FieldName = "EUs";
            this.gridColEUs.Name = "gridColEUs";
            this.gridColEUs.Summary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] {
            new DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum)});
            this.gridColEUs.Visible = true;
            this.gridColEUs.VisibleIndex = 7;
            // 
            // gridColGSWOTaxRMB
            // 
            this.gridColGSWOTaxRMB.Caption = "GS WO Tax (RMB)";
            this.gridColGSWOTaxRMB.ColumnEdit = this.ItemTextEditnumber;
            this.gridColGSWOTaxRMB.FieldName = "GSWOTaxRMB";
            this.gridColGSWOTaxRMB.Name = "gridColGSWOTaxRMB";
            this.gridColGSWOTaxRMB.Summary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] {
            new DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum)});
            this.gridColGSWOTaxRMB.Visible = true;
            this.gridColGSWOTaxRMB.VisibleIndex = 8;
            this.gridColGSWOTaxRMB.Width = 111;
            // 
            // gridColGSWOTaxUSD
            // 
            this.gridColGSWOTaxUSD.Caption = "GS WO Tax (USD)";
            this.gridColGSWOTaxUSD.ColumnEdit = this.ItemTextEditnumber;
            this.gridColGSWOTaxUSD.FieldName = "GSWOTaxUSD";
            this.gridColGSWOTaxUSD.Name = "gridColGSWOTaxUSD";
            this.gridColGSWOTaxUSD.Summary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] {
            new DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum)});
            this.gridColGSWOTaxUSD.Visible = true;
            this.gridColGSWOTaxUSD.VisibleIndex = 9;
            this.gridColGSWOTaxUSD.Width = 118;
            // 
            // gridColStandardCost
            // 
            this.gridColStandardCost.Caption = "Standard Cost";
            this.gridColStandardCost.ColumnEdit = this.ItemTextEditnumber;
            this.gridColStandardCost.FieldName = "StandardCost";
            this.gridColStandardCost.Name = "gridColStandardCost";
            this.gridColStandardCost.Summary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] {
            new DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum)});
            this.gridColStandardCost.Visible = true;
            this.gridColStandardCost.VisibleIndex = 10;
            this.gridColStandardCost.Width = 102;
            // 
            // gridColAllocateDutyCIQ
            // 
            this.gridColAllocateDutyCIQ.Caption = "Allocate Duty/CIQ";
            this.gridColAllocateDutyCIQ.ColumnEdit = this.ItemTextEditnumber;
            this.gridColAllocateDutyCIQ.FieldName = "AllocateDutyCIQ";
            this.gridColAllocateDutyCIQ.Name = "gridColAllocateDutyCIQ";
            this.gridColAllocateDutyCIQ.Summary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] {
            new DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum)});
            this.gridColAllocateDutyCIQ.Visible = true;
            this.gridColAllocateDutyCIQ.VisibleIndex = 11;
            this.gridColAllocateDutyCIQ.Width = 106;
            // 
            // gridColTotStdCostRMB
            // 
            this.gridColTotStdCostRMB.Caption = "Tot Std Cost (RMB)";
            this.gridColTotStdCostRMB.ColumnEdit = this.ItemTextEditnumber;
            this.gridColTotStdCostRMB.FieldName = "TotStdCostRMB";
            this.gridColTotStdCostRMB.Name = "gridColTotStdCostRMB";
            this.gridColTotStdCostRMB.Summary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] {
            new DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum)});
            this.gridColTotStdCostRMB.Visible = true;
            this.gridColTotStdCostRMB.VisibleIndex = 12;
            this.gridColTotStdCostRMB.Width = 141;
            // 
            // gridColTotStdCostUSD
            // 
            this.gridColTotStdCostUSD.Caption = "Tot Std Cost (USD)";
            this.gridColTotStdCostUSD.ColumnEdit = this.ItemTextEditnumber;
            this.gridColTotStdCostUSD.FieldName = "TotStdCostUSD";
            this.gridColTotStdCostUSD.Name = "gridColTotStdCostUSD";
            this.gridColTotStdCostUSD.Summary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] {
            new DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum)});
            this.gridColTotStdCostUSD.Visible = true;
            this.gridColTotStdCostUSD.VisibleIndex = 13;
            this.gridColTotStdCostUSD.Width = 115;
            // 
            // panel1
            // 
            this.panel1.AutoScroll = true;
            this.panel1.Controls.Add(this.label7);
            this.panel1.Controls.Add(this.txtExchangeRate);
            this.panel1.Controls.Add(this.label6);
            this.panel1.Controls.Add(this.txtStdCost);
            this.panel1.Controls.Add(this.label5);
            this.panel1.Controls.Add(this.txtTotal);
            this.panel1.Controls.Add(this.label4);
            this.panel1.Controls.Add(this.txtDuty);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.txtCIO);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.label9);
            this.panel1.Controls.Add(this.label8);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.dateEdit2);
            this.panel1.Controls.Add(this.dateEdit1);
            this.panel1.Controls.Add(this.gridControl1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 25);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(944, 431);
            this.panel1.TabIndex = 173;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(216, 71);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(17, 12);
            this.label7.TabIndex = 204;
            this.label7.Text = "To";
            // 
            // txtExchangeRate
            // 
            this.txtExchangeRate.Location = new System.Drawing.Point(321, 128);
            this.txtExchangeRate.Name = "txtExchangeRate";
            this.txtExchangeRate.Properties.Mask.EditMask = "n2";
            this.txtExchangeRate.Size = new System.Drawing.Size(100, 20);
            this.txtExchangeRate.TabIndex = 4;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(232, 131);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(83, 12);
            this.label6.TabIndex = 202;
            this.label6.Text = "Exchange Rate";
            // 
            // txtStdCost
            // 
            this.txtStdCost.Location = new System.Drawing.Point(126, 128);
            this.txtStdCost.Name = "txtStdCost";
            this.txtStdCost.Properties.Mask.EditMask = "P3";
            this.txtStdCost.Size = new System.Drawing.Size(100, 20);
            this.txtStdCost.TabIndex = 3;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(37, 131);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(83, 12);
            this.label5.TabIndex = 200;
            this.label5.Text = "% of Std Cost";
            // 
            // txtTotal
            // 
            this.txtTotal.Location = new System.Drawing.Point(502, 102);
            this.txtTotal.Name = "txtTotal";
            this.txtTotal.Properties.Mask.EditMask = "n2";
            this.txtTotal.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Numeric;
            this.txtTotal.Properties.ReadOnly = true;
            this.txtTotal.Size = new System.Drawing.Size(100, 20);
            this.txtTotal.TabIndex = 199;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(431, 105);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(65, 12);
            this.label4.TabIndex = 198;
            this.label4.Text = "Total COGS";
            // 
            // txtDuty
            // 
            this.txtDuty.Location = new System.Drawing.Point(321, 102);
            this.txtDuty.Name = "txtDuty";
            this.txtDuty.Properties.Mask.EditMask = "n2";
            this.txtDuty.Size = new System.Drawing.Size(100, 20);
            this.txtDuty.TabIndex = 2;
            this.txtDuty.EditValueChanged += new System.EventHandler(this.txt_EditValueChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(286, 105);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(29, 12);
            this.label3.TabIndex = 196;
            this.label3.Text = "Duty";
            // 
            // txtCIO
            // 
            this.txtCIO.Location = new System.Drawing.Point(126, 102);
            this.txtCIO.Name = "txtCIO";
            this.txtCIO.Properties.Mask.EditMask = "n";
            this.txtCIO.Size = new System.Drawing.Size(100, 20);
            this.txtCIO.TabIndex = 1;
            this.txtCIO.EditValueChanged += new System.EventHandler(this.txt_EditValueChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(97, 108);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(23, 12);
            this.label2.TabIndex = 194;
            this.label2.Text = "CIO";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(53, 71);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(29, 12);
            this.label1.TabIndex = 193;
            this.label1.Text = "Date";
            // 
            // dateEdit2
            // 
            this.dateEdit2.EditValue = null;
            this.dateEdit2.Location = new System.Drawing.Point(254, 68);
            this.dateEdit2.Name = "dateEdit2";
            this.dateEdit2.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.dateEdit2.Properties.VistaTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
            this.dateEdit2.Size = new System.Drawing.Size(100, 20);
            this.dateEdit2.TabIndex = 192;
            // 
            // dateEdit1
            // 
            this.dateEdit1.EditValue = null;
            this.dateEdit1.Location = new System.Drawing.Point(110, 68);
            this.dateEdit1.Name = "dateEdit1";
            this.dateEdit1.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.dateEdit1.Properties.VistaTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
            this.dateEdit1.Size = new System.Drawing.Size(100, 20);
            this.dateEdit1.TabIndex = 192;
            // 
            // label8
            // 
            this.label8.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("宋体", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label8.Location = new System.Drawing.Point(359, 10);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(252, 21);
            this.label8.TabIndex = 193;
            this.label8.Text = "The JM Smucker Company";
            // 
            // label9
            // 
            this.label9.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("宋体", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label9.Location = new System.Drawing.Point(383, 31);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(219, 21);
            this.label9.TabIndex = 193;
            this.label9.Text = "China WFOE Volumes ";
            // 
            // RepForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.menuStrip1);
            this.Name = "RepForm";
            this.Size = new System.Drawing.Size(944, 456);
            this.Load += new System.EventHandler(this.Frm_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ItemTextEditnumber)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtExchangeRate.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtStdCost.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtTotal.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtDuty.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtCIO.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dateEdit2.Properties.VistaTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dateEdit2.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dateEdit1.Properties.VistaTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dateEdit1.Properties)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private DevExpress.XtraGrid.GridControl gridControl1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.ToolStripMenuItem btnQuery;
        private System.Windows.Forms.ToolStripMenuItem btnExport;
        private DevExpress.XtraEditors.TextEdit txtStdCost;
        private System.Windows.Forms.Label label5;
        private DevExpress.XtraEditors.TextEdit txtTotal;
        private System.Windows.Forms.Label label4;
        private DevExpress.XtraEditors.TextEdit txtDuty;
        private System.Windows.Forms.Label label3;
        private DevExpress.XtraEditors.TextEdit txtCIO;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private DevExpress.XtraEditors.DateEdit dateEdit2;
        private DevExpress.XtraEditors.DateEdit dateEdit1;
        private System.Windows.Forms.Label label7;
        private DevExpress.XtraEditors.TextEdit txtExchangeRate;
        private System.Windows.Forms.Label label6;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView1;
        private DevExpress.XtraGrid.Columns.GridColumn gridColUPC;
        private DevExpress.XtraGrid.Columns.GridColumn gridColDescription;
        private DevExpress.XtraGrid.Columns.GridColumn gridColDescription2;
        private DevExpress.XtraGrid.Columns.GridColumn gridColQty;
        private DevExpress.XtraGrid.Columns.GridColumn gridColCSEConv0;
        private DevExpress.XtraGrid.Columns.GridColumn gridColCases;
        private DevExpress.XtraGrid.Columns.GridColumn gridColEUConv;
        private DevExpress.XtraGrid.Columns.GridColumn gridColEUs;
        private DevExpress.XtraGrid.Columns.GridColumn gridColGSWOTaxRMB;
        private DevExpress.XtraGrid.Columns.GridColumn gridColGSWOTaxUSD;
        private DevExpress.XtraGrid.Columns.GridColumn gridColStandardCost;
        private DevExpress.XtraGrid.Columns.GridColumn gridColAllocateDutyCIQ;
        private DevExpress.XtraGrid.Columns.GridColumn gridColTotStdCostRMB;
        private DevExpress.XtraGrid.Columns.GridColumn gridColTotStdCostUSD;
        private DevExpress.XtraEditors.Repository.RepositoryItemTextEdit ItemTextEditnumber;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label8;
    }
}
