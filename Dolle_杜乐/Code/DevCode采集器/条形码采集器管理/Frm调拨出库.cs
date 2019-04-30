using System;
using System.Linq;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Collections;

namespace BarCode
{
    public partial class Frm调拨出库 : FrmBase
    {
        DataTable dtTable;

        public Frm调拨出库()
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
            dc.ColumnName = "本次出库数量";
            dtTable.Columns.Add(dc);

            dc = new DataColumn();
            dc.ColumnName = "本次出库件数";
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
            dc.ColumnName = "仓库";
            dtTable.Columns.Add(dc);

            dc = new DataColumn();
            dc.ColumnName = "单据号";
            dtTable.Columns.Add(dc);

            dc = new DataColumn();
            dc.ColumnName = "单据日期";
            dtTable.Columns.Add(dc);

            dc = new DataColumn();
            dc.ColumnName = "数量";
            dtTable.Columns.Add(dc);

            dc = new DataColumn();
            dc.ColumnName = "件数";
            dtTable.Columns.Add(dc);

            dc = new DataColumn();
            dc.ColumnName = "出库单ID";
            dtTable.Columns.Add(dc);

            dc = new DataColumn();
            dc.ColumnName = "出库单子表ID";
            dtTable.Columns.Add(dc);

            dc = new DataColumn();
            dc.ColumnName = "bUsed";
            dtTable.Columns.Add(dc);

            dc = new DataColumn();
            dc.ColumnName = "bUsed2";
            dtTable.Columns.Add(dc);

            dc = new DataColumn();
            dc.ColumnName = "辅计量编码";
            dtTable.Columns.Add(dc);
            
            dataGrid1.DataSource = dtTable;
        }

        DataTable dt = new DataTable();

        private void Frm调拨出库_Load(object sender, EventArgs e)
        {
            date单据日期.Text = DateTime.Now.ToString("yyyy-MM-dd");
        }

