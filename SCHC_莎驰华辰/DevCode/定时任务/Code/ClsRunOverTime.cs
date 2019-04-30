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
namespace TH.WindowsService
{
    public class ClsRunOverTime
    {

        private string sPathConfig = "";
        private string sPathTxt = "";
        private string sPath = "";
        private string sSQL = "";

        public ClsRunOverTime(string sPConfig, string sPTxt, string sP)
        {
            sPathConfig = sPConfig;
            sPathTxt = sPTxt;
            sPath = sP;
        }
        
        public void RunOverTime(out DateTime dNowOut)
        {
            string sErr = "";

            dNowOut = Convert.ToDateTime("2000-01-01");
            try
            {
                string sConn = TH.BaseClass.ClsBaseDataInfo.sConnString;
                SqlConnection sqlConn = new SqlConnection(sConn);
                sqlConn.Open();
                //启用事务
                SqlTransaction tran = sqlConn.BeginTransaction();

                try
                {
                    string sSQL = "select getdate()";
                    DateTime d当前服务器时间 = Convert.ToDateTime(DbHelperSQL.ExecuteDataset(tran, CommandType.Text, sSQL).Tables[0].Rows[0][0]);

                    // 获得单据号
                    int iRdCode = 0;
                    sSQL = "select * From VoucherHistory  with (ROWLOCK) Where CardNumber='TM03' and cSeed = '" + d当前服务器时间.ToString("yyyyMMdd") + "'";
                    DataTable dtTemp = DbHelperSQL.ExecuteDataset(tran, CommandType.Text, sSQL).Tables[0];
                    if (dtTemp == null || dtTemp.Rows.Count < 1)
                    {
                        iRdCode = 0;
                    }
                    else
                    {
                        iRdCode = int.Parse(dtTemp.Rows[0]["cNumber"].ToString());
                    }
                    string nowdate = DateTime.Now.ToString();
                    sSQL = "select isnull(max(iRecordId)+1,1) from HR_TM_OverTimeVoucher ";
                    dtTemp = DbHelperSQL.ExecuteDataset(tran, CommandType.Text, sSQL).Tables[0];
                    int iRecordId = TH.BaseClass.BaseFunction.Returnint(dtTemp.Rows[0][0]);

                    //sSQL = "select * from _KQLIST where isnull(isOk,'')='' and convert(nvarchar(10),ddate,120)<'" + DateTime.Now.ToString("yyyy-MM-dd") + "'";
                    sSQL = @"
select distinct a.* 
from [dbo].[_Get刷卡签卡数据] a
	left join hr_tm_OverTimeresult b on a.cPsn_Num = b.cPsn_Num
	left join hr_hi_person c on a.cPsn_Num = c.cPsn_Num
	left join hr_tm_OverTimeresult d on a.cPsn_Num = d.cPsn_Num
where 1=1 
	and a.dDateTime >= '111111111111111111'
	and isnull(c.chdefine1,'') = '是'
	and  CONVERT(VARCHAR(10),a.dDateTime,120) <> isnull(d.dJbDate,'2000-01-01')
order by cPsn_Num,dDateTime
";
                    string d执行日期 = d当前服务器时间.AddMonths(-1).ToString("yyyy-MM-01");
                    sSQL = sSQL.Replace("111111111111111111", d执行日期);
                    DataTable dt = DbHelperSQL.ExecuteDataset(tran, CommandType.Text, sSQL).Tables[0];

                    for (int i = 0; i < dt.Rows.Count; i++)
                    {
                        string dDate = DateTime.Parse(dt.Rows[i]["dDateTime"].ToString()).ToString("yyyy-MM-dd");

                        string vJbCode = GetType(dDate);
                        // 非节假或休息日加班跳过
                        if (vJbCode == "")
                            continue;

                        //string Card = dt.Rows[i]["Card"].ToString();
                        string cPsn_Num = dt.Rows[i]["cPsn_Num"].ToString();
                        string JobNumber = dt.Rows[i]["JobNumber"].ToString();


                        iRdCode += 1;
                        sSQL = "select * from hr_tm_OverTimeresult where cPsn_Num='" + cPsn_Num + "' and dJbDate='" + dDate + "'";
                        DataTable dta = DbHelperSQL.ExecuteDataset(tran, CommandType.Text, sSQL).Tables[0];
                        //已有加班单，不自动生成
                        if (dta != null && dta.Rows.Count > 0)
                        {
                            continue;
                        }

                        string s单据号 = sGetCode(iRdCode, 5, "JB" + d当前服务器时间.ToString("yyMMdd"));

                        //签卡数据 有签卡数据
                        sSQL = @"
select a.*,b.cDept_num 
from [_Get刷卡签卡数据] a
    left join hr_hi_person b on a.cPsn_Num = b.cPsn_Num
where a.cPsn_Num = '111111111111111111' and CONVERT(VARCHAR(10),a.dDateTime,120) = '222222222222222222'
order by dDateTime
                        ";
                        sSQL = sSQL.Replace("111111111111111111", cPsn_Num);
                        sSQL = sSQL.Replace("222222222222222222", dDate);
                        DataTable dts = DbHelperSQL.ExecuteDataset(tran, CommandType.Text, sSQL).Tables[0];
                        if (dts.Rows.Count > 1)
                        {
                            string sdtime = TH.BaseClass.BaseFunction.ReturnDate(dts.Rows[0]["dDateTime"]).ToString("HH:mm");
                            string edtime = TH.BaseClass.BaseFunction.ReturnDate(dts.Rows[dts.Rows.Count - 1]["dDateTime"]).ToString("HH:mm");
                            string stime = GetDate(TH.BaseClass.BaseFunction.ReturnDate(dts.Rows[0]["dDateTime"]).ToString("HH:mm"), 1);
                            string etime = GetDate(TH.BaseClass.BaseFunction.ReturnDate(dts.Rows[dts.Rows.Count - 1]["dDateTime"]).ToString("HH:mm"), 2);

                            decimal d扣除时间1 = 0;
                            decimal d扣除时间2 = 0;
                            decimal nManHours = GetnManHours(stime, etime,out d扣除时间1,out d扣除时间2);
                            iRdCode = iRdCode + 1;
                            Model.HR_TM_OverTimeVoucher model = new Model.HR_TM_OverTimeVoucher();
                            model.VoucherID = s单据号;
                            model.cDept_num = dts.Rows[0]["cDept_num"].ToString();
                            model.vJbCode = vJbCode;
                            model.iComputeType = 5;
                            model.dJbDate = dDate;
                            model.nManHours = nManHours;
                            model.cTimeUseless1 = d扣除时间1.ToString();
                            model.cTimeUseless2 = d扣除时间2.ToString();
                            model.dDutyTime = sdtime;
                            model.dOffTime = edtime;
                            model.bOverDate = 0;
                            model.bOverDate2 = 0;
                            model.dBegintime = sdtime;
                            model.dEndTime = edtime;
                            model.iBeginCardAhead = 0;
                            model.iEndCardForward = 0;
                            model.rFreeCardMode = 0;
                            model.iRecordId = iRecordId;
                            iRecordId = iRecordId + 1;
                            model.bAuditFlag = 0;
                            model.vReason = "系统自动导入责任人休息日加班";

                            model.cAuditor = "demo";
                            //model.cAuditorNum = "demo";
                            model.cCreator = "demo";
                            model.cCreatorNum = "demo";
                            model.cOperator = "demo";
                            model.cOperatorNum = "demo";
                            model.dCreatTime = nowdate;
                            //model.dAuditTime = nowdate;
                            model.dOperatTime = nowdate;


                            model.rDealType = "0";
                            DAL.HR_TM_OverTimeVoucher dal = new DAL.HR_TM_OverTimeVoucher();
                            sSQL = dal.Add(model);
                            DbHelperSQL.ExecuteNonQuery(tran, CommandType.Text, sSQL);

                            Guid guid = Guid.NewGuid();
                            Guid guid2 = Guid.NewGuid();
                            Model.hr_tm_OverTimeresult model2 = new Model.hr_tm_OverTimeresult();
                            model2.VoucherID = s单据号;
                            model2.uRecordId = guid;
                            model2.uOverTimeCode = guid2;
                            model2.cPsn_Num = cPsn_Num;
                            model2.nOvertimeHours = 0;
                            model2.nManHours = nManHours;
                            model2.dJbDate = dDate;
                            model2.vJbCode = vJbCode;
                            model2.dDutyTime = stime;
                            model2.dOffTime = etime;
                            model2.dBegintime = sdtime;
                            model2.dEndTime = edtime;
                            model2.bOverDate = 0;
                            model2.bOverDate2 = 0;
                            model2.bPeriod = 0;
                            model2.bCompute = 0;
                            model2.iComputeType = 5;
                            model2.iRecordId = iRecordId;
                            model2.vReason = "系统自动导入责任人休息日加班";

                            //model2.cAuditor = "demo";
                            model2.cAuditorNum = "demo";
                            model2.cCreator = "demo";
                            model2.cCreatorNum = "demo";
                            model2.dCreatTime = nowdate;
                            //model2.dAuditTime = nowdate;
                            model2.rFreeCardMode = "1";
                            model2.JobNumber = JobNumber;
                            model2.cTimeUseless1 = d扣除时间1.ToString();
                            model2.cTimeUseless2 = d扣除时间2.ToString();
                            model2.nDeductedTime = 0;
                            model2.nCanceledTime = 0;
                            model2.nBalancedTime = 0;
                            model2.nAbsentOverHours = 0;
                            model2.iRowNo = 1;
                            model2.rDealType = "0";
                            model.bAuditFlag = 0;

                            DAL.hr_tm_OverTimeresult dal2 = new DAL.hr_tm_OverTimeresult();
                            sSQL = dal2.Add(model2);
                            DbHelperSQL.ExecuteNonQuery(tran, CommandType.Text, sSQL);

                            sSQL = @"
IF EXISTS(select cNumber as Maxnumber From VoucherHistory  with (XLOCK) Where  CardNumber='TM03'  and cSeed = '333333333333333333') 
    update VoucherHistory set cNumber='222222222222222222' Where  CardNumber='TM03'  and cSeed = '333333333333333333'
else
    Insert into VoucherHistory(CardNumber,cNumber,cSeed,cContent, cContentRule) values('TM03','222222222222222222','333333333333333333','日期','日')
            ";
                            sSQL = sSQL.Replace("111111111111111111", d当前服务器时间.ToString("yyMM"));
                            sSQL = sSQL.Replace("222222222222222222", iRdCode.ToString());
                            sSQL = sSQL.Replace("333333333333333333",d当前服务器时间.ToString("yyyyMMdd"));
                            DbHelperSQL.ExecuteNonQuery(tran, CommandType.Text, sSQL);
                        }
                    }

                    tran.Commit();

                    dNowOut = DateTime.Now;
                }
                catch (Exception error)
                {
                    tran.Rollback();
                    throw new Exception(error.Message);
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
        /// <summary>
        /// 根据序号组装单据号
        /// </summary>
        /// <param name="l"></param>
        /// <param name="iLength"></param>
        /// <param name="s前缀"></param>
        /// <returns></returns>
        private string sGetCode(int l, int iLength, string s前缀)
        {
            string sCode = l.ToString();
            for (int i = 0; i < iLength; i++)
            {
                if (sCode.Length < iLength)
                {
                    sCode = "0" + sCode;
                }
                else
                {
                    break;
                }
            }
            return s前缀 + sCode;
        }


        private decimal GetnManHours(string stime, string estime,out decimal d扣除1,out decimal d扣除2)
        {
            DateTime d1 = DateTime.Parse(stime);
            DateTime d2 = DateTime.Parse(estime);
            d扣除1 = 0;
                d扣除2=0;

            if (d1 > TH.BaseClass.BaseFunction.ReturnDate("12:00") && d1 < TH.BaseClass.BaseFunction.ReturnDate("13:00"))
                d1 = TH.BaseClass.BaseFunction.ReturnDate("13:00");
            if (d2 > TH.BaseClass.BaseFunction.ReturnDate("12:00") && d2 < TH.BaseClass.BaseFunction.ReturnDate("13:00"))
                d2 = TH.BaseClass.BaseFunction.ReturnDate("12:00");

            if (d1 > TH.BaseClass.BaseFunction.ReturnDate("17:00") && d1 < TH.BaseClass.BaseFunction.ReturnDate("17:30"))
                d1 = TH.BaseClass.BaseFunction.ReturnDate("17:30");
            if (d2 > TH.BaseClass.BaseFunction.ReturnDate("17:00") && d2 < TH.BaseClass.BaseFunction.ReturnDate("17:30"))
                d2 = TH.BaseClass.BaseFunction.ReturnDate("17:00");

            //求两个时间差
            System.TimeSpan ND = d2 - d1;
            //求两个时间的分钟差
            int hh = ND.Hours;
            int mm = ND.Minutes;

            decimal d = TH.BaseClass.BaseFunction.ReturnDecimal(hh);
            if (mm > 0)
                d = d + (decimal)0.5;

            if (d1 <= TH.BaseClass.BaseFunction.ReturnDate("12:00") && d2 >= TH.BaseClass.BaseFunction.ReturnDate("13:00"))
            {
                d = d - (decimal)1;
                d扣除1 = (decimal)1;
            }

            if (d1 <= TH.BaseClass.BaseFunction.ReturnDate("17:00") && d2 >= TH.BaseClass.BaseFunction.ReturnDate("17:30"))
            {
                d = d - (decimal)0.5;
                d扣除2 = (decimal)0.5;
            }

            return d;
        }

        private string GetDate(string time, int b)
        {
            int h = int.Parse(time.Substring(0, 2));
            int m = int.Parse(time.Substring(3, 2));
            if (b == 1)//早上
            {
                if (m > 30)//大于30分 下个小时整点
                {
                    h = h + 1;
                    m = 0;
                }
                else if (m > 0 && m < 30)//小于30分 本小时30分
                {
                    m = 30;
                }
            }
            else//下班
            {
                if (m > 30)//大于30分 本小时30分
                {
                    m = 30;
                }
                else if (m > 0 && m < 30)//小于30分 本小时0分
                {
                    m = 0;
                }
            }
            string stime = "";
            if (h < 10)
            {
                stime = stime + "0";
            }
            stime = stime + h + ":";
            if (m < 10)
            {
                stime = stime + "0";
            }
            stime = stime + m;
            return stime;
        }

        private string GetType(string ddate)
        {
            //法定假日
            string sSQL = "select *,datename(weekday,drestdate) as [week]  from hr_tm_restday where cCode='01' and rDateProperty='2' and dRestDate='" + ddate + "' order by dRestDate";
            DataTable dt = DbHelperSQL.Query(sSQL);
            if (dt.Rows.Count > 0)
            {
                return "CS03";
            }
            //休息日
            sSQL = "select *,datename(weekday,drestdate) as [week]  from hr_tm_restday where cCode='01' and rDateProperty = '1' and dRestDate='" + ddate + "'  order by dRestDate";
            DataTable dt1 = DbHelperSQL.Query(sSQL);
            if (dt1.Rows.Count > 0)
            {
                return "CS02";
            }
            return "";
        }


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
