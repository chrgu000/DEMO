using ClsBaseClass;
using System;
using System.Data;
namespace ClsU8.Query
{
    public class ClsRoleRight
    {
        protected ClsDataBase clsSQLCommond = ClsDataBaseFactory.Instance();
        public DataTable GetTreeInfo(string sPK)
        {
            DataTable dt = null;
            try
            {
                string sSQL = string.Concat(new string[]
				{
					"select distinct  fIntOrderID,sInfo,fchrFrmNameID,fchrFrmUpName,fchrFrmText,dt1.vchrRoleRight,dt1.vchrRoleRight,bChoosed = case isnull(dt1.vchrRoleRight,'') when '' then '' else '√' end from ( (SELECT fchrFrmUpName+'|'+fchrFrmNameID+'/'+fchrFrmText as sInfo,fchrFrmNameID,fchrFrmUpName,fIntOrderID,fchrFrmText FROM dbo._Form  WHERE (1 = 1) AND (fbitNoUse = 0) AND (fbitHide = 0)  and (vchrFormBel='",
					ClsBaseDataInfo.sProForm,
					"' or vchrFormBel is null)   union all select _FormBtnInfo.fchrFrmNameID+'|'+vchrBtnID,vchrBtnID,_FormBtnInfo.fchrFrmNameID,intOrder,vchrBtnText from dbo._FormBtnInfo left join _Form on _FormBtnInfo.fchrFrmNameID=_Form.fchrFrmNameID  where 1=1 )) dtTree left join dbo._RoleRight dt1 on dt1.vchrRoleRight = sInfo and dt1.vchrRoleID='",
					sPK,
					"' order by fIntOrderID"
				});
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
