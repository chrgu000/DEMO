using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraLayout;
using System.IO;
using FrameBaseFunction;
using System.Data.SqlClient;
using System.Collections;


namespace SaleOrder
{
    public partial class Frm外销订单总表 : FrameBaseFunction.Frm列表窗体模板
    {
        public Frm外销订单总表()
        {
            InitializeComponent();


            sLayoutHeadPath = base.sProPath + "\\layout\\" + this.Text.Trim() + "Head.xml";
            sLayoutGridPath = base.sProPath + "\\layout\\" + this.Text.Trim() + "Grid.xml";

            if (File.Exists(sLayoutHeadPath))
                layoutControl1.RestoreLayoutFromXml(sLayoutHeadPath);

            if (File.Exists(sLayoutGridPath))
            {
                gridControl外销订单总表.MainView.RestoreLayoutFromXml(sLayoutGridPath);
            }

            dtBingGrid = new DataTable();
            dtBingHead = new DataTable();
        }

        int iCols = 53;

        #region 按钮操作
        protected override void BtnClick(string sBtnName, string sBtnText)
        {
            try
            {
                switch (sBtnName.ToLower())
                {
                    case "addrow":
                        btnAddRow();
                        break;
                    case "alter":
                        btnAlter();
                        break;
                    case "audit":
                        btnAudit();
                        break;
                    case "add":
                        btnAdd();
                        break;
                    case "del":
                        btnDel();
                        break;
                    case "delrow":
                        btnDelRow();
                        break;
                    case "edit":
                        btnEdit();
                        break;
                    case "export":
                        btnExport();
                        break;
                    case "first":
                        btnFirst();
                        break;
                    case "import":
                        btnImport();
                        break;
                    case "last":
                        btnLast();
                        break;
                    case "lock":
                        btnLock();
                        break;
                    case "next":
                        btnNext();
                        break;
                    case "prev":
                        btnPrev();
                        break;
                    case "print":
                        btnPrint();
                        break;
                    //case "printset":
                    //    btnPrintSet();
                    //    break;
                    case "refresh":
                        btnRefresh();
                        break;
                    case "save":
                        btnSave();
                        break;
                    case "sel":
                        btnSel();
                        break;
                    case "unaudit":
                        btnUnAudit();
                        break;
                    case "undo":
                        btnUnDo();
                        break;
                    case "unlock":
                        btnUnLock();
                        break;
                    case "open":
                        btnOpen();
                        break;
                    case "close":
                        btnClose();
                        break;
                    case "layout":
                        btnLayout(sBtnText);
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

        DataTable dt评审 = new DataTable();

        private void btnAdd()
        {
           
        }

        #region 按钮模板

        ///// <summary>
        ///// 将表格中Lookup之类的保存ID的数据转换成Text用于打印
        ///// </summary>
        ///// <param name="dt"></param>
        ///// <returns></returns>
        private DataTable SetPrintData(DataTable dt)
        {
        //    DataTable dtState = (DataTable)ItemLookUpEditState.DataSource;
        //    DataColumn dc = new DataColumn();
        //    dc.ColumnName = "StateText";
        //    dt.Columns.Add(dc);
           
        //    for (int i = 0; i < dt.Rows.Count; i++)
        //    {
        //        DataRow[] drState = dtState.Select("iID = '" + dt.Rows[i]["State"].ToString().Trim() + "'");
        //        if (drState.Length > 0)
        //        {
        //            dt.Rows[i]["StateText"] = drState[0]["State"];
        //        }

        //    }

            return dt;
        }

        /// <summary>
        /// 打印
        /// </summary>
        private void btnPrint()
        {
        
        }
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
                    gridView外销订单总表.ExportToXls(sF.FileName);
                    MessageBox.Show("导出Excel成功\n\t路径：" + sF.FileName);
                }
            }
            catch (Exception ee)
            {
                MessageBox.Show(ee.Message);
            }
        }

        private void btnLayout(string sText)
        {
         
        }
        #endregion

        /// <summary>
        /// 导入
        /// </summary>
        private void btnImport()
        {

        }
        /// <summary>
        /// 刷新
        /// </summary>
        private void btnRefresh()
        {
            GetLookUp();
            btnSel();
        }

