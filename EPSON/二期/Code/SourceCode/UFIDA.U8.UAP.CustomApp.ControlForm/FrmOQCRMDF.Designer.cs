namespace UFIDA.U8.UAP.CustomApp.ControlForm
{
    partial class FrmOQCRMDF
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
            this.oqcrmdf1 = new UFIDA.U8.UAP.CustomApp.ControlForm.OQCRMDF();
            this.SuspendLayout();
            // 
            // oqcrmdf1
            // 
            this.oqcrmdf1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.oqcrmdf1.Conn = null;
            this.oqcrmdf1.dSerToday = new System.DateTime(((long)(0)));
            this.oqcrmdf1.Location = new System.Drawing.Point(3, 2);
            this.oqcrmdf1.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.oqcrmdf1.Name = "oqcrmdf1";
            this.oqcrmdf1.sAccID = null;
            this.oqcrmdf1.Size = new System.Drawing.Size(1386, 815);
            this.oqcrmdf1.sLogDate = null;
            this.oqcrmdf1.sUserID = null;
            this.oqcrmdf1.sUserName = null;
            this.oqcrmdf1.TabIndex = 0;
            // 
            // FrmOQCRMDF
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 18F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1392, 820);
            this.Controls.Add(this.oqcrmdf1);
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "FrmOQCRMDF";
            this.Text = "OQCResult";
            this.Load += new System.EventHandler(this.FrmOQCRMDF_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private OQCRMDF oqcrmdf1;


    }
}