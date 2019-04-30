using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Windows.Forms;

namespace 系统服务
{
    public static class GetPrice
    {
        public static decimal PriceAdjust(string cInvCode, string cCusCode)
        {
            string sSQL = "";
            系统服务.ClsDataBase clsSQLCommond = 系统服务.ClsDataBaseFactory.Instance();
            sSQL = @"select b.D1 from PriceAdjust_Details b left join PriceAdjust_Main a on a.ID=b.ID left join Customer c on b.S2=c.S4 where b.B1=1 
and b.S1='" + cInvCode + "' and c.cCusCode='" + cCusCode + "' and a.dVerifysysTime is not null  order by a.dDate desc";
            DataTable dt = clsSQLCommond.ExecQuery(sSQL);
            if (dt.Rows.Count > 0)
            {
                return 规格化.ReturnDecimal(dt.Rows[0]["D1"]);
            }
            else
            {
                sSQL = @"select b.D1 from PriceAdjust_Details b left join PriceAdjust_Main a on a.ID=b.ID left join Customer c on b.S2=c.S4 where (b.B1<>1 or b.B1 is null ) 
and b.S1='" + cInvCode + "' and c.cCusCode='" + cCusCode + "' and a.dVerifysysTime is not null  order by a.dDate desc";
                DataTable dts = clsSQLCommond.ExecQuery(sSQL);
                if (dts.Rows.Count > 0)
                {
                    return 规格化.ReturnDecimal(dts.Rows[0]["D1"]);
                }
            }
            return 0;
        }

    }
}
