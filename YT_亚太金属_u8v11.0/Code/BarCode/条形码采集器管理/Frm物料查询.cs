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
    public partial class Frm物料查询 : FrmBase
    {
        
        public DataTable dtGrid = new DataTable();
        public Frm物料查询()
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
                dc.ColumnName = "仓库";
                dtGrid.Columns.Add(dc);

                dc = new DataColumn();
                dc.ColumnName = "仓库名称";
                dtGrid.Columns.Add(dc);

                dc = new DataColumn();
                dc.ColumnName = "货位";
                dtGrid.Columns.Add(dc);

                dc = new DataColumn();
                dc.ColumnName = "货位名称";
                dtGrid.Columns.Add(dc);

                dc = new DataColumn();
                dc.ColumnName = "数量";
                dtGrid.Columns.Add(dc);

                dc = new DataColumn();
                dc.ColumnName = "件数";
                dtGrid.Columns.Add(dc);

                dc = new DataColumn();
                dc.ColumnName = "批号";
                dtGrid.Columns.Add(dc);
            }
            catch (Exception ee)
            {
                MsgBox msgBox = new MsgBox();
                msgBox.Text = "生成列表失败";
                msgBox.textBox1.Text = ee.Message;
                msgBox.ShowDialog();
                msgBox.WindowState = FormWindowState.Maximized;
            }
        }

        private void Frm物料查询_Load(object sender, EventArgs e)
        {
            try
            {
                dataGrid1.DataSource = dtGrid;
            }
            catch (Exception ee)
            {
                msgBox.Text = "加载物料查询失败";
                msgBox.textBox1.Text = ee.Message;
                msgBox.ShowDialog();
                msgBox.WindowState = FormWindowState.Maximized;
            }
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            try
            {
                DataTable dt = clsWeb.dt仓库(txt单据号.Text);
                if (dt.Rows.Count == 0)
                {
                    msgBox.Text = "提示";
                    msgBox.textBox1.Text = "无此物料";
                    msgBox.ShowDialog();
                    msgBox.WindowState = FormWindowState.Maximized;
                }
                else
                {
                    dataGrid1.DataSource = dt;
                }
            }
            catch (Exception ee)
            {
                msgBox.Text = "查询失败";
                msgBox.textBox1.Text = ee.Message;
                msgBox.ShowDialog();
                msgBox.WindowState = FormWindowState.Maximized;
            }
        }

        public static DataTable ColumnsSelect(DataTable dt, string[] str)
        {
            DataTable dtnew = new DataTable();
            for (int i = 0; i < str.Length; i++)
            {
                dtnew.Columns.Add(str[i]);
            }
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                DataRow dw = dtnew.NewRow();
                for (int j = 0; j < str.Length; j++)
                {
                    dw[str[j]] = dt.Rows[i][str[j]].ToString();
                }
                dtnew.Rows.Add(dw);
            }
            return dtnew;
        }

        int iFocRow = -1;

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

        private void txt单据号_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyValue == 13)
            {
                btnAdd_Click(null, null);
            }
        }
    }
}