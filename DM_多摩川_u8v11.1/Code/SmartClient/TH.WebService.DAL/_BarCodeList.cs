using System;
using System.Data;
using System.Text;
using TH.WebService.BaseClass;
using System.Data.SqlClient;


namespace TH.WebService.DAL
{
    /// <summary>
    /// 数据访问类:_BarCodeList
    /// </summary>
    public partial class _BarCodeList
    {
        public _BarCodeList()
        { }

        /// <summary>
        /// 根据条形码获得详细信息
        /// </summary>
        /// <param name="sBarCode"></param>
        /// <returns></returns>
        public DataTable dtScanBarCode(string sBarCode)
        {
            string sSQL = @"
SELECT CAST('' as varchar(1)) as 选择
	  ,a.[iID]
      ,a.[BarCode] as 条形码
      ,a.[cInvCode] as 存货编码
      ,a.[cInvName] as 存货名称
      ,a.[cInvStd] as 规格型号
      ,a.[iQty] as 数量
      ,a.[PosCode] as 货位
      ,a.[Batch] as 批号
      ,a.[SerialNO] as 序列号
      ,a.[cWhName] as 仓库
      ,a.[ExType] as 单据类型
      ,a.[ExCode] as 单据号
      ,a.[ExRowNo] as 行号
      ,a.[ExVenCode] as 供应商编码
      ,a.[ExVenName] as 供应商
      ,a.[ExDepCode] as 部门编码
      ,a.[ExDepName] as 部门
      ,a.[ExQuantity] as 单据数量
      ,a.[ExBatchQty] as 包装批量
      ,a.[cWhCode] as 仓库编码
      ,a.[CreateUserName] as 打印人
      ,a.[CreateDate] as 打印日期
      ,a.[SysDate] as 系统日期
      ,a.[GUID] as 打印分批标识
      ,a.[XBarCode] as 箱码
      ,a.[valid] as 是否有效
      ,a.[Used] as 是否使用
      ,a.[ExsID] as 来源单据ID
      ,a.[ExcInvDefine4] as 重要度
      ,a.[ExcInvDefine5] as REV
      ,a.[ExsID] as 来源单据ID
      ,b.Qty as 可用量
FROM [_BarCodeList] a
    	left join 
		(
			select sum(case when isnull(RDType,0) = 1 then Qty when  isnull(RDType,0) = 2 then -1 * Qty else 0 end) as Qty,BarCode
			from (
					select b.Qty,b.sType,b.RdType,a.BarCode
			from dbo._BarCodeList a inner join dbo._BarCodeRD b on a.BarCode = b.BarCode
				inner join (select a.cCode,b.iRowno,b.autoid,b.cinvcode from rdrecord01 a inner join rdrecords01 b 
						on a.id = b.id) c on b.ExsID = c.autoid and c.cCode = b.ExCode and c.iRowno = b.ExRowNo and c.cInvCode = b.cInvCode
			where b.sType = '采购入库单'
				and isnull(a.valid,0) = 1 and isnull(a.Used,0) = 1 
			union all
			select b.Qty,b.sType,b.RdType,a.BarCode
			from dbo._BarCodeList a inner join dbo._BarCodeRD b on a.BarCode = b.BarCode
				inner join (select a.cCode,b.iRowno,b.autoid,b.cinvcode from rdrecord11 a inner join rdrecords11 b 
						on a.id = b.id) c on b.ExsID = c.autoid and c.cCode = b.ExCode and c.iRowno = b.ExRowNo and c.cInvCode = b.cInvCode
			where b.sType = '材料出库单'
				and isnull(a.valid,0) = 1 and isnull(a.Used,0) = 1 	
			union all
			select b.Qty,b.sType,b.RdType,a.BarCode
			from dbo._BarCodeList a inner join dbo._BarCodeRD b on a.BarCode = b.BarCode
				inner join (select a.cCode,b.iRowno,b.autoid,b.cinvcode from rdrecord08 a inner join rdrecords08 b 
						on a.id = b.id) c on b.ExsID = c.autoid and c.cCode = b.ExCode and c.iRowno = b.ExRowNo and c.cInvCode = b.cInvCode
			where b.sType = '其他入库单'
				and isnull(a.valid,0) = 1 and isnull(a.Used,0) = 1 
			union all
			select b.Qty,b.sType,b.RdType,a.BarCode
			from dbo._BarCodeList a inner join dbo._BarCodeRD b on a.BarCode = b.BarCode
				inner join (select a.cCode,b.iRowno,b.autoid,b.cinvcode from rdrecord09 a inner join rdrecords09 b 
						on a.id = b.id) c on b.ExsID = c.autoid and c.cCode = b.ExCode and c.iRowno = b.ExRowNo and c.cInvCode = b.cInvCode
			where b.sType = '其他出库单'
				and isnull(a.valid,0) = 1 and isnull(a.Used,0) = 1 
			union all
			select b.Qty,b.sType,b.RdType,a.BarCode
			from dbo._BarCodeList a inner join dbo._BarCodeRD b on a.BarCode = b.BarCode
				inner join (select a.cCode,b.iRowno,b.autoid,b.cinvcode from rdrecord10 a inner join rdrecords10 b 
						on a.id = b.id) c on b.ExsID = c.autoid and c.cCode = b.ExCode and c.iRowno = b.ExRowNo and c.cInvCode = b.cInvCode
			where b.sType = '产成品入库单'
				and isnull(a.valid,0) = 1

			union all
			select b.Qty,b.sType,b.RdType,a.BarCode
			from dbo._BarCodeList a inner join dbo._BarCodeRD b on a.BarCode = b.BarCode
				inner join (select a.cDLCode,b.iRowno,b.autoid,b.cinvcode from DispatchList a inner join DispatchLists b on a.DLID  = b.DLID ) c 
					on b.ExsID = c.autoid and c.cDLCode = b.ExCode and c.iRowno = b.ExRowNo and c.cInvCode = b.cInvCode
			where b.sType = '销售发货单'
				and isnull(a.valid,0) = 1 and isnull(a.Used,0) = 1 

	        union all
			select a.Qty,a.sType,a.RdType,a.BarCode
			from dbo._BarCodeRD a
			where a.sType = '历史条码打印'

             union all
			select a.Qty,a.sType,a.RdType,a.BarCode
			from dbo._BarCodeRD a
			where a.sType = '条码数量调整'

             union all
			select a.Qty,a.sType,a.RdType,a.BarCode
			from dbo._BarCodeRD a
			where a.sType = '期初'
			) b 
			group by BarCode
		) b on a.BarCode = b.BarCode
where 1=1
order by a.[BarCode]
            ";
            sSQL = sSQL.Replace("1=1", "1=1 and a.[BarCode] = '" + sBarCode + "'");
            return DbHelperSQL.Query(sSQL);
        }

