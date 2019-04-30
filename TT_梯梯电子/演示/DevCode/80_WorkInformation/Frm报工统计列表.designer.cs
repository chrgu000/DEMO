namespace WorkInformation
{
    partial class Frm生产报工统计列表
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
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.gridControl1 = new DevExpress.XtraGrid.GridControl();
            this.GridView1 = new DevExpress.XtraGrid.Views.BandedGrid.BandedGridView();
            this.gridBand2 = new DevExpress.XtraGrid.Views.BandedGrid.GridBand();
            this.GridCol物料编码 = new DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn();
            this.GridCol物料名称 = new DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn();
            this.GridCol规格型号 = new DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn();
            this.GridCol工序 = new DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn();
            this.GridCol部门 = new DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn();
            this.GridCol外销单号 = new DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn();
            this.gridBand1 = new DevExpress.XtraGrid.Views.BandedGrid.GridBand();
            this.GridCol制造令号码 = new DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn();
            this.GridCol人员 = new DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn();
            this.GridCol设备 = new DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn();
            this.ItemLookUpEdit设备 = new DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit();
            this.dtm生产日期1 = new DevExpress.XtraEditors.DateEdit();
            this.dtm生产日期2 = new DevExpress.XtraEditors.DateEdit();
            this.layoutControlGroup1 = new DevExpress.XtraLayout.LayoutControlGroup();
            this.layoutControlItem3 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem4 = new DevExpress.XtraLayout.LayoutControlItem();
            this.emptySpaceItem2 = new DevExpress.XtraLayout.EmptySpaceItem();
            this.layoutControlItem5 = new DevExpress.XtraLayout.LayoutControlItem();
            ((System.ComponentModel.ISupportInitialize)(this.dsPrint)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dsForm)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtSel)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControl1)).BeginInit();
            this.layoutControl1.SuspendLayout();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.GridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ItemLookUpEdit设备)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtm生产日期1.Properties.VistaTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtm生产日期1.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtm生产日期2.Properties.VistaTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtm生产日期2.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem5)).BeginInit();
            this.SuspendLayout();
            // 
            // layoutControl1
            // 
            this.layoutControl1.AllowCustomizationMenu = false;
            this.layoutControl1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.layoutControl1.Controls.Add(this.tabControl1);
            this.layoutControl1.Controls.Add(this.dtm生产日期1);
            this.layoutControl1.Controls.Add(this.dtm生产日期2);
            this.layoutControl1.Location = new System.Drawing.Point(0, 28);
            this.layoutControl1.Name = "layoutControl1";
            this.layoutControl1.OptionsCustomizationForm.DesignTimeCustomizationFormPositionAndSize = new System.Drawing.Rectangle(210, 239, 250, 350);
            this.layoutControl1.OptionsCustomizationForm.ShowLoadButton = false;
            this.layoutControl1.OptionsCustomizationForm.ShowSaveButton = false;
            this.layoutControl1.OptionsView.UseDefaultDragAndDropRendering = false;
            this.layoutControl1.Root = this.layoutControlGroup1;
            this.layoutControl1.Size = new System.Drawing.Size(916, 376);
            this.layoutControl1.TabIndex = 5;
            this.layoutControl1.Text = "layoutControl1";
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Location = new System.Drawing.Point(12, 37);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(892, 327);
            this.tabControl1.TabIndex = 9;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.gridControl1);
            this.tabPage1.Location = new System.Drawing.Point(4, 23);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(884, 300);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "报工";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // gridControl1
            // 
            this.gridControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridControl1.Location = new System.Drawing.Point(3, 3);
            this.gridControl1.MainView = this.GridView1;
            this.gridControl1.Name = "gridControl1";
            this.gridControl1.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.ItemLookUpEdit设备});
            this.gridControl1.Size = new System.Drawing.Size(878, 294);
            this.gridControl1.TabIndex = 8;
            this.gridControl1.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.GridView1});
            // 
            // GridView1
            // 
            this.GridView1.Appearance.FocusedCell.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.GridView1.Appearance.FocusedCell.Options.UseBackColor = true;
            this.GridView1.Appearance.FocusedRow.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.GridView1.Appearance.FocusedRow.Options.UseBackColor = true;
            this.GridView1.Appearance.SelectedRow.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.GridView1.Appearance.SelectedRow.Options.UseBackColor = true;
            this.GridView1.Bands.AddRange(new DevExpress.XtraGrid.Views.BandedGrid.GridBand[] {
            this.gridBand2,
            this.gridBand1});
            this.GridView1.Columns.AddRange(new DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn[] {
            this.GridCol物料编码,
            this.GridCol制造令号码,
            this.GridCol工序,
            this.GridCol部门,
            this.GridCol人员,
            this.GridCol设备,
            this.GridCol物料名称,
            this.GridCol规格型号,
            this.GridCol外销单号});
            this.GridView1.GridControl = this.gridControl1;
            this.GridView1.IndicatorWidth = 40;
            this.GridView1.Name = "GridView1";
            this.GridView1.OptionsBehavior.Editable = false;
            this.GridView1.OptionsLayout.Columns.StoreAllOptions = true;
            this.GridView1.OptionsLayout.Columns.StoreAppearance = true;
            this.GridView1.OptionsLayout.StoreAllOptions = true;
            this.GridView1.OptionsLayout.StoreAppearance = true;
            this.GridView1.OptionsMenu.ShowAddNewSummaryItem = DevExpress.Utils.DefaultBoolean.True;
            this.GridView1.OptionsMenu.ShowGroupSummaryEditorItem = true;
            this.GridView1.OptionsNavigation.EnterMoveNextColumn = true;
            this.GridView1.OptionsSelection.MultiSelect = true;
            this.GridView1.OptionsView.AutoCalcPreviewLineCount = true;
            this.GridView1.OptionsView.ColumnAutoWidth = false;
            this.GridView1.OptionsView.EnableAppearanceEvenRow = true;
            this.GridView1.OptionsView.EnableAppearanceOddRow = true;
            this.GridView1.OptionsView.ShowFooter = true;
            this.GridView1.OptionsView.ShowGroupPanel = false;
            this.GridView1.CustomDrawRowIndicator += new DevExpress.XtraGrid.Views.Grid.RowIndicatorCustomDrawEventHandler(this.gridView1_CustomDrawRowIndicator);
            // 
            // gridBand2
            // 
            this.gridBand2.Columns.Add(this.GridCol物料编码);
            this.gridBand2.Columns.Add(this.GridCol物料名称);
            this.gridBand2.Columns.Add(this.GridCol规格型号);
            this.gridBand2.Columns.Add(this.GridCol工序);
            this.gridBand2.Columns.Add(this.GridCol部门);
            this.gridBand2.Columns.Add(this.GridCol外销单号);
            this.gridBand2.Fixed = DevExpress.XtraGrid.Columns.FixedStyle.Left;
            this.gridBand2.MinWidth = 20;
            this.gridBand2.Name = "gridBand2";
            this.gridBand2.Width = 456;
            // 
            // GridCol物料编码
            // 
            this.GridCol物料编码.Caption = "物料编码";
            this.GridCol物料编码.FieldName = "物料编码";
            this.GridCol物料编码.Name = "GridCol物料编码";
            this.GridCol物料编码.Visible = true;
            this.GridCol物料编码.Width = 119;
            // 
            // GridCol物料名称
            // 
            this.GridCol物料名称.Caption = "物料名称";
            this.GridCol物料名称.FieldName = "物料名称";
            this.GridCol物料名称.Name = "GridCol物料名称";
            this.GridCol物料名称.Visible = true;
            this.GridCol物料名称.Width = 112;
            // 
            // GridCol规格型号
            // 
            this.GridCol规格型号.Caption = "规格型号";
            this.GridCol规格型号.FieldName = "规格型号";
            this.GridCol规格型号.Name = "GridCol规格型号";
            this.GridCol规格型号.Visible = true;
            this.GridCol规格型号.Width = 68;
            // 
            // GridCol工序
            // 
            this.GridCol工序.Caption = "工序";
            this.GridCol工序.FieldName = "工序";
            this.GridCol工序.Name = "GridCol工序";
            this.GridCol工序.Visible = true;
            this.GridCol工序.Width = 39;
            // 
            // GridCol部门
            // 
            this.GridCol部门.Caption = "班组";
            this.GridCol部门.FieldName = "部门";
            this.GridCol部门.Name = "GridCol部门";
            this.GridCol部门.Visible = true;
            this.GridCol部门.Width = 45;
            // 
            // GridCol外销单号
            // 
            this.GridCol外销单号.Caption = "外销单号";
            this.GridCol外销单号.FieldName = "外销单号";
            this.GridCol外销单号.Name = "GridCol外销单号";
            this.GridCol外销单号.OptionsColumn.AllowEdit = false;
            this.GridCol外销单号.Visible = true;
            this.GridCol外销单号.Width = 73;
            // 
            // gridBand1
            // 
            this.gridBand1.Columns.Add(this.GridCol制造令号码);
            this.gridBand1.Columns.Add(this.GridCol人员);
            this.gridBand1.Columns.Add(this.GridCol设备);
            this.gridBand1.MinWidth = 20;
            this.gridBand1.Name = "gridBand1";
            this.gridBand1.Width = 188;
            // 
            // GridCol制造令号码
            // 
            this.GridCol制造令号码.Caption = "制造令号码";
            this.GridCol制造令号码.FieldName = "制造令号码";
            this.GridCol制造令号码.Name = "GridCol制造令号码";
            this.GridCol制造令号码.Visible = true;
            this.GridCol制造令号码.Width = 71;
            // 
            // GridCol人员
            // 
            this.GridCol人员.Caption = "人员";
            this.GridCol人员.FieldName = "人员";
            this.GridCol人员.Name = "GridCol人员";
            this.GridCol人员.Visible = true;
            this.GridCol人员.Width = 42;
            // 
            // GridCol设备
            // 
            this.GridCol设备.Caption = "设备";
            this.GridCol设备.FieldName = "设备";
            this.GridCol设备.Name = "GridCol设备";
            this.GridCol设备.Visible = true;
            // 
            // ItemLookUpEdit设备
            // 
            this.ItemLookUpEdit设备.AutoHeight = false;
            this.ItemLookUpEdit设备.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.ItemLookUpEdit设备.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("Machine", "设备")});
            this.ItemLookUpEdit设备.DisplayMember = "Machine";
            this.ItemLookUpEdit设备.Name = "ItemLookUpEdit设备";
            this.ItemLookUpEdit设备.NullText = "";
            this.ItemLookUpEdit设备.Tag = "";
            this.ItemLookUpEdit设备.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.Standard;
            this.ItemLookUpEdit设备.ValueMember = "Machine";
            // 
            // dtm生产日期1
            // 
            this.dtm生产日期1.EditValue = null;
            this.dtm生产日期1.Location = new System.Drawing.Point(88, 12);
            this.dtm生产日期1.Name = "dtm生产日期1";
            this.dtm生产日期1.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.dtm生产日期1.Properties.VistaTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
            this.dtm生产日期1.Size = new System.Drawing.Size(142, 21);
            this.dtm生产日期1.StyleController = this.layoutControl1;
            this.dtm生产日期1.TabIndex = 8;
            // 
            // dtm生产日期2
            // 
            this.dtm生产日期2.EditValue = null;
            this.dtm生产日期2.Location = new System.Drawing.Point(234, 12);
            this.dtm生产日期2.Name = "dtm生产日期2";
            this.dtm生产日期2.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.dtm生产日期2.Properties.VistaTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
            this.dtm生产日期2.Size = new System.Drawing.Size(164, 21);
            this.dtm生产日期2.StyleController = this.layoutControl1;
            this.dtm生产日期2.TabIndex = 8;
            // 
            // layoutControlGroup1
            // 
            this.layoutControlGroup1.CustomizationFormText = "layoutControlGroup1";
            this.layoutControlGroup1.EnableIndentsWithoutBorders = DevExpress.Utils.DefaultBoolean.True;
            this.layoutControlGroup1.GroupBordersVisible = false;
            this.layoutControlGroup1.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.layoutControlItem3,
            this.layoutControlItem4,
            this.emptySpaceItem2,
            this.layoutControlItem5});
            this.layoutControlGroup1.Location = new System.Drawing.Point(0, 0);
            this.layoutControlGroup1.Name = "Root";
            this.layoutControlGroup1.Size = new System.Drawing.Size(916, 376);
            this.layoutControlGroup1.Text = "Root";
            this.layoutControlGroup1.TextVisible = false;
            // 
            // layoutControlItem3
            // 
            this.layoutControlItem3.Control = this.dtm生产日期2;
            this.layoutControlItem3.CustomizationFormText = "layoutControlItem3";
            this.layoutControlItem3.Location = new System.Drawing.Point(222, 0);
            this.layoutControlItem3.Name = "layoutControlItem3";
            this.layoutControlItem3.Size = new System.Drawing.Size(168, 25);
            this.layoutControlItem3.Text = "layoutControlItem3";
            this.layoutControlItem3.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem3.TextToControlDistance = 0;
            this.layoutControlItem3.TextVisible = false;
            // 
            // layoutControlItem4
            // 
            this.layoutControlItem4.Control = this.dtm生产日期1;
            this.layoutControlItem4.CustomizationFormText = "生产日期";
            this.layoutControlItem4.Location = new System.Drawing.Point(0, 0);
            this.layoutControlItem4.Name = "layoutControlItem4";
            this.layoutControlItem4.Size = new System.Drawing.Size(222, 25);
            this.layoutControlItem4.Text = "生产报工日期";
            this.layoutControlItem4.TextSize = new System.Drawing.Size(72, 14);
            // 
            // emptySpaceItem2
            // 
            this.emptySpaceItem2.AllowHotTrack = false;
            this.emptySpaceItem2.CustomizationFormText = "emptySpaceItem2";
            this.emptySpaceItem2.Location = new System.Drawing.Point(390, 0);
            this.emptySpaceItem2.Name = "emptySpaceItem2";
            this.emptySpaceItem2.Size = new System.Drawing.Size(506, 25);
            this.emptySpaceItem2.Text = "emptySpaceItem2";
            this.emptySpaceItem2.TextSize = new System.Drawing.Size(0, 0);
            // 
            // layoutControlItem5
            // 
            this.layoutControlItem5.Control = this.tabControl1;
            this.layoutControlItem5.CustomizationFormText = "layoutControlItem5";
            this.layoutControlItem5.Location = new System.Drawing.Point(0, 25);
            this.layoutControlItem5.Name = "layoutControlItem5";
            this.layoutControlItem5.Size = new System.Drawing.Size(896, 331);
            this.layoutControlItem5.Text = "layoutControlItem5";
            this.layoutControlItem5.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem5.TextToControlDistance = 0;
            this.layoutControlItem5.TextVisible = false;
            // 
            // Frm生产报工统计列表
            // 
            this.Appearance.BackColor = System.Drawing.SystemColors.Control;
            this.Appearance.Options.UseBackColor = true;
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(914, 405);
            this.Controls.Add(this.layoutControl1);
            this.Name = "Frm生产报工统计列表";
            this.Text = "生产报工统计列表";
            this.Load += new System.EventHandler(this.Frm报工统计列表_Load);
            this.Controls.SetChildIndex(this.layoutControl1, 0);
            ((System.ComponentModel.ISupportInitialize)(this.dsPrint)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dsForm)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtSel)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControl1)).EndInit();
            this.layoutControl1.ResumeLayout(false);
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.GridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ItemLookUpEdit设备)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtm生产日期1.Properties.VistaTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtm生产日期1.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtm生产日期2.Properties.VistaTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtm生产日期2.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem5)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraLayout.LayoutControl layoutControl1;
        private DevExpress.XtraLayout.LayoutControlGroup layoutControlGroup1;
        private DevExpress.XtraEditors.DateEdit dtm生产日期1;
        private DevExpress.XtraEditors.DateEdit dtm生产日期2;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem3;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem4;
        private DevExpress.XtraLayout.EmptySpaceItem emptySpaceItem2;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private DevExpress.XtraGrid.GridControl gridControl1;
        private DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit ItemLookUpEdit设备;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem5;
        private DevExpress.XtraGrid.Views.BandedGrid.BandedGridView GridView1;
        private DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn GridCol物料编码;
        private DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn GridCol制造令号码;
        private DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn GridCol工序;
        private DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn GridCol部门;
        private DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn GridCol人员;
        private DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn GridCol设备;
        private DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn GridCol物料名称;
        private DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn GridCol规格型号;
        private DevExpress.XtraGrid.Views.BandedGrid.GridBand gridBand2;
        private DevExpress.XtraGrid.Views.BandedGrid.GridBand gridBand1;
        private DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn GridCol外销单号;
    }
}