using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraLayout;
using System.IO;
using System.Data.SqlClient;
using FrameBaseFunction;

namespace ImportDLL
{
    public partial class Frm制造票打印 : FrameBaseFunction.FrmFromModel
    {
        //TH.DAL.成本报表 DAL = new TH.DAL.成本报表();
        string sTable = "";


        public Frm制造票打印()
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
            gridView1.OptionsCustomization.AllowColumnMoving = true;
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

            for (int i = dt.Rows.Count - 1; i >= 0; i--)
            {
                if (!ReturnObjectToBool(dt.Rows[i]["bChoose"]))
                {
                    dt.Rows.RemoveAt(i);
                }
            }

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

            string sErr = "";
            base.dsPrint = new DataSet();
            int iCou = 0;
            SqlConnection conn = new SqlConnection(FrameBaseFunction.ClsBaseDataInfo.sConnString);
            conn.Open();
            //启用事务
            SqlTransaction tran = conn.BeginTransaction();
            try
            {

                long lMainId = -1;
                string sWorkCode = "";
                string sInvCode = "";
                string sSQL = "";
                DataTable dt = new DataTable();

                //每次只能选择一行数据
                int iFocRow = 0;
                for (int i = 0; i < gridView1.RowCount; i++)
                {
                    if (!ReturnObjectToBool(gridView1.GetRowCellValue(i, gridColbChoose)))
                    {
                        continue;
                    }
                    iFocRow = i;
                    break;
                }


                lMainId = ReturnObjectToLong(gridView1.GetRowCellValue(iFocRow, gridColMainId));
                sWorkCode = gridView1.GetRowCellValue(iFocRow, gridColcCode).ToString().Trim();
                sInvCode = gridView1.GetRowCellValue(iFocRow, gridColcInvCode).ToString().Trim();

                sSQL = "select * from 生产订单产品工序 where WorkDetailsID = " + lMainId.ToString().Trim();
                dt = DbHelperSQL.ExecuteDataset(tran, CommandType.Text, sSQL).Tables[0];
                if (dt == null || dt.Rows.Count == 0)
                {
                    throw new Exception("请先设定工序");
                }

                sSQL = "select * from BarCodeList where WorkCode = '" + sWorkCode + "' and WorkDetailsID = '" + lMainId + "' and cInvCode = '" + sInvCode + "' order by iID";
                dt = DbHelperSQL.ExecuteDataset(tran, CommandType.Text, sSQL).Tables[0];
                if (dt != null && dt.Rows.Count > 0)
                {
                    DialogResult d = MessageBox.Show("该订单已经打印过制造票,将调用历史记录打印", "提示", MessageBoxButtons.YesNo, MessageBoxIcon.Asterisk);
                    if (d != DialogResult.Yes)
                    {
                        throw new Exception("取消打印");
                    }
                }
                else
                {
                    long dQty = ReturnObjectToLong(gridView1.GetRowCellValue(iFocRow, gridColfQuantity));
                    long d装箱数 = ReturnObjectToLong(gridView1.GetRowCellValue(iFocRow, gridColcDefine26));

                    if (dQty <= 0)
                    {
                        sErr = sErr + "行" + (iFocRow + 1).ToString() + "数量不正确\n";
                    }
                    if (d装箱数 <= 0)
                    {
                        sErr = sErr + "行" + (iFocRow + 1).ToString() + "请设置装箱数\n";
                    }

                    string sDate = ReturnObjectToDatetime(FrameBaseFunction.ClsBaseDataInfo.sLogDate).ToString("yyMMdd");

                    #region 12位条码

                    sSQL = "select max(barCode) as MaxBarCode from dbo.BarCodeList where barcode like '" + sDate + "%' and len(BarCode) = 12 ";
                    dt = DbHelperSQL.ExecuteDataset(tran, CommandType.Text, sSQL).Tables[0];

                    string sMaxBarCode = sDate + "000000";
                    if (dt != null && dt.Rows.Count > 0 && dt.Rows[0]["MaxBarCode"].ToString().Trim() != "")
                    {
                        sMaxBarCode = dt.Rows[0]["MaxBarCode"].ToString().Trim().Substring(0, 12);
                    }

                    long iBoxCout = dQty / d装箱数;
                    long lBoxLast = dQty % d装箱数;

                    for (int j = 0; j < iBoxCout; j++)
                    {
                        TH.Model.BarCodeList model = new TH.Model.BarCodeList();
                        model.BarCode = (ReturnObjectToLong(sMaxBarCode) + 1 + j).ToString().Trim();
                        model.cInvCode = sInvCode;
                        model.iBoxQty = d装箱数;
                        model.iQty = d装箱数;
                        model.WorkQty = dQty;
                        model.WorkCode = sWorkCode;
                        model.WorkDetailsID = lMainId;

                        TH.DAL.BarCodeList dal = new TH.DAL.BarCodeList();
                        sSQL = dal.Add(model);
                        iCou = iCou + DbHelperSQL.ExecuteNonQuery(tran, CommandType.Text, sSQL);
                    }

                    if (lBoxLast > 0)
                    {
                        TH.Model.BarCodeList model = new TH.Model.BarCodeList();

                        model.BarCode = (ReturnObjectToLong(sMaxBarCode) + 1 + iBoxCout).ToString().Trim();
                        model.cInvCode = sInvCode;
                        model.iBoxQty = d装箱数;
                        model.iQty = lBoxLast;
                        model.WorkQty = dQty;
                        model.WorkCode = sWorkCode;
                        model.WorkDetailsID = lMainId;

                        TH.DAL.BarCodeList dal = new TH.DAL.BarCodeList();
                        sSQL = dal.Add(model);
                        iCou = iCou + DbHelperSQL.ExecuteNonQuery(tran, CommandType.Text, sSQL);
                    }

                    #endregion

                    #region 15位条码
                    sSQL = "select max(barCode) as MaxBarCode from dbo.BarCodeList where barcode like '" + sDate + "%' and len(BarCode) = 15 ";
                    dt = DbHelperSQL.ExecuteDataset(tran, CommandType.Text, sSQL).Tables[0];

                    sMaxBarCode = sDate + "000000000";
                    if (dt != null && dt.Rows.Count > 0 && dt.Rows[0]["MaxBarCode"].ToString().Trim() != "")
                    {
                        sMaxBarCode = dt.Rows[0]["MaxBarCode"].ToString().Trim().Substring(0, 15);
                    }

                    sSQL = @"
SELECT     iID, GUID工序, CreateUid, CreateDate, UpdataUid, UpdataDate, WorkCode, WorkDetailsID, WorkProcessNo, WorkProcessName, Remark, Remark2, 
                      Remark3, Remark4, Remark5, 装箱数, 分包, 分包数, 入库
FROM         生产订单产品工序
WHERE     (WorkDetailsID = 111111)  and isnull(分包,0) = 1
";
                    sSQL = sSQL.Replace("111111", lMainId.ToString());
                    DataTable dt分包 =  DbHelperSQL.ExecuteDataset(tran, CommandType.Text, sSQL).Tables[0];

                    //不需要分包
                    if (dt分包 != null && dt分包.Rows.Count > 0)
                    {
                        long d分包数 = ReturnObjectToLong(dt分包.Rows[0]["分包数"]);

                        long iBoxCout分包 = dQty / d分包数;
                        long lBoxLast分包 = dQty % d分包数;

                        for (int j = 0; j < iBoxCout分包; j++)
                        {
                            TH.Model.BarCodeList model = new TH.Model.BarCodeList();
                            model.BarCode = (ReturnObjectToLong(sMaxBarCode) + 1 + j).ToString().Trim();
                            model.cInvCode = sInvCode;
                            model.iBoxQty = d装箱数;
                            model.iQty = d分包数;
                            model.WorkQty = dQty;
                            model.WorkCode = sWorkCode;
                            model.WorkDetailsID = lMainId;

                            TH.DAL.BarCodeList dal = new TH.DAL.BarCodeList();
                            sSQL = dal.Add(model);
                            iCou = iCou + DbHelperSQL.ExecuteNonQuery(tran, CommandType.Text, sSQL);
                        }

                        if (lBoxLast分包 > 0)
                        {
                            TH.Model.BarCodeList model = new TH.Model.BarCodeList();

                            model.BarCode = (ReturnObjectToLong(sMaxBarCode) + 1 + iBoxCout分包).ToString().Trim();
                            model.cInvCode = sInvCode;
                            model.iBoxQty = d装箱数;
                            model.iQty = dQty - d分包数 * iBoxCout分包;
                            model.WorkQty = dQty;
                            model.WorkCode = sWorkCode;
                            model.WorkDetailsID = lMainId;

                            TH.DAL.BarCodeList dal = new TH.DAL.BarCodeList();
                            sSQL = dal.Add(model);
                            iCou = iCou + DbHelperSQL.ExecuteNonQuery(tran, CommandType.Text, sSQL);
                        }
                    }
                    #endregion
                }


                if (sWorkCode == "")
                {
                    throw new Exception("请选择正确的生产订单");
                }

                if (sErr.Length > 0)
                    throw new Exception(sErr);

                sSQL = "select *,case when len(isnull(BarCode,'')) = 15 then '分' end as 是否分包  from BarCodeList where WorkCode = '" + sWorkCode + "' and WorkDetailsID = '" + lMainId + "' and cInvCode = '" + sInvCode + "' order by iID";
                dt = DbHelperSQL.ExecuteDataset(tran, CommandType.Text, sSQL).Tables[0];

                base.dsPrint.Tables.Clear();
                DataTable dtGrid = dt.Copy();
                dtGrid.TableName = "dtGrid";

                base.dsPrint.Tables.Add(dtGrid);
                DataTable dtHead = dtBingHead.Copy();
                dtHead.TableName = "dtHead";
                base.dsPrint.Tables.Add(dtHead);

                if (iCou > 0)
                {
                    tran.Commit();
                }
                else
                {
                    tran.Rollback();
                }
            }
            catch (Exception error)
            {
                tran.Rollback();

                throw new Exception(error.Message);
            }
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


