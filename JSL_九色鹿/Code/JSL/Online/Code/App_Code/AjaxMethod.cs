using System;
using System.Data;
using System.Data.SqlClient;
using System.Data.OleDb;
using System.Configuration;
using System.Collections;
using System.Web.Configuration;
using BaseClass;
namespace Ajax
{

    /// <summary>
    /// Summary description for AjaxProClass.
    /// </summary>
    public class AjaxMethod : System.Web.UI.Page
    {
        DataTable dt = new DataTable();
        string sSQL = "";
        string Conn = WebConfigurationManager.ConnectionStrings["ConnectionString1"].ToString();
        //protected 系统服务.ClsDataBase clsSQLCommond = 系统服务.ClsDataBaseFactory.Instance();

        #region GetLogOut 退出登录
        /// <summary>
        /// 退出登录
        /// </summary>
        /// <returns></returns>
        [Ajax.AjaxMethod(Ajax.HttpSessionStateRequirement.Read)]
        public bool GetLogOut(string uid)
        {
            SqlConnection conn = new SqlConnection(Conn);
            conn.Open();
            SqlTransaction tran = conn.BeginTransaction();
            try
            {
                sSQL = "update Employee set IsLog='N' where UserID='" + uid + "'";
                DbHelperSQL.ExecuteNonQuery(tran, CommandType.Text, sSQL);
            }
            catch (Exception ee)
            {
                tran.Rollback();
                return false;
            }
            finally
            {
            }
            //PublicClass.SetCookie("", "", "", "");
            return true;
        }
        #endregion

