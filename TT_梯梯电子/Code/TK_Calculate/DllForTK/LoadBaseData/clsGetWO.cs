using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using TH.BaseClass;

namespace DllForTK
{
    public class clsGetWO
    {
        public string GetWO(SqlTransaction tran, string sVerData, string sUid,string sPath,DateTime dtmEnd)
        {
            try
            {
                string sSQL = @"
select count(1) as iCou from [dbo].[_Get_TK_WO]
";
                DataTable dtTemp = DbHelperSQL.ExecuteDataset(tran, CommandType.Text, sSQL).Tables[0];
                if (dtTemp == null || BaseFunction.ReturnLong(dtTemp.Rows[0][0]) == 0)
                {
                    throw new Exception("获取工单数据失败");
                }

                //清空工单表
                sSQL = @"
truncate table TK_WO
";
                DbHelperSQL.ExecuteNonQuery(tran, CommandType.Text, sSQL);

                sSQL = @"
insert into [TK_WO](sVersion, sWONo, dDate, sPartID, fQTY, fOpenQTY, dtmDuedate, sProductGroup
        , sPreparedBy,  dtmPreparedBy
)
select '{0}', sWONo, dDate, sPartID, fQTY, fOpenQTY, dtmDuedate, sProductGroup
        , '{1}',getdate()
from [dbo].[_Get_TK_WO]
where isnull(dtmDuedate,'2000-01-01') < '{2}'
";
                sSQL = string.Format(sSQL, sVerData, sUid, dtmEnd.ToString("yyyy-MM-dd"));
                int iCou = DbHelperSQL.ExecuteNonQuery(tran, CommandType.Text, sSQL);
                if (iCou == 0)
                {
                    throw new Exception("获取工单数据失败");
                }
                ClsWriteLog.WriteLog(sPath, "同步数据", "工单 总条数：" + iCou.ToString());
                
                //清除历史记录中当前版本数据（理论上不应该有）
                sSQL = @"
delete TK_WO_History where sVersion = '{0}'
";
                sSQL = string.Format(sSQL, sVerData);
                DbHelperSQL.ExecuteNonQuery(tran, CommandType.Text, sSQL);

                //清除2周前数据
                sSQL = @"
delete TK_WO_History where dtmPreparedBy < dateadd(WEEK,-2,getdate())
";
                sSQL = string.Format(sSQL, sVerData);
                DbHelperSQL.ExecuteNonQuery(tran, CommandType.Text, sSQL);

                sSQL = @"
insert into TK_WO_History(sVersion, sWONo, dDate, sPartID, fQTY, fOpenQTY, dtmDuedate, sProductGroup
        , sPreparedBy,  dtmPreparedBy
)
select sVersion, sWONo, dDate, sPartID, fQTY, fOpenQTY, dtmDuedate, sProductGroup
        ,sPreparedBy,getdate()
from [dbo].[TK_WO]
";
                iCou = DbHelperSQL.ExecuteNonQuery(tran, CommandType.Text, sSQL);

                sSQL = @"exec _Set_Data_WO";
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
