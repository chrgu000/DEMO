namespace UFIDA.U8.UAP.CustomApp.ControlForm
{
    partial class FrmMaterialList
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
            this.btnOK = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnSEL = new System.Windows.Forms.Button();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.lookUpEditcDepName = new DevExpress.XtraEditors.LookUpEdit();
            this.lookUpEditcDepCode = new DevExpress.XtraEditors.LookUpEdit();
            this.label1 = new System.Windows.Forms.Label();
            this.lookUpEditcCurrencyName = new DevExpress.XtraEditors.LookUpEdit();
            this.lookUpEditcInvStd = new DevExpress.XtraEditors.LookUpEdit();
            this.lookUpEditcInvName = new DevExpress.XtraEditors.LookUpEdit();
            this.label4 = new System.Windows.Forms.Label();
            this.lookUpEdit会计期间 = new DevExpress.XtraEditors.LookUpEdit();
            this.label3 = new System.Windows.Forms.Label();
            this.gridControl1 = new DevExpress.XtraGrid.GridControl();
            this.gridView1 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.gridCol产品编码 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.ItemLookUpEditcInvCode = new DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit();
            this.gridCol产品名称 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.ItemLookUpEditcInvName = new DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit();
            this.gridCol产品规格 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.ItemLookUpEditcInvStd = new DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit();
            this.gridCol通用名称 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.ItemLookUpEditcCurrencyName = new DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit();
            this.gridCol部门编码 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.ItemLookUpEditcDepCode = new DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit();
            this.gridCol部门名称 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.ItemLookUpEditcDepName = new DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit();
            this.gridCol会计期间 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.btnTxtInvCode = new DevExpress.XtraEditors.ButtonEdit();
            ((System.ComponentModel.ISupportInitialize)(this.lookUpEditcDepName.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lookUpEditcDepCode.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lookUpEditcCurrencyName.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lookUpEditcInvStd.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lookUpEditcInvName.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lookUpEdit会计期间.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ItemLookUpEditcInvCode)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ItemLookUpEditcInvName)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ItemLookUpEditcInvStd)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ItemLookUpEditcCurrencyName)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ItemLookUpEditcDepCode)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ItemLookUpEditcDepName)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnTxtInvCode.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // btnOK
            // 
            this.btnOK.Location = new System.Drawing.Point(834, 62);
            this.btnOK.Margin = new System.Windows.Forms.Padding(4);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(100, 29);
            this.btnOK.TabIndex = 0;
            this.btnOK.Text = "确 定";
            this.btnOK.UseVisualStyleBackColor = true;
            this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(971, 62);
            this.btnCancel.Margin = new System.Windows.Forms.Padding(4);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(100, 29);
            this.btnCancel.TabIndex = 1;
            this.btnCancel.Text = "取 消";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // btnSEL
            // 
            this.btnSEL.Location = new System.Drawing.Point(704, 62);
            this.btnSEL.Margin = new System.Windows.Forms.Padding(4);
            this.btnSEL.Name = "btnSEL";
            this.btnSEL.Size = new System.Drawing.Size(100, 29);
            this.btnSEL.TabIndex = 3;
            this.btnSEL.Text = "查 询";
            this.btnSEL.UseVisualStyleBackColor = true;
            this.btnSEL.Click += new System.EventHandler(this.btnSEL_Click);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(273, 76);
            this.label7.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(67, 15);
            this.label7.TabIndex = 220;
            this.label7.Text = "通用名称";
            this.label7.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(17, 76);
            this.label6.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(67, 15);
            this.label6.TabIndex = 219;
            this.label6.Text = "产品规格";
            this.label6.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(273, 44);
            this.label5.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(67, 15);
            this.label5.TabIndex = 218;
            this.label5.Text = "产品名称";
            this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(452, 11);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(37, 15);
            this.label2.TabIndex = 217;
            this.label2.Text = "部门";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lookUpEditcDepName
            // 
            this.lookUpEditcDepName.AllowHtmlTextInToolTip = DevExpress.Utils.DefaultBoolean.True;
            this.lookUpEditcDepName.Location = new System.Drawing.Point(499, 5);
            this.lookUpEditcDepName.Margin = new System.Windows.Forms.Padding(4);
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
            this.lookUpEditcDepName.Size = new System.Drawing.Size(193, 24);
            this.lookUpEditcDepName.TabIndex = 216;
            this.lookUpEditcDepName.EditValueChanged += new System.EventHandler(this.lookUpEditcDepName_EditValueChanged);
            // 
            // lookUpEditcDepCode
            // 
            this.lookUpEditcDepCode.AllowHtmlTextInToolTip = DevExpress.Utils.DefaultBoolean.True;
            this.lookUpEditcDepCode.Location = new System.Drawing.Point(352, 5);
            this.lookUpEditcDepCode.Margin = new System.Windows.Forms.Padding(4);
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
            this.lookUpEditcDepCode.Size = new System.Drawing.Size(92, 24);
            this.lookUpEditcDepCode.TabIndex = 215;
            this.lookUpEditcDepCode.EditValueChanged += new System.EventHandler(this.lookUpEditcDepCode_EditValueChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label1.Location = new System.Drawing.Point(273, 9);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(67, 15);
            this.label1.TabIndex = 214;
            this.label1.Text = "部门编码";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lookUpEditcCurrencyName
            // 
            this.lookUpEditcCurrencyName.AllowHtmlTextInToolTip = DevExpress.Utils.DefaultBoolean.True;
            this.lookUpEditcCurrencyName.Location = new System.Drawing.Point(352, 70);
            this.lookUpEditcCurrencyName.Margin = new System.Windows.Forms.Padding(4);
            this.lookUpEditcCurrencyName.Name = "lookUpEditcCurrencyName";
            this.lookUpEditcCurrencyName.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.lookUpEditcCurrencyName.Properties.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("cInvCode", 100, "编号"),
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("cInvName", 300, "名称"),
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("cInvStd", 200, "规格型号"),
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("cCurrencyName", 100, "通用名称")});
            this.lookUpEditcCurrencyName.Properties.DisplayMember = "cCurrencyName";
            this.lookUpEditcCurrencyName.Properties.NullText = "";
            this.lookUpEditcCurrencyName.Properties.PopupWidth = 700;
            this.lookUpEditcCurrencyName.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.Standard;
            this.lookUpEditcCurrencyName.Properties.ValueMember = "cInvCode";
            this.lookUpEditcCurrencyName.Size = new System.Drawing.Size(340, 24);
            this.lookUpEditcCurrencyName.TabIndex = 213;
            this.lookUpEditcCurrencyName.EditValueChanged += new System.EventHandler(this.lookUpEditcCurrencyName_EditValueChanged);
            // 
            // lookUpEditcInvStd
            // 
            this.lookUpEditcInvStd.AllowHtmlTextInToolTip = DevExpress.Utils.DefaultBoolean.True;
            this.lookUpEditcInvStd.Location = new System.Drawing.Point(96, 70);
            this.lookUpEditcInvStd.Margin = new System.Windows.Forms.Padding(4);
            this.lookUpEditcInvStd.Name = "lookUpEditcInvStd";
            this.lookUpEditcInvStd.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.lookUpEditcInvStd.Properties.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("cInvCode", 100, "编号"),
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("cInvName", 300, "名称"),
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("cInvStd", 200, "规格型号"),
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("cCurrencyName", 100, "通用名称")});
            this.lookUpEditcInvStd.Properties.DisplayMember = "cInvName";
            this.lookUpEditcInvStd.Properties.NullText = "";
            this.lookUpEditcInvStd.Properties.PopupWidth = 700;
            this.lookUpEditcInvStd.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.Standard;
            this.lookUpEditcInvStd.Properties.ValueMember = "cInvCode";
            this.lookUpEditcInvStd.Size = new System.Drawing.Size(161, 24);
            this.lookUpEditcInvStd.TabIndex = 212;
            this.lookUpEditcInvStd.EditValueChanged += new System.EventHandler(this.lookUpEditcInvStd_EditValueChanged);
            // 
            // lookUpEditcInvName
            // 
            this.lookUpEditcInvName.AllowHtmlTextInToolTip = DevExpress.Utils.DefaultBoolean.True;
            this.lookUpEditcInvName.Location = new System.Drawing.Point(352, 38);
            this.lookUpEditcInvName.Margin = new System.Windows.Forms.Padding(4);
            this.lookUpEditcInvName.Name = "lookUpEditcInvName";
            this.lookUpEditcInvName.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.lookUpEditcInvName.Properties.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("cInvCode", 100, "编号"),
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("cInvName", 300, "名称"),
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("cInvStd", 200, "规格型号"),
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("cCurrencyName", 100, "通用名称")});
            this.lookUpEditcInvName.Properties.DisplayMember = "cInvName";
            this.lookUpEditcInvName.Properties.NullText = "";
            this.lookUpEditcInvName.Properties.PopupWidth = 700;
            this.lookUpEditcInvName.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.Standard;
            this.lookUpEditcInvName.Properties.ValueMember = "cInvCode";
            this.lookUpEditcInvName.Size = new System.Drawing.Size(340, 24);
            this.lookUpEditcInvName.TabIndex = 211;
            this.lookUpEditcInvName.EditValueChanged += new System.EventHandler(this.lookUpEditcInvName_EditValueChanged);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label4.Location = new System.Drawing.Point(17, 44);
            this.label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(67, 15);
            this.label4.TabIndex = 209;
            this.label4.Text = "产品编码";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lookUpEdit会计期间
            // 
            this.lookUpEdit会计期间.AllowHtmlTextInToolTip = DevExpress.Utils.DefaultBoolean.True;
            this.lookUpEdit会计期间.Location = new System.Drawing.Point(96, 8);
            this.lookUpEdit会计期间.Margin = new System.Windows.Forms.Padding(4);
            this.lookUpEdit会计期间.Name = "lookUpEdit会计期间";
            this.lookUpEdit会计期间.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.lookUpEdit会计期间.Properties.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("会计期间", "会计期间")});
            this.lookUpEdit会计期间.Properties.DisplayMember = "会计期间";
            this.lookUpEdit会计期间.Properties.NullText = "";
            this.lookUpEdit会计期间.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.Standard;
            this.lookUpEdit会计期间.Properties.ValueMember = "会计期间";
            this.lookUpEdit会计期间.Size = new System.Drawing.Size(161, 24);
            this.lookUpEdit会计期间.TabIndex = 208;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label3.Location = new System.Drawing.Point(17, 11);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(67, 15);
            this.label3.TabIndex = 207;
            this.label3.Text = "会计期间";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // gridControl1
            // 
            this.gridControl1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.gridControl1.Location = new System.Drawing.Point(1, 102);
            this.gridControl1.LookAndFeel.SkinName = "Office 2010 Blue";
            this.gridControl1.MainView = this.gridView1;
            this.gridControl1.Margin = new System.Windows.Forms.Padding(4);
            this.gridControl1.Name = "gridControl1";
            this.gridControl1.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.ItemLookUpEditcInvCode,
            this.ItemLookUpEditcInvName,
            this.ItemLookUpEditcInvStd,
            this.ItemLookUpEditcCurrencyName,
            this.ItemLookUpEditcDepCode,
            this.ItemLookUpEditcDepName});
            this.gridControl1.Size = new System.Drawing.Size(1311, 445);
            this.gridControl1.TabIndex = 206;
            this.gridControl1.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView1});
            // 
            // gridView1
            // 
            this.gridView1.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.gridCol产品编码,
            this.gridCol产品名称,
            this.gridCol产品规格,
            this.gridCol通用名称,
            this.gridCol部门编码,
            this.gridCol部门名称,
            this.gridCol会计期间});
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
            // 
            // gridCol产品编码
            // 
            this.gridCol产品编码.Caption = "产品编码";
            this.gridCol产品编码.ColumnEdit = this.ItemLookUpEditcInvCode;
            this.gridCol产品编码.FieldName = "产品编码";
            this.gridCol产品编码.Name = "gridCol产品编码";
            this.gridCol产品编码.Visible = true;
            this.gridCol产品编码.VisibleIndex = 3;
            this.gridCol产品编码.Width = 121;
            // 
            // ItemLookUpEditcInvCode
            // 
            this.ItemLookUpEditcInvCode.AutoHeight = false;
            this.ItemLookUpEditcInvCode.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.ItemLookUpEditcInvCode.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("cInvCode", 100, "存货编码"),
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("cInvName", 300, "存货名称"),
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("cInvStd", 200, "规格型号"),
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("cCurrencyName", 100, "通用名称")});
            this.ItemLookUpEditcInvCode.DisplayMember = "cInvCode";
            this.ItemLookUpEditcInvCode.Name = "ItemLookUpEditcInvCode";
            this.ItemLookUpEditcInvCode.NullText = "";
            this.ItemLookUpEditcInvCode.PopupWidth = 700;
            this.ItemLookUpEditcInvCode.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.Standard;
            this.ItemLookUpEditcInvCode.ValueMember = "cInvCode";
            // 
            // gridCol产品名称
            // 
            this.gridCol产品名称.Caption = "产品名称";
            this.gridCol产品名称.ColumnEdit = this.ItemLookUpEditcInvName;
            this.gridCol产品名称.FieldName = "产品编码";
            this.gridCol产品名称.Name = "gridCol产品名称";
            this.gridCol产品名称.Visible = true;
            this.gridCol产品名称.VisibleIndex = 4;
            this.gridCol产品名称.Width = 134;
            // 
            // ItemLookUpEditcInvName
            // 
            this.ItemLookUpEditcInvName.AutoHeight = false;
            this.ItemLookUpEditcInvName.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.ItemLookUpEditcInvName.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("cInvCode", 100, "存货编码"),
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("cInvName", 300, "存货名称"),
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("cInvStd", 200, "规格型号"),
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("cCurrencyName", 100, "通用名称")});
            this.ItemLookUpEditcInvName.DisplayMember = "cInvName";
            this.ItemLookUpEditcInvName.Name = "ItemLookUpEditcInvName";
            this.ItemLookUpEditcInvName.NullText = "";
            this.ItemLookUpEditcInvName.PopupWidth = 700;
            this.ItemLookUpEditcInvName.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.Standard;
            this.ItemLookUpEditcInvName.ValueMember = "cInvCode";
            // 
            // gridCol产品规格
            // 
            this.gridCol产品规格.Caption = "产品规格";
            this.gridCol产品规格.ColumnEdit = this.ItemLookUpEditcInvStd;
            this.gridCol产品规格.FieldName = "产品编码";
            this.gridCol产品规格.Name = "gridCol产品规格";
            this.gridCol产品规格.Visible = true;
            this.gridCol产品规格.VisibleIndex = 5;
            this.gridCol产品规格.Width = 107;
            // 
            // ItemLookUpEditcInvStd
            // 
            this.ItemLookUpEditcInvStd.AutoHeight = false;
            this.ItemLookUpEditcInvStd.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.ItemLookUpEditcInvStd.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("cInvCode", 100, "存货编码"),
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("cInvName", 300, "存货名称"),
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("cInvStd", 200, "规格型号"),
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("cCurrencyName", 100, "通用名称")});
            this.ItemLookUpEditcInvStd.DisplayMember = "cInvStd";
            this.ItemLookUpEditcInvStd.Name = "ItemLookUpEditcInvStd";
            this.ItemLookUpEditcInvStd.NullText = "";
            this.ItemLookUpEditcInvStd.PopupWidth = 700;
            this.ItemLookUpEditcInvStd.ValueMember = "cInvCode";
            // 
            // gridCol通用名称
            // 
            this.gridCol通用名称.Caption = "通用名称";
            this.gridCol通用名称.ColumnEdit = this.ItemLookUpEditcCurrencyName;
            this.gridCol通用名称.FieldName = "产品编码";
            this.gridCol通用名称.Name = "gridCol通用名称";
            this.gridCol通用名称.Visible = true;
            this.gridCol通用名称.VisibleIndex = 6;
            this.gridCol通用名称.Width = 180;
            // 
            // ItemLookUpEditcCurrencyName
            // 
            this.ItemLookUpEditcCurrencyName.AutoHeight = false;
            this.ItemLookUpEditcCurrencyName.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.ItemLookUpEditcCurrencyName.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("cInvCode", 100, "存货编码"),
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("cInvName", 300, "存货名称"),
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("cInvStd", 200, "规格型号"),
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("cCurrencyName", 100, "通用名称")});
            this.ItemLookUpEditcCurrencyName.DisplayMember = "cCurrencyName";
            this.ItemLookUpEditcCurrencyName.Name = "ItemLookUpEditcCurrencyName";
            this.ItemLookUpEditcCurrencyName.NullText = "";
            this.ItemLookUpEditcCurrencyName.PopupWidth = 700;
            this.ItemLookUpEditcCurrencyName.ValueMember = "cInvCode";
            // 
            // gridCol部门编码
            // 
            this.gridCol部门编码.Caption = "部门编码";
            this.gridCol部门编码.ColumnEdit = this.ItemLookUpEditcDepCode;
            this.gridCol部门编码.FieldName = "部门编码";
            this.gridCol部门编码.Name = "gridCol部门编码";
            this.gridCol部门编码.Visible = true;
            this.gridCol部门编码.VisibleIndex = 1;
            this.gridCol部门编码.Width = 109;
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
            // gridCol部门名称
            // 
            this.gridCol部门名称.Caption = "部门名称";
            this.gridCol部门名称.ColumnEdit = this.ItemLookUpEditcDepName;
            this.gridCol部门名称.FieldName = "部门编码";
            this.gridCol部门名称.Name = "gridCol部门名称";
            this.gridCol部门名称.Visible = true;
            this.gridCol部门名称.VisibleIndex = 2;
            this.gridCol部门名称.Width = 143;
            // 
            // ItemLookUpEditcDepName
            // 
            this.ItemLookUpEditcDepName.AutoHeight = false;
            this.ItemLookUpEditcDepName.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.ItemLookUpEditcDepName.DisplayMember = "cDepName";
            this.ItemLookUpEditcDepName.Name = "ItemLookUpEditcDepName";
            this.ItemLookUpEditcDepName.NullText = "";
            this.ItemLookUpEditcDepName.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.Standard;
            this.ItemLookUpEditcDepName.ValueMember = "cDepCode";
            // 
            // gridCol会计期间
            // 
            this.gridCol会计期间.Caption = "会计期间";
            this.gridCol会计期间.FieldName = "会计期间";
            this.gridCol会计期间.Name = "gridCol会计期间";
            this.gridCol会计期间.Visible = true;
            this.gridCol会计期间.VisibleIndex = 0;
            this.gridCol会计期间.Width = 92;
            // 
            // btnTxtInvCode
            // 
            this.btnTxtInvCode.Location = new System.Drawing.Point(97, 38);
            this.btnTxtInvCode.Margin = new System.Windows.Forms.Padding(4);
            this.btnTxtInvCode.Name = "btnTxtInvCode";
            this.btnTxtInvCode.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
            this.btnTxtInvCode.Size = new System.Drawing.Size(160, 24);
            this.btnTxtInvCode.TabIndex = 221;
            this.btnTxtInvCode.ButtonClick += new DevExpress.XtraEditors.Controls.ButtonPressedEventHandler(this.btnTxtInvCode_ButtonClick);
            this.btnTxtInvCode.EditValueChanged += new System.EventHandler(this.btnTxtInvCode_EditValueChanged);
            // 
            // FrmMaterialList
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1316, 549);
            this.Controls.Add(this.btnTxtInvCode);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.lookUpEditcDepName);
            this.Controls.Add(this.lookUpEditcDepCode);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.lookUpEditcCurrencyName);
            this.Controls.Add(this.lookUpEditcInvStd);
            this.Controls.Add(this.lookUpEditcInvName);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.lookUpEdit会计期间);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.gridControl1);
            this.Controls.Add(this.btnSEL);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnOK);
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "FrmMaterialList";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Load += new System.EventHandler(this.FrmMaterialList_Load);
            ((System.ComponentModel.ISupportInitialize)(this.lookUpEditcDepName.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lookUpEditcDepCode.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lookUpEditcCurrencyName.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lookUpEditcInvStd.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lookUpEditcInvName.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lookUpEdit会计期间.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ItemLookUpEditcInvCode)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ItemLookUpEditcInvName)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ItemLookUpEditcInvStd)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ItemLookUpEditcCurrencyName)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ItemLookUpEditcDepCode)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ItemLookUpEditcDepName)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnTxtInvCode.Properties)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnOK;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Button btnSEL;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label2;
        private DevExpress.XtraEditors.LookUpEdit lookUpEditcDepName;
        private DevExpress.XtraEditors.LookUpEdit lookUpEditcDepCode;
        private System.Windows.Forms.Label label1;
        private DevExpress.XtraEditors.LookUpEdit lookUpEditcCurrencyName;
        private DevExpress.XtraEditors.LookUpEdit lookUpEditcInvStd;
        private DevExpress.XtraEditors.LookUpEdit lookUpEditcInvName;
        private System.Windows.Forms.Label label4;
        private DevExpress.XtraEditors.LookUpEdit lookUpEdit会计期间;
        private System.Windows.Forms.Label label3;
        private DevExpress.XtraGrid.GridControl gridControl1;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView1;
        private DevExpress.XtraGrid.Columns.GridColumn gridCol产品编码;
        private DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit ItemLookUpEditcInvCode;
        private DevExpress.XtraGrid.Columns.GridColumn gridCol产品名称;
        private DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit ItemLookUpEditcInvName;
        private DevExpress.XtraGrid.Columns.GridColumn gridCol产品规格;
        private DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit ItemLookUpEditcInvStd;
        private DevExpress.XtraGrid.Columns.GridColumn gridCol通用名称;
        private DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit ItemLookUpEditcCurrencyName;
        private DevExpress.XtraGrid.Columns.GridColumn gridCol部门编码;
        private DevExpress.XtraGrid.Columns.GridColumn gridCol部门名称;
        private DevExpress.XtraGrid.Columns.GridColumn gridCol会计期间;
        private DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit ItemLookUpEditcDepCode;
        private DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit ItemLookUpEditcDepName;
        private DevExpress.XtraEditors.ButtonEdit btnTxtInvCode;
    }
}