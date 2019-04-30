using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;

namespace ClsU8
{
    public class ClsU8基础档案
    {
        public string dt存货信息(string sInvCode)
        {
            string s = "";

            try
            {
                string sSQL = "select a.*,b.cInvCName,c.iChangRate from Inventory a left join InventoryClass b on a.cInvCCode =b.cInvCCode left join ComputationUnit c on a.cCAComUnitCode=c.ccomunitcode where cInvCode like '%" + sInvCode + "%'";
                DataTable dt = ClsBaseClass.SqlHelper.ExecuteDataset(ClsBaseClass.ClsBaseDataInfo.sConnString, CommandType.Text, sSQL).Tables[0];
                s = ClsBaseClass.Cls序列化.SerializeDataTableXml(dt);
            }
            catch (Exception ee)
            {

            }
            return s;
        }

        public string s货仓(string sWhCode)
        {
            string s = "";
            try
            {
                string sSQL = "select a.cWhCode,a.cWhName,b.cPosCode,b.cPosName,isnull(a.bWhPos,0) as bWhPos  " +
                                "from Warehouse a inner join Position b on a.cWhCode = b.cWhCode  and ISNULL(b.bPosEnd ,0) = 1  " +
                                "where  ISNULL(bPosEnd ,0) = 1 and (cPosCode = '" + sWhCode + "' or cPosName = '" + sWhCode + "') ";
                DataTable dt = ClsBaseClass.SqlHelper.ExecuteDataset(ClsBaseClass.ClsBaseDataInfo.sConnString, CommandType.Text, sSQL).Tables[0];
                if (dt != null && dt.Rows.Count > 0)
                {
                    s = ClsBaseClass.Cls序列化.SerializeDataTableXml(dt);
                }
                else
                {
                    sSQL = "select cWhCode,cWhName,null as cPosCode,null as cPosName,isnull(bWhPos,0) as bWhPos  " +
                            "from Warehouse " +
                            "where cWhCode = '" + sWhCode + "' or cWhName = '" + sWhCode + "' ";
                    dt = ClsBaseClass.SqlHelper.ExecuteDataset(ClsBaseClass.ClsBaseDataInfo.sConnString, CommandType.Text, sSQL).Tables[0];
                    s = ClsBaseClass.Cls序列化.SerializeDataTableXml(dt);
                }
            }
            catch (Exception ee)
            {

            }
            return s;
        }


        public decimal d仓库现存量(string sInvCode, string sBatch, string sFree1, string sFree2, string sFree3, string sFree4, string sWhCode)
        {
            decimal d = 0;
            try
            {
                string sSQL = "select sum(iquantity) as iQty from currentstock " +
                              " where cInvCode = '" + sInvCode + "' and cWhcode= '" + sWhCode + "' and isnull(cbatch,'') = '" + sBatch + "' and isnull(cfree1,'') = '" + sFree1 + "' and isnull(cfree2,'') = '" + sFree2 + "' and isnull(cfree3,'') = '" + sFree3 + "' and isnull(cfree4,'') = '" + sFree4 + "'";
                d = ClsBaseClass.ClsBaseDataInfo.ReturnObjectToDecimal(ClsBaseClass.SqlHelper.ExecuteScalar(ClsBaseClass.ClsBaseDataInfo.sConnString, CommandType.Text, sSQL));
            }
            catch { }
            return d;
        }

        public decimal d货位现存量(string sInvCode, string sBatch, string sFree1, string sFree2, string sFree3, string sFree4, string sWhPos)
        {
            decimal d = 0;
            try
            {
                string sSQL = "select SUM(iQuantity) as iQty from InvPositionSum " +
                              " where cInvCode = '" + sInvCode + "' and cPoscode= '" + sWhPos + "' and isnull(cbatch,'') = '" + sBatch + "' and isnull(cfree1,'') = '" + sFree1 + "' and isnull(cfree2,'') = '" + sFree2 + "' and isnull(cfree3,'') = '" + sFree3 + "' and isnull(cfree4,'') = '" + sFree4 + "'";
                d = ClsBaseClass.ClsBaseDataInfo.ReturnObjectToDecimal(ClsBaseClass.SqlHelper.ExecuteScalar(ClsBaseClass.ClsBaseDataInfo.sConnString, CommandType.Text, sSQL));
            }
            catch { }
            return d;
        }

