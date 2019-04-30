namespace UFIDA.U8.UAP.CustomApp.ControlForm
{
    partial class 产成品成本分配
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
            this.btn计算 = new System.Windows.Forms.ToolStripMenuItem();
            this.btn保存 = new System.Windows.Forms.ToolStripMenuItem();
            this.btnExport = new System.Windows.Forms.ToolStripMenuItem();
            this.gridControl1 = new DevExpress.XtraGrid.GridControl();
            this.gridView1 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.gridCol存货编码 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridCol存货名称 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridCol规格型号 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridCol数量 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridCol原价 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridCol标准 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridCol差异 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridCol间接原价 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridCol实际成本 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.panel1 = new System.Windows.Forms.Panel();
            this.txt间接原价 = new DevExpress.XtraEditors.TextEdit();
            this.label4 = new System.Windows.Forms.Label();
            this.txt差异 = new DevExpress.XtraEditors.TextEdit();
            this.label2 = new System.Windows.Forms.Label();
            this.lookUpEditcInvCName = new DevExpress.XtraEditors.LookUpEdit();
            this.label1 = new System.Windows.Forms.Label();
            this.lookUpEditcInvCCode = new DevExpress.XtraEditors.LookUpEdit();
            this.label3 = new System.Windows.Forms.Label();
            this.lookUpEdit会计期间 = new DevExpress.XtraEditors.LookUpEdit();
            this.menuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).BeginInit();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txt间接原价.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txt差异.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lookUpEditcInvCName.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lookUpEditcInvCCode.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lookUpEdit会计期间.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btnSEL,
            this.btn计算,
            this.btn保存,
            this.btnExport});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(944, 25);
            this.menuStrip1.TabIndex = 172;
            this.menuStrip1.Text = "menuStrip";
            // 
            // btnSEL
            // 
            this.btnSEL.Name = "btnSEL";
            this.btnSEL.Size = new System.Drawing.Size(44, 21);
            this.btnSEL.Text = "查询";
            this.btnSEL.Click += new System.EventHandler(this.btnSEL_Click);
            // 
            // btn计算
            // 
            this.btn计算.Name = "btn计算";
            this.btn计算.Size = new System.Drawing.Size(44, 21);
            this.btn计算.Text = "计算";
            this.btn计算.Click += new System.EventHandler(this.btn计算_Click);
            // 
            // btn保存
            // 
            this.btn保存.Name = "btn保存";
            this.btn保存.Size = new System.Drawing.Size(44, 21);
            this.btn保存.Text = "保存";
            this.btn保存.Click += new System.EventHandler(this.btn保存_Click);
            // 
            // btnExport
            // 
            this.btnExport.Name = "btnExport";
            this.btnExport.Size = new System.Drawing.Size(44, 21);
            this.btnExport.Text = "导出";
            this.btnExport.Click += new System.EventHandler(this.btnExport_Click);
            // 
            // gridControl1
            // 
            this.gridControl1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.gridControl1.Location = new System.Drawing.Point(6, 69);
            this.gridControl1.LookAndFeel.SkinName = "Office 2010 Blue";
            this.gridControl1.MainView = this.gridView1;
            this.gridControl1.Name = "gridControl1";
            this.gridControl1.Size = new System.Drawing.Size(935, 359);
            this.gridControl1.TabIndex = 191;
            this.gridControl1.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView1});
            // 
            // gridView1
            // 
            this.gridView1.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.gridCol存货编码,
            this.gridCol存货名称,
            this.gridCol规格型号,
            this.gridCol数量,
            this.gridCol原价,
            this.gridCol标准,
            this.gridCol差异,
            this.gridCol间接原价,
            this.gridCol实际成本});
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
            // gridCol存货编码
            // 
            this.gridCol存货编码.Caption = "存货编码";
            this.gridCol存货编码.FieldName = "存货编码";
            this.gridCol存货编码.Name = "gridCol存货编码";
            this.gridCol存货编码.OptionsColumn.AllowEdit = false;
            this.gridCol存货编码.Visible = true;
            this.gridCol存货编码.VisibleIndex = 0;
            // 
            // gridCol存货名称
            // 
            this.gridCol存货名称.Caption = "存货名称";
            this.gridCol存货名称.FieldName = "存货编码";
            this.gridCol存货名称.Name = "gridCol存货名称";
            this.gridCol存货名称.OptionsColumn.AllowEdit = false;
            this.gridCol存货名称.Visible = true;
            this.gridCol存货名称.VisibleIndex = 1;
            // 
            // gridCol规格型号
            // 
            this.gridCol规格型号.Caption = "规格型号";
            this.gridCol规格型号.FieldName = "存货编码";
            this.gridCol规格型号.Name = "gridCol规格型号";
            this.gridCol规格型号.OptionsColumn.AllowEdit = false;
            this.gridCol规格型号.Visible = true;
            this.gridCol规格型号.VisibleIndex = 2;
            // 
            // gridCol数量
            // 
            this.gridCol数量.Caption = "数量";
            this.gridCol数量.FieldName = "数量";
            this.gridCol数量.Name = "gridCol数量";
            this.gridCol数量.OptionsColumn.AllowEdit = false;
            this.gridCol数量.Summary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] {
            new DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum)});
            this.gridCol数量.Visible = true;
            this.gridCol数量.VisibleIndex = 3;
            // 
            // gridCol原价
            // 
            this.gridCol原价.Caption = "原价";
            this.gridCol原价.FieldName = "原价";
            this.gridCol原价.Name = "gridCol原价";
            this.gridCol原价.OptionsColumn.AllowEdit = false;
            this.gridCol原价.Visible = true;
            this.gridCol原价.VisibleIndex = 4;
            // 
            // gridCol标准
            // 
            this.gridCol标准.Caption = "标准";
            this.gridCol标准.FieldName = "标准";
            this.gridCol标准.Name = "gridCol标准";
            this.gridCol标准.OptionsColumn.AllowEdit = false;
            this.gridCol标准.Summary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] {
            new DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum)});
            this.gridCol标准.Visible = true;
            this.gridCol标准.VisibleIndex = 5;
            // 
            // gridCol差异
            // 
            this.gridCol差异.Caption = "差异";
            this.gridCol差异.FieldName = "差异";
            this.gridCol差异.Name = "gridCol差异";
            this.gridCol差异.OptionsColumn.AllowEdit = false;
            this.gridCol差异.Summary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] {
            new DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum)});
            this.gridCol差异.Visible = true;
            this.gridCol差异.VisibleIndex = 6;
            // 
            // gridCol间接原价
            // 
            this.gridCol间接原价.Caption = "间接原价";
            this.gridCol间接原价.FieldName = "间接原价";
            this.gridCol间接原价.Name = "gridCol间接原价";
            this.gridCol间接原价.OptionsColumn.AllowEdit = false;
            this.gridCol间接原价.Summary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] {
            new DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum)});
            this.gridCol间接原价.Visible = true;
            this.gridCol间接原价.VisibleIndex = 7;
            // 
            // gridCol实际成本
            // 
            this.gridCol实际成本.Caption = "实际成本";
            this.gridCol实际成本.FieldName = "实际成本";
            this.gridCol实际成本.Name = "gridCol实际成本";
            this.gridCol实际成本.Summary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] {
            new DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum)});
            this.gridCol实际成本.Visible = true;
            this.gridCol实际成本.VisibleIndex = 8;
            // 
            // panel1
            // 
            this.panel1.AutoScroll = true;
            this.panel1.Controls.Add(this.txt间接原价);
            this.panel1.Controls.Add(this.label4);
            this.panel1.Controls.Add(this.txt差异);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.lookUpEditcInvCName);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.lookUpEditcInvCCode);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.lookUpEdit会计期间);
            this.panel1.Controls.Add(this.gridControl1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 25);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(944, 431);
            this.panel1.TabIndex = 173;
            // 
            // txt间接原价
            // 
            this.txt间接原价.Location = new System.Drawing.Point(275, 43);
            this.txt间接原价.Name = "txt间接原价";
            this.txt间接原价.Size = new System.Drawing.Size(121, 20);
            this.txt间接原价.TabIndex = 207;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.ForeColor = System.Drawing.Color.Blue;
            this.label4.Location = new System.Drawing.Point(216, 48);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(53, 12);
            this.label4.TabIndex = 206;
            this.label4.Text = "间接原价";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txt差异
            // 
            this.txt差异.Location = new System.Drawing.Point(74, 43);
            this.txt差异.Name = "txt差异";
            this.txt差异.Size = new System.Drawing.Size(121, 20);
            this.txt差异.TabIndex = 205;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.ForeColor = System.Drawing.Color.Blue;
            this.label2.Location = new System.Drawing.Point(39, 48);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(29, 12);
            this.label2.TabIndex = 204;
            this.label2.Text = "差异";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lookUpEditcInvCName
            // 
            this.lookUpEditcInvCName.AllowHtmlTextInToolTip = DevExpress.Utils.DefaultBoolean.True;
            this.lookUpEditcInvCName.Location = new System.Drawing.Point(402, 17);
            this.lookUpEditcInvCName.Name = "lookUpEditcInvCName";
            this.lookUpEditcInvCName.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.lookUpEditcInvCName.Properties.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("cInvCCode", "存货大类编码"),
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("cInvCName", "存货大类")});
            this.lookUpEditcInvCName.Properties.DisplayMember = "cInvCName";
            this.lookUpEditcInvCName.Properties.NullText = "";
            this.lookUpEditcInvCName.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.Standard;
            this.lookUpEditcInvCName.Properties.ValueMember = "cInvCCode";
            this.lookUpEditcInvCName.Size = new System.Drawing.Size(121, 20);
            this.lookUpEditcInvCName.TabIndex = 203;
            this.lookUpEditcInvCName.EditValueChanged += new System.EventHandler(this.lookUpEditcInvCName_EditValueChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.ForeColor = System.Drawing.Color.Blue;
            this.label1.Location = new System.Drawing.Point(216, 22);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(53, 12);
            this.label1.TabIndex = 202;
            this.label1.Text = "存货分类";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lookUpEditcInvCCode
            // 
            this.lookUpEditcInvCCode.AllowHtmlTextInToolTip = DevExpress.Utils.DefaultBoolean.True;
            this.lookUpEditcInvCCode.Location = new System.Drawing.Point(275, 17);
            this.lookUpEditcInvCCode.Name = "lookUpEditcInvCCode";
            this.lookUpEditcInvCCode.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.lookUpEditcInvCCode.Properties.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("cInvCCode", "存货大类编码"),
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("cInvCName", "存货大类")});
            this.lookUpEditcInvCCode.Properties.DisplayMember = "cInvCCode";
            this.lookUpEditcInvCCode.Properties.NullText = "";
            this.lookUpEditcInvCCode.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.Standard;
            this.lookUpEditcInvCCode.Properties.ValueMember = "cInvCCode";
            this.lookUpEditcInvCCode.Size = new System.Drawing.Size(121, 20);
            this.lookUpEditcInvCCode.TabIndex = 201;
            this.lookUpEditcInvCCode.EditValueChanged += new System.EventHandler(this.lookUpEditcInvCCode_EditValueChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.ForeColor = System.Drawing.Color.Blue;
            this.label3.Location = new System.Drawing.Point(15, 22);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(53, 12);
            this.label3.TabIndex = 200;
            this.label3.Text = "会计期间";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lookUpEdit会计期间
            // 
            this.lookUpEdit会计期间.AllowHtmlTextInToolTip = DevExpress.Utils.DefaultBoolean.True;
            this.lookUpEdit会计期间.Location = new System.Drawing.Point(74, 17);
            this.lookUpEdit会计期间.Name = "lookUpEdit会计期间";
            this.lookUpEdit会计期间.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.lookUpEdit会计期间.Properties.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("会计期间", "会计期间")});
            this.lookUpEdit会计期间.Properties.DisplayMember = "会计期间";
            this.lookUpEdit会计期间.Properties.NullText = "";
            this.lookUpEdit会计期间.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.Standard;
            this.lookUpEdit会计期间.Properties.ValueMember = "会计期间";
            this.lookUpEdit会计期间.Size = new System.Drawing.Size(121, 20);
            this.lookUpEdit会计期间.TabIndex = 199;
            // 
            // 产成品成本分配
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.menuStrip1);
            this.Name = "产成品成本分配";
            this.Size = new System.Drawing.Size(944, 456);
            this.Load += new System.EventHandler(this.Frm_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txt间接原价.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txt差异.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lookUpEditcInvCName.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lookUpEditcInvCCode.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lookUpEdit会计期间.Properties)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private DevExpress.XtraGrid.GridControl gridControl1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.ToolStripMenuItem btnSEL;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView1;
        private System.Windows.Forms.ToolStripMenuItem btnExport;
        private DevExpress.XtraGrid.Columns.GridColumn gridCol存货编码;
        private DevExpress.XtraGrid.Columns.GridColumn gridCol存货名称;
        private DevExpress.XtraGrid.Columns.GridColumn gridCol规格型号;
        private DevExpress.XtraGrid.Columns.GridColumn gridCol数量;
        private DevExpress.XtraGrid.Columns.GridColumn gridCol原价;
        private DevExpress.XtraGrid.Columns.GridColumn gridCol标准;
        private DevExpress.XtraGrid.Columns.GridColumn gridCol差异;
        private DevExpress.XtraGrid.Columns.GridColumn gridCol间接原价;
        private DevExpress.XtraGrid.Columns.GridColumn gridCol实际成本;
        private System.Windows.Forms.Label label3;
        private DevExpress.XtraEditors.LookUpEdit lookUpEdit会计期间;
        private System.Windows.Forms.Label label1;
        private DevExpress.XtraEditors.LookUpEdit lookUpEditcInvCCode;
        private DevExpress.XtraEditors.LookUpEdit lookUpEditcInvCName;
        private System.Windows.Forms.Label label2;
        private DevExpress.XtraEditors.TextEdit txt间接原价;
        private System.Windows.Forms.Label label4;
        private DevExpress.XtraEditors.TextEdit txt差异;
        private System.Windows.Forms.ToolStripMenuItem btn计算;
        private System.Windows.Forms.ToolStripMenuItem btn保存;
    }
}
