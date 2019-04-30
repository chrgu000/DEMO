namespace UFIDA.U8.UAP.CustomApp.ControlForm
{
    partial class RDIn
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
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.btnQuery = new System.Windows.Forms.ToolStripMenuItem();
            this.btnSave = new System.Windows.Forms.ToolStripMenuItem();
            this.增行ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.删行ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            this.gridControl1 = new DevExpress.XtraGrid.GridControl();
            this.gridView1 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.gridCol存货编码 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridCol存货名称 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridCol规格型号 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridCol主计量 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.ItemLookUpEdit计量单位 = new DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit();
            this.gridCol辅计量 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridCol数量 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.ItemTextEditN6 = new DevExpress.XtraEditors.Repository.RepositoryItemTextEdit();
            this.gridCol件数 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridCol表体备注 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridCol换算率 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColID = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColAutoID = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridCol原始数量 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridCol原始件数 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColcFree1 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColcFree2 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColcFree3 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColcFree4 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColcFree5 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColcFree6 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridCol失效日期 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridCol生产日期 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.dtm = new DevExpress.XtraEditors.DateEdit();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label8 = new System.Windows.Forms.Label();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.txt业务号 = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.txt业务类型 = new System.Windows.Forms.TextBox();
            this.txt备注 = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.lookUpEdit入库类别 = new DevExpress.XtraEditors.LookUpEdit();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.txt单据号 = new System.Windows.Forms.TextBox();
            this.lookUpEdit仓库 = new DevExpress.XtraEditors.LookUpEdit();
            this.label3 = new System.Windows.Forms.Label();
            this.labelcInvCode1 = new System.Windows.Forms.Label();
            this.gridCol批号 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.menuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ItemLookUpEdit计量单位)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ItemTextEditN6)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtm.Properties.VistaTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtm.Properties)).BeginInit();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.lookUpEdit入库类别.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lookUpEdit仓库.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btnQuery,
            this.btnSave,
            this.增行ToolStripMenuItem,
            this.删行ToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(903, 24);
            this.menuStrip1.TabIndex = 172;
            this.menuStrip1.Text = "menuStrip";
            // 
            // btnQuery
            // 
            this.btnQuery.Name = "btnQuery";
            this.btnQuery.Size = new System.Drawing.Size(41, 20);
            this.btnQuery.Text = "查询";
            this.btnQuery.Click += new System.EventHandler(this.btnQuery_Click);
            // 
            // btnSave
            // 
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(41, 20);
            this.btnSave.Text = "保存";
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // 增行ToolStripMenuItem
            // 
            this.增行ToolStripMenuItem.Name = "增行ToolStripMenuItem";
            this.增行ToolStripMenuItem.Size = new System.Drawing.Size(41, 20);
            this.增行ToolStripMenuItem.Text = "增行";
            this.增行ToolStripMenuItem.Click += new System.EventHandler(this.增行ToolStripMenuItem_Click);
            // 
            // 删行ToolStripMenuItem
            // 
            this.删行ToolStripMenuItem.Name = "删行ToolStripMenuItem";
            this.删行ToolStripMenuItem.Size = new System.Drawing.Size(41, 20);
            this.删行ToolStripMenuItem.Text = "删行";
            this.删行ToolStripMenuItem.Click += new System.EventHandler(this.删行ToolStripMenuItem_Click);
            // 
            // labelControl1
            // 
            this.labelControl1.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.labelControl1.Appearance.Font = new System.Drawing.Font("Tahoma", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelControl1.Location = new System.Drawing.Point(346, 12);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(226, 25);
            this.labelControl1.TabIndex = 190;
            this.labelControl1.Text = "材料退回单(其他入库单)";
            // 
            // gridControl1
            // 
            this.gridControl1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.gridControl1.Location = new System.Drawing.Point(3, 119);
            this.gridControl1.LookAndFeel.SkinName = "Office 2010 Blue";
            this.gridControl1.MainView = this.gridView1;
            this.gridControl1.Name = "gridControl1";
            this.gridControl1.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.ItemTextEditN6,
            this.ItemLookUpEdit计量单位});
            this.gridControl1.Size = new System.Drawing.Size(897, 273);
            this.gridControl1.TabIndex = 191;
            this.gridControl1.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView1});
            // 
            // gridView1
            // 
            this.gridView1.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.gridCol存货编码,
            this.gridCol存货名称,
            this.gridCol规格型号,
            this.gridCol主计量,
            this.gridCol辅计量,
            this.gridCol数量,
            this.gridCol件数,
            this.gridCol表体备注,
            this.gridCol换算率,
            this.gridColID,
            this.gridColAutoID,
            this.gridCol原始数量,
            this.gridCol原始件数,
            this.gridColcFree1,
            this.gridColcFree2,
            this.gridColcFree3,
            this.gridColcFree4,
            this.gridColcFree5,
            this.gridColcFree6,
            this.gridCol失效日期,
            this.gridCol生产日期,
            this.gridCol批号});
            this.gridView1.GridControl = this.gridControl1;
            this.gridView1.IndicatorWidth = 40;
            this.gridView1.Name = "gridView1";
            this.gridView1.OptionsBehavior.AllowDeleteRows = DevExpress.Utils.DefaultBoolean.True;
            this.gridView1.OptionsBehavior.EditorShowMode = DevExpress.Utils.EditorShowMode.MouseDown;
            this.gridView1.OptionsCustomization.AllowGroup = false;
            this.gridView1.OptionsCustomization.AllowQuickHideColumns = false;
            this.gridView1.OptionsNavigation.EnterMoveNextColumn = true;
            this.gridView1.OptionsView.ColumnAutoWidth = false;
            this.gridView1.OptionsView.ShowFooter = true;
            this.gridView1.OptionsView.ShowGroupPanel = false;
            this.gridView1.FocusedRowChanged += new DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventHandler(this.gridView1_FocusedRowChanged);
            this.gridView1.CustomDrawRowIndicator += new DevExpress.XtraGrid.Views.Grid.RowIndicatorCustomDrawEventHandler(this.gridView1_CustomDrawRowIndicator_1);
            this.gridView1.CellValueChanged += new DevExpress.XtraGrid.Views.Base.CellValueChangedEventHandler(this.gridView1_CellValueChanged);
            // 
            // gridCol存货编码
            // 
            this.gridCol存货编码.Caption = "存货编码";
            this.gridCol存货编码.FieldName = "存货编码";
            this.gridCol存货编码.Name = "gridCol存货编码";
            this.gridCol存货编码.OptionsColumn.AllowEdit = false;
            this.gridCol存货编码.Visible = true;
            this.gridCol存货编码.VisibleIndex = 0;
            this.gridCol存货编码.Width = 120;
            // 
            // gridCol存货名称
            // 
            this.gridCol存货名称.Caption = "存货名称";
            this.gridCol存货名称.FieldName = "存货名称";
            this.gridCol存货名称.Name = "gridCol存货名称";
            this.gridCol存货名称.OptionsColumn.AllowEdit = false;
            this.gridCol存货名称.Visible = true;
            this.gridCol存货名称.VisibleIndex = 1;
            this.gridCol存货名称.Width = 140;
            // 
            // gridCol规格型号
            // 
            this.gridCol规格型号.Caption = "规格型号";
            this.gridCol规格型号.FieldName = "规格型号";
            this.gridCol规格型号.Name = "gridCol规格型号";
            this.gridCol规格型号.OptionsColumn.AllowEdit = false;
            this.gridCol规格型号.Width = 144;
            // 
            // gridCol主计量
            // 
            this.gridCol主计量.Caption = "主计量";
            this.gridCol主计量.ColumnEdit = this.ItemLookUpEdit计量单位;
            this.gridCol主计量.FieldName = "主计量";
            this.gridCol主计量.Name = "gridCol主计量";
            this.gridCol主计量.OptionsColumn.AllowEdit = false;
            this.gridCol主计量.Width = 109;
            // 
            // ItemLookUpEdit计量单位
            // 
            this.ItemLookUpEdit计量单位.AutoHeight = false;
            this.ItemLookUpEdit计量单位.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.ItemLookUpEdit计量单位.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("cComunitCode", "编码"),
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("cComUnitName", "名称")});
            this.ItemLookUpEdit计量单位.DisplayMember = "cComUnitName";
            this.ItemLookUpEdit计量单位.Name = "ItemLookUpEdit计量单位";
            this.ItemLookUpEdit计量单位.NullText = "";
            this.ItemLookUpEdit计量单位.ValueMember = "cComunitCode";
            // 
            // gridCol辅计量
            // 
            this.gridCol辅计量.Caption = "辅计量";
            this.gridCol辅计量.ColumnEdit = this.ItemLookUpEdit计量单位;
            this.gridCol辅计量.FieldName = "辅计量";
            this.gridCol辅计量.Name = "gridCol辅计量";
            this.gridCol辅计量.OptionsColumn.AllowEdit = false;
            this.gridCol辅计量.Width = 119;
            // 
            // gridCol数量
            // 
            this.gridCol数量.Caption = "数量";
            this.gridCol数量.ColumnEdit = this.ItemTextEditN6;
            this.gridCol数量.FieldName = "数量";
            this.gridCol数量.Name = "gridCol数量";
            this.gridCol数量.Summary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] {
            new DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum)});
            this.gridCol数量.Visible = true;
            this.gridCol数量.VisibleIndex = 9;
            this.gridCol数量.Width = 103;
            // 
            // ItemTextEditN6
            // 
            this.ItemTextEditN6.AutoHeight = false;
            this.ItemTextEditN6.DisplayFormat.FormatString = "n6";
            this.ItemTextEditN6.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.ItemTextEditN6.EditFormat.FormatString = "n6";
            this.ItemTextEditN6.EditFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.ItemTextEditN6.Mask.EditMask = "n6";
            this.ItemTextEditN6.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Numeric;
            this.ItemTextEditN6.Name = "ItemTextEditN6";
            // 
            // gridCol件数
            // 
            this.gridCol件数.Caption = "件数";
            this.gridCol件数.ColumnEdit = this.ItemTextEditN6;
            this.gridCol件数.FieldName = "件数";
            this.gridCol件数.Name = "gridCol件数";
            this.gridCol件数.Summary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] {
            new DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum)});
            this.gridCol件数.Visible = true;
            this.gridCol件数.VisibleIndex = 8;
            this.gridCol件数.Width = 108;
            // 
            // gridCol表体备注
            // 
            this.gridCol表体备注.Caption = "表体备注";
            this.gridCol表体备注.FieldName = "表体备注";
            this.gridCol表体备注.Name = "gridCol表体备注";
            this.gridCol表体备注.Visible = true;
            this.gridCol表体备注.VisibleIndex = 11;
            this.gridCol表体备注.Width = 215;
            // 
            // gridCol换算率
            // 
            this.gridCol换算率.Caption = "换算率";
            this.gridCol换算率.FieldName = "换算率";
            this.gridCol换算率.Name = "gridCol换算率";
            this.gridCol换算率.OptionsColumn.AllowEdit = false;
            this.gridCol换算率.Visible = true;
            this.gridCol换算率.VisibleIndex = 12;
            this.gridCol换算率.Width = 184;
            // 
            // gridColID
            // 
            this.gridColID.Caption = "ID";
            this.gridColID.FieldName = "ID";
            this.gridColID.Name = "gridColID";
            this.gridColID.OptionsColumn.AllowEdit = false;
            // 
            // gridColAutoID
            // 
            this.gridColAutoID.Caption = "AutoID";
            this.gridColAutoID.FieldName = "AutoID";
            this.gridColAutoID.Name = "gridColAutoID";
            this.gridColAutoID.OptionsColumn.AllowEdit = false;
            // 
            // gridCol原始数量
            // 
            this.gridCol原始数量.Caption = "原始数量";
            this.gridCol原始数量.FieldName = "原始数量";
            this.gridCol原始数量.Name = "gridCol原始数量";
            this.gridCol原始数量.OptionsColumn.AllowEdit = false;
            this.gridCol原始数量.Visible = true;
            this.gridCol原始数量.VisibleIndex = 15;
            // 
            // gridCol原始件数
            // 
            this.gridCol原始件数.Caption = "原始件数";
            this.gridCol原始件数.FieldName = "原始件数";
            this.gridCol原始件数.Name = "gridCol原始件数";
            this.gridCol原始件数.OptionsColumn.AllowEdit = false;
            this.gridCol原始件数.Visible = true;
            this.gridCol原始件数.VisibleIndex = 16;
            // 
            // gridColcFree1
            // 
            this.gridColcFree1.Caption = "宽度";
            this.gridColcFree1.FieldName = "cFree1";
            this.gridColcFree1.Name = "gridColcFree1";
            this.gridColcFree1.Visible = true;
            this.gridColcFree1.VisibleIndex = 2;
            this.gridColcFree1.Width = 68;
            // 
            // gridColcFree2
            // 
            this.gridColcFree2.Caption = "长度";
            this.gridColcFree2.FieldName = "cFree2";
            this.gridColcFree2.Name = "gridColcFree2";
            this.gridColcFree2.Visible = true;
            this.gridColcFree2.VisibleIndex = 3;
            // 
            // gridColcFree3
            // 
            this.gridColcFree3.Caption = "厚度";
            this.gridColcFree3.FieldName = "cFree3";
            this.gridColcFree3.Name = "gridColcFree3";
            this.gridColcFree3.OptionsColumn.AllowEdit = false;
            this.gridColcFree3.Visible = true;
            this.gridColcFree3.VisibleIndex = 4;
            // 
            // gridColcFree4
            // 
            this.gridColcFree4.Caption = "特性";
            this.gridColcFree4.FieldName = "cFree4";
            this.gridColcFree4.Name = "gridColcFree4";
            this.gridColcFree4.OptionsColumn.AllowEdit = false;
            this.gridColcFree4.Visible = true;
            this.gridColcFree4.VisibleIndex = 5;
            // 
            // gridColcFree5
            // 
            this.gridColcFree5.Caption = "连体号";
            this.gridColcFree5.FieldName = "cFree5";
            this.gridColcFree5.Name = "gridColcFree5";
            this.gridColcFree5.OptionsColumn.AllowEdit = false;
            this.gridColcFree5.Visible = true;
            this.gridColcFree5.VisibleIndex = 6;
            // 
            // gridColcFree6
            // 
            this.gridColcFree6.Caption = "部件号";
            this.gridColcFree6.FieldName = "cFree6";
            this.gridColcFree6.Name = "gridColcFree6";
            this.gridColcFree6.OptionsColumn.AllowEdit = false;
            this.gridColcFree6.Visible = true;
            this.gridColcFree6.VisibleIndex = 10;
            // 
            // gridCol失效日期
            // 
            this.gridCol失效日期.Caption = "失效日期";
            this.gridCol失效日期.FieldName = "dVDate";
            this.gridCol失效日期.Name = "gridCol失效日期";
            this.gridCol失效日期.OptionsColumn.AllowEdit = false;
            this.gridCol失效日期.Visible = true;
            this.gridCol失效日期.VisibleIndex = 14;
            // 
            // gridCol生产日期
            // 
            this.gridCol生产日期.Caption = "生产日期";
            this.gridCol生产日期.FieldName = "dMadeDate";
            this.gridCol生产日期.Name = "gridCol生产日期";
            this.gridCol生产日期.OptionsColumn.AllowEdit = false;
            this.gridCol生产日期.Visible = true;
            this.gridCol生产日期.VisibleIndex = 13;
            // 
            // dtm
            // 
            this.dtm.EditValue = null;
            this.dtm.Location = new System.Drawing.Point(262, 44);
            this.dtm.Name = "dtm";
            this.dtm.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.dtm.Properties.VistaTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
            this.dtm.Size = new System.Drawing.Size(119, 20);
            this.dtm.TabIndex = 213;
            // 
            // panel1
            // 
            this.panel1.AutoScroll = true;
            this.panel1.Controls.Add(this.label8);
            this.panel1.Controls.Add(this.textBox2);
            this.panel1.Controls.Add(this.label7);
            this.panel1.Controls.Add(this.txt业务号);
            this.panel1.Controls.Add(this.label6);
            this.panel1.Controls.Add(this.txt业务类型);
            this.panel1.Controls.Add(this.txt备注);
            this.panel1.Controls.Add(this.label5);
            this.panel1.Controls.Add(this.lookUpEdit入库类别);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.txt单据号);
            this.panel1.Controls.Add(this.lookUpEdit仓库);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.labelcInvCode1);
            this.panel1.Controls.Add(this.dtm);
            this.panel1.Controls.Add(this.gridControl1);
            this.panel1.Controls.Add(this.labelControl1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 24);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(903, 394);
            this.panel1.TabIndex = 173;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(17, 96);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(53, 12);
            this.label8.TabIndex = 259;
            this.label8.Text = "入库类别";
            // 
            // textBox2
            // 
            this.textBox2.Enabled = false;
            this.textBox2.Location = new System.Drawing.Point(74, 70);
            this.textBox2.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new System.Drawing.Size(120, 21);
            this.textBox2.TabIndex = 258;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Enabled = false;
            this.label7.Location = new System.Drawing.Point(17, 74);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(53, 12);
            this.label7.TabIndex = 257;
            this.label7.Text = "出库单号";
            // 
            // txt业务号
            // 
            this.txt业务号.Enabled = false;
            this.txt业务号.Location = new System.Drawing.Point(437, 70);
            this.txt业务号.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.txt业务号.Name = "txt业务号";
            this.txt业务号.Size = new System.Drawing.Size(120, 21);
            this.txt业务号.TabIndex = 256;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Enabled = false;
            this.label6.Location = new System.Drawing.Point(386, 72);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(41, 12);
            this.label6.TabIndex = 255;
            this.label6.Text = "业务号";
            // 
            // txt业务类型
            // 
            this.txt业务类型.Enabled = false;
            this.txt业务类型.Location = new System.Drawing.Point(262, 70);
            this.txt业务类型.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.txt业务类型.Name = "txt业务类型";
            this.txt业务类型.Size = new System.Drawing.Size(120, 21);
            this.txt业务类型.TabIndex = 254;
            this.txt业务类型.Text = "其他入库";
            // 
            // txt备注
            // 
            this.txt备注.Location = new System.Drawing.Point(262, 94);
            this.txt备注.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.txt备注.Name = "txt备注";
            this.txt备注.Size = new System.Drawing.Size(296, 21);
            this.txt备注.TabIndex = 253;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(206, 96);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(29, 12);
            this.label5.TabIndex = 252;
            this.label5.Text = "备注";
            // 
            // lookUpEdit入库类别
            // 
            this.lookUpEdit入库类别.Location = new System.Drawing.Point(74, 92);
            this.lookUpEdit入库类别.Name = "lookUpEdit入库类别";
            this.lookUpEdit入库类别.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.lookUpEdit入库类别.Properties.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("cRdCode", 40, "编码"),
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("cRdName", 60, "名称")});
            this.lookUpEdit入库类别.Properties.DisplayMember = "cRdName";
            this.lookUpEdit入库类别.Properties.NullText = "";
            this.lookUpEdit入库类别.Properties.PopupWidth = 400;
            this.lookUpEdit入库类别.Properties.ValueMember = "cRdCode";
            this.lookUpEdit入库类别.Size = new System.Drawing.Size(119, 20);
            this.lookUpEdit入库类别.TabIndex = 250;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Enabled = false;
            this.label2.Location = new System.Drawing.Point(206, 72);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(53, 12);
            this.label2.TabIndex = 249;
            this.label2.Text = "业务类型";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(398, 48);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(29, 12);
            this.label1.TabIndex = 247;
            this.label1.Text = "仓库";
            // 
            // txt单据号
            // 
            this.txt单据号.Enabled = false;
            this.txt单据号.Location = new System.Drawing.Point(74, 44);
            this.txt单据号.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.txt单据号.Name = "txt单据号";
            this.txt单据号.Size = new System.Drawing.Size(120, 21);
            this.txt单据号.TabIndex = 246;
            // 
            // lookUpEdit仓库
            // 
            this.lookUpEdit仓库.Location = new System.Drawing.Point(437, 46);
            this.lookUpEdit仓库.Name = "lookUpEdit仓库";
            this.lookUpEdit仓库.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.lookUpEdit仓库.Properties.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("cWhCode", 40, "编码"),
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("cWhName", 60, "名称")});
            this.lookUpEdit仓库.Properties.DisplayMember = "cWhName";
            this.lookUpEdit仓库.Properties.NullText = "";
            this.lookUpEdit仓库.Properties.ValueMember = "cWhCode";
            this.lookUpEdit仓库.Size = new System.Drawing.Size(119, 20);
            this.lookUpEdit仓库.TabIndex = 245;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(206, 48);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(53, 12);
            this.label3.TabIndex = 222;
            this.label3.Text = "入库日期";
            // 
            // labelcInvCode1
            // 
            this.labelcInvCode1.AutoSize = true;
            this.labelcInvCode1.Location = new System.Drawing.Point(17, 48);
            this.labelcInvCode1.Name = "labelcInvCode1";
            this.labelcInvCode1.Size = new System.Drawing.Size(53, 12);
            this.labelcInvCode1.TabIndex = 214;
            this.labelcInvCode1.Text = "入库单号";
            // 
            // gridCol批号
            // 
            this.gridCol批号.Caption = "批号";
            this.gridCol批号.FieldName = "cBatch";
            this.gridCol批号.Name = "gridCol批号";
            this.gridCol批号.Visible = true;
            this.gridCol批号.VisibleIndex = 7;
            // 
            // RDIn
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.menuStrip1);
            this.Name = "RDIn";
            this.Size = new System.Drawing.Size(903, 418);
            this.Load += new System.EventHandler(this.Frm_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ItemLookUpEdit计量单位)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ItemTextEditN6)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtm.Properties.VistaTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtm.Properties)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.lookUpEdit入库类别.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lookUpEdit仓库.Properties)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem btnSave;
        private DevExpress.XtraEditors.LabelControl labelControl1;
        private DevExpress.XtraGrid.GridControl gridControl1;
        private DevExpress.XtraEditors.DateEdit dtm;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label labelcInvCode1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ToolStripMenuItem btnQuery;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView1;
        private System.Windows.Forms.TextBox txt单据号;
        private DevExpress.XtraEditors.LookUpEdit lookUpEdit仓库;
        private DevExpress.XtraGrid.Columns.GridColumn gridCol存货编码;
        private DevExpress.XtraGrid.Columns.GridColumn gridCol存货名称;
        private DevExpress.XtraGrid.Columns.GridColumn gridCol规格型号;
        private DevExpress.XtraGrid.Columns.GridColumn gridCol主计量;
        private DevExpress.XtraGrid.Columns.GridColumn gridCol辅计量;
        private DevExpress.XtraGrid.Columns.GridColumn gridCol数量;
        private System.Windows.Forms.TextBox txt备注;
        private System.Windows.Forms.Label label5;
        private DevExpress.XtraEditors.LookUpEdit lookUpEdit入库类别;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private DevExpress.XtraGrid.Columns.GridColumn gridCol件数;
        private DevExpress.XtraGrid.Columns.GridColumn gridCol表体备注;
        private DevExpress.XtraGrid.Columns.GridColumn gridCol换算率;
        private DevExpress.XtraGrid.Columns.GridColumn gridColID;
        private DevExpress.XtraGrid.Columns.GridColumn gridColAutoID;
        private DevExpress.XtraEditors.Repository.RepositoryItemTextEdit ItemTextEditN6;
        private DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit ItemLookUpEdit计量单位;
        private DevExpress.XtraGrid.Columns.GridColumn gridCol原始数量;
        private DevExpress.XtraGrid.Columns.GridColumn gridCol原始件数;
        private DevExpress.XtraGrid.Columns.GridColumn gridColcFree1;
        private DevExpress.XtraGrid.Columns.GridColumn gridColcFree2;
        private DevExpress.XtraGrid.Columns.GridColumn gridColcFree3;
        private DevExpress.XtraGrid.Columns.GridColumn gridColcFree4;
        private DevExpress.XtraGrid.Columns.GridColumn gridColcFree5;
        private DevExpress.XtraGrid.Columns.GridColumn gridColcFree6;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox txt业务号;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txt业务类型;
        private System.Windows.Forms.ToolStripMenuItem 增行ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 删行ToolStripMenuItem;
        private DevExpress.XtraGrid.Columns.GridColumn gridCol失效日期;
        private DevExpress.XtraGrid.Columns.GridColumn gridCol生产日期;
        private DevExpress.XtraGrid.Columns.GridColumn gridCol批号;
    }
}
