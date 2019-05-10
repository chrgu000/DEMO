namespace UFIDA.U8.UAP.CustomApp.ControlForm
{
    partial class 高开返利单列表
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
            this.btnExcel = new System.Windows.Forms.ToolStripMenuItem();
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            this.gridControl1 = new DevExpress.XtraGrid.GridControl();
            this.gridView1 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.gridCol单据号 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridCol业务员编码 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridCol业务员姓名 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridCol发票号 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridCol发票日期 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridCol客户编码 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridCol客户名称 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridCol客户简称 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridCol发货单号 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridCol存货编码 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridCol存货名称 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridCol规格型号 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridCol单价 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridCol数量 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridCol金额 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridCol发货单价 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridCol差价税率 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridCol差价税额 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridCol返利金额 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridCol发票表体ID = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridCol部门编号 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridCol部门名称 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.panel1 = new System.Windows.Forms.Panel();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.dtm2 = new DevExpress.XtraEditors.DateEdit();
            this.dtm1 = new DevExpress.XtraEditors.DateEdit();
            this.label2 = new System.Windows.Forms.Label();
            this.lookUpEditcCode = new DevExpress.XtraEditors.LookUpEdit();
            this.label1 = new System.Windows.Forms.Label();
            this.lookUpEditcCusName = new DevExpress.XtraEditors.LookUpEdit();
            this.label6 = new System.Windows.Forms.Label();
            this.lookUpEditcCusCode = new DevExpress.XtraEditors.LookUpEdit();
            this.lookUpEditcPersonName = new DevExpress.XtraEditors.LookUpEdit();
            this.label3 = new System.Windows.Forms.Label();
            this.lookUpEditcPersonCode = new DevExpress.XtraEditors.LookUpEdit();
            this.menuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).BeginInit();
            this.panel1.SuspendLayout();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dtm2.Properties.VistaTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtm2.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtm1.Properties.VistaTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtm1.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lookUpEditcCode.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lookUpEditcCusName.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lookUpEditcCusCode.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lookUpEditcPersonName.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lookUpEditcPersonCode.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btnSEL,
            this.btnExcel});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(903, 25);
            this.menuStrip1.TabIndex = 172;
            this.menuStrip1.Text = "menuStrip";
            // 
            // btnSEL
            // 
            this.btnSEL.Name = "btnSEL";
            this.btnSEL.Size = new System.Drawing.Size(44, 21);
            this.btnSEL.Text = "查询";
            this.btnSEL.Click += new System.EventHandler(this.btnSEL_Click);
            // 
            // btnExcel
            // 
            this.btnExcel.Name = "btnExcel";
            this.btnExcel.Size = new System.Drawing.Size(44, 21);
            this.btnExcel.Text = "导出";
            this.btnExcel.Click += new System.EventHandler(this.btnExcel_Click);
            // 
            // labelControl1
            // 
            this.labelControl1.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.labelControl1.Appearance.Font = new System.Drawing.Font("Tahoma", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelControl1.Location = new System.Drawing.Point(407, 3);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(231, 25);
            this.labelControl1.TabIndex = 190;
            this.labelControl1.Text = "高开返利单列表（江西）";
            // 
            // gridControl1
            // 
            this.gridControl1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.gridControl1.Location = new System.Drawing.Point(6, 117);
            this.gridControl1.LookAndFeel.SkinName = "Office 2010 Blue";
            this.gridControl1.MainView = this.gridView1;
            this.gridControl1.Name = "gridControl1";
            this.gridControl1.Size = new System.Drawing.Size(897, 275);
            this.gridControl1.TabIndex = 191;
            this.gridControl1.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView1});
            // 
            // gridView1
            // 
            this.gridView1.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.gridCol单据号,
            this.gridCol业务员编码,
            this.gridCol业务员姓名,
            this.gridCol发票号,
            this.gridCol发票日期,
            this.gridCol客户编码,
            this.gridCol客户名称,
            this.gridCol客户简称,
            this.gridCol发货单号,
            this.gridCol存货编码,
            this.gridCol存货名称,
            this.gridCol规格型号,
            this.gridCol单价,
            this.gridCol数量,
            this.gridCol金额,
            this.gridCol发货单价,
            this.gridCol差价税率,
            this.gridCol差价税额,
            this.gridCol返利金额,
            this.gridCol发票表体ID,
            this.gridCol部门编号,
            this.gridCol部门名称});
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
            this.gridView1.DoubleClick += new System.EventHandler(this.gridView1_DoubleClick);
            // 
            // gridCol单据号
            // 
            this.gridCol单据号.Caption = "单据号";
            this.gridCol单据号.FieldName = "cCode";
            this.gridCol单据号.Name = "gridCol单据号";
            this.gridCol单据号.OptionsColumn.AllowEdit = false;
            this.gridCol单据号.Visible = true;
            this.gridCol单据号.VisibleIndex = 0;
            this.gridCol单据号.Width = 43;
            // 
            // gridCol业务员编码
            // 
            this.gridCol业务员编码.Caption = "业务员编码";
            this.gridCol业务员编码.FieldName = "cPersonCode";
            this.gridCol业务员编码.Name = "gridCol业务员编码";
            this.gridCol业务员编码.OptionsColumn.AllowEdit = false;
            this.gridCol业务员编码.Visible = true;
            this.gridCol业务员编码.VisibleIndex = 1;
            // 
            // gridCol业务员姓名
            // 
            this.gridCol业务员姓名.Caption = "业务员姓名";
            this.gridCol业务员姓名.FieldName = "cPersonName";
            this.gridCol业务员姓名.Name = "gridCol业务员姓名";
            this.gridCol业务员姓名.OptionsColumn.AllowEdit = false;
            this.gridCol业务员姓名.Visible = true;
            this.gridCol业务员姓名.VisibleIndex = 2;
            // 
            // gridCol发票号
            // 
            this.gridCol发票号.Caption = "发票号";
            this.gridCol发票号.FieldName = "cSBVCode";
            this.gridCol发票号.Name = "gridCol发票号";
            this.gridCol发票号.OptionsColumn.AllowEdit = false;
            this.gridCol发票号.Visible = true;
            this.gridCol发票号.VisibleIndex = 3;
            // 
            // gridCol发票日期
            // 
            this.gridCol发票日期.Caption = "发票日期";
            this.gridCol发票日期.FieldName = "dDate";
            this.gridCol发票日期.Name = "gridCol发票日期";
            this.gridCol发票日期.OptionsColumn.AllowEdit = false;
            this.gridCol发票日期.Visible = true;
            this.gridCol发票日期.VisibleIndex = 4;
            // 
            // gridCol客户编码
            // 
            this.gridCol客户编码.Caption = "客户编码";
            this.gridCol客户编码.FieldName = "cCusCode";
            this.gridCol客户编码.Name = "gridCol客户编码";
            this.gridCol客户编码.OptionsColumn.AllowEdit = false;
            this.gridCol客户编码.Visible = true;
            this.gridCol客户编码.VisibleIndex = 5;
            // 
            // gridCol客户名称
            // 
            this.gridCol客户名称.Caption = "客户名称";
            this.gridCol客户名称.FieldName = "cCusName";
            this.gridCol客户名称.Name = "gridCol客户名称";
            this.gridCol客户名称.OptionsColumn.AllowEdit = false;
            this.gridCol客户名称.Visible = true;
            this.gridCol客户名称.VisibleIndex = 6;
            // 
            // gridCol客户简称
            // 
            this.gridCol客户简称.Caption = "客户简称";
            this.gridCol客户简称.FieldName = "cCusAbbName";
            this.gridCol客户简称.Name = "gridCol客户简称";
            this.gridCol客户简称.OptionsColumn.AllowEdit = false;
            this.gridCol客户简称.Visible = true;
            this.gridCol客户简称.VisibleIndex = 19;
            // 
            // gridCol发货单号
            // 
            this.gridCol发货单号.Caption = "发货单号";
            this.gridCol发货单号.FieldName = "cDLCode";
            this.gridCol发货单号.Name = "gridCol发货单号";
            this.gridCol发货单号.OptionsColumn.AllowEdit = false;
            this.gridCol发货单号.Visible = true;
            this.gridCol发货单号.VisibleIndex = 7;
            // 
            // gridCol存货编码
            // 
            this.gridCol存货编码.Caption = "存货编码";
            this.gridCol存货编码.FieldName = "cInvCode";
            this.gridCol存货编码.Name = "gridCol存货编码";
            this.gridCol存货编码.OptionsColumn.AllowEdit = false;
            this.gridCol存货编码.Visible = true;
            this.gridCol存货编码.VisibleIndex = 8;
            // 
            // gridCol存货名称
            // 
            this.gridCol存货名称.Caption = "存货名称";
            this.gridCol存货名称.FieldName = "cInvName";
            this.gridCol存货名称.Name = "gridCol存货名称";
            this.gridCol存货名称.OptionsColumn.AllowEdit = false;
            this.gridCol存货名称.Visible = true;
            this.gridCol存货名称.VisibleIndex = 9;
            // 
            // gridCol规格型号
            // 
            this.gridCol规格型号.Caption = "规格型号";
            this.gridCol规格型号.FieldName = "cInvStd";
            this.gridCol规格型号.Name = "gridCol规格型号";
            this.gridCol规格型号.OptionsColumn.AllowEdit = false;
            this.gridCol规格型号.Visible = true;
            this.gridCol规格型号.VisibleIndex = 10;
            // 
            // gridCol单价
            // 
            this.gridCol单价.Caption = "单价";
            this.gridCol单价.FieldName = "iTaxUnitPrice";
            this.gridCol单价.Name = "gridCol单价";
            this.gridCol单价.OptionsColumn.AllowEdit = false;
            this.gridCol单价.Visible = true;
            this.gridCol单价.VisibleIndex = 11;
            // 
            // gridCol数量
            // 
            this.gridCol数量.Caption = "数量";
            this.gridCol数量.FieldName = "iQuantity";
            this.gridCol数量.Name = "gridCol数量";
            this.gridCol数量.OptionsColumn.AllowEdit = false;
            this.gridCol数量.Visible = true;
            this.gridCol数量.VisibleIndex = 12;
            // 
            // gridCol金额
            // 
            this.gridCol金额.Caption = "金额";
            this.gridCol金额.FieldName = "iSum";
            this.gridCol金额.Name = "gridCol金额";
            this.gridCol金额.OptionsColumn.AllowEdit = false;
            this.gridCol金额.Visible = true;
            this.gridCol金额.VisibleIndex = 13;
            // 
            // gridCol发货单价
            // 
            this.gridCol发货单价.Caption = "发货单价";
            this.gridCol发货单价.FieldName = "iTaxUnitPriceFH";
            this.gridCol发货单价.Name = "gridCol发货单价";
            this.gridCol发货单价.OptionsColumn.AllowEdit = false;
            this.gridCol发货单价.Visible = true;
            this.gridCol发货单价.VisibleIndex = 14;
            // 
            // gridCol差价税率
            // 
            this.gridCol差价税率.Caption = "差价税率";
            this.gridCol差价税率.FieldName = "iTaxRateCJ";
            this.gridCol差价税率.Name = "gridCol差价税率";
            this.gridCol差价税率.OptionsColumn.AllowEdit = false;
            this.gridCol差价税率.Visible = true;
            this.gridCol差价税率.VisibleIndex = 15;
            // 
            // gridCol差价税额
            // 
            this.gridCol差价税额.Caption = "差价税额";
            this.gridCol差价税额.FieldName = "iTaxCJ";
            this.gridCol差价税额.Name = "gridCol差价税额";
            this.gridCol差价税额.OptionsColumn.AllowEdit = false;
            this.gridCol差价税额.Visible = true;
            this.gridCol差价税额.VisibleIndex = 16;
            // 
            // gridCol返利金额
            // 
            this.gridCol返利金额.Caption = "返利金额";
            this.gridCol返利金额.FieldName = "iMoneyFL";
            this.gridCol返利金额.Name = "gridCol返利金额";
            this.gridCol返利金额.OptionsColumn.AllowEdit = false;
            this.gridCol返利金额.Visible = true;
            this.gridCol返利金额.VisibleIndex = 17;
            // 
            // gridCol发票表体ID
            // 
            this.gridCol发票表体ID.Caption = "发票表体ID";
            this.gridCol发票表体ID.FieldName = "FPIDs";
            this.gridCol发票表体ID.Name = "gridCol发票表体ID";
            this.gridCol发票表体ID.OptionsColumn.AllowEdit = false;
            this.gridCol发票表体ID.Visible = true;
            this.gridCol发票表体ID.VisibleIndex = 18;
            // 
            // gridCol部门编号
            // 
            this.gridCol部门编号.Caption = "部门编号";
            this.gridCol部门编号.FieldName = "cDepCode";
            this.gridCol部门编号.Name = "gridCol部门编号";
            this.gridCol部门编号.OptionsColumn.AllowEdit = false;
            this.gridCol部门编号.Visible = true;
            this.gridCol部门编号.VisibleIndex = 20;
            // 
            // gridCol部门名称
            // 
            this.gridCol部门名称.Caption = "部门名称";
            this.gridCol部门名称.FieldName = "cDepName";
            this.gridCol部门名称.Name = "gridCol部门名称";
            this.gridCol部门名称.OptionsColumn.AllowEdit = false;
            this.gridCol部门名称.Visible = true;
            this.gridCol部门名称.VisibleIndex = 21;
            // 
            // panel1
            // 
            this.panel1.AutoScroll = true;
            this.panel1.Controls.Add(this.groupBox1);
            this.panel1.Controls.Add(this.gridControl1);
            this.panel1.Controls.Add(this.labelControl1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 25);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(903, 392);
            this.panel1.TabIndex = 173;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.dtm2);
            this.groupBox1.Controls.Add(this.dtm1);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.lookUpEditcCode);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.lookUpEditcCusName);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.lookUpEditcCusCode);
            this.groupBox1.Controls.Add(this.lookUpEditcPersonName);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.lookUpEditcPersonCode);
            this.groupBox1.Location = new System.Drawing.Point(6, 34);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(848, 69);
            this.groupBox1.TabIndex = 247;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "过滤条件";
            // 
            // dtm2
            // 
            this.dtm2.EditValue = null;
            this.dtm2.Location = new System.Drawing.Point(721, 22);
            this.dtm2.Name = "dtm2";
            this.dtm2.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.dtm2.Properties.VistaTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
            this.dtm2.Size = new System.Drawing.Size(121, 20);
            this.dtm2.TabIndex = 252;
            // 
            // dtm1
            // 
            this.dtm1.EditValue = null;
            this.dtm1.Location = new System.Drawing.Point(593, 22);
            this.dtm1.Name = "dtm1";
            this.dtm1.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.dtm1.Properties.VistaTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
            this.dtm1.Size = new System.Drawing.Size(122, 20);
            this.dtm1.TabIndex = 251;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(540, 26);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(53, 12);
            this.label2.TabIndex = 250;
            this.label2.Text = "单据日期";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lookUpEditcCode
            // 
            this.lookUpEditcCode.AllowHtmlTextInToolTip = DevExpress.Utils.DefaultBoolean.True;
            this.lookUpEditcCode.Location = new System.Drawing.Point(401, 22);
            this.lookUpEditcCode.Name = "lookUpEditcCode";
            this.lookUpEditcCode.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.lookUpEditcCode.Properties.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("cCode", "单据号")});
            this.lookUpEditcCode.Properties.DisplayMember = "cCode";
            this.lookUpEditcCode.Properties.NullText = "";
            this.lookUpEditcCode.Properties.PopupWidth = 400;
            this.lookUpEditcCode.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.Standard;
            this.lookUpEditcCode.Properties.ValueMember = "cCode";
            this.lookUpEditcCode.Size = new System.Drawing.Size(121, 20);
            this.lookUpEditcCode.TabIndex = 249;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(359, 26);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(41, 12);
            this.label1.TabIndex = 248;
            this.label1.Text = "单据号";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lookUpEditcCusName
            // 
            this.lookUpEditcCusName.AllowHtmlTextInToolTip = DevExpress.Utils.DefaultBoolean.True;
            this.lookUpEditcCusName.Location = new System.Drawing.Point(205, 46);
            this.lookUpEditcCusName.Name = "lookUpEditcCusName";
            this.lookUpEditcCusName.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.lookUpEditcCusName.Properties.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("cCusCode", "客户编号"),
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("cCusName", 60, "客户名称")});
            this.lookUpEditcCusName.Properties.DisplayMember = "cCusName";
            this.lookUpEditcCusName.Properties.NullText = "";
            this.lookUpEditcCusName.Properties.PopupWidth = 400;
            this.lookUpEditcCusName.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.Standard;
            this.lookUpEditcCusName.Properties.ValueMember = "cCusCode";
            this.lookUpEditcCusName.Size = new System.Drawing.Size(637, 20);
            this.lookUpEditcCusName.TabIndex = 247;
            this.lookUpEditcCusName.EditValueChanged += new System.EventHandler(this.lookUpEditcCusName_EditValueChanged);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(31, 49);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(29, 12);
            this.label6.TabIndex = 245;
            this.label6.Text = "客户";
            this.label6.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lookUpEditcCusCode
            // 
            this.lookUpEditcCusCode.AllowHtmlTextInToolTip = DevExpress.Utils.DefaultBoolean.True;
            this.lookUpEditcCusCode.Location = new System.Drawing.Point(78, 45);
            this.lookUpEditcCusCode.Name = "lookUpEditcCusCode";
            this.lookUpEditcCusCode.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.lookUpEditcCusCode.Properties.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("cCusCode", "客户编号"),
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("cCusName", 60, "客户名称")});
            this.lookUpEditcCusCode.Properties.DisplayMember = "cCusCode";
            this.lookUpEditcCusCode.Properties.NullText = "";
            this.lookUpEditcCusCode.Properties.PopupWidth = 400;
            this.lookUpEditcCusCode.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.Standard;
            this.lookUpEditcCusCode.Properties.ValueMember = "cCusCode";
            this.lookUpEditcCusCode.Size = new System.Drawing.Size(121, 20);
            this.lookUpEditcCusCode.TabIndex = 246;
            this.lookUpEditcCusCode.EditValueChanged += new System.EventHandler(this.lookUpEditcCusCode_EditValueChanged);
            // 
            // lookUpEditcPersonName
            // 
            this.lookUpEditcPersonName.AllowHtmlTextInToolTip = DevExpress.Utils.DefaultBoolean.True;
            this.lookUpEditcPersonName.Location = new System.Drawing.Point(205, 22);
            this.lookUpEditcPersonName.Name = "lookUpEditcPersonName";
            this.lookUpEditcPersonName.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.lookUpEditcPersonName.Properties.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("cPersonCode", "业务员编号"),
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("cPersonName", 60, "业务员姓名")});
            this.lookUpEditcPersonName.Properties.DisplayMember = "cPersonName";
            this.lookUpEditcPersonName.Properties.NullText = "";
            this.lookUpEditcPersonName.Properties.PopupWidth = 400;
            this.lookUpEditcPersonName.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.Standard;
            this.lookUpEditcPersonName.Properties.ValueMember = "cPersonCode";
            this.lookUpEditcPersonName.Size = new System.Drawing.Size(121, 20);
            this.lookUpEditcPersonName.TabIndex = 241;
            this.lookUpEditcPersonName.EditValueChanged += new System.EventHandler(this.lookUpEditcPersonName_EditValueChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(20, 26);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(41, 12);
            this.label3.TabIndex = 194;
            this.label3.Text = "业务员";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lookUpEditcPersonCode
            // 
            this.lookUpEditcPersonCode.AllowHtmlTextInToolTip = DevExpress.Utils.DefaultBoolean.True;
            this.lookUpEditcPersonCode.Location = new System.Drawing.Point(78, 22);
            this.lookUpEditcPersonCode.Name = "lookUpEditcPersonCode";
            this.lookUpEditcPersonCode.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.lookUpEditcPersonCode.Properties.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("cPersonCode", "业务员编号"),
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("cPersonName", 60, "业务员姓名")});
            this.lookUpEditcPersonCode.Properties.DisplayMember = "cPersonCode";
            this.lookUpEditcPersonCode.Properties.NullText = "";
            this.lookUpEditcPersonCode.Properties.PopupWidth = 400;
            this.lookUpEditcPersonCode.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.Standard;
            this.lookUpEditcPersonCode.Properties.ValueMember = "cPersonCode";
            this.lookUpEditcPersonCode.Size = new System.Drawing.Size(121, 20);
            this.lookUpEditcPersonCode.TabIndex = 195;
            this.lookUpEditcPersonCode.EditValueChanged += new System.EventHandler(this.lookUpEditcPersonCode_EditValueChanged);
            // 
            // 高开返利单列表
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.menuStrip1);
            this.Name = "高开返利单列表";
            this.Size = new System.Drawing.Size(903, 417);
            this.Load += new System.EventHandler(this.Frm_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dtm2.Properties.VistaTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtm2.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtm1.Properties.VistaTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtm1.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lookUpEditcCode.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lookUpEditcCusName.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lookUpEditcCusCode.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lookUpEditcPersonName.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lookUpEditcPersonCode.Properties)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private DevExpress.XtraEditors.LabelControl labelControl1;
        private DevExpress.XtraGrid.GridControl gridControl1;
        private System.Windows.Forms.Panel panel1;
        private DevExpress.XtraEditors.LookUpEdit lookUpEditcPersonCode;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ToolStripMenuItem btnExcel;
        private DevExpress.XtraEditors.LookUpEdit lookUpEditcPersonName;
        private System.Windows.Forms.GroupBox groupBox1;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView1;
        private DevExpress.XtraGrid.Columns.GridColumn gridCol发票号;
        private DevExpress.XtraGrid.Columns.GridColumn gridCol发票日期;
        private DevExpress.XtraGrid.Columns.GridColumn gridCol客户编码;
        private DevExpress.XtraGrid.Columns.GridColumn gridCol客户名称;
        private DevExpress.XtraGrid.Columns.GridColumn gridCol发货单号;
        private DevExpress.XtraGrid.Columns.GridColumn gridCol存货编码;
        private DevExpress.XtraGrid.Columns.GridColumn gridCol存货名称;
        private DevExpress.XtraGrid.Columns.GridColumn gridCol规格型号;
        private DevExpress.XtraGrid.Columns.GridColumn gridCol单价;
        private DevExpress.XtraGrid.Columns.GridColumn gridCol数量;
        private DevExpress.XtraEditors.LookUpEdit lookUpEditcCusName;
        private System.Windows.Forms.Label label6;
        private DevExpress.XtraEditors.LookUpEdit lookUpEditcCusCode;
        private DevExpress.XtraGrid.Columns.GridColumn gridCol金额;
        private DevExpress.XtraGrid.Columns.GridColumn gridCol发货单价;
        private DevExpress.XtraGrid.Columns.GridColumn gridCol差价税率;
        private DevExpress.XtraGrid.Columns.GridColumn gridCol差价税额;
        private DevExpress.XtraGrid.Columns.GridColumn gridCol返利金额;
        private DevExpress.XtraGrid.Columns.GridColumn gridCol发票表体ID;
        private DevExpress.XtraGrid.Columns.GridColumn gridCol客户简称;
        private DevExpress.XtraGrid.Columns.GridColumn gridCol部门编号;
        private DevExpress.XtraGrid.Columns.GridColumn gridCol部门名称;
        private DevExpress.XtraGrid.Columns.GridColumn gridCol单据号;
        private DevExpress.XtraGrid.Columns.GridColumn gridCol业务员编码;
        private DevExpress.XtraGrid.Columns.GridColumn gridCol业务员姓名;
        private System.Windows.Forms.ToolStripMenuItem btnSEL;
        private System.Windows.Forms.Label label2;
        private DevExpress.XtraEditors.LookUpEdit lookUpEditcCode;
        private System.Windows.Forms.Label label1;
        private DevExpress.XtraEditors.DateEdit dtm2;
        private DevExpress.XtraEditors.DateEdit dtm1;
    }
}
