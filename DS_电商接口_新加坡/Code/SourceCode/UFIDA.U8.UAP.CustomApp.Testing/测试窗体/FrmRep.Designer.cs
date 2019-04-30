namespace WindowsFormsApplication1
{
    partial class FrmRep
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
            this.repCreateDisInfo1 = new UFIDA.U8.UAP.CustomApp.ControlForm.RepCreateDisInfo();
            this.SuspendLayout();
            // 
            // repCreateDisInfo1
            // 
            this.repCreateDisInfo1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.repCreateDisInfo1.Conn = null;
            this.repCreateDisInfo1.dSerToday = new System.DateTime(((long)(0)));
            this.repCreateDisInfo1.Location = new System.Drawing.Point(1, 3);
            this.repCreateDisInfo1.Name = "repCreateDisInfo1";
            this.repCreateDisInfo1.sAccID = null;
            this.repCreateDisInfo1.Size = new System.Drawing.Size(717, 472);
            this.repCreateDisInfo1.sLogDate = null;
            this.repCreateDisInfo1.sUserID = null;
            this.repCreateDisInfo1.sUserName = null;
            this.repCreateDisInfo1.TabIndex = 0;
            // 
            // FrmRep
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(721, 477);
            this.Controls.Add(this.repCreateDisInfo1);
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "FrmRep";
            this.Text = "Rep";
            this.ResumeLayout(false);

        }

        #endregion

        private UFIDA.U8.UAP.CustomApp.ControlForm.RepCreateDisInfo repCreateDisInfo1;

    }
}