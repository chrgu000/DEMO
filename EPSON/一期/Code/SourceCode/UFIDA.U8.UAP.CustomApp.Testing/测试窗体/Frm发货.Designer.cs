namespace WindowsFormsApplication1
{
    partial class Frm发货
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
            this.barSalesShipment1 = new UFIDA.U8.UAP.CustomApp.ControlForm.BarSalesShipment();
            this.SuspendLayout();
            // 
            // barSalesShipment1
            // 
            this.barSalesShipment1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.barSalesShipment1.Conn = null;
            this.barSalesShipment1.dSerToday = new System.DateTime(((long)(0)));
            this.barSalesShipment1.Location = new System.Drawing.Point(2, 1);
            this.barSalesShipment1.Name = "barSalesShipment1";
            this.barSalesShipment1.sAccID = null;
            this.barSalesShipment1.Size = new System.Drawing.Size(717, 476);
            this.barSalesShipment1.sLogDate = null;
            this.barSalesShipment1.sUserID = null;
            this.barSalesShipment1.sUserName = null;
            this.barSalesShipment1.TabIndex = 0;
            // 
            // Frm发货
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(721, 477);
            this.Controls.Add(this.barSalesShipment1);
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "Frm发货";
            this.Text = "发货";
            this.ResumeLayout(false);

        }

        #endregion

        private UFIDA.U8.UAP.CustomApp.ControlForm.BarSalesShipment barSalesShipment1;






    }
}