using System;
using System.Linq;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.IO;
using System.Reflection;

namespace Smartclient
{
    public partial class FrmMain : FrmBase
    {
        DataTable dt工序;

        public FrmMain()
        {
            InitializeComponent();
        }

        private void FrmMain_Load(object sender, EventArgs e)
        {
            try
            {
                FrmLogin f = new FrmLogin();
                DialogResult d = f.ShowDialog();
                if (d != DialogResult.Yes)
                {
                    MessageBox.Show("登陆失败");
                    this.Close();
                }

                sUserID = TH.Smart.BaseClass.ClsBaseDataInfo.sUid;

                labelUid.Text = labelUid.Text.Replace("111111", TH.Smart.BaseClass.ClsBaseDataInfo.sUid);
            }
            catch (Exception ee)
            {
                MsgBox m = new MsgBox();
                m.textBox1.Text = ee.Message;
                m.ShowDialog();
                m.Text = "提示";
            }
        }


        private void btn退出_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btn工序转移_Click(object sender, EventArgs e)
        {
            try
            {
                Frm工序转移 f = new Frm工序转移();
                f.ShowDialog();
            }
            catch (Exception ee)
            {
                MessageBox.Show("加载工序转移失败");
            }
        }

        private void btn条形码查看_Click(object sender, EventArgs e)
        {
            try
            {
                Frm条形码执行统计 f = new Frm条形码执行统计();
                f.ShowDialog();
            }
            catch (Exception ee)
            {
                MessageBox.Show("加载条形码执行统计失败");
            }
        }

        private void btn工单查看_Click(object sender, EventArgs e)
        {
            try
            {
                Frm生产订单执行统计 f = new Frm生产订单执行统计();
                f.ShowDialog();
            }
            catch (Exception ee)
            {
                MessageBox.Show("加载产品入库失败");
            }
        }

        private void btn产品入库_Click(object sender, EventArgs e)
        {
            try
            {
                Frm产品入库 f = new Frm产品入库();
                f.ShowDialog();
            }
            catch (Exception ee)
            {
                MessageBox.Show("加载产品入库失败");
            }
        }
    }
}