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
            this.btnDSSaleBaseInfo = new System.Windows.Forms.Button();
            this.btnRepCreateDisInfo = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btnDSSaleBaseInfo
            // 
            this.btnDSSaleBaseInfo.Location = new System.Drawing.Point(34, 22);
            this.btnDSSaleBaseInfo.Margin = new System.Windows.Forms.Padding(2);
            this.btnDSSaleBaseInfo.Name = "btnDSSaleBaseInfo";
            this.btnDSSaleBaseInfo.Size = new System.Drawing.Size(119, 36);
            this.btnDSSaleBaseInfo.TabIndex = 1;
            this.btnDSSaleBaseInfo.Text = "DSSaleBaseInfo";
            this.btnDSSaleBaseInfo.UseVisualStyleBackColor = true;
            this.btnDSSaleBaseInfo.Click += new System.EventHandler(this.btnDSSaleBaseInfo_Click);
            // 
            // btnRepCreateDisInfo
            // 
            this.btnRepCreateDisInfo.Location = new System.Drawing.Point(34, 113);
            this.btnRepCreateDisInfo.Margin = new System.Windows.Forms.Padding(2);
            this.btnRepCreateDisInfo.Name = "btnRepCreateDisInfo";
            this.btnRepCreateDisInfo.Size = new System.Drawing.Size(119, 36);
            this.btnRepCreateDisInfo.TabIndex = 1;
            this.btnRepCreateDisInfo.Text = "RepCreateDisInfo";
            this.btnRepCreateDisInfo.UseVisualStyleBackColor = true;
            this.btnRepCreateDisInfo.Click += new System.EventHandler(this.btnRepCreateDisInfo_Click);
            // 
            // FormTest
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(649, 262);
            this.Controls.Add(this.btnRepCreateDisInfo);
            this.Controls.Add(this.btnDSSaleBaseInfo);
            this.Name = "FormTest";
            this.Text = "FormTest";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnDSSaleBaseInfo;
        private System.Windows.Forms.Button btnRepCreateDisInfo;


    }
}