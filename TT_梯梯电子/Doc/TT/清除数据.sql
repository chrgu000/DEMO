

update PU_AppVouch set cCloser = 'th' where cCloser <> 'th' 
update PU_AppVouchs set cbcloser = 'th' where cbcloser <> 'th' 

update PO_Podetails set cbCloser = 'th' where cbCloser <> 'th' 

update PU_ArrivalVouch set ccloser  = 'th' where ccloser <> 'th' 


update OM_momain set cCloser  = 'th' where cCloser <> 'th' 
update om_modetails set cbCloser  = 'th' where cbCloser <> 'th' 



update mom_orderdetail set Status = 4 where Status <> 4

update SO_SOMain set cCloser  = 'th' where cCloser <> 'th' 
update SO_SODetails set cSCloser  = 'th' where cSCloser <> 'th' 