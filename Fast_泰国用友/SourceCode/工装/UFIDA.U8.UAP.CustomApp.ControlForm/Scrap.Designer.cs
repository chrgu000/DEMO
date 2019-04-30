namespace UFIDA.U8.UAP.CustomApp.ControlForm
{
    partial class Scrap
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
            this.btnView = new System.Windows.Forms.ToolStripMenuItem();
            this.btnAdd = new System.Windows.Forms.ToolStripMenuItem();
            this.btnEdit = new System.Windows.Forms.ToolStripMenuItem();
            this.btnDEL = new System.Windows.Forms.ToolStripMenuItem();
            this.btnExcel = new System.Windows.Forms.ToolStripMenuItem();
            this.gridControl1 = new DevExpress.XtraGrid.GridControl();
            this.gridView1 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.gridColcCode = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColdDate = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColSerialNo = new DevExpress.XtraGrid.Columns.GridColumn();
            this.ItemLookUpEditSerialNo = new DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit();
            this.gridColInvName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.ItemLookUpEditInvName = new DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit();
            this.gridColInvStd = new DevExpress.XtraGrid.Columns.GridColumn();
            this.ItemLookUpEditInvStd = new DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit();
            this.gridColCreater = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColCreaterDate = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColAuditer = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColAuditeDate = new DevExpress.XtraGrid.Columns.GridColumn();
            this.ItemButtonEditSerialNo = new DevExpress.XtraEditors.Repository.RepositoryItemButtonEdit();
            this.panel1 = new System.Windows.Forms.Panel();
            this.lookUpEditDep = new DevExpress.XtraEditors.LookUpEdit();
            this.label4 = new System.Windows.Forms.Label();
            this.lookUpEditPerson = new DevExpress.XtraEditors.LookUpEdit();
            this.label1 = new System.Windows.Forms.Label();
            this.dtm2 = new DevExpress.XtraEditors.DateEdit();
            this.lookUpEditCode2 = new DevExpress.XtraEditors.LookUpEdit();
            this.lookUpEditCode1 = new DevExpress.XtraEditors.LookUpEdit();
            this.label3 = new System.Windows.Forms.Label();
            this.dtm1 = new DevExpress.XtraEditors.DateEdit();
            this.label2 = new System.Windows.Forms.Label();
            this.menuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ItemLookUpEditSerialNo)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ItemLookUpEditInvName)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ItemLookUpEditInvStd)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ItemButtonEditSerialNo)).BeginInit();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.lookUpEditDep.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lookUpEditPerson.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtm2.Properties.VistaTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtm2.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lookUpEditCode2.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lookUpEditCode1.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtm1.Properties.VistaTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtm1.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btnView,
            this.btnAdd,
            this.btnEdit,
            this.btnDEL,
            this.btnExcel});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(944, 24);
            this.menuStrip1.TabIndex = 172;
            this.menuStrip1.Text = "menuStrip";
            // 
            // btnView
            // 
            this.btnView.Name = "btnView";
            this.btnView.Size = new System.Drawing.Size(41, 20);
            this.btnView.Text = "刷新";
            this.btnView.Click += new System.EventHandler(this.btnSEL_Click);
            // 
            // btnAdd
            // 
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(41, 20);
            this.btnAdd.Text = "新增";
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // btnEdit
            // 
            this.btnEdit.Name = "btnEdit";
            this.btnEdit.Size = new System.Drawing.Size(41, 20);
            this.btnEdit.Text = "修改";
            this.btnEdit.Click += new System.EventHandler(this.btnEdit_Click);
            // 
            // btnDEL
            // 
            this.btnDEL.Name = "btnDEL";
            this.btnDEL.Size = new System.Drawing.Size(41, 20);
            this.btnDEL.Text = "删除";
            this.btnDEL.Click += new System.EventHandler(this.btnDEL_Click);
            // 
            // btnExcel
            // 
            this.btnExcel.Name = "btnExcel";
            this.btnExcel.Size = new System.Drawing.Size(41, 20);
            this.btnExcel.Text = "导出";
            this.btnExcel.Click += new System.EventHandler(this.btnExcel_Click);
            // 
            // gridControl1
            // 
            this.gridControl1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.gridControl1.Location = new System.Drawing.Point(3, 69);
            this.gridControl1.LookAndFeel.SkinName = "Office 2010 Blue";
            this.gridControl1.MainView = this.gridView1;
            this.gridControl1.Name = "gridControl1";
            this.gridControl1.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.ItemButtonEditSerialNo,
            this.ItemLookUpEditInvName,
            this.ItemLookUpEditInvStd,
            this.ItemLookUpEditSerialNo});
            this.gridControl1.Size = new System.Drawing.Size(938, 294);
            this.gridControl1.TabIndex = 191;
            this.gridControl1.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView1});
            // 
            // gridView1
            // 
            this.gridView1.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.gridColcCode,
            this.gridColdDate,
            this.gridColSerialNo,
            this.gridColInvName,
            this.gridColInvStd,
            this.gridColCreater,
            this.gridColCreaterDate,
            this.gridColAuditer,
            this.gridColAuditeDate});
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
            this.gridView1.CustomDrawRowIndicator += new DevExpress.XtraGrid.Views.Grid.RowIndicatorCustomDrawEventHandler(this.gridView1_CustomDrawRowIndicator);
            this.gridView1.DoubleClick += new System.EventHandler(this.gridView1_DoubleClick);
            // 
            // gridColcCode
            // 
            this.gridColcCode.Caption = "单据号";
            this.gridColcCode.FieldName = "cCode";
            this.gridColcCode.Name = "gridColcCode";
            this.gridColcCode.OptionsColumn.AllowEdit = false;
            this.gridColcCode.Visible = true;
            this.gridColcCode.VisibleIndex = 0;
            this.gridColcCode.Width = 116;
            // 
            // gridColdDate
            // 
            this.gridColdDate.Caption = "单据日期";
            this.gridColdDate.FieldName = "dDate";
            this.gridColdDate.Name = "gridColdDate";
            this.gridColdDate.OptionsColumn.AllowEdit = false;
            this.gridColdDate.Visible = true;
            this.gridColdDate.VisibleIndex = 1;
            this.gridColdDate.Width = 120;
            // 
            // gridColSerialNo
            // 
            this.gridColSerialNo.Caption = "工装序号";
            this.gridColSerialNo.ColumnEdit = this.ItemLookUpEditSerialNo;
            this.gridColSerialNo.FieldName = "SerialNo";
            this.gridColSerialNo.Name = "gridColSerialNo";
            this.gridColSerialNo.OptionsColumn.AllowEdit = false;
            this.gridColSerialNo.Visible = true;
            this.gridColSerialNo.VisibleIndex = 2;
            this.gridColSerialNo.Width = 133;
            // 
            // ItemLookUpEditSerialNo
            // 
            this.ItemLookUpEditSerialNo.AutoHeight = false;
            this.ItemLookUpEditSerialNo.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.ItemLookUpEditSerialNo.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("SerialNo", "序号"),
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("InvName", "名称"),
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("InvStd", "规格")});
            this.ItemLookUpEditSerialNo.DisplayMember = "SerialNo";
            this.ItemLookUpEditSerialNo.Name = "ItemLookUpEditSerialNo";
            this.ItemLookUpEditSerialNo.NullText = "";
            this.ItemLookUpEditSerialNo.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.Standard;
            this.ItemLookUpEditSerialNo.ValueMember = "SerialNo";
            // 
            // gridColInvName
            // 
            this.gridColInvName.Caption = "工装名称";
            this.gridColInvName.ColumnEdit = this.ItemLookUpEditInvName;
            this.gridColInvName.FieldName = "SerialNo";
            this.gridColInvName.Name = "gridColInvName";
            this.gridColInvName.OptionsColumn.AllowEdit = false;
            this.gridColInvName.Visible = true;
            this.gridColInvName.VisibleIndex = 3;
            this.gridColInvName.Width = 193;
            // 
            // ItemLookUpEditInvName
            // 
            this.ItemLookUpEditInvName.AutoHeight = false;
            this.ItemLookUpEditInvName.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.ItemLookUpEditInvName.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("SerialNo", "序号"),
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("InvName", "名称"),
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("InvStd", "规格")});
            this.ItemLookUpEditInvName.DisplayMember = "InvName";
            this.ItemLookUpEditInvName.Name = "ItemLookUpEditInvName";
            this.ItemLookUpEditInvName.NullText = "";
            this.ItemLookUpEditInvName.ValueMember = "SerialNo";
            // 
            // gridColInvStd
            // 
            this.gridColInvStd.Caption = "规格型号";
            this.gridColInvStd.ColumnEdit = this.ItemLookUpEditInvStd;
            this.gridColInvStd.FieldName = "SerialNo";
            this.gridColInvStd.Name = "gridColInvStd";
            this.gridColInvStd.OptionsColumn.AllowEdit = false;
            this.gridColInvStd.Visible = true;
            this.gridColInvStd.VisibleIndex = 4;
            this.gridColInvStd.Width = 151;
            // 
            // ItemLookUpEditInvStd
            // 
            this.ItemLookUpEditInvStd.AutoHeight = false;
            this.ItemLookUpEditInvStd.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.ItemLookUpEditInvStd.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("SerialNo", "序号"),
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("InvName", "名称"),
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("InvStd", "规格")});
            this.ItemLookUpEditInvStd.DisplayMember = "InvStd";
            this.ItemLookUpEditInvStd.Name = "ItemLookUpEditInvStd";
            this.ItemLookUpEditInvStd.NullText = "";
            this.ItemLookUpEditInvStd.ValueMember = "SerialNo";
            // 
            // gridColCreater
            // 
            this.gridColCreater.Caption = "制单人";
            this.gridColCreater.FieldName = "CreateUserName";
            this.gridColCreater.Name = "gridColCreater";
            this.gridColCreater.OptionsColumn.AllowEdit = false;
            this.gridColCreater.Visible = true;
            this.gridColCreater.VisibleIndex = 5;
            // 
            // gridColCreaterDate
            // 
            this.gridColCreaterDate.Caption = "制单日期";
            this.gridColCreaterDate.FieldName = "CreateDate";
            this.gridColCreaterDate.Name = "gridColCreaterDate";
            this.gridColCreaterDate.OptionsColumn.AllowEdit = false;
            this.gridColCreaterDate.Visible = true;
            this.gridColCreaterDate.VisibleIndex = 6;
            // 
            // gridColAuditer
            // 
            this.gridColAuditer.Caption = "审核人";
            this.gridColAuditer.FieldName = "AuditUserName";
            this.gridColAuditer.Name = "gridColAuditer";
            this.gridColAuditer.OptionsColumn.AllowEdit = false;
            this.gridColAuditer.Visible = true;
            this.gridColAuditer.VisibleIndex = 7;
            // 
            // gridColAuditeDate
            // 
            this.gridColAuditeDate.Caption = "审核日期";
            this.gridColAuditeDate.FieldName = "AuditDate";
            this.gridColAuditeDate.Name = "gridColAuditeDate";
            this.gridColAuditeDate.OptionsColumn.AllowEdit = false;
            this.gridColAuditeDate.Visible = true;
            this.gridColAuditeDate.VisibleIndex = 8;
            // 
            // ItemButtonEditSerialNo
            // 
            this.ItemButtonEditSerialNo.AutoHeight = false;
            this.ItemButtonEditSerialNo.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
            this.ItemButtonEditSerialNo.Name = "ItemButtonEditSerialNo";
            // 
            // panel1
            // 
            this.panel1.AutoScroll = true;
            this.panel1.Controls.Add(this.lookUpEditDep);
            this.panel1.Controls.Add(this.label4);
            this.panel1.Controls.Add(this.lookUpEditPerson);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.dtm2);
            this.panel1.Controls.Add(this.lookUpEditCode2);
            this.panel1.Controls.Add(this.lookUpEditCode1);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.dtm1);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.gridControl1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 24);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(944, 366);
            this.panel1.TabIndex = 173;
            // 
            // lookUpEditDep
            // 
            this.lookUpEditDep.Location = new System.Drawing.Point(404, 33);
            this.lookUpEditDep.Margin = new System.Windows.Forms.Padding(2);
            this.lookUpEditDep.Name = "lookUpEditDep";
            this.lookUpEditDep.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.lookUpEditDep.Properties.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("cDepCode", "部门编号"),
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("cDepName", "部门")});
            this.lookUpEditDep.Properties.DisplayMember = "cDepName";
            this.lookUpEditDep.Properties.NullText = "";
            this.lookUpEditDep.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.Standard;
            this.lookUpEditDep.Properties.ValueMember = "cDepCode";
            this.lookUpEditDep.Size = new System.Drawing.Size(126, 20);
            this.lookUpEditDep.TabIndex = 210;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(344, 37);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(53, 12);
            this.label4.TabIndex = 209;
            this.label4.Text = "报废部门";
            // 
            // lookUpEditPerson
            // 
            this.lookUpEditPerson.Location = new System.Drawing.Point(404, 10);
            this.lookUpEditPerson.Margin = new System.Windows.Forms.Padding(2);
            this.lookUpEditPerson.Name = "lookUpEditPerson";
            this.lookUpEditPerson.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.lookUpEditPerson.Properties.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("cPersonCode", "人员编号"),
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("cPersonName", 80, "姓名")});
            this.lookUpEditPerson.Properties.DisplayMember = "cPersonName";
            this.lookUpEditPerson.Properties.NullText = "";
            this.lookUpEditPerson.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.Standard;
            this.lookUpEditPerson.Properties.ValueMember = "cPersonCode";
            this.lookUpEditPerson.Size = new System.Drawing.Size(126, 20);
            this.lookUpEditPerson.TabIndex = 208;
            this.lookUpEditPerson.EditValueChanged += new System.EventHandler(this.lookUpEditPerson_EditValueChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(344, 14);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(41, 12);
            this.label1.TabIndex = 207;
            this.label1.Text = "报废人";
            // 
            // dtm2
            // 
            this.dtm2.EditValue = null;
            this.dtm2.Location = new System.Drawing.Point(212, 33);
            this.dtm2.Margin = new System.Windows.Forms.Padding(2);
            this.dtm2.Name = "dtm2";
            this.dtm2.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.dtm2.Properties.VistaTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
            this.dtm2.Size = new System.Drawing.Size(126, 20);
            this.dtm2.TabIndex = 206;
            // 
            // lookUpEditCode2
            // 
            this.lookUpEditCode2.Location = new System.Drawing.Point(212, 10);
            this.lookUpEditCode2.Margin = new System.Windows.Forms.Padding(2);
            this.lookUpEditCode2.Name = "lookUpEditCode2";
            this.lookUpEditCode2.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.lookUpEditCode2.Properties.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("cCode", "单据号")});
            this.lookUpEditCode2.Properties.DisplayMember = "cCode";
            this.lookUpEditCode2.Properties.NullText = "";
            this.lookUpEditCode2.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.Standard;
            this.lookUpEditCode2.Properties.ValueMember = "cCode";
            this.lookUpEditCode2.Size = new System.Drawing.Size(126, 20);
            this.lookUpEditCode2.TabIndex = 205;
            // 
            // lookUpEditCode1
            // 
            this.lookUpEditCode1.Location = new System.Drawing.Point(81, 10);
            this.lookUpEditCode1.Margin = new System.Windows.Forms.Padding(2);
            this.lookUpEditCode1.Name = "lookUpEditCode1";
            this.lookUpEditCode1.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.lookUpEditCode1.Properties.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("cCode", "单据号")});
            this.lookUpEditCode1.Properties.DisplayMember = "cCode";
            this.lookUpEditCode1.Properties.NullText = "";
            this.lookUpEditCode1.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.Standard;
            this.lookUpEditCode1.Properties.ValueMember = "cCode";
            this.lookUpEditCode1.Size = new System.Drawing.Size(126, 20);
            this.lookUpEditCode1.TabIndex = 204;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(37, 14);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(41, 12);
            this.label3.TabIndex = 203;
            this.label3.Text = "单据号";
            // 
            // dtm1
            // 
            this.dtm1.EditValue = null;
            this.dtm1.Location = new System.Drawing.Point(81, 34);
            this.dtm1.Margin = new System.Windows.Forms.Padding(2);
            this.dtm1.Name = "dtm1";
            this.dtm1.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.dtm1.Properties.VistaTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
            this.dtm1.Size = new System.Drawing.Size(126, 20);
            this.dtm1.TabIndex = 202;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(26, 37);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(53, 12);
            this.label2.TabIndex = 201;
            this.label2.Text = "领用日期";
            // 
            // Scrap
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.menuStrip1);
            this.Name = "Scrap";
            this.Size = new System.Drawing.Size(944, 390);
            this.Load += new System.EventHandler(this.Frm_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ItemLookUpEditSerialNo)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ItemLookUpEditInvName)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ItemLookUpEditInvStd)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ItemButtonEditSerialNo)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.lookUpEditDep.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lookUpEditPerson.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtm2.Properties.VistaTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtm2.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lookUpEditCode2.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lookUpEditCode1.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtm1.Properties.VistaTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtm1.Properties)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem btnDEL;
        private DevExpress.XtraGrid.GridControl gridControl1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.ToolStripMenuItem btnView;
        private System.Windows.Forms.ToolStripMenuItem btnAdd;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView1;
        private DevExpress.XtraGrid.Columns.GridColumn gridColSerialNo;
        private DevExpress.XtraGrid.Columns.GridColumn gridColInvName;
        private DevExpress.XtraGrid.Columns.GridColumn gridColInvStd;
        private DevExpress.XtraGrid.Columns.GridColumn gridColCreater;
        private DevExpress.XtraGrid.Columns.GridColumn gridColCreaterDate;
        private DevExpress.XtraGrid.Columns.GridColumn gridColAuditer;
        private DevExpress.XtraGrid.Columns.GridColumn gridColAuditeDate;
        private System.Windows.Forms.ToolStripMenuItem btnEdit;
        private DevExpress.XtraEditors.LookUpEdit lookUpEditCode1;
        private System.Windows.Forms.Label label3;
        private DevExpress.XtraEditors.DateEdit dtm1;
        private System.Windows.Forms.Label label2;
        private DevExpress.XtraEditors.LookUpEdit lookUpEditCode2;
        private DevExpress.XtraEditors.DateEdit dtm2;
        private DevExpress.XtraEditors.LookUpEdit lookUpEditDep;
        private System.Windows.Forms.Label label4;
        private DevExpress.XtraEditors.LookUpEdit lookUpEditPerson;
        private System.Windows.Forms.Label label1;
        private DevExpress.XtraGrid.Columns.GridColumn gridColcCode;
        private DevExpress.XtraGrid.Columns.GridColumn gridColdDate;
        private DevExpress.XtraEditors.Repository.RepositoryItemButtonEdit ItemButtonEditSerialNo;
        private DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit ItemLookUpEditInvName;
        private DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit ItemLookUpEditInvStd;
        private DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit ItemLookUpEditSerialNo;
        private System.Windows.Forms.ToolStripMenuItem btnExcel;
    }
}
