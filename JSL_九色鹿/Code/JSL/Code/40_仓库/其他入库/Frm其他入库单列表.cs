using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraLayout;
using System.IO;

namespace 仓库
{
    public partial class Frm其他入库单列表 : 系统服务.FrmBaseInfo
    {
        string tablename = "RdRecord05";
        string tableid = "ID";
        string tablenames = "RdRecords05";
        string tableids = "AutoID";
        string cRsCode = "";

        public string 单据号1 = "";
        public string 单据号2 = "";
        public string 单据日期1 = "";
        public string 单据日期2 = "";
        public string 制单日期1 = "";
        public string 制单日期2 = "";
        public string 业务员 = "";
        public string 仓库 = "";
        public string 供应商1 = "";
        public string 供应商2 = "";
        public string 审核日期1 = "";
        public string 审核日期2 = "";
        public string 制单人1 = "";
        public string 制单人2 = "";
        public string 审核人1 = "";
        public string 审核人2 = "";
        public string 物料1 = "";
        public string 物料2 = "";

        public Frm其他入库单列表()
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
            gridView1.OptionsMenu.ShowAddNewSummaryItem = DevExpress.Utils.DefaultBoolean.False;
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
            //string sErr = "";
            //OpenFileDialog oFile = new OpenFileDialog();
            //oFile.Filter = "Excel文件2003|*.xls|Excel文件2007|*.xlsx";
            //if (oFile.ShowDialog() == DialogResult.OK)
            //{
            //    string sFilePath = oFile.FileName;
            //    string sSQL = "select 员工工号 as PerNO,姓名拼音 as NamePY,姓名 as Name,状态 as State,岗位 as Post,级别 as Levels,类型 as PerType,备注 as Remark,null as tstamp,null as iSave from [生产员工$]";
            //    DataTable dtExcel = clsExcel.ExcelToDT(sFilePath, sSQL, true);

            //    for (int i = 0; i < dtExcel.Rows.Count; i++)
            //    {
            //        string sPerNO = dtExcel.Rows[i]["PerNO"].ToString().Trim();
            //        DataRow[] dr = dtBingGrid.Select("PerNO = '" + sPerNO + "'");
            //        if (dr.Length > 0)
            //        {
            //            dtExcel.Rows[i]["tstamp"] = dr[0]["tstamp"];
            //            sErr = sErr + sPerNO + "\n";
            //        }
            //        string sName = dtExcel.Rows[i]["Name"].ToString().Trim();
            //        DataRow[] dr2 = dtBingGrid.Select("Name = '" + sName + "'");
            //        if (dr2.Length > 0)
            //        {
            //            dtExcel.Rows[i]["tstamp"] = dr2[0]["tstamp"];
            //            sErr = sErr + sName + "\n";
            //        }
            //    }

            //    gridControl1.DataSource = dtExcel;

