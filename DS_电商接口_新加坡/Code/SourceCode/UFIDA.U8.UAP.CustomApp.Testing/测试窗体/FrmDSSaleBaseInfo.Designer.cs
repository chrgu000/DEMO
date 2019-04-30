namespace WindowsFormsApplication1
{
    partial class FrmDSSaleBaseInfo
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
            this.rep1 = new UFIDA.U8.UAP.CustomApp.ControlForm.DSSaleBaseInfo();
            this.SuspendLayout();
            // 
            // rep1
            // 
            this.rep1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.rep1.Conn = null;
            this.rep1.dSerToday = new System.DateTime(((long)(0)));
            this.rep1.Location = new System.Drawing.Point(2, 3);
            this.rep1.Name = "rep1";
            this.rep1.sAccID = null;
            this.rep1.Size = new System.Drawing.Size(717, 472);
            this.rep1.sLogDate = null;
            this.rep1.sUserID = null;
            this.rep1.sUserName = null;
            this.rep1.TabIndex = 0;
            // 
            // FrmRepForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(721, 477);
            this.Controls.Add(this.rep1);
            this.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.Name = "FrmRepForm";
            this.Text = "Rep";
            this.ResumeLayout(false);

        }

        #endregion

        private UFIDA.U8.UAP.CustomApp.ControlForm.DSSaleBaseInfo rep1;
    }
}