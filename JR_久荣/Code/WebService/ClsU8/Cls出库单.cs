using System;
using System.Collections.Generic;
using System.Web;
using System.Data;
using System.Collections;
using System.Data.SqlClient;
using ClsBaseClass;

namespace ClsU8
{
    public class Cls出库单
    {
        public string dt发货计划(string cCode, string sQRCode,string iUsedAutoID)
        {
            string s = "";

            try
            {
                string sSQL = @"
select a.*,b.*,d.cInvName,d.cDefWareHouse,isnull(b.iDelQty,0)-isnull(rds.iQty,0) as leftQty ,cast(isnull(b.iBoxQty,0) - isnull(rds.iXS,0) as int) as leftXS
from ShipmentPlan a 
left join ShipmentPlans b on a.ID =b.ID left join Registers c on b.rID=c.ID 
    left join  @u8.Inventory d on b.InvCode=d.cInvCode
    left join (select sum(iQuantity) as iQty ,sum(cdefine35) as iXS,cDefine34 from @u8.Rdrecords where isnull(cDefine34,-1) <> -1 group by cDefine34) rds on rds.cDefine34 = b.autoid
where a.cCode = '" + cCode + "' and c.BarCode='" + sQRCode + "' and isnull(b.iDelQty,0)-isnull(rds.iQty,0)>0";
                if (iUsedAutoID != "")
                {
                    sSQL = sSQL + "and b.AutoID not in (" + iUsedAutoID + ")";
                }
                sSQL = sSQL + " order by b.AutoID";
                sSQL = sSQL.Replace("@u8.", ClsBaseDataInfo.sUFDataBaseName + ".dbo.");
                DataTable dt = ClsBaseClass.SqlHelper.ExecuteDataset(ClsBaseClass.ClsBaseDataInfo.sConnString, CommandType.Text, sSQL).Tables[0];
                s = ClsBaseClass.Cls序列化.SerializeDataTableXml(dt);
            }
            catch (Exception ee)
            {

            }
            return s;
        }

        public string chk发货计划(string sBarCode)
        {
            string s = "";

            try
            {
                string sSQL = "select count(1) from ShipmentPlan a where a.cCode = '" + sBarCode + "' ";
                s = ClsBaseClass.SqlHelper.ExecuteScalar(ClsBaseClass.ClsBaseDataInfo.sConnString, CommandType.Text, sSQL).ToString();
            }
            catch (Exception ee)
            {
                s = ee.Message;
            }
            return s;
        }

