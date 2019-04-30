namespace WindowsFormsApplication1
{
    partial class Frm分配规则
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
            this.分配规则1 = new UFIDA.U8.UAP.CustomApp.ControlForm.共耗费用分配规则();
            this.SuspendLayout();
            // 
            // 分配规则1
            // 
            this.分配规则1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.分配规则1.Conn = null;
            this.分配规则1.dSerToday = new System.DateTime(((long)(0)));
            this.分配规则1.Location = new System.Drawing.Point(2, 12);
            this.分配规则1.Name = "分配规则1";
            this.分配规则1.sAccID = null;
            this.分配规则1.Size = new System.Drawing.Size(934, 528);
            this.分配规则1.sLogDate = null;
            this.分配规则1.sUserID = null;
            this.分配规则1.sUserName = null;
            this.分配规则1.TabIndex = 0;
            // 
            // Frm分配规则
            // 
            this.ClientSize = new System.Drawing.Size(938, 542);
            this.Controls.Add(this.分配规则1);
            this.Name = "Frm分配规则";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.ResumeLayout(false);

        }

        #endregion

        private UFIDA.U8.UAP.CustomApp.ControlForm.共耗费用分配规则 分配规则1;





    }
}