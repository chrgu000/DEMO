namespace UFIDA.U8.UAP.CustomApp.ControlForm
{
    partial class FHDList
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
            this.btnReflash = new System.Windows.Forms.ToolStripMenuItem();
            this.btnAdd = new System.Windows.Forms.ToolStripMenuItem();
            this.btnEdit = new System.Windows.Forms.ToolStripMenuItem();
            this.btnExport = new System.Windows.Forms.ToolStripMenuItem();
            this.gridControl1 = new DevExpress.XtraGrid.GridControl();
            this.gridView1 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.gridColcDLCode = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColdDate = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColcCusCode = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColcCusName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColProjectName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColContackInfo = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColSiteQty = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColPickUpDate = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColPickUpTime = new DevExpress.XtraGrid.Columns.GridColumn();
            this.panel1 = new System.Windows.Forms.Panel();
            this.dateEdit2 = new DevExpress.XtraEditors.DateEdit();
            this.dateEdit1 = new DevExpress.XtraEditors.DateEdit();
            this.label1 = new System.Windows.Forms.Label();
            this.gridColStatus = new DevExpress.XtraGrid.Columns.GridColumn();
            this.menuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).BeginInit();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dateEdit2.Properties.VistaTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dateEdit2.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dateEdit1.Properties.VistaTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dateEdit1.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btnReflash,
            this.btnAdd,
            this.btnEdit,
            this.btnExport});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Padding = new System.Windows.Forms.Padding(8, 2, 0, 2);
            this.menuStrip1.Size = new System.Drawing.Size(961, 28);
            this.menuStrip1.TabIndex = 172;
            this.menuStrip1.Text = "menuStrip";
            // 
            // btnReflash
            // 
            this.btnReflash.Name = "btnReflash";
            this.btnReflash.Size = new System.Drawing.Size(73, 24);
            this.btnReflash.Text = "Reflash";
            this.btnReflash.Click += new System.EventHandler(this.btnReflash_Click);
            // 
            // btnAdd
            // 
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(52, 24);
            this.btnAdd.Text = "Add";
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // btnEdit
            // 
            this.btnEdit.Name = "btnEdit";
            this.btnEdit.Size = new System.Drawing.Size(49, 24);
            this.btnEdit.Text = "Edit";
            this.btnEdit.Click += new System.EventHandler(this.btnEdit_Click);
            // 
            // btnExport
            // 
            this.btnExport.Name = "btnExport";
            this.btnExport.Size = new System.Drawing.Size(110, 24);
            this.btnExport.Text = "Export Excel";
            this.btnExport.Click += new System.EventHandler(this.btnExport_Click);
            // 
            // gridControl1
            // 
            this.gridControl1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.gridControl1.EmbeddedNavigator.Margin = new System.Windows.Forms.Padding(4);
            this.gridControl1.Location = new System.Drawing.Point(0, 48);
            this.gridControl1.LookAndFeel.SkinName = "Office 2010 Blue";
            this.gridControl1.MainView = this.gridView1;
            this.gridControl1.Margin = new System.Windows.Forms.Padding(4);
            this.gridControl1.Name = "gridControl1";
            this.gridControl1.Size = new System.Drawing.Size(953, 348);
            this.gridControl1.TabIndex = 191;
            this.gridControl1.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView1});
            // 
            // gridView1
            // 
            this.gridView1.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.gridColcDLCode,
            this.gridColdDate,
            this.gridColcCusCode,
            this.gridColcCusName,
            this.gridColProjectName,
            this.gridColContackInfo,
            this.gridColSiteQty,
            this.gridColPickUpDate,
            this.gridColPickUpTime,
            this.gridColStatus});
            this.gridView1.GridControl = this.gridControl1;
            this.gridView1.IndicatorWidth = 40;
            this.gridView1.Name = "gridView1";
            this.gridView1.OptionsBehavior.AllowDeleteRows = DevExpress.Utils.DefaultBoolean.True;
            this.gridView1.OptionsBehavior.Editable = false;
            this.gridView1.OptionsBehavior.EditorShowMode = DevExpress.Utils.EditorShowMode.MouseDown;
            this.gridView1.OptionsCustomization.AllowGroup = false;
            this.gridView1.OptionsCustomization.AllowQuickHideColumns = false;
            this.gridView1.OptionsNavigation.EnterMoveNextColumn = true;
            this.gridView1.OptionsPrint.AutoWidth = false;
            this.gridView1.OptionsView.ColumnAutoWidth = false;
            this.gridView1.OptionsView.ShowFooter = true;
            this.gridView1.OptionsView.ShowGroupPanel = false;
            this.gridView1.CustomDrawRowIndicator += new DevExpress.XtraGrid.Views.Grid.RowIndicatorCustomDrawEventHandler(this.gridView1_CustomDrawRowIndicator);
            // 
            // gridColcDLCode
            // 
            this.gridColcDLCode.Caption = "DL No";
            this.gridColcDLCode.FieldName = "cDLCode";
            this.gridColcDLCode.Name = "gridColcDLCode";
            this.gridColcDLCode.OptionsColumn.AllowEdit = false;
            this.gridColcDLCode.Visible = true;
            this.gridColcDLCode.VisibleIndex = 0;
            this.gridColcDLCode.Width = 115;
            // 
            // gridColdDate
            // 
            this.gridColdDate.Caption = "Date";
            this.gridColdDate.FieldName = "dDate";
            this.gridColdDate.Name = "gridColdDate";
            this.gridColdDate.OptionsColumn.AllowEdit = false;
            this.gridColdDate.Visible = true;
            this.gridColdDate.VisibleIndex = 1;
            this.gridColdDate.Width = 120;
            // 
            // gridColcCusCode
            // 
            this.gridColcCusCode.Caption = "Customer Code";
            this.gridColcCusCode.FieldName = "cCusCode";
            this.gridColcCusCode.Name = "gridColcCusCode";
            this.gridColcCusCode.OptionsColumn.AllowEdit = false;
            this.gridColcCusCode.Visible = true;
            this.gridColcCusCode.VisibleIndex = 2;
            this.gridColcCusCode.Width = 111;
            // 
            // gridColcCusName
            // 
            this.gridColcCusName.Caption = "Customer";
            this.gridColcCusName.FieldName = "cCusName";
            this.gridColcCusName.Name = "gridColcCusName";
            this.gridColcCusName.OptionsColumn.AllowEdit = false;
            this.gridColcCusName.Visible = true;
            this.gridColcCusName.VisibleIndex = 3;
            this.gridColcCusName.Width = 193;
            // 
            // gridColProjectName
            // 
            this.gridColProjectName.Caption = "Project Name";
            this.gridColProjectName.FieldName = "ProjectName";
            this.gridColProjectName.Name = "gridColProjectName";
            this.gridColProjectName.OptionsColumn.AllowEdit = false;
            this.gridColProjectName.Visible = true;
            this.gridColProjectName.VisibleIndex = 4;
            // 
            // gridColContackInfo
            // 
            this.gridColContackInfo.Caption = "Contack Info";
            this.gridColContackInfo.FieldName = "ContackInfo";
            this.gridColContackInfo.Name = "gridColContackInfo";
            this.gridColContackInfo.OptionsColumn.AllowEdit = false;
            this.gridColContackInfo.Visible = true;
            this.gridColContackInfo.VisibleIndex = 5;
            // 
            // gridColSiteQty
            // 
            this.gridColSiteQty.Caption = "Site Qty";
            this.gridColSiteQty.FieldName = "SiteQty";
            this.gridColSiteQty.Name = "gridColSiteQty";
            this.gridColSiteQty.OptionsColumn.AllowEdit = false;
            this.gridColSiteQty.Visible = true;
            this.gridColSiteQty.VisibleIndex = 6;
            // 
            // gridColPickUpDate
            // 
            this.gridColPickUpDate.Caption = "PickUpDate";
            this.gridColPickUpDate.FieldName = "PickUpdate";
            this.gridColPickUpDate.Name = "gridColPickUpDate";
            this.gridColPickUpDate.OptionsColumn.AllowEdit = false;
            this.gridColPickUpDate.Visible = true;
            this.gridColPickUpDate.VisibleIndex = 7;
            // 
            // gridColPickUpTime
            // 
            this.gridColPickUpTime.Caption = "Time";
            this.gridColPickUpTime.FieldName = "PickUpTime";
            this.gridColPickUpTime.Name = "gridColPickUpTime";
            this.gridColPickUpTime.OptionsColumn.AllowEdit = false;
            this.gridColPickUpTime.Visible = true;
            this.gridColPickUpTime.VisibleIndex = 8;
            // 
            // panel1
            // 
            this.panel1.AutoScroll = true;
            this.panel1.Controls.Add(this.dateEdit2);
            this.panel1.Controls.Add(this.dateEdit1);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.gridControl1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 28);
            this.panel1.Margin = new System.Windows.Forms.Padding(4);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(961, 409);
            this.panel1.TabIndex = 173;
            // 
            // dateEdit2
            // 
            this.dateEdit2.EditValue = null;
            this.dateEdit2.Location = new System.Drawing.Point(233, 16);
            this.dateEdit2.Margin = new System.Windows.Forms.Padding(4);
            this.dateEdit2.Name = "dateEdit2";
            this.dateEdit2.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.dateEdit2.Properties.VistaTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
            this.dateEdit2.Size = new System.Drawing.Size(133, 24);
            this.dateEdit2.TabIndex = 202;
            // 
            // dateEdit1
            // 
            this.dateEdit1.EditValue = null;
            this.dateEdit1.Location = new System.Drawing.Point(92, 16);
            this.dateEdit1.Margin = new System.Windows.Forms.Padding(4);
            this.dateEdit1.Name = "dateEdit1";
            this.dateEdit1.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.dateEdit1.Properties.VistaTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
            this.dateEdit1.Size = new System.Drawing.Size(133, 24);
            this.dateEdit1.TabIndex = 201;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(17, 21);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(39, 15);
            this.label1.TabIndex = 200;
            this.label1.Text = "Date";
            // 
            // gridColStatus
            // 
            this.gridColStatus.Caption = "Status";
            this.gridColStatus.FieldName = "Status";
            this.gridColStatus.Name = "gridColStatus";
            this.gridColStatus.OptionsColumn.AllowEdit = false;
            this.gridColStatus.Visible = true;
            this.gridColStatus.VisibleIndex = 9;
            // 
            // FHDList
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.menuStrip1);
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "FHDList";
            this.Size = new System.Drawing.Size(961, 437);
            this.Load += new System.EventHandler(this.Frm_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dateEdit2.Properties.VistaTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dateEdit2.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dateEdit1.Properties.VistaTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dateEdit1.Properties)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private DevExpress.XtraGrid.GridControl gridControl1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.ToolStripMenuItem btnAdd;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView1;
        private System.Windows.Forms.ToolStripMenuItem btnEdit;
        private System.Windows.Forms.Label label1;
        private DevExpress.XtraEditors.DateEdit dateEdit1;
        private DevExpress.XtraGrid.Columns.GridColumn gridColcDLCode;
        private DevExpress.XtraGrid.Columns.GridColumn gridColdDate;
        private DevExpress.XtraGrid.Columns.GridColumn gridColcCusCode;
        private DevExpress.XtraGrid.Columns.GridColumn gridColProjectName;
        private DevExpress.XtraGrid.Columns.GridColumn gridColContackInfo;
        private DevExpress.XtraGrid.Columns.GridColumn gridColSiteQty;
        private DevExpress.XtraGrid.Columns.GridColumn gridColPickUpDate;
        private DevExpress.XtraGrid.Columns.GridColumn gridColPickUpTime;
        private DevExpress.XtraEditors.DateEdit dateEdit2;
        private System.Windows.Forms.ToolStripMenuItem btnReflash;
        private DevExpress.XtraGrid.Columns.GridColumn gridColcCusName;
        private System.Windows.Forms.ToolStripMenuItem btnExport;
        private DevExpress.XtraGrid.Columns.GridColumn gridColStatus;
    }
}
