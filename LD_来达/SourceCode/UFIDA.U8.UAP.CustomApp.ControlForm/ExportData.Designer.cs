namespace UFIDA.U8.UAP.CustomApp.ControlForm
{
    partial class ExportData
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
            this.btn查询 = new System.Windows.Forms.ToolStripMenuItem();
            this.btn导出csv = new System.Windows.Forms.ToolStripMenuItem();
            this.btn导出Txt = new System.Windows.Forms.ToolStripMenuItem();
            this.gridControl1 = new DevExpress.XtraGrid.GridControl();
            this.gridView1 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.gridColOperatingUnit = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColAccount = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColCostCenter = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColAmount = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColPERIOD = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColDR_CR = new DevExpress.XtraGrid.Columns.GridColumn();
            this.ItemTextEditn2 = new DevExpress.XtraEditors.Repository.RepositoryItemTextEdit();
            this.ItemDateEdit1 = new DevExpress.XtraEditors.Repository.RepositoryItemDateEdit();
            this.ItemTextEditn4 = new DevExpress.XtraEditors.Repository.RepositoryItemTextEdit();
            this.ItemLookUpEditCurrency = new DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit();
            this.ItemTextEditn0 = new DevExpress.XtraEditors.Repository.RepositoryItemTextEdit();
            this.ItemTextEditn3 = new DevExpress.XtraEditors.Repository.RepositoryItemTextEdit();
            this.ItemTextEditn1 = new DevExpress.XtraEditors.Repository.RepositoryItemTextEdit();
            this.panel1 = new System.Windows.Forms.Panel();
            this.lookUpEditiYPeriod = new DevExpress.XtraEditors.LookUpEdit();
            this.label3 = new System.Windows.Forms.Label();
            this.gridColIntercompany = new DevExpress.XtraGrid.Columns.GridColumn();
            this.menuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ItemTextEditn2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ItemDateEdit1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ItemDateEdit1.VistaTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ItemTextEditn4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ItemLookUpEditCurrency)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ItemTextEditn0)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ItemTextEditn3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ItemTextEditn1)).BeginInit();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.lookUpEditiYPeriod.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btn查询,
            this.btn导出csv,
            this.btn导出Txt});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Padding = new System.Windows.Forms.Padding(8, 2, 0, 2);
            this.menuStrip1.Size = new System.Drawing.Size(1259, 28);
            this.menuStrip1.TabIndex = 172;
            this.menuStrip1.Text = "menuStrip";
            // 
            // btn查询
            // 
            this.btn查询.Name = "btn查询";
            this.btn查询.Size = new System.Drawing.Size(51, 24);
            this.btn查询.Text = "查询";
            this.btn查询.Click += new System.EventHandler(this.btn查询_Click);
            // 
            // btn导出csv
            // 
            this.btn导出csv.Name = "btn导出csv";
            this.btn导出csv.Size = new System.Drawing.Size(74, 24);
            this.btn导出csv.Text = "导出csv";
            this.btn导出csv.Click += new System.EventHandler(this.btn导出csv_Click);
            // 
            // btn导出Txt
            // 
            this.btn导出Txt.Name = "btn导出Txt";
            this.btn导出Txt.Size = new System.Drawing.Size(74, 24);
            this.btn导出Txt.Text = "导出Txt";
            this.btn导出Txt.Click += new System.EventHandler(this.btn导出Txt_Click);
            // 
            // gridControl1
            // 
            this.gridControl1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.gridControl1.EmbeddedNavigator.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.gridControl1.Location = new System.Drawing.Point(4, 69);
            this.gridControl1.LookAndFeel.SkinName = "Office 2010 Blue";
            this.gridControl1.MainView = this.gridView1;
            this.gridControl1.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.gridControl1.Name = "gridControl1";
            this.gridControl1.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.ItemTextEditn2,
            this.ItemDateEdit1,
            this.ItemTextEditn4,
            this.ItemLookUpEditCurrency,
            this.ItemTextEditn0,
            this.ItemTextEditn3,
            this.ItemTextEditn1});
            this.gridControl1.Size = new System.Drawing.Size(1251, 467);
            this.gridControl1.TabIndex = 191;
            this.gridControl1.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView1});
            // 
            // gridView1
            // 
            this.gridView1.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.gridColOperatingUnit,
            this.gridColAccount,
            this.gridColCostCenter,
            this.gridColAmount,
            this.gridColPERIOD,
            this.gridColDR_CR,
            this.gridColIntercompany});
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
            // gridColOperatingUnit
            // 
            this.gridColOperatingUnit.Caption = "Operating Unit";
            this.gridColOperatingUnit.FieldName = "OperatingUnit";
            this.gridColOperatingUnit.Name = "gridColOperatingUnit";
            this.gridColOperatingUnit.OptionsColumn.AllowEdit = false;
            this.gridColOperatingUnit.Visible = true;
            this.gridColOperatingUnit.VisibleIndex = 0;
            this.gridColOperatingUnit.Width = 150;
            // 
            // gridColAccount
            // 
            this.gridColAccount.Caption = "Account";
            this.gridColAccount.FieldName = "Account";
            this.gridColAccount.Name = "gridColAccount";
            this.gridColAccount.OptionsColumn.AllowEdit = false;
            this.gridColAccount.Visible = true;
            this.gridColAccount.VisibleIndex = 1;
            this.gridColAccount.Width = 125;
            // 
            // gridColCostCenter
            // 
            this.gridColCostCenter.Caption = "Cost Center";
            this.gridColCostCenter.FieldName = "CostCenter";
            this.gridColCostCenter.Name = "gridColCostCenter";
            this.gridColCostCenter.OptionsColumn.AllowEdit = false;
            this.gridColCostCenter.Visible = true;
            this.gridColCostCenter.VisibleIndex = 2;
            this.gridColCostCenter.Width = 135;
            // 
            // gridColAmount
            // 
            this.gridColAmount.Caption = "Amount";
            this.gridColAmount.FieldName = "Amount";
            this.gridColAmount.Name = "gridColAmount";
            this.gridColAmount.OptionsColumn.AllowEdit = false;
            this.gridColAmount.Visible = true;
            this.gridColAmount.VisibleIndex = 4;
            // 
            // gridColPERIOD
            // 
            this.gridColPERIOD.Caption = "PERIOD(mmyy)";
            this.gridColPERIOD.FieldName = "PERIOD";
            this.gridColPERIOD.Name = "gridColPERIOD";
            this.gridColPERIOD.OptionsColumn.AllowEdit = false;
            this.gridColPERIOD.Visible = true;
            this.gridColPERIOD.VisibleIndex = 5;
            this.gridColPERIOD.Width = 164;
            // 
            // gridColDR_CR
            // 
            this.gridColDR_CR.Caption = "DR_CR";
            this.gridColDR_CR.FieldName = "DR_CR";
            this.gridColDR_CR.Name = "gridColDR_CR";
            this.gridColDR_CR.OptionsColumn.AllowEdit = false;
            this.gridColDR_CR.Visible = true;
            this.gridColDR_CR.VisibleIndex = 6;
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
            // ItemDateEdit1
            // 
            this.ItemDateEdit1.AutoHeight = false;
            this.ItemDateEdit1.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.ItemDateEdit1.Name = "ItemDateEdit1";
            this.ItemDateEdit1.VistaTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
            // 
            // ItemTextEditn4
            // 
            this.ItemTextEditn4.AutoHeight = false;
            this.ItemTextEditn4.DisplayFormat.FormatString = "n4";
            this.ItemTextEditn4.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.ItemTextEditn4.EditFormat.FormatString = "n4";
            this.ItemTextEditn4.EditFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.ItemTextEditn4.Mask.EditMask = "n4";
            this.ItemTextEditn4.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Numeric;
            this.ItemTextEditn4.Name = "ItemTextEditn4";
            // 
            // ItemLookUpEditCurrency
            // 
            this.ItemLookUpEditCurrency.AutoHeight = false;
            this.ItemLookUpEditCurrency.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.ItemLookUpEditCurrency.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("cexch_code", "Code"),
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("cexch_name", "Name")});
            this.ItemLookUpEditCurrency.DisplayMember = "cexch_name";
            this.ItemLookUpEditCurrency.Name = "ItemLookUpEditCurrency";
            this.ItemLookUpEditCurrency.NullText = "";
            this.ItemLookUpEditCurrency.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.Standard;
            this.ItemLookUpEditCurrency.ValueMember = "cexch_code";
            // 
            // ItemTextEditn0
            // 
            this.ItemTextEditn0.AutoHeight = false;
            this.ItemTextEditn0.DisplayFormat.FormatString = "n0";
            this.ItemTextEditn0.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.ItemTextEditn0.EditFormat.FormatString = "n0";
            this.ItemTextEditn0.EditFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.ItemTextEditn0.Mask.EditMask = "n0";
            this.ItemTextEditn0.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Numeric;
            this.ItemTextEditn0.Name = "ItemTextEditn0";
            // 
            // ItemTextEditn3
            // 
            this.ItemTextEditn3.AutoHeight = false;
            this.ItemTextEditn3.DisplayFormat.FormatString = "n3";
            this.ItemTextEditn3.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.ItemTextEditn3.EditFormat.FormatString = "n3";
            this.ItemTextEditn3.EditFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.ItemTextEditn3.Mask.EditMask = "n3";
            this.ItemTextEditn3.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Numeric;
            this.ItemTextEditn3.Name = "ItemTextEditn3";
            // 
            // ItemTextEditn1
            // 
            this.ItemTextEditn1.AutoHeight = false;
            this.ItemTextEditn1.DisplayFormat.FormatString = "n1";
            this.ItemTextEditn1.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.ItemTextEditn1.EditFormat.FormatString = "n1";
            this.ItemTextEditn1.EditFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.ItemTextEditn1.Mask.EditMask = "n1";
            this.ItemTextEditn1.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Numeric;
            this.ItemTextEditn1.Name = "ItemTextEditn1";
            // 
            // panel1
            // 
            this.panel1.AutoScroll = true;
            this.panel1.Controls.Add(this.lookUpEditiYPeriod);
            this.panel1.Controls.Add(this.gridControl1);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 28);
            this.panel1.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1259, 542);
            this.panel1.TabIndex = 173;
            // 
            // lookUpEditiYPeriod
            // 
            this.lookUpEditiYPeriod.Location = new System.Drawing.Point(132, 18);
            this.lookUpEditiYPeriod.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.lookUpEditiYPeriod.Name = "lookUpEditiYPeriod";
            this.lookUpEditiYPeriod.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.lookUpEditiYPeriod.Properties.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("iYPeriod", 80, "期间")});
            this.lookUpEditiYPeriod.Properties.DisplayMember = "iYPeriod";
            this.lookUpEditiYPeriod.Properties.NullText = "";
            this.lookUpEditiYPeriod.Properties.PopupWidth = 400;
            this.lookUpEditiYPeriod.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.Standard;
            this.lookUpEditiYPeriod.Properties.ValueMember = "iYPeriod";
            this.lookUpEditiYPeriod.Size = new System.Drawing.Size(113, 24);
            this.lookUpEditiYPeriod.TabIndex = 243;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.ForeColor = System.Drawing.Color.Blue;
            this.label3.Location = new System.Drawing.Point(32, 24);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(67, 15);
            this.label3.TabIndex = 222;
            this.label3.Text = "会计期间";
            // 
            // gridColIntercompany
            // 
            this.gridColIntercompany.Caption = "Intercompany";
            this.gridColIntercompany.FieldName = "Intercompany";
            this.gridColIntercompany.Name = "gridColIntercompany";
            this.gridColIntercompany.OptionsColumn.AllowEdit = false;
            this.gridColIntercompany.Visible = true;
            this.gridColIntercompany.VisibleIndex = 3;
            this.gridColIntercompany.Width = 155;
            // 
            // ExportData
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.menuStrip1);
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Name = "ExportData";
            this.Size = new System.Drawing.Size(1259, 570);
            this.Load += new System.EventHandler(this.Frm_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ItemTextEditn2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ItemDateEdit1.VistaTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ItemDateEdit1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ItemTextEditn4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ItemLookUpEditCurrency)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ItemTextEditn0)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ItemTextEditn3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ItemTextEditn1)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.lookUpEditiYPeriod.Properties)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private DevExpress.XtraGrid.GridControl gridControl1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label3;
        private DevExpress.XtraEditors.Repository.RepositoryItemTextEdit ItemTextEditn2;
        private DevExpress.XtraEditors.Repository.RepositoryItemDateEdit ItemDateEdit1;
        private DevExpress.XtraEditors.Repository.RepositoryItemTextEdit ItemTextEditn4;
        private DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit ItemLookUpEditCurrency;
        private DevExpress.XtraEditors.Repository.RepositoryItemTextEdit ItemTextEditn0;
        private DevExpress.XtraEditors.Repository.RepositoryItemTextEdit ItemTextEditn3;
        private DevExpress.XtraEditors.Repository.RepositoryItemTextEdit ItemTextEditn1;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView1;
        private System.Windows.Forms.ToolStripMenuItem btn查询;
        private System.Windows.Forms.ToolStripMenuItem btn导出csv;
        private DevExpress.XtraEditors.LookUpEdit lookUpEditiYPeriod;
        private DevExpress.XtraGrid.Columns.GridColumn gridColOperatingUnit;
        private DevExpress.XtraGrid.Columns.GridColumn gridColAccount;
        private DevExpress.XtraGrid.Columns.GridColumn gridColCostCenter;
        private DevExpress.XtraGrid.Columns.GridColumn gridColAmount;
        private DevExpress.XtraGrid.Columns.GridColumn gridColPERIOD;
        private DevExpress.XtraGrid.Columns.GridColumn gridColDR_CR;
        private System.Windows.Forms.ToolStripMenuItem btn导出Txt;
        private DevExpress.XtraGrid.Columns.GridColumn gridColIntercompany;
    }
}
