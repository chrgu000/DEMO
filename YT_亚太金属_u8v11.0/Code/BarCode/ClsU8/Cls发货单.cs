using System;
using System.Collections.Generic;
using System.Web;
using System.Data;
using System.Collections;
using System.Data.SqlClient;
using ClsBaseClass;

namespace ClsU8
{
    public class Cls发货单
    {

        public string dt发货单信息(string sCode)
        {
            string s = "";

            try
            {
                string sSQL = "select * from DispatchList a inner join DispatchLists b on a.DLID = b.DLID where cDLCode = '" + sCode.Trim() + "' and isnull(a.bReturnFlag,0) = 0 and isnull(a.cCloser,'') = '' and isnull(a.cVerifier ,'') <> '' ";
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
