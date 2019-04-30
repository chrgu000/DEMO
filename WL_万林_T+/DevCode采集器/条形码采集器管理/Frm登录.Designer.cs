namespace BarCode
{
    partial class Frm登录
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.MainMenu mainMenu1;

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
            this.mainMenu1 = new System.Windows.Forms.MainMenu();
            this.label1 = new System.Windows.Forms.Label();
            this.txt账号 = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txt密码 = new System.Windows.Forms.TextBox();
            this.btn登录 = new System.Windows.Forms.Button();
            this.dtmLogin = new System.Windows.Forms.DateTimePicker();
            this.label3 = new System.Windows.Forms.Label();
            this.dataSet1 = new System.Data.DataSet();
            ((System.ComponentModel.ISupportInitialize)(this.dataSet1)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(16, 62);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(45, 20);
            this.label1.Text = "账号";
            // 
            // txt账号
            // 
            this.txt账号.Location = new System.Drawing.Point(92, 61);
            this.txt账号.Name = "txt账号";
            this.txt账号.Size = new System.Drawing.Size(108, 25);
            this.txt账号.TabIndex = 1;
            // 
            // label2
            // 
            this.label2.Location = new System.Drawing.Point(16, 89);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(45, 20);
            this.label2.Text = "密码";
            // 
            // txt密码
            // 
            this.txt密码.Location = new System.Drawing.Point(92, 88);
            this.txt密码.Name = "txt密码";
            this.txt密码.PasswordChar = '*';
            this.txt密码.Size = new System.Drawing.Size(108, 25);
            this.txt密码.TabIndex = 2;
            // 
            // btn登录
            // 
            this.btn登录.Location = new System.Drawing.Point(128, 182);
            this.btn登录.Name = "btn登录";
            this.btn登录.Size = new System.Drawing.Size(72, 20);
            this.btn登录.TabIndex = 5;
            this.btn登录.Text = "登 录";
            this.btn登录.Click += new System.EventHandler(this.btn登录_Click);
            // 
            // dtmLogin
            // 
            this.dtmLogin.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtmLogin.Location = new System.Drawing.Point(92, 115);
            this.dtmLogin.Name = "dtmLogin";
            this.dtmLogin.Size = new System.Drawing.Size(108, 26);
            this.dtmLogin.TabIndex = 3;
            // 
            // label3
            // 
            this.label3.Location = new System.Drawing.Point(16, 117);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(45, 20);
            this.label3.Text = "日期";
            // 
            // dataSet1
            // 
            this.dataSet1.DataSetName = "NewDataSet";
            this.dataSet1.Namespace = "";
            this.dataSet1.Prefix = "";
            this.dataSet1.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // Frm登录
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.ClientSize = new System.Drawing.Size(240, 268);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.dtmLogin);
            this.Controls.Add(this.btn登录);
            this.Controls.Add(this.txt密码);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txt账号);
            this.Controls.Add(this.label1);
            this.Menu = this.mainMenu1;
            this.MinimizeBox = false;
            this.Name = "Frm登录";
            this.Text = "登录";
            this.Load += new System.EventHandler(this.Frm登录_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataSet1)).EndInit();
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
        private System.Data.DataSet dataSet1;
    }
}