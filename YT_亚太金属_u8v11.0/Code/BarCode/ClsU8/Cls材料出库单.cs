using System;
using System.Collections.Generic;
using System.Web;
using System.Data;
using System.Collections;
using System.Data.SqlClient;
using ClsBaseClass;

namespace ClsU8
{
    public class Cls材料出库单
    {
        public string Save材料出库单(DataTable dtData, string iRowNo)
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
                    sSQL = "select * from gl_mend where iyear=year(getdate()) and iperiod=month(getdate())";
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
                    ClsU8基础档案 cls = new ClsU8基础档案();
                    cls.GetRdID(out lID, out lIDDetail, ClsBaseDataInfo.sUFDataBaseName.Trim().Substring(7, 3));


                    //3. 获得单据号
                    long iCode = 0;
                    sSQL = "select * From VoucherHistory  with (ROWLOCK) Where  CardNumber='0412'";
                    dtTemp = SqlHelper.ExecuteDataset(tran, CommandType.Text, sSQL).Tables[0];
                    if (dtTemp == null || dtTemp.Rows.Count < 1)
                    {
                        iCode = 1;
                    }
                    else
                    {
                        iCode = ClsBaseDataInfo.ReturnObjectToLong(dtTemp.Rows[0]["cNumber"]);
                    }

                    sSQL = "select * from mom_order a inner join mom_orderdetail b on a.moid = b.moid where a.mocode = '" + dtData.Rows[0]["单据号"].ToString().Trim() + "' ";
                    DataTable dt生产订单表头 = SqlHelper.ExecuteDataset(tran, CommandType.Text, sSQL).Tables[0];
                    if (dt生产订单表头 == null || dt生产订单表头.Rows.Count < 1)
                    {
                        throw new Exception("获得生产订单信息失败");
                    }

                    //4. 组装表头
                    lID += 1;
                    string s仓库 = dtData.Rows[0]["仓库"].ToString().Trim();
                    string s订单号 = dtData.Rows[0]["单据号"].ToString().Trim();
                    //string s行号 = dtData.Rows[0]["行号"].ToString().Trim();
                    string s制单人 = dtData.Rows[0]["制单人"].ToString().Trim();
                    string s产量 = dt生产订单表头.Rows[0]["Qty"].ToString().Trim();
                    string s产品编码 = dt生产订单表头.Rows[0]["InvCode"].ToString().Trim();
                    string s生产订单主表标志 = dt生产订单表头.Rows[0]["MoId"].ToString().Trim();

                    sSQL = @"select b.MoDId,b.SortSeq,c.InvCode as 子件编码, c.qty,c.issQty,c.Qty - isnull(c.issQty,0) as 未领数量
                    from mom_order a inner join mom_orderdetail b on a.moid = b.moid inner join mom_moallocate c on c.MoDId  = b.Modid 
                    where a.mocode = '" + s订单号 + "' and b.SortSeq IN (222222) and c.Qty - isnull(c.issQty,0)>0 order by b.SortSeq";
                    sSQL = sSQL.Replace("222222", iRowNo);
                    DataTable dt未出库 = SqlHelper.ExecuteDataset(tran, CommandType.Text, sSQL).Tables[0];
                    iCode += 1;
                    string s单据号 = sGetCode(iCode, 4, "CLCK04" + d当前服务器时间.ToString("yyMM"));

                    string vtid = "31122";
                    sSQL = " insert into rdrecord11(id,brdflag,cvouchtype,cbustype,csource,cwhcode,ddate,ccode,crdcode,cdepcode " +
                                 ",cmaker,imquantity,vt_id,cpspcode,cmpocode,iproorderid,bomfirst,biscomplement,iswfcontrolled,dnmaketime " +
                                 ",dnmodifytime,dnverifytime,bmotran,cdefine1,cDefine14)  " +
                             "values (N'" + lID + "',N'0',N'11',N'领料',N'生产订单',N'" + s仓库 + "','" + d当前服务器时间.ToString("yyyy-MM-dd") + "',N'" + s单据号 + "',N'202',N'04' " +
                                 ",N'" + s制单人 + "'," + s产量 + "," + vtid + ",N'" + s产品编码 + "',N'" + s订单号 + "'," + s生产订单主表标志 + ",0,0,0, getdate()" +
                                 ", Null , Null ,N'0','" + s订单号 + "','Y' )";
                    SqlHelper.ExecuteNonQuery(tran, CommandType.Text, sSQL);

