namespace WindowsFormsApplication1
{
    partial class FrmIQCGenerateandSendRMDF
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
            this.iqcGenerateandSendRMDF1 = new UFIDA.U8.UAP.CustomApp.ControlForm.IQCRMDFList();
            this.SuspendLayout();
            // 
            // iqcGenerateandSendRMDF1
            // 
            this.iqcGenerateandSendRMDF1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.iqcGenerateandSendRMDF1.Conn = null;
            this.iqcGenerateandSendRMDF1.dSerToday = new System.DateTime(((long)(0)));
            this.iqcGenerateandSendRMDF1.Location = new System.Drawing.Point(1, 2);
            this.iqcGenerateandSendRMDF1.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.iqcGenerateandSendRMDF1.Name = "iqcGenerateandSendRMDF1";
            this.iqcGenerateandSendRMDF1.sAccID = null;
            this.iqcGenerateandSendRMDF1.Size = new System.Drawing.Size(959, 593);
            this.iqcGenerateandSendRMDF1.sLogDate = null;
            this.iqcGenerateandSendRMDF1.sUserID = null;
            this.iqcGenerateandSendRMDF1.sUserName = null;
            this.iqcGenerateandSendRMDF1.TabIndex = 0;
            // 
            // FrmIQCGenerateandSendRMDF
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(961, 596);
            this.Controls.Add(this.iqcGenerateandSendRMDF1);
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Name = "FrmIQCGenerateandSendRMDF";
            this.Text = "IQC Generate and Send RMDF";
            this.ResumeLayout(false);

        }

        #endregion

        private UFIDA.U8.UAP.CustomApp.ControlForm.IQCRMDFList iqcGenerateandSendRMDF1;






    }
}