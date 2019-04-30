select a.moid,c.modid,d.MoRoutingId,d.MoRoutingDId ,b.startDate as ��������,b.DueDate as �깤����
    ,a.MoCode as ����������,c.SortSeq as ���������к�,c.InvCode as ���ϱ���
    ,c.Qty as ������������,c.QualifiedInQty  as �������,c.SoCode as ���۶�����,c.SoSeq as ���۶����к�,c.Define26 as ����
    ,d.OpSeq as �����к�,d.Operationid as ��׼����ID,d.Description as ����˵��
    ,case when isnull(g.iID,0) = 0 then d.StartDate else g.�������� end as ���򿪹�����
    ,case when isnull(g.iID,0) = 0 then c.Qty - isnull(c.QualifiedInQty,0) else g.���� end as �����Ų�����,d.CompleteQty  as �����������
    ,d.DueDate as �����깤����
    ,d.WcID as �������Ĵ���,f.WcCode  as �������Ĵ���,f.Description as ������������
    ,case when d.SubFlag  = 1 then '��' else '��' end as ί�⹤��
    ,e.OperationId  as ��׼����ID,e.OpCode as ��׼�������,e.Description as ��׼����˵��
    ,isnull(d.Define27,0) as �����ӹ���ʱ,isnull(d.Define34,0) as �������,isnull(d.Define35,0) as �Ƿ�ƿ������
from UFDATA_100_2014..mom_order a 
    inner join UFDATA_100_2014..mom_morder b on a.moid = b.moid
    inner join UFDATA_100_2014..mom_orderdetail c on b.moid = a.moid and b.modid = c.modid
    inner join UFDATA_100_2014..sfc_moroutingdetail d on d.modid = c.modid
    inner join UFDATA_100_2014..sfc_operation e on e.OperationId = d.OperationId 
    inner join UFDATA_100_2014..sfc_workcenter f on f.WcId = d.WcID
    left join dbo.���������ռƻ� g on g.��������ID = d.MoRoutingDId
where c.Status = 3 
	and a.MoCode = 'SCDD14060001' and c.SortSeq = 1
order by a.moid,c.modid,d.OpSeq


