namespace UFIDA.U8.UAP.CustomApp.ControlForm
{
    partial class Frm高开返利核销单窗体
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
            this.splitContainerControl1 = new DevExpress.XtraEditors.SplitContainerControl();
            this.gridControl返利单 = new DevExpress.XtraGrid.GridControl();
            this.gridView返利单 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.gridCol发票号 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridCol发票日期 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridCol客户编码 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridCol客户名称 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridCol存货编码 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridCol存货名称 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridCol规格型号 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridCol差价税率 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridCol差价税额 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridCol返利金额 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridCol代理商编码 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridCol代理商 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColcPersonCode = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColcPersonName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColcDCCode = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColcDCName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColiID = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColHXMoney = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColcCode = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColdtmDate = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColFLD_iID = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridControl_发票 = new DevExpress.XtraGrid.GridControl();
            this.gridView_发票 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.gridCol_FPCode = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridCoL_FPDate = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridCol_代理商编码 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridCol_代理商名称 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridCol_发票金额 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridCol_UnMoney = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridCol_HXMoney = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridCol_FP_IDs = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridCol业务员编号 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridCol业务员名称 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridCol支付金额 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridCol费率 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.txt备注 = new DevExpress.XtraEditors.TextEdit();
            this.label7 = new System.Windows.Forms.Label();
            this.dtm = new DevExpress.XtraEditors.DateEdit();
            this.label2 = new System.Windows.Forms.Label();
            this.txt单据号 = new DevExpress.XtraEditors.TextEdit();
            this.label4 = new System.Windows.Forms.Label();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.btnDel = new System.Windows.Forms.ToolStripMenuItem();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerControl1)).BeginInit();
            this.splitContainerControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl返利单)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView返利单)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl_发票)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView_发票)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txt备注.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtm.Properties.VistaTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtm.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txt单据号.Properties)).BeginInit();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // splitContainerControl1
            // 
            this.splitContainerControl1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.splitContainerControl1.Horizontal = false;
            this.splitContainerControl1.Location = new System.Drawing.Point(5, 93);
            this.splitContainerControl1.Name = "splitContainerControl1";
            this.splitContainerControl1.Panel1.Controls.Add(this.gridControl返利单);
            this.splitContainerControl1.Panel1.Text = "Panel1";
            this.splitContainerControl1.Panel2.Controls.Add(this.gridControl_发票);
            this.splitContainerControl1.Panel2.Text = "Panel2";
            this.splitContainerControl1.Size = new System.Drawing.Size(984, 475);
            this.splitContainerControl1.SplitterPosition = 237;
            this.splitContainerControl1.TabIndex = 263;
            this.splitContainerControl1.Text = "splitContainerControl1";
            // 
            // gridControl返利单
            // 
            this.gridControl返利单.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridControl返利单.Location = new System.Drawing.Point(0, 0);
            this.gridControl返利单.LookAndFeel.SkinName = "Office 2010 Blue";
            this.gridControl返利单.MainView = this.gridView返利单;
            this.gridControl返利单.Name = "gridControl返利单";
            this.gridControl返利单.Size = new System.Drawing.Size(984, 237);
            this.gridControl返利单.TabIndex = 191;
            this.gridControl返利单.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView返利单});
            // 
            // gridView返利单
            // 
            this.gridView返利单.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.gridCol发票号,
            this.gridCol发票日期,
            this.gridCol客户编码,
            this.gridCol客户名称,
            this.gridCol存货编码,
            this.gridCol存货名称,
            this.gridCol规格型号,
            this.gridCol差价税率,
            this.gridCol差价税额,
            this.gridCol返利金额,
            this.gridCol代理商编码,
            this.gridCol代理商,
            this.gridColcPersonCode,
            this.gridColcPersonName,
            this.gridColcDCCode,
            this.gridColcDCName,
            this.gridColiID,
            this.gridColHXMoney,
            this.gridColcCode,
            this.gridColdtmDate,
            this.gridColFLD_iID});
            this.gridView返利单.GridControl = this.gridControl返利单;
            this.gridView返利单.IndicatorWidth = 40;
            this.gridView返利单.Name = "gridView返利单";
            this.gridView返利单.OptionsBehavior.AllowDeleteRows = DevExpress.Utils.DefaultBoolean.True;
            this.gridView返利单.OptionsBehavior.Editable = false;
            this.gridView返利单.OptionsBehavior.EditorShowMode = DevExpress.Utils.EditorShowMode.MouseDown;
            this.gridView返利单.OptionsCustomization.AllowGroup = false;
            this.gridView返利单.OptionsCustomization.AllowQuickHideColumns = false;
            this.gridView返利单.OptionsNavigation.EnterMoveNextColumn = true;
            this.gridView返利单.OptionsView.ColumnAutoWidth = false;
            this.gridView返利单.OptionsView.ShowFooter = true;
            this.gridView返利单.OptionsView.ShowGroupPanel = false;
            // 
            // gridCol发票号
            // 
            this.gridCol发票号.Caption = "发票号";
            this.gridCol发票号.FieldName = "cSBVCode";
            this.gridCol发票号.Name = "gridCol发票号";
            this.gridCol发票号.OptionsColumn.AllowEdit = false;
            this.gridCol发票号.Visible = true;
            this.gridCol发票号.VisibleIndex = 2;
            // 
            // gridCol发票日期
            // 
            this.gridCol发票日期.Caption = "发票日期";
            this.gridCol发票日期.FieldName = "dDate";
            this.gridCol发票日期.Name = "gridCol发票日期";
            this.gridCol发票日期.OptionsColumn.AllowEdit = false;
            this.gridCol发票日期.Visible = true;
            this.gridCol发票日期.VisibleIndex = 3;
            // 
            // gridCol客户编码
            // 
            this.gridCol客户编码.Caption = "客户编码";
            this.gridCol客户编码.FieldName = "cCusCode";
            this.gridCol客户编码.Name = "gridCol客户编码";
            this.gridCol客户编码.OptionsColumn.AllowEdit = false;
            // 
            // gridCol客户名称
            // 
            this.gridCol客户名称.Caption = "客户名称";
            this.gridCol客户名称.FieldName = "cCusName";
            this.gridCol客户名称.Name = "gridCol客户名称";
            this.gridCol客户名称.OptionsColumn.AllowEdit = false;
            // 
            // gridCol存货编码
            // 
            this.gridCol存货编码.Caption = "存货编码";
            this.gridCol存货编码.FieldName = "cInvCode";
            this.gridCol存货编码.Name = "gridCol存货编码";
            this.gridCol存货编码.OptionsColumn.AllowEdit = false;
            this.gridCol存货编码.Visible = true;
            this.gridCol存货编码.VisibleIndex = 4;
            // 
            // gridCol存货名称
            // 
            this.gridCol存货名称.Caption = "存货名称";
            this.gridCol存货名称.FieldName = "cInvName";
            this.gridCol存货名称.Name = "gridCol存货名称";
            this.gridCol存货名称.OptionsColumn.AllowEdit = false;
            this.gridCol存货名称.Visible = true;
            this.gridCol存货名称.VisibleIndex = 5;
            // 
            // gridCol规格型号
            // 
            this.gridCol规格型号.Caption = "规格型号";
            this.gridCol规格型号.FieldName = "cInvStd";
            this.gridCol规格型号.Name = "gridCol规格型号";
            this.gridCol规格型号.OptionsColumn.AllowEdit = false;
            this.gridCol规格型号.Visible = true;
            this.gridCol规格型号.VisibleIndex = 6;
            // 
            // gridCol差价税率
            // 
            this.gridCol差价税率.Caption = "差价税率";
            this.gridCol差价税率.FieldName = "iTaxRateCJ";
            this.gridCol差价税率.Name = "gridCol差价税率";
            this.gridCol差价税率.OptionsColumn.AllowEdit = false;
            this.gridCol差价税率.Visible = true;
            this.gridCol差价税率.VisibleIndex = 7;
            // 
            // gridCol差价税额
            // 
            this.gridCol差价税额.Caption = "差价税额";
            this.gridCol差价税额.FieldName = "iTaxCJ";
            this.gridCol差价税额.Name = "gridCol差价税额";
            this.gridCol差价税额.OptionsColumn.AllowEdit = false;
            this.gridCol差价税额.Visible = true;
            this.gridCol差价税额.VisibleIndex = 8;
            // 
            // gridCol返利金额
            // 
            this.gridCol返利金额.Caption = "返利金额";
            this.gridCol返利金额.FieldName = "iMoneyFL";
            this.gridCol返利金额.Name = "gridCol返利金额";
            this.gridCol返利金额.OptionsColumn.AllowEdit = false;
            this.gridCol返利金额.Summary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] {
            new DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum)});
            this.gridCol返利金额.Visible = true;
            this.gridCol返利金额.VisibleIndex = 9;
            // 
            // gridCol代理商编码
            // 
            this.gridCol代理商编码.Caption = "代理商编码";
            this.gridCol代理商编码.FieldName = "DLS";
            this.gridCol代理商编码.Name = "gridCol代理商编码";
            this.gridCol代理商编码.OptionsColumn.AllowEdit = false;
            this.gridCol代理商编码.Visible = true;
            this.gridCol代理商编码.VisibleIndex = 13;
            // 
            // gridCol代理商
            // 
            this.gridCol代理商.Caption = "代理商";
            this.gridCol代理商.FieldName = "DLSName";
            this.gridCol代理商.Name = "gridCol代理商";
            this.gridCol代理商.OptionsColumn.AllowEdit = false;
            this.gridCol代理商.Visible = true;
            this.gridCol代理商.VisibleIndex = 14;
            this.gridCol代理商.Width = 87;
            // 
            // gridColcPersonCode
            // 
            this.gridColcPersonCode.Caption = "业务员编码";
            this.gridColcPersonCode.FieldName = "cPersonCode";
            this.gridColcPersonCode.Name = "gridColcPersonCode";
            this.gridColcPersonCode.OptionsColumn.AllowEdit = false;
            this.gridColcPersonCode.Visible = true;
            this.gridColcPersonCode.VisibleIndex = 11;
            // 
            // gridColcPersonName
            // 
            this.gridColcPersonName.Caption = "业务员";
            this.gridColcPersonName.FieldName = "cPersonName";
            this.gridColcPersonName.Name = "gridColcPersonName";
            this.gridColcPersonName.OptionsColumn.AllowEdit = false;
            this.gridColcPersonName.Visible = true;
            this.gridColcPersonName.VisibleIndex = 12;
            // 
            // gridColcDCCode
            // 
            this.gridColcDCCode.Caption = "地区编码";
            this.gridColcDCCode.FieldName = "cDCCode";
            this.gridColcDCCode.Name = "gridColcDCCode";
            this.gridColcDCCode.OptionsColumn.AllowEdit = false;
            // 
            // gridColcDCName
            // 
            this.gridColcDCName.Caption = "地区";
            this.gridColcDCName.FieldName = "cDCName";
            this.gridColcDCName.Name = "gridColcDCName";
            this.gridColcDCName.OptionsColumn.AllowEdit = false;
            // 
            // gridColiID
            // 
            this.gridColiID.Caption = "iID";
            this.gridColiID.FieldName = "iID";
            this.gridColiID.Name = "gridColiID";
            this.gridColiID.OptionsColumn.AllowEdit = false;
            // 
            // gridColHXMoney
            // 
            this.gridColHXMoney.Caption = "本次核销金额";
            this.gridColHXMoney.FieldName = "HXMoney";
            this.gridColHXMoney.Name = "gridColHXMoney";
            this.gridColHXMoney.Summary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] {
            new DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum)});
            this.gridColHXMoney.Visible = true;
            this.gridColHXMoney.VisibleIndex = 10;
            this.gridColHXMoney.Width = 81;
            // 
            // gridColcCode
            // 
            this.gridColcCode.Caption = "返利单号";
            this.gridColcCode.FieldName = "cCode";
            this.gridColcCode.Name = "gridColcCode";
            this.gridColcCode.OptionsColumn.AllowEdit = false;
            this.gridColcCode.Visible = true;
            this.gridColcCode.VisibleIndex = 0;
            // 
            // gridColdtmDate
            // 
            this.gridColdtmDate.Caption = "返利单日期";
            this.gridColdtmDate.FieldName = "dtmDate";
            this.gridColdtmDate.Name = "gridColdtmDate";
            this.gridColdtmDate.OptionsColumn.AllowEdit = false;
            this.gridColdtmDate.Visible = true;
            this.gridColdtmDate.VisibleIndex = 1;
            // 
            // gridColFLD_iID
            // 
            this.gridColFLD_iID.Caption = "FLD_iID";
            this.gridColFLD_iID.FieldName = "FLD_iID";
            this.gridColFLD_iID.Name = "gridColFLD_iID";
            this.gridColFLD_iID.OptionsColumn.AllowEdit = false;
            this.gridColFLD_iID.Visible = true;
            this.gridColFLD_iID.VisibleIndex = 15;
            // 
            // gridControl_发票
            // 
            this.gridControl_发票.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridControl_发票.Location = new System.Drawing.Point(0, 0);
            this.gridControl_发票.LookAndFeel.SkinName = "Office 2010 Blue";
            this.gridControl_发票.MainView = this.gridView_发票;
            this.gridControl_发票.Name = "gridControl_发票";
            this.gridControl_发票.Size = new System.Drawing.Size(984, 233);
            this.gridControl_发票.TabIndex = 193;
            this.gridControl_发票.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView_发票});
            // 
            // gridView_发票
            // 
            this.gridView_发票.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.gridCol_FPCode,
            this.gridCoL_FPDate,
            this.gridCol_代理商编码,
            this.gridCol_代理商名称,
            this.gridCol_发票金额,
            this.gridCol_UnMoney,
            this.gridCol_HXMoney,
            this.gridCol_FP_IDs,
            this.gridCol业务员编号,
            this.gridCol业务员名称,
            this.gridCol支付金额,
            this.gridCol费率});
            this.gridView_发票.GridControl = this.gridControl_发票;
            this.gridView_发票.IndicatorWidth = 40;
            this.gridView_发票.Name = "gridView_发票";
            this.gridView_发票.OptionsBehavior.AllowDeleteRows = DevExpress.Utils.DefaultBoolean.True;
            this.gridView_发票.OptionsBehavior.EditorShowMode = DevExpress.Utils.EditorShowMode.MouseDown;
            this.gridView_发票.OptionsCustomization.AllowGroup = false;
            this.gridView_发票.OptionsCustomization.AllowQuickHideColumns = false;
            this.gridView_发票.OptionsNavigation.EnterMoveNextColumn = true;
            this.gridView_发票.OptionsView.ColumnAutoWidth = false;
            this.gridView_发票.OptionsView.ShowFooter = true;
            this.gridView_发票.OptionsView.ShowGroupPanel = false;
            // 
            // gridCol_FPCode
            // 
            this.gridCol_FPCode.Caption = "发票号";
            this.gridCol_FPCode.FieldName = "FPCode";
            this.gridCol_FPCode.Name = "gridCol_FPCode";
            this.gridCol_FPCode.OptionsColumn.AllowEdit = false;
            this.gridCol_FPCode.Visible = true;
            this.gridCol_FPCode.VisibleIndex = 2;
            // 
            // gridCoL_FPDate
            // 
            this.gridCoL_FPDate.Caption = "发票日期";
            this.gridCoL_FPDate.FieldName = "FPDate";
            this.gridCoL_FPDate.Name = "gridCoL_FPDate";
            this.gridCoL_FPDate.OptionsColumn.AllowEdit = false;
            this.gridCoL_FPDate.Visible = true;
            this.gridCoL_FPDate.VisibleIndex = 3;
            // 
            // gridCol_代理商编码
            // 
            this.gridCol_代理商编码.Caption = "代理商编码";
            this.gridCol_代理商编码.FieldName = "代理商编码";
            this.gridCol_代理商编码.Name = "gridCol_代理商编码";
            this.gridCol_代理商编码.OptionsColumn.AllowEdit = false;
            this.gridCol_代理商编码.Visible = true;
            this.gridCol_代理商编码.VisibleIndex = 4;
            // 
            // gridCol_代理商名称
            // 
            this.gridCol_代理商名称.Caption = "代理商名称";
            this.gridCol_代理商名称.FieldName = "代理商名称";
            this.gridCol_代理商名称.Name = "gridCol_代理商名称";
            this.gridCol_代理商名称.OptionsColumn.AllowEdit = false;
            this.gridCol_代理商名称.Visible = true;
            this.gridCol_代理商名称.VisibleIndex = 5;
            // 
            // gridCol_发票金额
            // 
            this.gridCol_发票金额.Caption = "发票金额";
            this.gridCol_发票金额.FieldName = "发票金额";
            this.gridCol_发票金额.Name = "gridCol_发票金额";
            this.gridCol_发票金额.OptionsColumn.AllowEdit = false;
            this.gridCol_发票金额.Summary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] {
            new DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum)});
            this.gridCol_发票金额.Visible = true;
            this.gridCol_发票金额.VisibleIndex = 6;
            // 
            // gridCol_UnMoney
            // 
            this.gridCol_UnMoney.Caption = "未核销金额";
            this.gridCol_UnMoney.FieldName = "UnMoney";
            this.gridCol_UnMoney.Name = "gridCol_UnMoney";
            this.gridCol_UnMoney.OptionsColumn.AllowEdit = false;
            this.gridCol_UnMoney.Summary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] {
            new DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum)});
            this.gridCol_UnMoney.Width = 99;
            // 
            // gridCol_HXMoney
            // 
            this.gridCol_HXMoney.Caption = "本次核销金额";
            this.gridCol_HXMoney.FieldName = "HXMoney";
            this.gridCol_HXMoney.Name = "gridCol_HXMoney";
            this.gridCol_HXMoney.Summary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] {
            new DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum)});
            this.gridCol_HXMoney.Visible = true;
            this.gridCol_HXMoney.VisibleIndex = 9;
            this.gridCol_HXMoney.Width = 87;
            // 
            // gridCol_FP_IDs
            // 
            this.gridCol_FP_IDs.Caption = "FP_IDs";
            this.gridCol_FP_IDs.FieldName = "FP_IDs";
            this.gridCol_FP_IDs.Name = "gridCol_FP_IDs";
            this.gridCol_FP_IDs.OptionsColumn.AllowEdit = false;
            this.gridCol_FP_IDs.Visible = true;
            this.gridCol_FP_IDs.VisibleIndex = 10;
            // 
            // gridCol业务员编号
            // 
            this.gridCol业务员编号.Caption = "业务员编号";
            this.gridCol业务员编号.FieldName = "业务员编号";
            this.gridCol业务员编号.Name = "gridCol业务员编号";
            this.gridCol业务员编号.OptionsColumn.AllowEdit = false;
            this.gridCol业务员编号.Visible = true;
            this.gridCol业务员编号.VisibleIndex = 0;
            // 
            // gridCol业务员名称
            // 
            this.gridCol业务员名称.Caption = "业务员名称";
            this.gridCol业务员名称.FieldName = "业务员名称";
            this.gridCol业务员名称.Name = "gridCol业务员名称";
            this.gridCol业务员名称.OptionsColumn.AllowEdit = false;
            this.gridCol业务员名称.Visible = true;
            this.gridCol业务员名称.VisibleIndex = 1;
            // 
            // gridCol支付金额
            // 
            this.gridCol支付金额.Caption = "支付金额";
            this.gridCol支付金额.FieldName = "支付金额";
            this.gridCol支付金额.Name = "gridCol支付金额";
            this.gridCol支付金额.OptionsColumn.AllowEdit = false;
            this.gridCol支付金额.Summary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] {
            new DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum)});
            this.gridCol支付金额.Visible = true;
            this.gridCol支付金额.VisibleIndex = 8;
            // 
            // gridCol费率
            // 
            this.gridCol费率.Caption = "费率";
            this.gridCol费率.FieldName = "费率";
            this.gridCol费率.Name = "gridCol费率";
            this.gridCol费率.OptionsColumn.AllowEdit = false;
            this.gridCol费率.Visible = true;
            this.gridCol费率.VisibleIndex = 7;
            // 
            // txt备注
            // 
            this.txt备注.Enabled = false;
            this.txt备注.Location = new System.Drawing.Point(78, 57);
            this.txt备注.Name = "txt备注";
            this.txt备注.Properties.DisplayFormat.FormatString = "n2";
            this.txt备注.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.txt备注.Properties.EditFormat.FormatString = "n2";
            this.txt备注.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.txt备注.Properties.Mask.EditMask = "n2";
            this.txt备注.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Numeric;
            this.txt备注.Size = new System.Drawing.Size(652, 20);
            this.txt备注.TabIndex = 262;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Enabled = false;
            this.label7.Location = new System.Drawing.Point(20, 60);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(29, 12);
            this.label7.TabIndex = 261;
            this.label7.Text = "备注";
            this.label7.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // dtm
            // 
            this.dtm.EditValue = null;
            this.dtm.Enabled = false;
            this.dtm.Location = new System.Drawing.Point(293, 31);
            this.dtm.Name = "dtm";
            this.dtm.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.dtm.Properties.VistaTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
            this.dtm.Size = new System.Drawing.Size(122, 20);
            this.dtm.TabIndex = 260;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Enabled = false;
            this.label2.Location = new System.Drawing.Point(220, 34);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(53, 12);
            this.label2.TabIndex = 259;
            this.label2.Text = "单据日期";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txt单据号
            // 
            this.txt单据号.Enabled = false;
            this.txt单据号.Location = new System.Drawing.Point(78, 31);
            this.txt单据号.Name = "txt单据号";
            this.txt单据号.Properties.DisplayFormat.FormatString = "n2";
            this.txt单据号.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.txt单据号.Properties.EditFormat.FormatString = "n2";
            this.txt单据号.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.txt单据号.Properties.Mask.EditMask = "n2";
            this.txt单据号.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Numeric;
            this.txt单据号.Size = new System.Drawing.Size(122, 20);
            this.txt单据号.TabIndex = 258;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Enabled = false;
            this.label4.Location = new System.Drawing.Point(20, 34);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(41, 12);
            this.label4.TabIndex = 257;
            this.label4.Text = "单据号";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btnDel});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(990, 25);
            this.menuStrip1.TabIndex = 264;
            this.menuStrip1.Text = "menuStrip";
            // 
            // btnDel
            // 
            this.btnDel.Name = "btnDel";
            this.btnDel.Size = new System.Drawing.Size(44, 21);
            this.btnDel.Text = "删除";
            this.btnDel.Click += new System.EventHandler(this.btnDel_Click);
            // 
            // Frm高开返利核销单窗体
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(990, 570);
            this.Controls.Add(this.menuStrip1);
            this.Controls.Add(this.splitContainerControl1);
            this.Controls.Add(this.txt备注);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.dtm);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txt单据号);
            this.Controls.Add(this.label4);
            this.Name = "Frm高开返利核销单窗体";
            this.Text = "高开返利核销单";
            this.Load += new System.EventHandler(this.Frm高开返利核销单窗体_Load);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerControl1)).EndInit();
            this.splitContainerControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gridControl返利单)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView返利单)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl_发票)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView_发票)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txt备注.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtm.Properties.VistaTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtm.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txt单据号.Properties)).EndInit();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraEditors.SplitContainerControl splitContainerControl1;
        private DevExpress.XtraGrid.GridControl gridControl返利单;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView返利单;
        private DevExpress.XtraGrid.Columns.GridColumn gridCol发票号;
        private DevExpress.XtraGrid.Columns.GridColumn gridCol发票日期;
        private DevExpress.XtraGrid.Columns.GridColumn gridCol客户编码;
        private DevExpress.XtraGrid.Columns.GridColumn gridCol客户名称;
        private DevExpress.XtraGrid.Columns.GridColumn gridCol存货编码;
        private DevExpress.XtraGrid.Columns.GridColumn gridCol存货名称;
        private DevExpress.XtraGrid.Columns.GridColumn gridCol规格型号;
        private DevExpress.XtraGrid.Columns.GridColumn gridCol差价税率;
        private DevExpress.XtraGrid.Columns.GridColumn gridCol差价税额;
        private DevExpress.XtraGrid.Columns.GridColumn gridCol返利金额;
        private DevExpress.XtraGrid.Columns.GridColumn gridCol代理商编码;
        private DevExpress.XtraGrid.Columns.GridColumn gridCol代理商;
        private DevExpress.XtraGrid.Columns.GridColumn gridColcPersonCode;
        private DevExpress.XtraGrid.Columns.GridColumn gridColcPersonName;
        private DevExpress.XtraGrid.Columns.GridColumn gridColcDCCode;
        private DevExpress.XtraGrid.Columns.GridColumn gridColcDCName;
        private DevExpress.XtraGrid.Columns.GridColumn gridColiID;
        private DevExpress.XtraGrid.Columns.GridColumn gridColHXMoney;
        private DevExpress.XtraGrid.Columns.GridColumn gridColcCode;
        private DevExpress.XtraGrid.Columns.GridColumn gridColdtmDate;
        private DevExpress.XtraGrid.Columns.GridColumn gridColFLD_iID;
        private DevExpress.XtraEditors.TextEdit txt备注;
        private System.Windows.Forms.Label label7;
        private DevExpress.XtraEditors.DateEdit dtm;
        private System.Windows.Forms.Label label2;
        private DevExpress.XtraEditors.TextEdit txt单据号;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem btnDel;
        private DevExpress.XtraGrid.GridControl gridControl_发票;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView_发票;
        private DevExpress.XtraGrid.Columns.GridColumn gridCol_FPCode;
        private DevExpress.XtraGrid.Columns.GridColumn gridCoL_FPDate;
        private DevExpress.XtraGrid.Columns.GridColumn gridCol_代理商编码;
        private DevExpress.XtraGrid.Columns.GridColumn gridCol_代理商名称;
        private DevExpress.XtraGrid.Columns.GridColumn gridCol_发票金额;
        private DevExpress.XtraGrid.Columns.GridColumn gridCol_UnMoney;
        private DevExpress.XtraGrid.Columns.GridColumn gridCol_HXMoney;
        private DevExpress.XtraGrid.Columns.GridColumn gridCol_FP_IDs;
        private DevExpress.XtraGrid.Columns.GridColumn gridCol业务员编号;
        private DevExpress.XtraGrid.Columns.GridColumn gridCol业务员名称;
        private DevExpress.XtraGrid.Columns.GridColumn gridCol支付金额;
        private DevExpress.XtraGrid.Columns.GridColumn gridCol费率;


    }
}