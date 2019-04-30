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
    public partial class Frm导入库存单据 : FrameBaseFunction.FrmBaseInfo
    {

        public Frm导入库存单据()
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


        protected override void BtnClick(string sBtnName, string sBtnText)
        {
            try
            {
                switch (sBtnName.ToLower())
                {        
                    case "save":
                        btnSave();
                        break;
                    case "sel":
                        btnSel();
                        break;
                    case "edit":
                        btnEdit();
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

        private void btnEdit()
        {
            try
            {
                gridView1.FocusedRowHandle -= 1;
                gridView1.FocusedRowHandle += 1;
            }
            catch { }

            try
            {
                string sErr = "";
                int iCount = 0;
                SqlConnection conn = new SqlConnection(FrameBaseFunction.ClsBaseDataInfo.sConnString);
                conn.Open();
                //启用事务
                SqlTransaction tran = conn.BeginTransaction();

                try
                {
                    sSQL = "SELECT * FROM dbo.InventoryClass WHERE bInvCEnd = 1";
                    DataTable dtInvClass = DbHelperSQL.ExecuteDataset(tran, CommandType.Text, sSQL).Tables[0];

                    #region 导入存货档案
                    for (int i = 0; i < gridView1.RowCount; i++)
                    {
                        bool b = Convert.ToBoolean(gridView1.GetRowCellValue(i, gridColchoose));
                        if (!b)
                            continue;

                        if (gridView1.GetRowCellValue(i, gridCol單號).ToString().Trim() == "合计")
                            continue;


                        string sInvCode = gridView1.GetRowCellValue(i, gridCol物資代號).ToString().Trim();
                        if (sInvCode == "")
                            continue;

                        sSQL = @"
select cInvCode from Inventory where cInvCode = 'aaaaaa'
";
                        sSQL = sSQL.Replace("aaaaaa", sInvCode);

                        DataTable dt = DbHelperSQL.ExecuteDataset(tran, CommandType.Text, sSQL).Tables[0];
                        if (dt == null || dt.Rows.Count == 0)
                        {
                            Model.Inventory modelInv = new ImportDLL.Model.Inventory();
                            modelInv.cInvCode = gridView1.GetRowCellValue(i, gridCol物資代號).ToString().Trim();
                            modelInv.cInvName = gridView1.GetRowCellValue(i, gridCol名稱).ToString().Trim();
                            modelInv.cInvStd = gridView1.GetRowCellValue(i, gridCol規格).ToString().Trim();

                            //modelInv.cInvCCode = gridView1.GetRowCellValue(i, gridCol材料類別).ToString().Trim();
                            modelInv.cInvCCode = gridView1.GetRowCellValue(i, gridCol库位代号).ToString().Trim();
                            DataRow[] dr = dtInvClass.Select("cInvCCode = '" + modelInv.cInvCCode + "' or cInvCName = '" + modelInv.cInvCCode + "'");
                            if (dr.Length > 0)
                            {
                                modelInv.cInvCCode = dr[0]["cInvCCode"].ToString().Trim();
                            }
                            else
                            {
                                modelInv.cInvCCode = "99";
                            }

                            modelInv.cInvM_Unit = gridView1.GetRowCellValue(i, gridCol計量單位).ToString().Trim();
                            modelInv.bSale = true;
                            modelInv.bPurchase = true;
                            modelInv.bSelf = true;
                            modelInv.bComsume = true;
                            modelInv.bProducing = true;
                            modelInv.bService = false;
                            modelInv.bAccessary = false;
                            modelInv.iTaxRate = 17;
                            modelInv.iVolume = 0;
                            modelInv.bInvQuality = false;
                            modelInv.bInvBatch = false;
                            modelInv.bInvEntrust = false;
                            modelInv.bInvOverStock = false;
                            modelInv.dSDate = Convert.ToDateTime(DateTime.Now.ToString("yyyy-MM-dd"));
                            modelInv.bFree1 = false;
                            modelInv.bFree2 = false;
                            modelInv.bInvType = false;
                            DAL.Inventory dalInv = new ImportDLL.DAL.Inventory();
                            sSQL = dalInv.Add(modelInv);
                            iCount += DbHelperSQL.ExecuteNonQuery(tran, CommandType.Text, sSQL);
                        }
                    }
                    if (sErr.Length > 0)
                    {
                        throw new Exception(sErr);
                    }
                    if (iCount > 0)
                    {
                        tran.Commit();
                    }

                    #endregion
                    MessageBox.Show("导入成功");
                }
                catch (Exception ee)
                {
                    tran.Rollback();
                    throw new Exception(ee.Message);
                }
            }
            catch (Exception ee)
            {
                MsgBox("导入数据失败", ee.Message);
            }
        }
      
        /// <summary>
        /// 查询
        /// </summary>
        private void btnSel()
        {
            try
            {
                chkAll.Checked = false;
                OpenFileDialog openFileDialog = new OpenFileDialog();
                openFileDialog.Filter = "Excel2003|*.xls|Excel2010|*.xlsx|所有文件|*.*";
                openFileDialog.RestoreDirectory = true;
                openFileDialog.FilterIndex = 1;

                if (openFileDialog.ShowDialog() != DialogResult.OK)
                {
                    return;
                }

                string fName = openFileDialog.FileName;

                ClsExcel clsExcel = ClsExcel.Instance();

                string sSQL = "select * from [Sheet1$] order by 單號";
                DataTable dt = clsExcel.ExcelToDT(fName, sSQL, true);
                DataColumn dc = new DataColumn();
                dc.ColumnName = "choose";
                dc.DataType = System.Type.GetType("System.Boolean");
                dt.Columns.Add(dc);
                for (int i = dt.Rows.Count - 1; i >= 0; i--)
                {
                    if (dt.Rows[i]["單號"].ToString().Trim() == "合计")
                        dt.Rows.RemoveAt(i);
                }

                gridControl1.DataSource = dt;
                gridView1.Columns["choose"].Fixed = DevExpress.XtraGrid.Columns.FixedStyle.Left;
                gridView1.Columns["choose"].Caption = "选择";
                chkAll.Checked = false;

                gridView1.BestFitColumns();
            }
            catch (Exception ee)
            {
                MessageBox.Show(ee.Message);
            }
        }
      

        private void Frm_Load(object sender, EventArgs e)
        {
            try
            {
                dateEdit日期.DateTime = DateTime.Today;
            }
            catch (Exception ee)
            {
                MessageBox.Show(ee.Message);
            }
        }

        private void gridView1_CustomDrawRowIndicator(object sender, DevExpress.XtraGrid.Views.Grid.RowIndicatorCustomDrawEventArgs e)
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

        long lIDRD = 1;
        long lIDRDs = 1;
        long lIDDispatch = 1;
        long lIDDispatchs = 1;

        DataTable dtWareHouse = new DataTable();
        DataTable dtDepartment = new DataTable();
        DataTable dtVendor = new DataTable();
        DataTable dtCustomer = new DataTable();


        string sWarn = "";
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

            try
            {
                sWarn = "";

                DialogResult d = MessageBox.Show("确定导入单据么？", "提示", MessageBoxButtons.YesNo, MessageBoxIcon.Asterisk);
                if(d != DialogResult.Yes)
                    return;

                string sErr = "";
                int iCount = 0;
                SqlConnection conn = new SqlConnection(FrameBaseFunction.ClsBaseDataInfo.sConnString);
                conn.Open();
                //启用事务
                SqlTransaction tran = conn.BeginTransaction();

                try
                {
                    sSQL = "SELECT * FROM dbo.InventoryClass WHERE bInvCEnd = 1";
                    DataTable dtInvClass = DbHelperSQL.ExecuteDataset(tran, CommandType.Text, sSQL).Tables[0];

                    iCount = 0;
                    sErr = "";

                    DataTable dtGrid = (DataTable)gridControl1.DataSource;

                    sSQL = @"
SELECT * FROM MaxVouch WHERE cVouch = '收发主表ID'
";
                    DataTable dtID = DbHelperSQL.ExecuteDataset(tran, CommandType.Text, sSQL).Tables[0];
                    if (dtID != null && dtID.Rows.Count > 0)
                    {
                        lIDRD = ReturnInt(dtID.Rows[0]["cInCode"]);
                    }

                    sSQL = @"
SELECT * FROM MaxVouch WHERE cVouch = '收发子表ID'
";
                    dtID = DbHelperSQL.ExecuteDataset(tran, CommandType.Text, sSQL).Tables[0];
                    if (dtID != null && dtID.Rows.Count > 0)
                    {
                        lIDRDs = ReturnLong(dtID.Rows[0]["cInCode"]);
                    }


                    sSQL = @"
SELECT * FROM MaxVouch WHERE cVouch = 'Dispatch'
";
                    dtID = DbHelperSQL.ExecuteDataset(tran, CommandType.Text, sSQL).Tables[0];
                    if (dtID != null && dtID.Rows.Count > 0)
                    {
                        lIDDispatch = ReturnLong(dtID.Rows[0]["cInCode"]);
                    }


                    sSQL = @"
SELECT * FROM MaxVouch WHERE cVouch = 'Dispatchs'
";
                    dtID = DbHelperSQL.ExecuteDataset(tran, CommandType.Text, sSQL).Tables[0];
                    if (dtID != null && dtID.Rows.Count > 0)
                    {
                        lIDDispatchs = ReturnLong(dtID.Rows[0]["cInCode"]);
                    }

                    sSQL = "select * FROM Warehouse ";
                    dtWareHouse = DbHelperSQL.ExecuteDataset(tran, CommandType.Text, sSQL).Tables[0];

                    sSQL = "SELECT * FROM dbo.Department WHERE bDepEnd = 1 ORDER BY cDepCode ";
                    dtDepartment = DbHelperSQL.ExecuteDataset(tran, CommandType.Text, sSQL).Tables[0];

                    sSQL = "SELECT * FROM dbo.Vendor ORDER BY cVenCode ";
                    dtVendor = DbHelperSQL.ExecuteDataset(tran, CommandType.Text, sSQL).Tables[0];

                    sSQL = "SELECT * FROM dbo.Customer ORDER BY cCusCode ";
                    dtCustomer = DbHelperSQL.ExecuteDataset(tran, CommandType.Text, sSQL).Tables[0];

                    #region 导入采购入库单

                    DataView dv = dtGrid.Copy().DefaultView;
                    dv.Sort = "單號 asc";
                    dv.RowFilter = "單據描述='采购收货单' and choose = 1";
                    DataTable dt1 = dv.ToTable();
                    if (dt1.Rows.Count > 0)
                    {
                        sErr = "";
                        iCount = CreateRD01(tran, dt1, out sErr);

                        if (sErr.Trim() != "")
                        {
                            throw new Exception("导入采购入库单失败:\n" + sErr);
                        }
                    }

                    #endregion

                    #region 导入红字采购入库单

                    dv = dtGrid.Copy().DefaultView;
                    dv.Sort = "單號 asc";
                    dv.RowFilter = "單據描述='采购退货单' and choose = 1";
                    dt1 = dv.ToTable();
                    if (dt1.Rows.Count > 0)
                    {
                        sErr = "";
                        iCount = CreateRD01Red(tran, dt1, out sErr);

                        if (sErr.Trim() != "")
                        {
                            throw new Exception("导入红字采购入库单失败:\n" + sErr);
                        }
                    }

                    #endregion


                    #region 导入材料出库单

                    dv = dtGrid.Copy().DefaultView;
                    dv.Sort = "單號 asc";
                    dv.RowFilter = "單據描述='生产领料单' and choose = 1";
                    dt1 = dv.ToTable();
                    if (dt1.Rows.Count > 0)
                    {
                        sErr = "";
                        iCount = CreateRD11(tran, dt1, out sErr);

                        if (sErr.Trim() != "")
                        {
                            throw new Exception("导入材料出库单失败:\n" + sErr);
                        }
                    }

                    #endregion

                    #region 导入红字材料出库单

                    dv = dtGrid.Copy().DefaultView;
                    dv.Sort = "單號 asc";
                    dv.RowFilter = "單據描述='生产退料单' and choose = 1";
                    dt1 = dv.ToTable();
                    if (dt1.Rows.Count > 0)
                    {
                        sErr = "";
                        iCount = CreateRD11Red(tran, dt1, out sErr);

                        if (sErr.Trim() != "")
                        {
                            throw new Exception("导入红字材料出库单失败:\n" + sErr);
                        }
                    }

                    #endregion


                    #region 导入产成品入库单

                    dv = dtGrid.Copy().DefaultView;
                    dv.Sort = "單號 asc";
                    dv.RowFilter = "單據描述='生产入库单' and choose = 1";
                    dt1 = dv.ToTable();
                    if (dt1.Rows.Count > 0)
                    {
                        sErr = "";
                        iCount = CreateRD10(tran, dt1, out sErr);

                        if (sErr.Trim() != "")
                        {
                            throw new Exception("导入产成品入库单失败:\n" + sErr);
                        }
                    }

                    #endregion



                    #region 导入销售发货单

                    dv = dtGrid.Copy().DefaultView;
                    dv.Sort = "單號 asc";
                    dv.RowFilter = "單據描述='销售发货单' and choose = 1";
                    dt1 = dv.ToTable();
                    if (dt1.Rows.Count > 0)
                    {
                        sErr = "";
                        iCount = CreateDispatchList(tran, dt1, out sErr);

                        if (sErr.Trim() != "")
                        {
                            throw new Exception("导入销售发货单失败:\n" + sErr);
                        }
                    }

                    #endregion


                    #region 导入销售退货单

                    dv = dtGrid.Copy().DefaultView;
                    dv.Sort = "單號 asc";
                    dv.RowFilter = "單據描述='销售退货单' and choose = 1";
                    dt1 = dv.ToTable();
                    if (dt1.Rows.Count > 0)
                    {
                        sErr = "";
                        iCount = CreateDispatchListRed(tran, dt1, out sErr);

                        if (sErr.Trim() != "")
                        {
                            throw new Exception("导入销售发货单失败:\n" + sErr);
                        }
                    }

                    #endregion

                    if (sWarn != "")
                    {
                        FrmMsgBox frm = new FrmMsgBox();
                        frm.richTextBox1.Text = sWarn;
                        DialogResult dWarn = frm.ShowDialog();
                        if (dWarn != DialogResult.OK)
                        {
                            throw new Exception(sWarn);
                        }
                    }

                    sSQL = "update MaxVouch set cInCode = aaaaaa + 1 WHERE cVouch = '收发主表ID'";
                    sSQL = sSQL.Replace("aaaaaa", lIDRD.ToString());
                    DbHelperSQL.ExecuteNonQuery(tran, CommandType.Text, sSQL);
                    sSQL = "update MaxVouch set cInCode = aaaaaa + 1 WHERE cVouch = '收发子表ID'";
                    sSQL = sSQL.Replace("aaaaaa", lIDRDs.ToString());
                    DbHelperSQL.ExecuteNonQuery(tran, CommandType.Text, sSQL);

                    sSQL = "update MaxVouch set cInCode = aaaaaa + 1 WHERE cVouch = 'Dispatch'";
                    sSQL = sSQL.Replace("aaaaaa", lIDDispatch.ToString());
                    DbHelperSQL.ExecuteNonQuery(tran, CommandType.Text, sSQL);
                    sSQL = "update MaxVouch set cInCode = aaaaaa + 1 WHERE cVouch = 'Dispatchs'";
                    sSQL = sSQL.Replace("aaaaaa", lIDDispatchs.ToString());
                    DbHelperSQL.ExecuteNonQuery(tran, CommandType.Text, sSQL);

                    sSQL = "EXEC [ProAdjustCurrentStock] aaaaaa,'bbbbbb'";
                    sSQL = sSQL.Replace("aaaaaa", dateEdit日期.DateTime.Year.ToString());
                    sSQL = sSQL.Replace("bbbbbb", FrameBaseFunction.ClsBaseDataInfo.sDataBaseName.Substring(7, 3));
                    DbHelperSQL.ExecuteNonQuery(tran, CommandType.Text, sSQL);

                    tran.Commit();

                    gridControl1.DataSource = null;
                    MessageBox.Show("导入成功");
                }
                catch (Exception ee)
                {
                    tran.Rollback();
                    throw new Exception(ee.Message);
                }
            }
            catch (Exception ee)
            {
                MsgBox("导入数据失败", ee.Message);
            }
        }

        /// <summary>
        /// 导入采购入库单
        /// </summary>
        /// <param name="tran"></param>
        /// <param name="dt"></param>
        /// <param name="sErr"></param>
        /// <returns></returns>
        private int CreateRD01(SqlTransaction tran, DataTable dt, out string sErr)
        {
            int iCount = 0;
            sErr = "";
            DataTable dtCode = new DataTable();
            DataColumn dc = new DataColumn();
            dc.ColumnName = "cCode";
            dtCode.Columns.Add(dc);
            dc = new DataColumn();
            dc.ColumnName = "cWhCode";
            dtCode.Columns.Add(dc);

            for (int i = 0; i < dt.Rows.Count; i++)
            {
                string s倉庫代號 = dt.Rows[i]["倉庫代號"].ToString().Trim();
                DataRow[] drWHCode = dtWareHouse.Select("cWhMemo like '%" + s倉庫代號 + "%'");
                if (drWHCode.Length != 1)
                {
                    sErr = sErr + " 仓库 " + s倉庫代號 + " 未设置\n";
                    continue;
                }
                string sWhCode = drWHCode[0]["cWhCode"].ToString().Trim();

                string sCode = dt.Rows[i]["單號"].ToString().Trim();
                DataRow[] drCode = dtCode.Select("cCode = '" + sCode + "' and cWhCode = '" + s倉庫代號 + "'");
                if (drCode.Length > 0)
                {
                    continue;
                }

                sSQL = "select cDefine1 as cCode,cWhCode  from Rdrecord where cDefine1 = '" + sCode + "' and cDefine2 = '" + s倉庫代號 + "'";
                DataTable dtTemp = DbHelperSQL.ExecuteDataset(tran, CommandType.Text, sSQL).Tables[0];
                if (dtTemp.Rows.Count > 0)
                {
                    sWarn = sWarn + "单据 " + sCode + "  仓库 " + sWhCode + "已存在\n";
                    continue;
                }

                DataRow dr = dtCode.NewRow();
                dr["cCode"] = sCode;
                dr["cWhCode"] = s倉庫代號;
                dtCode.Rows.Add(dr);


                Model.RdRecord modRD = new ImportDLL.Model.RdRecord();
                sSQL = @"
SELECT * FROM dbo.VoucherHistory WHERE CardNumber = '24' AND cSeed = 'aaaaaa'
";
                sSQL = sSQL.Replace("aaaaaa", drWHCode[0]["cWhCode"].ToString().Trim().Substring(0, 1));
                DataTable dtRdCode = DbHelperSQL.ExecuteDataset(tran, CommandType.Text, sSQL).Tables[0];
                long lCode = 0;
                if (dtRdCode != null && dtRdCode.Rows.Count > 0)
                {
                    lCode = ReturnLong(dtRdCode.Rows[0]["cNumber"]);
                }
                lCode += 1;
                sSQL = @"
update VoucherHistory set cNumber = bbbbbb where CardNumber = '24' AND cSeed = 'aaaaaa'
";
                sSQL = sSQL.Replace("aaaaaa", drWHCode[0]["cWhCode"].ToString().Trim().Substring(0, 1));
                sSQL = sSQL.Replace("bbbbbb", lCode.ToString());
                DbHelperSQL.ExecuteNonQuery(tran, CommandType.Text, sSQL);

                string sRdCode = lCode.ToString();
                while (sRdCode.Length < 5)
                {
                    sRdCode = "0" + sRdCode;
                }
                sRdCode = drWHCode[0]["cWhCode"].ToString().Trim().Substring(0, 1) + sRdCode;
                modRD.cCode = sRdCode;


                lIDRD += 1;
                modRD.ID = lIDRD;
                modRD.bRdFlag = 1;
                modRD.cVouchType = "01";
                modRD.cBusType = "普通采购";
                modRD.cSource = "采购";
                modRD.cMaker = FrameBaseFunction.ClsBaseDataInfo.sUserName;
                modRD.cMemo = "导入" + DateTime.Now.ToString("yyyyMMddHHmmss");
                modRD.cDefine1 = sCode;
                modRD.cDefine2 = s倉庫代號;

                modRD.cWhCode = sWhCode;
                modRD.dDate = Convert.ToDateTime(dt.Rows[i]["交易日期"]);
                if (modRD.dDate.Year != ReturnInt(dateEdit日期.DateTime.Year) || modRD.dDate.Month != ReturnInt(dateEdit日期.DateTime.Month))
                {
                    sErr = sErr + " 单据日期 " + dt.Rows[i]["交易日期"].ToString().Trim() + " 不在当前期间\n";
                    continue;
                }
                modRD.cRdCode = "1";
                modRD.cDepCode = "1";

                string sVenCode = dt.Rows[i]["供應商簡稱"].ToString().Trim();
                DataRow[] drVenCode = dtVendor.Select("cVenAbbName = '" + sVenCode + "'");
                if (drVenCode.Length == 0)
                {
                    sErr = sErr + " 供应商 " + sVenCode + " 不存在\n";
                    continue;
                }
                modRD.cVenCode = drVenCode[0]["cVenCode"].ToString().Trim();
                modRD.iNetLock = 0;
                modRD.dZQDate = modRD.dDate;
                DAL.RdRecord dalRD = new ImportDLL.DAL.RdRecord();
                sSQL = dalRD.Add(modRD);
                iCount += DbHelperSQL.ExecuteNonQuery(tran, CommandType.Text, sSQL);

                DataView dvRD = dt.DefaultView;
                dvRD.RowFilter = "單號 = '" + sCode + "' and 倉庫代號 = '" + s倉庫代號 + "'";
                DataTable dtRD = dvRD.ToTable();
                for (int j = 0; j < dtRD.Rows.Count; j++)
                {
                    Model.RdRecords modRDs = new ImportDLL.Model.RdRecords();

                    lIDRDs += 1;
                    modRDs.ID = lIDRD;
                    modRDs.AutoID = lIDRDs;
                    modRDs.cInvCode = dtRD.Rows[j]["物資代號"].ToString().Trim();
                    modRDs.iQuantity = ReturnDecimal(dtRD.Rows[j]["入库数量"]);
                    modRDs.iUnitCost = ReturnDecimal(dtRD.Rows[j]["单价"]);
                    modRDs.iPrice = ReturnDecimal(dtRD.Rows[j]["入库金额"]);
                    modRDs.iAPrice = ReturnDecimal(dtRD.Rows[j]["入库金额"]);
                    modRDs.iFlag = 0;
                    modRDs.iTax = 0;
                    modRDs.iSQuantity = 0;
                    modRDs.iSNum = 0;
                    modRDs.iMoney = 0;
                    modRDs.iSOutQuantity = 0;
                    modRDs.iSOutNum = 0;
                    modRDs.iFNum = 0;
                    modRDs.iFQuantity = 0;
                    modRDs.cDefine26 = 0;
                    modRDs.cDefine27 = 0;
                    modRDs.fACost = ReturnDecimal(dtRD.Rows[j]["单价"]);
                    modRDs.iSendQuantity = 0;
                    modRDs.iSendNum = 0;
                    modRDs.bDistribute = false;
                    modRDs.iTaxUnitPrice = ReturnDecimal(dtRD.Rows[j]["单价"]);
                    modRDs.iTaxPrice = ReturnDecimal(dtRD.Rows[j]["入库金额"]);
                    modRDs.iTaxRate = 0;

                    DAL.RdRecords dalRDs = new ImportDLL.DAL.RdRecords();
                    sSQL = dalRDs.Add(modRDs);
                    DbHelperSQL.ExecuteNonQuery(tran, CommandType.Text, sSQL);
                }
            }

            if (sErr.Length > 0)
                throw new Exception(sErr);

            return iCount;
        }



        /// <summary>
        /// 导入红字采购入库单
        /// </summary>
        /// <param name="tran"></param>
        /// <param name="dt"></param>
        /// <param name="sErr"></param>
        /// <returns></returns>
        private int CreateRD01Red(SqlTransaction tran, DataTable dt, out string sErr)
        {
            int iCount = 0;
            sErr = "";
            DataTable dtCode = new DataTable();
            DataColumn dc = new DataColumn();
            dc.ColumnName = "cCode";
            dtCode.Columns.Add(dc);
            dc = new DataColumn();
            dc.ColumnName = "cWhCode";
            dtCode.Columns.Add(dc);

            for (int i = 0; i < dt.Rows.Count; i++)
            {
                string s倉庫代號 = dt.Rows[i]["倉庫代號"].ToString().Trim();
                DataRow[] drWHCode = dtWareHouse.Select("cWhMemo like '%" + s倉庫代號 + "%'");
                if (drWHCode.Length != 1)
                {
                    sErr = sErr + " 仓库 " + s倉庫代號 + " 未设置\n";
                    continue;
                }
                string sWhCode = drWHCode[0]["cWhCode"].ToString().Trim();

                string sCode = dt.Rows[i]["單號"].ToString().Trim();
                DataRow[] drCode = dtCode.Select("cCode = '" + sCode + "' and cWhCode = '" + s倉庫代號 + "'");
                if (drCode.Length > 0)
                {
                    continue;
                }

                sSQL = "select cDefine1 as cCode,cWhCode,*  from Rdrecord where cDefine1 = '" + sCode + "' and cDefine2 = '" + s倉庫代號 + "'";
                DataTable dtTemp = DbHelperSQL.ExecuteDataset(tran, CommandType.Text, sSQL).Tables[0];
                if (dtTemp.Rows.Count > 0)
                {
                    sWarn = sWarn + "单据 " + sCode + "  仓库 " + sWhCode + "已存在\n";
                    continue;
                }

                DataRow dr = dtCode.NewRow();
                dr["cCode"] = sCode;
                dr["cWhCode"] = s倉庫代號;
                dtCode.Rows.Add(dr);

                Model.RdRecord modRD = new ImportDLL.Model.RdRecord();

               
                sSQL = @"
SELECT * FROM dbo.VoucherHistory WHERE CardNumber = '24' AND cSeed = 'aaaaaa'
";
                sSQL = sSQL.Replace("aaaaaa", drWHCode[0]["cWhCode"].ToString().Trim().Substring(0, 1));
                DataTable dtRdCode = DbHelperSQL.ExecuteDataset(tran, CommandType.Text, sSQL).Tables[0];
                long lCode = 0;
                if (dtRdCode != null && dtRdCode.Rows.Count > 0)
                {
                    lCode = ReturnLong(dtRdCode.Rows[0]["cNumber"]);
                }
                lCode += 1;
                sSQL = @"
update VoucherHistory set cNumber = bbbbbb where CardNumber = '24' AND cSeed = 'aaaaaa'
";
                sSQL = sSQL.Replace("aaaaaa", drWHCode[0]["cWhCode"].ToString().Trim().Substring(0, 1));
                sSQL = sSQL.Replace("bbbbbb", lCode.ToString());
                DbHelperSQL.ExecuteNonQuery(tran, CommandType.Text, sSQL);
                string sRdCode = lCode.ToString();
                while (sRdCode.Length < 5)
                {
                    sRdCode = "0" + sRdCode;
                }
                sRdCode = drWHCode[0]["cWhCode"].ToString().Trim().Substring(0, 1) + sRdCode;
                modRD.cCode = sRdCode;

                lIDRD += 1;
                modRD.ID = lIDRD;
                modRD.bRdFlag = 1;
                modRD.cVouchType = "01";
                modRD.cBusType = "普通采购";
                modRD.cSource = "采购";
                modRD.cMaker = FrameBaseFunction.ClsBaseDataInfo.sUserName;
                modRD.cMemo = "导入" + DateTime.Now.ToString("yyyyMMddHHmmss");
                modRD.cDefine1 = sCode;
                modRD.cDefine2 = s倉庫代號;

                modRD.cWhCode = drWHCode[0]["cWhCode"].ToString().Trim();
                modRD.dDate = Convert.ToDateTime(dt.Rows[i]["交易日期"]);
                if (modRD.dDate.Year != ReturnInt(dateEdit日期.DateTime.Year) || modRD.dDate.Month != ReturnInt(dateEdit日期.DateTime.Month))
                {
                    sErr = sErr + " 单据日期 " + dt.Rows[i]["交易日期"].ToString().Trim() + " 不在当前期间\n";
                    continue;
                }

                modRD.cRdCode = "1";
                modRD.cDepCode = "1";

                string sVenCode = dt.Rows[i]["供應商簡稱"].ToString().Trim();
                DataRow[] drVenCode = dtVendor.Select("cVenAbbName = '" + sVenCode + "'");
                if (drVenCode.Length == 0)
                {
                    sErr = sErr + " 供应商 " + sVenCode + " 不存在\n";
                    continue;
                }
                modRD.cVenCode = drVenCode[0]["cVenCode"].ToString().Trim();
                modRD.iNetLock = 0;
                modRD.dZQDate = modRD.dDate;
                DAL.RdRecord dalRD = new ImportDLL.DAL.RdRecord();
                sSQL = dalRD.Add(modRD);
                iCount += DbHelperSQL.ExecuteNonQuery(tran, CommandType.Text, sSQL);

                DataView dvRD = dt.DefaultView;
                dvRD.RowFilter = "單號 = '" + sCode + "'  and 倉庫代號 = '" + s倉庫代號 + "'";
                DataTable dtRD = dvRD.ToTable();
                for (int j = 0; j < dtRD.Rows.Count; j++)
                {
                    Model.RdRecords modRDs = new ImportDLL.Model.RdRecords();

                    lIDRDs += 1;
                    modRDs.ID = lIDRD;
                    modRDs.AutoID = lIDRDs;
                    modRDs.cInvCode = dtRD.Rows[j]["物資代號"].ToString().Trim();
                    modRDs.iQuantity = ReturnDecimal(dtRD.Rows[j]["入库数量"]);
                    modRDs.iUnitCost = ReturnDecimal(dtRD.Rows[j]["单价"]);
                    modRDs.iPrice = ReturnDecimal(dtRD.Rows[j]["入库金额"]);
                    modRDs.iAPrice = ReturnDecimal(dtRD.Rows[j]["入库金额"]);
                    modRDs.iFlag = 0;
                    modRDs.iTax = 0;
                    modRDs.iSQuantity = 0;
                    modRDs.iSNum = 0;
                    modRDs.iMoney = 0;
                    modRDs.iSOutQuantity = 0;
                    modRDs.iSOutNum = 0;
                    modRDs.iFNum = 0;
                    modRDs.iFQuantity = 0;
                    modRDs.cDefine26 = 0;
                    modRDs.cDefine27 = 0;
                    modRDs.fACost = ReturnDecimal(dtRD.Rows[j]["单价"]);
                    modRDs.iSendQuantity = 0;
                    modRDs.iSendNum = 0;
                    modRDs.bDistribute = false;
                    modRDs.iTaxUnitPrice = ReturnDecimal(dtRD.Rows[j]["单价"]);
                    modRDs.iTaxPrice = ReturnDecimal(dtRD.Rows[j]["入库金额"]);
                    modRDs.iTaxRate = 0;

                    DAL.RdRecords dalRDs = new ImportDLL.DAL.RdRecords();
                    sSQL = dalRDs.Add(modRDs);
                    DbHelperSQL.ExecuteNonQuery(tran, CommandType.Text, sSQL);
                }
            }

            if (sErr.Length > 0)
                throw new Exception(sErr);

            return iCount;
        }



        /// <summary>
        /// 导入材料出库单
        /// </summary>
        /// <param name="tran"></param>
        /// <param name="dt"></param>
        /// <param name="sErr"></param>
        /// <returns></returns>
        private int CreateRD11(SqlTransaction tran, DataTable dt, out string sErr)
        {
            int iCount = 0;
            sErr = "";
            DataTable dtCode = new DataTable();
            DataColumn dc = new DataColumn();
            dc.ColumnName = "cCode";
            dtCode.Columns.Add(dc);
            dc = new DataColumn();
            dc.ColumnName = "cWhCode";
            dtCode.Columns.Add(dc);

            for (int i = 0; i < dt.Rows.Count; i++)
            {
                string s倉庫代號 = dt.Rows[i]["倉庫代號"].ToString().Trim();
                DataRow[] drWHCode = dtWareHouse.Select("cWhMemo like '%" + s倉庫代號 + "%'");
                if (drWHCode.Length != 1)
                {
                    sErr = sErr + " 仓库 " + s倉庫代號 + " 未设置\n";
                    continue;
                }
                string sWhCode = drWHCode[0]["cWhCode"].ToString().Trim();

                string sCode = dt.Rows[i]["單號"].ToString().Trim();
                DataRow[] drCode = dtCode.Select("cCode = '" + sCode + "' and cWhCode = '" + s倉庫代號 + "'");
                if (drCode.Length > 0)
                {
                    continue;
                }

                sSQL = "select cDefine1 as cCode,cWhCode,*  from Rdrecord where cDefine1 = '" + sCode + "' and cDefine2 = '" + s倉庫代號 + "'";
                DataTable dtTemp = DbHelperSQL.ExecuteDataset(tran, CommandType.Text, sSQL).Tables[0];
                if (dtTemp.Rows.Count > 0)
                {
                    sWarn = sWarn + "单据 " + sCode + "  仓库 " + sWhCode + "已存在\n";
                    continue;
                }

                DataRow dr = dtCode.NewRow();
                dr["cCode"] = sCode;
                dr["cWhCode"] = s倉庫代號;
                dtCode.Rows.Add(dr);

                Model.RdRecord modRD = new ImportDLL.Model.RdRecord();


                sSQL = @"
SELECT * FROM dbo.VoucherHistory WHERE CardNumber = '0412'
";
                DataTable dtRdCode = DbHelperSQL.ExecuteDataset(tran, CommandType.Text, sSQL).Tables[0];
                long lCode = 0;
                if (dtRdCode != null && dtRdCode.Rows.Count > 0)
                {
                    lCode = ReturnLong(dtRdCode.Rows[0]["cNumber"]);
                }
                lCode += 1;
                sSQL = @"
update VoucherHistory set cNumber = bbbbbb where CardNumber = '0412'
";
                sSQL = sSQL.Replace("bbbbbb", lCode.ToString());
                DbHelperSQL.ExecuteNonQuery(tran, CommandType.Text, sSQL);
                string sRdCode = lCode.ToString();
                while (sRdCode.Length < 5)
                {
                    sRdCode = "0" + sRdCode;
                }
             
                modRD.cCode = drWHCode[0]["cWhCode"].ToString().Trim().Substring(0, 1) + sRdCode;

                lIDRD += 1;
                modRD.ID = lIDRD;
                modRD.bRdFlag = 0;
                modRD.cVouchType = "11";
                modRD.cBusType = "材料出库";
                modRD.cSource = "库存";
                modRD.cMaker = FrameBaseFunction.ClsBaseDataInfo.sUserName;
                modRD.cDefine1 = sCode;
                modRD.cDefine2 = s倉庫代號;

                modRD.cMemo = "导入" + DateTime.Now.ToString("yyyyMMddHHmmss");
                modRD.cWhCode = drWHCode[0]["cWhCode"].ToString().Trim();
                modRD.dDate = Convert.ToDateTime(dt.Rows[i]["交易日期"]);
                if (modRD.dDate.Year != ReturnInt(dateEdit日期.DateTime.Year) || modRD.dDate.Month != ReturnInt(dateEdit日期.DateTime.Month))
                {
                    sErr = sErr + " 单据日期 " + dt.Rows[i]["交易日期"].ToString().Trim() + " 不在当前期间\n";
                    continue;
                }
                modRD.cRdCode = "6";
                modRD.cDepCode = "3";

                modRD.iNetLock = 0;
                modRD.dZQDate = modRD.dDate;
                DAL.RdRecord dalRD = new ImportDLL.DAL.RdRecord();
                sSQL = dalRD.Add(modRD);
                iCount += DbHelperSQL.ExecuteNonQuery(tran, CommandType.Text, sSQL);

                DataView dvRD = dt.DefaultView;
                dvRD.RowFilter = "單號 = '" + sCode + "' and 倉庫代號 = '" + s倉庫代號 + "'";
                DataTable dtRD = dvRD.ToTable();
                for (int j = 0; j < dtRD.Rows.Count; j++)
                {
                    Model.RdRecords modRDs = new ImportDLL.Model.RdRecords();

                    lIDRDs += 1;
                    modRDs.ID = lIDRD;
                    modRDs.AutoID = lIDRDs;
                    modRDs.cInvCode = dtRD.Rows[j]["物資代號"].ToString().Trim();
                    modRDs.iQuantity = ReturnDecimal(dtRD.Rows[j]["數量"]);

                    modRDs.iFlag = 0;
                    modRDs.iSQuantity = 0;
                    modRDs.iSNum = 0;
                    modRDs.iMoney = 0;
                    modRDs.iSOutQuantity = 0;
                    modRDs.iSOutNum = 0;
                    modRDs.iFNum = 0;
                    modRDs.iFQuantity = 0;
                    modRDs.cDefine26 = 0;
                    modRDs.cDefine27 = 0;
                    modRDs.iSendQuantity = 0;
                    modRDs.iSendNum = 0;
                    modRDs.bDistribute = false;
                    modRDs.iTaxRate = 0;
                    modRDs.cDefine22 = dtRD.Rows[j]["领料单备注"].ToString().Trim();

                    DAL.RdRecords dalRDs = new ImportDLL.DAL.RdRecords();
                    sSQL = dalRDs.Add(modRDs);
                    DbHelperSQL.ExecuteNonQuery(tran, CommandType.Text, sSQL);
                }
            }

            if (sErr.Length > 0)
                throw new Exception(sErr);

            return iCount;
        }

        /// <summary>
        /// 导入红字材料出库单
        /// </summary>
        /// <param name="tran"></param>
        /// <param name="dt"></param>
        /// <param name="sErr"></param>
        /// <returns></returns>
        private int CreateRD11Red(SqlTransaction tran, DataTable dt, out string sErr)
        {
            int iCount = 0;
            sErr = "";
            DataTable dtCode = new DataTable();
            DataColumn dc = new DataColumn();
            dc.ColumnName = "cCode";
            dtCode.Columns.Add(dc);
            dc = new DataColumn();
            dc.ColumnName = "cWhCode";
            dtCode.Columns.Add(dc);

            for (int i = 0; i < dt.Rows.Count; i++)
            {
                string s倉庫代號 = dt.Rows[i]["倉庫代號"].ToString().Trim();
                DataRow[] drWHCode = dtWareHouse.Select("cWhMemo like '%" + s倉庫代號 + "%'");
                if (drWHCode.Length != 1)
                {
                    sErr = sErr + " 仓库 " + s倉庫代號 + " 未设置\n";
                    continue;
                }
                string sWhCode = drWHCode[0]["cWhCode"].ToString().Trim();

                string sCode = dt.Rows[i]["單號"].ToString().Trim();
                DataRow[] drCode = dtCode.Select("cCode = '" + sCode + "' and cWhCode = '" + s倉庫代號 + "'");
                if (drCode.Length > 0)
                {
                    continue;
                }

                sSQL = "select cDefine1 as cCode,cWhCode,*  from Rdrecord where cDefine1 = '" + sCode + "' and cDefine2 = '" + s倉庫代號 + "'";
                DataTable dtTemp = DbHelperSQL.ExecuteDataset(tran, CommandType.Text, sSQL).Tables[0];
                if (dtTemp.Rows.Count > 0)
                {
                    sWarn = sWarn + "单据 " + sCode + "  仓库 " + sWhCode + "已存在\n";
                    continue;
                }

                DataRow dr = dtCode.NewRow();
                dr["cCode"] = sCode;
                dr["cWhCode"] = s倉庫代號;
                dtCode.Rows.Add(dr);

                Model.RdRecord modRD = new ImportDLL.Model.RdRecord();

                sSQL = @"
SELECT * FROM dbo.VoucherHistory WHERE CardNumber = '0412'
";
                DataTable dtRdCode = DbHelperSQL.ExecuteDataset(tran, CommandType.Text, sSQL).Tables[0];
                long lCode = 0;
                if (dtRdCode != null && dtRdCode.Rows.Count > 0)
                {
                    lCode = ReturnLong(dtRdCode.Rows[0]["cNumber"]);
                }
                lCode += 1;
                sSQL = @"
update VoucherHistory set cNumber = bbbbbb where CardNumber = '0412'
";
                sSQL = sSQL.Replace("bbbbbb", lCode.ToString());
                DbHelperSQL.ExecuteNonQuery(tran, CommandType.Text, sSQL);
                string sRdCode = lCode.ToString();
                while (sRdCode.Length < 5)
                {
                    sRdCode = "0" + sRdCode;
                }
                //string sWHCode = dt.Rows[i]["倉庫代號"].ToString().Trim();
                //DataRow[] drWHCode = dtWareHouse.Select("cWhMemo like '%" + sWHCode + "%'");
                //if (drWHCode.Length != 1)
                //{
                //    sErr = sErr + " 仓库 " + sWHCode + " 未设置\n";
                //    continue;
                //}
                modRD.cCode = drWHCode[0]["cWhCode"].ToString().Trim().Substring(0, 1) + sRdCode;

                lIDRD += 1;
                modRD.ID = lIDRD;
                modRD.bRdFlag = 0;
                modRD.cVouchType = "11";
                modRD.cBusType = "材料出库";
                modRD.cSource = "库存";
                modRD.cMaker = FrameBaseFunction.ClsBaseDataInfo.sUserName;
                modRD.cDefine1 = sCode;
                modRD.cDefine2 = s倉庫代號;

                modRD.cMemo = "导入" + DateTime.Now.ToString("yyyyMMddHHmmss");
                modRD.cWhCode = drWHCode[0]["cWhCode"].ToString().Trim();
                modRD.dDate = Convert.ToDateTime(dt.Rows[i]["交易日期"]);
                if (modRD.dDate.Year != ReturnInt(dateEdit日期.DateTime.Year) || modRD.dDate.Month != ReturnInt(dateEdit日期.DateTime.Month))
                {
                    sErr = sErr + " 单据日期 " + dt.Rows[i]["交易日期"].ToString().Trim() + " 不在当前期间\n";
                    continue;
                }
                modRD.cRdCode = "6";
                modRD.cDepCode = "3";

                modRD.iNetLock = 0;
                modRD.dZQDate = modRD.dDate;
                DAL.RdRecord dalRD = new ImportDLL.DAL.RdRecord();
                sSQL = dalRD.Add(modRD);
                iCount += DbHelperSQL.ExecuteNonQuery(tran, CommandType.Text, sSQL);

                DataView dvRD = dt.DefaultView;
                dvRD.RowFilter = "單號 = '" + sCode + "' and 倉庫代號 = '" + s倉庫代號 + "'";
                DataTable dtRD = dvRD.ToTable();
                for (int j = 0; j < dtRD.Rows.Count; j++)
                {
                    Model.RdRecords modRDs = new ImportDLL.Model.RdRecords();

                    lIDRDs += 1;
                    modRDs.ID = lIDRD;
                    modRDs.AutoID = lIDRDs;
                    modRDs.cInvCode = dtRD.Rows[j]["物資代號"].ToString().Trim();
                    modRDs.iQuantity = ReturnDecimal(dtRD.Rows[j]["數量"]);

                    modRDs.iFlag = 0;
                    modRDs.iSQuantity = 0;
                    modRDs.iSNum = 0;
                    modRDs.iMoney = 0;
                    modRDs.iSOutQuantity = 0;
                    modRDs.iSOutNum = 0;
                    modRDs.iFNum = 0;
                    modRDs.iFQuantity = 0;
                    modRDs.cDefine26 = 0;
                    modRDs.cDefine27 = 0;
                    modRDs.iSendQuantity = 0;
                    modRDs.iSendNum = 0;
                    modRDs.bDistribute = false;
                    modRDs.iTaxRate = 0;
                    modRDs.cDefine22 = dtRD.Rows[j]["领料单备注"].ToString().Trim();

                    DAL.RdRecords dalRDs = new ImportDLL.DAL.RdRecords();
                    sSQL = dalRDs.Add(modRDs);
                    DbHelperSQL.ExecuteNonQuery(tran, CommandType.Text, sSQL);
                }
            }

            if (sErr.Length > 0)
                throw new Exception(sErr);

            return iCount;
        }



        /// <summary>
        /// 导入产成品入库单
        /// </summary>
        /// <param name="tran"></param>
        /// <param name="dt"></param>
        /// <param name="sErr"></param>
        /// <returns></returns>
        private int CreateRD10(SqlTransaction tran, DataTable dt, out string sErr)
        {
            int iCount = 0;
            sErr = "";
            DataTable dtCode = new DataTable();
            DataColumn dc = new DataColumn();
            dc.ColumnName = "cCode";
            dtCode.Columns.Add(dc);
            dc = new DataColumn();
            dc.ColumnName = "cWhCode";
            dtCode.Columns.Add(dc);

            for (int i = 0; i < dt.Rows.Count; i++)
            {
                string s倉庫代號 = dt.Rows[i]["倉庫代號"].ToString().Trim();
                DataRow[] drWHCode = dtWareHouse.Select("cWhMemo like '%" + s倉庫代號 + "%'");
                if (drWHCode.Length != 1)
                {
                    sErr = sErr + " 仓库 " + s倉庫代號 + " 未设置\n";
                    continue;
                }
                string sWhCode = drWHCode[0]["cWhCode"].ToString().Trim();

                string sCode = dt.Rows[i]["單號"].ToString().Trim();
                DataRow[] drCode = dtCode.Select("cCode = '" + sCode + "' and cWhCode = '" + s倉庫代號 + "'");
                if (drCode.Length > 0)
                {
                    continue;
                }

                sSQL = "select cDefine1 as cCode,cWhCode,*  from Rdrecord where cDefine1 = '" + sCode + "' and cDefine2 = '" + s倉庫代號 + "'";
                DataTable dtTemp = DbHelperSQL.ExecuteDataset(tran, CommandType.Text, sSQL).Tables[0];
                if (dtTemp.Rows.Count > 0)
                {
                    sWarn = sWarn + "单据 " + sCode + "  仓库 " + sWhCode + "已存在\n";
                    continue;
                }

                DataRow dr = dtCode.NewRow();
                dr["cCode"] = sCode;
                dr["cWhCode"] = s倉庫代號;
                dtCode.Rows.Add(dr);

                Model.RdRecord modRD = new ImportDLL.Model.RdRecord();
                sSQL = @"
SELECT * FROM dbo.VoucherHistory WHERE CardNumber = '0411'
";
                DataTable dtRdCode = DbHelperSQL.ExecuteDataset(tran, CommandType.Text, sSQL).Tables[0];
                long lCode = 0;
                if (dtRdCode != null && dtRdCode.Rows.Count > 0)
                {
                    lCode = ReturnLong(dtRdCode.Rows[0]["cNumber"]);
                }
                lCode += 1;
                sSQL = @"
update VoucherHistory set cNumber = bbbbbb where CardNumber = '0411'
";
                sSQL = sSQL.Replace("bbbbbb", lCode.ToString());
                DbHelperSQL.ExecuteNonQuery(tran, CommandType.Text, sSQL);
                string sRdCode = lCode.ToString();
                while (sRdCode.Length < 5)
                {
                    sRdCode = "0" + sRdCode;
                }
                //string sWHCode = dt.Rows[i]["倉庫代號"].ToString().Trim();
                //DataRow[] drWHCode = dtWareHouse.Select("cWhMemo like '%" + sWHCode + "%'");
                //if (drWHCode.Length != 1)
                //{
                //    sErr = sErr + " 仓库 " + sWHCode + " 未设置\n";
                //    continue;
                //}
                modRD.cCode = drWHCode[0]["cWhCode"].ToString().Trim().Substring(0, 1) + sRdCode;

                lIDRD += 1;
                modRD.ID = lIDRD;
                modRD.bRdFlag = 1;
                modRD.cVouchType = "10";
                modRD.cBusType = "产品入库";
                modRD.cSource = "库存";
                modRD.cMaker = FrameBaseFunction.ClsBaseDataInfo.sUserName;
                modRD.cMemo = "导入" + DateTime.Now.ToString("yyyyMMddHHmmss");
                modRD.cDefine1 = sCode;
                modRD.cDefine2 = s倉庫代號;

                modRD.cWhCode = drWHCode[0]["cWhCode"].ToString().Trim();
                modRD.dDate = Convert.ToDateTime(dt.Rows[i]["交易日期"]);
                if (modRD.dDate.Year != ReturnInt(dateEdit日期.DateTime.Year) || modRD.dDate.Month != ReturnInt(dateEdit日期.DateTime.Month))
                {
                    sErr = sErr + " 单据日期 " + dt.Rows[i]["交易日期"].ToString().Trim() + " 不在当前期间\n";
                    continue;
                }
                if (modRD.cWhCode == "成品")
                {
                    modRD.cRdCode = "4";
                }
                else
                {
                    modRD.cRdCode = "3";
                }
                modRD.cDepCode = "3";

                modRD.iNetLock = 0;
                modRD.dZQDate = modRD.dDate;
                DAL.RdRecord dalRD = new ImportDLL.DAL.RdRecord();
                sSQL = dalRD.Add(modRD);
                iCount += DbHelperSQL.ExecuteNonQuery(tran, CommandType.Text, sSQL);

                DataView dvRD = dt.DefaultView;
                dvRD.RowFilter = "單號 = '" + sCode + "' and 倉庫代號 = '" + s倉庫代號 + "'";
                DataTable dtRD = dvRD.ToTable();
                for (int j = 0; j < dtRD.Rows.Count; j++)
                {
                    Model.RdRecords modRDs = new ImportDLL.Model.RdRecords();

                    lIDRDs += 1;
                    modRDs.ID = lIDRD;
                    modRDs.AutoID = lIDRDs;
                    modRDs.cInvCode = dtRD.Rows[j]["物資代號"].ToString().Trim();
                    modRDs.iQuantity = ReturnDecimal(dtRD.Rows[j]["數量"]);

                    modRDs.iFlag = 0;
                    modRDs.iSQuantity = 0;
                    modRDs.iSNum = 0;
                    modRDs.iMoney = 0;
                    modRDs.iSOutQuantity = 0;
                    modRDs.iSOutNum = 0;
                    modRDs.iFNum = 0;
                    modRDs.iFQuantity = 0;
                    modRDs.cDefine26 = 0;
                    modRDs.cDefine27 = 0;
                    modRDs.iSendQuantity = 0;
                    modRDs.iSendNum = 0;
                    modRDs.bDistribute = false;
                    modRDs.iTaxRate = 0;

                    DAL.RdRecords dalRDs = new ImportDLL.DAL.RdRecords();
                    sSQL = dalRDs.Add(modRDs);
                    DbHelperSQL.ExecuteNonQuery(tran, CommandType.Text, sSQL);
                }
            }

            if (sErr.Length > 0)
                throw new Exception(sErr);

            return iCount;
        }



        /// <summary>
        /// 导入销售发货单
        /// </summary>
        /// <param name="tran"></param>
        /// <param name="dt"></param>
        /// <param name="sErr"></param>
        /// <returns></returns>
        private int CreateDispatchList(SqlTransaction tran, DataTable dt, out string sErr)
        {
            int iCount = 0;
            sErr = "";
            DataTable dtCode = new DataTable();
            DataColumn dc = new DataColumn();
            dc.ColumnName = "cCode";
            dtCode.Columns.Add(dc);

            for (int i = 0; i < dt.Rows.Count; i++)
            {
                string sCode = dt.Rows[i]["單號"].ToString().Trim();
                DataRow[] drCode = dtCode.Select("cCode = '" + sCode + "'");
                if (drCode.Length > 0)
                {
                    continue;
                }

                sSQL = "select cDLCode as cCode from DispatchList where cDefine1 = '" + sCode + "'";
                DataTable dtTemp = DbHelperSQL.ExecuteDataset(tran, CommandType.Text, sSQL).Tables[0];
                if (dtTemp.Rows.Count > 0)
                {
                    sWarn = sWarn + "单据 " + sCode + " 已存在\n";
                    continue;
                }

                DataRow dr = dtCode.NewRow();
                dr["cCode"] = sCode;
                dtCode.Rows.Add(dr);

                Model.DispatchList modDispatch = new ImportDLL.Model.DispatchList();
                sSQL = @"
SELECT * FROM dbo.VoucherHistory WHERE CardNumber = '01'
";
                DataTable dtRdCode = DbHelperSQL.ExecuteDataset(tran, CommandType.Text, sSQL).Tables[0];
                long lCode = 0;
                if (dtRdCode != null && dtRdCode.Rows.Count > 0)
                {
                    lCode = ReturnLong(dtRdCode.Rows[0]["cNumber"]);
                }
                lCode += 1;
                sSQL = @"
update VoucherHistory set cNumber = bbbbbb where CardNumber = '01'
";
                sSQL = sSQL.Replace("bbbbbb", lCode.ToString());
                DbHelperSQL.ExecuteNonQuery(tran, CommandType.Text, sSQL);
                string sRdCode = lCode.ToString();
                while (sRdCode.Length < 10)
                {
                    sRdCode = "0" + sRdCode;
                }

                modDispatch.cDLCode = sRdCode;

                lIDDispatch += 1;
                modDispatch.DLID = lIDDispatch;
              
                modDispatch.cVouchType = "05";
                modDispatch.cDefine1 = sCode;

                //成品仓 ： 1 ；其它仓库 ：2 
                string sWHCode = dt.Rows[i]["倉庫代號"].ToString().Trim();
                DataRow[] drWHCode = dtWareHouse.Select("cWhMemo like '%" + sWHCode + "%'");
                if (drWHCode.Length != 1)
                {
                    sErr = sErr + " 仓库 " + sWHCode + " 未设置\n";
                    continue;
                }
                if(drWHCode[0].ToString().Trim() == "1")
                    modDispatch.cSTCode = "1";
                else
                    modDispatch.cSTCode = "2";

                modDispatch.dDate = Convert.ToDateTime(dt.Rows[i]["交易日期"]);

                if (modDispatch.dDate.Year != ReturnInt(dateEdit日期.DateTime.Year) || modDispatch.dDate.Month != ReturnInt(dateEdit日期.DateTime.Month))
                {
                    sErr = sErr + " 单据日期 " + dt.Rows[i]["交易日期"].ToString().Trim() + " 不在当前期间\n";
                    continue;
                }

                modDispatch.cDepCode = "2";
                modDispatch.SBVID = 0;

                string sCusCode = dt.Rows[i]["客戶簡稱"].ToString().Trim();
                DataRow[] drCusCode = dtCustomer.Select("cCusAbbName = '" + sCusCode + "'");
                if (drCusCode.Length == 0)
                {
                    sErr = sErr + " 客户 " + sCusCode + " 不存在\n";
                    continue;
                }
                modDispatch.cCusCode = drCusCode[0]["cCusCode"].ToString().Trim();

                modDispatch.cMaker = FrameBaseFunction.ClsBaseDataInfo.sUserName;
                modDispatch.cMemo = "导入" + DateTime.Now.ToString("yyyyMMddHHmmss");
                modDispatch.cexch_name = "人民币";
                modDispatch.iExchRate = 1;
                modDispatch.iTaxRate = 17;
                modDispatch.bFirst = false;
                modDispatch.bReturnFlag = false;
                modDispatch.cMemo = "导入" + DateTime.Now.ToString("yyyyMMddHHmmss");
                modDispatch.bDisFlag = false;
                modDispatch.cDefine7 = 0;
                modDispatch.cMaker = FrameBaseFunction.ClsBaseDataInfo.sUserName;
                modDispatch.iNetLock = 0;
                modDispatch.iSale = 0;
                modDispatch.cCusName = drCusCode[0]["cCusName"].ToString().Trim();

                modDispatch.dZQDate = modDispatch.dDate;
                DAL.DispatchList dalDispatch = new ImportDLL.DAL.DispatchList();
                sSQL = dalDispatch.Add(modDispatch);
                iCount += DbHelperSQL.ExecuteNonQuery(tran, CommandType.Text, sSQL);

                DataView dvDispatch = dt.DefaultView;
                dvDispatch.RowFilter = "單號 = '" + sCode + "'";
                DataTable dtDispatch = dvDispatch.ToTable();
                for (int j = 0; j < dtDispatch.Rows.Count; j++)
                {
                    Model.DispatchLists modDispatchs = new ImportDLL.Model.DispatchLists();

                    lIDDispatchs += 1;
                    modDispatchs.DLID = lIDDispatch;
                    modDispatchs.AutoID = lIDDispatchs;
                    modDispatchs.iCorID = 0;
                    sWHCode = dtDispatch.Rows[j]["倉庫代號"].ToString().Trim();
                    drWHCode = dtWareHouse.Select("cWhMemo like '%" + sWHCode + "%'");
                    if (drWHCode.Length != 1)
                    {
                        sErr = sErr + " 仓库 " + sWHCode + " 未设置\n";
                        continue;
                    }
                    modDispatchs.cWhCode = drWHCode[0]["cWhCode"].ToString().Trim();
                    modDispatchs.cInvCode = dtDispatch.Rows[j]["物資代號"].ToString().Trim();
                    modDispatchs.iQuantity = ReturnDecimal(dtDispatch.Rows[j]["數量"]);
                    modDispatchs.iNum = 0;
                    modDispatchs.iQuotedPrice = 0;
                    modDispatchs.iUnitPrice = 0;
                    modDispatchs.iTaxUnitPrice = 0;
                    modDispatchs.iMoney = 0;
                    modDispatchs.iTax = 0;
                    modDispatchs.iSum = 0;
                    modDispatchs.iDisCount = 0;
                    modDispatchs.iNatUnitPrice = 0;
                    modDispatchs.iNatMoney = 0;
                    modDispatchs.iNatTax = 0;
                    modDispatchs.iNatSum = 0;
                    modDispatchs.iNatDisCount = 0;
                    modDispatchs.iSettleNum = 0;
                    modDispatchs.iSettleQuantity = 0;
                    modDispatchs.iBatch = 0;
                    modDispatchs.bSettleAll = false;
                    modDispatchs.iTB = 0;
                    modDispatchs.iSOsID = 0;
                    modDispatchs.iDLsID = lIDDispatchs;
                    modDispatchs.KL = 100;
                    modDispatchs.KL2 = 100;
                    modDispatchs.iTaxRate = 17;
                    modDispatchs.fOutQuantity = 0;
                    modDispatchs.fOutNum = 0;
                    modDispatchs.fSaleCost = 0;
                    modDispatchs.fSalePrice = 0;
                    modDispatchs.iInvExchRate = 0;

                    DAL.DispatchLists dalDispatchs = new ImportDLL.DAL.DispatchLists();
                    sSQL = dalDispatchs.Add(modDispatchs);
                    DbHelperSQL.ExecuteNonQuery(tran, CommandType.Text, sSQL);
                }
            }

            if (sErr.Length > 0)
                throw new Exception(sErr);

            return iCount;
        }

        /// <summary>
        /// 导入销售退货单
        /// </summary>
        /// <param name="tran"></param>
        /// <param name="dt"></param>
        /// <param name="sErr"></param>
        /// <returns></returns>
        private int CreateDispatchListRed(SqlTransaction tran, DataTable dt, out string sErr)
        {
            int iCount = 0;
            sErr = "";
            DataTable dtCode = new DataTable();
            DataColumn dc = new DataColumn();
            dc.ColumnName = "cCode";
            dtCode.Columns.Add(dc);

            for (int i = 0; i < dt.Rows.Count; i++)
            {
                string sCode = dt.Rows[i]["單號"].ToString().Trim();
                DataRow[] drCode = dtCode.Select("cCode = '" + sCode + "'");
                if (drCode.Length > 0)
                {
                    continue;
                }

                sSQL = "select cDLCode as cCode from DispatchList where cDefine1 = '" + sCode + "'";
                DataTable dtTemp = DbHelperSQL.ExecuteDataset(tran, CommandType.Text, sSQL).Tables[0];
                if (dtTemp.Rows.Count > 0)
                {
                    sWarn = sWarn + "单据 " + sCode + " 已存在\n";
                    continue;
                }

                DataRow dr = dtCode.NewRow();
                dr["cCode"] = sCode;
                dtCode.Rows.Add(dr);

                Model.DispatchList modDispatch = new ImportDLL.Model.DispatchList();
                sSQL = @"
SELECT * FROM dbo.VoucherHistory WHERE CardNumber = '01'
";
                DataTable dtRdCode = DbHelperSQL.ExecuteDataset(tran, CommandType.Text, sSQL).Tables[0];
                long lCode = 0;
                if (dtRdCode != null && dtRdCode.Rows.Count > 0)
                {
                    lCode = ReturnLong(dtRdCode.Rows[0]["cNumber"]);
                }
                lCode += 1;
                sSQL = @"
update VoucherHistory set cNumber = bbbbbb where CardNumber = '01'
";
                sSQL = sSQL.Replace("bbbbbb", lCode.ToString());
                DbHelperSQL.ExecuteNonQuery(tran, CommandType.Text, sSQL);
                string sRdCode = lCode.ToString();
                while (sRdCode.Length < 10)
                {
                    sRdCode = "0" + sRdCode;
                }

                modDispatch.cDLCode = sRdCode;
                lIDDispatch += 1;
                modDispatch.DLID = lIDDispatch;
                modDispatch.cVouchType = "05";
                modDispatch.dDate = Convert.ToDateTime(dt.Rows[i]["交易日期"]);
                modDispatch.cDefine1 = sCode;

                //成品仓 ： 1 ；其它仓库 ：2 
                string sWHCode = dt.Rows[i]["倉庫代號"].ToString().Trim();
                DataRow[] drWHCode = dtWareHouse.Select("cWhMemo like '%" + sWHCode + "%'");
                if (drWHCode.Length != 1)
                {
                    sErr = sErr + " 仓库 " + sWHCode + " 未设置\n";
                    continue;
                }
                if (drWHCode[0].ToString().Trim() == "1")
                    modDispatch.cSTCode = "1";
                else
                    modDispatch.cSTCode = "2";

                if (modDispatch.dDate.Year != ReturnInt(dateEdit日期.DateTime.Year) || modDispatch.dDate.Month != ReturnInt(dateEdit日期.DateTime.Month))
                {
                    sErr = sErr + " 单据日期 " + dt.Rows[i]["交易日期"].ToString().Trim() + " 不在当前期间\n";
                    continue;
                }

                modDispatch.cDepCode = "2";
                modDispatch.SBVID = 0;

                string sCusCode = dt.Rows[i]["客戶簡稱"].ToString().Trim();
                DataRow[] drCusCode = dtCustomer.Select("cCusAbbName = '" + sCusCode + "'");
                if (drCusCode.Length == 0)
                {
                    sErr = sErr + " 客户 " + sCusCode + " 不存在\n";
                    continue;
                }
                modDispatch.cCusCode = drCusCode[0]["cCusCode"].ToString().Trim();

                modDispatch.cMaker = FrameBaseFunction.ClsBaseDataInfo.sUserName;
                modDispatch.cMemo = "导入" + DateTime.Now.ToString("yyyyMMddHHmmss");
                modDispatch.cexch_name = "人民币";
                modDispatch.iExchRate = 1;
                modDispatch.iTaxRate = 17;
                modDispatch.bFirst = false;
                modDispatch.bReturnFlag = true;
                modDispatch.cMemo = "导入" + DateTime.Now.ToString("yyyyMMddHHmmss");
                modDispatch.bDisFlag = false;
                modDispatch.cDefine7 = 0;
                modDispatch.cMaker = FrameBaseFunction.ClsBaseDataInfo.sUserName;
                modDispatch.iNetLock = 0;
                modDispatch.iSale = 0;
                modDispatch.cCusName = drCusCode[0]["cCusName"].ToString().Trim();

                modDispatch.dZQDate = modDispatch.dDate;
                DAL.DispatchList dalDispatch = new ImportDLL.DAL.DispatchList();
                sSQL = dalDispatch.Add(modDispatch);
                iCount += DbHelperSQL.ExecuteNonQuery(tran, CommandType.Text, sSQL);

                DataView dvDispatch = dt.DefaultView;
                dvDispatch.RowFilter = "單號 = '" + sCode + "'";
                DataTable dtDispatch = dvDispatch.ToTable();
                for (int j = 0; j < dtDispatch.Rows.Count; j++)
                {
                    Model.DispatchLists modDispatchs = new ImportDLL.Model.DispatchLists();

                    lIDDispatchs += 1;
                    modDispatchs.DLID = lIDDispatch;
                    modDispatchs.AutoID = lIDDispatchs;
                    modDispatchs.iCorID = 0;
                    sWHCode = dtDispatch.Rows[j]["倉庫代號"].ToString().Trim();
                    drWHCode = dtWareHouse.Select("cWhMemo like '%" + sWHCode + "%'");
                    if (drWHCode.Length != 1)
                    {
                        sErr = sErr + " 仓库 " + sWHCode + " 未设置\n";
                        continue;
                    }
                    modDispatchs.cWhCode = drWHCode[0]["cWhCode"].ToString().Trim();
                    modDispatchs.cInvCode = dtDispatch.Rows[j]["物資代號"].ToString().Trim();
                    modDispatchs.iQuantity = ReturnDecimal(dtDispatch.Rows[j]["數量"]);
                    modDispatchs.iNum = 0;
                    modDispatchs.iQuotedPrice = 0;
                    modDispatchs.iUnitPrice = 0;
                    modDispatchs.iTaxUnitPrice = 0;
                    modDispatchs.iMoney = 0;
                    modDispatchs.iTax = 0;
                    modDispatchs.iSum = 0;
                    modDispatchs.iDisCount = 0;
                    modDispatchs.iNatUnitPrice = 0;
                    modDispatchs.iNatMoney = 0;
                    modDispatchs.iNatTax = 0;
                    modDispatchs.iNatSum = 0;
                    modDispatchs.iNatDisCount = 0;
                    modDispatchs.iSettleNum = 0;
                    modDispatchs.iSettleQuantity = 0;
                    modDispatchs.iBatch = 0;
                    modDispatchs.bSettleAll = false;
                    modDispatchs.iTB = 0;
                    modDispatchs.iSOsID = 0;
                    modDispatchs.iDLsID = lIDDispatchs;
                    modDispatchs.KL = 100;
                    modDispatchs.KL2 = 100;
                    modDispatchs.iTaxRate = 17;
                    modDispatchs.fOutQuantity = 0;
                    modDispatchs.fOutNum = 0;
                    modDispatchs.fSaleCost = 0;
                    modDispatchs.fSalePrice = 0;
                    modDispatchs.iInvExchRate = 0;

                    DAL.DispatchLists dalDispatchs = new ImportDLL.DAL.DispatchLists();
                    sSQL = dalDispatchs.Add(modDispatchs);
                    DbHelperSQL.ExecuteNonQuery(tran, CommandType.Text, sSQL);
                }
            }

            if (sErr.Length > 0)
                throw new Exception(sErr);

            return iCount;
        }

        ///// <summary>
        ///// 导入销售出库单
        ///// </summary>
        ///// <param name="tran"></param>
        ///// <param name="dt"></param>
        ///// <param name="sErr"></param>
        ///// <returns></returns>
        //private int CreateRD32(SqlTransaction tran, DataTable dt, out string sErr)
        //{
        //    int iCount = 0;
        //    sErr = "";
        //    DataTable dtCode = new DataTable();
        //    DataColumn dc = new DataColumn();
        //    dc.ColumnName = "cCode";
        //    dtCode.Columns.Add(dc);

        //    for (int i = 0; i < dt.Rows.Count; i++)
        //    {
        //        string sCode = dt.Rows[i]["單號"].ToString().Trim();
        //        DataRow[] drCode = dtCode.Select("cCode = '" + sCode + "'");
        //        if (drCode.Length > 0)
        //        {
        //            continue;
        //        }

        //        sSQL = "select cCode from Rdrecord where cCode = '" + sCode + "'";
        //        DataTable dtTemp = DbHelperSQL.ExecuteDataset(tran, CommandType.Text, sSQL).Tables[0];
        //        if (dtTemp.Rows.Count > 0)
        //        {
        //            sErr = sErr + "单据 " + sCode + " 已存在\n";
        //            continue;
        //        }

        //        DataRow dr = dtCode.NewRow();
        //        dr["cCode"] = sCode;
        //        dtCode.Rows.Add(dr);

        //        Model.RdRecord modRD = new ImportDLL.Model.RdRecord();
        //        lID += 1;
        //        modRD.ID = lID;
        //        modRD.bRdFlag = 0;
        //        modRD.cVouchType = "01";
        //        modRD.cBusType = "普通销售";
        //        modRD.cSource = "发货单";
        //        //modRD.cSource = "";
        //        modRD.cMaker = FrameBaseFunction.ClsBaseDataInfo.sUserName;
        //        modRD.cMemo = "导入" + DateTime.Now.ToString("yyyyMMddHHmmss");

        //        string sWHCode = dt.Rows[i]["倉庫代號"].ToString().Trim();
        //        DataRow[] drWHCode = dtWareHouse.Select("cWhMemo like '%" + sWHCode + "%'");
        //        if (drWHCode.Length != 1)
        //        {
        //            sErr = sErr + " 仓库 " + sWHCode + " 未设置\n";
        //            continue;
        //        }

        //        modRD.cWhCode = drWHCode[0]["cWhCode"].ToString().Trim();
        //        modRD.dDate = Convert.ToDateTime(dt.Rows[i]["交易日期"]);
        //        if (modRD.dDate.Year != ReturnInt(dateEdit日期.DateTime.Year) || modRD.dDate.Month != ReturnInt(dateEdit日期.DateTime.Month))
        //        {
        //            sErr = sErr + " 单据日期 " + dt.Rows[i]["交易日期"].ToString().Trim() + " 不在当前期间\n";
        //            continue;
        //        }
        //        modRD.cCode = sCode;
        //        modRD.cRdCode = "8";
        //        modRD.cDepCode = "2";

        //        string sCusCode = dt.Rows[i]["客戶簡稱"].ToString().Trim();
        //        DataRow[] drCusCode = dtVendor.Select("cCusAbbName = '" + sCusCode + "'");
        //        if (drCusCode.Length == 0)
        //        {
        //            sErr = sErr + " 客户 " + sCusCode + " 不存在\n";
        //            continue;
        //        }
        //        modRD.cCusCode = drCusCode[0]["cCusCode"].ToString().Trim();
        //        modRD.iNetLock = 0;
        //        modRD.dZQDate = modRD.dDate;
        //        DAL.RdRecord dalRD = new ImportDLL.DAL.RdRecord();
        //        sSQL = dalRD.Add(modRD);
        //        iCount += DbHelperSQL.ExecuteNonQuery(tran, CommandType.Text, sSQL);

        //        DataView dvRD = dt.DefaultView;
        //        dvRD.RowFilter = "單號 = '" + sCode + "'";
        //        DataTable dtRD = dvRD.ToTable();
        //        for (int j = 0; j < dtRD.Rows.Count; j++)
        //        {
        //            Model.RdRecords modRDs = new ImportDLL.Model.RdRecords();

        //            lIDs += 1;
        //            modRDs.ID = lID;
        //            modRDs.AutoID = lIDs;
        //            modRDs.cInvCode = dtRD.Rows[j]["物資代號"].ToString().Trim();
        //            modRDs.iQuantity = ReturnDecimal(dtRD.Rows[j]["入库数量"]);
        //            modRDs.iUnitCost = ReturnDecimal(dtRD.Rows[j]["单价"]);
        //            modRDs.iPrice = ReturnDecimal(dtRD.Rows[j]["入库金额"]);
        //            modRDs.iAPrice = ReturnDecimal(dtRD.Rows[j]["入库金额"]);
        //            modRDs.iFlag = 0;
        //            modRDs.iTax = 0;
        //            modRDs.iSQuantity = 0;
        //            modRDs.iSNum = 0;
        //            modRDs.iMoney = 0;
        //            modRDs.iSOutQuantity = 0;
        //            modRDs.iSOutNum = 0;
        //            modRDs.iFNum = 0;
        //            modRDs.iFQuantity = 0;
        //            modRDs.cDefine26 = 0;
        //            modRDs.cDefine27 = 0;
        //            modRDs.fACost = ReturnDecimal(dtRD.Rows[j]["单价"]);
        //            modRDs.iSendQuantity = 0;
        //            modRDs.iSendNum = 0;
        //            modRDs.bDistribute = false;
        //            modRDs.iTaxUnitPrice = ReturnDecimal(dtRD.Rows[j]["单价"]);
        //            modRDs.iTaxPrice = ReturnDecimal(dtRD.Rows[j]["入库金额"]);
        //            modRDs.iTaxRate = 0;

        //            DAL.RdRecords dalRDs = new ImportDLL.DAL.RdRecords();
        //            sSQL = dalRDs.Add(modRDs);
        //            DbHelperSQL.ExecuteNonQuery(tran, CommandType.Text, sSQL);
        //        }
        //    }

        //    if (sErr.Length > 0)
        //        throw new Exception(sErr);

        //    return iCount;
        //}



        private void chkAll_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                for (int i = 0; i < gridView1.RowCount; i++)
                {
                    gridView1.SetRowCellValue(i, gridColchoose, chkAll.Checked);
                }
            }
            catch { }
        }
    }
}
