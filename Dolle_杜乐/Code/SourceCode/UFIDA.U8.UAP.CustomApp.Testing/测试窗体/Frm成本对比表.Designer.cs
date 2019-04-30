namespace WindowsFormsApplication1
{
    partial class Frm成本对比表
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
            this.成本对比表1 = new UFIDA.U8.UAP.CustomApp.ControlForm.成本对比表();
            this.SuspendLayout();
            // 
            // 成本对比表1
            // 
            this.成本对比表1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.成本对比表1.Conn = null;
            this.成本对比表1.dSerToday = new System.DateTime(((long)(0)));
            this.成本对比表1.Location = new System.Drawing.Point(2, 2);
            this.成本对比表1.Name = "成本对比表1";
            this.成本对比表1.sAccID = null;
            this.成本对比表1.Size = new System.Drawing.Size(1100, 649);
            this.成本对比表1.sLogDate = null;
            this.成本对比表1.sUserID = null;
            this.成本对比表1.sUserName = null;
            this.成本对比表1.TabIndex = 0;
            // 
            // Frm成本对比表
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1103, 652);
            this.Controls.Add(this.成本对比表1);
            this.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.Name = "Frm成本对比表";
            this.Text = "成本对比表";
            this.ResumeLayout(false);

        }

        #endregion

        private UFIDA.U8.UAP.CustomApp.ControlForm.成本对比表 成本对比表1;


        //private UFIDA.U8.UAP.CustomApp.ControlForm.PaymentReminder PaymentReminder1;

    }
}