namespace UFIDA.U8.UAP.CustomApp.ControlForm
{
    partial class 回款导入_SZ
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
            this.btnLoadExcel = new System.Windows.Forms.ToolStripMenuItem();
            this.btnSEL = new System.Windows.Forms.ToolStripMenuItem();
            this.btnDel = new System.Windows.Forms.ToolStripMenuItem();
            this.btnSave = new System.Windows.Forms.ToolStripMenuItem();
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            this.panel1 = new System.Windows.Forms.Panel();
            this.gridControl1 = new DevExpress.XtraGrid.GridControl();
            this.gridView1 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.gridCol_选择 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridCol_收款单号 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridCol_收款单日期 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridCol_收款单金额 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridCol_业务员编码 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridCol_业务员 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridCol_核销金额 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridCol_核销日期 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridCol_发票号码 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridCol_发票日期 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridCol_销售组织 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridCol_客户编码 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridCol_客户名称 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridCol_发票金额 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridCol_货币单位 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridCol_分配 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridCol_金税发票号码 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridCol_清帐凭证号 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridCol_已使用 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridCol_iID = new DevExpress.XtraGrid.Columns.GridColumn();
            this.txt收款单号 = new DevExpress.XtraEditors.TextEdit();
            this.label1 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.chkAll = new System.Windows.Forms.CheckBox();
            this.lookUpEditYear = new DevExpress.XtraEditors.LookUpEdit();
            this.lookUpEditMonth = new DevExpress.XtraEditors.LookUpEdit();
            this.menuStrip1.SuspendLayout();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txt收款单号.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lookUpEditYear.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lookUpEditMonth.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btnLoadExcel,
            this.btnSEL,
            this.btnDel,
            this.btnSave});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(903, 25);
            this.menuStrip1.TabIndex = 172;
            this.menuStrip1.Text = "menuStrip";
            // 
            // btnLoadExcel
            // 
            this.btnLoadExcel.Name = "btnLoadExcel";
            this.btnLoadExcel.Size = new System.Drawing.Size(73, 21);
            this.btnLoadExcel.Text = "加载Excel";
            this.btnLoadExcel.Click += new System.EventHandler(this.btnLoadExcel_Click);
            // 
            // btnSEL
            // 
            this.btnSEL.Name = "btnSEL";
            this.btnSEL.Size = new System.Drawing.Size(44, 21);
            this.btnSEL.Text = "过滤";
            this.btnSEL.Click += new System.EventHandler(this.btnSEL_Click);
            // 
            // btnDel
            // 
            this.btnDel.Name = "btnDel";
            this.btnDel.Size = new System.Drawing.Size(44, 21);
            this.btnDel.Text = "删除";
            this.btnDel.Click += new System.EventHandler(this.btnDel_Click);
            // 
            // btnSave
            // 
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(44, 21);
            this.btnSave.Text = "保存";
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // labelControl1
            // 
            this.labelControl1.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.labelControl1.Appearance.Font = new System.Drawing.Font("Tahoma", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelControl1.Location = new System.Drawing.Point(373, 0);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(142, 25);
            this.labelControl1.TabIndex = 190;
            this.labelControl1.Text = "回款导入(苏州)";
            // 
            // panel1
            // 
            this.panel1.AutoScroll = true;
            this.panel1.Controls.Add(this.gridControl1);
            this.panel1.Controls.Add(this.txt收款单号);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.chkAll);
            this.panel1.Controls.Add(this.labelControl1);
            this.panel1.Controls.Add(this.lookUpEditYear);
            this.panel1.Controls.Add(this.lookUpEditMonth);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 25);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(903, 392);
            this.panel1.TabIndex = 173;
            // 
            // gridControl1
            // 
            this.gridControl1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.gridControl1.Location = new System.Drawing.Point(3, 73);
            this.gridControl1.LookAndFeel.SkinName = "Office 2010 Blue";
            this.gridControl1.MainView = this.gridView1;
            this.gridControl1.Name = "gridControl1";
            this.gridControl1.Size = new System.Drawing.Size(897, 316);
            this.gridControl1.TabIndex = 255;
            this.gridControl1.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView1});
            // 
            // gridView1
            // 
            this.gridView1.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.gridCol_选择,
            this.gridCol_收款单号,
            this.gridCol_收款单日期,
            this.gridCol_收款单金额,
            this.gridCol_业务员编码,
            this.gridCol_业务员,
            this.gridCol_核销金额,
            this.gridCol_核销日期,
            this.gridCol_发票号码,
            this.gridCol_发票日期,
            this.gridCol_销售组织,
            this.gridCol_客户编码,
            this.gridCol_客户名称,
            this.gridCol_发票金额,
            this.gridCol_货币单位,
            this.gridCol_分配,
            this.gridCol_金税发票号码,
            this.gridCol_清帐凭证号,
            this.gridCol_已使用,
            this.gridCol_iID});
            this.gridView1.GridControl = this.gridControl1;
            this.gridView1.IndicatorWidth = 40;
            this.gridView1.Name = "gridView1";
            this.gridView1.OptionsBehavior.AllowDeleteRows = DevExpress.Utils.DefaultBoolean.True;
            this.gridView1.OptionsBehavior.EditorShowMode = DevExpress.Utils.EditorShowMode.MouseDown;
            this.gridView1.OptionsCustomization.AllowGroup = false;
            this.gridView1.OptionsCustomization.AllowQuickHideColumns = false;
            this.gridView1.OptionsNavigation.EnterMoveNextColumn = true;
            this.gridView1.OptionsView.ColumnAutoWidth = false;
            this.gridView1.OptionsView.ShowFooter = true;
            this.gridView1.OptionsView.ShowGroupPanel = false;
            this.gridView1.CustomDrawRowIndicator += new DevExpress.XtraGrid.Views.Grid.RowIndicatorCustomDrawEventHandler(this.gridView1_CustomDrawRowIndicator);
            // 
            // gridCol_选择
            // 
            this.gridCol_选择.Caption = "选择";
            this.gridCol_选择.FieldName = "choose";
            this.gridCol_选择.Name = "gridCol_选择";
            this.gridCol_选择.Visible = true;
            this.gridCol_选择.VisibleIndex = 0;
            this.gridCol_选择.Width = 40;
            // 
            // gridCol_收款单号
            // 
            this.gridCol_收款单号.Caption = "收款单号";
            this.gridCol_收款单号.FieldName = "收款单号";
            this.gridCol_收款单号.Name = "gridCol_收款单号";
            this.gridCol_收款单号.OptionsColumn.AllowEdit = false;
            this.gridCol_收款单号.Visible = true;
            this.gridCol_收款单号.VisibleIndex = 1;
            // 
            // gridCol_收款单日期
            // 
            this.gridCol_收款单日期.Caption = "收款单日期";
            this.gridCol_收款单日期.FieldName = "收款单日期";
            this.gridCol_收款单日期.Name = "gridCol_收款单日期";
            this.gridCol_收款单日期.OptionsColumn.AllowEdit = false;
            this.gridCol_收款单日期.Visible = true;
            this.gridCol_收款单日期.VisibleIndex = 2;
            // 
            // gridCol_收款单金额
            // 
            this.gridCol_收款单金额.Caption = "收款单金额";
            this.gridCol_收款单金额.FieldName = "收款单金额";
            this.gridCol_收款单金额.Name = "gridCol_收款单金额";
            this.gridCol_收款单金额.OptionsColumn.AllowEdit = false;
            this.gridCol_收款单金额.Visible = true;
            this.gridCol_收款单金额.VisibleIndex = 3;
            // 
            // gridCol_业务员编码
            // 
            this.gridCol_业务员编码.Caption = "业务员编码";
            this.gridCol_业务员编码.FieldName = "业务员编码";
            this.gridCol_业务员编码.Name = "gridCol_业务员编码";
            this.gridCol_业务员编码.OptionsColumn.AllowEdit = false;
            this.gridCol_业务员编码.Visible = true;
            this.gridCol_业务员编码.VisibleIndex = 4;
            // 
            // gridCol_业务员
            // 
            this.gridCol_业务员.Caption = "业务员";
            this.gridCol_业务员.FieldName = "业务员";
            this.gridCol_业务员.Name = "gridCol_业务员";
            this.gridCol_业务员.OptionsColumn.AllowEdit = false;
            this.gridCol_业务员.Visible = true;
            this.gridCol_业务员.VisibleIndex = 5;
            // 
            // gridCol_核销金额
            // 
            this.gridCol_核销金额.Caption = "核销金额";
            this.gridCol_核销金额.FieldName = "核销金额";
            this.gridCol_核销金额.Name = "gridCol_核销金额";
            this.gridCol_核销金额.OptionsColumn.AllowEdit = false;
            this.gridCol_核销金额.Visible = true;
            this.gridCol_核销金额.VisibleIndex = 6;
            // 
            // gridCol_核销日期
            // 
            this.gridCol_核销日期.Caption = "核销日期";
            this.gridCol_核销日期.FieldName = "核销日期";
            this.gridCol_核销日期.Name = "gridCol_核销日期";
            this.gridCol_核销日期.OptionsColumn.AllowEdit = false;
            this.gridCol_核销日期.Visible = true;
            this.gridCol_核销日期.VisibleIndex = 7;
            // 
            // gridCol_发票号码
            // 
            this.gridCol_发票号码.Caption = "发票号码";
            this.gridCol_发票号码.FieldName = "发票号码";
            this.gridCol_发票号码.Name = "gridCol_发票号码";
            this.gridCol_发票号码.OptionsColumn.AllowEdit = false;
            this.gridCol_发票号码.Visible = true;
            this.gridCol_发票号码.VisibleIndex = 8;
            // 
            // gridCol_发票日期
            // 
            this.gridCol_发票日期.Caption = "发票日期";
            this.gridCol_发票日期.FieldName = "发票日期";
            this.gridCol_发票日期.Name = "gridCol_发票日期";
            this.gridCol_发票日期.OptionsColumn.AllowEdit = false;
            this.gridCol_发票日期.Visible = true;
            this.gridCol_发票日期.VisibleIndex = 9;
            // 
            // gridCol_销售组织
            // 
            this.gridCol_销售组织.Caption = "销售组织";
            this.gridCol_销售组织.FieldName = "销售组织";
            this.gridCol_销售组织.Name = "gridCol_销售组织";
            this.gridCol_销售组织.OptionsColumn.AllowEdit = false;
            this.gridCol_销售组织.Visible = true;
            this.gridCol_销售组织.VisibleIndex = 10;
            // 
            // gridCol_客户编码
            // 
            this.gridCol_客户编码.Caption = "客户编码";
            this.gridCol_客户编码.FieldName = "客户编码";
            this.gridCol_客户编码.Name = "gridCol_客户编码";
            this.gridCol_客户编码.OptionsColumn.AllowEdit = false;
            this.gridCol_客户编码.Visible = true;
            this.gridCol_客户编码.VisibleIndex = 11;
            // 
            // gridCol_客户名称
            // 
            this.gridCol_客户名称.Caption = "客户名称";
            this.gridCol_客户名称.FieldName = "客户名称";
            this.gridCol_客户名称.Name = "gridCol_客户名称";
            this.gridCol_客户名称.OptionsColumn.AllowEdit = false;
            this.gridCol_客户名称.Visible = true;
            this.gridCol_客户名称.VisibleIndex = 12;
            // 
            // gridCol_发票金额
            // 
            this.gridCol_发票金额.Caption = "发票金额";
            this.gridCol_发票金额.FieldName = "发票金额";
            this.gridCol_发票金额.Name = "gridCol_发票金额";
            this.gridCol_发票金额.OptionsColumn.AllowEdit = false;
            this.gridCol_发票金额.Visible = true;
            this.gridCol_发票金额.VisibleIndex = 13;
            // 
            // gridCol_货币单位
            // 
            this.gridCol_货币单位.Caption = "货币单位";
            this.gridCol_货币单位.FieldName = "货币单位";
            this.gridCol_货币单位.Name = "gridCol_货币单位";
            this.gridCol_货币单位.OptionsColumn.AllowEdit = false;
            this.gridCol_货币单位.Visible = true;
            this.gridCol_货币单位.VisibleIndex = 14;
            // 
            // gridCol_分配
            // 
            this.gridCol_分配.Caption = "分配";
            this.gridCol_分配.FieldName = "分配";
            this.gridCol_分配.Name = "gridCol_分配";
            this.gridCol_分配.OptionsColumn.AllowEdit = false;
            this.gridCol_分配.Visible = true;
            this.gridCol_分配.VisibleIndex = 15;
            // 
            // gridCol_金税发票号码
            // 
            this.gridCol_金税发票号码.Caption = "金税发票号码";
            this.gridCol_金税发票号码.FieldName = "金税发票号码";
            this.gridCol_金税发票号码.Name = "gridCol_金税发票号码";
            this.gridCol_金税发票号码.OptionsColumn.AllowEdit = false;
            this.gridCol_金税发票号码.Visible = true;
            this.gridCol_金税发票号码.VisibleIndex = 16;
            // 
            // gridCol_清帐凭证号
            // 
            this.gridCol_清帐凭证号.Caption = "清帐凭证号";
            this.gridCol_清帐凭证号.FieldName = "清帐凭证号";
            this.gridCol_清帐凭证号.Name = "gridCol_清帐凭证号";
            this.gridCol_清帐凭证号.OptionsColumn.AllowEdit = false;
            this.gridCol_清帐凭证号.Visible = true;
            this.gridCol_清帐凭证号.VisibleIndex = 17;
            // 
            // gridCol_已使用
            // 
            this.gridCol_已使用.Caption = "已使用";
            this.gridCol_已使用.FieldName = "已使用";
            this.gridCol_已使用.Name = "gridCol_已使用";
            this.gridCol_已使用.OptionsColumn.AllowEdit = false;
            // 
            // gridCol_iID
            // 
            this.gridCol_iID.Caption = "iID";
            this.gridCol_iID.FieldName = "iID";
            this.gridCol_iID.Name = "gridCol_iID";
            this.gridCol_iID.OptionsColumn.AllowEdit = false;
            // 
            // txt收款单号
            // 
            this.txt收款单号.Enabled = false;
            this.txt收款单号.Location = new System.Drawing.Point(272, 27);
            this.txt收款单号.Name = "txt收款单号";
            this.txt收款单号.Properties.DisplayFormat.FormatString = "n2";
            this.txt收款单号.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.txt收款单号.Properties.EditFormat.FormatString = "n2";
            this.txt收款单号.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.txt收款单号.Size = new System.Drawing.Size(122, 20);
            this.txt收款单号.TabIndex = 254;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(213, 31);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(53, 12);
            this.label1.TabIndex = 253;
            this.label1.Text = "收款单号";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(13, 31);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(53, 12);
            this.label3.TabIndex = 252;
            this.label3.Text = "收款期间";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // chkAll
            // 
            this.chkAll.AutoSize = true;
            this.chkAll.Location = new System.Drawing.Point(15, 51);
            this.chkAll.Name = "chkAll";
            this.chkAll.Size = new System.Drawing.Size(48, 16);
            this.chkAll.TabIndex = 251;
            this.chkAll.Text = "全选";
            this.chkAll.UseVisualStyleBackColor = true;
            this.chkAll.CheckedChanged += new System.EventHandler(this.chkAll_CheckedChanged);
            // 
            // lookUpEditYear
            // 
            this.lookUpEditYear.AllowHtmlTextInToolTip = DevExpress.Utils.DefaultBoolean.True;
            this.lookUpEditYear.Location = new System.Drawing.Point(70, 27);
            this.lookUpEditYear.Name = "lookUpEditYear";
            this.lookUpEditYear.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.lookUpEditYear.Properties.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("iYear", "年")});
            this.lookUpEditYear.Properties.DisplayMember = "iYear";
            this.lookUpEditYear.Properties.NullText = "";
            this.lookUpEditYear.Properties.PopupWidth = 400;
            this.lookUpEditYear.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.Standard;
            this.lookUpEditYear.Properties.ValueMember = "iYear";
            this.lookUpEditYear.Size = new System.Drawing.Size(61, 20);
            this.lookUpEditYear.TabIndex = 246;
            // 
            // lookUpEditMonth
            // 
            this.lookUpEditMonth.AllowHtmlTextInToolTip = DevExpress.Utils.DefaultBoolean.True;
            this.lookUpEditMonth.Location = new System.Drawing.Point(137, 27);
            this.lookUpEditMonth.Name = "lookUpEditMonth";
            this.lookUpEditMonth.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.lookUpEditMonth.Properties.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("iMonth", "月")});
            this.lookUpEditMonth.Properties.DisplayMember = "iMonth";
            this.lookUpEditMonth.Properties.NullText = "";
            this.lookUpEditMonth.Properties.PopupWidth = 400;
            this.lookUpEditMonth.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.Standard;
            this.lookUpEditMonth.Properties.ValueMember = "iMonth";
            this.lookUpEditMonth.Size = new System.Drawing.Size(51, 20);
            this.lookUpEditMonth.TabIndex = 241;
            // 
            // 回款导入_SZ
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.menuStrip1);
            this.Name = "回款导入_SZ";
            this.Size = new System.Drawing.Size(903, 417);
            this.Load += new System.EventHandler(this.Frm_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txt收款单号.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lookUpEditYear.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lookUpEditMonth.Properties)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem btnDel;
        private System.Windows.Forms.ToolStripMenuItem btnSave;
        private DevExpress.XtraEditors.LabelControl labelControl1;
        private System.Windows.Forms.Panel panel1;
        private DevExpress.XtraEditors.LookUpEdit lookUpEditMonth;
        private DevExpress.XtraEditors.LookUpEdit lookUpEditYear;
        private System.Windows.Forms.CheckBox chkAll;
        private System.Windows.Forms.ToolStripMenuItem btnLoadExcel;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ToolStripMenuItem btnSEL;
        private System.Windows.Forms.Label label1;
        private DevExpress.XtraEditors.TextEdit txt收款单号;
        private DevExpress.XtraGrid.GridControl gridControl1;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView1;
        private DevExpress.XtraGrid.Columns.GridColumn gridCol_收款单号;
        private DevExpress.XtraGrid.Columns.GridColumn gridCol_收款单日期;
        private DevExpress.XtraGrid.Columns.GridColumn gridCol_收款单金额;
        private DevExpress.XtraGrid.Columns.GridColumn gridCol_业务员编码;
        private DevExpress.XtraGrid.Columns.GridColumn gridCol_业务员;
        private DevExpress.XtraGrid.Columns.GridColumn gridCol_核销金额;
        private DevExpress.XtraGrid.Columns.GridColumn gridCol_核销日期;
        private DevExpress.XtraGrid.Columns.GridColumn gridCol_发票号码;
        private DevExpress.XtraGrid.Columns.GridColumn gridCol_发票日期;
        private DevExpress.XtraGrid.Columns.GridColumn gridCol_销售组织;
        private DevExpress.XtraGrid.Columns.GridColumn gridCol_客户编码;
        private DevExpress.XtraGrid.Columns.GridColumn gridCol_客户名称;
        private DevExpress.XtraGrid.Columns.GridColumn gridCol_发票金额;
        private DevExpress.XtraGrid.Columns.GridColumn gridCol_货币单位;
        private DevExpress.XtraGrid.Columns.GridColumn gridCol_分配;
        private DevExpress.XtraGrid.Columns.GridColumn gridCol_金税发票号码;
        private DevExpress.XtraGrid.Columns.GridColumn gridCol_清帐凭证号;
        private DevExpress.XtraGrid.Columns.GridColumn gridCol_选择;
        private DevExpress.XtraGrid.Columns.GridColumn gridCol_已使用;
        private DevExpress.XtraGrid.Columns.GridColumn gridCol_iID;
    }
}
