using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraLayout;
using System.IO;

namespace 报表
{
    public partial class Frm收发存汇总表 : 系统服务.FrmBaseInfo
    {
        DateTime Date1;
        DateTime Date2;
        
        public Frm收发存汇总表()
        {

            InitializeComponent();

            #region 禁止用户调整表格
            gridView1.OptionsMenu.EnableColumnMenu = false;
            gridView1.OptionsMenu.EnableFooterMenu = false;
            gridView1.OptionsMenu.EnableGroupPanelMenu = false;
            gridView1.OptionsMenu.ShowAutoFilterRowItem = false;
            gridView1.OptionsMenu.ShowDateTimeGroupIntervalItems = false;
            gridView1.OptionsMenu.ShowGroupSortSummaryItems = false;
            gridView1.OptionsMenu.ShowGroupSummaryEditorItem = false;
            gridView1.OptionsMenu.ShowAddNewSummaryItem  = DevExpress.Utils.DefaultBoolean.False;
            gridView1.OptionsBehavior.FocusLeaveOnTab = true;
            gridView1.OptionsCustomization.AllowColumnMoving = false;
            //gridView1.OptionsCustomization.

            #endregion

            sLayoutHeadPath = base.sProPath + "\\layout\\" + this.Text.Trim() + "Head.xml";
            sLayoutGridPath = base.sProPath + "\\layout\\" + this.Text.Trim() + "Grid.xml";

            if (File.Exists(sLayoutHeadPath))
                layoutControl1.RestoreLayoutFromXml(sLayoutHeadPath);

            if (File.Exists(sLayoutGridPath))
            {
                gridControl1.MainView.RestoreLayoutFromXml(sLayoutGridPath);
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
            return dt;
        }

        /// <summary>
        /// 打印
        /// </summary>
        private void btnPrint()
        {
            try
            {
                gridView1.FocusedRowHandle -= 1;
                gridView1.FocusedRowHandle += 1;
            }
            catch { }

            base.dsPrint.Tables.Clear();
            DataTable dtGrid = SetPrintData(((DataTable)gridControl1.DataSource).Copy());
            dtGrid.TableName = "dtGrid";

            base.dsPrint.Tables.Add(dtGrid);
            DataTable dtHead = dtBingHead.Copy();
            dtHead.TableName = "dtHead";
            base.dsPrint.Tables.Add(dtHead);
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
                    gridView1.ExportToXls(sF.FileName);
                    MessageBox.Show("导出Excel成功\n\t路径：" + sF.FileName);
                }
            }
            catch (Exception ee)
            {
                throw new Exception(ee.Message);
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
            try
            {
                SetLookUpEdit();
                GetGrid();
            }
            catch (Exception ee)
            {
                throw new Exception("刷新窗体失败\n" + ee.Message);
            }
        }
        /// <summary>
        /// 查询
        /// </summary>
        private void btnSel()
        {
            GetGrid();
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
            GetGrid();
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

        private void Frm收发存汇总表_Load(object sender, EventArgs e)
        {
            try
            {
                dateEdit1.EditValue = DateTime.Now.AddMonths(-1).ToString("yyyy-MM-dd");
                dateEdit2.EditValue = DateTime.Now.ToString("yyyy-MM-dd");
                SetLookUpEdit();
                GetGrid();
            }
            catch (Exception ee)
            {
                throw new Exception("加载窗体失败\n" + ee.Message);
            }
        }

        private void SetLookUpEdit()
        {
            系统服务.LookUp.Inventory(lookUpEdit存货编码);
            系统服务.LookUp.InventoryClass(lookUpEdit存货分类);
            系统服务.LookUp.InventoryClass(ItemLookUpEdit存货分类);
            系统服务.LookUp.Inventory(ItemLookUpEdit存货名称);
        }

        private void GetGrid()
        {
            string sErr = "";
            if (dateEdit1.EditValue == null && dateEdit2.EditValue == null)
            {
                throw new Exception("时间区域不可为空");
            }

            gridControl1.DataSource = Get();


            //gridView1.OptionsBehavior.Editable = false;
            sState = "sel";
        }
       

        private DataTable Get()
        {
            sSQL = @"
--期初
select 类别,cInvCode,cWhCode,case when b.收发标志=0 then iQuantity else -iQuantity end SQty,
case when b.收发标志=0 then iMoney else -iMoney end SMoney,
0 as InQty,0 as InMoney,0 as OutQty,0 as OutMoney from
(
    select '入库单' as 类别,cInvCode,cWhCode,cRSCode,iQuantity,iMoney 
    from view_RdRecord a inner join view_RdRecords b on a.ID=b.ID 
    where 1=1 and S11 is null and S12 is null and S13 is null and S14 is null and S15 is null and dVerifysysPerson is not null 
        union all 
    select '入库单' as 类别,S11,cWhCode,cRSCode,D11,D13 
    from view_RdRecord a inner join view_RdRecords b on a.ID=b.ID 
    where 1=1 and S11 is not null and dVerifysysPerson is not null 
        union all 
    select '入库单' as 类别,S12,cWhCode,cRSCode,D14,D16 
    from view_RdRecord a inner join view_RdRecords b on a.ID=b.ID 
    where 1=1 and S12 is not null and dVerifysysPerson is not null 
        union all 
    select '入库单' as 类别,S13,cWhCode,cRSCode,D17,D19 
    from view_RdRecord a inner join view_RdRecords b on a.ID=b.ID 
    where 1=1 and S13 is not null and dVerifysysPerson is not null 
        union all 
    select '入库单' as 类别,S14,cWhCode,cRSCode,D20,D22 
    from view_RdRecord a inner join view_RdRecords b on a.ID=b.ID 
    where 1=1 and S14 is not null and dVerifysysPerson is not null 
        union all 
    select '入库单' as 类别,S15,cWhCode,cRSCode,D23,D25 
    from view_RdRecord a inner join view_RdRecords b on a.ID=b.ID 
    where 1=1 and S15 is not null and dVerifysysPerson is not null 
) a left join RdStyle b on a.cRSCode=b.cRSCode 

    union all 
select '销售出库' as 类别,aInvCode,cWhCode,-aiQuantity,-isnull(b.D1,0)*iQuantity,0,0,0,0 
from view_SO_SOOutMain a inner join view_SO_SOOutSublist b on a.ID=b.ID 
where 1=1 and dVerifysysPerson is not null and a.Flag=1 and aInvCode is not null 

    union all 

select  '销售出库' as 类别,cInvCode,cWhCode,-iQuantity,-isnull(b.D1,0)*iQuantity,0,0,0,0 
from view_SO_SOOutMain a inner join view_SO_SOOutSublist b on a.ID=b.ID 
where 1=1 and dVerifysysPerson is not null and a.Flag=1 

    union all 

select  '销售出库' as 类别,cInvCode,cWhCode,-iQuantity,-iMoney,0,0,0,0 
from view_SO_SOOutMain a inner join view_SO_SOOutDetails b on a.ID=b.ID 
where 1=1 and dVerifysysPerson is not null and a.Flag=2 

            --当期入库
    union all 
select 类别,cInvCode,cWhCode,0 as SQty,0 as SMoney,case when b.收发标志=0 then iQuantity else -iQuantity end InQty,
case when b.收发标志=0 then iMoney else -iMoney end InMoney,0 as OutQty,0 as OutMoney from
(
    select '入库单' as 类别,cInvCode,cWhCode,cRSCode,iQuantity,iMoney 
    from view_RdRecord a inner join view_RdRecords b on a.ID=b.ID 
    where 2=2 and S11 is null and S12 is null and S13 is null and S14 is null and S15 is null and dVerifysysPerson is not null 
        union all 
    select '入库单' as 类别,S11,cWhCode,cRSCode,D11,D13 
    from view_RdRecord a inner join view_RdRecords b on a.ID=b.ID 
    where 2=2 and S11 is not null and dVerifysysPerson is not null 
        union all 
    select '入库单' as 类别,S12,cWhCode,cRSCode,D14,D16 
    from view_RdRecord a inner join view_RdRecords b on a.ID=b.ID 
    where 2=2 and S12 is not null and dVerifysysPerson is not null 
        union all 
    select '入库单' as 类别,S13,cWhCode,cRSCode,D17,D19 
    from view_RdRecord a inner join view_RdRecords b on a.ID=b.ID 
    where 2=2 and S13 is not null and dVerifysysPerson is not null  
        union all 
    select '入库单' as 类别,S14,cWhCode,cRSCode,D20,D22 
    from view_RdRecord a inner join view_RdRecords b on a.ID=b.ID 
    where 2=2 and S14 is not null and dVerifysysPerson is not null 
        union all 
    select '入库单' as 类别,S15,cWhCode,cRSCode,D23,D25 
    from view_RdRecord a inner join view_RdRecords b on a.ID=b.ID 
    where 2=2 and S15 is not null and dVerifysysPerson is not null 
) a left join RdStyle b on a.cRSCode=b.cRSCode where case when b.收发标志=0 then iQuantity else -iQuantity end>0 

    union all 
select  '销售出库' as 类别,cInvCode,cWhCode,0,0,-iQuantity,-iMoney,0,0 
from view_SO_SOOutMain a inner join view_SO_SOOutDetails b on a.ID=b.ID 
where 2=2 and dVerifysysPerson is not null and a.Flag=2 

            --当期出库
    union all 
select 类别,cInvCode,cWhCode,0 as SQty,0 as SMoney,0 as InQty,0 as InMoney,
case when b.收发标志=0 then iQuantity else -iQuantity end OutQty,
case when b.收发标志=0 then iMoney else -iMoney end OutMoney from
(
    select '入库单' as 类别,cInvCode,cWhCode,cRSCode,iQuantity,iMoney 
    from view_RdRecord a inner join view_RdRecords b on a.ID=b.ID 
    where 2=2 and S11 is null and S12 is null and S13 is null and S14 is null and S15 is null and dVerifysysPerson is not null 
        union all 
    select '入库单' as 类别,S11,cWhCode,cRSCode,D11,D13 
    from view_RdRecord a inner join view_RdRecords b on a.ID=b.ID 
    where 2=2 and S11 is not null and dVerifysysPerson is not null 
        union all 
    select '入库单' as 类别,S12,cWhCode,cRSCode,D14,D16 
    from view_RdRecord a inner join view_RdRecords b on a.ID=b.ID 
    where 2=2 and S12 is not null and dVerifysysPerson is not null 
        union all 
    select '入库单' as 类别,S13,cWhCode,cRSCode,D17,D19 
    from view_RdRecord a inner join view_RdRecords b on a.ID=b.ID 
    where 2=2 and S13 is not null and dVerifysysPerson is not null  
        union all 
    select '入库单' as 类别,S14,cWhCode,cRSCode,D20,D22 
    from view_RdRecord a inner join view_RdRecords b on a.ID=b.ID 
    where 2=2 and S14 is not null and dVerifysysPerson is not null 
        union all 
    select '入库单' as 类别,S15,cWhCode,cRSCode,D23,D25 
    from view_RdRecord a inner join view_RdRecords b on a.ID=b.ID 
    where 2=2 and S15 is not null and dVerifysysPerson is not null 
) a left join RdStyle b on a.cRSCode=b.cRSCode where case when b.收发标志=0 then iQuantity else -iQuantity end<0 

    union all 
select  '销售出库' as 类别,aInvCode,cWhCode,0,0,0,0,-aiQuantity,-isnull(b.D1,0)*iQuantity 
from view_SO_SOOutMain a inner join view_SO_SOOutSublist b on a.ID=b.ID 
where 2=2 and dVerifysysPerson is not null and a.Flag=1 and aInvCode is not null 
    union all 
select  '销售出库' as 类别,cInvCode,cWhCode,0,0,0,0,-iQuantity,-isnull(b.D1,0)*iQuantity 
from view_SO_SOOutMain a inner join view_SO_SOOutSublist b on a.ID=b.ID 
where 2=2 and dVerifysysPerson is not null and a.Flag=1 ";

            string sd=dateEdit1.DateTime.ToString("yyyy-MM-dd");
            string ed=dateEdit2.DateTime.ToString("yyyy-MM-dd");
            sSQL = sSQL.Replace("1=1", "1=1 and dDate<'" + sd + "'");
            sSQL = sSQL.Replace("2=2", "1=1 and dDate between '" + sd + "' and '" + ed + "'");

            if (lookUpEdit存货编码.EditValue != null && lookUpEdit存货编码.EditValue.ToString().Trim() != "")
            {
                sSQL = sSQL.Replace("1=1", "1=1 and b.cInvCode='" + lookUpEdit存货编码.EditValue.ToString().Trim() + "'");
                sSQL = sSQL.Replace("2=2", "2=2 and b.cInvCode='" + lookUpEdit存货编码.EditValue.ToString().Trim() + "'");
            }

            sSQL = @"select  b.cInvClassCode,a.cInvCode,
sum(SQty) as SQty,
sum(SMoney) as SMoney,
case when sum(SQty)<>0 then sum(SMoney)/sum(SQty) else 0 end as SPrice,

sum(InQty) as InQty,
sum(InMoney) as InMoney,
case when sum(InQty)<>0 then sum(InMoney)/sum(InQty) else 0 end as InPrice,

-sum(OutQty) as OutQty,
-sum(OutMoney) as OutMoney,
case when (sum(OutQty)+sum(InQty))<>0 then -(sum(SMoney)+sum(InMoney))/(sum(OutQty)+sum(InQty)) else 0 end as OutPrice,

sum(SQty)+sum(InQty)+sum(OutQty) as EQty,
sum(SMoney)+sum(InMoney)+sum(OutMoney) as EMoney,
case when (sum(SQty)+sum(InQty)+sum(OutQty))<>0 then (sum(SMoney)+sum(InMoney)+sum(OutMoney))/(sum(SQty)+sum(InQty)+sum(OutQty)) else 0 end as EPrice 

            from (" + sSQL + ") a left join Inventory b on a.cInvCode=b.cInvCode where 3=3 group by b.cInvClassCode,a.cInvCode order by b.cInvClassCode,a.cInvCode";


            if (lookUpEdit存货分类.EditValue != null && lookUpEdit存货分类.EditValue.ToString().Trim() != "")
            {
                sSQL = sSQL.Replace("3=3", "3=3 and b.cInvClassCode='" + lookUpEdit存货分类.EditValue.ToString().Trim() + "'");
            }
            DataTable dt = clsSQLCommond.ExecQuery(sSQL);

            return dt;
        }

        private void gridView1_CellValueChanged(object sender, DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs e)
        {
            
        }

        private void gridView1_CustomDrawRowIndicator(object sender, DevExpress.XtraGrid.Views.Grid.RowIndicatorCustomDrawEventArgs e)
        {
            try
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
            catch { }
        }

        private void buttonEdit存货分类_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            系统服务.Frm参照 frm = new 系统服务.Frm参照(7);
            if (DialogResult.OK == frm.ShowDialog())
            {
                buttonEdit存货分类.EditValue = frm.sID;
                frm.Enabled = true;
            }
        }

        private void buttonEdit存货分类_EditValueChanged(object sender, EventArgs e)
        {
            if (buttonEdit存货分类.Text.Trim() != "")
                lookUpEdit存货分类.EditValue = buttonEdit存货分类.Text.Trim();
            else
                lookUpEdit存货分类.EditValue = null;
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
            系统服务.Frm参照 frm = new 系统服务.Frm参照(1);
            if (DialogResult.OK == frm.ShowDialog())
            {
                buttonEdit存货编码.EditValue = frm.sID;

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
                lookUpEdit存货编码.EditValue = null;
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
