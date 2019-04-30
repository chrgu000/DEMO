namespace UFIDA.U8.UAP.CustomApp.ControlForm
{
    partial class SmartUser
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SmartUser));
            this.chkAll = new System.Windows.Forms.CheckBox();
            this.btnSave = new DevExpress.XtraEditors.SimpleButton();
            this.btnRefresh = new DevExpress.XtraEditors.SimpleButton();
            this.gridControl1 = new DevExpress.XtraGrid.GridControl();
            this.gridView1 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.gridColchoose = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColUserID = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColUserName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColPwd = new DevExpress.XtraGrid.Columns.GridColumn();
            this.ItemTextEditPwd = new DevExpress.XtraEditors.Repository.RepositoryItemTextEdit();
            this.gridColRePwd = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColEndDate = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColbUser = new DevExpress.XtraGrid.Columns.GridColumn();
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            this.radioAllUser = new System.Windows.Forms.RadioButton();
            this.radioSmartUser = new System.Windows.Forms.RadioButton();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ItemTextEditPwd)).BeginInit();
            this.SuspendLayout();
            // 
            // chkAll
            // 
            this.chkAll.AutoSize = true;
            this.chkAll.Location = new System.Drawing.Point(18, 84);
            this.chkAll.Name = "chkAll";
            this.chkAll.Size = new System.Drawing.Size(48, 16);
            this.chkAll.TabIndex = 155;
            this.chkAll.Text = "全选";
            this.chkAll.UseVisualStyleBackColor = true;
            this.chkAll.CheckedChanged += new System.EventHandler(this.chkAll_CheckedChanged);
            // 
            // btnSave
            // 
            this.btnSave.Image = ((System.Drawing.Image)(resources.GetObject("btnSave.Image")));
            this.btnSave.ImageLocation = DevExpress.XtraEditors.ImageLocation.TopCenter;
            this.btnSave.Location = new System.Drawing.Point(345, 59);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(46, 41);
            this.btnSave.TabIndex = 148;
            this.btnSave.Text = "保存";
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // btnRefresh
            // 
            this.btnRefresh.Image = ((System.Drawing.Image)(resources.GetObject("btnRefresh.Image")));
            this.btnRefresh.ImageLocation = DevExpress.XtraEditors.ImageLocation.TopCenter;
            this.btnRefresh.Location = new System.Drawing.Point(284, 60);
            this.btnRefresh.Name = "btnRefresh";
            this.btnRefresh.Size = new System.Drawing.Size(46, 41);
            this.btnRefresh.TabIndex = 141;
            this.btnRefresh.Text = "过滤";
            this.btnRefresh.Click += new System.EventHandler(this.btnRefresh_Click);
            // 
            // gridControl1
            // 
            this.gridControl1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.gridControl1.Location = new System.Drawing.Point(3, 107);
            this.gridControl1.LookAndFeel.SkinName = "Office 2010 Blue";
            this.gridControl1.MainView = this.gridView1;
            this.gridControl1.Name = "gridControl1";
            this.gridControl1.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.ItemTextEditPwd});
            this.gridControl1.Size = new System.Drawing.Size(1085, 261);
            this.gridControl1.TabIndex = 140;
            this.gridControl1.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView1});
            // 
            // gridView1
            // 
            this.gridView1.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.gridColchoose,
            this.gridColUserID,
            this.gridColUserName,
            this.gridColPwd,
            this.gridColRePwd,
            this.gridColEndDate,
            this.gridColbUser});
            this.gridView1.GridControl = this.gridControl1;
            this.gridView1.IndicatorWidth = 40;
            this.gridView1.Name = "gridView1";
            this.gridView1.OptionsBehavior.AllowDeleteRows = DevExpress.Utils.DefaultBoolean.True;
            this.gridView1.OptionsBehavior.EditorShowMode = DevExpress.Utils.EditorShowMode.MouseDown;
            this.gridView1.OptionsCustomization.AllowGroup = false;
            this.gridView1.OptionsCustomization.AllowQuickHideColumns = false;
            this.gridView1.OptionsView.ColumnAutoWidth = false;
            this.gridView1.OptionsView.ShowGroupPanel = false;
            this.gridView1.CustomDrawRowIndicator += new DevExpress.XtraGrid.Views.Grid.RowIndicatorCustomDrawEventHandler(this.gridView1_CustomDrawRowIndicator);
            this.gridView1.CellValueChanged += new DevExpress.XtraGrid.Views.Base.CellValueChangedEventHandler(this.gridView1_CellValueChanged);
            // 
            // gridColchoose
            // 
            this.gridColchoose.Caption = "选择";
            this.gridColchoose.FieldName = "choose";
            this.gridColchoose.Name = "gridColchoose";
            this.gridColchoose.Visible = true;
            this.gridColchoose.VisibleIndex = 0;
            this.gridColchoose.Width = 34;
            // 
            // gridColUserID
            // 
            this.gridColUserID.Caption = "账号";
            this.gridColUserID.FieldName = "UserID";
            this.gridColUserID.Name = "gridColUserID";
            this.gridColUserID.OptionsColumn.ReadOnly = true;
            this.gridColUserID.Visible = true;
            this.gridColUserID.VisibleIndex = 1;
            // 
            // gridColUserName
            // 
            this.gridColUserName.Caption = "姓名";
            this.gridColUserName.FieldName = "UserName";
            this.gridColUserName.Name = "gridColUserName";
            this.gridColUserName.OptionsColumn.ReadOnly = true;
            this.gridColUserName.Visible = true;
            this.gridColUserName.VisibleIndex = 2;
            this.gridColUserName.Width = 121;
            // 
            // gridColPwd
            // 
            this.gridColPwd.Caption = "密码";
            this.gridColPwd.ColumnEdit = this.ItemTextEditPwd;
            this.gridColPwd.FieldName = "Pwd";
            this.gridColPwd.Name = "gridColPwd";
            this.gridColPwd.Visible = true;
            this.gridColPwd.VisibleIndex = 3;
            this.gridColPwd.Width = 87;
            // 
            // ItemTextEditPwd
            // 
            this.ItemTextEditPwd.AutoHeight = false;
            this.ItemTextEditPwd.Name = "ItemTextEditPwd";
            this.ItemTextEditPwd.PasswordChar = '*';
            // 
            // gridColRePwd
            // 
            this.gridColRePwd.Caption = "确认密码";
            this.gridColRePwd.ColumnEdit = this.ItemTextEditPwd;
            this.gridColRePwd.FieldName = "RePwd";
            this.gridColRePwd.Name = "gridColRePwd";
            this.gridColRePwd.Visible = true;
            this.gridColRePwd.VisibleIndex = 4;
            this.gridColRePwd.Width = 123;
            // 
            // gridColEndDate
            // 
            this.gridColEndDate.Caption = "失效日期";
            this.gridColEndDate.FieldName = "EndDate";
            this.gridColEndDate.Name = "gridColEndDate";
            this.gridColEndDate.Visible = true;
            this.gridColEndDate.VisibleIndex = 5;
            // 
            // gridColbUser
            // 
            this.gridColbUser.Caption = "是否采集器操作员";
            this.gridColbUser.FieldName = "bUser";
            this.gridColbUser.Name = "gridColbUser";
            this.gridColbUser.OptionsColumn.ReadOnly = true;
            this.gridColbUser.Visible = true;
            this.gridColbUser.VisibleIndex = 6;
            this.gridColbUser.Width = 105;
            // 
            // labelControl1
            // 
            this.labelControl1.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.labelControl1.Appearance.Font = new System.Drawing.Font("Tahoma", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelControl1.Location = new System.Drawing.Point(469, 18);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(168, 25);
            this.labelControl1.TabIndex = 139;
            this.labelControl1.Text = "采集器操作员设置";
            // 
            // radioAllUser
            // 
            this.radioAllUser.AutoSize = true;
            this.radioAllUser.Checked = true;
            this.radioAllUser.Location = new System.Drawing.Point(18, 59);
            this.radioAllUser.Name = "radioAllUser";
            this.radioAllUser.Size = new System.Drawing.Size(83, 16);
            this.radioAllUser.TabIndex = 156;
            this.radioAllUser.TabStop = true;
            this.radioAllUser.Text = "全部U8用户";
            this.radioAllUser.UseVisualStyleBackColor = true;
            // 
            // radioSmartUser
            // 
            this.radioSmartUser.AutoSize = true;
            this.radioSmartUser.Location = new System.Drawing.Point(139, 59);
            this.radioSmartUser.Name = "radioSmartUser";
            this.radioSmartUser.Size = new System.Drawing.Size(95, 16);
            this.radioSmartUser.TabIndex = 157;
            this.radioSmartUser.Text = "采集器操作员";
            this.radioSmartUser.UseVisualStyleBackColor = true;
            // 
            // SmartUser
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.radioSmartUser);
            this.Controls.Add(this.radioAllUser);
            this.Controls.Add(this.chkAll);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.btnRefresh);
            this.Controls.Add(this.gridControl1);
            this.Controls.Add(this.labelControl1);
            this.Name = "SmartUser";
            this.Size = new System.Drawing.Size(1091, 371);
            this.Load += new System.EventHandler(this.Frm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ItemTextEditPwd)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.CheckBox chkAll;
        private DevExpress.XtraEditors.SimpleButton btnSave;
        private DevExpress.XtraEditors.SimpleButton btnRefresh;
        private DevExpress.XtraGrid.GridControl gridControl1;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView1;
        private DevExpress.XtraEditors.LabelControl labelControl1;
        private DevExpress.XtraGrid.Columns.GridColumn gridColchoose;
        private DevExpress.XtraGrid.Columns.GridColumn gridColUserID;
        private DevExpress.XtraGrid.Columns.GridColumn gridColUserName;
        private DevExpress.XtraGrid.Columns.GridColumn gridColPwd;
        private DevExpress.XtraGrid.Columns.GridColumn gridColRePwd;
        private DevExpress.XtraGrid.Columns.GridColumn gridColEndDate;
        private DevExpress.XtraGrid.Columns.GridColumn gridColbUser;
        private System.Windows.Forms.RadioButton radioAllUser;
        private System.Windows.Forms.RadioButton radioSmartUser;
        private DevExpress.XtraEditors.Repository.RepositoryItemTextEdit ItemTextEditPwd;
    }
}
