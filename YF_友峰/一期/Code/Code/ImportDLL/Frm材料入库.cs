using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraLayout;
using System.IO;
using System.Xml;

namespace ImportDLL
{
    public partial class Frm材料入库 : FrameBaseFunction.FrmBaseInfo
    {
        string 材料入库单号1 = "";
        string 材料入库单号2 = "";
        string 入库日期1 = "";
        string 入库日期2 = "";
        decimal d密度 = (decimal)3.14;

        public Frm材料入库()
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
            dtm入库日期.Text = FrameBaseFunction.ClsBaseDataInfo.sLogDate;
            dtm制单日期.Text = DateTime.Now.ToString();
            txt制单.Text = FrameBaseFunction.ClsBaseDataInfo.sUserName;
            txt审核.Text = "";
            dtm审核日期.Text = "";
            txt记账.Text = "";
            dtm记账日期.Text = "";

            SetEnable(true);

            sSQL = "SELECT *,null as 材料重量 FROM @u8.材料入库单表体 WHERE 1=-1";
            DataTable dt = clsSQLCommond.ExecQuery(sSQL);
            gridControl1.DataSource = dt;
            gridView1.AddNewRow();

            sSQL = "SELECT *,null as 材料重量 FROM @u8.材料入库单表体2 WHERE 1=-1";
            dt = clsSQLCommond.ExecQuery(sSQL);
            gridControl2.DataSource = dt;

            sState = "add";
        }

        private void SetText(string sCode)
        {
            string sSQL = "select * from @u8.材料入库单表头 where 入库单号 = '" + sCode + "'";
            DataTable dt = clsSQLCommond.ExecQuery(sSQL);
            if (dt != null && dt.Rows.Count > 0)
            {
             
            }

            sSQL = "select * from @u8.材料入库单表体 where 入库单号 = '" + sCode + "' order by iID";
            dt = clsSQLCommond.ExecQuery(sSQL);
            gridControl1.DataSource = dt;
        }

        private void SetTextNull()
        {
            txt入库单号.Text = "";
            txt制单.Text = "";
            dtm制单日期.Text = "";
            dtm入库日期.Text = "";

            sSQL = "select * from @u8.材料入库单表体 where 1 = -1";
            DataTable dt = clsSQLCommond.ExecQuery(sSQL);
            gridControl1.DataSource = dt;
        }


