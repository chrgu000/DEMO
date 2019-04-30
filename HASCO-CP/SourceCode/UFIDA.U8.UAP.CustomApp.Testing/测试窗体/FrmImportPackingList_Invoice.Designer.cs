namespace WindowsFormsApplication1
{
    partial class FrmImportPackingList_Invoice
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
            this.gL_accvouch1 = new UFIDA.U8.UAP.CustomApp.ControlForm.ImportPackingList_Invoice();
            this.SuspendLayout();
            // 
            // gL_accvouch1
            // 
            this.gL_accvouch1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.gL_accvouch1.Conn = null;
            this.gL_accvouch1.dSerToday = new System.DateTime(((long)(0)));
            this.gL_accvouch1.Location = new System.Drawing.Point(1, 3);
            this.gL_accvouch1.Name = "gL_accvouch1";
            this.gL_accvouch1.sAccID = null;
            this.gL_accvouch1.Size = new System.Drawing.Size(894, 381);
            this.gL_accvouch1.sLogDate = null;
            this.gL_accvouch1.sUserID = null;
            this.gL_accvouch1.sUserName = null;
            this.gL_accvouch1.TabIndex = 0;
            // 
            // FrmImportPackingList_Invoice
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(897, 383);
            this.Controls.Add(this.gL_accvouch1);
            this.Name = "FrmImportPackingList_Invoice";
            this.Text = "导入Excel(装箱单，发票)";
            this.ResumeLayout(false);

        }

        #endregion

        private UFIDA.U8.UAP.CustomApp.ControlForm.ImportPackingList_Invoice gL_accvouch1;


    }
}