        /// <summary>
        /// 判断条形码是否已经使用
        /// </summary>
        /// <param name="sBarCode"></param>
        /// <param name="sType"></param>
        /// <returns></returns>
        public int iBarCodeUsed(string sBarCode, string sType)
        {
            int iCou = -1;

            string sSQL = @"
SELECT count(1) as iCou
FROM _BarCodeRD
where 1=1
";
            if (sBarCode.Trim() != "")
            {
                sSQL = sSQL.Replace("1=1", "1=1 and [BarCode] = '" + sBarCode + "' ");
            }
            if (sType.Trim() != "")
            {
                sSQL = sSQL.Replace("1=1", "1=1 and [sType] = '" + sType + "' ");
            }

            DataTable dt = DbHelperSQL.Query(sSQL);

            if (dt != null && dt.Rows.Count > 0)
                iCou = BaseFunction.ReturnInt(dt.Rows[0][0]);

            if (iCou > 0)
                iCou = 1;

            return iCou;
        }

        public string sBarCodeQty(string sBarCode)
        {
            string sSQL = @"
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[_BarCodeQTyTemp]') AND type in (N'U'))
DROP TABLE [dbo].[_BarCodeQTyTemp]

CREATE TABLE [dbo].[_BarCodeQTyTemp](
	[Qty] [decimal](18, 6) NULL,
	[sType] [varchar](50) NULL,
	[RdType] [int] NULL
) ON [PRIMARY]

insert into _BarCodeQTyTemp
select b.Qty,b.sType,b.RdType
from dbo._BarCodeList a inner join dbo._BarCodeRD b on a.BarCode = b.BarCode
	inner join (select a.cCode,b.iRowno,b.autoid,b.cinvcode from rdrecord01 a inner join rdrecords01 b 
			on a.id = b.id) c on b.ExsID = c.autoid and c.cCode = b.ExCode and c.iRowno = b.ExRowNo and c.cInvCode = b.cInvCode
where b.sType = '采购入库单'
	and isnull(a.valid,0) = 1 and isnull(a.Used,0) = 1 
	and a.BarCode = '111111'
	
insert into _BarCodeQTyTemp
select b.Qty,b.sType,b.RdType
from dbo._BarCodeList a inner join dbo._BarCodeRD b on a.BarCode = b.BarCode
	inner join (select a.cCode,b.iRowno,b.autoid,b.cinvcode from rdrecord11 a inner join rdrecords11 b 
			on a.id = b.id) c on b.ExsID = c.autoid and c.cCode = b.ExCode and c.iRowno = b.ExRowNo and c.cInvCode = b.cInvCode
where b.sType = '材料出库单'
	and isnull(a.valid,0) = 1 and isnull(a.Used,0) = 1 
	and a.BarCode = '111111'

	
insert into _BarCodeQTyTemp
select b.Qty,b.sType,b.RdType
from dbo._BarCodeList a inner join dbo._BarCodeRD b on a.BarCode = b.BarCode
	inner join (select a.cCode,b.iRowno,b.autoid,b.cinvcode from rdrecord08 a inner join rdrecords08 b 
			on a.id = b.id) c on b.ExsID = c.autoid and c.cCode = b.ExCode and c.iRowno = b.ExRowNo and c.cInvCode = b.cInvCode
where b.sType = '其他入库单'
	and isnull(a.valid,0) = 1 and isnull(a.Used,0) = 1 
	and a.BarCode = '111111'


insert into _BarCodeQTyTemp
select b.Qty,b.sType,b.RdType
from dbo._BarCodeList a inner join dbo._BarCodeRD b on a.BarCode = b.BarCode
	inner join (select a.cCode,b.iRowno,b.autoid,b.cinvcode from rdrecord09 a inner join rdrecords09 b 
			on a.id = b.id) c on b.ExsID = c.autoid and c.cCode = b.ExCode and c.iRowno = b.ExRowNo and c.cInvCode = b.cInvCode
where b.sType = '其他出库单'
	and isnull(a.valid,0) = 1 and isnull(a.Used,0) = 1 
	and a.BarCode = '111111'
	
	
insert into _BarCodeQTyTemp
select b.Qty,b.sType,b.RdType
from dbo._BarCodeList a inner join dbo._BarCodeRD b on a.BarCode = b.BarCode
	inner join (select a.cCode,b.iRowno,b.autoid,b.cinvcode from rdrecord10 a inner join rdrecords10 b 
			on a.id = b.id) c on b.ExsID = c.autoid and c.cCode = b.ExCode and c.iRowno = b.ExRowNo and c.cInvCode = b.cInvCode
where b.sType = '产成品入库单'
	and isnull(a.valid,0) = 1
	and a.BarCode = '111111'
	
insert into _BarCodeQTyTemp
select b.Qty,b.sType,b.RdType
from dbo._BarCodeList a inner join dbo._BarCodeRD b on a.BarCode = b.BarCode
	inner join (select a.cDLCode,b.iRowno,b.autoid,b.cinvcode from DispatchList a inner join DispatchLists b on a.DLID  = b.DLID ) c 
		on b.ExsID = c.autoid and c.cDLCode = b.ExCode and c.iRowno = b.ExRowNo and c.cInvCode = b.cInvCode
where b.sType = '销售发货单'
	and isnull(a.valid,0) = 1 and isnull(a.Used,0) = 1 
	and a.BarCode = '111111'
	

insert into _BarCodeQTyTemp
select a.Qty,a.sType,a.RdType
from dbo._BarCodeRD a
where a.sType = '历史条码打印' and a.BarCode = '111111'
             

insert into _BarCodeQTyTemp
select a.Qty,a.sType,a.RdType
from dbo._BarCodeRD a
where a.sType = '期初' and a.BarCode = '111111'
             

insert into _BarCodeQTyTemp
select a.Qty,a.sType,a.RdType
from dbo._BarCodeRD a
where a.sType = '条码数量调整' and a.BarCode = '111111'

select sum(case when isnull(RDType,0) = 1 then Qty when  isnull(RDType,0) = 2 then -1 * Qty else 0 end) as Qty
from _BarCodeQTyTemp a
";
            sSQL = sSQL.Replace("111111", sBarCode);
            return sSQL;
        }

