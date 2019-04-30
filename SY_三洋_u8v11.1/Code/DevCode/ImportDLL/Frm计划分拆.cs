using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace ImportDLL
{
    public partial class Frm计划分拆 : Form
    {
        TH.DAL.生产计划 DAL = new TH.DAL.生产计划();
        TH.DAL.GetBaseData DALBaseData = new TH.DAL.GetBaseData();

        public DataTable dt分拆计划;
        DataTable dt分拆源2;

        public Frm计划分拆(DataTable dt2, DataTable dt)
        {
            InitializeComponent();

            dt分拆源2 = dt2;
            dt分拆计划 = dt;
        }

        private void Frm_Load(object sender, EventArgs e)
        {
            try
            {
                this.StartPosition = FormStartPosition.CenterScreen;
                gridControl2.DataSource = dt分拆源2;

                GetGrid();
            }
            catch (Exception ee)
            {
                MessageBox.Show(ee.Message);
            }
        }

        private void GetGrid()
        {
            SetLookUp();

            string sInvCode = gridView2.GetRowCellValue(0, gridColu存货编码).ToString().Trim();

            DataTable dt = DAL.GetProLine(sInvCode);

            DataColumn dc = new DataColumn();
            dc.ColumnName = "计划开工日期";
            dt.Columns.Add(dc);
            dc = new DataColumn();
            dc.ColumnName = "计划完工日期";
            dt.Columns.Add(dc);
            dc = new DataColumn();
            dc.ColumnName = "销售订单号";
            dt.Columns.Add(dc);
            dc = new DataColumn();
            dc.ColumnName = "销售订单行号";
            dt.Columns.Add(dc);
            dc = new DataColumn();
            dc.ColumnName = "单据类型";
            dt.Columns.Add(dc);
            dc = new DataColumn();
            dc.ColumnName = "评审单据号";
            dt.Columns.Add(dc);
            dc = new DataColumn();
            dc.ColumnName = "来源GUID";
            dt.Columns.Add(dc);
            dc = new DataColumn();
            dc.ColumnName = "数量";
            dc.DataType = System.Type.GetType("System.Decimal");
            dt.Columns.Add(dc);

            for (int i = 0; i < dt.Rows.Count; i++)
            {
                dt.Rows[i]["计划开工日期"] = gridView2.GetRowCellValue(0, gridCol计划开工日期).ToString().Trim();
                dt.Rows[i]["计划完工日期"] = gridView2.GetRowCellValue(0, gridCol计划完工日期).ToString().Trim();
                dt.Rows[i]["销售订单号"] = gridView2.GetRowCellValue(0, gridCol销售订单号).ToString().Trim();
                dt.Rows[i]["销售订单行号"] = gridView2.GetRowCellValue(0, gridCol销售订单行号).ToString().Trim();
                dt.Rows[i]["单据类型"] = gridView2.GetRowCellValue(0, gridCol单据类型).ToString().Trim();
                dt.Rows[i]["评审单据号"] = gridView2.GetRowCellValue(0, gridCol评审单据号).ToString().Trim();
                dt.Rows[i]["来源GUID"] = gridView2.GetRowCellValue(0, gridCol来源GUID).ToString().Trim();

                if (dt.Rows[i]["产线编码"].ToString().Trim() == gridView2.GetRowCellValue(0, gridCol产线编码).ToString().Trim())
                {
                    dt.Rows[i]["数量"] = gridView2.GetRowCellValue(0, gridCol数量).ToString().Trim();
                }
            }


            gridControl1.DataSource = dt;
        }

        private void btn分拆_Click(object sender, EventArgs e)
        {
            try
            {
                decimal d数量 = 0;
                for (int i = 0; i < gridView1.RowCount; i++)
                {
                    d数量 = d数量 + BaseFunction.BaseFunction.ReturnDecimal(gridView1.GetRowCellValue(i, gridCol数量));
                }

                decimal d数量2 = BaseFunction.BaseFunction.ReturnDecimal(gridView1.GetRowCellValue(0, gridColu数量));

                if (d数量 != d数量2)
                {
                    DialogResult d = MessageBox.Show("分拆后数量不等于源数量,确定继续么?", "提示", MessageBoxButtons.YesNo, MessageBoxIcon.Asterisk);
                    if (d == DialogResult.Yes)
                    {
                        string s来源GUID = gridView2.GetRowCellValue(0, gridColu来源GUID).ToString().Trim();
                        string sLineNo = gridView2.GetRowCellValue(0, gridColu产线编码).ToString().Trim();

                        int iRow = 0;
                        for (int i = 0; i < dt分拆计划.Rows.Count; i++)
                        {
                            string s来源Guid2 = dt分拆计划.Rows[i]["来源GUID"].ToString().Trim();
                            if (s来源GUID == s来源Guid2)
                            {
                                iRow = i;
                                break;
                            }
                        }

                        for (int i = 0; i < gridView1.RowCount; i++)
                        {
                            string s产线编码 = gridView1.GetRowCellValue(i, gridCol产线编码).ToString().Trim();
                            if (s产线编码 == sLineNo)
                            {
                                decimal d当前产线数量 = BaseFunction.BaseFunction.ReturnDecimal(gridView1.GetRowCellValue(i, gridCol数量));
                                if (d当前产线数量 > 0)
                                {
                                    dt分拆计划.Rows[iRow]["数量"] = d当前产线数量;
                                }
                                else
                                {
                                    dt分拆计划.Rows.RemoveAt(iRow);
                                }

                            }
                            else
                            {
                                decimal d当前产线数量 = BaseFunction.BaseFunction.ReturnDecimal(gridView1.GetRowCellValue(i, gridCol数量));
                                if (d当前产线数量 > 0)
                                {
                                    DataRow dr = dt分拆计划.NewRow();
                                    dr["来源GUID"] = gridView1.GetRowCellValue(i, gridCol来源GUID).ToString().Trim();
                                    dr["单据类型"] = gridView1.GetRowCellValue(i, gridCol单据类型).ToString().Trim();
                                    dr["评审单据号"] = gridView1.GetRowCellValue(i, gridCol评审单据号).ToString().Trim(); 
                                    dr["销售订单号"] = gridView1.GetRowCellValue(i, gridCol销售订单号).ToString().Trim(); 
                                    dr["销售订单行号"] = gridView1.GetRowCellValue(i, gridCol销售订单行号).ToString().Trim(); 
                                    dr["存货编码"] = gridView1.GetRowCellValue(i, gridCol存货编码).ToString().Trim();
                                    dr["数量"] = d当前产线数量;
                                    dr["计划开工日期"] = BaseFunction.BaseFunction.ReturnDate(gridView1.GetRowCellValue(i, gridCol计划开工日期)).ToString("yyyy-MM-dd");
                                    dr["计划完工日期"] = BaseFunction.BaseFunction.ReturnDate(gridView1.GetRowCellValue(i, gridCol计划完工日期)).ToString("yyyy-MM-dd");
                                    dr["产线编码"] = gridView1.GetRowCellValue(i, gridCol产线编码).ToString().Trim();
                                    dr["单件生产工时"] = BaseFunction.BaseFunction.ReturnDecimal(gridView1.GetRowCellValue(i, gridCol单件生产工时), 10);
                                    dr["生产准备时间"] = BaseFunction.BaseFunction.ReturnDecimal(gridView1.GetRowCellValue(i, gridCol生产准备时间), 1);
                                    dr["产线并发数"] = BaseFunction.BaseFunction.ReturnInt(gridView1.GetRowCellValue(i, gridCol产线并发数));
                                    dr["生产部门编码"] = gridView1.GetRowCellValue(i, gridCol生产部门编码); 

                                    dt分拆计划.Rows.InsertAt(dr, iRow);
                                }
                            }
                        }
                    }
                }

                this.DialogResult = DialogResult.Yes;
            }
            catch (Exception ee)
            {
                MessageBox.Show(ee.Message);
            }
        }

        private void btn取消_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void SetLookUp()
        {
            DataTable dt = DALBaseData.GetDepartment(" and isnull(bDepEnd ,0) = 1 and cDepCode like '08%'");
            ItemLookUpEdit部门编码.DataSource = dt;
            ItemLookUpEdit部门.DataSource = dt;
            ItemLookUpEdit_部门.DataSource = dt;
            ItemLookUpEdit_部门名称.DataSource = dt;

            dt = DALBaseData.GetInventory("");
            ItemLookUpEdit存货编码.DataSource = dt;
            ItemLookUpEdit存货名称.DataSource = dt;
            ItemLookUpEdit规格型号.DataSource = dt;
            ItemLookUpEdit_存货编码.DataSource = dt;
            ItemLookUpEdit_存货名称.DataSource = dt;
            ItemLookUpEdit_存货规格.DataSource = dt;

            dt = DALBaseData.GetProductionLine("");
            ItemLookUpEdit产线编码.DataSource = dt;
            ItemLookUpEdit产线.DataSource = dt;
            ItemLookUpEdit_产线编码.DataSource = dt;
            ItemLookUpEdit_产线.DataSource = dt;
        }

    }
}
