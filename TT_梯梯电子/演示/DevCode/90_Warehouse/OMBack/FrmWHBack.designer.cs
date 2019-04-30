namespace Warehouse
{
    partial class FrmWHBack
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
            this.rpiBackQty = new DevExpress.XtraEditors.Repository.RepositoryItemTextEdit();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.txtSeaInvName = new DevExpress.XtraEditors.TextEdit();
            this.txtSeaInvCode = new DevExpress.XtraEditors.ButtonEdit();
            this.btnInvClass = new DevExpress.XtraEditors.ButtonEdit();
            this.lueInvTo = new DevExpress.XtraEditors.ButtonEdit();
            this.lueInvStart = new DevExpress.XtraEditors.ButtonEdit();
            this.btnShowAll = new DevExpress.XtraEditors.SimpleButton();
            this.bntShowSel = new DevExpress.XtraEditors.SimpleButton();
            this.btnFilter = new DevExpress.XtraEditors.SimpleButton();
            this.label6 = new System.Windows.Forms.Label();
            this.txtInvClassName = new DevExpress.XtraEditors.TextEdit();
            this.label5 = new System.Windows.Forms.Label();
            this.lblInvTo = new DevExpress.XtraEditors.TextEdit();
            this.lblInvStart = new DevExpress.XtraEditors.TextEdit();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.lueWH = new DevExpress.XtraEditors.LookUpEdit();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.grdDetail = new DevExpress.XtraGrid.GridControl();
            this.grvDetail = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colSel = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colInvCode = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colInvName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn4 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn5 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn6 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colRate = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colQty = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn8 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colVenCode = new DevExpress.XtraGrid.Columns.GridColumn();
            this.rpiVen = new DevExpress.XtraEditors.Repository.RepositoryItemButtonEdit();
            this.colVenName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colInvProp = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colDoType = new DevExpress.XtraGrid.Columns.GridColumn();
            this.rpiProxyDoType = new DevExpress.XtraEditors.Repository.RepositoryItemButtonEdit();
            this.colChangeInv = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colChangeWH = new DevExpress.XtraGrid.Columns.GridColumn();
            this.rpiWH = new DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit();
            this.colBackQty = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colBackNum = new DevExpress.XtraGrid.Columns.GridColumn();
            this.rpiBackNum = new DevExpress.XtraEditors.Repository.RepositoryItemTextEdit();
            this.gridColumn12 = new DevExpress.XtraGrid.Columns.GridColumn();
            ((System.ComponentModel.ISupportInitialize)(this.rpiBackQty)).BeginInit();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtSeaInvName.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtSeaInvCode.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnInvClass.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lueInvTo.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lueInvStart.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtInvClassName.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblInvTo.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblInvStart.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lueWH.Properties)).BeginInit();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdDetail)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grvDetail)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.rpiVen)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.rpiProxyDoType)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.rpiWH)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.rpiBackNum)).BeginInit();
            this.SuspendLayout();
            // 
            // childLF
            // 
            this.childLF.LookAndFeel.Style = DevExpress.LookAndFeel.LookAndFeelStyle.Skin;
            this.childLF.LookAndFeel.UseWindowsXPTheme = false;
            // 
            // rpiBackQty
            // 
            this.rpiBackQty.AutoHeight = false;
            this.rpiBackQty.Mask.EditMask = "n6";
            this.rpiBackQty.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Numeric;
            this.rpiBackQty.Name = "rpiBackQty";
            this.rpiBackQty.EditValueChanged += new System.EventHandler(this.rpiBackQty_EditValueChanged);
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox1.Controls.Add(this.txtSeaInvName);
            this.groupBox1.Controls.Add(this.txtSeaInvCode);
            this.groupBox1.Controls.Add(this.btnInvClass);
            this.groupBox1.Controls.Add(this.lueInvTo);
            this.groupBox1.Controls.Add(this.lueInvStart);
            this.groupBox1.Controls.Add(this.btnShowAll);
            this.groupBox1.Controls.Add(this.bntShowSel);
            this.groupBox1.Controls.Add(this.btnFilter);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.txtInvClassName);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.lblInvTo);
            this.groupBox1.Controls.Add(this.lblInvStart);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.lueWH);
            this.groupBox1.Location = new System.Drawing.Point(0, 24);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(981, 128);
            this.groupBox1.TabIndex = 5;
            this.groupBox1.TabStop = false;
            // 
            // txtSeaInvName
            // 
            this.txtSeaInvName.Location = new System.Drawing.Point(233, 99);
            this.txtSeaInvName.Name = "txtSeaInvName";
            this.txtSeaInvName.Size = new System.Drawing.Size(218, 21);
            this.txtSeaInvName.TabIndex = 78;
            this.txtSeaInvName.EditValueChanged += new System.EventHandler(this.txtSeaInvName_EditValueChanged);
            // 
            // txtSeaInvCode
            // 
            this.txtSeaInvCode.Location = new System.Drawing.Point(111, 99);
            this.txtSeaInvCode.Name = "txtSeaInvCode";
            this.txtSeaInvCode.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
            this.txtSeaInvCode.Size = new System.Drawing.Size(116, 21);
            this.txtSeaInvCode.TabIndex = 77;
            this.txtSeaInvCode.ButtonClick += new DevExpress.XtraEditors.Controls.ButtonPressedEventHandler(this.txtSeaInvCode_ButtonClick);
            this.txtSeaInvCode.EditValueChanged += new System.EventHandler(this.txtSeaInvCode_EditValueChanged);
            // 
            // btnInvClass
            // 
            this.btnInvClass.Location = new System.Drawing.Point(70, 75);
            this.btnInvClass.Name = "btnInvClass";
            this.btnInvClass.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
            this.btnInvClass.Size = new System.Drawing.Size(157, 21);
            this.btnInvClass.TabIndex = 76;
            this.btnInvClass.ButtonClick += new DevExpress.XtraEditors.Controls.ButtonPressedEventHandler(this.btnInvClass_ButtonClick);
            this.btnInvClass.EditValueChanged += new System.EventHandler(this.btnInvClass_EditValueChanged);
            // 
            // lueInvTo
            // 
            this.lueInvTo.Location = new System.Drawing.Point(581, 21);
            this.lueInvTo.Name = "lueInvTo";
            this.lueInvTo.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
            this.lueInvTo.Size = new System.Drawing.Size(278, 21);
            this.lueInvTo.TabIndex = 75;
            this.lueInvTo.ButtonClick += new DevExpress.XtraEditors.Controls.ButtonPressedEventHandler(this.lueInvTo_ButtonClick);
            this.lueInvTo.EditValueChanged += new System.EventHandler(this.lueInvTo_EditValueChanged);
            // 
            // lueInvStart
            // 
            this.lueInvStart.Location = new System.Drawing.Point(275, 21);
            this.lueInvStart.Name = "lueInvStart";
            this.lueInvStart.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
            this.lueInvStart.Size = new System.Drawing.Size(276, 21);
            this.lueInvStart.TabIndex = 74;
            this.lueInvStart.ButtonClick += new DevExpress.XtraEditors.Controls.ButtonPressedEventHandler(this.lueInvStart_ButtonClick);
            this.lueInvStart.EditValueChanged += new System.EventHandler(this.lueInvStart_EditValueChanged);
            // 
            // btnShowAll
            // 
            this.btnShowAll.Location = new System.Drawing.Point(662, 99);
            this.btnShowAll.Name = "btnShowAll";
            this.btnShowAll.Size = new System.Drawing.Size(75, 23);
            this.btnShowAll.TabIndex = 73;
            this.btnShowAll.Text = "显示全部";
            this.btnShowAll.Click += new System.EventHandler(this.button2_Click);
            // 
            // bntShowSel
            // 
            this.bntShowSel.Location = new System.Drawing.Point(581, 99);
            this.bntShowSel.Name = "bntShowSel";
            this.bntShowSel.Size = new System.Drawing.Size(75, 23);
            this.bntShowSel.TabIndex = 72;
            this.bntShowSel.Text = "显示已选";
            this.bntShowSel.Click += new System.EventHandler(this.button1_Click);
            // 
            // btnFilter
            // 
            this.btnFilter.Location = new System.Drawing.Point(457, 99);
            this.btnFilter.Name = "btnFilter";
            this.btnFilter.Size = new System.Drawing.Size(75, 23);
            this.btnFilter.TabIndex = 71;
            this.btnFilter.Text = "定位";
            this.btnFilter.Click += new System.EventHandler(this.btnFilter_Click);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(12, 102);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(93, 14);
            this.label6.TabIndex = 69;
            this.label6.Text = "定位(存货名称):";
            // 
            // txtInvClassName
            // 
            this.txtInvClassName.Enabled = false;
            this.txtInvClassName.Location = new System.Drawing.Point(233, 75);
            this.txtInvClassName.Name = "txtInvClassName";
            this.txtInvClassName.Size = new System.Drawing.Size(318, 21);
            this.txtInvClassName.TabIndex = 68;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(9, 78);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(55, 14);
            this.label5.TabIndex = 66;
            this.label5.Text = "存货大类";
            // 
            // lblInvTo
            // 
            this.lblInvTo.Enabled = false;
            this.lblInvTo.Location = new System.Drawing.Point(582, 48);
            this.lblInvTo.Name = "lblInvTo";
            this.lblInvTo.Size = new System.Drawing.Size(277, 21);
            this.lblInvTo.TabIndex = 65;
            // 
            // lblInvStart
            // 
            this.lblInvStart.Enabled = false;
            this.lblInvStart.Location = new System.Drawing.Point(274, 48);
            this.lblInvStart.Name = "lblInvStart";
            this.lblInvStart.Size = new System.Drawing.Size(277, 21);
            this.lblInvStart.TabIndex = 65;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(557, 37);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(19, 14);
            this.label3.TabIndex = 4;
            this.label3.Text = "到";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(213, 24);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(55, 14);
            this.label4.TabIndex = 3;
            this.label4.Text = "存货编码";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(213, 48);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(55, 14);
            this.label2.TabIndex = 3;
            this.label2.Text = "存货名称";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 24);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(31, 14);
            this.label1.TabIndex = 1;
            this.label1.Text = "仓库";
            // 
            // lueWH
            // 
            this.lueWH.Location = new System.Drawing.Point(70, 21);
            this.lueWH.Name = "lueWH";
            this.lueWH.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.lueWH.Properties.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("cWhCode", "编号", 20, DevExpress.Utils.FormatType.None, "", true, DevExpress.Utils.HorzAlignment.Default, DevExpress.Data.ColumnSortOrder.None),
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("cWhName", "名称", 40)});
            this.lueWH.Properties.DisplayMember = "cWhName";
            this.lueWH.Properties.NullText = "";
            this.lueWH.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.Standard;
            this.lueWH.Properties.ValueMember = "cWhCode";
            this.lueWH.Size = new System.Drawing.Size(138, 21);
            this.lueWH.TabIndex = 0;
            // 
            // groupBox2
            // 
            this.groupBox2.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox2.Controls.Add(this.grdDetail);
            this.groupBox2.Location = new System.Drawing.Point(0, 158);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(981, 302);
            this.groupBox2.TabIndex = 6;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "仓库存货信息";
            // 
            // grdDetail
            // 
            this.grdDetail.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grdDetail.EmbeddedNavigator.Name = "";
            this.grdDetail.Location = new System.Drawing.Point(3, 18);
            this.grdDetail.MainView = this.grvDetail;
            this.grdDetail.Name = "grdDetail";
            this.grdDetail.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.rpiProxyDoType,
            this.rpiVen,
            this.rpiBackNum,
            this.rpiWH,
            this.rpiBackQty});
            this.grdDetail.Size = new System.Drawing.Size(975, 281);
            this.grdDetail.TabIndex = 13;
            this.grdDetail.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.grvDetail});
            // 
            // grvDetail
            // 
            this.grvDetail.Appearance.ColumnFilterButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(202)))), ((int)(((byte)(221)))), ((int)(((byte)(208)))));
            this.grvDetail.Appearance.ColumnFilterButton.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(202)))), ((int)(((byte)(221)))), ((int)(((byte)(208)))));
            this.grvDetail.Appearance.ColumnFilterButton.ForeColor = System.Drawing.Color.Black;
            this.grvDetail.Appearance.ColumnFilterButton.Options.UseBackColor = true;
            this.grvDetail.Appearance.ColumnFilterButton.Options.UseBorderColor = true;
            this.grvDetail.Appearance.ColumnFilterButton.Options.UseForeColor = true;
            this.grvDetail.Appearance.ColumnFilterButtonActive.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(211)))), ((int)(((byte)(226)))), ((int)(((byte)(216)))));
            this.grvDetail.Appearance.ColumnFilterButtonActive.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(211)))), ((int)(((byte)(226)))), ((int)(((byte)(216)))));
            this.grvDetail.Appearance.ColumnFilterButtonActive.ForeColor = System.Drawing.Color.Black;
            this.grvDetail.Appearance.ColumnFilterButtonActive.Options.UseBackColor = true;
            this.grvDetail.Appearance.ColumnFilterButtonActive.Options.UseBorderColor = true;
            this.grvDetail.Appearance.ColumnFilterButtonActive.Options.UseForeColor = true;
            this.grvDetail.Appearance.Empty.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(242)))), ((int)(((byte)(244)))), ((int)(((byte)(236)))));
            this.grvDetail.Appearance.Empty.BackColor2 = System.Drawing.Color.White;
            this.grvDetail.Appearance.Empty.Options.UseBackColor = true;
            this.grvDetail.Appearance.EvenRow.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(221)))), ((int)(((byte)(227)))), ((int)(((byte)(245)))));
            this.grvDetail.Appearance.EvenRow.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(221)))), ((int)(((byte)(227)))), ((int)(((byte)(245)))));
            this.grvDetail.Appearance.EvenRow.ForeColor = System.Drawing.Color.Black;
            this.grvDetail.Appearance.EvenRow.Options.UseBackColor = true;
            this.grvDetail.Appearance.EvenRow.Options.UseBorderColor = true;
            this.grvDetail.Appearance.EvenRow.Options.UseForeColor = true;
            this.grvDetail.Appearance.FilterCloseButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(202)))), ((int)(((byte)(221)))), ((int)(((byte)(208)))));
            this.grvDetail.Appearance.FilterCloseButton.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(202)))), ((int)(((byte)(221)))), ((int)(((byte)(208)))));
            this.grvDetail.Appearance.FilterCloseButton.ForeColor = System.Drawing.Color.Black;
            this.grvDetail.Appearance.FilterCloseButton.Options.UseBackColor = true;
            this.grvDetail.Appearance.FilterCloseButton.Options.UseBorderColor = true;
            this.grvDetail.Appearance.FilterCloseButton.Options.UseForeColor = true;
            this.grvDetail.Appearance.FilterPanel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(242)))), ((int)(((byte)(244)))), ((int)(((byte)(236)))));
            this.grvDetail.Appearance.FilterPanel.BackColor2 = System.Drawing.Color.White;
            this.grvDetail.Appearance.FilterPanel.ForeColor = System.Drawing.Color.Black;
            this.grvDetail.Appearance.FilterPanel.Options.UseBackColor = true;
            this.grvDetail.Appearance.FilterPanel.Options.UseForeColor = true;
            this.grvDetail.Appearance.FixedLine.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(117)))), ((int)(((byte)(136)))), ((int)(((byte)(122)))));
            this.grvDetail.Appearance.FixedLine.Options.UseBackColor = true;
            this.grvDetail.Appearance.FocusedCell.BackColor = System.Drawing.Color.White;
            this.grvDetail.Appearance.FocusedCell.ForeColor = System.Drawing.Color.Black;
            this.grvDetail.Appearance.FocusedCell.Options.UseBackColor = true;
            this.grvDetail.Appearance.FocusedCell.Options.UseForeColor = true;
            this.grvDetail.Appearance.FocusedRow.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(129)))), ((int)(((byte)(171)))), ((int)(((byte)(177)))));
            this.grvDetail.Appearance.FocusedRow.ForeColor = System.Drawing.Color.White;
            this.grvDetail.Appearance.FocusedRow.Options.UseBackColor = true;
            this.grvDetail.Appearance.FocusedRow.Options.UseForeColor = true;
            this.grvDetail.Appearance.FooterPanel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(202)))), ((int)(((byte)(221)))), ((int)(((byte)(208)))));
            this.grvDetail.Appearance.FooterPanel.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(202)))), ((int)(((byte)(221)))), ((int)(((byte)(208)))));
            this.grvDetail.Appearance.FooterPanel.ForeColor = System.Drawing.Color.Black;
            this.grvDetail.Appearance.FooterPanel.Options.UseBackColor = true;
            this.grvDetail.Appearance.FooterPanel.Options.UseBorderColor = true;
            this.grvDetail.Appearance.FooterPanel.Options.UseForeColor = true;
            this.grvDetail.Appearance.GroupButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(178)))), ((int)(((byte)(209)))), ((int)(((byte)(188)))));
            this.grvDetail.Appearance.GroupButton.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(178)))), ((int)(((byte)(209)))), ((int)(((byte)(188)))));
            this.grvDetail.Appearance.GroupButton.Options.UseBackColor = true;
            this.grvDetail.Appearance.GroupButton.Options.UseBorderColor = true;
            this.grvDetail.Appearance.GroupFooter.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(215)))), ((int)(((byte)(234)))), ((int)(((byte)(221)))));
            this.grvDetail.Appearance.GroupFooter.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(215)))), ((int)(((byte)(234)))), ((int)(((byte)(221)))));
            this.grvDetail.Appearance.GroupFooter.ForeColor = System.Drawing.Color.Black;
            this.grvDetail.Appearance.GroupFooter.Options.UseBackColor = true;
            this.grvDetail.Appearance.GroupFooter.Options.UseBorderColor = true;
            this.grvDetail.Appearance.GroupFooter.Options.UseForeColor = true;
            this.grvDetail.Appearance.GroupPanel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(242)))), ((int)(((byte)(244)))), ((int)(((byte)(236)))));
            this.grvDetail.Appearance.GroupPanel.BackColor2 = System.Drawing.Color.White;
            this.grvDetail.Appearance.GroupPanel.ForeColor = System.Drawing.Color.Black;
            this.grvDetail.Appearance.GroupPanel.Options.UseBackColor = true;
            this.grvDetail.Appearance.GroupPanel.Options.UseForeColor = true;
            this.grvDetail.Appearance.GroupRow.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(215)))), ((int)(((byte)(234)))), ((int)(((byte)(221)))));
            this.grvDetail.Appearance.GroupRow.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(215)))), ((int)(((byte)(234)))), ((int)(((byte)(221)))));
            this.grvDetail.Appearance.GroupRow.ForeColor = System.Drawing.Color.Black;
            this.grvDetail.Appearance.GroupRow.Options.UseBackColor = true;
            this.grvDetail.Appearance.GroupRow.Options.UseBorderColor = true;
            this.grvDetail.Appearance.GroupRow.Options.UseForeColor = true;
            this.grvDetail.Appearance.HeaderPanel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(211)))), ((int)(((byte)(226)))), ((int)(((byte)(216)))));
            this.grvDetail.Appearance.HeaderPanel.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(211)))), ((int)(((byte)(226)))), ((int)(((byte)(216)))));
            this.grvDetail.Appearance.HeaderPanel.ForeColor = System.Drawing.Color.Black;
            this.grvDetail.Appearance.HeaderPanel.Options.UseBackColor = true;
            this.grvDetail.Appearance.HeaderPanel.Options.UseBorderColor = true;
            this.grvDetail.Appearance.HeaderPanel.Options.UseForeColor = true;
            this.grvDetail.Appearance.HideSelectionRow.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(186)))), ((int)(((byte)(211)))), ((int)(((byte)(215)))));
            this.grvDetail.Appearance.HideSelectionRow.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(104)))), ((int)(((byte)(130)))), ((int)(((byte)(134)))));
            this.grvDetail.Appearance.HideSelectionRow.Options.UseBackColor = true;
            this.grvDetail.Appearance.HideSelectionRow.Options.UseForeColor = true;
            this.grvDetail.Appearance.HorzLine.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(172)))), ((int)(((byte)(197)))), ((int)(((byte)(180)))));
            this.grvDetail.Appearance.HorzLine.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(117)))), ((int)(((byte)(136)))), ((int)(((byte)(122)))));
            this.grvDetail.Appearance.HorzLine.Options.UseBackColor = true;
            this.grvDetail.Appearance.HorzLine.Options.UseBorderColor = true;
            this.grvDetail.Appearance.OddRow.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(242)))), ((int)(((byte)(244)))), ((int)(((byte)(236)))));
            this.grvDetail.Appearance.OddRow.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(242)))), ((int)(((byte)(244)))), ((int)(((byte)(236)))));
            this.grvDetail.Appearance.OddRow.ForeColor = System.Drawing.Color.Black;
            this.grvDetail.Appearance.OddRow.Options.UseBackColor = true;
            this.grvDetail.Appearance.OddRow.Options.UseBorderColor = true;
            this.grvDetail.Appearance.OddRow.Options.UseForeColor = true;
            this.grvDetail.Appearance.Preview.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(250)))), ((int)(((byte)(250)))), ((int)(((byte)(240)))));
            this.grvDetail.Appearance.Preview.Font = new System.Drawing.Font("Verdana", 7.5F);
            this.grvDetail.Appearance.Preview.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(104)))), ((int)(((byte)(130)))), ((int)(((byte)(134)))));
            this.grvDetail.Appearance.Preview.Options.UseBackColor = true;
            this.grvDetail.Appearance.Preview.Options.UseFont = true;
            this.grvDetail.Appearance.Preview.Options.UseForeColor = true;
            this.grvDetail.Appearance.Row.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(242)))), ((int)(((byte)(244)))), ((int)(((byte)(236)))));
            this.grvDetail.Appearance.Row.ForeColor = System.Drawing.Color.Black;
            this.grvDetail.Appearance.Row.Options.UseBackColor = true;
            this.grvDetail.Appearance.Row.Options.UseForeColor = true;
            this.grvDetail.Appearance.RowSeparator.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(242)))), ((int)(((byte)(244)))), ((int)(((byte)(236)))));
            this.grvDetail.Appearance.RowSeparator.BackColor2 = System.Drawing.Color.White;
            this.grvDetail.Appearance.RowSeparator.Options.UseBackColor = true;
            this.grvDetail.Appearance.SelectedRow.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(159)))), ((int)(((byte)(201)))), ((int)(((byte)(207)))));
            this.grvDetail.Appearance.SelectedRow.ForeColor = System.Drawing.Color.Black;
            this.grvDetail.Appearance.SelectedRow.Options.UseBackColor = true;
            this.grvDetail.Appearance.SelectedRow.Options.UseForeColor = true;
            this.grvDetail.Appearance.TopNewRow.BackColor = System.Drawing.Color.White;
            this.grvDetail.Appearance.TopNewRow.Options.UseBackColor = true;
            this.grvDetail.Appearance.VertLine.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(172)))), ((int)(((byte)(197)))), ((int)(((byte)(180)))));
            this.grvDetail.Appearance.VertLine.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(117)))), ((int)(((byte)(136)))), ((int)(((byte)(122)))));
            this.grvDetail.Appearance.VertLine.Options.UseBackColor = true;
            this.grvDetail.Appearance.VertLine.Options.UseBorderColor = true;
            this.grvDetail.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colSel,
            this.colInvCode,
            this.colInvName,
            this.gridColumn4,
            this.gridColumn5,
            this.gridColumn6,
            this.colRate,
            this.colQty,
            this.gridColumn8,
            this.colVenCode,
            this.colVenName,
            this.colInvProp,
            this.colDoType,
            this.colChangeInv,
            this.colChangeWH,
            this.colBackQty,
            this.colBackNum,
            this.gridColumn12});
            this.grvDetail.CustomizationFormBounds = new System.Drawing.Rectangle(1072, 422, 208, 175);
            this.grvDetail.GridControl = this.grdDetail;
            this.grvDetail.IndicatorWidth = 40;
            this.grvDetail.Name = "grvDetail";
            this.grvDetail.OptionsCustomization.AllowFilter = false;
            this.grvDetail.OptionsView.ColumnAutoWidth = false;
            this.grvDetail.OptionsView.EnableAppearanceEvenRow = true;
            this.grvDetail.OptionsView.EnableAppearanceOddRow = true;
            this.grvDetail.OptionsView.ShowFooter = true;
            this.grvDetail.OptionsView.ShowGroupPanel = false;
            this.grvDetail.RowCellStyle += new DevExpress.XtraGrid.Views.Grid.RowCellStyleEventHandler(this.grvDetail_RowCellStyle);
            this.grvDetail.CustomDrawRowIndicator += new DevExpress.XtraGrid.Views.Grid.RowIndicatorCustomDrawEventHandler(this.grvDetail_CustomDrawRowIndicator);
            // 
            // colSel
            // 
            this.colSel.Caption = "选择";
            this.colSel.FieldName = "IsSel";
            this.colSel.Fixed = DevExpress.XtraGrid.Columns.FixedStyle.Left;
            this.colSel.Name = "colSel";
            this.colSel.Visible = true;
            this.colSel.VisibleIndex = 0;
            this.colSel.Width = 38;
            // 
            // colInvCode
            // 
            this.colInvCode.Caption = "存货编码";
            this.colInvCode.FieldName = "cInvCode";
            this.colInvCode.Fixed = DevExpress.XtraGrid.Columns.FixedStyle.Left;
            this.colInvCode.Name = "colInvCode";
            this.colInvCode.OptionsColumn.AllowEdit = false;
            this.colInvCode.Visible = true;
            this.colInvCode.VisibleIndex = 1;
            this.colInvCode.Width = 131;
            // 
            // colInvName
            // 
            this.colInvName.Caption = "存货名称";
            this.colInvName.FieldName = "cInvName";
            this.colInvName.Fixed = DevExpress.XtraGrid.Columns.FixedStyle.Left;
            this.colInvName.Name = "colInvName";
            this.colInvName.OptionsColumn.AllowEdit = false;
            this.colInvName.Visible = true;
            this.colInvName.VisibleIndex = 2;
            this.colInvName.Width = 139;
            // 
            // gridColumn4
            // 
            this.gridColumn4.Caption = "规格型号";
            this.gridColumn4.FieldName = "cInvStd";
            this.gridColumn4.Name = "gridColumn4";
            this.gridColumn4.OptionsColumn.AllowEdit = false;
            this.gridColumn4.Visible = true;
            this.gridColumn4.VisibleIndex = 3;
            // 
            // gridColumn5
            // 
            this.gridColumn5.Caption = "主计量";
            this.gridColumn5.FieldName = "MUnitName";
            this.gridColumn5.Name = "gridColumn5";
            this.gridColumn5.OptionsColumn.AllowEdit = false;
            this.gridColumn5.Visible = true;
            this.gridColumn5.VisibleIndex = 4;
            // 
            // gridColumn6
            // 
            this.gridColumn6.Caption = "辅计量";
            this.gridColumn6.FieldName = "AUnitName";
            this.gridColumn6.Name = "gridColumn6";
            this.gridColumn6.OptionsColumn.AllowEdit = false;
            this.gridColumn6.Visible = true;
            this.gridColumn6.VisibleIndex = 5;
            // 
            // colRate
            // 
            this.colRate.Caption = "换算率";
            this.colRate.FieldName = "Rate";
            this.colRate.Name = "colRate";
            this.colRate.OptionsColumn.AllowEdit = false;
            this.colRate.Visible = true;
            this.colRate.VisibleIndex = 6;
            // 
            // colQty
            // 
            this.colQty.Caption = "库存数量";
            this.colQty.FieldName = "iQuantity";
            this.colQty.Name = "colQty";
            this.colQty.OptionsColumn.AllowEdit = false;
            this.colQty.Visible = true;
            this.colQty.VisibleIndex = 7;
            this.colQty.Width = 63;
            // 
            // gridColumn8
            // 
            this.gridColumn8.Caption = "库存件数";
            this.gridColumn8.FieldName = "iNum";
            this.gridColumn8.Name = "gridColumn8";
            this.gridColumn8.OptionsColumn.AllowEdit = false;
            this.gridColumn8.Visible = true;
            this.gridColumn8.VisibleIndex = 8;
            // 
            // colVenCode
            // 
            this.colVenCode.AppearanceHeader.ForeColor = System.Drawing.Color.Blue;
            this.colVenCode.AppearanceHeader.Options.UseForeColor = true;
            this.colVenCode.Caption = "供应商编码";
            this.colVenCode.ColumnEdit = this.rpiVen;
            this.colVenCode.FieldName = "cVenCode";
            this.colVenCode.Name = "colVenCode";
            this.colVenCode.Visible = true;
            this.colVenCode.VisibleIndex = 11;
            this.colVenCode.Width = 86;
            // 
            // rpiVen
            // 
            this.rpiVen.AutoHeight = false;
            this.rpiVen.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
            this.rpiVen.Name = "rpiVen";
            this.rpiVen.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.DisableTextEditor;
            this.rpiVen.ButtonClick += new DevExpress.XtraEditors.Controls.ButtonPressedEventHandler(this.rpiVen_ButtonClick);
            // 
            // colVenName
            // 
            this.colVenName.Caption = "供应商名称";
            this.colVenName.FieldName = "cVenName";
            this.colVenName.Name = "colVenName";
            this.colVenName.OptionsColumn.AllowEdit = false;
            this.colVenName.Visible = true;
            this.colVenName.VisibleIndex = 12;
            this.colVenName.Width = 99;
            // 
            // colInvProp
            // 
            this.colInvProp.Caption = "存货属性";
            this.colInvProp.FieldName = "InvProp";
            this.colInvProp.Name = "colInvProp";
            this.colInvProp.OptionsColumn.AllowEdit = false;
            this.colInvProp.Visible = true;
            this.colInvProp.VisibleIndex = 14;
            this.colInvProp.Width = 111;
            // 
            // colDoType
            // 
            this.colDoType.AppearanceHeader.ForeColor = System.Drawing.Color.Blue;
            this.colDoType.AppearanceHeader.Options.UseForeColor = true;
            this.colDoType.Caption = "处理方案";
            this.colDoType.ColumnEdit = this.rpiProxyDoType;
            this.colDoType.FieldName = "DoType";
            this.colDoType.Name = "colDoType";
            this.colDoType.Visible = true;
            this.colDoType.VisibleIndex = 13;
            this.colDoType.Width = 97;
            // 
            // rpiProxyDoType
            // 
            this.rpiProxyDoType.AutoHeight = false;
            this.rpiProxyDoType.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
            this.rpiProxyDoType.Name = "rpiProxyDoType";
            this.rpiProxyDoType.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.DisableTextEditor;
            this.rpiProxyDoType.Click += new System.EventHandler(this.rpiProxyDoType_Click);
            this.rpiProxyDoType.ButtonClick += new DevExpress.XtraEditors.Controls.ButtonPressedEventHandler(this.rpiProxyDoType_ButtonClick);
            // 
            // colChangeInv
            // 
            this.colChangeInv.Caption = "形态转换后物料";
            this.colChangeInv.FieldName = "ChangedInv";
            this.colChangeInv.Name = "colChangeInv";
            this.colChangeInv.OptionsColumn.AllowEdit = false;
            this.colChangeInv.Visible = true;
            this.colChangeInv.VisibleIndex = 15;
            this.colChangeInv.Width = 105;
            // 
            // colChangeWH
            // 
            this.colChangeWH.AppearanceHeader.ForeColor = System.Drawing.Color.Blue;
            this.colChangeWH.AppearanceHeader.Options.UseForeColor = true;
            this.colChangeWH.Caption = "形态转换后仓库";
            this.colChangeWH.ColumnEdit = this.rpiWH;
            this.colChangeWH.FieldName = "ChangedWH";
            this.colChangeWH.Name = "colChangeWH";
            this.colChangeWH.Visible = true;
            this.colChangeWH.VisibleIndex = 16;
            this.colChangeWH.Width = 97;
            // 
            // rpiWH
            // 
            this.rpiWH.AutoHeight = false;
            this.rpiWH.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.rpiWH.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("cWhCode", "仓库编码", 20, DevExpress.Utils.FormatType.None, "", true, DevExpress.Utils.HorzAlignment.Default, DevExpress.Data.ColumnSortOrder.None),
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("cWhName", "仓库名称", 20, DevExpress.Utils.FormatType.None, "", true, DevExpress.Utils.HorzAlignment.Default, DevExpress.Data.ColumnSortOrder.None)});
            this.rpiWH.DisplayMember = "cWhName";
            this.rpiWH.Name = "rpiWH";
            this.rpiWH.ValueMember = "cWhCode";
            // 
            // colBackQty
            // 
            this.colBackQty.AppearanceHeader.ForeColor = System.Drawing.Color.Blue;
            this.colBackQty.AppearanceHeader.Options.UseForeColor = true;
            this.colBackQty.Caption = "退货数量";
            this.colBackQty.ColumnEdit = this.rpiBackQty;
            this.colBackQty.FieldName = "BackQty";
            this.colBackQty.Name = "colBackQty";
            this.colBackQty.Visible = true;
            this.colBackQty.VisibleIndex = 9;
            // 
            // colBackNum
            // 
            this.colBackNum.AppearanceHeader.ForeColor = System.Drawing.Color.Blue;
            this.colBackNum.AppearanceHeader.Options.UseForeColor = true;
            this.colBackNum.Caption = "退货件数";
            this.colBackNum.ColumnEdit = this.rpiBackNum;
            this.colBackNum.FieldName = "BackNum";
            this.colBackNum.Name = "colBackNum";
            this.colBackNum.Visible = true;
            this.colBackNum.VisibleIndex = 10;
            // 
            // rpiBackNum
            // 
            this.rpiBackNum.AutoHeight = false;
            this.rpiBackNum.Name = "rpiBackNum";
            this.rpiBackNum.EditValueChanged += new System.EventHandler(this.rpiBackNum_EditValueChanged);
            // 
            // gridColumn12
            // 
            this.gridColumn12.Caption = "需求数";
            this.gridColumn12.Name = "gridColumn12";
            this.gridColumn12.OptionsColumn.AllowEdit = false;
            this.gridColumn12.Width = 104;
            // 
            // FrmWHBack
            // 
            this.Appearance.BackColor = System.Drawing.SystemColors.Control;
            this.Appearance.Options.UseBackColor = true;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(991, 476);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.groupBox2);
            this.Name = "FrmWHBack";
            this.Text = "仓库退货";
            this.Load += new System.EventHandler(this.FormVenBack_Load);
            this.Controls.SetChildIndex(this.groupBox2, 0);
            this.Controls.SetChildIndex(this.groupBox1, 0);
            ((System.ComponentModel.ISupportInitialize)(this.rpiBackQty)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtSeaInvName.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtSeaInvCode.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnInvClass.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lueInvTo.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lueInvStart.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtInvClassName.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblInvTo.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblInvStart.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lueWH.Properties)).EndInit();
            this.groupBox2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.grdDetail)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grvDetail)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.rpiVen)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.rpiProxyDoType)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.rpiWH)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.rpiBackNum)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private DevExpress.XtraGrid.GridControl grdDetail;
        private DevExpress.XtraGrid.Views.Grid.GridView grvDetail;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private DevExpress.XtraEditors.LookUpEdit lueWH;
        private DevExpress.XtraGrid.Columns.GridColumn colSel;
        private DevExpress.XtraGrid.Columns.GridColumn colInvCode;
        private DevExpress.XtraGrid.Columns.GridColumn colInvName;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn4;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn5;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn6;
        private DevExpress.XtraGrid.Columns.GridColumn colQty;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn8;
        private DevExpress.XtraGrid.Columns.GridColumn colVenCode;
        private DevExpress.XtraGrid.Columns.GridColumn colInvProp;
        private DevExpress.XtraGrid.Columns.GridColumn colChangeInv;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn12;
        private DevExpress.XtraGrid.Columns.GridColumn colBackQty;
        private DevExpress.XtraGrid.Columns.GridColumn colDoType;
        private DevExpress.XtraEditors.Repository.RepositoryItemButtonEdit rpiProxyDoType;
        private DevExpress.XtraEditors.Repository.RepositoryItemButtonEdit rpiVen;
        private DevExpress.XtraGrid.Columns.GridColumn colVenName;
        private DevExpress.XtraEditors.TextEdit lblInvTo;
        private DevExpress.XtraEditors.TextEdit lblInvStart;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private DevExpress.XtraEditors.TextEdit txtInvClassName;
        private DevExpress.XtraGrid.Columns.GridColumn colChangeWH;
        private DevExpress.XtraGrid.Columns.GridColumn colBackNum;
        private DevExpress.XtraGrid.Columns.GridColumn colRate;
        private DevExpress.XtraEditors.Repository.RepositoryItemTextEdit rpiBackNum;
        private System.Windows.Forms.Label label6;
        private DevExpress.XtraEditors.SimpleButton btnFilter;
        private DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit rpiWH;
        private DevExpress.XtraEditors.SimpleButton btnShowAll;
        private DevExpress.XtraEditors.SimpleButton bntShowSel;
        private DevExpress.XtraEditors.ButtonEdit lueInvTo;
        private DevExpress.XtraEditors.ButtonEdit lueInvStart;
        private DevExpress.XtraEditors.ButtonEdit btnInvClass;
        private DevExpress.XtraEditors.TextEdit txtSeaInvName;
        private DevExpress.XtraEditors.ButtonEdit txtSeaInvCode;
        private DevExpress.XtraEditors.Repository.RepositoryItemTextEdit rpiBackQty;



    }
}