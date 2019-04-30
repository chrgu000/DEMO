namespace WindowsFormsApplication1
{
    partial class FrmBraclose
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
            this.barClose1 = new UFIDA.U8.UAP.CustomApp.ControlForm.BarClose();
            this.SuspendLayout();
            // 
            // barClose1
            // 
            this.barClose1.Conn = null;
            this.barClose1.dSerToday = new System.DateTime(((long)(0)));
            this.barClose1.Location = new System.Drawing.Point(0, 5);
            this.barClose1.Margin = new System.Windows.Forms.Padding(4);
            this.barClose1.Name = "barClose1";
            this.barClose1.sAccID = null;
            this.barClose1.Size = new System.Drawing.Size(958, 588);
            this.barClose1.sLogDate = null;
            this.barClose1.sUserID = null;
            this.barClose1.sUserName = null;
            this.barClose1.TabIndex = 0;
            // 
            // FrmBraclose
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(961, 596);
            this.Controls.Add(this.barClose1);
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Name = "FrmBraclose";
            this.Text = "BarClose";
            this.ResumeLayout(false);

        }

        #endregion

        private UFIDA.U8.UAP.CustomApp.ControlForm.BarClose barClose1;




    }
}