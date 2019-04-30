namespace WindowsFormsApplication1
{
    partial class Frm调拨单
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
            this.importTransVouch1 = new UFIDA.U8.UAP.CustomApp.ControlForm.ImportTransVouch();
            this.SuspendLayout();
            // 
            // importTransVouch1
            // 
            this.importTransVouch1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.importTransVouch1.Conn = null;
            this.importTransVouch1.dSerToday = new System.DateTime(((long)(0)));
            this.importTransVouch1.Location = new System.Drawing.Point(3, 3);
            this.importTransVouch1.Name = "importTransVouch1";
            this.importTransVouch1.sAccID = null;
            this.importTransVouch1.Size = new System.Drawing.Size(887, 376);
            this.importTransVouch1.sLogDate = null;
            this.importTransVouch1.sUserID = null;
            this.importTransVouch1.sUserName = null;
            this.importTransVouch1.TabIndex = 0;
            // 
            // Frm调拨单
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(897, 383);
            this.Controls.Add(this.importTransVouch1);
            this.Name = "Frm调拨单";
            this.Text = "导入调拨单";
            this.ResumeLayout(false);

        }

        #endregion

        private UFIDA.U8.UAP.CustomApp.ControlForm.ImportTransVouch importTransVouch1;




    }
}