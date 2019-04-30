namespace WindowsFormsApplication1
{
    partial class FrmScrap
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
            this.scrap1 = new UFIDA.U8.UAP.CustomApp.ControlForm.Scrap();
            this.SuspendLayout();
            // 
            // scrap1
            // 
            this.scrap1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.scrap1.Conn = null;
            this.scrap1.dSerToday = new System.DateTime(((long)(0)));
            this.scrap1.Location = new System.Drawing.Point(-1, 2);
            this.scrap1.Margin = new System.Windows.Forms.Padding(4);
            this.scrap1.Name = "scrap1";
            this.scrap1.sAccID = null;
            this.scrap1.Size = new System.Drawing.Size(964, 594);
            this.scrap1.sLogDate = null;
            this.scrap1.sUserID = null;
            this.scrap1.sUserName = null;
            this.scrap1.TabIndex = 0;
            // 
            // FrmScrap
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(961, 596);
            this.Controls.Add(this.scrap1);
            this.Name = "FrmScrap";
            this.Text = "工装报废";
            this.ResumeLayout(false);

        }

        #endregion

        private UFIDA.U8.UAP.CustomApp.ControlForm.Scrap scrap1;


    }
}