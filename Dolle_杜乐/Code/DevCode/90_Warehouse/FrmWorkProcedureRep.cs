using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Warehouse
{
    public partial class FrmWorkProcedureRep : FrameBaseFunction.Frm�б���ģ��
    {
        public FrmWorkProcedureRep()
        {
            InitializeComponent();
        }

        private void FrmWorkProcedureRep_Load(object sender, EventArgs e)
        {
            date1.DateTime = Convert.ToDateTime(FrameBaseFunction.ClsBaseDataInfo.sLogDate).AddDays(-3);
            date2.DateTime = Convert.ToDateTime(FrameBaseFunction.ClsBaseDataInfo.sLogDate);
            date1.Enabled = true;
            date2.Enabled = true;
            date1.Properties.ReadOnly = false;
            date2.Properties.ReadOnly = false;
        }


        protected override void BtnClick(string sBtnName, string sBtnText)
        {
            try
            {
                switch (sBtnName.ToLower())
                {
                    case "sel":
                        btnSel();
                        break;
                    case "export":
                        btnExport();
                        break;
                    default:
                        break;
                }
            }
            catch (Exception ee)
            {
                MessageBox.Show(sBtnText + " ʧ��! \n\nԭ��:\n  " + ee.Message, "��ʾ", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void btnExport()
        {
            try
            {
                try
                {
                    gridView1.FocusedRowHandle -= 1;
                }
                catch { }

                SaveFileDialog sa = new SaveFileDialog();
                sa.Filter = "Excel�ļ�2003|*.xls";
                sa.FileName = "������Ϣ";

                DialogResult d = sa.ShowDialog();
                if (d == DialogResult.OK)
                {
                    string sPath = sa.FileName;

                    if (sPath.Trim() != string.Empty)
                    {
                        gridView1.ExportToXls(sPath);
                        MessageBox.Show("�����б�ɹ���\n·����" + sPath);
                    }
                }
            }
            catch (Exception ee)
            {
                throw new Exception("�����б�ʧ�ܣ�" + ee.Message);
            }
        }

        private void btnSel()
        {
            string sSQL = @"
select distinct a.workDepment as ���,c.SoCode as ��������,a.WorkOrderNO as ������,c.SortSeq as �к�,c.InvCode as ���ϱ���,e.cInvName as ��������,e.cInvStd as ����ͺ�,
    c.Qty as ��������,a.vchrRemark as δ�깤����,c.Qty - isnull(c.QualifiedInQty,0) as δ�ɿ�����,f.InvCode as ���ϱ���,g.cInvName as ��������,g.cInvStd as ���Ϲ��,
    d.Qty as Ӧ������,d.TransQty as ��������,case when isnull(h.cmocode,'') = ''  then '' else '��' end as ���������� 
from UFDLImport..WorkPlan a left join @u8.mom_order b on a.WorkOrderNO = b.MoCode 
    left join @u8.mom_orderdetail c on b.MoId = c.MoId
    left join @u8.mom_moallocate d on d.MoDId = c.MoDId 
    left join @u8.Inventory  e on e.cInvCode = c.InvCode
    left join @u8.bas_Part f on d.ComponentId = f.PartId 
    left join @u8.Inventory g on g.cInvCode = f.invCode
    left join (select distinct a.cmocode,b.itransflag from @u8.TransVouchs a inner join @u8.TransVouch b on a.id = b.id where b.itransflag = '����') h on h.cmocode = a.WorkOrderNO 
where a.dtmPlan >= '111111' and a.dtmPlan <= '222222' and accid = '333333' and accyear = '444444' 
order by a.WorkOrderNO,c.SortSeq
";

                sSQL = sSQL.Replace("111111",date1.DateTime.ToString("yyyy-MM-dd"));
                sSQL = sSQL.Replace("222222",date2.DateTime.ToString("yyyy-MM-dd"));
                sSQL = sSQL.Replace("333333",FrameBaseFunction.ClsBaseDataInfo.sUFDataBaseName.Substring(7, 3));
                sSQL = sSQL.Replace("444444",FrameBaseFunction.ClsBaseDataInfo.sUFDataBaseName.Substring(11, 4));
            DataTable dt = clsSQLCommond.ExecQuery(sSQL);
            gridControl1.DataSource = dt;
        }

    }
}