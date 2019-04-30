namespace WindowsFormsApplication1
{
    partial class Frm历史条形码打印
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
            this.printBarCode_History1 = new UFIDA.U8.UAP.CustomApp.ControlForm.PrintBarCode_History();
            this.SuspendLayout();
            // 
            // printBarCode_History1
            // 
            this.printBarCode_History1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.printBarCode_History1.Conn = null;
            this.printBarCode_History1.dSerToday = new System.DateTime(((long)(0)));
            this.printBarCode_History1.Location = new System.Drawing.Point(1, 3);
            this.printBarCode_History1.Name = "printBarCode_History1";
            this.printBarCode_History1.sAccID = null;
            this.printBarCode_History1.Size = new System.Drawing.Size(933, 537);
            this.printBarCode_History1.sLogDate = null;
            this.printBarCode_History1.sUserID = null;
            this.printBarCode_History1.sUserName = null;
            this.printBarCode_History1.TabIndex = 0;
            // 
            // Frm历史条形码打印
            // 
            this.ClientSize = new System.Drawing.Size(938, 542);
            this.Controls.Add(this.printBarCode_History1);
            this.Name = "Frm历史条形码打印";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.ResumeLayout(false);

        }

        #endregion

        private UFIDA.U8.UAP.CustomApp.ControlForm.PrintBarCode_History printBarCode_History1;




    }
}