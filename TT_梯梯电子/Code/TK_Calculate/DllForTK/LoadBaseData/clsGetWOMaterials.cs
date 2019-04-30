using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using TH.BaseClass;

namespace DllForTK
{
    public class clsGetWOMaterials
    {
        public string GetWOMaterials(SqlTransaction tran, string sVerData, string sUid,string sPath,DateTime dtmEnd)
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

                //清空工单材料表
                sSQL = @"
truncate table TK_WO_Materials_Sum
";
                DbHelperSQL.ExecuteNonQuery(tran, CommandType.Text, sSQL);

                sSQL = @"
insert into [TK_WO_Materials_Sum](sVersion, sPartID, Qty, dDate, sChild, Qty_Child, dDate_Child, sPreparedBy, dtmPrepared)
select wo.sVersion,wo.sPartID,wo.Qty,wo.dDate,bom.child,isnull(wo.Qty,0) * isnull(bom.qty,0), wo.dDate as dDate_Child,'{0}',getdate()
from [TK_WO_Sum] wo
	inner join (
		select parent, child, max(qty) as qty,max(childCycle) as childCycle
		from [dbo].[TK_BOM]
		where parent <> child
		group by parent, child
	 )bom on wo.sPartID = bom.parent
 where wo.dDate < '{1}'
";
                sSQL = string.Format(sSQL, sUid,dtmEnd.ToString("yyyy-MM-dd"));
                int iCou = DbHelperSQL.ExecuteNonQuery(tran, CommandType.Text, sSQL);
                if (iCou == 0)
                {
                    throw new Exception("获取工单数据失败");
                }
                ClsWriteLog.WriteLog(sPath, "同步数据", "工单材料表 总条数：" + iCou.ToString());

                //清除历史记录中当前版本数据（理论上不应该有）
                sSQL = @"
delete TK_WO_Materials_Sum_History where sVersion = '{0}'
";
                sSQL = string.Format(sSQL, sVerData);
                DbHelperSQL.ExecuteNonQuery(tran, CommandType.Text, sSQL);

                //清除2周前数据
                sSQL = @"
delete TK_WO_Materials_Sum_History where dtmPrepared < dateadd(WEEK,-2,getdate())
";
                sSQL = string.Format(sSQL, sVerData);
                DbHelperSQL.ExecuteNonQuery(tran, CommandType.Text, sSQL);

                sSQL = @"
insert into TK_WO_Materials_Sum_History(sVersion, sPartID, Qty, dDate, sChild, Qty_Child, dDate_Child, sPreparedBy, dtmPrepared)
select sVersion, sPartID, Qty, dDate, sChild, Qty_Child, dDate_Child, sPreparedBy, dtmPrepared
from TK_WO_Materials_Sum
";
                sSQL = string.Format(sSQL, sUid);
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
