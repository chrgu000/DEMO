namespace UFIDA.U8.UAP.CustomApp.ControlForm
{
    partial class PurBillVouch
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
            this.btnExport = new System.Windows.Forms.ToolStripMenuItem();
            this.gridControl1 = new DevExpress.XtraGrid.GridControl();
            this.gridView1 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.gridColchoose = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColcPBVCode = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColdPBVDate = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColcVenCode = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColcVenName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColcexch_name = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColcInvCode = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColcInvName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColcInvStd = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColiQuantity = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColiNum = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColiOriCost = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColiOriMoney = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColiOriSum = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColcOrderCode = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColPBVID = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColID = new DevExpress.XtraGrid.Columns.GridColumn();
            this.panel1 = new System.Windows.Forms.Panel();
            this.chkAll = new DevExpress.XtraEditors.CheckEdit();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.lookUpEditcPBVCode2 = new DevExpress.XtraEditors.LookUpEdit();
            this.lookUpEditcPBVCode1 = new DevExpress.XtraEditors.LookUpEdit();
            this.dateEdit2 = new DevExpress.XtraEditors.DateEdit();
            this.dateEdit1 = new DevExpress.XtraEditors.DateEdit();
            this.menuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).BeginInit();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chkAll.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lookUpEditcPBVCode2.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lookUpEditcPBVCode1.Properties)).BeginInit();
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
            this.btnSEL.Size = new System.Drawing.Size(55, 21);
            this.btnSEL.Text = "Query";
            this.btnSEL.Click += new System.EventHandler(this.btnSEL_Click);
            // 
            // btnExport
            // 
            this.btnExport.Name = "btnExport";
            this.btnExport.Size = new System.Drawing.Size(58, 21);
            this.btnExport.Text = "Export";
            this.btnExport.Click += new System.EventHandler(this.btnExport_Click);
            // 
            // gridControl1
            // 
            this.gridControl1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.gridControl1.Location = new System.Drawing.Point(3, 86);
            this.gridControl1.LookAndFeel.SkinName = "Office 2010 Blue";
            this.gridControl1.MainView = this.gridView1;
            this.gridControl1.Name = "gridControl1";
            this.gridControl1.Size = new System.Drawing.Size(938, 340);
            this.gridControl1.TabIndex = 191;
            this.gridControl1.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView1});
            // 
            // gridView1
            // 
            this.gridView1.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.gridColchoose,
            this.gridColcPBVCode,
            this.gridColdPBVDate,
            this.gridColcVenCode,
            this.gridColcVenName,
            this.gridColcexch_name,
            this.gridColcInvCode,
            this.gridColcInvName,
            this.gridColcInvStd,
            this.gridColiQuantity,
            this.gridColiNum,
            this.gridColiOriCost,
            this.gridColiOriMoney,
            this.gridColiOriSum,
            this.gridColcOrderCode,
            this.gridColPBVID,
            this.gridColID});
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
            // gridColcPBVCode
            // 
            this.gridColcPBVCode.Caption = "Invoice No.";
            this.gridColcPBVCode.FieldName = "cPBVCode";
            this.gridColcPBVCode.Name = "gridColcPBVCode";
            this.gridColcPBVCode.OptionsColumn.AllowEdit = false;
            this.gridColcPBVCode.Visible = true;
            this.gridColcPBVCode.VisibleIndex = 1;
            // 
            // gridColdPBVDate
            // 
            this.gridColdPBVDate.Caption = "Date";
            this.gridColdPBVDate.FieldName = "dPBVDate";
            this.gridColdPBVDate.Name = "gridColdPBVDate";
            this.gridColdPBVDate.OptionsColumn.AllowEdit = false;
            this.gridColdPBVDate.Visible = true;
            this.gridColdPBVDate.VisibleIndex = 2;
            // 
            // gridColcVenCode
            // 
            this.gridColcVenCode.Caption = "Supplier No.";
            this.gridColcVenCode.FieldName = "cVenCode";
            this.gridColcVenCode.Name = "gridColcVenCode";
            this.gridColcVenCode.OptionsColumn.AllowEdit = false;
            this.gridColcVenCode.Visible = true;
            this.gridColcVenCode.VisibleIndex = 3;
            // 
            // gridColcVenName
            // 
            this.gridColcVenName.Caption = "Supplier Name";
            this.gridColcVenName.FieldName = "cVenName";
            this.gridColcVenName.Name = "gridColcVenName";
            this.gridColcVenName.OptionsColumn.AllowEdit = false;
            this.gridColcVenName.Visible = true;
            this.gridColcVenName.VisibleIndex = 4;
            // 
            // gridColcexch_name
            // 
            this.gridColcexch_name.Caption = "Currency";
            this.gridColcexch_name.FieldName = "cexch_name";
            this.gridColcexch_name.Name = "gridColcexch_name";
            this.gridColcexch_name.OptionsColumn.AllowEdit = false;
            this.gridColcexch_name.Visible = true;
            this.gridColcexch_name.VisibleIndex = 5;
            // 
            // gridColcInvCode
            // 
            this.gridColcInvCode.Caption = "Item No";
            this.gridColcInvCode.FieldName = "cInvCode";
            this.gridColcInvCode.Name = "gridColcInvCode";
            this.gridColcInvCode.OptionsColumn.AllowEdit = false;
            this.gridColcInvCode.Visible = true;
            this.gridColcInvCode.VisibleIndex = 6;
            // 
            // gridColcInvName
            // 
            this.gridColcInvName.Caption = "Item Desc";
            this.gridColcInvName.FieldName = "cInvName";
            this.gridColcInvName.Name = "gridColcInvName";
            this.gridColcInvName.OptionsColumn.AllowEdit = false;
            this.gridColcInvName.Visible = true;
            this.gridColcInvName.VisibleIndex = 7;
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
            this.gridColiQuantity.FieldName = "iPBVQuantity";
            this.gridColiQuantity.Name = "gridColiQuantity";
            this.gridColiQuantity.OptionsColumn.AllowEdit = false;
            this.gridColiQuantity.Visible = true;
            this.gridColiQuantity.VisibleIndex = 8;
            // 
            // gridColiNum
            // 
            this.gridColiNum.Caption = "件数";
            this.gridColiNum.FieldName = "iNum";
            this.gridColiNum.Name = "gridColiNum";
            this.gridColiNum.OptionsColumn.AllowEdit = false;
            // 
            // gridColiOriCost
            // 
            this.gridColiOriCost.Caption = "Original Currency Unit Price";
            this.gridColiOriCost.FieldName = "iOriCost";
            this.gridColiOriCost.Name = "gridColiOriCost";
            this.gridColiOriCost.OptionsColumn.AllowEdit = false;
            this.gridColiOriCost.Visible = true;
            this.gridColiOriCost.VisibleIndex = 9;
            this.gridColiOriCost.Width = 90;
            // 
            // gridColiOriMoney
            // 
            this.gridColiOriMoney.Caption = "Original Currency Total Excl Tax";
            this.gridColiOriMoney.FieldName = "iOriMoney";
            this.gridColiOriMoney.Name = "gridColiOriMoney";
            this.gridColiOriMoney.OptionsColumn.AllowEdit = false;
            this.gridColiOriMoney.Visible = true;
            this.gridColiOriMoney.VisibleIndex = 10;
            this.gridColiOriMoney.Width = 91;
            // 
            // gridColiOriSum
            // 
            this.gridColiOriSum.Caption = "Original Currency Total Incl Tax";
            this.gridColiOriSum.FieldName = "iOriSum";
            this.gridColiOriSum.Name = "gridColiOriSum";
            this.gridColiOriSum.OptionsColumn.AllowEdit = false;
            this.gridColiOriSum.Visible = true;
            this.gridColiOriSum.VisibleIndex = 11;
            this.gridColiOriSum.Width = 85;
            // 
            // gridColcOrderCode
            // 
            this.gridColcOrderCode.Caption = "采购订单号";
            this.gridColcOrderCode.FieldName = "cOrderCode";
            this.gridColcOrderCode.Name = "gridColcOrderCode";
            this.gridColcOrderCode.OptionsColumn.AllowEdit = false;
            // 
            // gridColPBVID
            // 
            this.gridColPBVID.Caption = "PBVID";
            this.gridColPBVID.FieldName = "PBVID";
            this.gridColPBVID.Name = "gridColPBVID";
            this.gridColPBVID.OptionsColumn.AllowEdit = false;
            // 
            // gridColID
            // 
            this.gridColID.Caption = "ID";
            this.gridColID.FieldName = "ID";
            this.gridColID.Name = "gridColID";
            this.gridColID.OptionsColumn.AllowEdit = false;
            // 
            // panel1
            // 
            this.panel1.AutoScroll = true;
            this.panel1.Controls.Add(this.chkAll);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.lookUpEditcPBVCode2);
            this.panel1.Controls.Add(this.lookUpEditcPBVCode1);
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
            this.chkAll.Location = new System.Drawing.Point(13, 52);
            this.chkAll.Name = "chkAll";
            this.chkAll.Properties.Caption = "Select All";
            this.chkAll.Size = new System.Drawing.Size(75, 19);
            this.chkAll.TabIndex = 198;
            this.chkAll.CheckedChanged += new System.EventHandler(this.chkAll_CheckedChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(324, 21);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(77, 12);
            this.label2.TabIndex = 197;
            this.label2.Text = "Invoice Date";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(17, 21);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(71, 12);
            this.label1.TabIndex = 196;
            this.label1.Text = "Invocie No.";
            // 
            // lookUpEditcPBVCode2
            // 
            this.lookUpEditcPBVCode2.Location = new System.Drawing.Point(201, 18);
            this.lookUpEditcPBVCode2.Name = "lookUpEditcPBVCode2";
            this.lookUpEditcPBVCode2.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.lookUpEditcPBVCode2.Properties.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("cPBVCode", "发票号")});
            this.lookUpEditcPBVCode2.Properties.DisplayMember = "cPBVCode";
            this.lookUpEditcPBVCode2.Properties.NullText = "";
            this.lookUpEditcPBVCode2.Properties.ValueMember = "cPBVCode";
            this.lookUpEditcPBVCode2.Size = new System.Drawing.Size(100, 20);
            this.lookUpEditcPBVCode2.TabIndex = 195;
            // 
            // lookUpEditcPBVCode1
            // 
            this.lookUpEditcPBVCode1.Location = new System.Drawing.Point(94, 18);
            this.lookUpEditcPBVCode1.Name = "lookUpEditcPBVCode1";
            this.lookUpEditcPBVCode1.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.lookUpEditcPBVCode1.Properties.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("cPBVCode", "发票号")});
            this.lookUpEditcPBVCode1.Properties.DisplayMember = "cPBVCode";
            this.lookUpEditcPBVCode1.Properties.NullText = "";
            this.lookUpEditcPBVCode1.Properties.ValueMember = "cPBVCode";
            this.lookUpEditcPBVCode1.Size = new System.Drawing.Size(100, 20);
            this.lookUpEditcPBVCode1.TabIndex = 194;
            // 
            // dateEdit2
            // 
            this.dateEdit2.EditValue = null;
            this.dateEdit2.Location = new System.Drawing.Point(513, 18);
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
            this.dateEdit1.Location = new System.Drawing.Point(407, 18);
            this.dateEdit1.Name = "dateEdit1";
            this.dateEdit1.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.dateEdit1.Properties.VistaTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
            this.dateEdit1.Size = new System.Drawing.Size(100, 20);
            this.dateEdit1.TabIndex = 192;
            // 
            // PurBillVouch
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.menuStrip1);
            this.Name = "PurBillVouch";
            this.Size = new System.Drawing.Size(944, 456);
            this.Load += new System.EventHandler(this.Frm_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chkAll.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lookUpEditcPBVCode2.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lookUpEditcPBVCode1.Properties)).EndInit();
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
        private System.Windows.Forms.ToolStripMenuItem btnExport;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private DevExpress.XtraEditors.LookUpEdit lookUpEditcPBVCode2;
        private DevExpress.XtraEditors.LookUpEdit lookUpEditcPBVCode1;
        private DevExpress.XtraEditors.DateEdit dateEdit2;
        private DevExpress.XtraEditors.DateEdit dateEdit1;
        private DevExpress.XtraGrid.Columns.GridColumn gridColcPBVCode;
        private DevExpress.XtraGrid.Columns.GridColumn gridColdPBVDate;
        private DevExpress.XtraGrid.Columns.GridColumn gridColcVenCode;
        private DevExpress.XtraGrid.Columns.GridColumn gridColcVenName;
        private DevExpress.XtraGrid.Columns.GridColumn gridColcexch_name;
        private DevExpress.XtraGrid.Columns.GridColumn gridColcInvCode;
        private DevExpress.XtraGrid.Columns.GridColumn gridColcInvName;
        private DevExpress.XtraGrid.Columns.GridColumn gridColcInvStd;
        private DevExpress.XtraGrid.Columns.GridColumn gridColiQuantity;
        private DevExpress.XtraGrid.Columns.GridColumn gridColiNum;
        private DevExpress.XtraGrid.Columns.GridColumn gridColiOriCost;
        private DevExpress.XtraGrid.Columns.GridColumn gridColiOriMoney;
        private DevExpress.XtraGrid.Columns.GridColumn gridColiOriSum;
        private DevExpress.XtraGrid.Columns.GridColumn gridColchoose;
        private DevExpress.XtraEditors.CheckEdit chkAll;
        private DevExpress.XtraGrid.Columns.GridColumn gridColPBVID;
        private DevExpress.XtraGrid.Columns.GridColumn gridColID;
        private DevExpress.XtraGrid.Columns.GridColumn gridColcOrderCode;
    }
}
