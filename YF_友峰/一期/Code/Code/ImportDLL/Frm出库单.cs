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
    public partial class Frm出库单 : FrameBaseFunction.FrmBaseInfo
    {
        public Frm出库单()
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

            base.sTableList = "存货单价";
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
                    case "add":
                        btnAdd();
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
            Frm开料单_Add fAdd = new Frm开料单_Add();
            fAdd.ShowDialog();
            if (fAdd.DialogResult == DialogResult.OK)
            {
                string sAutoID = fAdd.sAutoID;
                //销售订单信息
                sSQL = "select a.cSOCode,b.iRowNo,b.autoid,b.cDefine28,b.cInvCode,d.cInvName,d.cInvStd,b.iQuantity,b.cItemCode,a.cDefine2,b.dPreDate,a.cCusCode,c.cCusName,b.dPreMoDate,b.cDefine36,b.iQuantity,b.iNum,d.cInvDefine13 " +
                        "from @u8.SO_SODetails b INNER JOIN @u8.SO_SOMain a ON a.ID = b.ID left join @u8.Customer c on a.cCusCode = c.cCusCode left join @u8.Inventory d on b.cInvCode=d.cInvCode " +
                        "where b.autoid = " + sAutoID;
                DataTable dtSO = clsSQLCommond.ExecQuery(sSQL);
                if (dtSO == null || dtSO.Rows.Count < 1)
                {
                    throw new Exception("获得销售订单失败");
                }

                SetTextNull();

                string s1="";;string s2="";string s3="";
                GetSize(dtSO.Rows[0]["cDefine28"].ToString().Trim(), out s1, out s2, out s3);
                //if (s1 == "")
                //{
                //    throw new Exception("材料厚度，宽度，长度必须设置");
                //}

                lookUpEdit公司名称.EditValue = dtSO.Rows[0]["cCusCode"].ToString().Trim();
                txt厚度2.Text = s1;
                txt宽度2.Text = s2;
                txt长度2.Text = s3;
                txt数量2.Text = dtSO.Rows[0]["iQuantity"].ToString().Trim();
                txt销售订单子表ID.Text = dtSO.Rows[0]["AutoID"].ToString().Trim();

                dtm交货日期.Text = FrameBaseFunction.ClsBaseDataInfo.sLogDate;
                dtm切割日期.Text = FrameBaseFunction.ClsBaseDataInfo.sLogDate;
                dtm算料日期.Text = FrameBaseFunction.ClsBaseDataInfo.sLogDate;
                txt密度.Text = dtSO.Rows[0]["cInvDefine13"].ToString().Trim();

                SetEnable(true);

                sSQL = "SELECT     a.开料单号, a.公司编码, a.交货日期, a.交货说明, a.密度, a.合金属性, a.切割员, a.切割日期, a.算料人, a.算料日期, b.iID, b.类型, b.存放区域, " +
                                              "b.存货编码1, b.序列号1, b.厚度1, b.宽度1, b.长度1, b.数量1, b.厚度2, b.宽度2, b.长度2, b.数量2, b.存货编码3, b.序列号3, b.厚度3, b.宽度3, b.长度3, b.数量3, " +
                                              "b.存放区域3 " +
                        "FROM         开料单表头 AS a INNER JOIN " +
                                              "开料单表体 AS b ON a.开料单号 = b.开料单号 " +
                        "WHERE        1=-1";
                DataTable dt = clsSQLCommond.ExecQuery(sSQL);
                gridControl1.DataSource = dt;
                gridView1.AddNewRow();

                sState = "add";
            }
        }

        private void SetText(string sCode)
        {
            string sSQL = "select * from 开料单表头 where 开料单号 = '" + sCode + "'";
            DataTable dt = clsSQLCommond.ExecQuery(sSQL);
            if (dt != null && dt.Rows.Count > 0)
            {
                lookUpEdit合金属性.EditValue = dt.Rows[0]["合金属性"].ToString().Trim();
                txt厚度2.Text = dt.Rows[0]["厚度2"].ToString().Trim();
                txt交货说明.Text = dt.Rows[0]["交货说明"].ToString().Trim();
                txt开料单号.Text = dt.Rows[0]["开料单号"].ToString().Trim();
                txt宽度2.Text = dt.Rows[0]["宽度2"].ToString().Trim();
                txt密度.Text = dt.Rows[0]["密度"].ToString().Trim();
                txt切割员.Text = dt.Rows[0]["切割员"].ToString().Trim();
                txt数量2.Text = dt.Rows[0]["数量2"].ToString().Trim();
                txt算料人.Text = dt.Rows[0]["算料人"].ToString().Trim();
                txt长度2.Text = dt.Rows[0]["长度2"].ToString().Trim();
                lookUpEdit公司名称.EditValue = dt.Rows[0]["公司编码"].ToString().Trim();
                dtm交货日期.Text = Convert.ToDateTime(dt.Rows[0]["交货日期"]).ToString("yyyy-MM-dd");
                timeEdit交货时间.Text = Convert.ToDateTime(dt.Rows[0]["交货日期"]).ToString("hh:mm:ss");
                dtm切割日期.Text = dt.Rows[0]["切割日期"].ToString().Trim();
                dtm算料日期.Text = dt.Rows[0]["算料日期"].ToString().Trim();
                txt销售订单子表ID.Text = dt.Rows[0]["销售订单ID"].ToString().Trim();
            }

            sSQL = "select * from 开料单表体 where 开料单号 = '" + sCode + "' order by iID";
            dt = clsSQLCommond.ExecQuery(sSQL);
            gridControl1.DataSource = dt;
        }

        private void SetTextNull()
        {
            lookUpEdit合金属性.EditValue = null;
            txt厚度2.Text = "";
            txt交货说明.Text = "";
            txt开料单号.Text = "";
            txt宽度2.Text = "";
            txt密度.Text = "";
            txt切割员.Text = "";
            txt数量2.Text = "";
            txt算料人.Text = "";
            txt长度2.Text = "";
            lookUpEdit公司名称.EditValue = null;
            dtm交货日期.Text = "";
            timeEdit交货时间.Text = "";
            dtm切割日期.Text = "";
            txt销售订单子表ID.Text = "";
            

            sSQL = "select * from 开料单表体 where 1 = -1";
            DataTable dt = clsSQLCommond.ExecQuery(sSQL);
            gridControl1.DataSource = dt;
        }


        #region 按钮模板

        /// <summary>
        /// 将表格中Lookup之类的保存ID的数据转换成Text用于打印
        /// </summary>
        /// <param name="dt"></param>
        /// <returns></returns>
        //private DataTable SetPrintData(DataTable dt)
        //{
        //    DataTable dtState = (DataTable)ItemLookUpEditState.DataSource;
        //    DataColumn dc = new DataColumn();
        //    dc.ColumnName = "StateText";
        //    dt.Columns.Add(dc);
           
        //    for (int i = 0; i < dt.Rows.Count; i++)
        //    {
        //        DataRow[] drState = dtState.Select("iID = '" + dt.Rows[i]["State"].ToString().Trim() + "'");
        //        if (drState.Length > 0)
        //        {
        //            dt.Rows[i]["StateText"] = drState[0]["State"];
        //        }

        //    }

        //    return dt;
        //}

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

            //base.dsPrint.Tables.Clear();
            //DataTable dtGrid = SetPrintData(((DataTable)gridControl1.DataSource).Copy());
            //dtGrid.TableName = "dtGrid";

            //base.dsPrint.Tables.Add(dtGrid);
            //DataTable dtHead = dtBingHead.Copy();
            //dtHead.TableName = "dtHead";
            //base.dsPrint.Tables.Add(dtHead);
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
            GetLookUp();
        }
        /// <summary>
        /// 查询
        /// </summary>
        private void btnSel()
        {
            string sSQL = "select 开料单号 from 开料单表头 order by 开料单号";
            dtSel = clsSQLCommond.ExecQuery(sSQL);

            btnLast();
        }
        /// <summary>
        /// 首页
        /// </summary>
        private void btnFirst()
        {
            if (dtSel != null && dtSel.Rows.Count > 0)
            {
                iPage = 0;
                GetGrid(dtSel.Rows[iPage]["开料单号"].ToString().Trim());
            }
        }
        /// <summary>
        /// 上页
        /// </summary>
        private void btnPrev()
        {
            if (dtSel != null && dtSel.Rows.Count > 0)
            {
                if (iPage > 0)
                    iPage -= 1;
                GetGrid(dtSel.Rows[iPage]["开料单号"].ToString().Trim());
            }
        }
        /// <summary>
        /// 下页
        /// </summary>
        private void btnNext()
        {
            if (dtSel != null && dtSel.Rows.Count > 0)
            {
                if (iPage < dtSel.Rows.Count - 1)
                    iPage += 1;
                GetGrid(dtSel.Rows[iPage]["开料单号"].ToString().Trim());
            }
        }
        /// <summary>
        /// 末页
        /// </summary>
        private void btnLast()
        {
            if (dtSel != null && dtSel.Rows.Count > 0)
            {
                iPage = dtSel.Rows.Count - 1;
                GetGrid(dtSel.Rows[iPage]["开料单号"].ToString().Trim());
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
            SetEnable(true);
            sState = "edit";
        }
        /// <summary>
        /// 删除
        /// </summary>
        private void btnDel()
        {
            string sErr = "";
            string sErrInfo = "";

            DialogResult d = MessageBox.Show("确定删除选中的 " + gridView1.SelectedRowsCount + " 行么？\n是：继续\n否：取消", "提示", MessageBoxButtons.YesNo, MessageBoxIcon.Asterisk);
            if (d != System.Windows.Forms.DialogResult.Yes)
            {
                return;
            }

            aList = new System.Collections.ArrayList();
            sSQL = "delete 开料单表体 where 开料单号 = '" + txt开料单号.Text.Trim() + "'";
            aList.Add(sSQL);
            sSQL = "delete 开料单表头 where 开料单号 = '" + txt开料单号.Text.Trim() + "'";
            aList.Add(sSQL);

            if (aList.Count > 0)
            {
                int iCou = clsSQLCommond.ExecSqlTran(aList);
                MessageBox.Show("保存成功！\n合计执行语句:" + iCou + "条");
                btnSel();
            }
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
            DataTable dt = new DataTable();

            if (gridView1.RowCount < 1)
            {
                throw new Exception("表体没有数据，不能保存");
            }

            if (sState == "add")
            {
                sSQL = "select case when isnull(max(开料单号)+1,1) = 1 then '" + DateTime.Parse(FrameBaseFunction.ClsBaseDataInfo.sLogDate).ToString("yyyyMM") + "0001' else  isnull(max(开料单号)+1,1) end as 开料单号 from 开料单表头 where 开料单号 like '" + DateTime.Parse(FrameBaseFunction.ClsBaseDataInfo.sLogDate).ToString("yyyyMM") + "%'";
                dt = clsSQLCommond.ExecQuery(sSQL);
                txt开料单号.Text = dt.Rows[0]["开料单号"].ToString().Trim();
            }

            sSQL = "select * from 开料单表头 where 1=-1";
            dt = clsSQLCommond.ExecQuery(sSQL);
            sSQL = "select * from 开料单表体 where 1=-1";
            DataTable dtDetail = clsSQLCommond.ExecQuery(sSQL);

            string sErr = "";

            aList = new System.Collections.ArrayList();

            DataRow dr = dt.NewRow();
            dr["开料单号"] = txt开料单号.Text.Trim();
            dr["公司编码"] =  lookUpEdit公司名称.EditValue.ToString().Trim();
            dr["交货日期"] =dtm交货日期.DateTime.ToString("yyyy-MM-dd") + " " + timeEdit交货时间.Time.ToString("hh:mm:ss");
            dr["交货说明"] =txt交货说明.Text.Trim();
            dr["密度"] =  txt密度.Text.Trim();
            dr["合金属性"] = lookUpEdit合金属性.EditValue.ToString().Trim();
            dr["切割员"] = txt切割员.Text;
            dr["切割日期"] =  dtm切割日期.Text;
            dr["算料人"] =  txt算料人.Text.Trim();
            dr["算料日期"] = dtm算料日期.Text;
            dr["厚度2"] = txt厚度2.Text.Trim();
            dr["宽度2"] = txt宽度2.Text.Trim();
            dr["长度2"] = txt长度2.Text.Trim();
            dr["数量2"] = txt数量2.Text.Trim();
            dr["销售订单ID"] = txt销售订单子表ID.Text.Trim();
            dt.Rows.Add(dr);
            if (sState == "add")
            {
                sSQL = clsGetSQL.GetInsertSQL(FrameBaseFunction.ClsBaseDataInfo.sUFDataBaseName, "开料单表头", dt, 0);
                aList.Add(sSQL);
            }
            if (sState == "edit")
            {

                sSQL = clsGetSQL.GetUpdateSQL(FrameBaseFunction.ClsBaseDataInfo.sUFDataBaseName, "开料单表头", dt, 0);
                aList.Add(sSQL);

                sSQL = "delete 开料单表体 where 开料单号 = '" + txt开料单号.Text.Trim() + "'";
                aList.Add(sSQL);
            }

            for (int i = 0; i < gridView1.RowCount; i++)
            {
                if (gridView1.GetRowCellDisplayText(i, GridCol存货编码3).ToString().Trim() == "")
                {
                    continue;
                }
                if (gridView1.GetRowCellDisplayText(i, GridCol序列号3).ToString().Trim() == "")
                {
                    continue;
                }

                DataRow drDetail = dtDetail.NewRow();
                drDetail["开料单号"] = txt开料单号.Text.Trim();
                drDetail["类型"] = gridView1.GetRowCellValue(i, GridCol类型).ToString().Trim();
                drDetail["存放区域"] = gridView1.GetRowCellValue(i, GridCol存放区域).ToString().Trim();
                drDetail["存货编码1"] = gridView1.GetRowCellValue(i, GridCol存货编码1).ToString().Trim();
                drDetail["序列号1"] = gridView1.GetRowCellValue(i, GridCol序列号1).ToString().Trim();

                if (gridView1.GetRowCellValue(i, GridCol厚度1).ToString().Trim() != "")
                    drDetail["厚度1"] = gridView1.GetRowCellValue(i, GridCol厚度1).ToString().Trim();
                if (gridView1.GetRowCellValue(i, GridCol宽度1).ToString().Trim() != "")
                    drDetail["宽度1"] = gridView1.GetRowCellValue(i, GridCol宽度1).ToString().Trim();
                if (gridView1.GetRowCellValue(i, GridCol长度1).ToString().Trim() != "")
                    drDetail["长度1"] = gridView1.GetRowCellValue(i, GridCol长度1).ToString().Trim();
                if (gridView1.GetRowCellValue(i, GridCol数量1).ToString().Trim() != "")
                    drDetail["数量1"] = gridView1.GetRowCellValue(i, GridCol数量1).ToString().Trim();
                if (gridView1.GetRowCellValue(i, GridCol厚度2).ToString().Trim() != "")
                    drDetail["厚度2"] = gridView1.GetRowCellValue(i, GridCol厚度2).ToString().Trim();
                if (gridView1.GetRowCellValue(i, GridCol宽度2).ToString().Trim() != "")
                    drDetail["宽度2"] = gridView1.GetRowCellValue(i, GridCol宽度2).ToString().Trim();
                if (gridView1.GetRowCellValue(i, GridCol长度2).ToString().Trim() != "")
                    drDetail["长度2"] = gridView1.GetRowCellValue(i, GridCol长度2).ToString().Trim();
                if (gridView1.GetRowCellValue(i, GridCol数量2).ToString().Trim() != "")
                    drDetail["数量2"] = gridView1.GetRowCellValue(i, GridCol数量2).ToString().Trim();

                drDetail["存货编码3"] = gridView1.GetRowCellValue(i, GridCol存货编码3).ToString().Trim();
                drDetail["序列号3"] = gridView1.GetRowCellValue(i, GridCol序列号3).ToString().Trim();
                drDetail["厚度3"] = gridView1.GetRowCellValue(i, GridCol厚度3).ToString().Trim();
                drDetail["宽度3"] = gridView1.GetRowCellValue(i, GridCol宽度3).ToString().Trim();
                drDetail["长度3"] = gridView1.GetRowCellValue(i, GridCol长度3).ToString().Trim();
                drDetail["数量3"] = gridView1.GetRowCellValue(i, GridCol数量3).ToString().Trim();
                drDetail["存放区域3"] = gridView1.GetRowCellValue(i, GridCol存放区域3).ToString().Trim();

                dtDetail.Rows.Add(drDetail);
            }

            if (sErr.Trim().Length > 0)
            {
                MsgBox("提示", sErr);
                return;
            }

            if (dt.Rows.Count > 0)
            {
                for (int i = 0; i < dtDetail.Rows.Count; i++)
                {
                    sSQL = clsGetSQL.GetInsertSQL("开料单表体", dtDetail, i);
                    aList.Add(sSQL);
                }

                if (aList.Count > 0)
                {
                    int iCou = clsSQLCommond.ExecSqlTran(aList);
                    MessageBox.Show("保存成功！\n合计执行语句:" + iCou + "条");
                    GetGrid(txt开料单号.Text.Trim());

                    //    gridView1.OptionsBehavior.Editable = false;
                }
            }
        }
        /// <summary>
        /// 撤销
        /// </summary>
        private void btnUnDo()
        {
            if (txt开料单号.Text.Trim() == "")
            {
                btnLast();
            }
            else
            {
                int iFocRow = gridView1.FocusedRowHandle;
                GetGrid(txt开料单号.Text.Trim());
                gridView1.FocusedRowHandle = iFocRow;
            }
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

        private void Frm开料单_Load(object sender, EventArgs e)
        {
            try
            {
                GetLookUp();

                SetEnable(false);

                btnSel();

                btnLast();
            }
            catch (Exception ee)
            {
                MessageBox.Show("加载窗体失败\n" + ee.Message);
            }
        }

        private void GetGrid(string sCode)
        {
            base.dsPrint = new DataSet();
            SetEnable(false);
            sSQL = "select * from 开料单表头 where 开料单号 = '" + sCode + "'";
            DataTable dt = clsSQLCommond.ExecQuery(sSQL);

            base.dsPrint.Tables.Add(dt.Copy());
            base.dsPrint.Tables[0].TableName = "dtHead";

            lookUpEdit合金属性.EditValue = dt.Rows[0]["合金属性"];
            txt厚度2.Text = dt.Rows[0]["厚度2"].ToString().Trim();
            txt交货说明.Text = dt.Rows[0]["交货说明"].ToString().Trim();
            txt开料单号.Text = dt.Rows[0]["开料单号"].ToString().Trim();
            txt宽度2.Text = dt.Rows[0]["宽度2"].ToString().Trim();
            txt密度.Text = dt.Rows[0]["密度"].ToString().Trim();
            txt切割员.Text = dt.Rows[0]["切割员"].ToString().Trim();
            txt数量2.Text = dt.Rows[0]["数量2"].ToString().Trim();
            txt算料人.Text = dt.Rows[0]["算料人"].ToString().Trim();
            txt长度2.Text = dt.Rows[0]["长度2"].ToString().Trim();
            lookUpEdit公司名称.EditValue = dt.Rows[0]["公司编码"].ToString().Trim();
            dtm交货日期.Text = Convert.ToDateTime(dt.Rows[0]["交货日期"]).ToString("yyyy-MM-dd");
            timeEdit交货时间.Text = Convert.ToDateTime(dt.Rows[0]["交货日期"]).ToString("hh:mm:ss");
            dtm切割日期.Text = dt.Rows[0]["切割日期"].ToString().Trim();
            dtm算料日期.Text = dt.Rows[0]["算料日期"].ToString().Trim();


            sSQL = "select * from 开料单表体 where 开料单号 = '" + sCode + "' order by iID";
            dt = clsSQLCommond.ExecQuery(sSQL);
            gridControl1.DataSource = dt;

            base.dsPrint.Tables.Add(dt.Copy());
            base.dsPrint.Tables[1].TableName = "dtGrid";

        }

        private void gridView1_CellValueChanged(object sender, DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs e)
        {
            if (e.Column == GridCol存货编码1)
            {
                if (txt厚度2.Text.Trim() != "" && txt宽度2.Text.Trim() != "" && txt长度2.Text.Trim() != "")
                {
                    gridView1.SetRowCellValue(e.RowHandle, GridCol厚度2, txt厚度2.Text);
                    gridView1.SetRowCellValue(e.RowHandle, GridCol宽度2, txt宽度2.Text);
                    gridView1.SetRowCellValue(e.RowHandle, GridCol长度2, txt长度2.Text);
                    gridView1.SetRowCellValue(e.RowHandle, GridCol数量2, txt数量2.Text);
                }

                if (gridView1.GetRowCellDisplayText(e.RowHandle, GridCol序列号1).ToString().Trim() != "")
                {
                    decimal dH = 0; decimal dK = 0; decimal dC = 0;
                    GetInvXLH(gridView1.GetRowCellDisplayText(e.RowHandle, GridCol存货编码1).ToString().Trim(), gridView1.GetRowCellDisplayText(e.RowHandle, GridCol序列号1).ToString().Trim(), out dH, out dK, out dC);
                    if (dH != 0)
                    {
                        gridView1.SetRowCellValue(e.RowHandle, GridCol厚度1, dH);
                    }
                    else
                    {
                        gridView1.SetRowCellValue(e.RowHandle, GridCol厚度1, DBNull.Value);
                    }
                    if (dK != 0)
                    {
                        gridView1.SetRowCellValue(e.RowHandle, GridCol宽度1, dK);
                    }
                    else
                    {
                        gridView1.SetRowCellValue(e.RowHandle, GridCol宽度1, DBNull.Value);
                    }
                    if (dC != 0)
                    {
                        gridView1.SetRowCellValue(e.RowHandle, GridCol长度1, dC);
                    }
                    else
                    {
                        gridView1.SetRowCellValue(e.RowHandle, GridCol长度1, DBNull.Value);
                    }
                }
            }
            if (e.Column == GridCol序列号1)
            {
                if (gridView1.GetRowCellDisplayText(e.RowHandle, GridCol存货编码1).ToString().Trim() != "")
                { 
                    decimal dH=0;decimal dK=0;decimal dC=0;
                    GetInvXLH(gridView1.GetRowCellDisplayText(e.RowHandle, GridCol存货编码1).ToString().Trim(), gridView1.GetRowCellDisplayText(e.RowHandle, GridCol序列号1).ToString().Trim(), out dH, out dK, out dC);
                    if (dH != 0)
                    {
                        gridView1.SetRowCellValue(e.RowHandle, GridCol厚度1, dH);
                    }
                    else
                    {
                        gridView1.SetRowCellValue(e.RowHandle, GridCol厚度1, DBNull.Value);
                    }
                    if (dK != 0)
                    {
                        gridView1.SetRowCellValue(e.RowHandle, GridCol宽度1, dK);
                    }
                    else
                    {
                        gridView1.SetRowCellValue(e.RowHandle, GridCol宽度1, DBNull.Value);
                    }
                    if (dC != 0)
                    {
                        gridView1.SetRowCellValue(e.RowHandle, GridCol长度1, dC);
                    }
                    else
                    {
                        gridView1.SetRowCellValue(e.RowHandle, GridCol长度1, DBNull.Value);
                    }
                }
            }
            if (e.Column == GridCol存货编码3)
            {
                decimal d=1;
                string sSQL = "select MAX(序列号1) + 1 as 序列号 from " +
                                "( " +
                                "select 序列号1 from 开料单表体 where 存货编码1 = '" + gridView1.GetRowCellValue(e.RowHandle,GridCol存货编码3).ToString().Trim() + "' " +
                                "union all " +
                                "select 序列号3 from 开料单表体 where 存货编码3 = '" + gridView1.GetRowCellValue(e.RowHandle, GridCol存货编码3).ToString().Trim() + "' " +
                                ")a ";
                DataTable dt = clsSQLCommond.ExecQuery(sSQL);
                if (dt != null && dt.Rows.Count > 0 && dt.Rows[0]["序列号"].ToString().Trim() != "")
                {
                    d = Convert.ToDecimal(dt.Rows[0]["序列号"]);
                }
                for (int i = 0; i < e.RowHandle; i++)
                {
                    if (gridView1.GetRowCellValue(i, GridCol存货编码3).ToString().Trim() == gridView1.GetRowCellValue(e.RowHandle, GridCol存货编码3).ToString().Trim())
                    {
                        d = Convert.ToDecimal(gridView1.GetRowCellValue(i, GridCol序列号3).ToString().Trim()) + 1;
                    }
                }
                gridView1.SetRowCellValue(e.RowHandle, GridCol序列号3, d);
            }
          
        }

        /// <summary>
        /// 根据存货编码，序列号获得厚度，宽度，长度
        /// </summary>
        /// <param name="sInvCode">存货编码</param>
        /// <param name="sXLH">序列号</param>
        /// <param name="dH">厚度</param>
        /// <param name="dK">宽度</param>
        /// <param name="dC">长度</param>
        private void GetInvXLH(string sInvCode, string sXLH,out decimal dH,out decimal dK,out decimal dC)
        {
            dH = 0; dK = 0; dC = 0;

            string sSQL = "select 存货编码1,序列号1,厚度1,宽度1, 长度1 from dbo.开料单表体 where 存货编码1 = '" + sInvCode + "' and 序列号1 = '" + sXLH + "' " +
                            "union all  " +
                            "select 存货编码3,序列号3,厚度3,宽度3, 长度3 from dbo.开料单表体 where 存货编码3 = '" + sInvCode + "' and 序列号3 = '" + sXLH + "'";
            DataTable dt = clsSQLCommond.ExecQuery(sSQL);
            if (dt != null && dt.Rows.Count > 0)
            {
                dH = Convert.ToDecimal(dt.Rows[0]["厚度1"]);
                dK = Convert.ToDecimal(dt.Rows[0]["宽度1"]);
                dC = Convert.ToDecimal(dt.Rows[0]["长度1"]);
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

        private void gridView1_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {

        }

        /// <summary>
        /// 获得参照下拉框数据
        /// </summary>
        private void GetLookUp()
        {
            string sSQL = "select cCusCode,cCusName,cCusAbbName from @u8.Customer order by cCusCode";
            DataTable dt = clsSQLCommond.ExecQuery(sSQL);
            lookUpEdit公司名称.Properties.DataSource = dt;

            sSQL = "select * from dbo._LookUpDate where iType = 5";
            dt = clsSQLCommond.ExecQuery(sSQL);
            ItemLookUpEdit存放区域.DataSource = dt;

            sSQL = "select * from dbo._LookUpDate where iType = 6";
            dt = clsSQLCommond.ExecQuery(sSQL);
            ItemLookUpEdit类型.DataSource = dt;

            sSQL = "select * from dbo._LookUpDate where iType = 7";
            dt = clsSQLCommond.ExecQuery(sSQL);
            lookUpEdit合金属性.Properties.DataSource = dt;


            sSQL = "select * from @u8.Inventory order by cInvCode";
            dt = clsSQLCommond.ExecQuery(sSQL);
            ItemLookUpEditcInvCode.DataSource = dt;
        }

        private void SetEnable(bool b)
        {
            txt开料单号.Enabled = false;
            lookUpEdit合金属性.Enabled = b;
            txt厚度2.Enabled = b;
            txt交货说明.Enabled = b;
            txt宽度2.Enabled = b;
            txt密度.Enabled = b;
            txt切割员.Enabled = b;
            txt数量2.Enabled = b;
            txt算料人.Enabled = b;
            txt长度2.Enabled = b;
            lookUpEdit公司名称.Enabled = false;
            timeEdit交货时间.Enabled = b;
            dtm切割日期.Enabled = b;
            dtm算料日期.Enabled = b;
            dtm交货日期.Enabled = b;

            gridView1.OptionsBehavior.Editable = b;
        }

        private void GetSize(string s, out string s1, out string s2, out string s3)
        {
            s1 = ""; s2 = ""; s3 = "";
            string[] sS = s.Split('*');
            if (sS.Length == 3)
            {
                s1 = sS[0];
                s2 = sS[1];
                s3 = sS[2];
            }
        }
    }
}
