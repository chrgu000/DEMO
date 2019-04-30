using System;
using System.Linq;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace BarCode
{
    public partial class Frm材料出库单行 : FrmBase
    {
        public string s生产订单号;
        public string s行号;
        public Frm材料出库单行(string sCode, string sRowNo)
        {
            
            InitializeComponent();
            s生产订单号 = sCode;
            s行号 = sRowNo;
            txt单据号.Text = s生产订单号;
        }

        private void Frm材料出库单行_Load(object sender, EventArgs e)
        {
            try
            {
                DataTable dtGrid = clsWeb.dt生产订单信息(txt单据号.Text.Trim(), "");
                //listBox1.DataSource = dtGrid;
                //listBox1.ValueMember = "SortSeq";
                for (int i = 0; i < dtGrid.Rows.Count; i++)
                {
                    listBox1.Items.Add(dtGrid.Rows[i]["SortSeq"] + " " + dtGrid.Rows[i]["invcode"]);
                }
            }
            catch (Exception ee)
            {
                msgBox.Text = "加载采购入库单失败";
                msgBox.textBox1.Text = ee.Message;
                msgBox.ShowDialog();
                msgBox.WindowState = FormWindowState.Maximized;
            }
        }


        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                s行号 = "";
                for (int i = 0; i < listBox2.Items.Count; i++)
                {
                    if (s行号 != "")
                    {
                        s行号 = s行号 + ",";
                    }
                    s行号 = s行号 + listBox2.Items[i].ToString().Split(' ')[0];
                }
                this.Close();
            }
            catch (Exception ee)
            {
                msgBox.Text = "操作失败";
                msgBox.textBox1.Text = ee.Message;
                msgBox.ShowDialog();
                msgBox.WindowState = FormWindowState.Maximized;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void btn全选_Click(object sender, EventArgs e)
        {
            for (int i = listBox1.Items.Count - 1; i >= 0; i--)
            {
                listBox2.Items.Add(listBox1.Items[i]);
                listBox1.Items.RemoveAt(i);
            }
        }

        private void btn选择_Click(object sender, EventArgs e)
        {
            if (listBox1.SelectedIndex >= 0)
            {
                listBox2.Items.Add(listBox1.Items[listBox1.SelectedIndex]); 
                listBox1.Items.RemoveAt(listBox1.SelectedIndex);
            }
        }

        private void btn消除_Click(object sender, EventArgs e)
        {
            if (listBox2.SelectedIndex >= 0)
            {
                listBox1.Items.Add(listBox2.Items[listBox2.SelectedIndex]);
                listBox2.Items.RemoveAt(listBox2.SelectedIndex);
            }
        }

        private void btn全消_Click(object sender, EventArgs e)
        {
            for (int i = listBox2.Items.Count - 1; i >= 0; i--)
            {
                listBox1.Items.Add(listBox2.Items[i]);
                listBox2.Items.RemoveAt(i);
            }
        }
    }
}