namespace UFIDA.U8.UAP.CustomApp.ControlForm
{
    partial class IQCRMDFList
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
            this.btnExport = new System.Windows.Forms.ToolStripMenuItem();
            this.gridControl1 = new DevExpress.XtraGrid.GridControl();
            this.gridView1 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.gridColiID = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColIQCNo = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColiSOsID = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColLotNo = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColLotQty = new DevExpress.XtraGrid.Columns.GridColumn();
            this.ItemTextEditn2 = new DevExpress.XtraEditors.Repository.RepositoryItemTextEdit();
            this.gridColInsQty = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColSampleSize = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColcCusCode = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColcCusName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColAQLLevel = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColdtmReceived = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColdtmInspected = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColInspectedBy = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColAuditUid = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColdtmAudit = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColRMDFNo = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColFeedback = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColIQCResult = new DevExpress.XtraGrid.Columns.GridColumn();
            this.label1 = new System.Windows.Forms.Label();
            this.txtIQCNo = new DevExpress.XtraEditors.TextEdit();
            this.label6 = new System.Windows.Forms.Label();
            this.txtLotNo = new DevExpress.XtraEditors.TextEdit();
            this.dtm1 = new DevExpress.XtraEditors.DateEdit();
            this.label13 = new System.Windows.Forms.Label();
            this.dtm2 = new DevExpress.XtraEditors.DateEdit();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btnLogout = new System.Windows.Forms.Button();
            this.btnLogin = new System.Windows.Forms.Button();
            this.txtPwd = new DevExpress.XtraEditors.TextEdit();
            this.label2 = new System.Windows.Forms.Label();
            this.txtUid = new DevExpress.XtraEditors.TextEdit();
            this.label8 = new System.Windows.Forms.Label();
            this.menuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ItemTextEditn2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtIQCNo.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtLotNo.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtm1.Properties.VistaTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtm1.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtm2.Properties.VistaTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtm2.Properties)).BeginInit();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtPwd.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtUid.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btnRefresh,
            this.btnExport});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Padding = new System.Windows.Forms.Padding(8, 2, 0, 2);
            this.menuStrip1.Size = new System.Drawing.Size(980, 24);
            this.menuStrip1.TabIndex = 172;
            this.menuStrip1.Text = "menuStrip";
            // 
            // btnRefresh
            // 
            this.btnRefresh.Name = "btnRefresh";
            this.btnRefresh.Size = new System.Drawing.Size(75, 20);
            this.btnRefresh.Text = "Refresh";
            this.btnRefresh.Click += new System.EventHandler(this.btnRefresh_Click);
            // 
            // btnExport
            // 
            this.btnExport.Name = "btnExport";
            this.btnExport.Size = new System.Drawing.Size(115, 20);
            this.btnExport.Text = "Export Excel";
            this.btnExport.Click += new System.EventHandler(this.btnExport_Click);
            // 
            // gridControl1
            // 
            this.gridControl1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.gridControl1.EmbeddedNavigator.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.gridControl1.Location = new System.Drawing.Point(2, 146);
            this.gridControl1.LookAndFeel.SkinName = "Office 2010 Blue";
            this.gridControl1.MainView = this.gridView1;
            this.gridControl1.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.gridControl1.Name = "gridControl1";
            this.gridControl1.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.ItemTextEditn2});
            this.gridControl1.Size = new System.Drawing.Size(974, 337);
            this.gridControl1.TabIndex = 4;
            this.gridControl1.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView1});
            // 
            // gridView1
            // 
            this.gridView1.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.gridColiID,
            this.gridColIQCNo,
            this.gridColiSOsID,
            this.gridColLotNo,
            this.gridColLotQty,
            this.gridColInsQty,
            this.gridColSampleSize,
            this.gridColcCusCode,
            this.gridColcCusName,
            this.gridColAQLLevel,
            this.gridColdtmReceived,
            this.gridColdtmInspected,
            this.gridColInspectedBy,
            this.gridColAuditUid,
            this.gridColdtmAudit,
            this.gridColRMDFNo,
            this.gridColFeedback,
            this.gridColIQCResult});
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
            this.gridView1.DoubleClick += new System.EventHandler(this.gridView1_DoubleClick);
            // 
            // gridColiID
            // 
            this.gridColiID.Caption = "iID";
            this.gridColiID.FieldName = "iID";
            this.gridColiID.Name = "gridColiID";
            this.gridColiID.OptionsColumn.AllowEdit = false;
            this.gridColiID.Width = 46;
            // 
            // gridColIQCNo
            // 
            this.gridColIQCNo.Caption = "IQC No";
            this.gridColIQCNo.FieldName = "IQCNo";
            this.gridColIQCNo.Name = "gridColIQCNo";
            this.gridColIQCNo.OptionsColumn.AllowEdit = false;
            this.gridColIQCNo.Visible = true;
            this.gridColIQCNo.VisibleIndex = 0;
            this.gridColIQCNo.Width = 119;
            // 
            // gridColiSOsID
            // 
            this.gridColiSOsID.Caption = "iSOsID";
            this.gridColiSOsID.FieldName = "iSOsID";
            this.gridColiSOsID.Name = "gridColiSOsID";
            this.gridColiSOsID.OptionsColumn.AllowEdit = false;
            // 
            // gridColLotNo
            // 
            this.gridColLotNo.Caption = "Lot No";
            this.gridColLotNo.FieldName = "LotNo";
            this.gridColLotNo.Name = "gridColLotNo";
            this.gridColLotNo.OptionsColumn.AllowEdit = false;
            this.gridColLotNo.Visible = true;
            this.gridColLotNo.VisibleIndex = 2;
            // 
            // gridColLotQty
            // 
            this.gridColLotQty.Caption = "Lot Qty";
            this.gridColLotQty.ColumnEdit = this.ItemTextEditn2;
            this.gridColLotQty.FieldName = "LotQty";
            this.gridColLotQty.Name = "gridColLotQty";
            this.gridColLotQty.OptionsColumn.AllowEdit = false;
            this.gridColLotQty.Visible = true;
            this.gridColLotQty.VisibleIndex = 5;
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
            // gridColInsQty
            // 
            this.gridColInsQty.Caption = "InsQty";
            this.gridColInsQty.ColumnEdit = this.ItemTextEditn2;
            this.gridColInsQty.FieldName = "InsQty";
            this.gridColInsQty.Name = "gridColInsQty";
            this.gridColInsQty.OptionsColumn.AllowEdit = false;
            this.gridColInsQty.Visible = true;
            this.gridColInsQty.VisibleIndex = 6;
            // 
            // gridColSampleSize
            // 
            this.gridColSampleSize.Caption = "Sample Size";
            this.gridColSampleSize.ColumnEdit = this.ItemTextEditn2;
            this.gridColSampleSize.FieldName = "SampleSize";
            this.gridColSampleSize.Name = "gridColSampleSize";
            this.gridColSampleSize.OptionsColumn.AllowEdit = false;
            this.gridColSampleSize.Visible = true;
            this.gridColSampleSize.VisibleIndex = 7;
            this.gridColSampleSize.Width = 107;
            // 
            // gridColcCusCode
            // 
            this.gridColcCusCode.Caption = "Customer Code";
            this.gridColcCusCode.FieldName = "cCusCode";
            this.gridColcCusCode.Name = "gridColcCusCode";
            this.gridColcCusCode.OptionsColumn.AllowEdit = false;
            this.gridColcCusCode.Visible = true;
            this.gridColcCusCode.VisibleIndex = 8;
            this.gridColcCusCode.Width = 138;
            // 
            // gridColcCusName
            // 
            this.gridColcCusName.Caption = "Customer Name";
            this.gridColcCusName.FieldName = "cCusName";
            this.gridColcCusName.Name = "gridColcCusName";
            this.gridColcCusName.OptionsColumn.AllowEdit = false;
            this.gridColcCusName.Visible = true;
            this.gridColcCusName.VisibleIndex = 9;
            this.gridColcCusName.Width = 156;
            // 
            // gridColAQLLevel
            // 
            this.gridColAQLLevel.Caption = "AQL Level";
            this.gridColAQLLevel.FieldName = "AQLLevel";
            this.gridColAQLLevel.Name = "gridColAQLLevel";
            this.gridColAQLLevel.OptionsColumn.AllowEdit = false;
            this.gridColAQLLevel.Visible = true;
            this.gridColAQLLevel.VisibleIndex = 10;
            this.gridColAQLLevel.Width = 122;
            // 
            // gridColdtmReceived
            // 
            this.gridColdtmReceived.Caption = "Received Date";
            this.gridColdtmReceived.FieldName = "dtmReceived";
            this.gridColdtmReceived.Name = "gridColdtmReceived";
            this.gridColdtmReceived.OptionsColumn.AllowEdit = false;
            this.gridColdtmReceived.Visible = true;
            this.gridColdtmReceived.VisibleIndex = 11;
            this.gridColdtmReceived.Width = 114;
            // 
            // gridColdtmInspected
            // 
            this.gridColdtmInspected.Caption = "Inspected Date";
            this.gridColdtmInspected.FieldName = "dtmInspected";
            this.gridColdtmInspected.Name = "gridColdtmInspected";
            this.gridColdtmInspected.OptionsColumn.AllowEdit = false;
            this.gridColdtmInspected.Visible = true;
            this.gridColdtmInspected.VisibleIndex = 13;
            this.gridColdtmInspected.Width = 138;
            // 
            // gridColInspectedBy
            // 
            this.gridColInspectedBy.Caption = "Inspected By";
            this.gridColInspectedBy.FieldName = "InspectedBy";
            this.gridColInspectedBy.Name = "gridColInspectedBy";
            this.gridColInspectedBy.OptionsColumn.AllowEdit = false;
            this.gridColInspectedBy.Visible = true;
            this.gridColInspectedBy.VisibleIndex = 12;
            this.gridColInspectedBy.Width = 125;
            // 
            // gridColAuditUid
            // 
            this.gridColAuditUid.Caption = "Audit Userid";
            this.gridColAuditUid.FieldName = "AuditUid";
            this.gridColAuditUid.Name = "gridColAuditUid";
            this.gridColAuditUid.OptionsColumn.AllowEdit = false;
            this.gridColAuditUid.Width = 94;
            // 
            // gridColdtmAudit
            // 
            this.gridColdtmAudit.Caption = "Audit Date";
            this.gridColdtmAudit.FieldName = "dtmAudit";
            this.gridColdtmAudit.Name = "gridColdtmAudit";
            this.gridColdtmAudit.OptionsColumn.AllowEdit = false;
            // 
            // gridColRMDFNo
            // 
            this.gridColRMDFNo.Caption = "RMDF No.";
            this.gridColRMDFNo.FieldName = "RMDFNo";
            this.gridColRMDFNo.Name = "gridColRMDFNo";
            this.gridColRMDFNo.Visible = true;
            this.gridColRMDFNo.VisibleIndex = 1;
            this.gridColRMDFNo.Width = 89;
            // 
            // gridColFeedback
            // 
            this.gridColFeedback.Caption = "Feedback";
            this.gridColFeedback.FieldName = "Feedback";
            this.gridColFeedback.Name = "gridColFeedback";
            this.gridColFeedback.Visible = true;
            this.gridColFeedback.VisibleIndex = 4;
            this.gridColFeedback.Width = 90;
            // 
            // gridColIQCResult
            // 
            this.gridColIQCResult.Caption = "IQC Result";
            this.gridColIQCResult.FieldName = "IQCResult";
            this.gridColIQCResult.Name = "gridColIQCResult";
            this.gridColIQCResult.OptionsColumn.AllowEdit = false;
            this.gridColIQCResult.Visible = true;
            this.gridColIQCResult.VisibleIndex = 3;
            this.gridColIQCResult.Width = 99;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(35, 50);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(55, 15);
            this.label1.TabIndex = 277;
            this.label1.Text = "IQC No";
            // 
            // txtIQCNo
            // 
            this.txtIQCNo.Location = new System.Drawing.Point(106, 45);
            this.txtIQCNo.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtIQCNo.Name = "txtIQCNo";
            this.txtIQCNo.Properties.ReadOnly = true;
            this.txtIQCNo.Size = new System.Drawing.Size(156, 24);
            this.txtIQCNo.TabIndex = 276;
            this.txtIQCNo.KeyUp += new System.Windows.Forms.KeyEventHandler(this.txtIQCNo_KeyUp);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(43, 78);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(55, 15);
            this.label6.TabIndex = 275;
            this.label6.Text = "Lot No";
            // 
            // txtLotNo
            // 
            this.txtLotNo.Location = new System.Drawing.Point(106, 73);
            this.txtLotNo.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtLotNo.Name = "txtLotNo";
            this.txtLotNo.Size = new System.Drawing.Size(156, 24);
            this.txtLotNo.TabIndex = 274;
            this.txtLotNo.KeyUp += new System.Windows.Forms.KeyEventHandler(this.txtLotNo_KeyUp);
            // 
            // dtm1
            // 
            this.dtm1.EditValue = null;
            this.dtm1.Enabled = false;
            this.dtm1.Location = new System.Drawing.Point(106, 101);
            this.dtm1.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.dtm1.Name = "dtm1";
            this.dtm1.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.dtm1.Properties.VistaTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
            this.dtm1.Size = new System.Drawing.Size(156, 24);
            this.dtm1.TabIndex = 287;
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Enabled = false;
            this.label13.Location = new System.Drawing.Point(59, 106);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(39, 15);
            this.label13.TabIndex = 288;
            this.label13.Text = "Date";
            // 
            // dtm2
            // 
            this.dtm2.EditValue = null;
            this.dtm2.Enabled = false;
            this.dtm2.Location = new System.Drawing.Point(270, 101);
            this.dtm2.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.dtm2.Name = "dtm2";
            this.dtm2.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.dtm2.Properties.VistaTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
            this.dtm2.Size = new System.Drawing.Size(156, 24);
            this.dtm2.TabIndex = 289;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.btnLogout);
            this.groupBox1.Controls.Add(this.btnLogin);
            this.groupBox1.Controls.Add(this.txtPwd);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.txtUid);
            this.groupBox1.Controls.Add(this.label8);
            this.groupBox1.Location = new System.Drawing.Point(462, 26);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.groupBox1.Size = new System.Drawing.Size(269, 114);
            this.groupBox1.TabIndex = 290;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Login";
            // 
            // btnLogout
            // 
            this.btnLogout.Location = new System.Drawing.Point(151, 79);
            this.btnLogout.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnLogout.Name = "btnLogout";
            this.btnLogout.Size = new System.Drawing.Size(75, 27);
            this.btnLogout.TabIndex = 15;
            this.btnLogout.Text = "Logout";
            this.btnLogout.UseVisualStyleBackColor = true;
            this.btnLogout.Click += new System.EventHandler(this.btnLogout_Click);
            // 
            // btnLogin
            // 
            this.btnLogin.Location = new System.Drawing.Point(37, 79);
            this.btnLogin.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnLogin.Name = "btnLogin";
            this.btnLogin.Size = new System.Drawing.Size(75, 27);
            this.btnLogin.TabIndex = 3;
            this.btnLogin.Text = "Login";
            this.btnLogin.UseVisualStyleBackColor = true;
            this.btnLogin.Click += new System.EventHandler(this.btnLogin_Click);
            // 
            // txtPwd
            // 
            this.txtPwd.Enabled = false;
            this.txtPwd.Location = new System.Drawing.Point(101, 46);
            this.txtPwd.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtPwd.Name = "txtPwd";
            this.txtPwd.Properties.PasswordChar = '*';
            this.txtPwd.Size = new System.Drawing.Size(153, 24);
            this.txtPwd.TabIndex = 2;
            this.txtPwd.KeyUp += new System.Windows.Forms.KeyEventHandler(this.txtPwd_KeyUp);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(15, 51);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(71, 15);
            this.label2.TabIndex = 253;
            this.label2.Text = "Password";
            // 
            // txtUid
            // 
            this.txtUid.Enabled = false;
            this.txtUid.Location = new System.Drawing.Point(101, 18);
            this.txtUid.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtUid.Name = "txtUid";
            this.txtUid.Size = new System.Drawing.Size(153, 24);
            this.txtUid.TabIndex = 1;
            this.txtUid.KeyUp += new System.Windows.Forms.KeyEventHandler(this.txtUid_KeyUp);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(15, 22);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(39, 15);
            this.label8.TabIndex = 252;
            this.label8.Text = "User";
            // 
            // IQCRMDFList
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.dtm2);
            this.Controls.Add(this.dtm1);
            this.Controls.Add(this.label13);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtIQCNo);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.txtLotNo);
            this.Controls.Add(this.gridControl1);
            this.Controls.Add(this.menuStrip1);
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Name = "IQCRMDFList";
            this.Size = new System.Drawing.Size(980, 487);
            this.Load += new System.EventHandler(this.IQCRMDFList_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ItemTextEditn2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtIQCNo.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtLotNo.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtm1.Properties.VistaTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtm1.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtm2.Properties.VistaTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtm2.Properties)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtPwd.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtUid.Properties)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem btnRefresh;
        private DevExpress.XtraGrid.GridControl gridControl1;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView1;
        private DevExpress.XtraGrid.Columns.GridColumn gridColiID;
        private DevExpress.XtraGrid.Columns.GridColumn gridColIQCNo;
        private DevExpress.XtraGrid.Columns.GridColumn gridColiSOsID;
        private DevExpress.XtraGrid.Columns.GridColumn gridColLotNo;
        private DevExpress.XtraGrid.Columns.GridColumn gridColLotQty;
        private DevExpress.XtraGrid.Columns.GridColumn gridColInsQty;
        private DevExpress.XtraGrid.Columns.GridColumn gridColSampleSize;
        private DevExpress.XtraGrid.Columns.GridColumn gridColcCusCode;
        private DevExpress.XtraGrid.Columns.GridColumn gridColcCusName;
        private DevExpress.XtraGrid.Columns.GridColumn gridColAQLLevel;
        private DevExpress.XtraGrid.Columns.GridColumn gridColdtmReceived;
        private DevExpress.XtraGrid.Columns.GridColumn gridColdtmInspected;
        private DevExpress.XtraGrid.Columns.GridColumn gridColInspectedBy;
        private DevExpress.XtraGrid.Columns.GridColumn gridColAuditUid;
        private DevExpress.XtraGrid.Columns.GridColumn gridColdtmAudit;
        private System.Windows.Forms.ToolStripMenuItem btnExport;
        private System.Windows.Forms.Label label1;
        private DevExpress.XtraEditors.TextEdit txtIQCNo;
        private System.Windows.Forms.Label label6;
        private DevExpress.XtraEditors.TextEdit txtLotNo;
        private DevExpress.XtraEditors.DateEdit dtm1;
        private System.Windows.Forms.Label label13;
        private DevExpress.XtraEditors.DateEdit dtm2;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button btnLogout;
        private System.Windows.Forms.Button btnLogin;
        private DevExpress.XtraEditors.TextEdit txtPwd;
        private System.Windows.Forms.Label label2;
        private DevExpress.XtraEditors.TextEdit txtUid;
        private System.Windows.Forms.Label label8;
        private DevExpress.XtraGrid.Columns.GridColumn gridColRMDFNo;
        private DevExpress.XtraEditors.Repository.RepositoryItemTextEdit ItemTextEditn2;
        private DevExpress.XtraGrid.Columns.GridColumn gridColFeedback;
        private DevExpress.XtraGrid.Columns.GridColumn gridColIQCResult;
    }
}
