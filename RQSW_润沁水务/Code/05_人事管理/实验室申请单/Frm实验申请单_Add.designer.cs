﻿namespace 人事管理
{
    partial class Frm实验申请单_Add
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
            this.lookUpEditiCode1 = new DevExpress.XtraEditors.LookUpEdit();
            this.layoutControl1 = new DevExpress.XtraLayout.LayoutControl();
            this.textEdit单位名称 = new DevExpress.XtraEditors.TextEdit();
            this.lookUpEdit销售人员 = new DevExpress.XtraEditors.LookUpEdit();
            this.buttonEdit销售人员 = new DevExpress.XtraEditors.ButtonEdit();
            this.dateEditdDate1 = new DevExpress.XtraEditors.DateEdit();
            this.dateEditdDate2 = new DevExpress.XtraEditors.DateEdit();
            this.lookUpEditiCode2 = new DevExpress.XtraEditors.LookUpEdit();
            this.layoutControlItem1 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem3 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem2 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem4 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem10 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem5 = new DevExpress.XtraLayout.LayoutControlItem();
            this.btnEnsure = new System.Windows.Forms.Button();
            this.buttonClear = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem6)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lookUpEditiCode1.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControl1)).BeginInit();
            this.layoutControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.textEdit单位名称.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lookUpEdit销售人员.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.buttonEdit销售人员.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dateEditdDate1.Properties.VistaTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dateEditdDate1.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dateEditdDate2.Properties.VistaTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dateEditdDate2.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lookUpEditiCode2.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem10)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem5)).BeginInit();
            this.SuspendLayout();
            // 
            // btnExit
            // 
            this.btnExit.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnExit.Location = new System.Drawing.Point(390, 208);
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
            this.layoutControlItem4,
            this.layoutControlItem10,
            this.layoutControlItem5});
            this.layoutControlGroup1.Location = new System.Drawing.Point(0, 0);
            this.layoutControlGroup1.Name = "Root";
            this.layoutControlGroup1.Size = new System.Drawing.Size(487, 193);
            this.layoutControlGroup1.Text = "Root";
            this.layoutControlGroup1.TextVisible = false;
            // 
            // layoutControlItem6
            // 
            this.layoutControlItem6.Control = this.lookUpEditiCode1;
            this.layoutControlItem6.CustomizationFormText = "销售订单号";
            this.layoutControlItem6.Location = new System.Drawing.Point(0, 0);
            this.layoutControlItem6.Name = "layoutControlItem6";
            this.layoutControlItem6.Size = new System.Drawing.Size(225, 25);
            this.layoutControlItem6.Text = "单据号";
            this.layoutControlItem6.TextSize = new System.Drawing.Size(48, 14);
            // 
            // lookUpEditiCode1
            // 
            this.lookUpEditiCode1.Location = new System.Drawing.Point(64, 12);
            this.lookUpEditiCode1.Name = "lookUpEditiCode1";
            this.lookUpEditiCode1.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.lookUpEditiCode1.Properties.DisplayMember = "iCode";
            this.lookUpEditiCode1.Properties.NullText = "";
            this.lookUpEditiCode1.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.Standard;
            this.lookUpEditiCode1.Properties.ValueMember = "iCode";
            this.lookUpEditiCode1.Size = new System.Drawing.Size(169, 21);
            this.lookUpEditiCode1.StyleController = this.layoutControl1;
            this.lookUpEditiCode1.TabIndex = 9;
            // 
            // layoutControl1
            // 
            this.layoutControl1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.layoutControl1.Controls.Add(this.textEdit单位名称);
            this.layoutControl1.Controls.Add(this.lookUpEdit销售人员);
            this.layoutControl1.Controls.Add(this.buttonEdit销售人员);
            this.layoutControl1.Controls.Add(this.dateEditdDate1);
            this.layoutControl1.Controls.Add(this.dateEditdDate2);
            this.layoutControl1.Controls.Add(this.lookUpEditiCode2);
            this.layoutControl1.Controls.Add(this.lookUpEditiCode1);
            this.layoutControl1.Location = new System.Drawing.Point(-3, 12);
            this.layoutControl1.Name = "layoutControl1";
            this.layoutControl1.OptionsCustomizationForm.DesignTimeCustomizationFormPositionAndSize = new System.Drawing.Rectangle(123, 171, 250, 350);
            this.layoutControl1.OptionsView.UseDefaultDragAndDropRendering = false;
            this.layoutControl1.Root = this.layoutControlGroup1;
            this.layoutControl1.Size = new System.Drawing.Size(487, 193);
            this.layoutControl1.TabIndex = 0;
            this.layoutControl1.Text = "layoutControl1";
            // 
            // textEdit单位名称
            // 
            this.textEdit单位名称.Location = new System.Drawing.Point(289, 62);
            this.textEdit单位名称.Name = "textEdit单位名称";
            this.textEdit单位名称.Size = new System.Drawing.Size(186, 21);
            this.textEdit单位名称.StyleController = this.layoutControl1;
            this.textEdit单位名称.TabIndex = 22;
            // 
            // lookUpEdit销售人员
            // 
            this.lookUpEdit销售人员.Enabled = false;
            this.lookUpEdit销售人员.Location = new System.Drawing.Point(134, 62);
            this.lookUpEdit销售人员.Name = "lookUpEdit销售人员";
            this.lookUpEdit销售人员.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.lookUpEdit销售人员.Size = new System.Drawing.Size(99, 21);
            this.lookUpEdit销售人员.StyleController = this.layoutControl1;
            this.lookUpEdit销售人员.TabIndex = 21;
            this.lookUpEdit销售人员.Visible = false;
            // 
            // buttonEdit销售人员
            // 
            this.buttonEdit销售人员.Location = new System.Drawing.Point(64, 62);
            this.buttonEdit销售人员.Name = "buttonEdit销售人员";
            this.buttonEdit销售人员.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
            this.buttonEdit销售人员.Size = new System.Drawing.Size(66, 21);
            this.buttonEdit销售人员.StyleController = this.layoutControl1;
            this.buttonEdit销售人员.TabIndex = 18;
            this.buttonEdit销售人员.ButtonClick += new DevExpress.XtraEditors.Controls.ButtonPressedEventHandler(this.buttonEditSS1_ButtonClick);
            this.buttonEdit销售人员.EditValueChanged += new System.EventHandler(this.buttonEditSS1_EditValueChanged);
            this.buttonEdit销售人员.Leave += new System.EventHandler(this.buttonEditSS1_Leave);
            // 
            // dateEditdDate1
            // 
            this.dateEditdDate1.EditValue = null;
            this.dateEditdDate1.Location = new System.Drawing.Point(64, 37);
            this.dateEditdDate1.Name = "dateEditdDate1";
            this.dateEditdDate1.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.dateEditdDate1.Properties.VistaTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
            this.dateEditdDate1.Size = new System.Drawing.Size(169, 21);
            this.dateEditdDate1.StyleController = this.layoutControl1;
            this.dateEditdDate1.TabIndex = 12;
            // 
            // dateEditdDate2
            // 
            this.dateEditdDate2.EditValue = null;
            this.dateEditdDate2.Location = new System.Drawing.Point(289, 37);
            this.dateEditdDate2.Name = "dateEditdDate2";
            this.dateEditdDate2.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.dateEditdDate2.Properties.VistaTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
            this.dateEditdDate2.Size = new System.Drawing.Size(186, 21);
            this.dateEditdDate2.StyleController = this.layoutControl1;
            this.dateEditdDate2.TabIndex = 11;
            // 
            // lookUpEditiCode2
            // 
            this.lookUpEditiCode2.Location = new System.Drawing.Point(289, 12);
            this.lookUpEditiCode2.Name = "lookUpEditiCode2";
            this.lookUpEditiCode2.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.lookUpEditiCode2.Properties.DisplayMember = "iCode";
            this.lookUpEditiCode2.Properties.NullText = "";
            this.lookUpEditiCode2.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.Standard;
            this.lookUpEditiCode2.Properties.ValueMember = "iCode";
            this.lookUpEditiCode2.Size = new System.Drawing.Size(186, 21);
            this.lookUpEditiCode2.StyleController = this.layoutControl1;
            this.lookUpEditiCode2.TabIndex = 10;
            // 
            // layoutControlItem1
            // 
            this.layoutControlItem1.Control = this.lookUpEditiCode2;
            this.layoutControlItem1.CustomizationFormText = "材料入库单号";
            this.layoutControlItem1.Location = new System.Drawing.Point(225, 0);
            this.layoutControlItem1.Name = "layoutControlItem1";
            this.layoutControlItem1.Size = new System.Drawing.Size(242, 25);
            this.layoutControlItem1.Text = "至";
            this.layoutControlItem1.TextSize = new System.Drawing.Size(48, 14);
            // 
            // layoutControlItem3
            // 
            this.layoutControlItem3.Control = this.dateEditdDate1;
            this.layoutControlItem3.CustomizationFormText = "入库日期";
            this.layoutControlItem3.Location = new System.Drawing.Point(0, 25);
            this.layoutControlItem3.Name = "layoutControlItem3";
            this.layoutControlItem3.Size = new System.Drawing.Size(225, 25);
            this.layoutControlItem3.Text = "单据日期";
            this.layoutControlItem3.TextSize = new System.Drawing.Size(48, 14);
            // 
            // layoutControlItem2
            // 
            this.layoutControlItem2.Control = this.dateEditdDate2;
            this.layoutControlItem2.CustomizationFormText = "入库日期";
            this.layoutControlItem2.Location = new System.Drawing.Point(225, 25);
            this.layoutControlItem2.Name = "layoutControlItem2";
            this.layoutControlItem2.Size = new System.Drawing.Size(242, 25);
            this.layoutControlItem2.Text = "至";
            this.layoutControlItem2.TextSize = new System.Drawing.Size(48, 14);
            // 
            // layoutControlItem4
            // 
            this.layoutControlItem4.Control = this.buttonEdit销售人员;
            this.layoutControlItem4.CustomizationFormText = "申请人";
            this.layoutControlItem4.Location = new System.Drawing.Point(0, 50);
            this.layoutControlItem4.Name = "layoutControlItem4";
            this.layoutControlItem4.Size = new System.Drawing.Size(122, 123);
            this.layoutControlItem4.Text = "销售人员";
            this.layoutControlItem4.TextSize = new System.Drawing.Size(48, 14);
            // 
            // layoutControlItem10
            // 
            this.layoutControlItem10.Control = this.lookUpEdit销售人员;
            this.layoutControlItem10.CustomizationFormText = "layoutControlItem10";
            this.layoutControlItem10.Location = new System.Drawing.Point(122, 50);
            this.layoutControlItem10.Name = "layoutControlItem10";
            this.layoutControlItem10.Size = new System.Drawing.Size(103, 123);
            this.layoutControlItem10.Text = "SS1";
            this.layoutControlItem10.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem10.TextToControlDistance = 0;
            this.layoutControlItem10.TextVisible = false;
            // 
            // layoutControlItem5
            // 
            this.layoutControlItem5.Control = this.textEdit单位名称;
            this.layoutControlItem5.CustomizationFormText = "单位名称";
            this.layoutControlItem5.Location = new System.Drawing.Point(225, 50);
            this.layoutControlItem5.Name = "layoutControlItem5";
            this.layoutControlItem5.Size = new System.Drawing.Size(242, 123);
            this.layoutControlItem5.Text = "单位名称";
            this.layoutControlItem5.TextSize = new System.Drawing.Size(48, 14);
            // 
            // btnEnsure
            // 
            this.btnEnsure.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnEnsure.Location = new System.Drawing.Point(230, 208);
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
            this.buttonClear.Location = new System.Drawing.Point(310, 208);
            this.buttonClear.Name = "buttonClear";
            this.buttonClear.Size = new System.Drawing.Size(62, 23);
            this.buttonClear.TabIndex = 5;
            this.buttonClear.Text = "清 除";
            this.buttonClear.UseVisualStyleBackColor = true;
            this.buttonClear.Click += new System.EventHandler(this.buttonClear_Click);
            // 
            // Frm实验申请单_Add
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(481, 243);
            this.Controls.Add(this.buttonClear);
            this.Controls.Add(this.btnEnsure);
            this.Controls.Add(this.btnExit);
            this.Controls.Add(this.layoutControl1);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Frm实验申请单_Add";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "参照";
            this.Load += new System.EventHandler(this.FrmWorkPlanAdd_Load);
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem6)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lookUpEditiCode1.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControl1)).EndInit();
            this.layoutControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.textEdit单位名称.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lookUpEdit销售人员.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.buttonEdit销售人员.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dateEditdDate1.Properties.VistaTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dateEditdDate1.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dateEditdDate2.Properties.VistaTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dateEditdDate2.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lookUpEditiCode2.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem10)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem5)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnExit;
        private DevExpress.XtraLayout.LayoutControlGroup layoutControlGroup1;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem6;
        private DevExpress.XtraEditors.LookUpEdit lookUpEditiCode1;
        private DevExpress.XtraLayout.LayoutControl layoutControl1;
        private System.Windows.Forms.Button btnEnsure;
        private DevExpress.XtraEditors.LookUpEdit lookUpEditiCode2;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem1;
        private DevExpress.XtraEditors.DateEdit dateEditdDate1;
        private DevExpress.XtraEditors.DateEdit dateEditdDate2;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem3;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem2;
        private System.Windows.Forms.Button buttonClear;
        private DevExpress.XtraEditors.ButtonEdit buttonEdit销售人员;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem4;
        private DevExpress.XtraEditors.LookUpEdit lookUpEdit销售人员;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem10;
        private DevExpress.XtraEditors.TextEdit textEdit单位名称;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem5;
    }
}