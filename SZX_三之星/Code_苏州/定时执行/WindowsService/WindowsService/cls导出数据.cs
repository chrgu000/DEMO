using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Xml;


namespace U8Export
{
    public class cls导出数据
    {
        public void ExportData(string sPathConfig)
        {
            string Conn = "";
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

                    switch (sType)
                    {
                        case "10-1":
                            Frm受注数据 cls101 = new Frm受注数据();
                            cls101.ExportData(dStart, dEnd, sPath, Conn);
                            sSQL = "update [dbo].[_ExportList] set StartTime = '" + dNowTime.ToString("yyyy-MM-dd HH:mm:ss") + "', EndTime = getdate() where Type = '" + sType + "' ";
                            DbHelperSQL.ExecuteSql(sSQL);
                            break;
                        case "10-2":
                            Frm销售实绩数据 cls102 = new Frm销售实绩数据();
                            cls102.ExportData(dStart.AddMonths(-1), dEnd, sPath, Conn);
                            sSQL = "update [dbo].[_ExportList] set StartTime = '" + dNowTime.ToString("yyyy-MM-dd HH:mm:ss") + "', EndTime = getdate() where Type = '" + sType + "' ";
                            DbHelperSQL.ExecuteSql(sSQL);
                            break;
                        case "10-3":
                            Frm在库数据 frm103 = new Frm在库数据();
                            frm103.ExportData(dStart, dEnd, sPath, Conn);
                            sSQL = "update [dbo].[_ExportList] set StartTime = '" + dNowTime.ToString("yyyy-MM-dd HH:mm:ss") + "', EndTime = getdate() where Type = '" + sType + "' ";
                            DbHelperSQL.ExecuteSql(sSQL);
                            break;
                        case "10-4":
                            Frm月末在库数据 frm104 = new Frm月末在库数据();
                            frm104.ExportData(dStart, dEnd, sPath, Conn);
                            sSQL = "update [dbo].[_ExportList] set StartTime = '" + dNowTime.ToString("yyyy-MM-dd HH:mm:ss") + "', EndTime = getdate() where Type = '" + sType + "' ";
                            DbHelperSQL.ExecuteSql(sSQL);
                            break;
                        case "10-5":
                            Frm生产入库数据每月明细 frm105 = new Frm生产入库数据每月明细();
                            sSQL = "update [dbo].[_ExportList] set StartTime = '" + dNowTime.ToString("yyyy-MM-dd HH:mm:ss") + "', EndTime = getdate() where Type = '" + sType + "' ";
                            DbHelperSQL.ExecuteSql(sSQL);
                            frm105.ExportData(dStart, dEnd, sPath, Conn);
                            break;
                        case "10-6":
                            Frm客户数据 frm106 = new Frm客户数据();
                            frm106.ExportData(dStart, dEnd, sPath, Conn);
                            sSQL = "update [dbo].[_ExportList] set StartTime = '" + dNowTime.ToString("yyyy-MM-dd HH:mm:ss") + "', EndTime = getdate() where Type = '" + sType + "' ";
                            DbHelperSQL.ExecuteSql(sSQL);
                            break;
                        case "10-7":
                            Frm条件数据 frm107 = new Frm条件数据();
                            frm107.ExportData(dStart, dEnd, sPath, Conn);
                            sSQL = "update [dbo].[_ExportList] set StartTime = '" + dNowTime.ToString("yyyy-MM-dd HH:mm:ss") + "', EndTime = getdate() where Type = '" + sType + "' ";
                            DbHelperSQL.ExecuteSql(sSQL);
                            break;
                        case "10-8":
                            Frm处理日期数据 frm108 = new Frm处理日期数据();
                            frm108.ExportData(dStart, dEnd, sPath, Conn);
                            sSQL = "update [dbo].[_ExportList] set StartTime = '" + dNowTime.ToString("yyyy-MM-dd HH:mm:ss") + "', EndTime = getdate() where Type = '" + sType + "' ";
                            DbHelperSQL.ExecuteSql(sSQL);
                            break;
                    }
                }
            }
            catch (Exception ee)
            {

            }
            finally
            {
            
            }
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
    }
}
