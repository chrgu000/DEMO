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

namespace FrameBaseFunction
{
    public partial class FrmLogin : Form
    {
        FrameBaseFunction.ClsXMLCommond clsXML = new FrameBaseFunction.ClsXMLCommond();
        FrameBaseFunction.ClsDataBase clsSQLCommond;
        FrameBaseFunction.ClsDES clsDES;
        private bool bSetInfo = false;                      //初始状态，未点击设置
        private string sPathConfig = Application.StartupPath + @"\App.dll";
      
        int iWidth = 0;
        int iHeigth = 0;
        bool bU8Improt = true;

        public FrmLogin()
        {
            FrameBaseFunction.ClsBaseDataInfo.sDataBaseType = GetConfigValue(sPathConfig, "DataBaseType");
            InitializeComponent();

            try
            {
                clsSQLCommond = FrameBaseFunction.ClsDataBaseFactory.Instance();
                clsDES = FrameBaseFunction.ClsDES.Instance();

                InitInfo();

                label1.Visible = bU8Improt;
                lookUpAcc.Visible = bU8Improt;
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

                if (txtUID.Text.Trim() != string.Empty)
                    txtPWD.Focus();
                else
                    txtUID.Focus();
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
                }
                
                try
                {
                    FrameBaseFunction.ClsBaseDataInfo.sUid = txtUID.Text.Trim();
                    FrameBaseFunction.ClsBaseDataInfo.sLogDate = dtmLogin.Text.Trim();


                    if (bU8Improt)
                    {
                        FrameBaseFunction.ClsBaseDataInfo.sUFDataBaseName = "UFDATA_" + lookUpAcc.EditValue.ToString().Trim() + "_" + dtmLogin.DateTime.ToString("yyyy").Trim();
                        FrameBaseFunction.ClsBaseDataInfo.sUFDataBaseText = lookUpAcc.Text.Trim();
                        FrameBaseFunction.ClsBaseDataInfo.sConnString2 = FrameBaseFunction.ClsBaseDataInfo.sConnString.Replace(FrameBaseFunction.ClsBaseDataInfo.sDataBaseName, FrameBaseFunction.ClsBaseDataInfo.sUFDataBaseName);
                    }
                    string sSQL = "select vchrName from dbo._UserInfo where vchrUid = '" + txtUID.Text.Trim() + "' ";
                    FrameBaseFunction.ClsBaseDataInfo.sUserName = clsSQLCommond.ExecGetScalar(sSQL).ToString().Trim();

                    if (bU8Improt)
                    {
                        sSQL = "select count(*) from Master.dbo.sysdatabases where name='" + FrameBaseFunction.ClsBaseDataInfo.sUFDataBaseName + "'";
                        int iCou = Convert.ToInt32(clsSQLCommond.ExecGetScalar(sSQL));
                        if (iCou == 0)
                        {
                            MessageBox.Show("年度帐不存在，日期请选择" + dtmLogin.DateTime.AddYears(-1).ToString("yyyy").Trim() + "-12-31");
                            return;
                        }
                    }

                    sSQL = "select iID from _LookUpDate where iType = 3";
                    FrameBaseFunction.ClsBaseDataInfo.sERPEdition = clsSQLCommond.ExecGetScalar(sSQL).ToString().ToLower().Trim();
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

        private bool Login(out string sEr)
        {
            sEr = "";
            bool b = false;
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

            int iCou = dt.Rows.Count;
            if (iCou == 1)
            {
                if (DateTime.Parse(Convert.ToDateTime(dt.Rows[0]["dtmClose"]).ToString("yyyy-MM-dd")) < DateTime.Today.AddDays(+1))
                {
                    sEr = "帐号已被停用！";
                }
                else
                {
                    
                    b = true;
                }
            }
            else
            {
                sEr = "帐号或者密码错误！";
            }

            return b;
        }
       

        private void btnExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        /// <summary>
        /// 基础设置信息
        /// </summary>
        private void InitInfo()
        {
            if (File.Exists(sPathConfig))
            {
                if (GetConfigValue(sPathConfig, "AccountInfo").Trim().Length > 5)
                {
                    lookUpAcc.EditValue = GetConfigValue(sPathConfig, "AccountInfo");
                    bU8Improt = true;
                }
                else
                    bU8Improt = false;

                txt服务器.Text = GetConfigValue(sPathConfig, "ServerInfo");
                txtUID.Text = GetConfigValue(sPathConfig, "UserInfo");
                FrameBaseFunction.ClsBaseDataInfo.sEdition = GetConfigValue(sPathConfig, "Edition");
                FrameBaseFunction.ClsBaseDataInfo.sProForm = GetConfigValue(sPathConfig, "ProForm");
                FrameBaseFunction.ClsBaseDataInfo.sDataBaseName = GetConfigValue(sPathConfig, "DataBaseInfo");

                lookUpAcc.EditValue = GetConfigValue(sPathConfig, "AccountInfo");


                FrameBaseFunction.ClsBaseDataInfo.sConnString = "server=" + txt服务器.Text.Trim() + ";database=" + GetConfigValue(sPathConfig, "DataBaseInfo") + ";uid=" + GetConfigValue(sPathConfig, "SQLUID") + ";pwd=" + clsDES.Decrypt(GetConfigValue(sPathConfig, "SQLPWD"));
            }
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

        private void button1_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
        }

        private void txt服务器_EditValueChanged(object sender, EventArgs e)
        {
            try
            {
                FrameBaseFunction.ClsBaseDataInfo.sConnString = "server=" + txt服务器.Text.Trim() + ";database=" + GetConfigValue(sPathConfig, "DataBaseInfo") + ";uid=" + GetConfigValue(sPathConfig, "SQLUID") + ";pwd=" + clsDES.Decrypt(GetConfigValue(sPathConfig, "SQLPWD"));
            }
            catch { }
        }
    }
}
