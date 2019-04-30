using System;
using System.Collections.Generic;
using System.Web;
using System.Data;
using System.Collections;
using System.Data.SqlClient;
using TH.BaseClass;

namespace ClsU8
{
    public class clsRdrecord01
    {
        public string sRdrecord01_Audit(SqlTransaction tran, string sCode, string sAuditer, DateTime dDate)
        {
            string sReturn = "";
            try
            {
                string sSQL = "select isnull(bflag_ST,0) as bflag from GL_mend where iYPeriod = '" + dDate.ToString("yyyyMM") + "'";
                DataTable dt = DbHelperSQL.ExecuteDataset(tran, CommandType.Text, sSQL).Tables[0];
                if (dt == null || dt.Rows.Count == 0)
                {
                    throw new Exception("获得模块状态失败");
                }
                int i结账 = BaseFunction.ReturnInt(dt.Rows[0]["bflag"]);
                if (i结账 > 0)
                {
                    throw new Exception(dDate.ToString("yyyy-MM") + " 已经结账");
                }

                sSQL = @"
select * from AccInformation  Where cSysId =N'ST' and  cName= N'bPurchaseInCheck'
";
                dt = DbHelperSQL.ExecuteDataset(tran, CommandType.Text, sSQL).Tables[0];
                bool bRD01ChangeCurrentStock = BaseFunction.ReturnBool(dt.Rows[0]["cValue"]);

                sSQL = @"
select * 
from rdrecord01 a inner join rdrecords01 b on a.id = b.id 
where cCode = '{0}'
";
                sSQL = string.Format(sSQL, sCode);
                dt = DbHelperSQL.ExecuteDataset(tran, CommandType.Text, sSQL).Tables[0];
                if (dt == null || dt.Rows.Count == 0)
                {
                    throw new Exception("获得单据信息失败");
                }
                if (dt.Rows[0]["cHandler"].ToString().Trim() != "")
                {
                    throw new Exception("已经审核");
                }
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    if (dt.Rows[i]["cbaccounter"].ToString().Trim() != "")
                    {
                        throw new Exception("已经记账");
                    }
                }

                sSQL = @"
update RdRecord01 set cHandler = '{0}',dVeriDate  = '{1}',dnverifytime = getdate() 
where cCode = '{2}'
";
                sSQL = string.Format(sSQL, sAuditer, dDate.ToString("yyyy-MM-dd"), sCode);
                DbHelperSQL.ExecuteNonQuery(tran, CommandType.Text, sSQL);

                //审核时修改现存量
                if (bRD01ChangeCurrentStock)
                {
                    for (int i = 0; i < dt.Rows.Count; i++)
                    {
                        string sBatch = dt.Rows[i]["cBatch"].ToString().Trim();

                        sSQL = @"
if exists(select * from  CurrentStock where cInvCode = '@cInvCode' and cWhCode = '@cWhCode' and 1=1)
  	update  CurrentStock set iQuantity = isnull(iQuantity,0) + @iQuantity  ,fInQuantity = fInQuantity - @iQuantity
    where cInvCode = '@cInvCode' and cWhCode = '@cWhCode'  and 1=1
      
else 
    begin 
        declare @itemid varchar(20); 
        declare @iCount int;  
        select @iCount=count(itemid) from CurrentStock where cInvCode = '@cInvCode';
        if( @iCount > 0 )
	        select @itemid=itemid from CurrentStock where cInvCode = '@cInvCode';
        else  
            select @itemid=max(itemid+1) from CurrentStock  
            insert into CurrentStock(cWhCode,cInvCode,iQuantity,itemid,iSoDid,cBatch)
            values('@cWhCode','@cInvCode', @iQuantity,isnull(@itemid,1),'',@cBatch) 
    end
";
                        sSQL = sSQL.Replace("@cInvCode", dt.Rows[i]["cInvCode"].ToString().Trim());
                        sSQL = sSQL.Replace("@cWhCode", dt.Rows[i]["cWhCode"].ToString().Trim());
                        sSQL = sSQL.Replace("@iQuantity", dt.Rows[i]["iQuantity"].ToString().Trim());
                        if (sBatch != "")
                        {
                            sSQL = sSQL.Replace("1=1", "1=1 and cBatch = '" + sBatch + "'");

                            sSQL = sSQL.Replace("@cBatch", "'" + sBatch + "'");
                        }
                        else
                        {
                            sSQL = sSQL.Replace("@cBatch", "NULL"); 
                        }

                        DbHelperSQL.ExecuteNonQuery(tran, CommandType.Text, sSQL);
                    }
                }
            }
            catch (Exception ee)
            {
                sReturn = ee.Message;
            }

            return sReturn;
        }
    }
}
