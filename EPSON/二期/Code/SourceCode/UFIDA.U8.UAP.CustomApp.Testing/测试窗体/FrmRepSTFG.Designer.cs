namespace WindowsFormsApplication1
{
    partial class FrmRepSTFG
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
            this.repPur1 = new UFIDA.U8.UAP.CustomApp.ControlForm.RepSTFG();
            this.SuspendLayout();
            // 
            // repPur1
            // 
            this.repPur1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.repPur1.Conn = null;
            this.repPur1.dSerToday = new System.DateTime(((long)(0)));
            this.repPur1.Location = new System.Drawing.Point(3, 3);
            this.repPur1.Margin = new System.Windows.Forms.Padding(4);
            this.repPur1.Name = "repPur1";
            this.repPur1.sAccID = null;
            this.repPur1.Size = new System.Drawing.Size(959, 595);
            this.repPur1.sLogDate = null;
            this.repPur1.sUserID = null;
            this.repPur1.sUserName = null;
            this.repPur1.TabIndex = 0;
            // 
            // FrmRepSTFG
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(961, 596);
            this.Controls.Add(this.repPur1);
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Name = "FrmRepSTFG";
            this.Text = "ST FG";
            this.ResumeLayout(false);

        }

        #endregion

        private UFIDA.U8.UAP.CustomApp.ControlForm.RepSTFG repPur1;







    }
}