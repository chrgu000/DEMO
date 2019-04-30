namespace clsU8
{
    partial class Frm采购订单导入
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
            this.gridControl1 = new DevExpress.XtraGrid.GridControl();
            this.gridView1 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.gridColchoose = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridCol供应商编号 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.ItemLookUpEditcVenCode = new DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit();
            this.gridCol供应商名称 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.ItemLookUpEditcVentName = new DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit();
            this.gridCol采购部门 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.ItemLookUpEditcDepName = new DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit();
            this.gridCol采购类型 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.ItemLookUpEditcPTName = new DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit();
            this.gridCol币种 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridCol汇率 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridCol存货编码 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.ItemLookUpEditcInvCode = new DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit();
            this.gridCol存货名称 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.ItemLookUpEditcInvName = new DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit();
            this.gridCol规格型号 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.ItemLookUpEditcInvStd = new DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit();
            this.gridCol数量 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridCol原币含税单价 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridCol税率 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridCol计划到货日期 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridCol发运日期 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridCol采购订单号 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.ItemLookUpEditcDepCode = new DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit();
            this.ItemLookUpEditcPTCode = new DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.btnLoad = new System.Windows.Forms.ToolStripMenuItem();
            this.btnSave = new System.Windows.Forms.ToolStripMenuItem();
            this.dateEdit1 = new DevExpress.XtraEditors.DateEdit();
            this.label1 = new System.Windows.Forms.Label();
            this.chkAll = new System.Windows.Forms.CheckBox();
            this.gridCol业务类型 = new DevExpress.XtraGrid.Columns.GridColumn();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ItemLookUpEditcVenCode)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ItemLookUpEditcVentName)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ItemLookUpEditcDepName)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ItemLookUpEditcPTName)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ItemLookUpEditcInvCode)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ItemLookUpEditcInvName)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ItemLookUpEditcInvStd)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ItemLookUpEditcDepCode)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ItemLookUpEditcPTCode)).BeginInit();
            this.menuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dateEdit1.Properties.VistaTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dateEdit1.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // gridControl1
            // 
            this.gridControl1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.gridControl1.Location = new System.Drawing.Point(0, 96);
            this.gridControl1.LookAndFeel.SkinName = "Office 2010 Blue";
            this.gridControl1.MainView = this.gridView1;
            this.gridControl1.Name = "gridControl1";
            this.gridControl1.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.ItemLookUpEditcInvCode,
            this.ItemLookUpEditcInvName,
            this.ItemLookUpEditcInvStd,
            this.ItemLookUpEditcDepCode,
            this.ItemLookUpEditcDepName,
            this.ItemLookUpEditcVenCode,
            this.ItemLookUpEditcVentName,
            this.ItemLookUpEditcPTCode,
            this.ItemLookUpEditcPTName});
            this.gridControl1.Size = new System.Drawing.Size(1050, 370);
            this.gridControl1.TabIndex = 192;
            this.gridControl1.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView1});
            // 
            // gridView1
            // 
            this.gridView1.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.gridColchoose,
            this.gridCol供应商编号,
            this.gridCol供应商名称,
            this.gridCol采购部门,
            this.gridCol采购类型,
            this.gridCol币种,
            this.gridCol汇率,
            this.gridCol存货编码,
            this.gridCol存货名称,
            this.gridCol规格型号,
            this.gridCol数量,
            this.gridCol原币含税单价,
            this.gridCol税率,
            this.gridCol计划到货日期,
            this.gridCol发运日期,
            this.gridCol采购订单号,
            this.gridCol业务类型});
            this.gridView1.GridControl = this.gridControl1;
            this.gridView1.IndicatorWidth = 40;
            this.gridView1.Name = "gridView1";
            this.gridView1.OptionsBehavior.AllowDeleteRows = DevExpress.Utils.DefaultBoolean.True;
            this.gridView1.OptionsBehavior.EditorShowMode = DevExpress.Utils.EditorShowMode.MouseDown;
            this.gridView1.OptionsCustomization.AllowGroup = false;
            this.gridView1.OptionsCustomization.AllowQuickHideColumns = false;
            this.gridView1.OptionsNavigation.EnterMoveNextColumn = true;
            this.gridView1.OptionsPrint.AutoWidth = false;
            this.gridView1.OptionsView.AllowCellMerge = true;
            this.gridView1.OptionsView.ColumnAutoWidth = false;
            this.gridView1.OptionsView.ShowFooter = true;
            this.gridView1.OptionsView.ShowGroupPanel = false;
            this.gridView1.CustomDrawRowIndicator += new DevExpress.XtraGrid.Views.Grid.RowIndicatorCustomDrawEventHandler(this.gridView1_CustomDrawRowIndicator);
            this.gridView1.CellMerge += new DevExpress.XtraGrid.Views.Grid.CellMergeEventHandler(this.gridView1_CellMerge);
            this.gridView1.Click += new System.EventHandler(this.gridView1_Click);
            // 
            // gridColchoose
            // 
            this.gridColchoose.Caption = "选择";
            this.gridColchoose.FieldName = "choose";
            this.gridColchoose.Name = "gridColchoose";
            this.gridColchoose.OptionsColumn.AllowMerge = DevExpress.Utils.DefaultBoolean.True;
            this.gridColchoose.OptionsColumn.AllowMove = false;
            this.gridColchoose.OptionsColumn.AllowSort = DevExpress.Utils.DefaultBoolean.False;
            this.gridColchoose.OptionsFilter.AllowFilter = false;
            this.gridColchoose.Visible = true;
            this.gridColchoose.VisibleIndex = 0;
            this.gridColchoose.Width = 35;
            // 
            // gridCol供应商编号
            // 
            this.gridCol供应商编号.AppearanceHeader.BackColor = System.Drawing.Color.Blue;
            this.gridCol供应商编号.AppearanceHeader.ForeColor = System.Drawing.Color.Blue;
            this.gridCol供应商编号.AppearanceHeader.Options.UseBackColor = true;
            this.gridCol供应商编号.AppearanceHeader.Options.UseForeColor = true;
            this.gridCol供应商编号.Caption = "供应商编号";
            this.gridCol供应商编号.ColumnEdit = this.ItemLookUpEditcVenCode;
            this.gridCol供应商编号.FieldName = "供应商编号";
            this.gridCol供应商编号.Name = "gridCol供应商编号";
            this.gridCol供应商编号.OptionsColumn.AllowEdit = false;
            this.gridCol供应商编号.OptionsColumn.AllowMerge = DevExpress.Utils.DefaultBoolean.True;
            this.gridCol供应商编号.OptionsColumn.AllowMove = false;
            this.gridCol供应商编号.OptionsColumn.AllowSort = DevExpress.Utils.DefaultBoolean.False;
            this.gridCol供应商编号.OptionsFilter.AllowFilter = false;
            this.gridCol供应商编号.Visible = true;
            this.gridCol供应商编号.VisibleIndex = 2;
            // 
            // ItemLookUpEditcVenCode
            // 
            this.ItemLookUpEditcVenCode.AutoHeight = false;
            this.ItemLookUpEditcVenCode.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.ItemLookUpEditcVenCode.DisplayMember = "cVenCode";
            this.ItemLookUpEditcVenCode.Name = "ItemLookUpEditcVenCode";
            this.ItemLookUpEditcVenCode.NullText = "";
            this.ItemLookUpEditcVenCode.ValueMember = "cVenCode";
            // 
            // gridCol供应商名称
            // 
            this.gridCol供应商名称.Caption = "供应商名称";
            this.gridCol供应商名称.ColumnEdit = this.ItemLookUpEditcVentName;
            this.gridCol供应商名称.FieldName = "供应商编号";
            this.gridCol供应商名称.Name = "gridCol供应商名称";
            this.gridCol供应商名称.OptionsColumn.AllowEdit = false;
            this.gridCol供应商名称.OptionsColumn.AllowMerge = DevExpress.Utils.DefaultBoolean.True;
            this.gridCol供应商名称.OptionsColumn.AllowMove = false;
            this.gridCol供应商名称.OptionsColumn.AllowSort = DevExpress.Utils.DefaultBoolean.False;
            this.gridCol供应商名称.OptionsFilter.AllowFilter = false;
            this.gridCol供应商名称.Visible = true;
            this.gridCol供应商名称.VisibleIndex = 3;
            // 
            // ItemLookUpEditcVentName
            // 
            this.ItemLookUpEditcVentName.AutoHeight = false;
            this.ItemLookUpEditcVentName.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.ItemLookUpEditcVentName.DisplayMember = "cVenName";
            this.ItemLookUpEditcVentName.Name = "ItemLookUpEditcVentName";
            this.ItemLookUpEditcVentName.NullText = "";
            this.ItemLookUpEditcVentName.ValueMember = "cVenCode";
            // 
            // gridCol采购部门
            // 
            this.gridCol采购部门.AppearanceHeader.BackColor = System.Drawing.Color.Blue;
            this.gridCol采购部门.AppearanceHeader.ForeColor = System.Drawing.Color.Blue;
            this.gridCol采购部门.AppearanceHeader.Options.UseBackColor = true;
            this.gridCol采购部门.AppearanceHeader.Options.UseForeColor = true;
            this.gridCol采购部门.Caption = "采购部门";
            this.gridCol采购部门.ColumnEdit = this.ItemLookUpEditcDepName;
            this.gridCol采购部门.FieldName = "采购部门";
            this.gridCol采购部门.Name = "gridCol采购部门";
            this.gridCol采购部门.OptionsColumn.AllowEdit = false;
            this.gridCol采购部门.OptionsColumn.AllowMerge = DevExpress.Utils.DefaultBoolean.True;
            this.gridCol采购部门.OptionsColumn.AllowMove = false;
            this.gridCol采购部门.OptionsColumn.AllowSort = DevExpress.Utils.DefaultBoolean.False;
            this.gridCol采购部门.OptionsFilter.AllowFilter = false;
            this.gridCol采购部门.Visible = true;
            this.gridCol采购部门.VisibleIndex = 5;
            // 
            // ItemLookUpEditcDepName
            // 
            this.ItemLookUpEditcDepName.AutoHeight = false;
            this.ItemLookUpEditcDepName.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.ItemLookUpEditcDepName.DisplayMember = "cDepName";
            this.ItemLookUpEditcDepName.Name = "ItemLookUpEditcDepName";
            this.ItemLookUpEditcDepName.NullText = "";
            this.ItemLookUpEditcDepName.ValueMember = "cDepCode";
            // 
            // gridCol采购类型
            // 
            this.gridCol采购类型.AppearanceHeader.BackColor = System.Drawing.Color.Blue;
            this.gridCol采购类型.AppearanceHeader.ForeColor = System.Drawing.Color.Blue;
            this.gridCol采购类型.AppearanceHeader.Options.UseBackColor = true;
            this.gridCol采购类型.AppearanceHeader.Options.UseForeColor = true;
            this.gridCol采购类型.Caption = "采购类型";
            this.gridCol采购类型.ColumnEdit = this.ItemLookUpEditcPTName;
            this.gridCol采购类型.FieldName = "采购类型";
            this.gridCol采购类型.Name = "gridCol采购类型";
            this.gridCol采购类型.OptionsColumn.AllowEdit = false;
            this.gridCol采购类型.OptionsColumn.AllowMerge = DevExpress.Utils.DefaultBoolean.True;
            this.gridCol采购类型.OptionsColumn.AllowMove = false;
            this.gridCol采购类型.OptionsColumn.AllowSort = DevExpress.Utils.DefaultBoolean.False;
            this.gridCol采购类型.OptionsFilter.AllowFilter = false;
            this.gridCol采购类型.Visible = true;
            this.gridCol采购类型.VisibleIndex = 6;
            // 
            // ItemLookUpEditcPTName
            // 
            this.ItemLookUpEditcPTName.AutoHeight = false;
            this.ItemLookUpEditcPTName.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.ItemLookUpEditcPTName.DisplayMember = "cPTName";
            this.ItemLookUpEditcPTName.Name = "ItemLookUpEditcPTName";
            this.ItemLookUpEditcPTName.NullText = "";
            this.ItemLookUpEditcPTName.ValueMember = "cPTCode";
            // 
            // gridCol币种
            // 
            this.gridCol币种.AppearanceHeader.BackColor = System.Drawing.Color.Blue;
            this.gridCol币种.AppearanceHeader.ForeColor = System.Drawing.Color.Blue;
            this.gridCol币种.AppearanceHeader.Options.UseBackColor = true;
            this.gridCol币种.AppearanceHeader.Options.UseForeColor = true;
            this.gridCol币种.Caption = "币种";
            this.gridCol币种.FieldName = "币种";
            this.gridCol币种.Name = "gridCol币种";
            this.gridCol币种.OptionsColumn.AllowEdit = false;
            this.gridCol币种.OptionsColumn.AllowMerge = DevExpress.Utils.DefaultBoolean.True;
            this.gridCol币种.OptionsColumn.AllowMove = false;
            this.gridCol币种.OptionsColumn.AllowSort = DevExpress.Utils.DefaultBoolean.False;
            this.gridCol币种.OptionsFilter.AllowFilter = false;
            this.gridCol币种.Visible = true;
            this.gridCol币种.VisibleIndex = 7;
            // 
            // gridCol汇率
            // 
            this.gridCol汇率.Caption = "汇率";
            this.gridCol汇率.FieldName = "汇率";
            this.gridCol汇率.Name = "gridCol汇率";
            this.gridCol汇率.OptionsColumn.AllowEdit = false;
            this.gridCol汇率.OptionsColumn.AllowMerge = DevExpress.Utils.DefaultBoolean.True;
            this.gridCol汇率.OptionsColumn.AllowMove = false;
            this.gridCol汇率.OptionsColumn.AllowSort = DevExpress.Utils.DefaultBoolean.False;
            this.gridCol汇率.OptionsFilter.AllowFilter = false;
            this.gridCol汇率.Visible = true;
            this.gridCol汇率.VisibleIndex = 8;
            // 
            // gridCol存货编码
            // 
            this.gridCol存货编码.AppearanceHeader.BackColor = System.Drawing.Color.Blue;
            this.gridCol存货编码.AppearanceHeader.ForeColor = System.Drawing.Color.Blue;
            this.gridCol存货编码.AppearanceHeader.Options.UseBackColor = true;
            this.gridCol存货编码.AppearanceHeader.Options.UseForeColor = true;
            this.gridCol存货编码.Caption = "存货编码";
            this.gridCol存货编码.ColumnEdit = this.ItemLookUpEditcInvCode;
            this.gridCol存货编码.FieldName = "存货编码";
            this.gridCol存货编码.Name = "gridCol存货编码";
            this.gridCol存货编码.OptionsColumn.AllowEdit = false;
            this.gridCol存货编码.OptionsColumn.AllowMerge = DevExpress.Utils.DefaultBoolean.False;
            this.gridCol存货编码.OptionsColumn.AllowMove = false;
            this.gridCol存货编码.OptionsColumn.AllowSort = DevExpress.Utils.DefaultBoolean.False;
            this.gridCol存货编码.OptionsFilter.AllowFilter = false;
            this.gridCol存货编码.Visible = true;
            this.gridCol存货编码.VisibleIndex = 9;
            // 
            // ItemLookUpEditcInvCode
            // 
            this.ItemLookUpEditcInvCode.AutoHeight = false;
            this.ItemLookUpEditcInvCode.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.ItemLookUpEditcInvCode.DisplayMember = "cInvCode";
            this.ItemLookUpEditcInvCode.Name = "ItemLookUpEditcInvCode";
            this.ItemLookUpEditcInvCode.NullText = "";
            this.ItemLookUpEditcInvCode.ValueMember = "cInvCode";
            // 
            // gridCol存货名称
            // 
            this.gridCol存货名称.Caption = "存货名称";
            this.gridCol存货名称.ColumnEdit = this.ItemLookUpEditcInvName;
            this.gridCol存货名称.FieldName = "存货编码";
            this.gridCol存货名称.Name = "gridCol存货名称";
            this.gridCol存货名称.OptionsColumn.AllowEdit = false;
            this.gridCol存货名称.OptionsColumn.AllowMerge = DevExpress.Utils.DefaultBoolean.False;
            this.gridCol存货名称.OptionsColumn.AllowMove = false;
            this.gridCol存货名称.OptionsColumn.AllowSort = DevExpress.Utils.DefaultBoolean.False;
            this.gridCol存货名称.OptionsFilter.AllowFilter = false;
            this.gridCol存货名称.Visible = true;
            this.gridCol存货名称.VisibleIndex = 10;
            // 
            // ItemLookUpEditcInvName
            // 
            this.ItemLookUpEditcInvName.AutoHeight = false;
            this.ItemLookUpEditcInvName.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.ItemLookUpEditcInvName.DisplayMember = "cInvName";
            this.ItemLookUpEditcInvName.Name = "ItemLookUpEditcInvName";
            this.ItemLookUpEditcInvName.NullText = "";
            this.ItemLookUpEditcInvName.ValueMember = "cInvCode";
            // 
            // gridCol规格型号
            // 
            this.gridCol规格型号.Caption = "规格型号";
            this.gridCol规格型号.ColumnEdit = this.ItemLookUpEditcInvStd;
            this.gridCol规格型号.FieldName = "存货编码";
            this.gridCol规格型号.Name = "gridCol规格型号";
            this.gridCol规格型号.OptionsColumn.AllowEdit = false;
            this.gridCol规格型号.OptionsColumn.AllowMerge = DevExpress.Utils.DefaultBoolean.False;
            this.gridCol规格型号.OptionsColumn.AllowMove = false;
            this.gridCol规格型号.OptionsColumn.AllowSort = DevExpress.Utils.DefaultBoolean.False;
            this.gridCol规格型号.OptionsFilter.AllowFilter = false;
            this.gridCol规格型号.Visible = true;
            this.gridCol规格型号.VisibleIndex = 11;
            // 
            // ItemLookUpEditcInvStd
            // 
            this.ItemLookUpEditcInvStd.AutoHeight = false;
            this.ItemLookUpEditcInvStd.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.ItemLookUpEditcInvStd.DisplayMember = "cInvSTd";
            this.ItemLookUpEditcInvStd.Name = "ItemLookUpEditcInvStd";
            this.ItemLookUpEditcInvStd.NullText = "";
            this.ItemLookUpEditcInvStd.ValueMember = "cInvCode";
            // 
            // gridCol数量
            // 
            this.gridCol数量.AppearanceHeader.BackColor = System.Drawing.Color.Blue;
            this.gridCol数量.AppearanceHeader.ForeColor = System.Drawing.Color.Blue;
            this.gridCol数量.AppearanceHeader.Options.UseBackColor = true;
            this.gridCol数量.AppearanceHeader.Options.UseForeColor = true;
            this.gridCol数量.Caption = "数量";
            this.gridCol数量.FieldName = "数量";
            this.gridCol数量.Name = "gridCol数量";
            this.gridCol数量.OptionsColumn.AllowEdit = false;
            this.gridCol数量.OptionsColumn.AllowMerge = DevExpress.Utils.DefaultBoolean.False;
            this.gridCol数量.OptionsColumn.AllowMove = false;
            this.gridCol数量.OptionsColumn.AllowSort = DevExpress.Utils.DefaultBoolean.False;
            this.gridCol数量.OptionsFilter.AllowFilter = false;
            this.gridCol数量.Visible = true;
            this.gridCol数量.VisibleIndex = 12;
            // 
            // gridCol原币含税单价
            // 
            this.gridCol原币含税单价.AppearanceHeader.BackColor = System.Drawing.Color.Blue;
            this.gridCol原币含税单价.AppearanceHeader.ForeColor = System.Drawing.Color.Blue;
            this.gridCol原币含税单价.AppearanceHeader.Options.UseBackColor = true;
            this.gridCol原币含税单价.AppearanceHeader.Options.UseForeColor = true;
            this.gridCol原币含税单价.Caption = "原币含税单价";
            this.gridCol原币含税单价.FieldName = "原币含税单价";
            this.gridCol原币含税单价.Name = "gridCol原币含税单价";
            this.gridCol原币含税单价.OptionsColumn.AllowEdit = false;
            this.gridCol原币含税单价.OptionsColumn.AllowMerge = DevExpress.Utils.DefaultBoolean.False;
            this.gridCol原币含税单价.OptionsColumn.AllowMove = false;
            this.gridCol原币含税单价.OptionsColumn.AllowSort = DevExpress.Utils.DefaultBoolean.False;
            this.gridCol原币含税单价.OptionsFilter.AllowFilter = false;
            this.gridCol原币含税单价.Visible = true;
            this.gridCol原币含税单价.VisibleIndex = 13;
            this.gridCol原币含税单价.Width = 103;
            // 
            // gridCol税率
            // 
            this.gridCol税率.AppearanceHeader.BackColor = System.Drawing.Color.Blue;
            this.gridCol税率.AppearanceHeader.ForeColor = System.Drawing.Color.Blue;
            this.gridCol税率.AppearanceHeader.Options.UseBackColor = true;
            this.gridCol税率.AppearanceHeader.Options.UseForeColor = true;
            this.gridCol税率.Caption = "税率";
            this.gridCol税率.FieldName = "税率";
            this.gridCol税率.Name = "gridCol税率";
            this.gridCol税率.OptionsColumn.AllowEdit = false;
            this.gridCol税率.OptionsColumn.AllowMerge = DevExpress.Utils.DefaultBoolean.False;
            this.gridCol税率.OptionsColumn.AllowMove = false;
            this.gridCol税率.OptionsColumn.AllowSort = DevExpress.Utils.DefaultBoolean.False;
            this.gridCol税率.OptionsFilter.AllowFilter = false;
            this.gridCol税率.Visible = true;
            this.gridCol税率.VisibleIndex = 14;
            // 
            // gridCol计划到货日期
            // 
            this.gridCol计划到货日期.AppearanceHeader.BackColor = System.Drawing.Color.Blue;
            this.gridCol计划到货日期.AppearanceHeader.ForeColor = System.Drawing.Color.Blue;
            this.gridCol计划到货日期.AppearanceHeader.Options.UseBackColor = true;
            this.gridCol计划到货日期.AppearanceHeader.Options.UseForeColor = true;
            this.gridCol计划到货日期.Caption = "计划到货日期";
            this.gridCol计划到货日期.FieldName = "计划到货日期";
            this.gridCol计划到货日期.Name = "gridCol计划到货日期";
            this.gridCol计划到货日期.OptionsColumn.AllowEdit = false;
            this.gridCol计划到货日期.OptionsColumn.AllowMerge = DevExpress.Utils.DefaultBoolean.False;
            this.gridCol计划到货日期.OptionsColumn.AllowMove = false;
            this.gridCol计划到货日期.OptionsColumn.AllowSort = DevExpress.Utils.DefaultBoolean.False;
            this.gridCol计划到货日期.OptionsFilter.AllowFilter = false;
            this.gridCol计划到货日期.Visible = true;
            this.gridCol计划到货日期.VisibleIndex = 15;
            this.gridCol计划到货日期.Width = 103;
            // 
            // gridCol发运日期
            // 
            this.gridCol发运日期.Caption = "发运日期";
            this.gridCol发运日期.FieldName = "发运日期";
            this.gridCol发运日期.Name = "gridCol发运日期";
            this.gridCol发运日期.OptionsColumn.AllowEdit = false;
            this.gridCol发运日期.Visible = true;
            this.gridCol发运日期.VisibleIndex = 16;
            // 
            // gridCol采购订单号
            // 
            this.gridCol采购订单号.Caption = "采购订单号";
            this.gridCol采购订单号.FieldName = "采购订单号";
            this.gridCol采购订单号.Name = "gridCol采购订单号";
            this.gridCol采购订单号.OptionsColumn.AllowEdit = false;
            this.gridCol采购订单号.Visible = true;
            this.gridCol采购订单号.VisibleIndex = 1;
            // 
            // ItemLookUpEditcDepCode
            // 
            this.ItemLookUpEditcDepCode.AutoHeight = false;
            this.ItemLookUpEditcDepCode.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.ItemLookUpEditcDepCode.DisplayMember = "cDepCode";
            this.ItemLookUpEditcDepCode.Name = "ItemLookUpEditcDepCode";
            this.ItemLookUpEditcDepCode.NullText = "";
            this.ItemLookUpEditcDepCode.ValueMember = "cDepCode";
            // 
            // ItemLookUpEditcPTCode
            // 
            this.ItemLookUpEditcPTCode.AutoHeight = false;
            this.ItemLookUpEditcPTCode.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.ItemLookUpEditcPTCode.DisplayMember = "cPTCode";
            this.ItemLookUpEditcPTCode.Name = "ItemLookUpEditcPTCode";
            this.ItemLookUpEditcPTCode.NullText = "";
            this.ItemLookUpEditcPTCode.ValueMember = "cPTCode";
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btnLoad,
            this.btnSave});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(1050, 25);
            this.menuStrip1.TabIndex = 193;
            this.menuStrip1.Text = "menuStrip";
            // 
            // btnLoad
            // 
            this.btnLoad.Name = "btnLoad";
            this.btnLoad.Size = new System.Drawing.Size(44, 21);
            this.btnLoad.Text = "加载";
            this.btnLoad.Click += new System.EventHandler(this.btnLoad_Click);
            // 
            // btnSave
            // 
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(44, 21);
            this.btnSave.Text = "导入";
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // dateEdit1
            // 
            this.dateEdit1.EditValue = null;
            this.dateEdit1.Location = new System.Drawing.Point(79, 33);
            this.dateEdit1.Name = "dateEdit1";
            this.dateEdit1.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.dateEdit1.Properties.VistaTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
            this.dateEdit1.Size = new System.Drawing.Size(141, 20);
            this.dateEdit1.TabIndex = 214;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(21, 36);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(53, 12);
            this.label1.TabIndex = 215;
            this.label1.Text = "导入日期";
            // 
            // chkAll
            // 
            this.chkAll.AutoSize = true;
            this.chkAll.Location = new System.Drawing.Point(23, 74);
            this.chkAll.Name = "chkAll";
            this.chkAll.Size = new System.Drawing.Size(48, 16);
            this.chkAll.TabIndex = 216;
            this.chkAll.Text = "选择";
            this.chkAll.UseVisualStyleBackColor = true;
            this.chkAll.CheckedChanged += new System.EventHandler(this.chkAll_CheckedChanged);
            // 
            // gridCol业务类型
            // 
            this.gridCol业务类型.Caption = "业务类型";
            this.gridCol业务类型.FieldName = "业务类型";
            this.gridCol业务类型.Name = "gridCol业务类型";
            this.gridCol业务类型.OptionsColumn.AllowEdit = false;
            this.gridCol业务类型.Visible = true;
            this.gridCol业务类型.VisibleIndex = 4;
            // 
            // Frm采购订单导入
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.ClientSize = new System.Drawing.Size(1050, 466);
            this.Controls.Add(this.chkAll);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.dateEdit1);
            this.Controls.Add(this.menuStrip1);
            this.Controls.Add(this.gridControl1);
            this.Name = "Frm采购订单导入";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "ImportPO";
            this.Load += new System.EventHandler(this.Frm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ItemLookUpEditcVenCode)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ItemLookUpEditcVentName)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ItemLookUpEditcDepName)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ItemLookUpEditcPTName)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ItemLookUpEditcInvCode)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ItemLookUpEditcInvName)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ItemLookUpEditcInvStd)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ItemLookUpEditcDepCode)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ItemLookUpEditcPTCode)).EndInit();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dateEdit1.Properties.VistaTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dateEdit1.Properties)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraGrid.GridControl gridControl1;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView1;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem btnLoad;
        private System.Windows.Forms.ToolStripMenuItem btnSave;
        private DevExpress.XtraEditors.DateEdit dateEdit1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.CheckBox chkAll;
        private DevExpress.XtraGrid.Columns.GridColumn gridColchoose;
        private DevExpress.XtraGrid.Columns.GridColumn gridCol供应商编号;
        private DevExpress.XtraGrid.Columns.GridColumn gridCol供应商名称;
        private DevExpress.XtraGrid.Columns.GridColumn gridCol采购部门;
        private DevExpress.XtraGrid.Columns.GridColumn gridCol采购类型;
        private DevExpress.XtraGrid.Columns.GridColumn gridCol币种;
        private DevExpress.XtraGrid.Columns.GridColumn gridCol存货编码;
        private DevExpress.XtraGrid.Columns.GridColumn gridCol存货名称;
        private DevExpress.XtraGrid.Columns.GridColumn gridCol规格型号;
        private DevExpress.XtraGrid.Columns.GridColumn gridCol数量;
        private DevExpress.XtraGrid.Columns.GridColumn gridCol原币含税单价;
        private DevExpress.XtraGrid.Columns.GridColumn gridCol计划到货日期;
        private DevExpress.XtraGrid.Columns.GridColumn gridCol汇率;
        private DevExpress.XtraGrid.Columns.GridColumn gridCol税率;
        private DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit ItemLookUpEditcInvCode;
        private DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit ItemLookUpEditcInvName;
        private DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit ItemLookUpEditcInvStd;
        private DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit ItemLookUpEditcDepCode;
        private DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit ItemLookUpEditcDepName;
        private DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit ItemLookUpEditcVenCode;
        private DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit ItemLookUpEditcVentName;
        private DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit ItemLookUpEditcPTName;
        private DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit ItemLookUpEditcPTCode;
        private DevExpress.XtraGrid.Columns.GridColumn gridCol发运日期;
        private DevExpress.XtraGrid.Columns.GridColumn gridCol采购订单号;
        private DevExpress.XtraGrid.Columns.GridColumn gridCol业务类型;

    }
}