        /// <summary>
        /// 查询
        /// </summary>
        private void btnSel()
        {
            SetBandCatpion();

            string sSQL = @"
declare @sAccid varchar(3)
set @sAccid = '555555'

declare @sYear varchar(4)
set @sYear = '666666'


select *
into #j
from
(
	select 帐套号, 销售订单号 , 行号
                  , sum(isnull([1周2],0) + isnull([2周2],0) + isnull([3周2],0) + isnull([4周2],0) + isnull([5周2],0) + isnull([6周2],0) + isnull([7周2],0) + isnull([8周2],0) + isnull([9周2],0) + isnull([10周2],0) + 
                    isnull([11周2],0) + isnull([12周2],0) + isnull([13周2],0) + isnull([14周2],0) + isnull([15周2],0) + isnull([16周2],0) + isnull([17周2],0) + isnull([18周2],0) + isnull([19周2],0) + isnull([20周2],0) + 
                    isnull([21周2],0) + isnull([22周2],0) + isnull([23周2],0) + isnull([24周2],0) + isnull([25周2],0) + isnull([26周2],0) + isnull([27周2],0) + isnull([28周2],0) + isnull([29周2],0) + isnull([30周2],0) + 
                    isnull([31周2],0) + isnull([32周2],0) + isnull([33周2],0) + isnull([34周2],0) + isnull([35周2],0) + isnull([36周2],0) + isnull([37周2],0) + isnull([38周2],0) + isnull([39周2],0) + isnull([40周2],0) + 
                    isnull([41周2],0) + isnull([42周2],0) + isnull([43周2],0) + isnull([44周2],0) + isnull([45周2],0) + isnull([46周2],0) + isnull([47周2],0) + isnull([48周2],0) + isnull([49周2],0) + isnull([50周2],0) + 
                    isnull([51周2],0) + isnull([52周2],0) + isnull([53周2],0))  as 其他年度发货总数
                from XWSystemDB_DL..外销订单总表
                where 帐套号 = @sAccid and 年度 <> @sYear
                group by 帐套号,销售订单号 , 行号
)a


select *
into #k
from
(
select 帐套号, 销售订单号 , 行号
				  , sum(isnull([1周],0) + isnull([2周],0) + isnull([3周],0) + isnull([4周],0) + isnull([5周],0) + isnull([6周],0) + isnull([7周],0) + isnull([8周],0) + isnull([9周],0) + isnull([10周],0) + 
					isnull([11周],0) + isnull([12周],0) + isnull([13周],0) + isnull([14周],0) + isnull([15周],0) + isnull([16周],0) + isnull([17周],0) + isnull([18周],0) + isnull([19周],0) + isnull([20周],0) + 
					isnull([21周],0) + isnull([22周],0) + isnull([23周],0) + isnull([24周],0) + isnull([25周],0) + isnull([26周],0) + isnull([27周],0) + isnull([28周],0) + isnull([29周],0) + isnull([30周],0) + 
					isnull([31周],0) + isnull([32周],0) + isnull([33周],0) + isnull([34周],0) + isnull([35周],0) + isnull([36周],0) + isnull([37周],0) + isnull([38周],0) + isnull([39周],0) + isnull([40周],0) + 
					isnull([41周],0) + isnull([42周],0) + isnull([43周],0) + isnull([44周],0) + isnull([45周],0) + isnull([46周],0) + isnull([47周],0) + isnull([48周],0) + isnull([49周],0) + isnull([50周],0) + 
					isnull([51周],0) + isnull([52周],0) + isnull([53周],0))  as 其他年度出货计划总数
				from XWSystemDB_DL..外销订单总表
				where 帐套号 = @sAccid and 年度 <> @sYear
                group by 帐套号,销售订单号 , 行号
)a

select *
into #l
from
(
  select 销售订单号 , 行号,sum(isnull(标记延期,0)) as 标记延期
                from  XWSystemDB_DL..外销订单总表
				where 帐套号 = @sAccid
                group by 销售订单号 , 行号
 )a

select distinct CAST(0 as bit) as 选择,b.AutoID as 销售订单子表ID,b.cDefine36 as 客户要求船期,datediff(d,b.cDefine36,case when ISNULL(e.订单交期回复,'') <> '' then e.订单交期回复 else b.dPreDate end) as 延期天数
    ,e.实际出货日期
    ,cast(null as varchar(50)) as 制造令号码
	,case when ISNULL(e.订单交期回复,'') <> '' then e.订单交期回复 else b.dPreDate end as 订单交期回复
    ,case when ISNULL(e.备注,'') <> '' then e.备注 else a.cMemo end as 备注,cast(a.dcreatesystime as varchar(20)) as 制单时间
	,case when ISNULL(e.交货方式,'') <> '' then e.交货方式 else i.cSCName end as 交货方式
	,b.iRowNo as 订单行号,a.cSOCode as 订单编号,a.cDefine2 as 订单号码,b.cInvCode as 产品编号,c.cInvName as 产品名称,f.cCusName  as 客户
	,rtrim(ltrim(e.组别)) as 组别,c.cInvDefine9 as 是否FSC,d.cComUnitName as 单位,b.iQuantity as 订单数量
          , isnull(e.[1周2],0) + isnull(e.[2周2],0) + isnull(e.[3周2],0) + isnull(e.[4周2],0) + isnull(e.[5周2],0) + isnull(e.[6周2],0) + isnull(e.[7周2],0) + isnull(e.[8周2],0) + isnull(e.[9周2],0) + isnull(e.[10周2],0) + 
            isnull(e.[11周2],0) + isnull(e.[12周2],0) + isnull(e.[13周2],0) + isnull(e.[14周2],0) + isnull(e.[15周2],0) + isnull(e.[16周2],0) + isnull(e.[17周2],0) + isnull(e.[18周2],0) + isnull(e.[19周2],0) + isnull(e.[20周2],0) + 
            isnull(e.[21周2],0) + isnull(e.[22周2],0) + isnull(e.[23周2],0) + isnull(e.[24周2],0) + isnull(e.[25周2],0) + isnull(e.[26周2],0) + isnull(e.[27周2],0) + isnull(e.[28周2],0) + isnull(e.[29周2],0) + isnull(e.[30周2],0) + 
            isnull(e.[31周2],0) + isnull(e.[32周2],0) + isnull(e.[33周2],0) + isnull(e.[34周2],0) + isnull(e.[35周2],0) + isnull(e.[36周2],0) + isnull(e.[37周2],0) + isnull(e.[38周2],0) + isnull(e.[39周2],0) + isnull(e.[40周2],0) + 
            isnull(e.[41周2],0) + isnull(e.[42周2],0) + isnull(e.[43周2],0) + isnull(e.[44周2],0) + isnull(e.[45周2],0) + isnull(e.[46周2],0) + isnull(e.[47周2],0) + isnull(e.[48周2],0) + isnull(e.[49周2],0) + isnull(e.[50周2],0) + 
            isnull(e.[51周2],0) + isnull(e.[52周2],0) + isnull(e.[53周2],0)+ isnull(j.其他年度发货总数,0) as 已出货数量
    ,
        b.iQuantity - 
                    (isnull(e.[1周2],0) + isnull(e.[2周2],0) + isnull(e.[3周2],0) + isnull(e.[4周2],0) + isnull(e.[5周2],0) + isnull(e.[6周2],0) + isnull(e.[7周2],0) + isnull(e.[8周2],0) + isnull(e.[9周2],0) + isnull(e.[10周2],0) + 
            isnull(e.[11周2],0) + isnull(e.[12周2],0) + isnull(e.[13周2],0) + isnull(e.[14周2],0) + isnull(e.[15周2],0) + isnull(e.[16周2],0) + isnull(e.[17周2],0) + isnull(e.[18周2],0) + isnull(e.[19周2],0) + isnull(e.[20周2],0) + 
            isnull(e.[21周2],0) + isnull(e.[22周2],0) + isnull(e.[23周2],0) + isnull(e.[24周2],0) + isnull(e.[25周2],0) + isnull(e.[26周2],0) + isnull(e.[27周2],0) + isnull(e.[28周2],0) + isnull(e.[29周2],0) + isnull(e.[30周2],0) + 
            isnull(e.[31周2],0) + isnull(e.[32周2],0) + isnull(e.[33周2],0) + isnull(e.[34周2],0) + isnull(e.[35周2],0) + isnull(e.[36周2],0) + isnull(e.[37周2],0) + isnull(e.[38周2],0) + isnull(e.[39周2],0) + isnull(e.[40周2],0) + 
            isnull(e.[41周2],0) + isnull(e.[42周2],0) + isnull(e.[43周2],0) + isnull(e.[44周2],0) + isnull(e.[45周2],0) + isnull(e.[46周2],0) + isnull(e.[47周2],0) + isnull(e.[48周2],0) + isnull(e.[49周2],0) + isnull(e.[50周2],0) + 
            isnull(e.[51周2],0) + isnull(e.[52周2],0) + isnull(e.[53周2],0) + isnull(j.其他年度发货总数,0)) as 未出货数量
    ,b.iQuantity  -(
                        isnull([1周],0) + isnull([2周],0) + isnull([3周],0) + isnull([4周],0) + isnull([5周],0) + isnull([6周],0) + isnull([7周],0) + isnull([8周],0) + isnull([9周],0) + isnull([10周],0) + 
					    isnull([11周],0) + isnull([12周],0) + isnull([13周],0) + isnull([14周],0) + isnull([15周],0) + isnull([16周],0) + isnull([17周],0) + isnull([18周],0) + isnull([19周],0) + isnull([20周],0) + 
					    isnull([21周],0) + isnull([22周],0) + isnull([23周],0) + isnull([24周],0) + isnull([25周],0) + isnull([26周],0) + isnull([27周],0) + isnull([28周],0) + isnull([29周],0) + isnull([30周],0) + 
					    isnull([31周],0) + isnull([32周],0) + isnull([33周],0) + isnull([34周],0) + isnull([35周],0) + isnull([36周],0) + isnull([37周],0) + isnull([38周],0) + isnull([39周],0) + isnull([40周],0) + 
					    isnull([41周],0) + isnull([42周],0) + isnull([43周],0) + isnull([44周],0) + isnull([45周],0) + isnull([46周],0) + isnull([47周],0) + isnull([48周],0) + isnull([49周],0) + isnull([50周],0) + 
					    isnull([51周],0) + isnull([52周],0) + isnull([53周],0)
                    )
                    - isnull(k.其他年度出货计划总数,0)
        as 计划余量
	,j.其他年度发货总数 as 其他年度发货总数
	,k.其他年度出货计划总数 as 其他年度出货计划总数
	,e.帐套号, e.年度, e.销售订单子表ID
	,e.分类, e.已出货数量, e.[1周], e.[2周], e.[3周], e.[4周], e.[5周], e.[6周], e.[7周], e.[8周], e.[9周], e.[10周], e.[11周], e.[12周], e.[13周], e.[14周], e.[15周], e.[16周]
	,e.[17周], e.[18周], e.[19周], e.[20周], e.[21周], e.[22周], e.[23周], e.[24周], e.[25周], e.[26周], e.[27周], e.[28周], e.[29周], e.[30周], e.[31周], e.[32周], e.[33周], e.[34周], e.[35周], e.[36周], e.[37周], e.[38周], e.[39周]
	,e.[40周], e.[41周], e.[42周], e.[43周], e.[44周], e.[45周], e.[46周], e.[47周], e.[48周], e.[49周], e.[50周], e.[51周], e.[52周], e.[53周], e.[1周2], e.[2周2], e.[3周2], e.[4周2], e.[5周2], e.[6周2], e.[7周2], e.[8周2], e.[9周2]
	,e.[10周2], e.[11周2], e.[12周2], e.[13周2], e.[14周2], e.[15周2], e.[16周2], e.[17周2], e.[18周2], e.[19周2], e.[20周2], e.[21周2], e.[22周2], e.[23周2], e.[24周2], e.[25周2], e.[26周2], e.[27周2], e.[28周2]
	,e.[29周2], e.[30周2], e.[31周2], e.[32周2], e.[33周2], e.[34周2], e.[35周2], e.[36周2], e.[37周2], e.[38周2], e.[39周2], e.[40周2], e.[41周2], e.[42周2], e.[43周2], e.[44周2], e.[45周2], e.[46周2], e.[47周2] 
	,e.[48周2], e.[49周2], e.[50周2], e.[51周2], e.[52周2], e.[53周2], e.关闭人, e.关闭时间
	,cast(case when isnull(g.销售订单号,'') = '' then 0 else 1 end as bit) as 是否评审
	,cast(case when isnull(h.销售订单号,'') = '' or ISNULL(h.手工计划ID,0) <> 0 then 0 else 1 end as bit) as 是否生产计划
	,cast(case when isnull(h.审核人,'') = '' or ISNULL(h.手工计划ID,0) <> 0 then 0 else 1 end as bit) as 生产计划审核
    ,cast(case when isnull(l.标记延期,0) = 0 then 0 else 1 end as bit) as 标记延期
from @u8.so_somain a inner join @u8.so_sodetails b on a.id = b.id
	inner join @u8.inventory c on b.cinvcode = c.cinvcode 
	inner join @u8.ComputationUnit d on d.cComunitCode = c.cComUnitCode
	left join XWSystemDB_DL..外销订单总表 e on e.销售订单号 = a.cSOCode and e.行号 = b.iRowNo and e.帐套号 = @sAccid and e.年度 = @sYear
	inner join @u8.Customer f on f.cCusCode = a.cCusCode
	left join (select distinct 销售订单号 from XWSystemDB_DL..订单评审运算1 where 帐套号 = @sAccid) g on g.销售订单号 = a.cSOCode
	left join (select distinct 销售订单号,销售订单行号,审核人,手工计划ID from XWSystemDB_DL..生产计划 where 帐套号 = @sAccid and ISNULL(手工计划ID,0) = 0) h on h.销售订单号 = a.cSOCode and h.销售订单行号 = b.iRowNo
    left join @u8.ShippingChoice i on i.cSCCode = a.cSCCode
    left join #j j on  j.销售订单号 = a.cSOCode and j.行号 = b.iRowNo
    left join #k k on  k.销售订单号 = a.cSOCode and k.行号 = b.iRowNo
    left join #l l on  l.销售订单号 = a.cSOCode and l.行号 = b.iRowNo
where 1=1 and a.dDate >= '11111111' and a.dDate <= '22222222'
order by b.AutoID

";
            sSQL = sSQL.Replace("555555",FrameBaseFunction.ClsBaseDataInfo.sUFDataBaseName.Substring(7, 3));
            sSQL = sSQL.Replace("666666", lookUpEdit年度.Text.Trim());
            sSQL = sSQL.Replace("11111111", dateEdit1.DateTime.ToString("yyyy-MM-dd"));
            sSQL = sSQL.Replace("22222222", dateEdit2.DateTime.ToString("yyyy-MM-dd"));

            DataTable dt = clsSQLCommond.ExecQuery(sSQL);

            sSQL = @"
               select distinct a.MoCode,b.InvCode,b.SoCode,b.SoSeq
from @u8.mom_order a inner join @u8.mom_orderdetail b on a.moid = b.moid 
";
            DataTable dt生产订单 = clsSQLCommond.ExecQuery(sSQL);

            for (int i = 0; i < dt.Rows.Count; i++)
            {
                string s销售订单号 = dt.Rows[i]["订单编号"].ToString().Trim();
                string s行号 = dt.Rows[i]["订单行号"].ToString().Trim();
                string s物料 = dt.Rows[i]["产品编号"].ToString().Trim();

                DataRow[] dr = dt生产订单.Select("InvCode = '" + s物料 + "' and SoCode = '" + s销售订单号 + "' and SoSeq = '" + s行号 + "' ");

                string s制造令号码 = "";
                for (int j = 0; j < dr.Length; j++)
                {
                    if (s制造令号码 == "")
                    {
                        s制造令号码 = dr[j]["MoCode"].ToString().Trim();
                    }
                    else
                    {
                        s制造令号码 = s制造令号码 + ";" +dr[j]["MoCode"].ToString().Trim();
                    }
                }

                dt.Rows[i]["制造令号码"] = s制造令号码;
            }

            gridControl外销订单总表.DataSource = dt;

            Get工时();
        }

        /// <summary>
        /// 首页
        /// </summary>
        private void btnFirst()
        {
           
        }
        /// <summary>
        /// 上页
        /// </summary>
        private void btnPrev()
        {
       

        }
        /// <summary>
        /// 下页
        /// </summary>
        private void btnNext()
        {
           
        }

