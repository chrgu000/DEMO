namespace WindowsFormsApplication1
{
    partial class FrmProLine
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
            this.proLine1 = new UFIDA.U8.UAP.CustomApp.ControlForm.ProLine();
            this.SuspendLayout();
            // 
            // proLine1
            // 
            this.proLine1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.proLine1.Conn = null;
            this.proLine1.dSerToday = new System.DateTime(((long)(0)));
            this.proLine1.Location = new System.Drawing.Point(1, 4);
            this.proLine1.Name = "proLine1";
            this.proLine1.sAccID = null;
            this.proLine1.Size = new System.Drawing.Size(720, 477);
            this.proLine1.sLogDate = null;
            this.proLine1.sUserID = null;
            this.proLine1.sUserName = null;
            this.proLine1.TabIndex = 0;
            // 
            // FrmProLine
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(721, 477);
            this.Controls.Add(this.proLine1);
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "FrmProLine";
            this.Text = "产品线";
            this.ResumeLayout(false);

        }

        #endregion

        private UFIDA.U8.UAP.CustomApp.ControlForm.ProLine proLine1;







    }
}