        public string s货位(string sWhPos)
        {
            string s = "";
            try
            {
                string sSQL = @"
 select a.cinvcode as 存货编码,sum(a.iQuantity) as 数量 ,sum(a.inum)  as 件数,b.cInvName as 存货名称,b.cInvStd as 规格型号,a.cPoscode as 货位,
  d.cWhCode  as 仓库,cBatch  as 批号 ,c.cPosName  as 货位名称,
  d.cWhName  as 仓库名称,a.cFree1 as 材质,a.cFree2 as 渗层,a.cFree3 as 统一号,a.cFree4 as 工艺要求   from InvPositionSum a left join Inventory b on a.cinvcode=b.cinvcode
   left join Position  c on a.cPosCode =c.cPosCode left join Warehouse d on a.cWhCode =d.cWhCode where a.cPoscode= '" + sWhPos + "'"+
  "  group by a.cinvcode,b.cInvName,b.cInvStd,a.cPoscode,d.cWhCode,cBatch,c.cPosName,d.cWhName,a.cFree1,a.cFree2,a.cFree3,a.cFree4 order by sum(a.iQuantity) desc";
                DataTable dt = ClsBaseClass.SqlHelper.ExecuteDataset(ClsBaseClass.ClsBaseDataInfo.sConnString, CommandType.Text, sSQL).Tables[0];
                if (dt != null && dt.Rows.Count > 0)
                {
                    s = ClsBaseClass.Cls序列化.SerializeDataTableXml(dt);
                }
            }
            catch { }
            {
            }
            return s;
        }

        public string s仓库(string sAutoID)
        {
            string s = "";
            try
            {
                string sSQL = @"

select a.cInvCode as 存货编码,a.cBatch  as 批号,a.cFree1 as 材质,a.cFree2 as 渗层,a.cFree3 as 统一号,a.cFree4 as 工艺要求,a.iQuantity as 数量 ,a.inum  as 件数,a.cPosCode as 货位,a.cWhCode as 仓库 ,b.cInvName as 存货名称,b.cInvStd as 规格型号,c.cPosName  as 货位名称,d.cWhName  as 仓库名称 
from  InvPositionSum a  left join Inventory b on a.cinvcode=b.cinvcode 
left join Position  c on a.cPosCode =c.cPosCode left join Warehouse d on a.cWhCode =d.cWhCode 
where a.cInvCode in (select cInvCode from _BarCodeInventory where AutoID =  '" + sAutoID + "')";
                DataTable dt = ClsBaseClass.SqlHelper.ExecuteDataset(ClsBaseClass.ClsBaseDataInfo.sConnString, CommandType.Text, sSQL).Tables[0];
                if (dt != null && dt.Rows.Count > 0)
                {
                    s = ClsBaseClass.Cls序列化.SerializeDataTableXml(dt);
                }
            }
            catch { }
            {
            }
            return s;
        }

        public string Chk货位是否存在(string sWhPos)
        {
            string s = "";

            try
            {
                string sSQL = "select count(1) from Position where ( cPosCode = '" + sWhPos + "' or cPosName= '" + sWhPos + "')";
                s = ClsBaseClass.SqlHelper.ExecuteScalar(ClsBaseClass.ClsBaseDataInfo.sConnString, CommandType.Text, sSQL).ToString();
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
           select MAX(id) as id,MAX(autoid) as autoid
from
(
select MAX(id) as id,MAX(autoid) as autoid from dbo.rdrecords01
union all
select MAX(id) as id,MAX(autoid) as autoid from dbo.rdrecords08
union all
select MAX(id) as id,MAX(autoid) as autoid from dbo.rdrecords09
union all
select MAX(id) as id,MAX(autoid) as autoid from dbo.rdrecords10
union all
select MAX(id) as id,MAX(autoid) as autoid from dbo.rdrecords11
union all
select MAX(id) as id,MAX(autoid) as autoid from dbo.rdrecords32
union all
select MAX(id) as id,MAX(autoid) as autoid from dbo.rdrecords34
)a 
            ";

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

        public string dt存货条码信息(string sBarCode)
        {
            string s = "";
            try
            {
                string sSQL = @"
select a.*, b.cInvName,b.cInvStd,b.bInvBatch 
from _BarCodeInventory a inner join Inventory b on a.cInvCode = b.cInvCode 	
where a.AutoID  = '333333'
";
                sSQL = sSQL.Replace("333333", sBarCode);

                DataTable dt = ClsBaseClass.SqlHelper.ExecuteDataset(ClsBaseClass.ClsBaseDataInfo.sConnString, CommandType.Text, sSQL).Tables[0];
                s = ClsBaseClass.Cls序列化.SerializeDataTableXml(dt);
            }
            catch (Exception ee)
            {
                s = "0" + ee.Message;
            }
            return s;
        }
    }
}
