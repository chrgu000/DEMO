namespace WindowsFormsApplication1
{
    partial class FrmRepWatchWipOS
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
            this.repWatchWipOS1 = new UFIDA.U8.UAP.CustomApp.ControlForm.RepWatchWipOS();
            this.SuspendLayout();
            // 
            // repWatchWipOS1
            // 
            this.repWatchWipOS1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.repWatchWipOS1.Conn = null;
            this.repWatchWipOS1.dSerToday = new System.DateTime(((long)(0)));
            this.repWatchWipOS1.Location = new System.Drawing.Point(1, 1);
            this.repWatchWipOS1.Margin = new System.Windows.Forms.Padding(4);
            this.repWatchWipOS1.Name = "repWatchWipOS1";
            this.repWatchWipOS1.sAccID = null;
            this.repWatchWipOS1.Size = new System.Drawing.Size(957, 593);
            this.repWatchWipOS1.sLogDate = null;
            this.repWatchWipOS1.sUserID = null;
            this.repWatchWipOS1.sUserName = null;
            this.repWatchWipOS1.TabIndex = 0;
            // 
            // FrmRepWatchWipOS
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(961, 596);
            this.Controls.Add(this.repWatchWipOS1);
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Name = "FrmRepWatchWipOS";
            this.Text = "Watch WIP OS";
            this.Load += new System.EventHandler(this.FrmRepWatchWipOS_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private UFIDA.U8.UAP.CustomApp.ControlForm.RepWatchWipOS repWatchWipOS1;







    }
}