﻿namespace WorkInformation
{
    partial class FrmWorkProcedureBarCode
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
            this.gridControl1 = new DevExpress.XtraGrid.GridControl();
            this.gridView1 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.gridColWorkOrderNO = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColWorkQtyY = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColworkDepment = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColworkDepmentNext = new DevExpress.XtraGrid.Columns.GridColumn();
            this.ItemLookUpEditworkDepmentNext = new DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit();
            this.gridColcInvCode = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColcInvName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColcInvStd = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColworkProcedure = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColworkProcedureNext = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridCol预计计划数量 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColiQuantity = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColwdiQty = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColwddiQty = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColQtyIng = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColQtyNow = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColdtm1 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColvchrPer = new DevExpress.XtraGrid.Columns.GridColumn();
            this.ItemButtonEditvchrPer = new DevExpress.XtraEditors.Repository.RepositoryItemButtonEdit();
            this.gridColvchrEquipment = new DevExpress.XtraGrid.Columns.GridColumn();
            this.ItemlookUpEquipment = new DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit();
            this.gridColWorkTime = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColbRDIn = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColInvCode = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColInvName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColSoCode = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColGUID = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColautoid = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColRDInType = new DevExpress.XtraGrid.Columns.GridColumn();
            this.ItemLookUpRdInType = new DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit();
            this.gridColQtyRDIn = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColQtyRDL = new DevExpress.XtraGrid.Columns.GridColumn();
            this.txtBarCode = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.txtGuid = new DevExpress.XtraEditors.TextEdit();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ItemLookUpEditworkDepmentNext)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ItemButtonEditvchrPer)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ItemlookUpEquipment)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ItemLookUpRdInType)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtGuid.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // childLF
            // 
            this.childLF.LookAndFeel.Style = DevExpress.LookAndFeel.LookAndFeelStyle.Skin;
            this.childLF.LookAndFeel.UseWindowsXPTheme = false;
            // 
            // gridControl1
            // 
            this.gridControl1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.gridControl1.EmbeddedNavigator.Name = "";
            this.gridControl1.Location = new System.Drawing.Point(0, 66);
            this.gridControl1.MainView = this.gridView1;
            this.gridControl1.Name = "gridControl1";
            this.gridControl1.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.ItemButtonEditvchrPer,
            this.ItemlookUpEquipment,
            this.ItemLookUpEditworkDepmentNext,
            this.ItemLookUpRdInType});
            this.gridControl1.Size = new System.Drawing.Size(927, 298);
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
            this.gridColWorkOrderNO,
            this.gridColWorkQtyY,
            this.gridColworkDepment,
            this.gridColworkDepmentNext,
            this.gridColcInvCode,
            this.gridColcInvName,
            this.gridColcInvStd,
            this.gridColworkProcedure,
            this.gridColworkProcedureNext,
            this.gridCol预计计划数量,
            this.gridColiQuantity,
            this.gridColwdiQty,
            this.gridColwddiQty,
            this.gridColQtyIng,
            this.gridColQtyNow,
            this.gridColdtm1,
            this.gridColvchrPer,
            this.gridColvchrEquipment,
            this.gridColWorkTime,
            this.gridColbRDIn,
            this.gridColInvCode,
            this.gridColInvName,
            this.gridColSoCode,
            this.gridColGUID,
            this.gridColautoid,
            this.gridColRDInType,
            this.gridColQtyRDIn,
            this.gridColQtyRDL});
            this.gridView1.GridControl = this.gridControl1;
            this.gridView1.IndicatorWidth = 40;
            this.gridView1.Name = "gridView1";
            this.gridView1.OptionsCustomization.AllowFilter = false;
            this.gridView1.OptionsPrint.AutoWidth = false;
            this.gridView1.OptionsView.ColumnAutoWidth = false;
            this.gridView1.OptionsView.EnableAppearanceEvenRow = true;
            this.gridView1.OptionsView.EnableAppearanceOddRow = true;
            this.gridView1.OptionsView.ShowGroupPanel = false;
            this.gridView1.CellValueChanged += new DevExpress.XtraGrid.Views.Base.CellValueChangedEventHandler(this.gridView1_CellValueChanged);
            this.gridView1.CustomDrawRowIndicator += new DevExpress.XtraGrid.Views.Grid.RowIndicatorCustomDrawEventHandler(this.gridView1_CustomDrawRowIndicator_1);
            // 
            // gridColWorkOrderNO
            // 
            this.gridColWorkOrderNO.Caption = "生产订单号";
            this.gridColWorkOrderNO.FieldName = "WorkOrderNO";
            this.gridColWorkOrderNO.Name = "gridColWorkOrderNO";
            this.gridColWorkOrderNO.OptionsColumn.AllowEdit = false;
            this.gridColWorkOrderNO.Visible = true;
            this.gridColWorkOrderNO.VisibleIndex = 0;
            this.gridColWorkOrderNO.Width = 86;
            // 
            // gridColWorkQtyY
            // 
            this.gridColWorkQtyY.Caption = "生产订单余量";
            this.gridColWorkQtyY.FieldName = "WorkQtyY";
            this.gridColWorkQtyY.Name = "gridColWorkQtyY";
            this.gridColWorkQtyY.OptionsColumn.AllowEdit = false;
            this.gridColWorkQtyY.Visible = true;
            this.gridColWorkQtyY.VisibleIndex = 1;
            this.gridColWorkQtyY.Width = 89;
            // 
            // gridColworkDepment
            // 
            this.gridColworkDepment.Caption = "班组";
            this.gridColworkDepment.FieldName = "workDepment";
            this.gridColworkDepment.Name = "gridColworkDepment";
            this.gridColworkDepment.OptionsColumn.AllowEdit = false;
            this.gridColworkDepment.Visible = true;
            this.gridColworkDepment.VisibleIndex = 3;
            this.gridColworkDepment.Width = 56;
            // 
            // gridColworkDepmentNext
            // 
            this.gridColworkDepmentNext.Caption = "接受班组";
            this.gridColworkDepmentNext.ColumnEdit = this.ItemLookUpEditworkDepmentNext;
            this.gridColworkDepmentNext.FieldName = "workDepmentNext2";
            this.gridColworkDepmentNext.Name = "gridColworkDepmentNext";
            this.gridColworkDepmentNext.Visible = true;
            this.gridColworkDepmentNext.VisibleIndex = 4;
            this.gridColworkDepmentNext.Width = 65;
            // 
            // ItemLookUpEditworkDepmentNext
            // 
            this.ItemLookUpEditworkDepmentNext.AutoHeight = false;
            this.ItemLookUpEditworkDepmentNext.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.ItemLookUpEditworkDepmentNext.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("FCode", "编码", 20, DevExpress.Utils.FormatType.None, "", true, DevExpress.Utils.HorzAlignment.Default, DevExpress.Data.ColumnSortOrder.None),
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("FName", "名称", 20, DevExpress.Utils.FormatType.None, "", true, DevExpress.Utils.HorzAlignment.Default, DevExpress.Data.ColumnSortOrder.None)});
            this.ItemLookUpEditworkDepmentNext.DisplayMember = "FName";
            this.ItemLookUpEditworkDepmentNext.Name = "ItemLookUpEditworkDepmentNext";
            this.ItemLookUpEditworkDepmentNext.NullText = "";
            this.ItemLookUpEditworkDepmentNext.ValueMember = "FName";
            // 
            // gridColcInvCode
            // 
            this.gridColcInvCode.Caption = "物料编码";
            this.gridColcInvCode.FieldName = "cInvCode";
            this.gridColcInvCode.Name = "gridColcInvCode";
            this.gridColcInvCode.OptionsColumn.AllowEdit = false;
            this.gridColcInvCode.Visible = true;
            this.gridColcInvCode.VisibleIndex = 5;
            this.gridColcInvCode.Width = 66;
            // 
            // gridColcInvName
            // 
            this.gridColcInvName.Caption = "物料名称";
            this.gridColcInvName.FieldName = "cInvName";
            this.gridColcInvName.Name = "gridColcInvName";
            this.gridColcInvName.OptionsColumn.AllowEdit = false;
            this.gridColcInvName.Visible = true;
            this.gridColcInvName.VisibleIndex = 6;
            this.gridColcInvName.Width = 89;
            // 
            // gridColcInvStd
            // 
            this.gridColcInvStd.Caption = "规格型号";
            this.gridColcInvStd.FieldName = "cInvStd";
            this.gridColcInvStd.Name = "gridColcInvStd";
            this.gridColcInvStd.OptionsColumn.AllowEdit = false;
            this.gridColcInvStd.Visible = true;
            this.gridColcInvStd.VisibleIndex = 7;
            this.gridColcInvStd.Width = 73;
            // 
            // gridColworkProcedure
            // 
            this.gridColworkProcedure.Caption = "工序";
            this.gridColworkProcedure.FieldName = "workProcedure";
            this.gridColworkProcedure.Name = "gridColworkProcedure";
            this.gridColworkProcedure.OptionsColumn.AllowEdit = false;
            this.gridColworkProcedure.Visible = true;
            this.gridColworkProcedure.VisibleIndex = 8;
            this.gridColworkProcedure.Width = 50;
            // 
            // gridColworkProcedureNext
            // 
            this.gridColworkProcedureNext.Caption = "下道工序";
            this.gridColworkProcedureNext.FieldName = "workProcedureNext";
            this.gridColworkProcedureNext.Name = "gridColworkProcedureNext";
            this.gridColworkProcedureNext.OptionsColumn.AllowEdit = false;
            this.gridColworkProcedureNext.Visible = true;
            this.gridColworkProcedureNext.VisibleIndex = 9;
            this.gridColworkProcedureNext.Width = 70;
            // 
            // gridCol预计计划数量
            // 
            this.gridCol预计计划数量.Caption = "预计计划数量";
            this.gridCol预计计划数量.FieldName = "预计计划数量";
            this.gridCol预计计划数量.Name = "gridCol预计计划数量";
            this.gridCol预计计划数量.OptionsColumn.AllowEdit = false;
            this.gridCol预计计划数量.Visible = true;
            this.gridCol预计计划数量.VisibleIndex = 10;
            this.gridCol预计计划数量.Width = 90;
            // 
            // gridColiQuantity
            // 
            this.gridColiQuantity.Caption = "计划数量";
            this.gridColiQuantity.FieldName = "iQuantity";
            this.gridColiQuantity.Name = "gridColiQuantity";
            this.gridColiQuantity.OptionsColumn.AllowEdit = false;
            this.gridColiQuantity.Visible = true;
            this.gridColiQuantity.VisibleIndex = 11;
            this.gridColiQuantity.Width = 60;
            // 
            // gridColwdiQty
            // 
            this.gridColwdiQty.Caption = "累计转移数量";
            this.gridColwdiQty.FieldName = "wdiQty";
            this.gridColwdiQty.Name = "gridColwdiQty";
            this.gridColwdiQty.OptionsColumn.AllowEdit = false;
            this.gridColwdiQty.Visible = true;
            this.gridColwdiQty.VisibleIndex = 12;
            this.gridColwdiQty.Width = 85;
            // 
            // gridColwddiQty
            // 
            this.gridColwddiQty.Caption = "累计不合格数量";
            this.gridColwddiQty.FieldName = "wddiQty";
            this.gridColwddiQty.Name = "gridColwddiQty";
            this.gridColwddiQty.OptionsColumn.AllowEdit = false;
            this.gridColwddiQty.Visible = true;
            this.gridColwddiQty.VisibleIndex = 13;
            this.gridColwddiQty.Width = 100;
            // 
            // gridColQtyIng
            // 
            this.gridColQtyIng.Caption = "未转移数量";
            this.gridColQtyIng.FieldName = "QtyIng";
            this.gridColQtyIng.Name = "gridColQtyIng";
            this.gridColQtyIng.OptionsColumn.AllowEdit = false;
            this.gridColQtyIng.Visible = true;
            this.gridColQtyIng.VisibleIndex = 14;
            this.gridColQtyIng.Width = 73;
            // 
            // gridColQtyNow
            // 
            this.gridColQtyNow.Caption = "本次接受数量";
            this.gridColQtyNow.FieldName = "QtyNow";
            this.gridColQtyNow.Name = "gridColQtyNow";
            this.gridColQtyNow.OptionsColumn.AllowEdit = false;
            this.gridColQtyNow.Visible = true;
            this.gridColQtyNow.VisibleIndex = 17;
            this.gridColQtyNow.Width = 95;
            // 
            // gridColdtm1
            // 
            this.gridColdtm1.Caption = "接受日期";
            this.gridColdtm1.FieldName = "dtm1";
            this.gridColdtm1.Name = "gridColdtm1";
            this.gridColdtm1.Visible = true;
            this.gridColdtm1.VisibleIndex = 18;
            this.gridColdtm1.Width = 69;
            // 
            // gridColvchrPer
            // 
            this.gridColvchrPer.Caption = "员工";
            this.gridColvchrPer.ColumnEdit = this.ItemButtonEditvchrPer;
            this.gridColvchrPer.FieldName = "vchrPer";
            this.gridColvchrPer.Name = "gridColvchrPer";
            this.gridColvchrPer.Visible = true;
            this.gridColvchrPer.VisibleIndex = 19;
            this.gridColvchrPer.Width = 50;
            // 
            // ItemButtonEditvchrPer
            // 
            this.ItemButtonEditvchrPer.AutoHeight = false;
            this.ItemButtonEditvchrPer.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
            this.ItemButtonEditvchrPer.Name = "ItemButtonEditvchrPer";
            this.ItemButtonEditvchrPer.ButtonClick += new DevExpress.XtraEditors.Controls.ButtonPressedEventHandler(this.ItemButtonEditvchrPer_ButtonClick);
            // 
            // gridColvchrEquipment
            // 
            this.gridColvchrEquipment.Caption = "设备";
            this.gridColvchrEquipment.ColumnEdit = this.ItemlookUpEquipment;
            this.gridColvchrEquipment.FieldName = "vchrEquipment";
            this.gridColvchrEquipment.Name = "gridColvchrEquipment";
            this.gridColvchrEquipment.Visible = true;
            this.gridColvchrEquipment.VisibleIndex = 20;
            this.gridColvchrEquipment.Width = 50;
            // 
            // ItemlookUpEquipment
            // 
            this.ItemlookUpEquipment.AutoHeight = false;
            this.ItemlookUpEquipment.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.ItemlookUpEquipment.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("FName", "名称", 20, DevExpress.Utils.FormatType.None, "", true, DevExpress.Utils.HorzAlignment.Default, DevExpress.Data.ColumnSortOrder.None)});
            this.ItemlookUpEquipment.DisplayMember = "FName";
            this.ItemlookUpEquipment.Name = "ItemlookUpEquipment";
            this.ItemlookUpEquipment.NullText = "";
            this.ItemlookUpEquipment.ValueMember = "FName";
            // 
            // gridColWorkTime
            // 
            this.gridColWorkTime.Caption = "工时";
            this.gridColWorkTime.FieldName = "WorkTime";
            this.gridColWorkTime.Name = "gridColWorkTime";
            this.gridColWorkTime.Visible = true;
            this.gridColWorkTime.VisibleIndex = 21;
            this.gridColWorkTime.Width = 50;
            // 
            // gridColbRDIn
            // 
            this.gridColbRDIn.Caption = "是否入库";
            this.gridColbRDIn.FieldName = "bRDIn";
            this.gridColbRDIn.Name = "gridColbRDIn";
            this.gridColbRDIn.OptionsColumn.AllowEdit = false;
            this.gridColbRDIn.Visible = true;
            this.gridColbRDIn.VisibleIndex = 22;
            this.gridColbRDIn.Width = 50;
            // 
            // gridColInvCode
            // 
            this.gridColInvCode.Caption = "母件编码";
            this.gridColInvCode.FieldName = "InvCode";
            this.gridColInvCode.Name = "gridColInvCode";
            this.gridColInvCode.Visible = true;
            this.gridColInvCode.VisibleIndex = 23;
            this.gridColInvCode.Width = 50;
            // 
            // gridColInvName
            // 
            this.gridColInvName.Caption = "母件名称";
            this.gridColInvName.FieldName = "InvName";
            this.gridColInvName.Name = "gridColInvName";
            this.gridColInvName.OptionsColumn.AllowEdit = false;
            this.gridColInvName.Visible = true;
            this.gridColInvName.VisibleIndex = 24;
            this.gridColInvName.Width = 50;
            // 
            // gridColSoCode
            // 
            this.gridColSoCode.Caption = "销售单号";
            this.gridColSoCode.FieldName = "SoCode";
            this.gridColSoCode.Name = "gridColSoCode";
            this.gridColSoCode.OptionsColumn.AllowEdit = false;
            this.gridColSoCode.Visible = true;
            this.gridColSoCode.VisibleIndex = 25;
            this.gridColSoCode.Width = 161;
            // 
            // gridColGUID
            // 
            this.gridColGUID.Caption = "GUID";
            this.gridColGUID.FieldName = "GUID";
            this.gridColGUID.Name = "gridColGUID";
            this.gridColGUID.OptionsColumn.AllowEdit = false;
            // 
            // gridColautoid
            // 
            this.gridColautoid.Caption = "autoid";
            this.gridColautoid.FieldName = "autoid";
            this.gridColautoid.Name = "gridColautoid";
            this.gridColautoid.OptionsColumn.AllowEdit = false;
            // 
            // gridColRDInType
            // 
            this.gridColRDInType.Caption = "缴库类型";
            this.gridColRDInType.ColumnEdit = this.ItemLookUpRdInType;
            this.gridColRDInType.FieldName = "RDInType";
            this.gridColRDInType.Name = "gridColRDInType";
            this.gridColRDInType.Visible = true;
            this.gridColRDInType.VisibleIndex = 2;
            // 
            // ItemLookUpRdInType
            // 
            this.ItemLookUpRdInType.AutoHeight = false;
            this.ItemLookUpRdInType.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.ItemLookUpRdInType.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("RdInType", "编码", 20, DevExpress.Utils.FormatType.None, "", true, DevExpress.Utils.HorzAlignment.Default, DevExpress.Data.ColumnSortOrder.None),
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("RdInName", "名称", 20, DevExpress.Utils.FormatType.None, "", true, DevExpress.Utils.HorzAlignment.Default, DevExpress.Data.ColumnSortOrder.None)});
            this.ItemLookUpRdInType.DisplayMember = "RdInName";
            this.ItemLookUpRdInType.Name = "ItemLookUpRdInType";
            this.ItemLookUpRdInType.ValueMember = "RdInType";
            // 
            // gridColQtyRDIn
            // 
            this.gridColQtyRDIn.Caption = "缴库数量";
            this.gridColQtyRDIn.FieldName = "QtyRDIn";
            this.gridColQtyRDIn.Name = "gridColQtyRDIn";
            this.gridColQtyRDIn.Visible = true;
            this.gridColQtyRDIn.VisibleIndex = 15;
            // 
            // gridColQtyRDL
            // 
            this.gridColQtyRDL.Caption = "流转数量";
            this.gridColQtyRDL.FieldName = "QtyRDL";
            this.gridColQtyRDL.Name = "gridColQtyRDL";
            this.gridColQtyRDL.Visible = true;
            this.gridColQtyRDL.VisibleIndex = 16;
            // 
            // txtBarCode
            // 
            this.txtBarCode.Location = new System.Drawing.Point(88, 39);
            this.txtBarCode.Name = "txtBarCode";
            this.txtBarCode.Size = new System.Drawing.Size(348, 21);
            this.txtBarCode.TabIndex = 47;
            this.txtBarCode.KeyUp += new System.Windows.Forms.KeyEventHandler(this.txtBarCode_KeyUp);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 42);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(67, 14);
            this.label1.TabIndex = 48;
            this.label1.Text = "条码输入框";
            // 
            // txtGuid
            // 
            this.txtGuid.Location = new System.Drawing.Point(539, 39);
            this.txtGuid.Name = "txtGuid";
            this.txtGuid.Properties.ReadOnly = true;
            this.txtGuid.Size = new System.Drawing.Size(314, 21);
            this.txtGuid.TabIndex = 49;
            this.txtGuid.Visible = false;
            // 
            // FrmWorkProcedureBarCode
            // 
            this.Appearance.BackColor = System.Drawing.SystemColors.Control;
            this.Appearance.Options.UseBackColor = true;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(927, 363);
            this.Controls.Add(this.txtBarCode);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtGuid);
            this.Controls.Add(this.gridControl1);
            this.Name = "FrmWorkProcedureBarCode";
            this.Text = "FrmWorkIn";
            this.Load += new System.EventHandler(this.FrmWorkProcedureBarCode_Load);
            this.Controls.SetChildIndex(this.gridControl1, 0);
            this.Controls.SetChildIndex(this.txtGuid, 0);
            this.Controls.SetChildIndex(this.label1, 0);
            this.Controls.SetChildIndex(this.txtBarCode, 0);
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ItemLookUpEditworkDepmentNext)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ItemButtonEditvchrPer)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ItemlookUpEquipment)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ItemLookUpRdInType)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtGuid.Properties)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraGrid.GridControl gridControl1;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView1;
        private DevExpress.XtraGrid.Columns.GridColumn gridColWorkOrderNO;
        private DevExpress.XtraGrid.Columns.GridColumn gridColWorkQtyY;
        private DevExpress.XtraGrid.Columns.GridColumn gridColworkDepment;
        private DevExpress.XtraGrid.Columns.GridColumn gridColworkDepmentNext;
        private DevExpress.XtraGrid.Columns.GridColumn gridColcInvCode;
        private DevExpress.XtraGrid.Columns.GridColumn gridColcInvName;
        private DevExpress.XtraGrid.Columns.GridColumn gridColcInvStd;
        private DevExpress.XtraGrid.Columns.GridColumn gridColworkProcedure;
        private DevExpress.XtraGrid.Columns.GridColumn gridColworkProcedureNext;
        private DevExpress.XtraGrid.Columns.GridColumn gridColiQuantity;
        private DevExpress.XtraGrid.Columns.GridColumn gridColwdiQty;
        private DevExpress.XtraGrid.Columns.GridColumn gridColwddiQty;
        private DevExpress.XtraGrid.Columns.GridColumn gridColQtyIng;
        private DevExpress.XtraGrid.Columns.GridColumn gridColQtyNow;
        private DevExpress.XtraGrid.Columns.GridColumn gridColdtm1;
        private DevExpress.XtraGrid.Columns.GridColumn gridColvchrPer;
        private DevExpress.XtraGrid.Columns.GridColumn gridColvchrEquipment;
        private DevExpress.XtraGrid.Columns.GridColumn gridColWorkTime;
        private DevExpress.XtraGrid.Columns.GridColumn gridColbRDIn;
        private DevExpress.XtraGrid.Columns.GridColumn gridColInvCode;
        private DevExpress.XtraGrid.Columns.GridColumn gridColInvName;
        private DevExpress.XtraGrid.Columns.GridColumn gridColSoCode;
        private System.Windows.Forms.TextBox txtBarCode;
        private System.Windows.Forms.Label label1;
        private DevExpress.XtraEditors.TextEdit txtGuid;
        private DevExpress.XtraGrid.Columns.GridColumn gridColGUID;
        private DevExpress.XtraGrid.Columns.GridColumn gridColautoid;
        private DevExpress.XtraEditors.Repository.RepositoryItemButtonEdit ItemButtonEditvchrPer;
        private DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit ItemlookUpEquipment;
        private DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit ItemLookUpEditworkDepmentNext;
        private DevExpress.XtraGrid.Columns.GridColumn gridColRDInType;
        private DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit ItemLookUpRdInType;
        private DevExpress.XtraGrid.Columns.GridColumn gridColQtyRDIn;
        private DevExpress.XtraGrid.Columns.GridColumn gridColQtyRDL;
        private DevExpress.XtraGrid.Columns.GridColumn gridCol预计计划数量;


    }
}