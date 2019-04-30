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
            this.btnPringMO = new System.Windows.Forms.Button();
            this.btnRd32 = new System.Windows.Forms.Button();
            this.btn打印生产流转单 = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btnPringMO
            // 
            this.btnPringMO.Location = new System.Drawing.Point(28, 36);
            this.btnPringMO.Name = "btnPringMO";
            this.btnPringMO.Size = new System.Drawing.Size(109, 23);
            this.btnPringMO.TabIndex = 0;
            this.btnPringMO.Text = "打印到货单";
            this.btnPringMO.UseVisualStyleBackColor = true;
            this.btnPringMO.Click += new System.EventHandler(this.btnPrintPU_ArrivalVouch_Click);
            // 
            // btnRd32
            // 
            this.btnRd32.Location = new System.Drawing.Point(28, 97);
            this.btnRd32.Name = "btnRd32";
            this.btnRd32.Size = new System.Drawing.Size(109, 23);
            this.btnRd32.TabIndex = 1;
            this.btnRd32.Text = "打印发货单";
            this.btnRd32.UseVisualStyleBackColor = true;
            this.btnRd32.Click += new System.EventHandler(this.btnPrintDispatchList_Click);
            // 
            // btn打印生产流转单
            // 
            this.btn打印生产流转单.Location = new System.Drawing.Point(28, 155);
            this.btn打印生产流转单.Name = "btn打印生产流转单";
            this.btn打印生产流转单.Size = new System.Drawing.Size(109, 23);
            this.btn打印生产流转单.TabIndex = 2;
            this.btn打印生产流转单.Text = "打印生产流转单";
            this.btn打印生产流转单.UseVisualStyleBackColor = true;
            this.btn打印生产流转单.Click += new System.EventHandler(this.btn打印生产流转单_Click);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(28, 209);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(109, 23);
            this.button1.TabIndex = 3;
            this.button1.Text = "打印生产流转单";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(384, 335);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.btn打印生产流转单);
            this.Controls.Add(this.btnRd32);
            this.Controls.Add(this.btnPringMO);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnPringMO;
        private System.Windows.Forms.Button btnRd32;
        private System.Windows.Forms.Button btn打印生产流转单;
        private System.Windows.Forms.Button button1;
    }
}

