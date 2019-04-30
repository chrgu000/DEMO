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
    public partial class Frm车间工序日报 : FrameBaseFunction.FrmFromModel
    {
        TH.DAL._GetBaseData DALGetBaseData = new TH.DAL._GetBaseData();

        DataTable dtGridInfo;

        string sTable = "";

        public Frm车间工序日报()
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
            gridView1.OptionsCustomization.AllowColumnMoving = true;
            gridView1.OptionsCustomization.AllowColumnMoving = false;
            //gridView1.OptionsCustomization.

            #endregion

            //sLayoutHeadPath = base.sProPath + "\\layout\\" + this.Text.Trim() + "Head.xml";
            //sLayoutGridPath = base.sProPath + "\\layout\\" + this.Text.Trim() + "Grid.xml";

            //if (File.Exists(sLayoutHeadPath))
            //    layoutControl1.RestoreLayoutFromXml(sLayoutHeadPath);

            //if (File.Exists(sLayoutGridPath))
            //{
            //    gridControl1.MainView.RestoreLayoutFromXml(sLayoutGridPath);
            //}

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
                    case "refresh":
                        btnRefresh();
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
                    case "save":
                        btnSave();
                        break;
                    case "layout":
                        btnLayout(sBtnText);
                        break;
                    case "close":
                        btnClose();
                        break;
                    case "open":
                        btnOpen();
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

        private void btnOpen()
        {
           
        }

        private void btnClose()
        {
          
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
        /// 刷新
        /// </summary>
        private void btnRefresh()
        {
            GetGrid(BaseFunction.BaseFunction.ReturnLong(buttonEdit生产订单iIDs.Text.Trim()));


            if (buttonEdit生产订单iIDs.Text.Trim() == "")
            {
                return;
            }
            if (lookUpEdit工序.EditValue == null || lookUpEdit工序.Text.Trim() == "")
            {
                return;
            }
            lookUpEdit工序_EditValueChanged(null, null);
        }
       
        /// <summary>
        /// 增行
        /// </summary>
        private void btnAddRow()
        {
            int iFocRow = gridView1.FocusedRowHandle;
            for (int i = 0; i < 10; i++)
            {
                gridView1.AddNewRow();
            }
            gridView1.FocusedRowHandle = iFocRow;
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
            //if (BaseFunction.BaseFunction.ReturnInt(buttonEdit生产订单iIDs.Text.Trim()) == 0)
            //{
            //    buttonEdit生产订单iIDs.Focus();
            //    throw new Exception("请选择生产订单");
            //}

            //if (lookUpEdit工序.EditValue == null || lookUpEdit工序.Text.Trim() == "")
            //{
            //    lookUpEdit工序.Focus();
            //    throw new Exception("请选择工序");
            //}

            //int iFocRow = gridView1.FocusedRowHandle;
            //if (iFocRow < 0)
            //    iFocRow = 0;

            //while (gridView1.RowCount < 100)
            //{
            //    gridView1.AddNewRow();
            //}

            //gridView1.FocusedRowHandle = iFocRow;

            //dateEdit1.Enabled = true;
            //gridView1.OptionsBehavior.Editable = true;
        }
        /// <summary>
        /// 删除
        /// </summary>
        private void btnDel()
        {
            try
            {
                gridView1.FocusedRowHandle -= 1;
                gridView1.FocusedRowHandle += 1;
            }
            catch { }

            DialogResult d = MessageBox.Show("确定删除选定的项么？", "提示", MessageBoxButtons.YesNo, MessageBoxIcon.Asterisk);
            if (d != DialogResult.Yes)
                return;

            try
            {
                sSQL = @"
delete [车间工序日报]
where 生产订单ID = aaaaaa and 工序 = 'bbbbbb' 
";
                sSQL = sSQL.Replace("aaaaaa", buttonEdit生产订单iIDs.Text.Trim());
                sSQL = sSQL.Replace("bbbbbb", lookUpEdit工序.EditValue.ToString().Trim());

                DbHelperSQL.ExecuteSql(sSQL);

                btnRefresh();
            }
            catch (Exception ee)
            {
                MsgBox("删除失败", ee.Message);
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

            try
            {
                if (gridView1.RowCount == 0)
                {
                    throw new Exception("请登记单据");
                }

                string sErr = "";
                int iCou = 0;
                if (BaseFunction.BaseFunction.ReturnInt(buttonEdit生产订单iIDs.Text.Trim()) == 0)
                {
                    buttonEdit生产订单iIDs.Focus();
                    throw new Exception("请选择生产订单");
                }

                if (lookUpEdit工序.EditValue == null || lookUpEdit工序.Text.Trim() == "")
                {
                    lookUpEdit工序.Focus();
                    throw new Exception("请选择工序");
                }

                SqlConnection conn = new SqlConnection(FrameBaseFunction.ClsBaseDataInfo.sConnString);
                conn.Open();
                //启用事务
                SqlTransaction tran = conn.BeginTransaction();

                try
                {
                    for (int i = 0; i < gridView1.RowCount; i++)
                    {
                        bool b = BaseFunction.BaseFunction.ReturnBool(gridView1.GetRowCellValue(i, gridCol选择));
                        if (!b)
                            continue;

                        int iBox = BaseFunction.BaseFunction.ReturnInt(gridView1.GetRowCellValue(i, gridCol箱号));
                        decimal d数量 = BaseFunction.BaseFunction.ReturnDecimal(gridView1.GetRowCellValue(i, gridCol数量),2);

                        if (iBox == 0 && d数量 == 0)
                            continue;

                        if (iBox == 0 && d数量 != 0)
                        {
                            sErr = sErr + "行" + (i + 1).ToString() + "请输入箱号\n";
                            continue;
                        }

                        string sInvCode = txtcInvCode.Text.Trim();

                        sSQL = @"
declare @工序 varchar(50)
select @工序 = WorkProcessNo from [_产品工序] 
where iID < (select iID from [dbo].[_产品工序] where cInvCode = 'aaaaaa' and workprocessNo = 'bbbbbb' )
	and cInvCode = 'aaaaaa' 
order by iID desc

select isnull(数量,0) as 数量,[工序],箱号
from 车间工序日报
where 工序 = @工序 and 生产订单ID = cccccc
";
                        sSQL = sSQL.Replace("aaaaaa", sInvCode);
                        sSQL = sSQL.Replace("bbbbbb", lookUpEdit工序.EditValue.ToString().Trim());
                        sSQL = sSQL.Replace("cccccc", buttonEdit生产订单iIDs.Text.Trim());
                        sSQL = sSQL.Replace("dddddd", iBox.ToString());
                        DataTable dt = DbHelperSQL.ExecuteDataset(tran, CommandType.Text, sSQL).Tables[0];
                        if (d数量 != 0 && dt != null && dt.Rows.Count > 0)
                        {
                            DataRow[] dr = dt.Select("箱号 = '" + iBox.ToString() + "'");
                            if (dr.Length > 0)
                            {
                                decimal d数量上道 = BaseFunction.BaseFunction.ReturnDecimal(dr[0]["数量"]);
                                if (d数量上道 < d数量)
                                {
                                    sErr = sErr + "行" + (i + 1).ToString() + " 数量超出上道工序\n";
                                    continue;
                                }
                            }
                            else
                            {
                                sErr = sErr + "行" + (i + 1).ToString() + " 数量超出上道工序\n";
                                continue;  
                            }
                        }
                        //if (dt == null || dt.Rows.Count == 0)
                        //{
                        //    sErr = sErr + "行" + (i + 1).ToString() + " 数量超出上道工序\n";
                        //    continue;
                        //}


                        TH.Model.车间工序日报 model = new TH.Model.车间工序日报();
                        model.生产订单ID = BaseFunction.BaseFunction.ReturnInt(buttonEdit生产订单iIDs.Text.Trim());
                        model.工序 = lookUpEdit工序.EditValue.ToString().Trim();
                        model.箱号 = iBox;
                        model.数量 = d数量;
                        model.登记日期 = BaseFunction.BaseFunction.ReturnDate(gridView1.GetRowCellValue(i, gridCol登记日期));
                        model.机台序号 = gridView1.GetRowCellValue(i, gridCol机台序号).ToString().Trim();
                        model.作业员 = gridView1.GetRowCellValue(i, gridCol作业员).ToString().Trim();
                        model.型式 = gridView1.GetRowCellValue(i, gridCol型式).ToString().Trim();
                        model.D1D2 = gridView1.GetRowCellValue(i, gridColD1D2).ToString().Trim();
                        model.模号 = gridView1.GetRowCellValue(i, gridCol模号).ToString().Trim(); ;
                        model.转速 = BaseFunction.BaseFunction.ReturnDecimal(gridView1.GetRowCellValue(i, gridCol转速), 2);
                        model.良品数 = BaseFunction.BaseFunction.ReturnDecimal(gridView1.GetRowCellValue(i, gridCol良品数), 2);
                        model.不良数 = BaseFunction.BaseFunction.ReturnDecimal(gridView1.GetRowCellValue(i, gridCol不良数), 2);
                        model.计划停机 = BaseFunction.BaseFunction.ReturnDecimal(gridView1.GetRowCellValue(i, gridCol计划停机), 2);
                        model.机故 = BaseFunction.BaseFunction.ReturnDecimal(gridView1.GetRowCellValue(i, gridCol机故), 2);
                        model.模故 = BaseFunction.BaseFunction.ReturnDecimal(gridView1.GetRowCellValue(i, gridCol模故), 2);
                        model.换料 = BaseFunction.BaseFunction.ReturnDecimal(gridView1.GetRowCellValue(i, gridCol换料), 2);
                        model.测量 = BaseFunction.BaseFunction.ReturnDecimal(gridView1.GetRowCellValue(i, gridCol测量), 2);
                        model.吃饭 = BaseFunction.BaseFunction.ReturnDecimal(gridView1.GetRowCellValue(i, gridCol吃饭), 2);
                        model.换模 = BaseFunction.BaseFunction.ReturnDecimal(gridView1.GetRowCellValue(i, gridCol换模), 2);
                        model.休息 = BaseFunction.BaseFunction.ReturnDecimal(gridView1.GetRowCellValue(i, gridCol休息), 2);
                        model.清扫 = BaseFunction.BaseFunction.ReturnDecimal(gridView1.GetRowCellValue(i, gridCol清扫), 2);
                        model.换班 = BaseFunction.BaseFunction.ReturnDecimal(gridView1.GetRowCellValue(i, gridCol换班), 2);
                        model.待料 = BaseFunction.BaseFunction.ReturnDecimal(gridView1.GetRowCellValue(i, gridCol待料), 2);
                        model.其他 = BaseFunction.BaseFunction.ReturnDecimal(gridView1.GetRowCellValue(i, gridCol其它), 2);
                        model.备注 = gridView1.GetRowCellValue(i, gridCol备注).ToString().Trim();
                        model.班次 = gridView1.GetRowCellValue(i, gridCol班次).ToString().Trim();
                        model.客户 = gridView1.GetRowCellValue(i, gridCol客户).ToString().Trim();

                        sSQL = @"select count(*) as iCou from [车间工序日报] where 生产订单ID = aaaaaa and 工序 = 'bbbbbb' and 箱号 = cccccc";
                        sSQL = sSQL.Replace("aaaaaa", buttonEdit生产订单iIDs.Text.Trim());
                        sSQL = sSQL.Replace("bbbbbb", lookUpEdit工序.EditValue.ToString().Trim());
                        sSQL = sSQL.Replace("cccccc", iBox.ToString());
                        dt = DbHelperSQL.ExecuteDataset(tran,CommandType.Text,sSQL).Tables[0];
                        int iExists = BaseFunction.BaseFunction.ReturnInt(dt.Rows[0][0]);

                        TH.DAL.车间工序日报 dal = new TH.DAL.车间工序日报();
                        if (iExists == 0)
                        {
                            sSQL = dal.Add(model);
                        }
                        else
                        {
                            sSQL = dal.Update(model);
                        }

                        iCou = iCou + DbHelperSQL.ExecuteNonQuery(tran, CommandType.Text, sSQL);
                    }

                    if (sErr.Length > 0)
                        throw new Exception(sErr);

                    if (iCou > 0)
                    {
                        tran.Commit();
                        btnRefresh();
                        MessageBox.Show("保存成功");
                    }
                    else
                    {
                        throw new Exception("没有数据");
                    }
                }
                catch (Exception error)
                {
                    tran.Rollback();
                    iCou = 0;

                    throw new Exception(error.Message);
                }
            }
            catch (Exception ee)
            {
                MsgBox("保存失败", ee.Message);
            }
        }
      
        #endregion

        private void Frm_Load(object sender, EventArgs e)
        {
            try
            {
                sTable = this.Text;

                gridView1.OptionsNavigation.EnterMoveNextColumn = false;

                SetLookup();
            }
            catch (Exception ee)
            {
                MessageBox.Show("加载窗体失败\n" + ee.Message);
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

       
        private void GetGrid(long l)
        {
            buttonEdit生产订单iIDs.Text = l.ToString();

            string sSQL = @"
select cast(0 as bit) as bChoose,a.cCode,a.dDate,b.cInvCode,i.cInvName,i.cInvStd
	,cast(b.fQuantity as decimal(16,2)) as fQuantity,b.dStartDate,b.dEndDate,cast(b.cDefine26 as int) as cDefine26
    ,getdate() as dtm1
from @u8.PP_ProductPO a inner join @u8.PP_POMain b on a.ID = b.ID
	left join @u8.Inventory I on I.cInvCode = b.cInvCode
    left join @u8.Department dep on dep.cDepCode = a.cDepCode
    left join @u8.Person per on per.cPersonCode = a.cPersonCode
where 1=1 
    and b.MainId = aaaaaa 
order by b.ID
";
            sSQL = sSQL.Replace("aaaaaa", l.ToString());
            DataTable dt = DbHelperSQL.Query(sSQL);

            decimal d装箱数 = BaseFunction.BaseFunction.ReturnDecimal(dt.Rows[0]["cDefine26"], 2);
            if(d装箱数==0)
            {
                throw new Exception("请设定生产订单装箱数");
            }

            if (dt != null && dt.Rows.Count > 0)
            {
                txt生产订单号.Text = dt.Rows[0]["cCode"].ToString().Trim();
                txtcInvCode.Text = dt.Rows[0]["cInvCode"].ToString().Trim();
                txtcInvName.Text = dt.Rows[0]["cInvName"].ToString().Trim();
                txtcInvStd.Text = dt.Rows[0]["cInvStd"].ToString().Trim();
                txtQty.Text = dt.Rows[0]["fQuantity"].ToString().Trim();
                dateEdit1.DateTime = Convert.ToDateTime(dt.Rows[0]["dtm1"]);
                txt装箱数.Text = dt.Rows[0]["cDefine26"].ToString().Trim();
            }
        }

        private void gridControl1_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                gridView1.FocusedRowHandle += 1;
            }
        }

        private void buttonEdit生产订单iIDs_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            try
            {
                Frm生产订单列表 frm = new Frm生产订单列表();
                frm.WindowState = FormWindowState.Normal;
                frm.StartPosition = FormStartPosition.CenterParent;
                frm.ShowDialog();

                if (frm.DialogResult == DialogResult.OK)
                {
                    long lIDDetails = frm.lIDDetails;

                    GetGrid(lIDDetails);

                    btnRefresh();
                }
            }
            catch (Exception ee)
            {
                MessageBox.Show(ee.Message);
            }
        }


        private void buttonEdit生产订单iIDs_Validated(object sender, EventArgs e)
        {
            try
            {
                long lIDDetails = BaseFunction.BaseFunction.ReturnLong(buttonEdit生产订单iIDs.Text.Trim());

                if (lIDDetails != 0)
                {
                    GetGrid(lIDDetails);

                    btnRefresh();
                }
            }
            catch { }

            try
            {
                btnRefresh();
            }
            catch { }
        }

        private void txtcInvCode_EditValueChanged(object sender, EventArgs e)
        {
            try
            {
                if(txtcInvCode.Text.Trim() == "")
                {
                    lookUpEdit工序.Properties.DataSource = null;
                }
                else
                {
                    string sSQL = @"
select a.WorkProcessNo as 编码,b.WorkProcessName as 工序
from _产品工序 a inner join [WorkProcess] b on a.WorkProcessNo = b.WorkProcessNo 
where a.cInvCode = '" + txtcInvCode.Text.Trim() + "' order by a.iID";
                    DataTable dt = DbHelperSQL.Query(sSQL);
                    lookUpEdit工序.Properties.DataSource = dt;
                }
            }
            catch (Exception ee)
            {
                MessageBox.Show(ee.Message);
            }
        }

        private void lookUpEdit工序_EditValueChanged(object sender, EventArgs e)
        {
            try
            {
                if (buttonEdit生产订单iIDs.Text.Trim() == "")
                {
                    throw new Exception("请选择生产订单ID");
                }
                if (lookUpEdit工序.EditValue == null || lookUpEdit工序.Text.Trim() == "")
                {
                    throw new Exception("请选择工序");
                }


                int iFocRow = gridView1.FocusedRowHandle;

                string sSQL = @"
select a.生产订单ID, b.工序, a.箱号, b.数量, b.登记日期, b.机台序号, b.作业员, b.型式, b.D1D2, b.模号, b.转速, b.良品数, b.不良数, b.计划停机
    ,b.机故, b.模故, b.换料, b.测量, b.吃饭, b.换模, b.休息, b.清扫, b.换班, b.待料, b.其他, b.备注, b.班次,b.客户
    ,case when isnull(b.机故,0) + isnull(b.模故,0) +isnull(b.换料,0) +isnull(b.测量,0) +isnull(b.吃饭,0) +isnull(b.换模,0) +isnull(b.休息,0) +isnull(b.清扫,0) +isnull(b.换班,0) +isnull(b.待料,0) +isnull(b.其他,0) <> 0 then isnull(b.机故,0) + isnull(b.模故,0) +isnull(b.换料,0) +isnull(b.测量,0) +isnull(b.吃饭,0) +isnull(b.换模,0) +isnull(b.休息,0) +isnull(b.清扫,0) +isnull(b.换班,0) +isnull(b.待料,0) +isnull(b.其他,0)  end as 合计
    ,cast(0 as bit) as 选择
from
(
	select distinct a.生产订单ID,a.箱号
	from [车间工序日报] a
	where 1=1
)a left join [车间工序日报] b on a.生产订单ID = b.生产订单ID and a.箱号 = b.箱号 and 2=2
where 1=1
order by a.生产订单ID,a.箱号
";
                sSQL = sSQL.Replace("1=1", "1=1 and a.生产订单ID = " + buttonEdit生产订单iIDs.Text.Trim());
                sSQL = sSQL.Replace("2=2", "2=2 and b.工序 = '" + lookUpEdit工序.EditValue.ToString().Trim() + "'");

                DataTable dt = DbHelperSQL.Query(sSQL);

                int iRowCount = BaseFunction.BaseFunction.ReturnInt(Math.Ceiling(BaseFunction.BaseFunction.ReturnDecimal(txtQty.Text.Trim()) / BaseFunction.BaseFunction.ReturnDecimal(txt装箱数.Text.Trim())));
                while (dt.Rows.Count < iRowCount)
                {
                    DataRow dr = dt.NewRow();
                    dr["箱号"] = (dt.Rows.Count + 1).ToString();
                    dt.Rows.Add(dr);
                }

                gridControl1.DataSource = dt;
                gridView1.FocusedRowHandle = iFocRow;
                dateEdit1.Enabled = true;
                gridView1.OptionsBehavior.Editable = true;
                gridView1.BestFitColumns();
            }
            catch (Exception ee)
            {
                MessageBox.Show(ee.Message);
            }
        }

        private void gridView1_CellValueChanged(object sender, DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs e)
        {
            try
            {
                if(e.Column != gridCol选择)
                {
                    if (!BaseFunction.BaseFunction.ReturnBool(gridView1.GetRowCellValue(e.RowHandle, gridCol选择)))
                    {
                        gridView1.SetRowCellValue(e.RowHandle, gridCol选择, true);
                    }

                    if (e.Column != gridCol班次 && gridView1.GetRowCellValue(e.RowHandle, gridCol班次).ToString().Trim() == "")
                    {
                        gridView1.SetRowCellValue(e.RowHandle, gridCol班次, lookUpEdit班次.EditValue);
                    }
                }

                if (e.Column == gridCol数量)
                {
                    if (gridView1.GetRowCellValue(e.RowHandle, gridCol登记日期).ToString().Trim() == "")
                    {
                        gridView1.SetRowCellValue(e.RowHandle, gridCol登记日期, dateEdit1.DateTime);
                    }
                }

                if (e.Column == gridCol机故
                    || e.Column == gridCol模故
                    || e.Column == gridCol换模
                    || e.Column == gridCol换料
                    || e.Column == gridCol测量
                    || e.Column == gridCol吃饭
                    || e.Column == gridCol休息
                    || e.Column == gridCol清扫
                    || e.Column == gridCol换班
                    || e.Column == gridCol待料
                    || e.Column == gridCol其它)
                {
                    decimal d1 = BaseFunction.BaseFunction.ReturnDecimal(gridView1.GetRowCellValue(e.RowHandle, gridCol机故), 2);
                    decimal d2 = BaseFunction.BaseFunction.ReturnDecimal(gridView1.GetRowCellValue(e.RowHandle, gridCol模故), 2);
                    decimal d3 = BaseFunction.BaseFunction.ReturnDecimal(gridView1.GetRowCellValue(e.RowHandle, gridCol换模), 2);
                    decimal d4 = BaseFunction.BaseFunction.ReturnDecimal(gridView1.GetRowCellValue(e.RowHandle, gridCol换料), 2);
                    decimal d5 = BaseFunction.BaseFunction.ReturnDecimal(gridView1.GetRowCellValue(e.RowHandle, gridCol测量), 2);
                    decimal d6 = BaseFunction.BaseFunction.ReturnDecimal(gridView1.GetRowCellValue(e.RowHandle, gridCol吃饭), 2);
                    decimal d7 = BaseFunction.BaseFunction.ReturnDecimal(gridView1.GetRowCellValue(e.RowHandle, gridCol休息), 2);
                    decimal d8 = BaseFunction.BaseFunction.ReturnDecimal(gridView1.GetRowCellValue(e.RowHandle, gridCol清扫), 2);
                    decimal d9 = BaseFunction.BaseFunction.ReturnDecimal(gridView1.GetRowCellValue(e.RowHandle, gridCol换班), 2);
                    decimal d10 = BaseFunction.BaseFunction.ReturnDecimal(gridView1.GetRowCellValue(e.RowHandle, gridCol待料), 2);
                    decimal d11 = BaseFunction.BaseFunction.ReturnDecimal(gridView1.GetRowCellValue(e.RowHandle, gridCol其它), 2);

                    decimal d = d1 + d2 + d3 + d4 + d5 + d6 + d7 + d8 + d9 + d10 + d11;
                    gridView1.SetRowCellValue(e.RowHandle, gridCol合计, d);

                }
            }
            catch { }
        }

        private void SetLookup()
        {
            string sSQL = @"
select * from [dbo].[_LookUpDate] where iType = '班次' order by iID
";
            DataTable dt = DbHelperSQL.Query(sSQL);
            DataRow dr = dt.NewRow();
            dt.Rows.InsertAt(dr, 0);

            lookUpEdit班次.Properties.DataSource = dt;
            ItemLookUpEdit班次.DataSource = dt;

            lookUpEdit班次.EditValue = dt.Rows[0]["iText"].ToString().Trim();
        }
    }
}
