namespace WindowsFormsApplication1
{
    partial class frmSaleBillVouch
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
            this.saleBillVouch1 = new UFIDA.U8.UAP.CustomApp.ControlForm.SaleBillVouch();
            this.SuspendLayout();
            // 
            // saleBillVouch1
            // 
            this.saleBillVouch1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.saleBillVouch1.Conn = null;
            this.saleBillVouch1.dSerToday = new System.DateTime(((long)(0)));
            this.saleBillVouch1.Location = new System.Drawing.Point(1, 9);
            this.saleBillVouch1.Name = "saleBillVouch1";
            this.saleBillVouch1.sAccID = null;
            this.saleBillVouch1.Size = new System.Drawing.Size(715, 467);
            this.saleBillVouch1.sLogDate = null;
            this.saleBillVouch1.sUserID = null;
            this.saleBillVouch1.sUserName = null;
            this.saleBillVouch1.TabIndex = 0;
            // 
            // frmSaleBillVouch
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(721, 477);
            this.Controls.Add(this.saleBillVouch1);
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "frmSaleBillVouch";
            this.Text = "saleBillVouch1";
            this.ResumeLayout(false);

        }

        #endregion

        private UFIDA.U8.UAP.CustomApp.ControlForm.SaleBillVouch saleBillVouch1;




    }
}