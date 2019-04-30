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

namespace UFIDA.U8.UAP.CustomApp.ControlForm
{
    public partial class Process : UserControl
    {
        TH.BaseClass.GetBaseData getBaseData = new GetBaseData();
        
        string sProPath = Application.StartupPath;

        UFIDA.U8.UAP.CustomApp.ControlForm.RepBaseGrid Rep = new RepBaseGrid();

        public DateTime dSerToday { get; set; }

        public string Conn { get; set; }

        public string sUserID { get; set; }

        public string sUserName { get; set; }

        public string sLogDate { get; set; }

        public string sAccID { get; set; }


        private void Frm_Load(object sender, EventArgs e)
        {
            try
            {
                DbHelperSQL.connectionString = Conn;
               
                GetGrid();
            }
            catch (Exception ee)
            {
                FrmMsgBox f = new FrmMsgBox();
                f.Text = "加载窗体失败";
                f.richTextBox1.Text = ee.Message;
                f.ShowDialog();
            }
        }

        public Process()
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

        private void btnSave_Click(object sender, EventArgs e)
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

                    for (int i = 0; i < gridView1.RowCount; i++)
                    {
                        int iID = BaseFunction.ReturnInt(gridView1.GetRowCellValue(i, gridColiID));
                        string iState = gridView1.GetRowCellValue(i, gridColiState).ToString().Trim();

                        if (iState == "")
                        {
                            continue;
                        }

                        if (gridView1.GetRowCellValue(i, gridColProcessNo).ToString().Trim() == "")
                            continue;
                   
                        Model._Process model = new UFIDA.U8.UAP.CustomApp.ControlForm.Model._Process();
                        model.ProcessNo = gridView1.GetRowCellValue(i, gridColProcessNo).ToString().Trim();
                        model.Process = gridView1.GetRowCellValue(i, gridColProcess).ToString().Trim();
                        if (model.Process == "")
                        {
                            sErr = sErr + "Row " + (i + 1).ToString() + " error\n";
                            continue;
                        }
                        
                        model.Condition = gridView1.GetRowCellValue(i, gridColCondition).ToString().Trim();
                        model.PLATINGSPEC = gridView1.GetRowCellValue(i, gridColPLATINGSPEC).ToString().Trim();
                        model.TIME = BaseFunction.ReturnDecimal(gridView1.GetRowCellValue(i, gridColTIME));
                        model.THICKNESS = gridView1.GetRowCellValue(i, gridColTHICKNESS).ToString().Trim();
                        model.AMPHRS = gridView1.GetRowCellValue(i, gridColAMPHRS).ToString().Trim();
                        model.Remark = gridView1.GetRowCellValue(i, gridColRemark).ToString().Trim();
                        
                        if (iID == 0)
                        {
                            model.CreateUid = sUserID;
                            model.CreateDate = dNowDate;

                            DAL._Process dal = new UFIDA.U8.UAP.CustomApp.ControlForm.DAL._Process();
                            sSQL = dal.Add(model);
                            iCount = iCount + DbHelperSQL.ExecuteNonQuery(tran, CommandType.Text, sSQL);
                        }
                        else
                        {
                            model.CreateUid = gridView1.GetRowCellValue(i, gridColCreateUid).ToString().Trim();
                            model.CreateDate = BaseFunction.ReturnDate(gridView1.GetRowCellValue(i, gridColCreateDate));
                            DAL._Process dal = new UFIDA.U8.UAP.CustomApp.ControlForm.DAL._Process();
                            sSQL = dal.Update(model);
                            iCount = iCount + DbHelperSQL.ExecuteNonQuery(tran, CommandType.Text, sSQL);
                        }
                    }

                    if (sErr != "")
                    {
                        throw new Exception(sErr);
                    }

