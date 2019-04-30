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
            this.btn凭证导入 = new System.Windows.Forms.Button();
            this.btn科目对照 = new System.Windows.Forms.Button();
            this.btn凭证导入2 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btn凭证导入
            // 
            this.btn凭证导入.Location = new System.Drawing.Point(46, 80);
            this.btn凭证导入.Name = "btn凭证导入";
            this.btn凭证导入.Size = new System.Drawing.Size(100, 23);
            this.btn凭证导入.TabIndex = 17;
            this.btn凭证导入.Text = "凭证导入";
            this.btn凭证导入.UseVisualStyleBackColor = true;
            this.btn凭证导入.Click += new System.EventHandler(this.btn凭证导入_Click);
            // 
            // btn科目对照
            // 
            this.btn科目对照.Location = new System.Drawing.Point(46, 33);
            this.btn科目对照.Name = "btn科目对照";
            this.btn科目对照.Size = new System.Drawing.Size(100, 23);
            this.btn科目对照.TabIndex = 18;
            this.btn科目对照.Text = "科目对照";
            this.btn科目对照.UseVisualStyleBackColor = true;
            this.btn科目对照.Click += new System.EventHandler(this.btn科目对照_Click);
            // 
            // btn凭证导入2
            // 
            this.btn凭证导入2.Location = new System.Drawing.Point(46, 138);
            this.btn凭证导入2.Name = "btn凭证导入2";
            this.btn凭证导入2.Size = new System.Drawing.Size(100, 23);
            this.btn凭证导入2.TabIndex = 19;
            this.btn凭证导入2.Text = "凭证导入2";
            this.btn凭证导入2.UseVisualStyleBackColor = true;
            this.btn凭证导入2.Click += new System.EventHandler(this.btn凭证导入2_Click);
            // 
            // FormTest
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(305, 298);
            this.Controls.Add(this.btn凭证导入2);
            this.Controls.Add(this.btn科目对照);
            this.Controls.Add(this.btn凭证导入);
            this.Name = "FormTest";
            this.Text = "FormTest";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btn凭证导入;
        private System.Windows.Forms.Button btn科目对照;
        private System.Windows.Forms.Button btn凭证导入2;

    }
}