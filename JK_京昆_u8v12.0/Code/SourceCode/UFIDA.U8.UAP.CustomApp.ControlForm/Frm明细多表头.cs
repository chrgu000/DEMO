using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraGrid.Views.BandedGrid;

namespace UFIDA.U8.UAP.CustomApp.ControlForm
{
    public partial class Frm��ϸ���ͷ : Form
    {

        public void Ӧ���˿�ɹ������;(string cVenCode,string sdate,string edate)
        {
            try
            {
                New("", new string[,]{
                     {"��Ӧ�̼��","��Ӧ�̼��"}
                });
                New("�ɹ���ⵥ", new string[,]{
                     {"�������","�������"}
                    ,{"��ⵥ��","��ⵥ��"}
                    ,{"��������","Ʒ��"}
                    ,{"����ͺ�","����ͺ�"}
                    ,{"�������","����"}
                    ,{"��˰����","����"}
                    ,{"�ݹ����","�ݹ����"}
                });
                New("��������", new string[,]{
                     {"�ɹ�������","�ɹ�������"}
                    ,{"�빺����","�빺����"}
                });
                New("�ɹ���Ʊ", new string[,]{
                     {"�ɹ���Ʊ����","����"}
                    ,{"�ɹ���Ʊ��","���ݺ�"}
                    ,{"�ɹ���Ʊ����","����"}
                    ,{"�ɹ���Ʊ��˰����","��˰����"}
                    ,{"�ɹ���Ʊ��˰�ϼ�","��˰�ϼ�"}
                });

                this.Text = "Ӧ���˿�ɹ������;";
                string sSQL = @"select a.dDate as �������,w.cWhName as ��˾����,a.cDefine10 as �ɹ�Ա,a.cDefine8 as �빺Ա,v.cVenAbbName as ��Ӧ�̼��,a.cCode as ��ⵥ��
,case when ISNULL(a.cHandler ,'')<>'' then '���' when isnull(a.iswfcontrolled,0)=1 and isnull(a.iverifystate ,0)=1 then '�����' when ISNULL(a.cMaker,'')<>'' then '����' end as ����״̬
,r.crdname as ������,ic.cInvCName as �����Ʒ����,i.cInvAddCode as Ʒ�����,i.cInvStd as ����ͺ�,b.cFree1 as ��װ,cBatch as ����,convert(decimal(18, 3),b.iquantity) as ����,cu.cComUnitName ��λ
,a.cMemo as ��ⱸע,dis.cDCName as ����,b.irowno as �к�,b.cInvCode as ���ϱ���,i.cInvName as Ʒ�� ,iUnitCost as ����,iAPrice as �ݹ���� ,pp.cPOID as �ɹ�������,pp.cappcode as �빺����
,pb.dPBVDate as �ɹ���Ʊ����,pb.cPBVCode as �ɹ���Ʊ��,pbs.iPBVQuantity as �ɹ���Ʊ����,pbs.iCost as �ɹ���Ʊ��˰����,pbs.iSum as �ɹ���Ʊ��˰�ϼ�
from RdRecord01 a inner join rdrecords01 b on a.ID = b.ID left join Inventory i on b.cInvCode=i.cInvCode left join Vendor v on a.cVenCode=v.cVenCode
left join Person p on a.cPersonCode=p.cPersonCode left join Department d on a.cDepCode=d.cDepCode left join DistrictClass dis on v.cDCCode=dis.cDCCode
left join Warehouse w on a.cWhCode=w.cWhCode left join InventoryClass ic on i.cInvCCode=ic.cInvCCode left join ComputationUnit cu on i.cComUnitCode=cu.cComUnitCode
left join Rd_Style r on a.cRdCode=r.cRdCode
left join PO_Podetails pps on b.iPOsID=pps.ID left join PO_Pomain pp on pp.POID =pps.POID 
left join PurBillVouchs pbs on pbs.RdsId =b.AutoID left join PurBillVouch pb on pb.PBVID=pbs.PBVID
where 1=1 and b.iquantity>0";
                if (cVenCode != "")
                {
                    sSQL = sSQL.Replace("1=1", "1=1 and a.cVenCode='" + cVenCode + "'");
                }
                if (sdate != "")
                {
                    sSQL = sSQL.Replace("1=1", "1=1 and convert(varchar(10),a.dDate,120)>='" + sdate + "'");
                }
                if (edate != "")
                {
                    sSQL = sSQL.Replace("1=1", "1=1 and convert(varchar(10),a.dDate,120)<='" + edate + "'");
                }
                DataTable dt = SqlHelper.ExecuteDataset(Conn, CommandType.Text, sSQL).Tables[0];
                gridControl1.DataSource = dt;
                for (int i = 0; i < gridView1.Columns.Count; i++)
                {
                    if (gridView1.Columns[i].FieldName == "�������" || gridView1.Columns[i].FieldName == "�ݹ����")
                    {
                        gridView1.Columns[i].Summary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] { new DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum) });
                    }
                }
                gridView1.OptionsBehavior.Editable = false;
                gridView1.BestFitColumns();
            }
            catch (Exception ee)
            {
                MessageBox.Show("��������ʧ��:" + ee.Message);
            }
        }

        public void Ӧ���˿�ɹ�������;(string cVenCode, string sdate, string edate)
        {
            try
            {
                New("", new string[,]{
                     {"��Ӧ�̼��","��Ӧ�̼��"}
                });
                New("�ɹ�����", new string[,]{
                     {"��������","��������"}
                    ,{"������","������"}
                    ,{"��������","Ʒ��"}
                    ,{"����ͺ�","����ͺ�"}
                    ,{"����","����"}
                    ,{"��˰����","��˰����"}
                    ,{"��˰���","��˰���"}
                });
                New("��������", new string[,]{
                     {"�빺����","�빺����"}
                    ,{"�빺����","�빺����"}
                });
                New("�ɹ���ⵥ", new string[,]{
                     {"�ɹ���ⵥ�������","����"}
                    ,{"�ɹ���ⵥ��ⵥ��","���ݺ�"}
                    ,{"�ɹ���ⵥ����","����"}
                    ,{"�ɹ���ⵥ����","��˰����"}
                    ,{"�ɹ���ⵥ��˰���","��˰�ϼ�"}
                });

                this.Text = "Ӧ���˿�ɹ�������;";
                string sSQL = @"select a.dPODate as ��������,w.cWhName as ��˾����,a.cDefine10 as �ɹ�Ա,a.cDefine8 as �빺Ա,v.cVenAbbName as ��Ӧ�̼��,a.cPOID as ������
,ic.cInvCName as �����Ʒ����,i.cInvAddCode as Ʒ�����,i.cInvStd as ����ͺ�,b.cFree1 as ��װ,cBatch as ����,convert(decimal(18, 3),b.iquantity) as ����,cu.cComUnitName ��λ
,a.cMemo as ��ⱸע,dis.cDCName as ����,b.irowno as �к�,b.cInvCode as ���ϱ���,i.cInvName as Ʒ�� ,iUnitCost as ��˰����,iAPrice as ��˰��� 
,pa.cCode  as �빺����,pas.fQuantity as �빺����
,rd.dDate �ɹ���ⵥ�������,rd.cCode as �ɹ���ⵥ��ⵥ��,convert(decimal(18, 3),b.iquantity) as �ɹ���ⵥ����,iUnitCost as �ɹ���ⵥ����,iAPrice as �ɹ���ⵥ��˰���
from PO_Pomain a inner join PO_Podetails b on a.POID = b.POID left join Inventory i on b.cInvCode=i.cInvCode left join Vendor v on a.cVenCode=v.cVenCode
left join Person p on a.cPersonCode=p.cPersonCode left join Department d on a.cDepCode=d.cDepCode left join DistrictClass dis on v.cDCCode=dis.cDCCode
left join InventoryClass ic on i.cInvCCode=ic.cInvCCode left join ComputationUnit cu on i.cComUnitCode=cu.cComUnitCode
left join rdrecords01 rds on rds.iPOsID=b.ID left join RdRecord01 rd on rd.ID =rds.ID  left join Warehouse w on rd.cWhCode=w.cWhCode 
left join PU_AppVouchs pas on b.iAppIds =pas.AutoID left join PU_AppVouch pa on pa.ID =pas.ID 
where 1=1 and b.iquantity>0";
                if (cVenCode != "")
                {
                    sSQL = sSQL.Replace("1=1", "1=1 and a.cVenCode='" + cVenCode + "'");
                }
                if (sdate != "")
                {
                    sSQL = sSQL.Replace("1=1", "1=1 and convert(varchar(10),a.dPODate,120)>='" + sdate + "'");
                }
                if (edate != "")
                {
                    sSQL = sSQL.Replace("1=1", "1=1 and convert(varchar(10),a.dPODate,120)<='" + edate + "'");
                }
                DataTable dt = SqlHelper.ExecuteDataset(Conn, CommandType.Text, sSQL).Tables[0];
                gridControl1.DataSource = dt;
                for (int i = 0; i < gridView1.Columns.Count; i++)
                {
                    if (gridView1.Columns[i].FieldName == "�������" || gridView1.Columns[i].FieldName == "�ݹ����")
                    {
                        gridView1.Columns[i].Summary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] { new DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum) });
                    }
                }
                gridView1.OptionsBehavior.Editable = false;
                gridView1.BestFitColumns();
            }
            catch (Exception ee)
            {
                MessageBox.Show("��������ʧ��:" + ee.Message);
            }
        }

        public void Ӧ���˿�ɹ���Ʊ(string cVenCode, string sdate, string edate)
        {
            try
            {
                New("", new string[,]{
                     {"��Ӧ�̼��","��Ӧ�̼��"}
                });
                New("�ɹ���Ʊ", new string[,]{
                     {"����","����"}
                    ,{"������","������"}
                    ,{"�������","�������"}
                    ,{"����ͺ�","����ͺ�"}
                    ,{"����","����"}
                    ,{"��˰����","��˰����"}
                    ,{"��˰���","��˰���"}
                });
                New("�����ɹ���ⵥ", new string[,]{
                     {"�ɹ���ⵥ�������","����"}
                    ,{"�ɹ���ⵥ��ⵥ��","���ݺ�"}
                    ,{"�ɹ���ⵥ����","����"}
                    ,{"�ɹ���ⵥ����","��˰����"}
                    ,{"�ɹ���ⵥ��˰���","��˰�ϼ�"}
                });
                New("", new string[,]{
                     {"���۲���","���۲���"}
                });
                New("", new string[,]{
                     {"ҵ��Ա","ҵ��Ա"}
                });
                New("", new string[,]{
                     {"��˾����","��˾����"}
                });
                this.Text = "Ӧ���˿�ɹ�������;";
                string sSQL = @"select a.dPBVDate as ����,d.cDepName as ���۲���,w.cWhName as ��˾����,a.cDefine10 as ҵ��Ա,a.cDefine8 as �빺Ա,v.cVenAbbName as ��Ӧ�̼��,a.cPBVCode as ���ݺ�
,ic.cInvCName as �����Ʒ����,i.cInvAddCode as Ʒ�����,i.cInvStd as ����ͺ�,b.cFree1 as ��װ,cBatch as ����,convert(decimal(18, 3),b.iPBVQuantity) as ����,cu.cComUnitName ��λ
,dis.cDCName as ����,b.cInvCode as �������,i.cInvName as Ʒ�� ,iUnitCost as ��˰����,iAPrice as ��˰��� 
,rd.dDate �ɹ���ⵥ�������,rd.cCode as �ɹ���ⵥ��ⵥ��,convert(decimal(18, 3),rds.iquantity) as �ɹ���ⵥ����,iUnitCost as �ɹ���ⵥ����,iAPrice as �ɹ���ⵥ��˰���
from PurBillVouch a inner join PurBillVouchs b on a.PBVID = b.PBVID left join Inventory i on b.cInvCode=i.cInvCode left join Vendor v on a.cVenCode=v.cVenCode
left join Person p on a.cPersonCode=p.cPersonCode left join Department d on a.cDepCode=d.cDepCode left join DistrictClass dis on v.cDCCode=dis.cDCCode
left join InventoryClass ic on i.cInvCCode=ic.cInvCCode left join ComputationUnit cu on i.cComUnitCode=cu.cComUnitCode
left join rdrecords01 rds on rds.iPOsID=b.ID left join RdRecord01 rd on rd.ID =rds.ID  left join Warehouse w on rd.cWhCode=w.cWhCode 
where 1=1 ";
                if (cVenCode != "")
                {
                    sSQL = sSQL.Replace("1=1", "1=1 and a.cVenCode='" + cVenCode + "'");
                }
                if (sdate != "")
                {
                    sSQL = sSQL.Replace("1=1", "1=1 and convert(varchar(10),a.dPBVDate,120)>='" + sdate + "'");
                }
                if (edate != "")
                {
                    sSQL = sSQL.Replace("1=1", "1=1 and convert(varchar(10),a.dPBVDate,120)<='" + edate + "'");
                }
                DataTable dt = SqlHelper.ExecuteDataset(Conn, CommandType.Text, sSQL).Tables[0];
                gridControl1.DataSource = dt;
                for (int i = 0; i < gridView1.Columns.Count; i++)
                {
                    if (gridView1.Columns[i].FieldName == "�������" || gridView1.Columns[i].FieldName == "�ݹ����")
                    {
                        gridView1.Columns[i].Summary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] { new DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum) });
                    }
                }
                gridView1.OptionsBehavior.Editable = false;
                gridView1.BestFitColumns();
            }
            catch (Exception ee)
            {
                MessageBox.Show("��������ʧ��:" + ee.Message);
            }
        }

        public void Ӧ���˿�ɹ�����(string cVenCode, string sdate, string edate)
        {
            try
            {
                New("", new string[,]{
                     {"��Ӧ�̼��","��Ӧ�̼��"}
                });
                New("�ɹ���Ʊ", new string[,]{
                     {"����","����"}
                    ,{"������","������"}
                    ,{"�������","�������"}
                    ,{"����ͺ�","����ͺ�"}
                    ,{"����","����"}
                    ,{"��˰����","��˰����"}
                    ,{"��˰���","��˰���"}
                });
                New("�����ɹ���ⵥ", new string[,]{
                     {"�ɹ���ⵥ�������","����"}
                    ,{"�ɹ���ⵥ��ⵥ��","���ݺ�"}
                    ,{"�ɹ���ⵥ����","����"}
                    ,{"�ɹ���ⵥ����","��˰����"}
                    ,{"�ɹ���ⵥ��˰���","��˰�ϼ�"}
                });
                New("", new string[,]{
                     {"���۲���","���۲���"}
                });
                New("", new string[,]{
                     {"ҵ��Ա","ҵ��Ա"}
                });
                New("", new string[,]{
                     {"��˾����","��˾����"}
                });
                this.Text = "Ӧ���˿�ɹ�������;";
                string sSQL = @"select a.dPBVDate as ����,d.cDepName as ���۲���,w.cWhName as ��˾����,a.cDefine10 as ҵ��Ա,a.cDefine8 as �빺Ա,v.cVenAbbName as ��Ӧ�̼��,a.cPBVCode as ���ݺ�
,ic.cInvCName as �����Ʒ����,i.cInvAddCode as Ʒ�����,i.cInvStd as ����ͺ�,b.cFree1 as ��װ,cBatch as ����,convert(decimal(18, 3),b.iPBVQuantity) as ����,cu.cComUnitName ��λ
,dis.cDCName as ����,b.cInvCode as �������,i.cInvName as Ʒ�� ,iUnitCost as ��˰����,iAPrice as ��˰��� 
,rd.dDate �ɹ���ⵥ�������,rd.cCode as �ɹ���ⵥ��ⵥ��,convert(decimal(18, 3),rds.iquantity) as �ɹ���ⵥ����,iUnitCost as �ɹ���ⵥ����,iAPrice as �ɹ���ⵥ��˰���
from PurBillVouch a inner join PurBillVouchs b on a.PBVID = b.PBVID left join Inventory i on b.cInvCode=i.cInvCode left join Vendor v on a.cVenCode=v.cVenCode
left join Person p on a.cPersonCode=p.cPersonCode left join Department d on a.cDepCode=d.cDepCode left join DistrictClass dis on v.cDCCode=dis.cDCCode
left join InventoryClass ic on i.cInvCCode=ic.cInvCCode left join ComputationUnit cu on i.cComUnitCode=cu.cComUnitCode
left join rdrecords01 rds on rds.iPOsID=b.ID left join RdRecord01 rd on rd.ID =rds.ID  left join Warehouse w on rd.cWhCode=w.cWhCode 
where 1=1 ";
                if (cVenCode != "")
                {
                    sSQL = sSQL.Replace("1=1", "1=1 and a.cVenCode='" + cVenCode + "'");
                }
                if (sdate != "")
                {
                    sSQL = sSQL.Replace("1=1", "1=1 and convert(varchar(10),a.dPBVDate,120)>='" + sdate + "'");
                }
                if (edate != "")
                {
                    sSQL = sSQL.Replace("1=1", "1=1 and convert(varchar(10),a.dPBVDate,120)<='" + edate + "'");
                }
                DataTable dt = SqlHelper.ExecuteDataset(Conn, CommandType.Text, sSQL).Tables[0];
                gridControl1.DataSource = dt;
                for (int i = 0; i < gridView1.Columns.Count; i++)
                {
                    if (gridView1.Columns[i].FieldName == "�������" || gridView1.Columns[i].FieldName == "�ݹ����")
                    {
                        gridView1.Columns[i].Summary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] { new DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum) });
                    }
                }
                gridView1.OptionsBehavior.Editable = false;
                gridView1.BestFitColumns();
            }
            catch (Exception ee)
            {
                MessageBox.Show("��������ʧ��:" + ee.Message);
            }
        }

        public void Ӧ���˿����۷�����;(string cCusCode, string sdate, string edate)
        {
            try
            {
                New("", new string[,]{
                     {"�ͻ����","�ͻ����"}
                });
                New("�ɹ���ⵥ", new string[,]{
                     {"��������","��������"}
                    ,{"��������","��������"}
                    ,{"��������","Ʒ��"}
                    ,{"����ͺ�","����ͺ�"}
                    ,{"����","����"}
                    ,{"��˰����","����"}
                    ,{"�ݹ����","�ݹ����"}
                });
                New("���۷�Ʊ", new string[,]{
                     {"���۷�Ʊ����","����"}
                    ,{"���۷�Ʊ��","���ݺ�"}
                    ,{"���۷�Ʊ����","����"}
                    ,{"���۷�Ʊ��˰����","��˰����"}
                    ,{"���۷�Ʊ��˰�ϼ�","��˰�ϼ�"}
                });

                this.Text = "Ӧ���˿����۷�����;";
                string sSQL = @"select a.dDate as ��������,a.cDefine10 as �ɹ�Ա,a.cDefine8 as �빺Ա,c.cCusAbbName as �ͻ����,a.cDLCode as ��������
,case when ISNULL(a.cVerifier ,'')<>'' then '���' when isnull(a.iswfcontrolled,0)=1 and isnull(a.iverifystate ,0)=1 then '�����' when ISNULL(a.cMaker,'')<>'' then '����' end as ����״̬
,r.crdname as ������,ic.cInvCName as �����Ʒ����,i.cInvAddCode as Ʒ�����,i.cInvStd as ����ͺ�,b.cFree1 as ��װ,b.cBatch as ����,convert(decimal(18, 3),b.iquantity) as ����,cu.cComUnitName ��λ
,a.cMemo as ��ⱸע,dis.cDCName as ����,b.irowno as �к�,b.cInvCode as ���ϱ���,i.cInvName as Ʒ�� ,b.iNatSum/b.iQuantity as ����,b.iNatSum as �ݹ���� 
,fp.dDate as ���۷�Ʊ����,fp.cSBVCode as ���۷�Ʊ��,fps.iQuantity as ���۷�Ʊ����,fps.iNatSum/fps.iQuantity as ���۷�Ʊ��˰����,fps.iSum as ���۷�Ʊ��˰�ϼ�
from DispatchList a inner join DispatchLists b on a.DLID = b.DLID left join Inventory i on b.cInvCode=i.cInvCode left join Customer c on a.cCusCode=c.cCusCode
left join Person p on a.cPersonCode=p.cPersonCode left join Department d on a.cDepCode=d.cDepCode left join DistrictClass dis on c.cDCCode=dis.cDCCode
left join InventoryClass ic on i.cInvCCode=ic.cInvCCode left join ComputationUnit cu on i.cComUnitCode=cu.cComUnitCode
left join Rd_Style r on a.cRdCode=r.cRdCode
left join SO_SODetails dds on b.iSOsID=dds.ID left join SO_SOMain dd on dd.ID  =dds.ID  
left join SaleBillVouchs fps on fps.RdsId =b.AutoID left join SaleBillVouch fp on fp.SBVID=fps.SBVID
where 1=1 and b.iquantity>0";
                if (cCusCode != "")
                {
                    sSQL = sSQL.Replace("1=1", "1=1 and a.cVenCode='" + cCusCode + "'");
                }
                if (sdate != "")
                {
                    sSQL = sSQL.Replace("1=1", "1=1 and convert(varchar(10),a.dDate,120)>='" + sdate + "'");
                }
                if (edate != "")
                {
                    sSQL = sSQL.Replace("1=1", "1=1 and convert(varchar(10),a.dDate,120)<='" + edate + "'");
                }
                DataTable dt = SqlHelper.ExecuteDataset(Conn, CommandType.Text, sSQL).Tables[0];
                gridControl1.DataSource = dt;
                for (int i = 0; i < gridView1.Columns.Count; i++)
                {
                    if (gridView1.Columns[i].FieldName == "�������" || gridView1.Columns[i].FieldName == "�ݹ����")
                    {
                        gridView1.Columns[i].Summary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] { new DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum) });
                    }
                }
                gridView1.OptionsBehavior.Editable = false;
                gridView1.BestFitColumns();
            }
            catch (Exception ee)
            {
                MessageBox.Show("��������ʧ��:" + ee.Message);
            }
        }

        public void Ӧ���˿����۷�Ʊ����;(string cCusCode, string sdate, string edate)
        {
            try
            {
                New("", new string[,]{
                     {"�ͻ����","�ͻ����"}
                });
                New("���۷�Ʊ", new string[,]{
                     {"��Ʊ����","����"}
                    ,{"������","������"}
                    ,{"��������","Ʒ��"}
                    ,{"����ͺ�","����ͺ�"}
                    ,{"����","����"}
                    ,{"��˰����","��˰����"}
                    ,{"��˰���","��˰���"}
                });
                New("��������", new string[,]{
                     {"�빺����","�빺����"}
                    ,{"�빺����","�빺����"}
                });
                New("�ɹ���ⵥ", new string[,]{
                     {"�ɹ���ⵥ�������","����"}
                    ,{"�ɹ���ⵥ��ⵥ��","���ݺ�"}
                    ,{"�ɹ���ⵥ����","����"}
                    ,{"�ɹ���ⵥ����","��˰����"}
                    ,{"�ɹ���ⵥ��˰���","��˰�ϼ�"}
                });

                this.Text = "Ӧ���˿����۷�Ʊ����;";
                string sSQL = @"
//select a.dPODate as ��Ʊ����,w.cWhName as ��˾����,a.cDefine10 as �ɹ�Ա,a.cDefine8 as �빺Ա,v.cVenAbbName as ��Ӧ�̼��,a.cPOID as ������
//,ic.cInvCName as �����Ʒ����,i.cInvAddCode as Ʒ�����,i.cInvStd as ����ͺ�,b.cFree1 as ��װ,cBatch as ����,convert(decimal(18, 3),b.iquantity) as ����,cu.cComUnitName ��λ
//,a.cMemo as ��ⱸע,dis.cDCName as ����,b.irowno as �к�,b.cInvCode as ���ϱ���,i.cInvName as Ʒ�� ,iUnitCost as ��˰����,iAPrice as ��˰��� 
//,pa.cCode  as �빺����,pas.fQuantity as �빺����
//,rd.dDate �ɹ���ⵥ�������,rd.cCode as �ɹ���ⵥ��ⵥ��,convert(decimal(18, 3),b.iquantity) as �ɹ���ⵥ����,iUnitCost as �ɹ���ⵥ����,iAPrice as �ɹ���ⵥ��˰���
//from PO_Pomain a inner join PO_Podetails b on a.POID = b.POID left join Inventory i on b.cInvCode=i.cInvCode left join Vendor v on a.cVenCode=v.cVenCode
//left join Person p on a.cPersonCode=p.cPersonCode left join Department d on a.cDepCode=d.cDepCode left join DistrictClass dis on v.cDCCode=dis.cDCCode
//left join InventoryClass ic on i.cInvCCode=ic.cInvCCode left join ComputationUnit cu on i.cComUnitCode=cu.cComUnitCode
//left join rdrecords01 rds on rds.iPOsID=b.ID left join RdRecord01 rd on rd.ID =rds.ID  left join Warehouse w on rd.cWhCode=w.cWhCode 
//left join PU_AppVouchs pas on b.iAppIds =pas.AutoID left join PU_AppVouch pa on pa.ID =pas.ID 
//where 1=1 and b.iquantity>0
";
                if (cCusCode != "")
                {
                    sSQL = sSQL.Replace("1=1", "1=1 and a.cCusCode='" + cCusCode + "'");
                }
                if (sdate != "")
                {
                    sSQL = sSQL.Replace("1=1", "1=1 and convert(varchar(10),a.dPODate,120)>='" + sdate + "'");
                }
                if (edate != "")
                {
                    sSQL = sSQL.Replace("1=1", "1=1 and convert(varchar(10),a.dPODate,120)<='" + edate + "'");
                }
                DataTable dt = SqlHelper.ExecuteDataset(Conn, CommandType.Text, sSQL).Tables[0];
                gridControl1.DataSource = dt;
                for (int i = 0; i < gridView1.Columns.Count; i++)
                {
                    if (gridView1.Columns[i].FieldName == "�������" || gridView1.Columns[i].FieldName == "�ݹ����")
                    {
                        gridView1.Columns[i].Summary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] { new DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum) });
                    }
                }
                gridView1.OptionsBehavior.Editable = false;
                gridView1.BestFitColumns();
            }
            catch (Exception ee)
            {
                MessageBox.Show("��������ʧ��:" + ee.Message);
            }
        }

        private void New(string Caption, string[,] col)
        {
            GridBand b1 = NewBand(Caption);
            for (int i = 0; i < col.Length / 2; i++)
            {
                NewCol(b1, col[i, 0], col[i, 1]);
            }
        }

        private GridBand NewBand(string Caption)
        {
            GridBand b = new GridBand();
            b.Caption = Caption;
            b.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            gridView1.Bands.Add(b);
            return b;
        }

        private void NewCol(GridBand b, string FieldName, string Caption)
        {
            BandedGridColumn Col = new BandedGridColumn();
            Col.FieldName = FieldName;
            Col.Caption = Caption;
            Col.Width = 75;
            Col.Visible = true;
            Col.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            b.Columns.Add(Col);
        }

        public string Conn { get; set; }

        public Frm��ϸ���ͷ(string conn)
        {
            InitializeComponent();
            Conn = conn;
        }
        
        private void Frm��ϸ���ͷ_Load(object sender, EventArgs e)
        {
            try
            {
                ϵͳ����.���.GetGridViewSet(gridView1);
            }
            catch (Exception ee)
            {
                MessageBox.Show("�����ϸ��Ϣʧ�ܣ�  " + ee.Message);
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}