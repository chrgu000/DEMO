namespace 销售
{
    partial class Frm人员调整单列表
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
            this.gridColiID = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColiSave = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColiCode = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColPersonCode = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColPersonName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColRemark = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColaAdjDeptID = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColaAdjDutyID = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColaAdjDCCode = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColaAdjType = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColaAdjCarStick = new DevExpress.XtraGrid.Columns.GridColumn();
            this.ItemLookUpEditSexID = new DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit();
            this.ItemLookUpEditDept = new DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit();
            this.ItemLookUpEditType = new DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit();
            this.ItemCheckEditsalesMan = new DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit();
            this.ItemDateEditBeginDate = new DevExpress.XtraEditors.Repository.RepositoryItemDateEdit();
            this.ItemDateEditEndDate = new DevExpress.XtraEditors.Repository.RepositoryItemDateEdit();
            this.layoutControlGroup1 = new DevExpress.XtraLayout.LayoutControlGroup();
            this.layoutControlItem3 = new DevExpress.XtraLayout.LayoutControlItem();
            ((System.ComponentModel.ISupportInitialize)(this.dsPrint)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dsForm)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtSel)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControl1)).BeginInit();
            this.layoutControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ItemLookUpEditSexID)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ItemLookUpEditDept)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ItemLookUpEditType)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ItemCheckEditsalesMan)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ItemDateEditBeginDate)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ItemDateEditBeginDate.VistaTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ItemDateEditEndDate)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ItemDateEditEndDate.VistaTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem3)).BeginInit();
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
            this.layoutControl1.Size = new System.Drawing.Size(1113, 440);
            this.layoutControl1.TabIndex = 5;
            this.layoutControl1.Text = "layoutControl1";
            // 
            // gridControl1
            // 
            this.gridControl1.Location = new System.Drawing.Point(12, 12);
            this.gridControl1.MainView = this.gridView1;
            this.gridControl1.Name = "gridControl1";
            this.gridControl1.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.ItemLookUpEditSexID,
            this.ItemLookUpEditDept,
            this.ItemLookUpEditType,
            this.ItemCheckEditsalesMan,
            this.ItemDateEditBeginDate,
            this.ItemDateEditEndDate});
            this.gridControl1.Size = new System.Drawing.Size(1089, 416);
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
            this.gridColiID,
            this.gridColiSave,
            this.gridColiCode,
            this.gridColPersonCode,
            this.gridColPersonName,
            this.gridColRemark,
            this.gridColaAdjDeptID,
            this.gridColaAdjDutyID,
            this.gridColaAdjDCCode,
            this.gridColaAdjType,
            this.gridColaAdjCarStick});
            this.gridView1.GridControl = this.gridControl1;
            this.gridView1.IndicatorWidth = 40;
            this.gridView1.Name = "gridView1";
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
            this.gridView1.RowClick += new DevExpress.XtraGrid.Views.Grid.RowClickEventHandler(this.gridView1_RowClick);
            this.gridView1.CustomDrawRowIndicator += new DevExpress.XtraGrid.Views.Grid.RowIndicatorCustomDrawEventHandler(this.gridView1_CustomDrawRowIndicator);
            // 
            // gridColiID
            // 
            this.gridColiID.Caption = "iID";
            this.gridColiID.FieldName = "iID";
            this.gridColiID.Name = "gridColiID";
            // 
            // gridColiSave
            // 
            this.gridColiSave.Caption = "编辑状态";
            this.gridColiSave.FieldName = "iSave";
            this.gridColiSave.Name = "gridColiSave";
            // 
            // gridColiCode
            // 
            this.gridColiCode.Caption = "单据号";
            this.gridColiCode.FieldName = "iCode";
            this.gridColiCode.Name = "gridColiCode";
            this.gridColiCode.Visible = true;
            this.gridColiCode.VisibleIndex = 0;
            // 
            // gridColPersonCode
            // 
            this.gridColPersonCode.Caption = "人员编码";
            this.gridColPersonCode.FieldName = "PersonCode";
            this.gridColPersonCode.Name = "gridColPersonCode";
            this.gridColPersonCode.Visible = true;
            this.gridColPersonCode.VisibleIndex = 1;
            this.gridColPersonCode.Width = 92;
            // 
            // gridColPersonName
            // 
            this.gridColPersonName.Caption = "人员名称";
            this.gridColPersonName.FieldName = "PersonName";
            this.gridColPersonName.Name = "gridColPersonName";
            this.gridColPersonName.Visible = true;
            this.gridColPersonName.VisibleIndex = 2;
            this.gridColPersonName.Width = 89;
            // 
            // gridColRemark
            // 
            this.gridColRemark.Caption = "备注";
            this.gridColRemark.FieldName = "Remark";
            this.gridColRemark.Name = "gridColRemark";
            this.gridColRemark.Visible = true;
            this.gridColRemark.VisibleIndex = 8;
            // 
            // gridColaAdjDeptID
            // 
            this.gridColaAdjDeptID.Caption = "部门";
            this.gridColaAdjDeptID.FieldName = "aAdjDeptID";
            this.gridColaAdjDeptID.Name = "gridColaAdjDeptID";
            this.gridColaAdjDeptID.Visible = true;
            this.gridColaAdjDeptID.VisibleIndex = 3;
            // 
            // gridColaAdjDutyID
            // 
            this.gridColaAdjDutyID.Caption = "职务";
            this.gridColaAdjDutyID.FieldName = "aAdjDutyID";
            this.gridColaAdjDutyID.Name = "gridColaAdjDutyID";
            this.gridColaAdjDutyID.Visible = true;
            this.gridColaAdjDutyID.VisibleIndex = 4;
            // 
            // gridColaAdjDCCode
            // 
            this.gridColaAdjDCCode.Caption = "区域";
            this.gridColaAdjDCCode.FieldName = "aAdjDCCode";
            this.gridColaAdjDCCode.Name = "gridColaAdjDCCode";
            this.gridColaAdjDCCode.Visible = true;
            this.gridColaAdjDCCode.VisibleIndex = 5;
            // 
            // gridColaAdjType
            // 
            this.gridColaAdjType.Caption = "类别";
            this.gridColaAdjType.FieldName = "aAdjType";
            this.gridColaAdjType.Name = "gridColaAdjType";
            this.gridColaAdjType.Visible = true;
            this.gridColaAdjType.VisibleIndex = 6;
            // 
            // gridColaAdjCarStick
            // 
            this.gridColaAdjCarStick.Caption = "车贴";
            this.gridColaAdjCarStick.FieldName = "aAdjCarStick";
            this.gridColaAdjCarStick.Name = "gridColaAdjCarStick";
            this.gridColaAdjCarStick.Visible = true;
            this.gridColaAdjCarStick.VisibleIndex = 7;
            // 
            // ItemLookUpEditSexID
            // 
            this.ItemLookUpEditSexID.AutoHeight = false;
            this.ItemLookUpEditSexID.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.ItemLookUpEditSexID.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("iID", "编号"),
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("iText", "类型")});
            this.ItemLookUpEditSexID.DisplayMember = "iText";
            this.ItemLookUpEditSexID.Name = "ItemLookUpEditSexID";
            this.ItemLookUpEditSexID.NullText = "";
            this.ItemLookUpEditSexID.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.Standard;
            this.ItemLookUpEditSexID.ValueMember = "iID";
            // 
            // ItemLookUpEditDept
            // 
            this.ItemLookUpEditDept.AutoHeight = false;
            this.ItemLookUpEditDept.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.ItemLookUpEditDept.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("iID", "序号"),
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("iText", "状态")});
            this.ItemLookUpEditDept.DisplayMember = "iText";
            this.ItemLookUpEditDept.Name = "ItemLookUpEditDept";
            this.ItemLookUpEditDept.NullText = "";
            this.ItemLookUpEditDept.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.Standard;
            this.ItemLookUpEditDept.ValueMember = "iID";
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
            this.ItemLookUpEditType.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.Standard;
            this.ItemLookUpEditType.ValueMember = "iID";
            // 
            // ItemCheckEditsalesMan
            // 
            this.ItemCheckEditsalesMan.AutoHeight = false;
            this.ItemCheckEditsalesMan.Name = "ItemCheckEditsalesMan";
            this.ItemCheckEditsalesMan.CheckedChanged += new System.EventHandler(this.ItemCheckEditsalesMan_CheckedChanged);
            // 
            // ItemDateEditBeginDate
            // 
            this.ItemDateEditBeginDate.AutoHeight = false;
            this.ItemDateEditBeginDate.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.ItemDateEditBeginDate.Name = "ItemDateEditBeginDate";
            this.ItemDateEditBeginDate.VistaTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
            // 
            // ItemDateEditEndDate
            // 
            this.ItemDateEditEndDate.AutoHeight = false;
            this.ItemDateEditEndDate.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.ItemDateEditEndDate.Name = "ItemDateEditEndDate";
            this.ItemDateEditEndDate.VistaTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
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
            this.layoutControlGroup1.Size = new System.Drawing.Size(1113, 440);
            this.layoutControlGroup1.Text = "Root";
            this.layoutControlGroup1.TextVisible = false;
            // 
            // layoutControlItem3
            // 
            this.layoutControlItem3.Control = this.gridControl1;
            this.layoutControlItem3.CustomizationFormText = "layoutControlItem3";
            this.layoutControlItem3.Location = new System.Drawing.Point(0, 0);
            this.layoutControlItem3.Name = "layoutControlItem3";
            this.layoutControlItem3.Size = new System.Drawing.Size(1093, 420);
            this.layoutControlItem3.Text = "layoutControlItem3";
            this.layoutControlItem3.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem3.TextToControlDistance = 0;
            this.layoutControlItem3.TextVisible = false;
            // 
            // Frm人员调整单列表
            // 
            this.Appearance.BackColor = System.Drawing.SystemColors.Control;
            this.Appearance.Options.UseBackColor = true;
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1111, 469);
            this.Controls.Add(this.layoutControl1);
            this.Name = "Frm人员调整单列表";
            this.Text = "人员调整单列表";
            this.Load += new System.EventHandler(this.Frm人员调整单列表_Load);
            this.Controls.SetChildIndex(this.layoutControl1, 0);
            ((System.ComponentModel.ISupportInitialize)(this.dsPrint)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dsForm)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtSel)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControl1)).EndInit();
            this.layoutControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ItemLookUpEditSexID)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ItemLookUpEditDept)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ItemLookUpEditType)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ItemCheckEditsalesMan)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ItemDateEditBeginDate.VistaTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ItemDateEditBeginDate)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ItemDateEditEndDate.VistaTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ItemDateEditEndDate)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem3)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraLayout.LayoutControl layoutControl1;
        private DevExpress.XtraGrid.GridControl gridControl1;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView1;
        private DevExpress.XtraLayout.LayoutControlGroup layoutControlGroup1;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem3;
        private DevExpress.XtraGrid.Columns.GridColumn gridColPersonCode;
        private DevExpress.XtraGrid.Columns.GridColumn gridColPersonName;
        private DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit ItemLookUpEditSexID;
        private DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit ItemLookUpEditDept;
        private DevExpress.XtraGrid.Columns.GridColumn gridColiSave;
        private DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit ItemLookUpEditType;
        private DevExpress.XtraGrid.Columns.GridColumn gridColRemark;
        private DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit ItemCheckEditsalesMan;
        private DevExpress.XtraEditors.Repository.RepositoryItemDateEdit ItemDateEditBeginDate;
        private DevExpress.XtraEditors.Repository.RepositoryItemDateEdit ItemDateEditEndDate;
        private DevExpress.XtraGrid.Columns.GridColumn gridColiID;
        private DevExpress.XtraGrid.Columns.GridColumn gridColaAdjDeptID;
        private DevExpress.XtraGrid.Columns.GridColumn gridColaAdjDutyID;
        private DevExpress.XtraGrid.Columns.GridColumn gridColaAdjDCCode;
        private DevExpress.XtraGrid.Columns.GridColumn gridColaAdjType;
        private DevExpress.XtraGrid.Columns.GridColumn gridColaAdjCarStick;
        private DevExpress.XtraGrid.Columns.GridColumn gridColiCode;
    }
}