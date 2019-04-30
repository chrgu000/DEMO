using System;
using System.Collections.Generic;
using System.Text;
using System.Data;

namespace FrameBaseFunction.Query
{
    class ClsRoleRight
    {
        FrameBaseFunction.ClsDataBase clsSQLCommond;

        public ClsRoleRight()
        {
            clsSQLCommond = FrameBaseFunction.ClsDataBaseFactory.Instance();
        }

        public DataTable GetTreeInfo(string sPK)
        {
            DataTable dt = null;
            try
            {
                //string sSQL = "SELECT TOP 100 PERCENT * FROM dbo._Form WHERE (1 = 1) AND (fbitNoUse = 0) AND (fbitHide = 0)  ORDER BY fIntOrderID";
                //string sSQL = "select sInfo,fchrFrmNameID,fchrFrmUpName,fchrFrmText,dt1.vchrRoleRight,dt1.vchrRoleRight,bChoosed = case isnull(dt1.vchrRoleRight,'') when '' then '' else '√' end " +
                //                "from ( " +
                //                "(SELECT fchrFrmUpName+'|'+fchrFrmNameID as sInfo,fchrFrmNameID,fchrFrmUpName,fIntOrderID,fchrFrmText FROM dbo._Form  WHERE (1 = 1) AND (fbitNoUse = 0) AND (fbitHide = 0)  and (vchrFormBel='" + FrameBaseFunction.ClsBaseDataInfo.sProForm + "' or vchrFormBel is null)   union all select fchrFrmNameID+'|'+vchrBtnID,vchrBtnID,fchrFrmNameID,intOrder,vchrBtnText from dbo._FormBtnInfo  where 1=1 )) dtTree " +
                //                "left join dbo._RoleRight dt1 on dt1.vchrRoleRight = dtTree.fchrFrmUpName+'|'+dtTree.fchrFrmNameID and dt1.vchrRoleID='" + sPK + "' " +
                //                "order by fIntOrderID"; 

                string sSQL = @"
select sInfo,fchrFrmNameID,isnull(fchrFrmUpName,0) as fchrFrmUpName,fchrFrmText,dt1.vchrRoleRight,dt1.vchrRoleRight
	,bChoosed = case isnull(dt1.vchrRoleRight,'') when '' then '' else '√' end 
from ( 
		(
			SELECT a.fchrFrmUpName +'-'+ isnull(b.fchrFrmText,0)+'|'+a.fchrFrmNameID + '-' + a.fchrFrmText as sInfo,a.fchrFrmNameID+'-' + a.fchrFrmText as fchrFrmNameID,a.fchrFrmUpName +'-'+ isnull(b.fchrFrmText,0) as fchrFrmUpName,a.fIntOrderID,a.fchrFrmText 
			FROM dbo._Form  a
				left join _Form b on a.fchrFrmUpName = b.fchrFrmNameID and a.fchrFrmUpName <> '0'
			WHERE (1 = 1) AND (a.fbitNoUse = 0) AND (a.fbitHide = 0)  
				and (a.vchrFormBel='dl' or a.vchrFormBel is null)   
			union all 
			select fchrFrmNameID+ '-' + fchrFrmText +'|'+vchrBtnID+ '-' + vchrBtnText,vchrBtnID + '-' + vchrBtnText,fchrFrmNameID+ '-' + fchrFrmText,intOrder,vchrBtnText 
			from dbo._FormBtnInfo  
			where 1=1 
		)
	) dtTree  
	left join dbo._RoleRight dt1 on dt1.vchrRoleRight = dtTree.fchrFrmUpName+'|'+dtTree.fchrFrmNameID and dt1.vchrRoleID='111111' 
				
order by fIntOrderID

";
                sSQL = sSQL.Replace("111111", sPK);
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