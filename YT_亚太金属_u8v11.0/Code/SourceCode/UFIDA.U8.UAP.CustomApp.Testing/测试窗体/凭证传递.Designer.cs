namespace WindowsFormsApplication1
{
    partial class Frm凭证传递
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
            this.凭证传递1 = new UFIDA.U8.UAP.CustomApp.ControlForm.凭证传递();
            this.SuspendLayout();
            // 
            // 凭证传递1
            // 
            this.凭证传递1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.凭证传递1.Conn = null;
            this.凭证传递1.dSerToday = new System.DateTime(((long)(0)));
            this.凭证传递1.Location = new System.Drawing.Point(12, 6);
            this.凭证传递1.Name = "凭证传递1";
            this.凭证传递1.sAccID = null;
            this.凭证传递1.Size = new System.Drawing.Size(881, 400);
            this.凭证传递1.sLogDate = null;
            this.凭证传递1.sUserID = null;
            this.凭证传递1.sUserName = null;
            this.凭证传递1.TabIndex = 0;
            // 
            // Frm凭证传递
            // 
            this.ClientSize = new System.Drawing.Size(895, 405);
            this.Controls.Add(this.凭证传递1);
            this.Name = "Frm凭证传递";
            this.ResumeLayout(false);

        }

        #endregion

        private UFIDA.U8.UAP.CustomApp.ControlForm.凭证传递 凭证传递1;





    }
}