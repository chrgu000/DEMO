namespace WindowsFormsApplication1
{
    partial class FrmExportData
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
            this.purchasePlan1 = new UFIDA.U8.UAP.CustomApp.ControlForm.ExportData();
            this.SuspendLayout();
            // 
            // purchasePlan1
            // 
            this.purchasePlan1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.purchasePlan1.Conn = null;
            this.purchasePlan1.dSerToday = new System.DateTime(((long)(0)));
            this.purchasePlan1.Location = new System.Drawing.Point(2, 3);
            this.purchasePlan1.Name = "purchasePlan1";
            this.purchasePlan1.sAccID = null;
            this.purchasePlan1.Size = new System.Drawing.Size(717, 472);
            this.purchasePlan1.sLogDate = null;
            this.purchasePlan1.sUserID = null;
            this.purchasePlan1.sUserName = null;
            this.purchasePlan1.TabIndex = 0;
            // 
            // FrmExportData
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(721, 477);
            this.Controls.Add(this.purchasePlan1);
            this.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.Name = "FrmExportData";
            this.Text = "FrmExportData";
            this.ResumeLayout(false);

        }

        #endregion

        private UFIDA.U8.UAP.CustomApp.ControlForm.ExportData purchasePlan1;
    }
}