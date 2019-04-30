namespace WindowsFormsApplication1
{
    partial class frm客户数据
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
            this.客户数据1 = new UFIDA.U8.UAP.CustomApp.ControlForm.客户数据();
            this.SuspendLayout();
            // 
            // 客户数据1
            // 
            this.客户数据1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.客户数据1.Conn = null;
            this.客户数据1.dSerToday = new System.DateTime(((long)(0)));
            this.客户数据1.Location = new System.Drawing.Point(0, 8);
            this.客户数据1.Margin = new System.Windows.Forms.Padding(5, 5, 5, 5);
            this.客户数据1.Name = "客户数据1";
            this.客户数据1.sAccID = null;
            this.客户数据1.Size = new System.Drawing.Size(979, 449);
            this.客户数据1.sLogDate = null;
            this.客户数据1.sUserID = null;
            this.客户数据1.sUserName = null;
            this.客户数据1.TabIndex = 0;
            // 
            // frm客户数据
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(981, 459);
            this.Controls.Add(this.客户数据1);
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Name = "frm客户数据";
            this.Text = "客户条件数据";
            this.ResumeLayout(false);

        }

        #endregion

        private UFIDA.U8.UAP.CustomApp.ControlForm.客户数据 客户数据1;










    }
}