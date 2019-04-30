namespace WindowsFormsApplication1
{
    partial class FrmPayment
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
            this.payment1 = new UFIDA.U8.UAP.CustomApp.ControlForm.Payment();
            this.SuspendLayout();
            // 
            // payment1
            // 
            this.payment1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.payment1.Conn = null;
            this.payment1.dSerToday = new System.DateTime(((long)(0)));
            this.payment1.Location = new System.Drawing.Point(-2, 9);
            this.payment1.Name = "payment1";
            this.payment1.sAccID = null;
            this.payment1.Size = new System.Drawing.Size(719, 464);
            this.payment1.sLogDate = null;
            this.payment1.sUserID = null;
            this.payment1.sUserName = null;
            this.payment1.TabIndex = 0;
            // 
            // FrmPayment
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(721, 477);
            this.Controls.Add(this.payment1);
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "FrmPayment";
            this.Text = "Payment";
            this.ResumeLayout(false);

        }

        #endregion

        private UFIDA.U8.UAP.CustomApp.ControlForm.Payment payment1;




    }
}