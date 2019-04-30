namespace WindowsFormsApplication1
{
    partial class frmChkValue01
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
            this.chkValue011 = new UFIDA.U8.UAP.CustomApp.ControlForm.ChkValue01();
            this.SuspendLayout();
            // 
            // chkValue011
            // 
            this.chkValue011.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.chkValue011.Conn = null;
            this.chkValue011.dSerToday = new System.DateTime(((long)(0)));
            this.chkValue011.Location = new System.Drawing.Point(1, 1);
            this.chkValue011.Name = "chkValue011";
            this.chkValue011.sAccID = null;
            this.chkValue011.Size = new System.Drawing.Size(1039, 618);
            this.chkValue011.sLogDate = null;
            this.chkValue011.sUserID = null;
            this.chkValue011.sUserName = null;
            this.chkValue011.TabIndex = 0;
            // 
            // frmChkValue01
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1041, 621);
            this.Controls.Add(this.chkValue011);
            this.Name = "frmChkValue01";
            this.Text = "frmChkValue01";
            this.ResumeLayout(false);

        }

        #endregion

        private UFIDA.U8.UAP.CustomApp.ControlForm.ChkValue01 chkValue011;


    }
}