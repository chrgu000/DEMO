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

namespace 报表
{
    public partial class Frm应收款明细表 : 系统服务.FrmBaseInfo
    {

        public Frm应收款明细表()
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

        private void Frm应收款明细表_Load(object sender, EventArgs e)
        {
            try
            {
                SetLookUpEdit();
                dateEdit截止于.EditValue = DateTime.Now.ToString("yyyy-MM-dd");
                GetGrid();

            }
            catch (Exception ee)
            {
                MessageBox.Show("加载窗体失败\n" + ee.Message);
            }
        }

        private void GetGrid()
        {
            if (dateEdit截止于.EditValue != null && dateEdit截止于.EditValue.ToString().Trim() != "")
            {
                string cCusCode = "";
                string cPersonCode = "";
                if (lookUpEdit客户.EditValue != null)
                {
                    cCusCode = lookUpEdit客户.EditValue.ToString().Trim();
                }
                if (lookUpEdit业务员.EditValue != null)
                {
                    cPersonCode = lookUpEdit业务员.EditValue.ToString().Trim();
                }
                
                DataTable dt = Table(dateEdit截止于.EditValue.ToString(), cCusCode, cPersonCode);
                gridControl1.DataSource = dt;
            }
            else
            {
                MessageBox.Show("请输入截止日期");
            }
        }


        public static DataTable Table(string endtime, string cCusCode, string cPersonCode)
        {
            系统服务.ClsDataBase clsSQLCommond = 系统服务.ClsDataBaseFactory.Instance();
            endtime = DateTime.Parse(endtime).ToString("yyyy-MM-dd");
            string sSQL = @"

SELECT     1 as type,cCusCode,cSTCode, iMoney,dDate,dDate as 记账日期,cPersonCode as 记账销售,cDepCode as 记账部门 
into #a
FROM   SO_SOMain a left join  SO_SODetails b on a.ID=b.ID 
where 1=1  and a.dDate<= 5=5  and a.dVerifysysTime is not null 
   
    
insert into #a
select 2 as type,a.cCusCode, cSTCode,b.iMoney,a.dDate,d.dDate as 记账日期,d.cPersonCode as 记账销售,d.cDepCode as 记账部门
from SO_SOReturn a left join SO_SOReturns b on a.ID=b.ID 
left join view_SO_SODetails c on b.SoAutoID=c.AutoID left join view_SO_SOMain d on c.ID=d.ID where 1=1 and a.dDate<= 5=5   and a.dVerifysysTime is not null 

insert into #a
select 4 as type,a.cCusCode,a.cSTCode,-b.iMoney,a.dDate,d.dDate as 记账日期,d.cPersonCode as 记账销售,d.cDepCode as 记账部门
from RdRecord a left join RdRecords b on a.ID=b.ID left join SO_SODetails c on a.SoAutoID=c.AutoID left join SO_SOMain d on c.ID=d.ID
    left join RdStyle on a.cRSCode=RdStyle.cRSCode  where 1=1 and a.dDate<=  5=5   and RdStyle.B2=1 and RdStyle.S1=2  and a.dVerifysysTime is not null 
    
insert into #a
select 5 as type,a.cCusCode,a.cSTCode,-iMoneyNow,a.dDate,c.dDate as 记账日期,c.cPersonCode as 记账销售,c.cDepCode as 记账部门
from SO_CloseBill a left join SO_CloseBillDetails b on a.ID=b.ID 
    left join view_SO_SOMain c on b.cTypeCode=c.cSOCode where 1=1 and a.dDate<=  5=5   and iType=2  and a.dVerifysysTime is not null 

insert into #a
select 9 as type, a.cCusCode,a.cSTCode,-a.iAmount+ISNULL(b.iMoneyNow,0) as iMoney,a.dDate,a.dDate as 记账日期,a.cPersonCode as 记账销售,a.cDepCode as 记账部门 
from SO_CloseBill a left join (select ID,sum(iMoneyNow) as iMoneyNow from SO_CloseBillDetails group by ID) b on a.ID=b.ID 
where 1=1 and a.dDate<=  5=5 and a.dVerifysysTime is not null 

--期初
insert into #a
select 6 as type,S1 as cCusCode,S5 as cSTCode,D1 as iMoney,Date1 as  dDate ,Date1 as  记账日期,S3 as 记账销售,S4 as 记账部门
from AR_First where 2=2 and Date1 <=   5=5

insert into #a
select 7 as type,a.cCusCode,a.cSTCode,-iMoneyNow,a.dDate
	,case when c.Date1 is null then d.Date1 else c.Date1 end as 记账日期
	,case when c.S3 is null then d.s3 else c.s3 end as 记账销售
	,case when c.S4 is null then d.S4 else c.s3 end as 记账部门
from SO_CloseBill a left join SO_CloseBillDetails b on a.ID=b.ID 
	left join AR_First c on b.cTypeCode=c.iid 
	left join [SysDB_RQSW_2013_20170617]..AR_First d on b.cTypeCode=d.iid 
where 1=1 and a.dDate<=  5=5  and iType=1  and a.dVerifysysTime is not null

insert into #a
select 8 as type,a.cCusCode,a.cSTCode,-b.iMoney,a.dDate,f.Date1 as 记账日期,f.S3 as 记账销售,f.S4 as 记账部门
from RdRecord a left join RdRecords b on a.ID=b.ID
    left join RdStyle on a.cRSCode=RdStyle.cRSCode left join AR_First f on ARiID=f.iid   
where 1=1 and a.dDate<=  5=5    and RdStyle.B2=1 and RdStyle.S1=1  and a.dVerifysysTime is not null 

select *,case when (select top 1 aIntPPerson from view_CustomersAdjust where cCusCode=aIntCode and  aIntAdjustTime<= 5=5  order by aIntAdjustTime desc) IS not null 
    then (select top 1 aIntPPerson from view_CustomersAdjust where cCusCode=aIntCode and  aIntAdjustTime<=  5=5  order by aIntAdjustTime desc) 
    else 记账销售 end cPersonCode 
into #b 
from #a 

select *
    ,case when (select top 1 aIntDepCode from view_CustomersAdjust where cCusCode=aIntCode and  aIntAdjustTime<=  5=5 order by aIntAdjustTime desc) IS not null 
        then (select top 1 aIntDepCode from view_CustomersAdjust where cCusCode=aIntCode and  aIntAdjustTime<=  5=5 order by aIntAdjustTime desc) 
        else 记账部门 end cDepCode  
into #c 
from #b

select cCusCode,cSTCode,cPersonCode,CONVERT(decimal(18, 2),sum(iMoney))  as iMoney from #c  where 1111111111111111  group by cCusCode,cSTCode,cPersonCode having CONVERT(decimal(18, 2),sum(iMoney))<>0
";

            sSQL = sSQL.Replace("5=5", " '" + endtime + "'  ");
            string s="1=1 ";
            if (cPersonCode != "")
            {
                s = s + " and cPersonCode='" + cPersonCode + "' ";
            }

            if (cCusCode != "")
            {
                s = s + " and cCusCode='" + cCusCode + "' ";
            }
            

            sSQL = sSQL.Replace("1111111111111111",  s );
            return clsSQLCommond.ExecQuery(sSQL);
        }


