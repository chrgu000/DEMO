namespace WindowsFormsApplication1
{
    partial class Frm其它入库单条形码打印
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
            this.printBarCode_RdRecord081 = new UFIDA.U8.UAP.CustomApp.ControlForm.PrintBarCode_RdRecord08();
            this.SuspendLayout();
            // 
            // printBarCode_RdRecord081
            // 
            this.printBarCode_RdRecord081.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.printBarCode_RdRecord081.Conn = null;
            this.printBarCode_RdRecord081.dSerToday = new System.DateTime(((long)(0)));
            this.printBarCode_RdRecord081.Location = new System.Drawing.Point(1, 12);
            this.printBarCode_RdRecord081.Name = "printBarCode_RdRecord081";
            this.printBarCode_RdRecord081.sAccID = null;
            this.printBarCode_RdRecord081.Size = new System.Drawing.Size(934, 523);
            this.printBarCode_RdRecord081.sLogDate = null;
            this.printBarCode_RdRecord081.sUserID = null;
            this.printBarCode_RdRecord081.sUserName = null;
            this.printBarCode_RdRecord081.TabIndex = 0;
            // 
            // Frm其它入库单条形码打印
            // 
            this.ClientSize = new System.Drawing.Size(938, 542);
            this.Controls.Add(this.printBarCode_RdRecord081);
            this.Name = "Frm其它入库单条形码打印";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.ResumeLayout(false);

        }

        #endregion

        private UFIDA.U8.UAP.CustomApp.ControlForm.PrintBarCode_RdRecord08 printBarCode_RdRecord081;





    }
}