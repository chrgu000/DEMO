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
    public partial class Frm出库 : FrmBase
    {

        public DataTable dtGrid = new DataTable();
        public Frm出库()
        {
            InitializeComponent();

            try
            {
                dtGrid.TableName = "dtGrid";

                DataColumn dc = new DataColumn();
                dc.ColumnName = "供应商";
                dtGrid.Columns.Add(dc);

                dc = new DataColumn();
                dc.ColumnName = "产品名称";
                dtGrid.Columns.Add(dc);

                dc = new DataColumn();
                dc.ColumnName = "品番";
                dtGrid.Columns.Add(dc);

                dc = new DataColumn();
                dc.ColumnName = "数量";
                dtGrid.Columns.Add(dc);

                dc = new DataColumn();
                dc.ColumnName = "箱数";
                dtGrid.Columns.Add(dc);

                dc = new DataColumn();
                dc.ColumnName = "单据号";
                dtGrid.Columns.Add(dc);

                dc = new DataColumn();
                dc.ColumnName = "单据子表序号";
                dtGrid.Columns.Add(dc);

                dc = new DataColumn();
                dc.ColumnName = "单据序号";
                dtGrid.Columns.Add(dc);

                dc = new DataColumn();
                dc.ColumnName = "登记人";
                dtGrid.Columns.Add(dc);

                dc = new DataColumn();
                dc.ColumnName = "仓库";
                dtGrid.Columns.Add(dc);
            }
            catch (Exception ee)
            {
                Msg("生成列表失败 " + ee.Message);
            }
        }

        private void Frm出库_Load(object sender, EventArgs e)
        {
            try
            {
                dataGrid1.DataSource = dtGrid;

                lSum.Text = "";

                txt单据号.Focus();
            }
            catch (Exception ee)
            {
                Msg("加载出库单失败 " + ee.Message);
            }
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            try
            {
                string sBarCode = txt单据号.Text.Trim();
                if (sBarCode.Length == 8)
                {
                    int iCou = ReturnObjectToInt(clsWeb.Chk发货计划(sBarCode));
                    if (iCou == 0) 
                    {
                        Msg("发货计划不存在或发货计划已出库");
                        return;
                    }
                    Frm出库_Edit fEdit = new Frm出库_Edit(sBarCode, dtGrid);
                    fEdit.ShowDialog();

                    dtGrid = fEdit.dtGrid;

                    decimal dQty = 0;
                    decimal dXS = 0;

                    for (int i = 0; i < dtGrid.Rows.Count; i++)
                    {
                        dQty += BaseDllMobile.ClsRetrunValue.ReturnDecimal(dtGrid.Rows[i]["数量"]);
                        dXS += BaseDllMobile.ClsRetrunValue.ReturnDecimal(dtGrid.Rows[i]["箱数"]);
                    }
                    lSum.Text = "条数:" + dtGrid.Rows.Count.ToString() + ";送货累计:" + dQty.ToString() + ";送货箱数:" + dXS.ToString();
                }
            }
            catch (Exception ee)
            {
                Msg("新增失败 " + ee.Message);
            }
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
                            dQty += BaseDllMobile.ClsRetrunValue.ReturnDecimal(dtGrid.Rows[i]["数量"]);
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
                string sErr = "";

                string sWHCode = "";

                for (int i = 0; i < dtGrid.Rows.Count; i++)
                {
                    if (dtGrid.Rows[i]["仓库"].ToString().Trim() == "")
                    {
                        throw new Exception("行" + (i + 1).ToString() + "仓库不能为空");
                    }
                    if (i == 0)
                    {
                        sWHCode = dtGrid.Rows[i]["仓库"].ToString().Trim();
                    }
                    else
                    {
                        if (sWHCode != dtGrid.Rows[i]["仓库"].ToString().Trim())
                        {
                            throw new Exception("不支持从多个仓库同时发货");
                        }
                    }
                }

                string sInfo = clsWeb.Save出库单(dtGrid);
                if (sInfo.Trim().Length > 2 && sInfo.Substring(0, 2) == "生成")
                {
                    Msg(sInfo);
                    dtGrid.Rows.Clear();
                    txt单据号.Text = "";
                    Interaction.Beep();
                }
                else
                    Msg(sInfo);
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
                if (e.KeyCode == Keys.Enter)
                {
                    btnAdd_Click(null, null);
                }
            }
            catch (Exception ee)
            {
                Msg(ee.Message);
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

    }
}