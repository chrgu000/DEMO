using System;
using System.Collections.Generic;
using System.Web;
using System.Data;
using System.Collections;
using System.Data.SqlClient;
using ClsBaseClass;

namespace ClsU8
{
    public class Cls销售订单
    {

        public string dt销售订单信息(string sCode)
        {
            string s = "";

            try
            {
                string sSQL = "select * from SO_SOMain a inner join SO_SODetails b on a.cSOCode  = b.cSOCode  where a.cSOCode  = '" + sCode.Trim() + "' ";
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
