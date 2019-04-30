using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Collections;
using FrameBaseFunction;

namespace Base
{
    public partial class Frm询价单结论公布内部 : FrameBaseFunction.Frm列表窗体模板
    {
        string sGuid = "";
        string sDepCode = "";

        public Frm询价单结论公布内部(string s_Guid,string s_DepCode)
        {
            InitializeComponent();

            sGuid = s_Guid;
            sDepCode = s_DepCode;
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
                 
                    default:
                        break;
                }

                sState = sBtnName.ToLower();
            }
            catch (Exception ee)
            {
                throw new Exception(sBtnText + " 失败! \n\n原因:\n  " + ee.Message);
            }
        }


        private void SetLookup()
        {
            string sSQL = "select cDepCode,cDepName from @u8.Department order by cDepCode";
            DataTable dt = clsSQLCommond.ExecQuery(sSQL);
            lookUpEditcDepCode.Properties.DataSource = dt;
            lookUpEditcDepCode.EditValue = sDepCode;
        }


        private void btnSel()
        {
            string sSQL = @"
if exists (select * from tempdb.dbo.sysobjects where id = object_id(N'tempdb..#a') and type='U')
	drop table #a

select distinct a.标题, CONVERT(varchar, a.单据日期, 120) AS 单据日期 , CONVERT(varchar, a.截止日期, 120) AS 截止日期,CONVERT(varchar, a.终止询价日期, 120) AS 终止询价日期
	,c.自定义物料,c.物料编码,d.cInvName as 物料名称,d.cInvStd as 规格型号
	,CAST(null as decimal(16,2)) as 最低价,CAST(null as decimal(16,2)) as 最高价,CAST(null as decimal(16,2)) as 录用价
	,c.GUID物料,a.[GUID],c.备注1
into #a
from UFDLImport..询价单 a inner join UFDLImport..询价单供应商 b on a.[GUID] = b.[GUID]
	inner join UFDLImport..询价单物料列表 c on a.[GUID] = c.[GUID] and b.[GUID] = c.[GUID]
	inner join @u8.Inventory d on c.物料编码 = d. cInvCode
where a.[GUID] = '111111'


update #a set 最低价 = a.最低价
from
(
	select [GUID],[GUID物料],min(单价) as 最低价
	from UFDLImport..询价单供应商报价
	where [GUID] = '111111'
		and ISNULL(单价,0) <> 0
	group by [GUID],[GUID物料]
)a
where a.GUID = #a.GUID and a.GUID物料 = #a.GUID物料

update #a set 最高价 = a.最高价
from
(
	select [GUID],[GUID物料],max(单价) as 最高价
	from UFDLImport..询价单供应商报价
	where [GUID] = '111111'
	group by [GUID],[GUID物料]
)a
where a.GUID = #a.GUID and a.GUID物料 = #a.GUID物料

update #a set 录用价 = a.录用价
from
(
	select a.[GUID],a.[GUID物料],max(a.单价) as 录用价
	from UFDLImport..询价单供应商报价 a inner join UFDLImport..询价单供应商 b on a.[GUID] = b.[guid]
	where a.[GUID] = '111111'
		and a.审批结论 = '通过'
group by a.[GUID],a.[GUID物料]
)a
where a.GUID = #a.GUID and a.GUID物料 = #a.GUID物料

select * from #a 

if exists (select * from tempdb.dbo.sysobjects where id = object_id(N'tempdb..#a') and type='U')
	drop table #a
";
            sSQL = sSQL.Replace("111111", sGuid);
            DataTable dt = clsSQLCommond.ExecQuery(sSQL);
            gridControl1.DataSource = dt;

        }


        #region 按钮模板

      
        /// <summary>
        /// 输出
        /// </summary>
        private void btnExport()
        {
            try
            {
                SaveFileDialog sF = new SaveFileDialog();
                sF.DefaultExt = "xls";
                sF.FileName = this.Text;
                sF.Filter = "Excel文件(*.xls)|*.xls|所有文件(*.*)|*.*";
                DialogResult dRes = sF.ShowDialog();
                if (DialogResult.OK == dRes)
                {
                    gridView1.ExportToXls(sF.FileName);
                    MessageBox.Show("导出Excel成功\n\t路径：" + sF.FileName);
                }
            }
            catch (Exception ee)
            {
                MessageBox.Show(ee.Message);
            }
        }

      
        #endregion






        private void Frm_Load(object sender, EventArgs e)
        {
            try
            {
                SetLookup();
                lookUpEditcDepCode.EditValue = sDepCode;
                if (lookUpEditcDepCode.Text.Trim() == "")
                {
                    MessageBox.Show("获得部门信息失败");
                    this.Close();
                    return;
                }
                btnSel();
            }
            catch (Exception ee)
            {
                MessageBox.Show("加载窗体失败\n" + ee.Message);
            }
        }

        private void gridView_CustomDrawRowIndicator(object sender, DevExpress.XtraGrid.Views.Grid.RowIndicatorCustomDrawEventArgs e)
        {
            e.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            if (e.Info.IsRowIndicator)
            {
                if (e.RowHandle >= 0)
                {
                    e.Info.DisplayText = (e.RowHandle + 1).ToString();
                }
                else if (e.RowHandle < 0 && e.RowHandle > -1000)
                {
                    e.Info.Appearance.BackColor = System.Drawing.Color.AntiqueWhite;
                    e.Info.DisplayText = "G" + e.RowHandle.ToString();
                }
            }
        }

    }
}