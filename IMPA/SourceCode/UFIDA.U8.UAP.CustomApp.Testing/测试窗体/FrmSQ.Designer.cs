namespace WindowsFormsApplication1
{
    partial class FrmSQ
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
            this.sq1 = new UFIDA.U8.UAP.CustomApp.ControlForm.SQ();
            this.SuspendLayout();
            // 
            // sq1
            // 
            this.sq1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.sq1.Conn = null;
            this.sq1.dSerToday = new System.DateTime(((long)(0)));
            this.sq1.Location = new System.Drawing.Point(2, 3);
            this.sq1.Name = "sq1";
            this.sq1.sAccID = null;
            this.sq1.Size = new System.Drawing.Size(1422, 900);
            this.sq1.sLogDate = null;
            this.sq1.sUserID = null;
            this.sq1.sUserName = null;
            this.sq1.TabIndex = 0;
            // 
            // FrmPurchasePlan
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1426, 905);
            this.Controls.Add(this.sq1);
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "FrmPurchasePlan";
            this.Text = "SQ";
            this.ResumeLayout(false);

        }

        #endregion

        private UFIDA.U8.UAP.CustomApp.ControlForm.SQ sq1;
    }
}