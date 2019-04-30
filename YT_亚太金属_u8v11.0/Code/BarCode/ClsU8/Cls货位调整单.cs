using System;
using System.Collections.Generic;
using System.Web;
using System.Data;
using System.Collections;
using System.Data.SqlClient;
using ClsBaseClass;

namespace ClsU8
{
    public class Cls货位调整单
    {
        public string Save货位调整单(DataTable dtData)
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

                    //1.  判断是否结账
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

                    string dDate = d当前服务器时间.ToString("yyyy-MM-dd");

                    //2. 获得单据ID
                    sSQL = "select MAX(a.ID) as iFatherId,MAX(b.AutoID) as iChildId from AdjustPVouch a left join AdjustPVouchs b on a.ID=b.ID ";
                    DataTable dt = SqlHelper.ExecuteDataset(tran, CommandType.Text, sSQL).Tables[0];

                    long lID = SqlHelper.ReturnObjectToLong(dt.Rows[0]["iFatherId"]);

                    long lIDDetail = SqlHelper.ReturnObjectToLong(dt.Rows[0]["iChildId"]);


                    sSQL = "select MAX(a.ID) as iFatherId,MAX(b.AutoID) as iChildId from ST_AppTransVouch a left join ST_AppTransVouchs b on a.ID=b.ID ";
                    dt = SqlHelper.ExecuteDataset(tran, CommandType.Text, sSQL).Tables[0];

                    long lID2 = SqlHelper.ReturnObjectToLong(dt.Rows[0]["iFatherId"]);

                    long lIDDetail2 = SqlHelper.ReturnObjectToLong(dt.Rows[0]["iChildId"]);
                   
                    //3. 获得单据号
                    long iCode = 0;
                    sSQL = "select cNumber as Maxnumber From VoucherHistory  with (NOLOCK) Where  CardNumber='0313' and isnull(cSeed,'')=''";
                    dtTemp = SqlHelper.ExecuteDataset(tran, CommandType.Text, sSQL).Tables[0];
                    if (dtTemp == null || dtTemp.Rows.Count < 1)
                    {
                        iCode = 1;
                    }
                    else
                    {
                        iCode = ClsBaseDataInfo.ReturnObjectToLong(dtTemp.Rows[0]["Maxnumber"]);
                    }

                    long iCode2 = 0;
                    sSQL = "select cNumber as Maxnumber From VoucherHistory  with (NOLOCK) Where  CardNumber='0324' and isnull(cSeed,'')=''";
                    dtTemp = SqlHelper.ExecuteDataset(tran, CommandType.Text, sSQL).Tables[0];
                    if (dtTemp == null || dtTemp.Rows.Count < 1)
                    {
                        iCode2 = 1;
                    }
                    else
                    {
                        iCode2 = ClsBaseDataInfo.ReturnObjectToLong(dtTemp.Rows[0]["Maxnumber"]);
                    }

