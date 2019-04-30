namespace UFIDA.U8.UAP.CustomApp.ControlForm
{
    partial class FrmRepSalebillvouchSEL
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
            this.gridColSalebillCode = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColdDate = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColProjectName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.ItemChk = new DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit();
            this.dateEdit2 = new DevExpress.XtraEditors.DateEdit();
            this.dateEdit1 = new DevExpress.XtraEditors.DateEdit();
            this.label2 = new System.Windows.Forms.Label();
            this.lookUpEditSaleBillCode1 = new DevExpress.XtraEditors.LookUpEdit();
            this.label4 = new System.Windows.Forms.Label();
            this.lookUpEditProName2 = new DevExpress.XtraEditors.LookUpEdit();
            this.lookUpEditProName1 = new DevExpress.XtraEditors.LookUpEdit();
            this.label1 = new System.Windows.Forms.Label();
            this.lookUpEditPartNO1 = new DevExpress.XtraEditors.LookUpEdit();
            this.label3 = new System.Windows.Forms.Label();
            this.lookUpEditSaleBillCode2 = new DevExpress.XtraEditors.LookUpEdit();
            this.lookUpEditPartNO2 = new DevExpress.XtraEditors.LookUpEdit();
            this.btnQuery = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnOK = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ItemChk)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dateEdit2.Properties.VistaTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dateEdit2.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dateEdit1.Properties.VistaTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dateEdit1.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lookUpEditSaleBillCode1.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lookUpEditProName2.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lookUpEditProName1.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lookUpEditPartNO1.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lookUpEditSaleBillCode2.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lookUpEditPartNO2.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // gridControl1
            // 
            this.gridControl1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.gridControl1.EmbeddedNavigator.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.gridControl1.Location = new System.Drawing.Point(2, 164);
            this.gridControl1.LookAndFeel.SkinName = "Office 2010 Blue";
            this.gridControl1.MainView = this.gridView1;
            this.gridControl1.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.gridControl1.Name = "gridControl1";
            this.gridControl1.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.ItemChk});
            this.gridControl1.Size = new System.Drawing.Size(1075, 302);
            this.gridControl1.TabIndex = 170;
            this.gridControl1.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView1});
            // 
            // gridView1
            // 
            this.gridView1.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.gridColSalebillCode,
            this.gridColdDate,
            this.gridColProjectName});
            this.gridView1.GridControl = this.gridControl1;
            this.gridView1.Name = "gridView1";
            this.gridView1.OptionsBehavior.Editable = false;
            this.gridView1.OptionsView.ColumnAutoWidth = false;
            this.gridView1.OptionsView.ShowGroupExpandCollapseButtons = false;
            this.gridView1.OptionsView.ShowGroupPanel = false;
            this.gridView1.DoubleClick += new System.EventHandler(this.gridView1_DoubleClick);
            // 
            // gridColSalebillCode
            // 
            this.gridColSalebillCode.Caption = "Salebill Code";
            this.gridColSalebillCode.FieldName = "SalebillCode";
            this.gridColSalebillCode.Name = "gridColSalebillCode";
            this.gridColSalebillCode.Visible = true;
            this.gridColSalebillCode.VisibleIndex = 0;
            this.gridColSalebillCode.Width = 146;
            // 
            // gridColdDate
            // 
            this.gridColdDate.Caption = "Date";
            this.gridColdDate.FieldName = "dDate";
            this.gridColdDate.Name = "gridColdDate";
            this.gridColdDate.Visible = true;
            this.gridColdDate.VisibleIndex = 1;
            // 
            // gridColProjectName
            // 
            this.gridColProjectName.Caption = "Project Name";
            this.gridColProjectName.FieldName = "ProjectName";
            this.gridColProjectName.Name = "gridColProjectName";
            this.gridColProjectName.Visible = true;
            this.gridColProjectName.VisibleIndex = 2;
            this.gridColProjectName.Width = 194;
            // 
            // ItemChk
            // 
            this.ItemChk.Name = "ItemChk";
            // 
            // dateEdit2
            // 
            this.dateEdit2.EditValue = null;
            this.dateEdit2.Location = new System.Drawing.Point(419, 50);
            this.dateEdit2.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.dateEdit2.Name = "dateEdit2";
            this.dateEdit2.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.dateEdit2.Properties.VistaTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
            this.dateEdit2.Size = new System.Drawing.Size(201, 28);
            this.dateEdit2.TabIndex = 173;
            // 
            // dateEdit1
            // 
            this.dateEdit1.EditValue = null;
            this.dateEdit1.Location = new System.Drawing.Point(199, 50);
            this.dateEdit1.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.dateEdit1.Name = "dateEdit1";
            this.dateEdit1.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.dateEdit1.Properties.VistaTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
            this.dateEdit1.Size = new System.Drawing.Size(201, 28);
            this.dateEdit1.TabIndex = 172;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(137, 56);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(44, 18);
            this.label2.TabIndex = 171;
            this.label2.Text = "Date";
            // 
            // lookUpEditSaleBillCode1
            // 
            this.lookUpEditSaleBillCode1.Location = new System.Drawing.Point(199, 17);
            this.lookUpEditSaleBillCode1.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.lookUpEditSaleBillCode1.Name = "lookUpEditSaleBillCode1";
            this.lookUpEditSaleBillCode1.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.lookUpEditSaleBillCode1.Properties.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("cSBVCode", "Salebillvouch No")});
            this.lookUpEditSaleBillCode1.Properties.DisplayMember = "cSBVCode";
            this.lookUpEditSaleBillCode1.Properties.NullText = "";
            this.lookUpEditSaleBillCode1.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.Standard;
            this.lookUpEditSaleBillCode1.Properties.ValueMember = "cSBVCode";
            this.lookUpEditSaleBillCode1.Size = new System.Drawing.Size(201, 28);
            this.lookUpEditSaleBillCode1.TabIndex = 184;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.ForeColor = System.Drawing.Color.Black;
            this.label4.Location = new System.Drawing.Point(29, 20);
            this.label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(152, 18);
            this.label4.TabIndex = 183;
            this.label4.Text = "Salebillvouch NO";
            // 
            // lookUpEditProName2
            // 
            this.lookUpEditProName2.Location = new System.Drawing.Point(419, 88);
            this.lookUpEditProName2.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.lookUpEditProName2.Name = "lookUpEditProName2";
            this.lookUpEditProName2.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.lookUpEditProName2.Properties.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("ProjectName", "Project Name")});
            this.lookUpEditProName2.Properties.DisplayMember = "ProjectName";
            this.lookUpEditProName2.Properties.NullText = "";
            this.lookUpEditProName2.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.Standard;
            this.lookUpEditProName2.Properties.ValueMember = "ProjectName";
            this.lookUpEditProName2.Size = new System.Drawing.Size(201, 28);
            this.lookUpEditProName2.TabIndex = 188;
            // 
            // lookUpEditProName1
            // 
            this.lookUpEditProName1.Location = new System.Drawing.Point(199, 88);
            this.lookUpEditProName1.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.lookUpEditProName1.Name = "lookUpEditProName1";
            this.lookUpEditProName1.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.lookUpEditProName1.Properties.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("ProjectName", "Project Name")});
            this.lookUpEditProName1.Properties.DisplayMember = "ProjectName";
            this.lookUpEditProName1.Properties.NullText = "";
            this.lookUpEditProName1.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.Standard;
            this.lookUpEditProName1.Properties.ValueMember = "ProjectName";
            this.lookUpEditProName1.Size = new System.Drawing.Size(201, 28);
            this.lookUpEditProName1.TabIndex = 187;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.ForeColor = System.Drawing.Color.Black;
            this.label1.Location = new System.Drawing.Point(65, 94);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(116, 18);
            this.label1.TabIndex = 186;
            this.label1.Text = "Project Name";
            // 
            // lookUpEditPartNO1
            // 
            this.lookUpEditPartNO1.Location = new System.Drawing.Point(199, 125);
            this.lookUpEditPartNO1.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.lookUpEditPartNO1.Name = "lookUpEditPartNO1";
            this.lookUpEditPartNO1.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.lookUpEditPartNO1.Properties.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("cCusInvCode", "Part No")});
            this.lookUpEditPartNO1.Properties.DisplayMember = "cCusInvCode";
            this.lookUpEditPartNO1.Properties.NullText = "";
            this.lookUpEditPartNO1.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.Standard;
            this.lookUpEditPartNO1.Properties.ValueMember = "cCusInvCode";
            this.lookUpEditPartNO1.Size = new System.Drawing.Size(201, 28);
            this.lookUpEditPartNO1.TabIndex = 190;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.ForeColor = System.Drawing.Color.Black;
            this.label3.Location = new System.Drawing.Point(110, 130);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(71, 18);
            this.label3.TabIndex = 189;
            this.label3.Text = "Part NO";
            // 
            // lookUpEditSaleBillCode2
            // 
            this.lookUpEditSaleBillCode2.Location = new System.Drawing.Point(419, 17);
            this.lookUpEditSaleBillCode2.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.lookUpEditSaleBillCode2.Name = "lookUpEditSaleBillCode2";
            this.lookUpEditSaleBillCode2.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.lookUpEditSaleBillCode2.Properties.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("cSBVCode", "Salebillvouch No")});
            this.lookUpEditSaleBillCode2.Properties.DisplayMember = "cSBVCode";
            this.lookUpEditSaleBillCode2.Properties.NullText = "";
            this.lookUpEditSaleBillCode2.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.Standard;
            this.lookUpEditSaleBillCode2.Properties.ValueMember = "cSBVCode";
            this.lookUpEditSaleBillCode2.Size = new System.Drawing.Size(201, 28);
            this.lookUpEditSaleBillCode2.TabIndex = 192;
            // 
            // lookUpEditPartNO2
            // 
            this.lookUpEditPartNO2.Location = new System.Drawing.Point(419, 125);
            this.lookUpEditPartNO2.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.lookUpEditPartNO2.Name = "lookUpEditPartNO2";
            this.lookUpEditPartNO2.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.lookUpEditPartNO2.Properties.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("cCusInvCode", "Part No")});
            this.lookUpEditPartNO2.Properties.DisplayMember = "cCusInvCode";
            this.lookUpEditPartNO2.Properties.NullText = "";
            this.lookUpEditPartNO2.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.Standard;
            this.lookUpEditPartNO2.Properties.ValueMember = "cCusInvCode";
            this.lookUpEditPartNO2.Size = new System.Drawing.Size(201, 28);
            this.lookUpEditPartNO2.TabIndex = 193;
            // 
            // btnQuery
            // 
            this.btnQuery.Location = new System.Drawing.Point(649, 113);
            this.btnQuery.Name = "btnQuery";
            this.btnQuery.Size = new System.Drawing.Size(94, 42);
            this.btnQuery.TabIndex = 194;
            this.btnQuery.Text = "Query";
            this.btnQuery.UseVisualStyleBackColor = true;
            this.btnQuery.Click += new System.EventHandler(this.btnQuery_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(877, 114);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(94, 42);
            this.btnCancel.TabIndex = 195;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // btnOK
            // 
            this.btnOK.Location = new System.Drawing.Point(763, 114);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(94, 42);
            this.btnOK.TabIndex = 196;
            this.btnOK.Text = "OK";
            this.btnOK.UseVisualStyleBackColor = true;
            this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
            // 
            // FrmRepSalebillvouchSEL
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 18F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1075, 464);
            this.Controls.Add(this.btnOK);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnQuery);
            this.Controls.Add(this.lookUpEditPartNO2);
            this.Controls.Add(this.lookUpEditSaleBillCode2);
            this.Controls.Add(this.lookUpEditPartNO1);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.lookUpEditProName2);
            this.Controls.Add(this.lookUpEditProName1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.lookUpEditSaleBillCode1);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.dateEdit2);
            this.Controls.Add(this.dateEdit1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.gridControl1);
            this.Name = "FrmRepSalebillvouchSEL";
            this.Text = "Query";
            this.Load += new System.EventHandler(this.FrmRepSalebillvouchSEL_Load);
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ItemChk)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dateEdit2.Properties.VistaTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dateEdit2.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dateEdit1.Properties.VistaTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dateEdit1.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lookUpEditSaleBillCode1.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lookUpEditProName2.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lookUpEditProName1.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lookUpEditPartNO1.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lookUpEditSaleBillCode2.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lookUpEditPartNO2.Properties)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraGrid.GridControl gridControl1;
        private DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit ItemChk;
        private DevExpress.XtraEditors.DateEdit dateEdit2;
        private DevExpress.XtraEditors.DateEdit dateEdit1;
        private System.Windows.Forms.Label label2;
        private DevExpress.XtraEditors.LookUpEdit lookUpEditSaleBillCode1;
        private System.Windows.Forms.Label label4;
        private DevExpress.XtraEditors.LookUpEdit lookUpEditProName2;
        private DevExpress.XtraEditors.LookUpEdit lookUpEditProName1;
        private System.Windows.Forms.Label label1;
        private DevExpress.XtraEditors.LookUpEdit lookUpEditPartNO1;
        private System.Windows.Forms.Label label3;
        private DevExpress.XtraEditors.LookUpEdit lookUpEditSaleBillCode2;
        private DevExpress.XtraEditors.LookUpEdit lookUpEditPartNO2;
        private System.Windows.Forms.Button btnQuery;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Button btnOK;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView1;
        private DevExpress.XtraGrid.Columns.GridColumn gridColSalebillCode;
        private DevExpress.XtraGrid.Columns.GridColumn gridColdDate;
        private DevExpress.XtraGrid.Columns.GridColumn gridColProjectName;
    }
}