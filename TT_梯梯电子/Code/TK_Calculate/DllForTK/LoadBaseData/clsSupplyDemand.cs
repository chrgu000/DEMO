using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using TH.BaseClass;

namespace DllForTK
{
    public class clsSupplyDemand
    {
        public string SupplyDemand(SqlTransaction tran)
        {
            try
            {
                //清空工单表
                string sSQL = @"
truncate table [TK_Trialkit_SupplyDemand]

insert into [TK_Trialkit_SupplyDemand](sDataVersion, sType, sPartID, Qty, dDate)
select [sVersion],'CurrentStock',[sItemNo],sum([Qty]),'2000-01-01'
from [dbo].[TK_CurrentStock_Sum]
group by [sVersion],[sItemNo]

insert into [TK_Trialkit_SupplyDemand](sDataVersion, sType, sPartID, Qty, dDate)
select [sVersion],'PO',sPartID,sum(Qty),dDate 
from [dbo].[TK_PO_Sum]
group by sVersion,dDate,sPartID

insert into [TK_Trialkit_SupplyDemand](sDataVersion, sType, sPartID, Qty, dDate)
select [sVersion],'WO',sPartID,sum(fOpenQTY),'2000-01-01'
from [dbo].[TK_WO]
group by sVersion,sPartID

insert into [TK_Trialkit_SupplyDemand](sDataVersion, sType, sPartID, Qty, dDate)
select [sVersion],'WOMaterials',sChild,sum(-1 * Qty_Child),'2000-01-01'
from [dbo].[TK_WO_Materials_Sum]
group by sVersion,sChild,dDate_Child

";
                DbHelperSQL.ExecuteNonQuery(tran, CommandType.Text, sSQL);               
            }
            catch (Exception ee)
            {
                return ee.Message;
            }

            return "";
        }
    }
}
