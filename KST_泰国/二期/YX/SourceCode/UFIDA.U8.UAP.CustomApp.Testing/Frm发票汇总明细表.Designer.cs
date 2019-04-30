namespace WindowsFormsApplication1
{
    partial class Frm发票汇总明细表
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
            this.发票汇总明细表1 = new UFIDA.U8.UAP.CustomApp.ControlForm.FrmSalebillvouch_Report();
            this.SuspendLayout();
            // 
            // 库龄1
            // 
            this.发票汇总明细表1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.发票汇总明细表1.Conn = null;
            this.发票汇总明细表1.dSerToday = new System.DateTime(((long)(0)));
            this.发票汇总明细表1.Location = new System.Drawing.Point(-3, 12);
            this.发票汇总明细表1.Name = "发票汇总明细表";
            this.发票汇总明细表1.sAccID = null;
            this.发票汇总明细表1.Size = new System.Drawing.Size(898, 459);
            this.发票汇总明细表1.sLogDate = null;
            this.发票汇总明细表1.sUserID = null;
            this.发票汇总明细表1.sUserName = null;
            this.发票汇总明细表1.TabIndex = 0;
            // 
            // 发票汇总明细表
            // 
            this.ClientSize = new System.Drawing.Size(896, 471);
            this.Controls.Add(this.发票汇总明细表1);
            this.Name = "发票汇总明细表";
            this.ResumeLayout(false);

        }

        #endregion

        private UFIDA.U8.UAP.CustomApp.ControlForm.FrmSalebillvouch_Report 发票汇总明细表1;




    }
}

