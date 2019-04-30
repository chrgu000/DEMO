namespace UFIDA.U8.UAP.CustomApp.ControlForm
{
    partial class GL_accvouchToJP
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
            this.ItemTextEditn2 = new DevExpress.XtraEditors.Repository.RepositoryItemTextEdit();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.btnSel = new System.Windows.Forms.ToolStripMenuItem();
            this.btnSave = new System.Windows.Forms.ToolStripMenuItem();
            this.panel1 = new System.Windows.Forms.Panel();
            this.chkAll = new System.Windows.Forms.CheckBox();
            this.gridControl1 = new DevExpress.XtraGrid.GridControl();
            this.gridView1 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.gridColbChoose = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColcsignid = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColcdigest = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColmd = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColmc = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColcbill = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColcbook = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColbUsed = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColcsign = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColino_id = new DevExpress.XtraGrid.Columns.GridColumn();
            ((System.ComponentModel.ISupportInitialize)(this.ItemTextEditn2)).BeginInit();
            this.menuStrip1.SuspendLayout();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // ItemTextEditn2
            // 
            this.ItemTextEditn2.AutoHeight = false;
            this.ItemTextEditn2.DisplayFormat.FormatString = "n2";
            this.ItemTextEditn2.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.ItemTextEditn2.EditFormat.FormatString = "n2";
            this.ItemTextEditn2.EditFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.ItemTextEditn2.Mask.EditMask = "n2";
            this.ItemTextEditn2.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Numeric;
            this.ItemTextEditn2.Name = "ItemTextEditn2";
            // 
            // menuStrip1
            // 
            this.menuStrip1.AllowDrop = true;
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btnSel,
            this.btnSave});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(1239, 25);
            this.menuStrip1.TabIndex = 172;
            this.menuStrip1.Text = "menuStrip";
            // 
            // btnSel
            // 
            this.btnSel.Name = "btnSel";
            this.btnSel.Size = new System.Drawing.Size(44, 21);
            this.btnSel.Text = "加载";
            this.btnSel.Click += new System.EventHandler(this.btnSel_Click);
            // 
            // btnSave
            // 
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(44, 21);
            this.btnSave.Text = "保存";
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // panel1
            // 
            this.panel1.AutoScroll = true;
            this.panel1.Controls.Add(this.chkAll);
            this.panel1.Controls.Add(this.gridControl1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 25);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1239, 455);
            this.panel1.TabIndex = 173;
            // 
            // chkAll
            // 
            this.chkAll.AutoSize = true;
            this.chkAll.Location = new System.Drawing.Point(15, 17);
            this.chkAll.Name = "chkAll";
            this.chkAll.Size = new System.Drawing.Size(48, 16);
            this.chkAll.TabIndex = 196;
            this.chkAll.Text = "全选";
            this.chkAll.UseVisualStyleBackColor = true;
            this.chkAll.CheckedChanged += new System.EventHandler(this.chkAll_CheckedChanged);
            // 
            // gridControl1
            // 
            this.gridControl1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.gridControl1.Location = new System.Drawing.Point(3, 42);
            this.gridControl1.LookAndFeel.SkinName = "Office 2010 Blue";
            this.gridControl1.MainView = this.gridView1;
            this.gridControl1.Name = "gridControl1";
            this.gridControl1.Size = new System.Drawing.Size(1233, 410);
            this.gridControl1.TabIndex = 192;
            this.gridControl1.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView1});
            // 
            // gridView1
            // 
            this.gridView1.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.gridColbChoose,
            this.gridColcsignid,
            this.gridColcdigest,
            this.gridColmd,
            this.gridColmc,
            this.gridColcbill,
            this.gridColcbook,
            this.gridColbUsed,
            this.gridColcsign,
            this.gridColino_id});
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
            // 
            // gridColbChoose
            // 
            this.gridColbChoose.Caption = "选择";
            this.gridColbChoose.FieldName = "bChoose";
            this.gridColbChoose.Name = "gridColbChoose";
            this.gridColbChoose.Visible = true;
            this.gridColbChoose.VisibleIndex = 0;
            this.gridColbChoose.Width = 37;
            // 
            // gridColcsignid
            // 
            this.gridColcsignid.Caption = "凭证号";
            this.gridColcsignid.FieldName = "csignid";
            this.gridColcsignid.Name = "gridColcsignid";
            this.gridColcsignid.OptionsColumn.AllowEdit = false;
            this.gridColcsignid.Visible = true;
            this.gridColcsignid.VisibleIndex = 1;
            // 
            // gridColcdigest
            // 
            this.gridColcdigest.Caption = "摘要";
            this.gridColcdigest.FieldName = "cdigest";
            this.gridColcdigest.Name = "gridColcdigest";
            this.gridColcdigest.OptionsColumn.AllowEdit = false;
            this.gridColcdigest.Visible = true;
            this.gridColcdigest.VisibleIndex = 2;
            this.gridColcdigest.Width = 150;
            // 
            // gridColmd
            // 
            this.gridColmd.Caption = "借方金额";
            this.gridColmd.FieldName = "md";
            this.gridColmd.Name = "gridColmd";
            this.gridColmd.OptionsColumn.AllowEdit = false;
            this.gridColmd.Visible = true;
            this.gridColmd.VisibleIndex = 3;
            // 
            // gridColmc
            // 
            this.gridColmc.Caption = "贷方金额";
            this.gridColmc.FieldName = "mc";
            this.gridColmc.Name = "gridColmc";
            this.gridColmc.OptionsColumn.AllowEdit = false;
            this.gridColmc.Visible = true;
            this.gridColmc.VisibleIndex = 4;
            // 
            // gridColcbill
            // 
            this.gridColcbill.Caption = "制单人";
            this.gridColcbill.FieldName = "cbill";
            this.gridColcbill.Name = "gridColcbill";
            this.gridColcbill.Visible = true;
            this.gridColcbill.VisibleIndex = 5;
            // 
            // gridColcbook
            // 
            this.gridColcbook.Caption = "记账人";
            this.gridColcbook.FieldName = "cbook";
            this.gridColcbook.Name = "gridColcbook";
            this.gridColcbook.Visible = true;
            this.gridColcbook.VisibleIndex = 6;
            // 
            // gridColbUsed
            // 
            this.gridColbUsed.Caption = "bUsed";
            this.gridColbUsed.FieldName = "bUsed";
            this.gridColbUsed.Name = "gridColbUsed";
            this.gridColbUsed.OptionsColumn.AllowEdit = false;
            this.gridColbUsed.Width = 55;
            // 
            // gridColcsign
            // 
            this.gridColcsign.Caption = "csign";
            this.gridColcsign.FieldName = "csign";
            this.gridColcsign.Name = "gridColcsign";
            this.gridColcsign.OptionsColumn.AllowEdit = false;
            this.gridColcsign.Visible = true;
            this.gridColcsign.VisibleIndex = 7;
            // 
            // gridColino_id
            // 
            this.gridColino_id.Caption = "ino_id";
            this.gridColino_id.FieldName = "ino_id";
            this.gridColino_id.Name = "gridColino_id";
            this.gridColino_id.OptionsColumn.AllowEdit = false;
            this.gridColino_id.Visible = true;
            this.gridColino_id.VisibleIndex = 8;
            // 
            // GL_accvouchToJP
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.menuStrip1);
            this.Name = "GL_accvouchToJP";
            this.Size = new System.Drawing.Size(1239, 480);
            this.Load += new System.EventHandler(this.Frm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.ItemTextEditn2)).EndInit();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem btnSave;
        private System.Windows.Forms.Panel panel1;
        private DevExpress.XtraGrid.GridControl gridControl1;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView1;
        private DevExpress.XtraEditors.Repository.RepositoryItemTextEdit ItemTextEditn2;
        private System.Windows.Forms.ToolStripMenuItem btnSel;
        private System.Windows.Forms.CheckBox chkAll;
        private DevExpress.XtraGrid.Columns.GridColumn gridColbChoose;
        private DevExpress.XtraGrid.Columns.GridColumn gridColcsignid;
        private DevExpress.XtraGrid.Columns.GridColumn gridColmd;
        private DevExpress.XtraGrid.Columns.GridColumn gridColmc;
        private DevExpress.XtraGrid.Columns.GridColumn gridColcdigest;
        private DevExpress.XtraGrid.Columns.GridColumn gridColbUsed;
        private DevExpress.XtraGrid.Columns.GridColumn gridColcbill;
        private DevExpress.XtraGrid.Columns.GridColumn gridColcbook;
        private DevExpress.XtraGrid.Columns.GridColumn gridColcsign;
        private DevExpress.XtraGrid.Columns.GridColumn gridColino_id;
    }
}
