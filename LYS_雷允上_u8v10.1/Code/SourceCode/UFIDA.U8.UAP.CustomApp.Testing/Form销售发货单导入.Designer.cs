namespace WindowsFormsApplication1
{
    partial class Form销售发货单导入
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
            this.销售发货单1 = new UFIDA.U8.UAP.CustomApp.ControlForm.销售发货单导入();
            this.SuspendLayout();
            // 
            // 销售发货单1
            // 
            this.销售发货单1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.销售发货单1.Conn = null;
            this.销售发货单1.dSerToday = new System.DateTime(((long)(0)));
            this.销售发货单1.Location = new System.Drawing.Point(-2, 12);
            this.销售发货单1.Name = "销售发货单1";
            this.销售发货单1.sAccID = null;
            this.销售发货单1.Size = new System.Drawing.Size(904, 430);
            this.销售发货单1.sLogDate = null;
            this.销售发货单1.sUserID = null;
            this.销售发货单1.sUserName = null;
            this.销售发货单1.TabIndex = 0;
            // 
            // Form销售发货单导入
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(904, 449);
            this.Controls.Add(this.销售发货单1);
            this.Name = "Form销售发货单导入";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.ResumeLayout(false);

        }

        #endregion

        private UFIDA.U8.UAP.CustomApp.ControlForm.销售发货单导入 销售发货单1;






    }
}

