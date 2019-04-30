namespace clsU8
{
    partial class Frm包装袋自动出库
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
            this.gridColcInvCode = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColcInvName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColcInvStd = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColcInvCode2 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColcInvName2 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColcInvStd2 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColQty = new DevExpress.XtraGrid.Columns.GridColumn();
            this.ItemTextEditn0 = new DevExpress.XtraEditors.Repository.RepositoryItemTextEdit();
            this.gridColCurrQty = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColcPOID = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColID = new DevExpress.XtraGrid.Columns.GridColumn();
            this.ItemRadioGroup1 = new DevExpress.XtraEditors.Repository.RepositoryItemRadioGroup();
            this.btn取消 = new System.Windows.Forms.Button();
            this.btnSave = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.dateEdit1 = new DevExpress.XtraEditors.DateEdit();
            this.label2 = new System.Windows.Forms.Label();
            this.lookUpEditWarehouse = new DevExpress.XtraEditors.LookUpEdit();
            this.lookUpEditOutType = new DevExpress.XtraEditors.LookUpEdit();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ItemTextEditn0)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ItemRadioGroup1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dateEdit1.Properties.VistaTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dateEdit1.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lookUpEditWarehouse.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lookUpEditOutType.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // gridControl1
            // 
            this.gridControl1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.gridControl1.Location = new System.Drawing.Point(-3, 42);
            this.gridControl1.MainView = this.gridView1;
            this.gridControl1.Name = "gridControl1";
            this.gridControl1.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.ItemRadioGroup1,
            this.ItemTextEditn0});
            this.gridControl1.Size = new System.Drawing.Size(904, 342);
            this.gridControl1.TabIndex = 0;
            this.gridControl1.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView1});
            // 
            // gridView1
            // 
            this.gridView1.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.gridColcInvCode,
            this.gridColcInvName,
            this.gridColcInvStd,
            this.gridColcInvCode2,
            this.gridColcInvName2,
            this.gridColcInvStd2,
            this.gridColQty,
            this.gridColCurrQty,
            this.gridColcPOID,
            this.gridColID});
            this.gridView1.GridControl = this.gridControl1;
            this.gridView1.Name = "gridView1";
            this.gridView1.OptionsSelection.MultiSelectMode = DevExpress.XtraGrid.Views.Grid.GridMultiSelectMode.CellSelect;
            this.gridView1.OptionsView.ColumnAutoWidth = false;
            this.gridView1.OptionsView.ShowFooter = true;
            this.gridView1.OptionsView.ShowGroupPanel = false;
            this.gridView1.RowHeight = 50;
            // 
            // gridColcInvCode
            // 
            this.gridColcInvCode.Caption = "Item Code(Purchase)";
            this.gridColcInvCode.FieldName = "cInvCode";
            this.gridColcInvCode.Name = "gridColcInvCode";
            this.gridColcInvCode.OptionsColumn.AllowEdit = false;
            this.gridColcInvCode.Visible = true;
            this.gridColcInvCode.VisibleIndex = 4;
            this.gridColcInvCode.Width = 201;
            // 
            // gridColcInvName
            // 
            this.gridColcInvName.Caption = "Description(Purchase)";
            this.gridColcInvName.FieldName = "cInvName";
            this.gridColcInvName.Name = "gridColcInvName";
            this.gridColcInvName.OptionsColumn.AllowEdit = false;
            this.gridColcInvName.Visible = true;
            this.gridColcInvName.VisibleIndex = 5;
            this.gridColcInvName.Width = 180;
            // 
            // gridColcInvStd
            // 
            this.gridColcInvStd.Caption = "cInvStd";
            this.gridColcInvStd.FieldName = "cInvStd";
            this.gridColcInvStd.Name = "gridColcInvStd";
            this.gridColcInvStd.OptionsColumn.AllowEdit = false;
            this.gridColcInvStd.Width = 153;
            // 
            // gridColcInvCode2
            // 
            this.gridColcInvCode2.Caption = "Item Code";
            this.gridColcInvCode2.FieldName = "cInvCode2";
            this.gridColcInvCode2.Name = "gridColcInvCode2";
            this.gridColcInvCode2.OptionsColumn.AllowEdit = false;
            this.gridColcInvCode2.Visible = true;
            this.gridColcInvCode2.VisibleIndex = 0;
            this.gridColcInvCode2.Width = 130;
            // 
            // gridColcInvName2
            // 
            this.gridColcInvName2.Caption = "Description";
            this.gridColcInvName2.FieldName = "cInvName2";
            this.gridColcInvName2.Name = "gridColcInvName2";
            this.gridColcInvName2.OptionsColumn.AllowEdit = false;
            this.gridColcInvName2.Visible = true;
            this.gridColcInvName2.VisibleIndex = 1;
            this.gridColcInvName2.Width = 188;
            // 
            // gridColcInvStd2
            // 
            this.gridColcInvStd2.Caption = "cInvStd2";
            this.gridColcInvStd2.FieldName = "cInvStd2";
            this.gridColcInvStd2.Name = "gridColcInvStd2";
            this.gridColcInvStd2.OptionsColumn.AllowEdit = false;
            this.gridColcInvStd2.Width = 146;
            // 
            // gridColQty
            // 
            this.gridColQty.Caption = "Qty";
            this.gridColQty.ColumnEdit = this.ItemTextEditn0;
            this.gridColQty.FieldName = "Qty";
            this.gridColQty.Name = "gridColQty";
            this.gridColQty.OptionsColumn.AllowEdit = false;
            this.gridColQty.Summary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] {
            new DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum)});
            this.gridColQty.Visible = true;
            this.gridColQty.VisibleIndex = 2;
            this.gridColQty.Width = 185;
            // 
            // ItemTextEditn0
            // 
            this.ItemTextEditn0.AutoHeight = false;
            this.ItemTextEditn0.DisplayFormat.FormatString = "n0";
            this.ItemTextEditn0.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.ItemTextEditn0.EditFormat.FormatString = "n0";
            this.ItemTextEditn0.EditFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.ItemTextEditn0.Mask.EditMask = "n0";
            this.ItemTextEditn0.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Numeric;
            this.ItemTextEditn0.Name = "ItemTextEditn0";
            // 
            // gridColCurrQty
            // 
            this.gridColCurrQty.Caption = "CurrQty";
            this.gridColCurrQty.ColumnEdit = this.ItemTextEditn0;
            this.gridColCurrQty.FieldName = "CurrQty";
            this.gridColCurrQty.Name = "gridColCurrQty";
            this.gridColCurrQty.OptionsColumn.AllowEdit = false;
            this.gridColCurrQty.Summary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] {
            new DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum)});
            this.gridColCurrQty.Visible = true;
            this.gridColCurrQty.VisibleIndex = 3;
            this.gridColCurrQty.Width = 181;
            // 
            // gridColcPOID
            // 
            this.gridColcPOID.Caption = "cPOID";
            this.gridColcPOID.FieldName = "cPOID";
            this.gridColcPOID.Name = "gridColcPOID";
            this.gridColcPOID.OptionsColumn.AllowEdit = false;
            // 
            // gridColID
            // 
            this.gridColID.Caption = "ID";
            this.gridColID.FieldName = "ID";
            this.gridColID.Name = "gridColID";
            this.gridColID.OptionsColumn.AllowEdit = false;
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
            // btn取消
            // 
            this.btn取消.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btn取消.Location = new System.Drawing.Point(804, 392);
            this.btn取消.Name = "btn取消";
            this.btn取消.Size = new System.Drawing.Size(75, 23);
            this.btn取消.TabIndex = 32;
            this.btn取消.Text = "Cancel";
            this.btn取消.UseVisualStyleBackColor = true;
            this.btn取消.Click += new System.EventHandler(this.btn取消_Click);
            // 
            // btnSave
            // 
            this.btnSave.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSave.Location = new System.Drawing.Point(706, 390);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(75, 23);
            this.btnSave.TabIndex = 34;
            this.btnSave.Text = "Save";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(13, 10);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(39, 15);
            this.label1.TabIndex = 35;
            this.label1.Text = "Date";
            // 
            // dateEdit1
            // 
            this.dateEdit1.EditValue = null;
            this.dateEdit1.Location = new System.Drawing.Point(82, 6);
            this.dateEdit1.Name = "dateEdit1";
            this.dateEdit1.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.dateEdit1.Properties.VistaTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
            this.dateEdit1.Size = new System.Drawing.Size(106, 20);
            this.dateEdit1.TabIndex = 36;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(209, 10);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(79, 15);
            this.label2.TabIndex = 37;
            this.label2.Text = "Warehouse";
            // 
            // lookUpEditWarehouse
            // 
            this.lookUpEditWarehouse.Location = new System.Drawing.Point(274, 6);
            this.lookUpEditWarehouse.Name = "lookUpEditWarehouse";
            this.lookUpEditWarehouse.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.lookUpEditWarehouse.Properties.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("cWhCode", "仓库编码"),
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("cWhName", "仓库")});
            this.lookUpEditWarehouse.Properties.DisplayMember = "cWhName";
            this.lookUpEditWarehouse.Properties.NullText = "";
            this.lookUpEditWarehouse.Properties.ValueMember = "cWhCode";
            this.lookUpEditWarehouse.Size = new System.Drawing.Size(171, 20);
            this.lookUpEditWarehouse.TabIndex = 38;
            // 
            // lookUpEditOutType
            // 
            this.lookUpEditOutType.Location = new System.Drawing.Point(598, 6);
            this.lookUpEditOutType.Name = "lookUpEditOutType";
            this.lookUpEditOutType.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.lookUpEditOutType.Properties.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("cRdCode", "编码"),
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("cRdName", "类别")});
            this.lookUpEditOutType.Properties.DisplayMember = "cRdName";
            this.lookUpEditOutType.Properties.NullText = "";
            this.lookUpEditOutType.Properties.ValueMember = "cRdCode";
            this.lookUpEditOutType.Size = new System.Drawing.Size(166, 20);
            this.lookUpEditOutType.TabIndex = 40;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(455, 10);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(183, 15);
            this.label3.TabIndex = 39;
            this.label3.Text = "Inventory Out Category";
            // 
            // label4
            // 
            this.label4.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(25, 402);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(55, 15);
            this.label4.TabIndex = 41;
            this.label4.Text = "label4";
            // 
            // Frm包装袋自动出库
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.ClientSize = new System.Drawing.Size(900, 426);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.lookUpEditOutType);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.lookUpEditWarehouse);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.dateEdit1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.btn取消);
            this.Controls.Add(this.gridControl1);
            this.Name = "Frm包装袋自动出库";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Packing bag out of warehouse";
            this.Load += new System.EventHandler(this.Frm包装袋自动出库_Load);
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ItemTextEditn0)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ItemRadioGroup1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dateEdit1.Properties.VistaTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dateEdit1.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lookUpEditWarehouse.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lookUpEditOutType.Properties)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraGrid.GridControl gridControl1;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView1;
        private System.Windows.Forms.Button btn取消;
        private System.Windows.Forms.Button btnSave;
        private DevExpress.XtraEditors.Repository.RepositoryItemRadioGroup ItemRadioGroup1;
        private DevExpress.XtraGrid.Columns.GridColumn gridColcInvCode;
        private DevExpress.XtraGrid.Columns.GridColumn gridColcInvName;
        private DevExpress.XtraGrid.Columns.GridColumn gridColcInvStd;
        private DevExpress.XtraGrid.Columns.GridColumn gridColcInvCode2;
        private DevExpress.XtraGrid.Columns.GridColumn gridColcInvName2;
        private DevExpress.XtraGrid.Columns.GridColumn gridColcInvStd2;
        private DevExpress.XtraGrid.Columns.GridColumn gridColQty;
        private DevExpress.XtraGrid.Columns.GridColumn gridColCurrQty;
        private System.Windows.Forms.Label label1;
        private DevExpress.XtraEditors.DateEdit dateEdit1;
        private System.Windows.Forms.Label label2;
        private DevExpress.XtraEditors.LookUpEdit lookUpEditWarehouse;
        private DevExpress.XtraEditors.LookUpEdit lookUpEditOutType;
        private System.Windows.Forms.Label label3;
        private DevExpress.XtraGrid.Columns.GridColumn gridColcPOID;
        private DevExpress.XtraGrid.Columns.GridColumn gridColID;
        private DevExpress.XtraEditors.Repository.RepositoryItemTextEdit ItemTextEditn0;
        private System.Windows.Forms.Label label4;
    }
}