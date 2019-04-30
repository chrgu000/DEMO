using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;
using TH.BaseClass;
using System.Data.SqlClient;
using DevExpress.XtraReports.UI;

namespace UFIDA.U8.UAP.CustomApp.ControlForm
{
    public partial class BarSplitList_del : UserControl
    {
        TH.BaseClass.GetBaseData getBaseData = new GetBaseData();

        UFIDA.U8.UAP.CustomApp.ControlForm.RepBaseGrid Rep = new RepBaseGrid();


        string sProPath = Application.StartupPath;
        string sPrintLayOutMod = Application.StartupPath + "\\UAP\\Runtime\\print\\BarLabelSplit.dll";


        public DateTime dSerToday { get; set; }

        public string Conn { get; set; }

        public string sUserID { get; set; }

        public string sUserName { get; set; }

        public string sLogDate { get; set; }

        public string sAccID { get; set; }

        string sProcess1 = "";
        string sProcess2 = "";
       

        private void Frm_Load(object sender, EventArgs e)
        {
            try
            {
                if (sUserID.ToLower() == "demo")
                {
                    //btnPrintSet.Visible = true;
                }
                else
                {
                    //btnPrintSet.Visible = false;
                }

                List<String> list = LocalPrinter.GetLocalPrinters(); //获得系统中的打印机列表
                DataTable dt = new DataTable();
                DataColumn dc = new DataColumn();
                dc.ColumnName = "Printer";
                dt.Columns.Add(dc);

                foreach (String s in list)
                {
                    DataRow dr = dt.NewRow();
                    dr["Printer"] = s;
                    dt.Rows.Add(dr);
                }
                lookUpEditPrinter.Properties.DataSource = dt;
                lookUpEditPrinter.EditValue = LocalPrinter.DefaultPrinter();

                DbHelperSQL.connectionString = Conn;

                btnTxtBarCode.Focus();
            }
            catch (Exception ee)
            {
                FrmMsgBox f = new FrmMsgBox();
                f.Text = "加载窗体失败";
                f.richTextBox1.Text = ee.Message;
                f.ShowDialog();
            }
        }

        public BarSplitList_del()
        {
            InitializeComponent();
        }

        private void gridView1_CustomDrawRowIndicator(object sender, DevExpress.XtraGrid.Views.Grid.RowIndicatorCustomDrawEventArgs e)
        {
            try
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
            catch { }
        }

        private void txtBarCode_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode != Keys.Enter)
                    return;

