namespace UFIDA.U8.UAP.CustomApp.ControlForm
{
    partial class GL_accvouch
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
            this.ItemTextEditn2 = new DevExpress.XtraEditors.Repository.RepositoryItemTextEdit();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.btnSel = new System.Windows.Forms.ToolStripMenuItem();
            this.btnSave = new System.Windows.Forms.ToolStripMenuItem();
            this.panel1 = new System.Windows.Forms.Panel();
            this.chkAll = new System.Windows.Forms.CheckBox();
            this.lookUpEditPeriod = new DevExpress.XtraEditors.LookUpEdit();
            this.gridControl1 = new DevExpress.XtraGrid.GridControl();
            this.gridView1 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.gridColbChoose = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColiID = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColdDate = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColcsign = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColino_id = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColcdigest = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColccode = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColccode_equal = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColmoney = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColcexch_name = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColnfrat = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColQty = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColcItem_id = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColcDepCode = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColcPersonCode = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColcCusCode = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColcVenCode = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColdtmCreate = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColsStatus = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColUser_Load = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColdDate_Load = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColcPersonName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColcCusName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColcVenName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColcDepName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColccode_name = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColccode_name2 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.txt摘要 = new DevExpress.XtraEditors.TextEdit();
            ((System.ComponentModel.ISupportInitialize)(this.ItemTextEditn2)).BeginInit();
            this.menuStrip1.SuspendLayout();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.lookUpEditPeriod.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txt摘要.Properties)).BeginInit();
            this.SuspendLayout();
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
            // menuStrip1
            // 
            this.menuStrip1.AllowDrop = true;
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btnSel,
            this.btnSave});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(1031, 25);
            this.menuStrip1.TabIndex = 172;
            this.menuStrip1.Text = "menuStrip";
            // 
            // btnSel
            // 
            this.btnSel.Name = "btnSel";
            this.btnSel.Size = new System.Drawing.Size(44, 21);
            this.btnSel.Text = "加载";
            this.btnSel.Click += new System.EventHandler(this.btnSel_Click);
            // 
            // btnSave
            // 
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(44, 21);
            this.btnSave.Text = "保存";
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // panel1
            // 
            this.panel1.AutoScroll = true;
            this.panel1.Controls.Add(this.txt摘要);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.chkAll);
            this.panel1.Controls.Add(this.lookUpEditPeriod);
            this.panel1.Controls.Add(this.gridControl1);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 25);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1031, 370);
            this.panel1.TabIndex = 173;
            // 
            // chkAll
            // 
            this.chkAll.AutoSize = true;
            this.chkAll.Location = new System.Drawing.Point(23, 51);
            this.chkAll.Name = "chkAll";
            this.chkAll.Size = new System.Drawing.Size(48, 16);
            this.chkAll.TabIndex = 196;
            this.chkAll.Text = "全选";
            this.chkAll.UseVisualStyleBackColor = true;
            this.chkAll.CheckedChanged += new System.EventHandler(this.chkAll_CheckedChanged);
            // 
            // lookUpEditPeriod
            // 
            this.lookUpEditPeriod.Location = new System.Drawing.Point(56, 17);
            this.lookUpEditPeriod.Name = "lookUpEditPeriod";
            this.lookUpEditPeriod.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.lookUpEditPeriod.Properties.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("Period", "期间")});
            this.lookUpEditPeriod.Properties.DisplayMember = "Period";
            this.lookUpEditPeriod.Properties.NullText = "";
            this.lookUpEditPeriod.Properties.ValueMember = "Period";
            this.lookUpEditPeriod.Size = new System.Drawing.Size(119, 20);
            this.lookUpEditPeriod.TabIndex = 195;
            // 
            // gridControl1
            // 
            this.gridControl1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.gridControl1.Location = new System.Drawing.Point(3, 73);
            this.gridControl1.LookAndFeel.SkinName = "Office 2010 Blue";
            this.gridControl1.MainView = this.gridView1;
            this.gridControl1.Name = "gridControl1";
            this.gridControl1.Size = new System.Drawing.Size(1025, 294);
            this.gridControl1.TabIndex = 192;
            this.gridControl1.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView1});
            // 
            // gridView1
            // 
            this.gridView1.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.gridColbChoose,
            this.gridColiID,
            this.gridColdDate,
            this.gridColcsign,
            this.gridColino_id,
            this.gridColcdigest,
            this.gridColccode,
            this.gridColccode_equal,
            this.gridColmoney,
            this.gridColcexch_name,
            this.gridColnfrat,
            this.gridColQty,
            this.gridColcItem_id,
            this.gridColcDepCode,
            this.gridColcPersonCode,
            this.gridColcCusCode,
            this.gridColcVenCode,
            this.gridColdtmCreate,
            this.gridColsStatus,
            this.gridColUser_Load,
            this.gridColdDate_Load,
            this.gridColcPersonName,
            this.gridColcCusName,
            this.gridColcVenName,
            this.gridColcDepName,
            this.gridColccode_name,
            this.gridColccode_name2});
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
            this.gridView1.DoubleClick += new System.EventHandler(this.gridView1_DoubleClick);
            // 
            // gridColbChoose
            // 
            this.gridColbChoose.Caption = "选择";
            this.gridColbChoose.FieldName = "bChoose";
            this.gridColbChoose.Name = "gridColbChoose";
            this.gridColbChoose.Visible = true;
            this.gridColbChoose.VisibleIndex = 0;
            this.gridColbChoose.Width = 38;
            // 
            // gridColiID
            // 
            this.gridColiID.Caption = "SourceID";
            this.gridColiID.FieldName = "iID";
            this.gridColiID.Name = "gridColiID";
            this.gridColiID.OptionsColumn.AllowEdit = false;
            this.gridColiID.Visible = true;
            this.gridColiID.VisibleIndex = 17;
            this.gridColiID.Width = 43;
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
            // gridColcsign
            // 
            this.gridColcsign.Caption = "凭证类别";
            this.gridColcsign.FieldName = "csign";
            this.gridColcsign.Name = "gridColcsign";
            this.gridColcsign.OptionsColumn.AllowEdit = false;
            this.gridColcsign.Width = 60;
            // 
            // gridColino_id
            // 
            this.gridColino_id.Caption = "凭证号";
            this.gridColino_id.FieldName = "ino_id";
            this.gridColino_id.Name = "gridColino_id";
            this.gridColino_id.OptionsColumn.AllowEdit = false;
            this.gridColino_id.Width = 55;
            // 
            // gridColcdigest
            // 
            this.gridColcdigest.Caption = "摘要";
            this.gridColcdigest.FieldName = "cdigest";
            this.gridColcdigest.Name = "gridColcdigest";
            this.gridColcdigest.OptionsColumn.AllowEdit = false;
            this.gridColcdigest.Visible = true;
            this.gridColcdigest.VisibleIndex = 2;
            this.gridColcdigest.Width = 132;
            // 
            // gridColccode
            // 
            this.gridColccode.Caption = "科目编码";
            this.gridColccode.FieldName = "ccode";
            this.gridColccode.Name = "gridColccode";
            this.gridColccode.OptionsColumn.AllowEdit = false;
            this.gridColccode.Visible = true;
            this.gridColccode.VisibleIndex = 3;
            // 
            // gridColccode_equal
            // 
            this.gridColccode_equal.Caption = "对方科目编码";
            this.gridColccode_equal.FieldName = "ccode_equal";
            this.gridColccode_equal.Name = "gridColccode_equal";
            this.gridColccode_equal.OptionsColumn.AllowEdit = false;
            this.gridColccode_equal.Visible = true;
            this.gridColccode_equal.VisibleIndex = 5;
            this.gridColccode_equal.Width = 85;
            // 
            // gridColmoney
            // 
            this.gridColmoney.Caption = "金额";
            this.gridColmoney.FieldName = "money";
            this.gridColmoney.Name = "gridColmoney";
            this.gridColmoney.OptionsColumn.AllowEdit = false;
            this.gridColmoney.Visible = true;
            this.gridColmoney.VisibleIndex = 7;
            // 
            // gridColcexch_name
            // 
            this.gridColcexch_name.Caption = "币种";
            this.gridColcexch_name.FieldName = "cexch_name";
            this.gridColcexch_name.Name = "gridColcexch_name";
            this.gridColcexch_name.OptionsColumn.AllowEdit = false;
            // 
            // gridColnfrat
            // 
            this.gridColnfrat.Caption = "汇率";
            this.gridColnfrat.FieldName = "nfrat";
            this.gridColnfrat.Name = "gridColnfrat";
            this.gridColnfrat.OptionsColumn.AllowEdit = false;
            // 
            // gridColQty
            // 
            this.gridColQty.Caption = "数量";
            this.gridColQty.FieldName = "Qty";
            this.gridColQty.Name = "gridColQty";
            this.gridColQty.OptionsColumn.AllowEdit = false;
            // 
            // gridColcItem_id
            // 
            this.gridColcItem_id.Caption = "项目";
            this.gridColcItem_id.FieldName = "cItem_id";
            this.gridColcItem_id.Name = "gridColcItem_id";
            this.gridColcItem_id.OptionsColumn.AllowEdit = false;
            this.gridColcItem_id.Visible = true;
            this.gridColcItem_id.VisibleIndex = 8;
            // 
            // gridColcDepCode
            // 
            this.gridColcDepCode.Caption = "部门编码";
            this.gridColcDepCode.FieldName = "cDepCode";
            this.gridColcDepCode.Name = "gridColcDepCode";
            this.gridColcDepCode.OptionsColumn.AllowEdit = false;
            this.gridColcDepCode.Visible = true;
            this.gridColcDepCode.VisibleIndex = 9;
            // 
            // gridColcPersonCode
            // 
            this.gridColcPersonCode.Caption = "人员编码";
            this.gridColcPersonCode.FieldName = "cPersonCode";
            this.gridColcPersonCode.Name = "gridColcPersonCode";
            this.gridColcPersonCode.OptionsColumn.AllowEdit = false;
            this.gridColcPersonCode.Visible = true;
            this.gridColcPersonCode.VisibleIndex = 11;
            this.gridColcPersonCode.Width = 93;
            // 
            // gridColcCusCode
            // 
            this.gridColcCusCode.Caption = "客户编码";
            this.gridColcCusCode.FieldName = "cCusCode";
            this.gridColcCusCode.Name = "gridColcCusCode";
            this.gridColcCusCode.OptionsColumn.AllowEdit = false;
            this.gridColcCusCode.Visible = true;
            this.gridColcCusCode.VisibleIndex = 13;
            // 
            // gridColcVenCode
            // 
            this.gridColcVenCode.Caption = "供应商编码";
            this.gridColcVenCode.FieldName = "cVenCode";
            this.gridColcVenCode.Name = "gridColcVenCode";
            this.gridColcVenCode.OptionsColumn.AllowEdit = false;
            this.gridColcVenCode.Visible = true;
            this.gridColcVenCode.VisibleIndex = 15;
            // 
            // gridColdtmCreate
            // 
            this.gridColdtmCreate.Caption = "dtmCreate";
            this.gridColdtmCreate.FieldName = "dtmCreate";
            this.gridColdtmCreate.Name = "gridColdtmCreate";
            this.gridColdtmCreate.OptionsColumn.AllowEdit = false;
            // 
            // gridColsStatus
            // 
            this.gridColsStatus.Caption = "状态";
            this.gridColsStatus.FieldName = "sStatus";
            this.gridColsStatus.Name = "gridColsStatus";
            this.gridColsStatus.OptionsColumn.AllowEdit = false;
            this.gridColsStatus.Width = 63;
            // 
            // gridColUser_Load
            // 
            this.gridColUser_Load.Caption = "User_Load";
            this.gridColUser_Load.FieldName = "User_Load";
            this.gridColUser_Load.Name = "gridColUser_Load";
            this.gridColUser_Load.OptionsColumn.AllowEdit = false;
            // 
            // gridColdDate_Load
            // 
            this.gridColdDate_Load.Caption = "dDate_Load";
            this.gridColdDate_Load.FieldName = "dDate_Load";
            this.gridColdDate_Load.Name = "gridColdDate_Load";
            this.gridColdDate_Load.OptionsColumn.AllowEdit = false;
            // 
            // gridColcPersonName
            // 
            this.gridColcPersonName.Caption = "人员";
            this.gridColcPersonName.FieldName = "cPersonName";
            this.gridColcPersonName.Name = "gridColcPersonName";
            this.gridColcPersonName.OptionsColumn.AllowEdit = false;
            this.gridColcPersonName.Visible = true;
            this.gridColcPersonName.VisibleIndex = 12;
            // 
            // gridColcCusName
            // 
            this.gridColcCusName.Caption = "客户";
            this.gridColcCusName.FieldName = "cCusName";
            this.gridColcCusName.Name = "gridColcCusName";
            this.gridColcCusName.OptionsColumn.AllowEdit = false;
            this.gridColcCusName.Visible = true;
            this.gridColcCusName.VisibleIndex = 14;
            // 
            // gridColcVenName
            // 
            this.gridColcVenName.Caption = "供应商";
            this.gridColcVenName.FieldName = "cVenName";
            this.gridColcVenName.Name = "gridColcVenName";
            this.gridColcVenName.OptionsColumn.AllowEdit = false;
            this.gridColcVenName.Visible = true;
            this.gridColcVenName.VisibleIndex = 16;
            // 
            // gridColcDepName
            // 
            this.gridColcDepName.Caption = "部门";
            this.gridColcDepName.FieldName = "cDepName";
            this.gridColcDepName.Name = "gridColcDepName";
            this.gridColcDepName.OptionsColumn.AllowEdit = false;
            this.gridColcDepName.Visible = true;
            this.gridColcDepName.VisibleIndex = 10;
            // 
            // gridColccode_name
            // 
            this.gridColccode_name.Caption = "科目";
            this.gridColccode_name.FieldName = "ccode_name";
            this.gridColccode_name.Name = "gridColccode_name";
            this.gridColccode_name.OptionsColumn.AllowEdit = false;
            this.gridColccode_name.Visible = true;
            this.gridColccode_name.VisibleIndex = 4;
            // 
            // gridColccode_name2
            // 
            this.gridColccode_name2.Caption = "对方科目";
            this.gridColccode_name2.FieldName = "ccode_name2";
            this.gridColccode_name2.Name = "gridColccode_name2";
            this.gridColccode_name2.OptionsColumn.AllowEdit = false;
            this.gridColccode_name2.Visible = true;
            this.gridColccode_name2.VisibleIndex = 6;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(21, 22);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(29, 12);
            this.label1.TabIndex = 194;
            this.label1.Text = "期间";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(197, 22);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(29, 12);
            this.label2.TabIndex = 197;
            this.label2.Text = "摘要";
            // 
            // txt摘要
            // 
            this.txt摘要.Location = new System.Drawing.Point(232, 17);
            this.txt摘要.Name = "txt摘要";
            this.txt摘要.Size = new System.Drawing.Size(208, 20);
            this.txt摘要.TabIndex = 198;
            // 
            // GL_accvouch
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.menuStrip1);
            this.Name = "GL_accvouch";
            this.Size = new System.Drawing.Size(1031, 395);
            this.Load += new System.EventHandler(this.Frm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.ItemTextEditn2)).EndInit();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.lookUpEditPeriod.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txt摘要.Properties)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem btnSave;
        private System.Windows.Forms.Panel panel1;
        private DevExpress.XtraGrid.GridControl gridControl1;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView1;
        private System.Windows.Forms.Label label1;
        private DevExpress.XtraEditors.Repository.RepositoryItemTextEdit ItemTextEditn2;
        private System.Windows.Forms.ToolStripMenuItem btnSel;
        private DevExpress.XtraGrid.Columns.GridColumn gridColiID;
        private DevExpress.XtraGrid.Columns.GridColumn gridColdDate;
        private DevExpress.XtraGrid.Columns.GridColumn gridColcsign;
        private DevExpress.XtraGrid.Columns.GridColumn gridColino_id;
        private DevExpress.XtraGrid.Columns.GridColumn gridColcdigest;
        private DevExpress.XtraGrid.Columns.GridColumn gridColccode;
        private DevExpress.XtraGrid.Columns.GridColumn gridColmoney;
        private DevExpress.XtraGrid.Columns.GridColumn gridColcexch_name;
        private DevExpress.XtraGrid.Columns.GridColumn gridColnfrat;
        private DevExpress.XtraGrid.Columns.GridColumn gridColQty;
        private DevExpress.XtraGrid.Columns.GridColumn gridColcItem_id;
        private DevExpress.XtraGrid.Columns.GridColumn gridColcDepCode;
        private DevExpress.XtraGrid.Columns.GridColumn gridColcPersonCode;
        private DevExpress.XtraGrid.Columns.GridColumn gridColcCusCode;
        private DevExpress.XtraGrid.Columns.GridColumn gridColcVenCode;
        private DevExpress.XtraGrid.Columns.GridColumn gridColccode_equal;
        private DevExpress.XtraGrid.Columns.GridColumn gridColdtmCreate;
        private DevExpress.XtraGrid.Columns.GridColumn gridColsStatus;
        private DevExpress.XtraGrid.Columns.GridColumn gridColUser_Load;
        private DevExpress.XtraGrid.Columns.GridColumn gridColdDate_Load;
        private DevExpress.XtraEditors.LookUpEdit lookUpEditPeriod;
        private DevExpress.XtraGrid.Columns.GridColumn gridColbChoose;
        private DevExpress.XtraGrid.Columns.GridColumn gridColcPersonName;
        private DevExpress.XtraGrid.Columns.GridColumn gridColcCusName;
        private DevExpress.XtraGrid.Columns.GridColumn gridColcVenName;
        private DevExpress.XtraGrid.Columns.GridColumn gridColcDepName;
        private DevExpress.XtraGrid.Columns.GridColumn gridColccode_name;
        private DevExpress.XtraGrid.Columns.GridColumn gridColccode_name2;
        private System.Windows.Forms.CheckBox chkAll;
        private DevExpress.XtraEditors.TextEdit txt摘要;
        private System.Windows.Forms.Label label2;
    }
}
