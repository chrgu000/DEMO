namespace 工程
{
    partial class Frm出库单_Add
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
            this.btnExit = new System.Windows.Forms.Button();
            this.layoutControlGroup1 = new DevExpress.XtraLayout.LayoutControlGroup();
            this.layoutControlItem6 = new DevExpress.XtraLayout.LayoutControlItem();
            this.lookUpEdit单据号1 = new DevExpress.XtraEditors.LookUpEdit();
            this.layoutControl1 = new DevExpress.XtraLayout.LayoutControl();
            this.lookUpEdit物料2 = new DevExpress.XtraEditors.LookUpEdit();
            this.lookUpEdit物料1 = new DevExpress.XtraEditors.LookUpEdit();
            this.buttonEdit物料2 = new DevExpress.XtraEditors.ButtonEdit();
            this.buttonEdit物料1 = new DevExpress.XtraEditors.ButtonEdit();
            this.dateEdit单据日期1 = new DevExpress.XtraEditors.DateEdit();
            this.dateEdit单据日期2 = new DevExpress.XtraEditors.DateEdit();
            this.lookUpEdit单据号2 = new DevExpress.XtraEditors.LookUpEdit();
            this.layoutControlItem1 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem3 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem2 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem11 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem12 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem23 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem26 = new DevExpress.XtraLayout.LayoutControlItem();
            this.btnEnsure = new System.Windows.Forms.Button();
            this.buttonClear = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem6)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lookUpEdit单据号1.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControl1)).BeginInit();
            this.layoutControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.lookUpEdit物料2.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lookUpEdit物料1.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.buttonEdit物料2.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.buttonEdit物料1.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dateEdit单据日期1.Properties.VistaTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dateEdit单据日期1.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dateEdit单据日期2.Properties.VistaTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dateEdit单据日期2.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lookUpEdit单据号2.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem11)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem12)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem23)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem26)).BeginInit();
            this.SuspendLayout();
            // 
            // btnExit
            // 
            this.btnExit.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnExit.Location = new System.Drawing.Point(398, 173);
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size(62, 23);
            this.btnExit.TabIndex = 2;
            this.btnExit.Text = "退 出";
            this.btnExit.UseVisualStyleBackColor = true;
            this.btnExit.Click += new System.EventHandler(this.btnExit_Click);
            // 
            // layoutControlGroup1
            // 
            this.layoutControlGroup1.CustomizationFormText = "layoutControlGroup1";
            this.layoutControlGroup1.EnableIndentsWithoutBorders = DevExpress.Utils.DefaultBoolean.True;
            this.layoutControlGroup1.GroupBordersVisible = false;
            this.layoutControlGroup1.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.layoutControlItem6,
            this.layoutControlItem1,
            this.layoutControlItem3,
            this.layoutControlItem2,
            this.layoutControlItem11,
            this.layoutControlItem12,
            this.layoutControlItem23,
            this.layoutControlItem26});
            this.layoutControlGroup1.Location = new System.Drawing.Point(0, 0);
            this.layoutControlGroup1.Name = "Root";
            this.layoutControlGroup1.Size = new System.Drawing.Size(495, 158);
            this.layoutControlGroup1.Text = "Root";
            this.layoutControlGroup1.TextVisible = false;
            // 
            // layoutControlItem6
            // 
            this.layoutControlItem6.Control = this.lookUpEdit单据号1;
            this.layoutControlItem6.CustomizationFormText = "销售订单号";
            this.layoutControlItem6.Location = new System.Drawing.Point(0, 0);
            this.layoutControlItem6.Name = "layoutControlItem6";
            this.layoutControlItem6.Size = new System.Drawing.Size(239, 24);
            this.layoutControlItem6.Text = "单据号";
            this.layoutControlItem6.TextSize = new System.Drawing.Size(48, 14);
            // 
            // lookUpEdit单据号1
            // 
            this.lookUpEdit单据号1.Location = new System.Drawing.Point(64, 12);
            this.lookUpEdit单据号1.Name = "lookUpEdit单据号1";
            this.lookUpEdit单据号1.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.lookUpEdit单据号1.Properties.DisplayMember = "cPOCCode";
            this.lookUpEdit单据号1.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.Standard;
            this.lookUpEdit单据号1.Properties.ValueMember = "cPOCCode";
            this.lookUpEdit单据号1.Size = new System.Drawing.Size(183, 20);
            this.lookUpEdit单据号1.StyleController = this.layoutControl1;
            this.lookUpEdit单据号1.TabIndex = 9;
            // 
            // layoutControl1
            // 
            this.layoutControl1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.layoutControl1.Controls.Add(this.lookUpEdit物料2);
            this.layoutControl1.Controls.Add(this.lookUpEdit物料1);
            this.layoutControl1.Controls.Add(this.buttonEdit物料2);
            this.layoutControl1.Controls.Add(this.buttonEdit物料1);
            this.layoutControl1.Controls.Add(this.dateEdit单据日期1);
            this.layoutControl1.Controls.Add(this.dateEdit单据日期2);
            this.layoutControl1.Controls.Add(this.lookUpEdit单据号2);
            this.layoutControl1.Controls.Add(this.lookUpEdit单据号1);
            this.layoutControl1.Location = new System.Drawing.Point(-3, 12);
            this.layoutControl1.Name = "layoutControl1";
            this.layoutControl1.OptionsCustomizationForm.DesignTimeCustomizationFormPositionAndSize = new System.Drawing.Rectangle(427, 194, 250, 350);
            this.layoutControl1.OptionsView.UseDefaultDragAndDropRendering = false;
            this.layoutControl1.Root = this.layoutControlGroup1;
            this.layoutControl1.Size = new System.Drawing.Size(495, 158);
            this.layoutControl1.TabIndex = 0;
            this.layoutControl1.Text = "layoutControl1";
            // 
            // lookUpEdit物料2
            // 
            this.lookUpEdit物料2.Enabled = false;
            this.lookUpEdit物料2.Location = new System.Drawing.Point(369, 60);
            this.lookUpEdit物料2.Name = "lookUpEdit物料2";
            this.lookUpEdit物料2.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.lookUpEdit物料2.Size = new System.Drawing.Size(114, 20);
            this.lookUpEdit物料2.StyleController = this.layoutControl1;
            this.lookUpEdit物料2.TabIndex = 42;
            // 
            // lookUpEdit物料1
            // 
            this.lookUpEdit物料1.Enabled = false;
            this.lookUpEdit物料1.Location = new System.Drawing.Point(155, 60);
            this.lookUpEdit物料1.Name = "lookUpEdit物料1";
            this.lookUpEdit物料1.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.lookUpEdit物料1.Size = new System.Drawing.Size(92, 20);
            this.lookUpEdit物料1.StyleController = this.layoutControl1;
            this.lookUpEdit物料1.TabIndex = 39;
            // 
            // buttonEdit物料2
            // 
            this.buttonEdit物料2.Location = new System.Drawing.Point(303, 60);
            this.buttonEdit物料2.Name = "buttonEdit物料2";
            this.buttonEdit物料2.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
            this.buttonEdit物料2.Size = new System.Drawing.Size(62, 20);
            this.buttonEdit物料2.StyleController = this.layoutControl1;
            this.buttonEdit物料2.TabIndex = 34;
            this.buttonEdit物料2.ButtonClick += new DevExpress.XtraEditors.Controls.ButtonPressedEventHandler(this.buttonEdit物料2_ButtonClick);
            this.buttonEdit物料2.EditValueChanged += new System.EventHandler(this.buttonEdit物料2_EditValueChanged);
            this.buttonEdit物料2.Leave += new System.EventHandler(this.buttonEdit物料2_Leave);
            // 
            // buttonEdit物料1
            // 
            this.buttonEdit物料1.Location = new System.Drawing.Point(64, 60);
            this.buttonEdit物料1.Name = "buttonEdit物料1";
            this.buttonEdit物料1.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
            this.buttonEdit物料1.Size = new System.Drawing.Size(87, 20);
            this.buttonEdit物料1.StyleController = this.layoutControl1;
            this.buttonEdit物料1.TabIndex = 33;
            this.buttonEdit物料1.ButtonClick += new DevExpress.XtraEditors.Controls.ButtonPressedEventHandler(this.buttonEdit物料1_ButtonClick);
            this.buttonEdit物料1.EditValueChanged += new System.EventHandler(this.buttonEdit物料1_EditValueChanged);
            this.buttonEdit物料1.Leave += new System.EventHandler(this.buttonEdit物料1_Leave);
            // 
            // dateEdit单据日期1
            // 
            this.dateEdit单据日期1.EditValue = null;
            this.dateEdit单据日期1.Location = new System.Drawing.Point(64, 36);
            this.dateEdit单据日期1.Name = "dateEdit单据日期1";
            this.dateEdit单据日期1.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.dateEdit单据日期1.Properties.VistaTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
            this.dateEdit单据日期1.Size = new System.Drawing.Size(183, 20);
            this.dateEdit单据日期1.StyleController = this.layoutControl1;
            this.dateEdit单据日期1.TabIndex = 12;
            // 
            // dateEdit单据日期2
            // 
            this.dateEdit单据日期2.EditValue = null;
            this.dateEdit单据日期2.Location = new System.Drawing.Point(303, 36);
            this.dateEdit单据日期2.Name = "dateEdit单据日期2";
            this.dateEdit单据日期2.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.dateEdit单据日期2.Properties.VistaTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
            this.dateEdit单据日期2.Size = new System.Drawing.Size(180, 20);
            this.dateEdit单据日期2.StyleController = this.layoutControl1;
            this.dateEdit单据日期2.TabIndex = 11;
            // 
            // lookUpEdit单据号2
            // 
            this.lookUpEdit单据号2.Location = new System.Drawing.Point(303, 12);
            this.lookUpEdit单据号2.Name = "lookUpEdit单据号2";
            this.lookUpEdit单据号2.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.lookUpEdit单据号2.Properties.DisplayMember = "cPOCCode";
            this.lookUpEdit单据号2.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.Standard;
            this.lookUpEdit单据号2.Properties.ValueMember = "cPOCCode";
            this.lookUpEdit单据号2.Size = new System.Drawing.Size(180, 20);
            this.lookUpEdit单据号2.StyleController = this.layoutControl1;
            this.lookUpEdit单据号2.TabIndex = 10;
            // 
            // layoutControlItem1
            // 
            this.layoutControlItem1.Control = this.lookUpEdit单据号2;
            this.layoutControlItem1.CustomizationFormText = "材料入库单号";
            this.layoutControlItem1.Location = new System.Drawing.Point(239, 0);
            this.layoutControlItem1.Name = "layoutControlItem1";
            this.layoutControlItem1.Size = new System.Drawing.Size(236, 24);
            this.layoutControlItem1.Text = "至";
            this.layoutControlItem1.TextSize = new System.Drawing.Size(48, 14);
            // 
            // layoutControlItem3
            // 
            this.layoutControlItem3.Control = this.dateEdit单据日期1;
            this.layoutControlItem3.CustomizationFormText = "入库日期";
            this.layoutControlItem3.Location = new System.Drawing.Point(0, 24);
            this.layoutControlItem3.Name = "layoutControlItem3";
            this.layoutControlItem3.Size = new System.Drawing.Size(239, 24);
            this.layoutControlItem3.Text = "单据日期";
            this.layoutControlItem3.TextSize = new System.Drawing.Size(48, 14);
            // 
            // layoutControlItem2
            // 
            this.layoutControlItem2.Control = this.dateEdit单据日期2;
            this.layoutControlItem2.CustomizationFormText = "入库日期";
            this.layoutControlItem2.Location = new System.Drawing.Point(239, 24);
            this.layoutControlItem2.Name = "layoutControlItem2";
            this.layoutControlItem2.Size = new System.Drawing.Size(236, 24);
            this.layoutControlItem2.Text = "至";
            this.layoutControlItem2.TextSize = new System.Drawing.Size(48, 14);
            // 
            // layoutControlItem11
            // 
            this.layoutControlItem11.Control = this.buttonEdit物料1;
            this.layoutControlItem11.CustomizationFormText = "物料编码";
            this.layoutControlItem11.Location = new System.Drawing.Point(0, 48);
            this.layoutControlItem11.Name = "layoutControlItem11";
            this.layoutControlItem11.Size = new System.Drawing.Size(143, 90);
            this.layoutControlItem11.Text = "存货编码";
            this.layoutControlItem11.TextSize = new System.Drawing.Size(48, 14);
            // 
            // layoutControlItem12
            // 
            this.layoutControlItem12.Control = this.buttonEdit物料2;
            this.layoutControlItem12.CustomizationFormText = "至";
            this.layoutControlItem12.Location = new System.Drawing.Point(239, 48);
            this.layoutControlItem12.Name = "layoutControlItem12";
            this.layoutControlItem12.Size = new System.Drawing.Size(118, 90);
            this.layoutControlItem12.Text = "至";
            this.layoutControlItem12.TextSize = new System.Drawing.Size(48, 14);
            // 
            // layoutControlItem23
            // 
            this.layoutControlItem23.Control = this.lookUpEdit物料1;
            this.layoutControlItem23.CustomizationFormText = "layoutControlItem23";
            this.layoutControlItem23.Location = new System.Drawing.Point(143, 48);
            this.layoutControlItem23.Name = "layoutControlItem23";
            this.layoutControlItem23.Size = new System.Drawing.Size(96, 90);
            this.layoutControlItem23.Text = "layoutControlItem23";
            this.layoutControlItem23.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem23.TextToControlDistance = 0;
            this.layoutControlItem23.TextVisible = false;
            // 
            // layoutControlItem26
            // 
            this.layoutControlItem26.Control = this.lookUpEdit物料2;
            this.layoutControlItem26.CustomizationFormText = "layoutControlItem26";
            this.layoutControlItem26.Location = new System.Drawing.Point(357, 48);
            this.layoutControlItem26.Name = "layoutControlItem26";
            this.layoutControlItem26.Size = new System.Drawing.Size(118, 90);
            this.layoutControlItem26.Text = "layoutControlItem26";
            this.layoutControlItem26.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem26.TextToControlDistance = 0;
            this.layoutControlItem26.TextVisible = false;
            // 
            // btnEnsure
            // 
            this.btnEnsure.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnEnsure.Location = new System.Drawing.Point(242, 173);
            this.btnEnsure.Name = "btnEnsure";
            this.btnEnsure.Size = new System.Drawing.Size(62, 23);
            this.btnEnsure.TabIndex = 3;
            this.btnEnsure.Text = "确 定";
            this.btnEnsure.UseVisualStyleBackColor = true;
            this.btnEnsure.Click += new System.EventHandler(this.btnEnsure_Click);
            // 
            // buttonClear
            // 
            this.buttonClear.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonClear.Location = new System.Drawing.Point(321, 173);
            this.buttonClear.Name = "buttonClear";
            this.buttonClear.Size = new System.Drawing.Size(62, 23);
            this.buttonClear.TabIndex = 4;
            this.buttonClear.Text = "清 除";
            this.buttonClear.UseVisualStyleBackColor = true;
            this.buttonClear.Click += new System.EventHandler(this.buttonClear_Click);
            // 
            // Frm出库单_Add
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(489, 208);
            this.Controls.Add(this.buttonClear);
            this.Controls.Add(this.btnEnsure);
            this.Controls.Add(this.btnExit);
            this.Controls.Add(this.layoutControl1);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Frm出库单_Add";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "参照";
            this.Load += new System.EventHandler(this.Frm出库单_Add_Load);
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem6)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lookUpEdit单据号1.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControl1)).EndInit();
            this.layoutControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.lookUpEdit物料2.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lookUpEdit物料1.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.buttonEdit物料2.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.buttonEdit物料1.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dateEdit单据日期1.Properties.VistaTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dateEdit单据日期1.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dateEdit单据日期2.Properties.VistaTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dateEdit单据日期2.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lookUpEdit单据号2.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem11)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem12)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem23)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem26)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnExit;
        private DevExpress.XtraLayout.LayoutControlGroup layoutControlGroup1;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem6;
        private DevExpress.XtraEditors.LookUpEdit lookUpEdit单据号1;
        private DevExpress.XtraLayout.LayoutControl layoutControl1;
        private System.Windows.Forms.Button btnEnsure;
        private DevExpress.XtraEditors.LookUpEdit lookUpEdit单据号2;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem1;
        private DevExpress.XtraEditors.DateEdit dateEdit单据日期1;
        private DevExpress.XtraEditors.DateEdit dateEdit单据日期2;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem3;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem2;
        private System.Windows.Forms.Button buttonClear;
        private DevExpress.XtraEditors.ButtonEdit buttonEdit物料2;
        private DevExpress.XtraEditors.ButtonEdit buttonEdit物料1;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem11;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem12;
        private DevExpress.XtraEditors.LookUpEdit lookUpEdit物料2;
        private DevExpress.XtraEditors.LookUpEdit lookUpEdit物料1;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem23;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem26;
    }
}