
--	暂估材料余额表 

-- 期初
select 
	--Ia_Subsidiary.AutoID,Ia_Subsidiary.ID,isnull(cSrcVouType,cVouType) As cVouType,Cast(IaInquantity As Decimal(34,8)) As QcQuantity
	--,
	sum((case when Ia_Subsidiary.cbustype= N'委外加工' then isnull(iainprice,0)+isnull(iDebitDifCost,0)-isnull(iCreditDifCost,0)-isnull(imaterialfee,0) else Cast(iainprice+isnull(iDebitDifCost,0)-isnull(iCreditDifCost,0) As Decimal(34,8)) end)) as Qcmoney
From ia_subsidiary
left join Inventory  On Inventory.cInvCode = Ia_Subsidiary.cInvcode
left join InventoryClass  On Inventory.cInvCCode = InventoryClass.cInvCCode
left join Warehouse  On Warehouse.cWhCode = Ia_Subsidiary.cWhCode
left join Department on Department.cDepCode=Ia_Subsidiary.cDepCode
left join Rd_Style on Rd_Style.cRdCode= Ia_Subsidiary.cRdCode
left join Vendor on Vendor.cVenCode = Ia_Subsidiary.cVenCode
left join VendorClass on Vendor.cVCCode = VendorClass.cVCCode
Where (( ia_subsidiary.cVouType in (N'01',N'70')  and bFlag = 1) or (cvoutype in (N'30',N'24') and bFlag = 1 and  ia_subsidiary.cSRcVoutype in (N'01',N'70') ) or (cVouType = '33' and  ia_subsidiary.cSRcVoutype in (N'01',N'70') ))
And cBusType In (N'普通采购',N'委外加工',N'一般贸易进口',N'进料加工') and imonth < 2
and  1=1   And (ia_subsidiary.iyear = N'2018') and  ((Ia_subsidiary.cWhCode IN (Select cWhCode From Warehouse Where bInCost = 1))  or Ia_subsidiary.cWhCode is null) 

