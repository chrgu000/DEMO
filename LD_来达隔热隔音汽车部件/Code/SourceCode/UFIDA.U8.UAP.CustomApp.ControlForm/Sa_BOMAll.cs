using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using UFIDA.U8.UAP.CustomApp.ControlForm.Business;
using DevExpress.XtraEditors;
using System.Xml;
using DevExpress.XtraTreeList.Nodes;


namespace UFIDA.U8.UAP.CustomApp.ControlForm
{
    public partial class Sa_BOMAll : UserControl
    {

        public DateTime dSerToday { get; set; }

        public string Conn { get; set; }

        public string sUserID { get; set; }

        public string sUserName { get; set; }

        public string sLogDate { get; set; }

        public string sAccID { get; set; }

        public Sa_BOMAll()
        {
            InitializeComponent();
        }


        private void ProjectManager_Load(object sender, EventArgs e)
        {
            try
            {
                DataTable dtmonth = new DataTable();
                dtmonth.Columns.Add("cValue");
                for (int i = 1; i <= 12; i++)
                {
                    DataRow dw = dtmonth.NewRow();
                    dw[0] = i.ToString();
                    dtmonth.Rows.Add(dw);
                }
                lookUpEditMonth.Properties.DataSource = dtmonth;

                txt��.EditValue = DateTime.Now.Year;

                lookUpEditMonth.EditValue = DateTime.Now.AddMonths(-1).Month.ToString();

                if (lookUpEditMonth.EditValue.ToString() == "12")
                {
                    txt��.EditValue = DateTime.Now.Year - 1;
                }

                GetGrid();
            }
            catch (Exception ee)
            {
                MessageBox.Show("��������ʧ��");
            }
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            GetGrid();
        }

        DataTable dtcg;
        DataTable dtc;
        DataTable dtt;
        DataTable dtsfc;
        DataTable dtso;
        DataTable dtinv;
        DataTable dtcb;
        string sd;
        string ed;

        private void GetGrid()
        {
            try
            {
                
                treeList1.Nodes.Clear();

                if (txt��.Text.Trim() == "")
                {
                    throw new Exception("��Ȳ���Ϊ��");
                }
                if (lookUpEditMonth.EditValue.ToString() == "")
                {
                    throw new Exception("�·ݲ���Ϊ��");
                }

                sd = txt��.EditValue.ToString() + "-" + lookUpEditMonth.EditValue.ToString()+"-01";
                ed = DateTime.Parse(sd).AddMonths(1).AddDays(-1).ToString("yyyy-MM-dd");
                

                dtcg = GetCusInvContraposeGroup();
                dtc = GetCusInvContrapose();
                dtt = GetTree();
                dtso = GetSo();
                dtinv = GetInv();
                dtcb = GetCb();
                dtsfc = GetSfchz();
                //�ҳ��ͻ�������ձ��е����д��
                for (int i = 0; i < dtcg.Rows.Count; i++)
                {
                    string tl = dtcg.Rows[i]["cInvCode"].ToString();
                    //DataRow[] dw = dtso.Select("cInvCode='" + tl + "'");
                    //if (dw.Length > 0)
                    //{
                        //�ҳ������Ӧ�Ŀͻ������Ϊ����������
                        //DataRow[] dwc = dtc.Select("cInvCode='" + tl + "'");
                        //if (dwc.Length == 1)
                        //{
                            AddNode(tl);
                        //}
                    //}
                }

                treeList1.ExpandAll();
            }
            catch (Exception ee)
            {
                MessageBox.Show(ee.Message);
            }
        }

        private void AddNode(string tl)
        {
            int isOpen = 0;
            object[] obj = AddNodeObj(0, tl, 0, 0, 0,out isOpen);
            TreeListNode node = treeList1.AppendNode(obj, -1);
            //����޸ĺ�Ŀ����С��0��չ��һ��
            if (isOpen == 1)
            {
                DataRow[] dwr = dtt.Select("ĸ������='" + tl + "' and �Ӽ���������='���Ƽ�' ");
                for (int i = 0; i < dwr.Length; i++)
                {
                    string tlzj = dwr[i]["�Ӽ�����"].ToString();
                    decimal d��Ʒ��� = ���.ReturnDecimal(obj[9], 6);
                    decimal d��Ʒ�ɱ���� = ���.ReturnDecimal(obj[13], 6);
                    decimal d���Ʒ���� = ���.ReturnDecimal(obj[6], 6) - ���.ReturnDecimal(obj[7], 6);
                    int isOpen2 = 0;
                    TreeListNode node1 = treeList1.AppendNode(AddNodeObj(1, tlzj, d��Ʒ���, d��Ʒ�ɱ����, d���Ʒ����, out isOpen2), node);
                }
            }
        }

