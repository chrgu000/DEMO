using System;
using System.Collections.Specialized;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using UFIDA.U8.UAP.CustomApp.MetaData;
using System.Globalization;
using System.Configuration;
using System.Diagnostics;
using System.IO;
using System.Threading;

namespace WindowsFormsApplication1
{
    public partial class FormTest : Form
    {
        public FormTest()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Frm销售出库统计查询 f = new Frm销售出库统计查询();
            f.WindowState = FormWindowState.Maximized;
            f.Show();
        }
        private void button2_Click(object sender, EventArgs e)
        {
            Frm库存物资统计简表查询 f = new Frm库存物资统计简表查询();
            f.WindowState = FormWindowState.Maximized;
            f.Show();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Frm检验档案 f = new Frm检验档案();
            f.WindowState = FormWindowState.Maximized;
            f.Show();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            Frm采购入库统计查询 f = new Frm采购入库统计查询();
            f.WindowState = FormWindowState.Maximized;
            f.Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Frm销售预测产品入库 f = new Frm销售预测产品入库();
            f.WindowState = FormWindowState.Maximized;
            f.Show();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            Frm产品入库统计查询 f = new Frm产品入库统计查询();
            f.WindowState = FormWindowState.Maximized;
            f.Show();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            Frm材料出库统计查询 f = new Frm材料出库统计查询();
            f.WindowState = FormWindowState.Maximized;
            f.Show();
        }

        private void button8_Click(object sender, EventArgs e)
        {
            Frm检验项目 f = new Frm检验项目();
            f.WindowState = FormWindowState.Maximized;
            f.Show();
        }

        private void button9_Click(object sender, EventArgs e)
        {
            Frm库存物资统计简表查询 f = new Frm库存物资统计简表查询();
            f.WindowState = FormWindowState.Maximized;
            f.Show();
        }

        private void button10_Click(object sender, EventArgs e)
        {
            Frm应收余额表 f = new Frm应收余额表();
            f.WindowState = FormWindowState.Maximized;
            f.Show();
        }

        private void button11_Click(object sender, EventArgs e)
        {
            Frm收发存汇总查询 f = new Frm收发存汇总查询();
            f.WindowState = FormWindowState.Maximized;
            f.Show();
        }

        private void button12_Click(object sender, EventArgs e)
        {
            Frm产品产量情况表查询 f = new Frm产品产量情况表查询();
            f.WindowState = FormWindowState.Maximized;
            f.Show();
        }

        private void button13_Click(object sender, EventArgs e)
        {
            Frm存货情况表查询 f = new Frm存货情况表查询();
            f.WindowState = FormWindowState.Maximized;
            f.Show();
        }

        private void button14_Click(object sender, EventArgs e)
        {
            Frm主要物资采购明细表查询 f = new Frm主要物资采购明细表查询();
            f.WindowState = FormWindowState.Maximized;
            f.Show();
        }

        private void button15_Click(object sender, EventArgs e)
        {
            Frm应付余额表 f = new Frm应付余额表();
            f.WindowState = FormWindowState.Maximized;
            f.Show();
        }

    }
}
