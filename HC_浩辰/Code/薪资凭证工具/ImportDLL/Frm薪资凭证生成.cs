using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraLayout;
using System.IO;

namespace ImportDLL
{
    public partial class Frm薪资凭证生成 : FrameBaseFunction.FrmBaseInfo
    {
        public Frm薪资凭证生成()
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

        //string s表名称 = "会计科目工资项目对照表";

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
            try
            {
                gridView1.FocusedRowHandle -= 1;
                gridView1.FocusedRowHandle += 1;
            }
            catch { }

            string sDBNameCW = "UFDATA_" + lookUpEdit财务帐套.EditValue.ToString().Trim() + "_2018";
            string sDBNameXZ = "UFDATA_" + lookUpEdit薪资帐套.EditValue.ToString().Trim() + "_2018";

            aList = new System.Collections.ArrayList();
            sSQL = "select * from dbo.薪资凭证记录 where 1=-1";
            DataTable dt薪资凭证记录 = clsSQLCommond.ExecQuery(sSQL);
            
            for (int i = 0; i < gridView1.RowCount; i++)
            {
                DataRow dr凭证 = dt薪资凭证记录.NewRow();
                dr凭证["创建记录"] = DateTime.Now.ToString("yyyyMMddHHmmss");
                dr凭证["摘要"] = gridView1.GetRowCellValue(i, gridCol摘要).ToString().Trim();
                dr凭证["会计科目"] = gridView1.GetRowCellValue(i, gridCol会计科目).ToString().Trim();
                dr凭证["借"] = gridView1.GetRowCellValue(i, gridCol借).ToString().Trim();
                dr凭证["贷"] = gridView1.GetRowCellValue(i, gridCol贷).ToString().Trim();
                dr凭证["对方科目"] = gridView1.GetRowCellValue(i, gridCol对方科目).ToString().Trim();
                dr凭证["部门核算"] = gridView1.GetRowCellValue(i, gridCol部门核算).ToString().Trim();
                dr凭证["个人往来"] = gridView1.GetRowCellValue(i, gridCol个人往来).ToString().Trim();
                dr凭证["财务帐套"] = lookUpEdit财务帐套.EditValue.ToString().Trim();
                dr凭证["薪资帐套"] = lookUpEdit薪资帐套.EditValue.ToString().Trim();
                dr凭证["薪资类别"] = lookUpEdit薪资类别.EditValue.ToString();
                dr凭证["薪资月份"] = lookUpEdit薪资月份.EditValue.ToString();
                dt薪资凭证记录.Rows.Add(dr凭证);

            }

            for (int i = 0; i < dt薪资凭证记录.Rows.Count; i++)
            {
                sSQL = clsGetSQL.GetInsertSQL(FrameBaseFunction.ClsBaseDataInfo.sDataBaseName, "薪资凭证记录 ", dt薪资凭证记录, i);
                aList.Add(sSQL);
            }


