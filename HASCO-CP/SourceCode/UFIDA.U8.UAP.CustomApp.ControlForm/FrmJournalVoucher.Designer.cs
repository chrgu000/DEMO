namespace UFIDA.U8.UAP.CustomApp.ControlForm
{
    partial class FrmJournalVoucher
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
            this.gridColSummary = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColAccountName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColDebitAmount = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColCreditAmount = new DevExpress.XtraGrid.Columns.GridColumn();
            this.btnSave = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // gridControl1
            // 
            this.gridControl1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.gridControl1.Location = new System.Drawing.Point(12, 2);
            this.gridControl1.LookAndFeel.SkinName = "Office 2010 Blue";
            this.gridControl1.MainView = this.gridView1;
            this.gridControl1.Name = "gridControl1";
            this.gridControl1.Size = new System.Drawing.Size(834, 422);
            this.gridControl1.TabIndex = 195;
            this.gridControl1.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView1});
            // 
            // gridView1
            // 
            this.gridView1.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.gridColSummary,
            this.gridColAccountName,
            this.gridColDebitAmount,
            this.gridColCreditAmount});
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
            // gridColSummary
            // 
            this.gridColSummary.Caption = "Summary";
            this.gridColSummary.FieldName = "Summary";
            this.gridColSummary.Name = "gridColSummary";
            this.gridColSummary.Visible = true;
            this.gridColSummary.VisibleIndex = 0;
            this.gridColSummary.Width = 238;
            // 
            // gridColAccountName
            // 
            this.gridColAccountName.Caption = "Account Name";
            this.gridColAccountName.FieldName = "AccountName";
            this.gridColAccountName.Name = "gridColAccountName";
            this.gridColAccountName.OptionsColumn.AllowEdit = false;
            this.gridColAccountName.Visible = true;
            this.gridColAccountName.VisibleIndex = 1;
            this.gridColAccountName.Width = 155;
            // 
            // gridColDebitAmount
            // 
            this.gridColDebitAmount.Caption = "Debit Amount";
            this.gridColDebitAmount.FieldName = "DebitAmount";
            this.gridColDebitAmount.Name = "gridColDebitAmount";
            this.gridColDebitAmount.OptionsColumn.AllowEdit = false;
            this.gridColDebitAmount.Visible = true;
            this.gridColDebitAmount.VisibleIndex = 2;
            this.gridColDebitAmount.Width = 143;
            // 
            // gridColCreditAmount
            // 
            this.gridColCreditAmount.Caption = "Credit Amount";
            this.gridColCreditAmount.FieldName = "CreditAmount";
            this.gridColCreditAmount.Name = "gridColCreditAmount";
            this.gridColCreditAmount.OptionsColumn.AllowEdit = false;
            this.gridColCreditAmount.Visible = true;
            this.gridColCreditAmount.VisibleIndex = 3;
            this.gridColCreditAmount.Width = 178;
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(611, 429);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(75, 23);
            this.btnSave.TabIndex = 196;
            this.btnSave.Text = "Save";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(724, 430);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 23);
            this.btnCancel.TabIndex = 197;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // FrmJournalVoucher
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(849, 464);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.gridControl1);
            this.Name = "FrmJournalVoucher";
            this.Text = "FrmJournalVoucher";
            this.Load += new System.EventHandler(this.FrmJournalVoucher_Load);
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraGrid.GridControl gridControl1;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView1;
        private DevExpress.XtraGrid.Columns.GridColumn gridColSummary;
        private DevExpress.XtraGrid.Columns.GridColumn gridColAccountName;
        private DevExpress.XtraGrid.Columns.GridColumn gridColDebitAmount;
        private DevExpress.XtraGrid.Columns.GridColumn gridColCreditAmount;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Button btnCancel;
    }
}