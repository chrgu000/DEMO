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
using 销售;

namespace 报表
{
    public partial class Frm销售订单执行情况表 : 系统服务.FrmBaseInfo
    {

        public Frm销售订单执行情况表()
        {
            InitializeComponent();

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
                GetLayOut(layoutControl1, gridControl1);

                SetLookUpEdit();
                dateEdit1.EditValue = DateTime.Now.AddMonths(-1).ToString("yyyy-MM-dd");
                dateEdit2.EditValue = DateTime.Now.ToString("yyyy-MM-dd");
                GetGrid();

            }
            catch (Exception ee)
            {
                MessageBox.Show("加载窗体失败\n" + ee.Message);
            }
        }

        private void GetGrid()
        {

            sSQL = @"

select cInvCode,a.cRSCode,M1,M2,iQuantity,sBoxQty into #a from RdRecord01 a inner join RdRecords01 b on a.ID=b.ID left join RdStyle c on a.cRSCode=c.cRSCode where 1=1 and dVerifysysPerson is not null      

insert into #a select cInvCode,a.cRSCode,M1,M2,iQuantity,sBoxQty from RdRecord02 a inner join RdRecords02 b on a.ID=b.ID left join RdStyle c on a.cRSCode=c.cRSCode where 1=1 and dVerifysysPerson is not null      
insert into #a select cInvCode,a.cRSCode,M1,M2,iQuantity,sBoxQty from RdRecord03 a inner join RdRecords03 b on a.ID=b.ID left join RdStyle c on a.cRSCode=c.cRSCode where 1=1 and dVerifysysPerson is not null      
insert into #a select cInvCode,a.cRSCode,M1,M2,iQuantity,sBoxQty from RdRecord05 a inner join RdRecords05 b on a.ID=b.ID left join RdStyle c on a.cRSCode=c.cRSCode where 1=1 and dVerifysysPerson is not null      

insert into #a select cInvCode,a.cRSCode,M1,M2,-iQuantity,-sBoxQty from RdRecord11 a inner join RdRecords11 b on a.ID=b.ID left join RdStyle c on a.cRSCode=c.cRSCode where 1=1 and dVerifysysPerson is not null      
insert into #a select cInvCode,a.cRSCode,M1,M2,-iQuantity,-sBoxQty from RdRecord12 a inner join RdRecords12 b on a.ID=b.ID left join RdStyle c on a.cRSCode=c.cRSCode where 1=1 and dVerifysysPerson is not null      
insert into #a select cInvCode,a.cRSCode,M1,M2,-iQuantity,-sBoxQty from RdRecord13 a inner join RdRecords13 b on a.ID=b.ID left join RdStyle c on a.cRSCode=c.cRSCode where 1=1 and dVerifysysPerson is not null      
insert into #a select cInvCode,a.cRSCode,M1,M2,-iQuantity,-sBoxQty from RdRecord15 a inner join RdRecords15 b on a.ID=b.ID left join RdStyle c on a.cRSCode=c.cRSCode where 1=1 and dVerifysysPerson is not null      

select cInvCode,M1,sum(sBoxQty) as sBoxQty into #b from #a  group by cInvCode,M1 


select SoAutoID,sum(iQuantity) as iQuantity,sum(iMoney) as iMoney,sum(sBoxQty) as sBoxQty,
sum(case when flag='2' then iQuantity else 0 end)  as iQuantity2,sum(case when flag='2' then sBoxQty else 0 end)  as sBoxQty2 into #c
from RdRecords13 b left join RdRecord13 a on a.ID=b.ID group by SoAutoID

select SoAutoID,sum(iQuantity) as iQuantity,sum(iMoney) as iMoney,sum(sBoxQty) as sBoxQty,
sum(case when flag='2' then iQuantity else 0 end)  as iQuantity2,sum(case when flag='2' then sBoxQty else 0 end)  as sBoxQty2 into #f 
from RdRecords11 a left join RdRecord11 b on a.ID=b.ID group by SoAutoID

select a.ID,b.AutoID,a.cSOCode,b.M1,b.M2,a.dDate,a.cCusCode,a.cPersonCode,a.cDepCode,a.cSTCode,b.cInvCode,b.iQuantity,b.D1 ,b.iMoney,b.sBoxQty,g.sBoxQty NowQty,
isnull(c.iQuantity,0)+isnull(f.iQuantity,0) as OutiQuantity,isnull(c.sBoxQty,0)+isnull(f.sBoxQty,0) as OutsBoxQty,isnull(c.iMoney,0)+isnull(f.iMoney,0) as OutiMoney,isnull(c.sBoxQty,0)+isnull(f.sBoxQty,0) as OutsBoxQty,
b.iQuantity-isnull(c.iQuantity,0)-isnull(f.iQuantity,0) as NotOutiQuantity,b.sBoxQty-isnull(c.sBoxQty,0)-isnull(f.sBoxQty,0) as NotOutsBoxQty,b.iMoney-isnull(c.iMoney,0)-isnull(f.iMoney,0) as NotOutiMoney
,isnull(c.iQuantity2,0)+isnull(f.iQuantity2,0) as 退货数量,isnull(c.sBoxQty2,0)+isnull(f.sBoxQty2,0) as 退货盒数 
from SO_SOMain a left join SO_SODetails b on a.ID=b.ID 
left join #c as c on b.AutoID=c.SoAutoID 
left join #f as f on b.AutoID=f.SoAutoID 
left join #b as g on b.cInvCode=g.cInvCode and b.M1=g.M1

                     where 1=1 ";//
            if (chk未出库.Checked == true && chk已出库.Checked == false)
            {
                sSQL = sSQL + " and b.sBoxQty-isnull(c.sBoxQty,0)-isnull(f.sBoxQty,0)>0";
            }
            else if (chk已出库.Checked == true && chk未出库.Checked == false)
            {
                sSQL = sSQL + " and b.sBoxQty-isnull(c.sBoxQty,0)-isnull(f.sBoxQty,0)=0";
            }
            if (dateEdit1.EditValue != null && dateEdit1.EditValue.ToString().Trim() != "")
            {
                sSQL = sSQL + " and convert(varchar(10),a.dDate,120)>='" + dateEdit1.DateTime.ToString("yyyy-MM-dd") + "'";
            }
            if (dateEdit2.EditValue != null && dateEdit2.EditValue.ToString().Trim() != "")
            {
                sSQL = sSQL + " and convert(varchar(10),a.dDate,120)<='" + dateEdit2.DateTime.ToString("yyyy-MM-dd") + "'";
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
            sSQL = sSQL + "  order by a.id desc";
            DataTable dt = clsSQLCommond.ExecQuery(sSQL);
            gridControl1.DataSource = dt;
            GetShow(false);
        }

        private void GetShow(bool b)
        {
            gridView1.OptionsBehavior.Editable = false;
        }

        /// <summary>
        /// 下拉列表框
        /// </summary>
        private void SetLookUpEdit()
        {
            //系统服务.LookUp.SaleTypeAll(ItemLookUpEdit销售类型);
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

        private void gridView1_DoubleClick(object sender, EventArgs e)
        {
            try
            {
                int iRow = gridView1.FocusedRowHandle;
                if (iRow < 0)
                    return;

                long sID = Convert.ToInt64(gridView1.GetRowCellValue(iRow, gridColID));
                if (sID == -1)
                    return;

                Frm销售订单 frm = new Frm销售订单(sID);
                frm.Tag = frm.Name;
                frm.MdiParent = this.MdiParent;

                frm.Show();
                if (DialogResult.OK == frm.ShowDialog())
                {
                    frm.Enabled = true;
                }
            }
            catch (Exception ee)
            { }
        }

        private void chk未出库_CheckedChanged(object sender, EventArgs e)
        {
            //if (chk未出库.Checked == true)
            //{
            //    chk已出库.Checked = false;
            //}
            //else
            //{
            //    chk已出库.Checked = true;
            //}
        }

        private void chk已出库_CheckedChanged(object sender, EventArgs e)
        {
            //if (chk已出库.Checked == true)
            //{
            //    chk未出库.Checked = false;
            //}
            //else
            //{
            //    chk未出库.Checked = true;
            //}
        }

    }
}
