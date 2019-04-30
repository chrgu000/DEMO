using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using SmallERP.DBUtility;
using SmallERP.Entity;

namespace SmallERP.DataAccess
{
    public class BuyerGatingData
    {

        public BuyerGatingData()
        { }
        #region  BasicMethod
        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public BuyerGatingEntity DataRowToModel(DataRow row)
        {
            BuyerGatingEntity model = new BuyerGatingEntity();
            if (row != null)
            {
                if (row["iID"] != null && row["iID"].ToString() != "")
                {
                    model.iID = int.Parse(row["iID"].ToString());
                }
                if (row["Guid"] != null && row["Guid"].ToString() != "")
                {
                    model.Guid = new Guid(row["Guid"].ToString());
                }
                if (row["sVersion"] != null)
                {
                    model.sVersion = row["sVersion"].ToString();
                }
                if (row["sPartID"] != null)
                {
                    model.sPartID = row["sPartID"].ToString();
                }
                if (row["fOpenQTY"] != null && row["fOpenQTY"].ToString() != "")
                {
                    model.fOpenQTY = decimal.Parse(row["fOpenQTY"].ToString());
                }
                if (row["dDate"] != null && row["dDate"].ToString() != "")
                {
                    model.dDate = DateTime.Parse(row["dDate"].ToString());
                }
                if (row["sPlannerCode"] != null)
                {
                    model.sPlannerCode = row["sPlannerCode"].ToString();
                }
                if (row["sSRC"] != null)
                {
                    model.sSRC = row["sSRC"].ToString();
                }
                if (row["sProductGroup"] != null)
                {
                    model.sProductGroup = row["sProductGroup"].ToString();
                }
                if (row["sReorderPolicy"] != null)
                {
                    model.sReorderPolicy = row["sReorderPolicy"].ToString();
                }
                if (row["sRemark"] != null)
                {
                    model.sRemark = row["sRemark"].ToString();
                }
                if (row["sPreparedBy"] != null)
                {
                    model.sPreparedBy = row["sPreparedBy"].ToString();
                }
                if (row["dtmPreparedBy"] != null && row["dtmPreparedBy"].ToString() != "")
                {
                    model.dtmPreparedBy = DateTime.Parse(row["dtmPreparedBy"].ToString());
                }
                if (row["sUpdateUid"] != null)
                {
                    model.sUpdateUid = row["sUpdateUid"].ToString();
                }
                if (row["dtmUpdate"] != null && row["dtmUpdate"].ToString() != "")
                {
                    model.dtmUpdate = DateTime.Parse(row["dtmUpdate"].ToString());
                }
                if (row["iStatus"] != null && row["iStatus"].ToString() != "")
                {
                    model.iStatus = int.Parse(row["iStatus"].ToString());
                }
                if (row["bDel"] != null && row["bDel"].ToString() != "")
                {
                    if ((row["bDel"].ToString() == "1") || (row["bDel"].ToString().ToLower() == "true"))
                    {
                        model.bDel = true;
                    }
                    else
                    {
                        model.bDel = false;
                    }
                }
            }
            return model;
        }
        #endregion  BasicMethod
        #region  ExtensionMethod

        #endregion  ExtensionMethod

