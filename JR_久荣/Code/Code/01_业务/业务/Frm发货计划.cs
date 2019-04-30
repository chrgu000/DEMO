using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraLayout;
using System.IO;
using DevExpress.XtraTreeList.Nodes;
using DevExpress.XtraEditors;
using System.Data.SqlClient;
using 系统服务;

namespace 业务
{
    public partial class Frm发货计划 : 系统服务.FrmBaseInfo
    {
        string tablename = "ShipmentPlan";
        string tableid = "cCode";
        string tablenames = "ShipmentPlans";

        long iID = -1;
        public string 单据日期1 = "";
        public string 单据日期2 = "";
        public string 供应商 = "";
        public string 定单编号 = "";

        public Frm发货计划(long siID)
        {
            iID = siID;
            InitializeComponent();

        }

        public Frm发货计划()
        {
            InitializeComponent();

            sLayoutHeadPath = base.sProPath + "\\layout\\" + this.Text.Trim() + "Head.xml";
            sLayoutGridPath = base.sProPath + "\\layout\\" + this.Text.Trim() + "Grid.xml";

            if (File.Exists(sLayoutHeadPath))
                layoutControl1.RestoreLayoutFromXml(sLayoutHeadPath);

            if (File.Exists(sLayoutGridPath))
            {
                //gridControl1.MainView.RestoreLayoutFromXml(sLayoutGridPath);
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
                throw new Exception(ee.Message);
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
            Frm发货计划_Add frm = new Frm发货计划_Add(单据日期1, 单据日期2, 供应商, 定单编号);
            if (DialogResult.OK == frm.ShowDialog())
            {
                frm.Enabled = true;
                单据日期1 = frm.单据日期1;
                单据日期2 = frm.单据日期2;
                供应商 = frm.供应商;
                定单编号 = frm.定单编号;
                GetSel();
            }

        }

        private void GetSel()
        {
            string sSQL = @"
select * 
    from ShipmentPlan a left join ShipmentPlans  b on a.ID=b.ID 
        left join [Registers] reg on reg.id = b.rid
where 1=1 
";
            if (单据日期1 != null && 单据日期1 != "")
            {
                sSQL = sSQL + " and reg.iSheDate>='" + 单据日期1 + "'";
            }
            if (单据日期2 != null && 单据日期2 != "")
            {
                sSQL = sSQL + " and reg.iSheDate<='" + 单据日期2 + "'";
            }
            if (供应商 != null && 供应商 != "")
            {
                sSQL = sSQL + " and a.VenCode='" + 供应商 + "'";
            }
            if (定单编号 != "")
            {
                sSQL = sSQL + " and a.OrderNo='" + 定单编号 + "'";
            }
            sSQL = sSQL + "  order by a.ID";
            dtSel = clsSQLCommond.ExecQuery(sSQL);
            if (dtSel.Rows.Count > 0)
            {
                iID = Convert.ToInt64(dtSel.Rows[0]["ID"]);
                GetGrid();
            }
            else
            {
                //btnLast();
               
            }
        }

        /// <summary>
        /// 首页
        /// </summary>
        private void btnFirst()
        {
            try
            {
                sSQL = "select min(ID) as ID from " + tablename + " where 1=1";
                DataTable dt = clsSQLCommond.ExecQuery(sSQL);
                if (dt.Rows.Count > 0)
                {
                    textEditID.EditValue = Convert.ToInt64(dt.Rows[0]["ID"]); ;
                    iID = Convert.ToInt64(dt.Rows[0]["ID"]); ;
                }
                GetGrid();
            }
            catch (Exception ee)
            {
                MessageBox.Show("加载数据失败：" + ee.Message);
            }
        }
        /// <summary>
        /// 上页
        /// </summary>
        private void btnPrev()
        {
            try
            {
                if (iID != -1)
                {
                    sSQL = "select ID from " + tablename + " where ID<" + iID + " order by ID desc";
                    DataTable dt = clsSQLCommond.ExecQuery(sSQL);
                    if (dt.Rows.Count > 0)
                    {
                        textEditID.EditValue = Convert.ToInt64(dt.Rows[0]["ID"]); ;
                        iID = Convert.ToInt64(dt.Rows[0]["ID"]); ;
                        GetGrid();
                    }
                    else
                    {
                        btnFirst();
                    }
                }
            }
            catch (Exception ee)
            {
                MessageBox.Show("加载数据失败：" + ee.Message);
            }
        }
        /// <summary>
        /// 下页
        /// </summary>
        private void btnNext()
        {
            try
            {
                if (iID != -1)
                {
                    sSQL = "select ID from " + tablename + " where ID>" + iID + " order by ID ";
                    DataTable dt = clsSQLCommond.ExecQuery(sSQL);
                    if (dt.Rows.Count > 0)
                    {
                        textEditID.EditValue = Convert.ToInt64(dt.Rows[0]["ID"]); ;
                        iID = Convert.ToInt64(dt.Rows[0]["ID"]); ;
                        GetGrid();
                    }
                    else
                    {
                        btnLast();
                    }
                }
            }
            catch (Exception ee)
            {
                MessageBox.Show("加载数据失败：" + ee.Message);
            }
        }
        /// <summary>
        /// 末页
        /// </summary>
        private void btnLast()
        {
            try
            {
                sSQL = "select isnull(max(ID),-1) as ID from " + tablename + " where 1=1";
                DataTable dt = clsSQLCommond.ExecQuery(sSQL);
                if (dt.Rows.Count > 0)
                {
                    if (Convert.ToInt64(dt.Rows[0]["ID"]) == -1)
                        iID = -1;
                    else
                        iID = Convert.ToInt64(dt.Rows[0]["ID"]); ;

                    textEditID.EditValue = Convert.ToInt64(dt.Rows[0]["ID"]); ;
                }
                GetGrid();
            }
            catch (Exception ee)
            {
                MessageBox.Show("加载数据失败：" + ee.Message);
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
            Frm发货计划_New frm = new Frm发货计划_New((DataTable)gridControl1.DataSource);
            if (lookUpEdit供应商.EditValue == null)
                frm.供应商 = "";
            else
                frm.供应商 = lookUpEdit供应商.EditValue.ToString().Trim();

            if (DialogResult.OK == frm.ShowDialog())
            {
                bool b = false;
                for (int ii = 0; ii < gridView1.RowCount; ii++)
                {
                    if (gridView1.GetRowCellValue(ii, gridCol门号).ToString().Trim() != "")
                    {
                        b = true;
                        break;
                    }
                }
                if (b && lookUpEdit供应商.EditValue != null && frm.供应商.Trim() != lookUpEdit供应商.EditValue.ToString().Trim() && frm.供应商.Trim() != "")
                {
                    throw new Exception("一张单据只能有一个供应商");
                }

                lookUpEdit供应商.EditValue = frm.供应商;

                frm.Enabled = true;
                DataTable dtnew = frm.dt;
                
                for (int s = 0; s < dtnew.Rows.Count; s++)
                {
                    gridView1.FocusedRowHandle = gridView1.RowCount - 1;
                    int i = gridView1.RowCount - 1;
                    gridView1.SetRowCellValue(i, gridCol门号, dtnew.Rows[s]["Door"].ToString());
                    gridView1.SetRowCellValue(i, gridCol产品名称, dtnew.Rows[s]["cInvName"].ToString());
                    gridView1.SetRowCellValue(i, gridCol品番, dtnew.Rows[s]["InvCode"].ToString());
                    gridView1.SetRowCellValue(i, gridCol何姿, dtnew.Rows[s]["iHZ"].ToString());
                    gridView1.SetRowCellValue(i, gridCol收容数,ReturnDecimal( dtnew.Rows[s]["iSheQty"].ToString()));
                    gridView1.SetRowCellValue(i, gridCol箱数, ReturnDecimal(dtnew.Rows[s]["iBoxQty"].ToString()));
                    gridView1.SetRowCellValue(i, gridCol送货数量, ReturnDecimal(dtnew.Rows[s]["iQty"].ToString()));
                    gridView1.SetRowCellValue(i, gridColOrderNo, dtnew.Rows[s]["OrderNo"].ToString());
                    gridView1.SetRowCellValue(i, gridColiSheDate, dtnew.Rows[s]["iSheDate"].ToString());//RegistersID
                    gridView1.SetRowCellValue(i, gridColRegistersID, dtnew.Rows[s]["RegistersID"].ToString());
                    gridView1.SetRowCellValue(i, gridColVenCode, dtnew.Rows[s]["VenCode"].ToString());
                    gridView1.SetRowCellValue(i, gridColcPosName, dtnew.Rows[s]["cPosName"].ToString());
                }
            }
        }
        /// <summary>
        /// 删行
        /// </summary>
        private void btnDelRow()
        {
            int iRow = 0;
            if (gridView1.RowCount > 0)
                iRow = gridView1.FocusedRowHandle;

            decimal 数量 = 0;
            if (gridView1.GetRowCellValue(iRow, gridCol送货数量).ToString().Trim() != "")
            {
                decimal d上游 = 0;
                decimal d累计 = 0;
                decimal d引用 = 0;
                long lAutoid = -1;
                if (gridView1.GetRowCellValue(iRow, gridColAutoID).ToString().Trim() != "")
                {
                    lAutoid = Convert.ToInt64(gridView1.GetRowCellValue(iRow, gridColAutoID));
                }
                //if (iCodeUsed(Convert.ToInt64(gridView1.GetRowCellValue(iRow, gridColrID)), lAutoid, out d上游, out d累计, out d引用) == -1)
                //{
                //    throw new Exception("获得引用信息失败");
                //}
                //else
                //{
                //    if (数量 + d累计 > d上游)
                //    {
                //        throw new Exception("累计送货数量超出收容数量，订单可下送货数量为" + (d上游 - d累计).ToString());
                //    }
                //    if (数量 + d累计 < d引用)
                //    {
                //        throw new Exception("累计送货数量低于已出库数量,已出库数量为" + d引用.ToString());
                //    }
                //}
            }

            if (gridView1.GetRowCellDisplayText(iRow, gridColAutoID).ToString().Trim() != "")
            {
                sSQL = "select AutoID from @u8.rdrecords where cDefine34 = " + gridView1.GetRowCellDisplayText(iRow, gridColAutoID).ToString().Trim();
                sSQL = sSQL.Replace("@u8.", 系统服务.ClsBaseDataInfo.sUFDataBaseName + ".dbo.");
                DataTable dts = clsSQLCommond.ExecQuery(sSQL);
                if (dts.Rows.Count > 0)
                {
                    throw new Exception("已出库，不可删行");
                }
            }

            if (gridView1.GetRowCellDisplayText(iRow, gridColAutoID).ToString().Trim() != "")
            {
                if (textEditDel.EditValue != null && textEditDel.EditValue.ToString().Trim() != "")
                {
                    textEditDel.EditValue = textEditDel.EditValue.ToString().Trim() + "," + gridView1.GetRowCellDisplayText(iRow, gridColAutoID).ToString().Trim();
                }
                else
                {
                    textEditDel.EditValue = gridView1.GetRowCellDisplayText(iRow, gridColAutoID).ToString().Trim();
                }
            }
            gridView1.DeleteRow(iRow);

        }
        /// <summary>
        /// 新增
        /// </summary>
        private void btnAdd()
        {
            GetNull();
            SetEnabled(true);
            dateEdit单据日期.EditValue = 系统服务.ClsBaseDataInfo.sLogDate;

            int iFocRow = gridView1.FocusedRowHandle;

            //sSQL = "select a.*, 'edit' as iSave,cast(null as decimal(16,6)) as iDelQty,cast(null as int) as rID from " + tablenames + " a  "


               
            //        + " where 1=-1";

            sSQL = @"
select * , 'edit' as iSave,cast(null as decimal(16,6)) as iDelQty,cast(null as int) as RegistersID,cast(null as varchar(50)) as cPosName
    from ShipmentPlan a left join ShipmentPlans  b on a.ID=b.ID 
        left join [Registers] reg on reg.id = b.rid
where 1=-1 
";
            dtBingGrid = clsSQLCommond.ExecQuery(sSQL);
            gridControl1.DataSource = dtBingGrid;
            try
            {
                gridView1.FocusedColumn = gridCol品番;
                gridView1.FocusedRowHandle -= 1;
                gridView1.FocusedRowHandle += 1;
                gridView1.Focus();
            }
            catch { }

            gridView1.OptionsBehavior.Editable = true;

            gridView1.AddNewRow();
            int i = gridView1.RowCount - 1;
            gridView1.FocusedColumn = gridCol品番;
            gridView1.FocusedRowHandle = i;

            btnAddRow();

            sState = "add";
        }
        /// <summary>
        /// 修改
        /// </summary>
        private void btnEdit()
        {
            if (textEdit单据号.Text.Trim() == "")
            {
                throw new Exception("请选择需要修改的单据");
            }

            int iRe = CheState(textEdit单据号.Text.Trim());
            if (iRe == -1)
            {
                throw new Exception("检查单据状态出错");
            }
            if (iRe == 0)
            {
                throw new Exception("单据不存在");
            }
            //if (iRe == 1)
            //{
            //    throw new Exception("单据已保存");
            //} 
            if (iRe == 2)
            {
                throw new Exception("单据已审核");
            }
            if (iRe == 3)
            {
                throw new Exception("单据已关闭");
            }

            sSQL = @"
select a.cCode,rds.cDefine34 ,rds.cDefine35
from ShipmentPlan a inner join ShipmentPlans b on a.ID = b.ID
	inner join @u8.RdRecords rds on b.AutoID = rds.cDefine34
where a.cCode = '{0}' 
";
            sSQL = sSQL.Replace("@u8.", 系统服务.ClsBaseDataInfo.sUFDataBaseName + ".dbo.");
            sSQL = string.Format(sSQL, textEdit单据号.Text.Trim());
            DataTable dt = clsSQLCommond.ExecQuery(sSQL);
            if (dt != null && dt.Rows.Count > 0)
            {
                throw new Exception("已经出库,不能编辑");
            }

            sState = "edit";
            SetEnabled(true);
        }
        /// <summary>
        /// 删除
        /// </summary>
        private void btnDel()
        {

            if (textEditID.Text.Trim() == "")
                throw new Exception("请选择需要删除的单据");

            if (textEdit单据号.Text.Trim() == "")
            {
                throw new Exception("请选择需要修改的单据");
            }

            int iRe = CheState(textEdit单据号.Text.Trim());
            if (iRe == -1)
            {
                throw new Exception("检查单据状态出错");
            }
            if (iRe == 0)
            {
                throw new Exception("单据不存在");
            }
            //if (iRe == 1)
            //{
            //    throw new Exception("单据已保存");
            //} 
            if (iRe == 2)
            {
                throw new Exception("单据已审核");
            }
            if (iRe == 3)
            {
                throw new Exception("单据已关闭");
            }

            sSQL = @"
select a.cCode,rds.cDefine34 ,rds.cDefine35
from ShipmentPlan a inner join ShipmentPlans b on a.ID = b.ID
	inner join @u8.RdRecords rds on b.AutoID = rds.cDefine34
where a.cCode = '{0}' 
";
            sSQL = sSQL.Replace("@u8.", 系统服务.ClsBaseDataInfo.sUFDataBaseName + ".dbo.");
            sSQL = string.Format(sSQL, textEdit单据号.Text.Trim());
            DataTable dt = clsSQLCommond.ExecQuery(sSQL);
            if (dt != null && dt.Rows.Count > 0)
            {
                throw new Exception("已经出库,不能删除");
            }


            DialogResult result = MessageBox.Show("是否删除?", "删除提示", MessageBoxButtons.OKCancel, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1);
            if (result == DialogResult.OK)
            {
                aList = new System.Collections.ArrayList();

                sSQL = @"
select * 
from ShipmentPlans ships 
    left join (select cDefine34,sum(iQuantity) as iqty from @u8.rdrecords where isnull(cDefine34,-1) <> -1 group by cDefine34) rds on ships.autoid = rds.cDefine34
    
where isnull(rds.iqty,0)>0 and ID = " + textEditID.Text.Trim();
                sSQL = sSQL.Replace("@u8.", 系统服务.ClsBaseDataInfo.sUFDataBaseName + ".dbo.");
                DataTable dts = clsSQLCommond.ExecQuery(sSQL);
                if (dts.Rows.Count > 0)
                {
                    throw new Exception("已出库，不可删除");
                }
                sSQL = "delete " + tablename + " where ID = " + textEditID.Text.Trim();
                aList.Add(sSQL);
                sSQL = "delete " + tablenames + " where ID = " + textEditID.Text.Trim();
                aList.Add(sSQL);


                if (aList.Count > 0)
                {
                    int iCou = clsSQLCommond.ExecSqlTran(aList);
                    MessageBox.Show("删除成功！\n合计执行语句:" + iCou + "条");
                    btnLast();
                    sState = "del";
                }
            }
        }

        /// <summary>
        /// 保存
        /// </summary>
        private void btnSave()
        {
            try
            {
                gridView1.FocusedColumn = gridCol品番;
                gridView1.FocusedRowHandle -= 1;
                gridView1.FocusedRowHandle += 1;
                gridView1.Focus();
            }
            catch { }
            bool bHasGrid = false;

            int iRe = CheState(textEdit单据号.Text.Trim());
            if (iRe == -1)
            {
                throw new Exception("检查单据状态出错");
            }
            if (iRe == 0 && (sState == "edit" || sState == "alter"))
            {
                throw new Exception("单据不存在");
            }
            if (iRe == 1 && sState == "alter")
            {
                throw new Exception("单据未审核");
            }
            if (iRe == 2 && sState == "edit")
            {
                throw new Exception("单据已审核");
            }
            if (iRe == 3)
            {
                throw new Exception("单据已关闭");
            }

            sSQL = @"
select a.cCode,rds.cDefine34 ,rds.cDefine35
from ShipmentPlan a inner join ShipmentPlans b on a.ID = b.ID
	inner join @u8.RdRecords rds on b.AutoID = rds.cDefine34
where a.cCode = '{0}' 
";
            sSQL = sSQL.Replace("@u8.", 系统服务.ClsBaseDataInfo.sUFDataBaseName + ".dbo.");
            sSQL = string.Format(sSQL, textEdit单据号.Text.Trim());
            DataTable dt = clsSQLCommond.ExecQuery(sSQL);
            if (dt != null && dt.Rows.Count > 0)
            {
                throw new Exception("已经出库,不能保存");
            }


            sSQL = "select * from " + tablename + " where 1=-1";
            dt = clsSQLCommond.ExecQuery(sSQL);
            sSQL = "select * from " + tablenames + " where 1=-1";
            DataTable dts = clsSQLCommond.ExecQuery(sSQL);
            string sErr = "";
            if (lookUpEdit供应商.EditValue == null || lookUpEdit供应商.EditValue.ToString().Trim() == "")
            {
                throw new Exception("供应商不能为空");
            }
            if (dateEdit单据日期.EditValue == null || dateEdit单据日期.EditValue.ToString().Trim() == "")
            {
                throw new Exception("单据日期不能为空");
            }
            aList = new System.Collections.ArrayList();
            DataRow drh = dt.NewRow();
            if (sState == "add")
            {
                sSQL = "select isnull(isnull(max(ID),-1)+1,1) as ID from " + tablename;
                iID = Convert.ToInt64(clsSQLCommond.ExecGetScalar(sSQL));
                drh["ID"] = iID;
                drh["cCode"] = 系统服务.序号.GetNewSerialNumberContinuous(tablename, tableid);
                textEdit单据号.EditValue = drh["cCode"].ToString();
            }
            else
            {
                drh["ID"] = textEditID.Text;
                iID = Convert.ToInt64(textEditID.Text);
                drh["cCode"] = textEdit单据号.EditValue.ToString().Trim();
            }
            drh["dDate"] = dateEdit单据日期.EditValue.ToString().Trim();

            drh["VenCode"] = lookUpEdit供应商.EditValue.ToString().Trim();

            if (sState == "add")
            {
                dateEdit制单日期.EditValue = 系统服务.ClsBaseDataInfo.sLogDate;
                textEdit制单人.EditValue = 系统服务.ClsBaseDataInfo.sUid;
            }
            else
            {
                drh["UpdateDate"] = 系统服务.ClsBaseDataInfo.sLogDate;
                drh["UpdateUid"] = 系统服务.ClsBaseDataInfo.sUid;
            }

            drh["CreateDate"] = dateEdit制单日期.EditValue.ToString().Trim();
            drh["CreateUid"] = textEdit制单人.EditValue.ToString().Trim();

            dt.Rows.Add(drh);
            if (sState == "add")
            {
                sSQL = clsGetSQL.GetInsertSQL(系统服务.ClsBaseDataInfo.sDataBaseName, tablename, dt, 0);
                aList.Add(sSQL);
            }
            else
            {
                sSQL = clsGetSQL.GetUpdateSQL(系统服务.ClsBaseDataInfo.sDataBaseName, tablename, dt, 0);
                aList.Add(sSQL);
            }

            #region 子表
            sSQL = "select isnull(max(AutoID)+1,1) as AutoID from " + tablenames;
            long sID = Convert.ToInt64(clsSQLCommond.ExecGetScalar(sSQL));
            for (int i = 0; i < gridView1.RowCount; i++)
            {
                if (gridView1.GetRowCellDisplayText(i, gridCol品番).ToString().Trim() == "")
                {
                    continue;
                }
                bHasGrid = true;
                if (gridView1.GetRowCellDisplayText(i, gridColiSave).ToString().Trim() == "update" || gridView1.GetRowCellDisplayText(i, gridColiSave).ToString().Trim() == "add" || gridView1.GetRowCellDisplayText(i, gridColiSave).ToString().Trim() == "alter")
                {
                    #region 判断

                    if (gridView1.GetRowCellValue(i, gridCol送货数量).ToString().Trim() == "")
                    {
                        sErr = sErr + "行" + (i + 1) + gridCol送货数量.Caption + "不能为空\n";
                        continue;
                    }

                    decimal 数量 = ReturnDecimal(gridView1.GetRowCellValue(i, gridCol送货数量));

                    decimal d上游 = 0;
                    decimal d累计 = 0;
                    decimal d引用 = 0;
                    long lAutoid = -1;
                    if (gridView1.GetRowCellValue(i, gridColAutoID).ToString().Trim() != "")
                    {
                        lAutoid = Convert.ToInt64(gridView1.GetRowCellValue(i, gridColAutoID));
                    }
                    if (iCodeUsed(Convert.ToInt32(gridView1.GetRowCellValue(i, gridColRegistersID)), lAutoid, out d上游, out d累计, out d引用) == -1)
                    {
                        sErr = sErr + "行" + (i + 1) + "获得引用信息失败\n";
                        continue;
                    }
                    else
                    {
                        if (数量 + d累计 > d上游)
                        {
                            sErr = sErr + "行" + (i + 1) + "累计送货数量超出收容数量，订单可下送货数量为" + (d上游 - d累计).ToString() + "\n";
                            continue;
                        }
                        if (数量 + d累计 < d引用)
                        {
                            sErr = sErr + "行" + (i + 1) + "累计送货数量低于已出库数量,已出库数量为" + d引用.ToString() + "\n";
                            continue;
                        }
                    }
                    #endregion

                    #region 生成table
                    DataRow dr = dts.NewRow();
                    if (gridView1.GetRowCellValue(i, gridColAutoID).ToString().Trim() == "")
                    {
                        dr["AutoID"] = sID;
                    }
                    else
                    {
                        dr["AutoID"] = gridView1.GetRowCellValue(i, gridColAutoID).ToString().Trim();
                    }
                    dr["ID"] = iID;
                    dr["rID"] = gridView1.GetRowCellValue(i, gridColRegistersID).ToString().Trim();
                    dr["iDelQty"] = gridView1.GetRowCellValue(i, gridCol送货数量).ToString().Trim();
                    dr["Door"] = gridView1.GetRowCellValue(i, gridCol门号).ToString().Trim();
                    dr["iSheQty"] = gridView1.GetRowCellValue(i, gridCol收容数).ToString().Trim();
                    dr["iBoxQty"] = gridView1.GetRowCellValue(i, gridCol箱数).ToString().Trim();
                    dr["iHZ"] = gridView1.GetRowCellValue(i, gridCol何姿).ToString().Trim();
                    dr["InvCode"] = gridView1.GetRowCellValue(i, gridCol品番).ToString().Trim();
                    dts.Rows.Add(dr);
                    sID = sID + 1;
                    #endregion

                    if (gridView1.GetRowCellDisplayText(i, gridColiSave).ToString().Trim() == "update")
                    {
                        sSQL = clsGetSQL.GetUpdateSQL(系统服务.ClsBaseDataInfo.sDataBaseName, tablenames, dts, dts.Rows.Count - 1);
                    }
                    else
                    {
                        sSQL = clsGetSQL.GetInsertSQL(系统服务.ClsBaseDataInfo.sDataBaseName, tablenames, dts, dts.Rows.Count - 1);
                    }

                    aList.Add(sSQL);

                }
                else
                {
                    if (gridView1.GetRowCellValue(i, gridCol收容数).ToString().Trim() != "")
                    {
                        if (ReturnDecimal(gridView1.GetRowCellValue(i, gridCol收容数).ToString().Trim()) < 0)
                        {
                            sErr = sErr + "行" + (i + 1) + gridCol收容数.Caption + "需为正\n";
                            continue;
                        }
                    }
                }
                if (textEditDel.EditValue != null && textEditDel.EditValue.ToString().Trim() != "")
                {
                    sSQL = "delete from  " + tablenames + " where AutoID in (" + textEditDel.EditValue.ToString().Trim() + ")";
                    aList.Add(sSQL);
                }
            }
            #endregion
            if (sErr != "")
            {
                throw new Exception(sErr);
            }

            if (!bHasGrid)
            {
                throw new Exception("数据不完整，不能保存");
            }

            if (aList.Count > 0)
            {
                int iCou = clsSQLCommond.ExecSqlTran(aList);
                MessageBox.Show("保存成功！\n合计执行语句:" + iCou + "条");
                textEditID.EditValue = iID;
                GetGrid();

                sState = "save";
            }

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
            sSQL = @"
select a.cCode,rds.cDefine34 ,rds.cDefine35
from ShipmentPlan a inner join ShipmentPlans b on a.ID = b.ID
	inner join @u8.RdRecords rds on b.AutoID = rds.cDefine34
where a.cCode = '{0}' 
";
            sSQL = sSQL.Replace("@u8.", 系统服务.ClsBaseDataInfo.sUFDataBaseName + ".dbo.");
            sSQL = string.Format(sSQL, textEdit单据号.Text.Trim());
            DataTable dt = clsSQLCommond.ExecQuery(sSQL);
            if (dt != null && dt.Rows.Count > 0)
            {
                throw new Exception("已经出库,不能再次出库");
            }

            Save出库单();
          
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

        private void Frm发货计划_Load(object sender, EventArgs e)
        {
            try
            {
                SetLookUpEdit();
                if (iID != -1)
                {
                    GetGrid();
                }
                else
                {
                    btnLast();
                }

            }
            catch (Exception ee)
            {
                MessageBox.Show("加载窗体失败\n" + ee.Message);
            }
        }

        private void GetGrid()
        {
            if (iID != -1)
            {
                sSQL = @"
select *
    ,cast(0 as int) as 条数,cast(null as decimal(16,2)) as 箱数,cast(null as decimal(16,2)) as 数量 ,cast(null as varchar(100)) as lSum
from ShipmentPlan
where ID=" + iID;
                DataTable dt = clsSQLCommond.ExecQuery(sSQL);
                if (dt.Rows.Count > 0)
                {
                    textEditDel.Text = "";

                    textEditID.EditValue = Convert.ToInt64(dt.Rows[0]["ID"]); 
                    textEdit单据号.EditValue = dt.Rows[0]["cCode"].ToString();
                    dateEdit单据日期.EditValue = DateTime.Parse(dt.Rows[0]["dDate"].ToString()).ToString("yyyy-MM-dd");

                    dateEdit制单日期.EditValue = DateTime.Parse(dt.Rows[0]["CreateDate"].ToString()).ToString("yyyy-MM-dd");
                    textEdit制单人.EditValue = dt.Rows[0]["CreateUid"].ToString();

                    lookUpEdit供应商.EditValue = dt.Rows[0]["VenCode"].ToString();

                    lookUpEdit供应商.Enabled = false;
                    sSQL = @"
select ROW_NUMBER() over(order by AutoID) as RowNum,a.AutoID, a.ID, a.Door, a.InvCode, a.iHZ, convert(int,a.iSheQty) as iSheQty
                    , convert(int,a.iBoxQty) as iBoxQty, convert(int,a.iDelQty) as iDelQty, convert(int,rds.iQty) as iOutQty, a.rID,i.cInvName, 'edit' as iSave 
                ,pos.cPosName,pos.cPosCode
                ,reg.OrderNo,CONVERT(varchar(100), reg.iSheDate, 111) as iSheDate,reg.id as RegistersID,reg.VenCode
from ShipmentPlans a 
	left join @u8.Inventory i on a.InvCode=i.cInvCode 
	left join @u8.Position pos on pos.cPosCode = i.cPosition 
	left join (select cDefine34 as iID, sum(iQuantity) as iQty from @u8.rdrecords where isnull(cDefine34,-1) <> -1 group by cDefine34) rds on a.[AutoID] = rds.iID
    left join [Registers] reg on reg.id = a.rid
where a.ID=" + iID;
                    sSQL = sSQL.Replace("@u8.", 系统服务.ClsBaseDataInfo.sUFDataBaseName + ".dbo.");

                    dtBingGrid = clsSQLCommond.ExecQuery(sSQL);
                    gridControl1.DataSource = dtBingGrid;

                    sSQL = @"
select  a.Door, a.InvCode, a.iHZ, convert(int,a.iSheQty) as iSheQty
                    , sum(convert(int,a.iBoxQty) - isnull(rds.iNum,0)) as iBoxQty, sum(convert(int,a.iDelQty) - isnull(rds.iQty,0)) as iDelQty
					,pos.cPosName,i.cInvName,pos.cPosCode
                    ,cast(null as int) as 序号,count(*) as 分组条数
                    ,reg.OrderNo,CONVERT(varchar(100), reg.iSheDate, 111) as iSheDate,reg.VenCode
from ShipmentPlans a 
	left join @u8.Inventory i on a.InvCode=i.cInvCode 
	left join @u8.Position pos on pos.cPosCode = i.cPosition 
	left join (select cDefine34 as iID, sum(iQuantity) as iQty, sum(cDefine35) as iNum from @u8.rdrecords where isnull(cDefine34,-1) <> -1 group by cDefine34) rds on a.[AutoID] = rds.iID
    left join [Registers] reg on reg.id = a.rid
where a.ID={0}
group by a.Door, a.InvCode, a.iHZ, a.iSheQty ,pos.cPosName,i.cInvName,reg.OrderNo,reg.iSheDate, a.Door,reg.VenCode,pos.cPosCode
having sum(convert(int,a.iDelQty) - isnull(rds.iQty,0)) > 0
order by  a.Door,reg.VenCode,iSheDate,pos.cPosName, a.InvCode
";
                    sSQL = string.Format(sSQL, iID);
                    DataTable dtGrid2 = clsSQLCommond.ExecQuery(sSQL);
                    gridControl2.DataSource = dtGrid2;


                    gridView1.FocusedRowHandle = iFocRow;

                    decimal d箱数 = 0;
                    decimal d数量 = 0;
                    int i条数 = dtGrid2.Rows.Count;

                    for (int ii = 0; ii < dtGrid2.Rows.Count; ii++)
                    {
                        d箱数 += ReturnDecimal(dtGrid2.Rows[ii]["iBoxQty"]);
                        d数量 += ReturnDecimal(dtGrid2.Rows[ii]["iDelQty"]);
                        dtGrid2.Rows[ii]["序号"] = ii + 1;
                        
                    }

                    dt.Rows[0]["条数"] = i条数;
                    dt.Rows[0]["箱数"] = d箱数;
                    dt.Rows[0]["数量"] = d数量;
                    dt.Rows[0]["lSum"] = "条数:" + i条数.ToString() + ", 箱数:" + d箱数.ToString() + "; 累计送货数量:" + d数量.ToString();


                    base.dsPrint.Tables.Clear();
                    base.dsPrint.Tables.Add(dt.Copy());
                    base.dsPrint.Tables[0].TableName = "dtHead";
                    base.dsPrint.Tables.Add(dtGrid2.Copy());
                    base.dsPrint.Tables[1].TableName = "dtGrid";
                }
                else
                {
                    GetNull();
                }
            }
            else
            {
                GetNull();
            }
            SetEnabled(false);
            sState = "sel";
        }

        /// <summary>
        /// 下拉列表框
        /// </summary>
        private void SetLookUpEdit()
        {
            系统服务.LookUp.Vendor(lookUpEdit供应商);

            系统服务.LookUp.Inventory(ItemLookUpEdit产品名称);
            ItemLookUpEdit产品名称.Properties.DisplayMember = "cInvName";
        }

        private void SetEnabled(bool b)
        {
            dateEdit单据日期.Enabled = b;
            dateEdit制单日期.Enabled = false;

            textEdit单据号.Enabled = false;
            textEdit制单人.Enabled = false;

            lookUpEdit供应商.Enabled = false;

            gridView1.OptionsBehavior.Editable = b;

        }

        private void GetNull()
        {
            dateEdit单据日期.EditValue = DBNull.Value;
            dateEdit制单日期.EditValue = DBNull.Value;

            textEditID.EditValue = "";
            textEdit单据号.EditValue = "";
            textEdit制单人.EditValue = "";

            lookUpEdit供应商.EditValue = "";

            gridControl1.DataSource = null;

        }

        private void gridView1_CellValueChanged(object sender, DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs e)
        {
            try
            {
                int iRow = gridView1.FocusedRowHandle;

                #region
                if (e.Column != gridColiSave && gridView1.GetRowCellDisplayText(iRow, gridColiSave).ToString().Trim() == "")
                {
                    gridView1.SetRowCellValue(iRow, gridColiSave, "add");
                }
                if (e.Column != gridColiSave && gridView1.GetRowCellDisplayText(iRow, gridColiSave).ToString().Trim() == "edit")
                {
                    gridView1.SetRowCellValue(iRow, gridColiSave, "update");
                }
                if (e.RowHandle == gridView1.RowCount - 1 && gridView1.GetRowCellDisplayText(e.RowHandle, gridCol品番).ToString().Trim() != "")
                {
                    gridView1.AddNewRow();
                    gridView1.FocusedRowHandle = iRow + 1;
                }
                #endregion
            }
            catch (Exception ee)
            {
                MessageBox.Show(ee.Message);
            }
        }

        private void gridView1_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            try
            {
            }
            catch (Exception ee)
            {
                MessageBox.Show(ee.Message);
            }

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
        private int CheState(string sCode)
        {
            int iReturn = -1;
            try
            {
                sSQL = "select  isnull(CreateUid,'') as 制单人 from " + tablename + " where " + tableid + " = '" + sCode + "'";
                DataTable dt = clsSQLCommond.ExecQuery(sSQL);
                if (dt == null || dt.Rows.Count < 1)
                    iReturn = 0;
                else
                {
                    if (dt.Rows[0]["制单人"].ToString().Trim() != "")
                    {
                        iReturn = 1;
                    }
                }
            }
            catch (Exception ee)
            {
                MessageBox.Show(ee.Message);
            }
            return iReturn;
        }

        /// <summary>
        /// 判断单据是否已经使用
        /// </summary>
        /// <param name="sCode">子表ID</param>
        /// <returns></returns>
        private decimal iCodeUsed(long 上游ID, long 当前ID, out decimal d上游单据数量, out decimal d累计使用数量, out decimal d引用量)
        {
            decimal iReturn = -1;
            d上游单据数量 = 0;
            d累计使用数量 = 0;
            d引用量 = 0;
            try
            {
//                sSQL = @"
//select isnull(sum(b.iDelQty),0) as iQuantity,isnull(a.iQty,0) as iQty
//from Registers a left join ShipmentPlans b on a.ID = b.rID  and b.AutoID <> " + 当前ID + " " +
//                       "where a.ID = '" + 上游ID + "' ";

//                sSQL = sSQL + "group by a.iSheQty,a.iQty";

                                sSQL = @"
select isnull(sum(b.iDelQty),0) as iQuantity,isnull(a.iQty,0) as iQty
from Registers a left join ShipmentPlans b on a.ID = b.rID  and b.AutoID <> {0}
where a.ID = {1} 
group by a.iSheQty,a.iQty
";
                                sSQL = string.Format(sSQL, 当前ID, 上游ID);

                DataTable dt = clsSQLCommond.ExecQuery(sSQL);
                if (dt != null && dt.Rows.Count > 0)
                {
                    d累计使用数量 = Convert.ToDecimal(dt.Rows[0][0]);
                    d上游单据数量 = Convert.ToDecimal(dt.Rows[0][1]);
                }
                sSQL = @"select isnull(sum(iQuantity),0) as iQty from @u8.rdrecords 
                       where cDefine34 = '" + 当前ID + "' ";
                sSQL = sSQL.Replace("@u8.", 系统服务.ClsBaseDataInfo.sUFDataBaseName + ".dbo.");
                dt = clsSQLCommond.ExecQuery(sSQL);
                if (dt != null && dt.Rows.Count > 0)
                {
                    d引用量 = Convert.ToDecimal(dt.Rows[0][0]);
                }
                iReturn = 0;
            }
            catch (Exception ee)
            {
                MessageBox.Show(ee.Message);
            }
            return iReturn;
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

        private void xtraTabControl1_SelectedPageChanged(object sender, DevExpress.XtraTab.TabPageChangedEventArgs e)
        {
            try
            {
                if (e.Page.Name == "Page发货汇总")
                {

                }
            }
            catch (Exception ee)
            { 
            
            }
        }


        public void Save出库单()
        {
            try
            {
                string sErr = "";

                if (gridControl1.DataSource == null || gridView1.RowCount < 1)
                    throw new Exception("没有需要保存的数据");

                SqlConnection conn = new SqlConnection(系统服务.ClsBaseDataInfo.sConnString);
                conn.Open();
                //启用事务
                SqlTransaction tran = conn.BeginTransaction();

                try
                {
                    string sSQL = "select getdate()";
                    DateTime d当前服务器时间 = Convert.ToDateTime(ClsSqlHelper.ExecuteScalar(tran, CommandType.Text, sSQL));

                    //1.   判断是否结账
                    sSQL = "select * from @u8.gl_mend where iperiod=month(getdate())";
                    sSQL = sSQL.Replace("@u8.", 系统服务.ClsBaseDataInfo.sUFDataBaseName + ".dbo.");
                    DataTable dtTemp = ClsSqlHelper.ExecuteDataset(tran, CommandType.Text, sSQL).Tables[0];
                    if (dtTemp == null || dtTemp.Rows.Count < 1)
                    {
                        throw new Exception("判断模块结账失败");
                    }
                    int iR = ReturnInt(dtTemp.Rows[0]["bflag_ST"]); 
                    if (iR == 1)
                    {
                        throw new Exception("当前月份已经结账");
                    }


                    //2. 获得单据ID
                    long lID = 1;
                    long lIDDetail = 1;
                    GetRdID(out lID, out lIDDetail, ClsBaseDataInfo.sUFDataBaseName.Substring(7, 3));


                    //3. 获得单据号
                    long iCode = 0;
                    sSQL = "select * From @u8.VoucherHistory  with (ROWLOCK) Where  CardNumber='0302'";
                    sSQL = sSQL.Replace("@u8.", ClsBaseDataInfo.sUFDataBaseName + ".dbo.");
                    dtTemp = ClsSqlHelper.ExecuteDataset(tran, CommandType.Text, sSQL).Tables[0];
                    if (dtTemp == null || dtTemp.Rows.Count < 1)
                    {
                        iCode = 1;
                    }
                    else
                    {
                        iCode = ReturnLong(dtTemp.Rows[0]["cNumber"]);
                    }

                    //4. 组装表头

                    lID += 1;
                    string s货位 = gridView1.GetRowCellValue(0, gridColcPosCode).ToString().Trim();

                    sSQL = @"
select distinct a.cWhCode ,a.cPosCode
from @u8.InvPosition a inner join @u8.Position b on a.cPosCode = b.cPosCode
where a.cPosCode = '{0}'
";
                    sSQL = string.Format(sSQL, s货位);
                    DataTable dtWHPos = ClsSqlHelper.ExecuteDataset(tran, CommandType.Text, sSQL).Tables[0];
                    if (dtWHPos == null || dtWHPos.Rows.Count == 0)
                    {
                        throw new Exception("获得仓库信息失败");
                    }
                    string s仓库 = dtWHPos.Rows[0]["cWhCode"].ToString().Trim();
                    string s订单号 = gridView1.GetRowCellValue(0, gridColOrderNo).ToString().Trim();

                    string s制单人 = sUserName;

                    iCode += 1;
                    string s单据号 = sGetCode(iCode, 10, "");

                    Model.RdRecord model = new Model.RdRecord();
                    model.ID = lID;
                    model.bRdFlag = 0;
                    model.cVouchType = "09";
                    model.cBusType = "其他出库";
                    model.cSource = "库存";
                    model.cWhCode = s仓库;
                    model.dDate = DateTime.Parse(DateTime.Now.ToString("yyyy-MM-dd"));
                    model.cCode = s单据号;
                    model.cRdCode = "CK01";
                    //model.bTransFlag = 0;
                    model.cMaker = s制单人;
                    //model.bpufirst = 0;
                    //model.biafirst = 0;
                    model.iMQuantity = 0;
                    model.VT_ID = 9108;
                    //model.bIsSTQc = 0;

                    DAL.RdRecord dal = new DAL.RdRecord();
                    ClsSqlHelper.ExecuteNonQuery(tran, CommandType.Text, dal.Add(model).Replace("@u8.", ClsBaseDataInfo.sUFDataBaseName + ".dbo."));

                    for (int i = 0; i < gridView1.RowCount; i++)
                    {
                        string s存货编码 = gridView1.GetRowCellValue(i, gridCol品番).ToString().Trim();
                        sSQL = @"
select * from @u8.Inventory where cInvCode = '{0}'
";
                        sSQL = string.Format(sSQL, s存货编码);
                        DataTable dtInv = ClsSqlHelper.ExecuteDataset(tran, CommandType.Text, sSQL).Tables[0];
                        if (dtInv == null || dtInv.Rows.Count == 0)
                        {
                            throw new Exception("品番在T6不存在;" + s存货编码);
                        }

                        string s批号 = "";

                        sSQL = @"
select distinct a.cWhCode,a.cPosCode 
from @u8.InvPosition a inner join @u8.Position b on a.cPosCode = b.cPosCode
where a.cPosCode = '{0}'
";
                        sSQL = string.Format(sSQL, gridView1.GetRowCellValue(i, gridColcPosCode).ToString().Trim());
                        DataTable dtWHPos2 = ClsSqlHelper.ExecuteDataset(tran, CommandType.Text, sSQL).Tables[0];
                        if (dtWHPos2 == null || dtWHPos2.Rows.Count == 0)
                        {
                            throw new Exception("获得仓库信息失败");
                        }

                        string s仓库2 = dtWHPos2.Rows[0]["cWhCode"].ToString().Trim();
                        if (s仓库 != s仓库2)
                        {
                            throw new Exception("不能从两个仓库发货");
                        }

                        s货位 = dtWHPos2.Rows[0]["cPosCode"].ToString().Trim();
                        string sAutoID = gridView1.GetRowCellValue(i, gridColAutoID).ToString().Trim();
                        decimal d数量 = ReturnDecimal(gridView1.GetRowCellValue(i, gridCol送货数量), 6);
                        int i箱数 = ReturnInt(gridView1.GetRowCellValue(i, gridCol箱数));
                        if (i箱数 == 0)
                        {
                            i箱数 = 1;
                        }

                        decimal d件数 = 0;
                        string cFree1 = "";
                        string cFree2 = "";
                        string cFree3 = "";
                        string cFree4 = "";
                        string cFree5 = "";
                        string cFree6 = "";
                        string cFree7 = "";
                        string cFree8 = "";
                        string cFree9 = "";
                        string cFree10 = "";

                        sSQL = "select * from @u8.Inventory where cInvCode = '" + s存货编码 + "'";
                        sSQL = sSQL.Replace("@u8.", ClsBaseDataInfo.sUFDataBaseName + ".dbo.");
                        DataTable dt存货信息 = ClsSqlHelper.ExecuteDataset(tran, CommandType.Text, sSQL).Tables[0];
                        if (dt存货信息 == null || dt存货信息.Rows.Count < 1)
                        {
                            sErr = sErr + "存货编码:" + s存货编码 + "获得存货信息失败\n";
                            continue;
                        }

                        s货位 = dt存货信息.Rows[0]["cPosition"].ToString();

                        sSQL = @"select top 1 * from @u8.InvPosition where cWhCode = '" + s仓库
                            + "' and cInvCode = '" + s存货编码 + "' and cWhCode='" + s仓库 + "' and cPosCode='" + s货位 + "' order by iQuantity desc";
                        sSQL = sSQL.Replace("@u8.", ClsBaseDataInfo.sUFDataBaseName + ".dbo.");
                        DataTable dt现存量 = ClsSqlHelper.ExecuteDataset(tran, CommandType.Text, sSQL).Tables[0];
                        if (dt现存量.Rows.Count == 0)
                        {
                            sErr = sErr + "存货编码:" + s存货编码 + ",无现存量\n";
                            continue;
                        }

                        decimal d现存数量 =ReturnDecimal(dt现存量.Rows[0]["iQuantity"], 6);
                        decimal d现存件数 = ReturnDecimal(dt现存量.Rows[0]["iNum"], 6);
                        if (d现存件数 != 0)
                        {
                            d件数 =ReturnDecimal(d数量 * d现存件数 / d现存数量, 6);
                        }

                        //string cPosition = dt现存量.Rows[0]["cPosCode"].ToString();
                        //组装表体
                        lIDDetail += 1;

                        Model.RdRecords models = new Model.RdRecords();
                        models.AutoID = lIDDetail;
                        models.ID = lID;
                        models.cInvCode = s存货编码;
                        models.iNum = d件数;
                        models.iQuantity = d数量;
                        models.iUnitCost = 0;
                        models.iFlag = 0;
                        models.iTax = 0;
                        models.iSQuantity = 0;
                        models.iSNum = 0;
                        models.iMoney = 0;
                        models.iSOutQuantity = 0;
                        models.iSOutNum = 0;
                        models.iFNum = 0;
                        models.iFQuantity = 0;
                        models.cPosition = s货位;
                        //models.cDefine22 = sAutoID;
                        models.cDefine34 = Convert.ToInt32(sAutoID);
                        models.cDefine35 = i箱数;

                        DAL.RdRecords dals = new DAL.RdRecords();

                        ClsSqlHelper.ExecuteNonQuery(tran, CommandType.Text, dals.Add(models).Replace("@u8.", ClsBaseDataInfo.sUFDataBaseName + ".dbo."));

                        string s数量 = "0";
                        if (d数量 > 0)
                        {
                            s数量 = (d数量).ToString();
                        }
                        string s件数 = "0";
                        if (d件数 > 0)
                        {
                            s件数 = (d件数).ToString();
                        }

                        //仓库登记
                        sSQL = "if exists(select * from @u8.CurrentStock where cinvcode = '" + s存货编码 + "' and isnull(cBatch,'') = isnull('" + s批号 + "','')  and cWhCode = '" + s仓库
                           + "' and ISNULL(cFree1,'') = ISNULL(" + ReturnCol(cFree1)
                           + ",'') and ISNULL(cFree2,'') = ISNULL(" + ReturnCol(cFree1)
                           + ",'') and ISNULL(cFree3,'') = ISNULL(" + ReturnCol(cFree1)
                           + ",'') and ISNULL(cFree4,'') = ISNULL(" + ReturnCol(cFree1)
                           + ",'') and ISNULL(cFree5,'') = ISNULL(" + ReturnCol(cFree1)
                           + ",'') and ISNULL(cFree6,'') = ISNULL(" + ReturnCol(cFree1)
                           + ",'') and ISNULL(cFree7,'') = ISNULL(" + ReturnCol(cFree1)
                           + ",'') and ISNULL(cFree8,'') = ISNULL(" + ReturnCol(cFree1)
                           + ",'') and ISNULL(cFree9,'') = ISNULL(" + ReturnCol(cFree1)
                           + ",'') and ISNULL(cFree10,'') = ISNULL(" + ReturnCol(cFree1) + ",'') )" +
                           "    update @u8.CurrentStock set iQuantity = isnull(iQuantity,0) - " + s数量 + ",iNum = isnull(iNum,0) - " + s件数 + " " +
                           "    where cinvcode = '" + s存货编码 + "' and isnull(cBatch,'') = isnull(" + ReturnCol(s批号) + ",'') and cWhCode = '" + s仓库
                            + "' and ISNULL(cFree1,'') = ISNULL(" + ReturnCol(cFree1)
                            + ",'') and ISNULL(cFree2,'') = ISNULL(" + ReturnCol(cFree2)
                            + ",'') and ISNULL(cFree3,'') = ISNULL(" + ReturnCol(cFree3)
                            + ",'') and ISNULL(cFree4,'') = ISNULL(" + ReturnCol(cFree4)
                            + ",'') and ISNULL(cFree5,'') = ISNULL(" + ReturnCol(cFree5)
                            + ",'') and ISNULL(cFree6,'') = ISNULL(" + ReturnCol(cFree6)
                            + ",'') and ISNULL(cFree7,'') = ISNULL(" + ReturnCol(cFree7)
                            + ",'') and ISNULL(cFree8,'') = ISNULL(" + ReturnCol(cFree8)
                            + ",'') and ISNULL(cFree9,'') = ISNULL(" + ReturnCol(cFree9)
                            + ",'') and ISNULL(cFree10,'') = ISNULL(" + ReturnCol(cFree10) + ",'') " +
                           "else " +
                           "    insert into @u8.CurrentStock(cWhCode,cInvCode,cBatch,iQuantity,iNum,cFree1,cFree2,cFree3,cFree4,cFree5,cFree6,cFree7,cFree8,cFree9,cFree10)  " +
                           "    values('" + s仓库 + "', '" + s存货编码 + "'," + ReturnCol(s批号) + "," + s数量 + "," + s件数
                            + "," + ReturnCol(cFree1)
                            + "," + ReturnCol(cFree2)
                            + "," + ReturnCol(cFree3)
                            + "," + ReturnCol(cFree4)
                            + "," + ReturnCol(cFree5)
                            + "," + ReturnCol(cFree6)
                            + "," + ReturnCol(cFree7)
                            + "," + ReturnCol(cFree8)
                            + "," + ReturnCol(cFree9)
                            + "," + ReturnCol(cFree10) + ")";
                        sSQL = sSQL.Replace("@u8.", ClsBaseDataInfo.sUFDataBaseName + ".dbo.");
                        ClsSqlHelper.ExecuteNonQuery(tran, CommandType.Text, sSQL);

                        //货位登记
                        sSQL = "insert into @u8.InvPosition( RdsID, RdID, cWhCode, cPosCode, cInvCode, cBatch, dVDate, iQuantity" +
                                ", iNum, cMemo, cHandler, dDate, bRdFlag, cSource, cAssUnit, cBVencode, iTrackId, dMadeDate, iMassDate" +
                                ",cFree1,cFree2,cFree3,cFree4,cFree5,cFree6,cFree7,cFree8,cFree9,cFree10) " +
                            "values(" + lIDDetail + "," + lID + ",'" + s仓库 + "','" + s货位 + "','" + s存货编码 + "',null,null," + s数量 + " " +
                            "," + s件数 + ",null,'" + s制单人 + "','" + d当前服务器时间.ToString("yyyy-MM-dd") + "',0,null"
                            + ",null,null,0,null,null"
                            + ",null,null,null,null,null,null,null,null,null,null)";
                        sSQL = sSQL.Replace("@u8.", ClsBaseDataInfo.sUFDataBaseName + ".dbo.");
                        ClsSqlHelper.ExecuteNonQuery(tran, CommandType.Text, sSQL);


                    }
                    //7. 更新历史单据号表
                    sSQL = "update @u8.VoucherHistory set cNumber='" + iCode + "' Where  CardNumber='0302' and cContent is NULL";
                    sSQL = sSQL.Replace("@u8.", ClsBaseDataInfo.sUFDataBaseName + ".dbo.");
                    ClsSqlHelper.ExecuteNonQuery(tran, CommandType.Text, sSQL);


                    //8. 更新单据ID号表
                    //string s1 = lID.ToString().Trim();
                    //string s2 = lIDDetail.ToString().Trim();
                    //s1 = s1.Substring(1);
                    //s2 = s2.Substring(1);
                    //lID = Convert.ToInt64(s1);
                    //lIDDetail = Convert.ToInt64(s2);
                    sSQL = "update  UFSystem..UA_Identity set iFatherID = " + lID + ",iChildID = " + lIDDetail + " where cAcc_Id = '" + ClsBaseDataInfo.sUFDataBaseName.Substring(7, 3) + "' and cVouchType = 'rd'";
                    ClsSqlHelper.ExecuteNonQuery(tran, CommandType.Text, sSQL);

                    if (sErr.Trim().Length > 0)
                    {
                        throw new Exception(sErr);
                    }

                    tran.Commit();

                    MessageBox.Show("生成单据号：" + s单据号);

                    GetGrid();
                }
                catch (Exception error)
                {
                    tran.Rollback();
                    throw new Exception(error.Message);
                }
            }
            catch (Exception ee)
            {
                throw new Exception(ee.Message);
            }
        }

        public void GetRdID(out long iID, out long iIDDetail, string sAccid)
        {
            string sSQL = @"
select MAX(id) as id,MAX(autoid) as autoid from @u8.rdrecords
            ";
            sSQL = sSQL.Replace("@u8.", ClsBaseDataInfo.sUFDataBaseName + ".dbo.");
            long l1 = 0;
            long l2 = 0;
            long l3 = 0;
            long l4 = 0;
            DataTable dt = ClsSqlHelper.ExecuteDataset(ClsBaseDataInfo.sConnString, CommandType.Text, sSQL).Tables[0];
            if (dt != null && dt.Rows.Count > 0)
            {
                l1 = Convert.ToInt64(dt.Rows[0]["id"]);
                l2 = Convert.ToInt64(dt.Rows[0]["autoid"]);
            }

            sSQL = "select * from UFSystem..UA_Identity where cAcc_Id = '" + sAccid + "' and cVouchType = 'rd'";
            dt = ClsSqlHelper.ExecuteDataset(ClsBaseDataInfo.sConnString, CommandType.Text, sSQL).Tables[0];
            if (dt != null && dt.Rows.Count > 0)
            {
                l3 = Convert.ToInt64(dt.Rows[0]["iFatherId"]);
                l4 = Convert.ToInt64(dt.Rows[0]["iChildId"]);
            }
            if (l1 > l3)
                iID = l1;
            else
                iID = l3;

            if (l2 > l4)
                iIDDetail = l2;
            else
                iIDDetail = l4;
        }

        /// <summary>
        /// 根据序号组装单据号
        /// </summary>
        /// <param name="l"></param>
        /// <param name="iLength"></param>
        /// <param name="s前缀"></param>
        /// <returns></returns>
        private string sGetCode(long l, int iLength, string s前缀)
        {
            string sCode = l.ToString();
            for (int i = 0; i < iLength; i++)
            {
                if (sCode.Length < iLength)
                {
                    sCode = "0" + sCode;
                }
                else
                {
                    break;
                }
            }
            return s前缀 + sCode;
        }

        public string ReturnCol(string s)
        {
            if (s.Trim() == "")
            {
                s = "null";
            }
            else
            {
                s = "'" + s + "'";
            }
            return s;
        }


        public string ReturnCol(object o)
        {
            return ReturnCol(o.ToString());
        }

    }
}
