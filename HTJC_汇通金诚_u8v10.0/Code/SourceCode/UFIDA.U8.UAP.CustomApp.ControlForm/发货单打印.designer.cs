namespace UFIDA.U8.UAP.CustomApp.ControlForm
{
    partial class 发货单打印
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(发货单打印));
            this.grdDetail = new DevExpress.XtraGrid.GridControl();
            this.gridView1 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.gridCol选择 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.ItemChk = new DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit();
            this.gridCol存货编码 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridCol存货名称 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridCol规格型号 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridCol数量 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridCol条形码 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridCol发货单号 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            this.lookUpEdit发货单号2 = new DevExpress.XtraEditors.LookUpEdit();
            this.chk全选 = new System.Windows.Forms.CheckBox();
            this.lookUpEdit发货单号1 = new DevExpress.XtraEditors.LookUpEdit();
            this.label4 = new System.Windows.Forms.Label();
            this.btnPrintSET = new DevExpress.XtraEditors.SimpleButton();
            this.btnSel = new DevExpress.XtraEditors.SimpleButton();
            this.btn清空 = new DevExpress.XtraEditors.SimpleButton();
            this.btnPrint = new DevExpress.XtraEditors.SimpleButton();
            this.label1 = new System.Windows.Forms.Label();
            this.dtm1 = new DevExpress.XtraEditors.DateEdit();
            this.dtm2 = new DevExpress.XtraEditors.DateEdit();
            ((System.ComponentModel.ISupportInitialize)(this.grdDetail)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ItemChk)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lookUpEdit发货单号2.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lookUpEdit发货单号1.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtm1.Properties.VistaTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtm1.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtm2.Properties.VistaTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtm2.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // grdDetail
            // 
            this.grdDetail.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.grdDetail.EmbeddedNavigator.Margin = new System.Windows.Forms.Padding(4);
            this.grdDetail.Location = new System.Drawing.Point(4, 186);
            this.grdDetail.LookAndFeel.SkinName = "Office 2010 Blue";
            this.grdDetail.MainView = this.gridView1;
            this.grdDetail.Margin = new System.Windows.Forms.Padding(4);
            this.grdDetail.Name = "grdDetail";
            this.grdDetail.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.ItemChk});
            this.grdDetail.Size = new System.Drawing.Size(905, 419);
            this.grdDetail.TabIndex = 101;
            this.grdDetail.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView1});
            // 
            // gridView1
            // 
            this.gridView1.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.gridCol选择,
            this.gridCol存货编码,
            this.gridCol存货名称,
            this.gridCol规格型号,
            this.gridCol数量,
            this.gridCol条形码,
            this.gridCol发货单号});
            this.gridView1.GridControl = this.grdDetail;
            this.gridView1.IndicatorWidth = 40;
            this.gridView1.Name = "gridView1";
            this.gridView1.OptionsBehavior.AllowDeleteRows = DevExpress.Utils.DefaultBoolean.True;
            this.gridView1.OptionsBehavior.EditorShowMode = DevExpress.Utils.EditorShowMode.MouseDown;
            this.gridView1.OptionsCustomization.AllowGroup = false;
            this.gridView1.OptionsCustomization.AllowQuickHideColumns = false;
            this.gridView1.OptionsView.ColumnAutoWidth = false;
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
            // gridCol存货编码
            // 
            this.gridCol存货编码.Caption = "存货编码";
            this.gridCol存货编码.FieldName = "cInvCode";
            this.gridCol存货编码.Name = "gridCol存货编码";
            this.gridCol存货编码.OptionsColumn.AllowEdit = false;
            this.gridCol存货编码.Visible = true;
            this.gridCol存货编码.VisibleIndex = 3;
            // 
            // gridCol存货名称
            // 
            this.gridCol存货名称.Caption = "存货名称";
            this.gridCol存货名称.FieldName = "cInvName";
            this.gridCol存货名称.Name = "gridCol存货名称";
            this.gridCol存货名称.OptionsColumn.AllowEdit = false;
            this.gridCol存货名称.Visible = true;
            this.gridCol存货名称.VisibleIndex = 4;
            this.gridCol存货名称.Width = 97;
            // 
            // gridCol规格型号
            // 
            this.gridCol规格型号.Caption = "规格型号";
            this.gridCol规格型号.FieldName = "cInvStd";
            this.gridCol规格型号.Name = "gridCol规格型号";
            this.gridCol规格型号.OptionsColumn.AllowEdit = false;
            this.gridCol规格型号.Visible = true;
            this.gridCol规格型号.VisibleIndex = 5;
            this.gridCol规格型号.Width = 104;
            // 
            // gridCol数量
            // 
            this.gridCol数量.Caption = "数量";
            this.gridCol数量.FieldName = "iQuantity";
            this.gridCol数量.Name = "gridCol数量";
            this.gridCol数量.OptionsColumn.AllowEdit = false;
            this.gridCol数量.Visible = true;
            this.gridCol数量.VisibleIndex = 6;
            this.gridCol数量.Width = 78;
            // 
            // gridCol条形码
            // 
            this.gridCol条形码.Caption = "条形码";
            this.gridCol条形码.FieldName = "cDLCode";
            this.gridCol条形码.Name = "gridCol条形码";
            this.gridCol条形码.OptionsColumn.AllowEdit = false;
            this.gridCol条形码.Visible = true;
            this.gridCol条形码.VisibleIndex = 1;
            this.gridCol条形码.Width = 109;
            // 
            // gridCol发货单号
            // 
            this.gridCol发货单号.Caption = "发货单号";
            this.gridCol发货单号.FieldName = "cDLCode";
            this.gridCol发货单号.Name = "gridCol发货单号";
            this.gridCol发货单号.OptionsColumn.AllowEdit = false;
            this.gridCol发货单号.Visible = true;
            this.gridCol发货单号.VisibleIndex = 2;
            this.gridCol发货单号.Width = 112;
            // 
            // labelControl1
            // 
            this.labelControl1.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.labelControl1.Appearance.Font = new System.Drawing.Font("Tahoma", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelControl1.Location = new System.Drawing.Point(397, 17);
            this.labelControl1.Margin = new System.Windows.Forms.Padding(4);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(54, 33);
            this.labelControl1.TabIndex = 102;
            this.labelControl1.Text = "发货";
            // 
            // lookUpEdit发货单号2
            // 
            this.lookUpEdit发货单号2.Location = new System.Drawing.Point(322, 68);
            this.lookUpEdit发货单号2.Margin = new System.Windows.Forms.Padding(4);
            this.lookUpEdit发货单号2.Name = "lookUpEdit发货单号2";
            this.lookUpEdit发货单号2.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.lookUpEdit发货单号2.Properties.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("cDLCode", "发货单号")});
            this.lookUpEdit发货单号2.Properties.DisplayMember = "cDLCode";
            this.lookUpEdit发货单号2.Properties.NullText = "";
            this.lookUpEdit发货单号2.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.Standard;
            this.lookUpEdit发货单号2.Properties.ValueMember = "cDLCode";
            this.lookUpEdit发货单号2.Size = new System.Drawing.Size(133, 24);
            this.lookUpEdit发货单号2.TabIndex = 116;
            // 
            // chk全选
            // 
            this.chk全选.AutoSize = true;
            this.chk全选.Location = new System.Drawing.Point(12, 157);
            this.chk全选.Margin = new System.Windows.Forms.Padding(4);
            this.chk全选.Name = "chk全选";
            this.chk全选.Size = new System.Drawing.Size(59, 19);
            this.chk全选.TabIndex = 112;
            this.chk全选.Text = "全选";
            this.chk全选.UseVisualStyleBackColor = true;
            this.chk全选.CheckedChanged += new System.EventHandler(this.chk全选_CheckedChanged);
            // 
            // lookUpEdit发货单号1
            // 
            this.lookUpEdit发货单号1.Location = new System.Drawing.Point(171, 68);
            this.lookUpEdit发货单号1.Margin = new System.Windows.Forms.Padding(4);
            this.lookUpEdit发货单号1.Name = "lookUpEdit发货单号1";
            this.lookUpEdit发货单号1.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.lookUpEdit发货单号1.Properties.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("cDLCode", "发货单号")});
            this.lookUpEdit发货单号1.Properties.DisplayMember = "cDLCode";
            this.lookUpEdit发货单号1.Properties.NullText = "";
            this.lookUpEdit发货单号1.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.Standard;
            this.lookUpEdit发货单号1.Properties.ValueMember = "cDLCode";
            this.lookUpEdit发货单号1.Size = new System.Drawing.Size(133, 24);
            this.lookUpEdit发货单号1.TabIndex = 115;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(81, 73);
            this.label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(67, 15);
            this.label4.TabIndex = 114;
            this.label4.Text = "发货单号";
            // 
            // btnPrintSET
            // 
            this.btnPrintSET.Image = ((System.Drawing.Image)(resources.GetObject("btnPrintSET.Image")));
            this.btnPrintSET.ImageLocation = DevExpress.XtraEditors.ImageLocation.TopCenter;
            this.btnPrintSET.Location = new System.Drawing.Point(766, 73);
            this.btnPrintSET.Margin = new System.Windows.Forms.Padding(4);
            this.btnPrintSET.Name = "btnPrintSET";
            this.btnPrintSET.Size = new System.Drawing.Size(75, 51);
            this.btnPrintSET.TabIndex = 113;
            this.btnPrintSET.Text = "打印模板";
            this.btnPrintSET.Click += new System.EventHandler(this.btnPrintSET_Click);
            // 
            // btnSel
            // 
            this.btnSel.Image = ((System.Drawing.Image)(resources.GetObject("btnSel.Image")));
            this.btnSel.ImageLocation = DevExpress.XtraEditors.ImageLocation.TopCenter;
            this.btnSel.Location = new System.Drawing.Point(614, 73);
            this.btnSel.Margin = new System.Windows.Forms.Padding(4);
            this.btnSel.Name = "btnSel";
            this.btnSel.Size = new System.Drawing.Size(61, 51);
            this.btnSel.TabIndex = 103;
            this.btnSel.Text = "过滤";
            this.btnSel.Click += new System.EventHandler(this.btnSel_Click_1);
            // 
            // btn清空
            // 
            this.btn清空.Image = ((System.Drawing.Image)(resources.GetObject("btn清空.Image")));
            this.btn清空.ImageLocation = DevExpress.XtraEditors.ImageLocation.TopCenter;
            this.btn清空.Location = new System.Drawing.Point(545, 73);
            this.btn清空.Margin = new System.Windows.Forms.Padding(4);
            this.btn清空.Name = "btn清空";
            this.btn清空.Size = new System.Drawing.Size(61, 51);
            this.btn清空.TabIndex = 108;
            this.btn清空.Text = "清空";
            this.btn清空.Click += new System.EventHandler(this.btn清空_Click);
            // 
            // btnPrint
            // 
            this.btnPrint.Image = ((System.Drawing.Image)(resources.GetObject("btnPrint.Image")));
            this.btnPrint.ImageLocation = DevExpress.XtraEditors.ImageLocation.TopCenter;
            this.btnPrint.Location = new System.Drawing.Point(683, 73);
            this.btnPrint.Margin = new System.Windows.Forms.Padding(4);
            this.btnPrint.Name = "btnPrint";
            this.btnPrint.Size = new System.Drawing.Size(61, 51);
            this.btnPrint.TabIndex = 107;
            this.btnPrint.Text = "打印";
            this.btnPrint.Click += new System.EventHandler(this.btnPrint_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(81, 103);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(67, 15);
            this.label1.TabIndex = 117;
            this.label1.Text = "单据日期";
            // 
            // dtm1
            // 
            this.dtm1.EditValue = null;
            this.dtm1.Location = new System.Drawing.Point(171, 98);
            this.dtm1.Margin = new System.Windows.Forms.Padding(4);
            this.dtm1.Name = "dtm1";
            this.dtm1.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.dtm1.Properties.VistaTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
            this.dtm1.Size = new System.Drawing.Size(133, 24);
            this.dtm1.TabIndex = 118;
            // 
            // dtm2
            // 
            this.dtm2.EditValue = null;
            this.dtm2.Location = new System.Drawing.Point(322, 98);
            this.dtm2.Margin = new System.Windows.Forms.Padding(4);
            this.dtm2.Name = "dtm2";
            this.dtm2.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.dtm2.Properties.VistaTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
            this.dtm2.Size = new System.Drawing.Size(133, 24);
            this.dtm2.TabIndex = 119;
            // 
            // 发货单打印
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.dtm2);
            this.Controls.Add(this.dtm1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.lookUpEdit发货单号2);
            this.Controls.Add(this.chk全选);
            this.Controls.Add(this.lookUpEdit发货单号1);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.btnPrintSET);
            this.Controls.Add(this.btnSel);
            this.Controls.Add(this.btn清空);
            this.Controls.Add(this.btnPrint);
            this.Controls.Add(this.labelControl1);
            this.Controls.Add(this.grdDetail);
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "发货单打印";
            this.Size = new System.Drawing.Size(913, 609);
            this.Load += new System.EventHandler(this.生产发料打印_Load);
            ((System.ComponentModel.ISupportInitialize)(this.grdDetail)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ItemChk)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lookUpEdit发货单号2.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lookUpEdit发货单号1.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtm1.Properties.VistaTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtm1.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtm2.Properties.VistaTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtm2.Properties)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraGrid.GridControl grdDetail;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView1;
        private DevExpress.XtraGrid.Columns.GridColumn gridCol选择;
        private DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit ItemChk;
        private DevExpress.XtraGrid.Columns.GridColumn gridCol存货编码;
        private DevExpress.XtraGrid.Columns.GridColumn gridCol存货名称;
        private DevExpress.XtraGrid.Columns.GridColumn gridCol规格型号;
        private DevExpress.XtraGrid.Columns.GridColumn gridCol数量;
        private DevExpress.XtraGrid.Columns.GridColumn gridCol条形码;
        private DevExpress.XtraGrid.Columns.GridColumn gridCol发货单号;
        private DevExpress.XtraEditors.LabelControl labelControl1;
        private DevExpress.XtraEditors.LookUpEdit lookUpEdit发货单号2;
        private System.Windows.Forms.CheckBox chk全选;
        private DevExpress.XtraEditors.LookUpEdit lookUpEdit发货单号1;
        private System.Windows.Forms.Label label4;
        private DevExpress.XtraEditors.SimpleButton btnPrintSET;
        private DevExpress.XtraEditors.SimpleButton btnSel;
        private DevExpress.XtraEditors.SimpleButton btn清空;
        private DevExpress.XtraEditors.SimpleButton btnPrint;
        private System.Windows.Forms.Label label1;
        private DevExpress.XtraEditors.DateEdit dtm1;
        private DevExpress.XtraEditors.DateEdit dtm2;

    }
}
