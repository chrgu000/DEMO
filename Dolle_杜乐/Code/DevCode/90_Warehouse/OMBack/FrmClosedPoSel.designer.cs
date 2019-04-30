namespace Warehouse
{
    partial class FrmClosedPoSel
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
            this.colSel = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colInvCode = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn3 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn4 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn5 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn6 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colQty = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn8 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colVenCode = new DevExpress.XtraGrid.Columns.GridColumn();
            this.rpiVen = new DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit();
            this.colInvProp = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn11 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colBackQty = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn12 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colPODId = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn1 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.button1 = new System.Windows.Forms.Button();
            this.btnClose = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.grdDetail)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grvDetail)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.rpiVen)).BeginInit();
            this.SuspendLayout();
            // 
            // grdDetail
            // 
            this.grdDetail.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.grdDetail.EmbeddedNavigator.Name = "";
            this.grdDetail.Location = new System.Drawing.Point(1, 12);
            this.grdDetail.MainView = this.grvDetail;
            this.grdDetail.Name = "grdDetail";
            this.grdDetail.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.rpiVen});
            this.grdDetail.Size = new System.Drawing.Size(927, 477);
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
            this.colSel,
            this.colInvCode,
            this.gridColumn3,
            this.gridColumn4,
            this.gridColumn5,
            this.gridColumn6,
            this.colQty,
            this.gridColumn8,
            this.colVenCode,
            this.colInvProp,
            this.gridColumn11,
            this.colBackQty,
            this.gridColumn12,
            this.colPODId,
            this.gridColumn1});
            this.grvDetail.CustomizationFormBounds = new System.Drawing.Rectangle(1072, 422, 208, 175);
            this.grvDetail.GridControl = this.grdDetail;
            this.grvDetail.IndicatorWidth = 40;
            this.grvDetail.Name = "grvDetail";
            this.grvDetail.OptionsCustomization.AllowFilter = false;
            this.grvDetail.OptionsView.ColumnAutoWidth = false;
            this.grvDetail.OptionsView.EnableAppearanceEvenRow = true;
            this.grvDetail.OptionsView.EnableAppearanceOddRow = true;
            this.grvDetail.OptionsView.ShowFooter = true;
            this.grvDetail.OptionsView.ShowGroupPanel = false;
            // 
            // colSel
            // 
            this.colSel.Caption = "选择";
            this.colSel.FieldName = "IsSel";
            this.colSel.Name = "colSel";
            this.colSel.Visible = true;
            this.colSel.VisibleIndex = 0;
            this.colSel.Width = 70;
            // 
            // colInvCode
            // 
            this.colInvCode.Caption = "存货编码";
            this.colInvCode.FieldName = "cInvCode";
            this.colInvCode.Name = "colInvCode";
            this.colInvCode.Visible = true;
            this.colInvCode.VisibleIndex = 1;
            // 
            // gridColumn3
            // 
            this.gridColumn3.Caption = "存货名称";
            this.gridColumn3.FieldName = "cInvName";
            this.gridColumn3.Name = "gridColumn3";
            this.gridColumn3.Visible = true;
            this.gridColumn3.VisibleIndex = 2;
            this.gridColumn3.Width = 108;
            // 
            // gridColumn4
            // 
            this.gridColumn4.Caption = "规格型号";
            this.gridColumn4.FieldName = "cInvStd";
            this.gridColumn4.Name = "gridColumn4";
            this.gridColumn4.Visible = true;
            this.gridColumn4.VisibleIndex = 3;
            // 
            // gridColumn5
            // 
            this.gridColumn5.Caption = "主计量";
            this.gridColumn5.FieldName = "MUnitName";
            this.gridColumn5.Name = "gridColumn5";
            this.gridColumn5.Visible = true;
            this.gridColumn5.VisibleIndex = 4;
            // 
            // gridColumn6
            // 
            this.gridColumn6.Caption = "辅计量";
            this.gridColumn6.FieldName = "AUnitName";
            this.gridColumn6.Name = "gridColumn6";
            this.gridColumn6.Visible = true;
            this.gridColumn6.VisibleIndex = 5;
            // 
            // colQty
            // 
            this.colQty.Caption = "数量";
            this.colQty.FieldName = "iQuantity";
            this.colQty.Name = "colQty";
            this.colQty.Visible = true;
            this.colQty.VisibleIndex = 6;
            // 
            // gridColumn8
            // 
            this.gridColumn8.Caption = "件数";
            this.gridColumn8.FieldName = "iNum";
            this.gridColumn8.Name = "gridColumn8";
            this.gridColumn8.Visible = true;
            this.gridColumn8.VisibleIndex = 7;
            // 
            // colVenCode
            // 
            this.colVenCode.Caption = "供应商编码";
            this.colVenCode.ColumnEdit = this.rpiVen;
            this.colVenCode.FieldName = "VenCode";
            this.colVenCode.Name = "colVenCode";
            this.colVenCode.Visible = true;
            this.colVenCode.VisibleIndex = 8;
            this.colVenCode.Width = 91;
            // 
            // rpiVen
            // 
            this.rpiVen.AutoHeight = false;
            this.rpiVen.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.rpiVen.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("cVenCode", "编码", 20, DevExpress.Utils.FormatType.None, "", true, DevExpress.Utils.HorzAlignment.Default, DevExpress.Data.ColumnSortOrder.None),
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("cVenName", "名称", 20, DevExpress.Utils.FormatType.None, "", true, DevExpress.Utils.HorzAlignment.Default, DevExpress.Data.ColumnSortOrder.None)});
            this.rpiVen.DisplayMember = "cVenName";
            this.rpiVen.Name = "rpiVen";
            this.rpiVen.ValueMember = "cVenCode";
            // 
            // colInvProp
            // 
            this.colInvProp.Caption = "存货属性";
            this.colInvProp.FieldName = "InvProp";
            this.colInvProp.Name = "colInvProp";
            this.colInvProp.Visible = true;
            this.colInvProp.VisibleIndex = 9;
            // 
            // gridColumn11
            // 
            this.gridColumn11.Caption = "形态转换后物料";
            this.gridColumn11.Name = "gridColumn11";
            this.gridColumn11.Visible = true;
            this.gridColumn11.VisibleIndex = 10;
            this.gridColumn11.Width = 120;
            // 
            // colBackQty
            // 
            this.colBackQty.Caption = "退货数量";
            this.colBackQty.Name = "colBackQty";
            this.colBackQty.Visible = true;
            this.colBackQty.VisibleIndex = 11;
            // 
            // gridColumn12
            // 
            this.gridColumn12.Caption = "需求数";
            this.gridColumn12.Name = "gridColumn12";
            this.gridColumn12.Visible = true;
            this.gridColumn12.VisibleIndex = 12;
            this.gridColumn12.Width = 104;
            // 
            // colPODId
            // 
            this.colPODId.Caption = "gridColumn1";
            this.colPODId.FieldName = "PODId";
            this.colPODId.Name = "colPODId";
            // 
            // gridColumn1
            // 
            this.gridColumn1.Caption = "对应单号";
            this.gridColumn1.FieldName = "cPOID";
            this.gridColumn1.Name = "gridColumn1";
            this.gridColumn1.Visible = true;
            this.gridColumn1.VisibleIndex = 13;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(853, 508);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 15;
            this.button1.Text = "退出";
            this.button1.UseVisualStyleBackColor = true;
            // 
            // btnClose
            // 
            this.btnClose.Location = new System.Drawing.Point(772, 508);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(75, 23);
            this.btnClose.TabIndex = 16;
            this.btnClose.Text = "关闭";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // FrmClosedPoSel
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(940, 553);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.grdDetail);
            this.Name = "FrmClosedPoSel";
            this.Text = "关闭订单";
            this.Load += new System.EventHandler(this.FrmClosedPoSel_Load);
            ((System.ComponentModel.ISupportInitialize)(this.grdDetail)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grvDetail)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.rpiVen)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraGrid.GridControl grdDetail;
        private DevExpress.XtraGrid.Views.Grid.GridView grvDetail;
        private DevExpress.XtraGrid.Columns.GridColumn colSel;
        private DevExpress.XtraGrid.Columns.GridColumn colInvCode;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn3;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn4;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn5;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn6;
        private DevExpress.XtraGrid.Columns.GridColumn colQty;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn8;
        private DevExpress.XtraGrid.Columns.GridColumn colVenCode;
        private DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit rpiVen;
        private DevExpress.XtraGrid.Columns.GridColumn colInvProp;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn11;
        private DevExpress.XtraGrid.Columns.GridColumn colBackQty;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn12;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button btnClose;
        private DevExpress.XtraGrid.Columns.GridColumn colPODId;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn1;
    }
}