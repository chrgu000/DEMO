namespace WindowsFormsApplication1
{
    partial class FHDList
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
            this.发货单导入1 = new UFIDA.U8.UAP.CustomApp.ControlForm.FHDList();
            this.SuspendLayout();
            // 
            // 发货单导入1
            // 
            this.发货单导入1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.发货单导入1.Conn = null;
            this.发货单导入1.dSerToday = new System.DateTime(((long)(0)));
            this.发货单导入1.Location = new System.Drawing.Point(1, 3);
            this.发货单导入1.Margin = new System.Windows.Forms.Padding(4);
            this.发货单导入1.Name = "发货单导入1";
            this.发货单导入1.sAccID = null;
            this.发货单导入1.Size = new System.Drawing.Size(979, 454);
            this.发货单导入1.sLogDate = null;
            this.发货单导入1.sUserID = null;
            this.发货单导入1.sUserName = null;
            this.发货单导入1.TabIndex = 0;
            // 
            // frm发货单导入
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(981, 459);
            this.Controls.Add(this.发货单导入1);
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Name = "frm发货单导入";
            this.Text = "发货单导入";
            this.ResumeLayout(false);

        }

        #endregion

        private UFIDA.U8.UAP.CustomApp.ControlForm.FHDList 发货单导入1;













    }
}