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
using System.Data.OleDb;

namespace ImportDLL
{
    public partial class FrmAccess : FrameBaseFunction.FrmFromModel
    {

        //TH.Model.Equipment Model = new TH.Model.Equipment();
        //TH.DAL._GetBaseData DALGetBaseData = new TH.DAL._GetBaseData();
        //TH.DAL.生产日报表 DAL = new TH.DAL.生产日报表();


        public FrmAccess()
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

            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "Access|*.accdb|所有文件|*.*";
            openFileDialog.RestoreDirectory = true;
            openFileDialog.FilterIndex = 1;

            if (openFileDialog.ShowDialog() != DialogResult.OK)
            {
                return;
            }

            string fName = openFileDialog.FileName;

            string str = @"provider= Microsoft.ACE.OLEDB.12.0;Data Source=" + fName;
            OleDbConnection conn = new OleDbConnection(str);
            conn.Open();
            OleDbTransaction tran = conn.BeginTransaction();

            try
            {
                string sSQL = @"

select 	iID, 存货编码, 期间
    , case when isnull(期初数量,0) = 0 then null else 期初数量 end as 期初数量
	, case when isnull(期初金额,0) = 0 then null else 期初金额 end as 期初金额
	, case when isnull(领用数量,0) = 0 then null else 领用数量 end as 领用数量
	, case when isnull(领用金额,0) = 0 then null else 领用金额 end as 领用金额
	, case when isnull(完工数量,0) = 0 then null else 完工数量 end as 完工数量
	, case when isnull(完工金额,0) = 0 then null else 完工金额 end as 完工金额
	, case when isnull(在制数量,0) = 0 then null else 在制数量 end as 在制数量
	, case when isnull(在制金额,0) = 0 then null else 在制金额 end as 在制金额 

from @u8._产品工序流转统计 
where 1=-1";
                DataTable dt = DbHelperSQL.Query(sSQL);

                sSQL = "select * from 存货收发设置 order by 表名";
                DataTable dtTables = GetDT(tran, sSQL);

                DateTime d期间 = ReturnObjectToDatetime(lookUpEdit导入期间.EditValue.ToString() + "-01");
                for (int i = 0; i < dtTables.Rows.Count; i++)
                {
                    string sTableName = dtTables.Rows[i]["表名"].ToString().Trim();
                    string s存货编码 = dtTables.Rows[i]["存货编码"].ToString().Trim();
                    string s领料工序 = dtTables.Rows[i]["领料工序"].ToString().Trim();
                    string s完工工序 = dtTables.Rows[i]["完工工序"].ToString().Trim();
                    string sD2 = dtTables.Rows[i]["D2名称"].ToString().Trim();
                    string s存货编码D2 = dtTables.Rows[i]["D2存货编码"].ToString().Trim();
                    string s领料工序D2 = dtTables.Rows[i]["D2领料工序"].ToString().Trim();
                    string s完工工序D2 = dtTables.Rows[i]["D2完工工序"].ToString().Trim();

                    sSQL = @"
select @存货编码,sum(领用数量) as 领用数量,sum(完工数量) as 完工数量
from
(
select @存货编码,count(*) as 领用数量,null as 完工数量 from @表名 where 年份 = '@年份' and @领料工序 like '@月份%' group by @存货编码
                union all
select @存货编码,null as 领用数量,count(*) as 完工数量 from @表名 where 年份 = '@年份' and @完工工序 like '@月份%' group by @存货编码
)a 
group by @存货编码
 ";

                    sSQL = sSQL.Replace("@年份", d期间.Year.ToString());
                    sSQL = sSQL.Replace("@月份", d期间.Month.ToString());
                    sSQL = sSQL.Replace("@存货编码", s存货编码);
                    sSQL = sSQL.Replace("@表名", sTableName);
                    sSQL = sSQL.Replace("@领料工序", s领料工序);
                    sSQL = sSQL.Replace("@完工工序", s完工工序);
                    DataTable dt1 = GetDT(tran, sSQL);

                    for (int j = 0; j < dt1.Rows.Count; j++)
                    {
                        DataRow dr = dt.NewRow();
                        dr["存货编码"] = dt1.Rows[j]["存货编码"].ToString().Trim();
                        dr["领用数量"] = dt1.Rows[j]["领用数量"];
                        dr["完工数量"] = dt1.Rows[j]["完工数量"];
                        dt.Rows.Add(dr);
                    }

                    if (sD2 == "")
                    {
                        continue;
                    }

                    sSQL = @"
select @存货编码,sum(领用数量) as 领用数量,sum(完工数量) as 完工数量
from
(
select @存货编码,count(*) as 领用数量,null as 完工数量 from @表名 where 年份 = '@年份' and @领料工序 like '@月份%' group by @存货编码
                union all
select @存货编码,null as 领用数量,count(*) as 完工数量 from @表名 where 年份 = '@年份' and @完工工序 like '@月份%' group by @存货编码
)a 
group by @存货编码
 ";

                    sSQL = sSQL.Replace("@年份", d期间.Year.ToString());
                    sSQL = sSQL.Replace("@月份", d期间.Month.ToString());
                    sSQL = sSQL.Replace("@表名", sTableName);
                    sSQL = sSQL.Replace("@存货编码", s存货编码D2);
                    sSQL = sSQL.Replace("@领料工序", s领料工序D2);
                    sSQL = sSQL.Replace("@完工工序", s完工工序D2);
                    DataTable dt2 = GetDT(tran, sSQL);

                    for (int j = 0; j < dt2.Rows.Count; j++)
                    {
                        DataRow dr = dt.NewRow();
                        dr["存货编码"] = dt2.Rows[j]["D2存货编码"].ToString().Trim();
                        dr["领用数量"] = dt2.Rows[j]["领用数量"];
                        dr["完工数量"] = dt2.Rows[j]["完工数量"];
                        dt.Rows.Add(dr);
                    }
                }

                tran.Commit();
                DataView dv = dt.DefaultView;
                dv.Sort = "存货编码";

                DataTable dtGrid = dv.ToTable();

                sSQL = "select * from @u8._产品工序流转统计 where 期间 = '" + d期间.AddMonths(-1).ToString("yyyy-MM-01") + "'";
                DataTable dt上月 = DbHelperSQL.Query(sSQL);

                for (int i = 0; i < dt上月.Rows.Count; i++)
                {
                    string s存货编码 = dt上月.Rows[i]["存货编码"].ToString();
                    DataRow[] drList = dtGrid.Select("存货编码 = '" + s存货编码 + "'");
                    if (drList.Length > 0)
                    {
                        drList[0]["期初数量"] = dt上月.Rows[i]["在制数量"];
                        drList[0]["期初金额"] = dt上月.Rows[i]["在制金额"];
                    }
                    else
                    {
                        DataRow dr = dtGrid.NewRow();
                        dr["存货编码"] = s存货编码;
                        dr["期初数量"] = dt上月.Rows[i]["在制数量"];
                        dr["期初金额"] = dt上月.Rows[i]["在制金额"];
                        dtGrid.Rows.Add(dr);
                    }
                }

                for (int i = 0; i < dtGrid.Rows.Count; i++)
                {
                    decimal d期初数量 = ReturnObjectToDecimal(dtGrid.Rows[i]["期初数量"], 2);
                    decimal d领用数量 = ReturnObjectToDecimal(dtGrid.Rows[i]["领用数量"], 2);
                    decimal d完工数量 = ReturnObjectToDecimal(dtGrid.Rows[i]["完工数量"], 2);
                    decimal d在制数量 = d期初数量 + d领用数量 - d完工数量;
                    if (d在制数量 != 0)
                    {
                        dtGrid.Rows[i]["在制数量"] = d在制数量;
                    }
                    else
                    {
                        dtGrid.Rows[i]["在制数量"] = DBNull.Value;
                    }

                    decimal d期初金额 = ReturnObjectToDecimal(dtGrid.Rows[i]["期初金额"], 2);
                    decimal d领用金额 = ReturnObjectToDecimal(dtGrid.Rows[i]["领用金额"], 2);
                    decimal d完工金额 = ReturnObjectToDecimal(dtGrid.Rows[i]["完工金额"], 2);
                    decimal d在制金额 = d期初金额 + d领用金额 - d完工金额;
                    if (d在制金额 != 0)
                    {
                        dtGrid.Rows[i]["在制金额"] = d在制金额;
                    }
                    else
                    {
                        dtGrid.Rows[i]["在制金额"] = DBNull.Value;
                    }
                }

                gridControl1.DataSource = dtGrid;
            }
            catch (Exception ee)
            {
                tran.Rollback();
                throw new Exception(ee.Message);
            }
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
            try
            {
                string sSQL = @"

select 	iID, 存货编码, 期间
    , case when isnull(期初数量,0) = 0 then null else 期初数量 end as 期初数量
	, case when isnull(期初金额,0) = 0 then null else 期初金额 end as 期初金额
	, case when isnull(领用数量,0) = 0 then null else 领用数量 end as 领用数量
	, case when isnull(领用金额,0) = 0 then null else 领用金额 end as 领用金额
	, case when isnull(完工数量,0) = 0 then null else 完工数量 end as 完工数量
	, case when isnull(完工金额,0) = 0 then null else 完工金额 end as 完工金额
	, case when isnull(在制数量,0) = 0 then null else 在制数量 end as 在制数量
	, case when isnull(在制金额,0) = 0 then null else 在制金额 end as 在制金额 

from @u8._产品工序流转统计 where 期间 = '" + lookUpEdit导入期间.EditValue.ToString() + "-01" + "'";
                DataTable dt = DbHelperSQL.Query(sSQL);
                if (dt != null && dt.Rows.Count > 0)
                {
                    gridControl1.DataSource = dt;
                    return;
                }
            }
            catch (Exception ee)
            {
                throw new Exception(ee.Message);
            }
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
            throw new NotImplementedException();
        }
        /// <summary>
        /// 删除
        /// </summary>
        private void btnDel()
        {


            SqlConnection conn = new SqlConnection(FrameBaseFunction.ClsBaseDataInfo.sConnString);
            conn.Open();
            //启用事务
            SqlTransaction tran = conn.BeginTransaction();
            try
            {
                string sSQL = "select top 1 * from @u8._产品工序流转统计 where 期间 >= '" + ReturnObjectToDatetime(lookUpEdit导入期间.EditValue.ToString() + "-01").AddMonths(1).ToString("yyyy-MM-01") + "'";
                DataTable dt = DbHelperSQL.Query(sSQL);
                if (dt != null && dt.Rows.Count > 0)
                {
                    throw new Exception("已有以后期间数据，不能删除");
                }

                sSQL = "delete @u8.[_产品工序流转统计] where 期间 = '" + lookUpEdit导入期间.EditValue.ToString() + "-01" + "'";
                int iCou = DbHelperSQL.ExecuteNonQuery(tran, CommandType.Text, sSQL);
                tran.Commit();
                if (iCou > 0)
                {
                    MessageBox.Show("删除成功");
                    gridControl1.DataSource = null;
                }
            }
            catch (Exception ee)
            {
                tran.Rollback();
                throw new Exception(ee.Message);
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

            string sErr = "";
            int iCou = 0;

            try
            {
                SqlConnection conn = new SqlConnection(FrameBaseFunction.ClsBaseDataInfo.sConnString);
                conn.Open();
                //启用事务
                SqlTransaction tran = conn.BeginTransaction();

                try
                {
                    if (lookUpEdit导入期间.Text.Trim() == "")
                    {
                        lookUpEdit导入期间.Focus();
                        throw new Exception("请选择导入月份");
                    }

                    string s导入期间 = lookUpEdit导入期间.Text + "-01".Trim();

                    string sSQL = "select top 1 * from @u8._产品工序流转统计 where 期间 >= '" + ReturnObjectToDatetime(lookUpEdit导入期间.EditValue.ToString() + "-01").AddMonths(1).ToString("yyyy-MM-01") + "'";
                    DataTable dt = DbHelperSQL.ExecuteDataset(tran, CommandType.Text, sSQL).Tables[0];
                    if (dt != null && dt.Rows.Count > 0)
                    {
                        throw new Exception("已有以后期间数据，不能保存");
                    }

                    for (int i = 0; i < gridView1.RowCount; i++)
                    {
                        TH.Model._产品工序流转统计 model = new TH.Model._产品工序流转统计();
                        model.存货编码 = gridView1.GetRowCellValue(i, gridCol存货编码).ToString().Trim();
                        model.期初数量 = BaseFunction.BaseFunction.ReturnDecimal(gridView1.GetRowCellValue(i, gridCol期初数量));
                        model.期间 = ReturnObjectToDatetime(lookUpEdit导入期间.EditValue.ToString().Trim() + "-01");
                        model.期初金额 = BaseFunction.BaseFunction.ReturnDecimal(gridView1.GetRowCellValue(i, gridCol期初金额));
                        model.领用数量 = BaseFunction.BaseFunction.ReturnDecimal(gridView1.GetRowCellValue(i, gridCol领用数量));
                        model.领用金额 = BaseFunction.BaseFunction.ReturnDecimal(gridView1.GetRowCellValue(i, gridCol领用金额));
                        model.完工数量 = BaseFunction.BaseFunction.ReturnDecimal(gridView1.GetRowCellValue(i, gridCol完工数量));
                        model.完工金额 = BaseFunction.BaseFunction.ReturnDecimal(gridView1.GetRowCellValue(i, gridCol完工金额));
                        model.在制数量 = BaseFunction.BaseFunction.ReturnDecimal(gridView1.GetRowCellValue(i, gridCol在制数量));
                        model.在制金额 = BaseFunction.BaseFunction.ReturnDecimal(gridView1.GetRowCellValue(i, gridCol在制金额));

                        TH.DAL._产品工序流转统计 dal = new TH.DAL._产品工序流转统计();

                        sSQL = dal.Delete(model.存货编码, model.期间);
                        DbHelperSQL.ExecuteNonQuery(tran, CommandType.Text, sSQL);


                        sSQL = dal.Add(model);
                        iCou += DbHelperSQL.ExecuteNonQuery(tran, CommandType.Text, sSQL);
                    }
                    if (sErr.Length > 0)
                    {
                        throw new Exception(sErr);
                    }

                    tran.Commit();

                    if (iCou > 0)
                    {
                        MessageBox.Show("成功导入" + iCou.ToString() + "条数据");
                    }
                }
                catch (Exception ee)
                {
                    tran.Rollback();
                    throw new Exception(ee.Message);
                }
            }
            catch (Exception ee)
            {
                throw new Exception(ee.Message);
            }
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
                GetLookUp();

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

        private void GetLookUp()
        {
            DataTable dt = new DataTable();
            DataColumn dc = new DataColumn();
            dc.ColumnName = "年月";
            dt.Columns.Add(dc);

            int iYear = DateTime.Today.AddYears(-1).Year;

            for (int i = iYear; i <= DateTime.Today.AddYears(1).Year; i++)
            {
                for (int j = 1; j <= 12; j++)
                {
                    DataRow dr = dt.NewRow();

                    string sMonth = j.ToString();
                    if (sMonth.Length < 2)
                    {
                        sMonth = "0" + sMonth;
                    }
                    dr["年月"] = i.ToString() + "-" + sMonth;
                    dt.Rows.Add(dr);
                }
            }
            lookUpEdit导入期间.Properties.DataSource = dt;
            lookUpEdit导入期间.EditValue = DateTime.Today.ToString("yyyy-MM");

            sSQL = "select cInvCode,cInvName from @u8.Inventory order by cInvCode";
            dt = clsSQLCommond.ExecQuery(sSQL);
            ItemLookUpEditcInvName.DataSource = dt;
        }

        private DataTable GetDT(OleDbTransaction tran, string sSQL)
        {
            OleDbCommand myCommand = new OleDbCommand(sSQL, tran.Connection, tran);
            //OleDbDataAdapter myCommand = new OleDbDataAdapter(sSQL,tran);
            DataSet ds = new DataSet();
            OleDbDataAdapter da = new OleDbDataAdapter(myCommand);
            da.Fill(ds);

            return ds.Tables[0];
        }

        private void lookUpEdit导入期间_EditValueChanged(object sender, EventArgs e)
        {
            try
            {
                btnSel();
            }
            catch (Exception ee)
            {
                MessageBox.Show(ee.Message);
            }
        }
    }
}
