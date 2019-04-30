using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using TH.WebService.BaseClass;


namespace TH.DAL
{
    /// <summary>
    /// 数据访问类:工序流转
    /// </summary>
    public partial class 工序流转
    {
        public 工序流转()
        { }

        /// <summary>
        /// 获得条形码信息
        /// </summary>
        /// <param name="sBarCode2"></param>
        /// <returns></returns>
        public DataTable dtGetBarCode(string sBarCode2,string sUfName)
        {

            string sSQL = @"
select a.WorkCode, a.WorkDetailsID, a.BarCode, a.cInvCode,Inv.cInvName,Inv.cInvStd, a.WorkQty, a.iQty, a.iBoxQty
	,b.WorkProcessNo,b.WorkProcessName,b.分包,b.分包数,b.入库
	,c.BarCode2,c.数量,c.iID
from dbo.BarCodeList a left join dbo.生产订单产品工序 b on a.WorkDetailsID = b.WorkDetailsID
	left join dbo.工序流转 c on a.BarCode = c.BarCode2 and b.WorkProcessNo = c.工序 and c.WorkDetailsID = b.WorkDetailsID and 1=1
	left join @u8.Inventory Inv on Inv.cInvCode = a.cInvCode
where a.BarCode = '111111'
order by b.WorkProcessNo
";

            sSQL = sSQL.Replace("111111", sBarCode2);
            sSQL = sSQL.Replace("@u8", sUfName + ".");

            return DbHelperSQL.Query(sSQL);
        }

        public DataTable dtBarCode执行统计(string sBarCode, string sUfName)
        {

            string sSQL = @"
if exists (select * from tempdb.dbo.sysobjects where id = object_id(N'tempdb..#a') and type='U')
	drop table #a

select b.WorkCode,b.WorkDetailsID,d.cInvCode,d.cInvStd,d.cInvName
	,b.WorkProcessNo,b.WorkProcessName
	,e.workqty,b.装箱数,isnull(cast(c.数量 as varchar(100)),'') as 数量
into #a
from dbo.WorkProcess a inner join dbo.生产订单产品工序 b on a.WorkProcessNo = b.WorkProcessNo
	left join dbo.工序流转 c on b.WorkDetailsID = c.WorkDetailsID and b.WorkProcessNo = c.工序 and c.BarCode = '111111'
	left join dbo.BarCodeList e on e.barcode = c.barcode2
    left join @u8.Inventory d on e.cInvCode = d.cInvCode
where 1=1 and b.WorkDetailsID = (select top 1 WorkDetailsID from 工序流转 where BarCode = '111111')
order by b.WorkProcessNo

insert into #a
select 99999999,99999999,a.cInvCode,b.cInvName,b.cInvStd,c.cCode,'产品入库',null,null,iQuantity 
from @u8.rdrecords a
	inner join @u8.Inventory b on a.cInvCode = b.cInvCode
	inner join @u8.rdrecord c on a.ID = c.id
where cdefine33 = '111111'

select * from #a order by WorkDetailsID,WorkProcessNo
";

            sSQL = sSQL.Replace("111111", sBarCode);
            sSQL = sSQL.Replace("@u8", sUfName + ".");

            return DbHelperSQL.Query(sSQL);
        }

