namespace WindowsFormsApplication1
{
    partial class FrmBarAdjust
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
            this.barAdjust1 = new UFIDA.U8.UAP.CustomApp.ControlForm.BarAdjust();
            this.SuspendLayout();
            // 
            // barAdjust1
            // 
            this.barAdjust1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.barAdjust1.Conn = null;
            this.barAdjust1.dSerToday = new System.DateTime(((long)(0)));
            this.barAdjust1.Location = new System.Drawing.Point(2, 2);
            this.barAdjust1.Name = "barAdjust1";
            this.barAdjust1.sAccID = null;
            this.barAdjust1.Size = new System.Drawing.Size(717, 474);
            this.barAdjust1.sLogDate = null;
            this.barAdjust1.sUserID = null;
            this.barAdjust1.sUserName = null;
            this.barAdjust1.TabIndex = 0;
            // 
            // FrmBarAdjust
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(721, 477);
            this.Controls.Add(this.barAdjust1);
            this.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.Name = "FrmBarAdjust";
            this.Text = "BarAdjust";
            this.ResumeLayout(false);

        }

        #endregion

        private UFIDA.U8.UAP.CustomApp.ControlForm.BarAdjust barAdjust1;





    }
}