namespace Base
{
    partial class Frm杜乐公告供应商查看
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
            DevExpress.XtraGrid.GridLevelNode gridLevelNode2 = new DevExpress.XtraGrid.GridLevelNode();
            this.gridControl1 = new DevExpress.XtraGrid.GridControl();
            this.gridView1 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.gridCol选择 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridCol标题 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridCol内容 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridCol制单人 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridCol制单日期 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColGUID = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridCol阅读人 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridCol阅读日期 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.chk全选 = new System.Windows.Forms.CheckBox();
            this.label1 = new System.Windows.Forms.Label();
            this.date1 = new DevExpress.XtraEditors.DateEdit();
            this.date2 = new DevExpress.XtraEditors.DateEdit();
            this.radio未处理 = new System.Windows.Forms.RadioButton();
            this.radio全部 = new System.Windows.Forms.RadioButton();
            this.l供应商编码 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.date1.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.date2.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // childLF
            // 
            this.childLF.LookAndFeel.Style = DevExpress.LookAndFeel.LookAndFeelStyle.Skin;
            this.childLF.LookAndFeel.UseWindowsXPTheme = false;
            // 
            // gridControl1
            // 
            this.gridControl1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.gridControl1.EmbeddedNavigator.Name = "";
            gridLevelNode2.RelationName = "Level1";
            this.gridControl1.LevelTree.Nodes.AddRange(new DevExpress.XtraGrid.GridLevelNode[] {
            gridLevelNode2});
            this.gridControl1.Location = new System.Drawing.Point(7, 70);
            this.gridControl1.MainView = this.gridView1;
            this.gridControl1.Name = "gridControl1";
            this.gridControl1.Size = new System.Drawing.Size(933, 326);
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
            this.gridCol标题,
            this.gridCol内容,
            this.gridCol制单人,
            this.gridCol制单日期,
            this.gridColGUID,
            this.gridCol阅读人,
            this.gridCol阅读日期});
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
            this.gridView1.DoubleClick += new System.EventHandler(this.gridView1_DoubleClick);
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
            // gridCol标题
            // 
            this.gridCol标题.Caption = "标题";
            this.gridCol标题.FieldName = "标题";
            this.gridCol标题.Name = "gridCol标题";
            this.gridCol标题.OptionsColumn.AllowEdit = false;
            this.gridCol标题.Visible = true;
            this.gridCol标题.VisibleIndex = 1;
            this.gridCol标题.Width = 85;
            // 
            // gridCol内容
            // 
            this.gridCol内容.Caption = "内容";
            this.gridCol内容.FieldName = "内容";
            this.gridCol内容.Name = "gridCol内容";
            this.gridCol内容.OptionsColumn.AllowEdit = false;
            this.gridCol内容.Visible = true;
            this.gridCol内容.VisibleIndex = 2;
            this.gridCol内容.Width = 391;
            // 
            // gridCol制单人
            // 
            this.gridCol制单人.Caption = "制单人";
            this.gridCol制单人.FieldName = "制单人";
            this.gridCol制单人.Name = "gridCol制单人";
            this.gridCol制单人.OptionsColumn.AllowEdit = false;
            this.gridCol制单人.Visible = true;
            this.gridCol制单人.VisibleIndex = 3;
            // 
            // gridCol制单日期
            // 
            this.gridCol制单日期.Caption = "制单日期";
            this.gridCol制单日期.FieldName = "制单日期";
            this.gridCol制单日期.Name = "gridCol制单日期";
            this.gridCol制单日期.OptionsColumn.AllowEdit = false;
            this.gridCol制单日期.Visible = true;
            this.gridCol制单日期.VisibleIndex = 4;
            // 
            // gridColGUID
            // 
            this.gridColGUID.Caption = "GUID";
            this.gridColGUID.FieldName = "GUID";
            this.gridColGUID.Name = "gridColGUID";
            this.gridColGUID.OptionsColumn.AllowEdit = false;
            // 
            // gridCol阅读人
            // 
            this.gridCol阅读人.Caption = "阅读人";
            this.gridCol阅读人.FieldName = "阅读人";
            this.gridCol阅读人.Name = "gridCol阅读人";
            this.gridCol阅读人.OptionsColumn.AllowEdit = false;
            this.gridCol阅读人.Visible = true;
            this.gridCol阅读人.VisibleIndex = 5;
            // 
            // gridCol阅读日期
            // 
            this.gridCol阅读日期.Caption = "阅读日期";
            this.gridCol阅读日期.FieldName = "阅读日期";
            this.gridCol阅读日期.Name = "gridCol阅读日期";
            this.gridCol阅读日期.OptionsColumn.AllowEdit = false;
            this.gridCol阅读日期.Visible = true;
            this.gridCol阅读日期.VisibleIndex = 6;
            // 
            // chk全选
            // 
            this.chk全选.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.chk全选.AutoSize = true;
            this.chk全选.Location = new System.Drawing.Point(863, 33);
            this.chk全选.Name = "chk全选";
            this.chk全选.Size = new System.Drawing.Size(50, 18);
            this.chk全选.TabIndex = 95;
            this.chk全选.Text = "全选";
            this.chk全选.UseVisualStyleBackColor = true;
            this.chk全选.CheckedChanged += new System.EventHandler(this.chk全选_CheckedChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(16, 33);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(55, 14);
            this.label1.TabIndex = 96;
            this.label1.Text = "单据日期";
            // 
            // date1
            // 
            this.date1.EditValue = new System.DateTime(2011, 10, 24, 0, 0, 0, 0);
            this.date1.Location = new System.Drawing.Point(77, 30);
            this.date1.Name = "date1";
            this.date1.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.date1.Size = new System.Drawing.Size(144, 21);
            this.date1.TabIndex = 97;
            // 
            // date2
            // 
            this.date2.EditValue = new System.DateTime(2011, 10, 24, 0, 0, 0, 0);
            this.date2.Location = new System.Drawing.Point(227, 30);
            this.date2.Name = "date2";
            this.date2.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.date2.Size = new System.Drawing.Size(144, 21);
            this.date2.TabIndex = 98;
            // 
            // radio未处理
            // 
            this.radio未处理.AutoSize = true;
            this.radio未处理.Checked = true;
            this.radio未处理.Location = new System.Drawing.Point(398, 33);
            this.radio未处理.Name = "radio未处理";
            this.radio未处理.Size = new System.Drawing.Size(61, 18);
            this.radio未处理.TabIndex = 99;
            this.radio未处理.TabStop = true;
            this.radio未处理.Text = "未处理";
            this.radio未处理.UseVisualStyleBackColor = true;
            this.radio未处理.Click += new System.EventHandler(this.radio未处理_Click);
            // 
            // radio全部
            // 
            this.radio全部.AutoSize = true;
            this.radio全部.Location = new System.Drawing.Point(465, 33);
            this.radio全部.Name = "radio全部";
            this.radio全部.Size = new System.Drawing.Size(49, 18);
            this.radio全部.TabIndex = 99;
            this.radio全部.Text = "全部";
            this.radio全部.UseVisualStyleBackColor = true;
            this.radio全部.Click += new System.EventHandler(this.radio未处理_Click);
            // 
            // l供应商编码
            // 
            this.l供应商编码.AutoSize = true;
            this.l供应商编码.Location = new System.Drawing.Point(542, 33);
            this.l供应商编码.Name = "l供应商编码";
            this.l供应商编码.Size = new System.Drawing.Size(67, 14);
            this.l供应商编码.TabIndex = 100;
            this.l供应商编码.Text = "供应商编码";
            // 
            // Frm杜乐公告供应商查看
            // 
            this.Appearance.BackColor = System.Drawing.SystemColors.Control;
            this.Appearance.Options.UseBackColor = true;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(945, 399);
            this.Controls.Add(this.l供应商编码);
            this.Controls.Add(this.radio全部);
            this.Controls.Add(this.radio未处理);
            this.Controls.Add(this.date2);
            this.Controls.Add(this.date1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.chk全选);
            this.Controls.Add(this.gridControl1);
            this.Name = "Frm杜乐公告供应商查看";
            this.Text = "杜乐公告";
            this.Load += new System.EventHandler(this.Frm杜乐公告供应商查看_Load);
            this.Controls.SetChildIndex(this.gridControl1, 0);
            this.Controls.SetChildIndex(this.chk全选, 0);
            this.Controls.SetChildIndex(this.label1, 0);
            this.Controls.SetChildIndex(this.date1, 0);
            this.Controls.SetChildIndex(this.date2, 0);
            this.Controls.SetChildIndex(this.radio未处理, 0);
            this.Controls.SetChildIndex(this.radio全部, 0);
            this.Controls.SetChildIndex(this.l供应商编码, 0);
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.date1.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.date2.Properties)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraGrid.GridControl gridControl1;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView1;
        private DevExpress.XtraGrid.Columns.GridColumn gridCol标题;
        private DevExpress.XtraGrid.Columns.GridColumn gridCol内容;
        private DevExpress.XtraGrid.Columns.GridColumn gridCol选择;
        private System.Windows.Forms.CheckBox chk全选;
        private System.Windows.Forms.Label label1;
        private DevExpress.XtraEditors.DateEdit date1;
        private DevExpress.XtraEditors.DateEdit date2;
        private DevExpress.XtraGrid.Columns.GridColumn gridCol制单人;
        private DevExpress.XtraGrid.Columns.GridColumn gridCol制单日期;
        private DevExpress.XtraGrid.Columns.GridColumn gridColGUID;
        private System.Windows.Forms.RadioButton radio未处理;
        private System.Windows.Forms.RadioButton radio全部;
        private System.Windows.Forms.Label l供应商编码;
        private DevExpress.XtraGrid.Columns.GridColumn gridCol阅读人;
        private DevExpress.XtraGrid.Columns.GridColumn gridCol阅读日期;
    }
}