        private object[] AddNodeObj(int flag, string tl, decimal d��Ʒ���, decimal d��Ʒ�ɱ����, decimal d���Ʒ����, out int isOpen)
        {
            isOpen = 0;
            DataRow[] dwc = dtc.Select("cInvCode='" + tl + "'");
            string cCusInvCode = "";
            string cCusName = "";
            string s�Ƿ�ͻ����� = "";
            if (dwc.Length > 0)
            {
                cCusInvCode = dwc[0]["cCusInvCode"].ToString();
                cCusName = dwc[0]["cCusName"].ToString();
                s�Ƿ�ͻ����� = dwc[0]["cCusDefine2"].ToString();
            }
            //���
            DataRow[] dwf = dtsfc.Select("���ϱ���='" + tl + "' and �շ���='���'");
            decimal d�µ׽������ = 0;
            decimal d�µ׽���� = 0;

            decimal dʵ�ʲ��ϵ��� = 0;
            decimal dʵ���˹����� = 0;
            decimal dʵ�ʹ̶����쵥�� = 0;
            decimal dʵ�ʱ䶯���쵥�� = 0;
            if (dwf.Length > 0)
            {
                d�µ׽������ = ���.ReturnDecimal(dwf[0]["����"], 2);
                d�µ׽���� = ���.ReturnDecimal(dwf[0]["�����"], 2);
                if (d�µ׽������ < 0)
                {
                    d�µ׽������ = 0;
                    d�µ׽���� = 0;
                }

                dʵ�ʲ��ϵ��� = ���.ReturnDecimal(dwf[0]["ʵ�ʲ��ϵ���"], 2);
                dʵ���˹����� = ���.ReturnDecimal(dwf[0]["ʵ���˹�����"], 2);
                dʵ�ʹ̶����쵥�� = ���.ReturnDecimal(dwf[0]["ʵ�ʹ̶����쵥��"], 2);
                dʵ�ʱ䶯���쵥�� = ���.ReturnDecimal(dwf[0]["ʵ�ʱ䶯���쵥��"], 2);
            }
            //14������
            decimal d14������ = ���.ReturnDecimal(dtso.Compute("sum(iQuantity)", "cInvCode='" + tl + "'"), 2);
            //�����Ϳ��Ƚϣ�ȡ��Сֵ��
            decimal dȷ������ = d�µ׽������;
            if (d�µ׽������ > d14������)
            {
                dȷ������ = d14������;
            }
            if (flag == 1)
            {
                d14������ = d���Ʒ����;
            }
            //���۵���
            decimal d���۵��� = 0;
            if (d��Ʒ��� == 0)
            {
                DataRow[] dwso = dtso.Select("cInvCode='" + tl + "'", "ddate desc");
                if (dwso.Length > 0)
                {
                    d���۵��� = ���.ReturnDecimal(dwso[0]["iTaxUnitPrice"], 2);
                }
            }
            else
            {
                DataRow[] dwcbs = dtcb.Select("cInvCode='" + tl + "'");
                if (dwcbs.Length > 0)
                {
                    d���۵��� = d��Ʒ��� * (d��Ʒ�ɱ���� / ���.ReturnDecimal(dwcbs[0]["iInvRCost"], 4));
                }
            }
            decimal d��� = d���۵��� * dȷ������;
            //�Ƿ�ͻ�����
            decimal dȷ������ = 0;
            if (s�Ƿ�ͻ����� == "��")
            {
                dȷ������ = d���;
            }
            //��׼�ɱ�
            decimal d��׼�ɱ����� = 0;
            DataRow[] dwcb = dtcb.Select("cInvCode='" + tl + "'");
            if (dwcb.Length > 0)
            {
                d��׼�ɱ����� = ���.ReturnDecimal(dwcb[0]["iInvRCost"], 4);
            }
            DataRow[] dwinv = dtinv.Select("cInvCode='" + tl + "'");
            decimal d��׼�ɱ���� = 0;
            string s�Ƿ��ô�� = "";
            if (dwinv.Length > 0)
            {

                d��׼�ɱ���� = d��׼�ɱ����� * dȷ������;

                s�Ƿ��ô�� = dwinv[0]["cInvDefine9"].ToString();

            }