        #region 按钮模板

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
            try
            {
                gridView1.FocusedRowHandle -= 1;
                gridView1.FocusedRowHandle += 1;
            }
            catch { }
            try
            {
                Replist rep = new Replist();
                if (base.dsPrint.Tables[0].Rows.Count > 0 && base.dsPrint.Tables[1].Rows.Count > 0)
                {

                    rep.dsPrint.Tables.Clear();
                    DataTable dthead = base.dsPrint.Tables[0].Copy();

                    dthead.TableName = "dtHead";
                    DataTable dtGrid = base.dsPrint.Tables[1].Copy();
                    dtGrid.TableName = "dtGrid";
                    rep.dsPrint.Tables.Add(dthead);
                    rep.dsPrint.Tables.Add(dtGrid);
                    rep.ShowPreview();
                }
                else
                {
                    MessageBox.Show("材料入库单打印失败");
                }
                
            }
            catch { }
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
            Frm材料入库单_Add frm = new Frm材料入库单_Add();
            frm.Get(材料入库单号1, 材料入库单号2, 入库日期1, 入库日期2);
            if (DialogResult.OK == frm.ShowDialog())
            {
                
                frm.Enabled = true;
                材料入库单号1 = frm.材料入库单号1;
                材料入库单号2 = frm.材料入库单号2;
                入库日期1 = frm.入库日期1;
                入库日期2 = frm.入库日期2;
            }
            GetSel();
            材料入库单号1 = "";
            材料入库单号2 = "";
            入库日期1 = "";
            入库日期2 = "";
        }

        private void GetSel()
        {
            string sSQL = "select 入库单号 from @u8.材料入库单表头 where 1=1";
            if (材料入库单号1 != null && 材料入库单号1 != "")
            {
                sSQL = sSQL + " and 入库单号>='" + 材料入库单号1 + "'";
            }
            if (材料入库单号2 != null && 材料入库单号2 != "")
            {
                sSQL = sSQL + " and 入库单号<='" + 材料入库单号2 + "'";
            }
            if (入库日期1 != null && 入库日期1 != "")
            {
                sSQL = sSQL + " and convert(varchar(10),入库日期,120)>=convert(varchar(10),'" + 入库日期1 + "',120)";
            }
            if (入库日期2 != null && 入库日期2 != "")
            {
                sSQL = sSQL + " and convert(varchar(10),入库日期,120)<=convert(varchar(10),'" + 入库日期2 + "',120)";
            }
            sSQL = sSQL + "  order by 入库单号";
            dtSel = clsSQLCommond.ExecQuery(sSQL);
            if (dtSel.Rows.Count > 0)
            {
                GetGrid(dtSel.Rows[0]["入库单号"].ToString().Trim());

                gridView1.OptionsBehavior.Editable = false;
                GridView2.OptionsBehavior.Editable = false;
            }
            else
            {
                txt入库单号.Text = "";
                txt制单.Text = "";
                gridControl1.DataSource = null;
                gridControl2.DataSource = null;

                btnLast();
            }
            sSQL = "select 入库单号 from @u8.材料入库单表头 where 1=1";
            dtSel = clsSQLCommond.ExecQuery(sSQL);

            lookUpEdit材料类型_EditValueChanged(null, null);
        }
        /// <summary>
        /// 首页
        /// </summary>
        private void btnFirst()
        {
            if (dtSel != null && dtSel.Rows.Count > 0)
            {
                iPage = 0;
                GetGrid(dtSel.Rows[iPage]["入库单号"].ToString().Trim());
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
                GetGrid(dtSel.Rows[iPage]["入库单号"].ToString().Trim());
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
                {
                    iPage += 1;
                }
                GetGrid(dtSel.Rows[iPage]["入库单号"].ToString().Trim());
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
                GetGrid(dtSel.Rows[iPage]["入库单号"].ToString().Trim());
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
            if (txt入库单号.Text.Trim() == "")
            {
                throw new Exception("请选择需要修改的单据");
            }
            if (txt审核.Text.Trim() != "")
            {
                throw new Exception("已经审核不能修改");
            }

            SetEnable(true);
            sState = "edit";
        }
        /// <summary>
        /// 删除
        /// </summary>
        private void btnDel()
        {
            if (txt入库单号.Text.Trim() == "")
            {
                throw new Exception("请选择需要删除的单据");
            }
            if (txt审核.Text.Trim() != "")
            {
                throw new Exception("已经审核不能删除");
            }

            string sErr = "";
            string sErrInfo = "";

            if (txt入库单号.Text.Trim() == "")
            {
                throw new Exception("单据号不能为空");
            }

            DialogResult d = MessageBox.Show("确定删除单据的 " + txt入库单号.Text + " 么？\n是：继续\n否：取消", "提示", MessageBoxButtons.YesNo, MessageBoxIcon.Asterisk);
            if (d != System.Windows.Forms.DialogResult.Yes)
            {
                return;
            }

            for (int i = 0; i < GridView2.RowCount; i++)
            {
                sSQL = "select * from @u8.开料单表体 where 存货编码1='" + GridView2.GetRowCellValue(i, GridCol_存货编码).ToString().Trim() + "' and 序列号1='" + GridView2.GetRowCellValue(i, GridCol_序列号).ToString().Trim() + "'";
                DataTable dts = clsSQLCommond.ExecQuery(sSQL);
                if (dts.Rows.Count > 0)
                {
                    throw new Exception("已经使用不能删除");
                }
            }

            aList = new System.Collections.ArrayList();
            sSQL = "delete @u8.材料入库单表体2 where 入库单号 = '" + txt入库单号.Text.Trim() + "'";
            aList.Add(sSQL);
            sSQL = "delete @u8.材料入库单表体 where 入库单号 = '" + txt入库单号.Text.Trim() + "'";
            aList.Add(sSQL);
            sSQL = "delete @u8.材料入库单表头 where 入库单号 = '" + txt入库单号.Text.Trim() + "'";
            aList.Add(sSQL);

            if (aList.Count > 0)
            {
                string djh = "";
                if (dtSel != null && dtSel.Rows.Count > 0)
                {
                    if (iPage < dtSel.Rows.Count - 1)
                    {
                        iPage += 1;
                    }
                    else if(iPage == dtSel.Rows.Count-1)
                    {
                        iPage = dtSel.Rows.Count - 2;
                    }
                    djh = dtSel.Rows[iPage]["入库单号"].ToString().Trim();
                }
                int iCou = clsSQLCommond.ExecSqlTran(aList);
                MessageBox.Show("删除单据" + txt入库单号.Text + "成功！\n合计执行语句:" + iCou + "条");
                GetSel();
                GetGrid(djh);
               
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

            if (GridView2.RowCount < 1)
            {
                throw new Exception("请先点击生成按钮");
            }

            DataTable dt = new DataTable();

            if (gridView1.RowCount < 1)
            {
                throw new Exception("表体没有数据，不能保存");
            }
            aList = new System.Collections.ArrayList();

            if (sState == "add")
            {
                sSQL = "select case when isnull(max(入库单号)+1,1) = 1 then '" + DateTime.Parse(FrameBaseFunction.ClsBaseDataInfo.sLogDate).ToString("yyyyMM") + "0001' else  isnull(max(入库单号)+1,1) end as 入库单号 from @u8.材料入库单表头 where 入库单号 like '" + DateTime.Parse(FrameBaseFunction.ClsBaseDataInfo.sLogDate).ToString("yyyyMM") + "%'";
                dt = clsSQLCommond.ExecQuery(sSQL);
                txt入库单号.Text = dt.Rows[0]["入库单号"].ToString().Trim();
            }

            sSQL = "select * from @u8.材料入库单表头 where 1=-1";
            dt = clsSQLCommond.ExecQuery(sSQL);

            DataTable dtDetail = (DataTable)gridControl1.DataSource;
            DataTable dtDetail2 = (DataTable)gridControl2.DataSource;

            for (int i = 0; i < dtDetail.Rows.Count; i++)
            {
                dtDetail.Rows[i]["入库单号"] = txt入库单号.Text.Trim();
            }
            for (int i = 0; i < dtDetail2.Rows.Count; i++)
            {
                dtDetail2.Rows[i]["入库单号"] = txt入库单号.Text.Trim();
            }

            string sErr = "";

            DataRow dr = dt.NewRow();
            dr["入库单号"] = txt入库单号.Text.Trim();
            dr["入库日期"] = dtm入库日期.EditValue.ToString().Trim();

            dr["日期"] = dtm制单日期.EditValue.ToString().Trim();
            dr["制单"] = txt制单.Text.Trim();
            dr["材料类型"] = lookUpEdit材料类型.Text.Trim();

            dt.Rows.Add(dr);
            if (sState == "add")
            {
                
                sSQL = clsGetSQL.GetInsertSQL(FrameBaseFunction.ClsBaseDataInfo.sUFDataBaseName, "材料入库单表头", dt, 0);
                aList.Add(sSQL);
            }
            if (sState == "edit")
            {

                sSQL = clsGetSQL.GetUpdateSQL(FrameBaseFunction.ClsBaseDataInfo.sUFDataBaseName, "材料入库单表头", dt, 0);
                aList.Add(sSQL);

                sSQL = "delete @u8.材料入库单表体 where 入库单号 = '" + txt入库单号.Text.Trim() + "'";
                aList.Add(sSQL);

                sSQL = "delete @u8.材料入库单表体2 where 入库单号 = '" + txt入库单号.Text.Trim() + "'";
                aList.Add(sSQL);
            }


            for (int i = 0; i < dtDetail.Rows.Count; i++)
            {
                string sql = "select * from @u8.Inventory where cInvCode='" + gridView1.GetRowCellValue(i, GridCol存货编码) + "'";
                DataTable dtinv = clsSQLCommond.ExecQuery(sql);
                bool b = false;
                if (dtinv.Rows[0]["cInvDefine4"].ToString().Trim() == "" && lookUpEdit材料类型.Text.Trim() == "板")
                {
                    b = true;
                }
                if (dtinv.Rows[0]["cInvDefine4"].ToString().Trim() == lookUpEdit材料类型.Text.Trim())
                {
                    b = true;
                }
                if (b == false)
                {
                    throw new Exception((i + 1) + "行" + gridView1.GetRowCellValue(i, GridCol存货编码) + "材料类型与单据材料类型不符");
                }
                sSQL = clsGetSQL.GetInsertSQL(FrameBaseFunction.ClsBaseDataInfo.sUFDataBaseName, "材料入库单表体", dtDetail, i);
                aList.Add(sSQL);
            }

            for (int i = 0; i < dtDetail2.Rows.Count; i++)
            {
                sSQL = clsGetSQL.GetInsertSQL(FrameBaseFunction.ClsBaseDataInfo.sUFDataBaseName, "材料入库单表体2", dtDetail2, i);
                aList.Add(sSQL);
            }

            if (sErr.Trim().Length > 0)
            {
                throw new Exception(sErr);
            }

            if (aList.Count > 0)
            {
                int iCou = clsSQLCommond.ExecSqlTran(aList);
                MessageBox.Show("保存成功！\n合计执行语句:" + iCou + "条");
                GetSel();
            }
        }
        /// <summary>
        /// 撤销
        /// </summary>
        private void btnUnDo()
        {
            if (txt入库单号.Text.Trim() == "")
            {
                btnLast();
            }
            else
            {
                int iFocRow = gridView1.FocusedRowHandle;
                GetGrid(txt入库单号.Text.Trim());
                gridView1.FocusedRowHandle = iFocRow;
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

            if (txt入库单号.Text.Trim() == "")
            {
                throw new Exception("没有单据号，不能审核");
            }
            if (txt审核.Text.Trim() != "")
            {
                throw new Exception("已经审核");
            }
            sSQL = "select * from @u8.材料入库单表头 where 1=-1";
            DataTable dt = clsSQLCommond.ExecQuery(sSQL);

            DataRow dr = dt.NewRow();
            dr["入库单号"] = txt入库单号.Text.Trim();
            dr["入库日期"] = dtm入库日期.Text.Trim();
            dr["制单"] = txt制单.Text.Trim();
            dr["日期"] = dtm制单日期.Text.Trim();
            dr["审核"] = FrameBaseFunction.ClsBaseDataInfo.sUserName;
            dr["审核日期"] = FrameBaseFunction.ClsBaseDataInfo.sLogDate;
            dr["材料类型"] = lookUpEdit材料类型.EditValue.ToString();
            dt.Rows.Add(dr);

            aList = new System.Collections.ArrayList();
            sSQL = clsGetSQL.GetUpdateSQL(FrameBaseFunction.ClsBaseDataInfo.sUFDataBaseName, "材料入库单表头", dt, 0);
            aList.Add(sSQL);

            if (aList.Count > 0)
            {
                int iCou = clsSQLCommond.ExecSqlTran(aList);
                MessageBox.Show("审核成功！\n合计执行语句:" + iCou + "条");
                GetGrid(txt入库单号.Text.Trim());
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

            if (txt入库单号.Text.Trim() == "")
            {
                throw new Exception("没有单据号，不能弃审");
            }
            if (txt审核.Text.Trim() == "")
            {
                throw new Exception("尚未审核，不能弃审");
            }
            if (txt记账.Text.Trim() != "")
            {
                throw new Exception("已经记账，不能弃审");
            }
            for (int i = 0; i < GridView2.RowCount; i++)
            {
                sSQL = "select count(*) from @u8.开料单表体 where 存货编码1 = '" + GridView2.GetRowCellValue(i, GridCol_存货编码) + "' and 序列号1 = '" + GridView2.GetRowCellValue(i, GridCol_序列号) + "' ";
                int iCou = Convert.ToInt32(clsSQLCommond.ExecGetScalar(sSQL));
                if (iCou > 0)
                {
                    throw new Exception("材料已经在开料单使用，不能弃审");
                }
            }

            sSQL = "select * from @u8.材料入库单表头 where 1=-1";
            DataTable dt = clsSQLCommond.ExecQuery(sSQL);

            DataRow dr = dt.NewRow();
            dr["入库单号"] = txt入库单号.Text.Trim();
            dr["入库日期"] = dtm入库日期.Text.Trim();
            dr["制单"] = txt制单.Text.Trim();
            dr["日期"] = dtm制单日期.Text.Trim();
            dr["审核"] = "";
            dr["审核日期"] = DBNull.Value;
            dr["材料类型"] = lookUpEdit材料类型.EditValue.ToString();
            dt.Rows.Add(dr);

            aList = new System.Collections.ArrayList();
            sSQL = clsGetSQL.GetUpdateSQL(FrameBaseFunction.ClsBaseDataInfo.sUFDataBaseName, "材料入库单表头", dt, 0);
            aList.Add(sSQL);

            if (aList.Count > 0)
            {
                int iCou = clsSQLCommond.ExecSqlTran(aList);
                MessageBox.Show("弃审成功！\n合计执行语句:" + iCou + "条");
                GetGrid(txt入库单号.Text.Trim());
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

            if (txt入库单号.Text.Trim() == "")
            {
                throw new Exception("没有单据号，不能记账");
            }
            if (txt审核.Text.Trim() == "")
            {
                throw new Exception("未审核,不可记账");
            }
            if (txt记账.Text.Trim() != "")
            {
                throw new Exception("已经记账");
            }

            sSQL = "select * from @u8.材料入库单表头 where 1=-1";
            DataTable dt = clsSQLCommond.ExecQuery(sSQL);

            DataRow dr = dt.NewRow();
            dr["入库单号"] = txt入库单号.Text.Trim();
            dr["入库日期"] = dtm入库日期.Text.Trim();
            dr["制单"] = txt制单.Text.Trim();
            dr["日期"] = dtm制单日期.Text.Trim();
            dr["审核"] = txt审核.Text.Trim();
            dr["审核日期"] = dtm审核日期.Text.Trim();
            dr["记账"] = FrameBaseFunction.ClsBaseDataInfo.sUserName;
            dr["记账日期"] = FrameBaseFunction.ClsBaseDataInfo.sLogDate;
            dr["材料类型"] = lookUpEdit材料类型.EditValue.ToString();
            dt.Rows.Add(dr);

            aList = new System.Collections.ArrayList();
            sSQL = clsGetSQL.GetUpdateSQL(FrameBaseFunction.ClsBaseDataInfo.sUFDataBaseName, "材料入库单表头", dt, 0);
            aList.Add(sSQL);

            if (aList.Count > 0)
            {
                int iCou = clsSQLCommond.ExecSqlTran(aList);
                MessageBox.Show("记账成功！\n合计执行语句:" + iCou + "条");
                GetGrid(txt入库单号.Text.Trim());
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

            if (txt入库单号.Text.Trim() == "")
            {
                throw new Exception("没有单据号，不能撤销记账");
            }
            if (txt审核.Text.Trim() == "")
            {
                throw new Exception("尚未审核，不能撤销记账");
            }
            if (txt记账.Text.Trim() == "")
            {
                throw new Exception("未记账，不能撤销记账");
            }

            sSQL = "select * from @u8.材料入库单表头 where 1=-1";
            DataTable dt = clsSQLCommond.ExecQuery(sSQL);

            DataRow dr = dt.NewRow();
            dr["入库单号"] = txt入库单号.Text.Trim();
            dr["入库日期"] = dtm入库日期.Text.Trim();
            dr["制单"] = txt制单.Text.Trim();
            dr["日期"] = dtm制单日期.Text.Trim();
            dr["审核"] = txt审核.Text.Trim();
            dr["审核日期"] = dtm审核日期.Text.Trim();
            dr["记账"] = "";
            dr["记账日期"] = DBNull.Value;
            dr["材料类型"] = lookUpEdit材料类型.EditValue.ToString();

            dt.Rows.Add(dr);

            aList = new System.Collections.ArrayList();
            sSQL = clsGetSQL.GetUpdateSQL(FrameBaseFunction.ClsBaseDataInfo.sUFDataBaseName, "材料入库单表头", dt, 0);
            aList.Add(sSQL);

            if (aList.Count > 0)
            {
                int iCou = clsSQLCommond.ExecSqlTran(aList);
                MessageBox.Show("撤销记账成功！\n合计执行语句:" + iCou + "条");
                GetGrid(txt入库单号.Text.Trim());
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

        private void Frm材料入库_Load(object sender, EventArgs e)
        {
            try
            {
                GetLookUp();

                SetEnable(false);
                //btnSel();
                GetSel();
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
            sSQL = "select * from @u8.材料入库单表头 where 入库单号 = '" + sCode + "'";
            DataTable dt = clsSQLCommond.ExecQuery(sSQL);
            base.dsPrint.Tables.Add(dt.Copy());
            base.dsPrint.Tables[0].TableName = "dtHead";

            txt入库单号.EditValue = dt.Rows[0]["入库单号"].ToString().Trim();
            dtm入库日期.Text = dt.Rows[0]["入库日期"].ToString().Trim();
            dtm制单日期.Text = dt.Rows[0]["日期"].ToString().Trim();
            txt入库单号.Text = dt.Rows[0]["入库单号"].ToString().Trim();
            txt制单.Text = dt.Rows[0]["制单"].ToString().Trim();
            txt审核.Text = dt.Rows[0]["审核"].ToString().Trim();
            dtm审核日期.Text = dt.Rows[0]["审核日期"].ToString().Trim();
            txt记账.Text = dt.Rows[0]["记账"].ToString().Trim();
            dtm记账日期.Text = dt.Rows[0]["记账日期"].ToString().Trim();
            lookUpEdit材料类型.EditValue = dt.Rows[0]["材料类型"].ToString().Trim();

            if (lookUpEdit材料类型.Text.Trim() == "板")
            {
                sSQL = @"
select  @u8.材料入库单表体.iID, 入库单号, 行号, 存货编码, 类型, 存放区域, convert(float,厚度) as 厚度, convert(float,宽度) as 宽度, convert(float,长度) as 长度, convert(float,材料密度) as 材料密度,convert(int, 数量) as 数量,convert(int,  数量2) as 数量2, 备注, 描述,
    convert(float,convert(decimal(18, 2),isnull(材料密度,0)*isnull(长度,0)*isnull(宽度,0)*isnull(厚度,0)*isnull(数量,0)/1000000)) as 材料重量,b.iText as 类型名称,c.iText as 存放区域名称  
from @u8.材料入库单表体 
    left join (select * from dbo._LookUpDate where iType = 6) b on  @u8.材料入库单表体.类型=b.iID 
    left join (select * from dbo._LookUpDate where iType = 5) c on  @u8.材料入库单表体.存放区域=c.iID 
where 入库单号 = '" + sCode + "' order by @u8.材料入库单表体.iID ";
            }
            if (lookUpEdit材料类型.Text.Trim() == "棒")
            {
                sSQL = @"
select  @u8.材料入库单表体.iID, 入库单号, 行号, 存货编码, 类型, 存放区域, convert(float,厚度) as 厚度, convert(float,宽度) as 宽度, convert(float,长度) as 长度, convert(float,材料密度) as 材料密度,convert(int, 数量) as 数量,convert(int,  数量2) as 数量2, 备注, 描述,
     convert(float,convert(decimal(18, 2),isnull(材料密度,0)*isnull(长度,0)*(isnull(宽度,0)/2)*(isnull(宽度,0)/2)*3.14*isnull(数量,0)/1000000)) as 材料重量,b.iText as 类型名称,c.iText as 存放区域名称  
from @u8.材料入库单表体 
    left join (select * from dbo._LookUpDate where iType = 6) b on  @u8.材料入库单表体.类型=b.iID 
    left join (select * from dbo._LookUpDate where iType = 5) c on  @u8.材料入库单表体.存放区域=c.iID 
where 入库单号 = '" + sCode + "' order by @u8.材料入库单表体.iID ";

                sSQL = sSQL.Replace("3.14", d密度.ToString());
            }
            dt = clsSQLCommond.ExecQuery(sSQL);
            gridControl1.DataSource = dt;

            base.dsPrint.Tables.Add(dt.Copy());
            base.dsPrint.Tables[1].TableName = "dtGrid";

            if (lookUpEdit材料类型.Text.Trim() == "板")
            {

                sSQL = @"
select  @u8.材料入库单表体2.iID , 入库单号, 入库单行号, 存货编码, 序列号, 类型, 存放区域,  convert(float,厚度) as 厚度, convert(float,宽度) as 宽度, convert(float,长度) as 长度, convert(float,材料密度) as 材料密度,convert(int, 数量) as 数量, 备注, 描述
    ,convert(float,convert(decimal(18, 2),isnull(材料密度,0)*isnull(长度,0)*isnull(宽度,0)*isnull(厚度,0)*isnull(数量,0)/1000000)) as 材料重量,b.iText as 类型名称,c.iText as 存放区域名称 
from @u8.材料入库单表体2 left join (select * from dbo._LookUpDate where iType = 6) b on  @u8.材料入库单表体2.类型=b.iID 
    left join (select * from dbo._LookUpDate where iType = 5) c on  @u8.材料入库单表体2.存放区域=c.iID 
where 入库单号 = '" + sCode + "' order by @u8.材料入库单表体2.iID";
            }
            if (lookUpEdit材料类型.Text.Trim() == "棒")
            {
                sSQL = @"
select  @u8.材料入库单表体2.iID , 入库单号, 入库单行号, 存货编码, 序列号, 类型, 存放区域, 厚度, 宽度, 长度, 材料密度, 数量, 备注, 描述
    ,convert(float,convert(decimal(18, 2),isnull(材料密度,0)*isnull(长度,0)*(isnull(宽度,0)/2)*(isnull(宽度,0)/2)*3.14*isnull(数量,0)/1000000)) as 材料重量,b.iText as 类型名称,c.iText as 存放区域名称 
from @u8.材料入库单表体2 left join (select * from dbo._LookUpDate where iType = 6) b on  @u8.材料入库单表体2.类型=b.iID 
     left join (select * from dbo._LookUpDate where iType = 5) c on  @u8.材料入库单表体2.存放区域=c.iID 
 where 入库单号 = '" + sCode + "' order by @u8.材料入库单表体2.iID";
                sSQL = sSQL.Replace("3.14", d密度.ToString());
            }
            dt = clsSQLCommond.ExecQuery(sSQL);
            gridControl2.DataSource = dt;


            gridView1.OptionsBehavior.Editable = false;
            GridView2.OptionsBehavior.Editable = false;
        }

        private void gridView1_CellValueChanged(object sender, DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs e)
        {
            gridControl2.DataSource = null;
            int iRow = 0;
            if (gridView1.FocusedRowHandle >= 0)
                iRow = gridView1.FocusedRowHandle;

            if (e.Column == GridCol厚度 || e.Column == GridCol宽度 || e.Column == GridCol长度 || e.Column == GridCol材料密度 || e.Column == GridCol数量)
            {
                decimal d厚度 = ReturnObjectToDecimal(gridView1.GetRowCellValue(iRow, GridCol厚度), 6);
                decimal d宽度 = ReturnObjectToDecimal(gridView1.GetRowCellValue(iRow, GridCol宽度), 6);
                decimal d长度 = ReturnObjectToDecimal(gridView1.GetRowCellValue(iRow, GridCol长度), 6);
                decimal d材料密度 = ReturnObjectToDecimal(gridView1.GetRowCellValue(iRow, GridCol材料密度), 6);
                decimal d数量 = ReturnObjectToDecimal(gridView1.GetRowCellValue(iRow, GridCol数量), 6);
                decimal d = 0;
                if (lookUpEdit材料类型.Text == "板")
                {
                    d = d厚度 * d宽度 * d长度 * d材料密度 * d数量 / 1000000;
                }
                if (lookUpEdit材料类型.Text == "棒")
                {
                    d = d密度 * (d宽度 / 2) * (d宽度 / 2) * d长度 * d材料密度 * d数量 / 1000000;
                }
                gridView1.SetRowCellValue(iRow, GridCol材料重量, d);
            }

            if (e.Column == GridCol存货编码 && gridView1.GetRowCellValue(iRow, GridCol存货编码).ToString().Trim() != "")
            {
                sSQL = "select count(*) from @u8.Inventory where cInvCode = '" + gridView1.GetRowCellValue(iRow, GridCol存货编码) + "' ";
                int iCou = Convert.ToInt32(clsSQLCommond.ExecGetScalar(sSQL));
                if (iCou == 0)
                {
                    MessageBox.Show("存货编码不存在");
                    gridView1.FocusedRowHandle = iRow;
                    gridView1.FocusedColumn = GridCol存货编码;
                    gridView1.SetRowCellValue(iRow, GridCol存货编码, DBNull.Value);
                    return;
                }
                else
                {
                   decimal dM = 0;
                    GetInvXLH(gridView1.GetRowCellDisplayText(iRow, GridCol存货编码).ToString().Trim(), out dM);
                    if (dM != 0)
                    {
                        gridView1.SetRowCellValue(iRow, GridCol材料密度, dM);
                    }
                    else
                    {
                        gridView1.SetRowCellValue(iRow, GridCol材料密度, DBNull.Value);
                    }
            }
                
                gridView1.SetRowCellValue(iRow, GridCol行号, iRow + 1);
            }
        }


        /// <summary>
        /// 根据存货编码，获得材料密度
        /// </summary>
        /// <param name="sInvCode">存货编码</param>
        /// <param name="dM">密度</param>
        private void GetInvXLH(string sInvCode,out decimal dM)
        {
            dM = 0;

            string sSQL = "select * from  @u8.Inventory where cInvCode = '" + sInvCode + "'  ";
                            
            DataTable dt = clsSQLCommond.ExecQuery(sSQL);
            if (dt != null && dt.Rows.Count > 0)
            {
                if (dt.Rows[0]["cInvDefine13"].ToString() != "")
                {
                    dM = Convert.ToDecimal(dt.Rows[0]["cInvDefine13"].ToString());
                }
            }
        }

        private void gridView1_CustomDrawRowIndicator(object sender, DevExpress.XtraGrid.Views.Grid.RowIndicatorCustomDrawEventArgs e)
        {
            //e.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            //if (e.Info.IsRowIndicator)
            //{
            //    if (e.RowHandle >= 0)
            //    {
            //        e.Info.DisplayText = (e.RowHandle + 1).ToString();
            //    }
            //    else if (e.RowHandle < 0 && e.RowHandle > -1000)
            //    {
            //        e.Info.Appearance.BackColor = System.Drawing.Color.AntiqueWhite;
            //        e.Info.DisplayText = "G" + e.RowHandle.ToString();
            //    }
            //}
        }
                /// <summary>
        /// 获得参照下拉框数据
        /// </summary>
        private void GetLookUp()
        {
            sSQL = "select * from dbo._LookUpDate where iType = 5";
            DataTable dt = clsSQLCommond.ExecQuery(sSQL);
            ItemLookUpEdit存放区域.DataSource = dt;
            ItemLookUpEdit_存放区域.DataSource = dt;

            sSQL = "select * from dbo._LookUpDate where iType = 6";
            dt = clsSQLCommond.ExecQuery(sSQL);
            ItemLookUpEdit类型.DataSource = dt;
            ItemLookUpEdit_类型.DataSource = dt;

            sSQL = "select * from @u8.Inventory order by cInvCode";
            dt = clsSQLCommond.ExecQuery(sSQL);
            ItemLookUpEditcInvCode.DataSource = dt;


            sSQL = "select cValue as iID from @u8.UserDefine where cID = 52 ";
            dt = clsSQLCommond.ExecQuery(sSQL);
            lookUpEdit材料类型.Properties.DataSource = dt;
        }

        private void SetEnable(bool b)
        {
            txt入库单号.Enabled = false;
            txt制单.Enabled = false;
            dtm入库日期.Enabled = b;
            dtm制单日期.Enabled = false;
            lookUpEdit材料类型.Enabled = b;

            txt审核.Enabled = false;
            dtm审核日期.Enabled = false;

            txt记账.Enabled = false;
            dtm记账日期.Enabled = false;

            gridView1.OptionsBehavior.Editable = b;
            GridView2.OptionsBehavior.Editable = b;
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

        private void ItemButtonEdit存货编码_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            int irow = gridView1.FocusedRowHandle;
            if (irow < 0)
            {
                irow = 0;
            }
            try
            {
                if (irow > 0)
                {
                    gridView1.FocusedRowHandle -= 1;
                    gridView1.FocusedRowHandle += 1;
                }
                else
                {
                    gridView1.FocusedRowHandle -= 1;
                }
            }
            catch { }

            string cinvcode = "";
            if (gridView1.GetRowCellValue(irow, GridCol存货编码) != null)
            {
                cinvcode = gridView1.GetRowCellValue(irow, GridCol存货编码).ToString().Trim();
            }
            FrmInvInfo fInv = new FrmInvInfo(cinvcode);
            if (DialogResult.OK == fInv.ShowDialog())
            {
                fInv.Enabled = true;
                if (gridView1.FocusedRowHandle >= 0)
                {
                    gridView1.SetRowCellValue(irow, GridCol存货编码, fInv.sInvCode);
                }
                else
                {
                    gridView1.SetRowCellValue(0, GridCol存货编码, fInv.sInvCode);
                }
            }
        }

        private void btn生成_Click(object sender, EventArgs e)
        {
            string sErr = "";
            for (int i = 0; i < gridView1.RowCount; i++)
            {
                string s存货编码 = gridView1.GetRowCellValue(i, GridCol存货编码).ToString().Trim();
                string s厚度 = gridView1.GetRowCellValue(i, GridCol厚度).ToString().Trim();
                if (s存货编码 == "")
                {
                    sErr = sErr + "行" + (i + 1)  + "存货编码不能为空\n";
                    continue;
                }
                if (s存货编码.LastIndexOf('A') == s存货编码.Length-1)
                {
                    sErr = sErr + "行" + (i + 1) + "存货编码不可以为产品编码\n";
                    continue;
                }
                if (gridView1.GetRowCellValue(i, GridCol材料密度).ToString().Trim() == "")
                {
                    sErr = sErr + "行" + (i + 1) + "材料密度不能为空\n";
                    continue;
                }
                if (gridView1.GetRowCellValue(i, GridCol存放区域).ToString().Trim() == "")
                {
                    sErr = sErr + "行" + (i + 1) + "存放区域不能为空\n";
                    continue;
                }
                if (gridView1.GetRowCellValue(i, GridCol行号).ToString().Trim() == "")
                {
                    sErr = sErr + "行" + (i + 1) + "行号不能为空\n";
                    continue;
                }
                if (gridView1.GetRowCellValue(i, GridCol厚度).ToString().Trim() == "" && lookUpEdit材料类型.Text.Trim() == "板")
                {
                    sErr = sErr + "行" + (i + 1) + "厚度不能为空\n";
                    continue;
                }
                if (gridView1.GetRowCellValue(i, GridCol宽度).ToString().Trim() == "")
                {
                    string s = "";
                    if (lookUpEdit材料类型.Text.Trim() == "板")
                        s = "宽度";
                    if (lookUpEdit材料类型.Text.Trim() == "棒")
                        s = "直径";

                    sErr = sErr + "行" + (i + 1) + s + "不能为空\n";
                    continue;
                }
                if (gridView1.GetRowCellValue(i, GridCol长度).ToString().Trim() == "")
                {
                    sErr = sErr + "行" + (i + 1) + "长度不能为空\n";
                    continue;
                }
                if (gridView1.GetRowCellValue(i, GridCol类型).ToString().Trim() == "")
                {
                    sErr = sErr + "行" + (i + 1) + "类型不能为空\n";
                    continue;
                }
                if (gridView1.GetRowCellValue(i, GridCol数量).ToString().Trim() == "")
                {
                    sErr = sErr + "行" + (i + 1) + "数量不能为空\n";
                    continue;
                }
                //for (int j = i + 1; j < gridView1.RowCount; j++)
                //{
                //    string s存货编码2 = gridView1.GetRowCellValue(j, GridCol存货编码).ToString().Trim();
                //    string s厚度2 = gridView1.GetRowCellValue(j, GridCol厚度).ToString().Trim();
                //    if (s存货编码 == s存货编码2 && s厚度 == s厚度2)
                //    {
                //        sErr = sErr + "行" + (i + 1) + " 与 行" + (j + 1) + "存货编码一样，一张入库单同一存货编码的厚度不可重复\n";
                //        continue;
                //    }
                //}

                decimal d1 = 0;
                decimal d2 = 0;
                decimal d3 = 0;
                decimal d4 = 0;
                decimal d5 = 0;
                decimal d6 = 0;
                try
                {
                    d1 = ReturnObjectToDecimal(gridView1.GetRowCellValue(i, GridCol数量), 6);
                    d2 =ReturnObjectToDecimal(gridView1.GetRowCellValue(i, GridCol材料密度),6);
                    d3 = ReturnObjectToDecimal(gridView1.GetRowCellValue(i, GridCol厚度),6);
                    d4 = ReturnObjectToDecimal(gridView1.GetRowCellValue(i, GridCol宽度),6);
                    d5 = ReturnObjectToDecimal(gridView1.GetRowCellValue(i, GridCol长度),6);
                }
                catch { }
                if (lookUpEdit材料类型.Text == "板")
                {
                    d6 = d1 * d2 * d3 * d4 * d5 / 1000000;
                }
                if (lookUpEdit材料类型.Text == "棒")
                {
                    d6 = d1 * d2 * d密度 * (d4 / 2) * (d4 / 2) * d5 / 1000000;
                }

                if (d6 == 0)
                {
                    sErr = sErr + "行" + (i + 1) + "重量计算错误\n";
                    continue;
                }
                gridView1.SetRowCellValue(i, GridCol材料重量, d6);
            }

            if (sErr.Length > 0)
            {
                MsgBox(" 提示", sErr);
                return;
            }

            string sSQL = "";
            if (lookUpEdit材料类型.Text == "板")
            {
                sSQL = "SELECT *,宽度*厚度*长度*材料密度*数量/1000000 as 材料重量 FROM @u8.材料入库单表体2 WHERE 1=-1";
            }
            if (lookUpEdit材料类型.Text == "棒")
            {
                sSQL = "SELECT *,3.14 * (宽度/2)* (宽度/2)*长度*材料密度*数量/1000000 as 材料重量 FROM @u8.材料入库单表体2 WHERE 1=-1";
                sSQL = sSQL.Replace("3.14", d密度.ToString());
            }
            DataTable dt = clsSQLCommond.ExecQuery(sSQL);
            gridControl2.DataSource = dt;

            try
            {
                gridView1.FocusedRowHandle -= 1;
                gridView1.FocusedRowHandle += 1;
            }
            catch { }

            int k = -1;
            for (int i = 0; i < gridView1.RowCount; i++)
            {
                int iCou = Convert.ToInt32(gridView1.GetRowCellValue(i, GridCol数量));
                if (iCou > 0)
                {
                    string s存货编码 = gridView1.GetRowCellValue(i, GridCol_存货编码).ToString().Trim();
                    sSQL = "SELECT MAX(序列号) " +
                        "FROM  " +
                        "( " +
                        "SELECT 存货编码,序列号 FROM @u8.材料入库单表体2 " +
                        "UNION ALL " +
                        "SELECT 存货编码1,序列号3 FROM @u8.开料单表体 " +
                        ")a where 存货编码 = '" + s存货编码 + "'";
                    DataTable dt序号 = clsSQLCommond.ExecQuery(sSQL);

                    int i序号 = 0;
                    if (dt序号.Rows[0][0].ToString() != "")
                    {
                        i序号 = Convert.ToInt32(dt序号.Rows[0][0]);
                    }
                    if (dt.Compute("max(序列号)", "存货编码='" + s存货编码 + "'").ToString() != "")
                    {
                        int xh = Convert.ToInt32(dt.Compute("max(序列号)", "存货编码='" + s存货编码 + "'"));
                        if (xh > i序号)
                        {
                            i序号 = xh;
                        }
                    }
                    for (int j = 0; j < iCou; j++)
                    {
                        i序号 += 1;
                        DataRow dr = dt.NewRow();
                        dr["入库单号"] = txt入库单号.Text.Trim();
                        dr["备注"] = gridView1.GetRowCellValue(i, GridCol备注);
                        dr["存放区域"] = gridView1.GetRowCellValue(i, GridCol存放区域);
                        dr["宽度"] = gridView1.GetRowCellValue(i, GridCol宽度);
                        dr["类型"] = gridView1.GetRowCellValue(i, GridCol类型);
                        dr["描述"] = gridView1.GetRowCellValue(i, GridCol描述);
                        dr["数量"] = 1;
                        dr["长度"] = gridView1.GetRowCellValue(i, GridCol长度);
                        dr["厚度"] = gridView1.GetRowCellValue(i, GridCol厚度);
                        dr["序列号"] = i序号;
                        dr["存货编码"] = gridView1.GetRowCellValue(i, GridCol存货编码);
                        dr["材料密度"] = gridView1.GetRowCellValue(i, GridCol材料密度);
                        dr["入库单行号"] = gridView1.GetRowCellValue(i, GridCol行号);

                        decimal d11 = 0;
                        decimal d12 = 0;
                        decimal d13 = 0;
                        decimal d14 = 0;
                        decimal d15 = 0;
                        decimal d16 = 0;
                        try
                        {
                            d11 = ReturnObjectToDecimal(dr["数量"], 6);
                            d12 = ReturnObjectToDecimal(dr["材料密度"], 6);
                            d13 = ReturnObjectToDecimal(dr["宽度"], 6);
                            d14 = ReturnObjectToDecimal(dr["厚度"], 6);
                            d15 = ReturnObjectToDecimal(dr["长度"], 6);
                        }
                        catch { }

                        if (lookUpEdit材料类型.Text == "板")
                        {
                            d16 = d11 * d12 * d13 * d14 * d15 / 1000000;
                        }
                        if (lookUpEdit材料类型.Text == "棒")
                        {
                            d16 = d11 * d12 * (d13 / 2) * (d13 / 2) * d密度 * d15 / 1000000;
                        }
                        dr["材料重量"] = d16;

                        dt.Rows.Add(dr);
                    }
                }
            }

            gridControl2.DataSource = dt;
        }

        private void gridView1_CustomDrawRowIndicator_1(object sender, DevExpress.XtraGrid.Views.Grid.RowIndicatorCustomDrawEventArgs e)
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

        private void GridView2_CustomDrawRowIndicator(object sender, DevExpress.XtraGrid.Views.Grid.RowIndicatorCustomDrawEventArgs e)
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

        private void lookUpEdit材料类型_EditValueChanged(object sender, EventArgs e)
        {
            if (lookUpEdit材料类型.Text.Trim() == "板")
            {
                GridCol厚度.Visible = true;
                GridCol_厚度.Visible = true;

                GridCol宽度.Caption = "宽度";
                GridCol_宽度.Caption = "宽度";

            }
            if (lookUpEdit材料类型.Text.Trim() == "棒")
            {
                GridCol厚度.Visible = false;
                GridCol_厚度.Visible = false;

                GridCol宽度.Caption = "直径";
                GridCol_宽度.Caption = "直径";
            }
        }
    }
}
