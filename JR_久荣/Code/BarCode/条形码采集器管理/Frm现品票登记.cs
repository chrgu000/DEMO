using System;
using System.Linq;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Microsoft.VisualBasic;

namespace BarCode
{
    public partial class Frm现品票登记 : FrmBase
    {

        public DataTable dtGrid = new DataTable();
        public Frm现品票登记()
        {
            InitializeComponent();

            try
            {
                dtGrid.TableName = "dtGrid";

                DataColumn dc = new DataColumn();
                dc.ColumnName = "供应商";
                dtGrid.Columns.Add(dc);

                dc = new DataColumn();
                dc.ColumnName = "门号";
                dtGrid.Columns.Add(dc);

                dc = new DataColumn();
                dc.ColumnName = "产品名称";
                dtGrid.Columns.Add(dc);

                dc = new DataColumn();
                dc.ColumnName = "品番";
                dtGrid.Columns.Add(dc);

                dc = new DataColumn();
                dc.ColumnName = "箱种";
                dtGrid.Columns.Add(dc);

                dc = new DataColumn();
                dc.ColumnName = "送货数量";
                dc.DataType = typeof(decimal);
                dtGrid.Columns.Add(dc);

                dc = new DataColumn();
                dc.ColumnName = "收容数";
                dc.DataType = typeof(decimal);
                dtGrid.Columns.Add(dc);

                dc = new DataColumn();
                dc.ColumnName = "箱数";
                dc.DataType = typeof(decimal);
                dtGrid.Columns.Add(dc);

                dc = new DataColumn();
                dc.ColumnName = "纳入指示日期";
                dtGrid.Columns.Add(dc);

                dc = new DataColumn();
                dc.ColumnName = "订单编号";
                dtGrid.Columns.Add(dc);

                dc = new DataColumn();
                dc.ColumnName = "条形码";
                dtGrid.Columns.Add(dc);

                dc = new DataColumn();
                dc.ColumnName = "登记人";
                dtGrid.Columns.Add(dc);
            }
            catch (Exception ee)
            {
                Msg("生成列表失败 " + ee.Message);
            }
        }

        private void Frm现品票登记_Load(object sender, EventArgs e)
        {
            try
            {
                lSum.Text = "";

                dataGrid1.DataSource = dtGrid;
            }
            catch (Exception ee)
            {
                Msg("加载现品票登记失败 " + ee.Message);
            }
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            try
            {
                Frm现品票登记_Edit fEdit = new Frm现品票登记_Edit(dtGrid);
                fEdit.ShowDialog();
                fEdit.WindowState = FormWindowState.Maximized;

                dtGrid = fEdit.dtGrid;


                decimal dQty = 0;
                decimal dXS = 0;
                for (int i = 0; i < dtGrid.Rows.Count; i++)
                {
                    dQty += BaseDllMobile.ClsRetrunValue.ReturnDecimal(dtGrid.Rows[i]["送货数量"]);
                    dXS += BaseDllMobile.ClsRetrunValue.ReturnDecimal(dtGrid.Rows[i]["箱数"]);
                }
                lSum.Text = "条数:" + dtGrid.Rows.Count.ToString() + ";数量:" + dQty.ToString() + ";箱数:" + dXS.ToString();

            }
            catch (Exception ee)
            {
                Msg("新增失败 " + ee.Message);
            }
        }

        private void GetBar(string sBarCode, out string VenCode, out string Door, out string InvName, out string InvCode, out string iHZ
            , out string iQty, out string iSheDate, out string iBoxQty, out string OrderNo, out string iPlace)
        {
            VenCode = sBarCode.Substring(53 - 1, 12);
            Door = sBarCode.Substring(17 - 1, 3);
            InvName = "";
            InvCode = sBarCode.Substring(4 - 1, 10);
            iHZ = sBarCode.Substring(1 - 1, 2);
            iQty = sBarCode.Substring(46 - 1, 7);
            iSheDate = sBarCode.Substring(38 - 1, 8);
            iBoxQty = "0";
            OrderNo = sBarCode.Substring(30 - 1, 8);
            iPlace = sBarCode.Substring(66 - 1, 5);
        }

        int iFocRow = -1;

        private void btnDel_Click(object sender, EventArgs e)
        {
            try
            {
                if (iFocRow == -1)
                {
                    Msg("请选择要删除的行 ");
                    return;
                }

                if (iFocRow + 1 <= dtGrid.Rows.Count)
                {
                    DialogResult d = MessageBox.Show("确定删除第" + (iFocRow + 1).ToString() + "行数据？", "提示", MessageBoxButtons.YesNo, MessageBoxIcon.Asterisk, MessageBoxDefaultButton.Button1);

                    if (d == DialogResult.Yes)
                    {
                        dtGrid.Rows.RemoveAt(iFocRow);

                        decimal dQty = 0;
                        decimal dXS = 0;
                        for (int i = 0; i < dtGrid.Rows.Count; i++)
                        {
                            dQty += BaseDllMobile.ClsRetrunValue.ReturnDecimal(dtGrid.Rows[i]["送货数量"]);
                            dXS += BaseDllMobile.ClsRetrunValue.ReturnDecimal(dtGrid.Rows[i]["箱数"]);
                        }
                        lSum.Text = "条数:" + dtGrid.Rows.Count.ToString() + ";数量:" + dQty.ToString() + ";箱数:" + dXS.ToString();

                        Interaction.Beep();

                        iFocRow = -1;
                    }
                }
            }
            catch (Exception ee)
            {
                Msg("删行失败 " + ee.Message);
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
                Msg("获得行信息失败 " + ee.Message);
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                if (dtGrid == null || dtGrid.Rows.Count < 1)
                {
                    Msg("没有需要保存的数据 ");
                    return;
                }

                string sInfo = clsWeb.Save现品票登记(dtGrid);
                if (sInfo.Trim().Length > 2 && sInfo.Substring(0, 2) == "生成")
                {
                    Msg(sInfo);
                    dtGrid.Rows.Clear();
                    lSum.Text = "";

                    Interaction.Beep();
                }
                else
                {
                    Msg(sInfo);
                }
            }
            catch (Exception ee)
            {
                Msg("保存失败 " + ee.Message);
            }
        }

        private void txt单据号_KeyUp(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyValue == 82)
                {
                    btnAdd_Click(null, null);
                }
            }
            catch (Exception ee)
            {
                Msg("新增失败 " + ee.Message);
            }
        }

        private void btn返回_Click(object sender, EventArgs e)
        {
            try
            {
                this.Close();
            }
            catch (Exception ee)
            {
                Msg("返回失败 " + ee.Message);
            }
        }

        private void msgBox_Load(object sender, EventArgs e)
        {

        }
    }
}