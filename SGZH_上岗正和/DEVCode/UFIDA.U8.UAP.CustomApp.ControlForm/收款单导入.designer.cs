namespace UFIDA.U8.UAP.CustomApp.ControlForm
{
    partial class 收款单导入
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(收款单导入));
            this.btnSave = new DevExpress.XtraEditors.SimpleButton();
            this.btnLoad = new DevExpress.XtraEditors.SimpleButton();
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            this.gridControl1 = new DevExpress.XtraGrid.GridControl();
            this.gridView1 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.gridColChk = new DevExpress.XtraGrid.Columns.GridColumn();
            this.ItemCheckEdit1 = new DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit();
            this.gridCol发票号码 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridCol发票ID = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridCol收款单ID = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridCol核销金额 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridCol结算科目 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridCol贷方科目 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridCol币种 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridCol汇率 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridCol结算方式 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.ItemLookUpEdit结算方式 = new DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit();
            this.gridCol客户名 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridCol单据日期 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridCol核销单ID = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridCol结算方式2 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.checkEdit1 = new DevExpress.XtraEditors.CheckEdit();
            this.tsbGet = new DevExpress.XtraEditors.SimpleButton();
            this.label5 = new System.Windows.Forms.Label();
            this.dateEdit结束日期 = new DevExpress.XtraEditors.DateEdit();
            this.label4 = new System.Windows.Forms.Label();
            this.dateEdit开始日期 = new DevExpress.XtraEditors.DateEdit();
            this.textBox发票号码 = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.textBox发票ID = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.textBox客户 = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.rdo已导入 = new System.Windows.Forms.RadioButton();
            this.rdo未导入 = new System.Windows.Forms.RadioButton();
            this.textBox收款单ID = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.panelControl1 = new DevExpress.XtraEditors.PanelControl();
            this.simpleButton1 = new DevExpress.XtraEditors.SimpleButton();
            this.txt总金额 = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ItemCheckEdit1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ItemLookUpEdit结算方式)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.checkEdit1.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dateEdit结束日期.Properties.VistaTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dateEdit结束日期.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dateEdit开始日期.Properties.VistaTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dateEdit开始日期.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).BeginInit();
            this.panelControl1.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnSave
            // 
            this.btnSave.Image = ((System.Drawing.Image)(resources.GetObject("btnSave.Image")));
            this.btnSave.ImageLocation = DevExpress.XtraEditors.ImageLocation.TopCenter;
            this.btnSave.Location = new System.Drawing.Point(935, 55);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(46, 41);
            this.btnSave.TabIndex = 111;
            this.btnSave.Text = "保存";
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // btnLoad
            // 
            this.btnLoad.Image = ((System.Drawing.Image)(resources.GetObject("btnLoad.Image")));
            this.btnLoad.ImageLocation = DevExpress.XtraEditors.ImageLocation.TopCenter;
            this.btnLoad.Location = new System.Drawing.Point(883, 55);
            this.btnLoad.Name = "btnLoad";
            this.btnLoad.Size = new System.Drawing.Size(46, 41);
            this.btnLoad.TabIndex = 110;
            this.btnLoad.Text = "加载";
            this.btnLoad.Click += new System.EventHandler(this.btnLoad_Click);
            // 
            // labelControl1
            // 
            this.labelControl1.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.labelControl1.Appearance.Font = new System.Drawing.Font("Tahoma", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelControl1.Location = new System.Drawing.Point(508, 14);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(105, 25);
            this.labelControl1.TabIndex = 109;
            this.labelControl1.Text = "收款单导入";
            // 
            // gridControl1
            // 
            this.gridControl1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.gridControl1.Location = new System.Drawing.Point(5, 118);
            this.gridControl1.LookAndFeel.SkinName = "Office 2010 Blue";
            this.gridControl1.MainView = this.gridView1;
            this.gridControl1.Name = "gridControl1";
            this.gridControl1.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.ItemCheckEdit1,
            this.ItemLookUpEdit结算方式});
            this.gridControl1.Size = new System.Drawing.Size(1123, 265);
            this.gridControl1.TabIndex = 113;
            this.gridControl1.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView1});
            // 
            // gridView1
            // 
            this.gridView1.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.gridColChk,
            this.gridCol发票号码,
            this.gridCol发票ID,
            this.gridCol收款单ID,
            this.gridCol核销金额,
            this.gridCol结算科目,
            this.gridCol贷方科目,
            this.gridCol币种,
            this.gridCol汇率,
            this.gridCol结算方式,
            this.gridCol客户名,
            this.gridCol单据日期,
            this.gridCol核销单ID,
            this.gridCol结算方式2});
            this.gridView1.GridControl = this.gridControl1;
            this.gridView1.IndicatorWidth = 40;
            this.gridView1.Name = "gridView1";
            this.gridView1.OptionsBehavior.AllowDeleteRows = DevExpress.Utils.DefaultBoolean.True;
            this.gridView1.OptionsBehavior.EditorShowMode = DevExpress.Utils.EditorShowMode.MouseDown;
            this.gridView1.OptionsCustomization.AllowGroup = false;
            this.gridView1.OptionsCustomization.AllowQuickHideColumns = false;
            this.gridView1.OptionsView.ColumnAutoWidth = false;
            this.gridView1.OptionsView.ShowGroupPanel = false;
            this.gridView1.CustomDrawRowIndicator += new DevExpress.XtraGrid.Views.Grid.RowIndicatorCustomDrawEventHandler(this.gridView1_CustomDrawRowIndicator);
            // 
            // gridColChk
            // 
            this.gridColChk.Caption = "选择";
            this.gridColChk.ColumnEdit = this.ItemCheckEdit1;
            this.gridColChk.FieldName = "选择";
            this.gridColChk.Name = "gridColChk";
            this.gridColChk.Visible = true;
            this.gridColChk.VisibleIndex = 0;
            this.gridColChk.Width = 37;
            // 
            // ItemCheckEdit1
            // 
            this.ItemCheckEdit1.AutoHeight = false;
            this.ItemCheckEdit1.Name = "ItemCheckEdit1";
            this.ItemCheckEdit1.CheckedChanged += new System.EventHandler(this.ItemCheckEdit1_CheckedChanged);
            // 
            // gridCol发票号码
            // 
            this.gridCol发票号码.Caption = "发票号码";
            this.gridCol发票号码.FieldName = "发票号码";
            this.gridCol发票号码.Name = "gridCol发票号码";
            this.gridCol发票号码.OptionsColumn.AllowEdit = false;
            this.gridCol发票号码.Visible = true;
            this.gridCol发票号码.VisibleIndex = 2;
            // 
            // gridCol发票ID
            // 
            this.gridCol发票ID.Caption = "发票ID";
            this.gridCol发票ID.FieldName = "发票ID";
            this.gridCol发票ID.Name = "gridCol发票ID";
            this.gridCol发票ID.OptionsColumn.AllowEdit = false;
            this.gridCol发票ID.Visible = true;
            this.gridCol发票ID.VisibleIndex = 1;
            // 
            // gridCol收款单ID
            // 
            this.gridCol收款单ID.Caption = "收款单ID";
            this.gridCol收款单ID.FieldName = "收款单ID";
            this.gridCol收款单ID.Name = "gridCol收款单ID";
            this.gridCol收款单ID.OptionsColumn.AllowEdit = false;
            this.gridCol收款单ID.Visible = true;
            this.gridCol收款单ID.VisibleIndex = 3;
            // 
            // gridCol核销金额
            // 
            this.gridCol核销金额.Caption = "核销金额";
            this.gridCol核销金额.FieldName = "核销金额";
            this.gridCol核销金额.Name = "gridCol核销金额";
            this.gridCol核销金额.OptionsColumn.AllowEdit = false;
            this.gridCol核销金额.Visible = true;
            this.gridCol核销金额.VisibleIndex = 6;
            // 
            // gridCol结算科目
            // 
            this.gridCol结算科目.Caption = "结算科目";
            this.gridCol结算科目.FieldName = "结算科目";
            this.gridCol结算科目.Name = "gridCol结算科目";
            this.gridCol结算科目.OptionsColumn.AllowEdit = false;
            this.gridCol结算科目.Visible = true;
            this.gridCol结算科目.VisibleIndex = 7;
            // 
            // gridCol贷方科目
            // 
            this.gridCol贷方科目.Caption = "贷方科目";
            this.gridCol贷方科目.FieldName = "贷方科目";
            this.gridCol贷方科目.Name = "gridCol贷方科目";
            this.gridCol贷方科目.OptionsColumn.AllowEdit = false;
            this.gridCol贷方科目.Visible = true;
            this.gridCol贷方科目.VisibleIndex = 8;
            // 
            // gridCol币种
            // 
            this.gridCol币种.Caption = "币种";
            this.gridCol币种.FieldName = "币种";
            this.gridCol币种.Name = "gridCol币种";
            this.gridCol币种.OptionsColumn.AllowEdit = false;
            this.gridCol币种.Visible = true;
            this.gridCol币种.VisibleIndex = 9;
            // 
            // gridCol汇率
            // 
            this.gridCol汇率.Caption = "汇率";
            this.gridCol汇率.FieldName = "汇率";
            this.gridCol汇率.Name = "gridCol汇率";
            this.gridCol汇率.OptionsColumn.AllowEdit = false;
            this.gridCol汇率.Visible = true;
            this.gridCol汇率.VisibleIndex = 10;
            // 
            // gridCol结算方式
            // 
            this.gridCol结算方式.Caption = "结算方式";
            this.gridCol结算方式.ColumnEdit = this.ItemLookUpEdit结算方式;
            this.gridCol结算方式.FieldName = "付费方式";
            this.gridCol结算方式.Name = "gridCol结算方式";
            this.gridCol结算方式.Visible = true;
            this.gridCol结算方式.VisibleIndex = 11;
            // 
            // ItemLookUpEdit结算方式
            // 
            this.ItemLookUpEdit结算方式.AutoHeight = false;
            this.ItemLookUpEdit结算方式.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.ItemLookUpEdit结算方式.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("业务系统编码", "业务系统编码"),
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("结算方式编码", "结算方式编码"),
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("cSSName", "结算方式名称")});
            this.ItemLookUpEdit结算方式.DisplayMember = "cSSCode";
            this.ItemLookUpEdit结算方式.Name = "ItemLookUpEdit结算方式";
            this.ItemLookUpEdit结算方式.ValueMember = "业务系统编码";
            // 
            // gridCol客户名
            // 
            this.gridCol客户名.Caption = "客户名";
            this.gridCol客户名.FieldName = "客户编码";
            this.gridCol客户名.Name = "gridCol客户名";
            this.gridCol客户名.OptionsColumn.AllowEdit = false;
            this.gridCol客户名.Visible = true;
            this.gridCol客户名.VisibleIndex = 5;
            this.gridCol客户名.Width = 189;
            // 
            // gridCol单据日期
            // 
            this.gridCol单据日期.Caption = "单据日期";
            this.gridCol单据日期.FieldName = "单据日期";
            this.gridCol单据日期.Name = "gridCol单据日期";
            this.gridCol单据日期.OptionsColumn.AllowEdit = false;
            this.gridCol单据日期.Visible = true;
            this.gridCol单据日期.VisibleIndex = 12;
            // 
            // gridCol核销单ID
            // 
            this.gridCol核销单ID.Caption = "核销单ID";
            this.gridCol核销单ID.FieldName = "核销单ID";
            this.gridCol核销单ID.Name = "gridCol核销单ID";
            this.gridCol核销单ID.OptionsColumn.AllowEdit = false;
            this.gridCol核销单ID.Visible = true;
            this.gridCol核销单ID.VisibleIndex = 4;
            // 
            // gridCol结算方式2
            // 
            this.gridCol结算方式2.Caption = "结算方式2";
            this.gridCol结算方式2.FieldName = "付费方式2";
            this.gridCol结算方式2.Name = "gridCol结算方式2";
            this.gridCol结算方式2.Visible = true;
            this.gridCol结算方式2.VisibleIndex = 13;
            // 
            // checkEdit1
            // 
            this.checkEdit1.Location = new System.Drawing.Point(17, 79);
            this.checkEdit1.Name = "checkEdit1";
            this.checkEdit1.Properties.Caption = "全选";
            this.checkEdit1.Size = new System.Drawing.Size(75, 19);
            this.checkEdit1.TabIndex = 115;
            this.checkEdit1.CheckedChanged += new System.EventHandler(this.checkEdit1_CheckedChanged);
            // 
            // tsbGet
            // 
            this.tsbGet.Image = ((System.Drawing.Image)(resources.GetObject("tsbGet.Image")));
            this.tsbGet.ImageLocation = DevExpress.XtraEditors.ImageLocation.TopCenter;
            this.tsbGet.Location = new System.Drawing.Point(1049, 55);
            this.tsbGet.Name = "tsbGet";
            this.tsbGet.Size = new System.Drawing.Size(65, 41);
            this.tsbGet.TabIndex = 135;
            this.tsbGet.Text = "凭证反写";
            this.tsbGet.Click += new System.EventHandler(this.tsbGet_Click);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(497, 82);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(77, 12);
            this.label5.TabIndex = 154;
            this.label5.Text = "收款结束日期";
            // 
            // dateEdit结束日期
            // 
            this.dateEdit结束日期.EditValue = null;
            this.dateEdit结束日期.Location = new System.Drawing.Point(580, 78);
            this.dateEdit结束日期.Name = "dateEdit结束日期";
            this.dateEdit结束日期.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.dateEdit结束日期.Properties.VistaTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
            this.dateEdit结束日期.Size = new System.Drawing.Size(100, 20);
            this.dateEdit结束日期.TabIndex = 153;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(497, 55);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(77, 12);
            this.label4.TabIndex = 152;
            this.label4.Text = "收款开始日期";
            // 
            // dateEdit开始日期
            // 
            this.dateEdit开始日期.EditValue = null;
            this.dateEdit开始日期.Location = new System.Drawing.Point(580, 51);
            this.dateEdit开始日期.Name = "dateEdit开始日期";
            this.dateEdit开始日期.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.dateEdit开始日期.Properties.VistaTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
            this.dateEdit开始日期.Size = new System.Drawing.Size(100, 20);
            this.dateEdit开始日期.TabIndex = 151;
            // 
            // textBox发票号码
            // 
            this.textBox发票号码.Location = new System.Drawing.Point(149, 51);
            this.textBox发票号码.Name = "textBox发票号码";
            this.textBox发票号码.Size = new System.Drawing.Size(145, 21);
            this.textBox发票号码.TabIndex = 150;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(90, 55);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(53, 12);
            this.label3.TabIndex = 149;
            this.label3.Text = "发票号码";
            // 
            // textBox发票ID
            // 
            this.textBox发票ID.Location = new System.Drawing.Point(149, 78);
            this.textBox发票ID.Name = "textBox发票ID";
            this.textBox发票ID.Size = new System.Drawing.Size(145, 21);
            this.textBox发票ID.TabIndex = 148;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(102, 82);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(41, 12);
            this.label2.TabIndex = 147;
            this.label2.Text = "发票ID";
            // 
            // textBox客户
            // 
            this.textBox客户.Location = new System.Drawing.Point(377, 51);
            this.textBox客户.Name = "textBox客户";
            this.textBox客户.Size = new System.Drawing.Size(107, 21);
            this.textBox客户.TabIndex = 146;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(309, 55);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(29, 12);
            this.label1.TabIndex = 145;
            this.label1.Text = "客户";
            // 
            // rdo已导入
            // 
            this.rdo已导入.AutoSize = true;
            this.rdo已导入.Location = new System.Drawing.Point(786, 80);
            this.rdo已导入.Name = "rdo已导入";
            this.rdo已导入.Size = new System.Drawing.Size(59, 16);
            this.rdo已导入.TabIndex = 156;
            this.rdo已导入.Text = "已导入";
            this.rdo已导入.UseVisualStyleBackColor = true;
            // 
            // rdo未导入
            // 
            this.rdo未导入.AutoSize = true;
            this.rdo未导入.Checked = true;
            this.rdo未导入.Location = new System.Drawing.Point(711, 80);
            this.rdo未导入.Name = "rdo未导入";
            this.rdo未导入.Size = new System.Drawing.Size(59, 16);
            this.rdo未导入.TabIndex = 155;
            this.rdo未导入.TabStop = true;
            this.rdo未导入.Text = "未导入";
            this.rdo未导入.UseVisualStyleBackColor = true;
            this.rdo未导入.CheckedChanged += new System.EventHandler(this.rdo未导入_CheckedChanged);
            // 
            // textBox收款单ID
            // 
            this.textBox收款单ID.Location = new System.Drawing.Point(377, 78);
            this.textBox收款单ID.Name = "textBox收款单ID";
            this.textBox收款单ID.Size = new System.Drawing.Size(107, 21);
            this.textBox收款单ID.TabIndex = 158;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(309, 82);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(53, 12);
            this.label6.TabIndex = 157;
            this.label6.Text = "收款单ID";
            // 
            // panelControl1
            // 
            this.panelControl1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.panelControl1.Controls.Add(this.simpleButton1);
            this.panelControl1.Controls.Add(this.txt总金额);
            this.panelControl1.Controls.Add(this.label7);
            this.panelControl1.Controls.Add(this.gridControl1);
            this.panelControl1.Controls.Add(this.textBox收款单ID);
            this.panelControl1.Controls.Add(this.labelControl1);
            this.panelControl1.Controls.Add(this.label6);
            this.panelControl1.Controls.Add(this.btnLoad);
            this.panelControl1.Controls.Add(this.rdo已导入);
            this.panelControl1.Controls.Add(this.btnSave);
            this.panelControl1.Controls.Add(this.rdo未导入);
            this.panelControl1.Controls.Add(this.checkEdit1);
            this.panelControl1.Controls.Add(this.label5);
            this.panelControl1.Controls.Add(this.tsbGet);
            this.panelControl1.Controls.Add(this.dateEdit结束日期);
            this.panelControl1.Controls.Add(this.label1);
            this.panelControl1.Controls.Add(this.label4);
            this.panelControl1.Controls.Add(this.textBox客户);
            this.panelControl1.Controls.Add(this.dateEdit开始日期);
            this.panelControl1.Controls.Add(this.label2);
            this.panelControl1.Controls.Add(this.textBox发票号码);
            this.panelControl1.Controls.Add(this.textBox发票ID);
            this.panelControl1.Controls.Add(this.label3);
            this.panelControl1.Location = new System.Drawing.Point(3, 3);
            this.panelControl1.Name = "panelControl1";
            this.panelControl1.Size = new System.Drawing.Size(1133, 396);
            this.panelControl1.TabIndex = 159;
            // 
            // simpleButton1
            // 
            this.simpleButton1.Enabled = false;
            this.simpleButton1.Image = ((System.Drawing.Image)(resources.GetObject("simpleButton1.Image")));
            this.simpleButton1.ImageLocation = DevExpress.XtraEditors.ImageLocation.TopCenter;
            this.simpleButton1.Location = new System.Drawing.Point(987, 55);
            this.simpleButton1.Name = "simpleButton1";
            this.simpleButton1.Size = new System.Drawing.Size(56, 41);
            this.simpleButton1.TabIndex = 161;
            this.simpleButton1.Text = "取消导入";
            this.simpleButton1.Click += new System.EventHandler(this.simpleButton1_Click);
            // 
            // txt总金额
            // 
            this.txt总金额.Location = new System.Drawing.Point(757, 50);
            this.txt总金额.Name = "txt总金额";
            this.txt总金额.ReadOnly = true;
            this.txt总金额.Size = new System.Drawing.Size(109, 21);
            this.txt总金额.TabIndex = 160;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(686, 54);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(65, 12);
            this.label7.TabIndex = 159;
            this.label7.Text = "选中总金额";
            // 
            // 收款单导入
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.panelControl1);
            this.Name = "收款单导入";
            this.Size = new System.Drawing.Size(1139, 415);
            this.Load += new System.EventHandler(this.ProjectManager_Load);
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ItemCheckEdit1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ItemLookUpEdit结算方式)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.checkEdit1.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dateEdit结束日期.Properties.VistaTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dateEdit结束日期.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dateEdit开始日期.Properties.VistaTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dateEdit开始日期.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).EndInit();
            this.panelControl1.ResumeLayout(false);
            this.panelControl1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.SimpleButton btnSave;
        private DevExpress.XtraEditors.SimpleButton btnLoad;
        private DevExpress.XtraEditors.LabelControl labelControl1;
        private DevExpress.XtraGrid.GridControl gridControl1;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView1;
        private DevExpress.XtraEditors.CheckEdit checkEdit1;
        private DevExpress.XtraGrid.Columns.GridColumn gridColChk;
        private DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit ItemCheckEdit1;
        private DevExpress.XtraGrid.Columns.GridColumn gridCol发票号码;
        private DevExpress.XtraGrid.Columns.GridColumn gridCol收款单ID;
        private DevExpress.XtraGrid.Columns.GridColumn gridCol发票ID;
        private DevExpress.XtraGrid.Columns.GridColumn gridCol核销金额;
        private DevExpress.XtraGrid.Columns.GridColumn gridCol结算科目;
        private DevExpress.XtraGrid.Columns.GridColumn gridCol贷方科目;
        private DevExpress.XtraGrid.Columns.GridColumn gridCol币种;
        private DevExpress.XtraGrid.Columns.GridColumn gridCol汇率;
        private DevExpress.XtraGrid.Columns.GridColumn gridCol结算方式;
        private DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit ItemLookUpEdit结算方式;
        private DevExpress.XtraGrid.Columns.GridColumn gridCol客户名;
        private DevExpress.XtraGrid.Columns.GridColumn gridCol单据日期;
        private DevExpress.XtraEditors.SimpleButton tsbGet;
        private DevExpress.XtraGrid.Columns.GridColumn gridCol核销单ID;
        private System.Windows.Forms.Label label5;
        private DevExpress.XtraEditors.DateEdit dateEdit结束日期;
        private System.Windows.Forms.Label label4;
        private DevExpress.XtraEditors.DateEdit dateEdit开始日期;
        private System.Windows.Forms.TextBox textBox发票号码;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox textBox发票ID;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox textBox客户;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.RadioButton rdo已导入;
        private System.Windows.Forms.RadioButton rdo未导入;
        private System.Windows.Forms.TextBox textBox收款单ID;
        private System.Windows.Forms.Label label6;
        private DevExpress.XtraEditors.PanelControl panelControl1;
        private System.Windows.Forms.TextBox txt总金额;
        private System.Windows.Forms.Label label7;
        private DevExpress.XtraGrid.Columns.GridColumn gridCol结算方式2;
        private DevExpress.XtraEditors.SimpleButton simpleButton1;

    }
}
