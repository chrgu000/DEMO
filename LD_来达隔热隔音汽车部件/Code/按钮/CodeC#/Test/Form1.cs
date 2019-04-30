using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Collections;
using System.IO;

namespace Test
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void btnPrintPU_ArrivalVouch_Click(object sender, EventArgs e)
        {
            clsU8.FrmPrintPU_ArrivalVouch frm = new clsU8.FrmPrintPU_ArrivalVouch("192.168.30.125", "sa", "189.cn", "UFDATA_012_2017", "0000000001", "demo");
            frm.ShowDialog();
        }

        private void btnPrintDispatchList_Click(object sender, EventArgs e)
        {
            clsU8.FrmPrintDispatchList frm = new clsU8.FrmPrintDispatchList("192.168.30.125", "sa", "189.cn", "UFDATA_012_2017", "SD18040001", "demo");
            frm.ShowDialog();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void btn打印生产流转单_Click(object sender, EventArgs e)
        {
            clsU8.FrmPrintWork1 frm = new clsU8.FrmPrintWork1("192.168.30.125", "sa", "189.cn", "UFDATA_012_2017", "00071", "demo");
            frm.ShowDialog();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            clsU8.FrmPrintWork2 frm = new clsU8.FrmPrintWork2("192.168.30.125", "sa", "189.cn", "UFDATA_012_2017", "00071", "demo");
            frm.ShowDialog();
        }

    }
}
