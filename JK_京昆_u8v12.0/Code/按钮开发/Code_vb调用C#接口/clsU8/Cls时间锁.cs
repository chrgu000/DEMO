using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;

namespace clsU8
{
    public class Cls时间锁
    {
        public bool bchk时间锁(string Conn)
        {
            DateTime d时间锁 = Convert.ToDateTime("2016-11-1");
            string sSQL2 = "select getdate()";
            DateTime d当前日期 = Convert.ToDateTime(SqlHelper.ExecuteScalar(Conn, CommandType.Text, sSQL2));

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
