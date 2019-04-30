namespace UFIDA.U8.UAP.CustomApp.ControlForm
{
    partial class GiveBack_Edit_SEL
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

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.btnCancel = new System.Windows.Forms.Button();
            this.txtInv = new DevExpress.XtraEditors.TextEdit();
            this.layoutControlItem1 = new DevExpress.XtraLayout.LayoutControlItem();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.dtmCode1 = new DevExpress.XtraEditors.DateEdit();
            this.gridControl1 = new DevExpress.XtraGrid.GridControl();
            this.gridView1 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.gridColSerialNo = new DevExpress.XtraGrid.Columns.GridColumn();
            this.ItemLookUpEditSerialNo = new DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit();
            this.gridColInvName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.ItemLookUpEditInvName = new DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit();
            this.gridColInvStd = new DevExpress.XtraGrid.Columns.GridColumn();
            this.ItemLookUpEditInvStd = new DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit();
            this.gridColRemark = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColbChoose = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColiID = new DevExpress.XtraGrid.Columns.GridColumn();
            this.label3 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.lookUpEditDep = new DevExpress.XtraEditors.LookUpEdit();
            this.lookUpEditPerson = new DevExpress.XtraEditors.LookUpEdit();
            this.btnSEL = new System.Windows.Forms.Button();
            this.dtmCode2 = new DevExpress.XtraEditors.DateEdit();
            this.lookUpEditCode1 = new DevExpress.XtraEditors.LookUpEdit();
            this.lookUpEditCode2 = new DevExpress.XtraEditors.LookUpEdit();
            this.btnOK = new System.Windows.Forms.Button();
            this.gridColcCode = new DevExpress.XtraGrid.Columns.GridColumn();
            ((System.ComponentModel.ISupportInitialize)(this.txtInv.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtmCode1.Properties.VistaTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtmCode1.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ItemLookUpEditSerialNo)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ItemLookUpEditInvName)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ItemLookUpEditInvStd)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lookUpEditDep.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lookUpEditPerson.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtmCode2.Properties.VistaTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtmCode2.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lookUpEditCode1.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lookUpEditCode2.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(756, 34);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 23);
            this.btnCancel.TabIndex = 44;
            this.btnCancel.Text = "取消";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // txtInv
            // 
            this.txtInv.Location = new System.Drawing.Point(88, 12);
            this.txtInv.Name = "txtInv";
            this.txtInv.Size = new System.Drawing.Size(438, 21);
            this.txtInv.TabIndex = 4;
            // 
            // layoutControlItem1
            // 
            this.layoutControlItem1.Control = this.txtInv;
            this.layoutControlItem1.CustomizationFormText = "存货模糊信息";
            this.layoutControlItem1.Location = new System.Drawing.Point(0, 0);
            this.layoutControlItem1.Name = "layoutControlItem1";
            this.layoutControlItem1.Size = new System.Drawing.Size(518, 293);
            this.layoutControlItem1.Text = "存货模糊信息";
            this.layoutControlItem1.TextSize = new System.Drawing.Size(72, 14);
            this.layoutControlItem1.TextToControlDistance = 5;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(25, 20);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(53, 12);
            this.label1.TabIndex = 47;
            this.label1.Text = "领用单号";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(25, 42);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(53, 12);
            this.label2.TabIndex = 49;
            this.label2.Text = "领用日期";
            // 
            // dtmCode1
            // 
            this.dtmCode1.EditValue = null;
            this.dtmCode1.Location = new System.Drawing.Point(80, 40);
            this.dtmCode1.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.dtmCode1.Name = "dtmCode1";
            this.dtmCode1.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.dtmCode1.Properties.VistaTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
            this.dtmCode1.Size = new System.Drawing.Size(126, 20);
            this.dtmCode1.TabIndex = 53;
            // 
            // gridControl1
            // 
            this.gridControl1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.gridControl1.Location = new System.Drawing.Point(-1, 74);
            this.gridControl1.LookAndFeel.SkinName = "Office 2010 Blue";
            this.gridControl1.MainView = this.gridView1;
            this.gridControl1.Name = "gridControl1";
            this.gridControl1.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.ItemLookUpEditInvName,
            this.ItemLookUpEditSerialNo,
            this.ItemLookUpEditInvStd});
            this.gridControl1.Size = new System.Drawing.Size(850, 374);
            this.gridControl1.TabIndex = 192;
            this.gridControl1.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView1});
            // 
            // gridView1
            // 
            this.gridView1.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.gridColSerialNo,
            this.gridColInvName,
            this.gridColInvStd,
            this.gridColRemark,
            this.gridColbChoose,
            this.gridColiID,
            this.gridColcCode});
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
            // gridColSerialNo
            // 
            this.gridColSerialNo.Caption = "工装序号";
            this.gridColSerialNo.ColumnEdit = this.ItemLookUpEditSerialNo;
            this.gridColSerialNo.FieldName = "SerialNo";
            this.gridColSerialNo.Fixed = DevExpress.XtraGrid.Columns.FixedStyle.Left;
            this.gridColSerialNo.Name = "gridColSerialNo";
            this.gridColSerialNo.OptionsColumn.AllowEdit = false;
            this.gridColSerialNo.Visible = true;
            this.gridColSerialNo.VisibleIndex = 3;
            this.gridColSerialNo.Width = 163;
            // 
            // ItemLookUpEditSerialNo
            // 
            this.ItemLookUpEditSerialNo.AutoHeight = false;
            this.ItemLookUpEditSerialNo.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.ItemLookUpEditSerialNo.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("SerialNo", "序号", 20, DevExpress.Utils.FormatType.None, "", true, DevExpress.Utils.HorzAlignment.Default, DevExpress.Data.ColumnSortOrder.None, DevExpress.Utils.DefaultBoolean.False),
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("InvName", "名称"),
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("InvStd", "规格")});
            this.ItemLookUpEditSerialNo.DisplayMember = "SerialNo";
            this.ItemLookUpEditSerialNo.Name = "ItemLookUpEditSerialNo";
            this.ItemLookUpEditSerialNo.NullText = "";
            this.ItemLookUpEditSerialNo.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.Standard;
            this.ItemLookUpEditSerialNo.ValueMember = "SerialNo";
            // 
            // gridColInvName
            // 
            this.gridColInvName.Caption = "工装名称";
            this.gridColInvName.ColumnEdit = this.ItemLookUpEditInvName;
            this.gridColInvName.FieldName = "SerialNo";
            this.gridColInvName.Fixed = DevExpress.XtraGrid.Columns.FixedStyle.Left;
            this.gridColInvName.Name = "gridColInvName";
            this.gridColInvName.OptionsColumn.AllowEdit = false;
            this.gridColInvName.Visible = true;
            this.gridColInvName.VisibleIndex = 4;
            this.gridColInvName.Width = 162;
            // 
            // ItemLookUpEditInvName
            // 
            this.ItemLookUpEditInvName.AutoHeight = false;
            this.ItemLookUpEditInvName.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.ItemLookUpEditInvName.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("SerialNo", "序号"),
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("InvName", "名称"),
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("InvStd", "规格")});
            this.ItemLookUpEditInvName.DisplayMember = "InvName";
            this.ItemLookUpEditInvName.Name = "ItemLookUpEditInvName";
            this.ItemLookUpEditInvName.NullText = "";
            this.ItemLookUpEditInvName.ValueMember = "SerialNo";
            // 
            // gridColInvStd
            // 
            this.gridColInvStd.Caption = "规格型号";
            this.gridColInvStd.ColumnEdit = this.ItemLookUpEditInvStd;
            this.gridColInvStd.FieldName = "SerialNo";
            this.gridColInvStd.Fixed = DevExpress.XtraGrid.Columns.FixedStyle.Left;
            this.gridColInvStd.Name = "gridColInvStd";
            this.gridColInvStd.OptionsColumn.AllowEdit = false;
            this.gridColInvStd.Visible = true;
            this.gridColInvStd.VisibleIndex = 5;
            this.gridColInvStd.Width = 135;
            // 
            // ItemLookUpEditInvStd
            // 
            this.ItemLookUpEditInvStd.AutoHeight = false;
            this.ItemLookUpEditInvStd.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.ItemLookUpEditInvStd.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("SerialNo", "序号"),
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("InvName", "名称"),
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("InvStd", "规格")});
            this.ItemLookUpEditInvStd.DisplayMember = "InvStd";
            this.ItemLookUpEditInvStd.Name = "ItemLookUpEditInvStd";
            this.ItemLookUpEditInvStd.NullText = "";
            this.ItemLookUpEditInvStd.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.Standard;
            this.ItemLookUpEditInvStd.ValueMember = "SerialNo";
            // 
            // gridColRemark
            // 
            this.gridColRemark.Caption = "备注";
            this.gridColRemark.FieldName = "Remark";
            this.gridColRemark.Name = "gridColRemark";
            this.gridColRemark.OptionsColumn.AllowEdit = false;
            this.gridColRemark.Visible = true;
            this.gridColRemark.VisibleIndex = 6;
            // 
            // gridColbChoose
            // 
            this.gridColbChoose.Caption = "选择";
            this.gridColbChoose.FieldName = "bChoose";
            this.gridColbChoose.Fixed = DevExpress.XtraGrid.Columns.FixedStyle.Left;
            this.gridColbChoose.Name = "gridColbChoose";
            this.gridColbChoose.Visible = true;
            this.gridColbChoose.VisibleIndex = 0;
            this.gridColbChoose.Width = 60;
            // 
            // gridColiID
            // 
            this.gridColiID.Caption = "领用单IDs";
            this.gridColiID.FieldName = "iID";
            this.gridColiID.Fixed = DevExpress.XtraGrid.Columns.FixedStyle.Left;
            this.gridColiID.Name = "gridColiID";
            this.gridColiID.OptionsColumn.AllowEdit = false;
            this.gridColiID.Visible = true;
            this.gridColiID.VisibleIndex = 2;
            this.gridColiID.Width = 120;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(381, 20);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(41, 12);
            this.label3.TabIndex = 193;
            this.label3.Text = "领用人";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(370, 42);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(53, 12);
            this.label5.TabIndex = 198;
            this.label5.Text = "领用部门";
            // 
            // lookUpEditDep
            // 
            this.lookUpEditDep.Location = new System.Drawing.Point(425, 38);
            this.lookUpEditDep.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.lookUpEditDep.Name = "lookUpEditDep";
            this.lookUpEditDep.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.lookUpEditDep.Properties.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("cDepCode", "编码"),
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("cDepName", "名称")});
            this.lookUpEditDep.Properties.DisplayMember = "cDepName";
            this.lookUpEditDep.Properties.NullText = "";
            this.lookUpEditDep.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.Standard;
            this.lookUpEditDep.Properties.ValueMember = "cDepCode";
            this.lookUpEditDep.Size = new System.Drawing.Size(126, 20);
            this.lookUpEditDep.TabIndex = 199;
            // 
            // lookUpEditPerson
            // 
            this.lookUpEditPerson.Location = new System.Drawing.Point(425, 16);
            this.lookUpEditPerson.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.lookUpEditPerson.Name = "lookUpEditPerson";
            this.lookUpEditPerson.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.lookUpEditPerson.Properties.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("cPersonCode", "编号"),
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("cPersonName", "姓名")});
            this.lookUpEditPerson.Properties.DisplayMember = "cPersonName";
            this.lookUpEditPerson.Properties.NullText = "";
            this.lookUpEditPerson.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.Standard;
            this.lookUpEditPerson.Properties.ValueMember = "cPersonCode";
            this.lookUpEditPerson.Size = new System.Drawing.Size(126, 20);
            this.lookUpEditPerson.TabIndex = 200;
            // 
            // btnSEL
            // 
            this.btnSEL.Location = new System.Drawing.Point(575, 34);
            this.btnSEL.Name = "btnSEL";
            this.btnSEL.Size = new System.Drawing.Size(75, 23);
            this.btnSEL.TabIndex = 43;
            this.btnSEL.Text = "查询";
            this.btnSEL.UseVisualStyleBackColor = true;
            this.btnSEL.Click += new System.EventHandler(this.btnSEL_Click);
            // 
            // dtmCode2
            // 
            this.dtmCode2.EditValue = null;
            this.dtmCode2.Location = new System.Drawing.Point(211, 40);
            this.dtmCode2.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.dtmCode2.Name = "dtmCode2";
            this.dtmCode2.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.dtmCode2.Properties.VistaTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
            this.dtmCode2.Size = new System.Drawing.Size(126, 20);
            this.dtmCode2.TabIndex = 202;
            // 
            // lookUpEditCode1
            // 
            this.lookUpEditCode1.Location = new System.Drawing.Point(80, 16);
            this.lookUpEditCode1.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.lookUpEditCode1.Name = "lookUpEditCode1";
            this.lookUpEditCode1.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.lookUpEditCode1.Properties.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("cCode", "单据号")});
            this.lookUpEditCode1.Properties.DisplayMember = "cCode";
            this.lookUpEditCode1.Properties.NullText = "";
            this.lookUpEditCode1.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.Standard;
            this.lookUpEditCode1.Properties.ValueMember = "cCode";
            this.lookUpEditCode1.Size = new System.Drawing.Size(126, 20);
            this.lookUpEditCode1.TabIndex = 203;
            // 
            // lookUpEditCode2
            // 
            this.lookUpEditCode2.Location = new System.Drawing.Point(211, 16);
            this.lookUpEditCode2.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.lookUpEditCode2.Name = "lookUpEditCode2";
            this.lookUpEditCode2.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.lookUpEditCode2.Properties.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("cCode", "单据号")});
            this.lookUpEditCode2.Properties.DisplayMember = "cCode";
            this.lookUpEditCode2.Properties.NullText = "";
            this.lookUpEditCode2.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.Standard;
            this.lookUpEditCode2.Properties.ValueMember = "cCode";
            this.lookUpEditCode2.Size = new System.Drawing.Size(126, 20);
            this.lookUpEditCode2.TabIndex = 204;
            // 
            // btnOK
            // 
            this.btnOK.Location = new System.Drawing.Point(667, 34);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(75, 23);
            this.btnOK.TabIndex = 205;
            this.btnOK.Text = "确定";
            this.btnOK.UseVisualStyleBackColor = true;
            this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
            // 
            // gridColcCode
            // 
            this.gridColcCode.Caption = "领用单编码";
            this.gridColcCode.FieldName = "cCode";
            this.gridColcCode.Fixed = DevExpress.XtraGrid.Columns.FixedStyle.Left;
            this.gridColcCode.Name = "gridColcCode";
            this.gridColcCode.OptionsColumn.AllowEdit = false;
            this.gridColcCode.Visible = true;
            this.gridColcCode.VisibleIndex = 1;
            this.gridColcCode.Width = 109;
            // 
            // GiveBack_Edit_SEL
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(851, 449);
            this.Controls.Add(this.btnOK);
            this.Controls.Add(this.lookUpEditCode2);
            this.Controls.Add(this.lookUpEditCode1);
            this.Controls.Add(this.dtmCode2);
            this.Controls.Add(this.lookUpEditPerson);
            this.Controls.Add(this.lookUpEditDep);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.gridControl1);
            this.Controls.Add(this.dtmCode1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnSEL);
            this.Controls.Add(this.btnCancel);
            this.Name = "GiveBack_Edit_SEL";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "工装归还_领用单";
            this.Load += new System.EventHandler(this.FrmRequisition_Edit_Load);
            ((System.ComponentModel.ISupportInitialize)(this.txtInv.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtmCode1.Properties.VistaTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtmCode1.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ItemLookUpEditSerialNo)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ItemLookUpEditInvName)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ItemLookUpEditInvStd)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lookUpEditDep.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lookUpEditPerson.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtmCode2.Properties.VistaTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtmCode2.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lookUpEditCode1.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lookUpEditCode2.Properties)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnCancel;
        private DevExpress.XtraEditors.TextEdit txtInv;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private DevExpress.XtraEditors.DateEdit dtmCode1;
        private DevExpress.XtraGrid.GridControl gridControl1;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView1;
        private DevExpress.XtraGrid.Columns.GridColumn gridColSerialNo;
        private DevExpress.XtraGrid.Columns.GridColumn gridColInvName;
        private DevExpress.XtraGrid.Columns.GridColumn gridColInvStd;
        private DevExpress.XtraGrid.Columns.GridColumn gridColRemark;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label5;
        private DevExpress.XtraEditors.LookUpEdit lookUpEditDep;
        private DevExpress.XtraEditors.LookUpEdit lookUpEditPerson;
        private DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit ItemLookUpEditInvName;
        private DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit ItemLookUpEditSerialNo;
        private DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit ItemLookUpEditInvStd;
        private System.Windows.Forms.Button btnSEL;
        private DevExpress.XtraGrid.Columns.GridColumn gridColbChoose;
        private DevExpress.XtraGrid.Columns.GridColumn gridColiID;
        private DevExpress.XtraEditors.DateEdit dtmCode2;
        private DevExpress.XtraEditors.LookUpEdit lookUpEditCode1;
        private DevExpress.XtraEditors.LookUpEdit lookUpEditCode2;
        private System.Windows.Forms.Button btnOK;
        private DevExpress.XtraGrid.Columns.GridColumn gridColcCode;
    }
}