namespace WindowsFormsApplication1
{
    partial class FrmInvProcessPrice
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
            this.invProcessPrice1 = new UFIDA.U8.UAP.CustomApp.ControlForm.InvProcessPrice();
            this.SuspendLayout();
            // 
            // invProcessPrice1
            // 
            this.invProcessPrice1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.invProcessPrice1.Conn = null;
            this.invProcessPrice1.dSerToday = new System.DateTime(((long)(0)));
            this.invProcessPrice1.Location = new System.Drawing.Point(3, 4);
            this.invProcessPrice1.Margin = new System.Windows.Forms.Padding(4);
            this.invProcessPrice1.Name = "invProcessPrice1";
            this.invProcessPrice1.sAccID = null;
            this.invProcessPrice1.Size = new System.Drawing.Size(957, 592);
            this.invProcessPrice1.sLogDate = null;
            this.invProcessPrice1.sUserID = null;
            this.invProcessPrice1.sUserName = null;
            this.invProcessPrice1.TabIndex = 0;
            // 
            // FrmInvProcessPrice
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(961, 596);
            this.Controls.Add(this.invProcessPrice1);
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Name = "FrmInvProcessPrice";
            this.Text = "InvProcessPrice";
            this.ResumeLayout(false);

        }

        #endregion

        private UFIDA.U8.UAP.CustomApp.ControlForm.InvProcessPrice invProcessPrice1;




    }
}