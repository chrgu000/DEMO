﻿namespace UFIDA.U8.UAP.CustomApp.ControlForm
{
    partial class Defects
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
            this.btnEdit = new System.Windows.Forms.ToolStripMenuItem();
            this.btnSave = new System.Windows.Forms.ToolStripMenuItem();
            this.btnDelete = new System.Windows.Forms.ToolStripMenuItem();
            this.btnExport = new System.Windows.Forms.ToolStripMenuItem();
            this.gridControl1 = new DevExpress.XtraGrid.GridControl();
            this.gridView1 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.gridColCustomerCode = new DevExpress.XtraGrid.Columns.GridColumn();
            this.ItemLookUpEditcCusCode = new DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit();
            this.gridColCustomerName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.ItemLookUpEditcCusName = new DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit();
            this.gridColDefectCode = new DevExpress.XtraGrid.Columns.GridColumn();
            this.ItemLookUpEditDefectCode = new DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit();
            this.gridColDefectName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.ItemLookUpEditDefectName = new DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit();
            this.gridColiID = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColsStatus = new DevExpress.XtraGrid.Columns.GridColumn();
            this.panel1 = new System.Windows.Forms.Panel();
            this.menuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ItemLookUpEditcCusCode)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ItemLookUpEditcCusName)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ItemLookUpEditDefectCode)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ItemLookUpEditDefectName)).BeginInit();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btnRefresh,
            this.btnAddRow,
            this.btnEdit,
            this.btnSave,
            this.btnDelete,
            this.btnExport});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Padding = new System.Windows.Forms.Padding(8, 2, 0, 2);
            this.menuStrip1.Size = new System.Drawing.Size(1259, 24);
            this.menuStrip1.TabIndex = 172;
            this.menuStrip1.Text = "menuStrip";
            // 
            // btnRefresh
            // 
            this.btnRefresh.BackColor = System.Drawing.SystemColors.Control;
            this.btnRefresh.Name = "btnRefresh";
            this.btnRefresh.Size = new System.Drawing.Size(75, 20);
            this.btnRefresh.Text = "Refresh";
            this.btnRefresh.Click += new System.EventHandler(this.btnRefresh_Click);
            // 
            // btnAddRow
            // 
            this.btnAddRow.Name = "btnAddRow";
            this.btnAddRow.Size = new System.Drawing.Size(75, 20);
            this.btnAddRow.Text = "Add Row";
            this.btnAddRow.Click += new System.EventHandler(this.btnAddRow_Click_1);
            // 
            // btnEdit
            // 
            this.btnEdit.Name = "btnEdit";
            this.btnEdit.Size = new System.Drawing.Size(51, 20);
            this.btnEdit.Text = "Edit";
            this.btnEdit.Click += new System.EventHandler(this.btnEdit_Click);
            // 
            // btnSave
            // 
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(51, 20);
            this.btnSave.Text = "Save";
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // btnDelete
            // 
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(67, 20);
            this.btnDelete.Text = "Delete";
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // btnExport
            // 
            this.btnExport.Name = "btnExport";
            this.btnExport.Size = new System.Drawing.Size(67, 20);
            this.btnExport.Text = "Export";
            this.btnExport.Click += new System.EventHandler(this.btnExport_Click);
            // 
            // gridControl1
            // 
            this.gridControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridControl1.EmbeddedNavigator.Margin = new System.Windows.Forms.Padding(4);
            this.gridControl1.Location = new System.Drawing.Point(0, 0);
            this.gridControl1.LookAndFeel.SkinName = "Office 2010 Blue";
            this.gridControl1.MainView = this.gridView1;
            this.gridControl1.Margin = new System.Windows.Forms.Padding(4);
            this.gridControl1.Name = "gridControl1";
            this.gridControl1.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.ItemLookUpEditcCusCode,
            this.ItemLookUpEditcCusName,
            this.ItemLookUpEditDefectName,
            this.ItemLookUpEditDefectCode});
            this.gridControl1.Size = new System.Drawing.Size(1259, 546);
            this.gridControl1.TabIndex = 191;
            this.gridControl1.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView1});
            // 
            // gridView1
            // 
            this.gridView1.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.gridColCustomerCode,
            this.gridColCustomerName,
            this.gridColDefectCode,
            this.gridColDefectName,
            this.gridColiID,
            this.gridColsStatus});
            this.gridView1.GridControl = this.gridControl1;
            this.gridView1.IndicatorWidth = 40;
            this.gridView1.Name = "gridView1";
            this.gridView1.OptionsBehavior.AllowDeleteRows = DevExpress.Utils.DefaultBoolean.True;
            this.gridView1.OptionsBehavior.EditorShowMode = DevExpress.Utils.EditorShowMode.MouseDown;
            this.gridView1.OptionsCustomization.AllowGroup = false;
            this.gridView1.OptionsCustomization.AllowQuickHideColumns = false;
            this.gridView1.OptionsNavigation.EnterMoveNextColumn = true;
            this.gridView1.OptionsPrint.AutoWidth = false;
            this.gridView1.OptionsView.ColumnAutoWidth = false;
            this.gridView1.OptionsView.ShowFooter = true;
            this.gridView1.OptionsView.ShowGroupPanel = false;
            this.gridView1.CustomDrawRowIndicator += new DevExpress.XtraGrid.Views.Grid.RowIndicatorCustomDrawEventHandler(this.gridView1_CustomDrawRowIndicator);
            this.gridView1.CellValueChanged += new DevExpress.XtraGrid.Views.Base.CellValueChangedEventHandler(this.gridView1_CellValueChanged);
            // 
            // gridColCustomerCode
            // 
            this.gridColCustomerCode.Caption = "Customer Code";
            this.gridColCustomerCode.ColumnEdit = this.ItemLookUpEditcCusCode;
            this.gridColCustomerCode.FieldName = "cCusCode";
            this.gridColCustomerCode.Name = "gridColCustomerCode";
            this.gridColCustomerCode.Visible = true;
            this.gridColCustomerCode.VisibleIndex = 0;
            this.gridColCustomerCode.Width = 132;
            // 
            // ItemLookUpEditcCusCode
            // 
            this.ItemLookUpEditcCusCode.AutoHeight = false;
            this.ItemLookUpEditcCusCode.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.ItemLookUpEditcCusCode.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("cCusCode", "Customer Code"),
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("cCusName", 80, "Customer Name")});
            this.ItemLookUpEditcCusCode.DisplayMember = "cCusCode";
            this.ItemLookUpEditcCusCode.Name = "ItemLookUpEditcCusCode";
            this.ItemLookUpEditcCusCode.NullText = "";
            this.ItemLookUpEditcCusCode.PopupWidth = 600;
            this.ItemLookUpEditcCusCode.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.Standard;
            this.ItemLookUpEditcCusCode.ValueMember = "cCusCode";
            // 
            // gridColCustomerName
            // 
            this.gridColCustomerName.Caption = "Customer Name";
            this.gridColCustomerName.ColumnEdit = this.ItemLookUpEditcCusName;
            this.gridColCustomerName.FieldName = "cCusCode";
            this.gridColCustomerName.Name = "gridColCustomerName";
            this.gridColCustomerName.Visible = true;
            this.gridColCustomerName.VisibleIndex = 1;
            this.gridColCustomerName.Width = 209;
            // 
            // ItemLookUpEditcCusName
            // 
            this.ItemLookUpEditcCusName.AutoHeight = false;
            this.ItemLookUpEditcCusName.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.ItemLookUpEditcCusName.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("cCusCode", "Customer Code"),
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("cCusName", 80, "Customer Name")});
            this.ItemLookUpEditcCusName.DisplayMember = "cCusName";
            this.ItemLookUpEditcCusName.Name = "ItemLookUpEditcCusName";
            this.ItemLookUpEditcCusName.NullText = "";
            this.ItemLookUpEditcCusName.PopupWidth = 600;
            this.ItemLookUpEditcCusName.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.Standard;
            this.ItemLookUpEditcCusName.ValueMember = "cCusCode";
            // 
            // gridColDefectCode
            // 
            this.gridColDefectCode.Caption = "Code";
            this.gridColDefectCode.ColumnEdit = this.ItemLookUpEditDefectCode;
            this.gridColDefectCode.FieldName = "DefectCode";
            this.gridColDefectCode.Name = "gridColDefectCode";
            this.gridColDefectCode.Visible = true;
            this.gridColDefectCode.VisibleIndex = 2;
            this.gridColDefectCode.Width = 109;
            // 
            // ItemLookUpEditDefectCode
            // 
            this.ItemLookUpEditDefectCode.AutoHeight = false;
            this.ItemLookUpEditDefectCode.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.ItemLookUpEditDefectCode.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("DefectCode", "Defect Code"),
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("DefectName", "Defect Name")});
            this.ItemLookUpEditDefectCode.DisplayMember = "DefectCode";
            this.ItemLookUpEditDefectCode.Name = "ItemLookUpEditDefectCode";
            this.ItemLookUpEditDefectCode.NullText = "";
            this.ItemLookUpEditDefectCode.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.Standard;
            this.ItemLookUpEditDefectCode.ValueMember = "DefectCode";
            // 
            // gridColDefectName
            // 
            this.gridColDefectName.Caption = "Item";
            this.gridColDefectName.ColumnEdit = this.ItemLookUpEditDefectName;
            this.gridColDefectName.FieldName = "DefectCode";
            this.gridColDefectName.Name = "gridColDefectName";
            this.gridColDefectName.Visible = true;
            this.gridColDefectName.VisibleIndex = 3;
            this.gridColDefectName.Width = 241;
            // 
            // ItemLookUpEditDefectName
            // 
            this.ItemLookUpEditDefectName.AutoHeight = false;
            this.ItemLookUpEditDefectName.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.ItemLookUpEditDefectName.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("DefectName", "Defect Name"),
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("DefectCode", "Defect Code")});
            this.ItemLookUpEditDefectName.DisplayMember = "DefectName";
            this.ItemLookUpEditDefectName.Name = "ItemLookUpEditDefectName";
            this.ItemLookUpEditDefectName.NullText = "";
            this.ItemLookUpEditDefectName.PopupWidth = 500;
            this.ItemLookUpEditDefectName.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.Standard;
            this.ItemLookUpEditDefectName.ValueMember = "DefectCode";
            // 
            // gridColiID
            // 
            this.gridColiID.Caption = "iID";
            this.gridColiID.FieldName = "iID";
            this.gridColiID.Name = "gridColiID";
            this.gridColiID.OptionsColumn.AllowEdit = false;
            // 
            // gridColsStatus
            // 
            this.gridColsStatus.Caption = "sStatus";
            this.gridColsStatus.FieldName = "sStatus";
            this.gridColsStatus.Name = "gridColsStatus";
            this.gridColsStatus.OptionsColumn.AllowEdit = false;
            // 
            // panel1
            // 
            this.panel1.AutoScroll = true;
            this.panel1.Controls.Add(this.gridControl1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 24);
            this.panel1.Margin = new System.Windows.Forms.Padding(4);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1259, 546);
            this.panel1.TabIndex = 173;
            // 
            // Defects
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.menuStrip1);
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "Defects";
            this.Size = new System.Drawing.Size(1259, 570);
            this.Load += new System.EventHandler(this.Frm_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ItemLookUpEditcCusCode)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ItemLookUpEditcCusName)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ItemLookUpEditDefectCode)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ItemLookUpEditDefectName)).EndInit();
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private DevExpress.XtraGrid.GridControl gridControl1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.ToolStripMenuItem btnRefresh;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView1;
        private System.Windows.Forms.ToolStripMenuItem btnExport;
        private DevExpress.XtraGrid.Columns.GridColumn gridColCustomerCode;
        private DevExpress.XtraGrid.Columns.GridColumn gridColCustomerName;
        private DevExpress.XtraGrid.Columns.GridColumn gridColDefectName;
        private System.Windows.Forms.ToolStripMenuItem btnEdit;
        private System.Windows.Forms.ToolStripMenuItem btnSave;
        private System.Windows.Forms.ToolStripMenuItem btnDelete;
        private DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit ItemLookUpEditcCusCode;
        private DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit ItemLookUpEditcCusName;
        private DevExpress.XtraGrid.Columns.GridColumn gridColiID;
        private DevExpress.XtraGrid.Columns.GridColumn gridColsStatus;
        private System.Windows.Forms.ToolStripMenuItem btnAddRow;
        private DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit ItemLookUpEditDefectName;
        private DevExpress.XtraGrid.Columns.GridColumn gridColDefectCode;
        private DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit ItemLookUpEditDefectCode;
    }
}
