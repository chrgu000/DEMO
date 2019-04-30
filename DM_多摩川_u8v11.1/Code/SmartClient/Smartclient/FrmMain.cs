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
            }
            catch (Exception ee)
            {
                MsgBox m = new MsgBox();
                m.ShowDialog();
                m.textBox1.Text = ee.Message;
                m.Text = "提示";
            }
        }


        private void btnChangePwd_Click(object sender, EventArgs e)
        {
            try
            {
                FrmChangePwd f = new FrmChangePwd();
                f.WindowState = FormWindowState.Maximized;
                f.ShowDialog();
            }
            catch (Exception ee)
            {
                MsgBox m = new MsgBox();
                m.ShowDialog();
                m.textBox1.Text = ee.Message;
                m.Text = "提示";
            }
        }
      

        /// <summary>
        /// 采购入库
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnRdRecord01_Click(object sender, EventArgs e)
        {
            try
            {
                TH.Smart.WebService.ClsUseWebService clsWeb = new TH.Smart.WebService.ClsUseWebService();
                string s = clsWeb.sCheckRight("2010", sUserID);
                if (s != "1")
                {
                    MessageBox.Show("没有权限");
                    return;
                }

                FrmRdrecord01 f = new FrmRdrecord01();
                f.WindowState = FormWindowState.Maximized;
                f.ShowDialog();
            }
            catch (Exception ee)
            {
                MessageBox.Show(ee.Message);
            }
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        /// <summary>
        /// 作废条形码
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnBarCodeInvalid_Click(object sender, EventArgs e)
        {
            try
            {
                TH.Smart.WebService.ClsUseWebService clsWeb = new TH.Smart.WebService.ClsUseWebService();
                string s = clsWeb.sCheckRight("2110", sUserID);
                if (s != "1")
                {
                    MessageBox.Show("没有权限");
                    return;
                }

                FrmBarCodeInvalid f = new FrmBarCodeInvalid();
                f.WindowState = FormWindowState.Maximized;
                f.ShowDialog();
            }
            catch (Exception ee)
            {
                MessageBox.Show(ee.Message);
            }
        }

        private void btnrdRecord11_Click(object sender, EventArgs e)
        {
            try
            {
                TH.Smart.WebService.ClsUseWebService clsWeb = new TH.Smart.WebService.ClsUseWebService();
                string s = clsWeb.sCheckRight("2020", sUserID);
                if (s != "1")
                {
                    MessageBox.Show("没有权限");
                    return;
                }

                FrmRdrecord11 f = new FrmRdrecord11();
                f.WindowState = FormWindowState.Maximized;
                f.ShowDialog();
            }
            catch (Exception ee)
            {
                MessageBox.Show(ee.Message);
            }
        }

        private void btnTransVouch_Click(object sender, EventArgs e)
        {
            try
            {
                TH.Smart.WebService.ClsUseWebService clsWeb = new TH.Smart.WebService.ClsUseWebService();
                string s = clsWeb.sCheckRight("2070", sUserID);
                if (s != "1")
                {
                    MessageBox.Show("没有权限");
                    return;
                }

                FrmTransVouch f = new FrmTransVouch();
                f.WindowState = FormWindowState.Maximized;
                f.ShowDialog();

            }
            catch (Exception ee)
            {
                MessageBox.Show(ee.Message);
            }
        }

        private void btnCheckVouch_Click(object sender, EventArgs e)
        {
            try
            {
                TH.Smart.WebService.ClsUseWebService clsWeb = new TH.Smart.WebService.ClsUseWebService();
                string s = clsWeb.sCheckRight("2080", sUserID);
                if (s != "1")
                {
                    MessageBox.Show("没有权限");
                    return;
                }

                FrmCheckVouch f = new FrmCheckVouch();
                f.WindowState = FormWindowState.Maximized;
                f.ShowDialog();

            }
            catch (Exception ee)
            {
                MessageBox.Show(ee.Message);
            }
        }

        private void btnBox_Click(object sender, EventArgs e)
        {
            try
            {
                TH.Smart.WebService.ClsUseWebService clsWeb = new TH.Smart.WebService.ClsUseWebService();
                string s = clsWeb.sCheckRight("2090", sUserID);
                if (s != "1")
                {
                    MessageBox.Show("没有权限");
                    return;
                }

                FrmBox f = new FrmBox();
                f.WindowState = FormWindowState.Maximized;
                f.ShowDialog();
            }
            catch (Exception ee)
            {
                MessageBox.Show(ee.Message);
            }
        }

        private void btnUnBox_Click(object sender, EventArgs e)
        {
            try
            {
                TH.Smart.WebService.ClsUseWebService clsWeb = new TH.Smart.WebService.ClsUseWebService();
                string s = clsWeb.sCheckRight("2100", sUserID);
                if (s != "1")
                {
                    MessageBox.Show("没有权限");
                    return;
                }

                FrmUnBox f = new FrmUnBox();
                f.WindowState = FormWindowState.Maximized;
                f.ShowDialog();
            }
            catch (Exception ee)
            {
                MessageBox.Show(ee.Message);
            }
        }

        private void btnRdrecord10_Click(object sender, EventArgs e)
        {
            try
            {
                TH.Smart.WebService.ClsUseWebService clsWeb = new TH.Smart.WebService.ClsUseWebService();
                string s = clsWeb.sCheckRight("2030", sUserID);
                if (s != "1")
                {
                    MessageBox.Show("没有权限");
                    return;
                }

                FrmRdrecord10 f = new FrmRdrecord10();
                f.WindowState = FormWindowState.Maximized;
                f.ShowDialog();
            }
            catch (Exception ee)
            {
                MessageBox.Show(ee.Message);
            }
        }

        private void btnDispatchList_Click(object sender, EventArgs e)
        {
            try
            {
                TH.Smart.WebService.ClsUseWebService clsWeb = new TH.Smart.WebService.ClsUseWebService();
                string s = clsWeb.sCheckRight("2040", sUserID);
                if (s != "1")
                {
                    MessageBox.Show("没有权限");
                    return;
                }

                FrmDispatchList f = new FrmDispatchList();
                f.WindowState = FormWindowState.Maximized;
                f.ShowDialog();
            }
            catch (Exception ee)
            {
                MessageBox.Show(ee.Message);
            }
        }

        private void btnBarCodeAdjust_Click(object sender, EventArgs e)
        {
            try
            {
                TH.Smart.WebService.ClsUseWebService clsWeb = new TH.Smart.WebService.ClsUseWebService();
                string s = clsWeb.sCheckRight("2120", sUserID);
                if (s != "1")
                {
                    MessageBox.Show("没有权限");
                    return;
                }

                FrmBarCodeAdjust f = new FrmBarCodeAdjust();
                f.WindowState = FormWindowState.Maximized;
                f.ShowDialog();
            }
            catch (Exception ee)
            {
                MessageBox.Show(ee.Message);
            }
        }

        private void btnrdRecord09_Click(object sender, EventArgs e)
        {
            try
            {
                TH.Smart.WebService.ClsUseWebService clsWeb = new TH.Smart.WebService.ClsUseWebService();
                string s = clsWeb.sCheckRight("2060", sUserID);
                if (s != "1")
                {
                    MessageBox.Show("没有权限");
                    return;
                }

                FrmRdrecord09 f = new FrmRdrecord09();
                f.WindowState = FormWindowState.Maximized;
                f.ShowDialog();

            }
            catch (Exception ee)
            {
                MessageBox.Show(ee.Message);
            }
        }

        private void btnrdRecord08_Click(object sender, EventArgs e)
        {
            try
            {
                TH.Smart.WebService.ClsUseWebService clsWeb = new TH.Smart.WebService.ClsUseWebService();
                string s = clsWeb.sCheckRight("2050", sUserID);
                if (s != "1")
                {
                    MessageBox.Show("没有权限");
                    return;
                }

                FrmRdrecord08 f = new FrmRdrecord08();
                f.WindowState = FormWindowState.Maximized;
                f.ShowDialog();
            }
            catch (Exception ee)
            {
                MessageBox.Show(ee.Message);
            }
        }
    }
}