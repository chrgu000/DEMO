namespace UFIDA.U8.UAP.CustomApp.ControlForm
{
    partial class 帐套科目归属表
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(帐套科目归属表));
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            this.gridControl1 = new DevExpress.XtraGrid.GridControl();
            this.gridView1 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.gridCol选择 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.repositoryItemCheckEdit1 = new DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit();
            this.gridColiID = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridCol帐套号 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridCol科目 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridCol归属公司 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridCol对方科目 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.btnSave = new DevExpress.XtraEditors.SimpleButton();
            this.btnLoad = new DevExpress.XtraEditors.SimpleButton();
            this.btnRefresh = new DevExpress.XtraEditors.SimpleButton();
            this.btnDel = new DevExpress.XtraEditors.SimpleButton();
            this.gridCol对方客户 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridCol对方供应商 = new DevExpress.XtraGrid.Columns.GridColumn();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemCheckEdit1)).BeginInit();
            this.SuspendLayout();
            // 
            // labelControl1
            // 
            this.labelControl1.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.labelControl1.Appearance.Font = new System.Drawing.Font("Tahoma", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelControl1.Location = new System.Drawing.Point(281, 19);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(147, 25);
            this.labelControl1.TabIndex = 109;
            this.labelControl1.Text = "帐套科目归属表";
            // 
            // gridControl1
            // 
            this.gridControl1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.gridControl1.Location = new System.Drawing.Point(7, 114);
            this.gridControl1.LookAndFeel.SkinName = "Office 2010 Blue";
            this.gridControl1.MainView = this.gridView1;
            this.gridControl1.Name = "gridControl1";
            this.gridControl1.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.repositoryItemCheckEdit1});
            this.gridControl1.Size = new System.Drawing.Size(701, 269);
            this.gridControl1.TabIndex = 113;
            this.gridControl1.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView1});
            // 
            // gridView1
            // 
            this.gridView1.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.gridCol选择,
            this.gridColiID,
            this.gridCol帐套号,
            this.gridCol科目,
            this.gridCol归属公司,
            this.gridCol对方科目,
            this.gridCol对方客户,
            this.gridCol对方供应商});
            this.gridView1.GridControl = this.gridControl1;
            this.gridView1.IndicatorWidth = 40;
            this.gridView1.Name = "gridView1";
            this.gridView1.OptionsBehavior.AllowDeleteRows = DevExpress.Utils.DefaultBoolean.True;
            this.gridView1.OptionsBehavior.EditorShowMode = DevExpress.Utils.EditorShowMode.MouseDown;
            this.gridView1.OptionsCustomization.AllowGroup = false;
            this.gridView1.OptionsCustomization.AllowQuickHideColumns = false;
            this.gridView1.OptionsSelection.MultiSelect = true;
            this.gridView1.OptionsView.ColumnAutoWidth = false;
            this.gridView1.OptionsView.ShowGroupPanel = false;
            this.gridView1.CustomDrawRowIndicator += new DevExpress.XtraGrid.Views.Grid.RowIndicatorCustomDrawEventHandler(this.gridView1_CustomDrawRowIndicator);
            this.gridView1.CellValueChanged += new DevExpress.XtraGrid.Views.Base.CellValueChangedEventHandler(this.gridView1_CellValueChanged);
            // 
            // gridCol选择
            // 
            this.gridCol选择.Caption = "选择";
            this.gridCol选择.ColumnEdit = this.repositoryItemCheckEdit1;
            this.gridCol选择.FieldName = "选择";
            this.gridCol选择.Name = "gridCol选择";
            this.gridCol选择.Visible = true;
            this.gridCol选择.VisibleIndex = 0;
            this.gridCol选择.Width = 52;
            // 
            // repositoryItemCheckEdit1
            // 
            this.repositoryItemCheckEdit1.AutoHeight = false;
            this.repositoryItemCheckEdit1.Name = "repositoryItemCheckEdit1";
            // 
            // gridColiID
            // 
            this.gridColiID.Caption = "序号";
            this.gridColiID.FieldName = "iID";
            this.gridColiID.Name = "gridColiID";
            this.gridColiID.OptionsColumn.AllowEdit = false;
            // 
            // gridCol帐套号
            // 
            this.gridCol帐套号.Caption = "帐套号";
            this.gridCol帐套号.FieldName = "帐套号";
            this.gridCol帐套号.Name = "gridCol帐套号";
            this.gridCol帐套号.Visible = true;
            this.gridCol帐套号.VisibleIndex = 1;
            this.gridCol帐套号.Width = 106;
            // 
            // gridCol科目
            // 
            this.gridCol科目.Caption = "科目";
            this.gridCol科目.FieldName = "科目";
            this.gridCol科目.Name = "gridCol科目";
            this.gridCol科目.Visible = true;
            this.gridCol科目.VisibleIndex = 2;
            this.gridCol科目.Width = 110;
            // 
            // gridCol归属公司
            // 
            this.gridCol归属公司.Caption = "归属公司";
            this.gridCol归属公司.FieldName = "归属公司";
            this.gridCol归属公司.Name = "gridCol归属公司";
            this.gridCol归属公司.Visible = true;
            this.gridCol归属公司.VisibleIndex = 3;
            this.gridCol归属公司.Width = 108;
            // 
            // gridCol对方科目
            // 
            this.gridCol对方科目.Caption = "对方科目";
            this.gridCol对方科目.FieldName = "对方科目";
            this.gridCol对方科目.Name = "gridCol对方科目";
            this.gridCol对方科目.Visible = true;
            this.gridCol对方科目.VisibleIndex = 4;
            this.gridCol对方科目.Width = 144;
            // 
            // btnSave
            // 
            this.btnSave.Image = ((System.Drawing.Image)(resources.GetObject("btnSave.Image")));
            this.btnSave.ImageLocation = DevExpress.XtraEditors.ImageLocation.TopCenter;
            this.btnSave.Location = new System.Drawing.Point(252, 52);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(46, 41);
            this.btnSave.TabIndex = 137;
            this.btnSave.Text = "保存";
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // btnLoad
            // 
            this.btnLoad.Image = ((System.Drawing.Image)(resources.GetObject("btnLoad.Image")));
            this.btnLoad.ImageLocation = DevExpress.XtraEditors.ImageLocation.TopCenter;
            this.btnLoad.Location = new System.Drawing.Point(20, 52);
            this.btnLoad.Name = "btnLoad";
            this.btnLoad.Size = new System.Drawing.Size(69, 41);
            this.btnLoad.TabIndex = 136;
            this.btnLoad.Text = "加载Excel";
            this.btnLoad.Click += new System.EventHandler(this.btnLoad_Click);
            // 
            // btnRefresh
            // 
            this.btnRefresh.Image = ((System.Drawing.Image)(resources.GetObject("btnRefresh.Image")));
            this.btnRefresh.ImageLocation = DevExpress.XtraEditors.ImageLocation.TopCenter;
            this.btnRefresh.Location = new System.Drawing.Point(105, 52);
            this.btnRefresh.Name = "btnRefresh";
            this.btnRefresh.Size = new System.Drawing.Size(46, 41);
            this.btnRefresh.TabIndex = 115;
            this.btnRefresh.Text = "过滤";
            this.btnRefresh.Click += new System.EventHandler(this.btnRefresh_Click);
            // 
            // btnDel
            // 
            this.btnDel.Image = ((System.Drawing.Image)(resources.GetObject("btnDel.Image")));
            this.btnDel.ImageLocation = DevExpress.XtraEditors.ImageLocation.TopCenter;
            this.btnDel.Location = new System.Drawing.Point(179, 52);
            this.btnDel.Name = "btnDel";
            this.btnDel.Size = new System.Drawing.Size(46, 41);
            this.btnDel.TabIndex = 138;
            this.btnDel.Text = "删除";
            this.btnDel.Click += new System.EventHandler(this.btnDel_Click);
            // 
            // gridCol对方客户
            // 
            this.gridCol对方客户.Caption = "对方客户";
            this.gridCol对方客户.FieldName = "对方客户";
            this.gridCol对方客户.Name = "gridCol对方客户";
            this.gridCol对方客户.Visible = true;
            this.gridCol对方客户.VisibleIndex = 5;
            this.gridCol对方客户.Width = 107;
            // 
            // gridCol对方供应商
            // 
            this.gridCol对方供应商.Caption = "对方供应商";
            this.gridCol对方供应商.FieldName = "对方供应商";
            this.gridCol对方供应商.Name = "gridCol对方供应商";
            this.gridCol对方供应商.Visible = true;
            this.gridCol对方供应商.VisibleIndex = 6;
            this.gridCol对方供应商.Width = 126;
            // 
            // 帐套科目归属表
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.btnDel);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.btnLoad);
            this.Controls.Add(this.btnRefresh);
            this.Controls.Add(this.gridControl1);
            this.Controls.Add(this.labelControl1);
            this.Name = "帐套科目归属表";
            this.Size = new System.Drawing.Size(710, 387);
            this.Load += new System.EventHandler(this.ProjectManager_Load);
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemCheckEdit1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraEditors.LabelControl labelControl1;
        private DevExpress.XtraGrid.GridControl gridControl1;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView1;
        private DevExpress.XtraEditors.SimpleButton btnSave;
        private DevExpress.XtraEditors.SimpleButton btnLoad;
        private DevExpress.XtraEditors.SimpleButton btnRefresh;
        private DevExpress.XtraEditors.SimpleButton btnDel;
        private DevExpress.XtraGrid.Columns.GridColumn gridColiID;
        private DevExpress.XtraGrid.Columns.GridColumn gridCol帐套号;
        private DevExpress.XtraGrid.Columns.GridColumn gridCol科目;
        private DevExpress.XtraGrid.Columns.GridColumn gridCol归属公司;
        private DevExpress.XtraGrid.Columns.GridColumn gridCol对方科目;
        private DevExpress.XtraGrid.Columns.GridColumn gridCol选择;
        private DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit repositoryItemCheckEdit1;
        private DevExpress.XtraGrid.Columns.GridColumn gridCol对方客户;
        private DevExpress.XtraGrid.Columns.GridColumn gridCol对方供应商;

    }
}
