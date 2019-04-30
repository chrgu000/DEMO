namespace UFIDA.U8.UAP.CustomApp.ControlForm
{
    partial class RepCreateDisInfo
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
            this.btnReflash = new System.Windows.Forms.ToolStripMenuItem();
            this.btnExport = new System.Windows.Forms.ToolStripMenuItem();
            this.gridControl1 = new DevExpress.XtraGrid.GridControl();
            this.gridView1 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.gridColcSOCode = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColDisCode = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColRdCode = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColStatus = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColRemark = new DevExpress.XtraGrid.Columns.GridColumn();
            this.ItemButtonEditShowDetails = new DevExpress.XtraEditors.Repository.RepositoryItemButtonEdit();
            this.gridColDescription2 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColQty = new DevExpress.XtraGrid.Columns.GridColumn();
            this.panel1 = new System.Windows.Forms.Panel();
            this.radioOneMonth = new System.Windows.Forms.RadioButton();
            this.radioOneWeek = new System.Windows.Forms.RadioButton();
            this.radioOneDay = new System.Windows.Forms.RadioButton();
            this.label1 = new System.Windows.Forms.Label();
            this.lookUpEditStatus = new DevExpress.XtraEditors.LookUpEdit();
            this.menuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ItemButtonEditShowDetails)).BeginInit();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.lookUpEditStatus.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btnReflash,
            this.btnExport});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(944, 24);
            this.menuStrip1.TabIndex = 172;
            this.menuStrip1.Text = "menuStrip";
            // 
            // btnReflash
            // 
            this.btnReflash.Name = "btnReflash";
            this.btnReflash.Size = new System.Drawing.Size(41, 20);
            this.btnReflash.Text = "刷新";
            this.btnReflash.Click += new System.EventHandler(this.btnQuery_Click);
            // 
            // btnExport
            // 
            this.btnExport.Name = "btnExport";
            this.btnExport.Size = new System.Drawing.Size(71, 20);
            this.btnExport.Text = "导出Excel";
            this.btnExport.Click += new System.EventHandler(this.btnExport_Click);
            // 
            // gridControl1
            // 
            this.gridControl1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.gridControl1.Location = new System.Drawing.Point(3, 43);
            this.gridControl1.LookAndFeel.SkinName = "Office 2010 Blue";
            this.gridControl1.MainView = this.gridView1;
            this.gridControl1.Name = "gridControl1";
            this.gridControl1.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.ItemButtonEditShowDetails});
            this.gridControl1.Size = new System.Drawing.Size(938, 384);
            this.gridControl1.TabIndex = 191;
            this.gridControl1.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView1});
            // 
            // gridView1
            // 
            this.gridView1.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.gridColcSOCode,
            this.gridColDisCode,
            this.gridColRdCode,
            this.gridColStatus,
            this.gridColRemark});
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
            this.gridView1.CellValueChanged += new DevExpress.XtraGrid.Views.Base.CellValueChangedEventHandler(this.gridView1_CellValueChanged);
            // 
            // gridColcSOCode
            // 
            this.gridColcSOCode.Caption = "销售订单号";
            this.gridColcSOCode.FieldName = "cSOCode";
            this.gridColcSOCode.Name = "gridColcSOCode";
            this.gridColcSOCode.OptionsColumn.AllowEdit = false;
            this.gridColcSOCode.Visible = true;
            this.gridColcSOCode.VisibleIndex = 0;
            this.gridColcSOCode.Width = 114;
            // 
            // gridColDisCode
            // 
            this.gridColDisCode.Caption = "发货单号";
            this.gridColDisCode.FieldName = "DisCode";
            this.gridColDisCode.Name = "gridColDisCode";
            this.gridColDisCode.OptionsColumn.AllowEdit = false;
            this.gridColDisCode.Visible = true;
            this.gridColDisCode.VisibleIndex = 1;
            this.gridColDisCode.Width = 186;
            // 
            // gridColRdCode
            // 
            this.gridColRdCode.Caption = "销售出库单号";
            this.gridColRdCode.FieldName = "RdCode";
            this.gridColRdCode.Name = "gridColRdCode";
            this.gridColRdCode.OptionsColumn.AllowEdit = false;
            this.gridColRdCode.Visible = true;
            this.gridColRdCode.VisibleIndex = 2;
            this.gridColRdCode.Width = 129;
            // 
            // gridColStatus
            // 
            this.gridColStatus.Caption = "状态";
            this.gridColStatus.FieldName = "Status";
            this.gridColStatus.Name = "gridColStatus";
            this.gridColStatus.OptionsColumn.AllowEdit = false;
            this.gridColStatus.Visible = true;
            this.gridColStatus.VisibleIndex = 3;
            this.gridColStatus.Width = 143;
            // 
            // gridColRemark
            // 
            this.gridColRemark.Caption = "说明";
            this.gridColRemark.ColumnEdit = this.ItemButtonEditShowDetails;
            this.gridColRemark.FieldName = "Remark";
            this.gridColRemark.Name = "gridColRemark";
            this.gridColRemark.OptionsColumn.ReadOnly = true;
            this.gridColRemark.Visible = true;
            this.gridColRemark.VisibleIndex = 4;
            this.gridColRemark.Width = 400;
            // 
            // ItemButtonEditShowDetails
            // 
            this.ItemButtonEditShowDetails.AutoHeight = false;
            this.ItemButtonEditShowDetails.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
            this.ItemButtonEditShowDetails.Name = "ItemButtonEditShowDetails";
            this.ItemButtonEditShowDetails.ButtonClick += new DevExpress.XtraEditors.Controls.ButtonPressedEventHandler(this.ItemButtonEditShowDetails_ButtonClick);
            // 
            // gridColDescription2
            // 
            this.gridColDescription2.Caption = "Description";
            this.gridColDescription2.FieldName = "Description2";
            this.gridColDescription2.Name = "gridColDescription2";
            // 
            // gridColQty
            // 
            this.gridColQty.Caption = "Qty (Units)";
            this.gridColQty.FieldName = "Qty";
            this.gridColQty.Name = "gridColQty";
            this.gridColQty.Summary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] {
            new DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum)});
            // 
            // panel1
            // 
            this.panel1.AutoScroll = true;
            this.panel1.Controls.Add(this.radioOneMonth);
            this.panel1.Controls.Add(this.radioOneWeek);
            this.panel1.Controls.Add(this.radioOneDay);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.lookUpEditStatus);
            this.panel1.Controls.Add(this.gridControl1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 24);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(944, 432);
            this.panel1.TabIndex = 173;
            // 
            // radioOneMonth
            // 
            this.radioOneMonth.AutoSize = true;
            this.radioOneMonth.Location = new System.Drawing.Point(411, 18);
            this.radioOneMonth.Name = "radioOneMonth";
            this.radioOneMonth.Size = new System.Drawing.Size(83, 16);
            this.radioOneMonth.TabIndex = 194;
            this.radioOneMonth.Text = "最近一个月";
            this.radioOneMonth.UseVisualStyleBackColor = true;
            // 
            // radioOneWeek
            // 
            this.radioOneWeek.AutoSize = true;
            this.radioOneWeek.Location = new System.Drawing.Point(324, 18);
            this.radioOneWeek.Name = "radioOneWeek";
            this.radioOneWeek.Size = new System.Drawing.Size(71, 16);
            this.radioOneWeek.TabIndex = 194;
            this.radioOneWeek.Text = "最近一周";
            this.radioOneWeek.UseVisualStyleBackColor = true;
            // 
            // radioOneDay
            // 
            this.radioOneDay.AutoSize = true;
            this.radioOneDay.Checked = true;
            this.radioOneDay.Location = new System.Drawing.Point(242, 18);
            this.radioOneDay.Name = "radioOneDay";
            this.radioOneDay.Size = new System.Drawing.Size(47, 16);
            this.radioOneDay.TabIndex = 194;
            this.radioOneDay.TabStop = true;
            this.radioOneDay.Text = "当天";
            this.radioOneDay.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(40, 22);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(29, 12);
            this.label1.TabIndex = 193;
            this.label1.Text = "状态";
            // 
            // lookUpEditStatus
            // 
            this.lookUpEditStatus.Location = new System.Drawing.Point(98, 17);
            this.lookUpEditStatus.Name = "lookUpEditStatus";
            this.lookUpEditStatus.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.lookUpEditStatus.Properties.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("Status", "Status")});
            this.lookUpEditStatus.Properties.DisplayMember = "Status";
            this.lookUpEditStatus.Properties.NullText = "";
            this.lookUpEditStatus.Properties.ValueMember = "Status";
            this.lookUpEditStatus.Size = new System.Drawing.Size(100, 20);
            this.lookUpEditStatus.TabIndex = 192;
            // 
            // RepCreateDisInfo
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.menuStrip1);
            this.Name = "RepCreateDisInfo";
            this.Size = new System.Drawing.Size(944, 456);
            this.Load += new System.EventHandler(this.Frm_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ItemButtonEditShowDetails)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.lookUpEditStatus.Properties)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private DevExpress.XtraGrid.GridControl gridControl1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.ToolStripMenuItem btnReflash;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView1;
        private DevExpress.XtraGrid.Columns.GridColumn gridColDisCode;
        private DevExpress.XtraGrid.Columns.GridColumn gridColStatus;
        private DevExpress.XtraGrid.Columns.GridColumn gridColDescription2;
        private DevExpress.XtraGrid.Columns.GridColumn gridColQty;
        private DevExpress.XtraGrid.Columns.GridColumn gridColRdCode;
        private DevExpress.XtraGrid.Columns.GridColumn gridColcSOCode;
        private System.Windows.Forms.ToolStripMenuItem btnExport;
        private DevExpress.XtraGrid.Columns.GridColumn gridColRemark;
        private System.Windows.Forms.Label label1;
        private DevExpress.XtraEditors.LookUpEdit lookUpEditStatus;
        private System.Windows.Forms.RadioButton radioOneMonth;
        private System.Windows.Forms.RadioButton radioOneWeek;
        private System.Windows.Forms.RadioButton radioOneDay;
        private DevExpress.XtraEditors.Repository.RepositoryItemButtonEdit ItemButtonEditShowDetails;
    }
}
