using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraLayout;
using System.IO;

namespace Warehouse
{
    public partial class Frm生产材料货位调拨 : FrameBaseFunction.Frm列表窗体模板
    {
        public Frm生产材料货位调拨()
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
                    case "add":
                        btnAdd();
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
            for (int i = 0; i < gridView1.RowCount; i++)
            {
                if (gridView1.GetRowCellValue(i, gridCol本次调拨) != null && gridView1.GetRowCellValue(i, gridCol本次调拨).ToString().Trim() != "")
                    continue;

                string sInvCode = gridView1.GetRowCellValue(i, gridCol子件编码).ToString().Trim();
                if ("WW0013Barcel01" == sInvCode)
                { 
                
                }
                decimal d累计下单 = FrameBaseFunction.ClsBaseDataInfo.ReturnDecimal(gridView1.GetRowCellValue(i, gridCol累计下单));
                decimal d现存量 = FrameBaseFunction.ClsBaseDataInfo.ReturnDecimal(gridView1.GetRowCellValue(i, gridCol仓库可用量));
                decimal d待调拨 = FrameBaseFunction.ClsBaseDataInfo.ReturnDecimal(gridView1.GetRowCellValue(i, gridCol子件待调拨数量));
                decimal d本次调拨 = FrameBaseFunction.ClsBaseDataInfo.ReturnDecimal(gridView1.GetRowCellValue(i, gridCol本次调拨));

                if (d待调拨 + d累计下单 < d现存量)
                {
                    d本次调拨 = d待调拨;
                    d累计下单 = d累计下单 + d本次调拨;
                }
                else
                {
                    if (d现存量 > d累计下单)
                    {
                        d本次调拨 = d现存量 - d累计下单;
                        d累计下单 = d累计下单 + d本次调拨;
                    }
                }
                gridView1.SetRowCellValue(i, gridCol累计下单, d累计下单);
                gridView1.SetRowCellValue(i, gridCol本次调拨, d本次调拨);

                for (int j = i+1; j < gridView1.RowCount; j++)
                {
                    string sInvCode2 = gridView1.GetRowCellValue(j, gridCol子件编码).ToString().Trim();
                    if (sInvCode == sInvCode2)
                    {
                        decimal d待调拨2 = FrameBaseFunction.ClsBaseDataInfo.ReturnDecimal(gridView1.GetRowCellValue(j, gridCol子件待调拨数量));
                        decimal d本次调拨2 = FrameBaseFunction.ClsBaseDataInfo.ReturnDecimal(gridView1.GetRowCellValue(j, gridCol本次调拨));
                        if (d累计下单 < d现存量)
                        {
                            if (d待调拨2 > d现存量 - d累计下单)
                            {
                                d本次调拨2 = d现存量 - d累计下单;
                                d累计下单 = d现存量;
                            }
                            else
                            {
                                d本次调拨2 = d待调拨2;
                                d累计下单 = d累计下单 + d本次调拨2;
                            }
                        }
                        gridView1.SetRowCellValue(j, gridCol累计下单, d累计下单);
                        gridView1.SetRowCellValue(j, gridCol本次调拨, d本次调拨2);
                    }
                }
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
            //DataTable dtState = (DataTable)ItemLookUpEditState.DataSource;
            //DataColumn dc = new DataColumn();
            //dc.ColumnName = "StateText";
            //dt.Columns.Add(dc);
           
            //for (int i = 0; i < dt.Rows.Count; i++)
            //{
            //    DataRow[] drState = dtState.Select("iID = '" + dt.Rows[i]["State"].ToString().Trim() + "'");
            //    if (drState.Length > 0)
            //    {
            //        dt.Rows[i]["StateText"] = drState[0]["State"];
            //    }

            //}

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

            for (int i = dtGrid.Rows.Count - 1; i >= 0; i--)
            {
                if (dtGrid.Rows[i]["iChk"].ToString().Trim() != "√")
                    dtGrid.Rows.RemoveAt(i);
            }

            for (int i = 0; i < dtGrid.Rows.Count; i++)
            {
                dtGrid.Rows[i]["本次调拨"] = FrameBaseFunction.ClsBaseDataInfo.ReturnDecimal(FrameBaseFunction.ClsBaseDataInfo.ReturnDouble(dtGrid.Rows[i]["本次调拨"]));
                dtGrid.Rows[i]["UnTransQty"] = FrameBaseFunction.ClsBaseDataInfo.ReturnDecimal(FrameBaseFunction.ClsBaseDataInfo.ReturnDouble(dtGrid.Rows[i]["UnTransQty"]));
            }

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
            //string sErr = "";
            //OpenFileDialog oFile = new OpenFileDialog();
            //oFile.Filter = "Excel文件2003|*.xls|Excel文件2007|*.xlsx";
            //if (oFile.ShowDialog() == DialogResult.OK)
            //{
            //    string sFilePath = oFile.FileName;
            //    string sSQL = "select distinct 设备编号 as MachineNO,设备 as Machine,负责人,状态 as State,备注 as Remark,null as tstamp,null as iSave from [设备档案$]";

            //    DataTable dtExcel = clsExcel.ExcelToDT(sFilePath, sSQL, true);

            //    for (int i = 0; i < dtExcel.Rows.Count; i++)
            //    {
            //        string sMachineNO = dtExcel.Rows[i]["MachineNO"].ToString().Trim();
            //        DataRow[] dr = dtBingGrid.Select("MachineNO = '" + sMachineNO + "'");
            //        if (dr.Length > 0)
            //        {
            //            dtExcel.Rows[i]["tstamp"] = dr[0]["tstamp"];
            //            sErr = sErr + sMachineNO + "\n";
            //        }
            //    }
            //    gridControl1.DataSource = dtExcel;

            //    if (sErr.Length > 0)
            //    {
            //        sErr = "以下设备编号已经存在，不能重复导入：\n" + sErr;
            //        MsgBox("提示", sErr);
            //    }
            //}
            //else
            //{
            //    throw new Exception("取消导入");
            //}
        }
        /// <summary>
        /// 刷新
        /// </summary>
        private void btnRefresh()
        {
            throw new NotImplementedException();
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
            for (int i = gridView1.RowCount - 1; i >= 0 ; i--)
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

            string s调拨单号 = "";
            string sErr = "";
            int iCou = 0;
            for (int i = 0; i < gridView1.RowCount; i++)
            {
                if (gridView1.GetRowCellValue(i, gridColiChk).ToString().Trim() == "")
                    continue;
                if (gridView1.GetRowCellValue(i, gridCol调出仓库) == null || gridView1.GetRowCellValue(i, gridCol调出仓库).ToString().Trim() == "")
                {
                    sErr = sErr + "行" + (i + 1) + "调出仓库不能为空\n";
                    continue;
                }
                if (gridView1.GetRowCellValue(i, gridCol调入仓库) == null || gridView1.GetRowCellValue(i, gridCol调入仓库).ToString().Trim() == "")
                {
                    sErr = sErr + "行" + (i + 1) + "调入仓库不能为空\n";
                    continue;
                }
                if (gridView1.GetRowCellValue(i, gridCol调出部门) == null || gridView1.GetRowCellValue(i, gridCol调出部门).ToString().Trim() == "")
                {
                    sErr = sErr + "行" + (i + 1) + "调出部门不能为空\n";
                    continue;
                }
                if (gridView1.GetRowCellValue(i, gridCol调入部门) == null || gridView1.GetRowCellValue(i, gridCol调入部门).ToString().Trim() == "")
                {
                    sErr = sErr + "行" + (i + 1) + "调入部门不能为空\n";
                    continue;
                }
                if (gridView1.GetRowCellValue(i, gridCol出库类别) == null || gridView1.GetRowCellValue(i, gridCol出库类别).ToString().Trim() == "")
                {
                    sErr = sErr + "行" + (i + 1) + "出库类别不能为空\n";
                    continue;
                }
                if (gridView1.GetRowCellValue(i, gridCol入库类别) == null || gridView1.GetRowCellValue(i, gridCol入库类别).ToString().Trim() == "")
                {
                    sErr = sErr + "行" + (i + 1) + "入库类别不能为空\n";
                    continue;
                }
                if (FrameBaseFunction.ClsBaseDataInfo.ReturnDecimal(gridView1.GetRowCellValue(i, gridCol本次调拨)) == 0)
                {
                    sErr = sErr + "行" + (i + 1) + "调拨数量必须大于0\n";
                    continue;
                }

                string s调出仓库 = gridView1.GetRowCellValue(i, gridCol调出仓库).ToString().Trim();
                string s调入仓库 = gridView1.GetRowCellValue(i, gridCol调入仓库).ToString().Trim();
                string s调出部门 = gridView1.GetRowCellValue(i, gridCol调出部门).ToString().Trim();
                string s调入部门 = gridView1.GetRowCellValue(i, gridCol调入部门).ToString().Trim();
                string s出库类别 = gridView1.GetRowCellValue(i, gridCol出库类别).ToString().Trim();
                string s入库类别 = gridView1.GetRowCellValue(i, gridCol入库类别).ToString().Trim();
                if (s调出仓库 == s调入仓库)
                {
                    sErr = sErr + "行" + (i + 1) + "调拨仓库不能相同\n";
                    continue;
                }
                if (s调出部门 == s调入部门)
                {
                    sErr = sErr + "行" + (i + 1) + "调拨部门不能相同\n";
                    continue;
                }

                iCou += 1;
            }
            if (sErr.Trim().Length > 0)
            {
                throw new Exception(sErr);
            }
            if (iCou == 0)
            {
                throw new Exception("没有符合调拨条件的行");
            }

            aList = new System.Collections.ArrayList();

            sSQL = "select * from @u8.TransVouch where 1=-1";
            DataTable dtTransVouch = clsSQLCommond.ExecQuery(sSQL);
            sSQL = "select * from @u8.TransVouchs  where 1=-1";
            DataTable dtTransVouchs = clsSQLCommond.ExecQuery(sSQL);

            DateTime dtm1 = dtm单据日期1.DateTime;
            long iTrID = 0;
            long iTrIDDetail = 0;
            GetID("tr", out iTrID, out iTrIDDetail);
            sSQL = "select max(cast(isnull(cNumber,0) as decimal(16,9))) as Maxnumber From @u8.VoucherHistory  with (NOLOCK) Where  CardNumber='0304'  and (cSeed = '" + dtm1.ToString("yyMM") + "' or cSeed = '" + dtm1.ToString("yyyyMM") + "')";
            DataTable dtCode = clsSQLCommond.ExecQuery(sSQL);
            long iTrCode = Convert.ToInt64(dtCode.Rows[0]["Maxnumber"]);

            for (int i = 0; i < gridView1.RowCount; i++)
            {
                if (gridView1.GetRowCellValue(i, gridColiChk).ToString().Trim() == "")
                    continue;

                string s调出仓库 = gridView1.GetRowCellValue(i, gridCol调出仓库).ToString().Trim();
                string s调入仓库 = gridView1.GetRowCellValue(i, gridCol调入仓库).ToString().Trim();
                string s调出部门 = gridView1.GetRowCellValue(i, gridCol调出部门).ToString().Trim();
                string s调入部门 = gridView1.GetRowCellValue(i, gridCol调入部门).ToString().Trim();
                string s出库类别 = gridView1.GetRowCellValue(i, gridCol出库类别).ToString().Trim();
                string s入库类别 = gridView1.GetRowCellValue(i, gridCol入库类别).ToString().Trim();
                string s生产订单号 = gridView1.GetRowCellValue(i, gridCol生产订单号).ToString().Trim();
                decimal d本次调拨 = FrameBaseFunction.ClsBaseDataInfo.ReturnDecimal(gridView1.GetRowCellValue(i, gridCol本次调拨));
                string sTrCode1 = "";

                bool b相同表头 = false;
                long lID = 0;

                for (int j = 0; j < dtTransVouch.Rows.Count; j++)
                {
                    string s调出仓库2 = dtTransVouch.Rows[j]["cOWhCode"].ToString().Trim();
                    string s调入仓库2 = dtTransVouch.Rows[j]["cIWhCode"].ToString().Trim();
                    string s调出部门2 = dtTransVouch.Rows[j]["cODepCode"].ToString().Trim();
                    string s调入部门2 = dtTransVouch.Rows[j]["cIDepCode"].ToString().Trim();
                    string s出库类别2 = dtTransVouch.Rows[j]["cORdCode"].ToString().Trim();
                    string s入库类别2 = dtTransVouch.Rows[j]["cIRdCode"].ToString().Trim();
                    string s生产订单号2 = dtTransVouch.Rows[j]["cMPoCode"].ToString().Trim();

                    if (s调出仓库 == s调出仓库2 && s调入仓库 == s调入仓库2 && s调出部门 == s调出部门2 && s调入部门 == s调入部门2
                        && s出库类别 == s出库类别2 && s入库类别 == s入库类别2)
                    {
                        lID = Convert.ToInt64(dtTransVouch.Rows[j]["ID"]);
                        sTrCode1 = dtTransVouch.Rows[j]["cTVCode"].ToString().Trim();
                        b相同表头 = true;
                        break;
                    }
                }
                if (!b相同表头)
                {
                    iTrID += 1;
                    lID = iTrID;

                    DataRow drTransVouch = dtTransVouch.NewRow();
                    iTrCode += 1;
                    sTrCode1 = sSetTransVouchCode(iTrCode);
                    s调拨单号 = s调拨单号 + "\n" + sTrCode1;

                    iTrID += 1;
                    lID = iTrID;
                    drTransVouch["cTVCode"] = sTrCode1;
                    drTransVouch["dTVDate"] = FrameBaseFunction.ClsBaseDataInfo.sLogDate;
                    drTransVouch["cOWhCode"] = s调出仓库;
                    drTransVouch["cIWhCode"] = s调入仓库;
                    drTransVouch["cODepCode"] = s调出部门;
                    drTransVouch["cIDepCode"] = s调入部门;
                    drTransVouch["cPersonCode"] = DBNull.Value;
                    drTransVouch["cIRdCode"] = s入库类别;
                    drTransVouch["cORdCode"] = s出库类别;
                    drTransVouch["cTVMemo"] = DBNull.Value;
                    drTransVouch["cDefine1"] = DBNull.Value;
                    drTransVouch["cDefine2"] = DBNull.Value;
                    drTransVouch["cDefine3"] = DBNull.Value;
                    drTransVouch["cDefine4"] = DBNull.Value;
                    drTransVouch["cDefine5"] = DBNull.Value;
                    drTransVouch["cDefine6"] = DBNull.Value;
                    drTransVouch["cDefine7"] = DBNull.Value;
                    drTransVouch["cDefine8"] = DBNull.Value;
                    drTransVouch["cDefine9"] = DBNull.Value;
                    drTransVouch["cDefine10"] = DBNull.Value;
                    drTransVouch["cAccounter"] = DBNull.Value;
                    drTransVouch["cMaker"] = FrameBaseFunction.ClsBaseDataInfo.sUserName;
                    drTransVouch["iNetLock"] = 0;
                    drTransVouch["ID"] = lID;
                    drTransVouch["VT_ID"] = 89;
                    drTransVouch["cVerifyPerson"] = DBNull.Value;
                    drTransVouch["dVerifyDate"] = DBNull.Value;
                    drTransVouch["cPSPCode"] = gridView1.GetRowCellValue(i, gridCol物料编码);
                    drTransVouch["cMPoCode"] = s生产订单号;
                    drTransVouch["iQuantity"] = FrameBaseFunction.ClsBaseDataInfo.ReturnDecimal(gridView1.GetRowCellValue(i, gridCol生产订单数量));
                    drTransVouch["bTransFlag"] = DBNull.Value;
                    drTransVouch["cDefine11"] = DBNull.Value;
                    drTransVouch["cDefine12"] = DBNull.Value;
                    drTransVouch["cDefine13"] = DBNull.Value;
                    drTransVouch["cDefine14"] = DBNull.Value;
                    drTransVouch["cDefine15"] = DBNull.Value;
                    drTransVouch["cDefine16"] = DBNull.Value;
                    //drTransVouch["ufts"] = DBNull.Value;
                    drTransVouch["iproorderid"] = DBNull.Value;
                    drTransVouch["cOrderType"] = "生产订单";
                    drTransVouch["cTranRequestCode"] = DBNull.Value;
                    drTransVouch["cVersion"] = DBNull.Value;
                    drTransVouch["BomId"] = DBNull.Value;
                    drTransVouch["cFree1"] = DBNull.Value;
                    drTransVouch["cFree2"] = DBNull.Value;
                    drTransVouch["cFree3"] = DBNull.Value;
                    drTransVouch["cFree4"] = DBNull.Value;
                    drTransVouch["cFree5"] = DBNull.Value;
                    drTransVouch["cFree6"] = DBNull.Value;
                    drTransVouch["cFree7"] = DBNull.Value;
                    drTransVouch["cFree8"] = DBNull.Value;
                    drTransVouch["cFree9"] = DBNull.Value;
                    drTransVouch["cFree10"] = DBNull.Value;
                    drTransVouch["cAppTVCode"] = DBNull.Value;
                    drTransVouch["csource"] = 1;
                    drTransVouch["itransflag"] = "正向";
                    //drTransVouch["cModifyPerson"] = FrameBaseFunction.ClsBaseDataInfo.sUserName;
                    //drTransVouch["dModifyDate"] = FrameBaseFunction.ClsBaseDataInfo.sLogDate;
                    drTransVouch["dnmaketime"] = Get当前服务器时间();
                    //drTransVouch["dnmodifytime"] = FrameBaseFunction.ClsBaseDataInfo.sLogDate;
                    drTransVouch["dnverifytime"] = DBNull.Value;
                    drTransVouch["ireturncount"] = 0;
                    drTransVouch["iverifystate"] = 0;
                    drTransVouch["iswfcontrolled"] = 0;

                    dtTransVouch.Rows.Add(drTransVouch);

                    aList.Add(clsGetSQL.GetInsertSQL(FrameBaseFunction.ClsBaseDataInfo.sUFDataBaseName, "TransVouch", dtTransVouch, dtTransVouch.Rows.Count - 1));
                }
                if(FrameBaseFunction.ClsBaseDataInfo.ReturnDecimal(gridView1.GetRowCellValue(i, gridCol本次调拨)) == 0)
                    throw new Exception("行" + (i + 1) + "调拨仓库不能相同");

                DataRow drTransVouchs = dtTransVouchs.NewRow();
                drTransVouchs["cTVCode"] = sTrCode1;
                drTransVouchs["cInvCode"] = gridView1.GetRowCellValue(i, gridCol子件编码);
                drTransVouchs["RdsID"] = DBNull.Value;
                drTransVouchs["iTVQuantity"] = FrameBaseFunction.ClsBaseDataInfo.ReturnDecimal(gridView1.GetRowCellValue(i, gridCol本次调拨));

                if (FrameBaseFunction.ClsBaseDataInfo.ReturnDecimal(gridView1.GetRowCellValue(i, gridCol子件换算率)) != 0)
                {
                    drTransVouchs["iinvexchrate"] = FrameBaseFunction.ClsBaseDataInfo.ReturnDecimal(gridView1.GetRowCellValue(i, gridCol子件换算率));
                    drTransVouchs["iTVNum"] = FrameBaseFunction.ClsBaseDataInfo.ReturnDecimal(FrameBaseFunction.ClsBaseDataInfo.ReturnDecimal(gridView1.GetRowCellValue(i, gridCol本次调拨)) / FrameBaseFunction.ClsBaseDataInfo.ReturnDecimal(gridView1.GetRowCellValue(i, gridCol子件换算率)));
                    drTransVouchs["cAssUnit"] = gridView1.GetRowCellValue(i, gridCol子件辅助计量);
                }
          
                drTransVouchs["iTVACost"] = DBNull.Value;
                drTransVouchs["iTVAPrice"] = DBNull.Value;
                drTransVouchs["iTVPCost"] = DBNull.Value;
                drTransVouchs["iTVPPrice"] = DBNull.Value;
                drTransVouchs["cTVBatch"] = DBNull.Value;
                drTransVouchs["dDisDate"] = DBNull.Value;
                drTransVouchs["cFree1"] = DBNull.Value;
                drTransVouchs["cFree2"] = DBNull.Value;
                drTransVouchs["cDefine22"] = DBNull.Value;
                drTransVouchs["cDefine23"] = DBNull.Value;
                drTransVouchs["cDefine24"] = DBNull.Value;
                drTransVouchs["cDefine25"] = DBNull.Value;
                drTransVouchs["cDefine26"] = DBNull.Value;
                drTransVouchs["cDefine27"] = DBNull.Value;
                if (gridView1.GetRowCellValue(i, gridCol项目编码).ToString().Trim() != "")
                {
                    drTransVouchs["cItemCode"] = gridView1.GetRowCellValue(i, gridCol项目编码);
                    drTransVouchs["cItem_class"] = "00";
                }
                drTransVouchs["fSaleCost"] = 0;
                drTransVouchs["fSalePrice"] = 0;
                drTransVouchs["cName"] = DBNull.Value;
                drTransVouchs["cItemCName"] = DBNull.Value;

                iTrIDDetail += 1;
                drTransVouchs["autoID"] = iTrIDDetail;
                drTransVouchs["ID"] = lID;
                drTransVouchs["iMassDate"] = DBNull.Value;
                drTransVouchs["cBarCode"] = DBNull.Value;
                drTransVouchs["cFree3"] = DBNull.Value;
                drTransVouchs["cFree4"] = DBNull.Value;
                drTransVouchs["cFree5"] = DBNull.Value;
                drTransVouchs["cFree6"] = DBNull.Value;
                drTransVouchs["cFree7"] = DBNull.Value;
                drTransVouchs["cFree8"] = DBNull.Value;
                drTransVouchs["cFree9"] = DBNull.Value;
                drTransVouchs["cFree10"] = DBNull.Value;
                drTransVouchs["cDefine28"] = DBNull.Value;
                drTransVouchs["cDefine29"] = DBNull.Value;
                drTransVouchs["cDefine30"] = DBNull.Value;
                drTransVouchs["cDefine31"] = DBNull.Value;
                drTransVouchs["cDefine32"] = DBNull.Value;
                drTransVouchs["cDefine33"] = DBNull.Value;
                drTransVouchs["cDefine34"] = DBNull.Value;
                drTransVouchs["cDefine35"] = DBNull.Value;
                drTransVouchs["cDefine36"] = DBNull.Value;
                drTransVouchs["cDefine37"] = DBNull.Value;
                drTransVouchs["iMPoIds"] = DBNull.Value;
                drTransVouchs["cBVencode"] = DBNull.Value;
                drTransVouchs["cInVouchCode"] = DBNull.Value;
                drTransVouchs["dMadeDate"] = DBNull.Value;
                drTransVouchs["cMassUnit"] = DBNull.Value;
                drTransVouchs["iTRIds"] = DBNull.Value;
                drTransVouchs["AppTransIDS"] = DBNull.Value;
                drTransVouchs["iSSoType"] = 0;
                drTransVouchs["iSSodid"] = DBNull.Value;
                drTransVouchs["iDSoType"] = 0;
                drTransVouchs["iDSodid"] = DBNull.Value;
                drTransVouchs["bCosting"] = 1;
                drTransVouchs["cvmivencode"] = DBNull.Value;
                drTransVouchs["cinposcode"] = DBNull.Value;
                drTransVouchs["coutposcode"] = DBNull.Value;
                drTransVouchs["iinvsncount"] = DBNull.Value;
                drTransVouchs["comcode"] = DBNull.Value;
                drTransVouchs["cmocode"] = gridView1.GetRowCellDisplayText(i, gridCol生产订单号);
                drTransVouchs["imoseq"] = gridView1.GetRowCellDisplayText(i, gridCol生产订单行号);
                drTransVouchs["invcode"] = gridView1.GetRowCellValue(i, gridCol物料编码);
                drTransVouchs["iomids"] = DBNull.Value;
                drTransVouchs["imoids"] = gridView1.GetRowCellDisplayText(i, gridCol生产订单子件ID);
                //drTransVouchs["corufts"] = DBNull.Value;
                drTransVouchs["iExpiratDateCalcu"] = 0;
                drTransVouchs["cExpirationdate"] = DBNull.Value;
                drTransVouchs["dExpirationdate"] = DBNull.Value;
                drTransVouchs["cBatchProperty1"] = DBNull.Value;
                drTransVouchs["cBatchProperty2"] = DBNull.Value;
                drTransVouchs["cBatchProperty3"] = DBNull.Value;
                drTransVouchs["cBatchProperty4"] = DBNull.Value;
                drTransVouchs["cBatchProperty5"] = DBNull.Value;
                drTransVouchs["cBatchProperty6"] = DBNull.Value;
                drTransVouchs["cBatchProperty7"] = DBNull.Value;
                drTransVouchs["cBatchProperty8"] = DBNull.Value;
                drTransVouchs["cBatchProperty9"] = DBNull.Value;
                drTransVouchs["cBatchProperty10"] = DBNull.Value;
                drTransVouchs["cciqbookcode"] = DBNull.Value;

                dtTransVouchs.Rows.Add(drTransVouchs);

                aList.Add(clsGetSQL.GetInsertSQL(FrameBaseFunction.ClsBaseDataInfo.sUFDataBaseName, "TransVouchs", dtTransVouchs, dtTransVouchs.Rows.Count - 1));


                sSQL = "update @u8.mom_moallocate set TransQty = isnull(TransQty,0)  + " + FrameBaseFunction.ClsBaseDataInfo.ReturnDecimal(gridView1.GetRowCellValue(i, gridCol本次调拨)) + " where AllocateId = " + gridView1.GetRowCellDisplayText(i, gridCol生产订单子件ID);
                aList.Add(sSQL);

        
            }
            //更改调拨单据号
            sSQL = "select isnull(max(cNumber),0) as Maxnumber From @u8.VoucherHistory  with (NOLOCK) Where  CardNumber='0304'  and (cSeed = '" + dtm1.ToString("yyMM") + "' or cSeed = '" + dtm1.ToString("yyyyMM") + "')";
            DataTable dtCodeTemp = clsSQLCommond.ExecQuery(sSQL);
            if (dtCodeTemp.Rows[0]["Maxnumber"].ToString().Trim() == "0")
            {
                sSQL = "insert into @u8.VoucherHistory(cardnumber,ccontent,ccontentrule,cseed,cnumber,bempty)values('0304','日期','月','" + dtm1.ToString("yyMM") + "','1',0)";
                aList.Add(sSQL);
            }
            else
            {
                sSQL = "update @u8.VoucherHistory set cNumber = '" + iTrCode.ToString().Trim() + "' Where CardNumber='0304' and (cSeed='" + dtm1.ToString("yyyyMM") + "' or cSeed='" + dtm1.ToString("yyMM") + "')";
                aList.Add(sSQL);
            }

            sSQL = "update UFSystem..UA_Identity set iFatherID = " + iTrID + ",iChildID=" + iTrIDDetail + "  where cAcc_Id = '200' and cVouchType = 'tr'";
            aList.Add(sSQL);

            if (aList.Count > 0 && dtTransVouch != null && dtTransVouch.Rows.Count > 0 && dtTransVouchs != null && dtTransVouchs.Rows.Count > 0)
            {
                clsSQLCommond.ExecSqlTran(aList);
                MsgBox("生单成功", s调拨单号);
                GetGrid();
            }
        }
        /// <summary>
        /// 撤销
        /// </summary>
        private void btnUnDo()
        {
            throw new NotImplementedException();
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

        private void Frm生产材料货位调拨_Load(object sender, EventArgs e)
        {
            try
            {
                dtm单据日期1.DateTime = DateTime.Today;
                GetLookUp();
                GetGrid();
            }
            catch (Exception ee)
            {
                MessageBox.Show("加载窗体失败\n" + ee.Message);
            }
        }

        private void GetGrid()
        {
            int iFocRow = gridView1.FocusedRowHandle;
            string sSQL = "select distinct cast(null as int) as 序号,cast ('' as varchar(1)) as iChk, a.*,b.*,计划日期,c.iQuantity as iCurrQty,'801' as cOutDept,d.cDefWareHouse as cOutWhCode,cast (null as decimal(16,6)) as 本次调拨" +
                                    ",cast (0 as decimal(16,6)) as 累计下单,'213' as 出库类别,'113' as 入库类别,e.iTVQuantity as 调拨未审核待出库,e.iTVNum as 调拨未审核待出库件数,cast(c.iQuantity - isnull(e.iTVQuantity,0) as decimal(16,6)) as iCanQty,cast(null as varchar(50)) as 条形码  " +
                      "   from " +
                            "( " +
                            " select distinct 订单号 as WorkOrderNO,物料编码 as InvCode,计划日期 from DolleDatabase.dbo.仓库发料明细 a where IsOpen = 'Y' " +
                            ") a left join  " +
                            "	( " +
                            "	select distinct a.MoCode,b.SortSeq,b.Status,b.InvCode,b.Qty,b.MDeptCode as cInDept,b.CostItemCode " +
                            "		,c.InvCode as cInvCode,c.Qty  as iQty,c.Qty-isnull(c.TransQty,0) as UnTransQty,UPPER(c.WhCode) as cInWhCode,c.AllocateId as 子件用料ID " +
                            "       ,c.Qty as 子件应领数量,c.AuxQty as 子件应领辅计量,c.ChangeRate as 子件换算率,c.AuxUnitCode as 子件计量单位 " +
                            "	from @u8.mom_order a inner join @u8.mom_orderdetail b on a.MoId = b.MoId " +
                            "		inner join @u8.mom_moallocate c on c.MoDId = b.MoDId " +
                            "	where b.Status = 3 and c.Qty > ISNULL(c.TransQty,0) " +
                            "	)b on a.InvCode = b.InvCode and a.WorkOrderNO = b.MoCode " +
                            "   left join @u8.Inventory d on d.cInvCode = b.cInvCode " +
                            "	left join (select cInvCode,sum(iQuantity) as iQuantity,cWhCode from @u8.CurrentStock group by cInvCode,cWhCode) c on c.cInvCode = b.cInvCode and d.cDefWareHouse = c.cWhCode " +
                            "   left join (select a.cOWhCode,b.cInvCode ,sum(case itransflag when '反向' then -1 * b.iTVQuantity else b.iTVQuantity end) as iTVQuantity ,sum(case itransflag when '反向' then -1 * cast(b.iTVNum as decimal(16,6))  else cast(b.iTVNum as decimal(16,6)) end) as iTVNum from @u8.TransVouch a inner join @u8.TransVouchs b on a.id = b.id where isnull(cVerifyPerson,'') = '' group by cInvCode,a.cOWhCode) e on e.cInvCode = b.cInvCode and e.cOWhCode = d.cDefWareHouse " +
                            "where 1=1 ";

            if (radio有生产订单.Checked)
            {
                sSQL = sSQL + " and b.MoCode is not null ";
            }
            if (radio订单子件有现存量.Checked)
            {
                sSQL = sSQL + " and b.MoCode is not null and ISNULL(c.iQuantity ,0) > 0";
            }
            sSQL = sSQL + " order by a.计划日期,a.WorkOrderNO,a.InvCode,b.cInvCode";
            //sSQL = sSQL + " order by b.cInvCode";

            dtBingGrid = clsSQLCommond.ExecQuery(sSQL);
            gridControl1.DataSource = dtBingGrid;

            gridView1.FocusedRowHandle = iFocRow;

            chk全选.Checked = false;
        }

        private void gridView1_CellValueChanged(object sender, DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs e)
        {
            if (e.Column != gridCol条形码)
            {
                int iRow = e.RowHandle;
                string sBarCode = "5$200$" + gridView1.GetRowCellValue(iRow, gridCol子件用料ID).ToString().Trim() + "$" + FrameBaseFunction.ClsBaseDataInfo.ReturnDecimal( FrameBaseFunction.ClsBaseDataInfo.ReturnDouble(gridView1.GetRowCellValue(iRow, gridCol本次调拨))).ToString().Trim();
                gridView1.SetRowCellValue(iRow, gridCol条形码, sBarCode);
            }
            if (e.Column == gridCol本次调拨)
            {
                decimal d本次调拨 = FrameBaseFunction.ClsBaseDataInfo.ReturnDecimal(gridView1.GetRowCellValue(e.RowHandle, gridCol本次调拨));
                decimal d待调拨 = FrameBaseFunction.ClsBaseDataInfo.ReturnDecimal(gridView1.GetRowCellValue(e.RowHandle,gridCol子件待调拨数量));
                decimal d仓库可用量 = FrameBaseFunction.ClsBaseDataInfo.ReturnDecimal(gridView1.GetRowCellValue(e.RowHandle, gridCol仓库可用量));
                if (d本次调拨 > d待调拨 || d本次调拨 > d仓库可用量)
                {
                    MessageBox.Show("行" + (e.RowHandle+1).ToString() + "调拨数量超出需求数量或者超过仓库可用量");
                    if (d待调拨 > d仓库可用量)
                        d本次调拨 = d仓库可用量;
                    else
                        d本次调拨 = d待调拨;

                    gridView1.SetRowCellValue(e.RowHandle, gridCol本次调拨, d本次调拨);
                }
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

        private void GetLookUp()
        {
            sSQL = "select * from @u8.Inventory";
            DataTable dt = clsSQLCommond.ExecQuery(sSQL);
            ItemLookUpEdit物料规格.DataSource = dt;
            ItemLookUpEdit物料名称.DataSource = dt;

            sSQL = "select UPPER(cWhCode) as cWhCode,UPPER(cWhName) as cWhName from @u8.Warehouse ";
            dt = clsSQLCommond.ExecQuery(sSQL);
            ItemLookUpEdit仓库.DataSource = dt;

            sSQL = "select cDepCode,cDepName from @u8.Department order by cDepCode";
            dt = clsSQLCommond.ExecQuery(sSQL);
            ItemLookUpEdit部门.DataSource = dt;

            sSQL = "select cRdCode,cRdName from @u8.Rd_Style where bRdEnd = 1 order by cRdCode";
            dt = clsSQLCommond.ExecQuery(sSQL);
            ItemLookUpEdit收发类别.DataSource = dt;
        }

        private void gridView1_DoubleClick(object sender, EventArgs e)
        {
            try
            {
                int iRow = 0;
                if (gridView1.RowCount < 1)
                    iRow = 0;
                else
                    iRow = gridView1.FocusedRowHandle;

                if (gridView1.GetRowCellValue(iRow, gridColiChk).ToString().Trim() == "")
                    gridView1.SetRowCellValue(iRow, gridColiChk, "√");
                else
                    gridView1.SetRowCellValue(iRow, gridColiChk, "");
            }

            catch { }
        }

        private void chk全选_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                if (chk全选.Checked)
                {
                    string sInfo = "";
                    for (int i = 0; i < gridView1.RowCount; i++)
                    {
                        if (FrameBaseFunction.ClsBaseDataInfo.ReturnDecimal(gridView1.GetRowCellValue(i, gridCol本次调拨)) > 0)
                        {
                            gridView1.SetRowCellValue(i, gridColiChk, "√");
                        }
                        else
                        {
                            sInfo = sInfo + "行 " + (i + 1).ToString() + " 本次调拨数量为0未选中\n";
                        }
                    }
                    if (sInfo.Length >0)
                    {
                        MsgBox("提示", sInfo);
                    }
                }
                else
                {
                    for (int i = 0; i < gridView1.RowCount; i++)
                    {
                        gridView1.SetRowCellValue(i, gridColiChk, "");
                    }
                }
            }
            catch { }
        }

        /// <summary>
        /// 获得单据ID
        /// </summary>
        /// <param name="sType">单据类型</param>
        private void GetID(string sType, out long iID, out long iIDDetail)
        {
            string sSQL = "select iFatherID,iChildID from UFSystem..UA_Identity where cAcc_Id = '200' and cVouchType = '" + sType + "'";
            DataTable dt = clsSQLCommond.ExecQuery(sSQL);

            if (dt == null || dt.Rows.Count < 1)
            {
                iID = 0;
                iIDDetail = 0;
            }
            else
            {
                iID = Convert.ToInt64(dt.Rows[0]["iFatherID"]);
                iIDDetail = Convert.ToInt64(dt.Rows[0]["iChildID"]);
            }
        }

        /// <summary>
        /// 返回调拨单号
        /// </summary>
        /// <param name="s"></param>
        /// <returns></returns>
        private string sSetTransVouchCode(long s)
        {
            string sCode = s.ToString().Trim();
            for (int i = 0; i < 6; i++)
            {
                if (sCode.Length < 6)
                {
                    sCode = "0" + sCode;
                }
                else
                {
                    break;
                }
            }
            return "TR" + dtm单据日期1.DateTime.ToString("yyMM") + sCode;
        }
    }
}
