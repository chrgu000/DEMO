namespace WindowsFormsApplication1
{
    partial class FrmProcessList
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
            this.processList1 = new UFIDA.U8.UAP.CustomApp.ControlForm.ProcessList();
            this.SuspendLayout();
            // 
            // processList1
            // 
            this.processList1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.processList1.Conn = null;
            this.processList1.dSerToday = new System.DateTime(((long)(0)));
            this.processList1.Location = new System.Drawing.Point(-7, -1);
            this.processList1.Margin = new System.Windows.Forms.Padding(4);
            this.processList1.Name = "processList1";
            this.processList1.sAccID = null;
            this.processList1.Size = new System.Drawing.Size(967, 597);
            this.processList1.sLogDate = null;
            this.processList1.sUserID = null;
            this.processList1.sUserName = null;
            this.processList1.TabIndex = 0;
            // 
            // FrmProcessList
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(961, 596);
            this.Controls.Add(this.processList1);
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Name = "FrmProcessList";
            this.Text = "ProcessList";
            this.ResumeLayout(false);

        }

        #endregion

        private UFIDA.U8.UAP.CustomApp.ControlForm.ProcessList processList1;




    }
}