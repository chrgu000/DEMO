namespace WindowsFormsApplication1
{
    partial class frmSaleBillVouchCSV
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
            this.saleBillVouchCSV1 = new UFIDA.U8.UAP.CustomApp.ControlForm.SaleBillVouchCSV();
            this.SuspendLayout();
            // 
            // saleBillVouchCSV1
            // 
            this.saleBillVouchCSV1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.saleBillVouchCSV1.Conn = null;
            this.saleBillVouchCSV1.dSerToday = new System.DateTime(((long)(0)));
            this.saleBillVouchCSV1.Location = new System.Drawing.Point(13, 0);
            this.saleBillVouchCSV1.Margin = new System.Windows.Forms.Padding(4);
            this.saleBillVouchCSV1.Name = "saleBillVouchCSV1";
            this.saleBillVouchCSV1.sAccID = null;
            this.saleBillVouchCSV1.Size = new System.Drawing.Size(935, 593);
            this.saleBillVouchCSV1.sLogDate = null;
            this.saleBillVouchCSV1.sUserID = null;
            this.saleBillVouchCSV1.sUserName = null;
            this.saleBillVouchCSV1.TabIndex = 0;
            // 
            // frmSaleBillVouchCSV
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(961, 596);
            this.Controls.Add(this.saleBillVouchCSV1);
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Name = "frmSaleBillVouchCSV";
            this.Text = "saleBillVouch1";
            this.ResumeLayout(false);

        }

        #endregion

        private UFIDA.U8.UAP.CustomApp.ControlForm.SaleBillVouchCSV saleBillVouchCSV1;





    }
}