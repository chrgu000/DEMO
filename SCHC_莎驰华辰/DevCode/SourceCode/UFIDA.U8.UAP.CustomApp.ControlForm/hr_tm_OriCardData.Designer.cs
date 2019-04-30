namespace UFIDA.U8.UAP.CustomApp.ControlForm
{
    partial class hr_tm_OriCardData
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
            this.ItemDateEdit1 = new DevExpress.XtraEditors.Repository.RepositoryItemDateEdit();
            this.ItemCheckEdit1 = new DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.btnLoad = new System.Windows.Forms.ToolStripMenuItem();
            this.btnSave = new System.Windows.Forms.ToolStripMenuItem();
            this.btnExcel = new System.Windows.Forms.ToolStripMenuItem();
            this.btnDownLoad = new System.Windows.Forms.ToolStripMenuItem();
            this.gridControl1 = new DevExpress.XtraGrid.GridControl();
            this.gridView1 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.gridCol考勤人员 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridCol姓名 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridCol卡号 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridCol打卡时间 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColiID = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridCol工号 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridCol打卡日期 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridCol人员编码 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridCol部门 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.ItemLookUpEdit部门 = new DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit();
            this.gridCol是否责任制员工 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColiCheck = new DevExpress.XtraGrid.Columns.GridColumn();
            this.panel1 = new System.Windows.Forms.Panel();
            this.textEditper = new DevExpress.XtraEditors.TextEdit();
            this.checkEdit1 = new DevExpress.XtraEditors.CheckEdit();
            this.label2 = new System.Windows.Forms.Label();
            this.buttonEdit1 = new DevExpress.XtraEditors.ButtonEdit();
            this.radio未导入2 = new System.Windows.Forms.RadioButton();
            this.radio全部 = new System.Windows.Forms.RadioButton();
            this.radio未导入 = new System.Windows.Forms.RadioButton();
            this.dateEdit2 = new DevExpress.XtraEditors.DateEdit();
            this.dateEdit1 = new DevExpress.XtraEditors.DateEdit();
            this.label1 = new System.Windows.Forms.Label();
            this.ceshiToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            ((System.ComponentModel.ISupportInitialize)(this.ItemDateEdit1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ItemDateEdit1.VistaTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ItemCheckEdit1)).BeginInit();
            this.menuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ItemLookUpEdit部门)).BeginInit();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.textEditper.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.checkEdit1.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.buttonEdit1.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dateEdit2.Properties.VistaTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dateEdit2.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dateEdit1.Properties.VistaTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dateEdit1.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // ItemDateEdit1
            // 
            this.ItemDateEdit1.AutoHeight = false;
            this.ItemDateEdit1.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.ItemDateEdit1.DisplayFormat.FormatString = "yyyy-MM-dd HH:mm:ss";
            this.ItemDateEdit1.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.ItemDateEdit1.Name = "ItemDateEdit1";
            this.ItemDateEdit1.VistaTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
            // 
            // ItemCheckEdit1
            // 
            this.ItemCheckEdit1.AutoHeight = false;
            this.ItemCheckEdit1.Name = "ItemCheckEdit1";
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btnLoad,
            this.btnSave,
            this.btnExcel,
            this.btnDownLoad,
            this.ceshiToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(903, 25);
            this.menuStrip1.TabIndex = 172;
            this.menuStrip1.Text = "menuStrip";
            // 
            // btnLoad
            // 
            this.btnLoad.Name = "btnLoad";
            this.btnLoad.Size = new System.Drawing.Size(44, 21);
            this.btnLoad.Text = "加载";
            this.btnLoad.Click += new System.EventHandler(this.btnLoad_Click);
            // 
            // btnSave
            // 
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(44, 21);
            this.btnSave.Text = "保存";
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // btnExcel
            // 
            this.btnExcel.Name = "btnExcel";
            this.btnExcel.Size = new System.Drawing.Size(73, 21);
            this.btnExcel.Text = "导出Excel";
            this.btnExcel.Click += new System.EventHandler(this.btnExcel_Click_1);
            // 
            // btnDownLoad
            // 
            this.btnDownLoad.Name = "btnDownLoad";
            this.btnDownLoad.Size = new System.Drawing.Size(44, 21);
            this.btnDownLoad.Text = "下载";
            this.btnDownLoad.Click += new System.EventHandler(this.btnDownLoad_Click);
            // 
            // gridControl1
            // 
            this.gridControl1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.gridControl1.Location = new System.Drawing.Point(3, 85);
            this.gridControl1.LookAndFeel.SkinName = "Office 2010 Blue";
            this.gridControl1.MainView = this.gridView1;
            this.gridControl1.Name = "gridControl1";
            this.gridControl1.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.ItemLookUpEdit部门});
            this.gridControl1.Size = new System.Drawing.Size(897, 305);
            this.gridControl1.TabIndex = 191;
            this.gridControl1.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView1});
            // 
            // gridView1
            // 
            this.gridView1.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.gridCol考勤人员,
            this.gridCol姓名,
            this.gridCol卡号,
            this.gridCol打卡时间,
            this.gridColiID,
            this.gridCol工号,
            this.gridCol打卡日期,
            this.gridCol人员编码,
            this.gridCol部门,
            this.gridCol是否责任制员工,
            this.gridColiCheck});
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
            // gridCol考勤人员
            // 
            this.gridCol考勤人员.Caption = "工号";
            this.gridCol考勤人员.FieldName = "考勤人员";
            this.gridCol考勤人员.Name = "gridCol考勤人员";
            this.gridCol考勤人员.Width = 73;
            // 
            // gridCol姓名
            // 
            this.gridCol姓名.Caption = "姓名";
            this.gridCol姓名.FieldName = "姓名";
            this.gridCol姓名.Name = "gridCol姓名";
            this.gridCol姓名.OptionsColumn.AllowEdit = false;
            this.gridCol姓名.Visible = true;
            this.gridCol姓名.VisibleIndex = 2;
            this.gridCol姓名.Width = 124;
            // 
            // gridCol卡号
            // 
            this.gridCol卡号.Caption = "卡号";
            this.gridCol卡号.FieldName = "卡号";
            this.gridCol卡号.Name = "gridCol卡号";
            this.gridCol卡号.OptionsColumn.AllowEdit = false;
            this.gridCol卡号.Visible = true;
            this.gridCol卡号.VisibleIndex = 4;
            this.gridCol卡号.Width = 135;
            // 
            // gridCol打卡时间
            // 
            this.gridCol打卡时间.Caption = "打卡时间";
            this.gridCol打卡时间.ColumnEdit = this.ItemDateEdit1;
            this.gridCol打卡时间.FieldName = "考勤时间";
            this.gridCol打卡时间.Name = "gridCol打卡时间";
            this.gridCol打卡时间.OptionsColumn.AllowEdit = false;
            this.gridCol打卡时间.Visible = true;
            this.gridCol打卡时间.VisibleIndex = 6;
            this.gridCol打卡时间.Width = 212;
            // 
            // gridColiID
            // 
            this.gridColiID.Caption = "iID";
            this.gridColiID.FieldName = "iID";
            this.gridColiID.Name = "gridColiID";
            this.gridColiID.OptionsColumn.AllowEdit = false;
            // 
            // gridCol工号
            // 
            this.gridCol工号.Caption = "工号";
            this.gridCol工号.FieldName = "工号";
            this.gridCol工号.Name = "gridCol工号";
            this.gridCol工号.OptionsColumn.AllowEdit = false;
            this.gridCol工号.Visible = true;
            this.gridCol工号.VisibleIndex = 3;
            this.gridCol工号.Width = 147;
            // 
            // gridCol打卡日期
            // 
            this.gridCol打卡日期.Caption = "打卡日期";
            this.gridCol打卡日期.FieldName = "考勤日期";
            this.gridCol打卡日期.Name = "gridCol打卡日期";
            this.gridCol打卡日期.OptionsColumn.AllowEdit = false;
            this.gridCol打卡日期.Visible = true;
            this.gridCol打卡日期.VisibleIndex = 5;
            this.gridCol打卡日期.Width = 102;
            // 
            // gridCol人员编码
            // 
            this.gridCol人员编码.Caption = "人员编码";
            this.gridCol人员编码.FieldName = "人员编码";
            this.gridCol人员编码.Name = "gridCol人员编码";
            this.gridCol人员编码.OptionsColumn.AllowEdit = false;
            this.gridCol人员编码.Visible = true;
            this.gridCol人员编码.VisibleIndex = 1;
            this.gridCol人员编码.Width = 105;
            // 
            // gridCol部门
            // 
            this.gridCol部门.Caption = "部门";
            this.gridCol部门.ColumnEdit = this.ItemLookUpEdit部门;
            this.gridCol部门.FieldName = "部门";
            this.gridCol部门.Name = "gridCol部门";
            this.gridCol部门.OptionsColumn.AllowEdit = false;
            this.gridCol部门.Visible = true;
            this.gridCol部门.VisibleIndex = 7;
            // 
            // ItemLookUpEdit部门
            // 
            this.ItemLookUpEdit部门.AutoHeight = false;
            this.ItemLookUpEdit部门.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.ItemLookUpEdit部门.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("cDepCode", "编码"),
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("cDepName", "名称")});
            this.ItemLookUpEdit部门.DisplayMember = "cDepName";
            this.ItemLookUpEdit部门.Name = "ItemLookUpEdit部门";
            this.ItemLookUpEdit部门.NullText = "";
            this.ItemLookUpEdit部门.Tag = "";
            this.ItemLookUpEdit部门.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.Standard;
            this.ItemLookUpEdit部门.ValueMember = "cDepCode";
            // 
            // gridCol是否责任制员工
            // 
            this.gridCol是否责任制员工.Caption = "责任制";
            this.gridCol是否责任制员工.FieldName = "是否责任制员工";
            this.gridCol是否责任制员工.Name = "gridCol是否责任制员工";
            this.gridCol是否责任制员工.OptionsColumn.AllowEdit = false;
            this.gridCol是否责任制员工.Visible = true;
            this.gridCol是否责任制员工.VisibleIndex = 8;
            // 
            // gridColiCheck
            // 
            this.gridColiCheck.Caption = "选择";
            this.gridColiCheck.ColumnEdit = this.ItemCheckEdit1;
            this.gridColiCheck.FieldName = "iChk";
            this.gridColiCheck.Name = "gridColiCheck";
            this.gridColiCheck.Visible = true;
            this.gridColiCheck.VisibleIndex = 0;
            this.gridColiCheck.Width = 44;
            // 
            // panel1
            // 
            this.panel1.AutoScroll = true;
            this.panel1.Controls.Add(this.textEditper);
            this.panel1.Controls.Add(this.checkEdit1);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.buttonEdit1);
            this.panel1.Controls.Add(this.radio未导入2);
            this.panel1.Controls.Add(this.radio全部);
            this.panel1.Controls.Add(this.radio未导入);
            this.panel1.Controls.Add(this.dateEdit2);
            this.panel1.Controls.Add(this.dateEdit1);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.gridControl1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 25);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(903, 393);
            this.panel1.TabIndex = 173;
            // 
            // textEditper
            // 
            this.textEditper.Enabled = false;
            this.textEditper.Location = new System.Drawing.Point(314, 59);
            this.textEditper.Name = "textEditper";
            this.textEditper.Size = new System.Drawing.Size(206, 20);
            this.textEditper.TabIndex = 201;
            // 
            // checkEdit1
            // 
            this.checkEdit1.Location = new System.Drawing.Point(562, 60);
            this.checkEdit1.Name = "checkEdit1";
            this.checkEdit1.Properties.Caption = "全选";
            this.checkEdit1.Size = new System.Drawing.Size(75, 19);
            this.checkEdit1.TabIndex = 200;
            this.checkEdit1.CheckedChanged += new System.EventHandler(this.checkEdit1_CheckedChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(255, 35);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(53, 12);
            this.label2.TabIndex = 199;
            this.label2.Text = "考勤人员";
            // 
            // buttonEdit1
            // 
            this.buttonEdit1.Location = new System.Drawing.Point(314, 31);
            this.buttonEdit1.Name = "buttonEdit1";
            this.buttonEdit1.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
            this.buttonEdit1.Size = new System.Drawing.Size(206, 20);
            this.buttonEdit1.TabIndex = 198;
            this.buttonEdit1.ButtonClick += new DevExpress.XtraEditors.Controls.ButtonPressedEventHandler(this.buttonEdit1_ButtonClick);
            // 
            // radio未导入2
            // 
            this.radio未导入2.AutoSize = true;
            this.radio未导入2.Location = new System.Drawing.Point(13, 34);
            this.radio未导入2.Name = "radio未导入2";
            this.radio未导入2.Size = new System.Drawing.Size(107, 16);
            this.radio未导入2.TabIndex = 197;
            this.radio未导入2.Text = "考勤机全部数据";
            this.radio未导入2.UseVisualStyleBackColor = true;
            this.radio未导入2.CheckedChanged += new System.EventHandler(this.radio未导入2_CheckedChanged);
            // 
            // radio全部
            // 
            this.radio全部.AutoSize = true;
            this.radio全部.Location = new System.Drawing.Point(13, 62);
            this.radio全部.Name = "radio全部";
            this.radio全部.Size = new System.Drawing.Size(47, 16);
            this.radio全部.TabIndex = 196;
            this.radio全部.Text = "全部";
            this.radio全部.UseVisualStyleBackColor = true;
            this.radio全部.CheckedChanged += new System.EventHandler(this.radio_CheckedChanged);
            // 
            // radio未导入
            // 
            this.radio未导入.AutoSize = true;
            this.radio未导入.Checked = true;
            this.radio未导入.Location = new System.Drawing.Point(13, 6);
            this.radio未导入.Name = "radio未导入";
            this.radio未导入.Size = new System.Drawing.Size(59, 16);
            this.radio未导入.TabIndex = 195;
            this.radio未导入.TabStop = true;
            this.radio未导入.Text = "未导入";
            this.radio未导入.UseVisualStyleBackColor = true;
            this.radio未导入.CheckedChanged += new System.EventHandler(this.radio_CheckedChanged);
            // 
            // dateEdit2
            // 
            this.dateEdit2.EditValue = null;
            this.dateEdit2.Location = new System.Drawing.Point(420, 5);
            this.dateEdit2.Name = "dateEdit2";
            this.dateEdit2.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.dateEdit2.Properties.VistaTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
            this.dateEdit2.Size = new System.Drawing.Size(100, 20);
            this.dateEdit2.TabIndex = 194;
            // 
            // dateEdit1
            // 
            this.dateEdit1.EditValue = null;
            this.dateEdit1.Location = new System.Drawing.Point(314, 5);
            this.dateEdit1.Name = "dateEdit1";
            this.dateEdit1.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.dateEdit1.Properties.VistaTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
            this.dateEdit1.Size = new System.Drawing.Size(100, 20);
            this.dateEdit1.TabIndex = 193;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(255, 10);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(53, 12);
            this.label1.TabIndex = 192;
            this.label1.Text = "刷卡日期";
            // 
            // ceshiToolStripMenuItem
            // 
            this.ceshiToolStripMenuItem.Name = "ceshiToolStripMenuItem";
            this.ceshiToolStripMenuItem.Size = new System.Drawing.Size(49, 21);
            this.ceshiToolStripMenuItem.Text = "ceshi";
            this.ceshiToolStripMenuItem.Click += new System.EventHandler(this.ceshiToolStripMenuItem_Click);
            // 
            // hr_tm_OriCardData
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.menuStrip1);
            this.Name = "hr_tm_OriCardData";
            this.Size = new System.Drawing.Size(903, 418);
            this.Load += new System.EventHandler(this.Frm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.ItemDateEdit1.VistaTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ItemDateEdit1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ItemCheckEdit1)).EndInit();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ItemLookUpEdit部门)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.textEditper.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.checkEdit1.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.buttonEdit1.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dateEdit2.Properties.VistaTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dateEdit2.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dateEdit1.Properties.VistaTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dateEdit1.Properties)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem btnSave;
        private DevExpress.XtraGrid.GridControl gridControl1;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.ToolStripMenuItem btnLoad;
        private System.Windows.Forms.Label label1;
        private DevExpress.XtraEditors.DateEdit dateEdit2;
        private DevExpress.XtraEditors.DateEdit dateEdit1;
        private System.Windows.Forms.RadioButton radio全部;
        private System.Windows.Forms.RadioButton radio未导入;
        private DevExpress.XtraGrid.Columns.GridColumn gridCol考勤人员;
        private DevExpress.XtraGrid.Columns.GridColumn gridCol姓名;
        private DevExpress.XtraGrid.Columns.GridColumn gridCol卡号;
        private DevExpress.XtraGrid.Columns.GridColumn gridCol打卡时间;
        private DevExpress.XtraGrid.Columns.GridColumn gridColiID;
        private DevExpress.XtraGrid.Columns.GridColumn gridCol工号;
        private DevExpress.XtraGrid.Columns.GridColumn gridCol打卡日期;
        private DevExpress.XtraGrid.Columns.GridColumn gridCol人员编码;
        private System.Windows.Forms.ToolStripMenuItem btnExcel;
        private System.Windows.Forms.ToolStripMenuItem btnDownLoad;
        private DevExpress.XtraGrid.Columns.GridColumn gridCol部门;
        private DevExpress.XtraGrid.Columns.GridColumn gridCol是否责任制员工;
        private System.Windows.Forms.RadioButton radio未导入2;
        private DevExpress.XtraGrid.Columns.GridColumn gridColiCheck;
        private DevExpress.XtraEditors.Repository.RepositoryItemDateEdit ItemDateEdit1;
        private DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit ItemCheckEdit1;
        private DevExpress.XtraEditors.ButtonEdit buttonEdit1;
        private System.Windows.Forms.Label label2;
        private DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit ItemLookUpEdit部门;
        private DevExpress.XtraEditors.CheckEdit checkEdit1;
        private DevExpress.XtraEditors.TextEdit textEditper;
        private System.Windows.Forms.ToolStripMenuItem ceshiToolStripMenuItem;
    }
}