        /// <summary>
        /// 末页
        /// </summary>
        private void btnLast()
        {

        }
        /// <summary>
        /// 锁定
        /// </summary>
        private void btnLock()
        {
            throw new NotImplementedException();
        }
        /// <summary>
        /// 解锁
        /// </summary>
        private void btnUnLock()
        {
            throw new NotImplementedException();
        }
        /// <summary>
        /// 增行
        /// </summary>
        private void btnAddRow()
        {

        }
        /// <summary>
        /// 删行
        /// </summary>
        private void btnDelRow()
        {
           
        }
        /// <summary>
        /// 修改
        /// </summary>
        private void btnEdit()
        {
   
            sState = "edit";
        }
        /// <summary>
        /// 删除
        /// </summary>
        private void btnDel()
        {

        }

        /// <summary>
        /// 保存
        /// </summary>
        private void btnSave()
        {
            try
            {
                gridView外销订单总表.FocusedRowHandle -= 1;
                gridView外销订单总表.FocusedRowHandle += 1;
            }
            catch { }

            string sSQL = "select *,'' as 编辑 from 外销订单总表 where 1=-1";
            DataTable dt外销订单总表 = clsSQLCommond.ExecQuery(sSQL);


            sSQL = "select getdate()";
            DateTime d当前时间 = Convert.ToDateTime(clsSQLCommond.ExecGetScalar(sSQL));

            aList = new System.Collections.ArrayList();
            for(int i=0;i<gridView外销订单总表.RowCount;i++)
            {
                if (Convert.ToBoolean(gridView外销订单总表.GetRowCellValue(i, gridCol选择)))
                {
                    DataRow dr = dt外销订单总表.NewRow();

                    dr["帐套号"] = FrameBaseFunction.ClsBaseDataInfo.sUFDataBaseName.Substring(7, 3);
                    dr["年度"] = lookUpEdit年度.Text.Trim();
                    dr["销售订单号"] = gridView外销订单总表.GetRowCellValue(i, gridCol订单编号).ToString().Trim();
                    dr["行号"] = gridView外销订单总表.GetRowCellValue(i, gridCol订单行号).ToString().Trim();
                    string s出货周 = "";
                    for (int j = 0; j < dt外销订单总表.Columns.Count; j++)
                    { 
                        string sColName = dt外销订单总表.Columns[j].ColumnName.Trim();

                        for (int k = 0; k < gridView外销订单总表.Columns.Count; k++)
                        {
                            string sColNameK = gridView外销订单总表.Columns[k].FieldName.Trim();
                         
                            if (sColName.ToLower() == sColNameK.ToLower())
                            {
                                if (sColNameK.Length > 2 && sColNameK.Substring(sColNameK.Length - 2) == "周2")
                                {
                                    decimal d = ReturnObjectToDecimal(gridView外销订单总表.GetRowCellValue(i, gridView外销订单总表.Columns[k]), 2);
                                    if (d != 0)
                                        dr[j] = d;
                                }
                                else if (sColNameK.Length > 1 && sColNameK.Substring(sColNameK.Length - 1) == "周")
                                {
                                    decimal d = ReturnObjectToDecimal(gridView外销订单总表.GetRowCellValue(i, gridView外销订单总表.Columns[k]), 2);
                                    if (d != 0)
                                    {
                                        dr[j] = d;

                                        if (s出货周 == "")
                                        {
                                            string sCaption = gridView外销订单总表.Columns[k].Caption.Trim();
                                            if(sCaption.Length == 2)
                                            {
                                                sCaption = "0" + sCaption;
                                            }

                                            s出货周 = lookUpEdit年度.Text.Trim() + "-" + sCaption;
                                        }
                                    }
                                }
                                else
                                {
                                    string s = gridView外销订单总表.GetRowCellValue(i, gridView外销订单总表.Columns[k]).ToString().Trim();
                                    if (sColNameK == "标记延期")
                                    {
                                        dr[j] = "0";
                                    }
                                    else
                                    {
                                        if (s != "")
                                        {
                                            dr[j] = s;
                                        }
                                    }
                                }
                            }
                        }
                    }


                
                    dr["出货周"] = s出货周;

                    sSQL = "select count(1) from 外销订单总表 where 帐套号 = '200' and 年度 = '" + lookUpEdit年度.Text.Trim() + "' " +
                                " and 销售订单号 = '" + gridView外销订单总表.GetRowCellValue(i, gridCol订单编号).ToString().Trim() + "' and 行号 = '" + gridView外销订单总表.GetRowCellValue(i, gridCol订单行号).ToString().Trim() + "'";
                    int iCol = ReturnObjectToInt(clsSQLCommond.ExecGetScalar(sSQL));
                    if (iCol > 0)
                    {
                        dr["编辑"] = "edit";
                    }
                    else
                    {
                        dr["编辑"] = "add";
                    }

                    dr["制单人"] = FrameBaseFunction.ClsBaseDataInfo.sUserName;
                    dr["制单日期"] = d当前时间;

                    dt外销订单总表.Rows.Add(dr);

                    if (s出货周 != "")
                    {
                        s出货周 = "'" + s出货周 + "'";
                    }
                    else
                    {

                        sSQL = "select 出货周 from 外销订单总表 where isnull(出货周,'') <> '' and  帐套号 = '200' " +
                                    " and 销售订单号 = '" + gridView外销订单总表.GetRowCellValue(i, gridCol订单编号).ToString().Trim() + "' and 行号 = '" + gridView外销订单总表.GetRowCellValue(i, gridCol订单行号).ToString().Trim() + "'";
              
                        DataTable dtTemp = clsSQLCommond.ExecQuery(sSQL);
                        if (dtTemp != null && dtTemp.Rows.Count > 0)
                        {
                            s出货周 = "'" + dtTemp.Rows[0]["出货周"].ToString().Trim() + "'";
                        }
                        else
                        {
                            s出货周 = "null";
                        }
                    }

                    string s出货周2 = s出货周;
                    if (s出货周2 == "null")
                        s出货周2 = "9999-99";

                    sSQL = "update  UFDLImport.dbo.omplan set UFDLImport.dbo.omplan.Remark = " + s出货周2 + " " +
                            "where SoCode = '" + gridView外销订单总表.GetRowCellValue(i,gridCol订单编号).ToString().Trim() + "' and SoSeq = '" + gridView外销订单总表.GetRowCellValue(i,gridCol订单行号).ToString().Trim() + "'";
                    aList.Add(sSQL);

                    if (s出货周 != "null")
                    {
                        int i周 = ReturnObjectToInt(s出货周.Substring(6, 2));
                        if (i周 > 0)
                        {
                            sSQL = "update 生产计划 set 出货周 = '" + i周 + "' where 销售订单号 = '" + gridView外销订单总表.GetRowCellValue(i, gridCol订单编号).ToString().Trim() + "' and 销售订单行号 = '" + gridView外销订单总表.GetRowCellValue(i, gridCol订单行号).ToString().Trim() + "'";
                            aList.Add(sSQL);
                        }
                    }
                }
            }

            if (dt外销订单总表 != null && dt外销订单总表.Rows.Count > 0)
            {
                for (int i = 0; i < dt外销订单总表.Rows.Count; i++)
                {
                    if (dt外销订单总表.Rows[i]["编辑"] == "edit")
                    {
                        sSQL = clsGetSQL.GetUpdateSQL("XWSystemDB_DL", "外销订单总表", dt外销订单总表, i);
                        aList.Add(sSQL);
                    }
                    if (dt外销订单总表.Rows[i]["编辑"] == "add")
                    {
                        sSQL = clsGetSQL.GetInsertSQL("XWSystemDB_DL", "外销订单总表", dt外销订单总表, i);
                        aList.Add(sSQL);
                    }

                    sSQL = clsGetSQL.GetInsertSQL("XWSystemDB_DL", "外销订单总表记录", dt外销订单总表, i);
                    aList.Add(sSQL);



                    sSQL = @"
update  外销订单总表 set 备注 = '{0}' where 销售订单号 = '{1}' and 行号 = {2}
                    ";
                    sSQL = string.Format(sSQL, dt外销订单总表.Rows[i]["备注"].ToString().Trim(),dt外销订单总表.Rows[i]["销售订单号"].ToString().Trim() ,dt外销订单总表.Rows[i]["行号"].ToString().Trim());
                    aList.Add(sSQL);
                }
            }

            if (aList.Count > 0)
            {
                clsSQLCommond.ExecSqlTran(aList);
                MessageBox.Show("保存成功");
            }
        }

        /// <summary>
        /// 撤销
        /// </summary>
        private void btnUnDo()
        {

        }
        /// <summary>
        /// 审核
        /// </summary>
        private void btnAudit()
        {

        }
        /// <summary>
        /// 弃审
        /// </summary>
        private void btnUnAudit()
        {

        }
        /// <summary>
        /// 打开
        /// </summary>
        private void btnOpen()
        {
        }

        /// <summary>
        /// 关闭
        /// </summary>
        private void btnClose()
        {
            try
            {
                gridView外销订单总表.FocusedRowHandle -= 1;
                gridView外销订单总表.FocusedRowHandle += 1;
            }
            catch { }
            aList = new System.Collections.ArrayList();
            string sErr = "";
            string sInfo = "";
            for (int i = 0; i < gridView外销订单总表.RowCount; i++)
            {
                if (Convert.ToBoolean(gridView外销订单总表.GetRowCellValue(i, gridCol选择)))
                {
                    sSQL = "select count(1) from XWSystemDB_DL..外销订单总表 where 帐套号 = '200' and 销售订单号 = '222222' and 行号 = '333333' ";
                    sSQL = sSQL.Replace("222222", gridView外销订单总表.GetRowCellValue(i, gridCol订单编号).ToString().Trim());
                    sSQL = sSQL.Replace("333333", gridView外销订单总表.GetRowCellValue(i, gridCol订单行号).ToString().Trim());
                    sSQL = sSQL.Replace("200", FrameBaseFunction.ClsBaseDataInfo.sUFDataBaseName.Substring(7, 3));
                    int iCou = ReturnObjectToInt(clsSQLCommond.ExecGetScalar(sSQL));
                    if (iCou == 0)
                    {
                        sErr = sErr + gridView外销订单总表.GetRowCellValue(i, gridCol订单编号).ToString().Trim() + "-" + gridView外销订单总表.GetRowCellValue(i, gridCol订单行号).ToString().Trim() + "\n";
                    }
                    else
                    {
                        sSQL = "update  XWSystemDB_DL..外销订单总表 set 标记延期 = null where 帐套号 = '200' and 销售订单号 = '222222' and 行号 = '333333'";
                        sSQL = sSQL.Replace("222222", gridView外销订单总表.GetRowCellValue(i, gridCol订单编号).ToString().Trim());
                        sSQL = sSQL.Replace("333333", gridView外销订单总表.GetRowCellValue(i, gridCol订单行号).ToString().Trim());
                        sSQL = sSQL.Replace("200", FrameBaseFunction.ClsBaseDataInfo.sUFDataBaseName.Substring(7, 3));
                        aList.Add(sSQL);

                        sInfo = sInfo + gridView外销订单总表.GetRowCellValue(i, gridCol订单编号).ToString().Trim() + "-" + gridView外销订单总表.GetRowCellValue(i, gridCol订单行号).ToString().Trim() + "\n";
                    }
                }
            }
            if (aList.Count > 0)
            {
                clsSQLCommond.ExecSqlTran(aList);

                string s = "取消标记成功：\n" + sInfo + "\n\n";
                if (sErr.Length > 0)
                {
                    s = s + "以下外销订单尚未登记：\n" + sErr;
                }

                MsgBox("提示", s);
            }
            else
            {
                if (sErr.Length > 0)
                {
                    MsgBox("提示", "取消标记失败，以下外销订单尚未登记：\n" + sErr);
                }
            }
        }

