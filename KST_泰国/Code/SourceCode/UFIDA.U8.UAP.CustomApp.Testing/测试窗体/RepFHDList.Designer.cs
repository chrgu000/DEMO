namespace WindowsFormsApplication1
{
    partial class RepFHDList
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
            this.repFHDList1 = new UFIDA.U8.UAP.CustomApp.ControlForm.RepFHDList();
            this.SuspendLayout();
            // 
            // repFHDList1
            // 
            this.repFHDList1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.repFHDList1.Conn = null;
            this.repFHDList1.dSerToday = new System.DateTime(((long)(0)));
            this.repFHDList1.Location = new System.Drawing.Point(3, 4);
            this.repFHDList1.Margin = new System.Windows.Forms.Padding(4);
            this.repFHDList1.Name = "repFHDList1";
            this.repFHDList1.sAccID = null;
            this.repFHDList1.Size = new System.Drawing.Size(978, 451);
            this.repFHDList1.sLogDate = null;
            this.repFHDList1.sUserID = null;
            this.repFHDList1.sUserName = null;
            this.repFHDList1.TabIndex = 0;
            // 
            // RepFHDList
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(981, 459);
            this.Controls.Add(this.repFHDList1);
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Name = "RepFHDList";
            this.Text = "发货单导入";
            this.ResumeLayout(false);

        }

        #endregion

        private UFIDA.U8.UAP.CustomApp.ControlForm.RepFHDList repFHDList1;














    }
}