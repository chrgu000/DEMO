using ClsBaseClass;
using System;
using System.Data;
namespace ClsU8.Query
{
    public class ClsBuckUpDataBase
    {
        protected ClsDataBase clsSQLCommond = ClsDataBaseFactory.Instance();
        public bool BuckUpDataBase(string sPathInfo)
        {
            bool b = false;
            try
            {
                string sSQL = string.Concat(new string[]
				{
					"BACKUP DATABASE [",
					ClsBaseDataInfo.sDataBaseName,
					"] TO  DISK = N'",
					sPathInfo,
					"' WITH NOFORMAT, NOINIT,  NAME = N'TH_Test-完整 数据库 备份',  SKIP, NOREWIND, NOUNLOAD,  STATS = 10"
				});
                this.clsSQLCommond.ExecSql(sSQL);
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
            DataTable result;
            try
            {
                string sSQL = "select host_name() as sHostName,@@SERVERname as sSerName  ";
                result = this.clsSQLCommond.ExecQuery(sSQL);
            }
            catch
            {
                throw new Exception("获得服务器名称失败！");
            }
            return result;
        }
    }
}
