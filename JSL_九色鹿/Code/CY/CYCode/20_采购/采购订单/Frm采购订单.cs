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

namespace 采购
{
    public partial class Frm采购订单 : 系统服务.FrmBaseInfo
    {
        string tablename = "PO_POMain";
        string tableid = "cPOCode";
        string tablenames = "PO_PODetails";

        long iID = -1;
        public string 单据号1 = "";
        public string 单据号2 = "";
        public string 单据日期1 = "";
        public string 单据日期2 = "";
        public string 制单日期1 = "";
        public string 制单日期2 = "";
        public string 业务员 = "";
        public string 部门 = "";
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

        string isChange = "";

        public DataTable dt子件;


        public Frm采购订单(long siID)
        {
            iID = siID;
            InitializeComponent();
            
        }

        public Frm采购订单()
        {
            InitializeComponent();

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
            throw new NotImplementedException();
        }

        private void btnLayout(string sText)
        {
            throw new NotImplementedException();
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
            Frm采购订单_Add frm = new Frm采购订单_Add(单据号1, 单据号2, 单据日期1, 单据日期2, 制单日期1, 制单日期2, 业务员,
               部门, 供应商1, 供应商2, 审核日期1, 审核日期2, 制单人1, 制单人2, 审核人1, 审核人2, 物料1, 物料2);
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
                部门 = frm.部门;
                供应商1 = frm.供应商1;
                供应商2 = frm.供应商2;
                审核日期1 = frm.审核日期1;
                审核日期2 = frm.审核日期2;
                制单人1 = frm.制单人1;
                制单人2 = frm.制单人2;
                审核人1 = frm.审核人1;
                审核人2 = frm.审核人2;
                物料1 = frm.物料1;
                物料2 = frm.物料2;
                GetSel();
            }

        }

        private void GetSel()
        {
            string sSQL = "select * from " + tablename + " a left join " + tablenames + "  b on a.ID=b.ID where 1=1";
            if (单据号1 != null && 单据号1 != "")
            {
                sSQL = sSQL + " and a." + tableid + ">='" + 单据号1 + "'";
            }
            if (单据号2 != null && 单据号2 != "")
            {
                sSQL = sSQL + " and a." + tableid + "<='" + 单据号2 + "'";
            }
            if (单据日期1 != null && 单据日期1 != "")
            {
                sSQL = sSQL + " and dDate>='" + 单据日期1 + "'";
            }
            if (单据日期2 != null && 单据日期2 != "")
            {
                sSQL = sSQL + " and dDate<='" + 单据日期2 + "'";
            }
            if (制单日期1 != null && 制单日期1 != "")
            {
                sSQL = sSQL + " and dCreatesysTime>='" + 制单日期1 + "'";
            }
            if (制单日期2 != null && 制单日期2 != "")
            {
                sSQL = sSQL + " and dCreatesysTime<='" + 制单日期2 + "'";
            }
            if (业务员 != null && 业务员 != "")
            {
                sSQL = sSQL + " and cPersonCode='" + 业务员 + "'";
            }
            if (部门 != "")
            {
                sSQL = sSQL + " and cDepCode='" + 部门 + "'";
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
                sSQL = sSQL + " and cInvCode>='" + 物料1 + "'";
            }
            if (物料2 != "")
            {
                sSQL = sSQL + " and cInvCode<='" + 物料2 + "'";
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
                btnLast();
            }

        }

        /// <summary>
        /// 首页
        /// </summary>
        private void btnFirst()
        {
            try
            {
                sSQL = "select min(ID) as ID from " + tablename + " ";
                DataTable dt = clsSQLCommond.ExecQuery(sSQL);
                if (dt.Rows.Count > 0)
                {
                    textEditID.EditValue = Convert.ToInt64(dt.Rows[0]["ID"]);;
                    iID = Convert.ToInt64(dt.Rows[0]["ID"]);;
                }
                GetSelBind();
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
                    sSQL = "select ID from " + tablename + " where ID<" + textEditID.EditValue.ToString().Trim() + " order by ID desc";
                    DataTable dt = clsSQLCommond.ExecQuery(sSQL);
                    if (dt.Rows.Count > 0)
                    {
                        textEditID.EditValue = Convert.ToInt64(dt.Rows[0]["ID"]);;
                        iID = Convert.ToInt64(dt.Rows[0]["ID"]);
                    }
                    GetSelBind();
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
                    sSQL = "select ID from " + tablename + " where ID>" + textEditID.EditValue.ToString().Trim() + " order by ID ";
                    DataTable dt = clsSQLCommond.ExecQuery(sSQL);
                    if (dt.Rows.Count > 0)
                    {
                        textEditID.EditValue = Convert.ToInt64(dt.Rows[0]["ID"]);;
                        iID = Convert.ToInt64(dt.Rows[0]["ID"]);;
                    }
                    GetSelBind();
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
                sSQL = "select isnull(max(ID),-1) as ID from " + tablename + " ";
                DataTable dt = clsSQLCommond.ExecQuery(sSQL);
                if (dt.Rows.Count > 0)
                {
                    textEditID.EditValue = Convert.ToInt64(dt.Rows[0]["ID"]);;
                    iID = Convert.ToInt64(dt.Rows[0]["ID"]);;
                }
                GetSelBind();
            }
            catch (Exception ee)
            {
                MessageBox.Show("加载数据失败：" + ee.Message);
            }
        }

