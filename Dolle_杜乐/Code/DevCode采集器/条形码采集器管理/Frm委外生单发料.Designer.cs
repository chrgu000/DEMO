namespace BarCode
{
    partial class Frm委外生单发料
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
            this.txt条形码 = new System.Windows.Forms.TextBox();
            this.txt货位 = new System.Windows.Forms.TextBox();
            this.btn删行 = new System.Windows.Forms.Button();
            this.btn保存 = new System.Windows.Forms.Button();
            this.txt条数 = new System.Windows.Forms.TextBox();
            this.dateTime单据日期 = new System.Windows.Forms.DateTimePicker();
            this.radio母件数量 = new System.Windows.Forms.RadioButton();
            this.radio子件数量 = new System.Windows.Forms.RadioButton();
            this.radio子件件数 = new System.Windows.Forms.RadioButton();
            this.dataGrid1 = new System.Windows.Forms.DataGrid();
            this.txt编辑 = new System.Windows.Forms.TextBox();
            this.date编辑 = new System.Windows.Forms.DateTimePicker();
            this.txt栈板登记 = new System.Windows.Forms.TextBox();
            this.btn栈板 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // msgBox
            // 
            this.msgBox.ClientSize = new System.Drawing.Size(1440, 851);
            this.msgBox.Location = new System.Drawing.Point(-9, -9);
            // 
            // txt条形码
            // 
            this.txt条形码.Location = new System.Drawing.Point(6, 56);
            this.txt条形码.Name = "txt条形码";
            this.txt条形码.Size = new System.Drawing.Size(178, 27);
            this.txt条形码.TabIndex = 2;
            this.txt条形码.KeyUp += new System.Windows.Forms.KeyEventHandler(this.txt条形码_KeyUp);
            this.txt条形码.LostFocus += new System.EventHandler(this.txt条形码_LostFocus);
            // 
            // txt货位
            // 
            this.txt货位.AcceptsReturn = true;
            this.txt货位.Location = new System.Drawing.Point(134, 31);
            this.txt货位.Name = "txt货位";
            this.txt货位.Size = new System.Drawing.Size(103, 27);
            this.txt货位.TabIndex = 1;
            this.txt货位.KeyUp += new System.Windows.Forms.KeyEventHandler(this.txt货位_KeyUp);
            // 
            // btn删行
            // 
            this.btn删行.Location = new System.Drawing.Point(6, 5);
            this.btn删行.Name = "btn删行";
            this.btn删行.Size = new System.Drawing.Size(47, 20);
            this.btn删行.TabIndex = 4;
            this.btn删行.Text = "删行";
            this.btn删行.Click += new System.EventHandler(this.btn删行_Click);
            // 
            // btn保存
            // 
            this.btn保存.Location = new System.Drawing.Point(70, 5);
            this.btn保存.Name = "btn保存";
            this.btn保存.Size = new System.Drawing.Size(47, 20);
            this.btn保存.TabIndex = 3;
            this.btn保存.Text = "保存";
            this.btn保存.Click += new System.EventHandler(this.btn保存_Click);
            // 
            // txt条数
            // 
            this.txt条数.AcceptsReturn = true;
            this.txt条数.Location = new System.Drawing.Point(79, 31);
            this.txt条数.Name = "txt条数";
            this.txt条数.Size = new System.Drawing.Size(49, 27);
            this.txt条数.TabIndex = 0;
            this.txt条数.KeyUp += new System.Windows.Forms.KeyEventHandler(this.txt条数_KeyUp);
            // 
            // dateTime单据日期
            // 
            this.dateTime单据日期.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dateTime单据日期.Location = new System.Drawing.Point(134, 3);
            this.dateTime单据日期.Name = "dateTime单据日期";
            this.dateTime单据日期.Size = new System.Drawing.Size(103, 28);
            this.dateTime单据日期.TabIndex = 7;
            // 
            // radio母件数量
            // 
            this.radio母件数量.Location = new System.Drawing.Point(6, 84);
            this.radio母件数量.Name = "radio母件数量";
            this.radio母件数量.Size = new System.Drawing.Size(83, 20);
            this.radio母件数量.TabIndex = 11;
            this.radio母件数量.TabStop = false;
            this.radio母件数量.Text = "母数量";
            // 
            // radio子件数量
            // 
            this.radio子件数量.Checked = true;
            this.radio子件数量.Location = new System.Drawing.Point(95, 84);
            this.radio子件数量.Name = "radio子件数量";
            this.radio子件数量.Size = new System.Drawing.Size(66, 20);
            this.radio子件数量.TabIndex = 12;
            this.radio子件数量.Text = "子数量";
            // 
            // radio子件件数
            // 
            this.radio子件件数.Location = new System.Drawing.Point(163, 84);
            this.radio子件件数.Name = "radio子件件数";
            this.radio子件件数.Size = new System.Drawing.Size(74, 20);
            this.radio子件件数.TabIndex = 13;
            this.radio子件件数.TabStop = false;
            this.radio子件件数.Text = "子件数";
            // 
            // dataGrid1
            // 
            this.dataGrid1.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(128)))), ((int)(((byte)(128)))));
            this.dataGrid1.Location = new System.Drawing.Point(0, 110);
            this.dataGrid1.Name = "dataGrid1";
            this.dataGrid1.Size = new System.Drawing.Size(240, 155);
            this.dataGrid1.TabIndex = 14;
            this.dataGrid1.CurrentCellChanged += new System.EventHandler(this.dataGrid1_CurrentCellChanged);
            // 
            // txt编辑
            // 
            this.txt编辑.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.txt编辑.Location = new System.Drawing.Point(67, 208);
            this.txt编辑.Name = "txt编辑";
            this.txt编辑.Size = new System.Drawing.Size(100, 27);
            this.txt编辑.TabIndex = 15;
            this.txt编辑.Visible = false;
            this.txt编辑.KeyUp += new System.Windows.Forms.KeyEventHandler(this.txt编辑_KeyUp);
            this.txt编辑.LostFocus += new System.EventHandler(this.txt编辑_LostFocus);
            // 
            // date编辑
            // 
            this.date编辑.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.date编辑.Location = new System.Drawing.Point(67, 180);
            this.date编辑.Name = "date编辑";
            this.date编辑.Size = new System.Drawing.Size(100, 28);
            this.date编辑.TabIndex = 16;
            this.date编辑.Visible = false;
            this.date编辑.LostFocus += new System.EventHandler(this.date编辑_LostFocus);
            // 
            // txt栈板登记
            // 
            this.txt栈板登记.AcceptsReturn = true;
            this.txt栈板登记.Location = new System.Drawing.Point(6, 31);
            this.txt栈板登记.Name = "txt栈板登记";
            this.txt栈板登记.Size = new System.Drawing.Size(67, 27);
            this.txt栈板登记.TabIndex = 17;
            this.txt栈板登记.KeyUp += new System.Windows.Forms.KeyEventHandler(this.txt栈板登记_KeyUp);
            // 
            // btn栈板
            // 
            this.btn栈板.Location = new System.Drawing.Point(190, 56);
            this.btn栈板.Name = "btn栈板";
            this.btn栈板.Size = new System.Drawing.Size(47, 20);
            this.btn栈板.TabIndex = 18;
            this.btn栈板.Text = "栈板";
            this.btn栈板.Click += new System.EventHandler(this.btn栈板_Click);
            // 
            // Frm委外生单发料
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.ClientSize = new System.Drawing.Size(240, 268);
            this.Controls.Add(this.btn栈板);
            this.Controls.Add(this.txt栈板登记);
            this.Controls.Add(this.date编辑);
            this.Controls.Add(this.txt编辑);
            this.Controls.Add(this.dataGrid1);
            this.Controls.Add(this.radio子件件数);
            this.Controls.Add(this.radio子件数量);
            this.Controls.Add(this.radio母件数量);
            this.Controls.Add(this.dateTime单据日期);
            this.Controls.Add(this.txt条数);
            this.Controls.Add(this.btn保存);
            this.Controls.Add(this.btn删行);
            this.Controls.Add(this.txt货位);
            this.Controls.Add(this.txt条形码);
            this.Name = "Frm委外生单发料";
            this.Text = "委外生单发料";
            this.Load += new System.EventHandler(this.Frm委外生单发料_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TextBox txt条形码;
        private System.Windows.Forms.TextBox txt货位;
        private System.Windows.Forms.Button btn删行;
        private System.Windows.Forms.Button btn保存;
        private System.Windows.Forms.TextBox txt条数;
        private System.Windows.Forms.DateTimePicker dateTime单据日期;
        private System.Windows.Forms.RadioButton radio母件数量;
        private System.Windows.Forms.RadioButton radio子件数量;
        private System.Windows.Forms.RadioButton radio子件件数;
        private System.Windows.Forms.DataGrid dataGrid1;
        private System.Windows.Forms.TextBox txt编辑;
        private System.Windows.Forms.DateTimePicker date编辑;
        private System.Windows.Forms.TextBox txt栈板登记;
        private System.Windows.Forms.Button btn栈板;
    }
}