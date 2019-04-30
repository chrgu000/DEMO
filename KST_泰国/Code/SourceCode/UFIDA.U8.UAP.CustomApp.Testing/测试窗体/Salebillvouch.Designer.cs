namespace WindowsFormsApplication1
{
    partial class Salebillvouch
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
            this.salebillvouch1 = new UFIDA.U8.UAP.CustomApp.ControlForm.Salebillvouch();
            this.SuspendLayout();
            // 
            // salebillvouch1
            // 
            this.salebillvouch1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.salebillvouch1.Conn = null;
            this.salebillvouch1.dSerToday = new System.DateTime(((long)(0)));
            this.salebillvouch1.Location = new System.Drawing.Point(1, 1);
            this.salebillvouch1.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.salebillvouch1.Name = "salebillvouch1";
            this.salebillvouch1.sAccID = null;
            this.salebillvouch1.Size = new System.Drawing.Size(1104, 549);
            this.salebillvouch1.sLogDate = null;
            this.salebillvouch1.sUserID = null;
            this.salebillvouch1.sUserName = null;
            this.salebillvouch1.TabIndex = 0;
            // 
            // Salebillvouch
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 18F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1103, 552);
            this.Controls.Add(this.salebillvouch1);
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Name = "Salebillvouch";
            this.Text = "发货单生成发票";
            this.ResumeLayout(false);

        }

        #endregion

        private UFIDA.U8.UAP.CustomApp.ControlForm.Salebillvouch salebillvouch1;
















    }
}