using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.IO;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Xml;
using System.Security.Cryptography;

namespace 自动更新
{
    public partial class Frm上传文件 : Form
    {
        string sConnString ;
        //= "server=.;uid=sa;pwd=Rqsw@password;database=SysDB_RQSW_2013;timeout=200";
        public Frm上传文件()
        {
            InitializeComponent();
        }

        private void Frm上传文件_Load(object sender, EventArgs e)
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

            if (sConnString.Trim() == "")
            {
                MessageBox.Show("连接配置错误");
            }
        }

        private void btn上传_Click(object sender, EventArgs e)
        {
            try
            {
                string sErr = "";
                string sInfo = "";
                string sAppPath = System.Windows.Forms.Application.StartupPath;

                OpenFileDialog oFile = new OpenFileDialog();
                oFile.Multiselect = true;
                oFile.ShowDialog();
                string[] sFiles = oFile.FileNames;

                progressBar1.Maximum = sFiles.Length;
                progressBar1.Value = 0;
                using (SqlConnection conn = new SqlConnection(sConnString))
                {
                    conn.Open();
                    SqlCommand cmd = new SqlCommand();
                    cmd.CommandTimeout = 3600;
                    cmd.Connection = conn;
                    SqlTransaction tx = conn.BeginTransaction();
                    cmd.Transaction = tx;

                    try
                    {
                        for (int i = 0; i < sFiles.Length; i++)
                        {
                            progressBar1.Value = i + 1;
                     

                            string sNamePathAll = sFiles[i].Trim();
                            string sNamePath = sNamePathAll.Replace(sAppPath, "");
                            string[] sName = sNamePath.Split('\\');
                            string sFileName = sName[sName.Length - 1];
                            string sFilePath = sNamePath.Replace(sFileName, "");
                            label1.Text = sFileName;
                            string sSQL = "select * from dbo.文件版本信息 where 文件名称 = '" + sFileName + "' ";
                            DataTable dt版本 = ExecQuery(sSQL);

                            string sFileVersion = FileVersionInfo.GetVersionInfo(sFiles[i].Trim()).FileVersion;

                            FileInfo fi = new FileInfo(sFiles[i].Trim());
                            FileStream fs = fi.OpenRead();
                            byte[] bytes = new byte[fs.Length];
                            fs.Read(bytes, 0, Convert.ToInt32(fs.Length));

                            sSQL = "if exists(select * from dbo.文件版本信息 where 文件名称 = '" + sFileName + "') " +
                                  "	update 文件版本信息 set 路径 = '" + sFilePath + "',版本 = '" + sFileVersion + "',文件 = @file" + i.ToString() + " ,更新日期 = GETDATE(),创建时间 = getdate() where 文件名称 = '" + sFileName + "' " +
                                  "else " +
                                  "	insert into 文件版本信息(文件名称,路径,版本,文件,更新日期,创建时间)values " +
                                  "	('" + sFileName + "','" + sFilePath + "','" + sFileVersion + "',@file" + i.ToString() + ",getdate(),getdate())";

                            cmd.CommandType = CommandType.Text;
                            cmd.CommandText = sSQL;
                            SqlParameter spFile = new SqlParameter("@file" + i.ToString(), SqlDbType.Image);
                            spFile.Value = bytes;
                            cmd.Parameters.Add(spFile);
                            cmd.ExecuteNonQuery();

                            sInfo = sInfo + sFileName + "\n";
                        }

                        tx.Commit();

                        if (sInfo.Trim().Length > 0)
                        {
                            if (sErr.Trim().Length > 0)
                            {
                                sErr = sErr + "\n\n";
                            }

                            sInfo = sErr + "以下文件上传成功:\n" + sInfo;
                        }
                        richTextBox1.Text = sInfo;

                        if (sErr.Trim().Length > 0)
                        {
                            sErr = sErr + "\n\n";
                            MessageBox.Show("上次文件存在错误");
                        }
                        else
                        {
                            MessageBox.Show("上次文件成功");
                        }
                        
                    }
                    catch (System.Data.SqlClient.SqlException E)
                    {
                        tx.Rollback();
                        throw new Exception(E.Message);
                    }
                }
            }
            catch (Exception ee)
            {
                MessageBox.Show("上次失败:" + ee.Message);
            }
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
