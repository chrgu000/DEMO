namespace WindowsFormsApplication1
{
    partial class Frm材料退回单
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
            this.rdIn1 = new UFIDA.U8.UAP.CustomApp.ControlForm.RDIn();
            this.SuspendLayout();
            // 
            // rdIn1
            // 
            this.rdIn1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.rdIn1.Conn = null;
            this.rdIn1.dSerToday = new System.DateTime(((long)(0)));
            this.rdIn1.Location = new System.Drawing.Point(-4, 13);
            this.rdIn1.Margin = new System.Windows.Forms.Padding(4);
            this.rdIn1.Name = "rdIn1";
            this.rdIn1.sAccID = null;
            this.rdIn1.Size = new System.Drawing.Size(1347, 569);
            this.rdIn1.sLogDate = null;
            this.rdIn1.sUserID = null;
            this.rdIn1.sUserName = null;
            this.rdIn1.TabIndex = 0;
            // 
            // Frm材料退回单
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1344, 585);
            this.Controls.Add(this.rdIn1);
            this.Name = "Frm材料退回单";
            this.Text = "材料退回单";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.ResumeLayout(false);

        }

        #endregion

        private UFIDA.U8.UAP.CustomApp.ControlForm.RDIn rdIn1;
    }
}