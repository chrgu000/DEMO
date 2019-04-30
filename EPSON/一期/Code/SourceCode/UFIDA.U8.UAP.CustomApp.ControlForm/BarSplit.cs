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
    public partial class BarSplit : UserControl
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

        string sProcess1 = "";
        string sProcess2 = "";
       

        private void Frm_Load(object sender, EventArgs e)
        {
            try
            {
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

        public BarSplit()
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

        private void btnSplit_Click(object sender, EventArgs e)
        {
            btnTxtBarCode.Focus();
            txtSplitQty.Focus();
            string sErr = "";
            int iCount = 0;
            try
            {
                GetBarCodeStatus(btnTxtBarCode.Text.Trim());

                if (BaseFunction.ReturnDecimal(txtSplitQty.Text) <= 0 || BaseFunction.ReturnDecimal(txtSplitQty.Text) > BaseFunction.ReturnDecimal(txtLotQTY.Text))
                {
                    throw new Exception("Split Qty is err");
                }

                string  sBarCodeNew  = "";

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
                    sSQL = sSQL.Replace("1=1", "1=1 and BarCode = '" + btnTxtBarCode.Text.Trim() + "'");
                    sSQL = sSQL.Replace("1=1", "1=1 and  iSOsID = '" + txtiSOsID.Text.Trim() + "'");
                    
                    DataTable dt = DbHelperSQL.ExecuteDataset(tran, CommandType.Text, sSQL).Tables[0];
                     
                    if (dt == null || dt.Rows.Count == 0)
                    {
                        throw new Exception("Please scan barcode");
                    }

                    string sStatus = BaseFunction.ReturnStatus(dt.Rows[0]["status"].ToString().Trim());
                    if (sStatus.ToLower() == "pending")
                    {
                        throw new Exception("Lot no is pending err\n" );
                    }


                    sProcess1 = dt.Rows[0]["Process"].ToString().Trim();

                    sSQL = @"
select *
FROM _BarStatus
where  1=1
order by iID desc
";
                    sSQL = sSQL.Replace("1=1", "1=1 and BarCode like '" + btnTxtBarCode.Text.Trim() + "%'");
                    sSQL = sSQL.Replace("1=1", "1=1 and  iSOsID = '" + txtiSOsID.Text.Trim() + "'");
                    DataTable dtBarStatus = DbHelperSQL.ExecuteDataset(tran, CommandType.Text, sSQL).Tables[0];

                    decimal dLotQtyOld = BaseFunction.ReturnDecimal(dt.Rows[0]["LotQTY"], 2);

                    DAL._BarCodeLabel dal = new UFIDA.U8.UAP.CustomApp.ControlForm.DAL._BarCodeLabel();
                    Model._BarCodeLabel model = new UFIDA.U8.UAP.CustomApp.ControlForm.Model._BarCodeLabel();
                    model = dal.DataRowToModel(dt.Rows[0]);

                    if (btnTxtBarCode2.Text.Trim() == "")
                    {
                        string[] sBarCodeList = btnTxtBarCode.Text.Split('-');

                        sSQL = @"
select BarCode as BarCodeNew 
from _BarCodeLabel 
where 1=1 
order by iID desc
";
                        sSQL = sSQL.Replace("1=1", "1=1 and BarCode like '" + sBarCodeList[0].Trim() + "%'");
                        sSQL = sSQL.Replace("1=1", "1=1 and  iSOsID = '" + txtiSOsID.Text.Trim() + "'");

                        DataTable dtBarCodeNew = DbHelperSQL.ExecuteDataset(tran, CommandType.Text, sSQL).Tables[0];
                        sBarCodeList = dtBarCodeNew.Rows[0]["BarCodeNew"].ToString().Trim().Split('-');
                        sBarCodeNew = sBarCodeList[0].Trim();
                        if (sBarCodeList.Length == 1)
                        {
                            sBarCodeNew = sBarCodeNew + "-0001";
                        }
                        else
                        {
                            int iCou = BaseFunction.ReturnInt(sBarCodeList[1]) + 1;
                            string sCou = iCou.ToString();
                            while (sCou.Length < 4)
                            {
                                sCou = "0" + sCou;
                            }
                            sBarCodeNew = sBarCodeList[0] + "-" + sCou;
                        }

                        model.oldBarCode = btnTxtBarCode.Text.Trim();
                        model.BarCode = sBarCodeNew;
                        model.LOTQTY = BaseFunction.ReturnDecimal(txtSplitQty.Text.Trim());
                      

                        sSQL = dal.Add(model);
                        iCount += DbHelperSQL.ExecuteNonQuery(tran, CommandType.Text, sSQL);

                        Model.BarStatus models = new UFIDA.U8.UAP.CustomApp.ControlForm.Model.BarStatus();
                        models.BarCode = model.oldBarCode;
                        models.Type = "调整";
                        models.QTY = dLotQtyOld - BaseFunction.ReturnDecimal(txtSplitQty.Text.Trim());
                        models.UpdateTime = dNow;
                        models.CreateDate = dNowDate;
                        models.CreateUid = sUserID;
                        models.iSOsID = BaseFunction.ReturnLong(txtiSOsID.Text);
                        models.RoutingFrom = dtBarStatus.Rows[0]["RoutingFrom"].ToString().Trim();
                        models.RoutingTo = dtBarStatus.Rows[0]["RoutingTo"].ToString().Trim();
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


                        models = new UFIDA.U8.UAP.CustomApp.ControlForm.Model.BarStatus();
                        models.BarCode = model.BarCode;
                        models.Type = "调整";
                        models.QTY = model.LOTQTY;
                        models.UpdateTime = dNow;
                        models.CreateDate = dNowDate;
                        models.CreateUid = sUserID;
                        models.iSOsID = BaseFunction.ReturnLong(txtiSOsID.Text);
                        models.RoutingFrom = dtBarStatus.Rows[0]["RoutingFrom"].ToString().Trim();
                        models.RoutingTo = dtBarStatus.Rows[0]["RoutingTo"].ToString().Trim();
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
update _BarCodeLabel set LotQTY = aaaaaa
where BarCode = 'bbbbbb'
"; 
                        sSQL = sSQL.Replace("aaaaaa", (dLotQtyOld - BaseFunction.ReturnDecimal(txtSplitQty.Text.Trim())).ToString());
                        sSQL = sSQL.Replace("bbbbbb", model.oldBarCode);
                        iCount += DbHelperSQL.ExecuteNonQuery(tran, CommandType.Text, sSQL);

                    }
                    else
                    {
                        sSQL = "select * from _BarCodeLabel where BarCode = '" + btnTxtBarCode2.Text.Trim() + "' ";
                        DataTable dtBarCodeTemp = DbHelperSQL.ExecuteDataset(tran, CommandType.Text, sSQL).Tables[0];
                        if (dtBarCodeTemp == null || dtBarCodeTemp.Rows.Count == 0)
                        {
                            btnTxtBarCode2.Text = "";
                            btnTxtBarCode2.Focus();
                            throw new Exception("BarCode is not exists");
                        }

                        sProcess2 = dtBarCodeTemp.Rows[0]["Process"].ToString().Trim();

                        if (sProcess1 != sProcess2)
                        {
                            throw new Exception("Both Lot are not in the same process");
                        }

                        sSQL = "update _BarCodeLabel set LotQTY = LotQTY - " + BaseFunction.ReturnDecimal(txtSplitQty.Text, 2) + " where BarCode = '" + btnTxtBarCode.Text.Trim() + "' and iSOsID = " + txtiSOsID.Text.Trim();
                        iCount += DbHelperSQL.ExecuteNonQuery(tran, CommandType.Text, sSQL);

                        sSQL = "update _BarCodeLabel set LotQTY = LotQTY + " + BaseFunction.ReturnDecimal(txtSplitQty.Text, 2) + " where BarCode = '" + btnTxtBarCode2.Text.Trim() + "' and iSOsID = " + txtiSOsID.Text.Trim();
                        iCount += DbHelperSQL.ExecuteNonQuery(tran, CommandType.Text, sSQL);



                        Model.BarStatus models = new UFIDA.U8.UAP.CustomApp.ControlForm.Model.BarStatus();
                        models.BarCode = btnTxtBarCode.Text.Trim();
                        models.Type = "调整";
                        models.QTY = dLotQtyOld - BaseFunction.ReturnDecimal(txtSplitQty.Text.Trim());
                        models.UpdateTime = dNow;
                        models.CreateDate = dNowDate;
                        models.CreateUid = sUserID;
                        models.iSOsID = BaseFunction.ReturnLong(txtiSOsID.Text);
                        models.RoutingFrom = dtBarStatus.Rows[0]["RoutingFrom"].ToString().Trim();
                        models.RoutingTo = dtBarStatus.Rows[0]["RoutingTo"].ToString().Trim();

                        DAL.BarStatus dals = new UFIDA.U8.UAP.CustomApp.ControlForm.DAL.BarStatus();
                        sSQL = dals.Add(models);
                        DbHelperSQL.ExecuteNonQuery(tran, CommandType.Text, sSQL);

                        models = new UFIDA.U8.UAP.CustomApp.ControlForm.Model.BarStatus();
                        models.BarCode = btnTxtBarCode2.Text.Trim();
                        models.Type = "调整";

                        decimal dQty = BaseFunction.ReturnDecimal(txtLotQTY2.Text) + BaseFunction.ReturnDecimal(txtSplitQty.Text);

                        if ((BaseFunction.ReturnDecimal(txtLotSize.Text) == 1 && dQty > BaseFunction.ReturnDecimal(txtOrderQTY.Text))
                            || (BaseFunction.ReturnDecimal(txtLotSize.Text) > 1 && dQty > BaseFunction.ReturnDecimal(txtLotSize.Text)))
                        {
                            throw new Exception("Qty is err");
                        }
                        models.QTY = dQty;
                        models.UpdateTime = dNow;
                        models.CreateDate = dNowDate;
                        models.CreateUid = sUserID;
                        models.iSOsID = BaseFunction.ReturnLong(txtiSOsID.Text);
                        models.RoutingFrom = dtBarStatus.Rows[0]["RoutingFrom"].ToString().Trim();
                        models.RoutingTo = dtBarStatus.Rows[0]["RoutingTo"].ToString().Trim();

                        dals = new UFIDA.U8.UAP.CustomApp.ControlForm.DAL.BarStatus();
                        sSQL = dals.Add(models);
                        DbHelperSQL.ExecuteNonQuery(tran, CommandType.Text, sSQL);
                    }

                    if (sErr.Length > 0)
                    {
                        throw new Exception(sErr);
                    }

                    if (iCount > 0)
                    {
                        tran.Commit();

                        btnTxtBarCode_ButtonClick(null, null);

                        SetTxtNull();
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
                if (btnTxtBarCode.Text.Trim() == "")
                {
                    MessageBox.Show("Please scan barcode");
                    return;
                }

                GetBarCodeStatus(btnTxtBarCode.Text.Trim());

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
                sSQL = sSQL.Replace("1=1", "1=1 and d.BarCode = '" + btnTxtBarCode.Text.Trim() + "'");

                DataTable dt = DbHelperSQL.Query(sSQL);
                if (dt == null || dt.Rows.Count == 0)
                {
                    btnTxtBarCode.Text = "";
                    btnTxtBarCode.Focus();
                    throw new Exception("Lot no is err\n" + btnTxtBarCode.Text.Trim() + " does not exist");
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



                txtSplitQty.Text = "";

                string[] sBarList = btnTxtBarCode.Text.Trim().Split('-');

                sSQL = @"
SELECT cast(0 as bit) as choose
    ,a.* ,b.iRowNo AS SaleOrderRow,a.BarCode AS LotNO,b.cSOCode,b.iRowNo AS SaleOrderRow
	,a.cInvCode AS ItemNO,a.cInvName AS [DESCRIPTION]
FROM [dbo].[_BarCodeLabel] a
	 INNER JOIN (SELECT iSOsID,a.cSOCode,b.iRowNo FROM dbo.SO_SODetails b INNER JOIN dbo.SO_SOMain a ON a.ID = b.ID WHERE ISNULL(cVerifier,'') <> '' AND ISNULL(cCloser ,'') = '') b ON a.isosid = b.isosid

WHERE a.BarCode LIKE 'aaaaaa%'
";
                sSQL = sSQL.Replace("aaaaaa", sBarList[0]);
                DataTable dtBarList = DbHelperSQL.Query(sSQL);
                gridControl1.DataSource = dtBarList;

                btnTxtBarCode2.Focus();
            }
            catch (Exception ee)
            {
                MessageBox.Show(ee.Message);
            }
        }

        private void btnTxtBarCode2_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            try
            {
                if (btnTxtBarCode2.Text.Trim() == "")
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
ORDER BY a.cSOCode, b.AutoID
";
                sSQL = sSQL.Replace("1=1", "1=1 and d.BarCode = '" + btnTxtBarCode2.Text.Trim() + "'");

                DataTable dt = DbHelperSQL.Query(sSQL);
                if (dt == null || dt.Rows.Count == 0)
                {
                    btnTxtBarCode2.Text = "";
                    txtStatus2.Text = "";
                    txtLotQTY2.Text = "";
                    btnTxtBarCode2.Focus();
                    throw new Exception("LotNO2 is not in the same orderno");
                }

                sProcess2 = dt.Rows[0]["Process"].ToString().Trim();
                if (sProcess1 != sProcess2)
                {
                    throw new Exception("Both Lot are not in the same process");
                }

                string sStatus = dt.Rows[0]["sStatus"].ToString().Trim();
                if (sStatus.ToLower() == "pending")
                {
                    throw new Exception("LotNO2 is pending err\n");
                }

                if(BaseFunction.ReturnLong(dt.Rows[0]["iSOsID"].ToString().Trim()) != BaseFunction.ReturnLong(txtiSOsID.Text.Trim()))
                {
                    btnTxtBarCode2.Text = "";
                    txtStatus2.Text = "";
                    txtLotQTY2.Text = "";
                    throw new Exception("LotNO2 is err");
                }

                txtStatus2.Text = BaseFunction.ReturnStatus(dt.Rows[0]["status"].ToString().Trim());
                if (txtStatus.Text.ToLower().Trim() != txtStatus2.Text.ToLower().Trim())
                {
                    btnTxtBarCode2.Text = "";
                    txtStatus2.Text = "";
                    txtLotQTY2.Text = "";
                    throw new Exception("LotNO2 is not in the same suatus");
                }

                txtLotQTY2.Text = dt.Rows[0]["LotQTY"].ToString().Trim();

             
                txtSplitQty.Focus();
            }
            catch (Exception ee)
            {
                MessageBox.Show(ee.Message);
            }

        }

        private void btnTxtBarCode2_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode != Keys.Enter)
                    return;

                btnTxtBarCode2_ButtonClick(null, null);
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
            txtSplitQty.Text = "";
            btnTxtBarCode2.Text = "";
            txtLotQTY2.Text = "";
            txtLotSize.Text = "";
            txtStatus.Text = "";
            txtStatus2.Text = "";
            sProcess1 = "";
            sProcess2 = "";

            btnTxtBarCode.Focus();
        }

        private void btnPrint_Click(object sender, EventArgs e)
        {
            try
            {
                try
                {
                    gridView1.FocusedRowHandle -= 1;
                    gridView1.FocusedRowHandle += 1;
                }
                catch { }

                GetBarCodeStatus(btnTxtBarCode.Text.Trim());

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

                string sID = "";
                string sSOsID = "";

                for (int i = 0; i < gridView1.RowCount; i++)
                {
                    bool b = BaseFunction.ReturnBool(gridView1.GetRowCellValue(i, gridColchoose));
                    if (!b)
                        continue;

                    if (sID == "")
                    {
                        sID = "'" + gridView1.GetRowCellValue(i, gridColLotNO).ToString().Trim() + "'";
                        sSOsID = gridView1.GetRowCellValue(i, gridColiSOsID).ToString().Trim();
                    }
                    else
                    {
                        sID = sID + ",'" + gridView1.GetRowCellValue(i, gridColLotNO).ToString().Trim() + "'";
                        sSOsID = sSOsID + "," + gridView1.GetRowCellValue(i, gridColiSOsID).ToString().Trim();
                    }
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

                if (sID == "")
                {
                    throw new Exception("Please choose");
                }

                string sSQL = @"
select 
    barCode, SaleOrderNo, SaleOrderRowNo, iSOsID, cInvCode, cInvName, cInvStd, DEPT,b.cDepName as DEPTName, CUST, 
    ORDERNO AS ORDNO, CUSTDO, LOTNO, ORDERQTY, LOTQTY, RECDate, DueDate, Creater, CreateDate, 
    PrintTime, PrintCount, cInvCode AS ITEMNO, cInvName AS ITEMDESC, RECDate AS RECDTE, 
    DueDate AS DUEDTE,ORDERQTY as ORDQTY
    ,CUSTLOT
    ,'Printed on ' as PrintInfo
    ,cast(null as varchar(50))  as RECDate2, cast(null as varchar(50)) as DueDate2
from _BarCodeLabel a
    left join Department b on a.DEPT = b.cDepCode
where barCode in (aaaaaaaa) and iSOsID in (bbbbbbbb)
";
                sSQL = sSQL.Replace("aaaaaaaa", sID);
                sSQL = sSQL.Replace("bbbbbbbb", sSOsID);
                DataTable dtBarCode = DbHelperSQL.Query(sSQL);
                for (int i = 0; i < dtBarCode.Rows.Count; i++)
                {
                    dtBarCode.Rows[i]["PrintInfo"] = "Printed on " + BaseFunction.ReturnDate(dtBarCode.Rows[i]["PrintTime"]).ToString("yyyy/MM/dd HH:mm:ss");
                    dtBarCode.Rows[i]["RECDate2"] = BaseFunction.ReturnDate(dtBarCode.Rows[i]["RECDate"]).ToString("yyyy-MM-dd");
                    dtBarCode.Rows[i]["DueDate2"] = BaseFunction.ReturnDate(dtBarCode.Rows[i]["DueDate"]).ToString("yyyy-MM-dd");    
                }

                Rep.dsPrint.Tables.Clear();
                Rep.dsPrint.Tables.Add(dtBarCode.Copy());
                Rep.dsPrint.Tables[0].TableName = "dtGrid";
                Rep.ShowPreview();
            }
            catch (Exception ee)
            {
                MessageBox.Show(ee.Message);
            }
        }

        private void GetBarCodeStatus(string sBarCode)
        {
            string sSQL = @"
select a.*,b.*
from [dbo].[_BarCodeLabel] a
	inner join 
		(
			select * from _BarStatus where iID in (select max(iID) from _BarStatus where BarCode = '{0}')
		)b on a.BarCode = b.BarCode and a.iSOsID = b.iSOsID
where a.BarCode = '{0}'
";
            sSQL = string.Format(sSQL, sBarCode);
            DataTable dt = DbHelperSQL.Query(sSQL);

            if (dt.Rows[0]["IQCSTATUS"].ToString().Trim().ToLower() == "iqc-onhold")
            {
                throw new Exception("Barcode " + btnTxtBarCode.Text.Trim() + " is in " + dt.Rows[0]["IQCSTATUS"].ToString().Trim().ToLower());
            }
        }
    }
}