        /// <summary>
        /// 变更
        /// </summary>
        private void btnAlter()
        {
            try
            {
                gridView外销订单总表.FocusedRowHandle -= 1;
                gridView外销订单总表.FocusedRowHandle += 1;
            }
            catch { }
            aList = new System.Collections.ArrayList();
            string sErr = "";
            string sInfo = "";
            for(int i=0;i<gridView外销订单总表.RowCount;i++)
            {
                if (Convert.ToBoolean(gridView外销订单总表.GetRowCellValue(i, gridCol选择)))
                {
                    sSQL = "select count(1) from XWSystemDB_DL..外销订单总表 where 帐套号 = '200' and 销售订单号 = '222222' and 行号 = '333333' "; 
                    sSQL = sSQL.Replace("222222", gridView外销订单总表.GetRowCellValue(i, gridCol订单编号).ToString().Trim());
                    sSQL = sSQL.Replace("333333", gridView外销订单总表.GetRowCellValue(i, gridCol订单行号).ToString().Trim());
                    sSQL = sSQL.Replace("200", FrameBaseFunction.ClsBaseDataInfo.sUFDataBaseName.Substring(7, 3));
                    int iCou = ReturnObjectToInt(clsSQLCommond.ExecGetScalar(sSQL));
                    if (iCou == 0)
                    {
                        sErr = sErr + gridView外销订单总表.GetRowCellValue(i, gridCol订单编号).ToString().Trim() + "-" + gridView外销订单总表.GetRowCellValue(i, gridCol订单行号).ToString().Trim() + "\n";
                    }
                    else
                    {
                        sSQL = "update  XWSystemDB_DL..外销订单总表 set 标记延期 = 1 where 帐套号 = '200' and 销售订单号 = '222222' and 行号 = '333333' ";
                        sSQL = sSQL.Replace("222222", gridView外销订单总表.GetRowCellValue(i, gridCol订单编号).ToString().Trim());
                        sSQL = sSQL.Replace("333333", gridView外销订单总表.GetRowCellValue(i, gridCol订单行号).ToString().Trim());
                        sSQL = sSQL.Replace("200", FrameBaseFunction.ClsBaseDataInfo.sUFDataBaseName.Substring(7, 3));
                        aList.Add(sSQL);

                        sInfo = sInfo + gridView外销订单总表.GetRowCellValue(i, gridCol订单编号).ToString().Trim() + "-" + gridView外销订单总表.GetRowCellValue(i, gridCol订单行号).ToString().Trim() + "\n";
                    }
                }
            }
            if (aList.Count > 0)
            {
                clsSQLCommond.ExecSqlTran(aList);

                string s = "标记成功：\n" + sInfo + "\n\n";
                if (sErr.Length > 0)
                {
                    s = s + "以下外销订单尚未登记：\n" + sErr;
                }

                MsgBox("提示", s);
            }
            else
            {
                if (sErr.Length > 0)
                {
                    MsgBox("提示", "标记失败，以下外销订单尚未登记：\n" + sErr);
                }
            }
        }

        #endregion

        DataTable dt产品工时 = null;
        DataTable dt工时统计 = null;

        private void Frm外销订单总表_Load(object sender, EventArgs e)
        {
            try
            {
                lookUpEdit年度.Text = Convert.ToDateTime(FrameBaseFunction.ClsBaseDataInfo.sLogDate).ToString("yyyy");

                SetCol();

                GetLookUp();

                dateEdit1.DateTime = Convert.ToDateTime(FrameBaseFunction.ClsBaseDataInfo.sLogDate).AddMonths(-6);
                dateEdit2.DateTime = DateTime.Today;

                sSQL = @"
select a.累计工时,a.产品编码 ,a.组别,c.cDepName
from
(
select  sum(isnull(单位工时,0) * isnull(数量,0)) as 累计工时,产品编码,组别
from [XWSystemDB_DL].[dbo].[ProProcess]
group by 产品编码,组别
) a left join _LookUpDate b on a.组别 = b.Remark and b.iType = 13
	left join @u8.Department c on b.iText = c.cDepCode
order by a.产品编码 ,a.累计工时,a.组别,c.cDepName
   ";

                dt产品工时 = clsSQLCommond.ExecQuery(sSQL);

                lookUpEdit年度.Enabled = true;
                lookUpEdit年度.Properties.ReadOnly = false;
            }
            catch (Exception ee)
            {
                MessageBox.Show("加载窗体失败\n" + ee.Message);
            }
        }

      
        private void gridView外销订单总表_CustomDrawRowIndicator(object sender, DevExpress.XtraGrid.Views.Grid.RowIndicatorCustomDrawEventArgs e)
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

        private void SetBandCatpion()
        {
            DateTime d周日期 = ReturnObjectToDatetime("1900-01-01");
            string sSQL = "select * from dbo._LookUpDate where iType = '16' and iID like '" + lookUpEdit年度.Text.Trim() + "01%'";
            DataTable dt = clsSQLCommond.ExecQuery(sSQL);
            if (dt != null && dt.Rows.Count > 0)
            {
                d周日期 = ReturnObjectToDatetime(dt.Rows[0]["iText"]);
            }

            for (int i = 1; i <= iCols; i++)
            {
                if (d周日期 != ReturnObjectToDatetime("1900-01-01"))
                {
                    string sCaption = d周日期.AddDays((i - 1) * 7).ToString("yyyy-MM-dd");

                    for (int j = 0; j < gridBand出货计划.Children.Count; j++)
                    {
                        if (gridBand出货计划.Children[j].Name == "gridBand周" + i.ToString())
                        {
                            gridBand出货计划.Children[j].Caption = sCaption;

                            gridBand出货计划.Children[j].AppearanceHeader.ForeColor = System.Drawing.Color.Red;
                            gridBand出货计划.Children[j].AppearanceHeader.Options.UseForeColor = true;
                            break;
                        }
                    }


                    for (int j = 0; j < gridBand出货登记.Children.Count; j++)
                    {
                        if (gridBand出货登记.Children[j].Name == "gridBand周2" + i.ToString())
                        {
                            gridBand出货登记.Children[j].Caption = sCaption;

                            gridBand出货登记.Children[j].AppearanceHeader.ForeColor = System.Drawing.Color.Blue;
                            gridBand出货登记.Children[j].AppearanceHeader.Options.UseForeColor = true;
                            break;
                        }
                    }

                    for (int j = 0; j < gridView工时.Bands.Count; j++)
                    {
                        if (gridView工时.Bands[j].Name == "gridBand周2" + i.ToString())
                        {
                            gridView工时.Bands[j].Caption = sCaption;
                            break;
                        }
                    }
                }
            }
        }

        private void SetCol()
        {
            DateTime d周日期 = ReturnObjectToDatetime("1900-01-01");
            string sSQL = "select * from dbo._LookUpDate where iType = '16' and iID like '" + lookUpEdit年度.Text.Trim() + "01%'";
            DataTable dt = clsSQLCommond.ExecQuery(sSQL);
            if (dt != null && dt.Rows.Count > 0)
            {
                d周日期 = ReturnObjectToDatetime(dt.Rows[0]["iText"]);
            }

            for (int i = 1; i <= iCols; i++)
            {
                DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn gridCol周 = new DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn();

                gridCol周.Caption = i.ToString() + "周";
                gridCol周.FieldName = i.ToString() + "周";
                gridCol周.Name = "gridCol" + i.ToString() + "周";
                gridCol周.Visible = true;
                gridView外销订单总表.Columns.AddRange(new DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn[] { gridCol周 });


                DevExpress.XtraGrid.Views.BandedGrid.GridBand gridBand周 = new DevExpress.XtraGrid.Views.BandedGrid.GridBand();
                gridBand出货计划.Children.AddRange(new DevExpress.XtraGrid.Views.BandedGrid.GridBand[] { gridBand周 });

                if (d周日期 != ReturnObjectToDatetime("1900-01-01"))
                {
                    gridBand周.Caption = d周日期.AddDays((i - 1) * 7).ToString("yyyy-MM-dd");
                }
                gridBand周.Name = "gridBand周" + i.ToString();
                gridBand周.Columns.Add(gridCol周);
                gridBand周.Width = 75;
            }

            for (int i = 1; i <= iCols; i++)
            {
                DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn gridCol周;
                gridCol周 = new DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn();

                gridCol周.Caption = i.ToString() + "周";
                gridCol周.FieldName = i.ToString() + "周2";
                gridCol周.Name = "gridCol" + i.ToString() + "周2";
                gridCol周.Visible = true;
                gridView外销订单总表.Columns.AddRange(new DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn[] { gridCol周 });


                DevExpress.XtraGrid.Views.BandedGrid.GridBand gridBand周 = new DevExpress.XtraGrid.Views.BandedGrid.GridBand();
                gridBand出货登记.Children.AddRange(new DevExpress.XtraGrid.Views.BandedGrid.GridBand[] { gridBand周 });

                if (d周日期 != ReturnObjectToDatetime("1900-01-01"))
                {
                    gridBand周.Caption = d周日期.AddDays((i - 1) * 7).ToString("yyyy-MM-dd");
                }
                gridBand周.Name = "gridBand周2" + i.ToString();
                gridBand周.Columns.Add(gridCol周);
                gridBand周.Width = 75;
            }


            for (int i = 1; i <= iCols; i++)
            {
                DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn gridCol周 = new DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn();

                gridCol周.Caption = i.ToString() + "周";
                gridCol周.FieldName = i.ToString() + "周工时";
                gridCol周.Name = "gridCol" + i.ToString() + "周工时";
                gridCol周.Visible = true;
                gridView工时.Columns.AddRange(new DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn[] { gridCol周 });
                gridCol周.SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Sum;
                

                DevExpress.XtraGrid.Views.BandedGrid.GridBand gridBand周 = new DevExpress.XtraGrid.Views.BandedGrid.GridBand();
                gridView工时.Bands.AddRange(new DevExpress.XtraGrid.Views.BandedGrid.GridBand[] { gridBand周});

                if (d周日期 != ReturnObjectToDatetime("1900-01-01"))
                {
                    gridBand周.Caption = d周日期.AddDays((i - 1) * 7).ToString("yyyy-MM-dd");
                }
                gridBand周.Name = "gridBand周2" + i.ToString();
                gridBand周.Columns.Add(gridCol周);
                gridBand周.Width = 75;
            }
        }

