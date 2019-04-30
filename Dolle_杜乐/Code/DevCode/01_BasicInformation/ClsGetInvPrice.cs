using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using FrameBaseFunction;

namespace BasicInformation
{
    /// <summary>
    /// 供应商存货价格表
    /// </summary>
    public class ClsGetInvPrice
    {
        protected FrameBaseFunction.ClsDataBase clsSQLCommond = FrameBaseFunction.ClsDataBaseFactory.Instance();

                    string sSQL = @"
Select 
	cVenCode,cvenabbname
	,cInvCode,cInvName,cinvaddcode
	,cinvstd,cexch_name
	,(iunitprice) as iunitprice,(itaxrate) as itaxrate,(itaxunitprice) as itaxunitprice
	,(ctermcode) as ctermcode,(ctermname) as ctermname,(ipriceid) as ipriceid
	,(ccomunitcode) as ccomunitcode
	,(ccomunitname) as ccomunitname,(dstartdate) as dstartdate,(denddate) as denddate
	,(btaxcost) as btaxcost,(isupplytype) as isupplytype
From pu_veninvpricelst  
Where 1=1  And cvencode = N'111111'
    and cInvCode = '222222'
order by cVenCode, cInvCode, dstartdate
";

        public DataTable Get供应商存货价格(string sVenCode, string sInvCode)
        {

            sSQL = sSQL.Replace("1=1", "1=1 and cVenCode = '" + sVenCode + "' ");
            sSQL = sSQL.Replace("1=1", "1=1 and cInvCode = '" + sInvCode + "' ");
            DataTable dt供应商存货价格 = clsSQLCommond.ExecQuery(sSQL);

            return dt供应商存货价格;
        }

        public DataTable Get供应商存货价格()
        {
            DataTable dt供应商存货价格 = clsSQLCommond.ExecQuery(sSQL);

            return dt供应商存货价格;
        }
    }
}
