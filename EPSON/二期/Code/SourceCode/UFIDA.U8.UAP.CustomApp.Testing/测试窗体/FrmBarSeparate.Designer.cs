namespace WindowsFormsApplication1
{
    partial class FrmBarSeparate
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
            this.barSplit1 = new UFIDA.U8.UAP.CustomApp.ControlForm.BarSplit();
            this.SuspendLayout();
            // 
            // barSplit1
            // 
            this.barSplit1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.barSplit1.Conn = null;
            this.barSplit1.dSerToday = new System.DateTime(((long)(0)));
            this.barSplit1.Location = new System.Drawing.Point(3, 2);
            this.barSplit1.Margin = new System.Windows.Forms.Padding(4);
            this.barSplit1.Name = "barSplit1";
            this.barSplit1.sAccID = null;
            this.barSplit1.Size = new System.Drawing.Size(957, 594);
            this.barSplit1.sLogDate = null;
            this.barSplit1.sUserID = null;
            this.barSplit1.sUserName = null;
            this.barSplit1.TabIndex = 0;
            // 
            // FrmBarSeparate
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(961, 596);
            this.Controls.Add(this.barSplit1);
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Name = "FrmBarSeparate";
            this.Text = "BarSPlit";
            this.ResumeLayout(false);

        }

        #endregion

        private UFIDA.U8.UAP.CustomApp.ControlForm.BarSplit barSplit1;




    }
}