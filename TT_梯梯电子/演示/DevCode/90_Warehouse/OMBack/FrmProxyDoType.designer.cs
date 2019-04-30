namespace Warehouse
{
    partial class FrmProxyDoType
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
            this.label1 = new System.Windows.Forms.Label();
            this.rdbDoBack = new System.Windows.Forms.RadioButton();
            this.rdbChangeToBack = new System.Windows.Forms.RadioButton();
            this.grdDetail = new DevExpress.XtraGrid.GridControl();
            this.grvDetail = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colInvCode = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn3 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn1 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colVenCode = new DevExpress.XtraGrid.Columns.GridColumn();
            this.rpiVenSel = new DevExpress.XtraEditors.Repository.RepositoryItemButtonEdit();
            this.colVenName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.rpiProxyDoType = new DevExpress.XtraEditors.Repository.RepositoryItemButtonEdit();
            this.label2 = new System.Windows.Forms.Label();
            this.btnCanle = new System.Windows.Forms.Button();
            this.btnOK = new System.Windows.Forms.Button();
            this.btnLoadBom = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.grdDetail)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grvDetail)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.rpiVenSel)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.rpiProxyDoType)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(53, 12);
            this.label1.TabIndex = 0;
            this.label1.Text = "处理方案";
            // 
            // rdbDoBack
            // 
            this.rdbDoBack.AutoSize = true;
            this.rdbDoBack.Location = new System.Drawing.Point(87, 7);
            this.rdbDoBack.Name = "rdbDoBack";
            this.rdbDoBack.Size = new System.Drawing.Size(71, 16);
            this.rdbDoBack.TabIndex = 1;
            this.rdbDoBack.TabStop = true;
            this.rdbDoBack.Text = "直接退货";
            this.rdbDoBack.UseVisualStyleBackColor = true;
            this.rdbDoBack.CheckedChanged += new System.EventHandler(this.rdbDoBack_CheckedChanged);
            // 
            // rdbChangeToBack
            // 
            this.rdbChangeToBack.AutoSize = true;
            this.rdbChangeToBack.Location = new System.Drawing.Point(185, 7);
            this.rdbChangeToBack.Name = "rdbChangeToBack";
            this.rdbChangeToBack.Size = new System.Drawing.Size(107, 16);
            this.rdbChangeToBack.TabIndex = 3;
            this.rdbChangeToBack.TabStop = true;
            this.rdbChangeToBack.Text = "形态转换后退货";
            this.rdbChangeToBack.UseVisualStyleBackColor = true;
            this.rdbChangeToBack.CheckedChanged += new System.EventHandler(this.rdbChangeToBack_CheckedChanged);
            // 
            // grdDetail
            // 
            // 
            // 
            // 
            this.grdDetail.EmbeddedNavigator.Name = "";
            this.grdDetail.Location = new System.Drawing.Point(12, 47);
            this.grdDetail.MainView = this.grvDetail;
            this.grdDetail.Name = "grdDetail";
            this.grdDetail.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.rpiProxyDoType,
            this.rpiVenSel});
            this.grdDetail.Size = new System.Drawing.Size(732, 335);
            this.grdDetail.TabIndex = 14;
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
            this.colInvCode,
            this.gridColumn3,
            this.gridColumn1,
            this.colVenCode,
            this.colVenName});
            this.grvDetail.CustomizationFormBounds = new System.Drawing.Rectangle(1072, 422, 208, 175);
            this.grvDetail.GridControl = this.grdDetail;
            this.grvDetail.IndicatorWidth = 40;
            this.grvDetail.Name = "grvDetail";
            this.grvDetail.OptionsCustomization.AllowFilter = false;
            this.grvDetail.OptionsView.ColumnAutoWidth = false;
            this.grvDetail.OptionsView.EnableAppearanceEvenRow = true;
            this.grvDetail.OptionsView.EnableAppearanceOddRow = true;
            this.grvDetail.OptionsView.ShowFooter = true;
            this.grvDetail.OptionsView.ShowGroupPanel = false;
            this.grvDetail.DoubleClick += new System.EventHandler(this.grvDetail_DoubleClick);
            // 
            // colInvCode
            // 
            this.colInvCode.Caption = "存货编码";
            this.colInvCode.FieldName = "子件编码";
            this.colInvCode.Name = "colInvCode";
            this.colInvCode.OptionsColumn.AllowEdit = false;
            this.colInvCode.Visible = true;
            this.colInvCode.VisibleIndex = 0;
            this.colInvCode.Width = 121;
            // 
            // gridColumn3
            // 
            this.gridColumn3.Caption = "存货名称";
            this.gridColumn3.FieldName = "子件名称";
            this.gridColumn3.Name = "gridColumn3";
            this.gridColumn3.OptionsColumn.AllowEdit = false;
            this.gridColumn3.Visible = true;
            this.gridColumn3.VisibleIndex = 1;
            this.gridColumn3.Width = 148;
            // 
            // gridColumn1
            // 
            this.gridColumn1.Caption = "存货属性";
            this.gridColumn1.FieldName = "子件属性";
            this.gridColumn1.Name = "gridColumn1";
            this.gridColumn1.OptionsColumn.AllowEdit = false;
            this.gridColumn1.Visible = true;
            this.gridColumn1.VisibleIndex = 2;
            this.gridColumn1.Width = 163;
            // 
            // colVenCode
            // 
            this.colVenCode.Caption = "供应商编码";
            this.colVenCode.ColumnEdit = this.rpiVenSel;
            this.colVenCode.FieldName = "VenCode";
            this.colVenCode.Name = "colVenCode";
            this.colVenCode.Visible = true;
            this.colVenCode.VisibleIndex = 3;
            this.colVenCode.Width = 87;
            // 
            // rpiVenSel
            // 
            this.rpiVenSel.AutoHeight = false;
            this.rpiVenSel.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
            this.rpiVenSel.Name = "rpiVenSel";
            this.rpiVenSel.ButtonClick += new DevExpress.XtraEditors.Controls.ButtonPressedEventHandler(this.rpiVenSel_ButtonClick);
            // 
            // colVenName
            // 
            this.colVenName.Caption = "供应商名称";
            this.colVenName.FieldName = "VenName";
            this.colVenName.Name = "colVenName";
            this.colVenName.OptionsColumn.AllowEdit = false;
            this.colVenName.Visible = true;
            this.colVenName.VisibleIndex = 4;
            this.colVenName.Width = 144;
            // 
            // rpiProxyDoType
            // 
            this.rpiProxyDoType.AutoHeight = false;
            this.rpiProxyDoType.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
            this.rpiProxyDoType.Name = "rpiProxyDoType";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 32);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(89, 12);
            this.label2.TabIndex = 15;
            this.label2.Text = "转换后物料选项";
            // 
            // btnCanle
            // 
            this.btnCanle.Location = new System.Drawing.Point(669, 12);
            this.btnCanle.Name = "btnCanle";
            this.btnCanle.Size = new System.Drawing.Size(75, 23);
            this.btnCanle.TabIndex = 16;
            this.btnCanle.Text = "退出";
            this.btnCanle.UseVisualStyleBackColor = true;
            this.btnCanle.Click += new System.EventHandler(this.btnCanle_Click);
            // 
            // btnOK
            // 
            this.btnOK.Location = new System.Drawing.Point(588, 12);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(75, 23);
            this.btnOK.TabIndex = 17;
            this.btnOK.Text = "确定";
            this.btnOK.UseVisualStyleBackColor = true;
            this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
            // 
            // btnLoadBom
            // 
            this.btnLoadBom.Location = new System.Drawing.Point(298, 4);
            this.btnLoadBom.Name = "btnLoadBom";
            this.btnLoadBom.Size = new System.Drawing.Size(105, 23);
            this.btnLoadBom.TabIndex = 18;
            this.btnLoadBom.Text = "载入BOM结构";
            this.btnLoadBom.UseVisualStyleBackColor = true;
            this.btnLoadBom.Visible = false;
            this.btnLoadBom.Click += new System.EventHandler(this.btnLoadBom_Click);
            // 
            // FrmProxyDoType
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(756, 408);
            this.Controls.Add(this.btnLoadBom);
            this.Controls.Add(this.btnOK);
            this.Controls.Add(this.btnCanle);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.grdDetail);
            this.Controls.Add(this.rdbChangeToBack);
            this.Controls.Add(this.rdbDoBack);
            this.Controls.Add(this.label1);
            this.Name = "FrmProxyDoType";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "委外物料退货处理方案";
            this.Load += new System.EventHandler(this.FrmProxyDoType_Load);
            ((System.ComponentModel.ISupportInitialize)(this.grdDetail)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grvDetail)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.rpiVenSel)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.rpiProxyDoType)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.RadioButton rdbDoBack;
        private System.Windows.Forms.RadioButton rdbChangeToBack;
        private DevExpress.XtraGrid.GridControl grdDetail;
        private DevExpress.XtraGrid.Views.Grid.GridView grvDetail;
        private DevExpress.XtraGrid.Columns.GridColumn colInvCode;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn3;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn1;
        private DevExpress.XtraEditors.Repository.RepositoryItemButtonEdit rpiProxyDoType;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnCanle;
        private System.Windows.Forms.Button btnOK;
        private System.Windows.Forms.Button btnLoadBom;
        private DevExpress.XtraGrid.Columns.GridColumn colVenCode;
        private DevExpress.XtraGrid.Columns.GridColumn colVenName;
        private DevExpress.XtraEditors.Repository.RepositoryItemButtonEdit rpiVenSel;
    }
}