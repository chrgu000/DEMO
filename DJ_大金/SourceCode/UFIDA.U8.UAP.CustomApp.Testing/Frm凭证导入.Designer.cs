namespace WindowsFormsApplication1
{
    partial class Frm凭证导入
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
            this.gL_accvouch1 = new UFIDA.U8.UAP.CustomApp.ControlForm.GL_accvouch();
            this.SuspendLayout();
            // 
            // gL_accvouch1
            // 
            this.gL_accvouch1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.gL_accvouch1.Conn = null;
            this.gL_accvouch1.dSerToday = new System.DateTime(((long)(0)));
            this.gL_accvouch1.Location = new System.Drawing.Point(1, 1);
            this.gL_accvouch1.Name = "gL_accvouch1";
            this.gL_accvouch1.sAccID = null;
            this.gL_accvouch1.Size = new System.Drawing.Size(888, 518);
            this.gL_accvouch1.sLogDate = null;
            this.gL_accvouch1.sUserID = null;
            this.gL_accvouch1.sUserName = null;
            this.gL_accvouch1.TabIndex = 0;
            // 
            // Frm凭证导入
            // 
            this.ClientSize = new System.Drawing.Size(888, 524);
            this.Controls.Add(this.gL_accvouch1);
            this.Name = "Frm凭证导入";
            this.ResumeLayout(false);

        }

        #endregion

        private UFIDA.U8.UAP.CustomApp.ControlForm.GL_accvouch gL_accvouch1;



    }
}

