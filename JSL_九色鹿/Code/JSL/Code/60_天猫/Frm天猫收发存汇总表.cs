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
    public partial class Frm天猫收发存汇总表 : 系统服务.FrmBaseInfo
    {
        DateTime Date1;
        DateTime Date2;
        
        public Frm天猫收发存汇总表()
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

        private void Frm天猫收发存汇总表_Load(object sender, EventArgs e)
        {
            try
            {
                GetLayOut(layoutControl1, gridControl1);

                dateEdit1.EditValue = DateTime.Now.AddMonths(-1).ToString("yyyy-MM-dd");
                dateEdit2.EditValue = DateTime.Now.ToString("yyyy-MM-dd");
                SetLookUpEdit();
                //GetGrid();
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
            系统服务.LookUp.ColorNo(lookUpEditM1);
            系统服务.LookUp.Warehouse(ItemLookUpEdit仓库);
            系统服务.LookUp.Position(ItemLookUpEdit货位);
        }

        private void GetGrid()
        {
            string sErr = "";
            if (dateEdit1.EditValue == null && dateEdit2.EditValue == null)
            {
                throw new Exception("时间区域不可为空");
            }

            gridControl1.DataSource = Get();


            GetShow(false);
        }

        private void GetShow(bool b)
        {
            gridView1.OptionsBehavior.Editable = false;
        }


        private DataTable Get()
        {
            #region
            string group = "";
            for (int i = 0; i < checkedListBoxControl1.ItemCount; i++)
            {
                if (checkedListBoxControl1.Items[i].CheckState == CheckState.Checked)
                {
                    if (group != "")
                    {
                        group = group + ",";
                    }
                    group = group + "a." + checkedListBoxControl1.Items[i].Value;
                    if (checkedListBoxControl1.Items[i].Value.ToString() == "M1")
                    {
                        gridColM1.Visible = true;
                    }
                    else if (checkedListBoxControl1.Items[i].Value.ToString() == "M2")
                    {
                        gridColM2.Visible = true;
                    }
                    else if (checkedListBoxControl1.Items[i].Value.ToString() == "cWhCode")
                    {
                        gridCol仓库.Visible = true;
                    }
                    else if (checkedListBoxControl1.Items[i].Value.ToString() == "cPosCode")
                    {
                        gridCol货位.Visible = true;
                    }
                }
                else
                {
                    if (checkedListBoxControl1.Items[i].Value.ToString() == "M1")
                    {
                        gridColM1.Visible = false;
                    }
                    else if (checkedListBoxControl1.Items[i].Value.ToString() == "M2")
                    {
                        gridColM2.Visible = false;
                    }
                    else if (checkedListBoxControl1.Items[i].Value.ToString() == "cWhCode")
                    {
                        gridCol仓库.Visible = false;
                    }
                    else if (checkedListBoxControl1.Items[i].Value.ToString() == "cPosCode")
                    {
                        gridCol货位.Visible = false;
                    }
                }
            }
            #endregion
            string chk = "";
            if (this.Text.IndexOf("成品") > -1 && this.Text.IndexOf("半成品") == -1)
            {
                chk = chk + "'01'";
                gridCol出库数量.Visible = false;
                gridCol入库数量.Visible = false;
            }
            else
            {
                if (chk != "")
                {
                    chk = chk + ",";
                }
                chk = chk + "'02','03','04'";
                gridCol期初结存盒数.Visible = false;
                gridCol入库盒数.Visible = false;
                gridCol出库盒数.Visible = false;
                gridCol期末结存盒数.Visible = false;
                gridCol其他成品盒数.Visible = false;
                gridCol成品盒数.Visible = false;
            }

            string sd = dateEdit1.DateTime.ToString("yyyy-MM-dd");
            string ed = dateEdit2.DateTime.ToString("yyyy-MM-dd");

            sSQL = @"
select dDate,cRSCode,Flag,cInvCode,M1,M2,cWhCode,cPosCode,sum(iQuantity) as iQuantity,sum(iMoney) as iMoney,sum(sBoxQty) as sBoxQty,0 as cpsBoxQty into #rd 
from RdRecord01 a inner join RdRecords01 b on a.ID=b.ID 
where  dVerifysysPerson is not null 
    and 55=55
group by dDate,cRSCode,Flag,cInvCode,M1,M2,cWhCode,cPosCode

insert into #rd select dDate,cRSCode,Flag,cInvCode,M1,M2,cWhCode,cPosCode,sum(iQuantity) as iQuantity,sum(iMoney) as iMoney,sum(sBoxQty) as sBoxQty,0 as cpsBoxQty 
from RdRecord02 a inner join RdRecords02 b on a.ID=b.ID 
where  dVerifysysPerson is not null 
    and 55=55
group by dDate,cRSCode,Flag,cInvCode,M1,M2,cWhCode,cPosCode

insert into #rd 
select dDate,cRSCode,Flag,cInvCode,M1,M2,cWhCode,cPosCode,sum(iQuantity) as iQuantity,sum(iMoney) as iMoney,sum(sBoxQty) as sBoxQty,sum(sBoxQty) as cpsBoxQty 
from RdRecord03 a inner join RdRecords03 b on a.ID=b.ID 
where  dVerifysysPerson is not null 
    and 55=55
group by dDate,cRSCode,Flag,cInvCode,M1,M2,cWhCode,cPosCode

insert into #rd 
select dDate,cRSCode,Flag,cInvCode,M1,M2,cWhCode,cPosCode,sum(iQuantity) as iQuantity,sum(iMoney) as iMoney,sum(sBoxQty) as sBoxQty,0 as cpsBoxQty 
from RdRecord05 a inner join RdRecords05 b on a.ID=b.ID 
where  dVerifysysPerson is not null 
    and 55=55
group by dDate,cRSCode,Flag,cInvCode,M1,M2,cWhCode,cPosCode

insert into #rd 
select dDate,cRSCode,Flag,cInvCode,M1,M2,cWhCode,cPosCode,sum(iQuantity) as iQuantity,sum(iMoney) as iMoney,sum(sBoxQty) as sBoxQty,0 as cpsBoxQty 
from RdRecord11 a inner join RdRecords11 b on a.ID=b.ID 
where  dVerifysysPerson is not null 
    and 55=55
group by dDate,cRSCode,Flag,cInvCode,M1,M2,cWhCode,cPosCode

insert into #rd 
select dDate,cRSCode,Flag,cInvCode,M1,M2,cWhCode,cPosCode,sum(iQuantity) as iQuantity,sum(iMoney) as iMoney,sum(sBoxQty) as sBoxQty,0 as cpsBoxQty 
from RdRecord12 a inner join RdRecords12 b on a.ID=b.ID 
where  dVerifysysPerson is not null 
    and 55=55
group by dDate,cRSCode,Flag,cInvCode,M1,M2,cWhCode,cPosCode

insert into #rd 
select dDate,cRSCode,Flag,cInvCode,M1,M2,cWhCode,cPosCode,sum(iQuantity) as iQuantity,sum(iMoney) as iMoney,sum(sBoxQty) as sBoxQty,sum(sBoxQty) as cpsBoxQty 
from RdRecord13 a inner join RdRecords13 b on a.ID=b.ID 
where  dVerifysysPerson is not null 
    and 55=55
group by dDate,cRSCode,Flag,cInvCode,M1,M2,cWhCode,cPosCode

insert into #rd 
select dDate,cRSCode,Flag,cInvCode,M1,M2,cWhCode,cPosCode,sum(iQuantity) as iQuantity,sum(iMoney) as iMoney,sum(sBoxQty) as sBoxQty,0 as cpsBoxQty 
from RdRecord15 a inner join RdRecords15 b on a.ID=b.ID 
where  dVerifysysPerson is not null 
    and 55=55
group by dDate,cRSCode,Flag,cInvCode,M1,M2,cWhCode,cPosCode

--期初
select 
cInvCode,M1,M2,cWhCode,cPosCode,
sum(case when r.收发标志=0 then iQuantity else -iQuantity end) SQty,
sum(case when r.收发标志=0 then iMoney else -iMoney end) SMoney,
sum(case when r.收发标志=0 then sBoxQty else -sBoxQty end) SBoxQty,
convert(decimal(18, 2),null) as InQty,convert(decimal(18, 2),null) as InMoney,convert(int,null) as InBoxQty,
convert(decimal(18, 2),null) as OutQty,convert(decimal(18, 2),null) as OutMoney,convert(int,null) as OutBoxQty,convert(decimal(18, 2),null) as 退货数量,convert(decimal(18, 2),null) as 退货盒数,
sum(case when r.收发标志=0 then cpsBoxQty else -cpsBoxQty end) as cpsBoxQty
into #a 
from #rd a left join RdStyle r on a.cRSCode=r.cRSCode 
where 1=1  
group by cInvCode,M1,M2,cWhCode,cPosCode

--当期入库
insert into #a
select 
cInvCode,M1,M2,cWhCode,cPosCode,
0 as SQty,0 as SMoney,0 as SBoxQty,
sum(case when r.收发标志=0 then iQuantity end) as InQty,
sum(case when r.收发标志=0 then iMoney end) as InMoney,
sum(case when r.收发标志=0 then sBoxQty end) as InBoxQty,
sum(case when r.收发标志=1 then iQuantity end) as OutQty,
sum(case when r.收发标志=1 then iMoney end) as OutMoney,
sum(case when r.收发标志=1 then sBoxQty end) as OutBoxQty,
sum(case when flag=2 then iQuantity end) as 退货数量,sum(case when flag=2 then sBoxQty end) as 退货盒数,
sum(case when r.收发标志=0 then cpsBoxQty else -cpsBoxQty end) as cpsBoxQty 
from #rd a 
left join RdStyle r on a.cRSCode=r.cRSCode 
where 2=2 
group by cInvCode,M1,M2,cWhCode,cPosCode

select a.S1,b.D1 into #i from 
(select b.S1,max(b.AutoID) as AutoID from PriceAdjust_Details b left join PriceAdjust_Main a on a.ID=b.ID 
where  BB1=0 and S2='02'
group by b.S1) a 
left join PriceAdjust_Details b on a.AutoID=b.AutoID

select  b.cInvClassCode,a.cInvCode,
convert(decimal(18, 2),sum(SQty)) as SQty,
--convert(decimal(18, 2),sum(SMoney)) as SMoney,
convert(decimal(18, 2),sum(SBoxQty)) as SBoxQty,

convert(decimal(18, 2),sum(InQty)) as InQty,
--convert(decimal(18, 2),sum(InMoney)) as InMoney,
convert(decimal(18, 2),sum(InBoxQty)) as InBoxQty,

convert(decimal(18, 2),sum(OutQty)) as OutQty,
--convert(decimal(18, 2),sum(OutMoney)) as OutMoney,
convert(decimal(18, 2),sum(OutBoxQty)) as OutBoxQty,

convert(decimal(18, 2),sum(isnull(convert(decimal(18, 2),SQty),0)+isnull(convert(decimal(18, 2),InQty),0)-isnull(convert(decimal(18, 2),OutQty),0))) as EQty,
--convert(decimal(18, 2),sum(isnull(SMoney,0)+isnull(InMoney,0)-isnull(OutMoney,0))) as EMoney,
convert(decimal(18, 2),sum(isnull(SBoxQty,0)+isnull(InBoxQty,0)-isnull(OutBoxQty,0))) as EBoxQty ,
sum(退货数量) as 退货数量,sum(退货盒数) as 退货盒数,
isnull(sum(cpsBoxQty),0) as 成品盒数,convert(decimal(18, 2),sum(isnull(SBoxQty,0)+isnull(InBoxQty,0)-isnull(OutBoxQty,0))-isnull(sum(cpsBoxQty),0)) as 其他成品盒数 
111111111111111111111111111  

          into #b   from #a a left join Inventory b on a.cInvCode=b.cInvCode where 3=3 group by b.cInvClassCode,a.cInvCode 111111111111111111111111111 order by b.cInvClassCode,a.cInvCode 111111111111111111111111111 

select #b.*,
convert(decimal(18, 2),case when SBoxQty<>0 then #i.D1 end) as SPrice,
convert(decimal(18, 2),case when InBoxQty<>0 then #i.D1 end) as InPrice,
convert(decimal(18, 2),case when OutBoxQty<>0 then #i.D1 end) as OutPrice,
convert(decimal(18, 2),case when EBoxQty<>0 then #i.D1 end) as EPrice,

convert(decimal(18, 2),case when SBoxQty<>0 then #i.D1*SBoxQty end) as SMoney,
convert(decimal(18, 2),case when InBoxQty<>0 then #i.D1*InBoxQty end) as InMoney,
convert(decimal(18, 2),case when OutBoxQty<>0 then #i.D1*OutBoxQty end) as OutMoney,
convert(decimal(18, 2),case when EBoxQty<>0 then #i.D1*EBoxQty end) as EMoney
 from #b left join #i on #b.cInvCode=#i.S1
";

            sSQL = sSQL.Replace("1=1", "1=1 and convert(varchar(10),dDate,120)<'" + sd + "'");
            sSQL = sSQL.Replace("2=2", "2=2 and convert(varchar(10),dDate,120) between '" + sd + "' and '" + ed + "'");

            if (lookUpEdit存货编码.EditValue != null && lookUpEdit存货编码.EditValue.ToString().Trim() != "")
            {
                sSQL = sSQL.Replace("1=1", "1=1 and cInvCode='" + lookUpEdit存货编码.EditValue.ToString().Trim() + "'");
                sSQL = sSQL.Replace("2=2", "2=2 and cInvCode='" + lookUpEdit存货编码.EditValue.ToString().Trim() + "'");
                sSQL = sSQL.Replace("55=55", "55=55 and b.cInvCode='" + lookUpEdit存货编码.EditValue.ToString().Trim() + "'");
            }
            if (group == "")
            {
                sSQL = sSQL.Replace("111111111111111111111111111", " ");
            }
            else
            {
                sSQL = sSQL.Replace("111111111111111111111111111", "," + group);
            }
            if (lookUpEdit存货分类.EditValue != null && lookUpEdit存货分类.EditValue.ToString().Trim() != "")
            {
                sSQL = sSQL.Replace("3=3", "3=3 and b.cInvClassCode='" + lookUpEdit存货分类.EditValue.ToString().Trim() + "'");
            }
            if (lookUpEditM1.EditValue != null && lookUpEditM1.EditValue.ToString().Trim() != "")
            {
                sSQL = sSQL.Replace("3=3", "3=3 and a.M1='" + lookUpEditM1.EditValue.ToString().Trim() + "'");
                sSQL = sSQL.Replace("55=55", "55=55 and b.M1='" + lookUpEditM1.EditValue.ToString().Trim() + "'");
            }
            if (textEditM2.Text.Trim() != "")
            {
                sSQL = sSQL.Replace("3=3", "3=3 and a.M2 like '%" + textEditM2.EditValue.ToString().Trim() + "%'");
                sSQL = sSQL.Replace("55=55", "55=55 and b.M2 like '%" + textEditM2.EditValue.ToString().Trim() + "%'");
            }
            if (chk != "")
            {
                sSQL = sSQL.Replace("3=3", "3=3 and b.cInvClassCode in (" + chk + ")");
            }
            if (checkBox1.Checked == true)
            {
                if (this.Text.IndexOf("成品") > -1 && this.Text.IndexOf("半成品") == -1)
                {
                    sSQL = sSQL + " where EBoxQty<>0";
                }
                else
                {
                    sSQL = sSQL + " where EQty<>0";
                }
            }
            DataTable dt = clsSQLCommond.ExecQuery(sSQL);
            return dt;
        }

        private string ReturnQC(string tablename,string tablenames,int x)
        {
            string sSQL1= @"
insert into #a select b.cInvCode,b.M1,b.M2,cWhCode,cPosCode
,333333
,0,0,0
,0,0,0
,0,0,0,0 
into #a 
from 111111 a inner join 222222 b on a.ID=b.ID left join Inventory i on b.cInvCode=i.cInvCode
where 1=1 and dVerifysysPerson is not null group by b.cInvCode,b.M1,b.M2,cWhCode,cPosCode

insert into #a select b.cInvCode,b.M1,b.M2,cWhCode,cPosCode
,0,0,0
,444444
,0,0,0
0 as 退货数量,0 as 退货盒数,
0 成品盒数,0 其他成品盒数 
from 111111 a inner join 222222 b on a.ID=b.ID left join Inventory i on b.cInvCode=i.cInvCode
where 1=1 and dVerifysysPerson is not null group by b.cInvCode,b.M1,b.M2,cWhCode,cPosCode

insert into #a select b.cInvCode,b.M1,b.M2,cWhCode,cPosCode
,0,0,0
,0,0,0
,555555
0 as 退货数量,0 as 退货盒数,
0 成品盒数,0 其他成品盒数 
from 111111 a inner join 222222 b on a.ID=b.ID left join Inventory i on b.cInvCode=i.cInvCode
where 1=1 and dVerifysysPerson is not null group by b.cInvCode,b.M1,b.M2,cWhCode,cPosCode
";
            sSQL1 = sSQL1.Replace("111111", tablename);
            sSQL1 = sSQL1.Replace("222222", tablenames);
            if (x == 0)//入库单据
            {
                sSQL1 = sSQL1.Replace("333333", "sum(iQuantity),sum(iMoney),sum(sBoxQty)");
                sSQL1 = sSQL1.Replace("444444", "sum(iQuantity),sum(iMoney),sum(sBoxQty)");
                sSQL1 = sSQL1.Replace("555555", "sum(iQuantity),sum(iMoney),sum(sBoxQty)");
            }
            else//出库单据
            {
                sSQL1 = sSQL1.Replace("333333", "-sum(iQuantity),-sum(iMoney),-sum(sBoxQty)");
                sSQL1 = sSQL1.Replace("444444", "-sum(iQuantity),-sum(iMoney),-sum(sBoxQty)");
                sSQL1 = sSQL1.Replace("555555", "sum(iQuantity),sum(iMoney),sum(sBoxQty)");
            }
            return sSQL1;
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

        private void buttonEditM1_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            系统服务.Frm参照 frm = new 系统服务.Frm参照(24);
            if (DialogResult.OK == frm.ShowDialog())
            {
                buttonEditM1.EditValue = frm.sID;
                frm.Enabled = true;
            }
        }

        private void buttonEditM1_EditValueChanged(object sender, EventArgs e)
        {
            if (buttonEditM1.Text.Trim() != "")
            {
                lookUpEditM1.EditValue = buttonEditM1.Text.Trim();
            }
            else
            {
                lookUpEditM1.EditValue = null;
            }
        }

        private void buttonEditM1_Leave(object sender, EventArgs e)
        {
            if (buttonEditM1.Text.Trim() == "")
                return;
            if (lookUpEditM1.Text.Trim() == "")
            {
                buttonEditM1.Text = "";
                buttonEditM1.Focus();
            }
        }


    }
}
