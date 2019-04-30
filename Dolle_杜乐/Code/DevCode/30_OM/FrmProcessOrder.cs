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
    public partial class FrmProcessOrder : FrameBaseFunction.Frm¡–±Ì¥∞ÃÂƒ£∞Â
    {
        public FrmProcessOrder()
        {
            InitializeComponent();

            txtVenCode.Enabled = false;
        }


        private void FrmProcessOrder_Load(object sender, EventArgs e)
        {
            try
            {
                txtVenCode.Properties.ReadOnly = false;

                string sSQL = "select vendCode,cVenName from UFDLImport.._vendUid left join @u8.Vendor on @u8.Vendor.cVenCode = vendCode where uid = '" + FrameBaseFunction.ClsBaseDataInfo.sUid + "'  and accid = 200 and accyear = " + FrameBaseFunction.ClsBaseDataInfo.sUFDataBaseName.Substring(11, 4) + " ";
                DataTable dt = clsSQLCommond.ExecQuery(sSQL);

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

                txt’ª∞Â1.Enabled = true;
                txt’ª∞Â2.Enabled = true;
                txt’ª∞Â3.Enabled = true;
                txt’ª∞Â4.Enabled = true;
                txt’ª∞Â5.Enabled = true;
                txt’ª∞Â6.Enabled = true;
                txt’ª∞Â7.Enabled = true;
                txt’ª∞Â1.Properties.ReadOnly = false;
                txt’ª∞Â2.Properties.ReadOnly = false;
                txt’ª∞Â3.Properties.ReadOnly = false;
                txt’ª∞Â4.Properties.ReadOnly = false;
                txt’ª∞Â5.Properties.ReadOnly = false;
                txt’ª∞Â6.Properties.ReadOnly = false;
                txt’ª∞Â7.Properties.ReadOnly = false;
            }
            catch (Exception ee)
            {
                MessageBox.Show("º”‘ÿ¥∞ÃÂ ß∞‹£°\n\t‘≠“Ú£∫" + ee.Message);
            }
        }

        /// <summary>
        /// ªÒµ√ŒØÕ‚º”π§…Ã∂©ªı–≈œ¢
        /// </summary>
        private void GetGridView()
        {
            try
            {
                string sSQL = "select * from UFDLImport.._Code where vchrType = '1' order by iOrder";
                DataTable dt’ª∞Â = clsSQLCommond.ExecQuery(sSQL);
                if (dt’ª∞Â == null || dt’ª∞Â.Rows.Count < 1)
                {
                    throw new Exception("«Îµ«º«’ª∞Âµµ∞∏");
                }
                for (int i = 0; i < dt’ª∞Â.Rows.Count; i++)
                { 
                    string svchrInfo = dt’ª∞Â.Rows[i]["vchrInfo"].ToString().Trim();
                    if (label’ª∞Â1.Name == "label" + svchrInfo)
                    {
                        label’ª∞Â1.Visible = true;
                        txt’ª∞Â1.Visible = true;
                        label’ª∞Â1.Text = dt’ª∞Â.Rows[i]["vchrRemark"].ToString().Trim();
                    }
                    if (label’ª∞Â2.Name == "label" + svchrInfo)
                    {
                        label’ª∞Â2.Visible = true;
                        txt’ª∞Â2.Visible = true;
                        label’ª∞Â2.Text = dt’ª∞Â.Rows[i]["vchrRemark"].ToString().Trim();
                    }
                    if (label’ª∞Â3.Name == "label" + svchrInfo)
                    {
                        label’ª∞Â3.Visible = true;
                        txt’ª∞Â3.Visible = true;
                        label’ª∞Â3.Text = dt’ª∞Â.Rows[i]["vchrRemark"].ToString().Trim();
                    }
                    if (label’ª∞Â4.Name == "label" + svchrInfo)
                    {
                        label’ª∞Â4.Visible = true;
                        txt’ª∞Â4.Visible = true;
                        label’ª∞Â4.Text = dt’ª∞Â.Rows[i]["vchrRemark"].ToString().Trim();
                    }
                    if (label’ª∞Â5.Name == "label" + svchrInfo)
                    {
                        label’ª∞Â5.Visible = true;
                        txt’ª∞Â5.Visible = true;
                        label’ª∞Â5.Text = dt’ª∞Â.Rows[i]["vchrRemark"].ToString().Trim();
                    }
                    if (label’ª∞Â6.Name == "label" + svchrInfo)
                    {
                        label’ª∞Â6.Visible = true;
                        txt’ª∞Â6.Visible = true;
                        label’ª∞Â6.Text = dt’ª∞Â.Rows[i]["vchrRemark"].ToString().Trim();
                    }
                    if (label’ª∞Â7.Name == "label" + svchrInfo)
                    {
                        label’ª∞Â7.Visible = true;
                        txt’ª∞Â7.Visible = true;
                        label’ª∞Â7.Text = dt’ª∞Â.Rows[i]["vchrRemark"].ToString().Trim();
                    }
                    if (label’ª∞Â8.Name == "label" + svchrInfo)
                    {
                        label’ª∞Â8.Visible = true;
                        txt’ª∞Â8.Visible = true;
                        label’ª∞Â8.Text = dt’ª∞Â.Rows[i]["vchrRemark"].ToString().Trim();
                    }
                    if (label’ª∞Â9.Name == "label" + svchrInfo)
                    {
                        label’ª∞Â9.Visible = true;
                        txt’ª∞Â9.Visible = true;
                        label’ª∞Â9.Text = dt’ª∞Â.Rows[i]["vchrRemark"].ToString().Trim();
                    }
                    if (label’ª∞Â10.Name == "label" + svchrInfo)
                    {
                        label’ª∞Â10.Visible = true;
                        txt’ª∞Â10.Visible = true;
                        label’ª∞Â10.Text = dt’ª∞Â.Rows[i]["vchrRemark"].ToString().Trim();
                    }
                }


                if (txtVenCode.Text != null && txtVenCode.Text.ToString().Trim() != string.Empty)
                {
                    sSQL = "@u8._GetProcessOrder '" + txtVenCode.Text.ToString().Trim() + "'";

                    DataTable dt = clsSQLCommond.ExecQuery(sSQL);
       
                    for (int i = 0; i < dt.Rows.Count; i++)
                    {

                        //DateTime dº∆ªÆÕ–Õ‚»’∆⁄ = Convert.ToDateTime(dt.Rows[i]["º∆ªÆÕ–Õ‚»’∆⁄"]);
                        //DateTime dº∆ªÆ–Ë«Û»’∆⁄ = Convert.ToDateTime(dt.Rows[i]["º∆ªÆ–Ë«Û»’∆⁄"]);


                        //TimeSpan ts = dº∆ªÆ–Ë«Û»’∆⁄ - dº∆ªÆÕ–Õ‚»’∆⁄; 
                        //int iDay = ts.Days;

                        int iDayº∆ªÆ = ReturnObjectToInt(dt.Rows[i]["º∆ªÆŒØÕ‚÷‹∆⁄"]);
                        int i÷‹∆⁄ = ReturnObjectToInt(dt.Rows[i]["iInvAdvance"]);

                        if (i÷‹∆⁄ < iDayº∆ªÆ)
                        {
                            dt.Rows[i][" «∑Ò—πÀı÷‹∆⁄"] = 1;
                        }
                        else
                        {
                            dt.Rows[i][" «∑Ò—πÀı÷‹∆⁄"] = 0;
                        }
                    }


                    DataView dv = dt.DefaultView;

                    dv.Sort = "MODetailsID";

                    string sFilter = " 1=1 ";
                    if (chkAllow.Checked)
                    {
                        sFilter = sFilter + " and cdefine35 is not null";
                    }
                    if (!chk∫¨AK∂©µ•.Checked)
                    {
                        sFilter = sFilter + " and cCode not like 'AK%' ";
                    }
                    dv.RowFilter = sFilter;

                    gridControl1.DataSource = dv;
                }
            }
            catch (Exception ee)
            {
                MessageBox.Show("ªÒµ√ŒØÕ‚º”π§…Ã–≈œ¢ ß∞‹£°\n\t‘≠“Ú£∫" + ee.Message);
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
                    case "lock":
                        btnPrint();
                        break;
                    case "unlock":
                        btnPrintLabel();
                        break;
                    case "export":
                        btnExport();
                        break;
                    case "close":
                        btnClose();
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
                MessageBox.Show(sBtnText + "  ß∞‹! \n\n‘≠“Ú:\n  " + ee.Message, "Ã· æ", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnClose()
        {
            ArrayList aList = new ArrayList();
            string sSQL = "";
            for (int i = 0; i < gridView1.RowCount; i++)
            {
                if (gridView1.GetRowCellValue(i, gridColbChoose).ToString().Trim() == "°Ã")
                {
                    sSQL = "update @u8.OM_MODetails set cbCloser = '" + FrameBaseFunction.ClsBaseDataInfo.sUserName + "' ,dbclosetime = '" + FrameBaseFunction.ClsBaseDataInfo.sLogDate + "' ,dbcloseDate = '" + FrameBaseFunction.ClsBaseDataInfo.sLogDate + "' where MODetailsID = " + gridView1.GetRowCellValue(i, gridColumn9).ToString().Trim();
                    aList.Add(sSQL);
                }
            }
            if (aList.Count > 0)
            {
                if (DialogResult.Yes == MessageBox.Show(" «∑Ò»∑»œπÿ±’£ø", "Ã· æ", MessageBoxButtons.YesNo, MessageBoxIcon.Asterisk))
                {
                    clsSQLCommond.ExecSqlTran(aList);
                    MessageBox.Show("πÿ±’≥…π¶£°");
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
                sa.Filter = "ExcelŒƒº˛2003|*.xls";

                sa.ShowDialog();
                string sPath = sa.FileName;

                if (sPath.Trim() != string.Empty)
                {
                    gridView1.ExportToXls(sPath);
                }
            }
            catch (Exception ee)
            { 
                throw new Exception("µº≥ˆExcel ß∞‹£∫" + ee.Message);
            }
            finally
            {
                gridView1.OptionsView.AllowCellMerge = true;
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
                                dr["Column9"] = "»Î " + iRow;
                            if (dt.Rows[i]["DType"].ToString().Trim().ToString().Trim() == "3")
                                dr["Column9"] = "µΩ " + iRow;

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
                dRowTe["Column2"] = "π©”¶…Ã£∫" + txtVenCode.Text.Trim() + "--" + txtVenName.Text.Trim();
                dRowTe["Column3"] = "÷∆µ•»’∆⁄£∫" + DateTime.Parse(FrameBaseFunction.ClsBaseDataInfo.sLogDate).ToString("yyyy-MM-dd");
                dRowTe["Column4"] = "÷∆µ•»À:" + FrameBaseFunction.ClsBaseDataInfo.sUserName;
                dRowTe["Column5"] = " ˝¡ø∫œº∆£∫" + dQTY.ToString().Trim();
                dt2.Rows.Add(dRowTe);

                rep.ShowPreview();
            }
            catch (Exception ee)
            {
                MessageBox.Show("º”‘ÿ¥Ú”° ß∞‹! \n\n‘≠“Ú:\n  " + ee.Message, "Ã· æ", MessageBoxButtons.OK, MessageBoxIcon.Error);
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

                DataTable dtTemp = ((DataView)gridControl1.DataSource).Table.Copy();
                DataView dv = dtTemp.DefaultView;
                dv.Sort = "cInvCode,dDate";
                dv.RowFilter = "NowQTY <> ''";
                DataTable dt = dv.ToTable().Copy();

                decimal dQTY = 0;

                ArrayList aList = new ArrayList();

              
                RdInReport rep = new RdInReport();
                int iRow = 0;
                if (dt.Rows.Count > 0)
                {
                    for (int i = 0; i < dt.Rows.Count; i++)
                    {
                        if (dt.Rows[i]["NowQty"].ToString().Trim() == "")
                            continue;

                        decimal dNowQty = BaseFunction.ReturnDecimal(dt.Rows[i]["NowQty"]);

                        if (dNowQty <= 0)
                        {
                            throw new Exception("––" + (i + 1).ToString() + " ˝¡ø±ÿ–Î¥Û”⁄0");
                        }

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
                            dr["Column9"] = "»Î " + iRow;
                        if (dt.Rows[i]["DType"].ToString().Trim().ToString().Trim() == "3")
                            dr["Column9"] = "µΩ " + iRow;

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
                        dr["Column16"] = dt.Rows[i]["citemcode"].ToString().Trim();
                        rep.dataSet1.Tables[0].Rows.Add(dr);
                    }
                }

                #region µ«º«¥Ú”°
                
                long i’ª∞Â1 = ReturnObjectToLong(txt’ª∞Â1.Text.Trim());
                long i’ª∞Â2 = ReturnObjectToLong(txt’ª∞Â2.Text.Trim());
                long i’ª∞Â3 = ReturnObjectToLong(txt’ª∞Â3.Text.Trim());
                long i’ª∞Â4 = ReturnObjectToLong(txt’ª∞Â4.Text.Trim());
                long i’ª∞Â5 = ReturnObjectToLong(txt’ª∞Â5.Text.Trim());
                long i’ª∞Â6 = ReturnObjectToLong(txt’ª∞Â6.Text.Trim());
                long i’ª∞Â7 = ReturnObjectToLong(txt’ª∞Â7.Text.Trim());
                long i’ª∞Â8 = ReturnObjectToLong(txt’ª∞Â8.Text.Trim());
                long i’ª∞Â9 = ReturnObjectToLong(txt’ª∞Â9.Text.Trim());
                long i’ª∞Â10 = ReturnObjectToLong(txt’ª∞Â10.Text.Trim());

                string sGuid = Guid.NewGuid().ToString();
                string sSQL = "insert into UFDLImport..’ª∞Â¥Ú”°µ«º«(GUID, µ•æ›¿‡–Õ,  ’ª∞Â1, ’ª∞Â2, ’ª∞Â3, ’ª∞Â4, ’ª∞Â5, ’ª∞Â6, ’ª∞Â7, ’ª∞Â8, ’ª∞Â9, ’ª∞Â10, ˝¡ø)" +
                    "values('" + sGuid + "','ŒØÕ‚µΩªı'," + i’ª∞Â1 + "," + i’ª∞Â2 + "," + i’ª∞Â3 + "," + i’ª∞Â4 + "," + i’ª∞Â5 + "," + i’ª∞Â6 + "," + i’ª∞Â7 + "," + i’ª∞Â8 + "," + i’ª∞Â9 + "," + i’ª∞Â10 + "," + rep.dataSet1.Tables[0].Rows.Count + ")";
                clsSQLCommond.ExecSql(sSQL);

                sSQL = "select * from UFDLImport..’ª∞Â¥Ú”°µ«º« where GUID = '" + sGuid + "'";
                DataTable dt’ª∞Â¥Ú”°µ«º« = clsSQLCommond.ExecQuery(sSQL);
                string sID’ª∞Â¥Ú”°µ«º« = "";
                if (dt’ª∞Â¥Ú”°µ«º« != null && dt’ª∞Â¥Ú”°µ«º«.Rows.Count > 0)
                    sID’ª∞Â¥Ú”°µ«º« = dt’ª∞Â¥Ú”°µ«º«.Rows[0]["iID"].ToString().Trim();

                #endregion

                DataTable dt2 = rep.dataSet1.Tables[1];
                DataRow dRowTe = dt2.NewRow();
                dRowTe["Column1"] = rep.dataSet1.Tables[0].Rows.Count;
                dRowTe["Column2"] = "π©”¶…Ã£∫" + txtVenCode.Text.Trim() + "--" + txtVenName.Text.Trim();
                dRowTe["Column3"] = "÷∆µ•»’∆⁄£∫" + DateTime.Parse(FrameBaseFunction.ClsBaseDataInfo.sLogDate).ToString("yyyy-MM-dd");
                dRowTe["Column4"] = "÷∆µ•»À:" + FrameBaseFunction.ClsBaseDataInfo.sUserName;
                dRowTe["Column5"] = " ˝¡ø∫œº∆£∫" + dQTY.ToString().Trim();

                string s’ª∞Â = "";
                if (ReturnObjectToLong(txt’ª∞Â1.Text.Trim()) > 0)
                {
                    s’ª∞Â = s’ª∞Â + label’ª∞Â1.Text + "[  " + txt’ª∞Â1.Text.Trim() + "  ]  ";
                }
                if (ReturnObjectToLong(txt’ª∞Â2.Text.Trim()) > 0)
                {
                    s’ª∞Â = s’ª∞Â + label’ª∞Â2.Text + "[  " + txt’ª∞Â2.Text.Trim() + "  ]  ";
                }
                if (ReturnObjectToLong(txt’ª∞Â3.Text.Trim()) > 0)
                {
                    s’ª∞Â = s’ª∞Â + label’ª∞Â3.Text + "[  " + txt’ª∞Â3.Text.Trim() + "  ]  ";
                }
                if (ReturnObjectToLong(txt’ª∞Â4.Text.Trim()) > 0)
                {
                    s’ª∞Â = s’ª∞Â + label’ª∞Â4.Text + "[  " + txt’ª∞Â4.Text.Trim() + "  ]  ";
                }
                if (ReturnObjectToLong(txt’ª∞Â5.Text.Trim()) > 0)
                {
                    s’ª∞Â = s’ª∞Â + label’ª∞Â5.Text + "[  " + txt’ª∞Â5.Text.Trim() + "  ]  ";
                }
                if (ReturnObjectToLong(txt’ª∞Â6.Text.Trim()) > 0)
                {
                    s’ª∞Â = s’ª∞Â + label’ª∞Â6.Text + "[  " + txt’ª∞Â6.Text.Trim() + "  ]  ";
                }
                if (ReturnObjectToLong(txt’ª∞Â7.Text.Trim()) > 0)
                {
                    s’ª∞Â = s’ª∞Â + label’ª∞Â7.Text + "[  " + txt’ª∞Â7.Text.Trim() + "  ]  ";
                }
                if (ReturnObjectToLong(txt’ª∞Â8.Text.Trim()) > 0)
                {
                    s’ª∞Â = s’ª∞Â + label’ª∞Â8.Text + "[  " + txt’ª∞Â8.Text.Trim() + "  ]  ";
                }
                if (ReturnObjectToLong(txt’ª∞Â9.Text.Trim()) > 0)
                {
                    s’ª∞Â = s’ª∞Â + label’ª∞Â9.Text + "[  " + txt’ª∞Â9.Text.Trim() + "  ]  ";
                }
                if (ReturnObjectToLong(txt’ª∞Â10.Text.Trim()) > 0)
                {
                    s’ª∞Â = s’ª∞Â + label’ª∞Â10.Text + "[  " + txt’ª∞Â10.Text.Trim() + "  ]  ";
                }
                dRowTe["Column11"] = s’ª∞Â;
                dRowTe["Column12"] = sID’ª∞Â¥Ú”°µ«º«;
                dt2.Rows.Add(dRowTe);

                rep.ShowPreview();
            }
            catch (Exception ee)
            {
                MessageBox.Show("º”‘ÿ¥Ú”° ß∞‹! \n\n‘≠“Ú:\n  " + ee.Message, "Ã· æ", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void gridView1_CellValueChanged(object sender, DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs e)
        {
            try
            {
                if (e.Column == gridColumn5)
                {
                    if (!ChkNumber(gridView1.GetRowCellValue(e.RowHandle, gridColumn5)))
                    {
                        MessageBox.Show("«Î ‰»Î ˝◊÷£°");
                        gridView1.SetRowCellValue(e.RowHandle, gridColumn5, "");
                        return;
                    }


                    string sSQL = "select min(iSendQTY/(fBaseQtyN/fBaseQtyD)) from @u8.OM_MOMaterials  where MoDetailsID = " + gridView1.GetRowCellValue(e.RowHandle, gridColumn9);
                    double d1 = Convert.ToDouble(clsSQLCommond.ExecGetScalar(sSQL));
                    if (gridView1.GetRowCellValue(e.RowHandle, gridColumn16).ToString().Trim() != "")
                    {
                        if (gridView1.GetRowCellValue(e.RowHandle, gridColumn5).ToString().Trim() != "")
                        {
                            double d = Convert.ToDouble(gridView1.GetRowCellValue(e.RowHandle, gridColumn16)) * Convert.ToDouble(gridView1.GetRowCellValue(e.RowHandle, gridColumn5)) / Convert.ToDouble(gridView1.GetRowCellValue(e.RowHandle, gridColumn15));

                            gridView1.SetRowCellValue(e.RowHandle, gridColumn11, d.ToString("0.000000"));
                        }
                        else
                        {
                            gridView1.SetRowCellValue(e.RowHandle, gridColumn11, "");
                        }
                    }
                    //gridColiWIPtype ¡Ï”√¿‡–Õ   1£∫ µπ≥Â£ª       3£∫¡Ï”√

                    decimal dNow = BaseFunction.ReturnDecimal(gridView1.GetRowCellValue(e.RowHandle, gridColumn5));
                    if (dNow < 0)
                    {
                        MessageBox.Show("∑¢ªıŒ™∏∫ ˝£¨«Î∫À≤È£°");
                        gridView1.SetRowCellValue(e.RowHandle, gridColumn5, "");
                        gridView1.SetRowCellValue(e.RowHandle, gridColumn11, "");
                        return;
                    }

                    decimal dŒ¥»Îø‚ = BaseFunction.ReturnDecimal(gridView1.GetRowCellValue(e.RowHandle, gridColiUnReceivedQTY));
                    if (dNow > dŒ¥»Îø‚ && dNow != 0)
                    {
                        MessageBox.Show("∑¢ªı≥¨∂©µ•£¨«Î∫À≤È£°");
                        gridView1.SetRowCellValue(e.RowHandle, gridColumn5, "");
                        gridView1.SetRowCellValue(e.RowHandle, gridColumn11, "");
                        return;
                    }

                    if (gridView1.GetRowCellValue(e.RowHandle, gridColiWIPtype).ToString().Trim() != "1" && Convert.ToDouble(gridView1.GetRowCellValue(e.RowHandle, gridColumn5)) > Convert.ToDouble(gridView1.GetRowCellValue(e.RowHandle, gridColiUnReceivedQTY)))
                    {                     
                        MessageBox.Show("À˘µ√≤ƒ¡œ≤ª◊„∑¢ªı£¨«Î∫À≤È£°");
                        gridView1.SetRowCellValue(e.RowHandle, gridColumn5, "");
                        gridView1.SetRowCellValue(e.RowHandle, gridColumn11, "");
                        return;
                    }
                    if (Convert.ToDouble(gridView1.GetRowCellValue(e.RowHandle, gridColumn15))*(1 +Convert.ToDouble(gridView1.GetRowCellValue(e.RowHandle, gridColfInExcess)))  < Convert.ToDouble(gridView1.GetRowCellValue(e.RowHandle, gridColumn5)) + Convert.ToDouble(gridView1.GetRowCellValue(e.RowHandle, gridColumn17)))
                    {
                        MessageBox.Show("∑¢ªı ˝¡ø“—æ≠≥¨≥ˆ£¨«Î∫À≤È£°");
                        gridView1.SetRowCellValue(e.RowHandle, gridColumn5, "");
                        gridView1.SetRowCellValue(e.RowHandle, gridColumn11, "");
                        return;
                    }
                    if (Convert.ToDouble(gridView1.GetRowCellValue(e.RowHandle, gridColumn16))*(1 +Convert.ToDouble(gridView1.GetRowCellValue(e.RowHandle, gridColfInExcess)))  < Convert.ToDouble(gridView1.GetRowCellValue(e.RowHandle, gridColumn18)) + Convert.ToDouble(gridView1.GetRowCellValue(e.RowHandle, gridColumn11)))
                    {
                        MessageBox.Show("∑¢ªı ˝¡ø“—æ≠≥¨≥ˆ£¨«Î∫À≤È£°");
                        gridView1.SetRowCellValue(e.RowHandle, gridColumn5, "");
                        gridView1.SetRowCellValue(e.RowHandle, gridColumn11, "");
                        return;
                    }
                }
                if (e.Column == gridColumn11)
                {

                    if (!ChkNumber(gridView1.GetRowCellValue(e.RowHandle, gridColumn11)))
                    {
                        MessageBox.Show("«Î ‰»Î ˝◊÷£°");
                        gridView1.SetRowCellValue(e.RowHandle, gridColumn11, "");
                        return;
                    }


                    if (Convert.ToDouble(gridView1.GetRowCellValue(e.RowHandle, gridColumn10)) < Convert.ToDouble(gridView1.GetRowCellValue(e.RowHandle, gridColumn11)))
                    {
                        MessageBox.Show("∑¢ªıº˛ ˝“—æ≠≥¨≥ˆ£¨«Î∫À≤È£°");
                    }
                }
            }
            catch
            { }
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
            try
            {
                if (e.RowHandle >= 0)
                {
                    DateTime d1;
                    if (gridView1.GetRowCellValue(e.RowHandle, gridColumn22).ToString().Trim() != "")
                        d1 = DateTime.Parse(DateTime.Parse(gridView1.GetRowCellValue(e.RowHandle, gridColumn22).ToString()).ToString("yyyy-MM-dd"));
                    else if (gridView1.GetRowCellValue(e.RowHandle, gridColumn20).ToString().Trim() != "")
                        d1 = DateTime.Parse(DateTime.Parse(gridView1.GetRowCellValue(e.RowHandle, gridColumn20).ToString()).ToString("yyyy-MM-dd"));
                    else
                        d1 = DateTime.Parse(DateTime.Parse(gridView1.GetRowCellValue(e.RowHandle, gridColumn13).ToString()).ToString("yyyy-MM-dd"));

                    if (d1 < DateTime.Parse(FrameBaseFunction.ClsBaseDataInfo.sLogDate))
                    {
                        e.Appearance.BackColor = Color.Tomato;
                    }


                    DevExpress.Utils.AppearanceDefault appTomato = new DevExpress.Utils.AppearanceDefault(Color.Tomato);
                    if (e.Column == gridCol±Íº«—”∆⁄)
                    {
                        if (Convert.ToBoolean(gridView1.GetRowCellValue(e.RowHandle, gridCol±Íº«—”∆⁄)))
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
                throw new Exception("ªÒµ√π©”¶…Ã–≈œ¢ ß∞‹£°");
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
                MessageBox.Show("ªÒµ√π©”¶…Ã–≈œ¢ ß∞‹£° " + ee.Message);
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

                if (gridView1.GetRowCellValue(iRow, gridColbChoose).ToString().Trim() != "°Ã")
                {
                    gridView1.SetRowCellValue(iRow, gridColbChoose, "°Ã");
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