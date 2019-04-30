using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Collections;
using FrameBaseFunction;

namespace Purchase
{
    public partial class Frm订单评审_采购 : FrameBaseFunction.Frm列表窗体模板
    {

        DataTable dtTable;
        DataTable dtSel = new DataTable();
        int iPage = 0;
        ArrayList aList;
        string sSQL;

        public Frm订单评审_采购()
        {
            InitializeComponent();
        }

        protected override void BtnClick(string sBtnName, string sBtnText)
        {
            try
            {
                switch (sBtnName.ToLower())
                {
                    case "alter":
                        btnAlter();
                        break;
                    case "edit":
                        btnEdit();
                        break;
                    case "export":
                        btnExport();
                        break;
                    case "first":
                        btnFirst();
                        break;
                    case "last":
                        btnLast();
                        break;
                    case "next":
                        btnNext();
                        break;
                    case "prev":
                        btnPrev();
                        break;
                    case "refresh":
                        btnRefresh();
                        break;
                    case "save":
                        btnSave();
                        break;
                    case "sel":
                        btnSel();
                        break;
                    default:
                        break;
                }

                sState = sBtnName.ToLower();
            }
            catch (Exception ee)
            {
                throw new Exception(sBtnText + " 失败! \n\n原因:\n  " + ee.Message);
            }
        }

        DataTable dt评审 = new DataTable();

        #region 按钮模板

      
        /// <summary>
        /// 输出
        /// </summary>
        private void btnExport()
        {
            try
            {
                SaveFileDialog sF = new SaveFileDialog();
                sF.DefaultExt = "xls";
                sF.FileName = this.Text;
                sF.Filter = "Excel文件(*.xls)|*.xls|所有文件(*.*)|*.*";
                DialogResult dRes = sF.ShowDialog();
                if (DialogResult.OK == dRes)
                {
                    gridView评审.ExportToXls(sF.FileName);
                    MessageBox.Show("导出Excel成功\n\t路径：" + sF.FileName);
                }
            }
            catch (Exception ee)
            {
                MessageBox.Show(ee.Message);
            }
        }

      
        #endregion

   
        /// <summary>
        /// 刷新
        /// </summary>
        private void btnRefresh()
        {
            if (txt销售订单ID.Text.Trim() != "")
                GetGrid(Convert.ToInt64(txt销售订单ID.Text));
        }

        private string sFrmSEL = "";

        /// <summary>
        /// 查询
        /// </summary>
        private void btnSel()
        {
            Frm订单评审_SEL fSel = new Frm订单评审_SEL(1);
            fSel.ShowDialog();
            if (fSel.DialogResult != DialogResult.OK)
            {
                throw new Exception("取消查询");
            }
            GetGrid(fSel.i销售订单ID);
        }

        /// <summary>
        /// 首页
        /// </summary>
        private void btnFirst()
        {
            try
            {
                if (dtSel == null || dtSel.Rows.Count < 1)
                {
                    throw new Exception("没有可以查看的单据");
                }

                iPage = 0;
                long i = Convert.ToInt64(dtSel.Rows[iPage]["销售订单ID"]);
                GetGrid(i);
                lPageInfo.Text = (iPage + 1).ToString() + "/" + dtSel.Rows.Count.ToString();
            }
            catch { }
        }
        /// <summary>
        /// 上页
        /// </summary>
        private void btnPrev()
        {
            try
            {
                if (dtSel == null || dtSel.Rows.Count < 1)
                {
                    throw new Exception("没有可以查看的单据");
                }

                if (iPage > 0)
                {
                    iPage -= 1;
                    long i = Convert.ToInt64(dtSel.Rows[iPage]["销售订单ID"]);
                    GetGrid(i);
                    lPageInfo.Text = (iPage + 1).ToString() + "/" + dtSel.Rows.Count.ToString();
                }
            }
            catch { }

        }
        /// <summary>
        /// 下页
        /// </summary>
        private void btnNext()
        {
            try
            {
                if (dtSel == null || dtSel.Rows.Count < 1)
                {
                    throw new Exception("没有可以查看的单据");
                }

                if (iPage < dtSel.Rows.Count - 1)
                {
                    iPage += 1;
                    long i = Convert.ToInt64(dtSel.Rows[iPage]["销售订单ID"]);
                    GetGrid(i);

                    lPageInfo.Text = (iPage + 1).ToString() + "/" + dtSel.Rows.Count.ToString();
                }
            }
            catch { }
        }

