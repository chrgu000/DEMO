namespace BarCode
{
    partial class Frm登录
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
            this.txt账号 = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txt密码 = new System.Windows.Forms.TextBox();
            this.btn登录 = new System.Windows.Forms.Button();
            this.dtmLogin = new System.Windows.Forms.DateTimePicker();
            this.label3 = new System.Windows.Forms.Label();
            this.btnClose = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // msgBox
            // 
            this.msgBox.ClientSize = new System.Drawing.Size(1916, 853);
            this.msgBox.Location = new System.Drawing.Point(-8, -8);
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(41, 61);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(45, 20);
            this.label1.Text = "账号";
            // 
            // txt账号
            // 
            this.txt账号.Location = new System.Drawing.Point(92, 61);
            this.txt账号.Name = "txt账号";
            this.txt账号.Size = new System.Drawing.Size(123, 21);
            this.txt账号.TabIndex = 1;
            // 
            // label2
            // 
            this.label2.Location = new System.Drawing.Point(41, 89);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(45, 20);
            this.label2.Text = "密码";
            // 
            // txt密码
            // 
            this.txt密码.Location = new System.Drawing.Point(92, 88);
            this.txt密码.Name = "txt密码";
            this.txt密码.PasswordChar = '*';
            this.txt密码.Size = new System.Drawing.Size(123, 21);
            this.txt密码.TabIndex = 2;
            // 
            // btn登录
            // 
            this.btn登录.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.btn登录.Location = new System.Drawing.Point(120, 167);
            this.btn登录.Name = "btn登录";
            this.btn登录.Size = new System.Drawing.Size(95, 20);
            this.btn登录.TabIndex = 5;
            this.btn登录.Text = "登 录";
            this.btn登录.Click += new System.EventHandler(this.btn登录_Click);
            // 
            // dtmLogin
            // 
            this.dtmLogin.Location = new System.Drawing.Point(92, 115);
            this.dtmLogin.Name = "dtmLogin";
            this.dtmLogin.Size = new System.Drawing.Size(123, 22);
            this.dtmLogin.TabIndex = 3;
            this.dtmLogin.Value = new System.DateTime(2013, 8, 1, 22, 51, 0, 0);
            // 
            // label3
            // 
            this.label3.Location = new System.Drawing.Point(41, 115);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(45, 20);
            this.label3.Text = "日期";
            // 
            // btnClose
            // 
            this.btnClose.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.btnClose.Location = new System.Drawing.Point(120, 204);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(95, 20);
            this.btnClose.TabIndex = 8;
            this.btnClose.Text = "关 闭";
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // label4
            // 
            this.label4.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label4.Location = new System.Drawing.Point(3, 230);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(110, 20);
            this.label4.Text = "1504271405";
            // 
            // Frm登录
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.ClientSize = new System.Drawing.Size(268, 250);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.dtmLogin);
            this.Controls.Add(this.btn登录);
            this.Controls.Add(this.txt密码);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txt账号);
            this.Controls.Add(this.label1);
            this.MinimizeBox = false;
            this.Name = "Frm登录";
            this.Text = "登录";
            this.Load += new System.EventHandler(this.Frm登录_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txt账号;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txt密码;
        private System.Windows.Forms.Button btn登录;
        private System.Windows.Forms.DateTimePicker dtmLogin;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.Label label4;
    }
}