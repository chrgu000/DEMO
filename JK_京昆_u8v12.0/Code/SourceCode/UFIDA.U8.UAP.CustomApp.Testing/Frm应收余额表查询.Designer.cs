namespace WindowsFormsApplication1
{
    partial class Frm应收余额表
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
            this.应收余额表1 = new UFIDA.U8.UAP.CustomApp.ControlForm.Frm应收余额表();
            this.SuspendLayout();
            // 
            // 库龄1
            // 
            this.应收余额表1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.应收余额表1.Conn = null;
            this.应收余额表1.dSerToday = new System.DateTime(((long)(0)));
            this.应收余额表1.Location = new System.Drawing.Point(-3, 12);
            this.应收余额表1.Name = "应收余额表";
            this.应收余额表1.sAccID = null;
            this.应收余额表1.Size = new System.Drawing.Size(898, 459);
            this.应收余额表1.sLogDate = null;
            this.应收余额表1.sUserID = null;
            this.应收余额表1.sUserName = null;
            this.应收余额表1.TabIndex = 0;
            // 
            // 应收余额表
            // 
            this.ClientSize = new System.Drawing.Size(896, 471);
            this.Controls.Add(this.应收余额表1);
            this.Name = "应收余额表";
            this.ResumeLayout(false);

        }

        #endregion

        private UFIDA.U8.UAP.CustomApp.ControlForm.Frm应收余额表 应收余额表1;




    }
}