        /// <summary>
        /// 生产订单执行统计
        /// </summary>
        /// <param name="lWorkIDs"></param>
        /// <param name="sUfName"></param>
        /// <returns></returns>
        public DataTable dtWorkIDs执行统计(string lWorkIDs, string sUfName)
        {
            string sSQL = @"
if exists (select * from tempdb.dbo.sysobjects where id = object_id(N'tempdb..#a') and type='U')
	drop table #a


select b.WorkCode,b.WorkDetailsID,d.cInvCode,d.cInvName,d.cInvStd
	,b.WorkProcessNo,b.WorkProcessName
	,e.workqty
	,sum(isnull(cast(c.数量 as decimal(16,0)),0)) as 数量
into #a
from dbo.WorkProcess a inner join dbo.生产订单产品工序 b on a.WorkProcessNo = b.WorkProcessNo
	left join dbo.工序流转 c on b.WorkDetailsID = c.WorkDetailsID and b.WorkProcessNo = c.工序 
	left join dbo.BarCodeList e on e.barcode = c.barcode2
    left join @u8.Inventory d on e.cInvCode = d.cInvCode
where 1=1 and b.WorkDetailsID = 111111
group by b.WorkCode,b.WorkDetailsID,d.cInvCode,d.cInvName,d.cInvStd
	,b.WorkProcessNo,b.WorkProcessName
	,e.workqty
order by b.WorkProcessNo

insert into #a
select '',99999999,a.cInvCode,b.cInvName,b.cInvStd,'','产品入库',null,sum(iQuantity )
from @u8.rdrecords a
	inner join @u8.Inventory b on a.cInvCode = b.cInvCode
	inner join @u8.rdrecord c on a.ID = c.id
where cdefine33 in (select BarCode2 from dbo.工序流转 where WorkDetailsID = 111111)
group by a.cInvCode,b.cInvName,b.cInvStd


select * from #a order by WorkDetailsID,WorkProcessNo
";

            sSQL = sSQL.Replace("111111", lWorkIDs.ToString());
            sSQL = sSQL.Replace("@u8", sUfName + ".");

            return DbHelperSQL.Query(sSQL);
        }