            decimal dʵ�ʲ��Ͻ�� = 0;
            decimal dʵ���˹���� = 0;
            decimal dʵ�ʹ̶������� = 0;
            decimal dʵ�ʱ䶯������ = 0;

            dʵ�ʲ��Ͻ�� = dʵ�ʲ��ϵ��� * dȷ������;
            dʵ���˹���� = dʵ���˹����� * dȷ������;
            dʵ�ʹ̶������� = dʵ�ʹ̶����쵥�� * dȷ������;
            dʵ�ʱ䶯������ = dʵ�ʱ䶯���쵥�� * dȷ������;

            //�޸ĺ�Ŀ����
            decimal d�޸ĺ�Ŀ���� = d�µ׽���� - d��׼�ɱ����;
            if (d�޸ĺ�Ŀ���� < 0)
            {
                d�޸ĺ�Ŀ���� = 0;
                isOpen = 1;
            }

            return new object[] { tl, cCusInvCode, cCusName,d�µ׽������ ,d�µ׽���� ,s�Ƿ��ô��
                ,d14������, dȷ������, d���۵���, d���, s�Ƿ�ͻ�����,dȷ������
                ,dʵ�ʲ��ϵ���,dʵ���˹�����,dʵ�ʹ̶����쵥��,dʵ�ʱ䶯���쵥��
                ,dʵ�ʲ��Ͻ��,dʵ���˹����,dʵ�ʹ̶�������,dʵ�ʱ䶯������
                ,d��׼�ɱ�����,d��׼�ɱ����,d�޸ĺ�Ŀ���� };

        }
        //private void AddNode(TreeListNode node, string tl)
        //{
        //    DataRow[] dwr = dtt.Select("ĸ������='" + tl + "'");
        //    for (int i = 0; i < dwr.Length; i++)
        //    {
        //        string tl1 = dwr[i]["�Ӽ�����"].ToString();
        //        TreeListNode node1 = treeList1.AppendNode(new object[] { tl1 }, node);

        //        AddNode(node1, tl1);
        //    }
        //}

