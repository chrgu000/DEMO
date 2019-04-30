namespace 销售
{
    partial class Frm意向性客户状态查询
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
            this.gridControl1 = new DevExpress.XtraGrid.GridControl();
            this.gridView1 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.gridCol业务员 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridCol部门 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridCol客户名称 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridCol联系人 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridCol联系电话 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridCol地址 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridCol状态 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridCol报备时间 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.ItemLookUpEdit业务员 = new DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit();
            this.ItemLookUpEdit部门 = new DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit();
            this.ItemLookUpEdit客户状态 = new DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit();
            this.ItemLookUpEdit区域 = new DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit();
            this.layoutControlGroup1 = new DevExpress.XtraLayout.LayoutControlGroup();
            this.layoutControlItem3 = new DevExpress.XtraLayout.LayoutControlItem();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.layoutControlItem1 = new DevExpress.XtraLayout.LayoutControlItem();
            this.emptySpaceItem1 = new DevExpress.XtraLayout.EmptySpaceItem();
            ((System.ComponentModel.ISupportInitialize)(this.dsPrint)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dsForm)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtSel)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControl1)).BeginInit();
            this.layoutControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ItemLookUpEdit业务员)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ItemLookUpEdit部门)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ItemLookUpEdit客户状态)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ItemLookUpEdit区域)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem1)).BeginInit();
            this.SuspendLayout();
            // 
            // layoutControl1
            // 
            this.layoutControl1.AllowCustomizationMenu = false;
            this.layoutControl1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.layoutControl1.Controls.Add(this.textBox1);
            this.layoutControl1.Controls.Add(this.gridControl1);
            this.layoutControl1.Location = new System.Drawing.Point(0, 28);
            this.layoutControl1.Name = "layoutControl1";
            this.layoutControl1.OptionsCustomizationForm.DesignTimeCustomizationFormPositionAndSize = new System.Drawing.Rectangle(210, 239, 250, 350);
            this.layoutControl1.OptionsCustomizationForm.ShowLoadButton = false;
            this.layoutControl1.OptionsCustomizationForm.ShowSaveButton = false;
            this.layoutControl1.OptionsView.UseDefaultDragAndDropRendering = false;
            this.layoutControl1.Root = this.layoutControlGroup1;
            this.layoutControl1.Size = new System.Drawing.Size(1030, 440);
            this.layoutControl1.TabIndex = 5;
            this.layoutControl1.Text = "layoutControl1";
            // 
            // gridControl1
            // 
            this.gridControl1.Location = new System.Drawing.Point(12, 36);
            this.gridControl1.MainView = this.gridView1;
            this.gridControl1.Name = "gridControl1";
            this.gridControl1.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.ItemLookUpEdit业务员,
            this.ItemLookUpEdit部门,
            this.ItemLookUpEdit客户状态,
            this.ItemLookUpEdit区域});
            this.gridControl1.Size = new System.Drawing.Size(1006, 392);
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
            this.gridCol业务员,
            this.gridCol部门,
            this.gridCol客户名称,
            this.gridCol联系人,
            this.gridCol联系电话,
            this.gridCol地址,
            this.gridCol状态,
            this.gridCol报备时间});
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
            this.gridView1.CustomDrawRowIndicator += new DevExpress.XtraGrid.Views.Grid.RowIndicatorCustomDrawEventHandler(this.gridView1_CustomDrawRowIndicator);
            // 
            // gridCol业务员
            // 
            this.gridCol业务员.Caption = "业务员";
            this.gridCol业务员.FieldName = "业务员";
            this.gridCol业务员.Name = "gridCol业务员";
            this.gridCol业务员.OptionsColumn.ReadOnly = true;
            this.gridCol业务员.Visible = true;
            this.gridCol业务员.VisibleIndex = 0;
            // 
            // gridCol部门
            // 
            this.gridCol部门.Caption = "部门";
            this.gridCol部门.FieldName = "部门";
            this.gridCol部门.Name = "gridCol部门";
            this.gridCol部门.OptionsColumn.ReadOnly = true;
            this.gridCol部门.Visible = true;
            this.gridCol部门.VisibleIndex = 1;
            // 
            // gridCol客户名称
            // 
            this.gridCol客户名称.Caption = "客户名称";
            this.gridCol客户名称.FieldName = "客户名称";
            this.gridCol客户名称.Name = "gridCol客户名称";
            this.gridCol客户名称.OptionsColumn.ReadOnly = true;
            this.gridCol客户名称.Visible = true;
            this.gridCol客户名称.VisibleIndex = 2;
            this.gridCol客户名称.Width = 198;
            // 
            // gridCol联系人
            // 
            this.gridCol联系人.Caption = "联系人";
            this.gridCol联系人.FieldName = "联系人";
            this.gridCol联系人.Name = "gridCol联系人";
            this.gridCol联系人.OptionsColumn.ReadOnly = true;
            this.gridCol联系人.Visible = true;
            this.gridCol联系人.VisibleIndex = 3;
            // 
            // gridCol联系电话
            // 
            this.gridCol联系电话.Caption = "联系电话";
            this.gridCol联系电话.FieldName = "联系电话";
            this.gridCol联系电话.Name = "gridCol联系电话";
            this.gridCol联系电话.OptionsColumn.ReadOnly = true;
            this.gridCol联系电话.Visible = true;
            this.gridCol联系电话.VisibleIndex = 4;
            // 
            // gridCol地址
            // 
            this.gridCol地址.Caption = "地址";
            this.gridCol地址.FieldName = "地址";
            this.gridCol地址.Name = "gridCol地址";
            this.gridCol地址.OptionsColumn.ReadOnly = true;
            this.gridCol地址.Visible = true;
            this.gridCol地址.VisibleIndex = 5;
            // 
            // gridCol状态
            // 
            this.gridCol状态.Caption = "状态";
            this.gridCol状态.FieldName = "状态";
            this.gridCol状态.Name = "gridCol状态";
            this.gridCol状态.OptionsColumn.ReadOnly = true;
            this.gridCol状态.Visible = true;
            this.gridCol状态.VisibleIndex = 6;
            // 
            // gridCol报备时间
            // 
            this.gridCol报备时间.Caption = "报备时间";
            this.gridCol报备时间.FieldName = "报备时间";
            this.gridCol报备时间.Name = "gridCol报备时间";
            this.gridCol报备时间.OptionsColumn.ReadOnly = true;
            this.gridCol报备时间.Visible = true;
            this.gridCol报备时间.VisibleIndex = 7;
            // 
            // ItemLookUpEdit业务员
            // 
            this.ItemLookUpEdit业务员.AutoHeight = false;
            this.ItemLookUpEdit业务员.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.ItemLookUpEdit业务员.Name = "ItemLookUpEdit业务员";
            this.ItemLookUpEdit业务员.NullText = "";
            this.ItemLookUpEdit业务员.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.Standard;
            // 
            // ItemLookUpEdit部门
            // 
            this.ItemLookUpEdit部门.AutoHeight = false;
            this.ItemLookUpEdit部门.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.ItemLookUpEdit部门.Name = "ItemLookUpEdit部门";
            this.ItemLookUpEdit部门.NullText = "";
            this.ItemLookUpEdit部门.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.Standard;
            // 
            // ItemLookUpEdit客户状态
            // 
            this.ItemLookUpEdit客户状态.AutoHeight = false;
            this.ItemLookUpEdit客户状态.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.ItemLookUpEdit客户状态.Name = "ItemLookUpEdit客户状态";
            this.ItemLookUpEdit客户状态.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.Standard;
            // 
            // ItemLookUpEdit区域
            // 
            this.ItemLookUpEdit区域.AutoHeight = false;
            this.ItemLookUpEdit区域.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.ItemLookUpEdit区域.Name = "ItemLookUpEdit区域";
            this.ItemLookUpEdit区域.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.Standard;
            // 
            // layoutControlGroup1
            // 
            this.layoutControlGroup1.CustomizationFormText = "layoutControlGroup1";
            this.layoutControlGroup1.EnableIndentsWithoutBorders = DevExpress.Utils.DefaultBoolean.True;
            this.layoutControlGroup1.GroupBordersVisible = false;
            this.layoutControlGroup1.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.layoutControlItem3,
            this.layoutControlItem1,
            this.emptySpaceItem1});
            this.layoutControlGroup1.Location = new System.Drawing.Point(0, 0);
            this.layoutControlGroup1.Name = "Root";
            this.layoutControlGroup1.Size = new System.Drawing.Size(1030, 440);
            this.layoutControlGroup1.Text = "Root";
            this.layoutControlGroup1.TextVisible = false;
            // 
            // layoutControlItem3
            // 
            this.layoutControlItem3.Control = this.gridControl1;
            this.layoutControlItem3.CustomizationFormText = "layoutControlItem3";
            this.layoutControlItem3.Location = new System.Drawing.Point(0, 24);
            this.layoutControlItem3.Name = "layoutControlItem3";
            this.layoutControlItem3.Size = new System.Drawing.Size(1010, 396);
            this.layoutControlItem3.Text = "layoutControlItem3";
            this.layoutControlItem3.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem3.TextToControlDistance = 0;
            this.layoutControlItem3.TextVisible = false;
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(28, 12);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(28, 20);
            this.textBox1.TabIndex = 7;
            this.textBox1.Text = "3";
            // 
            // layoutControlItem1
            // 
            this.layoutControlItem1.Control = this.textBox1;
            this.layoutControlItem1.CustomizationFormText = "月";
            this.layoutControlItem1.Location = new System.Drawing.Point(0, 0);
            this.layoutControlItem1.Name = "layoutControlItem1";
            this.layoutControlItem1.Size = new System.Drawing.Size(48, 24);
            this.layoutControlItem1.Text = "月";
            this.layoutControlItem1.TextSize = new System.Drawing.Size(12, 14);
            // 
            // emptySpaceItem1
            // 
            this.emptySpaceItem1.AllowHotTrack = false;
            this.emptySpaceItem1.CustomizationFormText = "emptySpaceItem1";
            this.emptySpaceItem1.Location = new System.Drawing.Point(48, 0);
            this.emptySpaceItem1.Name = "emptySpaceItem1";
            this.emptySpaceItem1.Size = new System.Drawing.Size(962, 24);
            this.emptySpaceItem1.Text = "emptySpaceItem1";
            this.emptySpaceItem1.TextSize = new System.Drawing.Size(0, 0);
            // 
            // Frm意向性客户状态查询
            // 
            this.Appearance.BackColor = System.Drawing.SystemColors.Control;
            this.Appearance.Options.UseBackColor = true;
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1028, 469);
            this.Controls.Add(this.layoutControl1);
            this.Name = "Frm意向性客户状态查询";
            this.Text = "意向性客户状态查询";
            this.Load += new System.EventHandler(this.Frm意向性客户状态查询_Load);
            this.Controls.SetChildIndex(this.layoutControl1, 0);
            ((System.ComponentModel.ISupportInitialize)(this.dsPrint)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dsForm)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtSel)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControl1)).EndInit();
            this.layoutControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ItemLookUpEdit业务员)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ItemLookUpEdit部门)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ItemLookUpEdit客户状态)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ItemLookUpEdit区域)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraLayout.LayoutControl layoutControl1;
        private DevExpress.XtraGrid.GridControl gridControl1;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView1;
        private DevExpress.XtraLayout.LayoutControlGroup layoutControlGroup1;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem3;
        private DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit ItemLookUpEdit业务员;
        private DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit ItemLookUpEdit部门;
        private DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit ItemLookUpEdit客户状态;
        private DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit ItemLookUpEdit区域;
        private DevExpress.XtraGrid.Columns.GridColumn gridCol业务员;
        private DevExpress.XtraGrid.Columns.GridColumn gridCol部门;
        private DevExpress.XtraGrid.Columns.GridColumn gridCol客户名称;
        private DevExpress.XtraGrid.Columns.GridColumn gridCol联系人;
        private DevExpress.XtraGrid.Columns.GridColumn gridCol联系电话;
        private DevExpress.XtraGrid.Columns.GridColumn gridCol地址;
        private DevExpress.XtraGrid.Columns.GridColumn gridCol状态;
        private DevExpress.XtraGrid.Columns.GridColumn gridCol报备时间;
        private System.Windows.Forms.TextBox textBox1;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem1;
        private DevExpress.XtraLayout.EmptySpaceItem emptySpaceItem1;
    }
}