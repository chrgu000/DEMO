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
using System.Collections;

namespace UFIDA.U8.UAP.CustomApp.ControlForm
{
    public partial class GL_accvouch : UserControl
    {        
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
                DbHelperSQL.connectionString = Conn;

            }
            catch (Exception ee)
            {
                FrmMsgBox f = new FrmMsgBox();
                f.Text = "加载窗体失败";
                f.richTextBox1.Text = ee.Message;
                f.ShowDialog();
            }
        }

        public GL_accvouch()
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

                int iCount = 0;
                decimal d借sum = 0;
                decimal d贷sum = 0;

                string sErr = "";

                int iYear = BaseFunction.ReturnInt(txtYear.Text.Trim());
                int iMonth = BaseFunction.ReturnInt(txtMonth.Text.Trim());
                int i年期间 = BaseFunction.ReturnInt(Convert.ToDateTime(iYear.ToString() + "-" + iMonth.ToString() + "-01").ToString("yyyyMM"));

                SqlConnection conn = new SqlConnection(Conn);
                conn.Open();
                SqlTransaction tran = conn.BeginTransaction();
                try
                {
                    if (gridView1.RowCount == 0)
                    {
                        throw new Exception("请查询可导入凭证");
                    }
                    DataTable dt币种 = new DataTable();

 

                    string sSQL = "";
                    for (int i = 0; i < gridView1.RowCount; i++)
                    {
                        bool b = BaseFunction.ReturnBool(gridView1.GetRowCellValue(i, gridCol选择));
                        if (!b)
                            continue;

                        d借sum = d借sum + BaseFunction.ReturnDecimal(gridView1.GetRowCellValue(i, gridCol借方));
                        d贷sum = d贷sum + BaseFunction.ReturnDecimal(gridView1.GetRowCellValue(i, gridCol贷方));

                        bool bCheck = BaseFunction.ReturnBool(gridView1.GetRowCellValue(i, gridCol供应商核算));
                        if (bCheck)
                        {
                            string sCheck = gridView1.GetRowCellValue(i, gridCol供应商编码).ToString().Trim();
                            if (sCheck == "")
                            {
                                sErr = sErr + "行" + (i + 1).ToString() + " 供应商不能为空\n";

                            }
                        }

                        bCheck = BaseFunction.ReturnBool(gridView1.GetRowCellValue(i, gridCol客户核算));
                        if (bCheck)
                        {
                            string sCheck = gridView1.GetRowCellValue(i, gridCol客户编码).ToString().Trim();
                            if (sCheck == "")
                            {
                                sErr = sErr + "行" + (i + 1).ToString() + " 客户不能为空\n";

                            }
                        }

                        bCheck = BaseFunction.ReturnBool(gridView1.GetRowCellValue(i, gridCol部门核算));
                        if (bCheck)
                        {
                            string sCheck = gridView1.GetRowCellValue(i, gridCol部门编码).ToString().Trim();
                            if (sCheck == "")
                            {
                                sErr = sErr + "行" + (i + 1).ToString() + " 部门不能为空\n";

                            }
                        }

                        decimal d外币借方 = BaseFunction.ReturnDecimal(gridView1.GetRowCellValue(i, gridCol外币借方));
                        decimal d外币贷方 = BaseFunction.ReturnDecimal(gridView1.GetRowCellValue(i, gridCol外币贷方));
                        decimal d汇率 = BaseFunction.ReturnDecimal(gridView1.GetRowCellValue(i, gridCol汇率));
                        string s币种 = gridView1.GetRowCellValue(i, gridCol币种).ToString().Trim();
                        if (d外币借方 != 0 || d外币贷方 != 0)
                        {
                            if (s币种 == "")
                            {
                                sErr = sErr + "行" + (i + 1).ToString() + " 币种不能为空\n";
                            }
                            if (d汇率 == 0)
                            {
                                sErr = sErr + "行" + (i + 1).ToString() + " 汇率不能为0\n";
                            }
                        }
                    }

                    if (d借sum != d贷sum)
                    {
                        throw new Exception("借贷不平");
                    }

                    if (sErr.Trim() != "")
                    {
                        throw new Exception(sErr);
                    }

                    DataTable dt凭证 = (DataTable)gridControl1.DataSource;
                    sSQL = "select isnull(max(ino_id),0)  from GL_accvouch where iyear = aaaaaa AND iperiod = bbbbbb";
                    sSQL = sSQL.Replace("aaaaaa", txtYear.Text.ToString());
                    sSQL = sSQL.Replace("bbbbbb", txtMonth.Text.ToString());
                    DataTable dtinoid = DbHelperSQL.ExecuteDataset(tran, CommandType.Text, sSQL).Tables[0];
                    int ino_id = BaseFunction.ReturnInt(dtinoid.Rows[0][0]);

                    ArrayList aList = new ArrayList();


                    for (int j = 0; j < gridView1.RowCount; j++)
                    {
                        Model.GL_accvouch model = new UFIDA.U8.UAP.CustomApp.ControlForm.Model.GL_accvouch();
                        model.iperiod = BaseFunction.ReturnInt(txtMonth.Text.Trim());

                        string sSignSeq = gridView1.GetRowCellValue(j, gridCol凭证类别).ToString().Trim();
                        model.csign = gridView1.GetRowCellValue(j, gridCol凭证类别).ToString().Trim();

                        if (sSignSeq == "现")
                        {
                            model.isignseq = 1;
                        }
                        if (sSignSeq == "银")
                        {
                            model.isignseq = 2;
                        }
                        if (sSignSeq == "转")
                        {
                            model.isignseq = 3;
                        }
                        if (sSignSeq == "记")
                        {
                            model.isignseq = 4;
                        }
                        model.ino_id = BaseFunction.ReturnInt(gridView1.GetRowCellValue(j, gridCol凭证号));
                        model.inid = BaseFunction.ReturnInt(gridView1.GetRowCellValue(j, gridCol行号)); ;
                        model.dbill_date = BaseFunction.ReturnDate(gridView1.GetRowCellValue(j, gridCol制单日期));
                        model.idoc = -1;
                        model.cbill = gridView1.GetRowCellValue(j, gridCol制单人).ToString().Trim();
                        model.ibook = 0;
                        model.cdigest = gridView1.GetRowCellValue(j, gridCol摘要).ToString().Trim();
                        model.ccode = gridView1.GetRowCellValue(j, gridCol会计科目).ToString().Trim();
                        model.md = BaseFunction.ReturnDecimal(gridView1.GetRowCellValue(j, gridCol借方));
                        model.mc = BaseFunction.ReturnDecimal(gridView1.GetRowCellValue(j, gridCol贷方));
                        model.md_f = BaseFunction.ReturnDecimal(gridView1.GetRowCellValue(j, gridCol外币借方));
                        model.mc_f = BaseFunction.ReturnDecimal(gridView1.GetRowCellValue(j, gridCol外币贷方));
                        model.nfrat = BaseFunction.ReturnDecimal(gridView1.GetRowCellValue(j, gridCol汇率));
                        model.nd_s = 0;
                        model.nc_s = 0;
                        //model.csettle = "";     //结算方式
                        //model.cn_id
                        //model.dt_date = 

                        DataRow[] dr凭证;
                        if (model.md > 0)
                        {
                            string s = "贷方>0 and 凭证类别 = '" + model.csign + "' and 凭证号 = '" + gridView1.GetRowCellValue(j, gridCol凭证号).ToString() + "'";
                            dr凭证 = dt凭证.Select(s);
                        }
                        else
                        {
                            string s = "借方>0 and 凭证类别 = '" + model.csign + "' and 凭证号 = '" + gridView1.GetRowCellValue(j, gridCol凭证号).ToString() + "'";
                            dr凭证 = dt凭证.Select(s);
                        }
                        string s对方科目 = "";
                        for (int k = 0; k < dr凭证.Length; k++)
                        {
                            if (s对方科目 == "")
                            {
                                s对方科目 = dr凭证[k]["会计科目"].ToString().Trim();
                            }
                            else
                            {
                                if (s对方科目.IndexOf(dr凭证[k]["会计科目"].ToString().Trim()) < 0)
                                {
                                    s对方科目 = s对方科目 + "," + dr凭证[k]["会计科目"].ToString().Trim();
                                }
                            }
                        }

                        if (s对方科目.Length <= 50)
                        {
                            model.ccode_equal = s对方科目;
                        }
                        model.bdelete = false;
                        model.doutbilldate = model.dbill_date;
                        model.bvouchedit = true;
                        model.bvouchAddordele = false;
                        model.bvouchmoneyhold = false;
                        model.bvalueedit = true;
                        model.bcodeedit = true;
                        model.bPCSedit = true;
                        model.bDeptedit = true;
                        model.bItemedit = true;
                        model.bCusSupInput = false;
                        model.bFlagOut = false;
                        model.RowGuid = Guid.NewGuid().ToString();
                        model.iyear = BaseFunction.ReturnInt(txtYear.Text.Trim());
                        model.iYPeriod = i年期间;
                        model.tvouchtime = DateTime.Now;

                        //if (s对方科目.Length <= 100)
                        //{
                            model.ccodeexch_equal = s对方科目;
                        //}
                        if (gridView1.GetRowCellValue(j, gridCol客户编码).ToString() != "")
                        {
                            model.ccus_id = gridView1.GetRowCellValue(j, gridCol客户编码).ToString();
                        }
                        if (gridView1.GetRowCellValue(j, gridCol供应商编码).ToString() != "")
                        {
                            model.csup_id = gridView1.GetRowCellValue(j, gridCol供应商编码).ToString();
                        }


                        DAL.GL_accvouch dal = new UFIDA.U8.UAP.CustomApp.ControlForm.DAL.GL_accvouch();
                        sSQL = dal.Add(model);
                        iCount = iCount + DbHelperSQL.ExecuteNonQuery(tran, CommandType.Text, sSQL);
                    }

                    if (sErr.Length > 0)
                    {
                        throw new Exception(sErr);
                    }

                    if (iCount > 0)
                    {
                        tran.Commit();
                        MessageBox.Show("保存成功");
                    }
                    else
                    {
                        throw new Exception("没有数据");
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
                FrmMsgBox f = new FrmMsgBox();
                f.Text = "提示";
                f.richTextBox1.Text = ee.Message;
                f.ShowDialog();
            }
        }

        private void btnLoad_Click(object sender, EventArgs e)
        {

            try
            {
                string sSQL = "select cDepCode,cDepName from Department order by cDepCode";
                DataTable dt = DbHelperSQL.Query(sSQL);
                DataRow dr = dt.NewRow();
                dt.Rows.InsertAt(dr, 0);
                ItemLookUpEditcDepCode.DataSource = dt;
                ItemLookUpEditcDepName.DataSource = dt;

                sSQL = "select cVenCode,cVenName from Vendor order by cVenCode";
                dt = DbHelperSQL.Query(sSQL);
                dr = dt.NewRow();
                dt.Rows.InsertAt(dr, 0);
                ItemLookUpEditcVenCode.DataSource = dt;
                ItemLookUpEditcVenName.DataSource = dt;

                sSQL = "select cCusCode,cCusName from Customer order by cCusCode";
                dt = DbHelperSQL.Query(sSQL);
                dr = dt.NewRow();
                dt.Rows.InsertAt(dr, 0);
                ItemLookUpEditcCusCode.DataSource = dt;
                ItemLookUpEditcCusName.DataSource = dt;


                string sYear = txtYear.Text.Trim();
                string sMonth = txtMonth.Text.Trim();
                string sXZD = txtXZDTableName.Text.Trim();

                sSQL = @"
select distinct cast(1 as bit) as 选择
    ,id
	,case when pzlx = 2 then '银' when pzlx = 3 then '转' when pzlx = 1 then '现' end as 凭证类别
	, PZH as 凭证号,cast(null as int) as 行号,zy as 摘要,kmdm as 会计科目,code.ccode_name  as 科目名称
	,j as 借方,d as 贷方
	,case when ISNULL(j,0) <> 0 then WBJE end as 外币借方,case when ISNULL(d,0) <> 0 then WBJE end as 外币贷方
	
    ,case when isnull(HL,0)> 7 then '欧元' when isnull(HL,0)> 6 then '美元' when isnull(HL,0)> 4 then '新币' end as 币种 
    ,HL as 汇率,BMRY as 部门编码,dep.cDepName as 部门名称
	,a.dqh, a.DWDM, b.pydm_,b.dwmc
	,case when cast(isnull(code.bcus,0) as bit) = 1 then cus.cCusCode else null end as 客户编码 ,case when cast(isnull(code.bcus,0) as bit) = 1 then cus.cCusName else null end as 客户名称
	,case when cast(isnull(code.bsup,0) as bit) = 1 then ven.cVenCode else null end as 供应商编码,case when cast(isnull(code.bsup,0) as bit) = 1 then ven.cVenName else null end as 供应商名称
	,ZDY as 制单人,PZRQ as 制单日期,2016 as 年度,'01' as 期间
    ,cast(isnull(code.bperson,0) as bit) as 个人核算,cast(isnull(code.bcus,0) as bit)  as 客户核算,cast(isnull(code.bsup,0) as bit) as 供应商核算
    ,cast(isnull(code.bdept,0) as bit)  as 部门核算,cast(isnull(code.bitem,0) as bit) as 项目核算
from XZDBBBBBB..z_pzAAAAAA a
	left join UFDATA_001_BBBBBB..Department dep on a.BMRY = dep.cDepCode
	left join XZDBBBBBB..dwtx b on a.DWDM = b.DWDM and a.dqh = b.dqh
	left join UFDATA_001_BBBBBB..Customer cus on cus.cCusName = b.dwmc or cus.cCusEnName =  b.dwmc or cus.cCusCode = b.pydm_
	left join UFDATA_001_BBBBBB..Vendor ven on ven.cVenName =  b.dwmc or ven.cVenEnName =  b.dwmc or ven.cVenCode =  b.pydm_
    left join UFDATA_001_BBBBBB..Code code on code.ccode = kmdm
where 1=1
	-- and dwmc is not null and (ven.cVenName is null and cus.cCusName is null)

order by id desc
";
                sSQL = sSQL.Replace("AAAAAA", sMonth);
                sSQL = sSQL.Replace("BBBBBB", sYear);

                dt = DbHelperSQL.Query(sSQL);
                gridControl1.DataSource = dt;


                for (int i = 0; i < gridView1.RowCount; i++)
                {
                    string s凭证类别 = gridView1.GetRowCellValue(i, gridCol凭证类别).ToString().Trim();
                    string s凭证号 = gridView1.GetRowCellValue(i, gridCol凭证号).ToString().Trim();
                    int i行 = BaseFunction.ReturnInt(gridView1.GetRowCellValue(i, gridCol行号));
                    if (i行 > 0)
                        continue;

                    int i行号 = 0;
                    for (int j = i; j < gridView1.RowCount; j++)
                    {
                        string s凭证号2 = gridView1.GetRowCellValue(j, gridCol凭证号).ToString().Trim();
                        string s凭证类别2 = gridView1.GetRowCellValue(j, gridCol凭证类别).ToString().Trim();

                        if (s凭证号 == s凭证号2 && s凭证类别 == s凭证类别2)
                        {
                            i行号 += 1;
                            gridView1.SetRowCellValue(j, gridCol行号, i行号);
                        }

                    }
                }


                gridView1.BestFitColumns();
            }
            catch (Exception ee)
            {
                MessageBox.Show(ee.Message);
            }
        }

    }
}
