namespace clsU8
{
    partial class Frm收款单导入
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
            this.gridControl1 = new DevExpress.XtraGrid.GridControl();
            this.gridView1 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.gridColchoose = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColDate = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColGMCVCode = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColCurency = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColExchangeRate = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColOriginal = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColLocalAMT = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColDocumentNo = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColInvoiceNo = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColDiscription = new DevExpress.XtraGrid.Columns.GridColumn();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.btnLoad = new System.Windows.Forms.ToolStripMenuItem();
            this.btnSave = new System.Windows.Forms.ToolStripMenuItem();
            this.chkAll = new System.Windows.Forms.CheckBox();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).BeginInit();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // gridControl1
            // 
            this.gridControl1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.gridControl1.EmbeddedNavigator.Margin = new System.Windows.Forms.Padding(4);
            this.gridControl1.Location = new System.Drawing.Point(0, 70);
            this.gridControl1.LookAndFeel.SkinName = "Office 2010 Blue";
            this.gridControl1.MainView = this.gridView1;
            this.gridControl1.Margin = new System.Windows.Forms.Padding(4);
            this.gridControl1.Name = "gridControl1";
            this.gridControl1.Size = new System.Drawing.Size(1200, 461);
            this.gridControl1.TabIndex = 192;
            this.gridControl1.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView1});
            // 
            // gridView1
            // 
            this.gridView1.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.gridColchoose,
            this.gridColDate,
            this.gridColGMCVCode,
            this.gridColCurency,
            this.gridColExchangeRate,
            this.gridColOriginal,
            this.gridColLocalAMT,
            this.gridColDocumentNo,
            this.gridColInvoiceNo,
            this.gridColDiscription});
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
            // 
            // gridColchoose
            // 
            this.gridColchoose.Caption = "Selected";
            this.gridColchoose.FieldName = "choose";
            this.gridColchoose.Fixed = DevExpress.XtraGrid.Columns.FixedStyle.Left;
            this.gridColchoose.Name = "gridColchoose";
            this.gridColchoose.Visible = true;
            this.gridColchoose.VisibleIndex = 0;
            this.gridColchoose.Width = 74;
            // 
            // gridColDate
            // 
            this.gridColDate.Caption = "Date";
            this.gridColDate.FieldName = "Date";
            this.gridColDate.Name = "gridColDate";
            this.gridColDate.Visible = true;
            this.gridColDate.VisibleIndex = 1;
            // 
            // gridColGMCVCode
            // 
            this.gridColGMCVCode.Caption = "GMCV Code ";
            this.gridColGMCVCode.FieldName = "GMCVCode";
            this.gridColGMCVCode.Name = "gridColGMCVCode";
            this.gridColGMCVCode.Visible = true;
            this.gridColGMCVCode.VisibleIndex = 2;
            this.gridColGMCVCode.Width = 91;
            // 
            // gridColCurency
            // 
            this.gridColCurency.Caption = "Curency";
            this.gridColCurency.FieldName = "Curency";
            this.gridColCurency.Name = "gridColCurency";
            this.gridColCurency.Visible = true;
            this.gridColCurency.VisibleIndex = 3;
            // 
            // gridColExchangeRate
            // 
            this.gridColExchangeRate.Caption = "Exchange Rate";
            this.gridColExchangeRate.FieldName = "ExchangeRate";
            this.gridColExchangeRate.Name = "gridColExchangeRate";
            this.gridColExchangeRate.Visible = true;
            this.gridColExchangeRate.VisibleIndex = 4;
            this.gridColExchangeRate.Width = 107;
            // 
            // gridColOriginal
            // 
            this.gridColOriginal.Caption = "Original";
            this.gridColOriginal.FieldName = "Original";
            this.gridColOriginal.Name = "gridColOriginal";
            this.gridColOriginal.Visible = true;
            this.gridColOriginal.VisibleIndex = 5;
            // 
            // gridColLocalAMT
            // 
            this.gridColLocalAMT.Caption = "LocalAMT";
            this.gridColLocalAMT.FieldName = "LocalAMT";
            this.gridColLocalAMT.Name = "gridColLocalAMT";
            this.gridColLocalAMT.Visible = true;
            this.gridColLocalAMT.VisibleIndex = 6;
            // 
            // gridColDocumentNo
            // 
            this.gridColDocumentNo.Caption = "Document No.";
            this.gridColDocumentNo.FieldName = "DocumentNo";
            this.gridColDocumentNo.Name = "gridColDocumentNo";
            this.gridColDocumentNo.Visible = true;
            this.gridColDocumentNo.VisibleIndex = 7;
            this.gridColDocumentNo.Width = 104;
            // 
            // gridColInvoiceNo
            // 
            this.gridColInvoiceNo.Caption = "Invoice No.";
            this.gridColInvoiceNo.FieldName = "InvoiceNo";
            this.gridColInvoiceNo.Name = "gridColInvoiceNo";
            this.gridColInvoiceNo.Visible = true;
            this.gridColInvoiceNo.VisibleIndex = 8;
            this.gridColInvoiceNo.Width = 84;
            // 
            // gridColDiscription
            // 
            this.gridColDiscription.Caption = "Discription";
            this.gridColDiscription.FieldName = "Discription";
            this.gridColDiscription.Name = "gridColDiscription";
            this.gridColDiscription.Visible = true;
            this.gridColDiscription.VisibleIndex = 9;
            this.gridColDiscription.Width = 142;
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btnLoad,
            this.btnSave});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Padding = new System.Windows.Forms.Padding(8, 2, 0, 2);
            this.menuStrip1.Size = new System.Drawing.Size(1200, 28);
            this.menuStrip1.TabIndex = 193;
            this.menuStrip1.Text = "menuStrip";
            // 
            // btnLoad
            // 
            this.btnLoad.Name = "btnLoad";
            this.btnLoad.Size = new System.Drawing.Size(57, 24);
            this.btnLoad.Text = "Load";
            this.btnLoad.Click += new System.EventHandler(this.btnLoad_Click);
            // 
            // btnSave
            // 
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(55, 24);
            this.btnSave.Text = "Save";
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // chkAll
            // 
            this.chkAll.AutoSize = true;
            this.chkAll.Location = new System.Drawing.Point(13, 43);
            this.chkAll.Margin = new System.Windows.Forms.Padding(4);
            this.chkAll.Name = "chkAll";
            this.chkAll.Size = new System.Drawing.Size(109, 19);
            this.chkAll.TabIndex = 217;
            this.chkAll.Text = "Select All";
            this.chkAll.UseVisualStyleBackColor = true;
            this.chkAll.CheckedChanged += new System.EventHandler(this.chkAll_CheckedChanged);
            // 
            // Frm收款单导入
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.ClientSize = new System.Drawing.Size(1200, 532);
            this.Controls.Add(this.chkAll);
            this.Controls.Add(this.menuStrip1);
            this.Controls.Add(this.gridControl1);
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "Frm收款单导入";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "ImportAR";
            this.Load += new System.EventHandler(this.Frm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).EndInit();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraGrid.GridControl gridControl1;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView1;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem btnLoad;
        private System.Windows.Forms.ToolStripMenuItem btnSave;
        private DevExpress.XtraGrid.Columns.GridColumn gridColDate;
        private DevExpress.XtraGrid.Columns.GridColumn gridColGMCVCode;
        private DevExpress.XtraGrid.Columns.GridColumn gridColCurency;
        private DevExpress.XtraGrid.Columns.GridColumn gridColExchangeRate;
        private DevExpress.XtraGrid.Columns.GridColumn gridColOriginal;
        private DevExpress.XtraGrid.Columns.GridColumn gridColLocalAMT;
        private DevExpress.XtraGrid.Columns.GridColumn gridColDocumentNo;
        private DevExpress.XtraGrid.Columns.GridColumn gridColInvoiceNo;
        private DevExpress.XtraGrid.Columns.GridColumn gridColDiscription;
        private DevExpress.XtraGrid.Columns.GridColumn gridColchoose;
        private System.Windows.Forms.CheckBox chkAll;

    }
}