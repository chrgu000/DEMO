namespace WindowsFormsApplication1
{
    partial class FrmDefect
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
            this.defects1 = new UFIDA.U8.UAP.CustomApp.ControlForm.Defects();
            this.SuspendLayout();
            // 
            // defects1
            // 
            this.defects1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.defects1.Conn = null;
            this.defects1.dSerToday = new System.DateTime(((long)(0)));
            this.defects1.Location = new System.Drawing.Point(2, 1);
            this.defects1.Margin = new System.Windows.Forms.Padding(4);
            this.defects1.Name = "defects1";
            this.defects1.sAccID = null;
            this.defects1.Size = new System.Drawing.Size(955, 595);
            this.defects1.sLogDate = null;
            this.defects1.sUserID = null;
            this.defects1.sUserName = null;
            this.defects1.TabIndex = 0;
            // 
            // FrmDefect
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(961, 596);
            this.Controls.Add(this.defects1);
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Name = "FrmDefect";
            this.Text = "Defects";
            this.ResumeLayout(false);

        }

        #endregion

        private UFIDA.U8.UAP.CustomApp.ControlForm.Defects defects1;






    }
}