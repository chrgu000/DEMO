namespace WindowsFormsApplication1
{
    partial class Frm采集器操作员
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
            this.smartUser1 = new UFIDA.U8.UAP.CustomApp.ControlForm.SmartUser();
            this.SuspendLayout();
            // 
            // smartUser1
            // 
            this.smartUser1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.smartUser1.Conn = null;
            this.smartUser1.dSerToday = new System.DateTime(((long)(0)));
            this.smartUser1.Location = new System.Drawing.Point(12, 12);
            this.smartUser1.Name = "smartUser1";
            this.smartUser1.sAccID = null;
            this.smartUser1.Size = new System.Drawing.Size(922, 523);
            this.smartUser1.sLogDate = null;
            this.smartUser1.sUserID = null;
            this.smartUser1.sUserName = null;
            this.smartUser1.TabIndex = 0;
            // 
            // Frm采集器操作员
            // 
            this.ClientSize = new System.Drawing.Size(938, 542);
            this.Controls.Add(this.smartUser1);
            this.Name = "Frm采集器操作员";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.ResumeLayout(false);

        }

        #endregion

        private UFIDA.U8.UAP.CustomApp.ControlForm.SmartUser smartUser1;





    }
}