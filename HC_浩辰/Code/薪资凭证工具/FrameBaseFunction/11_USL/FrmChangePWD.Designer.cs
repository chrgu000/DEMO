namespace FrameBaseFunction
{
    partial class FrmChangePWD
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmChangePWD));
            this.btnOK = new System.Windows.Forms.Button();
            this.btnExit = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.txtPWD = new DevExpress.XtraEditors.TextEdit();
            this.label2 = new System.Windows.Forms.Label();
            this.txtNewPWD = new DevExpress.XtraEditors.TextEdit();
            this.label4 = new System.Windows.Forms.Label();
            this.txtpwd2 = new DevExpress.XtraEditors.TextEdit();
            this.txtpwd1 = new DevExpress.XtraEditors.TextEdit();
            this.label3 = new System.Windows.Forms.Label();
            this.btnEnSure = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.txtPWD.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtNewPWD.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtpwd2.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtpwd1.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // btnOK
            // 
            this.btnOK.Location = new System.Drawing.Point(243, 138);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(75, 23);
            this.btnOK.TabIndex = 2;
            this.btnOK.Text = "确认";
            this.btnOK.UseVisualStyleBackColor = true;
            // 
            // btnExit
            // 
            this.btnExit.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnExit.Location = new System.Drawing.Point(346, 138);
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size(75, 23);
            this.btnExit.TabIndex = 3;
            this.btnExit.Text = "退出";
            this.btnExit.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(63, 42);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(53, 12);
            this.label1.TabIndex = 2;
            this.label1.Text = "密    码";
            // 
            // txtPWD
            // 
            this.txtPWD.Location = new System.Drawing.Point(134, 37);
            this.txtPWD.Name = "txtPWD";
            this.txtPWD.Properties.PasswordChar = '*';
            this.txtPWD.Size = new System.Drawing.Size(233, 21);
            this.txtPWD.TabIndex = 0;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(63, 69);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(53, 12);
            this.label2.TabIndex = 2;
            this.label2.Text = "确认密码";
            // 
            // txtNewPWD
            // 
            this.txtNewPWD.Location = new System.Drawing.Point(134, 64);
            this.txtNewPWD.Name = "txtNewPWD";
            this.txtNewPWD.Properties.PasswordChar = '*';
            this.txtNewPWD.Size = new System.Drawing.Size(233, 21);
            this.txtNewPWD.TabIndex = 1;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("华文行楷", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label4.Location = new System.Drawing.Point(18, 74);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(123, 19);
            this.label4.TabIndex = 8;
            this.label4.Text = "重复登陆密码";
            // 
            // txtpwd2
            // 
            this.txtpwd2.Location = new System.Drawing.Point(157, 72);
            this.txtpwd2.Name = "txtpwd2";
            this.txtpwd2.Properties.PasswordChar = '*';
            this.txtpwd2.Size = new System.Drawing.Size(244, 21);
            this.txtpwd2.TabIndex = 1;
            // 
            // txtpwd1
            // 
            this.txtpwd1.Location = new System.Drawing.Point(157, 45);
            this.txtpwd1.Name = "txtpwd1";
            this.txtpwd1.Properties.PasswordChar = '*';
            this.txtpwd1.Size = new System.Drawing.Size(244, 21);
            this.txtpwd1.TabIndex = 0;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("华文行楷", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label3.Location = new System.Drawing.Point(26, 47);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(115, 19);
            this.label3.TabIndex = 8;
            this.label3.Text = "登  陆  密  码";
            // 
            // btnEnSure
            // 
            this.btnEnSure.Location = new System.Drawing.Point(326, 144);
            this.btnEnSure.Name = "btnEnSure";
            this.btnEnSure.Size = new System.Drawing.Size(75, 23);
            this.btnEnSure.TabIndex = 2;
            this.btnEnSure.Text = "确  定";
            this.btnEnSure.UseVisualStyleBackColor = true;
            this.btnEnSure.Click += new System.EventHandler(this.btnOK_Click);
            // 
            // FrmChangePWD
            // 
            this.AcceptButton = this.btnEnSure;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.ClientSize = new System.Drawing.Size(411, 189);
            this.Controls.Add(this.btnEnSure);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.txtpwd1);
            this.Controls.Add(this.txtpwd2);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FrmChangePWD";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "修改密码";
            ((System.ComponentModel.ISupportInitialize)(this.txtPWD.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtNewPWD.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtpwd2.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtpwd1.Properties)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnOK;
        private System.Windows.Forms.Button btnExit;
        private System.Windows.Forms.Label label1;
        private DevExpress.XtraEditors.TextEdit txtPWD;
        private System.Windows.Forms.Label label2;
        private DevExpress.XtraEditors.TextEdit txtNewPWD;
        private System.Windows.Forms.Label label4;
        private DevExpress.XtraEditors.TextEdit txtpwd2;
        private DevExpress.XtraEditors.TextEdit txtpwd1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button btnEnSure;
    }
}