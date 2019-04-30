using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.IO;
using System.Diagnostics;
using System.Xml;
using System.Security.Cryptography;  

namespace FrameBaseFunction
{
    public partial class Frm下载文件 : Form
    {
        public Frm下载文件()
        {
            InitializeComponent();
        }

        private void btn确定_Click(object sender, EventArgs e)
        {
            try
            {
                System.Diagnostics.Process.Start(Application.StartupPath + @"\AppStart.exe");
                this.Close();
            }
            catch (Exception ee)
            {
                MessageBox.Show("更新失败:" + ee.Message);
            }
        }


        public void writePic(byte[] pics, string sPath)
        {
            FileStream fs = new FileStream(sPath, FileMode.Append, FileAccess.Write);
            BinaryWriter bw = new BinaryWriter(fs);
            bw.Write(pics, 0, pics.Length);
            bw.Close();
            fs.Close();
        }

        /// <summary>
        /// 执行查询语句，返回DataTable
        /// </summary>
        /// <param name="SQLString">查询语句</param>
        /// <returns>DataSet</returns>
        private DataTable ExecQuery(string SQLString)
        {
            using (SqlConnection connection = new SqlConnection(sConnString))
            {
                DataSet ds = new DataSet();
                try
                {
                    connection.Open();
                    SqlDataAdapter command = new SqlDataAdapter(SQLString, connection);
                    command.Fill(ds, "ds");
                }
                catch (System.Data.SqlClient.SqlException ex)
                {
                    throw new Exception(ex.Message);
                }
                return ds.Tables[0];
            }
        }

        string sConnString = "";
        /// <summary>
        /// 更新判断规则（必须两者任一满足即需要更新）：
        /// 1. 版本号不同更新
        /// 2. 服务器创建时间晚于本地文件创建时间
        /// 说明：服务器创建时间为上传更新时的服务器系统时间，下载文件后将下载的文件创建时间修改为该时间，作为下次升级的判断依据
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Frm下载文件_Load(object sender, EventArgs e)
        {
            Frm加载中 frm = new Frm加载中();
            frm.Show();

            try
            {
                #region 获得数据库连接语句

                string sPathConfig = Application.StartupPath + @"\App.dll";
                if (File.Exists(sPathConfig))
                {
                    string sServer = GetConfigValue(sPathConfig, "ServerInfo");
                    string sDataBase = GetConfigValue(sPathConfig, "DataBaseInfo");
                    string sUserID = GetConfigValue(sPathConfig, "SQLUID");
                    string sPasswd = Decrypt(GetConfigValue(sPathConfig, "SQLPWD"), "11111111");
                    string sTimeOut = GetConfigValue(sPathConfig, "SQLConnTimeOut");
                    string sComName = GetConfigValue(sPathConfig, "ComName");
                    string sProName = GetConfigValue(sPathConfig, "ProName");
                    string sSN = GetConfigValue(sPathConfig, "SN");

                    string sP = sComName + "&" + sProName;
                    string sP2 = Decrypt(sSN, "programs");
                    if (sP == sP2)
                    {
                        sConnString = "server=" + sServer + ";uid=" + sUserID + ";pwd= " + sPasswd + ";database=" + sDataBase + ";timeout=" + sTimeOut;
                    }
                }
                #endregion

                if (sConnString.Trim().Length == 0)
                {
                    throw new Exception("连接服务器失败");
                }

                bool b更新 = false;

                richTextBox1.Text = richTextBox1.Text + "检查服务器文件版本\n";
                string sAppPath = System.Windows.Forms.Application.StartupPath;
                string sSQL = "select * from 文件版本信息 order by iID";
                DataTable dt = ExecQuery(sSQL);

                progressBar1.Maximum = dt.Rows.Count;
                progressBar1.Value = 0;

                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    progressBar1.Value = i + 1;
                    string s路径 = sAppPath + dt.Rows[i]["路径"].ToString().Trim() + dt.Rows[i]["文件名称"].ToString().Trim();
                    string s目录路径 = sAppPath + dt.Rows[i]["路径"].ToString().Trim();
                    if (!Directory.Exists(s目录路径))
                        Directory.CreateDirectory(s目录路径);

                    string s版本 = dt.Rows[i]["版本"].ToString().Trim();
                    DateTime s创建时间;
                    if (dt.Rows[i]["创建时间"].ToString().Trim() != "")
                    {
                        s创建时间 = Convert.ToDateTime(dt.Rows[i]["创建时间"]);
                    }
                    else
                    {
                        s创建时间 = Convert.ToDateTime("2099-12-31");
                    }
                    label1.Text = dt.Rows[i]["文件名称"].ToString().Trim();

                    if (File.Exists(s路径))
                    {
                        string sFileVersion = FileVersionInfo.GetVersionInfo(s路径).FileVersion;
                        if (sFileVersion == null)
                            sFileVersion = "";

                        DateTime d本地文件创建时间 = File.GetCreationTime(s路径);

                        if (sFileVersion == s版本 && d本地文件创建时间 >= s创建时间)
                        {
                            continue;
                        }

                        if (File.Exists(s路径))
                        {
                            richTextBox1.Text = richTextBox1.Text + "删除历史版本文件" + dt.Rows[i]["文件名称"].ToString().Trim() + "\n";
                            File.Delete(s路径);
                        }

                    }
                    else
                    {
                        richTextBox1.Text = richTextBox1.Text + "文件不存在，需要新增" + dt.Rows[i]["文件名称"].ToString().Trim() + "\n";
                    }


                    richTextBox1.Text = richTextBox1.Text + "下载文件" + dt.Rows[i]["文件名称"].ToString().Trim() + "\n";
                    Byte[] b = (byte[])dt.Rows[i]["文件"];
                    writePic(b, s路径);

                    File.SetCreationTime(s路径, s创建时间);
                    b更新 = true;
                }

                if (!b更新)
                {
                    System.Diagnostics.Process.Start(Application.StartupPath + @"\AppStart.exe");
                    this.Close();
                }
                else
                {
                    label1.Text = "更新成功，请点击确认进入";
                }
            }
            catch (Exception ee)
            {
                MessageBox.Show("更新失败，请联系管理员:" + ee.Message);
                this.Close();
            }
            finally
            {
                frm.Close();
            }
        }

