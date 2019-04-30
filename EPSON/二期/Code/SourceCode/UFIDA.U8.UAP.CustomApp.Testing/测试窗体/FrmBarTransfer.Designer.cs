namespace WindowsFormsApplication1
{
    partial class FrmBarTransfer
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
            this.barTransfer1 = new UFIDA.U8.UAP.CustomApp.ControlForm.BarTransfer();
            this.SuspendLayout();
            // 
            // barTransfer1
            // 
            this.barTransfer1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.barTransfer1.Conn = null;
            this.barTransfer1.dSerToday = new System.DateTime(((long)(0)));
            this.barTransfer1.Location = new System.Drawing.Point(-1, 13);
            this.barTransfer1.Margin = new System.Windows.Forms.Padding(4);
            this.barTransfer1.Name = "barTransfer1";
            this.barTransfer1.sAccID = null;
            this.barTransfer1.Size = new System.Drawing.Size(960, 570);
            this.barTransfer1.sLogDate = null;
            this.barTransfer1.sUserID = null;
            this.barTransfer1.sUserName = null;
            this.barTransfer1.TabIndex = 0;
            // 
            // FrmBarTransfer
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(961, 596);
            this.Controls.Add(this.barTransfer1);
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Name = "FrmBarTransfer";
            this.Text = "工序流转";
            this.ResumeLayout(false);

        }

        #endregion

        private UFIDA.U8.UAP.CustomApp.ControlForm.BarTransfer barTransfer1;





    }
}