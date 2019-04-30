namespace Smartclient
{
    partial class Frm条形码执行统计
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Frm条形码执行统计));
            this.label1 = new System.Windows.Forms.Label();
            this.txtBarCode2 = new System.Windows.Forms.TextBox();
            this.btnExit = new System.Windows.Forms.Button();
            this.btnSEL = new System.Windows.Forms.Button();
            this.btnSEL2 = new System.Windows.Forms.Button();
            this.dataGrid1 = new System.Windows.Forms.DataGrid();
            this.txt信息 = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.ForeColor = System.Drawing.Color.Blue;
            this.label1.Location = new System.Drawing.Point(3, 4);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(52, 20);
            this.label1.Text = "条形码";
            // 
            // txtBarCode2
            // 
            this.txtBarCode2.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Regular);
            this.txtBarCode2.Location = new System.Drawing.Point(72, 1);
            this.txtBarCode2.Name = "txtBarCode2";
            this.txtBarCode2.Size = new System.Drawing.Size(125, 19);
            this.txtBarCode2.TabIndex = 2;
            this.txtBarCode2.KeyUp += new System.Windows.Forms.KeyEventHandler(this.txtBarCode_KeyUp);
            // 
            // btnExit
            // 
            this.btnExit.Location = new System.Drawing.Point(195, 244);
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size(39, 20);
            this.btnExit.TabIndex = 13;
            this.btnExit.Text = "退出";
            this.btnExit.Click += new System.EventHandler(this.btnExit_Click);
            // 
            // btnSEL
            // 
            this.btnSEL.Location = new System.Drawing.Point(210, 0);
            this.btnSEL.Name = "btnSEL";
            this.btnSEL.Size = new System.Drawing.Size(26, 21);
            this.btnSEL.TabIndex = 58;
            this.btnSEL.Text = "...";
            this.btnSEL.Click += new System.EventHandler(this.btnSEL_Click);
            // 
            // btnSEL2
            // 
            this.btnSEL2.Location = new System.Drawing.Point(152, 244);
            this.btnSEL2.Name = "btnSEL2";
            this.btnSEL2.Size = new System.Drawing.Size(35, 20);
            this.btnSEL2.TabIndex = 72;
            this.btnSEL2.Text = "查看";
            this.btnSEL2.Visible = false;
            // 
            // dataGrid1
            // 
            this.dataGrid1.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(128)))), ((int)(((byte)(128)))));
            this.dataGrid1.Location = new System.Drawing.Point(4, 122);
            this.dataGrid1.Name = "dataGrid1";
            this.dataGrid1.Size = new System.Drawing.Size(230, 104);
            this.dataGrid1.TabIndex = 103;
            // 
            // txt信息
            // 
            this.txt信息.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Regular);
            this.txt信息.Location = new System.Drawing.Point(4, 24);
            this.txt信息.Multiline = true;
            this.txt信息.Name = "txt信息";
            this.txt信息.ReadOnly = true;
            this.txt信息.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.txt信息.Size = new System.Drawing.Size(232, 98);
            this.txt信息.TabIndex = 109;
            // 
            // Frm条形码执行统计
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.ClientSize = new System.Drawing.Size(240, 268);
            this.Controls.Add(this.txt信息);
            this.Controls.Add(this.dataGrid1);
            this.Controls.Add(this.btnSEL2);
            this.Controls.Add(this.btnSEL);
            this.Controls.Add(this.btnExit);
            this.Controls.Add(this.txtBarCode2);
            this.Controls.Add(this.label1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.KeyPreview = true;
            this.Name = "Frm条形码执行统计";
            this.Text = "条形码执行统计";
            this.Load += new System.EventHandler(this.Frm_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtBarCode2;
        private System.Windows.Forms.Button btnExit;
        private System.Windows.Forms.Button btnSEL;
        private System.Windows.Forms.Button btnSEL2;
        private System.Windows.Forms.DataGrid dataGrid1;
        private System.Windows.Forms.TextBox txt信息;


    }
}

