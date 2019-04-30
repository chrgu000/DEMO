namespace WindowsFormsApplication1
{
    partial class FrmPlatingProcess
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
            this.platingProcess1 = new UFIDA.U8.UAP.CustomApp.ControlForm.PlatingProcess();
            this.SuspendLayout();
            // 
            // platingProcess1
            // 
            this.platingProcess1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.platingProcess1.Conn = null;
            this.platingProcess1.dSerToday = new System.DateTime(((long)(0)));
            this.platingProcess1.Location = new System.Drawing.Point(2, 0);
            this.platingProcess1.Margin = new System.Windows.Forms.Padding(4);
            this.platingProcess1.Name = "platingProcess1";
            this.platingProcess1.sAccID = null;
            this.platingProcess1.Size = new System.Drawing.Size(961, 595);
            this.platingProcess1.sLogDate = null;
            this.platingProcess1.sUserID = null;
            this.platingProcess1.sUserName = null;
            this.platingProcess1.TabIndex = 0;
            // 
            // FrmPlatingProcess
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(961, 596);
            this.Controls.Add(this.platingProcess1);
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Name = "FrmPlatingProcess";
            this.Text = "PlatingProcess";
            this.ResumeLayout(false);

        }

        #endregion

        private UFIDA.U8.UAP.CustomApp.ControlForm.PlatingProcess platingProcess1;




    }
}