                    for (int i = 0; i < dtData.Rows.Count; i++)
                    {
                        string s存货编码 = dtData.Rows[i]["存货编码"].ToString().Trim();
                        decimal d数量 = ClsBaseDataInfo.ReturnObjectToDecimal(dtData.Rows[i]["数量"], 6);
                        decimal d件数 = 0;

                        #region 存货自由项
                        sSQL = "select * from Inventory where cInvCode = '" + dtData.Rows[i]["存货编码"].ToString().Trim() + "'";
                        DataTable dt存货信息 = SqlHelper.ExecuteDataset(tran, CommandType.Text, sSQL).Tables[0];
                        if (dt存货信息 == null || dt存货信息.Rows.Count < 1)
                        {
                            sErr = sErr + "条形码:" + dtData.Rows[i]["条形码"].ToString() + "获得存货信息失败\n";
                            continue;
                        }

                        int i是否批次 = ClsBaseDataInfo.ReturnObjectToInt(dt存货信息.Rows[0]["bInvBatch"]);
                        if (i是否批次 != 0 && dtData.Rows[i]["批号"].ToString().Trim() == "")
                        {
                            sErr = sErr + "条形码:" + dtData.Rows[i]["条形码"].ToString() + ":" + dtData.Rows[i]["存货编码"].ToString().Trim() + "是批次管理物料，必须输入批号\n";
                            continue;
                        }
                        int i是否自由项1 = ClsBaseDataInfo.ReturnObjectToInt(dt存货信息.Rows[0]["bFree1"]);
                        if (i是否自由项1 != 0 && dtData.Rows[i]["cFree1"].ToString().Trim() == "")
                        {
                            sErr = sErr + "条形码:" + dtData.Rows[i]["条形码"].ToString() + ":" + dtData.Rows[i]["存货编码"].ToString().Trim() + "必须输入自由项1\n";
                            continue;
                        }

                        int i是否自由项2 = ClsBaseDataInfo.ReturnObjectToInt(dt存货信息.Rows[0]["bFree2"]);
                        if (i是否自由项2 != 0 && dtData.Rows[i]["cFree2"].ToString().Trim() == "")
                        {
                            sErr = sErr + "条形码:" + dtData.Rows[i]["条形码"].ToString() + ":" + dtData.Rows[i]["存货编码"].ToString().Trim() + "必须输入自由项2\n";
                            continue;
                        }
                        int i是否自由项3 = ClsBaseDataInfo.ReturnObjectToInt(dt存货信息.Rows[0]["bFree3"]);
                        if (i是否自由项3 != 0 && dtData.Rows[i]["cFree3"].ToString().Trim() == "")
                        {
                            sErr = sErr + "条形码:" + dtData.Rows[i]["条形码"].ToString() + ":" + dtData.Rows[i]["存货编码"].ToString().Trim() + "必须输入自由项3\n";
                            continue;
                        }
                        int i是否自由项4 = ClsBaseDataInfo.ReturnObjectToInt(dt存货信息.Rows[0]["bFree4"]);
                        if (i是否自由项4 != 0 && dtData.Rows[i]["cFree4"].ToString().Trim() == "")
                        {
                            sErr = sErr + "条形码:" + dtData.Rows[i]["条形码"].ToString() + ":" + dtData.Rows[i]["存货编码"].ToString().Trim() + "必须输入自由项4\n";
                            continue;
                        }
                        int i是否自由项5 = ClsBaseDataInfo.ReturnObjectToInt(dt存货信息.Rows[0]["bFree5"]);
                        if (i是否自由项5 != 0 && dtData.Rows[i]["cFree5"].ToString().Trim() == "")
                        {
                            sErr = sErr + "条形码:" + dtData.Rows[i]["条形码"].ToString() + ":" + dtData.Rows[i]["存货编码"].ToString().Trim() + "必须输入自由项5\n";
                            continue;
                        }
                        int i是否自由项6 = ClsBaseDataInfo.ReturnObjectToInt(dt存货信息.Rows[0]["bFree6"]);
                        if (i是否自由项6 != 0 && dtData.Rows[i]["cFree6"].ToString().Trim() == "")
                        {
                            sErr = sErr + "条形码:" + dtData.Rows[i]["条形码"].ToString() + ":" + dtData.Rows[i]["存货编码"].ToString().Trim() + "必须输入自由项6\n";
                            continue;
                        }
                        int i是否自由项7 = ClsBaseDataInfo.ReturnObjectToInt(dt存货信息.Rows[0]["bFree7"]);
                        if (i是否自由项7 != 0 && dtData.Rows[i]["cFree7"].ToString().Trim() == "")
                        {
                            sErr = sErr + "条形码:" + dtData.Rows[i]["条形码"].ToString() + ":" + dtData.Rows[i]["存货编码"].ToString().Trim() + "必须输入自由项7\n";
                            continue;
                        }
                        int i是否自由项8 = ClsBaseDataInfo.ReturnObjectToInt(dt存货信息.Rows[0]["bFree8"]);
                        if (i是否自由项8 != 0 && dtData.Rows[i]["cFree8"].ToString().Trim() == "")
                        {
                            sErr = sErr + "条形码:" + dtData.Rows[i]["条形码"].ToString() + ":" + dtData.Rows[i]["存货编码"].ToString().Trim() + "必须输入自由项8\n";
                            continue;
                        }
                        int i是否自由项9 = ClsBaseDataInfo.ReturnObjectToInt(dt存货信息.Rows[0]["bFree9"]);
                        if (i是否自由项9 != 0 && dtData.Rows[i]["cFree9"].ToString().Trim() == "")
                        {
                            sErr = sErr + "条形码:" + dtData.Rows[i]["条形码"].ToString() + ":" + dtData.Rows[i]["存货编码"].ToString().Trim() + "必须输入自由项9\n";
                            continue;
                        }
                        int i是否自由项10 = ClsBaseDataInfo.ReturnObjectToInt(dt存货信息.Rows[0]["bFree10"]);
                        if (i是否自由项10 != 0 && dtData.Rows[i]["cFree10"].ToString().Trim() == "")
                        {
                            sErr = sErr + "条形码:" + dtData.Rows[i]["条形码"].ToString() + ":" + dtData.Rows[i]["存货编码"].ToString().Trim() + "必须输入自由项10\n";
                            continue;
                        }
                        #endregion

                        sSQL = @"select * from CurrentStock where cWhCode = '" + dtData.Rows[i]["仓库"].ToString().Trim() + "' and cInvCode = '" + dtData.Rows[i]["存货编码"].ToString().Trim() + "' "
                        + "and isnull(cBatch,'') = '" + dtData.Rows[i]["批号"].ToString().Trim() + "' and isnull(cFree1,'') = '" + dtData.Rows[i]["cFree1"].ToString().Trim() + "'  and isnull(cFree2,'') = '" + dtData.Rows[i]["cFree2"].ToString().Trim() + "' and isnull(cFree3,'') = '" + dtData.Rows[i]["cFree3"].ToString().Trim() + "' and isnull(cFree4,'') = '" + dtData.Rows[i]["cFree4"].ToString().Trim() + "' and isnull(cFree5,'') = '" + dtData.Rows[i]["cFree5"].ToString().Trim() + "' "
                        + " and isnull(cFree6,'') = '" + dtData.Rows[i]["cFree6"].ToString().Trim() + "'  and isnull(cFree7,'') = '" + dtData.Rows[i]["cFree7"].ToString().Trim() + "' and isnull(cFree8,'') = '" + dtData.Rows[i]["cFree8"].ToString().Trim() + "' and isnull(cFree9,'') = '" + dtData.Rows[i]["cFree9"].ToString().Trim() + "' and isnull(cFree10,'') = '" + dtData.Rows[i]["cFree10"].ToString().Trim() + "' ";
                        DataTable dt现存量 = SqlHelper.ExecuteDataset(tran, CommandType.Text, sSQL).Tables[0];
                        if (dt现存量.Rows.Count == 0)
                        {
                            sErr = sErr + "条形码:" + dtData.Rows[i]["条形码"].ToString() + ":无现存量\n";
                            continue;
                        }

                        decimal d现存数量 = ClsBaseDataInfo.ReturnObjectToDecimal(dt现存量.Rows[0]["iQuantity"], 6);
                        decimal d现存件数 = ClsBaseDataInfo.ReturnObjectToDecimal(dt现存量.Rows[0]["iNum"], 6);
                        if (d现存件数 > 0)
                        {
                            if (d数量 == d现存数量)
                                d件数 = d现存件数;
                            else
                                d件数 = ClsBaseDataInfo.ReturnObjectToDecimal(d数量 * d现存件数 / d现存数量, 6);
                        }

                        for (int j = 0; j < dt未出库.Rows.Count; j++)
                        {
                            if (d数量 > 0 && ClsBaseDataInfo.ReturnObjectToDecimal(dt未出库.Rows[j]["未领数量"], 6) > 0 && dt未出库.Rows[j]["子件编码"].ToString().Trim() == s存货编码)
                            {
                                string s行号 = dt未出库.Rows[j]["SortSeq"].ToString();

                                sSQL = @"select a.moid, b.MoDId ,c.AllocateId ,c.InvCode ,c.Qty ,c.IssQty,b.OrderDId  from mom_order a inner join mom_orderdetail b on a.moid = b.moid inner join mom_moallocate c on c.MoDId  = b.Modid 
where a.mocode = '" + s订单号 + "' and b.SortSeq = '" + s行号 + "' and c.InvCode = '" + s存货编码 + "' ";//and isnull(LotNo,'') = '" + dtData.Rows[i]["批号"].ToString().Trim() + "'
                                DataTable dt生产订单信息 = SqlHelper.ExecuteDataset(tran, CommandType.Text, sSQL).Tables[0];
                                if (dt生产订单信息 == null || dt生产订单信息.Rows.Count < 1)
                                {
                                    sErr = sErr + "条形码:" + dtData.Rows[i]["条形码"].ToString() + "获得生产订单材料信息失败，请核实材料或批号是否匹配\n";
                                    continue;
                                }

                                

                                //组装表体

                                lIDDetail += 1;


                                decimal d生产订单子件数量 = ClsBaseDataInfo.ReturnObjectToDecimal(dt生产订单信息.Rows[0]["Qty"], 6);
                                decimal d生产订单子件已领数量 = ClsBaseDataInfo.ReturnObjectToDecimal(dt生产订单信息.Rows[0]["IssQty"], 6);
                                decimal d生产订单待领数量 = d生产订单子件数量 - d生产订单子件已领数量;

                                //if (d生产订单待领数量 < d数量)
                                //{
                                //    sErr = sErr + "条形码:" + dtData.Rows[i]["条形码"].ToString() + ":" + dtData.Rows[i]["存货编码"].ToString().Trim() + "超订单领料\n";
                                //    continue;
                                //}
                                

                                string iTrackid = "";
                                string ccode = "";
//                                sSQL = @" --select rdid,cvouchtype into #a  from mainbatch with (nolock) where cinvcode=N'1111111111' and cwhcode =N'2222222222'  and isotype=0 and isodid =N''
//  select '' as selcol,cposcode,cposname,cwhcode,cwhname,iquantity,inum,iinvexchrate,ioutquantity,ioutnum,cfree1,cfree2,cfree3,cfree4,cfree5,cfree6,cfree7,cfree8,cfree9,cfree10,cbatch,dmadedate,cmassunit,imassdate,dvdate,iTrackid,cInVouchType,cvmivencode,cvmivenname,iExpiratDateCalcu,cExpirationdate,dExpirationdate,cbatchproperty1,cbatchproperty2,cbatchproperty3,cbatchproperty4,cbatchproperty5,cbatchproperty6,cbatchproperty7,cbatchproperty8,cbatchproperty9,cbatchproperty10 from 
//(select '' as selcol,Inv.cWhCode,w.cwhname,Inv.cPosCode,p.cposname,Inv.iQuantity,convert(decimal(38,6),case when i.igrouptype=1 and isnull(c.iChangRate,0)<>0 then Inv.iQuantity/c.iChangRate else Inv.inum end) as inum,
//convert(decimal(38,6),case when i.igrouptype=0 then 0 when i.igrouptype=1 then ( case when isnull(c.iChangRate,0)<>0 then c.iChangRate else null end ) else (case when isnull(inv.inum,0)=0 then null else Inv.iQuantity/Inv.inum end) end) as iinvexchrate,convert(decimal(38,6),0) as ioutquantity,
//convert(decimal(38,6),0) as ioutnum,Inv.cBatch,Inv.cFree1,Inv.cFree2,Inv.cFree3,Inv.cFree4,Inv.cFree5,Inv.cFree6,Inv.cFree7,
//Inv.cFree8,Inv.cFree9,Inv.cFree10,Inv.cMassUnit,Inv.iMassDate,Inv.dMadeDate,Inv.dVDate,Inv.iTrackid,Inv.cInVouchType,Inv.cvmivencode,v.cvenname as cvmivenname,Inv.iExpiratDateCalcu,Inv.cExpirationdate,Inv.dExpirationdate,
// a.cbatchproperty1,a.cbatchproperty2,a.cbatchproperty3,a.cbatchproperty4,a.cbatchproperty5,a.cbatchproperty6,a.cbatchproperty7,a.cbatchproperty8,a.cbatchproperty9,a.cbatchproperty10,isnull(Invpos.iprior,20000) as iprior  from invpositionsum Inv inner join Inventory I on Inv.cinvcode=I.cinvcode inner join warehouse W on inv.cwhcode=w.cwhcode left join invposcontrapose Invpos on Inv.cposcode=Invpos.cposcode and Invpos.cinvcode=Inv.cinvcode left join Position p on p.cposcode=Inv.cposcode 
// left join Vendor V on inv.cvmivencode=v.cvencode 
// left join ComputationUnit c on i.cstcomunitcode=c.cComunitCode and i.igrouptype=1 
// left join aa_batchproperty a on a.cinvcode=Inv.cinvcode and a.cbatch=inv.cbatch and a.cfree1=inv.cfree1 and  a.cfree2=inv.cfree2 and a.cfree3=inv.cfree3 and a.cfree4=inv.cfree4 and a.cfree5=inv.cfree5 and
//a.cfree6=inv.cfree6 and a.cfree7=inv.cfree7 and a.cfree8=inv.cfree8 and a.cfree9=inv.cfree9 and a.cfree10=inv.cfree10 where Inv.cinvcode=N'1111111111' and Inv.cwhcode=N'2222222222' and (inv.iquantity>0 or (i.igrouptype =2 and inv.inum>0) )  
//--and iTrackid in (select rdid from #a)
//-- and cinvouchtype in (select cvouchtype from #a)
//) as T  order by iquantity,T.iprior ";
//                                sSQL = sSQL.Replace("1111111111", s存货编码);
//                                sSQL = sSQL.Replace("2222222222", s仓库);
//                                DataTable dtin = SqlHelper.ExecuteDataset(tran, CommandType.Text, sSQL).Tables[0];
//                                decimal d入库数量 = 0;
//                                string cInVouchType = "";
//                                decimal d入库件数 = 0;
//                                
//                                if (dtin == null || dtin.Rows.Count == 0)
//                                {
//                                    //sErr = sErr + "行" + (i + 1).ToString() + "未找到相关入库单\n";
//                                    //continue;
//                                }
//                                else
//                                {
//                                    d入库数量 = ClsBaseDataInfo.ReturnObjectToDecimal(dtin.Rows[0]["iquantity"], 6);
//                                    if (d数量 > d入库数量)
//                                    {
//                                        sErr = sErr + "行" + (i + 1).ToString() + "入库单数量不足\n";
//                                        continue;
//                                    }
//                                    cInVouchType = dtin.Rows[0]["cInVouchType"].ToString().Trim();
//                                    d入库件数 = ClsBaseDataInfo.ReturnObjectToDecimal(dtin.Rows[0]["inum"], 6);
//                                    iTrackid = dtin.Rows[0]["iTrackid"].ToString().Trim();
//                                }

//                                //得到入库单据号
//                                
//                                sSQL = @"select * from (
//select cCode,autoid,cinvouchtype  from dbo.rdrecord01 a left join dbo.rdrecords01 b on a.id=b.id
//union all
//select cCode,autoid,cinvouchtype  from dbo.rdrecord08 a left join dbo.rdrecords08 b on a.id=b.id
//union all
//select cCode,autoid,cinvouchtype  from dbo.rdrecord09 a left join dbo.rdrecords09 b on a.id=b.id
//union all
//select cCode,autoid,cinvouchtype  from dbo.rdrecord10 a left join dbo.rdrecords10 b on a.id=b.id
//union all
//select cCode,autoid,cinvouchtype  from dbo.rdrecord11 a left join dbo.rdrecords11 b on a.id=b.id
//union all
//select cCode,autoid,cinvouchtype  from dbo.rdrecord32 a left join dbo.rdrecords32 b on a.id=b.id
//union all
//select cCode,autoid,cinvouchtype  from dbo.rdrecord34 a left join dbo.rdrecords34 b on a.id=b.id
//) a where autoid='" + iTrackid + "' and cinvouchtype='" + cInVouchType + "'";
//                                DataTable dtrd = SqlHelper.ExecuteDataset(tran, CommandType.Text, sSQL).Tables[0];
//                                if (dtrd.Rows.Count > 0)
//                                {
//                                    ccode = dtrd.Rows[0]["cCode"].ToString().Trim();
//                                }
//                                else
//                                {
//                                    //sErr = sErr + "行" + (i + 1).ToString() + "未找到相关入库单\n";
//                                }
                                decimal d领料数量 = 0;
                                decimal d领料件数 = 0;
                                if (d生产订单待领数量 < d数量)
                                {
                                    d领料数量 = d生产订单待领数量;
                                }
                                else
                                {
                                    d领料数量 = d数量;
                                }
                                d领料件数 = ClsBaseDataInfo.ReturnObjectToDecimal(d领料数量 * d现存件数 / d现存数量, 6);
                                d数量 = d数量 - d领料数量;
                                d件数 = d件数 - d领料件数;
                                decimal iUnitCost = ClsBaseDataInfo.ReturnObjectToDecimal(s行号, 6);
                                decimal iPrice = iUnitCost * d领料数量;
                                sSQL = "Insert Into rdrecords11(autoid,id,cinvcode,inum,iquantity,iunitcost,iprice,ipunitcost,ipprice,cbatch " +
                                        "	,cobjcode,cvouchcode,cinvouchcode,cinvouchtype,isoutquantity,isoutnum,coutvouchid,coutvouchtype,isredoutquantity,isredoutnum " +
                                        "	,cfree1,cfree2,isquantity,ifnum,ifquantity,dvdate,itrids,cposition,cdefine22,cdefine23 " +
                                        "	,cdefine24,cdefine25,cdefine26,cdefine27,citem_class,citemcode,cname,citemcname,cfree3,cfree4 " +
                                        "	,cfree5,cfree6,cfree7,cfree8,cfree9,cfree10,cbarcode,inquantity,innum,cassunit " +
                                        "	,dmadedate,imassdate,cdefine28,cdefine29,cdefine30,cdefine31,cdefine32,cdefine33,cdefine34,cdefine35 " +
                                        "	,cdefine36,cdefine37,impoids,icheckids,cbvencode,crejectcode,cmassunit,cmolotcode,imaterialfee,dmsdate " +
                                        "	,ismaterialfee,iomodid,iomomid,cmworkcentercode,irsrowno,cbaccounter,dbkeepdate,bcosting,bvmiused,ivmisettlequantity " +
                                        "	,ivmisettlenum,cvmivencode,iinvsncount,cwhpersoncode,cwhpersonname,imaids,iinvexchrate,corufts,comcode,cmocode " +
                                        "	,invcode,imoseq,iopseq,copdesc,iexpiratdatecalcu,cexpirationdate,dexpirationdate,cciqbookcode,ibondedsumqty,productinids " +
                                        "	,iorderdid,iordertype,iordercode,iorderseq,isodid,isotype,csocode,isoseq,ipesodid,ipesotype " +
                                        "	,cpesocode,ipesoseq,cbatchproperty1,cbatchproperty2,cbatchproperty3,cbatchproperty4,cbatchproperty5,cbatchproperty6,cbatchproperty7,cbatchproperty8 " +
                                        "	,cbatchproperty9,cbatchproperty10,cbmemo,applydid,applycode,irowno,strowguid,cservicecode) " +
                                        "Values (" + lIDDetail + "," + lID + ",N'" + s存货编码 + "'," + d领料件数 + "," + d领料数量 + ",null,null,Null,Null,N'" + dtData.Rows[i]["批号"] + "' " +
                                        "	,Null,'" + iTrackid + "','" + ccode + "',Null,Null,Null,Null,Null,Null,Null " +
                                        "	," + ClsBaseDataInfo.ReturnCol(dtData.Rows[i]["cfree1"].ToString().Trim()) + "," + ClsBaseDataInfo.ReturnCol(dtData.Rows[i]["cfree2"].ToString().Trim()) + ",Null,Null,Null,Null,Null," + ClsBaseDataInfo.ReturnCol(dtData.Rows[i]["货位"].ToString()) + ",Null,Null " +
                                        "	,Null,Null,Null,Null,Null,Null,Null,Null," + ClsBaseDataInfo.ReturnCol(dtData.Rows[i]["cfree3"].ToString().Trim()) + "," + ClsBaseDataInfo.ReturnCol(dtData.Rows[i]["cfree4"].ToString().Trim()) + " " +
                                        "	,Null,Null,Null,Null,Null,Null,Null," + d数量 + "," + d件数 + ",N'" + dt存货信息.Rows[0]["cAssComUnitCode"] + "' " +
                                        "	,Null,Null,Null,Null,Null,Null,Null,Null,Null,Null " +
                                        "	,Null,Null," + ClsBaseDataInfo.ReturnCol(dt生产订单信息.Rows[0]["AllocateId"].ToString()) + ",Null,Null,Null,Null,Null,Null,Null " +
                                        "	,Null,Null,Null,Null,Null,Null,Null,1,0,Null " +
                                        "	,Null,Null,Null,Null,Null,Null,1,NULL,Null,N'" + s订单号 + "' " +
                                        "	,N'" + s产品编码 + "'," + s行号 + ",N'0000',Null,0,Null,Null,Null,Null,Null " +
                                        "	," + dt生产订单信息.Rows[0]["Modid"] + ",1,N'" + s订单号 + "',1," + dt生产订单信息.Rows[0]["OrderDId"] + ",0,Null,Null," + dt生产订单信息.Rows[0]["Modid"] + ",7 " +
                                        "	,'" + s订单号 + "'," + s行号 + ",Null,Null,Null,Null,Null,Null,Null,Null " +
                                        "	,Null,Null,Null,Null,Null,1,Null,Null)";
                                SqlHelper.ExecuteNonQuery(tran, CommandType.Text, sSQL);

                                //更新现存量

                                sSQL = "select * from SCM_Item where cInvCode = '" + s存货编码 + "' and ISNULL(cFree1,'') = '" + dtData.Rows[i]["cFree1"].ToString().Trim() + "' and ISNULL(cFree2,'') = '" + dtData.Rows[i]["cFree2"].ToString().Trim() + "' and ISNULL(cFree3,'') = '" + dtData.Rows[i]["cFree3"].ToString().Trim() + "' and ISNULL(cFree4,'') = '" + dtData.Rows[i]["cFree4"].ToString().Trim() + "' and ISNULL(cFree5,'') = '" + dtData.Rows[i]["cFree5"].ToString().Trim() + "' and ISNULL(cFree6,'') = '" + dtData.Rows[i]["cFree6"].ToString().Trim() + "' and ISNULL(cFree7,'') = '" + dtData.Rows[i]["cFree7"].ToString().Trim() + "' and ISNULL(cFree8,'') = '" + dtData.Rows[i]["cFree8"].ToString().Trim() + "' and ISNULL(cFree9,'') = '" + dtData.Rows[i]["cFree9"].ToString().Trim() + "' and ISNULL(cFree10,'') = '" + dtData.Rows[i]["cFree10"].ToString().Trim() + "' ";
                                DataTable dtTemp2 = SqlHelper.ExecuteDataset(tran, CommandType.Text, sSQL).Tables[0];
                                long lItemID = 0;
                                if (dtTemp2 == null || dtTemp2.Rows.Count == 0)
                                {
                                    sSQL = "insert into SCM_Item(cInvCode,cFree1,cFree2,cFree3,cFree4,cFree5,cFree6,cFree7,cFree8,cFree9,cFree10,PartId) " +
                                            "values('" + s存货编码 + "','" + ClsBaseDataInfo.ReturnCol(dtData.Rows[i]["cFree1"]) + "'," + ClsBaseDataInfo.ReturnCol(dtData.Rows[i]["cFree1"]) + "," + ClsBaseDataInfo.ReturnCol(dtData.Rows[i]["cFree2"]) + "," + ClsBaseDataInfo.ReturnCol(dtData.Rows[i]["cFree3"]) + "," + ClsBaseDataInfo.ReturnCol(dtData.Rows[i]["cFree4"]) + "," + ClsBaseDataInfo.ReturnCol(dtData.Rows[i]["cFree5"]) + "," + ClsBaseDataInfo.ReturnCol(dtData.Rows[i]["cFree6"]) + "," + ClsBaseDataInfo.ReturnCol(dtData.Rows[i]["cFree7"]) + "," + ClsBaseDataInfo.ReturnCol(dtData.Rows[i]["cFree8"]) + "," + ClsBaseDataInfo.ReturnCol(dtData.Rows[i]["cFree9"]) + "," + ClsBaseDataInfo.ReturnCol(dtData.Rows[i]["cFree10"]) + ",0)";
                                    SqlHelper.ExecuteNonQuery(tran, CommandType.Text, sSQL);

                                    sSQL = "select * from SCM_Item where cInvCode = '" + s存货编码 + "' and ISNULL(cFree1,'') = '" + dtData.Rows[i]["cFree1"].ToString().Trim() + "' and ISNULL(cFree2,'') = '" + dtData.Rows[i]["cFree2"].ToString().Trim() + "' and ISNULL(cFree3,'') = '" + dtData.Rows[i]["cFree3"].ToString().Trim() + "' and ISNULL(cFree4,'') = '" + dtData.Rows[i]["cFree4"].ToString().Trim() + "' and ISNULL(cFree5,'') = '" + dtData.Rows[i]["cFree5"].ToString().Trim() + "' and ISNULL(cFree6,'') = '" + dtData.Rows[i]["cFree6"].ToString().Trim() + "' and ISNULL(cFree7,'') = '" + dtData.Rows[i]["cFree7"].ToString().Trim() + "' and ISNULL(cFree8,'') = '" + dtData.Rows[i]["cFree8"].ToString().Trim() + "' and ISNULL(cFree9,'') = '" + dtData.Rows[i]["cFree9"].ToString().Trim() + "' and ISNULL(cFree10,'') = '" + dtData.Rows[i]["cFree10"].ToString().Trim() + "' ";
                                    dtTemp2 = SqlHelper.ExecuteDataset(tran, CommandType.Text, sSQL).Tables[0];
                                    lItemID = Convert.ToInt64(dtTemp2.Rows[0]["id"]);
                                }
                                else
                                {
                                    lItemID = Convert.ToInt64(dtTemp2.Rows[0]["id"]);
                                }

                                sSQL = "declare @itmeid int " +
                                            "select @itmeid = MAX(ItemId) + 1 from CurrentStock " +
                                           "if exists(select * from CurrentStock where cinvcode = '" + s存货编码 + "' and isnull(cBatch,'') = isnull(" + ClsBaseDataInfo.ReturnCol(dtData.Rows[i]["批号"].ToString()) + ",'')  and cWhCode = '" + s仓库 + "' and ISNULL(cFree1,'') = '" + dtData.Rows[i]["cFree1"].ToString().Trim() + "' and ISNULL(cFree2,'') = '" + dtData.Rows[i]["cFree2"].ToString().Trim() + "' and ISNULL(cFree3,'') = '" + dtData.Rows[i]["cFree3"].ToString().Trim() + "' and ISNULL(cFree4,'') = '" + dtData.Rows[i]["cFree4"].ToString().Trim() + "' and ISNULL(cFree5,'') = '" + dtData.Rows[i]["cFree5"].ToString().Trim() + "' and ISNULL(cFree6,'') = '" + dtData.Rows[i]["cFree6"].ToString().Trim() + "' and ISNULL(cFree7,'') = '" + dtData.Rows[i]["cFree7"].ToString().Trim() + "' and ISNULL(cFree8,'') = '" + dtData.Rows[i]["cFree8"].ToString().Trim() + "' and ISNULL(cFree9,'') = '" + dtData.Rows[i]["cFree9"].ToString().Trim() + "' and ISNULL(cFree10,'') = '" + dtData.Rows[i]["cFree10"].ToString().Trim() + "') " +
                                           "    update CurrentStock set iQuantity = isnull(iQuantity,0) - " + ClsBaseDataInfo.ReturnCol(d领料数量) + ",iNum = isnull(iNum,0) - " + ClsBaseDataInfo.ReturnCol(d领料件数) + " " +
                                           "    where cinvcode = '" + s存货编码 + "' and isnull(cBatch,'') = isnull(" + ClsBaseDataInfo.ReturnCol(dtData.Rows[i]["批号"].ToString()) + ",'') and cWhCode = '" + s仓库 + "' and ISNULL(cFree1,'') = '" + dtData.Rows[i]["cFree1"].ToString().Trim() + "' and ISNULL(cFree2,'') = '" + dtData.Rows[i]["cFree2"].ToString().Trim() + "' and ISNULL(cFree3,'') = '" + dtData.Rows[i]["cFree3"].ToString().Trim() + "' and ISNULL(cFree4,'') = '" + dtData.Rows[i]["cFree4"].ToString().Trim() + "' and ISNULL(cFree5,'') = '" + dtData.Rows[i]["cFree5"].ToString().Trim() + "' and ISNULL(cFree6,'') = '" + dtData.Rows[i]["cFree6"].ToString().Trim() + "' and ISNULL(cFree7,'') = '" + dtData.Rows[i]["cFree7"].ToString().Trim() + "' and ISNULL(cFree8,'') = '" + dtData.Rows[i]["cFree8"].ToString().Trim() + "' and ISNULL(cFree9,'') = '" + dtData.Rows[i]["cFree9"].ToString().Trim() + "' and ISNULL(cFree10,'') = '" + dtData.Rows[i]["cFree10"].ToString().Trim() + "' " +
                                           "else " +
                                           "    insert into CurrentStock(cWhCode,cInvCode,cBatch,iSoType,iQuantity,iNum,ItemId,cFree1,cFree2,cFree3,cFree4,cFree5,cFree6,cFree7,cFree8,cFree9,cFree10)  " +
                                           "    values('" + s仓库 + "', '" + s存货编码 + "'," + ClsBaseDataInfo.ReturnCol(dtData.Rows[i]["批号"].ToString()) + ",0,-" + ClsBaseDataInfo.ReturnCol(d领料数量) + ",-" + ClsBaseDataInfo.ReturnCol(d领料件数) + "," + lItemID + "," + ClsBaseDataInfo.ReturnCol(dtData.Rows[i]["cFree1"]) + "," + ClsBaseDataInfo.ReturnCol(dtData.Rows[i]["cFree2"]) + "," + ClsBaseDataInfo.ReturnCol(dtData.Rows[i]["cFree3"]) + "," + ClsBaseDataInfo.ReturnCol(dtData.Rows[i]["cFree4"]) + "," + ClsBaseDataInfo.ReturnCol(dtData.Rows[i]["cFree5"]) + "," + ClsBaseDataInfo.ReturnCol(dtData.Rows[i]["cFree6"]) + "," + ClsBaseDataInfo.ReturnCol(dtData.Rows[i]["cFree7"]) + "," + ClsBaseDataInfo.ReturnCol(dtData.Rows[i]["cFree8"]) + "," + ClsBaseDataInfo.ReturnCol(dtData.Rows[i]["cFree9"]) + "," + ClsBaseDataInfo.ReturnCol(dtData.Rows[i]["cFree10"]) + ")";
                                SqlHelper.ExecuteNonQuery(tran, CommandType.Text, sSQL);

                                sSQL = "update mom_moallocate set IssQty  = isnull(IssQty ,0) + " + ClsBaseDataInfo.ReturnCol(d领料数量) + "  where AllocateId = " + ClsBaseDataInfo.ReturnCol(dt生产订单信息.Rows[0]["AllocateId"].ToString());
                                SqlHelper.ExecuteNonQuery(tran, CommandType.Text, sSQL);


                                //货位登记
                                sSQL = "insert into InvPosition( RdsID, RdID, cWhCode, cPosCode, cInvCode, cBatch, cFree1, cFree2, dVDate, iQuantity" +
                                            ", iNum, cMemo, cHandler, dDate, bRdFlag, cSource, cFree3, cFree4, cFree5, cFree6" +
                                            ", cFree7, cFree8, cFree9, cFree10, cAssUnit, cBVencode, iTrackId,  dMadeDate, iMassDate" +
                                            ", cMassUnit, cvmivencode, iExpiratDateCalcu, cExpirationdate, dExpirationdate, cvouchtype, cInVouchType, cVerifier, dVeriDate, dVouchDate) " +
                                        "values(" + lIDDetail + "," + lID + ",'" + s仓库 + "'," + ClsBaseDataInfo.ReturnCol(dtData.Rows[i]["货位"].ToString()) + ",'" + s存货编码 + "'," + ClsBaseDataInfo.ReturnCol(dtData.Rows[i]["批号"].ToString()) + "," + ClsBaseDataInfo.ReturnCol(dtData.Rows[i]["cFree1"].ToString()) + "," + ClsBaseDataInfo.ReturnCol(dtData.Rows[i]["cFree2"].ToString()) + ",null," + ClsBaseDataInfo.ReturnCol(d领料数量) + " " +
                                        "," + ClsBaseDataInfo.ReturnCol(d领料件数) + ",null,'" + s制单人 + "','" + d当前服务器时间.ToString("yyyy-MM-dd") + "',0,null," + ClsBaseDataInfo.ReturnCol(dtData.Rows[i]["cFree3"].ToString()) + "," + ClsBaseDataInfo.ReturnCol(dtData.Rows[i]["cFree4"].ToString()) + "," + ClsBaseDataInfo.ReturnCol(dtData.Rows[i]["cFree5"].ToString()) + "," + ClsBaseDataInfo.ReturnCol(dtData.Rows[i]["cFree6"].ToString()) + "" +
                                        "," + ClsBaseDataInfo.ReturnCol(dtData.Rows[i]["cFree7"]) + "," + ClsBaseDataInfo.ReturnCol(dtData.Rows[i]["cFree8"]) + "," + ClsBaseDataInfo.ReturnCol(dtData.Rows[i]["cFree9"]) + "," + ClsBaseDataInfo.ReturnCol(dtData.Rows[i]["cFree10"]) + "," + ClsBaseDataInfo.ReturnCol(dt存货信息.Rows[0]["cAssComUnitCode"].ToString()) + ",null,0,null,null" +
                                        ",null,null,0,null,null,'11','',null,null,'" + d当前服务器时间.ToString("yyyy-MM-dd") + "')";
                                SqlHelper.ExecuteNonQuery(tran, CommandType.Text, sSQL);

                                sSQL = "if exists( select * from InvPositionSum where cInvCode = '" + s存货编码 + "' and cWhCode = '" + s仓库 + "' and cPosCode = " + ClsBaseDataInfo.ReturnCol(dtData.Rows[i]["货位"].ToString()) + " and ISNULL(cBatch,'') = '" + dtData.Rows[i]["批号"].ToString().Trim() + "' " +
                                    "and isnull(cFree1,'') = '" + dtData.Rows[i]["cFree1"].ToString().Trim() + "'  and ISNULL(cFree2,'') = '" + dtData.Rows[i]["cFree2"].ToString().Trim() + "' and ISNULL(cFree3,'') = '" + dtData.Rows[i]["cFree3"].ToString().Trim() + "' and ISNULL(cFree4,'') = '" + dtData.Rows[i]["cFree4"].ToString().Trim() + "' and ISNULL(cFree5,'') = '" + dtData.Rows[i]["cFree5"].ToString().Trim() + "' and ISNULL(cFree6,'') = '" + dtData.Rows[i]["cFree6"].ToString().Trim() + "' and ISNULL(cFree7,'') = '" + dtData.Rows[i]["cFree7"].ToString().Trim() + "' and ISNULL(cFree8,'') = '" + dtData.Rows[i]["cFree8"].ToString().Trim() + "' and ISNULL(cFree9,'') = '" + dtData.Rows[i]["cFree9"].ToString().Trim() + "' and ISNULL(cFree10,'') = '" + dtData.Rows[i]["cFree10"].ToString().Trim() + "') " +
                                    "   update InvPositionSum set iQuantity = iQuantity - " + ClsBaseDataInfo.ReturnCol(d领料数量) + ",iNum = iNum - " + ClsBaseDataInfo.ReturnCol(d领料件数) + " where cInvCode = '" + s存货编码 + "' and cWhCode = '" + s仓库 + "' and cPosCode = " + ClsBaseDataInfo.ReturnCol(dtData.Rows[i]["货位"].ToString()) + " and ISNULL(cBatch,'') = '" + dtData.Rows[i]["批号"].ToString().Trim() + "' " +
                                    " and isnull(cFree1,'') = '" + dtData.Rows[i]["cFree1"].ToString().Trim() + "'  and ISNULL(cFree2,'') = '" + dtData.Rows[i]["cFree2"].ToString().Trim() + "' and ISNULL(cFree3,'') = '" + dtData.Rows[i]["cFree3"].ToString().Trim() + "' and ISNULL(cFree4,'') = '" + dtData.Rows[i]["cFree4"].ToString().Trim() + "' and ISNULL(cFree5,'') = '" + dtData.Rows[i]["cFree5"].ToString().Trim() + "' and ISNULL(cFree6,'') = '" + dtData.Rows[i]["cFree6"].ToString().Trim() + "' and ISNULL(cFree7,'') = '" + dtData.Rows[i]["cFree7"].ToString().Trim() + "' and ISNULL(cFree8,'') = '" + dtData.Rows[i]["cFree8"].ToString().Trim() + "' and ISNULL(cFree9,'') = '" + dtData.Rows[i]["cFree9"].ToString().Trim() + "' and ISNULL(cFree10,'') = '" + dtData.Rows[i]["cFree10"].ToString().Trim() + "' " +
                                    "else " +
                                    "insert InvPositionSum(cWhCode, cPosCode, cInvCode, iQuantity, inum, cBatch, cFree1, cFree2, cFree3" +
                                        " , cFree4, cFree5, cFree6, cFree7, cFree8, cFree9, cFree10, iTrackid, cvmivencode, cMassUnit" +
                                        ", iMassDate, dMadeDate, dVDate, iExpiratDateCalcu, cExpirationdate, dExpirationdate, cInVouchType) " +
                                    "values(  '" + s仓库 + "', " + ClsBaseDataInfo.ReturnCol(dtData.Rows[i]["货位"].ToString()) + ", '" + s存货编码 + "',  -1 * " + ClsBaseDataInfo.ReturnCol(d领料数量) + ",  -1 * isnull(" + ClsBaseDataInfo.ReturnCol(d领料件数) + ",0), " + ClsBaseDataInfo.ReturnCol(dtData.Rows[i]["批号"].ToString()) + ",  " + ClsBaseDataInfo.ReturnCol(dtData.Rows[i]["cFree1"].ToString()) + ", " + ClsBaseDataInfo.ReturnCol(dtData.Rows[i]["cFree2"]) + ", " + ClsBaseDataInfo.ReturnCol(dtData.Rows[i]["cFree3"]) + "" +
                                        " , " + ClsBaseDataInfo.ReturnCol(dtData.Rows[i]["cFree4"]) + ", " + ClsBaseDataInfo.ReturnCol(dtData.Rows[i]["cFree5"]) + ", " + ClsBaseDataInfo.ReturnCol(dtData.Rows[i]["cFree6"]) + ", " + ClsBaseDataInfo.ReturnCol(dtData.Rows[i]["cFree7"]) + ", " + ClsBaseDataInfo.ReturnCol(dtData.Rows[i]["cFree8"]) + ", " + ClsBaseDataInfo.ReturnCol(dtData.Rows[i]["cFree9"]) + ", " + ClsBaseDataInfo.ReturnCol(dtData.Rows[i]["cFree10"]) + ", '" + lIDDetail + "', null, null" +
                                        ", null, null, null, 0, null, null, '11')";
                                SqlHelper.ExecuteNonQuery(tran, CommandType.Text, sSQL);
                            }
                        }
                    }
                    //7. 更新历史单据号表
                    sSQL = "update VoucherHistory set cNumber='" + iCode + "' Where  CardNumber='0412' and cContent is NULL";
                    SqlHelper.ExecuteNonQuery(tran, CommandType.Text, sSQL);


