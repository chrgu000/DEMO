namespace SaleOrder
{
    partial class Frm订单评审运算
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.dtm关闭日期 = new DevExpress.XtraEditors.DateEdit();
            this.txt关闭人 = new DevExpress.XtraEditors.TextEdit();
            this.txt审核人 = new DevExpress.XtraEditors.TextEdit();
            this.dtm制单日期 = new DevExpress.XtraEditors.DateEdit();
            this.txt评审备注 = new DevExpress.XtraEditors.TextEdit();
            this.lookUpEdit客户 = new DevExpress.XtraEditors.LookUpEdit();
            this.dtm审核日期 = new DevExpress.XtraEditors.DateEdit();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.gridControl销售订单列表 = new DevExpress.XtraGrid.GridControl();
            this.gridView销售订单列表 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.gridCol1订单子表ID = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridCol1存货编码 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.ItemLookUpEdit1存货编码 = new DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit();
            this.gridCol1存货名称 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.ItemLookUpEdit1存货名称 = new DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit();
            this.gridCol1规格型号 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.ItemLookUpEdit1规格型号 = new DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit();
            this.gridCol1主计量编码 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridCol1主计量 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridCol1数量 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridCol1船期 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridCol1国外要求交期 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridCol1预完工日期 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridCol1评审下达完工日期 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridCol1评审数量 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridCol1销售订单行号 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.gridControl评审计算 = new DevExpress.XtraGrid.GridControl();
            this.gridView评审计算 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.gridCol销售订单行号 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridCol根母件 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridCol级别 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridCol母件编码 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.ItemLookUpEdit物料编码 = new DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit();
            this.gridCol母件名称 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.ItemLookUpEdit物料名称 = new DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit();
            this.gridCol母件计量单位 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridCol母件规格 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridCol母件属性 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridCol子件行号 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridCol工序行号 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridCol子件编码 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridCol子件名称 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridCol子件规格 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.ItemLookUpEdit规格型号 = new DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit();
            this.gridCol子件计量单位 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridCol子件辅助单位 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridCol换算率 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridCol供应类型 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridCol使用数量 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridCol子件属性 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.ItemLookUpEdit子件属性 = new DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit();
            this.gridCol仓库代号 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.ItemLookUpEdit仓库编号 = new DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit();
            this.gridCol仓库名称 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.ItemLookUpEdit仓库名称 = new DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit();
            this.gridCol领料部门代号 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.ItemLookUpEdit部门编码 = new DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit();
            this.gridCol领料部门名称 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.ItemLookUpEdit部门名称 = new DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit();
            this.gridCol备注 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridCol需求数量 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridCol本次下单数量 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridCol仓库现存量 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridCol待入库量 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridCol最小批量 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridCol置办周期 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridCol开始日期 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridCol完成日期 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridCol质检周期 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridCol生产日工时 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridCol单件生产工时 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridCol生产工时 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridCol下单量 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridCol累计下单量 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridCol累计待入库 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridCol生产部门编码 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridCol生产部门名称 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridCol销售订单子表ID = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridCol累计可用数量 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridCol待出库量 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridCol已使用 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridCol母子对应 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridCol调整数量 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColiID = new DevExpress.XtraGrid.Columns.GridColumn();
            this.txt销售订单ID = new DevExpress.XtraEditors.TextEdit();
            this.txt制单人 = new DevExpress.XtraEditors.TextEdit();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btn变更部门 = new System.Windows.Forms.Button();
            this.btn15天核查 = new System.Windows.Forms.Button();
            this.btn日期检查 = new System.Windows.Forms.Button();
            this.dtm完成日期 = new DevExpress.XtraEditors.DateEdit();
            this.chk完成日期 = new System.Windows.Forms.CheckBox();
            this.dtm开始日期 = new DevExpress.XtraEditors.DateEdit();
            this.chk开始日期 = new System.Windows.Forms.CheckBox();
            this.label1 = new System.Windows.Forms.Label();
            this.txt存货编码 = new DevExpress.XtraEditors.TextEdit();
            this.btnChange = new System.Windows.Forms.Button();
            this.radio手工 = new System.Windows.Forms.RadioButton();
            this.radio逆排 = new System.Windows.Forms.RadioButton();
            this.radio顺排 = new System.Windows.Forms.RadioButton();
            this.txt备注 = new DevExpress.XtraEditors.TextEdit();
            this.txt客户订单号 = new DevExpress.XtraEditors.TextEdit();
            this.txt销售订单号 = new DevExpress.XtraEditors.TextEdit();
            this.txt外销订单号 = new DevExpress.XtraEditors.TextEdit();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.label14 = new System.Windows.Forms.Label();
            this.gridCol本次下单数量存档 = new DevExpress.XtraGrid.Columns.GridColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dsPrint)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dsForm)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtSel)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtm关闭日期.Properties.VistaTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtm关闭日期.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txt关闭人.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txt审核人.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtm制单日期.Properties.VistaTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtm制单日期.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txt评审备注.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lookUpEdit客户.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtm审核日期.Properties.VistaTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtm审核日期.Properties)).BeginInit();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl销售订单列表)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView销售订单列表)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ItemLookUpEdit1存货编码)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ItemLookUpEdit1存货名称)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ItemLookUpEdit1规格型号)).BeginInit();
            this.tabPage2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl评审计算)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView评审计算)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ItemLookUpEdit物料编码)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ItemLookUpEdit物料名称)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ItemLookUpEdit规格型号)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ItemLookUpEdit子件属性)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ItemLookUpEdit仓库编号)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ItemLookUpEdit仓库名称)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ItemLookUpEdit部门编码)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ItemLookUpEdit部门名称)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txt销售订单ID.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txt制单人.Properties)).BeginInit();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dtm完成日期.Properties.VistaTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtm完成日期.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtm开始日期.Properties.VistaTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtm开始日期.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txt存货编码.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txt备注.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txt客户订单号.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txt销售订单号.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txt外销订单号.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // dtm关闭日期
            // 
            this.dtm关闭日期.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.dtm关闭日期.EditValue = null;
            this.dtm关闭日期.Enabled = false;
            this.dtm关闭日期.Location = new System.Drawing.Point(970, 366);
            this.dtm关闭日期.Name = "dtm关闭日期";
            this.dtm关闭日期.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.dtm关闭日期.Properties.VistaTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
            this.dtm关闭日期.Size = new System.Drawing.Size(123, 20);
            this.dtm关闭日期.TabIndex = 73;
            // 
            // txt关闭人
            // 
            this.txt关闭人.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.txt关闭人.Enabled = false;
            this.txt关闭人.Location = new System.Drawing.Point(788, 366);
            this.txt关闭人.Name = "txt关闭人";
            this.txt关闭人.Size = new System.Drawing.Size(108, 20);
            this.txt关闭人.TabIndex = 72;
            // 
            // txt审核人
            // 
            this.txt审核人.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.txt审核人.Enabled = false;
            this.txt审核人.Location = new System.Drawing.Point(419, 366);
            this.txt审核人.Name = "txt审核人";
            this.txt审核人.Size = new System.Drawing.Size(95, 20);
            this.txt审核人.TabIndex = 70;
            // 
            // dtm制单日期
            // 
            this.dtm制单日期.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.dtm制单日期.EditValue = null;
            this.dtm制单日期.Enabled = false;
            this.dtm制单日期.Location = new System.Drawing.Point(248, 366);
            this.dtm制单日期.Name = "dtm制单日期";
            this.dtm制单日期.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.dtm制单日期.Properties.VistaTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
            this.dtm制单日期.Size = new System.Drawing.Size(97, 20);
            this.dtm制单日期.TabIndex = 69;
            // 
            // txt评审备注
            // 
            this.txt评审备注.Enabled = false;
            this.txt评审备注.Location = new System.Drawing.Point(80, 68);
            this.txt评审备注.Name = "txt评审备注";
            this.txt评审备注.Size = new System.Drawing.Size(1017, 20);
            this.txt评审备注.TabIndex = 67;
            // 
            // lookUpEdit客户
            // 
            this.lookUpEdit客户.Enabled = false;
            this.lookUpEdit客户.Location = new System.Drawing.Point(808, 24);
            this.lookUpEdit客户.Name = "lookUpEdit客户";
            this.lookUpEdit客户.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.lookUpEdit客户.Properties.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("cCusCode", "客户编码"),
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("cCusName", "客户名称"),
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("cCusAbbName", "客户简称")});
            this.lookUpEdit客户.Properties.DisplayMember = "cCusAbbName";
            this.lookUpEdit客户.Properties.NullText = "";
            this.lookUpEdit客户.Properties.ValueMember = "cCusCode";
            this.lookUpEdit客户.Size = new System.Drawing.Size(288, 20);
            this.lookUpEdit客户.TabIndex = 66;
            // 
            // dtm审核日期
            // 
            this.dtm审核日期.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.dtm审核日期.EditValue = null;
            this.dtm审核日期.Enabled = false;
            this.dtm审核日期.Location = new System.Drawing.Point(588, 366);
            this.dtm审核日期.Name = "dtm审核日期";
            this.dtm审核日期.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.dtm审核日期.Properties.VistaTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
            this.dtm审核日期.Size = new System.Drawing.Size(126, 20);
            this.dtm审核日期.TabIndex = 71;
            // 
            // tabControl1
            // 
            this.tabControl1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Location = new System.Drawing.Point(10, 131);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(1087, 229);
            this.tabControl1.TabIndex = 65;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.gridControl销售订单列表);
            this.tabPage1.Location = new System.Drawing.Point(4, 23);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(1079, 202);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "销售订单列表";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // gridControl销售订单列表
            // 
            this.gridControl销售订单列表.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridControl销售订单列表.Location = new System.Drawing.Point(3, 3);
            this.gridControl销售订单列表.MainView = this.gridView销售订单列表;
            this.gridControl销售订单列表.Name = "gridControl销售订单列表";
            this.gridControl销售订单列表.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.ItemLookUpEdit1存货编码,
            this.ItemLookUpEdit1存货名称,
            this.ItemLookUpEdit1规格型号});
            this.gridControl销售订单列表.Size = new System.Drawing.Size(1073, 196);
            this.gridControl销售订单列表.TabIndex = 8;
            this.gridControl销售订单列表.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView销售订单列表});
            // 
            // gridView销售订单列表
            // 
            this.gridView销售订单列表.Appearance.ColumnFilterButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(236)))), ((int)(((byte)(232)))), ((int)(((byte)(201)))));
            this.gridView销售订单列表.Appearance.ColumnFilterButton.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(236)))), ((int)(((byte)(232)))), ((int)(((byte)(201)))));
            this.gridView销售订单列表.Appearance.ColumnFilterButton.ForeColor = System.Drawing.Color.Black;
            this.gridView销售订单列表.Appearance.ColumnFilterButton.Options.UseBackColor = true;
            this.gridView销售订单列表.Appearance.ColumnFilterButton.Options.UseBorderColor = true;
            this.gridView销售订单列表.Appearance.ColumnFilterButton.Options.UseForeColor = true;
            this.gridView销售订单列表.Appearance.ColumnFilterButtonActive.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(221)))), ((int)(((byte)(231)))), ((int)(((byte)(234)))));
            this.gridView销售订单列表.Appearance.ColumnFilterButtonActive.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(221)))), ((int)(((byte)(231)))), ((int)(((byte)(234)))));
            this.gridView销售订单列表.Appearance.ColumnFilterButtonActive.ForeColor = System.Drawing.Color.Black;
            this.gridView销售订单列表.Appearance.ColumnFilterButtonActive.Options.UseBackColor = true;
            this.gridView销售订单列表.Appearance.ColumnFilterButtonActive.Options.UseBorderColor = true;
            this.gridView销售订单列表.Appearance.ColumnFilterButtonActive.Options.UseForeColor = true;
            this.gridView销售订单列表.Appearance.Empty.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(236)))), ((int)(((byte)(232)))), ((int)(((byte)(201)))));
            this.gridView销售订单列表.Appearance.Empty.BackColor2 = System.Drawing.Color.White;
            this.gridView销售订单列表.Appearance.Empty.Options.UseBackColor = true;
            this.gridView销售订单列表.Appearance.EvenRow.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(221)))), ((int)(((byte)(231)))), ((int)(((byte)(234)))));
            this.gridView销售订单列表.Appearance.EvenRow.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(221)))), ((int)(((byte)(231)))), ((int)(((byte)(234)))));
            this.gridView销售订单列表.Appearance.EvenRow.ForeColor = System.Drawing.Color.Black;
            this.gridView销售订单列表.Appearance.EvenRow.Options.UseBackColor = true;
            this.gridView销售订单列表.Appearance.EvenRow.Options.UseBorderColor = true;
            this.gridView销售订单列表.Appearance.EvenRow.Options.UseForeColor = true;
            this.gridView销售订单列表.Appearance.FilterCloseButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(216)))), ((int)(((byte)(209)))), ((int)(((byte)(179)))));
            this.gridView销售订单列表.Appearance.FilterCloseButton.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(216)))), ((int)(((byte)(209)))), ((int)(((byte)(179)))));
            this.gridView销售订单列表.Appearance.FilterCloseButton.ForeColor = System.Drawing.Color.Black;
            this.gridView销售订单列表.Appearance.FilterCloseButton.Options.UseBackColor = true;
            this.gridView销售订单列表.Appearance.FilterCloseButton.Options.UseBorderColor = true;
            this.gridView销售订单列表.Appearance.FilterCloseButton.Options.UseForeColor = true;
            this.gridView销售订单列表.Appearance.FilterPanel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(236)))), ((int)(((byte)(232)))), ((int)(((byte)(201)))));
            this.gridView销售订单列表.Appearance.FilterPanel.BackColor2 = System.Drawing.Color.White;
            this.gridView销售订单列表.Appearance.FilterPanel.ForeColor = System.Drawing.Color.Black;
            this.gridView销售订单列表.Appearance.FilterPanel.Options.UseBackColor = true;
            this.gridView销售订单列表.Appearance.FilterPanel.Options.UseForeColor = true;
            this.gridView销售订单列表.Appearance.FixedLine.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(122)))), ((int)(((byte)(114)))), ((int)(((byte)(113)))));
            this.gridView销售订单列表.Appearance.FixedLine.Options.UseBackColor = true;
            this.gridView销售订单列表.Appearance.FocusedCell.BackColor = System.Drawing.Color.White;
            this.gridView销售订单列表.Appearance.FocusedCell.ForeColor = System.Drawing.Color.Black;
            this.gridView销售订单列表.Appearance.FocusedCell.Options.UseBackColor = true;
            this.gridView销售订单列表.Appearance.FocusedCell.Options.UseForeColor = true;
            this.gridView销售订单列表.Appearance.FocusedRow.BackColor = System.Drawing.Color.Lime;
            this.gridView销售订单列表.Appearance.FocusedRow.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(219)))), ((int)(((byte)(188)))));
            this.gridView销售订单列表.Appearance.FocusedRow.ForeColor = System.Drawing.Color.Black;
            this.gridView销售订单列表.Appearance.FocusedRow.Options.UseBackColor = true;
            this.gridView销售订单列表.Appearance.FocusedRow.Options.UseBorderColor = true;
            this.gridView销售订单列表.Appearance.FocusedRow.Options.UseForeColor = true;
            this.gridView销售订单列表.Appearance.FooterPanel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(216)))), ((int)(((byte)(209)))), ((int)(((byte)(170)))));
            this.gridView销售订单列表.Appearance.FooterPanel.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(216)))), ((int)(((byte)(209)))), ((int)(((byte)(170)))));
            this.gridView销售订单列表.Appearance.FooterPanel.ForeColor = System.Drawing.Color.Black;
            this.gridView销售订单列表.Appearance.FooterPanel.Options.UseBackColor = true;
            this.gridView销售订单列表.Appearance.FooterPanel.Options.UseBorderColor = true;
            this.gridView销售订单列表.Appearance.FooterPanel.Options.UseForeColor = true;
            this.gridView销售订单列表.Appearance.GroupButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(216)))), ((int)(((byte)(209)))), ((int)(((byte)(179)))));
            this.gridView销售订单列表.Appearance.GroupButton.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(216)))), ((int)(((byte)(209)))), ((int)(((byte)(179)))));
            this.gridView销售订单列表.Appearance.GroupButton.Options.UseBackColor = true;
            this.gridView销售订单列表.Appearance.GroupButton.Options.UseBorderColor = true;
            this.gridView销售订单列表.Appearance.GroupFooter.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(236)))), ((int)(((byte)(232)))), ((int)(((byte)(201)))));
            this.gridView销售订单列表.Appearance.GroupFooter.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(236)))), ((int)(((byte)(232)))), ((int)(((byte)(201)))));
            this.gridView销售订单列表.Appearance.GroupFooter.ForeColor = System.Drawing.Color.Black;
            this.gridView销售订单列表.Appearance.GroupFooter.Options.UseBackColor = true;
            this.gridView销售订单列表.Appearance.GroupFooter.Options.UseBorderColor = true;
            this.gridView销售订单列表.Appearance.GroupFooter.Options.UseForeColor = true;
            this.gridView销售订单列表.Appearance.GroupPanel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(246)))), ((int)(((byte)(242)))), ((int)(((byte)(213)))));
            this.gridView销售订单列表.Appearance.GroupPanel.BackColor2 = System.Drawing.Color.White;
            this.gridView销售订单列表.Appearance.GroupPanel.ForeColor = System.Drawing.Color.Black;
            this.gridView销售订单列表.Appearance.GroupPanel.Options.UseBackColor = true;
            this.gridView销售订单列表.Appearance.GroupPanel.Options.UseForeColor = true;
            this.gridView销售订单列表.Appearance.GroupRow.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(236)))), ((int)(((byte)(232)))), ((int)(((byte)(201)))));
            this.gridView销售订单列表.Appearance.GroupRow.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(236)))), ((int)(((byte)(232)))), ((int)(((byte)(201)))));
            this.gridView销售订单列表.Appearance.GroupRow.ForeColor = System.Drawing.Color.Black;
            this.gridView销售订单列表.Appearance.GroupRow.Options.UseBackColor = true;
            this.gridView销售订单列表.Appearance.GroupRow.Options.UseBorderColor = true;
            this.gridView销售订单列表.Appearance.GroupRow.Options.UseForeColor = true;
            this.gridView销售订单列表.Appearance.HeaderPanel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(216)))), ((int)(((byte)(209)))), ((int)(((byte)(170)))));
            this.gridView销售订单列表.Appearance.HeaderPanel.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(216)))), ((int)(((byte)(209)))), ((int)(((byte)(170)))));
            this.gridView销售订单列表.Appearance.HeaderPanel.ForeColor = System.Drawing.Color.Black;
            this.gridView销售订单列表.Appearance.HeaderPanel.Options.UseBackColor = true;
            this.gridView销售订单列表.Appearance.HeaderPanel.Options.UseBorderColor = true;
            this.gridView销售订单列表.Appearance.HeaderPanel.Options.UseForeColor = true;
            this.gridView销售订单列表.Appearance.HideSelectionRow.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(237)))), ((int)(((byte)(230)))), ((int)(((byte)(203)))));
            this.gridView销售订单列表.Appearance.HideSelectionRow.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(237)))), ((int)(((byte)(230)))), ((int)(((byte)(203)))));
            this.gridView销售订单列表.Appearance.HideSelectionRow.ForeColor = System.Drawing.Color.Black;
            this.gridView销售订单列表.Appearance.HideSelectionRow.Options.UseBackColor = true;
            this.gridView销售订单列表.Appearance.HideSelectionRow.Options.UseBorderColor = true;
            this.gridView销售订单列表.Appearance.HideSelectionRow.Options.UseForeColor = true;
            this.gridView销售订单列表.Appearance.HorzLine.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(216)))), ((int)(((byte)(209)))), ((int)(((byte)(170)))));
            this.gridView销售订单列表.Appearance.HorzLine.Options.UseBackColor = true;
            this.gridView销售订单列表.Appearance.OddRow.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(242)))), ((int)(((byte)(244)))), ((int)(((byte)(236)))));
            this.gridView销售订单列表.Appearance.OddRow.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(242)))), ((int)(((byte)(244)))), ((int)(((byte)(236)))));
            this.gridView销售订单列表.Appearance.OddRow.ForeColor = System.Drawing.Color.Black;
            this.gridView销售订单列表.Appearance.OddRow.Options.UseBackColor = true;
            this.gridView销售订单列表.Appearance.OddRow.Options.UseBorderColor = true;
            this.gridView销售订单列表.Appearance.OddRow.Options.UseForeColor = true;
            this.gridView销售订单列表.Appearance.Preview.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(251)))), ((int)(((byte)(252)))), ((int)(((byte)(247)))));
            this.gridView销售订单列表.Appearance.Preview.Font = new System.Drawing.Font("Verdana", 7.5F);
            this.gridView销售订单列表.Appearance.Preview.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(148)))), ((int)(((byte)(148)))), ((int)(((byte)(148)))));
            this.gridView销售订单列表.Appearance.Preview.Options.UseBackColor = true;
            this.gridView销售订单列表.Appearance.Preview.Options.UseFont = true;
            this.gridView销售订单列表.Appearance.Preview.Options.UseForeColor = true;
            this.gridView销售订单列表.Appearance.Row.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(242)))), ((int)(((byte)(244)))), ((int)(((byte)(236)))));
            this.gridView销售订单列表.Appearance.Row.ForeColor = System.Drawing.Color.Black;
            this.gridView销售订单列表.Appearance.Row.Options.UseBackColor = true;
            this.gridView销售订单列表.Appearance.Row.Options.UseForeColor = true;
            this.gridView销售订单列表.Appearance.RowSeparator.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(236)))), ((int)(((byte)(232)))), ((int)(((byte)(201)))));
            this.gridView销售订单列表.Appearance.RowSeparator.BackColor2 = System.Drawing.Color.White;
            this.gridView销售订单列表.Appearance.RowSeparator.Options.UseBackColor = true;
            this.gridView销售订单列表.Appearance.SelectedRow.BackColor = System.Drawing.Color.Lime;
            this.gridView销售订单列表.Appearance.SelectedRow.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(237)))), ((int)(((byte)(230)))), ((int)(((byte)(203)))));
            this.gridView销售订单列表.Appearance.SelectedRow.ForeColor = System.Drawing.Color.Black;
            this.gridView销售订单列表.Appearance.SelectedRow.Options.UseBackColor = true;
            this.gridView销售订单列表.Appearance.SelectedRow.Options.UseBorderColor = true;
            this.gridView销售订单列表.Appearance.SelectedRow.Options.UseForeColor = true;
            this.gridView销售订单列表.Appearance.TopNewRow.BackColor = System.Drawing.Color.White;
            this.gridView销售订单列表.Appearance.TopNewRow.Options.UseBackColor = true;
            this.gridView销售订单列表.Appearance.VertLine.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(216)))), ((int)(((byte)(209)))), ((int)(((byte)(170)))));
            this.gridView销售订单列表.Appearance.VertLine.Options.UseBackColor = true;
            this.gridView销售订单列表.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.gridCol1订单子表ID,
            this.gridCol1存货编码,
            this.gridCol1存货名称,
            this.gridCol1规格型号,
            this.gridCol1主计量编码,
            this.gridCol1主计量,
            this.gridCol1数量,
            this.gridCol1船期,
            this.gridCol1国外要求交期,
            this.gridCol1预完工日期,
            this.gridCol1评审下达完工日期,
            this.gridCol1评审数量,
            this.gridCol1销售订单行号});
            this.gridView销售订单列表.GridControl = this.gridControl销售订单列表;
            this.gridView销售订单列表.IndicatorWidth = 40;
            this.gridView销售订单列表.Name = "gridView销售订单列表";
            this.gridView销售订单列表.OptionsLayout.Columns.StoreAllOptions = true;
            this.gridView销售订单列表.OptionsLayout.Columns.StoreAppearance = true;
            this.gridView销售订单列表.OptionsLayout.StoreAllOptions = true;
            this.gridView销售订单列表.OptionsLayout.StoreAppearance = true;
            this.gridView销售订单列表.OptionsMenu.ShowAddNewSummaryItem = DevExpress.Utils.DefaultBoolean.True;
            this.gridView销售订单列表.OptionsMenu.ShowGroupSummaryEditorItem = true;
            this.gridView销售订单列表.OptionsNavigation.EnterMoveNextColumn = true;
            this.gridView销售订单列表.OptionsSelection.MultiSelect = true;
            this.gridView销售订单列表.OptionsView.ColumnAutoWidth = false;
            this.gridView销售订单列表.OptionsView.EnableAppearanceEvenRow = true;
            this.gridView销售订单列表.OptionsView.EnableAppearanceOddRow = true;
            this.gridView销售订单列表.OptionsView.ShowFooter = true;
            this.gridView销售订单列表.OptionsView.ShowGroupPanel = false;
            this.gridView销售订单列表.CustomDrawRowIndicator += new DevExpress.XtraGrid.Views.Grid.RowIndicatorCustomDrawEventHandler(this.gridView销售订单列表_CustomDrawRowIndicator);
            // 
            // gridCol1订单子表ID
            // 
            this.gridCol1订单子表ID.Caption = "订单子表ID";
            this.gridCol1订单子表ID.FieldName = "订单子表ID";
            this.gridCol1订单子表ID.Name = "gridCol1订单子表ID";
            this.gridCol1订单子表ID.OptionsColumn.AllowEdit = false;
            this.gridCol1订单子表ID.OptionsColumn.AllowMerge = DevExpress.Utils.DefaultBoolean.False;
            this.gridCol1订单子表ID.OptionsColumn.AllowSort = DevExpress.Utils.DefaultBoolean.False;
            this.gridCol1订单子表ID.OptionsFilter.AllowFilter = false;
            // 
            // gridCol1存货编码
            // 
            this.gridCol1存货编码.Caption = "存货编码";
            this.gridCol1存货编码.ColumnEdit = this.ItemLookUpEdit1存货编码;
            this.gridCol1存货编码.FieldName = "存货编码";
            this.gridCol1存货编码.Name = "gridCol1存货编码";
            this.gridCol1存货编码.OptionsColumn.AllowEdit = false;
            this.gridCol1存货编码.OptionsColumn.AllowMerge = DevExpress.Utils.DefaultBoolean.False;
            this.gridCol1存货编码.OptionsColumn.AllowSort = DevExpress.Utils.DefaultBoolean.False;
            this.gridCol1存货编码.OptionsFilter.AllowFilter = false;
            this.gridCol1存货编码.Visible = true;
            this.gridCol1存货编码.VisibleIndex = 1;
            this.gridCol1存货编码.Width = 110;
            // 
            // ItemLookUpEdit1存货编码
            // 
            this.ItemLookUpEdit1存货编码.AutoHeight = false;
            this.ItemLookUpEdit1存货编码.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.ItemLookUpEdit1存货编码.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("cInvCode", "物料编码"),
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("cInvName", "物料名称"),
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("cInvStd", "规格型号")});
            this.ItemLookUpEdit1存货编码.DisplayMember = "cInvCode";
            this.ItemLookUpEdit1存货编码.Name = "ItemLookUpEdit1存货编码";
            this.ItemLookUpEdit1存货编码.NullText = "";
            this.ItemLookUpEdit1存货编码.ValueMember = "cInvCode";
            // 
            // gridCol1存货名称
            // 
            this.gridCol1存货名称.Caption = "存货名称";
            this.gridCol1存货名称.ColumnEdit = this.ItemLookUpEdit1存货名称;
            this.gridCol1存货名称.FieldName = "存货编码";
            this.gridCol1存货名称.Name = "gridCol1存货名称";
            this.gridCol1存货名称.OptionsColumn.AllowEdit = false;
            this.gridCol1存货名称.OptionsColumn.AllowMerge = DevExpress.Utils.DefaultBoolean.False;
            this.gridCol1存货名称.OptionsColumn.AllowSort = DevExpress.Utils.DefaultBoolean.False;
            this.gridCol1存货名称.OptionsFilter.AllowFilter = false;
            this.gridCol1存货名称.Visible = true;
            this.gridCol1存货名称.VisibleIndex = 2;
            this.gridCol1存货名称.Width = 177;
            // 
            // ItemLookUpEdit1存货名称
            // 
            this.ItemLookUpEdit1存货名称.AccessibleRole = System.Windows.Forms.AccessibleRole.None;
            this.ItemLookUpEdit1存货名称.AutoHeight = false;
            this.ItemLookUpEdit1存货名称.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.ItemLookUpEdit1存货名称.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("cInvCode", "物料编码"),
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("cInvName", "物料名称"),
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("cInvStd", "规格型号")});
            this.ItemLookUpEdit1存货名称.DisplayMember = "cInvName";
            this.ItemLookUpEdit1存货名称.Name = "ItemLookUpEdit1存货名称";
            this.ItemLookUpEdit1存货名称.NullText = "";
            this.ItemLookUpEdit1存货名称.ValueMember = "cInvCode";
            // 
            // gridCol1规格型号
            // 
            this.gridCol1规格型号.Caption = "规格型号";
            this.gridCol1规格型号.ColumnEdit = this.ItemLookUpEdit1规格型号;
            this.gridCol1规格型号.FieldName = "存货编码";
            this.gridCol1规格型号.Name = "gridCol1规格型号";
            this.gridCol1规格型号.OptionsColumn.AllowEdit = false;
            this.gridCol1规格型号.OptionsColumn.AllowMerge = DevExpress.Utils.DefaultBoolean.False;
            this.gridCol1规格型号.OptionsColumn.AllowSort = DevExpress.Utils.DefaultBoolean.False;
            this.gridCol1规格型号.OptionsFilter.AllowFilter = false;
            this.gridCol1规格型号.Visible = true;
            this.gridCol1规格型号.VisibleIndex = 3;
            this.gridCol1规格型号.Width = 180;
            // 
            // ItemLookUpEdit1规格型号
            // 
            this.ItemLookUpEdit1规格型号.AutoHeight = false;
            this.ItemLookUpEdit1规格型号.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.ItemLookUpEdit1规格型号.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("cInvCode", "存货编码"),
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("cInvName", "存货名称"),
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("cInvStd", "规格型号")});
            this.ItemLookUpEdit1规格型号.DisplayMember = "cInvStd";
            this.ItemLookUpEdit1规格型号.Name = "ItemLookUpEdit1规格型号";
            this.ItemLookUpEdit1规格型号.NullText = "";
            this.ItemLookUpEdit1规格型号.ValueMember = "cInvCode";
            // 
            // gridCol1主计量编码
            // 
            this.gridCol1主计量编码.Caption = "主计量编码";
            this.gridCol1主计量编码.FieldName = "主计量编码";
            this.gridCol1主计量编码.Name = "gridCol1主计量编码";
            this.gridCol1主计量编码.OptionsColumn.AllowEdit = false;
            this.gridCol1主计量编码.OptionsColumn.AllowMerge = DevExpress.Utils.DefaultBoolean.False;
            this.gridCol1主计量编码.OptionsColumn.AllowSort = DevExpress.Utils.DefaultBoolean.False;
            this.gridCol1主计量编码.OptionsFilter.AllowFilter = false;
            // 
            // gridCol1主计量
            // 
            this.gridCol1主计量.Caption = "主计量";
            this.gridCol1主计量.FieldName = "主计量";
            this.gridCol1主计量.Name = "gridCol1主计量";
            this.gridCol1主计量.OptionsColumn.AllowEdit = false;
            this.gridCol1主计量.OptionsColumn.AllowMerge = DevExpress.Utils.DefaultBoolean.False;
            this.gridCol1主计量.OptionsColumn.AllowSort = DevExpress.Utils.DefaultBoolean.False;
            this.gridCol1主计量.OptionsFilter.AllowFilter = false;
            // 
            // gridCol1数量
            // 
            this.gridCol1数量.Caption = "数量";
            this.gridCol1数量.FieldName = "数量";
            this.gridCol1数量.Name = "gridCol1数量";
            this.gridCol1数量.OptionsColumn.AllowEdit = false;
            this.gridCol1数量.OptionsColumn.AllowMerge = DevExpress.Utils.DefaultBoolean.False;
            this.gridCol1数量.OptionsColumn.AllowSort = DevExpress.Utils.DefaultBoolean.False;
            this.gridCol1数量.OptionsFilter.AllowFilter = false;
            this.gridCol1数量.Visible = true;
            this.gridCol1数量.VisibleIndex = 8;
            // 
            // gridCol1船期
            // 
            this.gridCol1船期.Caption = "船期";
            this.gridCol1船期.FieldName = "船期";
            this.gridCol1船期.Name = "gridCol1船期";
            this.gridCol1船期.OptionsColumn.AllowEdit = false;
            this.gridCol1船期.OptionsColumn.AllowMerge = DevExpress.Utils.DefaultBoolean.False;
            this.gridCol1船期.OptionsColumn.AllowSort = DevExpress.Utils.DefaultBoolean.False;
            this.gridCol1船期.OptionsFilter.AllowFilter = false;
            this.gridCol1船期.Visible = true;
            this.gridCol1船期.VisibleIndex = 4;
            // 
            // gridCol1国外要求交期
            // 
            this.gridCol1国外要求交期.Caption = "国外要求交期";
            this.gridCol1国外要求交期.FieldName = "国外要求交期";
            this.gridCol1国外要求交期.Name = "gridCol1国外要求交期";
            this.gridCol1国外要求交期.OptionsColumn.AllowEdit = false;
            this.gridCol1国外要求交期.OptionsColumn.AllowSort = DevExpress.Utils.DefaultBoolean.False;
            this.gridCol1国外要求交期.OptionsFilter.AllowFilter = false;
            this.gridCol1国外要求交期.Visible = true;
            this.gridCol1国外要求交期.VisibleIndex = 5;
            this.gridCol1国外要求交期.Width = 97;
            // 
            // gridCol1预完工日期
            // 
            this.gridCol1预完工日期.Caption = "预完工日期";
            this.gridCol1预完工日期.FieldName = "预完工日期";
            this.gridCol1预完工日期.Name = "gridCol1预完工日期";
            this.gridCol1预完工日期.OptionsColumn.AllowEdit = false;
            this.gridCol1预完工日期.OptionsColumn.AllowSort = DevExpress.Utils.DefaultBoolean.False;
            this.gridCol1预完工日期.OptionsFilter.AllowFilter = false;
            this.gridCol1预完工日期.Visible = true;
            this.gridCol1预完工日期.VisibleIndex = 6;
            // 
            // gridCol1评审下达完工日期
            // 
            this.gridCol1评审下达完工日期.AppearanceHeader.ForeColor = System.Drawing.Color.Blue;
            this.gridCol1评审下达完工日期.AppearanceHeader.Options.UseForeColor = true;
            this.gridCol1评审下达完工日期.Caption = "评审下达完工日期";
            this.gridCol1评审下达完工日期.FieldName = "评审下达完工日期";
            this.gridCol1评审下达完工日期.Name = "gridCol1评审下达完工日期";
            this.gridCol1评审下达完工日期.OptionsColumn.AllowEdit = false;
            this.gridCol1评审下达完工日期.OptionsColumn.AllowSort = DevExpress.Utils.DefaultBoolean.False;
            this.gridCol1评审下达完工日期.OptionsFilter.AllowFilter = false;
            this.gridCol1评审下达完工日期.Visible = true;
            this.gridCol1评审下达完工日期.VisibleIndex = 7;
            this.gridCol1评审下达完工日期.Width = 120;
            // 
            // gridCol1评审数量
            // 
            this.gridCol1评审数量.AppearanceHeader.ForeColor = System.Drawing.Color.Blue;
            this.gridCol1评审数量.AppearanceHeader.Options.UseForeColor = true;
            this.gridCol1评审数量.Caption = "评审数量";
            this.gridCol1评审数量.FieldName = "评审数量";
            this.gridCol1评审数量.Name = "gridCol1评审数量";
            this.gridCol1评审数量.OptionsColumn.AllowEdit = false;
            this.gridCol1评审数量.OptionsColumn.AllowSort = DevExpress.Utils.DefaultBoolean.False;
            this.gridCol1评审数量.OptionsFilter.AllowFilter = false;
            this.gridCol1评审数量.Visible = true;
            this.gridCol1评审数量.VisibleIndex = 9;
            // 
            // gridCol1销售订单行号
            // 
            this.gridCol1销售订单行号.Caption = "销售订单行号";
            this.gridCol1销售订单行号.FieldName = "销售订单行号";
            this.gridCol1销售订单行号.Name = "gridCol1销售订单行号";
            this.gridCol1销售订单行号.OptionsColumn.AllowEdit = false;
            this.gridCol1销售订单行号.OptionsColumn.AllowSort = DevExpress.Utils.DefaultBoolean.False;
            this.gridCol1销售订单行号.OptionsFilter.AllowFilter = false;
            this.gridCol1销售订单行号.Visible = true;
            this.gridCol1销售订单行号.VisibleIndex = 0;
            this.gridCol1销售订单行号.Width = 85;
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.gridControl评审计算);
            this.tabPage2.Location = new System.Drawing.Point(4, 23);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(1079, 202);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "评审计算";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // gridControl评审计算
            // 
            this.gridControl评审计算.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridControl评审计算.Location = new System.Drawing.Point(3, 3);
            this.gridControl评审计算.MainView = this.gridView评审计算;
            this.gridControl评审计算.Name = "gridControl评审计算";
            this.gridControl评审计算.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.ItemLookUpEdit子件属性,
            this.ItemLookUpEdit物料编码,
            this.ItemLookUpEdit物料名称,
            this.ItemLookUpEdit规格型号,
            this.ItemLookUpEdit仓库编号,
            this.ItemLookUpEdit仓库名称,
            this.ItemLookUpEdit部门编码,
            this.ItemLookUpEdit部门名称});
            this.gridControl评审计算.Size = new System.Drawing.Size(1073, 196);
            this.gridControl评审计算.TabIndex = 8;
            this.gridControl评审计算.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView评审计算});
            // 
            // gridView评审计算
            // 
            this.gridView评审计算.Appearance.ColumnFilterButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(236)))), ((int)(((byte)(232)))), ((int)(((byte)(201)))));
            this.gridView评审计算.Appearance.ColumnFilterButton.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(236)))), ((int)(((byte)(232)))), ((int)(((byte)(201)))));
            this.gridView评审计算.Appearance.ColumnFilterButton.ForeColor = System.Drawing.Color.Black;
            this.gridView评审计算.Appearance.ColumnFilterButton.Options.UseBackColor = true;
            this.gridView评审计算.Appearance.ColumnFilterButton.Options.UseBorderColor = true;
            this.gridView评审计算.Appearance.ColumnFilterButton.Options.UseForeColor = true;
            this.gridView评审计算.Appearance.ColumnFilterButtonActive.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(221)))), ((int)(((byte)(231)))), ((int)(((byte)(234)))));
            this.gridView评审计算.Appearance.ColumnFilterButtonActive.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(221)))), ((int)(((byte)(231)))), ((int)(((byte)(234)))));
            this.gridView评审计算.Appearance.ColumnFilterButtonActive.ForeColor = System.Drawing.Color.Black;
            this.gridView评审计算.Appearance.ColumnFilterButtonActive.Options.UseBackColor = true;
            this.gridView评审计算.Appearance.ColumnFilterButtonActive.Options.UseBorderColor = true;
            this.gridView评审计算.Appearance.ColumnFilterButtonActive.Options.UseForeColor = true;
            this.gridView评审计算.Appearance.Empty.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(236)))), ((int)(((byte)(232)))), ((int)(((byte)(201)))));
            this.gridView评审计算.Appearance.Empty.BackColor2 = System.Drawing.Color.White;
            this.gridView评审计算.Appearance.Empty.Options.UseBackColor = true;
            this.gridView评审计算.Appearance.EvenRow.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(221)))), ((int)(((byte)(231)))), ((int)(((byte)(234)))));
            this.gridView评审计算.Appearance.EvenRow.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(221)))), ((int)(((byte)(231)))), ((int)(((byte)(234)))));
            this.gridView评审计算.Appearance.EvenRow.ForeColor = System.Drawing.Color.Black;
            this.gridView评审计算.Appearance.EvenRow.Options.UseBackColor = true;
            this.gridView评审计算.Appearance.EvenRow.Options.UseBorderColor = true;
            this.gridView评审计算.Appearance.EvenRow.Options.UseForeColor = true;
            this.gridView评审计算.Appearance.FilterCloseButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(216)))), ((int)(((byte)(209)))), ((int)(((byte)(179)))));
            this.gridView评审计算.Appearance.FilterCloseButton.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(216)))), ((int)(((byte)(209)))), ((int)(((byte)(179)))));
            this.gridView评审计算.Appearance.FilterCloseButton.ForeColor = System.Drawing.Color.Black;
            this.gridView评审计算.Appearance.FilterCloseButton.Options.UseBackColor = true;
            this.gridView评审计算.Appearance.FilterCloseButton.Options.UseBorderColor = true;
            this.gridView评审计算.Appearance.FilterCloseButton.Options.UseForeColor = true;
            this.gridView评审计算.Appearance.FilterPanel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(236)))), ((int)(((byte)(232)))), ((int)(((byte)(201)))));
            this.gridView评审计算.Appearance.FilterPanel.BackColor2 = System.Drawing.Color.White;
            this.gridView评审计算.Appearance.FilterPanel.ForeColor = System.Drawing.Color.Black;
            this.gridView评审计算.Appearance.FilterPanel.Options.UseBackColor = true;
            this.gridView评审计算.Appearance.FilterPanel.Options.UseForeColor = true;
            this.gridView评审计算.Appearance.FixedLine.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(122)))), ((int)(((byte)(114)))), ((int)(((byte)(113)))));
            this.gridView评审计算.Appearance.FixedLine.Options.UseBackColor = true;
            this.gridView评审计算.Appearance.FocusedCell.BackColor = System.Drawing.Color.White;
            this.gridView评审计算.Appearance.FocusedCell.ForeColor = System.Drawing.Color.Black;
            this.gridView评审计算.Appearance.FocusedCell.Options.UseBackColor = true;
            this.gridView评审计算.Appearance.FocusedCell.Options.UseForeColor = true;
            this.gridView评审计算.Appearance.FocusedRow.BackColor = System.Drawing.Color.Lime;
            this.gridView评审计算.Appearance.FocusedRow.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(219)))), ((int)(((byte)(188)))));
            this.gridView评审计算.Appearance.FocusedRow.ForeColor = System.Drawing.Color.Black;
            this.gridView评审计算.Appearance.FocusedRow.Options.UseBackColor = true;
            this.gridView评审计算.Appearance.FocusedRow.Options.UseBorderColor = true;
            this.gridView评审计算.Appearance.FocusedRow.Options.UseForeColor = true;
            this.gridView评审计算.Appearance.FooterPanel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(216)))), ((int)(((byte)(209)))), ((int)(((byte)(170)))));
            this.gridView评审计算.Appearance.FooterPanel.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(216)))), ((int)(((byte)(209)))), ((int)(((byte)(170)))));
            this.gridView评审计算.Appearance.FooterPanel.ForeColor = System.Drawing.Color.Black;
            this.gridView评审计算.Appearance.FooterPanel.Options.UseBackColor = true;
            this.gridView评审计算.Appearance.FooterPanel.Options.UseBorderColor = true;
            this.gridView评审计算.Appearance.FooterPanel.Options.UseForeColor = true;
            this.gridView评审计算.Appearance.GroupButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(216)))), ((int)(((byte)(209)))), ((int)(((byte)(179)))));
            this.gridView评审计算.Appearance.GroupButton.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(216)))), ((int)(((byte)(209)))), ((int)(((byte)(179)))));
            this.gridView评审计算.Appearance.GroupButton.Options.UseBackColor = true;
            this.gridView评审计算.Appearance.GroupButton.Options.UseBorderColor = true;
            this.gridView评审计算.Appearance.GroupFooter.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(236)))), ((int)(((byte)(232)))), ((int)(((byte)(201)))));
            this.gridView评审计算.Appearance.GroupFooter.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(236)))), ((int)(((byte)(232)))), ((int)(((byte)(201)))));
            this.gridView评审计算.Appearance.GroupFooter.ForeColor = System.Drawing.Color.Black;
            this.gridView评审计算.Appearance.GroupFooter.Options.UseBackColor = true;
            this.gridView评审计算.Appearance.GroupFooter.Options.UseBorderColor = true;
            this.gridView评审计算.Appearance.GroupFooter.Options.UseForeColor = true;
            this.gridView评审计算.Appearance.GroupPanel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(246)))), ((int)(((byte)(242)))), ((int)(((byte)(213)))));
            this.gridView评审计算.Appearance.GroupPanel.BackColor2 = System.Drawing.Color.White;
            this.gridView评审计算.Appearance.GroupPanel.ForeColor = System.Drawing.Color.Black;
            this.gridView评审计算.Appearance.GroupPanel.Options.UseBackColor = true;
            this.gridView评审计算.Appearance.GroupPanel.Options.UseForeColor = true;
            this.gridView评审计算.Appearance.GroupRow.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(236)))), ((int)(((byte)(232)))), ((int)(((byte)(201)))));
            this.gridView评审计算.Appearance.GroupRow.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(236)))), ((int)(((byte)(232)))), ((int)(((byte)(201)))));
            this.gridView评审计算.Appearance.GroupRow.ForeColor = System.Drawing.Color.Black;
            this.gridView评审计算.Appearance.GroupRow.Options.UseBackColor = true;
            this.gridView评审计算.Appearance.GroupRow.Options.UseBorderColor = true;
            this.gridView评审计算.Appearance.GroupRow.Options.UseForeColor = true;
            this.gridView评审计算.Appearance.HeaderPanel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(216)))), ((int)(((byte)(209)))), ((int)(((byte)(170)))));
            this.gridView评审计算.Appearance.HeaderPanel.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(216)))), ((int)(((byte)(209)))), ((int)(((byte)(170)))));
            this.gridView评审计算.Appearance.HeaderPanel.ForeColor = System.Drawing.Color.Black;
            this.gridView评审计算.Appearance.HeaderPanel.Options.UseBackColor = true;
            this.gridView评审计算.Appearance.HeaderPanel.Options.UseBorderColor = true;
            this.gridView评审计算.Appearance.HeaderPanel.Options.UseForeColor = true;
            this.gridView评审计算.Appearance.HideSelectionRow.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(237)))), ((int)(((byte)(230)))), ((int)(((byte)(203)))));
            this.gridView评审计算.Appearance.HideSelectionRow.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(237)))), ((int)(((byte)(230)))), ((int)(((byte)(203)))));
            this.gridView评审计算.Appearance.HideSelectionRow.ForeColor = System.Drawing.Color.Black;
            this.gridView评审计算.Appearance.HideSelectionRow.Options.UseBackColor = true;
            this.gridView评审计算.Appearance.HideSelectionRow.Options.UseBorderColor = true;
            this.gridView评审计算.Appearance.HideSelectionRow.Options.UseForeColor = true;
            this.gridView评审计算.Appearance.HorzLine.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(216)))), ((int)(((byte)(209)))), ((int)(((byte)(170)))));
            this.gridView评审计算.Appearance.HorzLine.Options.UseBackColor = true;
            this.gridView评审计算.Appearance.OddRow.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(242)))), ((int)(((byte)(244)))), ((int)(((byte)(236)))));
            this.gridView评审计算.Appearance.OddRow.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(242)))), ((int)(((byte)(244)))), ((int)(((byte)(236)))));
            this.gridView评审计算.Appearance.OddRow.ForeColor = System.Drawing.Color.Black;
            this.gridView评审计算.Appearance.OddRow.Options.UseBackColor = true;
            this.gridView评审计算.Appearance.OddRow.Options.UseBorderColor = true;
            this.gridView评审计算.Appearance.OddRow.Options.UseForeColor = true;
            this.gridView评审计算.Appearance.Preview.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(251)))), ((int)(((byte)(252)))), ((int)(((byte)(247)))));
            this.gridView评审计算.Appearance.Preview.Font = new System.Drawing.Font("Verdana", 7.5F);
            this.gridView评审计算.Appearance.Preview.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(148)))), ((int)(((byte)(148)))), ((int)(((byte)(148)))));
            this.gridView评审计算.Appearance.Preview.Options.UseBackColor = true;
            this.gridView评审计算.Appearance.Preview.Options.UseFont = true;
            this.gridView评审计算.Appearance.Preview.Options.UseForeColor = true;
            this.gridView评审计算.Appearance.Row.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(242)))), ((int)(((byte)(244)))), ((int)(((byte)(236)))));
            this.gridView评审计算.Appearance.Row.ForeColor = System.Drawing.Color.Black;
            this.gridView评审计算.Appearance.Row.Options.UseBackColor = true;
            this.gridView评审计算.Appearance.Row.Options.UseForeColor = true;
            this.gridView评审计算.Appearance.RowSeparator.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(236)))), ((int)(((byte)(232)))), ((int)(((byte)(201)))));
            this.gridView评审计算.Appearance.RowSeparator.BackColor2 = System.Drawing.Color.White;
            this.gridView评审计算.Appearance.RowSeparator.Options.UseBackColor = true;
            this.gridView评审计算.Appearance.SelectedRow.BackColor = System.Drawing.Color.Lime;
            this.gridView评审计算.Appearance.SelectedRow.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(237)))), ((int)(((byte)(230)))), ((int)(((byte)(203)))));
            this.gridView评审计算.Appearance.SelectedRow.ForeColor = System.Drawing.Color.Black;
            this.gridView评审计算.Appearance.SelectedRow.Options.UseBackColor = true;
            this.gridView评审计算.Appearance.SelectedRow.Options.UseBorderColor = true;
            this.gridView评审计算.Appearance.SelectedRow.Options.UseForeColor = true;
            this.gridView评审计算.Appearance.TopNewRow.BackColor = System.Drawing.Color.White;
            this.gridView评审计算.Appearance.TopNewRow.Options.UseBackColor = true;
            this.gridView评审计算.Appearance.VertLine.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(216)))), ((int)(((byte)(209)))), ((int)(((byte)(170)))));
            this.gridView评审计算.Appearance.VertLine.Options.UseBackColor = true;
            this.gridView评审计算.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.gridCol销售订单行号,
            this.gridCol根母件,
            this.gridCol级别,
            this.gridCol母件编码,
            this.gridCol母件名称,
            this.gridCol母件计量单位,
            this.gridCol母件规格,
            this.gridCol母件属性,
            this.gridCol子件行号,
            this.gridCol工序行号,
            this.gridCol子件编码,
            this.gridCol子件名称,
            this.gridCol子件规格,
            this.gridCol子件计量单位,
            this.gridCol子件辅助单位,
            this.gridCol换算率,
            this.gridCol供应类型,
            this.gridCol使用数量,
            this.gridCol子件属性,
            this.gridCol仓库代号,
            this.gridCol仓库名称,
            this.gridCol领料部门代号,
            this.gridCol领料部门名称,
            this.gridCol备注,
            this.gridCol需求数量,
            this.gridCol本次下单数量,
            this.gridCol仓库现存量,
            this.gridCol待入库量,
            this.gridCol最小批量,
            this.gridCol置办周期,
            this.gridCol开始日期,
            this.gridCol完成日期,
            this.gridCol质检周期,
            this.gridCol生产日工时,
            this.gridCol单件生产工时,
            this.gridCol生产工时,
            this.gridCol下单量,
            this.gridCol累计下单量,
            this.gridCol累计待入库,
            this.gridCol生产部门编码,
            this.gridCol生产部门名称,
            this.gridCol销售订单子表ID,
            this.gridCol累计可用数量,
            this.gridCol待出库量,
            this.gridCol已使用,
            this.gridCol母子对应,
            this.gridCol调整数量,
            this.gridColiID,
            this.gridCol本次下单数量存档});
            this.gridView评审计算.GridControl = this.gridControl评审计算;
            this.gridView评审计算.IndicatorWidth = 40;
            this.gridView评审计算.Name = "gridView评审计算";
            this.gridView评审计算.OptionsLayout.Columns.StoreAllOptions = true;
            this.gridView评审计算.OptionsLayout.Columns.StoreAppearance = true;
            this.gridView评审计算.OptionsLayout.StoreAllOptions = true;
            this.gridView评审计算.OptionsLayout.StoreAppearance = true;
            this.gridView评审计算.OptionsMenu.ShowAddNewSummaryItem = DevExpress.Utils.DefaultBoolean.True;
            this.gridView评审计算.OptionsMenu.ShowGroupSummaryEditorItem = true;
            this.gridView评审计算.OptionsNavigation.EnterMoveNextColumn = true;
            this.gridView评审计算.OptionsSelection.MultiSelect = true;
            this.gridView评审计算.OptionsView.AutoCalcPreviewLineCount = true;
            this.gridView评审计算.OptionsView.ColumnAutoWidth = false;
            this.gridView评审计算.OptionsView.EnableAppearanceEvenRow = true;
            this.gridView评审计算.OptionsView.EnableAppearanceOddRow = true;
            this.gridView评审计算.OptionsView.ShowFooter = true;
            this.gridView评审计算.OptionsView.ShowGroupPanel = false;
            this.gridView评审计算.CustomDrawRowIndicator += new DevExpress.XtraGrid.Views.Grid.RowIndicatorCustomDrawEventHandler(this.gridView评审计算_CustomDrawRowIndicator);
            this.gridView评审计算.CellValueChanged += new DevExpress.XtraGrid.Views.Base.CellValueChangedEventHandler(this.gridView评审计算_CellValueChanged);
            this.gridView评审计算.RowCellStyle += new DevExpress.XtraGrid.Views.Grid.RowCellStyleEventHandler(this.gridView评审计算_RowCellStyle);
            this.gridView评审计算.DoubleClick += new System.EventHandler(this.gridView评审计算_DoubleClick);
            // 
            // gridCol销售订单行号
            // 
            this.gridCol销售订单行号.Caption = "行号";
            this.gridCol销售订单行号.FieldName = "销售订单行号";
            this.gridCol销售订单行号.Fixed = DevExpress.XtraGrid.Columns.FixedStyle.Left;
            this.gridCol销售订单行号.Name = "gridCol销售订单行号";
            this.gridCol销售订单行号.OptionsColumn.AllowEdit = false;
            this.gridCol销售订单行号.OptionsColumn.AllowSort = DevExpress.Utils.DefaultBoolean.True;
            this.gridCol销售订单行号.Visible = true;
            this.gridCol销售订单行号.VisibleIndex = 0;
            this.gridCol销售订单行号.Width = 32;
            // 
            // gridCol根母件
            // 
            this.gridCol根母件.Caption = "根母件";
            this.gridCol根母件.FieldName = "根母件";
            this.gridCol根母件.Name = "gridCol根母件";
            this.gridCol根母件.OptionsColumn.AllowEdit = false;
            this.gridCol根母件.OptionsColumn.AllowMerge = DevExpress.Utils.DefaultBoolean.False;
            this.gridCol根母件.OptionsColumn.AllowSort = DevExpress.Utils.DefaultBoolean.True;
            // 
            // gridCol级别
            // 
            this.gridCol级别.Caption = "级别";
            this.gridCol级别.FieldName = "级别";
            this.gridCol级别.Name = "gridCol级别";
            this.gridCol级别.OptionsColumn.AllowEdit = false;
            this.gridCol级别.OptionsColumn.AllowMerge = DevExpress.Utils.DefaultBoolean.False;
            this.gridCol级别.OptionsColumn.AllowSort = DevExpress.Utils.DefaultBoolean.True;
            this.gridCol级别.Visible = true;
            this.gridCol级别.VisibleIndex = 19;
            this.gridCol级别.Width = 36;
            // 
            // gridCol母件编码
            // 
            this.gridCol母件编码.Caption = "母件编码";
            this.gridCol母件编码.ColumnEdit = this.ItemLookUpEdit物料编码;
            this.gridCol母件编码.FieldName = "母件编码";
            this.gridCol母件编码.Name = "gridCol母件编码";
            this.gridCol母件编码.OptionsColumn.AllowEdit = false;
            this.gridCol母件编码.OptionsColumn.AllowMerge = DevExpress.Utils.DefaultBoolean.False;
            this.gridCol母件编码.OptionsColumn.AllowSort = DevExpress.Utils.DefaultBoolean.True;
            this.gridCol母件编码.Visible = true;
            this.gridCol母件编码.VisibleIndex = 20;
            // 
            // ItemLookUpEdit物料编码
            // 
            this.ItemLookUpEdit物料编码.AutoHeight = false;
            this.ItemLookUpEdit物料编码.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.ItemLookUpEdit物料编码.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("cInvCode", "物料编码"),
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("cInvName", "物料名称"),
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("cInvStd", "规格型号")});
            this.ItemLookUpEdit物料编码.DisplayMember = "cInvCode";
            this.ItemLookUpEdit物料编码.Name = "ItemLookUpEdit物料编码";
            this.ItemLookUpEdit物料编码.ValueMember = "cInvCode";
            // 
            // gridCol母件名称
            // 
            this.gridCol母件名称.Caption = "母件名称";
            this.gridCol母件名称.ColumnEdit = this.ItemLookUpEdit物料名称;
            this.gridCol母件名称.FieldName = "母件编码";
            this.gridCol母件名称.Fixed = DevExpress.XtraGrid.Columns.FixedStyle.Left;
            this.gridCol母件名称.Name = "gridCol母件名称";
            this.gridCol母件名称.OptionsColumn.AllowEdit = false;
            this.gridCol母件名称.OptionsColumn.AllowMerge = DevExpress.Utils.DefaultBoolean.False;
            this.gridCol母件名称.OptionsColumn.AllowSort = DevExpress.Utils.DefaultBoolean.True;
            // 
            // ItemLookUpEdit物料名称
            // 
            this.ItemLookUpEdit物料名称.AutoHeight = false;
            this.ItemLookUpEdit物料名称.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.ItemLookUpEdit物料名称.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("cInvCode", "物料编码"),
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("cInvName", "物料名称"),
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("cInvStd", "规格型号")});
            this.ItemLookUpEdit物料名称.DisplayMember = "cInvName";
            this.ItemLookUpEdit物料名称.Name = "ItemLookUpEdit物料名称";
            this.ItemLookUpEdit物料名称.ValueMember = "cInvCode";
            // 
            // gridCol母件计量单位
            // 
            this.gridCol母件计量单位.Caption = "母件计量单位";
            this.gridCol母件计量单位.FieldName = "母件计量单位";
            this.gridCol母件计量单位.Name = "gridCol母件计量单位";
            this.gridCol母件计量单位.OptionsColumn.AllowEdit = false;
            this.gridCol母件计量单位.OptionsColumn.AllowMerge = DevExpress.Utils.DefaultBoolean.False;
            this.gridCol母件计量单位.OptionsColumn.AllowSort = DevExpress.Utils.DefaultBoolean.True;
            this.gridCol母件计量单位.Width = 87;
            // 
            // gridCol母件规格
            // 
            this.gridCol母件规格.Caption = "母件规格";
            this.gridCol母件规格.FieldName = "母件编码";
            this.gridCol母件规格.Fixed = DevExpress.XtraGrid.Columns.FixedStyle.Left;
            this.gridCol母件规格.Name = "gridCol母件规格";
            this.gridCol母件规格.OptionsColumn.AllowEdit = false;
            this.gridCol母件规格.OptionsColumn.AllowSort = DevExpress.Utils.DefaultBoolean.True;
            // 
            // gridCol母件属性
            // 
            this.gridCol母件属性.Caption = "母件属性";
            this.gridCol母件属性.FieldName = "母件属性";
            this.gridCol母件属性.Name = "gridCol母件属性";
            this.gridCol母件属性.OptionsColumn.AllowEdit = false;
            this.gridCol母件属性.OptionsColumn.AllowMerge = DevExpress.Utils.DefaultBoolean.False;
            this.gridCol母件属性.OptionsColumn.AllowSort = DevExpress.Utils.DefaultBoolean.True;
            // 
            // gridCol子件行号
            // 
            this.gridCol子件行号.Caption = "子件行号";
            this.gridCol子件行号.FieldName = "子件行号";
            this.gridCol子件行号.Name = "gridCol子件行号";
            this.gridCol子件行号.OptionsColumn.AllowEdit = false;
            this.gridCol子件行号.OptionsColumn.AllowMerge = DevExpress.Utils.DefaultBoolean.False;
            this.gridCol子件行号.OptionsColumn.AllowSort = DevExpress.Utils.DefaultBoolean.True;
            // 
            // gridCol工序行号
            // 
            this.gridCol工序行号.Caption = "工序行号";
            this.gridCol工序行号.FieldName = "工序行号";
            this.gridCol工序行号.Name = "gridCol工序行号";
            this.gridCol工序行号.OptionsColumn.AllowEdit = false;
            this.gridCol工序行号.OptionsColumn.AllowMerge = DevExpress.Utils.DefaultBoolean.False;
            this.gridCol工序行号.OptionsColumn.AllowSort = DevExpress.Utils.DefaultBoolean.True;
            // 
            // gridCol子件编码
            // 
            this.gridCol子件编码.Caption = "物料编码";
            this.gridCol子件编码.ColumnEdit = this.ItemLookUpEdit物料编码;
            this.gridCol子件编码.FieldName = "子件编码";
            this.gridCol子件编码.Fixed = DevExpress.XtraGrid.Columns.FixedStyle.Left;
            this.gridCol子件编码.Name = "gridCol子件编码";
            this.gridCol子件编码.OptionsColumn.AllowEdit = false;
            this.gridCol子件编码.OptionsColumn.AllowMerge = DevExpress.Utils.DefaultBoolean.False;
            this.gridCol子件编码.OptionsColumn.AllowSort = DevExpress.Utils.DefaultBoolean.True;
            this.gridCol子件编码.Visible = true;
            this.gridCol子件编码.VisibleIndex = 1;
            // 
            // gridCol子件名称
            // 
            this.gridCol子件名称.Caption = "物料名称";
            this.gridCol子件名称.ColumnEdit = this.ItemLookUpEdit物料名称;
            this.gridCol子件名称.FieldName = "子件编码";
            this.gridCol子件名称.Fixed = DevExpress.XtraGrid.Columns.FixedStyle.Left;
            this.gridCol子件名称.Name = "gridCol子件名称";
            this.gridCol子件名称.OptionsColumn.AllowEdit = false;
            this.gridCol子件名称.OptionsColumn.AllowMerge = DevExpress.Utils.DefaultBoolean.False;
            this.gridCol子件名称.OptionsColumn.AllowSort = DevExpress.Utils.DefaultBoolean.True;
            this.gridCol子件名称.Visible = true;
            this.gridCol子件名称.VisibleIndex = 2;
            // 
            // gridCol子件规格
            // 
            this.gridCol子件规格.Caption = "物料规格";
            this.gridCol子件规格.ColumnEdit = this.ItemLookUpEdit规格型号;
            this.gridCol子件规格.FieldName = "子件编码";
            this.gridCol子件规格.Fixed = DevExpress.XtraGrid.Columns.FixedStyle.Left;
            this.gridCol子件规格.Name = "gridCol子件规格";
            this.gridCol子件规格.OptionsColumn.AllowEdit = false;
            this.gridCol子件规格.OptionsColumn.AllowMerge = DevExpress.Utils.DefaultBoolean.False;
            this.gridCol子件规格.OptionsColumn.AllowSort = DevExpress.Utils.DefaultBoolean.True;
            this.gridCol子件规格.Visible = true;
            this.gridCol子件规格.VisibleIndex = 3;
            // 
            // ItemLookUpEdit规格型号
            // 
            this.ItemLookUpEdit规格型号.AutoHeight = false;
            this.ItemLookUpEdit规格型号.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.ItemLookUpEdit规格型号.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("cInvCode", "物料编码"),
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("cInvName", "物料名称"),
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("cInvStd", "规格型号")});
            this.ItemLookUpEdit规格型号.DisplayMember = "cInvStd";
            this.ItemLookUpEdit规格型号.Name = "ItemLookUpEdit规格型号";
            this.ItemLookUpEdit规格型号.ValueMember = "cInvCode";
            // 
            // gridCol子件计量单位
            // 
            this.gridCol子件计量单位.Caption = "子件计量单位";
            this.gridCol子件计量单位.FieldName = "子件计量单位";
            this.gridCol子件计量单位.Name = "gridCol子件计量单位";
            this.gridCol子件计量单位.OptionsColumn.AllowEdit = false;
            this.gridCol子件计量单位.OptionsColumn.AllowMerge = DevExpress.Utils.DefaultBoolean.False;
            this.gridCol子件计量单位.OptionsColumn.AllowSort = DevExpress.Utils.DefaultBoolean.True;
            this.gridCol子件计量单位.Width = 95;
            // 
            // gridCol子件辅助单位
            // 
            this.gridCol子件辅助单位.Caption = "子件辅助单位";
            this.gridCol子件辅助单位.FieldName = "辅助单位";
            this.gridCol子件辅助单位.Name = "gridCol子件辅助单位";
            this.gridCol子件辅助单位.OptionsColumn.AllowEdit = false;
            this.gridCol子件辅助单位.OptionsColumn.AllowMerge = DevExpress.Utils.DefaultBoolean.False;
            this.gridCol子件辅助单位.OptionsColumn.AllowSort = DevExpress.Utils.DefaultBoolean.True;
            this.gridCol子件辅助单位.Width = 89;
            // 
            // gridCol换算率
            // 
            this.gridCol换算率.Caption = "换算率";
            this.gridCol换算率.FieldName = "换算率";
            this.gridCol换算率.Name = "gridCol换算率";
            this.gridCol换算率.OptionsColumn.AllowEdit = false;
            this.gridCol换算率.OptionsColumn.AllowMerge = DevExpress.Utils.DefaultBoolean.False;
            this.gridCol换算率.OptionsColumn.AllowSort = DevExpress.Utils.DefaultBoolean.True;
            this.gridCol换算率.Visible = true;
            this.gridCol换算率.VisibleIndex = 22;
            // 
            // gridCol供应类型
            // 
            this.gridCol供应类型.Caption = "供应类型";
            this.gridCol供应类型.FieldName = "供应类型";
            this.gridCol供应类型.Name = "gridCol供应类型";
            this.gridCol供应类型.OptionsColumn.AllowEdit = false;
            this.gridCol供应类型.OptionsColumn.AllowMerge = DevExpress.Utils.DefaultBoolean.False;
            this.gridCol供应类型.OptionsColumn.AllowSort = DevExpress.Utils.DefaultBoolean.True;
            this.gridCol供应类型.Visible = true;
            this.gridCol供应类型.VisibleIndex = 16;
            // 
            // gridCol使用数量
            // 
            this.gridCol使用数量.Caption = "使用数量";
            this.gridCol使用数量.FieldName = "使用数量";
            this.gridCol使用数量.Name = "gridCol使用数量";
            this.gridCol使用数量.OptionsColumn.AllowEdit = false;
            this.gridCol使用数量.OptionsColumn.AllowMerge = DevExpress.Utils.DefaultBoolean.False;
            this.gridCol使用数量.OptionsColumn.AllowSort = DevExpress.Utils.DefaultBoolean.True;
            this.gridCol使用数量.Visible = true;
            this.gridCol使用数量.VisibleIndex = 17;
            // 
            // gridCol子件属性
            // 
            this.gridCol子件属性.Caption = "属性";
            this.gridCol子件属性.ColumnEdit = this.ItemLookUpEdit子件属性;
            this.gridCol子件属性.FieldName = "子件属性";
            this.gridCol子件属性.Name = "gridCol子件属性";
            this.gridCol子件属性.OptionsColumn.AllowEdit = false;
            this.gridCol子件属性.OptionsColumn.AllowMerge = DevExpress.Utils.DefaultBoolean.False;
            this.gridCol子件属性.OptionsColumn.AllowSort = DevExpress.Utils.DefaultBoolean.True;
            this.gridCol子件属性.Visible = true;
            this.gridCol子件属性.VisibleIndex = 15;
            this.gridCol子件属性.Width = 57;
            // 
            // ItemLookUpEdit子件属性
            // 
            this.ItemLookUpEdit子件属性.AutoHeight = false;
            this.ItemLookUpEdit子件属性.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.ItemLookUpEdit子件属性.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("iID", "子件属性")});
            this.ItemLookUpEdit子件属性.DisplayMember = "iID";
            this.ItemLookUpEdit子件属性.Name = "ItemLookUpEdit子件属性";
            this.ItemLookUpEdit子件属性.ValueMember = "iID";
            // 
            // gridCol仓库代号
            // 
            this.gridCol仓库代号.Caption = "仓库代号";
            this.gridCol仓库代号.ColumnEdit = this.ItemLookUpEdit仓库编号;
            this.gridCol仓库代号.FieldName = "仓库代号";
            this.gridCol仓库代号.Name = "gridCol仓库代号";
            this.gridCol仓库代号.OptionsColumn.AllowEdit = false;
            this.gridCol仓库代号.OptionsColumn.AllowMerge = DevExpress.Utils.DefaultBoolean.False;
            this.gridCol仓库代号.OptionsColumn.AllowSort = DevExpress.Utils.DefaultBoolean.True;
            // 
            // ItemLookUpEdit仓库编号
            // 
            this.ItemLookUpEdit仓库编号.AutoHeight = false;
            this.ItemLookUpEdit仓库编号.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.ItemLookUpEdit仓库编号.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("cWhCode", "仓库编码"),
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("cWhName", "仓库")});
            this.ItemLookUpEdit仓库编号.DisplayMember = "cWhCode";
            this.ItemLookUpEdit仓库编号.Name = "ItemLookUpEdit仓库编号";
            this.ItemLookUpEdit仓库编号.ValueMember = "cWhCode";
            // 
            // gridCol仓库名称
            // 
            this.gridCol仓库名称.Caption = "仓库名称";
            this.gridCol仓库名称.ColumnEdit = this.ItemLookUpEdit仓库名称;
            this.gridCol仓库名称.FieldName = "仓库代号";
            this.gridCol仓库名称.Name = "gridCol仓库名称";
            this.gridCol仓库名称.OptionsColumn.AllowEdit = false;
            this.gridCol仓库名称.OptionsColumn.AllowMerge = DevExpress.Utils.DefaultBoolean.False;
            this.gridCol仓库名称.OptionsColumn.AllowSort = DevExpress.Utils.DefaultBoolean.True;
            // 
            // ItemLookUpEdit仓库名称
            // 
            this.ItemLookUpEdit仓库名称.AutoHeight = false;
            this.ItemLookUpEdit仓库名称.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.ItemLookUpEdit仓库名称.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("cWhCode", "仓库编码"),
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("cWhName", "仓库")});
            this.ItemLookUpEdit仓库名称.DisplayMember = "cWhName";
            this.ItemLookUpEdit仓库名称.Name = "ItemLookUpEdit仓库名称";
            this.ItemLookUpEdit仓库名称.ValueMember = "cWhCode";
            // 
            // gridCol领料部门代号
            // 
            this.gridCol领料部门代号.Caption = "领料部门代号";
            this.gridCol领料部门代号.ColumnEdit = this.ItemLookUpEdit部门编码;
            this.gridCol领料部门代号.FieldName = "领料部门代号";
            this.gridCol领料部门代号.Name = "gridCol领料部门代号";
            this.gridCol领料部门代号.OptionsColumn.AllowEdit = false;
            this.gridCol领料部门代号.OptionsColumn.AllowMerge = DevExpress.Utils.DefaultBoolean.False;
            this.gridCol领料部门代号.OptionsColumn.AllowSort = DevExpress.Utils.DefaultBoolean.True;
            this.gridCol领料部门代号.Width = 105;
            // 
            // ItemLookUpEdit部门编码
            // 
            this.ItemLookUpEdit部门编码.AutoHeight = false;
            this.ItemLookUpEdit部门编码.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.ItemLookUpEdit部门编码.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("cDepCode", "部门编码"),
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("cDepName", "部门名称")});
            this.ItemLookUpEdit部门编码.DisplayMember = "cDepCode";
            this.ItemLookUpEdit部门编码.Name = "ItemLookUpEdit部门编码";
            this.ItemLookUpEdit部门编码.ValueMember = "cDepCode";
            // 
            // gridCol领料部门名称
            // 
            this.gridCol领料部门名称.Caption = "领料部门名称";
            this.gridCol领料部门名称.ColumnEdit = this.ItemLookUpEdit部门名称;
            this.gridCol领料部门名称.FieldName = "领料部门代号";
            this.gridCol领料部门名称.Name = "gridCol领料部门名称";
            this.gridCol领料部门名称.OptionsColumn.AllowEdit = false;
            this.gridCol领料部门名称.OptionsColumn.AllowMerge = DevExpress.Utils.DefaultBoolean.False;
            this.gridCol领料部门名称.OptionsColumn.AllowSort = DevExpress.Utils.DefaultBoolean.True;
            this.gridCol领料部门名称.Width = 95;
            // 
            // ItemLookUpEdit部门名称
            // 
            this.ItemLookUpEdit部门名称.AutoHeight = false;
            this.ItemLookUpEdit部门名称.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.ItemLookUpEdit部门名称.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("cDepCode", "部门变化"),
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("cDepName", "部门")});
            this.ItemLookUpEdit部门名称.DisplayMember = "cDepName";
            this.ItemLookUpEdit部门名称.Name = "ItemLookUpEdit部门名称";
            this.ItemLookUpEdit部门名称.ValueMember = "cDepCode";
            // 
            // gridCol备注
            // 
            this.gridCol备注.Caption = "备注";
            this.gridCol备注.FieldName = "备注";
            this.gridCol备注.Name = "gridCol备注";
            this.gridCol备注.OptionsColumn.AllowEdit = false;
            this.gridCol备注.OptionsColumn.AllowMerge = DevExpress.Utils.DefaultBoolean.False;
            this.gridCol备注.OptionsColumn.AllowSort = DevExpress.Utils.DefaultBoolean.True;
            this.gridCol备注.Visible = true;
            this.gridCol备注.VisibleIndex = 18;
            // 
            // gridCol需求数量
            // 
            this.gridCol需求数量.Caption = "需求数量";
            this.gridCol需求数量.FieldName = "需求数量";
            this.gridCol需求数量.Fixed = DevExpress.XtraGrid.Columns.FixedStyle.Left;
            this.gridCol需求数量.Name = "gridCol需求数量";
            this.gridCol需求数量.OptionsColumn.AllowEdit = false;
            this.gridCol需求数量.OptionsColumn.AllowMerge = DevExpress.Utils.DefaultBoolean.False;
            this.gridCol需求数量.OptionsColumn.AllowSort = DevExpress.Utils.DefaultBoolean.True;
            this.gridCol需求数量.Summary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] {
            new DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum)});
            this.gridCol需求数量.Visible = true;
            this.gridCol需求数量.VisibleIndex = 4;
            // 
            // gridCol本次下单数量
            // 
            this.gridCol本次下单数量.AppearanceHeader.ForeColor = System.Drawing.Color.Blue;
            this.gridCol本次下单数量.AppearanceHeader.Options.UseForeColor = true;
            this.gridCol本次下单数量.Caption = "本次下单数量";
            this.gridCol本次下单数量.FieldName = "本次下单数量";
            this.gridCol本次下单数量.Fixed = DevExpress.XtraGrid.Columns.FixedStyle.Left;
            this.gridCol本次下单数量.Name = "gridCol本次下单数量";
            this.gridCol本次下单数量.OptionsColumn.AllowEdit = false;
            this.gridCol本次下单数量.OptionsColumn.AllowMerge = DevExpress.Utils.DefaultBoolean.False;
            this.gridCol本次下单数量.OptionsColumn.AllowSort = DevExpress.Utils.DefaultBoolean.True;
            this.gridCol本次下单数量.Summary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] {
            new DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum)});
            this.gridCol本次下单数量.Visible = true;
            this.gridCol本次下单数量.VisibleIndex = 5;
            this.gridCol本次下单数量.Width = 87;
            // 
            // gridCol仓库现存量
            // 
            this.gridCol仓库现存量.Caption = "仓库现存量";
            this.gridCol仓库现存量.FieldName = "仓库现存量";
            this.gridCol仓库现存量.Name = "gridCol仓库现存量";
            this.gridCol仓库现存量.OptionsColumn.AllowEdit = false;
            this.gridCol仓库现存量.OptionsColumn.AllowMerge = DevExpress.Utils.DefaultBoolean.False;
            this.gridCol仓库现存量.OptionsColumn.AllowSort = DevExpress.Utils.DefaultBoolean.True;
            this.gridCol仓库现存量.Visible = true;
            this.gridCol仓库现存量.VisibleIndex = 12;
            // 
            // gridCol待入库量
            // 
            this.gridCol待入库量.Caption = "待入库量";
            this.gridCol待入库量.FieldName = "待入库量";
            this.gridCol待入库量.Name = "gridCol待入库量";
            this.gridCol待入库量.OptionsColumn.AllowEdit = false;
            this.gridCol待入库量.OptionsColumn.AllowMerge = DevExpress.Utils.DefaultBoolean.False;
            this.gridCol待入库量.OptionsColumn.AllowSort = DevExpress.Utils.DefaultBoolean.True;
            this.gridCol待入库量.Visible = true;
            this.gridCol待入库量.VisibleIndex = 13;
            // 
            // gridCol最小批量
            // 
            this.gridCol最小批量.Caption = "最小批量";
            this.gridCol最小批量.FieldName = "最小批量";
            this.gridCol最小批量.Name = "gridCol最小批量";
            this.gridCol最小批量.OptionsColumn.AllowEdit = false;
            this.gridCol最小批量.OptionsColumn.AllowMerge = DevExpress.Utils.DefaultBoolean.False;
            this.gridCol最小批量.OptionsColumn.AllowSort = DevExpress.Utils.DefaultBoolean.True;
            this.gridCol最小批量.Visible = true;
            this.gridCol最小批量.VisibleIndex = 10;
            // 
            // gridCol置办周期
            // 
            this.gridCol置办周期.Caption = "置办周期";
            this.gridCol置办周期.FieldName = "置办周期";
            this.gridCol置办周期.Name = "gridCol置办周期";
            this.gridCol置办周期.OptionsColumn.AllowEdit = false;
            this.gridCol置办周期.OptionsColumn.AllowMerge = DevExpress.Utils.DefaultBoolean.False;
            this.gridCol置办周期.OptionsColumn.AllowSort = DevExpress.Utils.DefaultBoolean.True;
            this.gridCol置办周期.Visible = true;
            this.gridCol置办周期.VisibleIndex = 8;
            // 
            // gridCol开始日期
            // 
            this.gridCol开始日期.AppearanceHeader.ForeColor = System.Drawing.Color.Blue;
            this.gridCol开始日期.AppearanceHeader.Options.UseForeColor = true;
            this.gridCol开始日期.Caption = "开始日期";
            this.gridCol开始日期.FieldName = "开始日期";
            this.gridCol开始日期.Fixed = DevExpress.XtraGrid.Columns.FixedStyle.Left;
            this.gridCol开始日期.Name = "gridCol开始日期";
            this.gridCol开始日期.OptionsColumn.AllowEdit = false;
            this.gridCol开始日期.OptionsColumn.AllowMerge = DevExpress.Utils.DefaultBoolean.False;
            this.gridCol开始日期.OptionsColumn.AllowSort = DevExpress.Utils.DefaultBoolean.True;
            this.gridCol开始日期.Visible = true;
            this.gridCol开始日期.VisibleIndex = 6;
            // 
            // gridCol完成日期
            // 
            this.gridCol完成日期.AppearanceHeader.ForeColor = System.Drawing.Color.Blue;
            this.gridCol完成日期.AppearanceHeader.Options.UseForeColor = true;
            this.gridCol完成日期.Caption = "完成日期";
            this.gridCol完成日期.FieldName = "完成日期";
            this.gridCol完成日期.Fixed = DevExpress.XtraGrid.Columns.FixedStyle.Left;
            this.gridCol完成日期.Name = "gridCol完成日期";
            this.gridCol完成日期.OptionsColumn.AllowEdit = false;
            this.gridCol完成日期.OptionsColumn.AllowMerge = DevExpress.Utils.DefaultBoolean.False;
            this.gridCol完成日期.OptionsColumn.AllowSort = DevExpress.Utils.DefaultBoolean.True;
            this.gridCol完成日期.Visible = true;
            this.gridCol完成日期.VisibleIndex = 7;
            // 
            // gridCol质检周期
            // 
            this.gridCol质检周期.Caption = "质检周期";
            this.gridCol质检周期.FieldName = "质检周期";
            this.gridCol质检周期.Name = "gridCol质检周期";
            this.gridCol质检周期.OptionsColumn.AllowEdit = false;
            this.gridCol质检周期.OptionsColumn.AllowMerge = DevExpress.Utils.DefaultBoolean.False;
            this.gridCol质检周期.OptionsColumn.AllowSort = DevExpress.Utils.DefaultBoolean.True;
            this.gridCol质检周期.Visible = true;
            this.gridCol质检周期.VisibleIndex = 9;
            this.gridCol质检周期.Width = 63;
            // 
            // gridCol生产日工时
            // 
            this.gridCol生产日工时.Caption = "生产日工时";
            this.gridCol生产日工时.FieldName = "生产日工时";
            this.gridCol生产日工时.Name = "gridCol生产日工时";
            this.gridCol生产日工时.OptionsColumn.AllowEdit = false;
            this.gridCol生产日工时.OptionsColumn.AllowMerge = DevExpress.Utils.DefaultBoolean.False;
            this.gridCol生产日工时.OptionsColumn.AllowSort = DevExpress.Utils.DefaultBoolean.True;
            this.gridCol生产日工时.Visible = true;
            this.gridCol生产日工时.VisibleIndex = 24;
            // 
            // gridCol单件生产工时
            // 
            this.gridCol单件生产工时.Caption = "单件生产工时";
            this.gridCol单件生产工时.FieldName = "单件生产工时";
            this.gridCol单件生产工时.Name = "gridCol单件生产工时";
            this.gridCol单件生产工时.OptionsColumn.AllowEdit = false;
            this.gridCol单件生产工时.OptionsColumn.AllowSort = DevExpress.Utils.DefaultBoolean.True;
            this.gridCol单件生产工时.Visible = true;
            this.gridCol单件生产工时.VisibleIndex = 23;
            this.gridCol单件生产工时.Width = 92;
            // 
            // gridCol生产工时
            // 
            this.gridCol生产工时.Caption = "生产工时";
            this.gridCol生产工时.FieldName = "生产工时";
            this.gridCol生产工时.Name = "gridCol生产工时";
            this.gridCol生产工时.OptionsColumn.AllowEdit = false;
            this.gridCol生产工时.OptionsColumn.AllowSort = DevExpress.Utils.DefaultBoolean.True;
            this.gridCol生产工时.Visible = true;
            this.gridCol生产工时.VisibleIndex = 25;
            // 
            // gridCol下单量
            // 
            this.gridCol下单量.Caption = "下单量";
            this.gridCol下单量.FieldName = "下单量";
            this.gridCol下单量.Name = "gridCol下单量";
            this.gridCol下单量.OptionsColumn.AllowEdit = false;
            this.gridCol下单量.OptionsColumn.AllowSort = DevExpress.Utils.DefaultBoolean.True;
            this.gridCol下单量.Visible = true;
            this.gridCol下单量.VisibleIndex = 26;
            // 
            // gridCol累计下单量
            // 
            this.gridCol累计下单量.Caption = "累计下单量";
            this.gridCol累计下单量.FieldName = "累计下单量";
            this.gridCol累计下单量.Name = "gridCol累计下单量";
            this.gridCol累计下单量.OptionsColumn.AllowEdit = false;
            this.gridCol累计下单量.OptionsColumn.AllowSort = DevExpress.Utils.DefaultBoolean.True;
            this.gridCol累计下单量.Visible = true;
            this.gridCol累计下单量.VisibleIndex = 27;
            this.gridCol累计下单量.Width = 88;
            // 
            // gridCol累计待入库
            // 
            this.gridCol累计待入库.Caption = "累计待入库";
            this.gridCol累计待入库.FieldName = "累计待入库";
            this.gridCol累计待入库.Name = "gridCol累计待入库";
            this.gridCol累计待入库.OptionsColumn.AllowEdit = false;
            this.gridCol累计待入库.OptionsColumn.AllowSort = DevExpress.Utils.DefaultBoolean.True;
            // 
            // gridCol生产部门编码
            // 
            this.gridCol生产部门编码.Caption = "生产部门编码";
            this.gridCol生产部门编码.ColumnEdit = this.ItemLookUpEdit部门编码;
            this.gridCol生产部门编码.FieldName = "生产部门编码";
            this.gridCol生产部门编码.Name = "gridCol生产部门编码";
            this.gridCol生产部门编码.OptionsColumn.AllowEdit = false;
            this.gridCol生产部门编码.OptionsColumn.AllowSort = DevExpress.Utils.DefaultBoolean.True;
            this.gridCol生产部门编码.Visible = true;
            this.gridCol生产部门编码.VisibleIndex = 28;
            // 
            // gridCol生产部门名称
            // 
            this.gridCol生产部门名称.Caption = "生产部门名称";
            this.gridCol生产部门名称.ColumnEdit = this.ItemLookUpEdit部门名称;
            this.gridCol生产部门名称.FieldName = "生产部门编码";
            this.gridCol生产部门名称.Name = "gridCol生产部门名称";
            this.gridCol生产部门名称.OptionsColumn.AllowEdit = false;
            this.gridCol生产部门名称.OptionsColumn.AllowSort = DevExpress.Utils.DefaultBoolean.True;
            this.gridCol生产部门名称.Visible = true;
            this.gridCol生产部门名称.VisibleIndex = 29;
            // 
            // gridCol销售订单子表ID
            // 
            this.gridCol销售订单子表ID.Caption = "销售订单子表ID";
            this.gridCol销售订单子表ID.FieldName = "销售订单子表ID";
            this.gridCol销售订单子表ID.Name = "gridCol销售订单子表ID";
            this.gridCol销售订单子表ID.OptionsColumn.AllowEdit = false;
            this.gridCol销售订单子表ID.OptionsColumn.AllowSort = DevExpress.Utils.DefaultBoolean.True;
            this.gridCol销售订单子表ID.Width = 109;
            // 
            // gridCol累计可用数量
            // 
            this.gridCol累计可用数量.Caption = "累计可用数量";
            this.gridCol累计可用数量.FieldName = "累计可用数量";
            this.gridCol累计可用数量.Name = "gridCol累计可用数量";
            this.gridCol累计可用数量.OptionsColumn.AllowEdit = false;
            this.gridCol累计可用数量.OptionsColumn.AllowSort = DevExpress.Utils.DefaultBoolean.True;
            this.gridCol累计可用数量.Width = 88;
            // 
            // gridCol待出库量
            // 
            this.gridCol待出库量.Caption = "待出库量";
            this.gridCol待出库量.FieldName = "待出库量";
            this.gridCol待出库量.Name = "gridCol待出库量";
            this.gridCol待出库量.OptionsColumn.AllowEdit = false;
            this.gridCol待出库量.Visible = true;
            this.gridCol待出库量.VisibleIndex = 14;
            // 
            // gridCol已使用
            // 
            this.gridCol已使用.Caption = "已使用";
            this.gridCol已使用.FieldName = "已使用";
            this.gridCol已使用.Name = "gridCol已使用";
            this.gridCol已使用.OptionsColumn.AllowEdit = false;
            // 
            // gridCol母子对应
            // 
            this.gridCol母子对应.Caption = "母子对应";
            this.gridCol母子对应.FieldName = "母子对应";
            this.gridCol母子对应.Name = "gridCol母子对应";
            this.gridCol母子对应.OptionsColumn.AllowEdit = false;
            this.gridCol母子对应.Visible = true;
            this.gridCol母子对应.VisibleIndex = 21;
            this.gridCol母子对应.Width = 98;
            // 
            // gridCol调整数量
            // 
            this.gridCol调整数量.Caption = "调整数量";
            this.gridCol调整数量.FieldName = "调整数量";
            this.gridCol调整数量.Name = "gridCol调整数量";
            this.gridCol调整数量.OptionsColumn.AllowEdit = false;
            this.gridCol调整数量.Visible = true;
            this.gridCol调整数量.VisibleIndex = 11;
            this.gridCol调整数量.Width = 60;
            // 
            // gridColiID
            // 
            this.gridColiID.Caption = "iID";
            this.gridColiID.FieldName = "iID";
            this.gridColiID.Name = "gridColiID";
            this.gridColiID.OptionsColumn.AllowEdit = false;
            this.gridColiID.OptionsColumn.AllowSort = DevExpress.Utils.DefaultBoolean.True;
            this.gridColiID.Visible = true;
            this.gridColiID.VisibleIndex = 30;
            // 
            // txt销售订单ID
            // 
            this.txt销售订单ID.Enabled = false;
            this.txt销售订单ID.Location = new System.Drawing.Point(997, 46);
            this.txt销售订单ID.Name = "txt销售订单ID";
            this.txt销售订单ID.Size = new System.Drawing.Size(100, 20);
            this.txt销售订单ID.TabIndex = 64;
            // 
            // txt制单人
            // 
            this.txt制单人.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.txt制单人.Enabled = false;
            this.txt制单人.Location = new System.Drawing.Point(76, 366);
            this.txt制单人.Name = "txt制单人";
            this.txt制单人.Size = new System.Drawing.Size(99, 20);
            this.txt制单人.TabIndex = 68;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.btn变更部门);
            this.groupBox1.Controls.Add(this.btn15天核查);
            this.groupBox1.Controls.Add(this.btn日期检查);
            this.groupBox1.Controls.Add(this.dtm完成日期);
            this.groupBox1.Controls.Add(this.chk完成日期);
            this.groupBox1.Controls.Add(this.dtm开始日期);
            this.groupBox1.Controls.Add(this.chk开始日期);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.txt存货编码);
            this.groupBox1.Controls.Add(this.btnChange);
            this.groupBox1.Controls.Add(this.radio手工);
            this.groupBox1.Controls.Add(this.radio逆排);
            this.groupBox1.Controls.Add(this.radio顺排);
            this.groupBox1.Location = new System.Drawing.Point(10, 89);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(1087, 38);
            this.groupBox1.TabIndex = 63;
            this.groupBox1.TabStop = false;
            // 
            // btn变更部门
            // 
            this.btn变更部门.Location = new System.Drawing.Point(1003, 17);
            this.btn变更部门.Name = "btn变更部门";
            this.btn变更部门.Size = new System.Drawing.Size(75, 23);
            this.btn变更部门.TabIndex = 65;
            this.btn变更部门.Text = "变更部门";
            this.btn变更部门.UseVisualStyleBackColor = true;
            this.btn变更部门.Click += new System.EventHandler(this.btn变更部门_Click);
            // 
            // btn15天核查
            // 
            this.btn15天核查.Enabled = false;
            this.btn15天核查.Location = new System.Drawing.Point(236, 17);
            this.btn15天核查.Name = "btn15天核查";
            this.btn15天核查.Size = new System.Drawing.Size(75, 23);
            this.btn15天核查.TabIndex = 64;
            this.btn15天核查.Text = "15天核查";
            this.btn15天核查.UseVisualStyleBackColor = true;
            this.btn15天核查.Click += new System.EventHandler(this.btn15天核查_Click);
            // 
            // btn日期检查
            // 
            this.btn日期检查.Enabled = false;
            this.btn日期检查.Location = new System.Drawing.Point(317, 17);
            this.btn日期检查.Name = "btn日期检查";
            this.btn日期检查.Size = new System.Drawing.Size(75, 23);
            this.btn日期检查.TabIndex = 63;
            this.btn日期检查.Text = "日期检查";
            this.btn日期检查.UseVisualStyleBackColor = true;
            this.btn日期检查.Click += new System.EventHandler(this.btn日期检查_Click);
            // 
            // dtm完成日期
            // 
            this.dtm完成日期.EditValue = null;
            this.dtm完成日期.Enabled = false;
            this.dtm完成日期.Location = new System.Drawing.Point(816, 18);
            this.dtm完成日期.Name = "dtm完成日期";
            this.dtm完成日期.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.dtm完成日期.Properties.VistaTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
            this.dtm完成日期.Size = new System.Drawing.Size(100, 20);
            this.dtm完成日期.TabIndex = 62;
            // 
            // chk完成日期
            // 
            this.chk完成日期.AutoSize = true;
            this.chk完成日期.Enabled = false;
            this.chk完成日期.Location = new System.Drawing.Point(745, 19);
            this.chk完成日期.Name = "chk完成日期";
            this.chk完成日期.Size = new System.Drawing.Size(74, 18);
            this.chk完成日期.TabIndex = 61;
            this.chk完成日期.Text = "完成日期";
            this.chk完成日期.UseVisualStyleBackColor = true;
            this.chk完成日期.CheckedChanged += new System.EventHandler(this.chk完成日期_CheckedChanged_1);
            // 
            // dtm开始日期
            // 
            this.dtm开始日期.EditValue = null;
            this.dtm开始日期.Enabled = false;
            this.dtm开始日期.Location = new System.Drawing.Point(633, 18);
            this.dtm开始日期.Name = "dtm开始日期";
            this.dtm开始日期.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.dtm开始日期.Properties.VistaTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
            this.dtm开始日期.Size = new System.Drawing.Size(100, 20);
            this.dtm开始日期.TabIndex = 60;
            // 
            // chk开始日期
            // 
            this.chk开始日期.AutoSize = true;
            this.chk开始日期.Enabled = false;
            this.chk开始日期.Location = new System.Drawing.Point(562, 19);
            this.chk开始日期.Name = "chk开始日期";
            this.chk开始日期.Size = new System.Drawing.Size(74, 18);
            this.chk开始日期.TabIndex = 59;
            this.chk开始日期.Text = "开始日期";
            this.chk开始日期.UseVisualStyleBackColor = true;
            this.chk开始日期.CheckedChanged += new System.EventHandler(this.chk开始日期_CheckedChanged_1);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(395, 21);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(55, 14);
            this.label1.TabIndex = 57;
            this.label1.Text = "存货编码";
            // 
            // txt存货编码
            // 
            this.txt存货编码.Enabled = false;
            this.txt存货编码.Location = new System.Drawing.Point(456, 18);
            this.txt存货编码.Name = "txt存货编码";
            this.txt存货编码.Size = new System.Drawing.Size(100, 20);
            this.txt存货编码.TabIndex = 56;
            // 
            // btnChange
            // 
            this.btnChange.Enabled = false;
            this.btnChange.Location = new System.Drawing.Point(922, 17);
            this.btnChange.Name = "btnChange";
            this.btnChange.Size = new System.Drawing.Size(75, 23);
            this.btnChange.TabIndex = 55;
            this.btnChange.Text = "批改";
            this.btnChange.UseVisualStyleBackColor = true;
            this.btnChange.Click += new System.EventHandler(this.btnChange_Click);
            // 
            // radio手工
            // 
            this.radio手工.AutoSize = true;
            this.radio手工.Enabled = false;
            this.radio手工.ForeColor = System.Drawing.Color.Blue;
            this.radio手工.Location = new System.Drawing.Point(164, 19);
            this.radio手工.Name = "radio手工";
            this.radio手工.Size = new System.Drawing.Size(73, 18);
            this.radio手工.TabIndex = 45;
            this.radio手工.Text = "手工排程";
            this.radio手工.UseVisualStyleBackColor = true;
            this.radio手工.CheckedChanged += new System.EventHandler(this.radio_CheckedChanged);
            // 
            // radio逆排
            // 
            this.radio逆排.AutoSize = true;
            this.radio逆排.Checked = true;
            this.radio逆排.Enabled = false;
            this.radio逆排.ForeColor = System.Drawing.Color.Blue;
            this.radio逆排.Location = new System.Drawing.Point(7, 19);
            this.radio逆排.Name = "radio逆排";
            this.radio逆排.Size = new System.Drawing.Size(73, 18);
            this.radio逆排.TabIndex = 39;
            this.radio逆排.TabStop = true;
            this.radio逆排.Text = "逆推排程";
            this.radio逆排.UseVisualStyleBackColor = true;
            this.radio逆排.CheckedChanged += new System.EventHandler(this.radio_CheckedChanged);
            // 
            // radio顺排
            // 
            this.radio顺排.AutoSize = true;
            this.radio顺排.Enabled = false;
            this.radio顺排.ForeColor = System.Drawing.Color.Blue;
            this.radio顺排.Location = new System.Drawing.Point(85, 19);
            this.radio顺排.Name = "radio顺排";
            this.radio顺排.Size = new System.Drawing.Size(73, 18);
            this.radio顺排.TabIndex = 38;
            this.radio顺排.Text = "顺推排程";
            this.radio顺排.UseVisualStyleBackColor = true;
            this.radio顺排.CheckedChanged += new System.EventHandler(this.radio_CheckedChanged);
            // 
            // txt备注
            // 
            this.txt备注.Enabled = false;
            this.txt备注.Location = new System.Drawing.Point(80, 46);
            this.txt备注.Name = "txt备注";
            this.txt备注.Size = new System.Drawing.Size(833, 20);
            this.txt备注.TabIndex = 60;
            // 
            // txt客户订单号
            // 
            this.txt客户订单号.Enabled = false;
            this.txt客户订单号.Location = new System.Drawing.Point(503, 24);
            this.txt客户订单号.Name = "txt客户订单号";
            this.txt客户订单号.Size = new System.Drawing.Size(226, 20);
            this.txt客户订单号.TabIndex = 62;
            // 
            // txt销售订单号
            // 
            this.txt销售订单号.Enabled = false;
            this.txt销售订单号.Location = new System.Drawing.Point(80, 24);
            this.txt销售订单号.Name = "txt销售订单号";
            this.txt销售订单号.Size = new System.Drawing.Size(130, 20);
            this.txt销售订单号.TabIndex = 59;
            // 
            // txt外销订单号
            // 
            this.txt外销订单号.Enabled = false;
            this.txt外销订单号.Location = new System.Drawing.Point(292, 24);
            this.txt外销订单号.Name = "txt外销订单号";
            this.txt外销订单号.Size = new System.Drawing.Size(122, 20);
            this.txt外销订单号.TabIndex = 61;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(3, 24);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(67, 14);
            this.label2.TabIndex = 74;
            this.label2.Text = "销售订单号";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(16, 48);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(31, 14);
            this.label3.TabIndex = 74;
            this.label3.Text = "备注";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(16, 72);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(55, 14);
            this.label4.TabIndex = 74;
            this.label4.Text = "评审备注";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(214, 26);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(67, 14);
            this.label5.TabIndex = 74;
            this.label5.Text = "外销订单号";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(425, 26);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(67, 14);
            this.label6.TabIndex = 74;
            this.label6.Text = "客户订单号";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(744, 24);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(55, 14);
            this.label7.TabIndex = 74;
            this.label7.Text = "客户简称";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(918, 48);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(67, 14);
            this.label8.TabIndex = 74;
            this.label8.Text = "销售订单ID";
            // 
            // label9
            // 
            this.label9.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(7, 368);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(43, 14);
            this.label9.TabIndex = 75;
            this.label9.Text = "制单人";
            // 
            // label10
            // 
            this.label10.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(180, 368);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(55, 14);
            this.label10.TabIndex = 75;
            this.label10.Text = "制单日期";
            // 
            // label11
            // 
            this.label11.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(352, 368);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(43, 14);
            this.label11.TabIndex = 75;
            this.label11.Text = "审核人";
            // 
            // label12
            // 
            this.label12.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(523, 368);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(55, 14);
            this.label12.TabIndex = 75;
            this.label12.Text = "审核日期";
            // 
            // label13
            // 
            this.label13.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(723, 368);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(43, 14);
            this.label13.TabIndex = 75;
            this.label13.Text = "关闭人";
            // 
            // label14
            // 
            this.label14.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(901, 368);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(55, 14);
            this.label14.TabIndex = 75;
            this.label14.Text = "关闭日期";
            // 
            // gridCol本次下单数量存档
            // 
            this.gridCol本次下单数量存档.Caption = "本次下单数量存档";
            this.gridCol本次下单数量存档.FieldName = "本次下单数量存档";
            this.gridCol本次下单数量存档.Name = "gridCol本次下单数量存档";
            this.gridCol本次下单数量存档.OptionsColumn.AllowEdit = false;
            this.gridCol本次下单数量存档.Visible = true;
            this.gridCol本次下单数量存档.VisibleIndex = 31;
            // 
            // Frm订单评审运算
            // 
            this.Appearance.BackColor = System.Drawing.SystemColors.Control;
            this.Appearance.Options.UseBackColor = true;
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1106, 394);
            this.Controls.Add(this.label14);
            this.Controls.Add(this.label13);
            this.Controls.Add(this.label12);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.dtm关闭日期);
            this.Controls.Add(this.txt关闭人);
            this.Controls.Add(this.txt审核人);
            this.Controls.Add(this.dtm制单日期);
            this.Controls.Add(this.txt评审备注);
            this.Controls.Add(this.lookUpEdit客户);
            this.Controls.Add(this.dtm审核日期);
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.txt销售订单ID);
            this.Controls.Add(this.txt制单人);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.txt备注);
            this.Controls.Add(this.txt客户订单号);
            this.Controls.Add(this.txt销售订单号);
            this.Controls.Add(this.txt外销订单号);
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "Frm订单评审运算";
            this.Text = "Frm订单评审运算";
            this.Load += new System.EventHandler(this.Frm订单评审运算_Load);
            this.Controls.SetChildIndex(this.txt外销订单号, 0);
            this.Controls.SetChildIndex(this.txt销售订单号, 0);
            this.Controls.SetChildIndex(this.txt客户订单号, 0);
            this.Controls.SetChildIndex(this.txt备注, 0);
            this.Controls.SetChildIndex(this.groupBox1, 0);
            this.Controls.SetChildIndex(this.txt制单人, 0);
            this.Controls.SetChildIndex(this.txt销售订单ID, 0);
            this.Controls.SetChildIndex(this.tabControl1, 0);
            this.Controls.SetChildIndex(this.dtm审核日期, 0);
            this.Controls.SetChildIndex(this.lookUpEdit客户, 0);
            this.Controls.SetChildIndex(this.txt评审备注, 0);
            this.Controls.SetChildIndex(this.dtm制单日期, 0);
            this.Controls.SetChildIndex(this.txt审核人, 0);
            this.Controls.SetChildIndex(this.txt关闭人, 0);
            this.Controls.SetChildIndex(this.dtm关闭日期, 0);
            this.Controls.SetChildIndex(this.label2, 0);
            this.Controls.SetChildIndex(this.label3, 0);
            this.Controls.SetChildIndex(this.label5, 0);
            this.Controls.SetChildIndex(this.label4, 0);
            this.Controls.SetChildIndex(this.label6, 0);
            this.Controls.SetChildIndex(this.label7, 0);
            this.Controls.SetChildIndex(this.label8, 0);
            this.Controls.SetChildIndex(this.label9, 0);
            this.Controls.SetChildIndex(this.label10, 0);
            this.Controls.SetChildIndex(this.label11, 0);
            this.Controls.SetChildIndex(this.label12, 0);
            this.Controls.SetChildIndex(this.label13, 0);
            this.Controls.SetChildIndex(this.label14, 0);
            ((System.ComponentModel.ISupportInitialize)(this.dsPrint)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dsForm)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtSel)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtm关闭日期.Properties.VistaTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtm关闭日期.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txt关闭人.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txt审核人.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtm制单日期.Properties.VistaTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtm制单日期.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txt评审备注.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lookUpEdit客户.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtm审核日期.Properties.VistaTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtm审核日期.Properties)).EndInit();
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gridControl销售订单列表)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView销售订单列表)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ItemLookUpEdit1存货编码)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ItemLookUpEdit1存货名称)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ItemLookUpEdit1规格型号)).EndInit();
            this.tabPage2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gridControl评审计算)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView评审计算)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ItemLookUpEdit物料编码)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ItemLookUpEdit物料名称)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ItemLookUpEdit规格型号)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ItemLookUpEdit子件属性)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ItemLookUpEdit仓库编号)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ItemLookUpEdit仓库名称)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ItemLookUpEdit部门编码)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ItemLookUpEdit部门名称)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txt销售订单ID.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txt制单人.Properties)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dtm完成日期.Properties.VistaTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtm完成日期.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtm开始日期.Properties.VistaTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtm开始日期.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txt存货编码.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txt备注.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txt客户订单号.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txt销售订单号.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txt外销订单号.Properties)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraEditors.DateEdit dtm关闭日期;
        private DevExpress.XtraEditors.TextEdit txt关闭人;
        private DevExpress.XtraEditors.TextEdit txt审核人;
        private DevExpress.XtraEditors.DateEdit dtm制单日期;
        private DevExpress.XtraEditors.TextEdit txt评审备注;
        private DevExpress.XtraEditors.LookUpEdit lookUpEdit客户;
        private DevExpress.XtraEditors.DateEdit dtm审核日期;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private DevExpress.XtraGrid.GridControl gridControl销售订单列表;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView销售订单列表;
        private DevExpress.XtraGrid.Columns.GridColumn gridCol1订单子表ID;
        private DevExpress.XtraGrid.Columns.GridColumn gridCol1存货编码;
        private DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit ItemLookUpEdit1存货编码;
        private DevExpress.XtraGrid.Columns.GridColumn gridCol1存货名称;
        private DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit ItemLookUpEdit1存货名称;
        private DevExpress.XtraGrid.Columns.GridColumn gridCol1规格型号;
        private DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit ItemLookUpEdit1规格型号;
        private DevExpress.XtraGrid.Columns.GridColumn gridCol1主计量编码;
        private DevExpress.XtraGrid.Columns.GridColumn gridCol1主计量;
        private DevExpress.XtraGrid.Columns.GridColumn gridCol1数量;
        private DevExpress.XtraGrid.Columns.GridColumn gridCol1船期;
        private DevExpress.XtraGrid.Columns.GridColumn gridCol1国外要求交期;
        private DevExpress.XtraGrid.Columns.GridColumn gridCol1预完工日期;
        private DevExpress.XtraGrid.Columns.GridColumn gridCol1评审下达完工日期;
        private DevExpress.XtraGrid.Columns.GridColumn gridCol1评审数量;
        private DevExpress.XtraGrid.Columns.GridColumn gridCol1销售订单行号;
        private System.Windows.Forms.TabPage tabPage2;
        private DevExpress.XtraGrid.GridControl gridControl评审计算;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView评审计算;
        private DevExpress.XtraGrid.Columns.GridColumn gridCol销售订单行号;
        private DevExpress.XtraGrid.Columns.GridColumn gridCol根母件;
        private DevExpress.XtraGrid.Columns.GridColumn gridCol级别;
        private DevExpress.XtraGrid.Columns.GridColumn gridCol母件编码;
        private DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit ItemLookUpEdit物料编码;
        private DevExpress.XtraGrid.Columns.GridColumn gridCol母件名称;
        private DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit ItemLookUpEdit物料名称;
        private DevExpress.XtraGrid.Columns.GridColumn gridCol母件计量单位;
        private DevExpress.XtraGrid.Columns.GridColumn gridCol母件规格;
        private DevExpress.XtraGrid.Columns.GridColumn gridCol母件属性;
        private DevExpress.XtraGrid.Columns.GridColumn gridCol子件行号;
        private DevExpress.XtraGrid.Columns.GridColumn gridCol工序行号;
        private DevExpress.XtraGrid.Columns.GridColumn gridCol子件编码;
        private DevExpress.XtraGrid.Columns.GridColumn gridCol子件名称;
        private DevExpress.XtraGrid.Columns.GridColumn gridCol子件规格;
        private DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit ItemLookUpEdit规格型号;
        private DevExpress.XtraGrid.Columns.GridColumn gridCol子件计量单位;
        private DevExpress.XtraGrid.Columns.GridColumn gridCol子件辅助单位;
        private DevExpress.XtraGrid.Columns.GridColumn gridCol换算率;
        private DevExpress.XtraGrid.Columns.GridColumn gridCol供应类型;
        private DevExpress.XtraGrid.Columns.GridColumn gridCol使用数量;
        private DevExpress.XtraGrid.Columns.GridColumn gridCol子件属性;
        private DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit ItemLookUpEdit子件属性;
        private DevExpress.XtraGrid.Columns.GridColumn gridCol仓库代号;
        private DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit ItemLookUpEdit仓库编号;
        private DevExpress.XtraGrid.Columns.GridColumn gridCol仓库名称;
        private DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit ItemLookUpEdit仓库名称;
        private DevExpress.XtraGrid.Columns.GridColumn gridCol领料部门代号;
        private DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit ItemLookUpEdit部门编码;
        private DevExpress.XtraGrid.Columns.GridColumn gridCol领料部门名称;
        private DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit ItemLookUpEdit部门名称;
        private DevExpress.XtraGrid.Columns.GridColumn gridCol备注;
        private DevExpress.XtraGrid.Columns.GridColumn gridCol需求数量;
        private DevExpress.XtraGrid.Columns.GridColumn gridCol本次下单数量;
        private DevExpress.XtraGrid.Columns.GridColumn gridCol仓库现存量;
        private DevExpress.XtraGrid.Columns.GridColumn gridCol待入库量;
        private DevExpress.XtraGrid.Columns.GridColumn gridCol最小批量;
        private DevExpress.XtraGrid.Columns.GridColumn gridCol置办周期;
        private DevExpress.XtraGrid.Columns.GridColumn gridCol开始日期;
        private DevExpress.XtraGrid.Columns.GridColumn gridCol完成日期;
        private DevExpress.XtraGrid.Columns.GridColumn gridCol质检周期;
        private DevExpress.XtraGrid.Columns.GridColumn gridCol生产日工时;
        private DevExpress.XtraGrid.Columns.GridColumn gridCol单件生产工时;
        private DevExpress.XtraGrid.Columns.GridColumn gridCol生产工时;
        private DevExpress.XtraGrid.Columns.GridColumn gridCol下单量;
        private DevExpress.XtraGrid.Columns.GridColumn gridCol累计下单量;
        private DevExpress.XtraGrid.Columns.GridColumn gridCol累计待入库;
        private DevExpress.XtraGrid.Columns.GridColumn gridCol生产部门编码;
        private DevExpress.XtraGrid.Columns.GridColumn gridCol生产部门名称;
        private DevExpress.XtraGrid.Columns.GridColumn gridCol销售订单子表ID;
        private DevExpress.XtraGrid.Columns.GridColumn gridCol累计可用数量;
        private DevExpress.XtraGrid.Columns.GridColumn gridCol待出库量;
        private DevExpress.XtraGrid.Columns.GridColumn gridCol已使用;
        private DevExpress.XtraGrid.Columns.GridColumn gridCol母子对应;
        private DevExpress.XtraGrid.Columns.GridColumn gridCol调整数量;
        private DevExpress.XtraGrid.Columns.GridColumn gridColiID;
        private DevExpress.XtraEditors.TextEdit txt销售订单ID;
        private DevExpress.XtraEditors.TextEdit txt制单人;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button btn变更部门;
        private System.Windows.Forms.Button btn15天核查;
        private System.Windows.Forms.Button btn日期检查;
        private DevExpress.XtraEditors.DateEdit dtm完成日期;
        private System.Windows.Forms.CheckBox chk完成日期;
        private DevExpress.XtraEditors.DateEdit dtm开始日期;
        private System.Windows.Forms.CheckBox chk开始日期;
        private System.Windows.Forms.Label label1;
        private DevExpress.XtraEditors.TextEdit txt存货编码;
        private System.Windows.Forms.Button btnChange;
        private System.Windows.Forms.RadioButton radio手工;
        private System.Windows.Forms.RadioButton radio逆排;
        private System.Windows.Forms.RadioButton radio顺排;
        private DevExpress.XtraEditors.TextEdit txt备注;
        private DevExpress.XtraEditors.TextEdit txt客户订单号;
        private DevExpress.XtraEditors.TextEdit txt销售订单号;
        private DevExpress.XtraEditors.TextEdit txt外销订单号;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label label14;
        private DevExpress.XtraGrid.Columns.GridColumn gridCol本次下单数量存档;

        //private DevExpress.XtraLayout.LayoutControlGroup layoutControlGroup1;
    }
}