namespace ImportDLL
{
    partial class Frm订单评审
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
            this.layoutControl1 = new DevExpress.XtraLayout.LayoutControl();
            this.dtm单据日期 = new DevExpress.XtraEditors.DateEdit();
            this.textEdit单据号 = new DevExpress.XtraEditors.TextEdit();
            this.dtm关闭日期 = new DevExpress.XtraEditors.DateEdit();
            this.txt关闭人 = new DevExpress.XtraEditors.TextEdit();
            this.txt审核人 = new DevExpress.XtraEditors.TextEdit();
            this.dtm制单日期 = new DevExpress.XtraEditors.DateEdit();
            this.dtm审核日期 = new DevExpress.XtraEditors.DateEdit();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.gridControl1 = new DevExpress.XtraGrid.GridControl();
            this.gridView1 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.gridCol_评审单据号 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridCol_评审单据日期 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridCol_帐套号 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridCol_销售订单号 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridCol_单据日期 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridCol_客户编码 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridCol_客户简称 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridCol_行号 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridCol_存货编码 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridCol_存货名称 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridCol_规格型号 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridCol_订单数量 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridCol_交货日期 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridCol_销售订单子表ID = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridCol_已评审数量 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridCol_待评审数量 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridCol_数量 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridCol_Guid = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridCol_制单人 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridCol_制单日期 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridCol_锁定人 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridCol_锁定日期 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridCol_审核人 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridCol_审核日期 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridCol_关闭人 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridCol_关闭日期 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.gridControl评审计算 = new DevExpress.XtraGrid.GridControl();
            this.gridView评审计算 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.gridCol序号 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridCol级别 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridCol顶级母件编码 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridCol母件编码 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridCol母件名称 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridCol母件代号 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridCol母件规格 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridCol母件计量单位 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridCol母件损耗率 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridCol版本代号 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridCol版本说明 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridCol版本日期 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridCol状态 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridCol母件属性 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridCol变更单号 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridCol行号 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridCol子件行号 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridCol工序行号 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridCol子件编码 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridCol子件名称 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridCol子件代号 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridCol子件规格 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridCol子件计量单位 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridCol基本用量 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridCol基础用量 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridCol子件损耗率 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridCol固定用量 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridCol供应类型 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridCol单阶使用数量 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridCol加成数量 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridCol子件生效日 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridCol子件失效日 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridCol偏置期 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridCol计划比例 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridCol产出品 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridCol产出类型 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridCol成本相关 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridCol可选否 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridCol选择规则 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridCol备注 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridCol子件属性 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridCol母子关联 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridCol销售订单号 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridCol销售订单行号 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridCol销售订单子表ID = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridCol需求数量 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.ItemTextEditn2 = new DevExpress.XtraEditors.Repository.RepositoryItemTextEdit();
            this.gridCol评审数量 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridCol本单需求数量 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridCol交货日期 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridCol开始日期 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridCol结束日期 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridCol评审采购周期 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridCol评审委外周期 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridCol单件默认生产工时 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridCol默认产线 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.ItemLookUpEdit产线编码 = new DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit();
            this.gridCol产线 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.ItemLookUpEdit产线 = new DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit();
            this.gridCol质检周期 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridCol生产准备时间 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridCol经济批量 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridCol置办周期 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridCol生产合计工时 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridCol默认产线并发生产数 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridCol仓库存量 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridCol待入库数量 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridCol待出库数量 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridCol销售单号 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridCol仓库编码 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridCol仓库名称 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridCol领料部门编码 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridCol生产部门编码 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColGUIDHead = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColGUID = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridCol评审单据号 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColiID = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridCol换算率 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.txt制单人 = new DevExpress.XtraEditors.TextEdit();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.dateEditNow = new DevExpress.XtraEditors.DateEdit();
            this.btn日期顺推 = new System.Windows.Forms.Button();
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
            this.layoutControlGroup1 = new DevExpress.XtraLayout.LayoutControlGroup();
            this.layoutControlItem29 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem3 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem8 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem9 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem10 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem11 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem12 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem13 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem1 = new DevExpress.XtraLayout.LayoutControlItem();
            this.emptySpaceItem1 = new DevExpress.XtraLayout.EmptySpaceItem();
            this.layoutControlItem2 = new DevExpress.XtraLayout.LayoutControlItem();
            ((System.ComponentModel.ISupportInitialize)(this.dsPrint)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dsForm)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtSel)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControl1)).BeginInit();
            this.layoutControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dtm单据日期.Properties.VistaTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtm单据日期.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.textEdit单据号.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtm关闭日期.Properties.VistaTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtm关闭日期.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txt关闭人.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txt审核人.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtm制单日期.Properties.VistaTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtm制单日期.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtm审核日期.Properties.VistaTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtm审核日期.Properties)).BeginInit();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).BeginInit();
            this.tabPage2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl评审计算)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView评审计算)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ItemTextEditn2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ItemLookUpEdit产线编码)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ItemLookUpEdit产线)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txt制单人.Properties)).BeginInit();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dateEditNow.Properties.VistaTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dateEditNow.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtm完成日期.Properties.VistaTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtm完成日期.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtm开始日期.Properties.VistaTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtm开始日期.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txt存货编码.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem29)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem8)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem9)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem10)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem11)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem12)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem13)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem2)).BeginInit();
            this.SuspendLayout();
            // 
            // layoutControl1
            // 
            this.layoutControl1.AllowCustomizationMenu = false;
            this.layoutControl1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.layoutControl1.Controls.Add(this.dtm单据日期);
            this.layoutControl1.Controls.Add(this.textEdit单据号);
            this.layoutControl1.Controls.Add(this.dtm关闭日期);
            this.layoutControl1.Controls.Add(this.txt关闭人);
            this.layoutControl1.Controls.Add(this.txt审核人);
            this.layoutControl1.Controls.Add(this.dtm制单日期);
            this.layoutControl1.Controls.Add(this.dtm审核日期);
            this.layoutControl1.Controls.Add(this.tabControl1);
            this.layoutControl1.Controls.Add(this.txt制单人);
            this.layoutControl1.Controls.Add(this.groupBox1);
            this.layoutControl1.Location = new System.Drawing.Point(0, 28);
            this.layoutControl1.Name = "layoutControl1";
            this.layoutControl1.OptionsCustomizationForm.DesignTimeCustomizationFormPositionAndSize = new System.Drawing.Rectangle(491, 212, 250, 350);
            this.layoutControl1.OptionsCustomizationForm.ShowLoadButton = false;
            this.layoutControl1.OptionsCustomizationForm.ShowSaveButton = false;
            this.layoutControl1.Root = this.layoutControlGroup1;
            this.layoutControl1.Size = new System.Drawing.Size(1108, 365);
            this.layoutControl1.TabIndex = 5;
            this.layoutControl1.Text = "layoutControl1";
            // 
            // dtm单据日期
            // 
            this.dtm单据日期.EditValue = null;
            this.dtm单据日期.Enabled = false;
            this.dtm单据日期.Location = new System.Drawing.Point(229, 12);
            this.dtm单据日期.Name = "dtm单据日期";
            this.dtm单据日期.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.dtm单据日期.Properties.VistaTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
            this.dtm单据日期.Size = new System.Drawing.Size(89, 20);
            this.dtm单据日期.StyleController = this.layoutControl1;
            this.dtm单据日期.TabIndex = 55;
            // 
            // textEdit单据号
            // 
            this.textEdit单据号.Enabled = false;
            this.textEdit单据号.Location = new System.Drawing.Point(64, 12);
            this.textEdit单据号.Name = "textEdit单据号";
            this.textEdit单据号.Size = new System.Drawing.Size(109, 20);
            this.textEdit单据号.StyleController = this.layoutControl1;
            this.textEdit单据号.TabIndex = 59;
            // 
            // dtm关闭日期
            // 
            this.dtm关闭日期.EditValue = null;
            this.dtm关闭日期.Enabled = false;
            this.dtm关闭日期.Location = new System.Drawing.Point(956, 333);
            this.dtm关闭日期.Name = "dtm关闭日期";
            this.dtm关闭日期.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.dtm关闭日期.Properties.VistaTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
            this.dtm关闭日期.Size = new System.Drawing.Size(140, 20);
            this.dtm关闭日期.StyleController = this.layoutControl1;
            this.dtm关闭日期.TabIndex = 58;
            // 
            // txt关闭人
            // 
            this.txt关闭人.Enabled = false;
            this.txt关闭人.Location = new System.Drawing.Point(774, 333);
            this.txt关闭人.Name = "txt关闭人";
            this.txt关闭人.Size = new System.Drawing.Size(126, 20);
            this.txt关闭人.StyleController = this.layoutControl1;
            this.txt关闭人.TabIndex = 57;
            // 
            // txt审核人
            // 
            this.txt审核人.Enabled = false;
            this.txt审核人.Location = new System.Drawing.Point(406, 333);
            this.txt审核人.Name = "txt审核人";
            this.txt审核人.Size = new System.Drawing.Size(113, 20);
            this.txt审核人.StyleController = this.layoutControl1;
            this.txt审核人.TabIndex = 55;
            // 
            // dtm制单日期
            // 
            this.dtm制单日期.EditValue = null;
            this.dtm制单日期.Enabled = false;
            this.dtm制单日期.Location = new System.Drawing.Point(236, 333);
            this.dtm制单日期.Name = "dtm制单日期";
            this.dtm制单日期.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.dtm制单日期.Properties.VistaTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
            this.dtm制单日期.Size = new System.Drawing.Size(114, 20);
            this.dtm制单日期.StyleController = this.layoutControl1;
            this.dtm制单日期.TabIndex = 54;
            // 
            // dtm审核日期
            // 
            this.dtm审核日期.EditValue = null;
            this.dtm审核日期.Enabled = false;
            this.dtm审核日期.Location = new System.Drawing.Point(575, 333);
            this.dtm审核日期.Name = "dtm审核日期";
            this.dtm审核日期.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.dtm审核日期.Properties.VistaTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
            this.dtm审核日期.Size = new System.Drawing.Size(143, 20);
            this.dtm审核日期.StyleController = this.layoutControl1;
            this.dtm审核日期.TabIndex = 56;
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Location = new System.Drawing.Point(12, 89);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(1084, 240);
            this.tabControl1.TabIndex = 50;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.gridControl1);
            this.tabPage1.Location = new System.Drawing.Point(4, 23);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(1076, 213);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "销售订单列表";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // gridControl1
            // 
            this.gridControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridControl1.Location = new System.Drawing.Point(3, 3);
            this.gridControl1.MainView = this.gridView1;
            this.gridControl1.Name = "gridControl1";
            this.gridControl1.Size = new System.Drawing.Size(1070, 207);
            this.gridControl1.TabIndex = 8;
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
            this.gridCol_评审单据号,
            this.gridCol_评审单据日期,
            this.gridCol_帐套号,
            this.gridCol_销售订单号,
            this.gridCol_单据日期,
            this.gridCol_客户编码,
            this.gridCol_客户简称,
            this.gridCol_行号,
            this.gridCol_存货编码,
            this.gridCol_存货名称,
            this.gridCol_规格型号,
            this.gridCol_订单数量,
            this.gridCol_交货日期,
            this.gridCol_销售订单子表ID,
            this.gridCol_已评审数量,
            this.gridCol_待评审数量,
            this.gridCol_数量,
            this.gridCol_Guid,
            this.gridCol_制单人,
            this.gridCol_制单日期,
            this.gridCol_锁定人,
            this.gridCol_锁定日期,
            this.gridCol_审核人,
            this.gridCol_审核日期,
            this.gridCol_关闭人,
            this.gridCol_关闭日期});
            this.gridView1.GridControl = this.gridControl1;
            this.gridView1.IndicatorWidth = 40;
            this.gridView1.Name = "gridView1";
            this.gridView1.OptionsCustomization.AllowFilter = false;
            this.gridView1.OptionsCustomization.AllowSort = false;
            this.gridView1.OptionsLayout.Columns.StoreAllOptions = true;
            this.gridView1.OptionsLayout.Columns.StoreAppearance = true;
            this.gridView1.OptionsLayout.StoreAllOptions = true;
            this.gridView1.OptionsLayout.StoreAppearance = true;
            this.gridView1.OptionsMenu.ShowAddNewSummaryItem = DevExpress.Utils.DefaultBoolean.True;
            this.gridView1.OptionsMenu.ShowGroupSummaryEditorItem = true;
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
            // gridCol_评审单据号
            // 
            this.gridCol_评审单据号.Caption = "评审单据号";
            this.gridCol_评审单据号.FieldName = "评审单据号";
            this.gridCol_评审单据号.Name = "gridCol_评审单据号";
            this.gridCol_评审单据号.OptionsColumn.AllowEdit = false;
            // 
            // gridCol_评审单据日期
            // 
            this.gridCol_评审单据日期.Caption = "评审单据日期";
            this.gridCol_评审单据日期.FieldName = "评审单据日期";
            this.gridCol_评审单据日期.Name = "gridCol_评审单据日期";
            this.gridCol_评审单据日期.OptionsColumn.AllowEdit = false;
            this.gridCol_评审单据日期.Width = 102;
            // 
            // gridCol_帐套号
            // 
            this.gridCol_帐套号.Caption = "帐套号";
            this.gridCol_帐套号.FieldName = "帐套号";
            this.gridCol_帐套号.Name = "gridCol_帐套号";
            this.gridCol_帐套号.OptionsColumn.AllowEdit = false;
            // 
            // gridCol_销售订单号
            // 
            this.gridCol_销售订单号.Caption = "销售订单号";
            this.gridCol_销售订单号.FieldName = "销售订单号";
            this.gridCol_销售订单号.Name = "gridCol_销售订单号";
            this.gridCol_销售订单号.OptionsColumn.AllowEdit = false;
            this.gridCol_销售订单号.Visible = true;
            this.gridCol_销售订单号.VisibleIndex = 0;
            this.gridCol_销售订单号.Width = 118;
            // 
            // gridCol_单据日期
            // 
            this.gridCol_单据日期.Caption = "单据日期";
            this.gridCol_单据日期.FieldName = "单据日期";
            this.gridCol_单据日期.Name = "gridCol_单据日期";
            this.gridCol_单据日期.OptionsColumn.AllowEdit = false;
            this.gridCol_单据日期.Visible = true;
            this.gridCol_单据日期.VisibleIndex = 1;
            // 
            // gridCol_客户编码
            // 
            this.gridCol_客户编码.Caption = "客户编码";
            this.gridCol_客户编码.FieldName = "客户编码";
            this.gridCol_客户编码.Name = "gridCol_客户编码";
            this.gridCol_客户编码.OptionsColumn.AllowEdit = false;
            this.gridCol_客户编码.Visible = true;
            this.gridCol_客户编码.VisibleIndex = 2;
            // 
            // gridCol_客户简称
            // 
            this.gridCol_客户简称.Caption = "客户简称";
            this.gridCol_客户简称.FieldName = "客户简称";
            this.gridCol_客户简称.Name = "gridCol_客户简称";
            this.gridCol_客户简称.OptionsColumn.AllowEdit = false;
            this.gridCol_客户简称.Visible = true;
            this.gridCol_客户简称.VisibleIndex = 3;
            // 
            // gridCol_行号
            // 
            this.gridCol_行号.Caption = "行号";
            this.gridCol_行号.FieldName = "行号";
            this.gridCol_行号.Name = "gridCol_行号";
            this.gridCol_行号.OptionsColumn.AllowEdit = false;
            this.gridCol_行号.Visible = true;
            this.gridCol_行号.VisibleIndex = 4;
            this.gridCol_行号.Width = 45;
            // 
            // gridCol_存货编码
            // 
            this.gridCol_存货编码.Caption = "存货编码";
            this.gridCol_存货编码.FieldName = "存货编码";
            this.gridCol_存货编码.Name = "gridCol_存货编码";
            this.gridCol_存货编码.OptionsColumn.AllowEdit = false;
            this.gridCol_存货编码.Visible = true;
            this.gridCol_存货编码.VisibleIndex = 5;
            // 
            // gridCol_存货名称
            // 
            this.gridCol_存货名称.Caption = "存货名称";
            this.gridCol_存货名称.FieldName = "存货名称";
            this.gridCol_存货名称.Name = "gridCol_存货名称";
            this.gridCol_存货名称.OptionsColumn.AllowEdit = false;
            this.gridCol_存货名称.Visible = true;
            this.gridCol_存货名称.VisibleIndex = 6;
            // 
            // gridCol_规格型号
            // 
            this.gridCol_规格型号.Caption = "规格型号";
            this.gridCol_规格型号.FieldName = "规格型号";
            this.gridCol_规格型号.Name = "gridCol_规格型号";
            this.gridCol_规格型号.OptionsColumn.AllowEdit = false;
            this.gridCol_规格型号.Visible = true;
            this.gridCol_规格型号.VisibleIndex = 7;
            // 
            // gridCol_订单数量
            // 
            this.gridCol_订单数量.Caption = "订单数量";
            this.gridCol_订单数量.FieldName = "订单数量";
            this.gridCol_订单数量.Name = "gridCol_订单数量";
            this.gridCol_订单数量.OptionsColumn.AllowEdit = false;
            // 
            // gridCol_交货日期
            // 
            this.gridCol_交货日期.Caption = "交货日期";
            this.gridCol_交货日期.FieldName = "交货日期";
            this.gridCol_交货日期.Name = "gridCol_交货日期";
            this.gridCol_交货日期.OptionsColumn.AllowEdit = false;
            this.gridCol_交货日期.Visible = true;
            this.gridCol_交货日期.VisibleIndex = 9;
            // 
            // gridCol_销售订单子表ID
            // 
            this.gridCol_销售订单子表ID.Caption = "销售订单子表ID";
            this.gridCol_销售订单子表ID.FieldName = "销售订单子表ID";
            this.gridCol_销售订单子表ID.Name = "gridCol_销售订单子表ID";
            this.gridCol_销售订单子表ID.OptionsColumn.AllowEdit = false;
            this.gridCol_销售订单子表ID.Width = 91;
            // 
            // gridCol_已评审数量
            // 
            this.gridCol_已评审数量.Caption = "已评审数量";
            this.gridCol_已评审数量.FieldName = "已评审数量";
            this.gridCol_已评审数量.Name = "gridCol_已评审数量";
            this.gridCol_已评审数量.OptionsColumn.AllowEdit = false;
            // 
            // gridCol_待评审数量
            // 
            this.gridCol_待评审数量.Caption = "待评审数量";
            this.gridCol_待评审数量.FieldName = "待评审数量";
            this.gridCol_待评审数量.Name = "gridCol_待评审数量";
            this.gridCol_待评审数量.OptionsColumn.AllowEdit = false;
            // 
            // gridCol_数量
            // 
            this.gridCol_数量.Caption = "数量";
            this.gridCol_数量.FieldName = "数量";
            this.gridCol_数量.Name = "gridCol_数量";
            this.gridCol_数量.OptionsColumn.AllowEdit = false;
            this.gridCol_数量.Visible = true;
            this.gridCol_数量.VisibleIndex = 8;
            this.gridCol_数量.Width = 62;
            // 
            // gridCol_Guid
            // 
            this.gridCol_Guid.Caption = "Guid";
            this.gridCol_Guid.FieldName = "Guid";
            this.gridCol_Guid.Name = "gridCol_Guid";
            this.gridCol_Guid.OptionsColumn.AllowEdit = false;
            // 
            // gridCol_制单人
            // 
            this.gridCol_制单人.Caption = "制单人";
            this.gridCol_制单人.FieldName = "制单人";
            this.gridCol_制单人.Name = "gridCol_制单人";
            this.gridCol_制单人.OptionsColumn.AllowEdit = false;
            this.gridCol_制单人.Visible = true;
            this.gridCol_制单人.VisibleIndex = 10;
            // 
            // gridCol_制单日期
            // 
            this.gridCol_制单日期.Caption = "制单日期";
            this.gridCol_制单日期.FieldName = "制单日期";
            this.gridCol_制单日期.Name = "gridCol_制单日期";
            this.gridCol_制单日期.OptionsColumn.AllowEdit = false;
            this.gridCol_制单日期.Visible = true;
            this.gridCol_制单日期.VisibleIndex = 11;
            // 
            // gridCol_锁定人
            // 
            this.gridCol_锁定人.Caption = "锁定人";
            this.gridCol_锁定人.FieldName = "锁定人";
            this.gridCol_锁定人.Name = "gridCol_锁定人";
            this.gridCol_锁定人.OptionsColumn.AllowEdit = false;
            this.gridCol_锁定人.Visible = true;
            this.gridCol_锁定人.VisibleIndex = 12;
            // 
            // gridCol_锁定日期
            // 
            this.gridCol_锁定日期.Caption = "锁定日期";
            this.gridCol_锁定日期.FieldName = "锁定日期";
            this.gridCol_锁定日期.Name = "gridCol_锁定日期";
            this.gridCol_锁定日期.OptionsColumn.AllowEdit = false;
            this.gridCol_锁定日期.Visible = true;
            this.gridCol_锁定日期.VisibleIndex = 13;
            // 
            // gridCol_审核人
            // 
            this.gridCol_审核人.Caption = "审核人";
            this.gridCol_审核人.FieldName = "审核人";
            this.gridCol_审核人.Name = "gridCol_审核人";
            this.gridCol_审核人.OptionsColumn.AllowEdit = false;
            this.gridCol_审核人.Visible = true;
            this.gridCol_审核人.VisibleIndex = 14;
            // 
            // gridCol_审核日期
            // 
            this.gridCol_审核日期.Caption = "审核日期";
            this.gridCol_审核日期.FieldName = "审核日期";
            this.gridCol_审核日期.Name = "gridCol_审核日期";
            this.gridCol_审核日期.OptionsColumn.AllowEdit = false;
            this.gridCol_审核日期.Visible = true;
            this.gridCol_审核日期.VisibleIndex = 15;
            // 
            // gridCol_关闭人
            // 
            this.gridCol_关闭人.Caption = "关闭人";
            this.gridCol_关闭人.FieldName = "关闭人";
            this.gridCol_关闭人.Name = "gridCol_关闭人";
            this.gridCol_关闭人.OptionsColumn.AllowEdit = false;
            this.gridCol_关闭人.Visible = true;
            this.gridCol_关闭人.VisibleIndex = 16;
            // 
            // gridCol_关闭日期
            // 
            this.gridCol_关闭日期.Caption = "关闭日期";
            this.gridCol_关闭日期.FieldName = "关闭日期";
            this.gridCol_关闭日期.Name = "gridCol_关闭日期";
            this.gridCol_关闭日期.OptionsColumn.AllowEdit = false;
            this.gridCol_关闭日期.Visible = true;
            this.gridCol_关闭日期.VisibleIndex = 17;
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.gridControl评审计算);
            this.tabPage2.Location = new System.Drawing.Point(4, 23);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(1076, 213);
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
            this.ItemTextEditn2,
            this.ItemLookUpEdit产线编码,
            this.ItemLookUpEdit产线});
            this.gridControl评审计算.Size = new System.Drawing.Size(1070, 207);
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
            this.gridCol序号,
            this.gridCol级别,
            this.gridCol顶级母件编码,
            this.gridCol母件编码,
            this.gridCol母件名称,
            this.gridCol母件代号,
            this.gridCol母件规格,
            this.gridCol母件计量单位,
            this.gridCol母件损耗率,
            this.gridCol版本代号,
            this.gridCol版本说明,
            this.gridCol版本日期,
            this.gridCol状态,
            this.gridCol母件属性,
            this.gridCol变更单号,
            this.gridCol行号,
            this.gridCol子件行号,
            this.gridCol工序行号,
            this.gridCol子件编码,
            this.gridCol子件名称,
            this.gridCol子件代号,
            this.gridCol子件规格,
            this.gridCol子件计量单位,
            this.gridCol基本用量,
            this.gridCol基础用量,
            this.gridCol子件损耗率,
            this.gridCol固定用量,
            this.gridCol供应类型,
            this.gridCol单阶使用数量,
            this.gridCol加成数量,
            this.gridCol子件生效日,
            this.gridCol子件失效日,
            this.gridCol偏置期,
            this.gridCol计划比例,
            this.gridCol产出品,
            this.gridCol产出类型,
            this.gridCol成本相关,
            this.gridCol可选否,
            this.gridCol选择规则,
            this.gridCol备注,
            this.gridCol子件属性,
            this.gridCol母子关联,
            this.gridCol销售订单号,
            this.gridCol销售订单行号,
            this.gridCol销售订单子表ID,
            this.gridCol需求数量,
            this.gridCol评审数量,
            this.gridCol本单需求数量,
            this.gridCol交货日期,
            this.gridCol开始日期,
            this.gridCol结束日期,
            this.gridCol评审采购周期,
            this.gridCol评审委外周期,
            this.gridCol单件默认生产工时,
            this.gridCol默认产线,
            this.gridCol产线,
            this.gridCol质检周期,
            this.gridCol生产准备时间,
            this.gridCol经济批量,
            this.gridCol置办周期,
            this.gridCol生产合计工时,
            this.gridCol默认产线并发生产数,
            this.gridCol仓库存量,
            this.gridCol待入库数量,
            this.gridCol待出库数量,
            this.gridCol销售单号,
            this.gridCol仓库编码,
            this.gridCol仓库名称,
            this.gridCol领料部门编码,
            this.gridCol生产部门编码,
            this.gridColGUIDHead,
            this.gridColGUID,
            this.gridCol评审单据号,
            this.gridColiID,
            this.gridCol换算率});
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
            this.gridView评审计算.FocusedRowChanged += new DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventHandler(this.gridView评审计算_FocusedRowChanged);
            this.gridView评审计算.CustomDrawRowIndicator += new DevExpress.XtraGrid.Views.Grid.RowIndicatorCustomDrawEventHandler(this.gridView评审计算_CustomDrawRowIndicator);
            this.gridView评审计算.CellValueChanged += new DevExpress.XtraGrid.Views.Base.CellValueChangedEventHandler(this.gridView评审计算_CellValueChanged);
            this.gridView评审计算.RowCellStyle += new DevExpress.XtraGrid.Views.Grid.RowCellStyleEventHandler(this.gridView评审计算_RowCellStyle);
            this.gridView评审计算.DoubleClick += new System.EventHandler(this.gridView评审计算_DoubleClick);
            // 
            // gridCol序号
            // 
            this.gridCol序号.Caption = "序号";
            this.gridCol序号.FieldName = "序号";
            this.gridCol序号.Name = "gridCol序号";
            this.gridCol序号.OptionsColumn.AllowEdit = false;
            // 
            // gridCol级别
            // 
            this.gridCol级别.Caption = "级别";
            this.gridCol级别.FieldName = "级别";
            this.gridCol级别.Name = "gridCol级别";
            this.gridCol级别.OptionsColumn.AllowEdit = false;
            // 
            // gridCol顶级母件编码
            // 
            this.gridCol顶级母件编码.Caption = "顶级母件编码";
            this.gridCol顶级母件编码.FieldName = "顶级母件编码";
            this.gridCol顶级母件编码.Name = "gridCol顶级母件编码";
            this.gridCol顶级母件编码.OptionsColumn.AllowEdit = false;
            this.gridCol顶级母件编码.Visible = true;
            this.gridCol顶级母件编码.VisibleIndex = 29;
            this.gridCol顶级母件编码.Width = 99;
            // 
            // gridCol母件编码
            // 
            this.gridCol母件编码.Caption = "母件编码";
            this.gridCol母件编码.FieldName = "母件编码";
            this.gridCol母件编码.Name = "gridCol母件编码";
            this.gridCol母件编码.OptionsColumn.AllowEdit = false;
            this.gridCol母件编码.Visible = true;
            this.gridCol母件编码.VisibleIndex = 20;
            // 
            // gridCol母件名称
            // 
            this.gridCol母件名称.Caption = "母件名称";
            this.gridCol母件名称.FieldName = "母件名称";
            this.gridCol母件名称.Name = "gridCol母件名称";
            this.gridCol母件名称.OptionsColumn.AllowEdit = false;
            this.gridCol母件名称.Visible = true;
            this.gridCol母件名称.VisibleIndex = 27;
            // 
            // gridCol母件代号
            // 
            this.gridCol母件代号.Caption = "母件代号";
            this.gridCol母件代号.FieldName = "母件代号";
            this.gridCol母件代号.Name = "gridCol母件代号";
            this.gridCol母件代号.OptionsColumn.AllowEdit = false;
            // 
            // gridCol母件规格
            // 
            this.gridCol母件规格.Caption = "母件规格";
            this.gridCol母件规格.FieldName = "母件规格";
            this.gridCol母件规格.Name = "gridCol母件规格";
            this.gridCol母件规格.OptionsColumn.AllowEdit = false;
            this.gridCol母件规格.Visible = true;
            this.gridCol母件规格.VisibleIndex = 28;
            // 
            // gridCol母件计量单位
            // 
            this.gridCol母件计量单位.Caption = "母件计量单位";
            this.gridCol母件计量单位.FieldName = "母件计量单位";
            this.gridCol母件计量单位.Name = "gridCol母件计量单位";
            this.gridCol母件计量单位.OptionsColumn.AllowEdit = false;
            this.gridCol母件计量单位.Width = 93;
            // 
            // gridCol母件损耗率
            // 
            this.gridCol母件损耗率.Caption = "母件损耗率";
            this.gridCol母件损耗率.FieldName = "母件损耗率";
            this.gridCol母件损耗率.Name = "gridCol母件损耗率";
            this.gridCol母件损耗率.OptionsColumn.AllowEdit = false;
            // 
            // gridCol版本代号
            // 
            this.gridCol版本代号.Caption = "版本代号";
            this.gridCol版本代号.FieldName = "版本代号";
            this.gridCol版本代号.Name = "gridCol版本代号";
            this.gridCol版本代号.OptionsColumn.AllowEdit = false;
            // 
            // gridCol版本说明
            // 
            this.gridCol版本说明.Caption = "版本说明";
            this.gridCol版本说明.FieldName = "版本说明";
            this.gridCol版本说明.Name = "gridCol版本说明";
            this.gridCol版本说明.OptionsColumn.AllowEdit = false;
            // 
            // gridCol版本日期
            // 
            this.gridCol版本日期.Caption = "版本日期";
            this.gridCol版本日期.FieldName = "版本日期";
            this.gridCol版本日期.Name = "gridCol版本日期";
            this.gridCol版本日期.OptionsColumn.AllowEdit = false;
            // 
            // gridCol状态
            // 
            this.gridCol状态.Caption = "状态";
            this.gridCol状态.FieldName = "状态";
            this.gridCol状态.Name = "gridCol状态";
            this.gridCol状态.OptionsColumn.AllowEdit = false;
            // 
            // gridCol母件属性
            // 
            this.gridCol母件属性.Caption = "母件属性";
            this.gridCol母件属性.FieldName = "母件属性";
            this.gridCol母件属性.Name = "gridCol母件属性";
            this.gridCol母件属性.OptionsColumn.AllowEdit = false;
            this.gridCol母件属性.Visible = true;
            this.gridCol母件属性.VisibleIndex = 30;
            // 
            // gridCol变更单号
            // 
            this.gridCol变更单号.Caption = "变更单号";
            this.gridCol变更单号.FieldName = "变更单号";
            this.gridCol变更单号.Name = "gridCol变更单号";
            this.gridCol变更单号.OptionsColumn.AllowEdit = false;
            // 
            // gridCol行号
            // 
            this.gridCol行号.Caption = "行号";
            this.gridCol行号.FieldName = "行号";
            this.gridCol行号.Name = "gridCol行号";
            this.gridCol行号.OptionsColumn.AllowEdit = false;
            // 
            // gridCol子件行号
            // 
            this.gridCol子件行号.Caption = "子件行号";
            this.gridCol子件行号.FieldName = "子件行号";
            this.gridCol子件行号.Name = "gridCol子件行号";
            this.gridCol子件行号.OptionsColumn.AllowEdit = false;
            // 
            // gridCol工序行号
            // 
            this.gridCol工序行号.Caption = "工序行号";
            this.gridCol工序行号.FieldName = "工序行号";
            this.gridCol工序行号.Name = "gridCol工序行号";
            this.gridCol工序行号.OptionsColumn.AllowEdit = false;
            // 
            // gridCol子件编码
            // 
            this.gridCol子件编码.Caption = "存货编码";
            this.gridCol子件编码.FieldName = "子件编码";
            this.gridCol子件编码.Name = "gridCol子件编码";
            this.gridCol子件编码.OptionsColumn.AllowEdit = false;
            this.gridCol子件编码.Visible = true;
            this.gridCol子件编码.VisibleIndex = 0;
            this.gridCol子件编码.Width = 81;
            // 
            // gridCol子件名称
            // 
            this.gridCol子件名称.Caption = "存货名称";
            this.gridCol子件名称.FieldName = "子件名称";
            this.gridCol子件名称.Name = "gridCol子件名称";
            this.gridCol子件名称.OptionsColumn.AllowEdit = false;
            this.gridCol子件名称.Visible = true;
            this.gridCol子件名称.VisibleIndex = 1;
            this.gridCol子件名称.Width = 101;
            // 
            // gridCol子件代号
            // 
            this.gridCol子件代号.Caption = "子件代号";
            this.gridCol子件代号.FieldName = "子件代号";
            this.gridCol子件代号.Name = "gridCol子件代号";
            this.gridCol子件代号.OptionsColumn.AllowEdit = false;
            // 
            // gridCol子件规格
            // 
            this.gridCol子件规格.Caption = "存货规格";
            this.gridCol子件规格.FieldName = "子件规格";
            this.gridCol子件规格.Name = "gridCol子件规格";
            this.gridCol子件规格.OptionsColumn.AllowEdit = false;
            this.gridCol子件规格.Visible = true;
            this.gridCol子件规格.VisibleIndex = 2;
            // 
            // gridCol子件计量单位
            // 
            this.gridCol子件计量单位.Caption = "存货计量单位";
            this.gridCol子件计量单位.FieldName = "子件计量单位";
            this.gridCol子件计量单位.Name = "gridCol子件计量单位";
            this.gridCol子件计量单位.OptionsColumn.AllowEdit = false;
            this.gridCol子件计量单位.Visible = true;
            this.gridCol子件计量单位.VisibleIndex = 31;
            this.gridCol子件计量单位.Width = 95;
            // 
            // gridCol基本用量
            // 
            this.gridCol基本用量.Caption = "基本用量";
            this.gridCol基本用量.FieldName = "基本用量";
            this.gridCol基本用量.Name = "gridCol基本用量";
            this.gridCol基本用量.OptionsColumn.AllowEdit = false;
            // 
            // gridCol基础用量
            // 
            this.gridCol基础用量.Caption = "基础用量";
            this.gridCol基础用量.FieldName = "基础用量";
            this.gridCol基础用量.Name = "gridCol基础用量";
            this.gridCol基础用量.OptionsColumn.AllowEdit = false;
            // 
            // gridCol子件损耗率
            // 
            this.gridCol子件损耗率.Caption = "子件损耗率";
            this.gridCol子件损耗率.FieldName = "子件损耗率";
            this.gridCol子件损耗率.Name = "gridCol子件损耗率";
            this.gridCol子件损耗率.OptionsColumn.AllowEdit = false;
            // 
            // gridCol固定用量
            // 
            this.gridCol固定用量.Caption = "固定用量";
            this.gridCol固定用量.FieldName = "固定用量";
            this.gridCol固定用量.Name = "gridCol固定用量";
            this.gridCol固定用量.OptionsColumn.AllowEdit = false;
            // 
            // gridCol供应类型
            // 
            this.gridCol供应类型.Caption = "供应类型";
            this.gridCol供应类型.FieldName = "供应类型";
            this.gridCol供应类型.Name = "gridCol供应类型";
            this.gridCol供应类型.OptionsColumn.AllowEdit = false;
            this.gridCol供应类型.Visible = true;
            this.gridCol供应类型.VisibleIndex = 32;
            this.gridCol供应类型.Width = 63;
            // 
            // gridCol单阶使用数量
            // 
            this.gridCol单阶使用数量.Caption = "单阶使用数量";
            this.gridCol单阶使用数量.FieldName = "单阶使用数量";
            this.gridCol单阶使用数量.Name = "gridCol单阶使用数量";
            this.gridCol单阶使用数量.OptionsColumn.AllowEdit = false;
            // 
            // gridCol加成数量
            // 
            this.gridCol加成数量.Caption = "加成数量";
            this.gridCol加成数量.FieldName = "加成数量";
            this.gridCol加成数量.Name = "gridCol加成数量";
            this.gridCol加成数量.OptionsColumn.AllowEdit = false;
            this.gridCol加成数量.Visible = true;
            this.gridCol加成数量.VisibleIndex = 9;
            // 
            // gridCol子件生效日
            // 
            this.gridCol子件生效日.Caption = "子件生效日";
            this.gridCol子件生效日.FieldName = "子件生效日";
            this.gridCol子件生效日.Name = "gridCol子件生效日";
            this.gridCol子件生效日.OptionsColumn.AllowEdit = false;
            // 
            // gridCol子件失效日
            // 
            this.gridCol子件失效日.Caption = "子件失效日";
            this.gridCol子件失效日.FieldName = "子件失效日";
            this.gridCol子件失效日.Name = "gridCol子件失效日";
            this.gridCol子件失效日.OptionsColumn.AllowEdit = false;
            // 
            // gridCol偏置期
            // 
            this.gridCol偏置期.Caption = "偏置期";
            this.gridCol偏置期.FieldName = "偏置期";
            this.gridCol偏置期.Name = "gridCol偏置期";
            this.gridCol偏置期.OptionsColumn.AllowEdit = false;
            // 
            // gridCol计划比例
            // 
            this.gridCol计划比例.Caption = "计划比例";
            this.gridCol计划比例.FieldName = "计划比例";
            this.gridCol计划比例.Name = "gridCol计划比例";
            this.gridCol计划比例.OptionsColumn.AllowEdit = false;
            // 
            // gridCol产出品
            // 
            this.gridCol产出品.Caption = "产出品";
            this.gridCol产出品.FieldName = "产出品";
            this.gridCol产出品.Name = "gridCol产出品";
            this.gridCol产出品.OptionsColumn.AllowEdit = false;
            // 
            // gridCol产出类型
            // 
            this.gridCol产出类型.Caption = "产出类型";
            this.gridCol产出类型.FieldName = "产出类型";
            this.gridCol产出类型.Name = "gridCol产出类型";
            this.gridCol产出类型.OptionsColumn.AllowEdit = false;
            // 
            // gridCol成本相关
            // 
            this.gridCol成本相关.Caption = "成本相关";
            this.gridCol成本相关.FieldName = "成本相关";
            this.gridCol成本相关.Name = "gridCol成本相关";
            this.gridCol成本相关.OptionsColumn.AllowEdit = false;
            // 
            // gridCol可选否
            // 
            this.gridCol可选否.Caption = "可选否";
            this.gridCol可选否.FieldName = "可选否";
            this.gridCol可选否.Name = "gridCol可选否";
            this.gridCol可选否.OptionsColumn.AllowEdit = false;
            // 
            // gridCol选择规则
            // 
            this.gridCol选择规则.Caption = "选择规则";
            this.gridCol选择规则.FieldName = "选择规则";
            this.gridCol选择规则.Name = "gridCol选择规则";
            this.gridCol选择规则.OptionsColumn.AllowEdit = false;
            // 
            // gridCol备注
            // 
            this.gridCol备注.Caption = "备注";
            this.gridCol备注.FieldName = "备注";
            this.gridCol备注.Name = "gridCol备注";
            this.gridCol备注.OptionsColumn.AllowEdit = false;
            this.gridCol备注.Visible = true;
            this.gridCol备注.VisibleIndex = 35;
            // 
            // gridCol子件属性
            // 
            this.gridCol子件属性.Caption = "存货属性";
            this.gridCol子件属性.FieldName = "子件属性";
            this.gridCol子件属性.Name = "gridCol子件属性";
            this.gridCol子件属性.OptionsColumn.AllowEdit = false;
            this.gridCol子件属性.Visible = true;
            this.gridCol子件属性.VisibleIndex = 6;
            this.gridCol子件属性.Width = 62;
            // 
            // gridCol母子关联
            // 
            this.gridCol母子关联.Caption = "母子关联";
            this.gridCol母子关联.FieldName = "母子关联";
            this.gridCol母子关联.Name = "gridCol母子关联";
            this.gridCol母子关联.OptionsColumn.AllowEdit = false;
            this.gridCol母子关联.Visible = true;
            this.gridCol母子关联.VisibleIndex = 21;
            this.gridCol母子关联.Width = 113;
            // 
            // gridCol销售订单号
            // 
            this.gridCol销售订单号.Caption = "销售订单号";
            this.gridCol销售订单号.FieldName = "销售订单号";
            this.gridCol销售订单号.Name = "gridCol销售订单号";
            this.gridCol销售订单号.OptionsColumn.AllowEdit = false;
            this.gridCol销售订单号.Visible = true;
            this.gridCol销售订单号.VisibleIndex = 33;
            // 
            // gridCol销售订单行号
            // 
            this.gridCol销售订单行号.Caption = "销售订单行号";
            this.gridCol销售订单行号.FieldName = "销售订单行号";
            this.gridCol销售订单行号.Name = "gridCol销售订单行号";
            this.gridCol销售订单行号.OptionsColumn.AllowEdit = false;
            this.gridCol销售订单行号.Visible = true;
            this.gridCol销售订单行号.VisibleIndex = 34;
            this.gridCol销售订单行号.Width = 98;
            // 
            // gridCol销售订单子表ID
            // 
            this.gridCol销售订单子表ID.Caption = "销售订单子表ID";
            this.gridCol销售订单子表ID.FieldName = "销售订单子表ID";
            this.gridCol销售订单子表ID.Name = "gridCol销售订单子表ID";
            this.gridCol销售订单子表ID.OptionsColumn.AllowEdit = false;
            this.gridCol销售订单子表ID.Visible = true;
            this.gridCol销售订单子表ID.VisibleIndex = 36;
            this.gridCol销售订单子表ID.Width = 103;
            // 
            // gridCol需求数量
            // 
            this.gridCol需求数量.Caption = "需求数量";
            this.gridCol需求数量.ColumnEdit = this.ItemTextEditn2;
            this.gridCol需求数量.FieldName = "需求数量";
            this.gridCol需求数量.Name = "gridCol需求数量";
            this.gridCol需求数量.OptionsColumn.AllowEdit = false;
            this.gridCol需求数量.Summary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] {
            new DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum)});
            this.gridCol需求数量.Visible = true;
            this.gridCol需求数量.VisibleIndex = 4;
            this.gridCol需求数量.Width = 74;
            // 
            // ItemTextEditn2
            // 
            this.ItemTextEditn2.AutoHeight = false;
            this.ItemTextEditn2.DisplayFormat.FormatString = "n2";
            this.ItemTextEditn2.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.ItemTextEditn2.EditFormat.FormatString = "n2";
            this.ItemTextEditn2.EditFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.ItemTextEditn2.Mask.EditMask = "n2";
            this.ItemTextEditn2.Name = "ItemTextEditn2";
            // 
            // gridCol评审数量
            // 
            this.gridCol评审数量.Caption = "评审数量";
            this.gridCol评审数量.ColumnEdit = this.ItemTextEditn2;
            this.gridCol评审数量.FieldName = "评审数量";
            this.gridCol评审数量.Name = "gridCol评审数量";
            this.gridCol评审数量.OptionsColumn.AllowEdit = false;
            this.gridCol评审数量.Summary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] {
            new DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum)});
            this.gridCol评审数量.Visible = true;
            this.gridCol评审数量.VisibleIndex = 3;
            // 
            // gridCol本单需求数量
            // 
            this.gridCol本单需求数量.Caption = "本单需求数量";
            this.gridCol本单需求数量.ColumnEdit = this.ItemTextEditn2;
            this.gridCol本单需求数量.FieldName = "本单需求数量";
            this.gridCol本单需求数量.Name = "gridCol本单需求数量";
            this.gridCol本单需求数量.Summary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] {
            new DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum)});
            this.gridCol本单需求数量.Visible = true;
            this.gridCol本单需求数量.VisibleIndex = 5;
            this.gridCol本单需求数量.Width = 98;
            // 
            // gridCol交货日期
            // 
            this.gridCol交货日期.Caption = "交货日期";
            this.gridCol交货日期.FieldName = "交货日期";
            this.gridCol交货日期.Name = "gridCol交货日期";
            this.gridCol交货日期.OptionsColumn.AllowEdit = false;
            this.gridCol交货日期.Visible = true;
            this.gridCol交货日期.VisibleIndex = 37;
            // 
            // gridCol开始日期
            // 
            this.gridCol开始日期.Caption = "开始日期";
            this.gridCol开始日期.FieldName = "开始日期";
            this.gridCol开始日期.Name = "gridCol开始日期";
            this.gridCol开始日期.Visible = true;
            this.gridCol开始日期.VisibleIndex = 7;
            // 
            // gridCol结束日期
            // 
            this.gridCol结束日期.Caption = "完成日期";
            this.gridCol结束日期.FieldName = "结束日期";
            this.gridCol结束日期.Name = "gridCol结束日期";
            this.gridCol结束日期.Visible = true;
            this.gridCol结束日期.VisibleIndex = 8;
            this.gridCol结束日期.Width = 89;
            // 
            // gridCol评审采购周期
            // 
            this.gridCol评审采购周期.Caption = "评审采购周期";
            this.gridCol评审采购周期.FieldName = "评审采购周期";
            this.gridCol评审采购周期.Name = "gridCol评审采购周期";
            this.gridCol评审采购周期.OptionsColumn.AllowEdit = false;
            this.gridCol评审采购周期.Summary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] {
            new DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum)});
            this.gridCol评审采购周期.Visible = true;
            this.gridCol评审采购周期.VisibleIndex = 22;
            this.gridCol评审采购周期.Width = 92;
            // 
            // gridCol评审委外周期
            // 
            this.gridCol评审委外周期.Caption = "评审委外周期";
            this.gridCol评审委外周期.FieldName = "评审委外周期";
            this.gridCol评审委外周期.Name = "gridCol评审委外周期";
            this.gridCol评审委外周期.OptionsColumn.AllowEdit = false;
            this.gridCol评审委外周期.Summary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] {
            new DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum)});
            this.gridCol评审委外周期.Visible = true;
            this.gridCol评审委外周期.VisibleIndex = 23;
            this.gridCol评审委外周期.Width = 91;
            // 
            // gridCol单件默认生产工时
            // 
            this.gridCol单件默认生产工时.Caption = "单件默认生产工时";
            this.gridCol单件默认生产工时.FieldName = "单件默认生产工时";
            this.gridCol单件默认生产工时.Name = "gridCol单件默认生产工时";
            this.gridCol单件默认生产工时.Summary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] {
            new DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum)});
            this.gridCol单件默认生产工时.Visible = true;
            this.gridCol单件默认生产工时.VisibleIndex = 24;
            this.gridCol单件默认生产工时.Width = 116;
            // 
            // gridCol默认产线
            // 
            this.gridCol默认产线.Caption = "产线编码";
            this.gridCol默认产线.ColumnEdit = this.ItemLookUpEdit产线编码;
            this.gridCol默认产线.FieldName = "默认产线";
            this.gridCol默认产线.Name = "gridCol默认产线";
            this.gridCol默认产线.OptionsColumn.AllowEdit = false;
            this.gridCol默认产线.Visible = true;
            this.gridCol默认产线.VisibleIndex = 14;
            // 
            // ItemLookUpEdit产线编码
            // 
            this.ItemLookUpEdit产线编码.AutoHeight = false;
            this.ItemLookUpEdit产线编码.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.ItemLookUpEdit产线编码.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("LineNO", "产线编码"),
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("LineName", "产线")});
            this.ItemLookUpEdit产线编码.DisplayMember = "LineNo";
            this.ItemLookUpEdit产线编码.Name = "ItemLookUpEdit产线编码";
            this.ItemLookUpEdit产线编码.NullText = "";
            this.ItemLookUpEdit产线编码.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.Standard;
            this.ItemLookUpEdit产线编码.ValueMember = "LineNo";
            // 
            // gridCol产线
            // 
            this.gridCol产线.Caption = "产线";
            this.gridCol产线.ColumnEdit = this.ItemLookUpEdit产线;
            this.gridCol产线.FieldName = "默认产线";
            this.gridCol产线.Name = "gridCol产线";
            this.gridCol产线.OptionsColumn.AllowEdit = false;
            this.gridCol产线.Visible = true;
            this.gridCol产线.VisibleIndex = 15;
            this.gridCol产线.Width = 161;
            // 
            // ItemLookUpEdit产线
            // 
            this.ItemLookUpEdit产线.AutoHeight = false;
            this.ItemLookUpEdit产线.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.ItemLookUpEdit产线.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("LineNo", "产线编码"),
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("LineName", "产线")});
            this.ItemLookUpEdit产线.DisplayMember = "LineName";
            this.ItemLookUpEdit产线.Name = "ItemLookUpEdit产线";
            this.ItemLookUpEdit产线.NullText = "";
            this.ItemLookUpEdit产线.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.Standard;
            this.ItemLookUpEdit产线.ValueMember = "LineNo";
            // 
            // gridCol质检周期
            // 
            this.gridCol质检周期.Caption = "质检周期";
            this.gridCol质检周期.FieldName = "质检周期";
            this.gridCol质检周期.Name = "gridCol质检周期";
            this.gridCol质检周期.OptionsColumn.AllowEdit = false;
            this.gridCol质检周期.Summary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] {
            new DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum)});
            this.gridCol质检周期.Visible = true;
            this.gridCol质检周期.VisibleIndex = 17;
            // 
            // gridCol生产准备时间
            // 
            this.gridCol生产准备时间.Caption = "生产准备时间";
            this.gridCol生产准备时间.FieldName = "生产准备时间";
            this.gridCol生产准备时间.Name = "gridCol生产准备时间";
            this.gridCol生产准备时间.OptionsColumn.AllowEdit = false;
            this.gridCol生产准备时间.Summary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] {
            new DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum)});
            this.gridCol生产准备时间.Visible = true;
            this.gridCol生产准备时间.VisibleIndex = 18;
            this.gridCol生产准备时间.Width = 89;
            // 
            // gridCol经济批量
            // 
            this.gridCol经济批量.Caption = "经济批量";
            this.gridCol经济批量.ColumnEdit = this.ItemTextEditn2;
            this.gridCol经济批量.FieldName = "经济批量";
            this.gridCol经济批量.Name = "gridCol经济批量";
            this.gridCol经济批量.OptionsColumn.AllowEdit = false;
            this.gridCol经济批量.Summary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] {
            new DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum)});
            this.gridCol经济批量.Visible = true;
            this.gridCol经济批量.VisibleIndex = 10;
            // 
            // gridCol置办周期
            // 
            this.gridCol置办周期.Caption = "置办周期";
            this.gridCol置办周期.FieldName = "置办周期";
            this.gridCol置办周期.Name = "gridCol置办周期";
            this.gridCol置办周期.Summary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] {
            new DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum)});
            this.gridCol置办周期.Visible = true;
            this.gridCol置办周期.VisibleIndex = 16;
            // 
            // gridCol生产合计工时
            // 
            this.gridCol生产合计工时.Caption = "生产合计工时";
            this.gridCol生产合计工时.FieldName = "生产合计工时";
            this.gridCol生产合计工时.Name = "gridCol生产合计工时";
            this.gridCol生产合计工时.OptionsColumn.AllowEdit = false;
            this.gridCol生产合计工时.Visible = true;
            this.gridCol生产合计工时.VisibleIndex = 25;
            this.gridCol生产合计工时.Width = 98;
            // 
            // gridCol默认产线并发生产数
            // 
            this.gridCol默认产线并发生产数.Caption = "人数";
            this.gridCol默认产线并发生产数.FieldName = "默认产线并发生产数";
            this.gridCol默认产线并发生产数.Name = "gridCol默认产线并发生产数";
            this.gridCol默认产线并发生产数.Visible = true;
            this.gridCol默认产线并发生产数.VisibleIndex = 26;
            this.gridCol默认产线并发生产数.Width = 42;
            // 
            // gridCol仓库存量
            // 
            this.gridCol仓库存量.Caption = "仓库存量";
            this.gridCol仓库存量.ColumnEdit = this.ItemTextEditn2;
            this.gridCol仓库存量.FieldName = "仓库存量";
            this.gridCol仓库存量.Name = "gridCol仓库存量";
            this.gridCol仓库存量.OptionsColumn.AllowEdit = false;
            this.gridCol仓库存量.Visible = true;
            this.gridCol仓库存量.VisibleIndex = 11;
            // 
            // gridCol待入库数量
            // 
            this.gridCol待入库数量.Caption = "待入库数量";
            this.gridCol待入库数量.ColumnEdit = this.ItemTextEditn2;
            this.gridCol待入库数量.FieldName = "待入库数量";
            this.gridCol待入库数量.Name = "gridCol待入库数量";
            this.gridCol待入库数量.OptionsColumn.AllowEdit = false;
            this.gridCol待入库数量.Visible = true;
            this.gridCol待入库数量.VisibleIndex = 12;
            // 
            // gridCol待出库数量
            // 
            this.gridCol待出库数量.Caption = "待出库数量";
            this.gridCol待出库数量.ColumnEdit = this.ItemTextEditn2;
            this.gridCol待出库数量.FieldName = "待出库数量";
            this.gridCol待出库数量.Name = "gridCol待出库数量";
            this.gridCol待出库数量.OptionsColumn.AllowEdit = false;
            this.gridCol待出库数量.Visible = true;
            this.gridCol待出库数量.VisibleIndex = 13;
            // 
            // gridCol销售单号
            // 
            this.gridCol销售单号.Caption = "销售单号";
            this.gridCol销售单号.FieldName = "销售单号";
            this.gridCol销售单号.Name = "gridCol销售单号";
            this.gridCol销售单号.OptionsColumn.AllowEdit = false;
            this.gridCol销售单号.Visible = true;
            this.gridCol销售单号.VisibleIndex = 19;
            this.gridCol销售单号.Width = 114;
            // 
            // gridCol仓库编码
            // 
            this.gridCol仓库编码.Caption = "仓库编码";
            this.gridCol仓库编码.FieldName = "仓库编码";
            this.gridCol仓库编码.Name = "gridCol仓库编码";
            this.gridCol仓库编码.OptionsColumn.AllowEdit = false;
            this.gridCol仓库编码.Visible = true;
            this.gridCol仓库编码.VisibleIndex = 38;
            // 
            // gridCol仓库名称
            // 
            this.gridCol仓库名称.Caption = "仓库名称";
            this.gridCol仓库名称.FieldName = "仓库名称";
            this.gridCol仓库名称.Name = "gridCol仓库名称";
            this.gridCol仓库名称.OptionsColumn.AllowEdit = false;
            this.gridCol仓库名称.Visible = true;
            this.gridCol仓库名称.VisibleIndex = 39;
            // 
            // gridCol领料部门编码
            // 
            this.gridCol领料部门编码.Caption = "领料部门编码";
            this.gridCol领料部门编码.FieldName = "领料部门编码";
            this.gridCol领料部门编码.Name = "gridCol领料部门编码";
            this.gridCol领料部门编码.OptionsColumn.AllowEdit = false;
            this.gridCol领料部门编码.Visible = true;
            this.gridCol领料部门编码.VisibleIndex = 40;
            // 
            // gridCol生产部门编码
            // 
            this.gridCol生产部门编码.Caption = "生产部门编码";
            this.gridCol生产部门编码.FieldName = "生产部门编码";
            this.gridCol生产部门编码.Name = "gridCol生产部门编码";
            this.gridCol生产部门编码.OptionsColumn.AllowEdit = false;
            this.gridCol生产部门编码.Visible = true;
            this.gridCol生产部门编码.VisibleIndex = 41;
            // 
            // gridColGUIDHead
            // 
            this.gridColGUIDHead.Caption = "GUIDHead";
            this.gridColGUIDHead.FieldName = "GUIDHead";
            this.gridColGUIDHead.Name = "gridColGUIDHead";
            this.gridColGUIDHead.OptionsColumn.AllowEdit = false;
            this.gridColGUIDHead.Visible = true;
            this.gridColGUIDHead.VisibleIndex = 42;
            // 
            // gridColGUID
            // 
            this.gridColGUID.Caption = "GUID";
            this.gridColGUID.FieldName = "GUID";
            this.gridColGUID.Name = "gridColGUID";
            this.gridColGUID.OptionsColumn.AllowEdit = false;
            this.gridColGUID.Visible = true;
            this.gridColGUID.VisibleIndex = 43;
            // 
            // gridCol评审单据号
            // 
            this.gridCol评审单据号.Caption = "评审单据号";
            this.gridCol评审单据号.FieldName = "评审单据号";
            this.gridCol评审单据号.Name = "gridCol评审单据号";
            this.gridCol评审单据号.OptionsColumn.AllowEdit = false;
            this.gridCol评审单据号.Visible = true;
            this.gridCol评审单据号.VisibleIndex = 44;
            // 
            // gridColiID
            // 
            this.gridColiID.Caption = "iID";
            this.gridColiID.FieldName = "iID";
            this.gridColiID.Name = "gridColiID";
            this.gridColiID.OptionsColumn.AllowEdit = false;
            this.gridColiID.Visible = true;
            this.gridColiID.VisibleIndex = 45;
            // 
            // gridCol换算率
            // 
            this.gridCol换算率.Caption = "换算率";
            this.gridCol换算率.FieldName = "换算率";
            this.gridCol换算率.Name = "gridCol换算率";
            this.gridCol换算率.OptionsColumn.AllowEdit = false;
            this.gridCol换算率.Visible = true;
            this.gridCol换算率.VisibleIndex = 46;
            // 
            // txt制单人
            // 
            this.txt制单人.Enabled = false;
            this.txt制单人.Location = new System.Drawing.Point(64, 333);
            this.txt制单人.Name = "txt制单人";
            this.txt制单人.Size = new System.Drawing.Size(116, 20);
            this.txt制单人.StyleController = this.layoutControl1;
            this.txt制单人.TabIndex = 53;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.dateEditNow);
            this.groupBox1.Controls.Add(this.btn日期顺推);
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
            this.groupBox1.Location = new System.Drawing.Point(12, 36);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(1084, 49);
            this.groupBox1.TabIndex = 41;
            this.groupBox1.TabStop = false;
            // 
            // dateEditNow
            // 
            this.dateEditNow.EditValue = null;
            this.dateEditNow.Enabled = false;
            this.dateEditNow.Location = new System.Drawing.Point(164, 17);
            this.dateEditNow.Name = "dateEditNow";
            this.dateEditNow.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.dateEditNow.Properties.VistaTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
            this.dateEditNow.Size = new System.Drawing.Size(100, 20);
            this.dateEditNow.TabIndex = 64;
            // 
            // btn日期顺推
            // 
            this.btn日期顺推.Enabled = false;
            this.btn日期顺推.Location = new System.Drawing.Point(270, 16);
            this.btn日期顺推.Name = "btn日期顺推";
            this.btn日期顺推.Size = new System.Drawing.Size(83, 23);
            this.btn日期顺推.TabIndex = 63;
            this.btn日期顺推.Text = "采购件顺推";
            this.btn日期顺推.UseVisualStyleBackColor = true;
            this.btn日期顺推.Click += new System.EventHandler(this.btn日期顺推_Click);
            // 
            // dtm完成日期
            // 
            this.dtm完成日期.EditValue = null;
            this.dtm完成日期.Enabled = false;
            this.dtm完成日期.Location = new System.Drawing.Point(879, 22);
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
            this.chk完成日期.Location = new System.Drawing.Point(808, 23);
            this.chk完成日期.Name = "chk完成日期";
            this.chk完成日期.Size = new System.Drawing.Size(74, 18);
            this.chk完成日期.TabIndex = 61;
            this.chk完成日期.Text = "完成日期";
            this.chk完成日期.UseVisualStyleBackColor = true;
            this.chk完成日期.CheckedChanged += new System.EventHandler(this.chk完成日期_CheckedChanged);
            // 
            // dtm开始日期
            // 
            this.dtm开始日期.EditValue = null;
            this.dtm开始日期.Enabled = false;
            this.dtm开始日期.Location = new System.Drawing.Point(690, 22);
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
            this.chk开始日期.Location = new System.Drawing.Point(619, 23);
            this.chk开始日期.Name = "chk开始日期";
            this.chk开始日期.Size = new System.Drawing.Size(74, 18);
            this.chk开始日期.TabIndex = 59;
            this.chk开始日期.Text = "开始日期";
            this.chk开始日期.UseVisualStyleBackColor = true;
            this.chk开始日期.CheckedChanged += new System.EventHandler(this.chk开始日期_CheckedChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(452, 23);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(55, 14);
            this.label1.TabIndex = 57;
            this.label1.Text = "存货编码";
            // 
            // txt存货编码
            // 
            this.txt存货编码.Enabled = false;
            this.txt存货编码.Location = new System.Drawing.Point(513, 20);
            this.txt存货编码.Name = "txt存货编码";
            this.txt存货编码.Size = new System.Drawing.Size(100, 20);
            this.txt存货编码.TabIndex = 56;
            // 
            // btnChange
            // 
            this.btnChange.Enabled = false;
            this.btnChange.Location = new System.Drawing.Point(991, 20);
            this.btnChange.Name = "btnChange";
            this.btnChange.Size = new System.Drawing.Size(75, 23);
            this.btnChange.TabIndex = 55;
            this.btnChange.Text = "批改";
            this.btnChange.UseVisualStyleBackColor = true;
            // 
            // radio手工
            // 
            this.radio手工.AutoSize = true;
            this.radio手工.Enabled = false;
            this.radio手工.ForeColor = System.Drawing.Color.Blue;
            this.radio手工.Location = new System.Drawing.Point(359, 18);
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
            this.radio逆排.Location = new System.Drawing.Point(6, 18);
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
            this.radio顺排.Location = new System.Drawing.Point(85, 18);
            this.radio顺排.Name = "radio顺排";
            this.radio顺排.Size = new System.Drawing.Size(73, 18);
            this.radio顺排.TabIndex = 38;
            this.radio顺排.Text = "顺推排程";
            this.radio顺排.UseVisualStyleBackColor = true;
            this.radio顺排.CheckedChanged += new System.EventHandler(this.radio_CheckedChanged);
            // 
            // layoutControlGroup1
            // 
            this.layoutControlGroup1.CustomizationFormText = "layoutControlGroup1";
            this.layoutControlGroup1.EnableIndentsWithoutBorders = DevExpress.Utils.DefaultBoolean.True;
            this.layoutControlGroup1.GroupBordersVisible = false;
            this.layoutControlGroup1.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.layoutControlItem29,
            this.layoutControlItem3,
            this.layoutControlItem8,
            this.layoutControlItem9,
            this.layoutControlItem10,
            this.layoutControlItem11,
            this.layoutControlItem12,
            this.layoutControlItem13,
            this.layoutControlItem1,
            this.emptySpaceItem1,
            this.layoutControlItem2});
            this.layoutControlGroup1.Location = new System.Drawing.Point(0, 0);
            this.layoutControlGroup1.Name = "Root";
            this.layoutControlGroup1.Size = new System.Drawing.Size(1108, 365);
            this.layoutControlGroup1.Text = "Root";
            this.layoutControlGroup1.TextVisible = false;
            // 
            // layoutControlItem29
            // 
            this.layoutControlItem29.Control = this.groupBox1;
            this.layoutControlItem29.CustomizationFormText = "排程方式";
            this.layoutControlItem29.Location = new System.Drawing.Point(0, 24);
            this.layoutControlItem29.MaxSize = new System.Drawing.Size(0, 53);
            this.layoutControlItem29.MinSize = new System.Drawing.Size(104, 53);
            this.layoutControlItem29.Name = "layoutControlItem29";
            this.layoutControlItem29.Size = new System.Drawing.Size(1088, 53);
            this.layoutControlItem29.SizeConstraintsType = DevExpress.XtraLayout.SizeConstraintsType.Custom;
            this.layoutControlItem29.Text = "排程方式";
            this.layoutControlItem29.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem29.TextToControlDistance = 0;
            this.layoutControlItem29.TextVisible = false;
            // 
            // layoutControlItem3
            // 
            this.layoutControlItem3.Control = this.tabControl1;
            this.layoutControlItem3.CustomizationFormText = "layoutControlItem3";
            this.layoutControlItem3.Location = new System.Drawing.Point(0, 77);
            this.layoutControlItem3.Name = "layoutControlItem3";
            this.layoutControlItem3.Size = new System.Drawing.Size(1088, 244);
            this.layoutControlItem3.Text = "layoutControlItem3";
            this.layoutControlItem3.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem3.TextToControlDistance = 0;
            this.layoutControlItem3.TextVisible = false;
            // 
            // layoutControlItem8
            // 
            this.layoutControlItem8.Control = this.txt制单人;
            this.layoutControlItem8.CustomizationFormText = "制单人";
            this.layoutControlItem8.Location = new System.Drawing.Point(0, 321);
            this.layoutControlItem8.Name = "layoutControlItem8";
            this.layoutControlItem8.Size = new System.Drawing.Size(172, 24);
            this.layoutControlItem8.Text = "制单人";
            this.layoutControlItem8.TextSize = new System.Drawing.Size(48, 14);
            // 
            // layoutControlItem9
            // 
            this.layoutControlItem9.Control = this.dtm制单日期;
            this.layoutControlItem9.CustomizationFormText = "制单日期";
            this.layoutControlItem9.Location = new System.Drawing.Point(172, 321);
            this.layoutControlItem9.Name = "layoutControlItem9";
            this.layoutControlItem9.Size = new System.Drawing.Size(170, 24);
            this.layoutControlItem9.Text = "制单日期";
            this.layoutControlItem9.TextSize = new System.Drawing.Size(48, 14);
            // 
            // layoutControlItem10
            // 
            this.layoutControlItem10.Control = this.txt审核人;
            this.layoutControlItem10.CustomizationFormText = "审核人";
            this.layoutControlItem10.Location = new System.Drawing.Point(342, 321);
            this.layoutControlItem10.Name = "layoutControlItem10";
            this.layoutControlItem10.Size = new System.Drawing.Size(169, 24);
            this.layoutControlItem10.Text = "审核人";
            this.layoutControlItem10.TextSize = new System.Drawing.Size(48, 14);
            // 
            // layoutControlItem11
            // 
            this.layoutControlItem11.Control = this.dtm审核日期;
            this.layoutControlItem11.CustomizationFormText = "审核日期";
            this.layoutControlItem11.Location = new System.Drawing.Point(511, 321);
            this.layoutControlItem11.Name = "layoutControlItem11";
            this.layoutControlItem11.Size = new System.Drawing.Size(199, 24);
            this.layoutControlItem11.Text = "审核日期";
            this.layoutControlItem11.TextSize = new System.Drawing.Size(48, 14);
            // 
            // layoutControlItem12
            // 
            this.layoutControlItem12.Control = this.txt关闭人;
            this.layoutControlItem12.CustomizationFormText = "关闭人";
            this.layoutControlItem12.Location = new System.Drawing.Point(710, 321);
            this.layoutControlItem12.Name = "layoutControlItem12";
            this.layoutControlItem12.Size = new System.Drawing.Size(182, 24);
            this.layoutControlItem12.Text = "关闭人";
            this.layoutControlItem12.TextSize = new System.Drawing.Size(48, 14);
            // 
            // layoutControlItem13
            // 
            this.layoutControlItem13.Control = this.dtm关闭日期;
            this.layoutControlItem13.CustomizationFormText = "关闭日期";
            this.layoutControlItem13.Location = new System.Drawing.Point(892, 321);
            this.layoutControlItem13.Name = "layoutControlItem13";
            this.layoutControlItem13.Size = new System.Drawing.Size(196, 24);
            this.layoutControlItem13.Text = "关闭日期";
            this.layoutControlItem13.TextSize = new System.Drawing.Size(48, 14);
            // 
            // layoutControlItem1
            // 
            this.layoutControlItem1.Control = this.textEdit单据号;
            this.layoutControlItem1.CustomizationFormText = "单据号";
            this.layoutControlItem1.Location = new System.Drawing.Point(0, 0);
            this.layoutControlItem1.Name = "layoutControlItem1";
            this.layoutControlItem1.Size = new System.Drawing.Size(165, 24);
            this.layoutControlItem1.Text = "单据号";
            this.layoutControlItem1.TextSize = new System.Drawing.Size(48, 14);
            // 
            // emptySpaceItem1
            // 
            this.emptySpaceItem1.AllowHotTrack = false;
            this.emptySpaceItem1.CustomizationFormText = "emptySpaceItem1";
            this.emptySpaceItem1.Location = new System.Drawing.Point(310, 0);
            this.emptySpaceItem1.Name = "emptySpaceItem1";
            this.emptySpaceItem1.Size = new System.Drawing.Size(778, 24);
            this.emptySpaceItem1.Text = "emptySpaceItem1";
            this.emptySpaceItem1.TextSize = new System.Drawing.Size(0, 0);
            // 
            // layoutControlItem2
            // 
            this.layoutControlItem2.Control = this.dtm单据日期;
            this.layoutControlItem2.CustomizationFormText = "单据日期";
            this.layoutControlItem2.Location = new System.Drawing.Point(165, 0);
            this.layoutControlItem2.Name = "layoutControlItem2";
            this.layoutControlItem2.Size = new System.Drawing.Size(145, 24);
            this.layoutControlItem2.Text = "单据日期";
            this.layoutControlItem2.TextSize = new System.Drawing.Size(48, 14);
            // 
            // Frm订单评审
            // 
            this.Appearance.BackColor = System.Drawing.SystemColors.Control;
            this.Appearance.Options.UseBackColor = true;
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1106, 394);
            this.Controls.Add(this.layoutControl1);
            this.Name = "Frm订单评审";
            this.Text = "订单评审";
            this.Load += new System.EventHandler(this.Frm订单评审运算_Load);
            this.Controls.SetChildIndex(this.layoutControl1, 0);
            ((System.ComponentModel.ISupportInitialize)(this.dsPrint)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dsForm)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtSel)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControl1)).EndInit();
            this.layoutControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dtm单据日期.Properties.VistaTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtm单据日期.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.textEdit单据号.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtm关闭日期.Properties.VistaTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtm关闭日期.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txt关闭人.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txt审核人.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtm制单日期.Properties.VistaTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtm制单日期.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtm审核日期.Properties.VistaTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtm审核日期.Properties)).EndInit();
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).EndInit();
            this.tabPage2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gridControl评审计算)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView评审计算)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ItemTextEditn2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ItemLookUpEdit产线编码)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ItemLookUpEdit产线)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txt制单人.Properties)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dateEditNow.Properties.VistaTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dateEditNow.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtm完成日期.Properties.VistaTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtm完成日期.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtm开始日期.Properties.VistaTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtm开始日期.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txt存货编码.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem29)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem8)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem9)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem10)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem11)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem12)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem13)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem2)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraLayout.LayoutControl layoutControl1;
        private DevExpress.XtraLayout.LayoutControlGroup layoutControlGroup1;
        private System.Windows.Forms.RadioButton radio逆排;
        private System.Windows.Forms.RadioButton radio顺排;
        private System.Windows.Forms.GroupBox groupBox1;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem29;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
        private DevExpress.XtraGrid.GridControl gridControl评审计算;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView评审计算;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem3;
        private DevExpress.XtraEditors.TextEdit txt制单人;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem8;
        private DevExpress.XtraEditors.DateEdit dtm制单日期;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem9;
        private DevExpress.XtraEditors.DateEdit dtm关闭日期;
        private DevExpress.XtraEditors.TextEdit txt关闭人;
        private DevExpress.XtraEditors.TextEdit txt审核人;
        private DevExpress.XtraEditors.DateEdit dtm审核日期;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem10;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem11;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem12;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem13;
        private System.Windows.Forms.RadioButton radio手工;
        private DevExpress.XtraEditors.DateEdit dtm完成日期;
        private System.Windows.Forms.CheckBox chk完成日期;
        private DevExpress.XtraEditors.DateEdit dtm开始日期;
        private System.Windows.Forms.CheckBox chk开始日期;
        private System.Windows.Forms.Label label1;
        private DevExpress.XtraEditors.TextEdit txt存货编码;
        private System.Windows.Forms.Button btnChange;
        private DevExpress.XtraEditors.TextEdit textEdit单据号;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem1;
        private DevExpress.XtraLayout.EmptySpaceItem emptySpaceItem1;
        private DevExpress.XtraGrid.GridControl gridControl1;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView1;
        private DevExpress.XtraGrid.Columns.GridColumn gridCol_销售订单号;
        private DevExpress.XtraGrid.Columns.GridColumn gridCol_单据日期;
        private DevExpress.XtraGrid.Columns.GridColumn gridCol_客户编码;
        private DevExpress.XtraGrid.Columns.GridColumn gridCol_客户简称;
        private DevExpress.XtraGrid.Columns.GridColumn gridCol_存货编码;
        private DevExpress.XtraGrid.Columns.GridColumn gridCol_存货名称;
        private DevExpress.XtraGrid.Columns.GridColumn gridCol_规格型号;
        private DevExpress.XtraGrid.Columns.GridColumn gridCol_订单数量;
        private DevExpress.XtraGrid.Columns.GridColumn gridCol_交货日期;
        private DevExpress.XtraGrid.Columns.GridColumn gridCol_销售订单子表ID;
        private DevExpress.XtraGrid.Columns.GridColumn gridCol_已评审数量;
        private DevExpress.XtraGrid.Columns.GridColumn gridCol_待评审数量;
        private DevExpress.XtraGrid.Columns.GridColumn gridCol_行号;
        private DevExpress.XtraGrid.Columns.GridColumn gridCol序号;
        private DevExpress.XtraGrid.Columns.GridColumn gridCol级别;
        private DevExpress.XtraGrid.Columns.GridColumn gridCol顶级母件编码;
        private DevExpress.XtraGrid.Columns.GridColumn gridCol母件编码;
        private DevExpress.XtraGrid.Columns.GridColumn gridCol母件名称;
        private DevExpress.XtraGrid.Columns.GridColumn gridCol母件代号;
        private DevExpress.XtraGrid.Columns.GridColumn gridCol母件规格;
        private DevExpress.XtraGrid.Columns.GridColumn gridCol母件计量单位;
        private DevExpress.XtraGrid.Columns.GridColumn gridCol母件损耗率;
        private DevExpress.XtraGrid.Columns.GridColumn gridCol版本代号;
        private DevExpress.XtraGrid.Columns.GridColumn gridCol版本说明;
        private DevExpress.XtraGrid.Columns.GridColumn gridCol版本日期;
        private DevExpress.XtraGrid.Columns.GridColumn gridCol状态;
        private DevExpress.XtraGrid.Columns.GridColumn gridCol母件属性;
        private DevExpress.XtraGrid.Columns.GridColumn gridCol变更单号;
        private DevExpress.XtraGrid.Columns.GridColumn gridCol行号;
        private DevExpress.XtraGrid.Columns.GridColumn gridCol子件行号;
        private DevExpress.XtraGrid.Columns.GridColumn gridCol工序行号;
        private DevExpress.XtraGrid.Columns.GridColumn gridCol子件编码;
        private DevExpress.XtraGrid.Columns.GridColumn gridCol子件名称;
        private DevExpress.XtraGrid.Columns.GridColumn gridCol子件代号;
        private DevExpress.XtraGrid.Columns.GridColumn gridCol子件规格;
        private DevExpress.XtraGrid.Columns.GridColumn gridCol子件计量单位;
        private DevExpress.XtraGrid.Columns.GridColumn gridCol基本用量;
        private DevExpress.XtraGrid.Columns.GridColumn gridCol基础用量;
        private DevExpress.XtraGrid.Columns.GridColumn gridCol子件损耗率;
        private DevExpress.XtraGrid.Columns.GridColumn gridCol固定用量;
        private DevExpress.XtraGrid.Columns.GridColumn gridCol供应类型;
        private DevExpress.XtraGrid.Columns.GridColumn gridCol单阶使用数量;
        private DevExpress.XtraGrid.Columns.GridColumn gridCol加成数量;
        private DevExpress.XtraGrid.Columns.GridColumn gridCol子件生效日;
        private DevExpress.XtraGrid.Columns.GridColumn gridCol子件失效日;
        private DevExpress.XtraGrid.Columns.GridColumn gridCol偏置期;
        private DevExpress.XtraGrid.Columns.GridColumn gridCol计划比例;
        private DevExpress.XtraGrid.Columns.GridColumn gridCol产出品;
        private DevExpress.XtraGrid.Columns.GridColumn gridCol产出类型;
        private DevExpress.XtraGrid.Columns.GridColumn gridCol成本相关;
        private DevExpress.XtraGrid.Columns.GridColumn gridCol可选否;
        private DevExpress.XtraGrid.Columns.GridColumn gridCol选择规则;
        private DevExpress.XtraGrid.Columns.GridColumn gridCol备注;
        private DevExpress.XtraGrid.Columns.GridColumn gridCol子件属性;
        private DevExpress.XtraGrid.Columns.GridColumn gridCol母子关联;
        private DevExpress.XtraGrid.Columns.GridColumn gridCol销售订单号;
        private DevExpress.XtraGrid.Columns.GridColumn gridCol销售订单行号;
        private DevExpress.XtraGrid.Columns.GridColumn gridCol销售订单子表ID;
        private DevExpress.XtraGrid.Columns.GridColumn gridCol需求数量;
        private DevExpress.XtraGrid.Columns.GridColumn gridCol评审数量;
        private DevExpress.XtraGrid.Columns.GridColumn gridCol交货日期;
        private DevExpress.XtraGrid.Columns.GridColumn gridCol开始日期;
        private DevExpress.XtraGrid.Columns.GridColumn gridCol结束日期;
        private DevExpress.XtraGrid.Columns.GridColumn gridCol评审采购周期;
        private DevExpress.XtraGrid.Columns.GridColumn gridCol评审委外周期;
        private DevExpress.XtraGrid.Columns.GridColumn gridCol单件默认生产工时;
        private DevExpress.XtraGrid.Columns.GridColumn gridCol默认产线;
        private DevExpress.XtraGrid.Columns.GridColumn gridCol质检周期;
        private DevExpress.XtraGrid.Columns.GridColumn gridCol生产准备时间;
        private DevExpress.XtraGrid.Columns.GridColumn gridCol经济批量;
        private DevExpress.XtraGrid.Columns.GridColumn gridCol置办周期;
        private DevExpress.XtraGrid.Columns.GridColumn gridCol生产合计工时;
        private DevExpress.XtraGrid.Columns.GridColumn gridCol默认产线并发生产数;
        private DevExpress.XtraGrid.Columns.GridColumn gridCol仓库存量;
        private DevExpress.XtraGrid.Columns.GridColumn gridCol待入库数量;
        private DevExpress.XtraGrid.Columns.GridColumn gridCol待出库数量;
        private DevExpress.XtraGrid.Columns.GridColumn gridCol销售单号;
        private DevExpress.XtraGrid.Columns.GridColumn gridCol本单需求数量;
        private System.Windows.Forms.Button btn日期顺推;
        private DevExpress.XtraEditors.DateEdit dateEditNow;
        private DevExpress.XtraGrid.Columns.GridColumn gridCol_数量;
        private DevExpress.XtraGrid.Columns.GridColumn gridCol_评审单据号;
        private DevExpress.XtraGrid.Columns.GridColumn gridCol_评审单据日期;
        private DevExpress.XtraGrid.Columns.GridColumn gridCol_帐套号;
        private DevExpress.XtraGrid.Columns.GridColumn gridCol_Guid;
        private DevExpress.XtraGrid.Columns.GridColumn gridCol_制单人;
        private DevExpress.XtraGrid.Columns.GridColumn gridCol_制单日期;
        private DevExpress.XtraGrid.Columns.GridColumn gridCol_锁定人;
        private DevExpress.XtraGrid.Columns.GridColumn gridCol_锁定日期;
        private DevExpress.XtraGrid.Columns.GridColumn gridCol_审核人;
        private DevExpress.XtraGrid.Columns.GridColumn gridCol_审核日期;
        private DevExpress.XtraGrid.Columns.GridColumn gridCol_关闭人;
        private DevExpress.XtraGrid.Columns.GridColumn gridCol_关闭日期;
        private DevExpress.XtraGrid.Columns.GridColumn gridCol仓库编码;
        private DevExpress.XtraGrid.Columns.GridColumn gridCol仓库名称;
        private DevExpress.XtraGrid.Columns.GridColumn gridCol领料部门编码;
        private DevExpress.XtraGrid.Columns.GridColumn gridCol生产部门编码;
        private DevExpress.XtraGrid.Columns.GridColumn gridColGUIDHead;
        private DevExpress.XtraGrid.Columns.GridColumn gridColGUID;
        private DevExpress.XtraGrid.Columns.GridColumn gridCol评审单据号;
        private DevExpress.XtraGrid.Columns.GridColumn gridColiID;
        private DevExpress.XtraGrid.Columns.GridColumn gridCol换算率;
        private DevExpress.XtraEditors.DateEdit dtm单据日期;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem2;
        private DevExpress.XtraEditors.Repository.RepositoryItemTextEdit ItemTextEditn2;
        private DevExpress.XtraGrid.Columns.GridColumn gridCol产线;
        private DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit ItemLookUpEdit产线编码;
        private DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit ItemLookUpEdit产线;
    }
}