        #region 条码扫描入库
        /// <summary>
        /// 条码扫描入库
        /// </summary>
        /// <returns></returns>
        [Ajax.AjaxMethod(Ajax.HttpSessionStateRequirement.Read)]
        public string GetIn(string boxid, string ddate, string flag, string txtcPosCode)
        {
            SqlConnection conn = new SqlConnection(Conn);
            conn.Open();
            SqlTransaction tran = conn.BeginTransaction();
            try
            {
                string uid = Session["uID"].ToString();
                if (uid == "")
                {
                    return "制单人为空，请重新登录";
                }
                string tablename = "RdRecord03";
                string tablenames = "RdRecords03";
                decimal sQty = 1;
                if (flag == "2")
                {
                    sQty = -1;
                }


                string sErr = "";

                string cvencode = "";

                #region 盒
                string[] split = boxid.Split(',');
                for (int i = 0; i < split.Length; i++)
                {
                    string sBoxNO1 = split[i];
                    for (int j = i + 1; j < split.Length; j++)
                    {
                        string sBoxNO2 = split[j];
                        {
                            if (sBoxNO1 == sBoxNO2)
                            {
                                sErr = sErr + "盒号:" + sBoxNO1 + " 重复\n";
                                break;
                            }
                        }

                    }

                    if (flag == "1")
                    {
                        //是否已入库
                        sSQL = @"select count(1) as iCou from RdRecords03 a left join RdRecord03 b on a.ID=b.id where 1=1 ";
                        if (split[i].Length == 20)
                        {
                            sSQL=sSQL.Replace("1=1","1=1 and sBoxNo='" + split[i] + "'");
                        }
                        else
                        {
                            sSQL=sSQL.Replace("1=1","1=1 and BoxNo='" + split[i] + "'");
                        }
                        int iCou = Convert.ToInt32(DbHelperSQL.ExecuteDataset(tran, CommandType.Text, sSQL).Tables[0].Rows[0][0]);
                        if (iCou > 0)
                        {
                            sErr = sErr + split[i] + "已入库";
                        } 
                    }
                    else if (flag == "2")
                    {
                        sErr = sErr + split[i] + "红字出库暂不可用";
//                        sSQL = @"select sBoxNo,BoxNo from RdRecords WITH (NOLOCK) left join RdRecord WITH (NOLOCK) on RdRecords.ID=RdRecord.id 
//                            where  1=1 group by sBoxNo,BoxNo having sum(BoxQty)<>0  ";
//                        if (split[i].Length == 20)
//                        {
//                            sSQL = sSQL.Replace("1=1", "1=1 and sBoxNo='" + split[i] + "'");
//                        }
//                        else
//                        {
//                            sSQL = sSQL.Replace("1=1", "1=1 and BoxNo='" + split[i] + "'");
//                        }
//                        DataTable dta = clsSQLCommond.ExecQuery(sSQL);
//                        if (dta.Rows.Count == 0)
//                        {
//                            sErr = sErr + split[i] + "无销售出库单";
//                        }
                    }
                }

                if (sErr == "")
                {
                    long iID = 系统服务.序号.GetMaxID("RD");
                    string 单据号 = 系统服务.序号.GetMaxCodeRD("cRDCode");

                    Sql sc = new Sql();
                    sc.Get(tablename);
                    sc.ToString("ID", iID.ToString());
                    sc.ToString("cRdCode", 单据号);
                    sc.ToString("dDate", ddate);
                    sc.ToString("cMSCode", "0004");
                    sc.ToString("cRSCode", "0301");
                    sc.ToString("cWhCode", "02");
                    sc.ToString("Flag", flag);
                    sc.ToString("dCreatesysTime", DateTime.Now.ToString());
                    sc.ToString("dCreatesysPerson", uid);

                    for (int i = 0; i < split.Length; i++)
                    {
                        sSQL = @"
select c.*,b.cInvCode,e.cVenCode 
from SO_SOPackingMain  a WITH (NOLOCK) left join SO_SOPackingDetails b WITH (NOLOCK) on a.ID=b.ID 
    left join SO_SOPackingSublist c WITH (NOLOCK) on b.AutoID=c.AutoID 
    left join MO_MODetails d WITH (NOLOCK) on  b.MOAutoID=d.AutoID 
    left join MO_MOMain e on d.ID=e.ID 
WHERE 1=1
";

                        if (split[i].Length == 20)
                        {
                            sSQL = sSQL.Replace("1=1", "1=1 and c.sBoxNo='" + split[i] + "'");
                        }
                        else
                        {
                            sSQL = sSQL.Replace("1=1", "1=1 and b.BoxNo='" + split[i] + "'");
                        }
                        DataTable dtm = DbHelperSQL.ExecuteDataset(tran, CommandType.Text, sSQL).Tables[0];
                        if (dtm.Rows.Count == 0)
                        {
                            sErr = sErr + split[i] + "未找到相应的装箱单";
                        }
                        else
                        {
                            for (int j = 0; j < dtm.Rows.Count; j++)
                            {
                                Sql sc1 = new Sql();
                                sc1.Get(tablenames);
                                sc1.ToString("ID", iID.ToString());
                                long sAutoID = 系统服务.序号.GetMaxID("RDS");
                                sc1.ToString("AutoID", sAutoID);
                                sc1.ToString("cRdCode", 单据号);
                                sc1.ToString("iRowNo", (i + 1).ToString());
                                sc1.ToString("cInvCode", dtm.Rows[j]["cInvCode"].ToString());
                                sc1.ToString("BoxNo", dtm.Rows[j]["BoxNo"].ToString());
                                sc1.ToString("BoxQty", 1 * sQty);
                                sc1.ToString("sBoxQty", 1 * sQty);
                                sc1.ToString("iQuantity", dtm.Rows[j]["iQuantity"].ToString());
                                sc1.ToString("sBoxNo", dtm.Rows[j]["sBoxNo"].ToString());
                                sc1.ToString("cPosCode", txtcPosCode);
                                sc1.ToString("cSOPSID", dtm.Rows[j]["sID"].ToString());
                                sc1.ToString("MOAutoID", dtm.Rows[j]["MOAutoID"].ToString());
                                if (cvencode == "")
                                {
                                    cvencode = dtm.Rows[j]["cVenCode"].ToString();
                                }
                                else
                                {
                                    if (cvencode != dtm.Rows[j]["cVenCode"].ToString())
                                    {
                                        sErr = sErr + split[i] + "选择的入库单委外供应商不同";
                                    }
                                }
                                sc1.ToString("M1", dtm.Rows[0]["M1"].ToString());
                                sc1.ToString("M2", dtm.Rows[0]["M2"].ToString());
                                //sc1.ToString("M3", dtm.Rows[0]["M3"].ToString());
                                //sc1.ToString("M4", dtm.Rows[0]["M4"].ToString());
                                //sc1.ToString("M5", dtm.Rows[0]["M5"].ToString());
                                //sc1.ToString("M6", dtm.Rows[0]["M6"].ToString());
                                //sc1.ToString("M7", dtm.Rows[0]["M7"].ToString());
                                //sc1.ToString("M8", dtm.Rows[0]["M8"].ToString());
                                //sc1.ToString("M9", dtm.Rows[0]["M9"].ToString());
                                //sc1.ToString("M10", dtm.Rows[0]["M10"].ToString());
                                sSQL = sc1.InsertSql();
                                DbHelperSQL.ExecuteNonQuery(tran, CommandType.Text, sSQL);

                                //反写装箱单
                                sSQL = "update SO_SOPackingSublist set sInBoxQty=isnull(sInBoxQty,0)+" + sQty + ",iInQuantity=isnull(iInQuantity,0)+" + dtm.Rows[j]["iQuantity"].ToString() + ",InRdAutoID=" + sAutoID + ",cInWhCode='02',cInPosCode=" + txtcPosCode + " where sID='" + dtm.Rows[j]["sID"].ToString() + "'";
                                DbHelperSQL.ExecuteNonQuery(tran, CommandType.Text, sSQL);
                                //反写委外订单
                                sSQL = "update MO_MODetails set sInBoxQty=isnull(sInBoxQty,0)+" + sQty + ",iOutQuantity=isnull(iOutQuantity,0)+" + dtm.Rows[j]["iQuantity"].ToString() + " where AutoID='" + dtm.Rows[j]["MOAutoID"].ToString() + "'";
                                DbHelperSQL.ExecuteNonQuery(tran, CommandType.Text, sSQL);
                            }
                        }
                    }
                    sc.ToString("cVenCode", cvencode);
                    sSQL = sc.InsertSql();
                    DbHelperSQL.ExecuteNonQuery(tran, CommandType.Text, sSQL);
                }
                #endregion

                if (sErr != "")
                {
                    throw new Exception(sErr);
                }

                //int iCount = 0;
                //if (aList.Count > 0)
                //{
                //    iCount = clsSQLCommond.ExecSqlTran(aList);
                //}
                tran.Commit();
            }
            catch (Exception ee)
            {
                tran.Rollback();
                return "程序异常，请联系管理员"+ee.Message;
            }
            finally
            {
            }
            return "保存成功";
        }
        #endregion

