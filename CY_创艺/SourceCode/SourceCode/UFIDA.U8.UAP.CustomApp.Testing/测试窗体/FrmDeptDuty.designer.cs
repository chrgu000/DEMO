namespace WindowsFormsApplication1
{
    partial class FrmDeptDuty
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
            this.DeptDuty1 = new UFIDA.U8.UAP.CustomApp.ControlForm.DeptDuty();
            this.SuspendLayout();
            // 
            // DeptDuty1
            // 
            this.DeptDuty1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.DeptDuty1.Conn = null;
            this.DeptDuty1.dSerToday = new System.DateTime(((long)(0)));
            this.DeptDuty1.Location = new System.Drawing.Point(-2, -1);
            this.DeptDuty1.Name = "DeptDuty1";
            this.DeptDuty1.sAccID = null;
            this.DeptDuty1.Size = new System.Drawing.Size(722, 475);
            this.DeptDuty1.sLogDate = null;
            this.DeptDuty1.sUserID = null;
            this.DeptDuty1.sUserName = null;
            this.DeptDuty1.TabIndex = 0;
            // 
            // FrmDeptDuty
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(721, 477);
            this.Controls.Add(this.DeptDuty1);
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "FrmDeptDuty";
            this.Text = "部门班次对应表";
            this.ResumeLayout(false);

        }

        #endregion

        private UFIDA.U8.UAP.CustomApp.ControlForm.DeptDuty DeptDuty1;

    }
}