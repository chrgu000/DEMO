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
    public partial class PrintBarLabel : UserControl
    {
        TH.BaseClass.GetBaseData getBaseData = new GetBaseData();

        UFIDA.U8.UAP.CustomApp.ControlForm.RepBaseGrid Rep = new RepBaseGrid();

        public DateTime dSerToday { get; set; }

        public string Conn { get; set; }

        public string sUserID { get; set; }

        public string sUserName { get; set; }

        public string sLogDate { get; set; }

        public string sAccID { get; set; }

        string sProPath = Application.StartupPath;
        string sPrintLayOutMod = Application.StartupPath + "\\UAP\\Runtime\\print\\BarLabel1.dll";
       

        private void Frm_Load(object sender, EventArgs e)
        {
            try
            {
                if (sUserID.ToLower() == "demo")
                {
                    btnPrintSet.Visible = true;
                }
                else
                {
                    btnPrintSet.Visible = false;
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

                dateEdit1.DateTime = DateTime.Today;
                dateEdit2.DateTime = DateTime.Today;

                DbHelperSQL.connectionString = Conn;
                SetLookUp();
             

                btnRePrintLabel.Enabled = false;
                btnPrintLabel.Enabled = true;
                radioUnPrint.Checked = true;
            }
            catch (Exception ee)
            {
                FrmMsgBox f = new FrmMsgBox();
                f.Text = "加载窗体失败";
                f.richTextBox1.Text = ee.Message;
                f.ShowDialog();
            }
        }

        public PrintBarLabel()
        {
            InitializeComponent();
        }

        private void btnExcel_Click(object sender, EventArgs e)
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
                    gridView1.ExportToXls(sF.FileName);
                    MessageBox.Show("OK\n\tPath：" + sF.FileName);
                }
            }
            catch (Exception ee)
            {
                FrmMsgBox f = new FrmMsgBox();
                f.Text = "导出Excel失败";
                f.richTextBox1.Text = ee.Message;
                f.ShowDialog();
            }
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

        private void btnPrint_Click(object sender, EventArgs e)
        {
            string sErr = "";
            int iCount = 0;
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


                    for (int i = dtGrid.Rows.Count -1; i >=0; i--)
                    {
                        if(!BaseFunction.ReturnBool(dtGrid.Rows[i]["choose"]))
                        {
                            dtGrid.Rows.RemoveAt(i);
                        }
                    }

                    sSQL = @"
select  MAX(SUBSTRING(BarCode,9,4))
from _BarCodeLabel 
where SUBSTRING(BarCode,3,6) = 'aaaaaa'
";
                    sSQL = sSQL.Replace("aaaaaa", dNowDate.ToString("yyMMdd"));
                    DataTable dt = DbHelperSQL.ExecuteDataset(tran,CommandType.Text,sSQL).Tables[0];
                    long lBarList = BaseFunction.ReturnLong(dt.Rows[0][0]);

                    for (int i = 0; i < dtGrid.Rows.Count; i++)
                    {

                        long iLotSize = BaseFunction.ReturnLong(dtGrid.Rows[0]["LotSize"]);
                        if (iLotSize <= 0)
                        {
                            sErr = sErr + "Row " + (i + 1).ToString() + " lot qty err\n";
                            continue;
                        }

                        sSQL = "select count(1) from [_BarCodeLabel] where 1=1 and isnull(printCount,0) >0 and [iSOsID] = " + dtGrid.Rows[i]["iSOsID"].ToString().Trim() + " and [RDsID] = '" + dtGrid.Rows[i]["RdsAutoid"].ToString().Trim() + "'";
                        if (dtGrid.Rows[i]["cSTCode"].ToString().ToLower().Trim() == "os")
                        {
                            sSQL = sSQL.Replace("1=1", "1=1 and Batch = '" + dtGrid.Rows[i]["cBatch"].ToString().Trim() + "'");
                        }

                        dt = DbHelperSQL.ExecuteDataset(tran, CommandType.Text, sSQL).Tables[0];
                        if (BaseFunction.ReturnInt(dt.Rows[0][0], -1) != 0)
                        {
                            sErr = sErr + dtGrid.Rows[i]["ORDNO"] + " " + dtGrid.Rows[i]["iRowNo"] + " is printed\n";
                            continue;
                        }

                        long dOrderQTY = BaseFunction.ReturnLong(dtGrid.Rows[i]["ORDQTY"]);
                        long dLOTQTY = BaseFunction.ReturnLong(dtGrid.Rows[i]["LOTQTY"]);
                        if (dtGrid.Rows[i]["LOTNO"].ToString().Trim() != "")
                        {
                            dLOTQTY = 1;
                        }

                        if (dLOTQTY == 1 || dtGrid.Rows[i]["LOTNO"].ToString().Trim() != "")
                        {
                            dLOTQTY = dOrderQTY;
                        }

                        ////OS 业务使用入库单作为 dOrderQTY用于判断打印循环
                        //if (dtGrid.Rows[i]["cSTCode"].ToString().ToLower().Trim() == "os")
                        //{
                        //    dOrderQTY = dLOTQTY;
                        //}
                        while (dOrderQTY > 0)
                        {
                            lBarList += 1;

                            Model._BarCodeLabel model = new UFIDA.U8.UAP.CustomApp.ControlForm.Model._BarCodeLabel();

                            dtGrid.Rows[i]["BarCreateDate"] = "Printed on " + dNow.ToString("yyyy/MM/dd HH:mm:ss");

                            if (dtGrid.Rows[i]["LOTNO"].ToString().Trim() == "")
                            {
                                string sBarList = lBarList.ToString();
                                while (sBarList.Length < 4)
                                {
                                    sBarList = "0" + sBarList;
                                }
                                model.BarCode = dtGrid.Rows[i]["cSTCode"].ToString().Trim() + dNowDate.ToString("yyMMdd") + sBarList;
                            }
                            else
                            {
                                model.BarCode = dtGrid.Rows[i]["LOTNO"].ToString().Trim();
                            }
                            dtGrid.Rows[i]["barcode"] = model.BarCode;
                            model.SaleOrderNo = dtGrid.Rows[i]["ORDNO"].ToString().Trim();

                            model.SaleOrderRowNo = BaseFunction.ReturnLong(dtGrid.Rows[i]["iRowNo"]);
                            model.iSOsID = BaseFunction.ReturnLong(dtGrid.Rows[i]["iSOsID"]);
                            model.cInvCode = dtGrid.Rows[i]["ITEMNO"].ToString().Trim();
                            model.cInvName = dtGrid.Rows[i]["ITEMDESC"].ToString().Trim();
                            model.DEPT = dtGrid.Rows[i]["DEPT"].ToString().Trim();
                            model.CUST = dtGrid.Rows[i]["CUST"].ToString().Trim();
                            model.ORDERNO = dtGrid.Rows[i]["ORDNO"].ToString().Trim();
                            model.CUSTDO = dtGrid.Rows[i]["CUSTDO"].ToString().Trim();
                            model.LOTNO = dtGrid.Rows[i]["LOTNO"].ToString().Trim();
                            model.ORDERQTY = BaseFunction.ReturnLong(dtGrid.Rows[i]["ORDQTY"]);
                            model.CUSTLOT = dtGrid.Rows[i]["CUSTLOT"].ToString().Trim();
                            model.LotSize = BaseFunction.ReturnDecimal(dtGrid.Rows[i]["LotSize"], 2);
                            model.Batch = dtGrid.Rows[i]["cBatch"].ToString().Trim();
                            model.RDsID = BaseFunction.ReturnLong(dtGrid.Rows[i]["RdsAutoid"]);
                            model.RDType = dtGrid.Rows[i]["RDsType"].ToString().Trim();
                            model.Process = dtGrid.Rows[i]["cWhCode"].ToString().Trim();

                            if (dOrderQTY >= dLOTQTY)
                            {
                                model.LOTQTY = dLOTQTY;
                                dOrderQTY = dOrderQTY - dLOTQTY;
                            }
                            else
                            {
                                model.LOTQTY = dOrderQTY;
                                dOrderQTY = 0;
                            }

                            model.LOTQTY2 = model.LOTQTY;
                            model.RECDate = BaseFunction.ReturnDate(dtGrid.Rows[i]["RECDTE"]);
                            model.DueDate = BaseFunction.ReturnDate(dtGrid.Rows[i]["DUEDTE"]);
                            model.Creater = sUserID;
                            model.CreateDate = dNow;
                            model.PrintTime = dNow;
                            model.PrintCount = 1;
                            model.Status = "新增";

                            DAL._BarCodeLabel dal = new UFIDA.U8.UAP.CustomApp.ControlForm.DAL._BarCodeLabel();
                            sSQL = dal.Add(model);
                            iCount += DbHelperSQL.ExecuteNonQuery(tran, CommandType.Text, sSQL);

                            Model.BarStatus models = new UFIDA.U8.UAP.CustomApp.ControlForm.Model.BarStatus();
                            models.BarCode = model.BarCode;
                            models.Type = "新增";
                            models.UpdateTime = dNow;
                            models.QTY = model.LOTQTY;
                            models.CreateDate = dNowDate;
                            models.CreateUid = sUserID;
                            models.iSOsID = model.iSOsID;
                            models.RoutingFrom = "新增";
                            models.RoutingTo = model.Process;

                            DAL.BarStatus dals = new UFIDA.U8.UAP.CustomApp.ControlForm.DAL.BarStatus();
                            sSQL = dals.Add(models);
                            DbHelperSQL.ExecuteNonQuery(tran, CommandType.Text, sSQL);
                        }
                        //}
                        //else
                        //{
                        //    sSQL = "update _BarCodeLabel set Status = '新增', printTime = getdate(), PrintCount = 1, createdate = '" + dNow + "' where BarCode = '" + dtGrid.Rows[i]["LOTNO"].ToString().Trim() + "' and iSOsID = " + dtGrid.Rows[i]["iSOsID"].ToString().Trim();
                        //    iCount += DbHelperSQL.ExecuteNonQuery(tran, CommandType.Text, sSQL);
                        //}
                    }

                    if (sErr.Length > 0)
                    {
                        throw new Exception(sErr);
                    }

                    if (iCount == 0)
                    {
                        throw new Exception("Please choose data\n" + sErr);
                    }

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
where creater = '{0}' and createdate = '{1}'
order by a.barCode
";

                    sSQL = string.Format(sSQL, sUserID, dNow);
                    DataTable dtBarCode = DbHelperSQL.ExecuteDataset(tran, CommandType.Text, sSQL).Tables[0];
                    for (int i = 0; i < dtBarCode.Rows.Count; i++)
                    {
                        dtBarCode.Rows[i]["PrintInfo"] = "Printed on " + BaseFunction.ReturnDate(dtBarCode.Rows[i]["PrintTime"]).ToString("yyyy/MM/dd HH:mm:ss");
                        dtBarCode.Rows[i]["RECDate2"] = BaseFunction.ReturnDate(dtBarCode.Rows[i]["RECDate"]).ToString("yyyy-MM-dd");
                        dtBarCode.Rows[i]["DueDate2"] = BaseFunction.ReturnDate(dtBarCode.Rows[i]["DueDate"]).ToString("yyyy-MM-dd");
                    }

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
                            throw new Exception ("Please choose printer");
                        }
                        Rep.PrinterName = lookUpEditPrinter.Text.Trim();
                        Rep.Print();
                    }
                    if (iCount > 0)
                    {
                        tran.Commit();
                        GetGrid();
                    }
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

        private void btnQuery_Click(object sender, EventArgs e)
        {
            try
            {
                SetLookUp();
                GetGrid();
            }
            catch (Exception ee)
            {
                MessageBox.Show(ee.Message);
            }
        }

        private void GetGrid()
        { 
            //唐总，问题如下：OS业务是根据销售订单生成采购订单及采购入库，在用户在入库单上填写批号，
            //    如入库时总数量1000，因批号不同需分成3行分别填写批号。现在系统能根据销售订单打印三个条码，
            //    但单打印出来的三张条码是相同的号，所以请你修改下，且每个批号的基础上还要判断lotsize
            string sSQL = @"
SELECT distinct
      cast(0 as bit) as choose, A.cSTCode,a.dDate
    ,A.cSOCode AS ORDNO,b.iSOsID,b.iRowNo,c.cInvDepCode AS DEPT,e.cDepName as DEPTName
	,A.cCusCode AS CUST
	,NULL AS vend
	,b.cinvcode AS ITEMNO,b.cInvName AS ITEMDESC
	,case when isnull(b.cDefine25,'') <> '' then b.cDefine25 when isnull(g.cBatch,'') <> '' then g.cBatch else f.cBatch end AS CUSTLOT
    ,case when isnull(f.AutoID,-1) = -1 then g.cDefine25 else bb.cbdefine3 end AS CUSTDO
	,CAST(
           case when isnull(g.iQuantity,0) = 0 then  b.iQuantity 
                else g.iQuantity end
          AS DECIMAL(16,2)) AS ORDQTY
    ,cast(
		   case when isnull(d.LOTQTY,0) <> 0 then d.LOTQTY
				WHEN g.isosid IS NOT NULL and isnull(c.cInvDefine11,0) <> 0 THEN c.cInvDefine11
				WHEN g.isosid IS NOT NULL and isnull(c.cInvDefine11,0) = 0 THEN g.iquantity
				WHEN d.LotQTY is null then c.cInvDefine11 
				else d.LotQTY end
		  
		  as decimal(16,2)) AS LOTQTY
    ,CAST(c.cInvDefine11 AS DECIMAL(16,2)) as LotSize
    ,b.cDefine30 as Status
	,A.dDate AS RECDTE,B.dPreDate AS DUEDTE
	,B.cDefine28 AS LOTNO
    ,d.creater,d.createdate
    ,c.cComUnitCode as cUnitID ,d.PrintCount,d.PrintTime
    ,d.barcode
	,case when isnull(f.AutoID,-1) = -1 then g.autoid else f.autoid end as RdsAutoid
	,case when isnull(f.AutoID,-1) = -1 then 'rdrecord01' else 'rdrecord08' end as RDsType
	,case when isnull(f.AutoID,-1) <> -1 then f.cWhCode when isnull(g.AutoID,-1) <> -1 then g.cWhCode else ss.cWhCode end as cWhCode
	,case when isnull(f.AutoID,-1) = -1 then g.cBatch else f.cBatch end as cBatch
    ,B.cMemo
    ,c.cInvDefine6
FROM dbo.SO_SOMain A INNER JOIN dbo.SO_SODetails B ON A.ID = B.ID 
    left join SO_SODetails_extradefine bb on b.iSOsID = bb.iSOsID
	INNER JOIN inventory c ON b.cInvCode = c.cInvCode
    left join Department e on e.cDepCode = c.cInvDepCode
    left join (select b.isodid,b.autoid,a.cWhCode,b.cBatch from Rdrecord08 a inner join RdRecords08 b on a.id = b.id) f on b.iSOsID  = f.isodid 
	left join (
                    select c.isosid,b.autoid,a.cWhCode,b.cBatch ,b.iQuantity,b.cDefine25
                    from Rdrecord01 a inner join RdRecords01 b on a.id = b.id
                        inner join PO_Podetails c on b.iPOsID = c.ID
                    ) g on b.iSOsID  = g.isosid
	LEFT JOIN [dbo].[_BarCodeLabel] d ON b.iSOsID = d.iSOsID and case when isnull(f.AutoID,0) = 0 then g.AutoID  else f.AutoID end = d.RDsID
    LEFT JOIN (SELECT distinct cSTCode,cWhCode from _SystemSet) ss on ss.cSTCode = a.cSTCode
WHERE 1=1 and isnull(a.iStatus ,0) = 1 and isnull(cCloser ,'') = '' and isnull([Status],'') <> '关闭'
	AND (ISNULL(f.autoid,0) <> 0  OR ISNULL(g.autoid,0) <> 0 )
ORDER BY d.BarCode,a.cSOCode,b.iRowNo
";
            if (lookUpEditSoCode1.Text.Trim() != "")
            {
                sSQL = sSQL.Replace("1=1", "1=1 and a.cSOCode >= '" + lookUpEditSoCode1.Text.Trim() + "'");
            }
            if (lookUpEditSoCode2.Text.Trim() != "")
            {
                sSQL = sSQL.Replace("1=1", "1=1 and a.cSOCode <= '" + lookUpEditSoCode2.Text.Trim() + "'");
            }
            if (dateEdit1.Text.Trim() != "")
            {
                sSQL = sSQL.Replace("1=1", "1=1 and a.dDate >= '" + dateEdit1.DateTime.ToString("yyyy-MM-dd") + "'");
            }
            if (dateEdit2.Text.Trim() != "")
            {
                sSQL = sSQL.Replace("1=1", "1=1 and a.dDate < '" + dateEdit2.DateTime.AddDays(1).ToString("yyyy-MM-dd") + "'");
            }
            if (lookUpEditcCusCode.Text.Trim() != "")
            {
                sSQL = sSQL.Replace("1=1", "1=1 and a.cCusCode = '" + lookUpEditcCusCode.Text.Trim() + "'");
            }
            if (radioPrinted.Checked)
            {
                sSQL = sSQL.Replace("1=1", "1=1 and isnull(PrintCount,0) > 0 ");

            }
            if(radioUnPrint.Checked)
            {
                sSQL = sSQL.Replace("1=1", "1=1 and isnull(PrintCount,0) = 0");
            }

            DataTable dt = DbHelperSQL.Query(sSQL);
            gridControl1.DataSource = dt;

            for (int i = 0; i < gridView1.Columns.Count; i++)
            {
                gridView1.Columns[i].OptionsColumn.AllowEdit = false;
            }
            gridView1.Columns["choose"].OptionsColumn.AllowEdit = true;
            //gridView1.Columns["LOTQTY"].OptionsColumn.AllowEdit = true;

            gridView1.FocusedRowHandle = 0;

            chkAll.Checked = false;

            gridView1.BestFitColumns();
        }

        private void btnAddRow_Click(object sender, EventArgs e)
        {
            gridView1.AddNewRow();
        }

        private void gridView1_CellValueChanged(object sender, DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs e)
        {
            try
            {
                int iRow = e.RowHandle;

             
            }
            catch { }
        }
        
        private void SetLookUp()
        {
            string sSQL = "select cCusCode,cCusName from Customer order by cCusCode";
            DataTable dt = DbHelperSQL.Query(sSQL);
            DataRow dr = dt.NewRow();
            dt.Rows.InsertAt(dr, 0);
            lookUpEditcCusCode.Properties.DataSource = dt;
            lookUpEditcCusName.Properties.DataSource = dt;

            sSQL = "select cSoCode from SO_SOMain order by cSOCode";
            dt = DbHelperSQL.Query(sSQL);
            dr = dt.NewRow();
            dt.Rows.InsertAt(dr, 0);
            lookUpEditSoCode1.Properties.DataSource = dt;
            lookUpEditSoCode2.Properties.DataSource = dt;
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

        private void lookUpEditcCusCode_EditValueChanged(object sender, EventArgs e)
        {
            try
            {
                lookUpEditcCusName.EditValue = lookUpEditcCusCode.EditValue;
            }
            catch { }
        }

        private void lookUpEditcCusName_EditValueChanged(object sender, EventArgs e)
        {
            try
            {
                lookUpEditcCusCode.EditValue = lookUpEditcCusName.EditValue;
            }
            catch { }
        }

        private void radioUnPrint_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                if (radioUnPrint.Checked)
                {
                    btnRePrintLabel.Enabled = false;
                    btnPrintLabel.Enabled = true;
                    radioUnPrint.Checked = true;

                    GetGrid();
                }
            }
            catch { }
        }

        private void radioPrinted_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                if (radioPrinted.Checked)
                {
                    btnRePrintLabel.Enabled = true;
                    btnPrintLabel.Enabled = false;
                    radioPrinted.Checked = true;

                    GetGrid();
                }
            }
            catch { }
        }

        private void btnRePrint_Click(object sender, EventArgs e)
        {
            string sErr = "";
            int iCount = 0;
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
                    
                    dc = new DataColumn();
                    dc.ColumnName = "RECDate2";
                    dtGrid.Columns.Add(dc);

                    dc = new DataColumn();
                    dc.ColumnName = "DueDate2";
                    dtGrid.Columns.Add(dc);

                    dc = new DataColumn();
                    dc.ColumnName = "PrintInfo";
                    dtGrid.Columns.Add(dc);

                    for (int i = dtGrid.Rows.Count - 1; i >= 0; i--)
                    {
                        if (!BaseFunction.ReturnBool(dtGrid.Rows[i]["choose"]))
                        {
                            dtGrid.Rows.RemoveAt(i);
                        }
                    }

                    for (int i = 0; i < dtGrid.Rows.Count; i++)
                    {
                        string sBarCode = dtGrid.Rows[i]["BarCode"].ToString().Trim();

                        sSQL = "select count(1) from [_BarCodeLabel] where [BarCode] = '" + sBarCode + "' and iSOsID = " + dtGrid.Rows[i]["iSOsID"].ToString()  + " and [RDsID] = '" + dtGrid.Rows[i]["RdsAutoid"].ToString().Trim() + "'";;
                        DataTable dt = DbHelperSQL.ExecuteDataset(tran, CommandType.Text, sSQL).Tables[0];
                        if (BaseFunction.ReturnInt(dt.Rows[0][0], -1) == 0)
                        {
                            sErr = sErr + dtGrid.Rows[i]["ORDNO"] + " " + dtGrid.Rows[i]["iRowNo"] + " is not printe\n";
                            continue;
                        }

                        int iPrintCount = BaseFunction.ReturnInt(dtGrid.Rows[i]["PrintCount"]) + 1;
                        long lSOsID = BaseFunction.ReturnLong(dtGrid.Rows[i]["iSOsID"].ToString().Trim());
                        sSQL = "update  [_BarCodeLabel] set PrintTime = '{0}',PrintCount = {1} where BarCode='{2}' and iSOsID = {3}";
                        sSQL = string.Format(sSQL, dNow.ToString("yyyy-MM-dd HH:mm:ss"), iPrintCount, sBarCode, lSOsID);

                        dtGrid.Rows[i]["BarCreateDate"] = "Printed on " + dNow.ToString("yyyy/MM/dd HH:mm:ss");
                        dtGrid.Rows[i]["PrintTime"] = dNow;
                        dtGrid.Rows[i]["PrintCount"] = iPrintCount;
                        dtGrid.Rows[i]["PrintInfo"] = "Printed on " + BaseFunction.ReturnDate(dtGrid.Rows[i]["PrintTime"]).ToString("yyyy/MM/dd HH:mm:ss");
                        dtGrid.Rows[i]["RECDate2"] = BaseFunction.ReturnDate(dtGrid.Rows[i]["RECDTE"]).ToString("yyyy-MM-dd");
                        dtGrid.Rows[i]["DueDate2"] = BaseFunction.ReturnDate(dtGrid.Rows[i]["DUEDTE"]).ToString("yyyy-MM-dd");
                        iCount += DbHelperSQL.ExecuteNonQuery(tran, CommandType.Text, sSQL);
                    }

                    if (iCount == 0)
                    {
                        throw new Exception("Please choose data");
                    }

                    if (sErr.Length > 0)
                    {
                        throw new Exception(sErr);
                    }

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

                    Rep.dsPrint.Tables.Clear();
                    Rep.dsPrint.Tables.Add(dtGrid);
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
                    if (iCount > 0)
                    {
                        tran.Commit();
                        GetGrid();
                    }
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

        private void chkAll_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                for (int i = 0; i < gridView1.RowCount; i++)
                {
                    gridView1.SetRowCellValue(i, gridView1.Columns["choose"], chkAll.Checked);
                }
            }
            catch { }
        }
    }
}
