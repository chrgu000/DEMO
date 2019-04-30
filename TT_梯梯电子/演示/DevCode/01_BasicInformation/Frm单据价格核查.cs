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

namespace BasicInformation
{
    public partial class Frm单据价格核查 : FrameBaseFunction.Frm列表窗体模板
    {
        public Frm单据价格核查()
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
            return null;
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
           
        }
        /// <summary>
        /// 刷新
        /// </summary>
        private void btnRefresh()
        {
            GetGrid();
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
            gridView1.AddNewRow();
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
            throw new NotImplementedException();
        }
        /// <summary>
        /// 删除
        /// </summary>
        private void btnDel()
        {
           
        }

        /// <summary>
        /// 判断生产设备是否已经使用
        /// </summary>
        /// <param name="p"></param>
        /// <param name="sErr"></param>
        /// <returns></returns>
        private bool CheckCanDel(string p,out string sErr)
        {
            bool b = true;
            sErr = "";

            return b;
        }
        /// <summary>
        /// 保存
        /// </summary>
        private void btnSave()
        {
            try 
            {
                gridView1.FocusedRowHandle -= 1;
                gridView1.FocusedRowHandle += 1;
            }
            catch { }
          
            string sErr = "";

            aList = new System.Collections.ArrayList();
            for (int i = 0; i < gridView1.RowCount; i++)
            {
                if (gridView1.GetRowCellDisplayText(i, gridColiID).ToString().Trim() == "")
                {
                    continue;
                }

                if (!ReturnObjectToBool(gridView1.GetRowCellValue(i, gridCol选择)))
                {
                    continue;
                }

                sSQL = @"
select *
from 单据历史价格核对表
where iID = {0}
";
                sSQL = string.Format(sSQL, gridView1.GetRowCellDisplayText(i, gridColiID).ToString().Trim());
                DataTable dt = clsSQLCommond.ExecQuery(sSQL);
                if (dt == null || dt.Rows.Count == 0)
                    continue;

                string s确认人 = dt.Rows[0]["确认人"].ToString().Trim();
                string s审核人 = dt.Rows[0]["审核人"].ToString().Trim();

                if (s确认人 != "")
                {
                    sErr = sErr + "行 " + (i + 1).ToString() + " 已经确认\n";
                    continue;
                }
                if (s审核人 != "")
                {
                    sErr = sErr + "行 " + (i + 1).ToString() + " 已经审核\n";
                    continue;
                }

                sSQL = @"
update 单据历史价格核对表 set 确认人 = '{0}', 确认时间 = getdate(),备注 = '{2}' where iID = {1}
";
                sSQL = string.Format(sSQL, sUserName, gridView1.GetRowCellDisplayText(i, gridColiID).ToString().Trim(), gridView1.GetRowCellValue(i, gridCol备注).ToString().Trim());
                aList.Add(sSQL);
            }

            if (sErr.Trim().Length > 0)
            {
                MsgBox("提示", sErr);
                return;
            }

            if (aList.Count > 0)
            {
                int iCou = clsSQLCommond.ExecSqlTran(aList);
                MessageBox.Show("保存成功！\n合计执行语句:" + iCou + "条");
                GetGrid();
            }
        }
        /// <summary>
        /// 撤销
        /// </summary>
        private void btnUnDo()
        {
            try
            {
                gridView1.FocusedRowHandle -= 1;
                gridView1.FocusedRowHandle += 1;
            }
            catch { }

            string sErr = "";

            aList = new System.Collections.ArrayList();
            for (int i = 0; i < gridView1.RowCount; i++)
            {
                if (gridView1.GetRowCellDisplayText(i, gridColiID).ToString().Trim() == "")
                {
                    continue;
                }

                if (!ReturnObjectToBool(gridView1.GetRowCellValue(i, gridCol选择)))
                {
                    continue;
                }

                sSQL = @"
select *
from 单据历史价格核对表
where iID = {0}
";
                sSQL = string.Format(sSQL, gridView1.GetRowCellDisplayText(i, gridColiID).ToString().Trim());
                DataTable dt = clsSQLCommond.ExecQuery(sSQL);
                if (dt == null || dt.Rows.Count == 0)
                    continue;

                string s确认人 = dt.Rows[0]["确认人"].ToString().Trim();
                string s审核人 = dt.Rows[0]["审核人"].ToString().Trim();

                if (s审核人 != "")
                {
                    sErr = sErr + "行 " + (i + 1).ToString() + " 已经审核\n";
                    continue;
                }

                sSQL = @"
update 单据历史价格核对表 set 确认人 = null, 确认时间 = null where iID = {0}
";
                sSQL = string.Format(sSQL, gridView1.GetRowCellValue(i, gridColiID).ToString().Trim());
                aList.Add(sSQL);
            }

            if (sErr.Trim().Length > 0)
            {
                MsgBox("提示", sErr);
                return;
            }

            if (aList.Count > 0)
            {
                int iCou = clsSQLCommond.ExecSqlTran(aList);
                MessageBox.Show("撤销成功！\n合计执行语句:" + iCou + "条");
                GetGrid();
            }
        }
        /// <summary>
        /// 审核
        /// </summary>
        private void btnAudit()
        {
            try 
            {
                gridView1.FocusedRowHandle -= 1;
                gridView1.FocusedRowHandle += 1;
            }
            catch { }
          
            string sErr = "";

            aList = new System.Collections.ArrayList();
            for (int i = 0; i < gridView1.RowCount; i++)
            {
                if (gridView1.GetRowCellDisplayText(i, gridColiID).ToString().Trim() == "")
                {
                    continue;
                }

                if (!ReturnObjectToBool(gridView1.GetRowCellValue(i, gridCol选择)))
                {
                    continue;
                }

                sSQL = @"
select *
from 单据历史价格核对表
where iID = {0}
";
                sSQL = string.Format(sSQL, gridView1.GetRowCellDisplayText(i, gridColiID).ToString().Trim());
                DataTable dt = clsSQLCommond.ExecQuery(sSQL);
                if (dt == null || dt.Rows.Count == 0)
                    continue;

                string s确认人 = dt.Rows[0]["确认人"].ToString().Trim();
                string s审核人 = dt.Rows[0]["审核人"].ToString().Trim();

                if (s确认人 == "")
                {
                    sErr = sErr + "行 " + (i + 1).ToString() + " 尚未确认\n";
                    continue;
                }
                if (s审核人 != "")
                {
                    sErr = sErr + "行 " + (i + 1).ToString() + " 已经审核\n";
                    continue;
                }

                sSQL = @"
update 单据历史价格核对表 set 审核人 = '{0}', 审核时间 = getdate(),备注 = '{2}' where iID = {1}
";
                sSQL = string.Format(sSQL, sUserName, gridView1.GetRowCellDisplayText(i, gridColiID).ToString().Trim(), gridView1.GetRowCellValue(i, gridCol备注).ToString().Trim());
                aList.Add(sSQL);
            }

            if (sErr.Trim().Length > 0)
            {
                MsgBox("提示", sErr);
                return;
            }

            if (aList.Count > 0)
            {
                int iCou = clsSQLCommond.ExecSqlTran(aList);
                MessageBox.Show("审核成功！\n合计执行语句:" + iCou + "条");
                GetGrid();
            }
        }
        /// <summary>
        /// 弃审
        /// </summary>
        private void btnUnAudit()
        {
             try 
            {
                gridView1.FocusedRowHandle -= 1;
                gridView1.FocusedRowHandle += 1;
            }
            catch { }
          
            string sErr = "";

            aList = new System.Collections.ArrayList();
            for (int i = 0; i < gridView1.RowCount; i++)
            {
                if (gridView1.GetRowCellDisplayText(i, gridColiID).ToString().Trim() == "")
                {
                    continue;
                }

                if (!ReturnObjectToBool(gridView1.GetRowCellValue(i, gridCol选择)))
                {
                    continue;
                }

                sSQL = @"
select *
from 单据历史价格核对表
where iID = {0}
";
                sSQL = string.Format(sSQL, gridView1.GetRowCellDisplayText(i, gridColiID).ToString().Trim());
                DataTable dt = clsSQLCommond.ExecQuery(sSQL);
                if (dt == null || dt.Rows.Count == 0)
                    continue;

                string s确认人 = dt.Rows[0]["确认人"].ToString().Trim();
                string s审核人 = dt.Rows[0]["审核人"].ToString().Trim();

                if (s确认人 == "")
                {
                    sErr = sErr + "行 " + (i + 1).ToString() + " 尚未确认\n";
                    continue;
                }
                if (s审核人 == "")
                {
                    sErr = sErr + "行 " + (i + 1).ToString() + " 尚未审核\n";
                    continue;
                }

                sSQL = @"
update 单据历史价格核对表 set 审核人 = null, 审核时间 = null where iID = {0}
";
                sSQL = string.Format(sSQL, gridView1.GetRowCellValue(i, gridColiID).ToString().Trim());
                aList.Add(sSQL);
            }

            if (sErr.Trim().Length > 0)
            {
                MsgBox("提示", sErr);
                return;
            }

            if (aList.Count > 0)
            {
                int iCou = clsSQLCommond.ExecSqlTran(aList);
                MessageBox.Show("弃审成功！\n合计执行语句:" + iCou + "条");
                GetGrid();
            }
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


        private void GetGrid()
        {
            int iFocRow = gridView1.FocusedRowHandle;
            string sSQL = @"
select cast(0 as bit) as 选择 
    ,a.*
	,case when pos.iTaxPrice is null then oms.iTaxPrice else  pos.iTaxPrice end as 单据价格
	,case when po.cDepCode is null then om.cDepCode else  po.cDepCode end as cDepCode
	,case when isnull(最近一次含税单价,0) <> 0 and isnull(含税单价,0) <> 0 then  cast((含税单价 - 最近一次含税单价) * 100 / 最近一次含税单价 as decimal(16,2)) end as 变动幅度
	,case when po.cVenCode is null then om.cVenCode else po.cVenCode end as cVenCode,v.cVenName
from 单据历史价格核对表 a
	left join @u8.po_podetails pos on a.单据体IDs = pos.ID and a.单据类型 = '采购'
	left join @u8.PO_Pomain po on po.poid = pos.poid
	left join @u8.OM_MODetails oms on a.单据体IDs = oms.MODetailsID and a.单据类型 = '委外'
	left join @u8.OM_MOMain om on om.moid = oms.moid
    left join @u8.Vendor v on case when po.cVenCode is null then om.cVenCode else po.cVenCode end = v.cVenCode
where 1=1
order by iID
";
            
            if (radioUndo.Checked)
            {
                sSQL = sSQL.Replace("1=1", "1=1 and isnull(确认人,'') = ''");
            }
            if (radioEnSure.Checked)
            {
                sSQL = sSQL.Replace("1=1", "1=1 and isnull(确认人,'') <> '' and isnull(审核人,'') = ''");
            }
            if (radioAudit.Checked)
            {
                sSQL = sSQL.Replace("1=1", "1=1 and isnull(审核人,'') <> ''");
            }
            if (dtm单据日期1.Text.Trim() != "")
            {
                sSQL = sSQL.Replace("1=1", "1=1 and 单据日期 >= '" + dtm单据日期1.DateTime.ToString("yyyy-MM-dd") + "'");
            }
            if (dtm单据日期2.Text.Trim() != "")
            {
                sSQL = sSQL.Replace("1=1", "1=1 and 单据日期 < '" + dtm单据日期2.DateTime.AddDays(1).ToString("yyyy-MM-dd") + "'");
            }
            if (lookUpEditDepartment.Text.Trim() != "")
            {
                sSQL = sSQL.Replace("1=1", "1=1 and case when po.cDepCode is null then om.cDepCode else  po.cDepCode end = '" + lookUpEditDepartment.EditValue.ToString().Trim() + "'");
            }

            dtBingGrid = clsSQLCommond.ExecQuery(sSQL);
            gridControl1.DataSource = dtBingGrid;

            gridView1.BestFitColumns();
            gridCol存货名称.Width = 80;
            gridCol规格型号.Width = 80;
            gridCol备注.Width = 400;
            gridView1.FocusedRowHandle = iFocRow;

            chkAll.Checked = false;
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

        private void Frm单据价格核查_Load(object sender, EventArgs e)
        {
            try
            {
                dtm单据日期1.DateTime = DateTime.Today.AddDays(-7);
                dtm单据日期2.DateTime = DateTime.Today;

                setLookup();

                string sSQL = @"
select distinct cDepCode from @u8.Person where cPersonName = '{0}' and isnull(cDepCode,'') <> ''
";
                sSQL = string.Format(sSQL, sUserName);
                DataTable dt = clsSQLCommond.ExecQuery(sSQL);
                if(dt != null && dt.Rows.Count >0)
                {
                    lookUpEditDepartment.EditValue = dt.Rows[0]["cDepCode"].ToString().Trim();
                }

                GetGrid();
            }
            catch (Exception ee)
            {
                MessageBox.Show("加载窗体失败\n" + ee.Message);
            }
        }

        private void setLookup()
        {
            string sSQL = @"
select cDepCode,cDepName
from @u8.Department
order by cDepCode
";
            DataTable dt = clsSQLCommond.ExecQuery(sSQL);
            DataRow dr = dt.NewRow();
            dt.Rows.InsertAt(dr, 0);

            ItemLookUpEditcDepName.DataSource = dt;
            lookUpEditDepartment.Properties.DataSource = dt;
        }

        private void ItemButtonEditPrice_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            int iRow = 0;
            if (gridView1.RowCount > 0)
                iRow = gridView1.FocusedRowHandle;

            string sInvCode = gridView1.GetRowCellValue(iRow, gridCol存货编码).ToString().Trim();
            FrmInvPrice fPrice = new FrmInvPrice(sInvCode);
            fPrice.ShowDialog();
        }

        private void radio_CheckedChanged(object sender, EventArgs e)
        {
            GetGrid();
        }

        private void chkAll_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                for (int i = 0; i < gridView1.RowCount; i++)
                {
                    gridView1.SetRowCellValue(i, gridCol选择, chkAll.Checked);
                }
            }
            catch { }
        }

        private void lookUpEditDepartment_EditValueChanged(object sender, EventArgs e)
        {
            try
            {
                GetGrid();
            }
            catch(Exception ee)
            { }
        }
    }
}
