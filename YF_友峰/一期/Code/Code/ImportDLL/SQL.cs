using System;
using System.Collections.Generic;
using System.Text;

namespace ImportDLL
{
    public class SQL
    {
        /// <summary>
        /// 库存
        /// </summary>
        public static string _dataSourceStr1 = @"
SELECT 单据号,日期,制单人,a.存货编码,a.序列号,c.iText as 存放区域,厚度,宽度,长度,材料密度,
    cast(case when 材料类型='板' then isnull(厚度,0)*isnull(宽度,0)*isnull(长度,0)*isnull(材料密度,0)*isnull(数量,0)/1000000 
    when 材料类型='棒' then isnull(材料密度,0)*isnull(长度,0)*(isnull(宽度,0)/2)*(isnull(宽度,0)/2)*3.14*isnull(数量,0)/1000000 end as decimal(16,3)) as 材料重量, 数量 AS 现存量,b.cInvName as 存货名称,d.描述,d.备注,材料类型 
FROM 
( 
SELECT @u8.材料入库单表体2.入库单号 as 单据号,convert(varchar(10),@u8.材料入库单表头.入库日期,120) as 日期,制单 as 制单人,存货编码,序列号,存放区域,厚度,宽度,长度,数量,材料密度,iID as 来源iID ,材料类型 
FROM @u8.材料入库单表体2 left join @u8.材料入库单表头 on @u8.材料入库单表体2.入库单号=@u8.材料入库单表头.入库单号 where 1=1 and 审核<>'' and 审核 is not null 
UNION ALL 
SELECT @u8.开料单表体.开料单号,convert(varchar(10),@u8.开料单表头.交货日期,120) as 日期,算料人,存货编码3,序列号3,存放区域3,厚度3,宽度3,长度3,数量3,密度 as 材料密度,来源iID ,材料类型 
FROM @u8.开料单表体 left join @u8.开料单表头 on @u8.开料单表体.开料单号=@u8.开料单表头.开料单号  where 2=2 and 审核<>'' and 审核 is not null and 序列号3 is not null and 数量3 is not null and 数量3<>0 
)a left join @u8.Inventory b on a.存货编码 = b.cInvCode 
left join (select 存货编码1 as 存货编码,序列号1 as 序列号 from @u8.开料单表体 left join @u8.开料单表头 on @u8.开料单表体.开料单号=@u8.开料单表头.开料单号 
where 2=2 and 审核<>'' and 审核 is not null and 数量1<>0 group by 存货编码1,序列号1) s on a.存货编码=s.存货编码 and a.序列号=s.序列号

left join (select * from _LookUpDate where iType = 5) c on a.存放区域=c.iID 
left join (select iID,描述,备注 from @u8.材料入库单表体2) d on  d.iID=a.来源iID where s.序列号 is null 
";
        /// <summary>
        /// 入库
        /// </summary>
        public static string _dataSourceStr2 = @"
select a.*,c.cInvName as 存货名称,
    cast(case when 材料类型='板' then isnull(厚度,0)*isnull(宽度,0)*isnull(长度,0)*isnull(材料密度,0)*isnull(数量,0)/1000000 
    when 材料类型='棒' then isnull(材料密度,0)*isnull(长度,0)*(isnull(宽度,0)/2)*(isnull(宽度,0)/2)*3.14*isnull(数量,0)/1000000 
    end  as decimal(16,3)) as 材料重量 from 
(
SELECT @u8.材料入库单表体2.入库单号 as 单据号,@u8.材料入库单表头.入库日期 as 日期,制单 as 制单人,存货编码,序列号,存放区域,厚度,宽度,长度,数量,材料密度,iID as 来源iID,材料类型 
FROM @u8.材料入库单表体2 left join @u8.材料入库单表头 on @u8.材料入库单表体2.入库单号=@u8.材料入库单表头.入库单号 where 审核<>'' and 审核 is not null 
) a left join @u8.Inventory c on a.存货编码 = c.cInvCode where 1=1 ";

