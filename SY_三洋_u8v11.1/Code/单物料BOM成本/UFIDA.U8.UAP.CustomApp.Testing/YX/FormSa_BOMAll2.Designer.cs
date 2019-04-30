namespace WindowsFormsApplication1
{
    partial class FormSa_BOMAll2
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
            this.sa_BOMAll21 = new UFIDA.U8.UAP.CustomApp.ControlForm.Sa_BOMAll2();
            this.SuspendLayout();
            // 
            // sa_BOMAll21
            // 
            this.sa_BOMAll21.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.sa_BOMAll21.Conn = null;
            this.sa_BOMAll21.dSerToday = new System.DateTime(((long)(0)));
            this.sa_BOMAll21.Location = new System.Drawing.Point(0, 12);
            this.sa_BOMAll21.Name = "sa_BOMAll21";
            this.sa_BOMAll21.sAccID = null;
            this.sa_BOMAll21.Size = new System.Drawing.Size(903, 439);
            this.sa_BOMAll21.sLogDate = null;
            this.sa_BOMAll21.sUserID = null;
            this.sa_BOMAll21.sUserName = null;
            this.sa_BOMAll21.TabIndex = 0;
            // 
            // FormSa_BOMAll2
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(904, 449);
            this.Controls.Add(this.sa_BOMAll21);
            this.Name = "FormSa_BOMAll2";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.ResumeLayout(false);

        }

        #endregion

        private UFIDA.U8.UAP.CustomApp.ControlForm.Sa_BOMAll2 sa_BOMAll21;




    }
}

