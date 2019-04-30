namespace WindowsFormsApplication1
{
    partial class FrmAction
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
            this.action1 = new UFIDA.U8.UAP.CustomApp.ControlForm._Action();
            this.SuspendLayout();
            // 
            // action1
            // 
            this.action1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.action1.Conn = null;
            this.action1.dSerToday = new System.DateTime(((long)(0)));
            this.action1.Location = new System.Drawing.Point(1, 1);
            this.action1.Margin = new System.Windows.Forms.Padding(4);
            this.action1.Name = "action1";
            this.action1.sAccID = null;
            this.action1.Size = new System.Drawing.Size(961, 593);
            this.action1.sLogDate = null;
            this.action1.sUserID = null;
            this.action1.sUserName = null;
            this.action1.TabIndex = 0;
            // 
            // FrmAction
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(961, 596);
            this.Controls.Add(this.action1);
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Name = "FrmAction";
            this.Text = "Action";
            this.ResumeLayout(false);

        }

        #endregion

        private UFIDA.U8.UAP.CustomApp.ControlForm._Action action1;






    }
}