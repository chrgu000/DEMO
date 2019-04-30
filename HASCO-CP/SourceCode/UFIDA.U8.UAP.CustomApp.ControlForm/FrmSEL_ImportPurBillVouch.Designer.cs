namespace UFIDA.U8.UAP.CustomApp.ControlForm
{
    partial class FrmSEL_ImportPurBillVouch
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
            this.dateEdit2 = new DevExpress.XtraEditors.DateEdit();
            this.label3 = new System.Windows.Forms.Label();
            this.dateEdit1 = new DevExpress.XtraEditors.DateEdit();
            this.txtInvoiceNo = new DevExpress.XtraEditors.TextEdit();
            this.label2 = new System.Windows.Forms.Label();
            this.btnQuery = new System.Windows.Forms.Button();
            this.btnOK = new System.Windows.Forms.Button();
            this.gridControl1 = new DevExpress.XtraGrid.GridControl();
            this.gridView1 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.gridColbSelected = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColInvoiceNo = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColdDate = new DevExpress.XtraGrid.Columns.GridColumn();
            this.radioUnCreated = new System.Windows.Forms.RadioButton();
            this.radioCreated = new System.Windows.Forms.RadioButton();
            this.radioAll = new System.Windows.Forms.RadioButton();
            this.txtContainerNO = new DevExpress.XtraEditors.TextEdit();
            this.label1 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dateEdit2.Properties.VistaTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dateEdit2.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dateEdit1.Properties.VistaTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dateEdit1.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtInvoiceNo.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtContainerNO.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // dateEdit2
            // 
            this.dateEdit2.EditValue = null;
            this.dateEdit2.Location = new System.Drawing.Point(362, 11);
            this.dateEdit2.Name = "dateEdit2";
            this.dateEdit2.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.dateEdit2.Properties.VistaTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
            this.dateEdit2.Size = new System.Drawing.Size(114, 20);
            this.dateEdit2.TabIndex = 231;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(207, 15);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(29, 12);
            this.label3.TabIndex = 230;
            this.label3.Text = "Date";
            // 
            // dateEdit1
            // 
            this.dateEdit1.EditValue = null;
            this.dateEdit1.Location = new System.Drawing.Point(242, 11);
            this.dateEdit1.Name = "dateEdit1";
            this.dateEdit1.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.dateEdit1.Properties.VistaTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
            this.dateEdit1.Size = new System.Drawing.Size(114, 20);
            this.dateEdit1.TabIndex = 229;
            // 
            // txtInvoiceNo
            // 
            this.txtInvoiceNo.Location = new System.Drawing.Point(77, 11);
            this.txtInvoiceNo.Name = "txtInvoiceNo";
            this.txtInvoiceNo.Size = new System.Drawing.Size(119, 20);
            this.txtInvoiceNo.TabIndex = 228;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(6, 15);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(59, 12);
            this.label2.TabIndex = 227;
            this.label2.Text = "InvoiceNo";
            // 
            // btnQuery
            // 
            this.btnQuery.Location = new System.Drawing.Point(730, 10);
            this.btnQuery.Name = "btnQuery";
            this.btnQuery.Size = new System.Drawing.Size(75, 23);
            this.btnQuery.TabIndex = 232;
            this.btnQuery.Text = "Query";
            this.btnQuery.UseVisualStyleBackColor = true;
            this.btnQuery.Click += new System.EventHandler(this.btnQuery_Click);
            // 
            // btnOK
            // 
            this.btnOK.Location = new System.Drawing.Point(826, 10);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(75, 23);
            this.btnOK.TabIndex = 233;
            this.btnOK.Text = "OK";
            this.btnOK.UseVisualStyleBackColor = true;
            this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
            // 
            // gridControl1
            // 
            this.gridControl1.Location = new System.Drawing.Point(3, 82);
            this.gridControl1.LookAndFeel.SkinName = "Office 2010 Blue";
            this.gridControl1.MainView = this.gridView1;
            this.gridControl1.Name = "gridControl1";
            this.gridControl1.Size = new System.Drawing.Size(917, 361);
            this.gridControl1.TabIndex = 234;
            this.gridControl1.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView1});
            // 
            // gridView1
            // 
            this.gridView1.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.gridColbSelected,
            this.gridColInvoiceNo,
            this.gridColdDate});
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
            this.gridView1.Click += new System.EventHandler(this.gridView1_Click);
            // 
            // gridColbSelected
            // 
            this.gridColbSelected.Caption = "bSelected";
            this.gridColbSelected.FieldName = "bSelected";
            this.gridColbSelected.Name = "gridColbSelected";
            this.gridColbSelected.OptionsColumn.AllowEdit = false;
            this.gridColbSelected.Visible = true;
            this.gridColbSelected.VisibleIndex = 0;
            // 
            // gridColInvoiceNo
            // 
            this.gridColInvoiceNo.Caption = "InvoiceNo";
            this.gridColInvoiceNo.FieldName = "InvoiceNo";
            this.gridColInvoiceNo.Name = "gridColInvoiceNo";
            this.gridColInvoiceNo.OptionsColumn.AllowEdit = false;
            this.gridColInvoiceNo.Visible = true;
            this.gridColInvoiceNo.VisibleIndex = 1;
            // 
            // gridColdDate
            // 
            this.gridColdDate.Caption = "dDate";
            this.gridColdDate.FieldName = "dDate";
            this.gridColdDate.Name = "gridColdDate";
            this.gridColdDate.OptionsColumn.AllowEdit = false;
            this.gridColdDate.Visible = true;
            this.gridColdDate.VisibleIndex = 2;
            // 
            // radioUnCreated
            // 
            this.radioUnCreated.AutoSize = true;
            this.radioUnCreated.Checked = true;
            this.radioUnCreated.Location = new System.Drawing.Point(12, 50);
            this.radioUnCreated.Name = "radioUnCreated";
            this.radioUnCreated.Size = new System.Drawing.Size(77, 16);
            this.radioUnCreated.TabIndex = 235;
            this.radioUnCreated.TabStop = true;
            this.radioUnCreated.Text = "UnCreated";
            this.radioUnCreated.UseVisualStyleBackColor = true;
            // 
            // radioCreated
            // 
            this.radioCreated.AutoSize = true;
            this.radioCreated.Location = new System.Drawing.Point(112, 50);
            this.radioCreated.Name = "radioCreated";
            this.radioCreated.Size = new System.Drawing.Size(65, 16);
            this.radioCreated.TabIndex = 236;
            this.radioCreated.Text = "Created";
            this.radioCreated.UseVisualStyleBackColor = true;
            // 
            // radioAll
            // 
            this.radioAll.AutoSize = true;
            this.radioAll.Location = new System.Drawing.Point(204, 50);
            this.radioAll.Name = "radioAll";
            this.radioAll.Size = new System.Drawing.Size(41, 16);
            this.radioAll.TabIndex = 237;
            this.radioAll.Text = "All";
            this.radioAll.UseVisualStyleBackColor = true;
            // 
            // txtContainerNO
            // 
            this.txtContainerNO.Location = new System.Drawing.Point(568, 11);
            this.txtContainerNO.Name = "txtContainerNO";
            this.txtContainerNO.Size = new System.Drawing.Size(119, 20);
            this.txtContainerNO.TabIndex = 241;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(485, 15);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(77, 12);
            this.label1.TabIndex = 240;
            this.label1.Text = "Container NO";
            // 
            // FrmSEL_ImportPurBillVouch
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(925, 452);
            this.Controls.Add(this.txtContainerNO);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.radioAll);
            this.Controls.Add(this.radioCreated);
            this.Controls.Add(this.radioUnCreated);
            this.Controls.Add(this.gridControl1);
            this.Controls.Add(this.btnOK);
            this.Controls.Add(this.btnQuery);
            this.Controls.Add(this.dateEdit2);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.dateEdit1);
            this.Controls.Add(this.txtInvoiceNo);
            this.Controls.Add(this.label2);
            this.Name = "FrmSEL_ImportPurBillVouch";
            this.Text = "FrmSEL";
            this.Load += new System.EventHandler(this.FrmSEL_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dateEdit2.Properties.VistaTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dateEdit2.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dateEdit1.Properties.VistaTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dateEdit1.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtInvoiceNo.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtContainerNO.Properties)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraEditors.DateEdit dateEdit2;
        private System.Windows.Forms.Label label3;
        private DevExpress.XtraEditors.DateEdit dateEdit1;
        private DevExpress.XtraEditors.TextEdit txtInvoiceNo;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnQuery;
        private System.Windows.Forms.Button btnOK;
        private DevExpress.XtraGrid.GridControl gridControl1;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView1;
        private DevExpress.XtraGrid.Columns.GridColumn gridColbSelected;
        private DevExpress.XtraGrid.Columns.GridColumn gridColInvoiceNo;
        private DevExpress.XtraGrid.Columns.GridColumn gridColdDate;
        private System.Windows.Forms.RadioButton radioUnCreated;
        private System.Windows.Forms.RadioButton radioCreated;
        private System.Windows.Forms.RadioButton radioAll;
        private DevExpress.XtraEditors.TextEdit txtContainerNO;
        private System.Windows.Forms.Label label1;


    }
}