                    if (iCount > 0)
                    {
                        tran.Commit();

                        MessageBox.Show("OK");

                        GetGrid();
                    }
                    else
                    {
                        throw new Exception("no data");
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

//        private void lookUpEditforeigncurrency_EditValueChanged(object sender, EventArgs e)
//        {
//            try
//            {
//                string sSQL = "";

//                lookUpEditforeigncurrencyName.EditValue = lookUpEditforeigncurrency.EditValue;

//                string sForeigncurrency = lookUpEditforeigncurrencyName.Text.Trim();
//                if (lookUpEditforeigncurrencyName.EditValue.ToString().Trim().ToLower() != "sgd")
//                {
//                    sSQL = @" 
//select * 
//from exch a inner join foreigncurrency b on a.cexch_name = b.cexch_name
//where a.cexch_name = '111111' and a.iYear = '222222' and a.iperiod = 333333
//";
//                    sSQL = sSQL.Replace("111111", sForeigncurrency);
//                    sSQL = sSQL.Replace("222222", BaseFunction.ReturnDate(sLogDate).ToString("yyyy"));
//                    sSQL = sSQL.Replace("333333", BaseFunction.ReturnInt(BaseFunction.ReturnDate(sLogDate).ToString("MM")).ToString());
//                    DataTable dtCxch = DbHelperSQL.Query(sSQL);
//                    if (dtCxch == null || dtCxch.Rows.Count == 0)
//                    {
//                        throw new Exception("Please set exchange rate");
//                    }
//                    txtnflat.Text = dtCxch.Rows[0]["nflat"].ToString().Trim();
//                    bool b = BaseFunction.ReturnBool(dtCxch.Rows[0]["bcal"]);
//                    if (b)
//                        radio1.Checked = true;
//                    else
//                        radio2.Checked = true;
//                }
//                else
//                {
//                    txtnflat.Text = "1";
//                }

//                for (int i = 0; i < gridView1.RowCount; i++)
//                {
//                    string sVenCode = lookUpEditcVenName.EditValue.ToString().Trim();
//                    string sInvCode = gridView1.GetRowCellValue(i, gridColcInvCode).ToString().Trim();
//                    decimal dQty = BaseFunction.ReturnDecimal(gridView1.GetRowCellValue(i, gridColOrderNum));


//                    sSQL = @"
//select a.dEnableDate,a.dDisableDate ,a.iLowerLimit ,a.iUpperLimit ,* ,a.iTaxRate as iInvTaxRate
//from ven_inv_price a inner join Inventory b on a.cInvCode = b.cInvCode
//where a.iSupplyType = 1 and a.cVenCode = '222222' 
//	and a.cInvCode = '333333'
//	and a.iLowerLimit <= 444444 
//	and isnull(a.dEnableDate,'2000-01-01') <= '111111'
//	and isnull(a.dDisableDate,'2099-12-30') >= '111111'
//    and (ltrim(rtrim(a.cexch_name)) = '555555' or a.cexch_name = '666666')
//order by a.iLowerLimit desc,a.dEnableDate desc
//
//";
//                    sSQL = sSQL.Replace("111111", sLogDate);
//                    sSQL = sSQL.Replace("222222", sVenCode);
//                    sSQL = sSQL.Replace("333333", sInvCode);
//                    sSQL = sSQL.Replace("444444", dQty.ToString());
//                    sSQL = sSQL.Replace("555555", lookUpEditforeigncurrencyName.Text.Trim());
//                    sSQL = sSQL.Replace("666666", lookUpEditforeigncurrency.EditValue.ToString().Trim());
//                    DataTable dtPrice = DbHelperSQL.Query(sSQL);

//                    if (dtPrice != null && dtPrice.Rows.Count > 0)
//                    {
//                        decimal dPrice = BaseFunction.ReturnDecimal(dtPrice.Rows[0]["iUnitPrice"]);
//                        decimal dSum = BaseFunction.ReturnDecimal(dPrice * dQty);

//                        gridView1.SetRowCellValue(i, gridColPrice, dPrice);
//                        gridView1.SetRowCellValue(i, gridColMoney, dSum);
//                        gridView1.SetRowCellValue(i, gridColTaxRate, BaseFunction.ReturnDecimal(dtPrice.Rows[0]["iInvtaxRate"]));
//                    }
//                    else
//                    {
//                        gridView1.SetRowCellValue(i, gridColPrice, DBNull.Value);
//                        gridView1.SetRowCellValue(i, gridColMoney, DBNull.Value);
//                        gridView1.SetRowCellValue(i, gridColTaxRate, DBNull.Value);
//                    }
//                }
//            }
//            catch (Exception ee)
//            {
//                MessageBox.Show(ee.Message);
//            }
//        }

        //private void lookUpEditforeigncurrencyName_EditValueChanged(object sender, EventArgs e)
        //{
        //    try
        //    {
        //        lookUpEditforeigncurrency.EditValue = lookUpEditforeigncurrencyName.EditValue;
        //    }
        //    catch { }
        //}

        //private void btnTxtVenCode_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        //{
        //    try
        //    {
        //        FrmVendorInfo frm = new FrmVendorInfo(btnTxtVenCode.Text.Trim());
        //        DialogResult d = frm.ShowDialog();
        //        if (d == DialogResult.OK)
        //        {
        //            btnTxtVenCode.Text = frm.sVenCode;
        //            lookUpEditcVenName.EditValue = frm.sVenCode;
        //        }
        //    }
        //    catch { }
        //}

        //private void btnTxtVenCode_KeyDown(object sender, KeyEventArgs e)
        //{
        //    try
        //    {
        //        if (e.KeyCode == Keys.F2)
        //        {
        //            btnTxtVenCode_ButtonClick(null, null);
        //        }
        //        if (e.KeyCode == Keys.Enter)
        //        {
        //            lookUpEditcVenName.EditValue = btnTxtVenCode.Text.Trim();
        //        }
        //    }
        //    catch { }
        //}

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            try
            {
                GetGrid();
            }
            catch (Exception ee)
            {
                MessageBox.Show(ee.Message);
            }
        }

