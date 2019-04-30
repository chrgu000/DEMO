namespace Test
{
    partial class Form1
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
            this.btnDispatchList = new System.Windows.Forms.Button();
            this.btnRdRecord = new System.Windows.Forms.Button();
            this.btnSOStatus = new System.Windows.Forms.Button();
            this.btnPOStatus = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btnDispatchList
            // 
            this.btnDispatchList.Location = new System.Drawing.Point(103, 59);
            this.btnDispatchList.Margin = new System.Windows.Forms.Padding(4);
            this.btnDispatchList.Name = "btnDispatchList";
            this.btnDispatchList.Size = new System.Drawing.Size(128, 74);
            this.btnDispatchList.TabIndex = 0;
            this.btnDispatchList.Text = " 发货";
            this.btnDispatchList.UseVisualStyleBackColor = true;
            this.btnDispatchList.Click += new System.EventHandler(this.btnDispatchList_Click);
            // 
            // btnRdRecord
            // 
            this.btnRdRecord.Location = new System.Drawing.Point(103, 214);
            this.btnRdRecord.Margin = new System.Windows.Forms.Padding(4);
            this.btnRdRecord.Name = "btnRdRecord";
            this.btnRdRecord.Size = new System.Drawing.Size(128, 74);
            this.btnRdRecord.TabIndex = 1;
            this.btnRdRecord.Text = "采购入库";
            this.btnRdRecord.UseVisualStyleBackColor = true;
            this.btnRdRecord.Click += new System.EventHandler(this.btnRdRecord_Click);
            // 
            // btnSOStatus
            // 
            this.btnSOStatus.Location = new System.Drawing.Point(403, 59);
            this.btnSOStatus.Margin = new System.Windows.Forms.Padding(4);
            this.btnSOStatus.Name = "btnSOStatus";
            this.btnSOStatus.Size = new System.Drawing.Size(128, 74);
            this.btnSOStatus.TabIndex = 2;
            this.btnSOStatus.Text = "销售订单状态";
            this.btnSOStatus.UseVisualStyleBackColor = true;
            this.btnSOStatus.Click += new System.EventHandler(this.btnSOStatus_Click);
            // 
            // btnPOStatus
            // 
            this.btnPOStatus.Location = new System.Drawing.Point(403, 214);
            this.btnPOStatus.Margin = new System.Windows.Forms.Padding(4);
            this.btnPOStatus.Name = "btnPOStatus";
            this.btnPOStatus.Size = new System.Drawing.Size(128, 74);
            this.btnPOStatus.TabIndex = 3;
            this.btnPOStatus.Text = "采购订单状态";
            this.btnPOStatus.UseVisualStyleBackColor = true;
            this.btnPOStatus.Click += new System.EventHandler(this.btnPOStatus_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(759, 551);
            this.Controls.Add(this.btnPOStatus);
            this.Controls.Add(this.btnSOStatus);
            this.Controls.Add(this.btnRdRecord);
            this.Controls.Add(this.btnDispatchList);
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnDispatchList;
        private System.Windows.Forms.Button btnRdRecord;
        private System.Windows.Forms.Button btnSOStatus;
        private System.Windows.Forms.Button btnPOStatus;
    }
}