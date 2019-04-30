namespace WindowsFormsApplication1
{
    partial class FormTest
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.btn销售汇总表 = new System.Windows.Forms.Button();
            this.btn销售明细表 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btn销售汇总表
            // 
            this.btn销售汇总表.Location = new System.Drawing.Point(89, 52);
            this.btn销售汇总表.Margin = new System.Windows.Forms.Padding(4);
            this.btn销售汇总表.Name = "btn销售汇总表";
            this.btn销售汇总表.Size = new System.Drawing.Size(133, 29);
            this.btn销售汇总表.TabIndex = 17;
            this.btn销售汇总表.Text = "销售汇总表";
            this.btn销售汇总表.UseVisualStyleBackColor = true;
            this.btn销售汇总表.Click += new System.EventHandler(this.btn销售汇总表_Click);
            // 
            // btn销售明细表
            // 
            this.btn销售明细表.Location = new System.Drawing.Point(89, 122);
            this.btn销售明细表.Margin = new System.Windows.Forms.Padding(4);
            this.btn销售明细表.Name = "btn销售明细表";
            this.btn销售明细表.Size = new System.Drawing.Size(133, 29);
            this.btn销售明细表.TabIndex = 17;
            this.btn销售明细表.Text = "销售明细表";
            this.btn销售明细表.UseVisualStyleBackColor = true;
            // 
            // FormTest
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(379, 328);
            this.Controls.Add(this.btn销售明细表);
            this.Controls.Add(this.btn销售汇总表);
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "FormTest";
            this.Text = "FormTest";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btn销售汇总表;
        private System.Windows.Forms.Button btn销售明细表;
    }
}