                    string i单据号 = "";
                    DataTable dtgroup = Group(dtData, new string[] { "调整前仓库","调整前货位","调整后仓库","调整后货位", "制单人" }, "");
                    for (int j = 0; j < dtgroup.Rows.Count; j++)
                    {
                        string s调整前仓库 = dtgroup.Rows[j]["调整前仓库"].ToString().Trim();
                        string s调整后仓库 = dtgroup.Rows[j]["调整后仓库"].ToString().Trim();
                        string s制单人 = dtgroup.Rows[j]["制单人"].ToString().Trim();
                        #region 货位调整
                        if (s调整前仓库 == s调整后仓库)
                        {
                            //4. 组装表头
                            lID += 1;

                            
                            iCode += 1;

                            string s单据号 = sGetCode(iCode, 10);
                            if (i单据号 != "")
                            {
                                i单据号 = i单据号 + "," + s单据号;
                            }
                            else
                            {
                                i单据号 = s单据号;
                            }
                            sSQL = @" Insert Into AdjustPVouch(cvouchcode,ddate,cwhcode,cdepcode,cpersoncode,cmemo,cmaker,cdefine1,cdefine2,cdefine3,
cdefine4,cdefine5,cdefine6,cdefine7,cdefine8,cdefine9,cdefine10,id,vt_id,cdefine11,cdefine12,
cdefine13,cdefine15,cdefine16,cmodifyperson,dmodifydate,dnmaketime,dnmodifytime,csource,iprintcount,csysbarcode,cDefine14)
	 Values ('" + s单据号 + "',N'" + dDate + "',N'" + s调整前仓库 + "',Null,Null,Null,N'" + s制单人 + "',Null,Null,Null," +
             "Null,Null,Null,Null,Null,Null,Null," + lID + ",113," +
             "Null,Null,Null,Null,Null,Null,Null,getdate(),Null ,N'1',0,Null,'Y')";

                            SqlHelper.ExecuteNonQuery(tran, CommandType.Text, sSQL);
                            int irowno = 0;
                            for (int i = 0; i < dtData.Rows.Count; i++)
                            {
                                if (s调整前仓库 == dtData.Rows[i]["调整前仓库"].ToString().Trim() && s调整后仓库 == dtData.Rows[i]["调整后仓库"].ToString().Trim())
                                {
                                    #region 存货自由项
                                    string s存货编码 = dtData.Rows[i]["存货编码"].ToString().Trim();
                                    sSQL = "select * from Inventory where cInvCode = '" + s存货编码 + "'";
                                    DataTable dt存货 = SqlHelper.ExecuteDataset(tran, CommandType.Text, sSQL).Tables[0];
                                    if (dt存货.Rows.Count == 0)
                                    {
                                        sErr = sErr + "行" + (i + 1).ToString() + "存货不存在\n";
                                        continue;
                                    }


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

                                    //组装表体
                                    ClsU8基础档案 cls = new ClsU8基础档案();
                                    decimal d现存数量 = cls.d货位现存量(s存货编码, dtData.Rows[i]["批号"].ToString().Trim(), dtData.Rows[i]["cFree1"].ToString().Trim(), dtData.Rows[i]["cFree2"].ToString().Trim(),
                                        dtData.Rows[i]["cFree3"].ToString().Trim(), dtData.Rows[i]["cFree4"].ToString().Trim(), dtData.Rows[i]["调整前货位"].ToString().Trim());

                                    decimal d数量 = ClsBaseDataInfo.ReturnObjectToDecimal(dtData.Rows[i]["数量"], 6);
                                    if (d数量 > d现存数量)
                                    {
                                        sErr = sErr + "行" + (i + 1).ToString() + "货位现存量小于调整单数量\n";
                                    }

                                    decimal d件数 = ClsBaseDataInfo.ReturnObjectToDecimal(dtData.Rows[i]["件数"], 6);


                                    lIDDetail += 1;
                                    irowno = irowno + 1;
                                    sSQL = @"Insert Into AdjustPVouchs(cvouchcode,cinvcode,cbposcode,caposcode,rdsid,inum,iquantity,cbatch,cfree1,cfree2,
ddisdate,cdefine22,cdefine23,cdefine24,cdefine25,cdefine26,cdefine27,autoid,id,cbarcode,
cassunit,cfree3,cfree4,cfree5,cfree6,cfree7,cfree8,cfree9,cfree10,cdefine28,
cdefine29,cdefine30,cdefine31,cdefine32,cdefine33,cdefine34,cdefine35,cdefine36,cdefine37,cbvencode,
cinvouchcode,imassdate,dmadedate,cmassunit,cvmivencode,iinvsncount,iexpiratdatecalcu,cexpirationdate,dexpirationdate,cbatchproperty1,
cbatchproperty2,cbatchproperty3,cbatchproperty4,cbatchproperty5,cbatchproperty6,cbatchproperty7,cbatchproperty8,cbatchproperty9,cbatchproperty10,cbmemo,
irowno,cinvouchtype,strowguid,cbsysbarcode,idirectiveid)
Values (N'" + s单据号 + "',N'" + s存货编码 + "',N'" + dtData.Rows[i]["调整前货位"].ToString().Trim() + "',N'" + dtData.Rows[i]["调整后货位"].ToString().Trim() + "',null," + d件数 + "," + d数量 + ",N'" + dtData.Rows[i]["批号"].ToString().Trim() + "',N'" + dtData.Rows[i]["cFree1"].ToString().Trim() + "',N'" + dtData.Rows[i]["cFree2"].ToString().Trim() + "'," +
        "Null,Null,Null,Null,Null,Null,Null," + lIDDetail + "," + lID + ",Null," +
        "N'" + dt存货信息.Rows[0]["cAssComUnitCode"].ToString() + "',N'" + dtData.Rows[i]["cFree3"].ToString().Trim() + "',N'" + dtData.Rows[i]["cFree4"].ToString().Trim() + "',Null,Null,Null,Null,Null,Null,Null," +
        "Null,Null,Null,Null,Null,Null,Null,Null,Null,Null," +
        "null,Null,Null,Null,Null,Null,0,Null,Null,Null," +
        "Null,Null,Null,Null,Null,Null,Null,Null,Null,Null," +
        "" + irowno + ",null,Null,Null,Null)";

                                    SqlHelper.ExecuteNonQuery(tran, CommandType.Text, sSQL);

                                    //货位登记
                                    sSQL = "insert into InvPosition( RdsID, RdID, cWhCode, cPosCode, cInvCode, cBatch, cFree1, cFree2, dVDate, iQuantity" +
                                                ", iNum, cMemo, cHandler, dDate, bRdFlag, cSource, cFree3, cFree4, cFree5, cFree6" +
                                                ", cFree7, cFree8, cFree9, cFree10, cAssUnit, cBVencode, iTrackId,  dMadeDate, iMassDate" +
                                                ", cMassUnit, cvmivencode, iExpiratDateCalcu, cExpirationdate, dExpirationdate, cvouchtype, cInVouchType, cVerifier, dVeriDate, dVouchDate) " +
                                            "values(" + lIDDetail + "," + lID + ",'" + s调整前仓库 + "'," + ClsBaseDataInfo.ReturnCol(dtData.Rows[i]["调整前货位"].ToString()) + ",'" + s存货编码 + "'," + ClsBaseDataInfo.ReturnCol(dtData.Rows[i]["批号"].ToString()) + "," + ClsBaseDataInfo.ReturnCol(dtData.Rows[i]["cFree1"]) + "," + ClsBaseDataInfo.ReturnCol(dtData.Rows[i]["cFree2"]) + ",null," + ClsBaseDataInfo.ReturnCol(d数量) + " " +
                                            "," + ClsBaseDataInfo.ReturnCol(d件数) + ",null,'" + s制单人 + "','" + d当前服务器时间.ToString("yyyy-MM-dd") + "',0,'货位调整'," + ClsBaseDataInfo.ReturnCol(dtData.Rows[i]["cFree3"]) + "," + ClsBaseDataInfo.ReturnCol(dtData.Rows[i]["cFree4"]) + "," + ClsBaseDataInfo.ReturnCol(dtData.Rows[i]["cFree5"]) + "," + ClsBaseDataInfo.ReturnCol(dtData.Rows[i]["cFree6"]) + "" +
                                            "," + ClsBaseDataInfo.ReturnCol(dtData.Rows[i]["cFree7"]) + "," + ClsBaseDataInfo.ReturnCol(dtData.Rows[i]["cFree8"]) + "," + ClsBaseDataInfo.ReturnCol(dtData.Rows[i]["cFree9"]) + "," + ClsBaseDataInfo.ReturnCol(dtData.Rows[i]["cFree10"]) + "," + ClsBaseDataInfo.ReturnCol(dt存货信息.Rows[0]["cAssComUnitCode"].ToString()) + ",null,0,null,null" +
                                            ",null,null,0,null,null,19,'',null,null,'" + d当前服务器时间.ToString("yyyy-MM-dd") + "')";
                                    SqlHelper.ExecuteNonQuery(tran, CommandType.Text, sSQL);

                                    sSQL = "if exists( select * from InvPositionSum where cInvCode = '" + s存货编码 + "' and cWhCode = '" + s调整前仓库 + "' and cPosCode = " + ClsBaseDataInfo.ReturnCol(dtData.Rows[i]["调整前货位"].ToString()) + " and ISNULL(cBatch,'') = '" + dtData.Rows[i]["批号"].ToString().Trim() + "' " +
                                "and isnull(cFree1,'') = '" + dtData.Rows[i]["cFree1"].ToString().Trim() + "'  and ISNULL(cFree2,'') = '" + dtData.Rows[i]["cFree2"].ToString().Trim() + "' and ISNULL(cFree3,'') = '" + dtData.Rows[i]["cFree3"].ToString().Trim() + "' and ISNULL(cFree4,'') = '" + dtData.Rows[i]["cFree4"].ToString().Trim() + "' and ISNULL(cFree5,'') = '" + dtData.Rows[i]["cFree5"].ToString().Trim() + "' and ISNULL(cFree6,'') = '" + dtData.Rows[i]["cFree6"].ToString().Trim() + "' and ISNULL(cFree7,'') = '" + dtData.Rows[i]["cFree7"].ToString().Trim() + "' and ISNULL(cFree8,'') = '" + dtData.Rows[i]["cFree8"].ToString().Trim() + "' and ISNULL(cFree9,'') = '" + dtData.Rows[i]["cFree9"].ToString().Trim() + "' and ISNULL(cFree10,'') = '" + dtData.Rows[i]["cFree10"].ToString().Trim() + "') " +
                                "   update InvPositionSum set iQuantity = iQuantity -  " + ClsBaseDataInfo.ReturnCol(d数量) + ",iNum = iNum -  " + ClsBaseDataInfo.ReturnCol(d件数) + " where cInvCode = '" + s存货编码 + "' and cWhCode = '" + s调整前仓库 + "' and cPosCode = " + ClsBaseDataInfo.ReturnCol(dtData.Rows[i]["调整前货位"].ToString()) + " and ISNULL(cBatch,'') = '" + dtData.Rows[i]["批号"].ToString().Trim() + "'  " +
                                " and isnull(cFree1,'') = '" + dtData.Rows[i]["cFree1"].ToString().Trim() + "'  and ISNULL(cFree2,'') = '" + dtData.Rows[i]["cFree2"].ToString().Trim() + "' and ISNULL(cFree3,'') = '" + dtData.Rows[i]["cFree3"].ToString().Trim() + "' and ISNULL(cFree4,'') = '" + dtData.Rows[i]["cFree4"].ToString().Trim() + "' and ISNULL(cFree5,'') = '" + dtData.Rows[i]["cFree5"].ToString().Trim() + "' and ISNULL(cFree6,'') = '" + dtData.Rows[i]["cFree6"].ToString().Trim() + "' and ISNULL(cFree7,'') = '" + dtData.Rows[i]["cFree7"].ToString().Trim() + "' and ISNULL(cFree8,'') = '" + dtData.Rows[i]["cFree8"].ToString().Trim() + "' and ISNULL(cFree9,'') = '" + dtData.Rows[i]["cFree9"].ToString().Trim() + "' and ISNULL(cFree10,'') = '" + dtData.Rows[i]["cFree10"].ToString().Trim() + "' " +
                                "else " +
                                "insert InvPositionSum(cWhCode, cPosCode, cInvCode, iQuantity, inum, cBatch, cFree1, cFree2, cFree3" +
                                    " , cFree4, cFree5, cFree6, cFree7, cFree8, cFree9, cFree10, iTrackid, cvmivencode, cMassUnit" +
                                    ", iMassDate, dMadeDate, dVDate, iExpiratDateCalcu, cExpirationdate, dExpirationdate, cInVouchType) " +
                                "values(  '" + s调整前仓库 + "', " + ClsBaseDataInfo.ReturnCol(dtData.Rows[i]["调整前货位"].ToString()) + ", '" + s存货编码 + "',  -1*" + ClsBaseDataInfo.ReturnCol(d数量) + ", -1* " + ClsBaseDataInfo.ReturnCol(d件数) + ", " + ClsBaseDataInfo.ReturnCol(dtData.Rows[i]["批号"].ToString()) + ", " + ClsBaseDataInfo.ReturnCol(dtData.Rows[i]["cFree1"].ToString()) + ", " + ClsBaseDataInfo.ReturnCol(dtData.Rows[i]["cFree2"]) + ", " + ClsBaseDataInfo.ReturnCol(dtData.Rows[i]["cFree3"]) + "" +
                                    " , " + ClsBaseDataInfo.ReturnCol(dtData.Rows[i]["cFree4"]) + ", " + ClsBaseDataInfo.ReturnCol(dtData.Rows[i]["cFree5"]) + ", " + ClsBaseDataInfo.ReturnCol(dtData.Rows[i]["cFree6"]) + ", " + ClsBaseDataInfo.ReturnCol(dtData.Rows[i]["cFree7"]) + ", " + ClsBaseDataInfo.ReturnCol(dtData.Rows[i]["cFree8"]) + ", " + ClsBaseDataInfo.ReturnCol(dtData.Rows[i]["cFree9"]) + ", " + ClsBaseDataInfo.ReturnCol(dtData.Rows[i]["cFree10"]) + ", '" + lIDDetail + "', null, null" +
                                    ", null, null, null, 0, null, null, '19')";
                                    SqlHelper.ExecuteNonQuery(tran, CommandType.Text, sSQL);

                                    sSQL = "insert into InvPosition( RdsID, RdID, cWhCode, cPosCode, cInvCode, cBatch, cFree1, cFree2, dVDate, iQuantity" +
                                                ", iNum, cMemo, cHandler, dDate, bRdFlag, cSource, cFree3, cFree4, cFree5, cFree6" +
                                                ", cFree7, cFree8, cFree9, cFree10, cAssUnit, cBVencode, iTrackId,  dMadeDate, iMassDate" +
                                                ", cMassUnit, cvmivencode, iExpiratDateCalcu, cExpirationdate, dExpirationdate, cvouchtype, cInVouchType, cVerifier, dVeriDate, dVouchDate) " +
                                            "values(" + lIDDetail + "," + lID + ",'" + s调整前仓库 + "'," + ClsBaseDataInfo.ReturnCol(dtData.Rows[i]["调整后货位"].ToString()) + ",'" + s存货编码 + "'," + ClsBaseDataInfo.ReturnCol(dtData.Rows[i]["批号"].ToString()) + "," + ClsBaseDataInfo.ReturnCol(dtData.Rows[i]["cFree1"]) + "," + ClsBaseDataInfo.ReturnCol(dtData.Rows[i]["cFree2"]) + ",null," + ClsBaseDataInfo.ReturnCol(d数量) + " " +
                                            "," + ClsBaseDataInfo.ReturnCol(d件数) + ",null,'" + s制单人 + "','" + d当前服务器时间.ToString("yyyy-MM-dd") + "',1,'货位调整'," + ClsBaseDataInfo.ReturnCol(dtData.Rows[i]["cFree3"]) + "," + ClsBaseDataInfo.ReturnCol(dtData.Rows[i]["cFree4"]) + "," + ClsBaseDataInfo.ReturnCol(dtData.Rows[i]["cFree5"]) + "," + ClsBaseDataInfo.ReturnCol(dtData.Rows[i]["cFree6"]) + "" +
                                            "," + ClsBaseDataInfo.ReturnCol(dtData.Rows[i]["cFree7"]) + "," + ClsBaseDataInfo.ReturnCol(dtData.Rows[i]["cFree8"]) + "," + ClsBaseDataInfo.ReturnCol(dtData.Rows[i]["cFree9"]) + "," + ClsBaseDataInfo.ReturnCol(dtData.Rows[i]["cFree10"]) + "," + ClsBaseDataInfo.ReturnCol(dt存货信息.Rows[0]["cAssComUnitCode"].ToString()) + ",null,0,null,null" +
                                            ",null,null,0,null,null,19,'',null,null,'" + d当前服务器时间.ToString("yyyy-MM-dd") + "')";
                                    SqlHelper.ExecuteNonQuery(tran, CommandType.Text, sSQL);

                                    sSQL = "if exists( select * from InvPositionSum where cInvCode = '" + s存货编码 + "' and cWhCode = '" + s调整前仓库 + "' and cPosCode = " + ClsBaseDataInfo.ReturnCol(dtData.Rows[i]["调整后货位"].ToString()) + " and ISNULL(cBatch,'') = '" + dtData.Rows[i]["批号"].ToString().Trim() + "' " +
                                "and isnull(cFree1,'') = '" + dtData.Rows[i]["cFree1"].ToString().Trim() + "'  and ISNULL(cFree2,'') = '" + dtData.Rows[i]["cFree2"].ToString().Trim() + "' and ISNULL(cFree3,'') = '" + dtData.Rows[i]["cFree3"].ToString().Trim() + "' and ISNULL(cFree4,'') = '" + dtData.Rows[i]["cFree4"].ToString().Trim() + "' and ISNULL(cFree5,'') = '" + dtData.Rows[i]["cFree5"].ToString().Trim() + "' and ISNULL(cFree6,'') = '" + dtData.Rows[i]["cFree6"].ToString().Trim() + "' and ISNULL(cFree7,'') = '" + dtData.Rows[i]["cFree7"].ToString().Trim() + "' and ISNULL(cFree8,'') = '" + dtData.Rows[i]["cFree8"].ToString().Trim() + "' and ISNULL(cFree9,'') = '" + dtData.Rows[i]["cFree9"].ToString().Trim() + "' and ISNULL(cFree10,'') = '" + dtData.Rows[i]["cFree10"].ToString().Trim() + "') " +
                                "   update InvPositionSum set iQuantity = iQuantity +  " + ClsBaseDataInfo.ReturnCol(d数量) + ",iNum = iNum +  " + ClsBaseDataInfo.ReturnCol(d件数) + " where cInvCode = '" + s存货编码 + "' and cWhCode = '" + s调整前仓库 + "' and cPosCode = " + ClsBaseDataInfo.ReturnCol(dtData.Rows[i]["调整后货位"].ToString()) + " and ISNULL(cBatch,'') = '" + dtData.Rows[i]["批号"].ToString().Trim() + "'  " +
                                " and isnull(cFree1,'') = '" + dtData.Rows[i]["cFree1"].ToString().Trim() + "'  and ISNULL(cFree2,'') = '" + dtData.Rows[i]["cFree2"].ToString().Trim() + "' and ISNULL(cFree3,'') = '" + dtData.Rows[i]["cFree3"].ToString().Trim() + "' and ISNULL(cFree4,'') = '" + dtData.Rows[i]["cFree4"].ToString().Trim() + "' and ISNULL(cFree5,'') = '" + dtData.Rows[i]["cFree5"].ToString().Trim() + "' and ISNULL(cFree6,'') = '" + dtData.Rows[i]["cFree6"].ToString().Trim() + "' and ISNULL(cFree7,'') = '" + dtData.Rows[i]["cFree7"].ToString().Trim() + "' and ISNULL(cFree8,'') = '" + dtData.Rows[i]["cFree8"].ToString().Trim() + "' and ISNULL(cFree9,'') = '" + dtData.Rows[i]["cFree9"].ToString().Trim() + "' and ISNULL(cFree10,'') = '" + dtData.Rows[i]["cFree10"].ToString().Trim() + "' " +
                                "else " +
                                "insert InvPositionSum(cWhCode, cPosCode, cInvCode, iQuantity, inum, cBatch, cFree1, cFree2, cFree3" +
                                    " , cFree4, cFree5, cFree6, cFree7, cFree8, cFree9, cFree10, iTrackid, cvmivencode, cMassUnit" +
                                    ", iMassDate, dMadeDate, dVDate, iExpiratDateCalcu, cExpirationdate, dExpirationdate, cInVouchType) " +
                                "values(  '" + s调整前仓库 + "', " + ClsBaseDataInfo.ReturnCol(dtData.Rows[i]["调整后货位"].ToString()) + ", '" + s存货编码 + "',  " + ClsBaseDataInfo.ReturnCol(d数量) + ", " + ClsBaseDataInfo.ReturnCol(d件数) + ", " + ClsBaseDataInfo.ReturnCol(dtData.Rows[i]["批号"].ToString()) + ", " + ClsBaseDataInfo.ReturnCol(dtData.Rows[i]["cFree1"].ToString()) + ", " + ClsBaseDataInfo.ReturnCol(dtData.Rows[i]["cFree2"]) + ", " + ClsBaseDataInfo.ReturnCol(dtData.Rows[i]["cFree3"]) + "" +
                                    " , " + ClsBaseDataInfo.ReturnCol(dtData.Rows[i]["cFree4"]) + ", " + ClsBaseDataInfo.ReturnCol(dtData.Rows[i]["cFree5"]) + ", " + ClsBaseDataInfo.ReturnCol(dtData.Rows[i]["cFree6"]) + ", " + ClsBaseDataInfo.ReturnCol(dtData.Rows[i]["cFree7"]) + ", " + ClsBaseDataInfo.ReturnCol(dtData.Rows[i]["cFree8"]) + ", " + ClsBaseDataInfo.ReturnCol(dtData.Rows[i]["cFree9"]) + ", " + ClsBaseDataInfo.ReturnCol(dtData.Rows[i]["cFree10"]) + ", '" + lIDDetail + "', null, null" +
                                    ", null, null, null, 0, null, null, '19')";
                                    SqlHelper.ExecuteNonQuery(tran, CommandType.Text, sSQL);
                                }
                            }
                        }
                        #endregion
                        #region 调拨单
                        if (s调整前仓库 != s调整后仓库)
                        {
                            //4. 组装表头
                            lID2 += 1;
                            iCode2 += 1;

                            string s单据号2 = sGetCode(iCode2, 10);
                            if (i单据号 != "")
                            {
                                i单据号 = i单据号 + "," + s单据号2;
                            }
                            else
                            {
                                i单据号 = s单据号2;
                            }
                            sSQL = @"Insert Into ST_AppTransVouch(ctvcode,dtvdate,cowhcode,ciwhcode,codepcode,cidepcode,cpersoncode,cirdcode,cordcode,ctvmemo,
cdefine1,cdefine2,cdefine3,cdefine4,cdefine5,cdefine6,cdefine7,cdefine8,cdefine9,cdefine10,
cmaker,id,vt_id,cverifyperson,dverifydate,cdefine11,cdefine12,cdefine13,cdefine15,
cdefine16,ccloser,csource,ireturncount,iverifystate,iswfcontrolled,cmodifyperson,dmodifydate,dnmaketime,dnmodifytime,
dnverifytime,capprovar,dapprovedate,cbustype,bislsquery,csourcecodels,iprintcount,csourceguid,csysbarcode,ccurrentauditor,cDefine14)
     Values (N'" + s单据号2 + "',N'" + dDate + "',N'" + s调整前仓库 + "',N'" + s调整后仓库 + "',Null,Null,Null,Null,Null,Null," +
    "Null,Null,Null,Null,Null,Null,Null,Null,Null,Null," +
    "N'" + s制单人 + "'," + lID2 + ",37,Null,Null,Null,Null,Null,Null," +
    "Null,Null,Null,Null,Null,0,Null,Null,getdate(),Null ," +
    "Null ,Null,Null,Null,Null,Null,0,Null,Null,Null,'Y')";

                            SqlHelper.ExecuteNonQuery(tran, CommandType.Text, sSQL);
                            int irowno = 0;
                            for (int i = 0; i < dtData.Rows.Count; i++)
                            {
                                if (s调整前仓库 == dtData.Rows[i]["调整前仓库"].ToString().Trim() && s调整后仓库 == dtData.Rows[i]["调整后仓库"].ToString().Trim())
                                {
                                    #region 存货自由项
                                    string s存货编码 = dtData.Rows[i]["存货编码"].ToString().Trim();
                                    sSQL = "select * from Inventory where cInvCode = '" + s存货编码 + "'";
                                    DataTable dt存货 = SqlHelper.ExecuteDataset(tran, CommandType.Text, sSQL).Tables[0];
                                    if (dt存货.Rows.Count == 0)
                                    {
                                        sErr = sErr + "行" + (i + 1).ToString() + "存货不存在\n";
                                        continue;
                                    }
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

                                    //组装表体
                                    ClsU8基础档案 cls = new ClsU8基础档案();
                                    decimal d现存数量 = cls.d仓库现存量(s存货编码, dtData.Rows[i]["批号"].ToString().Trim(), dtData.Rows[i]["cFree1"].ToString().Trim(), dtData.Rows[i]["cFree2"].ToString().Trim(),
                                        dtData.Rows[i]["cFree3"].ToString().Trim(), dtData.Rows[i]["cFree4"].ToString().Trim(), s调整前仓库);

                                    decimal d数量 = ClsBaseDataInfo.ReturnObjectToDecimal(dtData.Rows[i]["数量"], 6);
                                    if (d数量 > d现存数量)
                                    {
                                        sErr = sErr + "行" + (i + 1).ToString() + "仓库现存量小于调拨数量\n";
                                    }

                                    lIDDetail2 += 1;
                                    irowno = irowno + 1;
                                    sSQL = @"Insert Into ST_AppTransVouchs(ctvcode,cinvcode,itvnum,itvquantity,itvchknum,itvchkquantity,itvsumnum,itvsumquantity,itvpcost,itvpprice,
ctvbatch,ddisdate,citemcode,citem_class,iunitcost,iprice,fsalecost,fsaleprice,cname,citemcname,
autoid,id,imassdate,dappdate,cbarcode,cassunit,cbvencode,cinvouchcode,dmadedate,cmassunit,
cbcloser,cfree1,cfree2,cfree3,cfree4,cfree5,cfree6,cfree7,cfree8,cfree9,
cfree10,cdefine22,cdefine23,cdefine24,cdefine25,cdefine26,cdefine27,cdefine28,cdefine29,cdefine30,
cdefine31,cdefine32,cdefine33,cdefine34,cdefine35,cdefine36,cdefine37,iinvexchrate,iexpiratdatecalcu,cexpirationdate,
dexpirationdate,cbmemo,irowno,cbsysbarcode)
Values (N'" + s单据号2 + "',N'" + s存货编码 + "',0," + d数量 + ",Null,Null,Null,Null,Null,Null," +
    "N'" + dtData.Rows[i]["批号"].ToString().Trim() + "',Null,Null,Null,Null,Null,0,0,Null,Null," +
    "" + lIDDetail2 + "," + lID2 + ",Null,Null,Null,N'" + dt存货信息.Rows[0]["cAssComUnitCode"].ToString() + "',Null,Null,Null,Null," +
    "Null,N'" + dtData.Rows[i]["cFree1"].ToString().Trim() + "',N'" + dtData.Rows[i]["cFree2"].ToString().Trim() + "',N'" + dtData.Rows[i]["cFree3"].ToString().Trim() + "',N'" + dtData.Rows[i]["cFree4"].ToString().Trim() + "',Null,Null,Null,Null,Null," +
    "Null,Null,Null,Null,Null,Null,Null,Null,Null,Null," +
    "Null,Null,Null,Null,Null,Null,Null,Null,0,Null," +
    "Null,Null," + irowno + ",Null)";

                                    SqlHelper.ExecuteNonQuery(tran, CommandType.Text, sSQL);

                                }
                            }
                        }
                        #endregion
                        
                    }