            if (aList.Count > 0)
            {
                int iCou = clsSQLCommond.ExecSqlTran(aList);
                MessageBox.Show("保存成功！\n合计执行语句:" + iCou + "条");
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

            //return dt;
            return null;
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
            //string sErr = "";
            //OpenFileDialog oFile = new OpenFileDialog();
            //oFile.Filter = "Excel文件2003|*.xls|Excel文件2007|*.xlsx";
            //if (oFile.ShowDialog() == DialogResult.OK)
            //{
            //    string sFilePath = oFile.FileName;
            //    string sSQL = "select distinct 计量单位编码,计量单位名称,备注 from [" + s表名称 + "$]";

            //    DataTable dtExcel = clsExcel.ExcelToDT(sFilePath, sSQL, true);

            //    for (int i = 0; i < dtExcel.Rows.Count; i++)
            //    {
            //        string s编码 = dtExcel.Rows[i][";"].ToString().Trim();
            //        DataRow[] dr = dtBingGrid.Select("; = '" + s编码 + "'");
            //        if (dr.Length > 0)
            //        {
            //            dtExcel.Rows[i]["时间戳"] = dr[0]["时间戳"];
            //            sErr = sErr + s编码 + "\n";
            //        }
            //    }
            //    gridControl1.DataSource = dtExcel;

            //    if (sErr.Length > 0)
            //    {
            //        sErr = "以下计量单位已经存在，不能重复导入：\n" + sErr;
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
            GetGridView();
        }
        /// <summary>
        /// 查询
        /// </summary>
        private void btnSel()
        {
            GetGridView();
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
            string s摘要 = lookUpEdit财务帐套.EditValue.ToString().Trim() + lookUpEdit薪资类别.EditValue.ToString().Trim();
            string sSQL摘要 = "select * from dbo._LookUpDate where iType = 3 and Remark = '" + s摘要 + "' order by iID";
            DataTable dt摘要 = clsSQLCommond.ExecQuery(sSQL摘要);

            DataTable dt = new DataTable();
            DataColumn dc = new DataColumn();
            dc.ColumnName = "会计科目";
            dt.Columns.Add(dc);
            dc = new DataColumn();
            dc.ColumnName = "借";
            dt.Columns.Add(dc);
            dc = new DataColumn();
            dc.ColumnName = "贷";
            dt.Columns.Add(dc);
            dc = new DataColumn();
            dc.ColumnName = "摘要";
            dt.Columns.Add(dc);
            dc = new DataColumn();
            dc.ColumnName = "部门核算";
            dt.Columns.Add(dc);
            dc = new DataColumn();
            dc.ColumnName = "个人往来";
            dt.Columns.Add(dc);
            dc = new DataColumn();
            dc.ColumnName = "对方科目";
            dt.Columns.Add(dc);

            #region MyRegion

            string sSQL = "select distinct a.会计科目,a.借贷方向,b.bperson,b.bcus,b.bsup,b.bdept,b.bitem " +
                            "from dbo.会计科目工资项目对照表 a 	inner join aaa..code b on a.会计科目 = b.ccode and b.iYear = bbb " +
                            "where a.财务帐套 = '" + lookUpEdit财务帐套.EditValue.ToString().Trim() + "' and a.薪资帐套 = '" + lookUpEdit薪资帐套.EditValue.ToString().Trim() + "' and a.工资类别 = '" + lookUpEdit薪资类别.EditValue.ToString().Trim() + "' " +
                            "order by a.借贷方向 desc,a.会计科目,b.bperson,b.bcus,b.bsup,b.bdept,b.bitem ";
            string sDBName = "UFDATA_" + lookUpEdit财务帐套.EditValue.ToString().Trim() + "_2018";
            sSQL = sSQL.Replace("aaa", sDBName);
            sSQL = sSQL.Replace("bbb", Convert.ToDateTime(FrameBaseFunction.ClsBaseDataInfo.sLogDate).ToString("yyyy").ToString());
            DataTable dt会计科目信息 = clsSQLCommond.ExecQuery(sSQL);
            string s对方科目借 = "";
            string s对方科目贷 = "";
            for (int i = 0; i < dt会计科目信息.Rows.Count; i++)
            {
                if (Convert.ToInt32(dt会计科目信息.Rows[i]["借贷方向"]) == 0)
                {
                    if (s对方科目借 == "")
                        s对方科目借 = dt会计科目信息.Rows[i]["会计科目"].ToString().Trim();
                    else
                    {
                        string sTemp = s对方科目借 + "," + dt会计科目信息.Rows[i]["会计科目"].ToString().Trim();
                        if (sTemp.Length < 50)
                        {
                            s对方科目借 = sTemp;
                        }
                        else
                        {

                        }
                    }

                }
                if (Convert.ToInt32(dt会计科目信息.Rows[i]["借贷方向"]) == 1)
                {
                    if (s对方科目贷 == "")
                        s对方科目贷 = dt会计科目信息.Rows[i]["会计科目"].ToString().Trim();
                    else
                    {
                        string sTemp = s对方科目贷 + "," + dt会计科目信息.Rows[i]["会计科目"].ToString().Trim();
                        if (sTemp.Length < 50)
                        {
                            s对方科目贷 = sTemp;
                        }
                        else
                        { 
                        
                        }
                    }

                }
            }

            sSQL = "select distinct 财务帐套,薪资帐套,工资类别,会计科目,工资项目,计算方式,借贷方向 from dbo.会计科目工资项目对照表 a " +
                    "where a.财务帐套 = '" + lookUpEdit财务帐套.EditValue.ToString().Trim() + "' and a.薪资帐套 = '" + lookUpEdit薪资帐套.EditValue.ToString().Trim() + "' and a.工资类别 = '" + lookUpEdit薪资类别.EditValue.ToString().Trim() + "' " +
                      "   and 计算方式 <> 0 ";
            DataTable dt会计科目工资项目对照表 = clsSQLCommond.ExecQuery(sSQL);

            sSQL = "select c.薪资人员编号,a.cDepCode,b.会计科目 from aaa..person a inner join 人员对照表 c on c.财务人员编号 = a.cPersonCode " +
                    "   inner join 会计科目部门对照表 b on a.cDepCode = b.部门 and b.工资类别 = '" + lookUpEdit薪资类别.EditValue.ToString().Trim() + "' ";
            sDBName = "UFDATA_" + lookUpEdit财务帐套.EditValue.ToString().Trim() + "_2018";
            sSQL = sSQL.Replace("aaa", sDBName);
            DataTable dt人员科目 = clsSQLCommond.ExecQuery(sSQL);

            for (int j = 0; j < dt会计科目信息.Rows.Count; j++)
            {
                string s会计科目 = dt会计科目信息.Rows[j]["会计科目"].ToString().Trim();
                int i借贷方向 = Convert.ToInt32(dt会计科目信息.Rows[j]["借贷方向"]);
                //个人往来
                if (Convert.ToBoolean(dt会计科目信息.Rows[j]["bperson"]))
                {
                    for (int i = 0; i < gridView2.RowCount; i++)
                    {
                        decimal d = 0;

                        string s人员 = gridView2.GetRowCellValue(i, gridCol人员编码).ToString().Trim();
                        string s部门 = "";
                        for (int k = 0; k < dt会计科目工资项目对照表.Rows.Count; k++)
                        {
                            string s会计科目对照 = dt会计科目工资项目对照表.Rows[k]["会计科目"].ToString().Trim();
                            int i借贷方向对照 = Convert.ToInt32(dt会计科目工资项目对照表.Rows[k]["借贷方向"]);

                            if (s会计科目 != s会计科目对照 || i借贷方向 != i借贷方向对照)
                                continue;

                            for (int l = 0; l < dt人员科目.Rows.Count; l++)
                            {
                                string s人员2 = dt人员科目.Rows[l]["薪资人员编号"].ToString().Trim();
                                if (s人员 != s人员2)
                                    continue;

                                string s人员会计科目 = dt人员科目.Rows[l]["会计科目"].ToString().Trim();
                                if (s会计科目 != s人员会计科目)
                                    continue;

                                s部门 = dt人员科目.Rows[l]["cDepCode"].ToString().Trim();

                                if (Convert.ToInt32(dt会计科目工资项目对照表.Rows[k]["计算方式"]) == 1)
                                {
                                    decimal d2 = ReturnDecimal(gridView2.GetRowCellValue(i, gridView2.Columns[dt会计科目工资项目对照表.Rows[k]["工资项目"].ToString().Trim().Replace("FG", "F")]));
                                    d = d + d2;
                                }

                                if (Convert.ToInt32(dt会计科目工资项目对照表.Rows[k]["计算方式"]) == 2)
                                {
                                    d = d - ReturnDecimal(gridView2.GetRowCellValue(i, gridView2.Columns[dt会计科目工资项目对照表.Rows[k]["工资项目"].ToString().Trim().Replace("FG", "F")]));
                                }
                            }
                        }
                        if (d == 0)
                            continue;

                        DataRow dr = dt.NewRow();
                        dr["会计科目"] = s会计科目;
                        if (i借贷方向 == 0)
                        {
                            dr["贷"] = d;
                            dr["对方科目"] = s对方科目贷;
                        }
                        if (i借贷方向 == 1)
                        {
                            dr["借"] = d;
                            dr["对方科目"] = s对方科目借;
                        }

                        DataRow[] dr摘要 = dt摘要.Select("iID='" + s会计科目 + "'");
                        if (dr摘要.Length > 0)
                        {
                            dr["摘要"] = dr摘要[0]["iText"].ToString().Trim();
                        }
                        else
                        {
                            dr["摘要"] = "应付" + lookUpEdit薪资月份.EditValue.ToString().Trim() + "月工资";
                        }
                        dr["部门核算"] = s部门;
                        dr["个人往来"] = s人员;
                        dt.Rows.Add(dr);
                    }
                }
                //客户往来
                else if (Convert.ToBoolean(dt会计科目信息.Rows[j]["bcus"]))
                {

                }
                //供应商往来
                else if (Convert.ToBoolean(dt会计科目信息.Rows[j]["bsup"]))
                { }
                //部门核算
                else if (Convert.ToBoolean(dt会计科目信息.Rows[j]["bdept"]))
                {
                    for (int i = 0; i < gridView2.RowCount; i++)
                    {
                        decimal d = 0;

                        string s部门 = gridView2.GetRowCellValue(i, gridCol部门编码).ToString().Trim();
                        for (int k = 0; k < dt会计科目工资项目对照表.Rows.Count; k++)
                        {
                            string s会计科目对照 = dt会计科目工资项目对照表.Rows[k]["会计科目"].ToString().Trim();
                            int i借贷方向对照 = Convert.ToInt32(dt会计科目工资项目对照表.Rows[k]["借贷方向"]);

                            if (s会计科目 != s会计科目对照 || i借贷方向 != i借贷方向对照)
                                continue;

                            //for (int l = 0; l < dt人员科目.Rows.Count; l++)
                            //{
                          

                                ////s部门 = dt人员科目.Rows[l]["cDepCode"].ToString().Trim();

                                if (Convert.ToInt32(dt会计科目工资项目对照表.Rows[k]["计算方式"]) == 1)
                                {
                                    decimal d2 = ReturnDecimal(gridView2.GetRowCellValue(i, gridView2.Columns[dt会计科目工资项目对照表.Rows[k]["工资项目"].ToString().Trim().Replace("FG", "F")]));
                                    d = d + d2;
                                }

                                if (Convert.ToInt32(dt会计科目工资项目对照表.Rows[k]["计算方式"]) == 2)
                                {
                                    d = d - ReturnDecimal(gridView2.GetRowCellValue(i, gridView2.Columns[dt会计科目工资项目对照表.Rows[k]["工资项目"].ToString().Trim().Replace("FG", "F")]));
                                }
                            //}
                        }
                        if (d == 0)
                            continue;

                        DataRow dr = dt.NewRow();
                        dr["会计科目"] = s会计科目;
                        if (i借贷方向 == 0)
                        {
                            dr["贷"] = d;
                            dr["对方科目"] = s对方科目贷;
                        }
                        if (i借贷方向 == 1)
                        {
                            dr["借"] = d;
                            dr["对方科目"] = s对方科目借;
                        }

                        DataRow[] dr摘要 = dt摘要.Select("iID='" + s会计科目 + "'");
                        if (dr摘要.Length > 0)
                        {
                            dr["摘要"] = dr摘要[0]["iText"].ToString().Trim();
                        }
                        else
                        {
                            dr["摘要"] = "应付" + lookUpEdit薪资月份.EditValue.ToString().Trim() + "月工资";
                        }
                        dr["部门核算"] = s部门;
                        dt.Rows.Add(dr);
                    }
                }
                //项目核算
                else if (Convert.ToBoolean(dt会计科目信息.Rows[j]["bitem"]))
                { }
                //没有辅助核算项
                else
                {
                    decimal d = 0;
                    for (int i = 0; i < gridView2.RowCount; i++)
                    {
                        for (int k = 0; k < dt会计科目工资项目对照表.Rows.Count; k++)
                        {
                            string s会计科目对照 = dt会计科目工资项目对照表.Rows[k]["会计科目"].ToString().Trim();
                            int i借贷方向对照 = Convert.ToInt32(dt会计科目工资项目对照表.Rows[k]["借贷方向"]);
                            if (s会计科目 != s会计科目对照 || i借贷方向 != i借贷方向对照)
                                continue;

                            if (Convert.ToInt32(dt会计科目工资项目对照表.Rows[k]["计算方式"]) == 1)
                            {
                                decimal d2 = ReturnDecimal(gridView2.GetRowCellValue(i, gridView2.Columns[dt会计科目工资项目对照表.Rows[k]["工资项目"].ToString().Trim().Replace("FG", "F")]));
                                d = d + d2;
                            }

                            if (Convert.ToInt32(dt会计科目工资项目对照表.Rows[k]["计算方式"]) == 2)
                            {
                                d = d - ReturnDecimal(gridView2.GetRowCellValue(i, gridView2.Columns[dt会计科目工资项目对照表.Rows[k]["工资项目"].ToString().Trim().Replace("FG", "F")]));
                            }
                        }
                    }
                    if (d == 0)
                        continue;

                    DataRow dr = dt.NewRow();
                    dr["会计科目"] = s会计科目;
                    if (i借贷方向 == 0)
                    {
                        dr["贷"] = d;
                        dr["对方科目"] = s对方科目贷;
                    }
                    if (i借贷方向 == 1)
                    {
                        dr["借"] = d;
                        dr["对方科目"] = s对方科目借;
                    }
                    DataRow[] dr摘要 = dt摘要.Select("iID='" + s会计科目 + "'");
                    if (dr摘要.Length > 0)
                    {
                        dr["摘要"] = dr摘要[0]["iText"].ToString().Trim();
                    }
                    else
                    {
                        dr["摘要"] = "应付" + lookUpEdit薪资月份.EditValue.ToString().Trim() + "月工资";
                    }
                    //dr["部门核算"] = "";
                    //dr["个人往来"] = "";
                    dt.Rows.Add(dr);
                }
            }
            #endregion

            gridControl1.DataSource = dt;
        }
        /// <summary>
        /// 删除
        /// </summary>
        private void btnDel()
        {
           
        }

