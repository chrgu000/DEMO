namespace WindowsFormsApplication1
{
    partial class Frm标准工时
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
            this.标准工时1 = new UFIDA.U8.UAP.CustomApp.ControlForm.标准工时();
            this.SuspendLayout();
            // 
            // 标准工时1
            // 
            this.标准工时1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.标准工时1.Conn = null;
            this.标准工时1.dSerToday = new System.DateTime(((long)(0)));
            this.标准工时1.Location = new System.Drawing.Point(3, 13);
            this.标准工时1.Margin = new System.Windows.Forms.Padding(4);
            this.标准工时1.Name = "标准工时1";
            this.标准工时1.sAccID = null;
            this.标准工时1.Size = new System.Drawing.Size(956, 578);
            this.标准工时1.sLogDate = null;
            this.标准工时1.sUserID = null;
            this.标准工时1.sUserName = null;
            this.标准工时1.TabIndex = 0;
            // 
            // Frm标准工时
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(961, 596);
            this.Controls.Add(this.标准工时1);
            this.Name = "Frm标准工时";
            this.Text = "标准工时";
            this.ResumeLayout(false);

        }

        #endregion

        private UFIDA.U8.UAP.CustomApp.ControlForm.标准工时 标准工时1;

        //private UFIDA.U8.UAP.CustomApp.ControlForm.PaymentReminder PaymentReminder1;

    }
}