                btnTxtBarCode_ButtonClick(null, null);
            }
            catch (Exception ee)
            {
                MessageBox.Show(ee.Message);
            }
        }

        private void btnTxtBarCode_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            try
            {
                lBarCodeScaned.Text = btnTxtBarCode.Text.Trim();
                if (lBarCodeScaned.Text.Trim() == "")
                {
                    MessageBox.Show("Please scan barcode");
                    return;
                }

                string sSQL = @"
SELECT 
      cast(0 as bit) as choose, d.*
FROM dbo.SO_SOMain A INNER JOIN dbo.SO_SODetails B ON A.ID = B.ID
	INNER JOIN inventory c ON b.cInvCode = c.cInvCode
	inner JOIN [dbo].[_BarCodeLabel] d ON b.iSOsID = d.iSOsID
WHERE 1=1 and isnull([status],'') <> '关闭'
    and d.iSOsID in (select max(iSOsID) from _BarCodeLabel group by barcode)
ORDER BY a.cSOCode, b.AutoID
";
                sSQL = sSQL.Replace("1=1", "1=1 and d.BarCode = '" + lBarCodeScaned.Text.Trim() + "'");

                DataTable dt = DbHelperSQL.Query(sSQL);
                if (dt == null || dt.Rows.Count == 0)
                {
                    btnTxtBarCode.Text = "";
                    btnTxtBarCode.Focus();
                    throw new Exception("Lot no is err\n" + lBarCodeScaned.Text.Trim() + " does not exist");
                }

                string sStatus = BaseFunction.ReturnStatus(dt.Rows[0]["status"].ToString().Trim());
                if (sStatus.ToLower() == "pending")
                {
                    throw new Exception("Lot no is pending err\n" );
                }

                txtSaleOrderNo.Text = dt.Rows[0]["ORDERNO"].ToString().Trim();
                txtRowNo.Text = dt.Rows[0]["SaleorderRowNo"].ToString().Trim();
                txtiSOsID.Text = dt.Rows[0]["iSOsID"].ToString().Trim();
                txtcInvCode.Text = dt.Rows[0]["cInvCode"].ToString().Trim();
                txtcInvName.Text = dt.Rows[0]["cInvName"].ToString().Trim();
                txtDEPT.Text = dt.Rows[0]["DEPT"].ToString().Trim();
                txtCUST.Text = dt.Rows[0]["CUST"].ToString().Trim();
                txtLOTNO.Text = dt.Rows[0]["LOTNO"].ToString().Trim();
                txtOrderQTY.EditValue = BaseFunction.ReturnDecimal(dt.Rows[0]["ORDERQTY"], 2);
                txtLotQTY.EditValue = BaseFunction.ReturnDecimal(dt.Rows[0]["LOTQTY"], 2);
                txtLotSize.EditValue = BaseFunction.ReturnDecimal(dt.Rows[0]["LotSize"], 2);
                txtStatus.Text = sStatus;
                sProcess1 = dt.Rows[0]["Process"].ToString().Trim();

                string[] sBarList = btnTxtBarCode.Text.Trim().Split('-');

                sSQL = @"
select cast(1 as bit) as choose,BarCode,LOTQTY from [_BarCodeLabel] where 1=-1
";
                DataTable dtBarList = DbHelperSQL.Query(sSQL);
                gridControl1.DataSource = dtBarList;

                btnTxtSplitSize.Text = "";
            }
            catch (Exception ee)
            {
                MessageBox.Show(ee.Message);
            }
        }

        private void SetTxtNull()
        {
            btnTxtBarCode.Text = "";

            txtLOTNO.Text = "";
            txtSaleOrderNo.Text = "";
            txtRowNo.Text = "";
            txtiSOsID.Text = "";
            txtcInvCode.Text = "";
            txtcInvName.Text = "";
            txtDEPT.Text = "";
            txtCUST.Text = "";
            txtLOTNO.Text = "";
            txtOrderQTY.Text = "";
            txtLotQTY.Text = "";
            txtLotSize.Text = "";
            txtStatus.Text = "";
            sProcess1 = "";
            sProcess2 = "";
            lBarCodeScaned.Text = "";

            btnTxtBarCode.Focus();
        }

        private void btnPrint_Click(object sender, EventArgs e)
        {
            string sErr = "";
            try
            {
                try
                {
                    gridView1.FocusedRowHandle -= 1;
                    gridView1.FocusedRowHandle += 1;
                }
                catch { }


                SqlConnection conn = new SqlConnection(Conn);
                conn.Open();
                SqlTransaction tran = conn.BeginTransaction();
                try
                {
                    string sSQL = "select getdate()";
                    DateTime dNow = BaseFunction.ReturnDate(DbHelperSQL.ExecuteDataset(tran, CommandType.Text, sSQL).Tables[0].Rows[0][0]);
                    DateTime dNowDate = BaseFunction.ReturnDate(dNow.ToString("yyyy-MM-dd"));

                    DataTable dtGrid = ((DataTable)gridControl1.DataSource).Copy();
                    dtGrid.TableName = "dtGrid";

                    DataColumn dc = new DataColumn();
                    dc.ColumnName = "BarCreateDate";
                    dtGrid.Columns.Add(dc);



                    Rep = new RepBaseGrid();
                    if (File.Exists(sPrintLayOutMod))
                    {
                        Rep.LoadLayout(sPrintLayOutMod);
                    }
                    else
                    {
                        MessageBox.Show("加载报表模板失败，请与管理员联系");
                        return;
                    }

                    for (int i = 0; i < gridView1.RowCount; i++)
                    {
                        if (!BaseFunction.ReturnBool(gridView1.GetRowCellValue(i, gridColchoose)))
                        {
                            continue;
                        }

                        string sBarCode = gridView1.GetRowCellValue(i, gridColLotNO).ToString().Trim();
                        if (sBarCode == "")
                            continue;

                        sSQL = @"
select 
    a.barCode, a.SaleOrderNo, a.SaleOrderRowNo, a.iSOsID, a.cInvCode, a.cInvName, a.cInvStd, Inv.cInvDepCode as DEPT 
    ,b.cDepName as DEPTName, CUST,ORDERNO AS ORDNO, CUSTDO, LOTNO, ORDERQTY, LOTQTY, RECDate, DueDate, Creater, CreateDate 
    ,PrintTime, PrintCount, a.cInvCode AS ITEMNO, a.cInvName AS ITEMDESC 
    ,RECDate,DueDate
    ,cast(null as varchar(50)) as RECDate2,cast(null as varchar(50)) as DueDate2
    ,ORDERQTY as ORDQTY
    ,CUSTLOT
    ,'Printed on ' as PrintInfo
    ,c.cMemo
    ,Inv.cInvDefine6
    ,Inv.cComUnitCode as cUnitID
from _BarCodeLabel a
    inner join Inventory Inv on a.cInvCode = Inv.cInvCode
    left join Department b on Inv.cInvDepCode = b.cDepCode
    left join SO_SODetails c on c.iSOsID = a.iSOsID
where a.BarCode = '{0}' and a.iSOsID = '{1}'
order by a.barCode
";

                        sSQL = string.Format(sSQL, sBarCode, txtiSOsID.Text.Trim());
                        DataTable dtBarCode = DbHelperSQL.ExecuteDataset(tran, CommandType.Text, sSQL).Tables[0];

                        dtBarCode.Rows[0]["PrintInfo"] = "Printed on " + dNow.ToString("yyyy/MM/dd HH:mm:ss");
                        dtBarCode.Rows[0]["RECDate2"] = BaseFunction.ReturnDate(dtBarCode.Rows[0]["RECDate"]).ToString("yyyy-MM-dd");
                        dtBarCode.Rows[0]["DueDate2"] = BaseFunction.ReturnDate(dtBarCode.Rows[0]["DueDate"]).ToString("yyyy-MM-dd");


                        Rep.dsPrint.Tables.Clear();
                        Rep.dsPrint.Tables.Add(dtBarCode.Copy());
                        Rep.dsPrint.Tables[0].TableName = "dtGrid";

                        if (radioPreview.Checked)
                        {
                            Rep.ShowPreview();
                        }
                        if (radioPrint.Checked)
                        {
                            if (lookUpEditPrinter.Text.Trim() == "")
                            {
                                lookUpEditPrinter.Focus();
                                throw new Exception("Please choose printer");
                            }
                            Rep.PrinterName = lookUpEditPrinter.Text.Trim();
                            Rep.Print();
                        }
                    }

                    tran.Commit();
                }
                catch (Exception ee)
                {
                    tran.Rollback();
                    throw new Exception(ee.Message);
                }
            }
            catch (Exception ee)
            {
                MessageBox.Show(ee.Message);
            }
        }

        private void btnPrintSet_Click(object sender, EventArgs e)
        {
            try
            {
                if (!Directory.Exists(sProPath + "\\print"))
                    Directory.CreateDirectory(sProPath + "\\print");

                if (File.Exists(sPrintLayOutMod))
                {
                    Rep.LoadLayout(sPrintLayOutMod);
                }

                Rep.ShowDesignerDialog();

                DialogResult d = MessageBox.Show("是否保存?模板调整将在下次打开窗体时体现\n是：保存打印模板\n", "提示", MessageBoxButtons.YesNo, MessageBoxIcon.Asterisk);
                if (DialogResult.Yes == d)
                {
                    Rep.SaveLayoutToXml(sPrintLayOutMod);
                }
            }
            catch (Exception ee)
            {
                FrmMsgBox f = new FrmMsgBox();
                f.Text = "设置打印模板失败";
                f.richTextBox1.Text = ee.Message;
                f.ShowDialog();
            }
        }

        private void btnTxtSplitSize_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            try
            {
                string sBarCode = lBarCodeScaned.Text.Trim();

                decimal dSplit = BaseFunction.ReturnDecimal(btnTxtSplitSize.Text.Trim());
                if (dSplit <= 0)
                {
                    throw new Exception("Please set split size");
                }

                decimal dLotQty = BaseFunction.ReturnDecimal(txtLotQTY.Text.Trim());
                if (dLotQty <= 0)
                {
                    throw new Exception("Please check barcode");
                }

                SqlConnection conn = new SqlConnection(Conn);
                conn.Open();
                SqlTransaction tran = conn.BeginTransaction();
                try
                {
                    string sSQL = @"
select cast(1 as bit) as choose,BarCode,LOTQTY from [_BarCodeLabel] where 1=-1
";
                    DataTable dtBarList = DbHelperSQL.ExecuteDataset(tran, CommandType.Text, sSQL).Tables[0];

                    sSQL = @"
select max(BarCode) as BarCode 
from [dbo].[_BarCodeLabel] 
where BarCode like '{0}%' 
    and iSOsID in (select max(iSOsID) from _BarCodeLabel group by BarCode)
";
                    sSQL = string.Format(sSQL, sBarCode);
                    DataTable dt = DbHelperSQL.ExecuteDataset(tran, CommandType.Text, sSQL).Tables[0];
                    if (dt == null || dt.Rows.Count == 0)
                    {
                        throw new Exception("Please check barcode");
                    }

                    string sBarCodeNew = sBarCode;
                    string[] s = dt.Rows[0]["BarCode"].ToString().Trim().Split('-');

                    int iMax = 0;
                    if (s.Length > 1)
                    {
                        iMax = BaseFunction.ReturnInt(s[1]);
                    }

                    //if (dLotQty >= dSplit)
                    //{
                    //    DataRow dr = dtBarList.NewRow();
                    //    dr["choose"] = true;
                    //    dr["BarCode"] = sBarCode;
                    //    dr["LOTQTY"] = dSplit;
                    //    dtBarList.Rows.Add(dr);

                    //    dLotQty = dLotQty - dSplit;
                    //}
                    //else
                    //{
                    //    DataRow dr = dtBarList.NewRow();
                    //    dr["choose"] = true;
                    //    dr["BarCode"] = sBarCode;
                    //    dr["LOTQTY"] = dLotQty;
                    //    dtBarList.Rows.Add(dr);
                    //    dLotQty = 0; 
                    //}

                    while (dLotQty > 0)
                    {
                        if (dLotQty >= dSplit)
                        {
                            iMax += 1;
                            DataRow dr = dtBarList.NewRow();
                            dr["choose"] = true;
                            dr["BarCode"] = sBarCode + "-" + iMax.ToString().PadLeft(4, '0');
                            dr["LOTQTY"] = dSplit;
                            dtBarList.Rows.Add(dr);

                            dLotQty = dLotQty - dSplit;
                        }
                        else
                        {
                            iMax += 1;
                            DataRow dr = dtBarList.NewRow();
                            dr["choose"] = true;
                            dr["BarCode"] = sBarCode + "-" + iMax.ToString().PadLeft(4, '0');
                            dr["LOTQTY"] = dLotQty;
                            dtBarList.Rows.Add(dr);
                            dLotQty = 0; 
                        }
                    }

                    gridControl1.DataSource = dtBarList;

                    tran.Commit();
                }
                catch (Exception ee)
                {
                    tran.Rollback();
                    throw new Exception(ee.Message);
                }
            }
            catch (Exception ee)
            {
                FrmMsgBox frm = new FrmMsgBox();
                frm.richTextBox1.Text = ee.Message;
                frm.ShowDialog();
            }
        }

        private void chkAll_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                for (int i = 0; i < gridView1.RowCount; i++)
                {
                    gridView1.SetRowCellValue(i, gridColchoose, chkAll.Checked);
                }
            }
            catch { }
        }

        private void btnTxtSplitSize_KeyUp(object sender, KeyEventArgs e)
        {

            try
            {
                if (e.KeyCode == Keys.Enter)
                {
                    btnTxtSplitSize_ButtonClick(null, null);
                }
            }
            catch { }
        }

        private void btnSplit_Click(object sender, EventArgs e)
        {
            try
            {
                try
                {
                    gridView1.FocusedRowHandle -= 1;
                    gridView1.FocusedRowHandle += 1;
                }
                catch { }

                string sBarCode = lBarCodeScaned.Text.Trim();

                SqlConnection conn = new SqlConnection(Conn);
                conn.Open();
                SqlTransaction tran = conn.BeginTransaction();
                try
                {
                    string sSQL = "select getdate()";
                    DateTime dNow = BaseFunction.ReturnDate(DbHelperSQL.ExecuteDataset(tran, CommandType.Text, sSQL).Tables[0].Rows[0][0]);
                    DateTime dNowDate = BaseFunction.ReturnDate(dNow.ToString("yyyy-MM-dd"));

                    sSQL = @"
select * 
from _BarCodeLabel 
where 1=1 
order by BarCode desc
";
                    sSQL = sSQL.Replace("1=1", "1=1 and BarCode = '" + sBarCode + "'");
                    sSQL = sSQL.Replace("1=1", "1=1 and  iSOsID = '" + txtiSOsID.Text.Trim() + "'");

                    DataTable dt = DbHelperSQL.ExecuteDataset(tran, CommandType.Text, sSQL).Tables[0];

                    if (dt == null || dt.Rows.Count == 0)
                    {
                        throw new Exception("Please scan barcode");
                    }

                    if (BaseFunction.ReturnDecimal(txtLotQTY.Text.Trim()) != BaseFunction.ReturnDecimal(dt.Rows[0]["LOTQTY"]))
                    {
                        throw new Exception("Please scan the bar code again");
                    }

                    if(BaseFunction.ReturnDecimal(txtLotQTY.Text.Trim()) != BaseFunction.ReturnDecimal(gridView1.Columns["LOTQTY"].SummaryItem.SummaryValue))
                    {
                        throw new Exception("Qty err");
                    }

                    sSQL = @"
update [_BarCodeLabel] set LOTQTY = 0,[Status] = '调整' where BarCode = '{0}' and iSOsID = '{1}' 
";
                    sSQL = string.Format(sSQL, lBarCodeScaned.Text.Trim(), txtiSOsID.Text.Trim());
                    DbHelperSQL.ExecuteNonQuery(tran,CommandType.Text,sSQL);
                    Model.BarStatus models = new UFIDA.U8.UAP.CustomApp.ControlForm.Model.BarStatus();
                    models.BarCode = lBarCodeScaned.Text.Trim();
                    models.Type = "调整";
                    models.QTY = 0;
                    models.UpdateTime = dNow;
                    models.CreateDate = dNowDate;
                    models.CreateUid = sUserID;
                    models.iSOsID = BaseFunction.ReturnLong(txtiSOsID.Text);
                    models.RoutingFrom = dt.Rows[0]["Process"].ToString().Trim();
                    models.RoutingTo = dt.Rows[0]["Process"].ToString().Trim();
                    DAL.BarStatus dals = new UFIDA.U8.UAP.CustomApp.ControlForm.DAL.BarStatus();
                    sSQL = dals.Add(models);
                    DbHelperSQL.ExecuteNonQuery(tran, CommandType.Text, sSQL);


                    //回写上一道工序的结束时间
                    sSQL = @"
declare @iID int 
select @iID = max(iID)
from _BarStatus
where [BarCode] = '{0}' and iSOsID = '{1}'
    and iID < (
        select max(iID) as maxID
        from _BarStatus
        where [BarCode] = '{0}' and iSOsID = '{1}'
    )

update _BarStatus set EndTime = '{2}' where iID = @iID and [BarCode] = '{0}' and iSOsID = '{1}'
";
                    sSQL = string.Format(sSQL, models.BarCode, models.iSOsID, dNow);
                    DbHelperSQL.ExecuteNonQuery(tran, CommandType.Text, sSQL);

                    for (int i = 0; i < gridView1.RowCount; i++)
                    {
                        string sBarCodeNew = gridView1.GetRowCellValue(i, gridColLotNO).ToString().Trim();
                        decimal dQty = BaseFunction.ReturnDecimal(gridView1.GetRowCellValue(i, gridColLOTQTY));

                        if (sBarCodeNew == "")
                            continue;

                        DAL._BarCodeLabel dal = new UFIDA.U8.UAP.CustomApp.ControlForm.DAL._BarCodeLabel();
                        Model._BarCodeLabel model = new UFIDA.U8.UAP.CustomApp.ControlForm.Model._BarCodeLabel();
                        model = dal.DataRowToModel(dt.Rows[0]);

                        model.oldBarCode = sBarCode;
                        model.BarCode = sBarCodeNew;
                        model.LOTQTY = dQty;
                        model.Status = "调整";

                        if (sBarCode == sBarCodeNew)
                        {
                            sSQL = dal.Update(model, model.BarCode, model.iSOsID);
                            DbHelperSQL.ExecuteNonQuery(tran, CommandType.Text, sSQL);
                        }
                        else
                        {
                            sSQL = dal.Add(model);
                            DbHelperSQL.ExecuteNonQuery(tran, CommandType.Text, sSQL);
                        }

                        models = new UFIDA.U8.UAP.CustomApp.ControlForm.Model.BarStatus();
                        models.BarCode = model.BarCode;
                        models.Type = "调整";
                        models.QTY = dQty;
                        models.UpdateTime = dNow;
                        models.CreateDate = dNowDate;
                        models.CreateUid = sUserID;
                        models.iSOsID = BaseFunction.ReturnLong(txtiSOsID.Text);
                        models.RoutingFrom = model.Process;
                        models.RoutingTo = model.Process;
                        dals = new UFIDA.U8.UAP.CustomApp.ControlForm.DAL.BarStatus();
                        sSQL = dals.Add(models);
                        DbHelperSQL.ExecuteNonQuery(tran, CommandType.Text, sSQL);


                        //回写上一道工序的结束时间
                        sSQL = @"
declare @iID int 
select @iID = max(iID)
from _BarStatus
where [BarCode] = '{0}' and iSOsID = '{1}'
    and iID < (
        select max(iID) as maxID
        from _BarStatus
        where [BarCode] = '{0}' and iSOsID = '{1}'
    )

update _BarStatus set EndTime = '{2}' where iID = @iID and [BarCode] = '{0}' and iSOsID = '{1}'
";
                        sSQL = string.Format(sSQL, models.BarCode, models.iSOsID, dNow);
                        DbHelperSQL.ExecuteNonQuery(tran, CommandType.Text, sSQL);

                        sSQL = @"
update _BarCodeLabel set IQCStatus = 'IQC-Sort'
where BarCode = '{0}' and iSOsID = {1}
";
                        sSQL = string.Format(sSQL, model.BarCode, model.iSOsID);
                        DbHelperSQL.ExecuteNonQuery(tran, CommandType.Text, sSQL);
                    }
                    tran.Commit();

                    MessageBox.Show("Split is ok");
                }
                catch (Exception ee)
                {
                    tran.Rollback();
                    throw new Exception(ee.Message);
                }
            }
            catch (Exception ee)
            {
                FrmMsgBox frm = new FrmMsgBox();
                frm.richTextBox1.Text = ee.Message;
                frm.ShowDialog();
            }
        }
    }
}
