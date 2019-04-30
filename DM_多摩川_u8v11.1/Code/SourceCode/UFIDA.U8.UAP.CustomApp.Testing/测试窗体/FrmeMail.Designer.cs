namespace WindowsFormsApplication1
{
    partial class FrmeMail
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
            this.eMail1 = new UFIDA.U8.UAP.CustomApp.ControlForm.eMail();
            this.SuspendLayout();
            // 
            // eMail1
            // 
            this.eMail1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.eMail1.Conn = null;
            this.eMail1.dSerToday = new System.DateTime(((long)(0)));
            this.eMail1.Location = new System.Drawing.Point(12, 12);
            this.eMail1.Name = "eMail1";
            this.eMail1.sAccID = null;
            this.eMail1.Size = new System.Drawing.Size(914, 518);
            this.eMail1.sLogDate = null;
            this.eMail1.sUserID = null;
            this.eMail1.sUserName = null;
            this.eMail1.TabIndex = 0;
            // 
            // FrmeMail
            // 
            this.ClientSize = new System.Drawing.Size(938, 542);
            this.Controls.Add(this.eMail1);
            this.Name = "FrmeMail";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.ResumeLayout(false);

        }

        #endregion

        private UFIDA.U8.UAP.CustomApp.ControlForm.eMail eMail1;






    }
}