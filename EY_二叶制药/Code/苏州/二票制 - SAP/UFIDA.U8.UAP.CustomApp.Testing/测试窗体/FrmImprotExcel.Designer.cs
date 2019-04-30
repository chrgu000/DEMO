namespace WindowsFormsApplication1
{
    partial class FrmImprotExcel
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
            this.improtExcel1 = new UFIDA.U8.UAP.CustomApp.ControlForm.ImprotExcel();
            this.SuspendLayout();
            // 
            // improtExcel1
            // 
            this.improtExcel1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.improtExcel1.Conn = null;
            this.improtExcel1.dSerToday = new System.DateTime(((long)(0)));
            this.improtExcel1.Location = new System.Drawing.Point(3, 12);
            this.improtExcel1.Name = "improtExcel1";
            this.improtExcel1.sAccID = null;
            this.improtExcel1.Size = new System.Drawing.Size(932, 526);
            this.improtExcel1.sLogDate = null;
            this.improtExcel1.sUserID = null;
            this.improtExcel1.sUserName = null;
            this.improtExcel1.TabIndex = 0;
            // 
            // FrmImprotExcel
            // 
            this.ClientSize = new System.Drawing.Size(938, 542);
            this.Controls.Add(this.improtExcel1);
            this.Name = "FrmImprotExcel";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.ResumeLayout(false);

        }

        #endregion

        private UFIDA.U8.UAP.CustomApp.ControlForm.ImprotExcel improtExcel1;












    }
}