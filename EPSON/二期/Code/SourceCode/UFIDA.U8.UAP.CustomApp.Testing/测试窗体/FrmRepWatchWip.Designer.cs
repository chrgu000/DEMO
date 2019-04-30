namespace WindowsFormsApplication1
{
    partial class FrmRepWatchWip
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
            this.repSale1 = new UFIDA.U8.UAP.CustomApp.ControlForm.RepWatchWip();
            this.SuspendLayout();
            // 
            // repSale1
            // 
            this.repSale1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.repSale1.Conn = null;
            this.repSale1.dSerToday = new System.DateTime(((long)(0)));
            this.repSale1.Location = new System.Drawing.Point(2, 13);
            this.repSale1.Margin = new System.Windows.Forms.Padding(4);
            this.repSale1.Name = "repSale1";
            this.repSale1.sAccID = null;
            this.repSale1.Size = new System.Drawing.Size(960, 570);
            this.repSale1.sLogDate = null;
            this.repSale1.sUserID = null;
            this.repSale1.sUserName = null;
            this.repSale1.TabIndex = 0;
            // 
            // FrmRepSale
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(961, 596);
            this.Controls.Add(this.repSale1);
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Name = "FrmRepSale";
            this.Text = "Watch WIP";
            this.Load += new System.EventHandler(this.FrmRepWatchWip_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private UFIDA.U8.UAP.CustomApp.ControlForm.RepWatchWip repSale1;






    }
}