        /// <summary>
        /// 判断是否已经使用
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

            int iYearPZ = Convert.ToDateTime(FrameBaseFunction.ClsBaseDataInfo.sLogDate).Year;
            int iMonthPZ = Convert.ToDateTime(FrameBaseFunction.ClsBaseDataInfo.sLogDate).Month;

            decimal d1 = 0;
            decimal d2 = 0;
            for (int i = 0; i < gridView1.RowCount; i++)
            {
                d1 = d1 + ReturnDecimal(gridView1.GetRowCellValue(i, gridCol借));
                d2 = d2 + ReturnDecimal(gridView1.GetRowCellValue(i, gridCol贷));
            }
            if (d1 != d2)
            {
                throw new Exception("借贷不平衡，不能生成凭证");
            }

            string sDBNameCW = "UFDATA_" + lookUpEdit财务帐套.EditValue.ToString().Trim() + "_2018";
            string sDBNameXZ = "UFDATA_" + lookUpEdit薪资帐套.EditValue.ToString().Trim() + "_2018";

            sSQL = "select bflag from aaa..GL_mend where iyear = '" + iYearPZ.ToString().Trim() + "' and iperiod = " + iMonthPZ.ToString().Trim();
            sSQL = sSQL.Replace("aaa", sDBNameCW);
            bool b结账 = Convert.ToBoolean(clsSQLCommond.ExecGetScalar(sSQL));
            if (b结账)
            {
                throw new Exception("当月已结账，不能再次生成");
            }

