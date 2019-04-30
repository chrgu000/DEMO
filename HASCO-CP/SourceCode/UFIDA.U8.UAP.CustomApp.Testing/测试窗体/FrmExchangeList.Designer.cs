namespace WindowsFormsApplication1
{
    partial class FrmExchangeList
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
            this.exchangeList1 = new UFIDA.U8.UAP.CustomApp.ControlForm.ExchangeList();
            this.SuspendLayout();
            // 
            // exchangeList1
            // 
            this.exchangeList1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.exchangeList1.Conn = null;
            this.exchangeList1.dSerToday = new System.DateTime(((long)(0)));
            this.exchangeList1.Location = new System.Drawing.Point(3, 2);
            this.exchangeList1.Name = "exchangeList1";
            this.exchangeList1.sAccID = null;
            this.exchangeList1.Size = new System.Drawing.Size(892, 380);
            this.exchangeList1.sLogDate = null;
            this.exchangeList1.sUserID = null;
            this.exchangeList1.sUserName = null;
            this.exchangeList1.TabIndex = 0;
            // 
            // FrmExchangeList
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(897, 383);
            this.Controls.Add(this.exchangeList1);
            this.Name = "FrmExchangeList";
            this.Text = "汇兑损益凭证生单";
            this.ResumeLayout(false);

        }

        #endregion

        private UFIDA.U8.UAP.CustomApp.ControlForm.ExchangeList exchangeList1;






    }
}