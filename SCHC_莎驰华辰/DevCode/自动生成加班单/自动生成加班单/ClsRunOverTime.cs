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

        public ClsRunOverTime(string sPConfig, string sPTxt, string sP)
        {
            sPathConfig = sPConfig;
            sPathTxt = sPTxt;
            sPath = sP;
            clsDES = ClsDES.Instance();
            clsSQLCommond = ClsDataBaseFactory.Instance();
            string ServerInfo = GetConfigValue(sPathConfig, "ServerInfo");
            string SQLUID = GetConfigValue(sPathConfig, "SQLUID");
            string SQLPWD = GetConfigValue(sPathConfig, "SQLPWD");
            SQLPWD = clsDES.Decrypt(SQLPWD);
            string DataBaseInfo = GetConfigValue(sPathConfig, "DataBaseInfo");
            ClsBaseDataInfo.sConnString = "server=" + ServerInfo + ";uid=" + SQLUID + ";pwd=" + SQLPWD + ";database=" + DataBaseInfo;

            RunOverTime();
        }

        [DllImport("w_kqrec.dll")]
        public static extern int _LANDOWNLOAD(string ipaddress);

        [DllImport("w_kqrec.dll")]
        public static extern int _LANGETUSERCODE(string ipaddress);

        TH.BaseClass.ClsDataBase clsSQLCommond;
        TH.BaseClass.ClsDES clsDES;
        public void RunOverTime()
        {
            string sErr = "";
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
                    sSQL = "select * From VoucherHistory  with (ROWLOCK) Where CardNumber='TM03'";
                    DataTable dtTemp = DbHelperSQL.ExecuteDataset(tran, CommandType.Text, sSQL).Tables[0];
                    if (dtTemp == null || dtTemp.Rows.Count < 1)
                    {
                        iRdCode = 1;
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
select a.* 
from [dbo].[_Get刷卡签卡数据] a
	left join hr_tm_OverTimeresult b on a.cPsn_Num = b.cPsn_Num
where 1=1 
	and a.dDateTime >= dateadd(month,-3,getdate())
	and a.cPsn_Num in (select cPsn_Num from hr_hi_person where isnull(chdefine1,'') = '是')
	and  CONVERT(VARCHAR(10),a.dDateTime,120) not in (select dJbDate from hr_tm_OverTimeresult)
order by cPsn_Num,dDateTime
";
                    DataTable dt = DbHelperSQL.ExecuteDataset(tran, CommandType.Text, sSQL).Tables[0];

                    bool b有加班单需要生成 = false;
                    for (int i = 0; i < dt.Rows.Count; i++)
                    {
                        string dDate = DateTime.Parse(dt.Rows[i]["dDateTime"].ToString()).ToString("yyyy-MM-dd");

                        string vJbCode = GetType(dDate);

                        //string Card = dt.Rows[i]["Card"].ToString();
                        string cPsn_Num = dt.Rows[i]["cPsn_Num"].ToString();
                        string JobNumber = dt.Rows[i]["JobNumber"].ToString();

                        // 非节假或休息日加班跳过
                        if (vJbCode == "")
                            continue;

                        string s单据号 = sGetCode(iRdCode, 4, "JB" + d当前服务器时间.ToString("yyMMdd"));
                        sSQL = "select * from hr_tm_OverTimeresult where cPsn_Num='" + cPsn_Num + "' and dJbDate='" + dDate + "'";
                        DataTable dta = DbHelperSQL.ExecuteDataset(tran, CommandType.Text, sSQL).Tables[0];
                        //已有加班单，不自动生成
                        if (dta != null && dta.Rows.Count > 0)
                        {
                            continue;
                        }

                        b有加班单需要生成 = true;
                        //签卡数据 有签卡数据
                        sSQL = @"
select a.*,b.cDept_num 
from [_Get刷卡签卡数据] a
    left join hr_hi_person b on a.cPsn_Num = b.cPsn_Num
where a.cPsn_Num = '111111' and CONVERT(VARCHAR(10),a.dDateTime,120) = '222222'
order by dDateTime
                        ";
                        sSQL = sSQL.Replace("111111", cPsn_Num);
                        sSQL = sSQL.Replace("222222", dDate);
                        DataTable dts = clsSQLCommond.ExecQuery(sSQL);
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
                            model.bAuditFlag = 1;
                            model.vReason = "系统自动导入责任人休息日加班";

                            model.cAuditor = "demo";
                            model.cAuditorNum = "demo";
                            model.cCreator = "demo";
                            model.cCreatorNum = "demo";
                            model.cOperator = "demo";
                            model.cOperatorNum = "demo";
                            model.dCreatTime = nowdate;
                            model.dAuditTime = nowdate;
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

                            model2.cAuditor = "demo";
                            model2.cAuditorNum = "demo";
                            model2.cCreator = "demo";
                            model2.cCreatorNum = "demo";
                            model2.dCreatTime = nowdate;
                            model2.dAuditTime = nowdate;
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
                            model.bAuditFlag = 1;

                            DAL.hr_tm_OverTimeresult dal2 = new DAL.hr_tm_OverTimeresult();
                            sSQL = dal2.Add(model2);
                            DbHelperSQL.ExecuteNonQuery(tran, CommandType.Text, sSQL);
                        }
                    }

                    if (b有加班单需要生成)
                    {

                        // 更新单据号
                        sSQL = @"
            IF EXISTS(select cNumber as Maxnumber From VoucherHistory  with (XLOCK) Where  CardNumber='TM03'  ) 
                update VoucherHistory set cNumber='222222' Where  CardNumber='TM03' 
            else
                Insert into VoucherHistory(CardNumber,cNumber) values('TM03','222222')
            ";
                        sSQL = sSQL.Replace("111111", d当前服务器时间.ToString("yyMM"));
                        sSQL = sSQL.Replace("222222", iRdCode.ToString());
                        DbHelperSQL.ExecuteNonQuery(tran, CommandType.Text, sSQL);
                    }

                    //int str = _LANDOWNLOAD("10.131.64.237");
                    sSQL = "select cPsn_Num,cPsn_Name,vCardNo,JobNumber ,cDept_num ,chdefine1 from hr_hi_person ";
                    DataTable dtper = DbHelperSQL.ExecuteDataset(tran, CommandType.Text, sSQL).Tables[0];

                    sSQL = "select isnull(max(ID),0)+1 from _KQLIST";
                    DataTable dtmax = DbHelperSQL.ExecuteDataset(tran, CommandType.Text, sSQL).Tables[0];
                    long iID = long.Parse(dtmax.Rows[0][0].ToString());
                    string[] list = File.ReadAllLines("KQREC.txt");
                    DateTime dNow = DateTime.Now;
                    for (int i = 0; i < list.Length; i++)
                    {
                        string kq = list[i];
                        string kqrq = kq.Substring(15, 4) + "-" + kq.Substring(19, 2) + "-" + kq.Substring(21, 2);
                        string kqsj = kq.Substring(10, 5);
                        string vCardNo = kq.Substring(2, 8).Trim();
                        DateTime sdt;
                        if (!DateTime.TryParse(kqrq, out sdt))
                            continue;
                        if (sdt <= DateTime.Parse("2015-08-31"))
                            continue;

                        DataRow[] dwper = dtper.Select("vCardNo='" + vCardNo + "'");
                        string cPsn_Num = "";
                        string JobNumber = "";
                        string cPsn_Name = "";
                        string cDept_num = "";
                        string chdefine1 = "";
                        if (dwper.Length > 0)
                        {
                            cPsn_Num = dwper[0]["cPsn_Num"].ToString();
                            JobNumber = dwper[0]["JobNumber"].ToString();
                            cPsn_Name = dwper[0]["cPsn_Name"].ToString();
                            cDept_num = dwper[0]["cDept_num"].ToString();
                            chdefine1 = dwper[0]["chdefine1"].ToString();
                            cPsn_Num = dwper[0]["cPsn_Num"].ToString();
                        }

                        sSQL = "select * from _KQLIST with (nolock) where Card='" + vCardNo + "' and  convert(nvarchar(10),dDate,120)='" + kqrq + "' and dTime='" + kqsj + "'";
                        DataTable dtc = DbHelperSQL.ExecuteDataset(tran, CommandType.Text, sSQL).Tables[0];
                        if (dtc.Rows.Count == 0)
                        {
                            sSQL = "insert into _KQLIST(dDate,dTime,Card,cPsn_Num,cPsn_Name,JobNumber,cDept_num,chdefine1) values('" + kqrq + "','" + kqsj + "','" + vCardNo + "'"
                                   + ",'" + cPsn_Num + "','" + cPsn_Name + "','" + JobNumber + "','" + cPsn_Num + "','" + chdefine1 + "')";
                            DbHelperSQL.ExecuteNonQuery(tran, CommandType.Text, sSQL);

                            sSQL = "select * from hr_tm_OriCardData where vCardNo='" + vCardNo + "' and dDateTime='" + TH.BaseClass.BaseFunction.ReturnDate(kqrq + " " + kqsj) + "'";//只导入范围内
                            DataTable dtkq = DbHelperSQL.ExecuteDataset(tran, CommandType.Text, sSQL).Tables[0];
                            if (dtkq.Rows.Count == 0)
                            {
                                Model.hr_tm_OriCardData model = new Model.hr_tm_OriCardData();
                                model.uRecordId = Guid.NewGuid();
                                model.cPsn_Num = cPsn_Num;
                                model.vCardNo = vCardNo;
                                model.dDateTime = TH.BaseClass.BaseFunction.ReturnDate(kqrq + " " + kqsj);
                                model.bManual = false;
                                model.iFlag = 0;

                                model.bEffect = 1;
                                model.bAuditFlag = true;

                                model.JobNumber = JobNumber;
                                model.cSource = "0";
                                model.vReason = "系统自动导入";

                                model.dAuditTime = dNow.ToString();
                                model.dSysTime = dNow;
                                model.cOptPsn_Num = "demo";
                                model.cAuditorNum = "demo";

                                DAL.hr_tm_OriCardData dal = new DAL.hr_tm_OriCardData();
                                sSQL = dal.Add(model);
                                DbHelperSQL.ExecuteNonQuery(tran, CommandType.Text, sSQL);
                            }
                        }

                        
                    }

                    if (sErr != "")
                    {
                        using (System.IO.StreamWriter sw = new System.IO.StreamWriter(sPath + @"\log.txt", true))
                        {
                            sw.WriteLine(DateTime.Now.ToString("sErr" + "yyyy-MM-dd HH:mm:ss ") + sErr);
                        }
                    }



                    tran.Commit();
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
            string sSQL = "select *,datename(weekday,drestdate) as [week]  from hr_tm_restday where cCode='01' and rDateProperty='2' and dRestDate='" + ddate + "' order by dRestDate";//and year(dRestDate)=2015
            DataTable dt = clsSQLCommond.ExecQuery(sSQL);
            if (dt.Rows.Count > 0)
            {
                return "CS03";
            }
            //休息日加班
            sSQL = "select *,datename(weekday,drestdate) as [week]  from hr_tm_restday where cCode='01' and rDateProperty<>'2' and dRestDate='" + ddate + "'  order by dRestDate";
            DataTable dt1 = clsSQLCommond.ExecQuery(sSQL);
            if (dt1.Rows.Count > 0)
            {
                if (dt1.Rows[0]["rDateProperty"].ToString() == "1")//休息日
                {
                    return "CS02";
                }
            }
            else
            {
                sSQL = "select datename(weekday,'" + ddate + "')";
                DataTable dt2 = clsSQLCommond.ExecQuery(sSQL);
                if (dt2.Rows.Count > 0)
                {
                    if (dt2.Rows[0][0].ToString() == "星期日" || dt2.Rows[0][0].ToString() == "星期六")
                    {
                        return "CS02";
                    }

                }
            }
            ////平时加班
            //sSQL = "select *,datename(weekday,drestdate) as [week]  from hr_tm_restday where cCode='01' and rDateProperty<>'2' and dRestDate='" + ddate + "' and rDateProperty =0 order by dRestDate";
            //DataTable dt2 = clsSQLCommond.ExecQuery(sSQL);
            //if (dt2.Rows.Count > 0)
            //{
            //    return "CS01";
            //}
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

        public void GetTimer()
        {
            TH.BaseClass.ClsDES clsDES = TH.BaseClass.ClsDES.Instance();
            clsSQLCommond = TH.BaseClass.ClsDataBaseFactory.Instance();
            string ServerInfo = GetConfigValue(sPathConfig, "ServerInfo");
            string SQLUID = GetConfigValue(sPathConfig, "SQLUID");
            string SQLPWD = clsDES.Decrypt(GetConfigValue(sPathConfig, "SQLPWD"));
            string DataBaseInfo = GetConfigValue(sPathConfig, "DataBaseInfo");
            TH.BaseClass.ClsBaseDataInfo.sConnString = "server=" + ServerInfo + ";uid=" + SQLUID + ";pwd=" + SQLPWD + ";database=" + DataBaseInfo;

            RunOverTime();
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
