namespace Base
{
    partial class FrmQMREJECT
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
            this.gridColbChoose = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColCREJECTCODE = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColDCHECKDATE = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColSOURCECODE = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColCINVCODE = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColcInvName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColcInvStd = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColFQUANTITY = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColFNUM = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColCSCRAPDISNAME = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColCCHECKPERSON = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColSOURCEAUTOID = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColiPOsID = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColcWhCode = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColcVenName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColcComUnitName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColcComUnitName2 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColcbustype = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColCPOCODE = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColcDefine13 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColCVERIFIER = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColDVERIFYDATE = new DevExpress.XtraGrid.Columns.GridColumn();
            this.txtVenName = new DevExpress.XtraEditors.TextEdit();
            this.txtVenCode = new DevExpress.XtraEditors.ButtonEdit();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.lookUpEditQM = new DevExpress.XtraEditors.LookUpEdit();
            this.lookUpEdit1 = new DevExpress.XtraEditors.LookUpEdit();
            this.label3 = new System.Windows.Forms.Label();
            this.lookUpEdit2 = new DevExpress.XtraEditors.LookUpEdit();
            this.label4 = new System.Windows.Forms.Label();
            this.chkAll = new System.Windows.Forms.CheckBox();
            this.radioUnAudit = new System.Windows.Forms.RadioButton();
            this.radioAudit = new System.Windows.Forms.RadioButton();
            this.gridColcItemCode = new DevExpress.XtraGrid.Columns.GridColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dsPrint)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dsForm)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtSel)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtVenName.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtVenCode.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lookUpEditQM.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lookUpEdit1.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lookUpEdit2.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // gridControl1
            // 
            this.gridControl1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.gridControl1.EmbeddedNavigator.Margin = new System.Windows.Forms.Padding(4);
            this.gridControl1.Location = new System.Drawing.Point(0, 207);
            this.gridControl1.MainView = this.gridView1;
            this.gridControl1.Margin = new System.Windows.Forms.Padding(4);
            this.gridControl1.Name = "gridControl1";
            this.gridControl1.Size = new System.Drawing.Size(1056, 422);
            this.gridControl1.TabIndex = 10;
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
            this.gridColbChoose,
            this.gridColCREJECTCODE,
            this.gridColDCHECKDATE,
            this.gridColSOURCECODE,
            this.gridColCINVCODE,
            this.gridColcInvName,
            this.gridColcInvStd,
            this.gridColFQUANTITY,
            this.gridColFNUM,
            this.gridColCSCRAPDISNAME,
            this.gridColCCHECKPERSON,
            this.gridColSOURCEAUTOID,
            this.gridColiPOsID,
            this.gridColcWhCode,
            this.gridColcVenName,
            this.gridColcComUnitName,
            this.gridColcComUnitName2,
            this.gridColcbustype,
            this.gridColCPOCODE,
            this.gridColcDefine13,
            this.gridColCVERIFIER,
            this.gridColDVERIFYDATE,
            this.gridColcItemCode});
            this.gridView1.GridControl = this.gridControl1;
            this.gridView1.IndicatorWidth = 40;
            this.gridView1.Name = "gridView1";
            this.gridView1.OptionsView.ColumnAutoWidth = false;
            this.gridView1.OptionsView.EnableAppearanceEvenRow = true;
            this.gridView1.OptionsView.EnableAppearanceOddRow = true;
            this.gridView1.OptionsView.ShowGroupPanel = false;
            this.gridView1.CustomDrawRowIndicator += new DevExpress.XtraGrid.Views.Grid.RowIndicatorCustomDrawEventHandler(this.gridView1_CustomDrawRowIndicator);
            this.gridView1.RowCellStyle += new DevExpress.XtraGrid.Views.Grid.RowCellStyleEventHandler(this.gridView1_RowCellStyle);
            this.gridView1.DoubleClick += new System.EventHandler(this.gridView1_DoubleClick);
            // 
            // gridColbChoose
            // 
            this.gridColbChoose.FieldName = "bChoose";
            this.gridColbChoose.Name = "gridColbChoose";
            this.gridColbChoose.OptionsColumn.AllowEdit = false;
            this.gridColbChoose.Visible = true;
            this.gridColbChoose.VisibleIndex = 0;
            this.gridColbChoose.Width = 20;
            // 
            // gridColCREJECTCODE
            // 
            this.gridColCREJECTCODE.Caption = "单据号";
            this.gridColCREJECTCODE.FieldName = "CREJECTCODE";
            this.gridColCREJECTCODE.Name = "gridColCREJECTCODE";
            this.gridColCREJECTCODE.OptionsColumn.AllowEdit = false;
            this.gridColCREJECTCODE.Visible = true;
            this.gridColCREJECTCODE.VisibleIndex = 3;
            this.gridColCREJECTCODE.Width = 64;
            // 
            // gridColDCHECKDATE
            // 
            this.gridColDCHECKDATE.Caption = "日期";
            this.gridColDCHECKDATE.FieldName = "DCHECKDATE";
            this.gridColDCHECKDATE.Name = "gridColDCHECKDATE";
            this.gridColDCHECKDATE.OptionsColumn.AllowEdit = false;
            this.gridColDCHECKDATE.Visible = true;
            this.gridColDCHECKDATE.VisibleIndex = 4;
            this.gridColDCHECKDATE.Width = 60;
            // 
            // gridColSOURCECODE
            // 
            this.gridColSOURCECODE.Caption = "到货单号";
            this.gridColSOURCECODE.FieldName = "SOURCECODE";
            this.gridColSOURCECODE.Name = "gridColSOURCECODE";
            this.gridColSOURCECODE.OptionsColumn.AllowEdit = false;
            this.gridColSOURCECODE.Visible = true;
            this.gridColSOURCECODE.VisibleIndex = 6;
            this.gridColSOURCECODE.Width = 59;
            // 
            // gridColCINVCODE
            // 
            this.gridColCINVCODE.Caption = "存货编码";
            this.gridColCINVCODE.FieldName = "CINVCODE";
            this.gridColCINVCODE.Name = "gridColCINVCODE";
            this.gridColCINVCODE.OptionsColumn.AllowEdit = false;
            this.gridColCINVCODE.Visible = true;
            this.gridColCINVCODE.VisibleIndex = 7;
            this.gridColCINVCODE.Width = 84;
            // 
            // gridColcInvName
            // 
            this.gridColcInvName.Caption = "存货名称";
            this.gridColcInvName.FieldName = "cInvName";
            this.gridColcInvName.Name = "gridColcInvName";
            this.gridColcInvName.OptionsColumn.AllowEdit = false;
            this.gridColcInvName.Visible = true;
            this.gridColcInvName.VisibleIndex = 8;
            this.gridColcInvName.Width = 108;
            // 
            // gridColcInvStd
            // 
            this.gridColcInvStd.Caption = "规格型号";
            this.gridColcInvStd.FieldName = "cInvStd";
            this.gridColcInvStd.Name = "gridColcInvStd";
            this.gridColcInvStd.OptionsColumn.AllowEdit = false;
            this.gridColcInvStd.Visible = true;
            this.gridColcInvStd.VisibleIndex = 9;
            this.gridColcInvStd.Width = 91;
            // 
            // gridColFQUANTITY
            // 
            this.gridColFQUANTITY.Caption = "不良品数量";
            this.gridColFQUANTITY.FieldName = "FQUANTITY";
            this.gridColFQUANTITY.Name = "gridColFQUANTITY";
            this.gridColFQUANTITY.OptionsColumn.AllowEdit = false;
            this.gridColFQUANTITY.OptionsFilter.AllowFilter = false;
            this.gridColFQUANTITY.Visible = true;
            this.gridColFQUANTITY.VisibleIndex = 10;
            this.gridColFQUANTITY.Width = 80;
            // 
            // gridColFNUM
            // 
            this.gridColFNUM.Caption = "不良品件数";
            this.gridColFNUM.FieldName = "FNUM";
            this.gridColFNUM.Name = "gridColFNUM";
            this.gridColFNUM.OptionsColumn.AllowEdit = false;
            this.gridColFNUM.OptionsFilter.AllowFilter = false;
            this.gridColFNUM.Visible = true;
            this.gridColFNUM.VisibleIndex = 11;
            this.gridColFNUM.Width = 70;
            // 
            // gridColCSCRAPDISNAME
            // 
            this.gridColCSCRAPDISNAME.Caption = "处理方式";
            this.gridColCSCRAPDISNAME.FieldName = "CSCRAPDISNAME";
            this.gridColCSCRAPDISNAME.Name = "gridColCSCRAPDISNAME";
            this.gridColCSCRAPDISNAME.OptionsColumn.AllowEdit = false;
            this.gridColCSCRAPDISNAME.Visible = true;
            this.gridColCSCRAPDISNAME.VisibleIndex = 13;
            this.gridColCSCRAPDISNAME.Width = 77;
            // 
            // gridColCCHECKPERSON
            // 
            this.gridColCCHECKPERSON.Caption = "检验员";
            this.gridColCCHECKPERSON.FieldName = "CMAKER";
            this.gridColCCHECKPERSON.Name = "gridColCCHECKPERSON";
            this.gridColCCHECKPERSON.OptionsColumn.AllowEdit = false;
            this.gridColCCHECKPERSON.Visible = true;
            this.gridColCCHECKPERSON.VisibleIndex = 14;
            this.gridColCCHECKPERSON.Width = 103;
            // 
            // gridColSOURCEAUTOID
            // 
            this.gridColSOURCEAUTOID.Caption = "到货单子表ID";
            this.gridColSOURCEAUTOID.FieldName = "SOURCEAUTOID";
            this.gridColSOURCEAUTOID.Name = "gridColSOURCEAUTOID";
            this.gridColSOURCEAUTOID.OptionsColumn.AllowEdit = false;
            this.gridColSOURCEAUTOID.Width = 87;
            // 
            // gridColiPOsID
            // 
            this.gridColiPOsID.Caption = "采购订单子表ID";
            this.gridColiPOsID.FieldName = "iPOsID";
            this.gridColiPOsID.Name = "gridColiPOsID";
            this.gridColiPOsID.OptionsColumn.AllowEdit = false;
            this.gridColiPOsID.Width = 116;
            // 
            // gridColcWhCode
            // 
            this.gridColcWhCode.Caption = "到货单仓库编码";
            this.gridColcWhCode.FieldName = "cWhCode";
            this.gridColcWhCode.Name = "gridColcWhCode";
            this.gridColcWhCode.OptionsColumn.AllowEdit = false;
            this.gridColcWhCode.Visible = true;
            this.gridColcWhCode.VisibleIndex = 17;
            this.gridColcWhCode.Width = 107;
            // 
            // gridColcVenName
            // 
            this.gridColcVenName.Caption = "供应商";
            this.gridColcVenName.FieldName = "cVenName";
            this.gridColcVenName.Name = "gridColcVenName";
            this.gridColcVenName.OptionsColumn.AllowEdit = false;
            this.gridColcVenName.Visible = true;
            this.gridColcVenName.VisibleIndex = 1;
            this.gridColcVenName.Width = 112;
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
            // gridColcComUnitName2
            // 
            this.gridColcComUnitName2.Caption = "副计量";
            this.gridColcComUnitName2.FieldName = "cComUnitName2";
            this.gridColcComUnitName2.Name = "gridColcComUnitName2";
            this.gridColcComUnitName2.OptionsColumn.AllowEdit = false;
            this.gridColcComUnitName2.Visible = true;
            this.gridColcComUnitName2.VisibleIndex = 16;
            // 
            // gridColcbustype
            // 
            this.gridColcbustype.Caption = "到货类型";
            this.gridColcbustype.FieldName = "cbustype";
            this.gridColcbustype.Name = "gridColcbustype";
            this.gridColcbustype.OptionsColumn.AllowEdit = false;
            this.gridColcbustype.Visible = true;
            this.gridColcbustype.VisibleIndex = 18;
            // 
            // gridColCPOCODE
            // 
            this.gridColCPOCODE.Caption = "订单号";
            this.gridColCPOCODE.FieldName = "CPOCODE";
            this.gridColCPOCODE.Name = "gridColCPOCODE";
            this.gridColCPOCODE.OptionsColumn.AllowEdit = false;
            this.gridColCPOCODE.Visible = true;
            this.gridColCPOCODE.VisibleIndex = 5;
            // 
            // gridColcDefine13
            // 
            this.gridColcDefine13.Caption = "不良扣款";
            this.gridColcDefine13.FieldName = "cDefine13";
            this.gridColcDefine13.Name = "gridColcDefine13";
            this.gridColcDefine13.OptionsColumn.AllowEdit = false;
            this.gridColcDefine13.Visible = true;
            this.gridColcDefine13.VisibleIndex = 12;
            this.gridColcDefine13.Width = 117;
            // 
            // gridColCVERIFIER
            // 
            this.gridColCVERIFIER.Caption = "审核人";
            this.gridColCVERIFIER.FieldName = "CVERIFIER";
            this.gridColCVERIFIER.Name = "gridColCVERIFIER";
            this.gridColCVERIFIER.OptionsColumn.AllowEdit = false;
            this.gridColCVERIFIER.Visible = true;
            this.gridColCVERIFIER.VisibleIndex = 19;
            // 
            // gridColDVERIFYDATE
            // 
            this.gridColDVERIFYDATE.Caption = "审核日期";
            this.gridColDVERIFYDATE.FieldName = "DVERIFYDATE";
            this.gridColDVERIFYDATE.Name = "gridColDVERIFYDATE";
            this.gridColDVERIFYDATE.OptionsColumn.AllowEdit = false;
            this.gridColDVERIFYDATE.Visible = true;
            this.gridColDVERIFYDATE.VisibleIndex = 20;
            // 
            // txtVenName
            // 
            this.txtVenName.Enabled = false;
            this.txtVenName.Location = new System.Drawing.Point(256, 70);
            this.txtVenName.Margin = new System.Windows.Forms.Padding(4);
            this.txtVenName.Name = "txtVenName";
            this.txtVenName.Properties.ReadOnly = true;
            this.txtVenName.Size = new System.Drawing.Size(460, 24);
            this.txtVenName.TabIndex = 61;
            // 
            // txtVenCode
            // 
            this.txtVenCode.EnterMoveNextControl = true;
            this.txtVenCode.Location = new System.Drawing.Point(115, 70);
            this.txtVenCode.Margin = new System.Windows.Forms.Padding(4);
            this.txtVenCode.Name = "txtVenCode";
            this.txtVenCode.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
            this.txtVenCode.Size = new System.Drawing.Size(133, 24);
            this.txtVenCode.TabIndex = 60;
            this.txtVenCode.ButtonClick += new DevExpress.XtraEditors.Controls.ButtonPressedEventHandler(this.txtVenCode_ButtonClick);
            this.txtVenCode.Leave += new System.EventHandler(this.txtVenCode_Leave);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(19, 75);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(53, 18);
            this.label1.TabIndex = 59;
            this.label1.Text = "供应商";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(19, 116);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(68, 18);
            this.label2.TabIndex = 62;
            this.label2.Text = "处理方式";
            // 
            // lookUpEditQM
            // 
            this.lookUpEditQM.Location = new System.Drawing.Point(115, 111);
            this.lookUpEditQM.Margin = new System.Windows.Forms.Padding(4);
            this.lookUpEditQM.Name = "lookUpEditQM";
            this.lookUpEditQM.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.lookUpEditQM.Properties.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("iID", "处理方式编码 "),
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("iText", 80, "处理方式名称 ")});
            this.lookUpEditQM.Properties.DisplayMember = "iText";
            this.lookUpEditQM.Properties.NullText = "";
            this.lookUpEditQM.Properties.PopupWidth = 350;
            this.lookUpEditQM.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.Standard;
            this.lookUpEditQM.Properties.ValueMember = "iID";
            this.lookUpEditQM.Size = new System.Drawing.Size(133, 24);
            this.lookUpEditQM.TabIndex = 65;
            this.lookUpEditQM.EditValueChanged += new System.EventHandler(this.lookUpEditQM_EditValueChanged);
            // 
            // lookUpEdit1
            // 
            this.lookUpEdit1.Location = new System.Drawing.Point(403, 111);
            this.lookUpEdit1.Margin = new System.Windows.Forms.Padding(4);
            this.lookUpEdit1.Name = "lookUpEdit1";
            this.lookUpEdit1.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.lookUpEdit1.Properties.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("iID", "单据号")});
            this.lookUpEdit1.Properties.DisplayMember = "iID";
            this.lookUpEdit1.Properties.NullText = "";
            this.lookUpEdit1.Properties.PopupWidth = 350;
            this.lookUpEdit1.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.Standard;
            this.lookUpEdit1.Properties.ValueMember = "iID";
            this.lookUpEdit1.Size = new System.Drawing.Size(133, 24);
            this.lookUpEdit1.TabIndex = 67;
            this.lookUpEdit1.EditValueChanged += new System.EventHandler(this.lookUpEdit1_EditValueChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(337, 116);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(53, 18);
            this.label3.TabIndex = 66;
            this.label3.Text = "单据号";
            // 
            // lookUpEdit2
            // 
            this.lookUpEdit2.Location = new System.Drawing.Point(583, 111);
            this.lookUpEdit2.Margin = new System.Windows.Forms.Padding(4);
            this.lookUpEdit2.Name = "lookUpEdit2";
            this.lookUpEdit2.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.lookUpEdit2.Properties.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("iID", "单据号")});
            this.lookUpEdit2.Properties.DisplayMember = "iID";
            this.lookUpEdit2.Properties.NullText = "";
            this.lookUpEdit2.Properties.PopupWidth = 350;
            this.lookUpEdit2.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.Standard;
            this.lookUpEdit2.Properties.ValueMember = "iID";
            this.lookUpEdit2.Size = new System.Drawing.Size(133, 24);
            this.lookUpEdit2.TabIndex = 0;
            this.lookUpEdit2.EditValueChanged += new System.EventHandler(this.lookUpEdit2_EditValueChanged);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(544, 116);
            this.label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(28, 18);
            this.label4.TabIndex = 68;
            this.label4.Text = "----";
            // 
            // chkAll
            // 
            this.chkAll.AutoSize = true;
            this.chkAll.Location = new System.Drawing.Point(23, 171);
            this.chkAll.Margin = new System.Windows.Forms.Padding(4);
            this.chkAll.Name = "chkAll";
            this.chkAll.Size = new System.Drawing.Size(60, 22);
            this.chkAll.TabIndex = 72;
            this.chkAll.Text = "全选";
            this.chkAll.UseVisualStyleBackColor = true;
            this.chkAll.CheckedChanged += new System.EventHandler(this.chkAll_CheckedChanged);
            // 
            // radioUnAudit
            // 
            this.radioUnAudit.AutoSize = true;
            this.radioUnAudit.Checked = true;
            this.radioUnAudit.Location = new System.Drawing.Point(115, 171);
            this.radioUnAudit.Margin = new System.Windows.Forms.Padding(4);
            this.radioUnAudit.Name = "radioUnAudit";
            this.radioUnAudit.Size = new System.Drawing.Size(74, 22);
            this.radioUnAudit.TabIndex = 71;
            this.radioUnAudit.TabStop = true;
            this.radioUnAudit.Text = "未审核";
            this.radioUnAudit.UseVisualStyleBackColor = true;
            this.radioUnAudit.CheckedChanged += new System.EventHandler(this.radioUnAudit_CheckedChanged);
            // 
            // radioAudit
            // 
            this.radioAudit.AutoSize = true;
            this.radioAudit.Location = new System.Drawing.Point(237, 170);
            this.radioAudit.Margin = new System.Windows.Forms.Padding(4);
            this.radioAudit.Name = "radioAudit";
            this.radioAudit.Size = new System.Drawing.Size(74, 22);
            this.radioAudit.TabIndex = 70;
            this.radioAudit.Text = "已审核";
            this.radioAudit.UseVisualStyleBackColor = true;
            this.radioAudit.CheckedChanged += new System.EventHandler(this.radioAudit_CheckedChanged);
            // 
            // gridColcItemCode
            // 
            this.gridColcItemCode.Caption = "外销订单号";
            this.gridColcItemCode.FieldName = "cItemCode";
            this.gridColcItemCode.Name = "gridColcItemCode";
            this.gridColcItemCode.OptionsColumn.AllowEdit = false;
            this.gridColcItemCode.Visible = true;
            this.gridColcItemCode.VisibleIndex = 2;
            this.gridColcItemCode.Width = 99;
            // 
            // FrmQMREJECT
            // 
            this.Appearance.BackColor = System.Drawing.SystemColors.Control;
            this.Appearance.Options.UseBackColor = true;
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 18F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1056, 632);
            this.Controls.Add(this.chkAll);
            this.Controls.Add(this.radioUnAudit);
            this.Controls.Add(this.radioAudit);
            this.Controls.Add(this.lookUpEdit2);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.lookUpEdit1);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.lookUpEditQM);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtVenName);
            this.Controls.Add(this.txtVenCode);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.gridControl1);
            this.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.Name = "FrmQMREJECT";
            this.Text = "FrmQMREJECT";
            this.Load += new System.EventHandler(this.FrmQMREJECT_Load);
            this.Controls.SetChildIndex(this.gridControl1, 0);
            this.Controls.SetChildIndex(this.label1, 0);
            this.Controls.SetChildIndex(this.txtVenCode, 0);
            this.Controls.SetChildIndex(this.txtVenName, 0);
            this.Controls.SetChildIndex(this.label2, 0);
            this.Controls.SetChildIndex(this.lookUpEditQM, 0);
            this.Controls.SetChildIndex(this.label3, 0);
            this.Controls.SetChildIndex(this.lookUpEdit1, 0);
            this.Controls.SetChildIndex(this.label4, 0);
            this.Controls.SetChildIndex(this.lookUpEdit2, 0);
            this.Controls.SetChildIndex(this.radioAudit, 0);
            this.Controls.SetChildIndex(this.radioUnAudit, 0);
            this.Controls.SetChildIndex(this.chkAll, 0);
            ((System.ComponentModel.ISupportInitialize)(this.dsPrint)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dsForm)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtSel)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtVenName.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtVenCode.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lookUpEditQM.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lookUpEdit1.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lookUpEdit2.Properties)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraGrid.GridControl gridControl1;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView1;
        private DevExpress.XtraEditors.TextEdit txtVenName;
        private DevExpress.XtraEditors.ButtonEdit txtVenCode;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private DevExpress.XtraGrid.Columns.GridColumn gridColCREJECTCODE;
        private DevExpress.XtraGrid.Columns.GridColumn gridColDCHECKDATE;
        private DevExpress.XtraGrid.Columns.GridColumn gridColSOURCECODE;
        private DevExpress.XtraGrid.Columns.GridColumn gridColCINVCODE;
        private DevExpress.XtraGrid.Columns.GridColumn gridColcInvName;
        private DevExpress.XtraGrid.Columns.GridColumn gridColFQUANTITY;
        private DevExpress.XtraGrid.Columns.GridColumn gridColCSCRAPDISNAME;
        private DevExpress.XtraGrid.Columns.GridColumn gridColCCHECKPERSON;
        private DevExpress.XtraEditors.LookUpEdit lookUpEditQM;
        private DevExpress.XtraEditors.LookUpEdit lookUpEdit1;
        private System.Windows.Forms.Label label3;
        private DevExpress.XtraEditors.LookUpEdit lookUpEdit2;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.CheckBox chkAll;
        private System.Windows.Forms.RadioButton radioUnAudit;
        private System.Windows.Forms.RadioButton radioAudit;
        private DevExpress.XtraGrid.Columns.GridColumn gridColcInvStd;
        private DevExpress.XtraGrid.Columns.GridColumn gridColbChoose;
        private DevExpress.XtraGrid.Columns.GridColumn gridColFNUM;
        private DevExpress.XtraGrid.Columns.GridColumn gridColSOURCEAUTOID;
        private DevExpress.XtraGrid.Columns.GridColumn gridColiPOsID;
        private DevExpress.XtraGrid.Columns.GridColumn gridColcWhCode;
        private DevExpress.XtraGrid.Columns.GridColumn gridColcVenName;
        private DevExpress.XtraGrid.Columns.GridColumn gridColcComUnitName;
        private DevExpress.XtraGrid.Columns.GridColumn gridColcComUnitName2;
        private DevExpress.XtraGrid.Columns.GridColumn gridColcbustype;
        private DevExpress.XtraGrid.Columns.GridColumn gridColCPOCODE;
        private DevExpress.XtraGrid.Columns.GridColumn gridColcDefine13;
        private DevExpress.XtraGrid.Columns.GridColumn gridColCVERIFIER;
        private DevExpress.XtraGrid.Columns.GridColumn gridColDVERIFYDATE;
        private DevExpress.XtraGrid.Columns.GridColumn gridColcItemCode;
    }
}