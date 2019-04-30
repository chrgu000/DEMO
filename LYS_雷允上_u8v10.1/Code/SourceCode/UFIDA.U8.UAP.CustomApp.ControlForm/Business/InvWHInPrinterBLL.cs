using System;
using System.Collections.Generic;

using System.Text;
using System.Data;
using TH.BaseClass;

namespace UFIDA.U8.UAP.CustomApp.ControlForm.Business
{
    public class InvWHInPrinterBLL
    {
        private static string _dataSourceStr = @"
select  
        cast(0 as bit) as IsSelected,
        mom_orderdetail.modid as 序号 ,
        '' as 供应商 ,
        getdate()   as 单据日期 ,
        mom_order.CreateUser as 制单人,
        mom_orderdetail.SortSeq as 订单行号 ,
        mom_orderdetail.Define36 as 打印日期 ,
        mom_morder.duedate as 完成日期 ,
        mom_orderdetail.qty as 单据数量 ,
        mom_orderdetail.QualifiedInQty  as 累计入库数量,
        Cast(null as decimal(18,2)) as 本次入库数量,
        mom_order.MoCode as 单据号码 ,
        mom_orderdetail.invcode as 存货编码 ,
        case when mom_orderdetail.status = 3 then '已审核'
             when mom_orderdetail.status = 4 then '已关闭'
             else '未审核'
        end as 订单状态 ,
        inventory.cinvname as 品名 ,
        isnull(inventory.cInvDefine13,null) as 批量,
        inventory.cinvstd as 规格 ,
        '' as 采购类型2 ,
        mom_orderdetail.free1 as 变化宽幅 ,
        mom_orderdetail.free2 as 变化长度 ,
        '' as 用料客户 ,
        '' as 料头责任人 ,
        '' as 批号 ,
        computationunit.ccomunitname as 计量单位 ,
        mom_orderdetail.mdeptcode as 生产部门编码 ,
        department.cdepname as 生产部门 ,
        mom_orderdetail.whcode as 供应仓库编码 ,
        Warehouse.cwhname as 供应仓库,
        cast('' as nvarchar(50)) as 显示规格,
        cast('' as nvarchar(50)) as 显示数量,
        cast('' as nvarchar(50)) as 条形码
from    mom_order  with (nolock) ,
        mom_orderdetail  with (nolock) ,
        mom_morder with (nolock) ,
        inventory  with (nolock) ,
        Warehouse  with (nolock) ,
        department  with (nolock) ,
        computationunit  with (nolock) 
where   1=1 
        and  mom_order.moid = mom_orderdetail.moid
        and mom_orderdetail.modid = mom_morder.modid
        and mom_orderdetail.invcode = inventory.cinvcode
       -- and ( mom_orderdetail.RelsDate > getdate() - 90 )
        and mom_orderdetail.whcode =Warehouse.cWhCode
        and mom_orderdetail.mdeptcode=department.cdepcode
        and inventory.ccomunitcode=computationunit.ccomunitcode

order by mom_order.moid desc
";

        public static DataTable GetFormsData(string filter, string conn)
        {
            string sql = _dataSourceStr.Replace("1=1", "1=1 " + filter);
            return SqlHelper.ExecuteDataset(conn, CommandType.Text, sql).Tables[0];
        }


        public static DataTable SplitQty(DataTable dtSource)
        {
            DataTable dtResult = dtSource.Clone();
            foreach (DataRow row in dtSource.Rows)
            {
                decimal batchQty = decimal.Parse(row["批量"].ToString() == "" ? "0" : row["批量"].ToString());
                decimal totalQty = decimal.Parse(row["本次入库数量"].ToString() == "" ? "0" : row["本次入库数量"].ToString());
                string qtyValue = totalQty.ToString();
                int pointCount = 0;
                if (qtyValue.Contains("."))
                {
                    pointCount = qtyValue.Split('.')[1].Length;
                }
                if (batchQty <= 0 || totalQty < batchQty)
                {
                    row["单据数量"] =Math.Round ( totalQty,pointCount );
                    dtResult.ImportRow(row);
                }
                else
                {
                    int lableQty = (int)(Math.Ceiling(totalQty / batchQty));
                    for (int i = 1; i <= lableQty; i++)
                    {
                        if (i == lableQty)

                            row["单据数量"] = Math.Round(totalQty - (i - 1) * batchQty, pointCount);
                        else
                            row["单据数量"] =Math.Round (batchQty,pointCount );
                        dtResult.ImportRow(row);
                    }

                }
            }

            return dtResult;

        }


        public static DataTable GetLabelPrintData(DataTable dtSource, string conn)
        {
            DataTable dtResult = dtSource.Clone();
            foreach (DataRow row in dtSource.Rows)
            {
                string labelId = GetLableId(row["单据号码"].ToString(), row["序号"].ToString(), row["单据数量"].ToString(), conn, row["存货编码"].ToString(),
                      row["品名"].ToString(),
                      row["规格"].ToString(),
                      row["变化宽幅"].ToString(),
                      row["变化长度"].ToString(),
                      row["本次入库数量"].ToString (),
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
                    row["条形码"] =  labelId;
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
          DetailId,
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
          BatchCode
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
          N'{10}'
        )
update dbo.mom_orderdetail  set Define36 =getdate()  where MoDId={1}
select   '{11}' as DetailId 
";
            sql = string.Format(sql, sourceFormCode, sourceDetailId, qty, "入库标签", invCode, invName,
                invStd, invWidth, invLength, currentInQty,batchCode,barCode );
            DataTable dt = SqlHelper.ExecuteDataset(conn, CommandType.Text, sql).Tables[0];
            return dt.Rows[0]["DetailId"].ToString();


        }

    }
}
