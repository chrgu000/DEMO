namespace WindowsFormsApplication1
{
    partial class FrmRepSTFGOS
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
            this.repSTFGOS1 = new UFIDA.U8.UAP.CustomApp.ControlForm.RepSTFGOS();
            this.SuspendLayout();
            // 
            // repSTFGOS1
            // 
            this.repSTFGOS1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.repSTFGOS1.Conn = null;
            this.repSTFGOS1.dSerToday = new System.DateTime(((long)(0)));
            this.repSTFGOS1.Location = new System.Drawing.Point(4, 2);
            this.repSTFGOS1.Margin = new System.Windows.Forms.Padding(4);
            this.repSTFGOS1.Name = "repSTFGOS1";
            this.repSTFGOS1.sAccID = null;
            this.repSTFGOS1.Size = new System.Drawing.Size(955, 593);
            this.repSTFGOS1.sLogDate = null;
            this.repSTFGOS1.sUserID = null;
            this.repSTFGOS1.sUserName = null;
            this.repSTFGOS1.TabIndex = 0;
            // 
            // FrmRepSTFGOS
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(961, 596);
            this.Controls.Add(this.repSTFGOS1);
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Name = "FrmRepSTFGOS";
            this.Text = "ST FG(OS)";
            this.ResumeLayout(false);

        }

        #endregion

        private UFIDA.U8.UAP.CustomApp.ControlForm.RepSTFGOS repSTFGOS1;








    }
}