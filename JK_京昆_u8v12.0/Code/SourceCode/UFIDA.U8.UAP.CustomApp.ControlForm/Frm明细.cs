using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraGrid.Columns;

namespace UFIDA.U8.UAP.CustomApp.ControlForm
{
    public partial class Frm��ϸ : Form
    {
        public string Conn { get; set; }
        string icinvcode; string isdate; string iedate; bool ibcHandler; bool ibcHas; string icFree3; string icFree4; string icWhCode; string icPosCode;

        public Frm��ϸ(string conn)
        {
            InitializeComponent();
            Conn = conn;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="cDepCode">����</param>
        /// <param name="cPersonCode">����Ա</param>
        /// <param name="cCusCode">�ͻ�</param>
        /// <param name="cDCName">����</param>
        /// <param name="cInvName">���</param>
        /// <param name="year"></param>
        /// <param name="month"></param>
        public void ���۳�����ϸ(string cDepCode, string cPersonCode, string cDCName, string cInvCode, string cCusCode, string year, string month)
        {
            try
            {
                this.Text = "���۳�����ϸ";
                string sSQL = @"select a.dDate as ����,w.cWhName as ��˾����,p.cPersonName as ҵ��Ա,c.cCusAbbName as �ͻ����,a.cCode as ���ݺ�
,case when ISNULL(a.cHandler ,'')<>'' then '���' when isnull(a.iswfcontrolled,0)=1 and isnull(a.iverifystate ,0)=1 then '�����' when ISNULL(a.cMaker,'')<>'' then '����' end as ����״̬
,i.cInvName as Ʒ�����,i.cInvStd as ����ͺ�,cFree1 as ��װ,cBatch as ����,convert(decimal(18, 3),b.iquantity) as ����,cu.cComUnitName ��λ
,convert(decimal(18, 2),b.iUnitCost) as ��˰���� ,convert(decimal(18, 2),b.iPrice) as ��˰���,rs.cRdName as ���۳������
,cBatchProperty6 as ���ϱ�ʶ��ע,cBatchProperty7 as ��װ����,cBatchProperty9 as ��ҵָ����,cMaker as �Ƶ���
--,d.cDepName as ����,dis.cDCName as ����,b.irowno as �к�,b.cInvCode as ���ϱ���,i.cInvName as Ʒ�� 
from RdRecord32 a inner join rdrecords32 b on a.ID = b.ID left join Inventory i on b.cInvCode=i.cInvCode left join Customer c on a.cCusCode=c.cCusCode
left join Person p on a.cPersonCode=p.cPersonCode left join Department d on a.cDepCode=d.cDepCode left join DistrictClass dis on c.cDCCode=dis.cDCCode
left join Warehouse w on a.cWhCode=w.cWhCode left join InventoryClass ic on i.cInvCCode=ic.cInvCCode left join ComputationUnit cu on i.cComUnitCode=cu.cComUnitCode
left join Rd_Style rs on a.cRdCode =rs.cRdCode 
where 1=1 ";
                if (cDepCode != "")
                {
                    sSQL = sSQL.Replace("1=1", "1=1 and isnull(d.cDepName,'')='" + cDepCode + "'");
                }
                if (cPersonCode != "")
                {
                    sSQL = sSQL.Replace("1=1", "1=1 and isnull(p.cPersonName,'')='" + cPersonCode + "'");
                }
                if (cCusCode != "")
                {
                    sSQL = sSQL.Replace("1=1", "1=1 and isnull(c.cCusName,'')='" + cCusCode + "'");
                }
                if (cInvCode != "")
                {
                    sSQL = sSQL.Replace("1=1", "1=1 and isnull(i.cInvCode,'')='" + cInvCode + "'");
                }
                if (cDCName != "")
                {
                    sSQL = sSQL.Replace("1=1", "1=1 and isnull(dis.cDCName,'')='" + cDCName + "'");
                }
                if (year != "")
                {
                    sSQL = sSQL.Replace("1=1", "1=1 and datepart(yyyy,a.dDate)='" + year + "'");
                }
                if (month != "")
                {
                    sSQL = sSQL.Replace("1=1", "1=1 and datepart(mm,a.dDate)='" + month + "'");
                }
                sSQL = sSQL + " order by a.dDate";
                DataTable dt = SqlHelper.ExecuteDataset(Conn, CommandType.Text, sSQL).Tables[0];
                gridControl1.DataSource = dt;
                for (int i = 0; i < gridView1.Columns.Count; i++)
                {
                    if (gridView1.Columns[i].FieldName == "����" || gridView1.Columns[i].FieldName == "��˰���")
                    {
                        gridView1.Columns[i].Summary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] { new DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum) });
                    }
                }
                gridView1.OptionsBehavior.Editable = false;
            }
            catch (Exception ee)
            {
                MessageBox.Show("��������ʧ��:" + ee.Message);
            }
        }

        public void ���ϳ�����ϸ(string cDepCode, string cInvCode, string year, string month)
        {
            try
            {
                this.Text = "���ϳ�����ϸ";
                string sSQL = @"select a.dDate as ����,w.cWhName as �ֿ�,a.cDefine3 as ��������,a.cMaker as �Ƶ���,a.cCode as ���ݺ�
,case when ISNULL(a.cHandler ,'')<>'' then '���' when isnull(a.iswfcontrolled,0)=1 and isnull(a.iverifystate ,0)=1 then '�����' when ISNULL(a.cMaker,'')<>'' then '����' end as ����״̬
,i.cInvName as Ʒ�����,i.cInvStd as ����ͺ�,cFree1 as ��װ,cBatch as ����,convert(decimal(18, 3),b.iquantity) as ����,cu.cComUnitName ��λ
,cBatchProperty6 as ���ϱ�ʶ��ע,cBatchProperty7 as ��װ����,cBatchProperty9 as ��ҵָ����,cFree3 as �����,cPosName as �ⷿ,r.crdname as �������
--,dis.cDCName as ����,c.cCusName as �ͻ�,b.cInvCode as ���ϱ���,i.cInvName as Ʒ��,ic.cInvCName as �����Ʒ����,i.cInvName as Ʒ�����,w.cWhName as ��˾����,d.cDepName as ���ϲ���,p.cPersonName as ������Ա
from RdRecord11 a inner join rdrecords11 b on a.ID = b.ID left join Inventory i on b.cInvCode=i.cInvCode left join Customer c on a.cCusCode=c.cCusCode
left join Person p on a.cPersonCode=p.cPersonCode left join Department d on a.cDepCode=d.cDepCode left join DistrictClass dis on c.cDCCode=dis.cDCCode
left join Warehouse w on a.cWhCode=w.cWhCode left join InventoryClass ic on i.cInvCCode=ic.cInvCCode left join ComputationUnit cu on i.cComUnitCode=cu.cComUnitCode
left join Rd_Style r on a.cRdCode=r.cRdCode left join Position po on b.cPosition =po.cPosCode 
where 1=1 ";
                if (cDepCode != "")
                {
                    sSQL = sSQL.Replace("1=1", "1=1 and isnull(d.cDepName,'')='" + cDepCode + "'");
                }
                if (cInvCode != "")
                {
                    sSQL = sSQL.Replace("1=1", "1=1 and isnull(i.cInvCode,'')='" + cInvCode + "'");
                }
                if (year != "")
                {
                    sSQL = sSQL.Replace("1=1", "1=1 and datepart(yyyy,a.dDate)='" + year + "'");
                }
                if (month != "")
                {
                    sSQL = sSQL.Replace("1=1", "1=1 and datepart(mm,a.dDate)='" + month + "'");
                }
                sSQL = sSQL + " order by a.dDate";
                DataTable dt = SqlHelper.ExecuteDataset(Conn, CommandType.Text, sSQL).Tables[0];
                gridControl1.DataSource = dt;
                for (int i = 0; i < gridView1.Columns.Count; i++)
                {
                    if (gridView1.Columns[i].FieldName == "����" || gridView1.Columns[i].FieldName == "���")
                    {
                        gridView1.Columns[i].Summary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] { new DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum) });
                    }
                }
                gridView1.OptionsBehavior.Editable = false;
            }
            catch (Exception ee)
            {
                MessageBox.Show("��������ʧ��:" + ee.Message);
            }
        }

        public void �ɹ���ⵥ��ϸ(string cDepCode, string cPersonCode, string cVenName,
            //string cWhCode,string cPosCode,string cFree4, 
            string cInvCode, string year, string month)
        {
            try
            {
                this.Text = "�ɹ���ⵥ��ϸ";
                string sSQL = @"select a.dDate as ����,w.cWhName as ��˾����,a.cDefine10 as �ɹ�Ա,v.cVenAbbName as ��Ӧ�̼��,a.cCode as ���ݺ�
,case when ISNULL(a.cHandler ,'')<>'' then '���' when isnull(a.iswfcontrolled,0)=1 and isnull(a.iverifystate ,0)=1 then '�����' when ISNULL(a.cMaker,'')<>'' then '����' end as ����״̬
,i.cInvName as Ʒ�����,i.cInvStd as ����ͺ�,cFree1 as ��װ,cBatch as ����,convert(decimal(18, 3),b.iquantity) as ����,cu.cComUnitName ��λ
,convert(decimal(18, 2),b.iUnitCost) as ��˰���� ,convert(decimal(18, 2),b.iPrice) as ��˰���,b.dSDate as �������� ,cBatchProperty6 as ���ϱ�ʶ��ע,cFree3 as �����,r.crdname as ������
--,ic.cInvCName as �����Ʒ����,a.cMemo as ��ⱸע,dis.cDCName as ����,b.irowno as �к�,b.cInvCode as ���ϱ���,i.cInvName as Ʒ�� ,a.cDefine8 as �빺Ա
from RdRecord01 a inner join rdrecords01 b on a.ID = b.ID left join Inventory i on b.cInvCode=i.cInvCode left join Vendor v on a.cVenCode=v.cVenCode
left join Person p on a.cPersonCode=p.cPersonCode left join Department d on a.cDepCode=d.cDepCode left join DistrictClass dis on v.cDCCode=dis.cDCCode
left join Warehouse w on a.cWhCode=w.cWhCode left join InventoryClass ic on i.cInvCCode=ic.cInvCCode left join ComputationUnit cu on i.cComUnitCode=cu.cComUnitCode
left join Rd_Style r on a.cRdCode=r.cRdCode
where 1=1 ";
                if (cDepCode != "")
                {
                    sSQL = sSQL.Replace("1=1", "1=1 and isnull(d.cDepName,'')='" + cDepCode + "'");
                }
                if (cPersonCode != "")
                {
                    sSQL = sSQL.Replace("1=1", "1=1 and isnull(cdefine10,'')='" + cPersonCode + "'");
                }
                if (cVenName != "")
                {
                    sSQL = sSQL.Replace("1=1", "1=1 and isnull(v.cVenName,'')='" + cVenName + "'");
                }
                if (cInvCode != "")
                {
                    sSQL = sSQL.Replace("1=1", "1=1 and isnull(i.cInvCode,'')='" + cInvCode + "'");
                }
                if (year != "")
                {
                    sSQL = sSQL.Replace("1=1", "1=1 and datepart(yyyy,a.dDate)='" + year + "'");
                }
                if (month != "")
                {
                    sSQL = sSQL.Replace("1=1", "1=1 and datepart(mm,a.dDate)='" + month + "'");
                }
                //if (cWhCode != "")
                //{
                //    sSQL = sSQL.Replace("1=1", "1=1 and isnull(a.cWhCode,'')='" + cWhCode + "'");
                //}
                //if (cPosCode != "")
                //{
                //    sSQL = sSQL.Replace("1=1", "1=1 and isnull(b.cPosition,'')='" + cPosCode + "'");
                //}
                //if (cFree4 != "")
                //{
                //    sSQL = sSQL.Replace("1=1", "1=1 and isnull(b.cFree4,'')='" + cFree4 + "'");
                //}
                sSQL = sSQL + " order by a.dDate";
                DataTable dt = SqlHelper.ExecuteDataset(Conn, CommandType.Text, sSQL).Tables[0];
                gridControl1.DataSource = dt;
                for (int i = 0; i < gridView1.Columns.Count; i++)
                {
                    if (gridView1.Columns[i].FieldName == "����" || gridView1.Columns[i].FieldName == "��˰���")
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

        public void ��Ʒ��ⵥ��ϸ(string cInvCode, string year, string month,int Flag,string cCode)
        {
            try
            {
                this.Text = "��Ʒ��ⵥ��ϸ";
                string sSQL = @"select a.dDate as ����,w.cWhName as �ֿ�,a.cDefine3 as ��������,a.cMaker as �Ƶ���,a.cCode as ���ݺ�
,case when ISNULL(a.cHandler ,'')<>'' then '���' when isnull(a.iswfcontrolled,0)=1 and isnull(a.iverifystate ,0)=1 then '�����' when ISNULL(a.cMaker,'')<>'' then '����' end as ����״̬
,i.cInvName as Ʒ�����,i.cInvStd as ����ͺ�,cFree1 as ��װ,cBatch as ����,convert(decimal(18, 3),b.iquantity) as ����,cu.cComUnitName ��λ
,cBatchProperty6 as ���ϱ�ʶ��ע,cBatchProperty7 as ��װ����,cBatchProperty9 as ��ҵָ����,cFree3 as �����,cPosName as �ⷿ,r.crdname as �������
--,r.crdname as �������,dis.cDCName as ����,v.cVenName as �ͻ�,a.dDate as ����,b.cInvCode as ���ϱ���,i.cInvName as Ʒ��, w.cWhName as ��˾����,ic.cInvCName as �����Ʒ����,r.crdname as �������
from RdRecord10 a inner join rdrecords10 b on a.ID = b.ID left join Inventory i on b.cInvCode=i.cInvCode left join Vendor v on a.cVenCode=v.cVenCode
left join Person p on a.cPersonCode=p.cPersonCode left join Department d on a.cDepCode=d.cDepCode left join DistrictClass dis on v.cDCCode=dis.cDCCode
left join Warehouse w on a.cWhCode=w.cWhCode left join InventoryClass ic on i.cInvCCode=ic.cInvCCode left join ComputationUnit cu on i.cComUnitCode=cu.cComUnitCode
left join Rd_Style r on a.cRdCode=r.cRdCode  left join Position po on b.cPosition =po.cPosCode 
where 1=1 ";
                if (cInvCode != "")
                {
                    sSQL = sSQL.Replace("1=1", "1=1 and isnull(i.cInvCode,'')='" + cInvCode + "'");
                }
                if (year != "")
                {
                    sSQL = sSQL.Replace("1=1", "1=1 and datepart(yyyy,a.dDate)='" + year + "'");
                }
                if (month != "")
                {
                    sSQL = sSQL.Replace("1=1", "1=1 and datepart(mm,a.dDate)='" + month + "'");
                }
                if (cCode != "")
                {
                    sSQL = sSQL.Replace("1=1", "1=1 and a.cCode='" + cCode + "'");
                }
                sSQL = sSQL + " order by a.dDate";
                DataTable dt = SqlHelper.ExecuteDataset(Conn, CommandType.Text, sSQL).Tables[0];
                gridControl1.DataSource = dt;
                for (int i = 0; i < gridView1.Columns.Count; i++)
                {
                    if (gridView1.Columns[i].FieldName == "����" || gridView1.Columns[i].FieldName == "���")
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

        //�������ͳ��

//        public void �ۼ����(string cInvCode, string sdate, string edate, string cposname, string cFree1, string cFree3)
//        {
//            try
//            {
//                this.Text = "�ۼ������ϸ";
//                string sSQL = @"select a.dDate as �������, w.cWhName as ��˾����,ic.cInvCName as �����Ʒ����,i.cInvName as Ʒ�����,i.cInvStd as ����ͺ�,cFree1 as ��װ,r.crdname as �������,a.cCode as ��ⵥ��
//,case when ISNULL(a.cHandler ,'')<>'' then '���' when isnull(a.iswfcontrolled,0)=1 and isnull(a.iverifystate ,0)=1 then '�����' when ISNULL(a.cMaker,'')<>'' then '����' end as ����״̬
//,r.crdname as �������,cBatch as ����,convert(decimal(18, 3),b.iquantity) as ����,cu.cComUnitName ��λ
//,cBatchProperty6 as ���ϱ�ʶ��ע,cBatchProperty7 as ��װ����,cBatchProperty9 as ��ҵָ����
//,dis.cDCName as ����,v.cVenName as �ͻ�,a.dDate as ����,b.cInvCode as ���ϱ���,i.cInvName as Ʒ��
//from RdRecord10 a inner join rdrecords10 b on a.ID = b.ID left join Inventory i on b.cInvCode=i.cInvCode left join Vendor v on a.cVenCode=v.cVenCode
//left join Person p on a.cPersonCode=p.cPersonCode left join Department d on a.cDepCode=d.cDepCode left join DistrictClass dis on v.cDCCode=dis.cDCCode
//left join Warehouse w on a.cWhCode=w.cWhCode left join InventoryClass ic on i.cInvCCode=ic.cInvCCode left join ComputationUnit cu on i.cComUnitCode=cu.cComUnitCode
//left join Rd_Style r on a.cRdCode=r.cRdCode
//where 1=1 and b.iquantity>0";
//                if (cInvCode != "")
//                {
//                    sSQL = sSQL.Replace("1=1", "1=1 and isnull(i.cInvCode,'')='" + cInvCode + "'");
//                }
//                if (sdate != "")
//                {
//                    sSQL = sSQL.Replace("1=1", "1=1 and convert(varchar(10),a.dDate,120)>='" + sdate + "'");
//                }
//                if (edate != "")
//                {
//                    sSQL = sSQL.Replace("1=1", "1=1 and convert(varchar(10),a.dDate,120)<='" + edate + "'");
//                }
//                if (cposname != "")
//                {
//                    sSQL = sSQL.Replace("1=1", "1=1 and cposname='" + cposname + "'");
//                }
//                if (cFree1 != "")
//                {
//                    sSQL = sSQL.Replace("1=1", "1=1 and b.cFree1='" + cFree1 + "'");
//                }
//                if (cFree3 != "")
//                {
//                    sSQL = sSQL.Replace("1=1", "1=1 and b.cFree3='" + cFree3 + "'");
//                }
//                sSQL = sSQL + " order by a.dDate";
//                DataTable dt = SqlHelper.ExecuteDataset(Conn, CommandType.Text, sSQL).Tables[0];
//                gridControl1.DataSource = dt;
//                for (int i = 0; i < gridView1.Columns.Count; i++)
//                {
//                    if (gridView1.Columns[i].FieldName == "����" || gridView1.Columns[i].FieldName == "���")
//                    {
//                        gridView1.Columns[i].Summary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] { new DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum) });
//                    }
//                }
//                gridView1.OptionsBehavior.Editable = false;
//            }
//            catch (Exception ee)
//            {
//                MessageBox.Show("��������ʧ��:" + ee.Message);
//            }
//        }

        public void �ۼ�����(string cInvCode, string sdate, string edate, string cposname, string cFree1, string cFree3, int Flag, string cCode)
        {
            try
            {
                this.Text = "�ۼ�������ϸ";
                string sSQL = @"select w.cWhName as ��˾����,d.cDepName as ���ϲ���,a.cDefine3 as ��������,p.cPersonName as ������Ա,a.cCode as ���ⵥ��
,case when ISNULL(a.cHandler ,'')<>'' then '���' when isnull(a.iswfcontrolled,0)=1 and isnull(a.iverifystate ,0)=1 then '�����' when ISNULL(a.cMaker,'')<>'' then '����' end as ����״̬
,r.crdname as �������,ic.cInvCName as �����Ʒ����,i.cInvName as Ʒ�����,i.cInvStd as ����ͺ�,cFree1 as ��װ,cBatch as ����,convert(decimal(18, 3),b.iquantity) as ����,cu.cComUnitName ��λ
,cBatchProperty6 as ���ϱ�ʶ��ע,cBatchProperty7 as ��װ����,cBatchProperty9 as ��ҵָ����
,dis.cDCName as ����,c.cCusName as �ͻ�,a.dDate as ����,b.cInvCode as ���ϱ���,i.cInvName as Ʒ��
from RdRecord11 a inner join rdrecords11 b on a.ID = b.ID left join Inventory i on b.cInvCode=i.cInvCode left join Customer c on a.cCusCode=c.cCusCode
left join Person p on a.cPersonCode=p.cPersonCode left join Department d on a.cDepCode=d.cDepCode left join DistrictClass dis on c.cDCCode=dis.cDCCode
left join Warehouse w on a.cWhCode=w.cWhCode left join InventoryClass ic on i.cInvCCode=ic.cInvCCode left join ComputationUnit cu on i.cComUnitCode=cu.cComUnitCode
left join Rd_Style r on a.cRdCode=r.cRdCode
where 1=1 ";
                if (cInvCode != "")
                {
                    sSQL = sSQL.Replace("1=1", "1=1 and isnull(i.cInvCode,'')='" + cInvCode + "'");
                }
                if (sdate != "")
                {
                    sSQL = sSQL.Replace("1=1", "1=1 and convert(varchar(10),a.dDate,120)>='" + sdate + "'");
                }
                if (edate != "")
                {
                    sSQL = sSQL.Replace("1=1", "1=1 and convert(varchar(10),a.dDate,120)<='" + edate + "'");
                }
                if (cposname != "")
                {
                    sSQL = sSQL.Replace("1=1", "1=1 and cposname='" + cposname + "'");
                }
                if (cFree1 != "")
                {
                    sSQL = sSQL.Replace("1=1", "1=1 and b.cFree1='" + cFree1 + "'");
                }
                if (cFree3 != "")
                {
                    sSQL = sSQL.Replace("1=1", "1=1 and b.cFree3='" + cFree3 + "'");
                }
                if (cCode != "")
                {
                    sSQL = sSQL.Replace("1=1", "1=1 and a.cCode='" + cCode + "'");
                }
                if (Flag == 0)
                {
                    sSQL = sSQL.Replace("1=1", "1=1 and b.iquantity>0");
                    this.Text = "�ۼ�������ϸ";
                }
                else if (Flag == 1)
                {
                    sSQL = sSQL.Replace("1=1", "1=1 and b.iquantity<0");
                    this.Text = "�ۼ��˿���ϸ";
                }
                else
                {
                    this.Text = "���ϳ��ⵥ��ϸ";
                }
                sSQL = sSQL + " order by a.dDate";
                DataTable dt = SqlHelper.ExecuteDataset(Conn, CommandType.Text, sSQL).Tables[0];
                gridControl1.DataSource = dt;
                for (int i = 0; i < gridView1.Columns.Count; i++)
                {
                    if (gridView1.Columns[i].FieldName == "����" || gridView1.Columns[i].FieldName == "���")
                    {
                        gridView1.Columns[i].Summary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] { new DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum) });
                    }
                }
                gridView1.OptionsBehavior.Editable = false;
            }
            catch (Exception ee)
            {
                MessageBox.Show("��������ʧ��:" + ee.Message);
            }
        }

//        public void �ɹ����(string cInvCode, string sdate, string edate, string cposname, string cFree1, string cFree3, int Flag, string cCode)
//        {
//            try
//            {
                
//                string sSQL = @"select a.dDate as �������,w.cWhName as ��˾����,a.cDefine10 as �ɹ�Ա,a.cDefine8 as �빺Ա,v.cVenAbbName as ��Ӧ�̼��,a.cCode as ��ⵥ��
//,case when ISNULL(a.cHandler ,'')<>'' then '���' when isnull(a.iswfcontrolled,0)=1 and isnull(a.iverifystate ,0)=1 then '�����' when ISNULL(a.cMaker,'')<>'' then '����' end as ����״̬
//,r.crdname as ������,ic.cInvCName as �����Ʒ����,i.cInvName as Ʒ�����,i.cInvStd as ����ͺ�,cFree1 as ��װ,cBatch as ����,convert(decimal(18, 3),b.iquantity) as ����,cu.cComUnitName ��λ
//,a.cMemo as ��ⱸע,dis.cDCName as ����,b.irowno as �к�,b.cInvCode as ���ϱ���,i.cInvName as Ʒ�� 
//from RdRecord01 a inner join rdrecords01 b on a.ID = b.ID left join Inventory i on b.cInvCode=i.cInvCode left join Vendor v on a.cVenCode=v.cVenCode
//left join Person p on a.cPersonCode=p.cPersonCode left join Department d on a.cDepCode=d.cDepCode left join DistrictClass dis on v.cDCCode=dis.cDCCode
//left join Warehouse w on a.cWhCode=w.cWhCode left join InventoryClass ic on i.cInvCCode=ic.cInvCCode left join ComputationUnit cu on i.cComUnitCode=cu.cComUnitCode
//left join Rd_Style r on a.cRdCode=r.cRdCode
//where 1=1 ";
//                if (cInvCode != "")
//                {
//                    sSQL = sSQL.Replace("1=1", "1=1 and isnull(i.cInvCode,'')='" + cInvCode + "'");
//                }
//                if (sdate != "")
//                {
//                    sSQL = sSQL.Replace("1=1", "1=1 and convert(varchar(10),a.dDate,120)>='" + sdate + "'");
//                }
//                if (edate != "")
//                {
//                    sSQL = sSQL.Replace("1=1", "1=1 and convert(varchar(10),a.dDate,120)<='" + edate + "'");
//                }
//                if (cposname != "")
//                {
//                    sSQL = sSQL.Replace("1=1", "1=1 and cposname='" + cposname + "'");
//                }
//                if (cFree1 != "")
//                {
//                    sSQL = sSQL.Replace("1=1", "1=1 and b.cFree1='" + cFree1 + "'");
//                }
//                if (cFree3 != "")
//                {
//                    sSQL = sSQL.Replace("1=1", "1=1 and b.cFree3='" + cFree3 + "'");
//                }
//                if (cCode != "")
//                {
//                    sSQL = sSQL.Replace("1=1", "1=1 and a.cCode='" + cCode + "'");
//                }
//                if (Flag == 0)
//                {
//                    sSQL = sSQL.Replace("1=1", "1=1 and b.iquantity>0");
//                    this.Text = "�ɹ����������ϸ";
//                }
//                else if (Flag == 1)
//                {
//                    sSQL = sSQL.Replace("1=1", "1=1 and b.iquantity<0");
//                    this.Text = "�˻�������ϸ";
//                }
//                else
//                {
//                    this.Text = "�ɹ���ⵥ��ϸ";
//                }
//                sSQL = sSQL + " order by a.dDate";
//                DataTable dt = SqlHelper.ExecuteDataset(Conn, CommandType.Text, sSQL).Tables[0];
//                gridControl1.DataSource = dt;
//                for (int i = 0; i < gridView1.Columns.Count; i++)
//                {
//                    if (gridView1.Columns[i].FieldName == "����" || gridView1.Columns[i].FieldName == "���")
//                    {
//                        gridView1.Columns[i].Summary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] { new DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum) });
//                    }
//                }
//                if (cFree1 != "")
//                {
//                    sSQL = sSQL.Replace("1=1", "1=1 and b.cFree1='" + cFree1 + "'");
//                }
//                gridView1.OptionsBehavior.Editable = false;
//            }
//            catch (Exception ee)
//            {
//                MessageBox.Show("��������ʧ��:" + ee.Message);
//            }
//        }

//        public void �ۼ�����(string cInvCode, string sdate, string edate, string cposname, string cFree1, string cFree3,int Flag,string cCode)
//        {
//            try
//            {
                
//                string sSQL = @"select a.dDate as ��������,w.cWhName as ��˾����,p.cPersonName as ҵ��Ա,c.cCusName as �ͻ�,a.cCode as ����
//,case when ISNULL(a.cHandler ,'')<>'' then '���' when isnull(a.iswfcontrolled,0)=1 and isnull(a.iverifystate ,0)=1 then '�����' when ISNULL(a.cMaker,'')<>'' then '����' end as ����״̬
//,ic.cInvCName as �����Ʒ����,i.cInvName as Ʒ�����,i.cInvStd as ����ͺ�,cFree1 as ��װ,cBatch as ����,convert(decimal(18, 3),b.iquantity) as ����,cu.cComUnitName ��λ
//,cBatchProperty6 as ���ϱ�ʶ��ע,cBatchProperty7 as ��װ����,cBatchProperty9 as ��ҵָ����
//,d.cDepName as ����,dis.cDCName as ����,b.irowno as �к�,b.cInvCode as ���ϱ���,i.cInvName as Ʒ�� --,convert(decimal(18, 2),b.iPrice) as ��� 
//from RdRecord32 a inner join rdrecords32 b on a.ID = b.ID left join Inventory i on b.cInvCode=i.cInvCode left join Customer c on a.cCusCode=c.cCusCode
//left join Person p on a.cPersonCode=p.cPersonCode left join Department d on a.cDepCode=d.cDepCode left join DistrictClass dis on c.cDCCode=dis.cDCCode
//left join Warehouse w on a.cWhCode=w.cWhCode left join InventoryClass ic on i.cInvCCode=ic.cInvCCode left join ComputationUnit cu on i.cComUnitCode=cu.cComUnitCode
//where 1=1 ";
//                if (cInvCode != "")
//                {
//                    sSQL = sSQL.Replace("1=1", "1=1 and isnull(i.cInvCode,'')='" + cInvCode + "'");
//                }
//                if (sdate != "")
//                {
//                    sSQL = sSQL.Replace("1=1", "1=1 and convert(varchar(10),a.dDate,120)>='" + sdate + "'");
//                }
//                if (edate != "")
//                {
//                    sSQL = sSQL.Replace("1=1", "1=1 and convert(varchar(10),a.dDate,120)<='" + edate + "'");
//                }
//                if (cposname != "")
//                {
//                    sSQL = sSQL.Replace("1=1", "1=1 and cposname='" + cposname + "'");
//                }
//                if (cFree1 != "")
//                {
//                    sSQL = sSQL.Replace("1=1", "1=1 and b.cFree1='" + cFree1 + "'");
//                }
//                if (cFree3 != "")
//                {
//                    sSQL = sSQL.Replace("1=1", "1=1 and b.cFree3='" + cFree3 + "'");
//                }
//                if (cCode != "")
//                {
//                    sSQL = sSQL.Replace("1=1", "1=1 and a.cCode='" + cCode + "'");
//                }
//                if (Flag == 0)
//                {
//                    sSQL = sSQL.Replace("1=1", "1=1 and b.iquantity>0");
//                    this.Text = "�ۼ�������ϸ";
//                }
//                else if (Flag == 1)
//                {
//                    sSQL = sSQL.Replace("1=1", "1=1 and b.iquantity<0");
//                    this.Text = "�ۼ��˻���ϸ";
//                }
//                else
//                {
//                    this.Text = "������ϸ";
//                }
//                sSQL = sSQL + " order by a.dDate";
//                DataTable dt = SqlHelper.ExecuteDataset(Conn, CommandType.Text, sSQL).Tables[0];
//                gridControl1.DataSource = dt;
//                for (int i = 0; i < gridView1.Columns.Count; i++)
//                {
//                    if (gridView1.Columns[i].FieldName == "����" || gridView1.Columns[i].FieldName == "���")
//                    {
//                        gridView1.Columns[i].Summary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] { new DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum) });
//                    }
//                }
//                gridView1.OptionsBehavior.Editable = false;
//            }
//            catch (Exception ee)
//            {
//                MessageBox.Show("��������ʧ��:" + ee.Message);
//            }
//        }

        public void ����ⵥ��ϸ(string cInvCode1, string cInvCode2, string sdate, string edate, string cposname
            , string cFree1, string cFree3 ,int QuantityFlag, string cCode,string Flag)
        {
            try
            {
                string sSQL = "";
                if (Flag == "01")
                {
                    #region SQL
                    sSQL = @"select a.dDate as �������,w.cWhName as ��˾����,a.cDefine10 as �ɹ�Ա,a.cDefine8 as �빺Ա,v.cVenAbbName as ��Ӧ�̼��,a.cCode as ��ⵥ��
,case when ISNULL(a.cHandler ,'')<>'' then '���' when isnull(a.iswfcontrolled,0)=1 and isnull(a.iverifystate ,0)=1 then '�����' when ISNULL(a.cMaker,'')<>'' then '����' end as ����״̬
,r.crdname as ������,ic.cInvCName as �����Ʒ����,i.cInvName as Ʒ�����,i.cInvStd as ����ͺ�,cFree1 as ��װ,cBatch as ����,convert(decimal(18, 3),b.iquantity) as ����,cu.cComUnitName ��λ
,a.cMemo as ��ⱸע,dis.cDCName as ����,b.irowno as �к�,b.cInvCode as ���ϱ���,i.cInvName as Ʒ�� 
from RdRecord01 a inner join rdrecords01 b on a.ID = b.ID left join Inventory i on b.cInvCode=i.cInvCode left join Vendor v on a.cVenCode=v.cVenCode
left join Person p on a.cPersonCode=p.cPersonCode left join Department d on a.cDepCode=d.cDepCode left join DistrictClass dis on v.cDCCode=dis.cDCCode
left join Warehouse w on a.cWhCode=w.cWhCode left join InventoryClass ic on i.cInvCCode=ic.cInvCCode left join ComputationUnit cu on i.cComUnitCode=cu.cComUnitCode
left join Rd_Style r on a.cRdCode=r.cRdCode
where 1=1 ";
                    #endregion
                    #region ����
                    if (QuantityFlag == 0)
                    {
                        this.Text = "�ɹ����������ϸ";
                    }
                    else if (QuantityFlag == 1)
                    {
                        this.Text = "�˻�������ϸ";
                    }
                    else
                    {
                        this.Text = "�ɹ���ⵥ��ϸ";
                    }
                    #endregion
                }
                else if (Flag == "08")
                {
                    #region SQL
                    sSQL = @"select a.dDate as �������, w.cWhName as ��˾����,ic.cInvCName as �����Ʒ����,i.cInvName as Ʒ�����,i.cInvStd as ����ͺ�,cFree1 as ��װ,r.crdname as �������,a.cCode as ��ⵥ��
,case when ISNULL(a.cHandler ,'')<>'' then '���' when isnull(a.iswfcontrolled,0)=1 and isnull(a.iverifystate ,0)=1 then '�����' when ISNULL(a.cMaker,'')<>'' then '����' end as ����״̬
,r.crdname as �������,cBatch as ����,convert(decimal(18, 3),b.iquantity) as ����,cu.cComUnitName ��λ
,cBatchProperty6 as ���ϱ�ʶ��ע,cBatchProperty7 as ��װ����,cBatchProperty9 as ��ҵָ����
,a.dDate as ����,b.cInvCode as ���ϱ���,i.cInvName as Ʒ��
from RdRecord08 a inner join rdrecords08 b on a.ID = b.ID left join Inventory i on b.cInvCode=i.cInvCode 
left join Person p on a.cPersonCode=p.cPersonCode left join Department d on a.cDepCode=d.cDepCode 
left join Warehouse w on a.cWhCode=w.cWhCode left join InventoryClass ic on i.cInvCCode=ic.cInvCCode left join ComputationUnit cu on i.cComUnitCode=cu.cComUnitCode
left join Rd_Style r on a.cRdCode=r.cRdCode
where 1=1 ";
                    #endregion
                    #region ����
                    this.Text = "������ⵥ��ϸ";
                    #endregion
                }
                else if (Flag == "09")
                {
                    #region SQL
                    sSQL = @"select a.dDate as �������, w.cWhName as ��˾����,ic.cInvCName as �����Ʒ����,i.cInvName as Ʒ�����,i.cInvStd as ����ͺ�,cFree1 as ��װ,r.crdname as �������,a.cCode as ��ⵥ��
,case when ISNULL(a.cHandler ,'')<>'' then '���' when isnull(a.iswfcontrolled,0)=1 and isnull(a.iverifystate ,0)=1 then '�����' when ISNULL(a.cMaker,'')<>'' then '����' end as ����״̬
,r.crdname as �������,cBatch as ����,convert(decimal(18, 3),b.iquantity) as ����,cu.cComUnitName ��λ
,cBatchProperty6 as ���ϱ�ʶ��ע,cBatchProperty7 as ��װ����,cBatchProperty9 as ��ҵָ����
,a.dDate as ����,b.cInvCode as ���ϱ���,i.cInvName as Ʒ��
from RdRecord09 a inner join rdrecords09 b on a.ID = b.ID left join Inventory i on b.cInvCode=i.cInvCode 
left join Person p on a.cPersonCode=p.cPersonCode left join Department d on a.cDepCode=d.cDepCode 
left join Warehouse w on a.cWhCode=w.cWhCode left join InventoryClass ic on i.cInvCCode=ic.cInvCCode left join ComputationUnit cu on i.cComUnitCode=cu.cComUnitCode
left join Rd_Style r on a.cRdCode=r.cRdCode
where 1=1 ";
                    #endregion
                    #region ����
                    this.Text = "�������ⵥ��ϸ";
                    #endregion
                }
                else if (Flag == "10")
                {
                    #region SQL
                    sSQL = @"select a.dDate as �������, w.cWhName as ��˾����,ic.cInvCName as �����Ʒ����,i.cInvName as Ʒ�����,i.cInvStd as ����ͺ�,cFree1 as ��װ,r.crdname as �������,a.cCode as ��ⵥ��
,case when ISNULL(a.cHandler ,'')<>'' then '���' when isnull(a.iswfcontrolled,0)=1 and isnull(a.iverifystate ,0)=1 then '�����' when ISNULL(a.cMaker,'')<>'' then '����' end as ����״̬
,r.crdname as �������,cBatch as ����,convert(decimal(18, 3),b.iquantity) as ����,cu.cComUnitName ��λ
,cBatchProperty6 as ���ϱ�ʶ��ע,cBatchProperty7 as ��װ����,cBatchProperty9 as ��ҵָ����
,dis.cDCName as ����,v.cVenName as �ͻ�,a.dDate as ����,b.cInvCode as ���ϱ���,i.cInvName as Ʒ��
from RdRecord10 a inner join rdrecords10 b on a.ID = b.ID left join Inventory i on b.cInvCode=i.cInvCode left join Vendor v on a.cVenCode=v.cVenCode
left join Person p on a.cPersonCode=p.cPersonCode left join Department d on a.cDepCode=d.cDepCode left join DistrictClass dis on v.cDCCode=dis.cDCCode
left join Warehouse w on a.cWhCode=w.cWhCode left join InventoryClass ic on i.cInvCCode=ic.cInvCCode left join ComputationUnit cu on i.cComUnitCode=cu.cComUnitCode
left join Rd_Style r on a.cRdCode=r.cRdCode
where 1=1 ";
                    #endregion
                    #region ����
                    if (QuantityFlag == 0)
                    {
                        this.Text = "�ۼ������ϸ";
                    }
                    else if (QuantityFlag == 1)
                    {
                        this.Text = "�ۼ��˿���ϸ";
                    }
                    else
                    {
                        this.Text = "����Ʒ��ⵥ��ϸ";
                    }
                    #endregion
                }
                else if (Flag == "11")
                {
                    #region SQL
                    sSQL = @"select w.cWhName as ��˾����,d.cDepName as ���ϲ���,a.cDefine3 as ��������,p.cPersonName as ������Ա,a.cCode as ���ⵥ��
,case when ISNULL(a.cHandler ,'')<>'' then '���' when isnull(a.iswfcontrolled,0)=1 and isnull(a.iverifystate ,0)=1 then '�����' when ISNULL(a.cMaker,'')<>'' then '����' end as ����״̬
,r.crdname as �������,ic.cInvCName as �����Ʒ����,i.cInvName as Ʒ�����,i.cInvStd as ����ͺ�,cFree1 as ��װ,cBatch as ����,convert(decimal(18, 3),b.iquantity) as ����,cu.cComUnitName ��λ
,cBatchProperty6 as ���ϱ�ʶ��ע,cBatchProperty7 as ��װ����,cBatchProperty9 as ��ҵָ����
,dis.cDCName as ����,c.cCusName as �ͻ�,a.dDate as ����,b.cInvCode as ���ϱ���,i.cInvName as Ʒ��
from RdRecord11 a inner join rdrecords11 b on a.ID = b.ID left join Inventory i on b.cInvCode=i.cInvCode left join Customer c on a.cCusCode=c.cCusCode
left join Person p on a.cPersonCode=p.cPersonCode left join Department d on a.cDepCode=d.cDepCode left join DistrictClass dis on c.cDCCode=dis.cDCCode
left join Warehouse w on a.cWhCode=w.cWhCode left join InventoryClass ic on i.cInvCCode=ic.cInvCCode left join ComputationUnit cu on i.cComUnitCode=cu.cComUnitCode
left join Rd_Style r on a.cRdCode=r.cRdCode
where 1=1 ";
                    #endregion
                    #region ����
                    if (QuantityFlag == 0)
                    {
                        this.Text = "�ۼ�������ϸ";
                    }
                    else if (QuantityFlag == 1)
                    {
                        this.Text = "�ۼ��˿���ϸ";
                    }
                    else
                    {
                        this.Text = "���ϳ��ⵥ��ϸ";
                    }
                    #endregion
                }
                else if (Flag == "32")
                {
                    #region SQL
                    sSQL = @"select a.dDate as ��������,w.cWhName as ��˾����,p.cPersonName as ҵ��Ա,c.cCusName as �ͻ�,a.cCode as ����
,case when ISNULL(a.cHandler ,'')<>'' then '���' when isnull(a.iswfcontrolled,0)=1 and isnull(a.iverifystate ,0)=1 then '�����' when ISNULL(a.cMaker,'')<>'' then '����' end as ����״̬
,ic.cInvCName as �����Ʒ����,i.cInvName as Ʒ�����,i.cInvStd as ����ͺ�,cFree1 as ��װ,cBatch as ����,convert(decimal(18, 3),b.iquantity) as ����,cu.cComUnitName ��λ
,cBatchProperty6 as ���ϱ�ʶ��ע,cBatchProperty7 as ��װ����,cBatchProperty9 as ��ҵָ����
,d.cDepName as ����,dis.cDCName as ����,b.irowno as �к�,b.cInvCode as ���ϱ���,i.cInvName as Ʒ�� --,convert(decimal(18, 2),b.iPrice) as ��� 
from RdRecord32 a inner join rdrecords32 b on a.ID = b.ID left join Inventory i on b.cInvCode=i.cInvCode left join Customer c on a.cCusCode=c.cCusCode
left join Person p on a.cPersonCode=p.cPersonCode left join Department d on a.cDepCode=d.cDepCode left join DistrictClass dis on c.cDCCode=dis.cDCCode
left join Warehouse w on a.cWhCode=w.cWhCode left join InventoryClass ic on i.cInvCCode=ic.cInvCCode left join ComputationUnit cu on i.cComUnitCode=cu.cComUnitCode
where 1=1 ";
                    #endregion
                    #region ����
                    if (QuantityFlag == 0)
                    {
                        this.Text = "�ۼ�������ϸ";
                    }
                    else if (QuantityFlag == 1)
                    {
                        this.Text = "�ۼ��˻���ϸ";
                    }
                    else
                    {
                        this.Text = "���۳��ⵥ��ϸ";
                    }
                    #endregion
                }
                if (cInvCode1 != "")
                {
                    sSQL = sSQL.Replace("1=1", "1=1 and isnull(i.cInvCode,'')>='" + cInvCode1 + "'");
                }
                if (cInvCode2 != "")
                {
                    sSQL = sSQL.Replace("1=1", "1=1 and isnull(i.cInvCode,'')<='" + cInvCode2 + "'");
                }
                if (sdate != "")
                {
                    sSQL = sSQL.Replace("1=1", "1=1 and convert(varchar(10),a.dDate,120)>='" + sdate + "'");
                }
                if (edate != "")
                {
                    sSQL = sSQL.Replace("1=1", "1=1 and convert(varchar(10),a.dDate,120)<='" + edate + "'");
                }
                if (cposname != "")
                {
                    sSQL = sSQL.Replace("1=1", "1=1 and cposname='" + cposname + "'");
                }
                if (cFree1 != "")
                {
                    sSQL = sSQL.Replace("1=1", "1=1 and b.cFree1='" + cFree1 + "'");
                }
                if (cFree3 != "")
                {
                    sSQL = sSQL.Replace("1=1", "1=1 and b.cFree3='" + cFree3 + "'");
                }
                if (cCode != "")
                {
                    sSQL = sSQL.Replace("1=1", "1=1 and a.cCode='" + cCode + "'");
                }
                if (QuantityFlag == 0)
                {
                    sSQL = sSQL.Replace("1=1", "1=1 and b.iquantity>0");
                }
                else if (QuantityFlag == 1)
                {
                    sSQL = sSQL.Replace("1=1", "1=1 and b.iquantity<0");
                }
                sSQL = sSQL + " order by a.dDate";
                DataTable dt = SqlHelper.ExecuteDataset(Conn, CommandType.Text, sSQL).Tables[0];
                gridControl1.DataSource = dt;
                for (int i = 0; i < gridView1.Columns.Count; i++)
                {
                    if (gridView1.Columns[i].FieldName == "����" || gridView1.Columns[i].FieldName == "���")
                    {
                        gridView1.Columns[i].Summary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] { new DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum) });
                    }
                }
                if (cFree1 != "")
                {
                    sSQL = sSQL.Replace("1=1", "1=1 and b.cFree1='" + cFree1 + "'");
                }
                gridView1.OptionsBehavior.Editable = false;
            }
            catch (Exception ee)
            {
                MessageBox.Show("��������ʧ��:" + ee.Message);
            }
        }

        public void �շ�����ܱ��ڵ����������(string cinvcode, string sdate, string edate, bool bcHandler, bool bcHas, string cFree3, string cFree4, string cWhCode, string cPosCode)
        {
            try
            {
                icinvcode = cinvcode;
                isdate = sdate;
                iedate = edate;
                ibcHandler = bcHandler;
                ibcHas = bcHas;
                icFree3 = cFree3;
                icFree4 = cFree4;
                icWhCode = cWhCode;
                icPosCode = cPosCode;
                New("cInvName", "Ʒ��");
                New("cInvStd", "�ͺ�");
                //New("cInvName", "����");
                New("cRdName", "�շ����");
                New("������λ", "������λ");
                New("�ڳ�����", "�ڳ�����");
                New("�ܼ��������", "�������");
                New("�ܼƳ�������", "��������");
                New("��ĩ����", "��ĩ����");
                New("cVouchName", "��������");
                //New("cInvName", "���ݱ�ע");
                //New("cInvName", "��Ӧ�̼��");
                //New("cInvName", "�ɹ�Ա");
                //New("cInvName", "�ͻ����");
                //New("cInvName", "����ҵ��Ա");
                //New("cInvName", "����");
                New("cDefine3", "����");
                //New("cInvName", "Ŀ���Ʒ");

                this.Text = "�շ�����ܱ��ڵ����������";
                ����Դ sfc = new ����Դ();
                DataTable dt = sfc.�շ������(Conn, cinvcode, cinvcode, sdate, edate, 3, bcHandler, bcHas, cFree3, cFree4, cWhCode, cPosCode, "", "");
                gridControl1.DataSource = dt;
                for (int i = 0; i < gridView1.Columns.Count; i++)
                {
                    if (gridView1.Columns[i].FieldName == "�ܼ��������" || gridView1.Columns[i].FieldName == "�ܼƳ�������"
                        || gridView1.Columns[i].FieldName == "�ڳ�����" || gridView1.Columns[i].FieldName == "��ĩ����")
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

        public void �շ�����ܱ��ڵ���������ϸ(string cinvcode, string sdate, string edate, bool bcHandler, bool bcHas, string cFree3, string cFree4, string cWhCode, string cPosCode, string cRdCode,string RdFlag)
        {
            try
            {
                New("cInvName", "Ʒ��");
                New("cInvStd", "�ͺ�");
                //New("cInvName", "����");
                New("cRdName", "�շ����");
                New("cCode", "���ݺ�");
                New("������λ", "������λ");
                //New("�ڳ�����", "�ڳ�����");
                New("�ܼ��������", "�������");
                New("�ܼƳ�������", "��������");
                //New("��ĩ����", "��ĩ����");
                New("cVouchName", "��������");
                //New("cInvName", "���ݱ�ע");
                //New("cInvName", "��Ӧ�̼��");
                //New("cInvName", "�ɹ�Ա");
                //New("cInvName", "�ͻ����");
                //New("cInvName", "����ҵ��Ա");
                //New("cInvName", "����");
                New("cDefine3", "����");
                //New("cInvName", "Ŀ���Ʒ");

                this.Text = "�շ�����ܱ��ڵ���������ϸ";
                ����Դ sfc = new ����Դ();
                DataTable dt = sfc.�շ������(Conn, cinvcode, cinvcode, sdate, edate, 2, bcHandler, bcHas, cFree3, cFree4, cWhCode, cPosCode, cRdCode, RdFlag);
                gridControl1.DataSource = dt;
                for (int i = 0; i < gridView1.Columns.Count; i++)
                {
                    if (gridView1.Columns[i].FieldName == "�ܼ��������" || gridView1.Columns[i].FieldName == "�ܼƳ�������"
                        || gridView1.Columns[i].FieldName == "�ڳ�����" || gridView1.Columns[i].FieldName == "��ĩ����")
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

        public void �շ�����ܲɹ�������;(string cInvCode, string sdate, string edate, bool bcHandler)
        {
            try
            {
                this.Text = "�շ�����ܲɹ�������;";
                string sSQL = @"select a.dDate as ��������,a.cDefine10 as �ɹ�Ա,a.cDefine8 as �빺Ա,v.cCusAbbName as �ͻ����,a.cSOCode as ������
,case when ISNULL(a.cVerifier ,'')<>'' then '���' when isnull(a.iswfcontrolled,0)=1 and isnull(a.iverifystate ,0)=1 then '�����' when ISNULL(a.cMaker,'')<>'' then '����' end as ����״̬
,ic.cInvCName as �����Ʒ����,i.cInvName as Ʒ�����,i.cInvStd as ����ͺ�,cFree1 as ��װ,convert(decimal(18, 3),b.iquantity) as ����,convert(decimal(18, 3),isnull(iQuantity,0)-isnull(finquantity ,0)) as ��;����,cu.cComUnitName ��λ
,a.cMemo as ��ⱸע,dis.cDCName as ����,b.irowno as �к�,b.cInvCode as ���ϱ���,i.cInvName as Ʒ��  
from SO_SOMain a left join SO_SODetails b on a.ID=b.ID
left join Inventory i on b.cInvCode=i.cInvCode left join Customer v on a.cCusCode =v.cCusCode
left join Person p on a.cPersonCode=p.cPersonCode left join Department d on a.cDepCode=d.cDepCode left join DistrictClass dis on v.cDCCode=dis.cDCCode
left join InventoryClass ic on i.cInvCCode=ic.cInvCCode left join ComputationUnit cu on i.cComUnitCode=cu.cComUnitCode
where isnull(iQuantity,0)-isnull(finquantity ,0)>0 and 1=1 ";
                if (cInvCode != "")
                {
                    sSQL = sSQL.Replace("1=1", "1=1 and isnull(i.cInvCode,'')='" + cInvCode + "'");
                }
                //if (sdate != "")
                //{
                //    sSQL = sSQL.Replace("1=1", "1=1 and convert(varchar(10),a.dDate,120)>='" + sdate + "'");
                //}
                //if (edate != "")
                //{
                //    sSQL = sSQL.Replace("1=1", "1=1 and convert(varchar(10),a.dDate,120)<='" + edate + "'");
                //}
                if (bcHandler == true)
                {
                    sSQL = sSQL.Replace("1=1", "1=1 and isnull(cVerifier ,'')<>''");
                }
                else
                {
                    sSQL = sSQL.Replace("1=1", "1=1 and isnull(cVerifier ,'')=''");
                }
                sSQL = sSQL + " order by a.dDate";
                DataTable dt = SqlHelper.ExecuteDataset(Conn, CommandType.Text, sSQL).Tables[0];
                gridControl1.DataSource = dt;
                for (int i = 0; i < gridView1.Columns.Count; i++)
                {
                    if (gridView1.Columns[i].FieldName == "����" || gridView1.Columns[i].FieldName == "��˰���")
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

        private void New(string FieldName, string Caption)
        {
            GridColumn Col = new GridColumn();
            Col.FieldName = FieldName;
            Col.Caption = Caption;
            Col.Visible = true;
            Col.VisibleIndex = gridView1.Columns.Count;
            gridView1.Columns.Add(Col);
        }

        
        private void Frm��ϸ_Load(object sender, EventArgs e)
        {
            try
            {
                ϵͳ����.���.GetGridViewSet(gridView1);
            }
            catch (Exception ee)
            {
                MessageBox.Show("������۳��ⵥ��ϸ��Ϣʧ�ܣ�  " + ee.Message);
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void gridView1_DoubleClick(object sender, EventArgs e)
        {
            if (this.Text == "�շ�����ܱ��ڵ����������")
            {
                try
                {
                    string Caption = gridView1.FocusedColumn.FieldName;
                    int iRow = gridView1.FocusedRowHandle;
                    if (iRow < 0)
                        return;
                    string cRdCode = gridView1.GetRowCellValue(iRow, "cRdCode").ToString();
                    Frm��ϸ frm = new Frm��ϸ(Conn);
                    frm.�շ�����ܱ��ڵ���������ϸ(icinvcode, isdate, iedate, ibcHandler, ibcHas, icFree3, icFree4, icWhCode, icPosCode, cRdCode,"");
                    frm.Show();
                    if (DialogResult.OK == frm.ShowDialog())
                    {
                        frm.Enabled = true;
                    }
                }
                catch (Exception ee)
                { }
            }
        }
    }
}