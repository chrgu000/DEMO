using System;
using System.Collections.Generic;
using System.Web;
using System.Data;
using System.Collections;
using System.Data.SqlClient;
using ClsBaseClass;

namespace ClsU8
{
    public class Cls销售出库单
    {
//        public string Save销售出库单(DataTable dtData)
//        {
//            string s = "";
//            try
//            {
//                string sErr = "";

//                if (dtData == null || dtData.Rows.Count < 1)
//                    throw new Exception("没有需要保存的数据");

//                SqlConnection conn = new SqlConnection(ClsBaseClass.ClsBaseDataInfo.sConnString);
//                conn.Open();
//                //启用事务
//                SqlTransaction tran = conn.BeginTransaction();

//                try
//                {
//                    string sSQL = "select getdate()";
//                    DateTime d当前服务器时间 = Convert.ToDateTime(SqlHelper.ExecuteScalar(tran, CommandType.Text, sSQL));

//                    //1.  判断是否结账
//                    sSQL = "select * from gl_mend where iyear=year(getdate()) and iperiod=month(getdate())";
//                    DataTable dtTemp = SqlHelper.ExecuteDataset(tran, CommandType.Text, sSQL).Tables[0];
//                    if (dtTemp == null || dtTemp.Rows.Count < 1)
//                    {
//                        throw new Exception("判断模块结账失败");
//                    }
//                    int iR = ClsBaseDataInfo.ReturnObjectToInt(dtTemp.Rows[0]["bflag_ST"]);
//                    if (iR == 1)
//                    {
//                        throw new Exception("当前月份已经结账");
//                    }


//                    //2. 获得单据ID
//                    long lID = 1;
//                    long lIDDetail = 1;
//                    ClsU8基础档案 cls = new ClsU8基础档案();
//                    cls.GetRdID(out lID, out lIDDetail, ClsBaseDataInfo.sUFDataBaseName.Trim().Substring(7, 3));


//                    //3. 获得单据号
//                    long iCode = 0;
//                    sSQL = "select * From VoucherHistory  with (ROWLOCK) Where  CardNumber='0303'";
//                    dtTemp = SqlHelper.ExecuteDataset(tran, CommandType.Text, sSQL).Tables[0];
//                    if (dtTemp == null || dtTemp.Rows.Count < 1)
//                    {
//                        iCode = 1;
//                    }
//                    else
//                    {
//                        iCode = ClsBaseDataInfo.ReturnObjectToLong(dtTemp.Rows[0]["cNumber"]);
//                    }

//                    //4. 组装表头
//                    lID += 1;
//                    string s仓库 = dtData.Rows[0]["仓库"].ToString().Trim();
//                    string s订单号 = dtData.Rows[0]["单据号"].ToString().Trim();
//                    string s制单人 = dtData.Rows[0]["制单人"].ToString().Trim();
//                    //string s产量 = dt生产订单表头.Rows[0]["Qty"].ToString().Trim();
//                    //string s产品编码 = dt生产订单表头.Rows[0]["InvCode"].ToString().Trim();
//                    //string s生产订单主表标志 = dt生产订单表头.Rows[0]["MoId"].ToString().Trim();
//                    iCode += 1; 
//                    string s单据号 = sGetCode(iCode, 10);

//                    sSQL = "select * from DispatchList  where cDLCode  = '" + s订单号 + "' and isnull(bReturnFlag,0) = 0 ";
//                    DataTable dt发货单 = SqlHelper.ExecuteDataset(tran, CommandType.Text, sSQL).Tables[0];
//                    if (dt发货单 == null || dt发货单.Rows.Count < 1)
//                    {
//                        throw new Exception("获得发货单信息失败");
//                    }

//                    sSQL = "insert into rdrecord32(id,brdflag,cvouchtype,cbustype,csource,cbuscode,cwhcode,ddate,ccode,crdcode" +
//                                    ",cdepcode,cpersoncode,cstcode,ccuscode,cdlcode,cmaker,vt_id,iswfcontrolled,dnmaketime,dnmodifytime" +
//                                    ",dnverifytime,cDefine14) " +
//                           "values (N'" + lID + "',N'0',N'32',N'普通销售',N'发货单',N'" + s订单号 + "',N'" + s仓库 + "','" + d当前服务器时间.ToString("yyyy-MM-dd") + "',N'" + s单据号 + "',N'24'" +
//                                    ",N'" + dt发货单.Rows[0]["cDepCode"] + "',N'" + dt发货单.Rows[0]["cPersonCode"] + "',N'" + dt发货单.Rows[0]["cstcode"] + "',N'" + dt发货单.Rows[0]["cCusCode"] + "',N'" + dt发货单.Rows[0]["DLID"] + "',N'" + s制单人 + "',87,0, getdate(), Null " +
//                                    ", Null ,'Y')";
//                    SqlHelper.ExecuteNonQuery(tran, CommandType.Text, sSQL);

//                    for (int i = 0; i < dtData.Rows.Count; i++)
//                    {
//                        //判断条码是否已经使用
//                        sSQL = "select * from rdrecords32 where cdefine28 = " + ClsBaseDataInfo.ReturnCol(dtData.Rows[i]["条形码"].ToString()) + " ";
//                        int iCou = ClsBaseDataInfo.ReturnObjectToInt(SqlHelper.ExecuteScalar(tran, CommandType.Text, sSQL));
//                        if (iCou > 0)
//                        {
//                            sErr = sErr + "条形码:" + dtData.Rows[i]["条形码"].ToString() + "已经使用\n";
//                            continue;
//                        }

//                        sSQL = "select * from DispatchList a inner join DispatchLists b on a.DLID = b.DLID where cDLCode = '" + s订单号 + "' and isnull(a.bReturnFlag,0) = 0 and cinvcode = '" + dtData.Rows[i]["存货编码"].ToString().Trim() + "' and isnull(b.cFree1,'') = '" + dtData.Rows[i]["长度"].ToString().Trim() + "'";
//                        DataTable dt发货单信息 = SqlHelper.ExecuteDataset(tran, CommandType.Text, sSQL).Tables[0];
//                        if (dt发货单信息 == null || dt发货单信息.Rows.Count < 1)
//                        {
//                            sErr = sErr + "条形码:" + dtData.Rows[i]["条形码"].ToString() + "获得发货单信息失败\n";
//                            continue;
//                        }

//                        sSQL = "select * from Inventory where cInvCode = '" + dtData.Rows[i]["存货编码"].ToString().Trim() + "'";
//                        DataTable dt存货信息 = SqlHelper.ExecuteDataset(tran, CommandType.Text, sSQL).Tables[0];
//                        if (dt存货信息 == null || dt存货信息.Rows.Count < 1)
//                        {
//                            sErr = sErr + "条形码:" + dtData.Rows[i]["条形码"].ToString() + "获得存货信息失败\n";
//                            continue;
//                        }

//                        int i是否批次 = ClsBaseDataInfo.ReturnObjectToInt(dt存货信息.Rows[0]["bInvBatch"]);
//                        if (i是否批次 != 0 && dtData.Rows[i]["批号"].ToString().Trim() == "")
//                        {
//                            sErr = sErr + "条形码:" + dtData.Rows[i]["条形码"].ToString() + ":" + dtData.Rows[i]["存货编码"].ToString().Trim() + "是批次管理物料，必须输入批号\n";
//                            continue;
//                        }
//                        int i是否自由项1 = ClsBaseDataInfo.ReturnObjectToInt(dt存货信息.Rows[0]["bFree1"]);
//                        if (i是否自由项1 != 0 && dtData.Rows[i]["长度"].ToString().Trim() == "")
//                        {
//                            sErr = sErr + "条形码:" + dtData.Rows[i]["条形码"].ToString() + ":" + dtData.Rows[i]["存货编码"].ToString().Trim() + "必须输入长度\n";
//                            continue;
//                        }

//                        //组装表体
//                        sSQL = "select * from CurrentStock where cWhCode = '" + dtData.Rows[i]["仓库"].ToString().Trim() + "' and cInvCode = '" + dtData.Rows[i]["存货编码"].ToString().Trim() + "' and isnull(cBatch,'') = '" + dtData.Rows[i]["批号"].ToString().Trim() + "' and isnull(cFree1,'') = '" + dtData.Rows[i]["长度"].ToString().Trim() + "'   ";
//                        DataTable dt现存量 = SqlHelper.ExecuteDataset(tran, CommandType.Text, sSQL).Tables[0];

                   

//                        lIDDetail += 1;
//                        string s存货编码 = dtData.Rows[i]["存货编码"].ToString().Trim();
//                        decimal d数量 = ClsBaseDataInfo.ReturnObjectToDecimal(dtData.Rows[i]["数量"], 6);
//                        decimal d件数 = 0;

//                        decimal d现存数量 = ClsBaseDataInfo.ReturnObjectToDecimal(dt现存量.Rows[0]["iQuantity"], 6);
//                        decimal d现存件数 = ClsBaseDataInfo.ReturnObjectToDecimal(dt现存量.Rows[0]["iNum"], 6);

//                        decimal d发货单数量 = ClsBaseDataInfo.ReturnObjectToDecimal(dt发货单信息.Rows[0]["iQuantity"]);
//                        decimal d发货单件数 = ClsBaseDataInfo.ReturnObjectToDecimal(dt发货单信息.Rows[0]["iNum"]);
//                        //if (d发货单件数 > 0)
//                        //{
//                        //    d件数 = ClsBaseDataInfo.ReturnObjectToDecimal(d数量 * d发货单件数 / d发货单数量, 6);
//                        //}
//                        d件数 = 1;

//                        decimal d累计出库数量 = ClsBaseDataInfo.ReturnObjectToDecimal(dt发货单信息.Rows[0]["fOutQuantity"]);
//                        decimal d累计出库件数 = ClsBaseDataInfo.ReturnObjectToDecimal(dt发货单信息.Rows[0]["fOutNum"]);
//                        //if (d发货单数量 - d累计出库数量 < d数量)
//                        //{
//                        //    sErr = sErr + "条形码:" + dtData.Rows[i]["条形码"].ToString() + ":" + dtData.Rows[i]["存货编码"].ToString().Trim() + "超单据发货\n";
//                        //    continue;
//                        //}

//                        sSQL = "Insert Into rdrecords32(autoid,id,cinvcode,inum,iquantity,iunitcost,iprice,ipunitcost,ipprice,cbatch" +
//                                        ",cvouchcode,cinvouchcode,cinvouchtype,isoutquantity,isoutnum,coutvouchid,coutvouchtype,isredoutquantity,isredoutnum,cfree1" +
//                                        ",cfree2,dvdate,cposition,cdefine22,cdefine23,cdefine24,cdefine25,cdefine26,cdefine27,citem_class" +
//                                        ",citemcode,idlsid,isbsid,isendquantity,isendnum,iensid,cname,citemcname,cfree3,cfree4" +
//                                        ",cfree5,cfree6,cfree7,cfree8,cfree9,cfree10,cbarcode,inquantity,innum,cassunit" +
//                                        ",dmadedate,imassdate,cdefine28,cdefine29,cdefine30,cdefine31,cdefine32,cdefine33,cdefine34,cdefine35" +
//                                        ",cdefine36,cdefine37,icheckids,cbvencode,bgsp,cgspstate,cmassunit,irefundinspectflag,strcontractid,strcode" +
//                                        ",bchecked,cbaccounter,dbkeepdate,bcosting,bvmiused,ivmisettlequantity,ivmisettlenum,cvmivencode,iinvsncount,iinvexchrate" +
//                                        ",cbdlcode,corufts,strcontractguid,iexpiratdatecalcu,cexpirationdate,dexpirationdate,cciqbookcode,ibondedsumqty,ccusinvcode,ccusinvname" +
//                                        ",iorderdid,iordertype,iordercode,iorderseq,ipesodid,ipesotype,cpesocode,ipesoseq,isodid,isotype" +
//                                        ",csocode,isoseq,cbatchproperty1,cbatchproperty2,cbatchproperty3,cbatchproperty4,cbatchproperty5,cbatchproperty6,cbatchproperty7,cbatchproperty8" +
//                                        ",cbatchproperty9,cbatchproperty10,cbmemo,irowno,strowguid) " +
//                               "Values (" + lIDDetail + "," + lID + ",N'" + s存货编码 + "'," + d件数 + "," + d数量 + ",Null,Null,Null,Null,N'" + dtData.Rows[i]["批号"] + "'" +
//                                        ",Null,Null,Null,Null,Null,Null,Null,Null,Null,N'" + dtData.Rows[i]["长度"] + "'" +
//                                        ",Null,Null,N'" + dtData.Rows[i]["货位"].ToString() + "',null,'" + dt发货单信息.Rows[0]["cdefine23"].ToString().Trim() + "','" + dt发货单信息.Rows[0]["cdefine24"].ToString().Trim() + "','" + dt发货单信息.Rows[0]["cdefine25"].ToString().Trim() + "',Null,Null,Null" +
//                                        ",Null," + dt发货单信息.Rows[0]["iDLsID"] + ",Null,Null,Null,Null,Null,Null,Null,Null" +
//                                        ",Null,Null,Null,Null,Null,Null,Null," + dt发货单信息.Rows[0]["iQuantity"] + "," + dt发货单信息.Rows[0]["iNum"] + ",N'" + dt存货信息.Rows[0]["cAssComUnitCode"] + "'" +
//                                        ",Null,Null,'" + dtData.Rows[i]["条形码"].ToString() + "',Null,Null,Null,Null,Null,Null,Null" +
//                                        ",Null,Null,Null,Null,Null,Null,Null,Null,Null,Null" +
//                                        ",Null,Null,Null,1,0,Null,Null,Null,Null,0" +
//                                        ",N'" + dt发货单信息.Rows[0]["cDLCode"] + "',null,Null,0,Null,Null,Null,Null,Null,Null" +
//                                        "," + dt发货单信息.Rows[0]["iSOsID"] + ",'1',N'" + dt发货单信息.Rows[0]["cSOCode"] + "'," + dt发货单信息.Rows[0]["iorderrowno"] + ",N'" + dt发货单信息.Rows[0]["iSOsID"] + "',1,N'" + dt发货单信息.Rows[0]["cSOCode"] + "'," + dt发货单信息.Rows[0]["iorderrowno"] + ",Null,0" +
//                                        ",Null,Null,Null,Null,Null,Null,Null,Null,Null,Null" +
//                                        ",Null,Null,Null," + dt发货单信息.Rows[0]["irowno"] + ",Null)";
//                        SqlHelper.ExecuteNonQuery(tran, CommandType.Text, sSQL);

//                        //更新现存量
//                        sSQL = "select * from SCM_Item where cInvCode = '" + s存货编码 + "' and ISNULL(cFree1,'') = '" + dtData.Rows[i]["cFree1"].ToString().Trim() + "' and ISNULL(cFree2,'') = '" + dtData.Rows[i]["cFree2"].ToString().Trim() + "' and ISNULL(cFree3,'') = '" + dtData.Rows[i]["cFree3"].ToString().Trim() + "' and ISNULL(cFree4,'') = '" + dtData.Rows[i]["cFree4"].ToString().Trim() + "' and ISNULL(cFree5,'') = '" + dtData.Rows[i]["cFree5"].ToString().Trim() + "' and ISNULL(cFree6,'') = '" + dtData.Rows[i]["cFree6"].ToString().Trim() + "' and ISNULL(cFree7,'') = '" + dtData.Rows[i]["cFree7"].ToString().Trim() + "' and ISNULL(cFree8,'') = '" + dtData.Rows[i]["cFree8"].ToString().Trim() + "' and ISNULL(cFree9,'') = '" + dtData.Rows[i]["cFree9"].ToString().Trim() + "' and ISNULL(cFree10,'') = '" + dtData.Rows[i]["cFree10"].ToString().Trim() + "' ";
//                        DataTable dtTemp2 = SqlHelper.ExecuteDataset(tran, CommandType.Text, sSQL).Tables[0];
//                        long lItemID = 0;
//                        if (dtTemp2 == null || dtTemp2.Rows.Count == 0)
//                        {
//                            sSQL = "insert into SCM_Item(cInvCode,cFree1,cFree2,cFree3,cFree4,cFree5,cFree6,cFree7,cFree8,cFree9,cFree10,PartId) " +
//                                    "values('" + s存货编码 + "','" + ClsBaseDataInfo.ReturnCol(dtData.Rows[i]["cFree1"]) + "'," + ClsBaseDataInfo.ReturnCol(dtData.Rows[i]["cFree1"]) + "," + ClsBaseDataInfo.ReturnCol(dtData.Rows[i]["cFree2"]) + "," + ClsBaseDataInfo.ReturnCol(dtData.Rows[i]["cFree3"]) + "," + ClsBaseDataInfo.ReturnCol(dtData.Rows[i]["cFree4"]) + "," + ClsBaseDataInfo.ReturnCol(dtData.Rows[i]["cFree5"]) + "," + ClsBaseDataInfo.ReturnCol(dtData.Rows[i]["cFree6"]) + "," + ClsBaseDataInfo.ReturnCol(dtData.Rows[i]["cFree7"]) + "," + ClsBaseDataInfo.ReturnCol(dtData.Rows[i]["cFree8"]) + "," + ClsBaseDataInfo.ReturnCol(dtData.Rows[i]["cFree9"]) + "," + ClsBaseDataInfo.ReturnCol(dtData.Rows[i]["cFree10"]) + ",0)";
//                            SqlHelper.ExecuteNonQuery(tran, CommandType.Text, sSQL);

//                            sSQL = "select * from SCM_Item where cInvCode = '" + s存货编码 + "' and ISNULL(cFree1,'') = '" + dtData.Rows[i]["cFree1"].ToString().Trim() + "' and ISNULL(cFree2,'') = '" + dtData.Rows[i]["cFree2"].ToString().Trim() + "' and ISNULL(cFree3,'') = '" + dtData.Rows[i]["cFree3"].ToString().Trim() + "' and ISNULL(cFree4,'') = '" + dtData.Rows[i]["cFree4"].ToString().Trim() + "' and ISNULL(cFree5,'') = '" + dtData.Rows[i]["cFree5"].ToString().Trim() + "' and ISNULL(cFree6,'') = '" + dtData.Rows[i]["cFree6"].ToString().Trim() + "' and ISNULL(cFree7,'') = '" + dtData.Rows[i]["cFree7"].ToString().Trim() + "' and ISNULL(cFree8,'') = '" + dtData.Rows[i]["cFree8"].ToString().Trim() + "' and ISNULL(cFree9,'') = '" + dtData.Rows[i]["cFree9"].ToString().Trim() + "' and ISNULL(cFree10,'') = '" + dtData.Rows[i]["cFree10"].ToString().Trim() + "' ";
//                            dtTemp2 = SqlHelper.ExecuteDataset(tran, CommandType.Text, sSQL).Tables[0];
//                            lItemID = Convert.ToInt64(dtTemp2.Rows[0]["id"]);
//                        }
//                        else
//                        {
//                            lItemID = Convert.ToInt64(dtTemp2.Rows[0]["id"]);
//                        }

//                        sSQL = "declare @itmeid int " +
//                                    "select @itmeid = MAX(ItemId) + 1 from CurrentStock " +
//                                   "if exists(select * from CurrentStock where cinvcode = '" + s存货编码 + "' and isnull(cBatch,'') = isnull(" + ClsBaseDataInfo.ReturnCol(dtData.Rows[i]["批号"].ToString()) + ",'')  and cWhCode = '" + s仓库 + "' and ISNULL(cFree1,'') = '" + dtData.Rows[i]["cFree1"].ToString().Trim() + "' and ISNULL(cFree2,'') = '" + dtData.Rows[i]["cFree2"].ToString().Trim() + "' and ISNULL(cFree3,'') = '" + dtData.Rows[i]["cFree3"].ToString().Trim() + "' and ISNULL(cFree4,'') = '" + dtData.Rows[i]["cFree4"].ToString().Trim() + "' and ISNULL(cFree5,'') = '" + dtData.Rows[i]["cFree5"].ToString().Trim() + "' and ISNULL(cFree6,'') = '" + dtData.Rows[i]["cFree6"].ToString().Trim() + "' and ISNULL(cFree7,'') = '" + dtData.Rows[i]["cFree7"].ToString().Trim() + "' and ISNULL(cFree8,'') = '" + dtData.Rows[i]["cFree8"].ToString().Trim() + "' and ISNULL(cFree9,'') = '" + dtData.Rows[i]["cFree9"].ToString().Trim() + "' and ISNULL(cFree10,'') = '" + dtData.Rows[i]["cFree10"].ToString().Trim() + "') " +
//                                   "    update CurrentStock set iQuantity = isnull(iQuantity,0) + " + ClsBaseDataInfo.ReturnCol(d数量) + ",iNum = isnull(iNum,0) + " + ClsBaseDataInfo.ReturnCol(d件数) + " " +
//                                   "    where cinvcode = '" + s存货编码 + "' and isnull(cBatch,'') = isnull(" + ClsBaseDataInfo.ReturnCol(dtData.Rows[i]["批号"].ToString()) + ",'') and cWhCode = '" + s仓库 + "' and ISNULL(cFree1,'') = '" + dtData.Rows[i]["cFree1"].ToString().Trim() + "' and ISNULL(cFree2,'') = '" + dtData.Rows[i]["cFree2"].ToString().Trim() + "' and ISNULL(cFree3,'') = '" + dtData.Rows[i]["cFree3"].ToString().Trim() + "' and ISNULL(cFree4,'') = '" + dtData.Rows[i]["cFree4"].ToString().Trim() + "' and ISNULL(cFree5,'') = '" + dtData.Rows[i]["cFree5"].ToString().Trim() + "' and ISNULL(cFree6,'') = '" + dtData.Rows[i]["cFree6"].ToString().Trim() + "' and ISNULL(cFree7,'') = '" + dtData.Rows[i]["cFree7"].ToString().Trim() + "' and ISNULL(cFree8,'') = '" + dtData.Rows[i]["cFree8"].ToString().Trim() + "' and ISNULL(cFree9,'') = '" + dtData.Rows[i]["cFree9"].ToString().Trim() + "' and ISNULL(cFree10,'') = '" + dtData.Rows[i]["cFree10"].ToString().Trim() + "' " +
//                                   "else " +
//                                   "    insert into CurrentStock(cWhCode,cInvCode,cBatch,iSoType,iQuantity,iNum,ItemId,cFree1,cFree2,cFree3,cFree4,cFree5,cFree6,cFree7,cFree8,cFree9,cFree10)  " +
//                                   "    values('" + s仓库 + "', '" + s存货编码 + "'," + ClsBaseDataInfo.ReturnCol(dtData.Rows[i]["批号"].ToString()) + ",0,-" + ClsBaseDataInfo.ReturnCol(d数量) + ",-" + ClsBaseDataInfo.ReturnCol(d件数) + "," + lItemID + "," + ClsBaseDataInfo.ReturnCol(dtData.Rows[i]["cFree1"]) + "," + ClsBaseDataInfo.ReturnCol(dtData.Rows[i]["cFree2"]) + "," + ClsBaseDataInfo.ReturnCol(dtData.Rows[i]["cFree3"]) + "," + ClsBaseDataInfo.ReturnCol(dtData.Rows[i]["cFree4"]) + "," + ClsBaseDataInfo.ReturnCol(dtData.Rows[i]["cFree5"]) + "," + ClsBaseDataInfo.ReturnCol(dtData.Rows[i]["cFree6"]) + "," + ClsBaseDataInfo.ReturnCol(dtData.Rows[i]["cFree7"]) + "," + ClsBaseDataInfo.ReturnCol(dtData.Rows[i]["cFree8"]) + "," + ClsBaseDataInfo.ReturnCol(dtData.Rows[i]["cFree9"]) + "," + ClsBaseDataInfo.ReturnCol(dtData.Rows[i]["cFree10"]) + ")";
//                        SqlHelper.ExecuteNonQuery(tran, CommandType.Text, sSQL);

//                        for (int ii = 0; ii < dt发货单信息.Rows.Count; ii++)
//                        {
//                            decimal d累计出库 = ClsBaseDataInfo.ReturnObjectToDecimal(dt发货单信息.Rows[ii]["fOutQuantity"]);
//                            decimal d出库 = ClsBaseDataInfo.ReturnObjectToDecimal(dt发货单信息.Rows[ii]["iQuantity"]);

//                            if (d出库 > d累计出库 || ii == dt发货单信息.Rows.Count - 1)
//                            {
//                                sSQL = "update DispatchLists set fOutQuantity = isnull(fOutQuantity,0) + " + ClsBaseDataInfo.ReturnCol(d数量) + " ,fOutNum  = isnull(fOutNum ,0) + " + ClsBaseDataInfo.ReturnCol(d件数) + " " +
//                                       "where AutoID = " + ClsBaseDataInfo.ReturnCol(dt发货单信息.Rows[ii]["AutoID"].ToString());
//                                SqlHelper.ExecuteNonQuery(tran, CommandType.Text, sSQL);


//                                sSQL = "update DispatchLists set iQuantity = fOutQuantity,iNum  = fOutNum " +
//                                       "where AutoID = " + ClsBaseDataInfo.ReturnCol(dt发货单信息.Rows[ii]["AutoID"].ToString());
//                                SqlHelper.ExecuteNonQuery(tran, CommandType.Text, sSQL);

//                                sSQL = @"
//update DispatchLists set iSum = cast(iTaxUnitPrice*iquantity as decimal(16,2)) ,iNatSum = cast(iTaxUnitPrice*iExchRate*iquantity as decimal(16,2))
//	,iMoney = cast(iTaxUnitPrice*iExchRate*iquantity as decimal(16,2)),iNatMoney = cast(cast(iTaxUnitPrice*iExchRate *iquantity as decimal(16,2)) / (1 + a.iTaxRate/100) as decimal(16,2))
//	,iTax = cast(iTaxUnitPrice*iquantity as decimal(16,2)) -  cast(cast(iTaxUnitPrice * iquantity as decimal(16,2)) / (1 + a.iTaxRate/100) as decimal(16,2)) 
//	,iNatTax = cast(iTaxUnitPrice*iExchRate*iquantity as decimal(16,2)) - cast(cast(iTaxUnitPrice*iExchRate *iquantity as decimal(16,2)) / (1 + a.iTaxRate/100) as decimal(16,2))
//from DispatchList a 
//where a.DLID = DispatchLists.DLID  and DispatchLists.AutoID = 111111
//";

//                                sSQL = sSQL.Replace("111111", ClsBaseDataInfo.ReturnCol(dt发货单信息.Rows[ii]["AutoID"].ToString()));
//                                SqlHelper.ExecuteNonQuery(tran, CommandType.Text, sSQL);

//                                //如果不标记，销售出库单就不能手工删除，出现“此单据不是库存生成的，不能删除”的错误提示
//                                sSQL = "update DispatchList set cSaleOut = 'ST' where  cDLCode = '" + s订单号 + "'";
//                                SqlHelper.ExecuteNonQuery(tran, CommandType.Text, sSQL);

//                                break;
//                            }
//                        }


//                        //货位登记
//                        sSQL = "insert into InvPosition( RdsID, RdID, cWhCode, cPosCode, cInvCode, cBatch, cFree1, cFree2, dVDate, iQuantity" +
//                                    ", iNum, cMemo, cHandler, dDate, bRdFlag, cSource, cFree3, cFree4, cFree5, cFree6" +
//                                    ", cFree7, cFree8, cFree9, cFree10, cAssUnit, cBVencode, iTrackId,  dMadeDate, iMassDate" +
//                                    ", cMassUnit, cvmivencode, iExpiratDateCalcu, cExpirationdate, dExpirationdate, cvouchtype, cInVouchType, cVerifier, dVeriDate, dVouchDate) " +
//                                "values(" + lIDDetail + "," + lID + ",'" + s仓库 + "'," + ClsBaseDataInfo.ReturnCol(dtData.Rows[i]["货位"].ToString()) + ",'" + s存货编码 + "'," + ClsBaseDataInfo.ReturnCol(dtData.Rows[i]["批号"].ToString()) + "," + ClsBaseDataInfo.ReturnCol(dtData.Rows[i]["长度"].ToString()) + ",null,null," + ClsBaseDataInfo.ReturnCol(d数量) + " " +
//                                "," + ClsBaseDataInfo.ReturnCol(d件数) + ",null,'" + s制单人 + "','" + d当前服务器时间.ToString("yyyy-MM-dd") + "',0,null,null,null,null,null" +
//                                ",null,null,null,null," + ClsBaseDataInfo.ReturnCol(dt存货信息.Rows[0]["cAssComUnitCode"].ToString()) + ",null,0,null,null" +
//                                ",null,null,0,null,null,'32','',null,null,'" + d当前服务器时间.ToString("yyyy-MM-dd") + "')";
//                        SqlHelper.ExecuteNonQuery(tran, CommandType.Text, sSQL);

//                        sSQL = "if exists( select * from InvPositionSum where cInvCode = '" + s存货编码 + "' and cWhCode = '" + s仓库 + "' and cPosCode = " + ClsBaseDataInfo.ReturnCol(dtData.Rows[i]["货位"].ToString()) + " and ISNULL(cBatch,'') = '" + dtData.Rows[i]["批号"].ToString().Trim() + "' and isnull(cFree1,'') = '" + dtData.Rows[i]["长度"].ToString().Trim() + "') " +
//                            "   update InvPositionSum set iQuantity = iQuantity - " + ClsBaseDataInfo.ReturnCol(d数量) + ",iNum = iNum - " + ClsBaseDataInfo.ReturnCol(d件数) + " where cInvCode = '" + s存货编码 + "' and cWhCode = '" + s仓库 + "' and cPosCode = " + ClsBaseDataInfo.ReturnCol(dtData.Rows[i]["货位"].ToString()) + " and ISNULL(cBatch,'') = '" + dtData.Rows[i]["批号"].ToString().Trim() + "'  and isnull(cFree1,'') = '" + dtData.Rows[i]["长度"].ToString().ToString() + "' " +
//                            "else " +
//                            "insert InvPositionSum(cWhCode, cPosCode, cInvCode, iQuantity, inum, cBatch, cFree1, cFree2, cFree3" +
//                                " , cFree4, cFree5, cFree6, cFree7, cFree8, cFree9, cFree10, iTrackid, cvmivencode, cMassUnit" +
//                                ", iMassDate, dMadeDate, dVDate, iExpiratDateCalcu, cExpirationdate, dExpirationdate, cInVouchType) " +
//                            "values(  '" + s仓库 + "', " + ClsBaseDataInfo.ReturnCol(dtData.Rows[i]["货位"].ToString()) + ", '" + s存货编码 + "',  -1 * " + ClsBaseDataInfo.ReturnCol(d数量) + ",  -1 * isnull(" + ClsBaseDataInfo.ReturnCol(d件数) + ",0), " + ClsBaseDataInfo.ReturnCol(dtData.Rows[i]["批号"].ToString()) + ", " + ClsBaseDataInfo.ReturnCol(dtData.Rows[i]["长度"].ToString()) + ", null, null" +
//                                " , null, null, null, null, null, null, null, 0, null, null" +
//                                ", null, null, null, 0, null, null, '32')";
//                        SqlHelper.ExecuteNonQuery(tran, CommandType.Text, sSQL);
//                    }

//                    //7. 更新历史单据号表
//                    sSQL = "update VoucherHistory set cNumber='" + iCode + "' Where  CardNumber='0303' and cContent is NULL";
//                    SqlHelper.ExecuteNonQuery(tran, CommandType.Text, sSQL);


//                    //8. 更新单据ID号表
//                    string s1 = lID.ToString().Trim();
//                    string s2 = lIDDetail.ToString().Trim();
//                    s1 = s1.Substring(1);
//                    s2 = s2.Substring(1);
//                    lID = Convert.ToInt64(s1);
//                    lIDDetail = Convert.ToInt64(s2);
//                    sSQL = "update  UFSystem..UA_Identity set iFatherID = " + lID + ",iChildID = " + lIDDetail + " where cAcc_Id = '" + ClsBaseDataInfo.sUFDataBaseName.Trim().Substring(7, 3) + "' and cVouchType = 'rd'";
//                    SqlHelper.ExecuteNonQuery(tran, CommandType.Text, sSQL);

//                    if (sErr.Trim().Length > 0)
//                    {
//                        throw new Exception(sErr);
//                    }

//                    tran.Commit();
//                    s = "生成单据号：" + s单据号;
//                }
//                catch (Exception error)
//                {
//                    tran.Rollback();
//                    throw new Exception(error.Message);
//                }
//            }
//            catch (Exception ee)
//            {
//                s = ee.Message;
//            }
//            return s;
//        }

