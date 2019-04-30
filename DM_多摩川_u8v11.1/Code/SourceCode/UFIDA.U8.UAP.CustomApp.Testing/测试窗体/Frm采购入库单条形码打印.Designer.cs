namespace WindowsFormsApplication1
{
    partial class Frm采购入库单条形码打印
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
            this.printBarCode_RdRecord011 = new UFIDA.U8.UAP.CustomApp.ControlForm.PrintBarCode_RdRecord01();
            this.SuspendLayout();
            // 
            // printBarCode_RdRecord011
            // 
            this.printBarCode_RdRecord011.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.printBarCode_RdRecord011.Conn = null;
            this.printBarCode_RdRecord011.dSerToday = new System.DateTime(((long)(0)));
            this.printBarCode_RdRecord011.Location = new System.Drawing.Point(9, 12);
            this.printBarCode_RdRecord011.Name = "printBarCode_RdRecord011";
            this.printBarCode_RdRecord011.sAccID = null;
            this.printBarCode_RdRecord011.Size = new System.Drawing.Size(925, 518);
            this.printBarCode_RdRecord011.sLogDate = null;
            this.printBarCode_RdRecord011.sUserID = null;
            this.printBarCode_RdRecord011.sUserName = null;
            this.printBarCode_RdRecord011.TabIndex = 0;
            // 
            // Frm采购入库单条形码打印
            // 
            this.ClientSize = new System.Drawing.Size(938, 542);
            this.Controls.Add(this.printBarCode_RdRecord011);
            this.Name = "Frm采购入库单条形码打印";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.ResumeLayout(false);

        }

        #endregion

        private UFIDA.U8.UAP.CustomApp.ControlForm.PrintBarCode_RdRecord01 printBarCode_RdRecord011;



    }
}