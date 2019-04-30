namespace UFIDA.U8.UAP.CustomApp.ControlForm
{
    partial class SaleBillVouch
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
            this.btnExportTxt = new System.Windows.Forms.ToolStripMenuItem();
            this.gridControl1 = new DevExpress.XtraGrid.GridControl();
            this.gridView1 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.gridColchoose = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColcSBVCode = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColdDate = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColcSOCode = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColcCusCode = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColcCusName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColcexch_name = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColcInvCode = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColcInvName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColcInvStd = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColiQuantity = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColiNum = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColiUnitPrice = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColiTaxUnitPrice = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColiSum = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColcBatch = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColbSettleAll = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColSBVID = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColAutoID = new DevExpress.XtraGrid.Columns.GridColumn();
            this.panel1 = new System.Windows.Forms.Panel();
            this.chkAll = new DevExpress.XtraEditors.CheckEdit();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.lookUpEditcSBVCode2 = new DevExpress.XtraEditors.LookUpEdit();
            this.lookUpEditcSBVCode1 = new DevExpress.XtraEditors.LookUpEdit();
            this.dateEdit2 = new DevExpress.XtraEditors.DateEdit();
            this.dateEdit1 = new DevExpress.XtraEditors.DateEdit();
            this.menuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).BeginInit();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chkAll.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lookUpEditcSBVCode2.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lookUpEditcSBVCode1.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dateEdit2.Properties.VistaTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dateEdit2.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dateEdit1.Properties.VistaTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dateEdit1.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btnSEL,
            this.btnExportTxt});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(944, 25);
            this.menuStrip1.TabIndex = 172;
            this.menuStrip1.Text = "menuStrip";
            // 
            // btnSEL
            // 
            this.btnSEL.Name = "btnSEL";
            this.btnSEL.Size = new System.Drawing.Size(55, 21);
            this.btnSEL.Text = "Query";
            this.btnSEL.Click += new System.EventHandler(this.btnSEL_Click);
            // 
            // btnExportTxt
            // 
            this.btnExportTxt.Name = "btnExportTxt";
            this.btnExportTxt.Size = new System.Drawing.Size(58, 21);
            this.btnExportTxt.Text = "Export";
            this.btnExportTxt.Click += new System.EventHandler(this.btnExportTxt_Click);
            // 
            // gridControl1
            // 
            this.gridControl1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.gridControl1.Location = new System.Drawing.Point(3, 76);
            this.gridControl1.LookAndFeel.SkinName = "Office 2010 Blue";
            this.gridControl1.MainView = this.gridView1;
            this.gridControl1.Name = "gridControl1";
            this.gridControl1.Size = new System.Drawing.Size(938, 350);
            this.gridControl1.TabIndex = 191;
            this.gridControl1.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView1});
            // 
            // gridView1
            // 
            this.gridView1.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.gridColchoose,
            this.gridColcSBVCode,
            this.gridColdDate,
            this.gridColcSOCode,
            this.gridColcCusCode,
            this.gridColcCusName,
            this.gridColcexch_name,
            this.gridColcInvCode,
            this.gridColcInvName,
            this.gridColcInvStd,
            this.gridColiQuantity,
            this.gridColiNum,
            this.gridColiUnitPrice,
            this.gridColiTaxUnitPrice,
            this.gridColiSum,
            this.gridColcBatch,
            this.gridColbSettleAll,
            this.gridColSBVID,
            this.gridColAutoID});
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
            // gridColchoose
            // 
            this.gridColchoose.Caption = "Selected";
            this.gridColchoose.FieldName = "choose";
            this.gridColchoose.Name = "gridColchoose";
            this.gridColchoose.Visible = true;
            this.gridColchoose.VisibleIndex = 0;
            this.gridColchoose.Width = 45;
            // 
            // gridColcSBVCode
            // 
            this.gridColcSBVCode.Caption = "Invoice No";
            this.gridColcSBVCode.FieldName = "cSBVCode";
            this.gridColcSBVCode.Name = "gridColcSBVCode";
            this.gridColcSBVCode.OptionsColumn.AllowEdit = false;
            this.gridColcSBVCode.Visible = true;
            this.gridColcSBVCode.VisibleIndex = 1;
            // 
            // gridColdDate
            // 
            this.gridColdDate.Caption = "Date";
            this.gridColdDate.FieldName = "dDate";
            this.gridColdDate.Name = "gridColdDate";
            this.gridColdDate.OptionsColumn.AllowEdit = false;
            this.gridColdDate.Visible = true;
            this.gridColdDate.VisibleIndex = 2;
            // 
            // gridColcSOCode
            // 
            this.gridColcSOCode.Caption = "Order No";
            this.gridColcSOCode.FieldName = "cSOCode";
            this.gridColcSOCode.Name = "gridColcSOCode";
            this.gridColcSOCode.OptionsColumn.AllowEdit = false;
            this.gridColcSOCode.Visible = true;
            this.gridColcSOCode.VisibleIndex = 3;
            // 
            // gridColcCusCode
            // 
            this.gridColcCusCode.Caption = "Cust No";
            this.gridColcCusCode.FieldName = "cCusCode";
            this.gridColcCusCode.Name = "gridColcCusCode";
            this.gridColcCusCode.OptionsColumn.AllowEdit = false;
            this.gridColcCusCode.Visible = true;
            this.gridColcCusCode.VisibleIndex = 4;
            // 
            // gridColcCusName
            // 
            this.gridColcCusName.Caption = "Cust Name";
            this.gridColcCusName.FieldName = "cCusName";
            this.gridColcCusName.Name = "gridColcCusName";
            this.gridColcCusName.OptionsColumn.AllowEdit = false;
            this.gridColcCusName.Visible = true;
            this.gridColcCusName.VisibleIndex = 5;
            // 
            // gridColcexch_name
            // 
            this.gridColcexch_name.Caption = "Currency";
            this.gridColcexch_name.FieldName = "cexch_name";
            this.gridColcexch_name.Name = "gridColcexch_name";
            this.gridColcexch_name.OptionsColumn.AllowEdit = false;
            this.gridColcexch_name.Visible = true;
            this.gridColcexch_name.VisibleIndex = 6;
            // 
            // gridColcInvCode
            // 
            this.gridColcInvCode.Caption = "Item No";
            this.gridColcInvCode.FieldName = "cInvCode";
            this.gridColcInvCode.Name = "gridColcInvCode";
            this.gridColcInvCode.OptionsColumn.AllowEdit = false;
            this.gridColcInvCode.Visible = true;
            this.gridColcInvCode.VisibleIndex = 7;
            // 
            // gridColcInvName
            // 
            this.gridColcInvName.Caption = "Item Desc";
            this.gridColcInvName.FieldName = "cInvName";
            this.gridColcInvName.Name = "gridColcInvName";
            this.gridColcInvName.OptionsColumn.AllowEdit = false;
            this.gridColcInvName.Visible = true;
            this.gridColcInvName.VisibleIndex = 8;
            // 
            // gridColcInvStd
            // 
            this.gridColcInvStd.Caption = "规格型号";
            this.gridColcInvStd.FieldName = "cInvStd";
            this.gridColcInvStd.Name = "gridColcInvStd";
            this.gridColcInvStd.OptionsColumn.AllowEdit = false;
            // 
            // gridColiQuantity
            // 
            this.gridColiQuantity.Caption = "Qty";
            this.gridColiQuantity.FieldName = "iQuantity";
            this.gridColiQuantity.Name = "gridColiQuantity";
            this.gridColiQuantity.OptionsColumn.AllowEdit = false;
            this.gridColiQuantity.Visible = true;
            this.gridColiQuantity.VisibleIndex = 9;
            // 
            // gridColiNum
            // 
            this.gridColiNum.Caption = "件数";
            this.gridColiNum.FieldName = "iNum";
            this.gridColiNum.Name = "gridColiNum";
            this.gridColiNum.OptionsColumn.AllowEdit = false;
            // 
            // gridColiUnitPrice
            // 
            this.gridColiUnitPrice.Caption = "Original Currency Excl Tax";
            this.gridColiUnitPrice.FieldName = "iUnitPrice";
            this.gridColiUnitPrice.Name = "gridColiUnitPrice";
            this.gridColiUnitPrice.OptionsColumn.AllowEdit = false;
            this.gridColiUnitPrice.Visible = true;
            this.gridColiUnitPrice.VisibleIndex = 10;
            this.gridColiUnitPrice.Width = 90;
            // 
            // gridColiTaxUnitPrice
            // 
            this.gridColiTaxUnitPrice.Caption = "Original Currency Incl Tax";
            this.gridColiTaxUnitPrice.FieldName = "iTaxUnitPrice";
            this.gridColiTaxUnitPrice.Name = "gridColiTaxUnitPrice";
            this.gridColiTaxUnitPrice.OptionsColumn.AllowEdit = false;
            this.gridColiTaxUnitPrice.Visible = true;
            this.gridColiTaxUnitPrice.VisibleIndex = 11;
            this.gridColiTaxUnitPrice.Width = 91;
            // 
            // gridColiSum
            // 
            this.gridColiSum.Caption = "Original Currency Total";
            this.gridColiSum.FieldName = "iSum";
            this.gridColiSum.Name = "gridColiSum";
            this.gridColiSum.OptionsColumn.AllowEdit = false;
            this.gridColiSum.Visible = true;
            this.gridColiSum.VisibleIndex = 12;
            this.gridColiSum.Width = 85;
            // 
            // gridColcBatch
            // 
            this.gridColcBatch.Caption = "Batch No.";
            this.gridColcBatch.FieldName = "cBatch";
            this.gridColcBatch.Name = "gridColcBatch";
            this.gridColcBatch.OptionsColumn.AllowEdit = false;
            this.gridColcBatch.Visible = true;
            this.gridColcBatch.VisibleIndex = 13;
            // 
            // gridColbSettleAll
            // 
            this.gridColbSettleAll.Caption = "是否结算";
            this.gridColbSettleAll.FieldName = "bSettleAll";
            this.gridColbSettleAll.Name = "gridColbSettleAll";
            this.gridColbSettleAll.OptionsColumn.AllowEdit = false;
            // 
            // gridColSBVID
            // 
            this.gridColSBVID.Caption = "SBVID";
            this.gridColSBVID.FieldName = "SBVID";
            this.gridColSBVID.Name = "gridColSBVID";
            this.gridColSBVID.OptionsColumn.AllowEdit = false;
            // 
            // gridColAutoID
            // 
            this.gridColAutoID.Caption = "AutoID";
            this.gridColAutoID.FieldName = "AutoID";
            this.gridColAutoID.Name = "gridColAutoID";
            this.gridColAutoID.OptionsColumn.AllowEdit = false;
            // 
            // panel1
            // 
            this.panel1.AutoScroll = true;
            this.panel1.Controls.Add(this.chkAll);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.lookUpEditcSBVCode2);
            this.panel1.Controls.Add(this.lookUpEditcSBVCode1);
            this.panel1.Controls.Add(this.dateEdit2);
            this.panel1.Controls.Add(this.dateEdit1);
            this.panel1.Controls.Add(this.gridControl1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 25);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(944, 431);
            this.panel1.TabIndex = 173;
            // 
            // chkAll
            // 
            this.chkAll.Location = new System.Drawing.Point(12, 51);
            this.chkAll.Name = "chkAll";
            this.chkAll.Properties.Caption = "Select All";
            this.chkAll.Size = new System.Drawing.Size(75, 19);
            this.chkAll.TabIndex = 198;
            this.chkAll.CheckedChanged += new System.EventHandler(this.chkAll_CheckedChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(331, 24);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(103, 15);
            this.label2.TabIndex = 197;
            this.label2.Text = "Invoice Date";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 24);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(95, 15);
            this.label1.TabIndex = 196;
            this.label1.Text = "Invoice No.";
            // 
            // lookUpEditcSBVCode2
            // 
            this.lookUpEditcSBVCode2.Location = new System.Drawing.Point(225, 21);
            this.lookUpEditcSBVCode2.Name = "lookUpEditcSBVCode2";
            this.lookUpEditcSBVCode2.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.lookUpEditcSBVCode2.Properties.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("cSBVCode", "发票号")});
            this.lookUpEditcSBVCode2.Properties.DisplayMember = "cSBVCode";
            this.lookUpEditcSBVCode2.Properties.NullText = "";
            this.lookUpEditcSBVCode2.Properties.ValueMember = "cSBVCode";
            this.lookUpEditcSBVCode2.Size = new System.Drawing.Size(100, 20);
            this.lookUpEditcSBVCode2.TabIndex = 195;
            // 
            // lookUpEditcSBVCode1
            // 
            this.lookUpEditcSBVCode1.Location = new System.Drawing.Point(119, 21);
            this.lookUpEditcSBVCode1.Name = "lookUpEditcSBVCode1";
            this.lookUpEditcSBVCode1.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.lookUpEditcSBVCode1.Properties.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("cSBVCode", "发票号")});
            this.lookUpEditcSBVCode1.Properties.DisplayMember = "cSBVCode";
            this.lookUpEditcSBVCode1.Properties.NullText = "";
            this.lookUpEditcSBVCode1.Properties.ValueMember = "cSBVCode";
            this.lookUpEditcSBVCode1.Size = new System.Drawing.Size(100, 20);
            this.lookUpEditcSBVCode1.TabIndex = 194;
            // 
            // dateEdit2
            // 
            this.dateEdit2.EditValue = null;
            this.dateEdit2.Location = new System.Drawing.Point(551, 21);
            this.dateEdit2.Name = "dateEdit2";
            this.dateEdit2.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.dateEdit2.Properties.VistaTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
            this.dateEdit2.Size = new System.Drawing.Size(100, 20);
            this.dateEdit2.TabIndex = 193;
            // 
            // dateEdit1
            // 
            this.dateEdit1.EditValue = null;
            this.dateEdit1.Location = new System.Drawing.Point(445, 21);
            this.dateEdit1.Name = "dateEdit1";
            this.dateEdit1.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.dateEdit1.Properties.VistaTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
            this.dateEdit1.Size = new System.Drawing.Size(100, 20);
            this.dateEdit1.TabIndex = 192;
            // 
            // SaleBillVouch
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.menuStrip1);
            this.Name = "SaleBillVouch";
            this.Size = new System.Drawing.Size(944, 456);
            this.Load += new System.EventHandler(this.Frm_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chkAll.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lookUpEditcSBVCode2.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lookUpEditcSBVCode1.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dateEdit2.Properties.VistaTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dateEdit2.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dateEdit1.Properties.VistaTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dateEdit1.Properties)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private DevExpress.XtraGrid.GridControl gridControl1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.ToolStripMenuItem btnSEL;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView1;
        private System.Windows.Forms.ToolStripMenuItem btnExportTxt;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private DevExpress.XtraEditors.LookUpEdit lookUpEditcSBVCode2;
        private DevExpress.XtraEditors.LookUpEdit lookUpEditcSBVCode1;
        private DevExpress.XtraEditors.DateEdit dateEdit2;
        private DevExpress.XtraEditors.DateEdit dateEdit1;
        private DevExpress.XtraGrid.Columns.GridColumn gridColcSBVCode;
        private DevExpress.XtraGrid.Columns.GridColumn gridColdDate;
        private DevExpress.XtraGrid.Columns.GridColumn gridColcSOCode;
        private DevExpress.XtraGrid.Columns.GridColumn gridColcCusCode;
        private DevExpress.XtraGrid.Columns.GridColumn gridColcCusName;
        private DevExpress.XtraGrid.Columns.GridColumn gridColcexch_name;
        private DevExpress.XtraGrid.Columns.GridColumn gridColcInvCode;
        private DevExpress.XtraGrid.Columns.GridColumn gridColcInvName;
        private DevExpress.XtraGrid.Columns.GridColumn gridColcInvStd;
        private DevExpress.XtraGrid.Columns.GridColumn gridColiQuantity;
        private DevExpress.XtraGrid.Columns.GridColumn gridColiNum;
        private DevExpress.XtraGrid.Columns.GridColumn gridColiUnitPrice;
        private DevExpress.XtraGrid.Columns.GridColumn gridColiTaxUnitPrice;
        private DevExpress.XtraGrid.Columns.GridColumn gridColiSum;
        private DevExpress.XtraGrid.Columns.GridColumn gridColcBatch;
        private DevExpress.XtraGrid.Columns.GridColumn gridColbSettleAll;
        private DevExpress.XtraGrid.Columns.GridColumn gridColchoose;
        private DevExpress.XtraEditors.CheckEdit chkAll;
        private DevExpress.XtraGrid.Columns.GridColumn gridColSBVID;
        private DevExpress.XtraGrid.Columns.GridColumn gridColAutoID;
    }
}