        /// <summary>
        /// Read confing
        /// </summary>
        /// <param name="path"></param>
        /// <param name="appKey"></param>
        /// <returns></returns>
        private string GetConfigValue(string path, string appKey)
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

        /// <summary>
        /// 解密
        /// </summary>
        /// <param name="pToDecrypt">要解密字符</param>
        /// <param name="sKey">密钥</param>
        /// <returns></returns>
        public string Decrypt(string pToDecrypt, string sKey)
        {
            try
            {
                DESCryptoServiceProvider des = new DESCryptoServiceProvider();

                //Put  the  input  string  into  the  byte  array  
                byte[] inputByteArray = new byte[pToDecrypt.Length / 2];
                for (int x = 0; x < pToDecrypt.Length / 2; x++)
                {
                    int i = (Convert.ToInt32(pToDecrypt.Substring(x * 2, 2), 16));
                    inputByteArray[x] = (byte)i;
                }

                //建立加密对象的密钥和偏移量，此值重要，不能修改  
                des.Key = ASCIIEncoding.ASCII.GetBytes(sKey);
                des.IV = ASCIIEncoding.ASCII.GetBytes(sKey);
                MemoryStream ms = new MemoryStream();
                CryptoStream cs = new CryptoStream(ms, des.CreateDecryptor(), CryptoStreamMode.Write);
                //Flush  the  data  through  the  crypto  stream  into  the  memory  stream  
                cs.Write(inputByteArray, 0, inputByteArray.Length);
                cs.FlushFinalBlock();

                //Get  the  decrypted  data  back  from  the  memory  stream  
                //建立StringBuild对象，CreateDecrypt使用的是流对象，必须把解密后的文本变成流对象  
                StringBuilder ret = new StringBuilder();

                return System.Text.Encoding.Default.GetString(ms.ToArray());

            }

            catch (Exception ee)
            {
                throw new Exception(ee.Message);
            }
        }
    }
}
