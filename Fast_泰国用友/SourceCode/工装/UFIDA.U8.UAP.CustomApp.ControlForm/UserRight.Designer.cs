namespace UFIDA.U8.UAP.CustomApp.ControlForm
{
    partial class UserRight
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
            this.btnSEL = new System.Windows.Forms.ToolStripMenuItem();
            this.btnSave = new System.Windows.Forms.ToolStripMenuItem();
            this.btnExcel = new System.Windows.Forms.ToolStripMenuItem();
            this.gridControl1 = new DevExpress.XtraGrid.GridControl();
            this.gridView1 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.gridCol_UserUid = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridCol_UserName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.panel1 = new System.Windows.Forms.Panel();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.labelUserName = new System.Windows.Forms.Label();
            this.labelUid = new System.Windows.Forms.Label();
            this.gridControl2 = new DevExpress.XtraGrid.GridControl();
            this.gridView2 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.gridColbChoose = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColFormID = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColFormName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColBtnName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColBtnID = new DevExpress.XtraGrid.Columns.GridColumn();
            this.menuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).BeginInit();
            this.panel1.SuspendLayout();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView2)).BeginInit();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btnSEL,
            this.btnSave,
            this.btnExcel});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(837, 24);
            this.menuStrip1.TabIndex = 172;
            this.menuStrip1.Text = "menuStrip";
            // 
            // btnSEL
            // 
            this.btnSEL.Name = "btnSEL";
            this.btnSEL.Size = new System.Drawing.Size(41, 20);
            this.btnSEL.Text = "刷新";
            this.btnSEL.Click += new System.EventHandler(this.btnSEL_Click);
            // 
            // btnSave
            // 
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(41, 20);
            this.btnSave.Text = "保存";
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
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
            this.gridControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridControl1.Location = new System.Drawing.Point(0, 0);
            this.gridControl1.LookAndFeel.SkinName = "Office 2010 Blue";
            this.gridControl1.MainView = this.gridView1;
            this.gridControl1.Name = "gridControl1";
            this.gridControl1.Size = new System.Drawing.Size(333, 488);
            this.gridControl1.TabIndex = 191;
            this.gridControl1.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView1});
            // 
            // gridView1
            // 
            this.gridView1.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.gridCol_UserUid,
            this.gridCol_UserName});
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
            // gridCol_UserUid
            // 
            this.gridCol_UserUid.Caption = "编号";
            this.gridCol_UserUid.FieldName = "UserUid";
            this.gridCol_UserUid.Name = "gridCol_UserUid";
            this.gridCol_UserUid.OptionsColumn.AllowEdit = false;
            this.gridCol_UserUid.Visible = true;
            this.gridCol_UserUid.VisibleIndex = 0;
            this.gridCol_UserUid.Width = 151;
            // 
            // gridCol_UserName
            // 
            this.gridCol_UserName.Caption = "姓名";
            this.gridCol_UserName.FieldName = "UserName";
            this.gridCol_UserName.Name = "gridCol_UserName";
            this.gridCol_UserName.OptionsColumn.AllowEdit = false;
            this.gridCol_UserName.Visible = true;
            this.gridCol_UserName.VisibleIndex = 1;
            this.gridCol_UserName.Width = 189;
            // 
            // panel1
            // 
            this.panel1.AutoScroll = true;
            this.panel1.Controls.Add(this.splitContainer1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 24);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(837, 488);
            this.panel1.TabIndex = 173;
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(0, 0);
            this.splitContainer1.Margin = new System.Windows.Forms.Padding(2);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.gridControl1);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.labelUserName);
            this.splitContainer1.Panel2.Controls.Add(this.labelUid);
            this.splitContainer1.Panel2.Controls.Add(this.gridControl2);
            this.splitContainer1.Size = new System.Drawing.Size(837, 488);
            this.splitContainer1.SplitterDistance = 333;
            this.splitContainer1.SplitterWidth = 3;
            this.splitContainer1.TabIndex = 192;
            // 
            // labelUserName
            // 
            this.labelUserName.AutoSize = true;
            this.labelUserName.Location = new System.Drawing.Point(124, 14);
            this.labelUserName.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.labelUserName.Name = "labelUserName";
            this.labelUserName.Size = new System.Drawing.Size(83, 12);
            this.labelUserName.TabIndex = 194;
            this.labelUserName.Text = "labelUserName";
            // 
            // labelUid
            // 
            this.labelUid.AutoSize = true;
            this.labelUid.Location = new System.Drawing.Point(18, 14);
            this.labelUid.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.labelUid.Name = "labelUid";
            this.labelUid.Size = new System.Drawing.Size(53, 12);
            this.labelUid.TabIndex = 193;
            this.labelUid.Text = "labelUid";
            // 
            // gridControl2
            // 
            this.gridControl2.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.gridControl2.Location = new System.Drawing.Point(0, 42);
            this.gridControl2.LookAndFeel.SkinName = "Office 2010 Blue";
            this.gridControl2.MainView = this.gridView2;
            this.gridControl2.Name = "gridControl2";
            this.gridControl2.Size = new System.Drawing.Size(501, 445);
            this.gridControl2.TabIndex = 192;
            this.gridControl2.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView2});
            // 
            // gridView2
            // 
            this.gridView2.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.gridColbChoose,
            this.gridColFormID,
            this.gridColFormName,
            this.gridColBtnName,
            this.gridColBtnID});
            this.gridView2.GridControl = this.gridControl2;
            this.gridView2.IndicatorWidth = 40;
            this.gridView2.Name = "gridView2";
            this.gridView2.OptionsBehavior.AllowDeleteRows = DevExpress.Utils.DefaultBoolean.True;
            this.gridView2.OptionsBehavior.EditorShowMode = DevExpress.Utils.EditorShowMode.MouseDown;
            this.gridView2.OptionsCustomization.AllowGroup = false;
            this.gridView2.OptionsCustomization.AllowQuickHideColumns = false;
            this.gridView2.OptionsNavigation.EnterMoveNextColumn = true;
            this.gridView2.OptionsView.AllowCellMerge = true;
            this.gridView2.OptionsView.ColumnAutoWidth = false;
            this.gridView2.OptionsView.ShowFooter = true;
            this.gridView2.OptionsView.ShowGroupPanel = false;
            this.gridView2.CustomDrawRowIndicator += new DevExpress.XtraGrid.Views.Grid.RowIndicatorCustomDrawEventHandler(this.gridView1_CustomDrawRowIndicator);
            // 
            // gridColbChoose
            // 
            this.gridColbChoose.Caption = "选择";
            this.gridColbChoose.FieldName = "bChoose";
            this.gridColbChoose.Name = "gridColbChoose";
            this.gridColbChoose.OptionsColumn.AllowMerge = DevExpress.Utils.DefaultBoolean.False;
            this.gridColbChoose.Visible = true;
            this.gridColbChoose.VisibleIndex = 0;
            // 
            // gridColFormID
            // 
            this.gridColFormID.Caption = "菜单编号";
            this.gridColFormID.FieldName = "FormID";
            this.gridColFormID.Name = "gridColFormID";
            this.gridColFormID.OptionsColumn.AllowEdit = false;
            this.gridColFormID.OptionsColumn.AllowMerge = DevExpress.Utils.DefaultBoolean.True;
            this.gridColFormID.Width = 130;
            // 
            // gridColFormName
            // 
            this.gridColFormName.Caption = "菜单名称";
            this.gridColFormName.FieldName = "FormName";
            this.gridColFormName.Name = "gridColFormName";
            this.gridColFormName.OptionsColumn.AllowEdit = false;
            this.gridColFormName.OptionsColumn.AllowMerge = DevExpress.Utils.DefaultBoolean.True;
            this.gridColFormName.Visible = true;
            this.gridColFormName.VisibleIndex = 1;
            this.gridColFormName.Width = 208;
            // 
            // gridColBtnName
            // 
            this.gridColBtnName.Caption = "按钮";
            this.gridColBtnName.FieldName = "BtnName";
            this.gridColBtnName.Name = "gridColBtnName";
            this.gridColBtnName.OptionsColumn.AllowEdit = false;
            this.gridColBtnName.OptionsColumn.AllowMerge = DevExpress.Utils.DefaultBoolean.False;
            this.gridColBtnName.Visible = true;
            this.gridColBtnName.VisibleIndex = 2;
            this.gridColBtnName.Width = 255;
            // 
            // gridColBtnID
            // 
            this.gridColBtnID.Caption = "按钮编号";
            this.gridColBtnID.FieldName = "BtnID";
            this.gridColBtnID.Name = "gridColBtnID";
            this.gridColBtnID.OptionsColumn.AllowEdit = false;
            this.gridColBtnID.OptionsColumn.AllowMerge = DevExpress.Utils.DefaultBoolean.False;
            this.gridColBtnID.Width = 94;
            // 
            // UserRight
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.menuStrip1);
            this.Name = "UserRight";
            this.Size = new System.Drawing.Size(837, 512);
            this.Load += new System.EventHandler(this.Frm_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).EndInit();
            this.panel1.ResumeLayout(false);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            this.splitContainer1.Panel2.PerformLayout();
            this.splitContainer1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gridControl2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView2)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private DevExpress.XtraGrid.GridControl gridControl1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.ToolStripMenuItem btnSEL;
        private System.Windows.Forms.ToolStripMenuItem btnSave;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView1;
        private DevExpress.XtraGrid.Columns.GridColumn gridCol_UserUid;
        private DevExpress.XtraGrid.Columns.GridColumn gridCol_UserName;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private DevExpress.XtraGrid.GridControl gridControl2;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView2;
        private DevExpress.XtraGrid.Columns.GridColumn gridColbChoose;
        private DevExpress.XtraGrid.Columns.GridColumn gridColFormName;
        private DevExpress.XtraGrid.Columns.GridColumn gridColBtnName;
        private DevExpress.XtraGrid.Columns.GridColumn gridColFormID;
        private DevExpress.XtraGrid.Columns.GridColumn gridColBtnID;
        private System.Windows.Forms.Label labelUid;
        private System.Windows.Forms.Label labelUserName;
        private System.Windows.Forms.ToolStripMenuItem btnExcel;
    }
}