        /// <summary>
        /// 计算条形码可用量(采购入库单 + 产品入库单 - 材料出库单 - 销售出库单，对应单据不匹配认为该条码失效
        /// </summary>
        /// <param name="sBarCode"></param>
        /// <param name="sType"></param>
        /// <returns></returns>
        public decimal dBarCodeQty(string sBarCode)
        {
            decimal d = 0;

            string sSQL = sBarCodeQty(sBarCode);
            DataTable dt = DbHelperSQL.Query(sSQL);

            if (dt != null && dt.Rows.Count > 0)
                d = BaseFunction.ReturnDecimal(dt.Rows[0][0]);

            return d;
        }

        /// <summary>
        /// 判断条形码是否已经使用过（多次保存单据，判断记录表里是否已经有该条码）
        /// </summary>
        /// <param name="sType"></param>
        /// <param name="ExsID"></param>
        /// <param name="BarCode"></param>
        /// <param name="RDType"></param>
        /// <returns></returns>
        public int iChkBarCodeUsed(string sType,string sCode,string BarCode,int RDType)
        {
            int iCou = 0;
            string sSQL = "select * from _BarCodeRD where sType = '" + sType + "' and ExCode = '" + sCode + "' and BarCode = '" + BarCode + "' and RDType = " + RDType;
            DataTable dt = DbHelperSQL.Query(sSQL);
            if (dt != null && dt.Rows.Count > 0)
            {
                iCou = dt.Rows.Count;
            }
            return iCou;
        }

