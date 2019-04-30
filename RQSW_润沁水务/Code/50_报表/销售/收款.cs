using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Windows.Forms;

namespace 报表
{
    public static class 收款
    {
        public static DataTable Table(string sdate, string edate)
        {
            系统服务.ClsDataBase clsSQLCommond = 系统服务.ClsDataBaseFactory.Instance();
            string sSQL = GetSql(sdate, edate);

            return clsSQLCommond.ExecQuery(sSQL);
        }


        public static string GetSql(string sdate, string edate)
        {
//            string sSQL = @"select a.cDepCode,a.cPersonCode,a.cCusCode,b.iType,b.cTypeCode,b.cSBVAutoID,b.iMoneyNow from SO_CloseBill a left join SO_CloseBillDetails b on a.ID=b.ID 
//            left join (
//
//            select a.cSOCode as cTypeCode,iMoney,b.cPersonCode,b.cDepCode from SO_SODetails a left join SO_SOMain b on a.ID=b.ID
//            union all 
//            select cast (iID as varchar(50)),D1,S3,S1 from AR_First 
//
//            ) c on b.cTypeCode=c.cTypeCode 
//            where dDate>='" + sdate + "' and dDate<='" + edate + "'";
            string sSQL = @"select cDepCode,cPersonCode,cCusCode,iAmount from SO_CloseBill 
            where dDate>='" + sdate + "' and dDate<='" + edate + "' and S1='1'";
            return sSQL;
        }


    }
}
