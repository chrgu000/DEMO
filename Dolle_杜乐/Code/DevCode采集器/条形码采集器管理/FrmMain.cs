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
    public partial class FrmMain : FrmBase
    {
        public FrmMain()
        {
            InitializeComponent();
        }

        private void btn采购入库_Click(object sender, EventArgs e)
        {
            Frm材料入库 f材料入库 = new Frm材料入库();
            f材料入库.ShowDialog();
        }

        private void btn委外发料_Click(object sender, EventArgs e)
        {
            Frm委外生单发料 f委外生单发料 = new Frm委外生单发料();
            f委外生单发料.ShowDialog();
        }

        private void FrmMain_Load(object sender, EventArgs e)
        {
            this.Text = MobileBaseDLL.ClsBaseDataInfo.sConnServer;

            Frm登录 f登陆 = new Frm登录();
            DialogResult d = f登陆.ShowDialog();
            if (d != DialogResult.Yes)
            {
                MessageBox.Show("登陆失败");
                this.Close();
            }
        }

        private void btn到货_Click(object sender, EventArgs e)
        {
            Frm到货 f采购到货 = new Frm到货();
            f采购到货.ShowDialog();
        }

        private void btn委外材料出库_Click(object sender, EventArgs e)
        {
            Frm委外材料出库 f委外材料出库 = new Frm委外材料出库();
            f委外材料出库.ShowDialog();
        }

        private void btn调拨出库_Click(object sender, EventArgs e)
        {
            Frm调拨出库 f调拨出库 = new Frm调拨出库();
            f调拨出库.ShowDialog();
        }

        private void btn其他入库_Click(object sender, EventArgs e)
        {
            Frm其他入库货位 f其他入库 = new Frm其他入库货位();
            f其他入库.ShowDialog();
        }

        private void btn其他出库_Click(object sender, EventArgs e)
        {
            Frm其他出库货位 f其他出库 = new Frm其他出库货位();
            f其他出库.ShowDialog();
        }

        private void btn委外生单发料_Click(object sender, EventArgs e)
        {
            Frm委外生单发料 f委外 = new Frm委外生单发料();
            f委外.ShowDialog();
        }

        private void btn缴库产品入库_Click(object sender, EventArgs e)
        {
            Frm缴库产品入库 f缴库 = new Frm缴库产品入库();
            f缴库.ShowDialog();
        }

        private void btn产品入库货位_Click(object sender, EventArgs e)
        {
            Frm产品入库货位 f产品入库 = new Frm产品入库货位();
            f产品入库.ShowDialog();
        }

        private void btn委外毛坯退回_Click(object sender, EventArgs e)
        {
            Frm委外毛坯退回 f = new Frm委外毛坯退回();
            f.ShowDialog();
        }
    }
}