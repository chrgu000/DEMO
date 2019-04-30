namespace WindowsFormsApplication1
{
    partial class FrmRepBarcodeAverage
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
            this.repBarcode1 = new UFIDA.U8.UAP.CustomApp.ControlForm.RepBarcodeAverage();
            this.SuspendLayout();
            // 
            // repBarcode1
            // 
            this.repBarcode1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.repBarcode1.Conn = null;
            this.repBarcode1.dSerToday = new System.DateTime(((long)(0)));
            this.repBarcode1.Location = new System.Drawing.Point(6, 3);
            this.repBarcode1.Name = "repBarcode1";
            this.repBarcode1.sAccID = null;
            this.repBarcode1.Size = new System.Drawing.Size(930, 543);
            this.repBarcode1.sLogDate = null;
            this.repBarcode1.sUserID = null;
            this.repBarcode1.sUserName = null;
            this.repBarcode1.TabIndex = 0;
            // 
            // FrmRepBarcodeAverage
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(937, 545);
            this.Controls.Add(this.repBarcode1);
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "FrmRepBarcodeAverage";
            this.Text = "工序报表";
            this.ResumeLayout(false);

        }

        #endregion

        private UFIDA.U8.UAP.CustomApp.ControlForm.RepBarcodeAverage repBarcode1;
    }
}