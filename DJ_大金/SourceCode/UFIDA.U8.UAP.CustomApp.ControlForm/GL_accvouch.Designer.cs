namespace UFIDA.U8.UAP.CustomApp.ControlForm
{
    partial class GL_accvouch
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

        #region 组件设计器生成的代码

        /// <summary> 
        /// 设计器支持所需的方法 - 不要
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.ItemTextEditn2 = new DevExpress.XtraEditors.Repository.RepositoryItemTextEdit();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.btnSel = new System.Windows.Forms.ToolStripMenuItem();
            this.btnSave = new System.Windows.Forms.ToolStripMenuItem();
            this.panel1 = new System.Windows.Forms.Panel();
            this.chkAll = new System.Windows.Forms.CheckBox();
            this.gridControl1 = new DevExpress.XtraGrid.GridControl();
            this.gridView1 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.gridColbChoose = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColNEWBW = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColKOSTL = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColPRCTR = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColPROJK = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColAUFNR = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColWRBTR = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColDMBTR = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColMWSKZ = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColZUONR = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColSGTXT = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColXREF1 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColXREF2 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColXREF3 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColZFBDT = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColZTERM = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColZLSCH = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColZLSPR = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColZBD1T = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColHBKID = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColBVTYP = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColVALUT = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColWDATE = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColXBLNR = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColBLDAT = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColBUDAT = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColBKTXT = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColWAERS = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColKURSF = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColNEWKO = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColNEWBS = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColNEWUM = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColbUsed = new DevExpress.XtraGrid.Columns.GridColumn();
            ((System.ComponentModel.ISupportInitialize)(this.ItemTextEditn2)).BeginInit();
            this.menuStrip1.SuspendLayout();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).BeginInit();
            this.SuspendLayout();
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
            // menuStrip1
            // 
            this.menuStrip1.AllowDrop = true;
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btnSel,
            this.btnSave});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(1031, 33);
            this.menuStrip1.TabIndex = 172;
            this.menuStrip1.Text = "menuStrip";
            // 
            // btnSel
            // 
            this.btnSel.Name = "btnSel";
            this.btnSel.Size = new System.Drawing.Size(62, 29);
            this.btnSel.Text = "加载";
            this.btnSel.Click += new System.EventHandler(this.btnSel_Click);
            // 
            // btnSave
            // 
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(62, 29);
            this.btnSave.Text = "保存";
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // panel1
            // 
            this.panel1.AutoScroll = true;
            this.panel1.Controls.Add(this.chkAll);
            this.panel1.Controls.Add(this.gridControl1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 33);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1031, 362);
            this.panel1.TabIndex = 173;
            // 
            // chkAll
            // 
            this.chkAll.AutoSize = true;
            this.chkAll.Location = new System.Drawing.Point(15, 17);
            this.chkAll.Name = "chkAll";
            this.chkAll.Size = new System.Drawing.Size(59, 19);
            this.chkAll.TabIndex = 196;
            this.chkAll.Text = "全选";
            this.chkAll.UseVisualStyleBackColor = true;
            this.chkAll.CheckedChanged += new System.EventHandler(this.chkAll_CheckedChanged);
            // 
            // gridControl1
            // 
            this.gridControl1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.gridControl1.Location = new System.Drawing.Point(3, 42);
            this.gridControl1.LookAndFeel.SkinName = "Office 2010 Blue";
            this.gridControl1.MainView = this.gridView1;
            this.gridControl1.Name = "gridControl1";
            this.gridControl1.Size = new System.Drawing.Size(1025, 317);
            this.gridControl1.TabIndex = 192;
            this.gridControl1.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView1});
            // 
            // gridView1
            // 
            this.gridView1.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.gridColbChoose,
            this.gridColNEWBW,
            this.gridColKOSTL,
            this.gridColPRCTR,
            this.gridColPROJK,
            this.gridColAUFNR,
            this.gridColWRBTR,
            this.gridColDMBTR,
            this.gridColMWSKZ,
            this.gridColZUONR,
            this.gridColSGTXT,
            this.gridColXREF1,
            this.gridColXREF2,
            this.gridColXREF3,
            this.gridColZFBDT,
            this.gridColZTERM,
            this.gridColZLSCH,
            this.gridColZLSPR,
            this.gridColZBD1T,
            this.gridColHBKID,
            this.gridColBVTYP,
            this.gridColVALUT,
            this.gridColWDATE,
            this.gridColXBLNR,
            this.gridColBLDAT,
            this.gridColBUDAT,
            this.gridColBKTXT,
            this.gridColWAERS,
            this.gridColKURSF,
            this.gridColNEWKO,
            this.gridColNEWBS,
            this.gridColNEWUM,
            this.gridColbUsed});
            this.gridView1.GridControl = this.gridControl1;
            this.gridView1.IndicatorWidth = 40;
            this.gridView1.Name = "gridView1";
            this.gridView1.OptionsBehavior.AllowDeleteRows = DevExpress.Utils.DefaultBoolean.True;
            this.gridView1.OptionsBehavior.EditorShowMode = DevExpress.Utils.EditorShowMode.MouseDown;
            this.gridView1.OptionsCustomization.AllowGroup = false;
            this.gridView1.OptionsCustomization.AllowQuickHideColumns = false;
            this.gridView1.OptionsNavigation.EnterMoveNextColumn = true;
            this.gridView1.OptionsPrint.AutoWidth = false;
            this.gridView1.OptionsView.ColumnAutoWidth = false;
            this.gridView1.OptionsView.ShowFooter = true;
            this.gridView1.OptionsView.ShowGroupPanel = false;
            this.gridView1.CustomDrawRowIndicator += new DevExpress.XtraGrid.Views.Grid.RowIndicatorCustomDrawEventHandler(this.gridView1_CustomDrawRowIndicator);
            this.gridView1.CellValueChanged += new DevExpress.XtraGrid.Views.Base.CellValueChangedEventHandler(this.gridView1_CellValueChanged);
            // 
            // gridColbChoose
            // 
            this.gridColbChoose.Caption = "选择";
            this.gridColbChoose.FieldName = "bChoose";
            this.gridColbChoose.Name = "gridColbChoose";
            this.gridColbChoose.Visible = true;
            this.gridColbChoose.VisibleIndex = 0;
            this.gridColbChoose.Width = 37;
            // 
            // gridColNEWBW
            // 
            this.gridColNEWBW.Caption = "NEWBW";
            this.gridColNEWBW.FieldName = "NEWBW";
            this.gridColNEWBW.Name = "gridColNEWBW";
            this.gridColNEWBW.OptionsColumn.AllowEdit = false;
            this.gridColNEWBW.Visible = true;
            this.gridColNEWBW.VisibleIndex = 10;
            // 
            // gridColKOSTL
            // 
            this.gridColKOSTL.Caption = "KOSTL";
            this.gridColKOSTL.FieldName = "KOSTL";
            this.gridColKOSTL.Name = "gridColKOSTL";
            this.gridColKOSTL.OptionsColumn.AllowEdit = false;
            this.gridColKOSTL.Visible = true;
            this.gridColKOSTL.VisibleIndex = 11;
            // 
            // gridColPRCTR
            // 
            this.gridColPRCTR.Caption = "PRCTR";
            this.gridColPRCTR.FieldName = "PRCTR";
            this.gridColPRCTR.Name = "gridColPRCTR";
            this.gridColPRCTR.OptionsColumn.AllowEdit = false;
            this.gridColPRCTR.Visible = true;
            this.gridColPRCTR.VisibleIndex = 12;
            // 
            // gridColPROJK
            // 
            this.gridColPROJK.Caption = "PROJK";
            this.gridColPROJK.FieldName = "PROJK";
            this.gridColPROJK.Name = "gridColPROJK";
            this.gridColPROJK.OptionsColumn.AllowEdit = false;
            this.gridColPROJK.Visible = true;
            this.gridColPROJK.VisibleIndex = 13;
            // 
            // gridColAUFNR
            // 
            this.gridColAUFNR.Caption = "AUFNR";
            this.gridColAUFNR.FieldName = "AUFNR";
            this.gridColAUFNR.Name = "gridColAUFNR";
            this.gridColAUFNR.OptionsColumn.AllowEdit = false;
            this.gridColAUFNR.Visible = true;
            this.gridColAUFNR.VisibleIndex = 14;
            // 
            // gridColWRBTR
            // 
            this.gridColWRBTR.Caption = "WRBTR";
            this.gridColWRBTR.FieldName = "WRBTR";
            this.gridColWRBTR.Name = "gridColWRBTR";
            this.gridColWRBTR.OptionsColumn.AllowEdit = false;
            this.gridColWRBTR.Visible = true;
            this.gridColWRBTR.VisibleIndex = 15;
            // 
            // gridColDMBTR
            // 
            this.gridColDMBTR.Caption = "DMBTR";
            this.gridColDMBTR.FieldName = "DMBTR";
            this.gridColDMBTR.Name = "gridColDMBTR";
            this.gridColDMBTR.OptionsColumn.AllowEdit = false;
            this.gridColDMBTR.Visible = true;
            this.gridColDMBTR.VisibleIndex = 16;
            // 
            // gridColMWSKZ
            // 
            this.gridColMWSKZ.Caption = "MWSKZ";
            this.gridColMWSKZ.FieldName = "MWSKZ";
            this.gridColMWSKZ.Name = "gridColMWSKZ";
            this.gridColMWSKZ.OptionsColumn.AllowEdit = false;
            this.gridColMWSKZ.Visible = true;
            this.gridColMWSKZ.VisibleIndex = 17;
            // 
            // gridColZUONR
            // 
            this.gridColZUONR.Caption = "ZUONR";
            this.gridColZUONR.FieldName = "ZUONR";
            this.gridColZUONR.Name = "gridColZUONR";
            this.gridColZUONR.OptionsColumn.AllowEdit = false;
            this.gridColZUONR.Visible = true;
            this.gridColZUONR.VisibleIndex = 18;
            // 
            // gridColSGTXT
            // 
            this.gridColSGTXT.Caption = "SGTXT";
            this.gridColSGTXT.FieldName = "SGTXT";
            this.gridColSGTXT.Name = "gridColSGTXT";
            this.gridColSGTXT.OptionsColumn.AllowEdit = false;
            this.gridColSGTXT.Visible = true;
            this.gridColSGTXT.VisibleIndex = 19;
            // 
            // gridColXREF1
            // 
            this.gridColXREF1.Caption = "XREF1";
            this.gridColXREF1.FieldName = "XREF1";
            this.gridColXREF1.Name = "gridColXREF1";
            this.gridColXREF1.OptionsColumn.AllowEdit = false;
            this.gridColXREF1.Visible = true;
            this.gridColXREF1.VisibleIndex = 20;
            // 
            // gridColXREF2
            // 
            this.gridColXREF2.Caption = "XREF2";
            this.gridColXREF2.FieldName = "XREF2";
            this.gridColXREF2.Name = "gridColXREF2";
            this.gridColXREF2.OptionsColumn.AllowEdit = false;
            this.gridColXREF2.Visible = true;
            this.gridColXREF2.VisibleIndex = 21;
            // 
            // gridColXREF3
            // 
            this.gridColXREF3.Caption = "XREF3";
            this.gridColXREF3.FieldName = "XREF3";
            this.gridColXREF3.Name = "gridColXREF3";
            this.gridColXREF3.OptionsColumn.AllowEdit = false;
            this.gridColXREF3.Visible = true;
            this.gridColXREF3.VisibleIndex = 22;
            // 
            // gridColZFBDT
            // 
            this.gridColZFBDT.Caption = "ZFBDT";
            this.gridColZFBDT.FieldName = "ZFBDT";
            this.gridColZFBDT.Name = "gridColZFBDT";
            this.gridColZFBDT.OptionsColumn.AllowEdit = false;
            this.gridColZFBDT.Visible = true;
            this.gridColZFBDT.VisibleIndex = 23;
            // 
            // gridColZTERM
            // 
            this.gridColZTERM.Caption = "ZTERM";
            this.gridColZTERM.FieldName = "ZTERM";
            this.gridColZTERM.Name = "gridColZTERM";
            this.gridColZTERM.OptionsColumn.AllowEdit = false;
            this.gridColZTERM.Visible = true;
            this.gridColZTERM.VisibleIndex = 24;
            // 
            // gridColZLSCH
            // 
            this.gridColZLSCH.Caption = "ZLSCH";
            this.gridColZLSCH.FieldName = "ZLSCH";
            this.gridColZLSCH.Name = "gridColZLSCH";
            this.gridColZLSCH.OptionsColumn.AllowEdit = false;
            this.gridColZLSCH.Visible = true;
            this.gridColZLSCH.VisibleIndex = 25;
            // 
            // gridColZLSPR
            // 
            this.gridColZLSPR.Caption = "ZLSPR";
            this.gridColZLSPR.FieldName = "ZLSPR";
            this.gridColZLSPR.Name = "gridColZLSPR";
            this.gridColZLSPR.OptionsColumn.AllowEdit = false;
            this.gridColZLSPR.Visible = true;
            this.gridColZLSPR.VisibleIndex = 26;
            // 
            // gridColZBD1T
            // 
            this.gridColZBD1T.Caption = "ZBD1T";
            this.gridColZBD1T.FieldName = "ZBD1T";
            this.gridColZBD1T.Name = "gridColZBD1T";
            this.gridColZBD1T.OptionsColumn.AllowEdit = false;
            this.gridColZBD1T.Visible = true;
            this.gridColZBD1T.VisibleIndex = 27;
            // 
            // gridColHBKID
            // 
            this.gridColHBKID.Caption = "HBKID";
            this.gridColHBKID.FieldName = "HBKID";
            this.gridColHBKID.Name = "gridColHBKID";
            this.gridColHBKID.OptionsColumn.AllowEdit = false;
            this.gridColHBKID.Visible = true;
            this.gridColHBKID.VisibleIndex = 28;
            // 
            // gridColBVTYP
            // 
            this.gridColBVTYP.Caption = "BVTYP";
            this.gridColBVTYP.FieldName = "BVTYP";
            this.gridColBVTYP.Name = "gridColBVTYP";
            this.gridColBVTYP.OptionsColumn.AllowEdit = false;
            this.gridColBVTYP.Visible = true;
            this.gridColBVTYP.VisibleIndex = 29;
            // 
            // gridColVALUT
            // 
            this.gridColVALUT.Caption = "VALUT";
            this.gridColVALUT.FieldName = "VALUT";
            this.gridColVALUT.Name = "gridColVALUT";
            this.gridColVALUT.OptionsColumn.AllowEdit = false;
            this.gridColVALUT.Visible = true;
            this.gridColVALUT.VisibleIndex = 30;
            // 
            // gridColWDATE
            // 
            this.gridColWDATE.Caption = "WDATE";
            this.gridColWDATE.FieldName = "WDATE";
            this.gridColWDATE.Name = "gridColWDATE";
            this.gridColWDATE.OptionsColumn.AllowEdit = false;
            this.gridColWDATE.Visible = true;
            this.gridColWDATE.VisibleIndex = 31;
            // 
            // gridColXBLNR
            // 
            this.gridColXBLNR.Caption = "XBLNR";
            this.gridColXBLNR.FieldName = "XBLNR";
            this.gridColXBLNR.Name = "gridColXBLNR";
            this.gridColXBLNR.OptionsColumn.AllowEdit = false;
            this.gridColXBLNR.Visible = true;
            this.gridColXBLNR.VisibleIndex = 1;
            // 
            // gridColBLDAT
            // 
            this.gridColBLDAT.Caption = "BLDAT";
            this.gridColBLDAT.FieldName = "BLDAT";
            this.gridColBLDAT.Name = "gridColBLDAT";
            this.gridColBLDAT.OptionsColumn.AllowEdit = false;
            this.gridColBLDAT.Visible = true;
            this.gridColBLDAT.VisibleIndex = 2;
            // 
            // gridColBUDAT
            // 
            this.gridColBUDAT.Caption = "BUDAT";
            this.gridColBUDAT.FieldName = "BUDAT";
            this.gridColBUDAT.Name = "gridColBUDAT";
            this.gridColBUDAT.OptionsColumn.AllowEdit = false;
            this.gridColBUDAT.Visible = true;
            this.gridColBUDAT.VisibleIndex = 3;
            // 
            // gridColBKTXT
            // 
            this.gridColBKTXT.Caption = "BKTXT";
            this.gridColBKTXT.FieldName = "BKTXT";
            this.gridColBKTXT.Name = "gridColBKTXT";
            this.gridColBKTXT.OptionsColumn.AllowEdit = false;
            this.gridColBKTXT.Visible = true;
            this.gridColBKTXT.VisibleIndex = 4;
            // 
            // gridColWAERS
            // 
            this.gridColWAERS.Caption = "WAERS";
            this.gridColWAERS.FieldName = "WAERS";
            this.gridColWAERS.Name = "gridColWAERS";
            this.gridColWAERS.OptionsColumn.AllowEdit = false;
            this.gridColWAERS.Visible = true;
            this.gridColWAERS.VisibleIndex = 5;
            // 
            // gridColKURSF
            // 
            this.gridColKURSF.Caption = "KURSF";
            this.gridColKURSF.FieldName = "KURSF";
            this.gridColKURSF.Name = "gridColKURSF";
            this.gridColKURSF.OptionsColumn.AllowEdit = false;
            this.gridColKURSF.Visible = true;
            this.gridColKURSF.VisibleIndex = 6;
            // 
            // gridColNEWKO
            // 
            this.gridColNEWKO.Caption = "NEWKO";
            this.gridColNEWKO.FieldName = "NEWKO";
            this.gridColNEWKO.Name = "gridColNEWKO";
            this.gridColNEWKO.OptionsColumn.AllowEdit = false;
            this.gridColNEWKO.Visible = true;
            this.gridColNEWKO.VisibleIndex = 7;
            // 
            // gridColNEWBS
            // 
            this.gridColNEWBS.Caption = "NEWBS";
            this.gridColNEWBS.FieldName = "NEWBS";
            this.gridColNEWBS.Name = "gridColNEWBS";
            this.gridColNEWBS.OptionsColumn.AllowEdit = false;
            this.gridColNEWBS.Visible = true;
            this.gridColNEWBS.VisibleIndex = 8;
            // 
            // gridColNEWUM
            // 
            this.gridColNEWUM.Caption = "NEWUM";
            this.gridColNEWUM.FieldName = "NEWUM";
            this.gridColNEWUM.Name = "gridColNEWUM";
            this.gridColNEWUM.OptionsColumn.AllowEdit = false;
            this.gridColNEWUM.Visible = true;
            this.gridColNEWUM.VisibleIndex = 9;
            // 
            // gridColbUsed
            // 
            this.gridColbUsed.Caption = "bUsed";
            this.gridColbUsed.FieldName = "bUsed";
            this.gridColbUsed.Name = "gridColbUsed";
            this.gridColbUsed.OptionsColumn.AllowEdit = false;
            this.gridColbUsed.Visible = true;
            this.gridColbUsed.VisibleIndex = 32;
            // 
            // GL_accvouch
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.menuStrip1);
            this.Name = "GL_accvouch";
            this.Size = new System.Drawing.Size(1031, 395);
            this.Load += new System.EventHandler(this.Frm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.ItemTextEditn2)).EndInit();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem btnSave;
        private System.Windows.Forms.Panel panel1;
        private DevExpress.XtraGrid.GridControl gridControl1;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView1;
        private DevExpress.XtraEditors.Repository.RepositoryItemTextEdit ItemTextEditn2;
        private System.Windows.Forms.ToolStripMenuItem btnSel;
        private System.Windows.Forms.CheckBox chkAll;
        private DevExpress.XtraGrid.Columns.GridColumn gridColbChoose;
        private DevExpress.XtraGrid.Columns.GridColumn gridColNEWBW;
        private DevExpress.XtraGrid.Columns.GridColumn gridColKOSTL;
        private DevExpress.XtraGrid.Columns.GridColumn gridColPRCTR;
        private DevExpress.XtraGrid.Columns.GridColumn gridColPROJK;
        private DevExpress.XtraGrid.Columns.GridColumn gridColAUFNR;
        private DevExpress.XtraGrid.Columns.GridColumn gridColWRBTR;
        private DevExpress.XtraGrid.Columns.GridColumn gridColDMBTR;
        private DevExpress.XtraGrid.Columns.GridColumn gridColMWSKZ;
        private DevExpress.XtraGrid.Columns.GridColumn gridColZUONR;
        private DevExpress.XtraGrid.Columns.GridColumn gridColSGTXT;
        private DevExpress.XtraGrid.Columns.GridColumn gridColXREF1;
        private DevExpress.XtraGrid.Columns.GridColumn gridColXREF2;
        private DevExpress.XtraGrid.Columns.GridColumn gridColXREF3;
        private DevExpress.XtraGrid.Columns.GridColumn gridColZFBDT;
        private DevExpress.XtraGrid.Columns.GridColumn gridColZTERM;
        private DevExpress.XtraGrid.Columns.GridColumn gridColZLSCH;
        private DevExpress.XtraGrid.Columns.GridColumn gridColZLSPR;
        private DevExpress.XtraGrid.Columns.GridColumn gridColZBD1T;
        private DevExpress.XtraGrid.Columns.GridColumn gridColHBKID;
        private DevExpress.XtraGrid.Columns.GridColumn gridColBVTYP;
        private DevExpress.XtraGrid.Columns.GridColumn gridColVALUT;
        private DevExpress.XtraGrid.Columns.GridColumn gridColWDATE;
        private DevExpress.XtraGrid.Columns.GridColumn gridColXBLNR;
        private DevExpress.XtraGrid.Columns.GridColumn gridColBLDAT;
        private DevExpress.XtraGrid.Columns.GridColumn gridColBUDAT;
        private DevExpress.XtraGrid.Columns.GridColumn gridColBKTXT;
        private DevExpress.XtraGrid.Columns.GridColumn gridColWAERS;
        private DevExpress.XtraGrid.Columns.GridColumn gridColKURSF;
        private DevExpress.XtraGrid.Columns.GridColumn gridColNEWKO;
        private DevExpress.XtraGrid.Columns.GridColumn gridColNEWBS;
        private DevExpress.XtraGrid.Columns.GridColumn gridColNEWUM;
        private DevExpress.XtraGrid.Columns.GridColumn gridColbUsed;
    }
}