        private void GetLookUp()
        {
            string sSQL = "select rtrim(ltrim(iText)) as iText from _LookUpDate where iType = '14'";
            DataTable dt = clsSQLCommond.ExecQuery(sSQL);
            ItemLookUpEdit组别.DataSource = dt;

            sSQL = "select distinct LEFT(iID,4) as iYear from _LookUpDate where iType = 16";
            dt = clsSQLCommond.ExecQuery(sSQL);
            lookUpEdit年度.Properties.DataSource = dt;
            lookUpEdit年度.EditValue = DateTime.Today.Year;
        }

        private void gridView外销订单总表_CellValueChanged(object sender, DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs e)
        {
            if (e.Column != gridCol选择)
            {
                gridView外销订单总表.SetRowCellValue(e.RowHandle, gridCol选择, true);
            }

            if((e.Column.FieldName.Trim().Length > 1 &&e.Column.FieldName.Trim().Substring(e.Column.FieldName.Trim().Length-2) == "周2") || e.Column == gridCol其他年度发货总数)
            {
                decimal d出货 = 0;
                decimal d出货计划 = 0;
                for (int i = 0; i < gridView外销订单总表.Columns.Count; i++)
                {
                    string sColName = gridView外销订单总表.Columns[i].FieldName.Trim();
                    if (sColName.Length > 2 && sColName.Substring(sColName.Length - 2) == "周2")
                    {
                        d出货 = d出货 + ReturnObjectToDecimal(gridView外销订单总表.GetRowCellValue(e.RowHandle, gridView外销订单总表.Columns[i]), 2);
                    }
                }

                d出货 = d出货 + ReturnObjectToDecimal(gridView外销订单总表.GetRowCellValue(e.RowHandle, gridCol其他年度发货总数), 2);
                
                gridView外销订单总表.SetRowCellValue(e.RowHandle, gridCol已出货数量, d出货);

                decimal d订单数量 = ReturnObjectToDecimal(gridView外销订单总表.GetRowCellValue(e.RowHandle, gridCol订单数量), 2);
   
                decimal d未出货 = d订单数量 - d出货;
                gridView外销订单总表.SetRowCellValue(e.RowHandle, gridCol未出货数量, d未出货);
            }

            if ((e.Column == gridCol其他年度发货总数)
                    || ((e.Column.FieldName.Trim().Length > 1 && e.Column.FieldName.Trim().Substring(e.Column.FieldName.Trim().Length - 1) == "周") || e.Column == gridCol其他年度发货总数))
            {
                decimal d出货 = 0;
                decimal d出货计划 = 0;
                for (int i = 0; i < gridView外销订单总表.Columns.Count; i++)
                {
                    string sColName = gridView外销订单总表.Columns[i].FieldName.Trim();
                    if (sColName.Length > 2 && sColName.Substring(sColName.Length - 2) == "周2")
                    {
                        d出货 = d出货 + ReturnObjectToDecimal(gridView外销订单总表.GetRowCellValue(e.RowHandle, gridView外销订单总表.Columns[i]), 2);
                    }
                    if (sColName.Length > 1 && sColName.Substring(sColName.Length - 1) == "周")
                    {
                        d出货计划 = d出货计划 + ReturnObjectToDecimal(gridView外销订单总表.GetRowCellValue(e.RowHandle, gridView外销订单总表.Columns[i]), 2);
                    }

                }

                d出货 = d出货 + ReturnObjectToDecimal(gridView外销订单总表.GetRowCellValue(e.RowHandle, gridCol其他年度发货总数), 2);

                gridView外销订单总表.SetRowCellValue(e.RowHandle, gridCol已出货数量, d出货);

                decimal d订单数量 = ReturnObjectToDecimal(gridView外销订单总表.GetRowCellValue(e.RowHandle, gridCol订单数量), 2);
                decimal d其他年度出货计划 = ReturnObjectToDecimal(gridView外销订单总表.GetRowCellValue(e.RowHandle, gridCol其他年度出货计划总数), 2);
                decimal d出货余量 = d订单数量 - d出货计划 - d其他年度出货计划;
                gridView外销订单总表.SetRowCellValue(e.RowHandle, gridCol计划余量, d出货余量);
            }

            if (e.Column == gridCol订单交期回复)
            {
                DateTime d1 = Convert.ToDateTime(gridView外销订单总表.GetRowCellValue(e.RowHandle, gridCol订单交期回复));
                DateTime d2 = Convert.ToDateTime(gridView外销订单总表.GetRowCellValue(e.RowHandle, gridCol客户要求船期));

                TimeSpan ts = d2 - d1;
                gridView外销订单总表.SetRowCellValue(e.RowHandle, gridCol延期天数, ts.Days);
            }
        }

