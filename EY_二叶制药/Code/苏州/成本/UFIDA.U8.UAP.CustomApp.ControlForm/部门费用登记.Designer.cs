namespace UFIDA.U8.UAP.CustomApp.ControlForm
{
    partial class 部门费用登记
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
            this.btnDel = new System.Windows.Forms.ToolStripMenuItem();
            this.btnSave = new System.Windows.Forms.ToolStripMenuItem();
            this.btnAudit = new System.Windows.Forms.ToolStripMenuItem();
            this.btnUnAudit = new System.Windows.Forms.ToolStripMenuItem();
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            this.gridControl1 = new DevExpress.XtraGrid.GridControl();
            this.gridView1 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.gridCol部门编码 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridCol部门 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridCol金额 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridCol备注 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridCol制单人 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridCol制单日期 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridCol审核人 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridCol审核日期 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridCol修改人 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridCol修改日期 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridCol记账人 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridCol记账日期 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label7 = new System.Windows.Forms.Label();
            this.lookUpEditCostType = new DevExpress.XtraEditors.LookUpEdit();
            this.lookUpEdit会计期间 = new DevExpress.XtraEditors.LookUpEdit();
            this.label3 = new System.Windows.Forms.Label();
            this.menuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).BeginInit();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.lookUpEditCostType.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lookUpEdit会计期间.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btnDel,
            this.btnSave,
            this.btnAudit,
            this.btnUnAudit});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(903, 25);
            this.menuStrip1.TabIndex = 172;
            this.menuStrip1.Text = "menuStrip";
            // 
            // btnDel
            // 
            this.btnDel.Name = "btnDel";
            this.btnDel.Size = new System.Drawing.Size(44, 21);
            this.btnDel.Text = "删除";
            this.btnDel.Click += new System.EventHandler(this.btnDel_Click);
            // 
            // btnSave
            // 
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(44, 21);
            this.btnSave.Text = "保存";
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // btnAudit
            // 
            this.btnAudit.Name = "btnAudit";
            this.btnAudit.Size = new System.Drawing.Size(44, 21);
            this.btnAudit.Text = "审核";
            this.btnAudit.Click += new System.EventHandler(this.btnAudit_Click);
            // 
            // btnUnAudit
            // 
            this.btnUnAudit.Name = "btnUnAudit";
            this.btnUnAudit.Size = new System.Drawing.Size(44, 21);
            this.btnUnAudit.Text = "弃审";
            this.btnUnAudit.Click += new System.EventHandler(this.btnUnAudit_Click);
            // 
            // labelControl1
            // 
            this.labelControl1.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.labelControl1.Appearance.Font = new System.Drawing.Font("Tahoma", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelControl1.Location = new System.Drawing.Point(354, 12);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(126, 25);
            this.labelControl1.TabIndex = 190;
            this.labelControl1.Text = "部门费用登记";
            // 
            // gridControl1
            // 
            this.gridControl1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.gridControl1.Location = new System.Drawing.Point(3, 70);
            this.gridControl1.LookAndFeel.SkinName = "Office 2010 Blue";
            this.gridControl1.MainView = this.gridView1;
            this.gridControl1.Name = "gridControl1";
            this.gridControl1.Size = new System.Drawing.Size(897, 320);
            this.gridControl1.TabIndex = 191;
            this.gridControl1.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView1});
            // 
            // gridView1
            // 
            this.gridView1.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.gridCol部门编码,
            this.gridCol部门,
            this.gridCol金额,
            this.gridCol备注,
            this.gridCol制单人,
            this.gridCol制单日期,
            this.gridCol审核人,
            this.gridCol审核日期,
            this.gridCol修改人,
            this.gridCol修改日期,
            this.gridCol记账人,
            this.gridCol记账日期});
            this.gridView1.GridControl = this.gridControl1;
            this.gridView1.IndicatorWidth = 40;
            this.gridView1.Name = "gridView1";
            this.gridView1.OptionsBehavior.AllowDeleteRows = DevExpress.Utils.DefaultBoolean.True;
            this.gridView1.OptionsBehavior.EditorShowMode = DevExpress.Utils.EditorShowMode.MouseDown;
            this.gridView1.OptionsCustomization.AllowGroup = false;
            this.gridView1.OptionsCustomization.AllowQuickHideColumns = false;
            this.gridView1.OptionsNavigation.EnterMoveNextColumn = true;
            this.gridView1.OptionsView.ColumnAutoWidth = false;
            this.gridView1.OptionsView.ShowFooter = true;
            this.gridView1.OptionsView.ShowGroupPanel = false;
            this.gridView1.CustomDrawRowIndicator += new DevExpress.XtraGrid.Views.Grid.RowIndicatorCustomDrawEventHandler(this.gridView1_CustomDrawRowIndicator);
            // 
            // gridCol部门编码
            // 
            this.gridCol部门编码.Caption = "部门编码";
            this.gridCol部门编码.FieldName = "部门编码";
            this.gridCol部门编码.Name = "gridCol部门编码";
            this.gridCol部门编码.OptionsColumn.AllowEdit = false;
            this.gridCol部门编码.OptionsColumn.AllowSort = DevExpress.Utils.DefaultBoolean.False;
            this.gridCol部门编码.OptionsFilter.AllowFilter = false;
            this.gridCol部门编码.Visible = true;
            this.gridCol部门编码.VisibleIndex = 0;
            this.gridCol部门编码.Width = 83;
            // 
            // gridCol部门
            // 
            this.gridCol部门.Caption = "部门";
            this.gridCol部门.FieldName = "部门";
            this.gridCol部门.Name = "gridCol部门";
            this.gridCol部门.OptionsColumn.AllowEdit = false;
            this.gridCol部门.Visible = true;
            this.gridCol部门.VisibleIndex = 1;
            this.gridCol部门.Width = 108;
            // 
            // gridCol金额
            // 
            this.gridCol金额.Caption = "金额";
            this.gridCol金额.FieldName = "金额";
            this.gridCol金额.Name = "gridCol金额";
            this.gridCol金额.OptionsColumn.AllowSort = DevExpress.Utils.DefaultBoolean.False;
            this.gridCol金额.OptionsFilter.AllowFilter = false;
            this.gridCol金额.Visible = true;
            this.gridCol金额.VisibleIndex = 2;
            this.gridCol金额.Width = 82;
            // 
            // gridCol备注
            // 
            this.gridCol备注.Caption = "备注";
            this.gridCol备注.FieldName = "备注";
            this.gridCol备注.Name = "gridCol备注";
            this.gridCol备注.OptionsColumn.AllowSort = DevExpress.Utils.DefaultBoolean.False;
            this.gridCol备注.OptionsFilter.AllowFilter = false;
            this.gridCol备注.Visible = true;
            this.gridCol备注.VisibleIndex = 3;
            this.gridCol备注.Width = 263;
            // 
            // gridCol制单人
            // 
            this.gridCol制单人.Caption = "制单人";
            this.gridCol制单人.FieldName = "制单人";
            this.gridCol制单人.Name = "gridCol制单人";
            this.gridCol制单人.OptionsColumn.AllowEdit = false;
            this.gridCol制单人.Visible = true;
            this.gridCol制单人.VisibleIndex = 4;
            // 
            // gridCol制单日期
            // 
            this.gridCol制单日期.Caption = "制单日期";
            this.gridCol制单日期.FieldName = "制单日期";
            this.gridCol制单日期.Name = "gridCol制单日期";
            this.gridCol制单日期.OptionsColumn.AllowEdit = false;
            this.gridCol制单日期.Visible = true;
            this.gridCol制单日期.VisibleIndex = 5;
            // 
            // gridCol审核人
            // 
            this.gridCol审核人.Caption = "审核人";
            this.gridCol审核人.FieldName = "审核人";
            this.gridCol审核人.Name = "gridCol审核人";
            this.gridCol审核人.OptionsColumn.AllowEdit = false;
            this.gridCol审核人.Visible = true;
            this.gridCol审核人.VisibleIndex = 8;
            // 
            // gridCol审核日期
            // 
            this.gridCol审核日期.Caption = "审核日期";
            this.gridCol审核日期.FieldName = "审核日期";
            this.gridCol审核日期.Name = "gridCol审核日期";
            this.gridCol审核日期.OptionsColumn.AllowEdit = false;
            this.gridCol审核日期.Visible = true;
            this.gridCol审核日期.VisibleIndex = 9;
            // 
            // gridCol修改人
            // 
            this.gridCol修改人.Caption = "修改人";
            this.gridCol修改人.FieldName = "修改人";
            this.gridCol修改人.Name = "gridCol修改人";
            this.gridCol修改人.OptionsColumn.AllowEdit = false;
            this.gridCol修改人.Visible = true;
            this.gridCol修改人.VisibleIndex = 6;
            // 
            // gridCol修改日期
            // 
            this.gridCol修改日期.Caption = "修改日期";
            this.gridCol修改日期.FieldName = "修改日期";
            this.gridCol修改日期.Name = "gridCol修改日期";
            this.gridCol修改日期.OptionsColumn.AllowEdit = false;
            this.gridCol修改日期.Visible = true;
            this.gridCol修改日期.VisibleIndex = 7;
            // 
            // gridCol记账人
            // 
            this.gridCol记账人.Caption = "记账人";
            this.gridCol记账人.FieldName = "记账人";
            this.gridCol记账人.Name = "gridCol记账人";
            this.gridCol记账人.OptionsColumn.AllowEdit = false;
            this.gridCol记账人.Visible = true;
            this.gridCol记账人.VisibleIndex = 10;
            // 
            // gridCol记账日期
            // 
            this.gridCol记账日期.Caption = "记账日期";
            this.gridCol记账日期.FieldName = "记账日期";
            this.gridCol记账日期.Name = "gridCol记账日期";
            this.gridCol记账日期.OptionsColumn.AllowEdit = false;
            this.gridCol记账日期.Visible = true;
            this.gridCol记账日期.VisibleIndex = 11;
            // 
            // panel1
            // 
            this.panel1.AutoScroll = true;
            this.panel1.Controls.Add(this.label7);
            this.panel1.Controls.Add(this.lookUpEditCostType);
            this.panel1.Controls.Add(this.lookUpEdit会计期间);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.gridControl1);
            this.panel1.Controls.Add(this.labelControl1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 25);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(903, 393);
            this.panel1.TabIndex = 173;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.ForeColor = System.Drawing.Color.Blue;
            this.label7.Location = new System.Drawing.Point(208, 47);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(53, 12);
            this.label7.TabIndex = 207;
            this.label7.Text = "费用类型";
            this.label7.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lookUpEditCostType
            // 
            this.lookUpEditCostType.AllowHtmlTextInToolTip = DevExpress.Utils.DefaultBoolean.True;
            this.lookUpEditCostType.Location = new System.Drawing.Point(267, 43);
            this.lookUpEditCostType.Name = "lookUpEditCostType";
            this.lookUpEditCostType.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.lookUpEditCostType.Properties.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("sType", 100, "类型")});
            this.lookUpEditCostType.Properties.DisplayMember = "sType";
            this.lookUpEditCostType.Properties.NullText = "";
            this.lookUpEditCostType.Properties.PopupWidth = 700;
            this.lookUpEditCostType.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.Standard;
            this.lookUpEditCostType.Properties.ValueMember = "sType";
            this.lookUpEditCostType.Size = new System.Drawing.Size(174, 20);
            this.lookUpEditCostType.TabIndex = 206;
            this.lookUpEditCostType.EditValueChanged += new System.EventHandler(this.lookUpEdi_EditValueChanged);
            // 
            // lookUpEdit会计期间
            // 
            this.lookUpEdit会计期间.AllowHtmlTextInToolTip = DevExpress.Utils.DefaultBoolean.True;
            this.lookUpEdit会计期间.Location = new System.Drawing.Point(70, 43);
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
            this.lookUpEdit会计期间.TabIndex = 195;
            this.lookUpEdit会计期间.EditValueChanged += new System.EventHandler(this.lookUpEdi_EditValueChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.ForeColor = System.Drawing.Color.Blue;
            this.label3.Location = new System.Drawing.Point(11, 47);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(53, 12);
            this.label3.TabIndex = 194;
            this.label3.Text = "会计期间";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // 部门费用登记
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.menuStrip1);
            this.Name = "部门费用登记";
            this.Size = new System.Drawing.Size(903, 418);
            this.Load += new System.EventHandler(this.Frm_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.lookUpEditCostType.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lookUpEdit会计期间.Properties)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem btnDel;
        private System.Windows.Forms.ToolStripMenuItem btnSave;
        private DevExpress.XtraEditors.LabelControl labelControl1;
        private DevExpress.XtraGrid.GridControl gridControl1;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView1;
        private System.Windows.Forms.Panel panel1;
        private DevExpress.XtraGrid.Columns.GridColumn gridCol部门编码;
        private DevExpress.XtraGrid.Columns.GridColumn gridCol金额;
        private DevExpress.XtraGrid.Columns.GridColumn gridCol备注;
        private DevExpress.XtraEditors.LookUpEdit lookUpEdit会计期间;
        private System.Windows.Forms.Label label3;
        private DevExpress.XtraGrid.Columns.GridColumn gridCol制单人;
        private DevExpress.XtraGrid.Columns.GridColumn gridCol制单日期;
        private DevExpress.XtraGrid.Columns.GridColumn gridCol审核人;
        private DevExpress.XtraGrid.Columns.GridColumn gridCol审核日期;
        private System.Windows.Forms.ToolStripMenuItem btnAudit;
        private System.Windows.Forms.ToolStripMenuItem btnUnAudit;
        private DevExpress.XtraGrid.Columns.GridColumn gridCol修改人;
        private DevExpress.XtraGrid.Columns.GridColumn gridCol修改日期;
        private DevExpress.XtraGrid.Columns.GridColumn gridCol记账人;
        private DevExpress.XtraGrid.Columns.GridColumn gridCol记账日期;
        private System.Windows.Forms.Label label7;
        private DevExpress.XtraEditors.LookUpEdit lookUpEditCostType;
        private DevExpress.XtraGrid.Columns.GridColumn gridCol部门;
    }
}
