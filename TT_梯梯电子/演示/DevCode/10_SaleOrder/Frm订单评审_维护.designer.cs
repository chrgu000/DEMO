namespace SaleOrder
{
    partial class Frm订单评审_维护
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
            this.txt审核人 = new DevExpress.XtraEditors.TextEdit();
            this.dtm审核 = new DevExpress.XtraEditors.DateEdit();
            this.txt评审备注 = new DevExpress.XtraEditors.TextEdit();
            this.lookUpEdit客户 = new DevExpress.XtraEditors.LookUpEdit();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.gridControl评审维护 = new DevExpress.XtraGrid.GridControl();
            this.gridView评审维护 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.gridColiID = new DevExpress.XtraGrid.Columns.GridColumn();
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
            this.gridCol回签日期1 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridCol回签日期2 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridCol选择 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridCol待出库量 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridCol母子对应 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridCol调整数量 = new DevExpress.XtraGrid.Columns.GridColumn();
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
            this.txt销售订单ID = new DevExpress.XtraEditors.TextEdit();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btn15天核查 = new System.Windows.Forms.Button();
            this.btn回签日期核查 = new System.Windows.Forms.Button();
            this.dtm完成日期 = new DevExpress.XtraEditors.DateEdit();
            this.chk完成日期 = new System.Windows.Forms.CheckBox();
            this.dtm开始日期 = new DevExpress.XtraEditors.DateEdit();
            this.chk开始日期 = new System.Windows.Forms.CheckBox();
            this.btn选择 = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.lookUpEdit属性 = new DevExpress.XtraEditors.LookUpEdit();
            this.chk0 = new System.Windows.Forms.CheckBox();
            this.radio手工 = new System.Windows.Forms.RadioButton();
            this.chk全选 = new System.Windows.Forms.CheckBox();
            this.txt存货编码 = new DevExpress.XtraEditors.TextEdit();
            this.btnChange = new System.Windows.Forms.Button();
            this.radio逆排 = new System.Windows.Forms.RadioButton();
            this.radio顺排 = new System.Windows.Forms.RadioButton();
            this.txt备注 = new DevExpress.XtraEditors.TextEdit();
            this.txt客户订单号 = new DevExpress.XtraEditors.TextEdit();
            this.txt销售订单号 = new DevExpress.XtraEditors.TextEdit();
            this.txt外销订单号 = new DevExpress.XtraEditors.TextEdit();
            this.layoutControlGroup1 = new DevExpress.XtraLayout.LayoutControlGroup();
            this.layoutControlItem2 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem6 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem29 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem19 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem3 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem7 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem1 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem5 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem30 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem8 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem9 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem4 = new DevExpress.XtraLayout.LayoutControlItem();
            ((System.ComponentModel.ISupportInitialize)(this.dsPrint)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dsForm)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtSel)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControl1)).BeginInit();
            this.layoutControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txt审核人.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtm审核.Properties.VistaTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtm审核.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txt评审备注.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lookUpEdit客户.Properties)).BeginInit();
            this.tabControl1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl评审维护)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView评审维护)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ItemLookUpEdit物料编码)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ItemLookUpEdit物料名称)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ItemLookUpEdit规格型号)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ItemLookUpEdit子件属性)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ItemLookUpEdit仓库编号)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ItemLookUpEdit仓库名称)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ItemLookUpEdit部门编码)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ItemLookUpEdit部门名称)).BeginInit();
            this.tabPage1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl销售订单列表)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView销售订单列表)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ItemLookUpEdit1存货编码)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ItemLookUpEdit1存货名称)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ItemLookUpEdit1规格型号)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txt销售订单ID.Properties)).BeginInit();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dtm完成日期.Properties.VistaTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtm完成日期.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtm开始日期.Properties.VistaTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtm开始日期.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lookUpEdit属性.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txt存货编码.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txt备注.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txt客户订单号.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txt销售订单号.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txt外销订单号.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem6)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem29)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem19)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem7)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem5)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem30)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem8)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem9)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem4)).BeginInit();
            this.SuspendLayout();
            // 
            // layoutControl1
            // 
            this.layoutControl1.AllowCustomizationMenu = false;
            this.layoutControl1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.layoutControl1.Controls.Add(this.txt审核人);
            this.layoutControl1.Controls.Add(this.dtm审核);
            this.layoutControl1.Controls.Add(this.txt评审备注);
            this.layoutControl1.Controls.Add(this.lookUpEdit客户);
            this.layoutControl1.Controls.Add(this.tabControl1);
            this.layoutControl1.Controls.Add(this.txt销售订单ID);
            this.layoutControl1.Controls.Add(this.groupBox1);
            this.layoutControl1.Controls.Add(this.txt备注);
            this.layoutControl1.Controls.Add(this.txt客户订单号);
            this.layoutControl1.Controls.Add(this.txt销售订单号);
            this.layoutControl1.Controls.Add(this.txt外销订单号);
            this.layoutControl1.Location = new System.Drawing.Point(0, 36);
            this.layoutControl1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.layoutControl1.Name = "layoutControl1";
            this.layoutControl1.OptionsCustomizationForm.DesignTimeCustomizationFormPositionAndSize = new System.Drawing.Rectangle(491, 212, 250, 350);
            this.layoutControl1.OptionsCustomizationForm.ShowLoadButton = false;
            this.layoutControl1.OptionsCustomizationForm.ShowSaveButton = false;
            this.layoutControl1.Root = this.layoutControlGroup1;
            this.layoutControl1.Size = new System.Drawing.Size(1568, 469);
            this.layoutControl1.TabIndex = 5;
            this.layoutControl1.Text = "layoutControl1";
            // 
            // txt审核人
            // 
            this.txt审核人.Enabled = false;
            this.txt审核人.Location = new System.Drawing.Point(1117, 68);
            this.txt审核人.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txt审核人.Name = "txt审核人";
            this.txt审核人.Size = new System.Drawing.Size(176, 24);
            this.txt审核人.StyleController = this.layoutControl1;
            this.txt审核人.TabIndex = 54;
            // 
            // dtm审核
            // 
            this.dtm审核.EditValue = null;
            this.dtm审核.Enabled = false;
            this.dtm审核.Location = new System.Drawing.Point(1377, 68);
            this.dtm审核.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.dtm审核.Name = "dtm审核";
            this.dtm审核.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.dtm审核.Properties.VistaTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
            this.dtm审核.Size = new System.Drawing.Size(179, 24);
            this.dtm审核.StyleController = this.layoutControl1;
            this.dtm审核.TabIndex = 53;
            // 
            // txt评审备注
            // 
            this.txt评审备注.Enabled = false;
            this.txt评审备注.Location = new System.Drawing.Point(92, 68);
            this.txt评审备注.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txt评审备注.Name = "txt评审备注";
            this.txt评审备注.Size = new System.Drawing.Size(941, 24);
            this.txt评审备注.StyleController = this.layoutControl1;
            this.txt评审备注.TabIndex = 52;
            // 
            // lookUpEdit客户
            // 
            this.lookUpEdit客户.Enabled = false;
            this.lookUpEdit客户.Location = new System.Drawing.Point(1118, 12);
            this.lookUpEdit客户.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
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
            this.lookUpEdit客户.Size = new System.Drawing.Size(438, 24);
            this.lookUpEdit客户.StyleController = this.layoutControl1;
            this.lookUpEdit客户.TabIndex = 51;
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Location = new System.Drawing.Point(12, 149);
            this.tabControl1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(1544, 308);
            this.tabControl1.TabIndex = 50;
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.gridControl评审维护);
            this.tabPage2.Location = new System.Drawing.Point(4, 27);
            this.tabPage2.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.tabPage2.Size = new System.Drawing.Size(1536, 277);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "评审计算";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // gridControl评审维护
            // 
            this.gridControl评审维护.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridControl评审维护.EmbeddedNavigator.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.gridControl评审维护.Location = new System.Drawing.Point(3, 4);
            this.gridControl评审维护.MainView = this.gridView评审维护;
            this.gridControl评审维护.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.gridControl评审维护.Name = "gridControl评审维护";
            this.gridControl评审维护.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.ItemLookUpEdit子件属性,
            this.ItemLookUpEdit物料编码,
            this.ItemLookUpEdit物料名称,
            this.ItemLookUpEdit规格型号,
            this.ItemLookUpEdit仓库编号,
            this.ItemLookUpEdit仓库名称,
            this.ItemLookUpEdit部门编码,
            this.ItemLookUpEdit部门名称});
            this.gridControl评审维护.Size = new System.Drawing.Size(1530, 269);
            this.gridControl评审维护.TabIndex = 8;
            this.gridControl评审维护.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView评审维护});
            // 
            // gridView评审维护
            // 
            this.gridView评审维护.Appearance.ColumnFilterButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(236)))), ((int)(((byte)(232)))), ((int)(((byte)(201)))));
            this.gridView评审维护.Appearance.ColumnFilterButton.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(236)))), ((int)(((byte)(232)))), ((int)(((byte)(201)))));
            this.gridView评审维护.Appearance.ColumnFilterButton.ForeColor = System.Drawing.Color.Black;
            this.gridView评审维护.Appearance.ColumnFilterButton.Options.UseBackColor = true;
            this.gridView评审维护.Appearance.ColumnFilterButton.Options.UseBorderColor = true;
            this.gridView评审维护.Appearance.ColumnFilterButton.Options.UseForeColor = true;
            this.gridView评审维护.Appearance.ColumnFilterButtonActive.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(221)))), ((int)(((byte)(231)))), ((int)(((byte)(234)))));
            this.gridView评审维护.Appearance.ColumnFilterButtonActive.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(221)))), ((int)(((byte)(231)))), ((int)(((byte)(234)))));
            this.gridView评审维护.Appearance.ColumnFilterButtonActive.ForeColor = System.Drawing.Color.Black;
            this.gridView评审维护.Appearance.ColumnFilterButtonActive.Options.UseBackColor = true;
            this.gridView评审维护.Appearance.ColumnFilterButtonActive.Options.UseBorderColor = true;
            this.gridView评审维护.Appearance.ColumnFilterButtonActive.Options.UseForeColor = true;
            this.gridView评审维护.Appearance.Empty.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(236)))), ((int)(((byte)(232)))), ((int)(((byte)(201)))));
            this.gridView评审维护.Appearance.Empty.BackColor2 = System.Drawing.Color.White;
            this.gridView评审维护.Appearance.Empty.Options.UseBackColor = true;
            this.gridView评审维护.Appearance.EvenRow.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(221)))), ((int)(((byte)(231)))), ((int)(((byte)(234)))));
            this.gridView评审维护.Appearance.EvenRow.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(221)))), ((int)(((byte)(231)))), ((int)(((byte)(234)))));
            this.gridView评审维护.Appearance.EvenRow.ForeColor = System.Drawing.Color.Black;
            this.gridView评审维护.Appearance.EvenRow.Options.UseBackColor = true;
            this.gridView评审维护.Appearance.EvenRow.Options.UseBorderColor = true;
            this.gridView评审维护.Appearance.EvenRow.Options.UseForeColor = true;
            this.gridView评审维护.Appearance.FilterCloseButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(216)))), ((int)(((byte)(209)))), ((int)(((byte)(179)))));
            this.gridView评审维护.Appearance.FilterCloseButton.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(216)))), ((int)(((byte)(209)))), ((int)(((byte)(179)))));
            this.gridView评审维护.Appearance.FilterCloseButton.ForeColor = System.Drawing.Color.Black;
            this.gridView评审维护.Appearance.FilterCloseButton.Options.UseBackColor = true;
            this.gridView评审维护.Appearance.FilterCloseButton.Options.UseBorderColor = true;
            this.gridView评审维护.Appearance.FilterCloseButton.Options.UseForeColor = true;
            this.gridView评审维护.Appearance.FilterPanel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(236)))), ((int)(((byte)(232)))), ((int)(((byte)(201)))));
            this.gridView评审维护.Appearance.FilterPanel.BackColor2 = System.Drawing.Color.White;
            this.gridView评审维护.Appearance.FilterPanel.ForeColor = System.Drawing.Color.Black;
            this.gridView评审维护.Appearance.FilterPanel.Options.UseBackColor = true;
            this.gridView评审维护.Appearance.FilterPanel.Options.UseForeColor = true;
            this.gridView评审维护.Appearance.FixedLine.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(122)))), ((int)(((byte)(114)))), ((int)(((byte)(113)))));
            this.gridView评审维护.Appearance.FixedLine.Options.UseBackColor = true;
            this.gridView评审维护.Appearance.FocusedCell.BackColor = System.Drawing.Color.White;
            this.gridView评审维护.Appearance.FocusedCell.ForeColor = System.Drawing.Color.Black;
            this.gridView评审维护.Appearance.FocusedCell.Options.UseBackColor = true;
            this.gridView评审维护.Appearance.FocusedCell.Options.UseForeColor = true;
            this.gridView评审维护.Appearance.FocusedRow.BackColor = System.Drawing.Color.Lime;
            this.gridView评审维护.Appearance.FocusedRow.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(219)))), ((int)(((byte)(188)))));
            this.gridView评审维护.Appearance.FocusedRow.ForeColor = System.Drawing.Color.Black;
            this.gridView评审维护.Appearance.FocusedRow.Options.UseBackColor = true;
            this.gridView评审维护.Appearance.FocusedRow.Options.UseBorderColor = true;
            this.gridView评审维护.Appearance.FocusedRow.Options.UseForeColor = true;
            this.gridView评审维护.Appearance.FooterPanel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(216)))), ((int)(((byte)(209)))), ((int)(((byte)(170)))));
            this.gridView评审维护.Appearance.FooterPanel.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(216)))), ((int)(((byte)(209)))), ((int)(((byte)(170)))));
            this.gridView评审维护.Appearance.FooterPanel.ForeColor = System.Drawing.Color.Black;
            this.gridView评审维护.Appearance.FooterPanel.Options.UseBackColor = true;
            this.gridView评审维护.Appearance.FooterPanel.Options.UseBorderColor = true;
            this.gridView评审维护.Appearance.FooterPanel.Options.UseForeColor = true;
            this.gridView评审维护.Appearance.GroupButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(216)))), ((int)(((byte)(209)))), ((int)(((byte)(179)))));
            this.gridView评审维护.Appearance.GroupButton.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(216)))), ((int)(((byte)(209)))), ((int)(((byte)(179)))));
            this.gridView评审维护.Appearance.GroupButton.Options.UseBackColor = true;
            this.gridView评审维护.Appearance.GroupButton.Options.UseBorderColor = true;
            this.gridView评审维护.Appearance.GroupFooter.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(236)))), ((int)(((byte)(232)))), ((int)(((byte)(201)))));
            this.gridView评审维护.Appearance.GroupFooter.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(236)))), ((int)(((byte)(232)))), ((int)(((byte)(201)))));
            this.gridView评审维护.Appearance.GroupFooter.ForeColor = System.Drawing.Color.Black;
            this.gridView评审维护.Appearance.GroupFooter.Options.UseBackColor = true;
            this.gridView评审维护.Appearance.GroupFooter.Options.UseBorderColor = true;
            this.gridView评审维护.Appearance.GroupFooter.Options.UseForeColor = true;
            this.gridView评审维护.Appearance.GroupPanel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(246)))), ((int)(((byte)(242)))), ((int)(((byte)(213)))));
            this.gridView评审维护.Appearance.GroupPanel.BackColor2 = System.Drawing.Color.White;
            this.gridView评审维护.Appearance.GroupPanel.ForeColor = System.Drawing.Color.Black;
            this.gridView评审维护.Appearance.GroupPanel.Options.UseBackColor = true;
            this.gridView评审维护.Appearance.GroupPanel.Options.UseForeColor = true;
            this.gridView评审维护.Appearance.GroupRow.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(236)))), ((int)(((byte)(232)))), ((int)(((byte)(201)))));
            this.gridView评审维护.Appearance.GroupRow.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(236)))), ((int)(((byte)(232)))), ((int)(((byte)(201)))));
            this.gridView评审维护.Appearance.GroupRow.ForeColor = System.Drawing.Color.Black;
            this.gridView评审维护.Appearance.GroupRow.Options.UseBackColor = true;
            this.gridView评审维护.Appearance.GroupRow.Options.UseBorderColor = true;
            this.gridView评审维护.Appearance.GroupRow.Options.UseForeColor = true;
            this.gridView评审维护.Appearance.HeaderPanel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(216)))), ((int)(((byte)(209)))), ((int)(((byte)(170)))));
            this.gridView评审维护.Appearance.HeaderPanel.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(216)))), ((int)(((byte)(209)))), ((int)(((byte)(170)))));
            this.gridView评审维护.Appearance.HeaderPanel.ForeColor = System.Drawing.Color.Black;
            this.gridView评审维护.Appearance.HeaderPanel.Options.UseBackColor = true;
            this.gridView评审维护.Appearance.HeaderPanel.Options.UseBorderColor = true;
            this.gridView评审维护.Appearance.HeaderPanel.Options.UseForeColor = true;
            this.gridView评审维护.Appearance.HideSelectionRow.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(237)))), ((int)(((byte)(230)))), ((int)(((byte)(203)))));
            this.gridView评审维护.Appearance.HideSelectionRow.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(237)))), ((int)(((byte)(230)))), ((int)(((byte)(203)))));
            this.gridView评审维护.Appearance.HideSelectionRow.ForeColor = System.Drawing.Color.Black;
            this.gridView评审维护.Appearance.HideSelectionRow.Options.UseBackColor = true;
            this.gridView评审维护.Appearance.HideSelectionRow.Options.UseBorderColor = true;
            this.gridView评审维护.Appearance.HideSelectionRow.Options.UseForeColor = true;
            this.gridView评审维护.Appearance.HorzLine.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(216)))), ((int)(((byte)(209)))), ((int)(((byte)(170)))));
            this.gridView评审维护.Appearance.HorzLine.Options.UseBackColor = true;
            this.gridView评审维护.Appearance.OddRow.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(242)))), ((int)(((byte)(244)))), ((int)(((byte)(236)))));
            this.gridView评审维护.Appearance.OddRow.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(242)))), ((int)(((byte)(244)))), ((int)(((byte)(236)))));
            this.gridView评审维护.Appearance.OddRow.ForeColor = System.Drawing.Color.Black;
            this.gridView评审维护.Appearance.OddRow.Options.UseBackColor = true;
            this.gridView评审维护.Appearance.OddRow.Options.UseBorderColor = true;
            this.gridView评审维护.Appearance.OddRow.Options.UseForeColor = true;
            this.gridView评审维护.Appearance.Preview.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(251)))), ((int)(((byte)(252)))), ((int)(((byte)(247)))));
            this.gridView评审维护.Appearance.Preview.Font = new System.Drawing.Font("Verdana", 7.5F);
            this.gridView评审维护.Appearance.Preview.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(148)))), ((int)(((byte)(148)))), ((int)(((byte)(148)))));
            this.gridView评审维护.Appearance.Preview.Options.UseBackColor = true;
            this.gridView评审维护.Appearance.Preview.Options.UseFont = true;
            this.gridView评审维护.Appearance.Preview.Options.UseForeColor = true;
            this.gridView评审维护.Appearance.Row.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(242)))), ((int)(((byte)(244)))), ((int)(((byte)(236)))));
            this.gridView评审维护.Appearance.Row.ForeColor = System.Drawing.Color.Black;
            this.gridView评审维护.Appearance.Row.Options.UseBackColor = true;
            this.gridView评审维护.Appearance.Row.Options.UseForeColor = true;
            this.gridView评审维护.Appearance.RowSeparator.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(236)))), ((int)(((byte)(232)))), ((int)(((byte)(201)))));
            this.gridView评审维护.Appearance.RowSeparator.BackColor2 = System.Drawing.Color.White;
            this.gridView评审维护.Appearance.RowSeparator.Options.UseBackColor = true;
            this.gridView评审维护.Appearance.SelectedRow.BackColor = System.Drawing.Color.Lime;
            this.gridView评审维护.Appearance.SelectedRow.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(237)))), ((int)(((byte)(230)))), ((int)(((byte)(203)))));
            this.gridView评审维护.Appearance.SelectedRow.ForeColor = System.Drawing.Color.Black;
            this.gridView评审维护.Appearance.SelectedRow.Options.UseBackColor = true;
            this.gridView评审维护.Appearance.SelectedRow.Options.UseBorderColor = true;
            this.gridView评审维护.Appearance.SelectedRow.Options.UseForeColor = true;
            this.gridView评审维护.Appearance.TopNewRow.BackColor = System.Drawing.Color.White;
            this.gridView评审维护.Appearance.TopNewRow.Options.UseBackColor = true;
            this.gridView评审维护.Appearance.VertLine.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(216)))), ((int)(((byte)(209)))), ((int)(((byte)(170)))));
            this.gridView评审维护.Appearance.VertLine.Options.UseBackColor = true;
            this.gridView评审维护.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.gridColiID,
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
            this.gridCol回签日期1,
            this.gridCol回签日期2,
            this.gridCol选择,
            this.gridCol待出库量,
            this.gridCol母子对应,
            this.gridCol调整数量});
            this.gridView评审维护.GridControl = this.gridControl评审维护;
            this.gridView评审维护.IndicatorWidth = 40;
            this.gridView评审维护.Name = "gridView评审维护";
            this.gridView评审维护.OptionsLayout.Columns.StoreAllOptions = true;
            this.gridView评审维护.OptionsLayout.Columns.StoreAppearance = true;
            this.gridView评审维护.OptionsLayout.StoreAllOptions = true;
            this.gridView评审维护.OptionsLayout.StoreAppearance = true;
            this.gridView评审维护.OptionsMenu.ShowAddNewSummaryItem = DevExpress.Utils.DefaultBoolean.True;
            this.gridView评审维护.OptionsMenu.ShowGroupSummaryEditorItem = true;
            this.gridView评审维护.OptionsNavigation.EnterMoveNextColumn = true;
            this.gridView评审维护.OptionsSelection.MultiSelect = true;
            this.gridView评审维护.OptionsView.AutoCalcPreviewLineCount = true;
            this.gridView评审维护.OptionsView.ColumnAutoWidth = false;
            this.gridView评审维护.OptionsView.EnableAppearanceEvenRow = true;
            this.gridView评审维护.OptionsView.EnableAppearanceOddRow = true;
            this.gridView评审维护.OptionsView.ShowFooter = true;
            this.gridView评审维护.OptionsView.ShowGroupPanel = false;
            this.gridView评审维护.CustomDrawRowIndicator += new DevExpress.XtraGrid.Views.Grid.RowIndicatorCustomDrawEventHandler(this.gridView评审计算_CustomDrawRowIndicator);
            this.gridView评审维护.CellValueChanged += new DevExpress.XtraGrid.Views.Base.CellValueChangedEventHandler(this.gridView评审计算_CellValueChanged);
            this.gridView评审维护.RowCellStyle += new DevExpress.XtraGrid.Views.Grid.RowCellStyleEventHandler(this.gridView评审维护_RowCellStyle);
            this.gridView评审维护.DoubleClick += new System.EventHandler(this.gridView评审维护_DoubleClick);
            // 
            // gridColiID
            // 
            this.gridColiID.Caption = "iID";
            this.gridColiID.FieldName = "iID";
            this.gridColiID.Name = "gridColiID";
            this.gridColiID.OptionsColumn.AllowEdit = false;
            this.gridColiID.OptionsColumn.AllowMerge = DevExpress.Utils.DefaultBoolean.False;
            this.gridColiID.OptionsColumn.AllowSort = DevExpress.Utils.DefaultBoolean.True;
            this.gridColiID.Visible = true;
            this.gridColiID.VisibleIndex = 13;
            this.gridColiID.Width = 31;
            // 
            // gridCol销售订单行号
            // 
            this.gridCol销售订单行号.Caption = "行号";
            this.gridCol销售订单行号.FieldName = "销售订单行号";
            this.gridCol销售订单行号.Fixed = DevExpress.XtraGrid.Columns.FixedStyle.Left;
            this.gridCol销售订单行号.Name = "gridCol销售订单行号";
            this.gridCol销售订单行号.OptionsColumn.AllowEdit = false;
            this.gridCol销售订单行号.OptionsColumn.AllowMerge = DevExpress.Utils.DefaultBoolean.False;
            this.gridCol销售订单行号.OptionsColumn.AllowSort = DevExpress.Utils.DefaultBoolean.True;
            this.gridCol销售订单行号.Visible = true;
            this.gridCol销售订单行号.VisibleIndex = 1;
            this.gridCol销售订单行号.Width = 38;
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
            this.gridCol级别.VisibleIndex = 14;
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
            this.gridCol母件编码.VisibleIndex = 15;
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
            this.ItemLookUpEdit物料编码.NullText = "";
            this.ItemLookUpEdit物料编码.ValueMember = "cInvCode";
            // 
            // gridCol母件名称
            // 
            this.gridCol母件名称.Caption = "母件名称";
            this.gridCol母件名称.ColumnEdit = this.ItemLookUpEdit物料名称;
            this.gridCol母件名称.FieldName = "母件编码";
            this.gridCol母件名称.Name = "gridCol母件名称";
            this.gridCol母件名称.OptionsColumn.AllowEdit = false;
            this.gridCol母件名称.OptionsColumn.AllowMerge = DevExpress.Utils.DefaultBoolean.False;
            this.gridCol母件名称.OptionsColumn.AllowSort = DevExpress.Utils.DefaultBoolean.True;
            this.gridCol母件名称.Visible = true;
            this.gridCol母件名称.VisibleIndex = 16;
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
            this.ItemLookUpEdit物料名称.NullText = "";
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
            this.gridCol母件规格.Name = "gridCol母件规格";
            this.gridCol母件规格.OptionsColumn.AllowEdit = false;
            this.gridCol母件规格.OptionsColumn.AllowMerge = DevExpress.Utils.DefaultBoolean.False;
            this.gridCol母件规格.OptionsColumn.AllowSort = DevExpress.Utils.DefaultBoolean.True;
            this.gridCol母件规格.Visible = true;
            this.gridCol母件规格.VisibleIndex = 17;
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
            this.gridCol子件编码.Caption = "子件编码";
            this.gridCol子件编码.ColumnEdit = this.ItemLookUpEdit物料编码;
            this.gridCol子件编码.FieldName = "子件编码";
            this.gridCol子件编码.Fixed = DevExpress.XtraGrid.Columns.FixedStyle.Left;
            this.gridCol子件编码.Name = "gridCol子件编码";
            this.gridCol子件编码.OptionsColumn.AllowEdit = false;
            this.gridCol子件编码.OptionsColumn.AllowMerge = DevExpress.Utils.DefaultBoolean.False;
            this.gridCol子件编码.OptionsColumn.AllowSort = DevExpress.Utils.DefaultBoolean.True;
            this.gridCol子件编码.Visible = true;
            this.gridCol子件编码.VisibleIndex = 2;
            // 
            // gridCol子件名称
            // 
            this.gridCol子件名称.Caption = "子件名称";
            this.gridCol子件名称.ColumnEdit = this.ItemLookUpEdit物料名称;
            this.gridCol子件名称.FieldName = "子件编码";
            this.gridCol子件名称.Fixed = DevExpress.XtraGrid.Columns.FixedStyle.Left;
            this.gridCol子件名称.Name = "gridCol子件名称";
            this.gridCol子件名称.OptionsColumn.AllowEdit = false;
            this.gridCol子件名称.OptionsColumn.AllowMerge = DevExpress.Utils.DefaultBoolean.False;
            this.gridCol子件名称.OptionsColumn.AllowSort = DevExpress.Utils.DefaultBoolean.True;
            this.gridCol子件名称.Visible = true;
            this.gridCol子件名称.VisibleIndex = 3;
            // 
            // gridCol子件规格
            // 
            this.gridCol子件规格.Caption = "子件规格";
            this.gridCol子件规格.ColumnEdit = this.ItemLookUpEdit规格型号;
            this.gridCol子件规格.FieldName = "子件编码";
            this.gridCol子件规格.Fixed = DevExpress.XtraGrid.Columns.FixedStyle.Left;
            this.gridCol子件规格.Name = "gridCol子件规格";
            this.gridCol子件规格.OptionsColumn.AllowEdit = false;
            this.gridCol子件规格.OptionsColumn.AllowMerge = DevExpress.Utils.DefaultBoolean.False;
            this.gridCol子件规格.OptionsColumn.AllowSort = DevExpress.Utils.DefaultBoolean.True;
            this.gridCol子件规格.Visible = true;
            this.gridCol子件规格.VisibleIndex = 4;
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
            this.ItemLookUpEdit规格型号.NullText = "";
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
            // 
            // gridCol供应类型
            // 
            this.gridCol供应类型.Caption = "供应类型";
            this.gridCol供应类型.FieldName = "供应类型";
            this.gridCol供应类型.Name = "gridCol供应类型";
            this.gridCol供应类型.OptionsColumn.AllowEdit = false;
            this.gridCol供应类型.OptionsColumn.AllowMerge = DevExpress.Utils.DefaultBoolean.False;
            this.gridCol供应类型.OptionsColumn.AllowSort = DevExpress.Utils.DefaultBoolean.True;
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
            this.gridCol使用数量.VisibleIndex = 28;
            // 
            // gridCol子件属性
            // 
            this.gridCol子件属性.Caption = "子件属性";
            this.gridCol子件属性.ColumnEdit = this.ItemLookUpEdit子件属性;
            this.gridCol子件属性.FieldName = "子件属性";
            this.gridCol子件属性.Name = "gridCol子件属性";
            this.gridCol子件属性.OptionsColumn.AllowEdit = false;
            this.gridCol子件属性.OptionsColumn.AllowMerge = DevExpress.Utils.DefaultBoolean.False;
            this.gridCol子件属性.OptionsColumn.AllowSort = DevExpress.Utils.DefaultBoolean.True;
            this.gridCol子件属性.Visible = true;
            this.gridCol子件属性.VisibleIndex = 18;
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
            this.ItemLookUpEdit子件属性.NullText = "";
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
            this.gridCol仓库代号.Visible = true;
            this.gridCol仓库代号.VisibleIndex = 21;
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
            this.ItemLookUpEdit仓库编号.NullText = "";
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
            this.gridCol仓库名称.Visible = true;
            this.gridCol仓库名称.VisibleIndex = 22;
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
            this.ItemLookUpEdit仓库名称.NullText = "";
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
            this.gridCol领料部门代号.Visible = true;
            this.gridCol领料部门代号.VisibleIndex = 29;
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
            this.ItemLookUpEdit部门编码.NullText = "";
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
            this.gridCol领料部门名称.Visible = true;
            this.gridCol领料部门名称.VisibleIndex = 30;
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
            this.ItemLookUpEdit部门名称.NullText = "";
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
            this.gridCol备注.VisibleIndex = 31;
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
            this.gridCol需求数量.Visible = true;
            this.gridCol需求数量.VisibleIndex = 5;
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
            this.gridCol本次下单数量.Visible = true;
            this.gridCol本次下单数量.VisibleIndex = 6;
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
            this.gridCol仓库现存量.VisibleIndex = 25;
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
            this.gridCol待入库量.VisibleIndex = 26;
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
            this.gridCol最小批量.VisibleIndex = 24;
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
            this.gridCol置办周期.VisibleIndex = 11;
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
            this.gridCol开始日期.VisibleIndex = 7;
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
            this.gridCol完成日期.VisibleIndex = 8;
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
            this.gridCol质检周期.VisibleIndex = 12;
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
            this.gridCol生产日工时.VisibleIndex = 19;
            // 
            // gridCol单件生产工时
            // 
            this.gridCol单件生产工时.Caption = "单件生产工时";
            this.gridCol单件生产工时.FieldName = "单件生产工时";
            this.gridCol单件生产工时.Name = "gridCol单件生产工时";
            this.gridCol单件生产工时.OptionsColumn.AllowEdit = false;
            this.gridCol单件生产工时.OptionsColumn.AllowMerge = DevExpress.Utils.DefaultBoolean.False;
            this.gridCol单件生产工时.OptionsColumn.AllowSort = DevExpress.Utils.DefaultBoolean.True;
            this.gridCol单件生产工时.Visible = true;
            this.gridCol单件生产工时.VisibleIndex = 33;
            this.gridCol单件生产工时.Width = 92;
            // 
            // gridCol生产工时
            // 
            this.gridCol生产工时.Caption = "生产工时";
            this.gridCol生产工时.FieldName = "生产工时";
            this.gridCol生产工时.Name = "gridCol生产工时";
            this.gridCol生产工时.OptionsColumn.AllowEdit = false;
            this.gridCol生产工时.OptionsColumn.AllowMerge = DevExpress.Utils.DefaultBoolean.False;
            this.gridCol生产工时.OptionsColumn.AllowSort = DevExpress.Utils.DefaultBoolean.True;
            this.gridCol生产工时.Visible = true;
            this.gridCol生产工时.VisibleIndex = 20;
            // 
            // gridCol下单量
            // 
            this.gridCol下单量.Caption = "下单量";
            this.gridCol下单量.FieldName = "下单量";
            this.gridCol下单量.Name = "gridCol下单量";
            this.gridCol下单量.OptionsColumn.AllowEdit = false;
            this.gridCol下单量.OptionsColumn.AllowMerge = DevExpress.Utils.DefaultBoolean.False;
            this.gridCol下单量.OptionsColumn.AllowSort = DevExpress.Utils.DefaultBoolean.True;
            this.gridCol下单量.Visible = true;
            this.gridCol下单量.VisibleIndex = 34;
            // 
            // gridCol累计下单量
            // 
            this.gridCol累计下单量.Caption = "累计下单量";
            this.gridCol累计下单量.FieldName = "累计下单量";
            this.gridCol累计下单量.Name = "gridCol累计下单量";
            this.gridCol累计下单量.OptionsColumn.AllowEdit = false;
            this.gridCol累计下单量.OptionsColumn.AllowMerge = DevExpress.Utils.DefaultBoolean.False;
            this.gridCol累计下单量.OptionsColumn.AllowSort = DevExpress.Utils.DefaultBoolean.True;
            this.gridCol累计下单量.Visible = true;
            this.gridCol累计下单量.VisibleIndex = 35;
            this.gridCol累计下单量.Width = 88;
            // 
            // gridCol累计待入库
            // 
            this.gridCol累计待入库.Caption = "累计待入库";
            this.gridCol累计待入库.FieldName = "累计待入库";
            this.gridCol累计待入库.Name = "gridCol累计待入库";
            this.gridCol累计待入库.OptionsColumn.AllowEdit = false;
            this.gridCol累计待入库.OptionsColumn.AllowMerge = DevExpress.Utils.DefaultBoolean.False;
            this.gridCol累计待入库.OptionsColumn.AllowSort = DevExpress.Utils.DefaultBoolean.True;
            // 
            // gridCol回签日期1
            // 
            this.gridCol回签日期1.Caption = "回签开始日期";
            this.gridCol回签日期1.FieldName = "回签日期1";
            this.gridCol回签日期1.Fixed = DevExpress.XtraGrid.Columns.FixedStyle.Left;
            this.gridCol回签日期1.Name = "gridCol回签日期1";
            this.gridCol回签日期1.OptionsColumn.AllowEdit = false;
            this.gridCol回签日期1.OptionsColumn.AllowMerge = DevExpress.Utils.DefaultBoolean.False;
            this.gridCol回签日期1.OptionsColumn.AllowSort = DevExpress.Utils.DefaultBoolean.True;
            this.gridCol回签日期1.Visible = true;
            this.gridCol回签日期1.VisibleIndex = 9;
            this.gridCol回签日期1.Width = 87;
            // 
            // gridCol回签日期2
            // 
            this.gridCol回签日期2.Caption = "回签完成日期";
            this.gridCol回签日期2.FieldName = "回签日期2";
            this.gridCol回签日期2.Fixed = DevExpress.XtraGrid.Columns.FixedStyle.Left;
            this.gridCol回签日期2.Name = "gridCol回签日期2";
            this.gridCol回签日期2.OptionsColumn.AllowEdit = false;
            this.gridCol回签日期2.OptionsColumn.AllowMerge = DevExpress.Utils.DefaultBoolean.False;
            this.gridCol回签日期2.OptionsColumn.AllowSort = DevExpress.Utils.DefaultBoolean.True;
            this.gridCol回签日期2.Visible = true;
            this.gridCol回签日期2.VisibleIndex = 10;
            this.gridCol回签日期2.Width = 81;
            // 
            // gridCol选择
            // 
            this.gridCol选择.Caption = "选择";
            this.gridCol选择.FieldName = "选择";
            this.gridCol选择.Fixed = DevExpress.XtraGrid.Columns.FixedStyle.Left;
            this.gridCol选择.Name = "gridCol选择";
            this.gridCol选择.OptionsColumn.AllowEdit = false;
            this.gridCol选择.OptionsColumn.AllowMerge = DevExpress.Utils.DefaultBoolean.False;
            this.gridCol选择.OptionsColumn.AllowSort = DevExpress.Utils.DefaultBoolean.True;
            this.gridCol选择.Visible = true;
            this.gridCol选择.VisibleIndex = 0;
            this.gridCol选择.Width = 33;
            // 
            // gridCol待出库量
            // 
            this.gridCol待出库量.Caption = "待出库量";
            this.gridCol待出库量.FieldName = "待出库量";
            this.gridCol待出库量.Name = "gridCol待出库量";
            this.gridCol待出库量.OptionsColumn.AllowEdit = false;
            this.gridCol待出库量.OptionsColumn.AllowMerge = DevExpress.Utils.DefaultBoolean.False;
            this.gridCol待出库量.OptionsColumn.AllowSort = DevExpress.Utils.DefaultBoolean.True;
            this.gridCol待出库量.Visible = true;
            this.gridCol待出库量.VisibleIndex = 27;
            // 
            // gridCol母子对应
            // 
            this.gridCol母子对应.Caption = "母子对应";
            this.gridCol母子对应.FieldName = "母子对应";
            this.gridCol母子对应.Name = "gridCol母子对应";
            this.gridCol母子对应.OptionsColumn.AllowEdit = false;
            this.gridCol母子对应.OptionsColumn.AllowMerge = DevExpress.Utils.DefaultBoolean.False;
            this.gridCol母子对应.OptionsColumn.AllowSort = DevExpress.Utils.DefaultBoolean.True;
            this.gridCol母子对应.Visible = true;
            this.gridCol母子对应.VisibleIndex = 32;
            // 
            // gridCol调整数量
            // 
            this.gridCol调整数量.Caption = "调整数量";
            this.gridCol调整数量.FieldName = "调整数量";
            this.gridCol调整数量.Name = "gridCol调整数量";
            this.gridCol调整数量.OptionsColumn.AllowEdit = false;
            this.gridCol调整数量.Visible = true;
            this.gridCol调整数量.VisibleIndex = 23;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.gridControl销售订单列表);
            this.tabPage1.Location = new System.Drawing.Point(4, 27);
            this.tabPage1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.tabPage1.Size = new System.Drawing.Size(1536, 277);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "销售订单列表";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // gridControl销售订单列表
            // 
            this.gridControl销售订单列表.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridControl销售订单列表.Location = new System.Drawing.Point(3, 4);
            this.gridControl销售订单列表.MainView = this.gridView销售订单列表;
            this.gridControl销售订单列表.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.gridControl销售订单列表.Name = "gridControl销售订单列表";
            this.gridControl销售订单列表.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.ItemLookUpEdit1存货编码,
            this.ItemLookUpEdit1存货名称,
            this.ItemLookUpEdit1规格型号});
            this.gridControl销售订单列表.Size = new System.Drawing.Size(1530, 269);
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
            // txt销售订单ID
            // 
            this.txt销售订单ID.Enabled = false;
            this.txt销售订单ID.Location = new System.Drawing.Point(1379, 40);
            this.txt销售订单ID.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txt销售订单ID.Name = "txt销售订单ID";
            this.txt销售订单ID.Size = new System.Drawing.Size(177, 24);
            this.txt销售订单ID.StyleController = this.layoutControl1;
            this.txt销售订单ID.TabIndex = 49;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.btn15天核查);
            this.groupBox1.Controls.Add(this.btn回签日期核查);
            this.groupBox1.Controls.Add(this.dtm完成日期);
            this.groupBox1.Controls.Add(this.chk完成日期);
            this.groupBox1.Controls.Add(this.dtm开始日期);
            this.groupBox1.Controls.Add(this.chk开始日期);
            this.groupBox1.Controls.Add(this.btn选择);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.lookUpEdit属性);
            this.groupBox1.Controls.Add(this.chk0);
            this.groupBox1.Controls.Add(this.radio手工);
            this.groupBox1.Controls.Add(this.chk全选);
            this.groupBox1.Controls.Add(this.txt存货编码);
            this.groupBox1.Controls.Add(this.btnChange);
            this.groupBox1.Controls.Add(this.radio逆排);
            this.groupBox1.Controls.Add(this.radio顺排);
            this.groupBox1.Location = new System.Drawing.Point(12, 96);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.groupBox1.Size = new System.Drawing.Size(1544, 49);
            this.groupBox1.TabIndex = 41;
            this.groupBox1.TabStop = false;
            // 
            // btn15天核查
            // 
            this.btn15天核查.Enabled = false;
            this.btn15天核查.Location = new System.Drawing.Point(486, 18);
            this.btn15天核查.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btn15天核查.Name = "btn15天核查";
            this.btn15天核查.Size = new System.Drawing.Size(86, 30);
            this.btn15天核查.TabIndex = 65;
            this.btn15天核查.Text = "15天核查";
            this.btn15天核查.UseVisualStyleBackColor = true;
            this.btn15天核查.Click += new System.EventHandler(this.btn15天核查_Click);
            // 
            // btn回签日期核查
            // 
            this.btn回签日期核查.Enabled = false;
            this.btn回签日期核查.Location = new System.Drawing.Point(970, 17);
            this.btn回签日期核查.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btn回签日期核查.Name = "btn回签日期核查";
            this.btn回签日期核查.Size = new System.Drawing.Size(107, 30);
            this.btn回签日期核查.TabIndex = 55;
            this.btn回签日期核查.Text = "回签日期核查";
            this.btn回签日期核查.UseVisualStyleBackColor = true;
            this.btn回签日期核查.Click += new System.EventHandler(this.btn回签日期核查_Click);
            // 
            // dtm完成日期
            // 
            this.dtm完成日期.EditValue = null;
            this.dtm完成日期.Location = new System.Drawing.Point(1370, 18);
            this.dtm完成日期.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.dtm完成日期.Name = "dtm完成日期";
            this.dtm完成日期.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.dtm完成日期.Properties.VistaTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
            this.dtm完成日期.Size = new System.Drawing.Size(86, 24);
            this.dtm完成日期.TabIndex = 54;
            // 
            // chk完成日期
            // 
            this.chk完成日期.AutoSize = true;
            this.chk完成日期.Location = new System.Drawing.Point(1279, 21);
            this.chk完成日期.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.chk完成日期.Name = "chk完成日期";
            this.chk完成日期.Size = new System.Drawing.Size(90, 22);
            this.chk完成日期.TabIndex = 53;
            this.chk完成日期.Text = "完成日期";
            this.chk完成日期.UseVisualStyleBackColor = true;
            this.chk完成日期.CheckedChanged += new System.EventHandler(this.chk完成日期_CheckedChanged);
            // 
            // dtm开始日期
            // 
            this.dtm开始日期.EditValue = null;
            this.dtm开始日期.Location = new System.Drawing.Point(1186, 19);
            this.dtm开始日期.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.dtm开始日期.Name = "dtm开始日期";
            this.dtm开始日期.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.dtm开始日期.Properties.VistaTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
            this.dtm开始日期.Size = new System.Drawing.Size(86, 24);
            this.dtm开始日期.TabIndex = 52;
            // 
            // chk开始日期
            // 
            this.chk开始日期.AutoSize = true;
            this.chk开始日期.Location = new System.Drawing.Point(1095, 22);
            this.chk开始日期.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.chk开始日期.Name = "chk开始日期";
            this.chk开始日期.Size = new System.Drawing.Size(90, 22);
            this.chk开始日期.TabIndex = 51;
            this.chk开始日期.Text = "开始日期";
            this.chk开始日期.UseVisualStyleBackColor = true;
            this.chk开始日期.CheckedChanged += new System.EventHandler(this.chk开始日期_CheckedChanged);
            // 
            // btn选择
            // 
            this.btn选择.Enabled = false;
            this.btn选择.Location = new System.Drawing.Point(901, 18);
            this.btn选择.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btn选择.Name = "btn选择";
            this.btn选择.Size = new System.Drawing.Size(63, 30);
            this.btn选择.TabIndex = 50;
            this.btn选择.Text = "选择";
            this.btn选择.UseVisualStyleBackColor = true;
            this.btn选择.Click += new System.EventHandler(this.btn选择_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(730, 23);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(68, 18);
            this.label1.TabIndex = 49;
            this.label1.Text = "存货编码";
            // 
            // lookUpEdit属性
            // 
            this.lookUpEdit属性.Location = new System.Drawing.Point(613, 19);
            this.lookUpEdit属性.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.lookUpEdit属性.Name = "lookUpEdit属性";
            this.lookUpEdit属性.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.lookUpEdit属性.Properties.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("iID", "内容")});
            this.lookUpEdit属性.Properties.DisplayMember = "iID";
            this.lookUpEdit属性.Properties.NullText = "";
            this.lookUpEdit属性.Properties.ValueMember = "iID";
            this.lookUpEdit属性.Size = new System.Drawing.Size(91, 24);
            this.lookUpEdit属性.TabIndex = 48;
            this.lookUpEdit属性.EditValueChanged += new System.EventHandler(this.lookUpEdit属性_EditValueChanged);
            // 
            // chk0
            // 
            this.chk0.AutoSize = true;
            this.chk0.Location = new System.Drawing.Point(355, 21);
            this.chk0.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.chk0.Name = "chk0";
            this.chk0.Size = new System.Drawing.Size(128, 22);
            this.chk0.TabIndex = 47;
            this.chk0.Text = "包括下单数量0";
            this.chk0.UseVisualStyleBackColor = true;
            this.chk0.CheckedChanged += new System.EventHandler(this.chk0_CheckedChanged);
            // 
            // radio手工
            // 
            this.radio手工.AutoSize = true;
            this.radio手工.Enabled = false;
            this.radio手工.ForeColor = System.Drawing.Color.Blue;
            this.radio手工.Location = new System.Drawing.Point(201, 21);
            this.radio手工.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.radio手工.Name = "radio手工";
            this.radio手工.Size = new System.Drawing.Size(89, 22);
            this.radio手工.TabIndex = 46;
            this.radio手工.Text = "手工排程";
            this.radio手工.UseVisualStyleBackColor = true;
            // 
            // chk全选
            // 
            this.chk全选.AutoSize = true;
            this.chk全选.Enabled = false;
            this.chk全选.Location = new System.Drawing.Point(291, 21);
            this.chk全选.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.chk全选.Name = "chk全选";
            this.chk全选.Size = new System.Drawing.Size(60, 22);
            this.chk全选.TabIndex = 45;
            this.chk全选.Text = "全选";
            this.chk全选.UseVisualStyleBackColor = true;
            this.chk全选.CheckedChanged += new System.EventHandler(this.chk全选_CheckedChanged);
            // 
            // txt存货编码
            // 
            this.txt存货编码.Enabled = false;
            this.txt存货编码.Location = new System.Drawing.Point(800, 18);
            this.txt存货编码.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txt存货编码.Name = "txt存货编码";
            this.txt存货编码.Size = new System.Drawing.Size(82, 24);
            this.txt存货编码.TabIndex = 44;
            // 
            // btnChange
            // 
            this.btnChange.Enabled = false;
            this.btnChange.Location = new System.Drawing.Point(1463, 18);
            this.btnChange.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnChange.Name = "btnChange";
            this.btnChange.Size = new System.Drawing.Size(65, 30);
            this.btnChange.TabIndex = 43;
            this.btnChange.Text = "批改";
            this.btnChange.UseVisualStyleBackColor = true;
            this.btnChange.Click += new System.EventHandler(this.btnChange_Click);
            // 
            // radio逆排
            // 
            this.radio逆排.AutoSize = true;
            this.radio逆排.Checked = true;
            this.radio逆排.Enabled = false;
            this.radio逆排.ForeColor = System.Drawing.Color.Blue;
            this.radio逆排.Location = new System.Drawing.Point(7, 21);
            this.radio逆排.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.radio逆排.Name = "radio逆排";
            this.radio逆排.Size = new System.Drawing.Size(89, 22);
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
            this.radio顺排.Location = new System.Drawing.Point(97, 21);
            this.radio顺排.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.radio顺排.Name = "radio顺排";
            this.radio顺排.Size = new System.Drawing.Size(89, 22);
            this.radio顺排.TabIndex = 38;
            this.radio顺排.Text = "顺推排程";
            this.radio顺排.UseVisualStyleBackColor = true;
            this.radio顺排.CheckedChanged += new System.EventHandler(this.radio_CheckedChanged);
            // 
            // txt备注
            // 
            this.txt备注.Enabled = false;
            this.txt备注.Location = new System.Drawing.Point(92, 40);
            this.txt备注.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txt备注.Name = "txt备注";
            this.txt备注.Size = new System.Drawing.Size(1203, 24);
            this.txt备注.StyleController = this.layoutControl1;
            this.txt备注.TabIndex = 24;
            // 
            // txt客户订单号
            // 
            this.txt客户订单号.Enabled = false;
            this.txt客户订单号.Location = new System.Drawing.Point(669, 12);
            this.txt客户订单号.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txt客户订单号.Name = "txt客户订单号";
            this.txt客户订单号.Size = new System.Drawing.Size(365, 24);
            this.txt客户订单号.StyleController = this.layoutControl1;
            this.txt客户订单号.TabIndex = 27;
            // 
            // txt销售订单号
            // 
            this.txt销售订单号.Enabled = false;
            this.txt销售订单号.Location = new System.Drawing.Point(92, 12);
            this.txt销售订单号.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txt销售订单号.Name = "txt销售订单号";
            this.txt销售订单号.Size = new System.Drawing.Size(203, 24);
            this.txt销售订单号.StyleController = this.layoutControl1;
            this.txt销售订单号.TabIndex = 9;
            // 
            // txt外销订单号
            // 
            this.txt外销订单号.Enabled = false;
            this.txt外销订单号.Location = new System.Drawing.Point(379, 12);
            this.txt外销订单号.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txt外销订单号.Name = "txt外销订单号";
            this.txt外销订单号.Size = new System.Drawing.Size(206, 24);
            this.txt外销订单号.StyleController = this.layoutControl1;
            this.txt外销订单号.TabIndex = 26;
            // 
            // layoutControlGroup1
            // 
            this.layoutControlGroup1.CustomizationFormText = "layoutControlGroup1";
            this.layoutControlGroup1.EnableIndentsWithoutBorders = DevExpress.Utils.DefaultBoolean.True;
            this.layoutControlGroup1.GroupBordersVisible = false;
            this.layoutControlGroup1.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.layoutControlItem2,
            this.layoutControlItem6,
            this.layoutControlItem29,
            this.layoutControlItem19,
            this.layoutControlItem3,
            this.layoutControlItem7,
            this.layoutControlItem1,
            this.layoutControlItem5,
            this.layoutControlItem30,
            this.layoutControlItem8,
            this.layoutControlItem9});
            this.layoutControlGroup1.Location = new System.Drawing.Point(0, 0);
            this.layoutControlGroup1.Name = "Root";
            this.layoutControlGroup1.Size = new System.Drawing.Size(1568, 469);
            this.layoutControlGroup1.Text = "Root";
            this.layoutControlGroup1.TextVisible = false;
            // 
            // layoutControlItem2
            // 
            this.layoutControlItem2.Control = this.txt销售订单号;
            this.layoutControlItem2.CustomizationFormText = "销售订单号";
            this.layoutControlItem2.Location = new System.Drawing.Point(0, 0);
            this.layoutControlItem2.Name = "layoutControlItem2";
            this.layoutControlItem2.Size = new System.Drawing.Size(287, 28);
            this.layoutControlItem2.Text = "销售订单号";
            this.layoutControlItem2.TextSize = new System.Drawing.Size(76, 18);
            // 
            // layoutControlItem6
            // 
            this.layoutControlItem6.Control = this.txt外销订单号;
            this.layoutControlItem6.CustomizationFormText = "外销订单号";
            this.layoutControlItem6.Location = new System.Drawing.Point(287, 0);
            this.layoutControlItem6.Name = "layoutControlItem6";
            this.layoutControlItem6.Size = new System.Drawing.Size(290, 28);
            this.layoutControlItem6.Text = "外销订单号";
            this.layoutControlItem6.TextSize = new System.Drawing.Size(76, 18);
            // 
            // layoutControlItem29
            // 
            this.layoutControlItem29.Control = this.groupBox1;
            this.layoutControlItem29.CustomizationFormText = "排程方式";
            this.layoutControlItem29.Location = new System.Drawing.Point(0, 84);
            this.layoutControlItem29.MaxSize = new System.Drawing.Size(0, 53);
            this.layoutControlItem29.MinSize = new System.Drawing.Size(104, 53);
            this.layoutControlItem29.Name = "layoutControlItem29";
            this.layoutControlItem29.Size = new System.Drawing.Size(1548, 53);
            this.layoutControlItem29.SizeConstraintsType = DevExpress.XtraLayout.SizeConstraintsType.Custom;
            this.layoutControlItem29.Text = "排程方式";
            this.layoutControlItem29.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem29.TextToControlDistance = 0;
            this.layoutControlItem29.TextVisible = false;
            // 
            // layoutControlItem19
            // 
            this.layoutControlItem19.Control = this.txt备注;
            this.layoutControlItem19.CustomizationFormText = "备注";
            this.layoutControlItem19.Location = new System.Drawing.Point(0, 28);
            this.layoutControlItem19.Name = "layoutControlItem19";
            this.layoutControlItem19.Size = new System.Drawing.Size(1287, 28);
            this.layoutControlItem19.Text = "备注";
            this.layoutControlItem19.TextSize = new System.Drawing.Size(76, 18);
            // 
            // layoutControlItem3
            // 
            this.layoutControlItem3.Control = this.tabControl1;
            this.layoutControlItem3.CustomizationFormText = "layoutControlItem3";
            this.layoutControlItem3.Location = new System.Drawing.Point(0, 137);
            this.layoutControlItem3.Name = "layoutControlItem3";
            this.layoutControlItem3.Size = new System.Drawing.Size(1548, 312);
            this.layoutControlItem3.Text = "layoutControlItem3";
            this.layoutControlItem3.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem3.TextToControlDistance = 0;
            this.layoutControlItem3.TextVisible = false;
            // 
            // layoutControlItem7
            // 
            this.layoutControlItem7.Control = this.txt客户订单号;
            this.layoutControlItem7.CustomizationFormText = "客户订单号";
            this.layoutControlItem7.Location = new System.Drawing.Point(577, 0);
            this.layoutControlItem7.Name = "layoutControlItem7";
            this.layoutControlItem7.Size = new System.Drawing.Size(449, 28);
            this.layoutControlItem7.Text = "客户订单号";
            this.layoutControlItem7.TextSize = new System.Drawing.Size(76, 18);
            // 
            // layoutControlItem1
            // 
            this.layoutControlItem1.Control = this.lookUpEdit客户;
            this.layoutControlItem1.CustomizationFormText = "客户简称";
            this.layoutControlItem1.Location = new System.Drawing.Point(1026, 0);
            this.layoutControlItem1.Name = "layoutControlItem1";
            this.layoutControlItem1.Size = new System.Drawing.Size(522, 28);
            this.layoutControlItem1.Text = "客户简称";
            this.layoutControlItem1.TextSize = new System.Drawing.Size(76, 18);
            // 
            // layoutControlItem5
            // 
            this.layoutControlItem5.Control = this.txt评审备注;
            this.layoutControlItem5.CustomizationFormText = "评审备注";
            this.layoutControlItem5.Location = new System.Drawing.Point(0, 56);
            this.layoutControlItem5.Name = "layoutControlItem5";
            this.layoutControlItem5.Size = new System.Drawing.Size(1025, 28);
            this.layoutControlItem5.Text = "评审备注";
            this.layoutControlItem5.TextSize = new System.Drawing.Size(76, 18);
            // 
            // layoutControlItem30
            // 
            this.layoutControlItem30.Control = this.txt销售订单ID;
            this.layoutControlItem30.CustomizationFormText = "销售订单ID";
            this.layoutControlItem30.Location = new System.Drawing.Point(1287, 28);
            this.layoutControlItem30.Name = "layoutControlItem30";
            this.layoutControlItem30.Size = new System.Drawing.Size(261, 28);
            this.layoutControlItem30.Text = "销售订单ID";
            this.layoutControlItem30.TextSize = new System.Drawing.Size(76, 18);
            // 
            // layoutControlItem8
            // 
            this.layoutControlItem8.Control = this.dtm审核;
            this.layoutControlItem8.CustomizationFormText = "审核日期";
            this.layoutControlItem8.Location = new System.Drawing.Point(1285, 56);
            this.layoutControlItem8.Name = "layoutControlItem8";
            this.layoutControlItem8.Size = new System.Drawing.Size(263, 28);
            this.layoutControlItem8.Text = "审核日期";
            this.layoutControlItem8.TextSize = new System.Drawing.Size(76, 18);
            // 
            // layoutControlItem9
            // 
            this.layoutControlItem9.Control = this.txt审核人;
            this.layoutControlItem9.CustomizationFormText = "审核人";
            this.layoutControlItem9.Location = new System.Drawing.Point(1025, 56);
            this.layoutControlItem9.Name = "layoutControlItem9";
            this.layoutControlItem9.Size = new System.Drawing.Size(260, 28);
            this.layoutControlItem9.Text = "审核人";
            this.layoutControlItem9.TextSize = new System.Drawing.Size(76, 18);
            // 
            // layoutControlItem4
            // 
            this.layoutControlItem4.Control = this.txt销售订单号;
            this.layoutControlItem4.CustomizationFormText = "销售订单号";
            this.layoutControlItem4.Location = new System.Drawing.Point(351, 0);
            this.layoutControlItem4.Name = "layoutControlItem2";
            this.layoutControlItem4.Size = new System.Drawing.Size(118, 25);
            this.layoutControlItem4.Text = "销售订单号";
            this.layoutControlItem4.TextSize = new System.Drawing.Size(60, 14);
            this.layoutControlItem4.TextToControlDistance = 5;
            // 
            // Frm订单评审_维护
            // 
            this.Appearance.BackColor = System.Drawing.SystemColors.Control;
            this.Appearance.Options.UseBackColor = true;
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 18F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1566, 507);
            this.Controls.Add(this.layoutControl1);
            this.Margin = new System.Windows.Forms.Padding(3, 5, 3, 5);
            this.Name = "Frm订单评审_维护";
            this.Text = "订单评审_维护";
            this.Load += new System.EventHandler(this.Frm订单评审_维护_Load);
            this.Controls.SetChildIndex(this.layoutControl1, 0);
            ((System.ComponentModel.ISupportInitialize)(this.dsPrint)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dsForm)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtSel)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControl1)).EndInit();
            this.layoutControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.txt审核人.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtm审核.Properties.VistaTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtm审核.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txt评审备注.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lookUpEdit客户.Properties)).EndInit();
            this.tabControl1.ResumeLayout(false);
            this.tabPage2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gridControl评审维护)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView评审维护)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ItemLookUpEdit物料编码)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ItemLookUpEdit物料名称)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ItemLookUpEdit规格型号)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ItemLookUpEdit子件属性)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ItemLookUpEdit仓库编号)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ItemLookUpEdit仓库名称)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ItemLookUpEdit部门编码)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ItemLookUpEdit部门名称)).EndInit();
            this.tabPage1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gridControl销售订单列表)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView销售订单列表)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ItemLookUpEdit1存货编码)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ItemLookUpEdit1存货名称)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ItemLookUpEdit1规格型号)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txt销售订单ID.Properties)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dtm完成日期.Properties.VistaTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtm完成日期.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtm开始日期.Properties.VistaTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtm开始日期.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lookUpEdit属性.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txt存货编码.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txt备注.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txt客户订单号.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txt销售订单号.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txt外销订单号.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem6)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem29)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem19)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem7)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem5)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem30)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem8)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem9)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem4)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraLayout.LayoutControl layoutControl1;
        private DevExpress.XtraLayout.LayoutControlGroup layoutControlGroup1;
        private DevExpress.XtraEditors.TextEdit txt备注;
        private DevExpress.XtraEditors.TextEdit txt销售订单号;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem2;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem4;
        private DevExpress.XtraEditors.TextEdit txt外销订单号;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem6;
        private DevExpress.XtraEditors.TextEdit txt客户订单号;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem7;
        private System.Windows.Forms.RadioButton radio逆排;
        private System.Windows.Forms.RadioButton radio顺排;
        private System.Windows.Forms.GroupBox groupBox1;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem29;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem19;
        private System.Windows.Forms.Button btnChange;
        private DevExpress.XtraEditors.TextEdit txt存货编码;
        private DevExpress.XtraEditors.TextEdit txt销售订单ID;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem30;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private DevExpress.XtraGrid.GridControl gridControl销售订单列表;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView销售订单列表;
        private DevExpress.XtraGrid.Columns.GridColumn gridCol1订单子表ID;
        private DevExpress.XtraGrid.Columns.GridColumn gridCol1存货编码;
        private DevExpress.XtraGrid.Columns.GridColumn gridCol1存货名称;
        private DevExpress.XtraGrid.Columns.GridColumn gridCol1规格型号;
        private DevExpress.XtraGrid.Columns.GridColumn gridCol1主计量编码;
        private DevExpress.XtraGrid.Columns.GridColumn gridCol1主计量;
        private DevExpress.XtraGrid.Columns.GridColumn gridCol1数量;
        private DevExpress.XtraGrid.Columns.GridColumn gridCol1船期;
        private DevExpress.XtraGrid.Columns.GridColumn gridCol1国外要求交期;
        private DevExpress.XtraGrid.Columns.GridColumn gridCol1预完工日期;
        private DevExpress.XtraGrid.Columns.GridColumn gridCol1评审下达完工日期;
        private DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit ItemLookUpEdit1存货编码;
        private DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit ItemLookUpEdit1存货名称;
        private System.Windows.Forms.TabPage tabPage2;
        private DevExpress.XtraGrid.GridControl gridControl评审维护;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView评审维护;
        private DevExpress.XtraGrid.Columns.GridColumn gridCol根母件;
        private DevExpress.XtraGrid.Columns.GridColumn gridCol级别;
        private DevExpress.XtraGrid.Columns.GridColumn gridCol母件编码;
        private DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit ItemLookUpEdit物料编码;
        private DevExpress.XtraGrid.Columns.GridColumn gridCol母件名称;
        private DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit ItemLookUpEdit物料名称;
        private DevExpress.XtraGrid.Columns.GridColumn gridCol母件计量单位;
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
        private DevExpress.XtraGrid.Columns.GridColumn gridCol仓库名称;
        private DevExpress.XtraGrid.Columns.GridColumn gridCol领料部门代号;
        private DevExpress.XtraGrid.Columns.GridColumn gridCol领料部门名称;
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
        private DevExpress.XtraGrid.Columns.GridColumn gridColiID;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem3;
        private DevExpress.XtraGrid.Columns.GridColumn gridCol1评审数量;
        private DevExpress.XtraGrid.Columns.GridColumn gridCol1销售订单行号;
        private DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit ItemLookUpEdit1规格型号;
        private DevExpress.XtraEditors.LookUpEdit lookUpEdit客户;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem1;
        private DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit ItemLookUpEdit仓库编号;
        private DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit ItemLookUpEdit仓库名称;
        private DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit ItemLookUpEdit部门编码;
        private DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit ItemLookUpEdit部门名称;
        private DevExpress.XtraGrid.Columns.GridColumn gridCol母件规格;
        private DevExpress.XtraGrid.Columns.GridColumn gridCol单件生产工时;
        private DevExpress.XtraGrid.Columns.GridColumn gridCol生产工时;
        private DevExpress.XtraGrid.Columns.GridColumn gridCol销售订单行号;
        private DevExpress.XtraGrid.Columns.GridColumn gridCol下单量;
        private DevExpress.XtraGrid.Columns.GridColumn gridCol累计下单量;
        private DevExpress.XtraGrid.Columns.GridColumn gridCol累计待入库;
        private DevExpress.XtraEditors.TextEdit txt评审备注;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem5;
        private DevExpress.XtraGrid.Columns.GridColumn gridCol回签日期1;
        private DevExpress.XtraGrid.Columns.GridColumn gridCol回签日期2;
        private DevExpress.XtraGrid.Columns.GridColumn gridCol选择;
        private System.Windows.Forms.CheckBox chk全选;
        private DevExpress.XtraEditors.TextEdit txt审核人;
        private DevExpress.XtraEditors.DateEdit dtm审核;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem8;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem9;
        private System.Windows.Forms.RadioButton radio手工;
        private DevExpress.XtraGrid.Columns.GridColumn gridCol待出库量;
        private DevExpress.XtraGrid.Columns.GridColumn gridCol母子对应;
        private System.Windows.Forms.CheckBox chk0;
        private DevExpress.XtraEditors.LookUpEdit lookUpEdit属性;
        private System.Windows.Forms.Button btn选择;
        private System.Windows.Forms.Label label1;
        private DevExpress.XtraEditors.DateEdit dtm完成日期;
        private System.Windows.Forms.CheckBox chk完成日期;
        private DevExpress.XtraEditors.DateEdit dtm开始日期;
        private System.Windows.Forms.CheckBox chk开始日期;
        private DevExpress.XtraGrid.Columns.GridColumn gridCol调整数量;
        private System.Windows.Forms.Button btn回签日期核查;
        private System.Windows.Forms.Button btn15天核查;
    }
}