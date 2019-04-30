using System;
using System.Linq;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using MobileBaseDLL;

namespace BarCode
{
    public partial class Frm材料入库 : FrmBase
    {
        DataTable dtTable;
        Cls材料检验合格入库 cls检验入库 = new Cls材料检验合格入库();

        public Frm材料入库()
        {
            InitializeComponent();

            dtTable = new DataTable();
            DataColumn dc = new DataColumn();
            dc.ColumnName = "序号";
            dtTable.Columns.Add(dc);

            dc = new DataColumn();
            dc.ColumnName = "物料编码";
            dtTable.Columns.Add(dc);

            dc = new DataColumn();
            dc.ColumnName = "货位编码";
            dtTable.Columns.Add(dc);

            dc = new DataColumn();
            dc.ColumnName = "本次入库数量";
            dtTable.Columns.Add(dc);

            dc = new DataColumn();
            dc.ColumnName = "本次入库件数";
            dtTable.Columns.Add(dc);

            dc = new DataColumn();
            dc.ColumnName = "仓库编码";
            dtTable.Columns.Add(dc);

            dc = new DataColumn();
            dc.ColumnName = "物料名称";
            dtTable.Columns.Add(dc);

            dc = new DataColumn();
            dc.ColumnName = "规格型号";
            dtTable.Columns.Add(dc);

            dc = new DataColumn();
            dc.ColumnName = "检验单号";
            dtTable.Columns.Add(dc);

            dc = new DataColumn();
            dc.ColumnName = "检验数量";
            dtTable.Columns.Add(dc);

            dc = new DataColumn();
            dc.ColumnName = "检验件数";
            dtTable.Columns.Add(dc);

            dc = new DataColumn();
            dc.ColumnName = "可入库数量";
            dtTable.Columns.Add(dc);

            dc = new DataColumn();
            dc.ColumnName = "可入库件数";
            dtTable.Columns.Add(dc);

            dc = new DataColumn();
            dc.ColumnName = "项目编码";
            dtTable.Columns.Add(dc);

            dc = new DataColumn();
            dc.ColumnName = "条形码";
            dtTable.Columns.Add(dc);

            dc = new DataColumn();
            dc.ColumnName = "bUsed";
            dtTable.Columns.Add(dc);

            dc = new DataColumn();
            dc.ColumnName = "bUsed2";
            dtTable.Columns.Add(dc);

            dc = new DataColumn();
            dc.ColumnName = "单据来源";
            dtTable.Columns.Add(dc);

            dc = new DataColumn();
            dc.ColumnName = "返回信息";
            dtTable.Columns.Add(dc);

            dc = new DataColumn();
            dc.ColumnName = "辅计量单位编码";
            dtTable.Columns.Add(dc);
            

            dataGrid1.DataSource = dtTable;
        }

        DataTable dt = new DataTable();

        private void Frm材料入库_Load(object sender, EventArgs e)
        {
            dateTime单据日期.Text = DateTime.Now.ToString("yyyy-MM-dd");
        }

