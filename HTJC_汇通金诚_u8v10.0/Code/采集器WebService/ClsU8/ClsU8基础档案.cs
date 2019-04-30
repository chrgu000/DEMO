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
                string sSQL = "select top 50 * from Inventory where cInvCode = '" + sInvCode + "'";
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
                            "where cWhCode = '" + sWhCode + "' or cWhName = '" + sWhCode + "'  ";
                    dt = ClsBaseClass.SqlHelper.ExecuteDataset(ClsBaseClass.ClsBaseDataInfo.sConnString, CommandType.Text, sSQL).Tables[0];
                    s = ClsBaseClass.Cls序列化.SerializeDataTableXml(dt);
                }
            }
            catch (Exception ee)
            {

            }
            return s;
        }

        public decimal d仓库现存量(string sInvCode, string sBatch, string sFree1,string sWhCode)
        {
            decimal d = 0;
            try
            {
                string sSQL = "select sum(iquantity) as iQty from currentstock " +
                              " where cInvCode = '" + sInvCode + "' and cWhcode= '" + sWhCode + "' and isnull(cbatch,'') = '" + sBatch + "' and isnull(cfree1,'') = '" + sFree1 + "'";
                d = ClsBaseClass.ClsBaseDataInfo.ReturnObjectToDecimal(ClsBaseClass.SqlHelper.ExecuteScalar(ClsBaseClass.ClsBaseDataInfo.sConnString, CommandType.Text, sSQL));
            }
            catch { }
            return d;
        }

        public decimal d货位现存量(string sInvCode, string sBatch, string sFree1, string sWhPos)
        {
            decimal d = 0;
            try
            {
                string sSQL = "select SUM(iQuantity) as iQty from InvPositionSum " +
                              " where cInvCode = '" + sInvCode + "' and cPoscode= '" + sWhPos + "' and isnull(cbatch,'') = '" + sBatch + "' and isnull(cfree1,'') = '" + sFree1 + "'";
                d = ClsBaseClass.ClsBaseDataInfo.ReturnObjectToDecimal(ClsBaseClass.SqlHelper.ExecuteScalar(ClsBaseClass.ClsBaseDataInfo.sConnString, CommandType.Text, sSQL));
            }
            catch { }
            return d;
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
    }
}
