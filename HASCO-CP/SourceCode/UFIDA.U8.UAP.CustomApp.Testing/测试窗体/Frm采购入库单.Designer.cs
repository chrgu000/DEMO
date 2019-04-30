namespace WindowsFormsApplication1
{
    partial class Frm采购入库单
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
            this.importRdrecord011 = new UFIDA.U8.UAP.CustomApp.ControlForm.ImportRdrecord01();
            this.SuspendLayout();
            // 
            // importRdrecord011
            // 
            this.importRdrecord011.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.importRdrecord011.Conn = null;
            this.importRdrecord011.dSerToday = new System.DateTime(((long)(0)));
            this.importRdrecord011.Location = new System.Drawing.Point(1, 2);
            this.importRdrecord011.Name = "importRdrecord011";
            this.importRdrecord011.sAccID = null;
            this.importRdrecord011.Size = new System.Drawing.Size(894, 379);
            this.importRdrecord011.sLogDate = null;
            this.importRdrecord011.sUserID = null;
            this.importRdrecord011.sUserName = null;
            this.importRdrecord011.TabIndex = 0;
            // 
            // Frm采购入库单
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(897, 383);
            this.Controls.Add(this.importRdrecord011);
            this.Name = "Frm采购入库单";
            this.Text = "导入采购入库单";
            this.ResumeLayout(false);

        }

        #endregion

        private UFIDA.U8.UAP.CustomApp.ControlForm.ImportRdrecord01 importRdrecord011;



    }
}