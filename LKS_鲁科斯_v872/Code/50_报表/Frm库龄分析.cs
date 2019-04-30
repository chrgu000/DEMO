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

using NPOI.HSSF.UserModel;
using NPOI.HSSF.Util;
using NPOI.SS.UserModel;
using NPOI.HPSF;
using NPOI.SS.Util;

namespace 报表
{
    public partial class Frm库龄分析 : 系统服务.FrmBaseInfo
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

                GetCol("小于30天", "数量1");
                GetCol("小于30天金额", "金额1");

                GetCol("30天到60天", "数量2");
                GetCol("30天到60天金额", "金额2");

                GetCol("60天到90天", "数量3");
                GetCol("60天到90天金额", "金额3");

                GetCol("90天到120天", "数量4");
                GetCol("90天到120天金额", "金额4");

                GetCol("120天到150天", "数量5");
                GetCol("120天到150天金额", "金额5");

                GetCol("150到180天", "数量6");
                GetCol("150到180天金额", "金额6");

                GetCol("180到365天", "数量7");
                GetCol("180到365天金额", "金额7");

                GetCol("365天以上", "数量8");
                GetCol("365天以上金额", "金额8");

                GetCol("库龄", "库龄");
                GetCol("最早入库日期", "最早入库日期");
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
            Col.Width = 80;
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

