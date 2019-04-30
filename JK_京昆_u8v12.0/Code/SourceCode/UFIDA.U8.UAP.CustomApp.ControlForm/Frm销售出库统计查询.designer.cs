namespace UFIDA.U8.UAP.CustomApp.ControlForm
{
    partial class Frm销售出库统计查询
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Frm销售出库统计查询));
            this.lookUpEdit部门 = new DevExpress.XtraEditors.LookUpEdit();
            this.buttonEdit部门 = new DevExpress.XtraEditors.ButtonEdit();
            this.label6 = new System.Windows.Forms.Label();
            this.radioButton4 = new System.Windows.Forms.RadioButton();
            this.radioButton3 = new System.Windows.Forms.RadioButton();
            this.radioButton2 = new System.Windows.Forms.RadioButton();
            this.radioButton1 = new System.Windows.Forms.RadioButton();
            this.lookUpEdit销售员名称 = new DevExpress.XtraEditors.LookUpEdit();
            this.lookUpEdit客户名称 = new DevExpress.XtraEditors.LookUpEdit();
            this.lookUpEdit存货名称2 = new DevExpress.XtraEditors.LookUpEdit();
            this.lookUpEdit存货名称1 = new DevExpress.XtraEditors.LookUpEdit();
            this.label5 = new System.Windows.Forms.Label();
            this.txt年 = new DevExpress.XtraEditors.TextEdit();
            this.buttonEdit销售员 = new DevExpress.XtraEditors.ButtonEdit();
            this.label4 = new System.Windows.Forms.Label();
            this.buttonEdit客户 = new DevExpress.XtraEditors.ButtonEdit();
            this.label3 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.buttonEdit存货编码2 = new DevExpress.XtraEditors.ButtonEdit();
            this.buttonEdit存货编码1 = new DevExpress.XtraEditors.ButtonEdit();
            this.label2 = new System.Windows.Forms.Label();
            this.btnExcel = new DevExpress.XtraEditors.SimpleButton();
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            this.btnRefresh = new DevExpress.XtraEditors.SimpleButton();
            this.myTreeList1 = new MyXtraTreeList.MyTreeList();
            this.lookUpEdit仓库 = new DevExpress.XtraEditors.LookUpEdit();
            this.buttonEdit仓库 = new DevExpress.XtraEditors.ButtonEdit();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.lookUpEditcDefine3 = new DevExpress.XtraEditors.LookUpEdit();
            this.label9 = new System.Windows.Forms.Label();
            this.lookUpEditcPosition = new DevExpress.XtraEditors.LookUpEdit();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.rdo未审 = new System.Windows.Forms.RadioButton();
            this.rdo审核 = new System.Windows.Forms.RadioButton();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.rdo数量 = new System.Windows.Forms.RadioButton();
            this.rdo金额 = new System.Windows.Forms.RadioButton();
            ((System.ComponentModel.ISupportInitialize)(this.lookUpEdit部门.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.buttonEdit部门.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lookUpEdit销售员名称.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lookUpEdit客户名称.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lookUpEdit存货名称2.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lookUpEdit存货名称1.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txt年.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.buttonEdit销售员.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.buttonEdit客户.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.buttonEdit存货编码2.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.buttonEdit存货编码1.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.myTreeList1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lookUpEdit仓库.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.buttonEdit仓库.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lookUpEditcDefine3.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lookUpEditcPosition.Properties)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.SuspendLayout();
            // 
            // lookUpEdit部门
            // 
            this.lookUpEdit部门.Enabled = false;
            this.lookUpEdit部门.Location = new System.Drawing.Point(583, 108);
            this.lookUpEdit部门.Name = "lookUpEdit部门";
            this.lookUpEdit部门.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.lookUpEdit部门.Size = new System.Drawing.Size(179, 20);
            this.lookUpEdit部门.TabIndex = 150;
            // 
            // buttonEdit部门
            // 
            this.buttonEdit部门.Location = new System.Drawing.Point(443, 108);
            this.buttonEdit部门.Name = "buttonEdit部门";
            this.buttonEdit部门.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
            this.buttonEdit部门.Size = new System.Drawing.Size(134, 20);
            this.buttonEdit部门.TabIndex = 149;
            this.buttonEdit部门.ButtonClick += new DevExpress.XtraEditors.Controls.ButtonPressedEventHandler(this.buttonEdit部门_ButtonClick);
            this.buttonEdit部门.EditValueChanged += new System.EventHandler(this.buttonEdit部门_EditValueChanged);
            this.buttonEdit部门.Leave += new System.EventHandler(this.buttonEdit部门_Leave);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(385, 113);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(29, 12);
            this.label6.TabIndex = 148;
            this.label6.Text = "部门";
            // 
            // radioButton4
            // 
            this.radioButton4.AutoSize = true;
            this.radioButton4.Location = new System.Drawing.Point(6, 26);
            this.radioButton4.Name = "radioButton4";
            this.radioButton4.Size = new System.Drawing.Size(47, 16);
            this.radioButton4.TabIndex = 147;
            this.radioButton4.Text = "客户";
            this.radioButton4.UseVisualStyleBackColor = true;
            this.radioButton4.CheckedChanged += new System.EventHandler(this.radioButton4_CheckedChanged);
            // 
            // radioButton3
            // 
            this.radioButton3.AutoSize = true;
            this.radioButton3.Checked = true;
            this.radioButton3.Location = new System.Drawing.Point(175, 26);
            this.radioButton3.Name = "radioButton3";
            this.radioButton3.Size = new System.Drawing.Size(47, 16);
            this.radioButton3.TabIndex = 146;
            this.radioButton3.TabStop = true;
            this.radioButton3.Text = "品名";
            this.radioButton3.UseVisualStyleBackColor = true;
            this.radioButton3.CheckedChanged += new System.EventHandler(this.radioButton3_CheckedChanged);
            // 
            // radioButton2
            // 
            this.radioButton2.AutoSize = true;
            this.radioButton2.Location = new System.Drawing.Point(110, 26);
            this.radioButton2.Name = "radioButton2";
            this.radioButton2.Size = new System.Drawing.Size(59, 16);
            this.radioButton2.TabIndex = 145;
            this.radioButton2.Text = "销售员";
            this.radioButton2.UseVisualStyleBackColor = true;
            this.radioButton2.CheckedChanged += new System.EventHandler(this.radioButton2_CheckedChanged);
            // 
            // radioButton1
            // 
            this.radioButton1.AutoSize = true;
            this.radioButton1.Location = new System.Drawing.Point(57, 26);
            this.radioButton1.Name = "radioButton1";
            this.radioButton1.Size = new System.Drawing.Size(47, 16);
            this.radioButton1.TabIndex = 144;
            this.radioButton1.Text = "部门";
            this.radioButton1.UseVisualStyleBackColor = true;
            this.radioButton1.CheckedChanged += new System.EventHandler(this.radioButton1_CheckedChanged);
            // 
            // lookUpEdit销售员名称
            // 
            this.lookUpEdit销售员名称.Enabled = false;
            this.lookUpEdit销售员名称.Location = new System.Drawing.Point(583, 81);
            this.lookUpEdit销售员名称.Name = "lookUpEdit销售员名称";
            this.lookUpEdit销售员名称.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.lookUpEdit销售员名称.Size = new System.Drawing.Size(179, 20);
            this.lookUpEdit销售员名称.TabIndex = 143;
            // 
            // lookUpEdit客户名称
            // 
            this.lookUpEdit客户名称.Enabled = false;
            this.lookUpEdit客户名称.Location = new System.Drawing.Point(583, 57);
            this.lookUpEdit客户名称.Name = "lookUpEdit客户名称";
            this.lookUpEdit客户名称.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.lookUpEdit客户名称.Size = new System.Drawing.Size(179, 20);
            this.lookUpEdit客户名称.TabIndex = 142;
            // 
            // lookUpEdit存货名称2
            // 
            this.lookUpEdit存货名称2.Enabled = false;
            this.lookUpEdit存货名称2.Location = new System.Drawing.Point(232, 107);
            this.lookUpEdit存货名称2.Name = "lookUpEdit存货名称2";
            this.lookUpEdit存货名称2.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.lookUpEdit存货名称2.Size = new System.Drawing.Size(134, 20);
            this.lookUpEdit存货名称2.TabIndex = 141;
            // 
            // lookUpEdit存货名称1
            // 
            this.lookUpEdit存货名称1.Enabled = false;
            this.lookUpEdit存货名称1.Location = new System.Drawing.Point(69, 107);
            this.lookUpEdit存货名称1.Name = "lookUpEdit存货名称1";
            this.lookUpEdit存货名称1.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.lookUpEdit存货名称1.Size = new System.Drawing.Size(117, 20);
            this.lookUpEdit存货名称1.TabIndex = 140;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(10, 62);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(29, 12);
            this.label5.TabIndex = 139;
            this.label5.Text = "年度";
            // 
            // txt年
            // 
            this.txt年.Location = new System.Drawing.Point(69, 57);
            this.txt年.Name = "txt年";
            this.txt年.Size = new System.Drawing.Size(100, 20);
            this.txt年.TabIndex = 138;
            // 
            // buttonEdit销售员
            // 
            this.buttonEdit销售员.Location = new System.Drawing.Point(443, 81);
            this.buttonEdit销售员.Name = "buttonEdit销售员";
            this.buttonEdit销售员.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
            this.buttonEdit销售员.Size = new System.Drawing.Size(134, 20);
            this.buttonEdit销售员.TabIndex = 137;
            this.buttonEdit销售员.ButtonClick += new DevExpress.XtraEditors.Controls.ButtonPressedEventHandler(this.buttonEdit销售员_ButtonClick);
            this.buttonEdit销售员.EditValueChanged += new System.EventHandler(this.buttonEdit销售员_EditValueChanged);
            this.buttonEdit销售员.Leave += new System.EventHandler(this.buttonEdit销售员_Leave);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(385, 86);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(41, 12);
            this.label4.TabIndex = 136;
            this.label4.Text = "销售员";
            // 
            // buttonEdit客户
            // 
            this.buttonEdit客户.Location = new System.Drawing.Point(443, 55);
            this.buttonEdit客户.Name = "buttonEdit客户";
            this.buttonEdit客户.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
            this.buttonEdit客户.Size = new System.Drawing.Size(134, 20);
            this.buttonEdit客户.TabIndex = 135;
            this.buttonEdit客户.ButtonClick += new DevExpress.XtraEditors.Controls.ButtonPressedEventHandler(this.buttonEdit客户_ButtonClick);
            this.buttonEdit客户.EditValueChanged += new System.EventHandler(this.buttonEdit客户_EditValueChanged);
            this.buttonEdit客户.Leave += new System.EventHandler(this.buttonEdit客户_Leave);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(385, 60);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(29, 12);
            this.label3.TabIndex = 134;
            this.label3.Text = "客户";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(192, 86);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(17, 12);
            this.label1.TabIndex = 133;
            this.label1.Text = "至";
            // 
            // buttonEdit存货编码2
            // 
            this.buttonEdit存货编码2.Location = new System.Drawing.Point(232, 81);
            this.buttonEdit存货编码2.Name = "buttonEdit存货编码2";
            this.buttonEdit存货编码2.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
            this.buttonEdit存货编码2.Size = new System.Drawing.Size(134, 20);
            this.buttonEdit存货编码2.TabIndex = 132;
            this.buttonEdit存货编码2.ButtonClick += new DevExpress.XtraEditors.Controls.ButtonPressedEventHandler(this.buttonEdit存货编码2_ButtonClick);
            this.buttonEdit存货编码2.EditValueChanged += new System.EventHandler(this.buttonEdit存货编码2_EditValueChanged);
            this.buttonEdit存货编码2.Leave += new System.EventHandler(this.buttonEdit存货编码2_Leave);
            // 
            // buttonEdit存货编码1
            // 
            this.buttonEdit存货编码1.Location = new System.Drawing.Point(69, 81);
            this.buttonEdit存货编码1.Name = "buttonEdit存货编码1";
            this.buttonEdit存货编码1.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
            this.buttonEdit存货编码1.Size = new System.Drawing.Size(117, 20);
            this.buttonEdit存货编码1.TabIndex = 131;
            this.buttonEdit存货编码1.ButtonClick += new DevExpress.XtraEditors.Controls.ButtonPressedEventHandler(this.buttonEdit存货编码1_ButtonClick);
            this.buttonEdit存货编码1.EditValueChanged += new System.EventHandler(this.buttonEdit存货编码1_EditValueChanged);
            this.buttonEdit存货编码1.Leave += new System.EventHandler(this.buttonEdit存货编码1_Leave);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(10, 86);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(53, 12);
            this.label2.TabIndex = 130;
            this.label2.Text = "存货编码";
            // 
            // btnExcel
            // 
            this.btnExcel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnExcel.Image = ((System.Drawing.Image)(resources.GetObject("btnExcel.Image")));
            this.btnExcel.ImageLocation = DevExpress.XtraEditors.ImageLocation.TopCenter;
            this.btnExcel.Location = new System.Drawing.Point(959, 8);
            this.btnExcel.Name = "btnExcel";
            this.btnExcel.Size = new System.Drawing.Size(61, 41);
            this.btnExcel.TabIndex = 129;
            this.btnExcel.Text = "导出";
            this.btnExcel.Click += new System.EventHandler(this.btnExcel_Click);
            // 
            // labelControl1
            // 
            this.labelControl1.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.labelControl1.Appearance.Font = new System.Drawing.Font("Tahoma", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelControl1.Location = new System.Drawing.Point(410, 13);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(168, 25);
            this.labelControl1.TabIndex = 128;
            this.labelControl1.Text = "销售出库统计查询";
            // 
            // btnRefresh
            // 
            this.btnRefresh.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnRefresh.Image = ((System.Drawing.Image)(resources.GetObject("btnRefresh.Image")));
            this.btnRefresh.ImageLocation = DevExpress.XtraEditors.ImageLocation.TopCenter;
            this.btnRefresh.Location = new System.Drawing.Point(886, 8);
            this.btnRefresh.Name = "btnRefresh";
            this.btnRefresh.Size = new System.Drawing.Size(61, 41);
            this.btnRefresh.TabIndex = 127;
            this.btnRefresh.Text = "过滤";
            this.btnRefresh.Click += new System.EventHandler(this.btnRefresh_Click);
            // 
            // myTreeList1
            // 
            this.myTreeList1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.myTreeList1.Location = new System.Drawing.Point(1, 174);
            this.myTreeList1.Name = "myTreeList1";
            this.myTreeList1.OptionsPrint.AutoWidth = false;
            this.myTreeList1.OptionsView.AutoWidth = false;
            this.myTreeList1.Size = new System.Drawing.Size(1044, 423);
            this.myTreeList1.TabIndex = 126;
            this.myTreeList1.DoubleClick += new System.EventHandler(this.myTreeList1_DoubleClick);
            // 
            // lookUpEdit仓库
            // 
            this.lookUpEdit仓库.Enabled = false;
            this.lookUpEdit仓库.Location = new System.Drawing.Point(583, 135);
            this.lookUpEdit仓库.Name = "lookUpEdit仓库";
            this.lookUpEdit仓库.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.lookUpEdit仓库.Size = new System.Drawing.Size(179, 20);
            this.lookUpEdit仓库.TabIndex = 159;
            // 
            // buttonEdit仓库
            // 
            this.buttonEdit仓库.Location = new System.Drawing.Point(443, 135);
            this.buttonEdit仓库.Name = "buttonEdit仓库";
            this.buttonEdit仓库.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
            this.buttonEdit仓库.Size = new System.Drawing.Size(134, 20);
            this.buttonEdit仓库.TabIndex = 158;
            this.buttonEdit仓库.ButtonClick += new DevExpress.XtraEditors.Controls.ButtonPressedEventHandler(this.buttonEdit仓库_ButtonClick);
            this.buttonEdit仓库.EditValueChanged += new System.EventHandler(this.buttonEdit仓库_EditValueChanged);
            this.buttonEdit仓库.Leave += new System.EventHandler(this.buttonEdit仓库_Leave);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(385, 140);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(53, 12);
            this.label7.TabIndex = 157;
            this.label7.Text = "公司名称";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(192, 140);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(29, 12);
            this.label8.TabIndex = 164;
            this.label8.Text = "货区";
            this.label8.Visible = false;
            // 
            // lookUpEditcDefine3
            // 
            this.lookUpEditcDefine3.Location = new System.Drawing.Point(232, 135);
            this.lookUpEditcDefine3.Name = "lookUpEditcDefine3";
            this.lookUpEditcDefine3.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.lookUpEditcDefine3.Properties.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("cValue", 40, "编码")});
            this.lookUpEditcDefine3.Properties.DisplayMember = "cValue";
            this.lookUpEditcDefine3.Properties.NullText = "";
            this.lookUpEditcDefine3.Properties.ValueMember = "cValue";
            this.lookUpEditcDefine3.Size = new System.Drawing.Size(134, 20);
            this.lookUpEditcDefine3.TabIndex = 163;
            this.lookUpEditcDefine3.Visible = false;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(10, 137);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(29, 12);
            this.label9.TabIndex = 162;
            this.label9.Text = "货位";
            this.label9.Visible = false;
            // 
            // lookUpEditcPosition
            // 
            this.lookUpEditcPosition.Location = new System.Drawing.Point(69, 134);
            this.lookUpEditcPosition.Name = "lookUpEditcPosition";
            this.lookUpEditcPosition.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.lookUpEditcPosition.Properties.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("cPosCode", 40, "编码"),
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("cPosName", "名称")});
            this.lookUpEditcPosition.Properties.DisplayMember = "cPosCode";
            this.lookUpEditcPosition.Properties.NullText = "";
            this.lookUpEditcPosition.Properties.ValueMember = "cPosCode";
            this.lookUpEditcPosition.Size = new System.Drawing.Size(117, 20);
            this.lookUpEditcPosition.TabIndex = 161;
            this.lookUpEditcPosition.Visible = false;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.radioButton2);
            this.groupBox1.Controls.Add(this.radioButton1);
            this.groupBox1.Controls.Add(this.radioButton4);
            this.groupBox1.Controls.Add(this.radioButton3);
            this.groupBox1.Location = new System.Drawing.Point(778, 50);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(242, 52);
            this.groupBox1.TabIndex = 165;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "分组条件";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.rdo未审);
            this.groupBox2.Controls.Add(this.rdo审核);
            this.groupBox2.Location = new System.Drawing.Point(778, 104);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(118, 52);
            this.groupBox2.TabIndex = 166;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "是否审核";
            // 
            // rdo未审
            // 
            this.rdo未审.AutoSize = true;
            this.rdo未审.Location = new System.Drawing.Point(61, 20);
            this.rdo未审.Name = "rdo未审";
            this.rdo未审.Size = new System.Drawing.Size(47, 16);
            this.rdo未审.TabIndex = 144;
            this.rdo未审.Text = "未审";
            this.rdo未审.UseVisualStyleBackColor = true;
            // 
            // rdo审核
            // 
            this.rdo审核.AutoSize = true;
            this.rdo审核.Checked = true;
            this.rdo审核.Location = new System.Drawing.Point(8, 20);
            this.rdo审核.Name = "rdo审核";
            this.rdo审核.Size = new System.Drawing.Size(47, 16);
            this.rdo审核.TabIndex = 147;
            this.rdo审核.TabStop = true;
            this.rdo审核.Text = "审核";
            this.rdo审核.UseVisualStyleBackColor = true;
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.rdo数量);
            this.groupBox3.Controls.Add(this.rdo金额);
            this.groupBox3.Location = new System.Drawing.Point(902, 104);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(118, 52);
            this.groupBox3.TabIndex = 167;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "统计查询类别";
            // 
            // rdo数量
            // 
            this.rdo数量.AutoSize = true;
            this.rdo数量.Checked = true;
            this.rdo数量.Location = new System.Drawing.Point(61, 20);
            this.rdo数量.Name = "rdo数量";
            this.rdo数量.Size = new System.Drawing.Size(47, 16);
            this.rdo数量.TabIndex = 144;
            this.rdo数量.TabStop = true;
            this.rdo数量.Text = "数量";
            this.rdo数量.UseVisualStyleBackColor = true;
            // 
            // rdo金额
            // 
            this.rdo金额.AutoSize = true;
            this.rdo金额.Location = new System.Drawing.Point(8, 20);
            this.rdo金额.Name = "rdo金额";
            this.rdo金额.Size = new System.Drawing.Size(47, 16);
            this.rdo金额.TabIndex = 147;
            this.rdo金额.Text = "金额";
            this.rdo金额.UseVisualStyleBackColor = true;
            // 
            // Frm销售出库统计查询
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.lookUpEditcDefine3);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.lookUpEditcPosition);
            this.Controls.Add(this.lookUpEdit仓库);
            this.Controls.Add(this.buttonEdit仓库);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.lookUpEdit部门);
            this.Controls.Add(this.buttonEdit部门);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.lookUpEdit销售员名称);
            this.Controls.Add(this.lookUpEdit客户名称);
            this.Controls.Add(this.lookUpEdit存货名称2);
            this.Controls.Add(this.lookUpEdit存货名称1);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.txt年);
            this.Controls.Add(this.buttonEdit销售员);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.buttonEdit客户);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.buttonEdit存货编码2);
            this.Controls.Add(this.buttonEdit存货编码1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.btnExcel);
            this.Controls.Add(this.labelControl1);
            this.Controls.Add(this.btnRefresh);
            this.Controls.Add(this.myTreeList1);
            this.Name = "Frm销售出库统计查询";
            this.Size = new System.Drawing.Size(1047, 600);
            this.Load += new System.EventHandler(this.Frm销售出库统计查询_Load);
            ((System.ComponentModel.ISupportInitialize)(this.lookUpEdit部门.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.buttonEdit部门.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lookUpEdit销售员名称.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lookUpEdit客户名称.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lookUpEdit存货名称2.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lookUpEdit存货名称1.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txt年.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.buttonEdit销售员.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.buttonEdit客户.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.buttonEdit存货编码2.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.buttonEdit存货编码1.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.myTreeList1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lookUpEdit仓库.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.buttonEdit仓库.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lookUpEditcDefine3.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lookUpEditcPosition.Properties)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraEditors.LookUpEdit lookUpEdit部门;
        private DevExpress.XtraEditors.ButtonEdit buttonEdit部门;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.RadioButton radioButton4;
        private System.Windows.Forms.RadioButton radioButton3;
        private System.Windows.Forms.RadioButton radioButton2;
        private System.Windows.Forms.RadioButton radioButton1;
        private DevExpress.XtraEditors.LookUpEdit lookUpEdit销售员名称;
        private DevExpress.XtraEditors.LookUpEdit lookUpEdit客户名称;
        private DevExpress.XtraEditors.LookUpEdit lookUpEdit存货名称2;
        private DevExpress.XtraEditors.LookUpEdit lookUpEdit存货名称1;
        private System.Windows.Forms.Label label5;
        private DevExpress.XtraEditors.TextEdit txt年;
        private DevExpress.XtraEditors.ButtonEdit buttonEdit销售员;
        private System.Windows.Forms.Label label4;
        private DevExpress.XtraEditors.ButtonEdit buttonEdit客户;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label1;
        private DevExpress.XtraEditors.ButtonEdit buttonEdit存货编码2;
        private DevExpress.XtraEditors.ButtonEdit buttonEdit存货编码1;
        private System.Windows.Forms.Label label2;
        private DevExpress.XtraEditors.SimpleButton btnExcel;
        private DevExpress.XtraEditors.LabelControl labelControl1;
        private DevExpress.XtraEditors.SimpleButton btnRefresh;
        private MyXtraTreeList.MyTreeList myTreeList1;
        private DevExpress.XtraEditors.LookUpEdit lookUpEdit仓库;
        private DevExpress.XtraEditors.ButtonEdit buttonEdit仓库;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private DevExpress.XtraEditors.LookUpEdit lookUpEditcDefine3;
        private System.Windows.Forms.Label label9;
        private DevExpress.XtraEditors.LookUpEdit lookUpEditcPosition;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.RadioButton rdo未审;
        private System.Windows.Forms.RadioButton rdo审核;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.RadioButton rdo数量;
        private System.Windows.Forms.RadioButton rdo金额;

    }
}