        public string Save出库单(DataTable dtData)
        {
            string s = "";
            try
            {
                string sErr = "";

                if (dtData == null || dtData.Rows.Count < 1)
                    throw new Exception("没有需要保存的数据");

                SqlConnection conn = new SqlConnection(ClsBaseClass.ClsBaseDataInfo.sConnString);
                conn.Open();
                //启用事务
                SqlTransaction tran = conn.BeginTransaction();

                try
                {
                    string sSQL = "select getdate()";
                    DateTime d当前服务器时间 = Convert.ToDateTime(SqlHelper.ExecuteScalar(tran, CommandType.Text, sSQL));

                    //1.   判断是否结账
                    sSQL = "select * from @u8.gl_mend where iperiod=month(getdate())";
                    sSQL = sSQL.Replace("@u8.", ClsBaseDataInfo.sUFDataBaseName + ".dbo.");
                    DataTable dtTemp = SqlHelper.ExecuteDataset(tran, CommandType.Text, sSQL).Tables[0];
                    if (dtTemp == null || dtTemp.Rows.Count < 1)
                    {
                        throw new Exception("判断模块结账失败");
                    }
                    int iR = ClsBaseDataInfo.ReturnObjectToInt(dtTemp.Rows[0]["bflag_ST"]);
                    if (iR == 1)
                    {
                        throw new Exception("当前月份已经结账");
                    }


                    //2. 获得单据ID
                    long lID = 1;
                    long lIDDetail = 1;
                    GetRdID(out lID, out lIDDetail, ClsBaseDataInfo.sUFDataBaseName.Substring(7, 3));


                    //3. 获得单据号
                    long iCode = 0;
                    sSQL = "select * From @u8.VoucherHistory  with (ROWLOCK) Where  CardNumber='0302'";
                    sSQL = sSQL.Replace("@u8.", ClsBaseDataInfo.sUFDataBaseName + ".dbo.");
                    dtTemp = SqlHelper.ExecuteDataset(tran, CommandType.Text, sSQL).Tables[0];
                    if (dtTemp == null || dtTemp.Rows.Count < 1)
                    {
                        iCode = 1;
                    }
                    else
                    {
                        iCode = ClsBaseDataInfo.ReturnObjectToLong(dtTemp.Rows[0]["cNumber"]);
                    }

                    //4. 组装表头
                    lID += 1;
                    string s仓库 = dtData.Rows[0]["仓库"].ToString().Trim();
                    string s订单号 = dtData.Rows[0]["单据号"].ToString().Trim();
                    
                    string s制单人 = dtData.Rows[0]["登记人"].ToString().Trim();

                    iCode += 1;
                    string s单据号 = sGetCode(iCode, 10, "");

                    Model.RdRecord model = new Model.RdRecord();
                    model.ID = lID;
                    model.bRdFlag = 0;
                    model.cVouchType = "09";
                    model.cBusType = "其他出库";
                    model.cSource = "库存";
                    model.cWhCode = s仓库;
                    model.dDate =DateTime.Parse(DateTime.Now.ToString("yyyy-MM-dd"));
                    model.cCode = s单据号;
                    model.cRdCode = "CK01";
                    //model.bTransFlag = 0;
                    model.cMaker = s制单人;
                    //model.bpufirst = 0;
                    //model.biafirst = 0;
                    model.iMQuantity = 0;
                    model.VT_ID = 9108;
                    //model.bIsSTQc = 0;

                    DAL.RdRecord dal = new DAL.RdRecord();
                    SqlHelper.ExecuteNonQuery(tran, CommandType.Text, dal.Add(model).Replace("@u8.", ClsBaseDataInfo.sUFDataBaseName + ".dbo."));

                    for (int i = 0; i < dtData.Rows.Count; i++)
                    {
                        string s存货编码 = dtData.Rows[i]["品番"].ToString().Trim();
                        string s批号 = "";
                        string s货位 = "";
                        string sAutoID = dtData.Rows[i]["单据子表序号"].ToString().Trim();
                        decimal d数量 = ClsBaseDataInfo.ReturnObjectToDecimal(dtData.Rows[i]["数量"], 6);
                        int i箱数 = ClsBaseDataInfo.ReturnObjectToInt(dtData.Rows[i]["箱数"]);
                        if (i箱数 == 0)
                        {
                            i箱数 = 1;
                        }

                        decimal d件数 = 0;
                        string cFree1 = "";
                        string cFree2 = "";
                        string cFree3 = "";
                        string cFree4 = "";
                        string cFree5 = "";
                        string cFree6 = "";
                        string cFree7 = "";
                        string cFree8 = "";
                        string cFree9 = "";
                        string cFree10 = "";

                        sSQL = "select * from @u8.Inventory where cInvCode = '" + s存货编码 + "'";
                        sSQL = sSQL.Replace("@u8.", ClsBaseDataInfo.sUFDataBaseName + ".dbo.");
                        DataTable dt存货信息 = SqlHelper.ExecuteDataset(tran, CommandType.Text, sSQL).Tables[0];
                        if (dt存货信息 == null || dt存货信息.Rows.Count < 1)
                        {
                            sErr = sErr + "存货编码:" + s存货编码 + "获得存货信息失败\n";
                            continue;
                        }

                        s货位 = dt存货信息.Rows[0]["cPosition"].ToString();

                        sSQL = @"select top 1 * from @u8.InvPosition where cWhCode = '" + s仓库
                            + "' and cInvCode = '" + s存货编码 + "' and cWhCode='" + s仓库 + "' and cPosCode='" + s货位 + "' order by iQuantity desc";
                        sSQL = sSQL.Replace("@u8.", ClsBaseDataInfo.sUFDataBaseName + ".dbo.");
                        DataTable dt现存量 = SqlHelper.ExecuteDataset(tran, CommandType.Text, sSQL).Tables[0];
                        if (dt现存量.Rows.Count == 0)
                        {
                            sErr = sErr + "存货编码:" + s存货编码 + ",无现存量\n";
                            continue;
                        }

                        decimal d现存数量 = ClsBaseDataInfo.ReturnObjectToDecimal(dt现存量.Rows[0]["iQuantity"], 6);
                        decimal d现存件数 = ClsBaseDataInfo.ReturnObjectToDecimal(dt现存量.Rows[0]["iNum"], 6);
                        if (d现存件数 != 0)
                        {
                            d件数 = ClsBaseDataInfo.ReturnObjectToDecimal(d数量 * d现存件数 / d现存数量, 6);
                        }

                        //string cPosition = dt现存量.Rows[0]["cPosCode"].ToString();
                        //组装表体
                        lIDDetail += 1;

                        Model.RdRecords models = new Model.RdRecords();
                        models.AutoID = lIDDetail;
                        models.ID = lID;
                        models.cInvCode = s存货编码;
                        models.iNum = d件数;
                        models.iQuantity = d数量;
                        models.iUnitCost = 0;
                        models.iFlag = 0;
                        models.iTax = 0;
                        models.iSQuantity = 0;
                        models.iSNum = 0;
                        models.iMoney = 0;
                        models.iSOutQuantity = 0;
                        models.iSOutNum = 0;
                        models.iFNum = 0;
                        models.iFQuantity = 0;
                        models.cPosition = s货位;
                        //models.cDefine22 = sAutoID;
                        models.cDefine34 = Convert.ToInt32(sAutoID);
                        models.cDefine35 = i箱数;

                        DAL.RdRecords dals = new DAL.RdRecords();
                        SqlHelper.ExecuteNonQuery(tran, CommandType.Text, dals.Add(models).Replace("@u8.", ClsBaseDataInfo.sUFDataBaseName + ".dbo."));


                        //仓库登记
                        sSQL = "if exists(select * from @u8.CurrentStock where cinvcode = '" + s存货编码 + "' and isnull(cBatch,'') = isnull('" + s批号 + "','')  and cWhCode = '" + s仓库
                           + "' and ISNULL(cFree1,'') = ISNULL(" + ClsBaseDataInfo.ReturnCol(cFree1)
                           + ",'') and ISNULL(cFree2,'') = ISNULL(" + ClsBaseDataInfo.ReturnCol(cFree1)
                           + ",'') and ISNULL(cFree3,'') = ISNULL(" + ClsBaseDataInfo.ReturnCol(cFree1)
                           + ",'') and ISNULL(cFree4,'') = ISNULL(" + ClsBaseDataInfo.ReturnCol(cFree1)
                           + ",'') and ISNULL(cFree5,'') = ISNULL(" + ClsBaseDataInfo.ReturnCol(cFree1)
                           + ",'') and ISNULL(cFree6,'') = ISNULL(" + ClsBaseDataInfo.ReturnCol(cFree1)
                           + ",'') and ISNULL(cFree7,'') = ISNULL(" + ClsBaseDataInfo.ReturnCol(cFree1)
                           + ",'') and ISNULL(cFree8,'') = ISNULL(" + ClsBaseDataInfo.ReturnCol(cFree1)
                           + ",'') and ISNULL(cFree9,'') = ISNULL(" + ClsBaseDataInfo.ReturnCol(cFree1)
                           + ",'') and ISNULL(cFree10,'') = ISNULL(" + ClsBaseDataInfo.ReturnCol(cFree1) + ",'') )" +
                           "    update @u8.CurrentStock set iQuantity = isnull(iQuantity,0) - " + ClsBaseDataInfo.ReturnCol(d数量) + ",iNum = isnull(iNum,0) - " + ClsBaseDataInfo.ReturnCol(d件数) + " " +
                           "    where cinvcode = '" + s存货编码 + "' and isnull(cBatch,'') = isnull(" + ClsBaseDataInfo.ReturnCol(s批号) + ",'') and cWhCode = '" + s仓库
                            + "' and ISNULL(cFree1,'') = ISNULL(" + ClsBaseDataInfo.ReturnCol(cFree1)
                            + ",'') and ISNULL(cFree2,'') = ISNULL(" + ClsBaseDataInfo.ReturnCol(cFree2)
                            + ",'') and ISNULL(cFree3,'') = ISNULL(" + ClsBaseDataInfo.ReturnCol(cFree3)
                            + ",'') and ISNULL(cFree4,'') = ISNULL(" + ClsBaseDataInfo.ReturnCol(cFree4)
                            + ",'') and ISNULL(cFree5,'') = ISNULL(" + ClsBaseDataInfo.ReturnCol(cFree5)
                            + ",'') and ISNULL(cFree6,'') = ISNULL(" + ClsBaseDataInfo.ReturnCol(cFree6)
                            + ",'') and ISNULL(cFree7,'') = ISNULL(" + ClsBaseDataInfo.ReturnCol(cFree7)
                            + ",'') and ISNULL(cFree8,'') = ISNULL(" + ClsBaseDataInfo.ReturnCol(cFree8)
                            + ",'') and ISNULL(cFree9,'') = ISNULL(" + ClsBaseDataInfo.ReturnCol(cFree9)
                            + ",'') and ISNULL(cFree10,'') = ISNULL(" + ClsBaseDataInfo.ReturnCol(cFree10) + ",'') " +
                           "else " +
                           "    insert into @u8.CurrentStock(cWhCode,cInvCode,cBatch,iQuantity,iNum,cFree1,cFree2,cFree3,cFree4,cFree5,cFree6,cFree7,cFree8,cFree9,cFree10)  " +
                           "    values('" + s仓库 + "', '" + s存货编码 + "'," + ClsBaseDataInfo.ReturnCol(s批号) + ",-" + ClsBaseDataInfo.ReturnCol(d数量) + ",-" + ClsBaseDataInfo.ReturnCol(d件数) 
                            + "," + ClsBaseDataInfo.ReturnCol(cFree1) 
                            + "," + ClsBaseDataInfo.ReturnCol(cFree2) 
                            + "," + ClsBaseDataInfo.ReturnCol(cFree3) 
                            + "," + ClsBaseDataInfo.ReturnCol(cFree4) 
                            + "," + ClsBaseDataInfo.ReturnCol(cFree5) 
                            + "," + ClsBaseDataInfo.ReturnCol(cFree6) 
                            + "," + ClsBaseDataInfo.ReturnCol(cFree7) 
                            + "," + ClsBaseDataInfo.ReturnCol(cFree8) 
                            + "," + ClsBaseDataInfo.ReturnCol(cFree9)
                            + "," + ClsBaseDataInfo.ReturnCol(cFree10) + ")";
                        sSQL = sSQL.Replace("@u8.", ClsBaseDataInfo.sUFDataBaseName + ".dbo.");
                        SqlHelper.ExecuteNonQuery(tran, CommandType.Text, sSQL);

                        //货位登记
                        sSQL = "insert into @u8.InvPosition( RdsID, RdID, cWhCode, cPosCode, cInvCode, cBatch, dVDate, iQuantity" +
                                ", iNum, cMemo, cHandler, dDate, bRdFlag, cSource, cAssUnit, cBVencode, iTrackId, dMadeDate, iMassDate" +
                                ",cFree1,cFree2,cFree3,cFree4,cFree5,cFree6,cFree7,cFree8,cFree9,cFree10) " +
                            "values(" + lIDDetail + "," + lID + ",'" + s仓库 + "','" + s货位 + "','" + s存货编码 + "',null,null," + ClsBaseDataInfo.ReturnCol(d数量) + " " +
                            "," + ClsBaseDataInfo.ReturnCol(d件数) + ",null,'" + s制单人 + "','" + d当前服务器时间.ToString("yyyy-MM-dd") + "',0,null"
                            + ",null,null,0,null,null" 
                            + ",null,null,null,null,null,null,null,null,null,null)";
                        sSQL = sSQL.Replace("@u8.", ClsBaseDataInfo.sUFDataBaseName + ".dbo.");
                        SqlHelper.ExecuteNonQuery(tran, CommandType.Text, sSQL);

                        
                    }
                    //7. 更新历史单据号表
                    sSQL = "update @u8.VoucherHistory set cNumber='" + iCode + "' Where  CardNumber='0302' and cContent is NULL";
                    sSQL = sSQL.Replace("@u8.", ClsBaseDataInfo.sUFDataBaseName + ".dbo.");
                    SqlHelper.ExecuteNonQuery(tran, CommandType.Text, sSQL);


                    //8. 更新单据ID号表
                    //string s1 = lID.ToString().Trim();
                    //string s2 = lIDDetail.ToString().Trim();
                    //s1 = s1.Substring(1);
                    //s2 = s2.Substring(1);
                    //lID = Convert.ToInt64(s1);
                    //lIDDetail = Convert.ToInt64(s2);
                    sSQL = "update  UFSystem..UA_Identity set iFatherID = " + lID + ",iChildID = " + lIDDetail + " where cAcc_Id = '" + ClsBaseDataInfo.sUFDataBaseName.Substring(7, 3) + "' and cVouchType = 'rd'";
                    SqlHelper.ExecuteNonQuery(tran, CommandType.Text, sSQL);

                    if (sErr.Trim().Length > 0)
                    {
                        throw new Exception(sErr);
                    }

                    tran.Commit();
                    s = "生成单据号：" + s单据号;
                }
                catch (Exception error)
                {
                    tran.Rollback();
                    throw new Exception(error.Message);
                }
            }
            catch (Exception ee)
            {
                s = ee.Message;
            }
            return s;
        }

