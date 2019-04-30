namespace WindowsFormsApplication1
{
    partial class FrmCustomerFeedback
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
            this.customerFeedback1 = new UFIDA.U8.UAP.CustomApp.ControlForm.CustomerFeedback();
            this.SuspendLayout();
            // 
            // customerFeedback1
            // 
            this.customerFeedback1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.customerFeedback1.Conn = null;
            this.customerFeedback1.dSerToday = new System.DateTime(((long)(0)));
            this.customerFeedback1.Location = new System.Drawing.Point(0, 2);
            this.customerFeedback1.Margin = new System.Windows.Forms.Padding(4);
            this.customerFeedback1.Name = "customerFeedback1";
            this.customerFeedback1.sAccID = null;
            this.customerFeedback1.Size = new System.Drawing.Size(1083, 717);
            this.customerFeedback1.sLogDate = null;
            this.customerFeedback1.sUserID = null;
            this.customerFeedback1.sUserName = null;
            this.customerFeedback1.TabIndex = 0;
            // 
            // FrmCustomerFeedback
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 18F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1082, 716);
            this.Controls.Add(this.customerFeedback1);
            this.Name = "FrmCustomerFeedback";
            this.Text = "CustomerFeedback";
            this.ResumeLayout(false);

        }

        #endregion

        private UFIDA.U8.UAP.CustomApp.ControlForm.CustomerFeedback customerFeedback1;






    }
}