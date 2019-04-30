using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Collections;

namespace WorkInformation
{
    public partial class Frm物料计算 : Form
    {
        FrameBaseFunction.ClsDataBase clsSQLCommond = FrameBaseFunction.ClsDataBaseFactory.Instance();

        DataTable dtGrid;
        public Frm物料计算(DataTable dt)
        {
            InitializeComponent();

            dtGrid = dt.Copy();
        }

        private void Frm物料计算_Load(object sender, EventArgs e)
        {
            try
            {
                this.StartPosition = FormStartPosition.CenterScreen;

                this.WindowState = FormWindowState.Maximized;

                btn刷新_Click(null, null);
            }
            catch (Exception ee)
            {
                MessageBox.Show(ee.Message);
            }
        }

        private int ReturnObjectToInt(object o)
        {
            int i = 0;
            try
            {
                i = Convert.ToInt32(o);
            }
            catch
            { }
            return i;
        }

        private decimal ReturnObjectToDecimal(object o, int i)
        {
            decimal d = 0;
            try
            {
                d = Convert.ToDecimal(o);
                d = decimal.Round(d, i);
            }
            catch
            { }
            return d;
        }

        private void btn关闭_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btn刷新_Click(object sender, EventArgs e)
        {
            try
            {
                string sSQL = "";
                ArrayList aList = new ArrayList();

                sSQL = "delete 生产日计划物料计算临时表";
                aList.Add(sSQL);

                for (int i = 0; i < dtGrid.Rows.Count; i++)
                {
                    if (ReturnObjectToInt(dtGrid.Rows[i]["加工顺序"]) != 1)
                        continue;

                    decimal d1 = ReturnObjectToDecimal(dtGrid.Rows[i]["日期1"], 6);
                    decimal d2 = ReturnObjectToDecimal(dtGrid.Rows[i]["日期2"], 6);
                    decimal d3 = ReturnObjectToDecimal(dtGrid.Rows[i]["日期3"], 6);
                    decimal d4 = ReturnObjectToDecimal(dtGrid.Rows[i]["日期4"], 6);
                    decimal d5 = ReturnObjectToDecimal(dtGrid.Rows[i]["日期5"], 6);
                    decimal d6 = ReturnObjectToDecimal(dtGrid.Rows[i]["日期6"], 6);
                    decimal d7 = ReturnObjectToDecimal(dtGrid.Rows[i]["日期7"], 6);
                    string s外销订单号 = dtGrid.Rows[i]["外销订单"].ToString().Trim();

                    decimal d8 = d1 + d2 + d3 + d4 + d5 + d6 + d7;
                    if (d8 <= 0)
                        continue;

                    string s物料编码 = dtGrid.Rows[i]["物料编码"].ToString().Trim();
                    string s制造令号码 = dtGrid.Rows[i]["制造令号码"].ToString().Trim();

                    sSQL = "select COUNT(1) from @u8.mom_order a inner join @u8.mom_orderdetail b on a.MoId = b.MoId " +
                            "where a.MoCode = '" + s制造令号码 + "' and b.InvCode = '" + s物料编码 + "'";
                    int iCou = ReturnObjectToInt(clsSQLCommond.ExecGetScalar(sSQL));

                    if (iCou > 0)
                    {
                        sSQL = "insert into 生产日计划物料计算临时表([物料编码],[数量1],[数量2],[数量3] ,[数量4] ,[数量5],[数量6] ,[数量7],外销订单号) " +
                                "values('" + dtGrid.Rows[i]["物料编码"].ToString().Trim() + "'," + d1 + "," + d2 + "," + d3 + "," + d4 + "," + d5 + "," + d6 + "," + d7 + ",'" + s外销订单号 + "')";
                        aList.Add(sSQL);
                    }
                }

                sSQL = "delete  [XWSystemDB_DL].dbo.生产日计划物料计算临时表2 " ;
                aList.Add(sSQL);

                sSQL = @"
insert into [XWSystemDB_DL].dbo.生产日计划物料计算临时表2
SELECT  a.[物料编码],b.cInvCode,a.[数量1] * ISNULL(b.BaseQtyN,0),a.[数量2] * ISNULL(b.BaseQtyN,0),a.[数量3] * ISNULL(b.BaseQtyN,0) 
    ,a.[数量4]  * ISNULL(b.BaseQtyN,0),a.[数量5] * ISNULL(b.BaseQtyN,0),a.[数量6] * ISNULL(b.BaseQtyN,0) ,a.[数量7] * ISNULL(b.BaseQtyN,0)
    ,c.现存量,a.外销订单号
FROM [XWSystemDB_DL].[dbo].[生产日计划物料计算临时表] a 
    left join (
                  select b.ParentId,c.InvCode,d.ComponentId,e.InvCode as cInvCode,d.BaseQtyN
                  from @u8.bom_bom a inner join @u8.bom_parent b on a.BomId = b.BomId
                    inner join @u8.bas_part c on b.ParentId = c.PartId 
                    inner join @u8.bom_opcomponent d on d.BomId = a.BomId
                    inner join @u8.bas_part e on d.ComponentId = e.PartId 
                ) b on a.物料编码 = b.InvCode
     left join (
                    select SUM(iquantity) as 现存量,cInvCode
                    from @u8.CurrentStock 
                    where cWhCode = '01' or cWhCode = '0F'
                    group by cInvCode
                )c on b.cInvCode = c.cInvCode
	";
                sSQL = sSQL.Replace("UFDATA_200_2013", FrameBaseFunction.ClsBaseDataInfo.sUFDataBaseName);
                aList.Add(sSQL);

                clsSQLCommond.ExecSqlTran(aList);

                sSQL = @"
 select distinct a.子件编码,b.使用数量1,c.使用数量2,d.使用数量3,a.仓库现存量,CAST (null as varchar(2000)) as 母件编码,外销订单号
 from [XWSystemDB_DL].dbo.生产日计划物料计算临时表2 a
	left join 
	(
		select SUM(isnull(数量1,0)) as 使用数量1 ,子件编码
		from [XWSystemDB_DL].dbo.生产日计划物料计算临时表2 
		group by 子件编码
	)b on a.子件编码 = b.子件编码
		left join 
	(
		select SUM(isnull(数量1,0) + isnull(数量2,0))  as 使用数量2 ,子件编码
		from [XWSystemDB_DL].dbo.生产日计划物料计算临时表2 
		group by 子件编码
	)c on a.子件编码 = c.子件编码
		left join 
	(
		select SUM(isnull(数量1,0) + isnull(数量2,0)+ isnull(数量3,0))  as 使用数量3 ,子件编码
		from [XWSystemDB_DL].dbo.生产日计划物料计算临时表2 
		group by 子件编码
	)d on a.子件编码 = d.子件编码
where ISNULL(a.子件编码,'') <> '' and ISNULL(数量1,0) +  ISNULL(数量2,0) +  ISNULL(数量3,0) > 0
order by a.子件编码

";

                DataTable dt = clsSQLCommond.ExecQuery(sSQL);

                sSQL = "select distinct 子件编码,物料编码,外销订单号 from  [XWSystemDB_DL].dbo.生产日计划物料计算临时表2 where isnull(子件编码,'') <> '' order by  子件编码 ";
                DataTable dt母子 = clsSQLCommond.ExecQuery(sSQL);

                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    string s子件 = dt.Rows[i]["子件编码"].ToString().Trim();

                    DataRow[] dr = dt母子.Select(" 子件编码 = '" + s子件 + "' ");

                    for (int j = 0; j < dr.Length; j++)
                    {
                        if (dt.Rows[i]["母件编码"].ToString().Trim() == "")
                            dt.Rows[i]["母件编码"] = dr[j]["物料编码"].ToString().Trim();
                        else
                            dt.Rows[i]["母件编码"] = dt.Rows[i]["母件编码"].ToString().Trim() + ";" + dr[j]["物料编码"].ToString().Trim();

                        if (dt.Rows[i]["外销订单号"].ToString().Trim() == "")
                            dt.Rows[i]["外销订单号"] = dr[j]["外销订单号"].ToString().Trim();
                        else
                            dt.Rows[i]["外销订单号"] = dt.Rows[i]["外销订单号"].ToString().Trim() + ";" + dr[j]["外销订单号"].ToString().Trim();
                    }
                }

                gridControl1.DataSource = dt;
            }
            catch (Exception ee)
            {
                MessageBox.Show(ee.Message);
            }
        }

        private void gridView1_RowCellStyle(object sender, DevExpress.XtraGrid.Views.Grid.RowCellStyleEventArgs e)
        {
            decimal d = ReturnObjectToDecimal(gridView1.GetRowCellValue(e.RowHandle, gridView1.Columns["仓库现存量"]), 6);
            decimal d1 = ReturnObjectToDecimal(gridView1.GetRowCellValue(e.RowHandle, gridView1.Columns["使用数量1"]), 6);
            decimal d2 = ReturnObjectToDecimal(gridView1.GetRowCellValue(e.RowHandle, gridView1.Columns["使用数量2"]), 6);
            decimal d3 = ReturnObjectToDecimal(gridView1.GetRowCellValue(e.RowHandle, gridView1.Columns["使用数量3"]), 6);

            if (d3 > d)
                e.Appearance.BackColor = Color.LightYellow;
            if (d2 > d)
                e.Appearance.BackColor = Color.Yellow;
            if (d1 > d)
                e.Appearance.BackColor = Color.Tomato;



        }

        private void btn导出_Click(object sender, EventArgs e)
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
    }
}
