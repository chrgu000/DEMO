namespace WindowsFormsApplication1
{
    partial class FrmImportSaleOrder
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
            this.importSaleOrder1 = new UFIDA.U8.UAP.CustomApp.ControlForm.ImportSaleOrder();
            this.SuspendLayout();
            // 
            // importSaleOrder1
            // 
            this.importSaleOrder1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.importSaleOrder1.Conn = null;
            this.importSaleOrder1.dSerToday = new System.DateTime(((long)(0)));
            this.importSaleOrder1.Location = new System.Drawing.Point(1, 2);
            this.importSaleOrder1.Margin = new System.Windows.Forms.Padding(4);
            this.importSaleOrder1.Name = "importSaleOrder1";
            this.importSaleOrder1.sAccID = null;
            this.importSaleOrder1.Size = new System.Drawing.Size(956, 590);
            this.importSaleOrder1.sLogDate = null;
            this.importSaleOrder1.sUserID = null;
            this.importSaleOrder1.sUserName = null;
            this.importSaleOrder1.TabIndex = 0;
            // 
            // FrmImportSaleOrder
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(961, 596);
            this.Controls.Add(this.importSaleOrder1);
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Name = "FrmImportSaleOrder";
            this.Text = "ImportSaleOrder";
            this.ResumeLayout(false);

        }

        #endregion

        private UFIDA.U8.UAP.CustomApp.ControlForm.ImportSaleOrder importSaleOrder1;



    }
}