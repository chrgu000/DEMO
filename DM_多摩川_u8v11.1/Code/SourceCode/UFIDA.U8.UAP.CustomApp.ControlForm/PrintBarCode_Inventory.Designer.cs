namespace UFIDA.U8.UAP.CustomApp.ControlForm
{
    partial class PrintBarCode_Inventory
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(PrintBarCode_Inventory));
            this.chkAll = new System.Windows.Forms.CheckBox();
            this.btnPrintSet = new DevExpress.XtraEditors.SimpleButton();
            this.btnPrint = new DevExpress.XtraEditors.SimpleButton();
            this.btnExcel = new DevExpress.XtraEditors.SimpleButton();
            this.gridControl1 = new DevExpress.XtraGrid.GridControl();
            this.gridView1 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.gridColchoose = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColcInvCode = new DevExpress.XtraGrid.Columns.GridColumn();
            this.ItemLookUpEditcInvCode = new DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit();
            this.gridColcInvName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.ItemLookUpEditcInvName = new DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit();
            this.gridColcInvStd = new DevExpress.XtraGrid.Columns.GridColumn();
            this.ItemLookUpEditcInvStd = new DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit();
            this.gridColExType = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColExCode = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColExVenCode = new DevExpress.XtraGrid.Columns.GridColumn();
            this.ItemLookUpEditcVenCode = new DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit();
            this.gridColExVenName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.ItemLookUpEditcVenName = new DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit();
            this.gridColCreateUserName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColCreateDate = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColiQty = new DevExpress.XtraGrid.Columns.GridColumn();
            this.ItemTextEditn2 = new DevExpress.XtraEditors.Repository.RepositoryItemTextEdit();
            this.gridColExBatchQty = new DevExpress.XtraGrid.Columns.GridColumn();
            this.ItemTextEditn0 = new DevExpress.XtraEditors.Repository.RepositoryItemTextEdit();
            this.gridColPosCode = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColBatch = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColcWhCode = new DevExpress.XtraGrid.Columns.GridColumn();
            this.ItemLookUpEditcWhCode = new DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit();
            this.gridColcWhName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.ItemLookUpEditcWhName = new DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit();
            this.gridColExDepCode = new DevExpress.XtraGrid.Columns.GridColumn();
            this.ItemLookUpEditcDepCode = new DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit();
            this.gridColExDepName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.ItemLookUpEditcDepName = new DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit();
            this.gridColExRowNo = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColBarCode = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColSerialNO = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColGUID = new DevExpress.XtraGrid.Columns.GridColumn();
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            this.btnDelRow = new DevExpress.XtraEditors.SimpleButton();
            this.btnAddRow = new DevExpress.XtraEditors.SimpleButton();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ItemLookUpEditcInvCode)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ItemLookUpEditcInvName)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ItemLookUpEditcInvStd)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ItemLookUpEditcVenCode)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ItemLookUpEditcVenName)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ItemTextEditn2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ItemTextEditn0)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ItemLookUpEditcWhCode)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ItemLookUpEditcWhName)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ItemLookUpEditcDepCode)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ItemLookUpEditcDepName)).BeginInit();
            this.SuspendLayout();
            // 
            // chkAll
            // 
            this.chkAll.AutoSize = true;
            this.chkAll.Location = new System.Drawing.Point(12, 90);
            this.chkAll.Name = "chkAll";
            this.chkAll.Size = new System.Drawing.Size(48, 16);
            this.chkAll.TabIndex = 155;
            this.chkAll.Text = "全选";
            this.chkAll.UseVisualStyleBackColor = true;
            this.chkAll.CheckedChanged += new System.EventHandler(this.chkAll_CheckedChanged);
            // 
            // btnPrintSet
            // 
            this.btnPrintSet.Image = ((System.Drawing.Image)(resources.GetObject("btnPrintSet.Image")));
            this.btnPrintSet.ImageLocation = DevExpress.XtraEditors.ImageLocation.TopCenter;
            this.btnPrintSet.Location = new System.Drawing.Point(278, 65);
            this.btnPrintSet.Name = "btnPrintSet";
            this.btnPrintSet.Size = new System.Drawing.Size(61, 41);
            this.btnPrintSet.TabIndex = 154;
            this.btnPrintSet.Text = "打印设置";
            this.btnPrintSet.Click += new System.EventHandler(this.btnPrintSet_Click);
            // 
            // btnPrint
            // 
            this.btnPrint.Image = ((System.Drawing.Image)(resources.GetObject("btnPrint.Image")));
            this.btnPrint.ImageLocation = DevExpress.XtraEditors.ImageLocation.TopCenter;
            this.btnPrint.Location = new System.Drawing.Point(226, 65);
            this.btnPrint.Name = "btnPrint";
            this.btnPrint.Size = new System.Drawing.Size(46, 41);
            this.btnPrint.TabIndex = 150;
            this.btnPrint.Text = "打印";
            this.btnPrint.Click += new System.EventHandler(this.btnPrint_Click);
            // 
            // btnExcel
            // 
            this.btnExcel.Image = ((System.Drawing.Image)(resources.GetObject("btnExcel.Image")));
            this.btnExcel.ImageLocation = DevExpress.XtraEditors.ImageLocation.TopCenter;
            this.btnExcel.Location = new System.Drawing.Point(174, 65);
            this.btnExcel.Name = "btnExcel";
            this.btnExcel.Size = new System.Drawing.Size(46, 41);
            this.btnExcel.TabIndex = 148;
            this.btnExcel.Text = "导出";
            this.btnExcel.Click += new System.EventHandler(this.btnExcel_Click);
            // 
            // gridControl1
            // 
            this.gridControl1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.gridControl1.Location = new System.Drawing.Point(3, 112);
            this.gridControl1.LookAndFeel.SkinName = "Office 2010 Blue";
            this.gridControl1.MainView = this.gridView1;
            this.gridControl1.Name = "gridControl1";
            this.gridControl1.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.ItemTextEditn2,
            this.ItemTextEditn0,
            this.ItemLookUpEditcInvCode,
            this.ItemLookUpEditcInvName,
            this.ItemLookUpEditcInvStd,
            this.ItemLookUpEditcVenCode,
            this.ItemLookUpEditcVenName,
            this.ItemLookUpEditcWhCode,
            this.ItemLookUpEditcWhName,
            this.ItemLookUpEditcDepCode,
            this.ItemLookUpEditcDepName});
            this.gridControl1.Size = new System.Drawing.Size(1085, 256);
            this.gridControl1.TabIndex = 140;
            this.gridControl1.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView1});
            // 
            // gridView1
            // 
            this.gridView1.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.gridColchoose,
            this.gridColcInvCode,
            this.gridColcInvName,
            this.gridColcInvStd,
            this.gridColExType,
            this.gridColExCode,
            this.gridColExVenCode,
            this.gridColExVenName,
            this.gridColCreateUserName,
            this.gridColCreateDate,
            this.gridColiQty,
            this.gridColExBatchQty,
            this.gridColPosCode,
            this.gridColBatch,
            this.gridColcWhCode,
            this.gridColcWhName,
            this.gridColExDepCode,
            this.gridColExDepName,
            this.gridColExRowNo,
            this.gridColBarCode,
            this.gridColSerialNO,
            this.gridColGUID});
            this.gridView1.GridControl = this.gridControl1;
            this.gridView1.IndicatorWidth = 40;
            this.gridView1.Name = "gridView1";
            this.gridView1.OptionsBehavior.AllowDeleteRows = DevExpress.Utils.DefaultBoolean.True;
            this.gridView1.OptionsBehavior.EditorShowMode = DevExpress.Utils.EditorShowMode.MouseDown;
            this.gridView1.OptionsCustomization.AllowGroup = false;
            this.gridView1.OptionsCustomization.AllowQuickHideColumns = false;
            this.gridView1.OptionsView.ColumnAutoWidth = false;
            this.gridView1.OptionsView.ShowGroupPanel = false;
            this.gridView1.CustomDrawRowIndicator += new DevExpress.XtraGrid.Views.Grid.RowIndicatorCustomDrawEventHandler(this.gridView1_CustomDrawRowIndicator);
            this.gridView1.CellValueChanged += new DevExpress.XtraGrid.Views.Base.CellValueChangedEventHandler(this.gridView1_CellValueChanged);
            // 
            // gridColchoose
            // 
            this.gridColchoose.Caption = "选择";
            this.gridColchoose.FieldName = "choose";
            this.gridColchoose.Name = "gridColchoose";
            this.gridColchoose.Visible = true;
            this.gridColchoose.VisibleIndex = 0;
            this.gridColchoose.Width = 34;
            // 
            // gridColcInvCode
            // 
            this.gridColcInvCode.Caption = "存货编码";
            this.gridColcInvCode.ColumnEdit = this.ItemLookUpEditcInvCode;
            this.gridColcInvCode.FieldName = "cInvCode";
            this.gridColcInvCode.Name = "gridColcInvCode";
            this.gridColcInvCode.Visible = true;
            this.gridColcInvCode.VisibleIndex = 1;
            // 
            // ItemLookUpEditcInvCode
            // 
            this.ItemLookUpEditcInvCode.AutoHeight = false;
            this.ItemLookUpEditcInvCode.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.ItemLookUpEditcInvCode.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("cInvCode", "存货编码"),
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("cInvName", "存货名称"),
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("cInvStd", "规格型号")});
            this.ItemLookUpEditcInvCode.DisplayMember = "cInvCode";
            this.ItemLookUpEditcInvCode.Name = "ItemLookUpEditcInvCode";
            this.ItemLookUpEditcInvCode.NullText = "";
            this.ItemLookUpEditcInvCode.PopupWidth = 500;
            this.ItemLookUpEditcInvCode.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.Standard;
            this.ItemLookUpEditcInvCode.ValueMember = "cInvCode";
            // 
            // gridColcInvName
            // 
            this.gridColcInvName.Caption = "存货名称";
            this.gridColcInvName.ColumnEdit = this.ItemLookUpEditcInvName;
            this.gridColcInvName.FieldName = "cInvCode";
            this.gridColcInvName.Name = "gridColcInvName";
            this.gridColcInvName.Visible = true;
            this.gridColcInvName.VisibleIndex = 2;
            // 
            // ItemLookUpEditcInvName
            // 
            this.ItemLookUpEditcInvName.AutoHeight = false;
            this.ItemLookUpEditcInvName.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.ItemLookUpEditcInvName.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("cInvCode", "存货编码"),
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("cInvName", "存货名称"),
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("cInvStd", "规格型号")});
            this.ItemLookUpEditcInvName.DisplayMember = "cInvName";
            this.ItemLookUpEditcInvName.Name = "ItemLookUpEditcInvName";
            this.ItemLookUpEditcInvName.NullText = "";
            this.ItemLookUpEditcInvName.PopupWidth = 500;
            this.ItemLookUpEditcInvName.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.Standard;
            this.ItemLookUpEditcInvName.ValueMember = "cInvCode";
            // 
            // gridColcInvStd
            // 
            this.gridColcInvStd.Caption = "规格型号";
            this.gridColcInvStd.ColumnEdit = this.ItemLookUpEditcInvStd;
            this.gridColcInvStd.FieldName = "cInvCode";
            this.gridColcInvStd.Name = "gridColcInvStd";
            this.gridColcInvStd.Visible = true;
            this.gridColcInvStd.VisibleIndex = 3;
            // 
            // ItemLookUpEditcInvStd
            // 
            this.ItemLookUpEditcInvStd.AutoHeight = false;
            this.ItemLookUpEditcInvStd.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.ItemLookUpEditcInvStd.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("cInvCode", "存货编码"),
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("cInvName", "存货名称"),
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("cInvStd", "规格型号")});
            this.ItemLookUpEditcInvStd.DisplayMember = "cInvStd";
            this.ItemLookUpEditcInvStd.Name = "ItemLookUpEditcInvStd";
            this.ItemLookUpEditcInvStd.NullText = "";
            this.ItemLookUpEditcInvStd.PopupWidth = 500;
            this.ItemLookUpEditcInvStd.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.Standard;
            this.ItemLookUpEditcInvStd.ValueMember = "cInvCode";
            // 
            // gridColExType
            // 
            this.gridColExType.Caption = "业务类型";
            this.gridColExType.FieldName = "ExType";
            this.gridColExType.Name = "gridColExType";
            this.gridColExType.Visible = true;
            this.gridColExType.VisibleIndex = 7;
            this.gridColExType.Width = 59;
            // 
            // gridColExCode
            // 
            this.gridColExCode.Caption = "来源单据号";
            this.gridColExCode.FieldName = "ExCode";
            this.gridColExCode.Name = "gridColExCode";
            this.gridColExCode.Visible = true;
            this.gridColExCode.VisibleIndex = 8;
            // 
            // gridColExVenCode
            // 
            this.gridColExVenCode.Caption = "供应商编码";
            this.gridColExVenCode.ColumnEdit = this.ItemLookUpEditcVenCode;
            this.gridColExVenCode.FieldName = "ExVenCode";
            this.gridColExVenCode.Name = "gridColExVenCode";
            this.gridColExVenCode.Visible = true;
            this.gridColExVenCode.VisibleIndex = 10;
            // 
            // ItemLookUpEditcVenCode
            // 
            this.ItemLookUpEditcVenCode.AutoHeight = false;
            this.ItemLookUpEditcVenCode.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.ItemLookUpEditcVenCode.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("cVenCode", "编码"),
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("cVenName", "名称")});
            this.ItemLookUpEditcVenCode.DisplayMember = "cVenCode";
            this.ItemLookUpEditcVenCode.Name = "ItemLookUpEditcVenCode";
            this.ItemLookUpEditcVenCode.NullText = "";
            this.ItemLookUpEditcVenCode.PopupWidth = 500;
            this.ItemLookUpEditcVenCode.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.Standard;
            this.ItemLookUpEditcVenCode.ValueMember = "cVenCode";
            // 
            // gridColExVenName
            // 
            this.gridColExVenName.Caption = "供应商";
            this.gridColExVenName.ColumnEdit = this.ItemLookUpEditcVenName;
            this.gridColExVenName.FieldName = "ExVenCode";
            this.gridColExVenName.Name = "gridColExVenName";
            this.gridColExVenName.Visible = true;
            this.gridColExVenName.VisibleIndex = 11;
            this.gridColExVenName.Width = 170;
            // 
            // ItemLookUpEditcVenName
            // 
            this.ItemLookUpEditcVenName.AutoHeight = false;
            this.ItemLookUpEditcVenName.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.ItemLookUpEditcVenName.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("cVenCode", "编码"),
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("cVenName", "名称")});
            this.ItemLookUpEditcVenName.DisplayMember = "cVenName";
            this.ItemLookUpEditcVenName.Name = "ItemLookUpEditcVenName";
            this.ItemLookUpEditcVenName.NullText = "";
            this.ItemLookUpEditcVenName.PopupWidth = 500;
            this.ItemLookUpEditcVenName.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.Standard;
            this.ItemLookUpEditcVenName.ValueMember = "cVenCode";
            // 
            // gridColCreateUserName
            // 
            this.gridColCreateUserName.Caption = "制单人";
            this.gridColCreateUserName.FieldName = "CreateUserName";
            this.gridColCreateUserName.Name = "gridColCreateUserName";
            this.gridColCreateUserName.Visible = true;
            this.gridColCreateUserName.VisibleIndex = 18;
            // 
            // gridColCreateDate
            // 
            this.gridColCreateDate.Caption = "制单日期";
            this.gridColCreateDate.FieldName = "CreateDate";
            this.gridColCreateDate.Name = "gridColCreateDate";
            this.gridColCreateDate.Visible = true;
            this.gridColCreateDate.VisibleIndex = 19;
            this.gridColCreateDate.Width = 65;
            // 
            // gridColiQty
            // 
            this.gridColiQty.Caption = "数量";
            this.gridColiQty.ColumnEdit = this.ItemTextEditn2;
            this.gridColiQty.FieldName = "iQty";
            this.gridColiQty.Name = "gridColiQty";
            this.gridColiQty.Visible = true;
            this.gridColiQty.VisibleIndex = 4;
            // 
            // ItemTextEditn2
            // 
            this.ItemTextEditn2.AutoHeight = false;
            this.ItemTextEditn2.DisplayFormat.FormatString = "n2";
            this.ItemTextEditn2.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.ItemTextEditn2.EditFormat.FormatString = "n2";
            this.ItemTextEditn2.EditFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.ItemTextEditn2.Mask.EditMask = "n2";
            this.ItemTextEditn2.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Numeric;
            this.ItemTextEditn2.Name = "ItemTextEditn2";
            // 
            // gridColExBatchQty
            // 
            this.gridColExBatchQty.Caption = "包装批量";
            this.gridColExBatchQty.ColumnEdit = this.ItemTextEditn0;
            this.gridColExBatchQty.FieldName = "ExBatchQty";
            this.gridColExBatchQty.Name = "gridColExBatchQty";
            this.gridColExBatchQty.Visible = true;
            this.gridColExBatchQty.VisibleIndex = 5;
            // 
            // ItemTextEditn0
            // 
            this.ItemTextEditn0.AutoHeight = false;
            this.ItemTextEditn0.DisplayFormat.FormatString = "n0";
            this.ItemTextEditn0.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.ItemTextEditn0.EditFormat.FormatString = "n0";
            this.ItemTextEditn0.EditFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.ItemTextEditn0.Mask.EditMask = "n0";
            this.ItemTextEditn0.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Numeric;
            this.ItemTextEditn0.Name = "ItemTextEditn0";
            // 
            // gridColPosCode
            // 
            this.gridColPosCode.Caption = "货位";
            this.gridColPosCode.FieldName = "PosCode";
            this.gridColPosCode.Name = "gridColPosCode";
            this.gridColPosCode.Visible = true;
            this.gridColPosCode.VisibleIndex = 6;
            this.gridColPosCode.Width = 72;
            // 
            // gridColBatch
            // 
            this.gridColBatch.Caption = "批号";
            this.gridColBatch.FieldName = "Batch";
            this.gridColBatch.Name = "gridColBatch";
            this.gridColBatch.Visible = true;
            this.gridColBatch.VisibleIndex = 17;
            // 
            // gridColcWhCode
            // 
            this.gridColcWhCode.Caption = "仓库编码";
            this.gridColcWhCode.ColumnEdit = this.ItemLookUpEditcWhCode;
            this.gridColcWhCode.FieldName = "cWhCode";
            this.gridColcWhCode.Name = "gridColcWhCode";
            this.gridColcWhCode.Visible = true;
            this.gridColcWhCode.VisibleIndex = 14;
            this.gridColcWhCode.Width = 59;
            // 
            // ItemLookUpEditcWhCode
            // 
            this.ItemLookUpEditcWhCode.AutoHeight = false;
            this.ItemLookUpEditcWhCode.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.ItemLookUpEditcWhCode.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("cWhCode", "编码"),
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("cWhName", "名称")});
            this.ItemLookUpEditcWhCode.DisplayMember = "cWhCode";
            this.ItemLookUpEditcWhCode.Name = "ItemLookUpEditcWhCode";
            this.ItemLookUpEditcWhCode.NullText = "";
            this.ItemLookUpEditcWhCode.PopupWidth = 500;
            this.ItemLookUpEditcWhCode.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.Standard;
            this.ItemLookUpEditcWhCode.ValueMember = "cWhCode";
            // 
            // gridColcWhName
            // 
            this.gridColcWhName.Caption = "仓库";
            this.gridColcWhName.ColumnEdit = this.ItemLookUpEditcWhName;
            this.gridColcWhName.FieldName = "cWhCode";
            this.gridColcWhName.Name = "gridColcWhName";
            this.gridColcWhName.Visible = true;
            this.gridColcWhName.VisibleIndex = 15;
            // 
            // ItemLookUpEditcWhName
            // 
            this.ItemLookUpEditcWhName.AutoHeight = false;
            this.ItemLookUpEditcWhName.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.ItemLookUpEditcWhName.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("cWhCode", "编码"),
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("cWhName", "名称")});
            this.ItemLookUpEditcWhName.DisplayMember = "cWhName";
            this.ItemLookUpEditcWhName.Name = "ItemLookUpEditcWhName";
            this.ItemLookUpEditcWhName.NullText = "";
            this.ItemLookUpEditcWhName.PopupWidth = 500;
            this.ItemLookUpEditcWhName.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.Standard;
            this.ItemLookUpEditcWhName.ValueMember = "cWhCode";
            // 
            // gridColExDepCode
            // 
            this.gridColExDepCode.Caption = "部门编码";
            this.gridColExDepCode.ColumnEdit = this.ItemLookUpEditcDepCode;
            this.gridColExDepCode.FieldName = "ExDepCode";
            this.gridColExDepCode.Name = "gridColExDepCode";
            this.gridColExDepCode.Visible = true;
            this.gridColExDepCode.VisibleIndex = 12;
            this.gridColExDepCode.Width = 57;
            // 
            // ItemLookUpEditcDepCode
            // 
            this.ItemLookUpEditcDepCode.AutoHeight = false;
            this.ItemLookUpEditcDepCode.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.ItemLookUpEditcDepCode.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("cDepCode", "编码"),
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("cDepName", "名称")});
            this.ItemLookUpEditcDepCode.DisplayMember = "cDepCode";
            this.ItemLookUpEditcDepCode.Name = "ItemLookUpEditcDepCode";
            this.ItemLookUpEditcDepCode.NullText = "";
            this.ItemLookUpEditcDepCode.PopupWidth = 500;
            this.ItemLookUpEditcDepCode.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.Standard;
            this.ItemLookUpEditcDepCode.ValueMember = "cDepCode";
            // 
            // gridColExDepName
            // 
            this.gridColExDepName.Caption = "部门";
            this.gridColExDepName.ColumnEdit = this.ItemLookUpEditcDepName;
            this.gridColExDepName.FieldName = "ExDepCode";
            this.gridColExDepName.Name = "gridColExDepName";
            this.gridColExDepName.Visible = true;
            this.gridColExDepName.VisibleIndex = 13;
            // 
            // ItemLookUpEditcDepName
            // 
            this.ItemLookUpEditcDepName.AutoHeight = false;
            this.ItemLookUpEditcDepName.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.ItemLookUpEditcDepName.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("cDepCode", "编码"),
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("cDepName", "名称")});
            this.ItemLookUpEditcDepName.DisplayMember = "cDepName";
            this.ItemLookUpEditcDepName.Name = "ItemLookUpEditcDepName";
            this.ItemLookUpEditcDepName.NullText = "";
            this.ItemLookUpEditcDepName.PopupWidth = 500;
            this.ItemLookUpEditcDepName.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.Standard;
            this.ItemLookUpEditcDepName.ValueMember = "cDepCode";
            // 
            // gridColExRowNo
            // 
            this.gridColExRowNo.Caption = "行号";
            this.gridColExRowNo.FieldName = "ExRowNo";
            this.gridColExRowNo.Name = "gridColExRowNo";
            this.gridColExRowNo.Visible = true;
            this.gridColExRowNo.VisibleIndex = 9;
            this.gridColExRowNo.Width = 37;
            // 
            // gridColBarCode
            // 
            this.gridColBarCode.Caption = "条形码";
            this.gridColBarCode.FieldName = "BarCode";
            this.gridColBarCode.Name = "gridColBarCode";
            this.gridColBarCode.Width = 62;
            // 
            // gridColSerialNO
            // 
            this.gridColSerialNO.Caption = "序列号";
            this.gridColSerialNO.FieldName = "SerialNO";
            this.gridColSerialNO.Name = "gridColSerialNO";
            this.gridColSerialNO.Visible = true;
            this.gridColSerialNO.VisibleIndex = 16;
            // 
            // gridColGUID
            // 
            this.gridColGUID.Caption = "GUID";
            this.gridColGUID.FieldName = "GUID";
            this.gridColGUID.Name = "gridColGUID";
            this.gridColGUID.OptionsColumn.AllowEdit = false;
            this.gridColGUID.Visible = true;
            this.gridColGUID.VisibleIndex = 20;
            // 
            // labelControl1
            // 
            this.labelControl1.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.labelControl1.Appearance.Font = new System.Drawing.Font("Tahoma", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelControl1.Location = new System.Drawing.Point(469, 18);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(147, 25);
            this.labelControl1.TabIndex = 139;
            this.labelControl1.Text = "存货条形码打印";
            // 
            // btnDelRow
            // 
            this.btnDelRow.Image = ((System.Drawing.Image)(resources.GetObject("btnDelRow.Image")));
            this.btnDelRow.ImageLocation = DevExpress.XtraEditors.ImageLocation.TopCenter;
            this.btnDelRow.Location = new System.Drawing.Point(118, 65);
            this.btnDelRow.Name = "btnDelRow";
            this.btnDelRow.Size = new System.Drawing.Size(46, 41);
            this.btnDelRow.TabIndex = 156;
            this.btnDelRow.Text = "删行";
            this.btnDelRow.Click += new System.EventHandler(this.btnDelRow_Click);
            // 
            // btnAddRow
            // 
            this.btnAddRow.Image = ((System.Drawing.Image)(resources.GetObject("btnAddRow.Image")));
            this.btnAddRow.ImageLocation = DevExpress.XtraEditors.ImageLocation.TopCenter;
            this.btnAddRow.Location = new System.Drawing.Point(66, 65);
            this.btnAddRow.Name = "btnAddRow";
            this.btnAddRow.Size = new System.Drawing.Size(46, 41);
            this.btnAddRow.TabIndex = 157;
            this.btnAddRow.Text = "增行";
            this.btnAddRow.Click += new System.EventHandler(this.btnAddRow_Click);
            // 
            // PrintBarCode_Inventory
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.btnAddRow);
            this.Controls.Add(this.btnDelRow);
            this.Controls.Add(this.chkAll);
            this.Controls.Add(this.btnPrintSet);
            this.Controls.Add(this.btnPrint);
            this.Controls.Add(this.btnExcel);
            this.Controls.Add(this.gridControl1);
            this.Controls.Add(this.labelControl1);
            this.Name = "PrintBarCode_Inventory";
            this.Size = new System.Drawing.Size(1091, 371);
            this.Load += new System.EventHandler(this.Frm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ItemLookUpEditcInvCode)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ItemLookUpEditcInvName)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ItemLookUpEditcInvStd)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ItemLookUpEditcVenCode)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ItemLookUpEditcVenName)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ItemTextEditn2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ItemTextEditn0)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ItemLookUpEditcWhCode)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ItemLookUpEditcWhName)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ItemLookUpEditcDepCode)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ItemLookUpEditcDepName)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.CheckBox chkAll;
        private DevExpress.XtraEditors.SimpleButton btnPrintSet;
        private DevExpress.XtraEditors.SimpleButton btnPrint;
        private DevExpress.XtraEditors.SimpleButton btnExcel;
        private DevExpress.XtraGrid.GridControl gridControl1;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView1;
        private DevExpress.XtraEditors.LabelControl labelControl1;
        private DevExpress.XtraGrid.Columns.GridColumn gridColchoose;
        private DevExpress.XtraGrid.Columns.GridColumn gridColExCode;
        private DevExpress.XtraGrid.Columns.GridColumn gridColCreateDate;
        private DevExpress.XtraGrid.Columns.GridColumn gridColExVenCode;
        private DevExpress.XtraGrid.Columns.GridColumn gridColExVenName;
        private DevExpress.XtraGrid.Columns.GridColumn gridColExType;
        private DevExpress.XtraGrid.Columns.GridColumn gridColCreateUserName;
        private DevExpress.XtraGrid.Columns.GridColumn gridColcInvCode;
        private DevExpress.XtraGrid.Columns.GridColumn gridColcInvName;
        private DevExpress.XtraGrid.Columns.GridColumn gridColcInvStd;
        private DevExpress.XtraGrid.Columns.GridColumn gridColiQty;
        private DevExpress.XtraGrid.Columns.GridColumn gridColExBatchQty;
        private DevExpress.XtraGrid.Columns.GridColumn gridColPosCode;
        private DevExpress.XtraGrid.Columns.GridColumn gridColBatch;
        private DevExpress.XtraGrid.Columns.GridColumn gridColcWhCode;
        private DevExpress.XtraGrid.Columns.GridColumn gridColcWhName;
        private DevExpress.XtraGrid.Columns.GridColumn gridColExDepCode;
        private DevExpress.XtraGrid.Columns.GridColumn gridColExDepName;
        private DevExpress.XtraEditors.Repository.RepositoryItemTextEdit ItemTextEditn2;
        private DevExpress.XtraEditors.Repository.RepositoryItemTextEdit ItemTextEditn0;
        private DevExpress.XtraGrid.Columns.GridColumn gridColExRowNo;
        private DevExpress.XtraGrid.Columns.GridColumn gridColBarCode;
        private DevExpress.XtraGrid.Columns.GridColumn gridColSerialNO;
        private DevExpress.XtraEditors.SimpleButton btnDelRow;
        private DevExpress.XtraEditors.SimpleButton btnAddRow;
        private DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit ItemLookUpEditcInvCode;
        private DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit ItemLookUpEditcInvName;
        private DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit ItemLookUpEditcInvStd;
        private DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit ItemLookUpEditcVenCode;
        private DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit ItemLookUpEditcVenName;
        private DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit ItemLookUpEditcWhCode;
        private DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit ItemLookUpEditcWhName;
        private DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit ItemLookUpEditcDepCode;
        private DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit ItemLookUpEditcDepName;
        private DevExpress.XtraGrid.Columns.GridColumn gridColGUID;
    }
}
