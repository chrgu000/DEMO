namespace UseWebService
{
    partial class Form1
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
            this.btnRdrecord01 = new System.Windows.Forms.Button();
            this.btnRdrecord09 = new System.Windows.Forms.Button();
            this.btnRdrecord10 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btnRdrecord01
            // 
            this.btnRdrecord01.Location = new System.Drawing.Point(214, 61);
            this.btnRdrecord01.Name = "btnRdrecord01";
            this.btnRdrecord01.Size = new System.Drawing.Size(140, 42);
            this.btnRdrecord01.TabIndex = 0;
            this.btnRdrecord01.Text = "采购入库单审核";
            this.btnRdrecord01.UseVisualStyleBackColor = true;
            this.btnRdrecord01.Click += new System.EventHandler(this.btnRdrecord01_Click);
            // 
            // btnRdrecord09
            // 
            this.btnRdrecord09.Location = new System.Drawing.Point(214, 136);
            this.btnRdrecord09.Name = "btnRdrecord09";
            this.btnRdrecord09.Size = new System.Drawing.Size(140, 42);
            this.btnRdrecord09.TabIndex = 1;
            this.btnRdrecord09.Text = "其它出库单导入";
            this.btnRdrecord09.UseVisualStyleBackColor = true;
            this.btnRdrecord09.Click += new System.EventHandler(this.btnRdrecord09_Click);
            // 
            // btnRdrecord10
            // 
            this.btnRdrecord10.Location = new System.Drawing.Point(214, 202);
            this.btnRdrecord10.Name = "btnRdrecord10";
            this.btnRdrecord10.Size = new System.Drawing.Size(140, 42);
            this.btnRdrecord10.TabIndex = 2;
            this.btnRdrecord10.Text = "产成品入库单导入";
            this.btnRdrecord10.UseVisualStyleBackColor = true;
            this.btnRdrecord10.Click += new System.EventHandler(this.btnRdrecord10_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(736, 434);
            this.Controls.Add(this.btnRdrecord10);
            this.Controls.Add(this.btnRdrecord09);
            this.Controls.Add(this.btnRdrecord01);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnRdrecord01;
        private System.Windows.Forms.Button btnRdrecord09;
        private System.Windows.Forms.Button btnRdrecord10;
    }
}