        #region GetSo 查询销售
        [Ajax.AjaxMethod(Ajax.HttpSessionStateRequirement.Read)]
        public string[] GetSo1(string id)
        {
            string [] str=new string[2];
            sSQL = @"select b.cCusCode,cCusName from SO_SOMain b left join Customer c on b.cCusCode=c.cCusCode where b.cSOCode='" + id + "' ";
            DataTable dt = DbHelperSQL.Query(sSQL);
            if (dt.Rows.Count > 0)
            {
                str[0] = dt.Rows[0]["cCusCode"].ToString();
                str[1] = dt.Rows[0]["cCusName"].ToString();
            }
            else
            {
                str[0] = "";
                str[1] = "";
            }
            return str;
        }
        #endregion

        #region GetOut 销售出库单
        /// <summary>
        /// 销售出库单
        /// </summary>
        /// <returns></returns>
        [Ajax.AjaxMethod(Ajax.HttpSessionStateRequirement.Read)]
        public string GetOut(string boxid, string ddate, string soid, string flag)
        {
            SqlConnection conn = new SqlConnection(Conn);
            conn.Open();
            SqlTransaction tran = conn.BeginTransaction();
            try
            {
                DataTable dtso = new DataTable();
                string cpen = "";
                string cdept = "";
                string cuscode = "";
                string sErr = "";

                string tablename = "RdRecord13";
                string tablenames = "RdRecords13";

                if(flag=="1" && soid!="")
                {
                    sSQL = "select * from SO_SODetails where cSOCode='" + soid + "' and isnull(isDispatchList,0)=1";
                    DataTable dtDis = DbHelperSQL.ExecuteDataset(tran, CommandType.Text, sSQL).Tables[0];
                    if (dtDis.Rows.Count > 0)
                    {
                        return "已生成发货单，请通过发货单发货";
                    }
                    //客户信息查询
                    sSQL = @"select *,b.sBoxQty as NotOutsBoxQty from  SO_SOMain a  WITH (NOLOCK)  left join  SO_SODetails b  WITH (NOLOCK)  on a.ID=b.ID WHERE  a.cSOCode='" + soid + "'";
                    dtso = DbHelperSQL.ExecuteDataset(tran, CommandType.Text, sSQL).Tables[0];
                    if (dtso.Rows.Count > 0)
                    {
                        cuscode = dtso.Rows[0]["cCusCode"].ToString();
                        cpen = dtso.Rows[0]["cPersonCode"].ToString();
                        cdept = dtso.Rows[0]["cDepCode"].ToString();
                    }
                    else
                    {
                        return "未找到客户";
                    }
                }

                string[] split = boxid.Split(',');
                #region 判断是否已出库
                sSQL = "select * from SO_SOPackingSublist with (nolock) where sBoxNo in ('" + boxid.Replace(",", "','") + "') or BoxNo in ('" + boxid.Replace(",", "','") + "')";
                DataTable dtPack = DbHelperSQL.ExecuteDataset(tran, CommandType.Text, sSQL).Tables[0];
                DataTable dt03 = new DataTable();
                if (flag == "1")
                {
                    sSQL = "select * from RdRecords03 with (nolock) where sBoxNo in ('" + boxid.Replace(",", "','") + "') or BoxNo in ('" + boxid.Replace(",", "','") + "')";
                    dt03 = DbHelperSQL.ExecuteDataset(tran, CommandType.Text, sSQL).Tables[0];
                }
                //判断
                if (flag == "1")
                {
                    #region 蓝字判断 
                    for (int i = 0; i < split.Length; i++)
                    {
                        DataRow[] dw = dtPack.Select("BoxNo='" + split[i] + "' or sBoxNo='" + split[i] + "'");
                        if (dw.Length > 0)
                        {
                            for (int s = 0; s < dw.Length; s++)
                            {
                                if (ReturnInt(dw[0]["sInBoxQty"]) == 0)
                                {
                                    sErr = sErr + "盒号：" + dw[s]["BoxNo"].ToString() + " 箱号：" + dw[s]["sBoxNo"].ToString() + "未入库";
                                }
                                if (ReturnInt(dw[0]["sOutBoxQty"]) > 0)
                                {
                                    sErr = sErr + "盒号：" + dw[s]["BoxNo"].ToString() + " 箱号：" + dw[s]["sBoxNo"].ToString() + "已出库";
                                }
                            }

                            DataRow[] dwso = dtso.Select("cInvCode='" + dw[0]["cInvCode"].ToString() + "' and M1='" + dw[0]["M1"].ToString() + "'");
                            if (dwso.Length == 0)
                            {
                                sErr = sErr + "盒号或箱号：" + split[i] + "不在销售订单" + soid + "中";
                            }
                        }
                        else
                        {
                            sErr = sErr + "盒号或箱号：" + split[i] + "未找到装箱单";
                        }

                        
                    }
                    
                    #endregion
                }
                else if(flag == "2")
                {
                    #region 红字判断 是否已经出库
                    for (int i = 0; i < split.Length; i++)
                    {
                        DataRow[] dw = dtPack.Select("BoxNo='" + split[i] + "' or sBoxNo='" + split[i] + "'");
                        if (dw.Length > 0)
                        {
                            for (int s = 0; s < dw.Length; s++)
                            {
                                if (ReturnInt(dw[s]["sInBoxQty"]) == 0)
                                {
                                    sErr = sErr + "盒号：" + dw[s]["BoxNo"].ToString() + " 箱号：" + dw[s]["sBoxNo"].ToString() + "未入库";
                                }
                                if (ReturnInt(dw[s]["sOutBoxQty"]) == 0)
                                {
                                    sErr = sErr + "盒号：" + dw[s]["BoxNo"].ToString() + " 箱号：" + dw[s]["sBoxNo"].ToString() + "未出库";
                                }
                                string icuscode = dw[s]["OutcCusCode"].ToString().Trim();
                                string icpen = dw[s]["OutcPersonCode"].ToString().Trim();
                                string icdept = dw[s]["OutcDepCode"].ToString().Trim();
                                if (i == 0 && s == 0)
                                {
                                    cuscode = icuscode;
                                    cpen = icpen;
                                    cdept = icdept;
                                }
                                else
                                {
                                    if (icuscode != cuscode)
                                    {
                                        sErr = sErr + split[i] + "客户不同\n";
                                    }
                                    //if (icpen != cpen)
                                    //{
                                    //    sErr = sErr + split[i] + "业务员不同\n";
                                    //}
                                    //if (icdept != cdept)
                                    //{
                                    //    sErr = sErr + split[i] + "部门不同\n";
                                    //}
                                }
                            }
                        }
                        else
                        {
                            sErr = sErr + "盒号或箱号：" + split[i] + "未找到装箱单";
                        }
                    }
                    #endregion
                }
                #endregion
                int icount = 0;
                if (sErr == "")
                {
                    string 单据号 = 系统服务.序号.GetMaxCode_SO("cRDCode");


                    long iID = 系统服务.序号.GetMaxID("RD");



                    string uid = Session["uID"].ToString();
                    if (uid == "")
                    {
                        sErr = sErr + "制单人为空，请重新登录";
                    }

                    #region 表头
                    Sql sc = new Sql();
                    sc.Get(tablename);
                    sc.ToString("ID", iID);
                    sc.ToString("cRDCode", 单据号);
                    sc.ToString("dDate", ddate);
                    sc.ToString("cCusCode", cuscode);
                    sc.ToString("cPersonCode", cpen);
                    sc.ToString("cDepCode", cdept);
                    sc.ToString("iType", "1");
                    sc.ToString("cWhCode", "02");
                    sc.ToString("Flag", flag);
                    sc.ToString("cRSCode", "1301");
                    sc.ToString("dCreatesysTime", DateTime.Now.ToString());
                    sc.ToString("dCreatesysPerson", uid);
                    sSQL = sc.InsertSql();
                    DbHelperSQL.ExecuteNonQuery(tran, CommandType.Text, sSQL);
                    #endregion
                    if (flag == "1")
                    {
                        for (int i = 0; i < dtso.Rows.Count; i++)
                        {
                            string cInvCode = dtso.Rows[i]["cInvCode"].ToString();

                            decimal iUnitPrice = ReturnDecimal(dtso.Rows[i]["D1"].ToString(), 6);
                            decimal iNatUnitPrice = ReturnDecimal(dtso.Rows[i]["iNatUnitPrice"].ToString(), 6);
                            decimal iTaxRate = ReturnDecimal(dtso.Rows[i]["iTaxRate"].ToString(), 6);
                            decimal iChangRate = ReturnDecimal(dtso.Rows[i]["iChangRate"].ToString(), 6);
                            string M1 = dtso.Rows[i]["M1"].ToString();

                            string SoAutoID = dtso.Rows[i]["AutoID"].ToString();
                            int allsBoxQty = 0;
                            decimal alliQuantity = 0;
                            DataRow[] dw03 = dt03.Select("cInvCode='" + cInvCode + "' and M1='" + M1 + "' ");
                            for (int s = 0; s < dw03.Length; s++)
                            {
                                string M2 = dw03[s]["M2"].ToString();
                                string BoxNo = dw03[s]["BoxNo"].ToString();
                                string sBoxNo = dw03[s]["sBoxNo"].ToString();
                                decimal iQuantity = decimal.Parse(dw03[s]["iQuantity"].ToString());
                                string RdAutoID = dw03[s]["AutoID"].ToString();
                                string cPosCode = dw03[s]["cPosCode"].ToString();
                                string cSOPSID = dw03[s]["cSOPSID"].ToString();

                                long sAutoID = 系统服务.序号.GetMaxID("RDS");
                                Sql sc1 = new Sql();
                                sc1.Get(tablenames);
                                sc1.ToString("ID", iID);
                                sc1.ToString("AutoID", sAutoID);
                                sc1.ToString("cRDCode", 单据号);
                                sc1.ToString("iRowNo", (i + 1).ToString());
                                sc1.ToString("cInvCode", cInvCode);
                                sc1.ToString("BoxNo", BoxNo);
                                sc1.ToString("sBoxNo", sBoxNo);

                                sc1.ToString("BoxQty", 1);
                                sc1.ToString("sBoxQty", 1);
                                sc1.ToString("iQuantity", iQuantity);

                                allsBoxQty = allsBoxQty + 1;
                                alliQuantity = alliQuantity + iQuantity;

                                sc1.ToString("RdAutoID", RdAutoID);
                                sc1.ToString("SoAutoID", SoAutoID);

                                sc1.ToString("cPosCode", cPosCode);
                                sc1.ToString("iMoney", iUnitPrice);
                                sc1.ToString("iNatMoney", iNatUnitPrice);
                                sc1.ToString("iUnitPrice", iUnitPrice);
                                sc1.ToString("iNatUnitPrice", iNatUnitPrice);
                                sc1.ToString("iTaxRate", iTaxRate);
                                sc1.ToString("iChangRate", iChangRate);

                                sc1.ToString("cSOPSID", cSOPSID);

                                sc1.ToString("M1", M1);
                                sc1.ToString("M2", M2);
                                sSQL = sc1.InsertSql();
                                DbHelperSQL.ExecuteNonQuery(tran, CommandType.Text, sSQL);
                                icount = icount + 1;

                                //反写成品入库单
                                sSQL = "update RdRecords03 set sOutBoxQty=isnull(sOutBoxQty,0)+" + 1 + ",iOutQuantity=isnull(iOutQuantity,0)+" + iQuantity + " where AutoID='" + RdAutoID + "'";
                                DbHelperSQL.ExecuteNonQuery(tran, CommandType.Text, sSQL);

                                //反写装箱单
                                sSQL = "update SO_SOPackingSublist set sOutBoxQty=isnull(sOutBoxQty,0)+" + 1 + ",iOutQuantity=isnull(iOutQuantity,0)+" + iQuantity + ",OutcCusCode='" + cuscode + "',OutcPersonCode='" + cpen + "',OutcDepCode='" + cdept + "',OutDate='" + ddate + "',OutSoAutoID='" + SoAutoID + "' where sID='" + cSOPSID + "'";
                                DbHelperSQL.ExecuteNonQuery(tran, CommandType.Text, sSQL);
                            }

                            //反写销售订单
                            sSQL = "update SO_SODetails set sOutBoxQty=isnull(sOutBoxQty,0)+" + allsBoxQty + ",iOutQuantity=isnull(iOutQuantity,0)+" + alliQuantity + " where AutoID='" + SoAutoID + "'";
                            DbHelperSQL.ExecuteNonQuery(tran, CommandType.Text, sSQL);
                        }
                    }
                    else if (flag == "2")
                    {
                        DataTable dts = Tables.Group(dtPack,new string[]{"OutSoAutoID"});
                        for (int j = 0; j < dts.Rows.Count; j++)
                        {
                            int allsBoxQty = 0;
                            decimal alliQuantity = 0;
                            for (int i = 0; i < dtPack.Rows.Count; i++)
                            {
                                if (dtPack.Rows[i]["OutSoAutoID"].ToString() == dts.Rows[j]["OutSoAutoID"].ToString())
                                {
                                    string cInvCode = dtPack.Rows[i]["cInvCode"].ToString();

                                    string M1 = dtPack.Rows[i]["M1"].ToString();
                                    string M2 = dtPack.Rows[i]["M2"].ToString();
                                    string BoxNo = dtPack.Rows[i]["BoxNo"].ToString();
                                    string sBoxNo = dtPack.Rows[i]["sBoxNo"].ToString();
                                    decimal iQuantity = -decimal.Parse(dtPack.Rows[i]["iQuantity"].ToString());
                                    string RdAutoID = dtPack.Rows[i]["AutoID"].ToString();
                                    string cPosCode = dtPack.Rows[i]["OutcPosCode"].ToString();
                                    string cSOPSID = dtPack.Rows[i]["SID"].ToString();
                                    string OutSoAutoID = dtPack.Rows[i]["OutSoAutoID"].ToString();

                                    long sAutoID = 系统服务.序号.GetMaxID("RDS");
                                    Sql sc1 = new Sql();
                                    sc1.Get(tablenames);
                                    sc1.ToString("ID", iID);
                                    sc1.ToString("AutoID", sAutoID);
                                    sc1.ToString("cRDCode", 单据号);
                                    sc1.ToString("iRowNo", (i + 1).ToString());
                                    sc1.ToString("cInvCode", cInvCode);
                                    sc1.ToString("BoxNo", BoxNo);
                                    sc1.ToString("sBoxNo", sBoxNo);

                                    sc1.ToString("BoxQty", -1);
                                    sc1.ToString("sBoxQty", -1);
                                    sc1.ToString("iQuantity", iQuantity);
                                    allsBoxQty = allsBoxQty + 1;
                                    alliQuantity = alliQuantity + iQuantity;

                                    sc1.ToString("RdAutoID", RdAutoID);
                                    sc1.ToString("SoAutoID", OutSoAutoID);

                                    sc1.ToString("cPosCode", cPosCode);

                                    decimal iUnitPrice = ReturnDecimal(dtPack.Rows[i]["OutiUnitPrice"].ToString(), 6);
                                    decimal iNatUnitPrice = ReturnDecimal(dtPack.Rows[i]["OutiNatUnitPrice"].ToString(), 6);
                                    decimal iTaxRate = ReturnDecimal(dtPack.Rows[i]["OutiTaxRate"].ToString(), 6);
                                    decimal iChangRate = ReturnDecimal(dtPack.Rows[i]["OutiChangRate"].ToString(), 6);
                                    sc1.ToString("iMoney", -iUnitPrice);
                                    sc1.ToString("iNatMoney", -iNatUnitPrice);
                                    sc1.ToString("iUnitPrice", iUnitPrice);
                                    sc1.ToString("iNatUnitPrice", iNatUnitPrice);
                                    sc1.ToString("iTaxRate", iTaxRate);
                                    sc1.ToString("iChangRate", iChangRate);

                                    sc1.ToString("cSOPSID", cSOPSID);

                                    sc1.ToString("M1", M1);
                                    sc1.ToString("M2", M2);
                                    sSQL = sc1.InsertSql();
                                    DbHelperSQL.ExecuteNonQuery(tran, CommandType.Text, sSQL);
                                    icount = icount + 1;

                                    //反写成品入库单
                                    sSQL = "update RdRecords03 set sOutBoxQty=isnull(sOutBoxQty,0)-" + 1 + ",iOutQuantity=isnull(iOutQuantity,0)-(" + iQuantity + ") where AutoID='" + RdAutoID + "'";
                                    DbHelperSQL.ExecuteNonQuery(tran, CommandType.Text, sSQL);

                                    ////反写装箱单
                                    sSQL = @"update SO_SOPackingSublist set sOutBoxQty=isnull(sOutBoxQty,0)-" + 1 + ",iOutQuantity=isnull(iOutQuantity,0)-(" + iQuantity + "),OutcCusCode=null,OutcPersonCode=null,OutcDepCode=null,OutDate=null,OutSoAutoID=null,OutiUnitPrice=null,OutiNatUnitPrice=null,OutiTaxRate=null,OutiChangRate=null,OutcPosCode=null where sID='" + cSOPSID + "'";
                                    DbHelperSQL.ExecuteNonQuery(tran, CommandType.Text, sSQL);

                                    
                                }
                            }
                            //反写销售订单
                            sSQL = "update SO_SODetails set sOutBoxQty=isnull(sOutBoxQty,0)-(" + allsBoxQty + "),iOutQuantity=isnull(iOutQuantity,0)-(" + alliQuantity + ") where AutoID='" + dts.Rows[j]["OutSoAutoID"].ToString() + "'";
                            DbHelperSQL.ExecuteNonQuery(tran, CommandType.Text, sSQL);
                        }
                        
                    }
                }
                
                if (sErr != "")
                {
                    throw new Exception(sErr);
                }
                if (icount == 0)
                {
                    throw new Exception("无单据，无法保存");
                }
                //int iCou = 0;
                //if (aList.Count > 0)
                //{
                //    iCou = clsSQLCommond.ExecSqlTran(aList);
                //}
                tran.Commit();
            }
            catch (Exception ee)
            {
                tran.Rollback();
                return ee.Message;
            }
            finally
            {
            }
            return "保存成功";
        }
        #endregion

