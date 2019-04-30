namespace WindowsFormsApplication1
{
    partial class FrmPurchasePlan
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
            this.purchasePlan1 = new UFIDA.U8.UAP.CustomApp.ControlForm.PurchasePlan();
            this.SuspendLayout();
            // 
            // purchasePlan1
            // 
            this.purchasePlan1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.purchasePlan1.Conn = null;
            this.purchasePlan1.dSerToday = new System.DateTime(((long)(0)));
            this.purchasePlan1.Location = new System.Drawing.Point(2, 4);
            this.purchasePlan1.Margin = new System.Windows.Forms.Padding(4);
            this.purchasePlan1.Name = "purchasePlan1";
            this.purchasePlan1.sAccID = null;
            this.purchasePlan1.Size = new System.Drawing.Size(956, 590);
            this.purchasePlan1.sLogDate = null;
            this.purchasePlan1.sUserID = null;
            this.purchasePlan1.sUserName = null;
            this.purchasePlan1.TabIndex = 0;
            // 
            // FrmPurchasePlan
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(961, 596);
            this.Controls.Add(this.purchasePlan1);
            this.Name = "FrmPurchasePlan";
            this.Text = "FrmPurchasePlan";
            this.ResumeLayout(false);

        }

        #endregion

        private UFIDA.U8.UAP.CustomApp.ControlForm.PurchasePlan purchasePlan1;
    }
}