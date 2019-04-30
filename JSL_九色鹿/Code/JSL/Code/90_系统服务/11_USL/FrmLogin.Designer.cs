namespace 系统服务
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
            this.btnSetInfo = new System.Windows.Forms.Button();
            this.label10 = new System.Windows.Forms.Label();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.btnSet = new System.Windows.Forms.Button();
            this.txtTimeOut = new DevExpress.XtraEditors.TextEdit();
            this.label5 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.txtServer = new DevExpress.XtraEditors.TextEdit();
            this.label8 = new System.Windows.Forms.Label();
            this.txtUserID = new DevExpress.XtraEditors.TextEdit();
            this.label7 = new System.Windows.Forms.Label();
            this.txtPasswd = new DevExpress.XtraEditors.TextEdit();
            this.label6 = new System.Windows.Forms.Label();
            this.txtDataBase = new DevExpress.XtraEditors.TextEdit();
            this.radioWindows = new System.Windows.Forms.RadioButton();
            this.radioSQLServer = new System.Windows.Forms.RadioButton();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.btnSetAppConfig = new System.Windows.Forms.Button();
            this.label11 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.txtComName = new DevExpress.XtraEditors.TextEdit();
            this.txtSN = new DevExpress.XtraEditors.TextEdit();
            this.label13 = new System.Windows.Forms.Label();
            this.txtProName = new DevExpress.XtraEditors.TextEdit();
            this.label14 = new System.Windows.Forms.Label();
            this.txtFiles = new DevExpress.XtraEditors.TextEdit();
            ((System.ComponentModel.ISupportInitialize)(this.txtPWD.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtUID.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lookUpAcc.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtmLogin.Properties.VistaTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtmLogin.Properties)).BeginInit();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtTimeOut.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtServer.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtUserID.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtPasswd.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtDataBase.Properties)).BeginInit();
            this.tabPage2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtComName.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtSN.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtProName.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtFiles.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // txtPWD
            // 
            resources.ApplyResources(this.txtPWD, "txtPWD");
            this.txtPWD.Name = "txtPWD";
            this.txtPWD.Properties.PasswordChar = '*';
            // 
            // label4
            // 
            resources.ApplyResources(this.label4, "label4");
            this.label4.Name = "label4";
            // 
            // txtUID
            // 
            resources.ApplyResources(this.txtUID, "txtUID");
            this.txtUID.Name = "txtUID";
            this.txtUID.EditValueChanged += new System.EventHandler(this.txtUID_EditValueChanged);
            this.txtUID.Leave += new System.EventHandler(this.txtUID_Leave);
            // 
            // label3
            // 
            resources.ApplyResources(this.label3, "label3");
            this.label3.Name = "label3";
            // 
            // lookUpAcc
            // 
            resources.ApplyResources(this.lookUpAcc, "lookUpAcc");
            this.lookUpAcc.Name = "lookUpAcc";
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
            this.dtmLogin.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(((DevExpress.XtraEditors.Controls.ButtonPredefines)(resources.GetObject("dtmLogin.Properties.Buttons"))))});
            this.dtmLogin.Properties.VistaTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
            // 
            // label1
            // 
            resources.ApplyResources(this.label1, "label1");
            this.label1.Name = "label1";
            // 
            // label2
            // 
            resources.ApplyResources(this.label2, "label2");
            this.label2.Name = "label2";
            // 
            // chkPWD
            // 
            resources.ApplyResources(this.chkPWD, "chkPWD");
            this.chkPWD.Name = "chkPWD";
            this.chkPWD.UseVisualStyleBackColor = true;
            // 
            // btnLogin
            // 
            resources.ApplyResources(this.btnLogin, "btnLogin");
            this.btnLogin.Name = "btnLogin";
            this.btnLogin.UseVisualStyleBackColor = true;
            this.btnLogin.Click += new System.EventHandler(this.btnLogin_Click);
            // 
            // btnSetInfo
            // 
            resources.ApplyResources(this.btnSetInfo, "btnSetInfo");
            this.btnSetInfo.Name = "btnSetInfo";
            this.btnSetInfo.UseVisualStyleBackColor = true;
            this.btnSetInfo.Click += new System.EventHandler(this.btnSetInfo_Click);
            // 
            // label10
            // 
            resources.ApplyResources(this.label10, "label10");
            this.label10.Name = "label10";
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            resources.ApplyResources(this.tabControl1, "tabControl1");
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            // 
            // tabPage1
            // 
            this.tabPage1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.tabPage1.Controls.Add(this.label14);
            this.tabPage1.Controls.Add(this.txtFiles);
            this.tabPage1.Controls.Add(this.btnSet);
            this.tabPage1.Controls.Add(this.txtTimeOut);
            this.tabPage1.Controls.Add(this.label5);
            this.tabPage1.Controls.Add(this.label9);
            this.tabPage1.Controls.Add(this.txtServer);
            this.tabPage1.Controls.Add(this.label8);
            this.tabPage1.Controls.Add(this.txtUserID);
            this.tabPage1.Controls.Add(this.label7);
            this.tabPage1.Controls.Add(this.txtPasswd);
            this.tabPage1.Controls.Add(this.label6);
            this.tabPage1.Controls.Add(this.txtDataBase);
            this.tabPage1.Controls.Add(this.radioWindows);
            this.tabPage1.Controls.Add(this.radioSQLServer);
            resources.ApplyResources(this.tabPage1, "tabPage1");
            this.tabPage1.Name = "tabPage1";
            // 
            // btnSet
            // 
            resources.ApplyResources(this.btnSet, "btnSet");
            this.btnSet.Name = "btnSet";
            this.btnSet.UseVisualStyleBackColor = true;
            this.btnSet.Click += new System.EventHandler(this.btnSet_Click);
            // 
            // txtTimeOut
            // 
            resources.ApplyResources(this.txtTimeOut, "txtTimeOut");
            this.txtTimeOut.Name = "txtTimeOut";
            this.txtTimeOut.Properties.Mask.EditMask = resources.GetString("txtTimeOut.Properties.Mask.EditMask");
            this.txtTimeOut.Properties.Mask.MaskType = ((DevExpress.XtraEditors.Mask.MaskType)(resources.GetObject("txtTimeOut.Properties.Mask.MaskType")));
            // 
            // label5
            // 
            resources.ApplyResources(this.label5, "label5");
            this.label5.Name = "label5";
            // 
            // label9
            // 
            resources.ApplyResources(this.label9, "label9");
            this.label9.Name = "label9";
            // 
            // txtServer
            // 
            resources.ApplyResources(this.txtServer, "txtServer");
            this.txtServer.Name = "txtServer";
            // 
            // label8
            // 
            resources.ApplyResources(this.label8, "label8");
            this.label8.Name = "label8";
            // 
            // txtUserID
            // 
            resources.ApplyResources(this.txtUserID, "txtUserID");
            this.txtUserID.Name = "txtUserID";
            // 
            // label7
            // 
            resources.ApplyResources(this.label7, "label7");
            this.label7.Name = "label7";
            // 
            // txtPasswd
            // 
            resources.ApplyResources(this.txtPasswd, "txtPasswd");
            this.txtPasswd.Name = "txtPasswd";
            this.txtPasswd.Properties.PasswordChar = '*';
            // 
            // label6
            // 
            resources.ApplyResources(this.label6, "label6");
            this.label6.Name = "label6";
            // 
            // txtDataBase
            // 
            resources.ApplyResources(this.txtDataBase, "txtDataBase");
            this.txtDataBase.Name = "txtDataBase";
            // 
            // radioWindows
            // 
            resources.ApplyResources(this.radioWindows, "radioWindows");
            this.radioWindows.Name = "radioWindows";
            this.radioWindows.UseVisualStyleBackColor = true;
            this.radioWindows.Click += new System.EventHandler(this.radioWindows_Click);
            // 
            // radioSQLServer
            // 
            resources.ApplyResources(this.radioSQLServer, "radioSQLServer");
            this.radioSQLServer.Checked = true;
            this.radioSQLServer.Name = "radioSQLServer";
            this.radioSQLServer.TabStop = true;
            this.radioSQLServer.UseVisualStyleBackColor = true;
            this.radioSQLServer.Click += new System.EventHandler(this.radioSQLServer_Click);
            // 
            // tabPage2
            // 
            this.tabPage2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.tabPage2.Controls.Add(this.btnSetAppConfig);
            this.tabPage2.Controls.Add(this.label11);
            this.tabPage2.Controls.Add(this.label12);
            this.tabPage2.Controls.Add(this.txtComName);
            this.tabPage2.Controls.Add(this.txtSN);
            this.tabPage2.Controls.Add(this.label13);
            this.tabPage2.Controls.Add(this.txtProName);
            resources.ApplyResources(this.tabPage2, "tabPage2");
            this.tabPage2.Name = "tabPage2";
            // 
            // btnSetAppConfig
            // 
            resources.ApplyResources(this.btnSetAppConfig, "btnSetAppConfig");
            this.btnSetAppConfig.Name = "btnSetAppConfig";
            this.btnSetAppConfig.UseVisualStyleBackColor = true;
            this.btnSetAppConfig.Click += new System.EventHandler(this.btnSetAppConfig_Click);
            // 
            // label11
            // 
            resources.ApplyResources(this.label11, "label11");
            this.label11.Name = "label11";
            // 
            // label12
            // 
            resources.ApplyResources(this.label12, "label12");
            this.label12.Name = "label12";
            // 
            // txtComName
            // 
            resources.ApplyResources(this.txtComName, "txtComName");
            this.txtComName.Name = "txtComName";
            // 
            // txtSN
            // 
            resources.ApplyResources(this.txtSN, "txtSN");
            this.txtSN.Name = "txtSN";
            // 
            // label13
            // 
            resources.ApplyResources(this.label13, "label13");
            this.label13.Name = "label13";
            // 
            // txtProName
            // 
            resources.ApplyResources(this.txtProName, "txtProName");
            this.txtProName.Name = "txtProName";
            // 
            // label14
            // 
            resources.ApplyResources(this.label14, "label14");
            this.label14.Name = "label14";
            // 
            // txtFiles
            // 
            resources.ApplyResources(this.txtFiles, "txtFiles");
            this.txtFiles.Name = "txtFiles";
            this.txtFiles.Properties.PasswordChar = '*';
            // 
            // FrmLogin
            // 
            this.AcceptButton = this.btnLogin;
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.chkPWD);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.btnLogin);
            this.Controls.Add(this.txtUID);
            this.Controls.Add(this.btnSetInfo);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.dtmLogin);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtPWD);
            this.Controls.Add(this.lookUpAcc);
            this.Controls.Add(this.label2);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FrmLogin";
            this.Load += new System.EventHandler(this.FrmLogin_Load);
            ((System.ComponentModel.ISupportInitialize)(this.txtPWD.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtUID.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lookUpAcc.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtmLogin.Properties.VistaTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtmLogin.Properties)).EndInit();
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtTimeOut.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtServer.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtUserID.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtPasswd.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtDataBase.Properties)).EndInit();
            this.tabPage2.ResumeLayout(false);
            this.tabPage2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtComName.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtSN.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtProName.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtFiles.Properties)).EndInit();
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
        private System.Windows.Forms.Button btnSetInfo;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.Button btnSet;
        private DevExpress.XtraEditors.TextEdit txtTimeOut;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label9;
        private DevExpress.XtraEditors.TextEdit txtServer;
        private System.Windows.Forms.Label label8;
        private DevExpress.XtraEditors.TextEdit txtUserID;
        private System.Windows.Forms.Label label7;
        private DevExpress.XtraEditors.TextEdit txtPasswd;
        private System.Windows.Forms.Label label6;
        private DevExpress.XtraEditors.TextEdit txtDataBase;
        private System.Windows.Forms.RadioButton radioWindows;
        private System.Windows.Forms.RadioButton radioSQLServer;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label12;
        private DevExpress.XtraEditors.TextEdit txtComName;
        private DevExpress.XtraEditors.TextEdit txtSN;
        private System.Windows.Forms.Label label13;
        private DevExpress.XtraEditors.TextEdit txtProName;
        private System.Windows.Forms.Button btnSetAppConfig;
        private System.Windows.Forms.Label label14;
        private DevExpress.XtraEditors.TextEdit txtFiles;
    }
}