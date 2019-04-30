namespace WindowsFormsApplication1
{
    partial class FrmRequisition
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
            this.requisition1 = new UFIDA.U8.UAP.CustomApp.ControlForm.Requisition();
            this.SuspendLayout();
            // 
            // requisition1
            // 
            this.requisition1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.requisition1.Conn = null;
            this.requisition1.dSerToday = new System.DateTime(((long)(0)));
            this.requisition1.Location = new System.Drawing.Point(1, 1);
            this.requisition1.Margin = new System.Windows.Forms.Padding(4);
            this.requisition1.Name = "requisition1";
            this.requisition1.sAccID = null;
            this.requisition1.Size = new System.Drawing.Size(957, 591);
            this.requisition1.sLogDate = null;
            this.requisition1.sUserID = null;
            this.requisition1.sUserName = null;
            this.requisition1.TabIndex = 0;
            // 
            // FrmRequisition
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(961, 596);
            this.Controls.Add(this.requisition1);
            this.Name = "FrmRequisition";
            this.Text = "工装领用";
            this.ResumeLayout(false);

        }

        #endregion

        private UFIDA.U8.UAP.CustomApp.ControlForm.Requisition requisition1;

    }
}