            sSQL = "select count(1) from aaa..GL_accvouch where iyear = '" + iYearPZ.ToString().Trim() + "' and iperiod = " + iMonthPZ.ToString().Trim() + " and isnull(cDefine14,'') != ''";
            sSQL = sSQL.Replace("aaa", sDBNameCW);
            decimal dCou = ReturnDecimal(clsSQLCommond.ExecGetScalar(sSQL));
            if (dCou != 0)
            {
                DialogResult d = MessageBox.Show("已经有凭证生成，是否继续（y/n）？", "提示", MessageBoxButtons.YesNo, MessageBoxIcon.Asterisk);
                if (d != DialogResult.Yes)
                {
                    throw new Exception("取消生成");
                }
            }

            aList = new System.Collections.ArrayList();

            sSQL = "select * from aaa..GL_accvouch where 1=-1";
            sSQL = sSQL.Replace("aaa", sDBNameCW);
            DataTable dtGL_accvouch = clsSQLCommond.ExecQuery(sSQL);

            //sSQL = "select * from dbo.薪资凭证记录 where 1=-1";
            //DataTable dt薪资凭证记录 = clsSQLCommond.ExecQuery(sSQL);


            sSQL = "select isnull(max(ino_id),0) + 1 from aaa..GL_accvouch where iyear = " + iYearPZ.ToString().Trim() + " and iperiod = " + iMonthPZ.ToString().Trim();
            sSQL = sSQL.Replace("aaa", sDBNameCW);
            int iNo_ID = Convert.ToInt32(clsSQLCommond.ExecGetScalar(sSQL));

