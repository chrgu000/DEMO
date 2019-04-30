namespace ImportDLL
{
    partial class Frm销售发票导入
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
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.radioT6存货编码 = new System.Windows.Forms.RadioButton();
            this.radio客户编码 = new System.Windows.Forms.RadioButton();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.radio含税 = new System.Windows.Forms.RadioButton();
            this.radio不含税 = new System.Windows.Forms.RadioButton();
            this.groupBox5 = new System.Windows.Forms.GroupBox();
            this.radioT6单号 = new System.Windows.Forms.RadioButton();
            this.radio客户单号 = new System.Windows.Forms.RadioButton();
            this.gridControl1 = new DevExpress.XtraGrid.GridControl();
            this.gridView1 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.gridCol序号 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridCol订单号 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.ItemLookUpEdit订单号 = new DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit();
            this.gridCol客户订单号 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridCol零件号码 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColT6存货编码 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.ItemLookUpEdit物料 = new DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit();
            this.gridCol地区 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridCol名称 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridCol组别 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridCol数量 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridCol单价 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridCol总价含税 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridCol总价不含税 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridCol作番号 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridCol完纳单号 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridCol完纳日期 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridCol仓库 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.ItemLookUpEdit仓库 = new DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit();
            this.layoutControlItem2 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem5 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlGroup1 = new DevExpress.XtraLayout.LayoutControlGroup();
            this.layoutControlItem3 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem1 = new DevExpress.XtraLayout.LayoutControlItem();
            this.emptySpaceItem1 = new DevExpress.XtraLayout.EmptySpaceItem();
            this.layoutControlItem4 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem6 = new DevExpress.XtraLayout.LayoutControlItem();
            ((System.ComponentModel.ISupportInitialize)(this.dsPrint)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dsForm)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtSel)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControl1)).BeginInit();
            this.layoutControl1.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.groupBox5.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ItemLookUpEdit订单号)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ItemLookUpEdit物料)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ItemLookUpEdit仓库)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem5)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem6)).BeginInit();
            this.SuspendLayout();
            // 
            // layoutControl1
            // 
            this.layoutControl1.AllowCustomizationMenu = false;
            this.layoutControl1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.layoutControl1.Controls.Add(this.groupBox4);
            this.layoutControl1.Controls.Add(this.groupBox3);
            this.layoutControl1.Controls.Add(this.groupBox2);
            this.layoutControl1.Controls.Add(this.groupBox1);
            this.layoutControl1.Controls.Add(this.groupBox5);
            this.layoutControl1.Controls.Add(this.gridControl1);
            this.layoutControl1.HiddenItems.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.layoutControlItem2,
            this.layoutControlItem5});
            this.layoutControl1.Location = new System.Drawing.Point(0, 28);
            this.layoutControl1.Name = "layoutControl1";
            this.layoutControl1.OptionsCustomizationForm.DesignTimeCustomizationFormPositionAndSize = new System.Drawing.Rectangle(467, 317, 250, 350);
            this.layoutControl1.OptionsCustomizationForm.ShowLoadButton = false;
            this.layoutControl1.OptionsCustomizationForm.ShowSaveButton = false;
            this.layoutControl1.OptionsView.UseDefaultDragAndDropRendering = false;
            this.layoutControl1.Root = this.layoutControlGroup1;
            this.layoutControl1.Size = new System.Drawing.Size(1199, 411);
            this.layoutControl1.TabIndex = 5;
            this.layoutControl1.Text = "layoutControl1";
            // 
            // groupBox4
            // 
            this.groupBox4.Location = new System.Drawing.Point(658, 12);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(100, 44);
            this.groupBox4.TabIndex = 10;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "groupBox4";
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.radioT6存货编码);
            this.groupBox3.Controls.Add(this.radio客户编码);
            this.groupBox3.Location = new System.Drawing.Point(246, 12);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(320, 44);
            this.groupBox3.TabIndex = 9;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "存货编码规则";
            // 
            // radioT6存货编码
            // 
            this.radioT6存货编码.Location = new System.Drawing.Point(154, 13);
            this.radioT6存货编码.Name = "radioT6存货编码";
            this.radioT6存货编码.Size = new System.Drawing.Size(100, 25);
            this.radioT6存货编码.TabIndex = 11;
            this.radioT6存货编码.Text = "T6存货编码";
            this.radioT6存货编码.UseVisualStyleBackColor = true;
            // 
            // radio客户编码
            // 
            this.radio客户编码.Checked = true;
            this.radio客户编码.Location = new System.Drawing.Point(19, 13);
            this.radio客户编码.Name = "radio客户编码";
            this.radio客户编码.Size = new System.Drawing.Size(100, 25);
            this.radio客户编码.TabIndex = 10;
            this.radio客户编码.TabStop = true;
            this.radio客户编码.Text = "客户存货编码";
            this.radio客户编码.UseVisualStyleBackColor = true;
            // 
            // groupBox2
            // 
            this.groupBox2.Location = new System.Drawing.Point(346, 12);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(100, 44);
            this.groupBox2.TabIndex = 8;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "groupBox2";
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.groupBox1.Controls.Add(this.radio含税);
            this.groupBox1.Controls.Add(this.radio不含税);
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(230, 44);
            this.groupBox1.TabIndex = 7;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "计价方式";
            // 
            // radio含税
            // 
            this.radio含税.Checked = true;
            this.radio含税.Location = new System.Drawing.Point(6, 13);
            this.radio含税.Name = "radio含税";
            this.radio含税.Size = new System.Drawing.Size(100, 25);
            this.radio含税.TabIndex = 9;
            this.radio含税.TabStop = true;
            this.radio含税.Text = "总价含税";
            this.radio含税.UseVisualStyleBackColor = true;
            // 
            // radio不含税
            // 
            this.radio不含税.Location = new System.Drawing.Point(112, 13);
            this.radio不含税.Name = "radio不含税";
            this.radio不含税.Size = new System.Drawing.Size(100, 25);
            this.radio不含税.TabIndex = 8;
            this.radio不含税.Text = "总价不含税";
            this.radio不含税.UseVisualStyleBackColor = true;
            // 
            // groupBox5
            // 
            this.groupBox5.Controls.Add(this.radioT6单号);
            this.groupBox5.Controls.Add(this.radio客户单号);
            this.groupBox5.Location = new System.Drawing.Point(570, 12);
            this.groupBox5.Name = "groupBox5";
            this.groupBox5.Size = new System.Drawing.Size(296, 44);
            this.groupBox5.TabIndex = 11;
            this.groupBox5.TabStop = false;
            this.groupBox5.Text = "订单规则";
            // 
            // radioT6单号
            // 
            this.radioT6单号.Location = new System.Drawing.Point(137, 13);
            this.radioT6单号.Name = "radioT6单号";
            this.radioT6单号.Size = new System.Drawing.Size(100, 25);
            this.radioT6单号.TabIndex = 12;
            this.radioT6单号.Text = "T6单号";
            this.radioT6单号.UseVisualStyleBackColor = true;
            // 
            // radio客户单号
            // 
            this.radio客户单号.Checked = true;
            this.radio客户单号.Location = new System.Drawing.Point(20, 13);
            this.radio客户单号.Name = "radio客户单号";
            this.radio客户单号.Size = new System.Drawing.Size(100, 25);
            this.radio客户单号.TabIndex = 11;
            this.radio客户单号.TabStop = true;
            this.radio客户单号.Text = "客户单号";
            this.radio客户单号.UseVisualStyleBackColor = true;
            // 
            // gridControl1
            // 
            this.gridControl1.Location = new System.Drawing.Point(12, 60);
            this.gridControl1.MainView = this.gridView1;
            this.gridControl1.Name = "gridControl1";
            this.gridControl1.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.ItemLookUpEdit物料,
            this.ItemLookUpEdit仓库,
            this.ItemLookUpEdit订单号});
            this.gridControl1.Size = new System.Drawing.Size(1175, 339);
            this.gridControl1.TabIndex = 6;
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
            this.gridCol序号,
            this.gridCol订单号,
            this.gridCol客户订单号,
            this.gridCol零件号码,
            this.gridColT6存货编码,
            this.gridCol地区,
            this.gridCol名称,
            this.gridCol组别,
            this.gridCol数量,
            this.gridCol单价,
            this.gridCol总价含税,
            this.gridCol总价不含税,
            this.gridCol作番号,
            this.gridCol完纳单号,
            this.gridCol完纳日期,
            this.gridCol仓库});
            this.gridView1.GridControl = this.gridControl1;
            this.gridView1.IndicatorWidth = 40;
            this.gridView1.Name = "gridView1";
            this.gridView1.OptionsLayout.Columns.StoreAllOptions = true;
            this.gridView1.OptionsLayout.Columns.StoreAppearance = true;
            this.gridView1.OptionsLayout.StoreAllOptions = true;
            this.gridView1.OptionsLayout.StoreAppearance = true;
            this.gridView1.OptionsMenu.ShowAddNewSummaryItem = DevExpress.Utils.DefaultBoolean.True;
            this.gridView1.OptionsMenu.ShowGroupSummaryEditorItem = true;
            this.gridView1.OptionsNavigation.AutoFocusNewRow = true;
            this.gridView1.OptionsSelection.MultiSelect = true;
            this.gridView1.OptionsView.AutoCalcPreviewLineCount = true;
            this.gridView1.OptionsView.ColumnAutoWidth = false;
            this.gridView1.OptionsView.EnableAppearanceEvenRow = true;
            this.gridView1.OptionsView.EnableAppearanceOddRow = true;
            this.gridView1.OptionsView.ShowFooter = true;
            this.gridView1.OptionsView.ShowGroupPanel = false;
            this.gridView1.CustomDrawRowIndicator += new DevExpress.XtraGrid.Views.Grid.RowIndicatorCustomDrawEventHandler(this.gridView1_CustomDrawRowIndicator);
            // 
            // gridCol序号
            // 
            this.gridCol序号.Caption = "序号";
            this.gridCol序号.FieldName = "序号";
            this.gridCol序号.Name = "gridCol序号";
            this.gridCol序号.OptionsColumn.AllowEdit = false;
            this.gridCol序号.Visible = true;
            this.gridCol序号.VisibleIndex = 2;
            this.gridCol序号.Width = 42;
            // 
            // gridCol订单号
            // 
            this.gridCol订单号.Caption = "T6单号";
            this.gridCol订单号.ColumnEdit = this.ItemLookUpEdit订单号;
            this.gridCol订单号.FieldName = "T6单号";
            this.gridCol订单号.Name = "gridCol订单号";
            this.gridCol订单号.OptionsColumn.AllowEdit = false;
            this.gridCol订单号.Visible = true;
            this.gridCol订单号.VisibleIndex = 0;
            this.gridCol订单号.Width = 132;
            // 
            // ItemLookUpEdit订单号
            // 
            this.ItemLookUpEdit订单号.AutoHeight = false;
            this.ItemLookUpEdit订单号.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.ItemLookUpEdit订单号.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("cSOCode", "订单号")});
            this.ItemLookUpEdit订单号.DisplayMember = "cSOCode";
            this.ItemLookUpEdit订单号.Name = "ItemLookUpEdit订单号";
            this.ItemLookUpEdit订单号.NullText = "";
            this.ItemLookUpEdit订单号.ValueMember = "cSOCode";
            // 
            // gridCol客户订单号
            // 
            this.gridCol客户订单号.Caption = "客户订单号";
            this.gridCol客户订单号.FieldName = "客户订单号";
            this.gridCol客户订单号.Name = "gridCol客户订单号";
            this.gridCol客户订单号.Visible = true;
            this.gridCol客户订单号.VisibleIndex = 1;
            this.gridCol客户订单号.Width = 125;
            // 
            // gridCol零件号码
            // 
            this.gridCol零件号码.Caption = "客户存货编码";
            this.gridCol零件号码.FieldName = "零件号码";
            this.gridCol零件号码.Name = "gridCol零件号码";
            this.gridCol零件号码.OptionsColumn.AllowEdit = false;
            this.gridCol零件号码.Visible = true;
            this.gridCol零件号码.VisibleIndex = 3;
            this.gridCol零件号码.Width = 112;
            // 
            // gridColT6存货编码
            // 
            this.gridColT6存货编码.Caption = "T6存货编码";
            this.gridColT6存货编码.ColumnEdit = this.ItemLookUpEdit物料;
            this.gridColT6存货编码.FieldName = "产品编码";
            this.gridColT6存货编码.Name = "gridColT6存货编码";
            this.gridColT6存货编码.Visible = true;
            this.gridColT6存货编码.VisibleIndex = 4;
            this.gridColT6存货编码.Width = 104;
            // 
            // ItemLookUpEdit物料
            // 
            this.ItemLookUpEdit物料.AutoHeight = false;
            this.ItemLookUpEdit物料.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.ItemLookUpEdit物料.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("cInvCode", "存货编码"),
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("cInvName", "存货名称"),
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("cInvStd", "规格型号")});
            this.ItemLookUpEdit物料.DisplayMember = "cInvCode";
            this.ItemLookUpEdit物料.Name = "ItemLookUpEdit物料";
            this.ItemLookUpEdit物料.NullText = "";
            this.ItemLookUpEdit物料.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.Standard;
            this.ItemLookUpEdit物料.ValueMember = "cInvCode";
            // 
            // gridCol地区
            // 
            this.gridCol地区.Caption = "地区";
            this.gridCol地区.FieldName = "地区";
            this.gridCol地区.Name = "gridCol地区";
            this.gridCol地区.OptionsColumn.AllowEdit = false;
            this.gridCol地区.Visible = true;
            this.gridCol地区.VisibleIndex = 5;
            this.gridCol地区.Width = 89;
            // 
            // gridCol名称
            // 
            this.gridCol名称.Caption = "名称";
            this.gridCol名称.FieldName = "名称";
            this.gridCol名称.Name = "gridCol名称";
            this.gridCol名称.OptionsColumn.AllowEdit = false;
            this.gridCol名称.Visible = true;
            this.gridCol名称.VisibleIndex = 6;
            // 
            // gridCol组别
            // 
            this.gridCol组别.Caption = "组别";
            this.gridCol组别.FieldName = "组别";
            this.gridCol组别.Name = "gridCol组别";
            this.gridCol组别.OptionsColumn.AllowEdit = false;
            this.gridCol组别.Visible = true;
            this.gridCol组别.VisibleIndex = 7;
            // 
            // gridCol数量
            // 
            this.gridCol数量.Caption = "数量";
            this.gridCol数量.FieldName = "数量";
            this.gridCol数量.Name = "gridCol数量";
            this.gridCol数量.OptionsColumn.AllowEdit = false;
            this.gridCol数量.Summary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] {
            new DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum)});
            this.gridCol数量.Visible = true;
            this.gridCol数量.VisibleIndex = 8;
            this.gridCol数量.Width = 84;
            // 
            // gridCol单价
            // 
            this.gridCol单价.Caption = "单价";
            this.gridCol单价.FieldName = "单价";
            this.gridCol单价.Name = "gridCol单价";
            this.gridCol单价.OptionsColumn.AllowEdit = false;
            this.gridCol单价.Visible = true;
            this.gridCol单价.VisibleIndex = 9;
            this.gridCol单价.Width = 90;
            // 
            // gridCol总价含税
            // 
            this.gridCol总价含税.Caption = "总价含税";
            this.gridCol总价含税.FieldName = "总价(含税)";
            this.gridCol总价含税.Name = "gridCol总价含税";
            this.gridCol总价含税.OptionsColumn.AllowEdit = false;
            this.gridCol总价含税.Summary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] {
            new DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum)});
            this.gridCol总价含税.Visible = true;
            this.gridCol总价含税.VisibleIndex = 10;
            this.gridCol总价含税.Width = 64;
            // 
            // gridCol总价不含税
            // 
            this.gridCol总价不含税.Caption = "总价不含税";
            this.gridCol总价不含税.FieldName = "总价(不含税)";
            this.gridCol总价不含税.Name = "gridCol总价不含税";
            this.gridCol总价不含税.OptionsColumn.AllowEdit = false;
            this.gridCol总价不含税.Summary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] {
            new DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum)});
            this.gridCol总价不含税.Visible = true;
            this.gridCol总价不含税.VisibleIndex = 11;
            // 
            // gridCol作番号
            // 
            this.gridCol作番号.Caption = "作番号";
            this.gridCol作番号.FieldName = "作番号";
            this.gridCol作番号.Name = "gridCol作番号";
            this.gridCol作番号.OptionsColumn.AllowEdit = false;
            this.gridCol作番号.Visible = true;
            this.gridCol作番号.VisibleIndex = 12;
            // 
            // gridCol完纳单号
            // 
            this.gridCol完纳单号.Caption = "完纳单号";
            this.gridCol完纳单号.FieldName = "完纳单号";
            this.gridCol完纳单号.Name = "gridCol完纳单号";
            this.gridCol完纳单号.OptionsColumn.AllowEdit = false;
            this.gridCol完纳单号.Visible = true;
            this.gridCol完纳单号.VisibleIndex = 13;
            // 
            // gridCol完纳日期
            // 
            this.gridCol完纳日期.Caption = "完纳日期";
            this.gridCol完纳日期.DisplayFormat.FormatString = "d";
            this.gridCol完纳日期.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.gridCol完纳日期.FieldName = "完纳日期";
            this.gridCol完纳日期.Name = "gridCol完纳日期";
            this.gridCol完纳日期.OptionsColumn.AllowEdit = false;
            this.gridCol完纳日期.Visible = true;
            this.gridCol完纳日期.VisibleIndex = 14;
            this.gridCol完纳日期.Width = 90;
            // 
            // gridCol仓库
            // 
            this.gridCol仓库.Caption = "仓库";
            this.gridCol仓库.ColumnEdit = this.ItemLookUpEdit仓库;
            this.gridCol仓库.FieldName = "零件号码";
            this.gridCol仓库.Name = "gridCol仓库";
            this.gridCol仓库.OptionsColumn.AllowEdit = false;
            // 
            // ItemLookUpEdit仓库
            // 
            this.ItemLookUpEdit仓库.AutoHeight = false;
            this.ItemLookUpEdit仓库.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.ItemLookUpEdit仓库.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("cWhCode", "仓库编码")});
            this.ItemLookUpEdit仓库.DisplayMember = "cWhCode";
            this.ItemLookUpEdit仓库.Name = "ItemLookUpEdit仓库";
            this.ItemLookUpEdit仓库.NullText = "";
            this.ItemLookUpEdit仓库.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.Standard;
            this.ItemLookUpEdit仓库.ValueMember = "cWhCode";
            // 
            // layoutControlItem2
            // 
            this.layoutControlItem2.Control = this.groupBox2;
            this.layoutControlItem2.CustomizationFormText = "layoutControlItem2";
            this.layoutControlItem2.Location = new System.Drawing.Point(225, 0);
            this.layoutControlItem2.Name = "layoutControlItem2";
            this.layoutControlItem2.Size = new System.Drawing.Size(213, 48);
            this.layoutControlItem2.Text = "layoutControlItem2";
            this.layoutControlItem2.TextSize = new System.Drawing.Size(50, 20);
            this.layoutControlItem2.TextToControlDistance = 5;
            // 
            // layoutControlItem5
            // 
            this.layoutControlItem5.Control = this.groupBox4;
            this.layoutControlItem5.CustomizationFormText = "layoutControlItem5";
            this.layoutControlItem5.Location = new System.Drawing.Point(537, 0);
            this.layoutControlItem5.Name = "layoutControlItem5";
            this.layoutControlItem5.Size = new System.Drawing.Size(213, 48);
            this.layoutControlItem5.Text = "layoutControlItem5";
            this.layoutControlItem5.TextSize = new System.Drawing.Size(50, 20);
            this.layoutControlItem5.TextToControlDistance = 5;
            // 
            // layoutControlGroup1
            // 
            this.layoutControlGroup1.CustomizationFormText = "layoutControlGroup1";
            this.layoutControlGroup1.EnableIndentsWithoutBorders = DevExpress.Utils.DefaultBoolean.True;
            this.layoutControlGroup1.GroupBordersVisible = false;
            this.layoutControlGroup1.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.layoutControlItem3,
            this.layoutControlItem1,
            this.emptySpaceItem1,
            this.layoutControlItem4,
            this.layoutControlItem6});
            this.layoutControlGroup1.Location = new System.Drawing.Point(0, 0);
            this.layoutControlGroup1.Name = "Root";
            this.layoutControlGroup1.Size = new System.Drawing.Size(1199, 411);
            this.layoutControlGroup1.Text = "Root";
            this.layoutControlGroup1.TextVisible = false;
            // 
            // layoutControlItem3
            // 
            this.layoutControlItem3.Control = this.gridControl1;
            this.layoutControlItem3.CustomizationFormText = "layoutControlItem3";
            this.layoutControlItem3.Location = new System.Drawing.Point(0, 48);
            this.layoutControlItem3.Name = "layoutControlItem3";
            this.layoutControlItem3.Size = new System.Drawing.Size(1179, 343);
            this.layoutControlItem3.Text = "layoutControlItem3";
            this.layoutControlItem3.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem3.TextToControlDistance = 0;
            this.layoutControlItem3.TextVisible = false;
            // 
            // layoutControlItem1
            // 
            this.layoutControlItem1.Control = this.groupBox1;
            this.layoutControlItem1.CustomizationFormText = "layoutControlItem1";
            this.layoutControlItem1.Location = new System.Drawing.Point(0, 0);
            this.layoutControlItem1.MaxSize = new System.Drawing.Size(0, 48);
            this.layoutControlItem1.MinSize = new System.Drawing.Size(104, 48);
            this.layoutControlItem1.Name = "layoutControlItem1";
            this.layoutControlItem1.Size = new System.Drawing.Size(234, 48);
            this.layoutControlItem1.SizeConstraintsType = DevExpress.XtraLayout.SizeConstraintsType.Custom;
            this.layoutControlItem1.Text = "layoutControlItem1";
            this.layoutControlItem1.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem1.TextToControlDistance = 0;
            this.layoutControlItem1.TextVisible = false;
            // 
            // emptySpaceItem1
            // 
            this.emptySpaceItem1.AllowHotTrack = false;
            this.emptySpaceItem1.CustomizationFormText = "emptySpaceItem1";
            this.emptySpaceItem1.Location = new System.Drawing.Point(858, 0);
            this.emptySpaceItem1.MaxSize = new System.Drawing.Size(0, 48);
            this.emptySpaceItem1.MinSize = new System.Drawing.Size(10, 48);
            this.emptySpaceItem1.Name = "emptySpaceItem1";
            this.emptySpaceItem1.Size = new System.Drawing.Size(321, 48);
            this.emptySpaceItem1.SizeConstraintsType = DevExpress.XtraLayout.SizeConstraintsType.Custom;
            this.emptySpaceItem1.Text = "emptySpaceItem1";
            this.emptySpaceItem1.TextSize = new System.Drawing.Size(0, 0);
            // 
            // layoutControlItem4
            // 
            this.layoutControlItem4.Control = this.groupBox3;
            this.layoutControlItem4.CustomizationFormText = "layoutControlItem4";
            this.layoutControlItem4.Location = new System.Drawing.Point(234, 0);
            this.layoutControlItem4.Name = "layoutControlItem4";
            this.layoutControlItem4.Size = new System.Drawing.Size(324, 48);
            this.layoutControlItem4.Text = "layoutControlItem4";
            this.layoutControlItem4.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem4.TextToControlDistance = 0;
            this.layoutControlItem4.TextVisible = false;
            // 
            // layoutControlItem6
            // 
            this.layoutControlItem6.Control = this.groupBox5;
            this.layoutControlItem6.CustomizationFormText = "layoutControlItem6";
            this.layoutControlItem6.Location = new System.Drawing.Point(558, 0);
            this.layoutControlItem6.Name = "layoutControlItem6";
            this.layoutControlItem6.Size = new System.Drawing.Size(300, 48);
            this.layoutControlItem6.Text = "layoutControlItem6";
            this.layoutControlItem6.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem6.TextToControlDistance = 0;
            this.layoutControlItem6.TextVisible = false;
            // 
            // Frm销售发票导入
            // 
            this.Appearance.BackColor = System.Drawing.SystemColors.Control;
            this.Appearance.Options.UseBackColor = true;
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1197, 440);
            this.Controls.Add(this.layoutControl1);
            this.Name = "Frm销售发票导入";
            this.Text = "销售发票导入";
            this.Load += new System.EventHandler(this.Frm_Load);
            this.Controls.SetChildIndex(this.layoutControl1, 0);
            ((System.ComponentModel.ISupportInitialize)(this.dsPrint)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dsForm)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtSel)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControl1)).EndInit();
            this.layoutControl1.ResumeLayout(false);
            this.groupBox3.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.groupBox5.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ItemLookUpEdit订单号)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ItemLookUpEdit物料)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ItemLookUpEdit仓库)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem5)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem6)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraLayout.LayoutControl layoutControl1;
        private DevExpress.XtraGrid.GridControl gridControl1;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView1;
        private DevExpress.XtraLayout.LayoutControlGroup layoutControlGroup1;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem3;
        private DevExpress.XtraGrid.Columns.GridColumn gridCol序号;
        private DevExpress.XtraGrid.Columns.GridColumn gridCol零件号码;
        private DevExpress.XtraGrid.Columns.GridColumn gridCol订单号;
        private DevExpress.XtraGrid.Columns.GridColumn gridCol完纳日期;
        private DevExpress.XtraGrid.Columns.GridColumn gridCol地区;
        private DevExpress.XtraGrid.Columns.GridColumn gridCol名称;
        private DevExpress.XtraGrid.Columns.GridColumn gridCol组别;
        private DevExpress.XtraGrid.Columns.GridColumn gridCol总价不含税;
        private DevExpress.XtraGrid.Columns.GridColumn gridCol作番号;
        private DevExpress.XtraGrid.Columns.GridColumn gridCol完纳单号;
        private DevExpress.XtraGrid.Columns.GridColumn gridCol数量;
        private DevExpress.XtraGrid.Columns.GridColumn gridCol单价;
        private DevExpress.XtraGrid.Columns.GridColumn gridCol总价含税;
        private DevExpress.XtraGrid.Columns.GridColumn gridCol仓库;
        private System.Windows.Forms.GroupBox groupBox1;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem1;
        private System.Windows.Forms.RadioButton radio含税;
        private System.Windows.Forms.RadioButton radio不含税;
        private DevExpress.XtraGrid.Columns.GridColumn gridColT6存货编码;
        private DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit ItemLookUpEdit物料;
        private DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit ItemLookUpEdit仓库;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.RadioButton radioT6存货编码;
        private System.Windows.Forms.RadioButton radio客户编码;
        private System.Windows.Forms.GroupBox groupBox2;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem2;
        private DevExpress.XtraLayout.EmptySpaceItem emptySpaceItem1;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem4;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem5;
        private System.Windows.Forms.GroupBox groupBox5;
        private System.Windows.Forms.RadioButton radioT6单号;
        private System.Windows.Forms.RadioButton radio客户单号;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem6;
        private DevExpress.XtraGrid.Columns.GridColumn gridCol客户订单号;
        private DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit ItemLookUpEdit订单号;
    }
}