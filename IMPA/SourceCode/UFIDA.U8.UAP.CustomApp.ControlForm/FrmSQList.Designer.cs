namespace UFIDA.U8.UAP.CustomApp.ControlForm
{
    partial class FrmSQList
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
            this.gridControlSQ = new DevExpress.XtraGrid.GridControl();
            this.gridViewSQ = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.gridColRef = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColStkID = new DevExpress.XtraGrid.Columns.GridColumn();
            this.ItemLookUpEditcInvCode = new DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit();
            this.gridColDesc = new DevExpress.XtraGrid.Columns.GridColumn();
            this.ItemLookUpEditcInvName = new DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit();
            this.gridColQty = new DevExpress.XtraGrid.Columns.GridColumn();
            this.ItemTextEditn2 = new DevExpress.XtraEditors.Repository.RepositoryItemTextEdit();
            this.gridColUOM = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColRatio = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColStkQty = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColATP = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColListPrice = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColHistPrice = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColDisc = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColNett = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColSupp = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColCost = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColMarkup = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColEstGP = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColcCode = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColdDate = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColcexch_name = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColcPersonCode = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColcCusCode = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColcCusName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColcDepName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridcCusPerson = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColcDefine11 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColcDefine7 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColcCusOAddress = new DevExpress.XtraGrid.Columns.GridColumn();
            this.btnOK = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnQuery = new System.Windows.Forms.Button();
            this.lookUpEditCustomer = new DevExpress.XtraEditors.LookUpEdit();
            this.lookUpEditAC = new DevExpress.XtraEditors.LookUpEdit();
            this.label9 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.txtSQ = new DevExpress.XtraEditors.TextEdit();
            this.label6 = new System.Windows.Forms.Label();
            this.dtm1 = new DevExpress.XtraEditors.DateEdit();
            this.dtm2 = new DevExpress.XtraEditors.DateEdit();
            ((System.ComponentModel.ISupportInitialize)(this.gridControlSQ)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridViewSQ)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ItemLookUpEditcInvCode)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ItemLookUpEditcInvName)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ItemTextEditn2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lookUpEditCustomer.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lookUpEditAC.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtSQ.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtm1.Properties.VistaTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtm1.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtm2.Properties.VistaTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtm2.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // gridControlSQ
            // 
            this.gridControlSQ.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.gridControlSQ.Location = new System.Drawing.Point(8, 77);
            this.gridControlSQ.LookAndFeel.SkinName = "Office 2010 Blue";
            this.gridControlSQ.MainView = this.gridViewSQ;
            this.gridControlSQ.Name = "gridControlSQ";
            this.gridControlSQ.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.ItemLookUpEditcInvCode,
            this.ItemLookUpEditcInvName,
            this.ItemTextEditn2});
            this.gridControlSQ.Size = new System.Drawing.Size(1274, 479);
            this.gridControlSQ.TabIndex = 193;
            this.gridControlSQ.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridViewSQ});
            // 
            // gridViewSQ
            // 
            this.gridViewSQ.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.gridColRef,
            this.gridColStkID,
            this.gridColDesc,
            this.gridColQty,
            this.gridColUOM,
            this.gridColRatio,
            this.gridColStkQty,
            this.gridColATP,
            this.gridColListPrice,
            this.gridColHistPrice,
            this.gridColDisc,
            this.gridColNett,
            this.gridColSupp,
            this.gridColCost,
            this.gridColMarkup,
            this.gridColEstGP,
            this.gridColcCode,
            this.gridColdDate,
            this.gridColcexch_name,
            this.gridColcPersonCode,
            this.gridColcCusCode,
            this.gridColcCusName,
            this.gridColcDepName,
            this.gridcCusPerson,
            this.gridColcDefine11,
            this.gridColcDefine7,
            this.gridColcCusOAddress});
            this.gridViewSQ.GridControl = this.gridControlSQ;
            this.gridViewSQ.IndicatorWidth = 40;
            this.gridViewSQ.Name = "gridViewSQ";
            this.gridViewSQ.OptionsBehavior.AllowDeleteRows = DevExpress.Utils.DefaultBoolean.True;
            this.gridViewSQ.OptionsBehavior.Editable = false;
            this.gridViewSQ.OptionsBehavior.EditorShowMode = DevExpress.Utils.EditorShowMode.MouseDown;
            this.gridViewSQ.OptionsCustomization.AllowGroup = false;
            this.gridViewSQ.OptionsCustomization.AllowQuickHideColumns = false;
            this.gridViewSQ.OptionsNavigation.EnterMoveNextColumn = true;
            this.gridViewSQ.OptionsPrint.AutoWidth = false;
            this.gridViewSQ.OptionsView.ColumnAutoWidth = false;
            this.gridViewSQ.OptionsView.ShowFooter = true;
            this.gridViewSQ.OptionsView.ShowGroupPanel = false;
            this.gridViewSQ.CustomDrawRowIndicator += new DevExpress.XtraGrid.Views.Grid.RowIndicatorCustomDrawEventHandler(this.gridViewSQ_CustomDrawRowIndicator);
            this.gridViewSQ.DoubleClick += new System.EventHandler(this.gridViewSQ_DoubleClick);
            // 
            // gridColRef
            // 
            this.gridColRef.Caption = "Ref#";
            this.gridColRef.FieldName = "Ref";
            this.gridColRef.Name = "gridColRef";
            this.gridColRef.Visible = true;
            this.gridColRef.VisibleIndex = 11;
            // 
            // gridColStkID
            // 
            this.gridColStkID.Caption = "StkID";
            this.gridColStkID.ColumnEdit = this.ItemLookUpEditcInvCode;
            this.gridColStkID.FieldName = "cInvCode";
            this.gridColStkID.Name = "gridColStkID";
            this.gridColStkID.Visible = true;
            this.gridColStkID.VisibleIndex = 13;
            // 
            // ItemLookUpEditcInvCode
            // 
            this.ItemLookUpEditcInvCode.AutoHeight = false;
            this.ItemLookUpEditcInvCode.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.ItemLookUpEditcInvCode.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("cInvCode", "StkID"),
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("cInvName", 60, "Desc.")});
            this.ItemLookUpEditcInvCode.DisplayMember = "cInvCode";
            this.ItemLookUpEditcInvCode.Name = "ItemLookUpEditcInvCode";
            this.ItemLookUpEditcInvCode.NullText = "";
            this.ItemLookUpEditcInvCode.PopupWidth = 600;
            this.ItemLookUpEditcInvCode.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.Standard;
            this.ItemLookUpEditcInvCode.ValueMember = "cInvCode";
            // 
            // gridColDesc
            // 
            this.gridColDesc.Caption = "Desc.";
            this.gridColDesc.ColumnEdit = this.ItemLookUpEditcInvName;
            this.gridColDesc.FieldName = "cInvCode";
            this.gridColDesc.Name = "gridColDesc";
            this.gridColDesc.Visible = true;
            this.gridColDesc.VisibleIndex = 14;
            // 
            // ItemLookUpEditcInvName
            // 
            this.ItemLookUpEditcInvName.AutoHeight = false;
            this.ItemLookUpEditcInvName.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.ItemLookUpEditcInvName.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("cInvCode", "StkID"),
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("cInvName", 60, "Desc.")});
            this.ItemLookUpEditcInvName.DisplayMember = "cInvName";
            this.ItemLookUpEditcInvName.Name = "ItemLookUpEditcInvName";
            this.ItemLookUpEditcInvName.NullText = "";
            this.ItemLookUpEditcInvName.PopupWidth = 600;
            this.ItemLookUpEditcInvName.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.Standard;
            this.ItemLookUpEditcInvName.ValueMember = "cInvCode";
            // 
            // gridColQty
            // 
            this.gridColQty.Caption = "Qty";
            this.gridColQty.ColumnEdit = this.ItemTextEditn2;
            this.gridColQty.FieldName = "iQuantity";
            this.gridColQty.Name = "gridColQty";
            this.gridColQty.Summary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] {
            new DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "Qty", "")});
            this.gridColQty.Visible = true;
            this.gridColQty.VisibleIndex = 15;
            // 
            // ItemTextEditn2
            // 
            this.ItemTextEditn2.AutoHeight = false;
            this.ItemTextEditn2.DisplayFormat.FormatString = "n2";
            this.ItemTextEditn2.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.ItemTextEditn2.EditFormat.FormatString = "n2";
            this.ItemTextEditn2.EditFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.ItemTextEditn2.Mask.EditMask = "n2";
            this.ItemTextEditn2.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Numeric;
            this.ItemTextEditn2.Name = "ItemTextEditn2";
            // 
            // gridColUOM
            // 
            this.gridColUOM.Caption = "UOM";
            this.gridColUOM.FieldName = "cComUnitName";
            this.gridColUOM.Name = "gridColUOM";
            this.gridColUOM.OptionsColumn.AllowEdit = false;
            this.gridColUOM.Visible = true;
            this.gridColUOM.VisibleIndex = 16;
            // 
            // gridColRatio
            // 
            this.gridColRatio.Caption = "Ratio";
            this.gridColRatio.ColumnEdit = this.ItemTextEditn2;
            this.gridColRatio.FieldName = "Ratio";
            this.gridColRatio.Name = "gridColRatio";
            this.gridColRatio.OptionsColumn.AllowEdit = false;
            this.gridColRatio.Visible = true;
            this.gridColRatio.VisibleIndex = 17;
            // 
            // gridColStkQty
            // 
            this.gridColStkQty.Caption = "StkQty";
            this.gridColStkQty.ColumnEdit = this.ItemTextEditn2;
            this.gridColStkQty.FieldName = "iNum";
            this.gridColStkQty.Name = "gridColStkQty";
            this.gridColStkQty.OptionsColumn.AllowEdit = false;
            this.gridColStkQty.Visible = true;
            this.gridColStkQty.VisibleIndex = 18;
            // 
            // gridColATP
            // 
            this.gridColATP.Caption = "ATP";
            this.gridColATP.ColumnEdit = this.ItemTextEditn2;
            this.gridColATP.FieldName = "ATP";
            this.gridColATP.Name = "gridColATP";
            this.gridColATP.OptionsColumn.AllowEdit = false;
            this.gridColATP.Visible = true;
            this.gridColATP.VisibleIndex = 19;
            // 
            // gridColListPrice
            // 
            this.gridColListPrice.Caption = "ListPrice";
            this.gridColListPrice.ColumnEdit = this.ItemTextEditn2;
            this.gridColListPrice.FieldName = "ListPrice";
            this.gridColListPrice.Name = "gridColListPrice";
            this.gridColListPrice.Visible = true;
            this.gridColListPrice.VisibleIndex = 20;
            // 
            // gridColHistPrice
            // 
            this.gridColHistPrice.Caption = "HistPrice";
            this.gridColHistPrice.ColumnEdit = this.ItemTextEditn2;
            this.gridColHistPrice.FieldName = "HistPrice";
            this.gridColHistPrice.Name = "gridColHistPrice";
            this.gridColHistPrice.OptionsColumn.AllowEdit = false;
            this.gridColHistPrice.Visible = true;
            this.gridColHistPrice.VisibleIndex = 21;
            // 
            // gridColDisc
            // 
            this.gridColDisc.Caption = "Disc%";
            this.gridColDisc.ColumnEdit = this.ItemTextEditn2;
            this.gridColDisc.FieldName = "Disc";
            this.gridColDisc.Name = "gridColDisc";
            this.gridColDisc.Visible = true;
            this.gridColDisc.VisibleIndex = 22;
            // 
            // gridColNett
            // 
            this.gridColNett.Caption = "Nett";
            this.gridColNett.ColumnEdit = this.ItemTextEditn2;
            this.gridColNett.FieldName = "Nett";
            this.gridColNett.Name = "gridColNett";
            this.gridColNett.OptionsColumn.AllowEdit = false;
            this.gridColNett.Visible = true;
            this.gridColNett.VisibleIndex = 7;
            // 
            // gridColSupp
            // 
            this.gridColSupp.Caption = "Supp";
            this.gridColSupp.FieldName = "Supp";
            this.gridColSupp.Name = "gridColSupp";
            this.gridColSupp.OptionsColumn.AllowEdit = false;
            this.gridColSupp.Visible = true;
            this.gridColSupp.VisibleIndex = 23;
            // 
            // gridColCost
            // 
            this.gridColCost.Caption = "Cost";
            this.gridColCost.ColumnEdit = this.ItemTextEditn2;
            this.gridColCost.FieldName = "Cost";
            this.gridColCost.Name = "gridColCost";
            this.gridColCost.Visible = true;
            this.gridColCost.VisibleIndex = 24;
            // 
            // gridColMarkup
            // 
            this.gridColMarkup.Caption = "Markup";
            this.gridColMarkup.ColumnEdit = this.ItemTextEditn2;
            this.gridColMarkup.FieldName = "Markup";
            this.gridColMarkup.Name = "gridColMarkup";
            this.gridColMarkup.Visible = true;
            this.gridColMarkup.VisibleIndex = 25;
            // 
            // gridColEstGP
            // 
            this.gridColEstGP.Caption = "Est. GP";
            this.gridColEstGP.ColumnEdit = this.ItemTextEditn2;
            this.gridColEstGP.FieldName = "EstGP";
            this.gridColEstGP.Name = "gridColEstGP";
            this.gridColEstGP.OptionsColumn.AllowEdit = false;
            this.gridColEstGP.Visible = true;
            this.gridColEstGP.VisibleIndex = 26;
            // 
            // gridColcCode
            // 
            this.gridColcCode.Caption = "SQ";
            this.gridColcCode.FieldName = "cCode";
            this.gridColcCode.Name = "gridColcCode";
            this.gridColcCode.Visible = true;
            this.gridColcCode.VisibleIndex = 0;
            // 
            // gridColdDate
            // 
            this.gridColdDate.Caption = "Date";
            this.gridColdDate.FieldName = "dDate";
            this.gridColdDate.Name = "gridColdDate";
            this.gridColdDate.Visible = true;
            this.gridColdDate.VisibleIndex = 1;
            // 
            // gridColcexch_name
            // 
            this.gridColcexch_name.Caption = "Currency";
            this.gridColcexch_name.FieldName = "cexch_name";
            this.gridColcexch_name.Name = "gridColcexch_name";
            this.gridColcexch_name.Visible = true;
            this.gridColcexch_name.VisibleIndex = 6;
            // 
            // gridColcPersonCode
            // 
            this.gridColcPersonCode.Caption = "Salesman";
            this.gridColcPersonCode.FieldName = "cPersonCode";
            this.gridColcPersonCode.Name = "gridColcPersonCode";
            this.gridColcPersonCode.Visible = true;
            this.gridColcPersonCode.VisibleIndex = 8;
            // 
            // gridColcCusCode
            // 
            this.gridColcCusCode.Caption = "A/C";
            this.gridColcCusCode.FieldName = "cCusCode";
            this.gridColcCusCode.Name = "gridColcCusCode";
            this.gridColcCusCode.Visible = true;
            this.gridColcCusCode.VisibleIndex = 4;
            // 
            // gridColcCusName
            // 
            this.gridColcCusName.Caption = "Customer";
            this.gridColcCusName.FieldName = "cCusName";
            this.gridColcCusName.Name = "gridColcCusName";
            this.gridColcCusName.Visible = true;
            this.gridColcCusName.VisibleIndex = 5;
            // 
            // gridColcDepName
            // 
            this.gridColcDepName.Caption = "UserDept";
            this.gridColcDepName.FieldName = "cDepName";
            this.gridColcDepName.Name = "gridColcDepName";
            this.gridColcDepName.Visible = true;
            this.gridColcDepName.VisibleIndex = 3;
            // 
            // gridcCusPerson
            // 
            this.gridcCusPerson.Caption = "Attn";
            this.gridcCusPerson.FieldName = "cCusPerson";
            this.gridcCusPerson.Name = "gridcCusPerson";
            this.gridcCusPerson.Visible = true;
            this.gridcCusPerson.VisibleIndex = 10;
            // 
            // gridColcDefine11
            // 
            this.gridColcDefine11.Caption = "CC";
            this.gridColcDefine11.FieldName = "cDefine11";
            this.gridColcDefine11.Name = "gridColcDefine11";
            this.gridColcDefine11.Visible = true;
            this.gridColcDefine11.VisibleIndex = 9;
            // 
            // gridColcDefine7
            // 
            this.gridColcDefine7.Caption = "Disc";
            this.gridColcDefine7.FieldName = "cDefine7";
            this.gridColcDefine7.Name = "gridColcDefine7";
            this.gridColcDefine7.Visible = true;
            this.gridColcDefine7.VisibleIndex = 12;
            // 
            // gridColcCusOAddress
            // 
            this.gridColcCusOAddress.Caption = "ShipTo";
            this.gridColcCusOAddress.FieldName = "cCusOAddress";
            this.gridColcCusOAddress.Name = "gridColcCusOAddress";
            this.gridColcCusOAddress.Visible = true;
            this.gridColcCusOAddress.VisibleIndex = 2;
            // 
            // btnOK
            // 
            this.btnOK.Location = new System.Drawing.Point(781, 33);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(75, 23);
            this.btnOK.TabIndex = 194;
            this.btnOK.Text = "确 定";
            this.btnOK.UseVisualStyleBackColor = true;
            this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(913, 33);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 23);
            this.btnCancel.TabIndex = 195;
            this.btnCancel.Text = "取 消";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // btnQuery
            // 
            this.btnQuery.Location = new System.Drawing.Point(672, 33);
            this.btnQuery.Name = "btnQuery";
            this.btnQuery.Size = new System.Drawing.Size(75, 23);
            this.btnQuery.TabIndex = 194;
            this.btnQuery.Text = "查 询";
            this.btnQuery.UseVisualStyleBackColor = true;
            this.btnQuery.Click += new System.EventHandler(this.btnQuery_Click);
            // 
            // lookUpEditCustomer
            // 
            this.lookUpEditCustomer.Location = new System.Drawing.Point(341, 36);
            this.lookUpEditCustomer.Name = "lookUpEditCustomer";
            this.lookUpEditCustomer.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.lookUpEditCustomer.Properties.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("cCusCode", "CusCode"),
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("cCusName", 60, "CusName")});
            this.lookUpEditCustomer.Properties.DisplayMember = "cCusName";
            this.lookUpEditCustomer.Properties.NullText = "";
            this.lookUpEditCustomer.Properties.PopupWidth = 400;
            this.lookUpEditCustomer.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.Standard;
            this.lookUpEditCustomer.Properties.ValueMember = "cCusCode";
            this.lookUpEditCustomer.Size = new System.Drawing.Size(288, 20);
            this.lookUpEditCustomer.TabIndex = 267;
            this.lookUpEditCustomer.EditValueChanged += new System.EventHandler(this.lookUpEditCustomer_EditValueChanged);
            // 
            // lookUpEditAC
            // 
            this.lookUpEditAC.Location = new System.Drawing.Point(117, 38);
            this.lookUpEditAC.Name = "lookUpEditAC";
            this.lookUpEditAC.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.lookUpEditAC.Properties.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("cCusCode", "CusCode"),
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("cCusName", 60, "CusName")});
            this.lookUpEditAC.Properties.DisplayMember = "cCusCode";
            this.lookUpEditAC.Properties.NullText = "";
            this.lookUpEditAC.Properties.PopupWidth = 400;
            this.lookUpEditAC.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.Standard;
            this.lookUpEditAC.Properties.ValueMember = "cCusCode";
            this.lookUpEditAC.Size = new System.Drawing.Size(141, 20);
            this.lookUpEditAC.TabIndex = 266;
            this.lookUpEditAC.EditValueChanged += new System.EventHandler(this.lookUpEditAC_EditValueChanged);
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.ForeColor = System.Drawing.Color.Black;
            this.label9.Location = new System.Drawing.Point(264, 41);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(53, 12);
            this.label9.TabIndex = 271;
            this.label9.Text = "Customer";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.ForeColor = System.Drawing.Color.Black;
            this.label7.Location = new System.Drawing.Point(276, 15);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(29, 12);
            this.label7.TabIndex = 270;
            this.label7.Text = "Date";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.ForeColor = System.Drawing.Color.Black;
            this.label1.Location = new System.Drawing.Point(45, 41);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(23, 12);
            this.label1.TabIndex = 269;
            this.label1.Text = "A/C";
            // 
            // txtSQ
            // 
            this.txtSQ.Location = new System.Drawing.Point(117, 12);
            this.txtSQ.Name = "txtSQ";
            this.txtSQ.Size = new System.Drawing.Size(141, 20);
            this.txtSQ.TabIndex = 264;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.ForeColor = System.Drawing.Color.Black;
            this.label6.Location = new System.Drawing.Point(45, 15);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(29, 12);
            this.label6.TabIndex = 268;
            this.label6.Text = "SQ #";
            // 
            // dtm1
            // 
            this.dtm1.EditValue = null;
            this.dtm1.Location = new System.Drawing.Point(341, 12);
            this.dtm1.Name = "dtm1";
            this.dtm1.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.dtm1.Properties.VistaTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
            this.dtm1.Size = new System.Drawing.Size(141, 20);
            this.dtm1.TabIndex = 265;
            // 
            // dtm2
            // 
            this.dtm2.EditValue = null;
            this.dtm2.Location = new System.Drawing.Point(488, 12);
            this.dtm2.Name = "dtm2";
            this.dtm2.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.dtm2.Properties.VistaTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
            this.dtm2.Size = new System.Drawing.Size(141, 20);
            this.dtm2.TabIndex = 272;
            // 
            // FrmSQList
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1283, 558);
            this.Controls.Add(this.dtm2);
            this.Controls.Add(this.lookUpEditCustomer);
            this.Controls.Add(this.lookUpEditAC);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtSQ);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.dtm1);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnQuery);
            this.Controls.Add(this.btnOK);
            this.Controls.Add(this.gridControlSQ);
            this.Name = "FrmSQList";
            this.Text = "SQList";
            this.Load += new System.EventHandler(this.FrmSQList_Load);
            ((System.ComponentModel.ISupportInitialize)(this.gridControlSQ)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridViewSQ)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ItemLookUpEditcInvCode)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ItemLookUpEditcInvName)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ItemTextEditn2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lookUpEditCustomer.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lookUpEditAC.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtSQ.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtm1.Properties.VistaTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtm1.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtm2.Properties.VistaTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtm2.Properties)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraGrid.GridControl gridControlSQ;
        private DevExpress.XtraGrid.Views.Grid.GridView gridViewSQ;
        private DevExpress.XtraGrid.Columns.GridColumn gridColRef;
        private DevExpress.XtraGrid.Columns.GridColumn gridColStkID;
        private DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit ItemLookUpEditcInvCode;
        private DevExpress.XtraGrid.Columns.GridColumn gridColDesc;
        private DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit ItemLookUpEditcInvName;
        private DevExpress.XtraGrid.Columns.GridColumn gridColQty;
        private DevExpress.XtraEditors.Repository.RepositoryItemTextEdit ItemTextEditn2;
        private DevExpress.XtraGrid.Columns.GridColumn gridColUOM;
        private DevExpress.XtraGrid.Columns.GridColumn gridColRatio;
        private DevExpress.XtraGrid.Columns.GridColumn gridColStkQty;
        private DevExpress.XtraGrid.Columns.GridColumn gridColATP;
        private DevExpress.XtraGrid.Columns.GridColumn gridColListPrice;
        private DevExpress.XtraGrid.Columns.GridColumn gridColHistPrice;
        private DevExpress.XtraGrid.Columns.GridColumn gridColDisc;
        private DevExpress.XtraGrid.Columns.GridColumn gridColNett;
        private DevExpress.XtraGrid.Columns.GridColumn gridColSupp;
        private DevExpress.XtraGrid.Columns.GridColumn gridColCost;
        private DevExpress.XtraGrid.Columns.GridColumn gridColMarkup;
        private DevExpress.XtraGrid.Columns.GridColumn gridColEstGP;
        private System.Windows.Forms.Button btnOK;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Button btnQuery;
        private DevExpress.XtraGrid.Columns.GridColumn gridColcCode;
        private DevExpress.XtraGrid.Columns.GridColumn gridColdDate;
        private DevExpress.XtraGrid.Columns.GridColumn gridColcexch_name;
        private DevExpress.XtraGrid.Columns.GridColumn gridColcPersonCode;
        private DevExpress.XtraGrid.Columns.GridColumn gridColcCusCode;
        private DevExpress.XtraGrid.Columns.GridColumn gridColcCusName;
        private DevExpress.XtraGrid.Columns.GridColumn gridColcDepName;
        private DevExpress.XtraGrid.Columns.GridColumn gridcCusPerson;
        private DevExpress.XtraGrid.Columns.GridColumn gridColcDefine11;
        private DevExpress.XtraGrid.Columns.GridColumn gridColcDefine7;
        private DevExpress.XtraGrid.Columns.GridColumn gridColcCusOAddress;
        private DevExpress.XtraEditors.LookUpEdit lookUpEditCustomer;
        private DevExpress.XtraEditors.LookUpEdit lookUpEditAC;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label1;
        private DevExpress.XtraEditors.TextEdit txtSQ;
        private System.Windows.Forms.Label label6;
        private DevExpress.XtraEditors.DateEdit dtm1;
        private DevExpress.XtraEditors.DateEdit dtm2;
    }
}