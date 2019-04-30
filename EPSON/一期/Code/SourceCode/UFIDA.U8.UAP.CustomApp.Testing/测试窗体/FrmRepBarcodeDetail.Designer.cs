namespace WindowsFormsApplication1
{
    partial class FrmRepBarcodeDetail
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
            this.repBarcodeDetail1 = new UFIDA.U8.UAP.CustomApp.ControlForm.RepBarcodeDetail();
            this.SuspendLayout();
            // 
            // repBarcodeDetail1
            // 
            this.repBarcodeDetail1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.repBarcodeDetail1.Conn = null;
            this.repBarcodeDetail1.dSerToday = new System.DateTime(((long)(0)));
            this.repBarcodeDetail1.Location = new System.Drawing.Point(1, 4);
            this.repBarcodeDetail1.Margin = new System.Windows.Forms.Padding(5, 5, 5, 5);
            this.repBarcodeDetail1.Name = "repBarcodeDetail1";
            this.repBarcodeDetail1.sAccID = null;
            this.repBarcodeDetail1.Size = new System.Drawing.Size(1245, 674);
            this.repBarcodeDetail1.sLogDate = null;
            this.repBarcodeDetail1.sUserID = null;
            this.repBarcodeDetail1.sUserName = null;
            this.repBarcodeDetail1.TabIndex = 0;
            // 
            // FrmRepBarcodeDetail
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1249, 681);
            this.Controls.Add(this.repBarcodeDetail1);
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Name = "FrmRepBarcodeDetail";
            this.Text = "工序报表";
            this.ResumeLayout(false);

        }

        #endregion

        private UFIDA.U8.UAP.CustomApp.ControlForm.RepBarcodeDetail repBarcodeDetail1;

    }
}