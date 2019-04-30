namespace clsU8
{
    partial class Frm销售订单导出
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
            this.ItemLookUpEditcInvCode = new DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit();
            this.ItemLookUpEditcInvName = new DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit();
            this.ItemLookUpEditcInvStd = new DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit();
            this.ItemLookUpEditcDepCode = new DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit();
            this.ItemLookUpEditcDepName = new DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit();
            this.ItemLookUpEditcCusCode = new DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit();
            this.ItemLookUpEditcCustName = new DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit();
            this.ItemLookUpEditcSTCode = new DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit();
            this.ItemLookUpEditcSTName = new DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ItemLookUpEditcInvCode)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ItemLookUpEditcInvName)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ItemLookUpEditcInvStd)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ItemLookUpEditcDepCode)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ItemLookUpEditcDepName)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ItemLookUpEditcCusCode)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ItemLookUpEditcCustName)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ItemLookUpEditcSTCode)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ItemLookUpEditcSTName)).BeginInit();
            this.SuspendLayout();
            // 
            // gridControl1
            // 
            this.gridControl1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.gridControl1.Location = new System.Drawing.Point(0, 3);
            this.gridControl1.LookAndFeel.SkinName = "Office 2010 Blue";
            this.gridControl1.MainView = this.gridView1;
            this.gridControl1.Name = "gridControl1";
            this.gridControl1.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.ItemLookUpEditcInvCode,
            this.ItemLookUpEditcInvName,
            this.ItemLookUpEditcInvStd,
            this.ItemLookUpEditcDepCode,
            this.ItemLookUpEditcDepName,
            this.ItemLookUpEditcCusCode,
            this.ItemLookUpEditcCustName,
            this.ItemLookUpEditcSTCode,
            this.ItemLookUpEditcSTName});
            this.gridControl1.Size = new System.Drawing.Size(679, 401);
            this.gridControl1.TabIndex = 192;
            this.gridControl1.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView1});
            // 
            // gridView1
            // 
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
            // 
            // ItemLookUpEditcInvCode
            // 
            this.ItemLookUpEditcInvCode.AutoHeight = false;
            this.ItemLookUpEditcInvCode.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.ItemLookUpEditcInvCode.DisplayMember = "cInvCode";
            this.ItemLookUpEditcInvCode.Name = "ItemLookUpEditcInvCode";
            this.ItemLookUpEditcInvCode.NullText = "";
            this.ItemLookUpEditcInvCode.ValueMember = "cInvCode";
            // 
            // ItemLookUpEditcInvName
            // 
            this.ItemLookUpEditcInvName.AutoHeight = false;
            this.ItemLookUpEditcInvName.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.ItemLookUpEditcInvName.DisplayMember = "cInvName";
            this.ItemLookUpEditcInvName.Name = "ItemLookUpEditcInvName";
            this.ItemLookUpEditcInvName.NullText = "";
            this.ItemLookUpEditcInvName.ValueMember = "cInvCode";
            // 
            // ItemLookUpEditcInvStd
            // 
            this.ItemLookUpEditcInvStd.AutoHeight = false;
            this.ItemLookUpEditcInvStd.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.ItemLookUpEditcInvStd.DisplayMember = "cInvSTd";
            this.ItemLookUpEditcInvStd.Name = "ItemLookUpEditcInvStd";
            this.ItemLookUpEditcInvStd.NullText = "";
            this.ItemLookUpEditcInvStd.ValueMember = "cInvCode";
            // 
            // ItemLookUpEditcDepCode
            // 
            this.ItemLookUpEditcDepCode.AutoHeight = false;
            this.ItemLookUpEditcDepCode.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.ItemLookUpEditcDepCode.DisplayMember = "cDepCode";
            this.ItemLookUpEditcDepCode.Name = "ItemLookUpEditcDepCode";
            this.ItemLookUpEditcDepCode.NullText = "";
            this.ItemLookUpEditcDepCode.ValueMember = "cDepCode";
            // 
            // ItemLookUpEditcDepName
            // 
            this.ItemLookUpEditcDepName.AutoHeight = false;
            this.ItemLookUpEditcDepName.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.ItemLookUpEditcDepName.DisplayMember = "cDepName";
            this.ItemLookUpEditcDepName.Name = "ItemLookUpEditcDepName";
            this.ItemLookUpEditcDepName.NullText = "";
            this.ItemLookUpEditcDepName.ValueMember = "cDepCode";
            // 
            // ItemLookUpEditcCusCode
            // 
            this.ItemLookUpEditcCusCode.AutoHeight = false;
            this.ItemLookUpEditcCusCode.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.ItemLookUpEditcCusCode.DisplayMember = "cCusCode";
            this.ItemLookUpEditcCusCode.Name = "ItemLookUpEditcCusCode";
            this.ItemLookUpEditcCusCode.NullText = "";
            this.ItemLookUpEditcCusCode.ValueMember = "cCusCode";
            // 
            // ItemLookUpEditcCustName
            // 
            this.ItemLookUpEditcCustName.AutoHeight = false;
            this.ItemLookUpEditcCustName.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.ItemLookUpEditcCustName.DisplayMember = "cCusName";
            this.ItemLookUpEditcCustName.Name = "ItemLookUpEditcCustName";
            this.ItemLookUpEditcCustName.NullText = "";
            this.ItemLookUpEditcCustName.ValueMember = "cCusCode";
            // 
            // ItemLookUpEditcSTCode
            // 
            this.ItemLookUpEditcSTCode.AutoHeight = false;
            this.ItemLookUpEditcSTCode.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.ItemLookUpEditcSTCode.DisplayMember = "cSTCode";
            this.ItemLookUpEditcSTCode.Name = "ItemLookUpEditcSTCode";
            this.ItemLookUpEditcSTCode.NullText = "";
            this.ItemLookUpEditcSTCode.ValueMember = "cSTCode";
            // 
            // ItemLookUpEditcSTName
            // 
            this.ItemLookUpEditcSTName.AutoHeight = false;
            this.ItemLookUpEditcSTName.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.ItemLookUpEditcSTName.DisplayMember = "cSTName";
            this.ItemLookUpEditcSTName.Name = "ItemLookUpEditcSTName";
            this.ItemLookUpEditcSTName.NullText = "";
            this.ItemLookUpEditcSTName.ValueMember = "cSTCode";
            // 
            // Frm销售订单导出
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.ClientSize = new System.Drawing.Size(679, 404);
            this.Controls.Add(this.gridControl1);
            this.Name = "Frm销售订单导出";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "ExportSale";
            this.Load += new System.EventHandler(this.Frm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ItemLookUpEditcInvCode)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ItemLookUpEditcInvName)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ItemLookUpEditcInvStd)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ItemLookUpEditcDepCode)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ItemLookUpEditcDepName)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ItemLookUpEditcCusCode)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ItemLookUpEditcCustName)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ItemLookUpEditcSTCode)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ItemLookUpEditcSTName)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraGrid.GridControl gridControl1;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView1;
        private DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit ItemLookUpEditcInvCode;
        private DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit ItemLookUpEditcInvName;
        private DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit ItemLookUpEditcInvStd;
        private DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit ItemLookUpEditcDepCode;
        private DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit ItemLookUpEditcDepName;
        private DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit ItemLookUpEditcCusCode;
        private DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit ItemLookUpEditcCustName;
        private DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit ItemLookUpEditcSTName;
        private DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit ItemLookUpEditcSTCode;

    }
}