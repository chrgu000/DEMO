namespace WindowsFormsApplication1
{
    partial class FrmXML文件转换
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
            this.frmXML文件转换1 = new UFIDA.U8.UAP.CustomApp.ControlForm.XML文件转换();
            this.SuspendLayout();
            // 
            // frmXML文件转换1
            // 
            this.frmXML文件转换1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.frmXML文件转换1.Conn = null;
            this.frmXML文件转换1.dSerToday = new System.DateTime(((long)(0)));
            this.frmXML文件转换1.Location = new System.Drawing.Point(4, 1);
            this.frmXML文件转换1.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.frmXML文件转换1.Name = "frmXML文件转换1";
            this.frmXML文件转换1.sAccID = null;
            this.frmXML文件转换1.Size = new System.Drawing.Size(1123, 252);
            this.frmXML文件转换1.sLogDate = null;
            this.frmXML文件转换1.sUserID = null;
            this.frmXML文件转换1.sUserName = null;
            this.frmXML文件转换1.TabIndex = 0;
            // 
            // Frm材料退回单
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1132, 256);
            this.Controls.Add(this.frmXML文件转换1);
            this.Name = "Frm材料退回单";
            this.Text = "材料退回单";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.ResumeLayout(false);

        }

        #endregion

        private UFIDA.U8.UAP.CustomApp.ControlForm.XML文件转换 frmXML文件转换1;

    }
}