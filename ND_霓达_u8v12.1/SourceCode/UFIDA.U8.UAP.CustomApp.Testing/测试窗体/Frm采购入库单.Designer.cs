namespace WindowsFormsApplication1
{
    partial class Frm采购入库单
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
            this.rdInPu1 = new UFIDA.U8.UAP.CustomApp.ControlForm.RDInPu();
            this.SuspendLayout();
            // 
            // rdInPu1
            // 
            this.rdInPu1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.rdInPu1.Conn = null;
            this.rdInPu1.dSerToday = new System.DateTime(((long)(0)));
            this.rdInPu1.Location = new System.Drawing.Point(2, 4);
            this.rdInPu1.Margin = new System.Windows.Forms.Padding(4);
            this.rdInPu1.Name = "rdInPu1";
            this.rdInPu1.sAccID = null;
            this.rdInPu1.Size = new System.Drawing.Size(1309, 550);
            this.rdInPu1.sLogDate = null;
            this.rdInPu1.sUserID = null;
            this.rdInPu1.sUserName = null;
            this.rdInPu1.TabIndex = 0;
            // 
            // Frm采购入库单
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1314, 561);
            this.Controls.Add(this.rdInPu1);
            this.Name = "Frm采购入库单";
            this.Text = "采购入库单";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.ResumeLayout(false);

        }

        #endregion

        private UFIDA.U8.UAP.CustomApp.ControlForm.RDInPu rdInPu1;

    }
}