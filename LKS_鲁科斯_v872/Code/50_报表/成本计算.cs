using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;


namespace 报表
{
    class 成本计算
    {
        string sSQL = "";
        DataTable dtrd;
        public string type;
        系统服务.ClsDataBase clsSQLCommond = 系统服务.ClsDataBaseFactory.Instance();
        public 成本计算()
        {
            sSQL = "select * from @u8.Rd_Style where len(cRdCode)=4 order by cRdCode ";
            dtrd = clsSQLCommond.ExecQuery(sSQL);
        }

        public string GetList(string sd, string ed, int month)
        {
            sSQL = @"
select 物料编码,sum(期初工) as 期初工,sum(期初费) as 期初费,sum(期初料) as 期初料,sum(期初贵金属) as 期初贵金属,sum(还原工) as 还原工,sum(还原费) as 还原费,sum(还原料) as 还原料,sum(本期工) as 本期工,sum(本期费) as 本期费,sum(本期料) as 本期料,sum(本期数量) as 本期数量 into #j  from Temp工费 where months=5555555555555555555555 group by 物料编码

declare @m as decimal(18,6)
select @m=isnull(D1,0) from PreciousMetals where S1='4444444444444444444444' and S2='5555555555555555555555'

Select 1 as i,cRdCode,i.cInvCCode as cInvCCode ,s.cInvCode, cInvAddCode, cInvName,cInvStd,dbo.ComputationUnit.cComunitCode,dbo.ComputationUnit.CComUnitName,dbo.ComputationUnit.iChangRate,iInvWeight,cInvDefine1,cInvDefine2,cInvDefine3,cInvDefine4,cInvDefine5,cInvDefine6,cInvDefine7,cInvDefine8,
isnull(convert(decimal(36,2),cInvDefine9),0)/100  as 贵金属比重,cInvDefine10,cInvDefine13,
cast(sum(ISNULL(Cast(iAInQuantity as decimal(20,4)),0) -ISNULL(Cast(iAOutQuantity as decimal(20,4)),0)) as float) AS QcQuantity,cast(sum(ISNULL(cast(iAInPrice as decimal(20,2)),0)-ISNULL(Cast(iAOutPrice as decimal(20,2)),0)) as decimal(20,2)) AS QcPrice,cast(sum(isnull(Cast(iDebitDifCost as decimal(20,2)),0)-isnull(Cast(iCreditDifCost as decimal(20,2)),0)) as decimal(20,2)) as qcDif,cast(0 as float) as InQuantity,cast(0 as decimal(20,2)) as InPrice,CAST(0 as decimal(20,2)) as InDif,cast(0 as float) as OutQuantity,cast(0 as decimal(20,2)) As OutPrice,cast(0 as decimal(20,2)) as OutDif ,
max(case when dbo.ComputationUnit.cComunitCode='106' then 0.45359237038 when  dbo.ComputationUnit.cComunitCode='112' then 0.0283495231488 when u.iChangRate is null then 1 else u.iChangRate end) as 换算率 
into #a
from dbo.IA_Subsidiary s with (nolock) left join dbo.Inventory i with (nolock) on s.cInvCode=i.cInvCode left join dbo.ComputationUnit with (nolock) ON i.cComunitCode = dbo.ComputationUnit.ccomunitcode left join dbo.warehouse with (nolock) on s.cWhCode=dbo.warehouse.cwhcode left join dbo.ComputationUnit u on i.cAssComUnitCode=u.cComunitCode 
Where cVouType<> N'33'  and ( Not s.cWhCode is null ) AND  (dbo.WareHouse.bInCost = 1 or dbo.WareHouse.cwhcode is null)  
And (imonth=0 or (dKeepDate< 1111111111111111111111 and iMonth<>0)) 
group by cRdCode,i.cInvCCode,s.cInvCode,cInvName,cInvStd,dbo.ComputationUnit.cComunitCode,dbo.ComputationUnit.CComUnitName,dbo.ComputationUnit.iChangRate,iInvWeight,cInvAddCode,cInvDefine1,cInvDefine2,cInvDefine3,cInvDefine4,cInvDefine5,cInvDefine6,cInvDefine7,cInvDefine8,cInvDefine9,cInvDefine10,cInvDefine13 
having (sum(ISNULL(iAInQuantity,0) -ISNULL(iAOutQuantity,0))<>0 or sum(ISNULL(iAInPrice,0)-ISNULL(iAOutPrice,0))<>0 or sum(isnull(iDebitDifCost,0)-isnull(iCreditDifCost,0))<>0)

insert into #a  select 2,cRdCode,i.cInvCCode, s.cInvCode, cInvAddCode, cInvName,cInvStd,dbo.ComputationUnit.cComunitCode,dbo.ComputationUnit.CComUnitName,dbo.ComputationUnit.iChangRate,iInvWeight,cInvDefine1,cInvDefine2,cInvDefine3,cInvDefine4,cInvDefine5,cInvDefine6,cInvDefine7,cInvDefine8,isnull(convert(decimal(36,2),cInvDefine9),0)/100 as  贵金属比重,cInvDefine10,cInvDefine13,0 AS QcQuantity,0 AS QcPrice,0 as qcDif,(case bRdFlag when 1 then (case when (iAInQuantity is null) then 0 else iAInQuantity end) else 0 end) as InQuantity,(case bRdFlag when 1 then (case when (iAInPrice is null) then 0 else cast(iAInPrice as decimal(20,2)) end) else 0 end) as InPrice,(case bRdFlag when 1 then (isnull(iDebitDifCost,0)-isnull(iCreditDifCost,0)) else 0 end) as InDif,(case bRdFlag when 0 then (case when (iAOutQuantity is null) then 0 else iAOutQuantity end) else 0 end) as OutQuantity,(case bRdFlag when 0 then (case when (iAOutPrice is null) then 0 else cast(iAOutPrice as decimal(20,2)) end) else 0 end) As OutPrice,(case bRdFlag when 0 then (isnull(iCreditDifCost,0)-isnull(iDebitDifCost,0)) else 0 end) as OutDif ,
case when dbo.ComputationUnit.cComunitCode='106' then 0.45359237038 when  dbo.ComputationUnit.cComunitCode='112' then 0.0283495231488 when u.iChangRate is null then 1 else u.iChangRate end as 换算率 
from dbo.IA_Subsidiary s with (nolock) left join dbo.Inventory i with (nolock) on s.cInvCode=i.cInvCode left join dbo.ComputationUnit with (nolock) ON i.cComunitCode = dbo.ComputationUnit.ccomunitcode left join dbo.warehouse with (nolock) on s.cWhCode=dbo.warehouse.cwhcode left join dbo.ComputationUnit u on i.cAssComUnitCode=u.cComunitCode 
Where cVouType<> N'33' and iMonth<>0 and ( Not s.cWhCode is null ) AND  (dbo.WareHouse.bInCost = 1 or dbo.WareHouse.cwhcode is null)  
And  (dKeepDate>= 1111111111111111111111 And  dKeepDate<= 2222222222222222222222) 



Select  #a.cInvCCode as 存货分类代码,dbo.InventoryClass.cInvCName as 存货分类名称,#a.cInvCode as N'存货编码',#a.cInvAddCode as N'存货代码',#a.cInvName as N'存货名称',#a.cInvStd as N'存货规格',#a.cComunitCode as 计量单位编码, #a.CComUnitName as N'计量单位',#a.贵金属比重,#a.换算率,
convert(decimal(18,4),sum(qcQuantity)) as N'期初数量',case when sum(qcQuantity)<>0 then convert(decimal(18,5),sum(qcPrice)/sum(qcQuantity)) else 0 end as N'期初单价',
sum(qcPrice) as N'期初金额',convert(decimal(18,4),sum(InQuantity)) as N'收入数量',case when sum(InQuantity)<>0 then convert(decimal(18,5),sum(inPrice)/sum(InQuantity)) else 0 end as N'收入单价',
sum(inPrice) as N'收入金额',convert(decimal(18,4),sum(OutQuantity)) as N'发出数量',case when sum(OutQuantity)<>0 then convert(decimal(18,5),sum(OutPrice)/sum(OutQuantity)) else 0 end as N'发出单价',
sum(OutPrice) as N'发出金额',convert(decimal(18,4),isnull(sum(qcQuantity),0)+isnull(sum(InQuantity),0)-isnull(sum(OutQuantity),0)) as N'结存数量',
case when isnull(sum(qcQuantity),0)+isnull(sum(InQuantity),0)-isnull(sum(OutQuantity),0)<>0 then convert(decimal(18,5),(isnull(sum(qcPrice),0)+isnull(sum(inPrice),0)-isnull(sum(OutPrice),0))/(isnull(sum(qcQuantity),0)+isnull(sum(InQuantity),0)-isnull(sum(OutQuantity),0))) else 0 end as N'结存单价',isnull(sum(qcPrice),0)+isnull(sum(inPrice),0)-isnull(sum(OutPrice),0) as N'结存金额',
convert(decimal(18,4),sum(qcQuantity*贵金属比重*换算率)) as N'期初数量贵',convert(decimal(18,4),sum(InQuantity*贵金属比重*换算率)) as N'收入数量贵',convert(decimal(18,4),sum(OutQuantity*贵金属比重*换算率)) as N'发出数量贵',
convert(decimal(18,4),isnull(sum(qcQuantity),0)*贵金属比重*换算率+isnull(sum(InQuantity),0)*贵金属比重*换算率-isnull(sum(OutQuantity),0)*贵金属比重*换算率) as N'结存数量贵'";
            for (int i = 0; i < dtrd.Rows.Count; i++)
            {
                string id = dtrd.Rows[i]["cRdCode"].ToString();
                if (id.Substring(0, 2) == "01")
                {
                    sSQL = sSQL + @"
,sum(CASE WHEN cRdCode='" + id + "' then InQuantity else 0 end) iquantity" + id;
                    sSQL = sSQL + @"
,sum(CASE WHEN cRdCode='" + id + "' then InQuantity*贵金属比重*换算率 else 0 end) iquantityM" + id;
                    sSQL = sSQL + @"
,sum(case when cRdCode='" + id + "' then convert(decimal(18,2),inPrice) else 0 end) imoney" + id;
                }
                else
                {
                    sSQL = sSQL + @"
,sum(CASE WHEN cRdCode='" + id + "' then OutQuantity else 0 end) iquantity" + id;
                    sSQL = sSQL + @"
,sum(CASE WHEN cRdCode='" + id + "' then OutQuantity*贵金属比重*换算率 else 0 end) iquantityM" + id;
                    sSQL = sSQL + @"
,sum(case when cRdCode='" + id + "' then convert(decimal(18,2),OutPrice) else 0 end) imoney" + id;
                }
            }
            sSQL = sSQL + @"  
into #b
from #a   left join  dbo.Inventory inv on #a.cInvCode=inv.cInvCode  left join dbo.InventoryClass on #a.cInvCCode=dbo.InventoryClass.cInvCCode 
where  3333333333333333333333 group by #a.cInvCCode,dbo.InventoryClass.cInvCName,#a.cInvCode,#a.cInvAddCode,#a.cInvName,#a.cInvStd,#a.cComunitCode,#a.CComUnitName ,贵金属比重,换算率

select #b.*,
isnull(convert(decimal(18,4),期初工),0) 期初工金额,isnull(convert(decimal(18,4),期初费),0) 期初费金额,isnull(convert(decimal(18,4),期初料),0) 期初料金额,
isnull(convert(decimal(18,4),还原工),0) 期初工还原,isnull(convert(decimal(18,4),还原费),0) 期初费还原,isnull(convert(decimal(18,4),期初金额),0)-isnull(convert(decimal(18,4),还原工),0)-isnull(convert(decimal(18,4),还原费),0) 期初料还原,
isnull(convert(decimal(18,4),本期工),0) 收入工金额,
isnull(convert(decimal(18,4),本期费),0) 收入费金额,
isnull(convert(decimal(18,4),本期料),0) 本期料,
convert(decimal(18,4),isnull(收入金额,0))-isnull(convert(decimal(18,4),本期工),0)-isnull(convert(decimal(18,4),本期费),0) 收入料金额,
isnull(convert(decimal(18,4),#j.期初贵金属),0) as 期初金额贵,isnull(收入数量贵*@m,0) 收入金额贵 
into #c from #b left join #j on  #b.存货编码=#j.物料编码 

select *,
case when 期初数量+收入数量<>0 then convert(decimal(18,4),(期初工金额+收入工金额)*发出数量/(期初数量+收入数量)) end 发出工金额,
case when 期初数量+收入数量<>0 then convert(decimal(18,4),(期初费金额+收入费金额)*发出数量/(期初数量+收入数量)) end 发出费金额,
convert(decimal(18,4),isnull(发出金额,0))
-convert(decimal(18,4),case when 期初数量+收入数量<>0 then (期初工金额+收入工金额)*发出数量/(期初数量+收入数量) else 0 end)
-convert(decimal(18,4),case when 期初数量+收入数量<>0 then (期初费金额+收入费金额)*发出数量/(期初数量+收入数量) else 0 end)  发出料金额,
case when 期初数量贵+收入数量贵<>0 then convert(decimal(18,4),(期初金额贵+收入金额贵)*发出数量贵/(期初数量贵+收入数量贵)) else 0 end 发出金额贵  
into #d from #c

select *, 
期初工金额+收入工金额-发出工金额 as 结存工金额,期初费金额+收入费金额-发出费金额 as 结存费金额,期初料金额+收入料金额-发出料金额 as 结存料金额,期初金额贵+收入金额贵-发出金额贵 as 结存金额贵 
into #e from #d

--select a.存货编码,sum(case when c.发出数量<>0 then b.UseQty*c.发出工金额/c.发出数量 else 0 end) as 工, sum(case when c.发出数量<>0 then b.UseQty*c.发出费金额/c.发出数量 else 0 end) as 费 
--into #a1 from #e a left join dbo.TEMPBom b on a.存货编码=b.母件编码 left join #e c on b.子件编码=c.存货编码 group by a.存货编码

select a.存货编码,sum(c.发出工金额) as 工, sum(c.发出费金额) as 费 
into #a1 from #e a left join dbo.TEMPBom b on a.存货编码=b.母件编码 left join #e c on b.子件编码=c.存货编码 group by a.存货编码

select a.*,收入工金额+isnull(b.工,0) as 收入工还原,收入费金额+isnull(b.费,0) as 收入费还原,收入料金额-isnull(b.工,0)-isnull(b.费,0) as 收入料还原,b.工,b.费 
into #f from #e a left join #a1 b on a.存货编码=b.存货编码

select *,
case when 期初数量+收入数量<>0 then convert(decimal(18,4),(期初工还原+收入工还原)*发出数量/(期初数量+收入数量)) end 发出工还原,
case when 期初数量+收入数量<>0 then convert(decimal(18,4),(期初费还原+收入费还原)*发出数量/(期初数量+收入数量)) end 发出费还原,
case when 期初数量+收入数量<>0 then convert(decimal(18,4),isnull(发出金额,0))-convert(decimal(18,4),(期初工还原+收入工还原)*发出数量/(期初数量+收入数量))-convert(decimal(18,4),(期初费还原+收入费还原)*发出数量/(期初数量+收入数量)) end 发出料还原,
case when 期初数量贵<>0 then convert(decimal(18,4),期初金额贵/期初数量贵) else 0 end 期初单价贵,
case when 发出数量贵<>0 then convert(decimal(18,4),发出金额贵/发出数量贵) else 0 end 发出单价贵, 
case when 收入数量贵<>0 then convert(decimal(18,4),收入金额贵/收入数量贵) else 0 end 收入单价贵,  
case when 结存数量贵<>0 then convert(decimal(18,4),结存金额贵/结存数量贵) else 0 end 结存单价贵  
into #g from #f

select *, 
期初工还原+收入工还原-发出工还原 as 结存工还原,期初费还原+收入费还原-发出费还原 as 结存费还原,期初料还原+收入料还原-发出料还原 as 结存料还原,
case when 期初数量<>0 then convert(decimal(18,4),期初料金额/期初数量) else 0 end 期初料单价,
case when 发出数量<>0 then convert(decimal(18,4),发出料金额/发出数量) else 0 end 发出料单价,
case when 收入数量<>0 then convert(decimal(18,4),收入料金额/收入数量) else 0 end 收入料单价,  
case when 期初数量<>0 then convert(decimal(18,4),期初料金额/期初数量) else 0 end 期初单价还原,
case when 发出数量<>0 then convert(decimal(18,4),发出料还原/发出数量) else 0 end 发出单价还原, 
case when 收入数量<>0 then convert(decimal(18,4),收入料还原/收入数量) else 0 end 收入单价还原,  
case when 结存数量<>0 then convert(decimal(18,4),(期初料还原+收入料还原-发出料还原)/结存数量) else 0 end 结存单价还原   
into #h from #g

select * ";
            for (int i = 0; i < dtrd.Rows.Count; i++)
            {
                string id = dtrd.Rows[i]["cRdCode"].ToString();
                if (id.Substring(0, 2) == "01")
                {
                    sSQL = sSQL + @"
,case when iquantity" + id + "<>0 then imoney" + id + "/iquantity" + id + " else 0 end iunit" + id;
                    sSQL = sSQL + @"
,case when iquantityM" + id + "<>0 then 收入单价贵 else 0 end iunitM" + id;
                    sSQL = sSQL + @"
,case when iquantity" + id + "<>0 then 收入料单价 else 0 end iunitAPrice" + id;
                    sSQL = sSQL + @"
,case when iquantity" + id + "<>0 then 收入单价还原 else 0 end iunitPrice" + id;
                    if (id == "0103")
                    {
                        sSQL = sSQL + @"
,case when iquantity" + id + "<>0 then convert(decimal(18,4),收入工金额) else 0 end iWork" + id;
                        sSQL = sSQL + @"
,case when iquantity" + id + "<>0 then convert(decimal(18,4),收入费金额) else 0 end iCost" + id;

                        sSQL = sSQL + @"
,case when iquantity" + id + "<>0 then convert(decimal(18,4),收入工还原) else 0 end sWork" + id;
                        sSQL = sSQL + @"
,case when iquantity" + id + "<>0 then convert(decimal(18,4),收入费还原) else 0 end sCost" + id;
                    }
                    else
                    {
                        sSQL = sSQL + @"
,case when 收入数量<>0 then convert(decimal(18,4),收入工金额*iquantity" + id + "/收入数量) else 0 end iWork" + id;
                        sSQL = sSQL + @"
,case when 收入数量<>0 then convert(decimal(18,4),收入费金额*iquantity" + id + "/收入数量) else 0 end iCost" + id;

                        sSQL = sSQL + @"
,case when 收入数量<>0 then convert(decimal(18,4),收入工还原*iquantity" + id + "/收入数量) else 0 end sWork" + id;
                        sSQL = sSQL + @"
,case when 收入数量<>0 then convert(decimal(18,4),收入费还原*iquantity" + id + "/收入数量) else 0 end sCost" + id;
                    }
                }
                else
                {
                    sSQL = sSQL + @"
,case when iquantity" + id + "<>0 then imoney" + id + "/iquantity" + id + " else 0 end iunit" + id;
                    sSQL = sSQL + @"
,case when iquantityM" + id + "<>0 then 发出单价贵 else 0 end iunitM" + id;
                    sSQL = sSQL + @"
,case when iquantity" + id + "<>0 then 发出料单价 else 0 end iunitAPrice" + id;
                    sSQL = sSQL + @"
,case when iquantity" + id + "<>0 then 发出单价还原 else 0 end iunitPrice" + id;
                    sSQL = sSQL + @"
,case when 发出数量<>0 then 发出工金额*iquantity" + id + "/发出数量 else 0 end iWork" + id;
                    sSQL = sSQL + @"
,case when 发出数量<>0 then 发出费金额*iquantity" + id + "/发出数量 else 0 end iCost" + id;

                    sSQL = sSQL + @"
,case when 发出数量<>0 then 发出工还原*iquantity" + id + "/发出数量 else 0 end sWork" + id;
                    sSQL = sSQL + @"
,case when 发出数量<>0 then 发出费还原*iquantity" + id + "/发出数量 else 0 end sCost" + id;
                }
            }
            sSQL = sSQL + @" 
into #i from #h

select * ";
            string g = "";
            string f = "";
            string inmoney="";
            string outmoney = "";
            for (int i = 0; i < dtrd.Rows.Count; i++)
            {
                string id = dtrd.Rows[i]["cRdCode"].ToString();
                if (id.Substring(0, 2) == "01")
                {
                    
                    sSQL = sSQL + @"
,case when iquantityM" + id + "<>0 then convert(decimal(18,2),收入单价贵*iquantityM" + id + ") else 0 end imoneyM" + id;
                    sSQL = sSQL + @"
,isnull(imoney" + id + ",0)-isnull(iWork" + id + ",0)-isnull(iCost" + id + ",0) iPriceA" + id;
                    sSQL = sSQL + @"
,isnull(imoney" + id + ",0)-isnull(sWork" + id + ",0)-isnull(sCost" + id + ",0) iPrice" + id;

                    if (inmoney != "")
                    {
                        inmoney = inmoney + "+";
                    }
                    inmoney = inmoney + "isnull(imoney" + id + ",0)";
                }
                else
                {
                    
                    sSQL = sSQL + @"
,case when iquantityM" + id + "<>0 then convert(decimal(18,2),发出单价贵*iquantityM" + id + ") else 0 end imoneyM" + id;
                    sSQL = sSQL + @"
,isnull(imoney" + id + ",0)-isnull(iWork" + id + ",0)-isnull(iCost" + id + ",0) iPriceA" + id;
                    sSQL = sSQL + @"
,isnull(imoney" + id + ",0)-isnull(sWork" + id + ",0)-isnull(sCost" + id + ",0) iPrice" + id;

                    if (outmoney != "")
                    {
                        outmoney = outmoney + "+";
                    }
                    outmoney = outmoney + "isnull(imoney" + id + ",0)";
                }
                if (g != "")
                {
                    g = g + "+";
                    f = f + "+";
                }
                g = g + "isnull(iWork" + id + ",0)";
                f = f + "isnull(iCost" + id + ",0)";
            }
            sSQL = sSQL + @" ," + g + " as 工汇总," + f + @" as 费汇总 into #k from #i  
";

            sSQL = sSQL.Replace("1111111111111111111111", "'" + sd + "'");
            sSQL = sSQL.Replace("2222222222222222222222", "'" + ed + "'");
            sSQL = sSQL.Replace("3333333333333333333333", type);
            sSQL = sSQL.Replace("5555555555555555555555", month.ToString());
            sSQL = sSQL.Replace("6666666666666666666666", (month - 1).ToString());
            sSQL = sSQL.Replace("4444444444444444444444", 系统服务.ClsBaseDataInfo.sUFDataBaseYear);


            sSQL = sSQL.Replace("dbo.", 系统服务.ClsBaseDataInfo.sUFDataBaseName + ".dbo.");
            return sSQL;
        }

        #region 期初生成
        public void GetQC(int month)
        {
            int year = int.Parse(系统服务.ClsBaseDataInfo.sUFDataBaseYear);
            sSQL = @"
delete from Temp工费 
insert into Temp工费(物料编码, 期初工, 期初费, 期初料,期初贵金属, 还原工, 还原费, 还原料, 本期工, 本期费, 本期料, 本期数量, years, months) 
SELECT 物料编码, 期初工, 期初费, 期初料,期初贵金属, 还原工, 还原费, 还原料, null, null, null, null, years, months  FROM 工费期初 ";
            clsSQLCommond.ExecSql(sSQL);
            if (month != 1)
            {
                for (int i = 1; i < month; i++)
                {
                    try
                    {
                        string sd = "";
                        string ed = "";
                        系统服务.GetUAPeriod p = new 系统服务.GetUAPeriod();
                        p.GetPeriod(i.ToString(), out sd, out ed);
                        sSQL = @"insert into Temp工费(物料编码, 期初工, 期初费, 期初料, 还原工, 还原费, 还原料, 本期工, 本期费, 本期料, 本期数量, years, months) 
select InvCode,null,null,null,null,null,null,iamotype1,iamotype3,iamotype0,ioutput ,4444444444444444444444 as year,t2.iperiod 
 from (select cppid,cbatch,iperiod,max(iFinQua) as ioutput,Sum(iTotalAmo-iOnpTotalAmo) as iamoall,
		Sum(case camotype when 0 then (iTotalAmo-iOnpTotalAmo) else 0 end) as iamotype0,
		Sum(case camotype when 1 then (iTotalAmo-iOnpTotalAmo) else 0 end) as iamotype1,
		Sum(case camotype when 2 then (iTotalAmo-iOnpTotalAmo) else 0 end) as iamotype2,
		Sum(case camotype when 3 then (iTotalAmo-iOnpTotalAmo) else 0 end) as iamotype3,
		Sum(case camotype when 4 then (iTotalAmo-iOnpTotalAmo) else 0 end) as iamotype4,
		'0' as iflag From dbo.CA_AmoCt group by cppid,cbatch,iperiod ) as t1
left join dbo.ca_rptoutput t2 on t1.cppid=t2.cppid and t1.cbatch=t2.cbatch and t1.iperiod=t2.iperiod 
inner join dbo.caq_coreal t3 on t1.cppid=t3.irealcoid and t3.docstatus<>1 inner join dbo.ca_inventory t4 on t3.invcode=t4.cinvcode where  ioutput<>0 and t2.iperiod=5555555555555555555555 ";
                        sSQL = sSQL.Replace("dbo.", 系统服务.ClsBaseDataInfo.sUFDataBaseName + ".dbo.");
                        sSQL = sSQL.Replace("4444444444444444444444", 系统服务.ClsBaseDataInfo.sUFDataBaseYear);
                        sSQL = sSQL.Replace("5555555555555555555555", i.ToString());
                        clsSQLCommond.ExecSql(sSQL);

                        sSQL = GetList(sd, ed, i) +
    @"
insert into Temp工费(物料编码, 期初工, 期初费, 期初料,期初贵金属, 还原工, 还原费, 还原料, 本期工, 本期费, 本期料, 本期数量, years, months) 
SELECT 存货编码, 结存工金额, 结存费金额, 结存料金额,结存金额贵, 结存工还原, 结存费还原, 结存料还原, 0, 0, 0, 0, 4444444444444444444444, " + (i + 1) + "  FROM #k ";
                        sSQL = sSQL.Replace("4444444444444444444444", 系统服务.ClsBaseDataInfo.sUFDataBaseYear);
                        clsSQLCommond.ExecSql(sSQL);
                    }
                    catch(Exception ee)
                    {
                        throw new Exception(i + "月期初有误," + ee.Message);
                    }
                }
            }
            sSQL = @"insert into Temp工费(物料编码, 期初工, 期初费, 期初料, 还原工, 还原费, 还原料, 本期工, 本期费, 本期料, 本期数量, years, months) 
select InvCode,null,null,null,null,null,null,iamotype1,iamotype3,iamotype0,ioutput ,4444444444444444444444 as year,t2.iperiod 
 from (select cppid,cbatch,iperiod,max(iFinQua) as ioutput,Sum(iTotalAmo-iOnpTotalAmo) as iamoall,
		Sum(case camotype when 0 then (iTotalAmo-iOnpTotalAmo) else 0 end) as iamotype0,
		Sum(case camotype when 1 then (iTotalAmo-iOnpTotalAmo) else 0 end) as iamotype1,
		Sum(case camotype when 2 then (iTotalAmo-iOnpTotalAmo) else 0 end) as iamotype2,
		Sum(case camotype when 3 then (iTotalAmo-iOnpTotalAmo) else 0 end) as iamotype3,
		Sum(case camotype when 4 then (iTotalAmo-iOnpTotalAmo) else 0 end) as iamotype4,
		'0' as iflag From dbo.CA_AmoCt group by cppid,cbatch,iperiod ) as t1
left join dbo.ca_rptoutput t2 on t1.cppid=t2.cppid and t1.cbatch=t2.cbatch and t1.iperiod=t2.iperiod 
inner join dbo.caq_coreal t3 on t1.cppid=t3.irealcoid and t3.docstatus<>1 inner join dbo.ca_inventory t4 on t3.invcode=t4.cinvcode where  ioutput<>0 and t2.iperiod=5555555555555555555555 ";
            sSQL = sSQL.Replace("dbo.", 系统服务.ClsBaseDataInfo.sUFDataBaseName + ".dbo.");
            sSQL = sSQL.Replace("4444444444444444444444", 系统服务.ClsBaseDataInfo.sUFDataBaseYear);

            sSQL = sSQL.Replace("5555555555555555555555", month.ToString());
            clsSQLCommond.ExecSql(sSQL);
        }
        #endregion
    }
}
