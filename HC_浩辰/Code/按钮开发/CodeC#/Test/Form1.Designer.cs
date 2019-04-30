namespace Test
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
            this.btn费用录入 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btn费用录入
            // 
            this.btn费用录入.Location = new System.Drawing.Point(40, 22);
            this.btn费用录入.Name = "btn费用录入";
            this.btn费用录入.Size = new System.Drawing.Size(109, 23);
            this.btn费用录入.TabIndex = 0;
            this.btn费用录入.Text = "费用录入";
            this.btn费用录入.UseVisualStyleBackColor = true;
            this.btn费用录入.Click += new System.EventHandler(this.btn费用录入_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(384, 335);
            this.Controls.Add(this.btn费用录入);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btn费用录入;
    }
}

