namespace WindowsFormsApplication1
{
    partial class FrmInvProcess
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
            this.invProcess1 = new UFIDA.U8.UAP.CustomApp.ControlForm.InvProcess();
            this.SuspendLayout();
            // 
            // invProcess1
            // 
            this.invProcess1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.invProcess1.Conn = null;
            this.invProcess1.dSerToday = new System.DateTime(((long)(0)));
            this.invProcess1.Location = new System.Drawing.Point(1, 9);
            this.invProcess1.Name = "invProcess1";
            this.invProcess1.sAccID = null;
            this.invProcess1.Size = new System.Drawing.Size(717, 463);
            this.invProcess1.sLogDate = null;
            this.invProcess1.sUserID = null;
            this.invProcess1.sUserName = null;
            this.invProcess1.TabIndex = 0;
            // 
            // FrmInvProcess
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(721, 477);
            this.Controls.Add(this.invProcess1);
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "FrmInvProcess";
            this.Text = "InvProcess";
            this.ResumeLayout(false);

        }

        #endregion

        private UFIDA.U8.UAP.CustomApp.ControlForm.InvProcess invProcess1;


    }
}