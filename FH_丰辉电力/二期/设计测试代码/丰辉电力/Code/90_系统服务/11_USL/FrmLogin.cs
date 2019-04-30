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
        //ClsUseWebService clsWeb = new ClsUseWebService();
        系统服务.ClsDataBase clsSQLCommond;
        系统服务.ClsDES clsDES;
        private bool bSetInfo = false;                      //初始状态，未点击设置
        private string sPathConfig = Application.StartupPath + @"\App.dll";
      
        int iWidth = 0;
        int iHeigth = 0;
        bool bU8Improt = true;

        string WebURL = "";
        public FrmLogin()
        {
            系统服务.ClsBaseDataInfo.sDataBaseType = GetConfigValue(sPathConfig, "DataBaseType");
            InitializeComponent();

            try
            {
                clsSQLCommond = 系统服务.ClsDataBaseFactory.Instance();
                clsDES = 系统服务.ClsDES.Instance();

                InitInfo();

                label1.Visible = bU8Improt;
                lookUpAcc.Visible = bU8Improt;

                tabControl1.Visible = false;
            }
            catch
            { }
        }

        /// <summary>
        /// 获得帐套数据,
        /// </summary>
        /// <param name="sSQL"></param>
        private void GetAccInfo()
        {
            try
            {
                string sSQL = "SELECT DISTINCT A.cAcc_Id,'[' + A.cAcc_Id + ']' + A.cAcc_Name as vchrText  " +
                         "FROM UFSystem.dbo.UA_Account A,UFSystem.dbo.UA_period P   " +
                         "WHERE A.cAcc_Id=P.cAcc_Id AND (P.bIsDelete=0 OR P.bIsDelete IS NULL)  " +
                         "ORDER BY A.cAcc_Id,vchrText";

                DataTable dt = clsSQLCommond.ExecQuery(sSQL);
                //DataTable dt = clsWeb.dtGetAccInfo();
                lookUpAcc.Properties.DataSource = dt;

                lookUpAcc.EditValue = GetConfigValue(sPathConfig, "AccountInfo");
            }
            catch
            {
                throw new Exception("获得帐套信息失败！");
            }
        }

        private void FrmLogin_Load(object sender, EventArgs e)
        {
            try
            {
                dtmLogin.DateTime = DateTime.Today;

                if (bU8Improt)
                {
                    lookUpAcc.Visible = true;
                    label1.Visible = true;
                }
                else
                {
                    lookUpAcc.Visible = false;
                    label1.Visible = false;
                }

                if (label1.Visible == false || lookUpAcc.Visible == false)
                {
                    label2.Top = label1.Top;
                    label2.Left = label1.Left;
                    dtmLogin.Top = lookUpAcc.Top;
                    dtmLogin.Left = lookUpAcc.Left;

                    int iH = label2.Top - label1.Top;
                    btnLogin.Top = dtmLogin.Top + 40;
                    btnSetInfo.Top = btnLogin.Top;

                    this.Height = btnLogin.Top + 70;

                    this.label10.Font = new System.Drawing.Font("华文行楷", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
                    this.label10.Size = new System.Drawing.Size(27, 90);
                }
                else
                {
                    btnLogin.Top = dtmLogin.Top + 40;

                    this.Height = btnLogin.Top + 70;

                    this.label10.Font = new System.Drawing.Font("华文行楷", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
                    this.label10.Size = new System.Drawing.Size(41, 114);

                }

                iWidth = this.Width;
                iHeigth = this.Height;


                if (系统服务.ClsBaseDataInfo.sConnString.Trim().ToLower() == "server=;uid=;pwd=;database=;timeout=")
                {
                    btnSetInfo_Click(null, null);
                    return;
                }

                if (txtUID.Text.Trim() != string.Empty)
                    txtPWD.Focus();
                else
                    txtUID.Focus();

                btnSetInfo.Enabled = false;

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
                if (bU8Improt && lookUpAcc.Text.Trim() == string.Empty)
                {
                    MessageBox.Show("请选择帐套", "提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    lookUpAcc.Focus();
                    return;
                }

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

                        string sSQL = "update _UserInfo set vchrPwd = '" + clsDES.Encrypt(sPWD) + "' where vchrUid = '" + txtUID.Text.Trim() + "'";
                        clsSQLCommond.ExecSql(sSQL);

                        MessageBox.Show("修改密码成功！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                    }
                    //string sPWD = "";
                    //FrmChangePWD frmChgPWD = new FrmChangePWD();
                    //frmChgPWD.ShowDialog();
                    //if (frmChgPWD.DialogResult == DialogResult.OK)
                    //{
                    //    sPWD = frmChgPWD.sNewPWD;

                    //    string sSQL = "update _UserInfo set vchrPwd = '" + clsDES.Encrypt(sPWD) + "' where vchrUid = '" + txtUID.Text.Trim() + "'";
                    //    clsSQLCommond.ExecSql(sSQL);
                    //    //string s = clsWeb.saveUserInfoPwd(txtUID.Text.Trim(), clsDES.Encrypt(sPWD));
                    //    if (s != "")
                    //    {
                    //        throw new Exception(s);
                    //    }
                    //    MessageBox.Show("修改密码成功！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                    //}
                }

                WriteConfig();
                
                try
                {
                    系统服务.ClsBaseDataInfo.sUid = txtUID.Text.Trim();
                    系统服务.ClsBaseDataInfo.sLogDate = dtmLogin.Text.Trim();
                    系统服务.ClsBaseDataInfo.sDataBaseName = txtDataBase.Text;
                    
                    if (bU8Improt)
                    {
                        系统服务.ClsBaseDataInfo.sUFDataBaseName = "UFDATA_" + lookUpAcc.EditValue.ToString().Trim() + "_" + dtmLogin.DateTime.ToString("yyyy").Trim();
                        系统服务.ClsBaseDataInfo.sUFDataBaseText = lookUpAcc.Text.Trim();
                        系统服务.ClsBaseDataInfo.sConnString2 = 系统服务.ClsBaseDataInfo.sConnString.Replace(系统服务.ClsBaseDataInfo.sDataBaseName, 系统服务.ClsBaseDataInfo.sUFDataBaseName);
                    }
                    string sSQL = "select vchrName from dbo._UserInfo where vchrUid = '" + txtUID.Text.Trim() + "' ";
                    系统服务.ClsBaseDataInfo.sUserName = clsSQLCommond.ExecGetScalar(sSQL).ToString().Trim();
                    //系统服务.ClsBaseDataInfo.sUserName = clsWeb.svchrName(txtUID.Text.Trim());
                    if (bU8Improt)
                    {
                        sSQL = "select count(*) from Master.dbo.sysdatabases where name='" + 系统服务.ClsBaseDataInfo.sUFDataBaseName + "'";
                        int iCou = Convert.ToInt32(clsSQLCommond.ExecGetScalar(sSQL));
                        //int iCou = 系统服务.规格化.ReturnInt(clsWeb.sbU8Improt(系统服务.ClsBaseDataInfo.sUFDataBaseName));
                        if (iCou == 0)
                        {
                            MessageBox.Show("年度帐不存在，日期请选择" + dtmLogin.DateTime.AddYears(-1).ToString("yyyy").Trim() + "-12-31");
                            return;
                        }
                    }
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
                if (node.Attributes["key"].Value == "ConnType")
                {
                    if(radioSQLServer.Checked)
                        node.Attributes["value"].Value = "SQL Server";
                    if (radioWindows.Checked)
                        node.Attributes["value"].Value = "Windows";
                }
                if (node.Attributes["key"].Value == "UserInfo")
                    node.Attributes["value"].Value = txtUID.Text.Trim();
               
                if (node.Attributes["key"].Value == "AccountInfo")
                    if (bU8Improt)
                        node.Attributes["value"].Value = "UFDATA_" + lookUpAcc.EditValue.ToString().Trim() + "_" + dtmLogin.DateTime.ToString("yyyy").Trim(); 
                if (node.Attributes["key"].Value == "ServerInfo")
                    node.Attributes["value"].Value = txtServer.Text.Trim();
                if (node.Attributes["key"].Value == "DataBaseInfo")
                    node.Attributes["value"].Value = txtDataBase.Text.Trim();
                if (node.Attributes["key"].Value == "SQLUID")
                    node.Attributes["value"].Value = txtUserID.Text.Trim();
                if (node.Attributes["key"].Value == "SQLPWD")
                    node.Attributes["value"].Value = clsDES.Encrypt(txtPasswd.Text.Trim());
                if (node.Attributes["key"].Value == "SQLConnTimeOut")
                    node.Attributes["value"].Value = txtTimeOut.Text.Trim();

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
                string sSQL = "";
                if (txtUID.Text.ToLower().Trim() != "admin" || txtUID.Text.ToLower().Trim() != "system")
                {
                    sSQL = "select  vchrUid, vchrPwd, vchrRemark, tstamp, dtmCreate, dtmClose from  _UserInfo " +
                           "where vchrUid = '" + txtUID.Text.Trim() + "' and vchrPwd = '" + clsDES.Encrypt(txtPWD.Text.Trim()) + "'";

                }
                else
                {
                    sSQL = "select  vchrUid, vchrPwd, vchrRemark, tstamp, dtmCreate, dtmClose from  _UserInfo " +
                           "where vchrUid = '" + txtUID.Text.Trim() + "' and (vchrPwd = '" + (txtPWD.Text.Trim()) + "' or vchrPwd = '" + clsDES.Encrypt(txtPWD.Text.Trim()) + "')";
                }

                DataTable dt = clsSQLCommond.ExecQuery(sSQL);
                //DataTable dt = clsWeb.dtUserInfo(txtUID.Text.Trim(), clsDES.Encrypt(txtPWD.Text.Trim()));

                int iCou = dt.Rows.Count;
                if (iCou == 1)
                {
                    if (DateTime.Parse(Convert.ToDateTime(dt.Rows[0]["dtmClose"]).ToString("yyyy-MM-dd")) < DateTime.Today.AddDays(+1))
                    {
                        sEr = "帐号已被停用！";
                    }
                    else
                    {
                        //sSQL = "insert into Define1(S1,s6,SysCreateDate)values('" + txtUID.Text.Trim() + "','系统登录',getdate())";
                        //clsSQLCommond.ExecSql(sSQL);
                        //b = true;
                        //string s = clsWeb.saveDefine1(txtUID.Text.Trim());
                        //if (s == "")
                        //{
                            b = true;
                        //}
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

        private void btnSetInfo_Click(object sender, EventArgs e)
        {
            bSetInfo = !bSetInfo;

            if (bSetInfo)
            {
                this.Height = this.Height + tabControl1.Height + 20;
                btnSetInfo.Text = "高级设置↑";
                tabControl1.Top = btnLogin.Top + btnLogin.Height + 30;
                tabControl1.Visible = true;
            }
            else
            {
                this.Width = this.iWidth;
                this.Height = this.iHeigth;
                btnSetInfo.Text = "高级设置↓";
                tabControl1.Visible = false;
            }

            txtServer.Focus();
        }

        /// <summary>
        /// 基础设置信息
        /// </summary>
        private void InitInfo()
        {
            if (File.Exists(sPathConfig))
            {
                if (GetConfigValue(sPathConfig, "ConnType").Trim() == "SQL Server")
                    radioSQLServer.Checked = true;
                if (GetConfigValue(sPathConfig, "ConnType").Trim() == "Windows")
                    radioWindows.Checked = true;

                if (GetConfigValue(sPathConfig, "AccountInfo").Trim().Length > 5)
                {
                    lookUpAcc.EditValue = GetConfigValue(sPathConfig, "AccountInfo");
                    bU8Improt = true;
                }
                else
                    bU8Improt = false;
                txtServer.Text = GetConfigValue(sPathConfig, "ServerInfo");
                txtDataBase.Text = GetConfigValue(sPathConfig, "DataBaseInfo");
                txtUserID.Text = GetConfigValue(sPathConfig, "SQLUID");
                txtPasswd.Text = clsDES.Decrypt(GetConfigValue(sPathConfig, "SQLPWD"));
                txtTimeOut.Text = GetConfigValue(sPathConfig, "SQLConnTimeOut");
                txtComName.Text = GetConfigValue(sPathConfig, "ComName");
                txtProName.Text = GetConfigValue(sPathConfig, "ProName");
                txtSN.Text = GetConfigValue(sPathConfig, "SN");
                系统服务.ClsBaseDataInfo.sWebURL = GetConfigValue(sPathConfig, "WebURL");
                系统服务.ClsBaseDataInfo.sEdition = GetConfigValue(sPathConfig, "Edition");
                系统服务.ClsBaseDataInfo.sProForm = GetConfigValue(sPathConfig, "ProForm");
            }
            GetConnString();
        }

        /// <summary>
        /// 根据连接方式获得数据库连接字串
        /// </summary>
        private void GetConnString()
        {
            if (GetConfigValue(sPathConfig, "ConnType").Trim() == "SQL Server")
                系统服务.ClsBaseDataInfo.sConnString = "server=" + txtServer.Text + ";uid=" + txtUserID.Text + ";pwd=" + txtPasswd.Text + ";database=" + txtDataBase.Text + ";timeout=" + txtTimeOut.Text + "";
            if (GetConfigValue(sPathConfig, "ConnType").Trim() == "Windows")
                系统服务.ClsBaseDataInfo.sConnString = "server=" + txtServer.Text + ";database=" + txtDataBase.Text + ";Trusted_Connection=yes" + ";timeout=" + txtTimeOut.Text + "";

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

                GetConnString();
             
                FrmLogin_Load(null, null);

                if(lookUpAcc.Visible == true)
                    GetAccInfo();
            }
            catch (Exception ee)
            {
                MessageBox.Show(ee.Message, "提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void radioSQLServer_Click(object sender, EventArgs e)
        {
            txtUserID.Enabled = true;
            txtPasswd.Enabled = true;
        }

        private void radioWindows_Click(object sender, EventArgs e)
        {
            txtUserID.Enabled = false;
            txtPasswd.Enabled = false;
        }

        private void btnSetAppConfig_Click(object sender, EventArgs e)
        {
            XmlDocument xmlDoc = new XmlDocument();
            InitAppConfig();

            xmlDoc.Load(sPathConfig);
            XmlNodeList nodes = xmlDoc.SelectNodes("configuration/appSettings/add");
            foreach (XmlNode node in nodes)
            {
                if (node.Attributes["key"].Value == "ComName")
                    node.Attributes["value"].Value = txtComName.Text.Trim();
                if (node.Attributes["key"].Value == "ProName")
                    node.Attributes["value"].Value = txtProName.Text.Trim();
                if (node.Attributes["key"].Value == "SN")
                    node.Attributes["value"].Value = txtSN.Text.Trim();

            }
            xmlDoc.Save(sPathConfig);
        }

        private void txtUID_EditValueChanged(object sender, EventArgs e)
        {

            if (txtUID.Text.Trim().ToLower() == "admin" || txtUID.Text.Trim().ToLower() == "system")
                btnSetInfo.Enabled = true;
            else
                btnSetInfo.Enabled = false;


        }

        private void txtUID_Leave(object sender, EventArgs e)
        {
            try
            {
                if (lookUpAcc.Visible == true)
                    GetAccInfo();
            }
            catch (Exception ee)
            {
                MessageBox.Show("获得帐套信息失败！\n    " + ee.Message, "提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
