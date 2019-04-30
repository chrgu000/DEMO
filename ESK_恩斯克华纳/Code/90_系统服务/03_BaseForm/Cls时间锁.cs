using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;

namespace 系统服务
{
    public class Cls时间锁
    {
        public bool bchk时间锁()
        {
            系统服务.ClsDataBase clsSQLCommond = 系统服务.ClsDataBaseFactory.Instance();
            DateTime d时间锁 = Convert.ToDateTime("2020-1-1");
            string sSQL = "select getdate()";
            DateTime d当前日期 = Convert.ToDateTime(clsSQLCommond.ExecQuery(sSQL).Rows[0][0]);

            if (d当前日期 > d时间锁)
            {
                return false;
            }
            else
            {
                return true;
            }
        }

    }
}
