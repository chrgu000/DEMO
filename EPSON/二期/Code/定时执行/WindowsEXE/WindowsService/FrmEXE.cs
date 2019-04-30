using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Xml;
using System.IO;

namespace AutoExe
{
    public partial class FrmEXE : Form
    {
        public FrmEXE(string sPath)
        {
            InitializeComponent();

            ExportData(sPath);
        }

        /// <summary>
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

        public void ExportData(string sPathConfig)
        {
            string Conn = "";

            sPathConfig = sPathConfig + @"\app.dll";
            if (File.Exists(sPathConfig))
            {
                Conn = "server=" + GetConfigValue(sPathConfig, "ServerInfo") + ";uid=" + GetConfigValue(sPathConfig, "SQLUID") + ";pwd=" + GetConfigValue(sPathConfig, "SQLPWD") + ";database=" + GetConfigValue(sPathConfig, "DataBaseInfo") + ";timeout=200";
            }

            //SqlConnection conn = new SqlConnection(Conn);
            //conn.Open();
            //启用事务
            //SqlTransaction tran = conn.BeginTransaction();
            try
            {
                DbHelperSQL.connectionString = Conn;

                string sSQL = "select *,getdate() as dNowTime from _ExportList";
                DataTable dt = DbHelperSQL.Query(sSQL);

                if (dt == null || dt.Rows.Count == 0)
                    return;

                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    string sType = dt.Rows[i]["Type"].ToString().Trim();
                    DateTime dStartTime = BaseFunction.ReturnDate(dt.Rows[i]["StartTime"]);
                    DateTime dEndTime = BaseFunction.ReturnDate(dt.Rows[i]["EndTime"]);
                    DateTime dNowTime = BaseFunction.ReturnDate(dt.Rows[i]["dNowTime"]);
                    DateTime dDoTime = BaseFunction.ReturnDate(dNowTime.ToString("yyyy-MM-dd") + " " + BaseFunction.ReturnDate(dt.Rows[i]["DoTime"]).ToString("HH:mm:ss"));
                    string sPath = dt.Rows[i]["FilePath"].ToString().Trim();

                    if (dEndTime > dDoTime || dDoTime > dNowTime)
                        continue;

                    DateTime dStart = BaseFunction.ReturnDate(dNowTime.ToString("yyyy-MM-01"));
                    DateTime dEnd = BaseFunction.ReturnDate(dNowTime.AddMonths(1).ToString("yyyy-MM-01")).AddDays(-1);

                    //导出销售发票
                    try
                    {
                        FrmSalevoiceExportTxt cls1 = new FrmSalevoiceExportTxt();
                        cls1.ExportData(dStart, dEnd, sPath, Conn);
                        sSQL = "update [dbo].[_ExportList] set StartTime = '" + dNowTime.ToString("yyyy-MM-dd HH:mm:ss") + "', EndTime = getdate() where Type = '" + sType + "' ";
                        DbHelperSQL.ExecuteSql(sSQL);
                    }
                    catch { }

                    //导出采购发票
                    try
                    {
                        FrmPUvoiceExportTxt cls1 = new FrmPUvoiceExportTxt();
                        cls1.ExportData(dStart, dEnd, sPath, Conn);
                        sSQL = "update [dbo].[_ExportList] set StartTime = '" + dNowTime.ToString("yyyy-MM-dd HH:mm:ss") + "', EndTime = getdate() where Type = '" + sType + "' ";
                        DbHelperSQL.ExecuteSql(sSQL);
                    }
                    catch { }
                }
            }
            catch (Exception ee)
            {

            }
            finally
            {
                System.Environment.Exit(0);
            }
        }
    }
}
