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
            this.btnFrmPurchasePlan = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btnFrmPurchasePlan
            // 
            this.btnFrmPurchasePlan.Location = new System.Drawing.Point(44, 92);
            this.btnFrmPurchasePlan.Name = "btnFrmPurchasePlan";
            this.btnFrmPurchasePlan.Size = new System.Drawing.Size(159, 45);
            this.btnFrmPurchasePlan.TabIndex = 1;
            this.btnFrmPurchasePlan.Text = "FrmPurchasePlan";
            this.btnFrmPurchasePlan.UseVisualStyleBackColor = true;
            this.btnFrmPurchasePlan.Click += new System.EventHandler(this.btnFrmPurchasePlan_Click);
            // 
            // FormTest
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(865, 328);
            this.Controls.Add(this.btnFrmPurchasePlan);
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "FormTest";
            this.Text = "FormTest";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnFrmPurchasePlan;


    }
}