        /// <summary>
        /// 末页
        /// </summary>
        private void btnLast()
        {
            try
            {
                if (dtSel == null || dtSel.Rows.Count < 1)
                {
                    throw new Exception("没有可以查看的单据");
                }

                iPage = dtSel.Rows.Count - 1;

                long i = Convert.ToInt64(dtSel.Rows[iPage]["销售订单ID"]);
                GetGrid(i);
                lPageInfo.Text = (iPage + 1).ToString() + "/" + dtSel.Rows.Count.ToString();
            }
            catch { }
        }
       
        /// <summary>
        /// 修改
        /// </summary>
        private void btnEdit()
        {
            if (txt销售订单号.Text.Trim() == "")
            {
                throw new Exception("请选择需要修改的单据");
            }

            dt评审 = (DataTable)gridControl评审.DataSource;

            sState = "edit";
            SetColEdit(true);
        }


        /// <summary>
        /// 保存
        /// </summary>
        private void btnSave()
        {
            try
            {
                gridView评审.FocusedRowHandle -= 1;
                gridView评审.FocusedRowHandle += 1;

                gridView评审.FocusedRowHandle -= 1;
                gridView评审.FocusedRowHandle += 1;
                aList = new System.Collections.ArrayList();
                string sErr = "";

                for (int i = 0; i < gridView评审.RowCount; i++)
                {

                    if (gridView评审.GetRowCellValue(i, gridCol选择1).ToString().Trim() == "√")
                    {
                        if (gridView评审.GetRowCellValue(i, gridCol锁定人1).ToString().Trim() != "")
                        {
                            sErr = sErr + "行" + (i + 1) + "已经锁定不能评审\n";
                            continue;
                        }
                        if (gridView评审.GetRowCellValue(i, gridCol回签完工日期1).ToString().Trim() != "")
                        {
                            DateTime d1 = Convert.ToDateTime(gridView评审.GetRowCellValue(i, gridCol回签完工日期1));
                            DateTime d2 = DateTime.Today;
                            if (d1 < d2)
                            {
                                sErr = sErr + "行" + (i + 1) + "回签日期不能早于当天\n";
                                continue;
                            }
                        }

                        gridView评审.SetRowCellValue(i, gridCol回签人1, FrameBaseFunction.ClsBaseDataInfo.sUserName);
                        gridView评审.SetRowCellValue(i, gridCol回签日期1, DateTime.Now);

                        sSQL = "update XWSystemDB_DL..订单评审运算3 set 回签日期2 = '" + gridView评审.GetRowCellValue(i, gridCol回签完工日期1).ToString().Trim() + "',回签人 = '" + gridView评审.GetRowCellValue(i, gridCol回签人1).ToString().Trim() + "',回签日期 = '" + gridView评审.GetRowCellValue(i, gridCol回签日期1).ToString().Trim() + "' where iID = " + gridView评审.GetRowCellValue(i, gridColiID1).ToString().Trim();
                        aList.Add(sSQL);
                    }
                }

                if (sErr.Trim() != "")
                {
                    throw new Exception(sErr);
                }

                if (aList.Count > 0)
                {
                    clsSQLCommond.ExecSqlTran(aList);

                    GetSelList();
                    iPage = dtSel.Rows.Count - 1;
                    lPageInfo.Text = (iPage + 1).ToString() + "/" + dtSel.Rows.Count.ToString();

                    MessageBox.Show("保存成功！");

                    SetColEdit(false);
                    sState = "save";
                }

                SetColEdit(false);

                GetSelList();
            }
            catch (Exception ee)
            {
                MsgBox("保存失败", ee.Message);
            }


        }

        