        /// <summary>
        /// 下拉列表框
        /// </summary>
        private void SetLookUpEdit()
        {
            系统服务.LookUp.SaleTypeAll(ItemLookUpEdit销售类型);

            系统服务.LookUp.Person(ItemLookUpEdit业务员);
            系统服务.LookUp.Customer(ItemLookUpEdit客户);
            系统服务.LookUp.Customer(ItemLookUpEdit部门);

            系统服务.LookUp.Person(lookUpEdit业务员);
            系统服务.LookUp.Customer(lookUpEdit客户);
        }

        private void buttonEdit业务员_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            系统服务.Frm参照 frm = new 系统服务.Frm参照(2);
            if (DialogResult.OK == frm.ShowDialog())
            {
                buttonEdit业务员.EditValue = frm.sID;

                frm.Enabled = true;
            }
        }

        private void buttonEdit客户_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            系统服务.Frm参照 frm = new 系统服务.Frm参照(9);
            if (DialogResult.OK == frm.ShowDialog())
            {
                buttonEdit客户.EditValue = frm.sID;
                frm.Enabled = true;
            }
        }

        private void buttonEdit业务员_EditValueChanged(object sender, EventArgs e)
        {
            if (buttonEdit业务员.Text.Trim() != "")
            {
                lookUpEdit业务员.EditValue = buttonEdit业务员.Text.Trim();
            }
            else
            {
                lookUpEdit业务员.EditValue = null;
            }
        }

        private void buttonEdit客户_EditValueChanged(object sender, EventArgs e)
        {
            if (buttonEdit客户.Text.Trim() != "")
            {
                lookUpEdit客户.EditValue = buttonEdit客户.Text.Trim();
            }
            else
            {
                buttonEdit客户.EditValue = null;
                lookUpEdit客户.EditValue = null;
            }
        }

        private void buttonEdit客户_Leave(object sender, EventArgs e)
        {
            if (buttonEdit客户.Text.Trim() == "")
                return;
            if (lookUpEdit客户.Text.Trim() == "")
            {
                buttonEdit客户.Text = "";
                buttonEdit客户.Focus();
            }
        }

        private void buttonEdit业务员_Leave(object sender, EventArgs e)
        {
            if (buttonEdit业务员.Text.Trim() == "")
                return;
            if (lookUpEdit业务员.Text.Trim() == "")
            {
                buttonEdit业务员.Text = "";
                buttonEdit业务员.Focus();
            }
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
