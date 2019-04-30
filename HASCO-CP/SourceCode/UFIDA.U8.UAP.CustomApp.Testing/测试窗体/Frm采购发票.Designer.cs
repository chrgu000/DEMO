namespace WindowsFormsApplication1
{
    partial class Frm采购发票
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
            this.importPurBillVouch1 = new UFIDA.U8.UAP.CustomApp.ControlForm.ImportPurBillVouch();
            this.SuspendLayout();
            // 
            // importPurBillVouch1
            // 
            this.importPurBillVouch1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.importPurBillVouch1.Conn = null;
            this.importPurBillVouch1.dSerToday = new System.DateTime(((long)(0)));
            this.importPurBillVouch1.Location = new System.Drawing.Point(2, 2);
            this.importPurBillVouch1.Name = "importPurBillVouch1";
            this.importPurBillVouch1.sAccID = null;
            this.importPurBillVouch1.Size = new System.Drawing.Size(894, 380);
            this.importPurBillVouch1.sLogDate = null;
            this.importPurBillVouch1.sUserID = null;
            this.importPurBillVouch1.sUserName = null;
            this.importPurBillVouch1.TabIndex = 0;
            // 
            // Frm采购发票
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(897, 383);
            this.Controls.Add(this.importPurBillVouch1);
            this.Name = "Frm采购发票";
            this.Text = "导入采购发票";
            this.ResumeLayout(false);

        }

        #endregion

        private UFIDA.U8.UAP.CustomApp.ControlForm.ImportPurBillVouch importPurBillVouch1;





    }
}