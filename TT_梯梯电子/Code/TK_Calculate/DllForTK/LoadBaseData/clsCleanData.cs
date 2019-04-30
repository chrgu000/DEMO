using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using TH.BaseClass;

namespace DllForTK
{
    public class clsCleanData
    {
        public string CleanData()
        {
            try
            {
                SqlConnection conn = new SqlConnection(DbHelperSQL.connectionString);
                conn.Open();
                //启用事务
                SqlTransaction tran = conn.BeginTransaction();

                try
                {
                    string sSQL = @"
exec CleanData
";
                    int iCou = DbHelperSQL.ExecuteNonQuery(tran, CommandType.Text, sSQL);
                    tran.Commit();
                }
                catch (Exception ee)
                {
                    tran.Rollback();
                    throw new Exception(ee.Message);
                }

            }
            catch (Exception ee)
            {
                return ee.Message;
            }

            return "";
        }
    }
}