            for (int i = 0; i < gridView1.RowCount; i++)
            {
                DataRow dr = dtGL_accvouch.NewRow();
                //dr["i_id"] = DBNull.Value;
                dr["iperiod"] = iMonthPZ;
                dr["csign"] = "记";
                dr["isignseq"] = 1;
                dr["ino_id"] = iNo_ID;
                dr["inid"] = i + 1;
                dr["dbill_date"] = FrameBaseFunction.ClsBaseDataInfo.sLogDate;
                dr["idoc"] = -1;
                dr["cbill"] = FrameBaseFunction.ClsBaseDataInfo.sUserName;
                dr["ccheck"] = DBNull.Value;
                dr["cbook"] = DBNull.Value;
                dr["ibook"] = 0;
                dr["ccashier"] = DBNull.Value;
                dr["iflag"] = DBNull.Value;
                dr["ctext1"] = DBNull.Value;
                dr["ctext2"] = DBNull.Value;
                dr["cdigest"] = gridView1.GetRowCellValue(i, gridCol摘要).ToString().Trim();
                dr["ccode"] = gridView1.GetRowCellValue(i, gridCol会计科目).ToString().Trim();
                dr["cexch_name"] = DBNull.Value;
                dr["md"] = ReturnDecimal(gridView1.GetRowCellValue(i, gridCol借));
                dr["mc"] = ReturnDecimal(gridView1.GetRowCellValue(i, gridCol贷));
                dr["md_f"] = 0;
                dr["mc_f"] = 0;
                dr["nfrat"] = 0;
                dr["nd_s"] = 0;
                dr["nc_s"] = 0;
                dr["csettle"] = DBNull.Value;
                dr["cn_id"] = DBNull.Value;
                dr["iyear"] = iYearPZ.ToString().Trim();
                dr["iYPeriod"] = iYearPZ.ToString().Trim() + iMonthPZ.ToString().Trim().PadLeft(2, '0');
                dr["dt_date"] = FrameBaseFunction.ClsBaseDataInfo.sLogDate;
                if (gridView1.GetRowCellValue(i, gridCol部门核算).ToString().Trim() != "")
                {
                    dr["cdept_id"] = gridView1.GetRowCellValue(i, gridCol部门核算).ToString().Trim();
                }
                if (gridView1.GetRowCellValue(i, gridCol个人往来).ToString().Trim() != "")
                {
                    sSQL = "select 财务人员编号 from dbo.人员对照表 " +
                            "where 薪资帐套 = '" + lookUpEdit薪资帐套.EditValue.ToString().Trim() + "' and 财务帐套 = '" + lookUpEdit财务帐套.EditValue.ToString().Trim() + "' " +
                                " and 薪资人员编号 = '" + gridView1.GetRowCellValue(i, gridCol个人往来).ToString().Trim() + "'";
                    sSQL = sSQL.Replace("aaa", sDBNameCW);
                    dr["cperson_id"] = clsSQLCommond.ExecGetScalar(sSQL).ToString().Trim();
                }
                dr["ccus_id"] = DBNull.Value;
                dr["csup_id"] = DBNull.Value;
                dr["citem_id"] = DBNull.Value;
                dr["citem_class"] = DBNull.Value;
                dr["cname"] = DBNull.Value;

                dr["ccode_equal"] = gridView1.GetRowCellValue(i, gridCol对方科目).ToString().Trim();

                dr["iflagbank"] = DBNull.Value;
                dr["iflagPerson"] = DBNull.Value;
                dr["bdelete"] = DBNull.Value;
                dr["coutaccset"] = DBNull.Value;
                dr["ioutyear"] = DBNull.Value;
                dr["coutsysname"] = DBNull.Value;
                dr["coutsysver"] = DBNull.Value;
                dr["doutbilldate"] = FrameBaseFunction.ClsBaseDataInfo.sLogDate;
                dr["ioutperiod"] = DBNull.Value;
                dr["coutsign"] = DBNull.Value;
                //dr["coutno_id"] = DBNull.Value;
                dr["doutdate"] = DBNull.Value;
                dr["coutbillsign"] = DBNull.Value;
                dr["coutid"] = DBNull.Value;
                dr["bvouchedit"] = true;
                dr["bvouchAddordele"] = false;
                dr["bvouchmoneyhold"] = false;
                dr["bvalueedit"] = true;
                dr["bcodeedit"] = true;
                dr["ccodecontrol"] = DBNull.Value;
                dr["bPCSedit"] = true;
                dr["bDeptedit"] = true;
                dr["bItemedit"] = true;
                dr["bCusSupInput"] = false;
                dr["cDefine1"] = DBNull.Value;
                dr["cDefine2"] = DBNull.Value;
                dr["cDefine3"] = DBNull.Value;
                dr["cDefine4"] = DBNull.Value;
                dr["cDefine5"] = DBNull.Value;
                dr["cDefine6"] = DBNull.Value;
                dr["cDefine7"] = DBNull.Value;
                dr["cDefine8"] = DBNull.Value;
                dr["cDefine9"] = DBNull.Value;
                dr["cDefine10"] = DBNull.Value;
                dr["cDefine11"] = DBNull.Value;
                dr["cDefine12"] = DBNull.Value;
                dr["cDefine13"] = DBNull.Value;
                dr["cDefine14"] = "TH" + DateTime.Now.ToString("yyMMddhhmmss");
                dr["cDefine15"] = DBNull.Value;
                dr["cDefine16"] = DBNull.Value;
                dr["dReceive"] = DBNull.Value;
                dr["cWLDZFlag"] = DBNull.Value;
                dr["dWLDZTime"] = DBNull.Value;
                dr["bFlagOut"] = false;
                dr["iBG_OverFlag"] = DBNull.Value;
                dr["cBG_Auditor"] = DBNull.Value;
                dr["dBG_AuditTime"] = DBNull.Value;
                dr["cBG_AuditOpinion"] = DBNull.Value;
                dr["bWH_BgFlag"] = DBNull.Value;
                dr["RowGuid"] = Guid.NewGuid().ToString();

                dtGL_accvouch.Rows.Add(dr);
            }
            for (int i = 0; i < dtGL_accvouch.Rows.Count; i++)
            {
                string sDBName = "UFDATA_" + lookUpEdit财务帐套.EditValue.ToString().Trim() + "_2018";
                sSQL = clsGetSQL.GetInsertSQL(sDBName, "GL_accvouch ", dtGL_accvouch, i);
                aList.Add(sSQL);
            }

