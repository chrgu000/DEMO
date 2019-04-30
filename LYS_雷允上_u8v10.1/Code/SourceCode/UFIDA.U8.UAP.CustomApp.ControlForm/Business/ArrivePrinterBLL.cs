using System;
using System.Collections.Generic;

using System.Text;
using System.Data;
using TH.BaseClass;

namespace UFIDA.U8.UAP.CustomApp.ControlForm.Business
{
    public class ArrivePrinterBLL
    {
        private static string _dataSourceStr = @"
select  
        cast(0 as bit) as IsSelected,
        PU_ArrivalVouchs.Autoid as 序号 ,
        PU_ArrivalVouch.cCode as 单据号码 ,
        PU_ArrivalVouch.dDate as 单据日期 ,
        PU_ArrivalVouchs.cDefine36  as 打印日期,
        PU_ArrivalVouch.cvencode as 供应商编码 ,
        vendor.cvenabbname as 供应商 ,
        cmaker as 制单人 ,
        cverifier as 审核人 ,
        PU_ArrivalVouch.ccloser as 关闭人 ,
        PU_ArrivalVouchs.cinvcode as 存货编码 ,
        inventory.cinvname as 品名 ,
        isnull(inventory.cinvstd,'') as 规格 ,
        cast(PU_ArrivalVouchs.iquantity as decimal(18,4)) as 单据数量 ,
        PU_ArrivalVouchs.cBatch as 批号 ,
        PU_ArrivalVouchs.cBatchProperty6 as 用料客户 ,
        '' as 料头责任人 ,
        PU_ArrivalVouchs.cWhCode as 仓库编码 ,
        isnull(PU_ArrivalVouchs.cfree1,'') as 变化宽幅 ,
        isnull(PU_ArrivalVouchs.cfree2,'') as 变化长度 ,
        computationunit.ccomunitname as 计量单位 ,
        PurchaseType.cPTName as 采购类型 ,
        left(PurchaseType.cPTName, 2) as 采购类型2,
        cast('' as nvarchar(50)) as 显示规格,
        cast('' as nvarchar(50)) as 显示数量
from    PU_ArrivalVouch with (nolock) 
        join PU_ArrivalVouchs  with (nolock) on PU_ArrivalVouch.ID = PU_ArrivalVouchs.ID
        join inventory   with (nolock)  on PU_ArrivalVouchs.cinvcode = inventory.cinvcode
        join computationunit   with (nolock)  on computationunit.ccomunitcode = inventory.ccomunitcode
        join Vendor  with (nolock)  on PU_ArrivalVouch.cvencode = Vendor.cvencode
        join PurchaseType  with (nolock)  on PU_ArrivalVouch.cPTCode = PurchaseType.cPTCode
where 1=1
order by PU_ArrivalVouch.dDate desc ,
        PU_ArrivalVouch.cCode desc ,
        PU_ArrivalVouchs.cinvcode
";

        public static DataTable GetFormsData(string filter, string conn)
        {
            string sql = _dataSourceStr.Replace("1=1", "1=1 " + filter);
            return SqlHelper.ExecuteDataset(conn, CommandType.Text, sql).Tables[0];
        }

        public static DataTable GetLabelPrintData(string filter, string conn)
        {
            string sql = _dataSourceStr.Replace("1=1", "1=1 " + filter);
            DataTable dt = SqlHelper.ExecuteDataset(conn, CommandType.Text, sql).Tables[0];
            DataColumn colBarCode = new DataColumn("条形码");
            colBarCode.DataType = typeof(string);
            dt.Columns.Add(colBarCode);


            foreach (DataRow row in dt.Rows)
            {

                string lableId = GetLableId(row["单据号码"].ToString(), row["序号"].ToString(), row["单据数量"].ToString(), conn,
                    row["存货编码"].ToString(),
                    row["品名"].ToString(),
                    row["规格"].ToString(),
                    row["变化宽幅"].ToString(),
                    row["变化长度"].ToString()
                    );


                SqlHelper.ExecuteNonQuery(conn, CommandType.Text, sql);

                string invStd = row["规格"].ToString();
                string changeWidth = row["变化宽幅"].ToString();
                string changeLen = row["变化长度"].ToString();
                string showStd = "";
                if (invStd != "")
                {
                    string deep = invStd.Split('*')[0];
                    if (changeWidth != "" || changeLen != "")
                        showStd = deep + "*" + changeWidth + "mm*" + changeLen;
                    else
                        showStd = invStd;
                }
                row["显示规格"] = showStd;
                row["显示数量"] = row["单据数量"].ToString() + row["计量单位"].ToString();
                row["条形码"] =  lableId;


            }
            return dt;
        }

        private static string GetLableId(string sourceFormCode, string sourceDetailId, string qty, string conn,
            string invCode ,string invName,string invStd,string invWidth,string invLength)
        {
            DateTime dtNow = Utils.GetServerTime(conn );
            string barCode = Utils.GetFormNumber2("", "Addins_WHLabel", "DetailId", Utils.GetServerTime(conn), false, conn);
            string sql = @"
if not exists (select  * from  dbo.Addins_WHLabel where SourceDetailId ='{1}' and LabelType='到货标签')
begin 
insert into dbo.Addins_WHLabel 
        (
          DetailId ,
          SourceFormCode ,
          SourceDetailId ,
          LableQty ,
          LabelType,
          InvCode ,
          InvName ,
          InvStd ,
          InvWidth ,
          InvLenght
        )
values  (
           '{10}',
           N'{0}' , -- SourceFormCode - nvarchar(50)
          {1} , -- SourceDetailId - int
          {2} , -- LableQty - decimal
          N'{3}',  -- LabelType - nvarchar(50)
          N'{4}' , -- InvCode - nvarchar(50)
          N'{5}' , -- InvName - nvarchar(50)
          N'{6}' , -- InvStd - nvarchar(50)
          N'{7}' , -- InvWidth - nvarchar(50)
          N'{8}'  -- InvLenght - nvarchar(50)
        )
update dbo.PU_ArrivalVouchs set cDefine36 ='{9}' where Autoid ={1}
select '{10}' as DetailId
end
else
begin
	select DetailId from  Addins_WHLabel where SourceDetailId ={1} and LabelType='到货标签'
end 
";
            sql = string.Format(sql, sourceFormCode, sourceDetailId, qty, "到货标签",
                invCode, invName, invStd, invWidth, invLength, dtNow.ToString("yyyy-MM-dd HH:mm:ss"), barCode);
            DataTable dt = SqlHelper.ExecuteDataset(conn, CommandType.Text, sql).Tables[0];
            return dt.Rows[0]["DetailId"].ToString();

        }
    }
}
