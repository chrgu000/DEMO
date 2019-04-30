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
    public partial class Frm账龄分析 : FrameBaseFunction.FrmBaseInfo
    {

        public Frm账龄分析()
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
                    case "add":
                        btnAdd();
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

        private void btnAdd()
        {
            gridView1.OptionsBehavior.Editable = true;
            gridView1.OptionsBehavior.ReadOnly = false;
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
            //string sErr = "";
            //OpenFileDialog oFile = new OpenFileDialog();
            //oFile.Filter = "Excel文件2003|*.xls|Excel文件2007|*.xlsx";
            //if (oFile.ShowDialog() == DialogResult.OK)
            //{
            //    string sFilePath = oFile.FileName;
            //    string sSQL = "select distinct 计量单位编码,计量单位名称,备注 from [" + s表名称 + "$]";

            //    DataTable dtExcel = clsExcel.ExcelToDT(sFilePath, sSQL, true);

            //    for (int i = 0; i < dtExcel.Rows.Count; i++)
            //    {
            //        string s编码 = dtExcel.Rows[i][";"].ToString().Trim();
            //        DataRow[] dr = dtBingGrid.Select("; = '" + s编码 + "'");
            //        if (dr.Length > 0)
            //        {
            //            dtExcel.Rows[i]["时间戳"] = dr[0]["时间戳"];
            //            sErr = sErr + s编码 + "\n";
            //        }
            //    }
            //    gridControl1.DataSource = dtExcel;

            //    if (sErr.Length > 0)
            //    {
            //        sErr = "以下计量单位已经存在，不能重复导入：\n" + sErr;
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
            throw new NotImplementedException();
        }
        /// <summary>
        /// 查询
        /// </summary>
        private void btnSel()
        {
            GetGridView();
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
            for (int i = gridView1.RowCount - 1; i >= 0 ; i--)
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
           
        }

        /// <summary>
        /// 判断是否已经使用
        /// </summary>
        /// <param name="p"></param>
        /// <param name="sErr"></param>
        /// <returns></returns>
        private bool CheckCanDel(string p,out string sErr)
        {
            bool b = true;
            sErr = "";

            return b;
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

            //sSQL = "delete " + s表名称 + " where 财务帐套 = '" + lookUpEdit财务帐套.EditValue.ToString().Trim() + "' and 薪资帐套 = '" + lookUpEdit薪资帐套.EditValue.ToString().Trim() + "'";
            //aList.Add(sSQL);

            //sSQL = "select * from " + s表名称 + " where 1=-1";
            //DataTable dt人员对照表 = clsSQLCommond.ExecQuery(sSQL);

            //for (int i = 0; i < gridView1.RowCount; i++)
            //{
            //    DataRow dr = dt人员对照表.NewRow();
            //    dr["财务帐套"] = lookUpEdit财务帐套.EditValue.ToString().Trim();
            //    dr["薪资帐套"] = lookUpEdit薪资帐套.EditValue.ToString().Trim();
            //    dr["薪资部门编号"] = gridView1.GetRowCellValue(i, gridCol薪资部门编号).ToString().Trim();
            //    dr["财务部门编号"] = gridView1.GetRowCellValue(i, gridCol财务部门编号).ToString().Trim();
            //    dr["部门名称"] = gridView1.GetRowCellValue(i, gridCol部门名称).ToString().Trim();

            //    dt人员对照表.Rows.Add(dr);
            //}

            //for (int i = 0; i < dt人员对照表.Rows.Count; i++)
            //{
            //    sSQL = clsGetSQL.GetInsertSQL(s表名称, dt人员对照表, i);
            //    aList.Add(sSQL);
            //}

            //if (aList.Count > 0)
            //{
            //    int iCou = clsSQLCommond.ExecSqlTran(aList);
            //    MessageBox.Show("保存成功！\n合计执行语句:" + iCou + "条");
            //    GetGridView();
            //}
        }
        /// <summary>
        /// 撤销
        /// </summary>
        private void btnUnDo()
        {
            throw new NotImplementedException();
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

        private void Frm账龄分析_Load(object sender, EventArgs e)
        {
            try
            {
                string sSQL = "select getdate()";

                DateTime dNow = Convert.ToDateTime(SqlHelper.ExecuteScalar(FrameBaseFunction.ClsBaseDataInfo.sConnString, CommandType.Text, sSQL));
                dateEdit分析日期.Text = dNow.ToString("yyyy-MM-dd");
            }
            catch (Exception ee)
            {
                MessageBox.Show(ee.Message);
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

        private object ReturnValue(object a)
        {
            if (a.ToString().Trim() == "")
                return DBNull.Value;
            else
                return a;
        }

        private void GetGridView()
        {
            string sErr = "";

            Frm用户默认帐套 f = new Frm用户默认帐套(FrameBaseFunction.ClsBaseDataInfo.sUid);
            f.ShowDialog();

            if (f.DialogResult != DialogResult.Yes)
            {
                throw new Exception("取消查询");
            }

            try
            {
                DataTable dt = f.dt.Copy();
                for (int i = gridView1.Columns.Count - 1; i >= 0; i--)
                {
                    if (gridView1.Columns[i].Caption.Trim() == "帐套号")
                        continue;
                    if (gridView1.Columns[i].Caption.Trim() == "帐套")
                        continue;
                    if (gridView1.Columns[i].Caption.Trim() == "客户/供应商编码")
                        continue;
                    if (gridView1.Columns[i].Caption.Trim() == "客户/供应商")
                        continue;
                    if (gridView1.Columns[i].Caption.Trim() == "总额")
                        continue;
                    if (gridView1.Columns[i].Caption.Trim() == "科目")
                        continue;

                    gridView1.Columns.RemoveAt(i);
                }

                SqlConnection con = new SqlConnection(FrameBaseFunction.ClsBaseDataInfo.sConnString);
                SqlCommand cmd = new SqlCommand();
                SqlTransaction trans;
                con.Open();
                cmd.Connection = con;
                trans = con.BeginTransaction();
                cmd.Transaction = trans;
                try
                {
                    #region 列表字段
                    
                    sSQL = "select * from dbo._LookUpDate where iType = 1 order by iID";
                    DataTable dtCol = SqlHelper.ExecuteDataset(trans, CommandType.Text, sSQL).Tables[0];

                    int iLow = 0;
                    string s组装字段 = "";
                    string s组装字段sum = "";

                    //string s报表字段 = "";
                    for (int i = 0; i < dtCol.Rows.Count; i++)
                    {
                        string sColName = "";;
                        if (i == 0)
                        {
                            sColName = " ~ " + dtCol.Rows[i]["iText"].ToString().Trim();
                            iLow = ReturnInt(dtCol.Rows[i]["iText"]);

                            //s报表字段 = s报表字段 + "aaaa" + i.ToString().Trim() + " <= " + dtCol.Rows[i]["iText"].ToString().Trim();
                            AddGridCol(sColName, sColName, "d" + i.ToString(), i + 10);
                            s组装字段 = s组装字段 + "," + "d" + i.ToString() + " money";
                            s组装字段sum = s组装字段sum + ",sum(" + "d" + i.ToString() + ") as " + "d" + i.ToString() + "";
                        }
                        else
                        {
                            sColName = iLow.ToString().Trim() + " ~ " + dtCol.Rows[i]["iText"].ToString().Trim();
                            iLow = ReturnInt(dtCol.Rows[i]["iText"]);
                            AddGridCol(sColName, sColName, "d" + i.ToString(), i + 10);
                            s组装字段 = s组装字段 + "," + "d" + i.ToString() + " money";
                            s组装字段sum = s组装字段sum + ",sum(" + "d" + i.ToString() + ") as " + "d" + i.ToString() + "";
                        }
                        if (i != 0 && i == dtCol.Rows.Count - 1)
                        {
                            sColName = dtCol.Rows[i]["iText"].ToString().Trim() + " ~ ";
                            AddGridCol(sColName, sColName, "d" + (i + 1).ToString(), i + 11);
                            s组装字段 = s组装字段 + "," + "d" + (i + 1).ToString() + " money";
                            s组装字段sum = s组装字段sum + ",sum(" + "d" + (i + 1).ToString() + ") as " + "d" + (i + 1).ToString() + "";
                        }
                    }

                    //创建临时表
                    string sPublicTableName = "RepPublicCusTH" + FrameBaseFunction.ClsBaseDataInfo.sUid;

                    //sSQL = @"IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[" + sPublicTableName + "]') AND type in (N'U')) DROP TABLE [dbo].[" + sPublicTableName + "]";
                    sSQL = @"if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[111111]') and OBJECTPROPERTY(id, N'IsUserTable') = 1) drop table [dbo].[111111]";
                    sSQL = sSQL.Replace("111111", sPublicTableName);
                    cmd.CommandText = sSQL;
                    cmd.ExecuteNonQuery();

                    sSQL = @"
create table RepTH(
客户编码 varchar(20),
客户 varchar(200),
科目 varchar(200),
帐套客户编号 varchar(20),
帐套号 varchar(20),
帐套 varchar(200),
总额 money,
单据日期 datetime
)
";
                    sSQL = sSQL.Replace("RepTH", sPublicTableName);
                    cmd.CommandText = sSQL;
                    cmd.ExecuteNonQuery();

                    string sTableName = "RepCusTH" + FrameBaseFunction.ClsBaseDataInfo.sUid;

                    //sSQL = @"IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[" + sTableName + "]') AND type in (N'U')) DROP TABLE [dbo].[" + sTableName + "]";
                    sSQL = @"if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[111111]') and OBJECTPROPERTY(id, N'IsUserTable') = 1) drop table [dbo].[111111]";
                    sSQL = sSQL.Replace("111111", sTableName);
                    cmd.CommandText = sSQL;
                    cmd.ExecuteNonQuery();

                    sSQL = @"
create table RepTH(
客户编码 varchar(20),
客户 varchar(200),
科目 varchar(200),
帐套号 varchar(20),
帐套 varchar(200),
来源客户编码 varchar(20),
来源帐套号 varchar(20),
总额 money
111111
)
";
                    sSQL = sSQL.Replace("RepTH", sTableName);
                    sSQL = sSQL.Replace("111111", s组装字段);
                    cmd.CommandText = sSQL;
                    cmd.ExecuteNonQuery();

                    #endregion

                    DataTable dt应收账款凭证 = null;
                    for (int i = 0; i < f.dt.Rows.Count; i++)
                    {
                        if (!Convert.ToBoolean(dt.Rows[i]["选择"]))
                            continue;

                        string sAccID = dt.Rows[i]["帐套号"].ToString().Trim();

                        sSQL = @"
SELECT distinct A.cAcc_Id as 帐套号,A.cAcc_Name as 帐套名称,p.iYear as 年度
FROM UFSystem.dbo.UA_Account A inner join UFSystem.dbo.UA_period P on A.cAcc_Id=P.cAcc_Id 
	AND (P.bIsDelete=0 OR P.bIsDelete IS NULL) 
WHERE 1=1 and a.cAcc_Id = '111111'
order by A.cAcc_Id,p.iYear desc
";
                        sSQL = sSQL.Replace("111111", sAccID);
                        DataTable dtAccYear = SqlHelper.ExecuteDataset(trans, CommandType.Text, sSQL).Tables[0];
                        if (dtAccYear == null || dtAccYear.Rows.Count < 1)
                        {
                            sErr = sErr + "帐套" + sAccID + "不存在\n";
                            continue;
                        }

                        string sDBName = "UFDATA_" + sAccID + "_" + dtAccYear.Rows[0]["年度"].ToString().Trim();
// or c.ccode like '2131%'
                        if (!chk包含未记账.Checked)
                        {
                            sSQL = @"
insert into RepTH(客户编码,客户,科目,帐套号,帐套,总额,来源客户编码,来源帐套号)
Select 
    case when isnull(a.cCusDefine1,'') = '' then a.cCusCode else a.cCusDefine1 end as 客户编码,a.cCusAbbName as 客户
    ,c.ccode as 科目
	,case when isnull(a.cCusDefine1,'') = '' then '222222' else '公共' end as 帐套号
	,case when isnull(a.cCusDefine1,'') = '' then '333333'  else '公共' end as 帐套
	,isnull(Sum(case when iperiod=111111 then (case when cendd_c<>'贷' then me else -me end) else 0 end),0) as 应收账款
    ,a.cCusCode as 来源客户编码,'222222' as 来源帐套号
from  UFDATA..Customer a right JOIN (UFDATA..Code b INNER JOIN UFDATA..GL_accass c ON b.cCode=c.cCode) ON a.cCusCode=c.ccus_id  
where iPeriod <= 111111 and not c.cCode is Null and (c.ccode like '1131%' or c.ccode like '1133%' )
Group By a.cCusCode,a.cCusAbbName,a.cCusDefine1,c.ccode
having isnull(Sum(case when iperiod=111111 then (case when cendd_c<>'贷' then me else -me end) else 0 end),0) <> 0
order by a.cCusCode,a.cCusAbbName 


insert into RepTH(客户编码,客户,科目,帐套号,帐套,总额,来源客户编码,来源帐套号)
Select 
    case when isnull(a.cCusDefine1,'') = '' then a.cCusCode else a.cCusDefine1 end as 客户编码,a.cCusAbbName as 客户
    ,c.ccode as 科目
	,case when isnull(a.cCusDefine1,'') = '' then '222222' else '公共' end as 帐套号
	,case when isnull(a.cCusDefine1,'') = '' then '333333'  else '公共' end as 帐套
	,-isnull(Sum(case when iperiod=111111 then (case when cendd_c<>'贷' then me else -me end) else 0 end),0) as 应收账款
    ,a.cCusCode as 来源客户编码,'222222' as 来源帐套号
from  UFDATA..Customer a right JOIN (UFDATA..Code b INNER JOIN UFDATA..GL_accass c ON b.cCode=c.cCode) ON a.cCusCode=c.ccus_id  
where iPeriod <= 111111 and not c.cCode is Null and (c.ccode like '2131%')
Group By a.cCusCode,a.cCusAbbName,a.cCusDefine1,c.ccode
having isnull(Sum(case when iperiod=111111 then (case when cendd_c<>'借' then me else -me end) else 0 end),0) <> 0
order by a.cCusCode,a.cCusAbbName 

insert into RepTH(客户编码,客户,科目,帐套号,帐套,总额,来源客户编码,来源帐套号)
Select 
    case when isnull(a.cVenDefine1,'') = '' then a.cVenCode else a.cVenDefine1 end as 客户编码,a.cVenAbbName as 客户
    ,c.ccode as 科目
	,case when isnull(a.cVenDefine1,'') = '' then '222222' else '公共' end as 帐套号
	,case when isnull(a.cVenDefine1,'') = '' then '333333'  else '公共' end as 帐套
	,isnull(Sum(case when iperiod=111111 then (case when cendd_c<>'贷' then me else -me end) else 0 end),0) as 应收账款
    ,a.cVenCode as 来源客户编码,'222222' as 来源帐套号
from  UFDATA..Vendor a right JOIN (UFDATA..Code b INNER JOIN UFDATA..GL_accass c ON b.cCode=c.cCode) ON a.cVenCode=c.csup_id  
where iPeriod <= 111111 and not c.cCode is Null and (c.ccode like '1151%')
Group By a.cVenCode,a.cVenAbbName,a.cVenDefine1,c.ccode
having isnull(Sum(case when iperiod=111111 then (case when cendd_c<>'贷' then me else -me end) else 0 end),0) <> 0
order by a.cVenCode,a.cVenAbbName 
";

                            sSQL = sSQL.Replace("111111", dateEdit分析日期.DateTime.Month.ToString());
                            sSQL = sSQL.Replace("222222", sAccID);
                            sSQL = sSQL.Replace("333333", dt.Rows[i]["帐套名称"].ToString().Trim());
                            sSQL = sSQL.Replace("UFDATA", sDBName);
                            sSQL = sSQL.Replace("RepTH", sTableName);
                            cmd.CommandText = sSQL;
                            cmd.ExecuteNonQuery();
                        }
                        else
                        {
                            sSQL = @"
insert into RepTH(客户编码,客户,科目,帐套号,帐套,总额,来源客户编码,来源帐套号)
select 客户编码,客户,科目,帐套号,帐套,sum(应收账款) as 应收账款,来源客户编码,来源帐套号
from
(
Select
	 case when isnull(a.cCusDefine1,'') = '' then a.cCusCode else a.cCusDefine1 end as 客户编码,a.cCusAbbName as 客户
    ,c.ccode as 科目
	,case when isnull(a.cCusDefine1,'') = '' then '222222' else '公共' end as 帐套号
	,case when isnull(a.cCusDefine1,'') = '' then '333333' else '公共' end as 帐套
	,(Sum(case when iperiod<1 then md-mc else 0 end) + Sum(case when iperiod>=1 then md else 0 end) - Sum(case when iperiod>=1 then mc else 0 end)) as 应收账款
    ,a.cCusCode as 来源客户编码,'222222' as 来源帐套号
from  UFDATA..Customer a right JOIN (UFDATA..Code b INNER JOIN  UFDATA..GL_accvouch c ON b.cCode=c.cCode) ON a.cCusCode=c.ccus_id  
where iperiod<= 111111 and not c.cCode is Null and (c.ccode like '1131%' or c.ccode like '1133%') and ibook=0 and (iflag is null or iflag=2) and iperiod>=1
Group By b.cCode,b.ccode_name,a.cCusCode,a.cCusAbbName ,a.cCusDefine1, c.ccode

union all

Select 
    case when isnull(a.cCusDefine1,'') = '' then a.cCusCode else a.cCusDefine1 end as 客户编码,a.cCusAbbName as 客户
    ,c.ccode as 科目
	,case when isnull(a.cCusDefine1,'') = '' then '222222' else '公共' end as 帐套号
	,case when isnull(a.cCusDefine1,'') = '' then '333333'  else '公共' end as 帐套
	,isnull(Sum(case when iperiod=111111 then (case when cendd_c<>'贷' then me else -me end) else 0 end),0) as 应收账款
    ,a.cCusCode as 来源客户编码,'222222' as 来源帐套号
from  UFDATA..Customer a right JOIN (UFDATA..Code b INNER JOIN  UFDATA..GL_accass c ON b.cCode=c.cCode) ON a.cCusCode=c.ccus_id  
where iPeriod <= 111111 and not c.cCode is Null and (c.ccode like '1131%' or c.ccode like '1133%') 
Group By a.cCusCode,a.cCusAbbName,a.cCusDefine1,c.ccode
)a 
group by 客户编码,客户,帐套号,帐套,来源客户编码,来源帐套号,科目
having sum(应收账款) <> 0
order by 客户编码 

insert into RepTH(客户编码,客户,科目,帐套号,帐套,总额,来源客户编码,来源帐套号)
select 客户编码,客户,科目,帐套号,帐套,sum(应收账款) as 应收账款,来源客户编码,来源帐套号
from
(
Select
	 case when isnull(a.cCusDefine1,'') = '' then a.cCusCode else a.cCusDefine1 end as 客户编码,a.cCusAbbName as 客户
    ,c.ccode as 科目
	,case when isnull(a.cCusDefine1,'') = '' then '222222' else '公共' end as 帐套号
	,case when isnull(a.cCusDefine1,'') = '' then '333333' else '公共' end as 帐套
	,-(Sum(case when iperiod<1 then md-mc else 0 end) + Sum(case when iperiod>=1 then md else 0 end) - Sum(case when iperiod>=1 then mc else 0 end)) as 应收账款
    ,a.cCusCode as 来源客户编码,'222222' as 来源帐套号
from  UFDATA..Customer a right JOIN (UFDATA..Code b INNER JOIN  UFDATA..GL_accvouch c ON b.cCode=c.cCode) ON a.cCusCode=c.ccus_id  
where iperiod<= 111111 and not c.cCode is Null and ( c.ccode like '2131%') and ibook=0 and (iflag is null or iflag=2) and iperiod>=1
Group By b.cCode,b.ccode_name,a.cCusCode,a.cCusAbbName ,a.cCusDefine1, c.ccode

union all

Select 
    case when isnull(a.cCusDefine1,'') = '' then a.cCusCode else a.cCusDefine1 end as 客户编码,a.cCusAbbName as 客户
    ,c.ccode as 科目
	,case when isnull(a.cCusDefine1,'') = '' then '222222' else '公共' end as 帐套号
	,case when isnull(a.cCusDefine1,'') = '' then '333333'  else '公共' end as 帐套
	,-isnull(Sum(case when iperiod=111111 then (case when cendd_c<>'贷' then me else -me end) else 0 end),0) as 应收账款
    ,a.cCusCode as 来源客户编码,'222222' as 来源帐套号
from  UFDATA..Customer a right JOIN (UFDATA..Code b INNER JOIN  UFDATA..GL_accass c ON b.cCode=c.cCode) ON a.cCusCode=c.ccus_id  
where iPeriod <= 111111 and not c.cCode is Null and (c.ccode like '2131%') 
Group By a.cCusCode,a.cCusAbbName,a.cCusDefine1,c.ccode
)a 
group by 客户编码,客户,帐套号,帐套,来源客户编码,来源帐套号,科目
having sum(应收账款) <> 0
order by 客户编码 

insert into RepTH(客户编码,客户,科目,帐套号,帐套,总额,来源客户编码,来源帐套号)
select 供应商编码,供应商,科目,帐套号,帐套,sum(预付账款) as 应收账款,来源客户编码,来源帐套号
from
(
Select 
    case when isnull(a.cVenDefine1,'') = '' then a.cVenCode else a.cVenDefine1 end as 供应商编码,a.cVenAbbName as 供应商
    ,c.ccode as 科目
	,case when isnull(a.cVenDefine1,'') = '' then '222222' else '公共' end as 帐套号
	,case when isnull(a.cVenDefine1,'') = '' then '333333'  else '公共' end as 帐套
	,isnull(Sum(case when iperiod=111111 then (case when cendd_c<>'贷' then me else -me end) else 0 end),0) as 预付账款
    ,a.cVenCode as 来源客户编码,'222222' as 来源帐套号
from  UFDATA..Vendor a right JOIN (UFDATA..Code b INNER JOIN UFDATA..GL_accass c ON b.cCode=c.cCode) ON a.cVenCode=c.csup_id  
where iPeriod <= 111111 and not c.cCode is Null and (c.ccode like '1151%')
Group By a.cVenCode,a.cVenAbbName,a.cVenDefine1,c.ccode
having isnull(Sum(case when iperiod=111111 then (case when cendd_c<>'贷' then me else -me end) else 0 end),0) <> 0

union all

Select
    case when isnull(a.cVenDefine1,'') = '' then a.cVenCode else a.cVenDefine1 end as 供应商编码,a.cVenAbbName as 供应商
    ,c.ccode as 科目
	,case when isnull(a.cVenDefine1,'') = '' then '222222' else '公共' end as 帐套号
	,case when isnull(a.cVenDefine1,'') = '' then '333333' else '公共' end as 帐套
	,(Sum(case when iperiod<1 then md-mc else 0 end) + Sum(case when iperiod>=1 then md else 0 end) - Sum(case when iperiod>=1 then mc else 0 end)) as 预付账款
    ,a.cVenCode as 来源供应商编码,'222222' as 来源帐套号
from  UFDATA..Vendor a right JOIN (UFDATA..Code b INNER JOIN  UFDATA..GL_accvouch c ON b.cCode=c.cCode) ON a.cVenCode=c.csup_id  
where iperiod<= 111111 and not c.cCode is Null and (c.ccode like '1151%') and ibook=0 and (iflag is null or iflag=2) and iperiod>=1
Group By a.cVenCode,a.cVenAbbName,a.cVenDefine1,c.ccode
)a
group by 供应商编码,供应商,帐套号,帐套,来源客户编码,来源帐套号,科目
having sum(预付账款) <> 0
order by 供应商编码 


";
                            sSQL = sSQL.Replace("111111", dateEdit分析日期.DateTime.Month.ToString());
                            sSQL = sSQL.Replace("222222", sAccID);
                            sSQL = sSQL.Replace("333333", dt.Rows[i]["帐套名称"].ToString().Trim());
                            sSQL = sSQL.Replace("UFDATA", sDBName);
                            sSQL = sSQL.Replace("RepTH", sTableName);
                            cmd.CommandText = sSQL;
                            cmd.ExecuteNonQuery();
                        }
                    }

                    sSQL = "select * from RepTH order by 帐套号,客户编码";
                    sSQL = sSQL.Replace("RepTH", sTableName);
                    dt应收账款凭证 = SqlHelper.ExecuteDataset(trans, CommandType.Text, sSQL).Tables[0];

                    for (int j = 0; j < dt应收账款凭证.Rows.Count; j++)
                    {
                        string sCustomID = dt应收账款凭证.Rows[j]["客户编码"].ToString().Trim();

                        if (sCustomID == "1001")
                        {
                        
                        }
                        decimal d客户总额 = ReturnDecimal(dt应收账款凭证.Rows[j]["总额"]);
                        string sAccID = dt应收账款凭证.Rows[j]["来源帐套号"].ToString().Trim();

                        sSQL = @"
SELECT distinct A.cAcc_Id as 帐套号,A.cAcc_Name as 帐套名称,p.iYear as 年度
FROM UFSystem.dbo.UA_Account A inner join UFSystem.dbo.UA_period P on A.cAcc_Id=P.cAcc_Id 
	AND (P.bIsDelete=0 OR P.bIsDelete IS NULL) 
WHERE 1=1 and a.cAcc_Id = '003'
order by A.cAcc_Id,p.iYear desc
";
                        sSQL = sSQL.Replace("003", sAccID);
                        DataTable dtAccYear = SqlHelper.ExecuteDataset(trans, CommandType.Text, sSQL).Tables[0];
                        for (int k = 0; k < dtAccYear.Rows.Count; k++)
                        {
                            string s帐套 = sAccID; // dt应收账款凭证.Rows[j]["帐套号"].ToString().Trim();
                            string sUFDB = "UFDATA_" + sAccID + "_" + dtAccYear.Rows[k]["年度"].ToString().Trim();

                            string s科目 = dt应收账款凭证.Rows[j]["科目"].ToString().Trim();

                            #region 非公共客户，供应商
                            
                            //if (s帐套 != "公共")
                            //{
                                sSQL = @"
select * from UFDATA_003_2013..GL_accvouch  
where 1=1 and (isnull(md,0) <> 0 or isnull(mc,0) <> 0) and (ccode = '222222') and (isnull(ccus_id,'') = '111111'  or isnull(csup_id,'') = '111111')
order by dbill_date desc
";
                                sSQL = sSQL.Replace("UFDATA_003_2013", sUFDB);
                                sSQL = sSQL.Replace("111111", sCustomID);
                                sSQL = sSQL.Replace("222222", s科目);
                                if (k != dtAccYear.Rows.Count - 1)
                                {
                                    sSQL = sSQL.Replace("1=1", " 1=1 and iperiod <> 0 ");
                                }
                                if (!chk包含未记账.Checked)
                                {
                                    sSQL = sSQL.Replace("1=1", "1=1 and isnull(cbook,'') <> '' ");
                                }

                                DataTable dt应收款明细 = SqlHelper.ExecuteDataset(trans, CommandType.Text, sSQL).Tables[0];

                                for (int l = 0; l < dt应收款明细.Rows.Count; l++)
                                {
                                    DateTime d单据日期 = Convert.ToDateTime(dt应收款明细.Rows[l]["dbill_date"]);

                                    decimal d金额 = ReturnDecimal(dt应收款明细.Rows[l]["md"]);
                                    decimal d = ReturnDecimal(dt应收款明细.Rows[l]["mc"]);

                                    if (s科目.Substring(0, 4) == "2131")
                                    {
                                        d金额 = ReturnDecimal(dt应收款明细.Rows[l]["mc"]);
                                        d = ReturnDecimal(dt应收款明细.Rows[l]["md"]);

                                        if (d < 0)
                                            d金额 = d金额 - d;
                                    }
                                    else
                                    {
                                        if (d < 0)
                                            d金额 = d金额 - d;
                                    }


                                    TimeSpan ts = dateEdit分析日期.DateTime - d单据日期;
                                    int iDays = ts.Days;

                                    for (int ii = 0; ii < gridView1.Columns.Count; ii++)
                                    {
                                        string sCaption = gridView1.Columns[ii].Caption.Trim();
                                        string sColName = gridView1.Columns[ii].FieldName.Trim();

                                        if (sColName.Substring(0, 1) == "d")
                                        {
                                            string[] sList = sCaption.Split('~');
                                            if (sList[0].Trim() == "")
                                                sList[0] = "0";
                                            if (sList[1].Trim() == "")
                                                sList[1] = "65000";

                                            if (iDays >= ReturnInt(sList[0]) && iDays < ReturnInt(sList[1]))
                                            {
                                                sSQL = @"
update RepTH set 111111 = isnull(111111,0) + 222222      
where isnull(客户编码,'') = '333333' and 来源帐套号 = '444444' and 科目 = '555555'           
";
                                                sSQL = sSQL.Replace("RepTH", sTableName);
                                                sSQL = sSQL.Replace("111111", sColName);
                                                sSQL = sSQL.Replace("333333", sCustomID);
                                                sSQL = sSQL.Replace("444444", sAccID);
                                                sSQL = sSQL.Replace("555555", s科目);
                                                if (d客户总额 > d金额)
                                                {
                                                    sSQL = sSQL.Replace("222222", d金额.ToString());
                                                }
                                                else
                                                {
                                                    sSQL = sSQL.Replace("222222", (d客户总额).ToString());
                                                }
                                                cmd.CommandText = sSQL;
                                                cmd.ExecuteNonQuery();
                                                d客户总额 = d客户总额 - d金额;
                                                if (d客户总额 <= 0)
                                                {
                                                    break;
                                                }


                                            }
                                        }
                                    }
                                    if (d客户总额 <= 0)
                                    {
                                        break;
                                    }
                                }
                            //}

                            #endregion
                            if (d客户总额 <= 0)
                            {
                                break;
                            }
                        }
                    }
                    
                    sSQL = @"
insert into RepTH
select null,null,科目 + '小计' as 科目,帐套号,null,null,null,SUM(总额) as 总额 111111 from RepTH 
where 科目 not like '%小计%' and 科目 not like '%合计%' 
group by 科目,帐套号
      
";

                    sSQL = sSQL.Replace("111111", s组装字段sum);
                    sSQL = sSQL.Replace("RepTH", sTableName);
                    cmd.CommandText = sSQL;
                    cmd.ExecuteNonQuery();

                    sSQL = @"
insert into RepTH
select null,null,科目 + '科目','合计' as 科目,null,null,null,SUM(总额) as 总额 111111 from RepTH 
where 科目 not like '%小计%' and 科目 not like '%合计%' 
group by 科目
      
";

                    sSQL = sSQL.Replace("111111", s组装字段sum);
                    sSQL = sSQL.Replace("RepTH", sTableName);
                    cmd.CommandText = sSQL;
                    cmd.ExecuteNonQuery();


                    sSQL = @"
insert into RepTH
select null,null,null,帐套号+'合计' as 帐套号,null,null,null,SUM(总额) as 总额 111111 from RepTH
where 科目 not like '%小计%' and 科目 not like '%合计%'  and 帐套号 not like '%合计%'
group by 帐套号,帐套
      
";
                    sSQL = sSQL.Replace("111111", s组装字段sum);
                    sSQL = sSQL.Replace("RepTH", sTableName);
                    cmd.CommandText = sSQL;
                    cmd.ExecuteNonQuery();

                    sSQL = @"
insert into RepTH
select null,null,'合计','合计',null,null,null,SUM(总额) as 总额 111111 from RepTH
where 科目 not like '%小计%' and 帐套号 not like '%合计%' 
      
";
                    sSQL = sSQL.Replace("111111", s组装字段sum);
                    sSQL = sSQL.Replace("RepTH", sTableName);
                    cmd.CommandText = sSQL;
                    cmd.ExecuteNonQuery();

                    string sTemp = "总额 ";
                    for (int i = 0; i < dtCol.Rows.Count; i++)
                    {
                        sTemp = sTemp + " - isnull(d" + i.ToString() + ",0)";
                    }
                    sTemp = "d" + dtCol.Rows.Count.ToString() + " =  case when " + sTemp + " <> 0 then " + sTemp + " end ";
                    sSQL = @"
update RepTH set 111111

";
                    sSQL = sSQL.Replace("111111", sTemp);
                    sSQL = sSQL.Replace("RepTH", sTableName);
                    cmd.CommandText = sSQL;
                    cmd.ExecuteNonQuery();

                    sSQL = "select * from RepTH order by 帐套号,科目,客户编码";
                    sSQL = sSQL.Replace("RepTH", sTableName);
                    DataTable dtGrid = SqlHelper.ExecuteDataset(trans, CommandType.Text, sSQL).Tables[0];
                    gridControl1.DataSource = dtGrid;


                    sSQL = @"
drop table RepTH
";
                    sSQL = sSQL.Replace("RepTH", sTableName);
                    cmd.CommandText = sSQL;
                    cmd.ExecuteNonQuery();

                    sSQL = @"
drop table RepTH
";
                    sSQL = sSQL.Replace("RepTH", sPublicTableName);
                    cmd.CommandText = sSQL;
                    cmd.ExecuteNonQuery();

                    trans.Commit();
                }
                catch(Exception ee)
                {
                    trans.Rollback();
                    throw new Exception(ee.Message);
                }
            }
            catch (Exception ee)
            {
                throw new Exception("加载报表列失败："+ee.Message);
            }
        }

        private void AddGridCol(string sCatpion,string sName,string sFieldName,int sIndex)
        {

            DevExpress.XtraGrid.Columns.GridColumn gridColumn1 = new DevExpress.XtraGrid.Columns.GridColumn();

            gridView1.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] { gridColumn1 });
            gridColumn1.Caption = sCatpion;
            gridColumn1.Name = "gridCol" + sName;
            gridColumn1.FieldName = sFieldName;
            gridColumn1.Visible = true;
            gridColumn1.VisibleIndex = sIndex;
            gridColumn1.Width = 100;
            gridColumn1.ColumnEdit = this.ItemTextEditn2;
        }

    }
}