        /// <summary>
        /// 发送邮件
        /// </summary>
        private void btnAlter()
        {
            string s = "";
            switch (FrameBaseFunction.ClsBaseDataInfo.sUid)
            {
                case "012":
                    s = " and (iID = 1 or iID = 3)";
                    break;
                case "014":
                    s = " and (iID = 1 or iID = 3)";
                    break;
                case "018":
                    s = " and (iID = 2 or iID = 3)";
                    break;
                case "027":
                    s = " and (iID = 2 or iID = 3)";
                    break;
            }

            string sSQL = "select * from XWSystemDB_DL.dbo._LookUpDate where iType = 7  " + s;
            DataTable dt = clsSQLCommond.ExecQuery(sSQL);

            string sMail = "";

            for (int i = 0; i < dt.Rows.Count; i++)
            {
                if (sMail == "")
                    sMail = dt.Rows[i]["iText"].ToString().Trim();
                else
                {
                    sMail = sMail + ";" + dt.Rows[i]["iText"].ToString().Trim();
                }
            }
            string sHead = "订单评审采购确认：" + txt外销订单号.Text.Trim();
            string sText = "外销订单" + txt外销订单号.Text.Trim() + "已经采购确认。";
            //Purchase.FrmSendMail fSendMail = new FrmSendMail(sMail, sHead, sText);
            //fSendMail.ShowDialog();
            //fSendMail.btnSend_Click(null, null);
        }

        private void Frm订单评审_采购_Load(object sender, EventArgs e)
        {
            try
            {

                lookUpEdit部门.Properties.ReadOnly = false;
                lookUpEdit部门.Enabled = true;

                GetLookUp();

                GetSelList();

                btnLast();
            }
            catch (Exception ee)
            {
                MessageBox.Show("加载窗体失败\n" + ee.Message);
            }
        }

        private void gridView评审_CustomDrawRowIndicator(object sender, DevExpress.XtraGrid.Views.Grid.RowIndicatorCustomDrawEventArgs e)
        {
            e.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            if (e.Info.IsRowIndicator)
            {
                if (e.RowHandle >= 0)
                {
                    e.Info.DisplayText = (e.RowHandle + 1).ToString();
                }
                else if (e.RowHandle < 0 && e.RowHandle > -1000)
                {
                    e.Info.Appearance.BackColor = System.Drawing.Color.AntiqueWhite;
                    e.Info.DisplayText = "G" + e.RowHandle.ToString();
                }
            }
        }
        private void GetLookUp()
        {
            string sSQL = "select cInvCode,cInvName,cInvStd from @u8.Inventory order by cInvCode";
            DataTable dt = clsSQLCommond.ExecQuery(sSQL);
            DataRow drInv = dt.NewRow();
            drInv["cInvCode"] = "--";
            dt.Rows.Add(drInv);
            ItemLookUpEdit1物料编码.DataSource = dt;
            ItemLookUpEdit1物料名称.DataSource = dt;
            ItemLookUpEdit1物料规格.DataSource = dt;

            sSQL = "select cCusCode,cCusName,cCusAbbName from @u8.Customer order by cCusCode";
            dt = clsSQLCommond.ExecQuery(sSQL);
            lookUpEdit客户.Properties.DataSource = dt;

            DataColumn dc = new DataColumn();
            dc.ColumnName = "iID";
            dt.Columns.Add(dc);
            DataRow dr = dt.NewRow();
            dr["iID"] = "采购";
            dt.Rows.Add(dr);
            dr = dt.NewRow();
            dr["iID"] = "委外";
            dt.Rows.Add(dr);
            dr = dt.NewRow();
            dr["iID"] = "自制";
            dt.Rows.Add(dr);
            ItemLookUpEdit1子件属性.DataSource = dt;

            sSQL = "select cDepCode,cDepName from @u8.Department order by cDepCode";
            dt = clsSQLCommond.ExecQuery(sSQL);
            ItemLookUpEdit1部门编码.DataSource = dt;
            ItemLookUpEdit1部门名称.DataSource = dt;

            sSQL = "select cWhCode,cWhName from @u8.Warehouse  order by cWhCode";
            dt = clsSQLCommond.ExecQuery(sSQL);
            ItemLookUpEdit1仓库编码.DataSource = dt;
            ItemLookUpEdit1仓库名称.DataSource = dt;

            sSQL = "select cDepCode,cDepName from @u8.Department where cDepCode in ('1','4','905') order by cDepCode ";
            dt = clsSQLCommond.ExecQuery(sSQL);
            DataRow dr2 = dt.NewRow();
            dt.Rows.InsertAt(dr2, 0);

            lookUpEdit部门.Properties.DataSource = dt;

            sSQL = "select cVenCode,cVenName from @u8.Vendor  order by cVenCode";
            dt = clsSQLCommond.ExecQuery(sSQL);
            ItemLookUpEdit供应商.DataSource = dt;
        }