                base.toolStripMenuBtn.Items["Layout"].Text = "布局";

                DialogResult d = MessageBox.Show("是否保存?\n是：保存界面样式\n否：取消保存", "提示", MessageBoxButtons.YesNo, MessageBoxIcon.Asterisk);
                if (d == DialogResult.Yes)
                {
                    int iCou = 0;
                    SqlConnection conn = new SqlConnection(FrameBaseFunction.ClsBaseDataInfo.sConnString);
                    conn.Open();
                    //启用事务
                    SqlTransaction tran = conn.BeginTransaction();
                    try
                    {
                        sSQL = @"update [dbo].[列表设置] set [可见] = 0 where 库名 = '.' and [表名] = '111111'";
                        sSQL = sSQL.Replace("111111", sTable);
                        DbHelperSQL.ExecuteNonQuery(tran, CommandType.Text, sSQL);
                        for (int i = 0; i < gridView1.Columns.Count; i++)
                        {
                            int iW = gridView1.Columns[i].Width;
                            string sColName = gridView1.Columns[i].FieldName.Trim();
                            string sColText = gridView1.Columns[i].Caption.Trim();
                            int iIndex = gridView1.Columns[i].VisibleIndex;
                            bool bVis = gridView1.Columns[i].Visible;

                            sSQL = @"update [dbo].[列表设置] set [排序] = 444444,[可见] = 555555, [宽度] = " + iW + " where 库名 = '.' and [表名] = '111111' and [列名] = '222222' and [列标题] = '333333'";
                            sSQL = sSQL.Replace("111111", sTable);
                            sSQL = sSQL.Replace("222222", sColName);
                            sSQL = sSQL.Replace("333333", sColText);
                            sSQL = sSQL.Replace("444444", iIndex.ToString().Trim());
                            if (bVis)
                            {
                                sSQL = sSQL.Replace("555555", "1");
                            }
                            else
                            {
                                sSQL = sSQL.Replace("555555", "0");
                            }
                            iCou = iCou + DbHelperSQL.ExecuteNonQuery(tran, CommandType.Text, sSQL);

                        }
                        if (iCou > 0)
                        {
                            tran.Commit();
                        }
                        else
                        {
                            tran.Rollback();
                        }
                    }
                    catch (Exception error)
                    {
                        tran.Rollback();

                        throw new Exception(error.Message);
                    }
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
        }
        /// <summary>
        /// 删行
        /// </summary>
        private void btnDelRow()
        {

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
        /// 保存
        /// </summary>
        private void btnSave()
        {
            int iFocRow = gridView1.FocusedRowHandle;
            try
            {
                gridView1.FocusedRowHandle -= 1;
                gridView1.FocusedRowHandle += 1;
            }
            catch { }
            
            long lWorkIDs = 0;
            decimal dQty = 0;
            for (int i = 0; i < gridView1.RowCount; i++)
            {
                if (ReturnObjectToBool(gridView1.GetRowCellValue(i, gridColbChoose)))
                {
                    lWorkIDs = ReturnObjectToLong(gridView1.GetRowCellValue(i, gridColMainId));
                    dQty = ReturnObjectToDecimal(gridView1.GetRowCellValue(i, gridColcDefine26), 0);
                    break;
                }
            }
            if (lWorkIDs == 0)
            {
                throw new Exception("获得生产订单ID失败");
            }

            Frm生产订单产品工序 f = new Frm生产订单产品工序(lWorkIDs, dQty);
            f.StartPosition = FormStartPosition.CenterScreen;
            DialogResult d = f.ShowDialog();

            gridView1.FocusedRowHandle = iFocRow;
            GetGrid();

        }
        /// <summary>
        /// 撤销
        /// </summary>
        private void btnUnDo()
        {

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

        }
        /// <summary>
        /// 关闭
        /// </summary>
        private void btnClose()
        {

        }

        /// <summary>
        /// 变更
        /// </summary>
        private void btnAlter()
        {
            throw new NotImplementedException();
        }

        #endregion

        private void Frm_Load(object sender, EventArgs e)
        {
            try
            {
                dateEdit1.DateTime = ReturnObjectToDatetime(DateTime.Today.ToString("yyyy-MM-01"));
                dateEdit2.DateTime = DateTime.Today;

                getLookup();

                GetGrid();

            }
            catch (Exception ee)
            {
                MessageBox.Show("加载窗体失败\n" + ee.Message);
            }
        }

        private void getLookup()
        {
            string sSQL = "select cCode from @u8.PP_ProductPO order by id";
            DataTable dt = clsSQLCommond.ExecQuery(sSQL);
            DataRow dr = dt.NewRow();
            dt.Rows.InsertAt(dr, 0);
            lookUpEditcCode1.Properties.DataSource = dt;
            lookUpEditcCode2.Properties.DataSource = dt;
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



        private void GetGrid()
        {

            int iFocRow = gridView1.FocusedRowHandle;
            bool bChoose = ReturnObjectToBool(gridView1.GetRowCellValue(iFocRow, gridColbChoose));

            string sSQL = @"
select cast(0 as bit) as bChoose,a.cCode,a.dDate,b.cInvCode,i.cInvName,i.cInvStd
	,cast(b.fQuantity as decimal(16,2)) as fQuantity,b.dStartDate,b.dEndDate,cast(b.cDefine26 as int) as cDefine26,a.ID,b.MainId,a.cDepCode,dep.cDepName,a.cPersonCode,per.cPersonName,a.iState
from @u8.PP_ProductPO a inner join @u8.PP_POMain b on a.ID = b.ID
	left join @u8.Inventory I on I.cInvCode = b.cInvCode
    left join @u8.Department dep on dep.cDepCode = a.cDepCode
    left join @u8.Person per on per.cPersonCode = a.cPersonCode
where 1=1 and a.iState = 2
order by b.ID
";
            if (lookUpEditcCode1.Text.Trim() != "")
            {
                sSQL = sSQL.Replace("1=1", " 1=1 and a.cCode >= '" + lookUpEditcCode1.Text.Trim() + "'");
            }
            if (lookUpEditcCode2.Text.Trim() != "")
            {
                sSQL = sSQL.Replace("1=1", " 1=1 and a.cCode <= '" + lookUpEditcCode2.Text.Trim() + "'");
            }
            if (dateEdit1.Text.Trim() != "")
            {
                sSQL = sSQL.Replace("1=1", " 1=1 and a.dDate >= '" + dateEdit1.DateTime.ToString("yyyy-MM-dd") + "'");
            }
            if (dateEdit2.Text.Trim() != "")
            {
                sSQL = sSQL.Replace("1=1", " 1=1 and a.dDate <= '" + dateEdit2.DateTime.ToString("yyyy-MM-dd") + "'");
            }

            DataTable dt = clsSQLCommond.ExecQuery(sSQL);
            gridControl1.DataSource = dt;

            gridView1.FocusedRowHandle = iFocRow;
            gridView1.SetRowCellValue(iFocRow, gridColbChoose, bChoose);
        }

        private void gridView1_CellValueChanged(object sender, DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs e)
        {
            try
            {
                long d = ReturnObjectToLong(gridView1.GetRowCellValue(e.RowHandle, gridColcDefine26));
                if (d > 0 && e.Column != gridColbChoose)
                {
                    gridView1.SetRowCellValue(e.RowHandle, gridColbChoose, true);
                }
            }
            catch { }
        }

        private void gridView1_CellValueChanging(object sender, DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs e)
        {
            try
            {
                bool b = ReturnObjectToBool(gridView1.GetRowCellValue(e.RowHandle, gridColbChoose));
                if (!b)
                {
                    for (int i = 0; i < gridView1.RowCount; i++)
                    {
                        if (i == e.RowHandle)
                            continue;

                        gridView1.SetRowCellValue(i, gridColbChoose, false);
                    }
                }
            }
            catch { }
        }
    }
}
