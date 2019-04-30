namespace WindowsFormsApplication1
{
    partial class frm销售明细表
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
            this.销售明细表1 = new UFIDA.U8.UAP.CustomApp.ControlForm.销售明细表();
            this.SuspendLayout();
            // 
            // 销售明细表1
            // 
            this.销售明细表1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.销售明细表1.Conn = null;
            this.销售明细表1.dSerToday = new System.DateTime(((long)(0)));
            this.销售明细表1.Location = new System.Drawing.Point(1, 3);
            this.销售明细表1.Margin = new System.Windows.Forms.Padding(4);
            this.销售明细表1.Name = "销售明细表1";
            this.销售明细表1.sAccID = null;
            this.销售明细表1.Size = new System.Drawing.Size(971, 584);
            this.销售明细表1.sLogDate = null;
            this.销售明细表1.sUserID = null;
            this.销售明细表1.sUserName = null;
            this.销售明细表1.TabIndex = 0;
            // 
            // frm销售明细表
            // 
            this.ClientSize = new System.Drawing.Size(972, 588);
            this.Controls.Add(this.销售明细表1);
            this.Name = "frm销售明细表";
            this.ResumeLayout(false);

        }

        #endregion

        private UFIDA.U8.UAP.CustomApp.ControlForm.销售明细表 销售明细表1;






    }
}