        private void gridView评审_RowCellStyle(object sender, DevExpress.XtraGrid.Views.Grid.RowCellStyleEventArgs e)
        {
            try
            {
                int i1 = ReturnObjectToInt(gridView评审.GetRowCellValue(e.RowHandle, gridCol销售订单行号1));
                int i2 = i1 % 2;

                if (i2 == 0)
                {
                    e.Appearance.BackColor = Color.AliceBlue;
                }
                else
                {
                    e.Appearance.BackColor = Color.AntiqueWhite;
                }
            }
            catch
            { }
        }

        private void SetColEdit(bool b)
        {
            gridCol回签开始日期1.OptionsColumn.AllowEdit = b;
            gridCol回签完工日期1.OptionsColumn.AllowEdit = b;
            chk全选.Enabled = true;
            chk全选.Checked = false;

            //for (int i = 0; i < base.toolStrip1.Items.Count; i++)
            //{
            //    if (base.toolStrip1.Items[i].Name.ToLower().Trim() == "edit")
            //    {
            //        base.toolStrip1.Items[i].Enabled = !b;
            //    }
            //    if (base.toolStrip1.Items[i].Name.ToLower().Trim() == "save")
            //    {
            //        base.toolStrip1.Items[i].Enabled = b;
            //    }
            //}
        }

