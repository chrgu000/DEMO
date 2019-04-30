namespace UFIDA.U8.UAP.CustomApp.ControlForm
{
    partial class 车间材料领用汇总月报
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
            this.btnClear = new System.Windows.Forms.ToolStripMenuItem();
            this.btnSEL = new System.Windows.Forms.ToolStripMenuItem();
            this.btnExport = new System.Windows.Forms.ToolStripMenuItem();
            this.btnAudit = new System.Windows.Forms.ToolStripMenuItem();
            this.btnUnAudit = new System.Windows.Forms.ToolStripMenuItem();
            this.btnExcel = new System.Windows.Forms.ToolStripMenuItem();
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            this.gridControl1 = new DevExpress.XtraGrid.GridControl();
            this.gridView1 = new DevExpress.XtraGrid.Views.BandedGrid.BandedGridView();
            this.gridBand材料 = new DevExpress.XtraGrid.Views.BandedGrid.GridBand();
            this.gridCol材料编码 = new DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn();
            this.ItemLookUpEditcInvCode = new DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit();
            this.gridCol材料名称 = new DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn();
            this.ItemLookUpEditcInvName = new DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit();
            this.gridCol材料规格 = new DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn();
            this.ItemLookUpEditcInvStd = new DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit();
            this.gridCol单位 = new DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn();
            this.ItemLookUpEditcComUnitName = new DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit();
            this.gridBand月初存料 = new DevExpress.XtraGrid.Views.BandedGrid.GridBand();
            this.gridCol月初存料数量 = new DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn();
            this.ItemTextEditN4 = new DevExpress.XtraEditors.Repository.RepositoryItemTextEdit();
            this.gridCol月初存料单价 = new DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn();
            this.gridCol月初存料金额 = new DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn();
            this.gridBand收发存汇总 = new DevExpress.XtraGrid.Views.BandedGrid.GridBand();
            this.gridCol收发存出库数量 = new DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn();
            this.gridCol收发存出库单价 = new DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn();
            this.gridCol收发存出库金额 = new DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn();
            this.gridBand月末结存 = new DevExpress.XtraGrid.Views.BandedGrid.GridBand();
            this.gridCol月末结存数量 = new DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn();
            this.gridCol月末结存单价 = new DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn();
            this.gridCol月末结存金额 = new DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn();
            this.本月耗用 = new DevExpress.XtraGrid.Views.BandedGrid.GridBand();
            this.gridCol本月耗用数量 = new DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn();
            this.gridCol本月耗用单价 = new DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn();
            this.gridCol本月耗用金额 = new DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn();
            this.label3 = new System.Windows.Forms.Label();
            this.lookUpEdit会计期间 = new DevExpress.XtraEditors.LookUpEdit();
            this.label1 = new System.Windows.Forms.Label();
            this.lookUpEditcDepCode = new DevExpress.XtraEditors.LookUpEdit();
            this.lookUpEditcDepName = new DevExpress.XtraEditors.LookUpEdit();
            this.label2 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label审核 = new System.Windows.Forms.Label();
            this.l会计期间 = new System.Windows.Forms.Label();
            this.l部门编码 = new System.Windows.Forms.Label();
            this.menuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ItemLookUpEditcInvCode)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ItemLookUpEditcInvName)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ItemLookUpEditcInvStd)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ItemLookUpEditcComUnitName)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ItemTextEditN4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lookUpEdit会计期间.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lookUpEditcDepCode.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lookUpEditcDepName.Properties)).BeginInit();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btnClear,
            this.btnSEL,
            this.btnExport,
            this.btnAudit,
            this.btnUnAudit,
            this.btnExcel});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(903, 25);
            this.menuStrip1.TabIndex = 172;
            this.menuStrip1.Text = "menuStrip";
            // 
            // btnClear
            // 
            this.btnClear.Name = "btnClear";
            this.btnClear.Size = new System.Drawing.Size(44, 21);
            this.btnClear.Text = "清空";
            this.btnClear.Click += new System.EventHandler(this.btnClear_Click);
            // 
            // btnSEL
            // 
            this.btnSEL.Name = "btnSEL";
            this.btnSEL.Size = new System.Drawing.Size(44, 21);
            this.btnSEL.Text = "查询";
            this.btnSEL.Click += new System.EventHandler(this.btnSEL_Click);
            // 
            // btnExport
            // 
            this.btnExport.Name = "btnExport";
            this.btnExport.Size = new System.Drawing.Size(44, 21);
            this.btnExport.Text = "导出";
            this.btnExport.Click += new System.EventHandler(this.btnExport_Click);
            // 
            // btnAudit
            // 
            this.btnAudit.Name = "btnAudit";
            this.btnAudit.Size = new System.Drawing.Size(44, 21);
            this.btnAudit.Text = "审核";
            this.btnAudit.Click += new System.EventHandler(this.btnAudit_Click);
            // 
            // btnUnAudit
            // 
            this.btnUnAudit.Name = "btnUnAudit";
            this.btnUnAudit.Size = new System.Drawing.Size(44, 21);
            this.btnUnAudit.Text = "弃审";
            this.btnUnAudit.Click += new System.EventHandler(this.btnUnAudit_Click);
            // 
            // btnExcel
            // 
            this.btnExcel.Name = "btnExcel";
            this.btnExcel.Size = new System.Drawing.Size(44, 21);
            this.btnExcel.Text = "导出";
            this.btnExcel.Click += new System.EventHandler(this.btnExcel_Click_1);
            // 
            // labelControl1
            // 
            this.labelControl1.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.labelControl1.Appearance.Font = new System.Drawing.Font("Tahoma", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelControl1.Location = new System.Drawing.Point(357, 12);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(210, 25);
            this.labelControl1.TabIndex = 190;
            this.labelControl1.Text = "车间材料领用汇总月报";
            // 
            // gridControl1
            // 
            this.gridControl1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.gridControl1.Location = new System.Drawing.Point(3, 81);
            this.gridControl1.LookAndFeel.SkinName = "Office 2010 Blue";
            this.gridControl1.MainView = this.gridView1;
            this.gridControl1.Name = "gridControl1";
            this.gridControl1.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.ItemLookUpEditcInvCode,
            this.ItemLookUpEditcInvName,
            this.ItemLookUpEditcInvStd,
            this.ItemLookUpEditcComUnitName,
            this.ItemTextEditN4});
            this.gridControl1.Size = new System.Drawing.Size(897, 308);
            this.gridControl1.TabIndex = 191;
            this.gridControl1.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView1});
            // 
            // gridView1
            // 
            this.gridView1.Bands.AddRange(new DevExpress.XtraGrid.Views.BandedGrid.GridBand[] {
            this.gridBand材料,
            this.gridBand月初存料,
            this.gridBand收发存汇总,
            this.gridBand月末结存,
            this.本月耗用});
            this.gridView1.Columns.AddRange(new DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn[] {
            this.gridCol材料编码,
            this.gridCol材料名称,
            this.gridCol材料规格,
            this.gridCol单位,
            this.gridCol月初存料数量,
            this.gridCol月初存料金额,
            this.gridCol月初存料单价,
            this.gridCol月末结存数量,
            this.gridCol月末结存金额,
            this.gridCol月末结存单价,
            this.gridCol本月耗用金额,
            this.gridCol本月耗用数量,
            this.gridCol本月耗用单价,
            this.gridCol收发存出库单价,
            this.gridCol收发存出库数量,
            this.gridCol收发存出库金额});
            this.gridView1.GridControl = this.gridControl1;
            this.gridView1.IndicatorWidth = 40;
            this.gridView1.Name = "gridView1";
            this.gridView1.OptionsBehavior.AllowDeleteRows = DevExpress.Utils.DefaultBoolean.True;
            this.gridView1.OptionsBehavior.Editable = false;
            this.gridView1.OptionsBehavior.EditorShowMode = DevExpress.Utils.EditorShowMode.MouseDown;
            this.gridView1.OptionsCustomization.AllowGroup = false;
            this.gridView1.OptionsCustomization.AllowQuickHideColumns = false;
            this.gridView1.OptionsView.ColumnAutoWidth = false;
            this.gridView1.OptionsView.ShowFooter = true;
            this.gridView1.OptionsView.ShowGroupPanel = false;
            this.gridView1.CustomDrawRowIndicator += new DevExpress.XtraGrid.Views.Grid.RowIndicatorCustomDrawEventHandler(this.gridView1_CustomDrawRowIndicator);
            // 
            // gridBand材料
            // 
            this.gridBand材料.AppearanceHeader.Options.UseTextOptions = true;
            this.gridBand材料.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gridBand材料.Caption = "材料";
            this.gridBand材料.Columns.Add(this.gridCol材料编码);
            this.gridBand材料.Columns.Add(this.gridCol材料名称);
            this.gridBand材料.Columns.Add(this.gridCol材料规格);
            this.gridBand材料.Columns.Add(this.gridCol单位);
            this.gridBand材料.Fixed = DevExpress.XtraGrid.Columns.FixedStyle.Left;
            this.gridBand材料.Name = "gridBand材料";
            this.gridBand材料.Width = 300;
            // 
            // gridCol材料编码
            // 
            this.gridCol材料编码.Caption = "材料编码";
            this.gridCol材料编码.ColumnEdit = this.ItemLookUpEditcInvCode;
            this.gridCol材料编码.FieldName = "材料编码";
            this.gridCol材料编码.Name = "gridCol材料编码";
            this.gridCol材料编码.Visible = true;
            // 
            // ItemLookUpEditcInvCode
            // 
            this.ItemLookUpEditcInvCode.AutoHeight = false;
            this.ItemLookUpEditcInvCode.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.ItemLookUpEditcInvCode.DisplayMember = "cInvCode";
            this.ItemLookUpEditcInvCode.Name = "ItemLookUpEditcInvCode";
            this.ItemLookUpEditcInvCode.NullText = "";
            this.ItemLookUpEditcInvCode.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.Standard;
            this.ItemLookUpEditcInvCode.ValueMember = "cInvCode";
            // 
            // gridCol材料名称
            // 
            this.gridCol材料名称.Caption = "材料名称";
            this.gridCol材料名称.ColumnEdit = this.ItemLookUpEditcInvName;
            this.gridCol材料名称.FieldName = "材料编码";
            this.gridCol材料名称.Name = "gridCol材料名称";
            this.gridCol材料名称.Visible = true;
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
            // gridCol材料规格
            // 
            this.gridCol材料规格.Caption = "材料规格";
            this.gridCol材料规格.ColumnEdit = this.ItemLookUpEditcInvStd;
            this.gridCol材料规格.FieldName = "材料编码";
            this.gridCol材料规格.Name = "gridCol材料规格";
            this.gridCol材料规格.Visible = true;
            // 
            // ItemLookUpEditcInvStd
            // 
            this.ItemLookUpEditcInvStd.AutoHeight = false;
            this.ItemLookUpEditcInvStd.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.ItemLookUpEditcInvStd.DisplayMember = "cInvStd";
            this.ItemLookUpEditcInvStd.Name = "ItemLookUpEditcInvStd";
            this.ItemLookUpEditcInvStd.NullText = "";
            this.ItemLookUpEditcInvStd.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.Standard;
            this.ItemLookUpEditcInvStd.ValueMember = "cInvCode";
            // 
            // gridCol单位
            // 
            this.gridCol单位.Caption = "单位";
            this.gridCol单位.ColumnEdit = this.ItemLookUpEditcComUnitName;
            this.gridCol单位.FieldName = "材料编码";
            this.gridCol单位.Name = "gridCol单位";
            this.gridCol单位.Visible = true;
            // 
            // ItemLookUpEditcComUnitName
            // 
            this.ItemLookUpEditcComUnitName.AutoHeight = false;
            this.ItemLookUpEditcComUnitName.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.ItemLookUpEditcComUnitName.DisplayMember = "cComUnitName";
            this.ItemLookUpEditcComUnitName.Name = "ItemLookUpEditcComUnitName";
            this.ItemLookUpEditcComUnitName.NullText = "";
            this.ItemLookUpEditcComUnitName.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.Standard;
            this.ItemLookUpEditcComUnitName.ValueMember = "cInvCode";
            // 
            // gridBand月初存料
            // 
            this.gridBand月初存料.AppearanceHeader.Options.UseTextOptions = true;
            this.gridBand月初存料.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gridBand月初存料.Caption = "月初存料";
            this.gridBand月初存料.Columns.Add(this.gridCol月初存料数量);
            this.gridBand月初存料.Columns.Add(this.gridCol月初存料单价);
            this.gridBand月初存料.Columns.Add(this.gridCol月初存料金额);
            this.gridBand月初存料.Name = "gridBand月初存料";
            this.gridBand月初存料.Width = 225;
            // 
            // gridCol月初存料数量
            // 
            this.gridCol月初存料数量.Caption = "数量";
            this.gridCol月初存料数量.ColumnEdit = this.ItemTextEditN4;
            this.gridCol月初存料数量.FieldName = "月初存料数量";
            this.gridCol月初存料数量.Name = "gridCol月初存料数量";
            this.gridCol月初存料数量.Visible = true;
            // 
            // ItemTextEditN4
            // 
            this.ItemTextEditN4.AutoHeight = false;
            this.ItemTextEditN4.DisplayFormat.FormatString = "n4";
            this.ItemTextEditN4.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.ItemTextEditN4.EditFormat.FormatString = "n4";
            this.ItemTextEditN4.EditFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.ItemTextEditN4.Mask.EditMask = "n4";
            this.ItemTextEditN4.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Numeric;
            this.ItemTextEditN4.Name = "ItemTextEditN4";
            // 
            // gridCol月初存料单价
            // 
            this.gridCol月初存料单价.Caption = "单价";
            this.gridCol月初存料单价.FieldName = "月初存料单价";
            this.gridCol月初存料单价.Name = "gridCol月初存料单价";
            this.gridCol月初存料单价.Visible = true;
            // 
            // gridCol月初存料金额
            // 
            this.gridCol月初存料金额.Caption = "金额";
            this.gridCol月初存料金额.FieldName = "月初存料金额";
            this.gridCol月初存料金额.Name = "gridCol月初存料金额";
            this.gridCol月初存料金额.Visible = true;
            // 
            // gridBand收发存汇总
            // 
            this.gridBand收发存汇总.AppearanceHeader.Options.UseTextOptions = true;
            this.gridBand收发存汇总.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gridBand收发存汇总.Caption = "收发存汇总";
            this.gridBand收发存汇总.Columns.Add(this.gridCol收发存出库数量);
            this.gridBand收发存汇总.Columns.Add(this.gridCol收发存出库单价);
            this.gridBand收发存汇总.Columns.Add(this.gridCol收发存出库金额);
            this.gridBand收发存汇总.Name = "gridBand收发存汇总";
            this.gridBand收发存汇总.Width = 225;
            // 
            // gridCol收发存出库数量
            // 
            this.gridCol收发存出库数量.Caption = "出库数量";
            this.gridCol收发存出库数量.ColumnEdit = this.ItemTextEditN4;
            this.gridCol收发存出库数量.FieldName = "收发存出库数量";
            this.gridCol收发存出库数量.Name = "gridCol收发存出库数量";
            this.gridCol收发存出库数量.Visible = true;
            // 
            // gridCol收发存出库单价
            // 
            this.gridCol收发存出库单价.Caption = "出库单价";
            this.gridCol收发存出库单价.FieldName = "收发存出库单价";
            this.gridCol收发存出库单价.Name = "gridCol收发存出库单价";
            this.gridCol收发存出库单价.Visible = true;
            // 
            // gridCol收发存出库金额
            // 
            this.gridCol收发存出库金额.Caption = "出库金额";
            this.gridCol收发存出库金额.FieldName = "收发存出库金额";
            this.gridCol收发存出库金额.Name = "gridCol收发存出库金额";
            this.gridCol收发存出库金额.Visible = true;
            // 
            // gridBand月末结存
            // 
            this.gridBand月末结存.AppearanceHeader.Options.UseTextOptions = true;
            this.gridBand月末结存.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gridBand月末结存.Caption = "月末结存";
            this.gridBand月末结存.Columns.Add(this.gridCol月末结存数量);
            this.gridBand月末结存.Columns.Add(this.gridCol月末结存单价);
            this.gridBand月末结存.Columns.Add(this.gridCol月末结存金额);
            this.gridBand月末结存.Name = "gridBand月末结存";
            this.gridBand月末结存.Width = 225;
            // 
            // gridCol月末结存数量
            // 
            this.gridCol月末结存数量.Caption = "数量";
            this.gridCol月末结存数量.ColumnEdit = this.ItemTextEditN4;
            this.gridCol月末结存数量.FieldName = "月末结存数量";
            this.gridCol月末结存数量.Name = "gridCol月末结存数量";
            this.gridCol月末结存数量.Visible = true;
            // 
            // gridCol月末结存单价
            // 
            this.gridCol月末结存单价.Caption = "单价";
            this.gridCol月末结存单价.FieldName = "月末结存单价";
            this.gridCol月末结存单价.Name = "gridCol月末结存单价";
            this.gridCol月末结存单价.Visible = true;
            // 
            // gridCol月末结存金额
            // 
            this.gridCol月末结存金额.Caption = "金额";
            this.gridCol月末结存金额.FieldName = "月末结存金额";
            this.gridCol月末结存金额.Name = "gridCol月末结存金额";
            this.gridCol月末结存金额.Visible = true;
            // 
            // 本月耗用
            // 
            this.本月耗用.AppearanceHeader.Options.UseTextOptions = true;
            this.本月耗用.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.本月耗用.Caption = "本月耗用";
            this.本月耗用.Columns.Add(this.gridCol本月耗用数量);
            this.本月耗用.Columns.Add(this.gridCol本月耗用单价);
            this.本月耗用.Columns.Add(this.gridCol本月耗用金额);
            this.本月耗用.Name = "本月耗用";
            this.本月耗用.Width = 225;
            // 
            // gridCol本月耗用数量
            // 
            this.gridCol本月耗用数量.Caption = "数量";
            this.gridCol本月耗用数量.ColumnEdit = this.ItemTextEditN4;
            this.gridCol本月耗用数量.FieldName = "本月耗用数量";
            this.gridCol本月耗用数量.Name = "gridCol本月耗用数量";
            this.gridCol本月耗用数量.Visible = true;
            // 
            // gridCol本月耗用单价
            // 
            this.gridCol本月耗用单价.Caption = "单价";
            this.gridCol本月耗用单价.FieldName = "本月耗用单价";
            this.gridCol本月耗用单价.Name = "gridCol本月耗用单价";
            this.gridCol本月耗用单价.Visible = true;
            // 
            // gridCol本月耗用金额
            // 
            this.gridCol本月耗用金额.Caption = "金额";
            this.gridCol本月耗用金额.FieldName = "本月耗用金额";
            this.gridCol本月耗用金额.Name = "gridCol本月耗用金额";
            this.gridCol本月耗用金额.Visible = true;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.ForeColor = System.Drawing.Color.Blue;
            this.label3.Location = new System.Drawing.Point(15, 57);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(53, 12);
            this.label3.TabIndex = 192;
            this.label3.Text = "会计期间";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lookUpEdit会计期间
            // 
            this.lookUpEdit会计期间.AllowHtmlTextInToolTip = DevExpress.Utils.DefaultBoolean.True;
            this.lookUpEdit会计期间.Location = new System.Drawing.Point(75, 54);
            this.lookUpEdit会计期间.Name = "lookUpEdit会计期间";
            this.lookUpEdit会计期间.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.lookUpEdit会计期间.Properties.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("会计期间", "会计期间")});
            this.lookUpEdit会计期间.Properties.DisplayMember = "会计期间";
            this.lookUpEdit会计期间.Properties.NullText = "";
            this.lookUpEdit会计期间.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.Standard;
            this.lookUpEdit会计期间.Properties.ValueMember = "会计期间";
            this.lookUpEdit会计期间.Size = new System.Drawing.Size(121, 20);
            this.lookUpEdit会计期间.TabIndex = 193;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.ForeColor = System.Drawing.Color.Blue;
            this.label1.Location = new System.Drawing.Point(207, 57);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(53, 12);
            this.label1.TabIndex = 199;
            this.label1.Text = "部门编码";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lookUpEditcDepCode
            // 
            this.lookUpEditcDepCode.AllowHtmlTextInToolTip = DevExpress.Utils.DefaultBoolean.True;
            this.lookUpEditcDepCode.Location = new System.Drawing.Point(267, 54);
            this.lookUpEditcDepCode.Name = "lookUpEditcDepCode";
            this.lookUpEditcDepCode.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.lookUpEditcDepCode.Properties.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("cDepCode", "部门编码"),
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("cDepName", "部门")});
            this.lookUpEditcDepCode.Properties.DisplayMember = "cDepCode";
            this.lookUpEditcDepCode.Properties.NullText = "";
            this.lookUpEditcDepCode.Properties.PopupWidth = 500;
            this.lookUpEditcDepCode.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.Standard;
            this.lookUpEditcDepCode.Properties.ValueMember = "cDepCode";
            this.lookUpEditcDepCode.Size = new System.Drawing.Size(69, 20);
            this.lookUpEditcDepCode.TabIndex = 200;
            this.lookUpEditcDepCode.EditValueChanged += new System.EventHandler(this.lookUpEditcDepCode_EditValueChanged);
            // 
            // lookUpEditcDepName
            // 
            this.lookUpEditcDepName.AllowHtmlTextInToolTip = DevExpress.Utils.DefaultBoolean.True;
            this.lookUpEditcDepName.Location = new System.Drawing.Point(375, 54);
            this.lookUpEditcDepName.Name = "lookUpEditcDepName";
            this.lookUpEditcDepName.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.lookUpEditcDepName.Properties.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("cDepCode", "部门编码"),
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("cDepName", "部门")});
            this.lookUpEditcDepName.Properties.DisplayMember = "cDepName";
            this.lookUpEditcDepName.Properties.NullText = "";
            this.lookUpEditcDepName.Properties.PopupWidth = 500;
            this.lookUpEditcDepName.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.Standard;
            this.lookUpEditcDepName.Properties.ValueMember = "cDepCode";
            this.lookUpEditcDepName.Size = new System.Drawing.Size(145, 20);
            this.lookUpEditcDepName.TabIndex = 201;
            this.lookUpEditcDepName.EditValueChanged += new System.EventHandler(this.lookUpEditcDepName_EditValueChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(341, 57);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(29, 12);
            this.label2.TabIndex = 202;
            this.label2.Text = "部门";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // panel1
            // 
            this.panel1.AutoScroll = true;
            this.panel1.Controls.Add(this.label审核);
            this.panel1.Controls.Add(this.l会计期间);
            this.panel1.Controls.Add(this.l部门编码);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.lookUpEditcDepName);
            this.panel1.Controls.Add(this.lookUpEditcDepCode);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.lookUpEdit会计期间);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.gridControl1);
            this.panel1.Controls.Add(this.labelControl1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 25);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(903, 392);
            this.panel1.TabIndex = 173;
            // 
            // label审核
            // 
            this.label审核.AutoSize = true;
            this.label审核.ForeColor = System.Drawing.Color.Blue;
            this.label审核.Location = new System.Drawing.Point(533, 59);
            this.label审核.Name = "label审核";
            this.label审核.Size = new System.Drawing.Size(41, 12);
            this.label审核.TabIndex = 205;
            this.label审核.Text = "审核人";
            this.label审核.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // l会计期间
            // 
            this.l会计期间.AutoSize = true;
            this.l会计期间.ForeColor = System.Drawing.Color.Blue;
            this.l会计期间.Location = new System.Drawing.Point(657, 57);
            this.l会计期间.Name = "l会计期间";
            this.l会计期间.Size = new System.Drawing.Size(53, 12);
            this.l会计期间.TabIndex = 204;
            this.l会计期间.Text = "会计期间";
            this.l会计期间.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.l会计期间.Visible = false;
            // 
            // l部门编码
            // 
            this.l部门编码.AutoSize = true;
            this.l部门编码.ForeColor = System.Drawing.Color.Blue;
            this.l部门编码.Location = new System.Drawing.Point(591, 57);
            this.l部门编码.Name = "l部门编码";
            this.l部门编码.Size = new System.Drawing.Size(53, 12);
            this.l部门编码.TabIndex = 203;
            this.l部门编码.Text = "部门编码";
            this.l部门编码.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.l部门编码.Visible = false;
            // 
            // 车间材料领用汇总月报
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.menuStrip1);
            this.Name = "车间材料领用汇总月报";
            this.Size = new System.Drawing.Size(903, 417);
            this.Load += new System.EventHandler(this.Frm_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ItemLookUpEditcInvCode)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ItemLookUpEditcInvName)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ItemLookUpEditcInvStd)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ItemLookUpEditcComUnitName)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ItemTextEditN4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lookUpEdit会计期间.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lookUpEditcDepCode.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lookUpEditcDepName.Properties)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem btnExport;
        private System.Windows.Forms.ToolStripMenuItem btnSEL;
        private DevExpress.XtraEditors.LabelControl labelControl1;
        private DevExpress.XtraGrid.GridControl gridControl1;
        private System.Windows.Forms.Label label3;
        private DevExpress.XtraEditors.LookUpEdit lookUpEdit会计期间;
        private System.Windows.Forms.Label label1;
        private DevExpress.XtraEditors.LookUpEdit lookUpEditcDepCode;
        private DevExpress.XtraEditors.LookUpEdit lookUpEditcDepName;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.ToolStripMenuItem btnClear;
        private DevExpress.XtraGrid.Views.BandedGrid.BandedGridView gridView1;
        private DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn gridCol材料编码;
        private DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn gridCol材料名称;
        private DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn gridCol材料规格;
        private DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn gridCol单位;
        private DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn gridCol月初存料数量;
        private DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn gridCol月初存料金额;
        private DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn gridCol月初存料单价;
        private DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn gridCol月末结存数量;
        private DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn gridCol月末结存金额;
        private DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn gridCol月末结存单价;
        private DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn gridCol本月耗用金额;
        private DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn gridCol本月耗用数量;
        private DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn gridCol本月耗用单价;
        private DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn gridCol收发存出库单价;
        private DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn gridCol收发存出库数量;
        private DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn gridCol收发存出库金额;
        private System.Windows.Forms.ToolStripMenuItem btnAudit;
        private System.Windows.Forms.ToolStripMenuItem btnUnAudit;
        private System.Windows.Forms.Label l会计期间;
        private System.Windows.Forms.Label l部门编码;
        private DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit ItemLookUpEditcInvCode;
        private DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit ItemLookUpEditcInvName;
        private DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit ItemLookUpEditcInvStd;
        private DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit ItemLookUpEditcComUnitName;
        private DevExpress.XtraGrid.Views.BandedGrid.GridBand gridBand材料;
        private DevExpress.XtraGrid.Views.BandedGrid.GridBand gridBand月初存料;
        private DevExpress.XtraGrid.Views.BandedGrid.GridBand gridBand月末结存;
        private DevExpress.XtraGrid.Views.BandedGrid.GridBand 本月耗用;
        private DevExpress.XtraGrid.Views.BandedGrid.GridBand gridBand收发存汇总;
        private System.Windows.Forms.Label label审核;
        private DevExpress.XtraEditors.Repository.RepositoryItemTextEdit ItemTextEditN4;
        private System.Windows.Forms.ToolStripMenuItem btnExcel;
    }
}