        private void txt条形码_KeyUp(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyValue == 13 && txt条形码.Text.Trim() != "")
                {
                    string sErr = "";
                    DataTable dt = cls检验入库.GetBarArrInfo(txt条形码.Text.Trim(),out sErr);
                    if (dt == null || dt.Rows.Count < 1)
                    {
                        throw new Exception("条码扫描失败");
                    }

                    if (sErr != string.Empty)
                    {
                        throw new Exception(sErr);
                    }

                    string s条形码 = dt.Rows[0]["条形码"].ToString().Trim();
                    for (int i = 0; i < dtTable.Rows.Count; i++)
                    {
                        string s条形码2 = dtTable.Rows[i]["条形码"].ToString().Trim();
                        if (s条形码 == s条形码2)
                        {
                            DialogResult d = MessageBox.Show("该条码已扫描，是否分货位继续？", "提示", MessageBoxButtons.YesNo, MessageBoxIcon.Asterisk, MessageBoxDefaultButton.Button1);
                            if (d != DialogResult.Yes)
                            {
                                throw new Exception("该条码已扫");
                            }

                            txt条数.Text = (MobileBaseDLL.ClsBaseDataInfo.ReturnInt(txt条数.Text) + 1).ToString();
                        }
                    }

                    DataRow dr = dtTable.NewRow();
                    for (int i = 0; i < dt.Columns.Count; i++)
                    {
                        dr[dt.Columns[i].ColumnName] = dt.Rows[0][i];
                    }

                    if (txt货位.Text.Trim() != "")
                    {
                        string s货位 = clsDES.Decrypt(txt货位.Text.Trim());
                        string sInvCode = dt.Rows[0]["物料编码"].ToString().Trim();
                        int iCou = clsu8.Chk货位物料(s货位, sInvCode);
                        if (iCou <= 0)
                        {
                            DialogResult d = MessageBox.Show("物料、货位不对应，是否继续", "提示", MessageBoxButtons.YesNo, MessageBoxIcon.Asterisk, MessageBoxDefaultButton.Button1);
                            if (d != DialogResult.Yes)
                            {
                                throw new Exception("物料货位不对应");
                            }
                        }

                        DataTable dt货位 = clsu8.Chk货位(s货位);
                        if (dt货位 == null || dt货位.Rows.Count < 1)
                        {
                            throw new Exception("货位信息失败");
                        }
                        if (dt货位.Rows[0]["返回信息"].ToString().Trim() != "")
                        {
                            throw new Exception(dt货位.Rows[0]["返回信息"].ToString().Trim());
                        }

                        dr["货位编码"] = dt货位.Rows[0]["货位编码"].ToString().Trim();
                        dr["仓库编码"] = dt货位.Rows[0]["仓库编码"].ToString().Trim();
                    }
  
                    dr["序号"] = dtTable.Rows.Count + 1;
                    dtTable.Rows.Add(dr);

                    dataGrid1.DataSource = dtTable;

                    txt条形码.Text = "";
                    txt条形码.Focus();
                }
            }
            catch (Exception ee)
            {
                txt条形码.Text = "";
                msgBox.textBox1.Text = "扫描失败:" + ee.Message;
                msgBox.ShowDialog();
            }
        }

       

        private void btn删行_Click(object sender, EventArgs e)
        {
            for (int i = dtTable.Rows.Count - 1; i >= 0; i--)
            {
                if (dataGrid1.IsSelected(i))
                    dtTable.Rows.RemoveAt(i);
            }
        }

        private void btn保存_Click(object sender, EventArgs e)
        {
            try
            {
                int i1 = dtTable.Rows.Count;
                int i2 = MobileBaseDLL.ClsBaseDataInfo.ReturnInt(txt条数.Text.Trim());
                if (i1 != i2)
                {
                    throw new Exception("条形码数量不一致");
                }
                if (dtTable == null || dtTable.Rows.Count < 1)
                {
                    throw new Exception("请先扫条形码");
                }

                decimal d本次入库累计 = 0;
                for (int i = 0; i < dtTable.Rows.Count; i++)
                {
                    dtTable.Rows[i]["bUsed"] = -1;
                    dtTable.Rows[i]["bUsed2"] = 0;

                    d本次入库累计 = d本次入库累计 + MobileBaseDLL.ClsBaseDataInfo.ReturnDecimal(dtTable.Rows[i]["本次入库数量"]);
                }

                DialogResult d = MessageBox.Show("本次入库数量：" + d本次入库累计.ToString(), "提示", MessageBoxButtons.YesNo, MessageBoxIcon.Asterisk, MessageBoxDefaultButton.Button1);
                if (d != DialogResult.Yes)
                    return;

                string sReturn = cls检验入库.Insert入库单(dtTable, dateTime单据日期.Value);

                if (sReturn.Substring(0, 2) == "成功")
                {
                    dtTable.Clear();
                    txt货位.Text = "";
                    txt条数.Text = "";
                    txt条形码.Text = "";
                    txt条数.Focus();
                }


                msgBox.textBox1.Text = sReturn;
                msgBox.ShowDialog();


            }
            catch (Exception ee)
            {
                msgBox.textBox1.Text = "保存失败:" + ee.Message;
                msgBox.ShowDialog();
            }
        }

        int iRow = -1;
        int iCol = -1;
        private void dataGrid1_CurrentCellChanged(object sender, EventArgs e)
        {
            try
            {
                DataGridCell editCell = dataGrid1.CurrentCell;
                Rectangle cellPos = new Rectangle();
                iRow = editCell.RowNumber;
                iCol = editCell.ColumnNumber;

                if (iCol == 2 || iCol == 3)
                {
                    cellPos = dataGrid1.GetCellBounds(iRow, iCol);
                    txt编辑.Left = cellPos.Left;
                    txt编辑.Top = cellPos.Top + dataGrid1.Top;
                    txt编辑.Width = cellPos.Width;
                    txt编辑.Height = cellPos.Height;
                    txt编辑.Visible = true;
                    txt编辑.Text = dtTable.Rows[editCell.RowNumber][editCell.ColumnNumber].ToString().Trim();
                    txt编辑.Focus();
                }
                else if (iCol == 4)
                {
                    decimal d检验件数 = MobileBaseDLL.ClsBaseDataInfo.ReturnDecimal(dtTable.Rows[iRow]["检验件数"]);
                    if (d检验件数 > 0)
                    {
                        cellPos = dataGrid1.GetCellBounds(iRow, iCol);
                        txt编辑.Left = cellPos.Left;
                        txt编辑.Top = cellPos.Top + dataGrid1.Top;
                        txt编辑.Width = cellPos.Width;
                        txt编辑.Height = cellPos.Height;
                        txt编辑.Visible = true;
                        txt编辑.Text = dtTable.Rows[editCell.RowNumber][editCell.ColumnNumber].ToString().Trim();
                        txt编辑.Focus();
                    }
                }
                else
                {
                    txt编辑.Text = "";
                    txt编辑.Visible = false;
                    iRow = -1;
                    iCol = -1;
                }
            }
            catch
            {
                txt编辑.Text = "";
                txt编辑.Visible = false;
                iRow = -1;
                iCol = -1;
            }
        }

        private void txt编辑_KeyUp(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyValue == 13)
                {
                    txt编辑_LostFocus(null, null);
                }
            }
            catch
            { }
        }

        private void txt条形码_LostFocus(object sender, EventArgs e)
        {
            txt编辑.Text = "";
            txt编辑.Visible = false;
        }

        private void txt条数_KeyUp(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyValue == 13)
                {
                    if (txt条数.Text.Trim() == "")
                        return;

                    //string[] s = txt条形码.Text.Trim().Split('$');
                    //if (s[0].Trim() != "5")
                    //{
                    //    txt条形码.Text = "";
                    //    msgBox.textBox1.Text = "条形码类型错误";
                    //    msgBox.ShowDialog();
                    //    return;
                    //}
                    //if (s[1].Trim() != MobileBaseDLL.ClsBaseDataInfo.sUFDataBaseName.Substring(7, 3))
                    //{
                    //    txt条形码.Text = "";
                    //    msgBox.textBox1.Text = "帐套错误";
                    //    msgBox.ShowDialog();
                    //    return;
                    //}

                    int iR = MobileBaseDLL.ClsBaseDataInfo.ReturnInt(txt条数.Text.Trim());
                    if (iR <= 0)
                    {
                        throw new Exception("条数必须大于0");
                    }
                    txt货位.Focus();
                }
            }
            catch (Exception ee)
            {
                MessageBox.Show(ee.Message);
                if (txt条数.Text.Trim() != "")
                {
                    txt条数.Text = "";
                }
            }
        }

        private void txt货位_KeyUp(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyValue == 13)
                {
                    if (txt货位.Text.Trim() == "")
                    {
                        return;
                    }
                    string s货位 = clsDES.Decrypt(txt货位.Text.Trim());
                    DataTable dt货位 = clsu8.Chk货位(s货位);
                    if (dt货位 == null || dt货位.Rows.Count < 1)
                    {
                        throw new Exception("货位信息失败");
                    }
                    if (dt货位.Rows[0]["返回信息"].ToString().Trim() != "")
                    {
                        throw new Exception(dt货位.Rows[0]["返回信息"].ToString().Trim());
                    }

                    txt条形码.Focus();
                }
            }
            catch (Exception ee)
            {
                MessageBox.Show("货位错误:" + ee.Message);
                if (txt货位.Text.Trim() != "")
                {
                    txt货位.Text = "";
                }
            }
        }

        private void txt编辑_LostFocus(object sender, EventArgs e)
        {
            try
            {
                if (iRow == -1 || iCol == -1)
                    return;

                if (iCol == 2)
                {
                    //判断货位
                    string s货位 = txt编辑.Text.Trim();
                    DataTable dt货位 = clsu8.Chk货位(s货位);
                    if (dt货位 == null || dt货位.Rows.Count < 1)
                    {
                        throw new Exception("货位信息失败");
                    }
                    if (dt货位.Rows[0]["返回信息"].ToString().Trim() != "")
                    {
                        throw new Exception(dt货位.Rows[0]["返回信息"].ToString().Trim());
                    }


                    dtTable.Rows[iRow]["货位编码"] = s货位;
                    dtTable.Rows[iRow]["仓库编码"] = dt货位.Rows[0]["仓库编码"].ToString().Trim();
                }
                if (iCol == 3)
                {
                    decimal d数量 = MobileBaseDLL.ClsBaseDataInfo.ReturnDecimal(txt编辑.Text);
                    decimal d本次入库数量 = MobileBaseDLL.ClsBaseDataInfo.ReturnDecimal(dtTable.Rows[iRow]["本次入库数量"]);
                    decimal d检验数量 = MobileBaseDLL.ClsBaseDataInfo.ReturnDecimal(dtTable.Rows[iRow]["检验数量"]);
                    decimal d检验件数 = MobileBaseDLL.ClsBaseDataInfo.ReturnDecimal(dtTable.Rows[iRow]["检验件数"]);
                    if (d数量 != d本次入库数量)
                    {
                        if (d数量 <= 0)
                        {
                            MessageBox.Show("本次入库数量必须大于0");
                            return;
                        }

                        if (d检验件数 > 0 && d数量 > 0)
                        {
                            if (radio数量.Checked)
                            {
                                decimal d件数 = MobileBaseDLL.ClsBaseDataInfo.ReturnDecimal(d检验件数 * d数量 / d检验数量);
                                dtTable.Rows[iRow]["本次入库件数"] = d件数;
                            }
                        }
                    }
                    dtTable.Rows[iRow][iCol] = txt编辑.Text.Trim();
                }

                if (iCol == 4)
                {
                    decimal d件数 = MobileBaseDLL.ClsBaseDataInfo.ReturnDecimal(txt编辑.Text);
                    decimal d本次入库件数 = MobileBaseDLL.ClsBaseDataInfo.ReturnDecimal(dtTable.Rows[iRow]["本次入库件数"]);
                    decimal d检验数量 = MobileBaseDLL.ClsBaseDataInfo.ReturnDecimal(dtTable.Rows[iRow]["检验数量"]);
                    decimal d检验件数 = MobileBaseDLL.ClsBaseDataInfo.ReturnDecimal(dtTable.Rows[iRow]["检验件数"]);

                    if (d件数 != d本次入库件数)
                    {
                        if (d检验件数 < 0)
                        {
                            iRow = -1;
                            iCol = -1;
                            txt编辑.Visible = false;
                            txt编辑.Text = "";
                        }
                        else
                        {
                            if (d件数 <= 0)
                            {
                                MessageBox.Show("本次入库件数必须大于0");
                                return;
                            }
                            if (radio件数.Checked)
                            {
                                decimal d数量 = MobileBaseDLL.ClsBaseDataInfo.ReturnDecimal(d检验数量 * d件数 / d检验件数);
                                dtTable.Rows[iRow]["本次入库数量"] = d数量;
                            }
                        }
                    }
                    dtTable.Rows[iRow][iCol] = txt编辑.Text.Trim();
                }

                iRow = -1;
                iCol = -1;
                txt编辑.Visible = false;
                txt编辑.Text = "";
            }
            catch
            { }
        }
    }
}