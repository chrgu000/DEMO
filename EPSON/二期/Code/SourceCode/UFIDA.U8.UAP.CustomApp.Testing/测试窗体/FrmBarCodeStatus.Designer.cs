namespace WindowsFormsApplication1
{
    partial class FrmBarCodeStatus
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
            this.barCodeStatus1 = new UFIDA.U8.UAP.CustomApp.ControlForm.BarCodeStatus();
            this.SuspendLayout();
            // 
            // barCodeStatus1
            // 
            this.barCodeStatus1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.barCodeStatus1.Conn = null;
            this.barCodeStatus1.dSerToday = new System.DateTime(((long)(0)));
            this.barCodeStatus1.Location = new System.Drawing.Point(1, 0);
            this.barCodeStatus1.Name = "barCodeStatus1";
            this.barCodeStatus1.sAccID = null;
            this.barCodeStatus1.Size = new System.Drawing.Size(1085, 559);
            this.barCodeStatus1.sLogDate = null;
            this.barCodeStatus1.sUserID = null;
            this.barCodeStatus1.sUserName = null;
            this.barCodeStatus1.TabIndex = 0;
            // 
            // BarCodeStatus
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1087, 564);
            this.Controls.Add(this.barCodeStatus1);
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "BarCodeStatus";
            this.Text = "条码状态";
            this.ResumeLayout(false);

        }

        #endregion

        private UFIDA.U8.UAP.CustomApp.ControlForm.BarCodeStatus barCodeStatus1;








    }
}