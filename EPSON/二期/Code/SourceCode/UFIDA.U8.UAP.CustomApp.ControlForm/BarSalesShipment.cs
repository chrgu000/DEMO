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
    public partial class BarSalesShipment : UserControl
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

        string sSQLBar = @"
SELECT  
    row_number() over (order by a.iID) as rowid
    ,CAST(1 AS BIT) AS CHOOSE,CAST(NULL AS VARCHAR(50)) AS sErr
	,a.BarCode AS LotNO,c.cSOCode ,b.iRowNo AS SaleOrderRow,b.iSOsID
	,b.cInvCode AS ItemNO,d.cInvName AS [Description],c.cCusCode
	,CAST(b.iQuantity AS DECIMAL(16,2)) AS OrderQTY
	,a.LOTQTY,c.cDepCode AS DEPT
	,a.Process
	,f.RoutingTo AS ProcessNext
    ,CAST(b.iQuantity AS DECIMAL(16,2)) as OtherQTY
	,a.[Status]
    ,c.cSTCode
	,g.CurrQTY
    ,cast(null as varchar(50)) as [CartonNo]
FROM [dbo].[_BarCodeLabel] a 
	INNER JOIN dbo.SO_SODetails b ON a.iSOsID = b.iSOsID
	INNER JOIN dbo.SO_SOMain c ON b.ID = c.ID
	INNER JOIN inventory d ON b.cInvCode = d.cInvCode
	LEFT JOIN dbo.[_SystemSet] e ON e.cSTCode = c.cSTCode
	LEFT JOIN _RoutingInfo f ON f.RoutingForm = CASE WHEN a.[Status] = '新增' or a.[Status] = '新增-客供条码' THEN e.cWhCode ELSE a.[Status] END
    left join (SELECT cWhCode, cInvCode,cBatch,SUM(iQuantity) AS CurrQTY FROM dbo.CurrentStock  GROUP BY cInvCode,cBatch,cWhCode) g 
		on a.cInvCode = g.cInvCode AND a.Batch = g.cBatch AND a.Process = g.cWhCode
WHERE 1=-1
	and isnull(a.[status],'') <> '发货' and isnull(a.[status],'') <> 'Pending'
