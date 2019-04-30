namespace WindowsFormsApplication1
{
    partial class FormTest
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
            this.btnImportExcel = new System.Windows.Forms.Button();
            this.btn导入采购入库单 = new System.Windows.Forms.Button();
            this.btn导入调拨单 = new System.Windows.Forms.Button();
            this.btn导入采购发票 = new System.Windows.Forms.Button();
            this.btn汇兑损益 = new System.Windows.Forms.Button();
            this.btn汇兑损益制单 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btnImportExcel
            // 
            this.btnImportExcel.Location = new System.Drawing.Point(21, 12);
            this.btnImportExcel.Name = "btnImportExcel";
            this.btnImportExcel.Size = new System.Drawing.Size(119, 36);
            this.btnImportExcel.TabIndex = 2;
            this.btnImportExcel.Text = "导入Excel（发货单，发票）";
            this.btnImportExcel.UseVisualStyleBackColor = true;
            this.btnImportExcel.Click += new System.EventHandler(this.btnImportExcel_Click);
            // 
            // btn导入采购入库单
            // 
            this.btn导入采购入库单.Location = new System.Drawing.Point(21, 68);
            this.btn导入采购入库单.Name = "btn导入采购入库单";
            this.btn导入采购入库单.Size = new System.Drawing.Size(119, 36);
            this.btn导入采购入库单.TabIndex = 2;
            this.btn导入采购入库单.Text = "导入采购入库单";
            this.btn导入采购入库单.UseVisualStyleBackColor = true;
            this.btn导入采购入库单.Click += new System.EventHandler(this.btn导入采购入库单_Click);
            // 
            // btn导入调拨单
            // 
            this.btn导入调拨单.Location = new System.Drawing.Point(21, 125);
            this.btn导入调拨单.Name = "btn导入调拨单";
            this.btn导入调拨单.Size = new System.Drawing.Size(119, 36);
            this.btn导入调拨单.TabIndex = 3;
            this.btn导入调拨单.Text = "导入调拨单";
            this.btn导入调拨单.UseVisualStyleBackColor = true;
            this.btn导入调拨单.Click += new System.EventHandler(this.btn导入调拨单_Click);
            // 
            // btn导入采购发票
            // 
            this.btn导入采购发票.Location = new System.Drawing.Point(21, 179);
            this.btn导入采购发票.Name = "btn导入采购发票";
            this.btn导入采购发票.Size = new System.Drawing.Size(119, 36);
            this.btn导入采购发票.TabIndex = 4;
            this.btn导入采购发票.Text = "导入采购发票";
            this.btn导入采购发票.UseVisualStyleBackColor = true;
            this.btn导入采购发票.Click += new System.EventHandler(this.btn导入采购发票_Click);
            // 
            // btn汇兑损益
            // 
            this.btn汇兑损益.Location = new System.Drawing.Point(21, 234);
            this.btn汇兑损益.Name = "btn汇兑损益";
            this.btn汇兑损益.Size = new System.Drawing.Size(119, 36);
            this.btn汇兑损益.TabIndex = 5;
            this.btn汇兑损益.Text = "汇兑损益";
            this.btn汇兑损益.UseVisualStyleBackColor = true;
            this.btn汇兑损益.Click += new System.EventHandler(this.btn汇兑损益_Click);
            // 
            // btn汇兑损益制单
            // 
            this.btn汇兑损益制单.Location = new System.Drawing.Point(21, 296);
            this.btn汇兑损益制单.Name = "btn汇兑损益制单";
            this.btn汇兑损益制单.Size = new System.Drawing.Size(119, 36);
            this.btn汇兑损益制单.TabIndex = 5;
            this.btn汇兑损益制单.Text = "汇兑损益制单";
            this.btn汇兑损益制单.UseVisualStyleBackColor = true;
            this.btn汇兑损益制单.Click += new System.EventHandler(this.btn汇兑损益制单_Click);
            // 
            // FormTest
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(401, 440);
            this.Controls.Add(this.btn汇兑损益制单);
            this.Controls.Add(this.btn汇兑损益);
            this.Controls.Add(this.btn导入采购发票);
            this.Controls.Add(this.btn导入调拨单);
            this.Controls.Add(this.btn导入采购入库单);
            this.Controls.Add(this.btnImportExcel);
            this.Name = "FormTest";
            this.Text = "FormTest";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnImportExcel;
        private System.Windows.Forms.Button btn导入采购入库单;
        private System.Windows.Forms.Button btn导入调拨单;
        private System.Windows.Forms.Button btn导入采购发票;
        private System.Windows.Forms.Button btn汇兑损益;
        private System.Windows.Forms.Button btn汇兑损益制单;


    }
}