        /// <summary>
        /// 分页查询用户列表
        /// </summary>
        /// <param name="userId"></param>
        /// <param name="name"></param>
        /// <param name="role"></param>
        /// <param name="pageIndex"></param>
        /// <param name="pageSize"></param>
        /// <param name="total"></param>
        /// <returns></returns>
        public DataTable GetList(string sWhere, string userId, string name, string roleId, int rowStart, int rowEnd, out int total)
        {
            //获得记录总数
            StringBuilder strCountSql = new StringBuilder();
            strCountSql.Append(" Select Count(1) From TK_BuyerGating T ");
            strCountSql.Append(" Where 1=1 ");
            if (!string.IsNullOrEmpty(sWhere))
                strCountSql.Replace("1=1", "1=1" + sWhere);
            total = Convert.ToInt32(DbHelperSQL.GetSingle(strCountSql.ToString()));
            //获得记录
            List<TK_CurrentStockEntity> list = new List<TK_CurrentStockEntity>();
            StringBuilder strSql = new StringBuilder();
            strSql.Append("SELECT * FROM ( ");
            strSql.Append(" SELECT ROW_NUMBER() OVER (");
            strSql.Append(" Order By T.iID ");
            strSql.Append(")AS Row, T.* from TK_BuyerGating T ");
            strSql.Append(" WHERE 1=1 ");
            if (!string.IsNullOrEmpty(sWhere))
                strSql.Replace("1=1", "1=1" + sWhere);
            strSql.Append(" ) TT");
            strSql.AppendFormat(" WHERE TT.Row between {0} and {1}", rowStart, rowEnd);
            DataTable result = DbHelperSQL.Query(strSql.ToString()).Tables[0];
            return result;
//            //获得记录总数
//            StringBuilder strCountSql = new StringBuilder();
//            strCountSql.Append(" Select Count(1) From ");

//            PublicData p = new PublicData();
//            DataTable dtp = p.GetPeriod();
//            strCountSql.Append("(select b.child");
//            for (int i = 0; i < dtp.Rows.Count; i++)
//            {
//                strCountSql.Append(",sum(case when convert(nvarchar(10),dtmQty,120) between '" + DateTime.Parse(dtp.Rows[i]["dtmStart"].ToString()).ToString("yyyy-MM-dd")
//                    + "' and '" + DateTime.Parse(dtp.Rows[i]["dtmEnd"].ToString()).ToString("yyyy-MM-dd") + "' then Qty end) as Month" + (i + 1) + " ");
//            }
//            strCountSql.Append(@"from TK_Trialkitting_Results a left join TK_BOM b on a.cInvCode=b.parent 
//            where 1=1 and b.childsm='PURCHASED'  group by b.child having ");

//            for (int i = 0; i < dtp.Rows.Count; i++)
//            {
//                if (i > 0)
//                {
//                    strCountSql.Append(" or ");
//                }
//                strCountSql.Append("sum(case when convert(nvarchar(10),dtmQty,120) between '" + DateTime.Parse(dtp.Rows[i]["dtmStart"].ToString()).ToString("yyyy-MM-dd")
//                    + "' and '" + DateTime.Parse(dtp.Rows[i]["dtmEnd"].ToString()).ToString("yyyy-MM-dd") + "' then Qty end) >0 ");
//            }
//            strCountSql.Append(") T ");
//            if (!string.IsNullOrEmpty(sWhere))
//                strCountSql.Replace("1=1", "1=1" + sWhere);
//            total = Convert.ToInt32(DbHelperSQL.GetSingle(strCountSql.ToString()));

//            //获得记录
//            StringBuilder strSql = new StringBuilder();
//            strSql.Append("SELECT * FROM ( ");
//            strSql.Append(" SELECT ROW_NUMBER() OVER (");
//            strSql.Append(" Order By iItemNO ");
//            strSql.Append(@")AS Row, T.*
//            ,convert(nvarchar(4000),null) as sProductGroup
//            ,convert(nvarchar(4000),null) as Planner
//            ,convert(nvarchar(4000),null) as sBuyer
//            ,convert(nvarchar(4000),null) as dtmDuedate
//            ,convert(nvarchar(4000),null) as Gating
//            ,convert(nvarchar(4000),null) as sPONo 
//            ,convert(nvarchar(4000),null) as fOpenQTY 
//            ,convert(nvarchar(4000),null) as Vendor 
//            ,convert(nvarchar(4000),null) as MPN
//            ,convert(nvarchar(4000),null) as MFR
//            ,convert(nvarchar(4000),null) as Remark
//            ,convert(nvarchar(4000),null) as Action 
//            from ( ");

//            //
//            strSql.Append("select b.child as iItemNO");
//            for (int i = 0; i < dtp.Rows.Count; i++)
//            {
//                strSql.Append(",convert(nvarchar(50),sum(case when convert(nvarchar(10),dtmQty,120) between '" + DateTime.Parse(dtp.Rows[i]["dtmStart"].ToString()).ToString("yyyy-MM-dd")
//                    + "' and '" + DateTime.Parse(dtp.Rows[i]["dtmEnd"].ToString()).ToString("yyyy-MM-dd") + "' then Qty end)) as Month" + (i + 1) + " ");
//            }
//            strSql.Append(@"from TK_Trialkitting_Results a left join TK_BOM b on a.cInvCode=b.parent 
//            where 1=1 and b.childsm='PURCHASED'  group by b.child having ");

//            for (int i = 0; i < dtp.Rows.Count; i++)
//            {
//                if (i > 0)
//                {
//                    strSql.Append(" or ");
//                }
//                strSql.Append("sum(case when convert(nvarchar(10),dtmQty,120) between '" + DateTime.Parse(dtp.Rows[i]["dtmStart"].ToString()).ToString("yyyy-MM-dd")
//                    + "' and '" + DateTime.Parse(dtp.Rows[i]["dtmEnd"].ToString()).ToString("yyyy-MM-dd") + "' then Qty end) >0 ");
//            }
//            //

//            strSql.Append(") T ");
//            if (!string.IsNullOrEmpty(sWhere))
//                strSql.Replace("1=1", "1=1" + sWhere);
//            strSql.Append(" ) TT");
//            strSql.AppendFormat(" WHERE TT.Row between {0} and {1}", rowStart, rowEnd);


//            DataTable result = DbHelperSQL.Query(strSql.ToString()).Tables[0];
            
            ////计算
            //for (int i = 0; i < result.Rows.Count; i++)
            //{
            //    string iItemNO = result.Rows[i]["iItemNO"].ToString();

                
            //    string sProductGroup = "";
            //    string Planner = "";
            //    string sBuyer = "";
            //    string dtmDuedate = "";
            //    string Gating = "";
            //    string sPONo = "";
            //    string Vendor = "";
            //    string MPN = "";
            //    string MFR = "";
            //    string Remark = "";
            //    string Action = "";

            //    //获取PO
            //    StringBuilder strSqlPO = new StringBuilder();
            //    //strSqlPO.Append(@"select sProductGroup,sBuyer,dtmRequirement,fOpenQTY,dtmDuedate,sPONo,fOpenQTY as leftQty from TK_PO where iItemNO='" + iItemNO
            //    //+ "' and convert(nvarchar(10),dtmDuedate,120) >= '" + DateTime.Parse(dtp.Rows[q]["dtmStart"].ToString()).ToString("yyyy-MM-dd")
            //    //+ "' and convert(nvarchar(10),dtmDuedate,120) <= '" + DateTime.Parse(dtp.Rows[q]["dtmEnd"].ToString()).ToString("yyyy-MM-dd") + "'");
            //    strSqlPO.Append(@"select sProductGroup,sBuyer,dtmRequirement,fOpenQTY,dtmDuedate,sPONo,fOpenQTY as leftQty from TK_PO where iItemNO='" + iItemNO + "' order by dtmDuedate");
            //    DataTable dtPO = DbHelperSQL.Query(strSqlPO.ToString()).Tables[0];

            //    for (int q = 0; q < dtp.Rows.Count; q++)
            //    {
            //        bool isred = false;
            //        if (result.Rows[i]["Month" + (q + 1)] != null && result.Rows[i]["Month" + (q + 1)].ToString() != "")
            //        {
            //            double planQtySum = 0;
            //            //前三个月
            //            if (q <= 2)
            //            {
            //                for (int r = 1; r <= 5; r++)
            //                {
            //                    if (dtp.Rows[q]["iWeek" + r] != null && dtp.Rows[q]["iWeek" + r].ToString() != "")
            //                    {
            //                        string sd = DateTime.Parse(dtp.Rows[q]["iWeek" + r].ToString()).ToString("yyyy-MM-dd");
            //                        string ed = DateTime.Parse(dtp.Rows[q]["iWeek" + r].ToString()).AddDays(7).ToString("yyyy-MM-dd");
            //                        //获取计划
            //                        StringBuilder strSqlResult = new StringBuilder();
            //                        strSqlResult.Append(@"select isnull(sum(a.Qty*b.qty),0) as qty from TK_Trialkitting_Results a left join TK_BOM b on a.cInvCode=b.parent where  child='" + iItemNO
            //                        + "' and convert(nvarchar(10),dtmQty,120) >= '" + sd
            //                        + "' and convert(nvarchar(10),dtmQty,120) <= '" + ed + "' ");
            //                        DataTable dtResultPlan = DbHelperSQL.Query(strSqlResult.ToString()).Tables[0];
            //                        if (double.Parse(dtResultPlan.Rows[0][0].ToString()) > 0)
            //                        {
            //                            double planQty = double.Parse(dtResultPlan.Rows[0][0].ToString());
            //                            planQtySum = planQtySum + planQty;
            //                            DateTime planDate = DateTime.Parse(ed);

            //                            for (int s = 0; s < dtPO.Rows.Count; s++)
            //                            {
            //                                double poQty = double.Parse(dtPO.Rows[s]["leftQty"].ToString());
            //                                if (planQty > 0)
            //                                {
            //                                    DateTime poDate = DateTime.Parse(dtPO.Rows[s]["dtmDuedate"].ToString());
            //                                    if (planQty < poQty)//计划数量小于订单数量
            //                                    {
            //                                        if (DateTime.Compare(planDate, poDate) < 0 && poDate.Day >= 10)//计划日期小于订单日期
            //                                        {
            //                                            result.Rows[i]["Gating"] = "Y";
            //                                            result.Rows[i]["Action"] = "keep pullin";
            //                                            isred = true;
            //                                        }
            //                                        dtPO.Rows[s]["leftQty"] = 0;
            //                                        planQty = planQty - poQty;
            //                                    }
            //                                    else
            //                                    {
            //                                        if (DateTime.Compare(planDate, poDate) < 0 && poDate.Day >= 10)//计划日期大于订单日期
            //                                        {
            //                                            result.Rows[i]["Gating"] = "Y";
            //                                            result.Rows[i]["Action"] = "keep pullin";
            //                                            isred = true;
            //                                        }
            //                                        dtPO.Rows[s]["leftQty"] = poQty - planQty;
            //                                        planQty = planQty - poQty;
            //                                    }
            //                                }

            //                                #region
            //                                string sProductGrouptemp = dtPO.Rows[s]["sProductGroup"].ToString();
            //                                if (sProductGroup.IndexOf(sProductGrouptemp) < 0)
            //                                {
            //                                    if (sProductGroup != "")
            //                                    {
            //                                        sProductGroup = sProductGroup + ",";
            //                                    }
            //                                    sProductGroup = sProductGroup + sProductGrouptemp;
            //                                }

            //                                //string Plannertemp = dtPO.Rows[s]["Planner"].ToString();
            //                                //if (Planner.IndexOf(Plannertemp) < 0)
            //                                //{
            //                                //    if (Planner != "")
            //                                //    {
            //                                //        Planner = Planner + ",";
            //                                //    }
            //                                //    Planner = Planner + Plannertemp;
            //                                //}

            //                                string sBuyertemp = dtPO.Rows[s]["sBuyer"].ToString();
            //                                if (sBuyer.IndexOf(sBuyertemp) < 0)
            //                                {
            //                                    if (sBuyer != "")
            //                                    {
            //                                        sBuyer = sBuyer + ",";
            //                                    }
            //                                    sBuyer = sBuyer + sBuyertemp;
            //                                }

            //                                string dtmDuedatetemp = DateTime.Parse(dtPO.Rows[s]["dtmDuedate"].ToString()).ToString("yyyy-MM-dd");
            //                                if (dtmDuedate.IndexOf(dtmDuedatetemp) < 0)
            //                                {
            //                                    if (dtmDuedate != "")
            //                                    {
            //                                        dtmDuedate = dtmDuedate + ",";
            //                                    }
            //                                    dtmDuedate = dtmDuedate + dtmDuedatetemp;
            //                                }

            //                                string sPONotemp = dtPO.Rows[s]["sPONo"].ToString();
            //                                if (sPONo.IndexOf(sPONotemp) < 0)
            //                                {
            //                                    if (sPONo != "")
            //                                    {
            //                                        sPONo = sPONo + ",";
            //                                    }
            //                                    sPONo = sPONo + sPONotemp;
            //                                }

            //                                if (Remark.IndexOf(sPONotemp) < 0)
            //                                {
            //                                    if (Remark != "")
            //                                    {
            //                                        Remark = Remark + ",";
            //                                    }
            //                                    Remark = Remark + "PO" + (s + 1) + ":" + dtmDuedatetemp + "*" + poQty;
            //                                    if (isred == true)
            //                                    {
            //                                        Remark = Remark + "(" + planQty + ")";
            //                                    }
            //                                }
            //                                #endregion
            //                            }
            //                        }
            //                    }
            //                }
                            
            //                if (isred == true)
            //                {
            //                    result.Rows[i]["Month" + (q + 1)] = "(" + planQtySum + ")";//缺料
            //                }
            //                else
            //                {
            //                    result.Rows[i]["Month" + (q + 1)] = planQtySum;
            //                }
            //            }
            //            else
            //            {
            //                double planQty = double.Parse(result.Rows[i]["Month" + (q + 1)].ToString());
            //                DateTime planDate = DateTime.Parse(dtp.Rows[q]["dtmEnd"].ToString());
                            
            //                for (int s = 0; s < dtPO.Rows.Count; s++)
            //                {
            //                    double poQty = double.Parse(dtPO.Rows[s]["leftQty"].ToString());
            //                    if (planQty > 0)
            //                    {
            //                        DateTime poDate = DateTime.Parse(dtPO.Rows[s]["dtmDuedate"].ToString());
            //                        if (planQty < poQty)//计划数量小于订单数量
            //                        {
            //                            if (DateTime.Compare(planDate, poDate) < 0)//计划日期小于订单日期
            //                            {
            //                                result.Rows[i]["Month" + (q + 1)] = "(" + planQty + ")";//缺料
            //                                result.Rows[i]["Gating"] = "Y";
            //                                result.Rows[i]["Action"] = "keep pullin";
            //                                isred = true;
            //                            }
            //                            dtPO.Rows[s]["leftQty"] = 0;
            //                            planQty = planQty - poQty;
            //                        }
            //                        else
            //                        {
            //                            if (DateTime.Compare(planDate, poDate) < 0)//计划日期大于订单日期
            //                            {
            //                                result.Rows[i]["Month" + (q + 1)] = "(" + planQty + ")";//缺料
            //                                result.Rows[i]["Gating"] = "Y";
            //                                result.Rows[i]["Action"] = "keep pullin";
            //                                isred = true;
            //                            }
            //                            dtPO.Rows[s]["leftQty"] = poQty - planQty;
            //                            planQty = planQty - poQty;
            //                        }
            //                    }

            //                    #region
            //                    string sProductGrouptemp = dtPO.Rows[s]["sProductGroup"].ToString();
            //                    if (sProductGroup.IndexOf(sProductGrouptemp) < 0)
            //                    {
            //                        if (sProductGroup != "")
            //                        {
            //                            sProductGroup = sProductGroup + ",";
            //                        }
            //                        sProductGroup = sProductGroup + sProductGrouptemp;
            //                    }

            //                    //string Plannertemp = dtPO.Rows[s]["Planner"].ToString();
            //                    //if (Planner.IndexOf(Plannertemp) < 0)
            //                    //{
            //                    //    if (Planner != "")
            //                    //    {
            //                    //        Planner = Planner + ",";
            //                    //    }
            //                    //    Planner = Planner + Plannertemp;
            //                    //}

            //                    string sBuyertemp = dtPO.Rows[s]["sBuyer"].ToString();
            //                    if (sBuyer.IndexOf(sBuyertemp) < 0)
            //                    {
            //                        if (sBuyer != "")
            //                        {
            //                            sBuyer = sBuyer + ",";
            //                        }
            //                        sBuyer = sBuyer + sBuyertemp;
            //                    }

            //                    string dtmDuedatetemp = DateTime.Parse(dtPO.Rows[s]["dtmDuedate"].ToString()).ToString("yyyy-MM-dd");
            //                    if (dtmDuedate.IndexOf(dtmDuedatetemp) < 0)
            //                    {
            //                        if (dtmDuedate != "")
            //                        {
            //                            dtmDuedate = dtmDuedate + ",";
            //                        }
            //                        dtmDuedate = dtmDuedate + dtmDuedatetemp;
            //                    }

            //                    string sPONotemp = dtPO.Rows[s]["sPONo"].ToString();
            //                    if (sPONo.IndexOf(sPONotemp) < 0)
            //                    {
            //                        if (sPONo != "")
            //                        {
            //                            sPONo = sPONo + ",";
            //                        }
            //                        sPONo = sPONo + sPONotemp;
            //                    }

            //                    if (Remark.IndexOf(sPONotemp) < 0)
            //                    {
            //                        if (Remark != "")
            //                        {
            //                            Remark = Remark + ",";
            //                        }
            //                        Remark = Remark + "PO" + (s + 1) + ":" + dtmDuedatetemp + "*" + poQty;
            //                        if (isred == true)
            //                        {
            //                            Remark = Remark + "(" + planQty + ")";
            //                        }
            //                    }
            //                    #endregion
            //                }

            //                if (isred == true)
            //                {
            //                    result.Rows[i]["Month" + (q + 1)] = "(" + planQty + ")";//缺料
            //                }
            //                else
            //                {
            //                    result.Rows[i]["Month" + (q + 1)] = planQty;
            //                }
            //            }
            //        }
            //    }

            //    result.Rows[i]["sProductGroup"] = sProductGroup;
            //    result.Rows[i]["Planner"] = Planner;
            //    result.Rows[i]["sBuyer"] = sBuyer;
            //    result.Rows[i]["dtmDuedate"] = dtmDuedate;
            //    result.Rows[i]["sPONo"] = sPONo;
            //    result.Rows[i]["Remark"] = Remark;

            //    //获取开启的PO数量
            //    StringBuilder strSqlPOSum = new StringBuilder();
            //    strSqlPOSum.Append(@"select isnull(sum(fOpenQTY),0) from TK_PO where iItemNO='" + iItemNO + "' ");
            //    DataTable dtPOSum = DbHelperSQL.Query(strSqlPOSum.ToString()).Tables[0];
            //    if (double.Parse(dtPOSum.Rows[0][0].ToString()) > 0)
            //    {
            //        result.Rows[i]["fOpenQTY"] = double.Parse(dtPOSum.Rows[0][0].ToString());
            //    }
            //}

            //return result;
        }
    }
}
