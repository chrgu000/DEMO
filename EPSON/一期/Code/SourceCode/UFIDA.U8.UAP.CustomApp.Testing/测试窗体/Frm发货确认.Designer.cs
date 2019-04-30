namespace WindowsFormsApplication1
{
    partial class Frm发货确认
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
            this.barSalesShipmentAudit1 = new UFIDA.U8.UAP.CustomApp.ControlForm.BarSalesShipmentAudit();
            this.SuspendLayout();
            // 
            // barSalesShipmentAudit1
            // 
            this.barSalesShipmentAudit1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.barSalesShipmentAudit1.Conn = null;
            this.barSalesShipmentAudit1.dSerToday = new System.DateTime(((long)(0)));
            this.barSalesShipmentAudit1.Location = new System.Drawing.Point(3, 2);
            this.barSalesShipmentAudit1.Name = "barSalesShipmentAudit1";
            this.barSalesShipmentAudit1.sAccID = null;
            this.barSalesShipmentAudit1.Size = new System.Drawing.Size(1152, 589);
            this.barSalesShipmentAudit1.sLogDate = null;
            this.barSalesShipmentAudit1.sUserID = null;
            this.barSalesShipmentAudit1.sUserName = null;
            this.barSalesShipmentAudit1.TabIndex = 0;
            // 
            // Frm发货确认
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1155, 589);
            this.Controls.Add(this.barSalesShipmentAudit1);
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "Frm发货确认";
            this.Text = "发货确认";
            this.ResumeLayout(false);

        }

        #endregion

        private UFIDA.U8.UAP.CustomApp.ControlForm.BarSalesShipmentAudit barSalesShipmentAudit1;







    }
}