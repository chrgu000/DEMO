namespace WindowsFormsApplication1
{
    partial class Frm同步刷卡数据
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
            this.hr_tm_OriCardData1 = new UFIDA.U8.UAP.CustomApp.ControlForm.hr_tm_OriCardData();
            this.SuspendLayout();
            // 
            // hr_tm_OriCardData1
            // 
            this.hr_tm_OriCardData1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.hr_tm_OriCardData1.Conn = null;
            this.hr_tm_OriCardData1.dSerToday = new System.DateTime(((long)(0)));
            this.hr_tm_OriCardData1.Location = new System.Drawing.Point(12, 12);
            this.hr_tm_OriCardData1.Name = "hr_tm_OriCardData1";
            this.hr_tm_OriCardData1.sAccID = null;
            this.hr_tm_OriCardData1.Size = new System.Drawing.Size(625, 238);
            this.hr_tm_OriCardData1.sLogDate = null;
            this.hr_tm_OriCardData1.sUserID = null;
            this.hr_tm_OriCardData1.sUserName = null;
            this.hr_tm_OriCardData1.TabIndex = 0;
            // 
            // Frm同步刷卡数据
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(649, 262);
            this.Controls.Add(this.hr_tm_OriCardData1);
            this.Name = "Frm同步刷卡数据";
            this.Text = "同步刷卡数据";
            this.ResumeLayout(false);

        }

        #endregion

        private UFIDA.U8.UAP.CustomApp.ControlForm.hr_tm_OriCardData hr_tm_OriCardData1;


    }
}