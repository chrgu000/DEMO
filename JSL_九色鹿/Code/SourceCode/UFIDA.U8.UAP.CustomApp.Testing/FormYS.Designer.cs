namespace WindowsFormsApplication1
{
    partial class FormYS
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
            this.sa_BOMAll1 = new UFIDA.U8.UAP.CustomApp.ControlForm.YS();
            this.SuspendLayout();
            // 
            // sa_BOMAll1
            // 
            this.sa_BOMAll1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.sa_BOMAll1.Conn = null;
            this.sa_BOMAll1.dSerToday = new System.DateTime(((long)(0)));
            this.sa_BOMAll1.Location = new System.Drawing.Point(0, 12);
            this.sa_BOMAll1.Name = "销售成本确认表";
            this.sa_BOMAll1.sAccID = null;
            this.sa_BOMAll1.Size = new System.Drawing.Size(903, 439);
            this.sa_BOMAll1.sLogDate = null;
            this.sa_BOMAll1.sUserID = null;
            this.sa_BOMAll1.sUserName = null;
            this.sa_BOMAll1.TabIndex = 0;
            // 
            // FormSa_BOMAll
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(904, 449);
            this.Controls.Add(this.sa_BOMAll1);
            this.Name = "销售成本确认表";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.ResumeLayout(false);

        }

        #endregion

        private UFIDA.U8.UAP.CustomApp.ControlForm.YS sa_BOMAll1;




    }
}

