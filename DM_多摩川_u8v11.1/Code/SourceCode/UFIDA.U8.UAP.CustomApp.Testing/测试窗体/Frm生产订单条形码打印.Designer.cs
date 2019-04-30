namespace WindowsFormsApplication1
{
    partial class Frm生产订单条形码打印
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
            this.printBarCode_mom_order1 = new UFIDA.U8.UAP.CustomApp.ControlForm.PrintBarCode_mom_order();
            this.SuspendLayout();
            // 
            // printBarCode_mom_order1
            // 
            this.printBarCode_mom_order1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.printBarCode_mom_order1.Conn = null;
            this.printBarCode_mom_order1.dSerToday = new System.DateTime(((long)(0)));
            this.printBarCode_mom_order1.Location = new System.Drawing.Point(2, 3);
            this.printBarCode_mom_order1.Name = "printBarCode_mom_order1";
            this.printBarCode_mom_order1.sAccID = null;
            this.printBarCode_mom_order1.Size = new System.Drawing.Size(995, 363);
            this.printBarCode_mom_order1.sLogDate = null;
            this.printBarCode_mom_order1.sUserID = null;
            this.printBarCode_mom_order1.sUserName = null;
            this.printBarCode_mom_order1.TabIndex = 0;
            // 
            // Frm生产订单条形码打印
            // 
            this.ClientSize = new System.Drawing.Size(999, 363);
            this.Controls.Add(this.printBarCode_mom_order1);
            this.Name = "Frm生产订单条形码打印";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.ResumeLayout(false);

        }

        #endregion

        private UFIDA.U8.UAP.CustomApp.ControlForm.PrintBarCode_mom_order printBarCode_mom_order1;





    }
}