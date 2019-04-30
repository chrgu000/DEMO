using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;
using TH.BaseClass;
using System.Data.SqlClient;

namespace UFIDA.U8.UAP.CustomApp.ControlForm
{
    public partial class 费用分配表 : UserControl
    {
        TH.BaseClass.GetBaseData getBaseData = new GetBaseData();
        
        string sProPath = Application.StartupPath;

        UFIDA.U8.UAP.CustomApp.ControlForm.RepBaseGrid Rep = new RepBaseGrid();

        public DateTime dSerToday { get; set; }

        public string Conn { get; set; }

        public string sUserID { get; set; }

        public string sUserName { get; set; }

        public string sLogDate { get; set; }

        public string sAccID { get; set; }



        private void Frm_Load(object sender, EventArgs e)
        {
            try
            {
                lAudit.Text = ""; 

                gridCol冻干工时.Visible = false;

                SetLookUp();
            }
            catch (Exception ee)
            {
                FrmMsgBox f = new FrmMsgBox();
                f.Text = "加载窗体失败";
                f.richTextBox1.Text = ee.Message;
                f.ShowDialog();
            }
        }

        public 费用分配表()
        {
            InitializeComponent();
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

        private void SetLookUp()
        {
           string sSQL = "select distinct 会计期间 from _ProMaterial order by 会计期间";
           DataTable dt = DbHelperSQL.Query(sSQL);
            if (dt == null || dt.Rows.Count == 0)
            {
                DataRow dr = dt.NewRow();
                dr["会计期间"] = DateTime.Today.AddMonths(-2).ToString("yyyy-MM");
                dt.Rows.Add(dr);
                dr = dt.NewRow();
                dr["会计期间"] = DateTime.Today.AddMonths(-1).ToString("yyyy-MM");
                dt.Rows.Add(dr);
                dr = dt.NewRow();
                dr["会计期间"] = DateTime.Today.ToString("yyyy-MM");
                dt.Rows.Add(dr);
                dr = dt.NewRow();
                dr["会计期间"] = DateTime.Today.AddMonths(1).ToString("yyyy-MM");
                dt.Rows.Add(dr);
                dr = dt.NewRow();
                dr["会计期间"] = DateTime.Today.AddMonths(2).ToString("yyyy-MM");
                dt.Rows.Add(dr);
            }
            else
            {
                DateTime sMax会计期间 = BaseFunction.ReturnDate(dt.Rows[dt.Rows.Count - 1]["会计期间"].ToString().Trim() + "-01");
                DateTime dNow = BaseFunction.ReturnDate(DateTime.Today.ToString("yyyy-MM") + "-01");

                while (sMax会计期间 < dNow.AddMonths(2))
                {
                    sMax会计期间 = sMax会计期间.AddMonths(1);
                    DataRow dr = dt.NewRow();
                    dr["会计期间"] = sMax会计期间.ToString("yyyy-MM");
                    dt.Rows.Add(dr);
                }
            }

            lookUpEdit会计期间.Properties.DataSource = dt;
            lookUpEdit会计期间.EditValue = DateTime.Today.ToString("yyyy-MM");

            sSQL = "select cDepCode,cDepName from Department where isnull(bDepEnd ,0) <> 0  and isnull(cDepProp,'') = '成本' order by cDepCode";
            dt = DbHelperSQL.Query(sSQL);
            lookUpEditcDepName.Properties.DataSource = dt;
            lookUpEditcDepCode.Properties.DataSource = dt;

            dt = new DataTable();
            DataColumn dc = new DataColumn();
            dc.ColumnName = "iID";
            dt.Columns.Add(dc);
            dc = new DataColumn();
            dc.ColumnName = "iText";
            dt.Columns.Add(dc);
            DataRow dr2 = dt.NewRow();
            dr2["iID"] = -1;
            dr2["iText"] = "未完工";
            dt.Rows.Add(dr2);
            dr2 = dt.NewRow();
            dr2["iID"] = 0;
            dr2["iText"] = "其他";
            dt.Rows.Add(dr2);
            dr2 = dt.NewRow();
            dr2["iID"] = 1;
            dr2["iText"] = "完工";
            dt.Rows.Add(dr2);
            dr2 = dt.NewRow();
            dr2["iID"] = 2;
            dr2["iText"] = "上月结转";
            dt.Rows.Add(dr2);
            dr2 = dt.NewRow();
            dr2["iID"] = 3;
            dr2["iText"] = "扣项";
            dt.Rows.Add(dr2);

            ItemLookUpEdit费用类型.DataSource = dt;
        }

        private void btnDel_Click(object sender, EventArgs e)
        {
            try
            {
                try
                {
                    gridView1.FocusedRowHandle -= 1;
                    gridView1.FocusedRowHandle += 1;
                }
                catch { }

                string sErr = "";
                int iCou = 0;
                SqlConnection conn = new SqlConnection(DbHelperSQL.connectionString);
                conn.Open();
                //启用事务
                SqlTransaction tran = conn.BeginTransaction();
                try
                {

                    string s会计期间 = lookUpEdit会计期间.EditValue.ToString().Trim();
                    if (s会计期间 == "")
                    {
                        lookUpEdit会计期间.Focus();
                        throw new Exception("会计期间不能为空");
                    }
                    string s部门 = lookUpEditcDepCode.EditValue.ToString().Trim();
                    if (s部门 == "")
                    {
                        lookUpEdit会计期间.Focus();
                        throw new Exception("部门不能为空");
                    }

                    string sSQL = "select count(1) from _费用分配 where 会计期间 = '111111' and isnull(审核人,'') <> '' and 部门编码 = '222222'";
                    sSQL = sSQL.Replace("111111", s会计期间);
                    sSQL = sSQL.Replace("222222", s部门);

                    int iCount = BaseFunction.ReturnInt(DbHelperSQL.ExecuteDataset(tran, CommandType.Text, sSQL).Tables[0].Rows[0][0]);
                    if (iCount > 0)
                        throw new Exception("已经审核不能删除");

                    sSQL = "delete _费用分配 where  会计期间 = '111111' and 部门编码 = '222222'";
                    sSQL = sSQL.Replace("111111", s会计期间);
                    sSQL = sSQL.Replace("222222", s部门);
                    iCou = DbHelperSQL.ExecuteNonQuery(tran, CommandType.Text, sSQL);

                    tran.Commit();

                    GetGrid();

                    if (iCou > 0)
                    {
                        MessageBox.Show("删除成功");
                    }
                }
                catch (Exception error)
                {
                    tran.Rollback();
                    throw new Exception(error.Message);
                }
            }
            catch (Exception ee)
            {
                FrmMsgBox f = new FrmMsgBox();
                f.Text = "删除失败";
                f.richTextBox1.Text = ee.Message;
                f.ShowDialog();
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                try
                {
                    gridView1.FocusedRowHandle -= 1;
                    gridView1.FocusedRowHandle += 1;
                }
                catch { }

                if (gridView1.RowCount <= 0)
                {
                    throw new Exception("请设置数据后处理");
                }

                if (BaseFunction.ReturnDecimal(txt应摊能源费用.Text.Trim())<0 )
                    throw new Exception("请重新获得应摊能源费用");
                if (BaseFunction.ReturnDecimal(txt应摊工资费用.Text.Trim()) < 0)
                    throw new Exception("请重新获得应摊工资费用");
                if (BaseFunction.ReturnDecimal(txt应摊制造费用.Text.Trim()) < 0)
                    throw new Exception("请重新获得应摊制造费用");


                decimal d1 = 0;
                decimal d2 = 0;
                decimal d3 = 0;
                for (int i = 0; i < gridView1.RowCount; i++)
                {
                    int iType = BaseFunction.ReturnInt(gridView1.GetRowCellValue(i, gridCol行类型));
                    if (iType == 2)
                        continue;

                    d1 = d1 + BaseFunction.ReturnDecimal(gridView1.GetRowCellValue(i, gridCol应摊能源费用行));
                    d2 = d2 + BaseFunction.ReturnDecimal(gridView1.GetRowCellValue(i, gridCol应摊工资费用行));
                    d3 = d3 + BaseFunction.ReturnDecimal(gridView1.GetRowCellValue(i, gridCol应摊制造费用行));
                }

                txt应摊工资费用_汇总.Text = d2.ToString();
                txt应摊能源费用_汇总.Text = d1.ToString();
                txt应摊制造费用_汇总.Text = d3.ToString();

                if (BaseFunction.ReturnDecimal(txt应摊能源费用.Text.Trim()) != d1)
                    throw new Exception("应摊能源费用分配不正确");
                if (BaseFunction.ReturnDecimal(txt应摊工资费用.Text.Trim()) != d2)
                    throw new Exception("应摊工资费用分配不正确");
                if (BaseFunction.ReturnDecimal(txt应摊制造费用.Text.Trim()) != d3)
                    throw new Exception("应摊制造费用分配不正确");

                string sErr = "";
                int iCou = 0;
                SqlConnection conn = new SqlConnection(DbHelperSQL.connectionString);
                conn.Open();
                //启用事务
                SqlTransaction tran = conn.BeginTransaction();
                try
                {
                    string s会计期间 = lookUpEdit会计期间.EditValue.ToString().Trim();
                    if (s会计期间 == "")
                    {
                        lookUpEdit会计期间.Focus();
                        throw new Exception("会计期间不能为空");
                    }

                    string s部门 = lookUpEditcDepCode.EditValue.ToString().Trim();
                    if (s部门 == "")
                    {
                        lookUpEditcDepCode.Focus();
                        throw new Exception("部门不能为空");
                    }

                    string sSQL = "select count(1) from _费用分配 where 会计期间 = '111111' and isnull(审核人,'') <> '' and 部门编码 = '222222'";
                    sSQL = sSQL.Replace("111111", s会计期间);
                    sSQL = sSQL.Replace("222222", s部门);
                    int iCount = BaseFunction.ReturnInt(DbHelperSQL.ExecuteDataset(tran, CommandType.Text, sSQL).Tables[0].Rows[0][0]);
                    if (iCount > 0)
                        throw new Exception("已经审核不能修改");

                    string s下一会计期间 = BaseFunction.ReturnDate(lookUpEdit会计期间.Text.Trim() + "-01").AddMonths(1).ToString("yyyy-MM");

                    sSQL = "delete _费用分配 where 会计期间 = '111111' and 部门编码 = '222222'";
                    sSQL = sSQL.Replace("111111", s会计期间);
                    sSQL = sSQL.Replace("222222", s部门);
                    DbHelperSQL.ExecuteNonQuery(tran, CommandType.Text, sSQL);


                    for (int i = 0; i < gridView1.RowCount; i++)
                    {
                        if (gridView1.GetRowCellValue(i, gridCol存货编码).ToString().Trim() == "" && BaseFunction.ReturnInt(gridView1.GetRowCellValue(i, gridCol行类型))!=0)
                            continue;

                        Model._费用分配 model = new UFIDA.U8.UAP.CustomApp.ControlForm.Model._费用分配();
                        model.会计期间 = s会计期间;
                        model.部门编码 = s部门;
                        model.应摊能源费用 = BaseFunction.ReturnDecimal(txt应摊能源费用.Text.Trim());
                        model.应摊工资费用 = BaseFunction.ReturnDecimal(txt应摊工资费用.Text.Trim());
                        model.应摊制造费用 = BaseFunction.ReturnDecimal(txt应摊制造费用.Text.Trim());
                        //model.合计分摊 = 

                        string s存货编码 = gridView1.GetRowCellValue(i, gridCol存货编码).ToString().Trim();
                        model.行类型 = BaseFunction.ReturnInt(gridView1.GetRowCellValue(i, gridCol行类型));

                        if (model.行类型 == 0)
                        {
                            s存货编码 = s存货编码.Replace("调整：", "");
                            model.存货编码 = "调整：" + s存货编码;
                        }
                        else
                        {
                            model.存货编码 = s存货编码;
                        }

                        model.生产工时 = BaseFunction.ReturnDecimal(gridView1.GetRowCellValue(i, gridCol生产工时));
                        model.冻干工时 = BaseFunction.ReturnDecimal(gridView1.GetRowCellValue(i, gridCol冻干工时));
                        model.应摊能源费用行 = BaseFunction.ReturnDecimal(gridView1.GetRowCellValue(i, gridCol应摊能源费用行));
                        model.应摊工资费用行 = BaseFunction.ReturnDecimal(gridView1.GetRowCellValue(i, gridCol应摊工资费用行));
                        model.应摊制造费用行 = BaseFunction.ReturnDecimal(gridView1.GetRowCellValue(i, gridCol应摊制造费用行));
                        model.合计分摊 = BaseFunction.ReturnDecimal(gridView1.GetRowCellValue(i, gridCol合计分摊));


                        model.制单人 = sUserName;
                        model.制单日期 = DateTime.Now;

                        DAL._费用分配 dal = new UFIDA.U8.UAP.CustomApp.ControlForm.DAL._费用分配();
                        sSQL = dal.Add(model);

                        iCou = iCou + DbHelperSQL.ExecuteNonQuery(tran, CommandType.Text, sSQL);

                        //Model._QCCost modQCCost = new UFIDA.U8.UAP.CustomApp.ControlForm.Model._QCCost();
                        //modQCCost.部门 = s部门;
                        //modQCCost.会计期间 = s下一会计期间;
                        //modQCCost.产品编码 = model.存货编码;
                   

                        //DAL._QCCost dalQccost = new UFIDA.U8.UAP.CustomApp.ControlForm.DAL._QCCost();
                        //sSQL = dalQccost.Add(modQCCost);
                        //DbHelperSQL.ExecuteNonQuery(tran, CommandType.Text, sSQL);

                        sSQL = "update _能源分配 set 记账人 = '" + sUserName + "',记账日期 = getdate() where 会计期间 = '111111' and 部门编码 = '222222'";
                        sSQL = sSQL.Replace("111111", s会计期间);
                        sSQL = sSQL.Replace("222222", s部门);
                        DbHelperSQL.ExecuteNonQuery(tran, CommandType.Text, sSQL);
                    }

                    tran.Commit();

                    GetGrid();

                    if (iCou > 0)
                    {
                        MessageBox.Show("保存成功");
                    }
                }
                catch (Exception error)
                {
                    tran.Rollback();
                    throw new Exception(error.Message);
                }
            }
            catch (Exception ee)
            {
                FrmMsgBox f = new FrmMsgBox();
                f.Text = "保存失败";
                f.richTextBox1.Text = ee.Message;
                f.ShowDialog();
            }
        }


        private void GetGrid()
        {
            try
            {
                lAudit.Text = "";

                SetEnable(true);

                if (lookUpEdit会计期间.EditValue == null || lookUpEdit会计期间.EditValue.ToString().Trim() == "")
                {
                    throw new Exception("请选择会计期间");
                }

                if (lookUpEditcDepCode.EditValue == null || lookUpEditcDepCode.EditValue.ToString().Trim() == "")
                {
                    throw new Exception("请选择部门");
                }

                string sSQL = @"
select * from dbo._能源分配 where 会计期间 = '111111' and 部门编码 = '222222' and isnull(审核人,'') <> ''
";
                sSQL = sSQL.Replace("111111", lookUpEdit会计期间.EditValue.ToString());
                sSQL = sSQL.Replace("222222", lookUpEditcDepCode.EditValue.ToString());
                DataTable dt = DbHelperSQL.Query(sSQL);
                if (dt == null || dt.Rows.Count == 0)
                {
                    throw new Exception("请先进行能源分配");
                }

                txt应摊能源费用.Text = dt.Rows[0]["合计"].ToString().Trim();

                sSQL = @"
select count(1) from _费用分配 where 会计期间 = '111111' and 部门编码 = '222222'
";
                sSQL = sSQL.Replace("111111", lookUpEdit会计期间.EditValue.ToString());
                sSQL = sSQL.Replace("222222", lookUpEditcDepCode.EditValue.ToString());
                int iCou = BaseFunction.ReturnInt(DbHelperSQL.GetSingle(sSQL));
                
                if (iCou > 0)
                {
                    sSQL = @"
select a.*,case when isnull(e.调整名称,'') <> '' then e.调整名称 else d.cInvName end as 存货名称
from [dbo].[_费用分配] a left join Department b on a.部门编码 = b.cDepCode
	left join Inventory d on a.存货编码 = d.cInvCode
    left join _调整类型_成本分配 e on e.调整编码 = a.存货编码
where a.会计期间 = '111111' and a.部门编码 = '222222'
order by a.部门编码,a.存货编码,行类型 desc
";
                    sSQL = sSQL.Replace("111111", lookUpEdit会计期间.EditValue.ToString());
                    sSQL = sSQL.Replace("222222", lookUpEditcDepCode.EditValue.ToString());
                    dt = DbHelperSQL.Query(sSQL);
                    gridControl1.DataSource = dt;

                    txt应摊工资费用.Text = dt.Rows[0]["应摊工资费用"].ToString().Trim();
                    txt应摊能源费用.Text =dt.Rows[0]["应摊能源费用"].ToString().Trim();
                    txt应摊制造费用.Text = dt.Rows[0]["应摊制造费用"].ToString().Trim();

                    if (dt.Rows[0]["审核人"].ToString().Trim() != "")
                    {
                        lAudit.Text = "已审核";

                        SetEnable(false);
                    }
                }

                else
                {

                    SetEnable(true);

                    sSQL = @"
select *
from
(
select distinct a.会计期间,a.部门 as 部门编码,b.应摊能源费用, b.应摊工资费用, b.应摊制造费用, b.合计分摊, a.产品编码 as 存货编码 

                   ,isnull(a.工时,0) as 生产工时,b.应摊能源费用行, b.应摊工资费用行, b.应摊制造费用行, b.合计分摊行
                   ,isnull(a. 冻干完工工时,0) as 冻干工时
                   , b.制单人, b.制单日期, b.审核人, b.审核日期, b.记账人 
                   ,b.记账日期,1 as 行类型,d.cInvName as 存货名称
from [dbo].[_ProMaterial] a left join [dbo].[_费用分配] b on a.部门 = b.部门编码 and a.会计期间 = b.会计期间 and a.产品编码 = b.存货编码
	left join Department c on a.部门 = c.cDepCode
	left join Inventory d on a.产品编码 = d.cInvCode
where a.会计期间 = '111111' and a.部门 = '222222'
	and (isnull(a.工时,0) <> 0 or isnull(a.冻干完工工时,0) <> 0)
union

select distinct a.会计期间,a.部门 as 部门编码,b.应摊能源费用, b.应摊工资费用, b.应摊制造费用, b.合计分摊, a.产品编码 as 存货编码 

                   ,isnull(a.未完工工时,0) as 生产工时,b.应摊能源费用行, b.应摊工资费用行, b.应摊制造费用行, b.合计分摊行
                   ,isnull(a. 冻干未完工工时,0) as 冻干工时
                   , b.制单人, b.制单日期, b.审核人, b.审核日期, b.记账人 
                   ,b.记账日期,-1 as 行类型,d.cInvName as 存货名称
from [dbo].[_ProMaterial] a left join [dbo].[_费用分配] b on a.部门 = b.部门编码 and a.会计期间 = b.会计期间 and a.产品编码 = b.存货编码
	left join Department c on a.部门 = c.cDepCode
	left join Inventory d on a.产品编码 = d.cInvCode
where a.会计期间 = '111111' and a.部门 = '222222'
	and (isnull(a.未完工工时,0) <> 0 or isnull(a.冻干未完工工时,0) <> 0)
union


select a.会计期间, a.部门编码, a.应摊能源费用, a.应摊工资费用, a.应摊制造费用, a.合计分摊, a.存货编码, a.生产工时,  
                   a.应摊能源费用行, a.应摊工资费用行, a.应摊制造费用行, a.合计分摊行,a.冻干工时
				   , null as 制单人, null as 制单日期, null as 审核人,null as  审核日期,null as 记账人, 
                   a.记账日期,2 as 行类型, b.cInvName as 存货名称

from [dbo].[_费用分配] a inner join Inventory b on a.存货编码 = b.cInvCode
where 会计期间 = '333333' and 行类型 = -1  and a.部门编码 = '222222'
)a 
order by a.存货编码,行类型 desc
";
                    sSQL = sSQL.Replace("111111", lookUpEdit会计期间.EditValue.ToString());
                    sSQL = sSQL.Replace("222222", lookUpEditcDepCode.EditValue.ToString());
                    sSQL = sSQL.Replace("333333", BaseFunction.ReturnDate((lookUpEdit会计期间.EditValue.ToString() + "-01")).AddMonths(-1).ToString("yyyy-MM"));
                    dt = DbHelperSQL.Query(sSQL);
                    gridControl1.DataSource = dt;

                    txt应摊工资费用.Text = "";
                    txt应摊制造费用.Text = "";
                }
            }
            catch (Exception ee)
            {
                throw new Exception(ee.Message);
            }
        }

        private void lookUpEditCostType_EditValueChanged(object sender, EventArgs e)
        {
            try
            {
                GetGrid();
            }
            catch (Exception ee)
            {
                MessageBox.Show(ee.Message);
            }
        }

        private void btnAudit_Click(object sender, EventArgs e)
        {
            try
            {
                try
                {
                    gridView1.FocusedRowHandle -= 1;
                    gridView1.FocusedRowHandle += 1;
                }
                catch { }

                string sErr = "";
                int iCou = 0;
                SqlConnection conn = new SqlConnection(DbHelperSQL.connectionString);
                conn.Open();
                //启用事务
                SqlTransaction tran = conn.BeginTransaction();
                try
                {

                    string s会计期间 = lookUpEdit会计期间.EditValue.ToString().Trim();
                    if (s会计期间 == "")
                    {
                        lookUpEdit会计期间.Focus();
                        throw new Exception("会计期间不能为空");
                    }

                    string s部门 = lookUpEditcDepCode.EditValue.ToString().Trim();
                    if (s部门 == "")
                    {
                        lookUpEditcDepCode.Focus();
                        throw new Exception("部门不能为空");
                    }

                    string sSQL = "select count(1) from _费用分配 where 会计期间 = '111111' and isnull(审核人,'') <> '' and 部门编码 = '222222'";
                    sSQL = sSQL.Replace("111111", s会计期间);
                    sSQL = sSQL.Replace("222222", s部门);
                    int iCount = BaseFunction.ReturnInt(DbHelperSQL.ExecuteDataset(tran, CommandType.Text, sSQL).Tables[0].Rows[0][0]);
                    if (iCount > 0)
                        throw new Exception("已经审核");

                    sSQL = "update _费用分配 set 审核人 = '" + sUserName + "' ,审核日期 = getdate() where 会计期间 = '111111' and 部门编码 = '222222'";
                    sSQL = sSQL.Replace("111111", s会计期间);
                    sSQL = sSQL.Replace("222222", s部门);
                    iCou = DbHelperSQL.ExecuteNonQuery(tran, CommandType.Text, sSQL);

                    tran.Commit();

                    GetGrid();

                    if (iCou > 0)
                    {
                        MessageBox.Show("审核成功");
                    }
                }
                catch (Exception error)
                {
                    tran.Rollback();
                    throw new Exception(error.Message);
                }
            }
            catch (Exception ee)
            {
                FrmMsgBox f = new FrmMsgBox();
                f.Text = "删除失败";
                f.richTextBox1.Text = ee.Message;
                f.ShowDialog();
            }
        }

        private void btnUnAudit_Click(object sender, EventArgs e)
        {
            try
            {
                try
                {
                    gridView1.FocusedRowHandle -= 1;
                    gridView1.FocusedRowHandle += 1;
                }
                catch { }

                string sErr = "";
                int iCou = 0;
                SqlConnection conn = new SqlConnection(DbHelperSQL.connectionString);
                conn.Open();
                //启用事务
                SqlTransaction tran = conn.BeginTransaction();
                try
                {

                    string s会计期间 = lookUpEdit会计期间.EditValue.ToString().Trim();
                    if (s会计期间 == "")
                    {
                        lookUpEdit会计期间.Focus();
                        throw new Exception("会计期间不能为空");
                    }

                    string s部门 = lookUpEditcDepCode.EditValue.ToString().Trim();
                    if (s部门 == "")
                    {
                        lookUpEditcDepCode.Focus();
                        throw new Exception("部门不能为空");
                    }

                    string sSQL = "select count(1) from _费用分配 where 会计期间 = '111111' and isnull(审核人,'') = '' and 部门编码 = '222222'";
                    sSQL = sSQL.Replace("111111", s会计期间);
                    sSQL = sSQL.Replace("222222", s部门);
                    int iCount = BaseFunction.ReturnInt(DbHelperSQL.ExecuteDataset(tran, CommandType.Text, sSQL).Tables[0].Rows[0][0]);
                    if (iCount > 0)
                        throw new Exception("尚未审核");

                    sSQL = "select count(1) from _费用分配 where 会计期间 = '111111' and isnull(记账人,'') <> '' and 部门编码 = '222222'";
                    sSQL = sSQL.Replace("111111", s会计期间);
                    sSQL = sSQL.Replace("222222", s部门);
                    iCount = BaseFunction.ReturnInt(DbHelperSQL.ExecuteDataset(tran, CommandType.Text, sSQL).Tables[0].Rows[0][0]);
                    if (iCount > 0)
                        throw new Exception("已经记账");

                    sSQL = "update _费用分配 set 审核人 = null ,审核日期 = null where 会计期间 = '111111' and 部门编码 = '222222'";
                    sSQL = sSQL.Replace("111111", s会计期间);
                    sSQL = sSQL.Replace("222222", s部门);
                    iCou = DbHelperSQL.ExecuteNonQuery(tran, CommandType.Text, sSQL);

                    tran.Commit();

                    GetGrid();

                    if (iCou > 0)
                    {
                        MessageBox.Show("弃审成功");
                    }
                }
                catch (Exception error)
                {
                    tran.Rollback();
                    throw new Exception(error.Message);
                }
            }
            catch (Exception ee)
            {
                FrmMsgBox f = new FrmMsgBox();
                f.Text = "删除失败";
                f.richTextBox1.Text = ee.Message;
                f.ShowDialog();
            }
        }

        private void btn刷新_Click(object sender, EventArgs e)
        {
            try
            {
                GetGrid();
            }
            catch (Exception ee)
            {
                MessageBox.Show(ee.Message);
            }
        }

        private void lookUpEditcDepCode_EditValueChanged(object sender, EventArgs e)
        {
            try
            {
                if (lookUpEditcDepCode.EditValue != null && (lookUpEditcDepCode.EditValue.ToString().Trim() == "0803" || lookUpEditcDepCode.EditValue.ToString().Trim() == "0808"))
                {
                    gridCol冻干工时.Visible = true;
                }
                else
                {
                    gridCol冻干工时.Visible = false;
                }

                lookUpEditcDepName.EditValue = lookUpEditcDepCode.EditValue;
                GetGrid();
            }
            catch { }
        }

        private void lookUpEditcDepName_EditValueChanged(object sender, EventArgs e)
        {
            try
            {
                lookUpEditcDepCode.EditValue = lookUpEditcDepName.EditValue;
            }
            catch { }
        }

        private void btnAddRow_Click(object sender, EventArgs e)
        {
            try
            {
                gridView1.AddNewRow();
            }
            catch { }
        }

        private void btnDelRow_Click(object sender, EventArgs e)
        {
            try
            {
                int iRow = gridView1.FocusedRowHandle;
                int iType = BaseFunction.ReturnInt(gridView1.GetRowCellValue(iRow, gridCol行类型));
                if (iType == 0)
                {
                    gridView1.DeleteRow(iRow);
                }
            }
            catch { }
        }

        private void gridView1_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            try
            {
                //int iType = BaseFunction.ReturnInt(gridView1.GetRowCellValue(gridView1.FocusedRowHandle, gridCol行类型));
                //if (iType == 1 || iType == -1)
                //{
                //    gridCol存货编码.OptionsColumn.AllowEdit = false;
                //    gridCol存货名称.OptionsColumn.AllowEdit = false;
                //    gridCol生产工时.OptionsColumn.AllowEdit = true;
                //}
                //else
                //{
                //    gridCol存货编码.OptionsColumn.AllowEdit = true;
                //    gridCol存货名称.OptionsColumn.AllowEdit = false;
                //    gridCol生产工时.OptionsColumn.AllowEdit = false;
                //}
                gridCol存货编码.OptionsColumn.AllowEdit = true;
                gridCol存货名称.OptionsColumn.AllowEdit = true;
                gridCol生产工时.OptionsColumn.AllowEdit = true;
                gridCol冻干工时.OptionsColumn.AllowEdit = true;
            }
            catch (Exception ee)
            {
                MessageBox.Show(ee.Message);
            }
        }

