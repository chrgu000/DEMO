﻿namespace 业务
{
    partial class Frm现品票
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
            this.gridColiSave = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColID = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColdDate = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColVenCode = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColDoor = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColInvCode = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColRemark = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColiHZ = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColiSheQty = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColiBoxQty = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColOrderNo = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColiSheDate = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColBarCode = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridCol产品名称 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.ItemLookUpEdit产品名称 = new DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit();
            this.gridColiQty = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColiOutDate = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColCreateUid = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColCreateDate = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColUpdateUid = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColUpdateDate = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColiDisQty = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColiOutQty = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColDisDate = new DevExpress.XtraGrid.Columns.GridColumn();
            this.layoutControlGroup1 = new DevExpress.XtraLayout.LayoutControlGroup();
            this.layoutControlItem3 = new DevExpress.XtraLayout.LayoutControlItem();
            ((System.ComponentModel.ISupportInitialize)(this.dsPrint)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dsForm)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtSel)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControl1)).BeginInit();
            this.layoutControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ItemLookUpEdit产品名称)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem3)).BeginInit();
            this.SuspendLayout();
            // 
            // layoutControl1
            // 
            this.layoutControl1.AllowCustomizationMenu = false;
            this.layoutControl1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.layoutControl1.Controls.Add(this.gridControl1);
            this.layoutControl1.Location = new System.Drawing.Point(0, 28);
            this.layoutControl1.Name = "layoutControl1";
            this.layoutControl1.OptionsCustomizationForm.DesignTimeCustomizationFormPositionAndSize = new System.Drawing.Rectangle(210, 239, 250, 350);
            this.layoutControl1.OptionsCustomizationForm.ShowLoadButton = false;
            this.layoutControl1.OptionsCustomizationForm.ShowSaveButton = false;
            this.layoutControl1.Root = this.layoutControlGroup1;
            this.layoutControl1.Size = new System.Drawing.Size(1252, 457);
            this.layoutControl1.TabIndex = 5;
            this.layoutControl1.Text = "layoutControl1";
            // 
            // gridControl1
            // 
            this.gridControl1.Location = new System.Drawing.Point(12, 12);
            this.gridControl1.MainView = this.gridView1;
            this.gridControl1.Name = "gridControl1";
            this.gridControl1.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.ItemLookUpEdit产品名称});
            this.gridControl1.Size = new System.Drawing.Size(1228, 433);
            this.gridControl1.TabIndex = 6;
            this.gridControl1.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView1});
            // 
            // gridView1
            // 
            this.gridView1.Appearance.ColumnFilterButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(236)))), ((int)(((byte)(232)))), ((int)(((byte)(201)))));
            this.gridView1.Appearance.ColumnFilterButton.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(236)))), ((int)(((byte)(232)))), ((int)(((byte)(201)))));
            this.gridView1.Appearance.ColumnFilterButton.ForeColor = System.Drawing.Color.Black;
            this.gridView1.Appearance.ColumnFilterButton.Options.UseBackColor = true;
            this.gridView1.Appearance.ColumnFilterButton.Options.UseBorderColor = true;
            this.gridView1.Appearance.ColumnFilterButton.Options.UseForeColor = true;
            this.gridView1.Appearance.ColumnFilterButtonActive.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(221)))), ((int)(((byte)(231)))), ((int)(((byte)(234)))));
            this.gridView1.Appearance.ColumnFilterButtonActive.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(221)))), ((int)(((byte)(231)))), ((int)(((byte)(234)))));
            this.gridView1.Appearance.ColumnFilterButtonActive.ForeColor = System.Drawing.Color.Black;
            this.gridView1.Appearance.ColumnFilterButtonActive.Options.UseBackColor = true;
            this.gridView1.Appearance.ColumnFilterButtonActive.Options.UseBorderColor = true;
            this.gridView1.Appearance.ColumnFilterButtonActive.Options.UseForeColor = true;
            this.gridView1.Appearance.Empty.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(236)))), ((int)(((byte)(232)))), ((int)(((byte)(201)))));
            this.gridView1.Appearance.Empty.BackColor2 = System.Drawing.Color.White;
            this.gridView1.Appearance.Empty.Options.UseBackColor = true;
            this.gridView1.Appearance.EvenRow.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(221)))), ((int)(((byte)(231)))), ((int)(((byte)(234)))));
            this.gridView1.Appearance.EvenRow.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(221)))), ((int)(((byte)(231)))), ((int)(((byte)(234)))));
            this.gridView1.Appearance.EvenRow.ForeColor = System.Drawing.Color.Black;
            this.gridView1.Appearance.EvenRow.Options.UseBackColor = true;
            this.gridView1.Appearance.EvenRow.Options.UseBorderColor = true;
            this.gridView1.Appearance.EvenRow.Options.UseForeColor = true;
            this.gridView1.Appearance.FilterCloseButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(216)))), ((int)(((byte)(209)))), ((int)(((byte)(179)))));
            this.gridView1.Appearance.FilterCloseButton.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(216)))), ((int)(((byte)(209)))), ((int)(((byte)(179)))));
            this.gridView1.Appearance.FilterCloseButton.ForeColor = System.Drawing.Color.Black;
            this.gridView1.Appearance.FilterCloseButton.Options.UseBackColor = true;
            this.gridView1.Appearance.FilterCloseButton.Options.UseBorderColor = true;
            this.gridView1.Appearance.FilterCloseButton.Options.UseForeColor = true;
            this.gridView1.Appearance.FilterPanel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(236)))), ((int)(((byte)(232)))), ((int)(((byte)(201)))));
            this.gridView1.Appearance.FilterPanel.BackColor2 = System.Drawing.Color.White;
            this.gridView1.Appearance.FilterPanel.ForeColor = System.Drawing.Color.Black;
            this.gridView1.Appearance.FilterPanel.Options.UseBackColor = true;
            this.gridView1.Appearance.FilterPanel.Options.UseForeColor = true;
            this.gridView1.Appearance.FixedLine.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(122)))), ((int)(((byte)(114)))), ((int)(((byte)(113)))));
            this.gridView1.Appearance.FixedLine.Options.UseBackColor = true;
            this.gridView1.Appearance.FocusedCell.BackColor = System.Drawing.Color.White;
            this.gridView1.Appearance.FocusedCell.ForeColor = System.Drawing.Color.Black;
            this.gridView1.Appearance.FocusedCell.Options.UseBackColor = true;
            this.gridView1.Appearance.FocusedCell.Options.UseForeColor = true;
            this.gridView1.Appearance.FocusedRow.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(200)))), ((int)(((byte)(192)))), ((int)(((byte)(157)))));
            this.gridView1.Appearance.FocusedRow.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(219)))), ((int)(((byte)(188)))));
            this.gridView1.Appearance.FocusedRow.ForeColor = System.Drawing.Color.Black;
            this.gridView1.Appearance.FocusedRow.Options.UseBackColor = true;
            this.gridView1.Appearance.FocusedRow.Options.UseBorderColor = true;
            this.gridView1.Appearance.FocusedRow.Options.UseForeColor = true;
            this.gridView1.Appearance.FooterPanel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(216)))), ((int)(((byte)(209)))), ((int)(((byte)(170)))));
            this.gridView1.Appearance.FooterPanel.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(216)))), ((int)(((byte)(209)))), ((int)(((byte)(170)))));
            this.gridView1.Appearance.FooterPanel.ForeColor = System.Drawing.Color.Black;
            this.gridView1.Appearance.FooterPanel.Options.UseBackColor = true;
            this.gridView1.Appearance.FooterPanel.Options.UseBorderColor = true;
            this.gridView1.Appearance.FooterPanel.Options.UseForeColor = true;
            this.gridView1.Appearance.GroupButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(216)))), ((int)(((byte)(209)))), ((int)(((byte)(179)))));
            this.gridView1.Appearance.GroupButton.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(216)))), ((int)(((byte)(209)))), ((int)(((byte)(179)))));
            this.gridView1.Appearance.GroupButton.Options.UseBackColor = true;
            this.gridView1.Appearance.GroupButton.Options.UseBorderColor = true;
            this.gridView1.Appearance.GroupFooter.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(236)))), ((int)(((byte)(232)))), ((int)(((byte)(201)))));
            this.gridView1.Appearance.GroupFooter.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(236)))), ((int)(((byte)(232)))), ((int)(((byte)(201)))));
            this.gridView1.Appearance.GroupFooter.ForeColor = System.Drawing.Color.Black;
            this.gridView1.Appearance.GroupFooter.Options.UseBackColor = true;
            this.gridView1.Appearance.GroupFooter.Options.UseBorderColor = true;
            this.gridView1.Appearance.GroupFooter.Options.UseForeColor = true;
            this.gridView1.Appearance.GroupPanel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(246)))), ((int)(((byte)(242)))), ((int)(((byte)(213)))));
            this.gridView1.Appearance.GroupPanel.BackColor2 = System.Drawing.Color.White;
            this.gridView1.Appearance.GroupPanel.ForeColor = System.Drawing.Color.Black;
            this.gridView1.Appearance.GroupPanel.Options.UseBackColor = true;
            this.gridView1.Appearance.GroupPanel.Options.UseForeColor = true;
            this.gridView1.Appearance.GroupRow.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(236)))), ((int)(((byte)(232)))), ((int)(((byte)(201)))));
            this.gridView1.Appearance.GroupRow.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(236)))), ((int)(((byte)(232)))), ((int)(((byte)(201)))));
            this.gridView1.Appearance.GroupRow.ForeColor = System.Drawing.Color.Black;
            this.gridView1.Appearance.GroupRow.Options.UseBackColor = true;
            this.gridView1.Appearance.GroupRow.Options.UseBorderColor = true;
            this.gridView1.Appearance.GroupRow.Options.UseForeColor = true;
            this.gridView1.Appearance.HeaderPanel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(216)))), ((int)(((byte)(209)))), ((int)(((byte)(170)))));
            this.gridView1.Appearance.HeaderPanel.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(216)))), ((int)(((byte)(209)))), ((int)(((byte)(170)))));
            this.gridView1.Appearance.HeaderPanel.ForeColor = System.Drawing.Color.Black;
            this.gridView1.Appearance.HeaderPanel.Options.UseBackColor = true;
            this.gridView1.Appearance.HeaderPanel.Options.UseBorderColor = true;
            this.gridView1.Appearance.HeaderPanel.Options.UseForeColor = true;
            this.gridView1.Appearance.HideSelectionRow.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(237)))), ((int)(((byte)(230)))), ((int)(((byte)(203)))));
            this.gridView1.Appearance.HideSelectionRow.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(237)))), ((int)(((byte)(230)))), ((int)(((byte)(203)))));
            this.gridView1.Appearance.HideSelectionRow.ForeColor = System.Drawing.Color.Black;
            this.gridView1.Appearance.HideSelectionRow.Options.UseBackColor = true;
            this.gridView1.Appearance.HideSelectionRow.Options.UseBorderColor = true;
            this.gridView1.Appearance.HideSelectionRow.Options.UseForeColor = true;
            this.gridView1.Appearance.HorzLine.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(216)))), ((int)(((byte)(209)))), ((int)(((byte)(170)))));
            this.gridView1.Appearance.HorzLine.Options.UseBackColor = true;
            this.gridView1.Appearance.OddRow.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(242)))), ((int)(((byte)(244)))), ((int)(((byte)(236)))));
            this.gridView1.Appearance.OddRow.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(242)))), ((int)(((byte)(244)))), ((int)(((byte)(236)))));
            this.gridView1.Appearance.OddRow.ForeColor = System.Drawing.Color.Black;
            this.gridView1.Appearance.OddRow.Options.UseBackColor = true;
            this.gridView1.Appearance.OddRow.Options.UseBorderColor = true;
            this.gridView1.Appearance.OddRow.Options.UseForeColor = true;
            this.gridView1.Appearance.Preview.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(251)))), ((int)(((byte)(252)))), ((int)(((byte)(247)))));
            this.gridView1.Appearance.Preview.Font = new System.Drawing.Font("Verdana", 7.5F);
            this.gridView1.Appearance.Preview.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(148)))), ((int)(((byte)(148)))), ((int)(((byte)(148)))));
            this.gridView1.Appearance.Preview.Options.UseBackColor = true;
            this.gridView1.Appearance.Preview.Options.UseFont = true;
            this.gridView1.Appearance.Preview.Options.UseForeColor = true;
            this.gridView1.Appearance.Row.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(242)))), ((int)(((byte)(244)))), ((int)(((byte)(236)))));
            this.gridView1.Appearance.Row.ForeColor = System.Drawing.Color.Black;
            this.gridView1.Appearance.Row.Options.UseBackColor = true;
            this.gridView1.Appearance.Row.Options.UseForeColor = true;
            this.gridView1.Appearance.RowSeparator.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(236)))), ((int)(((byte)(232)))), ((int)(((byte)(201)))));
            this.gridView1.Appearance.RowSeparator.BackColor2 = System.Drawing.Color.White;
            this.gridView1.Appearance.RowSeparator.Options.UseBackColor = true;
            this.gridView1.Appearance.SelectedRow.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(221)))), ((int)(((byte)(215)))), ((int)(((byte)(188)))));
            this.gridView1.Appearance.SelectedRow.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(237)))), ((int)(((byte)(230)))), ((int)(((byte)(203)))));
            this.gridView1.Appearance.SelectedRow.ForeColor = System.Drawing.Color.Black;
            this.gridView1.Appearance.SelectedRow.Options.UseBackColor = true;
            this.gridView1.Appearance.SelectedRow.Options.UseBorderColor = true;
            this.gridView1.Appearance.SelectedRow.Options.UseForeColor = true;
            this.gridView1.Appearance.TopNewRow.BackColor = System.Drawing.Color.White;
            this.gridView1.Appearance.TopNewRow.Options.UseBackColor = true;
            this.gridView1.Appearance.VertLine.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(216)))), ((int)(((byte)(209)))), ((int)(((byte)(170)))));
            this.gridView1.Appearance.VertLine.Options.UseBackColor = true;
            this.gridView1.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.gridColiSave,
            this.gridColID,
            this.gridColdDate,
            this.gridColVenCode,
            this.gridColDoor,
            this.gridColInvCode,
            this.gridColRemark,
            this.gridColiHZ,
            this.gridColiSheQty,
            this.gridColiBoxQty,
            this.gridColOrderNo,
            this.gridColiSheDate,
            this.gridColBarCode,
            this.gridCol产品名称,
            this.gridColiQty,
            this.gridColiOutDate,
            this.gridColCreateUid,
            this.gridColCreateDate,
            this.gridColUpdateUid,
            this.gridColUpdateDate,
            this.gridColiDisQty,
            this.gridColiOutQty,
            this.gridColDisDate});
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
            this.gridView1.FocusedRowChanged += new DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventHandler(this.gridView1_FocusedRowChanged);
            this.gridView1.CustomDrawRowIndicator += new DevExpress.XtraGrid.Views.Grid.RowIndicatorCustomDrawEventHandler(this.gridView1_CustomDrawRowIndicator);
            this.gridView1.CellValueChanged += new DevExpress.XtraGrid.Views.Base.CellValueChangedEventHandler(this.gridView1_CellValueChanged);
            // 
            // gridColiSave
            // 
            this.gridColiSave.Caption = "编辑状态";
            this.gridColiSave.FieldName = "iSave";
            this.gridColiSave.Name = "gridColiSave";
            this.gridColiSave.OptionsColumn.AllowEdit = false;
            // 
            // gridColID
            // 
            this.gridColID.Caption = "序号";
            this.gridColID.FieldName = "ID";
            this.gridColID.Name = "gridColID";
            this.gridColID.OptionsColumn.AllowEdit = false;
            this.gridColID.Visible = true;
            this.gridColID.VisibleIndex = 0;
            // 
            // gridColdDate
            // 
            this.gridColdDate.Caption = "登记日期";
            this.gridColdDate.FieldName = "dDate";
            this.gridColdDate.Name = "gridColdDate";
            this.gridColdDate.OptionsColumn.AllowEdit = false;
            this.gridColdDate.Visible = true;
            this.gridColdDate.VisibleIndex = 9;
            // 
            // gridColVenCode
            // 
            this.gridColVenCode.Caption = "供应商";
            this.gridColVenCode.FieldName = "VenCode";
            this.gridColVenCode.Name = "gridColVenCode";
            this.gridColVenCode.OptionsColumn.AllowEdit = false;
            this.gridColVenCode.Visible = true;
            this.gridColVenCode.VisibleIndex = 1;
            this.gridColVenCode.Width = 117;
            // 
            // gridColDoor
            // 
            this.gridColDoor.Caption = "门号";
            this.gridColDoor.FieldName = "Door";
            this.gridColDoor.Name = "gridColDoor";
            this.gridColDoor.OptionsColumn.AllowEdit = false;
            this.gridColDoor.Visible = true;
            this.gridColDoor.VisibleIndex = 2;
            // 
            // gridColInvCode
            // 
            this.gridColInvCode.Caption = "品番";
            this.gridColInvCode.FieldName = "InvCode";
            this.gridColInvCode.Name = "gridColInvCode";
            this.gridColInvCode.OptionsColumn.AllowEdit = false;
            this.gridColInvCode.Visible = true;
            this.gridColInvCode.VisibleIndex = 3;
            this.gridColInvCode.Width = 137;
            // 
            // gridColRemark
            // 
            this.gridColRemark.Caption = "备注";
            this.gridColRemark.FieldName = "Remark";
            this.gridColRemark.Name = "gridColRemark";
            this.gridColRemark.Visible = true;
            this.gridColRemark.VisibleIndex = 11;
            this.gridColRemark.Width = 95;
            // 
            // gridColiHZ
            // 
            this.gridColiHZ.Caption = "何姿";
            this.gridColiHZ.FieldName = "iHZ";
            this.gridColiHZ.Name = "gridColiHZ";
            this.gridColiHZ.Visible = true;
            this.gridColiHZ.VisibleIndex = 5;
            this.gridColiHZ.Width = 60;
            // 
            // gridColiSheQty
            // 
            this.gridColiSheQty.Caption = "收容数";
            this.gridColiSheQty.DisplayFormat.FormatString = "N0";
            this.gridColiSheQty.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.gridColiSheQty.FieldName = "iSheQty";
            this.gridColiSheQty.Name = "gridColiSheQty";
            this.gridColiSheQty.OptionsColumn.AllowEdit = false;
            this.gridColiSheQty.Visible = true;
            this.gridColiSheQty.VisibleIndex = 6;
            this.gridColiSheQty.Width = 76;
            // 
            // gridColiBoxQty
            // 
            this.gridColiBoxQty.Caption = "箱数";
            this.gridColiBoxQty.DisplayFormat.FormatString = "N0";
            this.gridColiBoxQty.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.gridColiBoxQty.FieldName = "iBoxQty";
            this.gridColiBoxQty.Name = "gridColiBoxQty";
            this.gridColiBoxQty.OptionsColumn.AllowEdit = false;
            this.gridColiBoxQty.Visible = true;
            this.gridColiBoxQty.VisibleIndex = 7;
            // 
            // gridColOrderNo
            // 
            this.gridColOrderNo.Caption = "定单编号";
            this.gridColOrderNo.FieldName = "OrderNo";
            this.gridColOrderNo.Name = "gridColOrderNo";
            this.gridColOrderNo.OptionsColumn.AllowEdit = false;
            this.gridColOrderNo.Visible = true;
            this.gridColOrderNo.VisibleIndex = 10;
            // 
            // gridColiSheDate
            // 
            this.gridColiSheDate.Caption = "纳入指示日";
            this.gridColiSheDate.FieldName = "iSheDate";
            this.gridColiSheDate.Name = "gridColiSheDate";
            this.gridColiSheDate.OptionsColumn.AllowEdit = false;
            this.gridColiSheDate.Visible = true;
            this.gridColiSheDate.VisibleIndex = 12;
            // 
            // gridColBarCode
            // 
            this.gridColBarCode.Caption = "二维码";
            this.gridColBarCode.FieldName = "BarCode";
            this.gridColBarCode.Name = "gridColBarCode";
            this.gridColBarCode.OptionsColumn.AllowEdit = false;
            this.gridColBarCode.Visible = true;
            this.gridColBarCode.VisibleIndex = 17;
            // 
            // gridCol产品名称
            // 
            this.gridCol产品名称.Caption = "产品名称";
            this.gridCol产品名称.ColumnEdit = this.ItemLookUpEdit产品名称;
            this.gridCol产品名称.FieldName = "InvCode";
            this.gridCol产品名称.Name = "gridCol产品名称";
            this.gridCol产品名称.OptionsColumn.AllowEdit = false;
            this.gridCol产品名称.Visible = true;
            this.gridCol产品名称.VisibleIndex = 4;
            // 
            // ItemLookUpEdit产品名称
            // 
            this.ItemLookUpEdit产品名称.AutoHeight = false;
            this.ItemLookUpEdit产品名称.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.ItemLookUpEdit产品名称.Name = "ItemLookUpEdit产品名称";
            // 
            // gridColiQty
            // 
            this.gridColiQty.Caption = "送货数量";
            this.gridColiQty.DisplayFormat.FormatString = "N0";
            this.gridColiQty.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.gridColiQty.FieldName = "iQty";
            this.gridColiQty.Name = "gridColiQty";
            this.gridColiQty.OptionsColumn.AllowEdit = false;
            this.gridColiQty.Visible = true;
            this.gridColiQty.VisibleIndex = 8;
            // 
            // gridColiOutDate
            // 
            this.gridColiOutDate.Caption = "出库日期";
            this.gridColiOutDate.FieldName = "iOutDate";
            this.gridColiOutDate.Name = "gridColiOutDate";
            this.gridColiOutDate.OptionsColumn.AllowEdit = false;
            this.gridColiOutDate.Visible = true;
            this.gridColiOutDate.VisibleIndex = 16;
            // 
            // gridColCreateUid
            // 
            this.gridColCreateUid.Caption = "CreateUid";
            this.gridColCreateUid.FieldName = "CreateUid";
            this.gridColCreateUid.Name = "gridColCreateUid";
            this.gridColCreateUid.OptionsColumn.AllowEdit = false;
            // 
            // gridColCreateDate
            // 
            this.gridColCreateDate.Caption = "CreateDate";
            this.gridColCreateDate.FieldName = "CreateDate";
            this.gridColCreateDate.Name = "gridColCreateDate";
            this.gridColCreateDate.OptionsColumn.AllowEdit = false;
            // 
            // gridColUpdateUid
            // 
            this.gridColUpdateUid.Caption = "UpdateUid";
            this.gridColUpdateUid.FieldName = "UpdateUid";
            this.gridColUpdateUid.Name = "gridColUpdateUid";
            this.gridColUpdateUid.OptionsColumn.AllowEdit = false;
            // 
            // gridColUpdateDate
            // 
            this.gridColUpdateDate.Caption = "UpdateDate";
            this.gridColUpdateDate.FieldName = "UpdateDate";
            this.gridColUpdateDate.Name = "gridColUpdateDate";
            this.gridColUpdateDate.OptionsColumn.AllowEdit = false;
            // 
            // gridColiDisQty
            // 
            this.gridColiDisQty.Caption = "备货数量";
            this.gridColiDisQty.FieldName = "iDisQty";
            this.gridColiDisQty.Name = "gridColiDisQty";
            this.gridColiDisQty.OptionsColumn.AllowEdit = false;
            this.gridColiDisQty.Visible = true;
            this.gridColiDisQty.VisibleIndex = 13;
            this.gridColiDisQty.Width = 92;
            // 
            // gridColiOutQty
            // 
            this.gridColiOutQty.Caption = "出库数量";
            this.gridColiOutQty.FieldName = "iOutQty";
            this.gridColiOutQty.Name = "gridColiOutQty";
            this.gridColiOutQty.OptionsColumn.AllowEdit = false;
            this.gridColiOutQty.Visible = true;
            this.gridColiOutQty.VisibleIndex = 15;
            // 
            // gridColDisDate
            // 
            this.gridColDisDate.Caption = "备货日期";
            this.gridColDisDate.FieldName = "DisDate";
            this.gridColDisDate.Name = "gridColDisDate";
            this.gridColDisDate.OptionsColumn.AllowEdit = false;
            this.gridColDisDate.Visible = true;
            this.gridColDisDate.VisibleIndex = 14;
            this.gridColDisDate.Width = 98;
            // 
            // layoutControlGroup1
            // 
            this.layoutControlGroup1.CustomizationFormText = "layoutControlGroup1";
            this.layoutControlGroup1.EnableIndentsWithoutBorders = DevExpress.Utils.DefaultBoolean.True;
            this.layoutControlGroup1.GroupBordersVisible = false;
            this.layoutControlGroup1.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.layoutControlItem3});
            this.layoutControlGroup1.Location = new System.Drawing.Point(0, 0);
            this.layoutControlGroup1.Name = "Root";
            this.layoutControlGroup1.Size = new System.Drawing.Size(1252, 457);
            this.layoutControlGroup1.Text = "Root";
            this.layoutControlGroup1.TextVisible = false;
            // 
            // layoutControlItem3
            // 
            this.layoutControlItem3.Control = this.gridControl1;
            this.layoutControlItem3.CustomizationFormText = "layoutControlItem3";
            this.layoutControlItem3.Location = new System.Drawing.Point(0, 0);
            this.layoutControlItem3.Name = "layoutControlItem3";
            this.layoutControlItem3.Size = new System.Drawing.Size(1232, 437);
            this.layoutControlItem3.Text = "layoutControlItem3";
            this.layoutControlItem3.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem3.TextToControlDistance = 0;
            this.layoutControlItem3.TextVisible = false;
            // 
            // Frm现品票
            // 
            this.Appearance.BackColor = System.Drawing.SystemColors.Control;
            this.Appearance.Options.UseBackColor = true;
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1250, 486);
            this.Controls.Add(this.layoutControl1);
            this.Name = "Frm现品票";
            this.Text = "现品票";
            this.Load += new System.EventHandler(this.Frm现品票_Load);
            this.Controls.SetChildIndex(this.layoutControl1, 0);
            ((System.ComponentModel.ISupportInitialize)(this.dsPrint)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dsForm)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtSel)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControl1)).EndInit();
            this.layoutControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ItemLookUpEdit产品名称)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem3)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraLayout.LayoutControl layoutControl1;
        private DevExpress.XtraGrid.GridControl gridControl1;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView1;
        private DevExpress.XtraLayout.LayoutControlGroup layoutControlGroup1;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem3;
        private DevExpress.XtraGrid.Columns.GridColumn gridColInvCode;
        private DevExpress.XtraGrid.Columns.GridColumn gridColiSave;
        private DevExpress.XtraGrid.Columns.GridColumn gridColRemark;
        private DevExpress.XtraGrid.Columns.GridColumn gridColID;
        private DevExpress.XtraGrid.Columns.GridColumn gridColiHZ;
        private DevExpress.XtraGrid.Columns.GridColumn gridColiSheQty;
        private DevExpress.XtraGrid.Columns.GridColumn gridColdDate;
        private DevExpress.XtraGrid.Columns.GridColumn gridColVenCode;
        private DevExpress.XtraGrid.Columns.GridColumn gridColDoor;
        private DevExpress.XtraGrid.Columns.GridColumn gridColiBoxQty;
        private DevExpress.XtraGrid.Columns.GridColumn gridColOrderNo;
        private DevExpress.XtraGrid.Columns.GridColumn gridColiSheDate;
        private DevExpress.XtraGrid.Columns.GridColumn gridColBarCode;
        private DevExpress.XtraGrid.Columns.GridColumn gridCol产品名称;
        private DevExpress.XtraGrid.Columns.GridColumn gridColiQty;
        private DevExpress.XtraGrid.Columns.GridColumn gridColiOutDate;
        private DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit ItemLookUpEdit产品名称;
        private DevExpress.XtraGrid.Columns.GridColumn gridColCreateUid;
        private DevExpress.XtraGrid.Columns.GridColumn gridColCreateDate;
        private DevExpress.XtraGrid.Columns.GridColumn gridColUpdateUid;
        private DevExpress.XtraGrid.Columns.GridColumn gridColUpdateDate;
        private DevExpress.XtraGrid.Columns.GridColumn gridColiDisQty;
        private DevExpress.XtraGrid.Columns.GridColumn gridColiOutQty;
        private DevExpress.XtraGrid.Columns.GridColumn gridColDisDate;
    }
}