                    //7. 更新历史单据号表
                    sSQL = @"IF EXISTS(select cNumber as Maxnumber From VoucherHistory  with (XLOCK) Where  CardNumber='0313'  and isnull(cSeed,'')='') 
    update VoucherHistory set cNumber='222222' Where  CardNumber='0313'  and  isnull(cSeed,'')=''
else
    Insert into VoucherHistory(CardNumber,cContent,cContentRule,cSeed,cNumber) values('0313',null,null,null,'222222')


IF EXISTS(select cNumber as Maxnumber From VoucherHistory  with (XLOCK) Where  CardNumber='0324'  and isnull(cSeed,'')='') 
    update VoucherHistory set cNumber='222222' Where  CardNumber='0324' and  isnull(cSeed,'')=''
else
    Insert into VoucherHistory(CardNumber,cContent,cContentRule,cSeed,cNumber) values('0324',null,null,null,'222222')
 ";
                    sSQL = sSQL.Replace("222222", iCode.ToString());
                    SqlHelper.ExecuteNonQuery(tran, CommandType.Text, sSQL);

                    ////8. 更新单据ID号表
                    //sSQL = "update  UFSystem..UA_Identity set iFatherId = " + lID + ",iChildId = " + lIDDetail + " where cVouchType = 'BILLVOUCH' and cAcc_Id =  '" + ClsBaseDataInfo.sUFDataBaseName.Trim().Substring(7, 3) + "'";
                    //SqlHelper.ExecuteNonQuery(tran, CommandType.Text, sSQL);

                    if (sErr.Trim().Length > 0)
                    {
                        throw new Exception(sErr);
                    }

                    tran.Commit();
                    s = "生成单据号：" + i单据号;
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


        public static DataTable Group(DataTable dt, string[] ColumnName,string Sel)
        {
            DataRow[] dw = dt.Select(Sel);
            DataTable dts = new DataTable();
            foreach (DataColumn dc in dt.Columns)
            {
                dts.Columns.Add(dc.ColumnName);
            }
            foreach (DataRow dws in dw)
            {
                dts.ImportRow(dws);
            }
            DataView dv = new DataView(dts);
            DataTable dtgroup = dv.ToTable(true, ColumnName);
            return dtgroup;
        }

    }
}