        private void btn分配_Click(object sender, EventArgs e)
        {
            try
            {
                try
                {
                    gridView1.FocusedRowHandle -= 1;
                    gridView1.FocusedRowHandle += 1;
                }
                catch { }

                decimal d应摊能源扣项 = 0;
                decimal d应摊工资扣项 = 0;
                decimal d应摊制造费用扣项 = 0;
                decimal d生产工时应扣项 = 0;
                decimal d冻干工时应扣项 = 0;

                //上月结转不参与本月计算
                for (int i = 0; i < gridView1.RowCount; i++)
                {
                    int iType = BaseFunction.ReturnInt(gridView1.GetRowCellValue(i, gridCol行类型));
                    if (iType == 2)
                    {
                    //    d应摊能源扣项 = d应摊能源扣项 + BaseFunction.ReturnDecimal(gridView1.GetRowCellValue(i, gridCol应摊能源费用行));
                    //    d应摊工资扣项 = d应摊工资扣项 + BaseFunction.ReturnDecimal(gridView1.GetRowCellValue(i, gridCol应摊工资费用行));
                    //    d应摊制造费用扣项 = d应摊制造费用扣项 + BaseFunction.ReturnDecimal(gridView1.GetRowCellValue(i, gridCol应摊制造费用行));
                        d生产工时应扣项 = d生产工时应扣项 + BaseFunction.ReturnDecimal(gridView1.GetRowCellValue(i, gridCol生产工时));
                        d冻干工时应扣项 = d冻干工时应扣项 + BaseFunction.ReturnDecimal(gridView1.GetRowCellValue(i, gridCol冻干工时));
                    }
                    if (iType == 3)
                    {
                        d应摊能源扣项 = d应摊能源扣项 + BaseFunction.ReturnDecimal(gridView1.GetRowCellValue(i, gridCol应摊能源费用行));
                        d应摊工资扣项 = d应摊工资扣项 + BaseFunction.ReturnDecimal(gridView1.GetRowCellValue(i, gridCol应摊工资费用行));
                        d应摊制造费用扣项 = d应摊制造费用扣项 + BaseFunction.ReturnDecimal(gridView1.GetRowCellValue(i, gridCol应摊制造费用行));
                        d生产工时应扣项 = d生产工时应扣项 + BaseFunction.ReturnDecimal(gridView1.GetRowCellValue(i, gridCol生产工时));
                        d冻干工时应扣项 = d冻干工时应扣项 + BaseFunction.ReturnDecimal(gridView1.GetRowCellValue(i, gridCol冻干工时));
                    }
                }

                decimal d应摊能源值 = BaseFunction.ReturnDecimal(txt应摊能源费用.Text.Trim());
                decimal d应摊工资值 = BaseFunction.ReturnDecimal(txt应摊工资费用.Text.Trim());
                decimal d应摊制造费用值 = BaseFunction.ReturnDecimal(txt应摊制造费用.Text.Trim());

                d应摊能源值 = d应摊能源值 - d应摊能源扣项;
                d应摊工资值 = d应摊工资值 - d应摊工资扣项;
                d应摊制造费用值 = d应摊制造费用值 - d应摊制造费用扣项;

                decimal d生产总工时 = BaseFunction.ReturnDecimal(gridView1.Columns["生产工时"].SummaryItem.SummaryValue) - d生产工时应扣项;
                decimal d冻干总工时 = BaseFunction.ReturnDecimal(gridView1.Columns["冻干工时"].SummaryItem.SummaryValue) - d冻干工时应扣项;

                if (lookUpEditcDepCode.EditValue.ToString() == "0803" || lookUpEditcDepCode.EditValue.ToString() == "0808")
                {
                    for (int i = 0; i < gridView1.RowCount; i++)
                    {
                        int iType = BaseFunction.ReturnInt(gridView1.GetRowCellValue(i, gridCol行类型));
                        if (iType == 2 || iType == 3)
                            continue;

                        decimal d生产工时 = BaseFunction.ReturnDecimal(gridView1.GetRowCellValue(i, gridCol生产工时));
                        decimal d冻干工时 = BaseFunction.ReturnDecimal(gridView1.GetRowCellValue(i, gridCol冻干工时));

                        if (d冻干总工时 != 0)
                        {
                            decimal d能源金额 = BaseFunction.ReturnDecimal(d应摊能源值 * d冻干工时 / d冻干总工时, 2);
                            gridView1.SetRowCellValue(i, gridCol应摊能源费用行, d能源金额);

                            decimal d制造费用金额 = BaseFunction.ReturnDecimal(d应摊制造费用值 * d冻干工时 / d冻干总工时, 2);
                            gridView1.SetRowCellValue(i, gridCol应摊制造费用行, d制造费用金额);
                        }

                        if (d生产总工时 != 0)
                        {
                            decimal d工资金额 = BaseFunction.ReturnDecimal(d应摊工资值 * d生产工时 / d生产总工时, 2);
                            gridView1.SetRowCellValue(i, gridCol应摊工资费用行, d工资金额);
                        }
                    }
                }
                else
                {
                    for (int i = 0; i < gridView1.RowCount; i++)
                    {
                        int iType = BaseFunction.ReturnInt(gridView1.GetRowCellValue(i, gridCol行类型));
                        if (iType == 2 || iType == 3)
                            continue;

                        if (d生产总工时 == 0)
                            continue;

                        decimal d生产工时 = BaseFunction.ReturnDecimal(gridView1.GetRowCellValue(i, gridCol生产工时));

                        decimal d能源金额 = BaseFunction.ReturnDecimal(d应摊能源值 * d生产工时 / d生产总工时, 2);
                        gridView1.SetRowCellValue(i, gridCol应摊能源费用行, d能源金额);


                        decimal d工资金额 = BaseFunction.ReturnDecimal(d应摊工资值 * d生产工时 / d生产总工时, 2);
                        gridView1.SetRowCellValue(i, gridCol应摊工资费用行, d工资金额);

                        decimal d制造费用金额 = BaseFunction.ReturnDecimal(d应摊制造费用值 * d生产工时 / d生产总工时, 2);
                        gridView1.SetRowCellValue(i, gridCol应摊制造费用行, d制造费用金额);
                    }
                }


                gridView1.FocusedRowHandle = 0;

                txt应摊工资费用_汇总.Text = d应摊工资值.ToString();
                txt应摊制造费用_汇总.Text = d应摊制造费用值.ToString();
                txt应摊能源费用_汇总.Text = d应摊能源值.ToString();
            }
            catch (Exception ee)
            {
                MessageBox.Show(ee.Message);
            }
        }