                    //8. 更新单据ID号表
                    string s1 = lID.ToString().Trim();
                    string s2 = lIDDetail.ToString().Trim();
                    s1 = s1.Substring(1);
                    s2 = s2.Substring(1);
                    lID = Convert.ToInt64(s1);
                    lIDDetail = Convert.ToInt64(s2);
                    sSQL = "update  UFSystem..UA_Identity set iFatherID = " + lID + ",iChildID = " + lIDDetail + " where cAcc_Id = '" + ClsBaseDataInfo.sUFDataBaseName.Trim().Substring(7, 3) + "' and cVouchType = 'rd'";
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

        public string Chk材料出库条码是否已经使用(string sBarCode)
        {
            string s = "";

            try
            {
                string sSQL = "select count(1) from rdrecords11 where isnull(iMPoIds ,'') = '" + SqlHelper.ReturnObjectToDecimal(sBarCode) + "'";
                s = ClsBaseClass.SqlHelper.ExecuteScalar(ClsBaseClass.ClsBaseDataInfo.sConnString, CommandType.Text, sSQL).ToString();
            }
            catch (Exception ee)
            {
                s = ee.Message;
            }
            return s;
        }

        public string dt材料出库条码信息(string sBarCode, string sCode,string sRow)
        {
            string s = "";
            try
            {
                string sSQL = @"
select a.*, b.cInvName,b.cInvStd,b.bInvBatch,a.cBatch
	,e.Qty,e.IssQty,e.未领数量 as 未领数量, 
	f.cCode,f.irowno,f.cInvCode,f.iNum 
	,a.cFree1,a.cFree2,a.cFree3,a.cFree4,a.cFree5,a.cFree6,a.cFree7,a.cFree8,a.cFree9,a.cFree10
	,a.cInvCode,f.iQuantity 
from _BarCodeInventory a 
	left join (
					select a.cCode,b.irowno,b.cInvCode,b.iQuantity,b.iNum,b.cBatch,b.cBatchProperty6 ,b.cFree1,b.cFree2,b.cFree3,b.cFree4,b.cFree5,b.cFree6,b.cFree7,b.cFree8,b.cFree9,b.cFree10   
					from rdrecord01 a inner join rdrecords01 b on a.id = b.ID
				) f on  a.cInvCode = f.cInvCode --and ISNULL(a.cFree1,'') = ISNULL(f.cFree1,'')
       -- and ISNULL(a.cFree2,'') = ISNULL(f.cFree2,'') and ISNULL(a.cFree3,'') = ISNULL(f.cFree3,'') and ISNULL(a.cFree4,'') = ISNULL(f.cFree4,'') and ISNULL(a.cFree5,'') = ISNULL(f.cFree5,'')
       -- and ISNULL(a.cFree6,'') = ISNULL(f.cFree6,'') and ISNULL(a.cFree7,'') = ISNULL(f.cFree7,'') and ISNULL(a.cFree8,'') = ISNULL(f.cFree8,'') and ISNULL(a.cFree9,'') = ISNULL(f.cFree9,'')
        --and ISNULL(a.cFree10,'') = ISNULL(f.cFree10,'') and ISNULL(a.cbatch,'') = ISNULL(f.cbatch,'')
	inner join Inventory b on a.cInvCode = b.cInvCode 	
	left join (
					select c.InvCode as 子件编码, c.qty,c.issQty,c.Qty - isnull(c.issQty,0) as 未领数量,c.LotNo  ,b.Free1,b.Free2,b.Free3,b.Free4,b.Free5,b.Free6,b.Free7,b.Free8,b.Free9,b.Free10
                    from mom_order a inner join mom_orderdetail b on a.moid = b.moid inner join mom_moallocate c on c.MoDId  = b.Modid 
                    where a.mocode = '111111' and 222222 
				) e on e.子件编码 = a.cInvCode 
                 --  and ISNULL(a.cFree1,'') = ISNULL(f.cFree1,'')
     --   and ISNULL(a.cFree2,'') = ISNULL(f.cFree2,'') and ISNULL(a.cFree3,'') = ISNULL(f.cFree3,'') and ISNULL(a.cFree4,'') = ISNULL(f.cFree4,'') and ISNULL(a.cFree5,'') = ISNULL(f.cFree5,'')
     --   and ISNULL(a.cFree6,'') = ISNULL(f.cFree6,'') and ISNULL(a.cFree7,'') = ISNULL(f.cFree7,'') and ISNULL(a.cFree8,'') = ISNULL(f.cFree8,'') and ISNULL(a.cFree9,'') = ISNULL(f.cFree9,'')
     --   and ISNULL(a.cFree10,'') = ISNULL(f.cFree10,'') and ISNULL(a.cbatch,'') = ISNULL(f.cbatch,'')
where a.AutoID  = '333333'
";


                sSQL = sSQL.Replace("111111", sCode);
                if (sRow != "")
                {
                    sSQL = sSQL.Replace("222222", "b.SortSeq = '" + sRow + "'");
                }
                else
                {
                    sSQL = sSQL.Replace("222222", "1=1");
                }
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
