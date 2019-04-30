namespace UFIDA.U8.UAP.CustomApp.ControlForm
{
    partial class 标准工时
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
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            this.gridControl1 = new DevExpress.XtraGrid.GridControl();
            this.gridView1 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.gridColiPlanCOID = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColcDeptID = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColcDepName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColInvCode = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColcInvName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColcInvStd = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColiQuo = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColGS = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColisRight = new DevExpress.XtraGrid.Columns.GridColumn();
            this.ItemLookUpEditcType = new DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit();
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnExcel = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ItemLookUpEditcType)).BeginInit();
            this.panel1.SuspendLayout();
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
            this.menuStrip1.Padding = new System.Windows.Forms.Padding(8, 2, 0, 2);
            this.menuStrip1.Size = new System.Drawing.Size(1300, 28);
            this.menuStrip1.TabIndex = 172;
            this.menuStrip1.Text = "menuStrip";
            // 
            // btnSEL
            // 
            this.btnSEL.Name = "btnSEL";
            this.btnSEL.Size = new System.Drawing.Size(51, 24);
            this.btnSEL.Text = "加载";
            this.btnSEL.Click += new System.EventHandler(this.btnSEL_Click);
            // 
            // btnSave
            // 
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(51, 24);
            this.btnSave.Text = "保存";
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // labelControl1
            // 
            this.labelControl1.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.labelControl1.Appearance.Font = new System.Drawing.Font("Tahoma", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelControl1.Location = new System.Drawing.Point(571, 4);
            this.labelControl1.Margin = new System.Windows.Forms.Padding(4);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(162, 33);
            this.labelControl1.TabIndex = 190;
            this.labelControl1.Text = "定额工时维护";
            // 
            // gridControl1
            // 
            this.gridControl1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.gridControl1.EmbeddedNavigator.Margin = new System.Windows.Forms.Padding(4);
            this.gridControl1.Location = new System.Drawing.Point(4, 55);
            this.gridControl1.LookAndFeel.SkinName = "Office 2010 Blue";
            this.gridControl1.MainView = this.gridView1;
            this.gridControl1.Margin = new System.Windows.Forms.Padding(4);
            this.gridControl1.Name = "gridControl1";
            this.gridControl1.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.ItemLookUpEditcType});
            this.gridControl1.Size = new System.Drawing.Size(1292, 401);
            this.gridControl1.TabIndex = 191;
            this.gridControl1.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView1});
            // 
            // gridView1
            // 
            this.gridView1.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.gridColiPlanCOID,
            this.gridColcDeptID,
            this.gridColcDepName,
            this.gridColInvCode,
            this.gridColcInvName,
            this.gridColcInvStd,
            this.gridColiQuo,
            this.gridColGS,
            this.gridColisRight});
            this.gridView1.GridControl = this.gridControl1;
            this.gridView1.IndicatorWidth = 40;
            this.gridView1.Name = "gridView1";
            this.gridView1.OptionsBehavior.AllowDeleteRows = DevExpress.Utils.DefaultBoolean.True;
            this.gridView1.OptionsBehavior.EditorShowMode = DevExpress.Utils.EditorShowMode.MouseDown;
            this.gridView1.OptionsCustomization.AllowGroup = false;
            this.gridView1.OptionsCustomization.AllowQuickHideColumns = false;
            this.gridView1.OptionsCustomization.AllowSort = false;
            this.gridView1.OptionsNavigation.EnterMoveNextColumn = true;
            this.gridView1.OptionsView.ColumnAutoWidth = false;
            this.gridView1.OptionsView.ShowFooter = true;
            this.gridView1.OptionsView.ShowGroupPanel = false;
            this.gridView1.CustomDrawRowIndicator += new DevExpress.XtraGrid.Views.Grid.RowIndicatorCustomDrawEventHandler(this.gridView1_CustomDrawRowIndicator);
            this.gridView1.RowCellStyle += new DevExpress.XtraGrid.Views.Grid.RowCellStyleEventHandler(this.gridView1_RowCellStyle);
            // 
            // gridColiPlanCOID
            // 
            this.gridColiPlanCOID.Caption = "iPlanCOID";
            this.gridColiPlanCOID.FieldName = "iPlanCOID";
            this.gridColiPlanCOID.Name = "gridColiPlanCOID";
            this.gridColiPlanCOID.OptionsColumn.AllowEdit = false;
            this.gridColiPlanCOID.Visible = true;
            this.gridColiPlanCOID.VisibleIndex = 8;
            // 
            // gridColcDeptID
            // 
            this.gridColcDeptID.Caption = "部门编码";
            this.gridColcDeptID.FieldName = "cDeptID";
            this.gridColcDeptID.Name = "gridColcDeptID";
            this.gridColcDeptID.OptionsColumn.AllowEdit = false;
            this.gridColcDeptID.Visible = true;
            this.gridColcDeptID.VisibleIndex = 6;
            // 
            // gridColcDepName
            // 
            this.gridColcDepName.Caption = "部门";
            this.gridColcDepName.FieldName = "cDepName";
            this.gridColcDepName.Name = "gridColcDepName";
            this.gridColcDepName.OptionsColumn.AllowEdit = false;
            this.gridColcDepName.Visible = true;
            this.gridColcDepName.VisibleIndex = 7;
            // 
            // gridColInvCode
            // 
            this.gridColInvCode.Caption = "存货编码";
            this.gridColInvCode.FieldName = "InvCode";
            this.gridColInvCode.Fixed = DevExpress.XtraGrid.Columns.FixedStyle.Left;
            this.gridColInvCode.Name = "gridColInvCode";
            this.gridColInvCode.OptionsColumn.AllowEdit = false;
            this.gridColInvCode.Visible = true;
            this.gridColInvCode.VisibleIndex = 0;
            this.gridColInvCode.Width = 127;
            // 
            // gridColcInvName
            // 
            this.gridColcInvName.Caption = "存货名称";
            this.gridColcInvName.FieldName = "cInvName";
            this.gridColcInvName.Name = "gridColcInvName";
            this.gridColcInvName.OptionsColumn.AllowEdit = false;
            this.gridColcInvName.Visible = true;
            this.gridColcInvName.VisibleIndex = 1;
            this.gridColcInvName.Width = 221;
            // 
            // gridColcInvStd
            // 
            this.gridColcInvStd.Caption = "规格型号";
            this.gridColcInvStd.FieldName = "cInvStd";
            this.gridColcInvStd.Name = "gridColcInvStd";
            this.gridColcInvStd.OptionsColumn.AllowEdit = false;
            this.gridColcInvStd.Visible = true;
            this.gridColcInvStd.VisibleIndex = 2;
            this.gridColcInvStd.Width = 142;
            // 
            // gridColiQuo
            // 
            this.gridColiQuo.Caption = "U8当前工时";
            this.gridColiQuo.FieldName = "iQuo";
            this.gridColiQuo.Name = "gridColiQuo";
            this.gridColiQuo.OptionsColumn.AllowEdit = false;
            this.gridColiQuo.Summary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] {
            new DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum)});
            this.gridColiQuo.Visible = true;
            this.gridColiQuo.VisibleIndex = 3;
            this.gridColiQuo.Width = 135;
            // 
            // gridColGS
            // 
            this.gridColGS.AppearanceHeader.ForeColor = System.Drawing.Color.Blue;
            this.gridColGS.AppearanceHeader.Options.UseForeColor = true;
            this.gridColGS.Caption = "工序档案定额工时";
            this.gridColGS.FieldName = "GS";
            this.gridColGS.Name = "gridColGS";
            this.gridColGS.OptionsColumn.AllowEdit = false;
            this.gridColGS.Summary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] {
            new DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum)});
            this.gridColGS.Visible = true;
            this.gridColGS.VisibleIndex = 4;
            this.gridColGS.Width = 160;
            // 
            // gridColisRight
            // 
            this.gridColisRight.Caption = "是否一致";
            this.gridColisRight.FieldName = "isRight";
            this.gridColisRight.Name = "gridColisRight";
            this.gridColisRight.Visible = true;
            this.gridColisRight.VisibleIndex = 5;
            // 
            // ItemLookUpEditcType
            // 
            this.ItemLookUpEditcType.AutoHeight = false;
            this.ItemLookUpEditcType.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.ItemLookUpEditcType.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("cType", "编码"),
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("cTypeName", "名称")});
            this.ItemLookUpEditcType.DisplayMember = "cTypeName";
            this.ItemLookUpEditcType.Name = "ItemLookUpEditcType";
            this.ItemLookUpEditcType.NullText = "";
            this.ItemLookUpEditcType.ValueMember = "cType";
            // 
            // panel1
            // 
            this.panel1.AutoScroll = true;
            this.panel1.Controls.Add(this.gridControl1);
            this.panel1.Controls.Add(this.labelControl1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 28);
            this.panel1.Margin = new System.Windows.Forms.Padding(4);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1300, 460);
            this.panel1.TabIndex = 173;
            // 
            // btnExcel
            // 
            this.btnExcel.Name = "btnExcel";
            this.btnExcel.Size = new System.Drawing.Size(88, 24);
            this.btnExcel.Text = "导出Excel";
            this.btnExcel.Click += new System.EventHandler(this.btnExcel_Click);
            // 
            // 标准工时
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.menuStrip1);
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "标准工时";
            this.Size = new System.Drawing.Size(1300, 488);
            this.Load += new System.EventHandler(this.Frm_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ItemLookUpEditcType)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private DevExpress.XtraEditors.LabelControl labelControl1;
        private DevExpress.XtraGrid.GridControl gridControl1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.ToolStripMenuItem btnSEL;
        private System.Windows.Forms.ToolStripMenuItem btnSave;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView1;
        private DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit ItemLookUpEditcType;
        private DevExpress.XtraGrid.Columns.GridColumn gridColiPlanCOID;
        private DevExpress.XtraGrid.Columns.GridColumn gridColcDeptID;
        private DevExpress.XtraGrid.Columns.GridColumn gridColcDepName;
        private DevExpress.XtraGrid.Columns.GridColumn gridColInvCode;
        private DevExpress.XtraGrid.Columns.GridColumn gridColcInvName;
        private DevExpress.XtraGrid.Columns.GridColumn gridColcInvStd;
        private DevExpress.XtraGrid.Columns.GridColumn gridColiQuo;
        private DevExpress.XtraGrid.Columns.GridColumn gridColGS;
        private DevExpress.XtraGrid.Columns.GridColumn gridColisRight;
        private System.Windows.Forms.ToolStripMenuItem btnExcel;
    }
}