        #region GetCustomer 查询客户编码
        [Ajax.AjaxMethod(Ajax.HttpSessionStateRequirement.Read)]
        public DataTable GetCustomer(string txt, string type)
        {
            sSQL = "select cCusCode as 客户编码,cCusName as 客户名称 from Customer where (cCusCode like '%" + txt + "%' or cCusName like '%" + txt + "%' or cCusAbbName like '%" + txt + "%')";
            if (type != "")
            {
                sSQL = sSQL + " and cCCCode='" + type + "'";
            }
            return DbHelperSQL.Query(sSQL);
        }
        #endregion

        #region GetCustomer 查询客户编码
        [Ajax.AjaxMethod(Ajax.HttpSessionStateRequirement.Read)]
        public DataTable GetTemp()
        {
            sSQL = "select* from temp123 ";
            return DbHelperSQL.Query(sSQL);
        }
        #endregion

        #region 盘点单
        /// <summary>
        /// 盘点单
        /// </summary>
        /// <returns></returns>
        [Ajax.AjaxMethod(Ajax.HttpSessionStateRequirement.Read)]
        public string GetCheckVouch(string boxid, string ddate, string flag, string txtcPosCode)
        {
            //SqlConnection con = new SqlConnection(Conn.Online);
            //SqlCommand cmd = new SqlCommand();
            //SqlTransaction trans;
            //con.Open();
            //cmd.Connection = con;
            //trans = con.BeginTransaction();
            //cmd.Transaction = trans;
            //try
            //{
            //    string uid = Session["uID"].ToString();
            //    if (uid == "")
            //    {
            //        return "制单人为空，请重新登录";
            //    }
            //    string tablename = "CheckVouch";
            //    string tablenames = "CheckVouchs";

            //    sSQL = "select isnull(isnull(max(ID),1)+1,1) as ID from " + tablename + " WITH (NOLOCK) ";
            //    long iID = long.Parse(Conn.String(sSQL));
            //    sSQL = "select isnull(max(AutoID)+1,1) as AutoID from " + tablenames + " WITH (NOLOCK) ";
            //    long sAutoID = long.Parse(Conn.String(sSQL));
            //    string 单据号 = 系统服务.序号.GetNewSerialNumberContinuous(tablename, "CheckCode");

            //    string sErr = "";
            //    string sBoxNo = "";
            //    Sql sc = new Sql();
            //    sc.Get(tablename);
            //    sc.ToString("ID", iID.ToString());
            //    sc.ToString("CheckCode", 单据号);
            //    sc.ToString("dDate", ddate);
            //    sc.ToString("cWhCode", "02");
            //    sc.ToString("dCreatesysTime", DateTime.Now.ToString());
            //    sc.ToString("dCreatesysPerson", uid);

            //    string cInvCode = "";
            //    string M1 = "";
            //    string M2 = "";
            //    int iRowNo = 0;
            //    #region 盒
            //    //判断是否有装箱单
            //    string[] split = boxid.Split(',');
            //    for (int i = 0; i < split.Length; i++)
            //    {
            //        string sWhere = "";
            //        if (split[i].Length == 10)
            //        {
            //            sWhere = "BoxNo='" + split[i] + "'";
            //        }
            //        else
            //        {
            //            sWhere = "sBoxNo='" + split[i] + "'";
            //        }
            //        sSQL = "select * from SO_SOPackingSublist where " + sWhere;
            //        DataTable dt = clsSQLCommond.ExecQuery(sSQL);
            //        if (dt.Rows.Count == 0)
            //        {
            //            throw new Exception(split[i] + " 未找到装箱单\n");
            //        }
            //        for (int j = 0; j < dt.Rows.Count; j++)
            //        {
            //            Sql sc1 = new Sql();
            //            sc1.Get(tablenames);
            //            sc1.ToString("ID", iID.ToString());
            //            sc1.ToString("AutoID", sAutoID);
            //            sc1.ToString("CheckCode", 单据号);

            //            sc1.ToString("iRowNo", iRowNo.ToString());
            //            iRowNo = iRowNo + 1;
            //            if (cInvCode == "")
            //            {
            //                cInvCode = dt.Rows[j]["cInvCode"].ToString();
            //            }
            //            else if (cInvCode != dt.Rows[j]["cInvCode"].ToString())
            //            {
            //                sErr = sErr + split[i] + "物料编码不同\n";
            //            }
            //            if (M1 == "")
            //            {
            //                M1 = dt.Rows[j]["M1"].ToString();
            //            }
            //            else if (M1 != dt.Rows[j]["M1"].ToString() && flag == "2")
            //            {
            //                sErr = sErr + split[i] + "色号不同\n";
            //            }
            //            if (M2 == "")
            //            {
            //                M2 = dt.Rows[j]["M2"].ToString();
            //            }
            //            else if (M2 != dt.Rows[j]["M2"].ToString() && flag == "3")
            //            {
            //                sErr = sErr + split[i] + "缸号不同\n";
            //            }
            //            sc1.ToString("cInvCode", dt.Rows[j]["cInvCode"].ToString());
            //            sc1.ToString("BoxNo", dt.Rows[j]["BoxNo"].ToString());
            //            sc1.ToString("BoxQty", 1);
            //            sc1.ToString("sBoxQty", 1);
            //            sc1.ToString("iQuantity", dt.Rows[j]["iQuantity"].ToString());
            //            if (sBoxNo != "")
            //            {
            //                sBoxNo = sBoxNo + ",";
            //            }
            //            sBoxNo = sBoxNo + dt.Rows[j]["sBoxNo"].ToString();
            //            sc1.ToString("sBoxNo", dt.Rows[j]["sBoxNo"].ToString());
            //            sc1.ToString("cPosCode", txtcPosCode);

            //            sc1.ToString("M1", dt.Rows[j]["M1"].ToString());
            //            sc1.ToString("M2", dt.Rows[j]["M2"].ToString());
            //            sc1.ToString("M3", dt.Rows[j]["M3"].ToString());
            //            sc1.ToString("M4", dt.Rows[j]["M4"].ToString());
            //            sc1.ToString("M5", dt.Rows[j]["M5"].ToString());
            //            sc1.ToString("M6", dt.Rows[j]["M6"].ToString());
            //            sc1.ToString("M7", dt.Rows[j]["M7"].ToString());
            //            sc1.ToString("M8", dt.Rows[j]["M8"].ToString());
            //            sc1.ToString("M9", dt.Rows[j]["M9"].ToString());
            //            sc1.ToString("M10", dt.Rows[j]["M10"].ToString());
            //            cmd.CommandText = sc1.InsertSql();
            //            cmd.ExecuteNonQuery();

            //            sAutoID = sAutoID + 1;
            //        }
            //    }
            //    //所有在库物料明细
            //    sSQL = @"select * from SO_SOPackingSublist where isnull(sInBoxQty,0)=1 and isnull(sOutBoxQty ,0)=0 and cInvCode='" + cInvCode + "'";
            //    if (flag == "2")
            //    {
            //        sSQL = sSQL + " and M1='" + M1 + "'";
            //    }

            //    else if (flag == "3")
            //    {
            //        sSQL = sSQL + " and M1='" + M1 + "' and M2='" + M2 + "' ";
            //    }

            //    DataTable dts = clsSQLCommond.ExecQuery(sSQL); 
            //    //如果在库 
            //    for (int j = 0; j < dts.Rows.Count; j++)
            //    {
            //        if (dts.Rows[j]["sBoxNo"].ToString().Trim().IndexOf(sBoxNo) == -1)
            //        {
            //            Sql sc1 = new Sql();
            //            sc1.Get(tablenames);
            //            sc1.ToString("ID", iID.ToString());
            //            sc1.ToString("AutoID", sAutoID);
            //            sc1.ToString("CheckCode", 单据号);
            //            sc1.ToString("iRowNo", iRowNo.ToString());
            //            iRowNo = iRowNo + 1;
            //            sc1.ToString("cInvCode", dts.Rows[j]["cInvCode"].ToString());
            //            sc1.ToString("BoxNo", dts.Rows[j]["BoxNo"].ToString());
            //            sc1.ToString("BoxQty", 1);
            //            sc1.ToString("sBoxQty", 0);
            //            sc1.ToString("iQuantity", 0);
            //            if (sBoxNo != "")
            //            {
            //                sBoxNo = sBoxNo + ",";
            //            }
            //            sBoxNo = sBoxNo + dts.Rows[j]["sBoxNo"].ToString();
            //            sc1.ToString("sBoxNo", dts.Rows[j]["sBoxNo"].ToString());
            //            sc1.ToString("cPosCode", txtcPosCode);

            //            sc1.ToString("M1", dts.Rows[j]["M1"].ToString());
            //            sc1.ToString("M2", dts.Rows[j]["M2"].ToString());
            //            sc1.ToString("M3", dts.Rows[j]["M3"].ToString());
            //            sc1.ToString("M4", dts.Rows[j]["M4"].ToString());
            //            sc1.ToString("M5", dts.Rows[j]["M5"].ToString());
            //            sc1.ToString("M6", dts.Rows[j]["M6"].ToString());
            //            sc1.ToString("M7", dts.Rows[j]["M7"].ToString());
            //            sc1.ToString("M8", dts.Rows[j]["M8"].ToString());
            //            sc1.ToString("M9", dts.Rows[j]["M9"].ToString());
            //            sc1.ToString("M10", dts.Rows[j]["M10"].ToString());
            //            cmd.CommandText = sc1.InsertSql();
            //            cmd.ExecuteNonQuery();

            //            sAutoID = sAutoID + 1;
            //        }
                    
            //    }
            //    #endregion

            //    //如果不在库
            //    for (int i = 0; i < split.Length; i++)
            //    {

            //    }
            //    cmd.CommandText = sc.InsertSql();
            //    cmd.ExecuteNonQuery();



            //    if (sErr != "")
            //    {
            //        throw new Exception(sErr);
            //    }
            //    trans.Commit();

            //}
            //catch (Exception ee)
            //{
            //    trans.Rollback();
            //    return "程序异常，请联系管理员" + ee.Message;
            //}
            //finally
            //{
            //    if (con.State == ConnectionState.Open)
            //    {
            //        con.Close();
            //    }
            //}
            return "保存成功";
        }
        #endregion

        #region 规格化
        public decimal ReturnDecimal(object o)
        {
            decimal d = 0;
            try
            {
                d = decimal.Round(Convert.ToDecimal(o), 6);
            }
            catch { }
            return d;
        }
        public decimal ReturnDecimal(object o, int iLength)
        {
            decimal d = 0;
            try
            {
                d = decimal.Round(Convert.ToDecimal(o), iLength);
            }
            catch { }
            return d;
        }


        public int ReturnInt(object o)
        {
            int d = 0;
            try
            {
                d = Convert.ToInt32(o);
            }
            catch { }
            return d;
        }

        public long ReturnLong(object o)
        {
            long d = 0;
            try
            {
                d = Convert.ToInt64(o);
            }
            catch { }
            return d;
        }

        public string ReturnDateTimeString(object o)
        {
            string d = "";
            try
            {
                if (Convert.ToDateTime(o) >= Convert.ToDateTime("1900-01-01"))
                {
                    d = Convert.ToDateTime(o).ToString("yyyy-MM-dd");
                }
            }
            catch { }
            return d;
        }
        #endregion
    }
}