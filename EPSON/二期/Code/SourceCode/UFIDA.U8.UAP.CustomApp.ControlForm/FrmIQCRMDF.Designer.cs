namespace UFIDA.U8.UAP.CustomApp.ControlForm
{
    partial class FrmIQCRMDF
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
            this.iqcrmdf1 = new UFIDA.U8.UAP.CustomApp.ControlForm.IQCRMDF();
            this.SuspendLayout();
            // 
            // iqcrmdf1
            // 
            this.iqcrmdf1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)));
            this.iqcrmdf1.Conn = null;
            this.iqcrmdf1.dSerToday = new System.DateTime(((long)(0)));
            this.iqcrmdf1.Location = new System.Drawing.Point(4, 14);
            this.iqcrmdf1.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.iqcrmdf1.Name = "iqcrmdf1";
            this.iqcrmdf1.sAccID = null;
            this.iqcrmdf1.Size = new System.Drawing.Size(1387, 802);
            this.iqcrmdf1.sLogDate = null;
            this.iqcrmdf1.sUserID = null;
            this.iqcrmdf1.sUserName = null;
            this.iqcrmdf1.TabIndex = 0;
            // 
            // FrmIQCRMDF
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 18F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1392, 820);
            this.Controls.Add(this.iqcrmdf1);
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "FrmIQCRMDF";
            this.Text = "IQCResult";
            this.Load += new System.EventHandler(this.FrmIQCRMDF_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private IQCRMDF iqcrmdf1;


    }
}