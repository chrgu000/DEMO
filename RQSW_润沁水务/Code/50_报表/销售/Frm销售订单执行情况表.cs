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
    public partial class Frm销售订单执行情况表 : 系统服务.FrmBaseInfo
    {

        public Frm销售订单执行情况表()
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

        string sCusCode = "";

        public Frm销售订单执行情况表(string CusCode)
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

            sCusCode = CusCode;

            gridCol8位数编码.Visible = false;
            gridCol已出库数量.Visible = false;
            gridCol已出库金额.Visible = false;
            gridCol未出库数量.Visible = false;
            gridCol未出库金额.Visible = false;
            gridCol业务招待费金额.Visible = false;
            gridCol已申请业务招待费.Visible = false;
            gridCol未申请业务招待费.Visible = false;
            gridCol利润.Visible = false;
            gridCol已分配利润.Visible = false;
            gridCol未分配利润.Visible = false;
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

        private void Frm销售订单执行情况表_Load(object sender, EventArgs e)
        {
            try
            {
                SetLookUpEdit();
                dateEdit1.EditValue = DateTime.Now.AddMonths(-1).ToString("yyyy-MM-dd");
                dateEdit2.EditValue = DateTime.Now.ToString("yyyy-MM-dd");

                if (sCusCode.Trim() != "")
                {
                    buttonEdit客户.Text = sCusCode;
                    dateEdit1.DateTime = Convert.ToDateTime("2000-01-01");

                    GetGrid();
                }
                //GetGrid();

            }
            catch (Exception ee)
            {
                MessageBox.Show("加载窗体失败\n" + ee.Message);
            }
        }

        private void GetGrid()
        {

            sSQL = @"
select a.cSOCode
	,a.dDate,a.ECode,a.cCusCode,a.cPersonCode,a.cDepCode,a.cSTCode,b.cInvCode,b.iQuantity,b.iUnitPrice,b.iMoney, 
	OutiQuantity,OutiMoney,b.iQuantity-isnull(OutiQuantity,0) as NotOutiQuantity,b.iMoney-isnull(OutiMoney,0) as NotOutiMoney,
	BilliQuantity,BilliMoney,b.iQuantity-isnull(BilliQuantity,0) as NotBilliQuantity,b.iMoney-isnull(BilliMoney,0) as NotBilliMoney,cSBVCode,BilldDate,
	isnull(CloseiMoney,0)+isnull(v.iMoney,0) as CloseiMoney,ClosedDate,b.iMoney-isnull(CloseiMoney,0)-isnull(v.iMoney,0)+(case when b.iMoney-isnull(CloseiMoney,0)-isnull(v.iMoney,0)>0 then isnull(r.iMoney,0) end) as NotCloseiMoney,
	CommiMoney,AppCommiMoney,CommiMoney-isnull(AppCommiMoney,0) as NotAppCommiMoney ,Profits1,b.iMoney-ISNULL(Profits1,0)-ISNULL(CommiMoney,0) as Profits,v.iMoney as 核销金额, 
	case when b.iMoney-isnull(CloseiMoney,0)-isnull(v.iMoney,0)>0 then isnull(r.iMoney,0) end  as 退货 
from SO_SOMain a left join SO_SODetails b on a.ID=b.ID 
	left join (select SoAutoID,sum(iQuantity) as OutiQuantity,sum(iMoney) as OutiMoney from SO_SOOutDetails group by SoAutoID) c on b.AutoID=c.SoAutoID 
	left join (select SoAutoID,sum(iQuantity) as BilliQuantity,sum(iMoney) as BilliMoney,max(a.cSBVCode) as cSBVCode,max(dDate) as BilldDate 
					from SaleBillVouchs a left join SaleBillVouch b on a.ID=b.ID group by SoAutoID
				) d on b.AutoID=d.SoAutoID 
	left join (select cTypeCode,sum(iMoneyNow) as CloseiMoney,max(dDate) as ClosedDate from SO_CloseBillDetails a left join SO_CloseBill b on a.ID=b.ID group by cTypeCode) e on a.cSOCode=e.cTypeCode 
	left join (select ID,sum(DD1*DD2) as CommiMoney from SO_SOMainCommissiion group by ID) f on a.ID=f.ID 
	left join (select b.ID,sum(a.DD1*a.DD2) as AppCommiMoney from Commissions a left join SO_SOMainCommissiion b on a.CID=b.CID group by b.ID) g on a.ID=g.ID 
	left join (select b.ID,sum(a.iQuantity*a.D1) as Profits1 from SO_SOSublist a left join SO_SODetails b on a.AutoID=b.AutoID group by b.ID) h on a.ID=h.ID 
	left join (select sum(iMoney) as iMoney,b.SoAutoID from SaleVerification a left join SaleVerifications b on a.ID=b.ID where 1=1 and dVerifysysTime is not null group by b.SoAutoID) v on b.AutoID=v.SoAutoID
	left join (select sum(iMoney) as iMoney,sum(iQuantity) as iQuantity,b.SoAutoID 
					from SO_SOReturn a left join SO_SOReturns b on a.ID=b.ID where 1=1 and dVerifysysTime is not null group by b.SoAutoID
				) r on b.AutoID=r.SoAutoID
where 1=1 
";
            if (dateEdit1.EditValue != null && dateEdit1.EditValue.ToString().Trim() != "")
            {
                sSQL = sSQL + " and a.dDate>='" + dateEdit1.EditValue.ToString().Trim() + "'";
            }
            if (dateEdit2.EditValue != null && dateEdit2.EditValue.ToString().Trim() != "")
            {
                sSQL = sSQL + " and a.dDate<='" + dateEdit2.EditValue.ToString().Trim() + "'";
            }

            if (lookUpEdit客户.EditValue != null && lookUpEdit客户.EditValue.ToString().Trim() != "")
            {
                sSQL = sSQL + " and a.cCusCode='" + lookUpEdit客户.EditValue.ToString().Trim() + "'";
            }
            if (lookUpEdit业务员.EditValue != null && lookUpEdit业务员.EditValue.ToString().Trim() != "")
            {
                sSQL = sSQL + " and a.cPersonCode='" + lookUpEdit业务员.EditValue.ToString().Trim() + "'";
            }
            if (lookUpEdit部门.EditValue != null && lookUpEdit部门.EditValue.ToString().Trim() != "")
            {
                sSQL = sSQL + " and a.cDepCode='" + lookUpEdit部门.EditValue.ToString().Trim() + "'";
            }
            if (textEdit8位数编码.EditValue != null && textEdit8位数编码.EditValue.ToString().Trim() != "")
            {
                sSQL = sSQL + " and a.ECode='" + textEdit8位数编码.EditValue.ToString().Trim() + "'";
            }
            sSQL = sSQL + @"
order by a.dDate
";
            DataTable dt = clsSQLCommond.ExecQuery(sSQL);
            gridControl1.DataSource = dt;
        }

        /// <summary>
        /// 下拉列表框
        /// </summary>
        private void SetLookUpEdit()
        {
            系统服务.LookUp.SaleTypeAll(ItemLookUpEdit销售类型);
            系统服务.LookUp.Inventory(ItemLookUpEdit产品);
            系统服务.LookUp.ShippingChoice(ItemLookUpEdit送货方式);

            系统服务.LookUp.Person(ItemLookUpEdit业务员);
            系统服务.LookUp.Customer(ItemLookUpEdit客户);
            系统服务.LookUp.Department(ItemLookUpEdit部门);

            系统服务.LookUp.Person(lookUpEdit业务员);
            系统服务.LookUp.Customer(lookUpEdit客户);
            系统服务.LookUp.Department(lookUpEdit部门);
            
        }

        private void gridView1_CellValueChanged(object sender, DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs e)
        {
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

        private void buttonEdit部门_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            系统服务.Frm参照 frm = new 系统服务.Frm参照(3);
            if (DialogResult.OK == frm.ShowDialog())
            {
                buttonEdit部门.EditValue = frm.sID;
                frm.Enabled = true;
            }
        }

        private void buttonEdit部门_EditValueChanged(object sender, EventArgs e)
        {
            if (buttonEdit部门.Text.Trim() != "")
                lookUpEdit部门.EditValue = buttonEdit部门.Text.Trim();
            else
                lookUpEdit部门.EditValue = null;
        }

        private void buttonEdit部门_Leave(object sender, EventArgs e)
        {
            if (buttonEdit部门.Text.Trim() == "")
                return;
            if (lookUpEdit部门.Text.Trim() == "")
            {
                buttonEdit部门.Text = "";
                buttonEdit部门.Focus();
            }
        }

    }
}
