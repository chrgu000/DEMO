namespace Smartclient
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
            this.label1 = new System.Windows.Forms.Label();
            this.txtUid = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtPwd = new System.Windows.Forms.TextBox();
            this.btnLogin = new System.Windows.Forms.Button();
            this.dtmLogin = new System.Windows.Forms.DateTimePicker();
            this.label3 = new System.Windows.Forms.Label();
            this.btnSetWebURL = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.btnCancel = new System.Windows.Forms.Button();
            this.chkUpdatePwd = new System.Windows.Forms.CheckBox();
            this.combo帐套 = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(30, 38);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(45, 20);
            this.label1.Text = "账号";
            // 
            // txtUid
            // 
            this.txtUid.Location = new System.Drawing.Point(81, 37);
            this.txtUid.Name = "txtUid";
            this.txtUid.Size = new System.Drawing.Size(108, 21);
            this.txtUid.TabIndex = 1;
            this.txtUid.KeyUp += new System.Windows.Forms.KeyEventHandler(this.txtUid_KeyUp);
            // 
            // label2
            // 
            this.label2.Location = new System.Drawing.Point(30, 68);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(45, 20);
            this.label2.Text = "密码";
            // 
            // txtPwd
            // 
            this.txtPwd.Location = new System.Drawing.Point(81, 64);
            this.txtPwd.Name = "txtPwd";
            this.txtPwd.PasswordChar = '*';
            this.txtPwd.Size = new System.Drawing.Size(108, 21);
            this.txtPwd.TabIndex = 2;
            this.txtPwd.KeyUp += new System.Windows.Forms.KeyEventHandler(this.txtPwd_KeyUp);
            // 
            // btnLogin
            // 
            this.btnLogin.Location = new System.Drawing.Point(117, 175);
            this.btnLogin.Name = "btnLogin";
            this.btnLogin.Size = new System.Drawing.Size(72, 20);
            this.btnLogin.TabIndex = 5;
            this.btnLogin.Text = "登 录";
            this.btnLogin.Click += new System.EventHandler(this.btnLogin_Click);
            // 
            // dtmLogin
            // 
            this.dtmLogin.Location = new System.Drawing.Point(81, 120);
            this.dtmLogin.Name = "dtmLogin";
            this.dtmLogin.Size = new System.Drawing.Size(108, 22);
            this.dtmLogin.TabIndex = 3;
            this.dtmLogin.Value = new System.DateTime(2013, 8, 1, 22, 51, 0, 0);
            // 
            // label3
            // 
            this.label3.Location = new System.Drawing.Point(30, 124);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(45, 20);
            this.label3.Text = "日期";
            // 
            // btnSetWebURL
            // 
            this.btnSetWebURL.Location = new System.Drawing.Point(117, 212);
            this.btnSetWebURL.Name = "btnSetWebURL";
            this.btnSetWebURL.Size = new System.Drawing.Size(72, 20);
            this.btnSetWebURL.TabIndex = 6;
            this.btnSetWebURL.Text = "设置连接";
            this.btnSetWebURL.Click += new System.EventHandler(this.btnSetWebURL_Click);
            // 
            // label4
            // 
            this.label4.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label4.Location = new System.Drawing.Point(9, 238);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(102, 20);
            this.label4.Text = "V150104-2";
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(117, 238);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(72, 20);
            this.btnCancel.TabIndex = 9;
            this.btnCancel.Text = "退 出";
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // chkUpdatePwd
            // 
            this.chkUpdatePwd.Location = new System.Drawing.Point(89, 148);
            this.chkUpdatePwd.Name = "chkUpdatePwd";
            this.chkUpdatePwd.Size = new System.Drawing.Size(100, 20);
            this.chkUpdatePwd.TabIndex = 14;
            this.chkUpdatePwd.Text = "修改密码";
            // 
            // combo帐套
            // 
            this.combo帐套.Location = new System.Drawing.Point(81, 91);
            this.combo帐套.Name = "combo帐套";
            this.combo帐套.Size = new System.Drawing.Size(108, 22);
            this.combo帐套.TabIndex = 20;
            this.combo帐套.KeyUp += new System.Windows.Forms.KeyEventHandler(this.combo帐套_KeyUp);
            // 
            // label5
            // 
            this.label5.Location = new System.Drawing.Point(30, 96);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(52, 20);
            this.label5.Text = "帐套";
            // 
            // FrmLogin
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.ClientSize = new System.Drawing.Size(240, 268);
            this.Controls.Add(this.combo帐套);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.chkUpdatePwd);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.btnSetWebURL);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.dtmLogin);
            this.Controls.Add(this.btnLogin);
            this.Controls.Add(this.txtPwd);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtUid);
            this.Controls.Add(this.label1);
            this.MinimizeBox = false;
            this.Name = "FrmLogin";
            this.Text = "登录";
            this.Load += new System.EventHandler(this.Frm_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtUid;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtPwd;
        private System.Windows.Forms.Button btnLogin;
        private System.Windows.Forms.DateTimePicker dtmLogin;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button btnSetWebURL;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.CheckBox chkUpdatePwd;
        private System.Windows.Forms.ComboBox combo帐套;
        private System.Windows.Forms.Label label5;
    }
}