namespace WindowsFormsApplication1
{
    partial class FrmReport
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
            this.Report1 = new UFIDA.U8.UAP.CustomApp.ControlForm.Report();
            this.SuspendLayout();
            // 
            // Report1
            // 
            this.Report1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.Report1.Conn = null;
            this.Report1.dSerToday = new System.DateTime(((long)(0)));
            this.Report1.Location = new System.Drawing.Point(2, 1);
            this.Report1.Name = "Report1";
            this.Report1.sAccID = null;
            this.Report1.Size = new System.Drawing.Size(718, 474);
            this.Report1.sLogDate = null;
            this.Report1.sUserID = null;
            this.Report1.sUserName = null;
            this.Report1.TabIndex = 0;
            // 
            // FrmReport
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(721, 477);
            this.Controls.Add(this.Report1);
            this.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.Name = "FrmReport";
            this.Text = "报表";
            this.ResumeLayout(false);

        }

        #endregion

        private UFIDA.U8.UAP.CustomApp.ControlForm.Report Report1;


    }
}