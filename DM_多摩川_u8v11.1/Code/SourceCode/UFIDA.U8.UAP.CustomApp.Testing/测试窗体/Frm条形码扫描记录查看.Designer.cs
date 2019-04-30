namespace WindowsFormsApplication1
{
    partial class Frm条形码扫描记录查看
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
            this.printBarCode_SEL1 = new UFIDA.U8.UAP.CustomApp.ControlForm.PrintBarCode_SEL();
            this.SuspendLayout();
            // 
            // printBarCode_SEL1
            // 
            this.printBarCode_SEL1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.printBarCode_SEL1.Conn = null;
            this.printBarCode_SEL1.dSerToday = new System.DateTime(((long)(0)));
            this.printBarCode_SEL1.Location = new System.Drawing.Point(2, 6);
            this.printBarCode_SEL1.Name = "printBarCode_SEL1";
            this.printBarCode_SEL1.sAccID = null;
            this.printBarCode_SEL1.Size = new System.Drawing.Size(934, 527);
            this.printBarCode_SEL1.sLogDate = null;
            this.printBarCode_SEL1.sUserID = null;
            this.printBarCode_SEL1.sUserName = null;
            this.printBarCode_SEL1.TabIndex = 0;
            // 
            // Frm条形码扫描记录查看
            // 
            this.ClientSize = new System.Drawing.Size(938, 542);
            this.Controls.Add(this.printBarCode_SEL1);
            this.Name = "Frm条形码扫描记录查看";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.ResumeLayout(false);

        }

        #endregion

        private UFIDA.U8.UAP.CustomApp.ControlForm.PrintBarCode_SEL printBarCode_SEL1;




    }
}