        private void txt条形码_KeyUp(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyValue == 13 && txt条形码.Text.Trim() != "")
                {
                    if (txt货位.Text.Trim() == "")
                    {
                        MessageBox.Show("请先扫描货位");
                        txt条形码.Text = "";
                        txt货位.Focus();
                        return;
                    }

                    string[] s = txt条形码.Text.Trim().Split('$');

                    if (s[0].Trim() != "9")
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

                    string sErr = "";

                    string sSQL = "";

                    string s货位 = clsDES.Decrypt(txt货位.Text.Trim());
                    sSQL = "select cast(null as int) as 序号, a.cCode as 单据号,a.dDate as 单据日期,a.cWhCode as 仓库编码,g.cWhName as 仓库, '" + s货位 + "' as 货位编码, b.cInvCode as 物料编码,e.cInvName as 物料名称,e.cInvStd as 规格型号 " +
                         "	,b.iQuantity - isnull(d.iqty,0) as 本次出库数量,b.iNum - isnull(d.inum,0) as 本次出库件数 " +
                         "	,b.iQuantity as 数量,b.iNum as 件数,d.iqty as 货位数量,d.inum as 货位件数,a.ID as 出库单ID,b.AutoID as 出库单子表ID,0 as bUsed,0 as bUsed2,b.cAssUnit as 辅计量编码 " +
                         "from @u8.rdrecord09 a inner join @u8.rdrecords09 b on a.id = b.ID " +
                         "	inner join @u8.Warehouse c on c.cWhCode = a.cWhCode " +
                         "	left join (select rdsid,cInvCode,sum(iQuantity) as iqty,sum(iNum) as inum from @u8.InvPosition group by rdsid,cInvCode) d on d.RdsID = b.AutoID " +
                         "	inner join @u8.Inventory e on e.cInvCode = b.cInvCode " +
                         "   inner join @u8.Warehouse  g on g.cWhCode = a.cWhCode " +
                         "where b.AutoID = " + s[2].Trim();

                    dt = clsSQLCommond.ExecQuery(sSQL);
                    if (dt.Rows.Count != 1)
                    {
                        sErr = "没有符合的单据！";
                        dt = null;
                    }

                    //decimal d可入库数量 = MobileBaseDLL.ClsBaseDataInfo.ReturnDecimal(dt.Rows[0]["可入库数量"]);
                    //decimal d可入库件数 = MobileBaseDLL.ClsBaseDataInfo.ReturnDecimal(dt.Rows[0]["可入库件数"]);
                    //decimal d待指定数量 = MobileBaseDLL.ClsBaseDataInfo.ReturnDecimal(dt.Rows[0]["待指定数量"]);
                    //decimal d待指定件数 = MobileBaseDLL.ClsBaseDataInfo.ReturnDecimal(dt.Rows[0]["待指定件数"]);

                    //if (d待指定数量 > d可入库数量)
                    //{
                    //    sErr = "入库数量已经超出，请核查！";
                    //}


                    if (sErr != string.Empty)
                    {
                        throw new Exception(sErr);
                    }

                    string s出库单子表ID = dt.Rows[0]["出库单子表ID"].ToString().Trim();
                    for (int i = 0; i < dtTable.Rows.Count; i++)
                    {
                        string s出库单表体ID2 = dtTable.Rows[i]["出库单子表ID"].ToString().Trim();

                        if (s出库单子表ID == s出库单表体ID2)
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
                    for (int i = 0; i < dtTable.Columns.Count; i++)
                    {
                        string sColName = dtTable.Columns[i].ToString().Trim();
                        dr[sColName] = dt.Rows[0][sColName];
                    }

                    if (txt货位.Text.Trim() != "")
                    {
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
                    //else
                    //{
                    //    string sInvCode = dt.Rows[0]["物料编码"].ToString().Trim();
                    //    DataTable dt默认货位 = clsu8.Get默认入库货位(sInvCode);

                    //    if (dt默认货位 == null || dt默认货位.Rows.Count < 1)
                    //    {
                    //        throw new Exception("货位信息失败");
                    //    }
                    //    if (dt默认货位.Rows[0]["返回信息"].ToString().Trim() != "")
                    //    {
                    //        throw new Exception(dt默认货位.Rows[0]["返回信息"].ToString().Trim());
                    //    }

                    //    dr["货位编码"] = dt默认货位.Rows[0]["货位编码"].ToString().Trim();
                    //    dr["仓库编码"] = dt默认货位.Rows[0]["仓库编码"].ToString().Trim();
                    //}
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
     
                decimal d本次累计 = 0;
                for (int i = 0; i < dtTable.Rows.Count; i++)
                {
                    dtTable.Rows[i]["bUsed"] = 0;
                    dtTable.Rows[i]["bUsed2"] = 0;

                    d本次累计 = d本次累计 + MobileBaseDLL.ClsBaseDataInfo.ReturnDecimal(dtTable.Rows[i]["本次出库数量"]);
                }

                DialogResult d = MessageBox.Show("本次出库数量：" + d本次累计.ToString(), "提示", MessageBoxButtons.YesNo, MessageBoxIcon.Asterisk, MessageBoxDefaultButton.Button1);
                if (d != DialogResult.Yes)
                    return;

                string sErr="";
                for (int i = 0; i < dtTable.Rows.Count; i++)
                {
                    long lbUsed = MobileBaseDLL.ClsBaseDataInfo.ReturnLong(dtTable.Rows[i]["bUsed"]);
                    if (lbUsed != 0)
                        continue;

                    long lAutoID = MobileBaseDLL.ClsBaseDataInfo.ReturnLong(dtTable.Rows[i]["出库单子表ID"]);
                    string s物料编码 = dtTable.Rows[i]["物料编码"].ToString().Trim();

                    string s货位编码 = dtTable.Rows[i]["货位编码"].ToString().Trim();

                    decimal d货位现存数量 = 0;
                    decimal d货位现存件数 = 0;
                    clsu8.Get货位现存量(s物料编码, s货位编码, out d货位现存数量, out d货位现存件数);

                    decimal d货位本次发料数量 = MobileBaseDLL.ClsBaseDataInfo.ReturnLong(dtTable.Rows[i]["本次出库数量"]);
                    decimal d货位本次发料件数 = MobileBaseDLL.ClsBaseDataInfo.ReturnLong(dtTable.Rows[i]["本次出库件数"]);

                    decimal d本次货位累计出库数量 = MobileBaseDLL.ClsBaseDataInfo.ReturnDecimal(dtTable.Rows[i]["本次出库数量"]);
                    decimal d本次货位累计出库件数 = MobileBaseDLL.ClsBaseDataInfo.ReturnDecimal(dtTable.Rows[i]["本次出库件数"]);

                    string s超出 = "行" + (i + 1);
                    string s超出2 = "行" + (i + 1);

                    for (int j = i + 1; j < dtTable.Rows.Count; j++)
                    {
                        long lAutoID2 = MobileBaseDLL.ClsBaseDataInfo.ReturnLong(dtTable.Rows[j]["出库单子表ID"]);
                        if (lAutoID == lAutoID2)
                        {
                            string s货位编码2 = dtTable.Rows[j]["货位编码"].ToString().Trim();
                            if (s货位编码 == s货位编码2)
                            {
                                d本次货位累计出库数量 += MobileBaseDLL.ClsBaseDataInfo.ReturnDecimal(dtTable.Rows[j]["本次出库数量"]);
                                d本次货位累计出库件数 += MobileBaseDLL.ClsBaseDataInfo.ReturnDecimal(dtTable.Rows[j]["本次出库件数"]);

                                dtTable.Rows[j]["bUsed"] = lAutoID;
                                s超出 = s超出 + "," + "行" + (j+1);
                            }
                        }
                    }

                    if (d本次货位累计出库数量 > d货位现存数量 || d本次货位累计出库件数 > d货位现存件数)
                    {
                        sErr = sErr + s超出 + "货位数量不足\r\n";
                    }

                    dtTable.Rows[i]["bUsed"] = lAutoID;
                }

                for (int i = 0; i < dtTable.Rows.Count; i++)
                {
                    long lbUsed = MobileBaseDLL.ClsBaseDataInfo.ReturnLong(dtTable.Rows[i]["bUsed2"]);
                    if (lbUsed != 0)
                        continue;

                    long lAutoID = MobileBaseDLL.ClsBaseDataInfo.ReturnLong(dtTable.Rows[i]["出库单子表ID"]);
                    string s物料编码 = dtTable.Rows[i]["物料编码"].ToString().Trim();

                    string s货位编码 = dtTable.Rows[i]["货位编码"].ToString().Trim();

                    decimal d货位现存数量 = 0;
                    decimal d货位现存件数 = 0;
                    clsu8.Get货位现存量(s物料编码, s货位编码, out d货位现存数量, out d货位现存件数);

                    decimal d货位本次发料数量 = MobileBaseDLL.ClsBaseDataInfo.ReturnLong(dtTable.Rows[i]["本次出库数量"]);
                    decimal d货位本次发料件数 = MobileBaseDLL.ClsBaseDataInfo.ReturnLong(dtTable.Rows[i]["本次出库件数"]);

                    decimal d本次累计出库数量 = MobileBaseDLL.ClsBaseDataInfo.ReturnDecimal(dtTable.Rows[i]["本次出库数量"]);
                    decimal d本次累计出库件数 = MobileBaseDLL.ClsBaseDataInfo.ReturnDecimal(dtTable.Rows[i]["本次出库件数"]);

                    decimal d单据数量 = MobileBaseDLL.ClsBaseDataInfo.ReturnDecimal(dtTable.Rows[i]["数量"]);
                    decimal d单据件数 = MobileBaseDLL.ClsBaseDataInfo.ReturnDecimal(dtTable.Rows[i]["件数"]);

                    string s超出 = "行" + (i + 1);
                    string s超出2 = "行" + (i + 1);

                    for (int j = i + 1; j < dtTable.Rows.Count; j++)
                    {
                        long lAutoID2 = MobileBaseDLL.ClsBaseDataInfo.ReturnLong(dtTable.Rows[j]["出库单子表ID"]);
                        if (lAutoID == lAutoID2)
                        {
                            d本次累计出库数量 += MobileBaseDLL.ClsBaseDataInfo.ReturnDecimal(dtTable.Rows[j]["本次出库数量"]);
                            d本次累计出库件数 += MobileBaseDLL.ClsBaseDataInfo.ReturnDecimal(dtTable.Rows[j]["本次出库件数"]);

                            dtTable.Rows[j]["bUsed2"] = lAutoID;
                            s超出2 = s超出2 + "," + "行" + (j + 1);
                        }
                    }

                    if (d本次累计出库数量 > d单据数量 || d本次累计出库件数 > d单据件数)
                    {
                        sErr = sErr + s超出2 + "超出单据量\r\n";
                    }
                    if (d本次累计出库数量 < d单据数量 || d本次累计出库件数 < d单据件数)
                    {
                        sErr = sErr + s超出2 + "发料不足单据量\r\n";
                    }

                    dtTable.Rows[i]["bUsed2"] = lAutoID;
                }


                if(sErr.Length > 0)
                {
                    throw new Exception(sErr);
                }

                ArrayList aList = new ArrayList();
                for (int i = 0; i < dtTable.Rows.Count; i++)
                {
                    long iID = MobileBaseDLL.ClsBaseDataInfo.ReturnLong(dtTable.Rows[i]["出库单ID"]);
                    long iIDDetail = MobileBaseDLL.ClsBaseDataInfo.ReturnLong(dtTable.Rows[i]["出库单子表ID"]);

                    decimal d货位数量 = MobileBaseDLL.ClsBaseDataInfo.ReturnDecimal(dtTable.Rows[i]["本次出库数量"]);
                    decimal d货位件数 = MobileBaseDLL.ClsBaseDataInfo.ReturnDecimal(dtTable.Rows[i]["本次出库件数"]);
                    string s货位件数 = "null";
                    if (d货位件数 > 0)
                        s货位件数 = d货位件数.ToString();

                    string s辅计量编码 = "null";
                    if (dtTable.Rows[i]["辅计量编码"].ToString().Trim() != "")
                        s辅计量编码 = dtTable.Rows[i]["辅计量编码"].ToString().Trim();

                    //string sSQL = "Insert Into @u8.InvPosition(rdsid,rdid,cwhcode,cposcode,cinvcode,cbatch,cfree1,cfree2,dvdate,iquantity" +
                    //            ",inum,cmemo,chandler,ddate,brdflag,csource,cfree3,cfree4,cfree5,cfree6" +
                    //            ",cfree7,cfree8,cfree9,cfree10,cassunit,cbvencode,itrackid,dmadedate,imassdate,cmassunit" +
                    //            ",cvmivencode,iexpiratdatecalcu,cexpirationdate,dexpirationdate) " +
                    //        "Values (" + iIDDetail + ",N'" + iID + "',N'" + dtTable.Rows[i]["仓库编码"].ToString().Trim() + "',N'" + dtTable.Rows[i]["货位编码"].ToString().Trim() + "',N'" + dtTable.Rows[i]["物料编码"].ToString().Trim() + "',Null,Null,Null,Null," + d货位数量 + " " +
                    //            "," + d货位件数 + ",Null,N'" + MobileBaseDLL.ClsBaseDataInfo.sUserName + "',N'" + date单据日期.Value.ToString("yyyy-MM-dd") + "',0,Null,Null,Null,Null,Null" +
                    //            ",Null,Null,Null,Null," + s辅计量编码 + ",Null,Null,Null,Null,Null" +
                    //            ",Null,0,Null,Null)";
                    //aList.Add(sSQL);
                    Model.InvPosition model = new BarCode.Model.InvPosition();
                    model.RdsID = iIDDetail;
                    model.RdID = iID;
                    model.cWhCode = dtTable.Rows[i]["仓库编码"].ToString().Trim();
                    model.cPosCode = dtTable.Rows[i]["货位编码"].ToString().Trim();
                    model.cInvCode = dtTable.Rows[i]["物料编码"].ToString().Trim();
                    model.iQuantity = d货位数量;
                    model.iNum = d货位件数;
                    model.cHandler = MobileBaseDLL.ClsBaseDataInfo.sUserName;
                    model.dDate = MobileBaseDLL.ClsBaseDataInfo.ReturnDate(date单据日期.Value.ToString("yyyy-MM-dd"));
                    model.bRdFlag = 0;
                    model.cAssUnit = s辅计量编码;
                    model.iTrackId = 0;
                    model.iExpiratDateCalcu = 0;
                    model.cvouchtype = "09";
                    model.dVouchDate = MobileBaseDLL.ClsBaseDataInfo.ReturnDate(date单据日期.Value.ToString("yyyy-MM-dd"));

                    DAL.InvPosition dal = new BarCode.DAL.InvPosition();
                    string sSQL = dal.Add(model);
                    aList.Add(sSQL);

                    sSQL = @"
if exists (select * from @u8.InvPositionSum where  cInvCode = 'aaaaaaaaaa' and cWhCode = 'cccccccccc' and cPosCode = 'bbbbbbbbbb')
    update @u8.InvPositionSum set iQuantity = isnull(iQuantity,0) - dddddddddd,iNum = isnull(iNum,0) - eeeeeeeeee where cInvCode = 'aaaaaaaaaa' and cWhCode = 'cccccccccc' and cPosCode = 'bbbbbbbbbb'
else
    insert into @u8.InvPositionSum(cInvCode,cWhCode,cPosCode,iQuantity,iNum)
    values('aaaaaaaaaa','cccccccccc','bbbbbbbbbb',-dddddddddd,-eeeeeeeeee)
";
                    sSQL = sSQL.Replace("aaaaaaaaaa", model.cInvCode);
                    sSQL = sSQL.Replace("bbbbbbbbbb", model.cPosCode);
                    sSQL = sSQL.Replace("cccccccccc", model.cWhCode);
                    sSQL = sSQL.Replace("dddddddddd", model.iQuantity.ToString());

                    if (model.iNum == 0)
                    {
                        sSQL = sSQL.Replace("eeeeeeeeee", "Null");
                    }
                    else
                    {
                        sSQL = sSQL.Replace("eeeeeeeeee", model.iNum.ToString());
                    }
                    aList.Add(sSQL);
                }

                if (aList.Count > 0)
                {
                    clsSQLCommond.ExecSqlTran(aList);

                    dtTable.Clear();
                    txt货位.Text = "";
                    txt条数.Text = "";
                    txt条形码.Text = "";
                    txt条数.Focus();
                    msgBox.textBox1.Text = "保存出库单货位信息成功";
                    msgBox.ShowDialog();
                }
            }
            catch (Exception ee)
            {
                msgBox.textBox1.Text = "保存失败:\r\n" + ee.Message;
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

                //if (iCol == 1 || iCol == 2 || iCol == 3)
                //{
                //    cellPos = dataGrid1.GetCellBounds(iRow, iCol);
                //    txt编辑.Left = cellPos.Left;
                //    txt编辑.Top = cellPos.Top + dataGrid1.Top;
                //    txt编辑.Width = cellPos.Width;
                //    txt编辑.Height = cellPos.Height;
                //    txt编辑.Visible = true;
                //    txt编辑.Text = dtTable.Rows[editCell.RowNumber][editCell.ColumnNumber].ToString().Trim();
                //    txt编辑.Focus();
                //}
                //else
                //{
                //    txt编辑.Text = "";
                //    txt编辑.Visible = false;
                //    iRow = -1;
                //    iCol = -1; 
                //}
                if (iCol == 1 || iCol == 2)
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
                else if (iCol == 3)
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
                MessageBox.Show("货物错误:" + ee.Message);
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

                if (iCol == 1)
                {
                    //判断货位
                    dtTable.Rows[iRow][iCol] = txt编辑.Text.Trim();
                }
                if (iCol == 2)
                {
                    decimal d数量 = MobileBaseDLL.ClsBaseDataInfo.ReturnDecimal(txt编辑.Text);
                    decimal d本次出库数量 = MobileBaseDLL.ClsBaseDataInfo.ReturnDecimal(dtTable.Rows[iRow]["本次出库数量"]);
                    decimal d单据数量 = MobileBaseDLL.ClsBaseDataInfo.ReturnDecimal(dtTable.Rows[iRow]["数量"]);
                    decimal d单据件数 = MobileBaseDLL.ClsBaseDataInfo.ReturnDecimal(dtTable.Rows[iRow]["件数"]);
                    if (d数量 != d单据数量)
                    {
                        if (d数量 <= 0)
                        {
                            MessageBox.Show("待指定数量必须大于0");
                            return;
                        }

                        if (d单据件数 > 0 || d数量 > 0)
                        {
                            if (radio数量.Checked)
                            {
                                decimal d件数 = MobileBaseDLL.ClsBaseDataInfo.ReturnDecimal(d单据件数 * d本次出库数量 / d单据数量);
                                dtTable.Rows[iRow]["本次出库件数"] = d件数;
                            }
                        }
                    }
                    dtTable.Rows[iRow][iCol] = txt编辑.Text.Trim();
                }

                if (iCol == 3)
                {
                    decimal d件数 = MobileBaseDLL.ClsBaseDataInfo.ReturnDecimal(txt编辑.Text);
                    decimal d本次出库件数 = MobileBaseDLL.ClsBaseDataInfo.ReturnDecimal(dtTable.Rows[iRow]["本次出库件数"]);
                    decimal d单据数量 = MobileBaseDLL.ClsBaseDataInfo.ReturnDecimal(dtTable.Rows[iRow]["数量"]);
                    decimal d单据件数 = MobileBaseDLL.ClsBaseDataInfo.ReturnDecimal(dtTable.Rows[iRow]["件数"]);

                    if (d件数 != d本次出库件数)
                    {
                        if (d件数 < 0)
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
                                MessageBox.Show("本次出库件数必须大于0");
                                return;
                            }
                            if (radio件数.Checked)
                            {
                                decimal d数量 = MobileBaseDLL.ClsBaseDataInfo.ReturnDecimal(d单据件数 * d本次出库件数 / d单据数量);
                                dtTable.Rows[iRow]["本次出库数量"] = d数量;
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