namespace Warehouse
{
    partial class FrmDealBackBill
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
            this.grdDetail = new DevExpress.XtraGrid.GridControl();
            this.grvDetail = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colBillId = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colMoCode = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn9 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn8 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColcInvCode = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColcInvName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColcInvStd = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn1 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn2 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn3 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn4 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn5 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colBackQty = new DevExpress.XtraGrid.Columns.GridColumn();
            this.LookUpWH = new DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit();
            this.txtBarCode = new System.Windows.Forms.TextBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label2 = new System.Windows.Forms.Label();
            this.colWhHouse = new DevExpress.XtraGrid.Columns.GridColumn();
            ((System.ComponentModel.ISupportInitialize)(this.grdDetail)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grvDetail)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.LookUpWH)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // childLF
            // 
            this.childLF.LookAndFeel.Style = DevExpress.LookAndFeel.LookAndFeelStyle.Skin;
            this.childLF.LookAndFeel.UseWindowsXPTheme = false;
            // 
            // grdDetail
            // 
            this.grdDetail.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.grdDetail.EmbeddedNavigator.Name = "";
            this.grdDetail.Location = new System.Drawing.Point(10, 98);
            this.grdDetail.MainView = this.grvDetail;
            this.grdDetail.Name = "grdDetail";
            this.grdDetail.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.LookUpWH});
            this.grdDetail.Size = new System.Drawing.Size(884, 380);
            this.grdDetail.TabIndex = 14;
            this.grdDetail.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.grvDetail});
            // 
            // grvDetail
            // 
            this.grvDetail.Appearance.ColumnFilterButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(202)))), ((int)(((byte)(221)))), ((int)(((byte)(208)))));
            this.grvDetail.Appearance.ColumnFilterButton.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(202)))), ((int)(((byte)(221)))), ((int)(((byte)(208)))));
            this.grvDetail.Appearance.ColumnFilterButton.ForeColor = System.Drawing.Color.Black;
            this.grvDetail.Appearance.ColumnFilterButton.Options.UseBackColor = true;
            this.grvDetail.Appearance.ColumnFilterButton.Options.UseBorderColor = true;
            this.grvDetail.Appearance.ColumnFilterButton.Options.UseForeColor = true;
            this.grvDetail.Appearance.ColumnFilterButtonActive.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(211)))), ((int)(((byte)(226)))), ((int)(((byte)(216)))));
            this.grvDetail.Appearance.ColumnFilterButtonActive.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(211)))), ((int)(((byte)(226)))), ((int)(((byte)(216)))));
            this.grvDetail.Appearance.ColumnFilterButtonActive.ForeColor = System.Drawing.Color.Black;
            this.grvDetail.Appearance.ColumnFilterButtonActive.Options.UseBackColor = true;
            this.grvDetail.Appearance.ColumnFilterButtonActive.Options.UseBorderColor = true;
            this.grvDetail.Appearance.ColumnFilterButtonActive.Options.UseForeColor = true;
            this.grvDetail.Appearance.Empty.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(242)))), ((int)(((byte)(244)))), ((int)(((byte)(236)))));
            this.grvDetail.Appearance.Empty.BackColor2 = System.Drawing.Color.White;
            this.grvDetail.Appearance.Empty.Options.UseBackColor = true;
            this.grvDetail.Appearance.EvenRow.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(221)))), ((int)(((byte)(227)))), ((int)(((byte)(245)))));
            this.grvDetail.Appearance.EvenRow.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(221)))), ((int)(((byte)(227)))), ((int)(((byte)(245)))));
            this.grvDetail.Appearance.EvenRow.ForeColor = System.Drawing.Color.Black;
            this.grvDetail.Appearance.EvenRow.Options.UseBackColor = true;
            this.grvDetail.Appearance.EvenRow.Options.UseBorderColor = true;
            this.grvDetail.Appearance.EvenRow.Options.UseForeColor = true;
            this.grvDetail.Appearance.FilterCloseButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(202)))), ((int)(((byte)(221)))), ((int)(((byte)(208)))));
            this.grvDetail.Appearance.FilterCloseButton.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(202)))), ((int)(((byte)(221)))), ((int)(((byte)(208)))));
            this.grvDetail.Appearance.FilterCloseButton.ForeColor = System.Drawing.Color.Black;
            this.grvDetail.Appearance.FilterCloseButton.Options.UseBackColor = true;
            this.grvDetail.Appearance.FilterCloseButton.Options.UseBorderColor = true;
            this.grvDetail.Appearance.FilterCloseButton.Options.UseForeColor = true;
            this.grvDetail.Appearance.FilterPanel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(242)))), ((int)(((byte)(244)))), ((int)(((byte)(236)))));
            this.grvDetail.Appearance.FilterPanel.BackColor2 = System.Drawing.Color.White;
            this.grvDetail.Appearance.FilterPanel.ForeColor = System.Drawing.Color.Black;
            this.grvDetail.Appearance.FilterPanel.Options.UseBackColor = true;
            this.grvDetail.Appearance.FilterPanel.Options.UseForeColor = true;
            this.grvDetail.Appearance.FixedLine.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(117)))), ((int)(((byte)(136)))), ((int)(((byte)(122)))));
            this.grvDetail.Appearance.FixedLine.Options.UseBackColor = true;
            this.grvDetail.Appearance.FocusedCell.BackColor = System.Drawing.Color.White;
            this.grvDetail.Appearance.FocusedCell.ForeColor = System.Drawing.Color.Black;
            this.grvDetail.Appearance.FocusedCell.Options.UseBackColor = true;
            this.grvDetail.Appearance.FocusedCell.Options.UseForeColor = true;
            this.grvDetail.Appearance.FocusedRow.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(129)))), ((int)(((byte)(171)))), ((int)(((byte)(177)))));
            this.grvDetail.Appearance.FocusedRow.ForeColor = System.Drawing.Color.White;
            this.grvDetail.Appearance.FocusedRow.Options.UseBackColor = true;
            this.grvDetail.Appearance.FocusedRow.Options.UseForeColor = true;
            this.grvDetail.Appearance.FooterPanel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(202)))), ((int)(((byte)(221)))), ((int)(((byte)(208)))));
            this.grvDetail.Appearance.FooterPanel.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(202)))), ((int)(((byte)(221)))), ((int)(((byte)(208)))));
            this.grvDetail.Appearance.FooterPanel.ForeColor = System.Drawing.Color.Black;
            this.grvDetail.Appearance.FooterPanel.Options.UseBackColor = true;
            this.grvDetail.Appearance.FooterPanel.Options.UseBorderColor = true;
            this.grvDetail.Appearance.FooterPanel.Options.UseForeColor = true;
            this.grvDetail.Appearance.GroupButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(178)))), ((int)(((byte)(209)))), ((int)(((byte)(188)))));
            this.grvDetail.Appearance.GroupButton.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(178)))), ((int)(((byte)(209)))), ((int)(((byte)(188)))));
            this.grvDetail.Appearance.GroupButton.Options.UseBackColor = true;
            this.grvDetail.Appearance.GroupButton.Options.UseBorderColor = true;
            this.grvDetail.Appearance.GroupFooter.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(215)))), ((int)(((byte)(234)))), ((int)(((byte)(221)))));
            this.grvDetail.Appearance.GroupFooter.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(215)))), ((int)(((byte)(234)))), ((int)(((byte)(221)))));
            this.grvDetail.Appearance.GroupFooter.ForeColor = System.Drawing.Color.Black;
            this.grvDetail.Appearance.GroupFooter.Options.UseBackColor = true;
            this.grvDetail.Appearance.GroupFooter.Options.UseBorderColor = true;
            this.grvDetail.Appearance.GroupFooter.Options.UseForeColor = true;
            this.grvDetail.Appearance.GroupPanel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(242)))), ((int)(((byte)(244)))), ((int)(((byte)(236)))));
            this.grvDetail.Appearance.GroupPanel.BackColor2 = System.Drawing.Color.White;
            this.grvDetail.Appearance.GroupPanel.ForeColor = System.Drawing.Color.Black;
            this.grvDetail.Appearance.GroupPanel.Options.UseBackColor = true;
            this.grvDetail.Appearance.GroupPanel.Options.UseForeColor = true;
            this.grvDetail.Appearance.GroupRow.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(215)))), ((int)(((byte)(234)))), ((int)(((byte)(221)))));
            this.grvDetail.Appearance.GroupRow.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(215)))), ((int)(((byte)(234)))), ((int)(((byte)(221)))));
            this.grvDetail.Appearance.GroupRow.ForeColor = System.Drawing.Color.Black;
            this.grvDetail.Appearance.GroupRow.Options.UseBackColor = true;
            this.grvDetail.Appearance.GroupRow.Options.UseBorderColor = true;
            this.grvDetail.Appearance.GroupRow.Options.UseForeColor = true;
            this.grvDetail.Appearance.HeaderPanel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(211)))), ((int)(((byte)(226)))), ((int)(((byte)(216)))));
            this.grvDetail.Appearance.HeaderPanel.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(211)))), ((int)(((byte)(226)))), ((int)(((byte)(216)))));
            this.grvDetail.Appearance.HeaderPanel.ForeColor = System.Drawing.Color.Black;
            this.grvDetail.Appearance.HeaderPanel.Options.UseBackColor = true;
            this.grvDetail.Appearance.HeaderPanel.Options.UseBorderColor = true;
            this.grvDetail.Appearance.HeaderPanel.Options.UseForeColor = true;
            this.grvDetail.Appearance.HideSelectionRow.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(186)))), ((int)(((byte)(211)))), ((int)(((byte)(215)))));
            this.grvDetail.Appearance.HideSelectionRow.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(104)))), ((int)(((byte)(130)))), ((int)(((byte)(134)))));
            this.grvDetail.Appearance.HideSelectionRow.Options.UseBackColor = true;
            this.grvDetail.Appearance.HideSelectionRow.Options.UseForeColor = true;
            this.grvDetail.Appearance.HorzLine.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(172)))), ((int)(((byte)(197)))), ((int)(((byte)(180)))));
            this.grvDetail.Appearance.HorzLine.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(117)))), ((int)(((byte)(136)))), ((int)(((byte)(122)))));
            this.grvDetail.Appearance.HorzLine.Options.UseBackColor = true;
            this.grvDetail.Appearance.HorzLine.Options.UseBorderColor = true;
            this.grvDetail.Appearance.OddRow.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(242)))), ((int)(((byte)(244)))), ((int)(((byte)(236)))));
            this.grvDetail.Appearance.OddRow.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(242)))), ((int)(((byte)(244)))), ((int)(((byte)(236)))));
            this.grvDetail.Appearance.OddRow.ForeColor = System.Drawing.Color.Black;
            this.grvDetail.Appearance.OddRow.Options.UseBackColor = true;
            this.grvDetail.Appearance.OddRow.Options.UseBorderColor = true;
            this.grvDetail.Appearance.OddRow.Options.UseForeColor = true;
            this.grvDetail.Appearance.Preview.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(250)))), ((int)(((byte)(250)))), ((int)(((byte)(240)))));
            this.grvDetail.Appearance.Preview.Font = new System.Drawing.Font("Verdana", 7.5F);
            this.grvDetail.Appearance.Preview.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(104)))), ((int)(((byte)(130)))), ((int)(((byte)(134)))));
            this.grvDetail.Appearance.Preview.Options.UseBackColor = true;
            this.grvDetail.Appearance.Preview.Options.UseFont = true;
            this.grvDetail.Appearance.Preview.Options.UseForeColor = true;
            this.grvDetail.Appearance.Row.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(242)))), ((int)(((byte)(244)))), ((int)(((byte)(236)))));
            this.grvDetail.Appearance.Row.ForeColor = System.Drawing.Color.Black;
            this.grvDetail.Appearance.Row.Options.UseBackColor = true;
            this.grvDetail.Appearance.Row.Options.UseForeColor = true;
            this.grvDetail.Appearance.RowSeparator.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(242)))), ((int)(((byte)(244)))), ((int)(((byte)(236)))));
            this.grvDetail.Appearance.RowSeparator.BackColor2 = System.Drawing.Color.White;
            this.grvDetail.Appearance.RowSeparator.Options.UseBackColor = true;
            this.grvDetail.Appearance.SelectedRow.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(159)))), ((int)(((byte)(201)))), ((int)(((byte)(207)))));
            this.grvDetail.Appearance.SelectedRow.ForeColor = System.Drawing.Color.Black;
            this.grvDetail.Appearance.SelectedRow.Options.UseBackColor = true;
            this.grvDetail.Appearance.SelectedRow.Options.UseForeColor = true;
            this.grvDetail.Appearance.TopNewRow.BackColor = System.Drawing.Color.White;
            this.grvDetail.Appearance.TopNewRow.Options.UseBackColor = true;
            this.grvDetail.Appearance.VertLine.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(172)))), ((int)(((byte)(197)))), ((int)(((byte)(180)))));
            this.grvDetail.Appearance.VertLine.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(117)))), ((int)(((byte)(136)))), ((int)(((byte)(122)))));
            this.grvDetail.Appearance.VertLine.Options.UseBackColor = true;
            this.grvDetail.Appearance.VertLine.Options.UseBorderColor = true;
            this.grvDetail.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colBillId,
            this.colMoCode,
            this.gridColumn9,
            this.gridColumn8,
            this.gridColcInvCode,
            this.gridColcInvName,
            this.gridColcInvStd,
            this.gridColumn1,
            this.gridColumn2,
            this.gridColumn3,
            this.gridColumn4,
            this.gridColumn5,
            this.colBackQty,
            this.colWhHouse});
            this.grvDetail.GridControl = this.grdDetail;
            this.grvDetail.IndicatorWidth = 40;
            this.grvDetail.Name = "grvDetail";
            this.grvDetail.OptionsCustomization.AllowFilter = false;
            this.grvDetail.OptionsView.ColumnAutoWidth = false;
            this.grvDetail.OptionsView.EnableAppearanceEvenRow = true;
            this.grvDetail.OptionsView.EnableAppearanceOddRow = true;
            this.grvDetail.OptionsView.ShowFooter = true;
            this.grvDetail.OptionsView.ShowGroupPanel = false;
            this.grvDetail.OptionsView.ShowIndicator = false;
            // 
            // colBillId
            // 
            this.colBillId.Caption = "gridColumn6";
            this.colBillId.FieldName = "BillID";
            this.colBillId.Name = "colBillId";
            // 
            // colMoCode
            // 
            this.colMoCode.Caption = "委外加工单号";
            this.colMoCode.FieldName = "cCode";
            this.colMoCode.Name = "colMoCode";
            this.colMoCode.OptionsColumn.AllowEdit = false;
            this.colMoCode.Visible = true;
            this.colMoCode.VisibleIndex = 0;
            this.colMoCode.Width = 133;
            // 
            // gridColumn9
            // 
            this.gridColumn9.Caption = "供应商名称";
            this.gridColumn9.FieldName = "cVenCode";
            this.gridColumn9.Name = "gridColumn9";
            this.gridColumn9.Visible = true;
            this.gridColumn9.VisibleIndex = 2;
            this.gridColumn9.Width = 119;
            // 
            // gridColumn8
            // 
            this.gridColumn8.Caption = "供应商编码";
            this.gridColumn8.FieldName = "cVenName";
            this.gridColumn8.Name = "gridColumn8";
            this.gridColumn8.Visible = true;
            this.gridColumn8.VisibleIndex = 1;
            this.gridColumn8.Width = 84;
            // 
            // gridColcInvCode
            // 
            this.gridColcInvCode.Caption = "存货编码";
            this.gridColcInvCode.FieldName = "cInvCode";
            this.gridColcInvCode.Name = "gridColcInvCode";
            this.gridColcInvCode.OptionsColumn.AllowEdit = false;
            this.gridColcInvCode.Visible = true;
            this.gridColcInvCode.VisibleIndex = 4;
            this.gridColcInvCode.Width = 98;
            // 
            // gridColcInvName
            // 
            this.gridColcInvName.Caption = "存货名称";
            this.gridColcInvName.FieldName = "cInvName";
            this.gridColcInvName.Name = "gridColcInvName";
            this.gridColcInvName.OptionsColumn.AllowEdit = false;
            this.gridColcInvName.Visible = true;
            this.gridColcInvName.VisibleIndex = 5;
            this.gridColcInvName.Width = 119;
            // 
            // gridColcInvStd
            // 
            this.gridColcInvStd.Caption = "规格型号";
            this.gridColcInvStd.FieldName = "cInvStd";
            this.gridColcInvStd.Name = "gridColcInvStd";
            this.gridColcInvStd.OptionsColumn.AllowEdit = false;
            this.gridColcInvStd.Visible = true;
            this.gridColcInvStd.VisibleIndex = 6;
            this.gridColcInvStd.Width = 83;
            // 
            // gridColumn1
            // 
            this.gridColumn1.Caption = "订单数量";
            this.gridColumn1.FieldName = "iQuantity";
            this.gridColumn1.Name = "gridColumn1";
            this.gridColumn1.OptionsColumn.AllowEdit = false;
            this.gridColumn1.Visible = true;
            this.gridColumn1.VisibleIndex = 7;
            this.gridColumn1.Width = 64;
            // 
            // gridColumn2
            // 
            this.gridColumn2.Caption = "原币含税单价";
            this.gridColumn2.FieldName = "iUnitPrice";
            this.gridColumn2.Name = "gridColumn2";
            this.gridColumn2.OptionsColumn.AllowEdit = false;
            this.gridColumn2.Visible = true;
            this.gridColumn2.VisibleIndex = 9;
            this.gridColumn2.Width = 94;
            // 
            // gridColumn3
            // 
            this.gridColumn3.Caption = "原币金额";
            this.gridColumn3.FieldName = "iMoney";
            this.gridColumn3.Name = "gridColumn3";
            this.gridColumn3.OptionsColumn.AllowEdit = false;
            this.gridColumn3.Visible = true;
            this.gridColumn3.VisibleIndex = 10;
            // 
            // gridColumn4
            // 
            this.gridColumn4.Caption = "计划下达日期";
            this.gridColumn4.FieldName = "dStartDate";
            this.gridColumn4.Name = "gridColumn4";
            this.gridColumn4.OptionsColumn.AllowEdit = false;
            this.gridColumn4.Visible = true;
            this.gridColumn4.VisibleIndex = 11;
            this.gridColumn4.Width = 92;
            // 
            // gridColumn5
            // 
            this.gridColumn5.Caption = "计划到货日期";
            this.gridColumn5.FieldName = "dArriveDate";
            this.gridColumn5.Name = "gridColumn5";
            this.gridColumn5.OptionsColumn.AllowEdit = false;
            this.gridColumn5.Visible = true;
            this.gridColumn5.VisibleIndex = 12;
            this.gridColumn5.Width = 100;
            // 
            // colBackQty
            // 
            this.colBackQty.Caption = "退货数量";
            this.colBackQty.FieldName = "BackQty";
            this.colBackQty.Name = "colBackQty";
            this.colBackQty.Visible = true;
            this.colBackQty.VisibleIndex = 8;
            // 
            // LookUpWH
            // 
            this.LookUpWH.AutoHeight = false;
            this.LookUpWH.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.LookUpWH.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("cWhCode", "仓库编号", 100),
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("cWhName", "仓库名称", 250)});
            this.LookUpWH.DisplayMember = "cWhName";
            this.LookUpWH.Name = "LookUpWH";
            this.LookUpWH.NullText = "";
            this.LookUpWH.PopupWidth = 350;
            this.LookUpWH.ValueMember = "cWhCode";
            // 
            // txtBarCode
            // 
            this.txtBarCode.Location = new System.Drawing.Point(88, 26);
            this.txtBarCode.Name = "txtBarCode";
            this.txtBarCode.Size = new System.Drawing.Size(201, 21);
            this.txtBarCode.TabIndex = 15;
            this.txtBarCode.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtBarCode_KeyPress_1);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.txtBarCode);
            this.groupBox1.Location = new System.Drawing.Point(10, 35);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(670, 57);
            this.groupBox1.TabIndex = 16;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "条形码";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(15, 29);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(67, 14);
            this.label2.TabIndex = 19;
            this.label2.Tag = "退货条形码";
            this.label2.Text = "退货条形码";
            // 
            // colWhHouse
            // 
            this.colWhHouse.Caption = "退回仓库";
            this.colWhHouse.ColumnEdit = this.LookUpWH;
            this.colWhHouse.FieldName = "HouseCode";
            this.colWhHouse.Name = "colWhHouse";
            this.colWhHouse.Visible = true;
            this.colWhHouse.VisibleIndex = 3;
            // 
            // FrmDealBackBill
            // 
            this.Appearance.BackColor = System.Drawing.SystemColors.Control;
            this.Appearance.Options.UseBackColor = true;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(909, 488);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.grdDetail);
            this.Name = "FrmDealBackBill";
            this.Text = "处理退货单";
            this.Load += new System.EventHandler(this.FormDealBackBill_Load);
            this.Controls.SetChildIndex(this.grdDetail, 0);
            this.Controls.SetChildIndex(this.groupBox1, 0);
            ((System.ComponentModel.ISupportInitialize)(this.grdDetail)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grvDetail)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.LookUpWH)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion


        private DevExpress.XtraGrid.GridControl grdDetail;
        private DevExpress.XtraGrid.Views.Grid.GridView grvDetail;
        private DevExpress.XtraGrid.Columns.GridColumn colBillId;
        private DevExpress.XtraGrid.Columns.GridColumn colMoCode;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn9;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn8;
        private DevExpress.XtraGrid.Columns.GridColumn gridColcInvCode;
        private DevExpress.XtraGrid.Columns.GridColumn gridColcInvName;
        private DevExpress.XtraGrid.Columns.GridColumn gridColcInvStd;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn1;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn2;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn3;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn4;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn5;
        private DevExpress.XtraGrid.Columns.GridColumn colBackQty;
        private DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit LookUpWH;
        private System.Windows.Forms.TextBox txtBarCode;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label2;
        private DevExpress.XtraGrid.Columns.GridColumn colWhHouse;
    }
}