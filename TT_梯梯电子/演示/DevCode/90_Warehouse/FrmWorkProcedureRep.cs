using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Warehouse
{
    public partial class FrmWorkProcedureRep : FrameBaseFunction.Frm列表窗体模板
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
                MessageBox.Show(sBtnText + " 失败! \n\n原因:\n  " + ee.Message, "提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
                sa.Filter = "Excel文件2003|*.xls";
                sa.FileName = "表列信息";

                DialogResult d = sa.ShowDialog();
                if (d == DialogResult.OK)
                {
                    string sPath = sa.FileName;

                    if (sPath.Trim() != string.Empty)
                    {
                        gridView1.ExportToXls(sPath);
                        MessageBox.Show("导出列表成功！\n路径：" + sPath);
                    }
                }
            }
            catch (Exception ee)
            {
                throw new Exception("导出列表失败：" + ee.Message);
            }
        }

        private void btnSel()
        {
            string sSQL = @"
select distinct a.workDepment as 组别,c.SoCode as 外销单号,a.WorkOrderNO as 制造令,c.SortSeq as 行号,c.InvCode as 物料编码,e.cInvName as 物料名称,e.cInvStd as 规格型号,
    c.Qty as 订单数量,a.vchrRemark as 未完工数量,c.Qty - isnull(c.QualifiedInQty,0) as 未缴库数量,f.InvCode as 材料编码,g.cInvName as 材料名称,g.cInvStd as 材料规格,
    d.Qty as 应领数量,d.TransQty as 调拨数量,case when isnull(h.cmocode,'') = ''  then '' else '是' end as 反向调拨标记 
from UFDLImport..WorkPlan a left join @u8.mom_order b on a.WorkOrderNO = b.MoCode 
    left join @u8.mom_orderdetail c on b.MoId = c.MoId
    left join @u8.mom_moallocate d on d.MoDId = c.MoDId 
    left join @u8.Inventory  e on e.cInvCode = c.InvCode
    left join @u8.bas_Part f on d.ComponentId = f.PartId 
    left join @u8.Inventory g on g.cInvCode = f.invCode
    left join (select distinct a.cmocode,b.itransflag from @u8.TransVouchs a inner join @u8.TransVouch b on a.id = b.id where b.itransflag = '反向') h on h.cmocode = a.WorkOrderNO 
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