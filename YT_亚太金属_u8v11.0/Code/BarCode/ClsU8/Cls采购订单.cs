using System;
using System.Collections.Generic;
using System.Web;
using System.Data;
using System.Collections;
using System.Data.SqlClient;
using ClsBaseClass;

namespace ClsU8
{
    public class Cls采购订单
    {

        public string dt采购订单信息(string sCode)
        {
            string s = "";

            try
            {
                string sSQL = "select * from PO_Pomain a inner join PO_Podetails b on a.POID = b.POID where a.cPOID = '" + sCode.Trim() + "' ";
                DataTable dt = SqlHelper.ExecuteDataset(ClsBaseDataInfo.sConnString, CommandType.Text, sSQL).Tables[0];
                s = Cls序列化.SerializeDataTableXml(dt);
            }
            catch (Exception ee)
            {
                s = ee.Message;
            }
            return s;
        }

        public string dt采购条码信息(string sBarCode, string sCode)
        {
            string s = "";
            try
            {
                string sSQL = @"
select a.*,b.cInvName,b.cInvStd,b.bInvBatch,e.cVenCode,e.iQuantity,e.iReceivedQTY,e.iQuantity - isnull(e.iReceivedQTY,0) as iQty
from 条形码信息 a inner join Inventory b on a.存货编码 = b.cInvCode 	
	inner join (
					select c.cVenCode,d.cInvCode,sum(d.iQuantity) as iQuantity,SUM(isnull(iReceivedQTY,0)) as iReceivedQTY 
					from PO_Pomain c inner join PO_Podetails d on c.POID = d.POID 
					where c.cPOID = '111111' 
					group by c.cVenCode,d.cInvCode
				) e on e.cInvCode = a.存货编码
where a.条形码  = '222222'
";

                sSQL = sSQL.Replace("111111", sCode);
                sSQL = sSQL.Replace("222222", sBarCode);

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
