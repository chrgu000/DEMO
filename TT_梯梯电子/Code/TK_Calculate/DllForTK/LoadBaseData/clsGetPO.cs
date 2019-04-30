using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using TH.BaseClass;

namespace DllForTK
{
    public class clsGetPO
    {
        public string GetPO(SqlTransaction tran, string sVerData, string sUid,string sPath)
        {
            try
            {
                string sSQL = @"
select count(1) as iCou from [dbo].[_Get_TK_PO]
";
                DataTable dtTemp = DbHelperSQL.ExecuteDataset(tran, CommandType.Text, sSQL).Tables[0];
                if (dtTemp == null || BaseFunction.ReturnLong(dtTemp.Rows[0][0]) == 0)
                {
                    throw new Exception("获取采购数据失败");
                }

                //清空采购表
                sSQL = @"
truncate table TK_PO
";
                DbHelperSQL.ExecuteNonQuery(tran, CommandType.Text, sSQL);

                sSQL = @"
insert into [TK_PO]( sVersion, sPONo, dDate, POLine, iItemNO, fQTY, fOpenQTY, dtmRequirement, dtmDuedate, 
                dtmCommitdate, sProductGroup, sBuyer
            , sPreparedBy, dtmPreparedBy, iType

)
select '{0}', sPONo, dDate, POLine, iItemNO, fQTY, fOpenQTY, dtmRequirement, dtmDuedate, 
                dtmCommitdate, sProductGroup, sBuyer
        , '{1}',getdate(),0
from [dbo].[_Get_TK_PO]
";
                sSQL = string.Format(sSQL, sVerData, sUid);
                int iCou = DbHelperSQL.ExecuteNonQuery(tran, CommandType.Text, sSQL);
                if (iCou == 0)
                {
                    throw new Exception("获取采购数据失败");
                }
                ClsWriteLog.WriteLog(sPath, "同步数据", "PO 总条数：" + iCou.ToString());

                sSQL = @"
insert into [dbo].[TK_PO](sVersion, dDate, sPONo,iItemNO, fQTY,fOpenQTY,  dtmCommitdate, sProductGroup, sPreparedBy, dtmPreparedBy, iType,dtmDuedate)
select distinct '{0}',CONVERT(varchar(100), DATEADD(day,ceiling(b.leadtime), GETDATE()), 23) ,'VPO'
	,a.child,9999999999,9999999999,CONVERT(varchar(100), DATEADD(day,ceiling(b.leadtime), GETDATE()), 23)
	,'','{1}',GETDATE(),1,CONVERT(varchar(100), DATEADD(day,ceiling(b.leadtime), GETDATE()), 23)
from [dbo].[TK_BOM] a
	inner join _Get_TK_Material_Sourcing b on a.child = b.spmpart
where childsm = 'PURCHASED'
	and child not in (select sItemNo from [dbo].[TK_Base_ItemNo_Exclude])
";
                sSQL = string.Format(sSQL, sVerData, sUid);
                iCou = DbHelperSQL.ExecuteNonQuery(tran, CommandType.Text, sSQL);
                if (iCou == 0)
                {
                    throw new Exception("获取采购数据失败");
                }
                ClsWriteLog.WriteLog(sPath, "同步数据", "PO ETA 总条数：" + iCou.ToString());



                //清除历史记录中当前版本数据（理论上不应该有）
                sSQL = @"
delete TK_PO_History where sVersion = '{0}'
";
                sSQL = string.Format(sSQL, sVerData);
                DbHelperSQL.ExecuteNonQuery(tran, CommandType.Text, sSQL);

                //清除2周前数据
                sSQL = @"
delete TK_PO_History where dtmPreparedBy < dateadd(WEEK,-2,getdate())
";
                sSQL = string.Format(sSQL, sVerData);
                DbHelperSQL.ExecuteNonQuery(tran, CommandType.Text, sSQL);

                sSQL = @"
insert into [TK_PO_History]( sVersion, sPONo, dDate, POLine, iItemNO, fQTY, fOpenQTY, dtmRequirement, dtmDuedate, 
                dtmCommitdate, sProductGroup, sBuyer
            , sPreparedBy, dtmPreparedBy,iType
)
select '{0}', sPONo, dDate, POLine, iItemNO, fQTY, fOpenQTY, dtmRequirement, dtmDuedate, 
                dtmCommitdate, sProductGroup, sBuyer
        , '{1}',getdate(),iType
from [dbo].[TK_PO]
where sVersion = '{0}'
";
                sSQL = string.Format(sSQL, sVerData, sUid);
                iCou = DbHelperSQL.ExecuteNonQuery(tran, CommandType.Text, sSQL);

                sSQL = @"exec _Set_Data_PO";
                iCou = DbHelperSQL.ExecuteNonQuery(tran, CommandType.Text, sSQL);
            }
            catch (Exception ee)
            {
                return ee.Message;
            }

            return "";
        }
    }
}
