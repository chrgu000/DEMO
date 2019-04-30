namespace UFIDA.U8.UAP.CustomApp.ControlForm
{
    partial class 科目设置表
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
            this.splitContainerControl1 = new DevExpress.XtraEditors.SplitContainerControl();
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnSel = new DevExpress.XtraEditors.SimpleButton();
            this.btnSave = new DevExpress.XtraEditors.SimpleButton();
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            this.grdDetail = new DevExpress.XtraGrid.GridControl();
            this.gridView1 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.gridCol类别 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridCol科目编码 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColiSave = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColChk = new DevExpress.XtraGrid.Columns.GridColumn();
            this.ItemCheckEditChk = new DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerControl1)).BeginInit();
            this.splitContainerControl1.SuspendLayout();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdDetail)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ItemCheckEditChk)).BeginInit();
            this.SuspendLayout();
            // 
            // splitContainerControl1
            // 
            this.splitContainerControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainerControl1.Horizontal = false;
            this.splitContainerControl1.Location = new System.Drawing.Point(0, 0);
            this.splitContainerControl1.Name = "splitContainerControl1";
            this.splitContainerControl1.Panel1.Controls.Add(this.panel1);
            this.splitContainerControl1.Panel1.Text = "Panel1";
            this.splitContainerControl1.Panel2.Controls.Add(this.grdDetail);
            this.splitContainerControl1.Panel2.Text = "Panel2";
            this.splitContainerControl1.Size = new System.Drawing.Size(986, 600);
            this.splitContainerControl1.SplitterPosition = 108;
            this.splitContainerControl1.TabIndex = 0;
            this.splitContainerControl1.Text = "splitContainerControl1";
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.btnSel);
            this.panel1.Controls.Add(this.btnSave);
            this.panel1.Controls.Add(this.labelControl1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(986, 108);
            this.panel1.TabIndex = 0;
            // 
            // btnSel
            // 
            this.btnSel.ImageLocation = DevExpress.XtraEditors.ImageLocation.TopCenter;
            this.btnSel.Location = new System.Drawing.Point(35, 49);
            this.btnSel.Name = "btnSel";
            this.btnSel.Size = new System.Drawing.Size(61, 41);
            this.btnSel.TabIndex = 54;
            this.btnSel.Text = "查询";
            this.btnSel.Click += new System.EventHandler(this.btnSel_Click);
            // 
            // btnSave
            // 
            this.btnSave.ImageLocation = DevExpress.XtraEditors.ImageLocation.TopCenter;
            this.btnSave.Location = new System.Drawing.Point(130, 49);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(61, 41);
            this.btnSave.TabIndex = 50;
            this.btnSave.Text = "保存";
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // labelControl1
            // 
            this.labelControl1.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.labelControl1.Appearance.Font = new System.Drawing.Font("Tahoma", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelControl1.Location = new System.Drawing.Point(394, 13);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(105, 25);
            this.labelControl1.TabIndex = 23;
            this.labelControl1.Text = "科目设置表";
            // 
            // grdDetail
            // 
            this.grdDetail.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grdDetail.Location = new System.Drawing.Point(0, 0);
            this.grdDetail.LookAndFeel.SkinName = "Office 2010 Blue";
            this.grdDetail.MainView = this.gridView1;
            this.grdDetail.Name = "grdDetail";
            this.grdDetail.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.ItemCheckEditChk});
            this.grdDetail.Size = new System.Drawing.Size(986, 487);
            this.grdDetail.TabIndex = 100;
            this.grdDetail.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView1});
            // 
            // gridView1
            // 
            this.gridView1.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.gridCol类别,
            this.gridCol科目编码,
            this.gridColiSave,
            this.gridColChk});
            this.gridView1.GridControl = this.grdDetail;
            this.gridView1.IndicatorWidth = 30;
            this.gridView1.Name = "gridView1";
            this.gridView1.OptionsBehavior.AllowDeleteRows = DevExpress.Utils.DefaultBoolean.True;
            this.gridView1.OptionsBehavior.EditorShowMode = DevExpress.Utils.EditorShowMode.MouseDown;
            this.gridView1.OptionsCustomization.AllowFilter = false;
            this.gridView1.OptionsCustomization.AllowGroup = false;
            this.gridView1.OptionsCustomization.AllowQuickHideColumns = false;
            this.gridView1.OptionsCustomization.AllowSort = false;
            this.gridView1.OptionsView.ColumnAutoWidth = false;
            this.gridView1.OptionsView.ShowGroupPanel = false;
            this.gridView1.FocusedRowChanged += new DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventHandler(this.gridView1_FocusedRowChanged);
            this.gridView1.CellValueChanged += new DevExpress.XtraGrid.Views.Base.CellValueChangedEventHandler(this.gridView1_CellValueChanged);
            // 
            // gridCol类别
            // 
            this.gridCol类别.Caption = "类别";
            this.gridCol类别.FieldName = "类别";
            this.gridCol类别.Name = "gridCol类别";
            this.gridCol类别.OptionsColumn.ReadOnly = true;
            this.gridCol类别.Visible = true;
            this.gridCol类别.VisibleIndex = 0;
            this.gridCol类别.Width = 91;
            // 
            // gridCol科目编码
            // 
            this.gridCol科目编码.Caption = "科目编码\r";
            this.gridCol科目编码.FieldName = "科目编码";
            this.gridCol科目编码.Name = "gridCol科目编码";
            this.gridCol科目编码.Visible = true;
            this.gridCol科目编码.VisibleIndex = 1;
            this.gridCol科目编码.Width = 181;
            // 
            // gridColiSave
            // 
            this.gridColiSave.Caption = "iSave";
            this.gridColiSave.FieldName = "iSave";
            this.gridColiSave.Name = "gridColiSave";
            // 
            // gridColChk
            // 
            this.gridColChk.Caption = "选择";
            this.gridColChk.ColumnEdit = this.ItemCheckEditChk;
            this.gridColChk.FieldName = "iChk";
            this.gridColChk.Name = "gridColChk";
            this.gridColChk.Width = 34;
            // 
            // ItemCheckEditChk
            // 
            this.ItemCheckEditChk.AutoHeight = false;
            this.ItemCheckEditChk.Name = "ItemCheckEditChk";
            // 
            // 科目设置表
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.splitContainerControl1);
            this.Name = "科目设置表";
            this.Size = new System.Drawing.Size(986, 600);
            this.Load += new System.EventHandler(this.科目设置表_Load);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerControl1)).EndInit();
            this.splitContainerControl1.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdDetail)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ItemCheckEditChk)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.SplitContainerControl splitContainerControl1;
        private System.Windows.Forms.Panel panel1;
        private DevExpress.XtraGrid.GridControl grdDetail;
        private DevExpress.XtraEditors.LabelControl labelControl1;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView1;
        private DevExpress.XtraGrid.Columns.GridColumn gridCol类别;
        private DevExpress.XtraGrid.Columns.GridColumn gridCol科目编码;
        private DevExpress.XtraEditors.SimpleButton btnSave;
        private DevExpress.XtraGrid.Columns.GridColumn gridColiSave;
        private DevExpress.XtraEditors.SimpleButton btnSel;
        private DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit ItemCheckEditChk;
        private DevExpress.XtraGrid.Columns.GridColumn gridColChk;
    }
}
