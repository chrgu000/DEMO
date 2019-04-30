using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using TH.BaseClass;

namespace DllForTK
{
    public class clsGetNetRequirement
    {
        public string GetNetRequirement(SqlTransaction tran, string sVerData, string sUid,string sPath,DateTime dtmEnd)
        {
            try
            {
                string sSQL = @"
select count(1) as iCou from [dbo].[_Get_TK_NetRequirement]
";
                DataTable dtTemp = DbHelperSQL.ExecuteDataset(tran, CommandType.Text, sSQL).Tables[0];
                if (dtTemp == null || BaseFunction.ReturnLong(dtTemp.Rows[0][0]) == 0)
                {
                    throw new Exception("获取净需求数据失败");
                }
                
                ClsWriteLog.WriteLog(sPath, "同步数据", "净需求 清空净需求表");
                //清空净需求表
                sSQL = @"
truncate table TK_NetRequirement
";
                DbHelperSQL.ExecuteNonQuery(tran, CommandType.Text, sSQL);

                sSQL = @"
insert into TK_NetRequirement(sVersion, SourceID, sNO, sPartID, fQTY, fOpenQTY, dtmDue, dtmRequirement, sPlannerCode, sSourceType, 
                sProductGroup,  sPreparedBy, dtmPreparedBy
)
select '{0}',SourceID, sNO, sPartID, fQTY, fOpenQTY, dtmDue, dtmRequirement, sPlannerCode, sSourceType, 
                sProductGroup, '{1}',getdate()
from [dbo].[_Get_TK_NetRequirement]
where dtmRequirement < '{2}'
";
                sSQL = string.Format(sSQL, sVerData, sUid, dtmEnd.ToString("yyyy-MM-dd"));
                int iCou = DbHelperSQL.ExecuteNonQuery(tran, CommandType.Text, sSQL);
                if (iCou == 0)
                {
                    throw new Exception("获取净需求数据失败");
                }
                ClsWriteLog.WriteLog(sPath, "同步数据", "净需求 总条数：" + iCou.ToString());

                //清除历史记录中当前版本数据（理论上不应该有）
                sSQL = @"
delete TK_NetRequirement_History where sVersion = '{0}'
";
                sSQL = string.Format(sSQL, sVerData);
                DbHelperSQL.ExecuteNonQuery(tran, CommandType.Text, sSQL);

                //清除2周前数据
                sSQL = @"
delete TK_NetRequirement_History where dtmPreparedBy < dateadd(WEEK,-2,getdate())
";
                sSQL = string.Format(sSQL, sVerData);
                DbHelperSQL.ExecuteNonQuery(tran, CommandType.Text, sSQL);

                sSQL = @"
insert into TK_NetRequirement_History(sVersion, SourceID, sNO, sPartID, fQTY, fOpenQTY, dtmDue, dtmRequirement, sPlannerCode, sSourceType, 
                sProductGroup,  sPreparedBy, dtmPreparedBy
)
select sVersion,SourceID, sNO, sPartID, fQTY, fOpenQTY, dtmDue, dtmRequirement, sPlannerCode, sSourceType, 
                sProductGroup, sPreparedBy,getdate()
from TK_NetRequirement
";
                sSQL = string.Format(sSQL, sVerData, sUid, dtmEnd.ToString("yyyy-MM-dd"));
                iCou = DbHelperSQL.ExecuteNonQuery(tran, CommandType.Text, sSQL);

                sSQL = @"exec _Set_Data_NetRequirement";
                iCou = DbHelperSQL.ExecuteNonQuery(tran, CommandType.Text, sSQL);
                ClsWriteLog.WriteLog(sPath, "同步数据", "净需求 汇总净需求");
            }
            catch (Exception ee)
            {
                return ee.Message;
            }

            return "";
        }
    }
}
