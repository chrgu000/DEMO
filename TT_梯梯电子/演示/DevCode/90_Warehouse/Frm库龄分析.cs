using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraLayout;
using System.IO;
using DevExpress.XtraEditors;

//using NPOI.HSSF.UserModel;
//using NPOI.HSSF.Util;
//using NPOI.SS.UserModel;
//using NPOI.HPSF;
//using NPOI.SS.Util;

namespace Warehouse
{
    public partial class Frm库龄分析 : FrameBaseFunction.Frm列表窗体模板
    {
        string Type = "";
        public Frm库龄分析()
        {
            InitializeComponent();

            sLayoutHeadPath = base.sProPath + "\\layout\\" + this.Text.Trim() + "Head.xml";
            sLayoutGridPath = base.sProPath + "\\layout\\" + this.Text.Trim() + "Grid.xml";

            if (File.Exists(sLayoutHeadPath))
                layoutControl1.RestoreLayoutFromXml(sLayoutHeadPath);

            if (File.Exists(sLayoutGridPath))
            {
                //gridControl1.MainView.RestoreLayoutFromXml(sLayoutGridPath);
            }

            dtBingGrid = new DataTable();
            dtBingHead = new DataTable();
        }



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
                    case "del":
                        btnDel();
                        break;
                    case "delrow":
                        btnDelRow();
                        break;
                    case "add":
                        btnAdd();
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
            }
            catch (Exception ee)
            {
                throw new Exception(sBtnText + " 失败! \n\n原因:\n  " + ee.Message);
            }
        }


        #region 按钮模板

        /// <summary>
        /// 将表格中Lookup之类的保存ID的数据转换成Text用于打印
        /// </summary>
        /// <param name="dt"></param>
        /// <returns></returns>
        private DataTable SetPrintData(DataTable dt)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// 打印
        /// </summary>
        private void btnPrint()
        {
            throw new NotImplementedException();
        }
        /// <summary>
        /// 输出
        /// </summary>
        private void btnExport()
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

        private void btnLayout(string sText)
        {
            if (layoutControl1 == null) return;
            if (sText == "布局")
            {
                //layoutControl1.ShowCustomizationForm();
                layoutControl1.AllowCustomizationMenu = true;
                base.toolStripMenuBtn.Items["Layout"].Text = "保存布局";

                gridView1.OptionsMenu.EnableColumnMenu = true;
                gridView1.OptionsMenu.EnableFooterMenu = true;
                gridView1.OptionsMenu.EnableGroupPanelMenu = true;
                //gridView1.OptionsMenu.ShowAddNewSummaryItem = true;
                gridView1.OptionsMenu.ShowAutoFilterRowItem = true;
                gridView1.OptionsMenu.ShowDateTimeGroupIntervalItems = true;
                gridView1.OptionsMenu.ShowGroupSortSummaryItems = true;
                gridView1.OptionsMenu.ShowGroupSummaryEditorItem = true;
                gridView1.OptionsCustomization.AllowColumnMoving = true;
            }
            else
            {
                //layoutControl1.HideCustomizationForm();
                layoutControl1.AllowCustomizationMenu = false;
                gridView1.OptionsMenu.EnableColumnMenu = false;
                gridView1.OptionsMenu.EnableFooterMenu = false;
                gridView1.OptionsMenu.EnableGroupPanelMenu = false;
                //gridView1.OptionsMenu.ShowAddNewSummaryItem = false;
                gridView1.OptionsMenu.ShowAutoFilterRowItem = false;
                gridView1.OptionsMenu.ShowDateTimeGroupIntervalItems = false;
                gridView1.OptionsMenu.ShowGroupSortSummaryItems = false;
                gridView1.OptionsMenu.ShowGroupSummaryEditorItem = false;
                gridView1.OptionsCustomization.AllowColumnMoving = false;


                if (!Directory.Exists(base.sProPath + "\\layout"))
                    Directory.CreateDirectory(base.sProPath + "\\layout");

                base.toolStripMenuBtn.Items["Layout"].Text = "布局";

                DialogResult d = MessageBox.Show("是否保存?\n是：保存界面样式\n否：恢复默认界面样式,下次加载时将以默认样式打开\n", "提示", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Asterisk);
                if (d == DialogResult.Yes)
                {
                    layoutControl1.SaveLayoutToXml(sLayoutHeadPath);
                    gridControl1.MainView.SaveLayoutToXml(sLayoutGridPath);
                }
                else if (d == DialogResult.No)
                {
                    if (File.Exists(sLayoutHeadPath))
                        File.Delete(sLayoutHeadPath);

                    if (File.Exists(sLayoutGridPath))
                        File.Delete(sLayoutGridPath);
                }
            }
        }
        #endregion

        /// <summary>
        /// 导入
        /// </summary>
        private void btnImport()
        {
            throw new NotImplementedException();
        }
        /// <summary>
        /// 刷新
        /// </summary>
        private void btnRefresh()
        {
            SetLookUpEdit();
            GetGrid();
        }
        /// <summary>
        /// 查询
        /// </summary>
        private void btnSel()
        {
            GetGrid();
        }

        private void GetSel()
        {
            throw new NotImplementedException();

        }

        /// <summary>
        /// 首页
        /// </summary>
        private void btnFirst()
        {
            throw new NotImplementedException();
        }
        /// <summary>
        /// 上页
        /// </summary>
        private void btnPrev()
        {
            throw new NotImplementedException();
        }
        /// <summary>
        /// 下页
        /// </summary>
        private void btnNext()
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// 末页
        /// </summary>
        private void btnLast()
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// 锁定
        /// </summary>
        private void btnLock()
        {
            throw new NotImplementedException();
        }
        /// <summary>
        /// 解锁  生成出库
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
            throw new NotImplementedException();
        }
        /// <summary>
        /// 删行
        /// </summary>
        private void btnDelRow()
        {
            throw new NotImplementedException();
        }
        /// <summary>
        /// 新增
        /// </summary>
        private void btnAdd()
        {
            throw new NotImplementedException();
        }
        /// <summary>
        /// 修改
        /// </summary>
        private void btnEdit()
        {
            throw new NotImplementedException();
        }
        /// <summary>
        /// 删除
        /// </summary>
        private void btnDel()
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// 保存
        /// </summary>
        private void btnSave()
        {
            throw new NotImplementedException();
        }
        /// <summary>
        /// 撤销
        /// </summary>
        private void btnUnDo()
        {
            int iFocRow = gridView1.FocusedRowHandle;
            GetGrid();
            gridView1.FocusedRowHandle = iFocRow;
        }
        /// <summary>
        /// 审核
        /// </summary>
        private void btnAudit()
        {
            throw new NotImplementedException();
        }
        /// <summary>
        /// 弃审
        /// </summary>
        private void btnUnAudit()
        {
            throw new NotImplementedException();
        }
        /// <summary>
        /// 打开
        /// </summary>
        private void btnOpen()
        {
            throw new NotImplementedException();
        }
        /// <summary>
        /// 关闭
        /// </summary>
        private void btnClose()
        {
            throw new NotImplementedException();
        }
        /// <summary>
        /// 变更
        /// </summary>
        private void btnAlter()
        {
            throw new NotImplementedException();
        }

        #endregion

        private void Frm库龄分析_Load(object sender, EventArgs e)
        {
            try
            {
                SetLookUpEdit();
                dateEdit1.EditValue = DateTime.Now.ToString("yyyy-MM-dd");

                //GetCol("合计", "iQty");
                //GetCol("小于180天金额", "iSum1");

                //GetCol("小于180天", "iQty1");
                //GetCol("小于180天金额", "iSum1");

                //GetCol("180-209天", "iQty2");
                GetCol("180-209天金额", "iSum2");

                //GetCol("210-239天", "iQty3");
                GetCol("210-239天金额", "iSum3");

                //GetCol("240-269天", "iQty4");
                GetCol("240-269天金额", "iSum4");

                //GetCol("270-299天", "iQty5");
                GetCol("270-299天金额", "iSum5");

                //GetCol("300-329天", "iQty6");
                GetCol("300-329天金额", "iSum6");

                //GetCol("330-359天", "iQty7");
                GetCol("330-359天金额", "iSum7");

                //GetCol("360-389天", "iQty8");
                GetCol("360-389天金额", "iSum8");

                //GetCol("390-419天", "iQty9");
                GetCol("390-419天金额", "iSum9");

                //GetCol("420-449天", "iQty10");
                GetCol("420-449天金额", "iSum10");

                //GetCol("大于449天", "iQty11");
                GetCol("大于449天金额", "iSum11");

                GetCol("合计", "iSum");
                //GetCol("小于30天", "d2");
                //GetCol("小于30天金额", "dP2");

                //GetCol("库龄", "库龄");
                //GetCol("最早入库日期", "最早入库日期");
            }
            catch (Exception ee)
            {
                MessageBox.Show("加载窗体失败\n" + ee.Message);
            }
        }



        private void GetCol(string ColText, string FieldName)
        {
            DevExpress.XtraGrid.Columns.GridColumn Col = new DevExpress.XtraGrid.Columns.GridColumn();
            Col.FieldName = FieldName;
            Col.Name = "gridCol" + FieldName;
            Col.Caption = ColText;
            Col.OptionsColumn.AllowEdit = false;
            Col.Width = 120;
            Col.Visible = true;
            Col.VisibleIndex = gridView1.Columns.Count - 1;
            Col.SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Sum;
            Col.SummaryItem.FieldName = FieldName;
            gridView1.Columns.Add(Col);
        }

        private void GetGrid()
        {
            string ddate = dateEdit1.Text.ToString();
            if (ddate != "")
            {
                ddate = DateTime.Parse(ddate).ToString("yyyy-MM-dd");
            }

            string sSQL = @"

declare @d varchar(10)
set @d = '222222'

select a.cCode,b.cInvCode,a.dDate,b.iquantity,b.iPrice 
into #h 
from @u8.RdRecord01 a inner join @u8.RdRecords01 b on a.ID = b.ID 
	left join @u8.Rd_Style c on a.cRdCode=c.cRdCode 
	left join @u8.Inventory d on b.cInvCode = d.cInvCode
where (c.crdcode='101' or c.crdcode = '104') and convert(varchar(4),a.dDate,120)= 111111   And a.dDate <=@d and 1=1   and b.iquantity > 0 

insert into #h
select a.cCode,b.cInvCode,a.dDate,b.iquantity,b.iPrice 
from @u8.RdRecord10 a inner join @u8.RdRecords10 b on a.ID = b.ID 
	left join @u8.Rd_Style c on a.cRdCode=c.cRdCode 
	left join @u8.Inventory d on b.cInvCode = d.cInvCode
where (c.crdcode='101' or c.crdcode = '104') and convert(varchar(4),a.dDate,120)= 111111   And a.dDate <=@d and 1=1   and b.iquantity > 0 

insert into #h select cCode,cInvCode,dDate,convert(decimal(18,3),iquantity),iPrice from @u8.库龄期初 where ddate<'111111-01-01' and 2=2 

select cInvCode,cast (null as decimal(16,2)) as iSum
	,sum(case when dDate > dateadd(day,-180,@d) then iquantity end)  as iQty1,sum(case when dDate > dateadd(day,-180,@d) then iPrice end)  as iSum1
	,sum(case when dDate > dateadd(day,-210,@d) and dDate <= dateadd(day,-180,@d) then iquantity end)  as iQty2,sum(case when dDate > dateadd(day,-210,@d) and dDate <= dateadd(day,-180,@d) then iPrice end)  as iSum2
	,sum(case when dDate > dateadd(day,-240,@d) and dDate <= dateadd(day,-210,@d) then iquantity end)  as iQty3,sum(case when dDate > dateadd(day,-240,@d) and dDate <= dateadd(day,-210,@d) then iPrice end)  as iSum3
	,sum(case when dDate > dateadd(day,-270,@d) and dDate <= dateadd(day,-240,@d) then iquantity end)  as iQty4,sum(case when dDate > dateadd(day,-270,@d) and dDate <= dateadd(day,-240,@d) then iPrice end)  as iSum4
	,sum(case when dDate > dateadd(day,-300,@d) and dDate <= dateadd(day,-270,@d) then iquantity end)  as iQty5,sum(case when dDate > dateadd(day,-300,@d) and dDate <= dateadd(day,-270,@d) then iPrice end)  as iSum5
	,sum(case when dDate > dateadd(day,-330,@d) and dDate <= dateadd(day,-300,@d) then iquantity end)  as iQty6,sum(case when dDate > dateadd(day,-330,@d) and dDate <= dateadd(day,-300,@d) then iPrice end)  as iSum6
	,sum(case when dDate > dateadd(day,-360,@d) and dDate <= dateadd(day,-330,@d) then iquantity end)  as iQty7,sum(case when dDate > dateadd(day,-360,@d) and dDate <= dateadd(day,-330,@d) then iPrice end)  as iSum7
	,sum(case when dDate > dateadd(day,-390,@d) and dDate <= dateadd(day,-360,@d) then iquantity end)  as iQty8,sum(case when dDate > dateadd(day,-390,@d) and dDate <= dateadd(day,-360,@d) then iPrice end)  as iSum8
	,sum(case when dDate > dateadd(day,-420,@d) and dDate <= dateadd(day,-390,@d) then iquantity end)  as iQty9,sum(case when dDate > dateadd(day,-420,@d) and dDate <= dateadd(day,-390,@d) then iPrice end)  as iSum9
	,sum(case when dDate > dateadd(day,-450,@d) and dDate <= dateadd(day,-420,@d) then iquantity end)  as iQty10,sum(case when dDate > dateadd(day,-450,@d) and dDate <= dateadd(day,-420,@d) then iPrice end)  as iSum10
	,sum(case when dDate > dateadd(day,-450,@d) then iquantity end)  as iQty11,sum(case when dDate > dateadd(day,-450,@d) then iPrice end)  as iSum11 
into #a from 
#h where 2=2 
group by cInvCode 

select a.cInvCode,cast(sum(a.iQuantity) as decimal(16,2)) as iQty
into #b
from @u8.CurrentStock a inner join @u8.Inventory b on a.cInvCode = b.cInvCode 
group by a.cInvCode

select * 
from #b b left join #a a on b.cInvCode = a.cInvCode
	left join @u8.Inventory c on a.cInvCode = c.cInvCode
where isnull(b.iQty,0) > 0


";


            sSQL = sSQL.Replace("111111", FrameBaseFunction.ClsBaseDataInfo.sUFDataBaseName.Substring(11, 4));
            sSQL = sSQL.Replace("222222", dateEdit1.DateTime.ToString("yyyy-MM-dd"));

            DataTable dt = clsSQLCommond.ExecQuery(sSQL);

            for (int i = 0; i < dt.Rows.Count; i++)
            {
                decimal dAll = ReturnObjectToDecimal(dt.Rows[i]["iQty"], 2);
                decimal d1 = 0;
                decimal d2 = 0;
                decimal d3 = 0;
                decimal d4 = 0;
                decimal d5 = 0;
                decimal d6 = 0;
                decimal d7 = 0;
                decimal d8 = 0;
                decimal d9 = 0;
                decimal d10 = 0;
                decimal d11 = 0;
                decimal dP1 = 0;
                decimal dP2 = 0;
                decimal dP3 = 0;
                decimal dP4 = 0;
                decimal dP5 = 0;
                decimal dP6 = 0;
                decimal dP7 = 0;
                decimal dP8 = 0;
                decimal dP9 = 0;
                decimal dP10 = 0;
                decimal dP11 = 0;
                decimal dSum = 0;
                decimal dPrice = 0;

                d1 = ReturnObjectToDecimal(dt.Rows[i]["iQty1"], 2);
                dP1 = ReturnObjectToDecimal(dt.Rows[i]["iSum1"], 2);

      
                if (dAll > 0 && dAll < d1)
                {
                    d1 = dAll;
                    dAll = 0;
                }
                else
                {
                    dAll = dAll - d1;
                    if (dAll < 0)
                    {
                        dAll = 0;
                        d1 = 0;
                    }
                }
                if (dP1 > 0 && d1 > 0)
                {
                    dPrice = dP1 / d1;
                    dP1 = dPrice * d1;
                }
                else
                {
                    dP1 = dPrice * d1;
                }
                    
                d2 = ReturnObjectToDecimal(dt.Rows[i]["iQty2"], 2);
                dP2 = ReturnObjectToDecimal(dt.Rows[i]["iSum2"], 2);
                if (dAll > 0 && dAll < d2)
                {
                    dP2 = dP2 / d2 * d2;
                    d2 = dAll;
                    dAll = 0;
                }
                else
                {
                    dAll = dAll - d2;
                    if (dAll < 0)
                    {
                        dAll = 0;
                        d2 = 0;
                    }
                }
                if (dP2 > 0 && d2 > 0)
                {
                    dPrice = dP2 / d2;
                    dP2 = dPrice * d2;
                }
                else
                {
                    dP2= dPrice * d2;
                }

                d3 = ReturnObjectToDecimal(dt.Rows[i]["iQty3"], 2);
                dP3 = ReturnObjectToDecimal(dt.Rows[i]["iSum3"], 2);
                if (dAll > 0 && dAll < d3)
                {
                    d3 = dAll;
                    dAll = 0;
                }
                else
                {
                    dAll = dAll - d3;
                    if (dAll < 0)
                    {
                        dAll = 0;
                        d3 = 0;
                    }
                }
                if (dP3 > 0 && d3 > 0)
                {
                    dPrice = dP3 / d3;
                    dP3 = dPrice * d3;
                }
                else
                {
                    dP3 = dPrice * d3;
                }

                d4 = ReturnObjectToDecimal(dt.Rows[i]["iQty4"], 2);
                dP4 = ReturnObjectToDecimal(dt.Rows[i]["iSum4"], 2);
                if (dAll > 0 && dAll < d4)
                {
                    dP4 = dP4 / d4 * dAll;
                    d4 = dAll;
                    dAll = 0;
                }
                else
                {
                    dAll = dAll - d4;
                    if (dAll < 0)
                    {
                        dAll = 0;
                        d4 = 0;
                    }
                }
                if (dP4 > 0 && d4 > 0)
                {
                    dPrice = dP4 / d4;
                    dP4 = dPrice * d4;
                }
                else
                {
                    dP4 = dPrice * d4;
                }

                d5 = ReturnObjectToDecimal(dt.Rows[i]["iQty5"], 2);
                dP5 = ReturnObjectToDecimal(dt.Rows[i]["iSum5"], 2);
                if (dAll > 0 && dAll < d5)
                {
                    d5 = dAll;
                    dAll = 0;
                }
                else
                {
                    dAll = dAll - d5;
                    if (dAll < 0)
                    {
                        dAll = 0;
                        d5 = 0;
                    }
                }
                if (dP5 > 0 && d5 > 0)
                {
                    dPrice = dP5 / d5;
                    dP5 = dPrice * d5;
                }
                else
                {
                    dP5 = dPrice * d5;
                }

                d6 = ReturnObjectToDecimal(dt.Rows[i]["iQty6"], 2);
                dP6 = ReturnObjectToDecimal(dt.Rows[i]["iSum6"], 2);
                if (dAll > 0 && dAll < d6)
                {
                    d6 = dAll;
                    dAll = 0;
                }
                else
                {
                    dAll = dAll - d6;
                    if (dAll < 0)
                    {
                        dAll = 0;
                        d6 = 0;
                    }
                } 
                if (dP6 > 0 && d6 > 0)
                {
                    dPrice = dP6 / d6;
                    dP6 = dPrice * d6;
                }
                else
                {
                    dP6 = dPrice * d6;
                }


                d7 = ReturnObjectToDecimal(dt.Rows[i]["iQty7"], 2);
                dP7 = ReturnObjectToDecimal(dt.Rows[i]["iSum7"], 2);
                if (dAll > 0 && dAll < d7)
                {
                    d7 = dAll;
                    dAll = 0;
                }
                else
                {
                    dAll = dAll - d7;
                    if (dAll < 0)
                    {
                        dAll = 0;
                        d7 = 0;
                    }
                }
                if (dP7 > 0 && d7 > 0)
                {
                    dPrice = dP7 / d7;
                    dP7 = dPrice * d7;
                }
                else
                {
                    dP7 = dPrice * d7;
                }


                d8 = ReturnObjectToDecimal(dt.Rows[i]["iQty8"], 2);
                dP8 = ReturnObjectToDecimal(dt.Rows[i]["iSum8"], 2);
                if (dAll > 0 && dAll < d8)
                {
                    d8 = dAll;
                    dAll = 0;
                }
                else
                {
                    dAll = dAll - d8;
                    if (dAll < 0)
                    {
                        dAll = 0;
                        d8 = 0;
                    }
                }
                if (dP8 > 0 && d8 > 0)
                {
                    dPrice = dP8 / d8;
                    dP8 = dPrice * d8;
                }
                else
                {
                    dP8 = dPrice * d8;
                }


                d9 = ReturnObjectToDecimal(dt.Rows[i]["iQty9"], 2);
                dP9 = ReturnObjectToDecimal(dt.Rows[i]["iSum9"], 2);
                if (dAll > 0 && dAll < d9)
                {
                    d9 = dAll;
                    dAll = 0;
                }
                else
                {
                    dAll = dAll - d9;
                    if (dAll < 0)
                    {
                        dAll = 0;
                        d9 = 0;
                    }
                }
                if (dP9 > 0 && d9 > 0)
                {
                    dPrice = dP9 / d9;
                    dP9 = dPrice * 9;
                }
                else
                {
                    dP9 = dPrice * d9;
                }


                d10 = ReturnObjectToDecimal(dt.Rows[i]["iQty10"], 2);
                dP10 = ReturnObjectToDecimal(dt.Rows[i]["iSum10"], 2);
                if (dAll > 0 && dAll < d10)
                {
                    d10 = dAll;
                    dAll = 0;
                }
                else
                {
                    dAll = dAll - d10;
                    if (dAll < 0)
                    {
                        dAll = 0;
                        d10 = 0;
                    }
                }
                if (dP10 > 0 && d10 > 0)
                {
                    dPrice = dP10 / d10;
                    dP10 = dPrice * d10;
                }
                else
                {
                    dP10 = dPrice * d10;
                }


                d11 = ReturnObjectToDecimal(dt.Rows[i]["iQty11"], 2);
                dP11 = ReturnObjectToDecimal(dt.Rows[i]["iSum11"], 2);
                if (dAll > 0 && dAll < d11)
                {
                    if (d11 > 0)
                    {
                        dP11 = dP11 / d11 * dAll;
                    }
                    else
                    {
                        dP11 = 0;
                    } 
                    d11 = dAll;
                    dAll = 0;
                }
                else
                {
                    dAll = dAll - d11;
                    if (dAll < 0)
                    {
                        dAll = 0;
                        d11 = 0;
                    }
                }
                if (dP11 > 0 && d11 > 0)
                {
                    dPrice = dP11 / d11;
                    dP11 = dPrice * d11;
                }
                else
                {
                    dP11 = dPrice * d11;
                }


                dt.Rows[i]["iQty1"] = d1;
                dt.Rows[i]["iQty2"] = d2;
                dt.Rows[i]["iQty3"] = d3;
                dt.Rows[i]["iQty4"] = d4;
                dt.Rows[i]["iQty5"] = d5;
                dt.Rows[i]["iQty6"] = d6;
                dt.Rows[i]["iQty7"] = d7;
                dt.Rows[i]["iQty8"] = d8;
                dt.Rows[i]["iQty9"] = d9;
                dt.Rows[i]["iQty10"] = d10;
                dt.Rows[i]["iQty11"] = d11;

                dP1 = ReturnObjectToDecimal(dP1, 2);
                dP2 = ReturnObjectToDecimal(dP2, 2);
                dP3 = ReturnObjectToDecimal(dP3, 2);
                dP4 = ReturnObjectToDecimal(dP4, 2);
                dP5 = ReturnObjectToDecimal(dP5, 2);
                dP6 = ReturnObjectToDecimal(dP6, 2);
                dP7 = ReturnObjectToDecimal(dP7, 2);
                dP8 = ReturnObjectToDecimal(dP8, 2);
                dP9 = ReturnObjectToDecimal(dP9, 2);
                dP10 = ReturnObjectToDecimal(dP10, 2);
                dP11 = ReturnObjectToDecimal(dP11, 2);

                if (dP1 != 0)
                {
                    dt.Rows[i]["iSum1"] = dP1;
                }
                else
                {
                    dt.Rows[i]["iSum1"] = DBNull.Value;  
                }
                if (dP2 != 0)
                {
                    dt.Rows[i]["iSum2"] = dP2;
                }
                else
                {
                    dt.Rows[i]["iSum2"] = DBNull.Value;
                }
                if (dP3 != 0)
                {
                    dt.Rows[i]["iSum3"] = dP3;
                }
                else
                {
                    dt.Rows[i]["iSum3"] = DBNull.Value;
                }
                if (dP4 != 0)
                {
                    dt.Rows[i]["iSum4"] = dP4;
                }
                else
                {
                    dt.Rows[i]["iSum4"] = DBNull.Value;
                }
                if (dP5 != 0)
                {
                    dt.Rows[i]["iSum5"] = dP5;
                }
                else
                {
                    dt.Rows[i]["iSum5"] = DBNull.Value;
                }
                if (dP6 != 0)
                {
                    dt.Rows[i]["iSum6"] = dP6;
                }
                else
                {
                    dt.Rows[i]["iSum6"] = DBNull.Value;
                }
                if (dP7 != 0)
                {
                    dt.Rows[i]["iSum7"] = dP7;
                }
                else
                {
                    dt.Rows[i]["iSum7"] = DBNull.Value;
                }
                if (dP8 != 0)
                {
                    dt.Rows[i]["iSum8"] = dP8;
                }
                else
                {
                    dt.Rows[i]["iSum8"] = DBNull.Value;
                }
                if (dP9 != 0)
                {
                    dt.Rows[i]["iSum9"] = dP9;
                }
                else
                {
                    dt.Rows[i]["iSum9"] = DBNull.Value;
                }
                if (dP10 != 0)
                {
                    dt.Rows[i]["iSum10"] = dP10;
                }
                else
                {
                    dt.Rows[i]["iSum10"] = DBNull.Value;
                }
                if (dP11 != 0)
                {
                    dt.Rows[i]["iSum11"] = dP11;
                }
                else
                {
                    dt.Rows[i]["iSum11"] = DBNull.Value;
                }
                
                decimal dSumPr =  dP2 + dP3 + dP4 + dP5 + dP6 + dP7 + dP8 + dP9 + dP10 + dP11;
                if (dSumPr > 0)
                {
                    dt.Rows[i]["iSum"] = dSumPr;
                }
                
            }

            for (int i = dt.Rows.Count - 1; i >= 0; i--)
            {
                if (ReturnObjectToDecimal(dt.Rows[i]["iSum"], 2) == 0)
                {
                    dt.Rows.RemoveAt(i);
                }
            }


            gridControl1.DataSource = dt;

            gridView1.ExpandAllGroups();
            
        }

        private decimal GetTemp(decimal 数量, decimal dTemp,decimal 单价, int i, int count,DataTable dt)
        {
            
            if (数量 > 0)
            {
                decimal tqty = 0;
                decimal tprice = 0;
                if (dTemp > 0)
                {
                    decimal qty = dTemp - 数量;

                    if (qty >= 0)
                    {
                        tqty = 数量;
                        dTemp = dTemp - 数量;
                    }
                    else
                    {
                        tqty = dTemp;
                        dTemp = 0;
                    }
                    dt.Rows[i]["数量" + count] = tqty;
                    tprice = ReturnObjectToDecimal(tqty * 单价, 2);
                    dt.Rows[i]["金额" + count] = tprice;
                }
                else
                {
                    dt.Rows[i]["数量" + count] = DBNull.Value;
                    dt.Rows[i]["金额" + count] = DBNull.Value;
                }
                
            }
            else
            {
                dt.Rows[i]["数量" + count] = DBNull.Value;
                dt.Rows[i]["金额" + count] = DBNull.Value;
            }
            
            return dTemp;
        }


        /// <summary>
        /// 下拉列表框
        /// </summary>
        private void SetLookUpEdit()
        {
            //系统服务.LookUp.InventoryClass(lookUpEdit存货分类);
            //系统服务.LookUp.Inventory(lookUpEdit存货编码);
        }

        private void gridView1_CellValueChanged(object sender, DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs e)
        {
        }


        private void gridView1_CustomDrawRowIndicator(object sender, DevExpress.XtraGrid.Views.Grid.RowIndicatorCustomDrawEventArgs e)
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
