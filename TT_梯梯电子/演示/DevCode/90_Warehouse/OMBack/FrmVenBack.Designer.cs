namespace Warehouse
{
    partial class FrmVenBack
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
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.chk含AK订单 = new System.Windows.Forms.CheckBox();
            this.txtVenName = new DevExpress.XtraEditors.TextEdit();
            this.txtVenCode = new DevExpress.XtraEditors.ButtonEdit();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.grdDetail = new DevExpress.XtraGrid.GridControl();
            this.grvDetail = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colOMDId = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colMoCode = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn9 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn8 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn10 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn6 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColcInvCode = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColcInvName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColcInvStd = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colRemainQty = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colRemainNum = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn1 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colCRate = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colSendQty = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colHaveUsedQty = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colSendNum = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn11 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn2 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn3 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn4 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colArriveDate = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colBackQty = new DevExpress.XtraGrid.Columns.GridColumn();
            this.rpiBackQty = new DevExpress.XtraEditors.Repository.RepositoryItemTextEdit();
            this.colBackNum = new DevExpress.XtraGrid.Columns.GridColumn();
            this.rpiBackNum = new DevExpress.XtraEditors.Repository.RepositoryItemTextEdit();
            this.colBackUnitQty = new DevExpress.XtraGrid.Columns.GridColumn();
            this.rpiBackUnitQty = new DevExpress.XtraEditors.Repository.RepositoryItemTextEdit();
            this.colBOMQty = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colMOMaterialsID = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColUnitQty = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColcItemCode = new DevExpress.XtraGrid.Columns.GridColumn();
            this.LookUpWH = new DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit();
            //((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dsPrint)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dsForm)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtSel)).BeginInit();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtVenName.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtVenCode.Properties)).BeginInit();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdDetail)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grvDetail)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.rpiBackQty)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.rpiBackNum)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.rpiBackUnitQty)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.LookUpWH)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox1.Controls.Add(this.chk含AK订单);
            this.groupBox1.Controls.Add(this.txtVenName);
            this.groupBox1.Controls.Add(this.txtVenCode);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Location = new System.Drawing.Point(0, 28);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(995, 71);
            this.groupBox1.TabIndex = 5;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "过滤条件";
            // 
            // chk含AK订单
            // 
            this.chk含AK订单.AutoSize = true;
            this.chk含AK订单.Location = new System.Drawing.Point(658, 29);
            this.chk含AK订单.Name = "chk含AK订单";
            this.chk含AK订单.Size = new System.Drawing.Size(77, 18);
            this.chk含AK订单.TabIndex = 62;
            this.chk含AK订单.Text = "含AK订单";
            this.chk含AK订单.UseVisualStyleBackColor = true;
            // 
            // txtVenName
            // 
            this.txtVenName.Enabled = false;
            this.txtVenName.Location = new System.Drawing.Point(219, 24);
            this.txtVenName.Name = "txtVenName";
            this.txtVenName.Properties.ReadOnly = true;
            this.txtVenName.Size = new System.Drawing.Size(402, 20);
            this.txtVenName.TabIndex = 61;
            // 
            // txtVenCode
            // 
            this.txtVenCode.EnterMoveNextControl = true;
            this.txtVenCode.Location = new System.Drawing.Point(96, 24);
            this.txtVenCode.Name = "txtVenCode";
            this.txtVenCode.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
            this.txtVenCode.Size = new System.Drawing.Size(117, 20);
            this.txtVenCode.TabIndex = 60;
            this.txtVenCode.ButtonClick += new DevExpress.XtraEditors.Controls.ButtonPressedEventHandler(this.txtVenCode_ButtonClick);
            this.txtVenCode.Leave += new System.EventHandler(this.txtVenCode_Leave);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 28);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(67, 14);
            this.label1.TabIndex = 59;
            this.label1.Text = "委外供应商";
            // 
            // groupBox2
            // 
            this.groupBox2.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox2.Controls.Add(this.grdDetail);
            this.groupBox2.Location = new System.Drawing.Point(0, 106);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(995, 430);
            this.groupBox2.TabIndex = 6;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "委外订单信息";
            // 
            // grdDetail
            // 
            this.grdDetail.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grdDetail.Location = new System.Drawing.Point(3, 18);
            this.grdDetail.MainView = this.grvDetail;
            this.grdDetail.Name = "grdDetail";
            this.grdDetail.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.LookUpWH,
            this.rpiBackQty,
            this.rpiBackUnitQty,
            this.rpiBackNum});
            this.grdDetail.Size = new System.Drawing.Size(989, 409);
            this.grdDetail.TabIndex = 13;
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
            this.colOMDId,
            this.colMoCode,
            this.gridColumn9,
            this.gridColumn8,
            this.gridColumn10,
            this.gridColumn6,
            this.gridColcInvCode,
            this.gridColcInvName,
            this.gridColcInvStd,
            this.colRemainQty,
            this.colRemainNum,
            this.gridColumn1,
            this.colCRate,
            this.colSendQty,
            this.colHaveUsedQty,
            this.colSendNum,
            this.gridColumn11,
            this.gridColumn2,
            this.gridColumn3,
            this.gridColumn4,
            this.colArriveDate,
            this.colBackQty,
            this.colBackNum,
            this.colBackUnitQty,
            this.colBOMQty,
            this.colMOMaterialsID,
            this.gridColUnitQty,
            this.gridColcItemCode});
            this.grvDetail.CustomizationFormBounds = new System.Drawing.Rectangle(1072, 422, 208, 175);
            this.grvDetail.GridControl = this.grdDetail;
            this.grvDetail.IndicatorWidth = 40;
            this.grvDetail.Name = "grvDetail";
            this.grvDetail.OptionsView.ColumnAutoWidth = false;
            this.grvDetail.OptionsView.EnableAppearanceEvenRow = true;
            this.grvDetail.OptionsView.EnableAppearanceOddRow = true;
            this.grvDetail.OptionsView.ShowFooter = true;
            this.grvDetail.OptionsView.ShowGroupPanel = false;
            this.grvDetail.CustomDrawRowIndicator += new DevExpress.XtraGrid.Views.Grid.RowIndicatorCustomDrawEventHandler(this.grvDetail_CustomDrawRowIndicator);
            this.grvDetail.RowCellStyle += new DevExpress.XtraGrid.Views.Grid.RowCellStyleEventHandler(this.grvDetail_RowCellStyle);
            // 
            // colOMDId
            // 
            this.colOMDId.Caption = "gridColumn6";
            this.colOMDId.FieldName = "MODetailsID";
            this.colOMDId.Name = "colOMDId";
            this.colOMDId.OptionsColumn.AllowEdit = false;
            this.colOMDId.OptionsFilter.AllowFilter = false;
            // 
            // colMoCode
            // 
            this.colMoCode.Caption = "委外加工单号";
            this.colMoCode.FieldName = "cCode";
            this.colMoCode.Name = "colMoCode";
            this.colMoCode.OptionsColumn.AllowEdit = false;
            this.colMoCode.Visible = true;
            this.colMoCode.VisibleIndex = 0;
            this.colMoCode.Width = 100;
            // 
            // gridColumn9
            // 
            this.gridColumn9.Caption = "供应商编码";
            this.gridColumn9.FieldName = "cVenCode";
            this.gridColumn9.Name = "gridColumn9";
            this.gridColumn9.OptionsColumn.AllowEdit = false;
            this.gridColumn9.Width = 69;
            // 
            // gridColumn8
            // 
            this.gridColumn8.Caption = "供应商名称";
            this.gridColumn8.FieldName = "cVenName";
            this.gridColumn8.Name = "gridColumn8";
            this.gridColumn8.OptionsColumn.AllowEdit = false;
            this.gridColumn8.Visible = true;
            this.gridColumn8.VisibleIndex = 1;
            this.gridColumn8.Width = 84;
            // 
            // gridColumn10
            // 
            this.gridColumn10.Caption = "产品编码";
            this.gridColumn10.FieldName = "PInvCode";
            this.gridColumn10.Name = "gridColumn10";
            this.gridColumn10.OptionsColumn.AllowEdit = false;
            this.gridColumn10.Visible = true;
            this.gridColumn10.VisibleIndex = 2;
            // 
            // gridColumn6
            // 
            this.gridColumn6.Caption = "产品名称";
            this.gridColumn6.FieldName = "PInvName";
            this.gridColumn6.Name = "gridColumn6";
            this.gridColumn6.OptionsColumn.AllowEdit = false;
            this.gridColumn6.Visible = true;
            this.gridColumn6.VisibleIndex = 3;
            this.gridColumn6.Width = 136;
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
            // colRemainQty
            // 
            this.colRemainQty.Caption = "剩余数量";
            this.colRemainQty.FieldName = "RemainQty";
            this.colRemainQty.Name = "colRemainQty";
            this.colRemainQty.OptionsColumn.AllowEdit = false;
            this.colRemainQty.OptionsFilter.AllowFilter = false;
            this.colRemainQty.Visible = true;
            this.colRemainQty.VisibleIndex = 9;
            // 
            // colRemainNum
            // 
            this.colRemainNum.Caption = "剩余件数";
            this.colRemainNum.FieldName = "RemainNum";
            this.colRemainNum.Name = "colRemainNum";
            this.colRemainNum.OptionsColumn.AllowEdit = false;
            this.colRemainNum.OptionsFilter.AllowFilter = false;
            this.colRemainNum.Visible = true;
            this.colRemainNum.VisibleIndex = 10;
            // 
            // gridColumn1
            // 
            this.gridColumn1.Caption = "应领数量";
            this.gridColumn1.FieldName = "iQuantity";
            this.gridColumn1.Name = "gridColumn1";
            this.gridColumn1.OptionsColumn.AllowEdit = false;
            this.gridColumn1.OptionsFilter.AllowFilter = false;
            this.gridColumn1.Summary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] {
            new DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum)});
            this.gridColumn1.Visible = true;
            this.gridColumn1.VisibleIndex = 13;
            this.gridColumn1.Width = 78;
            // 
            // colCRate
            // 
            this.colCRate.Caption = "换算率";
            this.colCRate.FieldName = "CRate";
            this.colCRate.Name = "colCRate";
            this.colCRate.OptionsColumn.AllowEdit = false;
            this.colCRate.OptionsFilter.AllowFilter = false;
            this.colCRate.Visible = true;
            this.colCRate.VisibleIndex = 17;
            // 
            // colSendQty
            // 
            this.colSendQty.Caption = "已领数量";
            this.colSendQty.FieldName = "iSendQty";
            this.colSendQty.Name = "colSendQty";
            this.colSendQty.OptionsColumn.AllowEdit = false;
            this.colSendQty.OptionsFilter.AllowFilter = false;
            this.colSendQty.Summary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] {
            new DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum)});
            this.colSendQty.Visible = true;
            this.colSendQty.VisibleIndex = 14;
            this.colSendQty.Width = 81;
            // 
            // colHaveUsedQty
            // 
            this.colHaveUsedQty.Caption = "累计使用数量";
            this.colHaveUsedQty.FieldName = "HaveUsedQty";
            this.colHaveUsedQty.Name = "colHaveUsedQty";
            this.colHaveUsedQty.OptionsColumn.AllowEdit = false;
            this.colHaveUsedQty.OptionsFilter.AllowFilter = false;
            this.colHaveUsedQty.Visible = true;
            this.colHaveUsedQty.VisibleIndex = 15;
            this.colHaveUsedQty.Width = 99;
            // 
            // colSendNum
            // 
            this.colSendNum.Caption = "已领件数";
            this.colSendNum.FieldName = "iSendNum";
            this.colSendNum.Name = "colSendNum";
            this.colSendNum.OptionsColumn.AllowEdit = false;
            this.colSendNum.OptionsFilter.AllowFilter = false;
            this.colSendNum.Summary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] {
            new DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum)});
            // 
            // gridColumn11
            // 
            this.gridColumn11.Caption = "已领套数";
            this.gridColumn11.FieldName = "iSendUnitQty";
            this.gridColumn11.Name = "gridColumn11";
            this.gridColumn11.OptionsColumn.AllowEdit = false;
            this.gridColumn11.OptionsFilter.AllowFilter = false;
            this.gridColumn11.Summary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] {
            new DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum)});
            this.gridColumn11.Visible = true;
            this.gridColumn11.VisibleIndex = 16;
            // 
            // gridColumn2
            // 
            this.gridColumn2.Caption = "原币含税单价";
            this.gridColumn2.FieldName = "iUnitPrice";
            this.gridColumn2.Name = "gridColumn2";
            this.gridColumn2.OptionsColumn.AllowEdit = false;
            this.gridColumn2.OptionsFilter.AllowFilter = false;
            this.gridColumn2.Width = 94;
            // 
            // gridColumn3
            // 
            this.gridColumn3.Caption = "原币金额";
            this.gridColumn3.FieldName = "iMoney";
            this.gridColumn3.Name = "gridColumn3";
            this.gridColumn3.OptionsColumn.AllowEdit = false;
            this.gridColumn3.OptionsFilter.AllowFilter = false;
            // 
            // gridColumn4
            // 
            this.gridColumn4.Caption = "计划下达日期";
            this.gridColumn4.FieldName = "dStartDate";
            this.gridColumn4.Name = "gridColumn4";
            this.gridColumn4.OptionsColumn.AllowEdit = false;
            this.gridColumn4.OptionsFilter.AllowFilter = false;
            this.gridColumn4.Visible = true;
            this.gridColumn4.VisibleIndex = 18;
            this.gridColumn4.Width = 92;
            // 
            // colArriveDate
            // 
            this.colArriveDate.Caption = "计划到货日期";
            this.colArriveDate.FieldName = "dArriveDate";
            this.colArriveDate.Name = "colArriveDate";
            this.colArriveDate.OptionsColumn.AllowEdit = false;
            this.colArriveDate.OptionsFilter.AllowFilter = false;
            this.colArriveDate.Visible = true;
            this.colArriveDate.VisibleIndex = 19;
            this.colArriveDate.Width = 100;
            // 
            // colBackQty
            // 
            this.colBackQty.AppearanceHeader.ForeColor = System.Drawing.Color.Blue;
            this.colBackQty.AppearanceHeader.Options.UseForeColor = true;
            this.colBackQty.Caption = "本次退货数量";
            this.colBackQty.ColumnEdit = this.rpiBackQty;
            this.colBackQty.FieldName = "BackQty";
            this.colBackQty.Name = "colBackQty";
            this.colBackQty.OptionsFilter.AllowFilter = false;
            this.colBackQty.Summary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] {
            new DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum)});
            this.colBackQty.Visible = true;
            this.colBackQty.VisibleIndex = 11;
            this.colBackQty.Width = 90;
            // 
            // rpiBackQty
            // 
            this.rpiBackQty.AutoHeight = false;
            this.rpiBackQty.Mask.EditMask = "n6";
            this.rpiBackQty.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Numeric;
            this.rpiBackQty.Name = "rpiBackQty";
            this.rpiBackQty.EditValueChanged += new System.EventHandler(this.rpiBackQty_EditValueChanged);
            // 
            // colBackNum
            // 
            this.colBackNum.Caption = "本次退货件数";
            this.colBackNum.ColumnEdit = this.rpiBackNum;
            this.colBackNum.FieldName = "BackNum";
            this.colBackNum.Name = "colBackNum";
            this.colBackNum.OptionsColumn.AllowEdit = false;
            this.colBackNum.OptionsFilter.AllowFilter = false;
            this.colBackNum.Visible = true;
            this.colBackNum.VisibleIndex = 12;
            this.colBackNum.Width = 96;
            // 
            // rpiBackNum
            // 
            this.rpiBackNum.AutoHeight = false;
            this.rpiBackNum.Mask.EditMask = "n6";
            this.rpiBackNum.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Numeric;
            this.rpiBackNum.Name = "rpiBackNum";
            this.rpiBackNum.EditValueChanged += new System.EventHandler(this.rpiBackNum_EditValueChanged);
            // 
            // colBackUnitQty
            // 
            this.colBackUnitQty.AppearanceHeader.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.colBackUnitQty.AppearanceHeader.Options.UseForeColor = true;
            this.colBackUnitQty.Caption = "本次退货套数";
            this.colBackUnitQty.ColumnEdit = this.rpiBackUnitQty;
            this.colBackUnitQty.FieldName = "BackUnitQty";
            this.colBackUnitQty.Name = "colBackUnitQty";
            this.colBackUnitQty.OptionsColumn.AllowEdit = false;
            this.colBackUnitQty.OptionsFilter.AllowFilter = false;
            this.colBackUnitQty.Summary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] {
            new DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum)});
            this.colBackUnitQty.Width = 90;
            // 
            // rpiBackUnitQty
            // 
            this.rpiBackUnitQty.AutoHeight = false;
            this.rpiBackUnitQty.Mask.EditMask = "n6";
            this.rpiBackUnitQty.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Numeric;
            this.rpiBackUnitQty.Name = "rpiBackUnitQty";
            this.rpiBackUnitQty.EditValueChanged += new System.EventHandler(this.rpiBackUnitQty_EditValueChanged);
            // 
            // colBOMQty
            // 
            this.colBOMQty.Caption = "BOM用量";
            this.colBOMQty.FieldName = "BOMQty";
            this.colBOMQty.Name = "colBOMQty";
            this.colBOMQty.OptionsColumn.AllowEdit = false;
            this.colBOMQty.OptionsFilter.AllowFilter = false;
            // 
            // colMOMaterialsID
            // 
            this.colMOMaterialsID.Caption = "gridColumn12";
            this.colMOMaterialsID.FieldName = "MOMaterialsID";
            this.colMOMaterialsID.Name = "colMOMaterialsID";
            this.colMOMaterialsID.OptionsColumn.AllowEdit = false;
            this.colMOMaterialsID.OptionsFilter.AllowFilter = false;
            // 
            // gridColUnitQty
            // 
            this.gridColUnitQty.Caption = "订单数量";
            this.gridColUnitQty.FieldName = "UnitQty";
            this.gridColUnitQty.Name = "gridColUnitQty";
            this.gridColUnitQty.OptionsColumn.AllowEdit = false;
            this.gridColUnitQty.OptionsFilter.AllowFilter = false;
            this.gridColUnitQty.Visible = true;
            this.gridColUnitQty.VisibleIndex = 8;
            // 
            // gridColcItemCode
            // 
            this.gridColcItemCode.Caption = "外销单号";
            this.gridColcItemCode.FieldName = "cItemCode";
            this.gridColcItemCode.Name = "gridColcItemCode";
            this.gridColcItemCode.OptionsColumn.AllowEdit = false;
            this.gridColcItemCode.OptionsFilter.AllowFilter = false;
            this.gridColcItemCode.Visible = true;
            this.gridColcItemCode.VisibleIndex = 7;
            // 
            // LookUpWH
            // 
            this.LookUpWH.AutoHeight = false;
            this.LookUpWH.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.LookUpWH.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("cWhCode", 100, "仓库编号"),
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("cWhName", 250, "仓库名称")});
            this.LookUpWH.DisplayMember = "cWhName";
            this.LookUpWH.Name = "LookUpWH";
            this.LookUpWH.NullText = "";
            this.LookUpWH.PopupWidth = 350;
            this.LookUpWH.ValueMember = "cWhCode";
            this.LookUpWH.EditValueChanged += new System.EventHandler(this.LookUpWH_EditValueChanged);
            // 
            // FrmVenBack
            // 
            this.Appearance.BackColor = System.Drawing.SystemColors.Control;
            this.Appearance.Options.UseBackColor = true;
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1007, 555);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.groupBox2);
            this.Name = "FrmVenBack";
            this.Text = "委外退货";
            this.Load += new System.EventHandler(this.FormVenBack_Load);
            this.Controls.SetChildIndex(this.groupBox2, 0);
            this.Controls.SetChildIndex(this.groupBox1, 0);
            //((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dsPrint)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dsForm)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtSel)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtVenName.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtVenCode.Properties)).EndInit();
            this.groupBox2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.grdDetail)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grvDetail)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.rpiBackQty)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.rpiBackNum)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.rpiBackUnitQty)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.LookUpWH)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private DevExpress.XtraGrid.GridControl grdDetail;
        private DevExpress.XtraGrid.Views.Grid.GridView grvDetail;
        private DevExpress.XtraGrid.Columns.GridColumn colMoCode;
        private DevExpress.XtraGrid.Columns.GridColumn gridColcInvCode;
        private DevExpress.XtraGrid.Columns.GridColumn gridColcInvName;
        private DevExpress.XtraGrid.Columns.GridColumn gridColcInvStd;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn1;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn2;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn3;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn4;
        private DevExpress.XtraGrid.Columns.GridColumn colArriveDate;
        private DevExpress.XtraGrid.Columns.GridColumn colBackQty;
        private DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit LookUpWH;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn9;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn8;
        private DevExpress.XtraGrid.Columns.GridColumn colOMDId;
        private DevExpress.XtraEditors.TextEdit txtVenName;
        private DevExpress.XtraEditors.ButtonEdit txtVenCode;
        private System.Windows.Forms.Label label1;
        private DevExpress.XtraGrid.Columns.GridColumn colBackUnitQty;
        private DevExpress.XtraGrid.Columns.GridColumn colBOMQty;
        private DevExpress.XtraEditors.Repository.RepositoryItemTextEdit rpiBackQty;
        private DevExpress.XtraEditors.Repository.RepositoryItemTextEdit rpiBackUnitQty;
        private DevExpress.XtraGrid.Columns.GridColumn colSendQty;
        private DevExpress.XtraGrid.Columns.GridColumn colSendNum;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn11;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn10;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn6;
        private DevExpress.XtraGrid.Columns.GridColumn colMOMaterialsID;
        private DevExpress.XtraGrid.Columns.GridColumn colCRate;
        private DevExpress.XtraGrid.Columns.GridColumn colBackNum;
        private DevExpress.XtraEditors.Repository.RepositoryItemTextEdit rpiBackNum;
        private DevExpress.XtraGrid.Columns.GridColumn colHaveUsedQty;
        private DevExpress.XtraGrid.Columns.GridColumn colRemainQty;
        private DevExpress.XtraGrid.Columns.GridColumn colRemainNum;
        private DevExpress.XtraGrid.Columns.GridColumn gridColUnitQty;
        private DevExpress.XtraGrid.Columns.GridColumn gridColcItemCode;
        private System.Windows.Forms.CheckBox chk含AK订单;
    }
}