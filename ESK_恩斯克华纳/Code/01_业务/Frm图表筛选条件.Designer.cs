namespace 业务
{
    partial class Frm图表筛选条件
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
            this.lookUpEdit检验工位 = new DevExpress.XtraEditors.LookUpEdit();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.lookUpEdit班组 = new DevExpress.XtraEditors.LookUpEdit();
            this.label3 = new System.Windows.Forms.Label();
            this.lookUpEdit测定项目 = new DevExpress.XtraEditors.LookUpEdit();
            this.btnOK = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.lookUpEdit检验工位.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lookUpEdit班组.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lookUpEdit测定项目.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // lookUpEdit检验工位
            // 
            this.lookUpEdit检验工位.Location = new System.Drawing.Point(71, 49);
            this.lookUpEdit检验工位.Name = "lookUpEdit检验工位";
            this.lookUpEdit检验工位.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.lookUpEdit检验工位.Properties.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("工作台", "检验工位")});
            this.lookUpEdit检验工位.Properties.DisplayMember = "检验工位";
            this.lookUpEdit检验工位.Properties.NullText = "";
            this.lookUpEdit检验工位.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.Standard;
            this.lookUpEdit检验工位.Properties.ValueMember = "检验工位";
            this.lookUpEdit检验工位.Size = new System.Drawing.Size(185, 21);
            this.lookUpEdit检验工位.TabIndex = 2;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 52);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(53, 12);
            this.label1.TabIndex = 64;
            this.label1.Text = "检验工位";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 79);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(29, 12);
            this.label2.TabIndex = 66;
            this.label2.Text = "班组";
            // 
            // lookUpEdit班组
            // 
            this.lookUpEdit班组.Location = new System.Drawing.Point(71, 76);
            this.lookUpEdit班组.Name = "lookUpEdit班组";
            this.lookUpEdit班组.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.lookUpEdit班组.Properties.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("WorkGroup", "班组")});
            this.lookUpEdit班组.Properties.DisplayMember = "WorkGroup";
            this.lookUpEdit班组.Properties.NullText = "";
            this.lookUpEdit班组.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.Standard;
            this.lookUpEdit班组.Properties.ValueMember = "WorkGroup";
            this.lookUpEdit班组.Size = new System.Drawing.Size(185, 21);
            this.lookUpEdit班组.TabIndex = 3;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 25);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(53, 12);
            this.label3.TabIndex = 68;
            this.label3.Text = "测定项目";
            // 
            // lookUpEdit测定项目
            // 
            this.lookUpEdit测定项目.Location = new System.Drawing.Point(71, 22);
            this.lookUpEdit测定项目.Name = "lookUpEdit测定项目";
            this.lookUpEdit测定项目.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.lookUpEdit测定项目.Properties.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("ProCode", "测定项目")});
            this.lookUpEdit测定项目.Properties.DisplayMember = "ProCode";
            this.lookUpEdit测定项目.Properties.NullText = "";
            this.lookUpEdit测定项目.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.Standard;
            this.lookUpEdit测定项目.Properties.ValueMember = "ProCode";
            this.lookUpEdit测定项目.Size = new System.Drawing.Size(185, 21);
            this.lookUpEdit测定项目.TabIndex = 1;
            // 
            // btnOK
            // 
            this.btnOK.Location = new System.Drawing.Point(181, 165);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(75, 23);
            this.btnOK.TabIndex = 69;
            this.btnOK.Text = "确定";
            this.btnOK.UseVisualStyleBackColor = true;
            this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
            // 
            // Frm图表筛选条件
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(268, 209);
            this.Controls.Add(this.btnOK);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.lookUpEdit测定项目);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.lookUpEdit班组);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.lookUpEdit检验工位);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Frm图表筛选条件";
            this.Text = "筛选条件";
            this.Load += new System.EventHandler(this.Frm图表筛选条件_Load);
            ((System.ComponentModel.ISupportInitialize)(this.lookUpEdit检验工位.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lookUpEdit班组.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lookUpEdit测定项目.Properties)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraEditors.LookUpEdit lookUpEdit检验工位;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private DevExpress.XtraEditors.LookUpEdit lookUpEdit班组;
        private System.Windows.Forms.Label label3;
        private DevExpress.XtraEditors.LookUpEdit lookUpEdit测定项目;
        private System.Windows.Forms.Button btnOK;
    }
}