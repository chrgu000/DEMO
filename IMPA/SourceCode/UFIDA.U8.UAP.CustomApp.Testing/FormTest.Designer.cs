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
            this.btnSQ = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btnSQ
            // 
            this.btnSQ.Location = new System.Drawing.Point(33, 74);
            this.btnSQ.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.btnSQ.Name = "btnSQ";
            this.btnSQ.Size = new System.Drawing.Size(119, 36);
            this.btnSQ.TabIndex = 1;
            this.btnSQ.Text = "SQ";
            this.btnSQ.UseVisualStyleBackColor = true;
            this.btnSQ.Click += new System.EventHandler(this.btnFrmPurchasePlan_Click);
            // 
            // FormTest
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(649, 262);
            this.Controls.Add(this.btnSQ);
            this.Name = "FormTest";
            this.Text = "FormTest";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnSQ;


    }
}