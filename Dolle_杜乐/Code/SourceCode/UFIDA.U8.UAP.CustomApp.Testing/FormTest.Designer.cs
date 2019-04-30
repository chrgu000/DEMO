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
            this.btnPaymentReminder = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btnPaymentReminder
            // 
            this.btnPaymentReminder.Location = new System.Drawing.Point(38, 35);
            this.btnPaymentReminder.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.btnPaymentReminder.Name = "btnPaymentReminder";
            this.btnPaymentReminder.Size = new System.Drawing.Size(119, 36);
            this.btnPaymentReminder.TabIndex = 2;
            this.btnPaymentReminder.Text = "标准工时";
            this.btnPaymentReminder.UseVisualStyleBackColor = true;
            this.btnPaymentReminder.Click += new System.EventHandler(this.button1_Click);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(38, 102);
            this.button1.Margin = new System.Windows.Forms.Padding(2);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(119, 36);
            this.button1.TabIndex = 3;
            this.button1.Text = "成本对比表";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click_1);
            // 
            // FormTest
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(238, 225);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.btnPaymentReminder);
            this.Name = "FormTest";
            this.Text = "FormTest";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnPaymentReminder;
        private System.Windows.Forms.Button button1;


    }
}