namespace ImportDLL
{
    partial class Frm汇总表
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
            this.gridCol日期 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridCol存货编码 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridCol合金属性 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridCol开料单号 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridCol切割产品重量 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridCol切割材料重量 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridCol废料重量 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridCol实际用料重量 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridCol废料率 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridCol材料类型 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.ItemLookUpEditWorkplant = new DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit();
            this.ItemLookUpEditPerState = new DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit();
            this.ItemLookUpEditType = new DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit();
            this.ItemLookUpEditPost = new DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit();
            this.ItemLookUpEditLevels = new DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit();
            this.ItemLookUpEditPerType = new DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit();
            this.layoutControlGroup1 = new DevExpress.XtraLayout.LayoutControlGroup();
            this.layoutControlItem3 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem4 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem1 = new DevExpress.XtraLayout.LayoutControlItem();
            this.dateEdit1 = new DevExpress.XtraEditors.DateEdit();
            this.dateEdit2 = new DevExpress.XtraEditors.DateEdit();
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            this.lookUpEdit材料类型 = new DevExpress.XtraEditors.LookUpEdit();
            this.label3 = new System.Windows.Forms.Label();
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
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dateEdit1.Properties.VistaTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dateEdit1.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dateEdit2.Properties.VistaTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dateEdit2.Properties)).BeginInit();
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
            this.layoutControl1.Size = new System.Drawing.Size(1146, 460);
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
            this.gridControl1.Size = new System.Drawing.Size(1122, 436);
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
            this.gridCol日期,
            this.gridCol存货编码,
            this.gridCol合金属性,
            this.gridCol开料单号,
            this.gridCol切割产品重量,
            this.gridCol切割材料重量,
            this.gridCol废料重量,
            this.gridCol实际用料重量,
            this.gridCol废料率,
            this.gridCol材料类型});
            this.gridView1.GridControl = this.gridControl1;
            this.gridView1.IndicatorWidth = 40;
            this.gridView1.Name = "gridView1";
            this.gridView1.OptionsBehavior.Editable = false;
            this.gridView1.OptionsCustomization.AllowSort = false;
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
            // gridCol日期
            // 
            this.gridCol日期.Caption = "日期";
            this.gridCol日期.FieldName = "日期";
            this.gridCol日期.Name = "gridCol日期";
            this.gridCol日期.Visible = true;
            this.gridCol日期.VisibleIndex = 0;
            this.gridCol日期.Width = 87;
            // 
            // gridCol存货编码
            // 
            this.gridCol存货编码.Caption = "存货编码";
            this.gridCol存货编码.FieldName = "存货编码";
            this.gridCol存货编码.Name = "gridCol存货编码";
            this.gridCol存货编码.OptionsColumn.AllowMerge = DevExpress.Utils.DefaultBoolean.False;
            this.gridCol存货编码.Visible = true;
            this.gridCol存货编码.VisibleIndex = 1;
            this.gridCol存货编码.Width = 177;
            // 
            // gridCol合金属性
            // 
            this.gridCol合金属性.Caption = "合金属性";
            this.gridCol合金属性.FieldName = "合金属性";
            this.gridCol合金属性.Name = "gridCol合金属性";
            this.gridCol合金属性.Visible = true;
            this.gridCol合金属性.VisibleIndex = 3;
            // 
            // gridCol开料单号
            // 
            this.gridCol开料单号.Caption = "开料单号";
            this.gridCol开料单号.FieldName = "开料单号";
            this.gridCol开料单号.Name = "gridCol开料单号";
            this.gridCol开料单号.Visible = true;
            this.gridCol开料单号.VisibleIndex = 4;
            this.gridCol开料单号.Width = 93;
            // 
            // gridCol切割产品重量
            // 
            this.gridCol切割产品重量.Caption = "切割产品重量";
            this.gridCol切割产品重量.FieldName = "切割产品重量";
            this.gridCol切割产品重量.Name = "gridCol切割产品重量";
            this.gridCol切割产品重量.Visible = true;
            this.gridCol切割产品重量.VisibleIndex = 5;
            this.gridCol切割产品重量.Width = 85;
            // 
            // gridCol切割材料重量
            // 
            this.gridCol切割材料重量.Caption = "切割材料重量";
            this.gridCol切割材料重量.FieldName = "切割材料重量";
            this.gridCol切割材料重量.Name = "gridCol切割材料重量";
            this.gridCol切割材料重量.Visible = true;
            this.gridCol切割材料重量.VisibleIndex = 6;
            this.gridCol切割材料重量.Width = 83;
            // 
            // gridCol废料重量
            // 
            this.gridCol废料重量.Caption = "废料重量";
            this.gridCol废料重量.FieldName = "废料重量";
            this.gridCol废料重量.Name = "gridCol废料重量";
            this.gridCol废料重量.Visible = true;
            this.gridCol废料重量.VisibleIndex = 7;
            this.gridCol废料重量.Width = 70;
            // 
            // gridCol实际用料重量
            // 
            this.gridCol实际用料重量.Caption = "实际用料重量";
            this.gridCol实际用料重量.FieldName = "实际用料重量";
            this.gridCol实际用料重量.Name = "gridCol实际用料重量";
            this.gridCol实际用料重量.OptionsColumn.AllowMerge = DevExpress.Utils.DefaultBoolean.False;
            this.gridCol实际用料重量.Visible = true;
            this.gridCol实际用料重量.VisibleIndex = 8;
            this.gridCol实际用料重量.Width = 79;
            // 
            // gridCol废料率
            // 
            this.gridCol废料率.Caption = "废料率";
            this.gridCol废料率.FieldName = "废料率";
            this.gridCol废料率.Name = "gridCol废料率";
            this.gridCol废料率.Visible = true;
            this.gridCol废料率.VisibleIndex = 9;
            // 
            // gridCol材料类型
            // 
            this.gridCol材料类型.Caption = "材料类型";
            this.gridCol材料类型.FieldName = "材料类型";
            this.gridCol材料类型.Name = "gridCol材料类型";
            this.gridCol材料类型.OptionsColumn.AllowEdit = false;
            this.gridCol材料类型.Visible = true;
            this.gridCol材料类型.VisibleIndex = 2;
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
            this.layoutControlGroup1.Size = new System.Drawing.Size(1146, 460);
            this.layoutControlGroup1.Text = "Root";
            this.layoutControlGroup1.TextVisible = false;
            // 
            // layoutControlItem3
            // 
            this.layoutControlItem3.Control = this.gridControl1;
            this.layoutControlItem3.CustomizationFormText = "layoutControlItem3";
            this.layoutControlItem3.Location = new System.Drawing.Point(0, 0);
            this.layoutControlItem3.Name = "layoutControlItem3";
            this.layoutControlItem3.Size = new System.Drawing.Size(1126, 440);
            this.layoutControlItem3.Text = "layoutControlItem3";
            this.layoutControlItem3.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem3.TextToControlDistance = 0;
            this.layoutControlItem3.TextVisible = false;
            // 
            // layoutControlItem4
            // 
            this.layoutControlItem4.CustomizationFormText = "交货日期";
            this.layoutControlItem4.Location = new System.Drawing.Point(145, 0);
            this.layoutControlItem4.Name = "layoutControlItem4";
            this.layoutControlItem4.Size = new System.Drawing.Size(166, 25);
            this.layoutControlItem4.Text = "入库日期";
            this.layoutControlItem4.TextSize = new System.Drawing.Size(48, 14);
            this.layoutControlItem4.TextToControlDistance = 5;
            // 
            // layoutControlItem1
            // 
            this.layoutControlItem1.CustomizationFormText = "交货日期";
            this.layoutControlItem1.Location = new System.Drawing.Point(145, 0);
            this.layoutControlItem1.Name = "layoutControlItem4";
            this.layoutControlItem1.Size = new System.Drawing.Size(166, 25);
            this.layoutControlItem1.Text = "入库日期";
            this.layoutControlItem1.TextSize = new System.Drawing.Size(48, 14);
            this.layoutControlItem1.TextToControlDistance = 5;
            // 
            // dateEdit1
            // 
            this.dateEdit1.EditValue = null;
            this.dateEdit1.Enabled = false;
            this.dateEdit1.Location = new System.Drawing.Point(97, 9);
            this.dateEdit1.Name = "dateEdit1";
            this.dateEdit1.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.dateEdit1.Properties.VistaTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
            this.dateEdit1.Size = new System.Drawing.Size(100, 21);
            this.dateEdit1.TabIndex = 6;
            // 
            // dateEdit2
            // 
            this.dateEdit2.EditValue = null;
            this.dateEdit2.Enabled = false;
            this.dateEdit2.Location = new System.Drawing.Point(233, 9);
            this.dateEdit2.Name = "dateEdit2";
            this.dateEdit2.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.dateEdit2.Properties.VistaTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
            this.dateEdit2.Size = new System.Drawing.Size(100, 21);
            this.dateEdit2.TabIndex = 7;
            // 
            // labelControl1
            // 
            this.labelControl1.Location = new System.Drawing.Point(21, 12);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(48, 14);
            this.labelControl1.TabIndex = 8;
            this.labelControl1.Text = "日期区域";
            // 
            // lookUpEdit材料类型
            // 
            this.lookUpEdit材料类型.Location = new System.Drawing.Point(470, 9);
            this.lookUpEdit材料类型.Name = "lookUpEdit材料类型";
            this.lookUpEdit材料类型.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.lookUpEdit材料类型.Properties.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("iID", "材料类型")});
            this.lookUpEdit材料类型.Properties.DisplayMember = "iID";
            this.lookUpEdit材料类型.Properties.NullText = "";
            this.lookUpEdit材料类型.Properties.ValueMember = "iID";
            this.lookUpEdit材料类型.Size = new System.Drawing.Size(100, 21);
            this.lookUpEdit材料类型.TabIndex = 15;
            this.lookUpEdit材料类型.EditValueChanged += new System.EventHandler(this.lookUpEdit材料类型_EditValueChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(389, 12);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(55, 14);
            this.label3.TabIndex = 14;
            this.label3.Text = "材料类型";
            // 
            // Frm汇总表
            // 
            this.Appearance.BackColor = System.Drawing.SystemColors.Control;
            this.Appearance.Options.UseBackColor = true;
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1144, 489);
            this.Controls.Add(this.lookUpEdit材料类型);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.labelControl1);
            this.Controls.Add(this.dateEdit2);
            this.Controls.Add(this.dateEdit1);
            this.Controls.Add(this.layoutControl1);
            this.Name = "Frm汇总表";
            this.Text = "现存量";
            this.Load += new System.EventHandler(this.FrmWorkPerson_Load);
            this.Controls.SetChildIndex(this.layoutControl1, 0);
            this.Controls.SetChildIndex(this.dateEdit1, 0);
            this.Controls.SetChildIndex(this.dateEdit2, 0);
            this.Controls.SetChildIndex(this.labelControl1, 0);
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
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dateEdit1.Properties.VistaTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dateEdit1.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dateEdit2.Properties.VistaTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dateEdit2.Properties)).EndInit();
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
        private DevExpress.XtraGrid.Columns.GridColumn gridCol实际用料重量;
        private DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit ItemLookUpEditWorkplant;
        private DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit ItemLookUpEditPerState;
        private DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit ItemLookUpEditType;
        private DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit ItemLookUpEditPost;
        private DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit ItemLookUpEditLevels;
        private DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit ItemLookUpEditPerType;
        private DevExpress.XtraGrid.Columns.GridColumn gridCol合金属性;
        private DevExpress.XtraGrid.Columns.GridColumn gridCol切割产品重量;
        private DevExpress.XtraGrid.Columns.GridColumn gridCol切割材料重量;
        private DevExpress.XtraGrid.Columns.GridColumn gridCol废料重量;
        private DevExpress.XtraGrid.Columns.GridColumn gridCol开料单号;
        private DevExpress.XtraGrid.Columns.GridColumn gridCol日期;
        private DevExpress.XtraGrid.Columns.GridColumn gridCol废料率;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem4;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem1;
        private DevExpress.XtraEditors.DateEdit dateEdit1;
        private DevExpress.XtraEditors.DateEdit dateEdit2;
        private DevExpress.XtraEditors.LabelControl labelControl1;
        private DevExpress.XtraEditors.LookUpEdit lookUpEdit材料类型;
        private System.Windows.Forms.Label label3;
        private DevExpress.XtraGrid.Columns.GridColumn gridCol材料类型;
    }
}