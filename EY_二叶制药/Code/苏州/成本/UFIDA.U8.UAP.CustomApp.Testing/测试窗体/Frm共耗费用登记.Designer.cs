namespace WindowsFormsApplication1
{
    partial class Frm共耗费用登记
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
            this.费用登记1 = new UFIDA.U8.UAP.CustomApp.ControlForm.共耗费用登记();
            this.SuspendLayout();
            // 
            // 费用登记1
            // 
            this.费用登记1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.费用登记1.Conn = null;
            this.费用登记1.dSerToday = new System.DateTime(((long)(0)));
            this.费用登记1.Location = new System.Drawing.Point(12, 12);
            this.费用登记1.Name = "费用登记1";
            this.费用登记1.sAccID = null;
            this.费用登记1.Size = new System.Drawing.Size(914, 518);
            this.费用登记1.sLogDate = null;
            this.费用登记1.sUserID = null;
            this.费用登记1.sUserName = null;
            this.费用登记1.TabIndex = 0;
            // 
            // Frm分配规则
            // 
            this.ClientSize = new System.Drawing.Size(938, 542);
            this.Controls.Add(this.费用登记1);
            this.Name = "Frm分配规则";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.ResumeLayout(false);

        }

        #endregion

        private UFIDA.U8.UAP.CustomApp.ControlForm.共耗费用登记 费用登记1;






    }
}