namespace WindowsFormsApplication1
{
    partial class FrmPrintBarLabel
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
            this.printBarLabel1 = new UFIDA.U8.UAP.CustomApp.ControlForm.PrintBarLabel();
            this.SuspendLayout();
            // 
            // printBarLabel1
            // 
            this.printBarLabel1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.printBarLabel1.Conn = null;
            this.printBarLabel1.dSerToday = new System.DateTime(((long)(0)));
            this.printBarLabel1.Location = new System.Drawing.Point(3, 6);
            this.printBarLabel1.Margin = new System.Windows.Forms.Padding(4);
            this.printBarLabel1.Name = "printBarLabel1";
            this.printBarLabel1.sAccID = null;
            this.printBarLabel1.Size = new System.Drawing.Size(956, 590);
            this.printBarLabel1.sLogDate = null;
            this.printBarLabel1.sUserID = null;
            this.printBarLabel1.sUserName = null;
            this.printBarLabel1.TabIndex = 0;
            // 
            // FrmPrintBarLabel
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(961, 596);
            this.Controls.Add(this.printBarLabel1);
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Name = "FrmPrintBarLabel";
            this.Text = "PrintBarLabel";
            this.ResumeLayout(false);

        }

        #endregion

        private UFIDA.U8.UAP.CustomApp.ControlForm.PrintBarLabel printBarLabel1;





    }
}