order by iSOsID desc
";

        private void Frm_Load(object sender, EventArgs e)
        {
            try
            {
                labelErr.Text = "　　　　";

                DbHelperSQL.connectionString = Conn;

                SetLookUp();

                DataTable dtGrid = DbHelperSQL.Query(sSQLBar);
                gridControl1.DataSource = dtGrid;
            }
            catch (Exception ee)
            {
                FrmMsgBox f = new FrmMsgBox();
                f.Text = "加载窗体失败";
                f.richTextBox1.Text = ee.Message;
                f.ShowDialog();
            }
        }

        private void SetLookUp()
        {
            string sSQL = "select cWhCode ,cWhName from WareHouse WHERE cwhmemo like '%F%' or cwhmemo like '%R%' order by cWhCode";
            DataTable dt = DbHelperSQL.Query(sSQL);
            lookUpEditProcess.Properties.DataSource = dt;

            ItemLookUpEditProcess.DataSource = dt;
        }

        public BarSalesShipment()
        {
            InitializeComponent();
        }

        private void GetGrid()
        {
            if (lookUpEditProcess.Text.Trim() == "")
            {
                lookUpEditProcess.Focus();
                throw new Exception("Please choose warehouse");
            }

            string sBarCodeScan = txtBarCode.Text.Trim();
            txtBarCode2.Text = txtBarCode.Text.Trim();

            for (int i = 0; i < gridView1.RowCount; i++)
            {
                string sBarCode = gridView1.GetRowCellValue(i, gridColLotNO).ToString().Trim();
                if (sBarCode == txtBarCode.Text.Trim())
                {
                    labelErr.BackColor = Color.Red;
                    labelErr.Text = "is scanned";
                    txtBarCode.Text = "";
                    return;
                }
            }

            string sSQL = sSQLBar.Replace("1=-1", "1=1 and a.BarCode = '" + sBarCodeScan + "'");

            DataTable dt = DbHelperSQL.Query(sSQL);
            dt.Rows[0]["rowid"] = gridView1.RowCount + 1;

            if (dt == null || dt.Rows.Count == 0)
            {
                labelErr.BackColor = Color.Red;
                labelErr.Text = "not exists";
                txtBarCode.Text = "";
                return;
            }

            if (dt.Rows[0]["status"].ToString().Trim() == "发货" || dt.Rows[0]["status"].ToString().Trim() == "Pending")
            {
                throw new Exception("The barcode is used");
            }

            string sProcess = dt.Rows[0]["Process"].ToString().Trim();

            if (sProcess != lookUpEditProcess.EditValue.ToString().Trim())
            {
                labelErr.BackColor = Color.Red;
                labelErr.Text = "Process is err";
                txtBarCode.Text = "";
                return;
            }

            DataTable dtGrid = (DataTable)(gridControl1.DataSource);
            dtGrid.ImportRow(dt.Rows[0]);
            gridControl1.DataSource = dtGrid;
            gridView1.BestFitColumns();
            gridColrowid.SortOrder = DevExpress.Data.ColumnSortOrder.Descending;

            labelErr.BackColor = Color.Green;
            labelErr.Text = "        ";
            txtBarCode.Text = "";
            txtBarCode.Focus();

            if (dtGrid == null || dtGrid.Rows.Count == 0)
            {
                lookUpEditProcess.Enabled = true;
            }
            else
            {
                lookUpEditProcess.Enabled = false;
            }
        }

        private void txtBarCode_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode != Keys.Enter)
                    return;

                if (txtBarCode.Text.Trim() == "")
                {
                    MessageBox.Show("Please scan barcode");
                    return;
                }

                GetGrid();
            }
            catch (Exception ee)
            {
                MessageBox.Show(ee.Message);
            }
        }

        private void btnScan_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtBarCode.Text.Trim() == "")
                {
                    MessageBox.Show("Please scan barcode");
                    return;
                }

                GetGrid();
            }
            catch (Exception ee)
            {
                MessageBox.Show(ee.Message);
            }
        }


        private void SetTxtNull()
        {
            txtBarCode.Text = "";

            lookUpEditProcess.EditValue = null;
            lookUpEditProcess.Enabled = true;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                gridView1.FocusedRowHandle -= 1;
                gridView1.FocusedRowHandle += 1;
            }
            catch { }

            txtBarCode.Focus();
            string sErr = "";

            int iCount = 0;
            try
            {
                if(gridView1.RowCount < 1)
                {
                    throw new Exception("Please scan barcode");
                }

                string sProcess = gridView1.GetRowCellValue(0, gridColProcess).ToString().Trim();

                SqlConnection conn = new SqlConnection(Conn);
                conn.Open();
                SqlTransaction tran = conn.BeginTransaction();
                try
                {
                    string sSQL = "select getdate()";
                    DateTime dNow = BaseFunction.ReturnDate(DbHelperSQL.ExecuteDataset(tran, CommandType.Text, sSQL).Tables[0].Rows[0][0]);
                    DateTime dNowDate = BaseFunction.ReturnDate(dNow.ToString("yyyy-MM-dd"));

                    for (int i = 0; i < gridView1.RowCount; i++)
                    {
                        long lSOsID = BaseFunction.ReturnLong(gridView1.GetRowCellValue(i, gridColiSOsID));
                        sSQL = @"
select * 
from SO_SOMain a inner join SO_SODetails b on a.ID = b.ID
    left join _SystemSet c on a.cSTCode = c.cSTCode
    inner join Inventory d on b.cInvCode = d.cInvCode
    inner join [_BarCodeLabel] e on e.[iSOsID] = b.[iSOsID]
where b.iSOsID = aaaaaa
order by b.autoid
";
                        sSQL = sSQL.Replace("aaaaaa", lSOsID.ToString().Trim());
                        DataTable dtSODetails = DbHelperSQL.ExecuteDataset(tran, CommandType.Text, sSQL).Tables[0];

                        if (dtSODetails == null || dtSODetails.Rows.Count == 0)
                        {
                            throw new Exception("Sale Order not exists err");
                        }

                        //if (gridView1.GetRowCellValue(i, gridColcCusCode).ToString().Trim() != sCusCode)
                        //{
                        //    sErr = sErr + "Row " + (i + 1).ToString() + " customer err\n";
                        //    continue;
                        //}

                        string sBarCode = gridView1.GetRowCellValue(i, gridColLotNO).ToString().Trim();
                        Model._SalesShipment model = new UFIDA.U8.UAP.CustomApp.ControlForm.Model._SalesShipment();
                        model.cCusCode = gridView1.GetRowCellValue(i, gridColcCusCode).ToString().Trim();
                        model.CreateDate = dNow;
                        model.CreateUid = sUserID;
                        model.cSOCode = gridView1.GetRowCellValue(i, gridColcSOCode).ToString();
                        model.cSTCode = gridView1.GetRowCellValue(i, gridColcSTCode).ToString();
                        model.CurrQTY = BaseFunction.ReturnDecimal(gridView1.GetRowCellValue(i, gridColCurrQTY));
                        //model.DEPT
                        model.Description = gridView1.GetRowCellValue(i, gridColDescription).ToString();
                        model.iSOsID = BaseFunction.ReturnLong(gridView1.GetRowCellValue(i, gridColiSOsID));
                        model.ItemNO = gridView1.GetRowCellValue(i, gridColItemNO).ToString();
                        model.LotNO = sBarCode;
                        model.LOTQTY = BaseFunction.ReturnDecimal(gridView1.GetRowCellValue(i, gridColLOTQTY));
                        model.OrderQTY = BaseFunction.ReturnDecimal(gridView1.GetRowCellValue(i, gridColOrderQTY));
                        model.OtherQTY = BaseFunction.ReturnDecimal(gridView1.GetRowCellValue(i, gridColOtherQTY));
                        model.Process = gridView1.GetRowCellValue(i, gridColProcess).ToString();
                        //model.ProcessNext = gridView1.GetRowCellValue(i,gridCol
                        model.SaleOrderRow = BaseFunction.ReturnLong(gridView1.GetRowCellValue(i, gridColSaleOrderRow));
                        //model.Status = "ship"
                        model.CartonNo = gridView1.GetRowCellValue(i, gridColCartonNo).ToString().Trim();

                        DAL._SalesShipment dal = new UFIDA.U8.UAP.CustomApp.ControlForm.DAL._SalesShipment();
                        sSQL = dal.Add(model);
                        iCount = iCount + DbHelperSQL.ExecuteNonQuery(tran, CommandType.Text, sSQL);

                        sSQL = "update _BarCodeLabel set [Status] = 'Pending' where BarCode = 'aaaaaa' and iSOsID = bbbbbb";
                        sSQL = sSQL.Replace("aaaaaa", gridView1.GetRowCellValue(i, gridColLotNO).ToString().Trim());
                        sSQL = sSQL.Replace("bbbbbb", model.iSOsID.ToString());
                        DbHelperSQL.ExecuteNonQuery(tran, CommandType.Text, sSQL);

                        Model.BarStatus modBarStatus = new UFIDA.U8.UAP.CustomApp.ControlForm.Model.BarStatus();
                        modBarStatus.BarCode = gridView1.GetRowCellValue(i, gridColLotNO).ToString().Trim();
                        modBarStatus.iSOsID = lSOsID;
                        modBarStatus.Type = "Pending";
                        modBarStatus.UpdateTime = dNow;
                        modBarStatus.QTY = model.LOTQTY;
                        modBarStatus.CreateUid = sUserID;
                        modBarStatus.CreateDate = dNow;
                        modBarStatus.RoutingFrom = lookUpEditProcess.EditValue.ToString().Trim();
                        modBarStatus.RoutingTo = lookUpEditProcess.EditValue.ToString().Trim();
                        DAL.BarStatus dalBarStatus = new UFIDA.U8.UAP.CustomApp.ControlForm.DAL.BarStatus();
                        sSQL = dalBarStatus.Add(modBarStatus);
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
                        sSQL = string.Format(sSQL, modBarStatus.BarCode, modBarStatus.iSOsID, dNow);
                        DbHelperSQL.ExecuteNonQuery(tran, CommandType.Text, sSQL);

                    }

                    if (sErr.Trim() != "")
                        throw new Exception(sErr);

                    if (iCount > 0)
                    {
                        tran.Commit();

                        SetTxtNull();

                        gridControl1.DataSource = DbHelperSQL.Query(sSQLBar);
                        txtBarCode.Focus();
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


        private void gridView1_CellValueChanged(object sender, DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs e)
        {
            try
            {
                int iRow = e.RowHandle;
                decimal dLotQTY = BaseFunction.ReturnDecimal(gridView1.GetRowCellValue(iRow, gridColLOTQTY));
                decimal dOtherQTY = BaseFunction.ReturnDecimal(gridView1.GetRowCellValue(iRow, gridColOtherQTY));

                if (dOtherQTY < 0)
                {
                    MessageBox.Show("OtherQTY is err");
                    gridView1.SetRowCellValue(iRow, gridColOtherQTY, DBNull.Value);
                    gridView1.FocusedRowHandle = iRow;
                    gridView1.FocusedColumn = gridColOtherQTY;
                }
            }
            catch (Exception ee)
            { }
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

        private void btnDelRow_Click(object sender, EventArgs e)
        {
            try
            {
                int iRow = gridView1.FocusedRowHandle;
                string sBarCode = gridView1.GetRowCellValue(iRow, gridColLotNO).ToString().Trim();

                gridView1.DeleteRow(iRow);
            }
            catch { }
        }
    }
}
