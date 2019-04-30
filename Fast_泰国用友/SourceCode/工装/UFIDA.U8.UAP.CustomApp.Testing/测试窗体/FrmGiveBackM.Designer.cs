namespace WindowsFormsApplication1
{
    partial class FrmGiveBackM
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
            this.GiveBackM1 = new UFIDA.U8.UAP.CustomApp.ControlForm.GiveBackM();
            this.SuspendLayout();
            // 
            // GiveBackM1
            // 
            this.GiveBackM1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.GiveBackM1.Conn = null;
            this.GiveBackM1.dSerToday = new System.DateTime(((long)(0)));
            this.GiveBackM1.Location = new System.Drawing.Point(3, 1);
            this.GiveBackM1.Margin = new System.Windows.Forms.Padding(4);
            this.GiveBackM1.Name = "GiveBackM1";
            this.GiveBackM1.sAccID = null;
            this.GiveBackM1.Size = new System.Drawing.Size(958, 593);
            this.GiveBackM1.sLogDate = null;
            this.GiveBackM1.sUserID = null;
            this.GiveBackM1.sUserName = null;
            this.GiveBackM1.TabIndex = 0;
            // 
            // FrmGiveBackM
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(961, 596);
            this.Controls.Add(this.GiveBackM1);
            this.Name = "FrmGiveBackM";
            this.Text = "维修归还";
            this.ResumeLayout(false);

        }

        #endregion

        private UFIDA.U8.UAP.CustomApp.ControlForm.GiveBackM GiveBackM1;


    }
}