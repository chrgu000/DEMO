﻿namespace BarCode
{
    partial class Frm其他出库货位
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
            this.date单据日期 = new System.Windows.Forms.DateTimePicker();
            this.dataGrid1 = new System.Windows.Forms.DataGrid();
            this.txt编辑 = new System.Windows.Forms.TextBox();
            this.radio件数 = new System.Windows.Forms.RadioButton();
            this.radio数量 = new System.Windows.Forms.RadioButton();
            this.SuspendLayout();
            // 
            // msgBox
            // 
            this.msgBox.ClientSize = new System.Drawing.Size(1366, 706);
            this.msgBox.Location = new System.Drawing.Point(-9, -9);
            // 
            // txt条形码
            // 
            this.txt条形码.Location = new System.Drawing.Point(3, 70);
            this.txt条形码.Name = "txt条形码";
            this.txt条形码.Size = new System.Drawing.Size(231, 27);
            this.txt条形码.TabIndex = 2;
            this.txt条形码.KeyUp += new System.Windows.Forms.KeyEventHandler(this.txt条形码_KeyUp);
            this.txt条形码.LostFocus += new System.EventHandler(this.txt条形码_LostFocus);
            // 
            // txt货位
            // 
            this.txt货位.AcceptsReturn = true;
            this.txt货位.Location = new System.Drawing.Point(67, 38);
            this.txt货位.Name = "txt货位";
            this.txt货位.Size = new System.Drawing.Size(167, 27);
            this.txt货位.TabIndex = 1;
            this.txt货位.KeyUp += new System.Windows.Forms.KeyEventHandler(this.txt货位_KeyUp);
            // 
            // btn删行
            // 
            this.btn删行.Location = new System.Drawing.Point(3, 12);
            this.btn删行.Name = "btn删行";
            this.btn删行.Size = new System.Drawing.Size(47, 20);
            this.btn删行.TabIndex = 4;
            this.btn删行.Text = "删行";
            this.btn删行.Click += new System.EventHandler(this.btn删行_Click);
            // 
            // btn保存
            // 
            this.btn保存.Location = new System.Drawing.Point(67, 12);
            this.btn保存.Name = "btn保存";
            this.btn保存.Size = new System.Drawing.Size(47, 20);
            this.btn保存.TabIndex = 3;
            this.btn保存.Text = "保存";
            this.btn保存.Click += new System.EventHandler(this.btn保存_Click);
            // 
            // txt条数
            // 
            this.txt条数.AcceptsReturn = true;
            this.txt条数.Location = new System.Drawing.Point(3, 38);
            this.txt条数.Name = "txt条数";
            this.txt条数.Size = new System.Drawing.Size(49, 27);
            this.txt条数.TabIndex = 0;
            this.txt条数.KeyUp += new System.Windows.Forms.KeyEventHandler(this.txt条数_KeyUp);
            // 
            // date单据日期
            // 
            this.date单据日期.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.date单据日期.Location = new System.Drawing.Point(131, 10);
            this.date单据日期.Name = "date单据日期";
            this.date单据日期.Size = new System.Drawing.Size(103, 28);
            this.date单据日期.TabIndex = 5;
            // 
            // dataGrid1
            // 
            this.dataGrid1.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(128)))), ((int)(((byte)(128)))));
            this.dataGrid1.Location = new System.Drawing.Point(3, 123);
            this.dataGrid1.Name = "dataGrid1";
            this.dataGrid1.Size = new System.Drawing.Size(231, 145);
            this.dataGrid1.TabIndex = 6;
            this.dataGrid1.CurrentCellChanged += new System.EventHandler(this.dataGrid1_CurrentCellChanged);
            // 
            // txt编辑
            // 
            this.txt编辑.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.txt编辑.Location = new System.Drawing.Point(87, 188);
            this.txt编辑.Name = "txt编辑";
            this.txt编辑.Size = new System.Drawing.Size(100, 27);
            this.txt编辑.TabIndex = 9;
            this.txt编辑.Visible = false;
            this.txt编辑.KeyUp += new System.Windows.Forms.KeyEventHandler(this.txt编辑_KeyUp);
            this.txt编辑.LostFocus += new System.EventHandler(this.txt编辑_LostFocus);
            // 
            // radio件数
            // 
            this.radio件数.Location = new System.Drawing.Point(70, 97);
            this.radio件数.Name = "radio件数";
            this.radio件数.Size = new System.Drawing.Size(61, 20);
            this.radio件数.TabIndex = 14;
            this.radio件数.TabStop = false;
            this.radio件数.Text = "件数";
            // 
            // radio数量
            // 
            this.radio数量.Checked = true;
            this.radio数量.Location = new System.Drawing.Point(3, 97);
            this.radio数量.Name = "radio数量";
            this.radio数量.Size = new System.Drawing.Size(61, 20);
            this.radio数量.TabIndex = 13;
            this.radio数量.TabStop = false;
            this.radio数量.Text = "数量";
            // 
            // Frm其他出库货位
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.ClientSize = new System.Drawing.Size(240, 268);
            this.Controls.Add(this.radio件数);
            this.Controls.Add(this.radio数量);
            this.Controls.Add(this.txt编辑);
            this.Controls.Add(this.dataGrid1);
            this.Controls.Add(this.date单据日期);
            this.Controls.Add(this.txt条数);
            this.Controls.Add(this.btn保存);
            this.Controls.Add(this.btn删行);
            this.Controls.Add(this.txt货位);
            this.Controls.Add(this.txt条形码);
            this.Name = "Frm其他出库货位";
            this.Text = "其他出库货位";
            this.Load += new System.EventHandler(this.Frm其他出库货位_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TextBox txt条形码;
        private System.Windows.Forms.TextBox txt货位;
        private System.Windows.Forms.Button btn删行;
        private System.Windows.Forms.Button btn保存;
        private System.Windows.Forms.TextBox txt条数;
        private System.Windows.Forms.DateTimePicker date单据日期;
        private System.Windows.Forms.DataGrid dataGrid1;
        private System.Windows.Forms.TextBox txt编辑;
        private System.Windows.Forms.RadioButton radio件数;
        private System.Windows.Forms.RadioButton radio数量;
    }
}