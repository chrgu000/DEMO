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
using 生产;
namespace 报表
{
    public partial class Frm成团委外订单执行情况表 : 系统服务.FrmBaseInfo
    {

        public Frm成团委外订单执行情况表()
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

        private void Frm成团委外订单执行情况表_Load(object sender, EventArgs e)
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
            sSQL = @"select a.ID,a.cMOCode,a.dDate,a.cVenCode,a.cPersonCode,a.cMSCode,b.cInvCode,b.iQuantity,b.iUnitPrice,b.iMoney, 
c.iQuantity as IniQuantity,b.iQuantity-isnull(c.iQuantity,0) as NotIniQuantity,c.iMoney as IniMoney,b.iMoney-isnull(c.iMoney,0) as NotIniMoney,c.D1 as InD1,c.D3 as InD3,
e.iQuantity as MiQuantity,d.iQuantity as MOutiQuantity,e.iQuantity-isnull(d.iQuantity,0) as NotOutiQuantity,d.D1 as OutD1,
case when isnull(c.iQuantity,0)=0 then null when isnull(d.iQuantity,0)<>0 then (isnull(e.iQuantity,0)-isnull(c.iQuantity,0)) end as 损耗 ,
c.D1,c.D2,c.D3,c.D4,c.D5,c.D6,c.D7,c.D8,c.D9,c.D9,c.D10,c.D11,c.D12,c.S1,c.sBoxQty,b.M1,c.M2 ,e.iQuantity as 订单重量,d.iQuantity as 出库重量
,convert(decimal(18, 6),case when isnull(c.iQuantity,0)=0 then null when isnull(d.iQuantity,0)<>0 then (isnull(e.iQuantity,0)-isnull(c.iQuantity,0)) end*100
/e.iQuantity) as 损耗比率
from MO_MOMain a left join MO_MODetails b on a.ID=b.ID 
left join (select MOAutoID,sum(iQuantity) as iQuantity,sum(iMoney) as iMoney,max(a.M1) as M1,max(a.M2) as M2 ,
SUM(a.D1) as D1,SUM(a.D2) as D2,SUM(a.D3) as D3,
SUM(a.D4) as D4,SUM(a.D5) as D5,SUM(a.D6) as D6,
SUM(a.D7) as D7,SUM(a.D8) as D8,SUM(a.D9) as D9,
SUM(a.D10) as D10,SUM(a.D11) as D11,SUM(a.D12) as D12,SUM(a.sBoxQty) as sBoxQty,
max(a.S1) as S1 from RdRecords03 a left join RdRecord03 b on a.ID=b.ID group by MOAutoID) c on b.AutoID=c.MOAutoID 
left join (select MOAutoID,sum(a.iQuantity) as iQuantity,sum(a.iMoney) as iMoney,SUM(a.D1) as D1 from MO_MOSublist c left join RdRecords12 a on a.MOsID=c.sID left join RdRecord12 b on a.ID=b.ID group by MOAutoID) d on b.AutoID=d.MOAutoID 
left join (select AutoID,sum(iQuantity) as iQuantity from MO_MOSublist group by AutoID) e on b.AutoID=e.AutoID
                     where 1=1 and a.cMSCode='0004' ";
            if (checkEdit1.Checked == true)
            {
                sSQL = sSQL + " and b.iQuantity-isnull(c.iQuantity,0) >0";
            }
            if (dateEdit1.EditValue != null && dateEdit1.EditValue.ToString().Trim() != "")
            {
                sSQL = sSQL + " and convert(varchar(10),a.dDate,120)>='" + dateEdit1.DateTime.ToString("yyyy-MM-dd") + "'";
            }
            if (dateEdit2.EditValue != null && dateEdit2.EditValue.ToString().Trim() != "")
            {
                sSQL = sSQL + " and convert(varchar(10),a.dDate,120)<='" + dateEdit2.DateTime.ToString("yyyy-MM-dd") + "'";
            }

