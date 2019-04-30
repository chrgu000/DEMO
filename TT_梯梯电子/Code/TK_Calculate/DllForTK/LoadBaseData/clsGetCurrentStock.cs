using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using TH.BaseClass;

namespace DllForTK
{
    public class clsGetCurrentStock
    {
        public string GetCurrentStock(SqlTransaction tran, string sVerData, string sUid,string sPath)
        {
            try
            {
                string sSQL = @"
select count(1) as iCou from [dbo].[_Get_TK_CurrentStock]
";
                DataTable dtTemp = DbHelperSQL.ExecuteDataset(tran, CommandType.Text, sSQL).Tables[0];
                if (dtTemp == null || BaseFunction.ReturnLong(dtTemp.Rows[0][0]) == 0)
                {
                    throw new Exception("获取仓库存量数据失败");
                }

                //清空仓库存量表
                sSQL = @"
truncate table TK_CurrentStock
";
                DbHelperSQL.ExecuteNonQuery(tran, CommandType.Text, sSQL);

                sSQL = @"
insert into [TK_CurrentStock](sVersion, Warehouse, LocationID, sItemNo, dQty, sPreparedBy, dtmPreparedBy
)
select '{0}', Warehouse, LocationID, sItemNo, dQty
        , '{1}',getdate()
from [dbo].[_Get_TK_CurrentStock]
";
                sSQL = string.Format(sSQL, sVerData, sUid);
                int iCou = DbHelperSQL.ExecuteNonQuery(tran, CommandType.Text, sSQL);
                if (iCou == 0)
                {
                    throw new Exception("获取仓库存量数据失败");
                }

                //清除历史记录中当前版本数据（理论上不应该有）
                sSQL = @"
delete TK_CurrentStock_History where sVersion = '{0}'
";
                sSQL = string.Format(sSQL, sVerData);
                DbHelperSQL.ExecuteNonQuery(tran, CommandType.Text, sSQL);

                //清除2周前数据
                sSQL = @"
delete TK_CurrentStock_History where dtmPreparedBy < dateadd(WEEK,-2,getdate())
";
                sSQL = string.Format(sSQL, sVerData);
                DbHelperSQL.ExecuteNonQuery(tran, CommandType.Text, sSQL);

                sSQL = @"
insert into [TK_CurrentStock_History](sVersion, Warehouse, LocationID, sItemNo, dQty, sPreparedBy, dtmPreparedBy
)
select '{0}', Warehouse, LocationID, sItemNo, dQty
        , '{1}',getdate()
from [dbo].[_Get_TK_CurrentStock]
";
                sSQL = string.Format(sSQL, sVerData, sUid);
                iCou = DbHelperSQL.ExecuteNonQuery(tran, CommandType.Text, sSQL);

                sSQL = @"exec _Set_Data_CurrentStock";
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
