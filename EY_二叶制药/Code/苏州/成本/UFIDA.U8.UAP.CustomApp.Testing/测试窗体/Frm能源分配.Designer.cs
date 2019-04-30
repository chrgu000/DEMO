namespace WindowsFormsApplication1
{
    partial class Frm能源分配
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
            this.能源分配1 = new UFIDA.U8.UAP.CustomApp.ControlForm.能源分配();
            this.SuspendLayout();
            // 
            // 能源分配1
            // 
            this.能源分配1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.能源分配1.Conn = null;
            this.能源分配1.dSerToday = new System.DateTime(((long)(0)));
            this.能源分配1.Location = new System.Drawing.Point(1, 7);
            this.能源分配1.Margin = new System.Windows.Forms.Padding(4);
            this.能源分配1.Name = "能源分配1";
            this.能源分配1.sAccID = null;
            this.能源分配1.Size = new System.Drawing.Size(929, 522);
            this.能源分配1.sLogDate = null;
            this.能源分配1.sUserID = null;
            this.能源分配1.sUserName = null;
            this.能源分配1.TabIndex = 0;
            // 
            // Frm能源分配
            // 
            this.ClientSize = new System.Drawing.Size(938, 542);
            this.Controls.Add(this.能源分配1);
            this.Name = "Frm能源分配";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.ResumeLayout(false);

        }

        #endregion

        private UFIDA.U8.UAP.CustomApp.ControlForm.能源分配 能源分配1;










    }
}