        public int iSave(DataTable dtBarCode, string sUid,string sUfNAme)
        {
            int iCou = 0;
            try
            {
                SqlConnection conn = new SqlConnection(DbHelperSQL.connectionString);
                conn.Open();
                //启用事务
                SqlTransaction tran = conn.BeginTransaction();
                try
                {
                    string sSQL = "select getdate()";
                    DataTable dt = DbHelperSQL.ExecuteDataset(tran, CommandType.Text, sSQL).Tables[0];
                    DateTime dtmNow = TH.WebService.BaseClass.BaseFunction.ReturnDate(dt.Rows[0][0]);


                    Model.工序流转 model = new TH.Model.工序流转();
                    model.WorkDetailsID = TH.WebService.BaseClass.BaseFunction.ReturnLong(dtBarCode.Rows[0]["WorkDetailsID"]);
                    model.BarCode = dtBarCode.Rows[0]["BarCode"].ToString().Trim();
                    model.BarCode2 = dtBarCode.Rows[0]["BarCode2"].ToString().Trim();
                    model.工序 = dtBarCode.Rows[0]["工序"].ToString().Trim();
                    model.数量 = TH.WebService.BaseClass.BaseFunction.ReturnDecimal(dtBarCode.Rows[0]["数量"], 0);
                    model.iID = TH.WebService.BaseClass.BaseFunction.ReturnLong(dtBarCode.Rows[0]["iID"], 0);

                    #region MyRegion
                    /*
                     * 判断是否分包工序
                     * 一 非分包工序
                     *      1. 判断前一道工序是否已经保存,未保存的不能保存当前工序
                     *      2. 工序数量不能超过装箱数
                     *      3. 流转总数不能超过上道工序总数
                     *      4. 本道工序数量不能小于下道工序已保存数量
                     * 二 分包工序
                     *      1. 分包工序允许一条条码分拆多条， 原条形码 + 两位流水（BarCode2）
                     *      2. 判断流转总数是否超过上道工序
                     *      3. 分包工序总数不得超过上道工序
                     *      4. 本道工序数量不能小于下道工序已保存数量
                    */


                    #endregion

                    sSQL = @"
select  distinct a.WorkCode as 生产订单号, a.WorkDetailsID as 生产订单IDs, a.WorkProcessNo as 工序号, a.WorkProcessName as 工序,a.装箱数,isnull(a.分包,0) as 分包, a.分包数, isnull(a.入库,0) as 入库
	,b.数量
from [生产订单产品工序] a 
	left join (select WorkDetailsID,BarCode,工序,sum(数量) as 数量 from 工序流转 group by WorkDetailsID,BarCode,工序) b on a.WorkDetailsID = b.WorkDetailsID and a.WorkProcessNo = b.工序
where a.WorkDetailsID = 111111
order by a.WorkProcessNo
";
                    sSQL = sSQL.Replace("111111", model.WorkDetailsID.ToString());
                    DataTable dt生产订单产品工序 = DbHelperSQL.ExecuteDataset(tran, CommandType.Text, sSQL).Tables[0];

                    int iFocRow = -1;
                    int iRow分包 = -1;
                    for (int i = 0; i < dt生产订单产品工序.Rows.Count; i++)
                    {
                        if (dt生产订单产品工序.Rows[i]["工序号"].ToString().Trim() == model.工序 && iFocRow == -1)
                        {
                            iFocRow = i;
                        }

                        if (TH.WebService.BaseClass.BaseFunction.ReturnBool(dt生产订单产品工序.Rows[i]["分包"]))
                        {
                            iRow分包 = i;
                        }
                    }

                    ////不能超过上道工序总数

                    //上道工序未保存，本工序不可保存
                    decimal d上道工序数量 = 0;
                    if (iFocRow > 0)
                    {
                        d上道工序数量 = TH.WebService.BaseClass.BaseFunction.ReturnDecimal(dt生产订单产品工序.Rows[iFocRow - 1]["数量"], 0);

                        if (d上道工序数量 == 0)
                        {
                            throw new Exception("上道工序尚未保存");
                        }
                    }

                    //工序数量不能大于装箱数
                    decimal d装箱数 = TH.WebService.BaseClass.BaseFunction.ReturnDecimal(dt生产订单产品工序.Rows[0]["装箱数"], 0);
                    if (model.数量 > d装箱数)
                    {
                        throw new Exception("数量不能超过装箱数");
                    }

                    //分包工序数量不能大于分包数量
                    if (iFocRow >= iRow分包 && iRow分包 >= 0)
                    {
                        decimal d分包数 = TH.WebService.BaseClass.BaseFunction.ReturnDecimal(dt生产订单产品工序.Rows[iRow分包]["分包数"], 0);
                        if (model.数量 > d分包数)
                        {
                            throw new Exception("数量不能超过分包数");
                        }
                    }

                    sSQL = @"
SELECT     TOP (200) iID, WorkDetailsID, BarCode, BarCode2, 工序, 数量, CreateUid, CreateDate, UpdateUid, UpdateDate, AuditUid, AuditDate
FROM         工序流转
where WorkDetailsID = 111111 and BarCode2 = '222222' and 工序 = '333333'
";
                    sSQL = sSQL.Replace("111111", model.WorkDetailsID.ToString());
                    sSQL = sSQL.Replace("222222", model.BarCode2.ToString());
                    sSQL = sSQL.Replace("333333", model.工序.ToString());
                    DataTable dt工序流转 = DbHelperSQL.ExecuteDataset(tran, CommandType.Text, sSQL).Tables[0];
                    if (dt工序流转 == null || dt工序流转.Rows.Count == 0)
                    {
                        model.CreateUid = sUid;
                        model.CreateDate = dtmNow;
                        sSQL = Add(model);
                    }
                    else
                    {
                        ////修改数量，不能小于下道工序总数

                        //下道工序已经保存，不能修改
                        decimal d下道工序数量 = 0;
                        if (iFocRow + 1 < dt生产订单产品工序.Rows.Count)
                        {
                            d下道工序数量 = TH.WebService.BaseClass.BaseFunction.ReturnDecimal(dt生产订单产品工序.Rows[iFocRow + 1]["数量"], 0);
                            if (d下道工序数量 > 0)
                            {
                                throw new Exception("下道工序已经保存");
                            }

                            //if (model.数量 < d下道工序数量 && d下道工序数量 != 0)
                            //{
                            //    throw new Exception("数量不能小于下道工序总数量");
                            //}
                        }

                        model.UpdateUid = sUid;
                        model.UpdateDate = dtmNow;
                        sSQL = Update(model);
                    }

                 

                    iCou = iCou + DbHelperSQL.ExecuteNonQuery(tran, CommandType.Text, sSQL);

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
                throw new Exception(ee.Message);
            }
            return iCou;
        }

        public string iSaveRD产品入库(DataTable dtBarCode, string sUid, string sUfNAme)
        {
            string sReturn = "";
            int iCou = 0;
            try
            {
                SqlConnection conn = new SqlConnection(DbHelperSQL.connectionString);
                conn.Open();
                //启用事务
                SqlTransaction tran = conn.BeginTransaction();
                try
                {
                    string sSQL = @"
select * from @u8.rdrecords where cDefine33 = '111111'
";
                    sSQL = sSQL.Replace("111111", dtBarCode.Rows[0]["BarCode2"].ToString().Trim());
                    sSQL = sSQL.Replace("@u8", sUfNAme + ".");
                    DataTable dttemp = DbHelperSQL.ExecuteDataset(tran, CommandType.Text, sSQL).Tables[0];
                    if (dttemp != null && dttemp.Rows.Count > 0)
                    {
                        throw new Exception("该条码入库单已经生成");
                    }

                    sSQL = @"
select *
from @u8.PP_ProductPO a inner join @u8.PP_POMain b on a.ID = b.ID
	inner join @u8.Inventory I on I.cInvCode = b.cInvCode
    inner join @u8.Department dep on dep.cDepCode = a.cDepCode
    left join @u8.Person per on per.cPersonCode = a.cPersonCode
where 1=1 and a.iState = 2
order by b.ID
";
                    sSQL = sSQL.Replace("@u8", sUfNAme + ".");
                    sSQL = sSQL.Replace("1=1", "1=1 and b.MainId = " + dtBarCode.Rows[0]["WorkDetailsID"].ToString().Trim());
                    DataTable dt生产订单 = DbHelperSQL.ExecuteDataset(tran, CommandType.Text, sSQL).Tables[0];

                    if (dt生产订单 == null || dt生产订单.Rows.Count == 0)
                    {
                        throw new Exception("获得生产订单失败");
                    }

                    sSQL = @"
select a.WorkCode, a.WorkDetailsID, a.BarCode, a.cInvCode,Inv.cInvName,Inv.cInvStd, a.WorkQty, a.iQty, a.iBoxQty
	,b.WorkProcessNo,b.WorkProcessName,b.分包,b.分包数,isnull(b.入库,0) as 入库
	,c.BarCode2,c.数量,c.iID
from dbo.BarCodeList a inner join dbo.生产订单产品工序 b on a.WorkDetailsID = b.WorkDetailsID
	inner join dbo.工序流转 c on a.BarCode = c.BarCode2 and b.WorkProcessNo = c.工序 and c.WorkDetailsID = b.WorkDetailsID and 1=1
	inner join @u8.Inventory Inv on Inv.cInvCode = a.cInvCode
where a.BarCode = '111111'
	and isnull(b.入库,0) = 1
order by b.WorkProcessNo
";

                    sSQL = sSQL.Replace("@u8", sUfNAme + ".");
                    sSQL = sSQL.Replace("111111", dtBarCode.Rows[0]["BarCode2"].ToString().Trim());
                    DataTable dt = DbHelperSQL.ExecuteDataset(tran, CommandType.Text, sSQL).Tables[0];
                    if (dt == null)
                    {
                        throw new Exception("获得工序信息失败");
                    }
                    if (dt.Rows.Count == 0)
                    {
                        throw new Exception("请扫描全部工序后入库");
                    }

                    bool b入库 = TH.WebService.BaseClass.BaseFunction.ReturnBool(dt.Rows[0]["入库"]);
                    if (!b入库)
                    {
                        throw new Exception("非入库工序");
                    }

                    sSQL = "select cWhCode ,cWhName from @u8.Warehouse where cWhCode = '111111' or cWhName = '111111' order by cWhCode";
                    sSQL = sSQL.Replace("111111", dtBarCode.Rows[0]["仓库"].ToString().Trim());
                    sSQL = sSQL.Replace("@u8", sUfNAme + ".");
                    DataTable dt仓库 = DbHelperSQL.ExecuteDataset(tran, CommandType.Text, sSQL).Tables[0];
                    if (dt仓库 == null || dt仓库.Rows.Count == 0)
                    {
                        throw new Exception("获得仓库信息失败");
                    }
                    string sWhCode = dt仓库.Rows[0]["cWhCode"].ToString().Trim();
                    dt仓库 = null;

                    sSQL = "select cRdCode,cRdName from @u8.rd_style where bRdFlag = 1 and ISNULL(bRdEnd ,0) = 1 and (cRdCode = '111111' or cRdName = '111111') order by cRdCode";
                    sSQL = sSQL.Replace("111111", dtBarCode.Rows[0]["入库类别"].ToString().Trim());
                    sSQL = sSQL.Replace("@u8", sUfNAme + ".");
                    DataTable dt入库类别 = DbHelperSQL.ExecuteDataset(tran, CommandType.Text, sSQL).Tables[0];
                    if (dt入库类别 == null || dt入库类别.Rows.Count == 0)
                    {
                        throw new Exception("获得入库类别信息失败");
                    }
                    string s入库类别 = dt入库类别.Rows[0]["cRdCode"].ToString().Trim();
                    dt入库类别 = null;


                    TH.Model.VoucherHistory mVouNumber = new TH.Model.VoucherHistory();
                    TH.DAL.VoucherHistory dalVouNumber = new VoucherHistory();


                    string s = sWhCode.Trim();
                    while (s.Length < 3)
                    {
                        s = "0" + s;
                    }

                    sSQL = @"
select * from @u8.VoucherHistory Where CardNumber='0411' and cSeed = '111111'
";
                    sSQL = sSQL.Replace("@u8", sUfNAme + ".");
                    sSQL = sSQL.Replace("111111", s);
                    dt = DbHelperSQL.ExecuteDataset(tran, CommandType.Text, sSQL).Tables[0];

                    string s单据号流水 = "1";

                    mVouNumber.CardNumber = "0411";
                    mVouNumber.iRdFlagSeed = 1;
                    mVouNumber.cContent = "仓库";
                    mVouNumber.cSeed = s;
                    mVouNumber.bEmpty = false;
                    if (dt == null || dt.Rows.Count == 0)
                    {
                        mVouNumber.cNumber = s单据号流水;
                        sSQL = dalVouNumber.Add(mVouNumber);
                        sSQL = sSQL.Replace("@u8", sUfNAme + ".");
                        DbHelperSQL.ExecuteNonQuery(tran, CommandType.Text, sSQL);
                    }
                    else
                    {

                        mVouNumber.AutoId = TH.WebService.BaseClass.BaseFunction.ReturnLong(dt.Rows[0]["AutoId"]);

                        s单据号流水 = (TH.WebService.BaseClass.BaseFunction.ReturnLong(dt.Rows[0]["cNumber"]) + 1).ToString();
                        mVouNumber.cNumber = s单据号流水;
                        sSQL = dalVouNumber.Update(mVouNumber);
                        sSQL = sSQL.Replace("@u8", sUfNAme + ".");
                        DbHelperSQL.ExecuteNonQuery(tran, CommandType.Text, sSQL);
                    }

                    while (s单据号流水.Length < 5)
                    {
                        s单据号流水 = "0" + s单据号流水;
                    }

                    sSQL = @"
declare @p5 int
set @p5=83233
declare @p6 int
set @p6=137021
exec @u8.sp_GetId '','007','rd',1,@p5 output,@p6 output
select @p5, @p6
";
                    sSQL = sSQL.Replace("@u8", sUfNAme + ".");
                    dt = DbHelperSQL.ExecuteDataset(tran, CommandType.Text, sSQL).Tables[0];
                    long lID = TH.WebService.BaseClass.BaseFunction.ReturnLong(dt.Rows[0][0]);
                    long lIDDetails = TH.WebService.BaseClass.BaseFunction.ReturnLong(dt.Rows[0][1]);

                    TH.Model.RdRecord model = new TH.Model.RdRecord();
                    model.ID = lID;
                    model.bRdFlag = 1;
                    model.cVouchType = "10";
                    model.cBusType = "成品入库";
                    model.cSource = "生产订单";
                    model.cWhCode = sWhCode;
                    model.dDate = TH.WebService.BaseClass.BaseFunction.ReturnDate(dtBarCode.Rows[0]["单据日期"]);
                    model.cDepCode = dt生产订单.Rows[0]["cDepCode"].ToString().Trim();
                    model.cPersonCode = dt生产订单.Rows[0]["cPersonCode"].ToString().Trim();
                    //model.cMemo = sUid;
                    model.bTransFlag = false;
                    model.cMaker = sUid;
                    model.iNetLock = 0;
                    model.bpufirst = false;
                    model.biafirst = false;
                    model.iMQuantity = 0;
                    model.VT_ID = 41;
                    model.bIsSTQc = false;
                    model.cPsPcode = dt生产订单.Rows[0]["cInvCode"].ToString().Trim();
                    model.cMPoCode = dt生产订单.Rows[0]["cCode"].ToString().Trim();
                    model.iproorderid = TH.WebService.BaseClass.BaseFunction.ReturnLong(dt生产订单.Rows[0]["id"]);

                    model.cCode = "00" + s + s单据号流水;
                    model.cRdCode = s入库类别;

                    TH.DAL.RdRecord Dal = new RdRecord();
                    sSQL = Dal.Add(model);
                    sSQL = sSQL.Replace("@u8", sUfNAme + ".");
                    DbHelperSQL.ExecuteNonQuery(tran, CommandType.Text, sSQL);


                    TH.Model.RdRecords models = new TH.Model.RdRecords();
                    models.AutoID = lIDDetails;
                    models.ID = lID;
                    models.cInvCode = dt生产订单.Rows[0]["cInvCode"].ToString().Trim();
                    //models.iNum 
                    models.iQuantity = TH.WebService.BaseClass.BaseFunction.ReturnDecimal(dtBarCode.Rows[0]["数量"], 2);
                    models.iFlag = 0;
                    models.iTax = 0;
                    models.iSQuantity = 0;
                    models.iSNum = 0;
                    models.iMoney = 0;
                    models.iSOutQuantity = 0;
                    models.iSOutNum = 0;
                    models.iFQuantity = 0;
                    models.iMPoIds =  TH.WebService.BaseClass.BaseFunction.ReturnLong(dt生产订单.Rows[0]["Mainid"]);
                    models.cDefine33 = dtBarCode.Rows[0]["barCode2"].ToString().Trim();

                    TH.DAL.RdRecords Dals = new RdRecords();
                    sSQL = Dals.Add(models);
                    sSQL = sSQL.Replace("@u8", sUfNAme + ".");
                    iCou = iCou + DbHelperSQL.ExecuteNonQuery(tran, CommandType.Text, sSQL);

                    sSQL = "update @u8.PP_POMain set finquantity=isnull(finquantity,0)+ " + models.iQuantity.ToString() + "  where mainid= " + models.iMPoIds.ToString();
                    sSQL = sSQL.Replace("@u8", sUfNAme + ".");
                    DbHelperSQL.ExecuteNonQuery(tran, CommandType.Text, sSQL);

                    sSQL = @"
Select Sum(iQuantity) As iQuantity,Sum(iNum) As iNum ,  Sum(fOutQuantity) as fOutQuantity,Sum(fOutNum) as fOutNum , Sum(fInQuantity) as fInQuantity 
	,Sum(fInNum) as fInNum,  Sum(fTransInQuantity) as fTransInQuantity ,Sum(fTransInNum) as fTransInNum ,  Sum(fTransOutQuantity) as fTransOutQuantity 
	,Sum(fTransOutNum) as fTransOutNum 
    ,cInvCode,cWhCode
From @u8.CurrentStock  WITH (UPDLOCK)  
Where cWhcode='111111' And cInvCode ='222222' And cFree1 ='' And cFree2 ='' And cFree3 ='' And cFree4 ='' And cFree5 ='' And cFree6 ='' And cFree7 ='' And cFree8 ='' And cFree9 ='' And cFree10 ='' And cBatch =''
group by cInvCode,cWhCode
";
                    sSQL = sSQL.Replace("@u8", sUfNAme + ".");
                    sSQL = sSQL.Replace("111111", model.cWhCode);
                    sSQL = sSQL.Replace("222222", models.cInvCode);
                    DataTable dtCurr = DbHelperSQL.ExecuteDataset(tran, CommandType.Text, sSQL).Tables[0];

                    TH.Model.CurrentStock modelCurr = new TH.Model.CurrentStock();
                    modelCurr.cWhCode = model.cWhCode;
                    modelCurr.cInvCode = models.cInvCode;

                    TH.DAL.CurrentStock DalCurr = new CurrentStock();
                    if (dtCurr == null || dtCurr.Rows.Count == 0)
                    {
                        modelCurr.iQuantity = 0;
                        modelCurr.fInQuantity = models.iQuantity;
                        sSQL = DalCurr.Add(modelCurr);
                        sSQL = sSQL.Replace("@u8", sUfNAme + ".");
                        DbHelperSQL.ExecuteNonQuery(tran, CommandType.Text, sSQL);
                    }
                    else
                    {
                        modelCurr.iQuantity = TH.WebService.BaseClass.BaseFunction.ReturnDecimal(dtCurr.Rows[0]["iQuantity"], 6);
                        modelCurr.fInQuantity = TH.WebService.BaseClass.BaseFunction.ReturnDecimal(dtCurr.Rows[0]["fInQuantity"], 6) + models.iQuantity;
                        sSQL = DalCurr.Update(modelCurr);
                        sSQL = sSQL.Replace("@u8", sUfNAme + ".");
                        DbHelperSQL.ExecuteNonQuery(tran, CommandType.Text, sSQL);
                    }
                    if (iCou <= 0)
                    { 
                        throw new Exception("没有数据保存");
                    }

                    tran.Commit();

                    sReturn = "OK：入库单号：" + model.cCode;
                }
                catch (Exception error)
                {
                    tran.Rollback();
                    sReturn =  error.Message;
                    throw new Exception(error.Message);
                }
            }
            catch (Exception ee)
            {
                throw new Exception(ee.Message);
            }
            return sReturn;
        }

        #region  Method

        

        /// <summary>
        /// 增加一条数据
        /// </summary>
        public string Add(TH.Model.工序流转 model)
        {
            StringBuilder strSql = new StringBuilder();
            StringBuilder strSql1 = new StringBuilder();
            StringBuilder strSql2 = new StringBuilder();
            if (model.WorkDetailsID != null)
            {
                strSql1.Append("WorkDetailsID,");
                strSql2.Append("" + model.WorkDetailsID + ",");
            }
            if (model.BarCode != null)
            {
                strSql1.Append("BarCode,");
                strSql2.Append("'" + model.BarCode + "',");
            }
            if (model.BarCode2 != null)
            {
                strSql1.Append("BarCode2,");
                strSql2.Append("'" + model.BarCode2 + "',");
            }
            if (model.工序 != null)
            {
                strSql1.Append("工序,");
                strSql2.Append("'" + model.工序 + "',");
            }
            if (model.数量 != null)
            {
                strSql1.Append("数量,");
                strSql2.Append("" + model.数量 + ",");
            }
            if (model.CreateUid != null)
            {
                strSql1.Append("CreateUid,");
                strSql2.Append("'" + model.CreateUid + "',");
            }
            if (model.CreateDate != null)
            {
                strSql1.Append("CreateDate,");
                strSql2.Append("'" + model.CreateDate + "',");
            }
            if (model.UpdateUid != null)
            {
                strSql1.Append("UpdateUid,");
                strSql2.Append("'" + model.UpdateUid + "',");
            }
            if (model.UpdateDate != null)
            {
                strSql1.Append("UpdateDate,");
                strSql2.Append("'" + model.UpdateDate + "',");
            }
            if (model.AuditUid != null)
            {
                strSql1.Append("AuditUid,");
                strSql2.Append("'" + model.AuditUid + "',");
            }
            if (model.AuditDate != null)
            {
                strSql1.Append("AuditDate,");
                strSql2.Append("'" + model.AuditDate + "',");
            }
            strSql.Append("insert into 工序流转(");
            strSql.Append(strSql1.ToString().Remove(strSql1.Length - 1));
            strSql.Append(")");
            strSql.Append(" values (");
            strSql.Append(strSql2.ToString().Remove(strSql2.Length - 1));
            strSql.Append(")");
            strSql.Append(";select @@IDENTITY");
            return (strSql.ToString());
        }

        /// <summary>
        /// 更新一条数据
        /// </summary>
        public string Update(TH.Model.工序流转 model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update 工序流转 set ");
            if (model.WorkDetailsID != null)
            {
                strSql.Append("WorkDetailsID=" + model.WorkDetailsID + ",");
            }
            else
            {
                strSql.Append("WorkDetailsID= null ,");
            }
            if (model.BarCode != null)
            {
                strSql.Append("BarCode='" + model.BarCode + "',");
            }
            else
            {
                strSql.Append("BarCode= null ,");
            }
            if (model.BarCode2 != null)
            {
                strSql.Append("BarCode2='" + model.BarCode2 + "',");
            }
            else
            {
                strSql.Append("BarCode2= null ,");
            }
            if (model.工序 != null)
            {
                strSql.Append("工序='" + model.工序 + "',");
            }
            else
            {
                strSql.Append("工序= null ,");
            }
            if (model.数量 != null)
            {
                strSql.Append("数量=" + model.数量 + ",");
            }
            else
            {
                strSql.Append("数量= null ,");
            }
            if (model.UpdateUid != null)
            {
                strSql.Append("UpdateUid='" + model.UpdateUid + "',");
            }
            else
            {
                strSql.Append("UpdateUid= null ,");
            }
            if (model.UpdateDate != null)
            {
                strSql.Append("UpdateDate='" + model.UpdateDate + "',");
            }
            else
            {
                strSql.Append("UpdateDate= null ,");
            }
            if (model.AuditUid != null)
            {
                strSql.Append("AuditUid='" + model.AuditUid + "',");
            }
            else
            {
                strSql.Append("AuditUid= null ,");
            }
            if (model.AuditDate != null)
            {
                strSql.Append("AuditDate='" + model.AuditDate + "',");
            }
            else
            {
                strSql.Append("AuditDate= null ,");
            }
            int n = strSql.ToString().LastIndexOf(",");
            strSql.Remove(n, 1);
            strSql.Append(" where WorkDetailsID=" + model.WorkDetailsID + " and BarCode2 = '" + model.BarCode2 + "' and 工序 = '" + model.工序 + "'");
            return (strSql.ToString());
        }

      
        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public TH.Model.工序流转 DataRowToModel(DataRow row)
        {
            TH.Model.工序流转 model = new TH.Model.工序流转();
            if (row != null)
            {
                if (row["iID"] != null && row["iID"].ToString() != "")
                {
                    model.iID = int.Parse(row["iID"].ToString());
                }
                if (row["BarCode"] != null)
                {
                    model.BarCode = row["BarCode"].ToString();
                }
                if (row["BarCode2"] != null)
                {
                    model.BarCode2 = row["BarCode2"].ToString();
                }
                if (row["工序"] != null)
                {
                    model.工序 = row["工序"].ToString();
                }
                if (row["数量"] != null && row["数量"].ToString() != "")
                {
                    model.数量 = decimal.Parse(row["数量"].ToString());
                }
                if (row["CreateUid"] != null)
                {
                    model.CreateUid = row["CreateUid"].ToString();
                }
                if (row["CreateDate"] != null && row["CreateDate"].ToString() != "")
                {
                    model.CreateDate = DateTime.Parse(row["CreateDate"].ToString());
                }
                if (row["UpdateUid"] != null)
                {
                    model.UpdateUid = row["UpdateUid"].ToString();
                }
                if (row["UpdateDate"] != null && row["UpdateDate"].ToString() != "")
                {
                    model.UpdateDate = DateTime.Parse(row["UpdateDate"].ToString());
                }
                if (row["AuditUid"] != null)
                {
                    model.AuditUid = row["AuditUid"].ToString();
                }
                if (row["AuditDate"] != null && row["AuditDate"].ToString() != "")
                {
                    model.AuditDate = DateTime.Parse(row["AuditDate"].ToString());
                }
            }
            return model;
        }


        #endregion  Method
    }
}

