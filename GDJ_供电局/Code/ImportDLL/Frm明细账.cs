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
    public partial class Frm明细账 : FrameBaseFunction.FrmBaseInfo
    {

        public Frm明细账()
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

        }

        /// <summary>
        /// 判断是否已经使用
        /// </summary>
        /// <param name="p"></param>
        /// <param name="sErr"></param>
        /// <returns></returns>
        private bool CheckCanDel(string p, out string sErr)
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

        private void Frm明细账_Load(object sender, EventArgs e)
        {
            try
            {
                GetLookUp();
            }
            catch (Exception ee)
            {
                MessageBox.Show(ee.Message);
            }
        }

        private void GetLookUp()
        {
            dateEdit1.Text = DateTime.Today.Year.ToString() + "-01-01";
            dateEdit2.DateTime = DateTime.Today;

            string sSQL = "select cVenCode,cVenName from @u8.Vendor order by cVenCode ";
            DataTable dt = clsSQLCommond.ExecQuery(sSQL);
            DataRow dr = dt.NewRow();
            dr[0] = DBNull.Value;
            dr[1] = DBNull.Value;
            dt.Rows.InsertAt(dr, 0);
            lookUpEditVendor.Properties.DataSource = dt;

            sSQL = "select cCusCode,cCusName from @u8.customer  order by cCusCode ";
            dt = clsSQLCommond.ExecQuery(sSQL);
            dr = dt.NewRow();
            dr[0] = DBNull.Value;
            dr[1] = DBNull.Value;
            dt.Rows.InsertAt(dr, 0);
            lookUpEdit客户.Properties.DataSource = dt;

            sSQL = "select cDepCode,cDepName from @u8.Department  order by cDepCode ";
            dt = clsSQLCommond.ExecQuery(sSQL);
            dr = dt.NewRow();
            dr[0] = DBNull.Value;
            dr[1] = DBNull.Value;
            dt.Rows.InsertAt(dr, 0);
            lookUpEdit部门.Properties.DataSource = dt;

            sSQL = "select cPersonCode,cPersonName from @u8.Person  order by cPersonCode ";
            dt = clsSQLCommond.ExecQuery(sSQL);
            dr = dt.NewRow();
            dr[0] = DBNull.Value;
            dr[1] = DBNull.Value;
            dt.Rows.InsertAt(dr, 0);
            lookUpEdit个人.Properties.DataSource = dt;

            try
            {
                sSQL = "select citemcode,citemname from @u8.fitemss00 order by citemcode";
                dt = clsSQLCommond.ExecQuery(sSQL);
                dr = dt.NewRow();
                dr[0] = DBNull.Value;
                dr[1] = DBNull.Value;
                dt.Rows.InsertAt(dr, 0);
                lookUpEdit项目.Properties.DataSource = dt;


                layoutControlItem11.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Always;
                gridCol项目号.Visible = true;
            }
            catch 
            {
                layoutControlItem11.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Never;
                gridCol项目号.Visible = false;
            }

            sSQL = "select csign,ctext from @u8.dsign order by i_id";
            dt = clsSQLCommond.ExecQuery(sSQL);
            dr = dt.NewRow();
            dr[0] = DBNull.Value;
            dr[1] = DBNull.Value;
            dt.Rows.InsertAt(dr, 0);
            lookUpEdit类别.Properties.DataSource = dt;

            sSQL = "select ccode,ccode_name from @u8.code order by ccode";
            dt = clsSQLCommond.ExecQuery(sSQL); ;
            lookUpEdit科目.Properties.DataSource = dt;
            if (dt != null && dt.Rows.Count > 0)
            {
                lookUpEdit科目.EditValue = dt.Rows[0]["ccode"];
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

        private void GetGrid()
        {
            string sErr = "";
            try
            {
                if (dateEdit1.Text.Trim() == "")
                {
                    sErr = sErr + "日期不能为空";
                    dateEdit1.Focus();
                }
                if (dateEdit2.Text.Trim() == "")
                {
                    sErr = sErr + "日期不能为空";
                    dateEdit1.Focus();
                }
                if (lookUpEdit科目.EditValue == null || lookUpEdit科目.EditValue.ToString().Trim() == "")
                {
                    sErr = sErr + "科目不能为空";
                    lookUpEdit科目.Focus();
                }

                if (sErr.Length > 0)
                    throw new Exception(sErr);

                SqlConnection con = new SqlConnection(FrameBaseFunction.ClsBaseDataInfo.sConnString);
                SqlCommand cmd = new SqlCommand();
                SqlTransaction trans;
                con.Open();
                cmd.Connection = con;
                trans = con.BeginTransaction();
                cmd.Transaction = trans;
                try
                {
                    string sSQL = @"
SELECT distinct A.cAcc_Id as 帐套号,A.cAcc_Name as 帐套名称,p.iYear as 年度
FROM UFSystem.dbo.UA_Account A inner join UFSystem.dbo.UA_period P on A.cAcc_Id=P.cAcc_Id 
	AND (P.bIsDelete=0 OR P.bIsDelete IS NULL) 
WHERE 1=1 and a.cAcc_Id = '111111'
order by A.cAcc_Id,p.iYear desc
";
                    sSQL = sSQL.Replace("111111", FrameBaseFunction.ClsBaseDataInfo.sUFDataBaseName.Substring(7, 3));
                    DataTable dtAccYear = SqlHelper.ExecuteDataset(trans, CommandType.Text, sSQL).Tables[0];

                    int iMinYear = dateEdit1.DateTime.Year;

                    sSQL = @"
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[_GL_accvouchTemp]') AND type in (N'U'))
	drop table _GL_accvouchTemp


CREATE TABLE [dbo].[_GL_accvouchTemp](
	[日期] [varchar](100) NULL,
	[凭证类别编号] [varchar](39) NULL,
	[凭证类别] [varchar](39) NULL,
	[凭证号数] [varchar](39) NULL,
	[摘要] [varchar](60) NULL,
	[方向] [varchar](2) NULL,
	[借方] [money] NULL,
	[外币借方] [money] NULL,
	[贷方] [money] NULL,
	[外币贷方] [money] NULL,
	[余额] [money] NULL,
	[外币余额] [money] NULL,
	[科目] [varchar](15) NULL,
	[科目名称] [varchar](40) NULL,
	[币种] [varchar](8) NULL,
	[对方科目] [varchar](50) NULL,
	[对方科目名称] [varchar](40) NULL,
	[项目号] [varchar](20) NULL,
	[部门编码] [varchar](12) NULL,
	[部门] [varchar](20) NULL,
	[职员编码] [varchar](8) NULL,
	[职员] [varchar](50) NULL,
	[客户编码] [varchar](20) NULL,
	[客户] [varchar](98) NULL,
	[供应商编码] [varchar](20) NULL,
	[供应商] [varchar](98) NULL,
	[期间] [tinyint] NULL,
	[年度] [int] NULL
) ON [PRIMARY]

";
                    cmd.CommandText = sSQL;
                    cmd.ExecuteNonQuery();


                    for (int i = iMinYear; i <= dateEdit2.DateTime.Year; i++)
                    {
                        #region 起始年月

                        if (i == iMinYear)
                        {
                            int iMinMonth = dateEdit1.DateTime.Month;

                            //期初余额
                            sSQL = @"
insert into _GL_accvouchTemp(科目,科目名称,摘要,方向,余额,外币余额,币种,年度)
select a.ccode,b.ccode_name
	,'期初余额' as 摘要,case when isnull(b.bproperty,0) = 0 then '贷' else '借' end as 方向
	,sum(case when isnull(b.bproperty,0) = 1 then a.md - a.mc else a.mc - a.md end)  as 余额
	,sum(case when isnull(b.bproperty,0) = 1 then a.md_f - a.mc_f else a.mc - a.md end)  as 外币余额
	,a.cexch_name as 币种
    ,111111 as 年度
from @u8.GL_accvouch a
	left join @u8.code b on a.ccode = b.ccode
	left join @u8.code c on a.ccode_equal = c.ccode
	left join @u8.Department d on d.cDepCode = a.cdept_id
	left join @u8.Person e on e.cPersonCode = a.cperson_id
	left join @u8.Customer f on f.cCusCode = a.ccus_id 
	left join @u8.Vendor g on g.cVenCode = a.csup_id
where 1=1
	and isnull(b.bend,0) = 1
group by b.bproperty,a.cexch_name,a.ccode,b.ccode_name
";
                            sSQL = sSQL.Replace("111111", i.ToString());
                            string sUFDataBaseName = FrameBaseFunction.ClsBaseDataInfo.sUFDataBaseName;
                            sUFDataBaseName = sUFDataBaseName.Replace("2014", i.ToString());
                            sSQL = sSQL.Replace("@u8", sUFDataBaseName + ".");
                            sSQL = sSQL.Replace("1=1", "1=1 and a.iperiod < " + iMinMonth.ToString());

                            if (lookUpEdit科目.EditValue != null && lookUpEdit科目.EditValue.ToString().Trim() != "")
                            {
                                sSQL = sSQL.Replace("1=1", "1=1 and a.ccode like '" + lookUpEdit科目.EditValue.ToString().Trim() + "%'");
                            }
                            if (!chkAll.Checked)
                            {
                                sSQL = sSQL.Replace("1=1", "1=1 and isnull(a.ibook,0) = 1"); 
                            }

                            cmd.CommandText = sSQL;
                            cmd.ExecuteNonQuery();
                        }
                        #endregion

                        sSQL = @"
insert into _GL_accvouchTemp
select CONVERT(varchar(100), a.dbill_date,111) as 日期
    ,h.i_id,a.csign as 类别
    ,a.csign + '-' + right('0000'+cast(a.ino_id as VARCHAR(20)),4) as 凭证号数,a.cdigest as 摘要,case when isnull(b.bproperty,0) = 0 then '贷' else '借' end as 方向
	,case when isnull(a.md,0) <> 0 then a.md end as 借方,case when isnull(a.md_f,0) <> 0 then a.md_f end as 外币借方
	,case when isnull(a.mc,0) <> 0 then a.mc end as 贷方,case when isnull(a.mc_f,0) <> 0 then a.mc_f end as 外币贷方
    ,null,null
	,a.ccode as 科目,b.ccode_name as 科目名称
	,a.cexch_name as 币种
	,a.ccode_equal as 对方科目,c.ccode_name as 对方科目名称
	,a.citem_id as 项目号
	,a.cdept_id  as 部门编码,d.cDepName as 部门
	,a.cperson_id as 职员编码,e.cPersonName  as 职员
	,a.ccus_id as 客户编码,f.cCusName as 客户
	,a.csup_id as 供应商编码,g.cVenName as 供应商
	,a.iperiod as 期间
    ,111111 as 年度
from @u8.GL_accvouch a
	left join @u8.code b on a.ccode = b.ccode
	left join @u8.code c on a.ccode_equal = c.ccode
	left join @u8.Department d on d.cDepCode = a.cdept_id
	left join @u8.Person e on e.cPersonCode = a.cperson_id
	left join @u8.Customer f on f.cCusCode = a.ccus_id 
	left join @u8.Vendor g on g.cVenCode = a.csup_id
    left join @u8.dsign h on h.csign = a.csign
where 1=1
order by a.dbill_date

";
                        string sUFDataBaseName2 = FrameBaseFunction.ClsBaseDataInfo.sUFDataBaseName;
                        sUFDataBaseName2 = sUFDataBaseName2.Replace("2014", i.ToString());
                        sSQL = sSQL.Replace("@u8", sUFDataBaseName2 + ".");
                        sSQL = sSQL.Replace("111111", i.ToString());

                        if (i == iMinYear)
                        {
                            int iMinMonth = dateEdit1.DateTime.Month;
                            sSQL = sSQL.Replace("1=1","1=1 and a.iperiod >= " + iMinMonth.ToString());
                        }
                        if (i == dateEdit2.DateTime.Year)
                        {
                            int iMaxMonth = dateEdit2.DateTime.Month;
                            sSQL = sSQL.Replace("1=1", "1=1 and a.iperiod <= " + iMaxMonth.ToString());

                        }
                        if (!chkAll.Checked)
                        {
                            sSQL = sSQL.Replace("1=1", "1=1 and isnull(a.ibook,0) = 1");
                        }

                  
                        if (lookUpEdit科目.EditValue != null && lookUpEdit科目.EditValue.ToString().Trim() != "")
                        {
                            sSQL = sSQL.Replace("1=1", "1=1 and a.ccode like '" + lookUpEdit科目.EditValue.ToString().Trim() + "%'");
                        }
                        if (lookUpEditVendor.EditValue != null && lookUpEditVendor.EditValue.ToString().Trim() != "")
                        {
                            sSQL = sSQL.Replace("1=1", "1=1 and a.csup_id = '" + lookUpEditVendor.EditValue.ToString().Trim() + "'");
                        }
                        if (lookUpEdit客户.EditValue != null && lookUpEdit客户.EditValue.ToString().Trim() != "")
                        {
                            sSQL = sSQL.Replace("1=1", "1=1 and a.ccus_id = '" + lookUpEdit客户.EditValue.ToString().Trim() + "'");
                        }
                        if (txt摘要.Text.Trim() != "")
                        {
                            sSQL = sSQL.Replace("1=1", "1=1 and a.cdigest like '%" + txt摘要.Text.Trim() + "%'");
                        }
                        if (lookUpEdit类别.EditValue != null && lookUpEdit类别.EditValue.ToString().Trim() != "")
                        {
                            sSQL = sSQL.Replace("1=1", "1=1 and a.csign = '" + lookUpEdit类别.EditValue.ToString().Trim() + "'");
                        }
                        if (lookUpEdit项目.EditValue != null && lookUpEdit项目.EditValue.ToString().Trim() != "")
                        {
                            sSQL = sSQL.Replace("1=1", "1=1 and a.citem_id = '" + lookUpEdit项目.EditValue.ToString().Trim() + "'");
                        }
                        if (lookUpEdit个人.EditValue != null && lookUpEdit个人.EditValue.ToString().Trim() != "")
                        {
                            sSQL = sSQL.Replace("1=1", "1=1 and a.cperson_id = '" + lookUpEdit个人.EditValue.ToString().Trim() + "'");
                        }
                        if (lookUpEdit部门.EditValue != null && lookUpEdit部门.EditValue.ToString().Trim() != "")
                        {
                            sSQL = sSQL.Replace("1=1", "1=1 and a.cdept_id = '" + lookUpEdit部门.EditValue.ToString().Trim() + "'");
                        }

                        cmd.CommandText = sSQL;
                        cmd.ExecuteNonQuery();
                    }

                    sSQL = "select * from _GL_accvouchTemp order by 科目,日期,凭证类别编号,凭证号数";
                    DataTable dtGrid = SqlHelper.ExecuteDataset(trans, CommandType.Text, sSQL).Tables[0];


                    trans.Commit();

                    gridControl1.DataSource = dtGrid;
                }
                catch (Exception ee)
                {
                    trans.Rollback();
                    throw new Exception(ee.Message);
                }
            }
            catch (Exception ee)
            {
                MessageBox.Show(ee.Message);
            }
        }

    }
}
