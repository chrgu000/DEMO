namespace WindowsFormsApplication1
{
    partial class frmPurBillVouch
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
            this.purBillVouch1 = new UFIDA.U8.UAP.CustomApp.ControlForm.PurBillVouch();
            this.SuspendLayout();
            // 
            // purBillVouch1
            // 
            this.purBillVouch1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.purBillVouch1.Conn = null;
            this.purBillVouch1.dSerToday = new System.DateTime(((long)(0)));
            this.purBillVouch1.Location = new System.Drawing.Point(3, 4);
            this.purBillVouch1.Name = "purBillVouch1";
            this.purBillVouch1.sAccID = null;
            this.purBillVouch1.Size = new System.Drawing.Size(718, 472);
            this.purBillVouch1.sLogDate = null;
            this.purBillVouch1.sUserID = null;
            this.purBillVouch1.sUserName = null;
            this.purBillVouch1.TabIndex = 0;
            // 
            // frmPurBillVouch
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(721, 477);
            this.Controls.Add(this.purBillVouch1);
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "frmPurBillVouch";
            this.Text = "PurBillVouch";
            this.ResumeLayout(false);

        }

        #endregion

        private UFIDA.U8.UAP.CustomApp.ControlForm.PurBillVouch purBillVouch1;





    }
}