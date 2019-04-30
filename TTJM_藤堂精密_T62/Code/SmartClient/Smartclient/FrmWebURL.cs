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
    public partial class FrmWebURL : Form
    {
        public FrmWebURL()
        {
            InitializeComponent();
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }


        private void FrmWebURL_Load(object sender, EventArgs e)
        {
            try
            {
                if (File.Exists(TH.Smart.BaseClass.ClsBaseDataInfo.sWebPath))
                {
                    StreamReader sr = new StreamReader(TH.Smart.BaseClass.ClsBaseDataInfo.sWebPath);
                    txtURL.Text = sr.ReadToEnd().Trim();
                    sr.Close();
                }
                else
                {
                    File.Create(TH.Smart.BaseClass.ClsBaseDataInfo.sWebPath);
                }
            }
            catch(Exception ee)
            {
                MessageBox.Show("加载窗体失败");
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtURL.Text.Trim() == "")
                {
                    txtURL.Focus();
                    throw new Exception("连接不能为空");
                }
                TH.Smart.BaseClass.ClsBaseDataInfo.sConnString = @"http://" + txtURL.Text.Trim() + @"/webTTJM/DBScanForCheck.asmx";

                TH.Smart.WebService.ClsUseWebService clsWeb = new TH.Smart.WebService.ClsUseWebService();
                if (clsWeb.HelloWork() == "Hello World")
                {
                    FileStream fs1 = new FileStream(TH.Smart.BaseClass.ClsBaseDataInfo.sWebPath, FileMode.Open, FileAccess.Write);
                    StreamWriter sw = new StreamWriter(fs1);
                    try
                    {
                        sw.WriteLine(this.txtURL.Text.Trim());

                        this.DialogResult = DialogResult.OK;
                    }
                    catch (Exception ee)
                    {
                        MessageBox.Show("保存网络服务地址失败");
                    }
                    finally
                    {
                        sw.Close();
                        fs1.Close();
                    }
                }
                else
                {
                    throw new Exception("网络地址配置不正确，或网络不通");
                }
            }
            catch (Exception ee)
            {
                MessageBox.Show(ee.Message);
            }
        }
    }
}