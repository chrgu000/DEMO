namespace WindowsFormsApplication1
{
    partial class FrmCreditLine
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
            this.creditLine1 = new UFIDA.U8.UAP.CustomApp.ControlForm.CreditLine();
            this.SuspendLayout();
            // 
            // creditLine1
            // 
            this.creditLine1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.creditLine1.Conn = null;
            this.creditLine1.dSerToday = new System.DateTime(((long)(0)));
            this.creditLine1.Location = new System.Drawing.Point(-1, 4);
            this.creditLine1.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.creditLine1.Name = "creditLine1";
            this.creditLine1.sAccID = null;
            this.creditLine1.Size = new System.Drawing.Size(960, 591);
            this.creditLine1.sLogDate = null;
            this.creditLine1.sUserID = null;
            this.creditLine1.sUserName = null;
            this.creditLine1.TabIndex = 0;
            // 
            // FrmCreditLine
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(961, 596);
            this.Controls.Add(this.creditLine1);
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Name = "FrmCreditLine";
            this.Text = "CreditLine";
            this.ResumeLayout(false);

        }

        #endregion

        private UFIDA.U8.UAP.CustomApp.ControlForm.CreditLine creditLine1;




    }
}