        /// <summary>
        /// 根据序号组装单据号
        /// </summary>
        /// <param name="l"></param>
        /// <param name="iLength"></param>
        /// <returns></returns>
        private string sGetCode(long l, int iLength)
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
            return sCode;
        }

        public string Chk销售出库条码是否已经使用(string sBarCode)
        {
            string s = "";

            try
            {
                string sSQL = "select count(1) from rdrecords11 where isnull(cDefine22 ,'') = '" + sBarCode + "'";
                s = ClsBaseClass.SqlHelper.ExecuteScalar(ClsBaseClass.ClsBaseDataInfo.sConnString, CommandType.Text, sSQL).ToString();
            }
            catch (Exception ee)
            {
                s = ee.Message;
            }
            return s;
        }

        public string dt销售出库条码信息(string sBarCode, string sCode)
        {
            string s = "";
            try
            {
                string sSQL = @"
select a.*, b.cInvName,b.cInvStd,b.bInvBatch,e.iQuantity,e.iNum,e.未发数量 ,e.未发件数
from 条形码信息 a inner join Inventory b on a.存货编码 = b.cInvCode 	
	inner join (
					select b.cInvCode as 子件编码, b.iQuantity,b.iNum, b.iQuantity - isnull(b.fOutQuantity ,0) as 未发数量,b.inum - isnull(b.fOutNum ,0) as 未发件数,b.cfree1 as 长度
                    from DispatchList  a inner join DispatchLists  b on a.DLID   = b.DLID  
                    where a.cDLCode  = '111111'
				) e on e.子件编码 = a.存货编码 and ISNULL(a.长度,'') = isnull(e.长度,'')
where a.条形码  = '333333'
";

                sSQL = sSQL.Replace("111111", sCode);
                sSQL = sSQL.Replace("333333", sBarCode);

                DataTable dt = SqlHelper.ExecuteDataset(ClsBaseDataInfo.sConnString, CommandType.Text, sSQL).Tables[0];
                s = Cls序列化.SerializeDataTableXml(dt);
            }
            catch (Exception ee)
            {
                s = "0" + ee.Message;
            }
            return s;
        }
    }
}
