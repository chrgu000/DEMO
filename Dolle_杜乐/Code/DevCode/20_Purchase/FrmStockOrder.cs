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
    public partial class FrmStockOrder : FrameBaseFunction.Frm列表窗体模板
    {
        public FrmStockOrder()
        {
            InitializeComponent();

            txtVenCode.Enabled = false;
        }

        private void FrmStockOrder_Load(object sender, EventArgs e)
        {
            try
            {
                string sSQL = "select vendCode,cVenName from UFDLImport.._vendUid left join @u8.Vendor on @u8.Vendor.cVenCode = vendCode where uid = '" + FrameBaseFunction.ClsBaseDataInfo.sUid + "'  and accid = 200 and accyear = " + FrameBaseFunction.ClsBaseDataInfo.sUFDataBaseName.Substring(11, 4) + " ";
                DataTable dt = clsSQLCommond.ExecQuery(sSQL);

                txtVenCode.Properties.ReadOnly = false;
                if (FrameBaseFunction.ClsBaseDataInfo.sUid == "admin" || dt.Rows.Count == 0)
                {
                    txtVenCode.Enabled = true;
                }
                else
                {
                    if (dt.Rows[0]["vendCode"].ToString().Trim() == string.Empty)
                    {
                        txtVenCode.Enabled = true;
                    }
                    else
                    {
                        txtVenCode.Enabled = false;
                    }
                    txtVenCode.EditValue = dt.Rows[0]["vendCode"].ToString().Trim();
                    txtVenCode_Leave(null, null);
                }

                if (txtVenCode.Text.Trim() == "0100412" || txtVenCode.Text.Trim() == "")
                {
                    gridCol厂商库存.Visible = true;
                    chk库存.Visible = true;
                }
                else
                {
                    gridCol厂商库存.Visible = false;
                    chk库存.Visible = false;
                }

                GetGridView();
            }
            catch (Exception ee)
            {
                MessageBox.Show("加载窗体失败！\n\t原因：" + ee.Message);
            }
        }

        /// <summary>
        /// 获得供应商订货信息
        /// </summary>
        private void GetGridView()
        {
            try
            {
                if (txtVenCode.Text != null && txtVenCode.Text.Trim() != string.Empty)
                {

                    string sSQL = "@u8._GetStockOrder '" + txtVenCode.Text.Trim() + "'";

                    DataTable dt = clsSQLCommond.ExecQuery(sSQL);
                    DataView dv = dt.DefaultView;
                    dv.Sort = "ID"; 

                    if (chkAllow.Checked)
                    {
                        dv.RowFilter = "cdefine35 is not null";
                    }

                    gridControl1.DataSource = dv;

                    //gridView1.BestFitColumns();
                    gridCol订单日期.BestFit();
                    gridCol存货编码.BestFit();
                    gridCol订单件数.BestFit();
                    gridCol未入库件数.BestFit();
                }
            }
            catch (Exception ee)
            {
                MessageBox.Show("获得供应商信息失败！\n\t原因：" + ee.Message);
            }
        }


        protected override void BtnClick(string sBtnName, string sBtnText)
        {
            try
            {
                switch (sBtnName.ToLower())
                {
                    case "sel":
                        btnSEL();
                        break;
                    case "audit":
                        btnAudit();
                        break;
                    case "unaudit":
                        btnUnAudit();
                        break;
                    case "export":
                        btnExport();
                        break;
                    case "close":
                        btnClose();
                        break;
                    default:
                        break;
                }
            }
            catch (Exception ee)
            {
                MessageBox.Show(sBtnText + " 失败! \n\n原因:\n  " + ee.Message, "提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnClose()
        {
            ArrayList aList = new ArrayList();
            string sSQL = "";
            for (int i = 0; i < gridView1.RowCount; i++)
            {
                if (gridView1.GetRowCellValue(i, gridColbChoose).ToString().Trim() == "√")
                {
                    sSQL = "update @u8.PO_Podetails set cbCloser = '" + FrameBaseFunction.ClsBaseDataInfo.sUserName + "' ,cbclosetime = '" + FrameBaseFunction.ClsBaseDataInfo.sLogDate + "' ,cbcloseDate = '" + FrameBaseFunction.ClsBaseDataInfo.sLogDate + "' where id = " + gridView1.GetRowCellValue(i, gridColumn9).ToString().Trim();
                    aList.Add(sSQL);
                }
            }
            if (aList.Count > 0)
            {
                if (DialogResult.Yes == MessageBox.Show("是否确认关闭？", "提示", MessageBoxButtons.YesNo, MessageBoxIcon.Asterisk))
                {
                    clsSQLCommond.ExecSqlTran(aList);
                    MessageBox.Show("关闭成功！");
                    btnSEL();
                }
            }
        }

        private void btnExport()
        {
            try
            {
                try
                {
                    gridView1.FocusedRowHandle -= 1;

                    gridView1.OptionsView.AllowCellMerge = false;
                }
                catch { }

                SaveFileDialog sa = new SaveFileDialog();
                sa.Filter = "Excel文件2003|*.xls";

                sa.ShowDialog();
                string sPath = sa.FileName;

                if (sPath.Trim() != string.Empty)
                {
                    gridView1.ExportToXls(sPath);
                }
            }
            catch (Exception ee)
            {
                throw new Exception("导出Excel失败：" + ee.Message);
            }
            finally 
            {
                gridView1.OptionsView.AllowCellMerge = true;
            }
        }

        private void btnUnAudit()
        {
            try
            {
                RdInReport2 rep = new RdInReport2();

                try
                {
                    gridView1.FocusedRowHandle -= 1;
                }
                catch { }


                for (int i = 0; i < gridView1.RowCount; i++)
                {
                    if (gridView1.GetRowCellValue(i, gridColumn16).ToString().Trim() == "" || Convert.ToDecimal(gridView1.GetRowCellValue(i, gridColumn16)) == 0)
                        continue;

                    DateTime d1 = DateTime.Now;
                    if (gridView1.GetRowCellValue(i, gridColumn23).ToString().Trim() != "")
                    {
                        d1 = Convert.ToDateTime(gridView1.GetRowCellValue(i, gridColumn23));
                    }
                    else if (gridView1.GetRowCellValue(i, gridColumn21).ToString().Trim() != "")
                    {
                        d1 = Convert.ToDateTime(gridView1.GetRowCellValue(i, gridColumn21));
                    }

                    DateTime d2 = DateTime.Today.AddDays(7);
                    if (d1 > d2)
                    {
                        throw new Exception("行" + (i + 1).ToString() + "提前7天，不能送货");
                    }

                }


                DataTable dt = ((DataView)gridControl1.DataSource).Table;
                int iRow = 0;

                decimal dQTY = 0;
                if (dt.Rows.Count > 0)
                {
                    for (int i = 0; i < dt.Rows.Count; i++)
                    {
                        if (dt.Rows[i]["NowQty"].ToString().Trim() != "")
                        {
                            iRow += 1;
                            DataRow dr = rep.dataSet1.Tables[0].NewRow();
                            dr["Column1"] = dt.Rows[i]["cpoid"].ToString().Trim();
                            dr["Column2"] = dt.Rows[i]["cInvCode"].ToString().Trim();
                            dr["Column3"] = dt.Rows[i]["cInvName"].ToString().Trim();
                            dr["Column4"] = dt.Rows[i]["cInvStd"].ToString().Trim();
                            dr["Column5"] = dt.Rows[i]["cinvm_unit"].ToString().Trim();
                            dr["Column6"] = dt.Rows[i]["cInva_unit"].ToString().Trim();
                            string s1 = "";
                            string s2 = "";
                            if (dt.Rows[i]["NowQty"].ToString().Trim() != "" && Convert.ToDecimal(dt.Rows[i]["NowQty"]) != 0)
                            {
                                dr["Column7"] = Convert.ToDecimal(dt.Rows[i]["NowQty"]);
                                s1 = dr["Column7"].ToString().Trim();

                                dQTY = dQTY + Convert.ToDecimal(dt.Rows[i]["NowQty"]);
                            }
                            if (dt.Rows[i]["NowNum"].ToString().Trim() != "" && Convert.ToDecimal(dt.Rows[i]["NowNum"]) != 0)
                            {
                                dr["Column8"] = Convert.ToDecimal(dt.Rows[i]["NowNum"]);
                                s2 = dr["Column8"].ToString().Trim();
                            }

                            if (dt.Rows[i]["DType"].ToString().Trim().ToString().Trim() == "0")
                                dr["Column9"] = "入 " + iRow;
                            if (dt.Rows[i]["DType"].ToString().Trim().ToString().Trim() == "2")
                                dr["Column9"] = "到 " + iRow;

                            string sBarCode = dt.Rows[i]["DType"].ToString().Trim().ToString().Trim() + "$200$" + dt.Rows[i]["id"].ToString().Trim() + "$" + s1 + "$" + s2;
                            dr["Column10"] = sBarCode;

                            if (dt.Rows[i]["cdefine36"].ToString().Trim() != "")
                            {
                                dr["Column11"] = Convert.ToDateTime(dt.Rows[i]["cdefine36"]).ToString("yyyy-MM-dd");
                            }
                            else if (dt.Rows[i]["cdefine37"].ToString().Trim() != "")
                            {
                                dr["Column11"] = Convert.ToDateTime(dt.Rows[i]["cdefine37"]).ToString("yyyy-MM-dd");
                            }
                            else
                            {
                                dr["Column11"] = Convert.ToDateTime(dt.Rows[i]["dArriveDate"]).ToString("yyyy-MM-dd");
                            }

                            dr["Column12"] = dt.Rows[i]["iquantity"].ToString().Trim();
                            if (dt.Rows[i]["iNum"].ToString().Trim() != "" && Convert.ToDecimal(dt.Rows[i]["iNum"]) != 0)
                            {
                                dr["Column13"] = dt.Rows[i]["iNum"].ToString().Trim();
                            }
                            dr["Column14"] = dt.Rows[i]["inqty"].ToString().Trim();
                            if (dt.Rows[i]["innum"].ToString().Trim() != "" && Convert.ToDecimal(dt.Rows[i]["innum"]) != 0)
                            {
                                dr["Column15"] = dt.Rows[i]["innum"].ToString().Trim();
                            }
                            rep.dataSet1.Tables[0].Rows.Add(dr);
                        }
                    }

                    DataTable dt2 = rep.dataSet1.Tables[1];
                    DataRow dRowTe = dt2.NewRow();
                    dRowTe["Column1"] = rep.dataSet1.Tables[0].Rows.Count;
                    dRowTe["Column2"] = "供应商：" + txtVenCode.Text.Trim() + "--" + txtVenName.Text.Trim();
                    dRowTe["Column3"] = "制单日期：" + DateTime.Parse(FrameBaseFunction.ClsBaseDataInfo.sLogDate).ToString("yyyy-MM-dd");
                    dRowTe["Column4"] = "制单人:" + FrameBaseFunction.ClsBaseDataInfo.sUserName;
                    dRowTe["Column5"] = "数量合计：" + dQTY.ToString().Trim();
                    dt2.Rows.Add(dRowTe);

                    rep.ShowPreview();
                }
            }
            catch (Exception ee)
            {
                MessageBox.Show("加载打印失败! \n\n原因:\n  " + ee.Message, "提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            //try
            //{
            //    RdInReportLabel rep = new RdInReportLabel();

            //    try
            //    {
            //        gridView1.FocusedRowHandle -= 1;
            //    }
            //    catch { }

            //    DataTable dt = ((DataView)gridControl1.DataSource).Table;
            //    int iRow = 0;
            //    if (dt.Rows.Count > 0)
            //    {
            //        for (int i = 0; i < dt.Rows.Count; i++)
            //        {
            //            if (dt.Rows[i]["NowQty"].ToString().Trim() != "")
            //            {
            //                iRow += 1;
            //                DataRow dr = rep.dataSet1.Tables[0].NewRow();
            //                dr["Column1"] = dt.Rows[i]["cpoid"].ToString().Trim();
            //                dr["Column2"] = dt.Rows[i]["cInvCode"].ToString().Trim();
            //                dr["Column3"] = dt.Rows[i]["cInvName"].ToString().Trim();
            //                dr["Column4"] = dt.Rows[i]["cInvStd"].ToString().Trim();
            //                dr["Column5"] = dt.Rows[i]["cinvm_unit"].ToString().Trim();
            //                dr["Column6"] = dt.Rows[i]["cInva_unit"].ToString().Trim();
            //                dr["Column7"] = dt.Rows[i]["NowQty"].ToString().Trim();
            //                dr["Column8"] = dt.Rows[i]["NowNum"].ToString().Trim();
                  
            //                dr["Column9"] = iRow;
            //                string sBarCode = "0$" + FrameBaseFunction.ClsBaseDataInfo.sUFDataBaseName.Substring(7, 3).Trim() + "$" + dt.Rows[i]["id"].ToString().Trim() + "$" + dt.Rows[i]["nowqty"].ToString().Trim() + "$" + dt.Rows[i]["NowNum"].ToString().Trim();
            //                dr["Column10"] = sBarCode;
            //                dr["Column11"] = Convert.ToDateTime(dt.Rows[i]["dArriveDate"]).ToString("yyyy-MM-dd");
            //                rep.dataSet1.Tables[0].Rows.Add(dr);
            //            }
            //        }

            //        DataTable dt2 = rep.dataSet1.Tables[1];
            //        DataRow dRowTe = dt2.NewRow();
            //        dRowTe["Column1"] = rep.dataSet1.Tables[0].Rows.Count;
            //        dRowTe["Column2"] = "供应商：" + txtVenName.Text.Trim();
            //        dRowTe["Column3"] = "制单日期：" + DateTime.Parse(FrameBaseFunction.ClsBaseDataInfo.sLogDate).ToString("yyyy-MM-dd");
            //        dRowTe["Column4"] = "制单人:" + FrameBaseFunction.ClsBaseDataInfo.sUserName;
            //        dt2.Rows.Add(dRowTe);

            //        rep.ShowPreview();
            //    }
            //}
            //catch (Exception ee)
            //{
            //    MessageBox.Show("加载打印失败! \n\n原因:\n  " + ee.Message, "提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
            //}
        }


        private void btnAudit()
        {
            try
            {
                RdInReport rep = new RdInReport();

                try
                {
                    gridView1.FocusedRowHandle -= 1;
                }
                catch { }


                for (int i = 0; i < gridView1.RowCount; i++)
                {
                    if (gridView1.GetRowCellValue(i, gridColumn16).ToString().Trim() == "" || Convert.ToDecimal(gridView1.GetRowCellValue(i, gridColumn16)) == 0)
                        continue;

                    decimal dQty = BaseFunction.ReturnDecimal(gridView1.GetRowCellValue(i, gridColumn16));
                    if (dQty <= 0)
                    {
                        throw new Exception("行" + (i + 1).ToString() + "送货数量必须大于0");
                    }

                    DateTime d1 = DateTime.Now;
                    if (gridView1.GetRowCellValue(i, gridColumn23).ToString().Trim() != "")
                    {
                        d1 = Convert.ToDateTime(gridView1.GetRowCellValue(i, gridColumn23));
                    }
                    else if (gridView1.GetRowCellValue(i, gridColumn21).ToString().Trim() != "")
                    {
                        d1 = Convert.ToDateTime(gridView1.GetRowCellValue(i, gridColumn21));
                    }

                    DateTime d2 =  DateTime.Today.AddDays(7);
                    if (d1 > d2)
                    {
                        throw new Exception("行" + (i+1).ToString() + "提前7天，不能送货");
                    }
                }


                DataTable dtTemp = ((DataView)gridControl1.DataSource).Table.Copy();
                DataView dv = dtTemp.DefaultView;
                dv.Sort = "cInvCode,dArriveDate";
                dv.RowFilter = "NowQTY <> ''";
                DataTable dt = dv.ToTable().Copy();
                int iRow = 0;

                decimal dQTY = 0;
                if (dt.Rows.Count > 0)
                {
                    for (int i = 0; i < dt.Rows.Count; i++)
                    {
                        if (dt.Rows[i]["NowQty"].ToString().Trim() != "")
                        {
                            iRow += 1;
                            DataRow dr = rep.dataSet1.Tables[0].NewRow();
                            dr["Column1"] = dt.Rows[i]["cpoid"].ToString().Trim();
                            dr["Column2"] = dt.Rows[i]["cInvCode"].ToString().Trim();
                            dr["Column3"] = dt.Rows[i]["cInvName"].ToString().Trim();
                            dr["Column4"] = dt.Rows[i]["cInvStd"].ToString().Trim();
                            dr["Column5"] = dt.Rows[i]["cinvm_unit"].ToString().Trim();
                            dr["Column6"] = dt.Rows[i]["cInva_unit"].ToString().Trim();
                            string s1 = "";
                            string s2 = "";
                            if (dt.Rows[i]["NowQty"].ToString().Trim() != "" && Convert.ToDecimal(dt.Rows[i]["NowQty"]) != 0)
                            {
                                dr["Column7"] = Convert.ToDecimal(dt.Rows[i]["NowQty"]);
                                s1 = dr["Column7"].ToString().Trim();

                                dQTY = dQTY + Convert.ToDecimal(dt.Rows[i]["NowQty"]);
                            }
                            if (dt.Rows[i]["NowNum"].ToString().Trim() != "" && Convert.ToDecimal(dt.Rows[i]["NowNum"]) != 0)
                            {
                                dr["Column8"] = Convert.ToDecimal(dt.Rows[i]["NowNum"]);
                                s2 = dr["Column8"].ToString().Trim();
                            }

                            if (dt.Rows[i]["DType"].ToString().Trim().ToString().Trim() == "0")
                                dr["Column9"] = "入 " + iRow;
                            if (dt.Rows[i]["DType"].ToString().Trim().ToString().Trim() == "2")
                                dr["Column9"] = "到 " + iRow;

                            string sBarCode = dt.Rows[i]["DType"].ToString().Trim().ToString().Trim() + "$200$" + dt.Rows[i]["id"].ToString().Trim() + "$" + s1 + "$" + s2;
                            dr["Column10"] = sBarCode;

                            if (dt.Rows[i]["cdefine36"].ToString().Trim() != "")
                            {
                                dr["Column11"] = Convert.ToDateTime(dt.Rows[i]["cdefine36"]).ToString("yyyy-MM-dd");
                            }
                            else if (dt.Rows[i]["cdefine37"].ToString().Trim() != "")
                            {
                                dr["Column11"] = Convert.ToDateTime(dt.Rows[i]["cdefine37"]).ToString("yyyy-MM-dd");
                            }
                            else
                            {
                                dr["Column11"] = Convert.ToDateTime(dt.Rows[i]["dArriveDate"]).ToString("yyyy-MM-dd");
                            }

                            dr["Column12"] = dt.Rows[i]["iquantity"].ToString().Trim();
                            if (dt.Rows[i]["iNum"].ToString().Trim() != "" && Convert.ToDecimal(dt.Rows[i]["iNum"]) != 0)
                            {
                                dr["Column13"] = dt.Rows[i]["iNum"].ToString().Trim();
                            }
                            dr["Column14"] = dt.Rows[i]["inqty"].ToString().Trim();
                            if (dt.Rows[i]["innum"].ToString().Trim() != "" && Convert.ToDecimal(dt.Rows[i]["innum"]) != 0)
                            {
                                dr["Column15"] = dt.Rows[i]["innum"].ToString().Trim();
                            }
                            dr["Column16"] = dt.Rows[i]["citemcode"].ToString().Trim();
                            dr["Column17"] = dt.Rows[i]["citemcode"].ToString().Trim();
                            dr["Column18"] = dt.Rows[i]["母件编码"].ToString().Trim();
                            dr["Column19"] = dt.Rows[i]["母件名称"].ToString().Trim();
                            rep.dataSet1.Tables[0].Rows.Add(dr);
                        }
                    }

                    DataTable dt2 = rep.dataSet1.Tables[1];
                    DataRow dRowTe = dt2.NewRow();
                    dRowTe["Column1"] = rep.dataSet1.Tables[0].Rows.Count;
                    dRowTe["Column2"] = "供应商：" + txtVenCode.Text.Trim() + "--" + txtVenName.Text.Trim();
                    dRowTe["Column3"] = "制单日期：" + DateTime.Parse(FrameBaseFunction.ClsBaseDataInfo.sLogDate).ToString("yyyy-MM-dd");
                    dRowTe["Column4"] = "制单人:" + FrameBaseFunction.ClsBaseDataInfo.sUserName;
                    dRowTe["Column5"] = "数量合计：" + dQTY.ToString().Trim();

                    if (chk库存.Checked)
                    {
                        dRowTe["Column6"] = "使用厂商库存";
                    }
                    else
                    {
                        dRowTe["Column6"] = "";
                    }
                    dt2.Rows.Add(dRowTe);

                    rep.ShowPreview();
                }
            }         
            catch (Exception ee)
            {
                MessageBox.Show("加载打印失败! \n\n原因:\n  " + ee.Message, "提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnSEL()
        {
            chk库存.Checked = false;
            GetGridView();
        }

        private void gridView1_CellValueChanged(object sender, DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs e)
        {
            try
            {
                gridView1.PostEditor();
                  double d2 =0;//超订单比率
                  try
                  {
                      d2 = Convert.ToDouble(gridView1.GetRowCellValue(e.RowHandle, gridColfInExcess));
                  }
                  catch { }

                if (e.Column == gridColumn16)
                {
                    decimal dQty = BaseFunction.ReturnDecimal(gridView1.GetRowCellValue(e.RowHandle, gridColumn16));
                    if (dQty <= 0 && gridView1.GetRowCellValue(e.RowHandle,gridColumn16).ToString().Trim() != "")
                    {
                        MessageBox.Show("送货数量必须大于0");

                        gridView1.SetRowCellValue(e.RowHandle, gridColumn16, "");
                        gridView1.SetRowCellValue(e.RowHandle, gridColumn17, "");
                    }

                    if (!ChkNumber(gridView1.GetRowCellValue(e.RowHandle, gridColumn8)))
                    {
                        MessageBox.Show("请输入数字！");
                        gridView1.SetRowCellValue(e.RowHandle, gridColumn8, "");
                        return;
                    }

                    //if(Convert.ToDouble(gridView1.GetRowCellValue(e.RowHandle, gridColumn13)) < Convert.ToDouble(gridView1.GetRowCellValue(e.RowHandle, gridColumn16)))
                    //{
                    //    MessageBox.Show("发货数量已经超出，请核查！");
                    //}
                    double d1 = 0;//订单数量
                    try
                    { 
                        d1 = Convert.ToDouble(gridView1.GetRowCellValue(e.RowHandle, gridColumn5)) ;
                    }
                    catch { }
                    double d3 = 0;//已入库数量
                    try
                    {
                        d3 = Convert.ToDouble(gridView1.GetRowCellValue(e.RowHandle, gridColumn13));
                        d3 = d1 - d3;
                    }
                    catch { }
                    double d4 = 0;//本次发货数量
                    try
                    {
                        d4 = Convert.ToDouble(gridView1.GetRowCellValue(e.RowHandle, gridColumn16));
                    }
                    catch { }
                    if (d1 * (1 + d2) <  d3 + d4)
                    {
                        MessageBox.Show("发货数量已经超出，请核查！");
                        gridView1.SetRowCellValue(e.RowHandle, gridColumn16, "");
                        gridView1.SetRowCellValue(e.RowHandle, gridColumn17, "");
                        return;
                    }
                  
                    if (gridView1.GetRowCellValue(e.RowHandle, gridCol订单件数).ToString().Trim() != "")
                    {
                        double d = Convert.ToDouble(gridView1.GetRowCellValue(e.RowHandle, gridCol订单件数)) * Convert.ToDouble(gridView1.GetRowCellValue(e.RowHandle, gridColumn16)) / Convert.ToDouble(gridView1.GetRowCellValue(e.RowHandle, gridColumn5));
                        
                        gridView1.SetRowCellValue(e.RowHandle,gridColumn17,d.ToString("0.000000"));
                    }
                }
                if (e.Column == gridColumn17)
                {
                    if (!ChkNumber(gridView1.GetRowCellValue(e.RowHandle, gridColumn17)))
                    {
                        MessageBox.Show("请输入数字！");
                        gridView1.SetRowCellValue(e.RowHandle, gridColumn17, "");
                        return;
                    }

                    //if (Convert.ToDouble(gridView1.GetRowCellValue(e.RowHandle, gridColumn11)) < Convert.ToDouble(gridView1.GetRowCellValue(e.RowHandle, gridColumn17)))
                    //{
                    //    MessageBox.Show("发货件数已经超出，请核查！");
                    //}
                    double d11 = 0;//订单件数
                    try
                    {
                        d11 = Convert.ToDouble(gridView1.GetRowCellValue(e.RowHandle, gridCol订单件数));
                    }
                    catch { }
                    double d12 = 0;//本次发货件数
                    try
                    {
                        d12 = Convert.ToDouble(gridView1.GetRowCellValue(e.RowHandle, gridColumn17));
                    }
                    catch { }
                    double d13 = 0;//已入库件数
                    try
                    {
                        d13 = Convert.ToDouble(gridView1.GetRowCellValue(e.RowHandle, gridCol未入库件数));
                        d13 = d11 - d13;
                    }
                    catch { }
                    if (d11 * (1 + d2) < d12 + d13)
                    {
                        MessageBox.Show("发货件数已经超出，请核查！");
                        gridView1.SetRowCellValue(e.RowHandle, gridColumn16, "");
                        gridView1.SetRowCellValue(e.RowHandle, gridColumn17, "");
                        return;
                    }
                }

        
            }
            catch
            { }
        }

        private bool ChkNumber(object oNum)
        {
            bool b = false;
            try
            {
                if (oNum.ToString().Trim() != string.Empty)
                {
                    double d = Convert.ToDouble(oNum);
                }

                b = true;
            }
            catch
            { }
            return b;
        }

        private void lookUpVendor_EditValueChanged(object sender, EventArgs e)
        {
            try
            {
                GetGridView();
            }
            catch (Exception ee)
            {
                MessageBox.Show("查询失败！\n\t原因：" + ee.Message);
            }
        }

        private void gridView1_RowCellStyle(object sender, DevExpress.XtraGrid.Views.Grid.RowCellStyleEventArgs e)
        {
            try
            {
                if (e.RowHandle >= 0)
                {
                    DateTime d1;
                    if (gridView1.GetRowCellValue(e.RowHandle, gridColumn23).ToString().Trim() != "")
                        d1 = DateTime.Parse(DateTime.Parse(gridView1.GetRowCellValue(e.RowHandle, gridColumn23).ToString()).ToString("yyyy-MM-dd"));
                    else if (gridView1.GetRowCellValue(e.RowHandle, gridColumn21).ToString().Trim() != "")
                        d1 = DateTime.Parse(DateTime.Parse(gridView1.GetRowCellValue(e.RowHandle, gridColumn21).ToString()).ToString("yyyy-MM-dd"));
                    else
                        d1 = DateTime.Parse(DateTime.Parse(gridView1.GetRowCellValue(e.RowHandle, gridColumn19).ToString()).ToString("yyyy-MM-dd"));

                    if (d1 < DateTime.Parse(FrameBaseFunction.ClsBaseDataInfo.sLogDate))
                    {
                        e.Appearance.BackColor = Color.Tomato;
                    }



                    DevExpress.Utils.AppearanceDefault appTomato = new DevExpress.Utils.AppearanceDefault(Color.Tomato);
                    if (e.Column == gridCol标记延期)
                    {
                        if (Convert.ToBoolean(gridView1.GetRowCellValue(e.RowHandle, gridCol标记延期)))
                        {
                            DevExpress.Utils.AppearanceHelper.Apply(e.Appearance, appTomato);
                        }
                    }
                }
            }
            catch
            { }
        }

        private void chkAllow_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                GetGridView();
            }
            catch (Exception ee)
            {
                MessageBox.Show("查询失败！\n\t原因：" + ee.Message);
            }
        }

        private void txtVenCode_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            FrmVenInfo fVen = new FrmVenInfo(txtVenCode.Text.Trim());
            if (DialogResult.OK == fVen.ShowDialog())
            {
                txtVenCode.Text = fVen.sVenCode;
                txtVenName.Text = fVen.sVenName;
            }
        }

     
        private DataTable GetVendor(string sVenCode)
        {
            try
            {
                string sSQL = "select cVenCode as iID,cVenName as iText from @u8.Vendor where cVenCode = '" + sVenCode + "' order by cVenCode";
                DataTable dt = clsGetSQL.GetLookUpEdit(sSQL);
                return dt;
            }
            catch
            {
                throw new Exception("获得供应商信息失败！");
            }
        }

        private void gridView1_CustomDrawRowIndicator(object sender, DevExpress.XtraGrid.Views.Grid.RowIndicatorCustomDrawEventArgs e)
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

        private void txtVenCode_Leave(object sender, EventArgs e)
        {
            try
            {
                DataTable dt = GetVendor(txtVenCode.Text.Trim());
                if (dt != null && dt.Rows.Count > 0)
                {
                    txtVenName.Text = dt.Rows[0]["iText"].ToString().Trim();
                    GetGridView();
                }
                else
                {
                    txtVenCode.Text = "";
                    txtVenName.Text = "";
                }
            }
            catch (Exception ee)
            {
                MessageBox.Show("获得供应商信息失败！ " + ee.Message);
            }
        }

        private void gridView1_DoubleClick(object sender, EventArgs e)
        {
            try
            {
                if (gridView1.RowCount < 1)
                    return;
                int iRow = 1;
                if (gridView1.RowCount == 1)
                    iRow = 0;
                else
                    iRow = gridView1.FocusedRowHandle;

                if (gridView1.GetRowCellValue(iRow, gridColbChoose).ToString().Trim() != "√")
                {
                    gridView1.SetRowCellValue(iRow, gridColbChoose, "√");
                }
                else
                {
                    gridView1.SetRowCellValue(iRow, gridColbChoose, "");

                }
            }
            catch (Exception ee)
            {

            }
        }
    }
}