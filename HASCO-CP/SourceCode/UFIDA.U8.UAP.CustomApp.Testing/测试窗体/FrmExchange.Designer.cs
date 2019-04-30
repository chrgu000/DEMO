namespace WindowsFormsApplication1
{
    partial class FrmExchange
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
            this.exchange1 = new UFIDA.U8.UAP.CustomApp.ControlForm.Exchange();
            this.SuspendLayout();
            // 
            // exchange1
            // 
            this.exchange1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.exchange1.Conn = null;
            this.exchange1.dSerToday = new System.DateTime(((long)(0)));
            this.exchange1.Location = new System.Drawing.Point(3, 3);
            this.exchange1.Name = "exchange1";
            this.exchange1.sAccID = null;
            this.exchange1.Size = new System.Drawing.Size(891, 376);
            this.exchange1.sLogDate = null;
            this.exchange1.sUserID = null;
            this.exchange1.sUserName = null;
            this.exchange1.TabIndex = 0;
            // 
            // FrmExchange
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(897, 383);
            this.Controls.Add(this.exchange1);
            this.Name = "FrmExchange";
            this.Text = "汇兑损益";
            this.ResumeLayout(false);

        }

        #endregion

        private UFIDA.U8.UAP.CustomApp.ControlForm.Exchange exchange1;





    }
}