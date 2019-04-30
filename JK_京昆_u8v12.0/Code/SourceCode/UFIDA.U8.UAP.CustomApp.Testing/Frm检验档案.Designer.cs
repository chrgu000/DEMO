namespace WindowsFormsApplication1
{
    partial class Frm检验档案
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
            this.检验档案1 = new UFIDA.U8.UAP.CustomApp.ControlForm.Frm检验档案();
            this.SuspendLayout();
            // 
            // 预付款1
            // 
            this.检验档案1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.检验档案1.Conn = null;
            this.检验档案1.dSerToday = new System.DateTime(((long)(0)));
            this.检验档案1.Location = new System.Drawing.Point(-3, 12);
            this.检验档案1.Name = "检验档案";
            this.检验档案1.sAccID = null;
            this.检验档案1.Size = new System.Drawing.Size(898, 459);
            this.检验档案1.sLogDate = null;
            this.检验档案1.sUserID = null;
            this.检验档案1.sUserName = null;
            this.检验档案1.TabIndex = 0;
            // 
            // 检验档案
            // 
            this.ClientSize = new System.Drawing.Size(896, 471);
            this.Controls.Add(this.检验档案1);
            this.Name = "检验档案";
            this.ResumeLayout(false);

        }

        #endregion

        private UFIDA.U8.UAP.CustomApp.ControlForm.Frm检验档案 检验档案1;




    }
}

