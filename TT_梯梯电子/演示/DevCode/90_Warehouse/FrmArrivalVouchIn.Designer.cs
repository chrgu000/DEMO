namespace Warehouse
{
    partial class FrmArrivalVouchIn
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
            this.txtBarCode = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.txtRowCount = new System.Windows.Forms.TextBox();
            this.gridControl1 = new DevExpress.XtraGrid.GridControl();
            this.gridView1 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.gridColOrderID = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColOrderNo = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColcInvCode = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColcInvName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColcInvStd = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColiQuantity = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColiNum = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColOrderType = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColcDefWareHouse = new DevExpress.XtraGrid.Columns.GridColumn();
            this.LookUpWH = new DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit();
            this.gridColbUsed = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColmoid = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColiArrQty1 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColiArrNum1 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColNowQuantity = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColNowNum = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColFaChuCaiLiaoQty = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColFaChuCaiLiaoNum = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColcComUnitName1 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColcComUnitName2 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridCol原币无税单价 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridCol本币无税单价 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridCol税率 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridCol业务员 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColcDepCode = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColfInExcess = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColbChoose = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColiWIPtype = new DevExpress.XtraGrid.Columns.GridColumn();
            this.date1 = new DevExpress.XtraEditors.DateEdit();
            this.label11 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.LookUpWH)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.date1.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // childLF
            // 
            this.childLF.LookAndFeel.Style = DevExpress.LookAndFeel.LookAndFeelStyle.Skin;
            this.childLF.LookAndFeel.UseWindowsXPTheme = false;
            // 
            // txtBarCode
            // 
            this.txtBarCode.Location = new System.Drawing.Point(101, 34);
            this.txtBarCode.Name = "txtBarCode";
            this.txtBarCode.Size = new System.Drawing.Size(416, 21);
            this.txtBarCode.TabIndex = 5;
            this.txtBarCode.KeyUp += new System.Windows.Forms.KeyEventHandler(this.txtBarCode_KeyUp);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(28, 37);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(67, 14);
            this.label1.TabIndex = 6;
            this.label1.Text = "条码输入框";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(572, 37);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(43, 14);
            this.label2.TabIndex = 10;
            this.label2.Text = "行数：";
            // 
            // txtRowCount
            // 
            this.txtRowCount.Enabled = false;
            this.txtRowCount.Location = new System.Drawing.Point(621, 34);
            this.txtRowCount.Name = "txtRowCount";
            this.txtRowCount.Size = new System.Drawing.Size(100, 21);
            this.txtRowCount.TabIndex = 11;
            // 
            // gridControl1
            // 
            this.gridControl1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.gridControl1.EmbeddedNavigator.Name = "";
            this.gridControl1.Location = new System.Drawing.Point(0, 72);
            this.gridControl1.MainView = this.gridView1;
            this.gridControl1.Name = "gridControl1";
            this.gridControl1.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.LookUpWH});
            this.gridControl1.Size = new System.Drawing.Size(1028, 292);
            this.gridControl1.TabIndex = 12;
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
            this.gridColOrderID,
            this.gridColOrderNo,
            this.gridColcInvCode,
            this.gridColcInvName,
            this.gridColcInvStd,
            this.gridColiQuantity,
            this.gridColiNum,
            this.gridColOrderType,
            this.gridColcDefWareHouse,
            this.gridColbUsed,
            this.gridColmoid,
            this.gridColiArrQty1,
            this.gridColiArrNum1,
            this.gridColNowQuantity,
            this.gridColNowNum,
            this.gridColFaChuCaiLiaoQty,
            this.gridColFaChuCaiLiaoNum,
            this.gridColcComUnitName1,
            this.gridColcComUnitName2,
            this.gridCol原币无税单价,
            this.gridCol本币无税单价,
            this.gridCol税率,
            this.gridCol业务员,
            this.gridColcDepCode,
            this.gridColfInExcess,
            this.gridColbChoose,
            this.gridColiWIPtype});
            this.gridView1.GridControl = this.gridControl1;
            this.gridView1.IndicatorWidth = 40;
            this.gridView1.Name = "gridView1";
            this.gridView1.OptionsCustomization.AllowFilter = false;
            this.gridView1.OptionsCustomization.AllowSort = false;
            this.gridView1.OptionsView.EnableAppearanceEvenRow = true;
            this.gridView1.OptionsView.EnableAppearanceOddRow = true;
            this.gridView1.OptionsView.ShowFooter = true;
            this.gridView1.OptionsView.ShowGroupPanel = false;
            this.gridView1.CellValueChanging += new DevExpress.XtraGrid.Views.Base.CellValueChangedEventHandler(this.gridView1_CellValueChanged);
            this.gridView1.CellValueChanged += new DevExpress.XtraGrid.Views.Base.CellValueChangedEventHandler(this.gridView1_CellValueChanged);
            this.gridView1.RowCellStyle += new DevExpress.XtraGrid.Views.Grid.RowCellStyleEventHandler(this.gridView1_RowCellStyle);
            this.gridView1.CustomDrawRowIndicator += new DevExpress.XtraGrid.Views.Grid.RowIndicatorCustomDrawEventHandler(this.gridView1_CustomDrawRowIndicator);
            // 
            // gridColOrderID
            // 
            this.gridColOrderID.Caption = "单据ID号";
            this.gridColOrderID.FieldName = "OrderID";
            this.gridColOrderID.Name = "gridColOrderID";
            this.gridColOrderID.OptionsColumn.AllowEdit = false;
            this.gridColOrderID.OptionsColumn.AllowSort = DevExpress.Utils.DefaultBoolean.False;
            // 
            // gridColOrderNo
            // 
            this.gridColOrderNo.Caption = "订单号";
            this.gridColOrderNo.FieldName = "OrderNo";
            this.gridColOrderNo.Name = "gridColOrderNo";
            this.gridColOrderNo.OptionsColumn.AllowEdit = false;
            this.gridColOrderNo.OptionsColumn.AllowSort = DevExpress.Utils.DefaultBoolean.False;
            this.gridColOrderNo.Visible = true;
            this.gridColOrderNo.VisibleIndex = 0;
            this.gridColOrderNo.Width = 62;
            // 
            // gridColcInvCode
            // 
            this.gridColcInvCode.Caption = "存货编码";
            this.gridColcInvCode.FieldName = "cInvCode";
            this.gridColcInvCode.Name = "gridColcInvCode";
            this.gridColcInvCode.OptionsColumn.AllowEdit = false;
            this.gridColcInvCode.OptionsColumn.AllowSort = DevExpress.Utils.DefaultBoolean.False;
            this.gridColcInvCode.Visible = true;
            this.gridColcInvCode.VisibleIndex = 1;
            this.gridColcInvCode.Width = 62;
            // 
            // gridColcInvName
            // 
            this.gridColcInvName.Caption = "存货名称";
            this.gridColcInvName.FieldName = "cInvName";
            this.gridColcInvName.Name = "gridColcInvName";
            this.gridColcInvName.OptionsColumn.AllowEdit = false;
            this.gridColcInvName.OptionsColumn.AllowSort = DevExpress.Utils.DefaultBoolean.False;
            this.gridColcInvName.Visible = true;
            this.gridColcInvName.VisibleIndex = 2;
            this.gridColcInvName.Width = 62;
            // 
            // gridColcInvStd
            // 
            this.gridColcInvStd.Caption = "规格型号";
            this.gridColcInvStd.FieldName = "cInvStd";
            this.gridColcInvStd.Name = "gridColcInvStd";
            this.gridColcInvStd.OptionsColumn.AllowEdit = false;
            this.gridColcInvStd.OptionsColumn.AllowSort = DevExpress.Utils.DefaultBoolean.False;
            this.gridColcInvStd.Visible = true;
            this.gridColcInvStd.VisibleIndex = 3;
            this.gridColcInvStd.Width = 62;
            // 
            // gridColiQuantity
            // 
            this.gridColiQuantity.Caption = "订单数量";
            this.gridColiQuantity.FieldName = "iQuantity";
            this.gridColiQuantity.Name = "gridColiQuantity";
            this.gridColiQuantity.OptionsColumn.AllowEdit = false;
            this.gridColiQuantity.OptionsColumn.AllowSort = DevExpress.Utils.DefaultBoolean.False;
            this.gridColiQuantity.SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Sum;
            this.gridColiQuantity.Visible = true;
            this.gridColiQuantity.VisibleIndex = 7;
            this.gridColiQuantity.Width = 60;
            // 
            // gridColiNum
            // 
            this.gridColiNum.Caption = "订单件数";
            this.gridColiNum.FieldName = "iNum";
            this.gridColiNum.Name = "gridColiNum";
            this.gridColiNum.OptionsColumn.AllowEdit = false;
            this.gridColiNum.OptionsColumn.AllowSort = DevExpress.Utils.DefaultBoolean.False;
            this.gridColiNum.SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Sum;
            this.gridColiNum.Visible = true;
            this.gridColiNum.VisibleIndex = 8;
            this.gridColiNum.Width = 60;
            // 
            // gridColOrderType
            // 
            this.gridColOrderType.Caption = "订单类型";
            this.gridColOrderType.FieldName = "OrderType";
            this.gridColOrderType.Name = "gridColOrderType";
            this.gridColOrderType.OptionsColumn.AllowEdit = false;
            this.gridColOrderType.OptionsColumn.AllowSort = DevExpress.Utils.DefaultBoolean.False;
            // 
            // gridColcDefWareHouse
            // 
            this.gridColcDefWareHouse.Caption = "仓库";
            this.gridColcDefWareHouse.ColumnEdit = this.LookUpWH;
            this.gridColcDefWareHouse.FieldName = "cDefWareHouse";
            this.gridColcDefWareHouse.Name = "gridColcDefWareHouse";
            this.gridColcDefWareHouse.OptionsColumn.AllowSort = DevExpress.Utils.DefaultBoolean.False;
            this.gridColcDefWareHouse.Visible = true;
            this.gridColcDefWareHouse.VisibleIndex = 4;
            this.gridColcDefWareHouse.Width = 53;
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
            // gridColbUsed
            // 
            this.gridColbUsed.Caption = "已使用";
            this.gridColbUsed.FieldName = "bUsed";
            this.gridColbUsed.Name = "gridColbUsed";
            this.gridColbUsed.OptionsColumn.AllowEdit = false;
            this.gridColbUsed.OptionsColumn.AllowSort = DevExpress.Utils.DefaultBoolean.False;
            // 
            // gridColmoid
            // 
            this.gridColmoid.Caption = "采购订单主表标志";
            this.gridColmoid.FieldName = "moid";
            this.gridColmoid.Name = "gridColmoid";
            this.gridColmoid.OptionsColumn.AllowEdit = false;
            this.gridColmoid.OptionsColumn.AllowSort = DevExpress.Utils.DefaultBoolean.False;
            // 
            // gridColiArrQty1
            // 
            this.gridColiArrQty1.Caption = "应收应发数量";
            this.gridColiArrQty1.FieldName = "iArrQty1";
            this.gridColiArrQty1.Name = "gridColiArrQty1";
            this.gridColiArrQty1.OptionsColumn.AllowEdit = false;
            this.gridColiArrQty1.OptionsColumn.AllowSort = DevExpress.Utils.DefaultBoolean.False;
            this.gridColiArrQty1.SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Sum;
            this.gridColiArrQty1.Visible = true;
            this.gridColiArrQty1.VisibleIndex = 9;
            this.gridColiArrQty1.Width = 60;
            // 
            // gridColiArrNum1
            // 
            this.gridColiArrNum1.Caption = "应收应发件数";
            this.gridColiArrNum1.FieldName = "iArrNum1";
            this.gridColiArrNum1.Name = "gridColiArrNum1";
            this.gridColiArrNum1.OptionsColumn.AllowEdit = false;
            this.gridColiArrNum1.OptionsColumn.AllowSort = DevExpress.Utils.DefaultBoolean.False;
            this.gridColiArrNum1.SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Sum;
            this.gridColiArrNum1.Visible = true;
            this.gridColiArrNum1.VisibleIndex = 10;
            this.gridColiArrNum1.Width = 60;
            // 
            // gridColNowQuantity
            // 
            this.gridColNowQuantity.AppearanceHeader.ForeColor = System.Drawing.Color.Blue;
            this.gridColNowQuantity.AppearanceHeader.Options.UseForeColor = true;
            this.gridColNowQuantity.Caption = "本次入库数量";
            this.gridColNowQuantity.FieldName = "NowQuantity";
            this.gridColNowQuantity.Name = "gridColNowQuantity";
            this.gridColNowQuantity.OptionsColumn.AllowSort = DevExpress.Utils.DefaultBoolean.False;
            this.gridColNowQuantity.SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Sum;
            this.gridColNowQuantity.Visible = true;
            this.gridColNowQuantity.VisibleIndex = 11;
            this.gridColNowQuantity.Width = 60;
            // 
            // gridColNowNum
            // 
            this.gridColNowNum.Caption = "本次入库件数";
            this.gridColNowNum.FieldName = "NowNum";
            this.gridColNowNum.Name = "gridColNowNum";
            this.gridColNowNum.OptionsColumn.AllowSort = DevExpress.Utils.DefaultBoolean.False;
            this.gridColNowNum.SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Sum;
            this.gridColNowNum.Visible = true;
            this.gridColNowNum.VisibleIndex = 12;
            this.gridColNowNum.Width = 70;
            // 
            // gridColFaChuCaiLiaoQty
            // 
            this.gridColFaChuCaiLiaoQty.Caption = "委外发出材料数量";
            this.gridColFaChuCaiLiaoQty.FieldName = "FaChuCaiLiaoQty";
            this.gridColFaChuCaiLiaoQty.Name = "gridColFaChuCaiLiaoQty";
            this.gridColFaChuCaiLiaoQty.OptionsColumn.AllowEdit = false;
            this.gridColFaChuCaiLiaoQty.OptionsColumn.AllowSort = DevExpress.Utils.DefaultBoolean.False;
            this.gridColFaChuCaiLiaoQty.SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Sum;
            // 
            // gridColFaChuCaiLiaoNum
            // 
            this.gridColFaChuCaiLiaoNum.Caption = "委外发出材料件数";
            this.gridColFaChuCaiLiaoNum.FieldName = "FaChuCaiLiaoNum";
            this.gridColFaChuCaiLiaoNum.Name = "gridColFaChuCaiLiaoNum";
            this.gridColFaChuCaiLiaoNum.OptionsColumn.AllowEdit = false;
            this.gridColFaChuCaiLiaoNum.OptionsColumn.AllowSort = DevExpress.Utils.DefaultBoolean.False;
            this.gridColFaChuCaiLiaoNum.SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Sum;
            // 
            // gridColcComUnitName1
            // 
            this.gridColcComUnitName1.Caption = "计量单位";
            this.gridColcComUnitName1.FieldName = "cComUnitName1";
            this.gridColcComUnitName1.Name = "gridColcComUnitName1";
            this.gridColcComUnitName1.OptionsColumn.AllowEdit = false;
            this.gridColcComUnitName1.OptionsColumn.AllowSort = DevExpress.Utils.DefaultBoolean.False;
            this.gridColcComUnitName1.Visible = true;
            this.gridColcComUnitName1.VisibleIndex = 5;
            this.gridColcComUnitName1.Width = 67;
            // 
            // gridColcComUnitName2
            // 
            this.gridColcComUnitName2.Caption = "辅计量";
            this.gridColcComUnitName2.FieldName = "cComUnitName2";
            this.gridColcComUnitName2.Name = "gridColcComUnitName2";
            this.gridColcComUnitName2.OptionsColumn.AllowEdit = false;
            this.gridColcComUnitName2.OptionsColumn.AllowSort = DevExpress.Utils.DefaultBoolean.False;
            this.gridColcComUnitName2.Visible = true;
            this.gridColcComUnitName2.VisibleIndex = 6;
            this.gridColcComUnitName2.Width = 70;
            // 
            // gridCol原币无税单价
            // 
            this.gridCol原币无税单价.Caption = "原币无税单价";
            this.gridCol原币无税单价.FieldName = "原币无税单价";
            this.gridCol原币无税单价.Name = "gridCol原币无税单价";
            this.gridCol原币无税单价.OptionsColumn.AllowEdit = false;
            this.gridCol原币无税单价.OptionsColumn.AllowSort = DevExpress.Utils.DefaultBoolean.False;
            // 
            // gridCol本币无税单价
            // 
            this.gridCol本币无税单价.Caption = "本币无税单价";
            this.gridCol本币无税单价.FieldName = "本币无税单价";
            this.gridCol本币无税单价.Name = "gridCol本币无税单价";
            this.gridCol本币无税单价.OptionsColumn.AllowEdit = false;
            this.gridCol本币无税单价.OptionsColumn.AllowSort = DevExpress.Utils.DefaultBoolean.False;
            // 
            // gridCol税率
            // 
            this.gridCol税率.Caption = "税率";
            this.gridCol税率.FieldName = "税率";
            this.gridCol税率.Name = "gridCol税率";
            this.gridCol税率.OptionsColumn.AllowEdit = false;
            this.gridCol税率.OptionsColumn.AllowSort = DevExpress.Utils.DefaultBoolean.False;
            // 
            // gridCol业务员
            // 
            this.gridCol业务员.Caption = "业务员";
            this.gridCol业务员.FieldName = "业务员";
            this.gridCol业务员.Name = "gridCol业务员";
            this.gridCol业务员.OptionsColumn.AllowEdit = false;
            this.gridCol业务员.OptionsColumn.AllowSort = DevExpress.Utils.DefaultBoolean.False;
            // 
            // gridColcDepCode
            // 
            this.gridColcDepCode.Caption = "部门";
            this.gridColcDepCode.FieldName = "cDepCode";
            this.gridColcDepCode.Name = "gridColcDepCode";
            this.gridColcDepCode.OptionsColumn.AllowEdit = false;
            this.gridColcDepCode.OptionsColumn.AllowSort = DevExpress.Utils.DefaultBoolean.False;
            this.gridColcDepCode.Visible = true;
            this.gridColcDepCode.VisibleIndex = 13;
            this.gridColcDepCode.Width = 72;
            // 
            // gridColfInExcess
            // 
            this.gridColfInExcess.Caption = "入库超额上限";
            this.gridColfInExcess.FieldName = "fInExcess";
            this.gridColfInExcess.Name = "gridColfInExcess";
            this.gridColfInExcess.OptionsColumn.AllowEdit = false;
            this.gridColfInExcess.OptionsColumn.AllowMerge = DevExpress.Utils.DefaultBoolean.False;
            this.gridColfInExcess.OptionsColumn.AllowSort = DevExpress.Utils.DefaultBoolean.False;
            this.gridColfInExcess.Visible = true;
            this.gridColfInExcess.VisibleIndex = 14;
            // 
            // gridColbChoose
            // 
            this.gridColbChoose.Caption = "错误数据";
            this.gridColbChoose.FieldName = "bChoose";
            this.gridColbChoose.Name = "gridColbChoose";
            this.gridColbChoose.OptionsColumn.AllowEdit = false;
            this.gridColbChoose.OptionsColumn.AllowMerge = DevExpress.Utils.DefaultBoolean.False;
            this.gridColbChoose.OptionsColumn.AllowSort = DevExpress.Utils.DefaultBoolean.False;
            // 
            // gridColiWIPtype
            // 
            this.gridColiWIPtype.Caption = "供应类型";
            this.gridColiWIPtype.FieldName = "iWIPtype";
            this.gridColiWIPtype.Name = "gridColiWIPtype";
            this.gridColiWIPtype.OptionsColumn.AllowEdit = false;
            this.gridColiWIPtype.OptionsColumn.AllowMerge = DevExpress.Utils.DefaultBoolean.False;
            this.gridColiWIPtype.OptionsColumn.AllowSort = DevExpress.Utils.DefaultBoolean.False;
            this.gridColiWIPtype.Visible = true;
            this.gridColiWIPtype.VisibleIndex = 15;
            // 
            // date1
            // 
            this.date1.EditValue = new System.DateTime(2011, 10, 24, 0, 0, 0, 0);
            this.date1.Location = new System.Drawing.Point(843, 34);
            this.date1.Name = "date1";
            this.date1.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.date1.Size = new System.Drawing.Size(144, 21);
            this.date1.TabIndex = 75;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(782, 37);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(55, 14);
            this.label11.TabIndex = 74;
            this.label11.Text = "单据日期";
            // 
            // FrmArrivalVouchIn
            // 
            this.Appearance.BackColor = System.Drawing.SystemColors.Control;
            this.Appearance.Options.UseBackColor = true;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1028, 363);
            this.Controls.Add(this.date1);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.gridControl1);
            this.Controls.Add(this.txtRowCount);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtBarCode);
            this.Controls.Add(this.label1);
            this.Name = "FrmArrivalVouchIn";
            this.Text = "FrmRDIn";
            this.Load += new System.EventHandler(this.FrmArrivalVouchIn_Load);
            this.Activated += new System.EventHandler(this.FrmArrivalVouchIn_Activated);
            this.Controls.SetChildIndex(this.label1, 0);
            this.Controls.SetChildIndex(this.txtBarCode, 0);
            this.Controls.SetChildIndex(this.label2, 0);
            this.Controls.SetChildIndex(this.txtRowCount, 0);
            this.Controls.SetChildIndex(this.gridControl1, 0);
            this.Controls.SetChildIndex(this.label11, 0);
            this.Controls.SetChildIndex(this.date1, 0);
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.LookUpWH)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.date1.Properties)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtBarCode;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtRowCount;
        private DevExpress.XtraGrid.GridControl gridControl1;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView1;
        private DevExpress.XtraGrid.Columns.GridColumn gridColOrderID;
        private DevExpress.XtraGrid.Columns.GridColumn gridColOrderNo;
        private DevExpress.XtraGrid.Columns.GridColumn gridColcInvCode;
        private DevExpress.XtraGrid.Columns.GridColumn gridColcInvName;
        private DevExpress.XtraGrid.Columns.GridColumn gridColcInvStd;
        private DevExpress.XtraGrid.Columns.GridColumn gridColiQuantity;
        private DevExpress.XtraGrid.Columns.GridColumn gridColiNum;
        private DevExpress.XtraGrid.Columns.GridColumn gridColOrderType;
        private DevExpress.XtraGrid.Columns.GridColumn gridColcDefWareHouse;
        private DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit LookUpWH;
        private DevExpress.XtraGrid.Columns.GridColumn gridColbUsed;
        private DevExpress.XtraGrid.Columns.GridColumn gridColmoid;
        private DevExpress.XtraGrid.Columns.GridColumn gridColiArrQty1;
        private DevExpress.XtraGrid.Columns.GridColumn gridColiArrNum1;
        private DevExpress.XtraGrid.Columns.GridColumn gridColNowQuantity;
        private DevExpress.XtraGrid.Columns.GridColumn gridColNowNum;
        private DevExpress.XtraGrid.Columns.GridColumn gridColFaChuCaiLiaoQty;
        private DevExpress.XtraGrid.Columns.GridColumn gridColFaChuCaiLiaoNum;
        private DevExpress.XtraGrid.Columns.GridColumn gridColcComUnitName1;
        private DevExpress.XtraGrid.Columns.GridColumn gridColcComUnitName2;
        private DevExpress.XtraGrid.Columns.GridColumn gridCol原币无税单价;
        private DevExpress.XtraGrid.Columns.GridColumn gridCol本币无税单价;
        private DevExpress.XtraGrid.Columns.GridColumn gridCol税率;
        private DevExpress.XtraGrid.Columns.GridColumn gridCol业务员;
        private DevExpress.XtraGrid.Columns.GridColumn gridColcDepCode;
        private DevExpress.XtraGrid.Columns.GridColumn gridColfInExcess;
        private DevExpress.XtraGrid.Columns.GridColumn gridColbChoose;
        private DevExpress.XtraGrid.Columns.GridColumn gridColiWIPtype;
        private DevExpress.XtraEditors.DateEdit date1;
        private System.Windows.Forms.Label label11;
    }
}