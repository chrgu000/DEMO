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
            this.btn库龄 = new System.Windows.Forms.Button();
            this.btn货位标签打印 = new System.Windows.Forms.Button();
            this.btn产品标签打印 = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.btn发货 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btn库龄
            // 
            this.btn库龄.Location = new System.Drawing.Point(307, 463);
            this.btn库龄.Margin = new System.Windows.Forms.Padding(4);
            this.btn库龄.Name = "btn库龄";
            this.btn库龄.Size = new System.Drawing.Size(133, 29);
            this.btn库龄.TabIndex = 15;
            this.btn库龄.Text = "存货标签打印";
            this.btn库龄.UseVisualStyleBackColor = true;
            this.btn库龄.Click += new System.EventHandler(this.btn存货标签打印_Click);
            // 
            // btn货位标签打印
            // 
            this.btn货位标签打印.Location = new System.Drawing.Point(117, 44);
            this.btn货位标签打印.Margin = new System.Windows.Forms.Padding(4);
            this.btn货位标签打印.Name = "btn货位标签打印";
            this.btn货位标签打印.Size = new System.Drawing.Size(133, 29);
            this.btn货位标签打印.TabIndex = 16;
            this.btn货位标签打印.Text = "货位标签打印";
            this.btn货位标签打印.UseVisualStyleBackColor = true;
            this.btn货位标签打印.Click += new System.EventHandler(this.btn货位标签打印_Click);
            // 
            // btn产品标签打印
            // 
            this.btn产品标签打印.Location = new System.Drawing.Point(117, 198);
            this.btn产品标签打印.Margin = new System.Windows.Forms.Padding(4);
            this.btn产品标签打印.Name = "btn产品标签打印";
            this.btn产品标签打印.Size = new System.Drawing.Size(133, 29);
            this.btn产品标签打印.TabIndex = 17;
            this.btn产品标签打印.Text = "产品标签打印";
            this.btn产品标签打印.UseVisualStyleBackColor = true;
            this.btn产品标签打印.Click += new System.EventHandler(this.btn产品标签打印_Click);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(117, 148);
            this.button1.Margin = new System.Windows.Forms.Padding(4);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(133, 29);
            this.button1.TabIndex = 18;
            this.button1.Text = "采购标签打印";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // btn发货
            // 
            this.btn发货.Location = new System.Drawing.Point(307, 417);
            this.btn发货.Margin = new System.Windows.Forms.Padding(4);
            this.btn发货.Name = "btn发货";
            this.btn发货.Size = new System.Drawing.Size(133, 29);
            this.btn发货.TabIndex = 20;
            this.btn发货.Text = "发货打印";
            this.btn发货.UseVisualStyleBackColor = true;
            this.btn发货.Click += new System.EventHandler(this.btn发货_Click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(117, 95);
            this.button2.Margin = new System.Windows.Forms.Padding(4);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(133, 29);
            this.button2.TabIndex = 21;
            this.button2.Text = "成品库标签打印";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // FormTest
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(463, 517);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.btn发货);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.btn产品标签打印);
            this.Controls.Add(this.btn货位标签打印);
            this.Controls.Add(this.btn库龄);
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "FormTest";
            this.Text = "FormTest";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btn库龄;
        private System.Windows.Forms.Button btn货位标签打印;
        private System.Windows.Forms.Button btn产品标签打印;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button btn发货;
        private System.Windows.Forms.Button button2;

    }
}