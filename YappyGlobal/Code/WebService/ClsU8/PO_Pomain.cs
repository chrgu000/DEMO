using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using ClsBaseClass;
using System.Data.SqlClient;

namespace ClsU8
{
    public class PO_Pomain
    {
        public string Update_PO_ScanStatus(SqlTransaction tran, string sPOCodeStatus)
        {
            string sReturn = "";
            try
            {
                if (sPOCodeStatus.Trim() == string.Empty || sPOCodeStatus.Trim() == string.Empty)
                    throw new Exception("没有需要保存的数据");

                string[] s = sPOCodeStatus.Split('◆');
                if (s.Length < 2)
                    throw new Exception("没有需要保存的数据");

                string sPOCode = s[0].Trim();
                string sStatus = s[1].Trim();

                if (sPOCode == "" || sStatus == "")
                    throw new Exception("没有需要保存的数据");


                string sAccID = ClsBaseClass.ClsBaseDataInfo.sDataBaseName.Trim().Substring(7, 3);

                string sSQL = "update PO_Pomain set cDefine5 = '{0}' where cPOID = '{1}'";
                sSQL = string.Format(sSQL, sStatus, sPOCode);
                int iCou = DbHelperSQL.ExecuteNonQuery(tran, CommandType.Text, sSQL);

                if (iCou > 0)
                {
                    sReturn = "OK";
                }
                else
                {
                    throw new Exception("no data");
                }
            }
            catch (Exception ee)
            {
                sReturn = "Err:" + ee.Message;
            }
            return sReturn;

            //string s = "";
            //try
            //{
            //    if (sPOCode.Trim() == string.Empty || sSatus.Trim() == string.Empty)
            //        throw new Exception("没有需要保存的数据");

            //    string sAccID = ClsBaseClass.ClsBaseDataInfo.sDataBaseName.Trim().Substring(7, 3);

            //    string sSQL = "update PO_Pomain set cDefine1 = '{0}' where cPOID = '{1}'";
            //    sSQL = string.Format(sSQL, sPOCode, sSatus);
            //    int iCou = DbHelperSQL.ExecuteSql(sPOCode);

            //    if (iCou > 0)
            //    {
            //        s = "OK";
            //    }
            //    else
            //    {
            //        throw new Exception("no data");
            //    }
            //}
            //catch (Exception ee)
            //{
            //    s = "Err:" + ee.Message;
            //}
            //return s;
        }
    }
}

