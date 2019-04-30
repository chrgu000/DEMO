namespace ImportDLL
{
    partial class Frm排产日期比对
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
            this.buttonEdit存货编码 = new DevExpress.XtraEditors.ButtonEdit();
            this.gridControl1 = new DevExpress.XtraGrid.GridControl();
            this.gridView1 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.gridCol生产订单号 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridCol生产订单行号 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridCol物料编码 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridCol物料名称 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridCol工序说明 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridCol计划生产完工日期 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridCol实际完工日期 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridCol零件号 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.ItemLookUpEdit存货分类 = new DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit();
            this.ItemLookUpEdit存货名称 = new DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit();
            this.checkEdit1 = new DevExpress.XtraEditors.CheckEdit();
            this.lookUpEdit存货编码 = new DevExpress.XtraEditors.LookUpEdit();
            this.layoutControlGroup1 = new DevExpress.XtraLayout.LayoutControlGroup();
            this.layoutControlItem3 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem4 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem5 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem1 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem6 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem2 = new DevExpress.XtraLayout.LayoutControlItem();
            this.gridCol委外工序 = new DevExpress.XtraGrid.Columns.GridColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dsPrint)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dsForm)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtSel)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControl1)).BeginInit();
            this.layoutControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dateEdit2.Properties.VistaTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dateEdit2.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dateEdit1.Properties.VistaTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dateEdit1.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.buttonEdit存货编码.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ItemLookUpEdit存货分类)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ItemLookUpEdit存货名称)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.checkEdit1.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lookUpEdit存货编码.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem5)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem6)).BeginInit();
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
            this.layoutControl1.Controls.Add(this.buttonEdit存货编码);
            this.layoutControl1.Controls.Add(this.gridControl1);
            this.layoutControl1.Controls.Add(this.checkEdit1);
            this.layoutControl1.Controls.Add(this.lookUpEdit存货编码);
            this.layoutControl1.Location = new System.Drawing.Point(0, 28);
            this.layoutControl1.Name = "layoutControl1";
            this.layoutControl1.OptionsCustomizationForm.DesignTimeCustomizationFormPositionAndSize = new System.Drawing.Rectangle(64, 320, 250, 350);
            this.layoutControl1.OptionsCustomizationForm.ShowLoadButton = false;
            this.layoutControl1.OptionsCustomizationForm.ShowSaveButton = false;
            this.layoutControl1.OptionsView.UseDefaultDragAndDropRendering = false;
            this.layoutControl1.Root = this.layoutControlGroup1;
            this.layoutControl1.Size = new System.Drawing.Size(981, 473);
            this.layoutControl1.TabIndex = 5;
            this.layoutControl1.Text = "layoutControl1";
            // 
            // dateEdit2
            // 
            this.dateEdit2.EditValue = null;
            this.dateEdit2.Location = new System.Drawing.Point(553, 12);
            this.dateEdit2.Name = "dateEdit2";
            this.dateEdit2.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.dateEdit2.Properties.VistaTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
            this.dateEdit2.Size = new System.Drawing.Size(322, 21);
            this.dateEdit2.StyleController = this.layoutControl1;
            this.dateEdit2.TabIndex = 67;
            // 
            // dateEdit1
            // 
            this.dateEdit1.EditValue = null;
            this.dateEdit1.Location = new System.Drawing.Point(88, 12);
            this.dateEdit1.Name = "dateEdit1";
            this.dateEdit1.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.dateEdit1.Properties.VistaTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
            this.dateEdit1.Size = new System.Drawing.Size(385, 21);
            this.dateEdit1.StyleController = this.layoutControl1;
            this.dateEdit1.TabIndex = 66;
            // 
            // buttonEdit存货编码
            // 
            this.buttonEdit存货编码.Location = new System.Drawing.Point(88, 37);
            this.buttonEdit存货编码.Name = "buttonEdit存货编码";
            this.buttonEdit存货编码.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
            this.buttonEdit存货编码.Size = new System.Drawing.Size(385, 21);
            this.buttonEdit存货编码.StyleController = this.layoutControl1;
            this.buttonEdit存货编码.TabIndex = 64;
            this.buttonEdit存货编码.ButtonClick += new DevExpress.XtraEditors.Controls.ButtonPressedEventHandler(this.buttonEdit存货编码_ButtonClick);
            this.buttonEdit存货编码.EditValueChanged += new System.EventHandler(this.buttonEdit存货编码_EditValueChanged);
            this.buttonEdit存货编码.Enter += new System.EventHandler(this.buttonEdit存货编码_Leave);
            // 
            // gridControl1
            // 
            this.gridControl1.Location = new System.Drawing.Point(12, 62);
            this.gridControl1.MainView = this.gridView1;
            this.gridControl1.Name = "gridControl1";
            this.gridControl1.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.ItemLookUpEdit存货分类,
            this.ItemLookUpEdit存货名称});
            this.gridControl1.Size = new System.Drawing.Size(957, 399);
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
            this.gridCol生产订单号,
            this.gridCol生产订单行号,
            this.gridCol物料编码,
            this.gridCol物料名称,
            this.gridCol工序说明,
            this.gridCol计划生产完工日期,
            this.gridCol实际完工日期,
            this.gridCol零件号,
            this.gridCol委外工序});
            this.gridView1.GridControl = this.gridControl1;
            this.gridView1.IndicatorWidth = 40;
            this.gridView1.Name = "gridView1";
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
            this.gridView1.OptionsView.ShowFooter = true;
            this.gridView1.OptionsView.ShowGroupPanel = false;
            this.gridView1.CustomDrawRowIndicator += new DevExpress.XtraGrid.Views.Grid.RowIndicatorCustomDrawEventHandler(this.gridView1_CustomDrawRowIndicator);
            this.gridView1.CellValueChanged += new DevExpress.XtraGrid.Views.Base.CellValueChangedEventHandler(this.gridView1_CellValueChanged);
            // 
            // gridCol生产订单号
            // 
            this.gridCol生产订单号.Caption = "生产订单号";
            this.gridCol生产订单号.FieldName = "生产订单号";
            this.gridCol生产订单号.Name = "gridCol生产订单号";
            this.gridCol生产订单号.Visible = true;
            this.gridCol生产订单号.VisibleIndex = 0;
            this.gridCol生产订单号.Width = 109;
            // 
            // gridCol生产订单行号
            // 
            this.gridCol生产订单行号.Caption = "生产订单行号";
            this.gridCol生产订单行号.FieldName = "生产订单行号";
            this.gridCol生产订单行号.Name = "gridCol生产订单行号";
            this.gridCol生产订单行号.Visible = true;
            this.gridCol生产订单行号.VisibleIndex = 1;
            this.gridCol生产订单行号.Width = 99;
            // 
            // gridCol物料编码
            // 
            this.gridCol物料编码.Caption = "物料编码";
            this.gridCol物料编码.FieldName = "物料编码";
            this.gridCol物料编码.Name = "gridCol物料编码";
            this.gridCol物料编码.OptionsColumn.ReadOnly = true;
            this.gridCol物料编码.Visible = true;
            this.gridCol物料编码.VisibleIndex = 3;
            // 
            // gridCol物料名称
            // 
            this.gridCol物料名称.Caption = "物料名称";
            this.gridCol物料名称.FieldName = "物料名称";
            this.gridCol物料名称.Name = "gridCol物料名称";
            this.gridCol物料名称.Visible = true;
            this.gridCol物料名称.VisibleIndex = 4;
            // 
            // gridCol工序说明
            // 
            this.gridCol工序说明.Caption = "工序说明";
            this.gridCol工序说明.FieldName = "工序说明";
            this.gridCol工序说明.Name = "gridCol工序说明";
            this.gridCol工序说明.OptionsColumn.ReadOnly = true;
            this.gridCol工序说明.Summary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] {
            new DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum)});
            this.gridCol工序说明.Visible = true;
            this.gridCol工序说明.VisibleIndex = 5;
            this.gridCol工序说明.Width = 97;
            // 
            // gridCol计划生产完工日期
            // 
            this.gridCol计划生产完工日期.Caption = "计划生产完工日期";
            this.gridCol计划生产完工日期.FieldName = "计划生产完工日期";
            this.gridCol计划生产完工日期.Name = "gridCol计划生产完工日期";
            this.gridCol计划生产完工日期.Visible = true;
            this.gridCol计划生产完工日期.VisibleIndex = 6;
            this.gridCol计划生产完工日期.Width = 111;
            // 
            // gridCol实际完工日期
            // 
            this.gridCol实际完工日期.Caption = "实际完工日期";
            this.gridCol实际完工日期.FieldName = "实际完工日期";
            this.gridCol实际完工日期.Name = "gridCol实际完工日期";
            this.gridCol实际完工日期.Visible = true;
            this.gridCol实际完工日期.VisibleIndex = 7;
            this.gridCol实际完工日期.Width = 124;
            // 
            // gridCol零件号
            // 
            this.gridCol零件号.Caption = "零件号";
            this.gridCol零件号.FieldName = "零件号";
            this.gridCol零件号.Name = "gridCol零件号";
            this.gridCol零件号.Visible = true;
            this.gridCol零件号.VisibleIndex = 2;
            // 
            // ItemLookUpEdit存货分类
            // 
            this.ItemLookUpEdit存货分类.AutoHeight = false;
            this.ItemLookUpEdit存货分类.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.ItemLookUpEdit存货分类.Name = "ItemLookUpEdit存货分类";
            this.ItemLookUpEdit存货分类.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.Standard;
            // 
            // ItemLookUpEdit存货名称
            // 
            this.ItemLookUpEdit存货名称.AutoHeight = false;
            this.ItemLookUpEdit存货名称.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.ItemLookUpEdit存货名称.Name = "ItemLookUpEdit存货名称";
            this.ItemLookUpEdit存货名称.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.Standard;
            // 
            // checkEdit1
            // 
            this.checkEdit1.EditValue = true;
            this.checkEdit1.Location = new System.Drawing.Point(879, 12);
            this.checkEdit1.Name = "checkEdit1";
            this.checkEdit1.Properties.Caption = "未关闭";
            this.checkEdit1.Size = new System.Drawing.Size(90, 19);
            this.checkEdit1.StyleController = this.layoutControl1;
            this.checkEdit1.TabIndex = 68;
            // 
            // lookUpEdit存货编码
            // 
            this.lookUpEdit存货编码.Enabled = false;
            this.lookUpEdit存货编码.Location = new System.Drawing.Point(477, 37);
            this.lookUpEdit存货编码.Name = "lookUpEdit存货编码";
            this.lookUpEdit存货编码.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.lookUpEdit存货编码.Properties.NullText = "";
            this.lookUpEdit存货编码.Size = new System.Drawing.Size(492, 21);
            this.lookUpEdit存货编码.StyleController = this.layoutControl1;
            this.lookUpEdit存货编码.TabIndex = 65;
            // 
            // layoutControlGroup1
            // 
            this.layoutControlGroup1.CustomizationFormText = "layoutControlGroup1";
            this.layoutControlGroup1.EnableIndentsWithoutBorders = DevExpress.Utils.DefaultBoolean.True;
            this.layoutControlGroup1.GroupBordersVisible = false;
            this.layoutControlGroup1.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.layoutControlItem3,
            this.layoutControlItem4,
            this.layoutControlItem5,
            this.layoutControlItem1,
            this.layoutControlItem6,
            this.layoutControlItem2});
            this.layoutControlGroup1.Location = new System.Drawing.Point(0, 0);
            this.layoutControlGroup1.Name = "Root";
            this.layoutControlGroup1.Size = new System.Drawing.Size(981, 473);
            this.layoutControlGroup1.Text = "Root";
            this.layoutControlGroup1.TextVisible = false;
            // 
            // layoutControlItem3
            // 
            this.layoutControlItem3.Control = this.gridControl1;
            this.layoutControlItem3.CustomizationFormText = "layoutControlItem3";
            this.layoutControlItem3.Location = new System.Drawing.Point(0, 50);
            this.layoutControlItem3.Name = "layoutControlItem3";
            this.layoutControlItem3.Size = new System.Drawing.Size(961, 403);
            this.layoutControlItem3.Text = "列表";
            this.layoutControlItem3.TextLocation = DevExpress.Utils.Locations.Top;
            this.layoutControlItem3.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem3.TextToControlDistance = 0;
            this.layoutControlItem3.TextVisible = false;
            // 
            // layoutControlItem4
            // 
            this.layoutControlItem4.Control = this.lookUpEdit存货编码;
            this.layoutControlItem4.CustomizationFormText = "layoutControlItem4";
            this.layoutControlItem4.Location = new System.Drawing.Point(465, 25);
            this.layoutControlItem4.Name = "layoutControlItem4";
            this.layoutControlItem4.Size = new System.Drawing.Size(496, 25);
            this.layoutControlItem4.Text = "layoutControlItem4";
            this.layoutControlItem4.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem4.TextToControlDistance = 0;
            this.layoutControlItem4.TextVisible = false;
            // 
            // layoutControlItem5
            // 
            this.layoutControlItem5.Control = this.dateEdit1;
            this.layoutControlItem5.CustomizationFormText = "开始日期";
            this.layoutControlItem5.Location = new System.Drawing.Point(0, 0);
            this.layoutControlItem5.Name = "layoutControlItem5";
            this.layoutControlItem5.Size = new System.Drawing.Size(465, 25);
            this.layoutControlItem5.Text = "排产开始日期";
            this.layoutControlItem5.TextSize = new System.Drawing.Size(72, 14);
            // 
            // layoutControlItem1
            // 
            this.layoutControlItem1.Control = this.checkEdit1;
            this.layoutControlItem1.CustomizationFormText = "layoutControlItem1";
            this.layoutControlItem1.Location = new System.Drawing.Point(867, 0);
            this.layoutControlItem1.Name = "layoutControlItem1";
            this.layoutControlItem1.Size = new System.Drawing.Size(94, 25);
            this.layoutControlItem1.Text = "layoutControlItem1";
            this.layoutControlItem1.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem1.TextToControlDistance = 0;
            this.layoutControlItem1.TextVisible = false;
            // 
            // layoutControlItem6
            // 
            this.layoutControlItem6.Control = this.dateEdit2;
            this.layoutControlItem6.CustomizationFormText = "结束日期";
            this.layoutControlItem6.Location = new System.Drawing.Point(465, 0);
            this.layoutControlItem6.Name = "layoutControlItem6";
            this.layoutControlItem6.Size = new System.Drawing.Size(402, 25);
            this.layoutControlItem6.Text = "排产结束日期";
            this.layoutControlItem6.TextSize = new System.Drawing.Size(72, 14);
            // 
            // layoutControlItem2
            // 
            this.layoutControlItem2.Control = this.buttonEdit存货编码;
            this.layoutControlItem2.CustomizationFormText = "业务员";
            this.layoutControlItem2.Location = new System.Drawing.Point(0, 25);
            this.layoutControlItem2.Name = "layoutControlItem2";
            this.layoutControlItem2.Size = new System.Drawing.Size(465, 25);
            this.layoutControlItem2.Text = "存货编码";
            this.layoutControlItem2.TextSize = new System.Drawing.Size(72, 14);
            // 
            // gridCol委外工序
            // 
            this.gridCol委外工序.Caption = "委外工序";
            this.gridCol委外工序.FieldName = "委外工序";
            this.gridCol委外工序.Name = "gridCol委外工序";
            this.gridCol委外工序.OptionsColumn.ReadOnly = true;
            this.gridCol委外工序.Visible = true;
            this.gridCol委外工序.VisibleIndex = 8;
            // 
            // Frm排产日期比对
            // 
            this.Appearance.BackColor = System.Drawing.SystemColors.Control;
            this.Appearance.Options.UseBackColor = true;
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(979, 502);
            this.Controls.Add(this.layoutControl1);
            this.Name = "Frm排产日期比对";
            this.Text = "排产日期比对";
            this.Load += new System.EventHandler(this.Frm排产日期比对_Load);
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
            ((System.ComponentModel.ISupportInitialize)(this.buttonEdit存货编码.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ItemLookUpEdit存货分类)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ItemLookUpEdit存货名称)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.checkEdit1.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lookUpEdit存货编码.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem5)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem6)).EndInit();
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
        private DevExpress.XtraEditors.LookUpEdit lookUpEdit存货编码;
        private DevExpress.XtraEditors.ButtonEdit buttonEdit存货编码;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem4;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem2;
        private DevExpress.XtraGrid.Columns.GridColumn gridCol工序说明;
        private DevExpress.XtraEditors.DateEdit dateEdit2;
        private DevExpress.XtraEditors.DateEdit dateEdit1;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem5;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem6;
        private DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit ItemLookUpEdit存货分类;
        private DevExpress.XtraGrid.Columns.GridColumn gridCol物料编码;
        private DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit ItemLookUpEdit存货名称;
        private DevExpress.XtraGrid.Columns.GridColumn gridCol生产订单号;
        private DevExpress.XtraGrid.Columns.GridColumn gridCol物料名称;
        private DevExpress.XtraGrid.Columns.GridColumn gridCol生产订单行号;
        private DevExpress.XtraGrid.Columns.GridColumn gridCol计划生产完工日期;
        private DevExpress.XtraGrid.Columns.GridColumn gridCol实际完工日期;
        private DevExpress.XtraEditors.CheckEdit checkEdit1;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem1;
        private DevExpress.XtraGrid.Columns.GridColumn gridCol零件号;
        private DevExpress.XtraGrid.Columns.GridColumn gridCol委外工序;
    }
}