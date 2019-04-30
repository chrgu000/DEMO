using System;
using System.Linq;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace BarCode
{
    public partial class Frm产品入库单 : FrmBase
    {

        public DataTable dtGrid = new DataTable();
        public Frm产品入库单()
        {
            InitializeComponent();

            try
            {
                dtGrid.TableName = "dtGrid";

                DataColumn dc = new DataColumn();
                dc.ColumnName = "存货编码";
                dtGrid.Columns.Add(dc);

                dc = new DataColumn();
                dc.ColumnName = "存货名称";
                dtGrid.Columns.Add(dc);

                dc = new DataColumn();
                dc.ColumnName = "规格型号";
                dtGrid.Columns.Add(dc);

                dc = new DataColumn();
                dc.ColumnName = "批号";
                dtGrid.Columns.Add(dc);

                dc = new DataColumn();
                dc.ColumnName = "数量";
                dtGrid.Columns.Add(dc);

                dc = new DataColumn();
                dc.ColumnName = "cFree1";
                dtGrid.Columns.Add(dc);

                dc = new DataColumn();
                dc.ColumnName = "cFree2";
                dtGrid.Columns.Add(dc);

                dc = new DataColumn();
                dc.ColumnName = "cFree3";
                dtGrid.Columns.Add(dc);

                dc = new DataColumn();
                dc.ColumnName = "cFree4";
                dtGrid.Columns.Add(dc);

                //dc = new DataColumn();
                //dc.ColumnName = "cFree5";
                //dtGrid.Columns.Add(dc);

                //dc = new DataColumn();
                //dc.ColumnName = "cFree6";
                //dtGrid.Columns.Add(dc);

                //dc = new DataColumn();
                //dc.ColumnName = "cFree7";
                //dtGrid.Columns.Add(dc);

                //dc = new DataColumn();
                //dc.ColumnName = "cFree8";
                //dtGrid.Columns.Add(dc);

                //dc = new DataColumn();
                //dc.ColumnName = "cFree9";
                //dtGrid.Columns.Add(dc);

                //dc = new DataColumn();
                //dc.ColumnName = "cFree10";
                //dtGrid.Columns.Add(dc);

                dc = new DataColumn();
                dc.ColumnName = "单据号";
                dtGrid.Columns.Add(dc);

                dc = new DataColumn();
                dc.ColumnName = "行号";
                dtGrid.Columns.Add(dc);

                dc = new DataColumn();
                dc.ColumnName = "条形码";
                dtGrid.Columns.Add(dc);

                dc = new DataColumn();
                dc.ColumnName = "仓库";
                dtGrid.Columns.Add(dc);

                dc = new DataColumn();
                dc.ColumnName = "货位";
                dtGrid.Columns.Add(dc);

                dc = new DataColumn();
                dc.ColumnName = "制单人";
                dtGrid.Columns.Add(dc);
            }
            catch (Exception ee)
            {
                msgBox.Text = "生成列表失败";
                msgBox.textBox1.Text = ee.Message;
                msgBox.ShowDialog();
                msgBox.WindowState = FormWindowState.Maximized;
            }
        }

        private void Frm产品入库单_Load(object sender, EventArgs e)
        {
            try
            {
                dataGrid1.DataSource = dtGrid;
            }
            catch (Exception ee)
            {
                msgBox.Text = "加载产品入库单失败";
                msgBox.textBox1.Text = ee.Message;
                msgBox.ShowDialog();
                msgBox.WindowState = FormWindowState.Maximized;
            }
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            try
            {
                Frm产品入库单_Edit fEdit = new Frm产品入库单_Edit(dtGrid);
                fEdit.ShowDialog();
                fEdit.WindowState = FormWindowState.Maximized;

                dtGrid = fEdit.dt产品入库;
            }
            catch (Exception ee)
            {
                msgBox.Text = "新增失败";
                msgBox.textBox1.Text = ee.Message;
                msgBox.ShowDialog();
                msgBox.WindowState = FormWindowState.Maximized;
            }
        }

        int iFocRow = -1;

        private void btnDel_Click(object sender, EventArgs e)
        {
            try
            {
                if (iFocRow == -1)
                {
                    throw new Exception("请选择要删除的行");
                }

                if (iFocRow + 1 <= dtGrid.Rows.Count)
                {
                    DialogResult d = MessageBox.Show("确定删除第" + (iFocRow + 1).ToString() + "行数据？", "提示", MessageBoxButtons.YesNo, MessageBoxIcon.Asterisk, MessageBoxDefaultButton.Button1);

                    if (d == DialogResult.Yes)
                    {
                        dtGrid.Rows.RemoveAt(iFocRow);

                        iFocRow = -1;
                    }
                }
            }
            catch (Exception ee)
            {
                msgBox.Text = "删行失败";
                msgBox.textBox1.Text = ee.Message;
                msgBox.ShowDialog();
                msgBox.WindowState = FormWindowState.Maximized;
            }
        }

        private void dataGrid1_Click(object sender, EventArgs e)
        {
            try
            {
                DataGridCell dCell = dataGrid1.CurrentCell;
                iFocRow = dCell.RowNumber;
            }
            catch (Exception ee)
            {
                msgBox.Text = "获得行信息失败";
                msgBox.textBox1.Text = ee.Message;
                msgBox.ShowDialog();
                msgBox.WindowState = FormWindowState.Maximized;
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                if (dtGrid == null || dtGrid.Rows.Count < 1)
                {
                    throw new Exception("没有需要保存的数据");
                }
                string sErr = "";
                for (int i = 0; i < dtGrid.Rows.Count; i++)
                {
                    string s条形码 = dtGrid.Rows[i]["条形码"].ToString().Trim();
                    string s仓库 = dtGrid.Rows[i]["仓库"].ToString().Trim();

                    for (int j = i + 1; j < dtGrid.Rows.Count; j++)
                    {
                        string s条形码2 = dtGrid.Rows[j]["条形码"].ToString().Trim();
                        if (s条形码 == s条形码2)
                        {
                            sErr = sErr + "行" + (j + 1).ToString().Trim() + "条形码已经使用";
                            continue;
                        }

                        string s仓库2 = dtGrid.Rows[j]["仓库"].ToString().Trim();
                        if (s仓库 != s仓库2)
                        {
                            sErr = sErr + "行" + (j + 1).ToString().Trim() + "仓库不一致";
                            continue;
                        }
                    }

                    if (sErr.Length > 0)
                    {
                        throw new Exception(sErr);
                    }

                    string sInfo = clsWeb.Save产品入库单(dtGrid);
                    if (sInfo.Trim().Length > 2 && sInfo.Substring(0, 2) == "生成")
                    {
                        MessageBox.Show(sInfo);
                        dtGrid.Rows.Clear();
                    }
                    else
                        throw new Exception(sInfo);
                }
            }
            catch (Exception ee)
            {
                msgBox.Text = "保存失败";
                msgBox.textBox1.Text = ee.Message;
                msgBox.ShowDialog();
                msgBox.WindowState = FormWindowState.Maximized;
            }
        }
    }
}