        private void GetSelBind()
        {
            GetGrid();
            SetEnabled(false);
            sState = "";
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
            int iRow = 0;
            if (gridView1.RowCount > 0)
                iRow = gridView1.FocusedRowHandle;

            if (sState == "alter")
            {
                long lAutoID = Convert.ToInt64(gridView1.GetRowCellValue(iRow, gridColAutoID));
                decimal iCou = iCodeUsed(lAutoID);
                if (iCou == -1)
                {
                    throw new Exception("获得引用数据失败");
                }
                if (iCou > 0)
                {
                    throw new Exception("改行数据已经引用，不能删行");
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
                gridView1.DeleteRow(iRow);
            }
            else
            {
                gridView1.DeleteRow(iRow);
            }

            for (int i = 0; i < gridView1.RowCount; i++)
            {
                if (gridView1.GetRowCellDisplayText(i, gridCol序号).ToString().Trim() != "")
                {
                    gridView1.SetRowCellValue(i, gridCol序号, i + 1);
                }
            }
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

            sSQL = "select a.*, 'edit' as iSave,cast(null as decimal(16,6)) as 引用量,cast(null as decimal(16,6)) as 历史数量 from " + tablenames + " a  where 1=-1";
            dtBingGrid = clsSQLCommond.ExecQuery(sSQL);
            gridControl1.DataSource = dtBingGrid;
            try
            {
                gridView1.FocusedColumn = gridCol序号;
                gridView1.FocusedRowHandle -= 1;
                gridView1.FocusedRowHandle += 1;
                gridView1.Focus();
            }
            catch { }

            gridView1.AddNewRow();
            gridView1.FocusedRowHandle = 0;


            gridView1.OptionsBehavior.Editable = true;
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
            if(iRe == -1)
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

            SetEnabled(true);
            gridView1.AddNewRow();
            gridView1.FocusedRowHandle = 0;
            sState = "edit";
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
            DialogResult result = MessageBox.Show("是否删除?", "删除提示", MessageBoxButtons.OKCancel, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1);
            if (result == DialogResult.OK)
            {
                string sErr = "";

                aList = new System.Collections.ArrayList();
                sSQL = "delete dbo.PO_PODetails where ID = " + textEditID.Text.Trim();
                aList.Add(sSQL);
                sSQL = "delete dbo.PO_POMain where ID = " + textEditID.Text.Trim();
                aList.Add(sSQL);

               
                if (aList.Count > 0)
                {
                    int iCou = clsSQLCommond.ExecSqlTran(aList);
                    MessageBox.Show("删除成功！\n合计执行语句:" + iCou + "条");
                    GetGrid();

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
                gridView1.FocusedColumn = gridCol序号;
                gridView1.FocusedRowHandle -= 1;
                gridView1.FocusedRowHandle += 1;
                gridView1.Focus();
            }
            catch { }

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

            string sErr = "";

            sSQL = "select * from " + tablename + " where 1=-1";
            DataTable dt = clsSQLCommond.ExecQuery(sSQL);
            sSQL = "select * from " + tablenames + " where 1=-1";
            DataTable dts = clsSQLCommond.ExecQuery(sSQL);

            //if (textEdit单据号.EditValue == null || textEdit单据号.EditValue.ToString().Trim() == "")
            //{
            //    throw new Exception("单据号不能为空");
            //}
            if (buttonEdit供应商.EditValue == null || buttonEdit供应商.EditValue.ToString().Trim() == "")
            {
                throw new Exception("供应商不能为空");
            }
            if (dateEdit单据日期.EditValue == null || dateEdit单据日期.EditValue.ToString().Trim() == "")
            {
                throw new Exception("单据日期不能为空");
            }
            if (lookUpEdit业务员.Text.Trim() == "")
            {
                throw new Exception("业务员不能为空");
            }
            if (lookUpEdit部门.Text.Trim() == "")
            {
                throw new Exception("部门不能为空");
            }
            if (lookUpEdit供应商.Text.Trim() == "")
            {
                throw new Exception("供应商不能为空");
            }
            if (lookUpEdit采购类型.Text.Trim() == "")
            {
                throw new Exception("采购类型不能为空");
            }

            aList = new System.Collections.ArrayList();
            DataRow drh = dt.NewRow();
            if (sState == "add")
            {
                sSQL = "select isnull(isnull(max(ID),-1)+1,1) as ID from " + tablename;
                iID = Convert.ToInt64(clsSQLCommond.ExecGetScalar(sSQL));
                drh["ID"] = iID;
               
                textEdit单据号.EditValue = clsPublic.GetNewSerialNumberContinuous(tablename, tableid);
            }
            else
            {
                drh["ID"] = textEditID.EditValue.ToString().Trim();
                iID = Convert.ToInt64(textEditID.Text);
            }

            sSQL = "select count(*) from " + tablename + " where cPOCode='" + textEdit单据号.EditValue.ToString().Trim() + "' and ID<>'" + iID + "'";
            decimal scount = Convert.ToInt64(clsSQLCommond.ExecGetScalar(sSQL));
            if (scount > 0)
            {
                sErr = sErr + "采购订单号不能重复\n";
            }
            drh["cPOCode"] = textEdit单据号.EditValue.ToString().Trim();
            drh["dDate"] = dateEdit单据日期.EditValue.ToString().Trim();

            drh["cPersonCode"] = buttonEdit业务员.EditValue.ToString().Trim();
            drh["cDepCode"] = buttonEdit部门.EditValue.ToString().Trim();
            drh["cVenCode"] = buttonEdit供应商.EditValue.ToString().Trim();
            drh["cPTCode"] = lookUpEdit采购类型.EditValue.ToString().Trim();

            drh["cMemo"] = textEdit备注.EditValue.ToString().Trim();

            if (sState == "add" )
            {
                textEdit制单人.Text = 系统服务.ClsBaseDataInfo.sUid;
                dateEdit制单日期.Text = GetSystemTime();
            }
            if (sState == "alter")
            {
                drh["dVerifysysTime"] = dateEdit审核日期.Text.Trim();
                drh["dVerifysysPerson"] = textEdit审核人.Text.Trim();
                textEdit关闭人.Text = 系统服务.ClsBaseDataInfo.sUid;
                dateEdit关闭日期.Text = GetSystemTime();
            }

            drh["dCreatesysTime"] = dateEdit制单日期.Text.Trim();
            drh["dCreatesysPerson"] = textEdit制单人.Text.Trim();
            //drh["dVerifysysTime"] = dateEdit审核日期.Text.Trim();
            //drh["dVerifysysPerson"] = textEdit审核人.Text.Trim();
            //drh["dChangeVerifyTime"] = textEdit关闭人.Text.Trim();
            //drh["dChangeVerifyPerson"] = dateEdit关闭日期.Text.Trim();
            dt.Rows.Add(drh);

            if (sState == "add")
            {
                sSQL = clsGetSQL.GetInsertSQL(系统服务.ClsBaseDataInfo.sDataBaseName, tablename, dt, 0);
                aList.Add(sSQL);
            }
            if (sState == "alter" || sState == "edit")
            {
                sSQL = clsGetSQL.GetUpdateSQL(系统服务.ClsBaseDataInfo.sDataBaseName, tablename, dt, 0);
                aList.Add(sSQL);
            }

            #region 更新变更表
            if (sState == "alter")
            {
                clsPublic.GetChange(tablename, tablenames, textEditID.EditValue.ToString().Trim(), clsGetSQL, aList);
            }
            #endregion

            #region 删行
            if (textEditDel.EditValue != null && textEditDel.EditValue.ToString().Trim() != "")
            {
                clsPublic.GetChangeDelRow(tablenames, textEditDel.EditValue.ToString().Trim(), aList);
            }
            #endregion

            #region 子表

            sSQL = "select isnull(max(AutoID)+1,1) as AutoID from " + tablenames;
            long sAutoID = Convert.ToInt64(clsSQLCommond.ExecGetScalar(sSQL));
            for (int i = 0; i < gridView1.RowCount; i++)
            {
                if (gridView1.GetRowCellDisplayText(i, gridColiSave).ToString().Trim() == "edit" || gridView1.GetRowCellDisplayText(i, gridColiSave).ToString().Trim() == "update" || gridView1.GetRowCellDisplayText(i, gridColiSave).ToString().Trim() == "add")
                {
                    #region 判断
                    if (gridView1.GetRowCellDisplayText(i, gridCol物料编码).ToString().Trim() == "")
                    {
                        continue;
                    }
                    if (gridView1.GetRowCellDisplayText(i, gridCol物料名称).ToString().Trim() == "")
                    {
                        sErr = sErr + "行" + (i + 1) + "无此物料\n";
                        continue;
                    }

                    if (ReturnDecimal(gridView1.GetRowCellValue(i, gridCol数量)) <= 0)
                    {
                        sErr = sErr + "行" + (i + 1) + gridCol数量.Caption + "必须大于0\n";
                        continue;
                    }
                    if (ReturnDecimal(gridView1.GetRowCellValue(i, gridCol含税单价)) <= 0)
                    {
                        sErr = sErr + "行" + (i + 1) + gridCol含税单价.Caption + "必须大于0\n";
                        continue;
                    }
                    #endregion

                    #region 生成table
                    DataRow dr = dts.NewRow();
                    if (gridView1.GetRowCellDisplayText(i, gridColiSave).ToString().Trim() == "add")
                    {
                        gridView1.SetRowCellValue(i, gridColAutoID, sAutoID);
                        sAutoID = sAutoID + 1;
                    }

                    dr["AutoID"] = gridView1.GetRowCellValue(i, gridColAutoID).ToString().Trim();
                    dr["ID"] = iID;
                    dr["cPOCode"] = textEdit单据号.EditValue.ToString().Trim();
                    dr["iRowNo"] = gridView1.GetRowCellValue(i, gridCol序号).ToString().Trim();
                    dr["cInvCode"] = gridView1.GetRowCellValue(i, gridCol物料编码).ToString().Trim();
                    dr["iQuantity"] = gridView1.GetRowCellValue(i, gridCol数量).ToString().Trim();
                    if (gridView1.GetRowCellValue(i, gridCol件数) != null && gridView1.GetRowCellValue(i, gridCol件数).ToString().Trim() != "")
                    {
                        dr["iNum"] = gridView1.GetRowCellValue(i, gridCol件数).ToString().Trim();
                    }
                    if (gridView1.GetRowCellValue(i, gridCol含税单价) != null && gridView1.GetRowCellValue(i, gridCol含税单价).ToString().Trim() != "")
                    {
                        dr["iUnitPrice"] = gridView1.GetRowCellValue(i, gridCol含税单价).ToString().Trim();
                    }
                    if (gridView1.GetRowCellValue(i, gridCol含税金额) != null && gridView1.GetRowCellValue(i, gridCol含税金额).ToString().Trim() != "")
                    {
                        dr["iMoney"] = gridView1.GetRowCellValue(i, gridCol含税金额).ToString().Trim();
                    }
                    if (gridView1.GetRowCellValue(i, gridCol无税单价) != null && gridView1.GetRowCellValue(i, gridCol无税单价).ToString().Trim() != "")
                    {
                        dr["iNatUnitPrice"] = gridView1.GetRowCellValue(i, gridCol无税单价).ToString().Trim();
                    }
                    if (gridView1.GetRowCellValue(i, gridCol无税金额) != null && gridView1.GetRowCellValue(i, gridCol无税金额).ToString().Trim() != "")
                    {
                        dr["iNatMoney"] = gridView1.GetRowCellValue(i, gridCol无税金额).ToString().Trim();
                    }
                    if (gridView1.GetRowCellValue(i, gridCol税率) != null && gridView1.GetRowCellValue(i, gridCol税率).ToString().Trim() != "")
                    {
                        dr["iTaxRate"] = gridView1.GetRowCellValue(i, gridCol税率).ToString().Trim();
                    }
                    if (gridView1.GetRowCellValue(i, gridCol换算率) != null && gridView1.GetRowCellValue(i, gridCol换算率).ToString().Trim() != "")
                    {
                        dr["iChangRate"] = gridView1.GetRowCellValue(i, gridCol换算率).ToString().Trim();
                    }
                    if (gridView1.GetRowCellValue(i, gridCol税额) != null && gridView1.GetRowCellValue(i, gridCol税额).ToString().Trim() != "")
                    {
                        dr["iNatTax"] = gridView1.GetRowCellValue(i, gridCol税额).ToString().Trim();
                    }

                    dr["cMemo"] = gridView1.GetRowCellValue(i, gridCol备注).ToString().Trim();

                    //dr["cClosesysPerson"] = gridView1.GetRowCellValue(i, gridCol行关闭人).ToString().Trim();
                    //dr["cClosesysTime"] = gridView1.GetRowCellValue(i, gridCol行关闭日期).ToString().Trim();

                    #region 
                    dr["S1"] = gridView1.GetRowCellValue(i, gridColS1).ToString().Trim();
                    dr["S2"] = gridView1.GetRowCellValue(i, gridColS2).ToString().Trim();
                    dr["S3"] = gridView1.GetRowCellValue(i, gridColS3).ToString().Trim();
                    dr["S4"] = gridView1.GetRowCellValue(i, gridColS4).ToString().Trim();
                    dr["S5"] = gridView1.GetRowCellValue(i, gridColS5).ToString().Trim();
                    dr["S6"] = gridView1.GetRowCellValue(i, gridColS6).ToString().Trim();
                    dr["S7"] = gridView1.GetRowCellValue(i, gridColS7).ToString().Trim();
                    dr["S8"] = gridView1.GetRowCellValue(i, gridColS8).ToString().Trim();
                    dr["S9"] = gridView1.GetRowCellValue(i, gridColS9).ToString().Trim();
                    dr["S10"] = gridView1.GetRowCellValue(i, gridColS10).ToString().Trim();

                    dr["M1"] = gridView1.GetRowCellValue(i, gridColM1).ToString().Trim();
                    dr["M2"] = gridView1.GetRowCellValue(i, gridColM2).ToString().Trim();
                    dr["M3"] = gridView1.GetRowCellValue(i, gridColM3).ToString().Trim();
                    dr["M4"] = gridView1.GetRowCellValue(i, gridColM4).ToString().Trim();
                    dr["M5"] = gridView1.GetRowCellValue(i, gridColM5).ToString().Trim();
                    dr["M6"] = gridView1.GetRowCellValue(i, gridColM6).ToString().Trim();
                    dr["M7"] = gridView1.GetRowCellValue(i, gridColM7).ToString().Trim();
                    dr["M8"] = gridView1.GetRowCellValue(i, gridColM8).ToString().Trim();
                    dr["M9"] = gridView1.GetRowCellValue(i, gridColM9).ToString().Trim();
                    dr["M10"] = gridView1.GetRowCellValue(i, gridColM10).ToString().Trim();

                    if (ReturnDecimal(gridView1.GetRowCellValue(i, gridColD1)) != 0)
                    {
                        dr["D1"] = gridView1.GetRowCellValue(i, gridColD1).ToString().Trim();
                    }
                    if (ReturnDecimal(gridView1.GetRowCellValue(i, gridColD2)) != 0)
                    {
                        dr["D2"] = gridView1.GetRowCellValue(i, gridColD2).ToString().Trim();
                    }
                    if (ReturnDecimal(gridView1.GetRowCellValue(i, gridColD3)) != 0)
                    {
                        dr["D3"] = gridView1.GetRowCellValue(i, gridColD3).ToString().Trim();
                    }
                    if (ReturnDecimal(gridView1.GetRowCellValue(i, gridColD4)) != 0)
                    {
                        dr["D4"] = gridView1.GetRowCellValue(i, gridColD4).ToString().Trim();
                    }
                    if (ReturnDecimal(gridView1.GetRowCellValue(i, gridColD5)) != 0)
                    {
                        dr["D5"] = gridView1.GetRowCellValue(i, gridColD5).ToString().Trim();
                    }
                    if (ReturnDecimal(gridView1.GetRowCellValue(i, gridColD6)) != 0)
                    {
                        dr["D6"] = gridView1.GetRowCellValue(i, gridColD6).ToString().Trim();
                    }
                    if (ReturnDecimal(gridView1.GetRowCellValue(i, gridColD7)) != 0)
                    {
                        dr["D7"] = gridView1.GetRowCellValue(i, gridColD7).ToString().Trim();
                    }
                    if (ReturnDecimal(gridView1.GetRowCellValue(i, gridColD8)) != 0)
                    {
                        dr["D8"] = gridView1.GetRowCellValue(i, gridColD8).ToString().Trim();
                    }
                    if (ReturnDecimal(gridView1.GetRowCellValue(i, gridColD9)) != 0)
                    {
                        dr["D9"] = gridView1.GetRowCellValue(i, gridColD9).ToString().Trim();
                    }
                    if (ReturnDecimal(gridView1.GetRowCellValue(i, gridColD10)) != 0)
                    {
                        dr["D10"] = gridView1.GetRowCellValue(i, gridColD10).ToString().Trim();
                    }

                    if ((gridView1.GetRowCellValue(i, gridColDate1)).ToString().Trim() != "")
                    {
                        dr["Date1"] = gridView1.GetRowCellValue(i, gridColDate1).ToString().Trim();
                    }
                    if ((gridView1.GetRowCellValue(i, gridColDate2)).ToString().Trim() != "")
                    {
                        dr["Date2"] = gridView1.GetRowCellValue(i, gridColDate2).ToString().Trim();
                    }
                    if ((gridView1.GetRowCellValue(i, gridColDate3)).ToString().Trim() != "")
                    {
                        dr["Date3"] = gridView1.GetRowCellValue(i, gridColDate3).ToString().Trim();
                    }
                    if ((gridView1.GetRowCellValue(i, gridColDate4)).ToString().Trim() != "")
                    {
                        dr["Date4"] = gridView1.GetRowCellValue(i, gridColDate4).ToString().Trim();
                    }
                    if ((gridView1.GetRowCellValue(i, gridColDate5)).ToString().Trim() != "")
                    {
                        dr["Date5"] = gridView1.GetRowCellValue(i, gridColDate5).ToString().Trim();
                    }
                    if ((gridView1.GetRowCellValue(i, gridColDate6)).ToString().Trim() != "")
                    {
                        dr["Date6"] = gridView1.GetRowCellValue(i, gridColDate6).ToString().Trim();
                    }
                    if ((gridView1.GetRowCellValue(i, gridColDate7)).ToString().Trim() != "")
                    {
                        dr["Date7"] = gridView1.GetRowCellValue(i, gridColDate7).ToString().Trim();
                    }
                    if ((gridView1.GetRowCellValue(i, gridColDate8)).ToString().Trim() != "")
                    {
                        dr["Date8"] = gridView1.GetRowCellValue(i, gridColDate8).ToString().Trim();
                    }
                    if ((gridView1.GetRowCellValue(i, gridColDate9)).ToString().Trim() != "")
                    {
                        dr["Date9"] = gridView1.GetRowCellValue(i, gridColDate9).ToString().Trim();
                    }
                    if ((gridView1.GetRowCellValue(i, gridColDate10)).ToString().Trim() != "")
                    {
                        dr["Date10"] = gridView1.GetRowCellValue(i, gridColDate10).ToString().Trim();
                    }
                    #endregion

                    dts.Rows.Add(dr);
                    #endregion

                    if (gridView1.GetRowCellDisplayText(i, gridColiSave).ToString().Trim() == "update" || gridView1.GetRowCellDisplayText(i, gridColiSave).ToString().Trim() == "edit")
                    {
                        sSQL = clsGetSQL.GetUpdateSQL(系统服务.ClsBaseDataInfo.sDataBaseName, tablenames, dts, dts.Rows.Count - 1);
                    }
                     if (gridView1.GetRowCellDisplayText(i, gridColiSave).ToString().Trim() == "add" )
                    {
                        sSQL = clsGetSQL.GetInsertSQL(系统服务.ClsBaseDataInfo.sDataBaseName, tablenames, dts, dts.Rows.Count - 1);
                    }

                    aList.Add(sSQL);
                }
            }
            #endregion


            if (sErr.Length != 0)
            {
                throw new Exception(sErr.ToString());
            }

            if (dt == null || dt.Rows.Count <= 0)
            {
                throw new Exception("表头不能为空");
            }

            bool b = false;
            for (int i = 0; i < gridView1.RowCount; i++)
            {
                if (gridView1.GetRowCellValue(i, gridCol物料编码).ToString().Trim() != "")
                {
                    b = true;
                    break;
                }
            }
            if (!b)
            {
                throw new Exception("表体不能为空");
            }

            if (aList.Count > 0)
            {
                int iCou = clsSQLCommond.ExecSqlTran(aList);
                MessageBox.Show("保存成功！\n合计执行语句:" + iCou + "条");
                textEditID.EditValue = iID;
                textEditDel.Text = "";
                GetGrid();
                sState = "save";
                SetEnabled(false);
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
            if (textEdit单据号.Text.Trim() == "")
            {
                throw new Exception("请选择需要审核的单据");
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

            aList = new System.Collections.ArrayList();

            sSQL = "update " + tablename + " set dVerifysysTime='" + GetSystemTime() + "',dVerifysysPerson='" + 系统服务.ClsBaseDataInfo.sUid + "' where ID=" + textEditID.EditValue.ToString().Trim() + "";
            aList.Add(sSQL);

            if (aList.Count > 0)
            {
                int iCou = clsSQLCommond.ExecSqlTran(aList);
                MessageBox.Show("审核成功！\n合计执行语句:" + iCou + "条");

                textEdit审核人.Text = 系统服务.ClsBaseDataInfo.sUid;
                dateEdit审核日期.Text = ReturnDateTimeString(GetSystemTime());
                sState = "audit";
            }
        }
        /// <summary>
        /// 弃审
        /// </summary>
        private void btnUnAudit()
        {
            if (textEdit单据号.Text.Trim() == "")
            {
                throw new Exception("请选择需要弃审的单据");
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
            if (iRe == 1)
            {
                throw new Exception("单据未审核");
            } 
            //if (iRe == 2)
            //{
            //    throw new Exception("单据已审核");
            //}
            if (iRe == 3)
            {
                throw new Exception("单据已关闭");
            }
            int iUsed= iCodeUsed(textEdit单据号.Text.Trim());
            if (iUsed > 0)
            {
                throw new Exception("单据已引用");
            }

            aList = new System.Collections.ArrayList();

            sSQL = "update " + tablename + " set dVerifysysTime=null,dVerifysysPerson=null where ID=" + textEditID.EditValue.ToString().Trim() + "";
            aList.Add(sSQL);

            if (aList.Count > 0)
            {
                int iCou = clsSQLCommond.ExecSqlTran(aList);
                MessageBox.Show("弃审成功！\n合计执行语句:" + iCou + "条");
                textEdit审核人.Text = "";
                dateEdit审核日期.Text = "";
                sState = "unaudit";
            }
        }
        /// <summary>
        /// 打开
        /// </summary>
        private void btnOpen()
        {
            int iRe = CheState(textEdit单据号.Text.Trim());
            if (iRe == -1)
            {
                throw new Exception("检查单据状态出错");
            }
            if (iRe == 0)
            {
                throw new Exception("单据不存在");
            }
            if (iRe == 1)
            {
                throw new Exception("单据未审核");
            }
            if (iRe == 2)
            {
                throw new Exception("单据未关闭");
            }
            //if (iRe == 3)
            //{
            //    throw new Exception("单据已关闭");
            //}

            aList = new System.Collections.ArrayList();

            sSQL = "update " + tablename + " set dClosesysTime=null,dClosesysPerson=null where ID=" + textEditID.EditValue.ToString().Trim() + "";
            aList.Add(sSQL);
            sSQL = "update " + tablenames + " set cClosesysTime=null,cClosesysPerson=null where ID=" + textEditID.EditValue.ToString().Trim() + " ";
            aList.Add(sSQL);

            if (aList.Count > 0)
            {
                int iCou = clsSQLCommond.ExecSqlTran(aList);
                MessageBox.Show("打开成功！\n合计执行语句:" + iCou + "条");

                textEdit关闭人.Text = "";
                dateEdit关闭日期.Text = "";
                sState = "open";
            }
        }
        /// <summary>
        /// 关闭
        /// </summary>
        private void btnClose()
        {
            int iRe = CheState(textEdit单据号.Text.Trim());
            if (iRe == -1)
            {
                throw new Exception("检查单据状态出错");
            }
            if (iRe == 0)
            {
                throw new Exception("单据不存在");
            }
            if (iRe == 1)
            {
                throw new Exception("单据未审核");
            }
            //if (iRe == 2)
            //{
            //    throw new Exception("单据已审核");
            //}
            if (iRe == 3)
            {
                throw new Exception("单据已关闭");
            }


            aList = new System.Collections.ArrayList();

            sSQL = "update " + tablename + " set dClosesysTime='" + GetSystemTime() + "',dClosesysPerson='" + 系统服务.ClsBaseDataInfo.sUid + "' where ID=" + textEditID.EditValue.ToString().Trim() + "";
            aList.Add(sSQL);
            sSQL = "update " + tablenames + " set cClosesysTime='" + GetSystemTime() + "',cClosesysPerson='" + 系统服务.ClsBaseDataInfo.sUid + "' where ID=" + textEditID.EditValue.ToString().Trim() + " and  (cClosesysPerson='' or cClosesysPerson is null)";
            aList.Add(sSQL);
            if (aList.Count > 0)
            {
                int iCou = clsSQLCommond.ExecSqlTran(aList);
                MessageBox.Show("关闭成功！\n合计执行语句:" + iCou + "条");

                textEdit关闭人.Text = 系统服务.ClsBaseDataInfo.sUid;
                dateEdit关闭日期.Text = ReturnDateTimeString(GetSystemTime());
                sState = "close";
            }
        }
        /// <summary>
        /// 变更
        /// </summary>
        private void btnAlter()
        {
            int iRe = CheState(textEdit单据号.Text.Trim());
            if (iRe == -1)
            {
                throw new Exception("检查单据状态出错");
            }
            if (iRe == 0)
            {
                throw new Exception("单据不存在");
            }
            if (iRe == 1)
            {
                throw new Exception("单据未审核");
            }
            if (iRe == 3)
            {
                throw new Exception("单据已关闭");
            }

            for (int i = 0; i < gridView1.RowCount; i++)
            {
                if (gridView1.GetRowCellValue(i, gridCol物料编码)!=null && gridView1.GetRowCellValue(i, gridCol物料编码).ToString().Trim() == "")
                    continue;

                if (ReturnDecimal(gridView1.GetRowCellValue(i, gridColAutoID)) != 0)
                {
                    long lAutoID = Convert.ToInt64(gridView1.GetRowCellValue(i, gridColAutoID));
                    gridView1.SetRowCellValue(i, gridCol引用量, iCodeUsed(lAutoID));
                }
            }
            SetEnabled(true);
            sState = "alter";
        }

        #endregion

        private void Frm采购订单_Load(object sender, EventArgs e)
        {
            try
            {
                GetLayOut(layoutControl1, gridControl1);
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

                sSQL = @"select a.*,u1.vchrName as 制单人,u2.vchrName as 审核人,d.cDepName,c.cVenName,  p1.PersonName,
convert(varchar(10),dCreatesysTime,120) as 制单日期,convert(varchar(10),dVerifysysTime,120) as 审核日期,convert(varchar(10),dDate,120) as 单据日期 from " + tablename + " a "
+ @"left join _UserInfo u1 on a.dCreatesysPerson=u1.vchrUid left join _UserInfo u2 on a.dVerifysysPerson=u2.vchrUid 
left join Department d on a.cDepCode=d.cDepCode left join Vendor c on a.cVenCode=c.cVenCode left join Person p1 on a.cPersonCode=p1.PersonCode where ID=" + iID;
                DataTable dt = clsSQLCommond.ExecQuery(sSQL);
                if (dt.Rows.Count > 0)
                {
                    textEditID.EditValue = Convert.ToInt64(dt.Rows[0]["ID"]);;
                    textEdit单据号.EditValue = dt.Rows[0]["cPOCode"].ToString();

                    dateEdit单据日期.EditValue = ReturnDateTimeString(dt.Rows[0]["dDate"]);
                    dateEdit制单日期.EditValue = ReturnDateTimeString(dt.Rows[0]["dCreatesysTime"]);
                    dateEdit审核日期.EditValue = ReturnDateTimeString(dt.Rows[0]["dVerifysysTime"]);
                    dateEdit关闭日期.EditValue = ReturnDateTimeString(dt.Rows[0]["dClosesysTime"]);

                    textEdit备注.EditValue = dt.Rows[0]["cMemo"].ToString();
                    textEdit制单人.EditValue = dt.Rows[0]["dCreatesysPerson"].ToString();
                    textEdit审核人.EditValue = dt.Rows[0]["dVerifysysPerson"].ToString();
                    textEdit关闭人.EditValue = dt.Rows[0]["dClosesysPerson"].ToString();

                    buttonEdit供应商.EditValue = dt.Rows[0]["cVenCode"].ToString();
                    buttonEdit业务员.EditValue = dt.Rows[0]["cPersonCode"].ToString();
                    buttonEdit部门.EditValue = dt.Rows[0]["cDepCode"].ToString();
                   
                    lookUpEdit采购类型.EditValue = dt.Rows[0]["cPTCode"].ToString();

                    sSQL = @"select a.*, 'edit' as iSave,cast(null as decimal(16,6)) as 引用量,cast(a.iQuantity as decimal(16,6)) as 历史数量 ,i.cInvName
                    from " + tablenames + "  a left join Inventory i on a.cInvCode=i.cInvCode where ID=" + iID + " order by iRowNo";

                    dtBingGrid = clsSQLCommond.ExecQuery(sSQL);
                    gridControl1.DataSource = dtBingGrid;

                    gridView1.FocusedRowHandle = iFocRow;

                    base.dsPrint.Tables.Clear();
                    base.dsPrint.Tables.Add(dt.Copy());
                    base.dsPrint.Tables[0].TableName = "dtHead";

                    base.dsPrint.Tables.Add(dtBingGrid.Copy());
                    base.dsPrint.Tables[1].TableName = "dtGrid";

                    gridView1.FocusedRowHandle = iFocRow;
                    gridView1.AddNewRow();
                    SetEnabled(false);

                }
                else
                {
                    GetNull();
                    SetEnabled(false);
                }
            }
            else
            {
                GetNull();
                SetEnabled(false);
            }
        }

        /// <summary>
        /// 下拉列表框
        /// </summary>
        private void SetLookUpEdit()
        {
            系统服务.LookUp.PurchaseType(lookUpEdit采购类型);
            系统服务.LookUp.Vendor(lookUpEdit供应商);
            系统服务.LookUp.Person(lookUpEdit业务员);
            系统服务.LookUp.Department(lookUpEdit部门);

            系统服务.LookUp.ColorNo(ItemLookUpEditM1);
            系统服务.LookUp.Dyelot(ItemLookUpEditM2);

            系统服务.LookUp.Inventory(ItemLookUpEdit物料名称);
            ItemLookUpEdit物料名称.Properties.DisplayMember = "cInvName";
            系统服务.LookUp.Inventory(ItemLookUpEdit物料规格);
            ItemLookUpEdit物料规格.Properties.DisplayMember = "cInvStd";
            系统服务.LookUp.Inventory(ItemLookUpEdit物料代码);
            ItemLookUpEdit物料规格.Properties.DisplayMember = "cInvAddCode";
            系统服务.LookUp.InventoryVenCode(ItemLookUpEdit供应商物料编码);
        }

        private void SetEnabled(bool b)
        {
            dateEdit单据日期.Enabled = b;
            dateEdit制单日期.Enabled = false;
            dateEdit审核日期.Enabled = false;
            dateEdit关闭日期.Enabled = false;

            textEdit单据号.Enabled = false;
            textEdit备注.Enabled = b;
            textEdit制单人.Enabled = false;
            textEdit审核人.Enabled = false;
            textEdit关闭人.Enabled = false;

            lookUpEdit供应商.Enabled = false;
            lookUpEdit部门.Enabled = false;
            lookUpEdit业务员.Enabled = false;

            buttonEdit业务员.Enabled = b;
            buttonEdit部门.Enabled = b;
            buttonEdit供应商.Enabled = b;
            lookUpEdit采购类型.Enabled = b;
            gridView1.OptionsBehavior.Editable = b;

            if (b == false)
            {
                isChange = "N";
            }
            else
            {
                isChange = "";
            }
        }

        private void GetNull()
        {
            dateEdit单据日期.EditValue = DBNull.Value;
            dateEdit制单日期.EditValue = DBNull.Value;
            dateEdit审核日期.EditValue = DBNull.Value;
            dateEdit关闭日期.EditValue = DBNull.Value;

            textEditID.EditValue = "";
            textEdit单据号.EditValue = "";
            textEdit备注.EditValue = "";
            textEdit制单人.EditValue = "";
            textEdit审核人.EditValue = "";
            textEdit关闭人.EditValue = "";

            buttonEdit业务员.EditValue = "";
            buttonEdit部门.EditValue = "";
            buttonEdit供应商.EditValue = "";
            lookUpEdit采购类型.EditValue = "";

            gridControl1.DataSource = null;
        }

        private void gridView1_CellValueChanged(object sender, DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs e)
        {
            int iRow = 0;
            if (gridView1.FocusedRowHandle >= 0)
                iRow = gridView1.FocusedRowHandle;

            if (gridView1.GetRowCellValue(iRow, gridCol序号).ToString().Trim() == "")
            {
                gridView1.SetRowCellValue(iRow, gridCol序号, iRow + 1);
            }

            string invcode = gridView1.GetRowCellValue(iRow, gridCol物料编码).ToString().Trim();

            if (e.Column == gridCol物料编码)
            {
                if (invcode != "")
                {
                    sSQL = "select * from Inventory where cInvCode = '" + invcode + "'";
                    DataTable dt = clsSQLCommond.ExecQuery(sSQL);
                    if (dt != null && dt.Rows.Count > 0)
                    {
                        gridView1.SetRowCellValue(iRow, gridCol供应商物料编码, gridView1.GetRowCellValue(iRow, gridCol物料编码).ToString().Trim());
                        gridView1.SetRowCellValue(iRow, gridCol税率, 17);

                        if (dt != null && dt.Rows.Count > 0 && ReturnDecimal(dt.Rows[0]["换算率"]) != 0)
                        {
                            gridView1.SetRowCellValue(iRow, gridCol换算率, ReturnDecimal(dt.Rows[0]["换算率"]));
                        }
                        else
                        {
                            gridView1.SetRowCellValue(iRow, gridCol换算率, null);
                        }
                    }
                    else
                    {
                        gridView1.SetRowCellValue(iRow, gridCol物料编码, DBNull.Value);
                    }

                    if (lookUpEdit供应商.EditValue != null && lookUpEdit供应商.EditValue.ToString().Trim() != "")
                    {
                        string sVenCode = lookUpEdit供应商.EditValue.ToString().Trim();
                        sSQL = "select top 1 b.iUnitPrice from dbo.PO_POMain a inner join dbo.PO_PODetails b on a.id = b.id " +
                                "where b.cInvCode  = '" + invcode + "' and cVenCode = '" + sVenCode + "' " +
                                "order by autoid desc";
                        decimal d含税单价 = ReturnDecimal(clsSQLCommond.ExecGetScalar(sSQL));
                        gridView1.SetRowCellValue(iRow, gridCol含税单价, d含税单价);
                    }
                }
                else
                {
                    gridView1.SetRowCellValue(iRow, gridCol物料名称, DBNull.Value);
                    gridView1.SetRowCellValue(iRow, gridCol物料规格, DBNull.Value);
                    gridView1.SetRowCellValue(iRow, gridCol供应商物料编码, DBNull.Value);
                }
            }
            

            #region 换算率
            if (e.Column == gridCol数量 || e.Column == gridCol换算率)
            {
                if (gridView1.GetRowCellValue(iRow, gridCol换算率).ToString().Trim() != "")
                {
                    decimal 换算率 = ReturnDecimal(gridView1.GetRowCellValue(iRow, gridCol换算率));
                    decimal 数量 = 0;
                    if (gridView1.GetRowCellValue(iRow, gridCol数量).ToString().Trim() != "")
                    {
                        数量 = ReturnDecimal(gridView1.GetRowCellValue(iRow, gridCol数量));
                    }
                    if (数量 == 0)
                    {
                        gridView1.SetRowCellValue(iRow, gridCol件数, null);
                    }
                    else
                    {
                        gridView1.SetRowCellValue(iRow, gridCol件数, ReturnDecimal(数量 * 换算率));
                    }
                    
                }
                else
                {
                    gridView1.SetRowCellValue(iRow, gridCol件数, null);
                }
            }
            #endregion

            if (e.Column == gridCol数量 || e.Column == gridCol件数 || e.Column == gridCol税率 || e.Column == gridCol税额 || e.Column == gridCol含税单价 || e.Column == gridCol含税金额
                || e.Column == gridCol无税单价 || e.Column == gridCol无税金额)
            {
                decimal 数量 = ReturnDecimal(gridView1.GetRowCellValue(iRow, gridCol数量));
                decimal 件数 = ReturnDecimal(gridView1.GetRowCellValue(iRow, gridCol件数));
                decimal 税率 = ReturnDecimal(gridView1.GetRowCellValue(iRow, gridCol税率)) / 100;
                decimal 税额 = ReturnDecimal(gridView1.GetRowCellValue(iRow, gridCol税额));
                decimal 换算率 = ReturnDecimal(gridView1.GetRowCellValue(iRow, gridCol换算率));
                decimal 含税单价 = ReturnDecimal(gridView1.GetRowCellValue(iRow, gridCol含税单价));
                decimal 含税金额 = ReturnDecimal(gridView1.GetRowCellValue(iRow, gridCol含税金额));
                decimal 无税单价 = ReturnDecimal(gridView1.GetRowCellValue(iRow, gridCol无税单价));
                decimal 无税金额 = ReturnDecimal(gridView1.GetRowCellValue(iRow, gridCol无税金额));

                #region 计算
                if (e.Column == gridCol数量)
                {
                    if (换算率 != 0)
                    {
                        gridView1.SetRowCellValue(iRow, gridCol件数, ReturnDecimal(数量 * 换算率));
                    }
                    else
                    {
                        gridView1.SetRowCellValue(iRow, gridCol件数, null);
                    }
                }
                if (e.Column == gridCol含税单价 || e.Column == gridCol数量 || e.Column == gridCol税率)
                {
                    无税单价 = ReturnDecimal(含税单价 / (1 + 税率));
                    含税金额 = ReturnDecimal(含税单价 * 数量);
                    无税金额 = ReturnDecimal(无税单价 * 数量);
                    税额 = 含税金额 - 无税金额;

                    gridView1.SetRowCellValue(iRow, gridCol无税单价, 无税单价);
                    gridView1.SetRowCellValue(iRow, gridCol无税金额, 无税金额);
                    gridView1.SetRowCellValue(iRow, gridCol含税金额, 含税金额);
                    gridView1.SetRowCellValue(iRow, gridCol税额, 税额);
                }
                if (e.Column == gridCol含税金额 && 数量 != 0)
                {
                    含税单价 = ReturnDecimal(含税金额 / 数量);
                }
                #endregion
            }

            if (e.Column == gridCol数量)
            {
                decimal 数量 = ReturnDecimal(gridView1.GetRowCellValue(iRow, gridCol数量));
                if (数量 <= 0)
                {
                    MessageBox.Show("数量必须大于0");
                    return;
                }

                decimal 引用量 = ReturnDecimal(gridView1.GetRowCellValue(iRow, gridCol引用量));
                if (数量 < 引用量)
                {
                    MessageBox.Show("引用量超出");
                    gridView1.SetRowCellValue(iRow, gridCol数量, gridView1.GetRowCellValue(iRow, gridCol历史数量));
                }
            }

            #region M1
            if (e.Column == gridM1)
            {
                string invocde = gridView1.GetRowCellValue(iRow, gridCol物料编码).ToString().Trim();
                string M1 = gridView1.GetRowCellValue(iRow, gridM1).ToString().Trim();
                if (invocde != "" && M1 != "")
                {
                    bool b = false;
                    sSQL = "select M1 from Inventory where cInvCode='" + invocde + "'";
                    DataTable dts = clsSQLCommond.ExecQuery(sSQL);
                    if (dts.Rows.Count > 0)
                    {
                        string per = dts.Rows[0]["M1"].ToString();
                        per = "," + per.Replace(", ", ",") + ",";
                        if (per.IndexOf("," + M1 + ",") >= 0)
                        {
                            b = true;
                        }
                    }
                    if (b == false)
                    {
                        MessageBox.Show(invocde + "无此色号");
                        if (gridView1.GetRowCellValue(iRow, gridColM1).ToString().Trim() != "")
                        {
                            gridView1.SetRowCellValue(iRow, gridColM1, "");
                        }
                        if (gridView1.GetRowCellValue(iRow, gridM1).ToString().Trim() != "")
                        {
                            gridView1.SetRowCellValue(iRow, gridM1, "");
                        }
                    }
                }
                else
                {
                    if (invocde == "")
                    {
                        MessageBox.Show(invocde + "未选择存货");
                    }
                    if (gridView1.GetRowCellValue(iRow, gridColM1).ToString().Trim() != "")
                    {
                        gridView1.SetRowCellValue(iRow, gridColM1, "");
                    }
                    if (gridView1.GetRowCellValue(iRow, gridM1).ToString().Trim() != "")
                    {
                        gridView1.SetRowCellValue(iRow, gridM1, "");
                    }
                }
            }
            #endregion

            #region
            if (e.Column != gridColiSave && e.Column != gridCol序号 && gridView1.GetRowCellDisplayText(iRow, gridColiSave).ToString().Trim() == "")
            {
                gridView1.SetRowCellValue(iRow, gridColiSave, "add");
            }
            if (e.Column != gridColiSave && e.Column != gridCol序号 && gridView1.GetRowCellDisplayText(iRow, gridColiSave).ToString().Trim() == "edit")
            {
                gridView1.SetRowCellValue(iRow, gridColiSave, "update");
            }
            if (e.Column == gridCol物料编码 && e.RowHandle == gridView1.RowCount - 1 && gridView1.GetRowCellDisplayText(iRow, gridCol物料编码).ToString().Trim() != "")
            {
                gridView1.AddNewRow();
                gridView1.FocusedRowHandle = gridView1.RowCount - 1;
                gridView1.FocusedRowHandle = gridView1.RowCount - 2;
            }
            #endregion
        }

        private void buttonEdit供应商_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            系统服务.Frm参照 frm = new 系统服务.Frm参照(10);
            if (DialogResult.OK == frm.ShowDialog())
            {
                buttonEdit供应商.EditValue = frm.sID;
                frm.Enabled = true;
            }
        }

        private void buttonEdit业务员_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            系统服务.Frm参照 frm = new 系统服务.Frm参照(2);
            if (DialogResult.OK == frm.ShowDialog())
            {
                buttonEdit业务员.EditValue = frm.sID;
                frm.Enabled = true;
            }
        }

        private void buttonEdit部门_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            系统服务.Frm参照 frm = new 系统服务.Frm参照(3);
            if (DialogResult.OK == frm.ShowDialog())
            {
                buttonEdit部门.EditValue = frm.sID;
                frm.Enabled = true;
            }
        }

        private void buttonEdit业务员_EditValueChanged(object sender, EventArgs e)
        {
            if (buttonEdit业务员.Text.Trim() != "")
            {
                lookUpEdit业务员.EditValue = buttonEdit业务员.Text.Trim();

                if (lookUpEdit业务员.Text.Trim() != "")
                {
                    DataTable dt = 系统服务.LookUp.PersonDepartment(buttonEdit业务员.Text.Trim());
                    if (dt != null && dt.Rows.Count > 0)
                    {
                        buttonEdit部门.EditValue = dt.Rows[0]["cDepCode"];
                    }
                }
            }
            else
                lookUpEdit业务员.EditValue = null;
        }


        private void buttonEdit业务员_Leave(object sender, EventArgs e)
        {
            if (buttonEdit业务员.Text.Trim() == "")
                return;
            if (lookUpEdit业务员.Text.Trim() == "")
            {
                buttonEdit业务员.Text = "";
                buttonEdit业务员.Focus();
            }
        }

        private void buttonEdit部门_EditValueChanged(object sender, EventArgs e)
        {
            if (buttonEdit部门.Text.Trim() != "")
                lookUpEdit部门.EditValue = buttonEdit部门.Text.Trim();
            else
                lookUpEdit部门.EditValue = null;
        }


        private void buttonEdit部门_Leave(object sender, EventArgs e)
        {
            if (buttonEdit部门.Text.Trim() == "")
                return;
            if (lookUpEdit部门.Text.Trim() == "")
            {
                buttonEdit部门.Text = "";
                buttonEdit部门.Focus();
            }
        }

        private void buttonEdit供应商_EditValueChanged(object sender, EventArgs e)
        {
            if (buttonEdit供应商.Text.Trim() != "")
            {
                lookUpEdit供应商.EditValue = buttonEdit供应商.Text.Trim();
                lookUpEdit采购类型.EditValue = "01";
            }
            else
            {
                lookUpEdit供应商.EditValue = null;
                lookUpEdit采购类型.EditValue = null;
            }
        }


        private void buttonEdit供应商_Leave(object sender, EventArgs e)
        {
            if (buttonEdit供应商.Text.Trim() == "")
                return;
            if (lookUpEdit供应商.Text.Trim() == "")
            {
                buttonEdit供应商.Text = "";
                buttonEdit供应商.Focus();
            }
        }

        private void ItemButtonEdit存货编码_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            int iRow = 0;
            if (gridView1.FocusedRowHandle > 0)
                iRow = gridView1.FocusedRowHandle;

            系统服务.Frm参照 frm = new 系统服务.Frm参照(1);
            if (DialogResult.OK == frm.ShowDialog())
            {
                gridView1.SetRowCellValue(iRow, gridCol物料编码, frm.sID);
                frm.Enabled = true;
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
                sSQL = "select  isnull(dCreatesysPerson,'') as 制单人,isnull(dVerifysysPerson,'') as 审核人,isnull(dClosesysPerson,'') as 关闭人 from " + tablename + " where ID= '" + textEditID.EditValue.ToString().Trim() + "'";
                DataTable dt = clsSQLCommond.ExecQuery(sSQL);
                if (dt == null || dt.Rows.Count < 1)
                    iReturn = 0;
                else
                {
                    if (dt.Rows[0]["制单人"].ToString().Trim() != "")
                    {
                        iReturn = 1;
                    }
                    if (dt.Rows[0]["审核人"].ToString().Trim() != "")
                    {
                        iReturn = 2;
                    }
                    if (dt.Rows[0]["关闭人"].ToString().Trim() != "")
                    {
                        iReturn = 3;
                    }
                }
            }
            catch (Exception ee)
            { }
            return iReturn;
        }

        /// <summary>
        /// 判断单据是否已经使用
        /// </summary>
        /// <param name="sCode">单据号</param>
        /// <returns></returns>
        private int iCodeUsed(string sCode)
        {
            int iReturn = -1;
            try
            {
                sSQL = "select count(1) from dbo.PO_POMain a inner join dbo.PO_PODetails b on a.ID = b.ID inner join dbo.RdRecords01 c on c.POAutoID = b.AutoID " +
                       "where a.cPOCode = '" + sCode + "'";
                iReturn = Convert.ToInt32(clsSQLCommond.ExecGetScalar(sSQL));
            }
            catch (Exception ee)
            { }
            return iReturn;
        }

        /// <summary>
        /// 判断单据是否已经使用
        /// </summary>
        /// <param name="sCode">子表ID</param>
        /// <returns></returns>
        private decimal iCodeUsed(long AutoID)
        {
            decimal iReturn = -1;
            try
            {
                sSQL = "select isnull(sum(iQuantity),0) as iQty from dbo.RdRecords01 where RdAutoID = '" + AutoID + "'";
                iReturn = ReturnDecimal(clsSQLCommond.ExecGetScalar(sSQL));
            }
            catch (Exception ee)
            { }
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

        private void ItemButtonEditM1_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            int iRow = 0;
            for (int i = 0; i < gridView1.RowCount; i++)
            {
                if (gridView1.IsRowSelected(i))
                {
                    iRow = i;
                }
            }
            string invocde = gridView1.GetRowCellValue(iRow, gridCol物料编码).ToString().Trim();
            系统服务.Frm参照 frm = new 系统服务.Frm参照(21, invocde);
            if (DialogResult.OK == frm.ShowDialog())
            {
                gridView1.SetRowCellValue(iRow, gridColM1, frm.sID);
                frm.Enabled = true;
            }
        }

        private void ItemButtonEditM2_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            int iRow = 0;
            for (int i = 0; i < gridView1.RowCount; i++)
            {
                if (gridView1.IsRowSelected(i))
                {
                    iRow = i;
                }
            }
            string invocde = gridView1.GetRowCellValue(iRow, gridCol物料编码).ToString().Trim();
            系统服务.Frm参照 frm = new 系统服务.Frm参照(22, invocde);
            if (DialogResult.OK == frm.ShowDialog())
            {
                gridView1.SetRowCellValue(iRow, gridColM2, frm.sID);
                frm.Enabled = true;
            }
        }
    }
}
