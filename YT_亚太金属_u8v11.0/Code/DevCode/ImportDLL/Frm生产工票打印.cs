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
using System.Data.SqlClient;


namespace ImportDLL
{
    public partial class Frm生产工票打印 : FrameBaseFunction.FrmFromModel
    {
        TH.DAL.生产工票打印 DAL = new TH.DAL.生产工票打印();

        int iPCDays = 0;
        int iDayTime = 0;

        public Frm生产工票打印()
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
            //gridView合并.OptionsCustomization.

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

                sState = sBtnName.ToLower();
            }
            catch (Exception ee)
            {
                throw new Exception(sBtnText + " 失败! \n\n原因:\n  " + ee.Message);
            }
        }

        DataTable dt评审 = new DataTable();

        private void btnAdd()
        {
        }

        #region 按钮模板

        ///// <summary>
        ///// 将表格中Lookup之类的保存ID的数据转换成Text用于打印
        ///// </summary>
        ///// <param name="dt"></param>
        ///// <returns></returns>
        private DataTable SetPrintData(DataTable dt)
        {
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

            return dt;
        }

        /// <summary>
        /// 打印
        /// </summary>
        private void btnPrint()
        {
            //try
            //{
            //    try
            //    {
            //        gridView1.FocusedRowHandle -= 1;
            //        gridView1.FocusedRowHandle += 1;
            //    }
            //    catch { }
            //    aList = new System.Collections.ArrayList();
            //    base.dsPrint.Tables.Clear();
            //    DataTable dtGrid = SetPrintData(((DataTable)gridControl1.DataSource).Copy());
            //    dtGrid.TableName = "dtGrid";

            //    for (int i = dtGrid.Rows.Count - 1; i >= 0; i--)
            //    {
            //        if (dtGrid.Rows[i]["iSave"].ToString().Trim() == "update")
            //        {
            //            throw new Exception("请先保存！");
            //        }
            //        if (!BaseFunction.BaseFunction.ReturnBool(dtGrid.Rows[i]["choose"]))
            //        {
            //            dtGrid.Rows.RemoveAt(i);
            //        }
                    
            //    }

            //    if (dtGrid == null || dtGrid.Rows.Count == 0)
            //    {
            //        throw new Exception("请选择需要打印的信息");
            //    }
            //    for (int i = 0; i < dtGrid.Rows.Count; i++)
            //    {
            //        string MoRoutingDId = dtGrid.Rows[i]["MoRoutingDId"].ToString().Trim();
            //        sSQL = "select isnull(sum(工票打印次数),0) as 工票打印次数 from 生产工票打印 where MoRoutingDId='" + MoRoutingDId + "' ";
            //        DataTable dtmo = clsSQLCommond.ExecQuery(sSQL);
            //        if (dtmo.Rows[0]["工票打印次数"].ToString().Trim() != "0")
            //        {
            //            throw new Exception(gridView1.GetRowCellValue(i, gridColMoRoutingDId) + "已打印");
            //        }
            //        sSQL = "select * from 生产工票打印 where MoRoutingDId='" + MoRoutingDId + "' ";
            //        DataTable dtmo2 = clsSQLCommond.ExecQuery(sSQL);
            //        if(dtmo2.Rows.Count==0)
            //        {
            //            sSQL = "insert into 生产工票打印(MoRoutingDId, 工票打印次数, 工票打印日期) values('" + MoRoutingDId + "',1,getdate())";
            //            aList.Add(sSQL);
            //        }
            //        else
            //        {
            //            sSQL = "update 生产工票打印 set 工票打印次数=工票打印次数+1, 工票打印日期=getdate() where MoRoutingDId='" + MoRoutingDId + "'";
            //            aList.Add(sSQL);
                        
            //        }
            //    }
            //    int iCou = clsSQLCommond.ExecSqlTran(aList);
            //    base.dsPrint.Tables.Add(dtGrid);
            //    DataTable dtHead = dtBingHead.Copy();
            //    dtHead.TableName = "dtHead";
            //    base.dsPrint.Tables.Add(dtHead);
            //    GetGrid();
            //}
            //catch (Exception ee)
            //{
            //    throw new Exception(ee.Message);
            //}
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
                //gridView合并.OptionsMenu.ShowAddNewSummaryItem = true;
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
                //gridView合并.OptionsMenu.ShowAddNewSummaryItem = false;
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

        }

        /// <summary>
        /// 上页
        /// </summary>
        private void btnPrev()
        {

        }
        /// <summary>
        /// 下页
        /// </summary>
        private void btnNext()
        {

        }

        /// <summary>
        /// 末页
        /// </summary>
        private void btnLast()
        {

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
            //for (int i = gridView评审计算.RowCount - 1; i >= 0 ; i--)
            //{
            //    if (gridView评审计算.IsRowSelected(i))
            //    {
            //        gridView评审计算.DeleteRow(i);
            //    }
            //}
        }
        /// <summary>
        /// 修改
        /// </summary>
        private void btnEdit()
        {
            try
            {
                Frm工序转移单批量_New frm = new Frm工序转移单批量_New();
                if (DialogResult.OK == frm.ShowDialog())
                {
                    frm.Enabled = true;
                    string iType = frm.iType;
                    string iValue = frm.iValue;
                    if (iType == "1")
                    {
                        for (int i = 0; i < gridView1.RowCount; i++)
                        {
                            gridView1.SetRowCellValue(i, gridCol机床, iValue);
                        }
                    }
                    else if (iType == "2")
                    {
                        for (int i = 0; i < gridView1.RowCount; i++)
                        {
                            gridView1.SetRowCellValue(i, gridCol人员, iValue);
                        }
                    }
                    else if (iType == "3")
                    {
                        for (int i = 0; i < gridView1.RowCount; i++)
                        {
                            gridView1.SetRowCellValue(i, gridCol调度安排时间, iValue);
                        }
                    }
                    
                
                }
            }
            catch (Exception ee)
            {
                MessageBox.Show("批量修改失败" + ee.Message);
            }
        }
        /// <summary>
        /// 删除
        /// </summary>
        private void btnDel()
        {

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

            aList = new System.Collections.ArrayList();
            string sList = "";
            string sErr = "";

            for (int j = 0; j < gridView1.RowCount; j++)
            {
                string 生产订单工艺路线明细ID = gridView1.GetRowCellValue(j, gridColMoRoutingDId).ToString().Trim();
                //string 选择 = gridView1.GetRowCellValue(j, gridColchoose).ToString().Trim();

                if (gridView1.GetRowCellValue(j, gridColiSave).ToString().Trim() == "update")
                {
                    sSQL = "select * from 生产工票打印 where MoRoutingDId='" + 生产订单工艺路线明细ID + "' ";
                    DataTable dtmo = clsSQLCommond.ExecQuery(sSQL);
                    if (dtmo.Rows.Count == 0)
                    {
                        sSQL = "insert into 生产工票打印(MoRoutingDId,机床,人员,调度安排时间,制单人,制单日期) "
                        +"values('" + 生产订单工艺路线明细ID + "','" + gridView1.GetRowCellValue(j, gridCol机床).ToString().Trim() + "',"
                        + "'" + gridView1.GetRowCellValue(j, gridCol人员).ToString().Trim() + "','" + gridView1.GetRowCellValue(j, gridCol调度安排时间).ToString().Trim() + "',"
                        +"'" + FrameBaseFunction.ClsBaseDataInfo.sUid + "',getdate())";
                        aList.Add(sSQL);
                    }
                    else
                    {
                        sSQL = @"update 生产工票打印 set 机床='" + gridView1.GetRowCellValue(j, gridCol机床).ToString().Trim() + "',人员='" + gridView1.GetRowCellValue(j, gridCol人员).ToString().Trim() + "'"
                    + ",调度安排时间='" + gridView1.GetRowCellValue(j, gridCol调度安排时间).ToString().Trim() + "' "
                        + ",修改人='" + FrameBaseFunction.ClsBaseDataInfo.sUid + "',修改日期=getdate() where MoRoutingDId='" + 生产订单工艺路线明细ID + "'";
                        aList.Add(sSQL);
                    }
                }
            }
            if (aList.Count > 0)
            {
                int iCou = clsSQLCommond.ExecSqlTran(aList);
                MsgBox("保存成功", sErr + "\n" + sList);
                GetGrid();
                sState = "sel";
            }
            else
            {
                throw new Exception(sErr);
            }
        }

        /// <summary>
        /// 撤销
        /// </summary>
        private void btnUnDo()
        {
            //if (txt销售订单ID.Text.Trim() != "")
            //{
            //    //GetGrid(Convert.ToInt64(txt销售订单ID.Text));
            //}
        }
        /// <summary>
        /// 审核
        /// </summary>
        private void btnAudit()
        {

        }
        /// <summary>
        /// 弃审
        /// </summary>
        private void btnUnAudit()
        {

        }
        /// <summary>
        /// 打开
        /// </summary>
        private void btnOpen()
        {
        }

        /// <summary>
        /// 关闭
        /// </summary>
        private void btnClose()
        {
            GetPrint(true);
        }

        /// <summary>
        /// 变更
        /// </summary>
        private void btnAlter()
        {
            GetPrint(false);
            
        }

        private void GetPrint(bool b)
        {
            try
            {
                try
                {
                    gridView1.FocusedRowHandle -= 1;
                    gridView1.FocusedRowHandle += 1;
                }
                catch { }
                aList = new System.Collections.ArrayList();
                base.dsPrint.Tables.Clear();
                DataTable dtGrid = SetPrintData(((DataTable)gridControl1.DataSource).Copy());
                dtGrid.TableName = "dtGrid";

                for (int i = dtGrid.Rows.Count - 1; i >= 0; i--)
                {
                    if (gridView1.GetRowCellValue(i, gridColiSave).ToString().Trim() == "update")
                    {
                        throw new Exception("请先保存！");
                    }
                    if (!BaseFunction.BaseFunction.ReturnBool(dtGrid.Rows[i]["choose"]))
                    {
                        dtGrid.Rows.RemoveAt(i);
                    }

                }

                if (dtGrid == null || dtGrid.Rows.Count == 0)
                {
                    throw new Exception("请选择需要打印的信息");
                }
                for (int i = 0; i < dtGrid.Rows.Count; i++)
                {
                    sSQL = "select * from 生产工票打印 where MoRoutingDId='" + gridView1.GetRowCellValue(i, gridColMoRoutingDId) + "' ";
                    DataTable dtmo = clsSQLCommond.ExecQuery(sSQL);
                    if (dtmo.Rows.Count == 0)
                    {
                        sSQL = "insert into 生产工票打印(MoRoutingDId, 工票打印次数, 工票打印日期) values('" + gridView1.GetRowCellValue(i, gridColMoRoutingDId) + "',1,getdate())";
                        aList.Add(sSQL);
                    }
                    else
                    {
                        sSQL = "update 生产工票打印 set 工票打印次数=isnull(工票打印次数,0)+1, 工票打印日期=getdate() where MoRoutingDId='" + gridView1.GetRowCellValue(i, gridColMoRoutingDId) + "'";
                        aList.Add(sSQL);
                        if (b == true)
                        {
                            throw new Exception(gridView1.GetRowCellValue(i, gridColMoRoutingDId) + "已打印");
                        }
                    }
                }
                int iCou = clsSQLCommond.ExecSqlTran(aList);
                base.dsPrint.Tables.Add(dtGrid);
                DataTable dtHead = dtBingHead.Copy();
                dtHead.TableName = "dtHead";
                base.dsPrint.Tables.Add(dtHead);


                RepBaseGrid Rep = new RepBaseGrid();
                if (File.Exists(sPrintLayOutUser))
                {
                    Rep.LoadLayout(sPrintLayOutUser);
                }
                else if (File.Exists(sPrintLayOutMod))
                {
                    Rep.LoadLayout(sPrintLayOutMod);
                }
                else
                {
                    MessageBox.Show("加载报表模板失败，请与管理员联系");
                    return;
                }
                Rep.dsPrint.Tables["dtHead"].Rows.Clear();
                Rep.dsPrint.Tables["dtGrid"].Clear();
                Rep.dsPrint.Tables["dtHead"].Columns.Clear();
                Rep.dsPrint.Tables["dtGrid"].Columns.Clear();
                //设置报表表头数据表列
                try
                {
                    for (int i = 0; i < this.dsPrint.Tables["dtHead"].Columns.Count; i++)
                    {
                        DataColumn dc = new DataColumn();
                        dc = this.dsPrint.Tables["dtHead"].Columns[i];
                        DataColumn dcRep = new DataColumn();
                        dcRep.ColumnName = dc.ColumnName;
                        Rep.dsPrint.Tables["dtHead"].Columns.Add(dcRep);
                    }
                }
                catch { }
                //设置报表表体数据表列
                for (int i = 0; i < this.dsPrint.Tables["dtGrid"].Columns.Count; i++)
                {
                    DataColumn dcGrid = new DataColumn();
                    dcGrid = this.dsPrint.Tables["dtGrid"].Columns[i];
                    DataColumn dcRepGrid = new DataColumn();
                    dcRepGrid.ColumnName = dcGrid.ColumnName;
                    Rep.dsPrint.Tables["dtGrid"].Columns.Add(dcRepGrid);
                }
                if (this.dsPrint.Tables["dtHead"] != null)
                {
                    for (int i = 0; i < this.dsPrint.Tables["dtHead"].Rows.Count; i++)
                    {
                        DataRow dr = Rep.dsPrint.Tables["dtHead"].NewRow();
                        for (int j = 0; j < Rep.dsPrint.Tables["dtHead"].Columns.Count; j++)
                        {
                            dr[j] = this.dsPrint.Tables["dtHead"].Rows[i][j];
                        }
                        Rep.dsPrint.Tables["dtHead"].Rows.Add(dr);
                    }
                }
                if (this.dsPrint.Tables["dtGrid"] != null)
                {
                    for (int i = 0; i < this.dsPrint.Tables["dtGrid"].Rows.Count; i++)
                    {
                        DataRow dr = Rep.dsPrint.Tables["dtGrid"].NewRow();
                        for (int j = 0; j < Rep.dsPrint.Tables["dtGrid"].Columns.Count; j++)
                        {
                            dr[j] = this.dsPrint.Tables["dtGrid"].Rows[i][j];
                        }
                        Rep.dsPrint.Tables["dtGrid"].Rows.Add(dr);
                    }
                }

                Rep.DataMember = "dtGrid";
                Rep.ShowPreview();
            }
            catch (Exception ee)
            {
                MessageBox.Show("打印失败:" + ee.Message, "提示", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
            }
        }
        #endregion

        private void Frm_Load(object sender, EventArgs e)
        {
            try
            {
                GetLookup();


                dtm开工日期1.DateTime = DateTime.Now;
                dtm开工日期2.DateTime = dtm开工日期1.DateTime.AddDays(7);
                iPCDays = DAL.Get工票打印天数();
                if (iPCDays == 0)
                    iPCDays = 1;

                //for (int i = 0; i < iPCDays; i++)
                //{
                //    AddCol(dtm.DateTime.AddDays(i + 1));
                //}
            }
            catch (Exception ee)
            {
                MsgBox("加载窗体失败", ee.Message);
            }
        }

        private void GetGrid()
        {
            try
            {
                if (dtm开工日期1.Text.Trim() == "")
                {
                    throw new Exception("请选择开工日期");
                }

                for (int i = gridView1.Columns.Count - 1; i >= 0; i--)
                {
                    if (gridView1.Columns[i].Name.Length > 11 && gridView1.Columns[i].Name.Substring(0, 11) == "gridColtemp")
                        gridView1.Columns.RemoveAt(i);
                }

                for (int i = gridView1.Bands.Count - 1; i >= 0; i--)
                {
                    if (gridView1.Bands[i].Name.Length > 12 && gridView1.Bands[i].Name.Substring(0, 12) == "gridBandtemp")
                    {
                        gridView1.Bands.RemoveAt(i);
                    }
                }

                //for (int i = 0; i < iPCDays; i++)
                //{
                //    AddCol(dtm.DateTime.AddDays(i + 1));
                //}

                //DateTime dPlan = BaseFunction.BaseFunction.ReturnDate(dtm.DateTime.ToString("yyyy-MM-dd"));
                DateTime dPlanWork = BaseFunction.BaseFunction.ReturnDate(dtm开工日期1.DateTime.ToString("yyyy-MM-dd"));
                DateTime dPlanWork2 = BaseFunction.BaseFunction.ReturnDate(dtm开工日期2.DateTime.ToString("yyyy-MM-dd"));
                DateTime dPlanWork3 = BaseFunction.BaseFunction.ReturnDate(dateEdit排产开工日期1.DateTime.ToString("yyyy-MM-dd"));
                DateTime dPlanWork4 = BaseFunction.BaseFunction.ReturnDate(dateEdit排产开工日期2.DateTime.ToString("yyyy-MM-dd"));
                string sReturn = "";
                DataTable dt = DAL.GetPCList(dPlanWork, dPlanWork2, dPlanWork3, dPlanWork4, iPCDays, out sReturn).Tables[0];

                DataColumn dc = new DataColumn();
                dc.ColumnName = "choose";
                dc.DataType = System.Type.GetType("System.Boolean");
                dc.DefaultValue = false;
                dt.Columns.Add(dc);

                gridControl1.DataSource = dt;       
            }
            catch (Exception ee)
            {
                throw new Exception("获得数据列表失败:" + ee.Message);
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

        private void AddCol(DateTime dDay)
        {
            DevExpress.XtraGrid.Views.BandedGrid.GridBand gridBand = new DevExpress.XtraGrid.Views.BandedGrid.GridBand();
            gridBand.Caption = dDay.ToString("MM月dd日");
            gridBand.MinWidth = 20;
            gridBand.Name = "gridBandtemp日期" + dDay.ToString("yyMMdd");
            gridBand.Width = 50;
            gridBand.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            gridView1.Bands.Add(gridBand);

            DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn gridColumn1 = new DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn();
            gridColumn1.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            gridColumn1.Caption = "数量";
            gridColumn1.Name = "gridColtemp数量" + dDay.ToString("yyMMdd");
            gridColumn1.FieldName = "数量" + dDay.ToString("yyMMdd");
            gridColumn1.Visible = true;
            gridColumn1.VisibleIndex = gridView1.Columns.Count;
            gridColumn1.Summary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] { new DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum) });

            gridBand.Columns.Add(gridColumn1);
        }

        private void gridView1_RowCellStyle(object sender, DevExpress.XtraGrid.Views.Grid.RowCellStyleEventArgs e)
        {
            try
            {
                int iRow = e.RowHandle;
                if (iRow < 0 || iRow >= gridView1.RowCount)
                    return;
                if (gridView1.GetRowCellDisplayText(e.RowHandle, gridCol排产说明).ToString().Trim() == "含未排产数据")
                    e.Appearance.BackColor = Color.LightYellow;
                if (gridView1.GetRowCellDisplayText(e.RowHandle, gridCol排产说明).ToString().Trim() == "完工延迟")
                    e.Appearance.BackColor = Color.Tomato;
            }
            catch { }
        }

        private void GetLookup()
        {
            LookUp.sfc_workcenter(ItemLookUpEdit工作中心);
            LookUp.EQ_EQData(ItemLookUpEdit机床);
            LookUp.EQ_EQData(ItemLookUpEdit机床2);
            ItemLookUpEdit机床2.Properties.DisplayMember = "cEQCode";
            LookUp.Person(ItemLookUpEdit人员);
            LookUp.Person(ItemLookUpEdit人员2);
            ItemLookUpEdit人员2.Properties.DisplayMember = "PersonCode";
        }

        private void gridControl1_Click(object sender, EventArgs e)
        {

        }

        private void gridView1_CellValueChanged(object sender, DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs e)
        {
            int iRow = 0;
            if (gridView1.FocusedRowHandle >= 0)
                iRow = gridView1.FocusedRowHandle;

            if ((e.Column != gridColchoose && e.Column != gridColiSave) && gridView1.GetRowCellDisplayText(e.RowHandle, gridColiSave).ToString().Trim() == "edit")
            {
                gridView1.SetRowCellValue(iRow, gridColiSave, "update");
            }
        }

    }
}
