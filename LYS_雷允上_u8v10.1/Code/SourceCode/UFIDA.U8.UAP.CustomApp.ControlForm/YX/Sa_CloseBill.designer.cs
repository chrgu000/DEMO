namespace UFIDA.U8.UAP.CustomApp.ControlForm
{
    partial class Sa_CloseBill
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Sa_CloseBill));
            this.splitContainerControl1 = new DevExpress.XtraEditors.SplitContainerControl();
            this.panel1 = new System.Windows.Forms.Panel();
            this.checkEdit1 = new DevExpress.XtraEditors.CheckEdit();
            this.dateCreate2 = new DevExpress.XtraEditors.DateEdit();
            this.dateCreate = new DevExpress.XtraEditors.DateEdit();
            this.comboBoxEdit1 = new DevExpress.XtraEditors.ComboBoxEdit();
            this.label6 = new System.Windows.Forms.Label();
            this.txt票据号 = new DevExpress.XtraEditors.TextEdit();
            this.cmb票据号 = new DevExpress.XtraEditors.ComboBoxEdit();
            this.label1 = new System.Windows.Forms.Label();
            this.btnExcel = new DevExpress.XtraEditors.SimpleButton();
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            this.btnRefresh = new DevExpress.XtraEditors.SimpleButton();
            this.grdDetail = new DevExpress.XtraGrid.GridControl();
            this.gridView1 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.gridColChk = new DevExpress.XtraGrid.Columns.GridColumn();
            this.ItemChk = new DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit();
            this.gridCol收款单号 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridCol收款日期 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridCol结算方式 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.ItemLookUpEdit结算方式 = new DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit();
            this.gridCol制单日期 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridCol制单人 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridCol原币金额 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridCol本币金额 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColiID = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridCol客户 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.ItemLookUpEdit客户 = new DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerControl1)).BeginInit();
            this.splitContainerControl1.SuspendLayout();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.checkEdit1.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dateCreate2.Properties.VistaTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dateCreate2.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dateCreate.Properties.VistaTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dateCreate.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.comboBoxEdit1.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txt票据号.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cmb票据号.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdDetail)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ItemChk)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ItemLookUpEdit结算方式)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ItemLookUpEdit客户)).BeginInit();
            this.SuspendLayout();
            // 
            // splitContainerControl1
            // 
            this.splitContainerControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainerControl1.Horizontal = false;
            this.splitContainerControl1.Location = new System.Drawing.Point(0, 0);
            this.splitContainerControl1.Name = "splitContainerControl1";
            this.splitContainerControl1.Panel1.Controls.Add(this.panel1);
            this.splitContainerControl1.Panel1.Text = "Panel1";
            this.splitContainerControl1.Panel2.Controls.Add(this.grdDetail);
            this.splitContainerControl1.Panel2.Text = "Panel2";
            this.splitContainerControl1.Size = new System.Drawing.Size(986, 600);
            this.splitContainerControl1.SplitterPosition = 107;
            this.splitContainerControl1.TabIndex = 0;
            this.splitContainerControl1.Text = "splitContainerControl1";
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.checkEdit1);
            this.panel1.Controls.Add(this.dateCreate2);
            this.panel1.Controls.Add(this.dateCreate);
            this.panel1.Controls.Add(this.comboBoxEdit1);
            this.panel1.Controls.Add(this.label6);
            this.panel1.Controls.Add(this.txt票据号);
            this.panel1.Controls.Add(this.cmb票据号);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.btnExcel);
            this.panel1.Controls.Add(this.labelControl1);
            this.panel1.Controls.Add(this.btnRefresh);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(986, 107);
            this.panel1.TabIndex = 0;
            // 
            // checkEdit1
            // 
            this.checkEdit1.Location = new System.Drawing.Point(47, 85);
            this.checkEdit1.Name = "checkEdit1";
            this.checkEdit1.Properties.Caption = "全选";
            this.checkEdit1.Size = new System.Drawing.Size(75, 19);
            this.checkEdit1.TabIndex = 49;
            this.checkEdit1.CheckedChanged += new System.EventHandler(this.checkEdit1_CheckedChanged);
            // 
            // dateCreate2
            // 
            this.dateCreate2.EditValue = null;
            this.dateCreate2.Location = new System.Drawing.Point(489, 48);
            this.dateCreate2.Name = "dateCreate2";
            this.dateCreate2.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.dateCreate2.Properties.VistaTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
            this.dateCreate2.Size = new System.Drawing.Size(123, 20);
            this.dateCreate2.TabIndex = 48;
            // 
            // dateCreate
            // 
            this.dateCreate.EditValue = null;
            this.dateCreate.Location = new System.Drawing.Point(360, 48);
            this.dateCreate.Name = "dateCreate";
            this.dateCreate.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.dateCreate.Properties.VistaTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
            this.dateCreate.Size = new System.Drawing.Size(123, 20);
            this.dateCreate.TabIndex = 47;
            // 
            // comboBoxEdit1
            // 
            this.comboBoxEdit1.EditValue = "=";
            this.comboBoxEdit1.Location = new System.Drawing.Point(320, 48);
            this.comboBoxEdit1.Name = "comboBoxEdit1";
            this.comboBoxEdit1.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.comboBoxEdit1.Properties.Items.AddRange(new object[] {
            "like",
            "=",
            ">",
            ">=",
            "<",
            "<="});
            this.comboBoxEdit1.Size = new System.Drawing.Size(34, 20);
            this.comboBoxEdit1.TabIndex = 46;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.ForeColor = System.Drawing.Color.Blue;
            this.label6.Location = new System.Drawing.Point(261, 53);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(53, 12);
            this.label6.TabIndex = 45;
            this.label6.Text = "票据日期";
            // 
            // txt票据号
            // 
            this.txt票据号.Location = new System.Drawing.Point(112, 48);
            this.txt票据号.Name = "txt票据号";
            this.txt票据号.Size = new System.Drawing.Size(101, 20);
            this.txt票据号.TabIndex = 32;
            // 
            // cmb票据号
            // 
            this.cmb票据号.EditValue = "like";
            this.cmb票据号.Location = new System.Drawing.Point(66, 48);
            this.cmb票据号.Name = "cmb票据号";
            this.cmb票据号.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.cmb票据号.Properties.Items.AddRange(new object[] {
            "like",
            "=",
            ">",
            ">=",
            "<",
            "<="});
            this.cmb票据号.Size = new System.Drawing.Size(40, 20);
            this.cmb票据号.TabIndex = 31;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.ForeColor = System.Drawing.Color.Blue;
            this.label1.Location = new System.Drawing.Point(7, 53);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(41, 12);
            this.label1.TabIndex = 30;
            this.label1.Text = "票据号";
            // 
            // btnExcel
            // 
            this.btnExcel.Image = ((System.Drawing.Image)(resources.GetObject("btnExcel.Image")));
            this.btnExcel.ImageLocation = DevExpress.XtraEditors.ImageLocation.TopCenter;
            this.btnExcel.Location = new System.Drawing.Point(902, 51);
            this.btnExcel.Name = "btnExcel";
            this.btnExcel.Size = new System.Drawing.Size(61, 41);
            this.btnExcel.TabIndex = 28;
            this.btnExcel.Text = "导出";
            this.btnExcel.Click += new System.EventHandler(this.btnExcel_Click);
            // 
            // labelControl1
            // 
            this.labelControl1.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.labelControl1.Appearance.Font = new System.Drawing.Font("Tahoma", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelControl1.Location = new System.Drawing.Point(416, 3);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(63, 25);
            this.labelControl1.TabIndex = 23;
            this.labelControl1.Text = "收款单";
            // 
            // btnRefresh
            // 
            this.btnRefresh.Image = ((System.Drawing.Image)(resources.GetObject("btnRefresh.Image")));
            this.btnRefresh.ImageLocation = DevExpress.XtraEditors.ImageLocation.TopCenter;
            this.btnRefresh.Location = new System.Drawing.Point(835, 51);
            this.btnRefresh.Name = "btnRefresh";
            this.btnRefresh.Size = new System.Drawing.Size(61, 41);
            this.btnRefresh.TabIndex = 21;
            this.btnRefresh.Text = "过滤";
            this.btnRefresh.Click += new System.EventHandler(this.btnRefresh_Click);
            // 
            // grdDetail
            // 
            this.grdDetail.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.grdDetail.Location = new System.Drawing.Point(3, 1);
            this.grdDetail.LookAndFeel.SkinName = "Office 2010 Blue";
            this.grdDetail.MainView = this.gridView1;
            this.grdDetail.Name = "grdDetail";
            this.grdDetail.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.ItemChk,
            this.ItemLookUpEdit结算方式,
            this.ItemLookUpEdit客户});
            this.grdDetail.Size = new System.Drawing.Size(983, 484);
            this.grdDetail.TabIndex = 100;
            this.grdDetail.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView1});
            // 
            // gridView1
            // 
            this.gridView1.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.gridColChk,
            this.gridCol收款单号,
            this.gridCol收款日期,
            this.gridCol结算方式,
            this.gridCol制单日期,
            this.gridCol制单人,
            this.gridCol原币金额,
            this.gridCol本币金额,
            this.gridColiID,
            this.gridCol客户});
            this.gridView1.GridControl = this.grdDetail;
            this.gridView1.IndicatorWidth = 30;
            this.gridView1.Name = "gridView1";
            this.gridView1.OptionsBehavior.AllowDeleteRows = DevExpress.Utils.DefaultBoolean.True;
            this.gridView1.OptionsBehavior.EditorShowMode = DevExpress.Utils.EditorShowMode.MouseDown;
            this.gridView1.OptionsCustomization.AllowFilter = false;
            this.gridView1.OptionsCustomization.AllowGroup = false;
            this.gridView1.OptionsCustomization.AllowQuickHideColumns = false;
            this.gridView1.OptionsCustomization.AllowSort = false;
            this.gridView1.OptionsView.ColumnAutoWidth = false;
            this.gridView1.OptionsView.ShowGroupPanel = false;
            this.gridView1.DoubleClick += new System.EventHandler(this.gridView1_DoubleClick);
            // 
            // gridColChk
            // 
            this.gridColChk.Caption = " ";
            this.gridColChk.ColumnEdit = this.ItemChk;
            this.gridColChk.FieldName = "ischk";
            this.gridColChk.Name = "gridColChk";
            this.gridColChk.Visible = true;
            this.gridColChk.VisibleIndex = 0;
            this.gridColChk.Width = 42;
            // 
            // ItemChk
            // 
            this.ItemChk.AutoHeight = false;
            this.ItemChk.Name = "ItemChk";
            // 
            // gridCol收款单号
            // 
            this.gridCol收款单号.Caption = "收款单号";
            this.gridCol收款单号.FieldName = "cVouchID";
            this.gridCol收款单号.Name = "gridCol收款单号";
            this.gridCol收款单号.OptionsColumn.AllowEdit = false;
            this.gridCol收款单号.OptionsColumn.ReadOnly = true;
            this.gridCol收款单号.Visible = true;
            this.gridCol收款单号.VisibleIndex = 1;
            this.gridCol收款单号.Width = 138;
            // 
            // gridCol收款日期
            // 
            this.gridCol收款日期.Caption = "收款日期";
            this.gridCol收款日期.FieldName = "dVouchDate";
            this.gridCol收款日期.Name = "gridCol收款日期";
            this.gridCol收款日期.OptionsColumn.AllowEdit = false;
            this.gridCol收款日期.OptionsColumn.ReadOnly = true;
            this.gridCol收款日期.Visible = true;
            this.gridCol收款日期.VisibleIndex = 2;
            // 
            // gridCol结算方式
            // 
            this.gridCol结算方式.Caption = "结算方式";
            this.gridCol结算方式.ColumnEdit = this.ItemLookUpEdit结算方式;
            this.gridCol结算方式.FieldName = "cSSCode";
            this.gridCol结算方式.Name = "gridCol结算方式";
            this.gridCol结算方式.OptionsColumn.AllowEdit = false;
            this.gridCol结算方式.OptionsColumn.ReadOnly = true;
            this.gridCol结算方式.Visible = true;
            this.gridCol结算方式.VisibleIndex = 6;
            // 
            // ItemLookUpEdit结算方式
            // 
            this.ItemLookUpEdit结算方式.AutoHeight = false;
            this.ItemLookUpEdit结算方式.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.ItemLookUpEdit结算方式.Name = "ItemLookUpEdit结算方式";
            // 
            // gridCol制单日期
            // 
            this.gridCol制单日期.Caption = "制单日期";
            this.gridCol制单日期.FieldName = "dcreatesystime";
            this.gridCol制单日期.Name = "gridCol制单日期";
            this.gridCol制单日期.OptionsColumn.AllowEdit = false;
            this.gridCol制单日期.OptionsColumn.ReadOnly = true;
            this.gridCol制单日期.Visible = true;
            this.gridCol制单日期.VisibleIndex = 5;
            this.gridCol制单日期.Width = 82;
            // 
            // gridCol制单人
            // 
            this.gridCol制单人.Caption = "制单人";
            this.gridCol制单人.FieldName = "cOperator";
            this.gridCol制单人.Name = "gridCol制单人";
            this.gridCol制单人.OptionsColumn.AllowEdit = false;
            this.gridCol制单人.OptionsColumn.ReadOnly = true;
            this.gridCol制单人.Summary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] {
            new DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "gridCol合计", "{0:n2}")});
            this.gridCol制单人.UnboundType = DevExpress.Data.UnboundColumnType.Decimal;
            this.gridCol制单人.Visible = true;
            this.gridCol制单人.VisibleIndex = 4;
            this.gridCol制单人.Width = 86;
            // 
            // gridCol原币金额
            // 
            this.gridCol原币金额.Caption = "原币金额";
            this.gridCol原币金额.FieldName = "iAmount_f";
            this.gridCol原币金额.Name = "gridCol原币金额";
            this.gridCol原币金额.OptionsColumn.AllowEdit = false;
            this.gridCol原币金额.OptionsColumn.ReadOnly = true;
            this.gridCol原币金额.Visible = true;
            this.gridCol原币金额.VisibleIndex = 7;
            // 
            // gridCol本币金额
            // 
            this.gridCol本币金额.Caption = "本币金额";
            this.gridCol本币金额.FieldName = "iAmount";
            this.gridCol本币金额.Name = "gridCol本币金额";
            this.gridCol本币金额.OptionsColumn.AllowEdit = false;
            this.gridCol本币金额.OptionsColumn.ReadOnly = true;
            this.gridCol本币金额.Visible = true;
            this.gridCol本币金额.VisibleIndex = 8;
            // 
            // gridColiID
            // 
            this.gridColiID.Caption = "iID";
            this.gridColiID.FieldName = "iID";
            this.gridColiID.Name = "gridColiID";
            this.gridColiID.OptionsColumn.AllowEdit = false;
            this.gridColiID.OptionsColumn.ReadOnly = true;
            // 
            // gridCol客户
            // 
            this.gridCol客户.Caption = "客户";
            this.gridCol客户.ColumnEdit = this.ItemLookUpEdit客户;
            this.gridCol客户.FieldName = "cDwCode";
            this.gridCol客户.Name = "gridCol客户";
            this.gridCol客户.OptionsColumn.AllowEdit = false;
            this.gridCol客户.OptionsColumn.ReadOnly = true;
            this.gridCol客户.Visible = true;
            this.gridCol客户.VisibleIndex = 3;
            this.gridCol客户.Width = 152;
            // 
            // ItemLookUpEdit客户
            // 
            this.ItemLookUpEdit客户.AutoHeight = false;
            this.ItemLookUpEdit客户.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.ItemLookUpEdit客户.Name = "ItemLookUpEdit客户";
            // 
            // Sa_CloseBill
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.splitContainerControl1);
            this.Name = "Sa_CloseBill";
            this.Size = new System.Drawing.Size(986, 600);
            this.Load += new System.EventHandler(this.Sa_CloseBill_Load);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerControl1)).EndInit();
            this.splitContainerControl1.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.checkEdit1.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dateCreate2.Properties.VistaTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dateCreate2.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dateCreate.Properties.VistaTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dateCreate.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.comboBoxEdit1.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txt票据号.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cmb票据号.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdDetail)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ItemChk)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ItemLookUpEdit结算方式)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ItemLookUpEdit客户)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.SplitContainerControl splitContainerControl1;
        private System.Windows.Forms.Panel panel1;
        private DevExpress.XtraEditors.SimpleButton btnRefresh;
        private DevExpress.XtraGrid.GridControl grdDetail;
        private DevExpress.XtraEditors.LabelControl labelControl1;
        private DevExpress.XtraEditors.SimpleButton btnExcel;
        private DevExpress.XtraEditors.TextEdit txt票据号;
        private DevExpress.XtraEditors.ComboBoxEdit cmb票据号;
        private System.Windows.Forms.Label label1;
        private DevExpress.XtraEditors.ComboBoxEdit comboBoxEdit1;
        private System.Windows.Forms.Label label6;
        private DevExpress.XtraEditors.DateEdit dateCreate;
        private DevExpress.XtraEditors.DateEdit dateCreate2;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView1;
        private DevExpress.XtraGrid.Columns.GridColumn gridCol制单日期;
        private DevExpress.XtraGrid.Columns.GridColumn gridCol制单人;
        private DevExpress.XtraGrid.Columns.GridColumn gridCol结算方式;
        private DevExpress.XtraGrid.Columns.GridColumn gridCol收款日期;
        private DevExpress.XtraGrid.Columns.GridColumn gridCol原币金额;
        private DevExpress.XtraGrid.Columns.GridColumn gridCol本币金额;
        private DevExpress.XtraGrid.Columns.GridColumn gridColChk;
        private DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit ItemChk;
        private DevExpress.XtraEditors.CheckEdit checkEdit1;
        private DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit ItemLookUpEdit结算方式;
        private DevExpress.XtraGrid.Columns.GridColumn gridCol收款单号;
        private DevExpress.XtraGrid.Columns.GridColumn gridColiID;
        private DevExpress.XtraGrid.Columns.GridColumn gridCol客户;
        private DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit ItemLookUpEdit客户;
    }
}
