namespace BarCode
{
    partial class Frm材料出库单行
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.btnSave = new System.Windows.Forms.Button();
            this.txt单据号 = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.listBox1 = new System.Windows.Forms.ListBox();
            this.listBox2 = new System.Windows.Forms.ListBox();
            this.btn全选 = new System.Windows.Forms.Button();
            this.btn选择 = new System.Windows.Forms.Button();
            this.btn消除 = new System.Windows.Forms.Button();
            this.btn全消 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // msgBox
            // 
            this.msgBox.ClientSize = new System.Drawing.Size(1366, 719);
            this.msgBox.Location = new System.Drawing.Point(-4, -4);
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(267, 18);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(39, 20);
            this.btnSave.TabIndex = 4;
            this.btnSave.Text = "确定";
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // txt单据号
            // 
            this.txt单据号.Enabled = false;
            this.txt单据号.Font = new System.Drawing.Font("Courier New", 8F, System.Drawing.FontStyle.Regular);
            this.txt单据号.Location = new System.Drawing.Point(70, 19);
            this.txt单据号.Name = "txt单据号";
            this.txt单据号.Size = new System.Drawing.Size(176, 19);
            this.txt单据号.TabIndex = 34;
            // 
            // label9
            // 
            this.label9.Font = new System.Drawing.Font("Courier New", 8F, System.Drawing.FontStyle.Regular);
            this.label9.Location = new System.Drawing.Point(14, 19);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(64, 20);
            this.label9.Text = "生产订单";
            // 
            // listBox1
            // 
            this.listBox1.Location = new System.Drawing.Point(14, 44);
            this.listBox1.Name = "listBox1";
            this.listBox1.Size = new System.Drawing.Size(120, 212);
            this.listBox1.TabIndex = 38;
            // 
            // listBox2
            // 
            this.listBox2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.listBox2.Location = new System.Drawing.Point(186, 45);
            this.listBox2.Name = "listBox2";
            this.listBox2.Size = new System.Drawing.Size(120, 212);
            this.listBox2.TabIndex = 39;
            // 
            // btn全选
            // 
            this.btn全选.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btn全选.Location = new System.Drawing.Point(141, 165);
            this.btn全选.Name = "btn全选";
            this.btn全选.Size = new System.Drawing.Size(39, 20);
            this.btn全选.TabIndex = 40;
            this.btn全选.Text = ">>";
            this.btn全选.Click += new System.EventHandler(this.btn全选_Click);
            // 
            // btn选择
            // 
            this.btn选择.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btn选择.Location = new System.Drawing.Point(140, 121);
            this.btn选择.Name = "btn选择";
            this.btn选择.Size = new System.Drawing.Size(39, 20);
            this.btn选择.TabIndex = 41;
            this.btn选择.Text = ">";
            this.btn选择.Click += new System.EventHandler(this.btn选择_Click);
            // 
            // btn消除
            // 
            this.btn消除.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.btn消除.Location = new System.Drawing.Point(140, 82);
            this.btn消除.Name = "btn消除";
            this.btn消除.Size = new System.Drawing.Size(39, 20);
            this.btn消除.TabIndex = 42;
            this.btn消除.Text = "<";
            this.btn消除.Click += new System.EventHandler(this.btn消除_Click);
            // 
            // btn全消
            // 
            this.btn全消.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btn全消.Location = new System.Drawing.Point(140, 45);
            this.btn全消.Name = "btn全消";
            this.btn全消.Size = new System.Drawing.Size(39, 20);
            this.btn全消.TabIndex = 43;
            this.btn全消.Text = "<<";
            this.btn全消.Click += new System.EventHandler(this.btn全消_Click);
            // 
            // Frm材料出库单行
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.ClientSize = new System.Drawing.Size(320, 270);
            this.Controls.Add(this.btn全消);
            this.Controls.Add(this.btn消除);
            this.Controls.Add(this.btn选择);
            this.Controls.Add(this.btn全选);
            this.Controls.Add(this.listBox2);
            this.Controls.Add(this.listBox1);
            this.Controls.Add(this.txt单据号);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.btnSave);
            this.Menu = null;
            this.Name = "Frm材料出库单行";
            this.Text = "材料出库单行";
            this.Load += new System.EventHandler(this.Frm材料出库单行_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.TextBox txt单据号;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.ListBox listBox1;
        private System.Windows.Forms.ListBox listBox2;
        private System.Windows.Forms.Button btn全选;
        private System.Windows.Forms.Button btn选择;
        private System.Windows.Forms.Button btn消除;
        private System.Windows.Forms.Button btn全消;
    }
}