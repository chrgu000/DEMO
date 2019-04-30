namespace UFIDA.U8.UAP.CustomApp.ControlForm
{
    partial class 成本分配表
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
            this.btnClear = new System.Windows.Forms.ToolStripMenuItem();
            this.btnSEL = new System.Windows.Forms.ToolStripMenuItem();
            this.btn计算 = new System.Windows.Forms.ToolStripMenuItem();
            this.btnSave = new System.Windows.Forms.ToolStripMenuItem();
            this.btnExport = new System.Windows.Forms.ToolStripMenuItem();
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            this.gridControl1 = new DevExpress.XtraGrid.GridControl();
            this.gridView1 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.gridColid = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColautoid = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColcCode = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColdDate = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColcRdCode = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColcInvCode = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColcInvName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColcInvStd = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColiQuantity = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColiUnitCost = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColiPrice = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColRdType = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridCol料 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridCol部门分摊 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridCol公用分摊 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColcDepCode = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColcDepName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridCol计算时间 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridCol产品总数 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.ItemLookUpEditcInvCode = new DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit();
            this.ItemLookUpEditcInvName = new DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit();
            this.ItemLookUpEditcInvStd = new DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit();
            this.ItemLookUpEditcComUnitName = new DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit();
            this.label3 = new System.Windows.Forms.Label();
            this.lookUpEdit会计期间 = new DevExpress.XtraEditors.LookUpEdit();
            this.panel1 = new System.Windows.Forms.Panel();
            this.menuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ItemLookUpEditcInvCode)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ItemLookUpEditcInvName)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ItemLookUpEditcInvStd)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ItemLookUpEditcComUnitName)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lookUpEdit会计期间.Properties)).BeginInit();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btnClear,
            this.btnSEL,
            this.btn计算,
            this.btnSave,
            this.btnExport});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Padding = new System.Windows.Forms.Padding(8, 2, 0, 2);
            this.menuStrip1.Size = new System.Drawing.Size(1204, 28);
            this.menuStrip1.TabIndex = 172;
            this.menuStrip1.Text = "menuStrip";
            // 
            // btnClear
            // 
            this.btnClear.Name = "btnClear";
            this.btnClear.Size = new System.Drawing.Size(51, 24);
            this.btnClear.Text = "清空";
            this.btnClear.Click += new System.EventHandler(this.btnClear_Click);
            // 
            // btnSEL
            // 
            this.btnSEL.Name = "btnSEL";
            this.btnSEL.Size = new System.Drawing.Size(51, 24);
            this.btnSEL.Text = "查询";
            this.btnSEL.Click += new System.EventHandler(this.btnSEL_Click);
            // 
            // btn计算
            // 
            this.btn计算.Name = "btn计算";
            this.btn计算.Size = new System.Drawing.Size(51, 24);
            this.btn计算.Text = "计算";
            this.btn计算.Click += new System.EventHandler(this.btn计算_Click);
            // 
            // btnSave
            // 
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(51, 24);
            this.btnSave.Text = "保存";
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // btnExport
            // 
            this.btnExport.Name = "btnExport";
            this.btnExport.Size = new System.Drawing.Size(51, 24);
            this.btnExport.Text = "导出";
            this.btnExport.Click += new System.EventHandler(this.btnExport_Click);
            // 
            // labelControl1
            // 
            this.labelControl1.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.labelControl1.Appearance.Font = new System.Drawing.Font("Tahoma", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelControl1.Location = new System.Drawing.Point(526, 13);
            this.labelControl1.Margin = new System.Windows.Forms.Padding(4);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(130, 31);
            this.labelControl1.TabIndex = 190;
            this.labelControl1.Text = "成本分配表";
            // 
            // gridControl1
            // 
            this.gridControl1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.gridControl1.EmbeddedNavigator.Margin = new System.Windows.Forms.Padding(4);
            this.gridControl1.Location = new System.Drawing.Point(4, 101);
            this.gridControl1.LookAndFeel.SkinName = "Office 2010 Blue";
            this.gridControl1.MainView = this.gridView1;
            this.gridControl1.Margin = new System.Windows.Forms.Padding(4);
            this.gridControl1.Name = "gridControl1";
            this.gridControl1.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.ItemLookUpEditcInvCode,
            this.ItemLookUpEditcInvName,
            this.ItemLookUpEditcInvStd,
            this.ItemLookUpEditcComUnitName});
            this.gridControl1.Size = new System.Drawing.Size(1196, 389);
            this.gridControl1.TabIndex = 191;
            this.gridControl1.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView1});
            // 
            // gridView1
            // 
            this.gridView1.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.gridColid,
            this.gridColautoid,
            this.gridColcCode,
            this.gridColdDate,
            this.gridColcRdCode,
            this.gridColcInvCode,
            this.gridColcInvName,
            this.gridColcInvStd,
            this.gridColiQuantity,
            this.gridColiUnitCost,
            this.gridColiPrice,
            this.gridColRdType,
            this.gridCol料,
            this.gridCol部门分摊,
            this.gridCol公用分摊,
            this.gridColcDepCode,
            this.gridColcDepName,
            this.gridCol计算时间,
            this.gridCol产品总数});
            this.gridView1.GridControl = this.gridControl1;
            this.gridView1.IndicatorWidth = 40;
            this.gridView1.Name = "gridView1";
            this.gridView1.OptionsBehavior.AllowDeleteRows = DevExpress.Utils.DefaultBoolean.True;
            this.gridView1.OptionsBehavior.Editable = false;
            this.gridView1.OptionsBehavior.EditorShowMode = DevExpress.Utils.EditorShowMode.MouseDown;
            this.gridView1.OptionsCustomization.AllowGroup = false;
            this.gridView1.OptionsCustomization.AllowQuickHideColumns = false;
            this.gridView1.OptionsView.ColumnAutoWidth = false;
            this.gridView1.OptionsView.ShowFooter = true;
            this.gridView1.OptionsView.ShowGroupPanel = false;
            this.gridView1.CustomDrawRowIndicator += new DevExpress.XtraGrid.Views.Grid.RowIndicatorCustomDrawEventHandler(this.gridView1_CustomDrawRowIndicator);
            // 
            // gridColid
            // 
            this.gridColid.Caption = "id";
            this.gridColid.FieldName = "id";
            this.gridColid.Name = "gridColid";
            this.gridColid.OptionsColumn.AllowEdit = false;
            // 
            // gridColautoid
            // 
            this.gridColautoid.Caption = "autoid";
            this.gridColautoid.FieldName = "autoid";
            this.gridColautoid.Name = "gridColautoid";
            this.gridColautoid.OptionsColumn.AllowEdit = false;
            // 
            // gridColcCode
            // 
            this.gridColcCode.Caption = "单据号";
            this.gridColcCode.FieldName = "cCode";
            this.gridColcCode.Name = "gridColcCode";
            this.gridColcCode.OptionsColumn.AllowEdit = false;
            this.gridColcCode.Visible = true;
            this.gridColcCode.VisibleIndex = 0;
            this.gridColcCode.Width = 131;
            // 
            // gridColdDate
            // 
            this.gridColdDate.Caption = "单据日期";
            this.gridColdDate.FieldName = "dDate";
            this.gridColdDate.Name = "gridColdDate";
            this.gridColdDate.OptionsColumn.AllowEdit = false;
            this.gridColdDate.Visible = true;
            this.gridColdDate.VisibleIndex = 1;
            // 
            // gridColcRdCode
            // 
            this.gridColcRdCode.Caption = "收发类别";
            this.gridColcRdCode.FieldName = "cRdCode";
            this.gridColcRdCode.Name = "gridColcRdCode";
            this.gridColcRdCode.OptionsColumn.AllowEdit = false;
            // 
            // gridColcInvCode
            // 
            this.gridColcInvCode.Caption = "存货编码";
            this.gridColcInvCode.FieldName = "cInvCode";
            this.gridColcInvCode.Name = "gridColcInvCode";
            this.gridColcInvCode.OptionsColumn.AllowEdit = false;
            this.gridColcInvCode.Visible = true;
            this.gridColcInvCode.VisibleIndex = 4;
            // 
            // gridColcInvName
            // 
            this.gridColcInvName.Caption = "存货名称";
            this.gridColcInvName.FieldName = "cInvName";
            this.gridColcInvName.Name = "gridColcInvName";
            this.gridColcInvName.OptionsColumn.AllowEdit = false;
            this.gridColcInvName.Visible = true;
            this.gridColcInvName.VisibleIndex = 5;
            // 
            // gridColcInvStd
            // 
            this.gridColcInvStd.Caption = "规格型号";
            this.gridColcInvStd.FieldName = "cInvStd";
            this.gridColcInvStd.Name = "gridColcInvStd";
            this.gridColcInvStd.OptionsColumn.AllowEdit = false;
            this.gridColcInvStd.Visible = true;
            this.gridColcInvStd.VisibleIndex = 6;
            // 
            // gridColiQuantity
            // 
            this.gridColiQuantity.Caption = "数量";
            this.gridColiQuantity.DisplayFormat.FormatString = "n6";
            this.gridColiQuantity.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.gridColiQuantity.FieldName = "iQuantity";
            this.gridColiQuantity.Name = "gridColiQuantity";
            this.gridColiQuantity.OptionsColumn.AllowEdit = false;
            this.gridColiQuantity.Visible = true;
            this.gridColiQuantity.VisibleIndex = 7;
            // 
            // gridColiUnitCost
            // 
            this.gridColiUnitCost.Caption = "单价";
            this.gridColiUnitCost.DisplayFormat.FormatString = "n6";
            this.gridColiUnitCost.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.gridColiUnitCost.FieldName = "iUnitCost";
            this.gridColiUnitCost.Name = "gridColiUnitCost";
            this.gridColiUnitCost.OptionsColumn.AllowEdit = false;
            this.gridColiUnitCost.Visible = true;
            this.gridColiUnitCost.VisibleIndex = 8;
            // 
            // gridColiPrice
            // 
            this.gridColiPrice.Caption = "金额";
            this.gridColiPrice.DisplayFormat.FormatString = "n6";
            this.gridColiPrice.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.gridColiPrice.FieldName = "iPrice";
            this.gridColiPrice.Name = "gridColiPrice";
            this.gridColiPrice.OptionsColumn.AllowEdit = false;
            this.gridColiPrice.Visible = true;
            this.gridColiPrice.VisibleIndex = 9;
            // 
            // gridColRdType
            // 
            this.gridColRdType.Caption = "单据类型";
            this.gridColRdType.FieldName = "RdType";
            this.gridColRdType.Name = "gridColRdType";
            this.gridColRdType.OptionsColumn.AllowEdit = false;
            // 
            // gridCol料
            // 
            this.gridCol料.Caption = "料";
            this.gridCol料.FieldName = "料";
            this.gridCol料.Name = "gridCol料";
            this.gridCol料.OptionsColumn.AllowEdit = false;
            // 
            // gridCol部门分摊
            // 
            this.gridCol部门分摊.Caption = "部门分摊";
            this.gridCol部门分摊.FieldName = "部门分摊";
            this.gridCol部门分摊.Name = "gridCol部门分摊";
            this.gridCol部门分摊.OptionsColumn.AllowEdit = false;
            // 
            // gridCol公用分摊
            // 
            this.gridCol公用分摊.Caption = "公用分摊";
            this.gridCol公用分摊.FieldName = "公用分摊";
            this.gridCol公用分摊.Name = "gridCol公用分摊";
            this.gridCol公用分摊.OptionsColumn.AllowEdit = false;
            // 
            // gridColcDepCode
            // 
            this.gridColcDepCode.Caption = "部门编码";
            this.gridColcDepCode.FieldName = "cDepCode";
            this.gridColcDepCode.Name = "gridColcDepCode";
            this.gridColcDepCode.OptionsColumn.AllowEdit = false;
            this.gridColcDepCode.Visible = true;
            this.gridColcDepCode.VisibleIndex = 2;
            // 
            // gridColcDepName
            // 
            this.gridColcDepName.Caption = "部门";
            this.gridColcDepName.FieldName = "cDepName";
            this.gridColcDepName.Name = "gridColcDepName";
            this.gridColcDepName.OptionsColumn.AllowEdit = false;
            this.gridColcDepName.Visible = true;
            this.gridColcDepName.VisibleIndex = 3;
            // 
            // gridCol计算时间
            // 
            this.gridCol计算时间.Caption = "计算时间";
            this.gridCol计算时间.FieldName = "计算时间";
            this.gridCol计算时间.Name = "gridCol计算时间";
            this.gridCol计算时间.OptionsColumn.AllowEdit = false;
            // 
            // gridCol产品总数
            // 
            this.gridCol产品总数.Caption = "产品总数";
            this.gridCol产品总数.FieldName = "产品总数";
            this.gridCol产品总数.Name = "gridCol产品总数";
            this.gridCol产品总数.OptionsColumn.AllowEdit = false;
            // 
            // ItemLookUpEditcInvCode
            // 
            this.ItemLookUpEditcInvCode.AutoHeight = false;
            this.ItemLookUpEditcInvCode.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.ItemLookUpEditcInvCode.DisplayMember = "cInvCode";
            this.ItemLookUpEditcInvCode.Name = "ItemLookUpEditcInvCode";
            this.ItemLookUpEditcInvCode.NullText = "";
            this.ItemLookUpEditcInvCode.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.Standard;
            this.ItemLookUpEditcInvCode.ValueMember = "cInvCode";
            // 
            // ItemLookUpEditcInvName
            // 
            this.ItemLookUpEditcInvName.AutoHeight = false;
            this.ItemLookUpEditcInvName.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.ItemLookUpEditcInvName.DisplayMember = "cInvName";
            this.ItemLookUpEditcInvName.Name = "ItemLookUpEditcInvName";
            this.ItemLookUpEditcInvName.NullText = "";
            this.ItemLookUpEditcInvName.ValueMember = "cInvCode";
            // 
            // ItemLookUpEditcInvStd
            // 
            this.ItemLookUpEditcInvStd.AutoHeight = false;
            this.ItemLookUpEditcInvStd.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.ItemLookUpEditcInvStd.DisplayMember = "cInvStd";
            this.ItemLookUpEditcInvStd.Name = "ItemLookUpEditcInvStd";
            this.ItemLookUpEditcInvStd.NullText = "";
            this.ItemLookUpEditcInvStd.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.Standard;
            this.ItemLookUpEditcInvStd.ValueMember = "cInvCode";
            // 
            // ItemLookUpEditcComUnitName
            // 
            this.ItemLookUpEditcComUnitName.AutoHeight = false;
            this.ItemLookUpEditcComUnitName.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.ItemLookUpEditcComUnitName.DisplayMember = "cComUnitName";
            this.ItemLookUpEditcComUnitName.Name = "ItemLookUpEditcComUnitName";
            this.ItemLookUpEditcComUnitName.NullText = "";
            this.ItemLookUpEditcComUnitName.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.Standard;
            this.ItemLookUpEditcComUnitName.ValueMember = "cInvCode";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.ForeColor = System.Drawing.Color.Blue;
            this.label3.Location = new System.Drawing.Point(20, 72);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(67, 15);
            this.label3.TabIndex = 192;
            this.label3.Text = "会计期间";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lookUpEdit会计期间
            // 
            this.lookUpEdit会计期间.AllowHtmlTextInToolTip = DevExpress.Utils.DefaultBoolean.True;
            this.lookUpEdit会计期间.Location = new System.Drawing.Point(99, 68);
            this.lookUpEdit会计期间.Margin = new System.Windows.Forms.Padding(4);
            this.lookUpEdit会计期间.Name = "lookUpEdit会计期间";
            this.lookUpEdit会计期间.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.lookUpEdit会计期间.Properties.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("会计期间", "会计期间")});
            this.lookUpEdit会计期间.Properties.DisplayMember = "会计期间";
            this.lookUpEdit会计期间.Properties.NullText = "";
            this.lookUpEdit会计期间.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.Standard;
            this.lookUpEdit会计期间.Properties.ValueMember = "会计期间";
            this.lookUpEdit会计期间.Size = new System.Drawing.Size(161, 24);
            this.lookUpEdit会计期间.TabIndex = 193;
            // 
            // panel1
            // 
            this.panel1.AutoScroll = true;
            this.panel1.Controls.Add(this.lookUpEdit会计期间);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.gridControl1);
            this.panel1.Controls.Add(this.labelControl1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 28);
            this.panel1.Margin = new System.Windows.Forms.Padding(4);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1204, 494);
            this.panel1.TabIndex = 173;
            // 
            // 成本分配表
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.menuStrip1);
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "成本分配表";
            this.Size = new System.Drawing.Size(1204, 522);
            this.Load += new System.EventHandler(this.Frm_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ItemLookUpEditcInvCode)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ItemLookUpEditcInvName)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ItemLookUpEditcInvStd)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ItemLookUpEditcComUnitName)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lookUpEdit会计期间.Properties)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem btnExport;
        private System.Windows.Forms.ToolStripMenuItem btnSEL;
        private DevExpress.XtraEditors.LabelControl labelControl1;
        private DevExpress.XtraGrid.GridControl gridControl1;
        private System.Windows.Forms.Label label3;
        private DevExpress.XtraEditors.LookUpEdit lookUpEdit会计期间;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.ToolStripMenuItem btnClear;
        private DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit ItemLookUpEditcInvCode;
        private DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit ItemLookUpEditcInvName;
        private DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit ItemLookUpEditcInvStd;
        private DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit ItemLookUpEditcComUnitName;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView1;
        private DevExpress.XtraGrid.Columns.GridColumn gridColid;
        private DevExpress.XtraGrid.Columns.GridColumn gridColautoid;
        private DevExpress.XtraGrid.Columns.GridColumn gridColcCode;
        private DevExpress.XtraGrid.Columns.GridColumn gridColdDate;
        private DevExpress.XtraGrid.Columns.GridColumn gridColcRdCode;
        private DevExpress.XtraGrid.Columns.GridColumn gridColcInvCode;
        private DevExpress.XtraGrid.Columns.GridColumn gridColcInvName;
        private DevExpress.XtraGrid.Columns.GridColumn gridColcInvStd;
        private DevExpress.XtraGrid.Columns.GridColumn gridColiQuantity;
        private DevExpress.XtraGrid.Columns.GridColumn gridColiUnitCost;
        private DevExpress.XtraGrid.Columns.GridColumn gridColiPrice;
        private DevExpress.XtraGrid.Columns.GridColumn gridColRdType;
        private DevExpress.XtraGrid.Columns.GridColumn gridCol料;
        private DevExpress.XtraGrid.Columns.GridColumn gridCol部门分摊;
        private DevExpress.XtraGrid.Columns.GridColumn gridCol公用分摊;
        private DevExpress.XtraGrid.Columns.GridColumn gridColcDepCode;
        private DevExpress.XtraGrid.Columns.GridColumn gridColcDepName;
        private System.Windows.Forms.ToolStripMenuItem btn计算;
        private System.Windows.Forms.ToolStripMenuItem btnSave;
        private DevExpress.XtraGrid.Columns.GridColumn gridCol计算时间;
        private DevExpress.XtraGrid.Columns.GridColumn gridCol产品总数;
    }
}
