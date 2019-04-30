namespace UFIDA.U8.UAP.CustomApp.ControlForm
{
    partial class 产品现存量标签打印
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(产品现存量标签打印));
            this.panel1 = new System.Windows.Forms.Panel();
            this.chkAll = new System.Windows.Forms.CheckBox();
            this.grdDetail = new DevExpress.XtraGrid.GridControl();
            this.gridView1 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.gridCol选择 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.ItemChk = new DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit();
            this.gridCol行号 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridCol生产订单号 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridCol存货编码 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridCol存货名称 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridCol规格型号 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridCol长度 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridCol批号 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridCol炉号 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridCol毛重 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridCol净重 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridCol条形码 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridCol件数 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.lookUpEdit生产订单号1 = new DevExpress.XtraEditors.LookUpEdit();
            this.label4 = new System.Windows.Forms.Label();
            this.btnPrintSET = new DevExpress.XtraEditors.SimpleButton();
            this.btnPrint = new DevExpress.XtraEditors.SimpleButton();
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            this.btnSel = new DevExpress.XtraEditors.SimpleButton();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdDetail)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ItemChk)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lookUpEdit生产订单号1.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.chkAll);
            this.panel1.Controls.Add(this.grdDetail);
            this.panel1.Controls.Add(this.lookUpEdit生产订单号1);
            this.panel1.Controls.Add(this.label4);
            this.panel1.Controls.Add(this.btnPrintSET);
            this.panel1.Controls.Add(this.btnPrint);
            this.panel1.Controls.Add(this.labelControl1);
            this.panel1.Controls.Add(this.btnSel);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Margin = new System.Windows.Forms.Padding(4);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(719, 651);
            this.panel1.TabIndex = 0;
            // 
            // chkAll
            // 
            this.chkAll.AutoSize = true;
            this.chkAll.Checked = true;
            this.chkAll.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkAll.Location = new System.Drawing.Point(30, 123);
            this.chkAll.Name = "chkAll";
            this.chkAll.Size = new System.Drawing.Size(59, 19);
            this.chkAll.TabIndex = 118;
            this.chkAll.Text = "全选";
            this.chkAll.UseVisualStyleBackColor = true;
            this.chkAll.CheckedChanged += new System.EventHandler(this.chkAll_CheckedChanged);
            // 
            // grdDetail
            // 
            this.grdDetail.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.grdDetail.EmbeddedNavigator.Margin = new System.Windows.Forms.Padding(4);
            this.grdDetail.Location = new System.Drawing.Point(4, 149);
            this.grdDetail.LookAndFeel.SkinName = "Office 2010 Blue";
            this.grdDetail.MainView = this.gridView1;
            this.grdDetail.Margin = new System.Windows.Forms.Padding(4);
            this.grdDetail.Name = "grdDetail";
            this.grdDetail.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.ItemChk});
            this.grdDetail.Size = new System.Drawing.Size(711, 498);
            this.grdDetail.TabIndex = 117;
            this.grdDetail.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView1});
            // 
            // gridView1
            // 
            this.gridView1.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.gridCol选择,
            this.gridCol行号,
            this.gridCol生产订单号,
            this.gridCol存货编码,
            this.gridCol存货名称,
            this.gridCol规格型号,
            this.gridCol长度,
            this.gridCol批号,
            this.gridCol炉号,
            this.gridCol毛重,
            this.gridCol净重,
            this.gridCol条形码,
            this.gridCol件数});
            this.gridView1.GridControl = this.grdDetail;
            this.gridView1.IndicatorWidth = 40;
            this.gridView1.Name = "gridView1";
            this.gridView1.OptionsBehavior.AllowDeleteRows = DevExpress.Utils.DefaultBoolean.True;
            this.gridView1.OptionsBehavior.EditorShowMode = DevExpress.Utils.EditorShowMode.MouseDown;
            this.gridView1.OptionsCustomization.AllowGroup = false;
            this.gridView1.OptionsCustomization.AllowQuickHideColumns = false;
            this.gridView1.OptionsView.ColumnAutoWidth = false;
            this.gridView1.OptionsView.ShowFooter = true;
            this.gridView1.OptionsView.ShowGroupPanel = false;
            // 
            // gridCol选择
            // 
            this.gridCol选择.Caption = "选择";
            this.gridCol选择.ColumnEdit = this.ItemChk;
            this.gridCol选择.FieldName = "选择";
            this.gridCol选择.Name = "gridCol选择";
            this.gridCol选择.Visible = true;
            this.gridCol选择.VisibleIndex = 0;
            this.gridCol选择.Width = 46;
            // 
            // ItemChk
            // 
            this.ItemChk.Name = "ItemChk";
            // 
            // gridCol行号
            // 
            this.gridCol行号.Caption = "行号";
            this.gridCol行号.FieldName = "行号";
            this.gridCol行号.Name = "gridCol行号";
            this.gridCol行号.OptionsColumn.AllowEdit = false;
            this.gridCol行号.Visible = true;
            this.gridCol行号.VisibleIndex = 2;
            // 
            // gridCol生产订单号
            // 
            this.gridCol生产订单号.Caption = "生产订单号";
            this.gridCol生产订单号.FieldName = "生产订单号";
            this.gridCol生产订单号.Name = "gridCol生产订单号";
            this.gridCol生产订单号.OptionsColumn.AllowEdit = false;
            this.gridCol生产订单号.Visible = true;
            this.gridCol生产订单号.VisibleIndex = 1;
            this.gridCol生产订单号.Width = 125;
            // 
            // gridCol存货编码
            // 
            this.gridCol存货编码.Caption = "存货编码";
            this.gridCol存货编码.FieldName = "存货编码";
            this.gridCol存货编码.Name = "gridCol存货编码";
            this.gridCol存货编码.OptionsColumn.AllowEdit = false;
            this.gridCol存货编码.Visible = true;
            this.gridCol存货编码.VisibleIndex = 3;
            // 
            // gridCol存货名称
            // 
            this.gridCol存货名称.Caption = "存货名称";
            this.gridCol存货名称.FieldName = "存货名称";
            this.gridCol存货名称.Name = "gridCol存货名称";
            this.gridCol存货名称.OptionsColumn.AllowEdit = false;
            this.gridCol存货名称.Visible = true;
            this.gridCol存货名称.VisibleIndex = 4;
            this.gridCol存货名称.Width = 97;
            // 
            // gridCol规格型号
            // 
            this.gridCol规格型号.Caption = "规格型号";
            this.gridCol规格型号.FieldName = "规格型号";
            this.gridCol规格型号.Name = "gridCol规格型号";
            this.gridCol规格型号.OptionsColumn.AllowEdit = false;
            this.gridCol规格型号.Visible = true;
            this.gridCol规格型号.VisibleIndex = 5;
            this.gridCol规格型号.Width = 104;
            // 
            // gridCol长度
            // 
            this.gridCol长度.Caption = "长度";
            this.gridCol长度.FieldName = "长度";
            this.gridCol长度.Name = "gridCol长度";
            this.gridCol长度.OptionsColumn.AllowEdit = false;
            this.gridCol长度.Visible = true;
            this.gridCol长度.VisibleIndex = 11;
            this.gridCol长度.Width = 52;
            // 
            // gridCol批号
            // 
            this.gridCol批号.Caption = "批号";
            this.gridCol批号.FieldName = "批号";
            this.gridCol批号.Name = "gridCol批号";
            this.gridCol批号.OptionsColumn.AllowEdit = false;
            this.gridCol批号.Visible = true;
            this.gridCol批号.VisibleIndex = 9;
            // 
            // gridCol炉号
            // 
            this.gridCol炉号.Caption = "炉号";
            this.gridCol炉号.FieldName = "炉号";
            this.gridCol炉号.Name = "gridCol炉号";
            this.gridCol炉号.OptionsColumn.AllowEdit = false;
            this.gridCol炉号.Visible = true;
            this.gridCol炉号.VisibleIndex = 10;
            this.gridCol炉号.Width = 73;
            // 
            // gridCol毛重
            // 
            this.gridCol毛重.Caption = "毛重";
            this.gridCol毛重.FieldName = "毛重";
            this.gridCol毛重.Name = "gridCol毛重";
            this.gridCol毛重.OptionsColumn.AllowEdit = false;
            this.gridCol毛重.Visible = true;
            this.gridCol毛重.VisibleIndex = 6;
            this.gridCol毛重.Width = 78;
            // 
            // gridCol净重
            // 
            this.gridCol净重.Caption = "净重";
            this.gridCol净重.FieldName = "净重";
            this.gridCol净重.Name = "gridCol净重";
            this.gridCol净重.OptionsColumn.AllowEdit = false;
            this.gridCol净重.Summary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] {
            new DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum)});
            this.gridCol净重.Visible = true;
            this.gridCol净重.VisibleIndex = 7;
            // 
            // gridCol条形码
            // 
            this.gridCol条形码.Caption = "条形码";
            this.gridCol条形码.FieldName = "条形码";
            this.gridCol条形码.Name = "gridCol条形码";
            this.gridCol条形码.OptionsColumn.AllowEdit = false;
            this.gridCol条形码.Visible = true;
            this.gridCol条形码.VisibleIndex = 12;
            // 
            // gridCol件数
            // 
            this.gridCol件数.Caption = "件数";
            this.gridCol件数.FieldName = "件数";
            this.gridCol件数.Name = "gridCol件数";
            this.gridCol件数.OptionsColumn.AllowEdit = false;
            this.gridCol件数.Summary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] {
            new DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum)});
            this.gridCol件数.Visible = true;
            this.gridCol件数.VisibleIndex = 8;
            // 
            // lookUpEdit生产订单号1
            // 
            this.lookUpEdit生产订单号1.Location = new System.Drawing.Point(129, 97);
            this.lookUpEdit生产订单号1.Margin = new System.Windows.Forms.Padding(4);
            this.lookUpEdit生产订单号1.Name = "lookUpEdit生产订单号1";
            this.lookUpEdit生产订单号1.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.lookUpEdit生产订单号1.Properties.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("MoCode", "生产订单号")});
            this.lookUpEdit生产订单号1.Properties.DisplayMember = "MoCode";
            this.lookUpEdit生产订单号1.Properties.NullText = "";
            this.lookUpEdit生产订单号1.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.Standard;
            this.lookUpEdit生产订单号1.Properties.ValueMember = "MoCode";
            this.lookUpEdit生产订单号1.Size = new System.Drawing.Size(145, 24);
            this.lookUpEdit生产订单号1.TabIndex = 116;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(27, 100);
            this.label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(82, 15);
            this.label4.TabIndex = 71;
            this.label4.Text = "生产订单号";
            // 
            // btnPrintSET
            // 
            this.btnPrintSET.Image = ((System.Drawing.Image)(resources.GetObject("btnPrintSET.Image")));
            this.btnPrintSET.ImageLocation = DevExpress.XtraEditors.ImageLocation.TopCenter;
            this.btnPrintSET.Location = new System.Drawing.Point(531, 70);
            this.btnPrintSET.Margin = new System.Windows.Forms.Padding(4);
            this.btnPrintSET.Name = "btnPrintSET";
            this.btnPrintSET.Size = new System.Drawing.Size(75, 51);
            this.btnPrintSET.TabIndex = 69;
            this.btnPrintSET.Text = "打印模板";
            this.btnPrintSET.Click += new System.EventHandler(this.btnPrintSET_Click);
            // 
            // btnPrint
            // 
            this.btnPrint.Image = ((System.Drawing.Image)(resources.GetObject("btnPrint.Image")));
            this.btnPrint.ImageLocation = DevExpress.XtraEditors.ImageLocation.TopCenter;
            this.btnPrint.Location = new System.Drawing.Point(428, 70);
            this.btnPrint.Margin = new System.Windows.Forms.Padding(4);
            this.btnPrint.Name = "btnPrint";
            this.btnPrint.Size = new System.Drawing.Size(61, 51);
            this.btnPrint.TabIndex = 54;
            this.btnPrint.Text = "打印";
            this.btnPrint.Click += new System.EventHandler(this.btnPrint_Click);
            // 
            // labelControl1
            // 
            this.labelControl1.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.labelControl1.Appearance.Font = new System.Drawing.Font("Tahoma", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelControl1.Location = new System.Drawing.Point(226, 20);
            this.labelControl1.Margin = new System.Windows.Forms.Padding(4);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(243, 33);
            this.labelControl1.TabIndex = 23;
            this.labelControl1.Text = "产品库存货标签打印";
            // 
            // btnSel
            // 
            this.btnSel.Image = ((System.Drawing.Image)(resources.GetObject("btnSel.Image")));
            this.btnSel.ImageLocation = DevExpress.XtraEditors.ImageLocation.TopCenter;
            this.btnSel.Location = new System.Drawing.Point(325, 70);
            this.btnSel.Margin = new System.Windows.Forms.Padding(4);
            this.btnSel.Name = "btnSel";
            this.btnSel.Size = new System.Drawing.Size(61, 51);
            this.btnSel.TabIndex = 21;
            this.btnSel.Text = "过滤";
            this.btnSel.Click += new System.EventHandler(this.btnSel_Click);
            // 
            // 产品现存量标签打印
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.panel1);
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "产品现存量标签打印";
            this.Size = new System.Drawing.Size(719, 651);
            this.Load += new System.EventHandler(this.ProjectManager_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdDetail)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ItemChk)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lookUpEdit生产订单号1.Properties)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label4;
        private DevExpress.XtraEditors.SimpleButton btnPrintSET;
        private DevExpress.XtraEditors.SimpleButton btnPrint;
        private DevExpress.XtraEditors.LabelControl labelControl1;
        private DevExpress.XtraEditors.SimpleButton btnSel;
        private DevExpress.XtraEditors.LookUpEdit lookUpEdit生产订单号1;
        private DevExpress.XtraGrid.GridControl grdDetail;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView1;
        private DevExpress.XtraGrid.Columns.GridColumn gridCol选择;
        private DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit ItemChk;
        private DevExpress.XtraGrid.Columns.GridColumn gridCol存货编码;
        private DevExpress.XtraGrid.Columns.GridColumn gridCol存货名称;
        private DevExpress.XtraGrid.Columns.GridColumn gridCol规格型号;
        private DevExpress.XtraGrid.Columns.GridColumn gridCol长度;
        private DevExpress.XtraGrid.Columns.GridColumn gridCol批号;
        private DevExpress.XtraGrid.Columns.GridColumn gridCol炉号;
        private DevExpress.XtraGrid.Columns.GridColumn gridCol毛重;
        private DevExpress.XtraGrid.Columns.GridColumn gridCol条形码;
        private DevExpress.XtraGrid.Columns.GridColumn gridCol生产订单号;
        private DevExpress.XtraGrid.Columns.GridColumn gridCol行号;
        private System.Windows.Forms.CheckBox chkAll;
        private DevExpress.XtraGrid.Columns.GridColumn gridCol净重;
        private DevExpress.XtraGrid.Columns.GridColumn gridCol件数;
    }
}
