namespace WindowsFormsApplication1
{
    partial class Frm成本分配表
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
            this.成本分配表1 = new UFIDA.U8.UAP.CustomApp.ControlForm.成本分配表();
            this.SuspendLayout();
            // 
            // 成本分配表1
            // 
            this.成本分配表1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.成本分配表1.Conn = null;
            this.成本分配表1.dSerToday = new System.DateTime(((long)(0)));
            this.成本分配表1.Location = new System.Drawing.Point(0, 13);
            this.成本分配表1.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.成本分配表1.Name = "成本分配表1";
            this.成本分配表1.sAccID = null;
            this.成本分配表1.Size = new System.Drawing.Size(935, 533);
            this.成本分配表1.sLogDate = null;
            this.成本分配表1.sUserID = null;
            this.成本分配表1.sUserName = null;
            this.成本分配表1.TabIndex = 0;
            // 
            // Frm成本分配表
            // 
            this.ClientSize = new System.Drawing.Size(938, 542);
            this.Controls.Add(this.成本分配表1);
            this.Name = "Frm成本分配表";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.ResumeLayout(false);

        }

        #endregion

        private UFIDA.U8.UAP.CustomApp.ControlForm.成本分配表 成本分配表1;






    }
}