        private void Get工时()
        {
            ArrayList aList = new ArrayList();
            sSQL = "delete 外销订单总表班组工时统计临时表";
            aList.Add(sSQL);

            sSQL = @"
insert into 外销订单总表班组工时统计临时表
select  rtrim(ltrim(h.iText)) as 组别
	,cast(sum(case when ISNULL(e.[1周],0) * ISNULL(f.累计工时,0) <> 0 then ISNULL(e.[1周],0) * ISNULL(f.累计工时,0) end) as decimal(18,2)) as [1周工时]
	,cast(sum(case when ISNULL(e.[2周],0) * ISNULL(f.累计工时,0) <> 0 then ISNULL(e.[2周],0) * ISNULL(f.累计工时,0) end) as decimal(18,2)) as [2周工时]
	,cast(sum(case when ISNULL(e.[3周],0) * ISNULL(f.累计工时,0) <> 0 then ISNULL(e.[3周],0) * ISNULL(f.累计工时,0) end) as decimal(18,2)) as [3周工时]
	,cast(sum(case when ISNULL(e.[4周],0) * ISNULL(f.累计工时,0) <> 0 then ISNULL(e.[4周],0) * ISNULL(f.累计工时,0) end) as decimal(18,2)) as [4周工时]
	,cast(sum(case when ISNULL(e.[5周],0) * ISNULL(f.累计工时,0) <> 0 then ISNULL(e.[5周],0) * ISNULL(f.累计工时,0) end) as decimal(18,2)) as [5周工时]
	,cast(sum(case when ISNULL(e.[6周],0) * ISNULL(f.累计工时,0) <> 0 then ISNULL(e.[6周],0) * ISNULL(f.累计工时,0) end) as decimal(18,2)) as [6周工时]
	,cast(sum(case when ISNULL(e.[7周],0) * ISNULL(f.累计工时,0) <> 0 then ISNULL(e.[7周],0) * ISNULL(f.累计工时,0) end) as decimal(18,2)) as [7周工时]
	,cast(sum(case when ISNULL(e.[8周],0) * ISNULL(f.累计工时,0) <> 0 then ISNULL(e.[8周],0) * ISNULL(f.累计工时,0) end) as decimal(18,2)) as [8周工时]
	,cast(sum(case when ISNULL(e.[9周],0) * ISNULL(f.累计工时,0) <> 0 then ISNULL(e.[9周],0) * ISNULL(f.累计工时,0) end) as decimal(18,2)) as [9周工时]
	,cast(sum(case when ISNULL(e.[10周],0) * ISNULL(f.累计工时,0) <> 0 then ISNULL(e.[10周],0) * ISNULL(f.累计工时,0) end) as decimal(18,2)) as [10周工时]
	,cast(sum(case when ISNULL(e.[11周],0) * ISNULL(f.累计工时,0) <> 0 then ISNULL(e.[11周],0) * ISNULL(f.累计工时,0) end) as decimal(18,2)) as [11周工时]
	,cast(sum(case when ISNULL(e.[12周],0) * ISNULL(f.累计工时,0) <> 0 then ISNULL(e.[12周],0) * ISNULL(f.累计工时,0) end) as decimal(18,2)) as [12周工时]
	,cast(sum(case when ISNULL(e.[13周],0) * ISNULL(f.累计工时,0) <> 0 then ISNULL(e.[13周],0) * ISNULL(f.累计工时,0) end) as decimal(18,2)) as [13周工时]
	,cast(sum(case when ISNULL(e.[14周],0) * ISNULL(f.累计工时,0) <> 0 then ISNULL(e.[14周],0) * ISNULL(f.累计工时,0) end) as decimal(18,2)) as [14周工时]
	,cast(sum(case when ISNULL(e.[15周],0) * ISNULL(f.累计工时,0) <> 0 then ISNULL(e.[15周],0) * ISNULL(f.累计工时,0) end) as decimal(18,2)) as [15周工时]
	,cast(sum(case when ISNULL(e.[16周],0) * ISNULL(f.累计工时,0) <> 0 then ISNULL(e.[16周],0) * ISNULL(f.累计工时,0) end) as decimal(18,2)) as [16周工时]
	,cast(sum(case when ISNULL(e.[17周],0) * ISNULL(f.累计工时,0) <> 0 then ISNULL(e.[17周],0) * ISNULL(f.累计工时,0) end) as decimal(18,2)) as [17周工时]
	,cast(sum(case when ISNULL(e.[18周],0) * ISNULL(f.累计工时,0) <> 0 then ISNULL(e.[18周],0) * ISNULL(f.累计工时,0) end) as decimal(18,2)) as [18周工时]
	,cast(sum(case when ISNULL(e.[19周],0) * ISNULL(f.累计工时,0) <> 0 then ISNULL(e.[19周],0) * ISNULL(f.累计工时,0) end) as decimal(18,2)) as [19周工时]
	,cast(sum(case when ISNULL(e.[20周],0) * ISNULL(f.累计工时,0) <> 0 then ISNULL(e.[20周],0) * ISNULL(f.累计工时,0) end) as decimal(18,2)) as [20周工时]
	,cast(sum(case when ISNULL(e.[21周],0) * ISNULL(f.累计工时,0) <> 0 then ISNULL(e.[21周],0) * ISNULL(f.累计工时,0) end) as decimal(18,2)) as [21周工时]
	,cast(sum(case when ISNULL(e.[22周],0) * ISNULL(f.累计工时,0) <> 0 then ISNULL(e.[22周],0) * ISNULL(f.累计工时,0) end) as decimal(18,2)) as [22周工时]
	,cast(sum(case when ISNULL(e.[23周],0) * ISNULL(f.累计工时,0) <> 0 then ISNULL(e.[23周],0) * ISNULL(f.累计工时,0) end) as decimal(18,2)) as [23周工时]
	,cast(sum(case when ISNULL(e.[24周],0) * ISNULL(f.累计工时,0) <> 0 then ISNULL(e.[24周],0) * ISNULL(f.累计工时,0) end) as decimal(18,2)) as [24周工时]
	,cast(sum(case when ISNULL(e.[25周],0) * ISNULL(f.累计工时,0) <> 0 then ISNULL(e.[25周],0) * ISNULL(f.累计工时,0) end) as decimal(18,2)) as [25周工时]
	,cast(sum(case when ISNULL(e.[26周],0) * ISNULL(f.累计工时,0) <> 0 then ISNULL(e.[26周],0) * ISNULL(f.累计工时,0) end) as decimal(18,2)) as [26周工时]
	,cast(sum(case when ISNULL(e.[27周],0) * ISNULL(f.累计工时,0) <> 0 then ISNULL(e.[27周],0) * ISNULL(f.累计工时,0) end) as decimal(18,2)) as [27周工时]
	,cast(sum(case when ISNULL(e.[28周],0) * ISNULL(f.累计工时,0) <> 0 then ISNULL(e.[28周],0) * ISNULL(f.累计工时,0) end) as decimal(18,2)) as [28周工时]
	,cast(sum(case when ISNULL(e.[29周],0) * ISNULL(f.累计工时,0) <> 0 then ISNULL(e.[29周],0) * ISNULL(f.累计工时,0) end) as decimal(18,2)) as [29周工时]
	,cast(sum(case when ISNULL(e.[30周],0) * ISNULL(f.累计工时,0) <> 0 then ISNULL(e.[30周],0) * ISNULL(f.累计工时,0) end) as decimal(18,2)) as [30周工时]
	,cast(sum(case when ISNULL(e.[31周],0) * ISNULL(f.累计工时,0) <> 0 then ISNULL(e.[31周],0) * ISNULL(f.累计工时,0) end) as decimal(18,2)) as [31周工时]
	,cast(sum(case when ISNULL(e.[32周],0) * ISNULL(f.累计工时,0) <> 0 then ISNULL(e.[32周],0) * ISNULL(f.累计工时,0) end) as decimal(18,2)) as [32周工时]
	,cast(sum(case when ISNULL(e.[33周],0) * ISNULL(f.累计工时,0) <> 0 then ISNULL(e.[33周],0) * ISNULL(f.累计工时,0) end) as decimal(18,2)) as [33周工时]
	,cast(sum(case when ISNULL(e.[34周],0) * ISNULL(f.累计工时,0) <> 0 then ISNULL(e.[34周],0) * ISNULL(f.累计工时,0) end) as decimal(18,2)) as [34周工时]
	,cast(sum(case when ISNULL(e.[35周],0) * ISNULL(f.累计工时,0) <> 0 then ISNULL(e.[35周],0) * ISNULL(f.累计工时,0) end) as decimal(18,2)) as [35周工时]
	,cast(sum(case when ISNULL(e.[36周],0) * ISNULL(f.累计工时,0) <> 0 then ISNULL(e.[36周],0) * ISNULL(f.累计工时,0) end) as decimal(18,2)) as [36周工时]
	,cast(sum(case when ISNULL(e.[37周],0) * ISNULL(f.累计工时,0) <> 0 then ISNULL(e.[37周],0) * ISNULL(f.累计工时,0) end) as decimal(18,2)) as [37周工时]
	,cast(sum(case when ISNULL(e.[38周],0) * ISNULL(f.累计工时,0) <> 0 then ISNULL(e.[38周],0) * ISNULL(f.累计工时,0) end) as decimal(18,2)) as [38周工时]
	,cast(sum(case when ISNULL(e.[39周],0) * ISNULL(f.累计工时,0) <> 0 then ISNULL(e.[39周],0) * ISNULL(f.累计工时,0) end) as decimal(18,2)) as [39周工时]
	,cast(sum(case when ISNULL(e.[40周],0) * ISNULL(f.累计工时,0) <> 0 then ISNULL(e.[40周],0) * ISNULL(f.累计工时,0) end) as decimal(18,2)) as [40周工时]
	,cast(sum(case when ISNULL(e.[41周],0) * ISNULL(f.累计工时,0) <> 0 then ISNULL(e.[41周],0) * ISNULL(f.累计工时,0) end) as decimal(18,2)) as [41周工时]
	,cast(sum(case when ISNULL(e.[42周],0) * ISNULL(f.累计工时,0) <> 0 then ISNULL(e.[42周],0) * ISNULL(f.累计工时,0) end) as decimal(18,2)) as [42周工时]
	,cast(sum(case when ISNULL(e.[43周],0) * ISNULL(f.累计工时,0) <> 0 then ISNULL(e.[43周],0) * ISNULL(f.累计工时,0) end) as decimal(18,2)) as [43周工时]
	,cast(sum(case when ISNULL(e.[44周],0) * ISNULL(f.累计工时,0) <> 0 then ISNULL(e.[44周],0) * ISNULL(f.累计工时,0) end) as decimal(18,2)) as [44周工时]
	,cast(sum(case when ISNULL(e.[45周],0) * ISNULL(f.累计工时,0) <> 0 then ISNULL(e.[45周],0) * ISNULL(f.累计工时,0) end) as decimal(18,2)) as [45周工时]
	,cast(sum(case when ISNULL(e.[46周],0) * ISNULL(f.累计工时,0) <> 0 then ISNULL(e.[46周],0) * ISNULL(f.累计工时,0) end) as decimal(18,2)) as [46周工时]
	,cast(sum(case when ISNULL(e.[47周],0) * ISNULL(f.累计工时,0) <> 0 then ISNULL(e.[47周],0) * ISNULL(f.累计工时,0) end) as decimal(18,2)) as [47周工时]
	,cast(sum(case when ISNULL(e.[48周],0) * ISNULL(f.累计工时,0) <> 0 then ISNULL(e.[48周],0) * ISNULL(f.累计工时,0) end) as decimal(18,2)) as [48周工时]
	,cast(sum(case when ISNULL(e.[49周],0) * ISNULL(f.累计工时,0) <> 0 then ISNULL(e.[49周],0) * ISNULL(f.累计工时,0) end) as decimal(18,2)) as [49周工时]
	,cast(sum(case when ISNULL(e.[50周],0) * ISNULL(f.累计工时,0) <> 0 then ISNULL(e.[50周],0) * ISNULL(f.累计工时,0) end) as decimal(18,2)) as [50周工时]
	,cast(sum(case when ISNULL(e.[51周],0) * ISNULL(f.累计工时,0) <> 0 then ISNULL(e.[51周],0) * ISNULL(f.累计工时,0) end) as decimal(18,2)) as [51周工时]
	,cast(sum(case when ISNULL(e.[52周],0) * ISNULL(f.累计工时,0) <> 0 then ISNULL(e.[52周],0) * ISNULL(f.累计工时,0) end) as decimal(18,2)) as [52周工时]
	,cast(sum(case when ISNULL(e.[53周],0) * ISNULL(f.累计工时,0) <> 0 then ISNULL(e.[53周],0) * ISNULL(f.累计工时,0) end) as decimal(18,2)) as [53周工时]
from @u8.so_somain a inner join @u8.so_sodetails b on a.id = b.id
	inner join @u8.inventory c on b.cinvcode = c.cinvcode 
	inner join @u8.ComputationUnit d on d.cComunitCode = c.cComUnitCode
	inner join XWSystemDB_DL..外销订单总表 e on a.cSoCode = e.销售订单号 and b.iRowNo = e.行号 and e.帐套号 = '200' and e.年度 = '33333333'
	inner join @u8.产品班组工时 f on f.产品编码 = b.cInvCode
    inner join _LookUpDate h on h.iID = f.cDepName and h.iType = 15
where 1=1 and a.dDate >= '11111111' and a.dDate < '22222222' and (rtrim(ltrim(h.iText)) = '铝件' or rtrim(ltrim(h.iText)) = '组装')
group by h.iText

";
            sSQL = sSQL.Replace("11111111", dateEdit1.DateTime.ToString("yyyy-MM-dd"));
            sSQL = sSQL.Replace("22222222", dateEdit2.DateTime.ToString("yyyy-MM-dd"));
            sSQL = sSQL.Replace("33333333", lookUpEdit年度.Text.Trim());
            sSQL = sSQL.Replace("44444444", Convert.ToDateTime(lookUpEdit年度.Text.Trim() + "-01-01").AddYears(1).ToString("yyyy"));
            sSQL = sSQL.Replace("55555555", Convert.ToDateTime(lookUpEdit年度.Text.Trim() + "-01-01").AddYears(-1).ToString("yyyy"));
            sSQL = sSQL.Replace("200", FrameBaseFunction.ClsBaseDataInfo.sUFDataBaseName.Substring(7, 3));
            aList.Add(sSQL);

            sSQL = @"
insert into 外销订单总表班组工时统计临时表
select  rtrim(ltrim(h.iText)) as 组别
	,cast(sum(case when ISNULL(e.[2周],0) * ISNULL(f.累计工时,0) <> 0 then ISNULL(e.[2周],0) * ISNULL(f.累计工时,0) end) as decimal(18,2)) as [1周工时]
	,cast(sum(case when ISNULL(e.[3周],0) * ISNULL(f.累计工时,0) <> 0 then ISNULL(e.[3周],0) * ISNULL(f.累计工时,0) end) as decimal(18,2)) as [2周工时]
	,cast(sum(case when ISNULL(e.[4周],0) * ISNULL(f.累计工时,0) <> 0 then ISNULL(e.[4周],0) * ISNULL(f.累计工时,0) end) as decimal(18,2)) as [3周工时]
	,cast(sum(case when ISNULL(e.[5周],0) * ISNULL(f.累计工时,0) <> 0 then ISNULL(e.[5周],0) * ISNULL(f.累计工时,0) end) as decimal(18,2)) as [4周工时]
	,cast(sum(case when ISNULL(e.[6周],0) * ISNULL(f.累计工时,0) <> 0 then ISNULL(e.[6周],0) * ISNULL(f.累计工时,0) end) as decimal(18,2)) as [5周工时]
	,cast(sum(case when ISNULL(e.[7周],0) * ISNULL(f.累计工时,0) <> 0 then ISNULL(e.[7周],0) * ISNULL(f.累计工时,0) end) as decimal(18,2)) as [6周工时]
	,cast(sum(case when ISNULL(e.[8周],0) * ISNULL(f.累计工时,0) <> 0 then ISNULL(e.[8周],0) * ISNULL(f.累计工时,0) end) as decimal(18,2)) as [7周工时]
	,cast(sum(case when ISNULL(e.[9周],0) * ISNULL(f.累计工时,0) <> 0 then ISNULL(e.[9周],0) * ISNULL(f.累计工时,0) end) as decimal(18,2)) as [8周工时]
	,cast(sum(case when ISNULL(e.[10周],0) * ISNULL(f.累计工时,0) <> 0 then ISNULL(e.[10周],0) * ISNULL(f.累计工时,0) end) as decimal(18,2)) as [9周工时]
	,cast(sum(case when ISNULL(e.[11周],0) * ISNULL(f.累计工时,0) <> 0 then ISNULL(e.[11周],0) * ISNULL(f.累计工时,0) end) as decimal(18,2)) as [10周工时]
	,cast(sum(case when ISNULL(e.[12周],0) * ISNULL(f.累计工时,0) <> 0 then ISNULL(e.[12周],0) * ISNULL(f.累计工时,0) end) as decimal(18,2)) as [11周工时]
	,cast(sum(case when ISNULL(e.[13周],0) * ISNULL(f.累计工时,0) <> 0 then ISNULL(e.[13周],0) * ISNULL(f.累计工时,0) end) as decimal(18,2)) as [12周工时]
	,cast(sum(case when ISNULL(e.[14周],0) * ISNULL(f.累计工时,0) <> 0 then ISNULL(e.[14周],0) * ISNULL(f.累计工时,0) end) as decimal(18,2)) as [13周工时]
	,cast(sum(case when ISNULL(e.[15周],0) * ISNULL(f.累计工时,0) <> 0 then ISNULL(e.[15周],0) * ISNULL(f.累计工时,0) end) as decimal(18,2)) as [14周工时]
	,cast(sum(case when ISNULL(e.[16周],0) * ISNULL(f.累计工时,0) <> 0 then ISNULL(e.[16周],0) * ISNULL(f.累计工时,0) end) as decimal(18,2)) as [15周工时]
	,cast(sum(case when ISNULL(e.[17周],0) * ISNULL(f.累计工时,0) <> 0 then ISNULL(e.[17周],0) * ISNULL(f.累计工时,0) end) as decimal(18,2)) as [16周工时]
	,cast(sum(case when ISNULL(e.[18周],0) * ISNULL(f.累计工时,0) <> 0 then ISNULL(e.[18周],0) * ISNULL(f.累计工时,0) end) as decimal(18,2)) as [17周工时]
	,cast(sum(case when ISNULL(e.[19周],0) * ISNULL(f.累计工时,0) <> 0 then ISNULL(e.[19周],0) * ISNULL(f.累计工时,0) end) as decimal(18,2)) as [18周工时]
	,cast(sum(case when ISNULL(e.[20周],0) * ISNULL(f.累计工时,0) <> 0 then ISNULL(e.[20周],0) * ISNULL(f.累计工时,0) end) as decimal(18,2)) as [19周工时]
	,cast(sum(case when ISNULL(e.[21周],0) * ISNULL(f.累计工时,0) <> 0 then ISNULL(e.[21周],0) * ISNULL(f.累计工时,0) end) as decimal(18,2)) as [20周工时]
	,cast(sum(case when ISNULL(e.[22周],0) * ISNULL(f.累计工时,0) <> 0 then ISNULL(e.[22周],0) * ISNULL(f.累计工时,0) end) as decimal(18,2)) as [21周工时]
	,cast(sum(case when ISNULL(e.[23周],0) * ISNULL(f.累计工时,0) <> 0 then ISNULL(e.[23周],0) * ISNULL(f.累计工时,0) end) as decimal(18,2)) as [22周工时]
	,cast(sum(case when ISNULL(e.[24周],0) * ISNULL(f.累计工时,0) <> 0 then ISNULL(e.[24周],0) * ISNULL(f.累计工时,0) end) as decimal(18,2)) as [23周工时]
	,cast(sum(case when ISNULL(e.[25周],0) * ISNULL(f.累计工时,0) <> 0 then ISNULL(e.[25周],0) * ISNULL(f.累计工时,0) end) as decimal(18,2)) as [24周工时]
	,cast(sum(case when ISNULL(e.[26周],0) * ISNULL(f.累计工时,0) <> 0 then ISNULL(e.[26周],0) * ISNULL(f.累计工时,0) end) as decimal(18,2)) as [25周工时]
	,cast(sum(case when ISNULL(e.[27周],0) * ISNULL(f.累计工时,0) <> 0 then ISNULL(e.[27周],0) * ISNULL(f.累计工时,0) end) as decimal(18,2)) as [26周工时]
	,cast(sum(case when ISNULL(e.[28周],0) * ISNULL(f.累计工时,0) <> 0 then ISNULL(e.[28周],0) * ISNULL(f.累计工时,0) end) as decimal(18,2)) as [27周工时]
	,cast(sum(case when ISNULL(e.[29周],0) * ISNULL(f.累计工时,0) <> 0 then ISNULL(e.[29周],0) * ISNULL(f.累计工时,0) end) as decimal(18,2)) as [28周工时]
	,cast(sum(case when ISNULL(e.[30周],0) * ISNULL(f.累计工时,0) <> 0 then ISNULL(e.[30周],0) * ISNULL(f.累计工时,0) end) as decimal(18,2)) as [29周工时]
	,cast(sum(case when ISNULL(e.[31周],0) * ISNULL(f.累计工时,0) <> 0 then ISNULL(e.[31周],0) * ISNULL(f.累计工时,0) end) as decimal(18,2)) as [30周工时]
	,cast(sum(case when ISNULL(e.[32周],0) * ISNULL(f.累计工时,0) <> 0 then ISNULL(e.[32周],0) * ISNULL(f.累计工时,0) end) as decimal(18,2)) as [31周工时]
	,cast(sum(case when ISNULL(e.[33周],0) * ISNULL(f.累计工时,0) <> 0 then ISNULL(e.[33周],0) * ISNULL(f.累计工时,0) end) as decimal(18,2)) as [32周工时]
	,cast(sum(case when ISNULL(e.[34周],0) * ISNULL(f.累计工时,0) <> 0 then ISNULL(e.[34周],0) * ISNULL(f.累计工时,0) end) as decimal(18,2)) as [33周工时]
	,cast(sum(case when ISNULL(e.[35周],0) * ISNULL(f.累计工时,0) <> 0 then ISNULL(e.[35周],0) * ISNULL(f.累计工时,0) end) as decimal(18,2)) as [34周工时]
	,cast(sum(case when ISNULL(e.[36周],0) * ISNULL(f.累计工时,0) <> 0 then ISNULL(e.[36周],0) * ISNULL(f.累计工时,0) end) as decimal(18,2)) as [35周工时]
	,cast(sum(case when ISNULL(e.[37周],0) * ISNULL(f.累计工时,0) <> 0 then ISNULL(e.[37周],0) * ISNULL(f.累计工时,0) end) as decimal(18,2)) as [36周工时]
	,cast(sum(case when ISNULL(e.[38周],0) * ISNULL(f.累计工时,0) <> 0 then ISNULL(e.[38周],0) * ISNULL(f.累计工时,0) end) as decimal(18,2)) as [37周工时]
	,cast(sum(case when ISNULL(e.[39周],0) * ISNULL(f.累计工时,0) <> 0 then ISNULL(e.[39周],0) * ISNULL(f.累计工时,0) end) as decimal(18,2)) as [38周工时]
	,cast(sum(case when ISNULL(e.[40周],0) * ISNULL(f.累计工时,0) <> 0 then ISNULL(e.[40周],0) * ISNULL(f.累计工时,0) end) as decimal(18,2)) as [39周工时]
	,cast(sum(case when ISNULL(e.[41周],0) * ISNULL(f.累计工时,0) <> 0 then ISNULL(e.[41周],0) * ISNULL(f.累计工时,0) end) as decimal(18,2)) as [40周工时]
	,cast(sum(case when ISNULL(e.[42周],0) * ISNULL(f.累计工时,0) <> 0 then ISNULL(e.[42周],0) * ISNULL(f.累计工时,0) end) as decimal(18,2)) as [41周工时]
	,cast(sum(case when ISNULL(e.[43周],0) * ISNULL(f.累计工时,0) <> 0 then ISNULL(e.[43周],0) * ISNULL(f.累计工时,0) end) as decimal(18,2)) as [42周工时]
	,cast(sum(case when ISNULL(e.[44周],0) * ISNULL(f.累计工时,0) <> 0 then ISNULL(e.[44周],0) * ISNULL(f.累计工时,0) end) as decimal(18,2)) as [43周工时]
	,cast(sum(case when ISNULL(e.[45周],0) * ISNULL(f.累计工时,0) <> 0 then ISNULL(e.[45周],0) * ISNULL(f.累计工时,0) end) as decimal(18,2)) as [44周工时]
	,cast(sum(case when ISNULL(e.[46周],0) * ISNULL(f.累计工时,0) <> 0 then ISNULL(e.[46周],0) * ISNULL(f.累计工时,0) end) as decimal(18,2)) as [45周工时]
	,cast(sum(case when ISNULL(e.[47周],0) * ISNULL(f.累计工时,0) <> 0 then ISNULL(e.[47周],0) * ISNULL(f.累计工时,0) end) as decimal(18,2)) as [46周工时]
	,cast(sum(case when ISNULL(e.[48周],0) * ISNULL(f.累计工时,0) <> 0 then ISNULL(e.[48周],0) * ISNULL(f.累计工时,0) end) as decimal(18,2)) as [47周工时]
	,cast(sum(case when ISNULL(e.[49周],0) * ISNULL(f.累计工时,0) <> 0 then ISNULL(e.[49周],0) * ISNULL(f.累计工时,0) end) as decimal(18,2)) as [48周工时]
	,cast(sum(case when ISNULL(e.[50周],0) * ISNULL(f.累计工时,0) <> 0 then ISNULL(e.[50周],0) * ISNULL(f.累计工时,0) end) as decimal(18,2)) as [49周工时]
	,cast(sum(case when ISNULL(e.[51周],0) * ISNULL(f.累计工时,0) <> 0 then ISNULL(e.[51周],0) * ISNULL(f.累计工时,0) end) as decimal(18,2)) as [50周工时]
	,cast(sum(case when ISNULL(e.[52周],0) * ISNULL(f.累计工时,0) <> 0 then ISNULL(e.[52周],0) * ISNULL(f.累计工时,0) end) as decimal(18,2)) as [51周工时]
	,cast(sum(case when ISNULL(e.[53周],0) * ISNULL(f.累计工时,0) <> 0 then ISNULL(e.[53周],0) * ISNULL(f.累计工时,0) end) as decimal(18,2)) as [52周工时]
	,null as [53周工时]
from @u8.so_somain a inner join @u8.so_sodetails b on a.id = b.id
	inner join @u8.inventory c on b.cinvcode = c.cinvcode 
	inner join @u8.ComputationUnit d on d.cComunitCode = c.cComUnitCode
	inner join XWSystemDB_DL..外销订单总表 e on a.cSoCode = e.销售订单号 and b.iRowNo = e.行号 and e.帐套号 = '200' and e.年度 = '33333333'
	inner join @u8.产品班组工时 f on f.产品编码 = b.cInvCode
    inner join _LookUpDate h on h.iID = f.cDepName and h.iType = 15
where 1=1 and a.dDate >= '11111111' and a.dDate < '22222222' and ( rtrim(ltrim(h.iText)) = '冲压' or rtrim(ltrim(h.iText)) = '电焊' or isnull(h.iText,'') = '')
group by h.iText

";
            sSQL = sSQL.Replace("11111111", dateEdit1.DateTime.ToString("yyyy-MM-dd"));
            sSQL = sSQL.Replace("22222222", dateEdit2.DateTime.ToString("yyyy-MM-dd"));
            sSQL = sSQL.Replace("33333333", lookUpEdit年度.Text.Trim());
            sSQL = sSQL.Replace("44444444", Convert.ToDateTime(lookUpEdit年度.Text.Trim() + "-01-01").AddYears(1).ToString("yyyy"));
            sSQL = sSQL.Replace("55555555", Convert.ToDateTime(lookUpEdit年度.Text.Trim() + "-01-01").AddYears(-1).ToString("yyyy"));
            sSQL = sSQL.Replace("200", FrameBaseFunction.ClsBaseDataInfo.sUFDataBaseName.Substring(7, 3));
            aList.Add(sSQL);

            sSQL = @"
insert into 外销订单总表班组工时统计临时表
select  rtrim(ltrim(h.iText)) as 组别
	,null as [1周工时]
	,null as [2周工时]
	,null as [3周工时]
	,null as [4周工时]
	,null as [5周工时]
	,null as [6周工时]
	,null as [7周工时]
	,null as [8周工时]
	,null as [9周工时]
	,null as [10周工时]
	,null as [11周工时]
	,null as [12周工时]
	,null as [13周工时]
	,null as [14周工时]
	,null as [15周工时]
	,null as [16周工时]
	,null as [17周工时]
	,null as [18周工时]
	,null as [19周工时]
	,null as [20周工时]
	,null as [21周工时]
	,null as [22周工时]
	,null as [23周工时]
	,null as [24周工时]
	,null as [25周工时]
	,null as [26周工时]
	,null as [27周工时]
	,null as [28周工时]
	,null as [29周工时]
	,null as [30周工时]
	,null as [31周工时]
	,null as [32周工时]
	,null as [33周工时]
	,null as [34周工时]
	,null as [35周工时]
	,null as [36周工时]
	,null as [37周工时]
	,null as [38周工时]
	,null as [39周工时]
	,null as [40周工时]
	,null as [41周工时]
	,null as [42周工时]
	,null as [43周工时]
	,null as [44周工时]
	,null as [45周工时]
	,null as [46周工时]
	,null as [47周工时]
	,null as [48周工时]
	,null as [49周工时]
	,null as [50周工时]
	,null as [51周工时]
	,null as [52周工时]
	,cast(sum(case when ISNULL(e.[1周],0) * ISNULL(f.累计工时,0) <> 0 then ISNULL(e.[48周],0) * ISNULL(f.累计工时,0) end) as decimal(18,2)) as [53周工时]
from @u8.so_somain a inner join @u8.so_sodetails b on a.id = b.id
	inner join @u8.inventory c on b.cinvcode = c.cinvcode 
	inner join @u8.ComputationUnit d on d.cComunitCode = c.cComUnitCode
	inner join XWSystemDB_DL..外销订单总表 e on a.cSoCode = e.销售订单号 and b.iRowNo = e.行号  and e.帐套号 = '200' and e.年度 = '44444444'
	inner join @u8.产品班组工时 f on f.产品编码 = b.cInvCode
    inner join _LookUpDate h on h.iID = f.cDepName and h.iType = 15
where 1=1 and a.dDate >= '11111111' and a.dDate < '22222222' and ( rtrim(ltrim(h.iText)) = '冲压' or rtrim(ltrim(h.iText)) = '电焊' or isnull(h.iText,'') = '')
group by h.iText
";
            sSQL = sSQL.Replace("11111111", dateEdit1.DateTime.ToString("yyyy-MM-dd"));
            sSQL = sSQL.Replace("22222222", dateEdit2.DateTime.ToString("yyyy-MM-dd"));
            sSQL = sSQL.Replace("33333333", lookUpEdit年度.Text.Trim());
            sSQL = sSQL.Replace("44444444", Convert.ToDateTime(lookUpEdit年度.Text.Trim() + "-01-01").AddYears(1).ToString("yyyy"));
            sSQL = sSQL.Replace("55555555", Convert.ToDateTime(lookUpEdit年度.Text.Trim() + "-01-01").AddYears(-1).ToString("yyyy"));
            sSQL = sSQL.Replace("200", FrameBaseFunction.ClsBaseDataInfo.sUFDataBaseName.Substring(7, 3));
            aList.Add(sSQL);

            int iCou = clsSQLCommond.ExecSqlTran(aList);
            if (iCou > 0)
            {
                sSQL = @"
select  
    组别
	,sum( [1周工时]) as [1周工时]
	,sum( [2周工时]) as [2周工时]
	,sum( [3周工时]) as [3周工时]
	,sum( [4周工时]) as [4周工时]
	,sum( [5周工时]) as [5周工时]
	,sum( [6周工时]) as [6周工时]
	,sum( [7周工时]) as [7周工时]
	,sum( [8周工时]) as [8周工时]
	,sum( [9周工时]) as [9周工时]
	,sum( [10周工时]) as [10周工时]
	,sum( [11周工时]) as [11周工时]
	,sum( [12周工时]) as [12周工时]
	,sum( [13周工时]) as [13周工时]
	,sum( [14周工时]) as [14周工时]
	,sum( [15周工时]) as [15周工时]
	,sum( [16周工时]) as [16周工时]
	,sum( [17周工时]) as [17周工时]
	,sum( [18周工时]) as [18周工时]
	,sum( [19周工时]) as [19周工时]
	,sum( [20周工时]) as [20周工时]
	,sum( [21周工时]) as [21周工时]
	,sum( [22周工时]) as [22周工时]
	,sum( [23周工时]) as [23周工时]
	,sum( [24周工时]) as [24周工时]
	,sum( [25周工时]) as [25周工时]
	,sum( [26周工时]) as [26周工时]
	,sum( [27周工时]) as [27周工时]
	,sum( [28周工时]) as [28周工时]
	,sum( [29周工时]) as [29周工时]
	,sum( [30周工时]) as [30周工时]
	,sum( [31周工时]) as [31周工时]
	,sum( [32周工时]) as [32周工时]
	,sum( [33周工时]) as [33周工时]
	,sum( [34周工时]) as [34周工时]
	,sum( [35周工时]) as [35周工时]
	,sum( [36周工时]) as [36周工时]
	,sum( [37周工时]) as [37周工时]
	,sum( [38周工时]) as [38周工时]
	,sum( [39周工时]) as [39周工时]
	,sum( [40周工时]) as [40周工时]
	,sum( [41周工时]) as [41周工时]
	,sum( [42周工时]) as [42周工时]
	,sum( [43周工时]) as [43周工时]
	,sum( [44周工时]) as [44周工时]
	,sum( [45周工时]) as [45周工时]
	,sum( [46周工时]) as [46周工时]
	,sum( [47周工时]) as [47周工时]
	,sum( [48周工时]) as [48周工时]
	,sum( [49周工时]) as [49周工时]
	,sum( [50周工时]) as [50周工时]
	,sum( [51周工时]) as [51周工时]
	,sum( [52周工时]) as [52周工时]
	,sum( [53周工时]) as [53周工时]

from 外销订单总表班组工时统计临时表
group by 组别
order by 组别
";

                sSQL = sSQL.Replace("11111111", dateEdit1.DateTime.ToString("yyyy-MM-dd"));
                sSQL = sSQL.Replace("22222222", dateEdit2.DateTime.ToString("yyyy-MM-dd"));
                sSQL = sSQL.Replace("33333333", lookUpEdit年度.Text.Trim());
                sSQL = sSQL.Replace("44444444", Convert.ToDateTime(lookUpEdit年度.Text.Trim() + "-01-01").AddYears(1).ToString("yyyy"));
                sSQL = sSQL.Replace("55555555", Convert.ToDateTime(lookUpEdit年度.Text.Trim() + "-01-01").AddYears(-1).ToString("yyyy"));
                sSQL = sSQL.Replace("200", FrameBaseFunction.ClsBaseDataInfo.sUFDataBaseName.Substring(7, 3));

                DataTable dt = clsSQLCommond.ExecQuery(sSQL);
                gridControl工时.DataSource = dt;
            }
        }
    }
}
