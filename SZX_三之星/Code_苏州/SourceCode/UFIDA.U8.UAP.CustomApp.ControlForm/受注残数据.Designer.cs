namespace UFIDA.U8.UAP.CustomApp.ControlForm
{
    partial class 受注残数据
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
            this.gridColchoose = new DevExpress.XtraGrid.Columns.GridColumn();
            this.ItemCheckEditchoose = new DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit();
            this.gridCol受注No = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridCol顾客订单NO = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridCol交期 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridCol仓库编号 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridCol受注处理日 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridCol顾客No = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridCol顾客名称 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridCol受注行No = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridCol产品编号 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridCol产品编号备注 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridCol受注数量 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.ItemTextEditN3 = new DevExpress.XtraEditors.Repository.RepositoryItemTextEdit();
            this.gridCol已出货数量 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridCol受注残数量 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridCol成本合計 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridCol生产线 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridCol制单人 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridCol表体自定义项10 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.panel1 = new System.Windows.Forms.Panel();
            this.lookUpEditcCusCode2 = new DevExpress.XtraEditors.LookUpEdit();
            this.label3 = new System.Windows.Forms.Label();
            this.lookUpEditcCusCode1 = new DevExpress.XtraEditors.LookUpEdit();
            this.chkAll = new DevExpress.XtraEditors.CheckEdit();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.lookUpEditcSOCode2 = new DevExpress.XtraEditors.LookUpEdit();
            this.lookUpEditcSOCode1 = new DevExpress.XtraEditors.LookUpEdit();
            this.dateEdit2 = new DevExpress.XtraEditors.DateEdit();
            this.dateEdit1 = new DevExpress.XtraEditors.DateEdit();
            this.menuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ItemCheckEditchoose)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ItemTextEditN3)).BeginInit();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.lookUpEditcCusCode2.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lookUpEditcCusCode1.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkAll.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lookUpEditcSOCode2.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lookUpEditcSOCode1.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dateEdit2.Properties.VistaTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dateEdit2.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dateEdit1.Properties.VistaTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dateEdit1.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btnSEL,
            this.btnExport});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Padding = new System.Windows.Forms.Padding(8, 2, 0, 2);
            this.menuStrip1.Size = new System.Drawing.Size(1259, 28);
            this.menuStrip1.TabIndex = 172;
            this.menuStrip1.Text = "menuStrip";
            // 
            // btnSEL
            // 
            this.btnSEL.Name = "btnSEL";
            this.btnSEL.Size = new System.Drawing.Size(51, 24);
            this.btnSEL.Text = "查询";
            this.btnSEL.Click += new System.EventHandler(this.btnSEL_Click);
            // 
            // btnExport
            // 
            this.btnExport.Name = "btnExport";
            this.btnExport.Size = new System.Drawing.Size(51, 24);
            this.btnExport.Text = "导出";
            this.btnExport.Click += new System.EventHandler(this.btnExport_Click);
            // 
            // gridControl1
            // 
            this.gridControl1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.gridControl1.EmbeddedNavigator.Margin = new System.Windows.Forms.Padding(4);
            this.gridControl1.Location = new System.Drawing.Point(4, 144);
            this.gridControl1.LookAndFeel.SkinName = "Office 2010 Blue";
            this.gridControl1.MainView = this.gridView1;
            this.gridControl1.Margin = new System.Windows.Forms.Padding(4);
            this.gridControl1.Name = "gridControl1";
            this.gridControl1.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.ItemCheckEditchoose,
            this.ItemTextEditN3});
            this.gridControl1.Size = new System.Drawing.Size(1251, 392);
            this.gridControl1.TabIndex = 191;
            this.gridControl1.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView1});
            // 
            // gridView1
            // 
            this.gridView1.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.gridColchoose,
            this.gridCol受注No,
            this.gridCol顾客订单NO,
            this.gridCol交期,
            this.gridCol仓库编号,
            this.gridCol受注处理日,
            this.gridCol顾客No,
            this.gridCol顾客名称,
            this.gridCol受注行No,
            this.gridCol产品编号,
            this.gridCol产品编号备注,
            this.gridCol受注数量,
            this.gridCol已出货数量,
            this.gridCol受注残数量,
            this.gridCol成本合計,
            this.gridCol生产线,
            this.gridCol制单人,
            this.gridCol表体自定义项10});
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
            // gridColchoose
            // 
            this.gridColchoose.Caption = "选择";
            this.gridColchoose.ColumnEdit = this.ItemCheckEditchoose;
            this.gridColchoose.FieldName = "选择";
            this.gridColchoose.Name = "gridColchoose";
            this.gridColchoose.Visible = true;
            this.gridColchoose.VisibleIndex = 0;
            this.gridColchoose.Width = 42;
            // 
            // ItemCheckEditchoose
            // 
            this.ItemCheckEditchoose.AutoHeight = false;
            this.ItemCheckEditchoose.Name = "ItemCheckEditchoose";
            // 
            // gridCol受注No
            // 
            this.gridCol受注No.Caption = "受注No";
            this.gridCol受注No.FieldName = "受注No";
            this.gridCol受注No.Name = "gridCol受注No";
            this.gridCol受注No.OptionsColumn.AllowEdit = false;
            this.gridCol受注No.Visible = true;
            this.gridCol受注No.VisibleIndex = 1;
            // 
            // gridCol顾客订单NO
            // 
            this.gridCol顾客订单NO.Caption = "顾客订单NO";
            this.gridCol顾客订单NO.FieldName = "顾客订单NO";
            this.gridCol顾客订单NO.Name = "gridCol顾客订单NO";
            this.gridCol顾客订单NO.OptionsColumn.AllowEdit = false;
            this.gridCol顾客订单NO.Visible = true;
            this.gridCol顾客订单NO.VisibleIndex = 2;
            // 
            // gridCol交期
            // 
            this.gridCol交期.Caption = "交期";
            this.gridCol交期.FieldName = "交期";
            this.gridCol交期.Name = "gridCol交期";
            this.gridCol交期.OptionsColumn.AllowEdit = false;
            this.gridCol交期.Visible = true;
            this.gridCol交期.VisibleIndex = 3;
            // 
            // gridCol仓库编号
            // 
            this.gridCol仓库编号.Caption = "仓库编号";
            this.gridCol仓库编号.FieldName = "仓库编号";
            this.gridCol仓库编号.Name = "gridCol仓库编号";
            this.gridCol仓库编号.OptionsColumn.AllowEdit = false;
            this.gridCol仓库编号.Visible = true;
            this.gridCol仓库编号.VisibleIndex = 4;
            // 
            // gridCol受注处理日
            // 
            this.gridCol受注处理日.Caption = "受注处理日";
            this.gridCol受注处理日.FieldName = "受注处理日";
            this.gridCol受注处理日.Name = "gridCol受注处理日";
            this.gridCol受注处理日.OptionsColumn.AllowEdit = false;
            this.gridCol受注处理日.Visible = true;
            this.gridCol受注处理日.VisibleIndex = 5;
            // 
            // gridCol顾客No
            // 
            this.gridCol顾客No.Caption = "顾客No";
            this.gridCol顾客No.FieldName = "顾客No";
            this.gridCol顾客No.Name = "gridCol顾客No";
            this.gridCol顾客No.OptionsColumn.AllowEdit = false;
            this.gridCol顾客No.Visible = true;
            this.gridCol顾客No.VisibleIndex = 6;
            // 
            // gridCol顾客名称
            // 
            this.gridCol顾客名称.Caption = "顾客名称";
            this.gridCol顾客名称.FieldName = "顾客名称";
            this.gridCol顾客名称.Name = "gridCol顾客名称";
            this.gridCol顾客名称.OptionsColumn.AllowEdit = false;
            this.gridCol顾客名称.Visible = true;
            this.gridCol顾客名称.VisibleIndex = 7;
            // 
            // gridCol受注行No
            // 
            this.gridCol受注行No.Caption = "受注行No";
            this.gridCol受注行No.FieldName = "受注行No";
            this.gridCol受注行No.Name = "gridCol受注行No";
            this.gridCol受注行No.OptionsColumn.AllowEdit = false;
            this.gridCol受注行No.Visible = true;
            this.gridCol受注行No.VisibleIndex = 8;
            // 
            // gridCol产品编号
            // 
            this.gridCol产品编号.Caption = "产品编号";
            this.gridCol产品编号.FieldName = "产品编号";
            this.gridCol产品编号.Name = "gridCol产品编号";
            this.gridCol产品编号.OptionsColumn.AllowEdit = false;
            this.gridCol产品编号.Visible = true;
            this.gridCol产品编号.VisibleIndex = 9;
            // 
            // gridCol产品编号备注
            // 
            this.gridCol产品编号备注.Caption = "产品编号备注";
            this.gridCol产品编号备注.FieldName = "产品编号备注";
            this.gridCol产品编号备注.Name = "gridCol产品编号备注";
            this.gridCol产品编号备注.OptionsColumn.AllowEdit = false;
            this.gridCol产品编号备注.Visible = true;
            this.gridCol产品编号备注.VisibleIndex = 10;
            // 
            // gridCol受注数量
            // 
            this.gridCol受注数量.Caption = "受注数量";
            this.gridCol受注数量.ColumnEdit = this.ItemTextEditN3;
            this.gridCol受注数量.FieldName = "受注数量";
            this.gridCol受注数量.Name = "gridCol受注数量";
            this.gridCol受注数量.OptionsColumn.AllowEdit = false;
            this.gridCol受注数量.Visible = true;
            this.gridCol受注数量.VisibleIndex = 11;
            // 
            // ItemTextEditN3
            // 
            this.ItemTextEditN3.AutoHeight = false;
            this.ItemTextEditN3.DisplayFormat.FormatString = "n3";
            this.ItemTextEditN3.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.ItemTextEditN3.EditFormat.FormatString = "n3";
            this.ItemTextEditN3.EditFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.ItemTextEditN3.Mask.EditMask = "n3";
            this.ItemTextEditN3.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Numeric;
            this.ItemTextEditN3.Name = "ItemTextEditN3";
            // 
            // gridCol已出货数量
            // 
            this.gridCol已出货数量.Caption = "已出货数量";
            this.gridCol已出货数量.ColumnEdit = this.ItemTextEditN3;
            this.gridCol已出货数量.FieldName = "已出货数量";
            this.gridCol已出货数量.Name = "gridCol已出货数量";
            this.gridCol已出货数量.OptionsColumn.AllowEdit = false;
            this.gridCol已出货数量.Visible = true;
            this.gridCol已出货数量.VisibleIndex = 12;
            // 
            // gridCol受注残数量
            // 
            this.gridCol受注残数量.Caption = "受注残数量";
            this.gridCol受注残数量.ColumnEdit = this.ItemTextEditN3;
            this.gridCol受注残数量.FieldName = "受注残数量";
            this.gridCol受注残数量.Name = "gridCol受注残数量";
            this.gridCol受注残数量.OptionsColumn.AllowEdit = false;
            this.gridCol受注残数量.Visible = true;
            this.gridCol受注残数量.VisibleIndex = 13;
            // 
            // gridCol成本合計
            // 
            this.gridCol成本合計.Caption = "成本(合計)";
            this.gridCol成本合計.ColumnEdit = this.ItemTextEditN3;
            this.gridCol成本合計.FieldName = "成本合計";
            this.gridCol成本合計.Name = "gridCol成本合計";
            this.gridCol成本合計.OptionsColumn.AllowEdit = false;
            this.gridCol成本合計.Visible = true;
            this.gridCol成本合計.VisibleIndex = 14;
            // 
            // gridCol生产线
            // 
            this.gridCol生产线.Caption = "生产线";
            this.gridCol生产线.FieldName = "生产线";
            this.gridCol生产线.Name = "gridCol生产线";
            this.gridCol生产线.OptionsColumn.AllowEdit = false;
            this.gridCol生产线.Visible = true;
            this.gridCol生产线.VisibleIndex = 15;
            // 
            // gridCol制单人
            // 
            this.gridCol制单人.Caption = "制单人";
            this.gridCol制单人.FieldName = "制单人";
            this.gridCol制单人.Name = "gridCol制单人";
            this.gridCol制单人.OptionsColumn.AllowEdit = false;
            this.gridCol制单人.Visible = true;
            this.gridCol制单人.VisibleIndex = 17;
            // 
            // gridCol表体自定义项10
            // 
            this.gridCol表体自定义项10.Caption = "表体自定义项10";
            this.gridCol表体自定义项10.FieldName = "表体自定义项10";
            this.gridCol表体自定义项10.Name = "gridCol表体自定义项10";
            this.gridCol表体自定义项10.OptionsColumn.AllowEdit = false;
            this.gridCol表体自定义项10.Visible = true;
            this.gridCol表体自定义项10.VisibleIndex = 16;
            // 
            // panel1
            // 
            this.panel1.AutoScroll = true;
            this.panel1.Controls.Add(this.lookUpEditcCusCode2);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.lookUpEditcCusCode1);
            this.panel1.Controls.Add(this.chkAll);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.lookUpEditcSOCode2);
            this.panel1.Controls.Add(this.lookUpEditcSOCode1);
            this.panel1.Controls.Add(this.dateEdit2);
            this.panel1.Controls.Add(this.dateEdit1);
            this.panel1.Controls.Add(this.gridControl1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 28);
            this.panel1.Margin = new System.Windows.Forms.Padding(4);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1259, 542);
            this.panel1.TabIndex = 173;
            // 
            // lookUpEditcCusCode2
            // 
            this.lookUpEditcCusCode2.Location = new System.Drawing.Point(265, 56);
            this.lookUpEditcCusCode2.Margin = new System.Windows.Forms.Padding(4);
            this.lookUpEditcCusCode2.Name = "lookUpEditcCusCode2";
            this.lookUpEditcCusCode2.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.lookUpEditcCusCode2.Properties.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("cCusCode", "客户编号"),
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("cCusName", "客户名称")});
            this.lookUpEditcCusCode2.Properties.DisplayMember = "cCusCode";
            this.lookUpEditcCusCode2.Properties.NullText = "";
            this.lookUpEditcCusCode2.Properties.ValueMember = "cCusCode";
            this.lookUpEditcCusCode2.Size = new System.Drawing.Size(133, 24);
            this.lookUpEditcCusCode2.TabIndex = 202;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(29, 62);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(67, 15);
            this.label3.TabIndex = 201;
            this.label3.Text = "客户编号";
            // 
            // lookUpEditcCusCode1
            // 
            this.lookUpEditcCusCode1.Location = new System.Drawing.Point(124, 56);
            this.lookUpEditcCusCode1.Margin = new System.Windows.Forms.Padding(4);
            this.lookUpEditcCusCode1.Name = "lookUpEditcCusCode1";
            this.lookUpEditcCusCode1.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.lookUpEditcCusCode1.Properties.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("cCusCode", "客户编号"),
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("cCusName", "客户名称")});
            this.lookUpEditcCusCode1.Properties.DisplayMember = "cCusCode";
            this.lookUpEditcCusCode1.Properties.NullText = "";
            this.lookUpEditcCusCode1.Properties.ValueMember = "cCusCode";
            this.lookUpEditcCusCode1.Size = new System.Drawing.Size(133, 24);
            this.lookUpEditcCusCode1.TabIndex = 199;
            // 
            // chkAll
            // 
            this.chkAll.Location = new System.Drawing.Point(29, 112);
            this.chkAll.Margin = new System.Windows.Forms.Padding(4);
            this.chkAll.Name = "chkAll";
            this.chkAll.Properties.Caption = "全选";
            this.chkAll.Size = new System.Drawing.Size(100, 23);
            this.chkAll.TabIndex = 198;
            this.chkAll.CheckedChanged += new System.EventHandler(this.chkAll_CheckedChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(441, 30);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(37, 15);
            this.label2.TabIndex = 197;
            this.label2.Text = "日期";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(29, 30);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(82, 15);
            this.label1.TabIndex = 196;
            this.label1.Text = "销售订单号";
            // 
            // lookUpEditcSOCode2
            // 
            this.lookUpEditcSOCode2.Location = new System.Drawing.Point(265, 26);
            this.lookUpEditcSOCode2.Margin = new System.Windows.Forms.Padding(4);
            this.lookUpEditcSOCode2.Name = "lookUpEditcSOCode2";
            this.lookUpEditcSOCode2.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.lookUpEditcSOCode2.Properties.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("cSOCode", "销售订单号")});
            this.lookUpEditcSOCode2.Properties.DisplayMember = "cSOCode";
            this.lookUpEditcSOCode2.Properties.NullText = "";
            this.lookUpEditcSOCode2.Properties.ValueMember = "cSOCode";
            this.lookUpEditcSOCode2.Size = new System.Drawing.Size(133, 24);
            this.lookUpEditcSOCode2.TabIndex = 195;
            // 
            // lookUpEditcSOCode1
            // 
            this.lookUpEditcSOCode1.Location = new System.Drawing.Point(124, 26);
            this.lookUpEditcSOCode1.Margin = new System.Windows.Forms.Padding(4);
            this.lookUpEditcSOCode1.Name = "lookUpEditcSOCode1";
            this.lookUpEditcSOCode1.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.lookUpEditcSOCode1.Properties.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("cSOCode", "销售订单号")});
            this.lookUpEditcSOCode1.Properties.DisplayMember = "cSOCode";
            this.lookUpEditcSOCode1.Properties.NullText = "";
            this.lookUpEditcSOCode1.Properties.ValueMember = "cSOCode";
            this.lookUpEditcSOCode1.Size = new System.Drawing.Size(133, 24);
            this.lookUpEditcSOCode1.TabIndex = 194;
            // 
            // dateEdit2
            // 
            this.dateEdit2.EditValue = null;
            this.dateEdit2.Location = new System.Drawing.Point(659, 26);
            this.dateEdit2.Margin = new System.Windows.Forms.Padding(4);
            this.dateEdit2.Name = "dateEdit2";
            this.dateEdit2.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.dateEdit2.Properties.VistaTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
            this.dateEdit2.Size = new System.Drawing.Size(133, 24);
            this.dateEdit2.TabIndex = 193;
            // 
            // dateEdit1
            // 
            this.dateEdit1.EditValue = null;
            this.dateEdit1.Location = new System.Drawing.Point(517, 26);
            this.dateEdit1.Margin = new System.Windows.Forms.Padding(4);
            this.dateEdit1.Name = "dateEdit1";
            this.dateEdit1.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.dateEdit1.Properties.VistaTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
            this.dateEdit1.Size = new System.Drawing.Size(133, 24);
            this.dateEdit1.TabIndex = 192;
            // 
            // 受注残数据
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.menuStrip1);
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "受注残数据";
            this.Size = new System.Drawing.Size(1259, 570);
            this.Load += new System.EventHandler(this.Frm_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ItemCheckEditchoose)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ItemTextEditN3)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.lookUpEditcCusCode2.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lookUpEditcCusCode1.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkAll.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lookUpEditcSOCode2.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lookUpEditcSOCode1.Properties)).EndInit();
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
        private System.Windows.Forms.ToolStripMenuItem btnSEL;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView1;
        private System.Windows.Forms.ToolStripMenuItem btnExport;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private DevExpress.XtraEditors.LookUpEdit lookUpEditcSOCode2;
        private DevExpress.XtraEditors.LookUpEdit lookUpEditcSOCode1;
        private DevExpress.XtraEditors.DateEdit dateEdit2;
        private DevExpress.XtraEditors.DateEdit dateEdit1;
        private DevExpress.XtraEditors.CheckEdit chkAll;
        private DevExpress.XtraGrid.Columns.GridColumn gridCol受注No;
        private DevExpress.XtraGrid.Columns.GridColumn gridCol顾客订单NO;
        private DevExpress.XtraGrid.Columns.GridColumn gridCol交期;
        private DevExpress.XtraGrid.Columns.GridColumn gridCol仓库编号;
        private DevExpress.XtraGrid.Columns.GridColumn gridCol受注处理日;
        private DevExpress.XtraGrid.Columns.GridColumn gridCol顾客No;
        private DevExpress.XtraGrid.Columns.GridColumn gridCol顾客名称;
        private DevExpress.XtraGrid.Columns.GridColumn gridCol受注行No;
        private DevExpress.XtraGrid.Columns.GridColumn gridCol产品编号;
        private DevExpress.XtraGrid.Columns.GridColumn gridCol产品编号备注;
        private DevExpress.XtraGrid.Columns.GridColumn gridCol受注数量;
        private DevExpress.XtraGrid.Columns.GridColumn gridCol已出货数量;
        private DevExpress.XtraGrid.Columns.GridColumn gridCol受注残数量;
        private DevExpress.XtraGrid.Columns.GridColumn gridCol成本合計;
        private DevExpress.XtraGrid.Columns.GridColumn gridCol生产线;
        private DevExpress.XtraGrid.Columns.GridColumn gridColchoose;
        private DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit ItemCheckEditchoose;
        private DevExpress.XtraEditors.Repository.RepositoryItemTextEdit ItemTextEditN3;
        private DevExpress.XtraEditors.LookUpEdit lookUpEditcCusCode2;
        private System.Windows.Forms.Label label3;
        private DevExpress.XtraEditors.LookUpEdit lookUpEditcCusCode1;
        private DevExpress.XtraGrid.Columns.GridColumn gridCol制单人;
        private DevExpress.XtraGrid.Columns.GridColumn gridCol表体自定义项10;
    }
}
