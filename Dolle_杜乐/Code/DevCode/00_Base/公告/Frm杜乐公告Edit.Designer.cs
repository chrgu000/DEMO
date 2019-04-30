namespace Base
{
    partial class Frm杜乐公告Edit
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
            DevExpress.XtraGrid.GridLevelNode gridLevelNode1 = new DevExpress.XtraGrid.GridLevelNode();
            this.gridControl1 = new DevExpress.XtraGrid.GridControl();
            this.gridView1 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.gridCol选择 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridCol供应商编码 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridCol供应商名称 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.label1 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.txt主题 = new System.Windows.Forms.TextBox();
            this.richTextBox内容 = new System.Windows.Forms.RichTextBox();
            this.chk全选 = new System.Windows.Forms.CheckBox();
            this.btn发布 = new System.Windows.Forms.Button();
            this.btn删除 = new System.Windows.Forms.Button();
            this.btn保存 = new System.Windows.Forms.Button();
            this.btn取消 = new System.Windows.Forms.Button();
            this.txt制单人 = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txt发布人 = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.date制单日期 = new DevExpress.XtraEditors.DateEdit();
            this.date_发布日期 = new DevExpress.XtraEditors.DateEdit();
            this.btn退出 = new System.Windows.Forms.Button();
            this.radio采购 = new System.Windows.Forms.RadioButton();
            this.radio委外 = new System.Windows.Forms.RadioButton();
            this.radio全部 = new System.Windows.Forms.RadioButton();
            this.radio未设置 = new System.Windows.Forms.RadioButton();
            this.label7 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.date制单日期.Properties.VistaTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.date制单日期.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.date_发布日期.Properties.VistaTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.date_发布日期.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // gridControl1
            // 
            this.gridControl1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.gridControl1.EmbeddedNavigator.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            gridLevelNode1.RelationName = "Level1";
            this.gridControl1.LevelTree.Nodes.AddRange(new DevExpress.XtraGrid.GridLevelNode[] {
            gridLevelNode1});
            this.gridControl1.Location = new System.Drawing.Point(823, 126);
            this.gridControl1.MainView = this.gridView1;
            this.gridControl1.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.gridControl1.Name = "gridControl1";
            this.gridControl1.Size = new System.Drawing.Size(437, 238);
            this.gridControl1.TabIndex = 71;
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
            this.gridCol选择,
            this.gridCol供应商编码,
            this.gridCol供应商名称});
            this.gridView1.CustomizationFormBounds = new System.Drawing.Rectangle(816, 318, 208, 177);
            this.gridView1.GridControl = this.gridControl1;
            this.gridView1.IndicatorWidth = 40;
            this.gridView1.Name = "gridView1";
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
            this.gridView1.CustomDrawRowIndicator += new DevExpress.XtraGrid.Views.Grid.RowIndicatorCustomDrawEventHandler(this.gridView评审_CustomDrawRowIndicator);
            // 
            // gridCol选择
            // 
            this.gridCol选择.Caption = "选择";
            this.gridCol选择.FieldName = "选择";
            this.gridCol选择.Name = "gridCol选择";
            this.gridCol选择.Visible = true;
            this.gridCol选择.VisibleIndex = 0;
            this.gridCol选择.Width = 44;
            // 
            // gridCol供应商编码
            // 
            this.gridCol供应商编码.Caption = "供应商编码";
            this.gridCol供应商编码.FieldName = "供应商编码";
            this.gridCol供应商编码.Name = "gridCol供应商编码";
            this.gridCol供应商编码.OptionsColumn.AllowEdit = false;
            this.gridCol供应商编码.Visible = true;
            this.gridCol供应商编码.VisibleIndex = 1;
            this.gridCol供应商编码.Width = 85;
            // 
            // gridCol供应商名称
            // 
            this.gridCol供应商名称.Caption = "供应商名称";
            this.gridCol供应商名称.FieldName = "供应商名称";
            this.gridCol供应商名称.Name = "gridCol供应商名称";
            this.gridCol供应商名称.Visible = true;
            this.gridCol供应商名称.VisibleIndex = 2;
            this.gridCol供应商名称.Width = 391;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(60, 52);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(37, 15);
            this.label1.TabIndex = 92;
            this.label1.Text = "主题";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(60, 88);
            this.label5.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(37, 15);
            this.label5.TabIndex = 92;
            this.label5.Text = "内容";
            // 
            // txt主题
            // 
            this.txt主题.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.txt主题.Location = new System.Drawing.Point(109, 49);
            this.txt主题.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.txt主题.Name = "txt主题";
            this.txt主题.Size = new System.Drawing.Size(685, 25);
            this.txt主题.TabIndex = 93;
            // 
            // richTextBox内容
            // 
            this.richTextBox内容.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.richTextBox内容.Location = new System.Drawing.Point(111, 88);
            this.richTextBox内容.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.richTextBox内容.Name = "richTextBox内容";
            this.richTextBox内容.Size = new System.Drawing.Size(684, 275);
            this.richTextBox内容.TabIndex = 94;
            this.richTextBox内容.Text = "";
            // 
            // chk全选
            // 
            this.chk全选.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.chk全选.AutoSize = true;
            this.chk全选.Location = new System.Drawing.Point(1188, 89);
            this.chk全选.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.chk全选.Name = "chk全选";
            this.chk全选.Size = new System.Drawing.Size(59, 19);
            this.chk全选.TabIndex = 95;
            this.chk全选.Text = "全选";
            this.chk全选.UseVisualStyleBackColor = true;
            this.chk全选.CheckedChanged += new System.EventHandler(this.chk全选_CheckedChanged);
            // 
            // btn发布
            // 
            this.btn发布.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btn发布.Location = new System.Drawing.Point(865, 405);
            this.btn发布.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btn发布.Name = "btn发布";
            this.btn发布.Size = new System.Drawing.Size(100, 29);
            this.btn发布.TabIndex = 96;
            this.btn发布.Text = "发布";
            this.btn发布.UseVisualStyleBackColor = true;
            this.btn发布.Click += new System.EventHandler(this.btn发布_Click);
            // 
            // btn删除
            // 
            this.btn删除.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btn删除.Location = new System.Drawing.Point(739, 405);
            this.btn删除.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btn删除.Name = "btn删除";
            this.btn删除.Size = new System.Drawing.Size(100, 29);
            this.btn删除.TabIndex = 96;
            this.btn删除.Text = "删除";
            this.btn删除.UseVisualStyleBackColor = true;
            this.btn删除.Click += new System.EventHandler(this.btn删除_Click);
            // 
            // btn保存
            // 
            this.btn保存.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btn保存.Location = new System.Drawing.Point(608, 405);
            this.btn保存.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btn保存.Name = "btn保存";
            this.btn保存.Size = new System.Drawing.Size(100, 29);
            this.btn保存.TabIndex = 96;
            this.btn保存.Text = "保存";
            this.btn保存.UseVisualStyleBackColor = true;
            this.btn保存.Click += new System.EventHandler(this.btn保存_Click);
            // 
            // btn取消
            // 
            this.btn取消.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btn取消.Location = new System.Drawing.Point(987, 405);
            this.btn取消.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btn取消.Name = "btn取消";
            this.btn取消.Size = new System.Drawing.Size(100, 29);
            this.btn取消.TabIndex = 96;
            this.btn取消.Text = "取消发布";
            this.btn取消.UseVisualStyleBackColor = true;
            this.btn取消.Click += new System.EventHandler(this.btn取消_Click);
            // 
            // txt制单人
            // 
            this.txt制单人.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.txt制单人.Enabled = false;
            this.txt制单人.Location = new System.Drawing.Point(109, 371);
            this.txt制单人.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.txt制单人.Name = "txt制单人";
            this.txt制单人.Size = new System.Drawing.Size(121, 25);
            this.txt制单人.TabIndex = 98;
            // 
            // label2
            // 
            this.label2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(47, 375);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(52, 15);
            this.label2.TabIndex = 97;
            this.label2.Text = "制单人";
            // 
            // txt发布人
            // 
            this.txt发布人.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.txt发布人.Enabled = false;
            this.txt发布人.Location = new System.Drawing.Point(109, 405);
            this.txt发布人.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.txt发布人.Name = "txt发布人";
            this.txt发布人.Size = new System.Drawing.Size(121, 25);
            this.txt发布人.TabIndex = 100;
            // 
            // label3
            // 
            this.label3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(44, 409);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(52, 15);
            this.label3.TabIndex = 99;
            this.label3.Text = "发布人";
            // 
            // label4
            // 
            this.label4.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(247, 409);
            this.label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(67, 15);
            this.label4.TabIndex = 103;
            this.label4.Text = "发布日期";
            // 
            // label6
            // 
            this.label6.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(247, 375);
            this.label6.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(67, 15);
            this.label6.TabIndex = 101;
            this.label6.Text = "制单日期";
            // 
            // date制单日期
            // 
            this.date制单日期.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.date制单日期.EditValue = new System.DateTime(2011, 10, 24, 0, 0, 0, 0);
            this.date制单日期.Enabled = false;
            this.date制单日期.Location = new System.Drawing.Point(325, 369);
            this.date制单日期.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.date制单日期.Name = "date制单日期";
            this.date制单日期.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.date制单日期.Properties.VistaTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
            this.date制单日期.Size = new System.Drawing.Size(152, 24);
            this.date制单日期.TabIndex = 105;
            // 
            // date_发布日期
            // 
            this.date_发布日期.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.date_发布日期.EditValue = new System.DateTime(2011, 10, 24, 0, 0, 0, 0);
            this.date_发布日期.Enabled = false;
            this.date_发布日期.Location = new System.Drawing.Point(325, 402);
            this.date_发布日期.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.date_发布日期.Name = "date_发布日期";
            this.date_发布日期.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.date_发布日期.Properties.VistaTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
            this.date_发布日期.Size = new System.Drawing.Size(152, 24);
            this.date_发布日期.TabIndex = 106;
            // 
            // btn退出
            // 
            this.btn退出.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btn退出.Location = new System.Drawing.Point(1113, 405);
            this.btn退出.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btn退出.Name = "btn退出";
            this.btn退出.Size = new System.Drawing.Size(100, 29);
            this.btn退出.TabIndex = 107;
            this.btn退出.Text = "退出";
            this.btn退出.UseVisualStyleBackColor = true;
            this.btn退出.Click += new System.EventHandler(this.btn退出_Click);
            // 
            // radio采购
            // 
            this.radio采购.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.radio采购.AutoSize = true;
            this.radio采购.Location = new System.Drawing.Point(824, 89);
            this.radio采购.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.radio采购.Name = "radio采购";
            this.radio采购.Size = new System.Drawing.Size(58, 19);
            this.radio采购.TabIndex = 108;
            this.radio采购.Text = "采购";
            this.radio采购.UseVisualStyleBackColor = true;
            this.radio采购.CheckedChanged += new System.EventHandler(this.radio供应商_CheckedChanged);
            // 
            // radio委外
            // 
            this.radio委外.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.radio委外.AutoSize = true;
            this.radio委外.Location = new System.Drawing.Point(904, 89);
            this.radio委外.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.radio委外.Name = "radio委外";
            this.radio委外.Size = new System.Drawing.Size(58, 19);
            this.radio委外.TabIndex = 109;
            this.radio委外.Text = "委外";
            this.radio委外.UseVisualStyleBackColor = true;
            this.radio委外.CheckedChanged += new System.EventHandler(this.radio供应商_CheckedChanged);
            // 
            // radio全部
            // 
            this.radio全部.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.radio全部.AutoSize = true;
            this.radio全部.Checked = true;
            this.radio全部.Location = new System.Drawing.Point(1077, 89);
            this.radio全部.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.radio全部.Name = "radio全部";
            this.radio全部.Size = new System.Drawing.Size(58, 19);
            this.radio全部.TabIndex = 110;
            this.radio全部.TabStop = true;
            this.radio全部.Text = "全部";
            this.radio全部.UseVisualStyleBackColor = true;
            this.radio全部.CheckedChanged += new System.EventHandler(this.radio供应商_CheckedChanged);
            // 
            // radio未设置
            // 
            this.radio未设置.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.radio未设置.AutoSize = true;
            this.radio未设置.Location = new System.Drawing.Point(976, 89);
            this.radio未设置.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.radio未设置.Name = "radio未设置";
            this.radio未设置.Size = new System.Drawing.Size(73, 19);
            this.radio未设置.TabIndex = 111;
            this.radio未设置.Text = "未设置";
            this.radio未设置.UseVisualStyleBackColor = true;
            this.radio未设置.CheckedChanged += new System.EventHandler(this.radio供应商_CheckedChanged);
            // 
            // label7
            // 
            this.label7.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(821, 52);
            this.label7.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(292, 15);
            this.label7.TabIndex = 112;
            this.label7.Text = "供应商档案中未设置分管部门的在未设置里";
            // 
            // Frm杜乐公告Edit
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1260, 451);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.radio未设置);
            this.Controls.Add(this.radio全部);
            this.Controls.Add(this.radio委外);
            this.Controls.Add(this.radio采购);
            this.Controls.Add(this.btn退出);
            this.Controls.Add(this.date_发布日期);
            this.Controls.Add(this.date制单日期);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.txt发布人);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txt制单人);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.btn取消);
            this.Controls.Add(this.btn删除);
            this.Controls.Add(this.btn保存);
            this.Controls.Add(this.btn发布);
            this.Controls.Add(this.chk全选);
            this.Controls.Add(this.richTextBox内容);
            this.Controls.Add(this.txt主题);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.gridControl1);
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Name = "Frm杜乐公告Edit";
            this.Text = "杜乐公告";
            this.Load += new System.EventHandler(this.Frm杜乐公告Edit_Load);
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.date制单日期.Properties.VistaTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.date制单日期.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.date_发布日期.Properties.VistaTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.date_发布日期.Properties)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraGrid.GridControl gridControl1;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label5;
        private DevExpress.XtraGrid.Columns.GridColumn gridCol供应商编码;
        private DevExpress.XtraGrid.Columns.GridColumn gridCol供应商名称;
        private DevExpress.XtraGrid.Columns.GridColumn gridCol选择;
        private System.Windows.Forms.TextBox txt主题;
        private System.Windows.Forms.RichTextBox richTextBox内容;
        private System.Windows.Forms.CheckBox chk全选;
        private System.Windows.Forms.Button btn发布;
        private System.Windows.Forms.Button btn删除;
        private System.Windows.Forms.Button btn保存;
        private System.Windows.Forms.Button btn取消;
        private System.Windows.Forms.TextBox txt制单人;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txt发布人;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox textBox3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label6;
        private DevExpress.XtraEditors.DateEdit date制单日期;
        private DevExpress.XtraEditors.DateEdit date_发布日期;
        private System.Windows.Forms.Button btn退出;
        private System.Windows.Forms.RadioButton radio采购;
        private System.Windows.Forms.RadioButton radio委外;
        private System.Windows.Forms.RadioButton radio全部;
        private System.Windows.Forms.RadioButton radio未设置;
        private System.Windows.Forms.Label label7;
    }
}