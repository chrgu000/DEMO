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
            this.btn检验01 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btn检验01
            // 
            this.btn检验01.Location = new System.Drawing.Point(60, 49);
            this.btn检验01.Name = "btn检验01";
            this.btn检验01.Size = new System.Drawing.Size(75, 23);
            this.btn检验01.TabIndex = 0;
            this.btn检验01.Text = "检验01";
            this.btn检验01.UseVisualStyleBackColor = true;
            this.btn检验01.Click += new System.EventHandler(this.btn检验01_Click);
            // 
            // FormTest
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(689, 262);
            this.Controls.Add(this.btn检验01);
            this.Name = "FormTest";
            this.Text = "FormTest";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btn检验01;



    }
}