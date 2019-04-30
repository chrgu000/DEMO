namespace UFIDA.U8.UAP.CustomApp.ControlForm
{
    partial class DSSaleBaseInfo
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
            this.btnSave = new System.Windows.Forms.ToolStripMenuItem();
            this.btnExport = new System.Windows.Forms.ToolStripMenuItem();
            this.gridControl1 = new DevExpress.XtraGrid.GridControl();
            this.gridView1 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.gridColbChoose = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColcSTCode = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColcSTName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColbCreateDP = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColDescription2 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColQty = new DevExpress.XtraGrid.Columns.GridColumn();
            this.panel1 = new System.Windows.Forms.Panel();
            this.menuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).BeginInit();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btnReflash,
            this.btnSave,
            this.btnExport});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(944, 24);
            this.menuStrip1.TabIndex = 172;
            this.menuStrip1.Text = "menuStrip";
            // 
            // btnReflash
            // 
            this.btnReflash.Name = "btnReflash";
            this.btnReflash.Size = new System.Drawing.Size(41, 20);
            this.btnReflash.Text = "刷新";
            this.btnReflash.Click += new System.EventHandler(this.btnQuery_Click);
            // 
            // btnSave
            // 
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(41, 20);
            this.btnSave.Text = "保存";
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // btnExport
            // 
            this.btnExport.Name = "btnExport";
            this.btnExport.Size = new System.Drawing.Size(71, 20);
            this.btnExport.Text = "导出Excel";
            this.btnExport.Click += new System.EventHandler(this.btnExport_Click);
            // 
            // gridControl1
            // 
            this.gridControl1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.gridControl1.Location = new System.Drawing.Point(3, 3);
            this.gridControl1.LookAndFeel.SkinName = "Office 2010 Blue";
            this.gridControl1.MainView = this.gridView1;
            this.gridControl1.Name = "gridControl1";
            this.gridControl1.Size = new System.Drawing.Size(938, 424);
            this.gridControl1.TabIndex = 191;
            this.gridControl1.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView1});
            // 
            // gridView1
            // 
            this.gridView1.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.gridColbChoose,
            this.gridColcSTCode,
            this.gridColcSTName,
            this.gridColbCreateDP});
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
            this.gridView1.CellValueChanged += new DevExpress.XtraGrid.Views.Base.CellValueChangedEventHandler(this.gridView1_CellValueChanged);
            // 
            // gridColbChoose
            // 
            this.gridColbChoose.Caption = "选择";
            this.gridColbChoose.FieldName = "bChoose";
            this.gridColbChoose.Name = "gridColbChoose";
            this.gridColbChoose.OptionsColumn.AllowEdit = false;
            this.gridColbChoose.Width = 57;
            // 
            // gridColcSTCode
            // 
            this.gridColcSTCode.Caption = "销售类型编码";
            this.gridColcSTCode.FieldName = "cSTCode";
            this.gridColcSTCode.Name = "gridColcSTCode";
            this.gridColcSTCode.OptionsColumn.AllowEdit = false;
            this.gridColcSTCode.Visible = true;
            this.gridColcSTCode.VisibleIndex = 0;
            this.gridColcSTCode.Width = 186;
            // 
            // gridColcSTName
            // 
            this.gridColcSTName.Caption = "销售类型";
            this.gridColcSTName.FieldName = "cSTName";
            this.gridColcSTName.Name = "gridColcSTName";
            this.gridColcSTName.OptionsColumn.AllowEdit = false;
            this.gridColcSTName.Visible = true;
            this.gridColcSTName.VisibleIndex = 1;
            this.gridColcSTName.Width = 129;
            // 
            // gridColbCreateDP
            // 
            this.gridColbCreateDP.Caption = "是否参与自动生单";
            this.gridColbCreateDP.FieldName = "bCreateDP";
            this.gridColbCreateDP.Name = "gridColbCreateDP";
            this.gridColbCreateDP.Visible = true;
            this.gridColbCreateDP.VisibleIndex = 2;
            this.gridColbCreateDP.Width = 143;
            // 
            // gridColDescription2
            // 
            this.gridColDescription2.Caption = "Description";
            this.gridColDescription2.FieldName = "Description2";
            this.gridColDescription2.Name = "gridColDescription2";
            // 
            // gridColQty
            // 
            this.gridColQty.Caption = "Qty (Units)";
            this.gridColQty.FieldName = "Qty";
            this.gridColQty.Name = "gridColQty";
            this.gridColQty.Summary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] {
            new DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum)});
            // 
            // panel1
            // 
            this.panel1.AutoScroll = true;
            this.panel1.Controls.Add(this.gridControl1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 24);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(944, 432);
            this.panel1.TabIndex = 173;
            // 
            // DSSaleBaseInfo
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.menuStrip1);
            this.Name = "DSSaleBaseInfo";
            this.Size = new System.Drawing.Size(944, 456);
            this.Load += new System.EventHandler(this.Frm_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).EndInit();
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private DevExpress.XtraGrid.GridControl gridControl1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.ToolStripMenuItem btnReflash;
        private System.Windows.Forms.ToolStripMenuItem btnSave;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView1;
        private DevExpress.XtraGrid.Columns.GridColumn gridColcSTCode;
        private DevExpress.XtraGrid.Columns.GridColumn gridColbCreateDP;
        private DevExpress.XtraGrid.Columns.GridColumn gridColDescription2;
        private DevExpress.XtraGrid.Columns.GridColumn gridColQty;
        private DevExpress.XtraGrid.Columns.GridColumn gridColcSTName;
        private DevExpress.XtraGrid.Columns.GridColumn gridColbChoose;
        private System.Windows.Forms.ToolStripMenuItem btnExport;
    }
}
