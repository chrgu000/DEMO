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
    public partial class Frm到货 : FrmBase
    {
        DataTable dtTable;
        Cls到货 cls到货 = new Cls到货();

        int i栈板1 = 0;
        int i栈板2 = 0;
        int i栈板3 = 0;
        int i栈板4 = 0;
        int i栈板5 = 0;
        int i栈板6 = 0;
        int i栈板7 = 0;
        int i栈板8 = 0;

        public Frm到货()
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
            dc.ColumnName = "物料名称";
            dtTable.Columns.Add(dc);

            dc = new DataColumn();
            dc.ColumnName = "本次到货数量";
            dtTable.Columns.Add(dc);

            dc = new DataColumn();
            dc.ColumnName = "本次到货件数";
            dtTable.Columns.Add(dc);

            dc = new DataColumn();
            dc.ColumnName = "规格型号";
            dtTable.Columns.Add(dc);

            dc = new DataColumn();
            dc.ColumnName = "订单号";
            dtTable.Columns.Add(dc);

            dc = new DataColumn();
            dc.ColumnName = "单据日期";
            dtTable.Columns.Add(dc);

            dc = new DataColumn();
            dc.ColumnName = "单据类型";
            dtTable.Columns.Add(dc);

            dc = new DataColumn();
            dc.ColumnName = "部门编码";
            dtTable.Columns.Add(dc);

            dc = new DataColumn();
            dc.ColumnName = "部门";
            dtTable.Columns.Add(dc);

            dc = new DataColumn();
            dc.ColumnName = "业务员编码";
            dtTable.Columns.Add(dc);

            dc = new DataColumn();
            dc.ColumnName = "业务员";
            dtTable.Columns.Add(dc);

            dc = new DataColumn();
            dc.ColumnName = "备注";
            dtTable.Columns.Add(dc);

            dc = new DataColumn();
            dc.ColumnName = "外销单号";
            dtTable.Columns.Add(dc);

            dc = new DataColumn();
            dc.ColumnName = "客户订单号";
            dtTable.Columns.Add(dc);

            dc = new DataColumn();
            dc.ColumnName = "供应商编码";
            dtTable.Columns.Add(dc);

            dc = new DataColumn();
            dc.ColumnName = "供应商";
            dtTable.Columns.Add(dc);

            dc = new DataColumn();
            dc.ColumnName = "订单数量";
            dtTable.Columns.Add(dc);

            dc = new DataColumn();
            dc.ColumnName = "订单件数";
            dtTable.Columns.Add(dc);

            dc = new DataColumn();
            dc.ColumnName = "主计量单位编码";
            dtTable.Columns.Add(dc);

            dc = new DataColumn();
            dc.ColumnName = "主计量";
            dtTable.Columns.Add(dc);

            dc = new DataColumn();
            dc.ColumnName = "货位编码";
            dtTable.Columns.Add(dc);

            dc = new DataColumn();
            dc.ColumnName = "货位";
            dtTable.Columns.Add(dc);

            dc = new DataColumn();
            dc.ColumnName = "辅计量单位编码";
            dtTable.Columns.Add(dc);

            dc = new DataColumn();
            dc.ColumnName = "辅计量";
            dtTable.Columns.Add(dc);

            dc = new DataColumn();
            dc.ColumnName = "默认仓库编码";
            dtTable.Columns.Add(dc);

            dc = new DataColumn();
            dc.ColumnName = "默认仓库";
            dtTable.Columns.Add(dc);

            dc = new DataColumn();
            dc.ColumnName = "应收数量";
            dtTable.Columns.Add(dc);

            dc = new DataColumn();
            dc.ColumnName = "应收件数";
            dtTable.Columns.Add(dc);

            dc = new DataColumn();
            dc.ColumnName = "原币无税单价";
            dtTable.Columns.Add(dc);

            dc = new DataColumn();
            dc.ColumnName = "含税单价";
            dtTable.Columns.Add(dc);

            dc = new DataColumn();
            dc.ColumnName = "本币无税单价";
            dtTable.Columns.Add(dc);

            dc = new DataColumn();
            dc.ColumnName = "税率";
            dtTable.Columns.Add(dc);

            dc = new DataColumn();
            dc.ColumnName = "入库上限";
            dtTable.Columns.Add(dc);

            dc = new DataColumn();  //委外使用（领用，入库倒冲）
            dc.ColumnName = "领用类型";
            dtTable.Columns.Add(dc);

            dc = new DataColumn();
            dc.ColumnName = "bUsed";
            dtTable.Columns.Add(dc);

            dc = new DataColumn();
            dc.ColumnName = "返回信息";
            dtTable.Columns.Add(dc);

            dc = new DataColumn();
            dc.ColumnName = "条形码";
            dtTable.Columns.Add(dc);

            dc = new DataColumn();
            dc.ColumnName = "订单ID";
            dtTable.Columns.Add(dc);

            dc = new DataColumn();
            dc.ColumnName = "订单子表ID";
            dtTable.Columns.Add(dc);

            dc = new DataColumn();
            dc.ColumnName = "制单人";
            dtTable.Columns.Add(dc);

            dc = new DataColumn();
            dc.ColumnName = "项目大类编码";
            dtTable.Columns.Add(dc);

            dc = new DataColumn();
            dc.ColumnName = "项目编码";
            dtTable.Columns.Add(dc);

            dc = new DataColumn();
            dc.ColumnName = "项目名称";
            dtTable.Columns.Add(dc);

            dataGrid1.DataSource = dtTable;
        }

        DataTable dt = new DataTable();

        private void Frm到货_Load(object sender, EventArgs e)
        {
            dateTime单据日期.Text = DateTime.Now.ToString("yyyy-MM-dd");

            txt栈板登记.Focus();
        }

        private void txt条形码_KeyUp(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyValue == 13)
                {
                    DataTable dt = cls到货.GetBarArrInfo(txt条形码.Text.Trim());
                    if (dt == null || dt.Rows.Count < 1)
                    {
                        throw new Exception("条码扫描失败");
                    }

                    string[] s = txt条形码.Text.Trim().Split('$');
                    if (s[0].Trim() != "2" && s[0].Trim() != "3")
                    {
                        txt条形码.Text = "";
                        msgBox.textBox1.Text = "条形码类型错误";
                        msgBox.ShowDialog();
                        return;
                    };
                    if (s[1].Trim() != MobileBaseDLL.ClsBaseDataInfo.sUFDataBaseName.Substring(7, 3))
                    {
                        txt条形码.Text = "";
                        msgBox.textBox1.Text = "帐套错误";
                        msgBox.ShowDialog();
                        return;
                    }

                    string s返回信息 = dt.Rows[0]["返回信息"].ToString().Trim();
                    if (s返回信息 != string.Empty)
                    {
                        throw new Exception(s返回信息);
                    }

                    string s条形码 = dt.Rows[0]["条形码"].ToString().Trim();
                    for (int i = 0; i < dtTable.Rows.Count; i++)
                    {
                        string s条形码2 = dtTable.Rows[i]["条形码"].ToString().Trim();
                        if (s条形码 == s条形码2)
                        {
                            throw new Exception("该条码已扫");
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
                        if (s货位 != "98")
                        {
                            DialogResult d = MessageBox.Show("物料、货位不对应，是否继续", "提示", MessageBoxButtons.YesNo, MessageBoxIcon.Asterisk, MessageBoxDefaultButton.Button1);
                            if (d != DialogResult.Yes)
                            {
                                throw new Exception("物料货位不对应");
                            }
                        }
                        dr["货位编码"] = s货位;
                        //dr["仓库编码"] = dt默认货位.Rows[0]["仓库编码"].ToString().Trim();
                    }

                    dr["制单人"] = MobileBaseDLL.ClsBaseDataInfo.sUserName;
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

                msgBox.textBox1.Text = "扫描条码失败:" + ee.Message;
                msgBox.ShowDialog();
                txt条形码.Focus();
            }
        }

        private DataTable GetArrInfo(string sBarCode)
        {
            return cls到货.GetBarArrInfo(sBarCode);
        }

        private void txt条数_KeyUp(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyValue == 13)
                {
                    txt栈板登记.Text = "";
                    i栈板1 = 0;
                    i栈板2 = 0;
                    i栈板3 = 0;
                    i栈板4 = 0;
                    i栈板5 = 0;
                    i栈板6 = 0;
                    i栈板7 = 0;
                    i栈板8 = 0;

                    if (txt条数.Text.Trim() == "")
                        return;

                    int iR = MobileBaseDLL.ClsBaseDataInfo.ReturnInt(txt条数.Text.Trim());
                    if (iR <= 0)
                    {
                        throw new Exception("条数必须大于0");
                    }
                    txt条形码.Focus();
                }
            }
            catch (Exception ee)
            {
                txt条数.Text = "";

                msgBox.textBox1.Text = ee.Message;
                msgBox.ShowDialog();
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

                    DataTable dt货位 = cls到货.Chk货位(s货位);
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
                msgBox.textBox1.Text = "货位错误:" + ee.Message;
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
                dtTable.TableName = "到货";
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

                    d本次入库累计 = d本次入库累计 + MobileBaseDLL.ClsBaseDataInfo.ReturnDecimal(dtTable.Rows[i]["本次到货数量"]);
                }


                DialogResult d = MessageBox.Show("本次到货数量：" + d本次入库累计.ToString(), "提示", MessageBoxButtons.YesNo, MessageBoxIcon.Asterisk, MessageBoxDefaultButton.Button1);
                if (d != DialogResult.Yes)
                    return;

                string sReturn = "";

                sReturn = cls到货.Insert到货单(dtTable, Convert.ToDateTime(dateTime单据日期.Text), i栈板1, i栈板2, i栈板3, i栈板4, i栈板5, i栈板6, i栈板7, i栈板8);

                if (sReturn.Substring(0, 2) == "成功")
                {
                    dtTable.Clear();
                    txt条数.Text = "";
                    txt条形码.Text = "";
                    txt栈板登记.Text = "";
                    
                    txt条数.Focus();

                    i栈板1 = 0;
                    i栈板2 = 0;
                    i栈板3 = 0;
                    i栈板4 = 0;
                    i栈板5 = 0;
                    i栈板6 = 0;
                    i栈板7 = 0;
                    i栈板8 = 0;
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

                if (iCol == 3 )
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
                    decimal d订单件数 = MobileBaseDLL.ClsBaseDataInfo.ReturnDecimal(dtTable.Rows[iRow]["订单件数"]);
                    if (d订单件数 > 0)
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

        private void txt编辑_LostFocus(object sender, EventArgs e)
        {
            try
            {
                if (iRow == -1 || iCol == -1)
                    return;

                if (iCol == 3)
                { 
                    decimal d数量 = MobileBaseDLL.ClsBaseDataInfo.ReturnDecimal(txt编辑.Text);
                    decimal d本次到货数量 = MobileBaseDLL.ClsBaseDataInfo.ReturnDecimal(dtTable.Rows[iRow]["本次到货数量"]);
                    decimal d订单数量 = MobileBaseDLL.ClsBaseDataInfo.ReturnDecimal(dtTable.Rows[iRow]["订单数量"]);
                    decimal d订单件数 = MobileBaseDLL.ClsBaseDataInfo.ReturnDecimal(dtTable.Rows[iRow]["订单件数"]);
                    if (d数量 != d本次到货数量)
                    {
                        if (d数量 <= 0)
                        {
                            MessageBox.Show("本次到货数量必须大于0");
                            return;
                        }

                        if (dtTable.Rows[iRow]["辅计量"].ToString().Trim() != "" || d数量 > 0)
                        {
                            if (radio数量.Checked)
                            {
                                decimal d件数 = MobileBaseDLL.ClsBaseDataInfo.ReturnDecimal(d订单件数 * d数量 / d订单数量);
                                dtTable.Rows[iRow]["本次到货件数"] = d件数;
                            }
                        }
                    }
                    dtTable.Rows[iRow][iCol] = txt编辑.Text.Trim();
                }

                if (iCol == 4)
                {
                    decimal d件数 = MobileBaseDLL.ClsBaseDataInfo.ReturnDecimal(txt编辑.Text);
                    decimal d本次到货件数 = MobileBaseDLL.ClsBaseDataInfo.ReturnDecimal(dtTable.Rows[iRow]["本次到货件数"]);
                    decimal d订单数量 = MobileBaseDLL.ClsBaseDataInfo.ReturnDecimal(dtTable.Rows[iRow]["订单数量"]);
                    decimal d订单件数 = MobileBaseDLL.ClsBaseDataInfo.ReturnDecimal(dtTable.Rows[iRow]["订单件数"]);

                    if (d件数 != d本次到货件数)
                    {
                        if (d订单件数 < 0)
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
                                MessageBox.Show("本次到货件数必须大于0");
                                return;
                            }
                            if (radio件数.Checked)
                            {
                                decimal d数量 = MobileBaseDLL.ClsBaseDataInfo.ReturnDecimal(d订单数量 * d件数 / d订单件数);
                                dtTable.Rows[iRow]["本次到货数量"] = d数量;
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

        private void txt栈板登记_KeyUp(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyValue == 13)
                {
                    if (txt栈板登记.Text.Trim() == "")
                        return;

                    long iR = MobileBaseDLL.ClsBaseDataInfo.ReturnLong(txt栈板登记.Text.Trim());
                    DataTable dt = cls到货.Get栈板打印(iR);

                    if (dt != null && dt.Rows.Count > 0)
                    {
                        i栈板1 = MobileBaseDLL.ClsBaseDataInfo.ReturnInt(dt.Rows[0]["栈板1"]);
                        i栈板2 = MobileBaseDLL.ClsBaseDataInfo.ReturnInt(dt.Rows[0]["栈板2"]);
                        i栈板3 = MobileBaseDLL.ClsBaseDataInfo.ReturnInt(dt.Rows[0]["栈板3"]);
                        i栈板4 = MobileBaseDLL.ClsBaseDataInfo.ReturnInt(dt.Rows[0]["栈板4"]);
                        i栈板5 = MobileBaseDLL.ClsBaseDataInfo.ReturnInt(dt.Rows[0]["栈板5"]);
                        i栈板6 = MobileBaseDLL.ClsBaseDataInfo.ReturnInt(dt.Rows[0]["栈板6"]);
                        i栈板7 = MobileBaseDLL.ClsBaseDataInfo.ReturnInt(dt.Rows[0]["栈板7"]);
                        i栈板8 = MobileBaseDLL.ClsBaseDataInfo.ReturnInt(dt.Rows[0]["栈板8"]);
                        txt条数.Text = MobileBaseDLL.ClsBaseDataInfo.ReturnInt(dt.Rows[0]["数量"]).ToString().Trim();
                    }
                    else
                    {
                        i栈板1 = 0;
                        i栈板2 = 0;
                        i栈板3 = 0;
                        i栈板4 = 0;
                        i栈板5 = 0;
                        i栈板6 = 0;
                        i栈板7 = 0;
                        i栈板8 = 0;
                        txt条数.Text = "";
                    }
                    txt条形码.Focus();
                }
            }
            catch (Exception ee)
            {
                txt条数.Text = "";

                msgBox.textBox1.Text = ee.Message;
                msgBox.ShowDialog();
            }
        }

        private void btn栈板_Click(object sender, EventArgs e)
        {
            Frm栈板 f = new Frm栈板();
            f.txt栈板1.Text = i栈板1.ToString().Trim();
            f.txt栈板2.Text = i栈板2.ToString().Trim();
            f.txt栈板3.Text = i栈板3.ToString().Trim();
            f.txt栈板4.Text = i栈板4.ToString().Trim();
            f.txt栈板5.Text = i栈板5.ToString().Trim();
            f.txt栈板6.Text = i栈板6.ToString().Trim();
            f.txt栈板7.Text = i栈板7.ToString().Trim();
            f.txt栈板8.Text = i栈板8.ToString().Trim();
            f.ShowDialog();

            i栈板1 = MobileBaseDLL.ClsBaseDataInfo.ReturnInt(f.txt栈板1.Text.Trim());
            i栈板2 = MobileBaseDLL.ClsBaseDataInfo.ReturnInt(f.txt栈板2.Text.Trim());
            i栈板3 = MobileBaseDLL.ClsBaseDataInfo.ReturnInt(f.txt栈板3.Text.Trim());
            i栈板4 = MobileBaseDLL.ClsBaseDataInfo.ReturnInt(f.txt栈板4.Text.Trim());
            i栈板5 = MobileBaseDLL.ClsBaseDataInfo.ReturnInt(f.txt栈板5.Text.Trim());
            i栈板6 = MobileBaseDLL.ClsBaseDataInfo.ReturnInt(f.txt栈板6.Text.Trim());
            i栈板7 = MobileBaseDLL.ClsBaseDataInfo.ReturnInt(f.txt栈板7.Text.Trim());
            i栈板8 = MobileBaseDLL.ClsBaseDataInfo.ReturnInt(f.txt栈板8.Text.Trim());
        }

        private void msgBox_Load(object sender, EventArgs e)
        {

        }
    }
}