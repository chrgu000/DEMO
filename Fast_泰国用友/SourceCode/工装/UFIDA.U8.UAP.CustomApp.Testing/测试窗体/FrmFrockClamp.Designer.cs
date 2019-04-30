namespace WindowsFormsApplication1
{
    partial class FrmFrockClamp
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
            this.frockClamp1 = new UFIDA.U8.UAP.CustomApp.ControlForm.FrockClamp();
            this.SuspendLayout();
            // 
            // frockClamp1
            // 
            this.frockClamp1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.frockClamp1.Conn = null;
            this.frockClamp1.dSerToday = new System.DateTime(((long)(0)));
            this.frockClamp1.Location = new System.Drawing.Point(-2, -1);
            this.frockClamp1.Margin = new System.Windows.Forms.Padding(4);
            this.frockClamp1.Name = "frockClamp1";
            this.frockClamp1.sAccID = null;
            this.frockClamp1.Size = new System.Drawing.Size(963, 594);
            this.frockClamp1.sLogDate = null;
            this.frockClamp1.sUserID = null;
            this.frockClamp1.sUserName = null;
            this.frockClamp1.TabIndex = 0;
            // 
            // FrmFrockClamp
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(961, 596);
            this.Controls.Add(this.frockClamp1);
            this.Name = "FrmFrockClamp";
            this.Text = "工装登记";
            this.ResumeLayout(false);

        }

        #endregion

        private UFIDA.U8.UAP.CustomApp.ControlForm.FrockClamp frockClamp1;

    }
}