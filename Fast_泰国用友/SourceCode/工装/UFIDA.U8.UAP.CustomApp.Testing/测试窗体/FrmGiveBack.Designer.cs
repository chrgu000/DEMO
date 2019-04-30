namespace WindowsFormsApplication1
{
    partial class FrmGiveBack
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
            this.giveBack1 = new UFIDA.U8.UAP.CustomApp.ControlForm.GiveBack();
            this.SuspendLayout();
            // 
            // giveBack1
            // 
            this.giveBack1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.giveBack1.Conn = null;
            this.giveBack1.dSerToday = new System.DateTime(((long)(0)));
            this.giveBack1.Location = new System.Drawing.Point(3, 1);
            this.giveBack1.Margin = new System.Windows.Forms.Padding(4);
            this.giveBack1.Name = "giveBack1";
            this.giveBack1.sAccID = null;
            this.giveBack1.Size = new System.Drawing.Size(958, 593);
            this.giveBack1.sLogDate = null;
            this.giveBack1.sUserID = null;
            this.giveBack1.sUserName = null;
            this.giveBack1.TabIndex = 0;
            // 
            // FrmGiveBack
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(961, 596);
            this.Controls.Add(this.giveBack1);
            this.Name = "FrmGiveBack";
            this.Text = "工装归还";
            this.ResumeLayout(false);

        }

        #endregion

        private UFIDA.U8.UAP.CustomApp.ControlForm.GiveBack giveBack1;


    }
}