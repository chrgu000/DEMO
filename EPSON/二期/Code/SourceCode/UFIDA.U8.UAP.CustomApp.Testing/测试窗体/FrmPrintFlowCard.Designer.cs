namespace WindowsFormsApplication1
{
    partial class FrmPrintFlowCard
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
            this.printFlowCard1 = new UFIDA.U8.UAP.CustomApp.ControlForm.PrintFlowCard();
            this.SuspendLayout();
            // 
            // printFlowCard1
            // 
            this.printFlowCard1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.printFlowCard1.Conn = null;
            this.printFlowCard1.dSerToday = new System.DateTime(((long)(0)));
            this.printFlowCard1.Location = new System.Drawing.Point(2, 1);
            this.printFlowCard1.Margin = new System.Windows.Forms.Padding(4);
            this.printFlowCard1.Name = "printFlowCard1";
            this.printFlowCard1.sAccID = null;
            this.printFlowCard1.Size = new System.Drawing.Size(1202, 619);
            this.printFlowCard1.sLogDate = null;
            this.printFlowCard1.sUserID = null;
            this.printFlowCard1.sUserName = null;
            this.printFlowCard1.TabIndex = 0;
            // 
            // FrmPrintFlowCard
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1207, 627);
            this.Controls.Add(this.printFlowCard1);
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Name = "FrmPrintFlowCard";
            this.Text = "printFlowCard";
            this.ResumeLayout(false);

        }

        #endregion

        private UFIDA.U8.UAP.CustomApp.ControlForm.PrintFlowCard printFlowCard1;





    }
}