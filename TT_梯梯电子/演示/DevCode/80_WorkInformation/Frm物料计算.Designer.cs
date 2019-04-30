namespace WorkInformation
{
    partial class Frm物料计算
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
            this.gridControl1 = new DevExpress.XtraGrid.GridControl();
            this.gridView1 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.gridCol子件编码 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridCol仓库现存量 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridCol使用数量1 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridCol使用数量2 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridCol使用数量3 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridCol母件编码 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridCol外销订单号 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.ItemLookUpEdit设备 = new DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit();
            this.btn刷新 = new System.Windows.Forms.Button();
            this.btn关闭 = new System.Windows.Forms.Button();
            this.btn导出 = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ItemLookUpEdit设备)).BeginInit();
            this.SuspendLayout();
            // 
            // gridControl1
            // 
            this.gridControl1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.gridControl1.Location = new System.Drawing.Point(12, 12);
            this.gridControl1.MainView = this.gridView1;
            this.gridControl1.Name = "gridControl1";
            this.gridControl1.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.ItemLookUpEdit设备});
            this.gridControl1.Size = new System.Drawing.Size(737, 285);
            this.gridControl1.TabIndex = 9;
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
            this.gridCol子件编码,
            this.gridCol仓库现存量,
            this.gridCol使用数量1,
            this.gridCol使用数量2,
            this.gridCol使用数量3,
            this.gridCol母件编码,
            this.gridCol外销订单号});
            this.gridView1.GridControl = this.gridControl1;
            this.gridView1.IndicatorWidth = 40;
            this.gridView1.Name = "gridView1";
            this.gridView1.OptionsBehavior.Editable = false;
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
            this.gridView1.RowCellStyle += new DevExpress.XtraGrid.Views.Grid.RowCellStyleEventHandler(this.gridView1_RowCellStyle);
            // 
            // gridCol子件编码
            // 
            this.gridCol子件编码.Caption = "子件编码";
            this.gridCol子件编码.FieldName = "子件编码";
            this.gridCol子件编码.Name = "gridCol子件编码";
            this.gridCol子件编码.OptionsColumn.AllowEdit = false;
            this.gridCol子件编码.Visible = true;
            this.gridCol子件编码.VisibleIndex = 0;
            this.gridCol子件编码.Width = 169;
            // 
            // gridCol仓库现存量
            // 
            this.gridCol仓库现存量.Caption = "仓库现存量";
            this.gridCol仓库现存量.FieldName = "仓库现存量";
            this.gridCol仓库现存量.Name = "gridCol仓库现存量";
            this.gridCol仓库现存量.OptionsColumn.AllowEdit = false;
            this.gridCol仓库现存量.Visible = true;
            this.gridCol仓库现存量.VisibleIndex = 1;
            this.gridCol仓库现存量.Width = 173;
            // 
            // gridCol使用数量1
            // 
            this.gridCol使用数量1.Caption = "使用数量1";
            this.gridCol使用数量1.FieldName = "使用数量1";
            this.gridCol使用数量1.Name = "gridCol使用数量1";
            this.gridCol使用数量1.OptionsColumn.AllowEdit = false;
            this.gridCol使用数量1.Visible = true;
            this.gridCol使用数量1.VisibleIndex = 2;
            this.gridCol使用数量1.Width = 142;
            // 
            // gridCol使用数量2
            // 
            this.gridCol使用数量2.Caption = "使用数量2";
            this.gridCol使用数量2.FieldName = "使用数量2";
            this.gridCol使用数量2.Name = "gridCol使用数量2";
            this.gridCol使用数量2.OptionsColumn.AllowEdit = false;
            this.gridCol使用数量2.Visible = true;
            this.gridCol使用数量2.VisibleIndex = 3;
            this.gridCol使用数量2.Width = 125;
            // 
            // gridCol使用数量3
            // 
            this.gridCol使用数量3.Caption = "使用数量3";
            this.gridCol使用数量3.FieldName = "使用数量3";
            this.gridCol使用数量3.Name = "gridCol使用数量3";
            this.gridCol使用数量3.OptionsColumn.AllowEdit = false;
            this.gridCol使用数量3.Visible = true;
            this.gridCol使用数量3.VisibleIndex = 4;
            this.gridCol使用数量3.Width = 113;
            // 
            // gridCol母件编码
            // 
            this.gridCol母件编码.Caption = "相关母件";
            this.gridCol母件编码.FieldName = "母件编码";
            this.gridCol母件编码.Name = "gridCol母件编码";
            this.gridCol母件编码.OptionsColumn.AllowEdit = false;
            this.gridCol母件编码.Visible = true;
            this.gridCol母件编码.VisibleIndex = 6;
            this.gridCol母件编码.Width = 363;
            // 
            // gridCol外销订单号
            // 
            this.gridCol外销订单号.Caption = "外销订单号";
            this.gridCol外销订单号.FieldName = "外销订单号";
            this.gridCol外销订单号.Name = "gridCol外销订单号";
            this.gridCol外销订单号.OptionsColumn.AllowEdit = false;
            this.gridCol外销订单号.Visible = true;
            this.gridCol外销订单号.VisibleIndex = 5;
            this.gridCol外销订单号.Width = 220;
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
            // btn刷新
            // 
            this.btn刷新.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btn刷新.Location = new System.Drawing.Point(563, 319);
            this.btn刷新.Name = "btn刷新";
            this.btn刷新.Size = new System.Drawing.Size(75, 23);
            this.btn刷新.TabIndex = 10;
            this.btn刷新.Text = "刷 新";
            this.btn刷新.UseVisualStyleBackColor = true;
            this.btn刷新.Click += new System.EventHandler(this.btn刷新_Click);
            // 
            // btn关闭
            // 
            this.btn关闭.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btn关闭.Location = new System.Drawing.Point(658, 319);
            this.btn关闭.Name = "btn关闭";
            this.btn关闭.Size = new System.Drawing.Size(75, 23);
            this.btn关闭.TabIndex = 10;
            this.btn关闭.Text = "关 闭";
            this.btn关闭.UseVisualStyleBackColor = true;
            this.btn关闭.Click += new System.EventHandler(this.btn关闭_Click);
            // 
            // btn导出
            // 
            this.btn导出.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btn导出.Location = new System.Drawing.Point(466, 319);
            this.btn导出.Name = "btn导出";
            this.btn导出.Size = new System.Drawing.Size(75, 23);
            this.btn导出.TabIndex = 11;
            this.btn导出.Text = "导 出";
            this.btn导出.UseVisualStyleBackColor = true;
            this.btn导出.Click += new System.EventHandler(this.btn导出_Click);
            // 
            // Frm物料计算
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(761, 354);
            this.Controls.Add(this.btn导出);
            this.Controls.Add(this.btn关闭);
            this.Controls.Add(this.btn刷新);
            this.Controls.Add(this.gridControl1);
            this.Name = "Frm物料计算";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "物料计算";
            this.Load += new System.EventHandler(this.Frm物料计算_Load);
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ItemLookUpEdit设备)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraGrid.GridControl gridControl1;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView1;
        private DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit ItemLookUpEdit设备;
        private System.Windows.Forms.Button btn刷新;
        private System.Windows.Forms.Button btn关闭;
        private DevExpress.XtraGrid.Columns.GridColumn gridCol子件编码;
        private DevExpress.XtraGrid.Columns.GridColumn gridCol仓库现存量;
        private DevExpress.XtraGrid.Columns.GridColumn gridCol使用数量1;
        private DevExpress.XtraGrid.Columns.GridColumn gridCol使用数量2;
        private DevExpress.XtraGrid.Columns.GridColumn gridCol使用数量3;
        private DevExpress.XtraGrid.Columns.GridColumn gridCol母件编码;
        private DevExpress.XtraGrid.Columns.GridColumn gridCol外销订单号;
        private System.Windows.Forms.Button btn导出;

    }
}