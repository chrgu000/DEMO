
alter table 材料入库单表头     add 材料类型 nvarchar(50)
alter table 开料单表头     add 材料类型 nvarchar(50)

update 开料单表头 set 材料类型='板'
update 材料入库单表头 set 材料类型='板'


insert into  UserDefine(cID,cValue) values(52,'板')
insert into  UserDefine(cID,cValue) values(52,'棒')

