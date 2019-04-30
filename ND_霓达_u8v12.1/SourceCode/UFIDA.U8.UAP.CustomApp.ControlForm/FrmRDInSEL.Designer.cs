namespace UFIDA.U8.UAP.CustomApp.ControlForm
{
    partial class FrmRDInSEL
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
            this.label4 = new System.Windows.Forms.Label();
            this.dtm2 = new DevExpress.XtraEditors.DateEdit();
            this.label3 = new System.Windows.Forms.Label();
            this.labelcInvCCode = new System.Windows.Forms.Label();
            this.dtm1 = new DevExpress.XtraEditors.DateEdit();
            this.gridControl1 = new DevExpress.XtraGrid.GridControl();
            this.gridView1 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.gridColID = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColcVouchType = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColbRdFlag = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColcBusType = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColcSource = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColcWhCode = new DevExpress.XtraGrid.Columns.GridColumn();
            this.ItemLookUpEdit仓库 = new DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit();
            this.gridColdDate = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColcCode = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColcRdCode = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColcDepCode = new DevExpress.XtraGrid.Columns.GridColumn();
            this.ItemLookUpEdit部门 = new DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit();
            this.gridColcPersonCode = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColcHandler = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColcMemo = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColcMaker = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColdnmaketime = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColdnverifytime = new DevExpress.XtraGrid.Columns.GridColumn();
            this.btnSEL = new System.Windows.Forms.Button();
            this.btnOK = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.lookUpEditcCode2 = new DevExpress.XtraEditors.LookUpEdit();
            this.lookUpEditcCode1 = new DevExpress.XtraEditors.LookUpEdit();
            this.label2 = new System.Windows.Forms.Label();
            this.chk包含已生单 = new System.Windows.Forms.CheckBox();
            this.lookUpEditWH1 = new DevExpress.XtraEditors.LookUpEdit();
            this.label1 = new System.Windows.Forms.Label();
            this.lookUpEditDep1 = new DevExpress.XtraEditors.LookUpEdit();
            this.label5 = new System.Windows.Forms.Label();
            this.lookUpEditWH2 = new DevExpress.XtraEditors.LookUpEdit();
            this.lookUpEditDep2 = new DevExpress.XtraEditors.LookUpEdit();
            ((System.ComponentModel.ISupportInitialize)(this.dtm2.Properties.VistaTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtm2.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtm1.Properties.VistaTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtm1.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ItemLookUpEdit仓库)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ItemLookUpEdit部门)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lookUpEditcCode2.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lookUpEditcCode1.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lookUpEditWH1.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lookUpEditDep1.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lookUpEditWH2.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lookUpEditDep2.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(215, 38);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(17, 12);
            this.label4.TabIndex = 236;
            this.label4.Text = "至";
            // 
            // dtm2
            // 
            this.dtm2.EditValue = null;
            this.dtm2.Location = new System.Drawing.Point(238, 34);
            this.dtm2.Name = "dtm2";
            this.dtm2.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.dtm2.Properties.VistaTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
            this.dtm2.Size = new System.Drawing.Size(134, 20);
            this.dtm2.TabIndex = 235;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(14, 38);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(53, 12);
            this.label3.TabIndex = 234;
            this.label3.Text = "单据日期";
            // 
            // labelcInvCCode
            // 
            this.labelcInvCCode.AutoSize = true;
            this.labelcInvCCode.Location = new System.Drawing.Point(14, 12);
            this.labelcInvCCode.Name = "labelcInvCCode";
            this.labelcInvCCode.Size = new System.Drawing.Size(41, 12);
            this.labelcInvCCode.TabIndex = 230;
            this.labelcInvCCode.Text = "单据号";
            // 
            // dtm1
            // 
            this.dtm1.EditValue = null;
            this.dtm1.Location = new System.Drawing.Point(75, 34);
            this.dtm1.Name = "dtm1";
            this.dtm1.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.dtm1.Properties.VistaTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
            this.dtm1.Size = new System.Drawing.Size(134, 20);
            this.dtm1.TabIndex = 227;
            // 
            // gridControl1
            // 
            this.gridControl1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.gridControl1.Location = new System.Drawing.Point(3, 107);
            this.gridControl1.LookAndFeel.SkinName = "Office 2010 Blue";
            this.gridControl1.MainView = this.gridView1;
            this.gridControl1.Name = "gridControl1";
            this.gridControl1.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.ItemLookUpEdit部门,
            this.ItemLookUpEdit仓库});
            this.gridControl1.Size = new System.Drawing.Size(836, 302);
            this.gridControl1.TabIndex = 226;
            this.gridControl1.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView1});
            // 
            // gridView1
            // 
            this.gridView1.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.gridColID,
            this.gridColcVouchType,
            this.gridColbRdFlag,
            this.gridColcBusType,
            this.gridColcSource,
            this.gridColcWhCode,
            this.gridColdDate,
            this.gridColcCode,
            this.gridColcRdCode,
            this.gridColcDepCode,
            this.gridColcPersonCode,
            this.gridColcHandler,
            this.gridColcMemo,
            this.gridColcMaker,
            this.gridColdnmaketime,
            this.gridColdnverifytime});
            this.gridView1.GridControl = this.gridControl1;
            this.gridView1.IndicatorWidth = 40;
            this.gridView1.Name = "gridView1";
            this.gridView1.OptionsBehavior.AllowDeleteRows = DevExpress.Utils.DefaultBoolean.True;
            this.gridView1.OptionsBehavior.Editable = false;
            this.gridView1.OptionsBehavior.EditorShowMode = DevExpress.Utils.EditorShowMode.MouseDown;
            this.gridView1.OptionsCustomization.AllowGroup = false;
            this.gridView1.OptionsCustomization.AllowQuickHideColumns = false;
            this.gridView1.OptionsNavigation.EnterMoveNextColumn = true;
            this.gridView1.OptionsView.ColumnAutoWidth = false;
            this.gridView1.OptionsView.ShowFooter = true;
            this.gridView1.OptionsView.ShowGroupPanel = false;
            this.gridView1.CustomDrawRowIndicator += new DevExpress.XtraGrid.Views.Grid.RowIndicatorCustomDrawEventHandler(this.gridView1_CustomDrawRowIndicator);
            this.gridView1.DoubleClick += new System.EventHandler(this.gridView1_DoubleClick);
            // 
            // gridColID
            // 
            this.gridColID.Caption = "ID";
            this.gridColID.FieldName = "ID";
            this.gridColID.Name = "gridColID";
            // 
            // gridColcVouchType
            // 
            this.gridColcVouchType.Caption = "单据类型";
            this.gridColcVouchType.FieldName = "cVouchType";
            this.gridColcVouchType.Name = "gridColcVouchType";
            // 
            // gridColbRdFlag
            // 
            this.gridColbRdFlag.Caption = "收发标志";
            this.gridColbRdFlag.FieldName = "bRdFlag";
            this.gridColbRdFlag.Name = "gridColbRdFlag";
            // 
            // gridColcBusType
            // 
            this.gridColcBusType.Caption = "业务类型";
            this.gridColcBusType.FieldName = "cBusType";
            this.gridColcBusType.Name = "gridColcBusType";
            // 
            // gridColcSource
            // 
            this.gridColcSource.Caption = "单据来源";
            this.gridColcSource.FieldName = "cSource";
            this.gridColcSource.Name = "gridColcSource";
            // 
            // gridColcWhCode
            // 
            this.gridColcWhCode.Caption = "仓库";
            this.gridColcWhCode.ColumnEdit = this.ItemLookUpEdit仓库;
            this.gridColcWhCode.FieldName = "cWhCode";
            this.gridColcWhCode.Name = "gridColcWhCode";
            this.gridColcWhCode.Visible = true;
            this.gridColcWhCode.VisibleIndex = 2;
            this.gridColcWhCode.Width = 107;
            // 
            // ItemLookUpEdit仓库
            // 
            this.ItemLookUpEdit仓库.AutoHeight = false;
            this.ItemLookUpEdit仓库.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.ItemLookUpEdit仓库.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("cWhCode", "编码"),
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("cWhName", "名称")});
            this.ItemLookUpEdit仓库.DisplayMember = "cWhName";
            this.ItemLookUpEdit仓库.Name = "ItemLookUpEdit仓库";
            this.ItemLookUpEdit仓库.NullText = "";
            this.ItemLookUpEdit仓库.ValueMember = "cWhCode";
            // 
            // gridColdDate
            // 
            this.gridColdDate.Caption = "单据日期";
            this.gridColdDate.FieldName = "dDate";
            this.gridColdDate.Name = "gridColdDate";
            this.gridColdDate.Visible = true;
            this.gridColdDate.VisibleIndex = 1;
            this.gridColdDate.Width = 102;
            // 
            // gridColcCode
            // 
            this.gridColcCode.Caption = "单据号";
            this.gridColcCode.FieldName = "cCode";
            this.gridColcCode.Name = "gridColcCode";
            this.gridColcCode.Visible = true;
            this.gridColcCode.VisibleIndex = 0;
            this.gridColcCode.Width = 123;
            // 
            // gridColcRdCode
            // 
            this.gridColcRdCode.Caption = "收发类别";
            this.gridColcRdCode.FieldName = "cRdCode";
            this.gridColcRdCode.Name = "gridColcRdCode";
            // 
            // gridColcDepCode
            // 
            this.gridColcDepCode.Caption = "部门";
            this.gridColcDepCode.ColumnEdit = this.ItemLookUpEdit部门;
            this.gridColcDepCode.FieldName = "cDepCode";
            this.gridColcDepCode.Name = "gridColcDepCode";
            this.gridColcDepCode.Visible = true;
            this.gridColcDepCode.VisibleIndex = 3;
            this.gridColcDepCode.Width = 95;
            // 
            // ItemLookUpEdit部门
            // 
            this.ItemLookUpEdit部门.AutoHeight = false;
            this.ItemLookUpEdit部门.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.ItemLookUpEdit部门.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("cDepCode", "编码"),
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("cDepName", 60, "名称")});
            this.ItemLookUpEdit部门.DisplayMember = "cDepName";
            this.ItemLookUpEdit部门.Name = "ItemLookUpEdit部门";
            this.ItemLookUpEdit部门.NullText = "";
            this.ItemLookUpEdit部门.ValueMember = "cDepCode";
            // 
            // gridColcPersonCode
            // 
            this.gridColcPersonCode.Caption = "业务员";
            this.gridColcPersonCode.FieldName = "cPersonCode";
            this.gridColcPersonCode.Name = "gridColcPersonCode";
            this.gridColcPersonCode.Visible = true;
            this.gridColcPersonCode.VisibleIndex = 4;
            this.gridColcPersonCode.Width = 101;
            // 
            // gridColcHandler
            // 
            this.gridColcHandler.Caption = "审核人";
            this.gridColcHandler.FieldName = "cHandler";
            this.gridColcHandler.Name = "gridColcHandler";
            this.gridColcHandler.Visible = true;
            this.gridColcHandler.VisibleIndex = 8;
            // 
            // gridColcMemo
            // 
            this.gridColcMemo.Caption = "备注";
            this.gridColcMemo.FieldName = "cMemo";
            this.gridColcMemo.Name = "gridColcMemo";
            this.gridColcMemo.Visible = true;
            this.gridColcMemo.VisibleIndex = 5;
            this.gridColcMemo.Width = 312;
            // 
            // gridColcMaker
            // 
            this.gridColcMaker.Caption = "制单人";
            this.gridColcMaker.FieldName = "cMaker";
            this.gridColcMaker.Name = "gridColcMaker";
            this.gridColcMaker.Visible = true;
            this.gridColcMaker.VisibleIndex = 6;
            // 
            // gridColdnmaketime
            // 
            this.gridColdnmaketime.Caption = "制单时间";
            this.gridColdnmaketime.FieldName = "dnmaketime";
            this.gridColdnmaketime.Name = "gridColdnmaketime";
            this.gridColdnmaketime.Visible = true;
            this.gridColdnmaketime.VisibleIndex = 7;
            // 
            // gridColdnverifytime
            // 
            this.gridColdnverifytime.Caption = "审核时间";
            this.gridColdnverifytime.FieldName = "dVeriDate";
            this.gridColdnverifytime.Name = "gridColdnverifytime";
            this.gridColdnverifytime.Visible = true;
            this.gridColdnverifytime.VisibleIndex = 9;
            // 
            // btnSEL
            // 
            this.btnSEL.Location = new System.Drawing.Point(482, 71);
            this.btnSEL.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.btnSEL.Name = "btnSEL";
            this.btnSEL.Size = new System.Drawing.Size(44, 26);
            this.btnSEL.TabIndex = 238;
            this.btnSEL.Text = "查 询";
            this.btnSEL.UseVisualStyleBackColor = true;
            this.btnSEL.Click += new System.EventHandler(this.btnSEL_Click);
            // 
            // btnOK
            // 
            this.btnOK.Location = new System.Drawing.Point(548, 71);
            this.btnOK.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(44, 26);
            this.btnOK.TabIndex = 239;
            this.btnOK.Text = "确定";
            this.btnOK.UseVisualStyleBackColor = true;
            this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(610, 71);
            this.btnCancel.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(44, 26);
            this.btnCancel.TabIndex = 240;
            this.btnCancel.Text = "取消";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // lookUpEditcCode2
            // 
            this.lookUpEditcCode2.Location = new System.Drawing.Point(238, 10);
            this.lookUpEditcCode2.Name = "lookUpEditcCode2";
            this.lookUpEditcCode2.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.lookUpEditcCode2.Properties.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("cCode", 40, "单据号")});
            this.lookUpEditcCode2.Properties.DisplayMember = "cCode";
            this.lookUpEditcCode2.Properties.NullText = "";
            this.lookUpEditcCode2.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.Standard;
            this.lookUpEditcCode2.Properties.ValueMember = "cCode";
            this.lookUpEditcCode2.Size = new System.Drawing.Size(134, 20);
            this.lookUpEditcCode2.TabIndex = 245;
            // 
            // lookUpEditcCode1
            // 
            this.lookUpEditcCode1.Location = new System.Drawing.Point(75, 10);
            this.lookUpEditcCode1.Name = "lookUpEditcCode1";
            this.lookUpEditcCode1.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.lookUpEditcCode1.Properties.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("cCode", 40, "单据号")});
            this.lookUpEditcCode1.Properties.DisplayMember = "cCode";
            this.lookUpEditcCode1.Properties.NullText = "";
            this.lookUpEditcCode1.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.Standard;
            this.lookUpEditcCode1.Properties.ValueMember = "cCode";
            this.lookUpEditcCode1.Size = new System.Drawing.Size(134, 20);
            this.lookUpEditcCode1.TabIndex = 244;
            this.lookUpEditcCode1.EditValueChanged += new System.EventHandler(this.lookUpEditcCode1_EditValueChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(215, 14);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(17, 12);
            this.label2.TabIndex = 243;
            this.label2.Text = "至";
            // 
            // chk包含已生单
            // 
            this.chk包含已生单.AutoSize = true;
            this.chk包含已生单.Location = new System.Drawing.Point(389, 80);
            this.chk包含已生单.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.chk包含已生单.Name = "chk包含已生单";
            this.chk包含已生单.Size = new System.Drawing.Size(84, 16);
            this.chk包含已生单.TabIndex = 246;
            this.chk包含已生单.Text = "包含已生单";
            this.chk包含已生单.UseVisualStyleBackColor = true;
            // 
            // lookUpEditWH1
            // 
            this.lookUpEditWH1.Location = new System.Drawing.Point(75, 58);
            this.lookUpEditWH1.Name = "lookUpEditWH1";
            this.lookUpEditWH1.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.lookUpEditWH1.Properties.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("cWhCode", 40, "编号"),
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("cWhName", 60, "名称")});
            this.lookUpEditWH1.Properties.DisplayMember = "cWhCode";
            this.lookUpEditWH1.Properties.NullText = "";
            this.lookUpEditWH1.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.Standard;
            this.lookUpEditWH1.Properties.ValueMember = "cWhCode";
            this.lookUpEditWH1.Size = new System.Drawing.Size(134, 20);
            this.lookUpEditWH1.TabIndex = 248;
            this.lookUpEditWH1.EditValueChanged += new System.EventHandler(this.lookUpEditWH1_EditValueChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(14, 62);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(29, 12);
            this.label1.TabIndex = 247;
            this.label1.Text = "仓库";
            // 
            // lookUpEditDep1
            // 
            this.lookUpEditDep1.Location = new System.Drawing.Point(75, 82);
            this.lookUpEditDep1.Name = "lookUpEditDep1";
            this.lookUpEditDep1.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.lookUpEditDep1.Properties.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("cDepCode", 40, "编码"),
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("cDepName", 60, "名称")});
            this.lookUpEditDep1.Properties.DisplayMember = "cDepCode";
            this.lookUpEditDep1.Properties.NullText = "";
            this.lookUpEditDep1.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.Standard;
            this.lookUpEditDep1.Properties.ValueMember = "cDepCode";
            this.lookUpEditDep1.Size = new System.Drawing.Size(134, 20);
            this.lookUpEditDep1.TabIndex = 251;
            this.lookUpEditDep1.EditValueChanged += new System.EventHandler(this.lookUpEditDep1_EditValueChanged);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(14, 86);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(29, 12);
            this.label5.TabIndex = 250;
            this.label5.Text = "部门";
            // 
            // lookUpEditWH2
            // 
            this.lookUpEditWH2.Location = new System.Drawing.Point(215, 59);
            this.lookUpEditWH2.Name = "lookUpEditWH2";
            this.lookUpEditWH2.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.lookUpEditWH2.Properties.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("cWhCode", 40, "编号"),
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("cWhName", 60, "名称")});
            this.lookUpEditWH2.Properties.DisplayMember = "cWhName";
            this.lookUpEditWH2.Properties.NullText = "";
            this.lookUpEditWH2.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.Standard;
            this.lookUpEditWH2.Properties.ValueMember = "cWhCode";
            this.lookUpEditWH2.Size = new System.Drawing.Size(157, 20);
            this.lookUpEditWH2.TabIndex = 253;
            this.lookUpEditWH2.EditValueChanged += new System.EventHandler(this.lookUpEditWH2_EditValueChanged);
            // 
            // lookUpEditDep2
            // 
            this.lookUpEditDep2.Location = new System.Drawing.Point(215, 82);
            this.lookUpEditDep2.Name = "lookUpEditDep2";
            this.lookUpEditDep2.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.lookUpEditDep2.Properties.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("cDepCode", 40, "编码"),
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("cDepName", 60, "名称")});
            this.lookUpEditDep2.Properties.DisplayMember = "cDepName";
            this.lookUpEditDep2.Properties.NullText = "";
            this.lookUpEditDep2.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.Standard;
            this.lookUpEditDep2.Properties.ValueMember = "cDepCode";
            this.lookUpEditDep2.Size = new System.Drawing.Size(157, 20);
            this.lookUpEditDep2.TabIndex = 254;
            this.lookUpEditDep2.EditValueChanged += new System.EventHandler(this.lookUpEditDep2_EditValueChanged);
            // 
            // FrmRDInSEL
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(840, 411);
            this.Controls.Add(this.lookUpEditDep2);
            this.Controls.Add(this.lookUpEditWH2);
            this.Controls.Add(this.lookUpEditDep1);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.lookUpEditWH1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.chk包含已生单);
            this.Controls.Add(this.lookUpEditcCode2);
            this.Controls.Add(this.lookUpEditcCode1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnOK);
            this.Controls.Add(this.btnSEL);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.dtm2);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.labelcInvCCode);
            this.Controls.Add(this.dtm1);
            this.Controls.Add(this.gridControl1);
            this.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.Name = "FrmRDInSEL";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "查询";
            this.Load += new System.EventHandler(this.FrmRDInSEL_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dtm2.Properties.VistaTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtm2.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtm1.Properties.VistaTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtm1.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ItemLookUpEdit仓库)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ItemLookUpEdit部门)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lookUpEditcCode2.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lookUpEditcCode1.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lookUpEditWH1.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lookUpEditDep1.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lookUpEditWH2.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lookUpEditDep2.Properties)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label4;
        private DevExpress.XtraEditors.DateEdit dtm2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label labelcInvCCode;
        private DevExpress.XtraEditors.DateEdit dtm1;
        private DevExpress.XtraGrid.GridControl gridControl1;
        private System.Windows.Forms.Button btnSEL;
        private System.Windows.Forms.Button btnOK;
        private System.Windows.Forms.Button btnCancel;
        private DevExpress.XtraEditors.LookUpEdit lookUpEditcCode2;
        private DevExpress.XtraEditors.LookUpEdit lookUpEditcCode1;
        private System.Windows.Forms.Label label2;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView1;
        private DevExpress.XtraGrid.Columns.GridColumn gridColID;
        private DevExpress.XtraGrid.Columns.GridColumn gridColcVouchType;
        private DevExpress.XtraGrid.Columns.GridColumn gridColbRdFlag;
        private DevExpress.XtraGrid.Columns.GridColumn gridColcBusType;
        private DevExpress.XtraGrid.Columns.GridColumn gridColcSource;
        private DevExpress.XtraGrid.Columns.GridColumn gridColcWhCode;
        private DevExpress.XtraGrid.Columns.GridColumn gridColdDate;
        private DevExpress.XtraGrid.Columns.GridColumn gridColcCode;
        private DevExpress.XtraGrid.Columns.GridColumn gridColcRdCode;
        private DevExpress.XtraGrid.Columns.GridColumn gridColcDepCode;
        private DevExpress.XtraGrid.Columns.GridColumn gridColcPersonCode;
        private DevExpress.XtraGrid.Columns.GridColumn gridColcHandler;
        private DevExpress.XtraGrid.Columns.GridColumn gridColcMemo;
        private DevExpress.XtraGrid.Columns.GridColumn gridColcMaker;
        private DevExpress.XtraGrid.Columns.GridColumn gridColdnmaketime;
        private DevExpress.XtraGrid.Columns.GridColumn gridColdnverifytime;
        private System.Windows.Forms.CheckBox chk包含已生单;
        private DevExpress.XtraEditors.LookUpEdit lookUpEditWH1;
        private System.Windows.Forms.Label label1;
        private DevExpress.XtraEditors.LookUpEdit lookUpEditDep1;
        private System.Windows.Forms.Label label5;
        private DevExpress.XtraEditors.LookUpEdit lookUpEditWH2;
        private DevExpress.XtraEditors.LookUpEdit lookUpEditDep2;
        private DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit ItemLookUpEdit部门;
        private DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit ItemLookUpEdit仓库;
    }
}