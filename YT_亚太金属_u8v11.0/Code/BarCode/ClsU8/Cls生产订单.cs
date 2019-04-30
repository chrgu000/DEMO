using System;
using System.Collections.Generic;
using System.Web;
using System.Data;
using System.Collections;
using System.Data.SqlClient;
using ClsBaseClass;

namespace ClsU8
{
    public class Cls生产订单
    {
      
        public string dt生产订单信息(string sCode,string sRowNo)
        {
            string s = "";

            try
            {
                string sSQL = "select * from mom_order a inner join mom_orderdetail b on a.moid = b.moid where a.mocode = '" + sCode.Trim() + "'  ";
                if (sRowNo != "")
                {
                    sSQL = sSQL + " and b.SortSeq = '" + sRowNo + "'";
                }
                DataTable dt = SqlHelper.ExecuteDataset(ClsBaseDataInfo.sConnString, CommandType.Text, sSQL).Tables[0];
                s = Cls序列化.SerializeDataTableXml(dt);
            }
            catch (Exception ee)
            {
                s = ee.Message;
            }
            return s;
        }


        public string dt生产订单子件信息(string sCode, string sRowNo,string sInvCode)
        {
            string s = "";

            try
            {
                string sSQL = "select * from mom_order a inner join mom_orderdetail b on a.moid = b.moid inner join mom_moallocate c on c.MoDId  = b.Modid where a.mocode = '" + sCode.Trim() + "' and b.SortSeq = '" + sRowNo + "' and c.InvCode = '" + sInvCode + "'";
                DataTable dt = SqlHelper.ExecuteDataset(ClsBaseDataInfo.sConnString, CommandType.Text, sSQL).Tables[0];
                s = Cls序列化.SerializeDataTableXml(dt);
            }
            catch (Exception ee)
            {
                s = ee.Message;
            }
            return s;
        }

        public string dt生产订单子件未出库信息(string sCode, string sRow)
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
from (
					select a.cCode,b.irowno,b.cInvCode,b.iQuantity,b.iNum,b.cBatch,b.cBatchProperty6 ,b.cFree1,b.cFree2,b.cFree3,b.cFree4,b.cFree5,b.cFree6,b.cFree7,b.cFree8,b.cFree9,b.cFree10   
					from rdrecord11 a inner join rdrecords11 b on a.id = b.ID
				) f on  a.cInvCode = f.cInvCode --and ISNULL(a.cFree1,'') = ISNULL(f.cFree1,'')
	inner join Inventory b on a.cInvCode = b.cInvCode 	
	left join (
					select c.InvCode as 子件编码, c.qty,c.issQty,c.Qty - isnull(c.issQty,0) as 未领数量,c.LotNo  ,b.Free1,b.Free2,b.Free3,b.Free4,b.Free5,b.Free6,b.Free7,b.Free8,b.Free9,b.Free10
                    from mom_order a inner join mom_orderdetail b on a.moid = b.moid inner join mom_moallocate c on c.MoDId  = b.Modid 
                    where a.mocode = '111111' and b.SortSeq = '222222' 
				) e on e.子件编码 = a.cInvCode 
                  and ISNULL(a.cFree1,'') = ISNULL(f.cFree1,'')
        and ISNULL(a.cFree2,'') = ISNULL(f.cFree2,'') and ISNULL(a.cFree3,'') = ISNULL(f.cFree3,'') and ISNULL(a.cFree4,'') = ISNULL(f.cFree4,'') and ISNULL(a.cFree5,'') = ISNULL(f.cFree5,'')
       and ISNULL(a.cFree6,'') = ISNULL(f.cFree6,'') and ISNULL(a.cFree7,'') = ISNULL(f.cFree7,'') and ISNULL(a.cFree8,'') = ISNULL(f.cFree8,'') and ISNULL(a.cFree9,'') = ISNULL(f.cFree9,'')
       and ISNULL(a.cFree10,'') = ISNULL(f.cFree10,'') and ISNULL(a.cbatch,'') = ISNULL(f.cbatch,'')
where a.AutoID  = '333333' and e.未领数量>0
";


                sSQL = sSQL.Replace("111111", sCode);
                sSQL = sSQL.Replace("222222", sRow);

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
