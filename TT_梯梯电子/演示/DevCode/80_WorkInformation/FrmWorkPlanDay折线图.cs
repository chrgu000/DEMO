using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraLayout;
using System.IO;

namespace WorkInformation
{
    public partial class FrmWorkPlanDay折线图 : FrameBaseFunction.Frm列表窗体模板
    {
        public FrmWorkPlanDay折线图()
        {
            InitializeComponent();
        }

       

        #region 按钮操作
        protected override void BtnClick(string sBtnName, string sBtnText)
        {
            try
            {
                switch (sBtnName.ToLower())
                {
                    case "audit":
                        btnAudit();
                        break;
                    case "del":
                        btnDel();
                        break;
                    case "export":
                        btnExport();
                        break;
                    case "import":
                        btnImport();
                        break;
                    case "print":
                        btnPrint();
                        break;
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
                    case "layout":
                        btnLayout(sBtnText);
                        break;
                    case "alter":
                        btnAlter();
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

        }

        private void btnAlter()
        {
            try
            {

            }
            catch (Exception ee)
            {
                MessageBox.Show("导出生产计划失败:" + ee.Message);
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

        }
        /// <summary>
        /// 输出
        /// </summary>
        private void btnExport()
        {
           
        }

        private void btnLayout(string sText)
        {
           
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
            sSQL = @"

select  d.iText as 组别
	,cast(sum(case when datediff(d,'2013-12-05',c.计划生产日期) = 1 then c.数量 * ISNULL(b.单位工时,0) end) as decimal(16,2)) as 日期工时1	 
	,cast(sum(case when datediff(d,'2013-12-05',c.计划生产日期) = 2 then c.数量 * ISNULL(b.单位工时,0) end) as decimal(16,2)) as 日期工时2	 
	,cast(sum(case when datediff(d,'2013-12-05',c.计划生产日期) = 3 then c.数量 * ISNULL(b.单位工时,0) end) as decimal(16,2)) as 日期工时3	 
	,cast(sum(case when datediff(d,'2013-12-05',c.计划生产日期) = 4 then c.数量 * ISNULL(b.单位工时,0) end) as decimal(16,2)) as 日期工时4	 
	,cast(sum(case when datediff(d,'2013-12-05',c.计划生产日期) = 5 then c.数量 * ISNULL(b.单位工时,0) end) as decimal(16,2)) as 日期工时5	 
	,cast(sum(case when datediff(d,'2013-12-05',c.计划生产日期) = 6 then c.数量 * ISNULL(b.单位工时,0) end) as decimal(16,2)) as 日期工时6	 
	,cast(sum(case when datediff(d,'2013-12-05',c.计划生产日期) = 7 then c.数量 * ISNULL(b.单位工时,0) end) as decimal(16,2)) as 日期工时7	 
	,cast(sum(case when datediff(d,'2013-12-05',c.计划生产日期) = 8 then c.数量 * ISNULL(b.单位工时,0) end) as decimal(16,2)) as 日期工时8	 
	,cast(sum(case when datediff(d,'2013-12-05',c.计划生产日期) = 9 then c.数量 * ISNULL(b.单位工时,0) end) as decimal(16,2)) as 日期工时9	 
	,cast(sum(case when datediff(d,'2013-12-05',c.计划生产日期) = 10 then c.数量 * ISNULL(b.单位工时,0) end) as decimal(16,2)) as 日期工时10	 
	,cast(sum(case when datediff(d,'2013-12-05',c.计划生产日期) = 11 then c.数量 * ISNULL(b.单位工时,0) end) as decimal(16,2)) as 日期工时11	 
	,cast(sum(case when datediff(d,'2013-12-05',c.计划生产日期) = 12 then c.数量 * ISNULL(b.单位工时,0) end) as decimal(16,2)) as 日期工时12	 
	,cast(sum(case when datediff(d,'2013-12-05',c.计划生产日期) = 13 then c.数量 * ISNULL(b.单位工时,0) end) as decimal(16,2)) as 日期工时13	 
	,cast(sum(case when datediff(d,'2013-12-05',c.计划生产日期) = 14 then c.数量 * ISNULL(b.单位工时,0) end) as decimal(16,2)) as 日期工时14	 
	,cast(sum(case when datediff(d,'2013-12-05',c.计划生产日期) = 15 then c.数量 * ISNULL(b.单位工时,0) end) as decimal(16,2)) as 日期工时15	 
	,cast(sum(case when datediff(d,'2013-12-05',c.计划生产日期) = 16 then c.数量 * ISNULL(b.单位工时,0) end) as decimal(16,2)) as 日期工时16	 
	,cast(sum(case when datediff(d,'2013-12-05',c.计划生产日期) = 17 then c.数量 * ISNULL(b.单位工时,0) end) as decimal(16,2)) as 日期工时17	 
	,cast(sum(case when datediff(d,'2013-12-05',c.计划生产日期) = 18 then c.数量 * ISNULL(b.单位工时,0) end) as decimal(16,2)) as 日期工时18	 
	,cast(sum(case when datediff(d,'2013-12-05',c.计划生产日期) = 19 then c.数量 * ISNULL(b.单位工时,0) end) as decimal(16,2)) as 日期工时19	 
	,cast(sum(case when datediff(d,'2013-12-05',c.计划生产日期) = 20 then c.数量 * ISNULL(b.单位工时,0) end) as decimal(16,2)) as 日期工时20	 
	,cast(sum(case when datediff(d,'2013-12-05',c.计划生产日期) = 21 then c.数量 * ISNULL(b.单位工时,0) end) as decimal(16,2)) as 日期工时21	 
	,cast(sum(case when datediff(d,'2013-12-05',c.计划生产日期) = 22 then c.数量 * ISNULL(b.单位工时,0) end) as decimal(16,2)) as 日期工时22	 
	,cast(sum(case when datediff(d,'2013-12-05',c.计划生产日期) = 23 then c.数量 * ISNULL(b.单位工时,0) end) as decimal(16,2)) as 日期工时23	 
	,cast(sum(case when datediff(d,'2013-12-05',c.计划生产日期) = 24 then c.数量 * ISNULL(b.单位工时,0) end) as decimal(16,2)) as 日期工时24	 
	,cast(sum(case when datediff(d,'2013-12-05',c.计划生产日期) = 25 then c.数量 * ISNULL(b.单位工时,0) end) as decimal(16,2)) as 日期工时25	 
	,cast(sum(case when datediff(d,'2013-12-05',c.计划生产日期) = 26 then c.数量 * ISNULL(b.单位工时,0) end) as decimal(16,2)) as 日期工时26	 
	,cast(sum(case when datediff(d,'2013-12-05',c.计划生产日期) = 27 then c.数量 * ISNULL(b.单位工时,0) end) as decimal(16,2)) as 日期工时27	 
	,cast(sum(case when datediff(d,'2013-12-05',c.计划生产日期) = 28 then c.数量 * ISNULL(b.单位工时,0) end) as decimal(16,2)) as 日期工时28	 
	,cast(sum(case when datediff(d,'2013-12-05',c.计划生产日期) = 29 then c.数量 * ISNULL(b.单位工时,0) end) as decimal(16,2)) as 日期工时29	 
	,cast(sum(case when datediff(d,'2013-12-05',c.计划生产日期) = 30 then c.数量 * ISNULL(b.单位工时,0) end) as decimal(16,2)) as 日期工时30	 
	,cast(sum(case when datediff(d,'2013-12-05',c.计划生产日期) = 31 then c.数量 * ISNULL(b.单位工时,0) end) as decimal(16,2)) as 日期工时31	 
	,cast(sum(case when datediff(d,'2013-12-05',c.计划生产日期) = 32 then c.数量 * ISNULL(b.单位工时,0) end) as decimal(16,2)) as 日期工时32	 
	,cast(sum(case when datediff(d,'2013-12-05',c.计划生产日期) = 33 then c.数量 * ISNULL(b.单位工时,0) end) as decimal(16,2)) as 日期工时33	 
	,cast(sum(case when datediff(d,'2013-12-05',c.计划生产日期) = 34 then c.数量 * ISNULL(b.单位工时,0) end) as decimal(16,2)) as 日期工时34	 
	,cast(sum(case when datediff(d,'2013-12-05',c.计划生产日期) = 35 then c.数量 * ISNULL(b.单位工时,0) end) as decimal(16,2)) as 日期工时35	 
	,cast(sum(case when datediff(d,'2013-12-05',c.计划生产日期) = 36 then c.数量 * ISNULL(b.单位工时,0) end) as decimal(16,2)) as 日期工时36	 
	,cast(sum(case when datediff(d,'2013-12-05',c.计划生产日期) = 37 then c.数量 * ISNULL(b.单位工时,0) end) as decimal(16,2)) as 日期工时37	 
	,cast(sum(case when datediff(d,'2013-12-05',c.计划生产日期) = 38 then c.数量 * ISNULL(b.单位工时,0) end) as decimal(16,2)) as 日期工时38	 
	,cast(sum(case when datediff(d,'2013-12-05',c.计划生产日期) = 39 then c.数量 * ISNULL(b.单位工时,0) end) as decimal(16,2)) as 日期工时39	 
	,cast(sum(case when datediff(d,'2013-12-05',c.计划生产日期) = 40 then c.数量 * ISNULL(b.单位工时,0) end) as decimal(16,2)) as 日期工时40	 
	,cast(sum(case when datediff(d,'2013-12-05',c.计划生产日期) = 41 then c.数量 * ISNULL(b.单位工时,0) end) as decimal(16,2)) as 日期工时41	 
	,cast(sum(case when datediff(d,'2013-12-05',c.计划生产日期) = 42 then c.数量 * ISNULL(b.单位工时,0) end) as decimal(16,2)) as 日期工时42	 
	,cast(sum(case when datediff(d,'2013-12-05',c.计划生产日期) = 43 then c.数量 * ISNULL(b.单位工时,0) end) as decimal(16,2)) as 日期工时43	 
	,cast(sum(case when datediff(d,'2013-12-05',c.计划生产日期) = 44 then c.数量 * ISNULL(b.单位工时,0) end) as decimal(16,2)) as 日期工时44	 
	,cast(sum(case when datediff(d,'2013-12-05',c.计划生产日期) = 45 then c.数量 * ISNULL(b.单位工时,0) end) as decimal(16,2)) as 日期工时45	 
	,cast(sum(case when datediff(d,'2013-12-05',c.计划生产日期) = 46 then c.数量 * ISNULL(b.单位工时,0) end) as decimal(16,2)) as 日期工时46	 
	,cast(sum(case when datediff(d,'2013-12-05',c.计划生产日期) = 47 then c.数量 * ISNULL(b.单位工时,0) end) as decimal(16,2)) as 日期工时47	 
	,cast(sum(case when datediff(d,'2013-12-05',c.计划生产日期) = 48 then c.数量 * ISNULL(b.单位工时,0) end) as decimal(16,2)) as 日期工时48	 
	,cast(sum(case when datediff(d,'2013-12-05',c.计划生产日期) = 49 then c.数量 * ISNULL(b.单位工时,0) end) as decimal(16,2)) as 日期工时49	 
	,cast(sum(case when datediff(d,'2013-12-05',c.计划生产日期) = 50 then c.数量 * ISNULL(b.单位工时,0) end) as decimal(16,2)) as 日期工时50	 
	,cast(sum(case when datediff(d,'2013-12-05',c.计划生产日期) = 51 then c.数量 * ISNULL(b.单位工时,0) end) as decimal(16,2)) as 日期工时51	 
	,cast(sum(case when datediff(d,'2013-12-05',c.计划生产日期) = 52 then c.数量 * ISNULL(b.单位工时,0) end) as decimal(16,2)) as 日期工时52	 
	,cast(sum(case when datediff(d,'2013-12-05',c.计划生产日期) = 53 then c.数量 * ISNULL(b.单位工时,0) end) as decimal(16,2)) as 日期工时53	 
	,cast(sum(case when datediff(d,'2013-12-05',c.计划生产日期) = 54 then c.数量 * ISNULL(b.单位工时,0) end) as decimal(16,2)) as 日期工时54	  
	,cast(sum(case when datediff(d,'2013-12-05',c.计划生产日期) = 55 then c.数量 * ISNULL(b.单位工时,0) end) as decimal(16,2)) as 日期工时55	 
	,cast(sum(case when datediff(d,'2013-12-05',c.计划生产日期) = 56 then c.数量 * ISNULL(b.单位工时,0) end) as decimal(16,2)) as 日期工时56	 
	,cast(sum(case when datediff(d,'2013-12-05',c.计划生产日期) = 57 then c.数量 * ISNULL(b.单位工时,0) end) as decimal(16,2)) as 日期工时57	 
	,cast(sum(case when datediff(d,'2013-12-05',c.计划生产日期) = 58 then c.数量 * ISNULL(b.单位工时,0) end) as decimal(16,2)) as 日期工时58	 
	,cast(sum(case when datediff(d,'2013-12-05',c.计划生产日期) = 59 then c.数量 * ISNULL(b.单位工时,0) end) as decimal(16,2)) as 日期工时59	 
	,cast(sum(case when datediff(d,'2013-12-05',c.计划生产日期) = 60 then c.数量 * ISNULL(b.单位工时,0) end) as decimal(16,2)) as 日期工时60	
from 生产计划 a 
      inner join dbo.生产计划明细 b on a.单据号 = b.表头单据号 
      inner join dbo.生产日计划 c on c.生产计划明细iID = b.iID
      left join _LookUpDate d on d.iID = b.组别 and d.iType = 15
    
where 排产日期 = '2013-12-05'
group by d.iText 
order by d.iText 
";
            sSQL = sSQL.Replace("2013-12-05", dtm.DateTime.ToString("yyyy-MM-dd"));

            DataTable dt = clsSQLCommond.ExecQuery(sSQL);

            DataRow[] dr冲压 = dt.Select("组别 = '冲压' ");
            DataTable dt冲压 = dr冲压.CopyToDataTable();
            DataRow dr = dt冲压.NewRow();
            dr[0] = "上限";
            for (int i = 1; i < dt.Columns.Count; i++)
            {
                dr[i] = 200;
            }
            dt冲压.Rows.Add(dr);
            dr = dt冲压.NewRow();
            dr[0] = "下限";
            for (int i = 1; i < dt.Columns.Count; i++)
            {
                dr[i] = 100;
            }
            dt冲压.Rows.Add(dr);


            DataRow[] dr电焊 = dt.Select("组别 = '电焊' ");
            DataTable dt电焊 = dr电焊.CopyToDataTable();
            dr = dt电焊.NewRow();
            dr[0] = "上限";
            for (int i = 1; i < dt.Columns.Count; i++)
            {
                dr[i] = 200;
            }
            dt电焊.Rows.Add(dr);
            dr = dt电焊.NewRow();
            dr[0] = "下限";
            for (int i = 1; i < dt.Columns.Count; i++)
            {
                dr[i] = 100;
            }
            dt电焊.Rows.Add(dr);


            DataRow[] dr铝件组装 = dt.Select("组别 = '铝件' or 组别 = '组装'");

            DataTable dt铝件组装 = dt.Clone();
            DataRow dr_铝件组装 = dt铝件组装.NewRow();

            dr_铝件组装[0] = "铝件组装";
            for (int j = 1; j < dt铝件组装.Columns.Count; j++)
            {
                decimal d工时 = 0;
                for (int i = 0; i < dr铝件组装.Length; i++)
                {
                    d工时 = d工时 + ReturnObjectToDecimal(dr铝件组装[i][j], 2);
                }
                dr_铝件组装[j] = d工时;
            }
            dt铝件组装.Rows.Add(dr_铝件组装);

            dr = dt铝件组装.NewRow();
            dr[0] = "上限";
            for (int i = 1; i < dt.Columns.Count; i++)
            {
                dr[i] = 600;
            }
            dt铝件组装.Rows.Add(dr);
            dr = dt铝件组装.NewRow();
            dr[0] = "下限";
            for (int i = 1; i < dt.Columns.Count; i++)
            {
                dr[i] = 300;
            }
            dt铝件组装.Rows.Add(dr);

            for (int i = 0; i < dt.Columns.Count; i++)
            {
                if (dt.Columns[i].Caption.Trim().Length > 4 && dt.Columns[i].Caption.Trim().Substring(0, 4) == "日期工时")
                {
                    int iDay = ReturnObjectToInt(dt.Columns[i].Caption.Trim().Substring(4));
                    string sCaption = dtm.DateTime.AddDays(iDay).ToString("MM|dd");
                    dt.Columns[i].Caption = sCaption;
                    dt铝件组装.Columns[i].Caption = sCaption;
                    dt冲压.Columns[i].Caption = sCaption;
                    dt电焊.Columns[i].Caption = sCaption;
                }
            }

            Set全部班组折线图(dt);

            Set铝件组装折线图(dt);

            Set冲压折线图(dt冲压);

            Set电焊折线图(dt电焊);

            Set铝件组装折线图(dt铝件组装);
        }

        private void Set冲压折线图(DataTable dt)
        {
            chartControl冲压.Series.Clear();

            for (int i = 0; i < dt.Rows.Count; i++)
            {
                DevExpress.XtraCharts.Series series1 = new DevExpress.XtraCharts.Series();
                series1.ChangeView(DevExpress.XtraCharts.ViewType.Line);
                series1.Name = dt.Rows[i][0].ToString().Trim();
                series1.Label.Visible = false;

                for (int j = 1; j < dt.Columns.Count; j++)
                {
                    decimal d = ReturnObjectToDecimal(dt.Rows[i][j], 2);
                    DevExpress.XtraCharts.SeriesPoint seriesPoint10 = new DevExpress.XtraCharts.SeriesPoint(dt.Columns[j].Caption.Trim(), new object[] { (d) });

                    series1.Points.AddRange(new DevExpress.XtraCharts.SeriesPoint[] { seriesPoint10 });
                }

                chartControl冲压.Series.Add(series1);
            }
        }
        private void Set电焊折线图(DataTable dt)
        {
            chartControl电焊.Series.Clear();

            for (int i = 0; i < dt.Rows.Count; i++)
            {
                DevExpress.XtraCharts.Series series1 = new DevExpress.XtraCharts.Series();
                series1.ChangeView(DevExpress.XtraCharts.ViewType.Line);
                series1.Name = dt.Rows[i][0].ToString().Trim();
                series1.Label.Visible = false;

                for (int j = 1; j < dt.Columns.Count; j++)
                {
                    decimal d = ReturnObjectToDecimal(dt.Rows[i][j], 2);
                    DevExpress.XtraCharts.SeriesPoint seriesPoint10 = new DevExpress.XtraCharts.SeriesPoint(dt.Columns[j].Caption.Trim(), new object[] { (d) });

                    series1.Points.AddRange(new DevExpress.XtraCharts.SeriesPoint[] { seriesPoint10 });
                }

                chartControl电焊.Series.Add(series1);
            }
        }
        private void Set铝件组装折线图(DataTable dt)
        {
            chartControl铝件组装.Series.Clear();

            for (int i = 0; i < dt.Rows.Count; i++)
            {
                DevExpress.XtraCharts.Series series1 = new DevExpress.XtraCharts.Series();
                series1.ChangeView(DevExpress.XtraCharts.ViewType.Line);
                series1.Name = dt.Rows[i][0].ToString().Trim();
                series1.Label.Visible = false;

                for (int j = 1; j < dt.Columns.Count; j++)
                {
                    decimal d = ReturnObjectToDecimal(dt.Rows[i][j], 2);
                    DevExpress.XtraCharts.SeriesPoint seriesPoint10 = new DevExpress.XtraCharts.SeriesPoint(dt.Columns[j].Caption.Trim(), new object[] { (d) });

                    series1.Points.AddRange(new DevExpress.XtraCharts.SeriesPoint[] { seriesPoint10 });
                }

                chartControl铝件组装.Series.Add(series1);
            }
        }

        private void Set全部班组折线图(DataTable dt)
        {
            chartControl1.Series.Clear();
            
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                DevExpress.XtraCharts.Series series1 = new DevExpress.XtraCharts.Series();
                series1.ChangeView(DevExpress.XtraCharts.ViewType.Line);
                series1.Name = dt.Rows[i][0].ToString().Trim();
                series1.Label.Visible = false;
              
                for (int j = 1; j < dt.Columns.Count; j++)
                {
                    decimal d = ReturnObjectToDecimal(dt.Rows[i][j], 2);
                    DevExpress.XtraCharts.SeriesPoint seriesPoint10 = new DevExpress.XtraCharts.SeriesPoint(dt.Columns[j].Caption.Trim(), new object[] { (d) });

                    series1.Points.AddRange(new DevExpress.XtraCharts.SeriesPoint[] { seriesPoint10 });
                }

                chartControl1.Series.Add(series1);
            }
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
            
        }

        /// <summary>
        /// 审核
        /// </summary>
        private void btnAudit()
        {
            
        }
        /// <summary>
        /// 弃审
        /// </summary>
        private void btnUnAudit()
        {
            
        }
      

        #endregion

        int i排产日期跨度 = 60;
        private void FrmWorkPlanDay折线图_Load(object sender, EventArgs e)
        {
            try
            {
                sSQL = "select max(a.排产日期) from dbo.生产日计划 a inner join  dbo.生产计划明细 b on a.生产计划明细iID = b.iID where b.帐套号 = '200'";
                DateTime d = Convert.ToDateTime(clsSQLCommond.ExecGetScalar(sSQL));
                if (d < Convert.ToDateTime("2000-1-1"))
                    return;
                else
                    dtm.DateTime = d;
            }
            catch (Exception ee)
            {
                MessageBox.Show("加载窗体失败\n" + ee.Message);
            }
        }

        private void dtm_EditValueChanged(object sender, EventArgs e)
        {
            try
            {
                dtmPlan1.DateTime = dtm.DateTime.AddDays(1);
            }
            catch (Exception ee)
            {
                MessageBox.Show(ee.Message);
            }
        }

        private void chartControl1_Click(object sender, EventArgs e)
        {

        }
       
    }
}
