using System;
using System.Collections.Generic;
using System.Text;
using System.Data;

namespace 系统服务.Query
{
    class ClsBuckUpDataBase
    {
        系统服务.ClsDataBase clsSQLCommond;

        public ClsBuckUpDataBase()
        {
            clsSQLCommond = 系统服务.ClsDataBaseFactory.Instance();
        }

        public bool BuckUpDataBase(string sPathInfo)
        {
            bool b = false;
            try
            {
                string sSQL = "BACKUP DATABASE [" + 系统服务.ClsBaseDataInfo.sDataBaseName + "] TO  DISK = N'" + sPathInfo + "' " +
	                            "WITH NOFORMAT, NOINIT,  NAME = N'TH_Test-完整 数据库 备份',  " +
	                            "SKIP, NOREWIND, NOUNLOAD,  STATS = 10";
                clsSQLCommond.ExecSql(sSQL);
                b = true;
            }
            catch
            {
                throw new Exception("备份数据库操作失败！");
            }
            return b;
        }


        public DateTime GetSerTime()
        {
            DateTime dTime;
            try
            {
                string sSQL = "select getdate() as sTime ";
                dTime = Convert.ToDateTime(clsSQLCommond.ExecGetScalar(sSQL));
            }
            catch
            {
                throw new Exception("获得服务器时间失败！");
            }
            return dTime;
        }

        public DataTable GetSerHostName()
        {
            try
            {
                string sSQL = "select host_name() as sHostName,@@SERVERname as sSerName  ";
                return clsSQLCommond.ExecQuery(sSQL);
            }
            catch
            {
                throw new Exception("获得服务器名称失败！");
            }
        }
    }
}
