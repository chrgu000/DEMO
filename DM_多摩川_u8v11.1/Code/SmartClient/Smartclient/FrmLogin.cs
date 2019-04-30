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
    public partial class FrmLogin :Form
    {
        TH.Smart.BaseClass.ClsDES clsDES = TH.Smart.BaseClass.ClsDES.Instance();

        public FrmLogin()
        {
            InitializeComponent();

        }


        private void btnLogin_Click(object sender, EventArgs e)
        {
            try
            {
                if (TH.Smart.BaseClass.ClsBaseDataInfo.sConnString == "")
                {
                    throw new Exception("请先设置连接");
                }

                if (comboBoxPrint.Text.Trim() == "")
                {
                    comboBoxPrint.Focus();
                    throw new Exception("请选择打印机");
                }

                string sUid = txtUid.Text.Trim();
                string sPwd = clsDES.Encrypt(txtPwd.Text.Trim());
                TH.Smart.WebService.ClsUseWebService clsWeb = new TH.Smart.WebService.ClsUseWebService();
                string s = clsWeb.sLogin(sUid, sPwd);

                if (s == "")
                {
                    this.DialogResult = DialogResult.Yes;
                    TH.Smart.BaseClass.ClsBaseDataInfo.sUid = sUid;
                    TH.Smart.BaseClass.ClsBaseDataInfo.sUid = txtUid.Text.Trim();
                    TH.Smart.BaseClass.ClsBaseDataInfo.sLogDate = dtmLogin.Value.ToString("yyyy-MM-dd HH;mm:ss");
                    TH.Smart.BaseClass.ClsBaseDataInfo.sPrintName = comboBoxPrint.Text.Trim();

                    this.Close();
                }
                else
                {
                    MessageBox.Show(s);
                }

            }
            catch (Exception ee)
            {
                MsgBox m = new MsgBox();
                m.textBox1.Text = ee.Message;
                m.Text = "登陆失败";
                m.ShowDialog();
            }
        }

        string sUrl = "";
        private void Frm_Load(object sender, EventArgs e)
        {
            try
            {
                TH.Smart.BaseClass.ClsBaseDataInfo.sWebPath = Path.GetDirectoryName(Assembly.GetExecutingAssembly().ManifestModule.FullyQualifiedName) + @"\WebURL.txt";
                if (!File.Exists(TH.Smart.BaseClass.ClsBaseDataInfo.sWebPath))
                {
                    MessageBox.Show("请先设置连接");
                    FrmWebURL f = new FrmWebURL();
                    f.ShowDialog();
                }

                StreamReader sr = new StreamReader(TH.Smart.BaseClass.ClsBaseDataInfo.sWebPath);
                string sUrl = sr.ReadToEnd().Trim();
                if (sUrl.Trim() != "")
                {
                    TH.Smart.BaseClass.ClsBaseDataInfo.sConnString = @"http://" + sUrl.Trim() + @"/webDMC/DBScanForCheck.asmx";
                }
                sr.Close();

                if (TH.Smart.BaseClass.ClsBaseDataInfo.sConnString == "")
                {
                    MessageBox.Show("请先设置连接");
                    FrmWebURL f = new FrmWebURL();
                    f.ShowDialog();
                }

                TH.Smart.WebService.ClsUseWebService clsWeb = new TH.Smart.WebService.ClsUseWebService();
                if (clsWeb.HelloWork() != "Hello World")
                {
                    throw new Exception("网络地址配置不正确，或网络不通");
                }

                DateTime d =Convert.ToDateTime(clsWeb.sServerTime());
                if (d > Convert.ToDateTime("1900-01-01"))
                {
                    dtmLogin.Value = d;
                }

                txtUid.Focus();
            }
            catch (Exception ee)
            {
                MessageBox.Show(ee.Message);
            }
        }

        private void btnSetWebURL_Click(object sender, EventArgs e)
        {
            try
            {           
                FrmWebURL f = new FrmWebURL();
                f.WindowState = FormWindowState.Maximized;
                f.ShowDialog();

                TH.Smart.WebService.ClsUseWebService clsWeb = new TH.Smart.WebService.ClsUseWebService();
                DateTime d = Convert.ToDateTime(clsWeb.sServerTime());
                if (d > Convert.ToDateTime("1900-01-01"))
                {
                    dtmLogin.Value = d;
                }
                txtUid.Focus();
            }
            catch (Exception ee)
            {
                MsgBox m = new MsgBox();
                m.textBox1.Text = "加载Web服务设置窗口失败:" + ee.Message;
                m.Text = "提示";
                m.ShowDialog();
            }
        }

        private void txtUid_KeyUp(object sender, KeyEventArgs e)
        {
            try
            {
                if (txtUid.Text.Trim() == "" && txtPwd.Text.Trim() != "")
                {
                    MessageBox.Show("账号不能为空");
                    return;
                }

                if (e.KeyCode == Keys.Enter)
                {
                    txtPwd.Focus();
                }
            }
            catch { }
        }

        private void txtPwd_KeyUp(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Enter)
                {
                    btnLogin_Click(null, null);
                }
            }
            catch { }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}