namespace clsU8
{
    partial class Frm采购入库单检验
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
            this.gridCol序号 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridCol表体序号 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridCol行号 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridCol存货编码 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridCol存货名称 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridCol规格型号 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridCol数量 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridCol结论 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.ItemRadioGroup1 = new DevExpress.XtraEditors.Repository.RepositoryItemRadioGroup();
            this.gridCol检验描述 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.btn取消 = new System.Windows.Forms.Button();
            this.btnSave = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ItemRadioGroup1)).BeginInit();
            this.SuspendLayout();
            // 
            // gridControl1
            // 
            this.gridControl1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.gridControl1.Location = new System.Drawing.Point(12, 2);
            this.gridControl1.MainView = this.gridView1;
            this.gridControl1.Name = "gridControl1";
            this.gridControl1.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.ItemRadioGroup1});
            this.gridControl1.Size = new System.Drawing.Size(761, 347);
            this.gridControl1.TabIndex = 0;
            this.gridControl1.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView1});
            // 
            // gridView1
            // 
            this.gridView1.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.gridCol序号,
            this.gridCol表体序号,
            this.gridCol行号,
            this.gridCol存货编码,
            this.gridCol存货名称,
            this.gridCol规格型号,
            this.gridCol数量,
            this.gridCol结论,
            this.gridCol检验描述});
            this.gridView1.GridControl = this.gridControl1;
            this.gridView1.Name = "gridView1";
            this.gridView1.OptionsSelection.MultiSelectMode = DevExpress.XtraGrid.Views.Grid.GridMultiSelectMode.CellSelect;
            this.gridView1.OptionsView.ColumnAutoWidth = false;
            this.gridView1.OptionsView.ShowGroupPanel = false;
            this.gridView1.RowHeight = 50;
            // 
            // gridCol序号
            // 
            this.gridCol序号.Caption = "序号";
            this.gridCol序号.FieldName = "ID";
            this.gridCol序号.Name = "gridCol序号";
            this.gridCol序号.OptionsColumn.AllowEdit = false;
            // 
            // gridCol表体序号
            // 
            this.gridCol表体序号.Caption = "表体序号";
            this.gridCol表体序号.FieldName = "AutoID";
            this.gridCol表体序号.Name = "gridCol表体序号";
            this.gridCol表体序号.OptionsColumn.AllowEdit = false;
            // 
            // gridCol行号
            // 
            this.gridCol行号.Caption = "行号";
            this.gridCol行号.FieldName = "irowno";
            this.gridCol行号.Name = "gridCol行号";
            this.gridCol行号.OptionsColumn.AllowEdit = false;
            this.gridCol行号.Visible = true;
            this.gridCol行号.VisibleIndex = 0;
            // 
            // gridCol存货编码
            // 
            this.gridCol存货编码.Caption = "存货编码";
            this.gridCol存货编码.FieldName = "cInvCode";
            this.gridCol存货编码.Name = "gridCol存货编码";
            this.gridCol存货编码.OptionsColumn.AllowEdit = false;
            this.gridCol存货编码.Visible = true;
            this.gridCol存货编码.VisibleIndex = 1;
            // 
            // gridCol存货名称
            // 
            this.gridCol存货名称.Caption = "存货名称";
            this.gridCol存货名称.FieldName = "cInvName";
            this.gridCol存货名称.Name = "gridCol存货名称";
            this.gridCol存货名称.OptionsColumn.AllowEdit = false;
            this.gridCol存货名称.Visible = true;
            this.gridCol存货名称.VisibleIndex = 2;
            // 
            // gridCol规格型号
            // 
            this.gridCol规格型号.Caption = "规格型号";
            this.gridCol规格型号.FieldName = "cInvStd";
            this.gridCol规格型号.Name = "gridCol规格型号";
            this.gridCol规格型号.OptionsColumn.AllowEdit = false;
            this.gridCol规格型号.Visible = true;
            this.gridCol规格型号.VisibleIndex = 3;
            // 
            // gridCol数量
            // 
            this.gridCol数量.Caption = "数量";
            this.gridCol数量.FieldName = "iQuantity";
            this.gridCol数量.Name = "gridCol数量";
            this.gridCol数量.OptionsColumn.AllowEdit = false;
            this.gridCol数量.Visible = true;
            this.gridCol数量.VisibleIndex = 4;
            // 
            // gridCol结论
            // 
            this.gridCol结论.Caption = "结论";
            this.gridCol结论.ColumnEdit = this.ItemRadioGroup1;
            this.gridCol结论.FieldName = "Conclusion";
            this.gridCol结论.Name = "gridCol结论";
            this.gridCol结论.Visible = true;
            this.gridCol结论.VisibleIndex = 5;
            this.gridCol结论.Width = 70;
            // 
            // ItemRadioGroup1
            // 
            this.ItemRadioGroup1.Columns = 1;
            this.ItemRadioGroup1.Items.AddRange(new DevExpress.XtraEditors.Controls.RadioGroupItem[] {
            new DevExpress.XtraEditors.Controls.RadioGroupItem("1", "待检"),
            new DevExpress.XtraEditors.Controls.RadioGroupItem("2", "合格"),
            new DevExpress.XtraEditors.Controls.RadioGroupItem("3", "不合格")});
            this.ItemRadioGroup1.Name = "ItemRadioGroup1";
            this.ItemRadioGroup1.NullText = "1";
            // 
            // gridCol检验描述
            // 
            this.gridCol检验描述.Caption = "检验描述";
            this.gridCol检验描述.FieldName = "Remark";
            this.gridCol检验描述.Name = "gridCol检验描述";
            this.gridCol检验描述.Visible = true;
            this.gridCol检验描述.VisibleIndex = 6;
            // 
            // btn取消
            // 
            this.btn取消.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btn取消.Location = new System.Drawing.Point(698, 355);
            this.btn取消.Name = "btn取消";
            this.btn取消.Size = new System.Drawing.Size(75, 23);
            this.btn取消.TabIndex = 32;
            this.btn取消.Text = "关 闭";
            this.btn取消.UseVisualStyleBackColor = true;
            this.btn取消.Click += new System.EventHandler(this.btn取消_Click);
            // 
            // btnSave
            // 
            this.btnSave.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSave.Location = new System.Drawing.Point(591, 355);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(75, 23);
            this.btnSave.TabIndex = 34;
            this.btnSave.Text = "保 存";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // Frm采购入库单检验
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.ClientSize = new System.Drawing.Size(785, 390);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.btn取消);
            this.Controls.Add(this.gridControl1);
            this.Name = "Frm采购入库单检验";
            this.Text = "采购入库单检验";
            this.Load += new System.EventHandler(this.Frm采购入库单检验_Load);
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ItemRadioGroup1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraGrid.GridControl gridControl1;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView1;
        private System.Windows.Forms.Button btn取消;
        private DevExpress.XtraGrid.Columns.GridColumn gridCol存货编码;
        private DevExpress.XtraGrid.Columns.GridColumn gridCol规格型号;
        private System.Windows.Forms.Button btnSave;
        private DevExpress.XtraGrid.Columns.GridColumn gridCol存货名称;
        private DevExpress.XtraEditors.Repository.RepositoryItemRadioGroup ItemRadioGroup1;
        private DevExpress.XtraGrid.Columns.GridColumn gridCol表体序号;
        private DevExpress.XtraGrid.Columns.GridColumn gridCol行号;
        private DevExpress.XtraGrid.Columns.GridColumn gridCol数量;
        private DevExpress.XtraGrid.Columns.GridColumn gridCol序号;
        private DevExpress.XtraGrid.Columns.GridColumn gridCol结论;
        private DevExpress.XtraGrid.Columns.GridColumn gridCol检验描述;
    }
}