        private void gridView1_RowCellStyle(object sender, DevExpress.XtraGrid.Views.Grid.RowCellStyleEventArgs e)
        {
            try
            {
                int iType = BaseFunction.ReturnInt(gridView1.GetRowCellValue(e.RowHandle, gridCol行类型));
                if (iType == -1)
                {
                    e.Appearance.BackColor = Color.Yellow;
                }
                if (iType == 0)
                {
                    e.Appearance.BackColor = Color.LightGray;
                }
                if (iType == 2)
                {
                    e.Appearance.BackColor = Color.Gray;
                }
            }
            catch { }
        }

        private void gridView1_CellValueChanged(object sender, DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs e)
        {
            try
            {
                if (e.Column == gridCol应摊能源费用行 || e.Column == gridCol应摊制造费用行 || e.Column == gridCol应摊工资费用行)
                {
                    decimal d1 = BaseFunction.ReturnDecimal(gridView1.GetRowCellValue(e.RowHandle, gridCol应摊能源费用行));
                    decimal d2 = BaseFunction.ReturnDecimal(gridView1.GetRowCellValue(e.RowHandle, gridCol应摊制造费用行));
                    decimal d3 = BaseFunction.ReturnDecimal(gridView1.GetRowCellValue(e.RowHandle, gridCol应摊工资费用行));

                    gridView1.SetRowCellValue(e.RowHandle, gridCol合计分摊, d1 + d2 + d3);
                }

                if (e.Column == gridCol存货编码)
                {
                    int i = BaseFunction.ReturnInt(gridView1.GetRowCellValue(e.RowHandle, gridCol行类型));
                    if (i == 0)
                    {
                        gridView1.SetRowCellValue(e.RowHandle, gridCol行类型, -1);
                        gridView1.FocusedColumn = gridCol存货编码;
                    }
                }
            }
            catch { }
        }

