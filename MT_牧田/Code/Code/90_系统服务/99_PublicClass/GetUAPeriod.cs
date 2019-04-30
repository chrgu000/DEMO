using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Windows.Forms;

namespace 系统服务
{
    public class GetUAPeriod
    {
        public void GetPeriod(string p, out string sdate, out string edate)
        {
            string sSQL = "";
            系统服务.ClsDataBase clsSQLCommond = 系统服务.ClsDataBaseFactory.Instance();
            sSQL = @"select * from UfSystem.dbo.UA_Period where iYear='" + 系统服务.ClsBaseDataInfo.sUFDataBaseYear + "' and iId='" + p + "' ";
            DataTable dt = clsSQLCommond.ExecQuery(sSQL);
            if (dt.Rows.Count > 0)
            {
                sdate = DateTime.Parse(dt.Rows[0]["dBegin"].ToString()).ToString("yyyy-MM-dd");
                edate = DateTime.Parse(dt.Rows[0]["dEnd"].ToString()).ToString("yyyy-MM-dd");
            }
            else
            {
                sdate = "";
                edate = "";
            }
        }

    }
}
