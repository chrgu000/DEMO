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
            this.btn发货单导入 = new System.Windows.Forms.Button();
            this.btn发货单报表 = new System.Windows.Forms.Button();
            this.btn发货单生成发票 = new System.Windows.Forms.Button();
            this.btn发票报表 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btn发货单导入
            // 
            this.btn发货单导入.Location = new System.Drawing.Point(26, 14);
            this.btn发货单导入.Name = "btn发货单导入";
            this.btn发货单导入.Size = new System.Drawing.Size(178, 54);
            this.btn发货单导入.TabIndex = 19;
            this.btn发货单导入.Text = "发货单导入";
            this.btn发货单导入.UseVisualStyleBackColor = true;
            this.btn发货单导入.Click += new System.EventHandler(this.btn发货单导入_Click);
            // 
            // btn发货单报表
            // 
            this.btn发货单报表.Location = new System.Drawing.Point(26, 102);
            this.btn发货单报表.Name = "btn发货单报表";
            this.btn发货单报表.Size = new System.Drawing.Size(178, 54);
            this.btn发货单报表.TabIndex = 19;
            this.btn发货单报表.Text = "发货单报表";
            this.btn发货单报表.UseVisualStyleBackColor = true;
            this.btn发货单报表.Click += new System.EventHandler(this.btn发货单报表_Click);
            // 
            // btn发货单生成发票
            // 
            this.btn发货单生成发票.Location = new System.Drawing.Point(26, 192);
            this.btn发货单生成发票.Name = "btn发货单生成发票";
            this.btn发货单生成发票.Size = new System.Drawing.Size(178, 54);
            this.btn发货单生成发票.TabIndex = 20;
            this.btn发货单生成发票.Text = "发货生成发票";
            this.btn发货单生成发票.UseVisualStyleBackColor = true;
            this.btn发货单生成发票.Click += new System.EventHandler(this.btn发货单生成发票_Click);
            // 
            // btn发票报表
            // 
            this.btn发票报表.Location = new System.Drawing.Point(26, 281);
            this.btn发票报表.Name = "btn发票报表";
            this.btn发票报表.Size = new System.Drawing.Size(178, 54);
            this.btn发票报表.TabIndex = 21;
            this.btn发票报表.Text = "发票报表";
            this.btn发票报表.UseVisualStyleBackColor = true;
            this.btn发票报表.Click += new System.EventHandler(this.btn发票报表_Click);
            // 
            // FormTest
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 18F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1034, 393);
            this.Controls.Add(this.btn发票报表);
            this.Controls.Add(this.btn发货单生成发票);
            this.Controls.Add(this.btn发货单报表);
            this.Controls.Add(this.btn发货单导入);
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "FormTest";
            this.Text = "FormTest";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btn发货单导入;
        private System.Windows.Forms.Button btn发货单报表;
        private System.Windows.Forms.Button btn发货单生成发票;
        private System.Windows.Forms.Button btn发票报表;


    }
}