        private void btnExcel_Click(object sender, EventArgs e)
        {
            try
            {
                try
                {
                    gridView1.FocusedRowHandle -= 1;
                }
                catch { }

                SaveFileDialog sa = new SaveFileDialog();
                sa.Filter = "Excel文件2003|*.xls";
                sa.FileName = "费用分配";

                sa.ShowDialog();
                string sPath = sa.FileName;

                if (sPath.Trim() != string.Empty)
                {
                    gridView1.ExportToXls(sPath);
                    MessageBox.Show("导出列表成功！\n路径：" + sPath);
                }
            }
            catch (Exception ee)
            {
                throw new Exception("导出列表失败：" + ee.Message);
            }
        }

        private void ItemButtonEditInvCode_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            try
            {
                gridView1.FocusedColumn = gridCol存货编码;
                string sInvCode = gridView1.GetRowCellDisplayText(gridView1.FocusedRowHandle, gridCol存货编码).ToString().Trim();

                gridView1.FocusedColumn = gridCol存货编码;

                FrmInvInfo frm = new FrmInvInfo(sInvCode, false);
                DialogResult d = frm.ShowDialog();
                if (d == DialogResult.OK)
                {
                    gridView1.SetRowCellValue(gridView1.FocusedRowHandle, gridCol存货编码, frm.sInvCode);
                    gridView1.SetRowCellValue(gridView1.FocusedRowHandle, gridCol存货名称, frm.sInvName);
                }
            }
            catch (Exception ee)
            {
                MessageBox.Show("加载存货档案失败:" + ee.Message);
            }
        }

        private void SetEnable(bool b)
        {
            txt应摊工资费用.Enabled = b;
            txt应摊能源费用.Enabled = b;
            txt应摊制造费用.Enabled = b;

            gridView1.OptionsBehavior.Editable = b;

            btn分配.Enabled = b;
            btnAddRow.Enabled = b;
            btnDelRow.Enabled = b;
            btnDel.Enabled = b;
            btnSave.Enabled = b;
            btnAudit.Enabled = b;
            btnUnAudit.Enabled = !b;
        }
    }
}
