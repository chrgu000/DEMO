﻿namespace UFIDA.U8.UAP.CustomApp.ControlForm
{
    partial class GL_Code
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
            this.btnAddRow = new System.Windows.Forms.ToolStripMenuItem();
            this.btnSave = new System.Windows.Forms.ToolStripMenuItem();
            this.删除ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.gridControl1 = new DevExpress.XtraGrid.GridControl();
            this.gridView1 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.gridColchoose = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridCol会计科目 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.ItemLookUpEdit科目编码 = new DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit();
            this.gridColccode_name = new DevExpress.XtraGrid.Columns.GridColumn();
            this.ItemLookUpEdit科目名称 = new DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit();
            this.gridCol对照科目 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColRemark = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColRemarkJ = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColRemarkD = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColiID = new DevExpress.XtraGrid.Columns.GridColumn();
            this.panel1 = new System.Windows.Forms.Panel();
            this.lookUpEditiYear = new DevExpress.XtraEditors.LookUpEdit();
            this.label1 = new System.Windows.Forms.Label();
            this.menuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ItemLookUpEdit科目编码)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ItemLookUpEdit科目名称)).BeginInit();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.lookUpEditiYear.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btnSEL,
            this.btnAddRow,
            this.btnSave,
            this.删除ToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(661, 24);
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
            // btnAddRow
            // 
            this.btnAddRow.Name = "btnAddRow";
            this.btnAddRow.Size = new System.Drawing.Size(41, 20);
            this.btnAddRow.Text = "增行";
            this.btnAddRow.Click += new System.EventHandler(this.btnAddRow_Click);
            // 
            // btnSave
            // 
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(41, 20);
            this.btnSave.Text = "保存";
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // 删除ToolStripMenuItem
            // 
            this.删除ToolStripMenuItem.Name = "删除ToolStripMenuItem";
            this.删除ToolStripMenuItem.Size = new System.Drawing.Size(41, 20);
            this.删除ToolStripMenuItem.Text = "删除";
            this.删除ToolStripMenuItem.Click += new System.EventHandler(this.删除ToolStripMenuItem_Click);
            // 
            // gridControl1
            // 
            this.gridControl1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.gridControl1.Location = new System.Drawing.Point(3, 34);
            this.gridControl1.LookAndFeel.SkinName = "Office 2010 Blue";
            this.gridControl1.MainView = this.gridView1;
            this.gridControl1.Name = "gridControl1";
            this.gridControl1.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.ItemLookUpEdit科目编码,
            this.ItemLookUpEdit科目名称});
            this.gridControl1.Size = new System.Drawing.Size(655, 288);
            this.gridControl1.TabIndex = 191;
            this.gridControl1.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView1});
            // 
            // gridView1
            // 
            this.gridView1.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.gridColchoose,
            this.gridCol会计科目,
            this.gridColccode_name,
            this.gridCol对照科目,
            this.gridColRemark,
            this.gridColRemarkJ,
            this.gridColRemarkD,
            this.gridColiID});
            this.gridView1.GridControl = this.gridControl1;
            this.gridView1.IndicatorWidth = 40;
            this.gridView1.Name = "gridView1";
            this.gridView1.OptionsBehavior.AllowDeleteRows = DevExpress.Utils.DefaultBoolean.True;
            this.gridView1.OptionsBehavior.EditorShowMode = DevExpress.Utils.EditorShowMode.MouseDown;
            this.gridView1.OptionsCustomization.AllowGroup = false;
            this.gridView1.OptionsCustomization.AllowQuickHideColumns = false;
            this.gridView1.OptionsCustomization.AllowSort = false;
            this.gridView1.OptionsNavigation.EnterMoveNextColumn = true;
            this.gridView1.OptionsPrint.AutoWidth = false;
            this.gridView1.OptionsView.ColumnAutoWidth = false;
            this.gridView1.OptionsView.ShowFooter = true;
            this.gridView1.OptionsView.ShowGroupPanel = false;
            this.gridView1.CustomDrawRowIndicator += new DevExpress.XtraGrid.Views.Grid.RowIndicatorCustomDrawEventHandler(this.gridView1_CustomDrawRowIndicator);
            this.gridView1.CellValueChanged += new DevExpress.XtraGrid.Views.Base.CellValueChangedEventHandler(this.gridView1_CellValueChanged);
            // 
            // gridColchoose
            // 
            this.gridColchoose.AppearanceHeader.Options.UseTextOptions = true;
            this.gridColchoose.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gridColchoose.Caption = "选择";
            this.gridColchoose.FieldName = "choose";
            this.gridColchoose.Name = "gridColchoose";
            this.gridColchoose.Visible = true;
            this.gridColchoose.VisibleIndex = 0;
            this.gridColchoose.Width = 53;
            // 
            // gridCol会计科目
            // 
            this.gridCol会计科目.Caption = "会计科目";
            this.gridCol会计科目.ColumnEdit = this.ItemLookUpEdit科目编码;
            this.gridCol会计科目.FieldName = "会计科目";
            this.gridCol会计科目.Name = "gridCol会计科目";
            this.gridCol会计科目.Visible = true;
            this.gridCol会计科目.VisibleIndex = 1;
            this.gridCol会计科目.Width = 121;
            // 
            // ItemLookUpEdit科目编码
            // 
            this.ItemLookUpEdit科目编码.AutoHeight = false;
            this.ItemLookUpEdit科目编码.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.ItemLookUpEdit科目编码.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("ccode", "ccode")});
            this.ItemLookUpEdit科目编码.DisplayMember = "ccode";
            this.ItemLookUpEdit科目编码.Name = "ItemLookUpEdit科目编码";
            this.ItemLookUpEdit科目编码.NullText = "";
            this.ItemLookUpEdit科目编码.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.Standard;
            this.ItemLookUpEdit科目编码.ValueMember = "ccode";
            // 
            // gridColccode_name
            // 
            this.gridColccode_name.Caption = "科目名称";
            this.gridColccode_name.ColumnEdit = this.ItemLookUpEdit科目名称;
            this.gridColccode_name.FieldName = "会计科目";
            this.gridColccode_name.Name = "gridColccode_name";
            this.gridColccode_name.OptionsColumn.AllowEdit = false;
            this.gridColccode_name.Visible = true;
            this.gridColccode_name.VisibleIndex = 2;
            this.gridColccode_name.Width = 154;
            // 
            // ItemLookUpEdit科目名称
            // 
            this.ItemLookUpEdit科目名称.AutoHeight = false;
            this.ItemLookUpEdit科目名称.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.ItemLookUpEdit科目名称.DisplayMember = "ccode_name";
            this.ItemLookUpEdit科目名称.Name = "ItemLookUpEdit科目名称";
            this.ItemLookUpEdit科目名称.NullText = "";
            this.ItemLookUpEdit科目名称.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.Standard;
            this.ItemLookUpEdit科目名称.ValueMember = "ccode";
            // 
            // gridCol对照科目
            // 
            this.gridCol对照科目.Caption = "对照科目";
            this.gridCol对照科目.FieldName = "对照科目";
            this.gridCol对照科目.Name = "gridCol对照科目";
            this.gridCol对照科目.Visible = true;
            this.gridCol对照科目.VisibleIndex = 3;
            this.gridCol对照科目.Width = 187;
            // 
            // gridColRemark
            // 
            this.gridColRemark.Caption = "备注";
            this.gridColRemark.FieldName = "Remark";
            this.gridColRemark.Name = "gridColRemark";
            this.gridColRemark.Visible = true;
            this.gridColRemark.VisibleIndex = 6;
            this.gridColRemark.Width = 117;
            // 
            // gridColRemarkJ
            // 
            this.gridColRemarkJ.Caption = "借方摘要";
            this.gridColRemarkJ.FieldName = "RemarkJ";
            this.gridColRemarkJ.Name = "gridColRemarkJ";
            this.gridColRemarkJ.Visible = true;
            this.gridColRemarkJ.VisibleIndex = 4;
            this.gridColRemarkJ.Width = 104;
            // 
            // gridColRemarkD
            // 
            this.gridColRemarkD.Caption = "贷方摘要";
            this.gridColRemarkD.FieldName = "RemarkD";
            this.gridColRemarkD.Name = "gridColRemarkD";
            this.gridColRemarkD.Visible = true;
            this.gridColRemarkD.VisibleIndex = 5;
            this.gridColRemarkD.Width = 91;
            // 
            // gridColiID
            // 
            this.gridColiID.Caption = "iID";
            this.gridColiID.FieldName = "iID";
            this.gridColiID.Name = "gridColiID";
            this.gridColiID.OptionsColumn.AllowEdit = false;
            // 
            // panel1
            // 
            this.panel1.AutoScroll = true;
            this.panel1.Controls.Add(this.lookUpEditiYear);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.gridControl1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 24);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(661, 322);
            this.panel1.TabIndex = 173;
            // 
            // lookUpEditiYear
            // 
            this.lookUpEditiYear.Location = new System.Drawing.Point(69, 8);
            this.lookUpEditiYear.Name = "lookUpEditiYear";
            this.lookUpEditiYear.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.lookUpEditiYear.Properties.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("iYear", "年度")});
            this.lookUpEditiYear.Properties.DisplayMember = "iYear";
            this.lookUpEditiYear.Properties.NullText = "";
            this.lookUpEditiYear.Properties.ValueMember = "iYear";
            this.lookUpEditiYear.Size = new System.Drawing.Size(105, 20);
            this.lookUpEditiYear.TabIndex = 196;
            this.lookUpEditiYear.EditValueChanged += new System.EventHandler(this.lookUpEditiYear_EditValueChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 10);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(29, 12);
            this.label1.TabIndex = 195;
            this.label1.Text = "年度";
            // 
            // GL_Code
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.menuStrip1);
            this.Name = "GL_Code";
            this.Size = new System.Drawing.Size(661, 346);
            this.Load += new System.EventHandler(this.Frm_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ItemLookUpEdit科目编码)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ItemLookUpEdit科目名称)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.lookUpEditiYear.Properties)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem btnSave;
        private DevExpress.XtraGrid.GridControl gridControl1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.ToolStripMenuItem btnSEL;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView1;
        private DevExpress.XtraGrid.Columns.GridColumn gridColchoose;
        private DevExpress.XtraGrid.Columns.GridColumn gridCol会计科目;
        private DevExpress.XtraGrid.Columns.GridColumn gridColccode_name;
        private DevExpress.XtraGrid.Columns.GridColumn gridCol对照科目;
        private System.Windows.Forms.Label label1;
        private DevExpress.XtraEditors.LookUpEdit lookUpEditiYear;
        private System.Windows.Forms.ToolStripMenuItem 删除ToolStripMenuItem;
        private DevExpress.XtraGrid.Columns.GridColumn gridColRemark;
        private DevExpress.XtraGrid.Columns.GridColumn gridColiID;
        private DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit ItemLookUpEdit科目编码;
        private DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit ItemLookUpEdit科目名称;
        private System.Windows.Forms.ToolStripMenuItem btnAddRow;
        private DevExpress.XtraGrid.Columns.GridColumn gridColRemarkD;
        private DevExpress.XtraGrid.Columns.GridColumn gridColRemarkJ;
    }
}
