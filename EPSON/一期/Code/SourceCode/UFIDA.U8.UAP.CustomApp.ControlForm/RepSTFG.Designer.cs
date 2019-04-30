namespace UFIDA.U8.UAP.CustomApp.ControlForm
{
    partial class RepSTFG
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.label2 = new System.Windows.Forms.Label();
            this.lookUpEditcInvCCode = new DevExpress.XtraEditors.LookUpEdit();
            this.lookUpEditcCusName = new DevExpress.XtraEditors.LookUpEdit();
            this.lookUpEditcCusCode = new DevExpress.XtraEditors.LookUpEdit();
            this.label1 = new System.Windows.Forms.Label();
            this.lookUpEditMonth = new DevExpress.XtraEditors.LookUpEdit();
            this.lookUpEditYear = new DevExpress.XtraEditors.LookUpEdit();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.treeList1 = new DevExpress.XtraTreeList.TreeList();
            this.treeListColID = new DevExpress.XtraTreeList.Columns.TreeListColumn();
            this.treeListColParentID = new DevExpress.XtraTreeList.Columns.TreeListColumn();
            this.treeListColcCusCode = new DevExpress.XtraTreeList.Columns.TreeListColumn();
            this.treeListColcCusName = new DevExpress.XtraTreeList.Columns.TreeListColumn();
            this.treeListColcCusAbbName = new DevExpress.XtraTreeList.Columns.TreeListColumn();
            this.treeListColItemNo = new DevExpress.XtraTreeList.Columns.TreeListColumn();
            this.treeListColcInvName = new DevExpress.XtraTreeList.Columns.TreeListColumn();
            this.treeListColcInvStd = new DevExpress.XtraTreeList.Columns.TreeListColumn();
            this.treeListColPurchaseCurr = new DevExpress.XtraTreeList.Columns.TreeListColumn();
            this.treeListColPlatingCurr = new DevExpress.XtraTreeList.Columns.TreeListColumn();
            this.treeListColUM = new DevExpress.XtraTreeList.Columns.TreeListColumn();
            this.treeListColOpeningQty = new DevExpress.XtraTreeList.Columns.TreeListColumn();
            this.treeListColRecQty = new DevExpress.XtraTreeList.Columns.TreeListColumn();
            this.treeListColIssQty = new DevExpress.XtraTreeList.Columns.TreeListColumn();
            this.treeListColAdjQty = new DevExpress.XtraTreeList.Columns.TreeListColumn();
            this.treeListColBalanceQty = new DevExpress.XtraTreeList.Columns.TreeListColumn();
            this.treeListColRejQty = new DevExpress.XtraTreeList.Columns.TreeListColumn();
            this.treeListColOpeningAmt = new DevExpress.XtraTreeList.Columns.TreeListColumn();
            this.treeListColRecAmt = new DevExpress.XtraTreeList.Columns.TreeListColumn();
            this.treeListColIssAmt = new DevExpress.XtraTreeList.Columns.TreeListColumn();
            this.treeListColAdjAmt = new DevExpress.XtraTreeList.Columns.TreeListColumn();
            this.treeListColRejAmt = new DevExpress.XtraTreeList.Columns.TreeListColumn();
            this.treeListColBalanceAmt = new DevExpress.XtraTreeList.Columns.TreeListColumn();
            this.treeListColAvgPrice = new DevExpress.XtraTreeList.Columns.TreeListColumn();
            this.treeListColDiffAmt = new DevExpress.XtraTreeList.Columns.TreeListColumn();
            this.chkExpandAll = new System.Windows.Forms.CheckBox();
            this.menuStrip1.SuspendLayout();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.lookUpEditcInvCCode.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lookUpEditcCusName.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lookUpEditcCusCode.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lookUpEditMonth.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lookUpEditYear.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.treeList1)).BeginInit();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btnQuery,
            this.btnExport});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Padding = new System.Windows.Forms.Padding(9, 2, 0, 2);
            this.menuStrip1.Size = new System.Drawing.Size(1537, 26);
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
            // btnExport
            // 
            this.btnExport.Name = "btnExport";
            this.btnExport.Size = new System.Drawing.Size(74, 22);
            this.btnExport.Text = "Export";
            this.btnExport.Click += new System.EventHandler(this.btnExport_Click);
            // 
            // panel1
            // 
            this.panel1.AutoScroll = true;
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.lookUpEditcInvCCode);
            this.panel1.Controls.Add(this.lookUpEditcCusName);
            this.panel1.Controls.Add(this.lookUpEditcCusCode);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.lookUpEditMonth);
            this.panel1.Controls.Add(this.lookUpEditYear);
            this.panel1.Controls.Add(this.label4);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.treeList1);
            this.panel1.Controls.Add(this.chkExpandAll);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 26);
            this.panel1.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1537, 1005);
            this.panel1.TabIndex = 173;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(16, 59);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(224, 18);
            this.label2.TabIndex = 267;
            this.label2.Text = "Inventory Classification";
            // 
            // lookUpEditcInvCCode
            // 
            this.lookUpEditcInvCCode.Location = new System.Drawing.Point(246, 53);
            this.lookUpEditcInvCCode.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.lookUpEditcInvCCode.Name = "lookUpEditcInvCCode";
            this.lookUpEditcInvCCode.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.lookUpEditcInvCCode.Properties.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("cInvCCode", "cInvCCode")});
            this.lookUpEditcInvCCode.Properties.DisplayMember = "cInvCCode";
            this.lookUpEditcInvCCode.Properties.NullText = "";
            this.lookUpEditcInvCCode.Properties.PopupWidth = 400;
            this.lookUpEditcInvCCode.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.Standard;
            this.lookUpEditcInvCCode.Properties.ValueMember = "cInvCCode";
            this.lookUpEditcInvCCode.Size = new System.Drawing.Size(306, 28);
            this.lookUpEditcInvCCode.TabIndex = 266;
            // 
            // lookUpEditcCusName
            // 
            this.lookUpEditcCusName.Location = new System.Drawing.Point(246, 19);
            this.lookUpEditcCusName.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.lookUpEditcCusName.Name = "lookUpEditcCusName";
            this.lookUpEditcCusName.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.lookUpEditcCusName.Properties.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("cCusCode", "cCusCode"),
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("cCusName", "cCusName")});
            this.lookUpEditcCusName.Properties.DisplayMember = "cCusName";
            this.lookUpEditcCusName.Properties.NullText = "";
            this.lookUpEditcCusName.Properties.PopupWidth = 400;
            this.lookUpEditcCusName.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.Standard;
            this.lookUpEditcCusName.Properties.ValueMember = "cCusCode";
            this.lookUpEditcCusName.Size = new System.Drawing.Size(306, 28);
            this.lookUpEditcCusName.TabIndex = 265;
            this.lookUpEditcCusName.EditValueChanged += new System.EventHandler(this.lookUpEditcCusName_EditValueChanged);
            // 
            // lookUpEditcCusCode
            // 
            this.lookUpEditcCusCode.Location = new System.Drawing.Point(120, 19);
            this.lookUpEditcCusCode.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.lookUpEditcCusCode.Name = "lookUpEditcCusCode";
            this.lookUpEditcCusCode.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.lookUpEditcCusCode.Properties.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("cCusCode", "cCusCode"),
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("cCusName", "cCusName")});
            this.lookUpEditcCusCode.Properties.DisplayMember = "cCusCode";
            this.lookUpEditcCusCode.Properties.NullText = "";
            this.lookUpEditcCusCode.Properties.PopupWidth = 400;
            this.lookUpEditcCusCode.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.Standard;
            this.lookUpEditcCusCode.Properties.ValueMember = "cCusCode";
            this.lookUpEditcCusCode.Size = new System.Drawing.Size(117, 28);
            this.lookUpEditcCusCode.TabIndex = 264;
            this.lookUpEditcCusCode.EditValueChanged += new System.EventHandler(this.lookUpEditcCusCode_EditValueChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(33, 25);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(80, 18);
            this.label1.TabIndex = 263;
            this.label1.Text = "Customer";
            // 
            // lookUpEditMonth
            // 
            this.lookUpEditMonth.Location = new System.Drawing.Point(771, 19);
            this.lookUpEditMonth.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.lookUpEditMonth.Name = "lookUpEditMonth";
            this.lookUpEditMonth.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.lookUpEditMonth.Properties.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("iMonth", "Month")});
            this.lookUpEditMonth.Properties.DisplayMember = "iMonth";
            this.lookUpEditMonth.Properties.NullText = "";
            this.lookUpEditMonth.Properties.PopupWidth = 400;
            this.lookUpEditMonth.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.Standard;
            this.lookUpEditMonth.Properties.ValueMember = "iMonth";
            this.lookUpEditMonth.Size = new System.Drawing.Size(82, 28);
            this.lookUpEditMonth.TabIndex = 262;
            // 
            // lookUpEditYear
            // 
            this.lookUpEditYear.Location = new System.Drawing.Point(623, 19);
            this.lookUpEditYear.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.lookUpEditYear.Name = "lookUpEditYear";
            this.lookUpEditYear.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.lookUpEditYear.Properties.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("iYear", "Year")});
            this.lookUpEditYear.Properties.DisplayMember = "iYear";
            this.lookUpEditYear.Properties.NullText = "";
            this.lookUpEditYear.Properties.PopupWidth = 400;
            this.lookUpEditYear.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.Standard;
            this.lookUpEditYear.Properties.ValueMember = "iYear";
            this.lookUpEditYear.Size = new System.Drawing.Size(79, 28);
            this.lookUpEditYear.TabIndex = 261;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(710, 25);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(53, 18);
            this.label4.TabIndex = 259;
            this.label4.Text = "Month";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(572, 25);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(44, 18);
            this.label3.TabIndex = 260;
            this.label3.Text = "Year";
            // 
            // treeList1
            // 
            this.treeList1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.treeList1.Columns.AddRange(new DevExpress.XtraTreeList.Columns.TreeListColumn[] {
            this.treeListColID,
            this.treeListColParentID,
            this.treeListColcCusCode,
            this.treeListColcCusName,
            this.treeListColcCusAbbName,
            this.treeListColItemNo,
            this.treeListColcInvName,
            this.treeListColcInvStd,
            this.treeListColPurchaseCurr,
            this.treeListColPlatingCurr,
            this.treeListColUM,
            this.treeListColOpeningQty,
            this.treeListColRecQty,
            this.treeListColIssQty,
            this.treeListColAdjQty,
            this.treeListColBalanceQty,
            this.treeListColRejQty,
            this.treeListColOpeningAmt,
            this.treeListColRecAmt,
            this.treeListColIssAmt,
            this.treeListColAdjAmt,
            this.treeListColRejAmt,
            this.treeListColBalanceAmt,
            this.treeListColAvgPrice,
            this.treeListColDiffAmt});
            this.treeList1.Location = new System.Drawing.Point(3, 125);
            this.treeList1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.treeList1.Name = "treeList1";
            this.treeList1.OptionsBehavior.Editable = false;
            this.treeList1.OptionsBehavior.PopulateServiceColumns = true;
            this.treeList1.OptionsPrint.PrintRowFooterSummary = true;
            this.treeList1.OptionsView.AutoWidth = false;
            this.treeList1.OptionsView.ShowSummaryFooter = true;
            this.treeList1.Size = new System.Drawing.Size(1527, 877);
            this.treeList1.TabIndex = 256;
            // 
            // treeListColID
            // 
            this.treeListColID.Caption = "ID";
            this.treeListColID.FieldName = "ID";
            this.treeListColID.Name = "treeListColID";
            // 
            // treeListColParentID
            // 
            this.treeListColParentID.Caption = "ParentID";
            this.treeListColParentID.FieldName = "ParentID";
            this.treeListColParentID.Name = "treeListColParentID";
            // 
            // treeListColcCusCode
            // 
            this.treeListColcCusCode.Caption = "cCusCode";
            this.treeListColcCusCode.FieldName = "cCusCode";
            this.treeListColcCusCode.Name = "treeListColcCusCode";
            this.treeListColcCusCode.Visible = true;
            this.treeListColcCusCode.VisibleIndex = 0;
            this.treeListColcCusCode.Width = 92;
            // 
            // treeListColcCusName
            // 
            this.treeListColcCusName.Caption = "cCusName";
            this.treeListColcCusName.FieldName = "cCusName";
            this.treeListColcCusName.Name = "treeListColcCusName";
            this.treeListColcCusName.Visible = true;
            this.treeListColcCusName.VisibleIndex = 1;
            this.treeListColcCusName.Width = 97;
            // 
            // treeListColcCusAbbName
            // 
            this.treeListColcCusAbbName.Caption = "cCusAbbName";
            this.treeListColcCusAbbName.FieldName = "cCusAbbName";
            this.treeListColcCusAbbName.Name = "treeListColcCusAbbName";
            this.treeListColcCusAbbName.Width = 122;
            // 
            // treeListColItemNo
            // 
            this.treeListColItemNo.Caption = "ItemNo";
            this.treeListColItemNo.FieldName = "ItemNo";
            this.treeListColItemNo.Name = "treeListColItemNo";
            this.treeListColItemNo.Visible = true;
            this.treeListColItemNo.VisibleIndex = 2;
            this.treeListColItemNo.Width = 77;
            // 
            // treeListColcInvName
            // 
            this.treeListColcInvName.Caption = "cInvName";
            this.treeListColcInvName.FieldName = "cInvName";
            this.treeListColcInvName.Name = "treeListColcInvName";
            this.treeListColcInvName.Width = 95;
            // 
            // treeListColcInvStd
            // 
            this.treeListColcInvStd.Caption = "cInvStd";
            this.treeListColcInvStd.FieldName = "cInvStd";
            this.treeListColcInvStd.Name = "treeListColcInvStd";
            this.treeListColcInvStd.Width = 77;
            // 
            // treeListColPurchaseCurr
            // 
            this.treeListColPurchaseCurr.Caption = "PurchaseCurr";
            this.treeListColPurchaseCurr.FieldName = "PurchaseCurr";
            this.treeListColPurchaseCurr.Name = "treeListColPurchaseCurr";
            this.treeListColPurchaseCurr.Visible = true;
            this.treeListColPurchaseCurr.VisibleIndex = 3;
            this.treeListColPurchaseCurr.Width = 113;
            // 
            // treeListColPlatingCurr
            // 
            this.treeListColPlatingCurr.Caption = "PlatingCurr";
            this.treeListColPlatingCurr.FieldName = "PlatingCurr";
            this.treeListColPlatingCurr.Name = "treeListColPlatingCurr";
            this.treeListColPlatingCurr.Visible = true;
            this.treeListColPlatingCurr.VisibleIndex = 4;
            this.treeListColPlatingCurr.Width = 95;
            // 
            // treeListColUM
            // 
            this.treeListColUM.Caption = "UM";
            this.treeListColUM.FieldName = "UM";
            this.treeListColUM.Name = "treeListColUM";
            this.treeListColUM.Visible = true;
            this.treeListColUM.VisibleIndex = 5;
            this.treeListColUM.Width = 49;
            // 
            // treeListColOpeningQty
            // 
            this.treeListColOpeningQty.Caption = "OpeningQty";
            this.treeListColOpeningQty.FieldName = "OpeningQty";
            this.treeListColOpeningQty.Format.FormatString = "n3";
            this.treeListColOpeningQty.Format.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.treeListColOpeningQty.Name = "treeListColOpeningQty";
            this.treeListColOpeningQty.RowFooterSummary = DevExpress.XtraTreeList.SummaryItemType.Sum;
            this.treeListColOpeningQty.RowFooterSummaryStrFormat = "{0:#,##0.000}";
            this.treeListColOpeningQty.SummaryFooter = DevExpress.XtraTreeList.SummaryItemType.Sum;
            this.treeListColOpeningQty.SummaryFooterStrFormat = "{0:#,##0.000}";
            this.treeListColOpeningQty.Visible = true;
            this.treeListColOpeningQty.VisibleIndex = 6;
            this.treeListColOpeningQty.Width = 104;
            // 
            // treeListColRecQty
            // 
            this.treeListColRecQty.Caption = "RecQty";
            this.treeListColRecQty.FieldName = "RecQty";
            this.treeListColRecQty.Format.FormatString = "n3";
            this.treeListColRecQty.Format.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.treeListColRecQty.Name = "treeListColRecQty";
            this.treeListColRecQty.RowFooterSummary = DevExpress.XtraTreeList.SummaryItemType.Sum;
            this.treeListColRecQty.RowFooterSummaryStrFormat = "{0:#,##0.000}";
            this.treeListColRecQty.SummaryFooter = DevExpress.XtraTreeList.SummaryItemType.Sum;
            this.treeListColRecQty.SummaryFooterStrFormat = "{0:#,##0.000}";
            this.treeListColRecQty.Visible = true;
            this.treeListColRecQty.VisibleIndex = 7;
            // 
            // treeListColIssQty
            // 
            this.treeListColIssQty.Caption = "IssQty";
            this.treeListColIssQty.FieldName = "IssQty";
            this.treeListColIssQty.Format.FormatString = "n3";
            this.treeListColIssQty.Format.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.treeListColIssQty.Name = "treeListColIssQty";
            this.treeListColIssQty.RowFooterSummary = DevExpress.XtraTreeList.SummaryItemType.Sum;
            this.treeListColIssQty.RowFooterSummaryStrFormat = "{0:#,##0.000}";
            this.treeListColIssQty.SummaryFooter = DevExpress.XtraTreeList.SummaryItemType.Sum;
            this.treeListColIssQty.SummaryFooterStrFormat = "{0:#,##0.000}";
            this.treeListColIssQty.Visible = true;
            this.treeListColIssQty.VisibleIndex = 8;
            // 
            // treeListColAdjQty
            // 
            this.treeListColAdjQty.Caption = "AdjQty";
            this.treeListColAdjQty.FieldName = "AdjQty";
            this.treeListColAdjQty.Format.FormatString = "n3";
            this.treeListColAdjQty.Format.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.treeListColAdjQty.Name = "treeListColAdjQty";
            this.treeListColAdjQty.RowFooterSummary = DevExpress.XtraTreeList.SummaryItemType.Sum;
            this.treeListColAdjQty.RowFooterSummaryStrFormat = "{0:#,##0.000}";
            this.treeListColAdjQty.SummaryFooter = DevExpress.XtraTreeList.SummaryItemType.Sum;
            this.treeListColAdjQty.SummaryFooterStrFormat = "{0:#,##0.000}";
            this.treeListColAdjQty.Visible = true;
            this.treeListColAdjQty.VisibleIndex = 9;
            // 
            // treeListColBalanceQty
            // 
            this.treeListColBalanceQty.Caption = "BalanceQty";
            this.treeListColBalanceQty.FieldName = "BalanceQty";
            this.treeListColBalanceQty.Format.FormatString = "n3";
            this.treeListColBalanceQty.Format.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.treeListColBalanceQty.Name = "treeListColBalanceQty";
            this.treeListColBalanceQty.RowFooterSummary = DevExpress.XtraTreeList.SummaryItemType.Sum;
            this.treeListColBalanceQty.RowFooterSummaryStrFormat = "{0:#,##0.000}";
            this.treeListColBalanceQty.SummaryFooter = DevExpress.XtraTreeList.SummaryItemType.Sum;
            this.treeListColBalanceQty.SummaryFooterStrFormat = "{0:#,##0.000}";
            this.treeListColBalanceQty.Visible = true;
            this.treeListColBalanceQty.VisibleIndex = 11;
            // 
            // treeListColRejQty
            // 
            this.treeListColRejQty.Caption = "RejQty";
            this.treeListColRejQty.FieldName = "RejQty";
            this.treeListColRejQty.Format.FormatString = "n3";
            this.treeListColRejQty.Format.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.treeListColRejQty.Name = "treeListColRejQty";
            this.treeListColRejQty.RowFooterSummary = DevExpress.XtraTreeList.SummaryItemType.Sum;
            this.treeListColRejQty.RowFooterSummaryStrFormat = "{0:#,##0.000}";
            this.treeListColRejQty.SummaryFooter = DevExpress.XtraTreeList.SummaryItemType.Sum;
            this.treeListColRejQty.SummaryFooterStrFormat = "{0:#,##0.000}";
            this.treeListColRejQty.Visible = true;
            this.treeListColRejQty.VisibleIndex = 10;
            // 
            // treeListColOpeningAmt
            // 
            this.treeListColOpeningAmt.Caption = "OpeningAmt";
            this.treeListColOpeningAmt.FieldName = "OpeningAmt";
            this.treeListColOpeningAmt.Format.FormatString = "n3";
            this.treeListColOpeningAmt.Format.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.treeListColOpeningAmt.Name = "treeListColOpeningAmt";
            this.treeListColOpeningAmt.RowFooterSummary = DevExpress.XtraTreeList.SummaryItemType.Sum;
            this.treeListColOpeningAmt.RowFooterSummaryStrFormat = "{0:#,##0.000}";
            this.treeListColOpeningAmt.SummaryFooter = DevExpress.XtraTreeList.SummaryItemType.Sum;
            this.treeListColOpeningAmt.SummaryFooterStrFormat = "{0:#,##0.000}";
            this.treeListColOpeningAmt.Visible = true;
            this.treeListColOpeningAmt.VisibleIndex = 12;
            // 
            // treeListColRecAmt
            // 
            this.treeListColRecAmt.Caption = "RecAmt";
            this.treeListColRecAmt.FieldName = "RecAmt";
            this.treeListColRecAmt.Format.FormatString = "n3";
            this.treeListColRecAmt.Format.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.treeListColRecAmt.Name = "treeListColRecAmt";
            this.treeListColRecAmt.RowFooterSummary = DevExpress.XtraTreeList.SummaryItemType.Sum;
            this.treeListColRecAmt.RowFooterSummaryStrFormat = "{0:#,##0.000}";
            this.treeListColRecAmt.SummaryFooter = DevExpress.XtraTreeList.SummaryItemType.Sum;
            this.treeListColRecAmt.SummaryFooterStrFormat = "{0:#,##0.000}";
            this.treeListColRecAmt.Visible = true;
            this.treeListColRecAmt.VisibleIndex = 13;
            // 
            // treeListColIssAmt
            // 
            this.treeListColIssAmt.Caption = "IssAmt";
            this.treeListColIssAmt.FieldName = "IssAmt";
            this.treeListColIssAmt.Format.FormatString = "n3";
            this.treeListColIssAmt.Format.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.treeListColIssAmt.Name = "treeListColIssAmt";
            this.treeListColIssAmt.RowFooterSummary = DevExpress.XtraTreeList.SummaryItemType.Sum;
            this.treeListColIssAmt.RowFooterSummaryStrFormat = "{0:#,##0.000}";
            this.treeListColIssAmt.SummaryFooter = DevExpress.XtraTreeList.SummaryItemType.Sum;
            this.treeListColIssAmt.SummaryFooterStrFormat = "{0:#,##0.000}";
            this.treeListColIssAmt.Visible = true;
            this.treeListColIssAmt.VisibleIndex = 14;
            // 
            // treeListColAdjAmt
            // 
            this.treeListColAdjAmt.Caption = "AdjAmt";
            this.treeListColAdjAmt.FieldName = "AdjAmt";
            this.treeListColAdjAmt.Format.FormatString = "n3";
            this.treeListColAdjAmt.Format.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.treeListColAdjAmt.Name = "treeListColAdjAmt";
            this.treeListColAdjAmt.RowFooterSummary = DevExpress.XtraTreeList.SummaryItemType.Sum;
            this.treeListColAdjAmt.RowFooterSummaryStrFormat = "{0:#,##0.000}";
            this.treeListColAdjAmt.SummaryFooter = DevExpress.XtraTreeList.SummaryItemType.Sum;
            this.treeListColAdjAmt.SummaryFooterStrFormat = "{0:#,##0.000}";
            this.treeListColAdjAmt.Visible = true;
            this.treeListColAdjAmt.VisibleIndex = 15;
            // 
            // treeListColRejAmt
            // 
            this.treeListColRejAmt.Caption = "RejAmt";
            this.treeListColRejAmt.FieldName = "RejAmt";
            this.treeListColRejAmt.Format.FormatString = "n3";
            this.treeListColRejAmt.Format.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.treeListColRejAmt.Name = "treeListColRejAmt";
            this.treeListColRejAmt.RowFooterSummary = DevExpress.XtraTreeList.SummaryItemType.Sum;
            this.treeListColRejAmt.RowFooterSummaryStrFormat = "{0:#,##0.000}";
            this.treeListColRejAmt.SummaryFooter = DevExpress.XtraTreeList.SummaryItemType.Sum;
            this.treeListColRejAmt.SummaryFooterStrFormat = "{0:#,##0.000}";
            this.treeListColRejAmt.Visible = true;
            this.treeListColRejAmt.VisibleIndex = 16;
            // 
            // treeListColBalanceAmt
            // 
            this.treeListColBalanceAmt.Caption = "BalanceAmt";
            this.treeListColBalanceAmt.FieldName = "BalanceAmt";
            this.treeListColBalanceAmt.Format.FormatString = "n3";
            this.treeListColBalanceAmt.Format.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.treeListColBalanceAmt.Name = "treeListColBalanceAmt";
            this.treeListColBalanceAmt.RowFooterSummary = DevExpress.XtraTreeList.SummaryItemType.Sum;
            this.treeListColBalanceAmt.RowFooterSummaryStrFormat = "{0:#,##0.000}";
            this.treeListColBalanceAmt.SummaryFooter = DevExpress.XtraTreeList.SummaryItemType.Sum;
            this.treeListColBalanceAmt.SummaryFooterStrFormat = "{0:#,##0.000}";
            this.treeListColBalanceAmt.Visible = true;
            this.treeListColBalanceAmt.VisibleIndex = 17;
            // 
            // treeListColAvgPrice
            // 
            this.treeListColAvgPrice.Caption = "AvgPrice";
            this.treeListColAvgPrice.FieldName = "AvgPrice";
            this.treeListColAvgPrice.Format.FormatString = "n3";
            this.treeListColAvgPrice.Format.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.treeListColAvgPrice.Name = "treeListColAvgPrice";
            this.treeListColAvgPrice.RowFooterSummary = DevExpress.XtraTreeList.SummaryItemType.Sum;
            this.treeListColAvgPrice.SummaryFooter = DevExpress.XtraTreeList.SummaryItemType.Count;
            this.treeListColAvgPrice.Visible = true;
            this.treeListColAvgPrice.VisibleIndex = 18;
            // 
            // treeListColDiffAmt
            // 
            this.treeListColDiffAmt.Caption = "DiffAmt";
            this.treeListColDiffAmt.FieldName = "DiffAmt";
            this.treeListColDiffAmt.Format.FormatString = "n3";
            this.treeListColDiffAmt.Format.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.treeListColDiffAmt.Name = "treeListColDiffAmt";
            this.treeListColDiffAmt.OptionsColumn.AllowEdit = false;
            this.treeListColDiffAmt.RowFooterSummary = DevExpress.XtraTreeList.SummaryItemType.Sum;
            this.treeListColDiffAmt.RowFooterSummaryStrFormat = "{0:#,##0.000}";
            this.treeListColDiffAmt.SummaryFooter = DevExpress.XtraTreeList.SummaryItemType.Sum;
            this.treeListColDiffAmt.SummaryFooterStrFormat = "{0:#,##0.000}";
            this.treeListColDiffAmt.Visible = true;
            this.treeListColDiffAmt.VisibleIndex = 19;
            // 
            // chkExpandAll
            // 
            this.chkExpandAll.AutoSize = true;
            this.chkExpandAll.Location = new System.Drawing.Point(24, 95);
            this.chkExpandAll.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.chkExpandAll.Name = "chkExpandAll";
            this.chkExpandAll.Size = new System.Drawing.Size(117, 22);
            this.chkExpandAll.TabIndex = 254;
            this.chkExpandAll.Text = "Expand All";
            this.chkExpandAll.UseVisualStyleBackColor = true;
            this.chkExpandAll.CheckedChanged += new System.EventHandler(this.chkExpandAll_CheckedChanged);
            // 
            // RepSTFG
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 18F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.menuStrip1);
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "RepSTFG";
            this.Size = new System.Drawing.Size(1537, 1031);
            this.Load += new System.EventHandler(this.Frm_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.lookUpEditcInvCCode.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lookUpEditcCusName.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lookUpEditcCusCode.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lookUpEditMonth.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lookUpEditYear.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.treeList1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.ToolStripMenuItem btnQuery;
        private System.Windows.Forms.ToolStripMenuItem btnExport;
        private System.Windows.Forms.CheckBox chkExpandAll;
        private DevExpress.XtraTreeList.TreeList treeList1;
        private DevExpress.XtraTreeList.Columns.TreeListColumn treeListColID;
        private DevExpress.XtraTreeList.Columns.TreeListColumn treeListColParentID;
        private DevExpress.XtraTreeList.Columns.TreeListColumn treeListColcCusCode;
        private DevExpress.XtraTreeList.Columns.TreeListColumn treeListColcCusName;
        private DevExpress.XtraTreeList.Columns.TreeListColumn treeListColcCusAbbName;
        private DevExpress.XtraTreeList.Columns.TreeListColumn treeListColItemNo;
        private DevExpress.XtraTreeList.Columns.TreeListColumn treeListColcInvName;
        private DevExpress.XtraTreeList.Columns.TreeListColumn treeListColcInvStd;
        private DevExpress.XtraTreeList.Columns.TreeListColumn treeListColPurchaseCurr;
        private DevExpress.XtraTreeList.Columns.TreeListColumn treeListColPlatingCurr;
        private DevExpress.XtraTreeList.Columns.TreeListColumn treeListColUM;
        private DevExpress.XtraTreeList.Columns.TreeListColumn treeListColOpeningQty;
        private DevExpress.XtraTreeList.Columns.TreeListColumn treeListColRecQty;
        private DevExpress.XtraTreeList.Columns.TreeListColumn treeListColIssQty;
        private DevExpress.XtraTreeList.Columns.TreeListColumn treeListColAdjQty;
        private DevExpress.XtraTreeList.Columns.TreeListColumn treeListColBalanceQty;
        private DevExpress.XtraTreeList.Columns.TreeListColumn treeListColRejQty;
        private DevExpress.XtraTreeList.Columns.TreeListColumn treeListColOpeningAmt;
        private DevExpress.XtraTreeList.Columns.TreeListColumn treeListColRecAmt;
        private DevExpress.XtraTreeList.Columns.TreeListColumn treeListColIssAmt;
        private DevExpress.XtraTreeList.Columns.TreeListColumn treeListColAdjAmt;
        private DevExpress.XtraTreeList.Columns.TreeListColumn treeListColRejAmt;
        private DevExpress.XtraTreeList.Columns.TreeListColumn treeListColBalanceAmt;
        private DevExpress.XtraTreeList.Columns.TreeListColumn treeListColAvgPrice;
        private DevExpress.XtraEditors.LookUpEdit lookUpEditMonth;
        private DevExpress.XtraEditors.LookUpEdit lookUpEditYear;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private DevExpress.XtraEditors.LookUpEdit lookUpEditcInvCCode;
        private DevExpress.XtraEditors.LookUpEdit lookUpEditcCusName;
        private DevExpress.XtraEditors.LookUpEdit lookUpEditcCusCode;
        private System.Windows.Forms.Label label1;
        private DevExpress.XtraTreeList.Columns.TreeListColumn treeListColDiffAmt;
    }
}
