using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using TH.BaseClass;

namespace UFIDA.U8.UAP.CustomApp.ControlForm
{
    public class ClsUserRight
    {
        public bool HasRight(string sMenuID, string sUserID, string Conn)
        {
            bool b = false;
            if (sUserID.ToLower() == "demo")
            {
                return true;
            }

            DbHelperSQL.connectionString = Conn; 
            
            string sSQL = @"
select *
from [_UserRight]
where UserID = '{0}' and MenuID = '{1}'
";
            sSQL = string.Format(sSQL, sUserID, sMenuID);
            DataTable dt = DbHelperSQL.Query(sSQL);

            if (dt == null || dt.Rows.Count == 0)
            {
                b = false;
            }
            else
            {
                b = true;
            }

            return b;
        }
    }
}
