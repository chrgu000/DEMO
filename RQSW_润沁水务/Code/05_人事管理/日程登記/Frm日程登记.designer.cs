namespace 人事管理
{
    partial class Frm日程登记
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
            this.layoutControl1 = new DevExpress.XtraLayout.LayoutControl();
            this.dateEdit2 = new DevExpress.XtraEditors.DateEdit();
            this.dateEdit1 = new DevExpress.XtraEditors.DateEdit();
            this.lookUpEdit业务员 = new DevExpress.XtraEditors.LookUpEdit();
            this.buttonEdit业务员 = new DevExpress.XtraEditors.ButtonEdit();
            this.gridControl1 = new DevExpress.XtraGrid.GridControl();
            this.gridView1 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.gridCol序号 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridCol登记部门编码 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.ItemButtonEdit部门 = new DevExpress.XtraEditors.Repository.RepositoryItemButtonEdit();
            this.gridCol登记部门 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.ItemLookUpEdit部门 = new DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit();
            this.gridCol开始日期 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridCol结束日期 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridCol备注 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridCol审核人 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridCol审核日期 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColiSave = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColiID = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridCol技术员编码 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.ItemButtonEdit技术员 = new DevExpress.XtraEditors.Repository.RepositoryItemButtonEdit();
            this.gridCol技术员 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.ItemLookUpEdit技术员 = new DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit();
            this.layoutControlGroup1 = new DevExpress.XtraLayout.LayoutControlGroup();
            this.layoutControlItem3 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem1 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem4 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem5 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem2 = new DevExpress.XtraLayout.LayoutControlItem();
            ((System.ComponentModel.ISupportInitialize)(this.dsPrint)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dsForm)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtSel)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControl1)).BeginInit();
            this.layoutControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dateEdit2.Properties.VistaTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dateEdit2.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dateEdit1.Properties.VistaTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dateEdit1.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lookUpEdit业务员.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.buttonEdit业务员.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ItemButtonEdit部门)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ItemLookUpEdit部门)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ItemButtonEdit技术员)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ItemLookUpEdit技术员)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem5)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem2)).BeginInit();
            this.SuspendLayout();
            // 
            // layoutControl1
            // 
            this.layoutControl1.AllowCustomizationMenu = false;
            this.layoutControl1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.layoutControl1.Controls.Add(this.dateEdit2);
            this.layoutControl1.Controls.Add(this.dateEdit1);
            this.layoutControl1.Controls.Add(this.lookUpEdit业务员);
            this.layoutControl1.Controls.Add(this.buttonEdit业务员);
            this.layoutControl1.Controls.Add(this.gridControl1);
            this.layoutControl1.Location = new System.Drawing.Point(0, 28);
            this.layoutControl1.Name = "layoutControl1";
            this.layoutControl1.OptionsCustomizationForm.DesignTimeCustomizationFormPositionAndSize = new System.Drawing.Rectangle(210, 239, 250, 350);
            this.layoutControl1.OptionsCustomizationForm.ShowLoadButton = false;
            this.layoutControl1.OptionsCustomizationForm.ShowSaveButton = false;
            this.layoutControl1.Root = this.layoutControlGroup1;
            this.layoutControl1.Size = new System.Drawing.Size(990, 322);
            this.layoutControl1.TabIndex = 5;
            this.layoutControl1.Text = "layoutControl1";
            // 
            // dateEdit2
            // 
            this.dateEdit2.EditValue = null;
            this.dateEdit2.Location = new System.Drawing.Point(784, 12);
            this.dateEdit2.Name = "dateEdit2";
            this.dateEdit2.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.dateEdit2.Properties.VistaTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
            this.dateEdit2.Size = new System.Drawing.Size(194, 21);
            this.dateEdit2.StyleController = this.layoutControl1;
            this.dateEdit2.TabIndex = 55;
            // 
            // dateEdit1
            // 
            this.dateEdit1.EditValue = null;
            this.dateEdit1.Location = new System.Drawing.Point(586, 12);
            this.dateEdit1.Name = "dateEdit1";
            this.dateEdit1.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.dateEdit1.Properties.VistaTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
            this.dateEdit1.Size = new System.Drawing.Size(194, 21);
            this.dateEdit1.StyleController = this.layoutControl1;
            this.dateEdit1.TabIndex = 54;
            // 
            // lookUpEdit业务员
            // 
            this.lookUpEdit业务员.Enabled = false;
            this.lookUpEdit业务员.Location = new System.Drawing.Point(232, 12);
            this.lookUpEdit业务员.Name = "lookUpEdit业务员";
            this.lookUpEdit业务员.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.lookUpEdit业务员.Properties.NullText = "";
            this.lookUpEdit业务员.Size = new System.Drawing.Size(310, 21);
            this.lookUpEdit业务员.StyleController = this.layoutControl1;
            this.lookUpEdit业务员.TabIndex = 53;
            // 
            // buttonEdit业务员
            // 
            this.buttonEdit业务员.Enabled = false;
            this.buttonEdit业务员.Location = new System.Drawing.Point(52, 12);
            this.buttonEdit业务员.Name = "buttonEdit业务员";
            this.buttonEdit业务员.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
            this.buttonEdit业务员.Size = new System.Drawing.Size(176, 21);
            this.buttonEdit业务员.StyleController = this.layoutControl1;
            this.buttonEdit业务员.TabIndex = 48;
            this.buttonEdit业务员.ButtonClick += new DevExpress.XtraEditors.Controls.ButtonPressedEventHandler(this.buttonEdit业务员_ButtonClick);
            this.buttonEdit业务员.EditValueChanged += new System.EventHandler(this.buttonEdit业务员_EditValueChanged);
            this.buttonEdit业务员.Leave += new System.EventHandler(this.buttonEdit业务员_Leave);
            // 
            // gridControl1
            // 
            this.gridControl1.Location = new System.Drawing.Point(12, 37);
            this.gridControl1.MainView = this.gridView1;
            this.gridControl1.Name = "gridControl1";
            this.gridControl1.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.ItemLookUpEdit部门,
            this.ItemButtonEdit部门,
            this.ItemButtonEdit技术员,
            this.ItemLookUpEdit技术员});
            this.gridControl1.Size = new System.Drawing.Size(966, 273);
            this.gridControl1.TabIndex = 6;
            this.gridControl1.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView1});
            // 
            // gridView1
            // 
            this.gridView1.Appearance.FocusedCell.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.gridView1.Appearance.FocusedCell.Options.UseBackColor = true;
            this.gridView1.Appearance.FocusedRow.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.gridView1.Appearance.FocusedRow.Options.UseBackColor = true;
            this.gridView1.Appearance.SelectedRow.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.gridView1.Appearance.SelectedRow.Options.UseBackColor = true;
            this.gridView1.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.gridCol序号,
            this.gridCol技术员编码,
            this.gridCol技术员,
            this.gridCol登记部门编码,
            this.gridCol登记部门,
            this.gridCol开始日期,
            this.gridCol结束日期,
            this.gridCol备注,
            this.gridCol审核人,
            this.gridCol审核日期,
            this.gridColiSave,
            this.gridColiID});
            this.gridView1.GridControl = this.gridControl1;
            this.gridView1.IndicatorWidth = 40;
            this.gridView1.Name = "gridView1";
            this.gridView1.OptionsCustomization.AllowSort = false;
            this.gridView1.OptionsLayout.Columns.StoreAllOptions = true;
            this.gridView1.OptionsLayout.Columns.StoreAppearance = true;
            this.gridView1.OptionsLayout.StoreAllOptions = true;
            this.gridView1.OptionsLayout.StoreAppearance = true;
            this.gridView1.OptionsMenu.ShowAddNewSummaryItem = DevExpress.Utils.DefaultBoolean.True;
            this.gridView1.OptionsMenu.ShowGroupSummaryEditorItem = true;
            this.gridView1.OptionsNavigation.EnterMoveNextColumn = true;
            this.gridView1.OptionsSelection.MultiSelect = true;
            this.gridView1.OptionsView.AutoCalcPreviewLineCount = true;
            this.gridView1.OptionsView.ColumnAutoWidth = false;
            this.gridView1.OptionsView.EnableAppearanceEvenRow = true;
            this.gridView1.OptionsView.EnableAppearanceOddRow = true;
            this.gridView1.OptionsView.ShowGroupPanel = false;
            this.gridView1.FocusedRowChanged += new DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventHandler(this.gridView1_FocusedRowChanged);
            this.gridView1.CustomDrawRowIndicator += new DevExpress.XtraGrid.Views.Grid.RowIndicatorCustomDrawEventHandler(this.gridView1_CustomDrawRowIndicator);
            this.gridView1.CellValueChanged += new DevExpress.XtraGrid.Views.Base.CellValueChangedEventHandler(this.gridView1_CellValueChanged);
            // 
            // gridCol序号
            // 
            this.gridCol序号.Caption = "序号";
            this.gridCol序号.FieldName = "序号";
            this.gridCol序号.Name = "gridCol序号";
            this.gridCol序号.OptionsColumn.AllowEdit = false;
            this.gridCol序号.Width = 52;
            // 
            // gridCol登记部门编码
            // 
            this.gridCol登记部门编码.AppearanceHeader.ForeColor = System.Drawing.Color.Blue;
            this.gridCol登记部门编码.AppearanceHeader.Options.UseForeColor = true;
            this.gridCol登记部门编码.Caption = "登记部门编码";
            this.gridCol登记部门编码.ColumnEdit = this.ItemButtonEdit部门;
            this.gridCol登记部门编码.FieldName = "登记部门";
            this.gridCol登记部门编码.Name = "gridCol登记部门编码";
            this.gridCol登记部门编码.OptionsColumn.AllowEdit = false;
            this.gridCol登记部门编码.Visible = true;
            this.gridCol登记部门编码.VisibleIndex = 2;
            this.gridCol登记部门编码.Width = 98;
            // 
            // ItemButtonEdit部门
            // 
            this.ItemButtonEdit部门.AutoHeight = false;
            this.ItemButtonEdit部门.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
            this.ItemButtonEdit部门.Name = "ItemButtonEdit部门";
            this.ItemButtonEdit部门.ButtonClick += new DevExpress.XtraEditors.Controls.ButtonPressedEventHandler(this.ItemButtonEdit部门_ButtonClick);
            // 
            // gridCol登记部门
            // 
            this.gridCol登记部门.Caption = "登记部门";
            this.gridCol登记部门.ColumnEdit = this.ItemLookUpEdit部门;
            this.gridCol登记部门.FieldName = "登记部门";
            this.gridCol登记部门.Name = "gridCol登记部门";
            this.gridCol登记部门.OptionsColumn.AllowEdit = false;
            this.gridCol登记部门.OptionsColumn.AllowMerge = DevExpress.Utils.DefaultBoolean.False;
            this.gridCol登记部门.Visible = true;
            this.gridCol登记部门.VisibleIndex = 3;
            this.gridCol登记部门.Width = 271;
            // 
            // ItemLookUpEdit部门
            // 
            this.ItemLookUpEdit部门.AutoHeight = false;
            this.ItemLookUpEdit部门.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.ItemLookUpEdit部门.Name = "ItemLookUpEdit部门";
            // 
            // gridCol开始日期
            // 
            this.gridCol开始日期.AppearanceHeader.ForeColor = System.Drawing.Color.Blue;
            this.gridCol开始日期.AppearanceHeader.Options.UseForeColor = true;
            this.gridCol开始日期.Caption = "开始日期";
            this.gridCol开始日期.FieldName = "开始日期";
            this.gridCol开始日期.Name = "gridCol开始日期";
            this.gridCol开始日期.Visible = true;
            this.gridCol开始日期.VisibleIndex = 4;
            this.gridCol开始日期.Width = 98;
            // 
            // gridCol结束日期
            // 
            this.gridCol结束日期.AppearanceHeader.ForeColor = System.Drawing.Color.Blue;
            this.gridCol结束日期.AppearanceHeader.Options.UseForeColor = true;
            this.gridCol结束日期.Caption = "结束日期";
            this.gridCol结束日期.FieldName = "结束日期";
            this.gridCol结束日期.Name = "gridCol结束日期";
            this.gridCol结束日期.Visible = true;
            this.gridCol结束日期.VisibleIndex = 5;
            this.gridCol结束日期.Width = 93;
            // 
            // gridCol备注
            // 
            this.gridCol备注.Caption = "备注";
            this.gridCol备注.FieldName = "备注";
            this.gridCol备注.Name = "gridCol备注";
            this.gridCol备注.Visible = true;
            this.gridCol备注.VisibleIndex = 6;
            this.gridCol备注.Width = 283;
            // 
            // gridCol审核人
            // 
            this.gridCol审核人.Caption = "审核人";
            this.gridCol审核人.FieldName = "审核人";
            this.gridCol审核人.Name = "gridCol审核人";
            // 
            // gridCol审核日期
            // 
            this.gridCol审核日期.Caption = "审核日期";
            this.gridCol审核日期.FieldName = "审核日期";
            this.gridCol审核日期.Name = "gridCol审核日期";
            // 
            // gridColiSave
            // 
            this.gridColiSave.Caption = "编辑状态";
            this.gridColiSave.FieldName = "iSave";
            this.gridColiSave.Name = "gridColiSave";
            this.gridColiSave.OptionsColumn.AllowEdit = false;
            // 
            // gridColiID
            // 
            this.gridColiID.Caption = "iID";
            this.gridColiID.FieldName = "iID";
            this.gridColiID.Name = "gridColiID";
            this.gridColiID.OptionsColumn.AllowEdit = false;
            // 
            // gridCol技术员编码
            // 
            this.gridCol技术员编码.AppearanceHeader.ForeColor = System.Drawing.Color.Blue;
            this.gridCol技术员编码.AppearanceHeader.Options.UseForeColor = true;
            this.gridCol技术员编码.Caption = "技术员编码";
            this.gridCol技术员编码.ColumnEdit = this.ItemButtonEdit技术员;
            this.gridCol技术员编码.FieldName = "技术员";
            this.gridCol技术员编码.Name = "gridCol技术员编码";
            this.gridCol技术员编码.Visible = true;
            this.gridCol技术员编码.VisibleIndex = 0;
            // 
            // ItemButtonEdit技术员
            // 
            this.ItemButtonEdit技术员.AutoHeight = false;
            this.ItemButtonEdit技术员.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
            this.ItemButtonEdit技术员.Name = "ItemButtonEdit技术员";
            this.ItemButtonEdit技术员.ButtonClick += new DevExpress.XtraEditors.Controls.ButtonPressedEventHandler(this.ItemButtonEdit技术员_ButtonClick);
            // 
            // gridCol技术员
            // 
            this.gridCol技术员.Caption = "技术员";
            this.gridCol技术员.ColumnEdit = this.ItemLookUpEdit技术员;
            this.gridCol技术员.FieldName = "技术员";
            this.gridCol技术员.Name = "gridCol技术员";
            this.gridCol技术员.OptionsColumn.AllowEdit = false;
            this.gridCol技术员.Visible = true;
            this.gridCol技术员.VisibleIndex = 1;
            // 
            // ItemLookUpEdit技术员
            // 
            this.ItemLookUpEdit技术员.AutoHeight = false;
            this.ItemLookUpEdit技术员.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.ItemLookUpEdit技术员.Name = "ItemLookUpEdit技术员";
            // 
            // layoutControlGroup1
            // 
            this.layoutControlGroup1.CustomizationFormText = "layoutControlGroup1";
            this.layoutControlGroup1.EnableIndentsWithoutBorders = DevExpress.Utils.DefaultBoolean.True;
            this.layoutControlGroup1.GroupBordersVisible = false;
            this.layoutControlGroup1.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.layoutControlItem3,
            this.layoutControlItem1,
            this.layoutControlItem4,
            this.layoutControlItem5,
            this.layoutControlItem2});
            this.layoutControlGroup1.Location = new System.Drawing.Point(0, 0);
            this.layoutControlGroup1.Name = "Root";
            this.layoutControlGroup1.Size = new System.Drawing.Size(990, 322);
            this.layoutControlGroup1.Text = "Root";
            this.layoutControlGroup1.TextVisible = false;
            // 
            // layoutControlItem3
            // 
            this.layoutControlItem3.Control = this.gridControl1;
            this.layoutControlItem3.CustomizationFormText = "layoutControlItem3";
            this.layoutControlItem3.Location = new System.Drawing.Point(0, 25);
            this.layoutControlItem3.Name = "layoutControlItem3";
            this.layoutControlItem3.Size = new System.Drawing.Size(970, 277);
            this.layoutControlItem3.Text = "layoutControlItem3";
            this.layoutControlItem3.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem3.TextToControlDistance = 0;
            this.layoutControlItem3.TextVisible = false;
            // 
            // layoutControlItem1
            // 
            this.layoutControlItem1.Control = this.buttonEdit业务员;
            this.layoutControlItem1.CustomizationFormText = "技术员";
            this.layoutControlItem1.Location = new System.Drawing.Point(0, 0);
            this.layoutControlItem1.Name = "layoutControlItem1";
            this.layoutControlItem1.Size = new System.Drawing.Size(220, 25);
            this.layoutControlItem1.Text = "技术员";
            this.layoutControlItem1.TextSize = new System.Drawing.Size(36, 14);
            // 
            // layoutControlItem4
            // 
            this.layoutControlItem4.Control = this.dateEdit1;
            this.layoutControlItem4.CustomizationFormText = "日期";
            this.layoutControlItem4.Location = new System.Drawing.Point(534, 0);
            this.layoutControlItem4.Name = "layoutControlItem4";
            this.layoutControlItem4.Size = new System.Drawing.Size(238, 25);
            this.layoutControlItem4.Text = "日期";
            this.layoutControlItem4.TextSize = new System.Drawing.Size(36, 14);
            // 
            // layoutControlItem5
            // 
            this.layoutControlItem5.Control = this.dateEdit2;
            this.layoutControlItem5.CustomizationFormText = "layoutControlItem5";
            this.layoutControlItem5.Location = new System.Drawing.Point(772, 0);
            this.layoutControlItem5.Name = "layoutControlItem5";
            this.layoutControlItem5.Size = new System.Drawing.Size(198, 25);
            this.layoutControlItem5.Text = "layoutControlItem5";
            this.layoutControlItem5.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem5.TextToControlDistance = 0;
            this.layoutControlItem5.TextVisible = false;
            // 
            // layoutControlItem2
            // 
            this.layoutControlItem2.Control = this.lookUpEdit业务员;
            this.layoutControlItem2.CustomizationFormText = "layoutControlItem2";
            this.layoutControlItem2.Location = new System.Drawing.Point(220, 0);
            this.layoutControlItem2.Name = "layoutControlItem2";
            this.layoutControlItem2.Size = new System.Drawing.Size(314, 25);
            this.layoutControlItem2.Text = "layoutControlItem2";
            this.layoutControlItem2.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem2.TextToControlDistance = 0;
            this.layoutControlItem2.TextVisible = false;
            // 
            // Frm日程登记
            // 
            this.Appearance.BackColor = System.Drawing.SystemColors.Control;
            this.Appearance.Options.UseBackColor = true;
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(988, 351);
            this.Controls.Add(this.layoutControl1);
            this.Name = "Frm日程登记";
            this.Text = "日程登记";
            this.Load += new System.EventHandler(this.Frm日程登记_Load);
            this.Controls.SetChildIndex(this.layoutControl1, 0);
            ((System.ComponentModel.ISupportInitialize)(this.dsPrint)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dsForm)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtSel)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControl1)).EndInit();
            this.layoutControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dateEdit2.Properties.VistaTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dateEdit2.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dateEdit1.Properties.VistaTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dateEdit1.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lookUpEdit业务员.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.buttonEdit业务员.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ItemButtonEdit部门)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ItemLookUpEdit部门)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ItemButtonEdit技术员)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ItemLookUpEdit技术员)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem5)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem2)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraLayout.LayoutControl layoutControl1;
        private DevExpress.XtraGrid.GridControl gridControl1;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView1;
        private DevExpress.XtraLayout.LayoutControlGroup layoutControlGroup1;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem3;
        private DevExpress.XtraGrid.Columns.GridColumn gridCol登记部门;
        private DevExpress.XtraGrid.Columns.GridColumn gridColiSave;
        private DevExpress.XtraGrid.Columns.GridColumn gridCol备注;
        private DevExpress.XtraGrid.Columns.GridColumn gridColiID;
        private DevExpress.XtraGrid.Columns.GridColumn gridCol开始日期;
        private DevExpress.XtraGrid.Columns.GridColumn gridCol结束日期;
        private DevExpress.XtraGrid.Columns.GridColumn gridCol审核人;
        private DevExpress.XtraGrid.Columns.GridColumn gridCol审核日期;
        private DevExpress.XtraEditors.ButtonEdit buttonEdit业务员;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem1;
        private DevExpress.XtraEditors.LookUpEdit lookUpEdit业务员;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem2;
        private DevExpress.XtraEditors.DateEdit dateEdit2;
        private DevExpress.XtraEditors.DateEdit dateEdit1;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem4;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem5;
        private DevExpress.XtraGrid.Columns.GridColumn gridCol序号;
        private DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit ItemLookUpEdit部门;
        private DevExpress.XtraGrid.Columns.GridColumn gridCol登记部门编码;
        private DevExpress.XtraEditors.Repository.RepositoryItemButtonEdit ItemButtonEdit部门;
        private DevExpress.XtraGrid.Columns.GridColumn gridCol技术员编码;
        private DevExpress.XtraGrid.Columns.GridColumn gridCol技术员;
        private DevExpress.XtraEditors.Repository.RepositoryItemButtonEdit ItemButtonEdit技术员;
        private DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit ItemLookUpEdit技术员;
    }
}