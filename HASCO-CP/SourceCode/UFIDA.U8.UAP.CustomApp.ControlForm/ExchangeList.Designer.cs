namespace UFIDA.U8.UAP.CustomApp.ControlForm
{
    partial class ExchangeList
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
            this.btnExchangeVoucher = new System.Windows.Forms.ToolStripMenuItem();
            this.btnCreateVoucher = new System.Windows.Forms.ToolStripMenuItem();
            this.btnDeleteVoucher = new System.Windows.Forms.ToolStripMenuItem();
            this.btnCreateRedVoucher = new System.Windows.Forms.ToolStripMenuItem();
            this.btnDeleteRedVoucher = new System.Windows.Forms.ToolStripMenuItem();
            this.panel1 = new System.Windows.Forms.Panel();
            this.lLoginPeriod = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.lookUpEditYear = new DevExpress.XtraEditors.LookUpEdit();
            this.label1 = new System.Windows.Forms.Label();
            this.lookUpEditPeriod2 = new DevExpress.XtraEditors.LookUpEdit();
            this.lookUpEditPeriod1 = new DevExpress.XtraEditors.LookUpEdit();
            this.label6 = new System.Windows.Forms.Label();
            this.gridControl1 = new DevExpress.XtraGrid.GridControl();
            this.gridView1 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.gridColiYear = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColiPeriod = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColAmountOfExchangeProfitAndLoss = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColGLVoucherNO = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColDebit = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColCredit = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColRedGLVoucherNO = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColRedDebit = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColRedCredit = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColSourceiYear = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColSourceiPeriod = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColSourcecsign = new DevExpress.XtraGrid.Columns.GridColumn();
            ((System.ComponentModel.ISupportInitialize)(this.ItemTextEditn2)).BeginInit();
            this.menuStrip1.SuspendLayout();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.lookUpEditYear.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lookUpEditPeriod2.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lookUpEditPeriod1.Properties)).BeginInit();
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
            this.btnExchangeVoucher,
            this.btnCreateVoucher,
            this.btnDeleteVoucher,
            this.btnCreateRedVoucher,
            this.btnDeleteRedVoucher});
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
            // btnExchangeVoucher
            // 
            this.btnExchangeVoucher.Name = "btnExchangeVoucher";
            this.btnExchangeVoucher.Size = new System.Drawing.Size(164, 22);
            this.btnExchangeVoucher.Text = "Exchange Voucher";
            this.btnExchangeVoucher.Click += new System.EventHandler(this.btnExchangeVoucher_Click);
            // 
            // btnCreateVoucher
            // 
            this.btnCreateVoucher.Name = "btnCreateVoucher";
            this.btnCreateVoucher.Size = new System.Drawing.Size(146, 22);
            this.btnCreateVoucher.Text = "Create Voucher";
            this.btnCreateVoucher.Click += new System.EventHandler(this.btnCreateVoucher_Click);
            // 
            // btnDeleteVoucher
            // 
            this.btnDeleteVoucher.Name = "btnDeleteVoucher";
            this.btnDeleteVoucher.Size = new System.Drawing.Size(146, 22);
            this.btnDeleteVoucher.Text = "Delete Voucher";
            this.btnDeleteVoucher.Click += new System.EventHandler(this.btnDeleteVoucher_Click);
            // 
            // btnCreateRedVoucher
            // 
            this.btnCreateRedVoucher.Name = "btnCreateRedVoucher";
            this.btnCreateRedVoucher.Size = new System.Drawing.Size(182, 22);
            this.btnCreateRedVoucher.Text = "Create Red Voucher";
            this.btnCreateRedVoucher.Click += new System.EventHandler(this.btnCreateRedVoucher_Click);
            // 
            // btnDeleteRedVoucher
            // 
            this.btnDeleteRedVoucher.Name = "btnDeleteRedVoucher";
            this.btnDeleteRedVoucher.Size = new System.Drawing.Size(182, 22);
            this.btnDeleteRedVoucher.Text = "Delete Red Voucher";
            this.btnDeleteRedVoucher.Click += new System.EventHandler(this.btnDeleteRedVoucher_Click);
            // 
            // panel1
            // 
            this.panel1.AutoScroll = true;
            this.panel1.Controls.Add(this.lLoginPeriod);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.lookUpEditYear);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.lookUpEditPeriod2);
            this.panel1.Controls.Add(this.lookUpEditPeriod1);
            this.panel1.Controls.Add(this.label6);
            this.panel1.Controls.Add(this.gridControl1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 28);
            this.panel1.Margin = new System.Windows.Forms.Padding(4);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1546, 564);
            this.panel1.TabIndex = 173;
            // 
            // lLoginPeriod
            // 
            this.lLoginPeriod.AutoSize = true;
            this.lLoginPeriod.Location = new System.Drawing.Point(650, 15);
            this.lLoginPeriod.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lLoginPeriod.Name = "lLoginPeriod";
            this.lLoginPeriod.Size = new System.Drawing.Size(116, 18);
            this.lLoginPeriod.TabIndex = 222;
            this.lLoginPeriod.Text = "Login Period";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(506, 15);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(116, 18);
            this.label2.TabIndex = 221;
            this.label2.Text = "Login Period";
            // 
            // lookUpEditYear
            // 
            this.lookUpEditYear.Location = new System.Drawing.Point(82, 8);
            this.lookUpEditYear.Margin = new System.Windows.Forms.Padding(4);
            this.lookUpEditYear.Name = "lookUpEditYear";
            this.lookUpEditYear.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.lookUpEditYear.Properties.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("iYear", 40, "Year")});
            this.lookUpEditYear.Properties.DisplayMember = "iYear";
            this.lookUpEditYear.Properties.NullText = "";
            this.lookUpEditYear.Properties.PopupWidth = 500;
            this.lookUpEditYear.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.Standard;
            this.lookUpEditYear.Properties.ValueMember = "iYear";
            this.lookUpEditYear.Size = new System.Drawing.Size(104, 28);
            this.lookUpEditYear.TabIndex = 220;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(30, 12);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(44, 18);
            this.label1.TabIndex = 219;
            this.label1.Text = "Year";
            // 
            // lookUpEditPeriod2
            // 
            this.lookUpEditPeriod2.Location = new System.Drawing.Point(376, 8);
            this.lookUpEditPeriod2.Margin = new System.Windows.Forms.Padding(4);
            this.lookUpEditPeriod2.Name = "lookUpEditPeriod2";
            this.lookUpEditPeriod2.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.lookUpEditPeriod2.Properties.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("iPeriod", 40, "Period")});
            this.lookUpEditPeriod2.Properties.DisplayMember = "iPeriod";
            this.lookUpEditPeriod2.Properties.NullText = "";
            this.lookUpEditPeriod2.Properties.PopupWidth = 500;
            this.lookUpEditPeriod2.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.Standard;
            this.lookUpEditPeriod2.Properties.ValueMember = "iPeriod";
            this.lookUpEditPeriod2.Size = new System.Drawing.Size(90, 28);
            this.lookUpEditPeriod2.TabIndex = 218;
            // 
            // lookUpEditPeriod1
            // 
            this.lookUpEditPeriod1.Location = new System.Drawing.Point(279, 8);
            this.lookUpEditPeriod1.Margin = new System.Windows.Forms.Padding(4);
            this.lookUpEditPeriod1.Name = "lookUpEditPeriod1";
            this.lookUpEditPeriod1.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.lookUpEditPeriod1.Properties.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("iPeriod", 40, "Period")});
            this.lookUpEditPeriod1.Properties.DisplayMember = "iPeriod";
            this.lookUpEditPeriod1.Properties.NullText = "";
            this.lookUpEditPeriod1.Properties.PopupWidth = 500;
            this.lookUpEditPeriod1.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.Standard;
            this.lookUpEditPeriod1.Properties.ValueMember = "iPeriod";
            this.lookUpEditPeriod1.Size = new System.Drawing.Size(88, 28);
            this.lookUpEditPeriod1.TabIndex = 216;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(195, 15);
            this.label6.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(62, 18);
            this.label6.TabIndex = 215;
            this.label6.Text = "Period";
            // 
            // gridControl1
            // 
            this.gridControl1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.gridControl1.EmbeddedNavigator.Margin = new System.Windows.Forms.Padding(4);
            this.gridControl1.Location = new System.Drawing.Point(3, 46);
            this.gridControl1.LookAndFeel.SkinName = "Office 2010 Blue";
            this.gridControl1.MainView = this.gridView1;
            this.gridControl1.Margin = new System.Windows.Forms.Padding(4);
            this.gridControl1.Name = "gridControl1";
            this.gridControl1.Size = new System.Drawing.Size(1542, 514);
            this.gridControl1.TabIndex = 194;
            this.gridControl1.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView1});
            // 
            // gridView1
            // 
            this.gridView1.Appearance.FocusedRow.BackColor = System.Drawing.Color.Green;
            this.gridView1.Appearance.FocusedRow.Options.UseBackColor = true;
            this.gridView1.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.gridColiYear,
            this.gridColiPeriod,
            this.gridColAmountOfExchangeProfitAndLoss,
            this.gridColGLVoucherNO,
            this.gridColDebit,
            this.gridColCredit,
            this.gridColRedGLVoucherNO,
            this.gridColRedDebit,
            this.gridColRedCredit,
            this.gridColSourceiYear,
            this.gridColSourceiPeriod,
            this.gridColSourcecsign});
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
            // gridColiYear
            // 
            this.gridColiYear.Caption = "Year";
            this.gridColiYear.FieldName = "iYear";
            this.gridColiYear.Name = "gridColiYear";
            this.gridColiYear.OptionsColumn.AllowEdit = false;
            this.gridColiYear.Visible = true;
            this.gridColiYear.VisibleIndex = 0;
            // 
            // gridColiPeriod
            // 
            this.gridColiPeriod.Caption = "iPeriod";
            this.gridColiPeriod.FieldName = "iPeriod";
            this.gridColiPeriod.Name = "gridColiPeriod";
            this.gridColiPeriod.OptionsColumn.AllowEdit = false;
            this.gridColiPeriod.Visible = true;
            this.gridColiPeriod.VisibleIndex = 1;
            // 
            // gridColAmountOfExchangeProfitAndLoss
            // 
            this.gridColAmountOfExchangeProfitAndLoss.Caption = "AmountOfExchangeProfitAndLoss";
            this.gridColAmountOfExchangeProfitAndLoss.DisplayFormat.FormatString = "n2";
            this.gridColAmountOfExchangeProfitAndLoss.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.gridColAmountOfExchangeProfitAndLoss.FieldName = "AmountOfExchangeProfitAndLoss";
            this.gridColAmountOfExchangeProfitAndLoss.Name = "gridColAmountOfExchangeProfitAndLoss";
            this.gridColAmountOfExchangeProfitAndLoss.OptionsColumn.AllowEdit = false;
            this.gridColAmountOfExchangeProfitAndLoss.Visible = true;
            this.gridColAmountOfExchangeProfitAndLoss.VisibleIndex = 2;
            this.gridColAmountOfExchangeProfitAndLoss.Width = 291;
            // 
            // gridColGLVoucherNO
            // 
            this.gridColGLVoucherNO.Caption = "GLVoucherNO";
            this.gridColGLVoucherNO.FieldName = "GLVoucherNO";
            this.gridColGLVoucherNO.Name = "gridColGLVoucherNO";
            this.gridColGLVoucherNO.OptionsColumn.AllowEdit = false;
            this.gridColGLVoucherNO.Visible = true;
            this.gridColGLVoucherNO.VisibleIndex = 3;
            this.gridColGLVoucherNO.Width = 124;
            // 
            // gridColDebit
            // 
            this.gridColDebit.Caption = "Debit";
            this.gridColDebit.DisplayFormat.FormatString = "n2";
            this.gridColDebit.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.gridColDebit.FieldName = "Debit";
            this.gridColDebit.Name = "gridColDebit";
            this.gridColDebit.OptionsColumn.AllowEdit = false;
            this.gridColDebit.Visible = true;
            this.gridColDebit.VisibleIndex = 4;
            // 
            // gridColCredit
            // 
            this.gridColCredit.Caption = "Credit";
            this.gridColCredit.DisplayFormat.FormatString = "n2";
            this.gridColCredit.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.gridColCredit.FieldName = "Credit";
            this.gridColCredit.Name = "gridColCredit";
            this.gridColCredit.OptionsColumn.AllowEdit = false;
            this.gridColCredit.Visible = true;
            this.gridColCredit.VisibleIndex = 5;
            // 
            // gridColRedGLVoucherNO
            // 
            this.gridColRedGLVoucherNO.Caption = "RedGLVoucherNO";
            this.gridColRedGLVoucherNO.FieldName = "RedGLVoucherNO";
            this.gridColRedGLVoucherNO.Name = "gridColRedGLVoucherNO";
            this.gridColRedGLVoucherNO.OptionsColumn.AllowEdit = false;
            this.gridColRedGLVoucherNO.Visible = true;
            this.gridColRedGLVoucherNO.VisibleIndex = 6;
            this.gridColRedGLVoucherNO.Width = 118;
            // 
            // gridColRedDebit
            // 
            this.gridColRedDebit.Caption = "RedDebit";
            this.gridColRedDebit.DisplayFormat.FormatString = "n2";
            this.gridColRedDebit.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.gridColRedDebit.FieldName = "RedDebit";
            this.gridColRedDebit.Name = "gridColRedDebit";
            this.gridColRedDebit.OptionsColumn.AllowEdit = false;
            this.gridColRedDebit.Visible = true;
            this.gridColRedDebit.VisibleIndex = 7;
            // 
            // gridColRedCredit
            // 
            this.gridColRedCredit.Caption = "RedCredit";
            this.gridColRedCredit.DisplayFormat.FormatString = "n2";
            this.gridColRedCredit.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.gridColRedCredit.FieldName = "RedCredit";
            this.gridColRedCredit.Name = "gridColRedCredit";
            this.gridColRedCredit.OptionsColumn.AllowEdit = false;
            this.gridColRedCredit.Visible = true;
            this.gridColRedCredit.VisibleIndex = 8;
            // 
            // gridColSourceiYear
            // 
            this.gridColSourceiYear.Caption = "SourceiYear";
            this.gridColSourceiYear.FieldName = "SourceiYear";
            this.gridColSourceiYear.Name = "gridColSourceiYear";
            this.gridColSourceiYear.OptionsColumn.AllowEdit = false;
            this.gridColSourceiYear.Visible = true;
            this.gridColSourceiYear.VisibleIndex = 9;
            // 
            // gridColSourceiPeriod
            // 
            this.gridColSourceiPeriod.Caption = "SourceiPeriod";
            this.gridColSourceiPeriod.FieldName = "SourceiPeriod";
            this.gridColSourceiPeriod.Name = "gridColSourceiPeriod";
            this.gridColSourceiPeriod.OptionsColumn.AllowEdit = false;
            this.gridColSourceiPeriod.Visible = true;
            this.gridColSourceiPeriod.VisibleIndex = 10;
            // 
            // gridColSourcecsign
            // 
            this.gridColSourcecsign.Caption = "Sourcecsign";
            this.gridColSourcecsign.FieldName = "Sourcecsign";
            this.gridColSourcecsign.Name = "gridColSourcecsign";
            this.gridColSourcecsign.OptionsColumn.AllowEdit = false;
            this.gridColSourcecsign.Visible = true;
            this.gridColSourcecsign.VisibleIndex = 11;
            // 
            // ExchangeList
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 18F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.menuStrip1);
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "ExchangeList";
            this.Size = new System.Drawing.Size(1546, 592);
            this.Load += new System.EventHandler(this.Frm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.ItemTextEditn2)).EndInit();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.lookUpEditYear.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lookUpEditPeriod2.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lookUpEditPeriod1.Properties)).EndInit();
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
        private System.Windows.Forms.ToolStripMenuItem btnCreateVoucher;
        private System.Windows.Forms.Label label6;
        private DevExpress.XtraEditors.LookUpEdit lookUpEditPeriod1;
        private System.Windows.Forms.ToolStripMenuItem btnDeleteVoucher;
        private DevExpress.XtraGrid.Columns.GridColumn gridColiYear;
        private DevExpress.XtraGrid.Columns.GridColumn gridColiPeriod;
        private DevExpress.XtraGrid.Columns.GridColumn gridColGLVoucherNO;
        private System.Windows.Forms.ToolStripMenuItem btnCreateRedVoucher;
        private System.Windows.Forms.ToolStripMenuItem btnExchangeVoucher;
        private DevExpress.XtraGrid.Columns.GridColumn gridColAmountOfExchangeProfitAndLoss;
        private DevExpress.XtraGrid.Columns.GridColumn gridColDebit;
        private DevExpress.XtraGrid.Columns.GridColumn gridColCredit;
        private DevExpress.XtraEditors.LookUpEdit lookUpEditPeriod2;
        private DevExpress.XtraGrid.Columns.GridColumn gridColRedGLVoucherNO;
        private DevExpress.XtraGrid.Columns.GridColumn gridColRedDebit;
        private DevExpress.XtraGrid.Columns.GridColumn gridColRedCredit;
        private System.Windows.Forms.ToolStripMenuItem btnDeleteRedVoucher;
        private DevExpress.XtraEditors.LookUpEdit lookUpEditYear;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lLoginPeriod;
        private System.Windows.Forms.Label label2;
        private DevExpress.XtraGrid.Columns.GridColumn gridColSourceiYear;
        private DevExpress.XtraGrid.Columns.GridColumn gridColSourceiPeriod;
        private DevExpress.XtraGrid.Columns.GridColumn gridColSourcecsign;
    }
}
