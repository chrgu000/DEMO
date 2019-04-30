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
    public partial class Frm采购入库单 : FrmBase
    {

        public DataTable dtGrid = new DataTable();
        public Frm采购入库单()
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
                dc.ColumnName = "入库数量";
                dc.DataType = typeof(decimal);
                dtGrid.Columns.Add(dc);

                dc = new DataColumn();
                dc.ColumnName = "入库件数";
                dc.DataType = typeof(decimal);
                dtGrid.Columns.Add(dc);

                dc = new DataColumn();
                dc.ColumnName = "拒收数量";
                dc.DataType = typeof(decimal);
                dtGrid.Columns.Add(dc);

                dc = new DataColumn();
                dc.ColumnName = "拒收件数";
                dc.DataType = typeof(decimal);
                dtGrid.Columns.Add(dc);

                dc = new DataColumn();
                dc.ColumnName = "换算率";
                dtGrid.Columns.Add(dc);

                dc = new DataColumn();
                dc.ColumnName = "单据号";
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

                dc = new DataColumn();
                dc.ColumnName = "cFree5";
                dtGrid.Columns.Add(dc);

                dc = new DataColumn();
                dc.ColumnName = "cFree6";
                dtGrid.Columns.Add(dc);

                dc = new DataColumn();
                dc.ColumnName = "cFree7";
                dtGrid.Columns.Add(dc);

                dc = new DataColumn();
                dc.ColumnName = "cFree8";
                dtGrid.Columns.Add(dc);

                dc = new DataColumn();
                dc.ColumnName = "cFree9";
                dtGrid.Columns.Add(dc);

                dc = new DataColumn();
                dc.ColumnName = "cFree10";
                dtGrid.Columns.Add(dc);

                dc = new DataColumn();
                dc.ColumnName = "条形码";
                dtGrid.Columns.Add(dc);

                dc = new DataColumn();
                dc.ColumnName = "采购到货单子表ID";
                dtGrid.Columns.Add(dc);

                dc = new DataColumn();
                dc.ColumnName = "采购订单子表ID";
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

        private void Frm采购入库单_Load(object sender, EventArgs e)
        {
            try
            {
                dataGrid1.DataSource = dtGrid;
            }
            catch (Exception ee)
            {
                msgBox.Text = "加载采购入库单失败";
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
                    MessageBox.Show("请输入到货单号");
                    return;
                }
                if (txt单据号.Text.Trim().Substring(0, 4).ToUpper() != "CGDH" && txt单据号.Text.Trim().Length==8)
                {
                    txt单据号.Text = "CGDH" + txt单据号.Text.Trim();
                }
                DataTable dt = clsWeb.dt到货单信息(txt单据号.Text.Trim());
                if (dt == null || dt.Rows.Count < 1)
                {
                    throw new Exception("到货单号不存在");
                }
                else
                {
                    string sAudit = dt.Rows[0]["cVerifier"].ToString().Trim();
                    if (sAudit == "")
                    {
                        throw new Exception("该到货单未审核");
                    }
                    string sClose = dt.Rows[0]["cCloser"].ToString().Trim();
                    if (sClose != "")
                    {
                        throw new Exception("该到货单已关闭");
                    }
                }

                Frm采购入库单_Edit fEdit = new Frm采购入库单_Edit(txt单据号.Text.Trim(), dtGrid);
                fEdit.ShowDialog();
                fEdit.WindowState = FormWindowState.Maximized;

                dtGrid = fEdit.dt采购入库;
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

                string sInfo = clsWeb.Save采购入库单(dtGrid);
                if (sInfo.Trim().Length > 2 && sInfo.Substring(0, 2) == "生成")
                {
                    MessageBox.Show(sInfo);
                    dtGrid.Rows.Clear();
                }
                else
                {
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

        private void txt单据号_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyValue == 13)
            {
                btnAdd_Click(null, null);
            }
        }
    }
}