        /// <summary>
        /// 条形码作废
        /// </summary>
        /// <param name="dt"></param>
        /// <returns></returns>
        public int iBarCodeInvalid(DataTable dt)
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
                    for (int i = 0; i < dt.Rows.Count; i++)
                    {
                        string sSQL = "update [_BarCodeList] set [valid] = 0,Used = 1,XBarCode = null where [BarCode] = '" + dt.Rows[i]["条形码"].ToString().Trim() + "'";
                        iCou = iCou + DbHelperSQL.ExecuteNonQuery(tran, CommandType.Text, sSQL);
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
                throw new Exception(ee.Message);
            }
            return iCou;
        }

        /// <summary>
        /// 装箱
        /// </summary>
        /// <param name="dt"></param>
        /// <returns></returns>
        public int iBarCodeBox(string sBoxCode,DataTable dtBarCode)
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
                    string sSQL = "";
                    for (int i = 0; i < dtBarCode.Rows.Count; i++)
                    {
                        sSQL = "update [_BarCodeList] set [XBarCode] = '" + sBoxCode + "',Used = 1 where [BarCode] = '" + dtBarCode.Rows[i]["条形码"].ToString().Trim() + "' and isnull(valid,0) = 1";
                        iCou = iCou + DbHelperSQL.ExecuteNonQuery(tran, CommandType.Text, sSQL);
                    }


                    sSQL = "update [_BarCodeList] set [Used] = 1 where [BarCode] = '" + sBoxCode + "'";
                    DbHelperSQL.ExecuteNonQuery(tran, CommandType.Text, sSQL);
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

        /// <summary>
        /// 拆箱
        /// </summary>
        /// <param name="dt"></param>
        /// <returns></returns>
        public int iBarCodeUnBox(string sBoxCode)
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
                    string sSQL = "update [_BarCodeList] set XBarCode = null where [XBarCode] = '" + sBoxCode + "' and isnull(valid,0) = 1";
                    iCou = iCou + DbHelperSQL.ExecuteNonQuery(tran, CommandType.Text, sSQL);

                    sSQL = "update [_BarCodeList] set [Used] = 0 where [BarCode] = '" + sBoxCode + "' and isnull(valid,0) = 1";
                    DbHelperSQL.ExecuteNonQuery(tran, CommandType.Text, sSQL);
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


        /// <summary>
        /// 根据箱码查看条形码
        /// </summary>
        /// <param name="sBarCode"></param>
        /// <returns></returns>
        public DataTable dtSBoxBarCode(string sBoxCode)
        {
            string sSQL = @"
select 
    CAST('' as varchar(1)) as 选择
	  ,[iID]
      ,[BarCode] as 条形码
      ,[cInvCode] as 存货编码
      ,[cInvName] as 存货名称
      ,[cInvStd] as 规格型号
      ,[iQty] as 数量
      ,[PosCode] as 货位
      ,[Batch] as 批号
      ,[SerialNO] as 序列号
      ,[cWhName] as 仓库
      ,[ExType] as 单据类型
      ,[ExCode] as 单据号
      ,[ExRowNo] as 行号
      ,[ExVenCode] as 供应商编码
      ,[ExVenName] as 供应商
      ,[ExDepCode] as 部门编码
      ,[ExDepName] as 部门
      ,[ExQuantity] as 单据数量
      ,[ExBatchQty] as 包装批量
      ,[cWhCode] as 仓库编码
      ,[CreateUserName] as 打印人
      ,[CreateDate] as 打印日期
      ,[SysDate] as 系统日期
      ,[GUID] as 打印分批标识
      ,[XBarCode] as 箱码
      ,[valid] as 是否有效
      ,[Used] as 是否使用
      ,[ExsID] as 来源单据ID
from _BarCodeList
where XBarCode = '111111'
    and isnull(valid,0) = 1
order by BarCode
            ";
            sSQL = sSQL.Replace("111111", sBoxCode);
            return DbHelperSQL.Query(sSQL);
        }


        /// <summary>
        /// 根据箱码查看存货
        /// </summary>
        /// <param name="sBarCode"></param>
        /// <returns></returns>
        public DataTable dtSBoxInvCode(string sBoxCode)
        {
            string sSQL = @"
select cInvCode as 存货编码,cInvName as 存货名称,cInvStd as 规格型号,sum(iQty) as 数量
from _BarCodeList
where XBarCode = '111111'
    and isnull(valid,0) = 1
group by cInvCode,cInvName,cInvStd
order by cInvCode
            ";
            sSQL = sSQL.Replace("111111", sBoxCode);
            return DbHelperSQL.Query(sSQL);
        }
    }
}
