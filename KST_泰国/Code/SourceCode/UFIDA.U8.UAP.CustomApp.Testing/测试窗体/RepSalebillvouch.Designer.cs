namespace WindowsFormsApplication1
{
    partial class RepSalebillvouch
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
            this.repSalebillvouch1 = new UFIDA.U8.UAP.CustomApp.ControlForm.RepSalebillvouch();
            this.SuspendLayout();
            // 
            // repSalebillvouch1
            // 
            this.repSalebillvouch1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.repSalebillvouch1.Conn = null;
            this.repSalebillvouch1.dSerToday = new System.DateTime(((long)(0)));
            this.repSalebillvouch1.Location = new System.Drawing.Point(0, 4);
            this.repSalebillvouch1.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.repSalebillvouch1.Name = "repSalebillvouch1";
            this.repSalebillvouch1.sAccID = null;
            this.repSalebillvouch1.Size = new System.Drawing.Size(1104, 542);
            this.repSalebillvouch1.sLogDate = null;
            this.repSalebillvouch1.sUserID = null;
            this.repSalebillvouch1.sUserName = null;
            this.repSalebillvouch1.TabIndex = 0;
            // 
            // RepSalebillvouch
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 18F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1104, 551);
            this.Controls.Add(this.repSalebillvouch1);
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Name = "RepSalebillvouch";
            this.Text = "发票报表";
            this.ResumeLayout(false);

        }

        #endregion

        private UFIDA.U8.UAP.CustomApp.ControlForm.RepSalebillvouch repSalebillvouch1;
















    }
}