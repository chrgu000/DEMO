using System;
using System.Data;
using System.Collections.Generic;
using TH.Model;
namespace TH.BLL
{
    /// <summary>
    /// 订单评审
    /// </summary>
    public partial class 生产工序排产
    {
        private TH.DAL.生产工序排产 dal = new TH.DAL.生产工序排产();
        private readonly TH.DAL.GetBaseData dalBaseData = new TH.DAL.GetBaseData();


        /// <summary>
        /// 获得生产排产
        /// </summary>
        /// <param name="strWhere"></param>
        /// <returns></returns>
        public DataSet GetPCList(DateTime dDate, int iDaysCount, int iDayTime, out string sReturn)
        {
            DataSet ds = dal.GetPCList(dDate, iDaysCount, iDayTime, out sReturn);
            return ds;
        }

        /// <summary>
        /// 获得生产排产默认天数
        /// </summary>
        public int GetPCDays()
        {
            return  dal.GetPCDays();
        }

        /// <summary>
        /// 获得生产默认日工时
        /// </summary>
        public int GetDayTime()
        {
            return dal.GetDayTime();
        }

        public int Save(DateTime dDate, DataTable dtDetails)
        {
            return dal.Save(dDate, dtDetails);
        }

        public int Audit(DateTime dDate)
        {
            return dal.Audit(dDate);
        }

        public int UnAudit(DateTime dDate)
        {
            return dal.UnAudit(dDate);
        }

        public int Del(DateTime dDate)
        {
            return dal.Del(dDate);
        }

        /// <summary>
        /// 获得工作日历
        /// </summary>
        /// <param name="iYear"></param>
        /// <returns></returns>
        public DataTable GetWorkCalendar(int iYear)
        {
            return dal.GetWorkCalendar(iYear);
        }

