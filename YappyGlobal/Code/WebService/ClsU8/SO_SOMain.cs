using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using ClsBaseClass;
using System.Data.SqlClient;

namespace ClsU8
{
    public class SO_SOMain
    {
        //ClsDataBase clsSQL = ClsDataBaseFactory.Instance();
        public string Update_SO_ScanStatus(SqlTransaction tran,string sSOCodeStatus)
        {
            string sReturn = "";
            try
            {
                if (sSOCodeStatus.Trim() == string.Empty || sSOCodeStatus.Trim() == string.Empty)
                    throw new Exception("没有需要保存的数据");

                string[] s = sSOCodeStatus.Split('◆');
                if(s.Length <2)
                    throw new Exception("没有需要保存的数据");

                string sSOCode = s[0].Trim();
                string sStatus = s[1].Trim();

                if(sSOCode == "" || sStatus == "")
                    throw new Exception("没有需要保存的数据");


                string sAccID = ClsBaseClass.ClsBaseDataInfo.sDataBaseName.Trim().Substring(7, 3);

                string sSQL = "update so_somain set cDefine5 = '{0}' where cSoCode = '{1}'";
                sSQL = string.Format(sSQL, sStatus, sSOCode);
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
        }
    }
}

