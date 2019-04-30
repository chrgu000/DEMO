using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TH.BaseClass;
using System.Data;
using System.Data.SqlClient;
using System.Xml;
using System.IO;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace TH.WindowsService
{
    public class Clshr_tm_OriCardData
    {

        private string sPathConfig = "";
        private string sPathTxt = "";
        private string sPath = "";
        private string sSQL = "";

        public Clshr_tm_OriCardData(string sPConfig, string sPTxt, string sP)
        {
            sPathConfig = sPConfig;
            sPathTxt = sPTxt;
            sPath = sP;
        }

        //[DllImport("W_Kqrec.DLL", CharSet = CharSet.Ansi, EntryPoint = "_LANDOWNLOADS")]
        //public extern static int _LANDOWNLOADS(string sIP);

        //public void RunCardData(out DateTime dNowOut,bool b直连考勤机)
        //{
        //string sErr = "";
        //dNowOut = Convert.ToDateTime("1900-01-01");
        //try
        //{
        //    string sConn = TH.BaseClass.ClsBaseDataInfo.sConnString;
        //    SqlConnection sqlConn = new SqlConnection(sConn);
        //    sqlConn.Open();
        //    //启用事务
        //    SqlTransaction tran = sqlConn.BeginTransaction();

        //    try
        //    {
        //        //同步考勤数据
        //        sSQL = "select * from _IP";
        //        DataTable dtip = DbHelperSQL.ExecuteDataset(tran, CommandType.Text, sSQL).Tables[0];
        //        int iCount = 0;
        //        for (int s = 0; s < dtip.Rows.Count; s++)
        //        {
        //            if (b直连考勤机)
        //            {
        //                int str = 0;
        //                str = _LANDOWNLOADS(dtip.Rows[s]["IP"].ToString().Trim());

        //                if (str != 0)
        //                {
        //                    throw new Exception("读取考勤机失败");
        //                }
        //            }
        //            if (!File.Exists("KQREC.txt"))
        //                continue;

        //            string[] list = File.ReadAllLines("KQREC.txt");
        //            File.Delete("KQREC.txt");

        //            if (list.Length == 0)
        //                continue;

        //            sSQL = "select cPsn_Num,cPsn_Name,vCardNo,JobNumber ,cDept_num ,chdefine1 from hr_hi_person ";
        //            DataTable dtper = DbHelperSQL.ExecuteDataset(tran, CommandType.Text, sSQL).Tables[0];

        //            sSQL = "select isnull(max(ID),0)+1 from _KQLIST";
        //            DataTable dtmax = DbHelperSQL.ExecuteDataset(tran, CommandType.Text, sSQL).Tables[0];
        //            long iID = long.Parse(dtmax.Rows[0][0].ToString());


        //            DateTime dNow = DateTime.Now;
        //            for (int i = 0; i < list.Length; i++)
        //            {
        //                string kq = list[i];
        //                string kqrq = kq.Substring(15, 4) + "-" + kq.Substring(19, 2) + "-" + kq.Substring(21, 2);
        //                string kqsj = kq.Substring(10, 5);
        //                string vCardNo = kq.Substring(2, 8).Trim();
        //                DateTime sdt;
        //                if (!DateTime.TryParse(kqrq, out sdt))
        //                    continue;
        //                if (sdt <= DateTime.Parse("2015-08-31"))
        //                    continue;

        //                DataRow[] dwper = dtper.Select("vCardNo='" + vCardNo + "'");
        //                string cPsn_Num = "";
        //                string JobNumber = "";
        //                string cPsn_Name = "";
        //                string cDept_num = "";
        //                string chdefine1 = "";
        //                if (dwper.Length > 0)
        //                {
        //                    cPsn_Num = dwper[0]["cPsn_Num"].ToString();
        //                    JobNumber = dwper[0]["JobNumber"].ToString();
        //                    cPsn_Name = dwper[0]["cPsn_Name"].ToString();
        //                    cDept_num = dwper[0]["cDept_num"].ToString();
        //                    chdefine1 = dwper[0]["chdefine1"].ToString();
        //                    cPsn_Num = dwper[0]["cPsn_Num"].ToString();
        //                }

        //                sSQL = "select * from _KQLIST with (nolock) where Card='" + vCardNo + "' and  convert(nvarchar(10),dDate,120)='" + kqrq + "' and dTime='" + kqsj + "'";
        //                DataTable dtc = DbHelperSQL.ExecuteDataset(tran, CommandType.Text, sSQL).Tables[0];
        //                if (dtc.Rows.Count == 0)
        //                {
        //                    sSQL = "insert into _KQLIST(dDate,dTime,Card,cPsn_Num,cPsn_Name,JobNumber,cDept_num,chdefine1) values('" + kqrq + "','" + kqsj + "','" + vCardNo + "'"
        //                           + ",'" + cPsn_Num + "','" + cPsn_Name + "','" + JobNumber + "','" + cPsn_Num + "','" + chdefine1 + "')";
        //                    DbHelperSQL.ExecuteNonQuery(tran, CommandType.Text, sSQL);
        //                    //刷卡数据
        //                    sSQL = "select * from hr_tm_OriCardData where vCardNo='" + vCardNo + "' and dDateTime='" + TH.BaseClass.BaseFunction.ReturnDate(kqrq + " " + kqsj) + "'";//只导入范围内
        //                    DataTable dtkq = DbHelperSQL.ExecuteDataset(tran, CommandType.Text, sSQL).Tables[0];
        //                    if (dtkq.Rows.Count == 0)
        //                    {
        //                        Model.hr_tm_OriCardData model = new Model.hr_tm_OriCardData();
        //                        model.uRecordId = Guid.NewGuid();
        //                        model.cPsn_Num = cPsn_Num;
        //                        model.vCardNo = vCardNo;
        //                        model.dDateTime = TH.BaseClass.BaseFunction.ReturnDate(kqrq + " " + kqsj);
        //                        model.bManual = false;
        //                        model.iFlag = 0;

        //                        model.bEffect = 1;
        //                        model.bAuditFlag = false;

        //                        model.JobNumber = JobNumber;
        //                        model.cSource = "0";
        //                        model.vReason = "系统自动导入";

        //                        //model.dAuditTime = dNow.ToString();
        //                        model.dSysTime = dNow;
        //                        model.cOptPsn_Num = "demo";
        //                        //model.cAuditorNum = "demo";

        //                        DAL.hr_tm_OriCardData dal = new DAL.hr_tm_OriCardData();
        //                        sSQL = dal.Add(model);
        //                        DbHelperSQL.ExecuteNonQuery(tran, CommandType.Text, sSQL);
        //                        iCount = iCount + 1;
        //                    }
        //                }
        //            }
        //        }
        //        if (sErr != "")
        //        {
        //            using (System.IO.StreamWriter sw = new System.IO.StreamWriter(sPath + @"\log.txt", true))
        //            {
        //                sw.WriteLine(DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss ") + sErr);
        //            }
        //        }
        //        else
        //        {
        //            using (System.IO.StreamWriter sw = new System.IO.StreamWriter(sPath + @"\log.txt", true))
        //            {
        //                sw.WriteLine(DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss ") + "导入考勤记录" + iCount + "条");
        //            }
        //        }


        //        tran.Commit();

        //        dNowOut = DateTime.Now;
        //    }
        //    catch (Exception error)
        //    {
        //        tran.Rollback();
        //        throw new Exception(error.Message);
        //    }
        //}
        //catch (Exception ee)
        //{
        //    using (System.IO.StreamWriter sw = new System.IO.StreamWriter(sPath + @"\log.txt", true))
        //    {
        //        sw.WriteLine(DateTime.Now.ToString("sErr" + "yyyy-MM-dd HH:mm:ss ") + ee);
        //    }
        //}
        //}




        public void StreamWriter(string o)
        {
            if (System.IO.File.Exists(sPathTxt) == false)
            {
                System.IO.File.Create(sPathTxt);
            }
            using (System.IO.StreamWriter sw = new System.IO.StreamWriter(sPathTxt, true))
            {
                sw.WriteLine(DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss ") + o + sPathConfig);
            }
        }

        /// <summary>
        /// 连接苏特考勤机数据库，同步数据
        /// </summary>
        public void RunCardDataSQL(out DateTime dNowOut, int iDays)
        {
            string sErr = "";
            DateTime dNow = DateTime.Now;

            string sConn = TH.BaseClass.ClsBaseDataInfo.sConnString;

            string s导入日期 = DateTime.Now.ToString("yyyyMMddhhmmss");
            dNowOut = Convert.ToDateTime("1900-01-01");
            try
            {
                string sSQL = @"
select ID_KEY,Brush_Date,Brush_Time as Brush_Data,Card_No 
from KQ_Download 
where brush_date > (GETDATE() - 111111111111111111) 
";
                sSQL = sSQL.Replace("111111111111111111", (iDays + 1).ToString());
                DataTable dt = DbHelperSQL.Query(sSQL, "server=10.131.64.252;uid=saa ;pwd=;database=STCard");

                int iCou = 0;

                SqlConnection conn = new SqlConnection(sConn);
                conn.Open();
                //启用事务
                SqlTransaction tran = conn.BeginTransaction();
                try
                {
                    for (int i = 0; i < dt.Rows.Count; i++)
                    {
                        sSQL = @"
select * 
from [_考勤机原始数据] a inner join hr_hi_person b on a.Card_No = b.vCardNo 
where ID_KEY = 111111111111111111
";
                        sSQL = sSQL.Replace("111111111111111111", dt.Rows[i]["ID_KEY"].ToString().Trim());
                        DataTable dtCou = DbHelperSQL.ExecuteDataset(tran, CommandType.Text, sSQL).Tables[0];

                        if (dtCou == null || dtCou.Rows.Count == 0)
                        {
                            sSQL = "select * from hr_hi_person where vCardNo = '222222222222222222'";
                            sSQL = sSQL.Replace("222222222222222222", dt.Rows[i]["Card_No"].ToString().Trim());
                            DataTable dt卡号 = DbHelperSQL.ExecuteDataset(tran, CommandType.Text, sSQL).Tables[0];
                            if (dt卡号 == null || dt卡号.Rows.Count == 0)
                                continue;

                            sSQL = @"
    insert into  [_考勤机原始数据](ID_KEY, Card_No, Brush_Date, Brush_Data,导入日期)
    values(111111111111111111,N'222222222222222222',N'333333333333333333',N'444444444444444444','555555555555555555')
";
                            sSQL = sSQL.Replace("111111111111111111", dt.Rows[i]["ID_KEY"].ToString().Trim());
                            sSQL = sSQL.Replace("222222222222222222", dt.Rows[i]["Card_No"].ToString().Trim());
                            sSQL = sSQL.Replace("333333333333333333", dt.Rows[i]["Brush_Date"].ToString().Trim());
                            sSQL = sSQL.Replace("444444444444444444", dt.Rows[i]["Brush_Data"].ToString().Trim());
                            sSQL = sSQL.Replace("555555555555555555", s导入日期.Trim());

                            DbHelperSQL.ExecuteNonQuery(tran, CommandType.Text, sSQL);

                            string s打卡 = dt.Rows[i]["Brush_Data"].ToString().Trim();
                            string s卡号 = dt卡号.Rows[0]["vCardNo"].ToString().Trim();

                            Model.hr_tm_OriCardData model = new Model.hr_tm_OriCardData();
                            model.uRecordId = Guid.NewGuid();
                            model.cPsn_Num = dt卡号.Rows[0]["cPsn_Num"].ToString().Trim();
                            model.vCardNo = dt卡号.Rows[0]["vCardNo"].ToString().Trim();
                            model.dDateTime = TH.BaseClass.BaseFunction.ReturnDate(dt.Rows[i]["Brush_Date"].ToString().Trim() + " " + dt.Rows[i]["Brush_Data"].ToString().Trim());
                            model.bManual = false;
                            model.iFlag = 0;
                            model.dSysTime = dNow;
                            model.bEffect = 1;
                            model.bAuditFlag = false;
                            model.JobNumber = dt卡号.Rows[0]["JobNumber"].ToString().Trim();
                            model.cSource = "0";

                            DAL.hr_tm_OriCardData dal = new DAL.hr_tm_OriCardData();

                            sSQL = dal.Add(model);
                            iCou = iCou + DbHelperSQL.ExecuteNonQuery(tran, CommandType.Text, sSQL);
                        }
                    }

                    if(iCou > 0)
                        tran.Commit();
                    else
                        tran.Rollback();

                    dNowOut = dNow;

                    if (sErr != "")
                        throw new Exception(sErr);
                }
                catch (Exception error)
                {
                    tran.Rollback();
                }
            }
            catch (Exception ee)
            {
                using (System.IO.StreamWriter sw = new System.IO.StreamWriter(sPath + @"\log.txt", true))
                {
                    sw.WriteLine(DateTime.Now.ToString("sErr" + "yyyy-MM-dd HH:mm:ss ") + ee);
                }
            }
        }
    }
}