        private void GetGrid()
        { 
            string sSQL = @"
select *,cast(null as varchar(50)) as iState from [_Process] order by [ProcessNo]
";
            DataTable dt = DbHelperSQL.Query(sSQL);
            gridControl1.DataSource = dt;

            gridView1.AddNewRow();
            while (gridView1.RowCount < 10)
            {
                gridView1.AddNewRow();
            }

            gridView1.FocusedRowHandle = 0;

            gridView1.BestFitColumns();
        }

        private void btnAddRow_Click(object sender, EventArgs e)
        {
            gridView1.AddNewRow();
        }

        private void btnDEL_Click(object sender, EventArgs e)
        {
            try
            {
                string sProcNo = gridView1.GetRowCellValue(gridView1.FocusedRowHandle, gridColProcessNo).ToString().Trim();
                if (sProcNo == "")
                {
                    throw new Exception("Please Choose data");
                }

                //判断是否使用


                string sSQL = "delete _Process where [ProcessNo] = '" + sProcNo + "'";
                int iCou = DbHelperSQL.ExecuteSql(sSQL);

                if (iCou > 0)
                {
                    MessageBox.Show("OK");
                    GetGrid();
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

                if (e.Column == gridColProcessNo)
                {
                    if (e.RowHandle == gridView1.RowCount - 1)
                    {
                        gridView1.AddNewRow();
                        gridView1.FocusedRowHandle = iRow;
                    }
                }

                if (e.Column != gridColiState && gridView1.GetRowCellValue(iRow, gridColiState).ToString().Trim() != "edit")
                {
                    gridView1.SetRowCellValue(iRow, gridColiState, "edit");
                }
            }
            catch { }
        }

        private void gridView1_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            try
            {
                int iID = BaseFunction.ReturnInt(gridView1.GetRowCellValue(e.FocusedRowHandle, gridColiID));
                if (iID == 0)
                {
                    gridColProcessNo.OptionsColumn.AllowEdit = true;
                }
                else
                {
                    gridColProcessNo.OptionsColumn.AllowEdit = false;
                }
            }
            catch { }
        }
    }
}
