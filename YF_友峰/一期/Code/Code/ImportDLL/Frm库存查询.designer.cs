namespace ImportDLL
{
    partial class Frm库存查询
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
            this.layoutControl1 = new DevExpress.XtraLayout.LayoutControl();
            this.gridControl1 = new DevExpress.XtraGrid.GridControl();
            this.gridView1 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.gridCol存放区域 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridCol单据号 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridCol制单人 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridCol存货编码 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridCol存货名称 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridCol序列号 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridCol宽度 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridCol长度 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridCol厚度 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridCol现存量 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridCol材料密度 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridCol产品密度 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridCol材料重量 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridCol产品重量 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridCol描述 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.ItemLookUpEditWorkplant = new DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit();
            this.ItemLookUpEditPerState = new DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit();
            this.ItemLookUpEditType = new DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit();
            this.ItemLookUpEditPost = new DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit();
            this.ItemLookUpEditLevels = new DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit();
            this.ItemLookUpEditPerType = new DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit();
            this.layoutControlGroup1 = new DevExpress.XtraLayout.LayoutControlGroup();
            this.layoutControlItem3 = new DevExpress.XtraLayout.LayoutControlItem();
            this.buttonEdit存货编码 = new DevExpress.XtraEditors.ButtonEdit();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.lookUpEdit区域 = new DevExpress.XtraEditors.LookUpEdit();
            this.label3 = new System.Windows.Forms.Label();
            this.lookUpEdit材料类型 = new DevExpress.XtraEditors.LookUpEdit();
            this.gridCol备注 = new DevExpress.XtraGrid.Columns.GridColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dsPrint)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dsForm)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtSel)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControl1)).BeginInit();
            this.layoutControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ItemLookUpEditWorkplant)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ItemLookUpEditPerState)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ItemLookUpEditType)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ItemLookUpEditPost)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ItemLookUpEditLevels)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ItemLookUpEditPerType)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.buttonEdit存货编码.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lookUpEdit区域.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lookUpEdit材料类型.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // layoutControl1
            // 
            this.layoutControl1.AllowCustomizationMenu = false;
            this.layoutControl1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.layoutControl1.Controls.Add(this.gridControl1);
            this.layoutControl1.Location = new System.Drawing.Point(0, 28);
            this.layoutControl1.Name = "layoutControl1";
            this.layoutControl1.OptionsCustomizationForm.DesignTimeCustomizationFormPositionAndSize = new System.Drawing.Rectangle(210, 239, 250, 350);
            this.layoutControl1.OptionsCustomizationForm.ShowLoadButton = false;
            this.layoutControl1.OptionsCustomizationForm.ShowSaveButton = false;
            this.layoutControl1.OptionsView.UseDefaultDragAndDropRendering = false;
            this.layoutControl1.Root = this.layoutControlGroup1;
            this.layoutControl1.Size = new System.Drawing.Size(1202, 485);
            this.layoutControl1.TabIndex = 5;
            this.layoutControl1.Text = "layoutControl1";
            // 
            // gridControl1
            // 
            this.gridControl1.Location = new System.Drawing.Point(12, 12);
            this.gridControl1.MainView = this.gridView1;
            this.gridControl1.Name = "gridControl1";
            this.gridControl1.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.ItemLookUpEditWorkplant,
            this.ItemLookUpEditPerState,
            this.ItemLookUpEditType,
            this.ItemLookUpEditPost,
            this.ItemLookUpEditLevels,
            this.ItemLookUpEditPerType});
            this.gridControl1.Size = new System.Drawing.Size(1178, 461);
            this.gridControl1.TabIndex = 6;
            this.gridControl1.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView1});
            // 
            // gridView1
            // 
            this.gridView1.Appearance.FocusedCell.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.gridView1.Appearance.FocusedCell.Options.UseBackColor = true;
            this.gridView1.Appearance.FocusedRow.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.gridView1.Appearance.FocusedRow.Options.UseBackColor = true;
            this.gridView1.Appearance.SelectedRow.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.gridView1.Appearance.SelectedRow.Options.UseBackColor = true;
            this.gridView1.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.gridCol存放区域,
            this.gridCol单据号,
            this.gridCol制单人,
            this.gridCol存货编码,
            this.gridCol存货名称,
            this.gridCol序列号,
            this.gridCol宽度,
            this.gridCol长度,
            this.gridCol厚度,
            this.gridCol现存量,
            this.gridCol材料密度,
            this.gridCol产品密度,
            this.gridCol材料重量,
            this.gridCol产品重量,
            this.gridCol描述,
            this.gridCol备注});
            this.gridView1.GridControl = this.gridControl1;
            this.gridView1.IndicatorWidth = 40;
            this.gridView1.Name = "gridView1";
            this.gridView1.OptionsBehavior.Editable = false;
            this.gridView1.OptionsLayout.Columns.StoreAllOptions = true;
            this.gridView1.OptionsLayout.Columns.StoreAppearance = true;
            this.gridView1.OptionsLayout.StoreAllOptions = true;
            this.gridView1.OptionsLayout.StoreAppearance = true;
            this.gridView1.OptionsMenu.ShowAddNewSummaryItem = DevExpress.Utils.DefaultBoolean.True;
            this.gridView1.OptionsMenu.ShowGroupSummaryEditorItem = true;
            this.gridView1.OptionsNavigation.EnterMoveNextColumn = true;
            this.gridView1.OptionsSelection.MultiSelect = true;
            this.gridView1.OptionsView.AutoCalcPreviewLineCount = true;
            this.gridView1.OptionsView.ColumnAutoWidth = false;
            this.gridView1.OptionsView.EnableAppearanceEvenRow = true;
            this.gridView1.OptionsView.EnableAppearanceOddRow = true;
            this.gridView1.OptionsView.ShowGroupPanel = false;
            this.gridView1.CustomDrawRowIndicator += new DevExpress.XtraGrid.Views.Grid.RowIndicatorCustomDrawEventHandler(this.gridView1_CustomDrawRowIndicator);
            // 
            // gridCol存放区域
            // 
            this.gridCol存放区域.Caption = "存放区域";
            this.gridCol存放区域.FieldName = "存放区域";
            this.gridCol存放区域.Name = "gridCol存放区域";
            this.gridCol存放区域.Visible = true;
            this.gridCol存放区域.VisibleIndex = 0;
            this.gridCol存放区域.Width = 60;
            // 
            // gridCol单据号
            // 
            this.gridCol单据号.Caption = "单据号";
            this.gridCol单据号.FieldName = "单据号";
            this.gridCol单据号.Name = "gridCol单据号";
            this.gridCol单据号.Visible = true;
            this.gridCol单据号.VisibleIndex = 1;
            this.gridCol单据号.Width = 120;
            // 
            // gridCol制单人
            // 
            this.gridCol制单人.Caption = "制单人";
            this.gridCol制单人.FieldName = "制单人";
            this.gridCol制单人.Name = "gridCol制单人";
            this.gridCol制单人.Visible = true;
            this.gridCol制单人.VisibleIndex = 2;
            this.gridCol制单人.Width = 60;
            // 
            // gridCol存货编码
            // 
            this.gridCol存货编码.Caption = "存货编码";
            this.gridCol存货编码.FieldName = "存货编码";
            this.gridCol存货编码.Name = "gridCol存货编码";
            this.gridCol存货编码.OptionsColumn.AllowMerge = DevExpress.Utils.DefaultBoolean.False;
            this.gridCol存货编码.Visible = true;
            this.gridCol存货编码.VisibleIndex = 3;
            this.gridCol存货编码.Width = 200;
            // 
            // gridCol存货名称
            // 
            this.gridCol存货名称.Caption = "存货名称";
            this.gridCol存货名称.FieldName = "存货名称";
            this.gridCol存货名称.Name = "gridCol存货名称";
            this.gridCol存货名称.Visible = true;
            this.gridCol存货名称.VisibleIndex = 4;
            // 
            // gridCol序列号
            // 
            this.gridCol序列号.Caption = "序列号";
            this.gridCol序列号.FieldName = "序列号";
            this.gridCol序列号.Name = "gridCol序列号";
            this.gridCol序列号.Visible = true;
            this.gridCol序列号.VisibleIndex = 5;
            // 
            // gridCol宽度
            // 
            this.gridCol宽度.Caption = "宽度";
            this.gridCol宽度.FieldName = "宽度";
            this.gridCol宽度.Name = "gridCol宽度";
            this.gridCol宽度.Visible = true;
            this.gridCol宽度.VisibleIndex = 6;
            // 
            // gridCol长度
            // 
            this.gridCol长度.Caption = "长度";
            this.gridCol长度.FieldName = "长度";
            this.gridCol长度.Name = "gridCol长度";
            this.gridCol长度.Visible = true;
            this.gridCol长度.VisibleIndex = 7;
            // 
            // gridCol厚度
            // 
            this.gridCol厚度.Caption = "厚度";
            this.gridCol厚度.FieldName = "厚度";
            this.gridCol厚度.Name = "gridCol厚度";
            this.gridCol厚度.Visible = true;
            this.gridCol厚度.VisibleIndex = 8;
            // 
            // gridCol现存量
            // 
            this.gridCol现存量.Caption = "现存量";
            this.gridCol现存量.FieldName = "现存量";
            this.gridCol现存量.Name = "gridCol现存量";
            this.gridCol现存量.OptionsColumn.AllowMerge = DevExpress.Utils.DefaultBoolean.False;
            this.gridCol现存量.Visible = true;
            this.gridCol现存量.VisibleIndex = 9;
            this.gridCol现存量.Width = 70;
            // 
            // gridCol材料密度
            // 
            this.gridCol材料密度.Caption = "材料密度";
            this.gridCol材料密度.FieldName = "材料密度";
            this.gridCol材料密度.Name = "gridCol材料密度";
            this.gridCol材料密度.Visible = true;
            this.gridCol材料密度.VisibleIndex = 10;
            // 
            // gridCol产品密度
            // 
            this.gridCol产品密度.Caption = "产品密度";
            this.gridCol产品密度.FieldName = "产品密度";
            this.gridCol产品密度.Name = "gridCol产品密度";
            // 
            // gridCol材料重量
            // 
            this.gridCol材料重量.Caption = "材料重量";
            this.gridCol材料重量.FieldName = "材料重量";
            this.gridCol材料重量.Name = "gridCol材料重量";
            this.gridCol材料重量.Visible = true;
            this.gridCol材料重量.VisibleIndex = 11;
            // 
            // gridCol产品重量
            // 
            this.gridCol产品重量.Caption = "产品重量";
            this.gridCol产品重量.FieldName = "产品重量";
            this.gridCol产品重量.Name = "gridCol产品重量";
            // 
            // gridCol描述
            // 
            this.gridCol描述.Caption = "描述";
            this.gridCol描述.FieldName = "描述";
            this.gridCol描述.Name = "gridCol描述";
            this.gridCol描述.Visible = true;
            this.gridCol描述.VisibleIndex = 12;
            // 
            // ItemLookUpEditWorkplant
            // 
            this.ItemLookUpEditWorkplant.AutoHeight = false;
            this.ItemLookUpEditWorkplant.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.ItemLookUpEditWorkplant.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("WorkplantNO", "编号"),
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("Workplant", "类型")});
            this.ItemLookUpEditWorkplant.DisplayMember = "Workplant";
            this.ItemLookUpEditWorkplant.Name = "ItemLookUpEditWorkplant";
            this.ItemLookUpEditWorkplant.NullText = "";
            this.ItemLookUpEditWorkplant.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.Standard;
            this.ItemLookUpEditWorkplant.ValueMember = "WorkplantNO";
            // 
            // ItemLookUpEditPerState
            // 
            this.ItemLookUpEditPerState.AutoHeight = false;
            this.ItemLookUpEditPerState.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.ItemLookUpEditPerState.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("iID", "序号"),
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("State", "状态")});
            this.ItemLookUpEditPerState.DisplayMember = "State";
            this.ItemLookUpEditPerState.Name = "ItemLookUpEditPerState";
            this.ItemLookUpEditPerState.NullText = "";
            this.ItemLookUpEditPerState.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.Standard;
            this.ItemLookUpEditPerState.ValueMember = "iID";
            // 
            // ItemLookUpEditType
            // 
            this.ItemLookUpEditType.AutoHeight = false;
            this.ItemLookUpEditType.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.ItemLookUpEditType.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("iID", "序号"),
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("iText", "状态")});
            this.ItemLookUpEditType.DisplayMember = "iText";
            this.ItemLookUpEditType.Name = "ItemLookUpEditType";
            this.ItemLookUpEditType.NullText = "";
            this.ItemLookUpEditType.ValueMember = "iID";
            // 
            // ItemLookUpEditPost
            // 
            this.ItemLookUpEditPost.AutoHeight = false;
            this.ItemLookUpEditPost.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.ItemLookUpEditPost.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("iID", "序号"),
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("iText", "状态")});
            this.ItemLookUpEditPost.DisplayMember = "iText";
            this.ItemLookUpEditPost.Name = "ItemLookUpEditPost";
            this.ItemLookUpEditPost.NullText = "";
            this.ItemLookUpEditPost.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.Standard;
            this.ItemLookUpEditPost.ValueMember = "iID";
            // 
            // ItemLookUpEditLevels
            // 
            this.ItemLookUpEditLevels.AutoHeight = false;
            this.ItemLookUpEditLevels.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.ItemLookUpEditLevels.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("iID", "序号"),
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("iText", "状态")});
            this.ItemLookUpEditLevels.DisplayMember = "iText";
            this.ItemLookUpEditLevels.Name = "ItemLookUpEditLevels";
            this.ItemLookUpEditLevels.NullText = "";
            this.ItemLookUpEditLevels.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.Standard;
            this.ItemLookUpEditLevels.ValueMember = "iID";
            // 
            // ItemLookUpEditPerType
            // 
            this.ItemLookUpEditPerType.AutoHeight = false;
            this.ItemLookUpEditPerType.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.ItemLookUpEditPerType.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("iID", "序号"),
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("iText", "类型")});
            this.ItemLookUpEditPerType.DisplayMember = "iText";
            this.ItemLookUpEditPerType.Name = "ItemLookUpEditPerType";
            this.ItemLookUpEditPerType.NullText = "";
            this.ItemLookUpEditPerType.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.Standard;
            this.ItemLookUpEditPerType.ValueMember = "iID";
            // 
            // layoutControlGroup1
            // 
            this.layoutControlGroup1.CustomizationFormText = "layoutControlGroup1";
            this.layoutControlGroup1.EnableIndentsWithoutBorders = DevExpress.Utils.DefaultBoolean.True;
            this.layoutControlGroup1.GroupBordersVisible = false;
            this.layoutControlGroup1.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.layoutControlItem3});
            this.layoutControlGroup1.Location = new System.Drawing.Point(0, 0);
            this.layoutControlGroup1.Name = "Root";
            this.layoutControlGroup1.Size = new System.Drawing.Size(1202, 485);
            this.layoutControlGroup1.Text = "Root";
            this.layoutControlGroup1.TextVisible = false;
            // 
            // layoutControlItem3
            // 
            this.layoutControlItem3.Control = this.gridControl1;
            this.layoutControlItem3.CustomizationFormText = "layoutControlItem3";
            this.layoutControlItem3.Location = new System.Drawing.Point(0, 0);
            this.layoutControlItem3.Name = "layoutControlItem3";
            this.layoutControlItem3.Size = new System.Drawing.Size(1182, 465);
            this.layoutControlItem3.Text = "layoutControlItem3";
            this.layoutControlItem3.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem3.TextToControlDistance = 0;
            this.layoutControlItem3.TextVisible = false;
            // 
            // buttonEdit存货编码
            // 
            this.buttonEdit存货编码.Location = new System.Drawing.Point(94, 13);
            this.buttonEdit存货编码.Name = "buttonEdit存货编码";
            this.buttonEdit存货编码.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
            this.buttonEdit存货编码.Size = new System.Drawing.Size(200, 21);
            this.buttonEdit存货编码.TabIndex = 6;
            this.buttonEdit存货编码.ButtonClick += new DevExpress.XtraEditors.Controls.ButtonPressedEventHandler(this.buttonEdit存货编码_ButtonClick);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(33, 15);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(55, 14);
            this.label1.TabIndex = 7;
            this.label1.Text = "存货编码";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(314, 15);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(31, 14);
            this.label2.TabIndex = 9;
            this.label2.Text = "区域";
            // 
            // lookUpEdit区域
            // 
            this.lookUpEdit区域.Location = new System.Drawing.Point(362, 12);
            this.lookUpEdit区域.Name = "lookUpEdit区域";
            this.lookUpEdit区域.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.lookUpEdit区域.Properties.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("iID", "区域序号"),
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("iText", "区域名称")});
            this.lookUpEdit区域.Properties.DisplayMember = "iText";
            this.lookUpEdit区域.Properties.NullText = "";
            this.lookUpEdit区域.Properties.ValueMember = "iID";
            this.lookUpEdit区域.Size = new System.Drawing.Size(100, 21);
            this.lookUpEdit区域.TabIndex = 10;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(480, 15);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(55, 14);
            this.label3.TabIndex = 12;
            this.label3.Text = "材料类型";
            // 
            // lookUpEdit材料类型
            // 
            this.lookUpEdit材料类型.Location = new System.Drawing.Point(561, 12);
            this.lookUpEdit材料类型.Name = "lookUpEdit材料类型";
            this.lookUpEdit材料类型.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.lookUpEdit材料类型.Properties.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("iID", "材料类型")});
            this.lookUpEdit材料类型.Properties.DisplayMember = "iID";
            this.lookUpEdit材料类型.Properties.NullText = "";
            this.lookUpEdit材料类型.Properties.ValueMember = "iID";
            this.lookUpEdit材料类型.Size = new System.Drawing.Size(100, 21);
            this.lookUpEdit材料类型.TabIndex = 13;
            this.lookUpEdit材料类型.EditValueChanged += new System.EventHandler(this.lookUpEdit材料类型_EditValueChanged);
            // 
            // gridCol备注
            // 
            this.gridCol备注.Caption = "备注";
            this.gridCol备注.FieldName = "备注";
            this.gridCol备注.Name = "gridCol备注";
            this.gridCol备注.OptionsColumn.AllowEdit = false;
            this.gridCol备注.Visible = true;
            this.gridCol备注.VisibleIndex = 13;
            // 
            // Frm库存查询
            // 
            this.Appearance.BackColor = System.Drawing.SystemColors.Control;
            this.Appearance.Options.UseBackColor = true;
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1200, 514);
            this.Controls.Add(this.lookUpEdit材料类型);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.lookUpEdit区域);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.buttonEdit存货编码);
            this.Controls.Add(this.layoutControl1);
            this.Name = "Frm库存查询";
            this.Text = "现存量";
            this.Load += new System.EventHandler(this.FrmWorkPerson_Load);
            this.Controls.SetChildIndex(this.layoutControl1, 0);
            this.Controls.SetChildIndex(this.buttonEdit存货编码, 0);
            this.Controls.SetChildIndex(this.label1, 0);
            this.Controls.SetChildIndex(this.label2, 0);
            this.Controls.SetChildIndex(this.lookUpEdit区域, 0);
            this.Controls.SetChildIndex(this.label3, 0);
            this.Controls.SetChildIndex(this.lookUpEdit材料类型, 0);
            ((System.ComponentModel.ISupportInitialize)(this.dsPrint)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dsForm)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtSel)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControl1)).EndInit();
            this.layoutControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ItemLookUpEditWorkplant)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ItemLookUpEditPerState)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ItemLookUpEditType)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ItemLookUpEditPost)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ItemLookUpEditLevels)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ItemLookUpEditPerType)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.buttonEdit存货编码.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lookUpEdit区域.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lookUpEdit材料类型.Properties)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraLayout.LayoutControl layoutControl1;
        private DevExpress.XtraGrid.GridControl gridControl1;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView1;
        private DevExpress.XtraLayout.LayoutControlGroup layoutControlGroup1;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem3;
        private DevExpress.XtraGrid.Columns.GridColumn gridCol存货编码;
        private DevExpress.XtraGrid.Columns.GridColumn gridCol现存量;
        private DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit ItemLookUpEditWorkplant;
        private DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit ItemLookUpEditPerState;
        private DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit ItemLookUpEditType;
        private DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit ItemLookUpEditPost;
        private DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit ItemLookUpEditLevels;
        private DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit ItemLookUpEditPerType;
        private DevExpress.XtraEditors.ButtonEdit buttonEdit存货编码;
        private System.Windows.Forms.Label label1;
        private DevExpress.XtraGrid.Columns.GridColumn gridCol存货名称;
        private DevExpress.XtraGrid.Columns.GridColumn gridCol宽度;
        private DevExpress.XtraGrid.Columns.GridColumn gridCol长度;
        private DevExpress.XtraGrid.Columns.GridColumn gridCol厚度;
        private DevExpress.XtraGrid.Columns.GridColumn gridCol序列号;
        private DevExpress.XtraGrid.Columns.GridColumn gridCol存放区域;
        private System.Windows.Forms.Label label2;
        private DevExpress.XtraGrid.Columns.GridColumn gridCol材料密度;
        private DevExpress.XtraGrid.Columns.GridColumn gridCol产品密度;
        private DevExpress.XtraGrid.Columns.GridColumn gridCol材料重量;
        private DevExpress.XtraGrid.Columns.GridColumn gridCol产品重量;
        private DevExpress.XtraEditors.LookUpEdit lookUpEdit区域;
        private DevExpress.XtraGrid.Columns.GridColumn gridCol描述;
        private DevExpress.XtraGrid.Columns.GridColumn gridCol单据号;
        private DevExpress.XtraGrid.Columns.GridColumn gridCol制单人;
        private System.Windows.Forms.Label label3;
        private DevExpress.XtraEditors.LookUpEdit lookUpEdit材料类型;
        private DevExpress.XtraGrid.Columns.GridColumn gridCol备注;
    }
}