using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.IO;
using System.Data.SqlClient;
using System.Xml;

namespace 系统服务
{
    public partial class FrmLogin : Form
    {
        系统服务.ClsXMLCommond clsXML = new 系统服务.ClsXMLCommond();
        ClsUseWebService clsWeb = new ClsUseWebService();
        系统服务.ClsDES clsDES;
        private bool bSetInfo = false;                      //初始状态，未点击设置
        private string sPathConfig = Application.StartupPath + @"\App.dll";
      
        int iWidth = 0;
        int iHeigth = 0;

        string WebURL = "";
        public FrmLogin()
        {
            系统服务.ClsBaseDataInfo.sDataBaseType = GetConfigValue(sPathConfig, "DataBaseType");
            InitializeComponent();

            try
            {
                //clsSQLCommond = 系统服务.ClsDataBaseFactory.Instance();
                clsDES = 系统服务.ClsDES.Instance();

            }
            catch
            { }
        }


        private void FrmLogin_Load(object sender, EventArgs e)
        {
            try
            {
                dtmLogin.DateTime = DateTime.Today;


                if (系统服务.ClsBaseDataInfo.sConnString.Trim().ToLower() == "server=;uid=;pwd=;database=;timeout=")
                {
                    return;
                }

                if (txtUID.Text.Trim() != string.Empty)
                    txtPWD.Focus();
                else
                    txtUID.Focus();

                txtUID.Text = GetConfigValue(sPathConfig, "UserInfo");
            }
            catch (Exception ee)
            {
                MessageBox.Show("加载窗体失败！ 原因如下：\n  " + ee.Message, "提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            try
            {
                if (!chkBaseInfo())
                {
                    MessageBox.Show("请检查信息是否完整", "提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
               
                string sErrInfo;

                if (!Login(out sErrInfo))
                {
                    MessageBox.Show("登陆失败！\n\n原因:\n  " + sErrInfo, "提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtUID.Focus();
                    return;
                }

                if (chkPWD.Checked)
                {
                    string sPWD = "";
                    FrmChangePWD frmChgPWD = new FrmChangePWD();
                    frmChgPWD.ShowDialog();
                    if (frmChgPWD.DialogResult == DialogResult.OK)
                    {
                        sPWD = frmChgPWD.sNewPWD;

                        //string sSQL = "update _UserInfo set vchrPwd = '" + clsDES.Encrypt(sPWD) + "' where vchrUid = '" + txtUID.Text.Trim() + "'";
                        //clsSQLCommond.ExecSql(sSQL);
                        string s = clsWeb.saveUserInfoPwd(txtUID.Text.Trim(), clsDES.Encrypt(sPWD));
                        if (s != "")
                        {
                            throw new Exception(s);
                        }
                        MessageBox.Show("修改密码成功！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                    }
                }

                WriteConfig();
                
                try
                {
                    系统服务.ClsBaseDataInfo.sUid = txtUID.Text.Trim();
                    系统服务.ClsBaseDataInfo.sLogDate = dtmLogin.Text.Trim();

                    //string sSQL = "select vchrName from dbo._UserInfo where vchrUid = '" + txtUID.Text.Trim() + "' ";
                    //系统服务.ClsBaseDataInfo.sUserName = clsSQLCommond.ExecGetScalar(sSQL).ToString().Trim();
                    系统服务.ClsBaseDataInfo.sUserName = clsWeb.svchrName(txtUID.Text.Trim());
        
                }
                catch
                { }

                DialogResult = DialogResult.OK;
            }
            catch(Exception ee)
            {
                MessageBox.Show("登陆失败！ " + ee.Message, "提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// 设置信息是否完整
        /// </summary>
        /// <returns></returns>
        private bool chkBaseInfo()
        {
            if (txtUID.Text.Trim() == string.Empty)
                return false;
            //if (txtServer.Text.Trim() == string.Empty)
            //    return false;
            //if (txtUserID.Text.Trim() == string.Empty)
            //    return false;
            //if (txtDataBase.Text.Trim() == string.Empty)
            //    return false;
           
            return true;
        }

        private void WriteConfig()
        {
            XmlDocument xmlDoc = new XmlDocument();
            InitAppConfig();

            xmlDoc.Load(sPathConfig);
            XmlNodeList nodes = xmlDoc.SelectNodes("configuration/appSettings/add");
            foreach (XmlNode node in nodes)
            {
   
                if (node.Attributes["key"].Value == "UserInfo")
                    node.Attributes["value"].Value = txtUID.Text.Trim();
            }
            xmlDoc.Save(sPathConfig);
        }

        private void InitAppConfig()
        {
            if (!File.Exists(sPathConfig))
            {
                File.WriteAllText(sPathConfig, @"<?xml version='1.0' encoding='GB2312'?> " +
                                        @"<configuration> " +
                                        @"  <appSettings> " +
                                        @"    <add key='ConnType' value='' /> " +
                                        @"    <add key='UserInfo' value='' /> " +
                                        @"    <add key='AccountInfo' value='' /> " +
                                        @"    <add key='ServerInfo' value='' /> " +
                                        @"    <add key='DataBaseType' value='SQL Server' /> " +
                                        @"    <add key='DataBaseInfo' value='' /> " +
                                        @"    <add key='SQLUID' value='' /> " +
                                        @"    <add key='SQLPWD' value='' /> " +
                                        @"    <add key='SQLConnTimeOut' value='200' /> " +
                                        @"    <add key='HttpDownPath' value='' /> " +
                                        @"    <add key='Edition' value='-1' /> " +
                                        @"    <add key='ComName' value='' /> " +
                                        @"    <add key='ProName' value='' /> " +
                                        @"    <add key='SN' value='' /> " +
                                        @"  </appSettings> " +
                                        @"</configuration>");
            }
        }

        private bool Login(out string sEr)
        {
            bool b = false;
            sEr = "";
            try
            {
                string sUser = txtUID.Text.Trim();
                string sPwd = clsDES.Encrypt(txtPWD.Text.Trim());
                DataTable dt = clsWeb.dtUserInfo(sUser, sPwd);

                int iCou = dt.Rows.Count;
                if (iCou == 1)
                {
                    if (DateTime.Parse(Convert.ToDateTime(dt.Rows[0]["dtmClose"]).ToString("yyyy-MM-dd")) < DateTime.Today.AddDays(+1))
                    {
                        sEr = "帐号已被停用！";
                    }
                    else
                    {
                        string s = clsWeb.saveDefine1(txtUID.Text.Trim());
                        if (s == "")
                        {
                            b = true;
                        }
                    }
                }
                else
                {
                    sEr = "帐号或者密码错误！";
                }

            }
            catch(Exception ee)
            {
                sEr = ee.Message;
                b = false;
            }
            return b;
        }
       

        private void btnExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }



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

        private void btnSet_Click(object sender, EventArgs e)
        {
            try
            {
                WriteConfig();
             
                FrmLogin_Load(null, null);;
            }
            catch (Exception ee)
            {
                MessageBox.Show(ee.Message, "提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnSetAppConfig_Click(object sender, EventArgs e)
        {
            XmlDocument xmlDoc = new XmlDocument();
            InitAppConfig();

            xmlDoc.Load(sPathConfig);
            XmlNodeList nodes = xmlDoc.SelectNodes("configuration/appSettings/add");
            foreach (XmlNode node in nodes)
            {
                //if (node.Attributes["key"].Value == "ComName")
                //    node.Attributes["value"].Value = txtComName.Text.Trim();
                //if (node.Attributes["key"].Value == "ProName")
                //    node.Attributes["value"].Value = txtProName.Text.Trim();
                //if (node.Attributes["key"].Value == "SN")
                //    node.Attributes["value"].Value = txtSN.Text.Trim();

            }
            xmlDoc.Save(sPathConfig);
        }
    }
}
