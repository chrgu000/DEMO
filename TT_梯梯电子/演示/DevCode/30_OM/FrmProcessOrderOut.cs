using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Collections;
using FrameBaseFunction;

namespace OM
{
    public partial class FrmProcessOrderOut : FrameBaseFunction.Frm列表窗体模板
    {
        public FrmProcessOrderOut()
        {
            InitializeComponent();
        }


        private void FrmProcessOrder_Load(object sender, EventArgs e)
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
                    txtVenCode.Text = dt.Rows[0]["vendCode"].ToString().Trim();
                    txtVenCode_Leave(null, null);
                }     
                GetGridView();
            }
            catch (Exception ee)
            {
                MessageBox.Show("加载窗体失败！\n\t原因：" + ee.Message);
            }
        }

        /// <summary>
        /// 获得委外加工商订货信息
        /// </summary>
        private void GetGridView()
        {

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
                    case "print":
                        btnPrint();
                        break;
                    case "printlabel":
                        btnPrintLabel();
                        break;
                    case "export":
                        btnExport();
                        break;
                    //case "import":
                    //    btnImport();
                    //    break;
                    default:
                        break;
                }
            }
            catch (Exception ee)
            {
                MessageBox.Show(sBtnText + " 失败! \n\n原因:\n  " + ee.Message, "提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        //private void btnImport()
        //{

        //    try
        //    {
        //        OpenFileDialog oFile = new OpenFileDialog();
        //        oFile.Filter = "Excel文件2003|*.xls|Excel文件2007|*.xlsx";
        //        if (oFile.ShowDialog() == DialogResult.OK)
        //        {
        //            string sFilePath = oFile.FileName;
        //            string sSQL = "select 单据ID,存货编码 from [Sheet1$]";

        //            TH.BaseClsInfo.ClsExcel clsExcel = TH.BaseClsInfo.ClsExcel.Instance();
        //            DataTable dtExcel = clsExcel.ExcelToDT(sFilePath, sSQL, true);
        //            if (dtExcel.Rows.Count <= 0)
        //            {
        //                MessageBox.Show("没有导入数据！");
        //                return;
        //            }

        //            ArrayList aList = new ArrayList();
        //            for (int i = 0; i < dtExcel.Rows.Count; i++)
        //            {
        //                sSQL = "update @u8.OM_MODetails set cdefine35 = '1' where [MODetailsID] =" + dtExcel.Rows[i]["单据ID"].ToString().Trim() + " and cInvCode = '" + dtExcel.Rows[i]["存货编码"].ToString().Trim() + "'";
        //                aList.Add(sSQL);
        //            }
        //            clsSQLCommond.ExecSqlTran(aList);
        //            MessageBox.Show("导入成功！");
        //            btnSEL();
        //        }
        //    }
        //    catch (Exception ee)
        //    {
        //        throw new Exception("导入Excel失败：" + ee.Message);
        //    }            
        //}

        private void btnExport()
        {
            try
            {
                try
                {
                    gridView1.FocusedRowHandle -= 1;
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
        }

        private void btnPrintLabel()
        {
            try
            {
                try
                {
                    gridView1.FocusedRowHandle -= 1;
                }
                catch { }
                DataTable dt = ((DataView)gridControl1.DataSource).Table;

                RdInReportLabel rep = new RdInReportLabel();
                int iRow = 0;
                if (dt.Rows.Count > 0)
                {
                    for (int i = 0; i < dt.Rows.Count; i++)
                    {
                        if (dt.Rows[i]["NowQty"].ToString().Trim() != "")
                        {
                            iRow += 1;
                            DataRow dr = rep.dataSet1.Tables[0].NewRow();
                            dr["Column1"] = dt.Rows[i]["cCode"].ToString().Trim();
                            dr["Column2"] = dt.Rows[i]["cInvCode"].ToString().Trim();
                            dr["Column3"] = dt.Rows[i]["cInvName"].ToString().Trim();
                            dr["Column4"] = dt.Rows[i]["cInvStd"].ToString().Trim();
                            dr["Column5"] = dt.Rows[i]["cInvm_unit"].ToString().Trim();
                            dr["Column6"] = dt.Rows[i]["cinva_unit"].ToString().Trim();
                            dr["Column7"] = dt.Rows[i]["NowQty"].ToString().Trim();
                            dr["Column8"] = dt.Rows[i]["NowNum"].ToString().Trim();
                            dr["Column9"] = iRow;
                            string sBarCode = "1$" + FrameBaseFunction.ClsBaseDataInfo.sUFDataBaseName.Substring(7, 3).Trim() + "$" + dt.Rows[i]["modetailsid"].ToString().Trim() + "$" + dt.Rows[i]["nowqty"].ToString().Trim() + "$" + dt.Rows[i]["NowNum"].ToString().Trim();
                            dr["Column10"] = sBarCode;
                            dr["Column11"] = Convert.ToDateTime(dt.Rows[i]["dDate"]).ToString("yyyy-MM-dd");
                            rep.dataSet1.Tables[0].Rows.Add(dr);
                        }
                    }
                }
                DataTable dt2 = rep.dataSet1.Tables[1];
                DataRow dRowTe = dt2.NewRow();
                dRowTe["Column1"] = rep.dataSet1.Tables[0].Rows.Count;
                dRowTe["Column2"] = "供应商：" + txtVenCode.Text.Trim();
                dRowTe["Column3"] = "制单日期：" + DateTime.Parse(FrameBaseFunction.ClsBaseDataInfo.sLogDate).ToString("yyyy-MM-dd");
                dRowTe["Column4"] = "制单人:" + FrameBaseFunction.ClsBaseDataInfo.sUserName;
                dt2.Rows.Add(dRowTe);

                rep.ShowPreview();
            }
            catch (Exception ee)
            {
                MessageBox.Show("加载打印失败! \n\n原因:\n  " + ee.Message, "提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnPrint()
        {
            try
            {
                try
                {
                    gridView1.FocusedRowHandle -= 1;
                }
                catch { }
                DataTable dt = ((DataView)gridControl1.DataSource).Table;

                decimal dQTY = 0;

                RdInReport2 rep = new RdInReport2();
                int iRow = 0;
                if (dt.Rows.Count > 0)
                {
                    for (int i = 0; i < dt.Rows.Count; i++)
                    {
                        if (dt.Rows[i]["NowQty"].ToString().Trim() != "")
                        {
                            iRow += 1;
                            DataRow dr = rep.dataSet1.Tables[0].NewRow();
                            dr["Column1"] = dt.Rows[i]["cCode"].ToString().Trim();
                            dr["Column2"] = dt.Rows[i]["cInvCode"].ToString().Trim();
                            dr["Column3"] = dt.Rows[i]["cInvName"].ToString().Trim();
                            dr["Column4"] = dt.Rows[i]["cInvStd"].ToString().Trim();
                            dr["Column5"] = dt.Rows[i]["cInvm_unit"].ToString().Trim();
                            dr["Column6"] = dt.Rows[i]["cinva_unit"].ToString().Trim();

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

                            if (dt.Rows[i]["DType"].ToString().Trim().ToString().Trim() == "1")
                                dr["Column9"] = "入 " + iRow;
                            if (dt.Rows[i]["DType"].ToString().Trim().ToString().Trim() == "3")
                                dr["Column9"] = "到 " + iRow;

                            string sBarCode = dt.Rows[i]["DType"].ToString().Trim().ToString().Trim() + "$" + FrameBaseFunction.ClsBaseDataInfo.sUFDataBaseName.Substring(7, 3).Trim() + "$" + dt.Rows[i]["modetailsid"].ToString().Trim() + "$" + s1 + "$" + s2;
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
                                dr["Column11"] = Convert.ToDateTime(dt.Rows[i]["dDate"]).ToString("yyyy-MM-dd");
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
                }
                DataTable dt2 = rep.dataSet1.Tables[1];
                DataRow dRowTe = dt2.NewRow();
                dRowTe["Column1"] = rep.dataSet1.Tables[0].Rows.Count;
                dRowTe["Column2"] = "供应商：" + txtVenName.Text.Trim();
                dRowTe["Column3"] = "制单日期：" + DateTime.Parse(FrameBaseFunction.ClsBaseDataInfo.sLogDate).ToString("yyyy-MM-dd");
                dRowTe["Column4"] = "制单人:" + FrameBaseFunction.ClsBaseDataInfo.sUserName;
                dRowTe["Column5"] = "数量合计：" + dQTY.ToString().Trim();
                dt2.Rows.Add(dRowTe);

                rep.ShowPreview();
            }
            catch (Exception ee)
            {
                MessageBox.Show("加载打印失败! \n\n原因:\n  " + ee.Message, "提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void gridView1_CellValueChanged(object sender, DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs e)
        {

        }
        private void btnSEL()
        {
            GetGridView();
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

        private void gridView1_RowCellStyle(object sender, DevExpress.XtraGrid.Views.Grid.RowCellStyleEventArgs e)
        {
          
        }

        private void chkAllow_CheckedChanged(object sender, EventArgs e)
        {
            GetGridView();
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
    }
}