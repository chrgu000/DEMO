namespace UFIDA.U8.UAP.CustomApp.ControlForm
{
    partial class FrmchkVouch01_SEL
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            DevExpress.XtraGrid.GridLevelNode gridLevelNode1 = new DevExpress.XtraGrid.GridLevelNode();
            this.label1 = new System.Windows.Forms.Label();
            this.lookUpEdit班组 = new DevExpress.XtraEditors.LookUpEdit();
            this.lookUpEdit工序 = new DevExpress.XtraEditors.LookUpEdit();
            this.label20 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.lookUpEdit生产订单号 = new DevExpress.XtraEditors.LookUpEdit();
            this.label10 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.lookUpEditcInvCode = new DevExpress.XtraEditors.LookUpEdit();
            this.lookUpEditcCode = new DevExpress.XtraEditors.LookUpEdit();
            this.dtm1 = new DevExpress.XtraEditors.DateEdit();
            this.label62 = new System.Windows.Forms.Label();
            this.dtm2 = new DevExpress.XtraEditors.DateEdit();
            this.label4 = new System.Windows.Forms.Label();
            this.btnSEL = new System.Windows.Forms.Button();
            this.gridControl1 = new DevExpress.XtraGrid.GridControl();
            this.gridView1 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.gridColcCode = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColdtmCode = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColWONo = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColWorkGroup = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColWorkProcess = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColcInvCode = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColcInvName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.btnOK = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.lookUpEditcInvName = new DevExpress.XtraEditors.LookUpEdit();
            ((System.ComponentModel.ISupportInitialize)(this.lookUpEdit班组.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lookUpEdit工序.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lookUpEdit生产订单号.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lookUpEditcInvCode.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lookUpEditcCode.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtm1.Properties.VistaTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtm1.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtm2.Properties.VistaTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtm2.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lookUpEditcInvName.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(38, 24);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(41, 12);
            this.label1.TabIndex = 213;
            this.label1.Text = "单据号";
            // 
            // lookUpEdit班组
            // 
            this.lookUpEdit班组.Location = new System.Drawing.Point(326, 68);
            this.lookUpEdit班组.Name = "lookUpEdit班组";
            this.lookUpEdit班组.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.lookUpEdit班组.Properties.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("WorkGroup", "班组")});
            this.lookUpEdit班组.Properties.DisplayMember = "WorkGroup";
            this.lookUpEdit班组.Properties.NullText = "";
            this.lookUpEdit班组.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.Standard;
            this.lookUpEdit班组.Properties.ValueMember = "WorkGroup";
            this.lookUpEdit班组.Size = new System.Drawing.Size(122, 20);
            this.lookUpEdit班组.TabIndex = 6;
            // 
            // lookUpEdit工序
            // 
            this.lookUpEdit工序.Location = new System.Drawing.Point(100, 68);
            this.lookUpEdit工序.Name = "lookUpEdit工序";
            this.lookUpEdit工序.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.lookUpEdit工序.Properties.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("WorkProcess", "工序")});
            this.lookUpEdit工序.Properties.DisplayMember = "WorkProcess";
            this.lookUpEdit工序.Properties.NullText = "";
            this.lookUpEdit工序.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.Standard;
            this.lookUpEdit工序.Properties.ValueMember = "WorkProcess";
            this.lookUpEdit工序.Size = new System.Drawing.Size(120, 20);
            this.lookUpEdit工序.TabIndex = 5;
            // 
            // label20
            // 
            this.label20.AutoSize = true;
            this.label20.Location = new System.Drawing.Point(50, 72);
            this.label20.Name = "label20";
            this.label20.Size = new System.Drawing.Size(29, 12);
            this.label20.TabIndex = 220;
            this.label20.Text = "工序";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(268, 72);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(29, 12);
            this.label3.TabIndex = 219;
            this.label3.Text = "班组";
            // 
            // lookUpEdit生产订单号
            // 
            this.lookUpEdit生产订单号.Location = new System.Drawing.Point(328, 20);
            this.lookUpEdit生产订单号.Name = "lookUpEdit生产订单号";
            this.lookUpEdit生产订单号.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.lookUpEdit生产订单号.Properties.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("生产订单号", "生产订单号")});
            this.lookUpEdit生产订单号.Properties.DisplayMember = "生产订单号";
            this.lookUpEdit生产订单号.Properties.NullText = "";
            this.lookUpEdit生产订单号.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.Standard;
            this.lookUpEdit生产订单号.Properties.ValueMember = "生产订单号";
            this.lookUpEdit生产订单号.Size = new System.Drawing.Size(120, 20);
            this.lookUpEdit生产订单号.TabIndex = 2;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(245, 24);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(65, 12);
            this.label10.TabIndex = 223;
            this.label10.Text = "生产订单号";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(26, 46);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(53, 12);
            this.label2.TabIndex = 215;
            this.label2.Text = "存货编码";
            // 
            // lookUpEditcInvCode
            // 
            this.lookUpEditcInvCode.Location = new System.Drawing.Point(100, 42);
            this.lookUpEditcInvCode.Name = "lookUpEditcInvCode";
            this.lookUpEditcInvCode.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.lookUpEditcInvCode.Properties.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("cInvCode", "存货编码"),
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("cInvName", 60, "存货名称")});
            this.lookUpEditcInvCode.Properties.DisplayMember = "cInvCode";
            this.lookUpEditcInvCode.Properties.NullText = "";
            this.lookUpEditcInvCode.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.Standard;
            this.lookUpEditcInvCode.Properties.ValueMember = "cInvCode";
            this.lookUpEditcInvCode.Size = new System.Drawing.Size(120, 20);
            this.lookUpEditcInvCode.TabIndex = 3;
            this.lookUpEditcInvCode.EditValueChanged += new System.EventHandler(this.lookUpEditcInvCode_EditValueChanged);
            // 
            // lookUpEditcCode
            // 
            this.lookUpEditcCode.Location = new System.Drawing.Point(100, 20);
            this.lookUpEditcCode.Name = "lookUpEditcCode";
            this.lookUpEditcCode.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.lookUpEditcCode.Properties.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("cCode", "单据号")});
            this.lookUpEditcCode.Properties.DisplayMember = "cCode";
            this.lookUpEditcCode.Properties.NullText = "";
            this.lookUpEditcCode.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.Standard;
            this.lookUpEditcCode.Properties.ValueMember = "cCode";
            this.lookUpEditcCode.Size = new System.Drawing.Size(120, 20);
            this.lookUpEditcCode.TabIndex = 1;
            // 
            // dtm1
            // 
            this.dtm1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.dtm1.EditValue = null;
            this.dtm1.Location = new System.Drawing.Point(100, 92);
            this.dtm1.Name = "dtm1";
            this.dtm1.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.dtm1.Properties.VistaTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
            this.dtm1.Size = new System.Drawing.Size(120, 20);
            this.dtm1.TabIndex = 7;
            // 
            // label62
            // 
            this.label62.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label62.AutoSize = true;
            this.label62.Enabled = false;
            this.label62.Location = new System.Drawing.Point(26, 96);
            this.label62.Name = "label62";
            this.label62.Size = new System.Drawing.Size(53, 12);
            this.label62.TabIndex = 273;
            this.label62.Text = "单据日期";
            // 
            // dtm2
            // 
            this.dtm2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.dtm2.EditValue = null;
            this.dtm2.Location = new System.Drawing.Point(326, 92);
            this.dtm2.Name = "dtm2";
            this.dtm2.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.dtm2.Properties.VistaTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
            this.dtm2.Size = new System.Drawing.Size(122, 20);
            this.dtm2.TabIndex = 8;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(245, 96);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(17, 12);
            this.label4.TabIndex = 275;
            this.label4.Text = "至";
            // 
            // btnSEL
            // 
            this.btnSEL.Location = new System.Drawing.Point(498, 91);
            this.btnSEL.Name = "btnSEL";
            this.btnSEL.Size = new System.Drawing.Size(75, 23);
            this.btnSEL.TabIndex = 9;
            this.btnSEL.Text = "查 询";
            this.btnSEL.UseVisualStyleBackColor = true;
            this.btnSEL.Click += new System.EventHandler(this.btnSEL_Click);
            // 
            // gridControl1
            // 
            gridLevelNode1.RelationName = "Level1";
            this.gridControl1.LevelTree.Nodes.AddRange(new DevExpress.XtraGrid.GridLevelNode[] {
            gridLevelNode1});
            this.gridControl1.Location = new System.Drawing.Point(1, 120);
            this.gridControl1.LookAndFeel.SkinName = "Office 2010 Blue";
            this.gridControl1.MainView = this.gridView1;
            this.gridControl1.Name = "gridControl1";
            this.gridControl1.Size = new System.Drawing.Size(797, 259);
            this.gridControl1.TabIndex = 277;
            this.gridControl1.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView1});
            // 
            // gridView1
            // 
            this.gridView1.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.gridColcCode,
            this.gridColdtmCode,
            this.gridColWONo,
            this.gridColWorkGroup,
            this.gridColWorkProcess,
            this.gridColcInvCode,
            this.gridColcInvName});
            this.gridView1.GridControl = this.gridControl1;
            this.gridView1.IndicatorWidth = 40;
            this.gridView1.Name = "gridView1";
            this.gridView1.OptionsBehavior.AllowDeleteRows = DevExpress.Utils.DefaultBoolean.True;
            this.gridView1.OptionsBehavior.Editable = false;
            this.gridView1.OptionsBehavior.EditorShowMode = DevExpress.Utils.EditorShowMode.MouseDown;
            this.gridView1.OptionsCustomization.AllowGroup = false;
            this.gridView1.OptionsCustomization.AllowQuickHideColumns = false;
            this.gridView1.OptionsNavigation.EnterMoveNextColumn = true;
            this.gridView1.OptionsPrint.AutoWidth = false;
            this.gridView1.OptionsView.ColumnAutoWidth = false;
            this.gridView1.OptionsView.ShowFooter = true;
            this.gridView1.OptionsView.ShowGroupPanel = false;
            this.gridView1.CustomDrawRowIndicator += new DevExpress.XtraGrid.Views.Grid.RowIndicatorCustomDrawEventHandler(this.gridView1_CustomDrawRowIndicator);
            this.gridView1.DoubleClick += new System.EventHandler(this.gridView1_DoubleClick);
            // 
            // gridColcCode
            // 
            this.gridColcCode.Caption = "单据号";
            this.gridColcCode.FieldName = "cCode";
            this.gridColcCode.Name = "gridColcCode";
            this.gridColcCode.OptionsColumn.AllowEdit = false;
            this.gridColcCode.Visible = true;
            this.gridColcCode.VisibleIndex = 0;
            // 
            // gridColdtmCode
            // 
            this.gridColdtmCode.Caption = "单据日期";
            this.gridColdtmCode.FieldName = "dtmCode";
            this.gridColdtmCode.Name = "gridColdtmCode";
            this.gridColdtmCode.OptionsColumn.AllowEdit = false;
            this.gridColdtmCode.Visible = true;
            this.gridColdtmCode.VisibleIndex = 1;
            // 
            // gridColWONo
            // 
            this.gridColWONo.Caption = "生产订单号";
            this.gridColWONo.FieldName = "WONo";
            this.gridColWONo.Name = "gridColWONo";
            this.gridColWONo.OptionsColumn.AllowEdit = false;
            this.gridColWONo.Visible = true;
            this.gridColWONo.VisibleIndex = 2;
            // 
            // gridColWorkGroup
            // 
            this.gridColWorkGroup.Caption = "班组";
            this.gridColWorkGroup.FieldName = "WorkGroup";
            this.gridColWorkGroup.Name = "gridColWorkGroup";
            this.gridColWorkGroup.OptionsColumn.AllowEdit = false;
            this.gridColWorkGroup.Visible = true;
            this.gridColWorkGroup.VisibleIndex = 3;
            // 
            // gridColWorkProcess
            // 
            this.gridColWorkProcess.Caption = "工序";
            this.gridColWorkProcess.FieldName = "WorkProcess";
            this.gridColWorkProcess.Name = "gridColWorkProcess";
            this.gridColWorkProcess.OptionsColumn.AllowEdit = false;
            this.gridColWorkProcess.Visible = true;
            this.gridColWorkProcess.VisibleIndex = 4;
            // 
            // gridColcInvCode
            // 
            this.gridColcInvCode.Caption = "存货编码";
            this.gridColcInvCode.FieldName = "cInvCode";
            this.gridColcInvCode.Name = "gridColcInvCode";
            this.gridColcInvCode.OptionsColumn.AllowEdit = false;
            this.gridColcInvCode.Visible = true;
            this.gridColcInvCode.VisibleIndex = 5;
            // 
            // gridColcInvName
            // 
            this.gridColcInvName.Caption = "存货名称";
            this.gridColcInvName.FieldName = "cInvName";
            this.gridColcInvName.Name = "gridColcInvName";
            this.gridColcInvName.OptionsColumn.AllowEdit = false;
            this.gridColcInvName.Visible = true;
            this.gridColcInvName.VisibleIndex = 6;
            // 
            // btnOK
            // 
            this.btnOK.Location = new System.Drawing.Point(597, 91);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(75, 23);
            this.btnOK.TabIndex = 10;
            this.btnOK.Text = "确 定";
            this.btnOK.UseVisualStyleBackColor = true;
            this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(694, 91);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 23);
            this.btnCancel.TabIndex = 11;
            this.btnCancel.Text = "退 出";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // lookUpEditcInvName
            // 
            this.lookUpEditcInvName.Location = new System.Drawing.Point(226, 44);
            this.lookUpEditcInvName.Name = "lookUpEditcInvName";
            this.lookUpEditcInvName.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.lookUpEditcInvName.Properties.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("cInvCode", "存货编码"),
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("cInvName", 60, "存货名称")});
            this.lookUpEditcInvName.Properties.DisplayMember = "cInvName";
            this.lookUpEditcInvName.Properties.NullText = "";
            this.lookUpEditcInvName.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.Standard;
            this.lookUpEditcInvName.Properties.ValueMember = "cInvCode";
            this.lookUpEditcInvName.Size = new System.Drawing.Size(222, 20);
            this.lookUpEditcInvName.TabIndex = 4;
            this.lookUpEditcInvName.EditValueChanged += new System.EventHandler(this.lookUpEditcInvName_EditValueChanged);
            // 
            // FrmchkVouch01_SEL
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 380);
            this.Controls.Add(this.lookUpEditcInvName);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnOK);
            this.Controls.Add(this.gridControl1);
            this.Controls.Add(this.btnSEL);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.dtm2);
            this.Controls.Add(this.dtm1);
            this.Controls.Add(this.label62);
            this.Controls.Add(this.lookUpEditcCode);
            this.Controls.Add(this.lookUpEditcInvCode);
            this.Controls.Add(this.lookUpEdit生产订单号);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.lookUpEdit班组);
            this.Controls.Add(this.lookUpEdit工序);
            this.Controls.Add(this.label20);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "FrmchkVouch01_SEL";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "查询";
            this.Load += new System.EventHandler(this.FrmchkVouch01_SEL_Load);
            ((System.ComponentModel.ISupportInitialize)(this.lookUpEdit班组.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lookUpEdit工序.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lookUpEdit生产订单号.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lookUpEditcInvCode.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lookUpEditcCode.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtm1.Properties.VistaTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtm1.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtm2.Properties.VistaTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtm2.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lookUpEditcInvName.Properties)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private DevExpress.XtraEditors.LookUpEdit lookUpEdit班组;
        private DevExpress.XtraEditors.LookUpEdit lookUpEdit工序;
        private System.Windows.Forms.Label label20;
        private System.Windows.Forms.Label label3;
        private DevExpress.XtraEditors.LookUpEdit lookUpEdit生产订单号;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label2;
        private DevExpress.XtraEditors.LookUpEdit lookUpEditcInvCode;
        private DevExpress.XtraEditors.LookUpEdit lookUpEditcCode;
        private DevExpress.XtraEditors.DateEdit dtm1;
        private System.Windows.Forms.Label label62;
        private DevExpress.XtraEditors.DateEdit dtm2;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button btnSEL;
        private DevExpress.XtraGrid.GridControl gridControl1;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView1;
        private System.Windows.Forms.Button btnOK;
        private System.Windows.Forms.Button btnCancel;
        private DevExpress.XtraEditors.LookUpEdit lookUpEditcInvName;
        private DevExpress.XtraGrid.Columns.GridColumn gridColcCode;
        private DevExpress.XtraGrid.Columns.GridColumn gridColdtmCode;
        private DevExpress.XtraGrid.Columns.GridColumn gridColWONo;
        private DevExpress.XtraGrid.Columns.GridColumn gridColWorkGroup;
        private DevExpress.XtraGrid.Columns.GridColumn gridColWorkProcess;
        private DevExpress.XtraGrid.Columns.GridColumn gridColcInvCode;
        private DevExpress.XtraGrid.Columns.GridColumn gridColcInvName;
    }
}