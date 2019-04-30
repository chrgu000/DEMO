namespace UFIDA.U8.UAP.CustomApp.ControlForm
{
    partial class Frm收发存汇总查询
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Frm收发存汇总查询));
            this.lookUpEdit存货名称2 = new DevExpress.XtraEditors.LookUpEdit();
            this.lookUpEdit存货名称1 = new DevExpress.XtraEditors.LookUpEdit();
            this.label1 = new System.Windows.Forms.Label();
            this.buttonEdit存货编码2 = new DevExpress.XtraEditors.ButtonEdit();
            this.buttonEdit存货编码1 = new DevExpress.XtraEditors.ButtonEdit();
            this.label2 = new System.Windows.Forms.Label();
            this.btnExcel = new DevExpress.XtraEditors.SimpleButton();
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            this.btnRefresh = new DevExpress.XtraEditors.SimpleButton();
            this.myTreeList1 = new MyXtraTreeList.MyTreeList();
            this.label7 = new System.Windows.Forms.Label();
            this.buttonEdit仓库 = new DevExpress.XtraEditors.ButtonEdit();
            this.lookUpEdit仓库 = new DevExpress.XtraEditors.LookUpEdit();
            this.lookUpEditcPosition = new DevExpress.XtraEditors.LookUpEdit();
            this.label3 = new System.Windows.Forms.Label();
            this.lookUpEditcFree4 = new DevExpress.XtraEditors.LookUpEdit();
            this.label4 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.rdo未审 = new System.Windows.Forms.RadioButton();
            this.rdo审核 = new System.Windows.Forms.RadioButton();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.rdo今日 = new System.Windows.Forms.RadioButton();
            this.rdo本年 = new System.Windows.Forms.RadioButton();
            this.rdo本季 = new System.Windows.Forms.RadioButton();
            this.rdo本月 = new System.Windows.Forms.RadioButton();
            this.lookUpEditcFree3 = new DevExpress.XtraEditors.LookUpEdit();
            this.label5 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.rdo不包含未发生物料 = new System.Windows.Forms.RadioButton();
            this.rdo包含未发生物料 = new System.Windows.Forms.RadioButton();
            ((System.ComponentModel.ISupportInitialize)(this.lookUpEdit存货名称2.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lookUpEdit存货名称1.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.buttonEdit存货编码2.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.buttonEdit存货编码1.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.myTreeList1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.buttonEdit仓库.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lookUpEdit仓库.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lookUpEditcPosition.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lookUpEditcFree4.Properties)).BeginInit();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.lookUpEditcFree3.Properties)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // lookUpEdit存货名称2
            // 
            this.lookUpEdit存货名称2.Enabled = false;
            this.lookUpEdit存货名称2.Location = new System.Drawing.Point(237, 84);
            this.lookUpEdit存货名称2.Name = "lookUpEdit存货名称2";
            this.lookUpEdit存货名称2.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.lookUpEdit存货名称2.Size = new System.Drawing.Size(134, 21);
            this.lookUpEdit存货名称2.TabIndex = 83;
            // 
            // lookUpEdit存货名称1
            // 
            this.lookUpEdit存货名称1.Enabled = false;
            this.lookUpEdit存货名称1.Location = new System.Drawing.Point(74, 84);
            this.lookUpEdit存货名称1.Name = "lookUpEdit存货名称1";
            this.lookUpEdit存货名称1.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.lookUpEdit存货名称1.Size = new System.Drawing.Size(134, 21);
            this.lookUpEdit存货名称1.TabIndex = 82;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(214, 63);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(17, 12);
            this.label1.TabIndex = 77;
            this.label1.Text = "至";
            // 
            // buttonEdit存货编码2
            // 
            this.buttonEdit存货编码2.Location = new System.Drawing.Point(237, 58);
            this.buttonEdit存货编码2.Name = "buttonEdit存货编码2";
            this.buttonEdit存货编码2.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
            this.buttonEdit存货编码2.Size = new System.Drawing.Size(134, 21);
            this.buttonEdit存货编码2.TabIndex = 76;
            this.buttonEdit存货编码2.ButtonClick += new DevExpress.XtraEditors.Controls.ButtonPressedEventHandler(this.buttonEdit存货编码2_ButtonClick);
            this.buttonEdit存货编码2.EditValueChanged += new System.EventHandler(this.buttonEdit存货编码2_EditValueChanged);
            this.buttonEdit存货编码2.Leave += new System.EventHandler(this.buttonEdit存货编码2_Leave);
            // 
            // buttonEdit存货编码1
            // 
            this.buttonEdit存货编码1.Location = new System.Drawing.Point(74, 58);
            this.buttonEdit存货编码1.Name = "buttonEdit存货编码1";
            this.buttonEdit存货编码1.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
            this.buttonEdit存货编码1.Size = new System.Drawing.Size(134, 21);
            this.buttonEdit存货编码1.TabIndex = 75;
            this.buttonEdit存货编码1.ButtonClick += new DevExpress.XtraEditors.Controls.ButtonPressedEventHandler(this.buttonEdit存货编码1_ButtonClick);
            this.buttonEdit存货编码1.EditValueChanged += new System.EventHandler(this.buttonEdit存货编码1_EditValueChanged);
            this.buttonEdit存货编码1.Leave += new System.EventHandler(this.buttonEdit存货编码1_Leave);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(15, 63);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(53, 12);
            this.label2.TabIndex = 74;
            this.label2.Text = "存货编码";
            // 
            // btnExcel
            // 
            this.btnExcel.Image = ((System.Drawing.Image)(resources.GetObject("btnExcel.Image")));
            this.btnExcel.ImageLocation = DevExpress.XtraEditors.ImageLocation.TopCenter;
            this.btnExcel.Location = new System.Drawing.Point(1255, 56);
            this.btnExcel.Name = "btnExcel";
            this.btnExcel.Size = new System.Drawing.Size(61, 41);
            this.btnExcel.TabIndex = 73;
            this.btnExcel.Text = "导出";
            this.btnExcel.Click += new System.EventHandler(this.btnExcel_Click);
            // 
            // labelControl1
            // 
            this.labelControl1.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.labelControl1.Appearance.Font = new System.Drawing.Font("Tahoma", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelControl1.Location = new System.Drawing.Point(567, 12);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(147, 25);
            this.labelControl1.TabIndex = 72;
            this.labelControl1.Text = "收发存汇总查询";
            // 
            // btnRefresh
            // 
            this.btnRefresh.Image = ((System.Drawing.Image)(resources.GetObject("btnRefresh.Image")));
            this.btnRefresh.ImageLocation = DevExpress.XtraEditors.ImageLocation.TopCenter;
            this.btnRefresh.Location = new System.Drawing.Point(1173, 56);
            this.btnRefresh.Name = "btnRefresh";
            this.btnRefresh.Size = new System.Drawing.Size(61, 41);
            this.btnRefresh.TabIndex = 71;
            this.btnRefresh.Text = "过滤";
            this.btnRefresh.Click += new System.EventHandler(this.btnRefresh_Click);
            // 
            // myTreeList1
            // 
            this.myTreeList1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.myTreeList1.Appearance.HeaderPanel.Options.UseTextOptions = true;
            this.myTreeList1.Appearance.HeaderPanel.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.myTreeList1.Location = new System.Drawing.Point(3, 167);
            this.myTreeList1.LookAndFeel.SkinName = "Black";
            this.myTreeList1.LookAndFeel.UseDefaultLookAndFeel = false;
            this.myTreeList1.Name = "myTreeList1";
            this.myTreeList1.OptionsPrint.AutoWidth = false;
            this.myTreeList1.OptionsView.AutoWidth = false;
            this.myTreeList1.Size = new System.Drawing.Size(1345, 430);
            this.myTreeList1.TabIndex = 70;
            this.myTreeList1.DoubleClick += new System.EventHandler(this.myTreeList1_DoubleClick);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(393, 59);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(53, 12);
            this.label7.TabIndex = 161;
            this.label7.Text = "公司名称";
            // 
            // buttonEdit仓库
            // 
            this.buttonEdit仓库.Location = new System.Drawing.Point(451, 54);
            this.buttonEdit仓库.Name = "buttonEdit仓库";
            this.buttonEdit仓库.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
            this.buttonEdit仓库.Size = new System.Drawing.Size(134, 21);
            this.buttonEdit仓库.TabIndex = 162;
            this.buttonEdit仓库.ButtonClick += new DevExpress.XtraEditors.Controls.ButtonPressedEventHandler(this.buttonEdit仓库_ButtonClick);
            this.buttonEdit仓库.EditValueChanged += new System.EventHandler(this.buttonEdit仓库_EditValueChanged);
            this.buttonEdit仓库.Leave += new System.EventHandler(this.buttonEdit仓库_Leave);
            // 
            // lookUpEdit仓库
            // 
            this.lookUpEdit仓库.Enabled = false;
            this.lookUpEdit仓库.Location = new System.Drawing.Point(591, 54);
            this.lookUpEdit仓库.Name = "lookUpEdit仓库";
            this.lookUpEdit仓库.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.lookUpEdit仓库.Size = new System.Drawing.Size(179, 21);
            this.lookUpEdit仓库.TabIndex = 163;
            // 
            // lookUpEditcPosition
            // 
            this.lookUpEditcPosition.Location = new System.Drawing.Point(451, 78);
            this.lookUpEditcPosition.Name = "lookUpEditcPosition";
            this.lookUpEditcPosition.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.lookUpEditcPosition.Properties.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("cPosCode", 40, "编码"),
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("cPosName", "名称")});
            this.lookUpEditcPosition.Properties.DisplayMember = "cPosCode";
            this.lookUpEditcPosition.Properties.NullText = "";
            this.lookUpEditcPosition.Properties.ValueMember = "cPosCode";
            this.lookUpEditcPosition.Size = new System.Drawing.Size(134, 21);
            this.lookUpEditcPosition.TabIndex = 164;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(393, 83);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(29, 12);
            this.label3.TabIndex = 165;
            this.label3.Text = "库房";
            // 
            // lookUpEditcFree4
            // 
            this.lookUpEditcFree4.Location = new System.Drawing.Point(451, 104);
            this.lookUpEditcFree4.Name = "lookUpEditcFree4";
            this.lookUpEditcFree4.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.lookUpEditcFree4.Properties.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("cValue", 40, "编码")});
            this.lookUpEditcFree4.Properties.DisplayMember = "cValue";
            this.lookUpEditcFree4.Properties.NullText = "";
            this.lookUpEditcFree4.Properties.ValueMember = "cValue";
            this.lookUpEditcFree4.Size = new System.Drawing.Size(134, 21);
            this.lookUpEditcFree4.TabIndex = 166;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(393, 109);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(29, 12);
            this.label4.TabIndex = 167;
            this.label4.Text = "货区";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.rdo未审);
            this.groupBox2.Controls.Add(this.rdo审核);
            this.groupBox2.Location = new System.Drawing.Point(796, 109);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(118, 52);
            this.groupBox2.TabIndex = 170;
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
            this.groupBox3.Controls.Add(this.rdo今日);
            this.groupBox3.Controls.Add(this.rdo本年);
            this.groupBox3.Controls.Add(this.rdo本季);
            this.groupBox3.Controls.Add(this.rdo本月);
            this.groupBox3.Location = new System.Drawing.Point(796, 49);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(228, 52);
            this.groupBox3.TabIndex = 182;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "区间";
            // 
            // rdo今日
            // 
            this.rdo今日.AutoSize = true;
            this.rdo今日.Checked = true;
            this.rdo今日.Location = new System.Drawing.Point(8, 20);
            this.rdo今日.Name = "rdo今日";
            this.rdo今日.Size = new System.Drawing.Size(47, 16);
            this.rdo今日.TabIndex = 149;
            this.rdo今日.TabStop = true;
            this.rdo今日.Text = "今日";
            this.rdo今日.UseVisualStyleBackColor = true;
            // 
            // rdo本年
            // 
            this.rdo本年.AutoSize = true;
            this.rdo本年.Location = new System.Drawing.Point(164, 20);
            this.rdo本年.Name = "rdo本年";
            this.rdo本年.Size = new System.Drawing.Size(47, 16);
            this.rdo本年.TabIndex = 148;
            this.rdo本年.Text = "本年";
            this.rdo本年.UseVisualStyleBackColor = true;
            // 
            // rdo本季
            // 
            this.rdo本季.AutoSize = true;
            this.rdo本季.Location = new System.Drawing.Point(111, 20);
            this.rdo本季.Name = "rdo本季";
            this.rdo本季.Size = new System.Drawing.Size(47, 16);
            this.rdo本季.TabIndex = 144;
            this.rdo本季.Text = "本季";
            this.rdo本季.UseVisualStyleBackColor = true;
            // 
            // rdo本月
            // 
            this.rdo本月.AutoSize = true;
            this.rdo本月.Location = new System.Drawing.Point(58, 20);
            this.rdo本月.Name = "rdo本月";
            this.rdo本月.Size = new System.Drawing.Size(47, 16);
            this.rdo本月.TabIndex = 147;
            this.rdo本月.Text = "本月";
            this.rdo本月.UseVisualStyleBackColor = true;
            // 
            // lookUpEditcFree3
            // 
            this.lookUpEditcFree3.Location = new System.Drawing.Point(451, 131);
            this.lookUpEditcFree3.Name = "lookUpEditcFree3";
            this.lookUpEditcFree3.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.lookUpEditcFree3.Properties.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("cValue", 40, "编码")});
            this.lookUpEditcFree3.Properties.DisplayMember = "cValue";
            this.lookUpEditcFree3.Properties.NullText = "";
            this.lookUpEditcFree3.Properties.ValueMember = "cValue";
            this.lookUpEditcFree3.Size = new System.Drawing.Size(134, 21);
            this.lookUpEditcFree3.TabIndex = 166;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(393, 136);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(41, 12);
            this.label5.TabIndex = 167;
            this.label5.Text = "虚拟库";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.rdo不包含未发生物料);
            this.groupBox1.Controls.Add(this.rdo包含未发生物料);
            this.groupBox1.Location = new System.Drawing.Point(920, 109);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(118, 52);
            this.groupBox1.TabIndex = 183;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "未发生物料";
            // 
            // rdo不包含未发生物料
            // 
            this.rdo不包含未发生物料.AutoSize = true;
            this.rdo不包含未发生物料.Location = new System.Drawing.Point(61, 20);
            this.rdo不包含未发生物料.Name = "rdo不包含未发生物料";
            this.rdo不包含未发生物料.Size = new System.Drawing.Size(59, 16);
            this.rdo不包含未发生物料.TabIndex = 144;
            this.rdo不包含未发生物料.Text = "不包含";
            this.rdo不包含未发生物料.UseVisualStyleBackColor = true;
            // 
            // rdo包含未发生物料
            // 
            this.rdo包含未发生物料.AutoSize = true;
            this.rdo包含未发生物料.Checked = true;
            this.rdo包含未发生物料.Location = new System.Drawing.Point(8, 20);
            this.rdo包含未发生物料.Name = "rdo包含未发生物料";
            this.rdo包含未发生物料.Size = new System.Drawing.Size(47, 16);
            this.rdo包含未发生物料.TabIndex = 147;
            this.rdo包含未发生物料.TabStop = true;
            this.rdo包含未发生物料.Text = "包含";
            this.rdo包含未发生物料.UseVisualStyleBackColor = true;
            // 
            // Frm收发存汇总查询
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.lookUpEditcFree3);
            this.Controls.Add(this.lookUpEditcFree4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.lookUpEditcPosition);
            this.Controls.Add(this.lookUpEdit仓库);
            this.Controls.Add(this.buttonEdit仓库);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.lookUpEdit存货名称2);
            this.Controls.Add(this.lookUpEdit存货名称1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.buttonEdit存货编码2);
            this.Controls.Add(this.buttonEdit存货编码1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.btnExcel);
            this.Controls.Add(this.labelControl1);
            this.Controls.Add(this.btnRefresh);
            this.Controls.Add(this.myTreeList1);
            this.Name = "Frm收发存汇总查询";
            this.Size = new System.Drawing.Size(1351, 600);
            this.Load += new System.EventHandler(this.Frm收发存汇总查询_Load);
            ((System.ComponentModel.ISupportInitialize)(this.lookUpEdit存货名称2.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lookUpEdit存货名称1.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.buttonEdit存货编码2.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.buttonEdit存货编码1.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.myTreeList1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.buttonEdit仓库.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lookUpEdit仓库.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lookUpEditcPosition.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lookUpEditcFree4.Properties)).EndInit();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.lookUpEditcFree3.Properties)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraEditors.LookUpEdit lookUpEdit存货名称2;
        private DevExpress.XtraEditors.LookUpEdit lookUpEdit存货名称1;
        private System.Windows.Forms.Label label1;
        private DevExpress.XtraEditors.ButtonEdit buttonEdit存货编码2;
        private DevExpress.XtraEditors.ButtonEdit buttonEdit存货编码1;
        private System.Windows.Forms.Label label2;
        private DevExpress.XtraEditors.SimpleButton btnExcel;
        private DevExpress.XtraEditors.LabelControl labelControl1;
        private DevExpress.XtraEditors.SimpleButton btnRefresh;
        private MyXtraTreeList.MyTreeList myTreeList1;
        private System.Windows.Forms.Label label7;
        private DevExpress.XtraEditors.ButtonEdit buttonEdit仓库;
        private DevExpress.XtraEditors.LookUpEdit lookUpEdit仓库;
        private DevExpress.XtraEditors.LookUpEdit lookUpEditcPosition;
        private System.Windows.Forms.Label label3;
        private DevExpress.XtraEditors.LookUpEdit lookUpEditcFree4;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.RadioButton rdo未审;
        private System.Windows.Forms.RadioButton rdo审核;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.RadioButton rdo本年;
        private System.Windows.Forms.RadioButton rdo本季;
        private System.Windows.Forms.RadioButton rdo本月;
        private System.Windows.Forms.RadioButton rdo今日;
        private DevExpress.XtraEditors.LookUpEdit lookUpEditcFree3;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.RadioButton rdo不包含未发生物料;
        private System.Windows.Forms.RadioButton rdo包含未发生物料;

    }
}
