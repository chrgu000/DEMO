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
    public partial class Frm销售出库单 : FrmBase
    {

        public DataTable dtGrid = new DataTable();
        public Frm销售出库单()
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
                dc.ColumnName = "材质";
                dtGrid.Columns.Add(dc);

                dc = new DataColumn();
                dc.ColumnName = "工艺要求";
                dtGrid.Columns.Add(dc);

                dc = new DataColumn();
                dc.ColumnName = "渗层";
                dtGrid.Columns.Add(dc);

                dc = new DataColumn();
                dc.ColumnName = "统一号";
                dtGrid.Columns.Add(dc);

                dc = new DataColumn();
                dc.ColumnName = "数量";
                dtGrid.Columns.Add(dc);

                dc = new DataColumn();
                dc.ColumnName = "单据号";
                dtGrid.Columns.Add(dc);

                dc = new DataColumn();
                dc.ColumnName = "条形码";
                dtGrid.Columns.Add(dc);

                dc = new DataColumn();
                dc.ColumnName = "销售订单子表ID";
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

        private void Frm销售出库单_Load(object sender, EventArgs e)
        {
            try
            {
                dataGrid1.DataSource = dtGrid;
            }
            catch (Exception ee)
            {
                msgBox.Text = "加载销售出库单失败";
                msgBox.textBox1.Text = ee.Message;
                msgBox.ShowDialog();
                msgBox.WindowState = FormWindowState.Maximized;
            }
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            try
            {
                if (txt单据号.Text.Trim() == "")
                {
                    MessageBox.Show("请输入发货单号");
                    return;
                }

                if (txt单据号.Text.Trim().Substring(0, 4).ToUpper() != "XSDD" && txt单据号.Text.Trim().Length == 8)
                {
                    txt单据号.Text = "XSDD" + txt单据号.Text.Trim();
                }

                DataTable dt = clsWeb.dt销售订单信息(txt单据号.Text.Trim());
                if (dt == null || dt.Rows.Count < 1)
                {
                    throw new Exception("销售订单号不存在");
                }

                Frm销售出库单_Edit fEdit = new Frm销售出库单_Edit(txt单据号.Text.Trim(), dtGrid);
                fEdit.ShowDialog();
                fEdit.WindowState = FormWindowState.Maximized;

                dtGrid = fEdit.dt销售出库;
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


                string sInfo = clsWeb.Save销售出库单(dtGrid);
                if (sInfo.Trim().Length > 2 && sInfo.Substring(0, 2) == "生成")
                {
                    MessageBox.Show(sInfo);
                    dtGrid.Rows.Clear();
                }
                else
                    throw new Exception(sInfo);
            }
            catch (Exception ee)
            {
                msgBox.Text = "保存失败";
                msgBox.textBox1.Text = ee.Message;
                msgBox.ShowDialog();
                msgBox.WindowState = FormWindowState.Maximized;
            }
        }

        private void msgBox_Load(object sender, EventArgs e)
        {

        }
    }
}