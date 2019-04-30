namespace WindowsFormsApplication1
{
    partial class FrmGL_Code
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
            this.gL_Code1 = new UFIDA.U8.UAP.CustomApp.ControlForm.GL_Code();
            this.SuspendLayout();
            // 
            // gL_Code1
            // 
            this.gL_Code1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.gL_Code1.Conn = null;
            this.gL_Code1.dSerToday = new System.DateTime(((long)(0)));
            this.gL_Code1.Location = new System.Drawing.Point(3, 3);
            this.gL_Code1.Margin = new System.Windows.Forms.Padding(4);
            this.gL_Code1.Name = "gL_Code1";
            this.gL_Code1.sAccID = null;
            this.gL_Code1.Size = new System.Drawing.Size(836, 545);
            this.gL_Code1.sLogDate = null;
            this.gL_Code1.sUserID = null;
            this.gL_Code1.sUserName = null;
            this.gL_Code1.TabIndex = 0;
            // 
            // FrmGL_Code
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(841, 548);
            this.Controls.Add(this.gL_Code1);
            this.Name = "FrmGL_Code";
            this.Text = "科目对照";
            this.ResumeLayout(false);

        }

        #endregion

        private UFIDA.U8.UAP.CustomApp.ControlForm.GL_Code gL_Code1;

    }
}