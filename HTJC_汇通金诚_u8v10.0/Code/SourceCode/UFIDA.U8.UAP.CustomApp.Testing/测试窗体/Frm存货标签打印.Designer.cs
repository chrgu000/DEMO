namespace WindowsFormsApplication1
{
    partial class Frm存货标签打印
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
            this.库龄1 = new UFIDA.U8.UAP.CustomApp.ControlForm.存货标签打印();
            this.SuspendLayout();
            // 
            // 库龄1
            // 
            this.库龄1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.库龄1.Conn = null;
            this.库龄1.dSerToday = new System.DateTime(((long)(0)));
            this.库龄1.Location = new System.Drawing.Point(-3, 12);
            this.库龄1.Name = "库龄1";
            this.库龄1.sAccID = null;
            this.库龄1.Size = new System.Drawing.Size(898, 459);
            this.库龄1.sLogDate = null;
            this.库龄1.sUserID = null;
            this.库龄1.sUserName = null;
            this.库龄1.TabIndex = 0;
            // 
            // Frm库龄
            // 
            this.ClientSize = new System.Drawing.Size(896, 471);
            this.Controls.Add(this.库龄1);
            this.Name = "Frm库龄";
            this.ResumeLayout(false);

        }

        #endregion

        private UFIDA.U8.UAP.CustomApp.ControlForm.存货标签打印 库龄1;




    }
}