        public void GetRdID(out long iID, out long iIDDetail, string sAccid)
        {
            string sSQL = @"
select MAX(id) as id,MAX(autoid) as autoid from @u8.rdrecords
            ";
            sSQL = sSQL.Replace("@u8.", ClsBaseDataInfo.sUFDataBaseName + ".dbo.");
            long l1 = 0;
            long l2 = 0;
            long l3 = 0;
            long l4 = 0;
            DataTable dt = ClsBaseClass.SqlHelper.ExecuteDataset(ClsBaseClass.ClsBaseDataInfo.sConnString, CommandType.Text, sSQL).Tables[0];
            if (dt != null && dt.Rows.Count > 0)
            {
                l1 = Convert.ToInt64(dt.Rows[0]["id"]);
                l2 = Convert.ToInt64(dt.Rows[0]["autoid"]);
            }

            sSQL = "select * from UFSystem..UA_Identity where cAcc_Id = '" + sAccid + "' and cVouchType = 'rd'";
            dt = ClsBaseClass.SqlHelper.ExecuteDataset(ClsBaseClass.ClsBaseDataInfo.sConnString, CommandType.Text, sSQL).Tables[0];
            if (dt != null && dt.Rows.Count > 0)
            {
                l3 = Convert.ToInt64(dt.Rows[0]["iFatherId"]);
                l4 = Convert.ToInt64(dt.Rows[0]["iChildId"]);
            }
            if (l1 > l3)
                iID = l1;
            else
                iID = l3;

            if (l2 > l4)
                iIDDetail = l2;
            else
                iIDDetail = l4;
        }

        /// <summary>
        /// 根据序号组装单据号
        /// </summary>
        /// <param name="l"></param>
        /// <param name="iLength"></param>
        /// <param name="s前缀"></param>
        /// <returns></returns>
        private string sGetCode(long l, int iLength, string s前缀)
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
    }
}