        private void GetGrid(long i销售订单ID)
        {
            string sSQL = "select * from XWSystemDB_DL.dbo.订单评审运算1 where 销售订单ID = " + i销售订单ID + " and 帐套号 = " + (FrameBaseFunction.ClsBaseDataInfo.sUFDataBaseName.Substring(7, 3)).Trim();
            DataTable dt订单评审运算1 = clsSQLCommond.ExecQuery(sSQL);

            sSQL = "select * from XWSystemDB_DL.dbo.订单评审运算2 where 销售订单ID = " + i销售订单ID + " and 帐套号 = " + (FrameBaseFunction.ClsBaseDataInfo.sUFDataBaseName.Substring(7, 3)).Trim() + " order by iID";
            DataTable dt订单评审运算2 = clsSQLCommond.ExecQuery(sSQL);

            sSQL = @"
select cast(null as varchar(2)) as 选择,*,cast(null as varchar(50)) as 供应商编码,cast(null as decimal(18,6)) as 含税单价,cast(null as decimal(18,6)) as 含税金额,cast(null as varchar(50)) as 采购部门编码,cast(null as decimal(18,6)) as 仓库现存量,cast(null as decimal(18,6)) as 待入库,cast(null as decimal(18,6)) as 下单量,cast(null as decimal(18,6)) as 累计下单量,cast(null as decimal(18,6)) as 累计待入库,cast(null as decimal(18,6)) as 最小批量 
from XWSystemDB_DL.dbo.订单评审运算3 where isnull(本次下单数量,0) <> 0 and 子件属性 = '采购' and 销售订单ID = aaaaaaaaaa and 帐套号 = 200
order by 子件编码,iID
";
            sSQL = sSQL.Replace("aaaaaaaaaa", i销售订单ID.ToString());
            DataTable dt订单评审运算3 = clsSQLCommond.ExecQuery(sSQL);

            if (dt订单评审运算1 != null && dt订单评审运算1.Rows.Count > 0 && dt订单评审运算2 != null && dt订单评审运算2.Rows.Count > 0 && dt订单评审运算3 != null && dt订单评审运算3.Rows.Count > 0)
            {
                for (int i = 0; i < dt订单评审运算3.Rows.Count; i++)
                {
                    string s子件 = dt订单评审运算3.Rows[i]["子件编码"].ToString().Trim();
                    string s销售订单号 = dt订单评审运算1.Rows[0]["销售订单号"].ToString().Trim();
                    sSQL = "select a.cPOID,b.cDefine37,b.iTaxPrice,b.iSum,a.cVenCode,c.cVenDepart " +
                           "from @u8.PO_Pomain a inner join @u8.PO_Podetails b on a.poid = b.poid  left join @u8.Vendor c on a.cVenCode = c.cVenCode " +
                           "where b.cInvCode = '" + s子件 + "' and cItemCode = '" + s销售订单号 + "'  ";
                    DataTable dt采购供应商回签日期 = clsSQLCommond.ExecQuery(sSQL);

                    if (dt采购供应商回签日期 != null && dt采购供应商回签日期.Rows.Count > 0)
                    {
                        DateTime dtm供应商回签日期 = ReturnObjectToDatetime(dt采购供应商回签日期.Rows[0]["cDefine37"]);
                        if(dtm供应商回签日期 > ReturnObjectToDatetime("2015-01-01"))
                        {
                            dt订单评审运算3.Rows[i]["供应商回签日期"] = dtm供应商回签日期.ToString("yyyy/MM/dd");
                        }
                        dt订单评审运算3.Rows[i]["供应商编码"] = dt采购供应商回签日期.Rows[0]["cVenCode"];
                        dt订单评审运算3.Rows[i]["含税单价"] = dt采购供应商回签日期.Rows[0]["iTaxPrice"];
                        dt订单评审运算3.Rows[i]["含税金额"] = dt采购供应商回签日期.Rows[0]["iSum"];
                        dt订单评审运算3.Rows[i]["采购部门编码"] = dt采购供应商回签日期.Rows[0]["cVenDepart"];
                    }
                }

                txt销售订单号.Text = dt订单评审运算1.Rows[0]["销售订单号"].ToString().Trim();
                txt外销订单号.Text = dt订单评审运算1.Rows[0]["外销订单号"].ToString().Trim();
                txt客户订单号.Text = dt订单评审运算1.Rows[0]["客户订单号"].ToString().Trim();
                lookUpEdit客户.EditValue = dt订单评审运算1.Rows[0]["客户编号"];
                txt备注.Text = dt订单评审运算1.Rows[0]["备注"].ToString().Trim();
                txt销售订单ID.Text = dt订单评审运算1.Rows[0]["销售订单ID"].ToString().Trim();
                txt评审备注.Text = dt订单评审运算1.Rows[0]["评审备注"].ToString().Trim();

                DataView dv = dt订单评审运算3.DefaultView;
                if (lookUpEdit部门.Text.Trim() != "")
                {
                    dv.RowFilter = " isnull(采购部门编码,'') = '' or 采购部门编码 = '" + lookUpEdit部门.EditValue.ToString().Trim() + "' ";
                }
                DataTable dtTemp = dv.ToTable();

                gridControl评审.DataSource = dtTemp;

                sSQL = @"
select distinct a.cCode,b.cItemCode,a.cAuditDate,a.cAuditTime,a.cMakeTime,a.ID
from @u8.PU_AppVouch a inner join @u8.PU_AppVouchs b on a.ID = b.ID  
where b.cItemCode = '111111'
order by a.ID
";
                sSQL = sSQL.Replace("111111", txt销售订单号.Text.Trim());
                DataTable dt审核时间 = clsSQLCommond.ExecQuery(sSQL);
                if (dt审核时间 != null && dt审核时间.Rows.Count > 0)
                {
                    txt请购单审核时间.Text = ReturnObjectToDatetime(dt审核时间.Rows[0]["cAuditTime"]).ToString("yyyy-MM-dd HH:mm:ss");
                }
                else
                {
                    txt请购单审核时间.Text = "";
                }
            }
            else
            {
                throw new Exception("获得单据失败");
            }


            SetColEdit(false);

            //if (lookUpEdit部门.Text.Trim() != "")
            //{
            //    gridCol采购部门编码1.FilterInfo = new DevExpress.XtraGrid.Columns.ColumnFilterInfo(" 采购部门编码 = '" + lookUpEdit部门.EditValue.ToString().Trim() + "' or 采购部门编码 = '' or 采购部门编码 is null ");
            //}
        }

        private void chkAll_CheckedChanged(object sender, EventArgs e)
        {
            b双击 = true;

            if (sState != "edit" && chk全选.Checked)
            {
                MessageBox.Show("必须评审状态才可以全选");
                chk全选.Checked = false;
                return;
            }

            try
            {
                if (chk全选.Checked)
                {
                    for (int i = 0; i < gridView评审.RowCount; i++)
                    {

                        //if (gridView评审.GetRowCellValue(i, gridCol回签完工日期1).ToString().Trim() == "")
                        //{
                            if (gridView评审.GetRowCellValue(i, gridCol供应商回签日期1).ToString().Trim() != "")
                            {
                                gridView评审.SetRowCellValue(i, gridCol回签完工日期1, gridView评审.GetRowCellValue(i, gridCol供应商回签日期1));
                            }
                            else
                            {
                                gridView评审.SetRowCellValue(i, gridCol回签完工日期1, gridView评审.GetRowCellValue(i, gridCol完成日期1));
                            }
                        //}

                        if (gridView评审.GetRowCellValue(i, gridCol回签完工日期1).ToString().Trim() != "")
                        {
                            gridView评审.SetRowCellValue(i, gridCol选择1, "√");
                        }
                    }
                }
                else
                {
                    for (int i = 0; i < gridView评审.RowCount; i++)
                    {
                        gridView评审.SetRowCellValue(i, gridCol选择1, "");
                    }
                }
            }
            catch (Exception ee)
            {
                MessageBox.Show(ee.Message);
            }
            b双击 = false;
        }

