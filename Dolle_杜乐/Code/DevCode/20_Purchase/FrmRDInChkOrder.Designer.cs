﻿namespace Purchase
{
    partial class FrmRDInChkOrder
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
            this.label1 = new System.Windows.Forms.Label();
            this.gridControl1 = new DevExpress.XtraGrid.GridControl();
            this.gridView1 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.gridColchoose = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColRdsID = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn2 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn3 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColcInvCode = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn5 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn6 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColprice = new DevExpress.XtraGrid.Columns.GridColumn();
            this.ItemTextEdit_n6 = new DevExpress.XtraEditors.Repository.RepositoryItemTextEdit();
            this.gridColiQuantity = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColiPrice = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColQty = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn11 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColiVendPrice = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColiSum = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColiArrSum = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColdDate = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColiiqty = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColcbarvcode = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColiInvWeight = new DevExpress.XtraGrid.Columns.GridColumn();
            this.chkAll = new System.Windows.Forms.CheckBox();
            this.dateEdit2 = new DevExpress.XtraEditors.DateEdit();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.dateEdit1 = new DevExpress.XtraEditors.DateEdit();
            this.label6 = new System.Windows.Forms.Label();
            this.lookUpEditRDIn2 = new DevExpress.XtraEditors.LookUpEdit();
            this.lookUpEditRDIn1 = new DevExpress.XtraEditors.LookUpEdit();
            this.label7 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.lookUpEditOrder2 = new DevExpress.XtraEditors.LookUpEdit();
            this.lookUpEditOrder1 = new DevExpress.XtraEditors.LookUpEdit();
            this.label4 = new System.Windows.Forms.Label();
            this.txtVenName = new DevExpress.XtraEditors.TextEdit();
            this.txtVenCode = new DevExpress.XtraEditors.ButtonEdit();
            this.chkDate = new System.Windows.Forms.CheckBox();
            this.radioAudit = new System.Windows.Forms.RadioButton();
            this.radioEnSure = new System.Windows.Forms.RadioButton();
            this.radioUnSure = new System.Windows.Forms.RadioButton();
            this.chkiInvIIQty = new System.Windows.Forms.CheckBox();
            this.btn保存净重 = new System.Windows.Forms.Button();
            this.radioInvoice = new System.Windows.Forms.RadioButton();
            this.label8 = new System.Windows.Forms.Label();
            this.gridColcComUnitName = new DevExpress.XtraGrid.Columns.GridColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dsPrint)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dsForm)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtSel)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ItemTextEdit_n6)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dateEdit2.Properties.VistaTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dateEdit2.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dateEdit1.Properties.VistaTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dateEdit1.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lookUpEditRDIn2.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lookUpEditRDIn1.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lookUpEditOrder2.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lookUpEditOrder1.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtVenName.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtVenCode.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(7, 44);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(55, 14);
            this.label1.TabIndex = 18;
            this.label1.Text = "供应商：";
            // 
            // gridControl1
            // 
            this.gridControl1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.gridControl1.EmbeddedNavigator.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.gridControl1.Location = new System.Drawing.Point(0, 166);
            this.gridControl1.MainView = this.gridView1;
            this.gridControl1.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.gridControl1.Name = "gridControl1";
            this.gridControl1.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.ItemTextEdit_n6});
            this.gridControl1.Size = new System.Drawing.Size(1124, 262);
            this.gridControl1.TabIndex = 20;
            this.gridControl1.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView1});
            // 
            // gridView1
            // 
            this.gridView1.Appearance.ColumnFilterButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(202)))), ((int)(((byte)(221)))), ((int)(((byte)(208)))));
            this.gridView1.Appearance.ColumnFilterButton.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(202)))), ((int)(((byte)(221)))), ((int)(((byte)(208)))));
            this.gridView1.Appearance.ColumnFilterButton.ForeColor = System.Drawing.Color.Black;
            this.gridView1.Appearance.ColumnFilterButton.Options.UseBackColor = true;
            this.gridView1.Appearance.ColumnFilterButton.Options.UseBorderColor = true;
            this.gridView1.Appearance.ColumnFilterButton.Options.UseForeColor = true;
            this.gridView1.Appearance.ColumnFilterButtonActive.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(211)))), ((int)(((byte)(226)))), ((int)(((byte)(216)))));
            this.gridView1.Appearance.ColumnFilterButtonActive.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(211)))), ((int)(((byte)(226)))), ((int)(((byte)(216)))));
            this.gridView1.Appearance.ColumnFilterButtonActive.ForeColor = System.Drawing.Color.Black;
            this.gridView1.Appearance.ColumnFilterButtonActive.Options.UseBackColor = true;
            this.gridView1.Appearance.ColumnFilterButtonActive.Options.UseBorderColor = true;
            this.gridView1.Appearance.ColumnFilterButtonActive.Options.UseForeColor = true;
            this.gridView1.Appearance.Empty.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(242)))), ((int)(((byte)(244)))), ((int)(((byte)(236)))));
            this.gridView1.Appearance.Empty.BackColor2 = System.Drawing.Color.White;
            this.gridView1.Appearance.Empty.Options.UseBackColor = true;
            this.gridView1.Appearance.EvenRow.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(221)))), ((int)(((byte)(227)))), ((int)(((byte)(245)))));
            this.gridView1.Appearance.EvenRow.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(221)))), ((int)(((byte)(227)))), ((int)(((byte)(245)))));
            this.gridView1.Appearance.EvenRow.ForeColor = System.Drawing.Color.Black;
            this.gridView1.Appearance.EvenRow.Options.UseBackColor = true;
            this.gridView1.Appearance.EvenRow.Options.UseBorderColor = true;
            this.gridView1.Appearance.EvenRow.Options.UseForeColor = true;
            this.gridView1.Appearance.FilterCloseButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(202)))), ((int)(((byte)(221)))), ((int)(((byte)(208)))));
            this.gridView1.Appearance.FilterCloseButton.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(202)))), ((int)(((byte)(221)))), ((int)(((byte)(208)))));
            this.gridView1.Appearance.FilterCloseButton.ForeColor = System.Drawing.Color.Black;
            this.gridView1.Appearance.FilterCloseButton.Options.UseBackColor = true;
            this.gridView1.Appearance.FilterCloseButton.Options.UseBorderColor = true;
            this.gridView1.Appearance.FilterCloseButton.Options.UseForeColor = true;
            this.gridView1.Appearance.FilterPanel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(242)))), ((int)(((byte)(244)))), ((int)(((byte)(236)))));
            this.gridView1.Appearance.FilterPanel.BackColor2 = System.Drawing.Color.White;
            this.gridView1.Appearance.FilterPanel.ForeColor = System.Drawing.Color.Black;
            this.gridView1.Appearance.FilterPanel.Options.UseBackColor = true;
            this.gridView1.Appearance.FilterPanel.Options.UseForeColor = true;
            this.gridView1.Appearance.FixedLine.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(117)))), ((int)(((byte)(136)))), ((int)(((byte)(122)))));
            this.gridView1.Appearance.FixedLine.Options.UseBackColor = true;
            this.gridView1.Appearance.FocusedCell.BackColor = System.Drawing.Color.White;
            this.gridView1.Appearance.FocusedCell.ForeColor = System.Drawing.Color.Black;
            this.gridView1.Appearance.FocusedCell.Options.UseBackColor = true;
            this.gridView1.Appearance.FocusedCell.Options.UseForeColor = true;
            this.gridView1.Appearance.FocusedRow.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(129)))), ((int)(((byte)(171)))), ((int)(((byte)(177)))));
            this.gridView1.Appearance.FocusedRow.ForeColor = System.Drawing.Color.White;
            this.gridView1.Appearance.FocusedRow.Options.UseBackColor = true;
            this.gridView1.Appearance.FocusedRow.Options.UseForeColor = true;
            this.gridView1.Appearance.FooterPanel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(202)))), ((int)(((byte)(221)))), ((int)(((byte)(208)))));
            this.gridView1.Appearance.FooterPanel.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(202)))), ((int)(((byte)(221)))), ((int)(((byte)(208)))));
            this.gridView1.Appearance.FooterPanel.ForeColor = System.Drawing.Color.Black;
            this.gridView1.Appearance.FooterPanel.Options.UseBackColor = true;
            this.gridView1.Appearance.FooterPanel.Options.UseBorderColor = true;
            this.gridView1.Appearance.FooterPanel.Options.UseForeColor = true;
            this.gridView1.Appearance.GroupButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(178)))), ((int)(((byte)(209)))), ((int)(((byte)(188)))));
            this.gridView1.Appearance.GroupButton.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(178)))), ((int)(((byte)(209)))), ((int)(((byte)(188)))));
            this.gridView1.Appearance.GroupButton.Options.UseBackColor = true;
            this.gridView1.Appearance.GroupButton.Options.UseBorderColor = true;
            this.gridView1.Appearance.GroupFooter.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(215)))), ((int)(((byte)(234)))), ((int)(((byte)(221)))));
            this.gridView1.Appearance.GroupFooter.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(215)))), ((int)(((byte)(234)))), ((int)(((byte)(221)))));
            this.gridView1.Appearance.GroupFooter.ForeColor = System.Drawing.Color.Black;
            this.gridView1.Appearance.GroupFooter.Options.UseBackColor = true;
            this.gridView1.Appearance.GroupFooter.Options.UseBorderColor = true;
            this.gridView1.Appearance.GroupFooter.Options.UseForeColor = true;
            this.gridView1.Appearance.GroupPanel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(242)))), ((int)(((byte)(244)))), ((int)(((byte)(236)))));
            this.gridView1.Appearance.GroupPanel.BackColor2 = System.Drawing.Color.White;
            this.gridView1.Appearance.GroupPanel.ForeColor = System.Drawing.Color.Black;
            this.gridView1.Appearance.GroupPanel.Options.UseBackColor = true;
            this.gridView1.Appearance.GroupPanel.Options.UseForeColor = true;
            this.gridView1.Appearance.GroupRow.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(215)))), ((int)(((byte)(234)))), ((int)(((byte)(221)))));
            this.gridView1.Appearance.GroupRow.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(215)))), ((int)(((byte)(234)))), ((int)(((byte)(221)))));
            this.gridView1.Appearance.GroupRow.ForeColor = System.Drawing.Color.Black;
            this.gridView1.Appearance.GroupRow.Options.UseBackColor = true;
            this.gridView1.Appearance.GroupRow.Options.UseBorderColor = true;
            this.gridView1.Appearance.GroupRow.Options.UseForeColor = true;
            this.gridView1.Appearance.HeaderPanel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(211)))), ((int)(((byte)(226)))), ((int)(((byte)(216)))));
            this.gridView1.Appearance.HeaderPanel.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(211)))), ((int)(((byte)(226)))), ((int)(((byte)(216)))));
            this.gridView1.Appearance.HeaderPanel.ForeColor = System.Drawing.Color.Black;
            this.gridView1.Appearance.HeaderPanel.Options.UseBackColor = true;
            this.gridView1.Appearance.HeaderPanel.Options.UseBorderColor = true;
            this.gridView1.Appearance.HeaderPanel.Options.UseForeColor = true;
            this.gridView1.Appearance.HideSelectionRow.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(186)))), ((int)(((byte)(211)))), ((int)(((byte)(215)))));
            this.gridView1.Appearance.HideSelectionRow.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(104)))), ((int)(((byte)(130)))), ((int)(((byte)(134)))));
            this.gridView1.Appearance.HideSelectionRow.Options.UseBackColor = true;
            this.gridView1.Appearance.HideSelectionRow.Options.UseForeColor = true;
            this.gridView1.Appearance.HorzLine.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(172)))), ((int)(((byte)(197)))), ((int)(((byte)(180)))));
            this.gridView1.Appearance.HorzLine.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(117)))), ((int)(((byte)(136)))), ((int)(((byte)(122)))));
            this.gridView1.Appearance.HorzLine.Options.UseBackColor = true;
            this.gridView1.Appearance.HorzLine.Options.UseBorderColor = true;
            this.gridView1.Appearance.OddRow.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(242)))), ((int)(((byte)(244)))), ((int)(((byte)(236)))));
            this.gridView1.Appearance.OddRow.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(242)))), ((int)(((byte)(244)))), ((int)(((byte)(236)))));
            this.gridView1.Appearance.OddRow.ForeColor = System.Drawing.Color.Black;
            this.gridView1.Appearance.OddRow.Options.UseBackColor = true;
            this.gridView1.Appearance.OddRow.Options.UseBorderColor = true;
            this.gridView1.Appearance.OddRow.Options.UseForeColor = true;
            this.gridView1.Appearance.Preview.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(250)))), ((int)(((byte)(250)))), ((int)(((byte)(240)))));
            this.gridView1.Appearance.Preview.Font = new System.Drawing.Font("Verdana", 7.5F);
            this.gridView1.Appearance.Preview.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(104)))), ((int)(((byte)(130)))), ((int)(((byte)(134)))));
            this.gridView1.Appearance.Preview.Options.UseBackColor = true;
            this.gridView1.Appearance.Preview.Options.UseFont = true;
            this.gridView1.Appearance.Preview.Options.UseForeColor = true;
            this.gridView1.Appearance.Row.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(242)))), ((int)(((byte)(244)))), ((int)(((byte)(236)))));
            this.gridView1.Appearance.Row.ForeColor = System.Drawing.Color.Black;
            this.gridView1.Appearance.Row.Options.UseBackColor = true;
            this.gridView1.Appearance.Row.Options.UseForeColor = true;
            this.gridView1.Appearance.RowSeparator.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(242)))), ((int)(((byte)(244)))), ((int)(((byte)(236)))));
            this.gridView1.Appearance.RowSeparator.BackColor2 = System.Drawing.Color.White;
            this.gridView1.Appearance.RowSeparator.Options.UseBackColor = true;
            this.gridView1.Appearance.SelectedRow.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(159)))), ((int)(((byte)(201)))), ((int)(((byte)(207)))));
            this.gridView1.Appearance.SelectedRow.ForeColor = System.Drawing.Color.Black;
            this.gridView1.Appearance.SelectedRow.Options.UseBackColor = true;
            this.gridView1.Appearance.SelectedRow.Options.UseForeColor = true;
            this.gridView1.Appearance.TopNewRow.BackColor = System.Drawing.Color.White;
            this.gridView1.Appearance.TopNewRow.Options.UseBackColor = true;
            this.gridView1.Appearance.VertLine.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(172)))), ((int)(((byte)(197)))), ((int)(((byte)(180)))));
            this.gridView1.Appearance.VertLine.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(117)))), ((int)(((byte)(136)))), ((int)(((byte)(122)))));
            this.gridView1.Appearance.VertLine.Options.UseBackColor = true;
            this.gridView1.Appearance.VertLine.Options.UseBorderColor = true;
            this.gridView1.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.gridColchoose,
            this.gridColRdsID,
            this.gridColumn2,
            this.gridColumn3,
            this.gridColcInvCode,
            this.gridColumn5,
            this.gridColumn6,
            this.gridColprice,
            this.gridColiQuantity,
            this.gridColiPrice,
            this.gridColQty,
            this.gridColumn11,
            this.gridColiVendPrice,
            this.gridColiSum,
            this.gridColiArrSum,
            this.gridColdDate,
            this.gridColiiqty,
            this.gridColcbarvcode,
            this.gridColiInvWeight,
            this.gridColcComUnitName});
            this.gridView1.CustomizationFormBounds = new System.Drawing.Rectangle(1062, 318, 208, 177);
            this.gridView1.GridControl = this.gridControl1;
            this.gridView1.IndicatorWidth = 40;
            this.gridView1.Name = "gridView1";
            this.gridView1.OptionsView.ColumnAutoWidth = false;
            this.gridView1.OptionsView.EnableAppearanceEvenRow = true;
            this.gridView1.OptionsView.EnableAppearanceOddRow = true;
            this.gridView1.OptionsView.ShowFooter = true;
            this.gridView1.OptionsView.ShowGroupPanel = false;
            this.gridView1.CustomDrawRowIndicator += new DevExpress.XtraGrid.Views.Grid.RowIndicatorCustomDrawEventHandler(this.gridView1_CustomDrawRowIndicator);
            this.gridView1.CellValueChanged += new DevExpress.XtraGrid.Views.Base.CellValueChangedEventHandler(this.gridView1_CellValueChanged);
            this.gridView1.RowCellStyle += new DevExpress.XtraGrid.Views.Grid.RowCellStyleEventHandler(this.gridView1_RowCellStyle);
            this.gridView1.DoubleClick += new System.EventHandler(this.gridView1_DoubleClick);
            // 
            // gridColchoose
            // 
            this.gridColchoose.Caption = "选择";
            this.gridColchoose.FieldName = "bChoose";
            this.gridColchoose.Name = "gridColchoose";
            this.gridColchoose.OptionsColumn.AllowEdit = false;
            this.gridColchoose.OptionsColumn.AllowSort = DevExpress.Utils.DefaultBoolean.False;
            this.gridColchoose.OptionsFilter.AllowFilter = false;
            this.gridColchoose.Visible = true;
            this.gridColchoose.VisibleIndex = 0;
            this.gridColchoose.Width = 34;
            // 
            // gridColRdsID
            // 
            this.gridColRdsID.Caption = "iID";
            this.gridColRdsID.FieldName = "autoid";
            this.gridColRdsID.Name = "gridColRdsID";
            this.gridColRdsID.OptionsColumn.AllowEdit = false;
            this.gridColRdsID.OptionsColumn.AllowSort = DevExpress.Utils.DefaultBoolean.False;
            // 
            // gridColumn2
            // 
            this.gridColumn2.Caption = "订单号";
            this.gridColumn2.FieldName = "cPOID";
            this.gridColumn2.Name = "gridColumn2";
            this.gridColumn2.OptionsColumn.AllowEdit = false;
            this.gridColumn2.OptionsColumn.AllowSort = DevExpress.Utils.DefaultBoolean.True;
            this.gridColumn2.Visible = true;
            this.gridColumn2.VisibleIndex = 4;
            this.gridColumn2.Width = 66;
            // 
            // gridColumn3
            // 
            this.gridColumn3.Caption = "入库单号";
            this.gridColumn3.FieldName = "cCode";
            this.gridColumn3.Name = "gridColumn3";
            this.gridColumn3.OptionsColumn.AllowEdit = false;
            this.gridColumn3.OptionsColumn.AllowSort = DevExpress.Utils.DefaultBoolean.True;
            this.gridColumn3.Visible = true;
            this.gridColumn3.VisibleIndex = 2;
            this.gridColumn3.Width = 77;
            // 
            // gridColcInvCode
            // 
            this.gridColcInvCode.Caption = "存货编码";
            this.gridColcInvCode.FieldName = "cInvCode";
            this.gridColcInvCode.Name = "gridColcInvCode";
            this.gridColcInvCode.OptionsColumn.AllowEdit = false;
            this.gridColcInvCode.OptionsColumn.AllowSort = DevExpress.Utils.DefaultBoolean.True;
            this.gridColcInvCode.Visible = true;
            this.gridColcInvCode.VisibleIndex = 5;
            this.gridColcInvCode.Width = 114;
            // 
            // gridColumn5
            // 
            this.gridColumn5.Caption = "存货名称";
            this.gridColumn5.FieldName = "cInvName";
            this.gridColumn5.Name = "gridColumn5";
            this.gridColumn5.OptionsColumn.AllowEdit = false;
            this.gridColumn5.OptionsColumn.AllowSort = DevExpress.Utils.DefaultBoolean.True;
            this.gridColumn5.Visible = true;
            this.gridColumn5.VisibleIndex = 6;
            this.gridColumn5.Width = 115;
            // 
            // gridColumn6
            // 
            this.gridColumn6.Caption = "规格型号";
            this.gridColumn6.FieldName = "cInvStd";
            this.gridColumn6.Name = "gridColumn6";
            this.gridColumn6.OptionsColumn.AllowEdit = false;
            this.gridColumn6.OptionsColumn.AllowSort = DevExpress.Utils.DefaultBoolean.True;
            this.gridColumn6.Visible = true;
            this.gridColumn6.VisibleIndex = 7;
            // 
            // gridColprice
            // 
            this.gridColprice.Caption = "单价";
            this.gridColprice.ColumnEdit = this.ItemTextEdit_n6;
            this.gridColprice.FieldName = "price";
            this.gridColprice.Name = "gridColprice";
            this.gridColprice.OptionsColumn.AllowEdit = false;
            this.gridColprice.OptionsColumn.AllowSort = DevExpress.Utils.DefaultBoolean.False;
            this.gridColprice.Width = 90;
            // 
            // ItemTextEdit_n6
            // 
            this.ItemTextEdit_n6.AutoHeight = false;
            this.ItemTextEdit_n6.DisplayFormat.FormatString = "n6";
            this.ItemTextEdit_n6.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.ItemTextEdit_n6.EditFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.ItemTextEdit_n6.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Numeric;
            this.ItemTextEdit_n6.Name = "ItemTextEdit_n6";
            // 
            // gridColiQuantity
            // 
            this.gridColiQuantity.Caption = "数量";
            this.gridColiQuantity.ColumnEdit = this.ItemTextEdit_n6;
            this.gridColiQuantity.FieldName = "iQuantity";
            this.gridColiQuantity.Name = "gridColiQuantity";
            this.gridColiQuantity.OptionsColumn.AllowEdit = false;
            this.gridColiQuantity.OptionsColumn.AllowSort = DevExpress.Utils.DefaultBoolean.False;
            this.gridColiQuantity.Summary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] {
            new DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum)});
            this.gridColiQuantity.Visible = true;
            this.gridColiQuantity.VisibleIndex = 13;
            this.gridColiQuantity.Width = 90;
            // 
            // gridColiPrice
            // 
            this.gridColiPrice.Caption = "送货单价";
            this.gridColiPrice.ColumnEdit = this.ItemTextEdit_n6;
            this.gridColiPrice.FieldName = "iPrice";
            this.gridColiPrice.Name = "gridColiPrice";
            this.gridColiPrice.OptionsColumn.AllowSort = DevExpress.Utils.DefaultBoolean.False;
            this.gridColiPrice.Visible = true;
            this.gridColiPrice.VisibleIndex = 10;
            this.gridColiPrice.Width = 90;
            // 
            // gridColQty
            // 
            this.gridColQty.Caption = "送货数量";
            this.gridColQty.ColumnEdit = this.ItemTextEdit_n6;
            this.gridColQty.FieldName = "Qty";
            this.gridColQty.Name = "gridColQty";
            this.gridColQty.OptionsColumn.AllowSort = DevExpress.Utils.DefaultBoolean.False;
            this.gridColQty.Summary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] {
            new DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum)});
            this.gridColQty.Visible = true;
            this.gridColQty.VisibleIndex = 11;
            this.gridColQty.Width = 90;
            // 
            // gridColumn11
            // 
            this.gridColumn11.Caption = "是否审核";
            this.gridColumn11.FieldName = "bAudit";
            this.gridColumn11.Name = "gridColumn11";
            this.gridColumn11.OptionsColumn.AllowEdit = false;
            this.gridColumn11.OptionsColumn.AllowSort = DevExpress.Utils.DefaultBoolean.False;
            // 
            // gridColiVendPrice
            // 
            this.gridColiVendPrice.Caption = "供应商存货价格";
            this.gridColiVendPrice.ColumnEdit = this.ItemTextEdit_n6;
            this.gridColiVendPrice.FieldName = "iVendPrice";
            this.gridColiVendPrice.Name = "gridColiVendPrice";
            this.gridColiVendPrice.OptionsColumn.AllowEdit = false;
            this.gridColiVendPrice.OptionsColumn.AllowSort = DevExpress.Utils.DefaultBoolean.False;
            this.gridColiVendPrice.Visible = true;
            this.gridColiVendPrice.VisibleIndex = 9;
            this.gridColiVendPrice.Width = 90;
            // 
            // gridColiSum
            // 
            this.gridColiSum.Caption = "金额";
            this.gridColiSum.ColumnEdit = this.ItemTextEdit_n6;
            this.gridColiSum.FieldName = "iSum";
            this.gridColiSum.Name = "gridColiSum";
            this.gridColiSum.OptionsColumn.AllowEdit = false;
            this.gridColiSum.OptionsColumn.AllowSort = DevExpress.Utils.DefaultBoolean.False;
            this.gridColiSum.Summary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] {
            new DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum)});
            this.gridColiSum.Width = 90;
            // 
            // gridColiArrSum
            // 
            this.gridColiArrSum.Caption = "送货金额";
            this.gridColiArrSum.ColumnEdit = this.ItemTextEdit_n6;
            this.gridColiArrSum.FieldName = "iArrSum";
            this.gridColiArrSum.Name = "gridColiArrSum";
            this.gridColiArrSum.OptionsColumn.AllowEdit = false;
            this.gridColiArrSum.OptionsColumn.AllowSort = DevExpress.Utils.DefaultBoolean.False;
            this.gridColiArrSum.Summary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] {
            new DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum)});
            this.gridColiArrSum.Visible = true;
            this.gridColiArrSum.VisibleIndex = 12;
            this.gridColiArrSum.Width = 90;
            // 
            // gridColdDate
            // 
            this.gridColdDate.Caption = "入库日期";
            this.gridColdDate.FieldName = "dDate";
            this.gridColdDate.Name = "gridColdDate";
            this.gridColdDate.OptionsColumn.AllowEdit = false;
            this.gridColdDate.OptionsColumn.AllowSort = DevExpress.Utils.DefaultBoolean.False;
            this.gridColdDate.Visible = true;
            this.gridColdDate.VisibleIndex = 3;
            // 
            // gridColiiqty
            // 
            this.gridColiiqty.Caption = "未结算数量";
            this.gridColiiqty.DisplayFormat.FormatString = "n3";
            this.gridColiiqty.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.gridColiiqty.FieldName = "iiqty";
            this.gridColiiqty.Name = "gridColiiqty";
            this.gridColiiqty.OptionsColumn.AllowEdit = false;
            this.gridColiiqty.OptionsColumn.AllowMerge = DevExpress.Utils.DefaultBoolean.False;
            this.gridColiiqty.Summary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] {
            new DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum)});
            this.gridColiiqty.Visible = true;
            this.gridColiiqty.VisibleIndex = 8;
            // 
            // gridColcbarvcode
            // 
            this.gridColcbarvcode.Caption = "到货单号";
            this.gridColcbarvcode.FieldName = "cbarvcode";
            this.gridColcbarvcode.Name = "gridColcbarvcode";
            this.gridColcbarvcode.OptionsColumn.AllowEdit = false;
            this.gridColcbarvcode.Visible = true;
            this.gridColcbarvcode.VisibleIndex = 1;
            // 
            // gridColiInvWeight
            // 
            this.gridColiInvWeight.Caption = "净重（公斤）";
            this.gridColiInvWeight.FieldName = "iInvWeight";
            this.gridColiInvWeight.Name = "gridColiInvWeight";
            this.gridColiInvWeight.Visible = true;
            this.gridColiInvWeight.VisibleIndex = 14;
            this.gridColiInvWeight.Width = 90;
            // 
            // chkAll
            // 
            this.chkAll.AutoSize = true;
            this.chkAll.Location = new System.Drawing.Point(560, 134);
            this.chkAll.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.chkAll.Name = "chkAll";
            this.chkAll.Size = new System.Drawing.Size(50, 18);
            this.chkAll.TabIndex = 27;
            this.chkAll.Text = "全选";
            this.chkAll.UseVisualStyleBackColor = true;
            this.chkAll.CheckedChanged += new System.EventHandler(this.chkAll_CheckedChanged);
            // 
            // dateEdit2
            // 
            this.dateEdit2.EditValue = new System.DateTime(2010, 9, 14, 0, 0, 0, 0);
            this.dateEdit2.Enabled = false;
            this.dateEdit2.Location = new System.Drawing.Point(349, 135);
            this.dateEdit2.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.dateEdit2.Name = "dateEdit2";
            this.dateEdit2.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.dateEdit2.Properties.VistaTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
            this.dateEdit2.Size = new System.Drawing.Size(193, 20);
            this.dateEdit2.TabIndex = 35;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(307, 138);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(23, 14);
            this.label3.TabIndex = 34;
            this.label3.Text = "----";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(7, 138);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(67, 14);
            this.label2.TabIndex = 33;
            this.label2.Text = "入库日期：";
            // 
            // dateEdit1
            // 
            this.dateEdit1.EditValue = new System.DateTime(2010, 9, 14, 0, 0, 0, 0);
            this.dateEdit1.Enabled = false;
            this.dateEdit1.Location = new System.Drawing.Point(118, 135);
            this.dateEdit1.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.dateEdit1.Name = "dateEdit1";
            this.dateEdit1.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.dateEdit1.Properties.VistaTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
            this.dateEdit1.Size = new System.Drawing.Size(179, 20);
            this.dateEdit1.TabIndex = 32;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(304, 109);
            this.label6.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(23, 14);
            this.label6.TabIndex = 48;
            this.label6.Text = "----";
            // 
            // lookUpEditRDIn2
            // 
            this.lookUpEditRDIn2.Location = new System.Drawing.Point(349, 104);
            this.lookUpEditRDIn2.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.lookUpEditRDIn2.Name = "lookUpEditRDIn2";
            this.lookUpEditRDIn2.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.lookUpEditRDIn2.Properties.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("iID", "采购入库单号")});
            this.lookUpEditRDIn2.Properties.DisplayMember = "iID";
            this.lookUpEditRDIn2.Properties.NullText = "";
            this.lookUpEditRDIn2.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.Standard;
            this.lookUpEditRDIn2.Properties.ValueMember = "iID";
            this.lookUpEditRDIn2.Size = new System.Drawing.Size(193, 20);
            this.lookUpEditRDIn2.TabIndex = 47;
            // 
            // lookUpEditRDIn1
            // 
            this.lookUpEditRDIn1.Location = new System.Drawing.Point(104, 104);
            this.lookUpEditRDIn1.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.lookUpEditRDIn1.Name = "lookUpEditRDIn1";
            this.lookUpEditRDIn1.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.lookUpEditRDIn1.Properties.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("iID", "采购入库单号")});
            this.lookUpEditRDIn1.Properties.DisplayMember = "iID";
            this.lookUpEditRDIn1.Properties.NullText = "";
            this.lookUpEditRDIn1.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.Standard;
            this.lookUpEditRDIn1.Properties.ValueMember = "iID";
            this.lookUpEditRDIn1.Size = new System.Drawing.Size(193, 20);
            this.lookUpEditRDIn1.TabIndex = 46;
            this.lookUpEditRDIn1.EditValueChanged += new System.EventHandler(this.lookUpEditRDIn1_EditValueChanged);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(4, 107);
            this.label7.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(67, 14);
            this.label7.TabIndex = 45;
            this.label7.Text = "入库单号：";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(304, 77);
            this.label5.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(23, 14);
            this.label5.TabIndex = 44;
            this.label5.Text = "----";
            // 
            // lookUpEditOrder2
            // 
            this.lookUpEditOrder2.Location = new System.Drawing.Point(349, 72);
            this.lookUpEditOrder2.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.lookUpEditOrder2.Name = "lookUpEditOrder2";
            this.lookUpEditOrder2.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.lookUpEditOrder2.Properties.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("iID", "采购订单号")});
            this.lookUpEditOrder2.Properties.DisplayMember = "iID";
            this.lookUpEditOrder2.Properties.NullText = "";
            this.lookUpEditOrder2.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.Standard;
            this.lookUpEditOrder2.Properties.ValueMember = "iID";
            this.lookUpEditOrder2.Size = new System.Drawing.Size(193, 20);
            this.lookUpEditOrder2.TabIndex = 43;
            // 
            // lookUpEditOrder1
            // 
            this.lookUpEditOrder1.Location = new System.Drawing.Point(104, 72);
            this.lookUpEditOrder1.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.lookUpEditOrder1.Name = "lookUpEditOrder1";
            this.lookUpEditOrder1.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.lookUpEditOrder1.Properties.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("iID", "采购订单号")});
            this.lookUpEditOrder1.Properties.DisplayMember = "iID";
            this.lookUpEditOrder1.Properties.NullText = "";
            this.lookUpEditOrder1.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.Standard;
            this.lookUpEditOrder1.Properties.ValueMember = "iID";
            this.lookUpEditOrder1.Size = new System.Drawing.Size(193, 20);
            this.lookUpEditOrder1.TabIndex = 42;
            this.lookUpEditOrder1.EditValueChanged += new System.EventHandler(this.lookUpEditOrder1_EditValueChanged);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(4, 76);
            this.label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(55, 14);
            this.label4.TabIndex = 41;
            this.label4.Text = "订单号：";
            // 
            // txtVenName
            // 
            this.txtVenName.Enabled = false;
            this.txtVenName.Location = new System.Drawing.Point(228, 40);
            this.txtVenName.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.txtVenName.Name = "txtVenName";
            this.txtVenName.Properties.ReadOnly = true;
            this.txtVenName.Size = new System.Drawing.Size(314, 20);
            this.txtVenName.TabIndex = 65;
            // 
            // txtVenCode
            // 
            this.txtVenCode.EnterMoveNextControl = true;
            this.txtVenCode.Location = new System.Drawing.Point(104, 40);
            this.txtVenCode.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.txtVenCode.Name = "txtVenCode";
            this.txtVenCode.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
            this.txtVenCode.Size = new System.Drawing.Size(118, 20);
            this.txtVenCode.TabIndex = 64;
            this.txtVenCode.ButtonClick += new DevExpress.XtraEditors.Controls.ButtonPressedEventHandler(this.txtVenCode_ButtonClick);
            this.txtVenCode.Leave += new System.EventHandler(this.txtVenCode_Leave);
            // 
            // chkDate
            // 
            this.chkDate.AutoSize = true;
            this.chkDate.Location = new System.Drawing.Point(104, 140);
            this.chkDate.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.chkDate.Name = "chkDate";
            this.chkDate.Size = new System.Drawing.Size(15, 14);
            this.chkDate.TabIndex = 66;
            this.chkDate.UseVisualStyleBackColor = true;
            this.chkDate.CheckedChanged += new System.EventHandler(this.chkDate_CheckedChanged);
            // 
            // radioAudit
            // 
            this.radioAudit.AutoSize = true;
            this.radioAudit.Location = new System.Drawing.Point(932, 137);
            this.radioAudit.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.radioAudit.Name = "radioAudit";
            this.radioAudit.Size = new System.Drawing.Size(61, 18);
            this.radioAudit.TabIndex = 70;
            this.radioAudit.Text = "已审核";
            this.radioAudit.UseVisualStyleBackColor = true;
            this.radioAudit.CheckedChanged += new System.EventHandler(this.radioAudit_CheckedChanged);
            // 
            // radioEnSure
            // 
            this.radioEnSure.AutoSize = true;
            this.radioEnSure.Location = new System.Drawing.Point(843, 137);
            this.radioEnSure.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.radioEnSure.Name = "radioEnSure";
            this.radioEnSure.Size = new System.Drawing.Size(61, 18);
            this.radioEnSure.TabIndex = 69;
            this.radioEnSure.Text = "已确认";
            this.radioEnSure.UseVisualStyleBackColor = true;
            this.radioEnSure.CheckedChanged += new System.EventHandler(this.radioEnSure_CheckedChanged);
            // 
            // radioUnSure
            // 
            this.radioUnSure.Checked = true;
            this.radioUnSure.Location = new System.Drawing.Point(764, 135);
            this.radioUnSure.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.radioUnSure.Name = "radioUnSure";
            this.radioUnSure.Size = new System.Drawing.Size(71, 21);
            this.radioUnSure.TabIndex = 68;
            this.radioUnSure.TabStop = true;
            this.radioUnSure.Text = "未确认";
            this.radioUnSure.UseVisualStyleBackColor = true;
            this.radioUnSure.CheckedChanged += new System.EventHandler(this.radioUnSure_CheckedChanged);
            // 
            // chkiInvIIQty
            // 
            this.chkiInvIIQty.AutoSize = true;
            this.chkiInvIIQty.Location = new System.Drawing.Point(560, 104);
            this.chkiInvIIQty.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.chkiInvIIQty.Name = "chkiInvIIQty";
            this.chkiInvIIQty.Size = new System.Drawing.Size(98, 18);
            this.chkiInvIIQty.TabIndex = 71;
            this.chkiInvIIQty.Text = "包含全部结算";
            this.chkiInvIIQty.UseVisualStyleBackColor = true;
            // 
            // btn保存净重
            // 
            this.btn保存净重.Location = new System.Drawing.Point(673, 44);
            this.btn保存净重.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.btn保存净重.Name = "btn保存净重";
            this.btn保存净重.Size = new System.Drawing.Size(88, 26);
            this.btn保存净重.TabIndex = 72;
            this.btn保存净重.Text = "保存净重";
            this.btn保存净重.UseVisualStyleBackColor = true;
            this.btn保存净重.Click += new System.EventHandler(this.btn保存净重_Click);
            // 
            // radioInvoice
            // 
            this.radioInvoice.AutoSize = true;
            this.radioInvoice.Location = new System.Drawing.Point(1014, 138);
            this.radioInvoice.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.radioInvoice.Name = "radioInvoice";
            this.radioInvoice.Size = new System.Drawing.Size(85, 18);
            this.radioInvoice.TabIndex = 73;
            this.radioInvoice.Text = "已生成发票";
            this.radioInvoice.UseVisualStyleBackColor = true;
            this.radioInvoice.CheckedChanged += new System.EventHandler(this.radioInvoice_CheckedChanged);
            // 
            // label8
            // 
            this.label8.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(967, 104);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(127, 14);
            this.label8.TabIndex = 74;
            this.label8.Text = "不支持入库单多次开票";
            // 
            // gridColcComUnitName
            // 
            this.gridColcComUnitName.Caption = "计量单位";
            this.gridColcComUnitName.FieldName = "cComUnitName";
            this.gridColcComUnitName.Name = "gridColcComUnitName";
            this.gridColcComUnitName.OptionsColumn.AllowEdit = false;
            this.gridColcComUnitName.Visible = true;
            this.gridColcComUnitName.VisibleIndex = 15;
            // 
            // FrmRDInChkOrder
            // 
            this.Appearance.BackColor = System.Drawing.SystemColors.Control;
            this.Appearance.Options.UseBackColor = true;
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1124, 432);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.radioInvoice);
            this.Controls.Add(this.btn保存净重);
            this.Controls.Add(this.chkiInvIIQty);
            this.Controls.Add(this.radioAudit);
            this.Controls.Add(this.radioEnSure);
            this.Controls.Add(this.radioUnSure);
            this.Controls.Add(this.chkDate);
            this.Controls.Add(this.txtVenName);
            this.Controls.Add(this.txtVenCode);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.lookUpEditRDIn2);
            this.Controls.Add(this.lookUpEditRDIn1);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.lookUpEditOrder2);
            this.Controls.Add(this.lookUpEditOrder1);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.dateEdit2);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.dateEdit1);
            this.Controls.Add(this.chkAll);
            this.Controls.Add(this.gridControl1);
            this.Controls.Add(this.label1);
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "FrmRDInChkOrder";
            this.Text = "FrmRDInChkOrder";
            this.Load += new System.EventHandler(this.FrmRDInChkOrder_Load);
            this.Controls.SetChildIndex(this.label1, 0);
            this.Controls.SetChildIndex(this.gridControl1, 0);
            this.Controls.SetChildIndex(this.chkAll, 0);
            this.Controls.SetChildIndex(this.dateEdit1, 0);
            this.Controls.SetChildIndex(this.label2, 0);
            this.Controls.SetChildIndex(this.label3, 0);
            this.Controls.SetChildIndex(this.dateEdit2, 0);
            this.Controls.SetChildIndex(this.label4, 0);
            this.Controls.SetChildIndex(this.lookUpEditOrder1, 0);
            this.Controls.SetChildIndex(this.lookUpEditOrder2, 0);
            this.Controls.SetChildIndex(this.label5, 0);
            this.Controls.SetChildIndex(this.label7, 0);
            this.Controls.SetChildIndex(this.lookUpEditRDIn1, 0);
            this.Controls.SetChildIndex(this.lookUpEditRDIn2, 0);
            this.Controls.SetChildIndex(this.label6, 0);
            this.Controls.SetChildIndex(this.txtVenCode, 0);
            this.Controls.SetChildIndex(this.txtVenName, 0);
            this.Controls.SetChildIndex(this.chkDate, 0);
            this.Controls.SetChildIndex(this.radioUnSure, 0);
            this.Controls.SetChildIndex(this.radioEnSure, 0);
            this.Controls.SetChildIndex(this.radioAudit, 0);
            this.Controls.SetChildIndex(this.chkiInvIIQty, 0);
            this.Controls.SetChildIndex(this.btn保存净重, 0);
            this.Controls.SetChildIndex(this.radioInvoice, 0);
            this.Controls.SetChildIndex(this.label8, 0);
            ((System.ComponentModel.ISupportInitialize)(this.dsPrint)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dsForm)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtSel)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ItemTextEdit_n6)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dateEdit2.Properties.VistaTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dateEdit2.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dateEdit1.Properties.VistaTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dateEdit1.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lookUpEditRDIn2.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lookUpEditRDIn1.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lookUpEditOrder2.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lookUpEditOrder1.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtVenName.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtVenCode.Properties)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private DevExpress.XtraGrid.GridControl gridControl1;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView1;
        private DevExpress.XtraGrid.Columns.GridColumn gridColRdsID;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn2;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn3;
        private DevExpress.XtraGrid.Columns.GridColumn gridColcInvCode;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn5;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn6;
        private DevExpress.XtraGrid.Columns.GridColumn gridColprice;
        private DevExpress.XtraGrid.Columns.GridColumn gridColiQuantity;
        private DevExpress.XtraGrid.Columns.GridColumn gridColiPrice;
        private DevExpress.XtraGrid.Columns.GridColumn gridColQty;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn11;
        private DevExpress.XtraGrid.Columns.GridColumn gridColchoose;
        private DevExpress.XtraGrid.Columns.GridColumn gridColiVendPrice;
        private System.Windows.Forms.CheckBox chkAll;
        private DevExpress.XtraGrid.Columns.GridColumn gridColiSum;
        private DevExpress.XtraGrid.Columns.GridColumn gridColiArrSum;
        private DevExpress.XtraGrid.Columns.GridColumn gridColdDate;
        private DevExpress.XtraEditors.DateEdit dateEdit2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private DevExpress.XtraEditors.DateEdit dateEdit1;
        private System.Windows.Forms.Label label6;
        private DevExpress.XtraEditors.LookUpEdit lookUpEditRDIn2;
        private DevExpress.XtraEditors.LookUpEdit lookUpEditRDIn1;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label5;
        private DevExpress.XtraEditors.LookUpEdit lookUpEditOrder2;
        private DevExpress.XtraEditors.LookUpEdit lookUpEditOrder1;
        private System.Windows.Forms.Label label4;
        private DevExpress.XtraEditors.Repository.RepositoryItemTextEdit ItemTextEdit_n6;
        private DevExpress.XtraEditors.TextEdit txtVenName;
        private DevExpress.XtraEditors.ButtonEdit txtVenCode;
        private System.Windows.Forms.CheckBox chkDate;
        private System.Windows.Forms.RadioButton radioAudit;
        private System.Windows.Forms.RadioButton radioEnSure;
        private System.Windows.Forms.RadioButton radioUnSure;
        private DevExpress.XtraGrid.Columns.GridColumn gridColiiqty;
        private System.Windows.Forms.CheckBox chkiInvIIQty;
        private DevExpress.XtraGrid.Columns.GridColumn gridColcbarvcode;
        private DevExpress.XtraGrid.Columns.GridColumn gridColiInvWeight;
        private System.Windows.Forms.Button btn保存净重;
        private System.Windows.Forms.RadioButton radioInvoice;
        private System.Windows.Forms.Label label8;
        private DevExpress.XtraGrid.Columns.GridColumn gridColcComUnitName;
    }
}