        private DataTable GetTree()
        {
            string sSQL = @"SELECT convert(float,c.SortSeq) as ���,vp.InvCode AS ĸ������,vp.InvName AS ĸ������,vpi.cEnglishName as ĸ��Ӣ������,
            vp.InvStd AS ĸ������ͺ�,vp.ComUnitName AS ĸ��������λ,
CONVERT(nvarchar(40), CASE vp.InvAttr WHEN 1 THEN '�ɹ���' WHEN 2 THEN 'ί���' WHEN 3 THEN '���Ƽ�' WHEN 4 THEN 'ѡ����' WHEN 5 THEN 'PTO' WHEN 6 THEN '' WHEN 7 THEN '�ƻ�Ʒ' ELSE '' END) AS ĸ����������,
            vc.InvCode AS �Ӽ�����,vc.InvName AS �Ӽ�����,vci.cEnglishName as �Ӽ�Ӣ������,
            vc.InvStd AS �Ӽ�����ͺ�,vc.ComUnitName AS �Ӽ�������λ,
            o.WhCode AS �ֿ����,w.cWhName AS �ֿ�����,convert(nvarchar(40),case b.Status when 4 then 'ͣ��' when 3 then '���'  end ) as ״̬ ,
            c.BaseQtyN AS '��������',c.BaseQtyD AS '��������',
            (case when c.AuxUnitCode is null or vc.BOMExpandUnitType = 1 then c.BaseQtyN else c.AuxBaseQtyN * c.Changerate end)/c.BaseQtyD * ( 1 + c.CompScrap/100) / case when c.FVFlag = 1 then (1 - p.ParentScrap/100) else 1 end   as ����ʹ������,
            (case when c.AuxUnitCode is null or vc.BOMExpandUnitType = 1 then c.BaseQtyN else c.AuxBaseQtyN * c.Changerate end)/c.BaseQtyD * ( 1 + c.CompScrap/100) / case when c.FVFlag = 1 then (1 - p.ParentScrap/100) else 1 end as ʹ������ ,
            CONVERT(nvarchar(40), CASE vc.InvAttr WHEN 1 THEN '�ɹ���' WHEN 2 THEN 'ί���' WHEN 3 THEN '���Ƽ�' WHEN 4 THEN 'ѡ����' WHEN 5 THEN 'PTO' WHEN 6 THEN '' WHEN 7 THEN '�ƻ�Ʒ' ELSE '' END) AS �Ӽ���������  ,
 ( CASE o.WIPType WHEN 2 THEN '���򵹳�' WHEN 1 THEN '��⵹��' WHEN 3 THEN '����' WHEN 4 THEN '�����' ELSE 'ֱ�ӹ�Ӧ' END) AS ��Ӧ���� 
            FROM bom_bom b with (nolock) 
            INNER JOIN bom_parent p with (nolock) ON b.BomId = p.BomId 
            INNER JOIN bas_part bp with (nolock) ON bp.PartId = p.ParentId 
            INNER JOIN v_bas_inventory vp with (nolock) ON bp.InvCode = vp.InvCode 
            INNER JOIN bom_opcomponent c with (nolock) ON b.BomId = c.BomId 
            INNER JOIN bas_part bc with (nolock) ON bc.PartId = c.ComponentId 
            INNER JOIN v_bas_inventory vc with (nolock) ON vc.InvCode = bc.InvCode 
            LEFT OUTER JOIN bom_opcomponentopt o with (nolock) ON o.OptionsId = c.OptionsId 
            LEFT OUTER JOIN WareHouse w ON w.cWhCode = o.WhCode 
            LEFT OUTER JOIN Department d ON d.cDepCode = o.DrawDeptCode   
            LEFT OUTER JOIN ecn_ecnapplydetail as ed with (nolock) on ed.ApplyDId = b.ApplyDId 
            LEFT OUTER JOIN ecn_ecnapply as eh with (nolock) on ed.ApplyId = eh.ApplyId  
            LEFT OUTER JOIN ComputationUnit fu with (nolock) on fu.cComunitCode = c.AuxUnitCode  
            LEFT OUTER JOIN v_prouting_all s  with (nolock) on s.partid = p.parentid and s.RountingType = b.bomtype and (b.bomtype = 1 and b.VersionEffDate >= s.VersionEffDate and b.VersionEffDate < s.VersionEndDate or b.bomtype = 2 and b.IdentCode = s.IdentCode)  
            LEFT OUTER JOIN sfc_proutingdetail s1  with (nolock) on s.PRoutingId = s1.PRoutingId and s1.opseq = c.opseq  
            LEFT OUTER JOIN inventory as vpi on vp.InvCode=vpi.cInvCode 
            LEFT OUTER JOIN inventory as vci on vc.InvCode=vci.cInvCode 
            WHERE 1=1 AND  ( b.BomType = 1)  AND c.EffBegDate <= coalesce(b.VersionEffDate,c.EffEndDate) AND c.EffEndDate > coalesce(b.VersionEffDate,c.EffBegDate) and b.VersionEndDate > getdate()
            and vpi.cInvCCode<>'I09' and vci.cInvCCode<>'I09'
            Order By vp.InvCode,convert(float,c.SortSeq)  ";
            return SqlHelper.ExecuteDataset(Conn, CommandType.Text, sSQL).Tables[0];
        }

        private DataTable GetCusInvContraposeGroup()
        {
            string sSQL = @"select distinct cInvCode from inventory where cInvCCode='I05'";
            return SqlHelper.ExecuteDataset(Conn, CommandType.Text, sSQL).Tables[0];
        } 

        private DataTable GetCusInvContrapose()
        {
            string sSQL = @"select a.cCusCode,cInvCode,cCusInvCode,b.cCusName,b.cCusDefine2 from CusInvContrapose  a left join Customer b on a.cCusCode=b.cCusCode ";
            return SqlHelper.ExecuteDataset(Conn, CommandType.Text, sSQL).Tables[0];
        }