        bool b双击 = false;

        private void gridView评审_DoubleClick(object sender, EventArgs e)
        {
            try
            {
                if (sState != "edit")
                    return;

                b双击 = true;
                int i = gridView评审.FocusedRowHandle;
                if (gridView评审.GetRowCellValue(i, gridCol选择1).ToString().Trim() == "")
                {
                    if (gridView评审.GetRowCellValue(i, gridCol供应商回签日期1).ToString().Trim() != "")
                    {
                        gridView评审.SetRowCellValue(i, gridCol回签完工日期1, gridView评审.GetRowCellValue(i, gridCol供应商回签日期1));
                    }
                    else
                    {
                        gridView评审.SetRowCellValue(i, gridCol回签完工日期1, gridView评审.GetRowCellValue(i, gridCol完成日期1));
                    }
                    if (gridView评审.GetRowCellValue(i, gridCol回签完工日期1).ToString().Trim() != "")
                    {
                        gridView评审.SetRowCellValue(i, gridCol选择1, "√");
                    }
                }
                else
                {
                    gridView评审.SetRowCellValue(i, gridCol选择1, "");
                }
                if (!b双击)
                {
                    if (gridView评审.GetRowCellValue(i, gridCol选择1).ToString().Trim() == "√")
                    {
                        gridView评审.SetRowCellValue(i, gridCol选择1, "");
                    }
                }
            }
            catch { }
            b双击 = false;
        }

        private void GetSelList()
        {
            string sSQL = "select 销售订单ID from XWSystemDB_DL..订单评审运算1 where 帐套号 = " + (FrameBaseFunction.ClsBaseDataInfo.sUFDataBaseName.Substring(7, 3)).Trim() + " and isnull(审核人,'') <> '' and isnull(关闭人,'') = '' and isnull(下达请购人,'') <> '' order by 销售订单号";
            dtSel = clsSQLCommond.ExecQuery(sSQL);

            if (dtSel != null && dtSel.Rows.Count > 0)
            {
                iPage = dtSel.Rows.Count - 1;
            }
        }

        private void gridView评审_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            if (sState == "edit")
            {
                if (gridView评审.GetRowCellValue(e.FocusedRowHandle, gridCol锁定人1) == null || gridView评审.GetRowCellValue(e.FocusedRowHandle, gridCol锁定人1).ToString().Trim() == "")
                {
                    gridCol回签开始日期1.OptionsColumn.AllowEdit = true;
                    gridCol回签完工日期1.OptionsColumn.AllowEdit = true;
                }
                else
                {
                    gridCol回签开始日期1.OptionsColumn.AllowEdit = false;
                    gridCol回签完工日期1.OptionsColumn.AllowEdit = false;
                }
            }
        }

        private decimal GetQTY(object d)
        {
            try
            {
                return ReturnDecimal(d);
            }
            catch
            {
                return -999999;
            }
        }

        private void lookUpEdit部门_EditValueChanged(object sender, EventArgs e)
        {
            try
            {
                if (txt销售订单ID.Text.Trim() == "")
                    return;

                GetGrid(Convert.ToInt64(txt销售订单ID.Text.Trim()));
            }
            catch (Exception ee)
            {
                MessageBox.Show("筛选失败:" + ee.Message);
            }
        }

        public static decimal ReturnDecimal(object d)
        {
            try
            {
                decimal d1 = Convert.ToDecimal(d);
                return decimal.Round(d1, 6);
            }
            catch
            {
                return 0;
            }
        }

        DateTime ReturnObjectToDatetime(object o)
        {
            DateTime d = Convert.ToDateTime("1900-01-01");
            try
            {
                d = Convert.ToDateTime(o);
            }
            catch { }
            return d;
        }
    }
}