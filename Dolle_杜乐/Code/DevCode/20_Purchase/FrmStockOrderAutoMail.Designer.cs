﻿namespace Purchase
{
    partial class FrmStockOrderAutoMail
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
            this.components = new System.ComponentModel.Container();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.gridControl2 = new DevExpress.XtraGrid.GridControl();
            this.gridView2 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.gridColbChoose = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColcPOID = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColdPODate = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColcInvCode = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColcInvName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColcInvStd = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColReturnDate1 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.ItemDateEdit1 = new DevExpress.XtraEditors.Repository.RepositoryItemDateEdit();
            this.gridColReturnDate2 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColiQuantity = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColiNum = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColcItemCode = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColiTaxPrice = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColiUnitPrice = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColiSum = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColiMoney = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColiPerTaxRate = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColPOID = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColdArriveDate = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColReturnAuditCount = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColReturnApply = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColReturnAuditUID = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColReturnAuditDate = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColReturnAudit = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColID = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColbAgain = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColcVenName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColcMaker = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColcVenCode = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColcDepCode = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColcDepName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColReturnRemark = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColbLock = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColLocker = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColLockDate = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColiQtyUnIn = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColiNumUnIn = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColReturnUid = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColReturnUidDate = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridCol初期计划日期 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridCol生产计划需求日期 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColbTomato = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColUnLockTomatoUser = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColUnLockTomatoDate = new DevExpress.XtraGrid.Columns.GridColumn();
            //((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dsPrint)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dsForm)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtSel)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ItemDateEdit1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ItemDateEdit1.VistaTimeProperties)).BeginInit();
            this.SuspendLayout();
            // 
            // timer1
            // 
            this.timer1.Interval = 1000;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // gridControl2
            // 
            this.gridControl2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridControl2.EmbeddedNavigator.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.gridControl2.Location = new System.Drawing.Point(0, 34);
            this.gridControl2.MainView = this.gridView2;
            this.gridControl2.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.gridControl2.Name = "gridControl2";
            this.gridControl2.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.ItemDateEdit1});
            this.gridControl2.Size = new System.Drawing.Size(1113, 488);
            this.gridControl2.TabIndex = 51;
            this.gridControl2.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView2});
            // 
            // gridView2
            // 
            this.gridView2.Appearance.ColumnFilterButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(236)))), ((int)(((byte)(232)))), ((int)(((byte)(201)))));
            this.gridView2.Appearance.ColumnFilterButton.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(236)))), ((int)(((byte)(232)))), ((int)(((byte)(201)))));
            this.gridView2.Appearance.ColumnFilterButton.ForeColor = System.Drawing.Color.Black;
            this.gridView2.Appearance.ColumnFilterButton.Options.UseBackColor = true;
            this.gridView2.Appearance.ColumnFilterButton.Options.UseBorderColor = true;
            this.gridView2.Appearance.ColumnFilterButton.Options.UseForeColor = true;
            this.gridView2.Appearance.ColumnFilterButtonActive.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(221)))), ((int)(((byte)(231)))), ((int)(((byte)(234)))));
            this.gridView2.Appearance.ColumnFilterButtonActive.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(221)))), ((int)(((byte)(231)))), ((int)(((byte)(234)))));
            this.gridView2.Appearance.ColumnFilterButtonActive.ForeColor = System.Drawing.Color.Black;
            this.gridView2.Appearance.ColumnFilterButtonActive.Options.UseBackColor = true;
            this.gridView2.Appearance.ColumnFilterButtonActive.Options.UseBorderColor = true;
            this.gridView2.Appearance.ColumnFilterButtonActive.Options.UseForeColor = true;
            this.gridView2.Appearance.Empty.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(236)))), ((int)(((byte)(232)))), ((int)(((byte)(201)))));
            this.gridView2.Appearance.Empty.BackColor2 = System.Drawing.Color.White;
            this.gridView2.Appearance.Empty.Options.UseBackColor = true;
            this.gridView2.Appearance.EvenRow.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(221)))), ((int)(((byte)(231)))), ((int)(((byte)(234)))));
            this.gridView2.Appearance.EvenRow.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(221)))), ((int)(((byte)(231)))), ((int)(((byte)(234)))));
            this.gridView2.Appearance.EvenRow.ForeColor = System.Drawing.Color.Black;
            this.gridView2.Appearance.EvenRow.Options.UseBackColor = true;
            this.gridView2.Appearance.EvenRow.Options.UseBorderColor = true;
            this.gridView2.Appearance.EvenRow.Options.UseForeColor = true;
            this.gridView2.Appearance.FilterCloseButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(216)))), ((int)(((byte)(209)))), ((int)(((byte)(179)))));
            this.gridView2.Appearance.FilterCloseButton.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(216)))), ((int)(((byte)(209)))), ((int)(((byte)(179)))));
            this.gridView2.Appearance.FilterCloseButton.ForeColor = System.Drawing.Color.Black;
            this.gridView2.Appearance.FilterCloseButton.Options.UseBackColor = true;
            this.gridView2.Appearance.FilterCloseButton.Options.UseBorderColor = true;
            this.gridView2.Appearance.FilterCloseButton.Options.UseForeColor = true;
            this.gridView2.Appearance.FilterPanel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(236)))), ((int)(((byte)(232)))), ((int)(((byte)(201)))));
            this.gridView2.Appearance.FilterPanel.BackColor2 = System.Drawing.Color.White;
            this.gridView2.Appearance.FilterPanel.ForeColor = System.Drawing.Color.Black;
            this.gridView2.Appearance.FilterPanel.Options.UseBackColor = true;
            this.gridView2.Appearance.FilterPanel.Options.UseForeColor = true;
            this.gridView2.Appearance.FixedLine.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(122)))), ((int)(((byte)(114)))), ((int)(((byte)(113)))));
            this.gridView2.Appearance.FixedLine.Options.UseBackColor = true;
            this.gridView2.Appearance.FocusedCell.BackColor = System.Drawing.Color.White;
            this.gridView2.Appearance.FocusedCell.ForeColor = System.Drawing.Color.Black;
            this.gridView2.Appearance.FocusedCell.Options.UseBackColor = true;
            this.gridView2.Appearance.FocusedCell.Options.UseForeColor = true;
            this.gridView2.Appearance.FocusedRow.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(200)))), ((int)(((byte)(192)))), ((int)(((byte)(157)))));
            this.gridView2.Appearance.FocusedRow.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(219)))), ((int)(((byte)(188)))));
            this.gridView2.Appearance.FocusedRow.ForeColor = System.Drawing.Color.Black;
            this.gridView2.Appearance.FocusedRow.Options.UseBackColor = true;
            this.gridView2.Appearance.FocusedRow.Options.UseBorderColor = true;
            this.gridView2.Appearance.FocusedRow.Options.UseForeColor = true;
            this.gridView2.Appearance.FooterPanel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(216)))), ((int)(((byte)(209)))), ((int)(((byte)(170)))));
            this.gridView2.Appearance.FooterPanel.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(216)))), ((int)(((byte)(209)))), ((int)(((byte)(170)))));
            this.gridView2.Appearance.FooterPanel.ForeColor = System.Drawing.Color.Black;
            this.gridView2.Appearance.FooterPanel.Options.UseBackColor = true;
            this.gridView2.Appearance.FooterPanel.Options.UseBorderColor = true;
            this.gridView2.Appearance.FooterPanel.Options.UseForeColor = true;
            this.gridView2.Appearance.GroupButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(216)))), ((int)(((byte)(209)))), ((int)(((byte)(179)))));
            this.gridView2.Appearance.GroupButton.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(216)))), ((int)(((byte)(209)))), ((int)(((byte)(179)))));
            this.gridView2.Appearance.GroupButton.Options.UseBackColor = true;
            this.gridView2.Appearance.GroupButton.Options.UseBorderColor = true;
            this.gridView2.Appearance.GroupFooter.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(236)))), ((int)(((byte)(232)))), ((int)(((byte)(201)))));
            this.gridView2.Appearance.GroupFooter.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(236)))), ((int)(((byte)(232)))), ((int)(((byte)(201)))));
            this.gridView2.Appearance.GroupFooter.ForeColor = System.Drawing.Color.Black;
            this.gridView2.Appearance.GroupFooter.Options.UseBackColor = true;
            this.gridView2.Appearance.GroupFooter.Options.UseBorderColor = true;
            this.gridView2.Appearance.GroupFooter.Options.UseForeColor = true;
            this.gridView2.Appearance.GroupPanel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(246)))), ((int)(((byte)(242)))), ((int)(((byte)(213)))));
            this.gridView2.Appearance.GroupPanel.BackColor2 = System.Drawing.Color.White;
            this.gridView2.Appearance.GroupPanel.ForeColor = System.Drawing.Color.Black;
            this.gridView2.Appearance.GroupPanel.Options.UseBackColor = true;
            this.gridView2.Appearance.GroupPanel.Options.UseForeColor = true;
            this.gridView2.Appearance.GroupRow.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(236)))), ((int)(((byte)(232)))), ((int)(((byte)(201)))));
            this.gridView2.Appearance.GroupRow.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(236)))), ((int)(((byte)(232)))), ((int)(((byte)(201)))));
            this.gridView2.Appearance.GroupRow.ForeColor = System.Drawing.Color.Black;
            this.gridView2.Appearance.GroupRow.Options.UseBackColor = true;
            this.gridView2.Appearance.GroupRow.Options.UseBorderColor = true;
            this.gridView2.Appearance.GroupRow.Options.UseForeColor = true;
            this.gridView2.Appearance.HeaderPanel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(216)))), ((int)(((byte)(209)))), ((int)(((byte)(170)))));
            this.gridView2.Appearance.HeaderPanel.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(216)))), ((int)(((byte)(209)))), ((int)(((byte)(170)))));
            this.gridView2.Appearance.HeaderPanel.ForeColor = System.Drawing.Color.Black;
            this.gridView2.Appearance.HeaderPanel.Options.UseBackColor = true;
            this.gridView2.Appearance.HeaderPanel.Options.UseBorderColor = true;
            this.gridView2.Appearance.HeaderPanel.Options.UseForeColor = true;
            this.gridView2.Appearance.HideSelectionRow.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(237)))), ((int)(((byte)(230)))), ((int)(((byte)(203)))));
            this.gridView2.Appearance.HideSelectionRow.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(237)))), ((int)(((byte)(230)))), ((int)(((byte)(203)))));
            this.gridView2.Appearance.HideSelectionRow.ForeColor = System.Drawing.Color.Black;
            this.gridView2.Appearance.HideSelectionRow.Options.UseBackColor = true;
            this.gridView2.Appearance.HideSelectionRow.Options.UseBorderColor = true;
            this.gridView2.Appearance.HideSelectionRow.Options.UseForeColor = true;
            this.gridView2.Appearance.HorzLine.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(216)))), ((int)(((byte)(209)))), ((int)(((byte)(170)))));
            this.gridView2.Appearance.HorzLine.Options.UseBackColor = true;
            this.gridView2.Appearance.OddRow.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(242)))), ((int)(((byte)(244)))), ((int)(((byte)(236)))));
            this.gridView2.Appearance.OddRow.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(242)))), ((int)(((byte)(244)))), ((int)(((byte)(236)))));
            this.gridView2.Appearance.OddRow.ForeColor = System.Drawing.Color.Black;
            this.gridView2.Appearance.OddRow.Options.UseBackColor = true;
            this.gridView2.Appearance.OddRow.Options.UseBorderColor = true;
            this.gridView2.Appearance.OddRow.Options.UseForeColor = true;
            this.gridView2.Appearance.Preview.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(251)))), ((int)(((byte)(252)))), ((int)(((byte)(247)))));
            this.gridView2.Appearance.Preview.Font = new System.Drawing.Font("Verdana", 7.5F);
            this.gridView2.Appearance.Preview.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(148)))), ((int)(((byte)(148)))), ((int)(((byte)(148)))));
            this.gridView2.Appearance.Preview.Options.UseBackColor = true;
            this.gridView2.Appearance.Preview.Options.UseFont = true;
            this.gridView2.Appearance.Preview.Options.UseForeColor = true;
            this.gridView2.Appearance.Row.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(242)))), ((int)(((byte)(244)))), ((int)(((byte)(236)))));
            this.gridView2.Appearance.Row.ForeColor = System.Drawing.Color.Black;
            this.gridView2.Appearance.Row.Options.UseBackColor = true;
            this.gridView2.Appearance.Row.Options.UseForeColor = true;
            this.gridView2.Appearance.RowSeparator.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(236)))), ((int)(((byte)(232)))), ((int)(((byte)(201)))));
            this.gridView2.Appearance.RowSeparator.BackColor2 = System.Drawing.Color.White;
            this.gridView2.Appearance.RowSeparator.Options.UseBackColor = true;
            this.gridView2.Appearance.SelectedRow.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(221)))), ((int)(((byte)(215)))), ((int)(((byte)(188)))));
            this.gridView2.Appearance.SelectedRow.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(237)))), ((int)(((byte)(230)))), ((int)(((byte)(203)))));
            this.gridView2.Appearance.SelectedRow.ForeColor = System.Drawing.Color.Black;
            this.gridView2.Appearance.SelectedRow.Options.UseBackColor = true;
            this.gridView2.Appearance.SelectedRow.Options.UseBorderColor = true;
            this.gridView2.Appearance.SelectedRow.Options.UseForeColor = true;
            this.gridView2.Appearance.TopNewRow.BackColor = System.Drawing.Color.White;
            this.gridView2.Appearance.TopNewRow.Options.UseBackColor = true;
            this.gridView2.Appearance.VertLine.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(216)))), ((int)(((byte)(209)))), ((int)(((byte)(170)))));
            this.gridView2.Appearance.VertLine.Options.UseBackColor = true;
            this.gridView2.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.gridColbChoose,
            this.gridColcPOID,
            this.gridColdPODate,
            this.gridColcInvCode,
            this.gridColcInvName,
            this.gridColcInvStd,
            this.gridColReturnDate1,
            this.gridColReturnDate2,
            this.gridColiQuantity,
            this.gridColiNum,
            this.gridColcItemCode,
            this.gridColiTaxPrice,
            this.gridColiUnitPrice,
            this.gridColiSum,
            this.gridColiMoney,
            this.gridColiPerTaxRate,
            this.gridColPOID,
            this.gridColdArriveDate,
            this.gridColReturnAuditCount,
            this.gridColReturnApply,
            this.gridColReturnAuditUID,
            this.gridColReturnAuditDate,
            this.gridColReturnAudit,
            this.gridColID,
            this.gridColbAgain,
            this.gridColcVenName,
            this.gridColcMaker,
            this.gridColcVenCode,
            this.gridColcDepCode,
            this.gridColcDepName,
            this.gridColReturnRemark,
            this.gridColbLock,
            this.gridColLocker,
            this.gridColLockDate,
            this.gridColiQtyUnIn,
            this.gridColiNumUnIn,
            this.gridColReturnUid,
            this.gridColReturnUidDate,
            this.gridCol初期计划日期,
            this.gridCol生产计划需求日期,
            this.gridColbTomato,
            this.gridColUnLockTomatoUser,
            this.gridColUnLockTomatoDate});
            this.gridView2.CustomizationFormBounds = new System.Drawing.Rectangle(816, 318, 208, 177);
            this.gridView2.GridControl = this.gridControl2;
            this.gridView2.IndicatorWidth = 40;
            this.gridView2.Name = "gridView2";
            this.gridView2.OptionsCustomization.AllowSort = false;
            this.gridView2.OptionsView.AllowCellMerge = true;
            this.gridView2.OptionsView.ColumnAutoWidth = false;
            this.gridView2.OptionsView.EnableAppearanceEvenRow = true;
            this.gridView2.OptionsView.EnableAppearanceOddRow = true;
            this.gridView2.OptionsView.ShowGroupPanel = false;
            this.gridView2.CustomDrawRowIndicator += new DevExpress.XtraGrid.Views.Grid.RowIndicatorCustomDrawEventHandler(this.gridView2_CustomDrawRowIndicator);
            // 
            // gridColbChoose
            // 
            this.gridColbChoose.Caption = "选择";
            this.gridColbChoose.FieldName = "bChoose";
            this.gridColbChoose.Name = "gridColbChoose";
            this.gridColbChoose.OptionsColumn.AllowEdit = false;
            this.gridColbChoose.OptionsColumn.AllowMerge = DevExpress.Utils.DefaultBoolean.False;
            this.gridColbChoose.OptionsColumn.AllowSort = DevExpress.Utils.DefaultBoolean.True;
            this.gridColbChoose.OptionsFilter.AllowFilter = false;
            this.gridColbChoose.Visible = true;
            this.gridColbChoose.VisibleIndex = 0;
            this.gridColbChoose.Width = 22;
            // 
            // gridColcPOID
            // 
            this.gridColcPOID.Caption = "订单号";
            this.gridColcPOID.FieldName = "cPOID";
            this.gridColcPOID.Name = "gridColcPOID";
            this.gridColcPOID.OptionsColumn.AllowEdit = false;
            this.gridColcPOID.OptionsColumn.AllowSort = DevExpress.Utils.DefaultBoolean.True;
            this.gridColcPOID.Visible = true;
            this.gridColcPOID.VisibleIndex = 2;
            // 
            // gridColdPODate
            // 
            this.gridColdPODate.Caption = "订单日期";
            this.gridColdPODate.FieldName = "dPODate";
            this.gridColdPODate.Name = "gridColdPODate";
            this.gridColdPODate.OptionsColumn.AllowEdit = false;
            this.gridColdPODate.OptionsColumn.AllowMerge = DevExpress.Utils.DefaultBoolean.False;
            this.gridColdPODate.OptionsColumn.AllowSort = DevExpress.Utils.DefaultBoolean.True;
            this.gridColdPODate.Visible = true;
            this.gridColdPODate.VisibleIndex = 3;
            // 
            // gridColcInvCode
            // 
            this.gridColcInvCode.Caption = "存货编码";
            this.gridColcInvCode.FieldName = "cInvCode";
            this.gridColcInvCode.Name = "gridColcInvCode";
            this.gridColcInvCode.OptionsColumn.AllowEdit = false;
            this.gridColcInvCode.OptionsColumn.AllowMerge = DevExpress.Utils.DefaultBoolean.False;
            this.gridColcInvCode.OptionsColumn.AllowSort = DevExpress.Utils.DefaultBoolean.True;
            this.gridColcInvCode.Visible = true;
            this.gridColcInvCode.VisibleIndex = 5;
            // 
            // gridColcInvName
            // 
            this.gridColcInvName.Caption = "存货名称";
            this.gridColcInvName.FieldName = "cInvName";
            this.gridColcInvName.Name = "gridColcInvName";
            this.gridColcInvName.OptionsColumn.AllowEdit = false;
            this.gridColcInvName.OptionsColumn.AllowMerge = DevExpress.Utils.DefaultBoolean.False;
            this.gridColcInvName.OptionsColumn.AllowSort = DevExpress.Utils.DefaultBoolean.True;
            this.gridColcInvName.Visible = true;
            this.gridColcInvName.VisibleIndex = 6;
            // 
            // gridColcInvStd
            // 
            this.gridColcInvStd.Caption = "规格型号";
            this.gridColcInvStd.FieldName = "cInvStd";
            this.gridColcInvStd.Name = "gridColcInvStd";
            this.gridColcInvStd.OptionsColumn.AllowEdit = false;
            this.gridColcInvStd.OptionsColumn.AllowMerge = DevExpress.Utils.DefaultBoolean.False;
            this.gridColcInvStd.OptionsColumn.AllowSort = DevExpress.Utils.DefaultBoolean.True;
            this.gridColcInvStd.Visible = true;
            this.gridColcInvStd.VisibleIndex = 7;
            // 
            // gridColReturnDate1
            // 
            this.gridColReturnDate1.Caption = "回签日期";
            this.gridColReturnDate1.ColumnEdit = this.ItemDateEdit1;
            this.gridColReturnDate1.DisplayFormat.FormatString = "d";
            this.gridColReturnDate1.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.gridColReturnDate1.FieldName = "ReturnDate1";
            this.gridColReturnDate1.Name = "gridColReturnDate1";
            this.gridColReturnDate1.OptionsColumn.AllowEdit = false;
            this.gridColReturnDate1.OptionsColumn.AllowMerge = DevExpress.Utils.DefaultBoolean.False;
            this.gridColReturnDate1.OptionsColumn.AllowSort = DevExpress.Utils.DefaultBoolean.True;
            this.gridColReturnDate1.Visible = true;
            this.gridColReturnDate1.VisibleIndex = 10;
            // 
            // ItemDateEdit1
            // 
            this.ItemDateEdit1.AutoHeight = false;
            this.ItemDateEdit1.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.ItemDateEdit1.Name = "ItemDateEdit1";
            this.ItemDateEdit1.VistaTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
            // 
            // gridColReturnDate2
            // 
            this.gridColReturnDate2.Caption = "回签日期2";
            this.gridColReturnDate2.ColumnEdit = this.ItemDateEdit1;
            this.gridColReturnDate2.DisplayFormat.FormatString = "d";
            this.gridColReturnDate2.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.gridColReturnDate2.FieldName = "ReturnDate2";
            this.gridColReturnDate2.Name = "gridColReturnDate2";
            this.gridColReturnDate2.OptionsColumn.AllowEdit = false;
            this.gridColReturnDate2.OptionsColumn.AllowMerge = DevExpress.Utils.DefaultBoolean.False;
            this.gridColReturnDate2.OptionsColumn.AllowSort = DevExpress.Utils.DefaultBoolean.True;
            this.gridColReturnDate2.Visible = true;
            this.gridColReturnDate2.VisibleIndex = 11;
            // 
            // gridColiQuantity
            // 
            this.gridColiQuantity.Caption = "数量";
            this.gridColiQuantity.FieldName = "iQuantity";
            this.gridColiQuantity.Name = "gridColiQuantity";
            this.gridColiQuantity.OptionsColumn.AllowEdit = false;
            this.gridColiQuantity.OptionsColumn.AllowMerge = DevExpress.Utils.DefaultBoolean.False;
            this.gridColiQuantity.OptionsColumn.AllowSort = DevExpress.Utils.DefaultBoolean.True;
            this.gridColiQuantity.OptionsFilter.AllowFilter = false;
            this.gridColiQuantity.Visible = true;
            this.gridColiQuantity.VisibleIndex = 15;
            // 
            // gridColiNum
            // 
            this.gridColiNum.Caption = "件数";
            this.gridColiNum.FieldName = "iNum";
            this.gridColiNum.Name = "gridColiNum";
            this.gridColiNum.OptionsColumn.AllowEdit = false;
            this.gridColiNum.OptionsColumn.AllowMerge = DevExpress.Utils.DefaultBoolean.False;
            this.gridColiNum.OptionsColumn.AllowSort = DevExpress.Utils.DefaultBoolean.True;
            this.gridColiNum.OptionsFilter.AllowFilter = false;
            this.gridColiNum.Visible = true;
            this.gridColiNum.VisibleIndex = 16;
            // 
            // gridColcItemCode
            // 
            this.gridColcItemCode.Caption = "外销订单号";
            this.gridColcItemCode.FieldName = "cItemCode";
            this.gridColcItemCode.Name = "gridColcItemCode";
            this.gridColcItemCode.OptionsColumn.AllowEdit = false;
            this.gridColcItemCode.OptionsColumn.AllowMerge = DevExpress.Utils.DefaultBoolean.False;
            this.gridColcItemCode.OptionsColumn.AllowSort = DevExpress.Utils.DefaultBoolean.True;
            this.gridColcItemCode.Visible = true;
            this.gridColcItemCode.VisibleIndex = 8;
            // 
            // gridColiTaxPrice
            // 
            this.gridColiTaxPrice.Caption = "含税单价";
            this.gridColiTaxPrice.FieldName = "iTaxPrice";
            this.gridColiTaxPrice.Name = "gridColiTaxPrice";
            this.gridColiTaxPrice.OptionsColumn.AllowEdit = false;
            this.gridColiTaxPrice.OptionsColumn.AllowMerge = DevExpress.Utils.DefaultBoolean.False;
            this.gridColiTaxPrice.OptionsColumn.AllowSort = DevExpress.Utils.DefaultBoolean.True;
            this.gridColiTaxPrice.OptionsFilter.AllowFilter = false;
            this.gridColiTaxPrice.Visible = true;
            this.gridColiTaxPrice.VisibleIndex = 19;
            // 
            // gridColiUnitPrice
            // 
            this.gridColiUnitPrice.Caption = "无税单价 ";
            this.gridColiUnitPrice.FieldName = "iUnitPrice";
            this.gridColiUnitPrice.Name = "gridColiUnitPrice";
            this.gridColiUnitPrice.OptionsColumn.AllowEdit = false;
            this.gridColiUnitPrice.OptionsColumn.AllowMerge = DevExpress.Utils.DefaultBoolean.False;
            this.gridColiUnitPrice.OptionsColumn.AllowSort = DevExpress.Utils.DefaultBoolean.True;
            this.gridColiUnitPrice.OptionsFilter.AllowFilter = false;
            // 
            // gridColiSum
            // 
            this.gridColiSum.Caption = "价税合计";
            this.gridColiSum.FieldName = "iSum";
            this.gridColiSum.Name = "gridColiSum";
            this.gridColiSum.OptionsColumn.AllowEdit = false;
            this.gridColiSum.OptionsColumn.AllowMerge = DevExpress.Utils.DefaultBoolean.False;
            this.gridColiSum.OptionsColumn.AllowSort = DevExpress.Utils.DefaultBoolean.True;
            this.gridColiSum.OptionsFilter.AllowFilter = false;
            this.gridColiSum.Visible = true;
            this.gridColiSum.VisibleIndex = 20;
            // 
            // gridColiMoney
            // 
            this.gridColiMoney.Caption = "无税金额 ";
            this.gridColiMoney.FieldName = "iMoney";
            this.gridColiMoney.Name = "gridColiMoney";
            this.gridColiMoney.OptionsColumn.AllowEdit = false;
            this.gridColiMoney.OptionsColumn.AllowMerge = DevExpress.Utils.DefaultBoolean.False;
            this.gridColiMoney.OptionsColumn.AllowSort = DevExpress.Utils.DefaultBoolean.True;
            this.gridColiMoney.OptionsFilter.AllowFilter = false;
            // 
            // gridColiPerTaxRate
            // 
            this.gridColiPerTaxRate.Caption = "税率";
            this.gridColiPerTaxRate.FieldName = "iPerTaxRate";
            this.gridColiPerTaxRate.Name = "gridColiPerTaxRate";
            this.gridColiPerTaxRate.OptionsColumn.AllowEdit = false;
            this.gridColiPerTaxRate.OptionsColumn.AllowMerge = DevExpress.Utils.DefaultBoolean.False;
            this.gridColiPerTaxRate.OptionsColumn.AllowSort = DevExpress.Utils.DefaultBoolean.True;
            this.gridColiPerTaxRate.OptionsFilter.AllowFilter = false;
            // 
            // gridColPOID
            // 
            this.gridColPOID.Caption = "采购订单ID";
            this.gridColPOID.FieldName = "POID";
            this.gridColPOID.Name = "gridColPOID";
            this.gridColPOID.OptionsColumn.AllowMerge = DevExpress.Utils.DefaultBoolean.False;
            this.gridColPOID.OptionsColumn.AllowSort = DevExpress.Utils.DefaultBoolean.True;
            // 
            // gridColdArriveDate
            // 
            this.gridColdArriveDate.Caption = "计划到货日期";
            this.gridColdArriveDate.ColumnEdit = this.ItemDateEdit1;
            this.gridColdArriveDate.DisplayFormat.FormatString = "d";
            this.gridColdArriveDate.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.gridColdArriveDate.FieldName = "dArriveDate";
            this.gridColdArriveDate.Name = "gridColdArriveDate";
            this.gridColdArriveDate.OptionsColumn.AllowEdit = false;
            this.gridColdArriveDate.OptionsColumn.AllowMerge = DevExpress.Utils.DefaultBoolean.False;
            this.gridColdArriveDate.OptionsColumn.AllowSort = DevExpress.Utils.DefaultBoolean.True;
            this.gridColdArriveDate.Visible = true;
            this.gridColdArriveDate.VisibleIndex = 9;
            this.gridColdArriveDate.Width = 94;
            // 
            // gridColReturnAuditCount
            // 
            this.gridColReturnAuditCount.Caption = "再次确认次数";
            this.gridColReturnAuditCount.FieldName = "ReturnAuditCount";
            this.gridColReturnAuditCount.Name = "gridColReturnAuditCount";
            this.gridColReturnAuditCount.OptionsColumn.AllowEdit = false;
            this.gridColReturnAuditCount.OptionsColumn.AllowMerge = DevExpress.Utils.DefaultBoolean.False;
            this.gridColReturnAuditCount.OptionsColumn.AllowSort = DevExpress.Utils.DefaultBoolean.True;
            this.gridColReturnAuditCount.Visible = true;
            this.gridColReturnAuditCount.VisibleIndex = 22;
            this.gridColReturnAuditCount.Width = 96;
            // 
            // gridColReturnApply
            // 
            this.gridColReturnApply.Caption = "申请重确认";
            this.gridColReturnApply.FieldName = "ReturnApply";
            this.gridColReturnApply.Name = "gridColReturnApply";
            this.gridColReturnApply.OptionsColumn.AllowEdit = false;
            this.gridColReturnApply.OptionsColumn.AllowMerge = DevExpress.Utils.DefaultBoolean.False;
            this.gridColReturnApply.OptionsColumn.AllowSort = DevExpress.Utils.DefaultBoolean.True;
            this.gridColReturnApply.Visible = true;
            this.gridColReturnApply.VisibleIndex = 23;
            // 
            // gridColReturnAuditUID
            // 
            this.gridColReturnAuditUID.Caption = "审核人";
            this.gridColReturnAuditUID.FieldName = "ReturnAuditUID";
            this.gridColReturnAuditUID.Name = "gridColReturnAuditUID";
            this.gridColReturnAuditUID.OptionsColumn.AllowEdit = false;
            this.gridColReturnAuditUID.OptionsColumn.AllowMerge = DevExpress.Utils.DefaultBoolean.False;
            this.gridColReturnAuditUID.OptionsColumn.AllowSort = DevExpress.Utils.DefaultBoolean.True;
            this.gridColReturnAuditUID.Visible = true;
            this.gridColReturnAuditUID.VisibleIndex = 24;
            // 
            // gridColReturnAuditDate
            // 
            this.gridColReturnAuditDate.Caption = "审核日期";
            this.gridColReturnAuditDate.FieldName = "ReturnAuditDate";
            this.gridColReturnAuditDate.Name = "gridColReturnAuditDate";
            this.gridColReturnAuditDate.OptionsColumn.AllowEdit = false;
            this.gridColReturnAuditDate.OptionsColumn.AllowMerge = DevExpress.Utils.DefaultBoolean.False;
            this.gridColReturnAuditDate.OptionsColumn.AllowSort = DevExpress.Utils.DefaultBoolean.True;
            this.gridColReturnAuditDate.Visible = true;
            this.gridColReturnAuditDate.VisibleIndex = 25;
            // 
            // gridColReturnAudit
            // 
            this.gridColReturnAudit.Caption = "已审核";
            this.gridColReturnAudit.FieldName = "ReturnAudit";
            this.gridColReturnAudit.Name = "gridColReturnAudit";
            this.gridColReturnAudit.OptionsColumn.AllowEdit = false;
            this.gridColReturnAudit.OptionsColumn.AllowMerge = DevExpress.Utils.DefaultBoolean.False;
            this.gridColReturnAudit.OptionsColumn.AllowSort = DevExpress.Utils.DefaultBoolean.True;
            this.gridColReturnAudit.Visible = true;
            this.gridColReturnAudit.VisibleIndex = 26;
            // 
            // gridColID
            // 
            this.gridColID.Caption = "采购订单子表ID";
            this.gridColID.FieldName = "ID";
            this.gridColID.Name = "gridColID";
            this.gridColID.OptionsColumn.AllowEdit = false;
            this.gridColID.OptionsColumn.AllowMerge = DevExpress.Utils.DefaultBoolean.False;
            this.gridColID.OptionsColumn.AllowSort = DevExpress.Utils.DefaultBoolean.True;
            this.gridColID.Width = 105;
            // 
            // gridColbAgain
            // 
            this.gridColbAgain.Caption = "是否二次回签";
            this.gridColbAgain.FieldName = "bAgain";
            this.gridColbAgain.Name = "gridColbAgain";
            this.gridColbAgain.OptionsColumn.AllowEdit = false;
            this.gridColbAgain.OptionsColumn.AllowMerge = DevExpress.Utils.DefaultBoolean.False;
            this.gridColbAgain.OptionsColumn.AllowSort = DevExpress.Utils.DefaultBoolean.True;
            this.gridColbAgain.Visible = true;
            this.gridColbAgain.VisibleIndex = 21;
            this.gridColbAgain.Width = 86;
            // 
            // gridColcVenName
            // 
            this.gridColcVenName.Caption = "供应商";
            this.gridColcVenName.FieldName = "cVenName";
            this.gridColcVenName.Name = "gridColcVenName";
            this.gridColcVenName.OptionsColumn.AllowEdit = false;
            this.gridColcVenName.OptionsColumn.AllowSort = DevExpress.Utils.DefaultBoolean.True;
            this.gridColcVenName.Visible = true;
            this.gridColcVenName.VisibleIndex = 4;
            this.gridColcVenName.Width = 154;
            // 
            // gridColcMaker
            // 
            this.gridColcMaker.Caption = "采购订单制单人";
            this.gridColcMaker.FieldName = "cMaker";
            this.gridColcMaker.Name = "gridColcMaker";
            this.gridColcMaker.OptionsColumn.AllowEdit = false;
            this.gridColcMaker.OptionsColumn.AllowMerge = DevExpress.Utils.DefaultBoolean.False;
            this.gridColcMaker.Visible = true;
            this.gridColcMaker.VisibleIndex = 27;
            // 
            // gridColcVenCode
            // 
            this.gridColcVenCode.Caption = "供应商编码";
            this.gridColcVenCode.FieldName = "cVenCode";
            this.gridColcVenCode.Name = "gridColcVenCode";
            this.gridColcVenCode.OptionsColumn.AllowEdit = false;
            this.gridColcVenCode.Visible = true;
            this.gridColcVenCode.VisibleIndex = 28;
            // 
            // gridColcDepCode
            // 
            this.gridColcDepCode.Caption = "部门编码";
            this.gridColcDepCode.FieldName = "cDepCode";
            this.gridColcDepCode.Name = "gridColcDepCode";
            this.gridColcDepCode.OptionsColumn.AllowEdit = false;
            this.gridColcDepCode.Visible = true;
            this.gridColcDepCode.VisibleIndex = 29;
            // 
            // gridColcDepName
            // 
            this.gridColcDepName.Caption = "部门名称";
            this.gridColcDepName.FieldName = "cDepName";
            this.gridColcDepName.Name = "gridColcDepName";
            this.gridColcDepName.OptionsColumn.AllowEdit = false;
            this.gridColcDepName.Visible = true;
            this.gridColcDepName.VisibleIndex = 30;
            // 
            // gridColReturnRemark
            // 
            this.gridColReturnRemark.Caption = "回签备注";
            this.gridColReturnRemark.FieldName = "ReturnRemark";
            this.gridColReturnRemark.Name = "gridColReturnRemark";
            this.gridColReturnRemark.OptionsColumn.AllowMerge = DevExpress.Utils.DefaultBoolean.False;
            this.gridColReturnRemark.Visible = true;
            this.gridColReturnRemark.VisibleIndex = 14;
            this.gridColReturnRemark.Width = 155;
            // 
            // gridColbLock
            // 
            this.gridColbLock.Caption = "已锁定";
            this.gridColbLock.FieldName = "bLock";
            this.gridColbLock.Name = "gridColbLock";
            this.gridColbLock.OptionsColumn.AllowEdit = false;
            this.gridColbLock.OptionsColumn.AllowMerge = DevExpress.Utils.DefaultBoolean.False;
            this.gridColbLock.Visible = true;
            this.gridColbLock.VisibleIndex = 1;
            this.gridColbLock.Width = 36;
            // 
            // gridColLocker
            // 
            this.gridColLocker.Caption = "锁定人";
            this.gridColLocker.FieldName = "Locker";
            this.gridColLocker.Name = "gridColLocker";
            this.gridColLocker.OptionsColumn.AllowEdit = false;
            this.gridColLocker.OptionsColumn.AllowMerge = DevExpress.Utils.DefaultBoolean.False;
            this.gridColLocker.Visible = true;
            this.gridColLocker.VisibleIndex = 31;
            // 
            // gridColLockDate
            // 
            this.gridColLockDate.Caption = "锁定日期";
            this.gridColLockDate.FieldName = "LockDate";
            this.gridColLockDate.Name = "gridColLockDate";
            this.gridColLockDate.OptionsColumn.AllowEdit = false;
            this.gridColLockDate.OptionsColumn.AllowMerge = DevExpress.Utils.DefaultBoolean.False;
            this.gridColLockDate.Visible = true;
            this.gridColLockDate.VisibleIndex = 32;
            // 
            // gridColiQtyUnIn
            // 
            this.gridColiQtyUnIn.Caption = "未到货数量";
            this.gridColiQtyUnIn.FieldName = "iQtyUnIn";
            this.gridColiQtyUnIn.Name = "gridColiQtyUnIn";
            this.gridColiQtyUnIn.OptionsColumn.AllowEdit = false;
            this.gridColiQtyUnIn.OptionsColumn.AllowMerge = DevExpress.Utils.DefaultBoolean.False;
            this.gridColiQtyUnIn.OptionsFilter.AllowFilter = false;
            this.gridColiQtyUnIn.Visible = true;
            this.gridColiQtyUnIn.VisibleIndex = 17;
            // 
            // gridColiNumUnIn
            // 
            this.gridColiNumUnIn.Caption = "未到货件数";
            this.gridColiNumUnIn.FieldName = "iNumUnIn";
            this.gridColiNumUnIn.Name = "gridColiNumUnIn";
            this.gridColiNumUnIn.OptionsColumn.AllowEdit = false;
            this.gridColiNumUnIn.OptionsColumn.AllowMerge = DevExpress.Utils.DefaultBoolean.False;
            this.gridColiNumUnIn.OptionsFilter.AllowFilter = false;
            this.gridColiNumUnIn.Visible = true;
            this.gridColiNumUnIn.VisibleIndex = 18;
            // 
            // gridColReturnUid
            // 
            this.gridColReturnUid.Caption = "二次确认申请";
            this.gridColReturnUid.FieldName = "ReturnUid";
            this.gridColReturnUid.Name = "gridColReturnUid";
            this.gridColReturnUid.OptionsColumn.AllowEdit = false;
            this.gridColReturnUid.Visible = true;
            this.gridColReturnUid.VisibleIndex = 33;
            // 
            // gridColReturnUidDate
            // 
            this.gridColReturnUidDate.Caption = "二次确认日期";
            this.gridColReturnUidDate.FieldName = "ReturnUidDate";
            this.gridColReturnUidDate.Name = "gridColReturnUidDate";
            this.gridColReturnUidDate.OptionsColumn.AllowEdit = false;
            this.gridColReturnUidDate.Visible = true;
            this.gridColReturnUidDate.VisibleIndex = 34;
            // 
            // gridCol初期计划日期
            // 
            this.gridCol初期计划日期.Caption = "初期计划日期";
            this.gridCol初期计划日期.FieldName = "初期计划日期";
            this.gridCol初期计划日期.Name = "gridCol初期计划日期";
            this.gridCol初期计划日期.OptionsColumn.AllowEdit = false;
            this.gridCol初期计划日期.OptionsColumn.AllowMerge = DevExpress.Utils.DefaultBoolean.False;
            this.gridCol初期计划日期.Visible = true;
            this.gridCol初期计划日期.VisibleIndex = 12;
            // 
            // gridCol生产计划需求日期
            // 
            this.gridCol生产计划需求日期.Caption = "生产计划需求日期";
            this.gridCol生产计划需求日期.FieldName = "生产计划需求日期";
            this.gridCol生产计划需求日期.Name = "gridCol生产计划需求日期";
            this.gridCol生产计划需求日期.OptionsColumn.AllowEdit = false;
            this.gridCol生产计划需求日期.OptionsColumn.AllowMerge = DevExpress.Utils.DefaultBoolean.False;
            this.gridCol生产计划需求日期.Visible = true;
            this.gridCol生产计划需求日期.VisibleIndex = 13;
            // 
            // gridColbTomato
            // 
            this.gridColbTomato.Caption = "bTomato";
            this.gridColbTomato.FieldName = "bTomato";
            this.gridColbTomato.Name = "gridColbTomato";
            this.gridColbTomato.OptionsColumn.AllowEdit = false;
            this.gridColbTomato.OptionsColumn.AllowMerge = DevExpress.Utils.DefaultBoolean.False;
            // 
            // gridColUnLockTomatoUser
            // 
            this.gridColUnLockTomatoUser.Caption = "UnLockTomatoUser";
            this.gridColUnLockTomatoUser.FieldName = "UnLockTomatoUser";
            this.gridColUnLockTomatoUser.Name = "gridColUnLockTomatoUser";
            this.gridColUnLockTomatoUser.OptionsColumn.AllowEdit = false;
            this.gridColUnLockTomatoUser.OptionsColumn.AllowMerge = DevExpress.Utils.DefaultBoolean.False;
            // 
            // gridColUnLockTomatoDate
            // 
            this.gridColUnLockTomatoDate.Caption = "UnLockTomatoDate";
            this.gridColUnLockTomatoDate.FieldName = "UnLockTomatoDate";
            this.gridColUnLockTomatoDate.Name = "gridColUnLockTomatoDate";
            this.gridColUnLockTomatoDate.OptionsColumn.AllowEdit = false;
            this.gridColUnLockTomatoDate.OptionsColumn.AllowMerge = DevExpress.Utils.DefaultBoolean.False;
            // 
            // FrmStockOrderAutoMail
            // 
            this.Appearance.BackColor = System.Drawing.SystemColors.Control;
            this.Appearance.Options.UseBackColor = true;
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 18F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1113, 522);
            this.Controls.Add(this.gridControl2);
            this.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.Name = "FrmStockOrderAutoMail";
            this.Text = "FrmStockOrderAutoMail";
            this.Load += new System.EventHandler(this.FrmStockOrderAutoMail_Load);
            this.Controls.SetChildIndex(this.gridControl2, 0);
            //((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dsPrint)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dsForm)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtSel)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ItemDateEdit1.VistaTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ItemDateEdit1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Timer timer1;
        private DevExpress.XtraGrid.GridControl gridControl2;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView2;
        private DevExpress.XtraGrid.Columns.GridColumn gridColbChoose;
        private DevExpress.XtraGrid.Columns.GridColumn gridColcPOID;
        private DevExpress.XtraGrid.Columns.GridColumn gridColdPODate;
        private DevExpress.XtraGrid.Columns.GridColumn gridColcInvCode;
        private DevExpress.XtraGrid.Columns.GridColumn gridColcInvName;
        private DevExpress.XtraGrid.Columns.GridColumn gridColcInvStd;
        private DevExpress.XtraGrid.Columns.GridColumn gridColReturnDate1;
        private DevExpress.XtraEditors.Repository.RepositoryItemDateEdit ItemDateEdit1;
        private DevExpress.XtraGrid.Columns.GridColumn gridColReturnDate2;
        private DevExpress.XtraGrid.Columns.GridColumn gridColiQuantity;
        private DevExpress.XtraGrid.Columns.GridColumn gridColiNum;
        private DevExpress.XtraGrid.Columns.GridColumn gridColcItemCode;
        private DevExpress.XtraGrid.Columns.GridColumn gridColiTaxPrice;
        private DevExpress.XtraGrid.Columns.GridColumn gridColiUnitPrice;
        private DevExpress.XtraGrid.Columns.GridColumn gridColiSum;
        private DevExpress.XtraGrid.Columns.GridColumn gridColiMoney;
        private DevExpress.XtraGrid.Columns.GridColumn gridColiPerTaxRate;
        private DevExpress.XtraGrid.Columns.GridColumn gridColPOID;
        private DevExpress.XtraGrid.Columns.GridColumn gridColdArriveDate;
        private DevExpress.XtraGrid.Columns.GridColumn gridColReturnAuditCount;
        private DevExpress.XtraGrid.Columns.GridColumn gridColReturnApply;
        private DevExpress.XtraGrid.Columns.GridColumn gridColReturnAuditUID;
        private DevExpress.XtraGrid.Columns.GridColumn gridColReturnAuditDate;
        private DevExpress.XtraGrid.Columns.GridColumn gridColReturnAudit;
        private DevExpress.XtraGrid.Columns.GridColumn gridColID;
        private DevExpress.XtraGrid.Columns.GridColumn gridColbAgain;
        private DevExpress.XtraGrid.Columns.GridColumn gridColcVenName;
        private DevExpress.XtraGrid.Columns.GridColumn gridColcMaker;
        private DevExpress.XtraGrid.Columns.GridColumn gridColcVenCode;
        private DevExpress.XtraGrid.Columns.GridColumn gridColcDepCode;
        private DevExpress.XtraGrid.Columns.GridColumn gridColcDepName;
        private DevExpress.XtraGrid.Columns.GridColumn gridColReturnRemark;
        private DevExpress.XtraGrid.Columns.GridColumn gridColbLock;
        private DevExpress.XtraGrid.Columns.GridColumn gridColLocker;
        private DevExpress.XtraGrid.Columns.GridColumn gridColLockDate;
        private DevExpress.XtraGrid.Columns.GridColumn gridColiQtyUnIn;
        private DevExpress.XtraGrid.Columns.GridColumn gridColiNumUnIn;
        private DevExpress.XtraGrid.Columns.GridColumn gridColReturnUid;
        private DevExpress.XtraGrid.Columns.GridColumn gridColReturnUidDate;
        private DevExpress.XtraGrid.Columns.GridColumn gridCol初期计划日期;
        private DevExpress.XtraGrid.Columns.GridColumn gridCol生产计划需求日期;
        private DevExpress.XtraGrid.Columns.GridColumn gridColbTomato;
        private DevExpress.XtraGrid.Columns.GridColumn gridColUnLockTomatoUser;
        private DevExpress.XtraGrid.Columns.GridColumn gridColUnLockTomatoDate;
    }
}