namespace WindowsFormsApplication1
{
    partial class FrmSystemSet
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
            this.systemSet1 = new UFIDA.U8.UAP.CustomApp.ControlForm.SystemSet();
            this.SuspendLayout();
            // 
            // systemSet1
            // 
            this.systemSet1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.systemSet1.Conn = null;
            this.systemSet1.dSerToday = new System.DateTime(((long)(0)));
            this.systemSet1.Location = new System.Drawing.Point(0, 9);
            this.systemSet1.Name = "systemSet1";
            this.systemSet1.sAccID = null;
            this.systemSet1.Size = new System.Drawing.Size(720, 467);
            this.systemSet1.sLogDate = null;
            this.systemSet1.sUserID = null;
            this.systemSet1.sUserName = null;
            this.systemSet1.TabIndex = 0;
            // 
            // FrmSystemSet
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(721, 477);
            this.Controls.Add(this.systemSet1);
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "FrmSystemSet";
            this.Text = "SystemSet";
            this.ResumeLayout(false);

        }

        #endregion

        private UFIDA.U8.UAP.CustomApp.ControlForm.SystemSet systemSet1;



    }
}