namespace WindowsFormsApplication1
{
    partial class FrmIQCResult
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
            this.barIQCResult1 = new UFIDA.U8.UAP.CustomApp.ControlForm.IQCResult();
            this.SuspendLayout();
            // 
            // barIQCResult1
            // 
            this.barIQCResult1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.barIQCResult1.Conn = null;
            this.barIQCResult1.dSerToday = new System.DateTime(((long)(0)));
            this.barIQCResult1.Location = new System.Drawing.Point(4, 6);
            this.barIQCResult1.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.barIQCResult1.Name = "barIQCResult1";
            this.barIQCResult1.sAccID = null;
            this.barIQCResult1.Size = new System.Drawing.Size(1077, 707);
            this.barIQCResult1.sLogDate = null;
            this.barIQCResult1.sUserID = null;
            this.barIQCResult1.sUserName = null;
            this.barIQCResult1.TabIndex = 0;
            // 
            // FrmIQCResult
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 18F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1082, 716);
            this.Controls.Add(this.barIQCResult1);
            this.Name = "FrmIQCResult";
            this.Text = "IQC Result";
            this.ResumeLayout(false);

        }

        #endregion

        private UFIDA.U8.UAP.CustomApp.ControlForm.IQCResult barIQCResult1;






    }
}