using System;
using System.Collections.Generic;
using System.Web;
using System.Data;
using System.Data.OracleClient;
namespace TH.BaseClass
{
    public class OracleHelp
    {
        public static DataTable ExecuteDataTable(string commandText)
        {
            DataTable dt;
            try
            {
                Config con = new Config();
                OracleDataAdapter da;
                da = new OracleDataAdapter(commandText, con.ConnectionString);
                dt = new DataTable();
                da.Fill(dt);
                da.Dispose();
            }
            catch(Exception ee)
            {
                throw new ArgumentException(ee.Message + "Oracle连接不成功！");
            }
            return dt;
        }

        public static bool ExecuteNonQuery(string commandText)
        {
            bool returnValue = false;
            try
            {
                OracleConnection Con;
                OracleCommand Cmd;

                Config con = new Config();
                Con = new OracleConnection(con.ConnectionString);
                Cmd = new OracleCommand(commandText, Con);
                Con.Open();
                Cmd.ExecuteNonQuery();
                returnValue = true;

                Con.Close();
            }
            catch(Exception ee)
            {
                throw new ArgumentException(ee.Message + "Oracle连接不成功！");
            }
            return returnValue;
        }
    }
}