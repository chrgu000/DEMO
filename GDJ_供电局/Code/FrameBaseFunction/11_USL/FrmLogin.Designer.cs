namespace FrameBaseFunction
{
    partial class FrmLogin
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

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmLogin));
            this.txtPWD = new DevExpress.XtraEditors.TextEdit();
            this.label4 = new System.Windows.Forms.Label();
            this.txtUID = new DevExpress.XtraEditors.TextEdit();
            this.label3 = new System.Windows.Forms.Label();
            this.lookUpAcc = new DevExpress.XtraEditors.LookUpEdit();
            this.dtmLogin = new DevExpress.XtraEditors.DateEdit();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.chkPWD = new System.Windows.Forms.CheckBox();
            this.btnLogin = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.label10 = new System.Windows.Forms.Label();
            this.txt服务器 = new DevExpress.XtraEditors.TextEdit();
            ((System.ComponentModel.ISupportInitialize)(this.txtPWD.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtUID.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lookUpAcc.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtmLogin.Properties.VistaTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtmLogin.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txt服务器.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // txtPWD
            // 
            resources.ApplyResources(this.txtPWD, "txtPWD");
            this.txtPWD.Name = "txtPWD";
            this.txtPWD.Properties.Appearance.Font = ((System.Drawing.Font)(resources.GetObject("txtPWD.Properties.Appearance.Font")));
            this.txtPWD.Properties.Appearance.Options.UseFont = true;
            this.txtPWD.Properties.PasswordChar = '*';
            // 
            // label4
            // 
            resources.ApplyResources(this.label4, "label4");
            this.label4.BackColor = System.Drawing.Color.White;
            this.label4.Name = "label4";
            // 
            // txtUID
            // 
            resources.ApplyResources(this.txtUID, "txtUID");
            this.txtUID.Name = "txtUID";
            this.txtUID.Properties.Appearance.Font = ((System.Drawing.Font)(resources.GetObject("txtUID.Properties.Appearance.Font")));
            this.txtUID.Properties.Appearance.Options.UseFont = true;
            this.txtUID.Leave += new System.EventHandler(this.txtUID_Leave);
            // 
            // label3
            // 
            resources.ApplyResources(this.label3, "label3");
            this.label3.BackColor = System.Drawing.Color.White;
            this.label3.Name = "label3";
            // 
            // lookUpAcc
            // 
            resources.ApplyResources(this.lookUpAcc, "lookUpAcc");
            this.lookUpAcc.Name = "lookUpAcc";
            this.lookUpAcc.Properties.Appearance.Font = ((System.Drawing.Font)(resources.GetObject("lookUpAcc.Properties.Appearance.Font")));
            this.lookUpAcc.Properties.Appearance.Options.UseFont = true;
            this.lookUpAcc.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(((DevExpress.XtraEditors.Controls.ButtonPredefines)(resources.GetObject("lookUpAcc.Properties.Buttons"))))});
            this.lookUpAcc.Properties.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo(resources.GetString("lookUpAcc.Properties.Columns"), resources.GetString("lookUpAcc.Properties.Columns1"))});
            this.lookUpAcc.Properties.DisplayMember = "vchrText";
            this.lookUpAcc.Properties.NullText = resources.GetString("lookUpAcc.Properties.NullText");
            this.lookUpAcc.Properties.ValueMember = "cAcc_Id";
            // 
            // dtmLogin
            // 
            resources.ApplyResources(this.dtmLogin, "dtmLogin");
            this.dtmLogin.Name = "dtmLogin";
            this.dtmLogin.Properties.Appearance.Font = ((System.Drawing.Font)(resources.GetObject("dtmLogin.Properties.Appearance.Font")));
            this.dtmLogin.Properties.Appearance.Options.UseFont = true;
            this.dtmLogin.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(((DevExpress.XtraEditors.Controls.ButtonPredefines)(resources.GetObject("dtmLogin.Properties.Buttons"))))});
            this.dtmLogin.Properties.VistaTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
            // 
            // label1
            // 
            resources.ApplyResources(this.label1, "label1");
            this.label1.BackColor = System.Drawing.Color.White;
            this.label1.Name = "label1";
            // 
            // label2
            // 
            resources.ApplyResources(this.label2, "label2");
            this.label2.BackColor = System.Drawing.Color.White;
            this.label2.Name = "label2";
            // 
            // chkPWD
            // 
            resources.ApplyResources(this.chkPWD, "chkPWD");
            this.chkPWD.BackColor = System.Drawing.Color.White;
            this.chkPWD.Name = "chkPWD";
            this.chkPWD.UseVisualStyleBackColor = false;
            // 
            // btnLogin
            // 
            resources.ApplyResources(this.btnLogin, "btnLogin");
            this.btnLogin.Name = "btnLogin";
            this.btnLogin.UseVisualStyleBackColor = true;
            this.btnLogin.Click += new System.EventHandler(this.btnLogin_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            resources.ApplyResources(this.btnCancel, "btnCancel");
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.button1_Click);
            // 
            // label10
            // 
            resources.ApplyResources(this.label10, "label10");
            this.label10.BackColor = System.Drawing.Color.White;
            this.label10.Name = "label10";
            // 
            // txt服务器
            // 
            resources.ApplyResources(this.txt服务器, "txt服务器");
            this.txt服务器.Name = "txt服务器";
            this.txt服务器.Properties.Appearance.Font = ((System.Drawing.Font)(resources.GetObject("txt服务器.Properties.Appearance.Font")));
            this.txt服务器.Properties.Appearance.Options.UseFont = true;
            this.txt服务器.EditValueChanged += new System.EventHandler(this.txt服务器_EditValueChanged);
            // 
            // FrmLogin
            // 
            this.AcceptButton = this.btnLogin;
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.CancelButton = this.btnCancel;
            this.Controls.Add(this.txt服务器);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.chkPWD);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.btnLogin);
            this.Controls.Add(this.txtUID);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.dtmLogin);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtPWD);
            this.Controls.Add(this.lookUpAcc);
            this.Controls.Add(this.label2);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FrmLogin";
            this.Load += new System.EventHandler(this.FrmLogin_Load);
            ((System.ComponentModel.ISupportInitialize)(this.txtPWD.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtUID.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lookUpAcc.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtmLogin.Properties.VistaTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtmLogin.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txt服务器.Properties)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraEditors.TextEdit txtPWD;
        private System.Windows.Forms.Label label4;
        private DevExpress.XtraEditors.TextEdit txtUID;
        private System.Windows.Forms.Label label3;
        private DevExpress.XtraEditors.LookUpEdit lookUpAcc;
        private DevExpress.XtraEditors.DateEdit dtmLogin;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.CheckBox chkPWD;
        private System.Windows.Forms.Button btnLogin;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Label label10;
        private DevExpress.XtraEditors.TextEdit txt服务器;
    }
}