            string SSQL1 = "";
            SSQL1 = @"select b.cInvCode,a.dDate,b.iquantity,b.iPrice into #h from @u8.RdRecord a inner join @u8.RdRecords b on a.ID = b.ID left join @u8.Rd_Style c on a.cRdCode=c.cRdCode 
where c.bRdFlag=1 and convert(varchar(4),a.dDate,120)=999999999999   And a.dDate <='" + ddate + "' and 1=1  ";
            SSQL1 = SSQL1.Replace("999999999999", 系统服务.ClsBaseDataInfo.sUFDataBaseYear);
            sSQL = SSQL1 + @"
insert into #h select cInvCode,dDate,convert(decimal(18,3),iquantity),iPrice from 库龄期初 where ddate<'999999999999' and 2=2 
select cInvCode
	,sum(case when dDate >= dateadd(month,-1,'222222222222') then iquantity end)  as iQty1,sum(case when dDate >= dateadd(month,-1,'222222222222') then iPrice end)  as iSum1
	,sum(case when dDate < dateadd(month,-1,'222222222222') and dDate >= dateadd(month,-2,'222222222222') then iquantity end)  as iQty2,sum(case when dDate < dateadd(month,-1,'222222222222') and dDate >= dateadd(month,-2,'222222222222') then iPrice end)  as iSum2
	,sum(case when dDate < dateadd(month,-2,'222222222222') and dDate >= dateadd(month,-3,'222222222222') then iquantity end)  as iQty3,sum(case when dDate < dateadd(month,-2,'222222222222') and dDate >= dateadd(month,-3,'222222222222') then iPrice end)  as iSum3
	,sum(case when dDate < dateadd(month,-3,'222222222222') and dDate >= dateadd(month,-4,'222222222222') then iquantity end)  as iQty4,sum(case when dDate < dateadd(month,-3,'222222222222') and dDate >= dateadd(month,-4,'222222222222') then iPrice end)  as iSum4
	,sum(case when dDate < dateadd(month,-4,'222222222222') and dDate >= dateadd(month,-5,'222222222222') then iquantity end)  as iQty5,sum(case when dDate < dateadd(month,-4,'222222222222') and dDate >= dateadd(month,-5,'222222222222') then iPrice end)  as iSum5
	,sum(case when dDate < dateadd(month,-5,'222222222222') and dDate >= dateadd(month,-6,'222222222222') then iquantity end)  as iQty6,sum(case when dDate < dateadd(month,-5,'222222222222') and dDate >= dateadd(month,-6,'222222222222') then iPrice end)  as iSum6
	,sum(case when dDate < dateadd(month,-6,'222222222222') and dDate >= dateadd(month,-12,'222222222222') then iquantity end)  as iQty7,sum(case when dDate < dateadd(month,-6,'222222222222') and dDate >= dateadd(month,-12,'222222222222') then iPrice end)  as iSum7
	,sum(case when dDate < dateadd(month,-12,'222222222222') then iquantity end)  as iQty8,sum(case when dDate < dateadd(month,-12,'222222222222') then iPrice end)  as iSum8 
into #a from #h where 2=2 group by cInvCode 

Select 1 as i,cRdCode,i.cInvCCode as cInvCCode ,s.cInvCode, cInvAddCode, cInvName,cInvStd,@u8.ComputationUnit.cComunitCode,@u8.ComputationUnit.CComUnitName,@u8.ComputationUnit.iChangRate,iInvWeight,cInvDefine1,cInvDefine2,cInvDefine3,cInvDefine4,cInvDefine5,cInvDefine6,cInvDefine7,cInvDefine8,isnull(convert(decimal(36,2),cInvDefine9),0)/100  as 贵金属比重,cInvDefine10,cInvDefine13,cast(sum(ISNULL(Cast(iAInQuantity as decimal(20,4)),0) -ISNULL(Cast(iAOutQuantity as decimal(20,4)),0)) as float) AS QcQuantity,cast(sum(ISNULL(cast(iAInPrice as decimal(20,2)),0)-ISNULL(Cast(iAOutPrice as decimal(20,2)),0)) as decimal(20,2)) AS QcPrice,cast(sum(isnull(Cast(iDebitDifCost as decimal(20,2)),0)-isnull(Cast(iCreditDifCost as decimal(20,2)),0)) as decimal(20,2)) as qcDif,cast(0 as float) as InQuantity,cast(0 as decimal(20,2)) as InPrice,CAST(0 as decimal(20,2)) as InDif,cast(0 as float) as OutQuantity,cast(0 as decimal(20,2)) As OutPrice,cast(0 as decimal(20,2)) as OutDif 
into #g
from @u8.IA_Subsidiary s with (nolock) left join @u8.Inventory i with (nolock) on s.cInvCode=i.cInvCode left join @u8.ComputationUnit with (nolock) ON i.cComunitCode = @u8.ComputationUnit.ccomunitcode left join @u8.warehouse with (nolock) on s.cWhCode=@u8.warehouse.cwhcode Where cVouType<> N'33'  and ( Not s.cWhCode is null ) AND  (@u8.WareHouse.bInCost = 1 or @u8.WareHouse.cwhcode is null)  And (imonth=0 or 
(dKeepDate<= '222222222222' and iMonth<>0)) and  5=5 and 6=6  group by cRdCode,i.cInvCCode,s.cInvCode,cInvName,cInvStd,@u8.ComputationUnit.cComunitCode,CComUnitName,iChangRate,iInvWeight,cInvAddCode,cInvDefine1,cInvDefine2,cInvDefine3,cInvDefine4,cInvDefine5,cInvDefine6,cInvDefine7,cInvDefine8,cInvDefine9,cInvDefine10,cInvDefine13 
having (sum(ISNULL(iAInQuantity,0) -ISNULL(iAOutQuantity,0))<>0 or sum(ISNULL(iAInPrice,0)-ISNULL(iAOutPrice,0))<>0 or sum(isnull(iDebitDifCost,0)-isnull(iCreditDifCost,0))<>0)

select *,convert(decimal(18,4),数量) as TempQty1 into #b from 
(
Select  #g.cInvCCode as 存货分类编码,@u8.InventoryClass.cInvCName as 存货分类名称,#g.cInvCode as N'存货编码',#g.cInvAddCode as N'存货代码',#g.cInvName as N'存货名称',#g.cInvStd as N'规格型号',#g.cComunitCode as 计量单位编码, #g.CComUnitName as N'单位',--iInvWeight as N'存货重量',isnull(cInvDefine1,N'') as N'存货自定义项自定义项1',isnull(cInvDefine2,N'') as N'存货自定义项包装要求',isnull(cInvDefine3,N'') as N'存货自定义项客户规格',isnull(cInvDefine4,N'') as N'存货自定义项自定义项4',isnull(cInvDefine5,N'') as N'存货自定义项自定义项5',isnull(cInvDefine6,N'') as N'存货自定义项lucas图纸号',isnull(cInvDefine7,N'') as N'存货自定义项化学成份',isnull(cInvDefine8,N'') as N'存货自定义项其他要求',isnull(cInvDefine10,N'') as N'存货自定义项自定义项10',isnull(cInvDefine13,N'') as N'存货自定义项采购最小批量',
max(贵金属比重) as 贵金属比重,max(case when u.iChangRate is null then 1 else u.iChangRate end) as 换算率,max(case when #g.cComunitCode='106' then 0.45359237038 when  #g.cComunitCode='112' then 0.0283495231488 when u.iChangRate is null then 1 else u.iChangRate end) as 贵金属换算率,
convert(decimal(18,4),isnull(sum(qcQuantity),0)) as N'数量',convert(decimal(18,2),isnull(sum(qcPrice),0))  as N'金额'  ,case when isnull(sum(qcQuantity),0)=0 then 0 else isnull(sum(qcPrice),0)/isnull(sum(qcQuantity),0) end as 单价 
from #g left join @u8.InventoryClass on #g.cInvCCode=@u8.InventoryClass.cInvCCode left join @u8.Inventory inv on #g.cInvCode=inv.cInvCode left join @u8.ComputationUnit u on inv.cAssComUnitCode=u.cComunitCode 
 group by #g.cInvCCode,@u8.InventoryClass.cInvCName,#g.cInvCode,#g.cInvAddCode,#g.cInvName,#g.cInvStd,#g.cComunitCode,#g.CComUnitName 
having convert(decimal(18,4),isnull(sum(qcQuantity),0))<>0
) a 
left join 
    (
        select cInvCode
				,convert(decimal(18,4),sum(iQty1)) as iQty1,sum(iSum1) as iSum1,case when convert(decimal(18,4),sum(iQty1))<>0 then convert(decimal(18,4),sum(iSum1)/sum(iQty1)) end iUnitPrice1
				,convert(decimal(18,4),sum(iQty2)) as iQty2,sum(iSum2) as iSum2,case when convert(decimal(18,4),sum(iQty2))<>0 then convert(decimal(18,4),sum(iSum2)/sum(iQty2)) end iUnitPrice2
				,convert(decimal(18,4),sum(iQty3)) as iQty3,sum(iSum3) as iSum3,case when convert(decimal(18,4),sum(iQty3))<>0 then convert(decimal(18,4),sum(iSum3)/sum(iQty3)) end iUnitPrice3
				,convert(decimal(18,4),sum(iQty4)) as iQty4,sum(iSum4) as iSum4,case when convert(decimal(18,4),sum(iQty4))<>0 then convert(decimal(18,4),sum(iSum4)/sum(iQty4)) end iUnitPrice4
				,convert(decimal(18,4),sum(iQty5)) as iQty5,sum(iSum5) as iSum5,case when convert(decimal(18,4),sum(iQty5))<>0 then convert(decimal(18,4),sum(iSum5)/sum(iQty5)) end iUnitPrice5
				,convert(decimal(18,4),sum(iQty6)) as iQty6,sum(iSum6) as iSum6,case when convert(decimal(18,4),sum(iQty6))<>0 then convert(decimal(18,4),sum(iSum6)/sum(iQty6)) end iUnitPrice6
				,convert(decimal(18,4),sum(iQty7)) as iQty7,sum(iSum7) as iSum7,case when convert(decimal(18,4),sum(iQty7))<>0 then convert(decimal(18,4),sum(iSum7)/sum(iQty7)) end iUnitPrice7
                ,convert(decimal(18,4),sum(iQty8)) as iQty8,sum(iSum8) as iSum8,case when convert(decimal(18,4),sum(iQty8))<>0 then convert(decimal(18,4),sum(iSum8)/sum(iQty8)) end iUnitPrice8 
        from #a
        group by cInvCode
    ) b on  a.存货编码 = b.cInvCode
order by a.存货编码

select *,case when TempQty1>0 and iQty1>0 then case when TempQty1-iQty1>0 then iQty1 else TempQty1 end end 数量1,case when TempQty1>0 and iQty1>0 then case when TempQty1-iQty1>0 then TempQty1-iQty1 else 0  end else TempQty1 end TempQty2 into #d1 from #b 
select *,case when TempQty2>0 and iQty2>0 then case when TempQty2-iQty2>0 then iQty2 else TempQty2 end end 数量2,case when TempQty2>0 and iQty2>0 then case when TempQty2-iQty2>0 then TempQty2-iQty2 else 0  end else TempQty2 end TempQty3 into #d2 from #d1 
select *,case when TempQty3>0 and iQty3>0 then case when TempQty3-iQty3>0 then iQty3 else TempQty3 end end 数量3,case when TempQty3>0 and iQty3>0 then case when TempQty3-iQty3>0 then TempQty3-iQty3 else 0  end else TempQty3 end TempQty4 into #d3 from #d2 
select *,case when TempQty4>0 and iQty4>0 then case when TempQty4-iQty4>0 then iQty4 else TempQty4 end end 数量4,case when TempQty4>0 and iQty4>0 then case when TempQty4-iQty4>0 then TempQty4-iQty4 else 0  end else TempQty4 end TempQty5 into #d4 from #d3 
select *,case when TempQty5>0 and iQty5>0 then case when TempQty5-iQty5>0 then iQty5 else TempQty5 end end 数量5,case when TempQty5>0 and iQty5>0 then case when TempQty5-iQty5>0 then TempQty5-iQty5 else 0  end else TempQty5 end TempQty6 into #d5 from #d4 
select *,case when TempQty6>0 and iQty6>0 then case when TempQty6-iQty6>0 then iQty6 else TempQty6 end end 数量6,case when TempQty6>0 and iQty6>0 then case when TempQty6-iQty6>0 then TempQty6-iQty6 else 0  end else TempQty6 end TempQty7 into #d6 from #d5 
select *,case when TempQty7>0 and iQty7>0 then case when TempQty7-iQty7>0 then iQty7 else TempQty7 end end 数量7,case when TempQty7>0 and iQty7>0 then case when TempQty7-iQty7>0 then TempQty7-iQty7 else 0  end else TempQty7 end TempQty8 into #d7 from #d6 
select *,case when TempQty8>0 and iQty8>0 then case when TempQty8-iQty8>0 then iQty8 else TempQty8 end end 数量8,case when TempQty8>0 and iQty8>0 then case when TempQty8-iQty8>0 then TempQty8-iQty8 else 0  end else TempQty8 end TempQty9 into #d8 from #d7 

select  identity(int,1,1) as seq,cInvCode,dDate ,iquantity into #c
from #h 
where 2=2 and iquantity>0 and  dDate<= '222222222222' order by dDate desc

select *,(select isnull(SUM(iquantity),0) from #c b where a.cInvCode=b.cInvCode and a.seq>b.seq) as iQty1,
(select isnull(SUM(iquantity),0) from #c b where a.cInvCode=b.cInvCode and a.seq>=b.seq) as iQty2 
into #e  from #c a

select *,(select dDate from #e where  #d8.cInvCode=#e.cInvCode and 数量>#e.iQty1 and  数量<=#e.iQty2) as 最早入库日期 ,
convert(decimal(18,3),数量1*金额/数量) as 金额1,convert(decimal(18,3),数量2*金额/数量) as 金额2,
convert(decimal(18,3),数量3*金额/数量) as 金额3,convert(decimal(18,3),数量4*金额/数量) as 金额4,
convert(decimal(18,3),数量5*金额/数量) as 金额5,convert(decimal(18,3),数量6*金额/数量) as 金额6,
convert(decimal(18,3),数量7*金额/数量) as 金额7,convert(decimal(18,3),数量8*金额/数量) as 金额8
into #f  from #d8

select *,isnull(数量1,0)+isnull(数量2,0)+isnull(数量3,0)+isnull(数量4,0)+isnull(数量5,0)+isnull(数量6,0)+isnull(数量7,0)+isnull(数量8,0) as 总数量 ,
convert(decimal(18,2),isnull(金额1,0)+isnull(金额2,0)+isnull(金额3,0)+isnull(金额4,0)+isnull(金额5,0)+isnull(金额6,0)+isnull(金额7,0)+isnull(金额8,0),2) as 总金额 ,
DATEDIFF(D,最早入库日期,GETDATE())-DATEDIFF(D,'222222222222',GETDATE()) as 库龄 from #f 
  
  ";
            
            

            sSQL = sSQL.Replace("222222222222", dateEdit1.DateTime.ToString("yyyy-MM-dd"));
            sSQL = sSQL.Replace("999999999999", 系统服务.ClsBaseDataInfo.sUFDataBaseYear+"-01-01");

            if (lookUpEdit存货分类.Text.Trim() != "")
            {
                sSQL = sSQL.Replace(" 5=5 ", " i.cInvCCode='" + lookUpEdit存货分类.EditValue.ToString().Trim() + "' ");
            }
            if (lookUpEdit存货编码.Text.Trim() != "")
            {
                sSQL = sSQL.Replace(" 6=6 ", " s.cInvCode='" + lookUpEdit存货编码.EditValue.ToString().Trim() + "' ");
                sSQL = sSQL.Replace(" 2=2 ", " cInvCode='" + lookUpEdit存货编码.EditValue.ToString().Trim() + "' ");
                sSQL = sSQL.Replace(" 1=1 ", " b.cInvCode='" + lookUpEdit存货编码.EditValue.ToString().Trim() + "' ");
            }
            sSQL = sSQL.Replace("@u8.", 系统服务.ClsBaseDataInfo.sUFDataBaseName + ".dbo.");

            DataTable dt = clsSQLCommond.ExecQuery(sSQL);

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
                    tprice = ReturnDecimal(tqty * 单价, 2);
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
            系统服务.LookUp.InventoryClass(lookUpEdit存货分类);
            系统服务.LookUp.Inventory(lookUpEdit存货编码);
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

        private void buttonEdit存货分类_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            系统服务.FrmInvClassInfo frm = new 系统服务.FrmInvClassInfo("");
            if (DialogResult.OK == frm.ShowDialog())
            {
                buttonEdit存货分类.EditValue = frm.id;

                frm.Enabled = true;
            }
        }

        private void buttonEdit存货分类_EditValueChanged(object sender, EventArgs e)
        {
            if (buttonEdit存货分类.Text.Trim() != "")
            {
                lookUpEdit存货分类.EditValue = buttonEdit存货分类.Text.Trim();
            }
        }

        private void buttonEdit存货分类_Leave(object sender, EventArgs e)
        {
            if (buttonEdit存货分类.Text.Trim() == "")
                return;
            if (lookUpEdit存货分类.Text.Trim() == "")
            {
                buttonEdit存货分类.Text = "";
                buttonEdit存货分类.Focus();
            }
        }

        private void buttonEdit存货编码_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            系统服务.FrmInvInfo frm = new 系统服务.FrmInvInfo("", false);
            if (DialogResult.OK == frm.ShowDialog())
            {
                buttonEdit存货编码.EditValue = frm.sInvCode;

                frm.Enabled = true;
            }
        }

        private void buttonEdit存货编码_EditValueChanged(object sender, EventArgs e)
        {
            if (buttonEdit存货编码.Text.Trim() != "")
            {
                lookUpEdit存货编码.EditValue = buttonEdit存货编码.Text.Trim();
            }
            else
            {
                lookUpEdit存货编码.EditValue = "";
            }
        }

        private void buttonEdit存货编码_Leave(object sender, EventArgs e)
        {
            if (buttonEdit存货编码.Text.Trim() == "")
                return;
            if (lookUpEdit存货编码.Text.Trim() == "")
            {
                buttonEdit存货编码.Text = "";
                buttonEdit存货编码.Focus();
            }
        }
    }
}
