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
    public partial class Frm工序流转卡打印 : FrameBaseFunction.FrmFromModel
    {
        TH.DAL.工序流转卡打印 DAL = new TH.DAL.工序流转卡打印();
        TH.DAL.GetBaseData DALBaseData = new TH.DAL.GetBaseData();

        public Frm工序流转卡打印()
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
        /// 关闭 打印
        /// </summary>
        private void btnClose()
        {
            GetPrint(true);
        }

        /// <summary>
        /// 变更  补打
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

                DataTable dtGrid = DAL.Get生产订单工序列表("-1");

                string sErr = "";
                
                

                for (int i = 0; i < gridView1.RowCount; i++)
                {
                    if (!ReturnObjectToBool(gridView1.GetRowCellValue(i, gridCol选择)))
                        continue;
                    if (gridView1.GetRowCellValue(i, gridCol零件号).ToString().Trim() == "")
                    {
                        sErr = sErr +"生产订单号：" +gridView1.GetRowCellValue(i, gridCol生产订单号).ToString()
                             + "生产订单行号：" + gridView1.GetRowCellValue(i, gridCol生产订单行号).ToString() + "\n";
                    }
                    sSQL = "select * from 流转卡打印 where modid='" + gridView1.GetRowCellValue(i, gridColmodid) + "' ";
                    DataTable dtmo = clsSQLCommond.ExecQuery(sSQL);
                    if (dtmo.Rows.Count == 0)
                    {
                        sSQL = "insert into 流转卡打印(modid, 流转卡打印次数, 流转卡打印日期) values('" + gridView1.GetRowCellValue(i, gridColmodid) + "',1,getdate())";
                        aList.Add(sSQL);
                    }
                    else
                    {
                        sSQL = "update 流转卡打印 set 流转卡打印次数=流转卡打印次数+1, 流转卡打印日期=getdate() where modid='" + gridView1.GetRowCellValue(i, gridColmodid) + "'";
                        aList.Add(sSQL);
                        if (b == true)
                        {
                            throw new Exception(gridView1.GetRowCellValue(i, gridView1.Columns["modid"]) + "已打印");
                        }
                    }
                    
                    long lMoDid = ReturnObjectToLong(gridView1.GetRowCellValue(i, gridColmodid));
                    DataTable dt = DAL.Get生产订单工序列表(lMoDid.ToString());

                    DataTable dt2 = DAL.Get生产订单列表("c.modid='" + lMoDid + "'");

                    //dtGrid = BaseFunction.BaseFunction.ReturnDataTableAdd(dtGrid, dt.Copy());
                    base.dsPrint.Tables.Clear();
                    dt.TableName = "dtGrid";
                    base.dsPrint.Tables.Add(dt.Copy());
                    dt2.TableName = "dtHead";
                    base.dsPrint.Tables.Add(dt2.Copy());

                    GetPrint();

                    

                }
                int iCou = clsSQLCommond.ExecSqlTran(aList);
                GetGrid();

            }
            catch (Exception ee)
            {
                MessageBox.Show("打印失败:" + ee.Message, "提示", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
            }
        }

        private void GetPrint()
        {
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

            Rep.Print();
            //Rep.ShowPreview();
        }
        #endregion

        private void Frm_Load(object sender, EventArgs e)
        {
            try
            {
                DataTable dtLook = DALBaseData.GetWorkOrderNO("").Tables[0];
                lookUpEdit生产订单号1.Properties.DataSource = dtLook;
                lookUpEdit生产订单号2.Properties.DataSource = dtLook;

                GetGrid();

                for (int i = 0; i < gridView1.Columns.Count; i++)
                {
                    if (gridView1.Columns[i] == gridView1.Columns["选择"])
                    {
                        gridView1.Columns[i].Width = 40;
                        gridView1.Columns[i].OptionsColumn.AllowEdit = true;
                    }
                    else
                    {
                        gridView1.Columns[i].OptionsColumn.AllowEdit = false;
                    }
                    //if (gridView1.Columns[i].FieldName.ToLower() == "moid")
                    //{
                    //    gridView1.Columns[i].Visible = false;
                    //}
                    //if (gridView1.Columns[i].FieldName.ToLower() == "modid")
                    //{
                    //    gridView1.Columns[i].Visible = false;
                    //}
                }
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

                string sWhere = "1=1";
                if (lookUpEdit生产订单号1.Text.Trim() != "")
                {
                    sWhere = sWhere.Replace("1=1", "1=1 and a.MoCode >= '" + lookUpEdit生产订单号1.Text.Trim() + "'");
                }
                if (lookUpEdit生产订单号2.Text.Trim() != "")
                {
                    sWhere = sWhere.Replace("1=1", "1=1 and a.MoCode <= '" + lookUpEdit生产订单号2.Text.Trim() + "'");
                }
                if (dtm领料日期1.Text.Trim() != "")
                {
                    sWhere = sWhere.Replace("1=1", "1=1 and 领料日期  >= '" + dtm领料日期1.Text.Trim() + "'");
                }
                if (dtm领料日期2.Text.Trim() != "")
                {
                    sWhere = sWhere.Replace("1=1", "1=1 and 领料日期  <= '" + dtm领料日期2.Text.Trim() + "'");
                }
                if (txt零件号.Text.Trim() != "")
                {
                    sWhere = sWhere.Replace("1=1", "1=1 and c.MoLotCode like '%" + txt零件号.Text.Trim() + "%'");
                }
                if (checkEdit1.Checked == true)
                {
                    sWhere = sWhere.Replace("1=1", "1=1 and 已领料数量>0 and isnull(c.MoLotCode,'')<>'' ");
                }
                if (checkEdit2.Checked == true)
                {
                    sWhere = sWhere.Replace("1=1", "1=1 and (流转卡打印次数 is null or 流转卡打印次数='' or 流转卡打印次数=0)");
                }
                DataTable dt = DAL.Get生产订单列表(sWhere);


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

        private void gridView1_CellValueChanging(object sender, DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs e)
        {
            try
            {
                int iRow = e.RowHandle;
                if (e.Column == gridView1.Columns["选择"] && !BaseFunction.BaseFunction.ReturnBool(gridView1.GetRowCellValue(iRow, gridView1.Columns["选择"])))
                {
                    for (int i = 0; i < gridView1.RowCount; i++)
                    {
                        if (i != iRow)
                        {
                            //gridView1.SetRowCellValue(i, "选择", false);
                        }
                    }
                }
            }
            catch { }
        }

        private void checkEdit3_CheckedChanged(object sender, EventArgs e)
        {
            bool b = checkEdit3.Checked;
            for (int i = 0; i < gridView1.RowCount; i++)
            {
                gridView1.SetRowCellValue(i, gridCol选择, b);
            }
            if (b == true)
            {
                checkEdit3.Text = "取消全选";
            }
            else
            {
                checkEdit3.Text = "全选";
            }
        }
    }
}
