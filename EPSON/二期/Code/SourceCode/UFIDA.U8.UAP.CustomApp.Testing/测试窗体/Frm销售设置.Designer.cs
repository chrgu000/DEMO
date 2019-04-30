namespace WindowsFormsApplication1
{
    partial class Frm销售设置
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
            this.salesSet1 = new UFIDA.U8.UAP.CustomApp.ControlForm.SalesSet();
            this.SuspendLayout();
            // 
            // salesSet1
            // 
            this.salesSet1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.salesSet1.Conn = null;
            this.salesSet1.dSerToday = new System.DateTime(((long)(0)));
            this.salesSet1.Location = new System.Drawing.Point(1, 2);
            this.salesSet1.Margin = new System.Windows.Forms.Padding(4);
            this.salesSet1.Name = "salesSet1";
            this.salesSet1.sAccID = null;
            this.salesSet1.Size = new System.Drawing.Size(838, 553);
            this.salesSet1.sLogDate = null;
            this.salesSet1.sUserID = null;
            this.salesSet1.sUserName = null;
            this.salesSet1.TabIndex = 0;
            // 
            // Frm销售设置
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(841, 556);
            this.Controls.Add(this.salesSet1);
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "Frm销售设置";
            this.Text = "销售设置";
            this.ResumeLayout(false);

        }

        #endregion

        private UFIDA.U8.UAP.CustomApp.ControlForm.SalesSet salesSet1;







    }
}