            if (lookUpEdit供应商.EditValue != null && lookUpEdit供应商.EditValue.ToString().Trim() != "")
            {
                sSQL = sSQL + " and a.cVenCode='" + lookUpEdit供应商.EditValue.ToString().Trim() + "'";
            }
            if (lookUpEdit业务员.EditValue != null && lookUpEdit业务员.EditValue.ToString().Trim() != "")
            {
                sSQL = sSQL + " and a.cPersonCode='" + lookUpEdit业务员.EditValue.ToString().Trim() + "'";
            }
            if (lookUpEdit部门.EditValue != null && lookUpEdit部门.EditValue.ToString().Trim() != "")
            {
                sSQL = sSQL + " and a.cDepCode='" + lookUpEdit部门.EditValue.ToString().Trim() + "'";
            }
            if (lookUpEdit物料编码.EditValue != null && lookUpEdit物料编码.EditValue.ToString().Trim() != "")
            {
                sSQL = sSQL + " and b.cInvCode='" + lookUpEdit物料编码.EditValue.ToString().Trim() + "'";
            }
            if (textEdit色号.EditValue != null && textEdit色号.EditValue.ToString().Trim() != "")
            {
                sSQL = sSQL + " and c.M1 like '%" + textEdit色号.EditValue.ToString().Trim() + "%'";
            }
            if (textEdit缸号.EditValue != null && textEdit缸号.EditValue.ToString().Trim() != "")
            {
                sSQL = sSQL + " and c.M2 like '%" + textEdit缸号.EditValue.ToString().Trim() + "%'";
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
            系统服务.LookUp.MOStyle(ItemLookUpEdit委外类型);
            //系统服务.LookUp.Inventory(ItemLookUpEdit产品);
            //系统服务.LookUp.ShippingChoice(ItemLookUpEdit送货方式);

            系统服务.LookUp.Person(ItemLookUpEdit业务员);
            系统服务.LookUp.Vendor2(ItemLookUpEdit供应商);
            系统服务.LookUp.Department(ItemLookUpEdit部门);

            系统服务.LookUp.Person(lookUpEdit业务员);
            系统服务.LookUp.Vendor(lookUpEdit供应商);
            系统服务.LookUp.Department(lookUpEdit部门);

            系统服务.LookUp.Inventory(ItemLookUpEdit物料名称);
            系统服务.LookUp.Inventory(lookUpEdit物料编码);
            系统服务.LookUp.MOStyle(lookUpEdit委外类型);
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

        private void buttonEdit供应商_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            系统服务.Frm参照 frm = new 系统服务.Frm参照(10);
            if (DialogResult.OK == frm.ShowDialog())
            {
                buttonEdit供应商.EditValue = frm.sID;
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

        private void buttonEdit供应商_EditValueChanged(object sender, EventArgs e)
        {
            if (buttonEdit供应商.Text.Trim() != "")
            {
                lookUpEdit供应商.EditValue = buttonEdit供应商.Text.Trim();
                
            }
            else
            {
                buttonEdit供应商.EditValue = null;
                lookUpEdit供应商.EditValue = null;
            }
        }

        private void buttonEdit供应商_Leave(object sender, EventArgs e)
        {
            if (buttonEdit供应商.Text.Trim() == "")
                return;
            if (lookUpEdit供应商.Text.Trim() == "")
            {
                buttonEdit供应商.Text = "";
                buttonEdit供应商.Focus();
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

                Frm委外订单 frm = new Frm委外订单(sID, gridView1.GetRowCellDisplayText(iRow, gridCol委外类型).ToString() + "委外订单");
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

        private void buttonEdit物料编码_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            系统服务.Frm参照 frm = new 系统服务.Frm参照(1);
            if (DialogResult.OK == frm.ShowDialog())
            {
                buttonEdit物料编码.EditValue = frm.sID;
                frm.Enabled = true;
            }
        }

        private void buttonEdit物料编码_EditValueChanged(object sender, EventArgs e)
        {
            if (buttonEdit物料编码.Text.Trim() != "")
                lookUpEdit物料编码.EditValue = buttonEdit物料编码.Text.Trim();
            else
                lookUpEdit物料编码.EditValue = null;
        }

        private void buttonEdit物料编码_Leave(object sender, EventArgs e)
        {
            if (buttonEdit物料编码.Text.Trim() == "")
                return;
            if (lookUpEdit物料编码.Text.Trim() == "")
            {
                buttonEdit物料编码.Text = "";
                buttonEdit物料编码.Focus();
            }
        }


    }
}