            //    if (sErr.Length > 0)
            //    {
            //        sErr = "以下工号已经存在，不能重复导入：\n" + sErr;
            //        MsgBox("提示", sErr);
            //    }
            //}
            //else
            //{
            //    throw new Exception("取消导入");
            //}
            throw new NotImplementedException();
        }
        /// <summary>
        /// 刷新
        /// </summary>
        private void btnRefresh()
        {
            try
            {
                GetGrid();
            }
            catch (Exception ee)
            {
                MessageBox.Show("刷新窗体失败\n" + ee.Message);
            }
        }
        /// <summary>
        /// 查询
        /// </summary>
        private void btnSel()
        {
            Frm其他入库单_Add frm = new Frm其他入库单_Add(单据号1, 单据号2, 单据日期1, 单据日期2, 制单日期1, 制单日期2, 业务员,
                仓库,审核日期1, 审核日期2, 制单人1, 制单人2, 审核人1, 审核人2, 物料1, 物料2);
            if (DialogResult.OK == frm.ShowDialog())
            {
                frm.Enabled = true;
                单据号1 = frm.单据号1;
                单据号2 = frm.单据号2;
                单据日期1 = frm.单据日期1;
                单据日期2 = frm.单据日期2;
                制单日期1 = frm.制单日期1;
                制单日期2 = frm.制单日期2;
                业务员 = frm.业务员;
                仓库 = frm.仓库;
                审核日期1 = frm.审核日期1;
                审核日期2 = frm.审核日期2;
                制单人1 = frm.制单人1;
                制单人2 = frm.制单人2;
                审核人1 = frm.审核人1;
                审核人2 = frm.审核人2;
                物料1 = frm.物料1;
                物料2 = frm.物料2;
                GetGrid();
            }


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
            for (int i = gridView1.RowCount - 1; i >= 0; i--)
            {
                if (gridView1.IsRowSelected(i))
                {
                    gridView1.DeleteRow(i);
                }
            }
        }
        /// <summary>
        /// 修改
        /// </summary>
        private void btnEdit()
        {
            gridView1.OptionsBehavior.ReadOnly = false;
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
            try
            {
                gridView1.FocusedRowHandle -= 1;
                gridView1.FocusedRowHandle += 1;
            }
            catch { }

            aList = new System.Collections.ArrayList();
            string slist = "";
            string sErr = "";
            for (int i = 0; i < gridView1.RowCount; i++)
            {
                if (Convert.ToBoolean(gridView1.GetRowCellValue(i, gridCol选择)))
                {
                    string sID = gridView1.GetRowCellValue(i, gridColID).ToString().Trim();

                    int iRe = CheState(sID);
                    if (iRe == -1)
                    {
                        sErr = sErr + "行" + (i + 1).ToString() + "检查单据状态出错\n";
                        continue;
                    }
                    if (iRe == 0)
                    {
                        sErr = sErr + "行" + (i + 1).ToString() + "单据不存在\n";
                        continue;
                    }
                    if (iRe == 2)
                    {
                        sErr = sErr + "行" + (i + 1).ToString() + "单据已审核\n";
                        continue;
                    }
                    if (iRe == 3)
                    {
                        sErr = sErr + "行" + (i + 1).ToString() + "单据已关闭\n";
                        continue;
                    }

                    sSQL = "update " + tablename + " set dVerifysysTime='" + GetSystemTime() + "',dVerifysysPerson='" + 系统服务.ClsBaseDataInfo.sUid + "' "
                    + "where ID=" + gridView1.GetRowCellValue(i, gridColID).ToString().Trim() + " and  (dVerifysysPerson='' or dVerifysysPerson is null)";
                    aList.Add(sSQL);
                }
            }
            if (sErr != "")
            {
                throw new Exception("请选择需审核的单据！" + sErr);
            }

            if (aList.Count > 0)
            {
                int iCou = clsSQLCommond.ExecSqlTran(aList);
                GetGrid();
                MessageBox.Show("审核成功！\n合计执行语句:" + iCou + "条");
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

            aList = new System.Collections.ArrayList();
            string sList = "";
            string sErr = "";
            for (int i = 0; i < gridView1.RowCount; i++)
            {
                if (Convert.ToBoolean(gridView1.GetRowCellValue(i, gridCol选择)))
                {
                    string sID = gridView1.GetRowCellValue(i, gridColID).ToString().Trim();

                    int iRe = CheState(sID);
                    if (iRe == -1)
                    {
                        sErr = sErr + "行" + (i + 1).ToString() + "检查单据状态出错\n";
                        continue;
                    }
                    if (iRe == 0)
                    {
                        sErr = sErr + "行" + (i + 1).ToString() + "单据不存在\n";
                        continue;
                    }
                    //if (iRe == 2)
                    //{
                    //    sErr = sErr + "行" + (i + 1).ToString() + "单据未关闭\n";
                    //    continue;
                    //}
                    if (iRe == 3)
                    {
                        sErr = sErr + "行" + (i + 1).ToString() + "单据已关闭\n";
                        continue;
                    }

                    sSQL = "update " + tablename + " set dVerifysysTime=null,dVerifysysPerson=null where ID=" + gridView1.GetRowCellValue(i, gridColID).ToString().Trim() + "";
                    aList.Add(sSQL);
                }
            }
            if (sErr != "")
            {
                throw new Exception("请选择需弃审的单据！" + sErr);
            }
        
            if (aList.Count > 0)
            {
                int iCou = iCou = clsSQLCommond.ExecSqlTran(aList);
                GetGrid();
                MessageBox.Show("弃审成功");
            }
        }
        /// <summary>
        /// 打开
        /// </summary>
        private void btnOpen()
        {
            try
            {
                gridView1.FocusedRowHandle -= 1;
                gridView1.FocusedRowHandle += 1;
            }
            catch { }

            aList = new System.Collections.ArrayList();
            string sList = "";
            string sErr = "";
            for (int i = 0; i < gridView1.RowCount; i++)
            {
                if (Convert.ToBoolean(gridView1.GetRowCellValue(i, gridCol选择)))
                {
                    string sID = gridView1.GetRowCellValue(i, gridColID).ToString().Trim();

                    int iRe = CheState(sID);
                    if (iRe == -1)
                    {
                        sErr = sErr + "行" + (i + 1).ToString() + "检查单据状态出错\n";
                        continue;
                    }
                    if (iRe == 0)
                    {
                        sErr = sErr + "行" + (i + 1).ToString() + "单据不存在\n";
                        continue;
                    }
                    if (iRe == 2)
                    {
                        sErr = sErr + "行" + (i + 1).ToString() + "单据未关闭\n";
                        continue;
                    }
                    //if (iRe == 3)
                    //{
                    //    sErr = sErr + "行" + (i + 1).ToString() + "单据已关闭\n";
                    //    continue;
                    //}

                    sSQL = "update " + tablename + " set dChangeVerifyTime=null,dClosesysPerson=null where ID=" + gridView1.GetRowCellValue(i, gridColID).ToString().Trim() + "";
                    aList.Add(sSQL);
                }
            }
            if (sErr != "")
            {
                throw new Exception(sErr);
            }
            int iCou = 0;
            if (aList.Count > 0)
            {
                iCou = clsSQLCommond.ExecSqlTran(aList);
                GetGrid();

                MessageBox.Show("打开成功！");
            }
        }

        /// <summary>
        /// 关闭
        /// </summary>
        private void btnClose()
        {
            try
            {
                gridView1.FocusedRowHandle -= 1;
                gridView1.FocusedRowHandle += 1;
            }
            catch { }

            aList = new System.Collections.ArrayList();
            string slist = "";
            string sErr = "";
            for (int i = 0; i < gridView1.RowCount; i++)
            {
                if (Convert.ToBoolean(gridView1.GetRowCellValue(i, gridCol选择)))
                {
                    string sID = gridView1.GetRowCellValue(i, gridColID).ToString().Trim();

                    int iRe = CheState(sID);
                    if (iRe == -1)
                    {
                        sErr = sErr + "行" + (i + 1).ToString() + "检查单据状态出错\n";
                        continue;
                    }
                    if (iRe == 0)
                    {
                        sErr = sErr + "行" + (i + 1).ToString() + "单据不存在\n";
                        continue;
                    }
                    //if (iRe == 2)
                    //{
                    //    sErr = sErr + "行" + (i + 1).ToString() + "单据未关闭\n";
                    //    continue;
                    //}
                    if (iRe == 3)
                    {
                        sErr = sErr + "行" + (i + 1).ToString() + "单据已关闭\n";
                        continue;
                    }

                    sSQL = "update " + tablename + " set dClosesysTime='" + GetSystemTime() + "',dClosesysPerson='" + 系统服务.ClsBaseDataInfo.sUid + "' where id=" + gridView1.GetRowCellValue(i, gridColID).ToString().Trim() + " ";
                    aList.Add(sSQL);
                }
            }
            if (sErr != "")
            {
                throw new Exception(sErr);
            }

            if (aList.Count > 0)
            {
                int iCou = clsSQLCommond.ExecSqlTran(aList);
                GetGrid();
                MessageBox.Show("关闭成功！");
            }
        }

        /// <summary>
        /// 变更
        /// </summary>
        private void btnAlter()
        {
            throw new NotImplementedException();
        }

        #endregion

        private void Frm其他入库单列表_Load(object sender, EventArgs e)
        {
            try
            {
                GetGridViewSet(gridView1);
                GetTitle();
                GetLayOut(layoutControl1, gridControl1);
                SetLookUpEdit();
                GetGrid();
            }
            catch (Exception ee)
            {
                MessageBox.Show("加载窗体失败\n" + ee.Message);
            }
        }

        /// <summary>
        /// 下拉列表框
        /// </summary>
        private void SetLookUpEdit()
        {
            系统服务.LookUp._LoopUpData(ItemLookUpEdit红蓝标识,"5");
            系统服务.LookUp.Person(ItemLookUpEditPerson);
            系统服务.LookUp.Warehouse(ItemLookUpEdit仓库);
            系统服务.LookUp.RdStyle(ItemLookUpEdit入库类别);
            系统服务.LookUp.Department(ItemLookUpEdit部门);
            系统服务.LookUp.Customer(ItemLookUpEdit客户名称);
            系统服务.LookUp.Position(ItemLookUpEdit货位);

            系统服务.LookUp.Inventory(ItemLookUpEdit物料名称);
            ItemLookUpEdit物料名称.Properties.DisplayMember = "cInvName";
            系统服务.LookUp.Inventory(ItemLookUpEdit物料规格);
            ItemLookUpEdit物料规格.Properties.DisplayMember = "cInvStd";
            系统服务.LookUp.Inventory(ItemLookUpEdit物料代码);
            ItemLookUpEdit物料规格.Properties.DisplayMember = "cInvAddCode";
        }

        private void GetTitle()
        {
            string title = this.Text;
            if (title.IndexOf("辅料") > -1)
            {
                cRsCode = "0503";
                gridColM1.Visible = false;
                gridColM2.Visible = false;
                gridCol入库单AutoID.Visible = false;
                gridCol客户名称.Caption = "供应商";
            }
            else if (title.IndexOf("期初原料") > -1)
            {
                cRsCode = "0501";
            }
            else if (title.IndexOf("期初成品") > -1)
            {
                cRsCode = "0502";
            }
            else if (title.IndexOf("盘点") > -1)
            {
                cRsCode = "0504";
            }
            else if (title.IndexOf("调拨") > -1)
            {
                cRsCode = "0505";
                gridCol盒数.Visible = false;
            }
        }

        private void GetGrid()
        {
            int iFocRow = gridView1.FocusedRowHandle;
            string sSQL = "select a.*,b.*,i.cInvName,i.cInvStd,cast(0 as bit) as iChk,iOutQuantity from dbo." + tablename + " a left join " + tablenames + " b on a.ID=b.ID "
            + @" left join Inventory i on b.cInvCode=i.cInvCode left join RdStyle r on a.cRSCode=r.cRSCode where 收发标志='0' and a.cRSCode='" + cRsCode + "' ";
            if (单据号1 != "")
            {
                sSQL = sSQL + " and a.cRDCode>='" + 单据号1 + "'";
            }
            if (单据号2 != "")
            {
                sSQL = sSQL + " and a.cRDCode<='" + 单据号2 + "'";
            }
            if (单据日期1 != "")
            {
                sSQL = sSQL + " and dDate>='" + 单据日期1 + "'";
            }
            if (单据日期2 != "")
            {
                sSQL = sSQL + " and dDate<='" + 单据日期2 + "'";
            }
            if (制单日期1 != "")
            {
                sSQL = sSQL + " and dCreatesysTime>='" + 制单日期1 + "'";
            }
            if (制单日期2 != "")
            {
                sSQL = sSQL + " and dCreatesysTime<='" + 制单日期2 + "'";
            }
            if (业务员 != "")
            {
                sSQL = sSQL + " and cPersonCode='" + 业务员 + "'";
            }
            if (仓库 != "")
            {
                sSQL = sSQL + " and cDepCode='" + 仓库 + "'";
            }
            if (供应商1 != "")
            {
                sSQL = sSQL + " and cVenCode>='" + 供应商1 + "'";
            }
            if (供应商2 != "")
            {
                sSQL = sSQL + " and cVenCode<='" + 供应商2 + "'";
            }
            if (审核日期1 != "")
            {
                sSQL = sSQL + " and dVerifysysTime>='" + 审核日期1 + "'";
            }
            if (审核日期2 != "")
            {
                sSQL = sSQL + " and dVerifysysTime<='" + 审核日期2 + "'";
            }
            if (制单人1 != "")
            {
                sSQL = sSQL + " and dCreatesysPerson>='" + 制单人1 + "'";
            }
            if (制单人2 != "")
            {
                sSQL = sSQL + " and dCreatesysPerson<='" + 制单人2 + "'";
            }
            if (审核人1 != "")
            {
                sSQL = sSQL + " and dVerifysysPerson>='" + 审核人1 + "'";
            }
            if (审核人2 != "")
            {
                sSQL = sSQL + " and dVerifysysPerson<='" + 审核人2 + "'";
            }
            if (物料1 != "")
            {
                sSQL = sSQL + " and b.cInvCode>='" + 物料1 + "'";
            }
            if (物料2 != "")
            {
                sSQL = sSQL + " and b.cInvCode<='" + 物料2 + "'";
            }
            sSQL = sSQL + " order by  a." + tableid + " desc";
            dtBingGrid = clsSQLCommond.ExecQuery(sSQL);
            gridControl1.DataSource = dtBingGrid;

            checkEditChk.Checked = false;
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

        private void checkEditChk_CheckedChanged(object sender, EventArgs e)
        {
            for (int i = 0; i < gridView1.RowCount; i++)
            {
                gridView1.SetRowCellValue(i, gridCol选择, checkEditChk.Checked);
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

                Frm其他入库单 frm = new Frm其他入库单(sID, this.Text.Replace("列表", ""));
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

        /// <summary>
        /// 判断单据状态
        /// </summary>
        /// <param name="sCode">单据号</param>
        /// <returns>-1：出错</returns>
        /// <returns>0 ：不存在单据</returns>
        /// <returns>1 ：已保存</returns>
        /// <returns>2 ：已审核</returns>
        /// <returns>3 ：已关闭</returns>
        private int CheState(string sID)
        {
            int iReturn = -1;
            try
            {
                sSQL = "select  isnull(dCreatesysPerson,'') as 制单人,isnull(dVerifysysPerson,'') as 审核人,isnull(dClosesysPerson,'') as 关闭人 from " + tablename + " where " + tableid + " = '" + sID + "'";
                DataTable dt = clsSQLCommond.ExecQuery(sSQL);
                if (dt == null || dt.Rows.Count < 1)
                    iReturn = 0;
                else
                {
                    if (dt.Rows[0]["制单人"] != "")
                    {
                        iReturn = 1;
                    }
                    if (dt.Rows[0]["审核人"] != "")
                    {
                        iReturn = 2;
                    }
                    if (dt.Rows[0]["关闭人"] != "")
                    {
                        iReturn = 3;
                    }
                }
            }
            catch (Exception ee)
            { }
            return iReturn;
        }

        private void ItemCheckEdit选择_CheckedChanged(object sender, EventArgs e)
        {
            int iRow = gridView1.FocusedRowHandle;
            try
            {
                gridView1.FocusedRowHandle -= 1;
                gridView1.FocusedRowHandle += 1;
            }
            catch { }

            string sCode = gridView1.GetRowCellValue(iRow, gridCol单据号).ToString().Trim();
            for (int i = 0; i < gridView1.RowCount; i++)
            {
                if (i == iRow)
                    continue;
                string sCode2 = gridView1.GetRowCellValue(i, gridCol单据号).ToString().Trim();
                if (sCode == sCode2)
                {
                    gridView1.SetRowCellValue(i, gridCol选择, Convert.ToBoolean(gridView1.GetRowCellValue(iRow, gridCol选择)));
                }
            }
        }
    }
}