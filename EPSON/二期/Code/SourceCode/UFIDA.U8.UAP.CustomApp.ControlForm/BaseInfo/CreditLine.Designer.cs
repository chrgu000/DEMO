namespace UFIDA.U8.UAP.CustomApp.ControlForm
{
    partial class CreditLine
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
            this.btnSEL = new System.Windows.Forms.ToolStripMenuItem();
            this.btnExport = new System.Windows.Forms.ToolStripMenuItem();
            this.gridControl1 = new DevExpress.XtraGrid.GridControl();
            this.gridView1 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.gridColCustomerCode = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColPaymentTerm = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColCustomerName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColCurrency = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColCreditLimit = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColTotalOutstandingAmount = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColExceedLimit = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColPosting = new DevExpress.XtraGrid.Columns.GridColumn();
            this.panel1 = new System.Windows.Forms.Panel();
            this.chkAll = new DevExpress.XtraEditors.CheckEdit();
            this.menuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).BeginInit();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chkAll.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btnSEL,
            this.btnExport});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(944, 25);
            this.menuStrip1.TabIndex = 172;
            this.menuStrip1.Text = "menuStrip";
            // 
            // btnSEL
            // 
            this.btnSEL.Name = "btnSEL";
            this.btnSEL.Size = new System.Drawing.Size(55, 21);
            this.btnSEL.Text = "Query";
            this.btnSEL.Click += new System.EventHandler(this.btnSEL_Click);
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
            this.gridControl1.Location = new System.Drawing.Point(3, 28);
            this.gridControl1.LookAndFeel.SkinName = "Office 2010 Blue";
            this.gridControl1.MainView = this.gridView1;
            this.gridControl1.Name = "gridControl1";
            this.gridControl1.Size = new System.Drawing.Size(938, 398);
            this.gridControl1.TabIndex = 191;
            this.gridControl1.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView1});
            // 
            // gridView1
            // 
            this.gridView1.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.gridColCustomerCode,
            this.gridColPaymentTerm,
            this.gridColCustomerName,
            this.gridColCurrency,
            this.gridColCreditLimit,
            this.gridColTotalOutstandingAmount,
            this.gridColExceedLimit,
            this.gridColPosting});
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
            // gridColCustomerCode
            // 
            this.gridColCustomerCode.Caption = "Customer Code";
            this.gridColCustomerCode.FieldName = "CustomerCode";
            this.gridColCustomerCode.Name = "gridColCustomerCode";
            this.gridColCustomerCode.OptionsColumn.AllowEdit = false;
            this.gridColCustomerCode.Visible = true;
            this.gridColCustomerCode.VisibleIndex = 0;
            this.gridColCustomerCode.Width = 132;
            // 
            // gridColPaymentTerm
            // 
            this.gridColPaymentTerm.Caption = "Payment Term";
            this.gridColPaymentTerm.FieldName = "PaymentTerm";
            this.gridColPaymentTerm.Name = "gridColPaymentTerm";
            this.gridColPaymentTerm.OptionsColumn.AllowEdit = false;
            this.gridColPaymentTerm.Visible = true;
            this.gridColPaymentTerm.VisibleIndex = 1;
            this.gridColPaymentTerm.Width = 132;
            // 
            // gridColCustomerName
            // 
            this.gridColCustomerName.Caption = "Customer Name";
            this.gridColCustomerName.FieldName = "CustomerName";
            this.gridColCustomerName.Name = "gridColCustomerName";
            this.gridColCustomerName.OptionsColumn.AllowEdit = false;
            this.gridColCustomerName.Visible = true;
            this.gridColCustomerName.VisibleIndex = 2;
            this.gridColCustomerName.Width = 209;
            // 
            // gridColCurrency
            // 
            this.gridColCurrency.Caption = "Currency";
            this.gridColCurrency.FieldName = "Currency";
            this.gridColCurrency.Name = "gridColCurrency";
            this.gridColCurrency.OptionsColumn.AllowEdit = false;
            this.gridColCurrency.Visible = true;
            this.gridColCurrency.VisibleIndex = 3;
            this.gridColCurrency.Width = 86;
            // 
            // gridColCreditLimit
            // 
            this.gridColCreditLimit.Caption = "Credit Limit";
            this.gridColCreditLimit.FieldName = "CreditLimit";
            this.gridColCreditLimit.Name = "gridColCreditLimit";
            this.gridColCreditLimit.OptionsColumn.AllowEdit = false;
            this.gridColCreditLimit.Visible = true;
            this.gridColCreditLimit.VisibleIndex = 4;
            this.gridColCreditLimit.Width = 97;
            // 
            // gridColTotalOutstandingAmount
            // 
            this.gridColTotalOutstandingAmount.Caption = "Total Outstanding Amount";
            this.gridColTotalOutstandingAmount.FieldName = "TotalOutstandingAmount";
            this.gridColTotalOutstandingAmount.Name = "gridColTotalOutstandingAmount";
            this.gridColTotalOutstandingAmount.OptionsColumn.AllowEdit = false;
            this.gridColTotalOutstandingAmount.Visible = true;
            this.gridColTotalOutstandingAmount.VisibleIndex = 5;
            this.gridColTotalOutstandingAmount.Width = 188;
            // 
            // gridColExceedLimit
            // 
            this.gridColExceedLimit.Caption = "Exceed Limit";
            this.gridColExceedLimit.FieldName = "ExceedLimit";
            this.gridColExceedLimit.Name = "gridColExceedLimit";
            this.gridColExceedLimit.OptionsColumn.AllowEdit = false;
            this.gridColExceedLimit.Visible = true;
            this.gridColExceedLimit.VisibleIndex = 6;
            this.gridColExceedLimit.Width = 114;
            // 
            // gridColPosting
            // 
            this.gridColPosting.Caption = "Posting";
            this.gridColPosting.FieldName = "Posting";
            this.gridColPosting.Name = "gridColPosting";
            this.gridColPosting.OptionsColumn.AllowEdit = false;
            this.gridColPosting.Visible = true;
            this.gridColPosting.VisibleIndex = 7;
            this.gridColPosting.Width = 90;
            // 
            // panel1
            // 
            this.panel1.AutoScroll = true;
            this.panel1.Controls.Add(this.chkAll);
            this.panel1.Controls.Add(this.gridControl1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 25);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(944, 431);
            this.panel1.TabIndex = 173;
            // 
            // chkAll
            // 
            this.chkAll.Location = new System.Drawing.Point(16, 3);
            this.chkAll.Name = "chkAll";
            this.chkAll.Properties.Caption = "Select All";
            this.chkAll.Size = new System.Drawing.Size(75, 19);
            this.chkAll.TabIndex = 198;
            this.chkAll.Visible = false;
            this.chkAll.CheckedChanged += new System.EventHandler(this.chkAll_CheckedChanged);
            // 
            // CreditLine
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.menuStrip1);
            this.Name = "CreditLine";
            this.Size = new System.Drawing.Size(944, 456);
            this.Load += new System.EventHandler(this.Frm_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).EndInit();
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.chkAll.Properties)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private DevExpress.XtraGrid.GridControl gridControl1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.ToolStripMenuItem btnSEL;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView1;
        private System.Windows.Forms.ToolStripMenuItem btnExport;
        private DevExpress.XtraGrid.Columns.GridColumn gridColCustomerCode;
        private DevExpress.XtraGrid.Columns.GridColumn gridColPaymentTerm;
        private DevExpress.XtraGrid.Columns.GridColumn gridColCustomerName;
        private DevExpress.XtraGrid.Columns.GridColumn gridColCurrency;
        private DevExpress.XtraGrid.Columns.GridColumn gridColCreditLimit;
        private DevExpress.XtraGrid.Columns.GridColumn gridColTotalOutstandingAmount;
        private DevExpress.XtraGrid.Columns.GridColumn gridColExceedLimit;
        private DevExpress.XtraGrid.Columns.GridColumn gridColPosting;
        private DevExpress.XtraEditors.CheckEdit chkAll;
    }
}
