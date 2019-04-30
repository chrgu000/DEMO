namespace WindowsFormsApplication1
{
    partial class FrmMaintenance
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
            this.Maintenance1 = new UFIDA.U8.UAP.CustomApp.ControlForm.Maintenance();
            this.SuspendLayout();
            // 
            // Maintenance1
            // 
            this.Maintenance1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.Maintenance1.Conn = null;
            this.Maintenance1.dSerToday = new System.DateTime(((long)(0)));
            this.Maintenance1.Location = new System.Drawing.Point(1, 1);
            this.Maintenance1.Margin = new System.Windows.Forms.Padding(4);
            this.Maintenance1.Name = "Maintenance1";
            this.Maintenance1.sAccID = null;
            this.Maintenance1.Size = new System.Drawing.Size(957, 591);
            this.Maintenance1.sLogDate = null;
            this.Maintenance1.sUserID = null;
            this.Maintenance1.sUserName = null;
            this.Maintenance1.TabIndex = 0;
            // 
            // FrmMaintenance
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(961, 596);
            this.Controls.Add(this.Maintenance1);
            this.Name = "FrmMaintenance";
            this.Text = "工装维修";
            this.ResumeLayout(false);

        }

        #endregion

        private UFIDA.U8.UAP.CustomApp.ControlForm.Maintenance Maintenance1;

    }
}