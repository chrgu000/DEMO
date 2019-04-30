using System;
using System.Collections.Generic;

using System.Text;
using System.Data;
using TH.BaseClass;

namespace UFIDA.U8.UAP.CustomApp.ControlForm.Business
{
    public class InvCustomPrinterBLL
    {
        public static string UserName { get; set; }

        private static string _dataSourceStr = @"
select  cast(0 as bit) as IsSelected ,
        inventory.I_id as 序号 ,
        '' as 单据号码 ,
        getdate()  as 单据日期 ,
        '' as 供应商编码 ,
        '' as 供应商 ,
        '' as 制单人 ,
        '' as 审核人 ,
        '' as 关闭人 ,
        dbo.Inventory.cinvcode as 存货编码 ,
        inventory.cinvname as 品名 ,
        isnull(inventory.cinvstd, '') as 规格 ,
        cast(null as decimal(18, 2)) as 单据数量 ,
        cast(null as decimal(18, 2)) as 批量 ,
        cast('' as nvarchar(50)) as 批号 ,
        '' as 用料客户 ,
        '' as 料头责任人 ,
        cast('' as nvarchar(50)) as 仓库编码 ,
        cast('' as nvarchar(50)) as 变化宽幅 ,
        cast('' as nvarchar(50)) as 变化长度 ,
        computationunit.ccomunitname as 计量单位 ,
        '' as 采购类型 ,
        '' as 采购类型2 ,
        cast('' as nvarchar(50)) as 显示规格 ,
        cast('' as nvarchar(50)) as 显示数量 ,
        cast('' as nvarchar(50)) as 条形码 ,
        S1.PrinteDate as 打印日期
from    inventory with ( nolock )
        join computationunit with ( nolock ) on computationunit.ccomunitcode = inventory.ccomunitcode
        left join ( select  SourceDetailId ,
                            max(PrinteDate) PrinteDate
                    from    dbo.Addins_WHLabel with ( nolock )
                    where   LabelType = '存货标签'
                    group by SourceDetailId
                  ) S1 on inventory.I_id = s1.SourceDetailId
where   1=1
order by inventory.cInvCode 

";

        public static DataTable GetFormsData(string filter, string conn)
        {
            string sql = _dataSourceStr.Replace("1=1", "1=1 " + filter);
            DataTable dt= SqlHelper.ExecuteDataset(conn, CommandType.Text, sql).Tables[0];
            if (UserName != null)
            {
                foreach (DataRow row in dt.Rows)
                {
                    row["制单人"] = UserName;
                }
            }
            return dt;
        }


        internal static DataTable SplitQty(DataTable dtSource)
        {
            DataTable dtResult = dtSource.Clone();
            foreach (DataRow row in dtSource.Rows)
            {
                decimal batchQty = decimal.Parse(row["批量"].ToString() == "" ? "0" : row["批量"].ToString());
                decimal totalQty = decimal.Parse(row["单据数量"].ToString() == "" ? "0" : row["单据数量"].ToString());

                string qtyValue = totalQty.ToString();
                int pointCount = 0;
                if (qtyValue.Contains("."))
                {
                    pointCount = qtyValue.Split('.')[1].Length;
                }


                if (batchQty <= 0 || totalQty < batchQty)
                {
                    row["单据数量"] = totalQty;
                    dtResult.ImportRow(row);
                }
                else
                {
                    int lableQty = (int)(Math.Ceiling(totalQty / batchQty));
                    for (int i = 1; i <= lableQty; i++)
                    {
                        if (i == lableQty)
                        {
                            row["单据数量"] = Math.Round(totalQty - (i - 1) * batchQty, pointCount);
                        }
                        else
                            row["单据数量"] = Math.Round(batchQty, pointCount);
                        dtResult.ImportRow(row);
                    }

                }
            }

            return dtResult;
        }

        internal static DataTable GetLabelPrintData(DataTable dtSource, string conn)
        {
            DataTable dtResult = dtSource.Clone();
            foreach (DataRow row in dtSource.Rows)
            {
                string labelId = GetLableId(row["单据号码"].ToString(), row["序号"].ToString(), row["单据数量"].ToString(), conn, row["存货编码"].ToString(),
                      row["品名"].ToString(),
                      row["规格"].ToString(),
                      row["变化宽幅"].ToString(),
                      row["变化长度"].ToString(),
                      "0",
                      row["批号"].ToString()
                      );

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
                row["条形码"] = labelId;
                dtResult.ImportRow(row);

            }
            return dtResult;
        }



        public static string GetLableId(string sourceFormCode, string sourceDetailId, string qty, string conn,
                       string invCode, string invName, string invStd, string invWidth, string invLength, string currentInQty, string batchCode)
        {
            string barCode = Utils.GetFormNumber2("", "Addins_WHLabel", "DetailId", Utils.GetServerTime(conn), false, conn);
            string sql = @"
set nocount on 
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
          InvLenght,
          SourceQty,
          BatchCode,
          PrinteDate
        )
values  (
           '{11}',
            N'{0}' , -- SourceFormCode - nvarchar(50)
          {1} , -- SourceDetailId - int
          {2} , -- LableQty - decimal
          N'{3}',  -- LabelType - nvarchar(50)
          N'{4}' , -- InvCode - nvarchar(50)
          N'{5}' , -- InvName - nvarchar(50)
          N'{6}' , -- InvStd - nvarchar(50)
          N'{7}' , -- InvWidth - nvarchar(50)
          N'{8}' , -- InvLenght - nvarchar(50),
         {9},  -- SourceQty - decimal
          N'{10}',
          getdate()
        )

select   '{11}' as DetailId 
";
            sql = string.Format(sql, sourceFormCode, sourceDetailId, qty, "存货标签", invCode, invName, invStd, 
                invWidth, invLength, currentInQty, batchCode,barCode );
            DataTable dt = SqlHelper.ExecuteDataset(conn, CommandType.Text, sql ).Tables[0];
            return dt.Rows[0]["DetailId"].ToString();


        }
    }
}
