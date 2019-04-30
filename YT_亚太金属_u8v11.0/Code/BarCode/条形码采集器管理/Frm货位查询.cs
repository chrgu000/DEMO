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
    public partial class Frm货位查询 : FrmBase
    {
        
        public DataTable dtGrid = new DataTable();
        public Frm货位查询()
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
                dc.ColumnName = "件数";
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
            }
            catch (Exception ee)
            {
                msgBox.Text = "生成列表失败";
                msgBox.textBox1.Text = ee.Message;
                msgBox.ShowDialog();
                msgBox.WindowState = FormWindowState.Maximized;
            }
        }

        private void Frm货位查询_Load(object sender, EventArgs e)
        {
            try
            {
                dataGrid1.DataSource = dtGrid;
            }
            catch (Exception ee)
            {
                msgBox.Text = "加载货位查询失败";
                msgBox.textBox1.Text = ee.Message;
                msgBox.ShowDialog();
                msgBox.WindowState = FormWindowState.Maximized;
            }
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            try
            {
                int iCou = ReturnObjectToInt(clsWeb.Chk货位是否存在(txt单据号.Text));
                if (iCou > 0)
                {
                    DataTable dt = clsWeb.dt货位(txt单据号.Text);
                    if (dt.Rows.Count == 0)
                    {
                        MsgBox msgBox = new MsgBox();
                        msgBox.Text = "提示";
                        msgBox.textBox1.Text = "当前货位无物料";
                        msgBox.ShowDialog();
                        msgBox.WindowState = FormWindowState.Maximized;
                    }
                    else
                    {
                        dataGrid1.DataSource = dt;
                    }
                }
                else
                {
                    msgBox.Text = "查询失败";
                    msgBox.textBox1.Text = "当前货位不存在";
                    msgBox.ShowDialog();
                    msgBox.WindowState = FormWindowState.Maximized;
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

        protected int ReturnObjectToInt(object o)
        {
            int l = 0;
            try
            {
                l = Convert.ToInt32(o);
            }
            catch
            { }
            return l;
        }

        protected long ReturnObjectToLong(object o)
        {
            long l = 0;
            try
            {
                l = Convert.ToInt64(o);
            }
            catch
            { }
            return l;
        }

        protected double ReturnObjectToDouble(object o)
        {
            double l = 0;
            try
            {
                l = Convert.ToDouble(o);
            }
            catch
            { }
            return l;
        }


        protected decimal ReturnObjectToDecimal(object o, int i)
        {
            decimal l = 0;
            try
            {
                l = Convert.ToDecimal(o);
                l = decimal.Round(l, i);
            }
            catch
            { }
            return l;
        }
    }
}