        /// <summary>
        /// 出库
        /// </summary>
        public static string _dataSourceStr3 = @"select 日期,开料单号,存货编码,b.cInvName as 存货名称,SUM(原始材料重量) as 原始材料重量,SUM(原始产品重量) as 原始产品重量,
SUM(切割材料重量) as 切割材料重量,SUM(切割产品重量) as 切割产品重量,SUM(剩余材料重量) as 剩余材料重量,SUM(剩余产品重量) as 剩余产品重量,
SUM(原始材料重量-切割材料重量-剩余材料重量) as 废料重量 ,
SUM(原始材料重量-剩余材料重量) as 实际用料重量,
case when sum(切割材料重量) = 0 then 0 else (sum(原始材料重量-切割材料重量-剩余材料重量))*100/sum(切割材料重量) end as 废料率 ,材料类型 
from (
select distinct convert(varchar(10),交货日期,120) as 日期, 序列号1 as 序列号,a.开料单号, 存货编码1 as 存货编码,
case when 材料类型='板' then isnull(a.长度1,0)*isnull(a.厚度1,0)*isnull(a.宽度1,0)*isnull(a.数量1,0)*密度/1000000 when 材料类型='棒' then isnull(密度,0)*isnull(长度1,0)*(isnull(宽度1,0)/2)*(isnull(宽度1,0)/2)*3.14*isnull(数量1,0)/1000000 end  as 原始材料重量,
case when 材料类型='板' then isnull(a.长度1,0)*isnull(a.厚度1,0)*isnull(a.宽度1,0)*isnull(a.数量1,0)*产品密度/1000000 when 材料类型='棒' then isnull(产品密度,0)*isnull(长度1,0)*(isnull(宽度1,0)/2)*(isnull(宽度1,0)/2)*3.14*isnull(数量1,0)/1000000 end as 原始产品重量,
0 as 切割材料重量,
0 as 切割产品重量,
0 as 剩余材料重量,
0 as 剩余产品重量,材料类型   
from @u8.开料单表体 a 
left join @u8.开料单表头 b on a.开料单号=b.开料单号 where 数量1<>0 
union all 
select distinct convert(varchar(10),交货日期,120) as 日期,0 as 序列号, 开料单号, 存货编码, 0 as 原始材料重量,0 as 原始产品重量,
case when 材料类型='板' then isnull(长度2,0)*isnull(厚度2,0)*isnull(宽度2,0)*isnull(数量2,0)*密度/1000000 when 材料类型='棒' then isnull(密度,0)*isnull(长度2,0)*(isnull(宽度2,0)/2)*(isnull(宽度2,0)/2)*3.14*isnull(数量2,0)/1000000 end as 切割材料重量,
case when 材料类型='板' then isnull(长度2,0)*isnull(厚度2,0)*isnull(宽度2,0)*isnull(数量2,0)*产品密度/1000000 when 材料类型='棒' then isnull(产品密度,0)*isnull(长度2,0)*(isnull(宽度2,0)/2)*(isnull(宽度2,0)/2)*3.14*isnull(数量2,0)/1000000 end as 切割产品重量,
0 as 剩余材料重量,0 as 剩余产品重量,材料类型 
from @u8.开料单表头 where 数量2<>0 
union all 
select distinct convert(varchar(10),交货日期,120) as 日期,序列号3 as 序列号, a.开料单号, 存货编码1 as 存货编码,
0 as 原始材料重量,
0 as 原始产品重量,
0 as 切割材料重量,
0 as 切割产品重量,
case when 材料类型='板' then isnull(a.长度3,0)*isnull(a.厚度3,0)*isnull(a.宽度3,0)*isnull(a.数量3,0)*密度/1000000 when 材料类型='棒' then isnull(密度,0)*isnull(长度3,0)*(isnull(宽度3,0)/2)*(isnull(宽度3,0)/2)*3.14*isnull(数量3,0)/1000000 end as 剩余材料重量,
case when 材料类型='板' then isnull(a.长度3,0)*isnull(a.厚度3,0)*isnull(a.宽度3,0)*isnull(a.数量3,0)*产品密度/1000000 when 材料类型='棒' then isnull(产品密度,0)*isnull(长度3,0)*(isnull(宽度3,0)/2)*(isnull(宽度3,0)/2)*3.14*isnull(数量3,0)/1000000 end as 剩余产品重量,材料类型   
from @u8.开料单表体 a 
left join @u8.开料单表头 b on a.开料单号=b.开料单号 where 数量3<>0 and 数量3 is not null 
) s  left join @u8.Inventory b on s.存货编码 = b.cInvCode
WHERE 1=1 group by 日期,开料单号,存货编码,b.cInvName,材料类型  ";

    }
}
