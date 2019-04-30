namespace UFIDA.U8.UAP.CustomApp.ControlForm
{
    partial class PlatingProcess
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
            this.btnRefresh = new System.Windows.Forms.ToolStripMenuItem();
            this.btnAddRow = new System.Windows.Forms.ToolStripMenuItem();
            this.btnDel = new System.Windows.Forms.ToolStripMenuItem();
            this.btnSave = new System.Windows.Forms.ToolStripMenuItem();
            this.btnExport = new System.Windows.Forms.ToolStripMenuItem();
            this.gridControl1 = new DevExpress.XtraGrid.GridControl();
            this.gridView1 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.gridColRemark = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColiState = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColCreateUid = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColCreateDate = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColItemCode = new DevExpress.XtraGrid.Columns.GridColumn();
            this.ItemLookUpEditItemNo = new DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit();
            this.gridColProcessCode = new DevExpress.XtraGrid.Columns.GridColumn();
            this.ItemLookUpEditWarehouse = new DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit();
            this.gridColMaterial = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColXRayFile = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColFinishingSpec = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColCommonPltSpec = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColColor = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColGrade = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColUnitSurfaceArea = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColUnitWeight = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColNote1 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColNote2 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColNote3 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColUpdatedDate = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColUpdatedBy = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColiID = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColDept = new DevExpress.XtraGrid.Columns.GridColumn();
            this.ItemLookUpEditInvDept = new DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit();
            this.panel1 = new System.Windows.Forms.Panel();
            this.menuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ItemLookUpEditItemNo)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ItemLookUpEditWarehouse)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ItemLookUpEditInvDept)).BeginInit();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btnRefresh,
            this.btnAddRow,
            this.btnDel,
            this.btnSave,
            this.btnExport});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(945, 25);
            this.menuStrip1.TabIndex = 172;
            this.menuStrip1.Text = "menuStrip";
            // 
            // btnRefresh
            // 
            this.btnRefresh.Name = "btnRefresh";
            this.btnRefresh.Size = new System.Drawing.Size(64, 21);
            this.btnRefresh.Text = "Refresh";
            this.btnRefresh.Click += new System.EventHandler(this.btnRefresh_Click);
            // 
            // btnAddRow
            // 
            this.btnAddRow.Name = "btnAddRow";
            this.btnAddRow.Size = new System.Drawing.Size(73, 21);
            this.btnAddRow.Text = "Add Row";
            this.btnAddRow.Click += new System.EventHandler(this.btnAddRow_Click_1);
            // 
            // btnDel
            // 
            this.btnDel.Name = "btnDel";
            this.btnDel.Size = new System.Drawing.Size(57, 21);
            this.btnDel.Text = "Delete";
            this.btnDel.Click += new System.EventHandler(this.btnDel_Click);
            // 
            // btnSave
            // 
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(47, 21);
            this.btnSave.Text = "Save";
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // btnExport
            // 
            this.btnExport.Name = "btnExport";
            this.btnExport.Size = new System.Drawing.Size(58, 21);
            this.btnExport.Text = "Export";
            this.btnExport.Click += new System.EventHandler(this.btnExcel_Click);
            // 
            // gridControl1
            // 
            this.gridControl1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.gridControl1.Location = new System.Drawing.Point(3, 3);
            this.gridControl1.LookAndFeel.SkinName = "Office 2010 Blue";
            this.gridControl1.MainView = this.gridView1;
            this.gridControl1.Name = "gridControl1";
            this.gridControl1.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.ItemLookUpEditItemNo,
            this.ItemLookUpEditWarehouse,
            this.ItemLookUpEditInvDept});
            this.gridControl1.Size = new System.Drawing.Size(939, 423);
            this.gridControl1.TabIndex = 191;
            this.gridControl1.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView1});
            // 
            // gridView1
            // 
            this.gridView1.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.gridColRemark,
            this.gridColiState,
            this.gridColCreateUid,
            this.gridColCreateDate,
            this.gridColItemCode,
            this.gridColProcessCode,
            this.gridColMaterial,
            this.gridColXRayFile,
            this.gridColFinishingSpec,
            this.gridColCommonPltSpec,
            this.gridColColor,
            this.gridColGrade,
            this.gridColUnitSurfaceArea,
            this.gridColUnitWeight,
            this.gridColNote1,
            this.gridColNote2,
            this.gridColNote3,
            this.gridColUpdatedDate,
            this.gridColUpdatedBy,
            this.gridColiID,
            this.gridColDept});
            this.gridView1.GridControl = this.gridControl1;
            this.gridView1.IndicatorWidth = 40;
            this.gridView1.Name = "gridView1";
            this.gridView1.OptionsBehavior.AllowDeleteRows = DevExpress.Utils.DefaultBoolean.True;
            this.gridView1.OptionsBehavior.EditorShowMode = DevExpress.Utils.EditorShowMode.MouseDown;
            this.gridView1.OptionsCustomization.AllowGroup = false;
            this.gridView1.OptionsCustomization.AllowQuickHideColumns = false;
            this.gridView1.OptionsCustomization.AllowSort = false;
            this.gridView1.OptionsNavigation.EnterMoveNextColumn = true;
            this.gridView1.OptionsPrint.AutoWidth = false;
            this.gridView1.OptionsView.ColumnAutoWidth = false;
            this.gridView1.OptionsView.ShowFooter = true;
            this.gridView1.OptionsView.ShowGroupPanel = false;
            this.gridView1.CustomDrawRowIndicator += new DevExpress.XtraGrid.Views.Grid.RowIndicatorCustomDrawEventHandler(this.gridView1_CustomDrawRowIndicator);
            this.gridView1.CellValueChanged += new DevExpress.XtraGrid.Views.Base.CellValueChangedEventHandler(this.gridView1_CellValueChanged);
            // 
            // gridColRemark
            // 
            this.gridColRemark.Caption = "Remark";
            this.gridColRemark.FieldName = "Remark";
            this.gridColRemark.Name = "gridColRemark";
            this.gridColRemark.OptionsColumn.AllowSort = DevExpress.Utils.DefaultBoolean.False;
            this.gridColRemark.Visible = true;
            this.gridColRemark.VisibleIndex = 16;
            this.gridColRemark.Width = 276;
            // 
            // gridColiState
            // 
            this.gridColiState.Caption = "iState";
            this.gridColiState.FieldName = "iState";
            this.gridColiState.Name = "gridColiState";
            this.gridColiState.OptionsColumn.AllowEdit = false;
            this.gridColiState.OptionsColumn.AllowSort = DevExpress.Utils.DefaultBoolean.False;
            // 
            // gridColCreateUid
            // 
            this.gridColCreateUid.Caption = "Creater";
            this.gridColCreateUid.FieldName = "CreaterUid";
            this.gridColCreateUid.Name = "gridColCreateUid";
            this.gridColCreateUid.OptionsColumn.AllowEdit = false;
            this.gridColCreateUid.OptionsColumn.AllowSort = DevExpress.Utils.DefaultBoolean.False;
            // 
            // gridColCreateDate
            // 
            this.gridColCreateDate.Caption = "CreateDate";
            this.gridColCreateDate.FieldName = "CreaterDate";
            this.gridColCreateDate.Name = "gridColCreateDate";
            this.gridColCreateDate.OptionsColumn.AllowEdit = false;
            this.gridColCreateDate.OptionsColumn.AllowSort = DevExpress.Utils.DefaultBoolean.False;
            this.gridColCreateDate.Width = 121;
            // 
            // gridColItemCode
            // 
            this.gridColItemCode.Caption = "Item Code";
            this.gridColItemCode.ColumnEdit = this.ItemLookUpEditItemNo;
            this.gridColItemCode.FieldName = "ItemCode";
            this.gridColItemCode.Name = "gridColItemCode";
            this.gridColItemCode.Visible = true;
            this.gridColItemCode.VisibleIndex = 0;
            this.gridColItemCode.Width = 85;
            // 
            // ItemLookUpEditItemNo
            // 
            this.ItemLookUpEditItemNo.AutoHeight = false;
            this.ItemLookUpEditItemNo.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.ItemLookUpEditItemNo.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("cInvCode", "Item NO"),
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("cInvName", 60, "Description")});
            this.ItemLookUpEditItemNo.DisplayMember = "cInvCode";
            this.ItemLookUpEditItemNo.Name = "ItemLookUpEditItemNo";
            this.ItemLookUpEditItemNo.NullText = "";
            this.ItemLookUpEditItemNo.PopupWidth = 400;
            this.ItemLookUpEditItemNo.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.Standard;
            this.ItemLookUpEditItemNo.ValueMember = "cInvCode";
            // 
            // gridColProcessCode
            // 
            this.gridColProcessCode.Caption = "Process Code";
            this.gridColProcessCode.ColumnEdit = this.ItemLookUpEditWarehouse;
            this.gridColProcessCode.FieldName = "ProcessCode";
            this.gridColProcessCode.Name = "gridColProcessCode";
            this.gridColProcessCode.Visible = true;
            this.gridColProcessCode.VisibleIndex = 2;
            this.gridColProcessCode.Width = 98;
            // 
            // ItemLookUpEditWarehouse
            // 
            this.ItemLookUpEditWarehouse.AutoHeight = false;
            this.ItemLookUpEditWarehouse.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.ItemLookUpEditWarehouse.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("cWhCode", "Process NO")});
            this.ItemLookUpEditWarehouse.DisplayMember = "cWhCode";
            this.ItemLookUpEditWarehouse.Name = "ItemLookUpEditWarehouse";
            this.ItemLookUpEditWarehouse.NullText = "";
            this.ItemLookUpEditWarehouse.ValueMember = "cWhCode";
            // 
            // gridColMaterial
            // 
            this.gridColMaterial.Caption = "Material";
            this.gridColMaterial.FieldName = "Material";
            this.gridColMaterial.Name = "gridColMaterial";
            this.gridColMaterial.Visible = true;
            this.gridColMaterial.VisibleIndex = 3;
            // 
            // gridColXRayFile
            // 
            this.gridColXRayFile.Caption = "X Ray File";
            this.gridColXRayFile.FieldName = "XRayFile";
            this.gridColXRayFile.Name = "gridColXRayFile";
            this.gridColXRayFile.Visible = true;
            this.gridColXRayFile.VisibleIndex = 4;
            // 
            // gridColFinishingSpec
            // 
            this.gridColFinishingSpec.Caption = "Finishing Spec";
            this.gridColFinishingSpec.FieldName = "FinishingSpec";
            this.gridColFinishingSpec.Name = "gridColFinishingSpec";
            this.gridColFinishingSpec.Visible = true;
            this.gridColFinishingSpec.VisibleIndex = 5;
            this.gridColFinishingSpec.Width = 100;
            // 
            // gridColCommonPltSpec
            // 
            this.gridColCommonPltSpec.Caption = "Common Plt Spec";
            this.gridColCommonPltSpec.FieldName = "CommonPltSpec";
            this.gridColCommonPltSpec.Name = "gridColCommonPltSpec";
            this.gridColCommonPltSpec.Visible = true;
            this.gridColCommonPltSpec.VisibleIndex = 6;
            this.gridColCommonPltSpec.Width = 149;
            // 
            // gridColColor
            // 
            this.gridColColor.Caption = "Color";
            this.gridColColor.FieldName = "Color";
            this.gridColColor.Name = "gridColColor";
            this.gridColColor.Visible = true;
            this.gridColColor.VisibleIndex = 7;
            // 
            // gridColGrade
            // 
            this.gridColGrade.Caption = "Grade";
            this.gridColGrade.FieldName = "Grade";
            this.gridColGrade.Name = "gridColGrade";
            this.gridColGrade.Visible = true;
            this.gridColGrade.VisibleIndex = 8;
            // 
            // gridColUnitSurfaceArea
            // 
            this.gridColUnitSurfaceArea.Caption = "Unit Surface Area";
            this.gridColUnitSurfaceArea.FieldName = "UnitSurfaceArea";
            this.gridColUnitSurfaceArea.Name = "gridColUnitSurfaceArea";
            this.gridColUnitSurfaceArea.Visible = true;
            this.gridColUnitSurfaceArea.VisibleIndex = 9;
            // 
            // gridColUnitWeight
            // 
            this.gridColUnitWeight.Caption = "Unit Weight";
            this.gridColUnitWeight.FieldName = "UnitWeight";
            this.gridColUnitWeight.Name = "gridColUnitWeight";
            this.gridColUnitWeight.Visible = true;
            this.gridColUnitWeight.VisibleIndex = 10;
            this.gridColUnitWeight.Width = 114;
            // 
            // gridColNote1
            // 
            this.gridColNote1.Caption = "Note1";
            this.gridColNote1.FieldName = "Note1";
            this.gridColNote1.Name = "gridColNote1";
            this.gridColNote1.Visible = true;
            this.gridColNote1.VisibleIndex = 11;
            // 
            // gridColNote2
            // 
            this.gridColNote2.Caption = "Note2";
            this.gridColNote2.FieldName = "Note2";
            this.gridColNote2.Name = "gridColNote2";
            this.gridColNote2.Visible = true;
            this.gridColNote2.VisibleIndex = 12;
            // 
            // gridColNote3
            // 
            this.gridColNote3.Caption = "Note3";
            this.gridColNote3.FieldName = "Note3";
            this.gridColNote3.Name = "gridColNote3";
            this.gridColNote3.Visible = true;
            this.gridColNote3.VisibleIndex = 13;
            // 
            // gridColUpdatedDate
            // 
            this.gridColUpdatedDate.Caption = "UpdatedDate";
            this.gridColUpdatedDate.FieldName = "UpdatedDate";
            this.gridColUpdatedDate.Name = "gridColUpdatedDate";
            this.gridColUpdatedDate.OptionsColumn.AllowEdit = false;
            this.gridColUpdatedDate.Visible = true;
            this.gridColUpdatedDate.VisibleIndex = 14;
            this.gridColUpdatedDate.Width = 101;
            // 
            // gridColUpdatedBy
            // 
            this.gridColUpdatedBy.Caption = "UpdatedBy";
            this.gridColUpdatedBy.FieldName = "UpdatedBy";
            this.gridColUpdatedBy.Name = "gridColUpdatedBy";
            this.gridColUpdatedBy.OptionsColumn.AllowEdit = false;
            this.gridColUpdatedBy.Visible = true;
            this.gridColUpdatedBy.VisibleIndex = 15;
            this.gridColUpdatedBy.Width = 107;
            // 
            // gridColiID
            // 
            this.gridColiID.Caption = "iID";
            this.gridColiID.FieldName = "iID";
            this.gridColiID.Name = "gridColiID";
            this.gridColiID.OptionsColumn.AllowEdit = false;
            // 
            // gridColDept
            // 
            this.gridColDept.Caption = "Dept";
            this.gridColDept.ColumnEdit = this.ItemLookUpEditInvDept;
            this.gridColDept.FieldName = "ItemCode";
            this.gridColDept.Name = "gridColDept";
            this.gridColDept.OptionsColumn.AllowEdit = false;
            this.gridColDept.Visible = true;
            this.gridColDept.VisibleIndex = 1;
            // 
            // ItemLookUpEditInvDept
            // 
            this.ItemLookUpEditInvDept.AutoHeight = false;
            this.ItemLookUpEditInvDept.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.ItemLookUpEditInvDept.DisplayMember = "cDepName";
            this.ItemLookUpEditInvDept.Name = "ItemLookUpEditInvDept";
            this.ItemLookUpEditInvDept.NullText = "";
            this.ItemLookUpEditInvDept.ValueMember = "cInvCode";
            // 
            // panel1
            // 
            this.panel1.AutoScroll = true;
            this.panel1.Controls.Add(this.gridControl1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 25);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(945, 431);
            this.panel1.TabIndex = 173;
            // 
            // PlatingProcess
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.menuStrip1);
            this.Name = "PlatingProcess";
            this.Size = new System.Drawing.Size(945, 456);
            this.Load += new System.EventHandler(this.Frm_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ItemLookUpEditItemNo)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ItemLookUpEditWarehouse)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ItemLookUpEditInvDept)).EndInit();
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem btnSave;
        private DevExpress.XtraGrid.GridControl gridControl1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.ToolStripMenuItem btnRefresh;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView1;
        private DevExpress.XtraGrid.Columns.GridColumn gridColCreateUid;
        private DevExpress.XtraGrid.Columns.GridColumn gridColCreateDate;
        private DevExpress.XtraGrid.Columns.GridColumn gridColRemark;
        private System.Windows.Forms.ToolStripMenuItem btnExport;
        private DevExpress.XtraGrid.Columns.GridColumn gridColiState;
        private DevExpress.XtraGrid.Columns.GridColumn gridColItemCode;
        private DevExpress.XtraGrid.Columns.GridColumn gridColProcessCode;
        private DevExpress.XtraGrid.Columns.GridColumn gridColMaterial;
        private DevExpress.XtraGrid.Columns.GridColumn gridColXRayFile;
        private DevExpress.XtraGrid.Columns.GridColumn gridColFinishingSpec;
        private DevExpress.XtraGrid.Columns.GridColumn gridColCommonPltSpec;
        private DevExpress.XtraGrid.Columns.GridColumn gridColGrade;
        private DevExpress.XtraGrid.Columns.GridColumn gridColUnitSurfaceArea;
        private DevExpress.XtraGrid.Columns.GridColumn gridColUnitWeight;
        private DevExpress.XtraGrid.Columns.GridColumn gridColNote1;
        private DevExpress.XtraGrid.Columns.GridColumn gridColNote2;
        private DevExpress.XtraGrid.Columns.GridColumn gridColNote3;
        private DevExpress.XtraGrid.Columns.GridColumn gridColUpdatedDate;
        private DevExpress.XtraGrid.Columns.GridColumn gridColUpdatedBy;
        private DevExpress.XtraGrid.Columns.GridColumn gridColiID;
        private System.Windows.Forms.ToolStripMenuItem btnAddRow;
        private System.Windows.Forms.ToolStripMenuItem btnDel;
        private DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit ItemLookUpEditItemNo;
        private DevExpress.XtraGrid.Columns.GridColumn gridColColor;
        private DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit ItemLookUpEditWarehouse;
        private DevExpress.XtraGrid.Columns.GridColumn gridColDept;
        private DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit ItemLookUpEditInvDept;
    }
}