            if (aList.Count > 0)
            {
                int iCou = clsSQLCommond.ExecSqlTran(aList);
                MessageBox.Show("保存成功！\n合计执行语句:" + iCou + "条");
                GetGridView();
            }
            else
            {
                MessageBox.Show("没有需要执行的语句");
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

        private void Frm薪资凭证生成_Load(object sender, EventArgs e)
        {
            try
            {
                txtYear.Text = "2018";

                txtYear.Text = Convert.ToDateTime(FrameBaseFunction.ClsBaseDataInfo.sLogDate).ToString("yyyy").ToString();
                txtYear.Enabled = true;
                txtYear.Properties.ReadOnly = false;

                Get借贷方向();
                Get工资项属性();
                GetAccInfo();
                GetLookUp();

                gridControl2.Visible = false;

                string sUid = FrameBaseFunction.ClsBaseDataInfo.sUid;
                sSQL = @"
select count(1)
from dbo._UserInfo a inner join dbo._UserRoleInfo b on a.vchrUid = b.vchrUserID
	inner join dbo._RoleInfo c on c.vchrRoleID = b.vchrRoleID
where a.vchrUid = '111111' and (c.vchrRoleID = '凭证生成_薪资查看' or c.vchrRoleText = '凭证生成_薪资查看') 
";
                sSQL = sSQL.Replace("111111", sUid);
                int iCou = ReturnInt(clsSQLCommond.ExecGetScalar(sSQL));
                if (iCou > 0)
                {
                    gridControl2.Visible = true;
                }

            }
            catch (Exception ee)
            {
                MessageBox.Show(ee.Message);
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

        private object ReturnValue(object a)
        {
            if (a.ToString().Trim() == "")
                return DBNull.Value;
            else
                return a;
        }


        /// <summary>
        /// 获得帐套数据,
        /// </summary>
        /// <param name="sSQL"></param>
        private void GetAccInfo()
        {
            try
            {
                string sSQL = @"
SELECT DISTINCT A.cAcc_Id as iID,'[' + A.cAcc_Id + ']' + A.cAcc_Name as iText  
FROM UFSystem.dbo.UA_Account A,UFSystem.dbo.UA_period P  
WHERE A.cAcc_Id=P.cAcc_Id AND (P.bIsDelete=0 OR P.bIsDelete IS NULL)  
ORDER BY iID,iText
";

                DataTable dt = clsSQLCommond.ExecQuery(sSQL);
                lookUpEdit财务帐套.Properties.DataSource = dt;
                lookUpEdit薪资帐套.Properties.DataSource = dt;

                //lookUpEdit财务帐套.EditValue = "003";
                //lookUpEdit薪资帐套.EditValue = "004";
            }
            catch
            {
                throw new Exception("获得帐套信息失败！");
            }
        }

        private void lookUpEdit薪资帐套_EditValueChanged(object sender, EventArgs e)
        {
            try
            {
                if (lookUpEdit薪资帐套.EditValue == null || lookUpEdit薪资帐套.EditValue.ToString().Trim() == "")
                {
                    throw new Exception("请选择薪资帐套");
                }
                string sSQL = "select cGZGradeNum,cGZGradeNum + '_' +cGzGradename as cGzGradename from aaa..WA_account where cGZGradeNum <> '000' AND iLastYear = bbb order by cGZGradeNum";
                string sDBName = "UFDATA_" + lookUpEdit薪资帐套.EditValue.ToString().Trim() + "_2018";
                sSQL = sSQL.Replace("aaa", sDBName);
                sSQL = sSQL.Replace("bbb", Convert.ToDateTime(FrameBaseFunction.ClsBaseDataInfo.sLogDate).ToString("yyyy").ToString());
                DataTable dt = clsSQLCommond.ExecQuery(sSQL);
                lookUpEdit薪资类别.Properties.DataSource = dt;
                //lookUpEdit薪资类别.EditValue = "001";
            }
            catch (Exception ee)
            {
                MsgBox("提示", ee.Message);
            }
        }

        private void lookUpEdit薪资类别_EditValueChanged(object sender, EventArgs e)
        {
            try
            {
                string sSQL = "select distinct iMonth from aaa..WA_GZData where iYear = '" + Convert.ToDateTime(FrameBaseFunction.ClsBaseDataInfo.sLogDate).ToString("yyyy") + "' order by iMonth";
                string sDBName = "UFDATA_" + lookUpEdit薪资帐套.EditValue.ToString().Trim() + "_2018";
                sSQL = sSQL.Replace("aaa", sDBName);
                DataTable dtLook = clsSQLCommond.ExecQuery(sSQL);
                lookUpEdit薪资月份.Properties.DataSource = dtLook;
                if (dtLook != null && dtLook.Rows.Count > 0)
                {
                    lookUpEdit薪资月份.EditValue = dtLook.Rows[dtLook.Rows.Count - 1]["iMonth"];
                }

                //GetGridView();
            }
            catch (Exception ee)
            {
                MsgBox("提示", ee.Message);
            }
        }

        private void lookUpEdit财务帐套_EditValueChanged(object sender, EventArgs e)
        {
            try
            {
                string sSQL = "select ccode as iID,ccode_name as iText from aaa..code where isnull(bend,0) = 1 order by ccode";
                string sDBName = "UFDATA_" + lookUpEdit财务帐套.EditValue.ToString().Trim() + "_2018";
                sSQL = sSQL.Replace("aaa", sDBName);
                DataTable dt = clsSQLCommond.ExecQuery(sSQL);
                ItemLookUpEdit会计科目.DataSource = dt;
                ItemLookUpEdit会计科目名称.DataSource = dt;

                GetGridView();
            }
            catch (Exception ee)
            {
                MsgBox("提示", ee.Message);
            }
        }

        private void Get借贷方向()
        {
            string sSQL = "select iID,iText from dbo._LookUpDate where iType = 1";
            DataTable dt = clsSQLCommond.ExecQuery(sSQL);
            ItemLookUpEdit借贷方向.DataSource = dt;
        }

        private void GetGridView()
        {
            if (lookUpEdit财务帐套.EditValue != null && lookUpEdit财务帐套.EditValue.ToString().Trim() != "" && lookUpEdit薪资类别.EditValue != null && lookUpEdit薪资类别.EditValue.ToString().Trim() != "" && lookUpEdit薪资月份.EditValue.ToString().Trim() != "")
            {
                Get薪资();
            }
        }

        private void Get工资项属性()
        {
            string sSQL = "select iID,iText from dbo._LookUpDate where iType = 2";
            DataTable dt = clsSQLCommond.ExecQuery(sSQL);
            ItemLookUpEdit工资项属性 .DataSource = dt;
        }


        private DataTable Get工资项()
        {
            string sSQL = "select * from aaa..WA_GZtblset";
            string sDBName = "UFDATA_" + lookUpEdit薪资帐套.EditValue.ToString().Trim() + "_2018";
            sSQL = sSQL.Replace("aaa", sDBName);
            DataTable dt = clsSQLCommond.ExecQuery(sSQL);

            return dt;
        }

        private void Get薪资()
        {
            for (int i = gridView2.Columns.Count - 1; i >= 0; i--)
            {
                if (gridView2.Columns[i].FieldName == "cPsn_Num")
                    continue;
                if (gridView2.Columns[i].FieldName == "cPsn_Name")
                    continue;
                if (gridView2.Columns[i].FieldName == "cDept_Num")
                    continue;
                if (gridView2.Columns[i].FieldName == "cDepName")
                    continue;

                gridView2.Columns.RemoveAt(i);
            }

            DataTable dt工资项目 = Get工资项();
            for (int i = 0; i < dt工资项目.Rows.Count; i++)
            {
                SetGridViewColumn("F_" + dt工资项目.Rows[i]["iGZItem_id"].ToString().Trim(), dt工资项目.Rows[i]["cSetGZItemName"].ToString().Trim());
            }

            string sSQL = @"
SELECT a.*,c.cDepName 
FROM ((aaa..WA_GZData a INNER JOIN aaa..WA_psn b ON a.cGZGradeNum=b.cGZGradeNum AND a.cPsn_Num=b.cPsn_Num AND a.cPsn_Name=b.cPsn_Name and a.iYear = b.iYear) INNER JOIN aaa..Department c ON 
    c.cDepCode=a.cDept_Num) INNER JOIN aaa..WA_grade d ON d.iPsnGrd_id=a.iPsnGrd_id  
WHERE a.iYear = 444444 and a.cGZGradeNum='111111' AND a.bTFBZ = 0 AND a.bDCBZ = 0 and iMonth = 222222
";

            sSQL = sSQL.Replace("111111", lookUpEdit薪资类别.EditValue.ToString().Trim());
            sSQL = sSQL.Replace("222222", Convert.ToInt32(lookUpEdit薪资月份.EditValue).ToString());
            sSQL = sSQL.Replace("444444", txtYear.Text.Trim());
            string sDBName = "UFDATA_" + lookUpEdit薪资帐套.EditValue.ToString().Trim() + "_2018";
            sSQL = sSQL.Replace("aaa", sDBName);
            DataTable dt = clsSQLCommond.ExecQuery(sSQL);
            gridControl2.DataSource = dt;

            btnEdit();
        }

        private void lookUpEdit薪资月份_EditValueChanged(object sender, EventArgs e)
        {
            try
            {
                GetGridView();
            }
            catch (Exception ee)
            {
                MsgBox("提示", ee.Message);
            }
        }

        private void gridView2_CustomDrawRowIndicator(object sender, DevExpress.XtraGrid.Views.Grid.RowIndicatorCustomDrawEventArgs e)
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

        private void SetGridViewColumn(string ColFieldName, string ColCaption)
        {
            try
            {
                DevExpress.XtraGrid.Columns.GridColumn Col1 = new DevExpress.XtraGrid.Columns.GridColumn();

                Col1.FieldName = ColFieldName;
                Col1.Caption = ColCaption;
                Col1.Name ="gridcol" + ColFieldName;
                Col1.OptionsColumn.AllowMerge = DevExpress.Utils.DefaultBoolean.False;
                Col1.Width = 100;
                Col1.Visible = true;
                Col1.VisibleIndex = gridView1.Columns.Count;
                Col1.OptionsColumn.AllowEdit = true;

                Col1.SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Sum;
                gridView2.Columns.Add(Col1);
            }
            catch
            {

            }
        }

        private void GetLookUp()
        {
            if (lookUpEdit财务帐套.EditValue != null && lookUpEdit财务帐套.EditValue.ToString().Trim() == "")
            {
                string sSQL = "select cDepCode as iID,cDepName as iText from aaa..Department  order by cDepCode";
                string sDBName = "UFDATA_" + lookUpEdit财务帐套.EditValue.ToString().Trim() + "_2018";
                sSQL = sSQL.Replace("aaa", sDBName);
                ItemLookUpEdit部门.DataSource = clsSQLCommond.ExecQuery(sSQL);


                sSQL = "select cPersonCode as iID,cPersonName as iText from aaa..Person   order by cPersonCode";
                sDBName = "UFDATA_" + lookUpEdit财务帐套.EditValue.ToString().Trim() + "_2018";
                sSQL = sSQL.Replace("aaa", sDBName);
                ItemLookUpEdit部门.DataSource = clsSQLCommond.ExecQuery(sSQL);
            }
        }
    }
}
