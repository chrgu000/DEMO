namespace UFIDA.U8.UAP.CustomApp.ControlForm
{
    partial class Sa_BOMAll
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Sa_BOMAll));
            this.panel1 = new System.Windows.Forms.Panel();
            this.lookUpEditMonth = new DevExpress.XtraEditors.LookUpEdit();
            this.label3 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.txt年 = new DevExpress.XtraEditors.TextEdit();
            this.treeList1 = new DevExpress.XtraTreeList.TreeList();
            this.col来达存货编码 = new DevExpress.XtraTreeList.Columns.TreeListColumn();
            this.col客户存货编码 = new DevExpress.XtraTreeList.Columns.TreeListColumn();
            this.col客户名称 = new DevExpress.XtraTreeList.Columns.TreeListColumn();
            this.col月底结存数量 = new DevExpress.XtraTreeList.Columns.TreeListColumn();
            this.col月底结存金额 = new DevExpress.XtraTreeList.Columns.TreeListColumn();
            this.col是否共用存货 = new DevExpress.XtraTreeList.Columns.TreeListColumn();
            this.col14天的销售量 = new DevExpress.XtraTreeList.Columns.TreeListColumn();
            this.col确认销量 = new DevExpress.XtraTreeList.Columns.TreeListColumn();
            this.col销售单价 = new DevExpress.XtraTreeList.Columns.TreeListColumn();
            this.col金额 = new DevExpress.XtraTreeList.Columns.TreeListColumn();
            this.col是否客户付款 = new DevExpress.XtraTreeList.Columns.TreeListColumn();
            this.col确认收入 = new DevExpress.XtraTreeList.Columns.TreeListColumn();
            this.col标准成本单价 = new DevExpress.XtraTreeList.Columns.TreeListColumn();
            this.col标准成本金额 = new DevExpress.XtraTreeList.Columns.TreeListColumn();
            this.col修改后的库存金额 = new DevExpress.XtraTreeList.Columns.TreeListColumn();
            this.btnExcel = new DevExpress.XtraEditors.SimpleButton();
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            this.btnRefresh = new DevExpress.XtraEditors.SimpleButton();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.lookUpEditMonth.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txt年.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.treeList1)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.panel1.Controls.Add(this.lookUpEditMonth);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.label5);
            this.panel1.Controls.Add(this.txt年);
            this.panel1.Controls.Add(this.treeList1);
            this.panel1.Controls.Add(this.btnExcel);
            this.panel1.Controls.Add(this.labelControl1);
            this.panel1.Controls.Add(this.btnRefresh);
            this.panel1.Location = new System.Drawing.Point(15, 15);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1224, 600);
            this.panel1.TabIndex = 68;
            // 
            // lookUpEditMonth
            // 
            this.lookUpEditMonth.Location = new System.Drawing.Point(82, 93);
            this.lookUpEditMonth.Name = "lookUpEditMonth";
            this.lookUpEditMonth.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.lookUpEditMonth.Properties.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("cValue", "月份")});
            this.lookUpEditMonth.Properties.DisplayMember = "cValue";
            this.lookUpEditMonth.Properties.ValueMember = "cValue";
            this.lookUpEditMonth.Size = new System.Drawing.Size(100, 20);
            this.lookUpEditMonth.TabIndex = 181;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(28, 98);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(29, 12);
            this.label3.TabIndex = 180;
            this.label3.Text = "月份";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(28, 69);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(29, 12);
            this.label5.TabIndex = 179;
            this.label5.Text = "年度";
            // 
            // txt年
            // 
            this.txt年.Location = new System.Drawing.Point(82, 64);
            this.txt年.Name = "txt年";
            this.txt年.Size = new System.Drawing.Size(100, 20);
            this.txt年.TabIndex = 178;
            // 
            // treeList1
            // 
            this.treeList1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.treeList1.Appearance.Empty.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(243)))), ((int)(((byte)(243)))), ((int)(((byte)(243)))));
            this.treeList1.Appearance.Empty.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.treeList1.Appearance.Empty.Options.UseBackColor = true;
            this.treeList1.Appearance.Empty.Options.UseForeColor = true;
            this.treeList1.Appearance.EvenRow.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(223)))), ((int)(((byte)(223)))), ((int)(((byte)(223)))));
            this.treeList1.Appearance.EvenRow.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.treeList1.Appearance.EvenRow.Options.UseBackColor = true;
            this.treeList1.Appearance.EvenRow.Options.UseForeColor = true;
            this.treeList1.Appearance.FocusedCell.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(225)))));
            this.treeList1.Appearance.FocusedCell.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.treeList1.Appearance.FocusedCell.Options.UseBackColor = true;
            this.treeList1.Appearance.FocusedCell.Options.UseForeColor = true;
            this.treeList1.Appearance.FocusedRow.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(128)))));
            this.treeList1.Appearance.FocusedRow.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.treeList1.Appearance.FocusedRow.Options.UseBackColor = true;
            this.treeList1.Appearance.FocusedRow.Options.UseForeColor = true;
            this.treeList1.Appearance.FooterPanel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(210)))), ((int)(((byte)(210)))), ((int)(((byte)(210)))));
            this.treeList1.Appearance.FooterPanel.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(210)))), ((int)(((byte)(210)))), ((int)(((byte)(210)))));
            this.treeList1.Appearance.FooterPanel.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.treeList1.Appearance.FooterPanel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.treeList1.Appearance.FooterPanel.Options.UseBackColor = true;
            this.treeList1.Appearance.FooterPanel.Options.UseBorderColor = true;
            this.treeList1.Appearance.FooterPanel.Options.UseFont = true;
            this.treeList1.Appearance.FooterPanel.Options.UseForeColor = true;
            this.treeList1.Appearance.GroupButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(202)))), ((int)(((byte)(202)))), ((int)(((byte)(202)))));
            this.treeList1.Appearance.GroupButton.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(202)))), ((int)(((byte)(202)))), ((int)(((byte)(202)))));
            this.treeList1.Appearance.GroupButton.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.treeList1.Appearance.GroupButton.Options.UseBackColor = true;
            this.treeList1.Appearance.GroupButton.Options.UseBorderColor = true;
            this.treeList1.Appearance.GroupButton.Options.UseForeColor = true;
            this.treeList1.Appearance.GroupFooter.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(202)))), ((int)(((byte)(202)))), ((int)(((byte)(202)))));
            this.treeList1.Appearance.GroupFooter.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(202)))), ((int)(((byte)(202)))), ((int)(((byte)(202)))));
            this.treeList1.Appearance.GroupFooter.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.treeList1.Appearance.GroupFooter.Options.UseBackColor = true;
            this.treeList1.Appearance.GroupFooter.Options.UseBorderColor = true;
            this.treeList1.Appearance.GroupFooter.Options.UseForeColor = true;
            this.treeList1.Appearance.HeaderPanel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.treeList1.Appearance.HeaderPanel.BorderColor = System.Drawing.Color.Silver;
            this.treeList1.Appearance.HeaderPanel.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.treeList1.Appearance.HeaderPanel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.treeList1.Appearance.HeaderPanel.Options.UseBackColor = true;
            this.treeList1.Appearance.HeaderPanel.Options.UseBorderColor = true;
            this.treeList1.Appearance.HeaderPanel.Options.UseFont = true;
            this.treeList1.Appearance.HeaderPanel.Options.UseForeColor = true;
            this.treeList1.Appearance.HideSelectionRow.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(128)))), ((int)(((byte)(128)))));
            this.treeList1.Appearance.HideSelectionRow.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(212)))), ((int)(((byte)(208)))), ((int)(((byte)(200)))));
            this.treeList1.Appearance.HideSelectionRow.Options.UseBackColor = true;
            this.treeList1.Appearance.HideSelectionRow.Options.UseForeColor = true;
            this.treeList1.Appearance.HorzLine.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.treeList1.Appearance.HorzLine.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(128)))), ((int)(((byte)(128)))));
            this.treeList1.Appearance.HorzLine.Options.UseBackColor = true;
            this.treeList1.Appearance.HorzLine.Options.UseForeColor = true;
            this.treeList1.Appearance.Preview.BackColor = System.Drawing.Color.LavenderBlush;
            this.treeList1.Appearance.Preview.ForeColor = System.Drawing.Color.MediumBlue;
            this.treeList1.Appearance.Preview.Options.UseBackColor = true;
            this.treeList1.Appearance.Preview.Options.UseForeColor = true;
            this.treeList1.Appearance.Preview.Options.UseTextOptions = true;
            this.treeList1.Appearance.Preview.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Top;
            this.treeList1.Appearance.Row.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(243)))), ((int)(((byte)(243)))), ((int)(((byte)(243)))));
            this.treeList1.Appearance.Row.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.treeList1.Appearance.Row.Options.UseBackColor = true;
            this.treeList1.Appearance.Row.Options.UseForeColor = true;
            this.treeList1.Appearance.SelectedRow.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(10)))), ((int)(((byte)(10)))), ((int)(((byte)(138)))));
            this.treeList1.Appearance.SelectedRow.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.treeList1.Appearance.SelectedRow.Options.UseBackColor = true;
            this.treeList1.Appearance.SelectedRow.Options.UseForeColor = true;
            this.treeList1.Appearance.TreeLine.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.treeList1.Appearance.TreeLine.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(128)))), ((int)(((byte)(128)))));
            this.treeList1.Appearance.TreeLine.Options.UseBackColor = true;
            this.treeList1.Appearance.TreeLine.Options.UseForeColor = true;
            this.treeList1.Appearance.VertLine.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.treeList1.Appearance.VertLine.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(128)))), ((int)(((byte)(128)))));
            this.treeList1.Appearance.VertLine.Options.UseBackColor = true;
            this.treeList1.Appearance.VertLine.Options.UseForeColor = true;
            this.treeList1.Appearance.VertLine.Options.UseTextOptions = true;
            this.treeList1.Appearance.VertLine.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near;
            this.treeList1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("treeList1.BackgroundImage")));
            this.treeList1.Columns.AddRange(new DevExpress.XtraTreeList.Columns.TreeListColumn[] {
            this.col来达存货编码,
            this.col客户存货编码,
            this.col客户名称,
            this.col月底结存数量,
            this.col月底结存金额,
            this.col是否共用存货,
            this.col14天的销售量,
            this.col确认销量,
            this.col销售单价,
            this.col金额,
            this.col是否客户付款,
            this.col确认收入,
            this.col标准成本单价,
            this.col标准成本金额,
            this.col修改后的库存金额});
            this.treeList1.Location = new System.Drawing.Point(18, 152);
            this.treeList1.Name = "treeList1";
            this.treeList1.OptionsBehavior.AutoChangeParent = false;
            this.treeList1.OptionsBehavior.AutoNodeHeight = false;
            this.treeList1.OptionsBehavior.AutoSelectAllInEditor = false;
            this.treeList1.OptionsBehavior.CloseEditorOnLostFocus = false;
            this.treeList1.OptionsBehavior.Editable = false;
            this.treeList1.OptionsBehavior.ExpandNodeOnDrag = false;
            this.treeList1.OptionsBehavior.KeepSelectedOnClick = false;
            this.treeList1.OptionsBehavior.ResizeNodes = false;
            this.treeList1.OptionsBehavior.SmartMouseHover = false;
            this.treeList1.OptionsMenu.EnableFooterMenu = false;
            this.treeList1.OptionsView.AutoCalcPreviewLineCount = true;
            this.treeList1.OptionsView.AutoWidth = false;
            this.treeList1.OptionsView.EnableAppearanceEvenRow = true;
            this.treeList1.OptionsView.ShowHorzLines = false;
            this.treeList1.OptionsView.ShowIndicator = false;
            this.treeList1.OptionsView.ShowSummaryFooter = true;
            this.treeList1.OptionsView.ShowVertLines = false;
            this.treeList1.Size = new System.Drawing.Size(1203, 435);
            this.treeList1.TabIndex = 68;
            // 
            // col来达存货编码
            // 
            this.col来达存货编码.Caption = "来达存货编码";
            this.col来达存货编码.FieldName = "来达存货编码";
            this.col来达存货编码.Name = "col来达存货编码";
            this.col来达存货编码.Visible = true;
            this.col来达存货编码.VisibleIndex = 0;
            this.col来达存货编码.Width = 123;
            // 
            // col客户存货编码
            // 
            this.col客户存货编码.Caption = "客户存货编码";
            this.col客户存货编码.FieldName = "客户存货编码";
            this.col客户存货编码.MinWidth = 49;
            this.col客户存货编码.Name = "col客户存货编码";
            this.col客户存货编码.Visible = true;
            this.col客户存货编码.VisibleIndex = 1;
            this.col客户存货编码.Width = 123;
            // 
            // col客户名称
            // 
            this.col客户名称.Caption = "客户名称";
            this.col客户名称.FieldName = "客户名称";
            this.col客户名称.Name = "col客户名称";
            this.col客户名称.Visible = true;
            this.col客户名称.VisibleIndex = 2;
            this.col客户名称.Width = 113;
            // 
            // col月底结存数量
            // 
            this.col月底结存数量.Caption = "月底结存数量";
            this.col月底结存数量.FieldName = "月底结存数量";
            this.col月底结存数量.Format.FormatString = "{0:N2}";
            this.col月底结存数量.Format.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.col月底结存数量.Name = "col月底结存数量";
            this.col月底结存数量.SummaryFooter = DevExpress.XtraTreeList.SummaryItemType.Sum;
            this.col月底结存数量.SummaryFooterStrFormat = "{0:N2}";
            this.col月底结存数量.Visible = true;
            this.col月底结存数量.VisibleIndex = 3;
            this.col月底结存数量.Width = 109;
            // 
            // col月底结存金额
            // 
            this.col月底结存金额.Caption = "月底结存金额";
            this.col月底结存金额.FieldName = "月底结存金额";
            this.col月底结存金额.Format.FormatString = "{0:N2}";
            this.col月底结存金额.Format.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.col月底结存金额.Name = "col月底结存金额";
            this.col月底结存金额.SummaryFooter = DevExpress.XtraTreeList.SummaryItemType.Sum;
            this.col月底结存金额.SummaryFooterStrFormat = "{0:N2}";
            this.col月底结存金额.Visible = true;
            this.col月底结存金额.VisibleIndex = 4;
            this.col月底结存金额.Width = 111;
            // 
            // col是否共用存货
            // 
            this.col是否共用存货.Caption = "是否共用存货";
            this.col是否共用存货.FieldName = "是否共用存货";
            this.col是否共用存货.Name = "col是否共用存货";
            this.col是否共用存货.SummaryFooter = DevExpress.XtraTreeList.SummaryItemType.Sum;
            this.col是否共用存货.Visible = true;
            this.col是否共用存货.VisibleIndex = 5;
            this.col是否共用存货.Width = 97;
            // 
            // col14天的销售量
            // 
            this.col14天的销售量.Caption = "14天的销售量";
            this.col14天的销售量.FieldName = "14天的销售量";
            this.col14天的销售量.Format.FormatString = "{0:N2}";
            this.col14天的销售量.Format.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.col14天的销售量.Name = "col14天的销售量";
            this.col14天的销售量.SummaryFooter = DevExpress.XtraTreeList.SummaryItemType.Sum;
            this.col14天的销售量.SummaryFooterStrFormat = "{0:N2}";
            this.col14天的销售量.Visible = true;
            this.col14天的销售量.VisibleIndex = 6;
            this.col14天的销售量.Width = 97;
            // 
            // col确认销量
            // 
            this.col确认销量.Caption = "确认销量";
            this.col确认销量.FieldName = "确认销量";
            this.col确认销量.Format.FormatString = "{0:N2}";
            this.col确认销量.Format.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.col确认销量.Name = "col确认销量";
            this.col确认销量.SummaryFooter = DevExpress.XtraTreeList.SummaryItemType.Sum;
            this.col确认销量.SummaryFooterStrFormat = "{0:N2}";
            this.col确认销量.Visible = true;
            this.col确认销量.VisibleIndex = 7;
            // 
            // col销售单价
            // 
            this.col销售单价.Caption = "销售单价";
            this.col销售单价.FieldName = "销售单价";
            this.col销售单价.Format.FormatString = "{0:N2}";
            this.col销售单价.Format.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.col销售单价.Name = "col销售单价";
            this.col销售单价.SummaryFooter = DevExpress.XtraTreeList.SummaryItemType.Sum;
            this.col销售单价.SummaryFooterStrFormat = "{0:N2}";
            this.col销售单价.Visible = true;
            this.col销售单价.VisibleIndex = 8;
            // 
            // col金额
            // 
            this.col金额.Caption = "金额";
            this.col金额.FieldName = "金额";
            this.col金额.Format.FormatString = "{0:N2}";
            this.col金额.Format.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.col金额.Name = "col金额";
            this.col金额.SummaryFooter = DevExpress.XtraTreeList.SummaryItemType.Sum;
            this.col金额.SummaryFooterStrFormat = "{0:N2}";
            this.col金额.Visible = true;
            this.col金额.VisibleIndex = 9;
            // 
            // col是否客户付款
            // 
            this.col是否客户付款.Caption = "是否客户付款";
            this.col是否客户付款.FieldName = "是否客户付款";
            this.col是否客户付款.Name = "col是否客户付款";
            this.col是否客户付款.Visible = true;
            this.col是否客户付款.VisibleIndex = 10;
            this.col是否客户付款.Width = 101;
            // 
            // col确认收入
            // 
            this.col确认收入.Caption = "确认收入";
            this.col确认收入.FieldName = "确认收入";
            this.col确认收入.Format.FormatString = "{0:N2}";
            this.col确认收入.Format.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.col确认收入.Name = "col确认收入";
            this.col确认收入.SummaryFooter = DevExpress.XtraTreeList.SummaryItemType.Sum;
            this.col确认收入.SummaryFooterStrFormat = "{0:N2}";
            this.col确认收入.Visible = true;
            this.col确认收入.VisibleIndex = 11;
            // 
            // col标准成本单价
            // 
            this.col标准成本单价.Caption = "标准成本单价";
            this.col标准成本单价.FieldName = "标准成本单价";
            this.col标准成本单价.Format.FormatString = "{0:N4}";
            this.col标准成本单价.Format.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.col标准成本单价.Name = "col标准成本单价";
            this.col标准成本单价.SummaryFooter = DevExpress.XtraTreeList.SummaryItemType.Sum;
            this.col标准成本单价.SummaryFooterStrFormat = "{0:N4}";
            this.col标准成本单价.Visible = true;
            this.col标准成本单价.VisibleIndex = 12;
            this.col标准成本单价.Width = 96;
            // 
            // col标准成本金额
            // 
            this.col标准成本金额.Caption = "标准成本金额";
            this.col标准成本金额.FieldName = "标准成本金额";
            this.col标准成本金额.Format.FormatString = "{0:N4}";
            this.col标准成本金额.Format.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.col标准成本金额.Name = "col标准成本金额";
            this.col标准成本金额.SummaryFooter = DevExpress.XtraTreeList.SummaryItemType.Sum;
            this.col标准成本金额.SummaryFooterStrFormat = "{0:N4}";
            this.col标准成本金额.Visible = true;
            this.col标准成本金额.VisibleIndex = 13;
            this.col标准成本金额.Width = 97;
            // 
            // col修改后的库存金额
            // 
            this.col修改后的库存金额.Caption = "修改后的库存金额";
            this.col修改后的库存金额.FieldName = "修改后的库存金额";
            this.col修改后的库存金额.Format.FormatString = "{0:N2}";
            this.col修改后的库存金额.Format.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.col修改后的库存金额.Name = "col修改后的库存金额";
            this.col修改后的库存金额.SummaryFooter = DevExpress.XtraTreeList.SummaryItemType.Sum;
            this.col修改后的库存金额.SummaryFooterStrFormat = "{0:N2}";
            this.col修改后的库存金额.Visible = true;
            this.col修改后的库存金额.VisibleIndex = 14;
            this.col修改后的库存金额.Width = 115;
            // 
            // btnExcel
            // 
            this.btnExcel.Image = ((System.Drawing.Image)(resources.GetObject("btnExcel.Image")));
            this.btnExcel.ImageLocation = DevExpress.XtraEditors.ImageLocation.TopCenter;
            this.btnExcel.Location = new System.Drawing.Point(280, 69);
            this.btnExcel.Name = "btnExcel";
            this.btnExcel.Size = new System.Drawing.Size(50, 41);
            this.btnExcel.TabIndex = 71;
            this.btnExcel.Text = "导出";
            this.btnExcel.Click += new System.EventHandler(this.btnExcel_Click);
            // 
            // labelControl1
            // 
            this.labelControl1.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.labelControl1.Appearance.Font = new System.Drawing.Font("Tahoma", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelControl1.Location = new System.Drawing.Point(548, 14);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(147, 25);
            this.labelControl1.TabIndex = 70;
            this.labelControl1.Text = "销售成本确认表";
            // 
            // btnRefresh
            // 
            this.btnRefresh.Image = ((System.Drawing.Image)(resources.GetObject("btnRefresh.Image")));
            this.btnRefresh.ImageLocation = DevExpress.XtraEditors.ImageLocation.TopCenter;
            this.btnRefresh.Location = new System.Drawing.Point(209, 69);
            this.btnRefresh.Name = "btnRefresh";
            this.btnRefresh.Size = new System.Drawing.Size(50, 41);
            this.btnRefresh.TabIndex = 69;
            this.btnRefresh.Text = "查询";
            this.btnRefresh.Click += new System.EventHandler(this.btnRefresh_Click);
            // 
            // Sa_BOMAll
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.panel1);
            this.Name = "Sa_BOMAll";
            this.Size = new System.Drawing.Size(1252, 631);
            this.Load += new System.EventHandler(this.ProjectManager_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.lookUpEditMonth.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txt年.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.treeList1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.CheckedListBoxControl checkedListBoxControl1;
        private DevExpress.XtraEditors.CheckedListBoxControl checkedListBoxControl2;
        private System.Windows.Forms.Panel panel1;
        private DevExpress.XtraTreeList.TreeList treeList1;
        private DevExpress.XtraTreeList.Columns.TreeListColumn col来达存货编码;
        private DevExpress.XtraTreeList.Columns.TreeListColumn col客户存货编码;
        private DevExpress.XtraTreeList.Columns.TreeListColumn col客户名称;
        private DevExpress.XtraEditors.SimpleButton btnExcel;
        private DevExpress.XtraEditors.LabelControl labelControl1;
        private DevExpress.XtraEditors.SimpleButton btnRefresh;
        private DevExpress.XtraTreeList.Columns.TreeListColumn col月底结存数量;
        private DevExpress.XtraTreeList.Columns.TreeListColumn col月底结存金额;
        private DevExpress.XtraTreeList.Columns.TreeListColumn col14天的销售量;
        private DevExpress.XtraTreeList.Columns.TreeListColumn col确认销量;
        private DevExpress.XtraTreeList.Columns.TreeListColumn col销售单价;
        private DevExpress.XtraTreeList.Columns.TreeListColumn col金额;
        private DevExpress.XtraTreeList.Columns.TreeListColumn col是否客户付款;
        private DevExpress.XtraTreeList.Columns.TreeListColumn col确认收入;
        private DevExpress.XtraTreeList.Columns.TreeListColumn col标准成本单价;
        private DevExpress.XtraTreeList.Columns.TreeListColumn col标准成本金额;
        private DevExpress.XtraTreeList.Columns.TreeListColumn col修改后的库存金额;
        private DevExpress.XtraEditors.LookUpEdit lookUpEditMonth;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label5;
        private DevExpress.XtraEditors.TextEdit txt年;
        private DevExpress.XtraTreeList.Columns.TreeListColumn col是否共用存货;
    }
}
