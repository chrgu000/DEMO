namespace UFIDA.U8.UAP.CustomApp.ControlForm
{
    partial class DeptDuty
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
            this.btnDEL = new System.Windows.Forms.ToolStripMenuItem();
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            this.gridControl1 = new DevExpress.XtraGrid.GridControl();
            this.gridView1 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.gridColbChoose = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColcDept_num = new DevExpress.XtraGrid.Columns.GridColumn();
            this.ItemLookUpEditcDept_num = new DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit();
            this.gridColcDutyCode = new DevExpress.XtraGrid.Columns.GridColumn();
            this.ItemLookUpEditcDutyCode = new DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit();
            this.gridColiID = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColsState = new DevExpress.XtraGrid.Columns.GridColumn();
            this.panel1 = new System.Windows.Forms.Panel();
            this.chkAll = new System.Windows.Forms.CheckBox();
            this.menuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ItemLookUpEditcDept_num)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ItemLookUpEditcDutyCode)).BeginInit();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btnSEL,
            this.btnSave,
            this.btnDEL});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(975, 24);
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
            // btnDEL
            // 
            this.btnDEL.Name = "btnDEL";
            this.btnDEL.Size = new System.Drawing.Size(41, 20);
            this.btnDEL.Text = "删除";
            this.btnDEL.Click += new System.EventHandler(this.btnDEL_Click);
            // 
            // labelControl1
            // 
            this.labelControl1.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.labelControl1.Appearance.Font = new System.Drawing.Font("Tahoma", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelControl1.Location = new System.Drawing.Point(428, 3);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(147, 25);
            this.labelControl1.TabIndex = 190;
            this.labelControl1.Text = "部门班次对应表";
            // 
            // gridControl1
            // 
            this.gridControl1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.gridControl1.Location = new System.Drawing.Point(3, 44);
            this.gridControl1.LookAndFeel.SkinName = "Office 2010 Blue";
            this.gridControl1.MainView = this.gridView1;
            this.gridControl1.Name = "gridControl1";
            this.gridControl1.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.ItemLookUpEditcDutyCode,
            this.ItemLookUpEditcDept_num});
            this.gridControl1.Size = new System.Drawing.Size(969, 319);
            this.gridControl1.TabIndex = 191;
            this.gridControl1.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView1});
            // 
            // gridView1
            // 
            this.gridView1.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.gridColbChoose,
            this.gridColcDept_num,
            this.gridColcDutyCode,
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
            this.gridView1.FocusedRowChanged += new DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventHandler(this.gridView1_FocusedRowChanged);
            this.gridView1.CustomDrawRowIndicator += new DevExpress.XtraGrid.Views.Grid.RowIndicatorCustomDrawEventHandler(this.gridView1_CustomDrawRowIndicator);
            this.gridView1.CellValueChanged += new DevExpress.XtraGrid.Views.Base.CellValueChangedEventHandler(this.gridView1_CellValueChanged);
            // 
            // gridColbChoose
            // 
            this.gridColbChoose.Caption = "选择";
            this.gridColbChoose.FieldName = "bChoose";
            this.gridColbChoose.Name = "gridColbChoose";
            this.gridColbChoose.Visible = true;
            this.gridColbChoose.VisibleIndex = 0;
            this.gridColbChoose.Width = 40;
            // 
            // gridColcDept_num
            // 
            this.gridColcDept_num.Caption = "部门";
            this.gridColcDept_num.ColumnEdit = this.ItemLookUpEditcDept_num;
            this.gridColcDept_num.FieldName = "cDept_num";
            this.gridColcDept_num.Name = "gridColcDept_num";
            this.gridColcDept_num.Visible = true;
            this.gridColcDept_num.VisibleIndex = 1;
            this.gridColcDept_num.Width = 157;
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
            // gridColcDutyCode
            // 
            this.gridColcDutyCode.Caption = "班次";
            this.gridColcDutyCode.ColumnEdit = this.ItemLookUpEditcDutyCode;
            this.gridColcDutyCode.FieldName = "cDutyCode";
            this.gridColcDutyCode.Name = "gridColcDutyCode";
            this.gridColcDutyCode.Visible = true;
            this.gridColcDutyCode.VisibleIndex = 2;
            this.gridColcDutyCode.Width = 162;
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
            // panel1
            // 
            this.panel1.AutoScroll = true;
            this.panel1.Controls.Add(this.chkAll);
            this.panel1.Controls.Add(this.gridControl1);
            this.panel1.Controls.Add(this.labelControl1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 24);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(975, 366);
            this.panel1.TabIndex = 173;
            // 
            // chkAll
            // 
            this.chkAll.AutoSize = true;
            this.chkAll.Location = new System.Drawing.Point(29, 23);
            this.chkAll.Margin = new System.Windows.Forms.Padding(2);
            this.chkAll.Name = "chkAll";
            this.chkAll.Size = new System.Drawing.Size(96, 16);
            this.chkAll.TabIndex = 192;
            this.chkAll.Text = "Selected All";
            this.chkAll.UseVisualStyleBackColor = true;
            this.chkAll.CheckedChanged += new System.EventHandler(this.chkAll_CheckedChanged);
            // 
            // DeptDuty
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.menuStrip1);
            this.Name = "DeptDuty";
            this.Size = new System.Drawing.Size(975, 390);
            this.Load += new System.EventHandler(this.Frm_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ItemLookUpEditcDept_num)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ItemLookUpEditcDutyCode)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem btnDEL;
        private DevExpress.XtraEditors.LabelControl labelControl1;
        private DevExpress.XtraGrid.GridControl gridControl1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.ToolStripMenuItem btnSEL;
        private System.Windows.Forms.ToolStripMenuItem btnSave;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView1;
        private DevExpress.XtraGrid.Columns.GridColumn gridColcDept_num;
        private DevExpress.XtraGrid.Columns.GridColumn gridColcDutyCode;
        private DevExpress.XtraGrid.Columns.GridColumn gridColbChoose;
        private System.Windows.Forms.CheckBox chkAll;
        private DevExpress.XtraGrid.Columns.GridColumn gridColiID;
        private DevExpress.XtraGrid.Columns.GridColumn gridColsState;
        private DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit ItemLookUpEditcDutyCode;
        private DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit ItemLookUpEditcDept_num;
    }
}
