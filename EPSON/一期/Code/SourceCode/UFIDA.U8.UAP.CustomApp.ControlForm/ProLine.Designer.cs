namespace UFIDA.U8.UAP.CustomApp.ControlForm
{
    partial class ProLine
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
            this.addrowToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.delrowToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.btnDEL = new System.Windows.Forms.ToolStripMenuItem();
            this.btnSave = new System.Windows.Forms.ToolStripMenuItem();
            this.btnExport = new System.Windows.Forms.ToolStripMenuItem();
            this.gridControl1 = new DevExpress.XtraGrid.GridControl();
            this.gridView1 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.gridColiState = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColiID = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColcCode = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColcName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColRemark1 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColRemark2 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColRemark3 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColRemark4 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColRemark5 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColCreateUid = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColCreateDate = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColUpdateUid = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColUpdateDate = new DevExpress.XtraGrid.Columns.GridColumn();
            this.ItemLookUpEditcWhCode = new DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit();
            this.ItemLookUpEditcWhName = new DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit();
            this.ItemLookUpEditcRdCode = new DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit();
            this.ItemLookUpEditcRdName = new DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit();
            this.panel1 = new System.Windows.Forms.Panel();
            this.menuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ItemLookUpEditcWhCode)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ItemLookUpEditcWhName)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ItemLookUpEditcRdCode)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ItemLookUpEditcRdName)).BeginInit();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btnRefresh,
            this.addrowToolStripMenuItem,
            this.delrowToolStripMenuItem,
            this.btnDEL,
            this.btnSave,
            this.btnExport});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(944, 25);
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
            // addrowToolStripMenuItem
            // 
            this.addrowToolStripMenuItem.Name = "addrowToolStripMenuItem";
            this.addrowToolStripMenuItem.Size = new System.Drawing.Size(73, 21);
            this.addrowToolStripMenuItem.Text = "Add Row";
            this.addrowToolStripMenuItem.Click += new System.EventHandler(this.addrowToolStripMenuItem_Click);
            // 
            // delrowToolStripMenuItem
            // 
            this.delrowToolStripMenuItem.Name = "delrowToolStripMenuItem";
            this.delrowToolStripMenuItem.Size = new System.Drawing.Size(86, 21);
            this.delrowToolStripMenuItem.Text = "Delete Row";
            this.delrowToolStripMenuItem.Click += new System.EventHandler(this.delrowToolStripMenuItem_Click);
            // 
            // btnDEL
            // 
            this.btnDEL.Name = "btnDEL";
            this.btnDEL.Size = new System.Drawing.Size(57, 21);
            this.btnDEL.Text = "Delete";
            this.btnDEL.Click += new System.EventHandler(this.btnDEL_Click);
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
            this.ItemLookUpEditcWhCode,
            this.ItemLookUpEditcWhName,
            this.ItemLookUpEditcRdCode,
            this.ItemLookUpEditcRdName});
            this.gridControl1.Size = new System.Drawing.Size(938, 423);
            this.gridControl1.TabIndex = 191;
            this.gridControl1.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView1});
            // 
            // gridView1
            // 
            this.gridView1.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.gridColiState,
            this.gridColiID,
            this.gridColcCode,
            this.gridColcName,
            this.gridColRemark1,
            this.gridColRemark2,
            this.gridColRemark3,
            this.gridColRemark4,
            this.gridColRemark5,
            this.gridColCreateUid,
            this.gridColCreateDate,
            this.gridColUpdateUid,
            this.gridColUpdateDate});
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
            // gridColiState
            // 
            this.gridColiState.Caption = "iState";
            this.gridColiState.FieldName = "iState";
            this.gridColiState.Name = "gridColiState";
            this.gridColiState.OptionsColumn.AllowEdit = false;
            this.gridColiState.OptionsColumn.AllowSort = DevExpress.Utils.DefaultBoolean.False;
            // 
            // gridColiID
            // 
            this.gridColiID.Caption = "iID";
            this.gridColiID.FieldName = "iID";
            this.gridColiID.Name = "gridColiID";
            this.gridColiID.OptionsColumn.AllowEdit = false;
            // 
            // gridColcCode
            // 
            this.gridColcCode.Caption = "Prod No";
            this.gridColcCode.FieldName = "cCode";
            this.gridColcCode.Name = "gridColcCode";
            this.gridColcCode.Visible = true;
            this.gridColcCode.VisibleIndex = 0;
            // 
            // gridColcName
            // 
            this.gridColcName.Caption = "Description";
            this.gridColcName.FieldName = "cName";
            this.gridColcName.Name = "gridColcName";
            this.gridColcName.Visible = true;
            this.gridColcName.VisibleIndex = 1;
            // 
            // gridColRemark1
            // 
            this.gridColRemark1.Caption = "Remark1";
            this.gridColRemark1.FieldName = "Remark1";
            this.gridColRemark1.Name = "gridColRemark1";
            this.gridColRemark1.OptionsColumn.AllowSort = DevExpress.Utils.DefaultBoolean.False;
            this.gridColRemark1.Visible = true;
            this.gridColRemark1.VisibleIndex = 2;
            this.gridColRemark1.Width = 197;
            // 
            // gridColRemark2
            // 
            this.gridColRemark2.Caption = "Remark2";
            this.gridColRemark2.FieldName = "Remark2";
            this.gridColRemark2.Name = "gridColRemark2";
            this.gridColRemark2.Visible = true;
            this.gridColRemark2.VisibleIndex = 3;
            // 
            // gridColRemark3
            // 
            this.gridColRemark3.Caption = "Remark3";
            this.gridColRemark3.FieldName = "Remark3";
            this.gridColRemark3.Name = "gridColRemark3";
            this.gridColRemark3.Visible = true;
            this.gridColRemark3.VisibleIndex = 4;
            // 
            // gridColRemark4
            // 
            this.gridColRemark4.Caption = "Remark4";
            this.gridColRemark4.FieldName = "Remark4";
            this.gridColRemark4.Name = "gridColRemark4";
            this.gridColRemark4.Visible = true;
            this.gridColRemark4.VisibleIndex = 5;
            // 
            // gridColRemark5
            // 
            this.gridColRemark5.Caption = "Remark5";
            this.gridColRemark5.FieldName = "Remark5";
            this.gridColRemark5.Name = "gridColRemark5";
            this.gridColRemark5.Visible = true;
            this.gridColRemark5.VisibleIndex = 6;
            // 
            // gridColCreateUid
            // 
            this.gridColCreateUid.Caption = "CreateUid";
            this.gridColCreateUid.FieldName = "Creater";
            this.gridColCreateUid.Name = "gridColCreateUid";
            this.gridColCreateUid.OptionsColumn.AllowEdit = false;
            this.gridColCreateUid.OptionsColumn.AllowSort = DevExpress.Utils.DefaultBoolean.False;
            // 
            // gridColCreateDate
            // 
            this.gridColCreateDate.Caption = "CreateDate";
            this.gridColCreateDate.FieldName = "CreateDate";
            this.gridColCreateDate.Name = "gridColCreateDate";
            this.gridColCreateDate.OptionsColumn.AllowEdit = false;
            this.gridColCreateDate.OptionsColumn.AllowSort = DevExpress.Utils.DefaultBoolean.False;
            // 
            // gridColUpdateUid
            // 
            this.gridColUpdateUid.Caption = "UpdateUid";
            this.gridColUpdateUid.FieldName = "UpdateUid";
            this.gridColUpdateUid.Name = "gridColUpdateUid";
            // 
            // gridColUpdateDate
            // 
            this.gridColUpdateDate.Caption = "UpdateDate";
            this.gridColUpdateDate.FieldName = "UpdateDate";
            this.gridColUpdateDate.Name = "gridColUpdateDate";
            // 
            // ItemLookUpEditcWhCode
            // 
            this.ItemLookUpEditcWhCode.AutoHeight = false;
            this.ItemLookUpEditcWhCode.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.ItemLookUpEditcWhCode.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("cWhCode", "WareHouseNo"),
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("cWhName", "WareHouse")});
            this.ItemLookUpEditcWhCode.DisplayMember = "cWhCode";
            this.ItemLookUpEditcWhCode.Name = "ItemLookUpEditcWhCode";
            this.ItemLookUpEditcWhCode.NullText = "";
            this.ItemLookUpEditcWhCode.PopupWidth = 400;
            this.ItemLookUpEditcWhCode.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.Standard;
            this.ItemLookUpEditcWhCode.ValueMember = "cWhCode";
            // 
            // ItemLookUpEditcWhName
            // 
            this.ItemLookUpEditcWhName.AutoHeight = false;
            this.ItemLookUpEditcWhName.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.ItemLookUpEditcWhName.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("cWhCode", "WareHouseNo"),
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("cWhName", "WareHouse")});
            this.ItemLookUpEditcWhName.DisplayMember = "cWhName";
            this.ItemLookUpEditcWhName.Name = "ItemLookUpEditcWhName";
            this.ItemLookUpEditcWhName.NullText = "";
            this.ItemLookUpEditcWhName.PopupWidth = 400;
            this.ItemLookUpEditcWhName.ValueMember = "cWhCode";
            // 
            // ItemLookUpEditcRdCode
            // 
            this.ItemLookUpEditcRdCode.AutoHeight = false;
            this.ItemLookUpEditcRdCode.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.ItemLookUpEditcRdCode.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("cRdCode", "收发类别编码"),
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("cRdName", "收发类别名称")});
            this.ItemLookUpEditcRdCode.DisplayMember = "cRdCode";
            this.ItemLookUpEditcRdCode.Name = "ItemLookUpEditcRdCode";
            this.ItemLookUpEditcRdCode.NullText = "";
            this.ItemLookUpEditcRdCode.PopupWidth = 400;
            this.ItemLookUpEditcRdCode.ValueMember = "cRdCode";
            // 
            // ItemLookUpEditcRdName
            // 
            this.ItemLookUpEditcRdName.AutoHeight = false;
            this.ItemLookUpEditcRdName.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.ItemLookUpEditcRdName.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("cRdCode", "收发类别编码"),
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("cRdName", "收发类别名称")});
            this.ItemLookUpEditcRdName.DisplayMember = "cRdName";
            this.ItemLookUpEditcRdName.Name = "ItemLookUpEditcRdName";
            this.ItemLookUpEditcRdName.NullText = "";
            this.ItemLookUpEditcRdName.PopupWidth = 400;
            this.ItemLookUpEditcRdName.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.Standard;
            this.ItemLookUpEditcRdName.ValueMember = "cRdCode";
            // 
            // panel1
            // 
            this.panel1.AutoScroll = true;
            this.panel1.Controls.Add(this.gridControl1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 25);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(944, 431);
            this.panel1.TabIndex = 173;
            // 
            // ProLine
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.menuStrip1);
            this.Name = "ProLine";
            this.Size = new System.Drawing.Size(944, 456);
            this.Load += new System.EventHandler(this.Frm_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ItemLookUpEditcWhCode)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ItemLookUpEditcWhName)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ItemLookUpEditcRdCode)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ItemLookUpEditcRdName)).EndInit();
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
        private DevExpress.XtraGrid.Columns.GridColumn gridColRemark1;
        private System.Windows.Forms.ToolStripMenuItem btnExport;
        private DevExpress.XtraGrid.Columns.GridColumn gridColiState;
        private DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit ItemLookUpEditcWhCode;
        private DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit ItemLookUpEditcWhName;
        private DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit ItemLookUpEditcRdCode;
        private DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit ItemLookUpEditcRdName;
        private DevExpress.XtraGrid.Columns.GridColumn gridColiID;
        private DevExpress.XtraGrid.Columns.GridColumn gridColcCode;
        private DevExpress.XtraGrid.Columns.GridColumn gridColcName;
        private DevExpress.XtraGrid.Columns.GridColumn gridColRemark2;
        private DevExpress.XtraGrid.Columns.GridColumn gridColRemark3;
        private DevExpress.XtraGrid.Columns.GridColumn gridColRemark4;
        private DevExpress.XtraGrid.Columns.GridColumn gridColRemark5;
        private DevExpress.XtraGrid.Columns.GridColumn gridColUpdateUid;
        private DevExpress.XtraGrid.Columns.GridColumn gridColUpdateDate;
        private System.Windows.Forms.ToolStripMenuItem btnDEL;
        private System.Windows.Forms.ToolStripMenuItem addrowToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem delrowToolStripMenuItem;
    }
}
