using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace 基础设置
{
    public partial class Frm客户协议登记表 : 系统服务.FrmBaseInfo
    {
        public Frm客户协议登记表()
        {
            InitializeComponent();
        }

        string sBtnStatus = "";

        #region 按钮操作
        protected override void BtnClick(string sBtnName, string sBtnText)
        {
            try
            {
                sBtnStatus = sBtnName.ToLower();

                switch (sBtnName.ToLower())
                {
                    case "add":
                        btnAdd();
                        break;
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

        private void btnAdd()
        {
            SetEnable(true);

            gridView1.FocusedRowHandle = 0;

            sBtnStatus = "add";
        }


        #region 按钮模板

        /// <summary>
        /// 将表格中Lookup之类的保存ID的数据转换成Text用于打印
        /// </summary>
        /// <param name="dt"></param>
        /// <returns></returns>
        private DataTable SetPrintData(DataTable dt)
        {
            //DataTable dtState = (DataTable)ItemLookUpEditcTrade.DataSource;
            //DataTable dtType = (DataTable)ItemLookUpEditcCCCode.DataSource;
            //DataColumn dc = new DataColumn();
            //dc.ColumnName = "StateText";
            //dt.Columns.Add(dc);
            //dc = new DataColumn();
            //dc.ColumnName = "TypeText";
            //dt.Columns.Add(dc);
            //for (int i = 0; i < dt.Rows.Count; i++)
            //{
            //    DataRow[] drState = dtState.Select("iID = '" + dt.Rows[i]["State"].ToString().Trim() + "'");
            //    if (drState.Length > 0)
            //    {
            //        dt.Rows[i]["StateText"] = drState[0]["State"];
            //    }

            //    DataRow[] drType = dtType.Select("iID = '" + dt.Rows[i]["Type"].ToString().Trim() + "'");
            //    if (drType.Length > 0)
            //    {
            //        dt.Rows[i]["TypeText"] = drType[0]["Type"];
            //    }
            //}

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
            //try
            //{
            //    SaveFileDialog sF = new SaveFileDialog();
            //    sF.DefaultExt = "xls";
            //    sF.FileName = this.Text;
            //    sF.Filter = "Excel文件(*.xls)|*.xls|所有文件(*.*)|*.*";
            //    DialogResult dRes = sF.ShowDialog();
            //    if (DialogResult.OK == dRes)
            //    {
            //        gridView1.ExportToXls(sF.FileName);
            //        MessageBox.Show("导出Excel成功\n\t路径：" + sF.FileName);
            //    }
            //}
            //catch (Exception ee)
            //{
            //    throw new Exception(ee.Message);
            //}
        }

        private void btnLayout(string sText)
        {
            //if (layoutControl1 == null) return;
            //if (sText == "布局")
            //{
            //    //layoutControl1.ShowCustomizationForm();
            //    layoutControl1.AllowCustomizationMenu = true;
            //    base.toolStripMenuBtn.Items["Layout"].Text = "保存布局";

            //    gridView1.OptionsMenu.EnableColumnMenu = true;
            //    gridView1.OptionsMenu.EnableFooterMenu = true;
            //    gridView1.OptionsMenu.EnableGroupPanelMenu = true;
            //    //gridView1.OptionsMenu.ShowAddNewSummaryItem = true;
            //    gridView1.OptionsMenu.ShowAutoFilterRowItem = true;
            //    gridView1.OptionsMenu.ShowDateTimeGroupIntervalItems = true;
            //    gridView1.OptionsMenu.ShowGroupSortSummaryItems = true;
            //    gridView1.OptionsMenu.ShowGroupSummaryEditorItem = true;
            //    gridView1.OptionsCustomization.AllowColumnMoving = true;
            //}
            //else
            //{
            //    //layoutControl1.HideCustomizationForm();
            //    layoutControl1.AllowCustomizationMenu = false;
            //    gridView1.OptionsMenu.EnableColumnMenu = false;
            //    gridView1.OptionsMenu.EnableFooterMenu = false;
            //    gridView1.OptionsMenu.EnableGroupPanelMenu = false;
            //    //gridView1.OptionsMenu.ShowAddNewSummaryItem = false;
            //    gridView1.OptionsMenu.ShowAutoFilterRowItem = false;
            //    gridView1.OptionsMenu.ShowDateTimeGroupIntervalItems = false;
            //    gridView1.OptionsMenu.ShowGroupSortSummaryItems = false;
            //    gridView1.OptionsMenu.ShowGroupSummaryEditorItem = false;
            //    gridView1.OptionsCustomization.AllowColumnMoving = false;


            //    if (!Directory.Exists(base.sProPath + "\\layout"))
            //        Directory.CreateDirectory(base.sProPath + "\\layout");

            //    base.toolStripMenuBtn.Items["Layout"].Text = "布局";

            //    DialogResult d = MessageBox.Show("是否保存?\n是：保存界面样式\n否：恢复默认界面样式,下次加载时将以默认样式打开\n", "提示", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Asterisk);
            //    if (d == DialogResult.Yes)
            //    {
            //        layoutControl1.SaveLayoutToXml(sLayoutHeadPath);
            //        gridControl1.MainView.SaveLayoutToXml(sLayoutGridPath);
            //    }
            //    else if (d == DialogResult.No)
            //    {
            //        if (File.Exists(sLayoutHeadPath))
            //            File.Delete(sLayoutHeadPath);

            //        if (File.Exists(sLayoutGridPath))
            //            File.Delete(sLayoutGridPath);
            //    }
            //}
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
                if (sBtnStatus != "add")
                {
                    //SetLookUpEdit();
                    GetGrid();

                    SetEnable(false);

                    GetInfo(btnTxtDLS.Text.Trim());
                }
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

        private void GetGrid()
        {
            try
            {
                if (lookUpEdit代理商.EditValue == null || lookUpEditCustomer.EditValue == null || lookUpEdit业务员.EditValue.ToString().Trim() == "")
                {
                    return;
                }
                lookUpEdit返点方式.EditValue = DBNull.Value;
                labelGUID.Text = "";

                if (lookUpEditYear.Text.Trim() == "")
                {
                    lookUpEditYear.Focus();
                    return;
                }

                string sYear = lookUpEditYear.EditValue.ToString().Trim();
                string s代理商 = "";
                string s开票客户 = "";
                string s业务员 = "";
                if (lookUpEdit代理商.EditValue != null && lookUpEditCustomer.EditValue != null && lookUpEdit业务员.EditValue.ToString().Trim() != "")
                {
                    s代理商 = lookUpEdit代理商.EditValue.ToString().Trim();
                    s开票客户 = lookUpEditCustomer.EditValue.ToString().Trim();
                    s业务员 = lookUpEdit业务员.EditValue.ToString().Trim();
                }

                string sSQL = @"
select a.iID, iYear, a.代理商, a.dDate1, a.dDate2, a.返点方式, a.底价, a.协议销量, a.保证金,inv.cInvStd as 规格型号,a.品种 as 编码,inv.cInvName as 品种
    ,cast(M1 as decimal(16,2)) as M1,cast(M2 as decimal(16,2)) as M2,cast(M3 as decimal(16,2)) as M3,cast(M4 as decimal(16,2)) as M4,cast(M5 as decimal(16,2)) as M5,cast(M6 as decimal(16,2)) as M6 
    ,cast(M7 as decimal(16,2)) as M7,cast(M8 as decimal(16,2)) as M8,cast(M9 as decimal(16,2)) as M9,cast(M10 as decimal(16,2)) as M10, cast(M11 as decimal(16,2)) as M11,cast(M12 as decimal(16,2)) as M12
    ,a.CreateUid,a.CreateDate, a.AuditUid, a.AuditDate
    ,cast(M1 as decimal(16,2)) + cast(M2 as decimal(16,2)) + cast(M3 as decimal(16,2)) + cast(M4 as decimal(16,2)) + cast(M5 as decimal(16,2)) + cast(M6 as decimal(16,2)) 
    + cast(M7 as decimal(16,2)) + cast(M8 as decimal(16,2)) + cast(M9 as decimal(16,2)) + cast(M10 as decimal(16,2)) + cast(M11 as decimal(16,2)) + cast(M12 as decimal(16,2)) as MSum
    ,a.GUID
    ,a.或有条款,case when isnull(a.是否有纸质合同,0) = 0 then '否' else '是' end as 是否有纸质合同
from 客户协议登记表 a
    left join U8Inventory inv on a.品种 = inv.cInvCode
where iYear = aaaaaaaa  
    and 代理商 = 'bbbbbbbb' and 开票客户 = 'cccccccc' and 业务员 = 'dddddddd'
order by a.iID
";
                sSQL = sSQL.Replace("aaaaaaaa", sYear);
                sSQL = sSQL.Replace("bbbbbbbb", s代理商);
                sSQL = sSQL.Replace("cccccccc", s开票客户);
                sSQL = sSQL.Replace("dddddddd", s业务员);
                DataTable dt = clsSQLCommond.ExecQuery(sSQL);
                gridControl1.DataSource = dt;

                if (dt.Rows.Count > 0)
                {
                    lookUpEdit返点方式.EditValue = dt.Rows[0]["返点方式"].ToString().Trim();

                    labelGUID.Text = dt.Rows[0]["GUID"].ToString().Trim();
                    lookUpEdit是否有纸质合同.EditValue = dt.Rows[0]["是否有纸质合同"].ToString().Trim();
                }
                while (gridView1.RowCount < 50)
                {
                    gridView1.AddNewRow();
                }
                gridView1.FocusedRowHandle = 0;

                //                sSQL = @"
                //select * 
                //from 客户协议登记表_业务员 
                //where 1=1
                //order by iID
                //";
                //                if (labelGUID.Text.Trim() == "")
                //                {
                //                    sSQL = sSQL.Replace("1=1", "1=1 and 1=-1");
                //                }
                //                else
                //                {
                //                    sSQL = sSQL.Replace("1=1", "1=1 and GUID = '" + labelGUID.Text.Trim() + "'");
                //                }
                //                dt = clsSQLCommond.ExecQuery(sSQL);
                //                gridControl2.DataSource = dt;

                //                while (gridView2.RowCount < 50)
                //                {
                //                    gridView2.AddNewRow();
                //                }
                //                gridView2.FocusedRowHandle = 0;
            }
            catch (Exception ee)
            {
                MessageBox.Show(ee.Message);
            }
        }

        /// <summary>
        /// 首页
        /// </summary>
        private void btnFirst()
        {
            if (dt翻页 != null && dt翻页.Rows.Count > 0)
            {
                lookUpEditCustomer.EditValue =  dt翻页.Rows[0]["开票客户"].ToString().Trim();
                lookUpEdit业务员.EditValue = dt翻页.Rows[0]["业务员"].ToString().Trim();

                label8.Text = "1/" + dt翻页.Rows.Count.ToString();
            }
        }
        /// <summary>
        /// 上页
        /// </summary>
        private void btnPrev()
        {
            int iRow = 0;
            for (int i = 0; i < dt翻页.Rows.Count; i++)
            {
                if (lookUpEditCustomer.EditValue.ToString().Trim() == dt翻页.Rows[i]["开票客户"].ToString().Trim() && lookUpEdit业务员.EditValue.ToString().Trim() == dt翻页.Rows[i]["业务员"].ToString().Trim())
                {
                    iRow = i;
                    break;
                }
            }

            if (iRow > 0)
                iRow = iRow - 1;

            lookUpEditCustomer.EditValue = dt翻页.Rows[iRow]["开票客户"].ToString().Trim();
            lookUpEdit业务员.EditValue = dt翻页.Rows[iRow]["业务员"].ToString().Trim();
            label8.Text = (iRow + 1).ToString() + "/" + dt翻页.Rows.Count.ToString();
        }
        /// <summary>
        /// 下页
        /// </summary>
        private void btnNext()
        {
            int iRow = 0;
            for (int i = 0; i < dt翻页.Rows.Count; i++)
            {
                if (lookUpEditCustomer.EditValue.ToString().Trim() == dt翻页.Rows[i]["开票客户"].ToString().Trim() && lookUpEdit业务员.EditValue.ToString().Trim() == dt翻页.Rows[i]["业务员"].ToString().Trim())
                {
                    iRow = i;
                    break;
                }
            }

            if (iRow < dt翻页.Rows.Count - 1)
                iRow = iRow + 1;

            lookUpEditCustomer.EditValue = dt翻页.Rows[iRow]["开票客户"].ToString().Trim();
            lookUpEdit业务员.EditValue = dt翻页.Rows[iRow]["业务员"].ToString().Trim();
            label8.Text = (iRow + 1).ToString() + "/" + dt翻页.Rows.Count.ToString();
        }
        /// <summary>
        /// 末页
        /// </summary>
        private void btnLast()
        {
            if (dt翻页 != null && dt翻页.Rows.Count > 0)
            {
                lookUpEditCustomer.EditValue = dt翻页.Rows[dt翻页.Rows.Count - 1]["开票客户"].ToString().Trim();
                lookUpEdit业务员.EditValue = dt翻页.Rows[dt翻页.Rows.Count - 1]["业务员"].ToString().Trim();
                label8.Text = dt翻页.Rows.Count.ToString() + "/" + dt翻页.Rows.Count.ToString();
            }
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
            gridView1.DeleteRow(gridView1.FocusedRowHandle);
        }
        /// <summary>
        /// 修改
        /// </summary>
        private void btnEdit()
        {
            if (lookUpEditYear.Text.Trim() == "")
            {
                lookUpEditYear.Focus();
                throw new Exception("请设置年度");
            }
            if (lookUpEdit代理商.Text.Trim() == "")
            {
                lookUpEdit代理商.Focus();
                throw new Exception("请设置代理商");
            }

            SetEnable(true);

            gridView1.FocusedRowHandle = 0;
        }
        /// <summary>
        /// 删除
        /// </summary>
        private void btnDel()
        {
            if (lookUpEditYear.Text.Trim() == "")
            {
                lookUpEditYear.Focus();
                throw new Exception("请设置年度");
            }

            if (lookUpEdit代理商.EditValue == null || lookUpEdit代理商.Text.Trim() == "")
            {
                btnTxtDLS.Focus();
                throw new Exception("请选择代理商");
            }

            if (lookUpEditCustomer.EditValue == null || lookUpEditCustomer.Text.Trim() == "")
            {
                btnTxtDLS.Focus();
                throw new Exception("请选择开票客户");
            }

            aList = new System.Collections.ArrayList();

            Guid sGuid = Guid.NewGuid();

            sSQL = @"
select GUID from 客户协议登记表 where iYear = aaaaaaaa and 代理商 = 'bbbbbbbb' and 开票客户 = 'cccccccc' and 业务员 = 'dddddddd'
";
            sSQL = sSQL.Replace("aaaaaaaa", lookUpEditYear.Text.Trim());
            sSQL = sSQL.Replace("bbbbbbbb", lookUpEdit代理商.EditValue.ToString().Trim());
            sSQL = sSQL.Replace("cccccccc", lookUpEditCustomer.EditValue.ToString().Trim());
            sSQL = sSQL.Replace("dddddddd", lookUpEdit业务员.EditValue.ToString().Trim());
            DataTable dtGuid = clsSQLCommond.ExecQuery(sSQL);
            if (dtGuid != null && dtGuid.Rows.Count > 0 & dtGuid.Rows[0]["GUID"].ToString().Trim() != "")
            {
                sGuid = (Guid)dtGuid.Rows[0]["GUID"];
            }

            sSQL = @"
delete 客户协议登记表 where iYear = aaaaaaaa and 代理商 = 'bbbbbbbb' and 开票客户 = 'cccccccc' and 业务员 = 'dddddddd'
";
            sSQL = sSQL.Replace("aaaaaaaa", lookUpEditYear.Text.Trim());
            sSQL = sSQL.Replace("bbbbbbbb", lookUpEdit代理商.EditValue.ToString().Trim());
            sSQL = sSQL.Replace("cccccccc", lookUpEditCustomer.EditValue.ToString().Trim());
            sSQL = sSQL.Replace("dddddddd", lookUpEdit业务员.EditValue.ToString().Trim());
            aList.Add(sSQL);


            sSQL = @"
delete 客户协议登记表_业务员 where GUID = 'aaaaaaaaaa'
";
            sSQL = sSQL.Replace("aaaaaaaaaa", sGuid.ToString());
            aList.Add(sSQL);

            int iCou = clsSQLCommond.ExecSqlTran(aList);
            if (iCou == 0)
            {
                throw new Exception("删除失败");
            }
            GetGrid();
            SetEnable(false);
            btnRefresh();
            btnFirst();
        }


        /// <summary>
        /// 保存
        /// </summary>
        private void btnSave()
        {
            try
            {
                try
                {
                    gridView1.FocusedRowHandle -= 1;
                    gridView1.FocusedRowHandle += 1;
                }
                catch { }
                
                if (lookUpEditYear.Text.Trim() == "")
                {
                    lookUpEditYear.Focus();
                    throw new Exception("请设置年度");
                }

                if (lookUpEdit代理商.EditValue == null || lookUpEdit代理商.Text.Trim() == "")
                {
                    btnTxtDLS.Focus();
                    throw new Exception("请选择代理商");
                }

                if (lookUpEditCustomer.EditValue == null || lookUpEditCustomer.Text.Trim() == "")
                {
                    btnTxtCustomer.Focus();
                    throw new Exception("请选择开票客户");
                }

                if (lookUpEdit业务员.EditValue == null || lookUpEdit业务员.Text.Trim() == "")
                {
                    lookUpEdit业务员.Focus();
                    throw new Exception("请选择业务员");
                }

                string s代理商编码 = lookUpEdit代理商.EditValue.ToString().Trim();
                string s开票客户 = lookUpEditCustomer.EditValue.ToString().Trim();
                string s业务员 = lookUpEdit业务员.EditValue.ToString().Trim();

                string s返点方式 = lookUpEdit返点方式.Text.Trim();
                if (s返点方式 == "")
                {
                    lookUpEdit返点方式.Focus();
                    throw new Exception("请选择返点方式");
                }

                string sErr = "";

                aList = new System.Collections.ArrayList();


                Guid sGuid = Guid.NewGuid();

                sSQL = @"
select GUID from 客户协议登记表 where iYear = aaaaaaaa and 代理商 = 'bbbbbbbb' and 开票客户 = 'cccccccc' and 业务员 = 'dddddddd'
";
                sSQL = sSQL.Replace("aaaaaaaa", lookUpEditYear.Text.Trim());
                sSQL = sSQL.Replace("bbbbbbbb", s代理商编码);
                sSQL = sSQL.Replace("cccccccc", s开票客户);
                sSQL = sSQL.Replace("dddddddd", s业务员);
                DataTable dtGuid = clsSQLCommond.ExecQuery(sSQL);
                if (dtGuid != null && dtGuid.Rows.Count > 0)
                {
                    if (dtGuid.Rows[0]["GUID"].ToString().Trim() != "")
                    {
                        sGuid = (Guid)dtGuid.Rows[0]["GUID"];
                    }
                }

                sSQL = @"
delete 客户协议登记表 where iYear = aaaaaaaa and 代理商 = 'bbbbbbbb' and 开票客户 = 'cccccc' and 业务员 = 'dddddddd'
";
                sSQL = sSQL.Replace("aaaaaaaa", lookUpEditYear.Text.Trim());
                sSQL = sSQL.Replace("bbbbbbbb", s代理商编码);
                sSQL = sSQL.Replace("cccccc", s开票客户);
                sSQL = sSQL.Replace("dddddddd", s业务员);
                aList.Add(sSQL);

                 
                for (int i = 0; i < gridView1.RowCount; i++)
                {
                    Model.客户协议登记表 mod = new 基础设置.Model.客户协议登记表();

                    string s编码 = gridView1.GetRowCellValue(i, gridCol编码).ToString().Trim();
                    if (s编码 == "")
                    {
                        continue;
                    }

                    sSQL = @"
select count(1) 
from U8Inventory 
where cInvCode = 'aaaaaaaa' 
";
                    sSQL = sSQL.Replace("aaaaaaaa", s编码);
                    DataTable dt = clsSQLCommond.ExecQuery(sSQL);
                    if (dt == null || dt.Rows.Count == 0)
                    {
                        sErr = sErr + "行 " + (i + 1).ToString() + " 品种不存在\n";
                        continue;
                    }

                    if (gridView1.GetRowCellValue(i, gridCol协议开始日期).ToString().Trim() == "")
                    {
                        sErr = sErr + "行 " + (i + 1).ToString() + " 协议开始日期必输\n";
                        continue;
                    }
                    if (gridView1.GetRowCellValue(i, gridCol协议结束日期).ToString().Trim() == "")
                    {
                        sErr = sErr + "行 " + (i + 1).ToString() + " 协议结束日期必输\n";
                        continue;
                    }

                    mod.GUID = sGuid;
                    mod.iYear = ReturnInt(lookUpEditYear.Text);
                    mod.代理商 = s代理商编码;
                    mod.dDate1 = ReturnDateTime(gridView1.GetRowCellValue(i, gridCol协议开始日期));
                    mod.dDate2 = ReturnDateTime(gridView1.GetRowCellValue(i, gridCol协议结束日期));
                    mod.返点方式 = s返点方式;
                    mod.品种 = s编码;
                    mod.或有条款 = gridView1.GetRowCellDisplayText(i, gridCol或有条款).ToString().Trim();
                    mod.开票客户 = s开票客户;
                    mod.业务员 = s业务员;
                    if (lookUpEdit是否有纸质合同.Text.Trim() == "是")
                    {
                        mod.是否有纸质合同 = 1;
                    }
                    else
                    {
                        mod.是否有纸质合同 = 0;
                    }

                    if (gridView1.GetRowCellValue(i, gridCol底价).ToString().Trim() != "")
                    { 
                        mod.底价 =  ReturnDecimal(gridView1.GetRowCellValue(i, gridCol底价), 2);
                    }
                    if (gridView1.GetRowCellValue(i, gridCol协议销量).ToString().Trim() != "")
                    {
                        mod.协议销量 = ReturnDecimal(gridView1.GetRowCellValue(i, gridCol协议销量), 2);
                    }
                    if (gridView1.GetRowCellValue(i, gridCol保证金).ToString().Trim() != "")
                    {
                        mod.保证金= ReturnDecimal(gridView1.GetRowCellValue(i, gridCol保证金), 2);
                    }
                    if (gridView1.GetRowCellValue(i, gridColM1).ToString().Trim() != "")
                    {
                        mod.M1 = ReturnDecimal(gridView1.GetRowCellValue(i, gridColM1), 2);
                    }
                    if (gridView1.GetRowCellValue(i, gridColM2).ToString().Trim() != "")
                    {
                        mod.M2 = ReturnDecimal(gridView1.GetRowCellValue(i, gridColM2), 2);
                    }
                    if (gridView1.GetRowCellValue(i, gridColM3).ToString().Trim() != "")
                    {
                        mod.M3 = ReturnDecimal(gridView1.GetRowCellValue(i, gridColM3), 2);
                    }
                    if (gridView1.GetRowCellValue(i, gridColM4).ToString().Trim() != "")
                    {
                        mod.M4 = ReturnDecimal(gridView1.GetRowCellValue(i, gridColM4), 2);
                    }
                    if (gridView1.GetRowCellValue(i, gridColM5).ToString().Trim() != "")
                    {
                        mod.M5 = ReturnDecimal(gridView1.GetRowCellValue(i, gridColM5), 2);
                    }
                    if (gridView1.GetRowCellValue(i, gridColM6).ToString().Trim() != "")
                    {
                        mod.M6 = ReturnDecimal(gridView1.GetRowCellValue(i, gridColM6), 2);
                    }
                    if (gridView1.GetRowCellValue(i, gridColM7).ToString().Trim() != "")
                    {
                        mod.M7 = ReturnDecimal(gridView1.GetRowCellValue(i, gridColM7), 2);
                    }
                    if (gridView1.GetRowCellValue(i, gridColM8).ToString().Trim() != "")
                    {
                        mod.M8 = ReturnDecimal(gridView1.GetRowCellValue(i, gridColM8), 2);
                    }
                    if (gridView1.GetRowCellValue(i, gridColM9).ToString().Trim() != "")
                    {
                        mod.M9 = ReturnDecimal(gridView1.GetRowCellValue(i, gridColM9), 2);
                    }
                    if (gridView1.GetRowCellValue(i, gridColM10).ToString().Trim() != "")
                    {
                        mod.M10 = ReturnDecimal(gridView1.GetRowCellValue(i, gridColM10), 2);
                    }
                    if (gridView1.GetRowCellValue(i, gridColM11).ToString().Trim() != "")
                    {
                        mod.M11 = ReturnDecimal(gridView1.GetRowCellValue(i, gridColM11), 2);
                    }
                    if (gridView1.GetRowCellValue(i, gridColM12).ToString().Trim() != "")
                    {
                        mod.M12 = ReturnDecimal(gridView1.GetRowCellValue(i, gridColM12), 2);
                    }
                    mod.CreateUid = sUid;
                    mod.CreateDate = DateTime.Now;

                    DAL.客户协议登记表 dal = new 基础设置.DAL.客户协议登记表();
                    sSQL = dal.Add(mod);
                    aList.Add(sSQL);
                }

                if (sErr.Trim() != "")
                {
                    throw new Exception(sErr);
                }

                if (aList.Count > 0)
                {
                    clsSQLCommond.ExecSqlTran(aList);
                    MessageBox.Show("保存成功");

                    btnRefresh();
                }
            }
            catch (Exception ee)
            {
                throw new Exception(ee.Message);
            }
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


        private void Frm客户协议登记表_Load(object sender, EventArgs e)
        {
            try
            {
                SetEnable(false);

                SetLookUpEdit();
                GetGrid();

                label8.Text = "";
                label8.Visible = true;
            }
            catch (Exception ee)
            {
                throw new Exception("加载窗体失败\n" + ee.Message);
            }

        }

        private void SetLookUpEdit()
        {
            string sSQL = @"
select cVenCode ,cVenName,cVenAbbName from 代理商 order by cVenCode
";
            DataTable dt = clsSQLCommond.ExecQuery(sSQL);
            lookUpEdit代理商.Properties.DataSource = dt;

            lookUpEdit代理商.Enabled = true;
            lookUpEdit代理商.Properties.ReadOnly = false;

            sSQL = @"
select cCode from 返点方式 order by cCode
";
            dt = clsSQLCommond.ExecQuery(sSQL);
            lookUpEdit返点方式.Properties.DataSource = dt;

            dt = new DataTable();
            DataColumn dc = new DataColumn();
            dc.ColumnName = "iYear";
            dt.Columns.Add(dc);
            for (int i = 2016; i <= DateTime.Today.Year + 1; i++)
            {
                DataRow dr = dt.NewRow();
                dr["iYear"] = i;
                dt.Rows.Add(dr);
            }
            lookUpEditYear.Properties.DataSource = dt;
            lookUpEditYear.EditValue = DateTime.Today.Year.ToString();

            sSQL = @"
select cPersonCode,cPersonName from U8Person order by cPersonCode
";
            dt = clsSQLCommond.ExecQuery(sSQL);
            lookUpEdit业务员.Properties.DataSource = dt;

            dt = new DataTable();
            dc = new DataColumn();
            dc.ColumnName = "是否有纸质合同";
            dt.Columns.Add(dc);

            DataRow dr2 = dt.NewRow();
            dr2["是否有纸质合同"] = "是";
            dt.Rows.Add(dr2);
            dr2 = dt.NewRow();
            dr2["是否有纸质合同"] = "否";
            dt.Rows.Add(dr2);
            lookUpEdit是否有纸质合同.Properties.DataSource = dt;
            lookUpEdit是否有纸质合同.EditValue = "是";

            sSQL = @"
select cCusCode,cCusName,cCusAbbName from u8Customer order by cCusCode
";
            dt = clsSQLCommond.ExecQuery(sSQL);
            lookUpEditCustomer.Properties.DataSource = dt;

            lookUpEditCustomer.Enabled = true;
            lookUpEditCustomer.Properties.ReadOnly = false;
        }




        private void lookUpEdit代理商2_EditValueChanged(object sender, EventArgs e)
        {
            try
            {
                btnTxtDLS.Text = lookUpEdit代理商.EditValue.ToString().Trim();

                if (lookUpEdit代理商.EditValue != null && lookUpEditCustomer.Text.Trim() != "" & lookUpEdit业务员.Text.Trim() != "")
                {
                    GetGrid();
                }

                GetInfo(btnTxtDLS.Text.Trim());

                btnFirst();
            }
            catch { }
        }

        private void gridView_CustomDrawRowIndicator(object sender, DevExpress.XtraGrid.Views.Grid.RowIndicatorCustomDrawEventArgs e)
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

     

        private void btnTxtDLS_KeyUp(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.F2)
                {
                    btnTxtDLS_ButtonClick(null, null);
                }
                if (e.KeyCode == Keys.Enter)
                {
                    btnTxtDLS_Leave(null, null);
                }
            }
            catch (Exception ee)
            {
                MessageBox.Show("操作失败：" + ee.Message);
            }
        }

        private void btnTxtDLS_Leave(object sender, EventArgs e)
        {
            lookUpEdit代理商.EditValue = btnTxtDLS.Text.Trim();

            if (lookUpEdit代理商.EditValue != null && lookUpEdit代理商.Text.Trim() != "" && lookUpEditCustomer.EditValue != null && lookUpEditCustomer.Text.Trim() != "")
            {
                GetGrid();
            }
        }

        private void btnTxtDLS_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            try
            {
                Frm参照 frm = new Frm参照(3);
                frm.txtSEL.Text = btnTxtDLS.Text.Trim();
                frm.ShowDialog();

                btnTxtDLS.Text = frm.iID;
                lookUpEdit代理商.EditValue = frm.iID;
            }
            catch (Exception ee)
            {
                MessageBox.Show("操作失败：" + ee.Message);
            }
        }


        private void SetEnable(bool b)
        {
            lookUpEditYear.Enabled = true;
            lookUpEditYear.Properties.ReadOnly = false;

            btnTxtDLS.Enabled = true;
            lookUpEdit代理商.Enabled = true;
            lookUpEdit业务员.Enabled = true;

            lookUpEdit业务员.Properties.ReadOnly = false;

            lookUpEdit返点方式.Enabled = b;
            lookUpEdit返点方式.Properties.ReadOnly = !b;

            lookUpEdit是否有纸质合同.Enabled = b;
            lookUpEdit是否有纸质合同.Properties.ReadOnly = !b;

            gridView1.OptionsBehavior.Editable = b;
        }


        private void gridView1_CellValueChanged(object sender, DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs e)
        {
            try
            {
                if (e.Column == gridColM1 || e.Column == gridColM2 || e.Column == gridColM3 || e.Column == gridColM4 || e.Column == gridColM5 || e.Column == gridColM6 ||
                    e.Column == gridColM7 || e.Column == gridColM8 || e.Column == gridColM9 || e.Column == gridColM10 || e.Column == gridColM11 || e.Column == gridColM12)
                {
                    decimal d1 = ReturnDecimal(gridView1.GetRowCellValue(e.RowHandle, gridColM1), 2);
                    decimal d2 = ReturnDecimal(gridView1.GetRowCellValue(e.RowHandle, gridColM2), 2);
                    decimal d3 = ReturnDecimal(gridView1.GetRowCellValue(e.RowHandle, gridColM3), 2);
                    decimal d4 = ReturnDecimal(gridView1.GetRowCellValue(e.RowHandle, gridColM4), 2);
                    decimal d5 = ReturnDecimal(gridView1.GetRowCellValue(e.RowHandle, gridColM5), 2);
                    decimal d6 = ReturnDecimal(gridView1.GetRowCellValue(e.RowHandle, gridColM6), 2);
                    decimal d7 = ReturnDecimal(gridView1.GetRowCellValue(e.RowHandle, gridColM7), 2);
                    decimal d8 = ReturnDecimal(gridView1.GetRowCellValue(e.RowHandle, gridColM8), 2);
                    decimal d9 = ReturnDecimal(gridView1.GetRowCellValue(e.RowHandle, gridColM9), 2);
                    decimal d10 = ReturnDecimal(gridView1.GetRowCellValue(e.RowHandle, gridColM10), 2);
                    decimal d11 = ReturnDecimal(gridView1.GetRowCellValue(e.RowHandle, gridColM11), 2);
                    decimal d12 = ReturnDecimal(gridView1.GetRowCellValue(e.RowHandle, gridColM12), 2);

                    decimal dSum = d1 + d2 + d3 + d4 + d5 + d6 + d7 + d8 + d9 + d10 + d11 + d12;

                    gridView1.SetRowCellValue(e.RowHandle, gridColMSum, dSum);
                }
            }
            catch (Exception ee)
            { 
            
            }
        }

        private void ItemButtonEditcInvName_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            try
            {
                Frm参照 frm = new Frm参照(1);
                frm.txtSEL.Text = gridView1.GetRowCellDisplayText(gridView1.FocusedRowHandle, gridCol品种).ToString().Trim();
                frm.ShowDialog();

                if (frm.DialogResult == DialogResult.OK)
                {
                    gridView1.SetRowCellValue(gridView1.FocusedRowHandle, gridCol编码, frm.iID);
                    gridView1.SetRowCellValue(gridView1.FocusedRowHandle, gridCol品种, frm.iText);
                    gridView1.SetRowCellValue(gridView1.FocusedRowHandle, gridCol规格型号, frm.iText2);
                }

            }
            catch (Exception ee)
            {
                MessageBox.Show("操作失败：" + ee.Message);
            }
        }

        private void ItemButtonEditcInvName_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F2)
            {
                ItemButtonEditcInvName_ButtonClick(null, null);
            }
        }

        private void ItemButtonEditcInvStd_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            try
            {
                Frm参照 frm = new Frm参照(1);
                frm.txtSEL.Text = gridView1.GetRowCellDisplayText(gridView1.FocusedRowHandle, gridCol规格型号).ToString().Trim();
                frm.ShowDialog();

                if (frm.DialogResult == DialogResult.OK)
                {
                    gridView1.SetRowCellValue(gridView1.FocusedRowHandle, gridCol编码, frm.iID);
                    gridView1.SetRowCellValue(gridView1.FocusedRowHandle, gridCol品种, frm.iText);
                    gridView1.SetRowCellValue(gridView1.FocusedRowHandle, gridCol规格型号, frm.iText2);
                }

            }
            catch (Exception ee)
            {
                MessageBox.Show("操作失败：" + ee.Message);
            }
        }

        private void ItemButtonEditcInvStd_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F2)
            {
                ItemButtonEditcInvStd_ButtonClick(null, null);
            }
        }

        private void ItemButtonEditcInvCode_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            try
            {
                Frm参照 frm = new Frm参照(1);
                frm.txtSEL.Text = gridView1.GetRowCellDisplayText(gridView1.FocusedRowHandle, gridCol编码).ToString().Trim();
                frm.ShowDialog();

                if (frm.DialogResult == DialogResult.OK)
                {
                    gridView1.SetRowCellValue(gridView1.FocusedRowHandle, gridCol编码, frm.iID);
                    gridView1.SetRowCellValue(gridView1.FocusedRowHandle, gridCol品种, frm.iText);
                    gridView1.SetRowCellValue(gridView1.FocusedRowHandle, gridCol规格型号, frm.iText2);
                }

            }
            catch (Exception ee)
            {
                MessageBox.Show("操作失败：" + ee.Message);
            }
        }

        private void ItemButtonEditcInvCode_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F2)
            {
                ItemButtonEditcInvCode_ButtonClick(null, null);
            }
        }

        private void btnTxtCustomer_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            try
            {
                Frm参照 frm = new Frm参照(4);
                frm.txtSEL.Text = btnTxtCustomer.Text.Trim();
                frm.ShowDialog();

                btnTxtCustomer.Text = frm.iID;
                lookUpEditCustomer.EditValue = frm.iID;
            }
            catch (Exception ee)
            {
                MessageBox.Show("操作失败：" + ee.Message);
            }
        }

        private void btnTxtCustomer_KeyUp(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.F2)
                {
                    btnTxtCustomer_ButtonClick(null, null);
                }
                if (e.KeyCode == Keys.Enter)
                {
                    btnTxtCustomer_Leave(null, null);
                }
            }
            catch (Exception ee)
            {
                MessageBox.Show("操作失败：" + ee.Message);
            }
        }

        private void btnTxtCustomer_Leave(object sender, EventArgs e)
        {
            lookUpEditCustomer.EditValue = btnTxtCustomer.Text.Trim();

            if (lookUpEdit代理商.EditValue != null && lookUpEdit代理商.Text.Trim() != "" && lookUpEditCustomer.EditValue != null && lookUpEditCustomer.Text.Trim() != "")
            {
                GetGrid();
            }
        }

        private void lookUpEditCustomer_EditValueChanged(object sender, EventArgs e)
        {

            try
            {
                btnTxtCustomer.Text = lookUpEditCustomer.EditValue.ToString().Trim();

                if (lookUpEdit代理商.EditValue != null && lookUpEdit代理商.Text.Trim() != "" & lookUpEdit业务员.Text.Trim() != "")
                {
                    GetGrid();
                }
            }
            catch { }
        }


        DataTable dt翻页;
        private void GetInfo(string sDLS)
        {
            if (sDLS == "")
            {
                label8.Text = "";
                label8.Visible = true;
                return;
            }

            string sSQL = @"
select distinct 代理商,开票客户,业务员
from [dbo].[客户协议登记表] 
where isnull(开票客户,'') <> ''
    and 代理商 = 'aaaaaaaa'
    and iYear = 'bbbbbbbb'
order by 代理商,开票客户,业务员
";
            sSQL = sSQL.Replace("aaaaaaaa", sDLS);
            sSQL = sSQL.Replace("bbbbbbbb", lookUpEditYear.Text.Trim());
            dt翻页 = clsSQLCommond.ExecQuery(sSQL);
            if (dt翻页 != null && dt翻页.Rows.Count > 0)
            {
                if (lookUpEditCustomer.EditValue == null || lookUpEditCustomer.EditValue.ToString().Trim() == "")
                {
                    //btnFirst();
                }
                else
                {
                    int iRow = 0;
                    for (int i = 0; i < dt翻页.Rows.Count; i++)
                    {
                        if (lookUpEditCustomer.EditValue.ToString().Trim() == dt翻页.Rows[i]["开票客户"].ToString().Trim() && lookUpEdit业务员.EditValue.ToString().Trim() == dt翻页.Rows[i]["业务员"].ToString().Trim())
                        {
                            iRow = i + 1;
                            break;
                        }
                    }

                    label8.Text = iRow.ToString() + "/" + dt翻页.Rows.Count.ToString();
                }
            }
            else
            {
                label8.Text = @"0/0";
            }
        }

        private void btnTxt业务员_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            try
            {
                Frm参照 frm = new Frm参照(7);
                frm.txtSEL.Text = btnTxt业务员.Text.Trim();
                frm.ShowDialog();

                btnTxt业务员.Text = frm.iID;
                lookUpEdit业务员.EditValue = frm.iID;

            }
            catch (Exception ee)
            {
                MessageBox.Show("操作失败：" + ee.Message);
            }
        }

        private void btnTxt业务员_KeyUp(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.F2)
                {
                    btnTxt业务员_ButtonClick(null, null);
                }
                if (e.KeyCode == Keys.Enter)
                {
                    btnTxt业务员_Leave(null, null);
                }
            }
            catch (Exception ee)
            {
                MessageBox.Show("操作失败：" + ee.Message);
            }
        }

        private void btnTxt业务员_Leave(object sender, EventArgs e)
        {
            lookUpEdit业务员.EditValue = btnTxt业务员.Text.Trim();

            if (lookUpEdit代理商.EditValue != null && lookUpEdit代理商.Text.Trim() != "" & lookUpEdit业务员.Text.Trim() != "")
            {
                GetGrid();
            }
        }

        private void lookUpEdit业务员_EditValueChanged(object sender, EventArgs e)
        {
            try
            {
                btnTxt业务员.Text = lookUpEdit业务员.EditValue.ToString().Trim();

                if (lookUpEdit代理商.EditValue != null && lookUpEdit代理商.Text.Trim() != "" && lookUpEdit业务员.EditValue != "" && lookUpEdit业务员.Text != "" && lookUpEditCustomer.EditValue != null && lookUpEditCustomer.Text.Trim() != "")
                {
                    GetGrid();
                }

                //btnFirst();
            }
            catch { }
        }

        private void lookUpEditYear_EditValueChanged(object sender, EventArgs e)
        {
            btnRefresh();
        }
    }
}
