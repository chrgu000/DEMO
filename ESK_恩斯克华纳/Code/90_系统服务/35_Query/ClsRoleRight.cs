using System;
using System.Collections.Generic;
using System.Text;
using System.Data;

namespace 系统服务.Query
{
    class ClsRoleRight
    {
        系统服务.ClsDataBase clsSQLCommond;

        public ClsRoleRight()
        {
            clsSQLCommond = 系统服务.ClsDataBaseFactory.Instance();
        }

        public DataTable GetTreeInfo(string sPK)
        {
            DataTable dt = null;
            try
            {
                //string sSQL = "SELECT TOP 100 PERCENT * FROM dbo._Form WHERE (1 = 1) AND (fbitNoUse = 0) AND (fbitHide = 0)  ORDER BY fIntOrderID";
                string sSQL = "select sInfo,fchrFrmNameID,fchrFrmUpName,fchrFrmText,dt1.vchrRoleRight,dt1.vchrRoleRight,bChoosed = case isnull(dt1.vchrRoleRight,'') when '' then '' else '√' end " +
                                "from ( " +
                                "(SELECT fchrFrmUpName+'|'+fchrFrmNameID as sInfo,fchrFrmNameID,fchrFrmUpName,fIntOrderID,fchrFrmText FROM dbo._Form  WHERE (1 = 1) AND (fbitNoUse = 0) AND (fbitHide = 0)  and (vchrFormBel='" + 系统服务.ClsBaseDataInfo.sProForm + "' or vchrFormBel is null)   union all select fchrFrmNameID+'|'+vchrBtnID,vchrBtnID,fchrFrmNameID,intOrder,vchrBtnText from dbo._FormBtnInfo  where 1=1 )) dtTree " +
                                "left join dbo._RoleRight dt1 on dt1.vchrRoleRight = dtTree.fchrFrmUpName+'|'+dtTree.fchrFrmNameID and dt1.vchrRoleID='" + sPK + "' " +
                                "order by fIntOrderID"; 
                dt = clsSQLCommond.ExecQuery(sSQL);
            }
            catch
            {
                throw new Exception("获得角色信息失败！");
            }
            return dt;
        }
    }
}