namespace Purchase
{
    partial class Frm订单评审_SEL
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

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.btnClose = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.dtm单据日期1 = new DevExpress.XtraEditors.DateEdit();
            this.dtm单据日期2 = new DevExpress.XtraEditors.DateEdit();
            this.lookUpEdit外销订单号2 = new DevExpress.XtraEditors.LookUpEdit();
            this.lookUpEdit客户订单号2 = new DevExpress.XtraEditors.LookUpEdit();
            this.lookUpEdit销售订单号2 = new DevExpress.XtraEditors.LookUpEdit();
            this.lookUpEdit外销订单号1 = new DevExpress.XtraEditors.LookUpEdit();
            this.label4 = new System.Windows.Forms.Label();
            this.lookUpEdit部门 = new DevExpress.XtraEditors.LookUpEdit();
            this.lookUpEdit客户订单号1 = new DevExpress.XtraEditors.LookUpEdit();
            this.label5 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.lookUpEdit销售订单号1 = new DevExpress.XtraEditors.LookUpEdit();
            this.label2 = new System.Windows.Forms.Label();
            this.radio未评审 = new System.Windows.Forms.RadioButton();
            this.radio全部 = new System.Windows.Forms.RadioButton();
            this.btnSEL = new System.Windows.Forms.Button();
            this.btnOK = new System.Windows.Forms.Button();
            this.gridControl1 = new DevExpress.XtraGrid.GridControl();
            this.gridView1 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.gridCol销售订单号 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridCol制单日期 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridCol外销订单号 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridCol客户订单号 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridCol客户编号 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.ItemLookUpEdit客户编码 = new DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit();
            this.gridCol客户简称 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.ItemLookUpEdit客户简称 = new DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit();
            this.gridCol备注 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridCol销售订单ID = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridCol采购评审 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridCol锁定 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dtm单据日期1.Properties.VistaTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtm单据日期1.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtm单据日期2.Properties.VistaTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtm单据日期2.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lookUpEdit外销订单号2.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lookUpEdit客户订单号2.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lookUpEdit销售订单号2.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lookUpEdit外销订单号1.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lookUpEdit部门.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lookUpEdit客户订单号1.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lookUpEdit销售订单号1.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ItemLookUpEdit客户编码)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ItemLookUpEdit客户简称)).BeginInit();
            this.SuspendLayout();
            // 
            // btnClose
            // 
            this.btnClose.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnClose.Location = new System.Drawing.Point(1123, 150);
            this.btnClose.Margin = new System.Windows.Forms.Padding(4);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(100, 29);
            this.btnClose.TabIndex = 12;
            this.btnClose.Text = "退  出";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox1.Controls.Add(this.dtm单据日期1);
            this.groupBox1.Controls.Add(this.dtm单据日期2);
            this.groupBox1.Controls.Add(this.lookUpEdit外销订单号2);
            this.groupBox1.Controls.Add(this.lookUpEdit客户订单号2);
            this.groupBox1.Controls.Add(this.lookUpEdit销售订单号2);
            this.groupBox1.Controls.Add(this.lookUpEdit外销订单号1);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.lookUpEdit部门);
            this.groupBox1.Controls.Add(this.lookUpEdit客户订单号1);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.lookUpEdit销售订单号1);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.radio未评审);
            this.groupBox1.Controls.Add(this.radio全部);
            this.groupBox1.Controls.Add(this.btnClose);
            this.groupBox1.Controls.Add(this.btnSEL);
            this.groupBox1.Controls.Add(this.btnOK);
            this.groupBox1.Controls.Add(this.gridControl1);
            this.groupBox1.Location = new System.Drawing.Point(3, 15);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(4);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(4);
            this.groupBox1.Size = new System.Drawing.Size(1237, 581);
            this.groupBox1.TabIndex = 14;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "选择委外计划";
            // 
            // dtm单据日期1
            // 
            this.dtm单据日期1.EditValue = new System.DateTime(2009, 5, 12, 0, 0, 0, 0);
            this.dtm单据日期1.Location = new System.Drawing.Point(657, 24);
            this.dtm单据日期1.Margin = new System.Windows.Forms.Padding(4);
            this.dtm单据日期1.Name = "dtm单据日期1";
            this.dtm单据日期1.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.dtm单据日期1.Properties.VistaTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
            this.dtm单据日期1.Size = new System.Drawing.Size(179, 24);
            this.dtm单据日期1.TabIndex = 63;
            // 
            // dtm单据日期2
            // 
            this.dtm单据日期2.EditValue = new System.DateTime(2009, 5, 12, 0, 0, 0, 0);
            this.dtm单据日期2.Location = new System.Drawing.Point(844, 24);
            this.dtm单据日期2.Margin = new System.Windows.Forms.Padding(4);
            this.dtm单据日期2.Name = "dtm单据日期2";
            this.dtm单据日期2.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.dtm单据日期2.Properties.VistaTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
            this.dtm单据日期2.Size = new System.Drawing.Size(192, 24);
            this.dtm单据日期2.TabIndex = 63;
            // 
            // lookUpEdit外销订单号2
            // 
            this.lookUpEdit外销订单号2.Location = new System.Drawing.Point(844, 61);
            this.lookUpEdit外销订单号2.Margin = new System.Windows.Forms.Padding(4);
            this.lookUpEdit外销订单号2.Name = "lookUpEdit外销订单号2";
            this.lookUpEdit外销订单号2.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.lookUpEdit外销订单号2.Properties.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("iID", "外销订单号")});
            this.lookUpEdit外销订单号2.Properties.DisplayMember = "iID";
            this.lookUpEdit外销订单号2.Properties.NullText = "";
            this.lookUpEdit外销订单号2.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.Standard;
            this.lookUpEdit外销订单号2.Properties.ValueMember = "iID";
            this.lookUpEdit外销订单号2.Size = new System.Drawing.Size(192, 24);
            this.lookUpEdit外销订单号2.TabIndex = 42;
            // 
            // lookUpEdit客户订单号2
            // 
            this.lookUpEdit客户订单号2.Location = new System.Drawing.Point(327, 64);
            this.lookUpEdit客户订单号2.Margin = new System.Windows.Forms.Padding(4);
            this.lookUpEdit客户订单号2.Name = "lookUpEdit客户订单号2";
            this.lookUpEdit客户订单号2.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.lookUpEdit客户订单号2.Properties.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("iID", "客户订单号")});
            this.lookUpEdit客户订单号2.Properties.DisplayMember = "iID";
            this.lookUpEdit客户订单号2.Properties.NullText = "";
            this.lookUpEdit客户订单号2.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.Standard;
            this.lookUpEdit客户订单号2.Properties.ValueMember = "iID";
            this.lookUpEdit客户订单号2.Size = new System.Drawing.Size(192, 24);
            this.lookUpEdit客户订单号2.TabIndex = 42;
            // 
            // lookUpEdit销售订单号2
            // 
            this.lookUpEdit销售订单号2.Location = new System.Drawing.Point(327, 28);
            this.lookUpEdit销售订单号2.Margin = new System.Windows.Forms.Padding(4);
            this.lookUpEdit销售订单号2.Name = "lookUpEdit销售订单号2";
            this.lookUpEdit销售订单号2.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.lookUpEdit销售订单号2.Properties.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("iID", "销售订单号")});
            this.lookUpEdit销售订单号2.Properties.DisplayMember = "iID";
            this.lookUpEdit销售订单号2.Properties.NullText = "";
            this.lookUpEdit销售订单号2.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.Standard;
            this.lookUpEdit销售订单号2.Properties.ValueMember = "iID";
            this.lookUpEdit销售订单号2.Size = new System.Drawing.Size(192, 24);
            this.lookUpEdit销售订单号2.TabIndex = 42;
            // 
            // lookUpEdit外销订单号1
            // 
            this.lookUpEdit外销订单号1.Location = new System.Drawing.Point(652, 61);
            this.lookUpEdit外销订单号1.Margin = new System.Windows.Forms.Padding(4);
            this.lookUpEdit外销订单号1.Name = "lookUpEdit外销订单号1";
            this.lookUpEdit外销订单号1.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.lookUpEdit外销订单号1.Properties.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("iID", "外销订单号")});
            this.lookUpEdit外销订单号1.Properties.DisplayMember = "iID";
            this.lookUpEdit外销订单号1.Properties.NullText = "";
            this.lookUpEdit外销订单号1.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.Standard;
            this.lookUpEdit外销订单号1.Properties.ValueMember = "iID";
            this.lookUpEdit外销订单号1.Size = new System.Drawing.Size(184, 24);
            this.lookUpEdit外销订单号1.TabIndex = 40;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(533, 68);
            this.label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(82, 15);
            this.label4.TabIndex = 39;
            this.label4.Text = "外销订单号";
            // 
            // lookUpEdit部门
            // 
            this.lookUpEdit部门.Location = new System.Drawing.Point(135, 100);
            this.lookUpEdit部门.Margin = new System.Windows.Forms.Padding(4);
            this.lookUpEdit部门.Name = "lookUpEdit部门";
            this.lookUpEdit部门.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.lookUpEdit部门.Properties.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("cDepCode", "部门编号"),
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("cDepName", "部门")});
            this.lookUpEdit部门.Properties.DisplayMember = "cDepName";
            this.lookUpEdit部门.Properties.NullText = "";
            this.lookUpEdit部门.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.Standard;
            this.lookUpEdit部门.Properties.ValueMember = "cDepCode";
            this.lookUpEdit部门.Size = new System.Drawing.Size(184, 24);
            this.lookUpEdit部门.TabIndex = 40;
            // 
            // lookUpEdit客户订单号1
            // 
            this.lookUpEdit客户订单号1.Location = new System.Drawing.Point(135, 64);
            this.lookUpEdit客户订单号1.Margin = new System.Windows.Forms.Padding(4);
            this.lookUpEdit客户订单号1.Name = "lookUpEdit客户订单号1";
            this.lookUpEdit客户订单号1.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.lookUpEdit客户订单号1.Properties.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("iID", "客户订单号")});
            this.lookUpEdit客户订单号1.Properties.DisplayMember = "iID";
            this.lookUpEdit客户订单号1.Properties.NullText = "";
            this.lookUpEdit客户订单号1.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.Standard;
            this.lookUpEdit客户订单号1.Properties.ValueMember = "iID";
            this.lookUpEdit客户订单号1.Size = new System.Drawing.Size(184, 24);
            this.lookUpEdit客户订单号1.TabIndex = 40;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(16, 106);
            this.label5.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(37, 15);
            this.label5.TabIndex = 39;
            this.label5.Text = "部门";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(533, 31);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(97, 15);
            this.label1.TabIndex = 39;
            this.label1.Text = "评审制单日期";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(16, 70);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(82, 15);
            this.label3.TabIndex = 39;
            this.label3.Text = "客户订单号";
            // 
            // lookUpEdit销售订单号1
            // 
            this.lookUpEdit销售订单号1.Location = new System.Drawing.Point(135, 28);
            this.lookUpEdit销售订单号1.Margin = new System.Windows.Forms.Padding(4);
            this.lookUpEdit销售订单号1.Name = "lookUpEdit销售订单号1";
            this.lookUpEdit销售订单号1.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.lookUpEdit销售订单号1.Properties.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("iID", "销售订单号")});
            this.lookUpEdit销售订单号1.Properties.DisplayMember = "iID";
            this.lookUpEdit销售订单号1.Properties.NullText = "";
            this.lookUpEdit销售订单号1.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.Standard;
            this.lookUpEdit销售订单号1.Properties.ValueMember = "iID";
            this.lookUpEdit销售订单号1.Size = new System.Drawing.Size(184, 24);
            this.lookUpEdit销售订单号1.TabIndex = 40;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(16, 34);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(82, 15);
            this.label2.TabIndex = 39;
            this.label2.Text = "销售订单号";
            // 
            // radio未评审
            // 
            this.radio未评审.AutoSize = true;
            this.radio未评审.Checked = true;
            this.radio未评审.Location = new System.Drawing.Point(8, 159);
            this.radio未评审.Margin = new System.Windows.Forms.Padding(4);
            this.radio未评审.Name = "radio未评审";
            this.radio未评审.Size = new System.Drawing.Size(73, 19);
            this.radio未评审.TabIndex = 35;
            this.radio未评审.TabStop = true;
            this.radio未评审.Text = "未评审";
            this.radio未评审.UseVisualStyleBackColor = true;
            // 
            // radio全部
            // 
            this.radio全部.AutoSize = true;
            this.radio全部.Location = new System.Drawing.Point(176, 159);
            this.radio全部.Margin = new System.Windows.Forms.Padding(4);
            this.radio全部.Name = "radio全部";
            this.radio全部.Size = new System.Drawing.Size(58, 19);
            this.radio全部.TabIndex = 33;
            this.radio全部.Text = "全部";
            this.radio全部.UseVisualStyleBackColor = true;
            // 
            // btnSEL
            // 
            this.btnSEL.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSEL.Location = new System.Drawing.Point(880, 150);
            this.btnSEL.Margin = new System.Windows.Forms.Padding(4);
            this.btnSEL.Name = "btnSEL";
            this.btnSEL.Size = new System.Drawing.Size(100, 29);
            this.btnSEL.TabIndex = 13;
            this.btnSEL.Text = "查  询";
            this.btnSEL.UseVisualStyleBackColor = true;
            this.btnSEL.Click += new System.EventHandler(this.btnSEL_Click);
            // 
            // btnOK
            // 
            this.btnOK.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnOK.Location = new System.Drawing.Point(1003, 150);
            this.btnOK.Margin = new System.Windows.Forms.Padding(4);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(100, 29);
            this.btnOK.TabIndex = 12;
            this.btnOK.Text = "确  定";
            this.btnOK.UseVisualStyleBackColor = true;
            this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
            // 
            // gridControl1
            // 
            this.gridControl1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.gridControl1.EmbeddedNavigator.Margin = new System.Windows.Forms.Padding(4);
            this.gridControl1.Location = new System.Drawing.Point(0, 208);
            this.gridControl1.MainView = this.gridView1;
            this.gridControl1.Margin = new System.Windows.Forms.Padding(4);
            this.gridControl1.Name = "gridControl1";
            this.gridControl1.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.ItemLookUpEdit客户编码,
            this.ItemLookUpEdit客户简称});
            this.gridControl1.Size = new System.Drawing.Size(1237, 374);
            this.gridControl1.TabIndex = 36;
            this.gridControl1.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView1});
            // 
            // gridView1
            // 
            this.gridView1.Appearance.ColumnFilterButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(236)))), ((int)(((byte)(232)))), ((int)(((byte)(201)))));
            this.gridView1.Appearance.ColumnFilterButton.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(236)))), ((int)(((byte)(232)))), ((int)(((byte)(201)))));
            this.gridView1.Appearance.ColumnFilterButton.ForeColor = System.Drawing.Color.Black;
            this.gridView1.Appearance.ColumnFilterButton.Options.UseBackColor = true;
            this.gridView1.Appearance.ColumnFilterButton.Options.UseBorderColor = true;
            this.gridView1.Appearance.ColumnFilterButton.Options.UseForeColor = true;
            this.gridView1.Appearance.ColumnFilterButtonActive.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(221)))), ((int)(((byte)(231)))), ((int)(((byte)(234)))));
            this.gridView1.Appearance.ColumnFilterButtonActive.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(221)))), ((int)(((byte)(231)))), ((int)(((byte)(234)))));
            this.gridView1.Appearance.ColumnFilterButtonActive.ForeColor = System.Drawing.Color.Black;
            this.gridView1.Appearance.ColumnFilterButtonActive.Options.UseBackColor = true;
            this.gridView1.Appearance.ColumnFilterButtonActive.Options.UseBorderColor = true;
            this.gridView1.Appearance.ColumnFilterButtonActive.Options.UseForeColor = true;
            this.gridView1.Appearance.Empty.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(236)))), ((int)(((byte)(232)))), ((int)(((byte)(201)))));
            this.gridView1.Appearance.Empty.BackColor2 = System.Drawing.Color.White;
            this.gridView1.Appearance.Empty.Options.UseBackColor = true;
            this.gridView1.Appearance.EvenRow.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(221)))), ((int)(((byte)(231)))), ((int)(((byte)(234)))));
            this.gridView1.Appearance.EvenRow.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(221)))), ((int)(((byte)(231)))), ((int)(((byte)(234)))));
            this.gridView1.Appearance.EvenRow.ForeColor = System.Drawing.Color.Black;
            this.gridView1.Appearance.EvenRow.Options.UseBackColor = true;
            this.gridView1.Appearance.EvenRow.Options.UseBorderColor = true;
            this.gridView1.Appearance.EvenRow.Options.UseForeColor = true;
            this.gridView1.Appearance.FilterCloseButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(216)))), ((int)(((byte)(209)))), ((int)(((byte)(179)))));
            this.gridView1.Appearance.FilterCloseButton.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(216)))), ((int)(((byte)(209)))), ((int)(((byte)(179)))));
            this.gridView1.Appearance.FilterCloseButton.ForeColor = System.Drawing.Color.Black;
            this.gridView1.Appearance.FilterCloseButton.Options.UseBackColor = true;
            this.gridView1.Appearance.FilterCloseButton.Options.UseBorderColor = true;
            this.gridView1.Appearance.FilterCloseButton.Options.UseForeColor = true;
            this.gridView1.Appearance.FilterPanel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(236)))), ((int)(((byte)(232)))), ((int)(((byte)(201)))));
            this.gridView1.Appearance.FilterPanel.BackColor2 = System.Drawing.Color.White;
            this.gridView1.Appearance.FilterPanel.ForeColor = System.Drawing.Color.Black;
            this.gridView1.Appearance.FilterPanel.Options.UseBackColor = true;
            this.gridView1.Appearance.FilterPanel.Options.UseForeColor = true;
            this.gridView1.Appearance.FixedLine.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(122)))), ((int)(((byte)(114)))), ((int)(((byte)(113)))));
            this.gridView1.Appearance.FixedLine.Options.UseBackColor = true;
            this.gridView1.Appearance.FocusedCell.BackColor = System.Drawing.Color.White;
            this.gridView1.Appearance.FocusedCell.ForeColor = System.Drawing.Color.Black;
            this.gridView1.Appearance.FocusedCell.Options.UseBackColor = true;
            this.gridView1.Appearance.FocusedCell.Options.UseForeColor = true;
            this.gridView1.Appearance.FocusedRow.BackColor = System.Drawing.Color.Lime;
            this.gridView1.Appearance.FocusedRow.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(219)))), ((int)(((byte)(188)))));
            this.gridView1.Appearance.FocusedRow.ForeColor = System.Drawing.Color.Black;
            this.gridView1.Appearance.FocusedRow.Options.UseBackColor = true;
            this.gridView1.Appearance.FocusedRow.Options.UseBorderColor = true;
            this.gridView1.Appearance.FocusedRow.Options.UseForeColor = true;
            this.gridView1.Appearance.FooterPanel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(216)))), ((int)(((byte)(209)))), ((int)(((byte)(170)))));
            this.gridView1.Appearance.FooterPanel.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(216)))), ((int)(((byte)(209)))), ((int)(((byte)(170)))));
            this.gridView1.Appearance.FooterPanel.ForeColor = System.Drawing.Color.Black;
            this.gridView1.Appearance.FooterPanel.Options.UseBackColor = true;
            this.gridView1.Appearance.FooterPanel.Options.UseBorderColor = true;
            this.gridView1.Appearance.FooterPanel.Options.UseForeColor = true;
            this.gridView1.Appearance.GroupButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(216)))), ((int)(((byte)(209)))), ((int)(((byte)(179)))));
            this.gridView1.Appearance.GroupButton.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(216)))), ((int)(((byte)(209)))), ((int)(((byte)(179)))));
            this.gridView1.Appearance.GroupButton.Options.UseBackColor = true;
            this.gridView1.Appearance.GroupButton.Options.UseBorderColor = true;
            this.gridView1.Appearance.GroupFooter.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(236)))), ((int)(((byte)(232)))), ((int)(((byte)(201)))));
            this.gridView1.Appearance.GroupFooter.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(236)))), ((int)(((byte)(232)))), ((int)(((byte)(201)))));
            this.gridView1.Appearance.GroupFooter.ForeColor = System.Drawing.Color.Black;
            this.gridView1.Appearance.GroupFooter.Options.UseBackColor = true;
            this.gridView1.Appearance.GroupFooter.Options.UseBorderColor = true;
            this.gridView1.Appearance.GroupFooter.Options.UseForeColor = true;
            this.gridView1.Appearance.GroupPanel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(246)))), ((int)(((byte)(242)))), ((int)(((byte)(213)))));
            this.gridView1.Appearance.GroupPanel.BackColor2 = System.Drawing.Color.White;
            this.gridView1.Appearance.GroupPanel.ForeColor = System.Drawing.Color.Black;
            this.gridView1.Appearance.GroupPanel.Options.UseBackColor = true;
            this.gridView1.Appearance.GroupPanel.Options.UseForeColor = true;
            this.gridView1.Appearance.GroupRow.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(236)))), ((int)(((byte)(232)))), ((int)(((byte)(201)))));
            this.gridView1.Appearance.GroupRow.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(236)))), ((int)(((byte)(232)))), ((int)(((byte)(201)))));
            this.gridView1.Appearance.GroupRow.ForeColor = System.Drawing.Color.Black;
            this.gridView1.Appearance.GroupRow.Options.UseBackColor = true;
            this.gridView1.Appearance.GroupRow.Options.UseBorderColor = true;
            this.gridView1.Appearance.GroupRow.Options.UseForeColor = true;
            this.gridView1.Appearance.HeaderPanel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(216)))), ((int)(((byte)(209)))), ((int)(((byte)(170)))));
            this.gridView1.Appearance.HeaderPanel.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(216)))), ((int)(((byte)(209)))), ((int)(((byte)(170)))));
            this.gridView1.Appearance.HeaderPanel.ForeColor = System.Drawing.Color.Black;
            this.gridView1.Appearance.HeaderPanel.Options.UseBackColor = true;
            this.gridView1.Appearance.HeaderPanel.Options.UseBorderColor = true;
            this.gridView1.Appearance.HeaderPanel.Options.UseForeColor = true;
            this.gridView1.Appearance.HideSelectionRow.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(237)))), ((int)(((byte)(230)))), ((int)(((byte)(203)))));
            this.gridView1.Appearance.HideSelectionRow.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(237)))), ((int)(((byte)(230)))), ((int)(((byte)(203)))));
            this.gridView1.Appearance.HideSelectionRow.ForeColor = System.Drawing.Color.Black;
            this.gridView1.Appearance.HideSelectionRow.Options.UseBackColor = true;
            this.gridView1.Appearance.HideSelectionRow.Options.UseBorderColor = true;
            this.gridView1.Appearance.HideSelectionRow.Options.UseForeColor = true;
            this.gridView1.Appearance.HorzLine.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(216)))), ((int)(((byte)(209)))), ((int)(((byte)(170)))));
            this.gridView1.Appearance.HorzLine.Options.UseBackColor = true;
            this.gridView1.Appearance.OddRow.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(242)))), ((int)(((byte)(244)))), ((int)(((byte)(236)))));
            this.gridView1.Appearance.OddRow.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(242)))), ((int)(((byte)(244)))), ((int)(((byte)(236)))));
            this.gridView1.Appearance.OddRow.ForeColor = System.Drawing.Color.Black;
            this.gridView1.Appearance.OddRow.Options.UseBackColor = true;
            this.gridView1.Appearance.OddRow.Options.UseBorderColor = true;
            this.gridView1.Appearance.OddRow.Options.UseForeColor = true;
            this.gridView1.Appearance.Preview.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(251)))), ((int)(((byte)(252)))), ((int)(((byte)(247)))));
            this.gridView1.Appearance.Preview.Font = new System.Drawing.Font("Verdana", 7.5F);
            this.gridView1.Appearance.Preview.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(148)))), ((int)(((byte)(148)))), ((int)(((byte)(148)))));
            this.gridView1.Appearance.Preview.Options.UseBackColor = true;
            this.gridView1.Appearance.Preview.Options.UseFont = true;
            this.gridView1.Appearance.Preview.Options.UseForeColor = true;
            this.gridView1.Appearance.Row.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(242)))), ((int)(((byte)(244)))), ((int)(((byte)(236)))));
            this.gridView1.Appearance.Row.ForeColor = System.Drawing.Color.Black;
            this.gridView1.Appearance.Row.Options.UseBackColor = true;
            this.gridView1.Appearance.Row.Options.UseForeColor = true;
            this.gridView1.Appearance.RowSeparator.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(236)))), ((int)(((byte)(232)))), ((int)(((byte)(201)))));
            this.gridView1.Appearance.RowSeparator.BackColor2 = System.Drawing.Color.White;
            this.gridView1.Appearance.RowSeparator.Options.UseBackColor = true;
            this.gridView1.Appearance.SelectedRow.BackColor = System.Drawing.Color.Lime;
            this.gridView1.Appearance.SelectedRow.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(237)))), ((int)(((byte)(230)))), ((int)(((byte)(203)))));
            this.gridView1.Appearance.SelectedRow.ForeColor = System.Drawing.Color.Black;
            this.gridView1.Appearance.SelectedRow.Options.UseBackColor = true;
            this.gridView1.Appearance.SelectedRow.Options.UseBorderColor = true;
            this.gridView1.Appearance.SelectedRow.Options.UseForeColor = true;
            this.gridView1.Appearance.TopNewRow.BackColor = System.Drawing.Color.White;
            this.gridView1.Appearance.TopNewRow.Options.UseBackColor = true;
            this.gridView1.Appearance.VertLine.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(216)))), ((int)(((byte)(209)))), ((int)(((byte)(170)))));
            this.gridView1.Appearance.VertLine.Options.UseBackColor = true;
            this.gridView1.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.gridCol销售订单号,
            this.gridCol制单日期,
            this.gridCol外销订单号,
            this.gridCol客户订单号,
            this.gridCol客户编号,
            this.gridCol客户简称,
            this.gridCol备注,
            this.gridCol销售订单ID,
            this.gridCol采购评审,
            this.gridCol锁定});
            this.gridView1.CustomizationFormBounds = new System.Drawing.Rectangle(1062, 318, 208, 177);
            this.gridView1.GridControl = this.gridControl1;
            this.gridView1.IndicatorWidth = 40;
            this.gridView1.Name = "gridView1";
            this.gridView1.OptionsBehavior.Editable = false;
            this.gridView1.OptionsCustomization.AllowFilter = false;
            this.gridView1.OptionsCustomization.AllowSort = false;
            this.gridView1.OptionsLayout.Columns.StoreAllOptions = true;
            this.gridView1.OptionsLayout.Columns.StoreAppearance = true;
            this.gridView1.OptionsLayout.StoreAllOptions = true;
            this.gridView1.OptionsLayout.StoreAppearance = true;
            this.gridView1.OptionsNavigation.EnterMoveNextColumn = true;
            this.gridView1.OptionsSelection.MultiSelect = true;
            this.gridView1.OptionsView.AutoCalcPreviewLineCount = true;
            this.gridView1.OptionsView.ColumnAutoWidth = false;
            this.gridView1.OptionsView.EnableAppearanceEvenRow = true;
            this.gridView1.OptionsView.EnableAppearanceOddRow = true;
            this.gridView1.OptionsView.ShowFooter = true;
            this.gridView1.OptionsView.ShowGroupPanel = false;
            this.gridView1.CustomDrawRowIndicator += new DevExpress.XtraGrid.Views.Grid.RowIndicatorCustomDrawEventHandler(this.gridView1_CustomDrawRowIndicator);
            // 
            // gridCol销售订单号
            // 
            this.gridCol销售订单号.Caption = "销售订单号";
            this.gridCol销售订单号.FieldName = "销售订单号";
            this.gridCol销售订单号.Name = "gridCol销售订单号";
            this.gridCol销售订单号.OptionsColumn.AllowEdit = false;
            this.gridCol销售订单号.Visible = true;
            this.gridCol销售订单号.VisibleIndex = 0;
            this.gridCol销售订单号.Width = 128;
            // 
            // gridCol制单日期
            // 
            this.gridCol制单日期.Caption = "制单日期";
            this.gridCol制单日期.FieldName = "制单日期";
            this.gridCol制单日期.Name = "gridCol制单日期";
            this.gridCol制单日期.OptionsColumn.AllowEdit = false;
            this.gridCol制单日期.Visible = true;
            this.gridCol制单日期.VisibleIndex = 1;
            this.gridCol制单日期.Width = 136;
            // 
            // gridCol外销订单号
            // 
            this.gridCol外销订单号.Caption = "外销订单号";
            this.gridCol外销订单号.FieldName = "外销订单号";
            this.gridCol外销订单号.Name = "gridCol外销订单号";
            this.gridCol外销订单号.OptionsColumn.AllowEdit = false;
            this.gridCol外销订单号.Visible = true;
            this.gridCol外销订单号.VisibleIndex = 4;
            this.gridCol外销订单号.Width = 85;
            // 
            // gridCol客户订单号
            // 
            this.gridCol客户订单号.Caption = "客户订单号";
            this.gridCol客户订单号.FieldName = "客户订单号";
            this.gridCol客户订单号.Name = "gridCol客户订单号";
            this.gridCol客户订单号.OptionsColumn.AllowEdit = false;
            this.gridCol客户订单号.Visible = true;
            this.gridCol客户订单号.VisibleIndex = 5;
            // 
            // gridCol客户编号
            // 
            this.gridCol客户编号.Caption = "客户编号";
            this.gridCol客户编号.ColumnEdit = this.ItemLookUpEdit客户编码;
            this.gridCol客户编号.FieldName = "客户编号";
            this.gridCol客户编号.Name = "gridCol客户编号";
            this.gridCol客户编号.OptionsColumn.AllowEdit = false;
            this.gridCol客户编号.Visible = true;
            this.gridCol客户编号.VisibleIndex = 2;
            this.gridCol客户编号.Width = 119;
            // 
            // ItemLookUpEdit客户编码
            // 
            this.ItemLookUpEdit客户编码.AutoHeight = false;
            this.ItemLookUpEdit客户编码.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.ItemLookUpEdit客户编码.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("cCusCode", "客户编码"),
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("cCusName", "客户名称"),
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("cCusAbbName", "客户简称")});
            this.ItemLookUpEdit客户编码.DisplayMember = "cCusCode";
            this.ItemLookUpEdit客户编码.Name = "ItemLookUpEdit客户编码";
            this.ItemLookUpEdit客户编码.ValueMember = "cCusCode";
            // 
            // gridCol客户简称
            // 
            this.gridCol客户简称.Caption = "客户简称";
            this.gridCol客户简称.ColumnEdit = this.ItemLookUpEdit客户简称;
            this.gridCol客户简称.FieldName = "客户编号";
            this.gridCol客户简称.Name = "gridCol客户简称";
            this.gridCol客户简称.OptionsColumn.AllowEdit = false;
            this.gridCol客户简称.Visible = true;
            this.gridCol客户简称.VisibleIndex = 3;
            this.gridCol客户简称.Width = 143;
            // 
            // ItemLookUpEdit客户简称
            // 
            this.ItemLookUpEdit客户简称.AutoHeight = false;
            this.ItemLookUpEdit客户简称.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.ItemLookUpEdit客户简称.DisplayMember = "cCusAbbName";
            this.ItemLookUpEdit客户简称.Name = "ItemLookUpEdit客户简称";
            this.ItemLookUpEdit客户简称.ValueMember = "cCusCode";
            // 
            // gridCol备注
            // 
            this.gridCol备注.Caption = "备注";
            this.gridCol备注.FieldName = "备注";
            this.gridCol备注.Name = "gridCol备注";
            this.gridCol备注.OptionsColumn.AllowEdit = false;
            this.gridCol备注.Visible = true;
            this.gridCol备注.VisibleIndex = 8;
            this.gridCol备注.Width = 271;
            // 
            // gridCol销售订单ID
            // 
            this.gridCol销售订单ID.Caption = "销售订单ID";
            this.gridCol销售订单ID.FieldName = "销售订单ID";
            this.gridCol销售订单ID.Name = "gridCol销售订单ID";
            this.gridCol销售订单ID.OptionsColumn.AllowEdit = false;
            // 
            // gridCol采购评审
            // 
            this.gridCol采购评审.Caption = "采购评审";
            this.gridCol采购评审.FieldName = "采购评审";
            this.gridCol采购评审.Name = "gridCol采购评审";
            this.gridCol采购评审.OptionsColumn.AllowEdit = false;
            this.gridCol采购评审.Visible = true;
            this.gridCol采购评审.VisibleIndex = 6;
            // 
            // gridCol锁定
            // 
            this.gridCol锁定.Caption = "锁定";
            this.gridCol锁定.FieldName = "锁定";
            this.gridCol锁定.Name = "gridCol锁定";
            this.gridCol锁定.OptionsColumn.AllowEdit = false;
            this.gridCol锁定.Visible = true;
            this.gridCol锁定.VisibleIndex = 7;
            // 
            // Frm订单评审_SEL
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1241, 601);
            this.Controls.Add(this.groupBox1);
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "Frm订单评审_SEL";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "查询";
            this.Load += new System.EventHandler(this.Frm订单评审_SEL_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dtm单据日期1.Properties.VistaTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtm单据日期1.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtm单据日期2.Properties.VistaTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtm单据日期2.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lookUpEdit外销订单号2.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lookUpEdit客户订单号2.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lookUpEdit销售订单号2.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lookUpEdit外销订单号1.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lookUpEdit部门.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lookUpEdit客户订单号1.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lookUpEdit销售订单号1.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ItemLookUpEdit客户编码)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ItemLookUpEdit客户简称)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button btnSEL;
        private System.Windows.Forms.Button btnOK;
        private System.Windows.Forms.RadioButton radio全部;
        private System.Windows.Forms.RadioButton radio未评审;
        private DevExpress.XtraGrid.GridControl gridControl1;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView1;
        private DevExpress.XtraEditors.LookUpEdit lookUpEdit销售订单号1;
        private System.Windows.Forms.Label label2;
        private DevExpress.XtraEditors.LookUpEdit lookUpEdit外销订单号2;
        private DevExpress.XtraEditors.LookUpEdit lookUpEdit客户订单号2;
        private DevExpress.XtraEditors.LookUpEdit lookUpEdit销售订单号2;
        private DevExpress.XtraEditors.LookUpEdit lookUpEdit外销订单号1;
        private System.Windows.Forms.Label label4;
        private DevExpress.XtraEditors.LookUpEdit lookUpEdit客户订单号1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label3;
        private DevExpress.XtraGrid.Columns.GridColumn gridCol销售订单号;
        private DevExpress.XtraGrid.Columns.GridColumn gridCol制单日期;
        private DevExpress.XtraGrid.Columns.GridColumn gridCol外销订单号;
        private DevExpress.XtraGrid.Columns.GridColumn gridCol客户订单号;
        private DevExpress.XtraGrid.Columns.GridColumn gridCol客户编号;
        private DevExpress.XtraGrid.Columns.GridColumn gridCol客户简称;
        private DevExpress.XtraGrid.Columns.GridColumn gridCol备注;
        private DevExpress.XtraGrid.Columns.GridColumn gridCol销售订单ID;
        private DevExpress.XtraGrid.Columns.GridColumn gridCol采购评审;
        private DevExpress.XtraGrid.Columns.GridColumn gridCol锁定;
        private DevExpress.XtraEditors.DateEdit dtm单据日期1;
        private DevExpress.XtraEditors.DateEdit dtm单据日期2;
        private DevExpress.XtraEditors.LookUpEdit lookUpEdit部门;
        private System.Windows.Forms.Label label5;
        private DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit ItemLookUpEdit客户编码;
        private DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit ItemLookUpEdit客户简称;
    }
}