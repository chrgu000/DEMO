namespace WindowsFormsApplication1
{
    partial class UserRight
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
            this.userRight1 = new UFIDA.U8.UAP.CustomApp.ControlForm.UserRight();
            this.SuspendLayout();
            // 
            // userRight1
            // 
            this.userRight1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.userRight1.Conn = null;
            this.userRight1.dSerToday = new System.DateTime(((long)(0)));
            this.userRight1.Location = new System.Drawing.Point(2, 4);
            this.userRight1.Margin = new System.Windows.Forms.Padding(4);
            this.userRight1.Name = "userRight1";
            this.userRight1.sAccID = null;
            this.userRight1.Size = new System.Drawing.Size(956, 595);
            this.userRight1.sLogDate = null;
            this.userRight1.sUserID = null;
            this.userRight1.sUserName = null;
            this.userRight1.TabIndex = 0;
            // 
            // UserRight
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(961, 596);
            this.Controls.Add(this.userRight1);
            this.Name = "UserRight";
            this.Text = "用户权限";
            this.ResumeLayout(false);

        }

        #endregion

        private UFIDA.U8.UAP.CustomApp.ControlForm.UserRight userRight1;

    }
}