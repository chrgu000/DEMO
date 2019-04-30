namespace UFIDA.U8.UAP.CustomApp.ControlForm
{
    partial class WorkAttendance
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
            this.btnQuery = new System.Windows.Forms.ToolStripMenuItem();
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            this.panel1 = new System.Windows.Forms.Panel();
            this.gridControl1 = new DevExpress.XtraGrid.GridControl();
            this.gridView1 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.gridColDate = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColDutyCode = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColDutyPepoleNames = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColiID = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColsState = new DevExpress.XtraGrid.Columns.GridColumn();
            this.ItemLookUpEditcDutyCode = new DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit();
            this.ItemLookUpEditcDept_num = new DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit();
            this.txt年度 = new DevExpress.XtraEditors.TextEdit();
            this.label3 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.lookUpEdit月份 = new DevExpress.XtraEditors.LookUpEdit();
            this.label4 = new System.Windows.Forms.Label();
            this.lookUpEdit部门 = new DevExpress.XtraEditors.LookUpEdit();
            this.txt单据号 = new DevExpress.XtraEditors.TextEdit();
            this.label2 = new System.Windows.Forms.Label();
            this.menuStrip1.SuspendLayout();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ItemLookUpEditcDutyCode)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ItemLookUpEditcDept_num)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txt年度.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lookUpEdit月份.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lookUpEdit部门.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txt单据号.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btnQuery});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(903, 24);
            this.menuStrip1.TabIndex = 172;
            this.menuStrip1.Text = "menuStrip";
            // 
            // btnQuery
            // 
            this.btnQuery.Name = "btnQuery";
            this.btnQuery.Size = new System.Drawing.Size(41, 20);
            this.btnQuery.Text = "生成";
            this.btnQuery.Click += new System.EventHandler(this.btnQuery_Click);
            // 
            // labelControl1
            // 
            this.labelControl1.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.labelControl1.Appearance.Font = new System.Drawing.Font("Tahoma", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelControl1.Location = new System.Drawing.Point(406, 14);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(126, 25);
            this.labelControl1.TabIndex = 190;
            this.labelControl1.Text = "排班数据生成";
            // 
            // panel1
            // 
            this.panel1.AutoScroll = true;
            this.panel1.Controls.Add(this.gridControl1);
            this.panel1.Controls.Add(this.txt年度);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.lookUpEdit月份);
            this.panel1.Controls.Add(this.label4);
            this.panel1.Controls.Add(this.lookUpEdit部门);
            this.panel1.Controls.Add(this.txt单据号);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.labelControl1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 24);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(903, 394);
            this.panel1.TabIndex = 173;
            // 
            // gridControl1
            // 
            this.gridControl1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.gridControl1.Location = new System.Drawing.Point(3, 75);
            this.gridControl1.LookAndFeel.SkinName = "Office 2010 Blue";
            this.gridControl1.MainView = this.gridView1;
            this.gridControl1.Name = "gridControl1";
            this.gridControl1.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.ItemLookUpEditcDutyCode,
            this.ItemLookUpEditcDept_num});
            this.gridControl1.Size = new System.Drawing.Size(897, 319);
            this.gridControl1.TabIndex = 233;
            this.gridControl1.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView1});
            // 
            // gridView1
            // 
            this.gridView1.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.gridColDate,
            this.gridColDutyCode,
            this.gridColDutyPepoleNames,
            this.gridColiID,
            this.gridColsState});
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
            // 
            // gridColDate
            // 
            this.gridColDate.Caption = "日期";
            this.gridColDate.FieldName = "Date";
            this.gridColDate.Name = "gridColDate";
            this.gridColDate.Visible = true;
            this.gridColDate.VisibleIndex = 0;
            this.gridColDate.Width = 92;
            // 
            // gridColDutyCode
            // 
            this.gridColDutyCode.Caption = "班次";
            this.gridColDutyCode.FieldName = "vDutyName";
            this.gridColDutyCode.Name = "gridColDutyCode";
            this.gridColDutyCode.Visible = true;
            this.gridColDutyCode.VisibleIndex = 1;
            this.gridColDutyCode.Width = 157;
            // 
            // gridColDutyPepoleNames
            // 
            this.gridColDutyPepoleNames.Caption = "人员";
            this.gridColDutyPepoleNames.FieldName = "DutyPepoleNames";
            this.gridColDutyPepoleNames.Name = "gridColDutyPepoleNames";
            this.gridColDutyPepoleNames.Visible = true;
            this.gridColDutyPepoleNames.VisibleIndex = 2;
            this.gridColDutyPepoleNames.Width = 162;
            // 
            // gridColiID
            // 
            this.gridColiID.Caption = "gridColiID";
            this.gridColiID.FieldName = "iID";
            this.gridColiID.Name = "gridColiID";
            this.gridColiID.OptionsColumn.AllowEdit = false;
            this.gridColiID.OptionsColumn.ReadOnly = true;
            // 
            // gridColsState
            // 
            this.gridColsState.Caption = "sState";
            this.gridColsState.FieldName = "sState";
            this.gridColsState.Name = "gridColsState";
            this.gridColsState.OptionsColumn.AllowEdit = false;
            this.gridColsState.OptionsColumn.ReadOnly = true;
            // 
            // ItemLookUpEditcDutyCode
            // 
            this.ItemLookUpEditcDutyCode.AutoHeight = false;
            this.ItemLookUpEditcDutyCode.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.ItemLookUpEditcDutyCode.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("cDutyCode", "班次编码"),
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("vDutyName", "班次名称")});
            this.ItemLookUpEditcDutyCode.DisplayMember = "vDutyName";
            this.ItemLookUpEditcDutyCode.Name = "ItemLookUpEditcDutyCode";
            this.ItemLookUpEditcDutyCode.NullText = "";
            this.ItemLookUpEditcDutyCode.ValueMember = "cDutyCode";
            // 
            // ItemLookUpEditcDept_num
            // 
            this.ItemLookUpEditcDept_num.AutoHeight = false;
            this.ItemLookUpEditcDept_num.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.ItemLookUpEditcDept_num.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("cDepCode", "部门编码"),
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("cDepName", "部门名称")});
            this.ItemLookUpEditcDept_num.DisplayMember = "cDepName";
            this.ItemLookUpEditcDept_num.Name = "ItemLookUpEditcDept_num";
            this.ItemLookUpEditcDept_num.NullText = "";
            this.ItemLookUpEditcDept_num.ValueMember = "cDepCode";
            // 
            // txt年度
            // 
            this.txt年度.Location = new System.Drawing.Point(393, 45);
            this.txt年度.Name = "txt年度";
            this.txt年度.Size = new System.Drawing.Size(66, 20);
            this.txt年度.TabIndex = 232;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(348, 48);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(29, 12);
            this.label3.TabIndex = 231;
            this.label3.Text = "年度";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(484, 50);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(29, 12);
            this.label1.TabIndex = 230;
            this.label1.Text = "月份";
            // 
            // lookUpEdit月份
            // 
            this.lookUpEdit月份.Location = new System.Drawing.Point(519, 45);
            this.lookUpEdit月份.Name = "lookUpEdit月份";
            this.lookUpEdit月份.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.lookUpEdit月份.Properties.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("iID", "月份")});
            this.lookUpEdit月份.Properties.DisplayMember = "iID";
            this.lookUpEdit月份.Properties.NullText = "";
            this.lookUpEdit月份.Properties.ValueMember = "iID";
            this.lookUpEdit月份.Size = new System.Drawing.Size(72, 20);
            this.lookUpEdit月份.TabIndex = 229;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(179, 50);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(29, 12);
            this.label4.TabIndex = 228;
            this.label4.Text = "部门";
            // 
            // lookUpEdit部门
            // 
            this.lookUpEdit部门.Location = new System.Drawing.Point(214, 45);
            this.lookUpEdit部门.Name = "lookUpEdit部门";
            this.lookUpEdit部门.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.lookUpEdit部门.Properties.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("cDepCode", "部门编码"),
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("cDepName", "部门名称")});
            this.lookUpEdit部门.Properties.DisplayMember = "cDepName";
            this.lookUpEdit部门.Properties.NullText = "";
            this.lookUpEdit部门.Properties.ValueMember = "cDepCode";
            this.lookUpEdit部门.Size = new System.Drawing.Size(100, 20);
            this.lookUpEdit部门.TabIndex = 227;
            // 
            // txt单据号
            // 
            this.txt单据号.Location = new System.Drawing.Point(65, 45);
            this.txt单据号.Name = "txt单据号";
            this.txt单据号.Size = new System.Drawing.Size(87, 20);
            this.txt单据号.TabIndex = 226;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(18, 50);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(41, 12);
            this.label2.TabIndex = 225;
            this.label2.Text = "单据号";
            // 
            // WorkAttendance
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.menuStrip1);
            this.Name = "WorkAttendance";
            this.Size = new System.Drawing.Size(903, 418);
            this.Load += new System.EventHandler(this.Frm_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ItemLookUpEditcDutyCode)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ItemLookUpEditcDept_num)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txt年度.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lookUpEdit月份.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lookUpEdit部门.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txt单据号.Properties)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private DevExpress.XtraEditors.LabelControl labelControl1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.ToolStripMenuItem btnQuery;
        private System.Windows.Forms.Label label4;
        private DevExpress.XtraEditors.LookUpEdit lookUpEdit部门;
        private DevExpress.XtraEditors.TextEdit txt单据号;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private DevExpress.XtraEditors.LookUpEdit lookUpEdit月份;
        private DevExpress.XtraEditors.TextEdit txt年度;
        private System.Windows.Forms.Label label3;
        private DevExpress.XtraGrid.GridControl gridControl1;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView1;
        private DevExpress.XtraGrid.Columns.GridColumn gridColDate;
        private DevExpress.XtraGrid.Columns.GridColumn gridColDutyCode;
        private DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit ItemLookUpEditcDept_num;
        private DevExpress.XtraGrid.Columns.GridColumn gridColDutyPepoleNames;
        private DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit ItemLookUpEditcDutyCode;
        private DevExpress.XtraGrid.Columns.GridColumn gridColiID;
        private DevExpress.XtraGrid.Columns.GridColumn gridColsState;
    }
}
