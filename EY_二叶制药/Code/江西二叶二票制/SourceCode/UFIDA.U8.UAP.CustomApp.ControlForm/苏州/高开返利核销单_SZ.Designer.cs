namespace UFIDA.U8.UAP.CustomApp.ControlForm
{
    partial class 高开返利核销单_SZ
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
            this.btnDel = new System.Windows.Forms.ToolStripMenuItem();
            this.btnSave = new System.Windows.Forms.ToolStripMenuItem();
            this.btnPrint = new System.Windows.Forms.ToolStripMenuItem();
            this.btnPrintSet = new System.Windows.Forms.ToolStripMenuItem();
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            this.gridControl返利单 = new DevExpress.XtraGrid.GridControl();
            this.gridView返利单 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.gridColbchoose = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridCol发票号 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridCol发票日期 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridCol客户编码 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridCol客户名称 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridCol存货编码 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridCol存货名称 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridCol规格型号 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridCol差价税率 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridCol差价税额 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridCol返利金额 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridCol代理商编码 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridCol代理商 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColcPersonCode = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColcPersonName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColcDCCode = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColcDCName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColiID = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColcCode = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColdtmDate = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColFLD_iID = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridCol发票金额 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.panel1 = new System.Windows.Forms.Panel();
            this.lookUpEdit区域 = new DevExpress.XtraEditors.LookUpEdit();
            this.lookUpEditcCusName = new DevExpress.XtraEditors.LookUpEdit();
            this.label5 = new System.Windows.Forms.Label();
            this.btnLoad = new System.Windows.Forms.Button();
            this.lookUpEditcCusCode = new DevExpress.XtraEditors.LookUpEdit();
            this.label6 = new System.Windows.Forms.Label();
            this.txt开票金额 = new DevExpress.XtraEditors.TextEdit();
            this.label9 = new System.Windows.Forms.Label();
            this.txt考核金额 = new DevExpress.XtraEditors.TextEdit();
            this.txt费率 = new DevExpress.XtraEditors.TextEdit();
            this.label8 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.txt备注 = new DevExpress.XtraEditors.TextEdit();
            this.label7 = new System.Windows.Forms.Label();
            this.dtm = new DevExpress.XtraEditors.DateEdit();
            this.label2 = new System.Windows.Forms.Label();
            this.txt单据号 = new DevExpress.XtraEditors.TextEdit();
            this.label4 = new System.Windows.Forms.Label();
            this.menuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl返利单)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView返利单)).BeginInit();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.lookUpEdit区域.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lookUpEditcCusName.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lookUpEditcCusCode.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txt开票金额.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txt考核金额.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txt费率.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txt备注.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtm.Properties.VistaTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtm.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txt单据号.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btnDel,
            this.btnSave,
            this.btnPrint,
            this.btnPrintSet});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(1040, 25);
            this.menuStrip1.TabIndex = 172;
            this.menuStrip1.Text = "menuStrip";
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
            this.btnSave.Text = "核销";
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // btnPrint
            // 
            this.btnPrint.Name = "btnPrint";
            this.btnPrint.Size = new System.Drawing.Size(44, 21);
            this.btnPrint.Text = "打印";
            this.btnPrint.Click += new System.EventHandler(this.btnPrint_Click);
            // 
            // btnPrintSet
            // 
            this.btnPrintSet.Name = "btnPrintSet";
            this.btnPrintSet.Size = new System.Drawing.Size(68, 21);
            this.btnPrintSet.Text = "打印设置";
            this.btnPrintSet.Click += new System.EventHandler(this.btnPrintSet_Click);
            // 
            // labelControl1
            // 
            this.labelControl1.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.labelControl1.Appearance.Font = new System.Drawing.Font("Tahoma", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelControl1.Location = new System.Drawing.Point(390, 0);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(205, 25);
            this.labelControl1.TabIndex = 190;
            this.labelControl1.Text = "高开返利核销单(苏州)";
            // 
            // gridControl返利单
            // 
            this.gridControl返利单.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.gridControl返利单.Location = new System.Drawing.Point(3, 153);
            this.gridControl返利单.LookAndFeel.SkinName = "Office 2010 Blue";
            this.gridControl返利单.MainView = this.gridView返利单;
            this.gridControl返利单.Name = "gridControl返利单";
            this.gridControl返利单.Size = new System.Drawing.Size(1034, 518);
            this.gridControl返利单.TabIndex = 191;
            this.gridControl返利单.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView返利单});
            // 
            // gridView返利单
            // 
            this.gridView返利单.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.gridColbchoose,
            this.gridCol发票号,
            this.gridCol发票日期,
            this.gridCol客户编码,
            this.gridCol客户名称,
            this.gridCol存货编码,
            this.gridCol存货名称,
            this.gridCol规格型号,
            this.gridCol差价税率,
            this.gridCol差价税额,
            this.gridCol返利金额,
            this.gridCol代理商编码,
            this.gridCol代理商,
            this.gridColcPersonCode,
            this.gridColcPersonName,
            this.gridColcDCCode,
            this.gridColcDCName,
            this.gridColiID,
            this.gridColcCode,
            this.gridColdtmDate,
            this.gridColFLD_iID,
            this.gridCol发票金额});
            this.gridView返利单.GridControl = this.gridControl返利单;
            this.gridView返利单.IndicatorWidth = 40;
            this.gridView返利单.Name = "gridView返利单";
            this.gridView返利单.OptionsBehavior.AllowDeleteRows = DevExpress.Utils.DefaultBoolean.True;
            this.gridView返利单.OptionsBehavior.EditorShowMode = DevExpress.Utils.EditorShowMode.MouseDown;
            this.gridView返利单.OptionsCustomization.AllowGroup = false;
            this.gridView返利单.OptionsCustomization.AllowQuickHideColumns = false;
            this.gridView返利单.OptionsNavigation.EnterMoveNextColumn = true;
            this.gridView返利单.OptionsView.ColumnAutoWidth = false;
            this.gridView返利单.OptionsView.ShowFooter = true;
            this.gridView返利单.OptionsView.ShowGroupPanel = false;
            this.gridView返利单.CustomDrawRowIndicator += new DevExpress.XtraGrid.Views.Grid.RowIndicatorCustomDrawEventHandler(this.gridView1_CustomDrawRowIndicator);
            this.gridView返利单.CellValueChanged += new DevExpress.XtraGrid.Views.Base.CellValueChangedEventHandler(this.gridView返利单_CellValueChanged);
            // 
            // gridColbchoose
            // 
            this.gridColbchoose.Caption = "选择";
            this.gridColbchoose.FieldName = "bchoose";
            this.gridColbchoose.Name = "gridColbchoose";
            this.gridColbchoose.Visible = true;
            this.gridColbchoose.VisibleIndex = 0;
            this.gridColbchoose.Width = 31;
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
            // 
            // gridCol客户名称
            // 
            this.gridCol客户名称.Caption = "客户名称";
            this.gridCol客户名称.FieldName = "cCusName";
            this.gridCol客户名称.Name = "gridCol客户名称";
            this.gridCol客户名称.OptionsColumn.AllowEdit = false;
            // 
            // gridCol存货编码
            // 
            this.gridCol存货编码.Caption = "存货编码";
            this.gridCol存货编码.FieldName = "cInvCode";
            this.gridCol存货编码.Name = "gridCol存货编码";
            this.gridCol存货编码.OptionsColumn.AllowEdit = false;
            this.gridCol存货编码.Visible = true;
            this.gridCol存货编码.VisibleIndex = 5;
            // 
            // gridCol存货名称
            // 
            this.gridCol存货名称.Caption = "存货名称";
            this.gridCol存货名称.FieldName = "cInvName";
            this.gridCol存货名称.Name = "gridCol存货名称";
            this.gridCol存货名称.OptionsColumn.AllowEdit = false;
            this.gridCol存货名称.Visible = true;
            this.gridCol存货名称.VisibleIndex = 6;
            // 
            // gridCol规格型号
            // 
            this.gridCol规格型号.Caption = "规格型号";
            this.gridCol规格型号.FieldName = "cInvStd";
            this.gridCol规格型号.Name = "gridCol规格型号";
            this.gridCol规格型号.OptionsColumn.AllowEdit = false;
            this.gridCol规格型号.Visible = true;
            this.gridCol规格型号.VisibleIndex = 7;
            // 
            // gridCol差价税率
            // 
            this.gridCol差价税率.Caption = "差价税率";
            this.gridCol差价税率.FieldName = "iTaxRateCJ";
            this.gridCol差价税率.Name = "gridCol差价税率";
            this.gridCol差价税率.OptionsColumn.AllowEdit = false;
            this.gridCol差价税率.Visible = true;
            this.gridCol差价税率.VisibleIndex = 8;
            // 
            // gridCol差价税额
            // 
            this.gridCol差价税额.Caption = "差价税额";
            this.gridCol差价税额.FieldName = "iTaxCJ";
            this.gridCol差价税额.Name = "gridCol差价税额";
            this.gridCol差价税额.OptionsColumn.AllowEdit = false;
            this.gridCol差价税额.Visible = true;
            this.gridCol差价税额.VisibleIndex = 9;
            // 
            // gridCol返利金额
            // 
            this.gridCol返利金额.Caption = "返利金额";
            this.gridCol返利金额.FieldName = "iMoneyFL";
            this.gridCol返利金额.Name = "gridCol返利金额";
            this.gridCol返利金额.OptionsColumn.AllowEdit = false;
            this.gridCol返利金额.Summary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] {
            new DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum)});
            this.gridCol返利金额.Visible = true;
            this.gridCol返利金额.VisibleIndex = 10;
            // 
            // gridCol代理商编码
            // 
            this.gridCol代理商编码.Caption = "代理商编码";
            this.gridCol代理商编码.FieldName = "DLS";
            this.gridCol代理商编码.Name = "gridCol代理商编码";
            this.gridCol代理商编码.OptionsColumn.AllowEdit = false;
            this.gridCol代理商编码.Visible = true;
            this.gridCol代理商编码.VisibleIndex = 13;
            // 
            // gridCol代理商
            // 
            this.gridCol代理商.Caption = "代理商";
            this.gridCol代理商.FieldName = "DLSName";
            this.gridCol代理商.Name = "gridCol代理商";
            this.gridCol代理商.OptionsColumn.AllowEdit = false;
            this.gridCol代理商.Visible = true;
            this.gridCol代理商.VisibleIndex = 14;
            this.gridCol代理商.Width = 87;
            // 
            // gridColcPersonCode
            // 
            this.gridColcPersonCode.Caption = "业务员编码";
            this.gridColcPersonCode.FieldName = "cPersonCode";
            this.gridColcPersonCode.Name = "gridColcPersonCode";
            this.gridColcPersonCode.OptionsColumn.AllowEdit = false;
            this.gridColcPersonCode.Visible = true;
            this.gridColcPersonCode.VisibleIndex = 11;
            // 
            // gridColcPersonName
            // 
            this.gridColcPersonName.Caption = "业务员";
            this.gridColcPersonName.FieldName = "cPersonName";
            this.gridColcPersonName.Name = "gridColcPersonName";
            this.gridColcPersonName.OptionsColumn.AllowEdit = false;
            this.gridColcPersonName.Visible = true;
            this.gridColcPersonName.VisibleIndex = 12;
            // 
            // gridColcDCCode
            // 
            this.gridColcDCCode.Caption = "地区编码";
            this.gridColcDCCode.FieldName = "cDCCode";
            this.gridColcDCCode.Name = "gridColcDCCode";
            this.gridColcDCCode.OptionsColumn.AllowEdit = false;
            // 
            // gridColcDCName
            // 
            this.gridColcDCName.Caption = "地区";
            this.gridColcDCName.FieldName = "cDCName";
            this.gridColcDCName.Name = "gridColcDCName";
            this.gridColcDCName.OptionsColumn.AllowEdit = false;
            // 
            // gridColiID
            // 
            this.gridColiID.Caption = "iID";
            this.gridColiID.FieldName = "iID";
            this.gridColiID.Name = "gridColiID";
            this.gridColiID.OptionsColumn.AllowEdit = false;
            // 
            // gridColcCode
            // 
            this.gridColcCode.Caption = "返利单号";
            this.gridColcCode.FieldName = "FL_Code";
            this.gridColcCode.Name = "gridColcCode";
            this.gridColcCode.OptionsColumn.AllowEdit = false;
            this.gridColcCode.Visible = true;
            this.gridColcCode.VisibleIndex = 1;
            // 
            // gridColdtmDate
            // 
            this.gridColdtmDate.Caption = "返利单日期";
            this.gridColdtmDate.FieldName = "dtmDate";
            this.gridColdtmDate.Name = "gridColdtmDate";
            this.gridColdtmDate.OptionsColumn.AllowEdit = false;
            this.gridColdtmDate.Visible = true;
            this.gridColdtmDate.VisibleIndex = 2;
            // 
            // gridColFLD_iID
            // 
            this.gridColFLD_iID.Caption = "FLD_iID";
            this.gridColFLD_iID.FieldName = "FLD_iID";
            this.gridColFLD_iID.Name = "gridColFLD_iID";
            this.gridColFLD_iID.OptionsColumn.AllowEdit = false;
            this.gridColFLD_iID.Visible = true;
            this.gridColFLD_iID.VisibleIndex = 15;
            // 
            // gridCol发票金额
            // 
            this.gridCol发票金额.Caption = "发票金额";
            this.gridCol发票金额.FieldName = "金额";
            this.gridCol发票金额.Name = "gridCol发票金额";
            this.gridCol发票金额.OptionsColumn.AllowEdit = false;
            this.gridCol发票金额.Summary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] {
            new DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum)});
            this.gridCol发票金额.Visible = true;
            this.gridCol发票金额.VisibleIndex = 16;
            // 
            // panel1
            // 
            this.panel1.AutoScroll = true;
            this.panel1.Controls.Add(this.lookUpEdit区域);
            this.panel1.Controls.Add(this.lookUpEditcCusName);
            this.panel1.Controls.Add(this.label5);
            this.panel1.Controls.Add(this.btnLoad);
            this.panel1.Controls.Add(this.lookUpEditcCusCode);
            this.panel1.Controls.Add(this.label6);
            this.panel1.Controls.Add(this.gridControl返利单);
            this.panel1.Controls.Add(this.txt开票金额);
            this.panel1.Controls.Add(this.label9);
            this.panel1.Controls.Add(this.txt考核金额);
            this.panel1.Controls.Add(this.txt费率);
            this.panel1.Controls.Add(this.label8);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.txt备注);
            this.panel1.Controls.Add(this.label7);
            this.panel1.Controls.Add(this.dtm);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.txt单据号);
            this.panel1.Controls.Add(this.label4);
            this.panel1.Controls.Add(this.labelControl1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 25);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1040, 674);
            this.panel1.TabIndex = 173;
            // 
            // lookUpEdit区域
            // 
            this.lookUpEdit区域.AllowHtmlTextInToolTip = DevExpress.Utils.DefaultBoolean.True;
            this.lookUpEdit区域.Location = new System.Drawing.Point(490, 47);
            this.lookUpEdit区域.Name = "lookUpEdit区域";
            this.lookUpEdit区域.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.lookUpEdit区域.Properties.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("城市编码", 60, "城市")});
            this.lookUpEdit区域.Properties.DisplayMember = "城市编码";
            this.lookUpEdit区域.Properties.NullText = "";
            this.lookUpEdit区域.Properties.PopupWidth = 400;
            this.lookUpEdit区域.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.Standard;
            this.lookUpEdit区域.Properties.ValueMember = "城市编码";
            this.lookUpEdit区域.Size = new System.Drawing.Size(124, 20);
            this.lookUpEdit区域.TabIndex = 262;
            // 
            // lookUpEditcCusName
            // 
            this.lookUpEditcCusName.AllowHtmlTextInToolTip = DevExpress.Utils.DefaultBoolean.True;
            this.lookUpEditcCusName.Location = new System.Drawing.Point(203, 47);
            this.lookUpEditcCusName.Name = "lookUpEditcCusName";
            this.lookUpEditcCusName.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.lookUpEditcCusName.Properties.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("DLS", "代理商编号"),
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("DLSName", 60, "代理商名称")});
            this.lookUpEditcCusName.Properties.DisplayMember = "DLSName";
            this.lookUpEditcCusName.Properties.NullText = "";
            this.lookUpEditcCusName.Properties.PopupWidth = 400;
            this.lookUpEditcCusName.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.Standard;
            this.lookUpEditcCusName.Properties.ValueMember = "DLS";
            this.lookUpEditcCusName.Size = new System.Drawing.Size(205, 20);
            this.lookUpEditcCusName.TabIndex = 247;
            this.lookUpEditcCusName.EditValueChanged += new System.EventHandler(this.lookUpEditcCusName_EditValueChanged);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(430, 51);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(29, 12);
            this.label5.TabIndex = 261;
            this.label5.Text = "区域";
            this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // btnLoad
            // 
            this.btnLoad.Location = new System.Drawing.Point(649, 46);
            this.btnLoad.Name = "btnLoad";
            this.btnLoad.Size = new System.Drawing.Size(75, 23);
            this.btnLoad.TabIndex = 248;
            this.btnLoad.Text = "加载数据";
            this.btnLoad.UseVisualStyleBackColor = true;
            this.btnLoad.Click += new System.EventHandler(this.btnLoad_Click);
            // 
            // lookUpEditcCusCode
            // 
            this.lookUpEditcCusCode.AllowHtmlTextInToolTip = DevExpress.Utils.DefaultBoolean.True;
            this.lookUpEditcCusCode.Location = new System.Drawing.Point(72, 47);
            this.lookUpEditcCusCode.Name = "lookUpEditcCusCode";
            this.lookUpEditcCusCode.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.lookUpEditcCusCode.Properties.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("DLS", "代理商编码"),
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("DLSName", 60, "代理商名称")});
            this.lookUpEditcCusCode.Properties.DisplayMember = "DLS";
            this.lookUpEditcCusCode.Properties.NullText = "";
            this.lookUpEditcCusCode.Properties.PopupWidth = 400;
            this.lookUpEditcCusCode.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.Standard;
            this.lookUpEditcCusCode.Properties.ValueMember = "DLS";
            this.lookUpEditcCusCode.Size = new System.Drawing.Size(124, 20);
            this.lookUpEditcCusCode.TabIndex = 246;
            this.lookUpEditcCusCode.EditValueChanged += new System.EventHandler(this.lookUpEditcCusCode_EditValueChanged);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.ForeColor = System.Drawing.Color.Blue;
            this.label6.Location = new System.Drawing.Point(12, 51);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(53, 12);
            this.label6.TabIndex = 245;
            this.label6.Text = "开票公司";
            this.label6.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txt开票金额
            // 
            this.txt开票金额.Location = new System.Drawing.Point(490, 100);
            this.txt开票金额.Name = "txt开票金额";
            this.txt开票金额.Properties.DisplayFormat.FormatString = "n2";
            this.txt开票金额.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.txt开票金额.Properties.EditFormat.FormatString = "n2";
            this.txt开票金额.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.txt开票金额.Size = new System.Drawing.Size(124, 20);
            this.txt开票金额.TabIndex = 266;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(417, 104);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(53, 12);
            this.label9.TabIndex = 265;
            this.label9.Text = "开票金额";
            this.label9.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txt考核金额
            // 
            this.txt考核金额.Location = new System.Drawing.Point(71, 101);
            this.txt考核金额.Name = "txt考核金额";
            this.txt考核金额.Properties.DisplayFormat.FormatString = "n2";
            this.txt考核金额.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.txt考核金额.Properties.EditFormat.FormatString = "n2";
            this.txt考核金额.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.txt考核金额.Size = new System.Drawing.Size(123, 20);
            this.txt考核金额.TabIndex = 264;
            // 
            // txt费率
            // 
            this.txt费率.Location = new System.Drawing.Point(286, 101);
            this.txt费率.Name = "txt费率";
            this.txt费率.Properties.DisplayFormat.FormatString = "n2";
            this.txt费率.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.txt费率.Properties.EditFormat.FormatString = "n2";
            this.txt费率.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.txt费率.Size = new System.Drawing.Size(122, 20);
            this.txt费率.TabIndex = 264;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(238, 104);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(29, 12);
            this.label8.TabIndex = 263;
            this.label8.Text = "费率";
            this.label8.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 105);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(53, 12);
            this.label1.TabIndex = 255;
            this.label1.Text = "考核金额";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txt备注
            // 
            this.txt备注.Location = new System.Drawing.Point(71, 127);
            this.txt备注.Name = "txt备注";
            this.txt备注.Properties.DisplayFormat.FormatString = "n2";
            this.txt备注.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.txt备注.Properties.EditFormat.FormatString = "n2";
            this.txt备注.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.txt备注.Size = new System.Drawing.Size(653, 20);
            this.txt备注.TabIndex = 253;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(26, 132);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(29, 12);
            this.label7.TabIndex = 252;
            this.label7.Text = "备注";
            this.label7.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // dtm
            // 
            this.dtm.EditValue = null;
            this.dtm.Location = new System.Drawing.Point(286, 73);
            this.dtm.Name = "dtm";
            this.dtm.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.dtm.Properties.VistaTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
            this.dtm.Size = new System.Drawing.Size(122, 20);
            this.dtm.TabIndex = 246;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(213, 76);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(53, 12);
            this.label2.TabIndex = 245;
            this.label2.Text = "单据日期";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txt单据号
            // 
            this.txt单据号.Enabled = false;
            this.txt单据号.Location = new System.Drawing.Point(72, 73);
            this.txt单据号.Name = "txt单据号";
            this.txt单据号.Properties.DisplayFormat.FormatString = "n2";
            this.txt单据号.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.txt单据号.Properties.EditFormat.FormatString = "n2";
            this.txt单据号.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.txt单据号.Properties.Mask.EditMask = "n2";
            this.txt单据号.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Numeric;
            this.txt单据号.Size = new System.Drawing.Size(122, 20);
            this.txt单据号.TabIndex = 239;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(18, 75);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(41, 12);
            this.label4.TabIndex = 232;
            this.label4.Text = "单据号";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // 高开返利核销单_SZ
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.menuStrip1);
            this.Name = "高开返利核销单_SZ";
            this.Size = new System.Drawing.Size(1040, 699);
            this.Load += new System.EventHandler(this.Frm_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl返利单)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView返利单)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.lookUpEdit区域.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lookUpEditcCusName.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lookUpEditcCusCode.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txt开票金额.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txt考核金额.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txt费率.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txt备注.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtm.Properties.VistaTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtm.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txt单据号.Properties)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem btnDel;
        private System.Windows.Forms.ToolStripMenuItem btnSave;
        private DevExpress.XtraEditors.LabelControl labelControl1;
        private DevExpress.XtraGrid.GridControl gridControl返利单;
        private System.Windows.Forms.Panel panel1;
        private DevExpress.XtraEditors.DateEdit dtm;
        private System.Windows.Forms.Label label2;
        private DevExpress.XtraEditors.TextEdit txt单据号;
        private System.Windows.Forms.Label label4;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView返利单;
        private DevExpress.XtraGrid.Columns.GridColumn gridCol发票号;
        private DevExpress.XtraGrid.Columns.GridColumn gridCol发票日期;
        private DevExpress.XtraGrid.Columns.GridColumn gridCol客户编码;
        private DevExpress.XtraGrid.Columns.GridColumn gridCol客户名称;
        private DevExpress.XtraGrid.Columns.GridColumn gridCol存货编码;
        private DevExpress.XtraGrid.Columns.GridColumn gridCol存货名称;
        private DevExpress.XtraGrid.Columns.GridColumn gridCol规格型号;
        private DevExpress.XtraEditors.LookUpEdit lookUpEditcCusName;
        private System.Windows.Forms.Label label6;
        private DevExpress.XtraEditors.LookUpEdit lookUpEditcCusCode;
        private DevExpress.XtraGrid.Columns.GridColumn gridCol差价税率;
        private DevExpress.XtraGrid.Columns.GridColumn gridCol差价税额;
        private DevExpress.XtraGrid.Columns.GridColumn gridCol返利金额;
        private DevExpress.XtraEditors.TextEdit txt备注;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Button btnLoad;
        private DevExpress.XtraGrid.Columns.GridColumn gridCol代理商编码;
        private DevExpress.XtraGrid.Columns.GridColumn gridCol代理商;
        private DevExpress.XtraGrid.Columns.GridColumn gridColcPersonCode;
        private DevExpress.XtraGrid.Columns.GridColumn gridColcPersonName;
        private DevExpress.XtraGrid.Columns.GridColumn gridColcDCCode;
        private DevExpress.XtraGrid.Columns.GridColumn gridColcDCName;
        private DevExpress.XtraGrid.Columns.GridColumn gridColiID;
        private DevExpress.XtraGrid.Columns.GridColumn gridColcCode;
        private DevExpress.XtraGrid.Columns.GridColumn gridColdtmDate;
        private DevExpress.XtraGrid.Columns.GridColumn gridColFLD_iID;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label5;
        private DevExpress.XtraEditors.LookUpEdit lookUpEdit区域;
        private DevExpress.XtraEditors.TextEdit txt开票金额;
        private System.Windows.Forms.Label label9;
        private DevExpress.XtraEditors.TextEdit txt费率;
        private System.Windows.Forms.Label label8;
        private DevExpress.XtraGrid.Columns.GridColumn gridColbchoose;
        private DevExpress.XtraEditors.TextEdit txt考核金额;
        private DevExpress.XtraGrid.Columns.GridColumn gridCol发票金额;
        private System.Windows.Forms.ToolStripMenuItem btnPrint;
        private System.Windows.Forms.ToolStripMenuItem btnPrintSet;
    }
}
