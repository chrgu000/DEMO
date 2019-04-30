namespace UFIDA.U8.UAP.CustomApp.ControlForm
{
    partial class 货位标签打印
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(货位标签打印));
            this.btn清空 = new DevExpress.XtraEditors.SimpleButton();
            this.btnPrint = new DevExpress.XtraEditors.SimpleButton();
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            this.btnSel = new DevExpress.XtraEditors.SimpleButton();
            this.chk全选 = new System.Windows.Forms.CheckBox();
            this.grdDetail = new DevExpress.XtraGrid.GridControl();
            this.gridView1 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.gridCol选择 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.ItemChk = new DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit();
            this.gridCol仓库编码 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridCol仓库名称 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridCol货位编码 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridCol货位名称 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.ItemLookUpEdit存货编码 = new DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit();
            this.ItemLookUpEdit存货名称 = new DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit();
            this.ItemLookUpEdit规格型号 = new DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit();
            ((System.ComponentModel.ISupportInitialize)(this.grdDetail)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ItemChk)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ItemLookUpEdit存货编码)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ItemLookUpEdit存货名称)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ItemLookUpEdit规格型号)).BeginInit();
            this.SuspendLayout();
            // 
            // btn清空
            // 
            this.btn清空.Image = ((System.Drawing.Image)(resources.GetObject("btn清空.Image")));
            this.btn清空.ImageLocation = DevExpress.XtraEditors.ImageLocation.TopCenter;
            this.btn清空.Location = new System.Drawing.Point(440, 59);
            this.btn清空.Margin = new System.Windows.Forms.Padding(4);
            this.btn清空.Name = "btn清空";
            this.btn清空.Size = new System.Drawing.Size(61, 51);
            this.btn清空.TabIndex = 57;
            this.btn清空.Text = "清空";
            // 
            // btnPrint
            // 
            this.btnPrint.Image = ((System.Drawing.Image)(resources.GetObject("btnPrint.Image")));
            this.btnPrint.ImageLocation = DevExpress.XtraEditors.ImageLocation.TopCenter;
            this.btnPrint.Location = new System.Drawing.Point(579, 59);
            this.btnPrint.Margin = new System.Windows.Forms.Padding(4);
            this.btnPrint.Name = "btnPrint";
            this.btnPrint.Size = new System.Drawing.Size(61, 51);
            this.btnPrint.TabIndex = 54;
            this.btnPrint.Text = "打印";
            this.btnPrint.Click += new System.EventHandler(this.btnPrint_Click);
            // 
            // labelControl1
            // 
            this.labelControl1.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.labelControl1.Appearance.Font = new System.Drawing.Font("Tahoma", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelControl1.Location = new System.Drawing.Point(294, 18);
            this.labelControl1.Margin = new System.Windows.Forms.Padding(4);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(162, 33);
            this.labelControl1.TabIndex = 23;
            this.labelControl1.Text = "货位标签打印";
            // 
            // btnSel
            // 
            this.btnSel.Image = ((System.Drawing.Image)(resources.GetObject("btnSel.Image")));
            this.btnSel.ImageLocation = DevExpress.XtraEditors.ImageLocation.TopCenter;
            this.btnSel.Location = new System.Drawing.Point(509, 59);
            this.btnSel.Margin = new System.Windows.Forms.Padding(4);
            this.btnSel.Name = "btnSel";
            this.btnSel.Size = new System.Drawing.Size(61, 51);
            this.btnSel.TabIndex = 21;
            this.btnSel.Text = "过滤";
            this.btnSel.Click += new System.EventHandler(this.btnSel_Click);
            // 
            // chk全选
            // 
            this.chk全选.AutoSize = true;
            this.chk全选.Location = new System.Drawing.Point(20, 91);
            this.chk全选.Margin = new System.Windows.Forms.Padding(4);
            this.chk全选.Name = "chk全选";
            this.chk全选.Size = new System.Drawing.Size(59, 19);
            this.chk全选.TabIndex = 65;
            this.chk全选.Text = "全选";
            this.chk全选.UseVisualStyleBackColor = true;
            this.chk全选.CheckedChanged += new System.EventHandler(this.chk全选_CheckedChanged);
            // 
            // grdDetail
            // 
            this.grdDetail.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.grdDetail.EmbeddedNavigator.Margin = new System.Windows.Forms.Padding(4);
            this.grdDetail.Location = new System.Drawing.Point(4, 118);
            this.grdDetail.LookAndFeel.SkinName = "Office 2010 Blue";
            this.grdDetail.MainView = this.gridView1;
            this.grdDetail.Margin = new System.Windows.Forms.Padding(4);
            this.grdDetail.Name = "grdDetail";
            this.grdDetail.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.ItemChk,
            this.ItemLookUpEdit存货编码,
            this.ItemLookUpEdit存货名称,
            this.ItemLookUpEdit规格型号});
            this.grdDetail.Size = new System.Drawing.Size(835, 541);
            this.grdDetail.TabIndex = 100;
            this.grdDetail.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView1});
            // 
            // gridView1
            // 
            this.gridView1.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.gridCol选择,
            this.gridCol仓库编码,
            this.gridCol仓库名称,
            this.gridCol货位编码,
            this.gridCol货位名称});
            this.gridView1.GridControl = this.grdDetail;
            this.gridView1.IndicatorWidth = 40;
            this.gridView1.Name = "gridView1";
            this.gridView1.OptionsBehavior.AllowDeleteRows = DevExpress.Utils.DefaultBoolean.True;
            this.gridView1.OptionsBehavior.EditorShowMode = DevExpress.Utils.EditorShowMode.MouseDown;
            this.gridView1.OptionsCustomization.AllowGroup = false;
            this.gridView1.OptionsCustomization.AllowQuickHideColumns = false;
            this.gridView1.OptionsView.ColumnAutoWidth = false;
            this.gridView1.OptionsView.ShowGroupPanel = false;
            this.gridView1.CustomDrawRowIndicator += new DevExpress.XtraGrid.Views.Grid.RowIndicatorCustomDrawEventHandler(this.gridView1_CustomDrawRowIndicator);
            // 
            // gridCol选择
            // 
            this.gridCol选择.Caption = "选择";
            this.gridCol选择.ColumnEdit = this.ItemChk;
            this.gridCol选择.FieldName = "选择";
            this.gridCol选择.Name = "gridCol选择";
            this.gridCol选择.Visible = true;
            this.gridCol选择.VisibleIndex = 0;
            this.gridCol选择.Width = 46;
            // 
            // ItemChk
            // 
            this.ItemChk.Name = "ItemChk";
            // 
            // gridCol仓库编码
            // 
            this.gridCol仓库编码.Caption = "仓库编码";
            this.gridCol仓库编码.FieldName = "仓库编码";
            this.gridCol仓库编码.Name = "gridCol仓库编码";
            this.gridCol仓库编码.Visible = true;
            this.gridCol仓库编码.VisibleIndex = 1;
            // 
            // gridCol仓库名称
            // 
            this.gridCol仓库名称.Caption = "仓库名称";
            this.gridCol仓库名称.FieldName = "仓库名称";
            this.gridCol仓库名称.Name = "gridCol仓库名称";
            this.gridCol仓库名称.Visible = true;
            this.gridCol仓库名称.VisibleIndex = 2;
            // 
            // gridCol货位编码
            // 
            this.gridCol货位编码.Caption = "货位编码";
            this.gridCol货位编码.FieldName = "货位编码";
            this.gridCol货位编码.Name = "gridCol货位编码";
            this.gridCol货位编码.Visible = true;
            this.gridCol货位编码.VisibleIndex = 3;
            // 
            // gridCol货位名称
            // 
            this.gridCol货位名称.Caption = "货位名称";
            this.gridCol货位名称.FieldName = "货位名称";
            this.gridCol货位名称.Name = "gridCol货位名称";
            this.gridCol货位名称.Visible = true;
            this.gridCol货位名称.VisibleIndex = 4;
            // 
            // ItemLookUpEdit存货编码
            // 
            this.ItemLookUpEdit存货编码.AutoHeight = false;
            this.ItemLookUpEdit存货编码.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.ItemLookUpEdit存货编码.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("cInvCode", "存货编码"),
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("cInvName", "存货名称"),
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("cInvStd", "规格型号")});
            this.ItemLookUpEdit存货编码.DisplayMember = "cInvCode";
            this.ItemLookUpEdit存货编码.Name = "ItemLookUpEdit存货编码";
            this.ItemLookUpEdit存货编码.ValueMember = "cInvCode";
            // 
            // ItemLookUpEdit存货名称
            // 
            this.ItemLookUpEdit存货名称.AutoHeight = false;
            this.ItemLookUpEdit存货名称.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.ItemLookUpEdit存货名称.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("cInvCode", "存货编码"),
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("cInvName", "存货名称"),
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("cInvStd", "规格型号")});
            this.ItemLookUpEdit存货名称.DisplayMember = "cInvName";
            this.ItemLookUpEdit存货名称.Name = "ItemLookUpEdit存货名称";
            this.ItemLookUpEdit存货名称.ValueMember = "cInvCode";
            // 
            // ItemLookUpEdit规格型号
            // 
            this.ItemLookUpEdit规格型号.AutoHeight = false;
            this.ItemLookUpEdit规格型号.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.ItemLookUpEdit规格型号.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("cInvCode", "存货编码"),
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("cInvName", "存货名称"),
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("cInvStd", "规格型号")});
            this.ItemLookUpEdit规格型号.DisplayMember = "cInvStd";
            this.ItemLookUpEdit规格型号.Name = "ItemLookUpEdit规格型号";
            this.ItemLookUpEdit规格型号.ValueMember = "cInvCode";
            // 
            // 货位标签打印
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.btn清空);
            this.Controls.Add(this.chk全选);
            this.Controls.Add(this.btnPrint);
            this.Controls.Add(this.labelControl1);
            this.Controls.Add(this.btnSel);
            this.Controls.Add(this.grdDetail);
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "货位标签打印";
            this.Size = new System.Drawing.Size(843, 663);
            this.Load += new System.EventHandler(this.ProjectManager_Load);
            ((System.ComponentModel.ISupportInitialize)(this.grdDetail)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ItemChk)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ItemLookUpEdit存货编码)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ItemLookUpEdit存货名称)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ItemLookUpEdit规格型号)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraEditors.SimpleButton btnSel;
        private DevExpress.XtraGrid.GridControl grdDetail;
        private DevExpress.XtraEditors.LabelControl labelControl1;
        private DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit ItemChk;
        private DevExpress.XtraEditors.SimpleButton btnPrint;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView1;
        private DevExpress.XtraGrid.Columns.GridColumn gridCol选择;
        private DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit ItemLookUpEdit存货编码;
        private DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit ItemLookUpEdit存货名称;
        private DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit ItemLookUpEdit规格型号;
        private DevExpress.XtraEditors.SimpleButton btn清空;
        private System.Windows.Forms.CheckBox chk全选;
        private DevExpress.XtraGrid.Columns.GridColumn gridCol仓库编码;
        private DevExpress.XtraGrid.Columns.GridColumn gridCol仓库名称;
        private DevExpress.XtraGrid.Columns.GridColumn gridCol货位编码;
        private DevExpress.XtraGrid.Columns.GridColumn gridCol货位名称;
    }
}