        /// <summary>
        /// 平移计划
        /// </summary>
        /// <param name="iDays"></param>
        /// <param name="dt"></param>
        /// <param name="dtmPlan"></param>
        /// <param name="sReturn"></param>
        /// <returns></returns>
        public DataTable TZ天数(int iDays, DataTable dt, DateTime dtmPlan, out string sReturn)
        {
            DataTable dtTemp = dt.Copy();

            try
            {
                sReturn = "";
                DataTable dtTemp日历 = dal.GetWorkCalendar(dtmPlan.Year);

                for (int i = 0; i < dtTemp.Rows.Count; i++)
                {
                    if (!Convert.ToBoolean(dtTemp.Rows[i]["choose"]))
                    {
                        continue;
                    }

                    #region 调整天数（往后）

                    if (iDays > 0)
                    {
                        string sMaxCol = "";
                        DateTime dMaxDate = dtmPlan;

                        for (int j = dtTemp.Columns.Count - 1; j >= 0; j--)
                        {
                            string sColName = dtTemp.Columns[j].ColumnName.Trim();
                            if (sColName.Length == 8 && sColName.Substring(0, 2) == "数量")
                            {
                                if (sMaxCol == "")
                                {
                                    sMaxCol = sColName;

                                    string s = sMaxCol.Substring(2);
                                    dMaxDate = BaseFunction.BaseFunction.ReturnDate("20" + s.Substring(0, 2) + "-" + s.Substring(2, 2) + "-" + s.Substring(4));
                                }
                                decimal dQty = BaseFunction.BaseFunction.ReturnDecimal(dtTemp.Rows[i][j]);
                                if (dQty == 0)
                                {
                                    continue;
                                }
                                string sNowCol = dtTemp.Columns[j].ColumnName.Trim();
                                string s2 = sNowCol.Substring(2);
                                DateTime dNowDate = BaseFunction.BaseFunction.ReturnDate("20" + s2.Substring(0, 2) + "-" + s2.Substring(2, 2) + "-" + s2.Substring(4));

                                DateTime dTime = dNowDate;
                                int iColAdd = 0;
                                int iDaysTemp = iDays;
                                while (iDaysTemp > 0)
                                {
                                    dTime = dTime.AddDays(1);
                                    iColAdd += 1;

                                    DataRow[] dr = dtTemp日历.Select("iYear = " + dTime.Year + " and iMonth = " + dTime.Month + " ");
                                    int iDayTime = BaseFunction.BaseFunction.ReturnInt(dr[0]["i" + dTime.Day.ToString()]);

                                    if (iDayTime > 0)
                                    {
                                        iDaysTemp -= 1;
                                    }
                                }
                                if (dTime > dMaxDate)
                                {
                                    sReturn = sReturn + "行" + (i + 1).ToString() + "超出当前排产日期\n";

                                    //gridView1.SetRowCellValue(i, gridView1.Columns[j], DBNull.Value);
                                    dtTemp.Rows[i]["数量" + dNowDate.ToString("yyMMdd")] = DBNull.Value;
                                }
                                else
                                {
                                    dtTemp.Rows[i]["数量" + dTime.ToString("yyMMdd")] = dQty;
                                    dtTemp.Rows[i]["数量" + dNowDate.ToString("yyMMdd")] = DBNull.Value;


                                    //gridView1.SetRowCellValue(i, gridView1.Columns["gridColtemp数量" + dTime.ToString("yyMMdd")], dQty);
                                    //gridView1.SetRowCellValue(i, gridView1.Columns["gridColtemp数量" + dNowDate.ToString("yyMMdd")], DBNull.Value);
                                }

                            }
                        }
                    }

                    #endregion
                    #region 调整天数（往前）

                    else
                    {
                        string sMinCol = "";
                        DateTime dMinDate = dtmPlan;

                        for (int j = 0; j < dtTemp.Columns.Count; j++)
                        {
                            string sColName = dtTemp.Columns[j].ColumnName.Trim();
                            if (sColName.Length == 8 && sColName.Substring(0, 2) == "数量")
                            {
                                if (sMinCol == "")
                                {
                                    sMinCol = sColName;

                                    string s = sMinCol.Substring(2);
                                    dMinDate = BaseFunction.BaseFunction.ReturnDate("20" + s.Substring(0, 2) + "-" + s.Substring(2, 2) + "-" + s.Substring(4));
                                }
                                decimal dQty = BaseFunction.BaseFunction.ReturnDecimal(dtTemp.Rows[i][j]);
                                if (dQty == 0)
                                {
                                    continue;
                                }
                                string sNowCol = dtTemp.Columns[j].ColumnName.Trim();
                                string s2 = sNowCol.Substring(2);
                                DateTime dNowDate = BaseFunction.BaseFunction.ReturnDate("20" + s2.Substring(0, 2) + "-" + s2.Substring(2, 2) + "-" + s2.Substring(4));

                                DateTime dTime = dNowDate;
                                int iColAdd = 0;
                                int iDaysTemp = iDays;
                                while (iDaysTemp < 0)
                                {
                                    dTime = dTime.AddDays(-1);
                                    iColAdd += 1;

                                    DataRow[] dr = dtTemp日历.Select("iYear = " + dTime.Year + " and iMonth = " + dTime.Month + " ");
                                    int iDayTime = BaseFunction.BaseFunction.ReturnInt(dr[0]["i" + dTime.Day.ToString()]);

                                    if (iDayTime > 0)
                                    {
                                        iDaysTemp += 1;
                                    }
                                }
                                if (dTime < dMinDate)
                                {
                                    sReturn = sReturn + "行" + (i + 1).ToString() + "早于当前排产日期\n";

                                    dtTemp.Rows[i]["数量" + dNowDate.ToString("yyMMdd")] = DBNull.Value;
                                }
                                else
                                {
                                    dtTemp.Rows[i]["数量" + dTime.ToString("yyMMdd")] = dQty;
                                    dtTemp.Rows[i]["数量" + dNowDate.ToString("yyMMdd")] = DBNull.Value;
                                }

                            }
                        }
                    }

                    #endregion

                    decimal d当前页面排产数量 = 0;

                    for (int j = dtTemp.Columns.Count - 1; j >= 0; j--)
                    {
                        string sColName = dtTemp.Columns[j].ColumnName.Trim();
                        if (sColName.Length == 8 && sColName.Substring(0, 2) == "数量")
                        {
                            d当前页面排产数量 = d当前页面排产数量 + BaseFunction.BaseFunction.ReturnDecimal(dtTemp.Rows[i][sColName], 2);
                        }
                    }

                    dtTemp.Rows[i]["当前页面排产数量"] = d当前页面排产数量;
                }

                dt = dtTemp.Copy();
            }
            catch (Exception ee)
            {
                throw new Exception(ee.Message);
            }
            return dt;
        }


        public DataTable GetLine()
        {
            return dal.GetLine();
        }
    }
}
