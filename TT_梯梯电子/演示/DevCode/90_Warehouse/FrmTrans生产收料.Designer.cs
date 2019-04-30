namespace Warehouse
{
    partial class FrmTrans生产收料
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
            DevExpress.XtraGrid.GridLevelNode gridLevelNode1 = new DevExpress.XtraGrid.GridLevelNode();
            this.gridControl1 = new DevExpress.XtraGrid.GridControl();
            this.gridView1 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.gridColbChoose = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColcsource = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColitransflag = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColcTVCode = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColdTVDate = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColcOWhCode = new DevExpress.XtraGrid.Columns.GridColumn();
            this.ItemLookUpEditWH = new DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit();
            this.gridColcIWhCode = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColcODepCode = new DevExpress.XtraGrid.Columns.GridColumn();
            this.ItemLookUpEditDep = new DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit();
            this.gridColcIDepCode = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColcIRdCode = new DevExpress.XtraGrid.Columns.GridColumn();
            this.ItemLookUpEditRd_Style = new DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit();
            this.gridColcORdCode = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColcTVMemo = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColcMaker = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColcVerifyPerson = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColdVerifyDate = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColcPSPCode = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColcMPoCode = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColiQuantity = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColiproorderid = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColcOrderType = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColcTranRequestCode = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColcVersion = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColBomId = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColcInvCode = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColcInvName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColcInvStd = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColiTVQuantity = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColiTVNum = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColcmocode = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColimoseq = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColcomcode = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColinvcode = new DevExpress.XtraGrid.Columns.GridColumn();
            this.dateEdit1 = new DevExpress.XtraEditors.DateEdit();
            this.label7 = new System.Windows.Forms.Label();
            this.radioUnAudit = new System.Windows.Forms.RadioButton();
            this.radioAudit = new System.Windows.Forms.RadioButton();
            this.chkAll = new System.Windows.Forms.CheckBox();
            this.label1 = new System.Windows.Forms.Label();
            this.lookUpEdit收料班组 = new DevExpress.XtraEditors.LookUpEdit();
            this.gridCol调拨单表体ID = new DevExpress.XtraGrid.Columns.GridColumn();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ItemLookUpEditWH)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ItemLookUpEditDep)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ItemLookUpEditRd_Style)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dateEdit1.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lookUpEdit收料班组.Properties)).BeginInit();
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
            gridLevelNode1.RelationName = "Level1";
            this.gridControl1.LevelTree.Nodes.AddRange(new DevExpress.XtraGrid.GridLevelNode[] {
            gridLevelNode1});
            this.gridControl1.Location = new System.Drawing.Point(0, 76);
            this.gridControl1.MainView = this.gridView1;
            this.gridControl1.Name = "gridControl1";
            this.gridControl1.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.ItemLookUpEditDep,
            this.ItemLookUpEditWH,
            this.ItemLookUpEditRd_Style});
            this.gridControl1.Size = new System.Drawing.Size(930, 384);
            this.gridControl1.TabIndex = 71;
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
            this.gridColbChoose,
            this.gridColcsource,
            this.gridColitransflag,
            this.gridColcTVCode,
            this.gridColdTVDate,
            this.gridColcOWhCode,
            this.gridColcIWhCode,
            this.gridColcODepCode,
            this.gridColcIDepCode,
            this.gridColcIRdCode,
            this.gridColcORdCode,
            this.gridColcTVMemo,
            this.gridColcMaker,
            this.gridColcVerifyPerson,
            this.gridColdVerifyDate,
            this.gridColcPSPCode,
            this.gridColcMPoCode,
            this.gridColiQuantity,
            this.gridColiproorderid,
            this.gridColcOrderType,
            this.gridColcTranRequestCode,
            this.gridColcVersion,
            this.gridColBomId,
            this.gridColcInvCode,
            this.gridColcInvName,
            this.gridColcInvStd,
            this.gridColiTVQuantity,
            this.gridColiTVNum,
            this.gridColcmocode,
            this.gridColimoseq,
            this.gridColcomcode,
            this.gridColinvcode,
            this.gridCol调拨单表体ID});
            this.gridView1.CustomizationFormBounds = new System.Drawing.Rectangle(816, 318, 208, 177);
            this.gridView1.GridControl = this.gridControl1;
            this.gridView1.IndicatorWidth = 40;
            this.gridView1.Name = "gridView1";
            this.gridView1.OptionsCustomization.AllowSort = false;
            this.gridView1.OptionsDetail.AllowExpandEmptyDetails = true;
            this.gridView1.OptionsDetail.AllowOnlyOneMasterRowExpanded = true;
            this.gridView1.OptionsNavigation.EnterMoveNextColumn = true;
            this.gridView1.OptionsPrint.AutoWidth = false;
            this.gridView1.OptionsPrint.ExpandAllDetails = true;
            this.gridView1.OptionsView.AllowCellMerge = true;
            this.gridView1.OptionsView.ColumnAutoWidth = false;
            this.gridView1.OptionsView.EnableAppearanceEvenRow = true;
            this.gridView1.OptionsView.EnableAppearanceOddRow = true;
            this.gridView1.OptionsView.ShowGroupPanel = false;
            this.gridView1.CellMerge += new DevExpress.XtraGrid.Views.Grid.CellMergeEventHandler(this.gridView1_CellMerge);
            this.gridView1.CustomDrawRowIndicator += new DevExpress.XtraGrid.Views.Grid.RowIndicatorCustomDrawEventHandler(this.gridView1_CustomDrawRowIndicator);
            this.gridView1.DoubleClick += new System.EventHandler(this.gridView1_DoubleClick);
            // 
            // gridColbChoose
            // 
            this.gridColbChoose.FieldName = "bChoose";
            this.gridColbChoose.Name = "gridColbChoose";
            this.gridColbChoose.OptionsColumn.AllowEdit = false;
            this.gridColbChoose.OptionsFilter.AllowFilter = false;
            this.gridColbChoose.Visible = true;
            this.gridColbChoose.VisibleIndex = 0;
            this.gridColbChoose.Width = 29;
            // 
            // gridColcsource
            // 
            this.gridColcsource.Caption = "单据来源 ";
            this.gridColcsource.FieldName = "csource";
            this.gridColcsource.Name = "gridColcsource";
            this.gridColcsource.OptionsColumn.AllowEdit = false;
            this.gridColcsource.Width = 67;
            // 
            // gridColitransflag
            // 
            this.gridColitransflag.Caption = "调拨方向 ";
            this.gridColitransflag.FieldName = "itransflag";
            this.gridColitransflag.Name = "gridColitransflag";
            this.gridColitransflag.OptionsColumn.AllowEdit = false;
            this.gridColitransflag.Visible = true;
            this.gridColitransflag.VisibleIndex = 1;
            this.gridColitransflag.Width = 65;
            // 
            // gridColcTVCode
            // 
            this.gridColcTVCode.Caption = "调拨单号 ";
            this.gridColcTVCode.FieldName = "cTVCode";
            this.gridColcTVCode.Name = "gridColcTVCode";
            this.gridColcTVCode.OptionsColumn.AllowEdit = false;
            this.gridColcTVCode.Visible = true;
            this.gridColcTVCode.VisibleIndex = 3;
            this.gridColcTVCode.Width = 94;
            // 
            // gridColdTVDate
            // 
            this.gridColdTVDate.Caption = "单据日期";
            this.gridColdTVDate.FieldName = "dTVDate";
            this.gridColdTVDate.Name = "gridColdTVDate";
            this.gridColdTVDate.OptionsColumn.AllowEdit = false;
            this.gridColdTVDate.Visible = true;
            this.gridColdTVDate.VisibleIndex = 2;
            // 
            // gridColcOWhCode
            // 
            this.gridColcOWhCode.Caption = "转出仓库";
            this.gridColcOWhCode.ColumnEdit = this.ItemLookUpEditWH;
            this.gridColcOWhCode.FieldName = "cOWhCode";
            this.gridColcOWhCode.Name = "gridColcOWhCode";
            this.gridColcOWhCode.OptionsColumn.AllowEdit = false;
            this.gridColcOWhCode.Visible = true;
            this.gridColcOWhCode.VisibleIndex = 9;
            // 
            // ItemLookUpEditWH
            // 
            this.ItemLookUpEditWH.AutoHeight = false;
            this.ItemLookUpEditWH.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.ItemLookUpEditWH.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("iID", "仓库编码", 20, DevExpress.Utils.FormatType.None, "", true, DevExpress.Utils.HorzAlignment.Default, DevExpress.Data.ColumnSortOrder.None),
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("iText", "仓库名称", 20, DevExpress.Utils.FormatType.None, "", true, DevExpress.Utils.HorzAlignment.Default, DevExpress.Data.ColumnSortOrder.None)});
            this.ItemLookUpEditWH.DisplayMember = "iText";
            this.ItemLookUpEditWH.Name = "ItemLookUpEditWH";
            this.ItemLookUpEditWH.ValueMember = "iID";
            // 
            // gridColcIWhCode
            // 
            this.gridColcIWhCode.Caption = "转入仓库";
            this.gridColcIWhCode.ColumnEdit = this.ItemLookUpEditWH;
            this.gridColcIWhCode.FieldName = "cIWhCode";
            this.gridColcIWhCode.Name = "gridColcIWhCode";
            this.gridColcIWhCode.OptionsColumn.AllowEdit = false;
            this.gridColcIWhCode.Visible = true;
            this.gridColcIWhCode.VisibleIndex = 10;
            // 
            // gridColcODepCode
            // 
            this.gridColcODepCode.Caption = "转出部门";
            this.gridColcODepCode.ColumnEdit = this.ItemLookUpEditDep;
            this.gridColcODepCode.FieldName = "cODepCode";
            this.gridColcODepCode.Name = "gridColcODepCode";
            this.gridColcODepCode.OptionsColumn.AllowEdit = false;
            this.gridColcODepCode.Visible = true;
            this.gridColcODepCode.VisibleIndex = 11;
            // 
            // ItemLookUpEditDep
            // 
            this.ItemLookUpEditDep.AutoHeight = false;
            this.ItemLookUpEditDep.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.ItemLookUpEditDep.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("iID", "部门编码", 20, DevExpress.Utils.FormatType.None, "", true, DevExpress.Utils.HorzAlignment.Default, DevExpress.Data.ColumnSortOrder.None),
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("iText", "部门名称", 20, DevExpress.Utils.FormatType.None, "", true, DevExpress.Utils.HorzAlignment.Default, DevExpress.Data.ColumnSortOrder.None)});
            this.ItemLookUpEditDep.DisplayMember = "iText";
            this.ItemLookUpEditDep.Name = "ItemLookUpEditDep";
            this.ItemLookUpEditDep.ValueMember = "iID";
            // 
            // gridColcIDepCode
            // 
            this.gridColcIDepCode.Caption = "转入部门";
            this.gridColcIDepCode.ColumnEdit = this.ItemLookUpEditDep;
            this.gridColcIDepCode.FieldName = "cIDepCode";
            this.gridColcIDepCode.Name = "gridColcIDepCode";
            this.gridColcIDepCode.OptionsColumn.AllowEdit = false;
            this.gridColcIDepCode.Visible = true;
            this.gridColcIDepCode.VisibleIndex = 12;
            // 
            // gridColcIRdCode
            // 
            this.gridColcIRdCode.Caption = "入库类别";
            this.gridColcIRdCode.ColumnEdit = this.ItemLookUpEditRd_Style;
            this.gridColcIRdCode.FieldName = "cIRdCode";
            this.gridColcIRdCode.Name = "gridColcIRdCode";
            this.gridColcIRdCode.OptionsColumn.AllowEdit = false;
            // 
            // ItemLookUpEditRd_Style
            // 
            this.ItemLookUpEditRd_Style.AutoHeight = false;
            this.ItemLookUpEditRd_Style.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.ItemLookUpEditRd_Style.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("iID", "编码", 20, DevExpress.Utils.FormatType.None, "", true, DevExpress.Utils.HorzAlignment.Default, DevExpress.Data.ColumnSortOrder.None),
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("iText", "名称", 20, DevExpress.Utils.FormatType.None, "", true, DevExpress.Utils.HorzAlignment.Default, DevExpress.Data.ColumnSortOrder.None)});
            this.ItemLookUpEditRd_Style.DisplayMember = "iText";
            this.ItemLookUpEditRd_Style.Name = "ItemLookUpEditRd_Style";
            this.ItemLookUpEditRd_Style.ValueMember = "iID";
            // 
            // gridColcORdCode
            // 
            this.gridColcORdCode.Caption = "出库类别";
            this.gridColcORdCode.ColumnEdit = this.ItemLookUpEditRd_Style;
            this.gridColcORdCode.FieldName = "cORdCode";
            this.gridColcORdCode.Name = "gridColcORdCode";
            this.gridColcORdCode.OptionsColumn.AllowEdit = false;
            // 
            // gridColcTVMemo
            // 
            this.gridColcTVMemo.Caption = "备注";
            this.gridColcTVMemo.FieldName = "cTVMemo";
            this.gridColcTVMemo.Name = "gridColcTVMemo";
            this.gridColcTVMemo.OptionsColumn.AllowEdit = false;
            this.gridColcTVMemo.Visible = true;
            this.gridColcTVMemo.VisibleIndex = 13;
            // 
            // gridColcMaker
            // 
            this.gridColcMaker.Caption = "制单人";
            this.gridColcMaker.FieldName = "cMaker";
            this.gridColcMaker.Name = "gridColcMaker";
            this.gridColcMaker.OptionsColumn.AllowEdit = false;
            this.gridColcMaker.Visible = true;
            this.gridColcMaker.VisibleIndex = 14;
            // 
            // gridColcVerifyPerson
            // 
            this.gridColcVerifyPerson.Caption = "审核人";
            this.gridColcVerifyPerson.FieldName = "cVerifyPerson";
            this.gridColcVerifyPerson.Name = "gridColcVerifyPerson";
            this.gridColcVerifyPerson.OptionsColumn.AllowEdit = false;
            this.gridColcVerifyPerson.Visible = true;
            this.gridColcVerifyPerson.VisibleIndex = 15;
            // 
            // gridColdVerifyDate
            // 
            this.gridColdVerifyDate.Caption = "审核日期";
            this.gridColdVerifyDate.FieldName = "dVerifyDate";
            this.gridColdVerifyDate.Name = "gridColdVerifyDate";
            this.gridColdVerifyDate.OptionsColumn.AllowEdit = false;
            this.gridColdVerifyDate.Visible = true;
            this.gridColdVerifyDate.VisibleIndex = 16;
            // 
            // gridColcPSPCode
            // 
            this.gridColcPSPCode.Caption = "父项产品编码 ";
            this.gridColcPSPCode.FieldName = "cPSPCode";
            this.gridColcPSPCode.Name = "gridColcPSPCode";
            this.gridColcPSPCode.OptionsColumn.AllowEdit = false;
            this.gridColcPSPCode.Visible = true;
            this.gridColcPSPCode.VisibleIndex = 17;
            this.gridColcPSPCode.Width = 101;
            // 
            // gridColcMPoCode
            // 
            this.gridColcMPoCode.Caption = "生产订单编号 ";
            this.gridColcMPoCode.FieldName = "cMPoCode";
            this.gridColcMPoCode.Name = "gridColcMPoCode";
            this.gridColcMPoCode.OptionsColumn.AllowEdit = false;
            this.gridColcMPoCode.Visible = true;
            this.gridColcMPoCode.VisibleIndex = 18;
            // 
            // gridColiQuantity
            // 
            this.gridColiQuantity.Caption = "产量 ";
            this.gridColiQuantity.FieldName = "iQuantity";
            this.gridColiQuantity.Name = "gridColiQuantity";
            this.gridColiQuantity.OptionsColumn.AllowEdit = false;
            this.gridColiQuantity.Visible = true;
            this.gridColiQuantity.VisibleIndex = 19;
            // 
            // gridColiproorderid
            // 
            this.gridColiproorderid.Caption = "生产订单主表标识 ";
            this.gridColiproorderid.FieldName = "iproorderid";
            this.gridColiproorderid.Name = "gridColiproorderid";
            this.gridColiproorderid.OptionsColumn.AllowEdit = false;
            // 
            // gridColcOrderType
            // 
            this.gridColcOrderType.Caption = "订单类型 ";
            this.gridColcOrderType.FieldName = "cOrderType";
            this.gridColcOrderType.Name = "gridColcOrderType";
            this.gridColcOrderType.OptionsColumn.AllowEdit = false;
            this.gridColcOrderType.Visible = true;
            this.gridColcOrderType.VisibleIndex = 20;
            // 
            // gridColcTranRequestCode
            // 
            this.gridColcTranRequestCode.Caption = "调拨申请单号 ";
            this.gridColcTranRequestCode.FieldName = "cTranRequestCode";
            this.gridColcTranRequestCode.Name = "gridColcTranRequestCode";
            this.gridColcTranRequestCode.OptionsColumn.AllowEdit = false;
            // 
            // gridColcVersion
            // 
            this.gridColcVersion.Caption = "版本号";
            this.gridColcVersion.FieldName = "cVersion";
            this.gridColcVersion.Name = "gridColcVersion";
            this.gridColcVersion.OptionsColumn.AllowEdit = false;
            // 
            // gridColBomId
            // 
            this.gridColBomId.Caption = "BomId";
            this.gridColBomId.FieldName = "BomId";
            this.gridColBomId.Name = "gridColBomId";
            this.gridColBomId.OptionsColumn.AllowEdit = false;
            // 
            // gridColcInvCode
            // 
            this.gridColcInvCode.Caption = "存货编码";
            this.gridColcInvCode.FieldName = "cInvCode";
            this.gridColcInvCode.Name = "gridColcInvCode";
            this.gridColcInvCode.OptionsColumn.AllowEdit = false;
            this.gridColcInvCode.OptionsColumn.AllowMerge = DevExpress.Utils.DefaultBoolean.False;
            this.gridColcInvCode.Visible = true;
            this.gridColcInvCode.VisibleIndex = 4;
            // 
            // gridColcInvName
            // 
            this.gridColcInvName.Caption = "存货名称";
            this.gridColcInvName.FieldName = "cInvName";
            this.gridColcInvName.Name = "gridColcInvName";
            this.gridColcInvName.OptionsColumn.AllowEdit = false;
            this.gridColcInvName.OptionsColumn.AllowMerge = DevExpress.Utils.DefaultBoolean.False;
            this.gridColcInvName.Visible = true;
            this.gridColcInvName.VisibleIndex = 5;
            // 
            // gridColcInvStd
            // 
            this.gridColcInvStd.Caption = "规格型号";
            this.gridColcInvStd.FieldName = "cInvStd";
            this.gridColcInvStd.Name = "gridColcInvStd";
            this.gridColcInvStd.OptionsColumn.AllowEdit = false;
            this.gridColcInvStd.OptionsColumn.AllowMerge = DevExpress.Utils.DefaultBoolean.False;
            this.gridColcInvStd.Visible = true;
            this.gridColcInvStd.VisibleIndex = 6;
            // 
            // gridColiTVQuantity
            // 
            this.gridColiTVQuantity.Caption = "数量";
            this.gridColiTVQuantity.FieldName = "iTVQuantity";
            this.gridColiTVQuantity.Name = "gridColiTVQuantity";
            this.gridColiTVQuantity.OptionsColumn.AllowEdit = false;
            this.gridColiTVQuantity.OptionsColumn.AllowMerge = DevExpress.Utils.DefaultBoolean.False;
            this.gridColiTVQuantity.Visible = true;
            this.gridColiTVQuantity.VisibleIndex = 7;
            // 
            // gridColiTVNum
            // 
            this.gridColiTVNum.Caption = "辅计量";
            this.gridColiTVNum.FieldName = "iTVNum";
            this.gridColiTVNum.Name = "gridColiTVNum";
            this.gridColiTVNum.OptionsColumn.AllowEdit = false;
            this.gridColiTVNum.OptionsColumn.AllowMerge = DevExpress.Utils.DefaultBoolean.False;
            this.gridColiTVNum.Visible = true;
            this.gridColiTVNum.VisibleIndex = 8;
            // 
            // gridColcmocode
            // 
            this.gridColcmocode.Caption = "生产订单号";
            this.gridColcmocode.FieldName = "cmocode";
            this.gridColcmocode.Name = "gridColcmocode";
            this.gridColcmocode.OptionsColumn.AllowEdit = false;
            this.gridColcmocode.OptionsColumn.AllowMerge = DevExpress.Utils.DefaultBoolean.False;
            this.gridColcmocode.Visible = true;
            this.gridColcmocode.VisibleIndex = 21;
            // 
            // gridColimoseq
            // 
            this.gridColimoseq.Caption = "生产订单行号";
            this.gridColimoseq.FieldName = "imoseq";
            this.gridColimoseq.Name = "gridColimoseq";
            this.gridColimoseq.OptionsColumn.AllowEdit = false;
            this.gridColimoseq.OptionsColumn.AllowMerge = DevExpress.Utils.DefaultBoolean.False;
            this.gridColimoseq.Visible = true;
            this.gridColimoseq.VisibleIndex = 22;
            // 
            // gridColcomcode
            // 
            this.gridColcomcode.Caption = "委外订单号";
            this.gridColcomcode.FieldName = "comcode";
            this.gridColcomcode.Name = "gridColcomcode";
            this.gridColcomcode.OptionsColumn.AllowEdit = false;
            this.gridColcomcode.OptionsColumn.AllowMerge = DevExpress.Utils.DefaultBoolean.False;
            this.gridColcomcode.Visible = true;
            this.gridColcomcode.VisibleIndex = 23;
            // 
            // gridColinvcode
            // 
            this.gridColinvcode.Caption = "产品编码";
            this.gridColinvcode.FieldName = "invcode";
            this.gridColinvcode.Name = "gridColinvcode";
            this.gridColinvcode.OptionsColumn.AllowEdit = false;
            this.gridColinvcode.OptionsColumn.AllowMerge = DevExpress.Utils.DefaultBoolean.False;
            this.gridColinvcode.Visible = true;
            this.gridColinvcode.VisibleIndex = 24;
            // 
            // dateEdit1
            // 
            this.dateEdit1.EditValue = new System.DateTime(2011, 10, 24, 0, 0, 0, 0);
            this.dateEdit1.Enabled = false;
            this.dateEdit1.Location = new System.Drawing.Point(192, 48);
            this.dateEdit1.Name = "dateEdit1";
            this.dateEdit1.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.dateEdit1.Properties.EditFormat.FormatString = "yyyy-MM";
            this.dateEdit1.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.dateEdit1.Size = new System.Drawing.Size(91, 21);
            this.dateEdit1.TabIndex = 80;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(83, 51);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(103, 14);
            this.label7.TabIndex = 79;
            this.label7.Text = "单据日期（年月）";
            // 
            // radioUnAudit
            // 
            this.radioUnAudit.AutoSize = true;
            this.radioUnAudit.Checked = true;
            this.radioUnAudit.Location = new System.Drawing.Point(544, 51);
            this.radioUnAudit.Name = "radioUnAudit";
            this.radioUnAudit.Size = new System.Drawing.Size(61, 18);
            this.radioUnAudit.TabIndex = 89;
            this.radioUnAudit.TabStop = true;
            this.radioUnAudit.Text = "未收料";
            this.radioUnAudit.UseVisualStyleBackColor = true;
            this.radioUnAudit.CheckedChanged += new System.EventHandler(this.radioUnAudit_CheckedChanged);
            // 
            // radioAudit
            // 
            this.radioAudit.AutoSize = true;
            this.radioAudit.Location = new System.Drawing.Point(629, 51);
            this.radioAudit.Name = "radioAudit";
            this.radioAudit.Size = new System.Drawing.Size(61, 18);
            this.radioAudit.TabIndex = 88;
            this.radioAudit.Text = "已收料";
            this.radioAudit.UseVisualStyleBackColor = true;
            this.radioAudit.CheckedChanged += new System.EventHandler(this.radioAudit_CheckedChanged);
            // 
            // chkAll
            // 
            this.chkAll.AutoSize = true;
            this.chkAll.Location = new System.Drawing.Point(12, 51);
            this.chkAll.Name = "chkAll";
            this.chkAll.Size = new System.Drawing.Size(50, 18);
            this.chkAll.TabIndex = 90;
            this.chkAll.Text = "全选";
            this.chkAll.UseVisualStyleBackColor = true;
            this.chkAll.CheckedChanged += new System.EventHandler(this.chkAll_CheckedChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(337, 52);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(55, 14);
            this.label1.TabIndex = 92;
            this.label1.Text = "收料班组";
            // 
            // lookUpEdit收料班组
            // 
            this.lookUpEdit收料班组.Location = new System.Drawing.Point(398, 48);
            this.lookUpEdit收料班组.Name = "lookUpEdit收料班组";
            this.lookUpEdit收料班组.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.lookUpEdit收料班组.Properties.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("cDepCode", "编号", 20, DevExpress.Utils.FormatType.None, "", true, DevExpress.Utils.HorzAlignment.Default, DevExpress.Data.ColumnSortOrder.None),
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("cDepName", "名称", 20, DevExpress.Utils.FormatType.None, "", true, DevExpress.Utils.HorzAlignment.Default, DevExpress.Data.ColumnSortOrder.None)});
            this.lookUpEdit收料班组.Properties.DisplayMember = "cDepName";
            this.lookUpEdit收料班组.Properties.NullText = "";
            this.lookUpEdit收料班组.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.Standard;
            this.lookUpEdit收料班组.Properties.ValueMember = "cDepCode";
            this.lookUpEdit收料班组.Size = new System.Drawing.Size(111, 21);
            this.lookUpEdit收料班组.TabIndex = 93;
            // 
            // gridCol调拨单表体ID
            // 
            this.gridCol调拨单表体ID.Caption = "调拨单表体ID";
            this.gridCol调拨单表体ID.FieldName = "autoID";
            this.gridCol调拨单表体ID.Name = "gridCol调拨单表体ID";
            this.gridCol调拨单表体ID.OptionsColumn.AllowEdit = false;
            this.gridCol调拨单表体ID.Visible = true;
            this.gridCol调拨单表体ID.VisibleIndex = 25;
            // 
            // FrmTrans生产收料
            // 
            this.Appearance.BackColor = System.Drawing.SystemColors.Control;
            this.Appearance.Options.UseBackColor = true;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(930, 459);
            this.Controls.Add(this.lookUpEdit收料班组);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.chkAll);
            this.Controls.Add(this.radioUnAudit);
            this.Controls.Add(this.radioAudit);
            this.Controls.Add(this.dateEdit1);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.gridControl1);
            this.Name = "FrmTrans生产收料";
            this.Text = "FrmTrans生产收料";
            this.Load += new System.EventHandler(this.FrmTransVouchAudit_Load);
            this.Controls.SetChildIndex(this.gridControl1, 0);
            this.Controls.SetChildIndex(this.label7, 0);
            this.Controls.SetChildIndex(this.dateEdit1, 0);
            this.Controls.SetChildIndex(this.radioAudit, 0);
            this.Controls.SetChildIndex(this.radioUnAudit, 0);
            this.Controls.SetChildIndex(this.chkAll, 0);
            this.Controls.SetChildIndex(this.label1, 0);
            this.Controls.SetChildIndex(this.lookUpEdit收料班组, 0);
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ItemLookUpEditWH)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ItemLookUpEditDep)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ItemLookUpEditRd_Style)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dateEdit1.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lookUpEdit收料班组.Properties)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraGrid.GridControl gridControl1;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView1;
        private DevExpress.XtraEditors.DateEdit dateEdit1;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.RadioButton radioUnAudit;
        private System.Windows.Forms.RadioButton radioAudit;
        private DevExpress.XtraGrid.Columns.GridColumn gridColbChoose;
        private DevExpress.XtraGrid.Columns.GridColumn gridColcsource;
        private DevExpress.XtraGrid.Columns.GridColumn gridColitransflag;
        private DevExpress.XtraGrid.Columns.GridColumn gridColcTVCode;
        private DevExpress.XtraGrid.Columns.GridColumn gridColdTVDate;
        private DevExpress.XtraGrid.Columns.GridColumn gridColcOWhCode;
        private DevExpress.XtraGrid.Columns.GridColumn gridColcIWhCode;
        private DevExpress.XtraGrid.Columns.GridColumn gridColcODepCode;
        private DevExpress.XtraGrid.Columns.GridColumn gridColcIDepCode;
        private DevExpress.XtraGrid.Columns.GridColumn gridColcIRdCode;
        private DevExpress.XtraGrid.Columns.GridColumn gridColcORdCode;
        private DevExpress.XtraGrid.Columns.GridColumn gridColcTVMemo;
        private DevExpress.XtraGrid.Columns.GridColumn gridColcMaker;
        private DevExpress.XtraGrid.Columns.GridColumn gridColcVerifyPerson;
        private DevExpress.XtraGrid.Columns.GridColumn gridColdVerifyDate;
        private DevExpress.XtraGrid.Columns.GridColumn gridColcPSPCode;
        private DevExpress.XtraGrid.Columns.GridColumn gridColcMPoCode;
        private DevExpress.XtraGrid.Columns.GridColumn gridColiQuantity;
        private DevExpress.XtraGrid.Columns.GridColumn gridColiproorderid;
        private DevExpress.XtraGrid.Columns.GridColumn gridColcOrderType;
        private DevExpress.XtraGrid.Columns.GridColumn gridColcTranRequestCode;
        private DevExpress.XtraGrid.Columns.GridColumn gridColcVersion;
        private DevExpress.XtraGrid.Columns.GridColumn gridColBomId;
        private DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit ItemLookUpEditDep;
        private DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit ItemLookUpEditWH;
        private DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit ItemLookUpEditRd_Style;
        private System.Windows.Forms.CheckBox chkAll;
        private DevExpress.XtraGrid.Columns.GridColumn gridColcInvCode;
        private DevExpress.XtraGrid.Columns.GridColumn gridColcInvName;
        private DevExpress.XtraGrid.Columns.GridColumn gridColcInvStd;
        private DevExpress.XtraGrid.Columns.GridColumn gridColiTVQuantity;
        private DevExpress.XtraGrid.Columns.GridColumn gridColiTVNum;
        private DevExpress.XtraGrid.Columns.GridColumn gridColcmocode;
        private DevExpress.XtraGrid.Columns.GridColumn gridColimoseq;
        private DevExpress.XtraGrid.Columns.GridColumn gridColcomcode;
        private DevExpress.XtraGrid.Columns.GridColumn gridColinvcode;
        private System.Windows.Forms.Label label1;
        private DevExpress.XtraEditors.LookUpEdit lookUpEdit收料班组;
        private DevExpress.XtraGrid.Columns.GridColumn gridCol调拨单表体ID;
    }
}