        private DataTable GetSo()
        {
//            string sSQL = @"select cInvCode,iQuantity-isnull(iFHQuantity,0)  as iQuantity,iTaxUnitPrice,ddate  from SO_SOMain  a left join SO_SODetails b on a.ID =b.ID 
//                where convert(varchar(10),cDefine36,120)>='" + DateTime.Parse(ed).AddDays(1).ToString("yyyy-MM-dd") + "' and convert(varchar(10),cDefine36,120)<='" + DateTime.Parse(ed).AddDays(16).ToString("yyyy-MM-dd") + "' and isnull(cVerifier,'')<>'' ";
            string sSQL = @"select cInvCode,iQuantity-isnull(iKPQuantity,0)  as iQuantity,iTaxUnitPrice,ddate  from SO_SOMain  a left join SO_SODetails b on a.ID =b.ID 
                where iQuantity-isnull(iKPQuantity,0)>0 and isnull(cVerifier,'')<>'' and isnull(cSCloser,'')='' and isnull(cSCloser,'')='' ";
            return SqlHelper.ExecuteDataset(Conn, CommandType.Text, sSQL).Tables[0];
        }

        private DataTable GetInv()
        {
            string sSQL = @"SELECT * FROM  Inventory ";
            return SqlHelper.ExecuteDataset(Conn, CommandType.Text, sSQL).Tables[0];
        }

        private DataTable GetCb()
        {
            string sSQL = "select * from Inventory ";
            return SqlHelper.ExecuteDataset(Conn, CommandType.Text, sSQL).Tables[0];
        }

        private DataTable GetSfchz()
        {
            string sSQL = @"if object_id(N'_temp_sfchz',N'U') is not null drop table _temp_sfchz

declare @p1 int
set @p1=0
exec sp_prepexecrpc @p1 output,N'sp_CO_InvHZ','  1>0  and  1>0  and  1>0  and  1>0  and  1>0  and  1>0  and  1>0  and  1>0  and  1>0  and  1>0  and  ( A.iPeriod  >= N''201710'') and ( A.iPeriod  <= N''201710'') and  right(A.iPeriod,2) <> ''00'' ','1=1','_temp_sfchz',1,2,'201710','201710','201700'
select @p1";
            sSQL = sSQL.Replace("201710", DateTime.Parse(sd).ToString("yyyyMM"));
            SqlHelper.ExecuteScalar(Conn, CommandType.Text, sSQL);
            sSQL = @"select *,ISNULL(ʵ�ʲ��Ϸ���,0)+ISNULL(ʵ���˹�����,0)+ISNULL(ʵ�ʹ̶��������,0)+ISNULL(ʵ�ʱ䶯�������,0)+ISNULL(ʵ��ί��ӹ���,0) as ����� 
            ,case when isnull(����,0)=0 then 0 else ISNULL(ʵ�ʲ��Ϸ���,0)/isnull(����,0) end as ʵ�ʲ��ϵ���
            ,case when isnull(����,0)=0 then 0 else ISNULL(ʵ���˹�����,0)/isnull(����,0) end as ʵ���˹�����
            ,case when isnull(����,0)=0 then 0 else ISNULL(ʵ�ʹ̶��������,0)/isnull(����,0) end as ʵ�ʹ̶����쵥��
            ,case when isnull(����,0)=0 then 0 else ISNULL(ʵ�ʱ䶯�������,0)/isnull(����,0) end as ʵ�ʱ䶯���쵥��
            from _temp_sfchz";
            return SqlHelper.ExecuteDataset(Conn, CommandType.Text, sSQL).Tables[0];
        }

        private void grvDetail_CustomDrawRowIndicator(object sender, DevExpress.XtraGrid.Views.Grid.RowIndicatorCustomDrawEventArgs e)
        {

            if (e.RowHandle < 0)
                return;
            e.Info.DisplayText = (e.RowHandle + 1).ToString();
        }

        private void btnExcel_Click(object sender, EventArgs e)
        {
            try
            {
                SaveFileDialog sa = new SaveFileDialog();
                sa.Filter = "Excel�ļ�2003|*.xls";
                sa.FileName = "����";

                DialogResult d = sa.ShowDialog();
                if (d == DialogResult.OK)
                {
                    string sPath = sa.FileName;

                    if (sPath.Trim() != string.Empty)
                    {
                        treeList1.ExportToXls(sPath);
                        MessageBox.Show("�����б�ɹ���\n·����" + sPath);
                    }
                }
                
            }
            catch (Exception ee)
            {
                MessageBox.Show("�����б�ʧ�ܣ�" + ee.Message);
            }
        }

    }
}