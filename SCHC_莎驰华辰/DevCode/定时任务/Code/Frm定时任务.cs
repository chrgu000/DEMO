using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Xml;
using System.Runtime.InteropServices;

namespace 定时任务
{
    public partial class Frm定时任务 : Form
    {
        private string sPathConfig = Application.StartupPath + @"\App.dll";
        private string sPathTxt = Application.StartupPath + @"\log.txt";


        TH.WindowsService.ClsRunOverTime clsOverTime;
        TH.WindowsService.Clshr_tm_OriCardData clsHrCard;

        public Frm定时任务()
        {
            InitializeComponent();
            
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            try
            {
                if (DateTime.Now.ToString("mm:ss") == "00:00")
                {
                    btnKQData_Click(null, null);
                }
                if (DateTime.Now.ToString("mm:ss") == "30:00")
                {
                    btnJB_Click(null, null);
                }

            }
            catch { }
        }

        ///
        /// Read confing
        /// </summary>
        /// <param name="path"></param>
        /// <param name="appKey"></param>
        /// <returns></returns>
        public string GetConfigValue(string path, string appKey)
        {
            XmlDocument xDoc = new XmlDocument();
            try
            {
                xDoc.Load(path);
                XmlNode xNode;
                XmlElement xElem;
                xNode = xDoc.SelectSingleNode("//appSettings");
                xElem = (XmlElement)xNode.SelectSingleNode("//add[@key='" + appKey + "']");
                if (xElem != null)
                    return xElem.GetAttribute("value");
                else
                    return "";
            }
            catch (Exception)
            {
                return "";
            }
        }

        private void Frm定时任务_Load(object sender, EventArgs e)
        {
            try
            {
                try
                {
                    this.WindowState = FormWindowState.Normal;  //还原窗体
                    this.ShowInTaskbar = false;  //不显示在系统任务栏
                    notifyIcon1.Visible = true;    //托盘图标可见


                    TH.BaseClass.ClsDES clsDES = TH.BaseClass.ClsDES.Instance();

                    this.StartPosition = FormStartPosition.CenterScreen;

                    string s1 = GetConfigValue(sPathConfig, "ServerInfo");
                    string s2 = clsDES.Decrypt(GetConfigValue(sPathConfig, "SQLPWD"));
                    string s3 = GetConfigValue(sPathConfig, "DataBaseInfo");
                    string s4 = GetConfigValue(sPathConfig, "SQLUID");
                    string sConn = "server=" + s1 + ";uid=" + s4 + ";pwd=" + s2 + ";database=" + s3 + "";

                    TH.BaseClass.ClsBaseDataInfo.sConnString = sConn;
                    TH.BaseClass.DbHelperSQL.connectionString = sConn;
                    clsOverTime = new TH.WindowsService.ClsRunOverTime(sPathConfig, sPathTxt, Application.StartupPath);
                    clsHrCard = new TH.WindowsService.Clshr_tm_OriCardData(sPathConfig, sPathTxt, Application.StartupPath);
                }
                catch { }

                timer1.Start();
            }
            catch (Exception ee)
            {
                MessageBox.Show(ee.Message);
            }
        }

        private void notifyIcon1_DoubleClick(object sender, EventArgs e)
        {
            try
            {
                if (this.WindowState == FormWindowState.Minimized)
                {
                    this.WindowState = FormWindowState.Normal;  //还原窗体
                    this.ShowInTaskbar = false;  //不显示在系统任务栏
                    notifyIcon1.Visible = true;  //托盘图标显示
                }
                else
                {
                    this.WindowState = FormWindowState.Minimized;
                    this.ShowInTaskbar = false;  //不显示在系统任务栏
                    notifyIcon1.Visible = true;  //托盘图标显示
                }
            }
            catch (Exception ee)
            {
                MessageBox.Show(ee.Message);
            }
        }

        private void Frm定时任务_SizeChanged(object sender, EventArgs e)
        {
            try
            {
                if (this.WindowState == FormWindowState.Minimized)  //判断是否最小化
                {
                    this.ShowInTaskbar = false;  //不显示在系统任务栏
                    notifyIcon1.Visible = true;    //托盘图标可见
                }
            }
            catch (Exception ee)
            {
                MessageBox.Show(ee.Message);
            }
        }


        //自动生成加班单
        private void btnJB_Click(object sender, EventArgs e)
        {
            try
            {
                DateTime dNow;
                clsOverTime.RunOverTime(out dNow);
                if (dNow > Convert.ToDateTime("2000-01-01"))
                {
                    txt成功时间2.Text = dNow.ToString("yyyy-MM-dd HH:mm:ss");
                }
            }
            catch { }
        }

        //连接苏特考勤机数据库
        private void btnKQData_Click(object sender, EventArgs e)
        {
            try
            {
                DateTime dNow;

                int iDays = 15;
                try
                {
                    iDays = Convert.ToInt32(comboBox3.Text.Trim());
                }
                catch 
                {
                    iDays = 1;
                }
                clsHrCard.RunCardDataSQL(out dNow, iDays);

                if (dNow > Convert.ToDateTime("2000-01-01"))
                {
                    textBox1.Text = dNow.ToString("yyyy-MM-dd HH:mm:ss");
                }
            }
            catch { }
        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
