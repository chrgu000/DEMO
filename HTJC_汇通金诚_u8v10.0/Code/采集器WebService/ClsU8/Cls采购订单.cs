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
    }
}
